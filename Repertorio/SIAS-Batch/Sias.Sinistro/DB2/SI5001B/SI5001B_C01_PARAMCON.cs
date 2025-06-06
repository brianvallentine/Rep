using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5001B
{
    public class SI5001B_C01_PARAMCON : QueryBasis<SI5001B_C01_PARAMCON>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI5001B_C01_PARAMCON() { IsCursor = true; }

        public SI5001B_C01_PARAMCON(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PARAMCON_NSAS { get; set; }

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


        public override SI5001B_C01_PARAMCON OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI5001B_C01_PARAMCON();
            var i = 0;

            dta.PARAMCON_NSAS = result[i++].Value?.ToString();

            return dta;
        }

    }
}