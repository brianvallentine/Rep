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
using static Code.FC0105B;

namespace FileTests.Test
{
    [Collection("FC0105B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class FC0105B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region FC0105B_C01_CURSOR1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "FC239_NUM_PLANO" , "790324"},
                { "FC239_IDE_CLIENTE" , "2608"},
                { "FC239_COD_RAMO" , "01"},
                { "FC239_NUM_MOD_PLANO" , "10"},
                { "FC239_QTD_DIAS_CANCELA" , "5"},
            });
            AppSettings.TestSet.DynamicData.Add("FC0105B_C01_CURSOR1", q0);

            #endregion

            #region FC0105B_C02_CURSOR2

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FCPROPOS_NUM_PROPOSTA" , "123456"},
                { "FCPROPOS_NUM_NSA" , "11"},
                { "FCTITULO_NUM_PLANO" , "12"},
                { "FCTITULO_NUM_SERIE" , "22"},
                { "FCTITULO_NUM_TITULO" , "776655"},
                { "FCTITULO_IDE_TITULAR" , "3"},
                { "FCTITULO_VLR_MENSALIDADE" , "100"},
            });
            AppSettings.TestSet.DynamicData.Add("FC0105B_C02_CURSOR2", q1);

            #endregion

            #region P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FCTITULO_NUM_TITULO" , ""},
                { "FCTITULO_NUM_PLANO" , ""},
                { "FCTITULO_NUM_SERIE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1", q2);

            #endregion

            #region P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "FCHISTIT_IDE_HIST_TITULO" , ""},
                { "FCHISTIT_COD_OPERACAO" , ""},
                { "FCHISTIT_IDE_USUARIO" , ""},
                { "FCHISTIT_NUM_PLANO" , ""},
                { "FCHISTIT_NUM_SERIE" , ""},
                { "FCHISTIT_NUM_TITULO" , ""},
                { "FCHISTIT_DES_MSG_ORIGEM" , ""},
                { "FCHISTIT_DES_MSG_DESTINO" , ""},
                { "FCHISTIT_IDE_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1", q3);

            #endregion

            #region P080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FCTITULO_NUM_TITULO" , ""},
                { "FCTITULO_NUM_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1", q4);

            #endregion

            #region P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "FCPROPOS_NUM_PROPOSTA" , ""},
                { "FC239_NUM_MOD_PLANO" , ""},
                { "FCTITULO_NUM_PLANO" , ""},
                { "FCPROPOS_NUM_NSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1", q5);

            #endregion

            #region P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "FCHISPRO_NUM_PLANO" , ""},
                { "FCHISPRO_NUM_PROPOSTA" , ""},
                { "FCHISPRO_NUM_NSA" , ""},
                { "FCHISPRO_IDE_USUARIO" , ""},
                { "FCHISPRO_COD_OPERACAO" , ""},
                { "FCHISPRO_DES_MSG_ORIGEM" , ""},
                { "FCHISPRO_DES_MSG_DESTINO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1", q6);

            #endregion

            #endregion
        }

        [Fact]
        public static void FC0105B_Tests_Fact_ReturnCode_0()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var param = new FC0105B_LK_PARAMETRO();
                param.LK_OPERACAO.Value = "COMMIT";
                param.LK_TRACE.Value = "TRACEON";


                #region FC0105B_C01_CURSOR1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("FC0105B_C01_CURSOR1");
                AppSettings.TestSet.DynamicData.Add("FC0105B_C01_CURSOR1", q0);

                #endregion
                #endregion
                var program = new FC0105B();
                program.Execute(param);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Fact]
        public static void FC0105B_Tests_Fact_ReturnCode_99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var param = new FC0105B_LK_PARAMETRO();
                //param.LK_OPERACAO.Value = "COMMIT";
                //param.LK_TRACE.Value = "TRACEON";
                #endregion
                var program = new FC0105B();
                program.Execute(param);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void FC0105B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var param = new FC0105B_LK_PARAMETRO();
                param.LK_OPERACAO.Value = "COMMIT";
                param.LK_TRACE.Value = "TRACEON";

                #endregion
                var program = new FC0105B();
                program.Execute(param);

                Assert.True(program.RETURN_CODE == 00);

                //P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("FCTITULO_NUM_TITULO", out var val0r) && val0r.Contains("000776655"));

                //P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("FCHISTIT_NUM_SERIE", out var val1r) && val1r.Contains("0022"));
                Assert.True(envList1.Count > 1);

                //P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("FCPROPOS_NUM_NSA", out var val2r) && val2r.Contains("000000011"));

                //P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("FCHISPRO_NUM_PROPOSTA", out var val3r) && val3r.Contains("000000000123456"));
                Assert.True(envList3.Count > 1);

            }
        }
    }
}