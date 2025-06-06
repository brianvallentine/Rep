using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI5166B
{
    public class BI5166B_V0BILHEERR : QueryBasis<BI5166B_V0BILHEERR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI5166B_V0BILHEERR() { IsCursor = true; }

        public BI5166B_V0BILHEERR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BILHEERR_COD_ERRO { get; set; }

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


        public override BI5166B_V0BILHEERR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI5166B_V0BILHEERR();
            var i = 0;

            dta.BILHEERR_COD_ERRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}