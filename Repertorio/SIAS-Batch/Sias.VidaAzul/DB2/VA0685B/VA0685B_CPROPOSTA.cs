using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class VA0685B_CPROPOSTA : QueryBasis<VA0685B_CPROPOSTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0685B_CPROPOSTA() { IsCursor = true; }

        public VA0685B_CPROPOSTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_NUM_MATRI_VENDEDOR { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string VGPROP_COD_USUARIO { get; set; }
        public string VIND_COD_USUARIO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_DATA_MOVIMENTO { get; set; }
        public string VGPROP_QTD_DIAS { get; set; }

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


        public override VA0685B_CPROPOSTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0685B_CPROPOSTA();
            var i = 0;

            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_MATRI_VENDEDOR = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.VGPROP_COD_USUARIO = result[i++].Value?.ToString();
            dta.VIND_COD_USUARIO = string.IsNullOrWhiteSpace(dta.VGPROP_COD_USUARIO) ? "-1" : "0";
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.VGPROP_QTD_DIAS = result[i++].Value?.ToString();

            return dta;
        }

    }
}