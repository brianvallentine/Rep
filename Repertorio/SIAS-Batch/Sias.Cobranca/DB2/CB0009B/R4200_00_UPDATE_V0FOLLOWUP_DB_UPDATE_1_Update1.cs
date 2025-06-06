using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1 : QueryBasis<R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FOLLOWUP
				SET SITUACAO = '2' ,
				OPERACAO = 403 ,
				DTLIBER =  '{this.V0SIST_DTMOVABE}'
				WHERE  NUM_APOLICE =  '{this.V0FOLL_NUMAPOL}'";

            return query;
        }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0FOLL_NUMAPOL { get; set; }

        public static void Execute(R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1 r4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1)
        {
            var ths = r4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}