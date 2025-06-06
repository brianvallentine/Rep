using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0070B
{
    public class R1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.BILHETE
				SET VAL_RCAP =  '{this.PARCELAS_PRM_TOTAL_IX}'
				WHERE  NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'";

            return query;
        }
        public string PARCELAS_PRM_TOTAL_IX { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }

        public static void Execute(R1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 r1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}