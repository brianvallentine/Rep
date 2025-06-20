using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R6000_10_CANCEL_DB_UPDATE_1_Update1 : QueryBasis<R6000_10_CANCEL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO = '4' ,
				COD_USUARIO = 'VA0853B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.V0HISC_NRCERTIF}'";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }

        public static void Execute(R6000_10_CANCEL_DB_UPDATE_1_Update1 r6000_10_CANCEL_DB_UPDATE_1_Update1)
        {
            var ths = r6000_10_CANCEL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6000_10_CANCEL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}