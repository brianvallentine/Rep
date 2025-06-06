using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0029B
{
    public class VE0029B_V0PENDENTE : QueryBasis<VE0029B_V0PENDENTE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0029B_V0PENDENTE() { IsCursor = true; }

        public VE0029B_V0PENDENTE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PEND_NUM_APOL { get; set; }
        public string V0PEND_COD_SUBG { get; set; }
        public string V0PEND_NRENDOS { get; set; }
        public string V0PEND_DTVENCTO { get; set; }
        public string VIND_DTVENCTO { get; set; }

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


        public override VE0029B_V0PENDENTE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0029B_V0PENDENTE();
            var i = 0;

            dta.V0PEND_NUM_APOL = result[i++].Value?.ToString();
            dta.V0PEND_COD_SUBG = result[i++].Value?.ToString();
            dta.V0PEND_NRENDOS = result[i++].Value?.ToString();
            dta.V0PEND_DTVENCTO = result[i++].Value?.ToString();
            dta.VIND_DTVENCTO = string.IsNullOrWhiteSpace(dta.V0PEND_DTVENCTO) ? "-1" : "0";

            return dta;
        }

    }
}