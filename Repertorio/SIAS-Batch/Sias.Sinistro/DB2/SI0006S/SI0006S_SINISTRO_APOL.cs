using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0006S
{
    public class SI0006S_SINISTRO_APOL : QueryBasis<SI0006S_SINISTRO_APOL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0006S_SINISTRO_APOL() { IsCursor = true; }

        public SI0006S_SINISTRO_APOL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string W_HOST_VALOR_AVISADO_OPER_101 { get; set; }

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


        public override SI0006S_SINISTRO_APOL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0006S_SINISTRO_APOL();
            var i = 0;

            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.W_HOST_VALOR_AVISADO_OPER_101 = result[i++].Value?.ToString();

            return dta;
        }

    }
}