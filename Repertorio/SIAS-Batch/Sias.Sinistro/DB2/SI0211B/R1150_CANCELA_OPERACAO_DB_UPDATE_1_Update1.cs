using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1 : QueryBasis<R1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_HISTORICO
				SET SIT_REGISTRO =  '{this.SINISHIS_SIT_REGISTRO}'
				WHERE  NUM_APOL_SINISTRO =  '{this.SINISHIS_NUM_APOL_SINISTRO}'
				AND OCORR_HISTORICO =  '{this.SINISHIS_OCORR_HISTORICO}'
				AND COD_OPERACAO =  '{this.SINISHIS_COD_OPERACAO}'";

            return query;
        }
        public string SINISHIS_SIT_REGISTRO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static void Execute(R1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1 r1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1)
        {
            var ths = r1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}