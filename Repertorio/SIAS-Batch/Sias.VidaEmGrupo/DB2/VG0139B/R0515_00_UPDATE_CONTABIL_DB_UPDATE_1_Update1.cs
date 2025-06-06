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
    public class R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1 : QueryBasis<R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTABILVA
				SET SITUACAO = '1'
				WHERE 
				NRCERTIF =  '{this.V0HCTB_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HCTB_NRPARCEL}'
				AND NRTIT =  '{this.V0HCTB_NRTIT}'
				AND OCOORHIST =  '{this.V0HCTB_OCORHIST}'
				AND NUM_APOLICE =  '{this.V0HCTB_NUM_APOLICE}'
				AND CODSUBES =  '{this.V0HCTB_CODSUBES}'";

            return query;
        }
        public string V0HCTB_NUM_APOLICE { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V0HCTB_NRPARCEL { get; set; }
        public string V0HCTB_OCORHIST { get; set; }
        public string V0HCTB_CODSUBES { get; set; }
        public string V0HCTB_NRTIT { get; set; }

        public static void Execute(R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1 r0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1)
        {
            var ths = r0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}