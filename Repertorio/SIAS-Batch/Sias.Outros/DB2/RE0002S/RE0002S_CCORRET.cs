using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0002S
{
    public class RE0002S_CCORRET : QueryBasis<RE0002S_CCORRET>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public RE0002S_CCORRET() { IsCursor = true; }

        public RE0002S_CCORRET(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APOLICOR_PCT_PART_CORRETOR { get; set; }
        public string APOLICOR_PCT_COM_CORRETOR { get; set; }

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


        public override RE0002S_CCORRET OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new RE0002S_CCORRET();
            var i = 0;

            dta.APOLICOR_PCT_PART_CORRETOR = result[i++].Value?.ToString();
            dta.APOLICOR_PCT_COM_CORRETOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}