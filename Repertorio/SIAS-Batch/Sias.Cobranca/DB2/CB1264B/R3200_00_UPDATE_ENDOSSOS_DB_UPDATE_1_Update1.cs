using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1264B
{
    public class R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 : QueryBasis<R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.ENDOSSOS
				SET
				SIT_REGISTRO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE 
				NUM_APOLICE =  '{this.ENDOSSOS_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.ENDOSSOS_NUM_ENDOSSO}'";

            return query;
        }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static void Execute(R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 r3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1)
        {
            var ths = r3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}