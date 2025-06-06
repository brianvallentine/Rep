using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class EM0005B_V1COSSEGSORT : QueryBasis<EM0005B_V1COSSEGSORT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0005B_V1COSSEGSORT() { IsCursor = true; }

        public EM0005B_V1COSSEGSORT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1COSS_RAMO { get; set; }
        public string V1COSS_CONGENER { get; set; }
        public string V1COSS_PCCOMCOS { get; set; }
        public string V1COSS_PCPARTIC { get; set; }
        public string V1COSS_SITUACAO { get; set; }

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


        public override EM0005B_V1COSSEGSORT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0005B_V1COSSEGSORT();
            var i = 0;

            dta.V1COSS_RAMO = result[i++].Value?.ToString();
            dta.V1COSS_CONGENER = result[i++].Value?.ToString();
            dta.V1COSS_PCCOMCOS = result[i++].Value?.ToString();
            dta.V1COSS_PCPARTIC = result[i++].Value?.ToString();
            dta.V1COSS_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}