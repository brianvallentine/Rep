using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 : QueryBasis<R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.ENDOSSOS
				SET SIT_REGISTRO = '2'
				WHERE  NUM_APOLICE =  '{this.PARCEHIS_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.PARCEHIS_NUM_ENDOSSO}'";

            return query;
        }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }

        public static void Execute(R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 r1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1)
        {
            var ths = r1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}