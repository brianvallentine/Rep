using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202B
{
    public class SI0202B_XXX : QueryBasis<SI0202B_XXX>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0202B_XXX() { IsCursor = true; }

        public SI0202B_XXX(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HOST_DATA_HOJE_MENOS_05_DIAS { get; set; }
        public string HOST_DATA_HOJE_MENOS_40_DIAS { get; set; }

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


        public override SI0202B_XXX OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0202B_XXX();
            var i = 0;

            dta.HOST_DATA_HOJE_MENOS_05_DIAS = result[i++].Value?.ToString();
            dta.HOST_DATA_HOJE_MENOS_40_DIAS = result[i++].Value?.ToString();

            return dta;
        }

    }
}