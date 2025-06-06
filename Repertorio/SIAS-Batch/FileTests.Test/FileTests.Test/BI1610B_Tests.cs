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
using static Code.BI1610B;

namespace FileTests.Test
{
    [Collection("BI1610B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI1610B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_70000_00_INICIAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_PROC" , ""},
                { "WS_DATA_PROC_AUX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_70000_00_INICIAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_13100_00_CLIENTE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_13100_00_CLIENTE_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_13130_00_CBO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CBO_DESCR_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_13130_00_CBO_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_13130_00_CBO_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PF062_NUM_PROPOSTA_SIVPF" , ""},
                { "PF062_COD_CBO" , ""},
                { "PF062_DES_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_13130_00_CBO_DB_INSERT_1_Insert1", q3);

            #endregion

            #region M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO" , ""},
                { "PRDSIVPF_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PESSOA" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_DIA_DEBITO" , ""},
                { "PROPOFID_OPCAOPAG" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "PROPOFID_PERC_DESCONTO" , ""},
                { "PROPOFID_NRMATRVEN" , ""},
                { "PROPOFID_AGECTAVEN" , ""},
                { "PROPOFID_OPRCTAVEN" , ""},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , ""},
                { "PROPOFID_CGC_CONVENENTE" , ""},
                { "PROPOFID_NOME_CONVENENTE" , ""},
                { "PROPOFID_NRMATRCON" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_AGEPGTO" , ""},
                { "PROPOFID_VAL_TARIFA" , ""},
                { "PROPOFID_VAL_IOF" , ""},
                { "PROPOFID_DATA_CREDITO" , ""},
                { "PROPOFID_VAL_COMISSAO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_COD_USUARIO" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , ""},
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_NSAC_SIVPF" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_COD_PLANO" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "PROPOFID_PROFISSAO_CONJUGE" , ""},
                { "PROPOFID_FAIXA_RENDA_IND" , ""},
                { "PROPOFID_FAIXA_RENDA_FAM" , ""},
                { "PROPOFID_IND_TIPO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1", q6);

            #endregion

            #region M_135B1_00_RCAPS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_135B1_00_RCAPS_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_135B3_00_RCAPS_COMP_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_135B3_00_RCAPS_COMP_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_135B3_00_RCAPS_COMP_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_135B3_00_RCAPS_COMP_DB_SELECT_2_Query1", q9);

            #endregion

            #region M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_135B5_00_OBTER_SICOB_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_135B5_00_OBTER_SICOB_DB_UPDATE_1_Update1", q11);

            #endregion

            #region M_135B5_00_OBTER_SICOB_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_SICOB" , ""},
                { "COD_EMPRESA_SIVPF" , ""},
                { "PRODUTO_SIVPF" , ""},
                { "AGEPGTO" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_135B5_00_OBTER_SICOB_DB_INSERT_1_Insert1", q12);

            #endregion

            #region M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""},
                { "CEDENTE_NUM_TITULO_MAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1", q13);

            #endregion

            #region M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "GETPMOIM_DES_TP_MORA_IMOVEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPSSBI_NUM_IDENTIFICACAO" , ""},
                { "PROPSSBI_RENOVACAO_AUTOM" , ""},
                { "GETPMOIM_NUM_TP_MORA_IMOVEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1", q15);

            #endregion

            #region M_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q16);

            #endregion

            #region M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "NUM_BENEFICIARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_13700_00_BENEFICIARIO_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_AZUL" , ""},
                { "COD_AGENCIA_LOTE" , ""},
                { "DATA_LOTE" , ""},
                { "NUM_LOTE" , ""},
                { "NUM_SEQ_LOTE" , ""},
                { "NUM_BENEFICIARIO" , ""},
                { "NOME_BENEFICIARIO" , ""},
                { "GRAU_PARENTESCO" , ""},
                { "PCT_PART_BENEFICIA" , ""},
                { "DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_13700_00_BENEFICIARIO_DB_INSERT_1_Insert1", q18);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.PF.D241202.PF0112B.BILHETESS", "BI1610O1_FILE_NAME_P")]
        public static void BI1610B_Tests_Theory_Erro99(string BI1610I1_FILE_NAME_P, string BI1610O1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            BI1610O1_FILE_NAME_P = $"{BI1610O1_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new BI1610B();
                program.Execute(BI1610I1_FILE_NAME_P, BI1610O1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("PRD.PF.D241202.PF0112B.BILHETESS", "BI1610O1_FILE_NAME_P")]
        public static void BI1610B_Tests_Theory(string BI1610I1_FILE_NAME_P, string BI1610O1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            BI1610O1_FILE_NAME_P = $"{BI1610O1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                SPBGE053_Tests.Load_Parameters();
                GE0070S_Tests.Load_Parameters();

                #region BI0003B_Parameters

                #region M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1

                var b0 = new DynamicData();
                b0.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""}
                });
                b0.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""}
                });
                b0.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1", b0);

                #endregion

                #region M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1

                var b1 = new DynamicData();
                b1.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""}
                });
                b1.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""}
                });
                b1.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1", b1);

                #endregion

                #region M_31000_00_INS_PESSOA_DB_SELECT_1_Query1

                var b2 = new DynamicData();
                b2.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""}
                });
                b2.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""}
                });
                b2.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_31000_00_INS_PESSOA_DB_SELECT_1_Query1", b2);

                #endregion

                #region M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1

                var b3 = new DynamicData();
                b3.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "PESSOA_NOME_PESSOA" , ""},
                    { "PESSOA_COD_USUARIO" , ""},
                    { "PESSOA_TIPO_PESSOA" , ""},
                });
                b3.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "PESSOA_NOME_PESSOA" , ""},
                    { "PESSOA_COD_USUARIO" , ""},
                    { "PESSOA_TIPO_PESSOA" , ""},
                });
                b3.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "PESSOA_NOME_PESSOA" , ""},
                    { "PESSOA_COD_USUARIO" , ""},
                    { "PESSOA_TIPO_PESSOA" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1", b3);

                #endregion

                #region M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1

                var b4 = new DynamicData();
                b4.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "CPF" , ""},
                    { "DATA_NASCIMENTO" , ""},
                    { "SEXO" , ""},
                    { "COD_USUARIO" , ""},
                    { "ESTADO_CIVIL" , ""},
                    { "NUM_IDENTIDADE" , ""},
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "UF_EXPEDIDORA" , ""},
                    { "DATA_EXPEDICAO" , ""},
                    { "COD_CBO" , ""},
                    { "TIPO_IDENT_SIVPF" , ""},
                });
                b4.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "CPF" , ""},
                    { "DATA_NASCIMENTO" , ""},
                    { "SEXO" , ""},
                    { "COD_USUARIO" , ""},
                    { "ESTADO_CIVIL" , ""},
                    { "NUM_IDENTIDADE" , ""},
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "UF_EXPEDIDORA" , ""},
                    { "DATA_EXPEDICAO" , ""},
                    { "COD_CBO" , ""},
                    { "TIPO_IDENT_SIVPF" , ""},
                });
                b4.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "CPF" , ""},
                    { "DATA_NASCIMENTO" , ""},
                    { "SEXO" , ""},
                    { "COD_USUARIO" , ""},
                    { "ESTADO_CIVIL" , ""},
                    { "NUM_IDENTIDADE" , ""},
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "UF_EXPEDIDORA" , ""},
                    { "DATA_EXPEDICAO" , ""},
                    { "COD_CBO" , ""},
                    { "TIPO_IDENT_SIVPF" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1", b4);

                #endregion

                #region M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1

                var b5 = new DynamicData();
                b5.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "CGC" , ""},
                    { "NOME_FANTASIA" , ""},
                    { "COD_USUARIO" , ""},
                });
                b5.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "CGC" , ""},
                    { "NOME_FANTASIA" , ""},
                    { "COD_USUARIO" , ""},
                });
                b5.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "CGC" , ""},
                    { "NOME_FANTASIA" , ""},
                    { "COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1", b5);

                #endregion

                #region M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1

                var b6 = new DynamicData();
                b6.AddDynamic(new Dictionary<string, string>{
                    { "NUM_IDENTIDADE" , ""},
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "UF_EXPEDIDORA" , ""},
                    { "DATA_EXPEDICAO" , ""},
                });
                b6.AddDynamic(new Dictionary<string, string>{
                    { "NUM_IDENTIDADE" , ""},
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "UF_EXPEDIDORA" , ""},
                    { "DATA_EXPEDICAO" , ""},
                });
                b6.AddDynamic(new Dictionary<string, string>{
                    { "NUM_IDENTIDADE" , ""},
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "UF_EXPEDIDORA" , ""},
                    { "DATA_EXPEDICAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1", b6);

                #endregion

                #region M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1

                var b7 = new DynamicData();
                b7.AddDynamic(new Dictionary<string, string>{
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "NUM_IDENTIDADE" , ""},
                    { "DATA_EXPEDICAO" , ""},
                    { "UF_EXPEDIDORA" , ""},
                    { "WS_COD_PES_ATU" , ""},
                });
                b7.AddDynamic(new Dictionary<string, string>{
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "NUM_IDENTIDADE" , ""},
                    { "DATA_EXPEDICAO" , ""},
                    { "UF_EXPEDIDORA" , ""},
                    { "WS_COD_PES_ATU" , ""},
                });
                b7.AddDynamic(new Dictionary<string, string>{
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "NUM_IDENTIDADE" , ""},
                    { "DATA_EXPEDICAO" , ""},
                    { "UF_EXPEDIDORA" , ""},
                    { "WS_COD_PES_ATU" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1", b7);

                #endregion

                #region M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1

                var b8 = new DynamicData();
                b8.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_SEQ_TEL" , ""}
                });
                b8.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_SEQ_TEL" , ""}
                });
                b8.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_SEQ_TEL" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1", b8);

                #endregion

                #region M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1

                var b9 = new DynamicData();
                b9.AddDynamic(new Dictionary<string, string>{
                    { "DDI" , ""},
                    { "DDD" , ""},
                    { "NUM_FONE" , ""},
                });
                b9.AddDynamic(new Dictionary<string, string>{
                    { "DDI" , ""},
                    { "DDD" , ""},
                    { "NUM_FONE" , ""},
                });
                b9.AddDynamic(new Dictionary<string, string>{
                    { "DDI" , ""},
                    { "DDD" , ""},
                    { "NUM_FONE" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1", b9);

                #endregion

                #region M_51000_00_GRAVA_TELEFONE_DB_SELECT_1_Query1

                var b10 = new DynamicData();
                b10.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_SEQ_TEL" , ""}
                });
                b10.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_SEQ_TEL" , ""}
                });
                b10.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_SEQ_TEL" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_51000_00_GRAVA_TELEFONE_DB_SELECT_1_Query1", b10);

                #endregion

                #region M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1

                var b11 = new DynamicData();
                b11.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "IND_TEL" , ""},
                    { "WS_MAX_SEQ_TEL" , ""},
                    { "DDI" , ""},
                    { "DDD" , ""},
                    { "NUM_FONE" , ""},
                    { "SITUACAO_FONE" , ""},
                    { "COD_USUARIO" , ""},
                });
                b11.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "IND_TEL" , ""},
                    { "WS_MAX_SEQ_TEL" , ""},
                    { "DDI" , ""},
                    { "DDD" , ""},
                    { "NUM_FONE" , ""},
                    { "SITUACAO_FONE" , ""},
                    { "COD_USUARIO" , ""},
                });
                b11.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "IND_TEL" , ""},
                    { "WS_MAX_SEQ_TEL" , ""},
                    { "DDI" , ""},
                    { "DDD" , ""},
                    { "NUM_FONE" , ""},
                    { "SITUACAO_FONE" , ""},
                    { "COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1", b11);

                #endregion

                #region M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1

                var b12 = new DynamicData();
                b12.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_SEQ_EMA" , ""}
                });
                b12.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_SEQ_EMA" , ""}
                });
                b12.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_SEQ_EMA" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1", b12);

                #endregion

                #region M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1

                var b13 = new DynamicData();
                b13.AddDynamic(new Dictionary<string, string>{
                    { "EMAIL" , ""}
                });
                b13.AddDynamic(new Dictionary<string, string>{
                    { "EMAIL" , ""}
                });
                b13.AddDynamic(new Dictionary<string, string>{
                    { "EMAIL" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1", b13);

                #endregion

                #region M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1

                var b14 = new DynamicData();
                b14.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "WS_MAX_SEQ_EMA" , ""},
                    { "EMAIL" , ""},
                    { "SITUACAO_EMAIL" , ""},
                    { "COD_USUARIO" , ""},
                });
                b14.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "WS_MAX_SEQ_EMA" , ""},
                    { "EMAIL" , ""},
                    { "SITUACAO_EMAIL" , ""},
                    { "COD_USUARIO" , ""},
                });
                b14.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "WS_MAX_SEQ_EMA" , ""},
                    { "EMAIL" , ""},
                    { "SITUACAO_EMAIL" , ""},
                    { "COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1", b14);

                #endregion

                #region M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1

                var b15 = new DynamicData();
                b15.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                b15.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                b15.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1", b15);

                #endregion

                #region M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1

                var b16 = new DynamicData();
                b16.AddDynamic(new Dictionary<string, string>{
                    { "CEP" , ""}
                });
                b16.AddDynamic(new Dictionary<string, string>{
                    { "CEP" , ""}
                });
                b16.AddDynamic(new Dictionary<string, string>{
                    { "CEP" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1", b16);

                #endregion

                #region M_91000_00_INS_ENDERECO_DB_SELECT_1_Query1

                var b17 = new DynamicData();
                b17.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                b17.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                b17.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_91000_00_INS_ENDERECO_DB_SELECT_1_Query1", b17);

                #endregion

                #region M_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1

                var b18 = new DynamicData();
                b18.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "WS_MAX_OCO_END" , ""},
                    { "ENDERECO" , ""},
                    { "TIPO_ENDER" , ""},
                    { "BAIRRO" , ""},
                    { "CEP" , ""},
                    { "CIDADE" , ""},
                    { "SIGLA_UF" , ""},
                    { "SITUACAO_ENDERECO" , ""},
                    { "COD_USUARIO" , ""},
                });
                b18.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "WS_MAX_OCO_END" , ""},
                    { "ENDERECO" , ""},
                    { "TIPO_ENDER" , ""},
                    { "BAIRRO" , ""},
                    { "CEP" , ""},
                    { "CIDADE" , ""},
                    { "SIGLA_UF" , ""},
                    { "SITUACAO_ENDERECO" , ""},
                    { "COD_USUARIO" , ""},
                });
                b18.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "WS_MAX_OCO_END" , ""},
                    { "ENDERECO" , ""},
                    { "TIPO_ENDER" , ""},
                    { "BAIRRO" , ""},
                    { "CEP" , ""},
                    { "CIDADE" , ""},
                    { "SIGLA_UF" , ""},
                    { "SITUACAO_ENDERECO" , ""},
                    { "COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1", b18);

                #endregion

                #region B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1

                var b19 = new DynamicData();
                b19.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                b19.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                b19.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1", b19);

                #endregion

                #region B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1

                var b20 = new DynamicData();
                b20.AddDynamic(new Dictionary<string, string>{
                    { "CEP" , ""}
                });
                b20.AddDynamic(new Dictionary<string, string>{
                    { "CEP" , ""}
                });
                b20.AddDynamic(new Dictionary<string, string>{
                    { "CEP" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1", b20);

                #endregion

                #region B1000_00_INS_ENDERECO_DB_SELECT_1_Query1

                var b21 = new DynamicData();
                b21.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                b21.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                b21.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_OCO_END" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("B1000_00_INS_ENDERECO_DB_SELECT_1_Query1", b21);

                #endregion

                #region B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1

                var b22 = new DynamicData();
                b22.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "WS_MAX_OCO_END" , ""},
                    { "ENDERECO" , ""},
                    { "TIPO_ENDER" , ""},
                    { "BAIRRO" , ""},
                    { "CEP" , ""},
                    { "CIDADE" , ""},
                    { "SIGLA_UF" , ""},
                    { "SITUACAO_ENDERECO" , ""},
                    { "COD_USUARIO" , ""},
                });
                b22.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "WS_MAX_OCO_END" , ""},
                    { "ENDERECO" , ""},
                    { "TIPO_ENDER" , ""},
                    { "BAIRRO" , ""},
                    { "CEP" , ""},
                    { "CIDADE" , ""},
                    { "SIGLA_UF" , ""},
                    { "SITUACAO_ENDERECO" , ""},
                    { "COD_USUARIO" , ""},
                });
                b22.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_ATU" , ""},
                    { "WS_MAX_OCO_END" , ""},
                    { "ENDERECO" , ""},
                    { "TIPO_ENDER" , ""},
                    { "BAIRRO" , ""},
                    { "CEP" , ""},
                    { "CIDADE" , ""},
                    { "SIGLA_UF" , ""},
                    { "SITUACAO_ENDERECO" , ""},
                    { "COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1", b22);

                #endregion
                #endregion

                #region BI0004S_Parameters

                #region M_30000_00_PESSOA_DB_SELECT_1_Query1

                var c0 = new DynamicData();
                c0.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_004" , ""}
                });
                c0.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_004" , ""}
                });
                c0.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_004" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_30000_00_PESSOA_DB_SELECT_1_Query1", c0);

                #endregion

                #region M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1

                var c1 = new DynamicData();
                c1.AddDynamic(new Dictionary<string, string>{
                    { "PRDSIVPF_COD_PRODUTO_SIVPF" , ""},
                    { "PRDSIVPF_COD_RELAC" , ""},
                    { "PRDSIVPF_COD_EMPRESA_SIVPF" , ""},
                });
                c1.AddDynamic(new Dictionary<string, string>{
                    { "PRDSIVPF_COD_PRODUTO_SIVPF" , ""},
                    { "PRDSIVPF_COD_RELAC" , ""},
                    { "PRDSIVPF_COD_EMPRESA_SIVPF" , ""},
                });
                c1.AddDynamic(new Dictionary<string, string>{
                    { "PRDSIVPF_COD_PRODUTO_SIVPF" , ""},
                    { "PRDSIVPF_COD_RELAC" , ""},
                    { "PRDSIVPF_COD_EMPRESA_SIVPF" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1", c1);

                #endregion

                #region M_70000_00_RELAC_TIP_DB_SELECT_1_Query1

                var c2 = new DynamicData();
                c2.AddDynamic(new Dictionary<string, string>{
                    { "COD_PESSOA" , ""},
                    { "COD_RELAC" , ""},
                });
                c2.AddDynamic(new Dictionary<string, string>{
                    { "COD_PESSOA" , ""},
                    { "COD_RELAC" , ""},
                });
                c2.AddDynamic(new Dictionary<string, string>{
                    { "COD_PESSOA" , ""},
                    { "COD_RELAC" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_70000_00_RELAC_TIP_DB_SELECT_1_Query1", c2);

                #endregion

                #region M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1

                var c3 = new DynamicData();
                c3.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_004" , ""},
                    { "PRDSIVPF_COD_RELAC" , ""},
                });
                c3.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_004" , ""},
                    { "PRDSIVPF_COD_RELAC" , ""},
                });
                c3.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_PES_004" , ""},
                    { "PRDSIVPF_COD_RELAC" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1", c3);

                #endregion

                #region B0000_INS_RELAC_IDE_DB_SELECT_1_Query1

                var c4 = new DynamicData();
                c4.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_NUM_IDE" , ""}
                });
                c4.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_NUM_IDE" , ""}
                });
                c4.AddDynamic(new Dictionary<string, string>{
                    { "WS_MAX_NUM_IDE" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("B0000_INS_RELAC_IDE_DB_SELECT_1_Query1", c4);

                #endregion

                #region B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1

                var c5 = new DynamicData();
                c5.AddDynamic(new Dictionary<string, string>{
                    { "BI0004L_S_COD_IDE" , ""},
                    { "WS_COD_PES_004" , ""},
                    { "PRDSIVPF_COD_RELAC" , ""},
                    { "BI0004L_E_COD_USU" , ""},
                });
                c5.AddDynamic(new Dictionary<string, string>{
                    { "BI0004L_S_COD_IDE" , ""},
                    { "WS_COD_PES_004" , ""},
                    { "PRDSIVPF_COD_RELAC" , ""},
                    { "BI0004L_E_COD_USU" , ""},
                });
                c5.AddDynamic(new Dictionary<string, string>{
                    { "BI0004L_S_COD_IDE" , ""},
                    { "WS_COD_PES_004" , ""},
                    { "PRDSIVPF_COD_RELAC" , ""},
                    { "BI0004L_E_COD_USU" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1", c5);

                #endregion
                #endregion

                PROTIT01_Tests.Load_Parameters();

                #region P0301_05_INICIO_DB_SELECT_1_Query1

                var j1 = new DynamicData();
                j1.AddDynamic(new Dictionary<string, string>{
                { "VG113_COD_PESSOA" , ""},
                { "VG113_SEQ_PESSOA_HIST" , ""},
                { "VG113_COD_CLASSIF_RISCO" , ""},
                { "VG113_NUM_SCORE_RISCO" , ""},
                { "VG113_DTA_CLASSIF_RISCO" , ""},
                { "VG113_IND_PEND_APROVACAO" , ""},
                { "VG113_IND_DECL_AUTOMATICO" , ""},
                { "VG113_IND_ATLZ_FAIXA_RISCO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("P0301_05_INICIO_DB_SELECT_1_Query1", j1);

                #endregion

                #region P3021_05_INICIO_DB_SELECT_1_Query1

                var j2 = new DynamicData();
                j2.AddDynamic(new Dictionary<string, string>{
                { "VG110_COD_PESSOA" , ""},
                { "VG110_SEQ_PESSOA_HIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("P3021_05_INICIO_DB_SELECT_1_Query1", j2);

                #endregion

                #region M_70000_00_INICIAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_PROC" , "2024-08-30"},
                { "WS_DATA_PROC_AUX" , "2024-09-30"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_70000_00_INICIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_70000_00_INICIAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_13100_00_CLIENTE_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "300"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "300"}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_13100_00_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_13100_00_CLIENTE_DB_SELECT_1_Query1", q1);

                #endregion


                #region M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO" , ""},
                { "PRDSIVPF_COD_PLANO" , ""},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO" , ""},
                { "PRDSIVPF_COD_PLANO" , ""},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO" , ""},
                { "PRDSIVPF_COD_PLANO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
                });
                q10.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
                });
                q10.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
                });
                q10.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
                });
                q10.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1", q10);

                #endregion

                #region M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "GETPMOIM_DES_TP_MORA_IMOVEL" , ""}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1", q14);

                #endregion

                #region M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "NUM_BENEFICIARIO" , ""}
                });
                q17.AddDynamic(new Dictionary<string, string>{
                { "NUM_BENEFICIARIO" , ""}
                });
                q17.AddDynamic(new Dictionary<string, string>{
                { "NUM_BENEFICIARIO" , ""}
                });
                q17.AddDynamic(new Dictionary<string, string>{
                { "NUM_BENEFICIARIO" , ""}
                });
                q17.AddDynamic(new Dictionary<string, string>{
                { "NUM_BENEFICIARIO" , ""}
                });
                q17.AddDynamic(new Dictionary<string, string>{
                { "NUM_BENEFICIARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1", q17);

                #endregion

                #endregion
                var program = new BI1610B();
                program.Execute(BI1610I1_FILE_NAME_P, BI1610O1_FILE_NAME_P);

                //M_13130_00_CBO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["M_13130_00_CBO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("PF062_COD_CBO", out var valor) && valor.Contains("291"));
                Assert.True(envList.Count > 1);

                //M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPOFID_COD_PRODUTO_SIVPF", out var valor1) && valor1.Contains("56"));
                Assert.True(envList1.Count > 1);

                //M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("PROPSSBI_RENOVACAO_AUTOM", out var valor4) && valor4.Contains("S"));
                Assert.True(envList4.Count > 1);

                //M_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["M_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var valor5) && valor5.Contains("6165"));
                Assert.True(envList5.Count > 1);

                //M_13700_00_BENEFICIARIO_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["M_13700_00_BENEFICIARIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("NUM_BENEFICIARIO", out var valor6) && valor6.Contains("1"));
                Assert.True(envList6.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}