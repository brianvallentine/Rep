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
using static Code.BI0071B;
using System.IO;

namespace FileTests.Test
{
    [Collection("BI0071B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0071B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_DTMOVABE" , "2000-10-10"},
                { "V1SISTE_DTCURRENT" , "2000-10-10"},
                { "V1SISTE_DTMOVABE_10" , "2000-10-10"},
                { "V1SISTE_DTMOVABE_30" , "2000-10-10"},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_TSCURRENT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q2);

            #endregion

            #region BI0071B_V0PARAMC

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_TIPO_MOVTOCC" , ""},
                { "V0PARAMC_CODPRODU" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_COD_AGENCIA_SASS" , ""},
                { "V0PARAMC_DTPROX_DEB" , "2000-10-10"},
                { "V0PARAMC_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0071B_V0PARAMC", q3);

            #endregion

            #region BI0071B_V0MOVDE

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_COD_AGENCIA_DEB" , ""},
                { "V0MOVDE_OPER_CONTA_DEB" , ""},
                { "V0MOVDE_NUM_CONTA_DEB" , ""},
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0MOVDE_DTVENCTO" , "2000-10-10"},
                { "V0MOVDE_DTVENCTO_5" , "2000-10-10"},
                { "V0MOVDE_VLR_DEBITO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRENDOS" , ""},
                { "V0MOVDE_NRPARCEL" , ""},
                { "V0MOVDE_DIA_DEBITO" , ""},
                { "V0MOVDE_SIT_COBRANCA" , ""},
                { "V0MOVDE_COD_RETORNO_CEF" , ""},
                { "V0MOVDE_DAYS" , ""},
                { "V0MOVDE_NSAS" , ""},
                { "V0MOVDE_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0071B_V0MOVDE", q4);

            #endregion

            #region R0114_00_LE_V1BILHETE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , ""},
                { "V1BILH_COD_CLIENTE" , ""},
                { "V1BILH_NUMAPOL" , ""},
                { "V1BILH_RAMO" , ""},
                { "V1BILH_OPCAO_COB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0114_00_LE_V1BILHETE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , ""},
                { "V1BILH_FONTE" , ""},
                { "V1BILH_COD_CLIENTE" , ""},
                { "V1BILH_OCOREND" , ""},
                { "V1BILH_SITUACAO" , ""},
                { "V1BILH_RAMO" , ""},
                { "V1BILH_OPCAO_COB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRPARCEL" , ""},
                { "V0MOVDE_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0121_00_LE_CONVERSI_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUMPROPOSTA" , ""},
                { "V0CONV_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0121_00_LE_CONVERSI_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0121_00_LE_CONVERSI_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0121_00_LE_CONVERSI_DB_SELECT_2_Query1", q9);

            #endregion

            #region R0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRPARCEL" , ""},
                { "V0MOVDE_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R0121_00_LE_CONVERSI_DB_SELECT_3_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUMPROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0121_00_LE_CONVERSI_DB_SELECT_3_Query1", q11);

            #endregion

            #region R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "APOLCOBR_COD_AGENCIA" , ""},
                { "APOLCOBR_COD_PRODUTO" , ""},
                { "APOLCOBR_COD_AGENCIA_DEB" , ""},
                { "APOLCOBR_OPER_CONTA_DEB" , ""},
                { "APOLCOBR_NUM_CONTA_DEB" , ""},
                { "APOLCOBR_DIG_CONTA_DEB" , ""},
                { "APOLCOBR_NUM_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1CLIEN_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_DTPROX_DEB" , "2000-10-10"},
                { "V1SISTE_DTCURRENT" , "2000-10-10"},
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_TIPO_MOVTOCC" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_SIT_COBRANCA" , ""},
                { "V0MOVDE_REQUISICAO" , ""},
                { "V1SISTE_DTCURRENT" , ""},
                { "V1SISTE_TSCURRENT" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRPARCEL" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_NRENDOS" , ""},
                { "V0MOVDE_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "BILCOBER_VAL_MAX_COBER_BAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1", q16);

            #endregion

            #region R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , ""},
                { "WHOST_SIT_REGISTRO" , ""},
                { "V1SISTE_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1", q17);

            #endregion

            #region R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1", q18);

            #endregion

            #region SEGUROS_SPBVG012_Call1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "LK_NUM_PLANO" , ""},
                { "LK_NUM_PROPOSTA" , ""},
                { "LK_COD_RAMO" , ""},
                { "LK_TRACE" , ""},
                { "LK_OUT_COD_RETORNO" , ""},
                { "LK_OUT_SQLCODE" , ""},
                { "LK_OUT_MENSAGEM" , ""},
                { "LK_OUT_SQLERRMC" , ""},
                { "LK_OUT_SQLSTATE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBVG012_Call1", q19);

            #endregion

            #region R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , ""},
                { "PARM_COD_EMPR_CAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q20);

            #endregion


            PROALN01_Tests.Load_Parameters();

            #endregion
        }

        [Theory]
        [InlineData("MOVDEBITO.txt", "RBI0071B.txt", "BI0071B1.txt")]
        public static void BI0071B_Tests_Theory(string MOVDEBITO_CC_FILE_NAME_P, string RBI0071B_FILE_NAME_P, string BI0071B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVDEBITO_CC_FILE_NAME_P = $"{MOVDEBITO_CC_FILE_NAME_P}_{timestamp}.txt";
            RBI0071B_FILE_NAME_P = $"{RBI0071B_FILE_NAME_P}_{timestamp}.txt";
            BI0071B1_FILE_NAME_P = $"{BI0071B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                AppSettings.TestSet.DynamicData.Remove("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1");

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA SEGURADORA S.A.                                                                                                               "}});
                AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q2);

                #region VARIAVEIS_TESTE
                #endregion
                var program = new BI0071B();
                program.Execute(MOVDEBITO_CC_FILE_NAME_P, RBI0071B_FILE_NAME_P, BI0071B1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.RBI0071B.FilePath));
                Assert.True(new FileInfo(program.RBI0071B.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0MOVDE_DTVENCTO", out var valor) && valor == "2000-10-10");

                var envList1 = AppSettings.TestSet.DynamicData["R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList1[1].TryGetValue("V0PARAMC_SITUACAO", out valor) && valor == "A");

            }
        }

        [Theory]
        [InlineData("MOVDEBITO.txt", "RBI0071B.txt", "BI0071B1.txt")]
        public static void BI0071B_Tests_SemDados(string MOVDEBITO_CC_FILE_NAME_P, string RBI0071B_FILE_NAME_P, string BI0071B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVDEBITO_CC_FILE_NAME_P = $"{MOVDEBITO_CC_FILE_NAME_P}_{timestamp}.txt";
            RBI0071B_FILE_NAME_P = $"{RBI0071B_FILE_NAME_P}_{timestamp}.txt";
            BI0071B1_FILE_NAME_P = $"{BI0071B1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                AppSettings.TestSet.DynamicData.Remove("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA SEGURADORA S.A.                                                                                                               "}});
                AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q2);

                AppSettings.TestSet.DynamicData.Remove("BI0071B_V0PARAMC");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_TIPO_MOVTOCC" , ""},
                { "V0PARAMC_CODPRODU" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_COD_AGENCIA_SASS" , ""},
                { "V0PARAMC_DTPROX_DEB" , "2000-10-10"},
                { "V0PARAMC_DIA_DEBITO" , ""},
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Add("BI0071B_V0PARAMC", q3);

                #region VARIAVEIS_TESTE
                #endregion
                var program = new BI0071B();
                program.Execute(MOVDEBITO_CC_FILE_NAME_P, RBI0071B_FILE_NAME_P, BI0071B1_FILE_NAME_P);

              
                Assert.True(program.RETURN_CODE == 99);

            }
        }

    }
}