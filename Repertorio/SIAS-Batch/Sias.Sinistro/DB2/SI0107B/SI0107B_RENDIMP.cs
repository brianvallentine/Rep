using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0107B
{
    public class SI0107B_RENDIMP : QueryBasis<SI0107B_RENDIMP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0107B_RENDIMP() { IsCursor = true; }

        public SI0107B_RENDIMP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RENDIMEN_CODPDT { get; set; }
        public string RENDIMEN_VALRDT { get; set; }
        public string IMPOST_VLIMPOST { get; set; }

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


        public override SI0107B_RENDIMP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0107B_RENDIMP();
            var i = 0;

            dta.RENDIMEN_CODPDT = result[i++].Value?.ToString();
            dta.RENDIMEN_VALRDT = result[i++].Value?.ToString();
            dta.IMPOST_VLIMPOST = result[i++].Value?.ToString();

            return dta;
        }

    }
}