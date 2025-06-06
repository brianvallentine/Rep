using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 : QueryBasis<R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET SIT_REGISTRO = '0'
				WHERE  NUM_APOLICE =  '{this.MOVIMCOB_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVIMCOB_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVIMCOB_NUM_PARCELA}'
				AND SIT_REGISTRO = ' '
				AND TIPO_MOVIMENTO = 'Y'
				AND NUM_AVISO =  '{this.MOVIMCOB_NUM_AVISO}'";

            return query;
        }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_ENDOSSO { get; set; }
        public string MOVIMCOB_NUM_PARCELA { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }

        public static void Execute(R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 r3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1)
        {
            var ths = r3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}