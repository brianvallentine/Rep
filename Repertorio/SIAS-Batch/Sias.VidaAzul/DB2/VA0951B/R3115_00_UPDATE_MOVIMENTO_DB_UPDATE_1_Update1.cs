using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0951B
{
    public class R3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 : QueryBasis<R3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVIMENTO
				SET TIPO_SALARIO = '0'
				WHERE  NUM_CERTIFICADO =  '{this.V0PROP_NRCERTIF}'
				AND COD_OPERACAO BETWEEN 100 AND 199
				AND COD_USUARIO IN ( 'VA0601B' , 'VP0601B' , 'VA3118B' )";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 r3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1)
        {
            var ths = r3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}