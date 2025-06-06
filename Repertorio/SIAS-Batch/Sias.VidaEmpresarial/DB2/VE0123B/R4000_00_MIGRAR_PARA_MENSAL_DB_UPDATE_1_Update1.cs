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
    public class R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1 : QueryBasis<R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SUBGRUPOS_VGAP
				SET PERI_FATURAMENTO =  '{this.SUBGVGAP_PERI_FATURAMENTO}'
				,DATA_INIVIGENCIA =  '{this.SUBGVGAP_DATA_INIVIGENCIA}'
				,DATA_TERVIGENCIA =  '{this.SUBGVGAP_DATA_TERVIGENCIA}'
				WHERE  NUM_APOLICE =  '{this.PROPOVA_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.PROPOVA_COD_SUBGRUPO}'";

            return query;
        }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string SUBGVGAP_DATA_INIVIGENCIA { get; set; }
        public string SUBGVGAP_DATA_TERVIGENCIA { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static void Execute(R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1 r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1)
        {
            var ths = r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}