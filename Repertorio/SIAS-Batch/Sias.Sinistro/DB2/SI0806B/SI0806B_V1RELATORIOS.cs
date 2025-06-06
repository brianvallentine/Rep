using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0806B
{
    public class SI0806B_V1RELATORIOS : QueryBasis<SI0806B_V1RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0806B_V1RELATORIOS() { IsCursor = true; }

        public SI0806B_V1RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1RELA_CODRELAT { get; set; }
        public string V1RELA_DATA_REFERE { get; set; }

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


        public override SI0806B_V1RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0806B_V1RELATORIOS();
            var i = 0;

            dta.V1RELA_CODRELAT = result[i++].Value?.ToString();
            dta.V1RELA_DATA_REFERE = result[i++].Value?.ToString();

            return dta;
        }

    }
}