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
using static Code.PF0720B;

namespace FileTests.Test
{
    [Collection("PF0720B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0720B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024/09/09"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "00013"}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "00005"}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1", q2);

            #endregion

            #region R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "00007"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "00002"},
                { "PROPOFID_CANAL_PROPOSTA" , "00003"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "00011"},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "00008"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "00003"},
                { "PROPOFID_CANAL_PROPOSTA" , "00004"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "00012"},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1", q4);

            #endregion

            #region R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_PREMIO_VG" , "00007"},
                { "PARCEVID_PREMIO_AP" , "00005"},
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0360_00_LER_PROP_VA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "00003"}
            });
            AppSettings.TestSet.DynamicData.Add("R0360_00_LER_PROP_VA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , "HUG"},
                { "ARQSIVPF_SISTEMA_ORIGEM" , "SIAS"},
                { "ARQSIVPF_NSAS_SIVPF" , "XXX"},
                { "ARQSIVPF_DATA_GERACAO" , "2024/05/05"},
                { "ARQSIVPF_QTDE_REG_GER" , "2"},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , "2024/06/06"},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q7);

            #endregion

            #region PF0720B_CPAGAMENTOS

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "00031"},
                { "HISCONPA_COD_SUBGRUPO" , "00003"},
                { "HISCONPA_NUM_CERTIFICADO" , "00011"},
                { "HISCONPA_NUM_PARCELA" , "3"},
                { "HISCONPA_OCORR_HISTORICO" , "INCLUSAO HISTORICO"},
                { "HISCONPA_COD_OPERACAO" , "00013"},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "00032"},
                { "HISCONPA_COD_SUBGRUPO" , "00004"},
                { "HISCONPA_NUM_CERTIFICADO" , "00012"},
                { "HISCONPA_NUM_PARCELA" , "4"},
                { "HISCONPA_OCORR_HISTORICO" , "INCLUSAO HISTORICO 2"},
                { "HISCONPA_COD_OPERACAO" , "00014"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0720B_CPAGAMENTOS", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0720B.txt")]
        public static void PF0720B_Tests_TheorySemPagamentoReturnCode00(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PF0720B_CPAGAMENTOS
                var q8 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("PF0720B_CPAGAMENTOS");
                AppSettings.TestSet.DynamicData.Add("PF0720B_CPAGAMENTOS", q8);
                #endregion
                #endregion
                var program = new PF0720B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("Saida_PF0720B.txt")]
        public static void PF0720B_Tests_TheoryComPagamentoReturnCode99(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1
                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1");

                q3.AddDynamic(new Dictionary<string, string>{
                    { "PROPOFID_NUM_PROPOSTA_SIVPF" , "00007"},
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "00002"},
                    { "PROPOFID_CANAL_PROPOSTA" , "00003"},
                    { "PROPOFID_NUM_IDENTIFICACAO" , "00011"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PROPOFID_NUM_PROPOSTA_SIVPF" , "00008"},
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "00003"},
                    { "PROPOFID_CANAL_PROPOSTA" , "00004"},
                    { "PROPOFID_NUM_IDENTIFICACAO" , "00012"},
                });
                AppSettings.TestSet.DynamicData.Add("R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new PF0720B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("Saida_PF0720B.txt")]
        public static void PF0720B_Tests_TheoryComPagamentoReturnCode00(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1
                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new PF0720B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("Saida_PF0720B.txt")]
        public static void PF0720B_Tests_TheorySubprogramaReturnCode00(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1
                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1");
                q5.AddDynamic(new Dictionary<string, string>{
                    { "PARCEVID_PREMIO_VG" , "00100"},
                    { "PARCEVID_PREMIO_AP" , "00101"},
                });
                q5.AddDynamic(new Dictionary<string, string>{
                    { "PARCEVID_PREMIO_VG" , "00200"},
                    { "PARCEVID_PREMIO_AP" , "00201"},
                });
                AppSettings.TestSet.DynamicData.Add("R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1", q5);

                #endregion

                #region PF0720B_CPAGAMENTOS

                var q8 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("PF0720B_CPAGAMENTOS");
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HISCONPA_NUM_APOLICE" , "00031"},
                    { "HISCONPA_COD_SUBGRUPO" , "00003"},
                    { "HISCONPA_NUM_CERTIFICADO" , "10000000001"},
                    { "HISCONPA_NUM_PARCELA" , "3"},
                    { "HISCONPA_OCORR_HISTORICO" , "INCLUSAO HISTORICO"},
                    { "HISCONPA_COD_OPERACAO" , "00013"},
                });
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HISCONPA_NUM_APOLICE" , "00032"},
                    { "HISCONPA_COD_SUBGRUPO" , "00004"},
                    { "HISCONPA_NUM_CERTIFICADO" , "10000000002"},
                    { "HISCONPA_NUM_PARCELA" , "4"},
                    { "HISCONPA_OCORR_HISTORICO" , "INCLUSAO HISTORICO 2"},
                    { "HISCONPA_COD_OPERACAO" , "00014"},
                });
                AppSettings.TestSet.DynamicData.Add("PF0720B_CPAGAMENTOS", q8);

                #endregion

                #region R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1");
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PROPOFID_NUM_PROPOSTA_SIVPF" , "00007"},
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "00002"},
                    { "PROPOFID_CANAL_PROPOSTA" , "00003"},
                    { "PROPOFID_NUM_IDENTIFICACAO" , "00011"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PROPOFID_NUM_PROPOSTA_SIVPF" , "00008"},
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "00003"},
                    { "PROPOFID_CANAL_PROPOSTA" , "00004"},
                    { "PROPOFID_NUM_IDENTIFICACAO" , "00012"},
                });
                AppSettings.TestSet.DynamicData.Add("R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1", q3);
                #endregion

                #region R0360_00_LER_PROP_VA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0360_00_LER_PROP_VA_DB_SELECT_1_Query1");
                q6.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_COD_PRODUTO" , "00003"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_COD_PRODUTO" , "00004"}
                });
                AppSettings.TestSet.DynamicData.Add("R0360_00_LER_PROP_VA_DB_SELECT_1_Query1", q6);

                #endregion

                #endregion
                var program = new PF0720B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(program.W01DIGCERT.WCERTIFICADO.IsNumeric());
            }
        }

    }
}