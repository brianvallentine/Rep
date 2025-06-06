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
using static Code.BI0073B;

namespace FileTests.Test
{
    [Collection("BI0073B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0073B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "71"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_AVISO" , "12"}
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , "7543"},
                { "PROPOFID_NUM_SICOB" , "0"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , "7543"},
                { "PROPOFID_NUM_SICOB" , "0"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , "7543"},
                { "PROPOFID_NUM_SICOB" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "4120"},
                { "BILHETE_NUM_APOLICE" , "0"},
                { "BILHETE_FONTE" , "6"},
                { "BILHETE_AGE_COBRANCA" , "1413"},
                { "BILHETE_NUM_MATRICULA" , "5815280"},
                { "BILHETE_COD_AGENCIA" , "0"},
                { "BILHETE_OPERACAO_CONTA" , "0"},
                { "BILHETE_NUM_CONTA" , "0"},
                { "BILHETE_DIG_CONTA" , "0"},
                { "BILHETE_COD_CLIENTE" , "5219300"},
                { "BILHETE_PROFISSAO" , "OUTROS              "},
                { "BILHETE_IDE_SEXO" , "M"},
                { "BILHETE_ESTADO_CIVIL" , "O"},
                { "BILHETE_OCORR_ENDERECO" , "1"},
                { "BILHETE_COD_AGENCIA_DEB" , "0"},
                { "BILHETE_OPERACAO_CONTA_DEB" , "0"},
                { "BILHETE_NUM_CONTA_DEB" , "0"},
                { "BILHETE_DIG_CONTA_DEB" , "0"},
                { "BILHETE_OPC_COBERTURA" , "31"},
                { "BILHETE_DATA_QUITACAO" , "0001-01-01"},
                { "BILHETE_VAL_RCAP" , "0"},
                { "BILHETE_RAMO" , "82"},
                { "BILHETE_DATA_VENDA" , "0001-01-01"},
                { "BILHETE_DATA_MOVIMENTO" , "2001-05-31"},
                { "BILHETE_NUM_APOL_ANTERIOR" , "0"},
                { "BILHETE_SITUACAO" , "P"},
                { "BILHETE_TIP_CANCELAMENTO" , "0"},
                { "BILHETE_SIT_SINISTRO" , "0"},
                { "BILHETE_COD_USUARIO" , "BI0094B "},
                { "BILHETE_TIMESTAMP" , "2001-05-31 20:17:23.447"},
                { "BILHETE_DATA_CANCELAMENTO" , "2017-09-25"},
                { "BILHETE_BI_FAIXA_RENDA_IND" , "0"},
                { "BILHETE_BI_FAIXA_RENDA_FAM" , "0"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "4120"},
                { "BILHETE_NUM_APOLICE" , "0"},
                { "BILHETE_FONTE" , "6"},
                { "BILHETE_AGE_COBRANCA" , "1413"},
                { "BILHETE_NUM_MATRICULA" , "5815280"},
                { "BILHETE_COD_AGENCIA" , "0"},
                { "BILHETE_OPERACAO_CONTA" , "0"},
                { "BILHETE_NUM_CONTA" , "0"},
                { "BILHETE_DIG_CONTA" , "0"},
                { "BILHETE_COD_CLIENTE" , "5219300"},
                { "BILHETE_PROFISSAO" , "OUTROS              "},
                { "BILHETE_IDE_SEXO" , "M"},
                { "BILHETE_ESTADO_CIVIL" , "O"},
                { "BILHETE_OCORR_ENDERECO" , "1"},
                { "BILHETE_COD_AGENCIA_DEB" , "0"},
                { "BILHETE_OPERACAO_CONTA_DEB" , "0"},
                { "BILHETE_NUM_CONTA_DEB" , "0"},
                { "BILHETE_DIG_CONTA_DEB" , "0"},
                { "BILHETE_OPC_COBERTURA" , "31"},
                { "BILHETE_DATA_QUITACAO" , "0001-01-01"},
                { "BILHETE_VAL_RCAP" , "0"},
                { "BILHETE_RAMO" , "82"},
                { "BILHETE_DATA_VENDA" , "0001-01-01"},
                { "BILHETE_DATA_MOVIMENTO" , "2001-05-31"},
                { "BILHETE_NUM_APOL_ANTERIOR" , "0"},
                { "BILHETE_SITUACAO" , "P"},
                { "BILHETE_TIP_CANCELAMENTO" , "0"},
                { "BILHETE_SIT_SINISTRO" , "0"},
                { "BILHETE_COD_USUARIO" , "BI0094B "},
                { "BILHETE_TIMESTAMP" , "2001-05-31 20:17:23.447"},
                { "BILHETE_DATA_CANCELAMENTO" , "2017-09-25"},
                { "BILHETE_BI_FAIXA_RENDA_IND" , "0"},
                { "BILHETE_BI_FAIXA_RENDA_FAM" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , "83502537299"},
                { "CEDENTE_NUM_TITULO_MAX" , "83599999999"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , "83502537299"},
                { "CEDENTE_NUM_TITULO_MAX" , "83599999999"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , "83502537299"},
                { "CEDENTE_NUM_TITULO_MAX" , "83599999999"},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1", q8);

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

            #region R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1", q10);

            #endregion

            #region R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                { "CONVERSI_NUM_SICOB" , ""},
                { "CONVERSI_COD_EMPRESA_SIVPF" , ""},
                { "CONVERSI_COD_PRODUTO_SIVPF" , ""},
                { "CONVERSI_AGEPGTO" , ""},
                { "CONVERSI_DATA_OPERACAO" , ""},
                { "CONVERSI_DATA_QUITACAO" , ""},
                { "CONVERSI_VAL_RCAP" , ""},
                { "CONVERSI_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_MATRICULA" , ""},
                { "BILHETE_COD_AGENCIA" , ""},
                { "BILHETE_OPERACAO_CONTA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_PROFISSAO" , ""},
                { "BILHETE_IDE_SEXO" , ""},
                { "BILHETE_ESTADO_CIVIL" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_COD_AGENCIA_DEB" , ""},
                { "BILHETE_OPERACAO_CONTA_DEB" , ""},
                { "BILHETE_NUM_CONTA_DEB" , ""},
                { "BILHETE_DIG_CONTA_DEB" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_DATA_MOVIMENTO" , ""},
                { "BILHETE_NUM_APOL_ANTERIOR" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_SIT_SINISTRO" , ""},
                { "BILHETE_COD_USUARIO" , ""},
                { "BILHETE_TIMESTAMP" , ""},
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "BILHETE_BI_FAIXA_RENDA_IND" , ""},
                { "BILHETE_BI_FAIXA_RENDA_FAM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1", q13);

            #endregion

            #region R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_IOCC" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1", q14);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.EM.D240902.EM8006B.DEBITO.txt")]
        public static void BI0073B_Tests_TheoryErro99(string MOVIMENTO_FILE_NAME_P)
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
                #region R0020_00_OBTER_MAX_NSAS_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new BI0073B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("PRD.EM.D240902.EM8006B.DEBITO.txt")]
        public static void BI0073B_Tests_Theory(string MOVIMENTO_FILE_NAME_P)
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
                var program = new BI0073B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                //arquivo de entrada nao possibilita o teste do restante das querys. Só tem Header e Trailler, Sem Movimento.

                //R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val7r) && val7r.Contains("STASCADE"));
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val8r) && val8r.Contains("4"));
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_NSAS_SIVPF", out var val9r) && val9r.Contains("72"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

    }
}