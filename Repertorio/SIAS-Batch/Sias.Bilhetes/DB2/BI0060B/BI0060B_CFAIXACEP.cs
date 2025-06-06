using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0060B
{
    public class BI0060B_CFAIXACEP : QueryBasis<BI0060B_CFAIXACEP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0060B_CFAIXACEP() { IsCursor = true; }

        public BI0060B_CFAIXACEP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0FAIC_FAIXA { get; set; }
        public string V0FAIC_CEPINI { get; set; }
        public string V0FAIC_CEPFIM { get; set; }
        public string V0FAIC_DESC_FAIXA { get; set; }
        public string V0FAIC_CENTRALIZA { get; set; }

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


        public override BI0060B_CFAIXACEP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0060B_CFAIXACEP();
            var i = 0;

            dta.V0FAIC_FAIXA = result[i++].Value?.ToString();
            dta.V0FAIC_CEPINI = result[i++].Value?.ToString();
            dta.V0FAIC_CEPFIM = result[i++].Value?.ToString();
            dta.V0FAIC_DESC_FAIXA = result[i++].Value?.ToString();
            dta.V0FAIC_CENTRALIZA = result[i++].Value?.ToString();

            return dta;
        }

    }
}