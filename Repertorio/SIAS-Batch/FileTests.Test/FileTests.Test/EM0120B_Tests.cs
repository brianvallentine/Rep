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
using static Code.EM0120B;

namespace FileTests.Test
{
    [Collection("EM0120B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0120B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0050_00_PROCESSA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "APOLCOBR_TIPO_COBRANCA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_PROCESSA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region EM0120B_V1EMISDIA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EDIA_NUM_APOL" , ""},
                { "V1EDIA_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0120B_V1EMISDIA", q2);

            #endregion

            #region EM0120B_V1PARCELA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , "12345"},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , "0"},
                { "V1PARC_COD_EMP" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_BCORCAP" , ""},
                { "V1ENDO_AGERCAP" , ""},
                { "V1ENDO_DACRCAP" , ""},
                { "V1ENDO_BCOCOBR" , ""},
                { "V1ENDO_AGECOBR" , ""},
                { "V1ENDO_DACCOBR" , ""},
                { "V1ENDO_QTPARCEL" , ""},
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , "18"},
                { "V1ENDO_CODPRODU" , "1803"},
                { "V1HISP_PRM_TAR" , ""},
                { "V1HISP_VAL_DESC" , ""},
                { "V1HISP_VLPRMLIQ" , ""},
                { "V1HISP_VLADIFRA" , ""},
                { "V1HISP_VLCUSEMI" , ""},
                { "V1HISP_VLIOCC" , ""},
                { "V1HISP_VLPRMTOT" , ""},
                { "V1HISP_VLPREMIO" , ""},
                { "V1HISP_DTVENCTO" , ""},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , "12346"},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , "0"},
                { "V1PARC_COD_EMP" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_BCORCAP" , ""},
                { "V1ENDO_AGERCAP" , ""},
                { "V1ENDO_DACRCAP" , ""},
                { "V1ENDO_BCOCOBR" , ""},
                { "V1ENDO_AGECOBR" , ""},
                { "V1ENDO_DACCOBR" , ""},
                { "V1ENDO_QTPARCEL" , ""},
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , "18"},
                { "V1ENDO_CODPRODU" , "1803"},
                { "V1HISP_PRM_TAR" , ""},
                { "V1HISP_VAL_DESC" , ""},
                { "V1HISP_VLPRMLIQ" , ""},
                { "V1HISP_VLADIFRA" , ""},
                { "V1HISP_VLCUSEMI" , ""},
                { "V1HISP_VLIOCC" , ""},
                { "V1HISP_VLPRMTOT" , ""},
                { "V1HISP_VLPREMIO" , ""},
                { "V1HISP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0120B_V1PARCELA", q3);

            #endregion

            #region R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WP_PRM_TAR" , "12"},
                { "WP_VAL_DESC" , "123"},
                { "WP_VLPRMLIQ" , "123"},
                { "WP_VLADIFRA" , "123"},
                { "WP_VLCUSEMI" , "123"},
                { "WP_VLIOCC" , "123"},
                { "WP_VLPRMTOT" , "123"},
                { "WP_VLPREMIO" , "123"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "WP_PRM_TAR" , "12"},
                { "WP_VAL_DESC" , "123"},
                { "WP_VLPRMLIQ" , "123"},
                { "WP_VLADIFRA" , "123"},
                { "WP_VLCUSEMI" , "123"},
                { "WP_VLIOCC" , "123"},
                { "WP_VLPRMTOT" , "123"},
                { "WP_VLPREMIO" , "123"},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WC_PRM_TAR" , "1"},
                { "WC_VAL_DESC" , "2"},
                { "WC_VLPRMLIQ" , "12"},
                { "WC_VLADIFRA" , "12"},
                { "WC_VLCUSEMI" , "32"},
                { "WC_VLIOCC" , "123"},
                { "WC_VLPRMTOT" , "123"},
                { "WC_VLPREMIO" , "123"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "WC_PRM_TAR" , "1"},
                { "WC_VAL_DESC" , "2"},
                { "WC_VLPRMLIQ" , "12"},
                { "WC_VLADIFRA" , "12"},
                { "WC_VLCUSEMI" , "32"},
                { "WC_VLIOCC" , "123"},
                { "WC_VLPRMTOT" , "123"},
                { "WC_VLPREMIO" , "123"},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_REG" , "3"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_REG" , "3"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_REG" , "3"}
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_DACPARC" , ""},
                { "V0HISP_DTMOVTO" , ""},
                { "V0HISP_OPERACAO" , ""},
                { "V0HISP_HORAOPER" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_PRM_TAR" , ""},
                { "V0HISP_VAL_DESC" , ""},
                { "V0HISP_VLPRMLIQ" , ""},
                { "V0HISP_VLADIFRA" , ""},
                { "V0HISP_VLCUSEMI" , ""},
                { "V0HISP_VLIOCC" , ""},
                { "V0HISP_VLPRMTOT" , ""},
                { "V0HISP_VLPREMIO" , ""},
                { "V0HISP_DTVENCTO" , ""},
                { "V0HISP_BCOCOBR" , ""},
                { "V0HISP_AGECOBR" , ""},
                { "V0HISP_NRAVISO" , ""},
                { "V0HISP_NRENDOCA" , ""},
                { "V0HISP_SITCONTB" , ""},
                { "V0HISP_COD_USUARIO" , ""},
                { "V0HISP_RNUDOC" , ""},
                { "V0HISP_DTQITBCO" , ""},
                { "V0HISP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R6000_00_ALTERA_V0PARCELA_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WOCORHIST" , ""},
                { "V1PARC_NUM_APOL" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V1PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_ALTERA_V0PARCELA_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_NUM_PROPOSTA_CONV" , ""},
                { "APOLIAUT_CANAL_PROPOSTA" , ""},
                { "APOLIAUT_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1", q9);

            #endregion

            #region R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WS_DT_VENCIM_20DIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1", q10);

            #endregion

            #region R6100_00_ALTERA_V0ENDOSSO_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6100_00_ALTERA_V0ENDOSSO_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R6200_00_ALTERA_V0EMISDIARIA_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6200_00_ALTERA_V0EMISDIARIA_DB_UPDATE_1_Update1", q13);

            #endregion

            #endregion
        }
        [Fact]
        public static void EM0120B_Tests_Fact()
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
                #endregion
                var program = new EM0120B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                //R5000_00_INSERT_V0HISTOPARC_Insert1

                var envList = AppSettings.TestSet.DynamicData["R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("V0HISP_NUM_APOL", out var valOr) && valOr == "0000000012345");


                //R6000_00_ALTERA_V0PARCELA_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R6000_00_ALTERA_V0PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("V1PARC_NUM_APOL", out var val2r) && valOr == "0000000012345");

                //problema de loop infinito, so encerra com 99 quando tem apolices

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void EM0120B_Tests_FactSemRegistro()
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

                #region EM0120B_V1EMISDIA

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("EM0120B_V1EMISDIA");
                AppSettings.TestSet.DynamicData.Add("EM0120B_V1EMISDIA", q2);

                #endregion
                #endregion
                var program = new EM0120B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}