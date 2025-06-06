using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class VA0128B_VGHISRAMC : QueryBasis<VA0128B_VGHISRAMC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0128B_VGHISRAMC() { IsCursor = true; }

        public VA0128B_VGHISRAMC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGHISR_NRCERTIF { get; set; }
        public string VGHISR_NUM_RAMO { get; set; }
        public string VGHISR_NUM_COBERTURA { get; set; }
        public string VGHISR_QTD_COBERTURA { get; set; }
        public string VGHISR_IMPSEGURADA { get; set; }
        public string VGHISR_CUSTO { get; set; }
        public string VGHISR_PREMIO { get; set; }

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


        public override VA0128B_VGHISRAMC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0128B_VGHISRAMC();
            var i = 0;

            dta.VGHISR_NRCERTIF = result[i++].Value?.ToString();
            dta.VGHISR_NUM_RAMO = result[i++].Value?.ToString();
            dta.VGHISR_NUM_COBERTURA = result[i++].Value?.ToString();
            dta.VGHISR_QTD_COBERTURA = result[i++].Value?.ToString();
            dta.VGHISR_IMPSEGURADA = result[i++].Value?.ToString();
            dta.VGHISR_CUSTO = result[i++].Value?.ToString();
            dta.VGHISR_PREMIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}