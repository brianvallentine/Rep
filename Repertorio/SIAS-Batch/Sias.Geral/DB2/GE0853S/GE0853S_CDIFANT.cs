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
    public class GE0853S_CDIFANT : QueryBasis<GE0853S_CDIFANT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0853S_CDIFANT() { IsCursor = true; }

        public GE0853S_CDIFANT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V2DIFP_NRPARCDIF { get; set; }
        public string V2DIFP_PRMVG { get; set; }
        public string V2DIFP_PRMAP { get; set; }
        public string V2DIFP_CODOPER { get; set; }

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


        public override GE0853S_CDIFANT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0853S_CDIFANT();
            var i = 0;

            dta.V2DIFP_NRPARCDIF = result[i++].Value?.ToString();
            dta.V2DIFP_PRMVG = result[i++].Value?.ToString();
            dta.V2DIFP_PRMAP = result[i++].Value?.ToString();
            dta.V2DIFP_CODOPER = result[i++].Value?.ToString();

            return dta;
        }

    }
}