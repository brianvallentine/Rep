using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 : QueryBasis<R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0ENDOSSO
				SET SITUACAO = '1'
				WHERE  NUM_APOLICE =  '{this.V1HIST_NUM_APOL}'
				AND NRENDOS =  '{this.V1HIST_NRENDOS}'";

            return query;
        }
        public string V1HIST_NUM_APOL { get; set; }
        public string V1HIST_NRENDOS { get; set; }

        public static void Execute(R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 r1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1)
        {
            var ths = r1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}