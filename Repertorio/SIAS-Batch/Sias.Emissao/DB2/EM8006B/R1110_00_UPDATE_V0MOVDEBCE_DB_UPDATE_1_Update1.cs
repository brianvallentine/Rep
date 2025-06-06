using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8006B
{
    public class R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 : QueryBasis<R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.MOVTO_DEBITOCC_CEF
				SET SITUACAO_COBRANCA =
				 '{this.MOVDEBCE_SITUACAO_COBRANCA}' ,
				DATA_RETORNO =
				 {FieldThreatment((this.VIND_DTRETORNO?.ToInt() == -1 ? null : $"{this.MOVDEBCE_DATA_RETORNO}"))} ,
				COD_RETORNO_CEF =
				 {FieldThreatment((this.VIND_RETORNO?.ToInt() == -1 ? null : $"{this.MOVDEBCE_COD_RETORNO_CEF}"))} ,
				COD_USUARIO =
				 {FieldThreatment((this.VIND_USUARIO?.ToInt() == -1 ? null : $"{this.MOVDEBCE_COD_USUARIO}"))} ,
				SEQUENCIA =
				 {FieldThreatment((this.VIND_SEQUENCIA?.ToInt() == -1 ? null : $"{this.MOVDEBCE_SEQUENCIA}"))}
				WHERE  NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'
				AND COD_CONVENIO =  '{this.MOVDEBCE_COD_CONVENIO}'
				AND NSAS =  '{this.MOVDEBCE_NSAS}'";

            return query;
        }
        public string MOVDEBCE_COD_RETORNO_CEF { get; set; }
        public string VIND_RETORNO { get; set; }
        public string MOVDEBCE_DATA_RETORNO { get; set; }
        public string VIND_DTRETORNO { get; set; }
        public string MOVDEBCE_COD_USUARIO { get; set; }
        public string VIND_USUARIO { get; set; }
        public string MOVDEBCE_SEQUENCIA { get; set; }
        public string VIND_SEQUENCIA { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_NSAS { get; set; }

        public static void Execute(R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 r1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1)
        {
            var ths = r1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}