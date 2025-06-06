using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1 : QueryBasis<R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0FATURCONT
				SET DATA_REFERENCIA = DATA_REFERENCIA
				+  {this.V1SUBG_PERI_FATUR} MONTH,
				DATA_ULT_FATURAMEN =  '{this.V1SIST_DTMOVABE}'
				WHERE  NUM_APOLICE =  '{this.W1SOLF_NUM_APOL}'
				AND COD_SUBGRUPO =  '{this.W1SOLF_COD_SUBG}'";

            return query;
        }
        public string V1SUBG_PERI_FATUR { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string W1SOLF_NUM_APOL { get; set; }
        public string W1SOLF_COD_SUBG { get; set; }

        public static void Execute(R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1 r5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1)
        {
            var ths = r5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}