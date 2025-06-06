using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6017B
{
    public class BI6017B_MOVDEBCC : QueryBasis<BI6017B_MOVDEBCC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI6017B_MOVDEBCC() { IsCursor = true; }

        public BI6017B_MOVDEBCC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVDEBCE_NUM_APOLICE { get; set; }

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


        public override BI6017B_MOVDEBCC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI6017B_MOVDEBCC();
            var i = 0;

            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();

            return dta;
        }

    }
}