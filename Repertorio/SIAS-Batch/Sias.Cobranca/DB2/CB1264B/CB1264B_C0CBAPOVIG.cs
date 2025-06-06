using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1264B
{
    public class CB1264B_C0CBAPOVIG : QueryBasis<CB1264B_C0CBAPOVIG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB1264B_C0CBAPOVIG() { IsCursor = true; }

        public CB1264B_C0CBAPOVIG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CBAPOVIG_NUM_APOLICE { get; set; }

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


        public override CB1264B_C0CBAPOVIG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB1264B_C0CBAPOVIG();
            var i = 0;

            dta.CBAPOVIG_NUM_APOLICE = result[i++].Value?.ToString();

            return dta;
        }

    }
}