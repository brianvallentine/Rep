using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6254B
{
    public class R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 : QueryBasis<R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVTO_DEBITOCC_CEF
				SET SITUACAO_COBRANCA = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP,
				DATA_ENVIO =  '{this.SISTEMAS_DATA_MOV_ABERTO}',
				NSAS =  '{this.PARAMCON_NSAS}',
				COD_USUARIO = 'BI6254B'
				WHERE  NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'
				AND COD_CONVENIO =  '{this.MOVDEBCE_COD_CONVENIO}'
				AND SITUACAO_COBRANCA =  '{this.MOVDEBCE_SITUACAO_COBRANCA}'
				AND DATA_VENCIMENTO =  '{this.MOVDEBCE_DATA_VENCIMENTO}'
				AND NUM_CARTAO =  '{this.MOVDEBCE_NUM_CARTAO}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PARAMCON_NSAS { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }

        public static void Execute(R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 r0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1)
        {
            var ths = r0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}