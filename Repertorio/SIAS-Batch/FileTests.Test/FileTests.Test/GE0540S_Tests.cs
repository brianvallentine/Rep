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
using static Code.GE0540S;
using Sias.Geral.DB2.GE0540S;

namespace FileTests.Test
{
    [Collection("GE0540S_Tests")]
    //desativado
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0540S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_Query1", q0);

            #endregion

            #region R0210_00_SELECT_APOLCOBR_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "APOLCOBR_COD_AGENCIA_DEB" , ""},
                { "APOLCOBR_OPER_CONTA_DEB" , ""},
                { "APOLCOBR_NUM_CONTA_DEB" , ""},
                { "APOLCOBR_DIG_CONTA_DEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_SELECT_APOLCOBR_Query1", q1);

            #endregion

            #region R0212_00_SELECT_APOLCOBR_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "APOLCOBR_COD_AGENCIA_DEB" , ""},
                { "APOLCOBR_OPER_CONTA_DEB" , ""},
                { "APOLCOBR_NUM_CONTA_DEB" , ""},
                { "APOLCOBR_DIG_CONTA_DEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0212_00_SELECT_APOLCOBR_Query1", q2);

            #endregion

            #region R0215_00_SELECT_BILHETE_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_COD_AGENCIA_DEB" , ""},
                { "BILHETE_OPERACAO_CONTA_DEB" , ""},
                { "BILHETE_NUM_CONTA_DEB" , ""},
                { "BILHETE_DIG_CONTA_DEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0215_00_SELECT_BILHETE_Query1", q3);

            #endregion

            #region R0216_00_SELECT_GE381_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE381_COD_BCO" , "104"},
                { "GE381_COD_AGENCIA" , "0001"},
                { "GE381_COD_AGENCIA_DV" , "1"},
                { "GE381_COD_OPERACAO" , "1"},
                { "GE381_NUM_CONTA" , "1454252"},
                { "GE381_NUM_CONTA_DV1" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R0216_00_SELECT_GE381_Query1", q4);

            #endregion

            #region R0220_00_SELECT_AGENCCEF_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_AGENCIA" , ""},
                { "AGENCCEF_NOME_AGENCIA" , ""},
                { "AGENCCEF_COD_SUREG" , ""},
                { "UNIDACEF_ENDERECO" , ""},
                { "UNIDACEF_BAIRRO" , ""},
                { "UNIDACEF_CIDADE" , ""},
                { "UNIDACEF_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_SELECT_AGENCCEF_Query1", q5);

            #endregion

            #region R0250_00_SELECT_AGENCIAS_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "AGENCIAS_COD_BANCO" , ""},
                { "AGENCIAS_COD_AGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_AGENCIAS_Query1", q6);

            #endregion

            #region R0270_00_INSERT_AGENCIAS_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "AGENCIAS_COD_BANCO" , ""},
                { "AGENCIAS_COD_AGENCIA" , ""},
                { "AGENCIAS_DAC_AGENCIA" , ""},
                { "AGENCIAS_NOME_AGENCIA" , ""},
                { "AGENCIAS_CIDADE" , ""},
                { "AGENCIAS_SIGLA_UF" , ""},
                { "AGENCIAS_ENDERECO" , ""},
                { "AGENCIAS_TELEFONE" , ""},
                { "AGENCIAS_DDD" , ""},
                { "AGENCIAS_FAX" , ""},
                { "AGENCIAS_TELEX" , ""},
                { "AGENCIAS_CEP" , ""},
                { "AGENCIAS_TIPO_CONTA" , ""},
                { "AGENCIAS_NUM_CTA_CORRENTE" , ""},
                { "AGENCIAS_DAC_CTA_CORRENTE" , ""},
                { "AGENCIAS_SIT_REGISTRO" , ""},
                { "AGENCIAS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0270_00_INSERT_AGENCIAS_Insert1", q7);

            #endregion

            #region R0310_00_SELECT_APOLICES_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""},
                { "APOLICES_ORGAO_EMISSOR" , "110"},
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_APOLICES_Query1", q8);

            #endregion

            #region R0315_00_SELECT_APOLIAUT_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0315_00_SELECT_APOLIAUT_Query1", q9);

            #endregion

            #region R0320_00_SELECT_ENDOSSOS_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , "53"},
                { "ENDOSSOS_COD_PRODUTO" , "5302"},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_SELECT_ENDOSSOS_Query1", q10);

            #endregion

            #region R0330_00_SELECT_CLIENTES_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_CLIENTES_Query1", q11);

            #endregion

            #region R0340_00_SELECT_ENDERECO_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , ""},
                { "ENDERECO_COD_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_DES_COMPLEMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_SELECT_ENDERECO_Query1", q12);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0540S_Tests_Fact_PessoaFisica()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                GE0500B_Tests.Load_Parameters();
                //GE0501B_Tests.Load_Parameters();
                GE0502B_Tests.Load_Parameters();
                GE0503B_Tests.Load_Parameters();
                GE0550B_Tests.Load_Parameters();   

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region param
                var inputParam = new GE0540S_WPARAMETROS()
                {
                    WPARM_NUMAPOL = new IntBasis()
                    {
                        Pic = new PIC("S9", "13", "S9(13)"),
                        Value = 1000790324
                    },
                    WPARM_NRENDOS = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 1
                    },
                    WPARM_PROGRAMA = new StringBasis()
                    {
                        Pic = new PIC("X", "8", "X(08)."),
                        Value = "GE0540S"
                    },
                };
                #endregion
                #region R0250_00_SELECT_AGENCIAS_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0250_00_SELECT_AGENCIAS_Query1");
                AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_AGENCIAS_Query1", q6);

                #endregion
                #region R0330_00_SELECT_CLIENTES_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""},
                { "CLIENTES_NOME_RAZAO" , "JOSE DA SILVA"},
                { "CLIENTES_TIPO_PESSOA" , "F"},
                { "CLIENTES_CGCCPF" , "03574845928"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0330_00_SELECT_CLIENTES_Query1");
                AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_CLIENTES_Query1", q11);

                #endregion
                #endregion
                var program = new GE0540S();
                program.Execute(inputParam);

                Assert.True(program.LK_PF_PARAMETRO.LK_PF_NUM_CPF == "035748459");
                Assert.True(program.LK_PF_PARAMETRO.LK_PF_NUM_DV_CPF == "0028");
                Assert.True(program.WPARAMETROS.WPARM_SQLCODE == 0);
            }
        }
        [Fact]
        public static void GE0540S_Tests_Fact_PessoaJuridica()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                //GE0500B_Tests.Load_Parameters();
                GE0501B_Tests.Load_Parameters();
                GE0502B_Tests.Load_Parameters();
                GE0503B_Tests.Load_Parameters();
                GE0550B_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region param
                var inputParam = new GE0540S_WPARAMETROS()
                {
                    WPARM_NUMAPOL = new IntBasis()
                    {
                        Pic = new PIC("S9", "13", "S9(13)"),
                        Value = 1000790324
                    },
                    WPARM_NRENDOS = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 1
                    },
                    WPARM_PROGRAMA = new StringBasis()
                    {
                        Pic = new PIC("X", "8", "X(08)."),
                        Value = "GE0540S"
                    },
                };
                #endregion
                #region R0250_00_SELECT_AGENCIAS_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0250_00_SELECT_AGENCIAS_Query1");
                AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_AGENCIAS_Query1", q6);

                #endregion
                #region R0330_00_SELECT_CLIENTES_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "79"},
                //{ "CLIENTES_NOME_RAZAO" , "AAAAAAAAAA                                                                                                                                                                                              "},
                { "CLIENTES_NOME_RAZAO" , "EMPREENDIMENTOS IMOBILIARIOS FENIX"},
                { "CLIENTES_TIPO_PESSOA" , "J"},
                { "CLIENTES_CGCCPF" , "96182387000113"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0330_00_SELECT_CLIENTES_Query1");
                AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_CLIENTES_Query1", q11);

                #endregion
                #endregion
                var program = new GE0540S();
                program.Execute(inputParam);

                Assert.True(program.LK_PJ_PARAMETRO.LK_PJ_NUM_CNPJ == "096182387");
                Assert.True(program.LK_PJ_PARAMETRO.LK_PJ_NUM_DV_CNPJ == "0013");
                Assert.True(program.WPARAMETROS.WPARM_SQLCODE == 0);
            }
        }
        [Fact]
        public static void GE0540S_Tests_Fact_InsertAgencias_PessoaJuridica()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                //GE0500B_Tests.Load_Parameters();
                GE0501B_Tests.Load_Parameters();
                GE0502B_Tests.Load_Parameters();
                GE0503B_Tests.Load_Parameters();
                GE0550B_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region param
                var inputParam = new GE0540S_WPARAMETROS()
                {
                    WPARM_NUMAPOL = new IntBasis()
                    {
                        Pic = new PIC("S9", "13", "S9(13)"),
                        Value = 1000790324
                    },
                    WPARM_NRENDOS = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 1
                    },
                    WPARM_PROGRAMA = new StringBasis()
                    {
                        Pic = new PIC("X", "8", "X(08)."),
                        Value = "GE0540S"
                    },
                };
                #endregion
                #region R0250_00_SELECT_AGENCIAS_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0250_00_SELECT_AGENCIAS_Query1");
                AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_AGENCIAS_Query1", q6);

                #endregion
                #region R0330_00_SELECT_CLIENTES_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "79"},
                //{ "CLIENTES_NOME_RAZAO" , "AAAAAAAAAA                                                                                                                                                                                              "},
                { "CLIENTES_NOME_RAZAO" , "EMPREENDIMENTOS IMOBILIARIOS FENIX"},
                { "CLIENTES_TIPO_PESSOA" , "J"},
                { "CLIENTES_CGCCPF" , "96182387000113"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0330_00_SELECT_CLIENTES_Query1");
                AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_CLIENTES_Query1", q11);

                #endregion
                #region R0310_00_SELECT_APOLICES_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""},
                { "APOLICES_ORGAO_EMISSOR" , "11"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0310_00_SELECT_APOLICES_Query1");
                AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_APOLICES_Query1", q8);

                #endregion

                #region R0210_00_SELECT_APOLCOBR_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "APOLCOBR_COD_AGENCIA_DEB" , "104"},
                { "APOLCOBR_OPER_CONTA_DEB" , "1"},
                { "APOLCOBR_NUM_CONTA_DEB" , "1548789"},
                { "APOLCOBR_DIG_CONTA_DEB" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0210_00_SELECT_APOLCOBR_Query1");
                AppSettings.TestSet.DynamicData.Add("R0210_00_SELECT_APOLCOBR_Query1", q1);

                #endregion
                #endregion
                var program = new GE0540S();
                program.Execute(inputParam);

                Assert.True(program.LK_PJ_PARAMETRO.LK_PJ_NUM_CNPJ == "096182387");
                Assert.True(program.LK_PJ_PARAMETRO.LK_PJ_NUM_DV_CNPJ == "0013");
                Assert.True(program.WPARAMETROS.WPARM_SQLCODE == 0);
                
                //R0270_00_INSERT_AGENCIAS_Insert1
                var envList = AppSettings.TestSet.DynamicData["R0270_00_INSERT_AGENCIAS_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("AGENCIAS_COD_BANCO", out var val0r) && val0r.Contains("0104"));
            }
        }
    }
}