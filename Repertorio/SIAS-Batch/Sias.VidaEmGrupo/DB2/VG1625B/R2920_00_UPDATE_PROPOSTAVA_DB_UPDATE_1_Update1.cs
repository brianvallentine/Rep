using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1625B
{
    public class R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 : QueryBasis<R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET OCORR_HISTORICO =  '{this.HISCOBPR_OCORR_HISTORICO}',
				NUM_PARCELA =  '{this.PROPOVA_NUM_PARCELA}'
				+ 1
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string HISCOBPR_OCORR_HISTORICO { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 r2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1)
        {
            var ths = r2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}