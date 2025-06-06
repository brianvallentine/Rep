using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1320_00_TRATA_DV_DB_UPDATE_1_Update1 : QueryBasis<R1320_00_TRATA_DV_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET DIG_CONTA_VENDEDOR =  '{this.PROPOVA_DIG_CONTA_VENDEDOR}'
				WHERE NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_DIG_CONTA_VENDEDOR { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1320_00_TRATA_DV_DB_UPDATE_1_Update1 r1320_00_TRATA_DV_DB_UPDATE_1_Update1)
        {
            var ths = r1320_00_TRATA_DV_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1320_00_TRATA_DV_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}