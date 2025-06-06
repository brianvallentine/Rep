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
using static Code.VE0031B;

namespace FileTests.Test
{
    [Collection("VE0031B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VE0031B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1PAR_RAMO_VG" , ""},
                { "V1PAR_RAMO_AP" , ""},
                { "V1PAR_RAMO_PST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region VE0031B_CRELAT

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0031B_CRELAT", q2);

            #endregion

            #region VE0031B_CSEGURA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0031B_CSEGURA", q3);

            #endregion

            #region R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_TIPO_INCLUSAO" , ""},
                { "SEGURVGA_COD_AGENCIADOR" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
                { "SEGURVGA_SIT_REGISTRO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_NUM_MATRICULA" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1", q7);

            #endregion

            #region R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_TIPO_INCLUSAO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_COD_AGENCIADOR" , ""},
                { "MOVIMVGA_PERI_PAGAMENTO" , ""},
                { "CONTACOR_COD_AGENCIA" , ""},
                { "SEGURVGA_NUM_MATRICULA" , ""},
                { "CONTACOR_NUM_CTA_CORRENTE" , ""},
                { "CONTACOR_DAC_CTA_CORRENTE" , ""},
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_IMPINVPERM" , ""},
                { "V0COBA_IMPDIT" , ""},
                { "V0COBA_PRMVG" , ""},
                { "V0COBA_PRMAP" , ""},
                { "MOVIMVGA_COD_OPERACAO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "FATURCON_DATA_REFERENCIA" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1", q10);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1", q11);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_PRMVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1", q12);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1", q13);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1", q14);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1", q15);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_COD_AGENCIA" , ""},
                { "CONTACOR_NUM_CTA_CORRENTE" , ""},
                { "CONTACOR_DAC_CTA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1", q16);

            #endregion

            #endregion
        }

        [Fact]
        public static void VE0031B_Tests_Fact_ReturnCode00()
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
                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1PAR_RAMO_VG" , "" },
                    { "V1PAR_RAMO_AP" , "" },
                    { "V1PAR_RAMO_PST" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region VE0031B_CRELAT

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_DATA_SOLICITACAO" , "" },
                    { "RELATORI_NUM_APOLICE" , "" },
                    { "RELATORI_COD_SUBGRUPO" , "" },
                    { "RELATORI_COD_USUARIO" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("VE0031B_CRELAT");
                AppSettings.TestSet.DynamicData.Add("VE0031B_CRELAT", q2);

                #endregion

                #region VE0031B_CSEGURA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_NUM_CERTIFICADO" , "" },
                    { "SEGURVGA_COD_FONTE" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("VE0031B_CSEGURA");
                AppSettings.TestSet.DynamicData.Add("VE0031B_CSEGURA", q3);

                #endregion

                #region R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SUBGVGAP_PERI_FATURAMENTO" , "" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_SUBGRUPO" , "" },
                    { "RELATORI_NUM_APOLICE" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_TIPO_INCLUSAO" , "" },
                    { "SEGURVGA_COD_AGENCIADOR" , "" },
                    { "SEGURVGA_NUM_ITEM" , "" },
                    { "SEGURVGA_OCORR_HISTORICO" , "" },
                    { "SEGURVGA_NUM_APOLICE" , "" },
                    { "SEGURVGA_COD_SUBGRUPO" , "" },
                    { "SEGURVGA_COD_FONTE" , "" },
                    { "SEGURVGA_SIT_REGISTRO" , "" },
                    { "SEGURVGA_COD_CLIENTE" , "" },
                    { "SEGURVGA_NUM_MATRICULA" , "" },
                    { "SEGURVGA_DATA_INIVIGENCIA" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_ULT_PROP_AUTOMAT" , "" }
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1", q7);

                #endregion

                #region R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_ULT_PROP_AUTOMAT" , "" },
                    { "SEGURVGA_COD_FONTE" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1", q8);

                #endregion

                #region R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_NUM_APOLICE" , "" },
                    { "SEGURVGA_COD_SUBGRUPO" , "" },
                    { "SEGURVGA_COD_FONTE" , "" },
                    { "FONTES_ULT_PROP_AUTOMAT" , "" },
                    { "SEGURVGA_NUM_CERTIFICADO" , "" },
                    { "SEGURVGA_TIPO_INCLUSAO" , "" },
                    { "SEGURVGA_COD_CLIENTE" , "" },
                    { "SEGURVGA_COD_AGENCIADOR" , "" },
                    { "MOVIMVGA_PERI_PAGAMENTO" , "" },
                    { "CONTACOR_COD_AGENCIA" , "" },
                    { "SEGURVGA_NUM_MATRICULA" , "" },
                    { "CONTACOR_NUM_CTA_CORRENTE" , "" },
                    { "CONTACOR_DAC_CTA_CORRENTE" , "" },
                    { "V0COBA_IMPMORNATU" , "" },
                    { "V0COBA_IMPMORACID" , "" },
                    { "V0COBA_IMPINVPERM" , "" },
                    { "V0COBA_IMPDIT" , "" },
                    { "V0COBA_PRMVG" , "" },
                    { "V0COBA_PRMAP" , "" },
                    { "MOVIMVGA_COD_OPERACAO" , "" },
                    { "RELATORI_COD_USUARIO" , "" },
                    { "FATURCON_DATA_REFERENCIA" , "" },
                    { "RELATORI_DATA_SOLICITACAO" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "FATURCON_DATA_REFERENCIA" , "" }
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1", q10);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "FATURCON_DATA_REFERENCIA" , "" }
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1", q11);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V0COBA_IMPMORNATU" , "" },
                    { "V0COBA_PRMVG" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1", q12);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V0COBA_IMPMORACID" , "" },
                    { "V0COBA_PRMAP" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1", q13);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V0COBA_IMPINVPERM" , "" }
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1", q14);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V0COBA_IMPDIT" , "" }
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1", q15);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "CONTACOR_COD_AGENCIA" , "" },
                    { "CONTACOR_NUM_CTA_CORRENTE" , "" },
                    { "CONTACOR_DAC_CTA_CORRENTE" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1", q16);

                #endregion
                #endregion
                var program = new VE0031B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count == 0).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VE0031B_Tests_Fact_ReturnCode99()
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
                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1PAR_RAMO_VG" , "" },
                    { "V1PAR_RAMO_AP" , "" },
                    { "V1PAR_RAMO_PST" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region VE0031B_CRELAT

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_DATA_SOLICITACAO" , "" },
                    { "RELATORI_NUM_APOLICE" , "" },
                    { "RELATORI_COD_SUBGRUPO" , "" },
                    { "RELATORI_COD_USUARIO" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VE0031B_CRELAT");
                AppSettings.TestSet.DynamicData.Add("VE0031B_CRELAT", q2);

                #endregion

                #region VE0031B_CSEGURA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_NUM_CERTIFICADO" , "" },
                    { "SEGURVGA_COD_FONTE" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VE0031B_CSEGURA");
                AppSettings.TestSet.DynamicData.Add("VE0031B_CSEGURA", q3);

                #endregion

                #region R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SUBGVGAP_PERI_FATURAMENTO" , "" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_SUBGRUPO" , "" },
                    { "RELATORI_NUM_APOLICE" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_TIPO_INCLUSAO" , "" },
                    { "SEGURVGA_COD_AGENCIADOR" , "" },
                    { "SEGURVGA_NUM_ITEM" , "" },
                    { "SEGURVGA_OCORR_HISTORICO" , "" },
                    { "SEGURVGA_NUM_APOLICE" , "" },
                    { "SEGURVGA_COD_SUBGRUPO" , "" },
                    { "SEGURVGA_COD_FONTE" , "" },
                    { "SEGURVGA_SIT_REGISTRO" , "" },
                    { "SEGURVGA_COD_CLIENTE" , "" },
                    { "SEGURVGA_NUM_MATRICULA" , "" },
                    { "SEGURVGA_DATA_INIVIGENCIA" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_ULT_PROP_AUTOMAT" , "" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1", q7);

                #endregion

                #region R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_ULT_PROP_AUTOMAT" , "" },
                    { "SEGURVGA_COD_FONTE" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1", q8);

                #endregion

                #region R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_NUM_APOLICE" , "" },
                    { "SEGURVGA_COD_SUBGRUPO" , "" },
                    { "SEGURVGA_COD_FONTE" , "" },
                    { "FONTES_ULT_PROP_AUTOMAT" , "" },
                    { "SEGURVGA_NUM_CERTIFICADO" , "" },
                    { "SEGURVGA_TIPO_INCLUSAO" , "" },
                    { "SEGURVGA_COD_CLIENTE" , "" },
                    { "SEGURVGA_COD_AGENCIADOR" , "" },
                    { "MOVIMVGA_PERI_PAGAMENTO" , "" },
                    { "CONTACOR_COD_AGENCIA" , "" },
                    { "SEGURVGA_NUM_MATRICULA" , "" },
                    { "CONTACOR_NUM_CTA_CORRENTE" , "" },
                    { "CONTACOR_DAC_CTA_CORRENTE" , "" },
                    { "V0COBA_IMPMORNATU" , "" },
                    { "V0COBA_IMPMORACID" , "" },
                    { "V0COBA_IMPINVPERM" , "" },
                    { "V0COBA_IMPDIT" , "" },
                    { "V0COBA_PRMVG" , "" },
                    { "V0COBA_PRMAP" , "" },
                    { "MOVIMVGA_COD_OPERACAO" , "" },
                    { "RELATORI_COD_USUARIO" , "" },
                    { "FATURCON_DATA_REFERENCIA" , "" },
                    { "RELATORI_DATA_SOLICITACAO" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "FATURCON_DATA_REFERENCIA" , "" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1", q10);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "FATURCON_DATA_REFERENCIA" , "" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1", q11);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V0COBA_IMPMORNATU" , "" },
                    { "V0COBA_PRMVG" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1", q12);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V0COBA_IMPMORACID" , "" },
                    { "V0COBA_PRMAP" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1", q13);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V0COBA_IMPINVPERM" , "" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1", q14);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V0COBA_IMPDIT" , "" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1", q15);

                #endregion

                #region R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "CONTACOR_COD_AGENCIA" , "" },
                    { "CONTACOR_NUM_CTA_CORRENTE" , "" },
                    { "CONTACOR_DAC_CTA_CORRENTE" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1", q16);

                #endregion

                #endregion
                var program = new VE0031B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}