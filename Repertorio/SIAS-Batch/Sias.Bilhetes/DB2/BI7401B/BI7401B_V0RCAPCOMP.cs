using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class BI7401B_V0RCAPCOMP : QueryBasis<BI7401B_V0RCAPCOMP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI7401B_V0RCAPCOMP() { IsCursor = true; }

        public BI7401B_V0RCAPCOMP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RCAPCOMP_COD_FONTE { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }
        public string RCAPCOMP_NUM_RCAP_COMPLEMEN { get; set; }
        public string HOST_COUNT { get; set; }

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


        public override BI7401B_V0RCAPCOMP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI7401B_V0RCAPCOMP();
            var i = 0;

            dta.RCAPCOMP_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_RCAP_COMPLEMEN = result[i++].Value?.ToString();
            dta.HOST_COUNT = result[i++].Value?.ToString();

            return dta;
        }

    }
}