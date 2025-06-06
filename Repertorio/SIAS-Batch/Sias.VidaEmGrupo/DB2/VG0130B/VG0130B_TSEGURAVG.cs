using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0130B
{
    public class VG0130B_TSEGURAVG : QueryBasis<VG0130B_TSEGURAVG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0130B_TSEGURAVG() { IsCursor = true; }

        public VG0130B_TSEGURAVG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SNUM_APOLICE { get; set; }
        public string SCOD_SUBGRUPO { get; set; }
        public string SNUM_CERTIFICADO { get; set; }
        public string SDAC_CERTIFICADO { get; set; }
        public string STIPO_SEGURADO { get; set; }
        public string SNUM_ITEM { get; set; }
        public string STIPO_INCLUSAO { get; set; }
        public string SCOD_CLIENTE { get; set; }
        public string SCOD_FONTE { get; set; }
        public string SNUM_PROPOSTA { get; set; }
        public string SCOD_AGENCIADOR { get; set; }
        public string SCOD_CORRETOR { get; set; }
        public string SCOD_PLANOVGAP { get; set; }
        public string SCOD_PLANOAP { get; set; }
        public string SFAIXA { get; set; }
        public string SAUTOR_AUM_AUTOMAT { get; set; }
        public string STIPO_BENEFICIARIO { get; set; }
        public string SOCORR_HISTORICO { get; set; }
        public string SPERI_PAGAMENTO { get; set; }
        public string SPERI_RENOVACAO { get; set; }
        public string SNUM_CARNE { get; set; }
        public string SCOD_OCUPACAO { get; set; }
        public string SESTADO_CIVIL { get; set; }
        public string SIDE_SEXO { get; set; }
        public string SCOD_PROFISSAO { get; set; }
        public string SNATURALIDADE { get; set; }
        public string SOCORR_ENDERECO { get; set; }
        public string SOCORR_END_COBRAN { get; set; }
        public string SBCO_COBRANCA { get; set; }
        public string SAGE_COBRANCA { get; set; }
        public string SDAC_COBRANCA { get; set; }
        public string SNUM_MATRICULA { get; set; }
        public string SVAL_SALARIO { get; set; }
        public string STIPO_SALARIO { get; set; }
        public string STIPO_PLANO { get; set; }
        public string SDATA_INIVIGENCIA { get; set; }
        public string SPCT_CONJUGE_VG { get; set; }
        public string SPCT_CONJUGE_AP { get; set; }
        public string SQTD_SAL_MORNATU { get; set; }
        public string SQTD_SAL_MORACID { get; set; }
        public string SQTD_SAL_INVPERM { get; set; }
        public string STAXA_AP_MORACID { get; set; }
        public string STAXA_AP_INVPERM { get; set; }
        public string STAXA_AP_AMDS { get; set; }
        public string STAXA_AP_DH { get; set; }
        public string STAXA_AP_DIT { get; set; }
        public string STAXA_AP { get; set; }
        public string STAXA_VG { get; set; }
        public string SSIT_REGISTRO { get; set; }
        public string SDATA_ADMISSAO { get; set; }
        public string SDATA_ADMISSAO_I { get; set; }
        public string SDATA_NASCIMENTO { get; set; }
        public string SDATA_NASCIMENTO_I { get; set; }
        public string SCOD_EMPRESA { get; set; }
        public string SCOD_EMPRESA_I { get; set; }
        public string SLOT_EMP_SEGURADO { get; set; }
        public string WLOT_EMP_SEGURADO { get; set; }

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


        public override VG0130B_TSEGURAVG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0130B_TSEGURAVG();
            var i = 0;

            dta.SNUM_APOLICE = result[i++].Value?.ToString();
            dta.SCOD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SNUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SDAC_CERTIFICADO = result[i++].Value?.ToString();
            dta.STIPO_SEGURADO = result[i++].Value?.ToString();
            dta.SNUM_ITEM = result[i++].Value?.ToString();
            dta.STIPO_INCLUSAO = result[i++].Value?.ToString();
            dta.SCOD_CLIENTE = result[i++].Value?.ToString();
            dta.SCOD_FONTE = result[i++].Value?.ToString();
            dta.SNUM_PROPOSTA = result[i++].Value?.ToString();
            dta.SCOD_AGENCIADOR = result[i++].Value?.ToString();
            dta.SCOD_CORRETOR = result[i++].Value?.ToString();
            dta.SCOD_PLANOVGAP = result[i++].Value?.ToString();
            dta.SCOD_PLANOAP = result[i++].Value?.ToString();
            dta.SFAIXA = result[i++].Value?.ToString();
            dta.SAUTOR_AUM_AUTOMAT = result[i++].Value?.ToString();
            dta.STIPO_BENEFICIARIO = result[i++].Value?.ToString();
            dta.SOCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SPERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.SPERI_RENOVACAO = result[i++].Value?.ToString();
            dta.SNUM_CARNE = result[i++].Value?.ToString();
            dta.SCOD_OCUPACAO = result[i++].Value?.ToString();
            dta.SESTADO_CIVIL = result[i++].Value?.ToString();
            dta.SIDE_SEXO = result[i++].Value?.ToString();
            dta.SCOD_PROFISSAO = result[i++].Value?.ToString();
            dta.SNATURALIDADE = result[i++].Value?.ToString();
            dta.SOCORR_ENDERECO = result[i++].Value?.ToString();
            dta.SOCORR_END_COBRAN = result[i++].Value?.ToString();
            dta.SBCO_COBRANCA = result[i++].Value?.ToString();
            dta.SAGE_COBRANCA = result[i++].Value?.ToString();
            dta.SDAC_COBRANCA = result[i++].Value?.ToString();
            dta.SNUM_MATRICULA = result[i++].Value?.ToString();
            dta.SVAL_SALARIO = result[i++].Value?.ToString();
            dta.STIPO_SALARIO = result[i++].Value?.ToString();
            dta.STIPO_PLANO = result[i++].Value?.ToString();
            dta.SDATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SPCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.SPCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.SQTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.SQTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.SQTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.STAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.STAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.STAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.STAXA_AP_DH = result[i++].Value?.ToString();
            dta.STAXA_AP_DIT = result[i++].Value?.ToString();
            dta.STAXA_AP = result[i++].Value?.ToString();
            dta.STAXA_VG = result[i++].Value?.ToString();
            dta.SSIT_REGISTRO = result[i++].Value?.ToString();
            dta.SDATA_ADMISSAO = result[i++].Value?.ToString();
            dta.SDATA_ADMISSAO_I = string.IsNullOrWhiteSpace(dta.SDATA_ADMISSAO) ? "-1" : "0";
            dta.SDATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.SDATA_NASCIMENTO_I = string.IsNullOrWhiteSpace(dta.SDATA_NASCIMENTO) ? "-1" : "0";
            dta.SOCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SCOD_EMPRESA = result[i++].Value?.ToString();
            dta.SCOD_EMPRESA_I = string.IsNullOrWhiteSpace(dta.SCOD_EMPRESA) ? "-1" : "0";
            dta.SLOT_EMP_SEGURADO = result[i++].Value?.ToString();
            dta.WLOT_EMP_SEGURADO = string.IsNullOrWhiteSpace(dta.SLOT_EMP_SEGURADO) ? "-1" : "0";

            return dta;
        }

    }
}