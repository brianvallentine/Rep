using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0415B
{
    public class R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1 : QueryBasis<R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0SAFCOBER
				SET DTTERVIG =  '{this.V0HSEG_DTREFER}',
				CODUSU = 'VA0415B' ,
				SITUACA = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CODCLIEN =  '{this.V0PROP_CODCLIEN}'
				AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' )";

            return query;
        }
        public string V0HSEG_DTREFER { get; set; }
        public string V0PROP_CODCLIEN { get; set; }

        public static void Execute(R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1 r080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1)
        {
            var ths = r080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}