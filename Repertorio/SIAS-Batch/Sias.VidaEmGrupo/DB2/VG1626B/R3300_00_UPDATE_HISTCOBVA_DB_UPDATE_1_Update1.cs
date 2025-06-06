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
    public class R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 : QueryBasis<R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COBER_HIST_VIDAZUL
				SET PRM_TOTAL =  '{this.WHOST_PRMVG}',
				SIT_REGISTRO = '5'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.PROPOVA_NUM_PARCELA}'";

            return query;
        }
        public string WHOST_PRMVG { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }

        public static void Execute(R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 r3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1)
        {
            var ths = r3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}