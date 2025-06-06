using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0890B
{
    public class SI0890B_CR_ADIANT : QueryBasis<SI0890B_CR_ADIANT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0890B_CR_ADIANT() { IsCursor = true; }

        public SI0890B_CR_ADIANT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HOST_DATA_ADIANTAMENTO { get; set; }
        public string HOST_VALOR_ADIANTAMENTO { get; set; }

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


        public override SI0890B_CR_ADIANT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0890B_CR_ADIANT();
            var i = 0;

            dta.HOST_DATA_ADIANTAMENTO = result[i++].Value?.ToString();
            dta.HOST_VALOR_ADIANTAMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}