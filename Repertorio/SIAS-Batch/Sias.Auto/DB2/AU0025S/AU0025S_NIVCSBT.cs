using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU0025S
{
    public class AU0025S_NIVCSBT : QueryBasis<AU0025S_NIVCSBT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AU0025S_NIVCSBT() { IsCursor = true; }

        public AU0025S_NIVCSBT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string NIVCS_NIVEL { get; set; }
        public string NIVCS_IMPSEGBT { get; set; }

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


        public override AU0025S_NIVCSBT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AU0025S_NIVCSBT();
            var i = 0;

            dta.NIVCS_NIVEL = result[i++].Value?.ToString();
            dta.NIVCS_IMPSEGBT = result[i++].Value?.ToString();

            return dta;
        }

    }
}