using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0145B
{
    public class R2710_00_NUM_TITULO_DB_UPDATE_1_Update1 : QueryBasis<R2710_00_NUM_TITULO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.BANCOS
				SET NUM_TITULO =  '{this.BANCOS_NUM_TITULO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_BANCO = 104";

            return query;
        }
        public string BANCOS_NUM_TITULO { get; set; }

        public static void Execute(R2710_00_NUM_TITULO_DB_UPDATE_1_Update1 r2710_00_NUM_TITULO_DB_UPDATE_1_Update1)
        {
            var ths = r2710_00_NUM_TITULO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2710_00_NUM_TITULO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}