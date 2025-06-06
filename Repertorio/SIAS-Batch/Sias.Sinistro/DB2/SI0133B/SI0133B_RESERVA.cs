using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class SI0133B_RESERVA : QueryBasis<SI0133B_RESERVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0133B_RESERVA() { IsCursor = true; }

        public SI0133B_RESERVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string THIST_OPERACAO1 { get; set; }
        public string THIST_VALPRI1 { get; set; }

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


        public override SI0133B_RESERVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0133B_RESERVA();
            var i = 0;

            dta.THIST_OPERACAO1 = result[i++].Value?.ToString();
            dta.THIST_VALPRI1 = result[i++].Value?.ToString();

            return dta;
        }

    }
}