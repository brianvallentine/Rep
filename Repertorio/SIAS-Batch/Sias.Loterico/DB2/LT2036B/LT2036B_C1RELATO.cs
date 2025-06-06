using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2036B
{
    public class LT2036B_C1RELATO : QueryBasis<LT2036B_C1RELATO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public LT2036B_C1RELATO() { IsCursor = true; }

        public LT2036B_C1RELATO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0LOT_COD_LOT_FENAL { get; set; }
        public string V0APO_NUM_APOLICE { get; set; }
        public string V0APO_NUM_ENDOSSO { get; set; }

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


        public override LT2036B_C1RELATO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new LT2036B_C1RELATO();
            var i = 0;

            dta.V0LOT_COD_LOT_FENAL = result[i++].Value?.ToString();
            dta.V0APO_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0APO_NUM_ENDOSSO = result[i++].Value?.ToString();

            return dta;
        }

    }
}