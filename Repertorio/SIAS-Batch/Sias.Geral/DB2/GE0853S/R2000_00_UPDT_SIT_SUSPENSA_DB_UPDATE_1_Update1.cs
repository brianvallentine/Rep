using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1 : QueryBasis<R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET SITUACAO = '6' ,
				NRPRIPARATZ =  '{this.V0HISC_NRPARCEL}',
				QTDPARATZ = 1,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0HISC_NRCERTIF}'";

            return query;
        }
        public string V0HISC_NRPARCEL { get; set; }
        public string V0HISC_NRCERTIF { get; set; }

        public static void Execute(R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1 r2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1)
        {
            var ths = r2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}