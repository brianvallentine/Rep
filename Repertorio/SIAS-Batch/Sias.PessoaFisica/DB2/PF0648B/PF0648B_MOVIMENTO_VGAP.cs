using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class PF0648B_MOVIMENTO_VGAP : QueryBasis<PF0648B_MOVIMENTO_VGAP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0648B_MOVIMENTO_VGAP() { IsCursor = true; }

        public PF0648B_MOVIMENTO_VGAP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVVGAP_NUM_APOLICE { get; set; }
        public string MOVVGAP_COD_SUBGRUPO { get; set; }
        public string MOVVGAP_COD_FONTE { get; set; }
        public string MOVVGAP_NUM_PROPOSTA { get; set; }
        public string MOVVGAP_TIPO_SEGURADO { get; set; }
        public string MOVVGAP_NUM_CERTIFICADO { get; set; }
        public string MOVVGAP_DAC_CERTIFICADO { get; set; }
        public string MOVVGAP_TIPO_INCLUSAO { get; set; }
        public string MOVVGAP_COD_CLIENTE { get; set; }
        public string MOVVGAP_COD_AGENCIADOR { get; set; }
        public string MOVVGAP_COD_CORRETOR { get; set; }
        public string MOVVGAP_COD_PLANOVGAP { get; set; }
        public string MOVVGAP_COD_PLANOAP { get; set; }
        public string MOVVGAP_FAIXA { get; set; }
        public string MOVVGAP_AUTOR_AUM_AUTOMAT { get; set; }
        public string MOVVGAP_TIPO_BENEFICIARIO { get; set; }
        public string MOVVGAP_PERI_PAGAMENTO { get; set; }
        public string MOVVGAP_PERI_RENOVACAO { get; set; }
        public string MOVVGAP_COD_OCUPACAO { get; set; }
        public string MOVVGAP_ESTADO_CIVIL { get; set; }
        public string MOVVGAP_IDE_SEXO { get; set; }
        public string MOVVGAP_COD_PROFISSAO { get; set; }
        public string MOVVGAP_NATURALIDADE { get; set; }
        public string MOVVGAP_OCORR_ENDERECO { get; set; }
        public string MOVVGAP_OCORR_END_COBRAN { get; set; }
        public string MOVVGAP_BCO_COBRANCA { get; set; }
        public string MOVVGAP_AGE_COBRANCA { get; set; }
        public string MOVVGAP_DAC_COBRANCA { get; set; }
        public string MOVVGAP_NUM_MATRICULA { get; set; }
        public string MOVVGAP_NUM_CTA_CORRENTE { get; set; }
        public string MOVVGAP_DAC_CTA_CORRENTE { get; set; }
        public string MOVVGAP_VAL_SALARIO { get; set; }
        public string MOVVGAP_TIPO_SALARIO { get; set; }
        public string MOVVGAP_TIPO_PLANO { get; set; }
        public string MOVVGAP_PCT_CONJUGE_VG { get; set; }
        public string MOVVGAP_PCT_CONJUGE_AP { get; set; }
        public string MOVVGAP_QTD_SAL_MORNATU { get; set; }
        public string MOVVGAP_QTD_SAL_MORACID { get; set; }
        public string MOVVGAP_QTD_SAL_INVPERM { get; set; }
        public string MOVVGAP_TAXA_AP_MORACID { get; set; }
        public string MOVVGAP_TAXA_AP_INVPERM { get; set; }
        public string MOVVGAP_TAXA_AP_AMDS { get; set; }
        public string MOVVGAP_TAXA_AP_DH { get; set; }
        public string MOVVGAP_TAXA_AP_DIT { get; set; }
        public string MOVVGAP_TAXA_VG { get; set; }
        public string MOVVGAP_IMP_MORNATU_ANT { get; set; }
        public string MOVVGAP_IMP_MORNATU_ATU { get; set; }
        public string MOVVGAP_IMP_MORACID_ANT { get; set; }
        public string MOVVGAP_IMP_MORACID_ATU { get; set; }
        public string MOVVGAP_IMP_INVPERM_ANT { get; set; }
        public string MOVVGAP_IMP_INVPERM_ATU { get; set; }
        public string MOVVGAP_IMP_AMDS_ANT { get; set; }
        public string MOVVGAP_IMP_AMDS_ATU { get; set; }
        public string MOVVGAP_IMP_DH_ANT { get; set; }
        public string MOVVGAP_IMP_DH_ATU { get; set; }
        public string MOVVGAP_IMP_DIT_ANT { get; set; }
        public string MOVVGAP_IMP_DIT_ATU { get; set; }
        public string MOVVGAP_PRM_VG_ANT { get; set; }
        public string MOVVGAP_PRM_VG_ATU { get; set; }
        public string MOVVGAP_PRM_AP_ANT { get; set; }
        public string MOVVGAP_PRM_AP_ATU { get; set; }
        public string MOVVGAP_COD_OPERACAO { get; set; }
        public string MOVVGAP_DATA_AVERBACAO { get; set; }
        public string MOVVGAP_DATA_INCLUSAO { get; set; }
        public string MOVVGAP_COD_SUBGRUPO_TRANS { get; set; }
        public string MOVVGAP_SIT_REGISTRO { get; set; }
        public string MOVVGAP_COD_USUARIO { get; set; }
        public string DCLPRODUTOS_VG_COD_PRODUTO { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }

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


        public override PF0648B_MOVIMENTO_VGAP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0648B_MOVIMENTO_VGAP();
            var i = 0;

            dta.MOVVGAP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_FONTE = result[i++].Value?.ToString();
            dta.MOVVGAP_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.MOVVGAP_TIPO_SEGURADO = result[i++].Value?.ToString();
            dta.MOVVGAP_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVVGAP_DAC_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVVGAP_TIPO_INCLUSAO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_CLIENTE = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_AGENCIADOR = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_CORRETOR = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_PLANOVGAP = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_PLANOAP = result[i++].Value?.ToString();
            dta.MOVVGAP_FAIXA = result[i++].Value?.ToString();
            dta.MOVVGAP_AUTOR_AUM_AUTOMAT = result[i++].Value?.ToString();
            dta.MOVVGAP_TIPO_BENEFICIARIO = result[i++].Value?.ToString();
            dta.MOVVGAP_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.MOVVGAP_PERI_RENOVACAO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_OCUPACAO = result[i++].Value?.ToString();
            dta.MOVVGAP_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.MOVVGAP_IDE_SEXO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_PROFISSAO = result[i++].Value?.ToString();
            dta.MOVVGAP_NATURALIDADE = result[i++].Value?.ToString();
            dta.MOVVGAP_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.MOVVGAP_OCORR_END_COBRAN = result[i++].Value?.ToString();
            dta.MOVVGAP_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVVGAP_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.MOVVGAP_DAC_COBRANCA = result[i++].Value?.ToString();
            dta.MOVVGAP_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.MOVVGAP_NUM_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.MOVVGAP_DAC_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.MOVVGAP_VAL_SALARIO = result[i++].Value?.ToString();
            dta.MOVVGAP_TIPO_SALARIO = result[i++].Value?.ToString();
            dta.MOVVGAP_TIPO_PLANO = result[i++].Value?.ToString();
            dta.MOVVGAP_PCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.MOVVGAP_PCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.MOVVGAP_QTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.MOVVGAP_QTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.MOVVGAP_QTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_DH = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_DIT = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_VG = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_MORNATU_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_MORNATU_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_MORACID_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_MORACID_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_INVPERM_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_INVPERM_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_AMDS_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_AMDS_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_DH_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_DH_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_DIT_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_DIT_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_PRM_VG_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_PRM_VG_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_PRM_AP_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_PRM_AP_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_OPERACAO = result[i++].Value?.ToString();
            dta.MOVVGAP_DATA_AVERBACAO = result[i++].Value?.ToString();
            dta.MOVVGAP_DATA_INCLUSAO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_SUBGRUPO_TRANS = result[i++].Value?.ToString();
            dta.MOVVGAP_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_USUARIO = result[i++].Value?.ToString();
            dta.DCLPRODUTOS_VG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.RELATORI_PERI_FINAL = result[i++].Value?.ToString();

            return dta;
        }

    }
}