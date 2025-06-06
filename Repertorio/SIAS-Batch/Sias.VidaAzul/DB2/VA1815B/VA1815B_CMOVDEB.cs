using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1815B
{
    public class VA1815B_CMOVDEB : QueryBasis<VA1815B_CMOVDEB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA1815B_CMOVDEB() { IsCursor = true; }

        public VA1815B_CMOVDEB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVDEBCE_NSAS { get; set; }
        public string VIND_NSAS { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_COD_RETORNO_CEF { get; set; }
        public string VIND_COD_RETORNO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }

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


        public override VA1815B_CMOVDEB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA1815B_CMOVDEB();
            var i = 0;

            dta.MOVDEBCE_NSAS = result[i++].Value?.ToString();
            dta.VIND_NSAS = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NSAS) ? "-1" : "0";
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_RETORNO_CEF = result[i++].Value?.ToString();
            dta.VIND_COD_RETORNO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_COD_RETORNO_CEF) ? "-1" : "0";
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();

            return dta;
        }

    }
}