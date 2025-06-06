using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class VF0851B_CPROPVA : QueryBasis<VF0851B_CPROPVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0851B_CPROPVA() { IsCursor = true; }

        public VF0851B_CPROPVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_CODPRODU { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_CODCLIEN { get; set; }

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


        public override VF0851B_CPROPVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0851B_CPROPVA();
            var i = 0;

            dta.V0PROP_NRCERTIF = result[i++].Value?.ToString();
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_FONTE = result[i++].Value?.ToString();
            dta.V0PROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();

            return dta;
        }

    }
}