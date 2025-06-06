using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OUTRDEBIT,
            OUTRCREDT
            INTO :WHOST-OUTRDEBIT,
            :WHOST-OUTRCREDT
            FROM SEGUROS.V0COSCED_CHEQUE
            WHERE COD_EMPRESA = :V0RELA-COD-EMPR
            AND CONGENER = :V0RELA-CONGENER
            AND DTMOVTO_AC = :V0RELA-DATA-SOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OUTRDEBIT
							,
											OUTRCREDT
											FROM SEGUROS.V0COSCED_CHEQUE
											WHERE COD_EMPRESA = '{this.V0RELA_COD_EMPR}'
											AND CONGENER = '{this.V0RELA_CONGENER}'
											AND DTMOVTO_AC = '{this.V0RELA_DATA_SOL}'";

            return query;
        }
        public string WHOST_OUTRDEBIT { get; set; }
        public string WHOST_OUTRCREDT { get; set; }
        public string V0RELA_COD_EMPR { get; set; }
        public string V0RELA_CONGENER { get; set; }
        public string V0RELA_DATA_SOL { get; set; }

        public static R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 r1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_OUTRDEBIT = result[i++].Value?.ToString();
            dta.WHOST_OUTRCREDT = result[i++].Value?.ToString();
            return dta;
        }

    }
}