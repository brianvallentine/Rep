using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R4070_2610_UPDT_SUBGRUPO_VGAP_DB_UPDATE_1_Update1 : QueryBasis<R4070_2610_UPDT_SUBGRUPO_VGAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SUBGRUPOS_VGAP
				SET SIT_REGISTRO =  '{this.SUBGVGAP_SIT_REGISTRO}'
				WHERE  NUM_APOLICE =  '{this.VGSOLFAT_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.VGSOLFAT_COD_SUBGRUPO}'";

            return query;
        }
        public string SUBGVGAP_SIT_REGISTRO { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static void Execute(R4070_2610_UPDT_SUBGRUPO_VGAP_DB_UPDATE_1_Update1 r4070_2610_UPDT_SUBGRUPO_VGAP_DB_UPDATE_1_Update1)
        {
            var ths = r4070_2610_UPDT_SUBGRUPO_VGAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4070_2610_UPDT_SUBGRUPO_VGAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}