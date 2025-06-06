using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0078B
{
    public class SI0078B_V0RELATORIOS : QueryBasis<SI0078B_V0RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0078B_V0RELATORIOS() { IsCursor = true; }

        public SI0078B_V0RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0RELATORIOS_ANO_REFERENCIA { get; set; }
        public string V0RELATORIOS_MES_REFERENCIA { get; set; }

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


        public override SI0078B_V0RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0078B_V0RELATORIOS();
            var i = 0;

            dta.V0RELATORIOS_ANO_REFERENCIA = result[i++].Value?.ToString();
            dta.V0RELATORIOS_MES_REFERENCIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}