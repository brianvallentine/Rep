using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.SI0048B;

namespace FileTests.Test
{
    [Collection("SI0048B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class SI0048B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1", q2);

            #endregion

            #region SI0048B_LISTA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SI0048B_LISTA", q3);

            #endregion

            #region R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "WS_CURRENT_DATE" , ""},
                { "WS_QTDE_DIAS_PENDENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_VALOR_PENDENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , ""},
                { "APOLICRE_TIPO_PESSOA" , ""},
                { "APOLICRE_CGCCPF" , ""},
                { "APOLICRE_NUM_FATURA" , ""},
                { "APOLICRE_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "APOLICRE_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SINIPENH_NUM_CONTRATO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
                { "SINIHAB1_CGCCPF" , ""},
                { "SINIHAB1_NOME_SEGURADO" , ""},
                { "SINIHAB1_DATA_NASC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "MOVSINIH_NOME_SEGURADO" , ""},
                { "MOVSINIH_CGCCPF" , ""},
                { "MOVSINIH_DTH_NASCIMENTO" , ""},
                { "MOVSINIH_NUM_CONTRATO_CEF" , ""},
                { "MOVSINIH_MATR_AGENTE" , ""},
                { "MOVSINIH_COD_COBERTURA" , ""},
                { "MOVSINIH_TSTP_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1", q18);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0048B_t1")]
        public static void SI0048B_Tests_Theory(string SI0048B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0048B1_FILE_NAME_P = $"{SI0048B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0048B_LISTA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "12456"}
            });
                AppSettings.TestSet.DynamicData.Remove("SI0048B_LISTA");
                AppSettings.TestSet.DynamicData.Add("SI0048B_LISTA", q3);

                #endregion

                #region R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_PRODUTO" , "1"},
                { "SINISMES_NUM_APOL_SINISTRO" , "123"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "SINISMES_COD_CAUSA" , "1"},
                { "SINISMES_RAMO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , "1"},
                { "SINISCAU_DESCR_CAUSA" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "WS_CURRENT_DATE" , "2020-01-01"},
                { "WS_QTDE_DIAS_PENDENTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_VALOR_PENDENTE" , "100"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , "1"},
                { "SINCREIN_COD_AGENCIA" , "2"},
                { "SINCREIN_COD_OPERACAO" , "3"},
                { "SINCREIN_NUM_CONTRATO" , "12"},
                { "SINCREIN_CONTRATO_DIGITO" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , "1"},
                { "APOLICRE_TIPO_PESSOA" , "2"},
                { "APOLICRE_CGCCPF" , "3"},
                { "APOLICRE_NUM_FATURA" , "4"},
                { "APOLICRE_DATA_INIVIGENCIA" , "5"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"},
                { "APOLICRE_TIPO_PESSOA" , "F"},
                { "CLIENTES_CGCCPF" , "123456"},
                { "CLIENTES_DATA_NASCIMENTO" , "2020-10-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1", q12);
                #endregion

                #region R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"},
                { "CLIENTES_TIPO_PESSOA" , "F"},
                { "CLIENTES_CGCCPF" , "123456"},
                { "CLIENTES_DATA_NASCIMENTO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "SINIPENH_NUM_CONTRATO" , "236"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1", q14);

                #endregion

                #region R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , "4"},
                { "SINIHAB1_PONTO_VENDA" , "1"},
                { "SINIHAB1_NUM_CONTRATO" , "123"},
                { "SINIHAB1_CGCCPF" , "123456"},
                { "SINIHAB1_NOME_SEGURADO" , "x"},
                { "SINIHAB1_DATA_NASC" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "MOVSINIH_NOME_SEGURADO" , "X"},
                { "MOVSINIH_CGCCPF" , "123456"},
                { "MOVSINIH_DTH_NASCIMENTO" , "2020-01-01"},
                { "MOVSINIH_NUM_CONTRATO_CEF" , "123465"},
                { "MOVSINIH_MATR_AGENTE" , "123"},
                { "MOVSINIH_COD_COBERTURA" , "1"},
                { "MOVSINIH_TSTP_SITUACAO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1", q18);

                #endregion

                #endregion
                var program = new SI0048B();
                program.Execute(SI0048B1_FILE_NAME_P);


                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                #region R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1

                var envList1 = AppSettings.TestSet.DynamicData["R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO) && SISTEMAS_DATA_MOV_ABERTO == "2020-01-01");

                #endregion

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0048B_t2")]
        public static void SI0048B_Tests99_Theory(string SI0048B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0048B1_FILE_NAME_P = $"{SI0048B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0048B_LISTA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "12456"}
            });
                AppSettings.TestSet.DynamicData.Remove("SI0048B_LISTA");
                AppSettings.TestSet.DynamicData.Add("SI0048B_LISTA", q3);

                #endregion

                #region R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , "1"},
                { "SINISCAU_DESCR_CAUSA" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "WS_CURRENT_DATE" , "2020-01-01"},
                { "WS_QTDE_DIAS_PENDENTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_VALOR_PENDENTE" , "100"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , "1"},
                { "SINCREIN_COD_AGENCIA" , "2"},
                { "SINCREIN_COD_OPERACAO" , "3"},
                { "SINCREIN_NUM_CONTRATO" , "12"},
                { "SINCREIN_CONTRATO_DIGITO" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , "1"},
                { "APOLICRE_TIPO_PESSOA" , "2"},
                { "APOLICRE_CGCCPF" , "3"},
                { "APOLICRE_NUM_FATURA" , "4"},
                { "APOLICRE_DATA_INIVIGENCIA" , "5"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"},
                { "APOLICRE_TIPO_PESSOA" , "F"},
                { "CLIENTES_CGCCPF" , "123456"},
                { "CLIENTES_DATA_NASCIMENTO" , "2020-10-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1", q12);
                #endregion

                #region R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"},
                { "CLIENTES_TIPO_PESSOA" , "F"},
                { "CLIENTES_CGCCPF" , "123456"},
                { "CLIENTES_DATA_NASCIMENTO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "SINIPENH_NUM_CONTRATO" , "236"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1", q14);

                #endregion

                #region R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , "4"},
                { "SINIHAB1_PONTO_VENDA" , "1"},
                { "SINIHAB1_NUM_CONTRATO" , "123"},
                { "SINIHAB1_CGCCPF" , "123456"},
                { "SINIHAB1_NOME_SEGURADO" , "x"},
                { "SINIHAB1_DATA_NASC" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "MOVSINIH_NOME_SEGURADO" , "X"},
                { "MOVSINIH_CGCCPF" , "123456"},
                { "MOVSINIH_DTH_NASCIMENTO" , "2020-01-01"},
                { "MOVSINIH_NUM_CONTRATO_CEF" , "123465"},
                { "MOVSINIH_MATR_AGENTE" , "123"},
                { "MOVSINIH_COD_COBERTURA" , "1"},
                { "MOVSINIH_TSTP_SITUACAO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1", q18);

                #endregion

                #endregion
                
                var program = new SI0048B();
                program.Execute(SI0048B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}