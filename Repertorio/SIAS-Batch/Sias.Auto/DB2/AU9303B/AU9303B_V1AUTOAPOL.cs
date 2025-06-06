using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU9303B
{
    public class AU9303B_V1AUTOAPOL : QueryBasis<AU9303B_V1AUTOAPOL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AU9303B_V1AUTOAPOL() { IsCursor = true; }

        public AU9303B_V1AUTOAPOL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1AUTA_NUM_APOLICE { get; set; }
        public string V1AUTA_NRENDOS { get; set; }
        public string V1AUTA_FONTE { get; set; }
        public string V1AUTA_NRPROPOS { get; set; }
        public string V1AUTA_NRITEM { get; set; }

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


        public override AU9303B_V1AUTOAPOL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AU9303B_V1AUTOAPOL();
            var i = 0;

            dta.V1AUTA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V1AUTA_NRENDOS = result[i++].Value?.ToString();
            dta.V1AUTA_FONTE = result[i++].Value?.ToString();
            dta.V1AUTA_NRPROPOS = result[i++].Value?.ToString();
            dta.V1AUTA_NRITEM = result[i++].Value?.ToString();

            return dta;
        }

    }
}