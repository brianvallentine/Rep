using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1127B
{
    public class CB1127B_V0RCAP : QueryBasis<CB1127B_V0RCAP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB1127B_V0RCAP() { IsCursor = true; }

        public CB1127B_V0RCAP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0RCAP_VLRCAP { get; set; }
        public string V0RCAP_VALPRI { get; set; }
        public string V0RCAP_OPERACAO { get; set; }
        public string V0RCAP_NRTIT { get; set; }
        public string VIND_NRTIT { get; set; }
        public string V0RCAP_CODPRODU { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string V0RCAP_AGECOBR { get; set; }
        public string VIND_AGECOBR { get; set; }
        public string V0RCAP_NRCERTIF { get; set; }
        public string VIND_NRCERTIF { get; set; }
        public string V0RCOM_FONTE { get; set; }
        public string V0RCOM_NRRCAP { get; set; }
        public string V0RCOM_NRRCAPCO { get; set; }
        public string V0RCOM_OPERACAO { get; set; }
        public string V0RCOM_BCOAVISO { get; set; }
        public string V0RCOM_AGEAVISO { get; set; }
        public string V0RCOM_NRAVISO { get; set; }
        public string V0RCOM_VLRCAP { get; set; }
        public string V0RCOM_DATARCAP { get; set; }
        public string V0RCOM_DTCADAST { get; set; }
        public string V0RCOM_SITCONTB { get; set; }
        public string V0AVIS_ORIGEM { get; set; }
        public string VIND_ORIGEM { get; set; }

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


        public override CB1127B_V0RCAP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB1127B_V0RCAP();
            var i = 0;

            dta.V0RCAP_VLRCAP = result[i++].Value?.ToString();
            dta.V0RCAP_VALPRI = result[i++].Value?.ToString();
            dta.V0RCAP_OPERACAO = result[i++].Value?.ToString();
            dta.V0RCAP_NRTIT = result[i++].Value?.ToString();
            dta.VIND_NRTIT = string.IsNullOrWhiteSpace(dta.V0RCAP_NRTIT) ? "-1" : "0";
            dta.V0RCAP_CODPRODU = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.V0RCAP_CODPRODU) ? "-1" : "0";
            dta.V0RCAP_AGECOBR = result[i++].Value?.ToString();
            dta.VIND_AGECOBR = string.IsNullOrWhiteSpace(dta.V0RCAP_AGECOBR) ? "-1" : "0";
            dta.V0RCAP_NRCERTIF = result[i++].Value?.ToString();
            dta.VIND_NRCERTIF = string.IsNullOrWhiteSpace(dta.V0RCAP_NRCERTIF) ? "-1" : "0";
            dta.V0RCOM_FONTE = result[i++].Value?.ToString();
            dta.V0RCOM_NRRCAP = result[i++].Value?.ToString();
            dta.V0RCOM_NRRCAPCO = result[i++].Value?.ToString();
            dta.V0RCOM_OPERACAO = result[i++].Value?.ToString();
            dta.V0RCOM_BCOAVISO = result[i++].Value?.ToString();
            dta.V0RCOM_AGEAVISO = result[i++].Value?.ToString();
            dta.V0RCOM_NRAVISO = result[i++].Value?.ToString();
            dta.V0RCOM_VLRCAP = result[i++].Value?.ToString();
            dta.V0RCOM_DATARCAP = result[i++].Value?.ToString();
            dta.V0RCOM_DTCADAST = result[i++].Value?.ToString();
            dta.V0RCOM_SITCONTB = result[i++].Value?.ToString();
            dta.V0AVIS_ORIGEM = result[i++].Value?.ToString();
            dta.VIND_ORIGEM = string.IsNullOrWhiteSpace(dta.V0AVIS_ORIGEM) ? "-1" : "0";

            return dta;
        }

    }
}