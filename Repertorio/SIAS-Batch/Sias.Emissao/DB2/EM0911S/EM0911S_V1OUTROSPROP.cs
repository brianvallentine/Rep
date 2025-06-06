using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0911S
{
    public class EM0911S_V1OUTROSPROP : QueryBasis<EM0911S_V1OUTROSPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0911S_V1OUTROSPROP() { IsCursor = true; }

        public EM0911S_V1OUTROSPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PROU_COD_EMPRESA { get; set; }
        public string V1PROU_FONTE { get; set; }
        public string V1PROU_NRPROPOS { get; set; }
        public string V1PROU_NRRISCO { get; set; }
        public string V1PROU_CODCLIEN { get; set; }
        public string V1PROU_OCORR_END { get; set; }
        public string V1PROU_PROPRIET { get; set; }
        public string V1PROU_COD_LOGRAD { get; set; }

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


        public override EM0911S_V1OUTROSPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0911S_V1OUTROSPROP();
            var i = 0;

            dta.V1PROU_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1PROU_FONTE = result[i++].Value?.ToString();
            dta.V1PROU_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PROU_NRRISCO = result[i++].Value?.ToString();
            dta.V1PROU_CODCLIEN = result[i++].Value?.ToString();
            dta.V1PROU_OCORR_END = result[i++].Value?.ToString();
            dta.V1PROU_PROPRIET = result[i++].Value?.ToString();
            dta.V1PROU_COD_LOGRAD = result[i++].Value?.ToString();

            return dta;
        }

    }
}