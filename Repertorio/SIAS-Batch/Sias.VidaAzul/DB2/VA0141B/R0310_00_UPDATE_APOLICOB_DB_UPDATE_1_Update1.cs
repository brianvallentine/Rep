using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 : QueryBasis<R0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.APOLICE_COBERTURAS
				SET DATA_INIVIGENCIA =  '{this.ENDOSSOS_DATA_INIVIGENCIA}'
				WHERE  NUM_APOLICE =  '{this.ENDOSSOS_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.ENDOSSOS_NUM_ENDOSSO}'";

            return query;
        }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static void Execute(R0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 r0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1)
        {
            var ths = r0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}