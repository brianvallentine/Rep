using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA0345B;

namespace FileTests.Test
{
    [Collection("VA0345B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0345B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , ""},
                { "SIST_DTMINDEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "PARM_VERSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA0345B_DEBITO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "VLPRMTOT" , ""},
                { "SITUACAO" , ""},
                { "DTVENCTO" , ""},
                { "NSAS" , ""},
                { "NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0345B_DEBITO", q2);

            #endregion

            #region M_0000_PRINCIPAL_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , ""},
                { "PARM_NSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_INSERT_1_Insert1", q3);

            #endregion

            #region M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PARM_NSA" , ""},
                { "SQL_NOT_NULL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_9000_FINALIZA_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARM_NSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_UPDATE_1_Update1", q5);

            #endregion

            #region M_9000_FINALIZA_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "SIST_CURRDATE" , ""},
                { "SIST_DTMAXDEB" , ""},
                { "PARM_VERSAO" , ""},
                { "FITSAS_REG" , ""},
                { "FITSAS_VALOR" , ""},
                { "FITSAS_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_INSERT_1_Insert1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("")]
        public static void VA0345B_Tests_Theory(string MOVIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VA0345B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
        [Theory]
        [InlineData("Saida_VA0345B.txt")]
        public static void VA0345B_Tests_Theory1(string MOVIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SIST_CURRDATE" , "2024-09-03"},
                    { "SIST_DTMINDEB" , "2024-09-04"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "PARM_CODCONV" , "6090"},
                    { "PARM_NSA" , "9000"},
                    { "PARM_VERSAO" , "4"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region VA0345B_DEBITO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "NRCERTIF" , "10000038929"},
                    { "NRPARCEL" , "160"},
                    { "AGECTADEB" , "0"},
                    { "OPRCTADEB" , "0"},
                    { "NUMCTADEB" , "0"},
                    { "DIGCTADEB" , "0"},
                    { "VLPRMTOT" , "240.22"},
                    { "SITUACAO" , "0"},
                    { "DTVENCTO" , "2024-08-20"},
                    { "NSAS" , ""},
                    { "NSL" , ""},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                    { "NRCERTIF" , "70000130083054"},
                    { "NRPARCEL" , "1"},
                    { "AGECTADEB" , "0"},
                    { "OPRCTADEB" , "0"},
                    { "NUMCTADEB" , "0"},
                    { "DIGCTADEB" , "0"},
                    { "VLPRMTOT" , "216.64"},
                    { "SITUACAO" , "0"},
                    { "DTVENCTO" , "2024-08-20"},
                    { "NSAS" , ""},
                    { "NSL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0345B_DEBITO");
                AppSettings.TestSet.DynamicData.Add("VA0345B_DEBITO", q2);

                #endregion
                #endregion
                var program = new VA0345B();
                program.Execute(MOVIMENTO_FILE_NAME_P);


                var envlist = AppSettings.TestSet.DynamicData["M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envlist[1].TryGetValue("PARM_NSA", out var valor) && valor.Contains("9001"));

                var envlist1 = AppSettings.TestSet.DynamicData["M_0000_PRINCIPAL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envlist1[1].Count > 1);
                Assert.True(envlist1[1].TryGetValue("PARM_NSA", out var val2r) && val2r.Contains("9001"));
                Assert.True(envlist1[1].TryGetValue("SIST_CURRDATE", out var val3r) && val3r.Contains("2024-09-03"));

                var envlist2 = AppSettings.TestSet.DynamicData["M_9000_FINALIZA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envlist2[1].TryGetValue("PARM_NSA", out var val4r) && val4r.Contains("9001"));

                var envlist3 = AppSettings.TestSet.DynamicData["M_9000_FINALIZA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envlist3[1].Count > 1);
                Assert.True(envlist3[1].TryGetValue("PARM_NSA", out var val5r) && val5r.Contains("9001"));
                Assert.True(envlist3[1].TryGetValue("PARM_CODCONV", out var val6r) && val6r.Contains("6090"));                         

                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}