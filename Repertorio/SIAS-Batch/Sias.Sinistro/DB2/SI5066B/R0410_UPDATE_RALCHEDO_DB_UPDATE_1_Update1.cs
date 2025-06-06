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
    public class R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1 : QueryBasis<R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RALACAO_CHEQ_DOCTO
				SET NUM_CHEQUE_INTERNO =  '{this.RALCHEDO_NUM_CHEQUE_INTERNO}',
				DIG_CHEQUE_INTERNO =  '{this.RALCHEDO_DIG_CHEQUE_INTERNO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUMDOC_NUM01 =  '{this.RALCHEDO_NUMDOC_NUM01}'
				AND OCORR_HISTORICO =  '{this.RALCHEDO_OCORR_HISTORICO}'";

            return query;
        }
        public string RALCHEDO_NUM_CHEQUE_INTERNO { get; set; }
        public string RALCHEDO_DIG_CHEQUE_INTERNO { get; set; }
        public string RALCHEDO_OCORR_HISTORICO { get; set; }
        public string RALCHEDO_NUMDOC_NUM01 { get; set; }

        public static void Execute(R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1 r0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1)
        {
            var ths = r0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}