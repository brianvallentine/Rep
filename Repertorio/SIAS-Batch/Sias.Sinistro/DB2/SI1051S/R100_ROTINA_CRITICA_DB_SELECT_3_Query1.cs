using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1051S
{
    public class R100_ROTINA_CRITICA_DB_SELECT_3_Query1 : QueryBasis<R100_ROTINA_CRITICA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-COUNT
            FROM SEGUROS.SI_RESSARC_PARCELA P
            WHERE P.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND P.NUM_RESSARC = :SI111-NUM-RESSARC
            AND P.SEQ_RESSARC = :SI111-SEQ-RESSARC
            AND P.NUM_PARCELA = :SI111-NUM-PARCELA
            AND P.COD_OPERACAO = 4290
            AND EXISTS
            (SELECT H.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
            AND H.OCORR_HISTORICO = P.OCORR_HISTORICO
            AND H.COD_OPERACAO = P.COD_OPERACAO)
            AND NOT EXISTS
            (SELECT H.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
            AND H.OCORR_HISTORICO = P.OCORR_HISTORICO
            AND H.COD_OPERACAO IN (4291,4293,4292))
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.SI_RESSARC_PARCELA P
											WHERE P.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND P.NUM_RESSARC = '{this.SI111_NUM_RESSARC}'
											AND P.SEQ_RESSARC = '{this.SI111_SEQ_RESSARC}'
											AND P.NUM_PARCELA = '{this.SI111_NUM_PARCELA}'
											AND P.COD_OPERACAO = 4290
											AND EXISTS
											(SELECT H.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
											AND H.OCORR_HISTORICO = P.OCORR_HISTORICO
											AND H.COD_OPERACAO = P.COD_OPERACAO)
											AND NOT EXISTS
											(SELECT H.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
											AND H.OCORR_HISTORICO = P.OCORR_HISTORICO
											AND H.COD_OPERACAO IN (4291
							,4293
							,4292))";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SI111_NUM_RESSARC { get; set; }
        public string SI111_SEQ_RESSARC { get; set; }
        public string SI111_NUM_PARCELA { get; set; }

        public static R100_ROTINA_CRITICA_DB_SELECT_3_Query1 Execute(R100_ROTINA_CRITICA_DB_SELECT_3_Query1 r100_ROTINA_CRITICA_DB_SELECT_3_Query1)
        {
            var ths = r100_ROTINA_CRITICA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_ROTINA_CRITICA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_ROTINA_CRITICA_DB_SELECT_3_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}