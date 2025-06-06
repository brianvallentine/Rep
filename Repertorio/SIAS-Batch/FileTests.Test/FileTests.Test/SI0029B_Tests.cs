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
using static Code.SI0029B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0029B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0029B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , "2024-11-21"}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_000_FINALIZACAO_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_FINALIZACAO_DB_UPDATE_1_Update1", q1);

            #endregion

            #region Execute_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "W_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q2);

            #endregion

            #region SI0029B_PRINCIPAL

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0MEST_FONTE" , ""},
                { "V0MEST_PROTSINI" , ""},
                { "V0MEST_NUM_APOL_SINISTRO" , ""},
                { "V0MEST_NUM_APOLICE" , ""},
                { "V0MEST_NRCERTIF" , ""},
                { "V0MEST_CODSUBES" , ""},
                { "V0MEST_CODCAU" , ""},
                { "V0MEST_DATORR" , ""},
                { "V0MEST_DATCMD" , ""},
                { "V0MEST_DATTEC" , ""},
                { "V0MEST_SITUACAO" , ""},
                { "V0PROP_IDADE" , ""},
                { "V0SAVG_IDE_SEXO" , ""},
                { "V0SAVG_DT_NASCM" , ""},
                { "V0CLI_COD_CLIENTE" , ""},
                { "V0CLI_NOME_RAZAO" , ""},
                { "V0CLI_DATA_NASCM" , ""},
                { "V0SCAU_DESCAU" , ""},
                { "V0CDGC_DTINIVIG" , ""},
                { "SEGVGAPH_OCORR_HISTORICO" , ""},
                { "SEGVGAPH_COD_OPERACAO" , ""},
                { "CA_IND_ATIVO" , ""},
                { "CA_MOTIV_CANCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0029B_PRINCIPAL", q3);

            #endregion

            #region SI0029B_V0ACOMSINI

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0ACOM_OPERACAO" , ""},
                { "V0ACOM_DATOPR" , ""},
                { "V0ACOM_CODUSU" , ""},
                { "V0OPER_DESOPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0029B_V0ACOMSINI", q4);

            #endregion

            #region M_020_PROCESSA_PRINCIPAL_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_020_PROCESSA_PRINCIPAL_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_DTMOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_SI0029B_1.txt", "Saida_SI0029B_2.txt")]
        public static void SI0029B_Tests_Theory(string SI0029R1_FILE_NAME_P, string SI0029R2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0029R1_FILE_NAME_P = $"{SI0029R1_FILE_NAME_P}_{timestamp}.txt";
            SI0029R2_FILE_NAME_P = $"{SI0029R2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new SI0029B();
                program.Execute(SI0029R1_FILE_NAME_P, SI0029R2_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                //"M_000_FINALIZACAO_Update1"	

                var envList = AppSettings.TestSet.DynamicData["M_000_FINALIZACAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("SIST_DTMOVABE", out var val1r) && val1r.Contains("2024-11-21"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("Saida_SI0029B_1.txt", "Saida_SI0029B_2.txt")]
        public static void SI0029B_Tests_TheoryEscreveArquivo(string SI0029R1_FILE_NAME_P, string SI0029R2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0029R1_FILE_NAME_P = $"{SI0029R1_FILE_NAME_P}_{timestamp}.txt";
            SI0029R2_FILE_NAME_P = $"{SI0029R2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region Execute_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "W_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q1);

                #endregion
                #endregion
                var program = new SI0029B();
                program.Execute(SI0029R1_FILE_NAME_P, SI0029R2_FILE_NAME_P);

                //Verificar se arquivos de saida escreveram
                Assert.True(File.Exists(program.SI0029R1.FilePath));
                Assert.True(new FileInfo(program.SI0029R1.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.SI0029R2.FilePath));
                Assert.True(new FileInfo(program.SI0029R2.FilePath)?.Length > 0);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);
                Assert.True(program.RETURN_CODE == 0);


            }
        }
        [Theory]
        [InlineData("Saida_SI0029B_1.txt", "Saida_SI0029B_2.txt")]
        public static void SI0029B_Tests_Theory1(string SI0029R1_FILE_NAME_P, string SI0029R2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0029R1_FILE_NAME_P = $"{SI0029R1_FILE_NAME_P}_{timestamp}.txt";
            SI0029R2_FILE_NAME_P = $"{SI0029R2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region Execute_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "W_COUNT" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q1);

                #endregion
                #endregion
                var program = new SI0029B();
                program.Execute(SI0029R1_FILE_NAME_P, SI0029R2_FILE_NAME_P);

                //Verificar se arquivos de saida escreveram
                //Assert.True(File.Exists(program.SI0029R1.FilePath));
                //Assert.True(new FileInfo(program.SI0029R1.FilePath)?.Length > 0);

                //Assert.True(File.Exists(program.SI0029R2.FilePath));
                //Assert.True(new FileInfo(program.SI0029R2.FilePath)?.Length > 0);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                //"M_000_FINALIZACAO_Update1"	
                var envList = AppSettings.TestSet.DynamicData["M_000_FINALIZACAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("SIST_DTMOVABE", out var val1r) && val1r.Contains("2024-11-21"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("Saida_SI0029B_1.txt", "Saida_SI0029B_2.txt")]
        public static void SI0029B_Tests_TheoryErro99(string SI0029R1_FILE_NAME_P, string SI0029R2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0029R1_FILE_NAME_P = $"{SI0029R1_FILE_NAME_P}_{timestamp}.txt";
            SI0029R2_FILE_NAME_P = $"{SI0029R2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0029B();
                program.Execute(SI0029R1_FILE_NAME_P, SI0029R2_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}