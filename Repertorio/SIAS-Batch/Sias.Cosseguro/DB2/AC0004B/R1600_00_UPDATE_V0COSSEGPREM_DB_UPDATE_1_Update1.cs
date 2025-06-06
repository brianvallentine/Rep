using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0004B
{
    public class R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1 : QueryBasis<R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COSSEG_PREM
				SET SIT_CONGENERE = '0' ,
				OCORHIST =  '{this.V0CHSP_OCORHIST}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CONGENER =  '{this.V1CHSP_CONGENER}'
				AND NUM_APOLICE =  '{this.V1CHSP_NUM_APOL}'
				AND NRENDOS =  '{this.V1CHSP_NRENDOS}'
				AND NRPARCEL =  '{this.V1CHSP_NRPARCEL}'
				AND TIPSGU =  '{this.V1CHSP_TIPSGU}'";

            return query;
        }
        public string V0CHSP_OCORHIST { get; set; }
        public string V1CHSP_CONGENER { get; set; }
        public string V1CHSP_NUM_APOL { get; set; }
        public string V1CHSP_NRPARCEL { get; set; }
        public string V1CHSP_NRENDOS { get; set; }
        public string V1CHSP_TIPSGU { get; set; }

        public static void Execute(R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1 r1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1)
        {
            var ths = r1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}