using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3118B
{
    public class VA3118B_CURSOR01 : QueryBasis<VA3118B_CURSOR01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA3118B_CURSOR01() { IsCursor = true; }

        public VA3118B_CURSOR01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WHOST_COD_ERRO { get; set; }

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


        public override VA3118B_CURSOR01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA3118B_CURSOR01();
            var i = 0;

            dta.WHOST_COD_ERRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}