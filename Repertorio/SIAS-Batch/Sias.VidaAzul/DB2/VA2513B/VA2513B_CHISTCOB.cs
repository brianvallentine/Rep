using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2513B
{
    public class VA2513B_CHISTCOB : QueryBasis<VA2513B_CHISTCOB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2513B_CHISTCOB() { IsCursor = true; }

        public VA2513B_CHISTCOB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HIST_NRCERTIF { get; set; }
        public string V0HIST_NRPARCEL { get; set; }
        public string V0HIST_NRTIT { get; set; }
        public string V0HIST_DTVENCTO { get; set; }
        public string V0HIST_VLPRMTOT { get; set; }
        public string V0HIST_CODOPER { get; set; }
        public string V0HIST_OPCAOPAG { get; set; }
        public string V0HIST_NRTITCOMP { get; set; }
        public string V0HIST_CODPRODU { get; set; }
        public string V0HIST_OCORHIST { get; set; }
        public string V0HIST_CDCLIENTE { get; set; }
        public string V0HIST_IDSEXO { get; set; }
        public string V0HIST_OPCOBERT { get; set; }
        public string V0HIST_NRAPOLICE { get; set; }
        public string V0HIST_CODSUBES { get; set; }
        public string V0HIST_AGECOBR { get; set; }
        public string V0HIST_FONTE { get; set; }

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


        public override VA2513B_CHISTCOB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2513B_CHISTCOB();
            var i = 0;

            dta.V0HIST_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HIST_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HIST_NRTIT = result[i++].Value?.ToString();
            dta.V0HIST_DTVENCTO = result[i++].Value?.ToString();
            dta.V0HIST_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0HIST_CODOPER = result[i++].Value?.ToString();
            dta.V0HIST_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0HIST_NRTITCOMP = result[i++].Value?.ToString();
            dta.V0HIST_CODPRODU = result[i++].Value?.ToString();
            dta.V0HIST_OCORHIST = result[i++].Value?.ToString();
            dta.V0HIST_CDCLIENTE = result[i++].Value?.ToString();
            dta.V0HIST_IDSEXO = result[i++].Value?.ToString();
            dta.V0HIST_OPCOBERT = result[i++].Value?.ToString();
            dta.V0HIST_NRAPOLICE = result[i++].Value?.ToString();
            dta.V0HIST_CODSUBES = result[i++].Value?.ToString();
            dta.V0HIST_AGECOBR = result[i++].Value?.ToString();
            dta.V0HIST_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}