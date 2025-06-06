using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0869B
{
    public class SI0869B_RETENCOES : QueryBasis<SI0869B_RETENCOES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0869B_RETENCOES() { IsCursor = true; }

        public SI0869B_RETENCOES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINLOAB2_VALOR_RETENCAO { get; set; }
        public string SINLOAB2_VLR_RETENCAO_CALC { get; set; }
        public string SINLOAB2_IND_VLR_RETENCAO { get; set; }
        public string SINLOAB2_PERCENT_RETENCAO { get; set; }
        public string SINLOAB2_COD_RETENCAO { get; set; }
        public string SINLOAB2_QTD_SINISTRO_PAGO { get; set; }

        public new void Open()
        {
            if (!IsProcedure)
                SetQuery(GetQueryEvent());
            base.Open();
        }


        public new bool Fetch()
        {
            if (!JustACursor)
            {
                var idx = CurrentIndex;
                Open();
                CurrentIndex = idx > -1 ? idx : 0;
            }

            return base.Fetch();
        }


        public override SI0869B_RETENCOES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0869B_RETENCOES();
            var i = 0;

            dta.SINLOAB2_VALOR_RETENCAO = result[i++].Value?.ToString();
            dta.SINLOAB2_VLR_RETENCAO_CALC = result[i++].Value?.ToString();
            dta.SINLOAB2_IND_VLR_RETENCAO = result[i++].Value?.ToString();
            dta.SINLOAB2_PERCENT_RETENCAO = result[i++].Value?.ToString();
            dta.SINLOAB2_COD_RETENCAO = result[i++].Value?.ToString();
            dta.SINLOAB2_QTD_SINISTRO_PAGO = result[i++].Value?.ToString();

            return dta;
        }

    }
}