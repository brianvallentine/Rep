using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5001B
{
    public class R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1 : QueryBasis<R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVTO_DEBITOCC_CEF
				SET SITUACAO_COBRANCA =  '{this.MOVDEBCE_SITUACAO_COBRANCA}',
				DATA_ENVIO =  '{this.SISTEMAS_DATA_MOV_ABERTO}',
				NSAS =  '{this.MOVDEBCE_NSAS}',
				COD_USUARIO = 'SI5001B'
				WHERE  NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'
				AND COD_CONVENIO =  '{this.MOVDEBCE_COD_CONVENIO}'
				AND SITUACAO_COBRANCA = '0'";

            return query;
        }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static void Execute(R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1 r330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1)
        {
            var ths = r330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}