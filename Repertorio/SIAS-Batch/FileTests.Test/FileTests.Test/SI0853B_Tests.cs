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
using static Code.SI0853B;

namespace FileTests.Test
{
    [Collection("SI0853B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0853B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS

            #region R0010_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0853B_CNOVAPT

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "APOLIAUT_NUM_ITEM" , ""},
                { "APOLIAUT_ANO_FABRICACAO" , ""},
                { "APOLIAUT_ANO_MODELO" , ""},
                { "APOLIAUT_PLACA_UF" , ""},
                { "APOLIAUT_PLACA_LETRA" , ""},
                { "APOLIAUT_PLACA_NUMERO" , ""},
                { "APOLIAUT_NUM_CHASSIS" , ""},
                { "APOLIAUT_COD_CLIENTE" , ""},
                { "APOLIAUT_COD_VEICULO" , ""},
                { "APOLIAUT_COD_FABRICANTE" , ""},
                { "APOLIAUT_NUM_PRM_RESSEGURO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0853B_CNOVAPT", q1);

            #endregion

            #region SI0853B_CPPPT

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "APOLIAUT_NUM_ITEM" , ""},
                { "APOLIAUT_ANO_FABRICACAO" , ""},
                { "APOLIAUT_ANO_MODELO" , ""},
                { "APOLIAUT_PLACA_UF" , ""},
                { "APOLIAUT_PLACA_LETRA" , ""},
                { "APOLIAUT_PLACA_NUMERO" , ""},
                { "APOLIAUT_NUM_CHASSIS" , ""},
                { "APOLIAUT_COD_CLIENTE" , ""},
                { "APOLIAUT_COD_VEICULO" , ""},
                { "APOLIAUT_COD_FABRICANTE" , ""},
                { "APOLIAUT_NUM_PRM_RESSEGURO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0853B_CPPPT", q2);

            #endregion

            #region SI0853B_CPTPP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "APOLIAUT_NUM_ITEM" , ""},
                { "APOLIAUT_ANO_FABRICACAO" , ""},
                { "APOLIAUT_ANO_MODELO" , ""},
                { "APOLIAUT_PLACA_UF" , ""},
                { "APOLIAUT_PLACA_LETRA" , ""},
                { "APOLIAUT_PLACA_NUMERO" , ""},
                { "APOLIAUT_NUM_CHASSIS" , ""},
                { "APOLIAUT_COD_CLIENTE" , ""},
                { "APOLIAUT_COD_VEICULO" , ""},
                { "APOLIAUT_COD_FABRICANTE" , ""},
                { "APOLIAUT_NUM_PRM_RESSEGURO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0853B_CPTPP", q3);

            #endregion

            #region R1000_SELECT_CLIENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_SELECT_CLIENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1100_SELECT_VEICULO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VEICUDES_DESCR_VEICULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_SELECT_VEICULO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_COD_CAUSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0853B_1_t1", "SI0853B_2_t1", "SI0853B_3_t1", "SI0853B_4_t1")]
        public static void SI0853B_Tests_Theory(string NOVAPT_FILE_NAME_P, string PPPT_FILE_NAME_P, string PTPP_FILE_NAME_P, string PTPT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            NOVAPT_FILE_NAME_P = $"{NOVAPT_FILE_NAME_P}_{timestamp}.txt";
            PPPT_FILE_NAME_P = $"{PPPT_FILE_NAME_P}_{timestamp}.txt";
            PTPP_FILE_NAME_P = $"{PPPT_FILE_NAME_P}_{timestamp}.txt";
            PTPT_FILE_NAME_P = $"{PTPT_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0853B_CNOVAPT

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "123456"},
                { "SINISMES_NUM_APOL_SINISTRO" , "123456"},
                { "SINISMES_COD_FONTE" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISMES_COD_CAUSA" , "1"},
                { "SINISCAU_DESCR_CAUSA" , "X"},
                { "SINISMES_DATA_OCORRENCIA" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "APOLIAUT_NUM_ITEM" , "1"},
                { "APOLIAUT_ANO_FABRICACAO" , "2020"},
                { "APOLIAUT_ANO_MODELO" , "2020"},
                { "APOLIAUT_PLACA_UF" , "SP"},
                { "APOLIAUT_PLACA_LETRA" , "A"},
                { "APOLIAUT_PLACA_NUMERO" , "123"},
                { "APOLIAUT_NUM_CHASSIS" , "123"},
                { "APOLIAUT_COD_CLIENTE" , "1"},
                { "APOLIAUT_COD_VEICULO" , "1"},
                { "APOLIAUT_COD_FABRICANTE" , "1"},
                { "APOLIAUT_NUM_PRM_RESSEGURO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0853B_CNOVAPT");
                AppSettings.TestSet.DynamicData.Add("SI0853B_CNOVAPT", q1);

                #endregion

                #region SI0853B_CPPPT

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "123456"},
                { "SINISMES_NUM_APOL_SINISTRO" , "123456"},
                { "SINISMES_COD_FONTE" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISMES_COD_CAUSA" , "1"},
                { "SINISCAU_DESCR_CAUSA" , "X"},
                { "SINISMES_DATA_OCORRENCIA" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "APOLIAUT_NUM_ITEM" , "123"},
                { "APOLIAUT_ANO_FABRICACAO" , "2020"},
                { "APOLIAUT_ANO_MODELO" , "2020"},
                { "APOLIAUT_PLACA_UF" , "SP"},
                { "APOLIAUT_PLACA_LETRA" , "A"},
                { "APOLIAUT_PLACA_NUMERO" , "213"},
                { "APOLIAUT_NUM_CHASSIS" , "123"},
                { "APOLIAUT_COD_CLIENTE" , "1"},
                { "APOLIAUT_COD_VEICULO" , "1"},
                { "APOLIAUT_COD_FABRICANTE" , "1"},
                { "APOLIAUT_NUM_PRM_RESSEGURO" , "123456"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0853B_CPPPT");
                AppSettings.TestSet.DynamicData.Add("SI0853B_CPPPT", q2);

                #endregion

                #region SI0853B_CPTPP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "123456"},
                { "SINISMES_NUM_APOL_SINISTRO" , "123456"},
                { "SINISMES_COD_FONTE" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISMES_COD_CAUSA" , "1"},
                { "SINISCAU_DESCR_CAUSA" , "X"},
                { "SINISMES_DATA_OCORRENCIA" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "APOLIAUT_NUM_ITEM" , "1"},
                { "APOLIAUT_ANO_FABRICACAO" , "2020"},
                { "APOLIAUT_ANO_MODELO" , "2020"},
                { "APOLIAUT_PLACA_UF" , "SP"},
                { "APOLIAUT_PLACA_LETRA" , "A"},
                { "APOLIAUT_PLACA_NUMERO" , "123456"},
                { "APOLIAUT_NUM_CHASSIS" , "123"},
                { "APOLIAUT_COD_CLIENTE" , "1"},
                { "APOLIAUT_COD_VEICULO" , "1"},
                { "APOLIAUT_COD_FABRICANTE" , "1"},
                { "APOLIAUT_NUM_PRM_RESSEGURO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0853B_CPTPP");
                AppSettings.TestSet.DynamicData.Add("SI0853B_CPTPP", q3);

                #endregion

                #region R1000_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"},
                { "CLIENTES_TIPO_PESSOA" , "PF"},
                { "CLIENTES_CGCCPF" , "1234656"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_SELECT_CLIENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1100_SELECT_VEICULO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "VEICUDES_DESCR_VEICULO" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_SELECT_VEICULO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_SELECT_VEICULO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_OCORR_HISTORICO" , "1"}
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_OCORR_HISTORICO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_COD_CAUSA" , "1"}
                 });
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_COD_CAUSA" , "2"}
                 });
                AppSettings.TestSet.DynamicData.Remove("R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1", q8);

                #endregion

                #endregion
                var program = new SI0853B();
                program.Execute(NOVAPT_FILE_NAME_P, PPPT_FILE_NAME_P, PTPP_FILE_NAME_P, PTPT_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0010_SELECT_SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["SI0853B_CNOVAPT"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["SI0853B_CPPPT"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["R1000_SELECT_CLIENTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["R1100_SELECT_VEICULO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList8);

                Assert.True(program.RETURN_CODE == 00);
            }
        }



        [Theory]
        [InlineData("SI0853B_1_t2", "SI0853B_2_t2", "SI0853B_3_t2", "SI0853B_4_t2")]
        public static void SI0853B_Tests99_Theory(string NOVAPT_FILE_NAME_P, string PPPT_FILE_NAME_P, string PTPP_FILE_NAME_P, string PTPT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            NOVAPT_FILE_NAME_P = $"{NOVAPT_FILE_NAME_P}_{timestamp}.txt";
            PPPT_FILE_NAME_P = $"{PPPT_FILE_NAME_P}_{timestamp}.txt";
            PTPP_FILE_NAME_P = $"{PPPT_FILE_NAME_P}_{timestamp}.txt";
            PTPT_FILE_NAME_P = $"{PTPT_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0853B_CNOVAPT

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "123456"},
                { "SINISMES_NUM_APOL_SINISTRO" , "123456"},
                { "SINISMES_COD_FONTE" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISMES_COD_CAUSA" , "1"},
                { "SINISCAU_DESCR_CAUSA" , "X"},
                { "SINISMES_DATA_OCORRENCIA" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "APOLIAUT_NUM_ITEM" , "1"},
                { "APOLIAUT_ANO_FABRICACAO" , "2020"},
                { "APOLIAUT_ANO_MODELO" , "2020"},
                { "APOLIAUT_PLACA_UF" , "SP"},
                { "APOLIAUT_PLACA_LETRA" , "A"},
                { "APOLIAUT_PLACA_NUMERO" , "123"},
                { "APOLIAUT_NUM_CHASSIS" , "123"},
                { "APOLIAUT_COD_CLIENTE" , "1"},
                { "APOLIAUT_COD_VEICULO" , "1"},
                { "APOLIAUT_COD_FABRICANTE" , "1"},
                { "APOLIAUT_NUM_PRM_RESSEGURO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0853B_CNOVAPT");
                AppSettings.TestSet.DynamicData.Add("SI0853B_CNOVAPT", q1);

                #endregion

                #region SI0853B_CPPPT

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "123456"},
                { "SINISMES_NUM_APOL_SINISTRO" , "123456"},
                { "SINISMES_COD_FONTE" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISMES_COD_CAUSA" , "1"},
                { "SINISCAU_DESCR_CAUSA" , "X"},
                { "SINISMES_DATA_OCORRENCIA" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "APOLIAUT_NUM_ITEM" , "123"},
                { "APOLIAUT_ANO_FABRICACAO" , "2020"},
                { "APOLIAUT_ANO_MODELO" , "2020"},
                { "APOLIAUT_PLACA_UF" , "SP"},
                { "APOLIAUT_PLACA_LETRA" , "A"},
                { "APOLIAUT_PLACA_NUMERO" , "213"},
                { "APOLIAUT_NUM_CHASSIS" , "123"},
                { "APOLIAUT_COD_CLIENTE" , "1"},
                { "APOLIAUT_COD_VEICULO" , "1"},
                { "APOLIAUT_COD_FABRICANTE" , "1"},
                { "APOLIAUT_NUM_PRM_RESSEGURO" , "123456"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0853B_CPPPT");
                AppSettings.TestSet.DynamicData.Add("SI0853B_CPPPT", q2);

                #endregion

                #region SI0853B_CPTPP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "123456"},
                { "SINISMES_NUM_APOL_SINISTRO" , "123456"},
                { "SINISMES_COD_FONTE" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISMES_COD_CAUSA" , "1"},
                { "SINISCAU_DESCR_CAUSA" , "X"},
                { "SINISMES_DATA_OCORRENCIA" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "APOLIAUT_NUM_ITEM" , "1"},
                { "APOLIAUT_ANO_FABRICACAO" , "2020"},
                { "APOLIAUT_ANO_MODELO" , "2020"},
                { "APOLIAUT_PLACA_UF" , "SP"},
                { "APOLIAUT_PLACA_LETRA" , "A"},
                { "APOLIAUT_PLACA_NUMERO" , "123456"},
                { "APOLIAUT_NUM_CHASSIS" , "123"},
                { "APOLIAUT_COD_CLIENTE" , "1"},
                { "APOLIAUT_COD_VEICULO" , "1"},
                { "APOLIAUT_COD_FABRICANTE" , "1"},
                { "APOLIAUT_NUM_PRM_RESSEGURO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0853B_CPTPP");
                AppSettings.TestSet.DynamicData.Add("SI0853B_CPTPP", q3);

                #endregion

                #region R1000_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "X"},
                { "CLIENTES_TIPO_PESSOA" , "PF"},
                { "CLIENTES_CGCCPF" , "1234656"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_SELECT_CLIENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1100_SELECT_VEICULO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "VEICUDES_DESCR_VEICULO" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_SELECT_VEICULO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_SELECT_VEICULO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_OCORR_HISTORICO" , "1"}
                });

                AppSettings.TestSet.DynamicData.Remove("R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_CAUSA_ANTERIOR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINIMPSE_COD_CAUSA" , "1"}
                 });
                AppSettings.TestSet.DynamicData.Remove("R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1", q8);

                #endregion

                #endregion
                var program = new SI0853B();
                program.Execute(NOVAPT_FILE_NAME_P, PPPT_FILE_NAME_P, PTPP_FILE_NAME_P, PTPT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}