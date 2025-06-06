using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 : QueryBasis<R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SI_AR_DETALHE_VC
				SET STA_PROCESSAMENTO =
				 '{this.SIARDEVC_STA_PROCESSAMENTO}',
				STA_RETORNO = '1' ,
				NUM_APOL_SINISTRO =
				 '{this.SIARDEVC_NUM_APOL_SINISTRO}',
				OCORR_HISTORICO =
				 '{this.SIARDEVC_OCORR_HISTORICO}',
				COD_ERRO =
				 {FieldThreatment((this.IND_COD_ERRO?.ToInt() == -1 ? null : $"{this.SIARDEVC_COD_ERRO}"))}
				WHERE  NOM_ARQUIVO =  '{this.SIARDEVC_NOM_ARQUIVO}'
				AND SEQ_GERACAO =  '{this.SIARDEVC_SEQ_GERACAO}'
				AND TIPO_REGISTRO =  '{this.SIARDEVC_TIPO_REGISTRO}'
				AND SEQ_REGISTRO =  '{this.SIARDEVC_SEQ_REGISTRO}'";

            return query;
        }
        public string SIARDEVC_COD_ERRO { get; set; }
        public string IND_COD_ERRO { get; set; }
        public string SIARDEVC_STA_PROCESSAMENTO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_OCORR_HISTORICO { get; set; }
        public string SIARDEVC_TIPO_REGISTRO { get; set; }
        public string SIARDEVC_SEQ_REGISTRO { get; set; }
        public string SIARDEVC_NOM_ARQUIVO { get; set; }
        public string SIARDEVC_SEQ_GERACAO { get; set; }

        public static void Execute(R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 r3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1)
        {
            var ths = r3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}