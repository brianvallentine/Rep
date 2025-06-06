using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0112B
{
    public class R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 : QueryBasis<R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVTO_DEBITOCC_CEF
				SET SITUACAO_COBRANCA = '5'
				, DATA_ENVIO =  '{this.SISTEMAS_DATA_MOV_ABERTO}'
				, NSAS =  '{this.PARAMCON_NSAS}'
				, NUM_ENDOSSO =  '{this.WS_NSL}'
				WHERE  COD_CONVENIO =  '{this.MOVDEBCE_COD_CONVENIO}'
				AND NSAS =  '{this.MOVDEBCE_NSAS}'
				AND NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'
				AND SITUACAO_COBRANCA =  '{this.MOVDEBCE_SITUACAO_COBRANCA}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PARAMCON_NSAS { get; set; }
        public string WS_NSL { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_NSAS { get; set; }

        public static void Execute(R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 r0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1)
        {
            var ths = r0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}