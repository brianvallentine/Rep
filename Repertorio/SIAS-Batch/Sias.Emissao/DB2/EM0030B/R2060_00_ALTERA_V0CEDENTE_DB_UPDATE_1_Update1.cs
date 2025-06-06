using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1 : QueryBasis<R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CEDENTE
				SET NUM_TITULO =  '{this.CEDENTE_NUM_TITULO}'
				WHERE  COD_CEDENTE =  '{this.CEDENTE_COD_CEDENTE}'";

            return query;
        }
        public string CEDENTE_NUM_TITULO { get; set; }
        public string CEDENTE_COD_CEDENTE { get; set; }

        public static void Execute(R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1 r2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1)
        {
            var ths = r2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}