using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0155B
{
    public class CB0155B_V0RCAP1 : QueryBasis<CB0155B_V0RCAP1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0155B_V0RCAP1() { IsCursor = true; }

        public CB0155B_V0RCAP1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RCAPCOMP_NUM_RCAP { get; set; }
        public string RCAPCOMP_NUM_RCAP_COMPLEMEN { get; set; }
        public string RCAPCOMP_DATA_MOVIMENTO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_VAL_RCAP { get; set; }
        public string RCAPCOMP_DATA_RCAP { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }
        public string VIND_NRTIT { get; set; }
        public string RCAPS_CODIGO_PRODUTO { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string RCAPS_AGE_COBRANCA { get; set; }
        public string VIND_AGECOBR { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }
        public string VIND_NRCERTIF { get; set; }

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


        public override CB0155B_V0RCAP1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0155B_V0RCAP1();
            var i = 0;

            dta.RCAPCOMP_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_RCAP_COMPLEMEN = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.RCAPCOMP_BCO_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_AGE_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.RCAPCOMP_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_NUM_TITULO = result[i++].Value?.ToString();
            dta.VIND_NRTIT = string.IsNullOrWhiteSpace(dta.RCAPS_NUM_TITULO) ? "-1" : "0";
            dta.RCAPS_CODIGO_PRODUTO = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.RCAPS_CODIGO_PRODUTO) ? "-1" : "0";
            dta.RCAPS_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.VIND_AGECOBR = string.IsNullOrWhiteSpace(dta.RCAPS_AGE_COBRANCA) ? "-1" : "0";
            dta.RCAPS_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VIND_NRCERTIF = string.IsNullOrWhiteSpace(dta.RCAPS_NUM_CERTIFICADO) ? "-1" : "0";

            return dta;
        }

    }
}