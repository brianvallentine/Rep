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
    public class VF0402B_C2 : QueryBasis<VF0402B_C2>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0402B_C2() { IsCursor = true; }

        public VF0402B_C2(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PLCO_CODCOR { get; set; }

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


        public override VF0402B_C2 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0402B_C2();
            var i = 0;

            dta.V0PLCO_CODCOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}