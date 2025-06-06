using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0623B
{
    public class PF0623B_TERMO_ADESAO : QueryBasis<PF0623B_TERMO_ADESAO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0623B_TERMO_ADESAO() { IsCursor = true; }

        public PF0623B_TERMO_ADESAO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string TERMOADE_NUM_TERMO { get; set; }
        public string TERMOADE_COD_SUBGRUPO { get; set; }
        public string TERMOADE_DATA_ADESAO { get; set; }
        public string TERMOADE_COD_AGENCIA_OP { get; set; }
        public string TERMOADE_NUM_MATRICULA_VEN { get; set; }
        public string TERMOADE_CODPDTVEN { get; set; }
        public string TERMOADE_PCCOMVEN { get; set; }
        public string TERMOADE_PCADIANTVEN { get; set; }
        public string TERMOADE_COD_AGENCIA_VEN { get; set; }
        public string TERMOADE_OPERACAO_CONTA_VEN { get; set; }
        public string TERMOADE_NUM_CONTA_VEN { get; set; }
        public string TERMOADE_DIG_CONTA_VEN { get; set; }
        public string TERMOADE_NUM_MATRICULA_GER { get; set; }
        public string TERMOADE_CODPDTGER { get; set; }
        public string TERMOADE_PCCOMGER { get; set; }
        public string TERMOADE_COD_AGENCIA_GER { get; set; }
        public string TERMOADE_OPERACAO_CONTA_GER { get; set; }
        public string TERMOADE_NUM_CONTA_GER { get; set; }
        public string TERMOADE_DIG_CONTA_GER { get; set; }
        public string TERMOADE_NUM_MATRICULA_SUR { get; set; }
        public string TERMOADE_CODPDTSUR { get; set; }
        public string TERMOADE_PCCOMSUR { get; set; }
        public string TERMOADE_NUM_MATRICULA_GCO { get; set; }
        public string TERMOADE_CODPDTGCO { get; set; }
        public string TERMOADE_PCCOMGCO { get; set; }
        public string TERMOADE_MODALIDADE_CAPITAL { get; set; }
        public string TERMOADE_TIPO_PLANO { get; set; }
        public string TERMOADE_IND_PLANO_ASSOCIAD { get; set; }
        public string TERMOADE_COD_PLANO_VGAPC { get; set; }
        public string TERMOADE_COD_PLANO_APC { get; set; }
        public string TERMOADE_VAL_CONTRATADO { get; set; }
        public string TERMOADE_VAL_COMISSAO_ADIAN { get; set; }
        public string TERMOADE_QUANT_VIDAS { get; set; }
        public string TERMOADE_TIPO_COBERTURA { get; set; }
        public string TERMOADE_PERI_PAGAMENTO { get; set; }
        public string TERMOADE_TIPO_CORRECAO { get; set; }
        public string TERMOADE_PERIODO_CORRECAO { get; set; }
        public string TERMOADE_COD_MOEDA_IMP { get; set; }
        public string TERMOADE_COD_MOEDA_PRM { get; set; }
        public string TERMOADE_COD_CLIENTE { get; set; }
        public string TERMOADE_OCORR_ENDERECO { get; set; }
        public string TERMOADE_COD_CORRETOR { get; set; }
        public string TERMOADE_PCCOMCOR { get; set; }
        public string TERMOADE_COD_ADMINISTRADOR { get; set; }
        public string TERMOADE_PCCOMADM { get; set; }
        public string TERMOADE_COD_USUARIO { get; set; }
        public string TERMOADE_DATA_INCLUSAO { get; set; }
        public string TERMOADE_SITUACAO { get; set; }
        public string TERMOADE_NUM_PROPOSTA { get; set; }
        public string TERMOADE_NUM_RCAP { get; set; }
        public string VIND_RCAP { get; set; }
        public string TERMOADE_DATA_RCAP { get; set; }
        public string VIND_DATA_RCAP { get; set; }
        public string TERMOADE_VAL_RCAP { get; set; }
        public string VIND_VAL_RCAP { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_FAIXA_RENDA_IND { get; set; }
        public string VIND_FAIXA_RENDA_IND { get; set; }
        public string PROPOVA_FAIXA_RENDA_FAM { get; set; }
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


        public override PF0623B_TERMO_ADESAO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0623B_TERMO_ADESAO();
            var i = 0;

            dta.TERMOADE_NUM_TERMO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.TERMOADE_DATA_ADESAO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_AGENCIA_OP = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_CODPDTVEN = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMVEN = result[i++].Value?.ToString();
            dta.TERMOADE_PCADIANTVEN = result[i++].Value?.ToString();
            dta.TERMOADE_COD_AGENCIA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_OPERACAO_CONTA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_CONTA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_DIG_CONTA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_CODPDTGER = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMGER = result[i++].Value?.ToString();
            dta.TERMOADE_COD_AGENCIA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_OPERACAO_CONTA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_CONTA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_DIG_CONTA_GER = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_SUR = result[i++].Value?.ToString();
            dta.TERMOADE_CODPDTSUR = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMSUR = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_GCO = result[i++].Value?.ToString();
            dta.TERMOADE_CODPDTGCO = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMGCO = result[i++].Value?.ToString();
            dta.TERMOADE_MODALIDADE_CAPITAL = result[i++].Value?.ToString();
            dta.TERMOADE_TIPO_PLANO = result[i++].Value?.ToString();
            dta.TERMOADE_IND_PLANO_ASSOCIAD = result[i++].Value?.ToString();
            dta.TERMOADE_COD_PLANO_VGAPC = result[i++].Value?.ToString();
            dta.TERMOADE_COD_PLANO_APC = result[i++].Value?.ToString();
            dta.TERMOADE_VAL_CONTRATADO = result[i++].Value?.ToString();
            dta.TERMOADE_VAL_COMISSAO_ADIAN = result[i++].Value?.ToString();
            dta.TERMOADE_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.TERMOADE_TIPO_COBERTURA = result[i++].Value?.ToString();
            dta.TERMOADE_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.TERMOADE_TIPO_CORRECAO = result[i++].Value?.ToString();
            dta.TERMOADE_PERIODO_CORRECAO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_MOEDA_IMP = result[i++].Value?.ToString();
            dta.TERMOADE_COD_MOEDA_PRM = result[i++].Value?.ToString();
            dta.TERMOADE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.TERMOADE_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_CORRETOR = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMCOR = result[i++].Value?.ToString();
            dta.TERMOADE_COD_ADMINISTRADOR = result[i++].Value?.ToString();
            dta.TERMOADE_PCCOMADM = result[i++].Value?.ToString();
            dta.TERMOADE_COD_USUARIO = result[i++].Value?.ToString();
            dta.TERMOADE_DATA_INCLUSAO = result[i++].Value?.ToString();
            dta.TERMOADE_SITUACAO = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_RCAP = result[i++].Value?.ToString();
            dta.VIND_RCAP = string.IsNullOrWhiteSpace(dta.TERMOADE_NUM_RCAP) ? "-1" : "0";
            dta.TERMOADE_DATA_RCAP = result[i++].Value?.ToString();
            dta.VIND_DATA_RCAP = string.IsNullOrWhiteSpace(dta.TERMOADE_DATA_RCAP) ? "-1" : "0";
            dta.TERMOADE_VAL_RCAP = result[i++].Value?.ToString();
            dta.VIND_VAL_RCAP = string.IsNullOrWhiteSpace(dta.TERMOADE_VAL_RCAP) ? "-1" : "0";
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_IND = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.PROPOVA_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_FAM = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_FAM) ? "-1" : "0";

            return dta;
        }

    }
}