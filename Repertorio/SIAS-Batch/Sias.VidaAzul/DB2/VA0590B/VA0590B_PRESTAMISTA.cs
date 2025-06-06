using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0590B
{
    public class VA0590B_PRESTAMISTA : QueryBasis<VA0590B_PRESTAMISTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0590B_PRESTAMISTA() { IsCursor = true; }

        public VA0590B_PRESTAMISTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_NUM_MATRI_VENDEDOR { get; set; }
        public string PROPOVA_PROFISSAO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_IDE_SEXO { get; set; }
        public string PROPOVA_NOME_ESPOSA { get; set; }
        public string WS_NULL { get; set; }
        public string PROPOVA_DTNASC_ESPOSA { get; set; }
        public string WS_NULL1 { get; set; }
        public string PROPOVA_FAIXA_RENDA_IND { get; set; }
        public string WS_NULL2 { get; set; }
        public string PROPOVA_FAIXA_RENDA_FAM { get; set; }
        public string WS_NULL3 { get; set; }
        public string PROPOVA_NUM_CONTR_VINCULO { get; set; }
        public string WS_NULL4 { get; set; }
        public string PROPOVA_COD_CORRESP_BANC { get; set; }
        public string WS_NULL5 { get; set; }
        public string PROPOVA_COD_ORIGEM_PROPOSTA { get; set; }
        public string WS_NULL6 { get; set; }
        public string PROPOVA_COD_OPER_CREDITO { get; set; }
        public string WS_NULL7 { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string WS_NULL8 { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string WS_FIM_DE_VIGENCIA { get; set; }

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


        public override VA0590B_PRESTAMISTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0590B_PRESTAMISTA();
            var i = 0;

            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_MATRI_VENDEDOR = result[i++].Value?.ToString();
            dta.PROPOVA_PROFISSAO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_IDE_SEXO = result[i++].Value?.ToString();
            dta.PROPOVA_NOME_ESPOSA = result[i++].Value?.ToString();
            dta.WS_NULL = string.IsNullOrWhiteSpace(dta.PROPOVA_NOME_ESPOSA) ? "-1" : "0";
            dta.PROPOVA_DTNASC_ESPOSA = result[i++].Value?.ToString();
            dta.WS_NULL1 = string.IsNullOrWhiteSpace(dta.PROPOVA_DTNASC_ESPOSA) ? "-1" : "0";
            dta.PROPOVA_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.WS_NULL2 = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.PROPOVA_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.WS_NULL3 = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_FAM) ? "-1" : "0";
            dta.PROPOVA_NUM_CONTR_VINCULO = result[i++].Value?.ToString();
            dta.WS_NULL4 = string.IsNullOrWhiteSpace(dta.PROPOVA_NUM_CONTR_VINCULO) ? "-1" : "0";
            dta.PROPOVA_COD_CORRESP_BANC = result[i++].Value?.ToString();
            dta.WS_NULL5 = string.IsNullOrWhiteSpace(dta.PROPOVA_COD_CORRESP_BANC) ? "-1" : "0";
            dta.PROPOVA_COD_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.WS_NULL6 = string.IsNullOrWhiteSpace(dta.PROPOVA_COD_ORIGEM_PROPOSTA) ? "-1" : "0";
            dta.PROPOVA_COD_OPER_CREDITO = result[i++].Value?.ToString();
            dta.WS_NULL7 = string.IsNullOrWhiteSpace(dta.PROPOVA_COD_OPER_CREDITO) ? "-1" : "0";
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.WS_NULL8 = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PLANO = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_SICOB = result[i++].Value?.ToString();
            dta.WS_FIM_DE_VIGENCIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}