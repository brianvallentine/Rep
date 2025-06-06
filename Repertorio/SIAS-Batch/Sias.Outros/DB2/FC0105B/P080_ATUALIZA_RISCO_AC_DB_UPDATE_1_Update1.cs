using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC0105B
{
    public class P080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1 : QueryBasis<P080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE FDRCAP.FC_RISCO_ACOPLADO
				SET QTD_TITULOS = QTD_TITULOS - 1
				WHERE  NUM_PLANO =  '{this.FCTITULO_NUM_PLANO}'
				AND NUM_TITULO =  '{this.FCTITULO_NUM_TITULO}'";

            return query;
        }
        public string FCTITULO_NUM_TITULO { get; set; }
        public string FCTITULO_NUM_PLANO { get; set; }

        public static void Execute(P080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1 p080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1)
        {
            var ths = p080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}