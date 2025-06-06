using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1 : QueryBasis<R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FUNCAO,
            COD_OPERACAO
            INTO :GESISORL-COD-FUNCAO,
            :GESISORL-COD-OPERACAO
            FROM SEGUROS.GE_SIS_FUN_OPE_REL
            WHERE IDE_SISTEMA_FC_ASS = :GESISFUO-IDE-SISTEMA
            AND COD_FUNCAO_ASS = :GESISFUO-COD-FUNCAO
            AND IDE_SISTEMA_OP_ASS = :GESISFUO-IDE-SISTEMA-OPER
            AND COD_OPERACAO_ASS = :V1CHSI-OPERACAO
            AND IDE_SISTEMA_FUNCAO = 'SI'
            AND IDE_SISTEMA_OPER = 'SI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FUNCAO
							,
											COD_OPERACAO
											FROM SEGUROS.GE_SIS_FUN_OPE_REL
											WHERE IDE_SISTEMA_FC_ASS = '{this.GESISFUO_IDE_SISTEMA}'
											AND COD_FUNCAO_ASS = '{this.GESISFUO_COD_FUNCAO}'
											AND IDE_SISTEMA_OP_ASS = '{this.GESISFUO_IDE_SISTEMA_OPER}'
											AND COD_OPERACAO_ASS = '{this.V1CHSI_OPERACAO}'
											AND IDE_SISTEMA_FUNCAO = 'SI'
											AND IDE_SISTEMA_OPER = 'SI'
											WITH UR";

            return query;
        }
        public string GESISORL_COD_FUNCAO { get; set; }
        public string GESISORL_COD_OPERACAO { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }
        public string GESISFUO_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }
        public string V1CHSI_OPERACAO { get; set; }

        public static R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1 Execute(R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1 r0900_00_SELECT_GESISORL_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_SELECT_GESISORL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1();
            var i = 0;
            dta.GESISORL_COD_FUNCAO = result[i++].Value?.ToString();
            dta.GESISORL_COD_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}