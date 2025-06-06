using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5421B
{
    public class R100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1 : QueryBasis<R100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0SAFCOBER
				SET DTTERVIG = DTTERVIG - 1 DAY,
				CODUSU = 'VA5421B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CODCLIEN =  '{this.V0PROP_CODCLIEN}'";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }

        public static void Execute(R100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1 r100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1)
        {
            var ths = r100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}