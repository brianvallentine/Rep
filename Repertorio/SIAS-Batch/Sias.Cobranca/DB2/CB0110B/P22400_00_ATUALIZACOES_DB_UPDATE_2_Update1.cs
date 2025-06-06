using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P22400_00_ATUALIZACOES_DB_UPDATE_2_Update1 : QueryBasis<P22400_00_ATUALIZACOES_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS
				SET QTD_DOCUMENTOS =  '{this.PARCELAS_QTD_DOCUMENTOS}'
				,TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.FOLLOUP_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.FOLLOUP_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.FOLLOUP_NUM_PARCELA}'";

            return query;
        }
        public string PARCELAS_QTD_DOCUMENTOS { get; set; }
        public string FOLLOUP_NUM_APOLICE { get; set; }
        public string FOLLOUP_NUM_ENDOSSO { get; set; }
        public string FOLLOUP_NUM_PARCELA { get; set; }

        public static void Execute(P22400_00_ATUALIZACOES_DB_UPDATE_2_Update1 p22400_00_ATUALIZACOES_DB_UPDATE_2_Update1)
        {
            var ths = p22400_00_ATUALIZACOES_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P22400_00_ATUALIZACOES_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}