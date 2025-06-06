using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class VG1601B_CSEGURA : QueryBasis<VG1601B_CSEGURA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1601B_CSEGURA() { IsCursor = true; }

        public VG1601B_CSEGURA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_DAC_CERTIFICADO { get; set; }
        public string SEGURVGA_TIPO_SEGURADO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_TIPO_INCLUSAO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_COD_FONTE { get; set; }
        public string SEGURVGA_NUM_PROPOSTA { get; set; }
        public string SEGURVGA_COD_AGENCIADOR { get; set; }
        public string SEGURVGA_COD_CORRETOR { get; set; }
        public string SEGURVGA_COD_PLANOVGAP { get; set; }
        public string SEGURVGA_COD_PLANOAP { get; set; }
        public string SEGURVGA_FAIXA { get; set; }
        public string SEGURVGA_AUTOR_AUM_AUTOMAT { get; set; }
        public string SEGURVGA_TIPO_BENEFICIARIO { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_PERI_PAGAMENTO { get; set; }
        public string SEGURVGA_PERI_RENOVACAO { get; set; }
        public string SEGURVGA_NUM_CARNE { get; set; }
        public string SEGURVGA_COD_OCUPACAO { get; set; }
        public string SEGURVGA_ESTADO_CIVIL { get; set; }
        public string SEGURVGA_IDE_SEXO { get; set; }
        public string SEGURVGA_COD_PROFISSAO { get; set; }
        public string SEGURVGA_NATURALIDADE { get; set; }
        public string SEGURVGA_OCORR_ENDERECO { get; set; }
        public string SEGURVGA_OCORR_END_COBRAN { get; set; }
        public string SEGURVGA_BCO_COBRANCA { get; set; }
        public string SEGURVGA_AGE_COBRANCA { get; set; }
        public string SEGURVGA_DAC_COBRANCA { get; set; }
        public string SEGURVGA_NUM_MATRICULA { get; set; }
        public string SEGURVGA_VAL_SALARIO { get; set; }
        public string SEGURVGA_TIPO_SALARIO { get; set; }
        public string SEGURVGA_TIPO_PLANO { get; set; }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }
        public string SEGURVGA_PCT_CONJUGE_VG { get; set; }
        public string SEGURVGA_PCT_CONJUGE_AP { get; set; }
        public string SEGURVGA_QTD_SAL_MORNATU { get; set; }
        public string SEGURVGA_QTD_SAL_MORACID { get; set; }
        public string SEGURVGA_QTD_SAL_INVPERM { get; set; }
        public string SEGURVGA_TAXA_AP_MORACID { get; set; }
        public string SEGURVGA_TAXA_AP_INVPERM { get; set; }
        public string SEGURVGA_TAXA_AP_AMDS { get; set; }
        public string SEGURVGA_TAXA_AP_DH { get; set; }
        public string SEGURVGA_TAXA_AP_DIT { get; set; }
        public string SEGURVGA_TAXA_AP { get; set; }
        public string SEGURVGA_TAXA_VG { get; set; }
        public string SEGURVGA_SIT_REGISTRO { get; set; }
        public string SEGURVGA_DATA_ADMISSAO { get; set; }
        public string SDATA_ADMISSAO_I { get; set; }
        public string SEGURVGA_DATA_NASCIMENTO { get; set; }
        public string SDATA_NASCIMENTO_I { get; set; }
        public string SEGURVGA_COD_EMPRESA { get; set; }
        public string SCOD_EMPRESA_I { get; set; }
        public string SEGURVGA_LOT_EMP_SEGURADO { get; set; }
        public string SLOT_EMP_SEGURADO_I { get; set; }

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


        public override VG1601B_CSEGURA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1601B_CSEGURA();
            var i = 0;

            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_DAC_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_TIPO_SEGURADO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_TIPO_INCLUSAO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_FONTE = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_AGENCIADOR = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CORRETOR = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_PLANOVGAP = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_PLANOAP = result[i++].Value?.ToString();
            dta.SEGURVGA_FAIXA = result[i++].Value?.ToString();
            dta.SEGURVGA_AUTOR_AUM_AUTOMAT = result[i++].Value?.ToString();
            dta.SEGURVGA_TIPO_BENEFICIARIO = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGURVGA_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.SEGURVGA_PERI_RENOVACAO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_CARNE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_OCUPACAO = result[i++].Value?.ToString();
            dta.SEGURVGA_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.SEGURVGA_IDE_SEXO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_PROFISSAO = result[i++].Value?.ToString();
            dta.SEGURVGA_NATURALIDADE = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_END_COBRAN = result[i++].Value?.ToString();
            dta.SEGURVGA_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.SEGURVGA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.SEGURVGA_DAC_COBRANCA = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.SEGURVGA_VAL_SALARIO = result[i++].Value?.ToString();
            dta.SEGURVGA_TIPO_SALARIO = result[i++].Value?.ToString();
            dta.SEGURVGA_TIPO_PLANO = result[i++].Value?.ToString();
            dta.SEGURVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SEGURVGA_PCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.SEGURVGA_PCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.SEGURVGA_QTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.SEGURVGA_QTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.SEGURVGA_QTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_DH = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_DIT = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_VG = result[i++].Value?.ToString();
            dta.SEGURVGA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SEGURVGA_DATA_ADMISSAO = result[i++].Value?.ToString();
            dta.SDATA_ADMISSAO_I = string.IsNullOrWhiteSpace(dta.SEGURVGA_DATA_ADMISSAO) ? "-1" : "0";
            dta.SEGURVGA_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.SDATA_NASCIMENTO_I = string.IsNullOrWhiteSpace(dta.SEGURVGA_DATA_NASCIMENTO) ? "-1" : "0";
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_EMPRESA = result[i++].Value?.ToString();
            dta.SCOD_EMPRESA_I = string.IsNullOrWhiteSpace(dta.SEGURVGA_COD_EMPRESA) ? "-1" : "0";
            dta.SEGURVGA_LOT_EMP_SEGURADO = result[i++].Value?.ToString();
            dta.SLOT_EMP_SEGURADO_I = string.IsNullOrWhiteSpace(dta.SEGURVGA_LOT_EMP_SEGURADO) ? "-1" : "0";

            return dta;
        }

    }
}