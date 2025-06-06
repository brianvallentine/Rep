using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R2500_00_LE_SINISHIS_DB_SELECT_2_Query1 : QueryBasis<R2500_00_LE_SINISHIS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(A.VAL_OPERACAO), 0)
            INTO :HOST-VAL-RECEBIDO-EST
            FROM SEGUROS.SINISTRO_HISTORICO A
            WHERE A.NUM_APOL_SINISTRO
            = :SINISHIS-NUM-APOL-SINISTRO
            AND A.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND A.COD_OPERACAO IN (4121, 4122)
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(A.VAL_OPERACAO)
							, 0)
											FROM SEGUROS.SINISTRO_HISTORICO A
											WHERE A.NUM_APOL_SINISTRO
											= '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND A.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND A.COD_OPERACAO IN (4121
							, 4122)";

            return query;
        }
        public string HOST_VAL_RECEBIDO_EST { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R2500_00_LE_SINISHIS_DB_SELECT_2_Query1 Execute(R2500_00_LE_SINISHIS_DB_SELECT_2_Query1 r2500_00_LE_SINISHIS_DB_SELECT_2_Query1)
        {
            var ths = r2500_00_LE_SINISHIS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_LE_SINISHIS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_LE_SINISHIS_DB_SELECT_2_Query1();
            var i = 0;
            dta.HOST_VAL_RECEBIDO_EST = result[i++].Value?.ToString();
            return dta;
        }

    }
}