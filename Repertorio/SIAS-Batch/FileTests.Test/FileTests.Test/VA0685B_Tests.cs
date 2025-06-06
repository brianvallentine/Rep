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
using static Code.VA0685B;

namespace FileTests.Test
{
    [Collection("VA0685B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0685B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region M_0015_LER_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WSIST_DTMOVABE" , "2024-01-01"},
                { "WSIST_DTCURREN" , "2024-01-01"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0015_LER_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0016_LER_RELATORIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0016_LER_RELATORIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0017_INSERE_RELAT_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0017_INSERE_RELAT_DB_INSERT_1_Insert1", q2);

            #endregion

            #region VA0685B_CPROPOSTA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_AGE_COBRANCA" , "3189"},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , "7777772"},
                { "PROPOVA_NUM_CERTIFICADO" , "73189130325961"},
                { "PROPOVA_DATA_QUITACAO" , "2023-03-09"},
                { "PROPOVA_COD_CLIENTE" , "239763"},
                { "VGPROP_COD_USUARIO" , "VA0458B "},
                { "PROPOVA_NUM_APOLICE" , "3009300012002"},
                { "PROPOVA_COD_SUBGRUPO" , "4"},
                { "PROPOVA_DATA_MOVIMENTO" , "2023-03-14"},
                { "VGPROP_QTD_DIAS" , "5"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0685B_CPROPOSTA", q3);

            #endregion

            #region M_0035_SELECT_DEVOL_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "VGDEVO_DES_DEVOLUCAO" , "CPF RECORRENTE - INFORMAÇÕES DIVERGENTES"}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "VGDEVO_DES_DEVOLUCAO" , "CPF RECORRENTE - INFORMAÇÕES DIVERGENTES"}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "VGDEVO_DES_DEVOLUCAO" , "CPF RECORRENTE - INFORMAÇÕES DIVERGENTES"}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "VGDEVO_DES_DEVOLUCAO" , "CPF RECORRENTE - INFORMAÇÕES DIVERGENTES"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0035_SELECT_DEVOL_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_0105_SELECT_COBHIS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "COD_DEVOLUCAO" , "0"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "COD_DEVOLUCAO" , "0"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "COD_DEVOLUCAO" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0105_SELECT_COBHIS_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "MULTIPR SUPER MENSAL S/C      "}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "MULTIPR SUPER MENSAL S/C      "}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "MULTIPR SUPER MENSAL S/C      "}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "MULTIPR SUPER MENSAL S/C      "}
            });

            AppSettings.TestSet.DynamicData.Add("M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMPSEGUR" , "200000.00"},
                { "HISCOBPR_VLPREMIO" , "897.32"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMPSEGUR" , "200000.00"},
                { "HISCOBPR_VLPREMIO" , "897.32"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMPSEGUR" , "200000.00"},
                { "HISCOBPR_VLPREMIO" , "897.32"},
            });

            AppSettings.TestSet.DynamicData.Add("M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_0130_SELECT_CLIENTE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "EDSON AMORIM DA SILVA                   "},
                { "CLIENTES_CGCCPF" , "06478021568"},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "EDSON AMORIM DA SILVA                   "},
                { "CLIENTES_CGCCPF" , "06478021568"},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "EDSON AMORIM DA SILVA                   "},
                { "CLIENTES_CGCCPF" , "06478021568"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0130_SELECT_CLIENTE_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_0140_SELECT_OPCAO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "2"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "3189"},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "1288"},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "756544771"},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "5"},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "2"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "3189"},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "1288"},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "756544771"},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "5"},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "2"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "3189"},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "1288"},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "756544771"},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "5"},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0140_SELECT_OPCAO_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_0150_SELECT_ESTR_VIN_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "AGENCIAS_COD_AGENCIA" , "3189"},
                { "ESCRINEG_COD_ESCNEG" , "2637"},
                { "ESCRINEG_REGIAO_ESCNEG" , "BRASILIA SUL, DF                        "},
                { "FONTES_COD_FONTE" , "5"},
                { "FONTES_NOME_FONTE" , "BRASILIA                                "},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "AGENCIAS_COD_AGENCIA" , "3189"},
                { "ESCRINEG_COD_ESCNEG" , "2637"},
                { "ESCRINEG_REGIAO_ESCNEG" , "BRASILIA SUL, DF                        "},
                { "FONTES_COD_FONTE" , "5"},
                { "FONTES_NOME_FONTE" , "BRASILIA                                "},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "AGENCIAS_COD_AGENCIA" , "3189"},
                { "ESCRINEG_COD_ESCNEG" , "2637"},
                { "ESCRINEG_REGIAO_ESCNEG" , "BRASILIA SUL, DF                        "},
                { "FONTES_COD_FONTE" , "5"},
                { "FONTES_NOME_FONTE" , "BRASILIA                                "},
            });
            AppSettings.TestSet.DynamicData.Add("M_0150_SELECT_ESTR_VIN_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_0160_SELECT_CHEQUE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , "0"},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , "0"},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , "0"},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , "0"},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , "0"},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , "0"},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , "0"},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0160_SELECT_CHEQUE_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WSIST_DTCURREN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA0685B_1_t1", "VA0685B_2_t1")]
        public static void VA0685B_Tests_Theory(string SVA0685B_FILE_NAME_P, string ARQ_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0685B_FILE_NAME_P = $"{SVA0685B_FILE_NAME_P}_{timestamp}.txt";
            ARQ_SAIDA_FILE_NAME_P = $"{ARQ_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA0685B();
                program.Execute(SVA0685B_FILE_NAME_P, ARQ_SAIDA_FILE_NAME_P);

                //M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("WSIST_DTCURREN", out var val4r) && val4r.Contains("2024-01-01"));


                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("VA0685B_1_t2", "VA0685B_2_t2")]
        public static void VA0685B_Tests_Theory_Erro99(string SVA0685B_FILE_NAME_P, string ARQ_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0685B_FILE_NAME_P = $"{SVA0685B_FILE_NAME_P}_{timestamp}.txt";
            ARQ_SAIDA_FILE_NAME_P = $"{ARQ_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0015_LER_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("M_0015_LER_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0015_LER_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VA0685B();
                program.Execute(SVA0685B_FILE_NAME_P, ARQ_SAIDA_FILE_NAME_P);



                Assert.True(program.RETURN_CODE == 09);
            }
        }
    }
}