using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG0134B;

namespace FileTests.Test
{
    [Collection("VG0134B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0134B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0134B_CRELAT

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_ANO_REFERENCIA" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "WS_DATA_AUX" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0134B_CRELAT", q1);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_IMP_SEGURADA_IX" , "12"}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_PARCELA" , ""},
                { "V0PROP_ANO" , "2001"},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q3);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_ANO" , "2000"},
                { "PARCEVID_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q4);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_4_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_4_Update1", q5);

            #endregion

            #region R1100_00_CANCELA_REMISSAO_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_QTD_ANOS" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_CANCELA_REMISSAO_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R1100_00_CANCELA_REMISSAO_DB_UPDATE_2_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_CANCELA_REMISSAO_DB_UPDATE_2_Update1", q7);

            #endregion

            #region R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HOST_QTD_ANOS" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_2_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_2_Update1", q9);

            #endregion

            #region R1200_00_GERA_REMISSAO_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_REFERENCIA" , ""},
                { "HOST_QTD_ANOS" , ""},
                { "WS_DATA_AUX" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_REMISSAO_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1", q11);

            #endregion

            #region R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_REFERENCIA" , ""},
                { "HOST_QTD_ANOS" , ""},
                { "WS_DATA_AUX" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

            q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "FUNC 1"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "FUNC 1"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "FUNC 1"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "FUNC 1"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "FUNC 1"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "FUNC 1"}
            });

            AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1

            q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2024-09-04"}
            });
            AppSettings.TestSet.DynamicData.Add("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1

            q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "123"}
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

            q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "1231"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "1231"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "1231"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "1231"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "1231"}
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "1231"}
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

            q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "1231"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "1231"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "1231"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "1231"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "1231"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "1231"},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1201_00_GERA_REMISSAO_MES_DB_UPDATE_2_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1201_00_GERA_REMISSAO_MES_DB_UPDATE_2_Update1", q13);

            #endregion

            #region VG0134B_C_SINI

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "123"}
            });
            AppSettings.TestSet.DynamicData.Add("VG0134B_C_SINI", q14);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0134B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0134B();
                program.Execute();

                //R1100_00_CANCELA_REMISSAO_DB_UPDATE_1_Update1
                //R1100_00_CANCELA_REMISSAO_DB_UPDATE_2_Update1

                var envList = AppSettings.TestSet.DynamicData["R1100_00_CANCELA_REMISSAO_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("HOST_QTD_ANOS", out var valor) && valor == "0001");

            }
        }
        [Fact]
        public static void VG0134B_Tests_Fact2()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion

                #region VG0134B_CRELAT
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_ANO_REFERENCIA" , "1"},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "WS_DATA_AUX" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_PLANO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("VG0134B_CRELAT");
                AppSettings.TestSet.DynamicData.Add("VG0134B_CRELAT", q1);
                #endregion

                var program = new VG0134B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R1200_00_GERA_REMISSAO_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("HOST_QTD_ANOS", out var valor) && valor == "0001");

            }
        }
    }
}