using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1 : QueryBasis<R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
				SET COD_SITUACAO =  '{this.GE403_COD_SITUACAO}',
				COD_USUARIO =  '{this.GE403_COD_USUARIO}' ,
				DTH_PROCESSAMENTO = CURRENT_TIMESTAMP
				WHERE  NUM_PROPOSTA =  '{this.GE403_NUM_PROPOSTA}'
				AND NUM_CERTIFICADO =  '{this.GE403_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.GE403_NUM_PARCELA}'
				AND NUM_APOLICE =  '{this.GE403_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.GE403_NUM_ENDOSSO}'
				AND SEQ_CONTROLE_SIGCB =  '{this.GE403_SEQ_CONTROLE_SIGCB}'";

            return query;
        }
        public string GE403_COD_SITUACAO { get; set; }
        public string GE403_COD_USUARIO { get; set; }
        public string GE403_SEQ_CONTROLE_SIGCB { get; set; }
        public string GE403_NUM_CERTIFICADO { get; set; }
        public string GE403_NUM_PROPOSTA { get; set; }
        public string GE403_NUM_PARCELA { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }

        public static void Execute(R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1 r3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1)
        {
            var ths = r3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}