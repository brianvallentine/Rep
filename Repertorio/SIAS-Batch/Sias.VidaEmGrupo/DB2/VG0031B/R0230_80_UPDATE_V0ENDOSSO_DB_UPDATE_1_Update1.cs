using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 : QueryBasis<R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0ENDOSSO
				SET SITUACAO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.V0HISP_NUM_APOL}'
				AND NRENDOS =  '{this.V0HISP_NRENDOS}'";

            return query;
        }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }

        public static void Execute(R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 r0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1)
        {
            var ths = r0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}