using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA3437B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA3437B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA3437B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , "2021-01-01"},
                { "SISTEMAS_DATA_MOV_ABERTO_15D" , "2020-01-15"},
                { "V1SIST_MESREFER" , "10"},
                { "V1SIST_ANOREFER" , "2020"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO_15D" , ""},
                { "V1SIST_MESREFER" , ""},
                { "V1SIST_ANOREFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA3437B_CFAIXACEP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , ""},
                { "GEFAICEP_CEP_INICIAL" , ""},
                { "GEFAICEP_CEP_FINAL" , ""},
                { "GEFAICEP_DESCRICAO_FAIXA" , ""},
                { "GEFAICEP_CENTRALIZADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3437B_CFAIXACEP", q2);

            #endregion

            #region VA3437B_CMSG

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_NUM_APOLICE" , "56"},
                { "COBMENVG_CODSUBES" , "12345"},
                { "COBMENVG_COD_OPERACAO" , "123"},
                { "COBMENVG_JDE" , ""},
                { "COBMENVG_JDL" , ""},
                { "COBMENVG_IDFORM" , ""},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_NUM_APOLICE" , "123"},
                { "COBMENVG_CODSUBES" , "12345"},
                { "COBMENVG_COD_OPERACAO" , "12"},
                { "COBMENVG_JDE" , ""},
                { "COBMENVG_JDL" , ""},
                { "COBMENVG_IDFORM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3437B_CMSG", q3);

            #endregion

            #region VA3437B_CFCPLANO

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FCPLANO_NUM_PLANO" , ""},
                { "FCPLANO_QTD_DIG_COMBINACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3437B_CFCPLANO", q4);

            #endregion

            #region VA3437B_V1AGENCEF

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , ""},
                { "FONTES_NOME_FONTE" , ""},
                { "FONTES_ENDERECO" , ""},
                { "FONTES_BAIRRO" , ""},
                { "FONTES_CIDADE" , ""},
                { "FONTES_CEP" , ""},
                { "FONTES_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3437B_V1AGENCEF", q5);

            #endregion

            #region VA3437B_CRELAT

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , "2"},
                { "RELATORI_COD_USUARIO" , "VA0118B"},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_TIMESTAMP" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_APOLICE" , "102030"},
                { "PROPOVA_COD_SUBGRUPO" , "123"},
                { "PROPOVA_NUM_CERTIFICADO" , "1"},
                { "PROPOVA_COD_PRODUTO" , "9314"},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_OCOREND" , ""},
                { "PROPOVA_IDE_SEXO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_IDADE" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "PROPOVA_FAIXA_RENDA_IND" , ""},
                { "PROPOVA_FAIXA_RENDA_FAM" , ""},
                { "PRODUVG_CODRELAT" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "PRODUTO_COD_EMPRESA" , ""},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , "12"},
                { "RELATORI_COD_USUARIO" , "VA0118B"},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_TIMESTAMP" , ""},
                { "PROPOVA_DATA_QUITACAO" , "2020-01-01"},
                { "PROPOVA_NUM_APOLICE" , "10203363"},
                { "PROPOVA_COD_SUBGRUPO" , "1236"},
                { "PROPOVA_NUM_CERTIFICADO" , "1"},
                { "PROPOVA_COD_PRODUTO" , "9314"},
                { "PROPOVA_COD_CLIENTE" , "12"},
                { "PROPOVA_OCOREND" , ""},
                { "PROPOVA_IDE_SEXO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_IDADE" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "PROPOVA_FAIXA_RENDA_IND" , ""},
                { "PROPOVA_FAIXA_RENDA_FAM" , ""},
                { "PRODUVG_CODRELAT" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "PRODUTO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3437B_CRELAT", q6);

            #endregion

            #region VA3437B_CTITFEDCA

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "TITFEDCA_NRTITFDCAP" , ""},
                { "TITFEDCA_NRSORTEIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3437B_CTITFEDCA", q7);

            #endregion

            #region R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_DUPLICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
                { "WHOST_DATA_TERVIG_PREMIO" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_OCORR_ENDERECO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "2"},
                { "OPCPAGVI_DIA_DEBITO" , "1"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "23"},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "789"},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "456"},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "123"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "1"},
                { "OPCPAGVI_DIA_DEBITO" , "1"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "23"},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "123"},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "456"},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "789"},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q10);

            #endregion

            #region VA3437B_COBER

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , ""},
                { "VGCOBSUB_IMP_SEGURADA_IX" , ""},
                { "VGCOBSUB_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3437B_COBER", q11);

            #endregion

            #region R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "FCPROSUS_COD_PROCESSO_SUSEP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_TELEX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA_1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
                { "CONDITEC_GARAN_ADIC_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q20);

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
                { "MOEDACOT_VAL_COMPRA" , "10"}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1", q22);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VG" , "123"},
                { "APOLICOB_PRM_TARIFARIO_VG" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , "10"},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1", q23);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AP" , "456"},
                { "APOLICOB_PRM_TARIFARIO_AP" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , "10"},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1", q24);

            #endregion

            #region R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "10"}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "10"}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "10"}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "10"}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "10"}
            });
            AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q25);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IP" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1", q26);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AMDS" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1", q27);

            #endregion

            #region VA3437B_V0BENEF

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NOME_BENEFICIARIO" , ""},
                { "BENEFICI_GRAU_PARENTESCO" , ""},
                { "BENEFICI_PCT_PART_BENEFICIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3437B_V0BENEF", q28);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DH" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1", q29);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DIT" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1", q30);

            #endregion

            #region R2215_00_FETCH_COBER_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "WS_COBERTURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2215_00_FETCH_COBER_DB_SELECT_1_Query1", q31);

            #endregion

            #region R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1", q32);

            #endregion

            #region R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , ""},
                { "COBMENVG_JDL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1", q33);

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

            #region R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_OPCAO_CONJUGE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1", q37);

            #endregion

            #region R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTMDIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q38);

            #endregion

            #region R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_NUM_PROCESSO_SUSEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q39);

            #endregion

            #region R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q40);

            #endregion

            #region R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q41);

            #endregion

            #region R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "V1SIST_MESREFER" , ""},
                { "V1SIST_ANOREFER" , ""},
                { "WHOST_NRAPOLICE" , ""},
                { "WHOST_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q42);

            #endregion

            #region R3100_00_BUSCA_PROFISSAO_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_BUSCA_PROFISSAO_DB_SELECT_1_Query1", q43);

            #endregion

            #region R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1", q44);

            #endregion

            #region R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , "GERAL"},
                { "RELATORI_NUM_APOL_LIDER" , "1234"},
            });
            q45.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , "OUTRO"},
                { "RELATORI_NUM_APOL_LIDER" , "1234"},
            });
            AppSettings.TestSet.DynamicData.Add("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q45);

            #endregion

            VG0710S_Tests.Load_Parameters();

            #endregion
        }

        [Theory]
        [InlineData("RVA3437B_FILE_NAME_P", "SVA3437B_FILE_NAME_P", "FVA3437B_FILE_NAME_P", "IMP3437B_FILE_NAME_P", "PDF3437B_FILE_NAME_P", "VDHTML01_FILE_NAME_P", "VDHTML09_FILE_NAME_P")]
        public static void VA3437B_Tests_Theory(string RVA3437B_FILE_NAME_P, string SVA3437B_FILE_NAME_P, string FVA3437B_FILE_NAME_P, string IMP3437B_FILE_NAME_P, string PDF3437B_FILE_NAME_P, string VDHTML01_FILE_NAME_P, string VDHTML09_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA3437B_FILE_NAME_P = $"{RVA3437B_FILE_NAME_P}_{timestamp}.txt";
            SVA3437B_FILE_NAME_P = $"{SVA3437B_FILE_NAME_P}_{timestamp}.txt";
            FVA3437B_FILE_NAME_P = $"{FVA3437B_FILE_NAME_P}_{timestamp}.txt";
            IMP3437B_FILE_NAME_P = $"{IMP3437B_FILE_NAME_P}_{timestamp}.txt";
            PDF3437B_FILE_NAME_P = $"{PDF3437B_FILE_NAME_P}_{timestamp}.txt";
            VDHTML01_FILE_NAME_P = $"{VDHTML01_FILE_NAME_P}_{timestamp}.txt";
            VDHTML09_FILE_NAME_P = $"{VDHTML09_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                VA3437B_LK_PARAMETROS LK_PARAMETROS = new VA3437B_LK_PARAMETROS();
                LK_PARAMETROS.LK_OPERACAO.Value = "COMMIT";

                //#region R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

                //var q45 = new DynamicData();
                //AppSettings.TestSet.DynamicData.Remove("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1");

                //AppSettings.TestSet.DynamicData.Add("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q45);

                //#endregion

                #endregion
                var program = new VA3437B();
                program.Execute(LK_PARAMETROS, RVA3437B_FILE_NAME_P, SVA3437B_FILE_NAME_P, FVA3437B_FILE_NAME_P, IMP3437B_FILE_NAME_P, PDF3437B_FILE_NAME_P, VDHTML01_FILE_NAME_P, VDHTML09_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);

                Assert.True(File.Exists(program.FVA3437B.FilePath));
                Assert.True(new FileInfo(program.FVA3437B.FilePath)?.Length > 0);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                var envList1 = AppSettings.TestSet.DynamicData["R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);

                Assert.True(envList1[1].TryGetValue("WHOST_NRCERTIF", out var val1r) && val1r.Equals("000000000000001"));
                Assert.True(envList2[1].TryGetValue("WHOST_CODSUBES", out val1r) && val1r.Equals("0123"));
                Assert.True(envList2[1].TryGetValue("WHOST_NRAPOLICE", out val1r) && val1r.Equals("0000000102030"));
            }
        }

        [Theory]
        [InlineData("RVA3437B_FILE_NAME_P", "SVA3437B_FILE_NAME_P", "FVA3437B_FILE_NAME_P", "IMP3437B_FILE_NAME_P", "PDF3437B_FILE_NAME_P", "VDHTML01_FILE_NAME_P", "VDHTML09_FILE_NAME_P")]
        public static void VA3437B_Tests_TheoryERRO99(string RVA3437B_FILE_NAME_P, string SVA3437B_FILE_NAME_P, string FVA3437B_FILE_NAME_P, string IMP3437B_FILE_NAME_P, string PDF3437B_FILE_NAME_P, string VDHTML01_FILE_NAME_P, string VDHTML09_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA3437B_FILE_NAME_P = $"{RVA3437B_FILE_NAME_P}_{timestamp}.txt";
            SVA3437B_FILE_NAME_P = $"{SVA3437B_FILE_NAME_P}_{timestamp}.txt";
            FVA3437B_FILE_NAME_P = $"{FVA3437B_FILE_NAME_P}_{timestamp}.txt";
            IMP3437B_FILE_NAME_P = $"{IMP3437B_FILE_NAME_P}_{timestamp}.txt";
            PDF3437B_FILE_NAME_P = $"{PDF3437B_FILE_NAME_P}_{timestamp}.txt";
            VDHTML01_FILE_NAME_P = $"{VDHTML01_FILE_NAME_P}_{timestamp}.txt";
            VDHTML09_FILE_NAME_P = $"{VDHTML09_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                VA3437B_LK_PARAMETROS LK_PARAMETROS = new VA3437B_LK_PARAMETROS();
                LK_PARAMETROS.LK_OPERACAO.Value = "TESTE DE ERRO";



                #endregion
                var program = new VA3437B();
                program.Execute(LK_PARAMETROS, RVA3437B_FILE_NAME_P, SVA3437B_FILE_NAME_P, FVA3437B_FILE_NAME_P, IMP3437B_FILE_NAME_P, PDF3437B_FILE_NAME_P, VDHTML01_FILE_NAME_P, VDHTML09_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

              
            }
        }
    }
}