using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0041B
{
    public class R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1 : QueryBasis<R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BANCO,
            AGENCIA,
            NUMCHQ,
            DIGCHQ,
            SERCHQ
            INTO :V0LTCH-BANCO,
            :V0LTCH-AGENCIA,
            :V0LTCH-NRCHQEXT,
            :V0LTCH-DVCHQEXT,
            :V0LTCH-SERCHQ
            FROM SEGUROS.V0LOTECHEQUE
            WHERE CHQINT = :V0CCCH-NRCHQINT
            AND DIGINT = :V0CCCH-DVCHQINT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT BANCO
							,
											AGENCIA
							,
											NUMCHQ
							,
											DIGCHQ
							,
											SERCHQ
											FROM SEGUROS.V0LOTECHEQUE
											WHERE CHQINT = '{this.V0CCCH_NRCHQINT}'
											AND DIGINT = '{this.V0CCCH_DVCHQINT}'";

            return query;
        }
        public string V0LTCH_BANCO { get; set; }
        public string V0LTCH_AGENCIA { get; set; }
        public string V0LTCH_NRCHQEXT { get; set; }
        public string V0LTCH_DVCHQEXT { get; set; }
        public string V0LTCH_SERCHQ { get; set; }
        public string V0CCCH_NRCHQINT { get; set; }
        public string V0CCCH_DVCHQINT { get; set; }

        public static R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1 Execute(R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1 r0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1)
        {
            var ths = r0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0LTCH_BANCO = result[i++].Value?.ToString();
            dta.V0LTCH_AGENCIA = result[i++].Value?.ToString();
            dta.V0LTCH_NRCHQEXT = result[i++].Value?.ToString();
            dta.V0LTCH_DVCHQEXT = result[i++].Value?.ToString();
            dta.V0LTCH_SERCHQ = result[i++].Value?.ToString();
            return dta;
        }

    }
}