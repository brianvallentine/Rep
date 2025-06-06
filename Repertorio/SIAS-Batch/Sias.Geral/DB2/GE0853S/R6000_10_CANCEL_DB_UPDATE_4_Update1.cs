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
    public class R6000_10_CANCEL_DB_UPDATE_4_Update1 : QueryBasis<R6000_10_CANCEL_DB_UPDATE_4_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO = '2'
				WHERE  NRCERTIF =  '{this.V0HISC_NRCERTIF}'
				AND TIPLANC = '1'
				AND SITUACAO IN ( ' ' , '0' , X'00' )";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }

        public static void Execute(R6000_10_CANCEL_DB_UPDATE_4_Update1 r6000_10_CANCEL_DB_UPDATE_4_Update1)
        {
            var ths = r6000_10_CANCEL_DB_UPDATE_4_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6000_10_CANCEL_DB_UPDATE_4_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}