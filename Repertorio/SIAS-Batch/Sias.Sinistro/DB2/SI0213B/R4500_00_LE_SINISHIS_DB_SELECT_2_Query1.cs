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
    public class R4500_00_LE_SINISHIS_DB_SELECT_2_Query1 : QueryBasis<R4500_00_LE_SINISHIS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(A.VAL_OPERACAO), 0)
            INTO :HOST-VAL-RECEBIDO-EST
            FROM SEGUROS.SINISTRO_HISTORICO A,
            SEGUROS.SI_RESSARC_PARCELA B
            WHERE A.NUM_APOL_SINISTRO
            = :SINISHIS-NUM-APOL-SINISTRO
            AND B.NUM_RESSARC = :SI111-NUM-RESSARC
            AND B.SEQ_RESSARC = :SI111-SEQ-RESSARC
            AND B.NUM_PARCELA = :SI111-NUM-PARCELA
            AND A.COD_OPERACAO IN (4121, 4122)
            AND A.NUM_APOL_SINISTRO
            = B.NUM_APOL_SINISTRO
            AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
            AND A.COD_OPERACAO = B.COD_OPERACAO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(A.VAL_OPERACAO)
							, 0)
											FROM SEGUROS.SINISTRO_HISTORICO A
							,
											SEGUROS.SI_RESSARC_PARCELA B
											WHERE A.NUM_APOL_SINISTRO
											= '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND B.NUM_RESSARC = '{this.SI111_NUM_RESSARC}'
											AND B.SEQ_RESSARC = '{this.SI111_SEQ_RESSARC}'
											AND B.NUM_PARCELA = '{this.SI111_NUM_PARCELA}'
											AND A.COD_OPERACAO IN (4121
							, 4122)
											AND A.NUM_APOL_SINISTRO
											= B.NUM_APOL_SINISTRO
											AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
											AND A.COD_OPERACAO = B.COD_OPERACAO";

            return query;
        }
        public string HOST_VAL_RECEBIDO_EST { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SI111_NUM_RESSARC { get; set; }
        public string SI111_SEQ_RESSARC { get; set; }
        public string SI111_NUM_PARCELA { get; set; }

        public static R4500_00_LE_SINISHIS_DB_SELECT_2_Query1 Execute(R4500_00_LE_SINISHIS_DB_SELECT_2_Query1 r4500_00_LE_SINISHIS_DB_SELECT_2_Query1)
        {
            var ths = r4500_00_LE_SINISHIS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4500_00_LE_SINISHIS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4500_00_LE_SINISHIS_DB_SELECT_2_Query1();
            var i = 0;
            dta.HOST_VAL_RECEBIDO_EST = result[i++].Value?.ToString();
            return dta;
        }

    }
}