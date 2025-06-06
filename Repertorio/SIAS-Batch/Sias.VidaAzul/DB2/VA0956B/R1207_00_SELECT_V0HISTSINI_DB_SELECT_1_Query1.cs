using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0956B
{
    public class R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 : QueryBasis<R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(VAL_OPERACAO)
            INTO :V0HSIN-VAL-JURO:VIND-VAL-JURO
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORHIST = :SINISHIS-OCORR-HISTORICO
            AND DTMOVTO = :SINISHIS-DATA-MOVIMENTO
            AND OPERACAO IN (1301, 1302)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(VAL_OPERACAO)
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORHIST = '{this.SINISHIS_OCORR_HISTORICO}'
											AND DTMOVTO = '{this.SINISHIS_DATA_MOVIMENTO}'
											AND OPERACAO IN (1301
							, 1302)
											WITH UR";

            return query;
        }
        public string V0HSIN_VAL_JURO { get; set; }
        public string VIND_VAL_JURO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }

        public static R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 Execute(R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 r1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1)
        {
            var ths = r1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HSIN_VAL_JURO = result[i++].Value?.ToString();
            dta.VIND_VAL_JURO = string.IsNullOrWhiteSpace(dta.V0HSIN_VAL_JURO) ? "-1" : "0";
            return dta;
        }

    }
}