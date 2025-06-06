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
using static Code.SI0021B;

namespace FileTests.Test
{
    [Collection("SI0021B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class SI0021B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0021B_V1HISTSIN

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_OPERACAO" , ""},
                { "V1HIST_OCORHIST" , ""},
                { "V1HIST_NOMFAV" , ""},
                { "V1HIST_DTMOVTO" , ""},
                { "V1HIST_VAL_OPER" , ""},
                { "V1HIST_LIMCRR" , ""},
                { "V1MEST_NUM_APOL" , ""},
                { "V1MEST_NRENDOS" , ""},
                { "V1MEST_APOL_SINI" , ""},
                { "V1MEST_DATCMD" , ""},
                { "V1MEST_DATORR" , ""},
                { "V1MEST_NRCERTIF" , ""},
                { "V1MEST_MOEDA_SINI" , ""},
                { "V1MEST_IDTPSEGU" , ""},
                { "V1MEST_NUMIRB" , ""},
                { "V1MEST_CODSUBES" , ""},
                { "V1MEST_NREMBARQ" , ""},
                { "V1MEST_REFEMBQ" , ""},
                { "V1MEST_VALSEGBT" , ""},
                { "V1MEST_PCPARTIC" , ""},
                { "V1MEST_CODCAU" , ""},
                { "V1MEST_RAMO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "V1RELA_COD_USUARIO" , ""},
                { "RELATORI_COD_CONGENERE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "WS_TIPO_CURSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0021B_V1HISTSIN", q0);

            #endregion

            #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_MNUEMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_025_000_SISTEMA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_025_000_SISTEMA_DB_SELECT_1_Query1", q2);

            #endregion

            #region SI0021B_V1APOLCOSCED

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1APCO_CODCOSS" , ""},
                { "V1APCO_PCPARTIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0021B_V1APOLCOSCED", q3);

            #endregion

            #region R1000_LE_USUARIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0USU_NOME_USUARIO" , ""},
                { "V0USU_DEPARTAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_USUARIO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CA_VALOR_TOTAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1CONGE_NOMECONG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOME" , ""},
                { "V1APOL_MODALIDA" , ""},
                { "V1APOL_CODCLIEN" , ""},
                { "V1APOL_PODPUBL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_CORRECAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_300_000_LER_V1RAMO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_000_LER_V1RAMO_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1ORDE_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1", q11);

            #endregion

            #region SI0021B_SX_APOLCOSG

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , ""},
                { "SX118_COD_CONGENERE" , ""},
                { "SX118_PCT_PARTICIPACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0021B_SX_APOLCOSG", q12);

            #endregion

            #region M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , ""},
                { "V1MOED_SIGLUNIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0COSSEG_HISTSIN_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1", q14);

            #endregion

            #region M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1APIT_DESCRITEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1SEGVG_COD_CLI" , ""},
                { "V1SEGVG_DTNASCIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1", q16);

            #endregion

            #region M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1COND_GARAN_IEA" , ""},
                { "V1COND_GARAN_IPA" , ""},
                { "V1COND_GARAN_IPD" , ""},
                { "V1COND_GARAN_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0SINICAUSA_DESCAU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1", q19);

            #endregion

            #region M_000_00_SELECT_V0SINI_LOCAL1_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0SINI_LOCAL1_ENDERECO_SINI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_00_SELECT_V0SINI_LOCAL1_DB_SELECT_1_Query1", q20);

            #endregion

            #region M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0ENDERECOS_ENDERECO" , ""},
                { "V0ENDERECOS_BAIRRO" , ""},
                { "V0ENDERECOS_CIDADE" , ""},
                { "V0ENDERECOS_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1", q21);

            #endregion

            #region M_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q22);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0021BM1_Saida1.txt", "SI0021BM2_Saida1.txt")]
        public static void SI0021B_Tests_Theory_ReturnCode_0(string SI0021M1_FILE_NAME_P, string SI0021M2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0021M1_FILE_NAME_P = $"{SI0021M1_FILE_NAME_P}_{timestamp}.txt";
            SI0021M2_FILE_NAME_P = $"{SI0021M2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_025_000_SISTEMA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2021-05-05"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_025_000_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_025_000_SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_MNUEMP" , "CAIXA VIDA SEGURADORA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q1);

                #endregion
                #region SI0021B_V1HISTSIN

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_OPERACAO" , "1090"},
                { "V1HIST_OCORHIST" , "2"},
                { "V1HIST_NOMFAV" , ""},
                { "V1HIST_DTMOVTO" , ""},
                { "V1HIST_VAL_OPER" , "10000"},
                { "V1HIST_LIMCRR" , ""},
                { "V1MEST_NUM_APOL" , "101800233695"},
                { "V1MEST_NRENDOS" , ""},
                { "V1MEST_APOL_SINI" , "101800138851"},
                { "V1MEST_DATCMD" , ""},
                { "V1MEST_DATORR" , ""},
                { "V1MEST_NRCERTIF" , ""},
                { "V1MEST_MOEDA_SINI" , ""},
                { "V1MEST_IDTPSEGU" , ""},
                { "V1MEST_NUMIRB" , ""},
                { "V1MEST_CODSUBES" , ""},
                { "V1MEST_NREMBARQ" , ""},
                { "V1MEST_REFEMBQ" , ""},
                { "V1MEST_VALSEGBT" , ""},
                { "V1MEST_PCPARTIC" , ""},
                { "V1MEST_CODCAU" , ""},
                { "V1MEST_RAMO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , "CLIB "},
                { "V1RELA_COD_USUARIO" , ""},
                { "RELATORI_COD_CONGENERE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "WS_TIPO_CURSOR" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0021B_V1HISTSIN");
                AppSettings.TestSet.DynamicData.Add("SI0021B_V1HISTSIN", q0);

                #endregion
                #region M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1"},
                { "V1MOED_SIGLUNIM" , "R$"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1", q13);

                #endregion
                #region M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0COSSEG_HISTSIN_VAL_OPERACAO" , "750"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1", q14);

                #endregion
                #region M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOME" , "JOÃO"},
                { "V1APOL_MODALIDA" , "0"},
                { "V1APOL_CODCLIEN" , "1"},
                { "V1APOL_PODPUBL" , "N"},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOME" , "JOÃO"},
                { "V1APOL_MODALIDA" , "0"},
                { "V1APOL_CODCLIEN" , "1"},
                { "V1APOL_PODPUBL" , "N"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1", q7);

                #endregion
                #region M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_DTINIVIG" , "1974-07-31"},
                { "V1ENDO_DTTERVIG" , "2038-01-24"},
                { "V1ENDO_CORRECAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1", q8);

                #endregion
                #endregion
                var program = new SI0021B();
                program.Execute(SI0021M1_FILE_NAME_P, SI0021M2_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(program.V1MEST_APOL_SINI.Value == 101800138851);

                var envList0 = AppSettings.TestSet.DynamicData["M_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("UpdateCheck", out var valor0) && valor0.Contains("UpdateCheck"));

            }
        }
        [Theory]
        [InlineData("SI0021BM1_Saida2.txt", "SI0021BM2_Saida2.txt")]
        public static void SI0021B_Tests_Theory_NoProcessing_ReturnCode_0(string SI0021M1_FILE_NAME_P, string SI0021M2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0021M1_FILE_NAME_P = $"{SI0021M1_FILE_NAME_P}_{timestamp}.txt";
            SI0021M2_FILE_NAME_P = $"{SI0021M2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_025_000_SISTEMA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2021-05-05"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_025_000_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_025_000_SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_MNUEMP" , "CAIXA VIDA SEGURADORA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q1);

                #endregion
                #region SI0021B_V1HISTSIN

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("SI0021B_V1HISTSIN");
                AppSettings.TestSet.DynamicData.Add("SI0021B_V1HISTSIN", q0);

                #endregion
                #endregion
                var program = new SI0021B();
                program.Execute(SI0021M1_FILE_NAME_P, SI0021M2_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.W.CH_CHAVE_ATU.CH_OPER_ATU.Value == 9999);
            }
        
        }
        [Theory]
        [InlineData("SI0021BM1_Saida3.txt", "SI0021BM2_Saida3.txt")]
        public static void SI0021B_Tests_Theory_NoProcessing_ReturnCodeError_99(string SI0021M1_FILE_NAME_P, string SI0021M2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0021M1_FILE_NAME_P = $"{SI0021M1_FILE_NAME_P}_{timestamp}.txt";
            SI0021M2_FILE_NAME_P = $"{SI0021M2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_025_000_SISTEMA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2021-05-05"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_025_000_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_025_000_SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_MNUEMP" , "CAIXA VIDA SEGURADORA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q1);

                #endregion
                #region SI0021B_V1HISTSIN

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_OPERACAO" , "1090"},
                { "V1HIST_OCORHIST" , "2"},
                { "V1HIST_NOMFAV" , ""},
                { "V1HIST_DTMOVTO" , ""},
                { "V1HIST_VAL_OPER" , "10000"},
                { "V1HIST_LIMCRR" , ""},
                { "V1MEST_NUM_APOL" , "101800233695"},
                { "V1MEST_NRENDOS" , ""},
                { "V1MEST_APOL_SINI" , "101800138851"},
                { "V1MEST_DATCMD" , ""},
                { "V1MEST_DATORR" , ""},
                { "V1MEST_NRCERTIF" , ""},
                { "V1MEST_MOEDA_SINI" , ""},
                { "V1MEST_IDTPSEGU" , ""},

                });
                AppSettings.TestSet.DynamicData.Remove("SI0021B_V1HISTSIN");
                AppSettings.TestSet.DynamicData.Add("SI0021B_V1HISTSIN", q0);

                #endregion
                #endregion
                var program = new SI0021B();
                program.Execute(SI0021M1_FILE_NAME_P, SI0021M2_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}