using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class VA0601B_CPROPOSTA : QueryBasis<VA0601B_CPROPOSTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0601B_CPROPOSTA() { IsCursor = true; }

        public VA0601B_CPROPOSTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE { get; set; }
        public string DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO { get; set; }
        public string DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO { get; set; }
        public string DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR { get; set; }
        public string DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE { get; set; }
        public string DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ { get; set; }
        public string PROPSSVD_NUM_CONTR_VINCULO { get; set; }
        public string VIND_NUM_CONTR { get; set; }
        public string PROPSSVD_COD_CORRESP_BANC { get; set; }
        public string VIND_COD_CORRESP { get; set; }
        public string PROPSSVD_NUM_PRAZO_FIN { get; set; }
        public string VIND_NUM_PRAZO { get; set; }
        public string PROPSSVD_COD_OPER_CREDITO { get; set; }
        public string VIND_COD_OPER_CRED { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO { get; set; }
        public string DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NSL { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE { get; set; }
        public string VIND_NOME_CONJUGE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE { get; set; }
        public string VIND_DATA_NASC_CONJUGE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE { get; set; }
        public string VIND_PROFISSAO_CONJUGE { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND { get; set; }
        public string VIND_RENDA_FIXA_IND { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM { get; set; }
        public string VIND_RENDA_FIXA_FAM { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA { get; set; }
        public string VIND_TP_PROPOSTA { get; set; }
        public string DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TIPO_CONTA { get; set; }
        public string VIND_TP_CONTA { get; set; }
        public string DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO { get; set; }
        public string DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO { get; set; }
        public string DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO { get; set; }
        public string DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO { get; set; }
        public string WHOST_RAMO { get; set; }

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


        public override VA0601B_CPROPOSTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0601B_CPROPOSTA();
            var i = 0;

            dta.DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE = result[i++].Value?.ToString();
            dta.DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR = result[i++].Value?.ToString();
            dta.DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE = result[i++].Value?.ToString();
            dta.DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ = result[i++].Value?.ToString();
            dta.PROPSSVD_NUM_CONTR_VINCULO = result[i++].Value?.ToString();
            dta.VIND_NUM_CONTR = string.IsNullOrWhiteSpace(dta.PROPSSVD_NUM_CONTR_VINCULO) ? "-1" : "0";
            dta.PROPSSVD_COD_CORRESP_BANC = result[i++].Value?.ToString();
            dta.VIND_COD_CORRESP = string.IsNullOrWhiteSpace(dta.PROPSSVD_COD_CORRESP_BANC) ? "-1" : "0";
            dta.PROPSSVD_NUM_PRAZO_FIN = result[i++].Value?.ToString();
            dta.VIND_NUM_PRAZO = string.IsNullOrWhiteSpace(dta.PROPSSVD_NUM_PRAZO_FIN) ? "-1" : "0";
            dta.PROPSSVD_COD_OPER_CREDITO = result[i++].Value?.ToString();
            dta.VIND_COD_OPER_CRED = string.IsNullOrWhiteSpace(dta.PROPSSVD_COD_OPER_CREDITO) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO = result[i++].Value?.ToString();
            dta.DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NSL = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_NOME_CONJUGE = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_DATA_NASC_CONJUGE = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_PROFISSAO_CONJUGE = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_RENDA_FIXA_IND = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_RENDA_FIXA_FAM = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA = result[i++].Value?.ToString();
            dta.VIND_TP_PROPOSTA = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA) ? "-1" : "0";
            dta.DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TIPO_CONTA = result[i++].Value?.ToString();
            dta.VIND_TP_CONTA = string.IsNullOrWhiteSpace(dta.DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TIPO_CONTA) ? "-1" : "0";
            dta.DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO = result[i++].Value?.ToString();
            dta.DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            dta.WHOST_RAMO = result[i++].Value?.ToString();

            return dta;
        }

    }
}