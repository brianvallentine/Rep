using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0017B
{
    public class R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPERACAO
            INTO :WHOST-OPERACAO
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI
            AND OCORHIST = :V1HSIN-OCORHIST
            AND OPERACAO IN (2017,3017)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPERACAO
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V1MSIN_NUM_SINI}'
											AND OCORHIST = '{this.V1HSIN_OCORHIST}'
											AND OPERACAO IN (2017
							,3017)";

            return query;
        }
        public string WHOST_OPERACAO { get; set; }
        public string V1MSIN_NUM_SINI { get; set; }
        public string V1HSIN_OCORHIST { get; set; }

        public static R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1 Execute(R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1 r0600_00_SELECT_2017_3017_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_SELECT_2017_3017_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}