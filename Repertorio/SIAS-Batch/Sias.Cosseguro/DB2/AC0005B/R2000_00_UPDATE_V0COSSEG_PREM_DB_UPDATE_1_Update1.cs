using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0005B
{
    public class R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 : QueryBasis<R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0COSSEG_PREM
				SET SITUACAO =  '{this.WHOST_SITUACAO}',
				SIT_CONGENERE =  '{this.WHOST_SITCONG}',
				TIMESTAMP = CURRENT TIMESTAMP,
				OCORHIST =  '{this.WHOST_OCORHIST}'
				WHERE  CONGENER =  '{this.V0COSC_CODLIDER}'
				AND NUM_APOLICE =  '{this.V0ENDO_NUM_APOL}'
				AND NRENDOS =  '{this.V0ENDO_NRENDOS}'
				AND NRPARCEL =  '{this.V0PARC_NRPARCEL}'
				AND TIPSGU = '0'
				AND NUM_ORDEM =  '{this.V0COSC_ORDLIDER}'";

            return query;
        }
        public string WHOST_SITUACAO { get; set; }
        public string WHOST_OCORHIST { get; set; }
        public string WHOST_SITCONG { get; set; }
        public string V0COSC_CODLIDER { get; set; }
        public string V0ENDO_NUM_APOL { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0COSC_ORDLIDER { get; set; }
        public string V0ENDO_NRENDOS { get; set; }

        public static void Execute(R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 r2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1)
        {
            var ths = r2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}