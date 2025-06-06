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
    public class R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1 : QueryBasis<R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0FONTE
				SET PROPAUTOM =  '{this.V0FONT_PROPAUTOM}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.W1SUBG_COD_FONTE}'";

            return query;
        }
        public string V0FONT_PROPAUTOM { get; set; }
        public string W1SUBG_COD_FONTE { get; set; }

        public static void Execute(R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1 r1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1)
        {
            var ths = r1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}