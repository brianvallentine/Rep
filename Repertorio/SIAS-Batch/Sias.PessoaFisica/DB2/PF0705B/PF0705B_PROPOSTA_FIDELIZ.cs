using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0705B
{
    public class PF0705B_PROPOSTA_FIDELIZ : QueryBasis<PF0705B_PROPOSTA_FIDELIZ>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0705B_PROPOSTA_FIDELIZ() { IsCursor = true; }

        public PF0705B_PROPOSTA_FIDELIZ(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
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
        public string PROPOFID_NSL { get; set; }
        public string PROPOFID_NSAC_SIVPF { get; set; }
        public string PROPOFID_SITUACAO_ENVIO { get; set; }

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


        public override PF0705B_PROPOSTA_FIDELIZ OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0705B_PROPOSTA_FIDELIZ();
            var i = 0;

            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PESSOA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_SICOB = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
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
            dta.PROPOFID_NSL = result[i++].Value?.ToString();
            dta.PROPOFID_NSAC_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_SITUACAO_ENVIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}