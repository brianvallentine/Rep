using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1 : QueryBasis<R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVTO_DEBITOCC_CEF
				SET SITUACAO_COBRANCA =  '{this.MOVDEBCE_SITUACAO_COBRANCA}'
				, DATA_MOVIMENTO =  '{this.MOVDEBCE_DATA_MOVIMENTO}'
				, DATA_RETORNO =  '{this.MOVDEBCE_DATA_RETORNO}'
				, COD_RETORNO_CEF =  '{this.MOVDEBCE_COD_RETORNO_CEF}'
				, COD_USUARIO =  '{this.MOVDEBCE_COD_USUARIO}'
				, DTCREDITO =  {FieldThreatment((this.VIND_DTCREDITO?.ToInt() == -1 ? null : $"{this.MOVDEBCE_DTCREDITO}"))}
				WHERE  COD_CONVENIO =  '{this.MOVDEBCE_COD_CONVENIO}'
				AND NSAS =  '{this.MOVDEBCE_NSAS}'
				AND (NUM_REQUISICAO =  '{this.MOVDEBCE_NUM_REQUISICAO}'
				OR NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}')";

            return query;
        }
        public string MOVDEBCE_DTCREDITO { get; set; }
        public string VIND_DTCREDITO { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_RETORNO_CEF { get; set; }
        public string MOVDEBCE_DATA_MOVIMENTO { get; set; }
        public string MOVDEBCE_DATA_RETORNO { get; set; }
        public string MOVDEBCE_COD_USUARIO { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }

        public static void Execute(R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1 r0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1)
        {
            var ths = r0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}