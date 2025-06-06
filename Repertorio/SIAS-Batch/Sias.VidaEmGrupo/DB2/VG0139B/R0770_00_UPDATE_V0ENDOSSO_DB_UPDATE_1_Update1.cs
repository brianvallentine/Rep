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
    public class R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 : QueryBasis<R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0ENDOSSO
				SET DTTERVIG =  '{this.WHOST_DTTERVIG}'
				WHERE  NUM_APOLICE =  '{this.V0HCTB_NUM_APOLICE}'
				AND NRENDOS = 0";

            return query;
        }
        public string WHOST_DTTERVIG { get; set; }
        public string V0HCTB_NUM_APOLICE { get; set; }

        public static void Execute(R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 r0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1)
        {
            var ths = r0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}