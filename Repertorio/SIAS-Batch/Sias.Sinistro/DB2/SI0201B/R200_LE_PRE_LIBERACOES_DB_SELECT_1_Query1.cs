using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0201B
{
    public class R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1 : QueryBasis<R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO),0)
            INTO :HOST-TOTAL-PRE-LIBERACAO
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO O
            WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND O.COD_OPERACAO = H.COD_OPERACAO
            AND O.IDE_SISTEMA = 'SI'
            AND O.FUNCAO_OPERACAO = 'PRE'
            AND NOT EXISTS
            (SELECT 1 FROM SEGUROS.SINISTRO_HISTORICO K
            WHERE K.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND K.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND K.COD_OPERACAO IN
            (1191,1192,1193,1194,1091,1092,1093,1094) )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(H.VAL_OPERACAO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO O
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND O.COD_OPERACAO = H.COD_OPERACAO
											AND O.IDE_SISTEMA = 'SI'
											AND O.FUNCAO_OPERACAO = 'PRE'
											AND NOT EXISTS
											(SELECT 1
							FROM SEGUROS.SINISTRO_HISTORICO K
											WHERE K.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND K.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND K.COD_OPERACAO IN
											(1191
							,1192
							,1193
							,1194
							,1091
							,1092
							,1093
							,1094) )
											WITH UR";

            return query;
        }
        public string HOST_TOTAL_PRE_LIBERACAO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1 Execute(R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1 r200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1)
        {
            var ths = r200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_TOTAL_PRE_LIBERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}