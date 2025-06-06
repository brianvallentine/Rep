using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0095B
{
    public class VG0095B_TMOVIMENTO : QueryBasis<VG0095B_TMOVIMENTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0095B_TMOVIMENTO() { IsCursor = true; }

        public VG0095B_TMOVIMENTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MNUM_APOLICE { get; set; }
        public string MCOD_SUBGRUPO { get; set; }
        public string MCOD_FONTE { get; set; }
        public string MNUM_PROPOSTA { get; set; }
        public string MTIPO_SEGURADO { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string MDAC_CERTIFICADO { get; set; }
        public string MTIPO_INCLUSAO { get; set; }
        public string MCOD_CLIENTE { get; set; }
        public string MCOD_AGENCIADOR { get; set; }
        public string MCOD_CORRETOR { get; set; }
        public string MCOD_PLANOVGAP { get; set; }
        public string MCOD_PLANOAP { get; set; }
        public string MFAIXA { get; set; }
        public string MAUTOR_AUM_AUTOMAT { get; set; }
        public string MTIPO_BENEFICIARIO { get; set; }
        public string MPERI_PAGAMENTO { get; set; }
        public string MPERI_RENOVACAO { get; set; }
        public string MCOD_OCUPACAO { get; set; }
        public string MESTADO_CIVIL { get; set; }
        public string MIDE_SEXO { get; set; }
        public string MCOD_PROFISSAO { get; set; }
        public string MNATURALIDADE { get; set; }
        public string MOCORR_ENDERECO { get; set; }
        public string MOCORR_END_COBRAN { get; set; }
        public string MBCO_COBRANCA { get; set; }
        public string MAGE_COBRANCA { get; set; }
        public string MDAC_COBRANCA { get; set; }
        public string MNUM_MATRICULA { get; set; }
        public string MNUM_CTA_CORRENTE { get; set; }
        public string MDAC_CTA_CORRENTE { get; set; }
        public string MVAL_SALARIO { get; set; }
        public string MTIPO_SALARIO { get; set; }
        public string MTIPO_PLANO { get; set; }
        public string MPCT_CONJUGE_VG { get; set; }
        public string MPCT_CONJUGE_AP { get; set; }
        public string MQTD_SAL_MORNATU { get; set; }
        public string MQTD_SAL_MORACID { get; set; }
        public string MQTD_SAL_INVPERM { get; set; }
        public string MTAXA_AP_MORACID { get; set; }
        public string MTAXA_AP_INVPERM { get; set; }
        public string MTAXA_AP_AMDS { get; set; }
        public string MTAXA_AP_DH { get; set; }
        public string MTAXA_AP_DIT { get; set; }
        public string MTAXA_VG { get; set; }
        public string MIMP_MORNATU_ANT { get; set; }
        public string MIMP_MORNATU_ATU { get; set; }
        public string MIMP_MORACID_ANT { get; set; }
        public string MIMP_MORACID_ATU { get; set; }
        public string MIMP_INVPERM_ANT { get; set; }
        public string MIMP_INVPERM_ATU { get; set; }
        public string MIMP_AMDS_ANT { get; set; }
        public string MIMP_AMDS_ATU { get; set; }
        public string MIMP_DH_ANT { get; set; }
        public string MIMP_DH_ATU { get; set; }
        public string MIMP_DIT_ANT { get; set; }
        public string MIMP_DIT_ATU { get; set; }
        public string MPRM_VG_ANT { get; set; }
        public string MPRM_VG_ATU { get; set; }
        public string MPRM_AP_ANT { get; set; }
        public string MPRM_AP_ATU { get; set; }
        public string MCOD_OPERACAO { get; set; }
        public string MDATA_OPERACAO { get; set; }
        public string COD_SUBGRUPO_TRANS { get; set; }
        public string MSIT_REGISTRO { get; set; }
        public string MCOD_USUARIO { get; set; }
        public string MDATA_AVERBACAO { get; set; }
        public string WDATA_AVERBACAO { get; set; }
        public string MDATA_ADMISSAO { get; set; }
        public string WDATA_ADMISSAO { get; set; }
        public string MDATA_INCLUSAO { get; set; }
        public string WDATA_INCLUSAO { get; set; }
        public string MDATA_NASCIMENTO { get; set; }
        public string WDATA_NASCIMENTO { get; set; }
        public string MDATA_FATURA { get; set; }
        public string WDATA_FATURA { get; set; }
        public string MDATA_REFERENCIA { get; set; }
        public string WDATA_REFERENCIA { get; set; }
        public string MDATA_MOVIMENTO { get; set; }
        public string WDATA_MOVIMENTO { get; set; }
        public string MCOD_EMPRESA { get; set; }
        public string WCOD_EMPRESA { get; set; }

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


        public override VG0095B_TMOVIMENTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0095B_TMOVIMENTO();
            var i = 0;

            dta.MNUM_APOLICE = result[i++].Value?.ToString();
            dta.MCOD_SUBGRUPO = result[i++].Value?.ToString();
            dta.MCOD_FONTE = result[i++].Value?.ToString();
            dta.MNUM_PROPOSTA = result[i++].Value?.ToString();
            dta.MTIPO_SEGURADO = result[i++].Value?.ToString();
            dta.MNUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.MDAC_CERTIFICADO = result[i++].Value?.ToString();
            dta.MTIPO_INCLUSAO = result[i++].Value?.ToString();
            dta.MCOD_CLIENTE = result[i++].Value?.ToString();
            dta.MCOD_AGENCIADOR = result[i++].Value?.ToString();
            dta.MCOD_CORRETOR = result[i++].Value?.ToString();
            dta.MCOD_PLANOVGAP = result[i++].Value?.ToString();
            dta.MCOD_PLANOAP = result[i++].Value?.ToString();
            dta.MFAIXA = result[i++].Value?.ToString();
            dta.MAUTOR_AUM_AUTOMAT = result[i++].Value?.ToString();
            dta.MTIPO_BENEFICIARIO = result[i++].Value?.ToString();
            dta.MPERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.MPERI_RENOVACAO = result[i++].Value?.ToString();
            dta.MCOD_OCUPACAO = result[i++].Value?.ToString();
            dta.MESTADO_CIVIL = result[i++].Value?.ToString();
            dta.MIDE_SEXO = result[i++].Value?.ToString();
            dta.MCOD_PROFISSAO = result[i++].Value?.ToString();
            dta.MNATURALIDADE = result[i++].Value?.ToString();
            dta.MOCORR_ENDERECO = result[i++].Value?.ToString();
            dta.MOCORR_END_COBRAN = result[i++].Value?.ToString();
            dta.MBCO_COBRANCA = result[i++].Value?.ToString();
            dta.MAGE_COBRANCA = result[i++].Value?.ToString();
            dta.MDAC_COBRANCA = result[i++].Value?.ToString();
            dta.MNUM_MATRICULA = result[i++].Value?.ToString();
            dta.MNUM_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.MDAC_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.MVAL_SALARIO = result[i++].Value?.ToString();
            dta.MTIPO_SALARIO = result[i++].Value?.ToString();
            dta.MTIPO_PLANO = result[i++].Value?.ToString();
            dta.MPCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.MPCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.MQTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.MQTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.MQTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.MTAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.MTAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.MTAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.MTAXA_AP_DH = result[i++].Value?.ToString();
            dta.MTAXA_AP_DIT = result[i++].Value?.ToString();
            dta.MTAXA_VG = result[i++].Value?.ToString();
            dta.MIMP_MORNATU_ANT = result[i++].Value?.ToString();
            dta.MIMP_MORNATU_ATU = result[i++].Value?.ToString();
            dta.MIMP_MORACID_ANT = result[i++].Value?.ToString();
            dta.MIMP_MORACID_ATU = result[i++].Value?.ToString();
            dta.MIMP_INVPERM_ANT = result[i++].Value?.ToString();
            dta.MIMP_INVPERM_ATU = result[i++].Value?.ToString();
            dta.MIMP_AMDS_ANT = result[i++].Value?.ToString();
            dta.MIMP_AMDS_ATU = result[i++].Value?.ToString();
            dta.MIMP_DH_ANT = result[i++].Value?.ToString();
            dta.MIMP_DH_ATU = result[i++].Value?.ToString();
            dta.MIMP_DIT_ANT = result[i++].Value?.ToString();
            dta.MIMP_DIT_ATU = result[i++].Value?.ToString();
            dta.MPRM_VG_ANT = result[i++].Value?.ToString();
            dta.MPRM_VG_ATU = result[i++].Value?.ToString();
            dta.MPRM_AP_ANT = result[i++].Value?.ToString();
            dta.MPRM_AP_ATU = result[i++].Value?.ToString();
            dta.MCOD_OPERACAO = result[i++].Value?.ToString();
            dta.MDATA_OPERACAO = result[i++].Value?.ToString();
            dta.COD_SUBGRUPO_TRANS = result[i++].Value?.ToString();
            dta.MSIT_REGISTRO = result[i++].Value?.ToString();
            dta.MCOD_USUARIO = result[i++].Value?.ToString();
            dta.MDATA_AVERBACAO = result[i++].Value?.ToString();
            dta.WDATA_AVERBACAO = string.IsNullOrWhiteSpace(dta.MDATA_AVERBACAO) ? "-1" : "0";
            dta.MDATA_ADMISSAO = result[i++].Value?.ToString();
            dta.WDATA_ADMISSAO = string.IsNullOrWhiteSpace(dta.MDATA_ADMISSAO) ? "-1" : "0";
            dta.MDATA_INCLUSAO = result[i++].Value?.ToString();
            dta.WDATA_INCLUSAO = string.IsNullOrWhiteSpace(dta.MDATA_INCLUSAO) ? "-1" : "0";
            dta.MDATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.WDATA_NASCIMENTO = string.IsNullOrWhiteSpace(dta.MDATA_NASCIMENTO) ? "-1" : "0";
            dta.MDATA_FATURA = result[i++].Value?.ToString();
            dta.WDATA_FATURA = string.IsNullOrWhiteSpace(dta.MDATA_FATURA) ? "-1" : "0";
            dta.MDATA_REFERENCIA = result[i++].Value?.ToString();
            dta.WDATA_REFERENCIA = string.IsNullOrWhiteSpace(dta.MDATA_REFERENCIA) ? "-1" : "0";
            dta.MDATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.WDATA_MOVIMENTO = string.IsNullOrWhiteSpace(dta.MDATA_MOVIMENTO) ? "-1" : "0";
            dta.MCOD_EMPRESA = result[i++].Value?.ToString();
            dta.WCOD_EMPRESA = string.IsNullOrWhiteSpace(dta.MCOD_EMPRESA) ? "-1" : "0";

            return dta;
        }

    }
}