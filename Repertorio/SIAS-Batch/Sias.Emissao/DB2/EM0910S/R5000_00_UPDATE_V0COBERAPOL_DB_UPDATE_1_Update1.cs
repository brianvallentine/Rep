using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 : QueryBasis<R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0COBERAPOL
				SET PCT_COBERTURA =  '{this.V0COBA_PCT_COBERT}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.V0COBA_NUM_APOL}'
				AND NRENDOS =  '{this.V0COBA_NRENDOS}'
				AND NUM_ITEM =  '{this.V0COBA_NUM_ITEM}'
				AND OCORHIST =  '{this.V0COBA_OCORHIST}'
				AND RAMOFR =  '{this.V0COBA_RAMOFR}'
				AND MODALIFR =  '{this.V0COBA_MODALIFR}'";

            return query;
        }
        public string V0COBA_PCT_COBERT { get; set; }
        public string V0COBA_NUM_APOL { get; set; }
        public string V0COBA_NUM_ITEM { get; set; }
        public string V0COBA_OCORHIST { get; set; }
        public string V0COBA_MODALIFR { get; set; }
        public string V0COBA_NRENDOS { get; set; }
        public string V0COBA_RAMOFR { get; set; }

        public static void Execute(R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 r5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1)
        {
            var ths = r5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}