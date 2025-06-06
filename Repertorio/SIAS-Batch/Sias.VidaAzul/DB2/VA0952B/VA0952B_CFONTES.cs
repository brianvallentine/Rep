using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0952B
{
    public class VA0952B_CFONTES : QueryBasis<VA0952B_CFONTES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0952B_CFONTES() { IsCursor = true; }

        public VA0952B_CFONTES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0FONT_CODFTE { get; set; }
        public string V0FONT_NOMEFTE { get; set; }

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


        public override VA0952B_CFONTES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0952B_CFONTES();
            var i = 0;

            dta.V0FONT_CODFTE = result[i++].Value?.ToString();
            dta.V0FONT_NOMEFTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}