using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0109B
{
    public class SI0109B_V1SINICAUSA : QueryBasis<SI0109B_V1SINICAUSA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0109B_V1SINICAUSA() { IsCursor = true; }

        public SI0109B_V1SINICAUSA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINICAU_RAMO { get; set; }
        public string SINICAU_CODCAU { get; set; }
        public string SINICAU_DESCAU { get; set; }

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


        public override SI0109B_V1SINICAUSA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0109B_V1SINICAUSA();
            var i = 0;

            dta.SINICAU_RAMO = result[i++].Value?.ToString();
            dta.SINICAU_CODCAU = result[i++].Value?.ToString();
            dta.SINICAU_DESCAU = result[i++].Value?.ToString();

            return dta;
        }

    }
}