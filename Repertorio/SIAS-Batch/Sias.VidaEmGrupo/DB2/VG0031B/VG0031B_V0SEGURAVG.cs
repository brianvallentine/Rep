using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class VG0031B_V0SEGURAVG : QueryBasis<VG0031B_V0SEGURAVG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0031B_V0SEGURAVG() { IsCursor = true; }

        public VG0031B_V0SEGURAVG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0SEG_NUM_APOL { get; set; }
        public string V0SEG_COD_SUBG { get; set; }
        public string V0SEG_NUM_CERTIF { get; set; }
        public string V0SEG_DAC_CERTIF { get; set; }
        public string V0SEG_TP_SEGURADO { get; set; }
        public string V0SEG_NUM_ITEM { get; set; }
        public string V0SEG_TP_INCLUSAO { get; set; }
        public string V0SEG_COD_CLIENTE { get; set; }
        public string V0SEG_COD_FONTE { get; set; }
        public string V0SEG_NUM_PROPOSTA { get; set; }
        public string V0SEG_AGENCIADOR { get; set; }
        public string V0SEG_CORRETOR { get; set; }
        public string V0SEG_CD_PLANOVGAP { get; set; }
        public string V0SEG_CD_PLANOAP { get; set; }
        public string V0SEG_FAIXA { get; set; }
        public string V0SEG_AUT_AUM_AUT { get; set; }
        public string V0SEG_TP_BENEFICIA { get; set; }
        public string V0SEG_OCORR_HIST { get; set; }
        public string V0SEG_PERI_PGTO { get; set; }
        public string V0SEG_PERI_RENOVA { get; set; }
        public string V0SEG_NUM_CARNE { get; set; }
        public string V0SEG_COD_OCUPACAO { get; set; }
        public string V0SEG_EST_CIVIL { get; set; }
        public string V0SEG_SEXO { get; set; }
        public string V0SEG_CD_PROFISSAO { get; set; }
        public string V0SEG_NATURALIDADE { get; set; }
        public string V0SEG_OCOR_ENDERE { get; set; }
        public string V0SEG_OCOR_END_COB { get; set; }
        public string V0SEG_BCO_COBRANCA { get; set; }
        public string V0SEG_AGE_COBRANCA { get; set; }
        public string V0SEG_DAC_COBRANCA { get; set; }
        public string V0SEG_NUM_MATRIC { get; set; }
        public string V0SEG_VAL_SALARIO { get; set; }
        public string V0SEG_TP_SALARIO { get; set; }
        public string V0SEG_TP_PLANO { get; set; }
        public string V0SEG_DT_INIVIG { get; set; }
        public string V0SEG_PCT_CONJ_VG { get; set; }
        public string V0SEG_PCT_CONJ_AP { get; set; }
        public string V0SEG_QTD_S_MONATU { get; set; }
        public string V0SEG_QTD_S_MOACID { get; set; }
        public string V0SEG_QTD_S_INVPER { get; set; }
        public string V0SEG_TX_AP_MOACID { get; set; }
        public string V0SEG_TX_AP_INVPER { get; set; }
        public string V0SEG_TX_AP_AMDS { get; set; }
        public string V0SEG_TX_AP_DH { get; set; }
        public string V0SEG_TX_AP_DIT { get; set; }
        public string V0SEG_TAXA_AP { get; set; }
        public string V0SEG_TAXA_VG { get; set; }
        public string V0SEG_SIT_REGISTRO { get; set; }
        public string V0SEG_DT_ADMISSAO { get; set; }
        public string VIND_DT_ADMISSAO { get; set; }
        public string V0SEG_DT_NASCI { get; set; }
        public string VIND_DT_NASCI { get; set; }
        public string V0SEG_LOT_EMP_SEGURADO { get; set; }
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


        public override VG0031B_V0SEGURAVG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0031B_V0SEGURAVG();
            var i = 0;

            dta.V0SEG_NUM_APOL = result[i++].Value?.ToString();
            dta.V0SEG_COD_SUBG = result[i++].Value?.ToString();
            dta.V0SEG_NUM_CERTIF = result[i++].Value?.ToString();
            dta.V0SEG_DAC_CERTIF = result[i++].Value?.ToString();
            dta.V0SEG_TP_SEGURADO = result[i++].Value?.ToString();
            dta.V0SEG_NUM_ITEM = result[i++].Value?.ToString();
            dta.V0SEG_TP_INCLUSAO = result[i++].Value?.ToString();
            dta.V0SEG_COD_CLIENTE = result[i++].Value?.ToString();
            dta.V0SEG_COD_FONTE = result[i++].Value?.ToString();
            dta.V0SEG_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.V0SEG_AGENCIADOR = result[i++].Value?.ToString();
            dta.V0SEG_CORRETOR = result[i++].Value?.ToString();
            dta.V0SEG_CD_PLANOVGAP = result[i++].Value?.ToString();
            dta.V0SEG_CD_PLANOAP = result[i++].Value?.ToString();
            dta.V0SEG_FAIXA = result[i++].Value?.ToString();
            dta.V0SEG_AUT_AUM_AUT = result[i++].Value?.ToString();
            dta.V0SEG_TP_BENEFICIA = result[i++].Value?.ToString();
            dta.V0SEG_OCORR_HIST = result[i++].Value?.ToString();
            dta.V0SEG_PERI_PGTO = result[i++].Value?.ToString();
            dta.V0SEG_PERI_RENOVA = result[i++].Value?.ToString();
            dta.V0SEG_NUM_CARNE = result[i++].Value?.ToString();
            dta.V0SEG_COD_OCUPACAO = result[i++].Value?.ToString();
            dta.V0SEG_EST_CIVIL = result[i++].Value?.ToString();
            dta.V0SEG_SEXO = result[i++].Value?.ToString();
            dta.V0SEG_CD_PROFISSAO = result[i++].Value?.ToString();
            dta.V0SEG_NATURALIDADE = result[i++].Value?.ToString();
            dta.V0SEG_OCOR_ENDERE = result[i++].Value?.ToString();
            dta.V0SEG_OCOR_END_COB = result[i++].Value?.ToString();
            dta.V0SEG_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.V0SEG_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.V0SEG_DAC_COBRANCA = result[i++].Value?.ToString();
            dta.V0SEG_NUM_MATRIC = result[i++].Value?.ToString();
            dta.V0SEG_VAL_SALARIO = result[i++].Value?.ToString();
            dta.V0SEG_TP_SALARIO = result[i++].Value?.ToString();
            dta.V0SEG_TP_PLANO = result[i++].Value?.ToString();
            dta.V0SEG_DT_INIVIG = result[i++].Value?.ToString();
            dta.V0SEG_PCT_CONJ_VG = result[i++].Value?.ToString();
            dta.V0SEG_PCT_CONJ_AP = result[i++].Value?.ToString();
            dta.V0SEG_QTD_S_MONATU = result[i++].Value?.ToString();
            dta.V0SEG_QTD_S_MOACID = result[i++].Value?.ToString();
            dta.V0SEG_QTD_S_INVPER = result[i++].Value?.ToString();
            dta.V0SEG_TX_AP_MOACID = result[i++].Value?.ToString();
            dta.V0SEG_TX_AP_INVPER = result[i++].Value?.ToString();
            dta.V0SEG_TX_AP_AMDS = result[i++].Value?.ToString();
            dta.V0SEG_TX_AP_DH = result[i++].Value?.ToString();
            dta.V0SEG_TX_AP_DIT = result[i++].Value?.ToString();
            dta.V0SEG_TAXA_AP = result[i++].Value?.ToString();
            dta.V0SEG_TAXA_VG = result[i++].Value?.ToString();
            dta.V0SEG_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.V0SEG_DT_ADMISSAO = result[i++].Value?.ToString();
            dta.VIND_DT_ADMISSAO = string.IsNullOrWhiteSpace(dta.V0SEG_DT_ADMISSAO) ? "-1" : "0";
            dta.V0SEG_DT_NASCI = result[i++].Value?.ToString();
            dta.VIND_DT_NASCI = string.IsNullOrWhiteSpace(dta.V0SEG_DT_NASCI) ? "-1" : "0";
            dta.V0SEG_LOT_EMP_SEGURADO = result[i++].Value?.ToString();
            dta.WLOT_EMP_SEGURADO = string.IsNullOrWhiteSpace(dta.V0SEG_LOT_EMP_SEGURADO) ? "-1" : "0";

            return dta;
        }

    }
}