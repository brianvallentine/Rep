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
    public class CB1260B_C1AU071 : QueryBasis<CB1260B_C1AU071>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB1260B_C1AU071() { IsCursor = true; }

        public CB1260B_C1AU071(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string AU071_NUM_APOLICE { get; set; }
        public string AU071_NUM_ENDOSSO { get; set; }
        public string AU071_NUM_PARCELA { get; set; }
        public string AU071_DTA_VENCTO { get; set; }
        public string AU071_NUM_VENCTO { get; set; }

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


        public override CB1260B_C1AU071 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB1260B_C1AU071();
            var i = 0;

            dta.AU071_NUM_APOLICE = result[i++].Value?.ToString();
            dta.AU071_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.AU071_NUM_PARCELA = result[i++].Value?.ToString();
            dta.AU071_DTA_VENCTO = result[i++].Value?.ToString();
            dta.AU071_NUM_VENCTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}