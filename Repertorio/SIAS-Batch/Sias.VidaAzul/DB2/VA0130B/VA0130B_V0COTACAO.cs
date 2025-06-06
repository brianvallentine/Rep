using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class VA0130B_V0COTACAO : QueryBasis<VA0130B_V0COTACAO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0130B_V0COTACAO() { IsCursor = true; }

        public VA0130B_V0COTACAO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string COTACAO_DTINIVIG { get; set; }
        public string COTACAO_VAL_VENDA { get; set; }

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


        public override VA0130B_V0COTACAO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0130B_V0COTACAO();
            var i = 0;

            dta.COTACAO_DTINIVIG = result[i++].Value?.ToString();
            dta.COTACAO_VAL_VENDA = result[i++].Value?.ToString();

            return dta;
        }

    }
}