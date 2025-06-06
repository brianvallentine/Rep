//using System;
//using IA_ConverterCommons;
//using System.Collections.Generic;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using System.Linq;
//using _ = IA_ConverterCommons.Statements;
//using DB = IA_ConverterCommons.DatabaseBasis;
//using Xunit;
//using Code;
//using static Code.VA0198B;
//using System.IO;

//namespace FileTests.Test
//{
//    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
//    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
//    public class VA0198B_Tests
//    {
//        //é de extrema importancia que este método seja modificado com cautela, 
//        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
//        private static void Load_Parameters()
//        {
//            AppSettings.TestSet.DynamicData.Clear();
//            #region PARAMETERS
//            #region VA0198B_C01_RESULT


//            #region SEGUROS_SPBVG012_Call1

//            var q10 = new DynamicData();
//            q10.AddDynamic(new Dictionary<string, string>{
//                { "LK_NUM_PLANO_FC12" , ""},
//                { "LK_NUM_PROPOSTA_FC12" , ""},
//                { "LK_COD_RAMO_FC12" , ""},
//                { "LK_TRACE_FC12" , ""},
//                { "LK_OUT_COD_RET_FC12" , ""},
//                { "LK_OUT_SQLCODE_FC12" , ""},
//                { "LK_OUT_MENSAGEM_FC12" , ""},
//                { "LK_OUT_SQLERRMC_FC12" , ""},
//                { "LK_OUT_SQLSTATE_FC12" , ""},
//            }, new SQLCA(466));
//            AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBVG012_Call1", q10);

//            #endregion
//            var q0 = new DynamicData();
//            q0.AddDynamic(new Dictionary<string, string>{
//                { "WF_NUM_PLANO" , "101"},
//                { "WF_NUM_SERIE" , "10"},
//                { "WF_NUM_TITULO" , "123564"},
//                { "WF_COD_STA_TITULO" , "BAI"},
//                { "WF_COD_SUB_STATUS" , "RST"},
//                { "WF_DTH_ATIVACAO" , "2020-01-01"},
//                { "WF_DTH_CADUCACAO" , "2020-01-01"},
//                { "WF_DTH_CRIACAO" , "2020-01-01"},
//                { "WF_DTH_FIM_VIGENCIA" , "2027-01-01"},
//                { "WF_DTH_INI_SORTEIO" , "2020-01-01"},
//                { "WF_DTH_INI_VIGENCIA" , "2021-01-01"},
//                { "WF_DTH_SUSPENSAO" , "2023-01-01"},
//                { "WF_IND_DV" , "1"},
//                { "WF_VLR_MENSALIDADE" , "123000"},
//                { "WF_NUM_PROPOSTA" , "1233434"},
//                { "WF_NUM_MOD_PLANO" , "2"},
//                { "WF_DES_COMBINACAO" , "1"},
//            }); 
//            q0.AddDynamic(new Dictionary<string, string>{
//                { "WF_NUM_PLANO" , "101"},
//                { "WF_NUM_SERIE" , "10"},
//                { "WF_NUM_TITULO" , "123564"},
//                { "WF_COD_STA_TITULO" , "BAI"},
//                { "WF_COD_SUB_STATUS" , "RST"},
//                { "WF_DTH_ATIVACAO" , "2020-01-01"},
//                { "WF_DTH_CADUCACAO" , "2020-01-01"},
//                { "WF_DTH_CRIACAO" , "2020-01-01"},
//                { "WF_DTH_FIM_VIGENCIA" , "2027-01-01"},
//                { "WF_DTH_INI_SORTEIO" , "2020-01-01"},
//                { "WF_DTH_INI_VIGENCIA" , "2021-01-01"},
//                { "WF_DTH_SUSPENSAO" , "2023-01-01"},
//                { "WF_IND_DV" , "1"},
//                { "WF_VLR_MENSALIDADE" , "123000"},
//                { "WF_NUM_PROPOSTA" , "1233434"},
//                { "WF_NUM_MOD_PLANO" , "2"},
//                { "WF_DES_COMBINACAO" , "1"},
//            });
//            AppSettings.TestSet.DynamicData.Add("VA0198B_C01_RESULT", q0);

//            #endregion

//            #region VA0198B_C01_TITULOS

//            var q1 = new DynamicData();
//            q1.AddDynamic(new Dictionary<string, string>{
//                { "PROPVA_NUM_APOLICE" , "93010000890"},
//                { "PROPVA_NRCERTIF" , "8900000075"},
//                { "PROPVA_CODSUBES" , "3"},
//                { "PROPVA_CODPRODU" , "9304"},
//                { "FED_DATA_MOVIMENTO" , "1998-11-161"},
//            });
//            q1.AddDynamic(new Dictionary<string, string>{
//                { "PROPVA_NUM_APOLICE" , "93010000890"},
//                { "PROPVA_NRCERTIF" , "8900000075"},
//                { "PROPVA_CODSUBES" , "3"},
//                { "PROPVA_CODPRODU" , "9304"},
//                { "FED_DATA_MOVIMENTO" , "1998-11-161"},
//            });
//            AppSettings.TestSet.DynamicData.Add("VA0198B_C01_TITULOS", q1);

//            #endregion

//            #region P1400_00_SELECT_HISCOBPR_Query1

//            var q2 = new DynamicData();
//            q2.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_NUM_CERTIFICADO" , "211523067"},
//                { "HISCOBPR_OCORR_HISTORICO" , "1"},
//                { "HISCOBPR_DATA_INIVIGENCIA" , "1994-05-10"},
//                { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
//                { "HISCOBPR_IMPSEGUR" , "0"},
//                { "HISCOBPR_QUANT_VIDAS" , "1"},
//                { "HISCOBPR_IMPSEGIND" , "0"},
//                { "HISCOBPR_COD_OPERACAO" , "106"},
//                { "HISCOBPR_OPCAO_COBERTURA" , "L"},
//                { "HISCOBPR_IMP_MORNATU" , "0"},
//                { "HISCOBPR_IMPMORACID" , "0"},
//                { "HISCOBPR_IMPINVPERM" , "0"},
//                { "HISCOBPR_IMPAMDS" , "0"},
//                { "HISCOBPR_IMPDH" , "0"},
//                { "HISCOBPR_IMPDIT" , "12"},
//                { "HISCOBPR_VLPREMIO" , "12000"},
//                { "HISCOBPR_PRMVG" , "12120"},
//                { "HISCOBPR_PRMAP" , "1200"},
//                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "1"},
//                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "0"},
//                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "12000"},
//                { "HISCOBPR_IMPSEGCDG" , "0"},
//                { "HISCOBPR_VLCUSTCDG" , "0"},
//                { "HISCOBPR_COD_USUARIO" , "PF0601B "},
//                { "HISCOBPR_TIMESTAMP" , "2001-10-01 19:48:31.771"},
//                { "HISCOBPR_IMPSEGAUXF" , ""},
//                { "HISCOBPR_VLCUSTAUXF" , ""},
//                { "HISCOBPR_PRMDIT" , ""},
//                { "HISCOBPR_QTMDIT" , ""},
//            });
//            q2.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_NUM_CERTIFICADO" , "211523067"},
//                { "HISCOBPR_OCORR_HISTORICO" , "1"},
//                { "HISCOBPR_DATA_INIVIGENCIA" , "1994-05-10"},
//                { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
//                { "HISCOBPR_IMPSEGUR" , "0"},
//                { "HISCOBPR_QUANT_VIDAS" , "1"},
//                { "HISCOBPR_IMPSEGIND" , "0"},
//                { "HISCOBPR_COD_OPERACAO" , "106"},
//                { "HISCOBPR_OPCAO_COBERTURA" , "L"},
//                { "HISCOBPR_IMP_MORNATU" , "0"},
//                { "HISCOBPR_IMPMORACID" , "0"},
//                { "HISCOBPR_IMPINVPERM" , "0"},
//                { "HISCOBPR_IMPAMDS" , "0"},
//                { "HISCOBPR_IMPDH" , "0"},
//                { "HISCOBPR_IMPDIT" , "12"},
//                { "HISCOBPR_VLPREMIO" , "12000"},
//                { "HISCOBPR_PRMVG" , "12120"},
//                { "HISCOBPR_PRMAP" , "1200"},
//                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "1"},
//                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "0"},
//                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "12000"},
//                { "HISCOBPR_IMPSEGCDG" , "0"},
//                { "HISCOBPR_VLCUSTCDG" , "0"},
//                { "HISCOBPR_COD_USUARIO" , "PF0601B "},
//                { "HISCOBPR_TIMESTAMP" , "2001-10-01 19:48:31.771"},
//                { "HISCOBPR_IMPSEGAUXF" , ""},
//                { "HISCOBPR_VLCUSTAUXF" , ""},
//                { "HISCOBPR_PRMDIT" , ""},
//                { "HISCOBPR_QTMDIT" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1400_00_SELECT_HISCOBPR_Query1", q2);

//            #endregion

//            #region P1450_00_BUSCA_ULT_HISCOBPR_Query1

//            var q3 = new DynamicData();
//            q3.AddDynamic(new Dictionary<string, string>{
//                { "WS_OCORR_HISTORICO" , "71"}
//            });
//            AppSettings.TestSet.DynamicData.Add("P1450_00_BUSCA_ULT_HISCOBPR_Query1", q3);

//            #endregion

//            #region P1450_00_BUSCA_ULT_HISCOBPR_Query2

//            var q4 = new DynamicData();
//            q4.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_NUM_CERTIFICADO" , ""},
//                { "HISCOBPR_OCORR_HISTORICO" , ""},
//                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
//                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
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
//            AppSettings.TestSet.DynamicData.Add("P1450_00_BUSCA_ULT_HISCOBPR_Query2", q4);

//            #endregion

//            #region P1500_00_ATUALIZA_COBERPROP_Update1

//            var q5 = new DynamicData();
//            q5.AddDynamic(new Dictionary<string, string>{
//                { "WS_ONTEM" , ""},
//                { "HISCOBPR_NUM_CERTIFICADO" , ""},
//                { "HISCOBPR_OCORR_HISTORICO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1500_00_ATUALIZA_COBERPROP_Update1", q5);

//            #endregion

//            #region P1500_00_ATUALIZA_COBERPROP_Insert2

//            var q6 = new DynamicData();
//            q6.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_NUM_CERTIFICADO" , ""},
//                { "HISCOBPR_OCORR_HISTORICO" , ""},
//                { "WS_HOJE" , ""},
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
//                { "WHOST_QTTITCAP" , ""},
//                { "WHOST_VLTITCAP" , ""},
//                { "WHOST_VLCUSTCAP" , ""},
//                { "HISCOBPR_IMPSEGCDG" , ""},
//                { "HISCOBPR_VLCUSTCDG" , ""},
//                { "HISCOBPR_COD_USUARIO" , ""},
//                { "HISCOBPR_IMPSEGAUXF" , ""},
//                { "HISCOBPR_VLCUSTAUXF" , ""},
//                { "HISCOBPR_PRMDIT" , ""},
//                { "HISCOBPR_QTMDIT" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1500_00_ATUALIZA_COBERPROP_Insert2", q6);

//            #endregion

//            #region P1500_00_ATUALIZA_COBERPROP_Update3

//            var q7 = new DynamicData();
//            q7.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_OCORR_HISTORICO" , ""},
//                { "HISCOBPR_NUM_CERTIFICADO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1500_00_ATUALIZA_COBERPROP_Update3", q7);

//            #endregion

//            #region P1600_00_INSERT_COMFEDCA_Insert1

//            var q8 = new DynamicData();
//            q8.AddDynamic(new Dictionary<string, string>{
//                { "HISCOBPR_NUM_CERTIFICADO" , ""},
//                { "WHOST_SIT_REGISTRO" , ""},
//                { "WS_HOJE" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1600_00_INSERT_COMFEDCA_Insert1", q8);

//            #endregion

//            #region P1700_00_SELECT_PRODUTOVG_Query1

//            var q9 = new DynamicData();
//            q9.AddDynamic(new Dictionary<string, string>{
//                { "PRODUVG_ORIG_PRODU" , "EMPRE     "},
//                { "PRODUVG_COD_RUBRICA" , "10"},
//                { "WS_COD_RUBRICA_ANT" , "10"},
//                { "PRODUVG_NOME_PRODUTO" , "CAIXA SEGURO VIDA EMPRESARIAL "},
//                { "PRODUVG_COD_PRODUTO" , "9712"},
//            });
//            q9.AddDynamic(new Dictionary<string, string>{
//                { "PRODUVG_ORIG_PRODU" , "AVERB     "},
//                { "PRODUVG_COD_RUBRICA" , "10"},
//                { "WS_COD_RUBRICA_ANT" , "10"},
//                { "PRODUVG_NOME_PRODUTO" , "PREFERENCIAL VIDA             "},
//                { "PRODUVG_COD_PRODUTO" , "9304"},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1700_00_SELECT_PRODUTOVG_Query1", q9);

//            #endregion

//            #region P1904_BUSCAR_MIGRACAO_Query1

//            q10 = new DynamicData();
//            q10.AddDynamic(new Dictionary<string, string>{
//                { "RELATORI_NUM_CERTIFICADO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("P1904_BUSCAR_MIGRACAO_Query1", q10);

//            #endregion

//            #region P1921_00_SELECT_PLANOS_VA_Query1

//            var q11 = new DynamicData();
//            q11.AddDynamic(new Dictionary<string, string>{
//                { "WHOST_QTTITCAP" , "1"},
//                { "WHOST_VLCUSTCAP" , "0.43"},
//                { "WHOST_VLTITCAP" , "10000"},
//            });
//            q11.AddDynamic(new Dictionary<string, string>{
//                { "WHOST_QTTITCAP" , "1"},
//                { "WHOST_VLCUSTCAP" , "0.43"},
//                { "WHOST_VLTITCAP" , "10000"},
//            });
//            q11.AddDynamic(new Dictionary<string, string>{
//                { "WHOST_QTTITCAP" , "1"},
//                { "WHOST_VLCUSTCAP" , "0.43"},
//                { "WHOST_VLTITCAP" , "10000"},
//            });
//            AppSettings.TestSet.DynamicData.Add("P1921_00_SELECT_PLANOS_VA_Query1", q11);

//            #endregion

//            #region P2100_00_SELECT_VENCIMENTO_Query1

//            var q12 = new DynamicData();
//            q12.AddDynamic(new Dictionary<string, string>{
//                { "SEGVGAP_NUM_CERTIFICADO" , "790000003"}
//            });
//            q12.AddDynamic(new Dictionary<string, string>{
//                { "SEGVGAP_NUM_CERTIFICADO" , "790000003"}
//            });
//            q12.AddDynamic(new Dictionary<string, string>{
//                { "SEGVGAP_NUM_CERTIFICADO" , "790000003"}
//            });
//            AppSettings.TestSet.DynamicData.Add("P2100_00_SELECT_VENCIMENTO_Query1", q12);

//            #endregion

//            #region R5000_00_SELECT_EMP_CAP_Query1

//            var q13 = new DynamicData();
//            q13.AddDynamic(new Dictionary<string, string>{
//                { "PROD_COD_EMPRESA" , ""},
//                { "PARM_COD_EMPR_CAP" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R5000_00_SELECT_EMP_CAP_Query1", q13);

//            #endregion

//            #endregion
//        }

//        [Theory]
//        [InlineData("Saida_VA0198B_1.txt", "Saida_VA0198B.txt", "Saida_VA0198B_2.txt")]
//        public static void VA0198B_Tests_Theory(string ARQ_ERROS_BU_FILE_NAME_P, string ARQ_ERROS_TI_FILE_NAME_P, string ARQ_RENOV_FILE_NAME_P)
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
//                var program = new VA0198B();

//                var parametros = new VA0198B_LK_PARAMETROS();
//                parametros.LK_NRO_DIAS.Value = 5;
//                parametros.LK_OPERACAO.Value = "COMMIT";

//                program.Execute(parametros, ARQ_ERROS_BU_FILE_NAME_P, ARQ_ERROS_TI_FILE_NAME_P, ARQ_RENOV_FILE_NAME_P);

//                Assert.True(File.Exists(program.ARQ_ERROS_BU.FilePath));
//                Assert.True(new FileInfo(program.ARQ_ERROS_BU.FilePath)?.Length > 0);

//                //P1500_00_ATUALIZA_COBERPROP_Update1
//                var envList = AppSettings.TestSet.DynamicData["P1500_00_ATUALIZA_COBERPROP_Update1"].DynamicList;
//                Assert.True(envList[1].TryGetValue("HISCOBPR_NUM_CERTIFICADO", out var val5r) && val5r.Contains("8900000075"));
//                Assert.True(envList[1].TryGetValue("HISCOBPR_OCORR_HISTORICO", out var val7r) && val7r.Contains("1"));

//                //P1500_00_ATUALIZA_COBERPROP_Insert2
//                var envList1 = AppSettings.TestSet.DynamicData["P1500_00_ATUALIZA_COBERPROP_Insert2"].DynamicList;
//                Assert.True(envList1?.Count > 1);
//                Assert.True(envList1[1].TryGetValue("HISCOBPR_NUM_CERTIFICADO", out var val4or) && val4or.Contains("8900000075"));
//                Assert.True(envList1[1].TryGetValue("HISCOBPR_OCORR_HISTORICO", out var val3or) && val3or.Contains("2"));

//                //P1500_00_ATUALIZA_COBERPROP_Update3
//                var envList2 = AppSettings.TestSet.DynamicData["P1500_00_ATUALIZA_COBERPROP_Update3"].DynamicList;
//                Assert.True(envList2[1].TryGetValue("HISCOBPR_NUM_CERTIFICADO", out var val1r) && val1r.Contains("8900000075"));
//                Assert.True(envList2[1].TryGetValue("HISCOBPR_OCORR_HISTORICO", out var val2r) && val2r.Contains("2"));

//                //P1600_00_INSERT_COMFEDCA_Insert1
//                var envList3 = AppSettings.TestSet.DynamicData["P1600_00_INSERT_COMFEDCA_Insert1"].DynamicList;
//                Assert.True(envList3?.Count > 1);
//                Assert.True(envList3[1].TryGetValue("HISCOBPR_NUM_CERTIFICADO", out var val8or) && val8or.Contains("8900000075"));
//                Assert.True(envList3[1].TryGetValue("WHOST_SIT_REGISTRO", out var val9or) && val9or.Contains("R"));

//                Assert.True(program.RETURN_CODE == 00);

//                Assert.True(true);
//            }
//        }
//        [Theory]
//        [InlineData("Saida_VA0198B_3.txt", "Saida_VA0198B_1.txt", "Saida_VA0198B_4.txt")]
//        public static void VA0198B_Tests_Theory_SemTituloErro99(string ARQ_ERROS_BU_FILE_NAME_P, string ARQ_ERROS_TI_FILE_NAME_P, string ARQ_RENOV_FILE_NAME_P)
//        {
//            lock (AppSettings.TestSet._lock)
//            {
//                AppSettings.TestSet.IsTest = true;
//                Load_Parameters();

//                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
//                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
//                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

//                #region VARIAVEIS_TESTE

//                #region P1700_00_SELECT_PRODUTOVG_Query1

//                var q9 = new DynamicData();
//                AppSettings.TestSet.DynamicData.Remove("P1700_00_SELECT_PRODUTOVG_Query1");
//                q9.AddDynamic(new Dictionary<string, string>{
//                { "PRODUVG_ORIG_PRODU" , "EMPRE     "},
//                { "PRODUVG_COD_RUBRICA" , "10"},
//                { "WS_COD_RUBRICA_ANT" , "10"},
//                { "PRODUVG_NOME_PRODUTO" , "CAIXA SEGURO VIDA EMPRESARIAL "},
//                { "PRODUVG_COD_PRODUTO" , "9712"},
//            });
//                q9.AddDynamic(new Dictionary<string, string>{
//                { "PRODUVG_ORIG_PRODU" , "AVERB     "},
//                { "PRODUVG_COD_RUBRICA" , "10"},
//                { "WS_COD_RUBRICA_ANT" , "10"},
//                { "PRODUVG_NOME_PRODUTO" , "PREFERENCIAL VIDA             "},
//                { "PRODUVG_COD_PRODUTO" , "9304"},
//            });
//                AppSettings.TestSet.DynamicData.Add("P1700_00_SELECT_PRODUTOVG_Query1", q9);

//                #endregion

//                #region VA0198B_C01_TITULOS

//                var q1 = new DynamicData();
//                AppSettings.TestSet.DynamicData.Remove("VA0198B_C01_TITULOS");
//                q1.AddDynamic(new Dictionary<string, string>{
//                { "PROPVA_NUM_APOLICE" , "93010000890"},
//                { "PROPVA_NRCERTIF" , "8900000075"},
//                { "PROPVA_CODSUBES" , "3"},
//                { "PROPVA_CODPRODU" , "9304"},
//                { "FED_DATA_MOVIMENTO" , "1998-11-161"},
//            });
//                AppSettings.TestSet.DynamicData.Add("VA0198B_C01_TITULOS", q1);

//                #endregion
//                #endregion
//                var program = new VA0198B();

//                var parametros = new VA0198B_LK_PARAMETROS();
//                parametros.LK_NRO_DIAS.Value = 0;
//                parametros.LK_OPERACAO.Value = "Erro";

//                program.Execute(parametros, ARQ_ERROS_BU_FILE_NAME_P, ARQ_ERROS_TI_FILE_NAME_P, ARQ_RENOV_FILE_NAME_P);

//                Assert.True(program.RETURN_CODE == 99);


//            }
//        }
//    }
//}