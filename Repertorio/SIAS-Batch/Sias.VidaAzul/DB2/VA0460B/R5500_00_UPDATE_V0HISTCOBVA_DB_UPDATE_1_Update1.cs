using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 : QueryBasis<R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COBER_HIST_VIDAZUL
				SET SIT_REGISTRO = '7'
				WHERE  NUM_CERTIFICADO =  '{this.COBHISVI_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.COBHISVI_NUM_PARCELA}'
				AND NUM_TITULO =  '{this.COBHISVI_NUM_TITULO}'
				AND SIT_REGISTRO = '4'";

            return query;
        }
        public string COBHISVI_NUM_CERTIFICADO { get; set; }
        public string COBHISVI_NUM_PARCELA { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }

        public static void Execute(R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 r5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1)
        {
            var ths = r5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}