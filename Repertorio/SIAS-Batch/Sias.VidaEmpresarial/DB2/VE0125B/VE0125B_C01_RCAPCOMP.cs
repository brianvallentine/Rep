using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0125B
{
    public class VE0125B_C01_RCAPCOMP : QueryBasis<VE0125B_C01_RCAPCOMP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0125B_C01_RCAPCOMP() { IsCursor = true; }

        public VE0125B_C01_RCAPCOMP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO { get; set; }
        public string DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO { get; set; }
        public string DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO { get; set; }
        public string DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP { get; set; }
        public string DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO { get; set; }

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


        public override VE0125B_C01_RCAPCOMP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0125B_C01_RCAPCOMP();
            var i = 0;

            dta.DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO = result[i++].Value?.ToString();
            dta.DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO = result[i++].Value?.ToString();
            dta.DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP = result[i++].Value?.ToString();
            dta.DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}