using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 : QueryBasis<R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET NUM_APOLICE =  '{this.MOVIMCOB_NUM_APOLICE}',
				NUM_ENDOSSO =  '{this.MOVIMCOB_NUM_ENDOSSO}',
				NUM_PARCELA =  '{this.MOVIMCOB_NUM_PARCELA}'
				WHERE  NUM_APOLICE =  '{this.WHOST_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.WHOST_NUM_ENDOSSO}'
				AND NUM_PARCELA IN (0, 1)
				AND SIT_REGISTRO = '0'
				AND TIPO_MOVIMENTO = 'Y'
				AND NUM_AVISO =  '{this.MOVIMCOB_NUM_AVISO}'";

            return query;
        }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_ENDOSSO { get; set; }
        public string MOVIMCOB_NUM_PARCELA { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string WHOST_NUM_APOLICE { get; set; }
        public string WHOST_NUM_ENDOSSO { get; set; }

        public static void Execute(R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 r0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1)
        {
            var ths = r0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}