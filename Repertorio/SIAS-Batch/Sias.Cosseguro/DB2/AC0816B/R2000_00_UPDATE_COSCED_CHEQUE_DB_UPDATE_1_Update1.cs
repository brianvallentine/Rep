using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 : QueryBasis<R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COSCED_CHEQUE
				SET VLRSINI =  '{this.V0CCHQ_VLRSINI}',
				VLDESPESA =  '{this.V0CCHQ_VLDESPESA}',
				VLRHONOR =  '{this.V0CCHQ_VLRHONOR}',
				VLRSALVD =  '{this.V0CCHQ_VLRSALVD}',
				VLRESSARC =  '{this.V0CCHQ_VLRESSARC}',
				OUTRDEBIT =  '{this.V0CCHQ_OUTRDEBIT}',
				OUTRCREDT =  '{this.V0CCHQ_OUTRCREDT}'
				WHERE  COD_EMPRESA =  '{this.V0RELA_COD_EMPR}'
				AND CONGENER =  '{this.V0RELA_CONGENER}'
				AND DTMOVTO_AC =  '{this.V0RELA_DATA_SOL}'";

            return query;
        }
        public string V0CCHQ_VLDESPESA { get; set; }
        public string V0CCHQ_VLRESSARC { get; set; }
        public string V0CCHQ_OUTRDEBIT { get; set; }
        public string V0CCHQ_OUTRCREDT { get; set; }
        public string V0CCHQ_VLRHONOR { get; set; }
        public string V0CCHQ_VLRSALVD { get; set; }
        public string V0CCHQ_VLRSINI { get; set; }
        public string V0RELA_COD_EMPR { get; set; }
        public string V0RELA_CONGENER { get; set; }
        public string V0RELA_DATA_SOL { get; set; }

        public static void Execute(R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 r2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1)
        {
            var ths = r2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}