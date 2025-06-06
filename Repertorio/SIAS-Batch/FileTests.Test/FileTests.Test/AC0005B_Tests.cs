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
using static Code.AC0005B;

namespace FileTests.Test
{
    [Collection("AC0005B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AC0005B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region AC0005B_V0HISTOPARC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_OPERACAO" , ""},
                { "V0HISP_DTMOVTO" , ""},
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
                { "V0HISP_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0005B_V0HISTOPARC", q2);

            #endregion

            #region AC0005B_V1HISTOPARC

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_NUM_APOL" , ""},
                { "V1HISP_NRENDOS" , ""},
                { "V1HISP_NRPARCEL" , ""},
                { "V1HISP_OCORHIST" , ""},
                { "V1HISP_OPERACAO" , ""},
                { "V1HISP_DTMOVTO" , ""},
                { "V1HISP_PRM_TAR" , ""},
                { "V1HISP_VAL_DESC" , ""},
                { "V1HISP_VLPRMLIQ" , ""},
                { "V1HISP_VLADIFRA" , ""},
                { "V1HISP_VLCUSEMI" , ""},
                { "V1HISP_VLIOCC" , ""},
                { "V1HISP_VLPRMTOT" , ""},
                { "V1HISP_VLPREMIO" , ""},
                { "V1HISP_DTVENCTO" , ""},
                { "V1HISP_BCOCOBR" , ""},
                { "V1HISP_AGECOBR" , ""},
                { "V1HISP_NRAVISO" , ""},
                { "V1HISP_NRENDOCA" , ""},
                { "V1HISP_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0005B_V1HISTOPARC", q3);

            #endregion

            #region R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_CORRECAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0COSC_NUM_APOL" , ""},
                { "V0COSC_NRENDOS" , ""},
                { "V0COSC_CODLIDER" , ""},
                { "V0COSC_ORDLIDER" , ""},
                { "V0COSC_PCCOMCOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , ""},
                { "V0PARC_NRENDOS" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_PRM_TAR" , ""},
                { "V0PARC_VAL_DESC" , ""},
                { "V0PARC_OTNPRLIQ" , ""},
                { "V0PARC_OTNADFRA" , ""},
                { "V0PARC_OTNCUSTO" , ""},
                { "V0PARC_OTNIOF" , ""},
                { "V0PARC_OTNTOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CPRE_COD_EMP" , ""},
                { "V0CPRE_TIPSGU" , ""},
                { "V0CPRE_CONGENER" , ""},
                { "V0CPRE_NUM_ORDEM" , ""},
                { "V0CPRE_NUM_APOL" , ""},
                { "V0CPRE_NRENDOS" , ""},
                { "V0CPRE_NRPARCEL" , ""},
                { "V0CPRE_PRM_TAR_IX" , ""},
                { "V0CPRE_VAL_DES_IX" , ""},
                { "V0CPRE_OTNPRLIQ" , ""},
                { "V0CPRE_OTNADFRA" , ""},
                { "V0CPRE_VLCOMISIX" , ""},
                { "V0CPRE_OTNTOTAL" , ""},
                { "V0CPRE_SITUACAO" , ""},
                { "V0CPRE_SIT_CONG" , ""},
                { "V0CPRE_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMP" , ""},
                { "V0CHIS_CONGENER" , ""},
                { "V0CHIS_NUM_APOL" , ""},
                { "V0CHIS_NRENDOS" , ""},
                { "V0CHIS_NRPARCEL" , ""},
                { "V0CHIS_OCORHIST" , ""},
                { "V0CHIS_OPERACAO" , ""},
                { "V0CHIS_DTMOVTO" , ""},
                { "V0CHIS_TIPSGU" , ""},
                { "V0CHIS_PRM_TAR" , ""},
                { "V0CHIS_VAL_DESC" , ""},
                { "V0CHIS_VLPRMLIQ" , ""},
                { "V0CHIS_VLADIFRA" , ""},
                { "V0CHIS_VLCOMIS" , ""},
                { "V0CHIS_VLPRMTOT" , ""},
                { "V0CHIS_DTQITBCO" , ""},
                { "V0CHIS_SIT_FINANC" , ""},
                { "V0CHIS_SIT_LIBRECUP" , ""},
                { "V0CHIS_NUMOCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""},
                { "WHOST_OCORHIST" , ""},
                { "WHOST_SITCONG" , ""},
                { "V0COSC_CODLIDER" , ""},
                { "V0ENDO_NUM_APOL" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0COSC_ORDLIDER" , ""},
                { "V0ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DESC" , ""},
                { "V1PARC_OTNPRLIQ" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
                { "V1PARC_OTNIOF" , ""},
                { "V1PARC_OTNTOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""},
                { "WHOST_OCORHIST" , ""},
                { "WHOST_SITCONG" , ""},
                { "V0COSC_CODLIDER" , ""},
                { "V0ENDO_NUM_APOL" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V0COSC_ORDLIDER" , ""},
                { "V0ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q12);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0005B_Tests_Fact()
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
                #region PARAMETERS
                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_COUNT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0005B_V0HISTOPARC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V0HISP_OCORHIST" , ""},
                    { "V0HISP_OPERACAO" , "0202"},
                    { "V0HISP_DTMOVTO" , ""},
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
                    { "V0HISP_DTQITBCO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0005B_V0HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0005B_V0HISTOPARC", q2);

                #endregion

                #region AC0005B_V1HISTOPARC

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1HISP_NUM_APOL" , ""},
                    { "V1HISP_NRENDOS" , ""},
                    { "V1HISP_NRPARCEL" , ""},
                    { "V1HISP_OCORHIST" , ""},
                    { "V1HISP_OPERACAO" , "2"},
                    { "V1HISP_DTMOVTO" , ""},
                    { "V1HISP_PRM_TAR" , ""},
                    { "V1HISP_VAL_DESC" , ""},
                    { "V1HISP_VLPRMLIQ" , ""},
                    { "V1HISP_VLADIFRA" , ""},
                    { "V1HISP_VLCUSEMI" , ""},
                    { "V1HISP_VLIOCC" , ""},
                    { "V1HISP_VLPRMTOT" , ""},
                    { "V1HISP_VLPREMIO" , ""},
                    { "V1HISP_DTVENCTO" , ""},
                    { "V1HISP_BCOCOBR" , ""},
                    { "V1HISP_AGECOBR" , ""},
                    { "V1HISP_NRAVISO" , ""},
                    { "V1HISP_NRENDOCA" , ""},
                    { "V1HISP_DTQITBCO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0005B_V1HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0005B_V1HISTOPARC", q3);

                #endregion

                #region R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDO_NUM_APOL" , ""},
                    { "V0ENDO_NRENDOS" , ""},
                    { "V0ENDO_CORRECAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0COSC_NUM_APOL" , ""},
                    { "V0COSC_NRENDOS" , ""},
                    { "V0COSC_CODLIDER" , ""},
                    { "V0COSC_ORDLIDER" , ""},
                    { "V0COSC_PCCOMCOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0PARC_NUM_APOL" , ""},
                    { "V0PARC_NRENDOS" , ""},
                    { "V0PARC_NRPARCEL" , ""},
                    { "V0PARC_PRM_TAR" , ""},
                    { "V0PARC_VAL_DESC" , ""},
                    { "V0PARC_OTNPRLIQ" , ""},
                    { "V0PARC_OTNADFRA" , ""},
                    { "V0PARC_OTNCUSTO" , ""},
                    { "V0PARC_OTNIOF" , ""},
                    { "V0PARC_OTNTOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                //q7.AddDynamic(new Dictionary<string, string>{
                //    { "WHOST_OCORHIST" , "2"}
                //});
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0CPRE_COD_EMP" , ""},
                    { "V0CPRE_TIPSGU" , ""},
                    { "V0CPRE_CONGENER" , ""},
                    { "V0CPRE_NUM_ORDEM" , ""},
                    { "V0CPRE_NUM_APOL" , ""},
                    { "V0CPRE_NRENDOS" , ""},
                    { "V0CPRE_NRPARCEL" , ""},
                    { "V0CPRE_PRM_TAR_IX" , ""},
                    { "V0CPRE_VAL_DES_IX" , ""},
                    { "V0CPRE_OTNPRLIQ" , ""},
                    { "V0CPRE_OTNADFRA" , ""},
                    { "V0CPRE_VLCOMISIX" , ""},
                    { "V0CPRE_OTNTOTAL" , ""},
                    { "V0CPRE_SITUACAO" , ""},
                    { "V0CPRE_SIT_CONG" , ""},
                    { "V0CPRE_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0CHIS_COD_EMP" , ""},
                    { "V0CHIS_CONGENER" , ""},
                    { "V0CHIS_NUM_APOL" , ""},
                    { "V0CHIS_NRENDOS" , ""},
                    { "V0CHIS_NRPARCEL" , ""},
                    { "V0CHIS_OCORHIST" , ""},
                    { "V0CHIS_OPERACAO" , "0202"},
                    { "V0CHIS_DTMOVTO" , ""},
                    { "V0CHIS_TIPSGU" , ""},
                    { "V0CHIS_PRM_TAR" , ""},
                    { "V0CHIS_VAL_DESC" , ""},
                    { "V0CHIS_VLPRMLIQ" , ""},
                    { "V0CHIS_VLADIFRA" , ""},
                    { "V0CHIS_VLCOMIS" , ""},
                    { "V0CHIS_VLPRMTOT" , ""},
                    { "V0CHIS_DTQITBCO" , ""},
                    { "V0CHIS_SIT_FINANC" , ""},
                    { "V0CHIS_SIT_LIBRECUP" , ""},
                    { "V0CHIS_NUMOCOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_SITUACAO" , ""},
                    { "WHOST_OCORHIST" , "2"},
                    { "WHOST_SITCONG" , ""},
                    { "V0COSC_CODLIDER" , ""},
                    { "V0ENDO_NUM_APOL" , ""},
                    { "V0PARC_NRPARCEL" , ""},
                    { "V0COSC_ORDLIDER" , ""},
                    { "V0ENDO_NRENDOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q10);

                #endregion

                #region R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL" , ""},
                    { "V1PARC_NRENDOS" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V1PARC_PRM_TAR" , ""},
                    { "V1PARC_VAL_DESC" , ""},
                    { "V1PARC_OTNPRLIQ" , ""},
                    { "V1PARC_OTNADFRA" , ""},
                    { "V1PARC_OTNCUSTO" , ""},
                    { "V1PARC_OTNIOF" , ""},
                    { "V1PARC_OTNTOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_SITUACAO" , ""},
                    { "WHOST_OCORHIST" , "2"},
                    { "WHOST_SITCONG" , ""},
                    { "V0COSC_CODLIDER" , ""},
                    { "V0ENDO_NUM_APOL" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V0COSC_ORDLIDER" , ""},
                    { "V0ENDO_NRENDOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q12);

                #endregion

                #endregion
                #endregion
                var program = new AC0005B();
                program.Execute();

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                var update1 = AppSettings.TestSet.DynamicData["R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update1[1].TryGetValue("V0ENDO_NUM_APOL", out string value1) && value1.Equals("0000000000000"));
                Assert.True(update1[1].TryGetValue("UpdateCheck", out string value2) && value2.Equals("UpdateCheck"));

                var insert1 = AppSettings.TestSet.DynamicData["R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert1[1].TryGetValue("V0CPRE_NUM_APOL", out string value7) && value7.Equals("0000000000000"));

                var insert2 = AppSettings.TestSet.DynamicData["R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert2[1].TryGetValue("V0CHIS_NUM_APOL", out string value8) && value8.Equals("0000000000000"));

                Assert.True(selects.Count > allSelects.Count / 2);

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Fact]
        public static void AC0005B_Tests_Update2_Fact()
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
                #region PARAMETERS
                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_COUNT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0005B_V0HISTOPARC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V0HISP_OCORHIST" , ""},
                    { "V0HISP_OPERACAO" , "0202"},
                    { "V0HISP_DTMOVTO" , ""},
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
                    { "V0HISP_DTQITBCO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0005B_V0HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0005B_V0HISTOPARC", q2);

                #endregion

                #region AC0005B_V1HISTOPARC

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1HISP_NUM_APOL" , ""},
                    { "V1HISP_NRENDOS" , ""},
                    { "V1HISP_NRPARCEL" , ""},
                    { "V1HISP_OCORHIST" , ""},
                    { "V1HISP_OPERACAO" , "2"},
                    { "V1HISP_DTMOVTO" , ""},
                    { "V1HISP_PRM_TAR" , ""},
                    { "V1HISP_VAL_DESC" , ""},
                    { "V1HISP_VLPRMLIQ" , ""},
                    { "V1HISP_VLADIFRA" , ""},
                    { "V1HISP_VLCUSEMI" , ""},
                    { "V1HISP_VLIOCC" , ""},
                    { "V1HISP_VLPRMTOT" , ""},
                    { "V1HISP_VLPREMIO" , ""},
                    { "V1HISP_DTVENCTO" , ""},
                    { "V1HISP_BCOCOBR" , ""},
                    { "V1HISP_AGECOBR" , ""},
                    { "V1HISP_NRAVISO" , ""},
                    { "V1HISP_NRENDOCA" , ""},
                    { "V1HISP_DTQITBCO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1HISP_NUM_APOL" , ""},
                    { "V1HISP_NRENDOS" , ""},
                    { "V1HISP_NRPARCEL" , ""},
                    { "V1HISP_OCORHIST" , ""},
                    { "V1HISP_OPERACAO" , "2"},
                    { "V1HISP_DTMOVTO" , ""},
                    { "V1HISP_PRM_TAR" , ""},
                    { "V1HISP_VAL_DESC" , ""},
                    { "V1HISP_VLPRMLIQ" , ""},
                    { "V1HISP_VLADIFRA" , ""},
                    { "V1HISP_VLCUSEMI" , ""},
                    { "V1HISP_VLIOCC" , ""},
                    { "V1HISP_VLPRMTOT" , ""},
                    { "V1HISP_VLPREMIO" , ""},
                    { "V1HISP_DTVENCTO" , ""},
                    { "V1HISP_BCOCOBR" , ""},
                    { "V1HISP_AGECOBR" , ""},
                    { "V1HISP_NRAVISO" , ""},
                    { "V1HISP_NRENDOCA" , ""},
                    { "V1HISP_DTQITBCO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0005B_V1HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0005B_V1HISTOPARC", q3);

                #endregion

                #region R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDO_NUM_APOL" , ""},
                    { "V0ENDO_NRENDOS" , ""},
                    { "V0ENDO_CORRECAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0COSC_NUM_APOL" , ""},
                    { "V0COSC_NRENDOS" , ""},
                    { "V0COSC_CODLIDER" , ""},
                    { "V0COSC_ORDLIDER" , ""},
                    { "V0COSC_PCCOMCOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0PARC_NUM_APOL" , ""},
                    { "V0PARC_NRENDOS" , ""},
                    { "V0PARC_NRPARCEL" , ""},
                    { "V0PARC_PRM_TAR" , ""},
                    { "V0PARC_VAL_DESC" , ""},
                    { "V0PARC_OTNPRLIQ" , ""},
                    { "V0PARC_OTNADFRA" , ""},
                    { "V0PARC_OTNCUSTO" , ""},
                    { "V0PARC_OTNIOF" , ""},
                    { "V0PARC_OTNTOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                //q7.AddDynamic(new Dictionary<string, string>{
                //    { "WHOST_OCORHIST" , "2"}
                //});
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0CPRE_COD_EMP" , ""},
                    { "V0CPRE_TIPSGU" , ""},
                    { "V0CPRE_CONGENER" , ""},
                    { "V0CPRE_NUM_ORDEM" , ""},
                    { "V0CPRE_NUM_APOL" , ""},
                    { "V0CPRE_NRENDOS" , ""},
                    { "V0CPRE_NRPARCEL" , ""},
                    { "V0CPRE_PRM_TAR_IX" , ""},
                    { "V0CPRE_VAL_DES_IX" , ""},
                    { "V0CPRE_OTNPRLIQ" , ""},
                    { "V0CPRE_OTNADFRA" , ""},
                    { "V0CPRE_VLCOMISIX" , ""},
                    { "V0CPRE_OTNTOTAL" , ""},
                    { "V0CPRE_SITUACAO" , ""},
                    { "V0CPRE_SIT_CONG" , ""},
                    { "V0CPRE_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0CHIS_COD_EMP" , ""},
                    { "V0CHIS_CONGENER" , ""},
                    { "V0CHIS_NUM_APOL" , ""},
                    { "V0CHIS_NRENDOS" , ""},
                    { "V0CHIS_NRPARCEL" , ""},
                    { "V0CHIS_OCORHIST" , ""},
                    { "V0CHIS_OPERACAO" , "0202"},
                    { "V0CHIS_DTMOVTO" , ""},
                    { "V0CHIS_TIPSGU" , ""},
                    { "V0CHIS_PRM_TAR" , ""},
                    { "V0CHIS_VAL_DESC" , ""},
                    { "V0CHIS_VLPRMLIQ" , ""},
                    { "V0CHIS_VLADIFRA" , ""},
                    { "V0CHIS_VLCOMIS" , ""},
                    { "V0CHIS_VLPRMTOT" , ""},
                    { "V0CHIS_DTQITBCO" , ""},
                    { "V0CHIS_SIT_FINANC" , ""},
                    { "V0CHIS_SIT_LIBRECUP" , ""},
                    { "V0CHIS_NUMOCOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_SITUACAO" , ""},
                    { "WHOST_OCORHIST" , "2"},
                    { "WHOST_SITCONG" , ""},
                    { "V0COSC_CODLIDER" , ""},
                    { "V0ENDO_NUM_APOL" , ""},
                    { "V0PARC_NRPARCEL" , ""},
                    { "V0COSC_ORDLIDER" , ""},
                    { "V0ENDO_NRENDOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q10);

                #endregion

                #region R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL" , ""},
                    { "V1PARC_NRENDOS" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V1PARC_PRM_TAR" , ""},
                    { "V1PARC_VAL_DESC" , ""},
                    { "V1PARC_OTNPRLIQ" , ""},
                    { "V1PARC_OTNADFRA" , ""},
                    { "V1PARC_OTNCUSTO" , ""},
                    { "V1PARC_OTNIOF" , ""},
                    { "V1PARC_OTNTOTAL" , ""},
                });
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL" , ""},
                    { "V1PARC_NRENDOS" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V1PARC_PRM_TAR" , ""},
                    { "V1PARC_VAL_DESC" , ""},
                    { "V1PARC_OTNPRLIQ" , ""},
                    { "V1PARC_OTNADFRA" , ""},
                    { "V1PARC_OTNCUSTO" , ""},
                    { "V1PARC_OTNIOF" , ""},
                    { "V1PARC_OTNTOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_SITUACAO" , ""},
                    { "WHOST_OCORHIST" , "2"},
                    { "WHOST_SITCONG" , ""},
                    { "V0COSC_CODLIDER" , ""},
                    { "V0ENDO_NUM_APOL" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V0COSC_ORDLIDER" , ""},
                    { "V0ENDO_NRENDOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q12);

                #endregion

                #endregion
                #endregion
                var program = new AC0005B();
                program.Execute();

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                var update2 = AppSettings.TestSet.DynamicData["R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update2[1].TryGetValue("V0ENDO_NUM_APOL", out string value3) && value3.Equals("0000000000000"));
                Assert.True(update2[1].TryGetValue("UpdateCheck", out string value4) && value4.Equals("UpdateCheck"));

                var insert1 = AppSettings.TestSet.DynamicData["R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert1[1].TryGetValue("V0CPRE_NUM_APOL", out string value7) && value7.Equals("0000000000000"));

                var insert2 = AppSettings.TestSet.DynamicData["R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert2[1].TryGetValue("V0CHIS_NUM_APOL", out string value8) && value8.Equals("0000000000000"));

                Assert.True(selects.Count > allSelects.Count / 2);

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Fact]
        public static void AC0005B_Tests_ReturnCode99_Fact()
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
                #region PARAMETERS
                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_COUNT" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0005B_V0HISTOPARC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V0HISP_OCORHIST" , ""},
                    { "V0HISP_OPERACAO" , "0202"},
                    { "V0HISP_DTMOVTO" , ""},
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
                    { "V0HISP_DTQITBCO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0005B_V0HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0005B_V0HISTOPARC", q2);

                #endregion

                #region AC0005B_V1HISTOPARC

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1HISP_NUM_APOL" , ""},
                    { "V1HISP_NRENDOS" , ""},
                    { "V1HISP_NRPARCEL" , ""},
                    { "V1HISP_OCORHIST" , ""},
                    { "V1HISP_OPERACAO" , "2"},
                    { "V1HISP_DTMOVTO" , ""},
                    { "V1HISP_PRM_TAR" , ""},
                    { "V1HISP_VAL_DESC" , ""},
                    { "V1HISP_VLPRMLIQ" , ""},
                    { "V1HISP_VLADIFRA" , ""},
                    { "V1HISP_VLCUSEMI" , ""},
                    { "V1HISP_VLIOCC" , ""},
                    { "V1HISP_VLPRMTOT" , ""},
                    { "V1HISP_VLPREMIO" , ""},
                    { "V1HISP_DTVENCTO" , ""},
                    { "V1HISP_BCOCOBR" , ""},
                    { "V1HISP_AGECOBR" , ""},
                    { "V1HISP_NRAVISO" , ""},
                    { "V1HISP_NRENDOCA" , ""},
                    { "V1HISP_DTQITBCO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1HISP_NUM_APOL" , ""},
                    { "V1HISP_NRENDOS" , ""},
                    { "V1HISP_NRPARCEL" , ""},
                    { "V1HISP_OCORHIST" , ""},
                    { "V1HISP_OPERACAO" , "2"},
                    { "V1HISP_DTMOVTO" , ""},
                    { "V1HISP_PRM_TAR" , ""},
                    { "V1HISP_VAL_DESC" , ""},
                    { "V1HISP_VLPRMLIQ" , ""},
                    { "V1HISP_VLADIFRA" , ""},
                    { "V1HISP_VLCUSEMI" , ""},
                    { "V1HISP_VLIOCC" , ""},
                    { "V1HISP_VLPRMTOT" , ""},
                    { "V1HISP_VLPREMIO" , ""},
                    { "V1HISP_DTVENCTO" , ""},
                    { "V1HISP_BCOCOBR" , ""},
                    { "V1HISP_AGECOBR" , ""},
                    { "V1HISP_NRAVISO" , ""},
                    { "V1HISP_NRENDOCA" , ""},
                    { "V1HISP_DTQITBCO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0005B_V1HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0005B_V1HISTOPARC", q3);

                #endregion

                #region R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDO_NUM_APOL" , ""},
                    { "V0ENDO_NRENDOS" , ""},
                    { "V0ENDO_CORRECAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0COSC_NUM_APOL" , ""},
                    { "V0COSC_NRENDOS" , ""},
                    { "V0COSC_CODLIDER" , ""},
                    { "V0COSC_ORDLIDER" , ""},
                    { "V0COSC_PCCOMCOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0PARC_NUM_APOL" , ""},
                    { "V0PARC_NRENDOS" , ""},
                    { "V0PARC_NRPARCEL" , ""},
                    { "V0PARC_PRM_TAR" , ""},
                    { "V0PARC_VAL_DESC" , ""},
                    { "V0PARC_OTNPRLIQ" , ""},
                    { "V0PARC_OTNADFRA" , ""},
                    { "V0PARC_OTNCUSTO" , ""},
                    { "V0PARC_OTNIOF" , ""},
                    { "V0PARC_OTNTOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                //q7.AddDynamic(new Dictionary<string, string>{
                //    { "WHOST_OCORHIST" , "2"}
                //});
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0CPRE_COD_EMP" , ""},
                    { "V0CPRE_TIPSGU" , ""},
                    { "V0CPRE_CONGENER" , ""},
                    { "V0CPRE_NUM_ORDEM" , ""},
                    { "V0CPRE_NUM_APOL" , ""},
                    { "V0CPRE_NRENDOS" , ""},
                    { "V0CPRE_NRPARCEL" , ""},
                    { "V0CPRE_PRM_TAR_IX" , ""},
                    { "V0CPRE_VAL_DES_IX" , ""},
                    { "V0CPRE_OTNPRLIQ" , ""},
                    { "V0CPRE_OTNADFRA" , ""},
                    { "V0CPRE_VLCOMISIX" , ""},
                    { "V0CPRE_OTNTOTAL" , ""},
                    { "V0CPRE_SITUACAO" , ""},
                    { "V0CPRE_SIT_CONG" , ""},
                    { "V0CPRE_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0CHIS_COD_EMP" , ""},
                    { "V0CHIS_CONGENER" , ""},
                    { "V0CHIS_NUM_APOL" , ""},
                    { "V0CHIS_NRENDOS" , ""},
                    { "V0CHIS_NRPARCEL" , ""},
                    { "V0CHIS_OCORHIST" , ""},
                    { "V0CHIS_OPERACAO" , "0202"},
                    { "V0CHIS_DTMOVTO" , ""},
                    { "V0CHIS_TIPSGU" , ""},
                    { "V0CHIS_PRM_TAR" , ""},
                    { "V0CHIS_VAL_DESC" , ""},
                    { "V0CHIS_VLPRMLIQ" , ""},
                    { "V0CHIS_VLADIFRA" , ""},
                    { "V0CHIS_VLCOMIS" , ""},
                    { "V0CHIS_VLPRMTOT" , ""},
                    { "V0CHIS_DTQITBCO" , ""},
                    { "V0CHIS_SIT_FINANC" , ""},
                    { "V0CHIS_SIT_LIBRECUP" , ""},
                    { "V0CHIS_NUMOCOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_SITUACAO" , ""},
                    { "WHOST_OCORHIST" , "2"},
                    { "WHOST_SITCONG" , ""},
                    { "V0COSC_CODLIDER" , ""},
                    { "V0ENDO_NUM_APOL" , ""},
                    { "V0PARC_NRPARCEL" , ""},
                    { "V0COSC_ORDLIDER" , ""},
                    { "V0ENDO_NRENDOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q10);

                #endregion

                #region R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL" , ""},
                    { "V1PARC_NRENDOS" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V1PARC_PRM_TAR" , ""},
                    { "V1PARC_VAL_DESC" , ""},
                    { "V1PARC_OTNPRLIQ" , ""},
                    { "V1PARC_OTNADFRA" , ""},
                    { "V1PARC_OTNCUSTO" , ""},
                    { "V1PARC_OTNIOF" , ""},
                    { "V1PARC_OTNTOTAL" , ""},
                });
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL" , ""},
                    { "V1PARC_NRENDOS" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V1PARC_PRM_TAR" , ""},
                    { "V1PARC_VAL_DESC" , ""},
                    { "V1PARC_OTNPRLIQ" , ""},
                    { "V1PARC_OTNADFRA" , ""},
                    { "V1PARC_OTNCUSTO" , ""},
                    { "V1PARC_OTNIOF" , ""},
                    { "V1PARC_OTNTOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_SITUACAO" , ""},
                    { "WHOST_OCORHIST" , "2"},
                    { "WHOST_SITCONG" , ""},
                    { "V0COSC_CODLIDER" , ""},
                    { "V0ENDO_NUM_APOL" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V0COSC_ORDLIDER" , ""},
                    { "V0ENDO_NRENDOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q12);

                #endregion

                #endregion
                #endregion
                var program = new AC0005B();
                program.Execute();

                Assert.True(program.RETURN_CODE.Value == 99);
            }
        }
    }
}