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
    public class EM0006B_V1PROPDESCO : QueryBasis<EM0006B_V1PROPDESCO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0006B_V1PROPDESCO() { IsCursor = true; }

        public EM0006B_V1PROPDESCO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PIND_COD_EMPRESA { get; set; }
        public string V1PIND_FONTE { get; set; }
        public string V1PIND_NRPROPOS { get; set; }
        public string V1PIND_NUM_RISCO { get; set; }
        public string V1PIND_SUBRIS { get; set; }
        public string V1PIND_NRITEM { get; set; }
        public string V1PIND_PLANTA { get; set; }
        public string V1PIND_PCDESPRT { get; set; }
        public string V1PIND_TPDESCON { get; set; }
        public string V1PIND_PCDESTAR { get; set; }
        public string V1PIND_DESCDESCON { get; set; }

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


        public override EM0006B_V1PROPDESCO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0006B_V1PROPDESCO();
            var i = 0;

            dta.V1PIND_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1PIND_FONTE = result[i++].Value?.ToString();
            dta.V1PIND_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PIND_NUM_RISCO = result[i++].Value?.ToString();
            dta.V1PIND_SUBRIS = result[i++].Value?.ToString();
            dta.V1PIND_NRITEM = result[i++].Value?.ToString();
            dta.V1PIND_PLANTA = result[i++].Value?.ToString();
            dta.V1PIND_PCDESPRT = result[i++].Value?.ToString();
            dta.V1PIND_TPDESCON = result[i++].Value?.ToString();
            dta.V1PIND_PCDESTAR = result[i++].Value?.ToString();
            dta.V1PIND_DESCDESCON = result[i++].Value?.ToString();

            return dta;
        }

    }
}