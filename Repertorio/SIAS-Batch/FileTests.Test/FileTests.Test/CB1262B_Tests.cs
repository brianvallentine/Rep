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
using static Code.CB1262B;

namespace FileTests.Test
{
    [Collection("CB1262B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB1262B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WS_HOST_CURRENT_DATE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region CB1262B_C0PARCEHIS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "CBAPOVIG_NUM_APOLICE" , ""},
                { "CBAPOVIG_NUM_ENDOSSO" , ""},
                { "CBAPOVIG_NUM_PARCELA" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1262B_C0PARCEHIS", q1);

            #endregion

            #region CB1262B_C1PARCEHIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "CBMALPAR_DATA_MOVIMENTO" , ""},
                { "CBMALPAR_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1262B_C1PARCEHIS", q2);

            #endregion

            #region R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_SITUACAO" , ""},
                { "PARCEHIS_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1", q3);

            #endregion

            #region CB1262B_C0MOVDEBCE

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1262B_C0MOVDEBCE", q4);

            #endregion

            #region R1650_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CBMALPAR_SITUACAO" , ""},
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CBMALPAR_SITUACAO" , ""},
                { "CBMALPAR_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R2400_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void CB1262B_Tests_Fact()
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

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "WS_HOST_CURRENT_DATE" , "2025-02-21"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region CB1262B_C0PARCEHIS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "0107100070673"},
                { "PARCEHIS_NUM_ENDOSSO" , "23"},
                { "PARCEHIS_NUM_PARCELA" , "1"},
                { "PARCEHIS_OCORR_HISTORICO" , "1"},
                { "PARCEHIS_COD_OPERACAO" , "0200"},//AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER
                { "CBAPOVIG_NUM_APOLICE" , "0107100070673"},
                { "CBAPOVIG_NUM_ENDOSSO" , "1"},
                { "CBAPOVIG_NUM_PARCELA" , "1"},
                { "APOLICES_ORGAO_EMISSOR" , "1"},
                });

                AppSettings.TestSet.DynamicData.Remove("CB1262B_C0PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("CB1262B_C0PARCEHIS", q1);

                #endregion

                #region CB1262B_C1PARCEHIS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "0107100070673"},
                { "PARCEHIS_NUM_ENDOSSO" , "1"},
                { "PARCEHIS_NUM_PARCELA" , "1"},
                { "PARCEHIS_OCORR_HISTORICO" , "1"},
                { "PARCEHIS_COD_OPERACAO" , "0200"},//AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER
                { "CBMALPAR_DATA_MOVIMENTO" , "2025-01-01"},
                { "CBMALPAR_NUM_TITULO" , "0"},//CBMALPAR_NUM_TITULO
                });

                AppSettings.TestSet.DynamicData.Remove("CB1262B_C1PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("CB1262B_C1PARCEHIS", q2);

                #endregion

                #region CB1262B_C0MOVDEBCE

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "0107100070673"},
                { "MOVDEBCE_NUM_ENDOSSO" , "1"},
                { "MOVDEBCE_NUM_PARCELA" , "1"},
                { "MOVDEBCE_COD_CONVENIO" , "1"},
                { "MOVDEBCE_NSAS" , "1"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2025-03-01"},
            });
                q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "0107100070673"},
                { "MOVDEBCE_NUM_ENDOSSO" , "1"},
                { "MOVDEBCE_NUM_PARCELA" , "1"},
                { "MOVDEBCE_COD_CONVENIO" , "1"},
                { "MOVDEBCE_NSAS" , "1"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2025-01-01"},//MOVDEBCE_DATA_VENCIMENTO
            });
                AppSettings.TestSet.DynamicData.Remove("CB1262B_C0MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("CB1262B_C0MOVDEBCE", q4);

                #endregion


                #endregion
                var program = new CB1262B();

                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                //AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER == 02
                var envList = AppSettings.TestSet.DynamicData["R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("CBAPOVIG_SITUACAO", out var CBAPOVIG_SITUACAO) && CBAPOVIG_SITUACAO == "4");
                Assert.True(envList[1].TryGetValue("PARCEHIS_NUM_APOLICE", out var PARCEHIS_NUM_APOLICE) && PARCEHIS_NUM_APOLICE == "0107100070673");

                //AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER == 02
                var envList1 = AppSettings.TestSet.DynamicData["R1650_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("CBMALPAR_SITUACAO", out var CBMALPAR_SITUACAO) && CBMALPAR_SITUACAO == "2");
                Assert.True(envList1[1].TryGetValue("PARCEHIS_NUM_APOLICE", out var PARCEHIS_NUM_APOLICE1) && PARCEHIS_NUM_APOLICE1 == "0107100070673");


                //AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER.In("03", "05") and CBMALPAR_NUM_TITULO == 0
                /* var envList2 = AppSettings.TestSet.DynamicData["R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1"].DynamicList;
                 Assert.True(envList2?.Count > 1);
                 Assert.True(envList2[1].TryGetValue("CBMALPAR_SITUACAO", out var CBMALPAR_SITUACAO1) && CBMALPAR_SITUACAO1 == "0");
                 Assert.True(envList2[1].TryGetValue("CBMALPAR_DATA_MOVIMENTO", out var CBMALPAR_DATA_MOVIMENTO) && CBMALPAR_DATA_MOVIMENTO == "2025-01-01");
                 Assert.True(envList2[1].TryGetValue("PARCEHIS_NUM_APOLICE", out var PARCEHIS_NUM_APOLICE2) && PARCEHIS_NUM_APOLICE2 == "0107100070673");
                 Assert.True(envList2[1].TryGetValue("PARCEHIS_NUM_ENDOSSO", out var PARCEHIS_NUM_ENDOSSO1) && PARCEHIS_NUM_ENDOSSO1 == "000000001");
                 Assert.True(envList2[1].TryGetValue("PARCEHIS_NUM_PARCELA", out var PARCEHIS_NUM_PARCELA1) && PARCEHIS_NUM_PARCELA1 == "0001");*/

                //AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER == 02 e MOVDEBCE_DATA_VENCIMENTO <= WS_HOST_CURRENT_DATE
                var envList3 = AppSettings.TestSet.DynamicData["R2300_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO) && SISTEMAS_DATA_MOV_ABERTO == "2025-01-27");
                Assert.True(envList3[1].TryGetValue("MOVDEBCE_COD_CONVENIO", out var MOVDEBCE_COD_CONVENIO) && MOVDEBCE_COD_CONVENIO == "000000001");
                Assert.True(envList3[1].TryGetValue("MOVDEBCE_NUM_APOLICE", out var MOVDEBCE_NUM_APOLICE) && MOVDEBCE_NUM_APOLICE == "0107100070673");
                Assert.True(envList3[1].TryGetValue("MOVDEBCE_NUM_ENDOSSO", out var MOVDEBCE_NUM_ENDOSSO) && MOVDEBCE_NUM_ENDOSSO == "000000001");
                Assert.True(envList3[1].TryGetValue("MOVDEBCE_NUM_PARCELA", out var MOVDEBCE_NUM_PARCELA) && MOVDEBCE_NUM_PARCELA == "0001");
                Assert.True(envList3[1].TryGetValue("MOVDEBCE_NSAS", out var MOVDEBCE_NSAS) && MOVDEBCE_NSAS == "0001");

                //AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER == 02
                var envList4 = AppSettings.TestSet.DynamicData["R2400_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4?.Count > 1);
                Assert.True(envList4[1].TryGetValue("MOVDEBCE_NUM_APOLICE", out var MOVDEBCE_NUM_APOLICE1) && MOVDEBCE_NUM_APOLICE1 == "0107100070673");
                Assert.True(envList4[1].TryGetValue("MOVDEBCE_NUM_ENDOSSO", out var MOVDEBCE_NUM_ENDOSSO1) && MOVDEBCE_NUM_ENDOSSO1 == "000000001");
                Assert.True(envList4[1].TryGetValue("MOVDEBCE_NUM_PARCELA", out var MOVDEBCE_NUM_PARCELA1) && MOVDEBCE_NUM_PARCELA1 == "0001");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void CB1262B_Tests99_Fact()
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

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WS_HOST_CURRENT_DATE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region CB1262B_C0PARCEHIS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                //{ "PARCEHIS_NUM_APOLICE" , "0107100070673"},
                { "PARCEHIS_NUM_ENDOSSO" , "23"},
                { "PARCEHIS_NUM_PARCELA" , "1"},
                { "PARCEHIS_OCORR_HISTORICO" , "1"},
                { "PARCEHIS_COD_OPERACAO" , "0200"},//AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER
                { "CBAPOVIG_NUM_APOLICE" , "0107100070673"},
                //{ "CBAPOVIG_NUM_ENDOSSO" , "1"},
                { "CBAPOVIG_NUM_PARCELA" , "1"},
               // { "APOLICES_ORGAO_EMISSOR" , "1"},
                });

                AppSettings.TestSet.DynamicData.Remove("CB1262B_C0PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("CB1262B_C0PARCEHIS", q1);

                #endregion

                #region CB1262B_C1PARCEHIS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                //{ "PARCEHIS_NUM_APOLICE" , "0107100070673"},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_COD_OPERACAO" , "0200"},//AREA_DE_WORK.FILLER_0.WS_FAIXA_OPER
               // { "CBMALPAR_DATA_MOVIMENTO" , "2025-01-01"},
                { "CBMALPAR_NUM_TITULO" , ""},//CBMALPAR_NUM_TITULO
                });

                AppSettings.TestSet.DynamicData.Remove("CB1262B_C1PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("CB1262B_C1PARCEHIS", q2);

                #endregion

                #region CB1262B_C0MOVDEBCE

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "0107100070673"},
                { "MOVDEBCE_NUM_ENDOSSO" , "1"},
                { "MOVDEBCE_NUM_PARCELA" , "1"},
                { "MOVDEBCE_COD_CONVENIO" , "1"},
                { "MOVDEBCE_NSAS" , "1"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2025-03-01"},
            });

                AppSettings.TestSet.DynamicData.Remove("CB1262B_C0MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("CB1262B_C0MOVDEBCE", q4);

                #endregion


                #endregion
                var program = new CB1262B();

                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                var envList = AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}