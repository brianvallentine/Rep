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
using static Code.EM8008B;

namespace FileTests.Test
{
    [Collection("EM8008B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class EM8008B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_DTCURRENT_18" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_550_11_NOVO_NSAC_6088_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_550_11_NOVO_NSAC_6088_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CONFITCE_NSAC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("123456789", "PRD.EM.D240913.EM8006B.SICOV", "SAIDA01_FILE_NAME_P", "SAIDA02_FILE_NAME_P", "SAIDA03_FILE_NAME_P", "SAIDA04_FILE_NAME_P", "SAIDA05_FILE_NAME_P", "SAIDA06_FILE_NAME_P", "SAIDA07_FILE_NAME_P", "SAIDA08_FILE_NAME_P", "SAIDA09_FILE_NAME_P", "SAIDA10_FILE_NAME_P", "SAIDA11_FILE_NAME_P", "SAIDA12_FILE_NAME_P", "SAIDA13_FILE_NAME_P", "SAIDA14_FILE_NAME_P", "SAIDA15_FILE_NAME_P")]
        public static void EM8008B_Tests_Theory(string ARQSORT_FILE_NAME_P, string ENTRADA_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P, string SAIDA04_FILE_NAME_P, string SAIDA05_FILE_NAME_P, string SAIDA06_FILE_NAME_P, string SAIDA07_FILE_NAME_P, string SAIDA08_FILE_NAME_P, string SAIDA09_FILE_NAME_P, string SAIDA10_FILE_NAME_P, string SAIDA11_FILE_NAME_P, string SAIDA12_FILE_NAME_P, string SAIDA13_FILE_NAME_P, string SAIDA14_FILE_NAME_P, string SAIDA15_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            SAIDA01_FILE_NAME_P = $"{SAIDA01_FILE_NAME_P}_{timestamp}.txt";
            SAIDA02_FILE_NAME_P = $"{SAIDA02_FILE_NAME_P}_{timestamp}.txt";
            SAIDA03_FILE_NAME_P = $"{SAIDA03_FILE_NAME_P}_{timestamp}.txt";
            SAIDA04_FILE_NAME_P = $"{SAIDA04_FILE_NAME_P}_{timestamp}.txt";
            SAIDA05_FILE_NAME_P = $"{SAIDA05_FILE_NAME_P}_{timestamp}.txt";
            SAIDA06_FILE_NAME_P = $"{SAIDA06_FILE_NAME_P}_{timestamp}.txt";
            SAIDA07_FILE_NAME_P = $"{SAIDA07_FILE_NAME_P}_{timestamp}.txt";
            SAIDA08_FILE_NAME_P = $"{SAIDA08_FILE_NAME_P}_{timestamp}.txt";
            SAIDA09_FILE_NAME_P = $"{SAIDA09_FILE_NAME_P}_{timestamp}.txt";
            SAIDA10_FILE_NAME_P = $"{SAIDA10_FILE_NAME_P}_{timestamp}.txt";
            SAIDA11_FILE_NAME_P = $"{SAIDA11_FILE_NAME_P}_{timestamp}.txt";
            SAIDA12_FILE_NAME_P = $"{SAIDA12_FILE_NAME_P}_{timestamp}.txt";
            SAIDA13_FILE_NAME_P = $"{SAIDA13_FILE_NAME_P}_{timestamp}.txt";
            SAIDA14_FILE_NAME_P = $"{SAIDA14_FILE_NAME_P}_{timestamp}.txt";
            SAIDA15_FILE_NAME_P = $"{SAIDA15_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new EM8008B();
                program.Execute(ARQSORT_FILE_NAME_P, ENTRADA_FILE_NAME_P, SAIDA01_FILE_NAME_P, SAIDA02_FILE_NAME_P, SAIDA03_FILE_NAME_P, SAIDA04_FILE_NAME_P, SAIDA05_FILE_NAME_P, SAIDA06_FILE_NAME_P, SAIDA07_FILE_NAME_P, SAIDA08_FILE_NAME_P, SAIDA09_FILE_NAME_P, SAIDA10_FILE_NAME_P, SAIDA11_FILE_NAME_P, SAIDA12_FILE_NAME_P, SAIDA13_FILE_NAME_P, SAIDA14_FILE_NAME_P, SAIDA15_FILE_NAME_P);
                
                var envList = AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1"].DynamicList;

                Assert.Empty(envList);
                Assert.Empty(envList1);
                Assert.Empty(envList2);
                Assert.Empty(envList3);

            }
        }
    }
}