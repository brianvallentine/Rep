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
using static Code.BI0031B;

namespace FileTests.Test
{
    [Collection("BI0031B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class BI0031B_Tests
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
                { "V1SISTE_DTMOVABE_30" , ""},
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

            #region BI0031B_V0PARAMC

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
            AppSettings.TestSet.DynamicData.Add("BI0031B_V0PARAMC", q2);

            #endregion

            #region BI0031B_V0MOVDE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRENDOS" , ""},
                { "V0MOVDE_NRPARCEL" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_DAYS" , ""},
                { "V0MOVDE_VLR_DEBITO" , ""},
                { "V0MOVDE_DIA_DEBITO" , ""},
                { "V0MOVDE_COD_AGENCIA_DEB" , ""},
                { "V0MOVDE_OPER_CONTA_DEB" , ""},
                { "V0MOVDE_NUM_CONTA_DEB" , ""},
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0031B_V0MOVDE", q3);

            #endregion

            #region BI0031B_CORIGEM

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI0031B_CORIGEM", q4);

            #endregion

            #region R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , ""},
                { "V1BILH_COD_CLIENTE" , ""},
                { "V1BILH_OPC_COBER" , ""},
                { "V1BILH_RAMO" , ""},
                { "V1BILH_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , ""},
                { "V1BILH_COD_CLIENTE" , ""},
                { "V1BILH_OPC_COBER" , ""},
                { "V1BILH_RAMO" , ""},
                { "V1BILH_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0117_UPDATE_V1BILHETE_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_DTVENCTO" , ""},
                { "V1BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0117_UPDATE_V1BILHETE_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRPARCEL" , ""},
                { "V0MOVDE_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0119_00_LE_PROPOFID_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0119_00_LE_PROPOFID_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0121_00_LE_BILCOBER_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "BILCOBER_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0121_00_LE_BILCOBER_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1CLIEN_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_DTPROX_DEB" , ""},
                { "V1SISTE_DTCURRENT" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_TIPO_MOVTOCC" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_REQUISICAO" , ""},
                { "V1SISTE_DTMOVABE" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRPARCEL" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0MOVDE_REQUISICAO" , ""},
                { "V1SISTE_DTMOVABE" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRPARCEL" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_COD_PRODUTO" , ""},
                { "HISCOBPR_SEQ_PRODUTO_VRS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1", q17);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("BI0031B_SaidaDebito.txt", "BI0031B.txt")]
        public static void BI0031B_Tests_Theory_ReturnCode_0(string MOVDEBITO_CC_FILE_NAME_P, string RBI0031B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVDEBITO_CC_FILE_NAME_P = $"{MOVDEBITO_CC_FILE_NAME_P}_{timestamp}.txt";
            RBI0031B_FILE_NAME_P = $"{RBI0031B_FILE_NAME_P}_{timestamp}.txt";
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
                { "V1SISTE_DTMOVABE" , "2025-01-27"},
                { "V1SISTE_DTCURRENT" , "2025-02-17"},
                { "V1SISTE_DTMOVABE_10" , "2025-02-06"},
                { "V1SISTE_DTMOVABE_30" , "2024-12-28"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #region R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA SEGURADORA S.A.                   "}
                });
                AppSettings.TestSet.DynamicData.Remove("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion
                #region BI0031B_V0PARAMC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_TIPO_MOVTOCC" , "1"},
                { "V0PARAMC_CODPRODU" , "7106"},
                { "V0PARAMC_COD_CONVENIO" , "6114"},
                { "V0PARAMC_NSAS" , "10354"},
                { "V0PARAMC_COD_AGENCIA_SASS" , "630"},
                { "V0PARAMC_DTPROX_DEB" , "2029-05-08"},
                { "V0PARAMC_DIA_DEBITO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI0031B_V0PARAMC");
                AppSettings.TestSet.DynamicData.Add("BI0031B_V0PARAMC", q2);

                #endregion
                #region BI0031B_V0MOVDE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_NUM_APOLICE" , "103100006962"},
                { "V0MOVDE_NRENDOS" , "0"},
                { "V0MOVDE_NRPARCEL" , "6"},
                { "V0MOVDE_DTVENCTO" , "2024-12-31"},
                { "V0MOVDE_DAYS" , "-819"},
                { "V0MOVDE_VLR_DEBITO" , "99"},
                { "V0MOVDE_DIA_DEBITO" , "0"},
                { "V0MOVDE_COD_AGENCIA_DEB" , "0"},
                { "V0MOVDE_OPER_CONTA_DEB" , "5"},
                { "V0MOVDE_NUM_CONTA_DEB" , "0"},
                { "V0MOVDE_DIG_CONTA_DEB" , "151"},
                { "V0MOVDE_COD_CONVENIO" , "0"},
                { "V0MOVDE_COD_USUARIO" , "VA0853B "},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_NUM_APOLICE" , "103100006962"},
                { "V0MOVDE_NRENDOS" , "0"},
                { "V0MOVDE_NRPARCEL" , "0"},
                { "V0MOVDE_DTVENCTO" , "2024-12-31"},
                { "V0MOVDE_DAYS" , "-819"},
                { "V0MOVDE_VLR_DEBITO" , "99"},
                { "V0MOVDE_DIA_DEBITO" , "0"},
                { "V0MOVDE_COD_AGENCIA_DEB" , "0"},
                { "V0MOVDE_OPER_CONTA_DEB" , "5"},
                { "V0MOVDE_NUM_CONTA_DEB" , "0"},
                { "V0MOVDE_DIG_CONTA_DEB" , "152"},
                { "V0MOVDE_COD_CONVENIO" , "0"},
                { "V0MOVDE_COD_USUARIO" , "VA0853B "},
                });

                AppSettings.TestSet.DynamicData.Remove("BI0031B_V0MOVDE");
                AppSettings.TestSet.DynamicData.Add("BI0031B_V0MOVDE", q3);

                #endregion
                #region R0121_00_LE_BILCOBER_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "BILCOBER_COD_PRODUTO" , "1402"}
                });
                q10.AddDynamic(new Dictionary<string, string>{
                { "BILCOBER_COD_PRODUTO" , "8144"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0121_00_LE_BILCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0121_00_LE_BILCOBER_DB_SELECT_1_Query1", q10);

                #endregion
                #region R0119_00_LE_PROPOFID_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , "0"},
                { "PROPOFID_COD_PLANO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0119_00_LE_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0119_00_LE_PROPOFID_DB_SELECT_1_Query1", q9);

                #endregion
                #endregion
                var program = new BI0031B();
                program.Execute(MOVDEBITO_CC_FILE_NAME_P, RBI0031B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0PARAMC_COD_CONVENIO", out var valor0) && valor0.Contains("000006114"));

                //R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0MOVDE_NUM_APOLICE", out var valor1) && valor1.Contains("0103100006962"));

                //R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V0BILH_NUMBIL", out var valor2) && valor2.Contains("000103100006962"));

                //R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("V0PARAMC_NSAS", out var valor3) && valor3.Contains("1036"));

                //R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("V0BILH_SITUACAO", out var valor4) && valor4.Contains("6"));

            }
        }
        [Theory]
        [InlineData("BI0031B_SaidaDebito.txt", "BI0031B.txt")]
        public static void BI0031B_Tests_Theory_Error_ReturnCode_9(string MOVDEBITO_CC_FILE_NAME_P, string RBI0031B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVDEBITO_CC_FILE_NAME_P = $"{MOVDEBITO_CC_FILE_NAME_P}_{timestamp}.txt";
            RBI0031B_FILE_NAME_P = $"{RBI0031B_FILE_NAME_P}_{timestamp}.txt";
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
                { "V1SISTE_DTMOVABE" , "2025-01-27"},
                { "V1SISTE_DTCURRENT" , "2025-02-17"},
                { "V1SISTE_DTMOVABE_10" , "2025-02-06"},
                { "V1SISTE_DTMOVABE_30" , "2024-12-28"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #region R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA SEGURADORA S.A.                   "}
                });
                AppSettings.TestSet.DynamicData.Remove("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion
                #region BI0031B_V0PARAMC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_TIPO_MOVTOCC" , "1"},
                { "V0PARAMC_CODPRODU" , "7106"},
                { "V0PARAMC_COD_CONVENIO" , "6114"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI0031B_V0PARAMC");
                AppSettings.TestSet.DynamicData.Add("BI0031B_V0PARAMC", q2);

                #endregion
                #endregion
                var program = new BI0031B();
                program.Execute(MOVDEBITO_CC_FILE_NAME_P, RBI0031B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }

    }
}