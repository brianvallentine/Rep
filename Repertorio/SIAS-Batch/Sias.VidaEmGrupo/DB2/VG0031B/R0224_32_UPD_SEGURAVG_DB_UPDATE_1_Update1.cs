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
    public class R0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1 : QueryBasis<R0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.SEGURADOS_VGAP
				SET SIT_REGISTRO = '2'
				WHERE  NUM_APOLICE =  '{this.V0SEG_NUM_APOL}'
				AND NUM_ITEM =  '{this.V0SEG_NUM_ITEM}'";

            return query;
        }
        public string V0SEG_NUM_APOL { get; set; }
        public string V0SEG_NUM_ITEM { get; set; }

        public static void Execute(R0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1 r0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1)
        {
            var ths = r0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}