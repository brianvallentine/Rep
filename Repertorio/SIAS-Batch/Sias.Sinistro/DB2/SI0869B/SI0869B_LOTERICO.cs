using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0869B
{
    public class SI0869B_LOTERICO : QueryBasis<SI0869B_LOTERICO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0869B_LOTERICO() { IsCursor = true; }

        public SI0869B_LOTERICO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string LOTERI01_DDD { get; set; }
        public string LOTERI01_NUM_FONE { get; set; }
        public string LOTERI01_DTTERVIG { get; set; }

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


        public override SI0869B_LOTERICO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0869B_LOTERICO();
            var i = 0;

            dta.LOTERI01_DDD = result[i++].Value?.ToString();
            dta.LOTERI01_NUM_FONE = result[i++].Value?.ToString();
            dta.LOTERI01_DTTERVIG = result[i++].Value?.ToString();

            return dta;
        }

    }
}