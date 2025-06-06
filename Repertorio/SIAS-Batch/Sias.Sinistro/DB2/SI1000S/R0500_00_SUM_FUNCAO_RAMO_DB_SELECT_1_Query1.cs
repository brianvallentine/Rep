using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1000S
{
    public class R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1 : QueryBasis<R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR), 0)
            INTO :SINISHIS-VAL-OPERACAO
            FROM SEGUROS.SINISTRO_HISTORICO A,
            SEGUROS.GE_SIS_FUNCAO_OPER B,
            SEGUROS.SINISTRO_MESTRE C
            WHERE C.RAMO = :SINISMES-RAMO
            AND B.IDE_SISTEMA = :GESISFUN-IDE-SISTEMA
            AND B.COD_FUNCAO = :GESISFUN-COD-FUNCAO
            AND B.IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER
            AND B.TIPO_ENDOSSO = '9'
            AND A.DATA_MOVIMENTO >= :HOST-DATA-INICIO
            AND A.DATA_MOVIMENTO <= :HOST-DATA-FIM
            AND A.COD_OPERACAO = B.COD_OPERACAO
            AND A.NUM_APOL_SINISTRO
            = C.NUM_APOL_SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR)
							, 0)
											FROM SEGUROS.SINISTRO_HISTORICO A
							,
											SEGUROS.GE_SIS_FUNCAO_OPER B
							,
											SEGUROS.SINISTRO_MESTRE C
											WHERE C.RAMO = '{this.SINISMES_RAMO}'
											AND B.IDE_SISTEMA = '{this.GESISFUN_IDE_SISTEMA}'
											AND B.COD_FUNCAO = '{this.GESISFUN_COD_FUNCAO}'
											AND B.IDE_SISTEMA_OPER = '{this.GESISFUO_IDE_SISTEMA_OPER}'
											AND B.TIPO_ENDOSSO = '9'
											AND A.DATA_MOVIMENTO >= '{this.HOST_DATA_INICIO}'
											AND A.DATA_MOVIMENTO <= '{this.HOST_DATA_FIM}'
											AND A.COD_OPERACAO = B.COD_OPERACAO
											AND A.NUM_APOL_SINISTRO
											= C.NUM_APOL_SINISTRO";

            return query;
        }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }
        public string GESISFUN_IDE_SISTEMA { get; set; }
        public string GESISFUN_COD_FUNCAO { get; set; }
        public string HOST_DATA_INICIO { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string HOST_DATA_FIM { get; set; }

        public static R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1 Execute(R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1 r0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}