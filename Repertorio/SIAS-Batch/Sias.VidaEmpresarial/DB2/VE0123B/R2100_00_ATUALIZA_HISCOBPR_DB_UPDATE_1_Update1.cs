using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1 : QueryBasis<R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIS_COBER_PROPOST
				SET DATA_TERVIGENCIA =  '{this.HISCOBPR_DATA_TERVIGENCIA}'
				,TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND OCORR_HISTORICO =  '{this.HISCOBPR_OCORR_HISTORICO}'";

            return query;
        }
        public string HISCOBPR_DATA_TERVIGENCIA { get; set; }
        public string HISCOBPR_OCORR_HISTORICO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1 r2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1)
        {
            var ths = r2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}