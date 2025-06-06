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
    public class R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 : QueryBasis<R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0NUMERO_AES
				SET NRENDOCA =  '{this.V0NAES_NRENDOCA}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_ORGAO =  '{this.V1ENDO_ORGAO}'
				AND COD_RAMO =  '{this.V1ENDO_RAMO}'";

            return query;
        }
        public string V0NAES_NRENDOCA { get; set; }
        public string V1ENDO_ORGAO { get; set; }
        public string V1ENDO_RAMO { get; set; }

        public static void Execute(R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 r0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1)
        {
            var ths = r0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}