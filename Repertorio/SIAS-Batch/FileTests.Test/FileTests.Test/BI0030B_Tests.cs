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
using static Code.BI0030B;
using Sias.Bilhetes.DB2.BI0030B;

namespace FileTests.Test
{
    [Collection("BI0030B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class BI0030B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTMOVABE_30" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI0030B_CORIGEM

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI0030B_CORIGEM", q1);

            #endregion

            #region BI0030B_V1BILHETE

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , ""},
                { "V1BILH_AGENCIA" , ""},
                { "V1BILH_OPERACAO" , ""},
                { "V1BILH_NUMCTA" , ""},
                { "V1BILH_DIGCTA" , ""},
                { "V1BILH_AGENCIA_DEB" , ""},
                { "V1BILH_OPERACAO_DEB" , ""},
                { "V1BILH_NUMCTA_DEB" , ""},
                { "V1BILH_DIGCTA_DEB" , ""},
                { "V1BILH_DTQITBCO" , ""},
                { "V1BILH_VLRCAP" , ""},
                { "V1BILH_NUM_APOL_ANT" , ""},
                { "V1BILH_RAMO" , ""},
                { "V1BILH_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0030B_V1BILHETE", q2);

            #endregion

            #region R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DATA_REFER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_PROPOSTA_SIVPF" , ""},
                { "V0CONV_ORIGEM_PROPOSTA" , ""},
                { "V0CONV_NUM_SICOB" , ""},
                { "V0SIVPF_SIT_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1CREN_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_ANT_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CALE_DTMOVTO" , ""},
                { "V0CALE_DIASEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0FERI_DTMOVTO" , ""},
                { "V0FERI_TIPO" , ""},
                { "V0FERI_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRENDOS" , ""},
                { "V0MOVDE_SIT_COBRANCA" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_VLR_DEBITO" , ""},
                { "V0MOVDE_DTMOVTO" , ""},
                { "V0MOVDE_DIA_DEBITO" , ""},
                { "V0MOVDE_COD_AGE_DEB" , ""},
                { "V0MOVDE_OPER_CTA_DEB" , ""},
                { "V0MOVDE_NUM_CTA_DEB" , ""},
                { "V0MOVDE_DIG_CTA_DEB" , ""},
                { "V0MOVDE_COD_CONVENIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "WDATA_BASE_10" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WDATA_BASE" , ""},
                { "V1BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q13);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI0030B_Tests_Fact_Erro99()
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

                GE0006S_Tests.Load_Parameters();
                PROSOCU1_Tests.Load_Parameters();

                #region R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_PROPOSTA_SIVPF" , "1"},
                { "V0CONV_ORIGEM_PROPOSTA" , "1"},
                { "V0CONV_NUM_SICOB" , "1"},
                { "V0SIVPF_SIT_PROPOSTA" , "1"},
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1", q5);

                #endregion

                #endregion
                var program = new BI0030B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void BI0030B_Tests_Fact_UpdateBilhete()
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

                GE0006S_Tests.Load_Parameters();
                PROSOCU1_Tests.Load_Parameters();

                #region BI0030B_V1BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , "1005"},
                { "V1BILH_AGENCIA" , "1"},
                { "V1BILH_OPERACAO" , "1"},
                { "V1BILH_NUMCTA" , "1"},
                { "V1BILH_DIGCTA" , "1"},
                { "V1BILH_AGENCIA_DEB" , "1"},
                { "V1BILH_OPERACAO_DEB" , "1"},
                { "V1BILH_NUMCTA_DEB" , "1"},
                { "V1BILH_DIGCTA_DEB" , "1"},
                { "V1BILH_DTQITBCO" , "1"},
                { "V1BILH_VLRCAP" , "1"},
                { "V1BILH_NUM_APOL_ANT" , "1"},
                { "V1BILH_RAMO" , "1"},
                { "V1BILH_SITUACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI0030B_V1BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI0030B_V1BILHETE", q2);

                #endregion

                #region R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_ANT_SITUACAO" , "8"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_NUM_PROPOSTA_SIVPF" , "1"},
                { "V0CONV_ORIGEM_PROPOSTA" , "1"},
                { "V0CONV_NUM_SICOB" , "1"},
                { "V0SIVPF_SIT_PROPOSTA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1CREN_SITUACAO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1", q6);

                #endregion

                #endregion
                var program = new BI0030B();
                program.Execute();

                //R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("V1BILH_NUMBIL", out var valor3) && valor3.Contains("1005"));

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void BI0030B_Tests_Fact_InsertBilhete()
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

                GE0006S_Tests.Load_Parameters();
                PROSOCU1_Tests.Load_Parameters();

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2020-06-20"},
                { "V1SIST_DTMOVABE_30" , "2020-07-20"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region BI0030B_V1BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , "1006"},
                { "V1BILH_AGENCIA" , "1"},
                { "V1BILH_OPERACAO" , "1"},
                { "V1BILH_NUMCTA" , "1"},
                { "V1BILH_DIGCTA" , "1"},
                { "V1BILH_AGENCIA_DEB" , "1"},
                { "V1BILH_OPERACAO_DEB" , "1"},
                { "V1BILH_NUMCTA_DEB" , "1"},
                { "V1BILH_DIGCTA_DEB" , "1"},
                { "V1BILH_DTQITBCO" , "1"},
                { "V1BILH_VLRCAP" , "1"},
                { "V1BILH_NUM_APOL_ANT" , "1"},
                { "V1BILH_RAMO" , "1"},
                { "V1BILH_SITUACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI0030B_V1BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI0030B_V1BILHETE", q2);

                #endregion

                #region R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1CREN_SITUACAO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1", q6);

                #endregion

                #endregion
                var program = new BI0030B();
                program.Execute();

                //R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("V0MOVDE_COD_CONVENIO", out var valor) && valor.Contains("6114"));


                //R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("WDATA_BASE_10", out var valor2) && valor2.Contains("2020-06-30"));

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}