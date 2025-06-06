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
    public class SI0109B_V1RAMO : QueryBasis<SI0109B_V1RAMO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0109B_V1RAMO() { IsCursor = true; }

        public SI0109B_V1RAMO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string TGERAMO_NOMERAMO { get; set; }

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


        public override SI0109B_V1RAMO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0109B_V1RAMO();
            var i = 0;

            dta.TGERAMO_NOMERAMO = result[i++].Value?.ToString();

            return dta;
        }

    }
}