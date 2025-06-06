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
using static Code.EM0911S;

namespace FileTests.Test
{
    [Collection("EM0911S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0911S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_ORGAO" , "10"},
                { "V1ENDO_RAMO" , "71"},
                { "V1ENDO_FONTE" , "10"},
                { "V1ENDO_MOEDA_PRM" , "1"},
                { "V1ENDO_MOEDA_IMP" , "1"},
                { "V1ENDO_TIPO_ENDO" , "0"},
                { "V1ENDO_CODPRODU" , "6800"},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q1);

            #endregion

            #region EM0911S_V1OUTROSPROP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1PROU_COD_EMPRESA" , ""},
                { "V1PROU_FONTE" , ""},
                { "V1PROU_NRPROPOS" , ""},
                { "V1PROU_NRRISCO" , ""},
                { "V1PROU_CODCLIEN" , ""},
                { "V1PROU_OCORR_END" , ""},
                { "V1PROU_PROPRIET" , ""},
                { "V1PROU_COD_LOGRAD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0911S_V1OUTROSPROP", q2);

            #endregion

            #region EM0911S_V1OUTRCOBERPROP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1PRCO_COD_EMPRESA" , "0"},
                { "V1PRCO_FONTE" , "1"},
                { "V1PRCO_NRPROPOS" , "1335"},
                { "V1PRCO_NRRISCO" , "1"},
                { "V1PRCO_RAMOFR" , "71"},
                { "V1PRCO_MODALIFR" , "50"},
                { "V1PRCO_COD_COBERTURA" , "2"},
                { "V1PRCO_DTINIVIG" , "1996-08-01"},
                { "V1PRCO_DTTERVIG" , "1997-08-01"},
                { "V1PRCO_IMP_SEGURADA_IX" , "50000.00"},
                { "V1PRCO_IMP_SEGURADA_VAR" , "50000.00"},
                { "V1PRCO_TAXA_IS" , "0.140000000"},
                { "V1PRCO_PRM_ANUAL_IX" , "70.00000"},
                { "V1PRCO_PRM_TARIFARIO_IX" , "70.00000"},
                { "V1PRCO_PRM_TARIFARIO_VAR" , "70.00000"},
                { "V1PRCO_VRFROBR_IX" , "0.00"},
                { "V1PRCO_LIMITE_INDENIZA_IX" , "50000.00000"},
                { "V1PRCO_SITUACAO" , " "},
            });
            AppSettings.TestSet.DynamicData.Add("EM0911S_V1OUTRCOBERPROP", q3);

            #endregion

            #region R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0APOU_COD_EMPRESA" , ""},
                { "V0APOU_FONTE" , ""},
                { "V0APOU_NRPROPOS" , ""},
                { "V0APOU_NRRISCO" , ""},
                { "V0APOU_CODCLIEN" , ""},
                { "V0APOU_OCORR_END" , ""},
                { "V0APOU_PROPRIET" , ""},
                { "V0APOU_COD_LOGRAD" , ""},
                { "V0APOU_NUM_APOL" , ""},
                { "V0APOU_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1", q4);

            #endregion

            #region EM0911S_V1OUTRBENSPROP

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1PROB_COD_EMPRESA" , "1"},
                { "V1PROB_FONTE" , "10"},
                { "V1PROB_NRPROPOS" , "41887"},
                { "V1PROB_NRRISCO" , "1"},
                { "V1PROB_DTINIVIG" , "2024-01-01"},
                { "V1PROB_DTTERVIG" , "2024-12-12"},
                { "V1PROB_NRBEM" , "1"},
                { "V1PROB_DESCRBEM" , "IMOVEL DESABITADO                       "},
                { "V1PROB_NRSERIE" , ""},
                { "V1PROB_IMP_SEG_IX" , "14000"},
            });
            AppSettings.TestSet.DynamicData.Add("EM0911S_V1OUTRBENSPROP", q5);

            #endregion

            #region R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0APOC_COD_EMPRESA" , ""},
                { "V0APOC_FONTE" , ""},
                { "V0APOC_NRPROPOS" , ""},
                { "V0APOC_NRRISCO" , ""},
                { "V0APOC_RAMOFR" , ""},
                { "V0APOC_MODALIFR" , ""},
                { "V0APOC_COD_COBER" , ""},
                { "V0APOC_DTINIVIG" , ""},
                { "V0APOC_DTTERVIG" , ""},
                { "V0APOC_IMP_SEG_IX" , ""},
                { "V0APOC_IMP_SEG_VR" , ""},
                { "V0APOC_TAXA_IS" , ""},
                { "V0APOC_PRM_ANU_IX" , ""},
                { "V0APOC_PRM_TAR_IX" , ""},
                { "V0APOC_PRM_TAR_VR" , ""},
                { "V0APOC_VRFROBR_IX" , ""},
                { "V0APOC_LIM_IND_IX" , ""},
                { "V0APOC_SITUACAO" , ""},
                { "V0APOC_NUM_APOL" , ""},
                { "V0APOC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1", q6);

            #endregion

            #region EM0911S_V1BENSCOBERPROP

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1PRBC_COD_EMPRESA" , "1"},
                { "V1PRBC_FONTE" , "10"},
                { "V1PRBC_NRPROPOS" , "41887"},
                { "V1PRBC_NRRISCO" , "1"},
                { "V1PRBC_COD_COBER" , "0"},
                { "V1PRBC_NRBEM" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("EM0911S_V1BENSCOBERPROP", q7);

            #endregion

            #region R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0APOB_COD_EMPRESA" , ""},
                { "V0APOB_FONTE" , ""},
                { "V0APOB_NRPROPOS" , ""},
                { "V0APOB_NRRISCO" , ""},
                { "V0APOB_DTINIVIG" , ""},
                { "V0APOB_DTTERVIG" , ""},
                { "V0APOB_NRBEM" , ""},
                { "V0APOB_DESCRBEM" , ""},
                { "V0APOB_NRSERIE" , ""},
                { "V0APOB_IMP_SEG_IX" , ""},
                { "V0APOB_NUM_APOL" , ""},
                { "V0APOB_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1", q8);

            #endregion

            #region EM0911S_V1PROPCLAU

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1PRCL_COD_EMPRESA" , "0"},
                { "V1PRCL_FONTE" , "1"},
                { "V1PRCL_NRPROPOS" , "876"},
                { "V1PRCL_RAMOFR" , "11"},
                { "V1PRCL_MODALIFR" , "0"},
                { "V1PRCL_COD_COBERT" , "0"},
                { "V1PRCL_DTINIVIG" , "1996-01-31"},
                { "V1PRCL_DTTERVIG" , "1997-01-31"},
                { "V1PRCL_NRITEM" , "1"},
                { "V1PRCL_CODCLAUS" , "101     "},
                { "V1PRCL_LIM_IND_IX" , "0.00000"},
            });
            AppSettings.TestSet.DynamicData.Add("EM0911S_V1PROPCLAU", q9);

            #endregion

            #region R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0APBC_COD_EMPRESA" , ""},
                { "V0APBC_FONTE" , ""},
                { "V0APBC_NRPROPOS" , ""},
                { "V0APBC_NRRISCO" , ""},
                { "V0APBC_COD_COBER" , ""},
                { "V0APBC_NRBEM" , ""},
                { "V0APBC_NUM_APOL" , ""},
                { "V0APBC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1", q10);

            #endregion

            #region EM0911S_V1OUTRCOBERP

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1PRCO_COD_EMPRESA" , ""},
                { "V1PRCO_FONTE" , ""},
                { "V1PRCO_NRPROPOS" , ""},
                { "V1PRCO_NRRISCO" , ""},
                { "V1PRCO_RAMOFR" , ""},
                { "V1PRCO_MODALIFR" , ""},
                { "V1PRCO_COD_COBER" , ""},
                { "V1PRCO_DTINIVIG" , ""},
                { "V1PRCO_DTTERVIG" , ""},
                { "V1PRCO_IMP_SEG_IX" , ""},
                { "V1PRCO_IMP_SEG_VR" , ""},
                { "V1PRCO_TAXA_IS" , ""},
                { "V1PRCO_PRM_ANU_IX" , ""},
                { "V1PRCO_PRM_TAR_IX" , ""},
                { "V1PRCO_PRM_TAR_VR" , ""},
                { "V1PRCO_VRFROBR_IX" , ""},
                { "V1PRCO_LIM_IND_IX" , ""},
                { "V1PRCO_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0911S_V1OUTRCOBERP", q11);

            #endregion

            #region R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0APCL_COD_EMPRESA" , ""},
                { "V0APCL_NUM_APOL" , ""},
                { "V0APCL_NRENDOS" , ""},
                { "V0APCL_RAMOFR" , ""},
                { "V0APCL_MODALIFR" , ""},
                { "V0APCL_COD_COBERT" , ""},
                { "V0APCL_DTINIVIG" , ""},
                { "V0APCL_DTTERVIG" , ""},
                { "V0APCL_NRITEM" , ""},
                { "V0APCL_CODCLAUS" , ""},
                { "V0APCL_LIM_IND_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , ""},
                { "V0EDIA_NUM_APOL" , ""},
                { "V0EDIA_NRENDOS" , ""},
                { "V0EDIA_NRPARCEL" , ""},
                { "V0EDIA_DTMOVTO" , ""},
                { "V0EDIA_ORGAO" , ""},
                { "V0EDIA_RAMO" , ""},
                { "V0EDIA_FONTE" , ""},
                { "V0EDIA_CONGENER" , ""},
                { "V0EDIA_CODCORR" , ""},
                { "V0EDIA_SITUACAO" , ""},
                { "V0EDIA_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "W1COBP_PRM_TAR_VR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1_Query1", q14);

            #endregion

            #region R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , ""},
                { "V0COBA_NRENDOS" , ""},
                { "V0COBA_NUM_ITEM" , ""},
                { "V0COBA_OCORHIST" , ""},
                { "V0COBA_RAMOFR" , ""},
                { "V0COBA_MODALIFR" , ""},
                { "V0COBA_COD_COBER" , ""},
                { "V0COBA_IMP_SEG_IX" , ""},
                { "V0COBA_PRM_TAR_IX" , ""},
                { "V0COBA_IMP_SEG_VR" , ""},
                { "V0COBA_PRM_TAR_VR" , ""},
                { "V0COBA_PCT_COBERT" , ""},
                { "V0COBA_FATOR_MULT" , ""},
                { "V0COBA_DATA_INIVI" , ""},
                { "V0COBA_DATA_TERVI" , ""},
                { "V0COBA_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_PCT_COBERT" , ""},
                { "V0COBA_NUM_APOL" , ""},
                { "V0COBA_NUM_ITEM" , ""},
                { "V0COBA_OCORHIST" , ""},
                { "V0COBA_MODALIFR" , ""},
                { "V0COBA_NRENDOS" , ""},
                { "V0COBA_RAMOFR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1", q16);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0911S_Tests_Fact_ReturnCode_00()
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
                #region param
                var inputParam = new EM0911S_LK_PROPOSTA();
                inputParam.LK_CODPRODU.Value = 100;
                inputParam.LK_FONTE.Value = 1;
                inputParam.LK_NRPROPOS.Value = 2;
                inputParam.LK_NUM_APOL.Value = 1000790324;
                inputParam.LK_NRENDOS.Value = 3;
                inputParam.LK_DTMOVABE.Value = "2024-01-01";
                inputParam.LK_CODCORR.Value = 5;
                #endregion
                #endregion
                var program = new EM0911S();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 0);

                //R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0APOU_NUM_APOL", out var val0r) && val0r.Contains("0001000790324"));
                Assert.True(envList0.Count > 1);
                //R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0APOC_RAMOFR", out var val1r) && val1r.Contains("0071"));
                Assert.True(envList1.Count > 1);
                //R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V0APOB_NRPROPOS", out var val2r) && val2r.Contains("000041887"));
                Assert.True(envList2.Count > 1);
                //R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("V0APBC_NUM_APOL", out var val3r) && val3r.Contains("0001000790324"));
                Assert.True(envList3.Count > 1);
                //R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("V0APCL_CODCLAUS", out var val4r) && val4r.Contains("101"));
                Assert.True(envList4.Count > 1);
                //R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("V0EDIA_RAMO", out var val5r) && val5r.Contains("0071"));
                Assert.True(envList5.Count > 1);
            }
        }
        [Fact]
        public static void EM0911S_Tests_Fact_Produto_99_ReturnCode_00()
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
                #region param
                var inputParam = new EM0911S_LK_PROPOSTA();
                inputParam.LK_CODPRODU.Value = 99;
                #endregion
                #endregion
                var program = new EM0911S();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.LK_PROPOSTA.LK_CODPRODU == 99);

            }
        }
        [Fact]
        public static void EM0911S_Tests_Fact_ReturnCode_99()
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
                #region param
                var inputParam = new EM0911S_LK_PROPOSTA();
                inputParam.LK_CODPRODU.Value = 100;
                #endregion
                #region R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new EM0911S();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}