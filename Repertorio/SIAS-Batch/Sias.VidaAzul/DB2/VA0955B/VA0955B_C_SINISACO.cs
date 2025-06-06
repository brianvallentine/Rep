using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0955B
{
    public class VA0955B_C_SINISACO : QueryBasis<VA0955B_C_SINISACO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0955B_C_SINISACO() { IsCursor = true; }

        public VA0955B_C_SINISACO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CODIGOPE_COD_OPERACAO { get; set; }
        public string CODIGOPE_DESCR_OPERACAO { get; set; }

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


        public override VA0955B_C_SINISACO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0955B_C_SINISACO();
            var i = 0;

            dta.CODIGOPE_COD_OPERACAO = result[i++].Value?.ToString();
            dta.CODIGOPE_DESCR_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}