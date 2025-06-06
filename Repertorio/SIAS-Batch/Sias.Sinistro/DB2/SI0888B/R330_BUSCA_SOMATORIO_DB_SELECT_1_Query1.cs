using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0888B
{
    public class R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1 : QueryBasis<R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(H.VAL_OPERACAO),0)
            INTO :HOST-VAL-OPERACAO
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.SINISTRO_MESTRE M,
            SEGUROS.GE_SIS_FUNCAO_OPER O
            WHERE H.DATA_MOVIMENTO BETWEEN :HOST-MOV-INICIAL
            AND :HOST-DTH-ULT-DIA-MES
            AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO
            AND H.SIT_CONTABIL IN ( '1' , '2' , '5' , '7' )
            AND O.IDE_SISTEMA_OPER = 'SI'
            AND O.COD_OPERACAO = H.COD_OPERACAO
            AND O.IDE_SISTEMA = O.IDE_SISTEMA_OPER
            AND H.COD_USUARIO <> 'RESSARC'
            AND H.NOM_PROGRAMA <> 'SI0211B'
            AND O.COD_FUNCAO IN (24, 25)
            AND O.NUM_FATOR = -1
            AND O.TIPO_ENDOSSO = '9'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(H.VAL_OPERACAO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.SINISTRO_MESTRE M
							,
											SEGUROS.GE_SIS_FUNCAO_OPER O
											WHERE H.DATA_MOVIMENTO BETWEEN '{this.HOST_MOV_INICIAL}'
											AND '{this.HOST_DTH_ULT_DIA_MES}'
											AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO
											AND H.SIT_CONTABIL IN ( '1' 
							, '2' 
							, '5' 
							, '7' )
											AND O.IDE_SISTEMA_OPER = 'SI'
											AND O.COD_OPERACAO = H.COD_OPERACAO
											AND O.IDE_SISTEMA = O.IDE_SISTEMA_OPER
											AND H.COD_USUARIO <> 'RESSARC'
											AND H.NOM_PROGRAMA <> 'SI0211B'
											AND O.COD_FUNCAO IN (24
							, 25)
											AND O.NUM_FATOR = -1
											AND O.TIPO_ENDOSSO = '9'
											WITH UR";

            return query;
        }
        public string HOST_VAL_OPERACAO { get; set; }
        public string HOST_DTH_ULT_DIA_MES { get; set; }
        public string HOST_MOV_INICIAL { get; set; }

        public static R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1 Execute(R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1 r330_BUSCA_SOMATORIO_DB_SELECT_1_Query1)
        {
            var ths = r330_BUSCA_SOMATORIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}