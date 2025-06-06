using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0953B
{
    public class R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 : QueryBasis<R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            MAX(CODUSU)
            INTO :V0HSIN-CODUSU-LIB:VIND-CODUSU-LIB
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORHIST = :SINISHIS-OCORR-HISTORICO
            AND OPERACAO IN (1081, 1082, 1083, 1084)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											MAX(CODUSU)
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORHIST = '{this.SINISHIS_OCORR_HISTORICO}'
											AND OPERACAO IN (1081
							, 1082
							, 1083
							, 1084)";

            return query;
        }
        public string V0HSIN_CODUSU_LIB { get; set; }
        public string VIND_CODUSU_LIB { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 Execute(R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 r1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1)
        {
            var ths = r1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HSIN_CODUSU_LIB = result[i++].Value?.ToString();
            dta.VIND_CODUSU_LIB = string.IsNullOrWhiteSpace(dta.V0HSIN_CODUSU_LIB) ? "-1" : "0";
            return dta;
        }

    }
}