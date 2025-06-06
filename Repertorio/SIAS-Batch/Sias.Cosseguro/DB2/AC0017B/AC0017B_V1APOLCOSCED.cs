using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0017B
{
    public class AC0017B_V1APOLCOSCED : QueryBasis<AC0017B_V1APOLCOSCED>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0017B_V1APOLCOSCED() { IsCursor = true; }

        public AC0017B_V1APOLCOSCED(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1APCD_CODCOSS { get; set; }
        public string V1APCD_PCPARTIC { get; set; }
        public string V1APCD_PCCOMCOS { get; set; }

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


        public override AC0017B_V1APOLCOSCED OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0017B_V1APOLCOSCED();
            var i = 0;

            dta.V1APCD_CODCOSS = result[i++].Value?.ToString();
            dta.V1APCD_PCPARTIC = result[i++].Value?.ToString();
            dta.V1APCD_PCCOMCOS = result[i++].Value?.ToString();

            return dta;
        }

    }
}