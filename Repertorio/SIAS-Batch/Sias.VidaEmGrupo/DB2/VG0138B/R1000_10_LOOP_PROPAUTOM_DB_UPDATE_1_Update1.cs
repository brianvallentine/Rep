using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0138B
{
    public class R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1 : QueryBasis<R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FONTE
				SET PROPAUTOM =  '{this.V1FONT_PROPAUTOM}'
				WHERE  FONTE =  '{this.V0ENDO_FONTE}'";

            return query;
        }
        public string V1FONT_PROPAUTOM { get; set; }
        public string V0ENDO_FONTE { get; set; }

        public static void Execute(R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1 r1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1)
        {
            var ths = r1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}