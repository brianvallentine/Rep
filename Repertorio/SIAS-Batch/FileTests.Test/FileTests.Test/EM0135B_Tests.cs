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
using static Code.EM0135B;

namespace FileTests.Test
{
    [Collection("EM0135B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0135B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2020-05-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region EM0135B_C01_ENDOSSOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "1103100100698"},
                { "ENDOSSOS_NUM_ENDOSSO" , "1"},
                { "ENDOSSOS_TIPO_ENDOSSO" , "1"},
                { "ENDOSSOS_COD_FONTE" , "12"},
            });
            AppSettings.TestSet.DynamicData.Add("EM0135B_C01_ENDOSSOS", q1);

            #endregion

            #region R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_PRM_LIQUIDO_IX" , "12"},
                { "PARCELAS_PRM_TOTAL_IX" , "15"},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1220_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_PRM_TOTAL_IX" , "15"}
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1230_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_PRM_TOTAL_IX" , "12"}
            });
            AppSettings.TestSet.DynamicData.Add("R1230_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , ""},
                { "V0EDIA_NUM_APOL" , ""},
                { "V0EDIA_NRENDOS" , ""},
                { "V0EDIA_NRPARCEL" , ""},
                { "V0EDIA_DTMOVTO" , ""},
                { "V0EDIA_ORGAO" , ""},
                { "V0EDIA_RAMO" , ""},
                { "V0EDIA_FONTE" , ""},
                { "V0EDIA_CONGENER" , ""},
                { "V0EDIA_CODCORR" , ""},
                { "V0EDIA_SITUACAO" , ""},
                { "V0EDIA_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0135B_Tests_Fact()
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

                #region R1330_00_SELECT_MOVDEBCE_Query1

                var q7 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q7);

                #endregion
                #endregion
                var program = new EM0135B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                //R1310_00_INSERT_V0EMISDIA_Insert1
                var envList = AppSettings.TestSet.DynamicData["R1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("V0EDIA_CODRELAT", out var valOr) && valOr == "EM0202B1");
                Assert.True(envList[1].TryGetValue("V0EDIA_NUM_APOL", out var valSivpf) && valSivpf == "1103100100698");

                //R1320_00_UPDATE_PARCEHIS_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V1SIST_DTMOVABE", out var val2r) && val2r == "2020-05-01");
                Assert.True(envList1[1].TryGetValue("ENDOSSOS_NUM_APOLICE", out var val3r) && val3r == "1103100100698");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void EM0135B_Tests_FactErro99()
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

                #region R0100_00_SELECT_SISTEMAS_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new EM0135B();
                program.Execute();



                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}