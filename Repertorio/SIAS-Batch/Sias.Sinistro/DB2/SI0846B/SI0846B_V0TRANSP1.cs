using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0846B
{
    public class SI0846B_V0TRANSP1 : QueryBasis<SI0846B_V0TRANSP1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0846B_V0TRANSP1() { IsCursor = true; }

        public SI0846B_V0TRANSP1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0NUM_APOL_SINISTRO { get; set; }
        public string V0COD_FRANQUE { get; set; }
        public string V0QTD_ITENS_SINI { get; set; }
        public string V0QTD_ITENS_TRANSP { get; set; }
        public string V0NUM_SINI_FRANQUE { get; set; }
        public string V0ANO_SINI_FRANQUE { get; set; }
        public string V0DATA_OCORR { get; set; }
        public string V0NUM_APOLICE { get; set; }

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


        public override SI0846B_V0TRANSP1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0846B_V0TRANSP1();
            var i = 0;

            dta.V0NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.V0COD_FRANQUE = result[i++].Value?.ToString();
            dta.V0QTD_ITENS_SINI = result[i++].Value?.ToString();
            dta.V0QTD_ITENS_TRANSP = result[i++].Value?.ToString();
            dta.V0NUM_SINI_FRANQUE = result[i++].Value?.ToString();
            dta.V0ANO_SINI_FRANQUE = result[i++].Value?.ToString();
            dta.V0DATA_OCORR = result[i++].Value?.ToString();
            dta.V0NUM_APOLICE = result[i++].Value?.ToString();

            return dta;
        }

    }
}