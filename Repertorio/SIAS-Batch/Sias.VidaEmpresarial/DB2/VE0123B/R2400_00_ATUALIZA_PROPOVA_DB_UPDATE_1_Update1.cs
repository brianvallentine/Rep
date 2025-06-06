using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1 : QueryBasis<R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET COD_OPERACAO =  '{this.PROPOVA_COD_OPERACAO}'
				,DATA_MOVIMENTO =  '{this.WS_DTANIVERS}'
				,OCORR_HISTORICO =  '{this.HISCOBPR_OCORR_HISTORICO}'
				,SIT_INTERFACE = '0'
				,TIMESTAMP = CURRENT TIMESTAMP
				,COD_USUARIO = 'VE0123B'
				,STA_ANTECIPACAO = 'N'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string HISCOBPR_OCORR_HISTORICO { get; set; }
        public string PROPOVA_COD_OPERACAO { get; set; }
        public string WS_DTANIVERS { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1 r2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1)
        {
            var ths = r2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}