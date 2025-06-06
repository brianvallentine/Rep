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
using static Code.BI6017B;

namespace FileTests.Test
{
    [Collection("BI6017B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI6017B_Tests
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
                { "SISTEMAS_MESREFER" , ""},
                { "SISTEMAS_ANOREFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI6017B_CFAIXACEP

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , ""},
                { "GEFAICEP_CEP_INICIAL" , ""},
                { "GEFAICEP_CEP_FINAL" , ""},
                { "GEFAICEP_DESCRICAO_FAIXA" , ""},
                { "GEFAICEP_CENTRALIZADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6017B_CFAIXACEP", q1);

            #endregion

            #region BI6017B_MOVDEBCC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI6017B_MOVDEBCC", q2);

            #endregion

            #region R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1100_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "APOLICES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_BILHETE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "TESTE"},
                { "CLIENTES_CGCCPF" , "TESTE"},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1", q6);

            #endregion
                        #region R1400_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""},
                { "FONTES_ENDERECO" , ""},
                { "FONTES_BAIRRO" , ""},
                { "FONTES_CIDADE" , ""},
                { "FONTES_SIGLA_UF" , ""},
                { "FONTES_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_FONTES_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_STA_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R9900_03_INSERT_OBJETO_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R9900_03_INSERT_OBJETO_DB_INSERT_1_Insert1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SBI6017B_Sort1.txt", "BI6017B1_Saida1.txt", "BI6017B2_Saida1.txt")]
        public static void BI6017B_Tests_Theory_Success_ReturnCode_0(string SBI6017B_FILE_NAME_P, string BI6017B1_FILE_NAME_P, string BI6017B2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SBI6017B_FILE_NAME_P = $"{SBI6017B_FILE_NAME_P}_{timestamp}.txt";
            BI6017B1_FILE_NAME_P = $"{BI6017B1_FILE_NAME_P}_{timestamp}.txt";
            BI6017B2_FILE_NAME_P = $"{BI6017B2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region BI6017B_CFAIXACEP

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , "7"},
                { "GEFAICEP_CEP_INICIAL" , "1100000"},
                { "GEFAICEP_CEP_FINAL" , "1199999"},
                { "GEFAICEP_DESCRICAO_FAIXA" , "CDD AL. NOTHMANN/SPM                                                    "},
                { "GEFAICEP_CENTRALIZADOR" , "CTC/MOOCA/SPM   01                                                      "},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6017B_CFAIXACEP");
                AppSettings.TestSet.DynamicData.Add("BI6017B_CFAIXACEP", q1);

                #endregion
                #region BI6017B_MOVDEBCC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "82579641462"}
                });
                AppSettings.TestSet.DynamicData.Remove("BI6017B_MOVDEBCC");
                AppSettings.TestSet.DynamicData.Add("BI6017B_MOVDEBCC", q2);

                #endregion
                #region R1100_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_COD_CLIENTE" , "7799635"},
                { "BILHETE_FONTE" , "10"},
                { "BILHETE_RAMO" , "72"},
                { "BILHETE_OCORR_ENDERECO" , "1"},
                { "BILHETE_NUM_APOLICE" , "1019790324"},
                { "APOLICES_COD_PRODUTO" , "1402"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_BILHETE_DB_SELECT_1_Query1", q4);

                #endregion
                #region R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "CLAUDIO GARCIA MAIA                     "},
                { "CLIENTES_CGCCPF" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q5);

                #endregion
                #region R1300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "RUA DA VERDADE 287                                                      "},
                { "ENDERECO_BAIRRO" , "SANTA CRUZ                                                              "},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "23555130"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new BI6017B();
                program.Execute(SBI6017B_FILE_NAME_P, BI6017B1_FILE_NAME_P, BI6017B2_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                var envList = AppSettings.TestSet.DynamicData["R9900_03_INSERT_OBJETO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("GEOBJECT_COD_PRODUTO", out var valor) && valor.Contains("1402"));
                Assert.True(envList.Count > 1);
            }
        }
        [Theory]
        [InlineData("SBI6017B_Sort2.txt", "BI6017B1_Saida2.txt", "BI6017B2_Saida2.txt")]
        public static void BI6017B_Tests_Theory_NoProcessing_ReturnCode_99(string SBI6017B_FILE_NAME_P, string BI6017B1_FILE_NAME_P, string BI6017B2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SBI6017B_FILE_NAME_P = $"{SBI6017B_FILE_NAME_P}_{timestamp}.txt";
            BI6017B1_FILE_NAME_P = $"{BI6017B1_FILE_NAME_P}_{timestamp}.txt";
            BI6017B2_FILE_NAME_P = $"{BI6017B2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region BI6017B_CFAIXACEP

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , "7"},
                { "GEFAICEP_CEP_INICIAL" , "1100000"},
                { "GEFAICEP_CEP_FINAL" , "1199999"},
                { "GEFAICEP_DESCRICAO_FAIXA" , "CDD AL. NOTHMANN/SPM                                                    "},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6017B_CFAIXACEP");
                AppSettings.TestSet.DynamicData.Add("BI6017B_CFAIXACEP", q1);

                #endregion
                #region BI6017B_MOVDEBCC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "82579641462"}
                });
                AppSettings.TestSet.DynamicData.Remove("BI6017B_MOVDEBCC");
                AppSettings.TestSet.DynamicData.Add("BI6017B_MOVDEBCC", q2);

                #endregion
                #endregion
                var program = new BI6017B();
                program.Execute(SBI6017B_FILE_NAME_P, BI6017B1_FILE_NAME_P, BI6017B2_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }

        [Theory]
        [InlineData("SBI6017B_Sort3.txt", "BI6017B1_Saida3.txt", "BI6017B2_Saida3.txt")]
        public static void BI6017B_Tests_Theory_NoProcessing_ReturnCode_0(string SBI6017B_FILE_NAME_P, string BI6017B1_FILE_NAME_P, string BI6017B2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SBI6017B_FILE_NAME_P = $"{SBI6017B_FILE_NAME_P}_{timestamp}.txt";
            BI6017B1_FILE_NAME_P = $"{BI6017B1_FILE_NAME_P}_{timestamp}.txt";
            BI6017B2_FILE_NAME_P = $"{BI6017B2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region BI6016B_MOVDEBCC

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("BI6017B_MOVDEBCC");
                AppSettings.TestSet.DynamicData.Add("BI6017B_MOVDEBCC", q2);

                #endregion
                #endregion
                var program = new BI6017B();
                program.Execute(SBI6017B_FILE_NAME_P, BI6017B1_FILE_NAME_P, BI6017B2_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}