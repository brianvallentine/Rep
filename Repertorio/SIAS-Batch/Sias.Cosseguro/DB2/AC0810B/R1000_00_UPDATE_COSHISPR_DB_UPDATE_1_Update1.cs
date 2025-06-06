using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0810B
{
    public class R1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1 : QueryBasis<R1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.COSSEGURO_HIST_PRE
				SET COD_EMPRESA =  '{this.PRODUTO_COD_EMPRESA}'
				WHERE  COD_CONGENERE =  '{this.COSHISPR_COD_CONGENERE}'
				AND NUM_APOLICE =  '{this.COSHISPR_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.COSHISPR_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.COSHISPR_NUM_PARCELA}'
				AND OCORR_HISTORICO =  '{this.COSHISPR_OCORR_HISTORICO}'
				AND COD_OPERACAO =  '{this.COSHISPR_COD_OPERACAO}'
				AND DATA_MOVIMENTO =  '{this.COSHISPR_DATA_MOVIMENTO}'
				AND TIPO_SEGURO =  '{this.COSHISPR_TIPO_SEGURO}'
				AND COD_EMPRESA =  '{this.COSHISPR_COD_EMPRESA}'";

            return query;
        }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string COSHISPR_OCORR_HISTORICO { get; set; }
        public string COSHISPR_DATA_MOVIMENTO { get; set; }
        public string COSHISPR_COD_CONGENERE { get; set; }
        public string COSHISPR_COD_OPERACAO { get; set; }
        public string COSHISPR_NUM_APOLICE { get; set; }
        public string COSHISPR_NUM_ENDOSSO { get; set; }
        public string COSHISPR_NUM_PARCELA { get; set; }
        public string COSHISPR_TIPO_SEGURO { get; set; }
        public string COSHISPR_COD_EMPRESA { get; set; }

        public static void Execute(R1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1 r1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1)
        {
            var ths = r1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}