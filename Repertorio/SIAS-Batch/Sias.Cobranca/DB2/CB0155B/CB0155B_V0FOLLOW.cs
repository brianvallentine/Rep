using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0155B
{
    public class CB0155B_V0FOLLOW : QueryBasis<CB0155B_V0FOLLOW>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0155B_V0FOLLOW() { IsCursor = true; }

        public CB0155B_V0FOLLOW(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FOLLOUP_BCO_AVISO { get; set; }
        public string FOLLOUP_AGE_AVISO { get; set; }
        public string FOLLOUP_NUM_AVISO_CREDITO { get; set; }
        public string FOLLOUP_VAL_OPERACAO { get; set; }

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


        public override CB0155B_V0FOLLOW OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0155B_V0FOLLOW();
            var i = 0;

            dta.FOLLOUP_BCO_AVISO = result[i++].Value?.ToString();
            dta.FOLLOUP_AGE_AVISO = result[i++].Value?.ToString();
            dta.FOLLOUP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.FOLLOUP_VAL_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}