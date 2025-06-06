using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class VF0118B_CBENEFP : QueryBasis<VF0118B_CBENEFP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0118B_CBENEFP() { IsCursor = true; }

        public VF0118B_CBENEFP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BENEF_NOMBENEF { get; set; }
        public string BENEF_GRAUPAR { get; set; }
        public string BENEF_PCTBENEF { get; set; }

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


        public override VF0118B_CBENEFP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0118B_CBENEFP();
            var i = 0;

            dta.BENEF_NOMBENEF = result[i++].Value?.ToString();
            dta.BENEF_GRAUPAR = result[i++].Value?.ToString();
            dta.BENEF_PCTBENEF = result[i++].Value?.ToString();

            return dta;
        }

    }
}