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
using static Code.SPBVG013;

namespace FileTests.Test
{
    [Collection("SPBVG013_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SPBVG013_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region P0050_05_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region P0200_05_INICIO_DB_INSERT_1_Insert1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "VG135_IDE_SISTEMA" , ""},
                { "VG135_NUM_CERTIFICADO" , ""},
                { "VG135_COD_PRODUTO" , ""},
                { "VG135_COD_PLANO" , ""},
                { "VG135_DTA_MOVIMENTO" , ""},
                { "VG135_STA_ACOPLADO" , ""},
                { "VG135_COD_EMPRESA_CAP" , ""},
                { "VG135_QTD_TITULO" , ""},
                { "VG135_VLR_TITULO" , ""},
                { "VG135_COD_USUARIO" , ""},
                { "VG135_NOM_PROGRAMA" , ""},
                { "VG135_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0200_05_INICIO_DB_INSERT_1_Insert1", q1);

            #endregion

            #region P0210_05_INICIO_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "VG135_DTH_CADASTRAMENTO" , ""},
                { "VG135_DTA_MOVIMENTO" , ""},
                { "VG135_STA_ACOPLADO" , ""},
                { "VG135_NOM_PROGRAMA" , ""},
                { "VG135_COD_USUARIO" , ""},
                { "VG135_VLR_TITULO" , ""},
                { "VG135_NUM_CERTIFICADO" , ""},
                { "VG135_IDE_SISTEMA" , ""},
                { "VG135_COD_PRODUTO" , ""},
                { "VG135_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0210_05_INICIO_DB_UPDATE_1_Update1", q2);

            #endregion

            #region P0250_05_INICIO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "VG135_STA_ACOPLADO" , ""},
                { "VG135_COD_EMPRESA_CAP" , ""},
                { "VG135_QTD_TITULO" , ""},
                { "VG135_VLR_TITULO" , ""},
                { "VG135_COD_USUARIO" , ""},
                { "VG135_SEQ_REMESSA" , ""},
                { "VG135_SEQ_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0250_05_INICIO_DB_SELECT_1_Query1", q3);

            #endregion

            #region P0300_05_INICIO_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "VG137_IDE_SISTEMA" , ""},
                { "VG137_NUM_CERTIFICADO" , ""},
                { "VG137_COD_PRODUTO" , ""},
                { "VG137_COD_PLANO" , ""},
                { "VG137_DTH_CADASTRAMENTO" , ""},
                { "VG137_DTA_MOVIMENTO" , ""},
                { "VG137_STA_ACOPLADO" , ""},
                { "VG137_COD_EMPRESA_CAP" , ""},
                { "VG137_QTD_TITULO" , ""},
                { "VG137_VLR_TITULO" , ""},
                { "VG137_COD_USUARIO" , ""},
                { "VG137_NOM_PROGRAMA" , ""},
                { "VG137_SEQ_REMESSA" , ""},
                { "VG137_SEQ_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0300_05_INICIO_DB_INSERT_1_Insert1", q4);

            #endregion

            #region P0400_05_INICIO_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VG139_IDE_SISTEMA" , ""},
                { "VG139_NUM_CERTIFICADO" , ""},
                { "VG139_COD_PRODUTO" , ""},
                { "VG139_COD_PLANO" , ""},
                { "VG139_SEQ_ERRO" , ""},
                { "VG139_COD_SQLCODE" , ""},
                { "VG139_COD_ERRO" , ""},
                { "VG139_DES_ERRO" , ""},
                { "VG139_DES_ACAO" , ""},
                { "VG139_COD_USUARIO" , ""},
                { "VG139_NOM_PROGRAMA" , ""},
                { "VG139_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0400_05_INICIO_DB_INSERT_1_Insert1", q5);

            #endregion

            #region P0460_05_INICIO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VG139_SEQ_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0460_05_INICIO_DB_SELECT_1_Query1", q6);

            #endregion

            #region P0540_05_INICIO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0540_05_INICIO_DB_SELECT_1_Query1", q7);

            #endregion

            #region P0851_01_INICIO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_CURRENT_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0851_01_INICIO_DB_SELECT_1_Query1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void SPBVG013_Tests_Fact_TipoAcao_2_Sucesso()
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
                var param = new SPVG013W();
                param.LK_VG013_TRACE.Value = "S";
                param.LK_VG013_TIPO_ACAO.Value = 2;
                param.LK_VG013_SISTEMA_CHAMADOR.Value = "VG";
                //LK_VG013_CANAL
                //LK_VG013_ORIGEM
                //LK_VG013_COD_USUARIO
                param.LK_VG013_IDE_SISTEMA.Value = "VG";
                param.LK_VG013_NUM_CERTIFICADO.Value = 1234;
                param.LK_VG013_COD_PRODUTO.Value = 100;
                param.LK_VG013_COD_PLANO.Value = 100;

                //LK_VG013_QTD_TITULO
                param.LK_VG013_VLR_TITULO.Value = 1500;
                //LK_VG013_COD_EMPRESA_CAP
                //LK_VG013_COD_RETORNO_API
                //LK_VG013_DES_ERRO
                //LK_VG013_DES_ACAO
                var paramOut = new LBHCT002();

                #region P0250_05_INICIO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "VG135_STA_ACOPLADO" , "007"},
                { "VG135_COD_EMPRESA_CAP" , "1"},
                { "VG135_QTD_TITULO" , "1"},
                { "VG135_VLR_TITULO" , "12"},
                { "VG135_COD_USUARIO" , "USU"},
                { "VG135_SEQ_REMESSA" , "1"},
                { "VG135_SEQ_REGISTRO" , "1"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "VG135_STA_ACOPLADO" , "008"},
                { "VG135_COD_EMPRESA_CAP" , "1"},
                { "VG135_QTD_TITULO" , "2"},
                { "VG135_VLR_TITULO" , "14"},
                { "VG135_COD_USUARIO" , "USU2"},
                { "VG135_SEQ_REMESSA" , "2"},
                { "VG135_SEQ_REGISTRO" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("P0250_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0250_05_INICIO_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new SPBVG013();
                program.Execute(param, paramOut);
                Assert.True(program.WORK.WS_ERRO.WS_IND_ERRO.Value == 0);

                //P0210_05_INICIO_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["P0210_05_INICIO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("VG135_NUM_CERTIFICADO", out var val0r) && val0r.Contains("000000000000001234"));

                //P0300_05_INICIO_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["P0300_05_INICIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("VG137_VLR_TITULO", out var val1r) && val1r.Contains("1500"));
                Assert.True(envList1.Count > 1);


            }
        }

        [Fact]
        public static void SPBVG013_Tests_Fact_TipoAcao_3_Sucesso()
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
                var param = new SPVG013W();
                param.LK_VG013_TRACE.Value = "S";
                param.LK_VG013_TIPO_ACAO.Value = 3;
                param.LK_VG013_SISTEMA_CHAMADOR.Value = "VG";
                //LK_VG013_CANAL
                //LK_VG013_ORIGEM
                //LK_VG013_COD_USUARIO
                param.LK_VG013_IDE_SISTEMA.Value = "VG";
                param.LK_VG013_NUM_CERTIFICADO.Value = 790324;
                param.LK_VG013_COD_PRODUTO.Value = 200;
                param.LK_VG013_COD_PLANO.Value = 200;

                //LK_VG013_QTD_TITULO
                param.LK_VG013_VLR_TITULO.Value = 2500;
                //LK_VG013_COD_EMPRESA_CAP
                param.LK_VG013_COD_RETORNO_API.Value = 100;
                //LK_VG013_DES_ERRO
                //LK_VG013_DES_ACAO
                var paramOut = new LBHCT002();

                #region P0250_05_INICIO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "VG135_STA_ACOPLADO" , "0"},
                { "VG135_COD_EMPRESA_CAP" , ""},
                { "VG135_QTD_TITULO" , ""},
                { "VG135_VLR_TITULO" , ""},
                { "VG135_COD_USUARIO" , ""},
                { "VG135_SEQ_REMESSA" , ""},
                { "VG135_SEQ_REGISTRO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "VG135_STA_ACOPLADO" , "0"},
                { "VG135_COD_EMPRESA_CAP" , ""},
                { "VG135_QTD_TITULO" , ""},
                { "VG135_VLR_TITULO" , ""},
                { "VG135_COD_USUARIO" , ""},
                { "VG135_SEQ_REMESSA" , ""},
                { "VG135_SEQ_REGISTRO" , ""},                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "VG135_STA_ACOPLADO" , "0"},
                { "VG135_COD_EMPRESA_CAP" , ""},
                { "VG135_QTD_TITULO" , ""},
                { "VG135_VLR_TITULO" , ""},
                { "VG135_COD_USUARIO" , ""},
                { "VG135_SEQ_REMESSA" , ""},
                { "VG135_SEQ_REGISTRO" , ""},                });
                AppSettings.TestSet.DynamicData.Remove("P0250_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0250_05_INICIO_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new SPBVG013();
                program.Execute(param, paramOut);
                Assert.True(program.WORK.WS_ERRO.WS_IND_ERRO.Value == 0);

                //P0210_05_INICIO_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["P0210_05_INICIO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("VG135_NUM_CERTIFICADO", out var val0r) && val0r.Contains("000000000000790324"));

                //P0300_05_INICIO_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["P0300_05_INICIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("VG137_COD_PLANO", out var val1r) && val1r.Contains("0200"));
                Assert.True(envList1.Count > 1);

                //P0400_05_INICIO_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["P0400_05_INICIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("VG139_NUM_CERTIFICADO", out var val2r) && val2r.Contains("000000000000790324"));
                Assert.True(envList2.Count > 1);


            }
        }

        [Fact]
        public static void SPBVG013_Tests_Fact_TipoAcao_3_Erro()
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
                var param = new SPVG013W();
                param.LK_VG013_TRACE.Value = "S";
                param.LK_VG013_TIPO_ACAO.Value = 3;
                param.LK_VG013_SISTEMA_CHAMADOR.Value = "VG";
                //LK_VG013_CANAL
                //LK_VG013_ORIGEM
                //LK_VG013_COD_USUARIO
                param.LK_VG013_IDE_SISTEMA.Value = "VG";
                param.LK_VG013_NUM_CERTIFICADO.Value = 0;
                param.LK_VG013_COD_PRODUTO.Value = 0;
                param.LK_VG013_COD_PLANO.Value = 0;

                //LK_VG013_QTD_TITULO
                param.LK_VG013_VLR_TITULO.Value = 0;
                //LK_VG013_COD_EMPRESA_CAP
                param.LK_VG013_COD_RETORNO_API.Value = 0;
                //LK_VG013_DES_ERRO
                //LK_VG013_DES_ACAO
                var paramOut = new LBHCT002();

                #endregion
                var program = new SPBVG013();
                program.Execute(param, paramOut);
                Assert.True(program.WORK.WS_ERRO.WS_IND_ERRO.Value == 1);
                Assert.True(param.LK_VG013_NUM_CERTIFICADO.Value == 0);
            }
        }

    }
}