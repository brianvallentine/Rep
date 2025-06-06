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
using static Code.SI0874B;

namespace FileTests.Test
{
    [Collection("SI0874B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0874B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_LE_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R010_LE_SISTEMA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_QTDE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_2_Query1", q1);

            #endregion

            #region SI0874B_CTRAB

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_NUM_ENDOSSO" , ""},
                { "SINISMES_COD_SUBGRUPO" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_TIPO_SEGURADO" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINISMES_NUM_IRB" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_HORA_OPERACAO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0874B_CTRAB", q2);

            #endregion

            #region SI0874B_APOLICE_CREDITO_C

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , ""},
                { "APOLICRE_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0874B_APOLICE_CREDITO_C", q3);

            #endregion

            #region R120_LE_GESISFUO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GESISFUO_NUM_FATOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R120_LE_GESISFUO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_CONT_PROC_JURID" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_VLR_AVISADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CGCCPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1", q8);

            #endregion

            #region R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISCAU_GRUPO_CAUSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "RAMOS_NOME_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_CGCCPF" , ""},
                { "SINIHAB1_NOME_SEGURADO" , ""},
                { "SINIHAB1_OPERACAO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1", q12);

            #endregion

            #region R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
                { "SINCREIN_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1", q13);

            #endregion

            #region R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SINIPENH_COD_AGENCIA" , ""},
                { "SINIPENH_NUM_CONTRATO" , ""},
                { "SINIPENH_DV_CONTRATO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1", q16);

            #endregion

            #region R1010_ACESSO_APOLICE_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_ACESSO_APOLICE_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , ""},
                { "PARAMRAM_RAMO_VG" , ""},
                { "PARAMRAM_RAMO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "SINISAUT_NUM_ITEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1", q20);

            #endregion

            #region R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1", q21);

            #endregion

            #region R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_NUM_APOL_SINISTRO" , ""},
                { "SINIITEM_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1", q22);

            #endregion

            #region R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1", q23);

            #endregion

            #region R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1", q24);

            #endregion

            #region R1700_BUSCA_AGENTE_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "SIEPEMHB_COD_SUBESTIP_EMIS" , ""},
                { "SIEPEMHB_COD_AGENTE_EMIS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_BUSCA_AGENTE_DB_SELECT_1_Query1", q25);

            #endregion

            #region R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1", q26);

            #endregion

            #region R1810_BUSCA_SIVAT_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "RALCHEDO_NUM_CHEQUE_INTERNO" , ""},
                { "RALCHEDO_NUMERO_SIVAT" , ""},
                { "RALCHEDO_DV_SIVAT" , ""},
                { "RALCHEDO_DATA_SIVAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1810_BUSCA_SIVAT_DB_SELECT_1_Query1", q27);

            #endregion

            #region R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_DEPARTAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1", q28);

            #endregion

            #region R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1", q29);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("123456789")]
        public static void SI0874B_Tests_Theory(string ARQ_ANAL_FILE_NAME_P)
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
               
                #region R010_LE_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R010_LE_SISTEMA_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_QTDE" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_2_Query1", q1);

                #endregion

                #region SI0874B_CTRAB

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "123456"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "0"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "SINISMES_NUM_APOLICE" , "123456"},
                { "SINISMES_RAMO" , "10"},
                { "SINISMES_COD_PRODUTO" , "1"},
                { "SINISMES_COD_CAUSA" , "0"},
                { "SINISMES_COD_FONTE" , "0"},
                { "SINISMES_DATA_OCORRENCIA" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "SINISMES_NUM_ENDOSSO" , "123456"},
                { "SINISMES_COD_SUBGRUPO" , "0"},
                { "SINISMES_NUM_CERTIFICADO" , "123456"},
                { "SINISMES_TIPO_SEGURADO" , "1"},
                { "SINISMES_NUM_PROTOCOLO_SINI" , "12356"},
                { "SINISMES_NUM_IRB" , "123456"},
                { "SINISHIS_SIT_REGISTRO" , "0"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISHIS_HORA_OPERACAO" , "12"},
                { "SINISHIS_COD_OPERACAO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "1"},
                { "SINISHIS_VAL_OPERACAO" , "100"},
                { "SINISHIS_DATA_LIM_CORRECAO" , "2020-01-01"},
                { "SINISHIS_COD_USUARIO" , "0"},
                { "SINISHIS_NOME_FAVORECIDO" , "X"},
                { "SINISHIS_COD_PREST_SERVICO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0874B_CTRAB");
                AppSettings.TestSet.DynamicData.Add("SI0874B_CTRAB", q2);

                #endregion

                #region SI0874B_APOLICE_CREDITO_C

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , "123"},
                { "APOLICRE_CGCCPF" , "123456"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0874B_APOLICE_CREDITO_C");
                AppSettings.TestSet.DynamicData.Add("SI0874B_APOLICE_CREDITO_C", q3);

                #endregion

                #region R120_LE_GESISFUO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GESISFUO_NUM_FATOR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R120_LE_GESISFUO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_LE_GESISFUO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "SINISHIS_COD_USUARIO" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_CONT_PROC_JURID" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_VLR_AVISADO" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CGCCPF" , "1234"}
            });
                AppSettings.TestSet.DynamicData.Remove("R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1", q8);

                #endregion

                #region R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_DESCR_CAUSA" , "X"},
                { "SINISCAU_GRUPO_CAUSAS" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "RAMOS_NOME_RAMO" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_CGCCPF" , "123456"},
                { "SINIHAB1_NOME_SEGURADO" , "X"},
                { "SINIHAB1_OPERACAO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1", q12);

                #endregion

                #region R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , "1"},
                { "SINCREIN_COD_AGENCIA" , "1"},
                { "SINCREIN_COD_OPERACAO" , "1"},
                { "SINCREIN_NUM_CONTRATO" , "x"},
                { "SINCREIN_CONTRATO_DIGITO" , "1"},
                { "SINCREIN_SIT_REGISTRO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1", q13);

                #endregion

                #region R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "SINIPENH_COD_AGENCIA" , "0"},
                { "SINIPENH_NUM_CONTRATO" , "1"},
                { "SINIPENH_DV_CONTRATO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1", q16);

                #endregion

                #region R1010_ACESSO_APOLICE_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1010_ACESSO_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_ACESSO_APOLICE_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , "1"},
                { "PARAMRAM_RAMO_VG" , "1"},
                { "PARAMRAM_RAMO_AP" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "SINISAUT_NUM_ITEM" , "123456"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1", q19);


                #endregion

                #region R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1", q20);

                #endregion

                #region R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_NUM_APOL_SINISTRO" , "123456"},
                { "SINIITEM_COD_CLIENTE" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1", q22);

                #endregion

                #region R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1", q23);

                #endregion

                #region R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"},
                { "CLIENTES_CGCCPF" , "123456"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1", q24);

                #endregion

                #region R1700_BUSCA_AGENTE_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "SIEPEMHB_COD_SUBESTIP_EMIS" , "1"},
                { "SIEPEMHB_COD_AGENTE_EMIS" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_BUSCA_AGENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_BUSCA_AGENTE_DB_SELECT_1_Query1", q25);

                #endregion

                #region R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , "123456"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1", q26);

                #endregion

                #region R1810_BUSCA_SIVAT_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "RALCHEDO_NUM_CHEQUE_INTERNO" , "123456"},
                { "RALCHEDO_NUMERO_SIVAT" , "123"},
                { "RALCHEDO_DV_SIVAT" , "1"},
                { "RALCHEDO_DATA_SIVAT" , "2020-011-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1810_BUSCA_SIVAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1810_BUSCA_SIVAT_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_DEPARTAMENTO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1", q28);

                #endregion

                #region R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "X"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1", q29);

                #endregion

                #endregion
                
                var program = new SI0874B();
                program.Execute(new SI0874B_LK_LINK_PERIODICIDADE(), ARQ_ANAL_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R010_LE_SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["R010_LE_SISTEMA_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["SI0874B_CTRAB"].DynamicList;
                Assert.Empty(envList3);
                //R920_ACESSO tem que retornar 100 e SINISMES_RAMO = 0
                //var envList4 = AppSettings.TestSet.DynamicData["SI0874B_APOLICE_CREDITO_C"].DynamicList;
                //Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["R120_LE_GESISFUO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList8);

                var envList9 = AppSettings.TestSet.DynamicData["R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList9);
                //SINISMES_RAMO = 1
                var envList10 = AppSettings.TestSet.DynamicData["R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList10);

                var envList11 = AppSettings.TestSet.DynamicData["R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList11);

        
                var envList12 = AppSettings.TestSet.DynamicData["R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList12);

                //SINISMES_COD_PRODUTO <> 0
                var envList13 = AppSettings.TestSet.DynamicData["R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList13);

                var envList14 = AppSettings.TestSet.DynamicData["R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList14);

                //R920_ACESSO tem que retornar 100
                //var envList15 = AppSettings.TestSet.DynamicData["R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1"].DynamicList;
                // Assert.Empty(envList15);

                //APOLICES_RAMO_EMISSOR = 1
                //var envList16 = AppSettings.TestSet.DynamicData["R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList16);

                var envList17 = AppSettings.TestSet.DynamicData["R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList17);

                var envList18 = AppSettings.TestSet.DynamicData["R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList18);

                //APOLICES_RAMO_EMISSOR = 1
                //var envList19 = AppSettings.TestSet.DynamicData["R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList19);

                //APOLICES_RAMO_EMISSOR = 31
               // var envList20 = AppSettings.TestSet.DynamicData["R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList20);

                //var envList21 = AppSettings.TestSet.DynamicData["R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1"].DynamicList;
                //Assert.Empty(envList21);

                //APOLICES_RAMO_EMISSOR = 1
                //var envList22 = AppSettings.TestSet.DynamicData["R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1"].DynamicList;
               // Assert.Empty(envList22);
                
                //SINISMES_RAMO <> 1
                //var envList23 = AppSettings.TestSet.DynamicData["R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList23);

                //var envList24 = AppSettings.TestSet.DynamicData["R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1"].DynamicList;
                //Assert.Empty(envList24);

                var envList25 = AppSettings.TestSet.DynamicData["R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList25);

                //var envList26 = AppSettings.TestSet.DynamicData["R1700_BUSCA_AGENTE_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList26);

                var envList27 = AppSettings.TestSet.DynamicData["R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList27);

                var envList28 = AppSettings.TestSet.DynamicData["R1810_BUSCA_SIVAT_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList28);

                var envList29 = AppSettings.TestSet.DynamicData["R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList29);

                //var envList30 = AppSettings.TestSet.DynamicData["R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList30);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("123456789")]
        public static void SI0874B_Tests99_Theory(string ARQ_ANAL_FILE_NAME_P)
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

                #region R010_LE_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R010_LE_SISTEMA_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_QTDE" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_2_Query1", q1);

                #endregion

                #region SI0874B_CTRAB

                var q2 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("SI0874B_CTRAB");
                AppSettings.TestSet.DynamicData.Add("SI0874B_CTRAB", q2);

                #endregion

                #region SI0874B_APOLICE_CREDITO_C

                var q3 = new DynamicData();
                              
                AppSettings.TestSet.DynamicData.Remove("SI0874B_APOLICE_CREDITO_C");
                AppSettings.TestSet.DynamicData.Add("SI0874B_APOLICE_CREDITO_C", q3);

                #endregion

                #region R120_LE_GESISFUO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GESISFUO_NUM_FATOR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R120_LE_GESISFUO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_LE_GESISFUO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "SINISHIS_COD_USUARIO" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_CONT_PROC_JURID" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_VLR_AVISADO" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CGCCPF" , "1234"}
            });
                AppSettings.TestSet.DynamicData.Remove("R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1", q8);

                #endregion

                #region R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_DESCR_CAUSA" , "X"},
                { "SINISCAU_GRUPO_CAUSAS" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "RAMOS_NOME_RAMO" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                 AppSettings.TestSet.DynamicData.Remove("R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1", q12);

                #endregion

                #region R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1", q13);

                #endregion

                #region R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "SINIPENH_COD_AGENCIA" , "0"},
                { "SINIPENH_NUM_CONTRATO" , "1"},
                { "SINIPENH_DV_CONTRATO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1", q16);

                #endregion

                #region R1010_ACESSO_APOLICE_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1010_ACESSO_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_ACESSO_APOLICE_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                 AppSettings.TestSet.DynamicData.Remove("R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "SINISAUT_NUM_ITEM" , "123456"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1", q19);


                #endregion

                #region R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1", q20);

                #endregion

                #region R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_NUM_APOL_SINISTRO" , "123456"},
                { "SINIITEM_COD_CLIENTE" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1", q22);

                #endregion

                #region R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1", q23);

                #endregion

                #region R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"},
                { "CLIENTES_CGCCPF" , "123456"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1", q24);

                #endregion

                #region R1700_BUSCA_AGENTE_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "SIEPEMHB_COD_SUBESTIP_EMIS" , "1"},
                { "SIEPEMHB_COD_AGENTE_EMIS" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_BUSCA_AGENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_BUSCA_AGENTE_DB_SELECT_1_Query1", q25);

                #endregion

                #region R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , "123456"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1", q26);

                #endregion

                #region R1810_BUSCA_SIVAT_DB_SELECT_1_Query1

                var q27 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R1810_BUSCA_SIVAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1810_BUSCA_SIVAT_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_DEPARTAMENTO" , null}
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1", q28);

                #endregion

                #region R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "X"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1", q29);

                #endregion

                #endregion

                var program = new SI0874B();
                program.Execute(new SI0874B_LK_LINK_PERIODICIDADE(), ARQ_ANAL_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}