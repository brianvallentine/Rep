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
    public class DB122_ALTERA_SUBGRUPOSVGAP_DB_UPDATE_1_Update1 : QueryBasis<DB122_ALTERA_SUBGRUPOSVGAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SUBGRUPOS_VGAP
				SET COD_FONTE =  '{this.SUBGVGAP_COD_FONTE}'
				WHERE  NUM_APOLICE =  '{this.VGSOLFAT_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.VGSOLFAT_COD_SUBGRUPO}'
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static void Execute(DB122_ALTERA_SUBGRUPOSVGAP_DB_UPDATE_1_Update1 dB122_ALTERA_SUBGRUPOSVGAP_DB_UPDATE_1_Update1)
        {
            var ths = dB122_ALTERA_SUBGRUPOSVGAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB122_ALTERA_SUBGRUPOSVGAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}