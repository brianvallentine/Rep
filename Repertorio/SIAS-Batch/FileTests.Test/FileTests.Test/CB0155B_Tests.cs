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
using static Code.CB0155B;
using System.IO;

namespace FileTests.Test
{
    [Collection("CB0155B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB0155B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region CB0155B_V0AVISOCRE

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , ""},
                { "AVISOCRE_AGE_AVISO" , ""},
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                { "AVISOCRE_NUM_SEQUENCIA" , ""},
                { "AVISOCRE_DATA_MOVIMENTO" , ""},
                { "AVISOCRE_TIPO_AVISO" , "R"},
                { "AVISOCRE_DATA_AVISO" , ""},
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , "5000"},
                { "AVISOCRE_ORIGEM_AVISO" , ""},
                { "AVISOSAL_SALDO_ATUAL" , "82178.25"},
                { "AVISOSAL_SIT_REGISTRO" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("CB0155B_V0AVISOCRE", q1);

            #endregion

            #region CB0155B_V0RCAP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , "82178.25"},
            });
            AppSettings.TestSet.DynamicData.Add("CB0155B_V0RCAP", q2);

            #endregion

            #region CB0155B_V0FOLLOW

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_BCO_AVISO" , ""},
                { "FOLLOUP_AGE_AVISO" , ""},
                { "FOLLOUP_NUM_AVISO_CREDITO" , ""},
                { "FOLLOUP_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0155B_V0FOLLOW", q3);

            #endregion

            #region R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , ""},
                { "AVISOCRE_AGE_AVISO" , ""},
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                { "AVISOCRE_NUM_SEQUENCIA" , ""},
                { "AVISOCRE_DATA_MOVIMENTO" , ""},
                { "AVISOCRE_TIPO_AVISO" , "R"},
                { "AVISOCRE_DATA_AVISO" , ""},
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , "5000"},
                { "AVISOCRE_ORIGEM_AVISO" , ""},
                { "AVISOSAL_SALDO_ATUAL" , "82178.25"},
                { "AVISOSAL_SIT_REGISTRO" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , ""},
                { "AVISOCRE_AGE_AVISO" , ""},
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                { "AVISOCRE_NUM_SEQUENCIA" , ""},
                { "AVISOCRE_DATA_MOVIMENTO" , ""},
                { "AVISOCRE_TIPO_AVISO" , "R"},
                { "AVISOCRE_DATA_AVISO" , ""},
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , "5000"},
                { "AVISOCRE_ORIGEM_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1", q5);

            #endregion

            #region CB0155B_V0MOVICOB

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0155B_V0MOVICOB", q6);

            #endregion

            #region CB0155B_V0MOVICOB1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0155B_V0MOVICOB1", q7);

            #endregion

            #region R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ORIGEAVI_DESCRICAO_ORIGEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , "82178.25"}
            });
            AppSettings.TestSet.DynamicData.Add("R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , "82178.25"}
            });
            AppSettings.TestSet.DynamicData.Add("R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , "82178.25"}
            });
            AppSettings.TestSet.DynamicData.Add("R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , "82178.25"}
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , "82178.25"}
            });
            AppSettings.TestSet.DynamicData.Add("R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , "82178.25"}
            });
            AppSettings.TestSet.DynamicData.Add("R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , "82178.25"}
            });
            AppSettings.TestSet.DynamicData.Add("R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q19);

            #endregion

            #region R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1", q20);

            #endregion

            #region R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_QTD_REGISTROS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1", q21);

            #endregion

            #region CB0155B_V0FOLLOW1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_NUM_APOLICE" , ""},
                { "FOLLOUP_NUM_ENDOSSO" , ""},
                { "FOLLOUP_NUM_PARCELA" , ""},
                { "FOLLOUP_DATA_MOVIMENTO" , ""},
                { "FOLLOUP_VAL_OPERACAO" , ""},
                { "FOLLOUP_BCO_AVISO" , ""},
                { "FOLLOUP_AGE_AVISO" , ""},
                { "FOLLOUP_NUM_AVISO_CREDITO" , ""},
                { "FOLLOUP_DATA_QUITACAO" , ""},
                { "FOLLOUP_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0155B_V0FOLLOW1", q22);

            #endregion

            #region CB0155B_V0RCAP1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , "82178.25"},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPS_NUM_TITULO" , ""},
                { "RCAPS_CODIGO_PRODUTO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
                { "RCAPS_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0155B_V0RCAP1", q23);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CB0155B_OUTPUT_20250306112700", "CB0155B_OUTPUT_20250306112701", "CB0155B_OUTPUT_20250306112702", "CB0155B_OUTPUT_20250306112703")]
        public static void CB0155B_Tests_Theory_ReturnCode_00_Selects_1(string ARQSORT_FILE_NAME_P, string CB0155B1_FILE_NAME_P, string CB0155B2_FILE_NAME_P, string CB0155B3_FILE_NAME_P)
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
                var program = new CB0155B();
                program.W.WS_VLPRMTOT.Value = 5;
                program.W.LD01.LD01_VLPRMTOT.Value = 5;

                //W.LD01.LD01_TIPOAVI == "RECIBO "
                //AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO = C

                program.Execute(ARQSORT_FILE_NAME_P, CB0155B1_FILE_NAME_P, CB0155B2_FILE_NAME_P, CB0155B3_FILE_NAME_P);

                Assert.True(File.Exists(program.CB0155B1.FilePath));
                Assert.True(File.Exists(program.CB0155B2.FilePath));
                Assert.True(File.Exists(program.CB0155B3.FilePath));

                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1"].DynamicList.ToList());

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("CB0155B_OUTPUT_20250306112704", "CB0155B_OUTPUT_20250306112705", "CB0155B_OUTPUT_20250306112706", "CB0155B_OUTPUT_20250306112707")]
        public static void CB0155B_Tests_Theory_ReturnCode_00_Selects_2(string ARQSORT_FILE_NAME_P, string CB0155B1_FILE_NAME_P, string CB0155B2_FILE_NAME_P, string CB0155B3_FILE_NAME_P)
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
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "AVISOCRE_BCO_AVISO" , ""},
                    { "AVISOCRE_AGE_AVISO" , ""},
                    { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                    { "AVISOCRE_NUM_SEQUENCIA" , ""},
                    { "AVISOCRE_DATA_MOVIMENTO" , ""},
                    { "AVISOCRE_TIPO_AVISO" , "C"},
                    { "AVISOCRE_DATA_AVISO" , ""},
                    { "AVISOCRE_VAL_DESPESA" , ""},
                    { "AVISOCRE_PRM_LIQUIDO" , ""},
                    { "AVISOCRE_PRM_TOTAL" , "5000"},
                    { "AVISOCRE_ORIGEM_AVISO" , ""},
                    { "AVISOSAL_SALDO_ATUAL" , "0"},
                    { "AVISOSAL_SIT_REGISTRO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0155B_V0AVISOCRE");
                AppSettings.TestSet.DynamicData.Add("CB0155B_V0AVISOCRE", q1);

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_BCO_AVISO" , ""},
                    { "RCAPCOMP_AGE_AVISO" , ""},
                    { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                    { "RCAPCOMP_VAL_RCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0155B_V0RCAP");
                AppSettings.TestSet.DynamicData.Add("CB0155B_V0RCAP", q2);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "AVISOCRE_BCO_AVISO" , ""},
                    { "AVISOCRE_AGE_AVISO" , ""},
                    { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                    { "AVISOCRE_NUM_SEQUENCIA" , ""},
                    { "AVISOCRE_DATA_MOVIMENTO" , ""},
                    { "AVISOCRE_TIPO_AVISO" , "C"},
                    { "AVISOCRE_DATA_AVISO" , ""},
                    { "AVISOCRE_VAL_DESPESA" , ""},
                    { "AVISOCRE_PRM_LIQUIDO" , ""},
                    { "AVISOCRE_PRM_TOTAL" , "5000"},
                    { "AVISOCRE_ORIGEM_AVISO" , ""},
                    { "AVISOSAL_SALDO_ATUAL" , "0"},
                    { "AVISOSAL_SIT_REGISTRO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1", q4);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_VAL_RCAP" , "1000.00"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_VAL_RCAP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q10);

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_VAL_RCAP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q11);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "PARCEHIS_VAL_OPERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1", q13);

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "PARCEHIS_VAL_OPERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1", q14);

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_VAL_RCAP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q16);

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_VAL_RCAP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q17);

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_VAL_RCAP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q18);


                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_VAL_RCAP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q19);

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "CONDESCE_QTD_REGISTROS" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1", q21);

                #endregion
                var program = new CB0155B();
                program.W.WS_VLPRMTOT.Value = 5;
                program.W.LD01.LD01_VLPRMTOT.Value = 5;

                //W.LD01.LD01_TIPOAVI == "RECIBO "
                //AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO = C

                program.Execute(ARQSORT_FILE_NAME_P, CB0155B1_FILE_NAME_P, CB0155B2_FILE_NAME_P, CB0155B3_FILE_NAME_P);

                Assert.True(File.Exists(program.CB0155B1.FilePath));
                Assert.True(File.Exists(program.CB0155B2.FilePath));
                Assert.True(File.Exists(program.CB0155B3.FilePath));

                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1"].DynamicList.ToList());

                Assert.Empty(AppSettings.TestSet.DynamicData["R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1"].DynamicList.ToList());

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("CB0155B_OUTPUT_20250306112708", "CB0155B_OUTPUT_20250306112709", "CB0155B_OUTPUT_20250306112710", "CB0155B_OUTPUT_20250306112711")]
        public static void CB0155B_Tests_Theory_ReturnCode_99(string ARQSORT_FILE_NAME_P, string CB0155B1_FILE_NAME_P, string CB0155B2_FILE_NAME_P, string CB0155B3_FILE_NAME_P)
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
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new CB0155B();

                program.Execute(ARQSORT_FILE_NAME_P, CB0155B1_FILE_NAME_P, CB0155B2_FILE_NAME_P, CB0155B3_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}