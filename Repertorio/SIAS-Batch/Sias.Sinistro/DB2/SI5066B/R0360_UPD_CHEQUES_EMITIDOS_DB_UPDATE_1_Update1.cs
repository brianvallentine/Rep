using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5066B
{
    public class R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1 : QueryBasis<R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CHEQUES_EMITIDOS
				SET VAL_CHEQUE =  '{this.CHEQUEMI_VAL_CHEQUE}'
				WHERE  NUM_CHEQUE_INTERNO =  '{this.CHEQUEMI_NUM_CHEQUE_INTERNO}'";

            return query;
        }
        public string CHEQUEMI_VAL_CHEQUE { get; set; }
        public string CHEQUEMI_NUM_CHEQUE_INTERNO { get; set; }

        public static void Execute(R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1 r0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1)
        {
            var ths = r0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}