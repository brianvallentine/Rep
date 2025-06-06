using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0106B
{
    public class R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1 : QueryBasis<R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0FATURCONT
				SET DATA_REFERENCIA =  '{this.WHOST_DTREFER}'
				WHERE  NUM_APOLICE =  '{this.V1FATC_NUM_APOL}'
				AND COD_SUBGRUPO =  '{this.V1FATC_COD_SUBG}'";

            return query;
        }
        public string WHOST_DTREFER { get; set; }
        public string V1FATC_NUM_APOL { get; set; }
        public string V1FATC_COD_SUBG { get; set; }

        public static void Execute(R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1 r1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1)
        {
            var ths = r1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}