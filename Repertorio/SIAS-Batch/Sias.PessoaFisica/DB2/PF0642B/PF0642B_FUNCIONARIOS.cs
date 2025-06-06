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
    public class PF0642B_FUNCIONARIOS : QueryBasis<PF0642B_FUNCIONARIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0642B_FUNCIONARIOS() { IsCursor = true; }

        public PF0642B_FUNCIONARIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGMOVFUN_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGMOVFUN_DTH_INI_VIGENCIA { get; set; }
        public string VGMOVFUN_NUM_CPF { get; set; }
        public string VGMOVFUN_DTH_FIM_VIGENCIA { get; set; }
        public string VGMOVFUN_NUM_NIVEL_CARGO { get; set; }
        public string VGMOVFUN_NUM_MATRICULA { get; set; }
        public string VGMOVFUN_NOM_FUNCIONARIO { get; set; }
        public string VGMOVFUN_DTH_NASCIMENTO { get; set; }
        public string VGMOVFUN_NUM_IDADE { get; set; }
        public string VGMOVFUN_STA_SEXO { get; set; }
        public string VGMOVFUN_STA_ESTADO_CIVIL { get; set; }
        public string VGMOVFUN_COD_PROFISSAO { get; set; }
        public string VGMOVFUN_IND_REPR_EMPRE { get; set; }
        public string VGMOVFUN_IND_IMP_DPS { get; set; }
        public string VGMOVFUN_DES_MOTIVO { get; set; }
        public string VGMOVFUN_NUM_DDD { get; set; }
        public string VGMOVFUN_NUM_TELEFONE { get; set; }
        public string VGMOVFUN_NUM_RG { get; set; }
        public string VGMOVFUN_COD_ORGAO_RG { get; set; }
        public string VGMOVFUN_COD_UF_ORGAO_RG { get; set; }
        public string VGMOVFUN_DTH_EMISSAO_RG { get; set; }
        public string VGMOVFUN_STA_FUNCIONARIO { get; set; }
        public string VGMOVFUN_COD_USUARIO { get; set; }

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


        public override PF0642B_FUNCIONARIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0642B_FUNCIONARIOS();
            var i = 0;

            dta.VGMOVFUN_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.VGMOVFUN_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.VGMOVFUN_NUM_CPF = result[i++].Value?.ToString();
            dta.VGMOVFUN_DTH_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.VGMOVFUN_NUM_NIVEL_CARGO = result[i++].Value?.ToString();
            dta.VGMOVFUN_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.VGMOVFUN_NOM_FUNCIONARIO = result[i++].Value?.ToString();
            dta.VGMOVFUN_DTH_NASCIMENTO = result[i++].Value?.ToString();
            dta.VGMOVFUN_NUM_IDADE = result[i++].Value?.ToString();
            dta.VGMOVFUN_STA_SEXO = result[i++].Value?.ToString();
            dta.VGMOVFUN_STA_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.VGMOVFUN_COD_PROFISSAO = result[i++].Value?.ToString();
            dta.VGMOVFUN_IND_REPR_EMPRE = result[i++].Value?.ToString();
            dta.VGMOVFUN_IND_IMP_DPS = result[i++].Value?.ToString();
            dta.VGMOVFUN_DES_MOTIVO = result[i++].Value?.ToString();
            dta.VGMOVFUN_NUM_DDD = result[i++].Value?.ToString();
            dta.VGMOVFUN_NUM_TELEFONE = result[i++].Value?.ToString();
            dta.VGMOVFUN_NUM_RG = result[i++].Value?.ToString();
            dta.VGMOVFUN_COD_ORGAO_RG = result[i++].Value?.ToString();
            dta.VGMOVFUN_COD_UF_ORGAO_RG = result[i++].Value?.ToString();
            dta.VGMOVFUN_DTH_EMISSAO_RG = result[i++].Value?.ToString();
            dta.VGMOVFUN_STA_FUNCIONARIO = result[i++].Value?.ToString();
            dta.VGMOVFUN_COD_USUARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}