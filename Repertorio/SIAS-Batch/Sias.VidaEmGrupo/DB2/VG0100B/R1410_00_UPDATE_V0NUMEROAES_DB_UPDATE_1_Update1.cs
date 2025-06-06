using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1 : QueryBasis<R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0NUMERO_AES
				SET ENDOSCOB =  '{this.V0NAES_ENDOSCOB}' ,
				ENDOSRES =  '{this.V0NAES_ENDOSRES}' ,
				ENDOSSEM =  '{this.V0NAES_ENDOSSEM}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_ORGAO =  '{this.V1APOL_ORGAO}'
				AND COD_RAMO =  '{this.V1APOL_RAMO}'";

            return query;
        }
        public string V0NAES_ENDOSCOB { get; set; }
        public string V0NAES_ENDOSRES { get; set; }
        public string V0NAES_ENDOSSEM { get; set; }
        public string V1APOL_ORGAO { get; set; }
        public string V1APOL_RAMO { get; set; }

        public static void Execute(R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1 r1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1)
        {
            var ths = r1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}