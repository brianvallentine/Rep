using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1500_LE_SINISHIS_DB_SELECT_1_Query1 : QueryBasis<R1500_LE_SINISHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(A.OCORR_HISTORICO), 0)
            INTO :HOST-MIN-OCORR-HISTORICO
            FROM SEGUROS.SINISTRO_HISTORICO A
            WHERE A.COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND A.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO
            AND A.DATA_MOVIMENTO <= '2008-11-01'
            AND NOT EXISTS
            (SELECT B.OCORR_HISTORICO
            FROM SEGUROS.SI_RESSARC_PARCELA B
            WHERE A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO
            AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
            AND A.COD_OPERACAO = B.COD_OPERACAO)
            AND NOT EXISTS
            (SELECT C.OCORR_HISTORICO
            FROM SEGUROS.SINISTRO_HISTORICO C
            WHERE A.NUM_APOL_SINISTRO = C.NUM_APOL_SINISTRO
            AND A.OCORR_HISTORICO = C.OCORR_HISTORICO
            AND C.COD_OPERACAO = 4100)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(A.OCORR_HISTORICO)
							, 0)
											FROM SEGUROS.SINISTRO_HISTORICO A
											WHERE A.COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND A.NUM_APOL_SINISTRO = '{this.SI111_NUM_APOL_SINISTRO}'
											AND A.DATA_MOVIMENTO <= '2008-11-01'
											AND NOT EXISTS
											(SELECT B.OCORR_HISTORICO
											FROM SEGUROS.SI_RESSARC_PARCELA B
											WHERE A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO
											AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
											AND A.COD_OPERACAO = B.COD_OPERACAO)
											AND NOT EXISTS
											(SELECT C.OCORR_HISTORICO
											FROM SEGUROS.SINISTRO_HISTORICO C
											WHERE A.NUM_APOL_SINISTRO = C.NUM_APOL_SINISTRO
											AND A.OCORR_HISTORICO = C.OCORR_HISTORICO
											AND C.COD_OPERACAO = 4100)";

            return query;
        }
        public string HOST_MIN_OCORR_HISTORICO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static R1500_LE_SINISHIS_DB_SELECT_1_Query1 Execute(R1500_LE_SINISHIS_DB_SELECT_1_Query1 r1500_LE_SINISHIS_DB_SELECT_1_Query1)
        {
            var ths = r1500_LE_SINISHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_LE_SINISHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_LE_SINISHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_MIN_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}