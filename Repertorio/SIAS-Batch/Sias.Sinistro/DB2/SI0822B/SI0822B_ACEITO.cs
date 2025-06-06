using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0822B
{
    public class SI0822B_ACEITO : QueryBasis<SI0822B_ACEITO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0822B_ACEITO() { IsCursor = true; }

        public SI0822B_ACEITO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0MEST_CODLIDER { get; set; }
        public string V0HISTSINI_AA_DTMOVTO { get; set; }
        public string V0HISTSINI_MM_DTMOVTO { get; set; }
        public string V0MEST_RAMO { get; set; }
        public string V0HISTSINI_OPERACAO { get; set; }
        public string V0HISTSINI_VAL_OPERACAO { get; set; }

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


        public override SI0822B_ACEITO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0822B_ACEITO();
            var i = 0;

            dta.V0MEST_CODLIDER = result[i++].Value?.ToString();
            dta.V0HISTSINI_AA_DTMOVTO = result[i++].Value?.ToString();
            dta.V0HISTSINI_MM_DTMOVTO = result[i++].Value?.ToString();
            dta.V0MEST_RAMO = result[i++].Value?.ToString();
            dta.V0HISTSINI_OPERACAO = result[i++].Value?.ToString();
            dta.V0HISTSINI_VAL_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}