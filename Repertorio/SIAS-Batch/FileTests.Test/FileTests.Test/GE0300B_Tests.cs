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
using static Code.GE0300B;

namespace FileTests.Test
{
    [Collection("GE0300B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0300B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                { "HOST_CURRENT_DATE" , ""},
                { "HOST_TIMESTAMP" , ""},
                { "HOST_CURRENT_TIME" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GE099_NUM_OCORR_MOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE096_NUM_OCORR_MOVTO" , ""},
                { "GE096_NUM_APOLICE" , ""},
                { "GE096_NUM_ENDOSSO" , ""},
                { "GE096_NUM_PARCELA" , ""},
                { "GE096_NUM_NOSSO_TITULO" , ""},
                { "GE096_NUM_OCORR_HISTORICO" , ""},
                { "GE096_IDE_SISTEMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1", q2);

            #endregion

            #region R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE098_NUM_OCORR_MOVTO" , ""},
                { "GE098_NUM_APOL_SINISTRO" , ""},
                { "GE098_COD_OPERACAO" , ""},
                { "GE098_NUM_OCORR_HISTORICO" , ""},
                { "GE098_NUM_RESSARC" , ""},
                { "GE098_SEQ_RESSARC" , ""},
                { "GE098_NUM_PARCELA" , ""},
                { "GE098_NUM_NOSSO_TITULO" , ""},
                { "GE098_NSAS" , ""},
                { "GE098_IDE_SISTEMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE097_NUM_OCORR_MOVTO" , ""},
                { "GE097_NUM_CHEQUE_INTERNO" , ""},
                { "GE097_NSAS" , ""},
                { "GE097_IDE_SISTEMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1", q4);

            #endregion

            #region R1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GE094_NUM_APOLICE" , ""},
                { "GE094_NUM_ENDOSSO" , ""},
                { "GE094_NUM_PARCELA" , ""},
                { "GE094_COD_CONVENIO" , ""},
                { "GE094_NSAS" , ""},
                { "GE094_NUM_OCORR_MOVTO" , ""},
                { "GE094_IDE_SISTEMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R1060_INS_VIDA_SAP_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE095_NUM_OCORR_MOVTO" , ""},
                { "GE095_NUM_CERTIFICADO" , ""},
                { "GE095_NUM_PARCELA" , ""},
                { "GE095_NUM_NOSSO_TITULO" , ""},
                { "GE095_NSAS" , ""},
                { "GE095_IDE_SISTEMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1060_INS_VIDA_SAP_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GE113_NUM_OCORR_MOVTO" , ""},
                { "GE113_CHR_USO_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE099_NUM_OCORR_MOVTO" , ""},
                { "GE099_DTH_MOVIMENTO" , ""},
                { "GE099_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R1300_INS_CONTROLE_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "GE100_NUM_OCORR_MOVTO" , ""},
                { "GE100_COD_IDLG" , ""},
                { "GE100_DTA_MOVIMENTO_LEGADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_INS_CONTROLE_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GE102_NUM_OCORR_MOVTO" , ""},
                { "GE102_COD_IDLG" , ""},
                { "GE102_DTH_MOVIMENTO" , ""},
                { "GE102_DTH_CADASTRAMENTO" , ""},
                { "GE102_NUM_LOTE_SAP" , ""},
                { "GE102_TXT_REG_SAP" , ""},
                { "GE102_COD_ORIGEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1", q10);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0300B_Tests_Fact_NumEstrutura1()
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
                var program = new GE0300B();
                var param = new GE0300B_REGISTRO_LINKAGE_GE0300B();
                param.LK_GE0300B_REGISTRO.Value = "ABC\0123\0GHI";
                param.LK_GE0300B_FUNCAO.Value = 1;
                param.LK_GE0300B_IDE_SISTEMA.Value = "IDE SISTEMA";
                param.LK_GE0300B_CHR_USO_EMPRESA.Value = "CHR_USO_EMPRESA";
                param.LK_GE0300B_COD_OPERACAO.Value = 1;
                param.LK_GE0300B_NUM_ESTRUTURA.Value = 1;
                param.LK_GE0300B_NUM_NOSSO_TITULO.Value = 10;
                program.Execute(param);

                var envList = AppSettings.TestSet.DynamicData["R1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("GE096_IDE_SISTEMA", out var valor) && valor == "ID");

                var envList1 = AppSettings.TestSet.DynamicData["R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("GE113_CHR_USO_EMPRESA", out valor) && valor.Contains("CHR_USO_EMPRESA"));

                var envList2 = AppSettings.TestSet.DynamicData["R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("GE099_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList3 = AppSettings.TestSet.DynamicData["R1300_INS_CONTROLE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("GE100_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList4 = AppSettings.TestSet.DynamicData["R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("GE102_DTH_CADASTRAMENTO", out valor) && valor == "9999-12-31-01.01.01.010101");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void GE0300B_Tests_Fact_NumEstrutura2()
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
                var program = new GE0300B();
                var param = new GE0300B_REGISTRO_LINKAGE_GE0300B();
                param.LK_GE0300B_REGISTRO.Value = "ABC\0123\0GHI";
                param.LK_GE0300B_FUNCAO.Value = 1;
                param.LK_GE0300B_IDE_SISTEMA.Value = "IDE SISTEMA";
                param.LK_GE0300B_CHR_USO_EMPRESA.Value = "CHR_USO_EMPRESA";
                param.LK_GE0300B_COD_OPERACAO.Value = 1;
                param.LK_GE0300B_NUM_ESTRUTURA.Value = 2;
                param.LK_GE0300B_NUM_NOSSO_TITULO.Value = 10;
                param.LK_GE0300B_NUM_APOL_SINISTRO.Value = 10;
                param.LK_GE0300B_NUM_OCORR_HISTORICO.Value = 10;
                param.LK_GE0300B_NUM_RESSARC.Value = 10;
                param.LK_GE0300B_NUM_PARCELA.Value = 10;
                param.LK_GE0300B_NSAS.Value = 10;
                program.Execute(param);

                var envList = AppSettings.TestSet.DynamicData["R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("GE098_IDE_SISTEMA", out var valor) && valor == "ID");

                var envList1 = AppSettings.TestSet.DynamicData["R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("GE113_CHR_USO_EMPRESA", out valor) && valor.Contains("CHR_USO_EMPRESA"));

                var envList2 = AppSettings.TestSet.DynamicData["R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("GE099_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList3 = AppSettings.TestSet.DynamicData["R1300_INS_CONTROLE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("GE100_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList4 = AppSettings.TestSet.DynamicData["R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("GE102_DTH_CADASTRAMENTO", out valor) && valor == "9999-12-31-01.01.01.010101");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void GE0300B_Tests_Fact_NumEstrutura3()
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
                var program = new GE0300B();
                var param = new GE0300B_REGISTRO_LINKAGE_GE0300B();
                param.LK_GE0300B_REGISTRO.Value = "ABC\0123\0GHI";
                param.LK_GE0300B_FUNCAO.Value = 1;
                param.LK_GE0300B_IDE_SISTEMA.Value = "IDE SISTEMA";
                param.LK_GE0300B_CHR_USO_EMPRESA.Value = "CHR_USO_EMPRESA";
                param.LK_GE0300B_COD_OPERACAO.Value = 1;
                param.LK_GE0300B_NUM_ESTRUTURA.Value = 3;
                param.LK_GE0300B_NUM_NOSSO_TITULO.Value = 10;
                param.LK_GE0300B_NUM_CHEQUE_INTERNO.Value = 1;
                program.Execute(param);

                var envList = AppSettings.TestSet.DynamicData["R1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("GE097_IDE_SISTEMA", out var valor) && valor == "ID");

                var envList1 = AppSettings.TestSet.DynamicData["R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("GE113_CHR_USO_EMPRESA", out valor) && valor.Contains("CHR_USO_EMPRESA"));

                var envList2 = AppSettings.TestSet.DynamicData["R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("GE099_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList3 = AppSettings.TestSet.DynamicData["R1300_INS_CONTROLE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("GE100_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList4 = AppSettings.TestSet.DynamicData["R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("GE102_DTH_CADASTRAMENTO", out valor) && valor == "9999-12-31-01.01.01.010101");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void GE0300B_Tests_Fact_NumEstrutura4()
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
                var program = new GE0300B();
                var param = new GE0300B_REGISTRO_LINKAGE_GE0300B();
                param.LK_GE0300B_REGISTRO.Value = "ABC\0123\0GHI";
                param.LK_GE0300B_FUNCAO.Value = 1;
                param.LK_GE0300B_IDE_SISTEMA.Value = "IDE SISTEMA";
                param.LK_GE0300B_CHR_USO_EMPRESA.Value = "CHR_USO_EMPRESA";
                param.LK_GE0300B_COD_OPERACAO.Value = 1;
                param.LK_GE0300B_NUM_ESTRUTURA.Value = 4;
                param.LK_GE0300B_NUM_NOSSO_TITULO.Value = 10;
                param.LK_GE0300B_NUM_APOL_SINISTRO.Value = 10;
                param.LK_GE0300B_NUM_OCORR_HISTORICO.Value = 10;
                param.LK_GE0300B_NUM_RESSARC.Value = 10;
                param.LK_GE0300B_NUM_PARCELA.Value = 10;
                param.LK_GE0300B_NSAS.Value = 10;
                param.LK_GE0300B_NUM_APOLICE.Value = 10;
                program.Execute(param);

                var envList = AppSettings.TestSet.DynamicData["R1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("GE094_IDE_SISTEMA", out var valor) && valor == "ID");

                var envList1 = AppSettings.TestSet.DynamicData["R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("GE113_CHR_USO_EMPRESA", out valor) && valor.Contains("CHR_USO_EMPRESA"));

                var envList2 = AppSettings.TestSet.DynamicData["R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("GE099_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList3 = AppSettings.TestSet.DynamicData["R1300_INS_CONTROLE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("GE100_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList4 = AppSettings.TestSet.DynamicData["R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("GE102_DTH_CADASTRAMENTO", out valor) && valor == "9999-12-31-01.01.01.010101");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void GE0300B_Tests_Fact_NumEstrutura5()
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
                var program = new GE0300B();
                var param = new GE0300B_REGISTRO_LINKAGE_GE0300B();
                param.LK_GE0300B_REGISTRO.Value = "ABC\0123\0GHI";
                param.LK_GE0300B_FUNCAO.Value = 1;
                param.LK_GE0300B_IDE_SISTEMA.Value = "IDE SISTEMA";
                param.LK_GE0300B_CHR_USO_EMPRESA.Value = "CHR_USO_EMPRESA";
                param.LK_GE0300B_COD_OPERACAO.Value = 1;
                param.LK_GE0300B_NUM_ESTRUTURA.Value = 5;
                param.LK_GE0300B_NUM_NOSSO_TITULO.Value = 10;
                param.LK_GE0300B_NUM_APOL_SINISTRO.Value = 10;
                param.LK_GE0300B_NUM_OCORR_HISTORICO.Value = 10;
                param.LK_GE0300B_NUM_RESSARC.Value = 10;
                param.LK_GE0300B_NUM_PARCELA.Value = 10;
                param.LK_GE0300B_NSAS.Value = 10;
                param.LK_GE0300B_NUM_APOLICE.Value = 10;
                param.LK_GE0300B_NUM_CERTIFICADO.Value = 10;
                program.Execute(param);

                var envList = AppSettings.TestSet.DynamicData["R1060_INS_VIDA_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("GE095_IDE_SISTEMA", out var valor) && valor == "ID");

                var envList1 = AppSettings.TestSet.DynamicData["R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("GE113_CHR_USO_EMPRESA", out valor) && valor.Contains("CHR_USO_EMPRESA"));

                var envList2 = AppSettings.TestSet.DynamicData["R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("GE099_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList3 = AppSettings.TestSet.DynamicData["R1300_INS_CONTROLE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("GE100_NUM_OCORR_MOVTO", out valor) && valor == "000000000000000000");

                var envList4 = AppSettings.TestSet.DynamicData["R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("GE102_DTH_CADASTRAMENTO", out valor) && valor == "9999-12-31-01.01.01.010101");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void GE0300B_Tests_SemDados()
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

                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q4);

                #endregion
                var program = new GE0300B();
                var param = new GE0300B_REGISTRO_LINKAGE_GE0300B();
                program.Execute(param);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}