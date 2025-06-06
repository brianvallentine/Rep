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
    public class DB124_ALTERA_COMISSOES_DB_UPDATE_1_Update1 : QueryBasis<DB124_ALTERA_COMISSOES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COMISSOES
				SET COD_FONTE =  '{this.SUBGVGAP_COD_FONTE}'
				WHERE  NUM_APOLICE =  '{this.VGSOLFAT_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.VGSOLFAT_COD_SUBGRUPO}'
				AND NUM_ENDOSSO = 0
				AND NUM_PARCELA = 1";

            return query;
        }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static void Execute(DB124_ALTERA_COMISSOES_DB_UPDATE_1_Update1 dB124_ALTERA_COMISSOES_DB_UPDATE_1_Update1)
        {
            var ths = dB124_ALTERA_COMISSOES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB124_ALTERA_COMISSOES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}