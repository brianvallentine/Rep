using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1 : QueryBasis<R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(DISTINCT M.NUM_APOL_SINISTRO),0)
            INTO :HOST-COUNT
            FROM SEGUROS.SINI_LOTERICO01 SL,
            SEGUROS.SINISTRO_MESTRE M,
            SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO O
            WHERE SL.COD_LOT_CEF = :SINILT01-COD-LOT-CEF
            AND SL.COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL
            AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO
            AND M.SIT_REGISTRO <> '2'
            AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO
            AND H.SIT_REGISTRO <> '2'
            AND H.COD_OPERACAO BETWEEN 1181 AND 1184
            AND O.COD_OPERACAO = H.COD_OPERACAO
            AND O.IND_TIPO_FUNCAO = 'IN'
            AND O.FUNCAO_OPERACAO = 'IND'
            AND O.IDE_SISTEMA = 'SI'
            AND SL.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(DISTINCT M.NUM_APOL_SINISTRO)
							,0)
											FROM SEGUROS.SINI_LOTERICO01 SL
							,
											SEGUROS.SINISTRO_MESTRE M
							,
											SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO O
											WHERE SL.COD_LOT_CEF = '{this.SINILT01_COD_LOT_CEF}'
											AND SL.COD_LOT_FENAL = '{this.SINILT01_COD_LOT_FENAL}'
											AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO
											AND M.SIT_REGISTRO <> '2'
											AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO
											AND H.SIT_REGISTRO <> '2'
											AND H.COD_OPERACAO BETWEEN 1181 AND 1184
											AND O.COD_OPERACAO = H.COD_OPERACAO
											AND O.IND_TIPO_FUNCAO = 'IN'
											AND O.FUNCAO_OPERACAO = 'IND'
											AND O.IDE_SISTEMA = 'SI'
											AND SL.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string SINILT01_COD_LOT_FENAL { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1 Execute(R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1 r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1)
        {
            var ths = r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}