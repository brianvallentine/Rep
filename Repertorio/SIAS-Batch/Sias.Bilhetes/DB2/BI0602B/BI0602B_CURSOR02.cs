using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0602B
{
    public class BI0602B_CURSOR02 : QueryBasis<BI0602B_CURSOR02>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0602B_CURSOR02() { IsCursor = true; }

        public BI0602B_CURSOR02(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_SITUAC_CEF { get; set; }
        public string WIND_NULL1 { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_TIMESTAMP { get; set; }

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


        public override BI0602B_CURSOR02 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0602B_CURSOR02();
            var i = 0;

            dta.WS_SITUAC_CEF = result[i++].Value?.ToString();
            dta.WIND_NULL1 = string.IsNullOrWhiteSpace(dta.WS_SITUAC_CEF) ? "-1" : "0";
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_TIMESTAMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}