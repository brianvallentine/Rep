using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI2010B
{
    public class SI2010B_V1SISINCHE : QueryBasis<SI2010B_V1SISINCHE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI2010B_V1SISINCHE() { IsCursor = true; }

        public SI2010B_V1SISINCHE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SISINCHE_NUM_CHEQUE_INTERNO { get; set; }

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


        public override SI2010B_V1SISINCHE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI2010B_V1SISINCHE();
            var i = 0;

            dta.SISINCHE_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();

            return dta;
        }

    }
}