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
using static Code.FN0303B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    [Collection("FN0303B_Tests")]
    public class FN0303B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""},
                { "SIST_CURRDATE" , ""},
                { "SIST_DTMINDEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region FN0303B_DEBITO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "NRAPOLICE" , ""},
                { "CODSUBES" , ""},
                { "SITUACAO_PROP" , ""},
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "OPCAOPAG" , ""},
                { "OCORHIST" , ""},
                { "VLPRMTOT" , ""},
                { "SITUACAO_COBR" , ""},
                { "DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0303B_DEBITO", q1);

            #endregion

            #region M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "APOLCORR_CODCORR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_LANC" , ""},
                { "CODRET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "DATA_QUITACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "DTVENCTO_PARCELA" , ""},
                { "NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("FN0303B_t1")]
        public static void FN0303B_Tests_Theory(string MOVIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , "2020-01-01"},
                { "SIST_CURRDATE" , "1"},
                { "SIST_DTMINDEB" , "2002-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region FN0303B_DEBITO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "NRAPOLICE" , "123"},
                { "CODSUBES" , "1"},
                { "SITUACAO_PROP" , "2"},
                { "NRCERTIF" , "3"},
                { "NRPARCEL" , "0"},
                { "AGECTADEB" , "1"},
                { "OPRCTADEB" , "0"},
                { "NUMCTADEB" , "3"},
                { "DIGCTADEB" , "4"},
                { "OPCAOPAG" , "5"},
                { "OCORHIST" , "6"},
                { "VLPRMTOT" , "14"},
                { "SITUACAO_COBR" , "1"},
                { "DTVENCTO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("FN0303B_DEBITO");
                AppSettings.TestSet.DynamicData.Add("FN0303B_DEBITO", q1);

                #endregion

                #region M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "APOLCORR_CODCORR" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_LANC" , "1"},
                { "CODRET" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "DATA_QUITACAO" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "DTVENCTO_PARCELA" , "2020-01-01"},
                { "NUM_ENDOSSO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1", q5);

                #endregion
                #endregion

                var program = new FN0303B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["M_0000_PRINCIPAL_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["FN0303B_DEBITO"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                var envList6 = AppSettings.TestSet.DynamicData["M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList6);


                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("FN0303B_t2")]
        public static void FN0303B_Tests99_Theory(string MOVIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region FN0303B_DEBITO

                var q1 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("FN0303B_DEBITO");
                AppSettings.TestSet.DynamicData.Add("FN0303B_DEBITO", q1);

                #endregion

                #region M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "APOLCORR_CODCORR" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_LANC" , "1"},
                { "CODRET" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "DATA_QUITACAO" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1

                var q5 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1", q5);

                #endregion
                #endregion

                var program = new FN0303B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

              
                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}