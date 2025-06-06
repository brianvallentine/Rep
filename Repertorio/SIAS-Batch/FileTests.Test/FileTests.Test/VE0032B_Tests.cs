using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VE0032B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VE0032B_Tests")]
    public class VE0032B_Tests
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

            #region VE0032B_CRELAT

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0032B_CRELAT", q1);

            #endregion

            #region VE0032B_CSEGURA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0032B_CSEGURA", q2);

            #endregion

            #region R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0850_00_PROCESSA_V0RELATORIOS_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_PROCESSA_V0RELATORIOS_DB_UPDATE_1_Update1", q4);

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
        public static void VE0032B_Tests_Fact_Erro99()
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
                { "V1PAR_RAMO_VG" , ""},
                { "V1PAR_RAMO_AP" , ""},
                { "V1PAR_RAMO_PST" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VE0032B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void VE0032B_Tests_Fact()
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
                #endregion
                var program = new VE0032B();
                program.Execute();

                //R0850_00_PROCESSA_V0RELATORIOS_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R0850_00_PROCESSA_V0RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("SEGURVGA_COD_SUBGRUPO", out var valor) && valor.Contains("0"));
                Assert.True(envList.Count > 1);

                //R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("RELATORI_COD_SUBGRUPO", out var valor2) && valor2.Contains("0"));
                Assert.True(envList2.Count > 1);

                //R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("FONTES_ULT_PROP_AUTOMAT", out var valor3) && valor3.Contains("0"));
                Assert.True(envList3.Count > 1);

                //R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("MOVIMVGA_COD_OPERACAO", out var valor4) && valor4.Contains("0409"));
                Assert.True(envList4.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}