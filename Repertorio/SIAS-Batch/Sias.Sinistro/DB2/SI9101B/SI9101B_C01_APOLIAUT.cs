using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class SI9101B_C01_APOLIAUT : QueryBasis<SI9101B_C01_APOLIAUT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI9101B_C01_APOLIAUT() { IsCursor = true; }

        public SI9101B_C01_APOLIAUT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APOLIAUT_NUM_ITEM { get; set; }
        public string APOLIAUT_NUM_ENDOSSO { get; set; }
        public string APOLIAUT_DATA_INIVIGENCIA { get; set; }
        public string APOLIAUT_SIT_REGISTRO { get; set; }

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


        public override SI9101B_C01_APOLIAUT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI9101B_C01_APOLIAUT();
            var i = 0;

            dta.APOLIAUT_NUM_ITEM = result[i++].Value?.ToString();
            dta.APOLIAUT_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.APOLIAUT_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLIAUT_SIT_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}