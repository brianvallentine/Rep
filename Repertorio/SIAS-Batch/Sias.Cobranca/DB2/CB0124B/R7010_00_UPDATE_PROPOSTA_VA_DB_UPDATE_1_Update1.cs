using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1 : QueryBasis<R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO = '4'
				, COD_USUARIO = 'CB0124B'
				, TIMESTAMP = CURRENT_TIMESTAMP
				, DATA_MOVIMENTO =  '{this.SISTEMAS_DATA_MOV_ABERTO}'
				WHERE  NUM_CERTIFICADO =  '{this.V0PROP_NRCERTIF}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1 r7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1)
        {
            var ths = r7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}