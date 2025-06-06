using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9268B
{
    public class R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 : QueryBasis<R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SI_AR_DETALHE_VC
				SET STA_RETORNO = '2' ,
				STA_PROCESSAMENTO = '3' ,
				OCORR_HISTORICO =  '{this.SINISHIS_OCORR_HISTORICO}'
				WHERE  NOM_ARQUIVO =  '{this.SIARDEVC_NOM_ARQUIVO}'
				AND SEQ_GERACAO =  '{this.SIARDEVC_SEQ_GERACAO}'
				AND TIPO_REGISTRO =  '{this.SIARDEVC_TIPO_REGISTRO}'
				AND SEQ_REGISTRO =  '{this.SIARDEVC_SEQ_REGISTRO}'
				AND STA_RETORNO = '2'";

            return query;
        }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SIARDEVC_TIPO_REGISTRO { get; set; }
        public string SIARDEVC_SEQ_REGISTRO { get; set; }
        public string SIARDEVC_NOM_ARQUIVO { get; set; }
        public string SIARDEVC_SEQ_GERACAO { get; set; }

        public static void Execute(R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 r1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1)
        {
            var ths = r1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}