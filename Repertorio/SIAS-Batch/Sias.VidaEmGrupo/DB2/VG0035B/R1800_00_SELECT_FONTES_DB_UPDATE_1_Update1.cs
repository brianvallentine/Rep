using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0035B
{
    public class R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1 : QueryBasis<R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.FONTES
				SET ULT_PROP_AUTOMAT = ULT_PROP_AUTOMAT + 1
				WHERE  COD_FONTE =  '{this.PROPOVA_COD_FONTE}'";

            return query;
        }
        public string PROPOVA_COD_FONTE { get; set; }

        public static void Execute(R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1 r1800_00_SELECT_FONTES_DB_UPDATE_1_Update1)
        {
            var ths = r1800_00_SELECT_FONTES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}