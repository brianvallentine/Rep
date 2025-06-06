using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Dclgens;
using Code;
using static Code.VE2640B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VE2640B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VE2640B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VE2640B_C1_PARGEREM

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "H_APOLICES_RAMO_EMISSOR" , ""},
                { "PARGEREM_DIA_FATURAMENTO" , ""},
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE2640B_C1_PARGEREM", q0);

            #endregion

            #region R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0110_2600_VALIDAR_CONVENIO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CONVESIV_DESCR_ARQUIVO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_2600_VALIDAR_CONVENIO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0802_2600_TRATA_REG_EMP_TP02_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "VGMOVFUN_NUM_PROPOSTA_SIVPF" , ""},
                { "VGMOVFUN_DTH_INI_VIGENCIA" , ""},
                { "VGMOVFUN_NUM_CPF" , ""},
                { "VGMOVFUN_DTH_FIM_VIGENCIA" , ""},
                { "VGMOVFUN_NUM_NIVEL_CARGO" , ""},
                { "VGMOVFUN_NUM_MATRICULA" , ""},
                { "VGMOVFUN_NOM_FUNCIONARIO" , ""},
                { "VGMOVFUN_DTH_NASCIMENTO" , ""},
                { "VGMOVFUN_NUM_IDADE" , ""},
                { "VGMOVFUN_STA_SEXO" , ""},
                { "VGMOVFUN_STA_ESTADO_CIVIL" , ""},
                { "VGMOVFUN_COD_PROFISSAO" , ""},
                { "VGMOVFUN_IND_REPR_EMPRE" , ""},
                { "VGMOVFUN_IND_IMP_DPS" , ""},
                { "VGMOVFUN_DES_MOTIVO" , ""},
                { "VGMOVFUN_NUM_DDD" , ""},
                { "VGMOVFUN_NUM_TELEFONE" , ""},
                { "VGMOVFUN_NUM_RG" , ""},
                { "VGMOVFUN_COD_ORGAO_RG" , ""},
                { "VGMOVFUN_COD_UF_ORGAO_RG" , ""},
                { "VGMOVFUN_DTH_EMISSAO_RG" , ""},
                { "VGMOVFUN_STA_FUNCIONARIO" , ""},
                { "VGMOVFUN_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0802_2600_TRATA_REG_EMP_TP02_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R0838_2600_TRATA_CNPJ_FILIAL_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "VG133_NUM_APOLICE" , ""},
                { "VG133_COD_SUBGRUPO" , ""},
                { "VG133_NUM_CNPJ" , ""},
                { "VG133_SEQ_ESTIP_VINC" , ""},
                { "VG133_STA_ATIVO" , ""},
                { "VG133_COD_USUARIO" , ""},
                { "VG133_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0838_2600_TRATA_CNPJ_FILIAL_DB_INSERT_1_Insert1", q4);

            #endregion

            #region R0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "APOLICOR_NUM_APOLICE" , ""},
                { "APOLICOR_RAMO_COBERTURA" , ""},
                { "APOLICOR_MODALI_COBERTURA" , ""},
                { "APOLICOR_COD_CORRETOR" , ""},
                { "APOLICOR_COD_SUBGRUPO" , ""},
                { "APOLICOR_DATA_INIVIGENCIA" , ""},
                { "APOLICOR_DATA_TERVIGENCIA" , ""},
                { "APOLICOR_PCT_PART_CORRETOR" , ""},
                { "APOLICOR_PCT_COM_CORRETOR" , ""},
                { "APOLICOR_TIPO_COMISSAO" , ""},
                { "APOLICOR_IND_CORRETOR_PRIN" , ""},
                { "APOLICOR_COD_EMPRESA" , ""},
                { "APOLICOR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R0846_2600_TRATA_FAIXAETA_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "FAIXAETA_NUM_APOLICE" , ""},
                { "FAIXAETA_COD_SUBGRUPO" , ""},
                { "FAIXAETA_FAIXA" , ""},
                { "FAIXAETA_IDADE_INICIAL" , ""},
                { "FAIXAETA_IDADE_FINAL" , ""},
                { "FAIXAETA_TAXA_VG" , ""},
                { "FAIXAETA_COD_EMPRESA" , ""},
                { "FAIXAETA_DATA_INIVIGENCIA" , ""},
                { "FAIXAETA_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0846_2600_TRATA_FAIXAETA_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R0854_2600_TRATA_VGSOLFAT_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_DATA_SOLICITACAO" , ""},
                { "VGSOLFAT_DIA_DEBITO" , ""},
                { "VGSOLFAT_OPCAOPAG" , ""},
                { "VGSOLFAT_QUANT_VIDAS" , ""},
                { "VGSOLFAT_CAP_BAS_SEGURADO" , ""},
                { "VGSOLFAT_PRM_VG" , ""},
                { "VGSOLFAT_PRM_AP" , ""},
                { "VGSOLFAT_DTVENCTO_FATURA" , ""},
                { "VGSOLFAT_COD_FONTE" , ""},
                { "VGSOLFAT_NUM_TITULO" , ""},
                { "VGSOLFAT_DT_QUITBCO_TITULO" , ""},
                { "VGSOLFAT_VALOR_TITULO" , ""},
                { "VGSOLFAT_SIT_SOLICITA" , ""},
                { "VGSOLFAT_COD_USUARIO" , ""},
                { "VGSOLFAT_AGECTADEB" , ""},
                { "VGSOLFAT_OPRCTADEB" , ""},
                { "VGSOLFAT_NUMCTADEB" , ""},
                { "VGSOLFAT_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0854_2600_TRATA_VGSOLFAT_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R0894_2600_INSERE_PESSOFIS_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""},
                { "PESSOFIS_CPF" , ""},
                { "PESSOFIS_SEXO" , ""},
                { "PESSOFIS_COD_USUARIO" , ""},
                { "PESSOFIS_ESTADO_CIVIL" , ""},
                { "PESSOFIS_NUM_IDENTIDADE" , ""},
                { "PESSOFIS_ORGAO_EXPEDIDOR" , ""},
                { "PESSOFIS_UF_EXPEDIDORA" , ""},
                { "PESSOFIS_COD_CBO" , ""},
                { "PESSOFIS_TIPO_IDENT_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0894_2600_INSERE_PESSOFIS_DB_INSERT_1_Insert1", q8);

            #endregion

            #region VE2640B_C2_TERMONIVEL

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "VGTERNIV_NUM_PROPOSTA_SIVPF" , ""},
                { "VGTERNIV_DTH_INI_VIGENCIA" , ""},
                { "VGTERNIV_NUM_NIVEL_CARGO" , ""},
                { "VGTERNIV_DTH_FIM_VIGENCIA" , ""},
                { "VGTERNIV_IMP_SEGURADA" , ""},
                { "VGTERNIV_VLR_PRM_INDIVIDUAL" , ""},
                { "VGTERNIV_QTD_VIDAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE2640B_C2_TERMONIVEL", q9);

            #endregion

            #region VE2640B_C4_SOLICITA

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_DATA_SOLICITACAO" , ""},
                { "VGSOLFAT_DIA_DEBITO" , ""},
                { "VGSOLFAT_OPCAOPAG" , ""},
                { "VGSOLFAT_QUANT_VIDAS" , ""},
                { "VGSOLFAT_CAP_BAS_SEGURADO" , ""},
                { "VGSOLFAT_PRM_VG" , ""},
                { "VGSOLFAT_PRM_AP" , ""},
                { "H_VGSOLFAT_PRM_TOTAL" , ""},
                { "VGSOLFAT_DTVENCTO_FATURA" , ""},
                { "VGSOLFAT_COD_FONTE" , ""},
                { "VGSOLFAT_NUM_TITULO" , ""},
                { "VGSOLFAT_DT_QUITBCO_TITULO" , ""},
                { "VGSOLFAT_VALOR_TITULO" , ""},
                { "VGSOLFAT_COD_USUARIO" , ""},
                { "VGSOLFAT_AGECTADEB" , ""},
                { "VGSOLFAT_OPRCTADEB" , ""},
                { "VGSOLFAT_NUMCTADEB" , ""},
                { "VGSOLFAT_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE2640B_C4_SOLICITA", q10);

            #endregion

            #region R0930_2600_UPDATE_VGSOLICITA_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_COD_USUARIO" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0930_2600_UPDATE_VGSOLICITA_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_TERMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1", q12);

            #endregion

            #region VE2640B_C5_RCAPCOMP

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_HORA_OPERACAO" , ""},
                { "RCAPCOMP_SIT_REGISTRO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE2640B_C5_RCAPCOMP", q13);

            #endregion

            #region VE2640B_C6_VGRAMOCOMP

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "VG081_NUM_APOLICE" , ""},
                { "VG081_COD_SUBGRUPO" , ""},
                { "VG081_COD_GRUPO_SUSEP" , ""},
                { "VG081_RAMO_EMISSOR" , ""},
                { "VG081_COD_MODALIDADE" , ""},
                { "VG081_DTH_INI_VIGENCIA" , ""},
                { "VG081_COD_OPCAO_COBERTURA" , ""},
                { "VG081_NUM_IDADE_INICIAL" , ""},
                { "VG081_NUM_IDADE_FINAL" , ""},
                { "VG081_VLR_PERC_PREMIO" , ""},
                { "VG081_COD_USUARIO" , ""},
                { "VG081_DTH_ATUALIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE2640B_C6_VGRAMOCOMP", q14);

            #endregion

            #region R1123_2610_UPDATE_V1RCAPCOMP_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_HORA_OPERACAO" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1123_2610_UPDATE_V1RCAPCOMP_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R1124_2610_INSERT_V1RCAPCOMP_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "H_DT_MOV_ABERTO_2610" , ""},
                { "RCAPCOMP_SIT_REGISTRO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
                { "RCAPCOMP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1124_2610_INSERT_V1RCAPCOMP_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R1125_2610_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1125_2610_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R1300_2610_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "H_NUM_CERTIFICADO" , ""},
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_2610_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1", q18);

            #endregion

            #region R2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "VG081_VLR_PERC_PREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1", q19);

            #endregion

            #region R2100_2610_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "VGSOLFAT_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_2610_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R2400_2610_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_2610_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R2500_2610_INSERT_PARCELVA_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "PARCEVID_OPCAO_PAGAMENTO" , ""},
                { "PARCEVID_SIT_REGISTRO" , ""},
                { "PARCEVID_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_2610_INSERT_PARCELVA_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R2600_2610_INSERT_HISTCOBVA_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "COBHISVI_PRM_TOTAL" , ""},
                { "PARCEVID_OPCAO_PAGAMENTO" , ""},
                { "COBHISVI_SIT_REGISTRO" , ""},
                { "COBHISVI_OCORR_HISTORICO" , ""},
                { "COBHISVI_BCO_AVISO" , ""},
                { "COBHISVI_AGE_AVISO" , ""},
                { "COBHISVI_NUM_AVISO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_2610_INSERT_HISTCOBVA_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R2800_2610_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "COBHISVI_PRM_TOTAL" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_TIPLANC" , ""},
                { "HISLANCT_OCORR_HISTORICO" , ""},
                { "HISLANCT_CODCONV" , ""},
                { "HISLANCT_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_2610_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1", q24);

            #endregion

            #region R2950_2610_INSERT_VGHISTCONT_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "H_GRUPO_SUSEP" , ""},
                { "H_COD_RAMO" , ""},
                { "VG082_COD_MODALIDADE" , ""},
                { "VG082_COD_COBERTURA" , ""},
                { "H_PREMIO_CONJ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2950_2610_INSERT_VGHISTCONT_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R2960_2610_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_TAXA_AP_MORACID" , ""},
                { "CONDITEC_TAXA_AP_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_AMDS" , ""},
                { "CONDITEC_TAXA_AP_DH" , ""},
                { "CONDITEC_TAXA_AP_DIT" , ""},
                { "CONDITEC_TAXA_AP" , ""},
                { "CONDITEC_CARREGA_PRINCIPAL" , ""},
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_CARREGA_FILHOS" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2960_2610_SELECT_CONDITEC_DB_SELECT_1_Query1", q26);

            #endregion

            #region R3000_2610_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "CONVEVG_NUM_APOLICE" , ""},
                { "CONVEVG_CODSUBES" , ""},
                { "CONVEVG_COD_SEGURO" , ""},
                { "CONVEVG_COD_AJUSTE" , ""},
                { "CONVEVG_COD_COMISSAO" , ""},
                { "CONVEVG_COD_NAOACEITE" , ""},
                { "CONVEVG_CODUSU" , ""},
                { "CONVEVG_COD_CONV_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_2610_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R4070_2610_UPDT_SUBGRUPO_VGAP_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_SIT_REGISTRO" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4070_2610_UPDT_SUBGRUPO_VGAP_DB_UPDATE_1_Update1", q28);

            #endregion

            #region R4072_2610_UPDT_TERMO_ADESAO_DB_UPDATE_1_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4072_2610_UPDT_TERMO_ADESAO_DB_UPDATE_1_Update1", q29);

            #endregion

            #region R4250_00_SELECT_PLANVG_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_QTTITCAP" , ""},
                { "PLAVAVGA_VLTITCAP" , ""},
                { "PLAVAVGA_VLCUSTCAP" , ""},
                { "PRODUVG_COD_RUBRICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4250_00_SELECT_PLANVG_DB_SELECT_1_Query1", q30);

            #endregion

            #region R4400_2610_INSERT_COMFEDCA_DB_INSERT_1_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , ""},
                { "H_DT_MOV_ABERTO_2610" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_2610_INSERT_COMFEDCA_DB_INSERT_1_Insert1", q31);

            #endregion

            #region R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , ""},
                { "PARM_COD_EMPR_CAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q32);

            #endregion

            #region DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1", q33);

            #endregion

            #region DB005_ACESSA_RCAPS_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB005_ACESSA_RCAPS_DB_SELECT_1_Query1", q34);

            #endregion

            #region DB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "H_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1", q35);

            #endregion

            #region DB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1_Query1", q36);

            #endregion

            #region DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1", q37);

            #endregion

            #region DB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1", q38);

            #endregion

            #region DB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1_Update1", q39);

            #endregion

            #region DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1", q40);

            #endregion

            #region DB018_ALTERA_NUMERO_OUTROS_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB018_ALTERA_NUMERO_OUTROS_DB_UPDATE_1_Update1", q41);

            #endregion

            #region DB020_INCLUI_CLIENTES_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB020_INCLUI_CLIENTES_DB_INSERT_1_Insert1", q42);

            #endregion

            #region DB022_ALTERA_CLIENTE_EMAIL_DB_UPDATE_1_Update1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""},
                { "CLIENTES_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB022_ALTERA_CLIENTE_EMAIL_DB_UPDATE_1_Update1", q43);

            #endregion

            #region DB024_INCLUI_CLIENTE_EMAIL_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_COD_CLIENTE" , ""},
                { "CLIENEMA_SEQ_EMAIL" , ""},
                { "CLIENEMA_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB024_INCLUI_CLIENTE_EMAIL_DB_INSERT_1_Insert1", q44);

            #endregion

            #region DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1", q45);

            #endregion

            #region DB028_INCLUI_ENDERECOS_DB_INSERT_1_Insert1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , ""},
                { "ENDERECO_COD_ENDERECO" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_TELEX" , ""},
                { "ENDERECO_SIT_REGISTRO" , ""},
                { "ENDERECO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB028_INCLUI_ENDERECOS_DB_INSERT_1_Insert1", q46);

            #endregion

            #region DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1", q47);

            #endregion

            #region DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1", q48);

            #endregion

            #region DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1", q49);

            #endregion

            #region DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1", q50);

            #endregion

            #region DB038_INCLUI_TERMO_ADESAO_DB_INSERT_1_Insert1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , ""},
                { "TERMOADE_COD_SUBGRUPO" , ""},
                { "TERMOADE_DATA_ADESAO" , ""},
                { "TERMOADE_COD_AGENCIA_OP" , ""},
                { "TERMOADE_NUM_MATRICULA_VEN" , ""},
                { "TERMOADE_CODPDTVEN" , ""},
                { "TERMOADE_PCCOMVEN" , ""},
                { "TERMOADE_PCADIANTVEN" , ""},
                { "TERMOADE_COD_AGENCIA_VEN" , ""},
                { "TERMOADE_OPERACAO_CONTA_VEN" , ""},
                { "TERMOADE_NUM_CONTA_VEN" , ""},
                { "TERMOADE_DIG_CONTA_VEN" , ""},
                { "TERMOADE_NUM_MATRICULA_GER" , ""},
                { "TERMOADE_CODPDTGER" , ""},
                { "TERMOADE_PCCOMGER" , ""},
                { "TERMOADE_COD_AGENCIA_GER" , ""},
                { "TERMOADE_OPERACAO_CONTA_GER" , ""},
                { "TERMOADE_NUM_CONTA_GER" , ""},
                { "TERMOADE_DIG_CONTA_GER" , ""},
                { "TERMOADE_NUM_MATRICULA_SUR" , ""},
                { "TERMOADE_CODPDTSUR" , ""},
                { "TERMOADE_PCCOMSUR" , ""},
                { "TERMOADE_NUM_MATRICULA_GCO" , ""},
                { "TERMOADE_CODPDTGCO" , ""},
                { "TERMOADE_PCCOMGCO" , ""},
                { "TERMOADE_MODALIDADE_CAPITAL" , ""},
                { "TERMOADE_TIPO_PLANO" , ""},
                { "TERMOADE_IND_PLANO_ASSOCIAD" , ""},
                { "TERMOADE_COD_PLANO_VGAPC" , ""},
                { "TERMOADE_COD_PLANO_APC" , ""},
                { "TERMOADE_VAL_CONTRATADO" , ""},
                { "TERMOADE_VAL_COMISSAO_ADIAN" , ""},
                { "TERMOADE_QUANT_VIDAS" , ""},
                { "TERMOADE_TIPO_COBERTURA" , ""},
                { "TERMOADE_PERI_PAGAMENTO" , ""},
                { "TERMOADE_TIPO_CORRECAO" , ""},
                { "TERMOADE_PERIODO_CORRECAO" , ""},
                { "TERMOADE_COD_MOEDA_IMP" , ""},
                { "TERMOADE_COD_MOEDA_PRM" , ""},
                { "TERMOADE_COD_CLIENTE" , ""},
                { "TERMOADE_OCORR_ENDERECO" , ""},
                { "TERMOADE_COD_CORRETOR" , ""},
                { "TERMOADE_PCCOMCOR" , ""},
                { "TERMOADE_COD_ADMINISTRADOR" , ""},
                { "TERMOADE_PCCOMADM" , ""},
                { "TERMOADE_COD_USUARIO" , ""},
                { "TERMOADE_DATA_INCLUSAO" , ""},
                { "TERMOADE_SITUACAO" , ""},
                { "TERMOADE_NUM_PROPOSTA" , ""},
                { "TERMOADE_NUM_RCAP" , ""},
                { "TERMOADE_DATA_RCAP" , ""},
                { "TERMOADE_VAL_RCAP" , ""},
                { "TERMOADE_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB038_INCLUI_TERMO_ADESAO_DB_INSERT_1_Insert1", q51);

            #endregion

            #region DB040_INCLUI_VG_COMPL_TERMO_DB_INSERT_1_Insert1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_TERMO" , ""},
                { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , ""},
                { "VGCOMTRO_DTH_DIA_DEBITO" , ""},
                { "VGCOMTRO_COD_AGENCIA_DEB" , ""},
                { "VGCOMTRO_OPERACAO_CONTA_DEB" , ""},
                { "VGCOMTRO_NUM_CONTA_DEBITO" , ""},
                { "VGCOMTRO_DIG_CONTA_DEBITO" , ""},
                { "VGCOMTRO_DTH_LIBERACAO" , ""},
                { "VGCOMTRO_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB040_INCLUI_VG_COMPL_TERMO_DB_INSERT_1_Insert1", q52);

            #endregion

            #region VE2640B_C3_VGMOVFUN

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "VGMOVFUN_NUM_PROPOSTA_SIVPF" , ""},
                { "VGMOVFUN_DTH_INI_VIGENCIA" , ""},
                { "VGMOVFUN_NUM_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE2640B_C3_VGMOVFUN", q53);

            #endregion

            #region DB044_ALTERA_PORTE_CLIENTES_DB_UPDATE_1_Update1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_PORTE_EMP" , ""},
                { "CLIENTES_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB044_ALTERA_PORTE_CLIENTES_DB_UPDATE_1_Update1", q54);

            #endregion

            #region DB046_INCLUI_VG_TERMO_NIVEL_DB_INSERT_1_Insert1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "VGTERNIV_NUM_PROPOSTA_SIVPF" , ""},
                { "VGTERNIV_DTH_INI_VIGENCIA" , ""},
                { "VGTERNIV_NUM_NIVEL_CARGO" , ""},
                { "VGTERNIV_DTH_FIM_VIGENCIA" , ""},
                { "VGTERNIV_IMP_SEGURADA" , ""},
                { "VGTERNIV_VLR_PRM_INDIVIDUAL" , ""},
                { "VGTERNIV_COD_USUARIO" , ""},
                { "VGTERNIV_QTD_VIDAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB046_INCLUI_VG_TERMO_NIVEL_DB_INSERT_1_Insert1", q55);

            #endregion

            #region DB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_IND_TP_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1", q56);

            #endregion

            #region DB050_ALTERA_PROP_SASSE_VIDA_DB_UPDATE_1_Update1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""},
                { "PROPSSVD_NUM_IDENTIFICACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB050_ALTERA_PROP_SASSE_VIDA_DB_UPDATE_1_Update1", q57);

            #endregion

            #region DB052_INCLUI_VG_ANDAMENTO_PROP_DB_INSERT_1_Insert1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "VG078_NUM_CERTIFICADO" , ""},
                { "VG078_DES_ANDAMENTO" , ""},
                { "VG078_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB052_INCLUI_VG_ANDAMENTO_PROP_DB_INSERT_1_Insert1", q58);

            #endregion

            #region DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1", q59);

            #endregion

            #region DB056_ACESSA_APOLICES_DB_SELECT_1_Query1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB056_ACESSA_APOLICES_DB_SELECT_1_Query1", q60);

            #endregion

            #region DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1", q61);

            #endregion

            #region DB060_ALTERA_TERMO_ADESAO_DB_UPDATE_1_Update1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_MODALIDADE_CAPITAL" , ""},
                { "TERMOADE_VAL_CONTRATADO" , ""},
                { "TERMOADE_PERI_PAGAMENTO" , ""},
                { "TERMOADE_COD_MOEDA_IMP" , ""},
                { "TERMOADE_COD_MOEDA_PRM" , ""},
                { "TERMOADE_COD_SUBGRUPO" , ""},
                { "TERMOADE_COD_CORRETOR" , ""},
                { "TERMOADE_NUM_APOLICE" , ""},
                { "TERMOADE_QUANT_VIDAS" , ""},
                { "TERMOADE_PCCOMGER" , ""},
                { "TERMOADE_PCCOMVEN" , ""},
                { "TERMOADE_PCCOMCOR" , ""},
                { "TERMOADE_NUM_TERMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB060_ALTERA_TERMO_ADESAO_DB_UPDATE_1_Update1", q62);

            #endregion

            #region DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_DES_GARANTIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1", q63);

            #endregion

            #region DB064_INCLUI_VG_COBER_TERMO_DB_INSERT_1_Insert1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "VGCOBTER_NUM_PROPOSTA_SIVPF" , ""},
                { "VGCOBTER_DTH_INI_VIGENCIA" , ""},
                { "VGCOBTER_COD_GARANTIA" , ""},
                { "VGCOBTER_DTH_FIM_VIGENCIA" , ""},
                { "VGCOBTER_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB064_INCLUI_VG_COBER_TERMO_DB_INSERT_1_Insert1", q64);

            #endregion

            #region DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1", q65);

            #endregion

            #region DB068_INCLUI_SUBGRUPOSVGAP_DB_INSERT_1_Insert1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_NUM_APOLICE" , ""},
                { "SUBGVGAP_COD_SUBGRUPO" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_CLASSE_APOLICE" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
                { "SUBGVGAP_FORMA_FATURAMENTO" , ""},
                { "SUBGVGAP_FORMA_AVERBACAO" , ""},
                { "SUBGVGAP_TIPO_PLANO" , ""},
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_PERI_RENOVACAO" , ""},
                { "SUBGVGAP_PERI_RETROATI_INC" , ""},
                { "SUBGVGAP_PERI_RETROATI_CAN" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
                { "SUBGVGAP_OCORR_END_COBRAN" , ""},
                { "SUBGVGAP_BCO_COBRANCA" , ""},
                { "SUBGVGAP_AGE_COBRANCA" , ""},
                { "SUBGVGAP_DAC_COBRANCA" , ""},
                { "SUBGVGAP_TIPO_COBRANCA" , ""},
                { "SUBGVGAP_COD_PAG_ANGARIACAO" , ""},
                { "SUBGVGAP_PCT_CONJUGE_VG" , ""},
                { "SUBGVGAP_PCT_CONJUGE_AP" , ""},
                { "SUBGVGAP_OPCAO_COBERTURA" , ""},
                { "SUBGVGAP_OPCAO_CORRETAGEM" , ""},
                { "SUBGVGAP_IND_CONSISTE_MATRI" , ""},
                { "SUBGVGAP_IND_PLANO_ASSOCIA" , ""},
                { "SUBGVGAP_SIT_REGISTRO" , ""},
                { "SUBGVGAP_OPCAO_CONJUGE" , ""},
                { "SUBGVGAP_COD_EMPRESA" , ""},
                { "SUBGVGAP_TIPO_SUBGRUPO" , ""},
                { "SUBGVGAP_DATA_INCLUSAO" , ""},
                { "SUBGVGAP_DATA_INIVIGENCIA" , ""},
                { "SUBGVGAP_DATA_TERVIGENCIA" , ""},
                { "SUBGVGAP_IND_IOF" , ""},
                { "SUBGVGAP_TIPO_POSTAGEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB068_INCLUI_SUBGRUPOSVGAP_DB_INSERT_1_Insert1", q66);

            #endregion

            #region DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1

            var q67 = new DynamicData();
            q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1", q67);

            #endregion

            #region DB070_INCLUI_CONDICOESTECNICAS_DB_INSERT_1_Insert1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_NUM_APOLICE" , ""},
                { "CONDITEC_COD_SUBGRUPO" , ""},
                { "CONDITEC_QTD_SAL_MORNATU" , ""},
                { "CONDITEC_QTD_SAL_MORACID" , ""},
                { "CONDITEC_QTD_SAL_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_MORACID" , ""},
                { "CONDITEC_TAXA_AP_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_AMDS" , ""},
                { "CONDITEC_TAXA_AP_DH" , ""},
                { "CONDITEC_TAXA_AP_DIT" , ""},
                { "CONDITEC_TAXA_AP" , ""},
                { "CONDITEC_CARREGA_PRINCIPAL" , ""},
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_CARREGA_FILHOS" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
                { "CONDITEC_GARAN_ADIC_HD" , ""},
                { "CONDITEC_TAXA_DESPESA_ADM" , ""},
                { "CONDITEC_TAXA_IRB" , ""},
                { "CONDITEC_LIM_CAP_MORNATU" , ""},
                { "CONDITEC_LIM_CAP_MORACID" , ""},
                { "CONDITEC_LIM_CAP_INVAPER" , ""},
                { "CONDITEC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB070_INCLUI_CONDICOESTECNICAS_DB_INSERT_1_Insert1", q68);

            #endregion

            #region DB072_INCLUI_V0RELATORIOS_DB_INSERT_1_Insert1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
                { "H_DT_MOV_ABERTO_2600" , ""},
                { "H_COD_RELATORIO" , ""},
                { "VGPROSIA_NUM_APOLICE" , ""},
                { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , ""},
                { "TERMOADE_NUM_TERMO" , ""},
                { "SUBGVGAP_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB072_INCLUI_V0RELATORIOS_DB_INSERT_1_Insert1", q69);

            #endregion

            #region DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1", q70);

            #endregion

            #region DB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1", q71);

            #endregion

            #region DB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "VGTERNIV_QTD_VIDAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1", q72);

            #endregion

            #region DB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
                { "VGFUNCOB_VLR_PREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1", q73);

            #endregion

            #region DB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1_Update1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "VGFUNCOB_VLR_PREMIO" , ""},
                { "VGTERNIV_QTD_VIDAS" , ""},
                { "VGTERNIV_NUM_PROPOSTA_SIVPF" , ""},
                { "VGTERNIV_DTH_INI_VIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1_Update1", q74);

            #endregion

            #region DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1", q75);

            #endregion

            #region DB090_INCLUI_VGREPRESLEGAL_DB_INSERT_1_Insert1

            var q76 = new DynamicData();
            q76.AddDynamic(new Dictionary<string, string>{
                { "VG093_COD_PESSOA" , ""},
                { "VG093_NUM_OCORR_HIST" , ""},
                { "VG093_NUM_APOLICE" , ""},
                { "VG093_COD_SUBGRUPO" , ""},
                { "VG093_VLR_RENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB090_INCLUI_VGREPRESLEGAL_DB_INSERT_1_Insert1", q76);

            #endregion

            #region DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1

            var q77 = new DynamicData();
            q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1", q77);

            #endregion

            #region DB094_INCLUI_PESSOA_DB_INSERT_1_Insert1

            var q78 = new DynamicData();
            q78.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_USUARIO" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
                { "PESSOA_SIGLA_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB094_INCLUI_PESSOA_DB_INSERT_1_Insert1", q78);

            #endregion

            #region DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1

            var q79 = new DynamicData();
            q79.AddDynamic(new Dictionary<string, string>{
                { "VG092_DTA_FAT_ANUAL" , ""},
                { "VG092_VLR_FAT_ANUAL" , ""},
                { "VG092_DTA_CONSTITUICAO" , ""},
                { "VG092_COD_CNAE_ATIVIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1", q79);

            #endregion

            #region DB098_INCLUI_VGCOMPLCLIEMP_DB_INSERT_1_Insert1

            var q80 = new DynamicData();
            q80.AddDynamic(new Dictionary<string, string>{
                { "VG092_COD_CLIENTE" , ""},
                { "VG092_DTA_FAT_ANUAL" , ""},
                { "VG092_VLR_FAT_ANUAL" , ""},
                { "VG092_DTA_CONSTITUICAO" , ""},
                { "VG092_COD_CNAE_ATIVIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB098_INCLUI_VGCOMPLCLIEMP_DB_INSERT_1_Insert1", q80);

            #endregion

            #region DB100_ACESSA_RCAPS_TITULO_DB_SELECT_1_Query1

            var q81 = new DynamicData();
            q81.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
                { "RCAPS_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB100_ACESSA_RCAPS_TITULO_DB_SELECT_1_Query1", q81);

            #endregion

            #region DB102_ACESSA_RCAPCOMPL_A1_DB_SELECT_1_Query1

            var q82 = new DynamicData();
            q82.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB102_ACESSA_RCAPCOMPL_A1_DB_SELECT_1_Query1", q82);

            #endregion

            #region DB104_ACESSA_SUBGRUPOS_VGAP_DB_SELECT_1_Query1

            var q83 = new DynamicData();
            q83.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_FONTE" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
                { "SUBGVGAP_AGE_COBRANCA" , ""},
                { "SUBGVGAP_OPCAO_COBERTURA" , ""},
                { "SUBGVGAP_DATA_INIVIGENCIA" , ""},
                { "SUBGVGAP_TIPO_SUBGRUPO" , ""},
                { "SUBGVGAP_IND_IOF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB104_ACESSA_SUBGRUPOS_VGAP_DB_SELECT_1_Query1", q83);

            #endregion

            #region DB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1

            var q84 = new DynamicData();
            q84.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_AGE_COBRANCA" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1", q84);

            #endregion

            #region DB108_ACESSA_PROPOSTAS_VA_DB_SELECT_1_Query1

            var q85 = new DynamicData();
            q85.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB108_ACESSA_PROPOSTAS_VA_DB_SELECT_1_Query1", q85);

            #endregion

            #region DB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1

            var q86 = new DynamicData();
            q86.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , ""},
                { "TERMOADE_NUM_MATRICULA_VEN" , ""},
                { "TERMOADE_COD_AGENCIA_VEN" , ""},
                { "TERMOADE_OPERACAO_CONTA_VEN" , ""},
                { "TERMOADE_NUM_CONTA_VEN" , ""},
                { "TERMOADE_DIG_CONTA_VEN" , ""},
                { "TERMOADE_COD_PLANO_VGAPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1", q86);

            #endregion

            #region DB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1

            var q87 = new DynamicData();
            q87.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , ""},
                { "VGCOMTRO_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1", q87);

            #endregion

            #region DB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1

            var q88 = new DynamicData();
            q88.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_VAL_COMPRA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1", q88);

            #endregion

            #region DB116_ACESSA_FATURAS_COUNT_DB_SELECT_1_Query1

            var q89 = new DynamicData();
            q89.AddDynamic(new Dictionary<string, string>{
                { "FATURAS_NUM_FATURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB116_ACESSA_FATURAS_COUNT_DB_SELECT_1_Query1", q89);

            #endregion

            #region DB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1_Update1

            var q90 = new DynamicData();
            q90.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_SIT_SOLICITA" , ""},
                { "JVPRD8205" , ""},
                { "JVPRD8209" , ""},
                { "JVPRD9329" , ""},
                { "JVPRD9343" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1_Update1", q90);

            #endregion

            #region DB120_ALTERA_VGCOMPLTERMO_DB_UPDATE_1_Update1

            var q91 = new DynamicData();
            q91.AddDynamic(new Dictionary<string, string>{
                { "H_DT_MOV_ABERTO_2610" , ""},
                { "TERMOADE_NUM_TERMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB120_ALTERA_VGCOMPLTERMO_DB_UPDATE_1_Update1", q91);

            #endregion

            #region DB122_ALTERA_SUBGRUPOSVGAP_DB_UPDATE_1_Update1

            var q92 = new DynamicData();
            q92.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_FONTE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB122_ALTERA_SUBGRUPOSVGAP_DB_UPDATE_1_Update1", q92);

            #endregion

            #region DB124_ALTERA_COMISSOES_DB_UPDATE_1_Update1

            var q93 = new DynamicData();
            q93.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_FONTE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB124_ALTERA_COMISSOES_DB_UPDATE_1_Update1", q93);

            #endregion

            #region DB126_ACESSA_RCAPS_FONTE_DB_SELECT_1_Query1

            var q94 = new DynamicData();
            q94.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB126_ACESSA_RCAPS_FONTE_DB_SELECT_1_Query1", q94);

            #endregion

            #region DB128_ALTERA_RCAPS_DB_UPDATE_1_Update1

            var q95 = new DynamicData();
            q95.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB128_ALTERA_RCAPS_DB_UPDATE_1_Update1", q95);

            #endregion

            #region DB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1

            var q96 = new DynamicData();
            q96.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1", q96);

            #endregion

            #region DB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1

            var q97 = new DynamicData();
            q97.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO" , ""},
                { "VGPROSIA_COD_PRODUTO_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1", q97);

            #endregion

            #region DB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1

            var q98 = new DynamicData();
            q98.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_COD_CORRESP_BANC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1", q98);

            #endregion

            #region DB136_INCLUI_PROPOSTASVA_DB_INSERT_1_Insert1

            var q99 = new DynamicData();
            q99.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "TERMOADE_COD_AGENCIA_VEN" , ""},
                { "TERMOADE_OPERACAO_CONTA_VEN" , ""},
                { "TERMOADE_NUM_CONTA_VEN" , ""},
                { "TERMOADE_DIG_CONTA_VEN" , ""},
                { "TERMOADE_NUM_MATRICULA_VEN" , ""},
                { "H_DT_MOV_ABERTO_2610" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "PROPOVA_INFO_COMPLEMENTAR" , ""},
                { "H_FAIXA_RENDA" , ""},
                { "PROPOVA_COD_CORRESP_BANC" , ""},
                { "PROPOVA_STA_ANTECIPACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB136_INCLUI_PROPOSTASVA_DB_INSERT_1_Insert1", q99);

            #endregion

            #region DB138_ACESSA_BANCOS_DB_SELECT_1_Query1

            var q100 = new DynamicData();
            q100.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB138_ACESSA_BANCOS_DB_SELECT_1_Query1", q100);

            #endregion

            #region DB140_ALTERA_BANCOS_DB_UPDATE_1_Update1

            var q101 = new DynamicData();
            q101.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB140_ALTERA_BANCOS_DB_UPDATE_1_Update1", q101);

            #endregion

            #region DB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1

            var q102 = new DynamicData();
            q102.AddDynamic(new Dictionary<string, string>{
                { "FATURAS_NUM_FATURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1", q102);

            #endregion

            #region DB142_ACESSA_FATURAS_DB_SELECT_1_Query1

            var q103 = new DynamicData();
            q103.AddDynamic(new Dictionary<string, string>{
                { "FATURAS_NUM_ENDOSSO" , ""},
                { "FATURAS_DATA_FATURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB142_ACESSA_FATURAS_DB_SELECT_1_Query1", q103);

            #endregion

            #region DB144_INCLUI_HISCONTPARCEL_DB_INSERT_1_Insert1

            var q104 = new DynamicData();
            q104.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
                { "H_DT_MOV_ABERTO_2610" , ""},
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
                { "HISCONPA_DTFATUR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB144_INCLUI_HISCONTPARCEL_DB_INSERT_1_Insert1", q104);

            #endregion

            #region DB146_ACESSA_PRODUTO_DB_SELECT_1_Query1

            var q105 = new DynamicData();
            q105.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB146_ACESSA_PRODUTO_DB_SELECT_1_Query1", q105);

            #endregion

            #region DB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1

            var q106 = new DynamicData();
            q106.AddDynamic(new Dictionary<string, string>{
                { "VGCOBTER_COD_GARANTIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1", q106);

            #endregion

            #region DB150_INCLUI_PRODUTOSVG_DB_INSERT_1_Insert1

            var q107 = new DynamicData();
            q107.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NUM_APOLICE" , ""},
                { "PRODUVG_COD_SUBGRUPO" , ""},
                { "PRODUVG_ID_SISTEMA" , ""},
                { "PRODUVG_COD_PRODUTO_AZUL" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PRODUVG_NOME_PRODUTO" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "PRODUVG_DIAS_INICIO_VIGENC" , ""},
                { "PRODUVG_DATA_MINVIGENCIA" , ""},
                { "PRODUVG_DATA_MAXVIGENCIA" , ""},
                { "PRODUVG_SIT_PLANO_CEF" , ""},
                { "PRODUVG_OPCAO_PAGAMENTO" , ""},
                { "PRODUVG_COD_CEDENTE" , ""},
                { "PRODUVG_OPC_AGENCTO_SUREG" , ""},
                { "PRODUVG_OPCAO_CAPITALIZ" , ""},
                { "PRODUVG_COD_SERIE" , ""},
                { "PRODUVG_NUM_SEQ_TITULO" , ""},
                { "PRODUVG_NUM_MALA_DIRETA" , ""},
                { "PRODUVG_RAMO" , ""},
                { "PRODUVG_CANCELA_ANTIGO" , ""},
                { "PRODUVG_TEM_CDG" , ""},
                { "PRODUVG_TEM_SAF" , ""},
                { "PRODUVG_DIA_FATURA" , ""},
                { "PRODUVG_ESTR_COBR" , ""},
                { "PRODUVG_ESTR_EMISS" , ""},
                { "PRODUVG_ORIG_PRODU" , ""},
                { "PRODUVG_CODRELAT" , ""},
                { "PRODUVG_ROT_SAF" , ""},
                { "PRODUVG_COD_PRODUTO_EA" , ""},
                { "PRODUVG_COBERADIC_PREMIO" , ""},
                { "PRODUVG_CUSTOCAP_TOTAL" , ""},
                { "PRODUVG_DESCONTO_ADESAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB150_INCLUI_PRODUTOSVG_DB_INSERT_1_Insert1", q107);

            #endregion

            #region SEGUROS_SZEMNL01_Call1

            var q108 = new DynamicData();
            q108.AddDynamic(new Dictionary<string, string>{
                { "H_SZL01_COD_USUARIO" , ""},
                { "N_SZL01_COD_USUARIO" , ""},
                { "H_SZL01_COD_PROGRAMA" , ""},
                { "N_SZL01_COD_PROGRAMA" , ""},
                { "H_SZL01_DES_MSG_SISTEMA" , ""},
                { "N_SZL01_DES_MSG_SISTEMA" , ""},
                { "H_SZL01_IND_ERRO_LOG" , ""},
                { "N_SZL01_IND_ERRO_LOG" , ""},
                { "H_SZL01_SQLCODE_LOG" , ""},
                { "N_SZL01_SQLCODE_LOG" , ""},
                { "H_SZL01_SQLERRMC_LOG" , ""},
                { "N_SZL01_SQLERRMC_LOG" , ""},
                { "H_SZL01_DES_MSG_RETORNO" , ""},
                { "N_SZL01_DES_MSG_RETORNO" , ""},
                { "H_SZL01_SEQ_LOG_SISTEMA" , ""},
                { "N_SZL01_SEQ_LOG_SISTEMA" , ""},
                { "H_SZL01_IND_ERRO" , ""},
                { "N_SZL01_IND_ERRO" , ""},
                { "H_SZL01_MSG_RET" , ""},
                { "N_SZL01_MSG_RET" , ""},
                { "H_SZL01_NM_TAB" , ""},
                { "N_SZL01_NM_TAB" , ""},
                { "H_SZL01_SQLCODE" , ""},
                { "N_SZL01_SQLCODE" , ""},
                { "H_SZL01_SQLERRMC" , ""},
                { "N_SZL01_SQLERRMC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SEGUROS_SZEMNL01_Call1", q108);

            #endregion

            GEJVS002_Tests.Load_Parameters();

            #endregion
        }

        [Theory]
        [InlineData("REDUZIDO.PRD.VA.D241202.VA0600B.ARQVDEMP", "VE2640B_t1")]
        public static void VE2640B_Tests_Theory(string MOV_VDEMP_FILE_NAME_P, string MOV_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV_SAIDA_FILE_NAME_P = $"{MOV_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1");
                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1", q45);

                #endregion
                #region VE2640B_C4_SOLICITA
                AppSettings.TestSet.DynamicData.Remove("VE2640B_C4_SOLICITA");

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_DATA_SOLICITACAO" , ""},
                { "VGSOLFAT_DIA_DEBITO" , ""},
                { "VGSOLFAT_OPCAOPAG" , ""},
                { "VGSOLFAT_QUANT_VIDAS" , ""},
                { "VGSOLFAT_CAP_BAS_SEGURADO" , ""},
                { "VGSOLFAT_PRM_VG" , ""},
                { "VGSOLFAT_PRM_AP" , ""},
                { "H_VGSOLFAT_PRM_TOTAL" , ""},
                { "VGSOLFAT_DTVENCTO_FATURA" , ""},
                { "VGSOLFAT_COD_FONTE" , ""},
                { "VGSOLFAT_NUM_TITULO" , ""},
                { "VGSOLFAT_DT_QUITBCO_TITULO" , ""},
                { "VGSOLFAT_VALOR_TITULO" , ""},
                { "VGSOLFAT_COD_USUARIO" , ""},
                { "VGSOLFAT_AGECTADEB" , ""},
                { "VGSOLFAT_OPRCTADEB" , ""},
                { "VGSOLFAT_NUMCTADEB" , ""},
                { "VGSOLFAT_DIGCTADEB" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VE2640B_C4_SOLICITA", q10);

                #endregion
                #region DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1");

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "1"}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1", q37);

                #endregion
                #region DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1");
                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1", q40);

                #endregion
                #region DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1");

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            }); q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            }); q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            }); q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            }); q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1", q47);

                #endregion
                #region DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1");

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1", q48);

                #endregion
                #region DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1");

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            }); q49.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            }); q49.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            }); q49.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1", q49);

                #endregion

                #region DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1");

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            }); q50.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            }); q50.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            }); q50.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1", q50);

                #endregion

                #region R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1");

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1", q1);

                #endregion

                #region DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1");

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1", q65);

                #endregion

                #region DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1");

                var q59 = new DynamicData();
                q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1", q59);

                #endregion

                #region DB056_ACESSA_APOLICES_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB056_ACESSA_APOLICES_DB_SELECT_1_Query1");

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB056_ACESSA_APOLICES_DB_SELECT_1_Query1", q60);

                #endregion
                #region DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1");

                var q61 = new DynamicData();
                q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1", q61);

                #endregion

                #region DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1");

                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""}
            }); q70.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""}
            }); q70.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1", q70);

                #endregion

                #region DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1");

                var q63 = new DynamicData();
                q63.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_DES_GARANTIA" , ""}
            }); q63.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_DES_GARANTIA" , ""}
            }); q63.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_DES_GARANTIA" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1", q63);

                #endregion

                #region DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1");

                var q75 = new DynamicData();
                q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1", q75);

                #endregion

                #region DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1");

                var q67 = new DynamicData();
                q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1", q67);

                #endregion
                #region DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1");

                var q79 = new DynamicData();
                q79.AddDynamic(new Dictionary<string, string>{
                { "VG092_DTA_FAT_ANUAL" , ""},
                { "VG092_VLR_FAT_ANUAL" , "0000001172121.29"},
                { "VG092_DTA_CONSTITUICAO" , "2023-09-23"},
                { "VG092_COD_CNAE_ATIVIDADE" , "4789004"},
            });
                AppSettings.TestSet.DynamicData.Add("DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1", q79);

                #endregion
                #region DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1");

                var q77 = new DynamicData();
                q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1", q77);

                #endregion
                #region R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1");

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_TERMO" , ""}
            }); q12.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_TERMO" , ""}
            }); q12.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_TERMO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1", q12);

                #endregion

                #region DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1");

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            }); q33.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            }); q33.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1", q33);

                #endregion
                #endregion
                var program = new VE2640B();
                program.Execute(MOV_VDEMP_FILE_NAME_P, MOV_SAIDA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                var envList = AppSettings.TestSet.DynamicData["R0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("APOLICOR_NUM_APOLICE", out var valor) && valor.Contains("3008210933403"));

                var envList1 = AppSettings.TestSet.DynamicData["R0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                valor = "";
                Assert.True(envList1[1].TryGetValue("APOLICOR_DATA_TERVIGENCIA", out valor) && valor.Contains("9999-12-31"));

                var envList2 = AppSettings.TestSet.DynamicData["R0854_2600_TRATA_VGSOLFAT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                valor = "";
                Assert.True(envList2[1].TryGetValue("VGSOLFAT_NUM_APOLICE", out valor) && valor.Contains("3008210933403"));

                var envList3 = AppSettings.TestSet.DynamicData["R0894_2600_INSERE_PESSOFIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                valor = "";
                Assert.True(envList3[1].TryGetValue("PESSOFIS_CPF", out valor) && valor.Contains("02510741454"));

                var envList4 = AppSettings.TestSet.DynamicData["DB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4?.Count > 1);
                valor = "";
                Assert.True(envList4[1].TryGetValue("CLIENTES_NOME_RAZAO", out valor) && valor.Contains("WP SERVICOS MEDICOS LTDA                "));

                var envList5 = AppSettings.TestSet.DynamicData["DB018_ALTERA_NUMERO_OUTROS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5?.Count > 1);
                valor = "";
                Assert.True(envList5[1].TryGetValue("CLIENTES_COD_CLIENTE", out valor) && valor.Contains("000000001"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("PRD.VA.D241202.VA0600B.ARQVDEMP", "VE2640B_t2")]
        public static void VE2640B_Tests_Theory9(string MOV_VDEMP_FILE_NAME_P, string MOV_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV_SAIDA_FILE_NAME_P = $"{MOV_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1");
                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            }); q45.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1_Query1", q45);

                #endregion
                #region VE2640B_C4_SOLICITA
                AppSettings.TestSet.DynamicData.Remove("VE2640B_C4_SOLICITA");

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_DATA_SOLICITACAO" , ""},
                { "VGSOLFAT_DIA_DEBITO" , ""},
                { "VGSOLFAT_OPCAOPAG" , ""},
                { "VGSOLFAT_QUANT_VIDAS" , ""},
                { "VGSOLFAT_CAP_BAS_SEGURADO" , ""},
                { "VGSOLFAT_PRM_VG" , ""},
                { "VGSOLFAT_PRM_AP" , ""},
                { "H_VGSOLFAT_PRM_TOTAL" , ""},
                { "VGSOLFAT_DTVENCTO_FATURA" , ""},
                { "VGSOLFAT_COD_FONTE" , ""},
                { "VGSOLFAT_NUM_TITULO" , ""},
                { "VGSOLFAT_DT_QUITBCO_TITULO" , ""},
                { "VGSOLFAT_VALOR_TITULO" , ""},
                { "VGSOLFAT_COD_USUARIO" , ""},
                { "VGSOLFAT_AGECTADEB" , ""},
                { "VGSOLFAT_OPRCTADEB" , ""},
                { "VGSOLFAT_NUMCTADEB" , ""},
                { "VGSOLFAT_DIGCTADEB" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VE2640B_C4_SOLICITA", q10);

                #endregion
                #region DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1");

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "1"}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            }); q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1", q37);

                #endregion
                #region DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1");
                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            }); q40.AddDynamic(new Dictionary<string, string>{
                { "H_NUMEROUT_NUM_CERT_VGAP" , ""},
                { "H_NUMEROUT_NUM_CLIENTE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1", q40);

                #endregion
                #region DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1");

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            }); q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            }); q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            }); q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            }); q47.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_COD_AGENCIA" , ""},
                { "FUNCICEF_OPERACAO_CONTA" , ""},
                { "FUNCICEF_NUM_CONTA" , ""},
                { "FUNCICEF_DIG_CONTA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1", q47);

                #endregion
                #region DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1");

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            }); q48.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_PRODUTOR" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1", q48);

                #endregion
                #region DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1");

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            }); q49.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            }); q49.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            }); q49.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1", q49);

                #endregion

                #region DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1");

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            }); q50.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            }); q50.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            }); q50.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1", q50);

                #endregion

                #region R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1");

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "H_VGPROSIA_NUM_APOLICE_P" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1", q1);

                #endregion

                #region DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1");

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            }); q65.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1", q65);

                #endregion

                #region DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1");

                var q59 = new DynamicData();
                q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            }); q59.AddDynamic(new Dictionary<string, string>{
                { "PARGEREM_COD_CORRETOR" , ""},
                { "PARGEREM_PCCOMCOR" , ""},
                { "PARGEREM_COD_MOEDA_FAT" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1", q59);

                #endregion

                #region DB056_ACESSA_APOLICES_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB056_ACESSA_APOLICES_DB_SELECT_1_Query1");

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            }); q60.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB056_ACESSA_APOLICES_DB_SELECT_1_Query1", q60);

                #endregion
                #region DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1");

                var q61 = new DynamicData();
                q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            }); q61.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMGER" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1", q61);

                #endregion

                #region DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1");

                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""}
            }); q70.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""}
            }); q70.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1", q70);

                #endregion

                #region DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1");

                var q63 = new DynamicData();
                q63.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_DES_GARANTIA" , ""}
            }); q63.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_DES_GARANTIA" , ""}
            }); q63.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_DES_GARANTIA" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1", q63);

                #endregion

                #region DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1");

                var q75 = new DynamicData();
                q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "VG093_NUM_OCORR_HIST" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1", q75);

                #endregion

                #region DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1");

                var q67 = new DynamicData();
                q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            }); q67.AddDynamic(new Dictionary<string, string>{
                { "TAXASEMP_TAXA_VG" , ""},
                { "TAXASEMP_TAXA_AP_MORACID" , ""},
                { "TAXASEMP_TAXA_AP_INVPERM" , ""},
                { "TAXASEMP_TAXA_AP_AMDS" , ""},
                { "TAXASEMP_TAXA_AP_DH" , ""},
                { "TAXASEMP_TAXA_AP_DIT" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1", q67);

                #endregion
                #region DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1");

                var q79 = new DynamicData();
                q79.AddDynamic(new Dictionary<string, string>{
                { "VG092_DTA_FAT_ANUAL" , ""},
                { "VG092_VLR_FAT_ANUAL" , "0000001172121.29"},
                { "VG092_DTA_CONSTITUICAO" , "2023-09-23"},
                { "VG092_COD_CNAE_ATIVIDADE" , "4789004"},
            });
                AppSettings.TestSet.DynamicData.Add("DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1", q79);

                #endregion
                #region DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1");

                var q77 = new DynamicData();
                q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            }); q77.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1", q77);

                #endregion
                #region R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1");

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_TERMO" , ""}
            }); q12.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_TERMO" , ""}
            }); q12.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_TERMO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1", q12);

                #endregion

                #region DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1");

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            }); q33.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            }); q33.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1", q33);

                #endregion
                #endregion
                var program = new VE2640B();
                program.Execute(MOV_VDEMP_FILE_NAME_P, MOV_SAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}