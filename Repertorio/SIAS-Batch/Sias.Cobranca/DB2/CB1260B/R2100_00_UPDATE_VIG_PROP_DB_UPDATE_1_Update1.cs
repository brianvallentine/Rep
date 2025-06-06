using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1 : QueryBasis<R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CB_APOLICE_VIGPROP
				SET NUM_ENDOSSO =  '{this.CBAPOVIG_NUM_ENDOSSO}'
				,NUM_PARCELA =  '{this.CBAPOVIG_NUM_PARCELA}'
				,DATA_MOVIMENTO =  '{this.CBAPOVIG_DATA_MOVIMENTO}'
				,DATA_VENCIMENTO =  '{this.CBAPOVIG_DATA_VENCIMENTO}'
				,PREMIO_TOTAL_PAGO =  '{this.CBAPOVIG_PREMIO_TOTAL_PAGO}'
				,PREMIO_TOTAL_DEV =  '{this.CBAPOVIG_PREMIO_TOTAL_DEV}'
				,QTD_DIAS_COBERTOS =  '{this.CBAPOVIG_QTD_DIAS_COBERTOS}'
				,DATA_FIM_VIG_PROP =  '{this.CBAPOVIG_DATA_FIM_VIG_PROP}'
				,DATA_CANCELAMENTO =  '{this.CBAPOVIG_DATA_CANCELAMENTO}'
				,IDTAB_SITUACAO =  '{this.CBAPOVIG_IDTAB_SITUACAO}'
				,SITUACAO =  '{this.CBAPOVIG_SITUACAO}'
				,DATA_MALA_VIG_PROP =  {FieldThreatment((this.VIND_DATA_MALA_VIG?.ToInt() == -1 ? null : $"{this.CBAPOVIG_DATA_MALA_VIG_PROP}"))}
				,DATA_MALA_CANCEL =  {FieldThreatment((this.VIND_DATA_MALA_CANCEL?.ToInt() == -1 ? null : $"{this.CBAPOVIG_DATA_MALA_CANCEL}"))}
				,TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.CBAPOVIG_NUM_APOLICE}'";

            return query;
        }
        public string CBAPOVIG_DATA_MALA_CANCEL { get; set; }
        public string VIND_DATA_MALA_CANCEL { get; set; }
        public string CBAPOVIG_DATA_MALA_VIG_PROP { get; set; }
        public string VIND_DATA_MALA_VIG { get; set; }
        public string CBAPOVIG_PREMIO_TOTAL_PAGO { get; set; }
        public string CBAPOVIG_QTD_DIAS_COBERTOS { get; set; }
        public string CBAPOVIG_DATA_FIM_VIG_PROP { get; set; }
        public string CBAPOVIG_DATA_CANCELAMENTO { get; set; }
        public string CBAPOVIG_PREMIO_TOTAL_DEV { get; set; }
        public string CBAPOVIG_DATA_VENCIMENTO { get; set; }
        public string CBAPOVIG_DATA_MOVIMENTO { get; set; }
        public string CBAPOVIG_IDTAB_SITUACAO { get; set; }
        public string CBAPOVIG_NUM_ENDOSSO { get; set; }
        public string CBAPOVIG_NUM_PARCELA { get; set; }
        public string CBAPOVIG_SITUACAO { get; set; }
        public string CBAPOVIG_NUM_APOLICE { get; set; }

        public static void Execute(R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1 r2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1)
        {
            var ths = r2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}