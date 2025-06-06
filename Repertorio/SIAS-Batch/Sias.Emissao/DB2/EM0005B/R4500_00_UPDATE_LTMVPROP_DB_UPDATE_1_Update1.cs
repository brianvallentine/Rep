using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1 : QueryBasis<R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.LT_MOV_PROPOSTA
				SET NUM_APOLICE =  '{this.V0ENDO_NUM_APOL}'
				WHERE  COD_FONTE =  '{this.V1PROP_FONTE}'
				AND NUM_PROPOSTA =  '{this.V1PROP_NRPROPOS}'";

            return query;
        }
        public string V0ENDO_NUM_APOL { get; set; }
        public string V1PROP_NRPROPOS { get; set; }
        public string V1PROP_FONTE { get; set; }

        public static void Execute(R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1 r4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1)
        {
            var ths = r4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}