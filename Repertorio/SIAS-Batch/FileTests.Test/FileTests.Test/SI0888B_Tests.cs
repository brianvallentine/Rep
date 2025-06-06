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
using static Code.SI0888B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0888B_Tests")]
    public class SI0888B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0888B_CR_ESTORNO

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "GESISFUO_IDE_SISTEMA" , ""},
                { "GESISFUO_COD_FUNCAO" , ""},
                { "GESISFUO_IDE_SISTEMA_OPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0888B_CR_ESTORNO", q0);

            #endregion

            #region SI0888B_CR_APOLICRE

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , ""},
                { "APOLICRE_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0888B_CR_APOLICRE", q1);

            #endregion

            #region R10_PROCESSA_DATA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R10_PROCESSA_DATA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R31000_SEGURADO_HABIT_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_NOME_SEGURADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31000_SEGURADO_HABIT_DB_SELECT_1_Query1", q3);

            #endregion

            #region R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1", q4);

            #endregion

            #region R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R310200_SEGURADO_ITEM_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R310200_SEGURADO_ITEM_DB_SELECT_1_Query1", q6);

            #endregion

            #region R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R31100_LE_SINISHIS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R31100_LE_SINISHIS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R31110_PROC_AGENCIA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_AGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31110_PROC_AGENCIA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R31110_PROC_AGENCIA_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_PONTO_VENDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31110_PROC_AGENCIA_DB_SELECT_2_Query1", q10);

            #endregion

            #region R31120_PROC_CHEQUE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31120_PROC_CHEQUE_DB_SELECT_1_Query1", q11);

            #endregion

            #region R31110_PROC_AGENCIA_DB_SELECT_3_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINIPENH_COD_AGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31110_PROC_AGENCIA_DB_SELECT_3_Query1", q12);

            #endregion

            #region R31130_PROC_SIVAT_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "RALCHEDO_NUMERO_SIVAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31130_PROC_SIVAT_DB_SELECT_1_Query1", q13);

            #endregion

            #region R31140_PROC_SICOV_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_CARTAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31140_PROC_SICOV_DB_SELECT_1_Query1", q14);

            #endregion

            #region R31140_PROC_SICOV_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31140_PROC_SICOV_DB_SELECT_2_Query1", q15);

            #endregion

            #region R31150_LE_AGTABCH1_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "AGTABCH1_DESCRICAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31150_LE_AGTABCH1_DB_SELECT_1_Query1", q16);

            #endregion

            #region R31140_PROC_SICOV_DB_SELECT_3_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_CARTAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31140_PROC_SICOV_DB_SELECT_3_Query1", q17);

            #endregion

            #region R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1", q18);

            #endregion

            #region R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1", q19);

            #endregion

            #region R340_CALENDARIO_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "HOST_DTH_ULT_DIA_MES" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R340_CALENDARIO_DB_SELECT_1_Query1", q20);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0888B_t1")]
        public static void SI0888B_Tests_Theory(string ARQESTOR_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQESTOR_FILE_NAME_P = $"{ARQESTOR_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region SI0888B_CR_ESTORNO

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISHIS_NUM_APOLICE" , ""},
                    { "SINISHIS_COD_USUARIO" , ""},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "GESISFUO_IDE_SISTEMA" , ""},
                    { "GESISFUO_COD_FUNCAO" , ""},
                    { "GESISFUO_IDE_SISTEMA_OPER" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0888B_CR_ESTORNO");
                AppSettings.TestSet.DynamicData.Add("SI0888B_CR_ESTORNO", q0);

                #endregion

                #region SI0888B_CR_APOLICRE

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "APOLICRE_PROPRIET" , ""},
                    { "APOLICRE_DATA_INIVIGENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0888B_CR_APOLICRE");
                AppSettings.TestSet.DynamicData.Add("SI0888B_CR_APOLICRE", q1);

                #endregion

                #region R10_PROCESSA_DATA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "HOST_MES_MOV_ABERTO" , ""},
                    { "HOST_ANO_MOV_ABERTO" , ""},
                    { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R10_PROCESSA_DATA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R10_PROCESSA_DATA_DB_SELECT_1_Query1", q2);

                #endregion

                #region R31000_SEGURADO_HABIT_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SINIHAB1_NOME_SEGURADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31000_SEGURADO_HABIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31000_SEGURADO_HABIT_DB_SELECT_1_Query1", q3);

                #endregion

                #region R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SINCREIN_COD_SUREG" , ""},
                    { "SINCREIN_COD_AGENCIA" , ""},
                    { "SINCREIN_COD_OPERACAO" , ""},
                    { "SINCREIN_NUM_CONTRATO" , ""},
                    { "SINCREIN_CONTRATO_DIGITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1", q4);

                #endregion

                #region R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R310200_SEGURADO_ITEM_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINIITEM_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R310200_SEGURADO_ITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R310200_SEGURADO_ITEM_DB_SELECT_1_Query1", q6);

                #endregion

                #region R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R31100_LE_SINISHIS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , ""},
                    { "SINISHIS_DATA_MOVIMENTO" , ""},
                    { "GEOPERAC_DES_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R31100_LE_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31100_LE_SINISHIS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R31110_PROC_AGENCIA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "SINCREIN_COD_AGENCIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31110_PROC_AGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31110_PROC_AGENCIA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R31110_PROC_AGENCIA_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SINIHAB1_PONTO_VENDA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31110_PROC_AGENCIA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R31110_PROC_AGENCIA_DB_SELECT_2_Query1", q10);

                #endregion

                #region R31120_PROC_CHEQUE_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31120_PROC_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31120_PROC_CHEQUE_DB_SELECT_1_Query1", q11);

                #endregion

                #region R31110_PROC_AGENCIA_DB_SELECT_3_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "SINIPENH_COD_AGENCIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31110_PROC_AGENCIA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R31110_PROC_AGENCIA_DB_SELECT_3_Query1", q12);

                #endregion

                #region R31130_PROC_SIVAT_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "RALCHEDO_NUMERO_SIVAT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31130_PROC_SIVAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31130_PROC_SIVAT_DB_SELECT_1_Query1", q13);

                #endregion

                #region R31140_PROC_SICOV_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_NUM_CARTAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31140_PROC_SICOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31140_PROC_SICOV_DB_SELECT_1_Query1", q14);

                #endregion

                #region R31140_PROC_SICOV_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31140_PROC_SICOV_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R31140_PROC_SICOV_DB_SELECT_2_Query1", q15);

                #endregion

                #region R31150_LE_AGTABCH1_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "AGTABCH1_DESCRICAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31150_LE_AGTABCH1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31150_LE_AGTABCH1_DB_SELECT_1_Query1", q16);

                #endregion

                #region R31140_PROC_SICOV_DB_SELECT_3_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_NUM_CARTAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31140_PROC_SICOV_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R31140_PROC_SICOV_DB_SELECT_3_Query1", q17);

                #endregion

                #region R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_DESCR_PRODUTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1", q18);

                #endregion

                #region R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R340_CALENDARIO_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "HOST_DTH_ULT_DIA_MES" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R340_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R340_CALENDARIO_DB_SELECT_1_Query1", q20);

                #endregion

                #endregion
                var program = new SI0888B();
                program.Execute(ARQESTOR_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0888B_t2")]
        public static void SI0888B_Tests_TheoryReturn99(string ARQESTOR_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQESTOR_FILE_NAME_P = $"{ARQESTOR_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region SI0888B_CR_ESTORNO

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISHIS_NUM_APOLICE" , ""},
                    { "SINISHIS_COD_USUARIO" , ""},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "GESISFUO_IDE_SISTEMA" , ""},
                    { "GESISFUO_COD_FUNCAO" , ""},
                    { "GESISFUO_IDE_SISTEMA_OPER" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0888B_CR_ESTORNO");
                AppSettings.TestSet.DynamicData.Add("SI0888B_CR_ESTORNO", q0);

                #endregion

                #region SI0888B_CR_APOLICRE

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "APOLICRE_PROPRIET" , ""},
                    { "APOLICRE_DATA_INIVIGENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0888B_CR_APOLICRE");
                AppSettings.TestSet.DynamicData.Add("SI0888B_CR_APOLICRE", q1);

                #endregion

                #region R10_PROCESSA_DATA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "HOST_MES_MOV_ABERTO" , ""},
                    { "HOST_ANO_MOV_ABERTO" , ""},
                    { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R10_PROCESSA_DATA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R10_PROCESSA_DATA_DB_SELECT_1_Query1", q2);

                #endregion

                #region R31000_SEGURADO_HABIT_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SINIHAB1_NOME_SEGURADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31000_SEGURADO_HABIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31000_SEGURADO_HABIT_DB_SELECT_1_Query1", q3);

                #endregion

                #region R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    
                });
                AppSettings.TestSet.DynamicData.Remove("R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1", q4);

                #endregion

                #region R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R310200_SEGURADO_ITEM_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINIITEM_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R310200_SEGURADO_ITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R310200_SEGURADO_ITEM_DB_SELECT_1_Query1", q6);

                #endregion

                #region R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R31100_LE_SINISHIS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , ""},
                    { "SINISHIS_DATA_MOVIMENTO" , ""},
                    { "GEOPERAC_DES_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R31100_LE_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31100_LE_SINISHIS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R31110_PROC_AGENCIA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "SINCREIN_COD_AGENCIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31110_PROC_AGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31110_PROC_AGENCIA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R31110_PROC_AGENCIA_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SINIHAB1_PONTO_VENDA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31110_PROC_AGENCIA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R31110_PROC_AGENCIA_DB_SELECT_2_Query1", q10);

                #endregion

                #region R31120_PROC_CHEQUE_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31120_PROC_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31120_PROC_CHEQUE_DB_SELECT_1_Query1", q11);

                #endregion

                #region R31110_PROC_AGENCIA_DB_SELECT_3_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "SINIPENH_COD_AGENCIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31110_PROC_AGENCIA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R31110_PROC_AGENCIA_DB_SELECT_3_Query1", q12);

                #endregion

                #region R31130_PROC_SIVAT_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "RALCHEDO_NUMERO_SIVAT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31130_PROC_SIVAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31130_PROC_SIVAT_DB_SELECT_1_Query1", q13);

                #endregion

                #region R31140_PROC_SICOV_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_NUM_CARTAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31140_PROC_SICOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31140_PROC_SICOV_DB_SELECT_1_Query1", q14);

                #endregion

                #region R31140_PROC_SICOV_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31140_PROC_SICOV_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R31140_PROC_SICOV_DB_SELECT_2_Query1", q15);

                #endregion

                #region R31150_LE_AGTABCH1_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "AGTABCH1_DESCRICAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31150_LE_AGTABCH1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31150_LE_AGTABCH1_DB_SELECT_1_Query1", q16);

                #endregion

                #region R31140_PROC_SICOV_DB_SELECT_3_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_NUM_CARTAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R31140_PROC_SICOV_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R31140_PROC_SICOV_DB_SELECT_3_Query1", q17);

                #endregion

                #region R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_DESCR_PRODUTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1", q18);

                #endregion

                #region R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R340_CALENDARIO_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "HOST_DTH_ULT_DIA_MES" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R340_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R340_CALENDARIO_DB_SELECT_1_Query1", q20);

                #endregion

                #endregion
                var program = new SI0888B();
                program.Execute(ARQESTOR_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}