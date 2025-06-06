using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1 : QueryBasis<R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_LANC_CTA
				SET SIT_REGISTRO = '2' ,
				TIMESTAMP = CURRENT_TIMESTAMP,
				COD_USUARIO = 'VA0469B' ,
				CODRET = 2
				WHERE  NUM_CERTIFICADO =  '{this.RELATORI_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.RELATORI_NUM_PARCELA}'
				AND TIPLANC = '2'
				AND SIT_REGISTRO = ' '
				AND CODCONV =  '{this.WS_COD_CONVENIO}'";

            return query;
        }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string WS_COD_CONVENIO { get; set; }

        public static void Execute(R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1 r2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1)
        {
            var ths = r2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}