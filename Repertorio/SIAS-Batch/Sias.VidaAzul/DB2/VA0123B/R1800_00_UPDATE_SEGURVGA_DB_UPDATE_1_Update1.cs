using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 : QueryBasis<R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SEGURADOS_VGAP
				SET OCORR_HISTORICO =  '{this.SEGURVGA_OCORR_HISTORICO1}',
				COD_SUBGRUPO =  '{this.SUBGVGAP_COD_SUBGRUPO}',
				PERI_PAGAMENTO =  '{this.PRODUVG_PERI_PAGAMENTO}',
				FAIXA =  '{this.PLAVAVGA_FAIXA}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string SEGURVGA_OCORR_HISTORICO1 { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string PLAVAVGA_FAIXA { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 r1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1)
        {
            var ths = r1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}