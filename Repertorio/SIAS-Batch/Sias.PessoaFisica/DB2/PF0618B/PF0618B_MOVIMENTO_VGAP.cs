using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0618B
{
    public class PF0618B_MOVIMENTO_VGAP : QueryBasis<PF0618B_MOVIMENTO_VGAP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0618B_MOVIMENTO_VGAP() { IsCursor = true; }

        public PF0618B_MOVIMENTO_VGAP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_SELECT { get; set; }
        public string MOVIMVGA_NUM_APOLICE { get; set; }
        public string MOVIMVGA_COD_SUBGRUPO { get; set; }
        public string MOVIMVGA_COD_FONTE { get; set; }
        public string MOVIMVGA_NUM_PROPOSTA { get; set; }
        public string MOVIMVGA_TIPO_SEGURADO { get; set; }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }
        public string MOVIMVGA_DAC_CERTIFICADO { get; set; }
        public string MOVIMVGA_IDE_SEXO { get; set; }
        public string MOVIMVGA_PCT_CONJUGE_VG { get; set; }
        public string MOVIMVGA_PCT_CONJUGE_AP { get; set; }
        public string MOVIMVGA_QTD_SAL_MORNATU { get; set; }
        public string MOVIMVGA_QTD_SAL_MORACID { get; set; }
        public string MOVIMVGA_QTD_SAL_INVPERM { get; set; }
        public string MOVIMVGA_TAXA_AP_MORACID { get; set; }
        public string MOVIMVGA_TAXA_AP_INVPERM { get; set; }
        public string MOVIMVGA_TAXA_AP_AMDS { get; set; }
        public string MOVIMVGA_TAXA_AP_DH { get; set; }
        public string MOVIMVGA_TAXA_AP_DIT { get; set; }
        public string MOVIMVGA_TAXA_VG { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ANT { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ATU { get; set; }
        public string MOVIMVGA_IMP_MORACID_ANT { get; set; }
        public string MOVIMVGA_IMP_MORACID_ATU { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ANT { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ATU { get; set; }
        public string MOVIMVGA_IMP_AMDS_ANT { get; set; }
        public string MOVIMVGA_IMP_AMDS_ATU { get; set; }
        public string MOVIMVGA_IMP_DH_ANT { get; set; }
        public string MOVIMVGA_IMP_DH_ATU { get; set; }
        public string MOVIMVGA_IMP_DIT_ANT { get; set; }
        public string MOVIMVGA_IMP_DIT_ATU { get; set; }
        public string MOVIMVGA_PRM_VG_ANT { get; set; }
        public string MOVIMVGA_PRM_VG_ATU { get; set; }
        public string MOVIMVGA_PRM_AP_ANT { get; set; }
        public string MOVIMVGA_PRM_AP_ATU { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string MOVIMVGA_DATA_OPERACAO { get; set; }
        public string MOVIMVGA_DATA_REFERENCIA { get; set; }
        public string VIND_DATA_REFERENCIA { get; set; }
        public string MOVIMVGA_DATA_MOVIMENTO { get; set; }
        public string VIND_DATA_MOVIMENTO { get; set; }
        public string MOVIMVGA_DATA_INCLUSAO { get; set; }
        public string VIND_DATA_INCLUSAO { get; set; }
        public string MOVIMVGA_COD_SUBGRUPO_TRANS { get; set; }
        public string MOVIMVGA_SIT_REGISTRO { get; set; }
        public string MOVIMVGA_COD_USUARIO { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }

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


        public override PF0618B_MOVIMENTO_VGAP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0618B_MOVIMENTO_VGAP();
            var i = 0;

            dta.WS_SELECT = result[i++].Value?.ToString();
            dta.MOVIMVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_FONTE = result[i++].Value?.ToString();
            dta.MOVIMVGA_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.MOVIMVGA_TIPO_SEGURADO = result[i++].Value?.ToString();
            dta.MOVIMVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DAC_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVIMVGA_IDE_SEXO = result[i++].Value?.ToString();
            dta.MOVIMVGA_PCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.MOVIMVGA_PCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.MOVIMVGA_QTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_QTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.MOVIMVGA_QTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_DH = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_DIT = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_VG = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_MORNATU_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_MORNATU_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_MORACID_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_MORACID_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_INVPERM_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_INVPERM_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_AMDS_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_AMDS_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_DH_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_DH_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_DIT_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_DIT_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_PRM_VG_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_PRM_VG_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_PRM_AP_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_PRM_AP_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DATA_OPERACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.VIND_DATA_REFERENCIA = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_REFERENCIA) ? "-1" : "0";
            dta.MOVIMVGA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.VIND_DATA_MOVIMENTO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_MOVIMENTO) ? "-1" : "0";
            dta.MOVIMVGA_DATA_INCLUSAO = result[i++].Value?.ToString();
            dta.VIND_DATA_INCLUSAO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_INCLUSAO) ? "-1" : "0";
            dta.MOVIMVGA_COD_SUBGRUPO_TRANS = result[i++].Value?.ToString();
            dta.MOVIMVGA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_USUARIO = result[i++].Value?.ToString();
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_PERI_PAGAMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}