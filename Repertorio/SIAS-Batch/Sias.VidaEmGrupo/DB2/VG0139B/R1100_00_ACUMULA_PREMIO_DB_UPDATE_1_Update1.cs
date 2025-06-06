using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1 : QueryBasis<R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTABILVA
				SET SITUACAO = '1' ,
				NRENDOS =  '{this.V0ENDO_NRENDOS}',
				DTFATUR =  '{this.V1SIST_DTMOVABE}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0HCTB_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HCTB_NRPARCEL}'
				AND NRTIT =  '{this.V0HCTB_NRTIT}'
				AND OCOORHIST =  '{this.V0HCTB_OCORHIST}'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0ENDO_NRENDOS { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V0HCTB_NRPARCEL { get; set; }
        public string V0HCTB_OCORHIST { get; set; }
        public string V0HCTB_NRTIT { get; set; }

        public static void Execute(R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1 r1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1)
        {
            var ths = r1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}