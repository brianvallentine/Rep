using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R3000_10_CONTINUA_DB_UPDATE_1_Update1 : QueryBasis<R3000_10_CONTINUA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FUNCIOCEF
				SET COD_ANGARIADOR =  '{this.V1FUNC_COD_ANGAR}'
				WHERE  NUM_MATRICULA =  '{this.V1FUNC_NUM_MATRIC}'
				AND NUM_CPF =  '{this.V1FUNC_NUM_CPF}'";

            return query;
        }
        public string V1FUNC_COD_ANGAR { get; set; }
        public string V1FUNC_NUM_MATRIC { get; set; }
        public string V1FUNC_NUM_CPF { get; set; }

        public static void Execute(R3000_10_CONTINUA_DB_UPDATE_1_Update1 r3000_10_CONTINUA_DB_UPDATE_1_Update1)
        {
            var ths = r3000_10_CONTINUA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_10_CONTINUA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}