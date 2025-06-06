using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0967B
{
    public class R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_USUARIO AS USUARIO_LIBERADOR ,
            DATA_MOVIMENTO AS DATA_LIBERACAO
            INTO
            :SINISHIS-COD-USUARIO ,
            :SINISHIS-DATA-MOVIMENTO
            FROM
            SEGUROS.SINISTRO_HISTORICO
            WHERE
            NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND COD_OPERACAO IN (1081,1082,1083,1084,1089)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_USUARIO AS USUARIO_LIBERADOR 
							,
											DATA_MOVIMENTO AS DATA_LIBERACAO
											FROM
											SEGUROS.SINISTRO_HISTORICO
											WHERE
											NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND COD_OPERACAO IN (1081
							,1082
							,1083
							,1084
							,1089)";

            return query;
        }
        public string SINISHIS_COD_USUARIO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 r2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}