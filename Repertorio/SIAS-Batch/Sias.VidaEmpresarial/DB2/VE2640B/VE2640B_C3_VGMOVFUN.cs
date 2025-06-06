using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class VE2640B_C3_VGMOVFUN : QueryBasis<VE2640B_C3_VGMOVFUN>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE2640B_C3_VGMOVFUN() { IsCursor = true; }

        public VE2640B_C3_VGMOVFUN(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGMOVFUN_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGMOVFUN_DTH_INI_VIGENCIA { get; set; }
        public string VGMOVFUN_NUM_CPF { get; set; }

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


        public override VE2640B_C3_VGMOVFUN OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE2640B_C3_VGMOVFUN();
            var i = 0;

            dta.VGMOVFUN_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.VGMOVFUN_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.VGMOVFUN_NUM_CPF = result[i++].Value?.ToString();

            return dta;
        }

    }
}