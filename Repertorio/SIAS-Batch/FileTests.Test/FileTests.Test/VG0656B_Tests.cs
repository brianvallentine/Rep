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
using static Code.VG0656B;

namespace FileTests.Test
{
    [Collection("VG0656B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0656B_Tests
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
                { "WHOST_DT_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0656B_C01_PROPOVA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "PROPOVA_COD_USUARIO" , ""},
                { "PROPOVA_DATA_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0656B_C01_PROPOVA", q1);

            #endregion

            #region R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q2);

            #endregion

            #region R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q3);

            #endregion

            #region R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_NOME_AGENCIA" , ""},
                { "AGENCCEF_COD_ESCNEG" , ""},
                { "ESCRINEG_REGIAO_ESCNEG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , ""},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_COD_DEVOLUCAO" , ""},
                { "DEVOLVID_DESC_DEVOLUCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_COD_ERRO" , ""},
                { "ERROSVID_DESCR_ERRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_COD_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1", q10);

            #endregion

            #region R3050_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1", q11);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("E2020010120250101", "MDETALHE", "MPRODUTO", "MTRAB", "ARQSORT1", "ARQSORT2")]
        public static void VG0656B_Tests_Theory(string WPAR_PARAMETROS_P, string MDETALHE_FILE_NAME_P, string MPRODUTO_FILE_NAME_P, string MTRAB_FILE_NAME_P, string ARQSORT1_FILE_NAME_P, string ARQSORT2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WPAR_PARAMETROS_P = $"{WPAR_PARAMETROS_P}_{timestamp}.txt";
            MDETALHE_FILE_NAME_P = $"{MDETALHE_FILE_NAME_P}_{timestamp}.txt";
            MPRODUTO_FILE_NAME_P = $"{MPRODUTO_FILE_NAME_P}_{timestamp}.txt";
            MTRAB_FILE_NAME_P = $"{MTRAB_FILE_NAME_P}_{timestamp}.txt";
            ARQSORT1_FILE_NAME_P = $"{ARQSORT1_FILE_NAME_P}_{timestamp}.txt";
            ARQSORT2_FILE_NAME_P = $"{ARQSORT2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-12-31"},
                { "WHOST_DT_CORRENTE" , "2025-03-06"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region VG0656B_C01_PROPOVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "123"},
                { "PROPOVA_COD_SUBGRUPO" , "123"},
                { "PROPOVA_COD_FONTE" , "3"},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "PROPOVA_COD_USUARIO" , ""},
                { "PROPOVA_DATA_MOVIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0656B_C01_PROPOVA");
                AppSettings.TestSet.DynamicData.Add("VG0656B_C01_PROPOVA", q1);

                #endregion

                #region R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A"},
                { "CLIENTES_CGCCPF" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q2);

                #endregion

                #region R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , "75.50"},
                { "HISCOBPR_IMP_MORNATU" , "12000.00"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q3);

                #endregion

                #region R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_NOME_AGENCIA" , "PAB INCRA, PE"},
                { "AGENCCEF_COD_ESCNEG" , "999"},
                { "ESCRINEG_REGIAO_ESCNEG" , "PONTO DE VENDA NAO IDENTIFICADO NA CEF"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "PREFERENCIAL VIDA"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "3"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "206"},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "3"},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "817"},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "0"},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "27"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , "1278877"},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , "5"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_COD_DEVOLUCAO" , "1"},
                { "DEVOLVID_DESC_DEVOLUCAO" , "DATA ESCOLHIDA PARA DEBITO FORA DO LIMITE PREESTABELECIDO"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_COD_ERRO" , ""},
                { "ERROSVID_DESCR_ERRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_COD_ERRO" , "1800"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1", q10);

                #endregion

                #region R3050_00_SELECT_FONTES_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , "RRRRRR"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1", q11);

                #endregion

                #endregion
                var program = new VG0656B();
                program.FILLER_7.WPAR_ROTINA.Value = "E";
                program.FILLER_7.WPAR_INICIO.Value = "20200101";
                program.FILLER_7.WPAR_FIM.Value = "20250101";
             
                program.Execute(new StringBasis(null, WPAR_PARAMETROS_P), MDETALHE_FILE_NAME_P, MPRODUTO_FILE_NAME_P, MTRAB_FILE_NAME_P, ARQSORT1_FILE_NAME_P, ARQSORT2_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["VG0656B_C01_PROPOVA"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList8);

                var envList9 = AppSettings.TestSet.DynamicData["R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList9);

                var envList10 = AppSettings.TestSet.DynamicData["R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList10);

              
                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("E2020010120250101", "MDETALHE", "MPRODUTO", "MTRAB", "ARQSORT1", "ARQSORT2")]
        public static void VG0656B_Tests99_Theory(string WPAR_PARAMETROS_P, string MDETALHE_FILE_NAME_P, string MPRODUTO_FILE_NAME_P, string MTRAB_FILE_NAME_P, string ARQSORT1_FILE_NAME_P, string ARQSORT2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WPAR_PARAMETROS_P = $"{WPAR_PARAMETROS_P}_{timestamp}.txt";
            MDETALHE_FILE_NAME_P = $"{MDETALHE_FILE_NAME_P}_{timestamp}.txt";
            MPRODUTO_FILE_NAME_P = $"{MPRODUTO_FILE_NAME_P}_{timestamp}.txt";
            MTRAB_FILE_NAME_P = $"{MTRAB_FILE_NAME_P}_{timestamp}.txt";
            ARQSORT1_FILE_NAME_P = $"{ARQSORT1_FILE_NAME_P}_{timestamp}.txt";
            ARQSORT2_FILE_NAME_P = $"{ARQSORT2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-12-31"},
                { "WHOST_DT_CORRENTE" , "2025-03-06"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region VG0656B_C01_PROPOVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "123"},
                { "PROPOVA_COD_SUBGRUPO" , "123"},
                { "PROPOVA_COD_FONTE" , "3"},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "PROPOVA_COD_USUARIO" , ""},
                { "PROPOVA_DATA_MOVIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0656B_C01_PROPOVA");
                AppSettings.TestSet.DynamicData.Add("VG0656B_C01_PROPOVA", q1);

                #endregion

                #region R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A"},
                { "CLIENTES_CGCCPF" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q2);

                #endregion

                #region R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , "75.50"},
                { "HISCOBPR_IMP_MORNATU" , "12000.00"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q3);

                #endregion

                #region R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_NOME_AGENCIA" , "PAB INCRA, PE"},
                { "AGENCCEF_COD_ESCNEG" , "999"},
                { "ESCRINEG_REGIAO_ESCNEG" , "PONTO DE VENDA NAO IDENTIFICADO NA CEF"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "PREFERENCIAL VIDA"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "3"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "206"},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "3"},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "817"},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "0"},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "27"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , "1278877"},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , "5"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_COD_DEVOLUCAO" , "1"},
                { "DEVOLVID_DESC_DEVOLUCAO" , "DATA ESCOLHIDA PARA DEBITO FORA DO LIMITE PREESTABELECIDO"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
              //  { "ERRPROVI_COD_ERRO" , ""},
                { "ERROSVID_DESCR_ERRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_COD_ERRO" , "1800"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1", q10);

                #endregion

                #region R3050_00_SELECT_FONTES_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , "RRRRRR"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3050_00_SELECT_FONTES_DB_SELECT_1_Query1", q11);

                #endregion

                #endregion
                var program = new VG0656B();
                program.FILLER_7.WPAR_ROTINA.Value = "E";
                program.FILLER_7.WPAR_INICIO.Value = "20200101";
                program.FILLER_7.WPAR_FIM.Value = "20250101";              
              
                program.Execute(new StringBasis(null, WPAR_PARAMETROS_P), MDETALHE_FILE_NAME_P, MPRODUTO_FILE_NAME_P, MTRAB_FILE_NAME_P, ARQSORT1_FILE_NAME_P, ARQSORT2_FILE_NAME_P);
                              

                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}