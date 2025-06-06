using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_530_000_INCLUI_DB_UPDATE_1_Update1 : QueryBasis<M_530_000_INCLUI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCOBVA
				SET OCORHIST =  '{this.V0HCOB_OCORHIST}'
				WHERE  NRCERTIF =  '{this.MNUM_CERTIFICADO}'
				AND NRPARCEL =  '{this.V0PROP_NRPARCELA}'";

            return query;
        }
        public string V0HCOB_OCORHIST { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string V0PROP_NRPARCELA { get; set; }

        public static void Execute(M_530_000_INCLUI_DB_UPDATE_1_Update1 m_530_000_INCLUI_DB_UPDATE_1_Update1)
        {
            var ths = m_530_000_INCLUI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_530_000_INCLUI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}