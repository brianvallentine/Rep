using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0888B
{
    public class SI0888B_CR_APOLICRE : QueryBasis<SI0888B_CR_APOLICRE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0888B_CR_APOLICRE() { IsCursor = true; }

        public SI0888B_CR_APOLICRE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APOLICRE_PROPRIET { get; set; }
        public string APOLICRE_DATA_INIVIGENCIA { get; set; }

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


        public override SI0888B_CR_APOLICRE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0888B_CR_APOLICRE();
            var i = 0;

            dta.APOLICRE_PROPRIET = result[i++].Value?.ToString();
            dta.APOLICRE_DATA_INIVIGENCIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}