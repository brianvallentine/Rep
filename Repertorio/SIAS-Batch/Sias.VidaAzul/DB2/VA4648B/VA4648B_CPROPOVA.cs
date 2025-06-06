using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4648B
{
    public class VA4648B_CPROPOVA : QueryBasis<VA4648B_CPROPOVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA4648B_CPROPOVA() { IsCursor = true; }

        public VA4648B_CPROPOVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLPROPOSTAS_VA_NUM_CERTIFICADO { get; set; }
        public string DCLPROPOSTAS_VA_COD_PRODUTO { get; set; }
        public string DCLPROPOSTAS_VA_COD_CLIENTE { get; set; }
        public string DCLPROPOSTAS_VA_OCOREND { get; set; }
        public string DCLPROPOSTAS_VA_COD_FONTE { get; set; }
        public string DCLPROPOSTAS_VA_AGE_COBRANCA { get; set; }
        public string DCLPROPOSTAS_VA_OPCAO_COBERTURA { get; set; }
        public string DCLPROPOSTAS_VA_DATA_QUITACAO { get; set; }
        public string DCLPROPOSTAS_VA_COD_AGE_VENDEDOR { get; set; }
        public string DCLPROPOSTAS_VA_OPE_CONTA_VENDEDOR { get; set; }
        public string DCLPROPOSTAS_VA_NUM_CONTA_VENDEDOR { get; set; }
        public string DCLPROPOSTAS_VA_DIG_CONTA_VENDEDOR { get; set; }
        public string DCLPROPOSTAS_VA_NUM_MATRI_VENDEDOR { get; set; }
        public string DCLPROPOSTAS_VA_COD_OPERACAO { get; set; }
        public string DCLPROPOSTAS_VA_PROFISSAO { get; set; }
        public string DCLPROPOSTAS_VA_DTINCLUS { get; set; }
        public string DCLPROPOSTAS_VA_DATA_MOVIMENTO { get; set; }
        public string DCLPROPOSTAS_VA_SIT_REGISTRO { get; set; }
        public string DCLPROPOSTAS_VA_NUM_APOLICE { get; set; }
        public string DCLPROPOSTAS_VA_COD_SUBGRUPO { get; set; }
        public string DCLPROPOSTAS_VA_OCORR_HISTORICO { get; set; }
        public string DCLPROPOSTAS_VA_NRPRIPARATZ { get; set; }
        public string DCLPROPOSTAS_VA_QTDPARATZ { get; set; }
        public string DCLPROPOSTAS_VA_DTPROXVEN { get; set; }
        public string DCLPROPOSTAS_VA_NUM_PARCELA { get; set; }
        public string DCLPROPOSTAS_VA_DATA_VENCIMENTO { get; set; }
        public string DCLPROPOSTAS_VA_SIT_INTERFACE { get; set; }
        public string DCLPROPOSTAS_VA_DTFENAE { get; set; }
        public string DCLPROPOSTAS_VA_COD_USUARIO { get; set; }
        public string DCLPROPOSTAS_VA_TIMESTAMP { get; set; }
        public string DCLPROPOSTAS_VA_IDADE { get; set; }
        public string DCLPROPOSTAS_VA_IDE_SEXO { get; set; }
        public string DCLPROPOSTAS_VA_ESTADO_CIVIL { get; set; }
        public string DCLPROPOSTAS_VA_APOS_INVALIDEZ { get; set; }
        public string VIND_APOS_INVALIDEZ { get; set; }
        public string DCLPROPOSTAS_VA_NOME_ESPOSA { get; set; }
        public string VIND_NOME_ESPOSA { get; set; }
        public string DCLPROPOSTAS_VA_DTNASC_ESPOSA { get; set; }
        public string VIND_DTNASC_ESPOSA { get; set; }
        public string DCLPROPOSTAS_VA_PROFIS_ESPOSA { get; set; }
        public string VIND_PROFIS_ESPOSA { get; set; }
        public string DCLPROPOSTAS_VA_DPS_TITULAR { get; set; }
        public string VIND_DPS_TITULAR { get; set; }
        public string DCLPROPOSTAS_VA_DPS_ESPOSA { get; set; }
        public string VIND_DPS_ESPOSA { get; set; }
        public string DCLPROPOSTAS_VA_INFO_COMPLEMENTAR { get; set; }
        public string VIND_INFO_COMP { get; set; }
        public string DCLPROPOSTAS_VA_COD_CCT { get; set; }
        public string VIND_COD_CCT { get; set; }
        public string DCLPROPOSTAS_VA_FAIXA_RENDA_IND { get; set; }
        public string VIND_FAIXA_RENDA_IND { get; set; }
        public string DCLPROPOSTAS_VA_FAIXA_RENDA_FAM { get; set; }
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


        public override VA4648B_CPROPOVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA4648B_CPROPOVA();
            var i = 0;

            dta.DCLPROPOSTAS_VA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_OCOREND = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_COD_FONTE = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_COD_AGE_VENDEDOR = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_OPE_CONTA_VENDEDOR = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_NUM_CONTA_VENDEDOR = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_DIG_CONTA_VENDEDOR = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_NUM_MATRI_VENDEDOR = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_PROFISSAO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_DTINCLUS = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_NRPRIPARATZ = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_QTDPARATZ = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_DTPROXVEN = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_SIT_INTERFACE = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_DTFENAE = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_COD_USUARIO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_TIMESTAMP = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_IDADE = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_IDE_SEXO = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.DCLPROPOSTAS_VA_APOS_INVALIDEZ = result[i++].Value?.ToString();
            dta.VIND_APOS_INVALIDEZ = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_APOS_INVALIDEZ) ? "-1" : "0";
            dta.DCLPROPOSTAS_VA_NOME_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_NOME_ESPOSA = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_NOME_ESPOSA) ? "-1" : "0";
            dta.DCLPROPOSTAS_VA_DTNASC_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_DTNASC_ESPOSA = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_DTNASC_ESPOSA) ? "-1" : "0";
            dta.DCLPROPOSTAS_VA_PROFIS_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_PROFIS_ESPOSA = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_PROFIS_ESPOSA) ? "-1" : "0";
            dta.DCLPROPOSTAS_VA_DPS_TITULAR = result[i++].Value?.ToString();
            dta.VIND_DPS_TITULAR = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_DPS_TITULAR) ? "-1" : "0";
            dta.DCLPROPOSTAS_VA_DPS_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_DPS_ESPOSA = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_DPS_ESPOSA) ? "-1" : "0";
            dta.DCLPROPOSTAS_VA_INFO_COMPLEMENTAR = result[i++].Value?.ToString();
            dta.VIND_INFO_COMP = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_INFO_COMPLEMENTAR) ? "-1" : "0";
            dta.DCLPROPOSTAS_VA_COD_CCT = result[i++].Value?.ToString();
            dta.VIND_COD_CCT = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_COD_CCT) ? "-1" : "0";
            dta.DCLPROPOSTAS_VA_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_IND = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.DCLPROPOSTAS_VA_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_FAM = string.IsNullOrWhiteSpace(dta.DCLPROPOSTAS_VA_FAIXA_RENDA_FAM) ? "-1" : "0";

            return dta;
        }

    }
}