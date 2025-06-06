using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0905S
{
    public class EM0905S_V1MOEDA : QueryBasis<EM0905S_V1MOEDA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0905S_V1MOEDA() { IsCursor = true; }

        public EM0905S_V1MOEDA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOED_VALOR { get; set; }
        public string MOED_TIPO_MOEDA { get; set; }

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


        public override EM0905S_V1MOEDA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0905S_V1MOEDA();
            var i = 0;

            dta.MOED_VALOR = result[i++].Value?.ToString();
            dta.MOED_TIPO_MOEDA = result[i++].Value?.ToString();

            return dta;
        }

    }
}