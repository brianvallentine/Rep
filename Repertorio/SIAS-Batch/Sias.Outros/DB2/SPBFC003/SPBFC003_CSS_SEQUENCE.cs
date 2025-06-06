using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBFC003
{
    public class SPBFC003_CSS_SEQUENCE : QueryBasis<SPBFC003_CSS_SEQUENCE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SPBFC003_CSS_SEQUENCE() { IsCursor = true; }

        public SPBFC003_CSS_SEQUENCE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FCSEQUEN_NUM_SEQ { get; set; }

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


        public override SPBFC003_CSS_SEQUENCE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SPBFC003_CSS_SEQUENCE();
            var i = 0;

            dta.FCSEQUEN_NUM_SEQ = result[i++].Value?.ToString();

            return dta;
        }

    }
}