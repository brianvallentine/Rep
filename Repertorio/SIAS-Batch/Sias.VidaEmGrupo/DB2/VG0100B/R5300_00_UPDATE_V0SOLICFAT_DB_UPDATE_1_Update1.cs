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
    public class R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1 : QueryBasis<R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0SOLICITAFAT
				SET SIT_REGISTRO =  '{this.V1SOLF_SIT_REG}'
				WHERE  NUM_APOLICE =  '{this.V1SOLF_NUM_APOL}'
				AND COD_SUBGRUPO =  '{this.V1SOLF_COD_SUBG}'
				AND NUM_FATURA =  '{this.V1SOLF_NUM_FAT}'
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string V1SOLF_SIT_REG { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }
        public string V1SOLF_COD_SUBG { get; set; }
        public string V1SOLF_NUM_FAT { get; set; }

        public static void Execute(R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1 r5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1)
        {
            var ths = r5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}