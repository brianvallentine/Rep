using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 : QueryBasis<R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0COSCED_CHEQUE
				SET VLRCOMIS =  '{this.V0CCHQ_COMISSAO}',
				OUTRDEBIT =  '{this.V0CCHQ_OUTRDEBIT}'
				WHERE  COD_EMPRESA =  '{this.V1RELA_COD_EMPR}'
				AND CONGENER =  '{this.V1RELA_CONGENER}'
				AND DTMOVTO_AC =  '{this.V1RELA_DATA_SOL}'";

            return query;
        }
        public string V0CCHQ_OUTRDEBIT { get; set; }
        public string V0CCHQ_COMISSAO { get; set; }
        public string V1RELA_COD_EMPR { get; set; }
        public string V1RELA_CONGENER { get; set; }
        public string V1RELA_DATA_SOL { get; set; }

        public static void Execute(R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 r3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1)
        {
            var ths = r3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}