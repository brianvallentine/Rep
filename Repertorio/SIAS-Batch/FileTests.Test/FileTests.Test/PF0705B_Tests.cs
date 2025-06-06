using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0705B;
using Sias.PessoaFisica.DB2.PF0705B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0705B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0705B_Tests
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

            #region R0015_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "17265"}
            });
            AppSettings.TestSet.DynamicData.Add("R0015_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region PF0705B_PROPOSTA_FIDELIZ

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                {"PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058960"},
                {"PROPOFID_NUM_IDENTIFICACAO" , "1"},
                {"PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                {"PROPOFID_COD_PESSOA" , "1"},
                {"PROPOFID_NUM_SICOB" , "80000000017"},
                {"PROPOFID_DATA_PROPOSTA" , "2000-02-14"},
                {"PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                {"PROPOFID_AGECOBR" , "55"},
                {"PROPOFID_DIA_DEBITO" , "14"},
                {"PROPOFID_OPCAOPAG" , "1"},
                {"PROPOFID_AGECTADEB" , "55"},
                {"PROPOFID_OPRCTADEB" , "1"},
                {"PROPOFID_NUMCTADEB" , "47247"},
                {"PROPOFID_DIGCTADEB" , "4"},
                {"PROPOFID_PERC_DESCONTO" , "0.00"},
                {"PROPOFID_NRMATRVEN" , "262131"},
                {"PROPOFID_AGECTAVEN" , "55"},
                {"PROPOFID_OPRCTAVEN" , "1"},
                {"PROPOFID_NUMCTAVEN" , "42953"},
                {"PROPOFID_DIGCTAVEN" , "6"},
                {"PROPOFID_CGC_CONVENENTE" , "0"},
                {"PROPOFID_NOME_CONVENENTE" , "                                        "},
                {"PROPOFID_NRMATRCON" , "0"},
                {"PROPOFID_DTQITBCO" , "2000-02-14"},
                {"PROPOFID_VAL_PAGO" , "300.00"},
                {"PROPOFID_AGEPGTO" , "55"},
                {"PROPOFID_VAL_TARIFA" , "3.30"},
                {"PROPOFID_VAL_IOF" , "0.00"},
                {"PROPOFID_DATA_CREDITO" , "2000-02-15"},
                {"PROPOFID_VAL_COMISSAO" , "0.00"},
                {"PROPOFID_SIT_PROPOSTA" , "EMT"},
                {"PROPOFID_COD_USUARIO" , "PF0600B "},
                {"PROPOFID_CANAL_PROPOSTA" , "1"},
                {"PROPOFID_NSAS_SIVPF" , "835"},
                {"PROPOFID_ORIGEM_PROPOSTA" , "6"},
                {"PROPOFID_NSL" , "5520"},
                {"PROPOFID_NSAC_SIVPF" , "4"},
                {"PROPOFID_SITUACAO_ENVIO" , "R"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                {"PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058977"},
                {"PROPOFID_NUM_IDENTIFICACAO" , "1"},
                {"PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                {"PROPOFID_COD_PESSOA" , "1"},
                {"PROPOFID_NUM_SICOB" , "80000000017"},
                {"PROPOFID_DATA_PROPOSTA" , "2000-02-14"},
                {"PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                {"PROPOFID_AGECOBR" , "55"},
                {"PROPOFID_DIA_DEBITO" , "14"},
                {"PROPOFID_OPCAOPAG" , "1"},
                {"PROPOFID_AGECTADEB" , "55"},
                {"PROPOFID_OPRCTADEB" , "1"},
                {"PROPOFID_NUMCTADEB" , "47247"},
                {"PROPOFID_DIGCTADEB" , "4"},
                {"PROPOFID_PERC_DESCONTO" , "0.00"},
                {"PROPOFID_NRMATRVEN" , "262131"},
                {"PROPOFID_AGECTAVEN" , "55"},
                {"PROPOFID_OPRCTAVEN" , "1"},
                {"PROPOFID_NUMCTAVEN" , "42953"},
                {"PROPOFID_DIGCTAVEN" , "6"},
                {"PROPOFID_CGC_CONVENENTE" , "0"},
                {"PROPOFID_NOME_CONVENENTE" , "                                        "},
                {"PROPOFID_NRMATRCON" , "0"},
                {"PROPOFID_DTQITBCO" , "2000-02-14"},
                {"PROPOFID_VAL_PAGO" , "300.00"},
                {"PROPOFID_AGEPGTO" , "55"},
                {"PROPOFID_VAL_TARIFA" , "3.30"},
                {"PROPOFID_VAL_IOF" , "0.00"},
                {"PROPOFID_DATA_CREDITO" , "2000-02-15"},
                {"PROPOFID_VAL_COMISSAO" , "0.00"},
                {"PROPOFID_SIT_PROPOSTA" , "EMT"},
                {"PROPOFID_COD_USUARIO" , "PF0600B "},
                {"PROPOFID_CANAL_PROPOSTA" , "1"},
                {"PROPOFID_NSAS_SIVPF" , "835"},
                {"PROPOFID_ORIGEM_PROPOSTA" , "6"},
                {"PROPOFID_NSL" , "5520"},
                {"PROPOFID_NSAC_SIVPF" , "4"},
                {"PROPOFID_SITUACAO_ENVIO" , "R"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                {"PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058977"},
                {"PROPOFID_NUM_IDENTIFICACAO" , "1"},
                {"PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                {"PROPOFID_COD_PESSOA" , "1"},
                {"PROPOFID_NUM_SICOB" , "80000000017"},
                {"PROPOFID_DATA_PROPOSTA" , "2000-02-14"},
                {"PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                {"PROPOFID_AGECOBR" , "55"},
                {"PROPOFID_DIA_DEBITO" , "14"},
                {"PROPOFID_OPCAOPAG" , "1"},
                {"PROPOFID_AGECTADEB" , "55"},
                {"PROPOFID_OPRCTADEB" , "1"},
                {"PROPOFID_NUMCTADEB" , "47247"},
                {"PROPOFID_DIGCTADEB" , "4"},
                {"PROPOFID_PERC_DESCONTO" , "0.00"},
                {"PROPOFID_NRMATRVEN" , "262131"},
                {"PROPOFID_AGECTAVEN" , "55"},
                {"PROPOFID_OPRCTAVEN" , "1"},
                {"PROPOFID_NUMCTAVEN" , "42953"},
                {"PROPOFID_DIGCTAVEN" , "6"},
                {"PROPOFID_CGC_CONVENENTE" , "0"},
                {"PROPOFID_NOME_CONVENENTE" , "                                        "},
                {"PROPOFID_NRMATRCON" , "0"},
                {"PROPOFID_DTQITBCO" , "2000-02-14"},
                {"PROPOFID_VAL_PAGO" , "300.00"},
                {"PROPOFID_AGEPGTO" , "55"},
                {"PROPOFID_VAL_TARIFA" , "3.30"},
                {"PROPOFID_VAL_IOF" , "0.00"},
                {"PROPOFID_DATA_CREDITO" , "2000-02-15"},
                {"PROPOFID_VAL_COMISSAO" , "0.00"},
                {"PROPOFID_SIT_PROPOSTA" , "EMT"},
                {"PROPOFID_COD_USUARIO" , "PF0600B "},
                {"PROPOFID_CANAL_PROPOSTA" , "1"},
                {"PROPOFID_NSAS_SIVPF" , "835"},
                {"PROPOFID_ORIGEM_PROPOSTA" , "6"},
                {"PROPOFID_NSL" , "5520"},
                {"PROPOFID_NSAC_SIVPF" , "4"},
                {"PROPOFID_SITUACAO_ENVIO" , "R"}
            });
            AppSettings.TestSet.DynamicData.Add("PF0705B_PROPOSTA_FIDELIZ", q2);

            #endregion

            #region R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , "1"},
                { "PROPFIDH_NSL" , "7594"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , "1"},
                { "PROPFIDH_NSL" , "7594"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , "1"},
                { "PROPFIDH_NSL" , "7594"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , "1"},
                { "PROPFIDH_NSL" , "7594"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , "1"},
                { "PROPFIDH_NSL" , "7594"},
            });
            AppSettings.TestSet.DynamicData.Add("R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0044_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R0044_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "80021058960"},
                { "PROPOVA_COD_SUBGRUPO" , "12"},
                { "PROPOVA_COD_PRODUTO" , "9321"},
                { "PROPOVA_DATA_MOVIMENTO" , "2008-07-31"},
                { "PROPOVA_IDE_SEXO" , "M"},
            });
            AppSettings.TestSet.DynamicData.Add("R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1

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
            AppSettings.TestSet.DynamicData.Add("R0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , "211523067"},
                { "DATA_INIVIGENCIA" , "2000-07-21"},
                { "DATA_TERVIGENCIA" , "9999-12-31"},
                { "IMPSEGUR" , "12000.00"},
                { "IMP_MORNATU" , "12000.00"},
                { "IMPMORACID" , "24000.00"},
                { "IMPINVPERM" , "12000.00"},
                { "IMPAMDS" , "0"},
                { "IMPDH" , "0"},
                { "IMPDIT" , "0"},
                { "VLPREMIO" , "75.50"},
                { "PRMVG" , "52.80"},
                { "PRMAP" , "22.70"},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , "211523062"},
                { "DATA_INIVIGENCIA" , "2000-07-21"},
                { "DATA_TERVIGENCIA" , "9999-12-31"},
                { "IMPSEGUR" , "12000.00"},
                { "IMP_MORNATU" , "12000.00"},
                { "IMPMORACID" , "24000.00"},
                { "IMPINVPERM" , "12000.00"},
                { "IMPAMDS" , "0"},
                { "IMPDH" , "0"},
                { "IMPDIT" , "0"},
                { "VLPREMIO" , "75.50"},
                { "PRMVG" , "52.80"},
                { "PRMAP" , "22.70"},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , "211523061"},
                { "DATA_INIVIGENCIA" , "2000-07-21"},
                { "DATA_TERVIGENCIA" , "9999-12-31"},
                { "IMPSEGUR" , "12000.00"},
                { "IMP_MORNATU" , "12000.00"},
                { "IMPMORACID" , "24000.00"},
                { "IMPINVPERM" , "12000.00"},
                { "IMPAMDS" , "0"},
                { "IMPDH" , "0"},
                { "IMPDIT" , "0"},
                { "VLPREMIO" , "75.50"},
                { "PRMVG" , "52.80"},
                { "PRMAP" , "22.70"},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0070_00_ACESSA_APOLICE_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0070_00_ACESSA_APOLICE_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0075_00_OBTER_PCT_IOF_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0075_00_OBTER_PCT_IOF_DB_SELECT_1_Query1", q10);

            #endregion

            #region PF0705B_PAGAMENTO

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0705B_PAGAMENTO", q11);

            #endregion

            #region R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "W_COD_OPERACAO" , "3"}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "ERROVDAZ_COD_ERRO_SIVPF" , "693"}
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "ERROVDAZ_COD_ERRO_SIVPF" , "693"}
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "ERROVDAZ_COD_ERRO_SIVPF" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1", q14);

            #endregion

            #region PARAMETERS_SubVG0710S

            #region Execute_DB_SELECT_1_Query1
            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-09-02"},

            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q31);

            #endregion

            #region M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1
            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "TAXA_AP_MORACID" , "0.0001"},
                { "TAXA_AP_INVPERM" , "0"},
                { "TAXA_AP_AMDS" , "0"},
                { "TAXA_AP_DH" , "0"},
                { "TAXA_AP_DIT" , "0"},
                { "GARAN_ADIC_IEA" , "0"},
                { "GARAN_ADIC_IPA" , "100"},
                { "GARAN_ADIC_IPD" , "0"},
                { "GARAN_ADIC_HD" , "0"},


            });
            AppSettings.TestSet.DynamicData.Add("M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1", q32);

            #endregion

            #region M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1
            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "MODALIDA" , "0"},
                { "RAMO" , "97"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1", q33);

            #endregion
            #endregion
            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0705B.txt")]
        public static void PF0705B_Tests_Theory(string MOVTO_STA_SASSE_FILE_NAME_P)
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

                #region R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1

                var q3 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new PF0705B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                

                //arquivo
                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

                //teste especifico para o call do Subprograma VG0710S
                //Verifica se o parametro do subprograma foi alterado
                Assert.True(program.PARAMETROS.LK_COBT_MORTE_ACIDENTAL != 0);

                //R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

                var envList1 = AppSettings.TestSet.DynamicData["R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val8r) && val8r.Contains("STASASSE"));
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val9r) && val9r.Contains("4"));

                var envList2 = AppSettings.TestSet.DynamicData["R0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var val4r) && val4r.Contains("1"));
                Assert.True(envList2[1].TryGetValue("PROPFIDH_SIT_MOTIVO_SIVPF", out var val5r) && val5r.Contains("693"));

            }
        }

        [Theory]
        [InlineData("Saida_PF0705B.txt")]
        public static void PF0705B_Tests_Theory2(string MOVTO_STA_SASSE_FILE_NAME_P)
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
                #region PF0705B_PROPOSTA_FIDELIZ

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    {"PROPOFID_NUM_PROPOSTA_SIVPF" , "19999900999"},
                    {"PROPOFID_NUM_IDENTIFICACAO" , "1"},
                    {"PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                    {"PROPOFID_COD_PESSOA" , "1"},
                    {"PROPOFID_NUM_SICOB" , "80000000017"},
                    {"PROPOFID_DATA_PROPOSTA" , "2000-02-14"},
                    {"PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                    {"PROPOFID_AGECOBR" , "55"},
                    {"PROPOFID_DIA_DEBITO" , "14"},
                    {"PROPOFID_OPCAOPAG" , "1"},
                    {"PROPOFID_AGECTADEB" , "55"},
                    {"PROPOFID_OPRCTADEB" , "1"},
                    {"PROPOFID_NUMCTADEB" , "47247"},
                    {"PROPOFID_DIGCTADEB" , "4"},
                    {"PROPOFID_PERC_DESCONTO" , "0.00"},
                    {"PROPOFID_NRMATRVEN" , "262131"},
                    {"PROPOFID_AGECTAVEN" , "55"},
                    {"PROPOFID_OPRCTAVEN" , "1"},
                    {"PROPOFID_NUMCTAVEN" , "42953"},
                    {"PROPOFID_DIGCTAVEN" , "6"},
                    {"PROPOFID_CGC_CONVENENTE" , "0"},
                    {"PROPOFID_NOME_CONVENENTE" , "                                        "},
                    {"PROPOFID_NRMATRCON" , "0"},
                    {"PROPOFID_DTQITBCO" , "2000-02-14"},
                    {"PROPOFID_VAL_PAGO" , "300.00"},
                    {"PROPOFID_AGEPGTO" , "55"},
                    {"PROPOFID_VAL_TARIFA" , "3.30"},
                    {"PROPOFID_VAL_IOF" , "0.00"},
                    {"PROPOFID_DATA_CREDITO" , "2000-02-15"},
                    {"PROPOFID_VAL_COMISSAO" , "0.00"},
                    {"PROPOFID_SIT_PROPOSTA" , "EMT"},
                    {"PROPOFID_COD_USUARIO" , "PF0600B "},
                    {"PROPOFID_CANAL_PROPOSTA" , "1"},
                    {"PROPOFID_NSAS_SIVPF" , "835"},
                    {"PROPOFID_ORIGEM_PROPOSTA" , "6"},
                    {"PROPOFID_NSL" , "5520"},
                    {"PROPOFID_NSAC_SIVPF" , "4"},
                    {"PROPOFID_SITUACAO_ENVIO" , "R"}
                });
                AppSettings.TestSet.DynamicData.Remove("PF0705B_PROPOSTA_FIDELIZ");
                AppSettings.TestSet.DynamicData.Add("PF0705B_PROPOSTA_FIDELIZ", q2);

                #endregion
                #endregion
                var program = new PF0705B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);
                //teste especifico para o call do Subprograma PROM1101
                //Verifica se o parametro do subprograma foi alterado
                Assert.True(program.W01DIGCERT.WDIG.Value == "6");

                Assert.True(program.RETURN_CODE == 0);

                //R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1

                var envList = AppSettings.TestSet.DynamicData["R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var val4r) && val4r.Contains("1"));
                Assert.True(envList[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var val5r) && val5r.Contains("000019999900999"));

                //R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

                var envList1 = AppSettings.TestSet.DynamicData["R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val8r) && val8r.Contains("STASASSE"));
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val9r) && val9r.Contains("4"));

            }
        }
        [Theory]
        [InlineData("Saida_PF0705B.txt")]
        public static void PF0705B_Tests_Theory3(string MOVTO_STA_SASSE_FILE_NAME_P)
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

                #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new PF0705B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                //teste de erro, sem dado na base em alguma query
                Assert.True(program.RETURN_CODE == 9);

            }
        }
    }
}