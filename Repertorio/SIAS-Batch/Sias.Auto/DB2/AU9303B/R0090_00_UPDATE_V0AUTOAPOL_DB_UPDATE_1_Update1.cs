using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU9303B
{
    public class R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1 : QueryBasis<R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0AUTOAPOL
				SET SITUACAO =  '{this.V0AUTP_SITUACAO}'
				WHERE  NUM_APOLICE =  '{this.V1AUTA_NUM_APOLICE}'
				AND NRENDOS =  '{this.V1AUTA_NRENDOS}'
				AND FONTE =  '{this.V1AUTA_FONTE}'
				AND NRPROPOS =  '{this.V1AUTA_NRPROPOS}'
				AND NRITEM =  '{this.V1AUTA_NRITEM}'";

            return query;
        }
        public string V0AUTP_SITUACAO { get; set; }
        public string V1AUTA_NUM_APOLICE { get; set; }
        public string V1AUTA_NRPROPOS { get; set; }
        public string V1AUTA_NRENDOS { get; set; }
        public string V1AUTA_NRITEM { get; set; }
        public string V1AUTA_FONTE { get; set; }

        public static void Execute(R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1 r0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1)
        {
            var ths = r0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}