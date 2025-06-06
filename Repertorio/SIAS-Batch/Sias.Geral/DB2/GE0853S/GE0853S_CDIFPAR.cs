using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class GE0853S_CDIFPAR : QueryBasis<GE0853S_CDIFPAR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0853S_CDIFPAR() { IsCursor = true; }

        public GE0853S_CDIFPAR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0DIFP_NRPARCEL { get; set; }
        public string V0DIFP_NRPARCELDIF { get; set; }
        public string V0DIFP_CODOPER { get; set; }
        public string V0DIFP_VLPRMTOT { get; set; }
        public string V0DIFP_PRMDIFVG { get; set; }
        public string V0DIFP_PRMDIFAP { get; set; }

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


        public override GE0853S_CDIFPAR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0853S_CDIFPAR();
            var i = 0;

            dta.V0DIFP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0DIFP_NRPARCELDIF = result[i++].Value?.ToString();
            dta.V0DIFP_CODOPER = result[i++].Value?.ToString();
            dta.V0DIFP_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0DIFP_PRMDIFVG = result[i++].Value?.ToString();
            dta.V0DIFP_PRMDIFAP = result[i++].Value?.ToString();

            return dta;
        }

    }
}