using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class VA2646B_TPROPOVA : QueryBasis<VA2646B_TPROPOVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2646B_TPROPOVA() { IsCursor = true; }

        public VA2646B_TPROPOVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_DTNASC_ESPOSA { get; set; }
        public string VIND_NULL { get; set; }
        public string PROPOVA_NRCERTIFANT { get; set; }
        public string VIND_NULL_2 { get; set; }
        public string MOVVGAP_NUM_APOLICE { get; set; }
        public string MOVVGAP_COD_SUBGRUPO { get; set; }
        public string MOVVGAP_COD_FONTE { get; set; }
        public string MOVVGAP_NUM_PROPOSTA { get; set; }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string PROPOVA_DTINCLUS { get; set; }

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


        public override VA2646B_TPROPOVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2646B_TPROPOVA();
            var i = 0;

            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_DTNASC_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_NULL = string.IsNullOrWhiteSpace(dta.PROPOVA_DTNASC_ESPOSA) ? "-1" : "0";
            dta.PROPOVA_NRCERTIFANT = result[i++].Value?.ToString();
            dta.VIND_NULL_2 = string.IsNullOrWhiteSpace(dta.PROPOVA_NRCERTIFANT) ? "-1" : "0";
            dta.MOVVGAP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_FONTE = result[i++].Value?.ToString();
            dta.MOVVGAP_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.PRODUVG_ORIG_PRODU = result[i++].Value?.ToString();
            dta.PROPOVA_DTINCLUS = result[i++].Value?.ToString();

            return dta;
        }

    }
}