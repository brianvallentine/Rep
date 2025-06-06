using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 : QueryBasis<R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0APOLICE
				SET PCTCED =  '{this.W0APOL_PCTCED}' ,
				QTCOSSEG =  '{this.W0APOL_QTCOSSEG}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.V0APOL_NUM_APOL}'";

            return query;
        }
        public string W0APOL_QTCOSSEG { get; set; }
        public string W0APOL_PCTCED { get; set; }
        public string V0APOL_NUM_APOL { get; set; }

        public static void Execute(R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 r4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1)
        {
            var ths = r4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}