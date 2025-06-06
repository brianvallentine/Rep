using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1 : QueryBasis<R0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.COBER_HIST_VIDAZUL
				SET NUM_TITULO =  '{this.HISCONPA_NUM_TITULO}'
				WHERE  NUM_CERTIFICADO =  '{this.HISCONPA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.HISCONPA_NUM_PARCELA}'";

            return query;
        }
        public string HISCONPA_NUM_TITULO { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static void Execute(R0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1 r0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1)
        {
            var ths = r0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}