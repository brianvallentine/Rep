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
using static Code.SI0202S;

namespace FileTests.Test
{
    [Collection("SI0202S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class SI0202S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EF072_NUM_CONTRATO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1", q1);

            #endregion

            #region R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "W_EF083_ENDERECO" , ""},
                { "EF083_NOM_BAIRRO" , ""},
                { "EF083_NUM_CEP" , ""},
                { "EF083_NOM_CIDADE" , ""},
                { "EF083_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1", q2);

            #endregion

            #region R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "EF083_DES_ENDERECO" , ""},
                { "EF083_DES_COMPL_ENDERECO" , ""},
                { "EF083_NOM_BAIRRO" , ""},
                { "EF083_NUM_CEP" , ""},
                { "EF083_NOM_CIDADE" , ""},
                { "EF083_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1", q3);

            #endregion

            #region R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "EF079_SEQ_TIPO_OBJ_SEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1", q4);

            #endregion

            #region R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "EF079_COD_PESSOA_CONTRTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "W_GEPESEND_ENDERECO" , ""},
                { "GEPESEND_NOM_BAIRRO" , ""},
                { "GEPESEND_NOM_CIDADE" , ""},
                { "GEPESEND_COD_UF" , ""},
                { "GEPESEND_NUM_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1", q6);

            #endregion

            #region R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "EF079_COD_PESSOA_CONTRTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1", q7);

            #endregion

            #region R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "EF047_COD_PESSOA_CONTRTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1", q8);

            #endregion

            #region R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "W_ENDHABIT_ENDERECO" , ""},
                { "ENDHABIT_BAIRRO" , ""},
                { "ENDHABIT_CIDADE" , ""},
                { "ENDHABIT_UF" , ""},
                { "ENDHABIT_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1", q9);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI0202S_Tests_Fact()
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

                #region R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , "3"},
                { "SINIHAB1_PONTO_VENDA" , "0"},
                { "SINIHAB1_NUM_CONTRATO" , "650205"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EF072_NUM_CONTRATO" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1", q1);

                #endregion

                #region R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1
                
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "W_EF083_ENDERECO" , "AV  QR 404 CJ 4A LT 01 APTO     NR.00404 NORTE"},
                { "EF083_NOM_BAIRRO" , "SAMAMBAIA"},
                { "EF083_NUM_CEP" , "72000000"},
                { "EF083_NOM_CIDADE" , "BRASILIA"},
                { "EF083_COD_UF" , "DF"},
                });             
                AppSettings.TestSet.DynamicData.Remove("R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1", q2);

                #endregion

                #region R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "EF083_DES_ENDERECO" , "AV  QR 404 CJ 4A LT 01 APTO     NR.00404 NORTE"},
                { "EF083_DES_COMPL_ENDERECO" , "X"},
                { "EF083_NOM_BAIRRO" , "SAMAMBAIA"},
                { "EF083_NUM_CEP" , "72000000"},
                { "EF083_NOM_CIDADE" , "BRASILIA"},
                { "EF083_COD_UF" , "DF"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1", q3);

                #endregion

                #region R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "EF079_SEQ_TIPO_OBJ_SEG" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1", q4);

                #endregion

                #region R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "EF079_COD_PESSOA_CONTRTE" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "W_GEPESEND_ENDERECO" , "AV  QR 404 CJ 4A LT 01 APTO     NR.00404 NORTE"},
                { "GEPESEND_NOM_BAIRRO" , "X"},
                { "GEPESEND_NOM_CIDADE" , "X"},
                { "GEPESEND_COD_UF" , "123"},
                { "GEPESEND_NUM_CEP" , "72000000"},
            });
                AppSettings.TestSet.DynamicData.Remove("R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1", q6);

                #endregion

                #region R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "EF079_COD_PESSOA_CONTRTE" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1", q7);

                #endregion

                #region R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "EF047_COD_PESSOA_CONTRTE" , "123"}
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1", q8);

                #endregion

                #region R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "W_ENDHABIT_ENDERECO" , "XXX"},
                { "ENDHABIT_BAIRRO" , "XX"},
                { "ENDHABIT_CIDADE" , "XX"},
                { "ENDHABIT_UF" , "X"},
                { "ENDHABIT_CEP" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1", q9);

                #endregion
                #endregion
                var program = new SI0202S();
                program.Execute(new LBSI0202_SI0202S_PARAMETROS());

                var envList1 = AppSettings.TestSet.DynamicData["R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                //R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1 Tem que estar nulo
               // var envList4 = AppSettings.TestSet.DynamicData["R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1"].DynamicList;
               // Assert.Empty(envList4);

                //R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1 tem que estar nulo
                // var envList5 = AppSettings.TestSet.DynamicData["R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1"].DynamicList;
                // Assert.Empty(envList5);

                //var envList6 = AppSettings.TestSet.DynamicData["R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1"].DynamicList;
                // Assert.Empty(envList6);

                //Causar erro 999 no R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1
                //var envList7 = AppSettings.TestSet.DynamicData["R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1"].DynamicList;
                // Assert.Empty(envList7);

                //var envList8 = AppSettings.TestSet.DynamicData["R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList8);

                //Causar erro 999 no R5000_SEL e R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1 tem que retorna resultado == 100
                //var envList9 = AppSettings.TestSet.DynamicData["R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList9);
                
                //Retorna 100 no R1000_SEL_EF_CONTR...
                //var envList10 = AppSettings.TestSet.DynamicData["R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1"].DynamicList;
               // Assert.Empty(envList10);


                Assert.True(program.LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM == "");
            }
        }

        [Fact]
        public static void SI0202S_Tests99_Fact()
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

                #region R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , "3"},
                { "SINIHAB1_PONTO_VENDA" , "0"},
                { "SINIHAB1_NUM_CONTRATO" , "650205"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1

                var q1 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1", q1);

                #endregion

                #region R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1

                var q2 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1", q2);

                #endregion

                #region R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1

                var q3 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1", q3);

                #endregion

                #region R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "EF079_SEQ_TIPO_OBJ_SEG" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1", q4);

                #endregion

                #region R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "EF079_COD_PESSOA_CONTRTE" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "W_GEPESEND_ENDERECO" , "AV  QR 404 CJ 4A LT 01 APTO     NR.00404 NORTE"},
                { "GEPESEND_NOM_BAIRRO" , "X"},
                { "GEPESEND_NOM_CIDADE" , "X"},
                { "GEPESEND_COD_UF" , "123"},
                { "GEPESEND_NUM_CEP" , "72000000"},
            });
                AppSettings.TestSet.DynamicData.Remove("R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1", q6);

                #endregion

                #region R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1

                var q7 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1", q7);

                #endregion

                #region R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "EF047_COD_PESSOA_CONTRTE" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1", q8);

                #endregion

                #region R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1", q9);

                #endregion
                #endregion
                var program = new SI0202S();
                program.Execute(new LBSI0202_SI0202S_PARAMETROS());

              

                Assert.True(program.LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM != "");
            }
        }

    }
}