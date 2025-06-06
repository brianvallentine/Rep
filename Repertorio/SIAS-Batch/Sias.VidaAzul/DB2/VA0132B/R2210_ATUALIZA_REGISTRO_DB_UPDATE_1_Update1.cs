using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0132B
{
    public class R2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1 : QueryBasis<R2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VA_CAMPANHA_CARENCIA
				SET STA_CARENCIA =  '{this.REG_STA_CARENCIA}'
				, COD_USUARIO =  '{this.VA111_COD_USUARIO}'
				, DTH_INCLUSAO = CURRENT TIMESTAMP
				WHERE  NUM_CPF_CNPJ =  '{this.VA111_NUM_CPF_CNPJ}'
				AND STA_CARENCIA =  '{this.WS_STA_CARENCIA}'";

            return query;
        }
        public string VA111_COD_USUARIO { get; set; }
        public string REG_STA_CARENCIA { get; set; }
        public string VA111_NUM_CPF_CNPJ { get; set; }
        public string WS_STA_CARENCIA { get; set; }

        public static void Execute(R2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1 r2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1)
        {
            var ths = r2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}