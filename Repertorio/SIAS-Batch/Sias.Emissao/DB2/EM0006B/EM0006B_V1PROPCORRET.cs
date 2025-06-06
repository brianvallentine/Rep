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
    public class EM0006B_V1PROPCORRET : QueryBasis<EM0006B_V1PROPCORRET>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0006B_V1PROPCORRET() { IsCursor = true; }

        public EM0006B_V1PROPCORRET(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PCOR_FONTE { get; set; }
        public string V1PCOR_NRPROPOS { get; set; }
        public string V1PCOR_RAMOFR { get; set; }
        public string V1PCOR_MODALIFR { get; set; }
        public string V1PCOR_CODCORR { get; set; }
        public string V1PCOR_PCPARCOR { get; set; }
        public string V1PCOR_PCCOMCOR { get; set; }
        public string V1PCOR_INDCRT { get; set; }
        public string V1PCOR_COD_USUARIO { get; set; }

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


        public override EM0006B_V1PROPCORRET OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0006B_V1PROPCORRET();
            var i = 0;

            dta.V1PCOR_FONTE = result[i++].Value?.ToString();
            dta.V1PCOR_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PCOR_RAMOFR = result[i++].Value?.ToString();
            dta.V1PCOR_MODALIFR = result[i++].Value?.ToString();
            dta.V1PCOR_CODCORR = result[i++].Value?.ToString();
            dta.V1PCOR_PCPARCOR = result[i++].Value?.ToString();
            dta.V1PCOR_PCCOMCOR = result[i++].Value?.ToString();
            dta.V1PCOR_INDCRT = result[i++].Value?.ToString();
            dta.V1PCOR_COD_USUARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}