using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6248B
{
    public class R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1 : QueryBasis<R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.BILHETE
				SET NUM_MATRICULA =  '{this.BILHETE_NUM_MATRICULA}'
				WHERE  NUM_BILHETE =  '{this.BILHETE_NUM_BILHETE}'";

            return query;
        }
        public string BILHETE_NUM_MATRICULA { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static void Execute(R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1 r6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1)
        {
            var ths = r6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}