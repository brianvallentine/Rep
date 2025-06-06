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
using static Code.VA4437B;

namespace FileTests.Test
{
    [Collection("VA4437B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA4437B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-07-19"},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , "2023-07-19"},
                { "SISTEMAS_DATA_MOV_ABERTO_15D" , "2024-07-04"},
                { "V1SIST_MESREFER" , "7"},
                { "V1SIST_ANOREFER" , "2024"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA4437B_CFAIXACEP

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , ""},
                { "GEFAICEP_CEP_INICIAL" , ""},
                { "GEFAICEP_CEP_FINAL" , ""},
                { "GEFAICEP_DESCRICAO_FAIXA" , ""},
                { "GEFAICEP_CENTRALIZADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4437B_CFAIXACEP", q1);

            #endregion

            #region VA4437B_CMSG

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_NUM_APOLICE" , ""},
                { "COBMENVG_CODSUBES" , ""},
                { "COBMENVG_COD_OPERACAO" , ""},
                { "COBMENVG_JDE" , ""},
                { "COBMENVG_JDL" , ""},
                { "COBMENVG_IDFORM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4437B_CMSG", q2);

            #endregion

            #region VA4437B_CFCPLANO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "FCPLANO_NUM_PLANO" , ""},
                { "FCPLANO_QTD_DIG_COMBINACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4437B_CFCPLANO", q3);

            #endregion

            #region VA4437B_V1AGENCEF

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , ""},
                { "FONTES_NOME_FONTE" , ""},
                { "FONTES_ENDERECO" , ""},
                { "FONTES_BAIRRO" , ""},
                { "FONTES_CIDADE" , ""},
                { "FONTES_CEP" , ""},
                { "FONTES_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4437B_V1AGENCEF", q4);

            #endregion

            #region VA4437B_CRELAT

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_TIMESTAMP" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
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
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "PRODUTO_NUM_PROCESSO_SUSEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4437B_CRELAT", q5);

            #endregion

            #region VA4437B_CTITFEDCA

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "TITFEDCA_NRTITFDCAP" , ""},
                { "TITFEDCA_NRSORTEIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4437B_CTITFEDCA", q6);

            #endregion

            #region R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_DUPLICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
                { "WHOST_DATA_TERVIG_PREMIO" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_OCORR_ENDERECO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q8);

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

            #region VA4437B_COBER

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , ""},
                { "VGCOBSUB_IMP_SEGURADA_IX" , ""},
                { "VGCOBSUB_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4437B_COBER", q10);

            #endregion

            #region R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "FCPROSUS_COD_PROCESSO_SUSEP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA_1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
                { "CONDITEC_GARAN_ADIC_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q19);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_MOVIMENTO" , ""},
                { "SEGVGAPH_COD_OPERACAO" , ""},
                { "SEGVGAPH_COD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1", q20);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_VAL_COMPRA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1", q21);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VG" , ""},
                { "APOLICOB_PRM_TARIFARIO_VG" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1", q22);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AP" , ""},
                { "APOLICOB_PRM_TARIFARIO_AP" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1", q23);

            #endregion

            #region R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q24);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IP" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1", q25);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AMDS" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1", q26);

            #endregion

            #region VA4437B_V0BENEF

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NOME_BENEFICIARIO" , ""},
                { "BENEFICI_GRAU_PARENTESCO" , ""},
                { "BENEFICI_PCT_PART_BENEFICIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4437B_V0BENEF", q27);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DH" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1", q28);

            #endregion

            #region R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_DIT" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1", q29);

            #endregion

            #region R2215_00_FETCH_COBER_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "WS_COBERTURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2215_00_FETCH_COBER_DB_SELECT_1_Query1", q30);

            #endregion

            #region R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1", q31);

            #endregion

            #region R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , ""},
                { "COBMENVG_JDL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1", q32);

            #endregion

            #region R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODRELAT" , ""},
                { "WHOST_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q33);

            #endregion

            #region R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1", q34);

            #endregion

            #region R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_OPCAO_CONJUGE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1", q35);

            #endregion

            #region R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTMDIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q36);

            #endregion

            #region R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q37);

            #endregion

            #region R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q38);

            #endregion

            #region R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "V1SIST_MESREFER" , ""},
                { "V1SIST_ANOREFER" , ""},
                { "WHOST_NRAPOLICE" , ""},
                { "WHOST_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q39);

            #endregion

            #region R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q40);

            #endregion
            VG0710S_Tests.Load_Parameters();

            #endregion
        }

        [Theory]
        [InlineData("SVA4437B_FILE_NAME_P", "RVA4437B_FILE_NAME_P", "RVA4437I_FILE_NAME_P", "RVA4437P_FILE_NAME_P", "RVA4437H_FILE_NAME_P")]
        public static void VA4437B_Tests_Theory_ErroParametros_ReturnCode_99(string SVA4437B_FILE_NAME_P, string RVA4437B_FILE_NAME_P, string RVA4437I_FILE_NAME_P, string RVA4437P_FILE_NAME_P, string RVA4437H_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA4437B_FILE_NAME_P = $"{SVA4437B_FILE_NAME_P}_{timestamp}.txt";
            RVA4437B_FILE_NAME_P = $"{RVA4437B_FILE_NAME_P}_{timestamp}.txt";
            RVA4437I_FILE_NAME_P = $"{RVA4437I_FILE_NAME_P}_{timestamp}.txt";
            RVA4437P_FILE_NAME_P = $"{RVA4437P_FILE_NAME_P}_{timestamp}.txt";
            RVA4437H_FILE_NAME_P = $"{RVA4437H_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                VA4437B_LK_PARAMETROS parameters = new VA4437B_LK_PARAMETROS();
                parameters.LK_OPERACAO.Value = "";

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-08-20"},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , "2023-09-20"},
                { "SISTEMAS_DATA_MOV_ABERTO_15D" , "2024-07-04"},
                { "V1SIST_MESREFER" , "8"},
                { "V1SIST_ANOREFER" , "2024"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new VA4437B();
                program.Execute(parameters, SVA4437B_FILE_NAME_P, RVA4437B_FILE_NAME_P, RVA4437I_FILE_NAME_P, RVA4437P_FILE_NAME_P, RVA4437H_FILE_NAME_P);

                Assert.True(program.LK_PARAMETROS.LK_OPERACAO.Value != "COMMIT" && program.LK_PARAMETROS.LK_OPERACAO.Value != "ROLLBACK");
                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("SVA4437B_FILE_NAME_P", "RVA4437B_FILE_NAME_P", "RVA4437I_FILE_NAME_P", "RVA4437P_FILE_NAME_P", "RVA4437H_FILE_NAME_P")]
        public static void VA4437B_Tests_Theory_FinalizaSemSolicitacao_ReturnCode_00(string SVA4437B_FILE_NAME_P, string RVA4437B_FILE_NAME_P, string RVA4437I_FILE_NAME_P, string RVA4437P_FILE_NAME_P, string RVA4437H_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA4437B_FILE_NAME_P = $"{SVA4437B_FILE_NAME_P}_{timestamp}.txt";
            RVA4437B_FILE_NAME_P = $"{RVA4437B_FILE_NAME_P}_{timestamp}.txt";
            RVA4437I_FILE_NAME_P = $"{RVA4437I_FILE_NAME_P}_{timestamp}.txt";
            RVA4437P_FILE_NAME_P = $"{RVA4437P_FILE_NAME_P}_{timestamp}.txt";
            RVA4437H_FILE_NAME_P = $"{RVA4437H_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                VA4437B_LK_PARAMETROS parameters = new VA4437B_LK_PARAMETROS();
                parameters.LK_OPERACAO.Value = "COMMIT";

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-08-20"},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , "2023-09-20"},
                { "SISTEMAS_DATA_MOV_ABERTO_15D" , "2024-07-04"},
                { "V1SIST_MESREFER" , "8"},
                { "V1SIST_ANOREFER" , "2024"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #region VA4437B_CRELAT

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VA4437B_CRELAT");
                AppSettings.TestSet.DynamicData.Add("VA4437B_CRELAT", q5);

                #endregion
                #endregion
                var program = new VA4437B();
                program.Execute(parameters, SVA4437B_FILE_NAME_P, RVA4437B_FILE_NAME_P, RVA4437I_FILE_NAME_P, RVA4437P_FILE_NAME_P, RVA4437H_FILE_NAME_P);

                Assert.True(program.LK_PARAMETROS.LK_OPERACAO.Value == "COMMIT" || program.LK_PARAMETROS.LK_OPERACAO.Value == "ROLLBACK");
                var envList0 = AppSettings.TestSet.DynamicData["VA4437B_CRELAT"].DynamicList;

                Assert.True(envList0.Count == 0);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SVA4437B_FILE_NAME_P", "RVA4437B_FILE_NAME_P", "RVA4437I_FILE_NAME_P", "RVA4437P_FILE_NAME_P", "RVA4437H_FILE_NAME_P")]
        public static void VA4437B_Tests_Theory_Produto_9304_ReturnCode_00(string SVA4437B_FILE_NAME_P, string RVA4437B_FILE_NAME_P, string RVA4437I_FILE_NAME_P, string RVA4437P_FILE_NAME_P, string RVA4437H_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA4437B_FILE_NAME_P = $"{SVA4437B_FILE_NAME_P}_{timestamp}.txt";
            RVA4437B_FILE_NAME_P = $"{RVA4437B_FILE_NAME_P}_{timestamp}.txt";
            RVA4437I_FILE_NAME_P = $"{RVA4437I_FILE_NAME_P}_{timestamp}.txt";
            RVA4437P_FILE_NAME_P = $"{RVA4437P_FILE_NAME_P}_{timestamp}.txt";
            RVA4437H_FILE_NAME_P = $"{RVA4437H_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                VA4437B_LK_PARAMETROS parameters = new VA4437B_LK_PARAMETROS();
                parameters.LK_OPERACAO.Value = "COMMIT";

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-08-20"},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , "2023-09-20"},
                { "SISTEMAS_DATA_MOV_ABERTO_15D" , "2024-07-04"},
                { "V1SIST_MESREFER" , "8"},
                { "V1SIST_ANOREFER" , "2024"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #region VA4437B_CRELAT

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , "1"},
                { "RELATORI_COD_USUARIO" , "SAS6419 "},
                { "RELATORI_COD_RELATORIO" , "VG0420B"},
                { "RELATORI_NUM_PARCELA" , "1"},
                { "RELATORI_TIMESTAMP" , "2003-03-17 17:27:09.991"},
                { "PROPOVA_DATA_QUITACAO" , "1992-04-01"},
                { "PROPOVA_NUM_APOLICE" , "93010000890"},
                { "PROPOVA_COD_SUBGRUPO" , "1   "},
                { "PROPOVA_NUM_CERTIFICADO" , "10000011003"},
                { "PROPOVA_COD_PRODUTO" , "9304"},
                { "PROPOVA_COD_CLIENTE" , "246850"},
                { "PROPOVA_OCOREND" , "1"},
                { "PROPOVA_IDE_SEXO" , " "},
                { "PROPOVA_SIT_REGISTRO" , "4"},
                { "PROPOVA_AGE_COBRANCA" , "0"},
                { "PROPOVA_COD_FONTE" , "21"},
                { "PROPOVA_IDADE" , "48"},
                { "PROPOVA_OCORR_HISTORICO" , "18"},
                { "PROPOVA_FAIXA_RENDA_IND" , ""},
                { "PROPOVA_FAIXA_RENDA_FAM" , ""},
                { "PRODUVG_CODRELAT" , "VP0420B"},
                { "PRODUVG_PERI_PAGAMENTO" , "1"},
                { "PRODUTO_COD_EMPRESA" , "11"},
                { "PRODUTO_DESCR_PRODUTO" , "PREFERENCIAL VIDA                       "},
                { "PRODUTO_NUM_PROCESSO_SUSEP" , "15414.002262\\/2007-07     "},
                });
                AppSettings.TestSet.DynamicData.Remove("VA4437B_CRELAT");
                AppSettings.TestSet.DynamicData.Add("VA4437B_CRELAT", q5);

                #endregion
                #region VA4437B_V1AGENCEF

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , "0"},
                { "FONTES_NOME_FONTE" , "RIO DE JANEIRO                          "},
                { "FONTES_ENDERECO" , "AV GRACA ARANHA,182 - 2 ANDAR -         "},
                { "FONTES_BAIRRO" , "CASTELO             "},
                { "FONTES_CIDADE" , "RIO DE JANEIRO      "},
                { "FONTES_CEP" , "20030001"},
                { "FONTES_SIGLA_UF" , "RJ"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA4437B_V1AGENCEF");
                AppSettings.TestSet.DynamicData.Add("VA4437B_V1AGENCEF", q4);

                #endregion

                #region VA4437B_CFAIXACEP

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , "1"},
                { "GEFAICEP_CEP_INICIAL" , "1001000"},
                { "GEFAICEP_CEP_FINAL" , "1028999"},
                { "GEFAICEP_DESCRICAO_FAIXA" , "CDD SE\\/SPM"},
                { "GEFAICEP_CENTRALIZADOR" , "CTC\\/MOOCA\\/SPM   01"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA4437B_CFAIXACEP");
                AppSettings.TestSet.DynamicData.Add("VA4437B_CFAIXACEP", q1);

                #endregion
                #region VA4437B_CMSG

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_NUM_APOLICE" , "93010000890"},
                { "COBMENVG_CODSUBES" , "1"},
                { "COBMENVG_COD_OPERACAO" , "2"},
                { "COBMENVG_JDE" , "PV01"},
                { "COBMENVG_JDL" , "PV"},
                { "COBMENVG_IDFORM" , "A4"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA4437B_CMSG");
                AppSettings.TestSet.DynamicData.Add("VA4437B_CMSG", q2);

                #endregion
                #region VA4437B_CFCPLANO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "FCPLANO_NUM_PLANO" , "123"},
                { "FCPLANO_QTD_DIG_COMBINACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA4437B_CFCPLANO");
                AppSettings.TestSet.DynamicData.Add("VA4437B_CFCPLANO", q3);

                #endregion
                #region R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , "1994-05-10"},
                { "HISCOBPR_COD_OPERACAO" , "106"},
                { "HISCOBPR_OPCAO_COBERTURA" , "L"},
                { "HISCOBPR_IMP_MORNATU" , "0.00"},
                { "HISCOBPR_IMPSEGCDG" , "0.00"},
                { "HISCOBPR_VLPREMIO" , "0.00"},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "0.00"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q15);

                #endregion

                #region VA4437B_CTITFEDCA

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "TITFEDCA_NRTITFDCAP" , "180011534162"},
                { "TITFEDCA_NRSORTEIO" , "89170"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA4437B_CTITFEDCA");
                AppSettings.TestSet.DynamicData.Add("VA4437B_CTITFEDCA", q6);

                #endregion

                #region R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "FCPROSUS_COD_PROCESSO_SUSEP" , "19790324"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1", q11);

                #endregion
                #region R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "2"},
                { "SEGURVGA_COD_CLIENTE" , "640712"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1990-07-10"},
                { "WHOST_DATA_TERVIG_PREMIO" , "1990-08-10"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_OCORR_ENDERECO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "1"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q8);

                #endregion
                #region R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "JOAO FERREIRA"},
                { "CLIENTES_CGCCPF" , "12345678999"},
                { "CLIENTES_IDE_SEXO" , "M"},
                { "CLIENTES_DATA_NASCIMENTO" , "1970-12-11"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q12);

                #endregion
                #region R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO                                                                "},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q14);

                #endregion
                #region R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "1"},
                { "APOLICES_RAMO_EMISSOR" , "11"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1", q17);

                #endregion
                #region R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2020-01-28"},
                { "ENDOSSOS_DATA_TERVIGENCIA_1" , "2019-01-28"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q18);

                #endregion
                #region R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q38);

                #endregion
                #region R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , "I"},
                { "RELATORI_NUM_APOL_LIDER" , "VDHTML05       "},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q40);

                #endregion
                #region R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "HUGO"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q24);

                #endregion
                #region R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1", q20);

                #endregion

                #region R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , ""},
                { "COBMENVG_JDL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1", q32);

                #endregion

                #endregion
                var program = new VA4437B();
                program.Execute(parameters, SVA4437B_FILE_NAME_P, RVA4437B_FILE_NAME_P, RVA4437I_FILE_NAME_P, RVA4437P_FILE_NAME_P, RVA4437H_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var val2r) && val2r.Contains("2024-08-20"));
                Assert.True(envList1[1].TryGetValue("WHOST_NRAPOLICE", out var val3r) && val3r.Contains("0093010000890"));

                //produto vida 9304
                Assert.True(program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9304);
            }
        }
    }
}