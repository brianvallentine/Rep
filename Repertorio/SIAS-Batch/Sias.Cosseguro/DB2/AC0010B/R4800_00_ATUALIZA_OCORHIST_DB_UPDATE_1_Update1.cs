using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1 : QueryBasis<R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COSSEG_PREM
				SET OCORHIST =  '{this.V2CHIS_OCORHIST}'
				WHERE  CONGENER =  '{this.V2CHIS_CONGENER}'
				AND NUM_APOLICE =  '{this.V2CHIS_NUM_APOL}'
				AND NRENDOS =  '{this.V2CHIS_NRENDOS}'
				AND NRPARCEL =  '{this.V2CHIS_NRPARCEL}'
				AND TIPSGU = '1'";

            return query;
        }
        public string V2CHIS_OCORHIST { get; set; }
        public string V2CHIS_CONGENER { get; set; }
        public string V2CHIS_NUM_APOL { get; set; }
        public string V2CHIS_NRPARCEL { get; set; }
        public string V2CHIS_NRENDOS { get; set; }

        public static void Execute(R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1 r4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1)
        {
            var ths = r4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}