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
using static Code.BI0033B;

namespace FileTests.Test
{

    [Collection("BI0033B_Tests")]

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0033B_Tests
    {

        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_DTMOVABE" , ""},
                { "V1SISTE_DTCURRENT" , ""},
                { "V1SISTE_DTMOVABE_10" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q1);

            #endregion

            #region BI0033B_V0PARAMC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_TIPO_MOVTOCC" , ""},
                { "V0PARAMC_CODPRODU" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_COD_AGENCIA_SASS" , ""},
                { "V0PARAMC_DTPROX_DEB" , ""},
                { "V0PARAMC_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0033B_V0PARAMC", q2);

            #endregion

            #region BI0033B_V0MOVDE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_COD_AGENCIA_DEB" , ""},
                { "V0MOVDE_OPER_CONTA_DEB" , ""},
                { "V0MOVDE_NUM_CONTA_DEB" , ""},
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_VLR_DEBITO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_DIA_DEBITO" , ""},
                { "V0MOVDE_DAYS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0033B_V0MOVDE", q3);

            #endregion

            #region R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , ""},
                { "V1BILH_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1CLIEN_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_DTPROX_DEB" , ""},
                { "V1SISTE_DTCURRENT" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_TIPO_MOVTOCC" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_DTCURRENT" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0MOVDE_SIT_COBRANCA" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVDEBITO_CC_FILE_NAME_P", "RBI0033B_FILE_NAME_P")]
        public static void BI0033B_Tests_Theory(string MOVDEBITO_CC_FILE_NAME_P, string RBI0033B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVDEBITO_CC_FILE_NAME_P = $"{MOVDEBITO_CC_FILE_NAME_P}_{timestamp}.txt";
            RBI0033B_FILE_NAME_P = $"{RBI0033B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                PROSOCU1_Tests.Load_Parameters();
                PROALN01_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_DTMOVABE" , "2000-10-10"},
                { "V1SISTE_DTCURRENT" , "2000-10-10"},
                { "V1SISTE_DTMOVABE_10" , "2000-10-10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "TESTE"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion

                #region BI0033B_V0PARAMC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_TIPO_MOVTOCC" , "1"},
                { "V0PARAMC_CODPRODU" , "1"},
                { "V0PARAMC_COD_CONVENIO" , "1"},
                { "V0PARAMC_NSAS" , "1"},
                { "V0PARAMC_COD_AGENCIA_SASS" , "1"},
                { "V0PARAMC_DTPROX_DEB" , "2000-10-10"},
                { "V0PARAMC_DIA_DEBITO" , "10"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI0033B_V0PARAMC");
                AppSettings.TestSet.DynamicData.Add("BI0033B_V0PARAMC", q2);

                #endregion

                #region BI0033B_V0MOVDE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_COD_CONVENIO" , "1"},
                { "V0MOVDE_COD_AGENCIA_DEB" , "2"},
                { "V0MOVDE_OPER_CONTA_DEB" , "1"},
                { "V0MOVDE_NUM_CONTA_DEB" , "2"},
                { "V0MOVDE_DIG_CONTA_DEB" , "2"},
                { "V0MOVDE_DTVENCTO" , "2000-10-10"},
                { "V0MOVDE_VLR_DEBITO" , "120"},
                { "V0MOVDE_NUM_APOLICE" , "103100012237"},
                { "V0MOVDE_DIA_DEBITO" , "10"},
                { "V0MOVDE_DAYS" , "10"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI0033B_V0MOVDE");
                AppSettings.TestSet.DynamicData.Add("BI0033B_V0MOVDE", q3);

                #endregion

                #region R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , "19"},
                { "V1BILH_COD_CLIENTE" , "145257"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "1"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "2"},
                { "MOVDEBCE_OPER_CONTA_DEB" , "3"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "4"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "5"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2000-10-10"},
                { "MOVDEBCE_VALOR_DEBITO" , "120"},
                { "MOVDEBCE_NSAS" , "1"},
                { "MOVDEBCE_SEQUENCIA" , "0"},
                { "MOVDEBCE_NUM_REQUISICAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1CLIEN_NOME_RAZAO" , "X"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1", q6);

                #endregion
                              
                #endregion
                var program = new BI0033B();
                program.Execute(MOVDEBITO_CC_FILE_NAME_P, RBI0033B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);
                
                var envList = AppSettings.TestSet.DynamicData["R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0PARAMC_DTPROX_DEB", out var V0PARAMC_DTPROX_DEB) && V0PARAMC_DTPROX_DEB == "2000-01-01");
                Assert.True(envList[1].TryGetValue("V1SISTE_DTCURRENT", out var V1SISTE_DTCURRENT) && V1SISTE_DTCURRENT == "2000-10-10");
                Assert.True(envList[1].TryGetValue("V0PARAMC_NSAS", out var V0PARAMC_NSAS) && V0PARAMC_NSAS == "0002");
                Assert.True(envList[1].TryGetValue("V0PARAMC_TIPO_MOVTOCC", out var V0PARAMC_TIPO_MOVTOCC) && V0PARAMC_TIPO_MOVTOCC == "0001");
                Assert.True(envList[1].TryGetValue("V0PARAMC_COD_CONVENIO", out var V0PARAMC_COD_CONVENIO) && V0PARAMC_COD_CONVENIO == "000000001");
                Assert.True(envList[1].TryGetValue("V0PARAMC_SITUACAO", out var V0PARAMC_SITUACAO) && V0PARAMC_SITUACAO == "A");
                //****************************************************************************************************************
                       
                var envList1 = AppSettings.TestSet.DynamicData["R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("V1SISTE_DTCURRENT", out var V0BILH_SITUACAO) && V0BILH_SITUACAO == "2000-10-10");
                Assert.True(envList1[1].TryGetValue("V0PARAMC_NSAS", out var V0PARAMC_NSAS1) && V0PARAMC_NSAS1 == "0002");
                Assert.True(envList1[1].TryGetValue("V0MOVDE_SIT_COBRANCA", out var V0MOVDE_SIT_COBRANCA) && V0MOVDE_SIT_COBRANCA == "D");
                Assert.True(envList1[1].TryGetValue("V0MOVDE_NUM_APOLICE", out var V0MOVDE_NUM_APOLICE) && V0MOVDE_NUM_APOLICE == "0103100012237");
                Assert.True(envList1[1].TryGetValue("V0MOVDE_DTVENCTO", out var V0MOVDE_DTVENCTO) && V0MOVDE_DTVENCTO == "2000-10-10");
                //***********************************************************************************

                var envList2 = AppSettings.TestSet.DynamicData["R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("V0BILH_SITUACAO", out var V0BILH_SITUACAO1) && V0BILH_SITUACAO1 == "6");
                Assert.True(envList2[1].TryGetValue("V0BILH_NUMBIL", out var V0BILH_NUMBIL) && V0BILH_NUMBIL == "000103100012237");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("MOVDEBITO_CC_FILE_NAME_P", "RBI0033B_FILE_NAME_P")]
        public static void BI0033B_Tests99_Theory(string MOVDEBITO_CC_FILE_NAME_P, string RBI0033B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVDEBITO_CC_FILE_NAME_P = $"{MOVDEBITO_CC_FILE_NAME_P}_{timestamp}.txt";
            RBI0033B_FILE_NAME_P = $"{RBI0033B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_DTMOVABE" , ""},
                { "V1SISTE_DTCURRENT" , ""},
                { "V1SISTE_DTMOVABE_10" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "TESTE"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion

                #region BI0033B_V0PARAMC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_TIPO_MOVTOCC" , ""},
                { "V0PARAMC_CODPRODU" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_COD_AGENCIA_SASS" , ""},
                { "V0PARAMC_DTPROX_DEB" , "2000-10-10"},
                { "V0PARAMC_DIA_DEBITO" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI0033B_V0PARAMC");
                AppSettings.TestSet.DynamicData.Add("BI0033B_V0PARAMC", q2);

                #endregion

                #region BI0033B_V0MOVDE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_COD_AGENCIA_DEB" , ""},
                { "V0MOVDE_OPER_CONTA_DEB" , ""},
                { "V0MOVDE_NUM_CONTA_DEB" , ""},
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_VLR_DEBITO" , ""},
                { "V0MOVDE_NUM_APOLICE" , "103100012237"},
                { "V0MOVDE_DIA_DEBITO" , ""},
                { "V0MOVDE_DAYS" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("BI0033B_V0MOVDE");
                AppSettings.TestSet.DynamicData.Add("BI0033B_V0MOVDE", q3);

                #endregion

                #region R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , "19"},
                { "V1BILH_COD_CLIENTE" , "145257"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
              //  { "MOVDEBCE_NUM_APOLICE" , "103100012237"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1CLIEN_NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1", q6);

                #endregion


                #endregion
                var program = new BI0033B();
                program.Execute(MOVDEBITO_CC_FILE_NAME_P, RBI0033B_FILE_NAME_P);
               
                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}