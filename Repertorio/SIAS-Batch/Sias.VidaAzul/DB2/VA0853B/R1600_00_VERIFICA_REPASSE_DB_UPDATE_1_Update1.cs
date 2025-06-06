using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1 : QueryBasis<R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0DIFPARCELVA
				SET SITUACAO = '1'
				WHERE NRCERTIF =  '{this.V0PROP_NRCERTIF}'
				AND NRPARCEL =  '{this.V0PROP_NRPARCEL}'
				AND SITUACAO = ' '";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }

        public static void Execute(R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1 r1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1)
        {
            var ths = r1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}