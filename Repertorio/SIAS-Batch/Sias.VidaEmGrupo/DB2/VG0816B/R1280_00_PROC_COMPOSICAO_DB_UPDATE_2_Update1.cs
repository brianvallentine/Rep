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
    public class R1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1 : QueryBasis<R1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELVA
				SET SITUACAO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0HCOB_NRCERTIF}'
				AND NRPARCEL =  '{this.V0CMPT_NRPARCEL}'";

            return query;
        }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0CMPT_NRPARCEL { get; set; }

        public static void Execute(R1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1 r1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1)
        {
            var ths = r1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}