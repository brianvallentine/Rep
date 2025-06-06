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
using static Code.VG0282B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VG0282B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0282B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2024-11-11"},
                { "V1SIST_DTCURRENT" , "2024-11-11"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0282B_V1RELATORIOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_NUM_APOL" , "19790324"},
                { "V1RELA_CODSUBES" , "1"},
                { "V1RELA_CODUNIMO" , "2"},
                { "V1RELA_PERI_INI" , "2024-10-10"},
                { "V1RELA_PERI_FIN" , "2024-09-10"},
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_NUM_APOL" , "19790324"},
                { "V1RELA_CODSUBES" , "1"},
                { "V1RELA_CODUNIMO" , "2"},
                { "V1RELA_PERI_INI" , "2024-10-10"},
                { "V1RELA_PERI_FIN" , "2024-09-10"},
            });
            AppSettings.TestSet.DynamicData.Add("VG0282B_V1RELATORIOS", q1);

            #endregion

            #region VG0282B_V1ENDOSSO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUM_APOL" , "19790312"},
                { "V1ENDO_NRENDOS" , "1"},
                { "V1ENDO_CODSUBES" , "3"},
                { "V1ENDO_DTINIVIG" , "2024-10-10"},
                { "V1ENDO_DTTERVIG" , "2024-12-10"},
                { "V1ENDO_SITUACAO" , "2"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUM_APOL" , "19790312"},
                { "V1ENDO_NRENDOS" , "1"},
                { "V1ENDO_CODSUBES" , "3"},
                { "V1ENDO_DTINIVIG" , "2024-10-10"},
                { "V1ENDO_DTTERVIG" , "2024-12-10"},
                { "V1ENDO_SITUACAO" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("VG0282B_V1ENDOSSO", q2);

            #endregion

            #region R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA SEGURADORA VIDA"}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0MOED_SIGLUNIM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1", q5);

            #endregion

            #region VG0282B_V1HISTOPARC

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_OPERACAO" , ""},
                { "V1HISP_DTMOVTO" , ""},
                { "V1HISP_VLPRMLIQ" , ""},
                { "V1HISP_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0282B_V1HISTOPARC", q6);

            #endregion

            #region R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1SUBG_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2300_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2400_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q10);

            #endregion

            #region VG0282B_V1COMISSAO

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1COMI_NRENDOS" , ""},
                { "V1COMI_OPERACAO" , ""},
                { "V1COMI_DTMOVTO" , ""},
                { "V1COMI_VLCOMIS" , ""},
                { "V1COMI_DATCLO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0282B_V1COMISSAO", q11);

            #endregion

            #endregion
        }
        [Theory]
        [InlineData("RVG0282B_FILE_NAME_P_00")]
        public static void VG0282B_Tests_Theory_ReturnCode_0(string RVG0282B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0282B_FILE_NAME_P = $"{RVG0282B_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new VG0282B();
                program.Execute(RVG0282B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                Assert.True(File.Exists(program.RVG0282B.FilePath));
                Assert.True(new FileInfo(program.RVG0282B.FilePath)?.Length > 0);
                Assert.True(program.RETURN_CODE == 0);

                var envList = AppSettings.TestSet.DynamicData["R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("UpdateCheck", out var val0r) && val0r.Contains("UpdateCheck"));
                Assert.True(program.LK_LINK.LK_TITULO == "CAIXA SEGURADORA VIDA");

            }
        }
        [Theory]
        [InlineData("RVG0282B_FILE_NAME_P_01")]
        public static void VG0282B_Tests_Theory_SemSolicitacao_ReturnCode_0(string RVG0282B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0282B_FILE_NAME_P = $"{RVG0282B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                var program = new VG0282B();
                program.Execute(RVG0282B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                Assert.True(File.Exists(program.RVG0282B.FilePath));
                Assert.True(new FileInfo(program.RVG0282B.FilePath)?.Length >= 0);
                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Theory]
        [InlineData("RVG0282B_FILE_NAME_P_02")]
        public static void VG0282B_Tests_Theory_ReturnCode_9(string RVG0282B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0282B_FILE_NAME_P = $"{RVG0282B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VG0282B_V1RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_NUM_APOL" , "19790324"},
                { "V1RELA_CODSUBES" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0282B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("VG0282B_V1RELATORIOS", q1);

                #endregion
                #endregion
                var program = new VG0282B();
                program.Execute(RVG0282B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                Assert.True(!File.Exists(program.RVG0282B.FilePath));

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}