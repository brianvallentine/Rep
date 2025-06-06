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
    public class EM0006B_V1PROPOUTR : QueryBasis<EM0006B_V1PROPOUTR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0006B_V1PROPOUTR() { IsCursor = true; }

        public EM0006B_V1PROPOUTR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PROU_COD_EMPRESA { get; set; }
        public string V1PROU_FONTE { get; set; }
        public string V1PROU_NRPROPOS { get; set; }
        public string V1PROU_APOLIDER { get; set; }
        public string V1PROU_CODLIDER { get; set; }
        public string V1PROU_IMP_SEG_IX { get; set; }

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


        public override EM0006B_V1PROPOUTR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0006B_V1PROPOUTR();
            var i = 0;

            dta.V1PROU_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1PROU_FONTE = result[i++].Value?.ToString();
            dta.V1PROU_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PROU_APOLIDER = result[i++].Value?.ToString();
            dta.V1PROU_CODLIDER = result[i++].Value?.ToString();
            dta.V1PROU_IMP_SEG_IX = result[i++].Value?.ToString();

            return dta;
        }

    }
}