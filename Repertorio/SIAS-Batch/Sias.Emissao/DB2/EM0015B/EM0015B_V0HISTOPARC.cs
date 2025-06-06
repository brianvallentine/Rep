using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class EM0015B_V0HISTOPARC : QueryBasis<EM0015B_V0HISTOPARC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0015B_V0HISTOPARC() { IsCursor = true; }

        public EM0015B_V0HISTOPARC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HISTO_NRPARCEL { get; set; }
        public string V0HISTO_DTMOVTO { get; set; }
        public string V0HISTO_VLPRMTOT { get; set; }
        public string V0HISTO_DTVENCTO { get; set; }

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


        public override EM0015B_V0HISTOPARC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0015B_V0HISTOPARC();
            var i = 0;

            dta.V0HISTO_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HISTO_DTMOVTO = result[i++].Value?.ToString();
            dta.V0HISTO_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0HISTO_DTVENCTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}