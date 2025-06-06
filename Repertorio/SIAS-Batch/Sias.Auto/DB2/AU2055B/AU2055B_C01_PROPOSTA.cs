using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class AU2055B_C01_PROPOSTA : QueryBasis<AU2055B_C01_PROPOSTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AU2055B_C01_PROPOSTA() { IsCursor = true; }

        public AU2055B_C01_PROPOSTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOSTA_COD_FONTE { get; set; }
        public string PROPOSTA_NUM_PROPOSTA { get; set; }
        public string PROPOSTA_NUM_RCAP { get; set; }
        public string PROPCOBR_TIPO_COBRANCA { get; set; }
        public string AU085_IND_FORMA_PAGTO_AD { get; set; }
        public string PROPOSTA_DATA_INIVIGENCIA { get; set; }
        public string PROPOSTA_NUM_APOL_ANTERIOR { get; set; }

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


        public override AU2055B_C01_PROPOSTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AU2055B_C01_PROPOSTA();
            var i = 0;

            dta.PROPOSTA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOSTA_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOSTA_NUM_RCAP = result[i++].Value?.ToString();
            dta.PROPCOBR_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.AU085_IND_FORMA_PAGTO_AD = result[i++].Value?.ToString();
            dta.PROPOSTA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.PROPOSTA_NUM_APOL_ANTERIOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}