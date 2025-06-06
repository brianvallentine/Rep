using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1700_10_LOOP_DB_UPDATE_1_Update1 : QueryBasis<R1700_10_LOOP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIS_COBER_PROPOST
				SET DATA_TERVIGENCIA =  '{this.WHOST_DTTERVIG}'
				WHERE  NUM_CERTIFICADO =  '{this.V0PROP_NRCERTIF}'
				AND OCORR_HISTORICO =  '{this.V0PROP_OCORHIST}'";

            return query;
        }
        public string WHOST_DTTERVIG { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_OCORHIST { get; set; }

        public static void Execute(R1700_10_LOOP_DB_UPDATE_1_Update1 r1700_10_LOOP_DB_UPDATE_1_Update1)
        {
            var ths = r1700_10_LOOP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1700_10_LOOP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}