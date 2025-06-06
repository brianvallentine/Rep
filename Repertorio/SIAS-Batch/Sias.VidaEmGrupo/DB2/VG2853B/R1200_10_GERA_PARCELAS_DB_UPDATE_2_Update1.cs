using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2853B
{
    public class R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1 : QueryBasis<R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0DIFPARCELVA
				SET SITUACAO = '1'
				WHERE  NRCERTIF =  '{this.V0PROP_NRCERTIF}'
				AND NRPARCEL =  '{this.V0PROP_NRPARCEL}'";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }

        public static void Execute(R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1 r1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1)
        {
            var ths = r1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}