//using System;
//using IA_ConverterCommons;
//using System.Collections.Generic;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using System.Linq;
//using _ = IA_ConverterCommons.Statements;
//using DB = IA_ConverterCommons.DatabaseBasis;
//using Xunit;
//using Copies;
//using Code;
//using static Code.VA0197B;

//namespace FileTests.Test
//{
//    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
//    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
//    public class VA0197B_Tests
//    {
//        //é de extrema importancia que este método seja modificado com cautela, 
//        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
//        private static void Load_Parameters()
//        {
//            AppSettings.TestSet.DynamicData.Clear();
//            #region PARAMETERS
//            #region P0100_00_SELECT_SISTEMAS_Query1

//            var q0 = new DynamicData();
//            q0.AddDynamic(new Dictionary<string, string>{
//                { "SISTEMA_DTMOVABE" , "2024-07-19"},
//                { "SISTEMA_DTMOVABE_1" , "2024-10-29"},
//                { "SISTEMA_DTMOVABE_10" , "2024-07-09"},
//            });
//            AppSettings.TestSet.DynamicData.Add("P0100_00_SELECT_SISTEMAS_Query1", q0);

//            #endregion

//            #region P0200_00_SELECT_RELATORI_Query1

//            var q1 = new DynamicData();
//            q1.AddDynamic(new Dictionary<string, string>{
//                { "RELATORI_DATA_SOLICITACAO_0" , "2024-07-19"},
//                { "RELATORI_DATA_SOLICITACAO" , "2024-07-20"},
//            });
//            AppSettings.TestSet.DynamicData.Add("P0200_00_SELECT_RELATORI_Query1", q1);

//            #endregion

//            #region VA0197B_CMOVIMVGA

//            var q2 = new DynamicData();
//            q2.AddDynamic(new Dictionary<string, string>{
//                { "MOVIMVGA_NUM_CERTIFICADO" , "10000258004"},
//                { "PROPVA_NUM_CERTIFICADO" , "8900000246"},
//                { "PROPVA_NUM_APOLICE" , "93010000890"},
//                { "PROPVA_CODSUBES" , "1"},
//                { "PROPVA_OCORHIST" , "17"},
//                { "PROPVA_SITUACAO" , "4"},
//                { "PROPVA_CODPRODU" , "9304"},
//                { "PROPVA_OPCAO_COBER" , ""},
//                { "PRODVG_NOMPRODU" , "PREFERENCIAL VIDA             "},
//                { "PRODVG_ORIG_PRODU" , "AVERB     "},
//                { "PRODVG_COD_RUBRICA" , "2"},
//            });
//            q2.AddDynamic(new Dictionary<string, string>{
//                { "MOVIMVGA_NUM_CERTIFICADO" , "10000258004"},
//                { "PROPVA_NUM_CERTIFICADO" , "8900000246"},
//                { "PROPVA_NUM_APOLICE" , "93010000890"},
//                { "PROPVA_CODSUBES" , "1"},
//                { "PROPVA_OCORHIST" , "17"},
//                { "PROPVA_SITUACAO" , "4"},
//                { "PROPVA_CODPRODU" , "9304"},
//                { "PROPVA_OPCAO_COBER" , ""},
//                { "PRODVG_NOMPRODU" , "PREFERENCIAL VIDA             "},
//                { "PRODVG_ORIG_PRODU" , "AVERB     "},
//                { "PRODVG_COD_RUBRICA" , "2"},
//            });
//            AppSettings.TestSet.DynamicData.Add("VA0197B_CMOVIMVGA", q2);

//            #endregion

//            #region P1000_00_PROCESSA_REGISTRO_Query1

//            var q3 = new DynamicData();
//            q3.AddDynamic(new Dictionary<string, string>{
//                { "COMFEDCA_DATA_MOVIMENTO" , "2020-01-01"}
//            });
//            AppSettings.TestSet.DynamicData.Add("P1000_00_PROCESSA_REGISTRO_Query1", q3);

//            #endregion

//            #region P1000_00_PROCESSA_REGISTRO_Query2

//            var q4 = new DynamicData();
//            q4.AddDynamic(new Dictionary<string, string>{
//                { "WHOST_QTTITCAP" , "1"},
//                { "WHOST_VLCUSTCAP" , "0.43"},
//                { "WHOST_VLTITCAP" , "10000.00"},
//            });
//            q4.AddDynamic(new Dictionary<string, string>{
//                { "WHOST_QTTITCAP" , "1"},
//                { "WHOST_VLCUSTCAP" , "0.43"},
//                { "WHOST_VLTITCAP" , "10000.00"},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1000_00_PROCESSA_REGISTRO_Query2", q4);

//            #endregion

//            #region P1400_00_SELECT_HISCOBPR_Query1

//            var q5 = new DynamicData();
//            q5.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_NUM_CERTIFICADO" , "32404290000265"},
//                { "HISCOBPR_OCORR_HISTORICO" , "1"},
//                { "HISCOBPR_DATA_INIVIGENCIA" , "0001-01-01"},
//                { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
//                { "HISCOBPR_IMPSEGUR" , "0"},
//                { "HISCOBPR_QUANT_VIDAS" , "1"},
//                { "HISCOBPR_IMPSEGIND" , "0"},
//                { "HISCOBPR_COD_OPERACAO" , "106"},
//                { "HISCOBPR_OPCAO_COBERTURA" , "A"},
//                { "HISCOBPR_IMP_MORNATU" , "12"},
//                { "HISCOBPR_IMPMORACID" , "14"},
//                { "HISCOBPR_IMPINVPERM" , "0"},
//                { "HISCOBPR_IMPAMDS" , "0"},
//                { "HISCOBPR_IMPDH" , "0"},
//                { "HISCOBPR_IMPDIT" , "0"},
//                { "HISCOBPR_VLPREMIO" , "52"},
//                { "HISCOBPR_PRMVG" , "52"},
//                { "HISCOBPR_PRMAP" , "34"},
//                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "52000"},
//                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "20"},
//                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "20"},
//                { "HISCOBPR_IMPSEGCDG" , "123"},
//                { "HISCOBPR_VLCUSTCDG" , "1234"},
//                { "HISCOBPR_COD_USUARIO" , "PF0601B "},
//                { "HISCOBPR_TIMESTAMP" , "2001-06-08 11:10:50.351"},
//                { "HISCOBPR_IMPSEGAUXF" , ""},
//                { "HISCOBPR_VLCUSTAUXF" , ""},
//                { "HISCOBPR_PRMDIT" , ""},
//                { "HISCOBPR_QTMDIT" , ""},
//            });
//            q5.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_NUM_CERTIFICADO" , "32404290000265"},
//                { "HISCOBPR_OCORR_HISTORICO" , "1"},
//                { "HISCOBPR_DATA_INIVIGENCIA" , "0001-01-01"},
//                { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
//                { "HISCOBPR_IMPSEGUR" , "0"},
//                { "HISCOBPR_QUANT_VIDAS" , "1"},
//                { "HISCOBPR_IMPSEGIND" , "0"},
//                { "HISCOBPR_COD_OPERACAO" , "106"},
//                { "HISCOBPR_OPCAO_COBERTURA" , "A"},
//                { "HISCOBPR_IMP_MORNATU" , "12"},
//                { "HISCOBPR_IMPMORACID" , "14"},
//                { "HISCOBPR_IMPINVPERM" , "0"},
//                { "HISCOBPR_IMPAMDS" , "0"},
//                { "HISCOBPR_IMPDH" , "0"},
//                { "HISCOBPR_IMPDIT" , "0"},
//                { "HISCOBPR_VLPREMIO" , "52"},
//                { "HISCOBPR_PRMVG" , "52"},
//                { "HISCOBPR_PRMAP" , "34"},
//                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "52000"},
//                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "20"},
//                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "20"},
//                { "HISCOBPR_IMPSEGCDG" , "123"},
//                { "HISCOBPR_VLCUSTCDG" , "1234"},
//                { "HISCOBPR_COD_USUARIO" , "PF0601B "},
//                { "HISCOBPR_TIMESTAMP" , "2001-06-08 11:10:50.351"},
//                { "HISCOBPR_IMPSEGAUXF" , ""},
//                { "HISCOBPR_VLCUSTAUXF" , ""},
//                { "HISCOBPR_PRMDIT" , ""},
//                { "HISCOBPR_QTMDIT" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1400_00_SELECT_HISCOBPR_Query1", q5);

//            #endregion

//            #region P1500_INSERT_HISCOBPR_Update1

//            var q6 = new DynamicData();
//            q6.AddDynamic(new Dictionary<string, string>{
//                { "PROPVA_NUM_CERTIFICADO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("P1500_INSERT_HISCOBPR_Update1", q6);

//            #endregion

//            #region P1500_INSERT_HISCOBPR_Insert2

//            var q7 = new DynamicData();
//            q7.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_NUM_CERTIFICADO" , ""},
//                { "HISCOBPR_OCORR_HISTORICO" , ""},
//                { "SISTEMA_DTMOVABE" , ""},
//                { "HISCOBPR_IMPSEGUR" , ""},
//                { "HISCOBPR_QUANT_VIDAS" , ""},
//                { "HISCOBPR_IMPSEGIND" , ""},
//                { "HISCOBPR_COD_OPERACAO" , ""},
//                { "HISCOBPR_OPCAO_COBERTURA" , ""},
//                { "HISCOBPR_IMP_MORNATU" , ""},
//                { "HISCOBPR_IMPMORACID" , ""},
//                { "HISCOBPR_IMPINVPERM" , ""},
//                { "HISCOBPR_IMPAMDS" , ""},
//                { "HISCOBPR_IMPDH" , ""},
//                { "HISCOBPR_IMPDIT" , ""},
//                { "HISCOBPR_VLPREMIO" , ""},
//                { "HISCOBPR_PRMVG" , ""},
//                { "HISCOBPR_PRMAP" , ""},
//                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
//                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
//                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
//                { "HISCOBPR_IMPSEGCDG" , ""},
//                { "HISCOBPR_VLCUSTCDG" , ""},
//                { "HISCOBPR_COD_USUARIO" , ""},
//                { "HISCOBPR_TIMESTAMP" , ""},
//                { "HISCOBPR_IMPSEGAUXF" , ""},
//                { "HISCOBPR_VLCUSTAUXF" , ""},
//                { "HISCOBPR_PRMDIT" , ""},
//                { "HISCOBPR_QTMDIT" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1500_INSERT_HISCOBPR_Insert2", q7);

//            #endregion

//            #region P1500_INSERT_HISCOBPR_Update3

//            var q8 = new DynamicData();
//            q8.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_OCORR_HISTORICO" , ""},
//                { "PROPVA_NUM_CERTIFICADO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1500_INSERT_HISCOBPR_Update3", q8);

//            #endregion

//            #region P1600_00_INSERT_COMFEDCA_Insert1

//            var q9 = new DynamicData();
//            q9.AddDynamic(new Dictionary<string, string>{
//                { "MOVIMVGA_NUM_CERTIFICADO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("P1600_00_INSERT_COMFEDCA_Insert1", q9);

//            #endregion

//            #region R5000_00_SELECT_EMP_CAP_Query1

//            var q10 = new DynamicData();
//            q10.AddDynamic(new Dictionary<string, string>{
//                { "PROD_COD_EMPRESA" , "10"},
//                { "PARM_COD_EMPR_CAP" , "1"},
//            });
//            q10.AddDynamic(new Dictionary<string, string>{
//                { "PROD_COD_EMPRESA" , "10"},
//                { "PARM_COD_EMPR_CAP" , "1"},
//            });
//            AppSettings.TestSet.DynamicData.Add("R5000_00_SELECT_EMP_CAP_Query1", q10);

//            #endregion

//            #region P8000_00_UPDATE_RELATORI_Update1

//            var q11 = new DynamicData();
//            q11.AddDynamic(new Dictionary<string, string>{
//                { "SISTEMA_DTMOVABE" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("P8000_00_UPDATE_RELATORI_Update1", q11);

//            #endregion

//            #endregion

//            VG0105S_Tests.Load_Parameters();
//        }

//        [Theory]
//        [InlineData("Saida_VA0197B_1.txt", "Saida_VA0197B_2.txt", "Saida_VA0197B_3.txt")]
//        public static void VA0197B_Tests_Theory(string ARQ_ERROS_BU_FILE_NAME_P, string ARQ_ERROS_TI_FILE_NAME_P, string ARQ_COMPRAS_FILE_NAME_P)
//        {
//            lock (AppSettings.TestSet._lock)
//            {
//                AppSettings.TestSet.IsTest = true;
//                Load_Parameters();

//                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
//                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
//                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

//                #region VARIAVEIS_TESTE
//                #endregion
//                var program = new VA0197B();

//                var parametros = new VA0197B_LK_PARAMETROS();
//                parametros.LK_DATA_FIM.Value = "9999-12-31";
//                parametros.LK_DATA_INI.Value = "2024-12-31";
//                parametros.LK_OPERACAO.Value = "COMMIT";
//                parametros.LK_TRACE.Value = "TRACE ON";

//                program.Execute(parametros, ARQ_ERROS_BU_FILE_NAME_P, ARQ_ERROS_TI_FILE_NAME_P, ARQ_COMPRAS_FILE_NAME_P);

//                Assert.True(true);

//                //P1600_00_INSERT_COMFEDCA_Insert1
//                var envList3 = AppSettings.TestSet.DynamicData["P1600_00_INSERT_COMFEDCA_Insert1"].DynamicList;
//                Assert.True(envList3?.Count > 1);
//                Assert.True(envList3[1].TryGetValue("MOVIMVGA_NUM_CERTIFICADO", out var val7r) && val7r.Contains("10000258004"));

//                //P1500_INSERT_HISCOBPR_Insert2
//                var envList4 = AppSettings.TestSet.DynamicData["P1500_INSERT_HISCOBPR_Insert2"].DynamicList;
//                Assert.True(envList4?.Count > 1);
//                Assert.True(envList4[1].TryGetValue("HISCOBPR_NUM_CERTIFICADO", out var val8r) && val8r.Contains("032404290000265"));

//                //P1500_INSERT_HISCOBPR_Update3
//                var envList1 = AppSettings.TestSet.DynamicData["P1500_INSERT_HISCOBPR_Update3"].DynamicList;
//                Assert.True(envList1[1].TryGetValue("PROPVA_NUM_CERTIFICADO", out var val1r) && val1r.Contains("8900000246"));

//                //P1500_INSERT_HISCOBPR_Update1
//                var envList2 = AppSettings.TestSet.DynamicData["P1500_INSERT_HISCOBPR_Update1"].DynamicList;
//                Assert.True(envList2[1].TryGetValue("PROPVA_NUM_CERTIFICADO", out var val100r) && val100r.Contains("8900000246"));


//            }
//        }

//            [Theory]
//            [InlineData("Sem_arquivo", "Sem_arquivo", "Sem_arquivo")]
//            public static void VA0197B_Tests_TheoryErro99(string ARQ_ERROS_BU_FILE_NAME_P, string ARQ_ERROS_TI_FILE_NAME_P, string ARQ_COMPRAS_FILE_NAME_P)
//            {
//                lock (AppSettings.TestSet._lock)
//                {
//                    AppSettings.TestSet.IsTest = true;
//                    Load_Parameters();

//                    //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
//                    //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
//                    //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

//                    #region VARIAVEIS_TESTE
//                    #endregion
//                    var program = new VA0197B();

//                    var parametros = new VA0197B_LK_PARAMETROS();
//                    parametros.LK_DATA_FIM.Value = "9999-12-31";
//                    parametros.LK_DATA_INI.Value = "9999-12-31";
//                    parametros.LK_OPERACAO.Value = "teste";
//                    parametros.LK_TRACE.Value = "TRACE ON";

//                    program.Execute(parametros, ARQ_ERROS_BU_FILE_NAME_P, ARQ_ERROS_TI_FILE_NAME_P, ARQ_COMPRAS_FILE_NAME_P);

//                    Assert.True(program.RETURN_CODE == 99);

//                }
//            }
         
//    }
//}