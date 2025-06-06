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
using static Code.SI0110B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0110B_Tests")]
    public class SI0110B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "V1SISTEMA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0110B_RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1RELATORIOS_DATA1" , ""},
                { "V1RELATORIOS_DATA2" , ""},
                { "V1RELATORIOS_APOLICE1" , ""},
                { "V1RELATORIOS_CODUSU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0110B_RELATORIOS", q2);

            #endregion

            #region SI0110B_HISTMEST

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_SINISTRO" , ""},
                { "V1HISTMEST_VAL_OPERACAO2" , ""},
                { "V1HISTMEST_NUM_APOLICE" , ""},
                { "V1HISTMEST_OCORHIST" , ""},
                { "V1HISTMEST_OPERACAO" , ""},
                { "V1HISTMEST_IDTPSEGU" , ""},
                { "V1HISTMEST_CODSUBES" , ""},
                { "V1HISTMEST_NRCERTIF" , ""},
                { "V1HISTMEST_ESTADO" , ""},
                { "V1HISTMEST_NOMFAV" , ""},
                { "V1HISTMEST_DTMOVTO" , ""},
                { "V1HISTMEST_DATCMD" , ""},
                { "V1HISTMEST_DATORR" , ""},
                { "V1HISTMEST_FONTE" , ""},
                { "V1HISTMEST_RAMO" , ""},
                { "V1HISTMEST_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0110B_HISTMEST", q3);

            #endregion

            #region M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1PARAMRAMO_RAMO_VG" , ""},
                { "V1PARAMRAMO_RAMO_AP" , ""},
                { "V1PARAMRAMO_RAMO_VGAPC" , ""},
                { "V1PARAMRAMO_RAMO_SAUDE" , ""},
                { "V1PARAMRAMO_RAMO_EDUCACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1", q5);

            #endregion

            #region M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_VAL_OPERACAO1" , ""},
                { "V1HISTMEST_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1FONTE_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0110B_1")]
        public static void SI0110B_Tests_Theory_Erro99(string SI0110M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0110M1_FILE_NAME_P = $"{SI0110M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , ""}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0110B();
                program.Execute(SI0110M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("SI0110B_2")]
        public static void SI0110B_Tests_Theory_Case1(string SI0110M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0110M1_FILE_NAME_P = $"{SI0110M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0110B_HISTMEST

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_SINISTRO" , "1"},
                { "V1HISTMEST_VAL_OPERACAO2" , "1"},
                { "V1HISTMEST_NUM_APOLICE" , "1"},
                { "V1HISTMEST_OCORHIST" , "1"},
                { "V1HISTMEST_OPERACAO" , "1"},
                { "V1HISTMEST_IDTPSEGU" , "1"},
                { "V1HISTMEST_CODSUBES" , "1"},
                { "V1HISTMEST_NRCERTIF" , "1"},
                { "V1HISTMEST_ESTADO" , "1"},
                { "V1HISTMEST_NOMFAV" , "1"},
                { "V1HISTMEST_DTMOVTO" , "1"},
                { "V1HISTMEST_DATCMD" , "1"},
                { "V1HISTMEST_DATORR" , "1"},
                { "V1HISTMEST_FONTE" , "1"},
                { "V1HISTMEST_RAMO" , "1"},
                { "V1HISTMEST_PRODUTO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0110B_HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI0110B_HISTMEST", q3);

                #endregion
                #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , "CAIXA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1PARAMRAMO_RAMO_VG" , "1"},
                { "V1PARAMRAMO_RAMO_AP" , "1"},
                { "V1PARAMRAMO_RAMO_VGAPC" , "1"},
                { "V1PARAMRAMO_RAMO_SAUDE" , "1"},
                { "V1PARAMRAMO_RAMO_EDUCACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q4);

                #endregion

                #endregion
                var program = new SI0110B();
                program.Execute(SI0110M1_FILE_NAME_P);

                //M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1"].DynamicList);

                //M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1"].DynamicList);

                //M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1"].DynamicList);

                //M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1"].DynamicList);

                //M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1"].DynamicList);

                //M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1"].DynamicList);

                //M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1"].DynamicList);

                //M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0110B_3")]
        public static void SI0110B_Tests_Theory_Case2(string SI0110M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0110M1_FILE_NAME_P = $"{SI0110M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0110B_HISTMEST

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_SINISTRO" , "1"},
                { "V1HISTMEST_VAL_OPERACAO2" , "1"},
                { "V1HISTMEST_NUM_APOLICE" , "1"},
                { "V1HISTMEST_OCORHIST" , "1"},
                { "V1HISTMEST_OPERACAO" , "1"},
                { "V1HISTMEST_IDTPSEGU" , ""},
                { "V1HISTMEST_CODSUBES" , "1"},
                { "V1HISTMEST_NRCERTIF" , "00"},
                { "V1HISTMEST_ESTADO" , "1"},
                { "V1HISTMEST_NOMFAV" , "1"},
                { "V1HISTMEST_DTMOVTO" , "1"},
                { "V1HISTMEST_DATCMD" , "1"},
                { "V1HISTMEST_DATORR" , "1"},
                { "V1HISTMEST_FONTE" , "1"},
                { "V1HISTMEST_RAMO" , "1"},
                { "V1HISTMEST_PRODUTO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0110B_HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI0110B_HISTMEST", q3);

                #endregion
                #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , "CAIXA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1PARAMRAMO_RAMO_VG" , "1"},
                { "V1PARAMRAMO_RAMO_AP" , "1"},
                { "V1PARAMRAMO_RAMO_VGAPC" , "1"},
                { "V1PARAMRAMO_RAMO_SAUDE" , "1"},
                { "V1PARAMRAMO_RAMO_EDUCACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q4);

                #endregion
                #endregion
                var program = new SI0110B();
                program.Execute(SI0110M1_FILE_NAME_P);

                //M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1"].DynamicList);

                //M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1"].DynamicList);

                //M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1"].DynamicList);

                //M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1"].DynamicList);

                //M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1"].DynamicList);

                //M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1"].DynamicList);

                //M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1"].DynamicList);

                //M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0110B_4")]
        public static void SI0110B_Tests_Theory_Case3(string SI0110M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0110M1_FILE_NAME_P = $"{SI0110M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0110B_HISTMEST

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_SINISTRO" , "1"},
                { "V1HISTMEST_VAL_OPERACAO2" , "1"},
                { "V1HISTMEST_NUM_APOLICE" , "1"},
                { "V1HISTMEST_OCORHIST" , "1"},
                { "V1HISTMEST_OPERACAO" , "1"},
                { "V1HISTMEST_IDTPSEGU" , ""},
                { "V1HISTMEST_CODSUBES" , "1"},
                { "V1HISTMEST_NRCERTIF" , "00"},
                { "V1HISTMEST_ESTADO" , "1"},
                { "V1HISTMEST_NOMFAV" , "1"},
                { "V1HISTMEST_DTMOVTO" , "1"},
                { "V1HISTMEST_DATCMD" , "1"},
                { "V1HISTMEST_DATORR" , "1"},
                { "V1HISTMEST_FONTE" , "1"},
                { "V1HISTMEST_RAMO" , "32"},
                { "V1HISTMEST_PRODUTO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0110B_HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI0110B_HISTMEST", q3);

                #endregion
                #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , "CAIXA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1PARAMRAMO_RAMO_VG" , "2"},
                { "V1PARAMRAMO_RAMO_AP" , "2"},
                { "V1PARAMRAMO_RAMO_VGAPC" , "2"},
                { "V1PARAMRAMO_RAMO_SAUDE" , "2"},
                { "V1PARAMRAMO_RAMO_EDUCACAO" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q4);

                #endregion
                #endregion
                var program = new SI0110B();
                program.Execute(SI0110M1_FILE_NAME_P);

                //M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1"].DynamicList);

                //M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1"].DynamicList);

                //M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1"].DynamicList);

                //M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1"].DynamicList);

                //M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_200_300_SELECT_V1RAMO_DB_SELECT_1_Query1"].DynamicList);

                //M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1"].DynamicList);

                //M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1"].DynamicList);

                //M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}