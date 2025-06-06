using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0864B
{
    public class SI0864B_BONUS : QueryBasis<SI0864B_BONUS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0864B_BONUS() { IsCursor = true; }

        public SI0864B_BONUS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string LOTBONUS_TIPO_BONUS { get; set; }

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


        public override SI0864B_BONUS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0864B_BONUS();
            var i = 0;

            dta.LOTBONUS_TIPO_BONUS = result[i++].Value?.ToString();

            return dta;
        }

    }
}