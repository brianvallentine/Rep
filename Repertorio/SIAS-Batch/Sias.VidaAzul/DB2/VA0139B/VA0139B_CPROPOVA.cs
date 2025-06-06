using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class VA0139B_CPROPOVA : QueryBasis<VA0139B_CPROPOVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0139B_CPROPOVA() { IsCursor = true; }

        public VA0139B_CPROPOVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_OCORHIST { get; set; }

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


        public override VA0139B_CPROPOVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0139B_CPROPOVA();
            var i = 0;

            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_OCORHIST = result[i++].Value?.ToString();

            return dta;
        }

    }
}