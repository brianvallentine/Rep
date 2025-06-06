using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3159S
{
    public class R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1 : QueryBasis<R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.LT_SOLICITA_PARAM
            WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA
            AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01
            AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO
            AND :LTSOLPAR-PARAM-DATE01 BETWEEN PARAM_DATE01
            AND PARAM_DATE02
            AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO
            END-EXEC
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.LT_SOLICITA_PARAM
				WHERE COD_PROGRAMA = '{this.LTSOLPAR_COD_PROGRAMA}'
				AND PARAM_SMINT01 = '{this.LTSOLPAR_PARAM_SMINT01}'
				AND SIT_SOLICITACAO = '{this.LTSOLPAR_SIT_SOLICITACAO}'
				AND '{this.LTSOLPAR_PARAM_DATE01}' BETWEEN PARAM_DATE01
				AND PARAM_DATE02
				AND COD_PRODUTO = '{this.LTSOLPAR_COD_PRODUTO}'";

            return query;
        }
        public string LTSOLPAR_COD_PROGRAMA { get; set; }
        public string LTSOLPAR_PARAM_SMINT01 { get; set; }
        public string LTSOLPAR_SIT_SOLICITACAO { get; set; }
        public string LTSOLPAR_PARAM_DATE01 { get; set; }
        public string LTSOLPAR_COD_PRODUTO { get; set; }

        public static void Execute(R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1 r1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1)
        {
            var ths = r1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}