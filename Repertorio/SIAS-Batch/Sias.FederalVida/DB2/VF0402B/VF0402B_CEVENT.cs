using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0402B
{
    public class VF0402B_CEVENT : QueryBasis<VF0402B_CEVENT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0402B_CEVENT() { IsCursor = true; }

        public VF0402B_CEVENT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0EVEN_NRCERTIF { get; set; }
        public string V0EVEN_VLPREMIO { get; set; }

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


        public override VF0402B_CEVENT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0402B_CEVENT();
            var i = 0;

            dta.V0EVEN_NRCERTIF = result[i++].Value?.ToString();
            dta.V0EVEN_VLPREMIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}