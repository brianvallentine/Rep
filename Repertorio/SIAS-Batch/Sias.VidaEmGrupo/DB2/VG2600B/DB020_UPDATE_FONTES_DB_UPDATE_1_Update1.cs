using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class DB020_UPDATE_FONTES_DB_UPDATE_1_Update1 : QueryBasis<DB020_UPDATE_FONTES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.FONTES
				SET ULT_PROP_AUTOMAT =  '{this.FONTES_ULT_PROP_AUTOMAT}'
				WHERE COD_FONTE =  '{this.FONTES_COD_FONTE}'";

            return query;
        }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string FONTES_COD_FONTE { get; set; }

        public static void Execute(DB020_UPDATE_FONTES_DB_UPDATE_1_Update1 dB020_UPDATE_FONTES_DB_UPDATE_1_Update1)
        {
            var ths = dB020_UPDATE_FONTES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB020_UPDATE_FONTES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}