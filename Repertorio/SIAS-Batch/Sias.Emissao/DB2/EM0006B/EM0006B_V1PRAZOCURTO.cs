using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class EM0006B_V1PRAZOCURTO : QueryBasis<EM0006B_V1PRAZOCURTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0006B_V1PRAZOCURTO() { IsCursor = true; }

        public EM0006B_V1PRAZOCURTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PRAC_PCTPRAZOVIG { get; set; }

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


        public override EM0006B_V1PRAZOCURTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0006B_V1PRAZOCURTO();
            var i = 0;

            dta.V1PRAC_PCTPRAZOVIG = result[i++].Value?.ToString();

            return dta;
        }

    }
}