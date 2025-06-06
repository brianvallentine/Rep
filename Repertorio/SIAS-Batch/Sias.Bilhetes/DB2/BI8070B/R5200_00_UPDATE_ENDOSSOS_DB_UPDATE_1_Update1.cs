using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R5200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 : QueryBasis<R5200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.ENDOSSOS
				SET DATA_TERVIGENCIA =  '{this.ENDOSSOS_DATA_TERVIGENCIA}'
				WHERE  NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO = 0";

            return query;
        }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }

        public static void Execute(R5200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 r5200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1)
        {
            var ths = r5200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}