using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0303B
{
    public class FN0303B_DEBITO : QueryBasis<FN0303B_DEBITO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FN0303B_DEBITO() { IsCursor = true; }

        public FN0303B_DEBITO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string NRAPOLICE { get; set; }
        public string CODSUBES { get; set; }
        public string SITUACAO_PROP { get; set; }
        public string NRCERTIF { get; set; }
        public string NRPARCEL { get; set; }
        public string AGECTADEB { get; set; }
        public string VIND_AGECTADEB { get; set; }
        public string OPRCTADEB { get; set; }
        public string VIND_OPRCTADEB { get; set; }
        public string NUMCTADEB { get; set; }
        public string VIND_NUMCTADEB { get; set; }
        public string DIGCTADEB { get; set; }
        public string VIND_DIGCTADEB { get; set; }
        public string OPCAOPAG { get; set; }
        public string OCORHIST { get; set; }
        public string VLPRMTOT { get; set; }
        public string SITUACAO_COBR { get; set; }
        public string DTVENCTO { get; set; }

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


        public override FN0303B_DEBITO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FN0303B_DEBITO();
            var i = 0;

            dta.NRAPOLICE = result[i++].Value?.ToString();
            dta.CODSUBES = result[i++].Value?.ToString();
            dta.SITUACAO_PROP = result[i++].Value?.ToString();
            dta.NRCERTIF = result[i++].Value?.ToString();
            dta.NRPARCEL = result[i++].Value?.ToString();
            dta.AGECTADEB = result[i++].Value?.ToString();
            dta.VIND_AGECTADEB = string.IsNullOrWhiteSpace(dta.AGECTADEB) ? "-1" : "0";
            dta.OPRCTADEB = result[i++].Value?.ToString();
            dta.VIND_OPRCTADEB = string.IsNullOrWhiteSpace(dta.OPRCTADEB) ? "-1" : "0";
            dta.NUMCTADEB = result[i++].Value?.ToString();
            dta.VIND_NUMCTADEB = string.IsNullOrWhiteSpace(dta.NUMCTADEB) ? "-1" : "0";
            dta.DIGCTADEB = result[i++].Value?.ToString();
            dta.VIND_DIGCTADEB = string.IsNullOrWhiteSpace(dta.DIGCTADEB) ? "-1" : "0";
            dta.OPCAOPAG = result[i++].Value?.ToString();
            dta.OCORHIST = result[i++].Value?.ToString();
            dta.VLPRMTOT = result[i++].Value?.ToString();
            dta.SITUACAO_COBR = result[i++].Value?.ToString();
            dta.DTVENCTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}