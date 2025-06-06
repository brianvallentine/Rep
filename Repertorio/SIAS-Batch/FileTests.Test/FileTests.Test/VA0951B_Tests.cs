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
using static Code.VA0951B;

namespace FileTests.Test
{
    [Collection("VA0951B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0951B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTMOVABE_3M" , ""},
                { "WHOST_DT_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0CONT_DATCEF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA0951B_TCOMIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_AGECOBR" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "WHOST_QTDIAS" , ""},
                { "V0PROP_CODUSU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_OCOREND" , ""},
                { "V0PROP_IMPSEGUR" , ""},
                { "V0PROP_VLPREMIO" , ""},
                { "V0PROP_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0951B_TCOMIS", q2);

            #endregion

            #region VA0951B_CERROSP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0ERROSP_DESCR_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0951B_CERROSP", q3);

            #endregion

            #region R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_NOME_RAZAO" , ""},
                { "V0CLIE_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CONV_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_COD_FONTE" , ""},
                { "V0RCAP_NUM_RCAP" , ""},
                { "V0RCAP_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0RCAPCOMP_NRRCAP" , ""},
                { "V0RCAPCOMP_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0ENDE_ENDERECO" , ""},
                { "V0ENDE_BAIRRO" , ""},
                { "V0ENDE_CIDADE" , ""},
                { "V0ENDE_SIGLA_UF" , ""},
                { "V0ENDE_CEP" , ""},
                { "V0ENDE_DDD" , ""},
                { "V0ENDE_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0MALHA_CDFONTE" , ""},
                { "V0MALHA_CDESCNEG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1", q9);

            #endregion

            #region VA0951B_CFONTES

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_CODFTE" , ""},
                { "V0FONT_NOMEFTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0951B_CFONTES", q10);

            #endregion

            #region R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_NOMPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q11);

            #endregion

            #region VA0951B_CESCNEG

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0ESCN_CODESC" , ""},
                { "V0ESCN_NOMEESC" , ""},
                { "V0ESCN_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0951B_CESCNEG", q12);

            #endregion

            #region R3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R3116_00_UPDATE_PREP_MVMTO_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DT_INICIO" , ""},
                { "WHOST_DT_FIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3116_00_UPDATE_PREP_MVMTO_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0ESCN_CODESC" , ""},
                { "V0ESCN_NOMEESC" , ""},
                { "V0ESCN_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1", q15);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("D0000000000000000", "VA0951B_1", "VA0951B_2")]
        public static void VA0951B_Tests_Theory(string WPAR_PARAMETROS_P, string SVA0951B_FILE_NAME_P, string AVA0951B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WPAR_PARAMETROS_P = $"{WPAR_PARAMETROS_P}_{timestamp}.txt";
            SVA0951B_FILE_NAME_P = $"{SVA0951B_FILE_NAME_P}_{timestamp}.txt";
            AVA0951B_FILE_NAME_P = $"{AVA0951B_FILE_NAME_P}_{timestamp}.txt";
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
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2025-01-27"},
                { "V1SIST_DTMOVABE_3M" , "2025-01-27"},
                { "WHOST_DT_CORRENTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);
                #endregion

                #endregion
                var program = new VA0951B();
                program.Execute(new StringBasis(null, WPAR_PARAMETROS_P), SVA0951B_FILE_NAME_P, AVA0951B_FILE_NAME_P);

                //R3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R3115_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);

                //R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1
                var envList2 = AppSettings.TestSet.DynamicData["R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                //R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1
                var envList3 = AppSettings.TestSet.DynamicData["R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                //R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1
                var envList4 = AppSettings.TestSet.DynamicData["R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                //R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1
                var envList5 = AppSettings.TestSet.DynamicData["R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("E2025010120250101", "VA0951B_1", "VA0951B_2")]
        public static void VA0951B_Tests_Theory_Wpar_Rotina_E(string WPAR_PARAMETROS_P, string SVA0951B_FILE_NAME_P, string AVA0951B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WPAR_PARAMETROS_P = $"{WPAR_PARAMETROS_P}_{timestamp}.txt";
            SVA0951B_FILE_NAME_P = $"{SVA0951B_FILE_NAME_P}_{timestamp}.txt";
            AVA0951B_FILE_NAME_P = $"{AVA0951B_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA0951B();
                program.Execute(new StringBasis(null, WPAR_PARAMETROS_P), SVA0951B_FILE_NAME_P, AVA0951B_FILE_NAME_P);

                //R3116_00_UPDATE_PREP_MVMTO_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R3116_00_UPDATE_PREP_MVMTO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("WHOST_DT_INICIO", out var valor1) && valor1.Contains("2025"));
                Assert.True(envList1[1].TryGetValue("WHOST_DT_FIM", out var valor2) && valor2.Contains("2025"));

                Assert.True(envList1?.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("D0000000000000000", "VA0951B_1", "VA0951B_2")]
        public static void VA0951B_Tests_SemDados(string WPAR_PARAMETROS_P, string SVA0951B_FILE_NAME_P, string AVA0951B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WPAR_PARAMETROS_P = $"{WPAR_PARAMETROS_P}_{timestamp}.txt";
            SVA0951B_FILE_NAME_P = $"{SVA0951B_FILE_NAME_P}_{timestamp}.txt";
            AVA0951B_FILE_NAME_P = $"{AVA0951B_FILE_NAME_P}_{timestamp}.txt";
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
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);
                #endregion

                #endregion
                var program = new VA0951B();
                program.Execute(new StringBasis(null, WPAR_PARAMETROS_P), SVA0951B_FILE_NAME_P, AVA0951B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}