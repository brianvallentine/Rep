using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 : QueryBasis<R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RCAP_COMPLEMENTAR
				SET SIT_REGISTRO = '1'
				WHERE  NUM_RCAP =  '{this.RCAPCOMP_NUM_RCAP}'";

            return query;
        }
        public string RCAPCOMP_NUM_RCAP { get; set; }

        public static void Execute(R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 r1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1)
        {
            var ths = r1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}