using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0642B
{
    public class PF0642B_COBERFUNC : QueryBasis<PF0642B_COBERFUNC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0642B_COBERFUNC() { IsCursor = true; }

        public PF0642B_COBERFUNC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGFUNCOB_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGFUNCOB_DTH_INI_VIGENCIA { get; set; }
        public string VGFUNCOB_NUM_CPF { get; set; }
        public string VGFUNCOB_COD_GARANTIA { get; set; }
        public string VGFUNCOB_IMP_SEGURADA { get; set; }
        public string VGFUNCOB_VLR_PREMIO { get; set; }
        public string VGFUNCOB_VLR_TAXA_CALC_PRM { get; set; }
        public string VGMOVFUN_NUM_MATRICULA { get; set; }

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


        public override PF0642B_COBERFUNC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0642B_COBERFUNC();
            var i = 0;

            dta.VGFUNCOB_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.VGFUNCOB_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.VGFUNCOB_NUM_CPF = result[i++].Value?.ToString();
            dta.VGFUNCOB_COD_GARANTIA = result[i++].Value?.ToString();
            dta.VGFUNCOB_IMP_SEGURADA = result[i++].Value?.ToString();
            dta.VGFUNCOB_VLR_PREMIO = result[i++].Value?.ToString();
            dta.VGFUNCOB_VLR_TAXA_CALC_PRM = result[i++].Value?.ToString();
            dta.VGMOVFUN_NUM_MATRICULA = result[i++].Value?.ToString();

            return dta;
        }

    }
}