using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0341B
{
    public class VF0341B_DEBITO : QueryBasis<VF0341B_DEBITO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0341B_DEBITO() { IsCursor = true; }

        public VF0341B_DEBITO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string NRCERTIF { get; set; }
        public string NRPARCEL { get; set; }
        public string AGECTADEB { get; set; }
        public string OPRCTADEB { get; set; }
        public string NUMCTADEB { get; set; }
        public string DIGCTADEB { get; set; }
        public string VLPRMTOT { get; set; }
        public string SITUACAO { get; set; }
        public string DTVENCTO { get; set; }
        public string NSAS { get; set; }
        public string SQL_MAYBE_NULL1 { get; set; }
        public string NSL { get; set; }
        public string SQL_MAYBE_NULL2 { get; set; }

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


        public override VF0341B_DEBITO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0341B_DEBITO();
            var i = 0;

            dta.NRCERTIF = result[i++].Value?.ToString();
            dta.NRPARCEL = result[i++].Value?.ToString();
            dta.AGECTADEB = result[i++].Value?.ToString();
            dta.OPRCTADEB = result[i++].Value?.ToString();
            dta.NUMCTADEB = result[i++].Value?.ToString();
            dta.DIGCTADEB = result[i++].Value?.ToString();
            dta.VLPRMTOT = result[i++].Value?.ToString();
            dta.SITUACAO = result[i++].Value?.ToString();
            dta.DTVENCTO = result[i++].Value?.ToString();
            dta.NSAS = result[i++].Value?.ToString();
            dta.SQL_MAYBE_NULL1 = string.IsNullOrWhiteSpace(dta.NSAS) ? "-1" : "0";
            dta.NSL = result[i++].Value?.ToString();
            dta.SQL_MAYBE_NULL2 = string.IsNullOrWhiteSpace(dta.NSL) ? "-1" : "0";

            return dta;
        }

    }
}