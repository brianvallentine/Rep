using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0100B;
using Sias.PessoaFisica.DB2.PF0100B;

namespace FileTests.Test
{
    [Collection("PF0100B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0100B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region PF0100B_PROPOSTA_FIDELIZ

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                {"DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , "82116567540"},
                {"DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO" , "5476879"},
                {"DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF" , "1"},
                {"DCLPROPOSTA_FIDELIZ_COD_PESSOA" , "4193214"},
                {"DCLPROPOSTA_FIDELIZ_NUM_SICOB" , "82116567540"},
                {"DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA" , "2002-06-03"},
                {"DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF" , "4"},
                {"DCLPROPOSTA_FIDELIZ_AGECOBR" , "338"},
                {"DCLPROPOSTA_FIDELIZ_DIA_DEBITO" , "3"},
                {"DCLPROPOSTA_FIDELIZ_OPCAOPAG" , "3"},
                {"DCLPROPOSTA_FIDELIZ_AGECTADEB" , "0"},
                {"DCLPROPOSTA_FIDELIZ_OPRCTADEB" , "0"},
                {"DCLPROPOSTA_FIDELIZ_NUMCTADEB" , "0"},
                {"DCLPROPOSTA_FIDELIZ_DIGCTADEB" , "0"},
                {"DCLPROPOSTA_FIDELIZ_PERC_DESCONTO" , "0.00"},
                {"DCLPROPOSTA_FIDELIZ_NRMATRVEN" , "513461"},
                {"DCLPROPOSTA_FIDELIZ_AGECTAVEN" , "0"},
                {"DCLPROPOSTA_FIDELIZ_OPRCTAVEN" , "0"},
                {"DCLPROPOSTA_FIDELIZ_NUMCTAVEN" , "0"},
                {"DCLPROPOSTA_FIDELIZ_DIGCTAVEN" , "0"},
                {"DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE" , "0"},
                {"DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE" , "                                        "},
                {"DCLPROPOSTA_FIDELIZ_NRMATRCON" , "0"},
                {"DCLPROPOSTA_FIDELIZ_DTQITBCO" , "2002-06-03"},
                {"DCLPROPOSTA_FIDELIZ_VAL_PAGO" , "75.50"},
                {"DCLPROPOSTA_FIDELIZ_AGEPGTO" , "338"},
                {"DCLPROPOSTA_FIDELIZ_VAL_TARIFA" , "0.00"},
                {"DCLPROPOSTA_FIDELIZ_VAL_IOF" , "4.94"},
                {"DCLPROPOSTA_FIDELIZ_DATA_CREDITO" , "2002-06-04"},
                {"DCLPROPOSTA_FIDELIZ_VAL_COMISSAO" , "5.58"},
                {"DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA" , "VNC"},
                {"DCLPROPOSTA_FIDELIZ_COD_USUARIO" , "PF0618B "},
                {"DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA" , "2"},
                {"DCLPROPOSTA_FIDELIZ_NSAS_SIVPF" , "5987"},
                {"DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA" , "6"},
                {"DCLPROPOSTA_FIDELIZ_NSL" , "2125"},
                {"DCLPROPOSTA_FIDELIZ_NSAC_SIVPF" , "1983"},
                {"DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO" , "R"},
                {"RELATORI_NUM_ENDOSSO" , "228"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                {"DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , "82118757541"},
                {"DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO" , "5476877"},
                {"DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF" , "1"},
                {"DCLPROPOSTA_FIDELIZ_COD_PESSOA" , "4191055"},
                {"DCLPROPOSTA_FIDELIZ_NUM_SICOB" , "82116567540"},
                {"DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA" , "2002-06-03"},
                {"DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF" , "4"},
                {"DCLPROPOSTA_FIDELIZ_AGECOBR" , "338"},
                {"DCLPROPOSTA_FIDELIZ_DIA_DEBITO" , "3"},
                {"DCLPROPOSTA_FIDELIZ_OPCAOPAG" , "3"},
                {"DCLPROPOSTA_FIDELIZ_AGECTADEB" , "0"},
                {"DCLPROPOSTA_FIDELIZ_OPRCTADEB" , "0"},
                {"DCLPROPOSTA_FIDELIZ_NUMCTADEB" , "0"},
                {"DCLPROPOSTA_FIDELIZ_DIGCTADEB" , "0"},
                {"DCLPROPOSTA_FIDELIZ_PERC_DESCONTO" , "0.00"},
                {"DCLPROPOSTA_FIDELIZ_NRMATRVEN" , "513461"},
                {"DCLPROPOSTA_FIDELIZ_AGECTAVEN" , "0"},
                {"DCLPROPOSTA_FIDELIZ_OPRCTAVEN" , "0"},
                {"DCLPROPOSTA_FIDELIZ_NUMCTAVEN" , "0"},
                {"DCLPROPOSTA_FIDELIZ_DIGCTAVEN" , "0"},
                {"DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE" , "0"},
                {"DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE" , "                                        "},
                {"DCLPROPOSTA_FIDELIZ_NRMATRCON" , "0"},
                {"DCLPROPOSTA_FIDELIZ_DTQITBCO" , "2002-06-03"},
                {"DCLPROPOSTA_FIDELIZ_VAL_PAGO" , "75.50"},
                {"DCLPROPOSTA_FIDELIZ_AGEPGTO" , "338"},
                {"DCLPROPOSTA_FIDELIZ_VAL_TARIFA" , "0.00"},
                {"DCLPROPOSTA_FIDELIZ_VAL_IOF" , "4.94"},
                {"DCLPROPOSTA_FIDELIZ_DATA_CREDITO" , "2002-06-04"},
                {"DCLPROPOSTA_FIDELIZ_VAL_COMISSAO" , "5.58"},
                {"DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA" , "VNC"},
                {"DCLPROPOSTA_FIDELIZ_COD_USUARIO" , "PF0618B "},
                {"DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA" , "2"},
                {"DCLPROPOSTA_FIDELIZ_NSAS_SIVPF" , "5987"},
                {"DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA" , "6"},
                {"DCLPROPOSTA_FIDELIZ_NSL" , "2125"},
                {"DCLPROPOSTA_FIDELIZ_NSAC_SIVPF" , "1983"},
                {"DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO" , "R"},
                {"RELATORI_NUM_ENDOSSO" , "228"}
            });
            AppSettings.TestSet.DynamicData.Add("PF0100B_PROPOSTA_FIDELIZ", q1);

            #endregion

            #region R0151_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "1626"}
            });
            AppSettings.TestSet.DynamicData.Add("R0151_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0100B.txt", "Saida_PF0100B_2.txt", "Saida_PF0100B_3.txt")]
        public static void PF0100B_Tests_Theory_Normal_0(string MOVTO_STA_SASSE_FILE_NAME_P, string MOVTO_STA_PREV_FILE_NAME_P, string MOVTO_STA_CAP_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";
            MOVTO_STA_PREV_FILE_NAME_P = $"{MOVTO_STA_PREV_FILE_NAME_P}_{timestamp}.txt";
            MOVTO_STA_CAP_FILE_NAME_P = $"{MOVTO_STA_CAP_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                //FLUXO NORMAL
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0100B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P, MOVTO_STA_PREV_FILE_NAME_P, MOVTO_STA_CAP_FILE_NAME_P);

                //R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("PROPFIDH_NUM_IDENTIFICACAO", out var valor) && valor.Contains("5476879"));
                Assert.True(envList[1].TryGetValue("PROPFIDH_DATA_SITUACAO", out var val1r) && val1r.Contains("2024-09-02"));
                Assert.True(envList[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var val2r) && val2r.Contains("1627"));

                //R0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var val3r) && val3r.Contains("1627"));
                Assert.True(envList1[1].TryGetValue("PROPFIDH_NSL", out var val4r) && val4r.Contains("1"));

                //R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("RELATORI_SIT_REGISTRO", out var val5r) && val5r.Contains("0"));
                Assert.True(envList2[1].TryGetValue("RELATORI_IDE_SISTEMA", out var val6r) && val6r.Contains("PF"));

                //R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val7r) && val7r.Contains("STASASSE"));
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val8r) && val8r.Contains("4"));
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_NSAS_SIVPF", out var val9r) && val9r.Contains("1627"));


                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("Saida_PF0100B.txt", "Saida_PF0100B_2.txt", "Saida_PF0100B_3.txt")]
        public static void PF0100B_Tests_Theory_Erro_99(string MOVTO_STA_SASSE_FILE_NAME_P, string MOVTO_STA_PREV_FILE_NAME_P, string MOVTO_STA_CAP_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";
            MOVTO_STA_PREV_FILE_NAME_P = $"{MOVTO_STA_PREV_FILE_NAME_P}_{timestamp}.txt";
            MOVTO_STA_CAP_FILE_NAME_P = $"{MOVTO_STA_CAP_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                //FLUXO DE ERRO
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                //R0151_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1
                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0151_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0151_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);


                #endregion
                var program = new PF0100B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P, MOVTO_STA_PREV_FILE_NAME_P, MOVTO_STA_CAP_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}