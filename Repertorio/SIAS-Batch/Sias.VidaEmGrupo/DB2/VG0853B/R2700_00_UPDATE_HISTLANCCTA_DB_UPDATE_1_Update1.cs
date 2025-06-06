using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1 : QueryBasis<R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_LANC_CTA
				SET SIT_REGISTRO = '2'
				WHERE  NUM_CERTIFICADO =  '{this.HISLANCT_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.HISLANCT_NUM_PARCELA}'
				AND CODCONV = 6088
				AND TIPLANC = '1'
				AND SIT_REGISTRO = ' '
				AND CODRET <> 0";

            return query;
        }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }

        public static void Execute(R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1 r2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1)
        {
            var ths = r2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}