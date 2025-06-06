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
    public class R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1 : QueryBasis<R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPERACAO_ASS
            INTO :GESISORL-COD-OPERACAO-ASS
            FROM SEGUROS.GE_SIS_FUN_OPE_REL
            WHERE IDE_SISTEMA_FUNCAO = 'SI'
            AND COD_FUNCAO = :GESISORL-COD-FUNCAO
            AND IDE_SISTEMA_OPER = 'SI'
            AND COD_OPERACAO = :GESISORL-COD-OPERACAO
            AND IDE_SISTEMA_FC_ASS = 'AC'
            AND COD_FUNCAO_ASS = :GESISORL-COD-FUNCAO-ASS
            AND IDE_SISTEMA_OP_ASS = 'AC'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_OPERACAO_ASS
											FROM SEGUROS.GE_SIS_FUN_OPE_REL
											WHERE IDE_SISTEMA_FUNCAO = 'SI'
											AND COD_FUNCAO = '{this.GESISORL_COD_FUNCAO}'
											AND IDE_SISTEMA_OPER = 'SI'
											AND COD_OPERACAO = '{this.GESISORL_COD_OPERACAO}'
											AND IDE_SISTEMA_FC_ASS = 'AC'
											AND COD_FUNCAO_ASS = '{this.GESISORL_COD_FUNCAO_ASS}'
											AND IDE_SISTEMA_OP_ASS = 'AC'
											WITH UR";

            return query;
        }
        public string GESISORL_COD_OPERACAO_ASS { get; set; }
        public string GESISORL_COD_FUNCAO_ASS { get; set; }
        public string GESISORL_COD_OPERACAO { get; set; }
        public string GESISORL_COD_FUNCAO { get; set; }

        public static R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1 Execute(R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1 r0950_00_SELECT_GESISORL_DB_SELECT_1_Query1)
        {
            var ths = r0950_00_SELECT_GESISORL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1();
            var i = 0;
            dta.GESISORL_COD_OPERACAO_ASS = result[i++].Value?.ToString();
            return dta;
        }

    }
}