using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0073B
{
    public class R0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.BILHETE
				SET DATA_QUITACAO =  '{this.MOVIMCOB_DATA_QUITACAO}',
				SITUACAO = '5'
				WHERE  NUM_BILHETE =  '{this.PROPOFID_NUM_SICOB}'";

            return query;
        }
        public string MOVIMCOB_DATA_QUITACAO { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }

        public static void Execute(R0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 r0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}