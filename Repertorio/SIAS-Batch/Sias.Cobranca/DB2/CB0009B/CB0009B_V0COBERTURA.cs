using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class CB0009B_V0COBERTURA : QueryBasis<CB0009B_V0COBERTURA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0009B_V0COBERTURA() { IsCursor = true; }

        public CB0009B_V0COBERTURA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0BCOB_CODOPCAO { get; set; }
        public string V0BCOB_DTINIVIG { get; set; }
        public string V0BCOB_VLPRMTOT { get; set; }
        public string VIND_VLPRMTOT { get; set; }

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


        public override CB0009B_V0COBERTURA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0009B_V0COBERTURA();
            var i = 0;

            dta.V0BCOB_CODOPCAO = result[i++].Value?.ToString();
            dta.V0BCOB_DTINIVIG = result[i++].Value?.ToString();
            dta.V0BCOB_VLPRMTOT = result[i++].Value?.ToString();
            dta.VIND_VLPRMTOT = string.IsNullOrWhiteSpace(dta.V0BCOB_VLPRMTOT) ? "-1" : "0";

            return dta;
        }

    }
}