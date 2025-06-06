using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0972B
{
    public class R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1 : QueryBasis<R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_CONTROLE_CARTAO_CIELO
				SET STA_REGISTRO =  '{this.GE407_STA_REGISTRO}'
				, DTA_MOVIMENTO =  '{this.GE407_DTA_MOVIMENTO}'
				, DTH_PROCESSAMENTO = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.GE407_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.GE407_NUM_PARCELA}'
				AND SEQ_CONTROL_CARTAO =  '{this.GE407_SEQ_CONTROL_CARTAO}'
				AND NUM_OCORR_MOVTO =  '{this.GE407_NUM_OCORR_MOVTO}'";

            return query;
        }
        public string GE407_DTA_MOVIMENTO { get; set; }
        public string GE407_STA_REGISTRO { get; set; }
        public string GE407_SEQ_CONTROL_CARTAO { get; set; }
        public string GE407_NUM_CERTIFICADO { get; set; }
        public string GE407_NUM_OCORR_MOVTO { get; set; }
        public string GE407_NUM_PARCELA { get; set; }

        public static void Execute(R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1 r7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1)
        {
            var ths = r7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}