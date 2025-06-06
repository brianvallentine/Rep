using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0011B
{
    public class R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 : QueryBasis<R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COSSEG_PREM
				SET OCORHIST =  '{this.WSHOST_OCORHIST}' ,
				SITUACAO =  '{this.WSHOST_SITUACAO}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  TIPSGU = '1'
				AND CONGENER =  '{this.V1APCD_CODCOSS}'
				AND NUM_ORDEM =  '{this.V1ORDC_ORD_CEDIDO}'
				AND NUM_APOLICE =  '{this.V1HISP_NUM_APOL}'
				AND NRENDOS =  '{this.V1HISP_NRENDOS}'
				AND NRPARCEL =  '{this.V1HISP_NRPARCEL}'";

            return query;
        }
        public string WSHOST_OCORHIST { get; set; }
        public string WSHOST_SITUACAO { get; set; }
        public string V1ORDC_ORD_CEDIDO { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRPARCEL { get; set; }
        public string V1APCD_CODCOSS { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static void Execute(R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 r3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1)
        {
            var ths = r3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}