using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9107B
{
    public class R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1 : QueryBasis<R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.OCORR_HISTORICO,
            A.VAL_IS_DATA_OCORR,
            A.DATA_OCORRENCIA
            INTO :SINIMPSE-OCORR-HISTORICO,
            :SINIMPSE-VAL-IS-DATA-OCORR,
            :SINIMPSE-DATA-OCORRENCIA
            FROM SEGUROS.SINISTRO_IMP_SEG A
            WHERE A.NUM_APOL_SINISTRO
            = :SIARDEVC-NUM-APOL-SINISTRO
            AND A.OCORR_HISTORICO =
            (SELECT MAX(B.OCORR_HISTORICO)
            FROM SEGUROS.SINISTRO_IMP_SEG B
            WHERE B.NUM_APOL_SINISTRO
            = A.NUM_APOL_SINISTRO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.OCORR_HISTORICO
							,
											A.VAL_IS_DATA_OCORR
							,
											A.DATA_OCORRENCIA
											FROM SEGUROS.SINISTRO_IMP_SEG A
											WHERE A.NUM_APOL_SINISTRO
											= '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND A.OCORR_HISTORICO =
											(SELECT MAX(B.OCORR_HISTORICO)
											FROM SEGUROS.SINISTRO_IMP_SEG B
											WHERE B.NUM_APOL_SINISTRO
											= A.NUM_APOL_SINISTRO)";

            return query;
        }
        public string SINIMPSE_OCORR_HISTORICO { get; set; }
        public string SINIMPSE_VAL_IS_DATA_OCORR { get; set; }
        public string SINIMPSE_DATA_OCORRENCIA { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }

        public static R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1 Execute(R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1 r2200_00_LE_SINIMPSE_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_LE_SINIMPSE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIMPSE_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINIMPSE_VAL_IS_DATA_OCORR = result[i++].Value?.ToString();
            dta.SINIMPSE_DATA_OCORRENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}