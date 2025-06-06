using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0715B
{
    public class PF0715B_TER_NIVEL : QueryBasis<PF0715B_TER_NIVEL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0715B_TER_NIVEL() { IsCursor = true; }

        public PF0715B_TER_NIVEL(bool justACursor)
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


        public override PF0715B_TER_NIVEL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0715B_TER_NIVEL();
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