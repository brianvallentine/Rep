using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0853B
{
    public class VF0853B_CCMPTIT : QueryBasis<VF0853B_CCMPTIT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0853B_CCMPTIT() { IsCursor = true; }

        public VF0853B_CCMPTIT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0COMP_NRPARCEL { get; set; }
        public string V0COMP_CODOPER { get; set; }
        public string V0COMP_PRMDIFVG { get; set; }
        public string V0COMP_PRMDIFAP { get; set; }

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


        public override VF0853B_CCMPTIT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0853B_CCMPTIT();
            var i = 0;

            dta.V0COMP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0COMP_CODOPER = result[i++].Value?.ToString();
            dta.V0COMP_PRMDIFVG = result[i++].Value?.ToString();
            dta.V0COMP_PRMDIFAP = result[i++].Value?.ToString();

            return dta;
        }

    }
}