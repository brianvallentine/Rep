using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1 : QueryBasis<R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.FONTES
				SET ULT_PROP_AUTOMAT =  '{this.WHOST_PROP_AUTOMAT}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_FONTE =  '{this.SUBGVGAP_COD_FONTE}'";

            return query;
        }
        public string WHOST_PROP_AUTOMAT { get; set; }
        public string SUBGVGAP_COD_FONTE { get; set; }

        public static void Execute(R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1 r3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1)
        {
            var ths = r3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}