using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTFASESS
{
    public class R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1 : QueryBasis<R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SI_SINISTRO_FASE
				SET DATA_FECHA_SIFA =  '{this.SISINFAS_DATA_FECHA_SIFA}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_FONTE =  '{this.SISINFAS_COD_FONTE}'
				AND NUM_PROTOCOLO_SINI =  '{this.SISINFAS_NUM_PROTOCOLO_SINI}'
				AND DAC_PROTOCOLO_SINI =  '{this.SISINFAS_DAC_PROTOCOLO_SINI}'
				AND COD_FASE =  '{this.SISINFAS_COD_FASE}'
				AND DATA_FECHA_SIFA = '9999-12-31'";

            return query;
        }
        public string SISINFAS_DATA_FECHA_SIFA { get; set; }
        public string SISINFAS_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINFAS_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINFAS_COD_FONTE { get; set; }
        public string SISINFAS_COD_FASE { get; set; }

        public static void Execute(R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1 r2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1)
        {
            var ths = r2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}