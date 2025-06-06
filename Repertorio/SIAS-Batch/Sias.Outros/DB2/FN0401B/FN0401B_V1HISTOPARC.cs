using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0401B
{
    public class FN0401B_V1HISTOPARC : QueryBasis<FN0401B_V1HISTOPARC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FN0401B_V1HISTOPARC() { IsCursor = true; }

        public FN0401B_V1HISTOPARC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1HIST_NUMAPOL { get; set; }
        public string V1HIST_NRENDOS { get; set; }
        public string V1HIST_NRPARCEL { get; set; }
        public string V1HIST_DTMOVTO { get; set; }
        public string V1HIST_OPERACAO { get; set; }
        public string V1HIST_OCORHIST { get; set; }
        public string V1HIST_VLPRMLIQ { get; set; }
        public string V1HIST_VLPRMTOT { get; set; }
        public string V1HIST_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string V1HIST_DTVENCTO { get; set; }
        public string V0ENDO_CODSUBES { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }

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


        public override FN0401B_V1HISTOPARC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FN0401B_V1HISTOPARC();
            var i = 0;

            dta.V1HIST_NUMAPOL = result[i++].Value?.ToString();
            dta.V1HIST_NRENDOS = result[i++].Value?.ToString();
            dta.V1HIST_NRPARCEL = result[i++].Value?.ToString();
            dta.V1HIST_DTMOVTO = result[i++].Value?.ToString();
            dta.V1HIST_OPERACAO = result[i++].Value?.ToString();
            dta.V1HIST_OCORHIST = result[i++].Value?.ToString();
            dta.V1HIST_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V1HIST_VLPRMTOT = result[i++].Value?.ToString();
            dta.V1HIST_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DTQITBCO = string.IsNullOrWhiteSpace(dta.V1HIST_DTQITBCO) ? "-1" : "0";
            dta.V1HIST_DTVENCTO = result[i++].Value?.ToString();
            dta.V0ENDO_CODSUBES = result[i++].Value?.ToString();
            dta.V0ENDO_DTINIVIG = result[i++].Value?.ToString();

            return dta;
        }

    }
}