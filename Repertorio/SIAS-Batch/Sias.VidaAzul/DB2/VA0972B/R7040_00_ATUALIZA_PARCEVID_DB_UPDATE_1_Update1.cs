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
    public class R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1 : QueryBasis<R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS_VIDAZUL
				SET SIT_REGISTRO =  '{this.PARCEVID_SIT_REGISTRO}'
				, OCORR_HISTORICO = OCORR_HISTORICO + 1
				WHERE  NUM_CERTIFICADO =  '{this.PARCEVID_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.PARCEVID_NUM_PARCELA}'";

            return query;
        }
        public string PARCEVID_SIT_REGISTRO { get; set; }
        public string PARCEVID_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_NUM_PARCELA { get; set; }

        public static void Execute(R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1 r7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1)
        {
            var ths = r7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}