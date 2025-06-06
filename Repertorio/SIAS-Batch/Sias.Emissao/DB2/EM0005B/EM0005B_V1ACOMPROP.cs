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
    public class EM0005B_V1ACOMPROP : QueryBasis<EM0005B_V1ACOMPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0005B_V1ACOMPROP() { IsCursor = true; }

        public EM0005B_V1ACOMPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1APRO_DATOPR { get; set; }
        public string V1APRO_HORAOPER { get; set; }

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


        public override EM0005B_V1ACOMPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0005B_V1ACOMPROP();
            var i = 0;

            dta.V1APRO_DATOPR = result[i++].Value?.ToString();
            dta.V1APRO_HORAOPER = result[i++].Value?.ToString();

            return dta;
        }

    }
}