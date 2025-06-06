using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0120B
{
    public class EM0120B_V1EMISDIA : QueryBasis<EM0120B_V1EMISDIA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0120B_V1EMISDIA() { IsCursor = true; }

        public EM0120B_V1EMISDIA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1EDIA_NUM_APOL { get; set; }
        public string V1EDIA_NRENDOS { get; set; }

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


        public override EM0120B_V1EMISDIA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0120B_V1EMISDIA();
            var i = 0;

            dta.V1EDIA_NUM_APOL = result[i++].Value?.ToString();
            dta.V1EDIA_NRENDOS = result[i++].Value?.ToString();

            return dta;
        }

    }
}