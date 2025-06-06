using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0100S
{
    public class R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1 : QueryBasis<R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FORNECEDOR
				SET NUMREC =  '{this.V1FAVO_NUMREC}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CLIFOR =  '{this.V1FAVO_CODFAV}'";

            return query;
        }
        public string V1FAVO_NUMREC { get; set; }
        public string V1FAVO_CODFAV { get; set; }

        public static void Execute(R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1 r0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1)
        {
            var ths = r0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}