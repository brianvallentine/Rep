using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VP0437B;

namespace FileTests.Test
{
    [Collection("VP0437B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VP0437B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , ""},
                { "V1SIST_MESREFER" , ""},
                { "V1SIST_ANOREFER" , ""},
                { "V1SIST_CURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VP0437B_CFAIXACEP

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , ""},
                { "GEFAICEP_CEP_INICIAL" , ""},
                { "GEFAICEP_CEP_FINAL" , ""},
                { "GEFAICEP_DESCRICAO_FAIXA" , ""},
                { "GEFAICEP_CENTRALIZADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0437B_CFAIXACEP", q1);

            #endregion

            #region VP0437B_CMSG

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_NUM_APOLICE" , ""},
                { "COBMENVG_CODSUBES" , ""},
                { "COBMENVG_COD_OPERACAO" , ""},
                { "COBMENVG_JDE" , ""},
                { "COBMENVG_JDL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0437B_CMSG", q2);

            #endregion

            #region VP0437B_V1AGENCEF

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , ""},
                { "FONTES_NOME_FONTE" , ""},
                { "FONTES_ENDERECO" , ""},
                { "FONTES_BAIRRO" , ""},
                { "FONTES_CIDADE" , ""},
                { "FONTES_CEP" , ""},
                { "FONTES_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0437B_V1AGENCEF", q3);

            #endregion

            #region VP0437B_CRELAT

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_IDE_SEXO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_IDADE" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "WS_DATA_FIM_CALC" , ""},
                { "PRODUVG_CODRELAT" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "PRODUVG_ORIG_PRODU" , ""},
                { "PRODUTO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0437B_CRELAT", q4);

            #endregion

            #region VP0437B_COBER

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , ""},
                { "VGCOBSUB_IMP_SEGURADA_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0437B_COBER", q5);

            #endregion

            #region R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
                { "WHOST_DATA_TERVIG_PREMIO" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_OCORR_ENDERECO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_OPRCTADEB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "FCTITULO_VLR_MENSALIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_IDE_SEXO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA_1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "PLANOVID_COD_PLANO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
                { "CONDITEC_GARAN_ADIC_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_REGISTRO_SUSEP" , ""},
                { "PRODUTOR_NOME_PRODUTOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WS_NOME_SEG" , ""},
                { "WS_CGCCPF_SEG" , ""},
                { "WS_ENDERECO_SEG" , ""},
                { "WS_BAIRRO_SEG" , ""},
                { "WS_CIDADE_SEG" , ""},
                { "WS_CEP_SEG" , ""},
                { "WS_UF_SEG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1", q20);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_MOVIMENTO" , ""},
                { "SEGVGAPH_COD_OPERACAO" , ""},
                { "SEGVGAPH_COD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1", q21);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_VAL_COMPRA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1", q22);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VG" , ""},
                { "APOLICOB_PRM_TARIFARIO_VG" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1", q23);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AP" , ""},
                { "APOLICOB_PRM_TARIFARIO_AP" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1", q24);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IP" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1", q25);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AMDS" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1", q26);

            #endregion

            #region R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q27);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DH" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1", q28);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DIT" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1", q29);

            #endregion

            #region VP0437B_V0BENEF

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NOME_BENEFICIARIO" , ""},
                { "BENEFICI_GRAU_PARENTESCO" , ""},
                { "BENEFICI_PCT_PART_BENEFICIA" , ""},
                { "BENEFICI_NUM_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0437B_V0BENEF", q30);

            #endregion

            #region R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PLANO" , ""},
                { "SEGURVGA_PERI_RENOVACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1", q31);

            #endregion

            #region R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , ""},
                { "COBMENVG_JDL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1", q32);

            #endregion

            #region R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_IDE_SEXO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q33);

            #endregion

            #region R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODRELAT" , ""},
                { "WHOST_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q34);

            #endregion

            #region R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q35);

            #endregion

            #region R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1", q36);

            #endregion

            #region R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1", q37);

            #endregion

            #region R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTMDIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q38);

            #endregion

            #region R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q39);

            #endregion

            #region R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1", q40);

            #endregion

            #region R2903_00_LER_EMAIL_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2903_00_LER_EMAIL_DB_SELECT_1_Query1", q41);

            #endregion

            #region R2904_00_LER_TELEFONE_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "DDD" , ""},
                { "NUM_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2904_00_LER_TELEFONE_DB_SELECT_1_Query1", q42);

            #endregion

            #region R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q43);

            #endregion

            #region R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "V1SIST_MESREFER" , ""},
                { "V1SIST_ANOREFER" , ""},
                { "WHOST_NRAPOLICE" , ""},
                { "WHOST_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q44);

            #endregion

            #region R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_ID_SISTEMA" , ""},
                { "PRODUVG_CODRELAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q45);

            #endregion

            #region R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_STA_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1", q46);

            #endregion

            #region R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_NUM_CEP" , ""},
                { "GEOBJECT_COD_FORMULARIO" , ""},
                { "GEOBJECT_STA_REGISTRO" , ""},
                { "GEOBJECT_COD_PRODUTO" , ""},
                { "GEOBJECT_NUM_INI_POS_VERSO" , ""},
                { "GEOBJECT_QTD_PESO_GRAMAS" , ""},
                { "GEOBJECT_VLR_DECLARADO" , ""},
                { "GEOBJECT_COD_IDENT_OBJETO" , ""},
                { "GEOBJECT_DES_OBJETO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1", q47);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VP0437B_1_t1", "VP0437B_2_t1", "VP0437B_3_t1")]
        public static void VP0437B_Tests_Theory_ReturnCode_00(string RVP0437B_FILE_NAME_P, string SVP0437B_FILE_NAME_P, string FVP0437B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVP0437B_FILE_NAME_P = $"{RVP0437B_FILE_NAME_P}_{timestamp}.txt";
            SVP0437B_FILE_NAME_P = $"{SVP0437B_FILE_NAME_P}_{timestamp}.txt";
            FVP0437B_FILE_NAME_P = $"{FVP0437B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                VG0710S_Tests.Load_Parameters();
                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SISTEMAS_DATA_MOV_ABERTO_1" , "2023-12-02" },
                { "V1SIST_MESREFER" , "12" },
                { "V1SIST_ANOREFER" , "2023" },
                { "V1SIST_CURRENT" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region VP0437B_CFAIXACEP

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , "1" },
                { "GEFAICEP_CEP_INICIAL" , "70000000" },
                { "GEFAICEP_CEP_FINAL" , "70099999" },
                { "GEFAICEP_DESCRICAO_FAIXA" , "Brasília - DF" },
                { "GEFAICEP_CENTRALIZADOR" , "DF" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP0437B_CFAIXACEP");
AppSettings.TestSet.DynamicData.Add("VP0437B_CFAIXACEP", q1);

                #endregion

                #region VP0437B_CMSG

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_NUM_APOLICE" , "123456789" },
                { "COBMENVG_CODSUBES" , "001" },
                { "COBMENVG_COD_OPERACAO" , "123" },
                { "COBMENVG_JDE" , "1" },
                { "COBMENVG_JDL" , "2" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP0437B_CMSG");
AppSettings.TestSet.DynamicData.Add("VP0437B_CMSG", q2);

                #endregion

                #region VP0437B_V1AGENCEF

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , "001" },
                { "FONTES_NOME_FONTE" , "Fonte A" },
                { "FONTES_ENDERECO" , "Rua A" },
                { "FONTES_BAIRRO" , "Bairro A" },
                { "FONTES_CIDADE" , "Cidade A" },
                { "FONTES_CEP" , "70000000" },
                { "FONTES_SIGLA_UF" , "DF" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP0437B_V1AGENCEF");
AppSettings.TestSet.DynamicData.Add("VP0437B_V1AGENCEF", q3);

                #endregion

                #region VP0437B_CRELAT

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , "123" },
                { "RELATORI_COD_USUARIO" , "001" },
                { "RELATORI_COD_RELATORIO" , "001" },
                { "PROPOVA_DATA_QUITACAO" , "2023-12-31" },
                { "PROPOVA_NUM_APOLICE" , "123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_NUM_CERTIFICADO" , "987654321" },
                { "PROPOVA_COD_PRODUTO" , "7705" },
                { "PROPOVA_COD_CLIENTE" , "123456" },
                { "PROPOVA_IDE_SEXO" , "M" },
                { "PROPOVA_SIT_REGISTRO" , "Ativo" },
                { "PROPOVA_AGE_COBRANCA" , "30" },
                { "PROPOVA_COD_FONTE" , "001" },
                { "PROPOVA_IDADE" , "30" },
                { "PROPOVA_OCORR_HISTORICO" , "Nenhuma" },
                { "WS_DATA_FIM_CALC" , "2023-12-31" },
                { "PRODUVG_CODRELAT" , "001" },
                { "PRODUVG_PERI_PAGAMENTO" , "Mensal" },
                { "PRODUVG_ORIG_PRODU" , "Interna" },
                { "PRODUTO_COD_EMPRESA" , "001" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP0437B_CRELAT");
AppSettings.TestSet.DynamicData.Add("VP0437B_CRELAT", q4);

                #endregion

                #region VP0437B_COBER

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , "001" },
                { "VGCOBSUB_IMP_SEGURADA_IX" , "100000" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP0437B_COBER");
AppSettings.TestSet.DynamicData.Add("VP0437B_COBER", q5);

                #endregion

                #region R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "Ativo" },
                { "SEGURVGA_COD_CLIENTE" , "123456" },
                { "SEGURVGA_DATA_INIVIGENCIA" , "2023-01-01" },
                { "WHOST_DATA_TERVIG_PREMIO" , "2023-12-31" },
                { "SEGURVGA_COD_SUBGRUPO" , "001" },
                { "SEGURVGA_OCORR_ENDERECO" , "Rua A, 100" },
                { "SEGURVGA_NUM_ITEM" , "1" },
                { "SEGURVGA_OCORR_HISTORICO" , "Nenhuma" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_OPRCTADEB" , "Debito Direto" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "FCTITULO_VLR_MENSALIDADE" , "100.00" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "Débito Automático" },
                { "OPCPAGVI_DIA_DEBITO" , "10" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "0001" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "Operação 001" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "12345678" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "9" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Cliente A" },
                { "CLIENTES_CGCCPF" , "12345678901" },
                { "CLIENTES_IDE_SEXO" , "M" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "Rua A" },
                { "ENDERECO_BAIRRO" , "Bairro A" },
                { "ENDERECO_CIDADE" , "Cidade A" },
                { "ENDERECO_SIGLA_UF" , "DF" },
                { "ENDERECO_CEP" , "70000000" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "HISCOBPR_COD_OPERACAO" , "123" },
                { "HISCOBPR_OPCAO_COBERTURA" , "Cobertura A" },
                { "HISCOBPR_IMP_MORNATU" , "100000" },
                { "HISCOBPR_IMPSEGCDG" , "001" },
                { "HISCOBPR_VLPREMIO" , "1000.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , "001" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "123456" },
                { "APOLICES_RAMO_EMISSOR" , "Seguros" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2024-01-01" },
                { "ENDOSSOS_DATA_TERVIGENCIA_1" , "2024-01-02" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_DATA_INIVIGENCIA" , "2023-01-01" },
                { "APOLICOB_DATA_TERVIGENCIA" , "2024-01-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "PLANOVID_COD_PLANO" , "001" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , "Sim" },
                { "CONDITEC_GARAN_ADIC_IEA" , "Invalidez por Acidente" },
                { "CONDITEC_GARAN_ADIC_IPA" , "Invalidez Permanente Total por Acidente" },
                { "CONDITEC_GARAN_ADIC_IPD" , "Invalidez Permanente Parcial por Doença" },
                { "CONDITEC_GARAN_ADIC_HD" , "Hospitalização por Doença" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_REGISTRO_SUSEP" , "001" },
                { "PRODUTOR_NOME_PRODUTOR" , "Produtor A" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WS_NOME_SEG" , "Segurado A" },
                { "WS_CGCCPF_SEG" , "12345678901" },
                { "WS_ENDERECO_SEG" , "Rua A" },
                { "WS_BAIRRO_SEG" , "Bairro A" },
                { "WS_CIDADE_SEG" , "Cidade A" },
                { "WS_CEP_SEG" , "70000000" },
                { "WS_UF_SEG" , "DF" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1", q20);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_MOVIMENTO" , "2023-12-01" },
                { "SEGVGAPH_COD_OPERACAO" , "123" },
                { "SEGVGAPH_COD_MOEDA_PRM" , "BRL" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1", q21);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1

    var q22 = new DynamicData();
            AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1", q22);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1

    var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VG" , "100000" },
                { "APOLICOB_PRM_TARIFARIO_VG" , "1000.00" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1", q23);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1

    var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AP" , "50000" },
                { "APOLICOB_PRM_TARIFARIO_AP" , "500.00" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1");
AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1", q24);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1

    var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IP" , "25000" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1");
AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1", q25);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1

    var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AMDS" , "15000" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });

                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1");
AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1", q26);

                #endregion

                #region R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1

    var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "001" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q27);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1

    var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DH" , "10000" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1");
AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1", q28);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1

    var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DIT" , "5000" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1");
AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1", q29);

                #endregion

                #region VP0437B_V0BENEF

    var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NOME_BENEFICIARIO" , "Beneficiário A" },
                { "BENEFICI_GRAU_PARENTESCO" , "Filho" },
                { "BENEFICI_PCT_PART_BENEFICIA" , "50" },
                { "BENEFICI_NUM_CPF" , "12345678901" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP0437B_V0BENEF");
AppSettings.TestSet.DynamicData.Add("VP0437B_V0BENEF", q30);

                #endregion

                #region R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1

    var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PLANO" , "001" },
                { "SEGURVGA_PERI_RENOVACAO" , "Anual" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1", q31);

                #endregion

                #region R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1

    var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , "1" },
                { "COBMENVG_JDL" , "2" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1", q32);

                #endregion

                #region R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1

    var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Cliente A" },
                { "CLIENTES_IDE_SEXO" , "M" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q33);

                #endregion

                #region R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

    var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODRELAT" , "001" },
                { "WHOST_NRCERTIF" , "987654321" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q34);

                #endregion

                #region R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1

    var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "Produto A" },
                { "PRODUVG_COD_PRODUTO" , "001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q35);

                #endregion

                #region R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1

    var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Cliente A" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1", q36);

                #endregion

                #region R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1

    var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Cliente A" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1", q37);

                #endregion

                #region R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

    var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTMDIT" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q38);

                #endregion

                #region R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

    var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "123456789" },
                { "SEGURVGA_COD_SUBGRUPO" , "001" },
                { "SEGURVGA_NUM_ITEM" , "1" },
                { "SEGURVGA_OCORR_HISTORICO" , "Nenhuma" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q39);

                #endregion

                #region R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1

    var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , "123456" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1", q40);

                #endregion

                #region R2903_00_LER_EMAIL_DB_SELECT_1_Query1

    var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "EMAIL" , "clienteA@example.com" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2903_00_LER_EMAIL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2903_00_LER_EMAIL_DB_SELECT_1_Query1", q41);

                #endregion

                #region R2904_00_LER_TELEFONE_DB_SELECT_1_Query1

    var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "DDD" , "61" },
                { "NUM_FONE" , "123456789" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2904_00_LER_TELEFONE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2904_00_LER_TELEFONE_DB_SELECT_1_Query1", q42);

                #endregion

                #region R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

    var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q43);

                #endregion

                #region R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

    var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "RELATORI_NUM_COPIAS" , "2" },
                { "V1SIST_MESREFER" , "12" },
                { "V1SIST_ANOREFER" , "2023" },
                { "WHOST_NRAPOLICE" , "123456789" },
                { "WHOST_CODSUBES" , "001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q44);

                #endregion

                #region R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1

    var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_ID_SISTEMA" , "1" },
                { "PRODUVG_CODRELAT" , "001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q45);

                #endregion

                #region R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1

    var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_STA_REGISTRO" , "Ativo" }
            });
            AppSettings.TestSet.DynamicData.Remove("R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1", q46);

                #endregion

                #region R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1

    var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_NUM_CEP" , "70000000" },
                { "GEOBJECT_COD_FORMULARIO" , "001" },
                { "GEOBJECT_STA_REGISTRO" , "Ativo" },
                { "GEOBJECT_COD_PRODUTO" , "001" },
                { "GEOBJECT_NUM_INI_POS_VERSO" , "1" },
                { "GEOBJECT_QTD_PESO_GRAMAS" , "100" },
                { "GEOBJECT_VLR_DECLARADO" , "1000.00" },
                { "GEOBJECT_COD_IDENT_OBJETO" , "001" },
                { "GEOBJECT_DES_OBJETO" , "Objeto A" },
            });
            AppSettings.TestSet.DynamicData.Remove("R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1", q47);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VP0437B();
                program.Execute(RVP0437B_FILE_NAME_P, SVP0437B_FILE_NAME_P, FVP0437B_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VP0437B_1_t2", "VP0437B_2_t2", "VP0437B_3_t2")]
        public static void VP0437B_Tests_Theory_ReturnCode_99(string RVP0437B_FILE_NAME_P, string SVP0437B_FILE_NAME_P, string FVP0437B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVP0437B_FILE_NAME_P = $"{RVP0437B_FILE_NAME_P}_{timestamp}.txt";
            SVP0437B_FILE_NAME_P = $"{SVP0437B_FILE_NAME_P}_{timestamp}.txt";
            FVP0437B_FILE_NAME_P = $"{FVP0437B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                VG0710S_Tests.Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SISTEMAS_DATA_MOV_ABERTO_1" , "2023-12-02" },
                { "V1SIST_MESREFER" , "12" },
                { "V1SIST_ANOREFER" , "2023" },
                { "V1SIST_CURRENT" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region VP0437B_CFAIXACEP

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , "1" },
                { "GEFAICEP_CEP_INICIAL" , "70000000" },
                { "GEFAICEP_CEP_FINAL" , "70099999" },
                { "GEFAICEP_DESCRICAO_FAIXA" , "Brasília - DF" },
                { "GEFAICEP_CENTRALIZADOR" , "DF" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0437B_CFAIXACEP");
                AppSettings.TestSet.DynamicData.Add("VP0437B_CFAIXACEP", q1);

                #endregion

                #region VP0437B_CMSG

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_NUM_APOLICE" , "123456789" },
                { "COBMENVG_CODSUBES" , "001" },
                { "COBMENVG_COD_OPERACAO" , "123" },
                { "COBMENVG_JDE" , "1" },
                { "COBMENVG_JDL" , "2" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0437B_CMSG");
                AppSettings.TestSet.DynamicData.Add("VP0437B_CMSG", q2);

                #endregion

                #region VP0437B_V1AGENCEF

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VP0437B_V1AGENCEF");
                AppSettings.TestSet.DynamicData.Add("VP0437B_V1AGENCEF", q3);

                #endregion

                #region VP0437B_CRELAT

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , "123" },
                { "RELATORI_COD_USUARIO" , "001" },
                { "RELATORI_COD_RELATORIO" , "001" },
                { "PROPOVA_DATA_QUITACAO" , "2023-12-31" },
                { "PROPOVA_NUM_APOLICE" , "123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_NUM_CERTIFICADO" , "987654321" },
                { "PROPOVA_COD_PRODUTO" , "7705" },
                { "PROPOVA_COD_CLIENTE" , "123456" },
                { "PROPOVA_IDE_SEXO" , "M" },
                { "PROPOVA_SIT_REGISTRO" , "Ativo" },
                { "PROPOVA_AGE_COBRANCA" , "30" },
                { "PROPOVA_COD_FONTE" , "001" },
                { "PROPOVA_IDADE" , "30" },
                { "PROPOVA_OCORR_HISTORICO" , "Nenhuma" },
                { "WS_DATA_FIM_CALC" , "2023-12-31" },
                { "PRODUVG_CODRELAT" , "001" },
                { "PRODUVG_PERI_PAGAMENTO" , "Mensal" },
                { "PRODUVG_ORIG_PRODU" , "Interna" },
                { "PRODUTO_COD_EMPRESA" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0437B_CRELAT");
                AppSettings.TestSet.DynamicData.Add("VP0437B_CRELAT", q4);

                #endregion

                #region VP0437B_COBER

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , "001" },
                { "VGCOBSUB_IMP_SEGURADA_IX" , "100000" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0437B_COBER");
                AppSettings.TestSet.DynamicData.Add("VP0437B_COBER", q5);

                #endregion

                #region R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "Ativo" },
                { "SEGURVGA_COD_CLIENTE" , "123456" },
                { "SEGURVGA_DATA_INIVIGENCIA" , "2023-01-01" },
                { "WHOST_DATA_TERVIG_PREMIO" , "2023-12-31" },
                { "SEGURVGA_COD_SUBGRUPO" , "001" },
                { "SEGURVGA_OCORR_ENDERECO" , "Rua A, 100" },
                { "SEGURVGA_NUM_ITEM" , "1" },
                { "SEGURVGA_OCORR_HISTORICO" , "Nenhuma" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_OPRCTADEB" , "Debito Direto" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "FCTITULO_VLR_MENSALIDADE" , "100.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "Débito Automático" },
                { "OPCPAGVI_DIA_DEBITO" , "10" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "0001" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "Operação 001" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "12345678" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "9" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Cliente A" },
                { "CLIENTES_CGCCPF" , "12345678901" },
                { "CLIENTES_IDE_SEXO" , "M" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "Rua A" },
                { "ENDERECO_BAIRRO" , "Bairro A" },
                { "ENDERECO_CIDADE" , "Cidade A" },
                { "ENDERECO_SIGLA_UF" , "DF" },
                { "ENDERECO_CEP" , "70000000" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "HISCOBPR_COD_OPERACAO" , "123" },
                { "HISCOBPR_OPCAO_COBERTURA" , "Cobertura A" },
                { "HISCOBPR_IMP_MORNATU" , "100000" },
                { "HISCOBPR_IMPSEGCDG" , "001" },
                { "HISCOBPR_VLPREMIO" , "1000.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , "001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "123456" },
                { "APOLICES_RAMO_EMISSOR" , "Seguros" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2024-01-01" },
                { "ENDOSSOS_DATA_TERVIGENCIA_1" , "2024-01-02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_DATA_INIVIGENCIA" , "2023-01-01" },
                { "APOLICOB_DATA_TERVIGENCIA" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "PLANOVID_COD_PLANO" , "001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , "Sim" },
                { "CONDITEC_GARAN_ADIC_IEA" , "Invalidez por Acidente" },
                { "CONDITEC_GARAN_ADIC_IPA" , "Invalidez Permanente Total por Acidente" },
                { "CONDITEC_GARAN_ADIC_IPD" , "Invalidez Permanente Parcial por Doença" },
                { "CONDITEC_GARAN_ADIC_HD" , "Hospitalização por Doença" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_REGISTRO_SUSEP" , "001" },
                { "PRODUTOR_NOME_PRODUTOR" , "Produtor A" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "WS_NOME_SEG" , "Segurado A" },
                { "WS_CGCCPF_SEG" , "12345678901" },
                { "WS_ENDERECO_SEG" , "Rua A" },
                { "WS_BAIRRO_SEG" , "Bairro A" },
                { "WS_CIDADE_SEG" , "Cidade A" },
                { "WS_CEP_SEG" , "70000000" },
                { "WS_UF_SEG" , "DF" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1", q20);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_MOVIMENTO" , "2023-12-01" },
                { "SEGVGAPH_COD_OPERACAO" , "123" },
                { "SEGVGAPH_COD_MOEDA_PRM" , "BRL" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1", q21);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1

                var q22 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1", q22);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VG" , "100000" },
                { "APOLICOB_PRM_TARIFARIO_VG" , "1000.00" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1", q23);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AP" , "50000" },
                { "APOLICOB_PRM_TARIFARIO_AP" , "500.00" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1", q24);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IP" , "25000" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1", q25);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AMDS" , "15000" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });

                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1", q26);

                #endregion

                #region R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q27);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DH" , "10000" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1", q28);

                #endregion

                #region R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DIT" , "5000" },
                { "APOLICOB_FATOR_MULTIPLICA" , "1" },
                { "APOLICOB_RAMO_COBERTURA" , "Vida" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1", q29);

                #endregion

                #region VP0437B_V0BENEF

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NOME_BENEFICIARIO" , "Beneficiário A" },
                { "BENEFICI_GRAU_PARENTESCO" , "Filho" },
                { "BENEFICI_PCT_PART_BENEFICIA" , "50" },
                { "BENEFICI_NUM_CPF" , "12345678901" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0437B_V0BENEF");
                AppSettings.TestSet.DynamicData.Add("VP0437B_V0BENEF", q30);

                #endregion

                #region R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PLANO" , "001" },
                { "SEGURVGA_PERI_RENOVACAO" , "Anual" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1", q31);

                #endregion

                #region R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , "1" },
                { "COBMENVG_JDL" , "2" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1", q32);

                #endregion

                #region R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Cliente A" },
                { "CLIENTES_IDE_SEXO" , "M" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q33);

                #endregion

                #region R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODRELAT" , "001" },
                { "WHOST_NRCERTIF" , "987654321" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q34);

                #endregion

                #region R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "Produto A" },
                { "PRODUVG_COD_PRODUTO" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q35);

                #endregion

                #region R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Cliente A" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1", q36);

                #endregion

                #region R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Cliente A" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1", q37);

                #endregion

                #region R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTMDIT" , "10" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q38);

                #endregion

                #region R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "123456789" },
                { "SEGURVGA_COD_SUBGRUPO" , "001" },
                { "SEGURVGA_NUM_ITEM" , "1" },
                { "SEGURVGA_OCORR_HISTORICO" , "Nenhuma" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q39);

                #endregion

                #region R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , "123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1", q40);

                #endregion

                #region R2903_00_LER_EMAIL_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "EMAIL" , "clienteA@example.com" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2903_00_LER_EMAIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2903_00_LER_EMAIL_DB_SELECT_1_Query1", q41);

                #endregion

                #region R2904_00_LER_TELEFONE_DB_SELECT_1_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "DDD" , "61" },
                { "NUM_FONE" , "123456789" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2904_00_LER_TELEFONE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2904_00_LER_TELEFONE_DB_SELECT_1_Query1", q42);

                #endregion

                #region R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , "2" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q43);

                #endregion

                #region R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "RELATORI_NUM_COPIAS" , "2" },
                { "V1SIST_MESREFER" , "12" },
                { "V1SIST_ANOREFER" , "2023" },
                { "WHOST_NRAPOLICE" , "123456789" },
                { "WHOST_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q44);

                #endregion

                #region R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_ID_SISTEMA" , "1" },
                { "PRODUVG_CODRELAT" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q45);

                #endregion

                #region R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_STA_REGISTRO" , "Ativo" }
            });
                AppSettings.TestSet.DynamicData.Remove("R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1", q46);

                #endregion

                #region R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_NUM_CEP" , "70000000" },
                { "GEOBJECT_COD_FORMULARIO" , "001" },
                { "GEOBJECT_STA_REGISTRO" , "Ativo" },
                { "GEOBJECT_COD_PRODUTO" , "001" },
                { "GEOBJECT_NUM_INI_POS_VERSO" , "1" },
                { "GEOBJECT_QTD_PESO_GRAMAS" , "100" },
                { "GEOBJECT_VLR_DECLARADO" , "1000.00" },
                { "GEOBJECT_COD_IDENT_OBJETO" , "001" },
                { "GEOBJECT_DES_OBJETO" , "Objeto A" },
            });
                AppSettings.TestSet.DynamicData.Remove("R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1", q47);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VP0437B();
                program.Execute(RVP0437B_FILE_NAME_P, SVP0437B_FILE_NAME_P, FVP0437B_FILE_NAME_P);
                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}