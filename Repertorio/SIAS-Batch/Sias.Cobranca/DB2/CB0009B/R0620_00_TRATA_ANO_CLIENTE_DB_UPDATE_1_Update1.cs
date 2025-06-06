using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1 : QueryBasis<R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0CLIENTE
				SET
				DATA_NASCIMENTO =  '{this.V0CLIE_DTNASC}'
				WHERE 
				COD_CLIENTE =  '{this.V0CLIE_CODCLIEN}'";

            return query;
        }
        public string V0CLIE_DTNASC { get; set; }
        public string V0CLIE_CODCLIEN { get; set; }

        public static void Execute(R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1 r0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1)
        {
            var ths = r0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}