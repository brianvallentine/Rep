using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1 : QueryBasis<R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0COBERINC
				SET SITUACAO = '1'
				WHERE  NUM_APOLICE =  '{this.V0ENDO_NUM_APOL}'
				AND NUM_RISCO =  '{this.V1COBP_NUM_RISCO}'
				AND SUBRIS =  '{this.V1COBP_SUBRIS}'
				AND NRITEM =  '{this.V1COBP_NRITEM}'
				AND TIPOCOBINC =  '{this.V1COBP_TIPCOBINC}'
				AND CODCOBINC =  '{this.V1COBP_CODCOBINC}'
				AND OCORHIST =  '{this.V1COBI_OCORHIST}'
				AND SITUACAO = '0'";

            return query;
        }
        public string V1COBP_NUM_RISCO { get; set; }
        public string V1COBP_TIPCOBINC { get; set; }
        public string V1COBP_CODCOBINC { get; set; }
        public string V0ENDO_NUM_APOL { get; set; }
        public string V1COBI_OCORHIST { get; set; }
        public string V1COBP_SUBRIS { get; set; }
        public string V1COBP_NRITEM { get; set; }

        public static void Execute(R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1 r3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1)
        {
            var ths = r3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}