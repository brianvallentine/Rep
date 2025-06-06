using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class EM0006B_V1PROPCLAUSULA : QueryBasis<EM0006B_V1PROPCLAUSULA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0006B_V1PROPCLAUSULA() { IsCursor = true; }

        public EM0006B_V1PROPCLAUSULA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PRCL_COD_EMPRESA { get; set; }
        public string V1PRCL_FONTE { get; set; }
        public string V1PRCL_NRPROPOS { get; set; }
        public string V1PRCL_RAMOFR { get; set; }
        public string V1PRCL_MODALIFR { get; set; }
        public string V1PRCL_CODCOBER { get; set; }
        public string V1PRCL_DTINIVIG { get; set; }
        public string V1PRCL_DTTERVIG { get; set; }
        public string V1PRCL_NRITEM { get; set; }
        public string V1PRCL_CODCLAUS { get; set; }
        public string V1PRCL_LIM_IND_IX { get; set; }
        public string V1PRCL_TIPOCLAU { get; set; }

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


        public override EM0006B_V1PROPCLAUSULA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0006B_V1PROPCLAUSULA();
            var i = 0;

            dta.V1PRCL_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1PRCL_FONTE = result[i++].Value?.ToString();
            dta.V1PRCL_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PRCL_RAMOFR = result[i++].Value?.ToString();
            dta.V1PRCL_MODALIFR = result[i++].Value?.ToString();
            dta.V1PRCL_CODCOBER = result[i++].Value?.ToString();
            dta.V1PRCL_DTINIVIG = result[i++].Value?.ToString();
            dta.V1PRCL_DTTERVIG = result[i++].Value?.ToString();
            dta.V1PRCL_NRITEM = result[i++].Value?.ToString();
            dta.V1PRCL_CODCLAUS = result[i++].Value?.ToString();
            dta.V1PRCL_LIM_IND_IX = result[i++].Value?.ToString();
            dta.V1PRCL_TIPOCLAU = result[i++].Value?.ToString();

            return dta;
        }

    }
}