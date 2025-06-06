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
using static Code.VA2722B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA2722B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA2722B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VA2722B_RELAT

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA2722B_RELAT", q0);

            #endregion

            #region R0012_00_VER_PRODUVG_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_ORIG_PRODU" , "ESPEC"}
            });
            AppSettings.TestSet.DynamicData.Add("R0012_00_VER_PRODUVG_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1", q2);

            #endregion

            #region R0015_00_UPDATE_COD_RELAT_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_PROCESSAMENTO" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0015_00_UPDATE_COD_RELAT_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO_30" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1000_00_PROCESSA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "1"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_CERTIFICADO" , "1"},
                { "PROPOVA_COD_CLIENTE" , "1"},
                { "PROPOVA_OCOREND" , "1"},
                { "PROPOVA_AGE_COBRANCA" , "1"},
                { "PROPOVA_DATA_MOVIMENTO" , "1"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1400_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA2722B_OUTPUT-20250225162900")]
        public static void VA2722B_Tests_Theory_ReturnCode_00(string AVA2722B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA2722B_FILE_NAME_P = $"{AVA2722B_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA2722B();
                program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Value = "ESPEC";

                program.Execute(AVA2722B_FILE_NAME_P);

                Assert.True(File.Exists(program.AVA2722B.FilePath));

                Assert.Empty(AppSettings.TestSet.DynamicData["R0012_00_VER_PRODUVG_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(AppSettings.TestSet.DynamicData["R0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1"].DynamicList.Count > 1);
                Assert.True(AppSettings.TestSet.DynamicData["R0015_00_UPDATE_COD_RELAT_DB_UPDATE_1_Update1"].DynamicList.Count > 0);

                Assert.Empty(AppSettings.TestSet.DynamicData["R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1400_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("VA2722B_OUTPUT-20250225165000")]
        public static void VA2722B_Tests_Theory_ReturnCode_99(string AVA2722B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA2722B_FILE_NAME_P = $"{AVA2722B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "PRODUVG_ORIG_PRODU" , ""}
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("R0012_00_VER_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0012_00_VER_PRODUVG_DB_SELECT_1_Query1", q1);
                #endregion
                var program = new VA2722B();

                program.Execute(AVA2722B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}