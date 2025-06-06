using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1 : QueryBasis<R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVTO_DEBITOCC_CEF
				SET COD_AGENCIA_DEB =  '{this.MOVDEBCE_COD_AGENCIA_DEB}',
				OPER_CONTA_DEB =  '{this.MOVDEBCE_OPER_CONTA_DEB}' ,
				NUM_CONTA_DEB =  '{this.MOVDEBCE_NUM_CONTA_DEB}' ,
				DIG_CONTA_DEB =  '{this.MOVDEBCE_DIG_CONTA_DEB}' ,
				DIA_DEBITO =  '{this.MOVDEBCE_DIA_DEBITO}' ,
				DATA_MOVIMENTO =  '{this.MOVDEBCE_DATA_MOVIMENTO}' ,
				SITUACAO_COBRANCA =  '{this.MOVDEBCE_SITUACAO_COBRANCA}',
				TIMESTAMP = CURRENT_TIMESTAMP
				WHERE  NUM_CARTAO =  '{this.MOVDEBCE_NUM_CARTAO}'
				AND NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'
				AND SITUACAO_COBRANCA = 'R'";

            return query;
        }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_DATA_MOVIMENTO { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIA_DEBITO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }

        public static void Execute(R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1 r3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1)
        {
            var ths = r3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}