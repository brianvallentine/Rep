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
    public class SI0846B_V0RELATORIOS : QueryBasis<SI0846B_V0RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0846B_V0RELATORIOS() { IsCursor = true; }

        public SI0846B_V0RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0CODUSU { get; set; }
        public string V0PERI_INICIAL { get; set; }
        public string V0PERI_FINAL { get; set; }
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


        public override SI0846B_V0RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0846B_V0RELATORIOS();
            var i = 0;

            dta.V0CODUSU = result[i++].Value?.ToString();
            dta.V0PERI_INICIAL = result[i++].Value?.ToString();
            dta.V0PERI_FINAL = result[i++].Value?.ToString();
            dta.V0NUM_APOLICE = result[i++].Value?.ToString();

            return dta;
        }

    }
}