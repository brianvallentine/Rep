using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0861B
{
    public class SI0861B_PAGO : QueryBasis<SI0861B_PAGO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0861B_PAGO() { IsCursor = true; }

        public SI0861B_PAGO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISMES_TIPO_REGISTRO { get; set; }
        public string HOST_FONTE { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

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


        public override SI0861B_PAGO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0861B_PAGO();
            var i = 0;

            dta.SINISMES_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.HOST_FONTE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}