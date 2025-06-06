using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4004B
{
    public class VA4004B_CERROSP : QueryBasis<VA4004B_CERROSP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA4004B_CERROSP() { IsCursor = true; }

        public VA4004B_CERROSP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_DESCR_ERRO { get; set; }

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


        public override VA4004B_CERROSP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA4004B_CERROSP();
            var i = 0;

            dta.WS_DESCR_ERRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}