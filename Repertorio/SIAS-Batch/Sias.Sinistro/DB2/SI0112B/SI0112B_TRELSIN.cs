using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0112B
{
    public class SI0112B_TRELSIN : QueryBasis<SI0112B_TRELSIN>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0112B_TRELSIN() { IsCursor = true; }

        public SI0112B_TRELSIN(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1RELA_NUMSINI { get; set; }
        public string V1RELA_CONGE { get; set; }
        public string V1RELA_OPERACAO { get; set; }
        public string V1RELA_OCORHIST { get; set; }
        public string V1RELA_DTMOVTO { get; set; }

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


        public override SI0112B_TRELSIN OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0112B_TRELSIN();
            var i = 0;

            dta.V1RELA_NUMSINI = result[i++].Value?.ToString();
            dta.V1RELA_CONGE = result[i++].Value?.ToString();
            dta.V1RELA_OPERACAO = result[i++].Value?.ToString();
            dta.V1RELA_OCORHIST = result[i++].Value?.ToString();
            dta.V1RELA_DTMOVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}