using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1262B
{
    public class R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 : QueryBasis<R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.MOVTO_DEBITOCC_CEF
				SET
				SITUACAO_COBRANCA = ' ' ,
				DATA_MOVIMENTO =  '{this.SISTEMAS_DATA_MOV_ABERTO}',
				COD_USUARIO = 'CB1262B' ,
				DATA_RETORNO = NULL,
				COD_RETORNO_CEF = NULL
				WHERE 
				NUM_APOLICE =  '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVDEBCE_NUM_PARCELA}'
				AND COD_CONVENIO =  '{this.MOVDEBCE_COD_CONVENIO}'
				AND NSAS =  '{this.MOVDEBCE_NSAS}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_NSAS { get; set; }

        public static void Execute(R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 r2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1)
        {
            var ths = r2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}