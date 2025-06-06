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
    public class R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1 : QueryBasis<R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COBERAPOL
				SET DATA_INIVIGENCIA =  '{this.V0MOVC_DTQITBCO}'
				WHERE  NUM_APOLICE = 109700000028
				AND NRENDOS = 0
				AND NUM_ITEM =  '{this.V0SEGU_NUM_ITEM}'
				AND OCORHIST = 1";

            return query;
        }
        public string V0MOVC_DTQITBCO { get; set; }
        public string V0SEGU_NUM_ITEM { get; set; }

        public static void Execute(R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1 r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1)
        {
            var ths = r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}