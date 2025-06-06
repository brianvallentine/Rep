using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0862B
{
    public class R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1 : QueryBasis<R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR),0)
            INTO :HOST-VALOR
            FROM SEGUROS.SINISTRO_MESTRE M,
            SEGUROS.SINI_LOTERICO01 SL,
            SEGUROS.GE_SIS_FUNCAO_OPER O,
            SEGUROS.SINISTRO_HISTORICO H
            WHERE M.COD_PRODUTO = 7105
            AND M.NUM_APOLICE = :HOST-APOLICE
            AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO
            AND SL.COD_COBERTURA <> 4
            AND H.COD_OPERACAO IN (1003,1004,1050)
            AND O.IDE_SISTEMA = 'SI'
            AND O.COD_FUNCAO = 2
            AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA
            AND O.COD_OPERACAO = H.COD_OPERACAO
            AND O.TIPO_ENDOSSO = '9'
            AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL
            AND :HOST-DATA-FINAL
            AND NOT EXISTS
            (SELECT S.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO S
            WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND S.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND S.COD_OPERACAO = 1070)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR)
							,0)
											FROM SEGUROS.SINISTRO_MESTRE M
							,
											SEGUROS.SINI_LOTERICO01 SL
							,
											SEGUROS.GE_SIS_FUNCAO_OPER O
							,
											SEGUROS.SINISTRO_HISTORICO H
											WHERE M.COD_PRODUTO = 7105
											AND M.NUM_APOLICE = '{this.HOST_APOLICE}'
											AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO
											AND SL.COD_COBERTURA <> 4
											AND H.COD_OPERACAO IN (1003
							,1004
							,1050)
											AND O.IDE_SISTEMA = 'SI'
											AND O.COD_FUNCAO = 2
											AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA
											AND O.COD_OPERACAO = H.COD_OPERACAO
											AND O.TIPO_ENDOSSO = '9'
											AND H.DATA_MOVIMENTO BETWEEN '{this.HOST_DATA_INICIAL}'
											AND '{this.HOST_DATA_FINAL}'
											AND NOT EXISTS
											(SELECT S.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO S
											WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND S.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND S.COD_OPERACAO = 1070)";

            return query;
        }
        public string HOST_VALOR { get; set; }
        public string HOST_DATA_INICIAL { get; set; }
        public string HOST_DATA_FINAL { get; set; }
        public string HOST_APOLICE { get; set; }

        public static R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1 Execute(R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1 r130_GRAVA_COLUNA_J_DB_SELECT_1_Query1)
        {
            var ths = r130_GRAVA_COLUNA_J_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}