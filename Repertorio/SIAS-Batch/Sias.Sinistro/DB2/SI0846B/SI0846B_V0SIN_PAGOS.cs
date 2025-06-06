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
    public class SI0846B_V0SIN_PAGOS : QueryBasis<SI0846B_V0SIN_PAGOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0846B_V0SIN_PAGOS() { IsCursor = true; }

        public SI0846B_V0SIN_PAGOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0NOMEFAV { get; set; }
        public string V0DTMOVTO { get; set; }
        public string V0VAL_OPERACAO { get; set; }

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


        public override SI0846B_V0SIN_PAGOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0846B_V0SIN_PAGOS();
            var i = 0;

            dta.V0NOMEFAV = result[i++].Value?.ToString();
            dta.V0DTMOVTO = result[i++].Value?.ToString();
            dta.V0VAL_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}