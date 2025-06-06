using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class BI1630B_CUR_PRO : QueryBasis<BI1630B_CUR_PRO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI1630B_CUR_PRO() { IsCursor = true; }

        public BI1630B_CUR_PRO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPSSBI_RENOVACAO_AUTOM { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_AGECOBR { get; set; }
        public string PROPOFID_DIA_DEBITO { get; set; }
        public string PROPOFID_OPCAOPAG { get; set; }
        public string PROPOFID_AGECTADEB { get; set; }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string PROPOFID_NUMCTADEB { get; set; }
        public string PROPOFID_DIGCTADEB { get; set; }
        public string PROPOFID_PERC_DESCONTO { get; set; }
        public string PROPOFID_NRMATRVEN { get; set; }
        public string PROPOFID_AGECTAVEN { get; set; }
        public string PROPOFID_OPRCTAVEN { get; set; }
        public string PROPOFID_NUMCTAVEN { get; set; }
        public string PROPOFID_DIGCTAVEN { get; set; }
        public string PROPOFID_CGC_CONVENENTE { get; set; }
        public string PROPOFID_NOME_CONVENENTE { get; set; }
        public string PROPOFID_NRMATRCON { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string PROPOFID_AGEPGTO { get; set; }
        public string PROPOFID_VAL_TARIFA { get; set; }
        public string PROPOFID_VAL_IOF { get; set; }
        public string PROPOFID_DATA_CREDITO { get; set; }
        public string PROPOFID_VAL_COMISSAO { get; set; }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_COD_USUARIO { get; set; }
        public string PROPOFID_CANAL_PROPOSTA { get; set; }
        public string PROPOFID_NSAS_SIVPF { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_TIMESTAMP { get; set; }
        public string PROPOFID_NSL { get; set; }
        public string PROPOFID_NSAC_SIVPF { get; set; }
        public string PROPOFID_NOME_CONJUGE { get; set; }
        public string VIND_NULL01 { get; set; }
        public string PROPOFID_DATA_NASC_CONJUGE { get; set; }
        public string VIND_NULL02 { get; set; }
        public string PROPOFID_PROFISSAO_CONJUGE { get; set; }
        public string VIND_NULL03 { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string PROPOFID_FAIXA_RENDA_IND { get; set; }
        public string VIND_NULL04 { get; set; }
        public string PROPOFID_FAIXA_RENDA_FAM { get; set; }
        public string VIND_NULL05 { get; set; }

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


        public override BI1630B_CUR_PRO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI1630B_CUR_PRO();
            var i = 0;

            dta.PROPSSBI_RENOVACAO_AUTOM = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PESSOA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_SICOB = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_AGECOBR = result[i++].Value?.ToString();
            dta.PROPOFID_DIA_DEBITO = result[i++].Value?.ToString();
            dta.PROPOFID_OPCAOPAG = result[i++].Value?.ToString();
            dta.PROPOFID_AGECTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_OPRCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_NUMCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_DIGCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_PERC_DESCONTO = result[i++].Value?.ToString();
            dta.PROPOFID_NRMATRVEN = result[i++].Value?.ToString();
            dta.PROPOFID_AGECTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_OPRCTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_NUMCTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_DIGCTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_CGC_CONVENENTE = result[i++].Value?.ToString();
            dta.PROPOFID_NOME_CONVENENTE = result[i++].Value?.ToString();
            dta.PROPOFID_NRMATRCON = result[i++].Value?.ToString();
            dta.PROPOFID_DTQITBCO = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_PAGO = result[i++].Value?.ToString();
            dta.PROPOFID_AGEPGTO = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_TARIFA = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_IOF = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_CREDITO = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_COMISSAO = result[i++].Value?.ToString();
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_COD_USUARIO = result[i++].Value?.ToString();
            dta.PROPOFID_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NSAS_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_TIMESTAMP = result[i++].Value?.ToString();
            dta.PROPOFID_NSL = result[i++].Value?.ToString();
            dta.PROPOFID_NSAC_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NOME_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.PROPOFID_NOME_CONJUGE) ? "-1" : "0";
            dta.PROPOFID_DATA_NASC_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.PROPOFID_DATA_NASC_CONJUGE) ? "-1" : "0";
            dta.PROPOFID_PROFISSAO_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.PROPOFID_PROFISSAO_CONJUGE) ? "-1" : "0";
            dta.PROPOFID_OPCAO_COBER = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PLANO = result[i++].Value?.ToString();
            dta.PROPOFID_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.PROPOFID_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.PROPOFID_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_NULL05 = string.IsNullOrWhiteSpace(dta.PROPOFID_FAIXA_RENDA_FAM) ? "-1" : "0";

            return dta;
        }

    }
}