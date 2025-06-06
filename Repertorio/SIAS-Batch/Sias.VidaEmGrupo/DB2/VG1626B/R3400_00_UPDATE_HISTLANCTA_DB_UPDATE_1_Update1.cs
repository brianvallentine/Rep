using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1 : QueryBasis<R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_LANC_CTA
				SET PRM_TOTAL =  '{this.WHOST_PRMVG}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.PROPOVA_OCORR_HISTORICO}'
				AND SIT_REGISTRO IN ( '0' , ' ' )";

            return query;
        }
        public string WHOST_PRMVG { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }

        public static void Execute(R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1 r3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1)
        {
            var ths = r3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}