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
    public class EM0911S_V1BENSCOBERPROP : QueryBasis<EM0911S_V1BENSCOBERPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0911S_V1BENSCOBERPROP() { IsCursor = true; }

        public EM0911S_V1BENSCOBERPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PRBC_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V1PRBC_FONTE { get; set; }
        public string V1PRBC_NRPROPOS { get; set; }
        public string V1PRBC_NRRISCO { get; set; }
        public string V1PRBC_COD_COBER { get; set; }
        public string V1PRBC_NRBEM { get; set; }

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


        public override EM0911S_V1BENSCOBERPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0911S_V1BENSCOBERPROP();
            var i = 0;

            dta.V1PRBC_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMP = string.IsNullOrWhiteSpace(dta.V1PRBC_COD_EMPRESA) ? "-1" : "0";
            dta.V1PRBC_FONTE = result[i++].Value?.ToString();
            dta.V1PRBC_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PRBC_NRRISCO = result[i++].Value?.ToString();
            dta.V1PRBC_COD_COBER = result[i++].Value?.ToString();
            dta.V1PRBC_NRBEM = result[i++].Value?.ToString();

            return dta;
        }

    }
}