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
using static Code.CB1000B;
using Sias.Cobranca.DB2.CB1000B;

namespace FileTests.Test
{
    [Collection("CB1000B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class CB1000B_Tests
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
                { "V1SIST_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_CODRELAT" , ""},
                { "V1RELA_MES_REFER" , ""},
                { "V1RELA_ANO_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q2);

            #endregion

            #region CB1000B_V1PARCELA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNPRLIQ" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
                { "V1PARC_OTNIOF" , ""},
                { "V1PARC_OTNTOTAL" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , ""},
                { "V1PARC_COD_EMP" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_MOEDA_IMP" , ""},
                { "V1ENDO_MOEDA_PRM" , ""},
                { "V1ENDO_BCORCAP" , ""},
                { "V1ENDO_AGERCAP" , ""},
                { "V1ENDO_DACRCAP" , ""},
                { "V1ENDO_BCOCOBR" , ""},
                { "V1ENDO_AGECOBR" , ""},
                { "V1ENDO_DACCOBR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1000B_V1PARCELA", q3);

            #endregion

            #region R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "W1_PRM_TAR" , ""},
                { "W1_VAL_DES" , ""},
                { "W1_VLPRMLIQ" , ""},
                { "W1_VLADIFRA" , ""},
                { "W1_VLCUSEMI" , ""},
                { "W1_VLIOCC" , ""},
                { "W1_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1", q5);

            #endregion

            #region R3500_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0COTM_VAL_VNDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0COTM_VAL_VNDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0COTM_VAL_VNDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_DACPARC" , ""},
                { "V0HISP_DTMOVTO" , ""},
                { "V0HISP_OPERACAO" , ""},
                { "V0HISP_HORAOPER" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_PRM_TAR" , ""},
                { "V0HISP_VAL_DESC" , ""},
                { "V0HISP_VLPRMLIQ" , ""},
                { "V0HISP_VLADIFRA" , ""},
                { "V0HISP_VLCUSEMI" , ""},
                { "V0HISP_VLIOCC" , ""},
                { "V0HISP_VLPRMTOT" , ""},
                { "V0HISP_VLPREMIO" , ""},
                { "V0HISP_DTVENCTO" , ""},
                { "V0HISP_BCOCOBR" , ""},
                { "V0HISP_AGECOBR" , ""},
                { "V0HISP_NRAVISO" , ""},
                { "V0HISP_NRENDOCA" , ""},
                { "V0HISP_SITCONTB" , ""},
                { "V0HISP_COD_USUR" , ""},
                { "V0HISP_RNUDOC" , ""},
                { "V0HISP_DTQITBCO" , ""},
                { "V0HISP_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OCORHIST" , ""},
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q10);

            #endregion

            #endregion
        }

        [Fact]
        public static void CB1000B_Tests_Fact_Erro99()
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
                var program = new CB1000B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void CB1000B_Tests_Fact()
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

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2022-06-30"},
                { "V1SIST_TIMESTAMP" , "2022-08-26 16:00:13.010"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_CODRELAT" , "CB1000B1"},
                { "V1RELA_MES_REFER" , "6"},
                { "V1RELA_ANO_REFER" , "2022"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTVENCTO" , "2022-05-30"}
                });
                
                AppSettings.TestSet.DynamicData.Remove("R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1_Query1", q4);

                #endregion

                #region CB1000B_V1PARCELA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL", "97010000889"},
                    { "V1PARC_NRENDOS", "833526"},
                    { "V1PARC_NRPARCEL", "0"},
                    { "V1PARC_DACPARC", "0"},
                    { "V1PARC_FONTE", "6"},
                    { "V1PARC_NRTIT", "84100564489"},
                    { "V1PARC_PRM_TAR", "73.41000"},
                    { "V1PARC_VAL_DES", "0.00000"},
                    { "V1PARC_OTNPRLIQ", "73.41000"},
                    { "V1PARC_OTNADFRA", "0.00000"},
                    { "V1PARC_OTNCUSTO", "0.00000"},
                    { "V1PARC_OTNIOF", "1.46820"},
                    { "V1PARC_OTNTOTAL", "74.87820"},
                    { "V1PARC_OCORHIST", "359"},
                    { "V1PARC_QTDDOC", "0"},
                    { "V1PARC_SITUACAO", "0"},
                    { "V1PARC_COD_EMP", ""},
                    { "V1ENDO_DTEMIS", "2023-03-23"},
                    { "V1ENDO_DTINIVIG", "2023-03-28"},
                    { "V1ENDO_DTTERVIG", "2023-04-27"},
                    { "V1ENDO_MOEDA_IMP", "1"},
                    { "V1ENDO_MOEDA_PRM", "1"},
                    { "V1ENDO_BCORCAP", "0"},
                    { "V1ENDO_AGERCAP", "0"},
                    { "V1ENDO_DACRCAP", " "},
                    { "V1ENDO_BCOCOBR", "104"},
                    { "V1ENDO_AGECOBR", "545"},
                    { "V1ENDO_DACCOBR", "3"}
                });

                AppSettings.TestSet.DynamicData.Remove("CB1000B_V1PARCELA");
                AppSettings.TestSet.DynamicData.Add("CB1000B_V1PARCELA", q3);


                #endregion

                #region R3500_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0COTM_VAL_VNDA" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3500_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0COTM_VAL_VNDA" , "1.5"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , "101800269053"},
                { "V0HISP_NRENDOS" , "809350"},
                { "V0HISP_NRPARCEL" , "1"},
                { "V0HISP_DACPARC" , "0"},
                { "V0HISP_DTMOVTO" , "2020-01-02"},
                { "V0HISP_OPERACAO" , "101"},
                { "V0HISP_HORAOPER" , "23:53:17"},
                { "V0HISP_OCORHIST" , "1"},
                { "V0HISP_PRM_TAR" , "103.59"},
                { "V0HISP_VAL_DESC" , "0.00"},
                { "V0HISP_VLPRMLIQ" , "103.59"},
                { "V0HISP_VLADIFRA" , "0.00"},
                { "V0HISP_VLCUSEMI" , "0.00"},
                { "V0HISP_VLIOCC" , "7.64"},
                { "V0HISP_VLPRMTOT" , "111.23"},
                { "V0HISP_VLPREMIO" , "111.23"},
                { "V0HISP_DTVENCTO" , "2020-01-09"},
                { "V0HISP_BCOCOBR" , "104"},
                { "V0HISP_AGECOBR" , "1089"},
                { "V0HISP_NRAVISO" , "0"},
                { "V0HISP_NRENDOCA" , "0"},
                { "V0HISP_SITCONTB" , "0"},
                { "V0HISP_COD_USUR" , ""},
                { "V0HISP_RNUDOC" , "0"},
                { "V0HISP_DTQITBCO" , ""},
                { "V0HISP_COD_EMPR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OCORHIST" , "2"},
                { "V1PARC_NUM_APOL" , "93010000890"},
                { "V1PARC_NRPARCEL" , "39290935"},
                { "V1PARC_NRENDOS" , "0"},
                 });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q10);

                #endregion

                #endregion
                var program = new CB1000B();
                program.Execute();

                //R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1
                var env = AppSettings.TestSet.DynamicData["R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(AppSettings.TestSet.DynamicData["R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1"].DynamicList);
                
                //R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("V1PARC_NUM_APOL", out var valor4) && valor4.Contains("0097010000889"));

                //R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0HISP_NRENDOS", out var valor) && valor.Contains("833526"));
                Assert.True(envList[1].TryGetValue("V0HISP_OPERACAO", out var valor2) && valor2.Contains("1000"));
                Assert.True(envList[1].TryGetValue("V0HISP_NUM_APOL", out var valor3) && valor3.Contains("97010000889"));


                Assert.True(program.RETURN_CODE == 00,"Erro no Return Code");
            }
        }
    }
}