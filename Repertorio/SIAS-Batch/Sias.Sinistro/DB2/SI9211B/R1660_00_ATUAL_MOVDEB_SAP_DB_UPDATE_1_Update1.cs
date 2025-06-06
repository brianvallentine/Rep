using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1 : QueryBasis<R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_MOVDEBCE_SAP
				SET NUM_ENDOSSO =  '{this.SINISHIS_COD_OPERACAO}'
				WHERE  NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'";

            return query;
        }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static void Execute(R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1 r1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1)
        {
            var ths = r1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}