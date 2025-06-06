using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0077B
{
    public class R0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.BILHETE
				SET SITUACAO = '8' ,
				DATA_CANCELAMENTO = CURRENT DATE,
				COD_USUARIO = 'BI0077B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_BILHETE =  '{this.BILHETE_NUM_BILHETE}'
				AND SITUACAO <> '8'";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static void Execute(R0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1 r0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}