using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class CB0009B_V1BILHETE : QueryBasis<CB0009B_V1BILHETE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0009B_V1BILHETE() { IsCursor = true; }

        public CB0009B_V1BILHETE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0BILH_NUMBIL { get; set; }
        public string V0BILH_SITUACAO { get; set; }
        public string V0BILH_CODUSU { get; set; }
        public string V0BILH_DTCANCEL { get; set; }
        public string VIND_DTCANCEL { get; set; }
        public string V0BILH_RAMO { get; set; }

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


        public override CB0009B_V1BILHETE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0009B_V1BILHETE();
            var i = 0;

            dta.V0BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V0BILH_SITUACAO = result[i++].Value?.ToString();
            dta.V0BILH_CODUSU = result[i++].Value?.ToString();
            dta.V0BILH_DTCANCEL = result[i++].Value?.ToString();
            dta.VIND_DTCANCEL = string.IsNullOrWhiteSpace(dta.V0BILH_DTCANCEL) ? "-1" : "0";
            dta.V0BILH_RAMO = result[i++].Value?.ToString();

            return dta;
        }

    }
}