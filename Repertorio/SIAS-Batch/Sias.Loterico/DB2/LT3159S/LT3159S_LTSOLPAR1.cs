using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3159S
{
    public class LT3159S_LTSOLPAR1 : QueryBasis<LT3159S_LTSOLPAR1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public LT3159S_LTSOLPAR1() { IsCursor = true; }

        public LT3159S_LTSOLPAR1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string LTSOLPAR_PARAM_SMINT01 { get; set; }
        public string LTSOLPAR_PARAM_SMINT03 { get; set; }
        public string LTSOLPAR_PARAM_INTG01 { get; set; }
        public string LTSOLPAR_PARAM_CHAR01 { get; set; }
        public string LTSOLPAR_PARAM_CHAR04 { get; set; }
        public string LTSOLPAR_PARAM_DATE01 { get; set; }
        public string LTSOLPAR_PARAM_DATE02 { get; set; }
        public string LTSOLPAR_PARAM_DATE03 { get; set; }

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


        public override LT3159S_LTSOLPAR1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new LT3159S_LTSOLPAR1();
            var i = 0;

            dta.LTSOLPAR_PARAM_SMINT01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_SMINT03 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_INTG01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_CHAR01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_CHAR04 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_DATE01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_DATE02 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_DATE03 = result[i++].Value?.ToString();

            return dta;
        }

    }
}