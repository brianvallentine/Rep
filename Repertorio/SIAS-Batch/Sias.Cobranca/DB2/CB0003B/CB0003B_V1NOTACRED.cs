using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class CB0003B_V1NOTACRED : QueryBasis<CB0003B_V1NOTACRED>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0003B_V1NOTACRED() { IsCursor = true; }

        public CB0003B_V1NOTACRED(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1NOTA_NRENDOSR { get; set; }
        public string V1NOTA_NRPARCELR { get; set; }
        public string V1NOTA_DTVENCTO { get; set; }
        public string V1NOTA_VALCREDR_IX { get; set; }

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


        public override CB0003B_V1NOTACRED OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0003B_V1NOTACRED();
            var i = 0;

            dta.V1NOTA_NRENDOSR = result[i++].Value?.ToString();
            dta.V1NOTA_NRPARCELR = result[i++].Value?.ToString();
            dta.V1NOTA_DTVENCTO = result[i++].Value?.ToString();
            dta.V1NOTA_VALCREDR_IX = result[i++].Value?.ToString();

            return dta;
        }

    }
}