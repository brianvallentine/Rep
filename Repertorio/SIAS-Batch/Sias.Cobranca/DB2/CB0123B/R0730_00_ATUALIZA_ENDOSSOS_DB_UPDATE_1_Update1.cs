using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0123B
{
    public class R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1 : QueryBasis<R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ENDOSSOS
				SET SIT_REGISTRO = '1'
				WHERE  NUM_APOLICE =  '{this.HISCONPA_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.HISCONPA_NUM_ENDOSSO}'";

            return query;
        }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }

        public static void Execute(R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1 r0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1)
        {
            var ths = r0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}