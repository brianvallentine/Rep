using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0847B
{
    public class SI0847B_SINISTRO : QueryBasis<SI0847B_SINISTRO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0847B_SINISTRO() { IsCursor = true; }

        public SI0847B_SINISTRO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1MSIN_NUM_APOL { get; set; }
        public string V1MSIN_NRENDOS { get; set; }
        public string V1MSIN_DATORR { get; set; }
        public string V1MSIN_FONTE { get; set; }
        public string V1MSIN_CODCAU { get; set; }
        public string V1MSIN_RAMO { get; set; }
        public string V1HSIN_NUM_SINI { get; set; }
        public string V1HSIN_VAL_OPERACAO { get; set; }
        public string V1HSIN_DTMOVTO { get; set; }
        public string V1SAUT_NRITEM { get; set; }

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


        public override SI0847B_SINISTRO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0847B_SINISTRO();
            var i = 0;

            dta.V1MSIN_NUM_APOL = result[i++].Value?.ToString();
            dta.V1MSIN_NRENDOS = result[i++].Value?.ToString();
            dta.V1MSIN_DATORR = result[i++].Value?.ToString();
            dta.V1MSIN_FONTE = result[i++].Value?.ToString();
            dta.V1MSIN_CODCAU = result[i++].Value?.ToString();
            dta.V1MSIN_RAMO = result[i++].Value?.ToString();
            dta.V1HSIN_NUM_SINI = result[i++].Value?.ToString();
            dta.V1HSIN_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.V1HSIN_DTMOVTO = result[i++].Value?.ToString();
            dta.V1SAUT_NRITEM = result[i++].Value?.ToString();

            return dta;
        }

    }
}