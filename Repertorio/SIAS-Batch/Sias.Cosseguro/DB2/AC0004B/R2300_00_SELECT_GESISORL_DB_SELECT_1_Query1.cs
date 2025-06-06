using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0004B
{
    public class R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1 : QueryBasis<R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPERACAO_ASS
            INTO :GESISORL-COD-OPERACAO-ASS
            FROM SEGUROS.GE_SIS_FUN_OPE_REL
            WHERE IDE_SISTEMA_FUNCAO = :GESISFUO-IDE-SISTEMA
            AND COD_FUNCAO = :GESISFUO-COD-FUNCAO
            AND IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER
            AND COD_OPERACAO = :GESISFUO-COD-OPERACAO
            AND TIPO_ENDOSSO = '9'
            AND IDE_SISTEMA_FC_ASS = 'AC'
            AND COD_FUNCAO_ASS IN (02,06)
            AND IDE_SISTEMA_OP_ASS = 'AC'
            AND TIPO_ENDOSSO_ASS = '9'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_OPERACAO_ASS
											FROM SEGUROS.GE_SIS_FUN_OPE_REL
											WHERE IDE_SISTEMA_FUNCAO = '{this.GESISFUO_IDE_SISTEMA}'
											AND COD_FUNCAO = '{this.GESISFUO_COD_FUNCAO}'
											AND IDE_SISTEMA_OPER = '{this.GESISFUO_IDE_SISTEMA_OPER}'
											AND COD_OPERACAO = '{this.GESISFUO_COD_OPERACAO}'
											AND TIPO_ENDOSSO = '9'
											AND IDE_SISTEMA_FC_ASS = 'AC'
											AND COD_FUNCAO_ASS IN (02
							,06)
											AND IDE_SISTEMA_OP_ASS = 'AC'
											AND TIPO_ENDOSSO_ASS = '9'";

            return query;
        }
        public string GESISORL_COD_OPERACAO_ASS { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }
        public string GESISFUO_COD_OPERACAO { get; set; }
        public string GESISFUO_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }

        public static R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1 Execute(R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1 r2300_00_SELECT_GESISORL_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_SELECT_GESISORL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_SELECT_GESISORL_DB_SELECT_1_Query1();
            var i = 0;
            dta.GESISORL_COD_OPERACAO_ASS = result[i++].Value?.ToString();
            return dta;
        }

    }
}