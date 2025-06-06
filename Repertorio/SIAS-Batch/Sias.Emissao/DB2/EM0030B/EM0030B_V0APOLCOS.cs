using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class EM0030B_V0APOLCOS : QueryBasis<EM0030B_V0APOLCOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0030B_V0APOLCOS() { IsCursor = true; }

        public EM0030B_V0APOLCOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string COSS_CODCOSS { get; set; }

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


        public override EM0030B_V0APOLCOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0030B_V0APOLCOS();
            var i = 0;

            dta.COSS_CODCOSS = result[i++].Value?.ToString();

            return dta;
        }

    }
}