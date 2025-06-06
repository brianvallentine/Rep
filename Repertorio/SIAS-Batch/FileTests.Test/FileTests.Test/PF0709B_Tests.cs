using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0709B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0709B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0709B_Tests
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
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-02"},
                { "WHOST_DT_INI_ATR" , "2024-09-01"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "1248"}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "1"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "12"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "NUM_PARCELA" , "331"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "NUM_PARCELA" , "332"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "NUM_PARCELA" , "331"}
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "DATA_VENCIMENTO" , "R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1"}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "DATA_VENCIMENTO" , "R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1"}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "DATA_VENCIMENTO" , "R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1"}
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0400_00_SELECT_HISTORICO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_HISTORICO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIT_REGISTRO" , "3"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIT_REGISTRO" , "3"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIT_REGISTRO" , "3"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIT_REGISTRO" , "3"}
            });
            AppSettings.TestSet.DynamicData.Add("R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0500_00_INCLUIR_HISTORICO_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""},
                { "PROPFIDH_DATA_SITUACAO" , ""},
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
                { "PROPFIDH_SIT_PROPOSTA" , ""},
                { "PROPFIDH_SIT_COBRANCA_SIVPF" , ""},
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , ""},
                { "PROPFIDH_COD_EMPRESA_SIVPF" , ""},
                { "PROPFIDH_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_INCLUIR_HISTORICO_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
                { "PROPOFID_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q9);

            #endregion

            #region PF0709B_CPROPOSTA

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "DCLCOBER_HIST_VIDAZUL_NUM_CERTIFICADO" , "10000392471"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "6127249"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "1"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "7"},
                { "DCLCOBER_HIST_VIDAZUL_NUM_PARCELA" , "331"},
                { "DCLCOBER_HIST_VIDAZUL_DATA_VENCIMENTO" , "2023-03-06"},
                { "DCLCOBER_HIST_VIDAZUL_OPCAO_PAGAMENTO" , "1"},
                { "DCLCOBER_HIST_VIDAZUL_SIT_REGISTRO" , "0"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "DCLCOBER_HIST_VIDAZUL_NUM_CERTIFICADO" , "10000395725"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "6127252"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "1"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "7"},
                { "DCLCOBER_HIST_VIDAZUL_NUM_PARCELA" , "331"},
                { "DCLCOBER_HIST_VIDAZUL_DATA_VENCIMENTO" , "2023-03-06"},
                { "DCLCOBER_HIST_VIDAZUL_OPCAO_PAGAMENTO" , "1"},
                { "DCLCOBER_HIST_VIDAZUL_SIT_REGISTRO" , "0"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "DCLCOBER_HIST_VIDAZUL_NUM_CERTIFICADO" , "10000415500"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "6127265"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "1"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "7"},
                { "DCLCOBER_HIST_VIDAZUL_NUM_PARCELA" , "331"},
                { "DCLCOBER_HIST_VIDAZUL_DATA_VENCIMENTO" , "2023-03-06"},
                { "DCLCOBER_HIST_VIDAZUL_OPCAO_PAGAMENTO" , "1"},
                { "DCLCOBER_HIST_VIDAZUL_SIT_REGISTRO" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0709B_CPROPOSTA", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0709B_00.txt")]
        public static void PF0709B_Tests_TheoryFluxoComPgto(string MOVTO_STA_SASSE_FILE_NAME_P)
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
                #endregion
                var program = new PF0709B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 0);

                var envList1 = AppSettings.TestSet.DynamicData["R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val8r) && val8r.Contains("STASASSE"));
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val9r) && val9r.Contains("4"));

            }
        }

        [Theory]
        [InlineData("Saida_PF0709B_01.txt")]
        public static void PF0709B_Tests_Theory2_fluxoSemPagto(string MOVTO_STA_SASSE_FILE_NAME_P)
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


                #region R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1
                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1", q3);
                #endregion

                #region R0400_00_SELECT_HISTORICO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SELECT_HISTORICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_HISTORICO_DB_SELECT_1_Query1", q5);

                #endregion

                #endregion
                var program = new PF0709B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                //teste especifico para o call do Subprograma PROM1101
                //Verifica se o parametro do subprograma foi alterado
                Assert.True(program.W01DIGCERT.WDIG.Value != "0");

                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 0);

                var envList1 = AppSettings.TestSet.DynamicData["R0500_00_INCLUIR_HISTORICO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("PROPFIDH_NUM_IDENTIFICACAO", out var val8r) && val8r.Contains("6127249"));
                Assert.True(envList1[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var val9r) && val9r.Contains("1249"));

                var envList = AppSettings.TestSet.DynamicData["R0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var val4r) && val4r.Contains("1"));
                Assert.True(envList[1].TryGetValue("PROPOFID_COD_USUARIO", out var val5r) && val5r.Contains("PF0709B"));

            }
        }

        [Theory]
        [InlineData("Saida_PF0709B_02.txt")]
        public static void PF0709B_Tests_Theory2_Erro99(string MOVTO_STA_SASSE_FILE_NAME_P)
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

                #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

                var q0 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0100_00_INICIALIZA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new PF0709B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.AREA_ABEND.WABEND.WSQLCODE == 100);
                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}