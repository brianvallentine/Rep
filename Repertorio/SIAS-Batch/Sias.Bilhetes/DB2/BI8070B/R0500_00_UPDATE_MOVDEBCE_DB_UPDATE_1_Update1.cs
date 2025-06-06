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
    public class R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 : QueryBasis<R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.MOVTO_DEBITOCC_CEF
				SET SITUACAO_COBRANCA = 'A'
				WHERE  NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'
				AND SITUACAO_COBRANCA =  '{this.MOVDEBCE_SITUACAO_COBRANCA}'
				AND COD_CONVENIO =  '{this.MOVDEBCE_COD_CONVENIO}'";

            return query;
        }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static void Execute(R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 r0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1)
        {
            var ths = r0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}