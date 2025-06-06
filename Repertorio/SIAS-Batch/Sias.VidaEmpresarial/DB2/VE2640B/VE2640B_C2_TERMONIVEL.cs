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
    public class VE2640B_C2_TERMONIVEL : QueryBasis<VE2640B_C2_TERMONIVEL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE2640B_C2_TERMONIVEL() { IsCursor = true; }

        public VE2640B_C2_TERMONIVEL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGTERNIV_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGTERNIV_DTH_INI_VIGENCIA { get; set; }
        public string VGTERNIV_NUM_NIVEL_CARGO { get; set; }
        public string VGTERNIV_DTH_FIM_VIGENCIA { get; set; }
        public string VGTERNIV_IMP_SEGURADA { get; set; }
        public string VGTERNIV_VLR_PRM_INDIVIDUAL { get; set; }
        public string VGTERNIV_QTD_VIDAS { get; set; }

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


        public override VE2640B_C2_TERMONIVEL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE2640B_C2_TERMONIVEL();
            var i = 0;

            dta.VGTERNIV_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.VGTERNIV_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.VGTERNIV_NUM_NIVEL_CARGO = result[i++].Value?.ToString();
            dta.VGTERNIV_DTH_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.VGTERNIV_IMP_SEGURADA = result[i++].Value?.ToString();
            dta.VGTERNIV_VLR_PRM_INDIVIDUAL = result[i++].Value?.ToString();
            dta.VGTERNIV_QTD_VIDAS = result[i++].Value?.ToString();

            return dta;
        }

    }
}