using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2139B
{
    public class VA2139B_CPROPVA : QueryBasis<VA2139B_CPROPVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2139B_CPROPVA() { IsCursor = true; }

        public VA2139B_CPROPVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_CODPRODU { get; set; }
        public string V0PROP_IDADE { get; set; }
        public string V0PROP_OPCAO_COBER { get; set; }

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


        public override VA2139B_CPROPVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2139B_CPROPVA();
            var i = 0;

            dta.V0PROP_NRCERTIF = result[i++].Value?.ToString();
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROP_IDADE = result[i++].Value?.ToString();
            dta.V0PROP_OPCAO_COBER = result[i++].Value?.ToString();

            return dta;
        }

    }
}