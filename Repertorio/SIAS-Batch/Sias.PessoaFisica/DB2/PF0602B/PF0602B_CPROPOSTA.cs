using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class PF0602B_CPROPOSTA : QueryBasis<PF0602B_CPROPOSTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0602B_CPROPOSTA() { IsCursor = true; }

        public PF0602B_CPROPOSTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLPROP_SASSE_BILHETE_PROPSSBI_RENOVACAO_AUTOM { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_COD_PESSOA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NUM_SICOB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_AGECOBR { get; set; }
        public string DCLPROPOSTA_FIDELIZ_DIA_DEBITO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_OPCAOPAG { get; set; }
        public string DCLPROPOSTA_FIDELIZ_AGECTADEB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_OPRCTADEB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NUMCTADEB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_DIGCTADEB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PERC_DESCONTO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NRMATRVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_AGECTAVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_OPRCTAVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NUMCTAVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_DIGCTAVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NRMATRCON { get; set; }
        public string DCLPROPOSTA_FIDELIZ_DTQITBCO { get; set; }
        public string WHOST_DTPROXVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_VAL_PAGO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_AGEPGTO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_VAL_TARIFA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_VAL_IOF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_DATA_CREDITO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_VAL_COMISSAO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_COD_USUARIO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NSAS_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_TIMESTAMP { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NSL { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NSAC_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NOME_CONJUGE { get; set; }
        public string VIND_NOME_CONJUGE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_DATA_NASC_CONJUGE { get; set; }
        public string VIND_DATA_NASC_CONJUGE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROFISSAO_CONJUGE { get; set; }
        public string VIND_PROFISSAO_CONJUGE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_OPCAO_COBER { get; set; }
        public string DCLPROPOSTA_FIDELIZ_COD_PLANO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_IND { get; set; }
        public string VIND_FAIXA_RENDA_IND { get; set; }
        public string DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_FAM { get; set; }
        public string VIND_FAIXA_RENDA_FAM { get; set; }

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


        public override PF0602B_CPROPOSTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0602B_CPROPOSTA();
            var i = 0;

            dta.DCLPROP_SASSE_BILHETE_PROPSSBI_RENOVACAO_AUTOM = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_COD_PESSOA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NUM_SICOB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_AGECOBR = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_DIA_DEBITO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_OPCAOPAG = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_AGECTADEB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_OPRCTADEB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NUMCTADEB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_DIGCTADEB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PERC_DESCONTO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NRMATRVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_AGECTAVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_OPRCTAVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NUMCTAVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_DIGCTAVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NRMATRCON = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_DTQITBCO = result[i++].Value?.ToString();
            dta.WHOST_DTPROXVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_VAL_PAGO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_AGEPGTO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_VAL_TARIFA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_VAL_IOF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_DATA_CREDITO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_VAL_COMISSAO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_COD_USUARIO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NSAS_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_TIMESTAMP = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NSL = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NSAC_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NOME_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_NOME_CONJUGE = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_NOME_CONJUGE) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_DATA_NASC_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_DATA_NASC_CONJUGE = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_DATA_NASC_CONJUGE) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_PROFISSAO_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_PROFISSAO_CONJUGE = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_PROFISSAO_CONJUGE) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_OPCAO_COBER = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_COD_PLANO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_IND = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_FAM = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_FAM) ? "-1" : "0";

            return dta;
        }

    }
}