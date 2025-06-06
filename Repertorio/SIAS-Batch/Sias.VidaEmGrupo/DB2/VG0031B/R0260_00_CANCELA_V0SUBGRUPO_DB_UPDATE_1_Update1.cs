using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1 : QueryBasis<R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0SUBGRUPO
				SET SIT_REGISTRO = '2'
				WHERE  NUM_APOLICE =  '{this.V0SUBG_NUM_APOL}'
				AND COD_SUBGRUPO =  '{this.V0SUBG_COD_SUBG}'";

            return query;
        }
        public string V0SUBG_NUM_APOL { get; set; }
        public string V0SUBG_COD_SUBG { get; set; }

        public static void Execute(R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1 r0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1)
        {
            var ths = r0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}