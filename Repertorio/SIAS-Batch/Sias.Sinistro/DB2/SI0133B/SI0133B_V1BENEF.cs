using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class SI0133B_V1BENEF : QueryBasis<SI0133B_V1BENEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0133B_V1BENEF() { IsCursor = true; }

        public SI0133B_V1BENEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string TBENEF_NOME_BENEFIC { get; set; }
        public string TBENEF_GRAU_PARENT { get; set; }
        public string TBENEF_PCT_PART_BENEF { get; set; }

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


        public override SI0133B_V1BENEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0133B_V1BENEF();
            var i = 0;

            dta.TBENEF_NOME_BENEFIC = result[i++].Value?.ToString();
            dta.TBENEF_GRAU_PARENT = result[i++].Value?.ToString();
            dta.TBENEF_PCT_PART_BENEF = result[i++].Value?.ToString();

            return dta;
        }

    }
}