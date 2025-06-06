using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0007B
{
    public class R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 : QueryBasis<R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0COSCED_CHEQUE
				SET SITUACAO = '1' ,
				NRCHEQUE =  '{this.V0CCHQ_NRCHEQUE}',
				DVCHEQUE =  '{this.V0CCHQ_DVCHEQUE}'
				WHERE  COD_EMPRESA =  '{this.V0CCHQ_COD_EMPR}'
				AND CONGENER =  '{this.V0CCHQ_CONGENER}'
				AND DTMOVTO_FI =  '{this.V1SIST_DTMOVABE_FI}'
				AND SITUACAO = '0'";

            return query;
        }
        public string V0CCHQ_NRCHEQUE { get; set; }
        public string V0CCHQ_DVCHEQUE { get; set; }
        public string V1SIST_DTMOVABE_FI { get; set; }
        public string V0CCHQ_COD_EMPR { get; set; }
        public string V0CCHQ_CONGENER { get; set; }

        public static void Execute(R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 r2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1)
        {
            var ths = r2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}