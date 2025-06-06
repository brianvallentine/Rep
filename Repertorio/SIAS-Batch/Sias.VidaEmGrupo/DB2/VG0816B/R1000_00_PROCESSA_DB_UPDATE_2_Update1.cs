using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R1000_00_PROCESSA_DB_UPDATE_2_Update1 : QueryBasis<R1000_00_PROCESSA_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCOBVA
				SET SITUACAO =  '{this.WHOST_SITUACAO}',
				OCORHIST =  '{this.V0HCOB_OCORHIST}',
				BCOAVISO =  '{this.V0MOVC_BCOAVISO}',
				AGEAVISO =  '{this.V0MOVC_AGEAVISO}',
				NRAVISO =  '{this.V0MOVC_NRAVISO}' ,
				NRTITCOMP =  '{this.V0MOVC_NRTIT}'
				WHERE  NRCERTIF =  '{this.V0HCOB_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HCOB_NRPARCEL}'";

            return query;
        }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0MOVC_BCOAVISO { get; set; }
        public string V0MOVC_AGEAVISO { get; set; }
        public string WHOST_SITUACAO { get; set; }
        public string V0MOVC_NRAVISO { get; set; }
        public string V0MOVC_NRTIT { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }

        public static void Execute(R1000_00_PROCESSA_DB_UPDATE_2_Update1 r1000_00_PROCESSA_DB_UPDATE_2_Update1)
        {
            var ths = r1000_00_PROCESSA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}