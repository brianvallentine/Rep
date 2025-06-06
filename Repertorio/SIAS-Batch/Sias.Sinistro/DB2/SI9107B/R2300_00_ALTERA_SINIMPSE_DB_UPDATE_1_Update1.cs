using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9107B
{
    public class R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1 : QueryBasis<R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_IMP_SEG
				SET SIT_REGISTRO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOL_SINISTRO =  '{this.SIARDEVC_NUM_APOL_SINISTRO}'
				AND OCORR_HISTORICO =  '{this.SINIMPSE_OCORR_HISTORICO}'";

            return query;
        }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SINIMPSE_OCORR_HISTORICO { get; set; }

        public static void Execute(R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1 r2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1)
        {
            var ths = r2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}