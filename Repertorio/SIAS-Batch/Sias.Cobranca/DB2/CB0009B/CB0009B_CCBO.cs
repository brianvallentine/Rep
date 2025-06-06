using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class CB0009B_CCBO : QueryBasis<CB0009B_CCBO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0009B_CCBO() { IsCursor = true; }

        public CB0009B_CCBO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CBO_COD_CBO { get; set; }
        public string CBO_DESCR_CBO { get; set; }

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


        public override CB0009B_CCBO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0009B_CCBO();
            var i = 0;

            dta.CBO_COD_CBO = result[i++].Value?.ToString();
            dta.CBO_DESCR_CBO = result[i++].Value?.ToString();

            return dta;
        }

    }
}