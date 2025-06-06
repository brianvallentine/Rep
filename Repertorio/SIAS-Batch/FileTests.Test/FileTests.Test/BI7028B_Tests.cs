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
using static Code.BI7028B;

namespace FileTests.Test
{
    [Collection("BI7028B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI7028B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , ""},
                { "SISTEMAS_DATA_MOV_5DIA" , ""},
                { "WS_DATA_ATUAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI7028B_CORIGEM

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI7028B_CORIGEM", q1);

            #endregion

            #region BI7028B_CRELAT

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_DATA_MOVIMENTO" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_COD_PESSOA" , ""},
                { "PROPOFID_DIA_DEBITO" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "PROPOFID_NOME_CONVENENTE" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_CGC_CONVENENTE" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "PROPOFID_OPCAOPAG" , ""},
                { "WS_CURSOR_FORMAPAG" , ""},
                { "WS_CURSOR_VLIOF" , ""},
                { "WS_CURSOR_VLPREMIO_LIQ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI7028B_CRELAT", q2);

            #endregion

            #region BI7028B_CVG033

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , ""},
                { "VG033_DES_ACESSORIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI7028B_CVG033", q3);

            #endregion

            #region R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FCPLANO_QTD_DIG_COMBINACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "PRODUTO_NUM_PROCESSO_SUSEP" , ""},
                { "PRODUTO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DIA_DEBITO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PESSOEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "BILCOBER_VAL_MAX_COBER_BAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1", q12);

            #endregion

            #region BI7028B_V0BENEF

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NOME_BENEFICIARIO" , ""},
                { "BENEFICI_NUM_CARTEIRINHA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI7028B_V0BENEF", q13);

            #endregion

            #region R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2300_00_CARREGA_COBMENVG_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_CARREGA_COBMENVG_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1", q16);

            #endregion

            #region R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_AP" , ""},
                { "APOLICOB_PRM_TARIFARIO_AP" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q17);

            #endregion

            #region BI7028B_CTITFD

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0TITF_NRSORTEIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI7028B_CTITFD", q18);

            #endregion

            #region R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODRELAT" , ""},
                { "WS_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R2650_LER_CAP_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WS_CABU_SORTEIO_07" , ""},
                { "CABU_COD_SUSEP_CAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2650_LER_CAP_DB_SELECT_1_Query1", q20);

            #endregion

            #region R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q21);

            #endregion

            GEJVS002_Tests.Load_Parameters();

            #endregion
        }

        [Theory]
        [InlineData("Saida_RBI7028B", "Saida_RBI7028I", "Saida_RBI7028P", "Saida_RBI7028H", "Saida_SBI7028B")]
        public static void BI7028B_Tests_TheorySemBilheteAEmitir(string RBI7028B_FILE_NAME_P, string RBI7028I_FILE_NAME_P, string RBI7028P_FILE_NAME_P, string RBI7028H_FILE_NAME_P, string SBI7028B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RBI7028B_FILE_NAME_P = $"{RBI7028B_FILE_NAME_P}_{timestamp}.txt";
            RBI7028I_FILE_NAME_P = $"{RBI7028I_FILE_NAME_P}_{timestamp}.txt";
            RBI7028P_FILE_NAME_P = $"{RBI7028P_FILE_NAME_P}_{timestamp}.txt";
            RBI7028H_FILE_NAME_P = $"{RBI7028H_FILE_NAME_P}_{timestamp}.txt";
            SBI7028B_FILE_NAME_P = $"{SBI7028B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2024-11-04"},
                    { "SISTEMAS_DATA_MOV_ABERTO_1" , "2024-11-04"},
                    { "SISTEMAS_DATA_MOV_5DIA" , "2024-10-30"},
                    { "WS_DATA_ATUAL" , "2024-11-14"},
                });
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                AppSettings.TestSet.DynamicData.Remove("BI7028B_CORIGEM");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "ARQSIVPF_SISTEMA_ORIGEM" , "1001"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                    { "ARQSIVPF_SISTEMA_ORIGEM" , "1002"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                    { "ARQSIVPF_SISTEMA_ORIGEM" , "1003"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                    { "ARQSIVPF_SISTEMA_ORIGEM" , "1004"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                    { "ARQSIVPF_SISTEMA_ORIGEM" , "1005"}
                });
                AppSettings.TestSet.DynamicData.Add("BI7028B_CORIGEM", q1);

                AppSettings.TestSet.DynamicData.Remove("BI7028B_CRELAT");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_OPERACAO" , "3" },
                    { "RELATORI_COD_USUARIO" , "BI3005B " },
                    { "RELATORI_COD_RELATORIO" , "BI3005B1" },
                    { "RELATORI_DATA_SOLICITACAO" , "2020-12-03" },
                    { "RELATORI_NUM_ENDOSSO" , "1" },
                    { "BILHETE_DATA_QUITACAO" , "2011-08-08" },
                    { "BILHETE_NUM_APOLICE" , "108102219352" },
                    { "BILHETE_NUM_BILHETE" , "95394411648" },
                    { "BILHETE_COD_CLIENTE" , "16839587" },
                    { "BILHETE_OCORR_ENDERECO" , "1" },
                    { "BILHETE_RAMO" , "81" },
                    { "BILHETE_FONTE" , "5" },
                    { "BILHETE_DATA_MOVIMENTO" , "2011-07-25" },
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "8132" },
                    { "PROPOFID_ORIGEM_PROPOSTA" , "1002" },
                    { "PROPOFID_COD_PESSOA" , "19883294" },
                    { "PROPOFID_DIA_DEBITO" , "25" },
                    { "PROPOFID_AGECTADEB" , "2855" },
                    { "PROPOFID_OPRCTADEB" , "13" },
                    { "PROPOFID_NUMCTADEB" , "12424" },
                    { "PROPOFID_DIGCTADEB" , "5" },
                    { "PROPOFID_NOME_CONVENENTE" , "0000000000000000                        " },
                    { "PROPOFID_VAL_PAGO" , "42.90" },
                    { "PROPOFID_CGC_CONVENENTE" , "100001241" },
                    { "BILHETE_OPC_COBERTURA" , "117" },
                    { "PROPOFID_OPCAOPAG" , "CONTA BANCARIA            " },
                    { "WS_CURSOR_FORMAPAG" , "1" },
                    { "WS_CURSOR_VLIOF" , "0.16000000000" },
                    { "WS_CURSOR_VLPREMIO_LIQ" , "42.74000000000" }
                });
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_OPERACAO" , "3" },
                    { "RELATORI_COD_USUARIO" , "BI3005B " },
                    { "RELATORI_COD_RELATORIO" , "BI3005B1" },
                    { "RELATORI_DATA_SOLICITACAO" , "2020-12-03" },
                    { "RELATORI_NUM_ENDOSSO" , "1" },
                    { "BILHETE_DATA_QUITACAO" , "2011-08-08" },
                    { "BILHETE_NUM_APOLICE" , "108102219352" },
                    { "BILHETE_NUM_BILHETE" , "95394411648" },
                    { "BILHETE_COD_CLIENTE" , "16839587" },
                    { "BILHETE_OCORR_ENDERECO" , "1" },
                    { "BILHETE_RAMO" , "81" },
                    { "BILHETE_FONTE" , "5" },
                    { "BILHETE_DATA_MOVIMENTO" , "2011-07-25" },
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "8132" },
                    { "PROPOFID_ORIGEM_PROPOSTA" , "1002" },
                    { "PROPOFID_COD_PESSOA" , "19883294" },
                    { "PROPOFID_DIA_DEBITO" , "25" },
                    { "PROPOFID_AGECTADEB" , "2855" },
                    { "PROPOFID_OPRCTADEB" , "13" },
                    { "PROPOFID_NUMCTADEB" , "12424" },
                    { "PROPOFID_DIGCTADEB" , "5" },
                    { "PROPOFID_NOME_CONVENENTE" , "0000000000000000                        " },
                    { "PROPOFID_VAL_PAGO" , "42.90" },
                    { "PROPOFID_CGC_CONVENENTE" , "100001241" },
                    { "BILHETE_OPC_COBERTURA" , "117" },
                    { "PROPOFID_OPCAOPAG" , "CONTA BANCARIA            " },
                    { "WS_CURSOR_FORMAPAG" , "1" },
                    { "WS_CURSOR_VLIOF" , "0.16000000000" },
                    { "WS_CURSOR_VLPREMIO_LIQ" , "42.74000000000" }
                });
                AppSettings.TestSet.DynamicData.Add("BI7028B_CRELAT", q2);

                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "FCPLANO_QTD_DIG_COMBINACAO" , "5"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                    { "FCPLANO_QTD_DIG_COMBINACAO" , "5"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                    { "FCPLANO_QTD_DIG_COMBINACAO" , "5"}
                });
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1", q4);

                AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1");
                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT1" , "52"}
                });
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT1" , "52"}
                });
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT1" , "52"}
                });
                AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1", q5);

                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , "ROSARIA MONTEIRO DA SILVEIRA            "},
                    { "CLIENTES_CGCCPF" , "4178551841"},
                    { "CLIENTES_DATA_NASCIMENTO" , "2001-05-05"},
                    { "CLIENTES_TIPO_PESSOA" , "F"},
                });
                q6.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , "ROSARIA MONTEIRO DA SILVEIRA            "},
                    { "CLIENTES_CGCCPF" , "4178551841"},
                    { "CLIENTES_DATA_NASCIMENTO" , "2001-05-05"},
                    { "CLIENTES_TIPO_PESSOA" , "F"},
                });
                q6.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , "ROSARIA MONTEIRO DA SILVEIRA            "},
                    { "CLIENTES_CGCCPF" , "4178551841"},
                    { "CLIENTES_DATA_NASCIMENTO" , "2001-05-05"},
                    { "CLIENTES_TIPO_PESSOA" , "F"},
                });
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q6);

                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1");
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "ENDERECO_ENDERECO" , "rua camboriu"},
                    { "ENDERECO_BAIRRO" , "centro"},
                    { "ENDERECO_CIDADE" , "navega"},
                    { "ENDERECO_SIGLA_UF" , "SC"},
                    { "ENDERECO_CEP" , "88830417"},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                    { "ENDERECO_ENDERECO" , "rua camboriu"},
                    { "ENDERECO_BAIRRO" , "centro"},
                    { "ENDERECO_CIDADE" , "navega"},
                    { "ENDERECO_SIGLA_UF" , "SC"},
                    { "ENDERECO_CEP" , "88830417"},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                    { "ENDERECO_ENDERECO" , "rua camboriu"},
                    { "ENDERECO_BAIRRO" , "centro"},
                    { "ENDERECO_CIDADE" , "navega"},
                    { "ENDERECO_SIGLA_UF" , "SC"},
                    { "ENDERECO_CEP" , "88830417"},
                });
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q7);

                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1");
                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_DESCR_PRODUTO" , "PREVIDENCIA PRIVADA                     "},
                    { "PRODUTO_NUM_PROCESSO_SUSEP" , "001.003403/96            "},
                    { "PRODUTO_COD_EMPRESA" , "10"},
                });
                q8.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_DESCR_PRODUTO" , "PREVIDENCIA PRIVADA                     "},
                    { "PRODUTO_NUM_PROCESSO_SUSEP" , "001.003403/96            "},
                    { "PRODUTO_COD_EMPRESA" , "10"},
                });
                q8.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_DESCR_PRODUTO" , "PREVIDENCIA PRIVADA                     "},
                    { "PRODUTO_NUM_PROCESSO_SUSEP" , "001.003403/96            "},
                    { "PRODUTO_COD_EMPRESA" , "10"},
                });
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q8);

                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1");
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_DATA_VENCIMENTO" , "2004-08-12"},
                    { "MOVDEBCE_VALOR_DEBITO" , "300"},
                    { "MOVDEBCE_DIA_DEBITO" , "0"},
                    { "MOVDEBCE_COD_AGENCIA_DEB" , "16"},
                    { "MOVDEBCE_OPER_CONTA_DEB" , "3"},
                    { "MOVDEBCE_NUM_CONTA_DEB" , "1372"},
                    { "MOVDEBCE_DIG_CONTA_DEB" , "0"},
                    { "MOVDEBCE_NUM_CARTAO" , "1051"},
                });
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q9);

                AppSettings.TestSet.DynamicData.Remove("R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1");
                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "PESSOEMA_EMAIL" , "GUS@HOT.COM"}
                });
                q11.AddDynamic(new Dictionary<string, string>{
                    { "PESSOEMA_EMAIL" , "GUS@HOT.COM"}
                });
                q11.AddDynamic(new Dictionary<string, string>{
                    { "PESSOEMA_EMAIL" , "GUS@HOT.COM"}
                });
                AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1", q11);

                #endregion
                var program = new BI7028B();
                program.Execute(RBI7028B_FILE_NAME_P, RBI7028I_FILE_NAME_P, RBI7028P_FILE_NAME_P, RBI7028H_FILE_NAME_P, SBI7028B_FILE_NAME_P);

                Assert.Contains("BI7028B ", program.GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM.Value);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("Saida_RBI7028B", "Saida_RBI7028I", "Saida_RBI7028P", "Saida_RBI7028H", "Saida_SBI7028B")]
        public static void BI7028B_Tests_Theory(string RBI7028B_FILE_NAME_P, string RBI7028I_FILE_NAME_P, string RBI7028P_FILE_NAME_P, string RBI7028H_FILE_NAME_P, string SBI7028B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RBI7028B_FILE_NAME_P = $"{RBI7028B_FILE_NAME_P}_{timestamp}.txt";
            RBI7028I_FILE_NAME_P = $"{RBI7028I_FILE_NAME_P}_{timestamp}.txt";
            RBI7028P_FILE_NAME_P = $"{RBI7028P_FILE_NAME_P}_{timestamp}.txt";
            RBI7028H_FILE_NAME_P = $"{RBI7028H_FILE_NAME_P}_{timestamp}.txt";
            SBI7028B_FILE_NAME_P = $"{SBI7028B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region BI7028B_CRELAT

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_OPERACAO" , "3" },
                    { "RELATORI_COD_USUARIO" , "BI3005B " },
                    { "RELATORI_COD_RELATORIO" , "" },
                    { "RELATORI_DATA_SOLICITACAO" , "2020-12-03" },
                    { "RELATORI_NUM_ENDOSSO" , "1" },
                    { "BILHETE_DATA_QUITACAO" , "2011-08-08" },
                    { "BILHETE_NUM_APOLICE" , "108102219352" },
                    { "BILHETE_NUM_BILHETE" , "95394411648" },
                    { "BILHETE_COD_CLIENTE" , "16839587" },
                    { "BILHETE_OCORR_ENDERECO" , "1" },
                    { "BILHETE_RAMO" , "81" },
                    { "BILHETE_FONTE" , "5" },
                    { "BILHETE_DATA_MOVIMENTO" , "2011-07-25" },
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "8132" },
                    { "PROPOFID_ORIGEM_PROPOSTA" , "0" },
                    { "PROPOFID_COD_PESSOA" , "19883294" },
                    { "PROPOFID_DIA_DEBITO" , "25" },
                    { "PROPOFID_AGECTADEB" , "2855" },
                    { "PROPOFID_OPRCTADEB" , "13" },
                    { "PROPOFID_NUMCTADEB" , "12424" },
                    { "PROPOFID_DIGCTADEB" , "5" },
                    { "PROPOFID_NOME_CONVENENTE" , "0000000000000000                        " },
                    { "PROPOFID_VAL_PAGO" , "42.90" },
                    { "PROPOFID_CGC_CONVENENTE" , "100001241" },
                    { "BILHETE_OPC_COBERTURA" , "117" },
                    { "PROPOFID_OPCAOPAG" , "CONTA BANCARIA            " },
                    { "WS_CURSOR_FORMAPAG" , "1" },
                    { "WS_CURSOR_VLIOF" , "0.16000000000" },
                    { "WS_CURSOR_VLPREMIO_LIQ" , "42.74000000000" }
                });
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_OPERACAO" , "3" },
                    { "RELATORI_COD_USUARIO" , "BI3005B " },
                    { "RELATORI_COD_RELATORIO" , "" },
                    { "RELATORI_DATA_SOLICITACAO" , "2020-12-03" },
                    { "RELATORI_NUM_ENDOSSO" , "1" },
                    { "BILHETE_DATA_QUITACAO" , "2011-08-08" },
                    { "BILHETE_NUM_APOLICE" , "108102219352" },
                    { "BILHETE_NUM_BILHETE" , "95394411648" },
                    { "BILHETE_COD_CLIENTE" , "16839587" },
                    { "BILHETE_OCORR_ENDERECO" , "1" },
                    { "BILHETE_RAMO" , "81" },
                    { "BILHETE_FONTE" , "5" },
                    { "BILHETE_DATA_MOVIMENTO" , "2011-07-25" },
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "8132" },
                    { "PROPOFID_ORIGEM_PROPOSTA" , "0" },
                    { "PROPOFID_COD_PESSOA" , "19883294" },
                    { "PROPOFID_DIA_DEBITO" , "25" },
                    { "PROPOFID_AGECTADEB" , "2855" },
                    { "PROPOFID_OPRCTADEB" , "13" },
                    { "PROPOFID_NUMCTADEB" , "12424" },
                    { "PROPOFID_DIGCTADEB" , "5" },
                    { "PROPOFID_NOME_CONVENENTE" , "0000000000000000                        " },
                    { "PROPOFID_VAL_PAGO" , "42.90" },
                    { "PROPOFID_CGC_CONVENENTE" , "100001241" },
                    { "BILHETE_OPC_COBERTURA" , "117" },
                    { "PROPOFID_OPCAOPAG" , "CONTA BANCARIA            " },
                    { "WS_CURSOR_FORMAPAG" , "1" },
                    { "WS_CURSOR_VLIOF" , "0.16000000000" },
                    { "WS_CURSOR_VLPREMIO_LIQ" , "42.74000000000" }
                });
                AppSettings.TestSet.DynamicData.Remove("BI7028B_CRELAT");
                AppSettings.TestSet.DynamicData.Add("BI7028B_CRELAT", q2);

                AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1");
                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT1" , "52"}
                });
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT1" , "52"}
                });
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT1" , "52"}
                });
                AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1", q5);

                #endregion
                #endregion
                var program = new BI7028B();
                program.Execute(RBI7028B_FILE_NAME_P, RBI7028I_FILE_NAME_P, RBI7028P_FILE_NAME_P, RBI7028H_FILE_NAME_P, SBI7028B_FILE_NAME_P);

                //sub programas
                Assert.True(program.GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM.Value.Contains("BI7028B"));

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert") || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1);

                var envList = AppSettings.TestSet.DynamicData["R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("WS_NUM_APOLICE", out var valOr) && valOr == "0108102219352");

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}