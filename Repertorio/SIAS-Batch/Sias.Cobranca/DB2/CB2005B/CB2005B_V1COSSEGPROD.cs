using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class CB2005B_V1COSSEGPROD : QueryBasis<CB2005B_V1COSSEGPROD>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB2005B_V1COSSEGPROD() { IsCursor = true; }

        public CB2005B_V1COSSEGPROD(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1COSP_CODPRODU { get; set; }
        public string V1COSP_RAMO { get; set; }
        public string V1COSP_CONGENER { get; set; }
        public string V1COSP_PCPARTIC { get; set; }
        public string V1COSP_PCCOMCOS { get; set; }
        public string V1COSP_PCADMCOS { get; set; }
        public string V1COSP_DTINIVIG { get; set; }
        public string V1COSP_DTTERVIG { get; set; }
        public string V1COSP_SITUACAO { get; set; }

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


        public override CB2005B_V1COSSEGPROD OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB2005B_V1COSSEGPROD();
            var i = 0;

            dta.V1COSP_CODPRODU = result[i++].Value?.ToString();
            dta.V1COSP_RAMO = result[i++].Value?.ToString();
            dta.V1COSP_CONGENER = result[i++].Value?.ToString();
            dta.V1COSP_PCPARTIC = result[i++].Value?.ToString();
            dta.V1COSP_PCCOMCOS = result[i++].Value?.ToString();
            dta.V1COSP_PCADMCOS = result[i++].Value?.ToString();
            dta.V1COSP_DTINIVIG = result[i++].Value?.ToString();
            dta.V1COSP_DTTERVIG = result[i++].Value?.ToString();
            dta.V1COSP_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}