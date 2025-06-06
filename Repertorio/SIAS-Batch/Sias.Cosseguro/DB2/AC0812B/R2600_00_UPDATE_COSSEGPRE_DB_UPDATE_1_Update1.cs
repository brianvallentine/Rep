using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1 : QueryBasis<R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0COSSEG_PREM
				SET SIT_CONGENERE = '1' ,
				OCORHIST =  '{this.V1CPRE_OCORHIST}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CONGENER =  '{this.V1CHIS_CONGENER}'
				AND NUM_APOLICE =  '{this.V1CHIS_NUM_APOL}'
				AND NRENDOS =  '{this.V1CHIS_NUM_ENDS}'
				AND NRPARCEL =  '{this.V1CHIS_NRPARCEL}'
				AND TIPSGU = '1'";

            return query;
        }
        public string V1CPRE_OCORHIST { get; set; }
        public string V1CHIS_CONGENER { get; set; }
        public string V1CHIS_NUM_APOL { get; set; }
        public string V1CHIS_NUM_ENDS { get; set; }
        public string V1CHIS_NRPARCEL { get; set; }

        public static void Execute(R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1 r2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1)
        {
            var ths = r2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}