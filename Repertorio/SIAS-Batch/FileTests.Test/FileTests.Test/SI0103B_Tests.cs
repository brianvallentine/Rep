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
using Code;
using static Code.SI0103B;
using Sias.Sinistro.DB2.SI0103B;

namespace FileTests.Test
{

    [Collection("SI0103B_Tests")]

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0103B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1FONTE_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "V1SISTEMA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q5);

            #endregion

            #region SI0103B_RELATORIOS

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1RELATORIOS_CODUSU" , ""},
                { "V1RELATORIOS_DATA1" , ""},
                { "V1RELATORIOS_DATA2" , ""},
                { "V1RELATORIOS_APOLICE1" , ""},
                { "V1RELATORIOS_RAMO1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0103B_RELATORIOS", q6);

            #endregion

            #region SI0103B_HISTMEST

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_APOLICE" , ""},
                { "V1HISTMEST_NUM_SINISTRO" , ""},
                { "V1HISTMEST_CODSUBES" , ""},
                { "V1HISTMEST_NRCERTIF" , ""},
                { "V1HISTMEST_IDTPSEGU" , ""},
                { "V1HISTMEST_PCPARTIC" , ""},
                { "V1HISTMEST_DATORR" , ""},
                { "V1HISTMEST_PCTRES" , ""},
                { "V1HISTMEST_FONTE" , ""},
                { "V1HISTMEST_RAMO" , ""},
                { "V1HISTMEST_COD_MOEDA_SINI" , ""},
                { "V1HISTMEST_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0103B_HISTMEST", q7);

            #endregion

            #region M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1PARAMRAMO_RAMO_VG" , ""},
                { "V1PARAMRAMO_RAMO_AP" , ""},
                { "V1PARAMRAMO_RAMO_VGAPC" , ""},
                { "V1PARAMRAMO_RAMO_SAUDE" , ""},
                { "V1PARAMRAMO_RAMO_EDUCACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0MOEDA_SIGLUNIM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_000_700_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_700_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1", q11);

            #endregion

            SI1000S_Tests.Load_Parameters();

            #endregion
        }

        [Theory]
        [InlineData("SI0103M1_1")]
        public static void SI0103B_Tests_Theory(string SI0103M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0103M1_FILE_NAME_P = $"{SI0103M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , "JOSE LOPES DE ARANTES"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , "ANTONIO SERGIO WANDERLEY"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1FONTE_NOMEFTE" , "GERAL"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , "CAIXA SEGURADORA S.A."}
            });
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q4);


                #endregion

                #region M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , "2025-01-27"},
                { "V1SISTEMA_DTCURRENT" ,  "2025-03-27"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q5);

                #endregion

                #region SI0103B_RELATORIOS

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1RELATORIOS_CODUSU" , "1"},
                { "V1RELATORIOS_DATA1" ,  "2025-01-27"},
                { "V1RELATORIOS_DATA2" ,  "2025-03-27"},
                { "V1RELATORIOS_APOLICE1" , "11001001961"},
                { "V1RELATORIOS_RAMO1" , "0"},
            });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1RELATORIOS_CODUSU" , "1"},
                { "V1RELATORIOS_DATA1" ,  "2025-01-27"},
                { "V1RELATORIOS_DATA2" ,  "2025-03-27"},
                { "V1RELATORIOS_APOLICE1" , "11001001961"},
                { "V1RELATORIOS_RAMO1" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0103B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0103B_RELATORIOS", q6);

                #endregion

                #region SI0103B_HISTMEST

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_APOLICE" , "11001001961"},
                { "V1HISTMEST_NUM_SINISTRO" , "11001001961"},
                { "V1HISTMEST_CODSUBES" , "1"},
                { "V1HISTMEST_NRCERTIF" , "1234567"},
                { "V1HISTMEST_IDTPSEGU" , "1"},
                { "V1HISTMEST_PCPARTIC" , "2"},
                { "V1HISTMEST_DATORR" ,  "2025-01-01"},
                { "V1HISTMEST_PCTRES" , "3"},
                { "V1HISTMEST_FONTE" , "GERAL"},
                { "V1HISTMEST_RAMO" , "32"},
                { "V1HISTMEST_COD_MOEDA_SINI" , "6"},
                { "V1HISTMEST_DTMOVTO" ,  "2025-01-01"},
            });
                
                AppSettings.TestSet.DynamicData.Remove("SI0103B_HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI0103B_HISTMEST", q7);

                #endregion

                #region M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1PARAMRAMO_RAMO_VG" , "93"},
                { "V1PARAMRAMO_RAMO_AP" , "82"},
                { "V1PARAMRAMO_RAMO_VGAPC" , "97"},
                { "V1PARAMRAMO_RAMO_SAUDE" , "87"},
                { "V1PARAMRAMO_RAMO_EDUCACAO" , "77"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , "RAMO 00 PARA CONTABILIDADE - DESATIVADO"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0MOEDA_SIGLUNIM" , "REAL"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1", q10);

                #endregion


                #endregion
                var program = new SI0103B();
                program.Execute(SI0103M1_FILE_NAME_P);
              
                //V1PARAMRAMO_RAMO_EDUCACAO <> 0
               // var envList1 = AppSettings.TestSet.DynamicData["M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1"].DynamicList;
              //  Assert.Empty(envList1);

                //V1HISTMEST_RAMO <> 32 e V1PARAMRAMO_RAMO_EDUCACAO = 0
                //var envList2 = AppSettings.TestSet.DynamicData["M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList2);

                //V1HISTMEST_RAMO = 32 e V1PARAMRAMO_RAMO_EDUCACAO = 0
                var envList3 = AppSettings.TestSet.DynamicData["M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["SI0103B_RELATORIOS"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["SI0103B_HISTMEST"].DynamicList;
                Assert.Empty(envList8);

                var envList9 = AppSettings.TestSet.DynamicData["M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList9);

                var envList10 = AppSettings.TestSet.DynamicData["M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList9);

                var envList11 = AppSettings.TestSet.DynamicData["M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList9);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0103M1_2")]
        public static void SI0103B_Tests99_Theory(string SI0103M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0103M1_FILE_NAME_P = $"{SI0103M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                /*q0.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , "JOSE LOPES DE ARANTES"}
            });*/
                AppSettings.TestSet.DynamicData.Remove("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1

                var q1 = new DynamicData();
               /* q1.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , "ANTONIO SERGIO WANDERLEY"}
            });*/
                AppSettings.TestSet.DynamicData.Remove("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1

                var q3 = new DynamicData();          
               
                AppSettings.TestSet.DynamicData.Remove("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q4);


                #endregion

                #region M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q5);

                #endregion

                #region SI0103B_RELATORIOS

                var q6 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("SI0103B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0103B_RELATORIOS", q6);

                #endregion

                #region SI0103B_HISTMEST

                var q7 = new DynamicData();
         
                AppSettings.TestSet.DynamicData.Remove("SI0103B_HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI0103B_HISTMEST", q7);

                #endregion

                #region M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1", q10);

                #endregion


                #endregion
                var program = new SI0103B();
                program.Execute(SI0103M1_FILE_NAME_P);

               

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}