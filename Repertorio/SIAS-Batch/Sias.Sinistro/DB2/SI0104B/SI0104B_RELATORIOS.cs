using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0104B
{
    public class SI0104B_RELATORIOS : QueryBasis<SI0104B_RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0104B_RELATORIOS() { IsCursor = true; }

        public SI0104B_RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1RELATORIOS_DATA1 { get; set; }
        public string V1RELATORIOS_DATA2 { get; set; }
        public string V1RELATORIOS_APOLICE1 { get; set; }

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


        public override SI0104B_RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0104B_RELATORIOS();
            var i = 0;

            dta.V1RELATORIOS_DATA1 = result[i++].Value?.ToString();
            dta.V1RELATORIOS_DATA2 = result[i++].Value?.ToString();
            dta.V1RELATORIOS_APOLICE1 = result[i++].Value?.ToString();

            return dta;
        }

    }
}