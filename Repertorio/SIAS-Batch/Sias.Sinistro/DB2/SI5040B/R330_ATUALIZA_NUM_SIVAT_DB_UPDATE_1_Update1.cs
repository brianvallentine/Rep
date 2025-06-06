using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5040B
{
    public class R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1 : QueryBasis<R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_OUTROS
				SET NUM_SIVAT =  '{this.NUMEROUT_NUM_SIVAT}'
				WHERE  1 = 1";

            return query;
        }
        public string NUMEROUT_NUM_SIVAT { get; set; }

        public static void Execute(R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1 r330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1)
        {
            var ths = r330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}