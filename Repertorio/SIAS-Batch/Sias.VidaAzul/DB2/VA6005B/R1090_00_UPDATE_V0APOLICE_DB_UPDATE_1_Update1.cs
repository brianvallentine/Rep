using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 : QueryBasis<R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0APOLICE
				SET QTCOSSEG =  '{this.V0APOL_QTCOSSEG}' ,
				PCTCED =  '{this.V0APOL_PCTCED}'
				WHERE  NUM_APOLICE =  '{this.V0APOL_NUM_APOL}'";

            return query;
        }
        public string V0APOL_QTCOSSEG { get; set; }
        public string V0APOL_PCTCED { get; set; }
        public string V0APOL_NUM_APOL { get; set; }

        public static void Execute(R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 r1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1)
        {
            var ths = r1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}