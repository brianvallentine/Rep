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
    public class P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1 : QueryBasis<P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE FDRCAP.FC_TITULO
				SET COD_SUB_STATUS = 'CAN'
				,NOM_ULT_PROGRAMA = 'FC0105B'
				WHERE  NUM_PLANO =  '{this.FCTITULO_NUM_PLANO}'
				AND NUM_SERIE =  '{this.FCTITULO_NUM_SERIE}'
				AND NUM_TITULO =  '{this.FCTITULO_NUM_TITULO}'";

            return query;
        }
        public string FCTITULO_NUM_TITULO { get; set; }
        public string FCTITULO_NUM_PLANO { get; set; }
        public string FCTITULO_NUM_SERIE { get; set; }

        public static void Execute(P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1 p060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1)
        {
            var ths = p060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}