using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class PF0002B_V0BILCOBER : QueryBasis<PF0002B_V0BILCOBER>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0002B_V0BILCOBER() { IsCursor = true; }

        public PF0002B_V0BILCOBER(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0BCOB_RAMOFR { get; set; }
        public string V0BCOB_CODOPCAO { get; set; }
        public string V0BCOB_VLPRMTAR { get; set; }
        public string V0BCOB_VLPRMTOT { get; set; }
        public string VIND_VLPRMTOT { get; set; }
        public string V0BCOB_PCIOCC { get; set; }
        public string VIND_PCIOCC { get; set; }

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


        public override PF0002B_V0BILCOBER OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0002B_V0BILCOBER();
            var i = 0;

            dta.V0BCOB_RAMOFR = result[i++].Value?.ToString();
            dta.V0BCOB_CODOPCAO = result[i++].Value?.ToString();
            dta.V0BCOB_VLPRMTAR = result[i++].Value?.ToString();
            dta.V0BCOB_VLPRMTOT = result[i++].Value?.ToString();
            dta.VIND_VLPRMTOT = string.IsNullOrWhiteSpace(dta.V0BCOB_VLPRMTOT) ? "-1" : "0";
            dta.V0BCOB_PCIOCC = result[i++].Value?.ToString();
            dta.VIND_PCIOCC = string.IsNullOrWhiteSpace(dta.V0BCOB_PCIOCC) ? "-1" : "0";

            return dta;
        }

    }
}