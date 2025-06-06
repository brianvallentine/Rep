using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6253B
{
    public class R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 : QueryBasis<R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ENDOSSOS
				SET SIT_REGISTRO =  '{this.ENDOSSOS_SIT_REGISTRO}'
				WHERE  NUM_APOLICE =  '{this.PARCELAS_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.PARCELAS_NUM_ENDOSSO}'";

            return query;
        }
        public string ENDOSSOS_SIT_REGISTRO { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }

        public static void Execute(R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 r1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1)
        {
            var ths = r1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}