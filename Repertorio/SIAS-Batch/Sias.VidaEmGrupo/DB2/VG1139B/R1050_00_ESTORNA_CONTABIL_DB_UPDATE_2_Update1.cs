using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1139B
{
    public class R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1 : QueryBasis<R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0NUMERO_AES
				SET ENDOSCOB =  '{this.V0ENDO_NRENDOS}'
				WHERE  COD_ORGAO =  '{this.V0APOL_ORGAO}'
				AND COD_RAMO =  '{this.V0APOL_RAMO}'";

            return query;
        }
        public string V0ENDO_NRENDOS { get; set; }
        public string V0APOL_ORGAO { get; set; }
        public string V0APOL_RAMO { get; set; }

        public static void Execute(R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1 r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1)
        {
            var ths = r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}