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
    public class EM0015B_V0APOLINDICA : QueryBasis<EM0015B_V0APOLINDICA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0015B_V0APOLINDICA() { IsCursor = true; }

        public EM0015B_V0APOLINDICA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0APOIN_FONTE { get; set; }
        public string V0APOIN_NRPROPOS { get; set; }
        public string V0APOIN_DTINIVIG { get; set; }
        public string V0APOIN_DTTERVIG { get; set; }
        public string V0APOIN_TIPOFUNC { get; set; }

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


        public override EM0015B_V0APOLINDICA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0015B_V0APOLINDICA();
            var i = 0;

            dta.V0APOIN_FONTE = result[i++].Value?.ToString();
            dta.V0APOIN_NRPROPOS = result[i++].Value?.ToString();
            dta.V0APOIN_DTINIVIG = result[i++].Value?.ToString();
            dta.V0APOIN_DTTERVIG = result[i++].Value?.ToString();
            dta.V0APOIN_TIPOFUNC = result[i++].Value?.ToString();

            return dta;
        }

    }
}