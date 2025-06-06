using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class FN0301B_V1OUTRCOBER : QueryBasis<FN0301B_V1OUTRCOBER>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FN0301B_V1OUTRCOBER() { IsCursor = true; }

        public FN0301B_V1OUTRCOBER(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1OCOB_NRRISCO { get; set; }
        public string V1OCOB_RAMOFR { get; set; }
        public string V1OCOB_CODCOBER { get; set; }
        public string V1OCOB_DTINIVIG { get; set; }
        public string V1OCOB_DTTERVIG { get; set; }
        public string V1OCOB_IMP_SEG_IX { get; set; }
        public string V1OCOB_PRM_TAR_VAR { get; set; }
        public string V1OCOB_VRFROBR_IX { get; set; }
        public string V1OCOB_LIMINDENIZ { get; set; }

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


        public override FN0301B_V1OUTRCOBER OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FN0301B_V1OUTRCOBER();
            var i = 0;

            dta.V1OCOB_NRRISCO = result[i++].Value?.ToString();
            dta.V1OCOB_RAMOFR = result[i++].Value?.ToString();
            dta.V1OCOB_CODCOBER = result[i++].Value?.ToString();
            dta.V1OCOB_DTINIVIG = result[i++].Value?.ToString();
            dta.V1OCOB_DTTERVIG = result[i++].Value?.ToString();
            dta.V1OCOB_IMP_SEG_IX = result[i++].Value?.ToString();
            dta.V1OCOB_PRM_TAR_VAR = result[i++].Value?.ToString();
            dta.V1OCOB_VRFROBR_IX = result[i++].Value?.ToString();
            dta.V1OCOB_LIMINDENIZ = result[i++].Value?.ToString();

            return dta;
        }

    }
}