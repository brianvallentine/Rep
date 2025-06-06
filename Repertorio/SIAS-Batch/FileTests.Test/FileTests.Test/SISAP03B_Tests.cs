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
using static Code.SISAP03B;
using static Code.SISAP03B.SISAP03B_LK_IDLG_REGISTRO_SINISTRO;
using static Code.SISAP03B.SISAP03B_LK_IDLG_REGISTRO_SINISTRO.SISAP03B_LK_IDLG_DADOS_ENTRADA;

namespace FileTests.Test
{
    [Collection("SISAP03B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SISAP03B_Tests
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

            #region R0020_CRITICA_LINKAGE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_CRITICA_LINKAGE_DB_SELECT_1_Query1", q1);

            #endregion

            #region RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE100_NUM_OCORR_MOVTO" , ""}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE100_NUM_OCORR_MOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0020_CRITICA_LINKAGE_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_CRITICA_LINKAGE_DB_SELECT_2_Query1", q3);

            #endregion

            #region R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
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
                { "GE098_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GE097_NUM_OCORR_MOVTO" , ""},
                { "GE097_NUM_CHEQUE_INTERNO" , ""},
                { "GE097_NSAS" , ""},
                { "GE097_IDE_SISTEMA" , ""},
                { "GE097_DTH_CADASTRAMENTO" , ""},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "GE097_NUM_OCORR_MOVTO" , ""},
                { "GE097_NUM_CHEQUE_INTERNO" , ""},
                { "GE097_NSAS" , ""},
                { "GE097_IDE_SISTEMA" , ""},
                { "GE097_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE094_NUM_APOLICE" , ""},
                { "GE094_NUM_ENDOSSO" , ""},
                { "GE094_NUM_PARCELA" , ""},
                { "GE094_COD_CONVENIO" , ""},
                { "GE094_NSAS" , ""},
                { "GE094_NUM_OCORR_MOVTO" , ""},
                { "GE094_IDE_SISTEMA" , ""},
                { "GE094_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_REQUISICAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void SISAP03B_Tests_Fact()
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
                var program = new SISAP03B();
                
                var param = new SISAP03B_LK_IDLG_REGISTRO_SINISTRO()
                {
                    LK_IDLG_DADOS_ENTRADA = new SISAP03B_LK_IDLG_DADOS_ENTRADA()
                    {
                        LK_IDLG_CODIGO_SINISTRO = new StringBasis(new PIC("X", "40", "X(40)."), @"S1234567890123|56789|1234|P|1|0"),
                        LK_IDLG_DADOS_RETORNO = new SISAP03B_LK_IDLG_DADOS_RETORNO() { },
                    }
                };

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO == 0);
            }
        }
        [Fact]
        public static void SISAP03B_Tests_Erro()
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
                AppSettings.TestSet.DynamicData.Remove("R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1");

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "GE097_NUM_OCORR_MOVTO" , ""},
                { "GE097_NUM_CHEQUE_INTERNO" , ""},
                { "GE097_NSAS" , ""},
                { "GE097_IDE_SISTEMA" , ""},
                { "GE097_DTH_CADASTRAMENTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1", q5);

                #endregion
                var program = new SISAP03B();

                var param = new SISAP03B_LK_IDLG_REGISTRO_SINISTRO()
                {
                    LK_IDLG_DADOS_ENTRADA = new SISAP03B_LK_IDLG_DADOS_ENTRADA()
                    {
                        LK_IDLG_CODIGO_SINISTRO = new StringBasis(new PIC("X", "40", "X(40)."), @"S1234567890123|56789|1234|P|1|0"),
                        LK_IDLG_DADOS_RETORNO = new SISAP03B_LK_IDLG_DADOS_RETORNO() { },
                    }
                };

                program.Execute(param);

                Assert.True(program.LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO == 2);
            }
        }
        [Fact]
        public static void SISAP03B_Tests_Erro2()
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
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                var program = new SISAP03B();

                var param = new SISAP03B_LK_IDLG_REGISTRO_SINISTRO()
                {
                    LK_IDLG_DADOS_ENTRADA = new SISAP03B_LK_IDLG_DADOS_ENTRADA()
                    {
                        LK_IDLG_CODIGO_SINISTRO = new StringBasis(new PIC("X", "40", "X(40)."), @"S1234567890123|56789|1234|P|1|0"),
                        LK_IDLG_DADOS_RETORNO = new SISAP03B_LK_IDLG_DADOS_RETORNO() { },
                    }
                };

                program.Execute(param);

                Assert.True(program.LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO == 1);
            }
        }
    }
}