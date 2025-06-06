using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 : QueryBasis<R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.MOVTO_DEBITOCC_CEF
				SET SITUACAO_COBRANCA = ' '
				,VALOR_DEBITO =  '{this.PARCELAS_PRM_TOTAL_IX}'
				,COD_CONVENIO =  '{this.MOVDEBCE_COD_CONVENIO}'
				WHERE  NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'
				AND SITUACAO_COBRANCA = '6'
				AND COD_CONVENIO = 76114";

            return query;
        }
        public string PARCELAS_PRM_TOTAL_IX { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static void Execute(R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 r1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1)
        {
            var ths = r1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}