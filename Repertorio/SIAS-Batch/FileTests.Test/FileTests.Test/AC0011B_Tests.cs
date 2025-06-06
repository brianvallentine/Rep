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
using static Code.AC0011B;
using System.IO;
using Sias.Cosseguro.DB2.AC0011B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("AC0011B_Tests")]
    public class AC0011B_Tests
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
                { "WSHOST_QTDE_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region AC0011B_V1HISTOPARC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_NUM_APOL" , ""},
                { "V1HISP_NRENDOS" , ""},
                { "V1HISP_NRPARCEL" , ""},
                { "V1HISP_OCORHIST" , ""},
                { "V1HISP_OPERACAO" , ""},
                { "V1HISP_DTMOVTO" , ""},
                { "V1HISP_PRM_TAR" , ""},
                { "V1HISP_VAL_DES" , ""},
                { "V1HISP_VLADIFRA" , ""},
                { "V1HISP_VLCUSEMI" , ""},
                { "V1HISP_DTQITBCO" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0011B_V1HISTOPARC", q2);

            #endregion

            #region AC0011B_V1APOLCOSCED

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1APCD_CODCOSS" , ""},
                { "V1APCD_PCPARTIC" , ""},
                { "V1APCD_PCCOMCOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0011B_V1APOLCOSCED", q3);

            #endregion

            #region R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_DTEMIS" , ""},
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_CDFRACIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q4);

            #endregion

            #region AC0011B_V2HISTOPARC

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V2HISP_NUM_APOL" , ""},
                { "V2HISP_NRENDOS" , ""},
                { "V2HISP_NRPARCEL" , ""},
                { "V2HISP_OCORHIST" , ""},
                { "V2HISP_OPERACAO" , ""},
                { "V2HISP_DTMOVTO" , ""},
                { "V2HISP_PRM_TAR" , ""},
                { "V2HISP_VAL_DES" , ""},
                { "V2HISP_VLADIFRA" , ""},
                { "V2HISP_VLCUSEMI" , ""},
                { "V2HISP_DTQITBCO" , ""},
                { "V2PARC_PRM_TAR" , ""},
                { "V2PARC_VAL_DES" , ""},
                { "V2PARC_OTNADFRA" , ""},
                { "V2PARC_OTNCUSTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0011B_V2HISTOPARC", q5);

            #endregion

            #region R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1ORDC_ORD_CEDIDO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0COSP_PCADMCOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1PCOM_NUM_APOL" , ""},
                { "V1PCOM_NRENDOS" , ""},
                { "V1PCOM_NRPARCEL" , ""},
                { "V1PCOM_VLR_COMPL_IX" , ""},
                { "V1PCOM_VLR_COMPL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1PLCO_PCCOMSEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V3PARC_PRM_TAR" , ""},
                { "V3PARC_VAL_DES" , ""},
                { "V3PARC_OTNADFRA" , ""},
                { "V3PARC_OTNCUSTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V3HISP_PRM_TAR" , ""},
                { "V3HISP_VAL_DES" , ""},
                { "V3HISP_VLADIFRA" , ""},
                { "V3HISP_VLCUSEMI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V2PCOM_VLR_COMPL_IX" , ""},
                { "V2PCOM_VLR_COMPL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0CPRE_COD_EMPR" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , ""},
                { "V0CHIS_CONGENER" , ""},
                { "V0CHIS_NUM_APOL" , ""},
                { "V0CHIS_NRENDOS" , ""},
                { "V0CHIS_NRPARCEL" , ""},
                { "V0CHIS_OCORHIST" , ""},
                { "V0CHIS_OPERACAO" , ""},
                { "V0CHIS_DTMOVTO" , ""},
                { "V0CHIS_TIPSGU" , ""},
                { "V0CHIS_PRM_TAR" , ""},
                { "V0CHIS_VAL_DES" , ""},
                { "V0CHIS_VLPRMLIQ" , ""},
                { "V0CHIS_VLADIFRA" , ""},
                { "V0CHIS_VLCOMIS" , ""},
                { "V0CHIS_VLPRMTOT" , ""},
                { "V0CHIS_DTQITBCO" , ""},
                { "V0CHIS_SIT_FINANC" , ""},
                { "V0CHIS_SIT_LIBRECUP" , ""},
                { "V0CHIS_NUMOCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V3HISP_NUM_APOL" , ""},
                { "V3HISP_NRENDOS" , ""},
                { "V3HISP_NRPARCEL" , ""},
                { "V3HISP_OCORHIST" , ""},
                { "V3HISP_OPERACAO" , ""},
                { "V3HISP_DTMOVTO" , ""},
                { "V3HISP_PRM_TAR" , ""},
                { "V3HISP_VAL_DES" , ""},
                { "V3HISP_VLADIFRA" , ""},
                { "V3HISP_VLCUSEMI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1", q16);

            #endregion

            #region R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q17);

            #endregion

            #region R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V3CHIS_TIPSGU" , ""},
                { "V3CHIS_CONGENER" , ""},
                { "V3CHIS_NUM_APOL" , ""},
                { "V3CHIS_NRENDOS" , ""},
                { "V3CHIS_NRPARCEL" , ""},
                { "V3CHIS_OCORHIST" , ""},
                { "V3CHIS_OPERACAO" , ""},
                { "V3CHIS_PRM_TAR" , ""},
                { "V3CHIS_VAL_DES" , ""},
                { "V3CHIS_VLADIFRA" , ""},
                { "V3CHIS_VLCOMIS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1", q18);

            #endregion

            #region R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_OCORHIST" , ""},
                { "WSHOST_SITUACAO" , ""},
                { "V1ORDC_ORD_CEDIDO" , ""},
                { "V1HISP_NUM_APOL" , ""},
                { "V1HISP_NRPARCEL" , ""},
                { "V1APCD_CODCOSS" , ""},
                { "V1HISP_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V2CPRE_COD_EMPR" , ""},
                { "V2CPRE_TIPSGU" , ""},
                { "V2CPRE_CONGENER" , ""},
                { "V2CPRE_NUM_ORDEM" , ""},
                { "V2CPRE_NUM_APOL" , ""},
                { "V2CPRE_NRENDOS" , ""},
                { "V2CPRE_NRPARCEL" , ""},
                { "V2CPRE_PRM_TAR_IX" , ""},
                { "V2CPRE_VAL_DES_IX" , ""},
                { "V2CPRE_OTNPRLIQ" , ""},
                { "V2CPRE_OTNADFRA" , ""},
                { "V2CPRE_VLCOMISIX" , ""},
                { "V2CPRE_OTNTOTAL" , ""},
                { "V2CPRE_SITUACAO" , ""},
                { "V2CPRE_SIT_CONG" , ""},
                { "V2CPRE_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_COD_EMPR" , ""},
                { "V2CHIS_CONGENER" , ""},
                { "V2CHIS_NUM_APOL" , ""},
                { "V2CHIS_NRENDOS" , ""},
                { "V2CHIS_NRPARCEL" , ""},
                { "V2CHIS_OCORHIST" , ""},
                { "V2CHIS_OPERACAO" , ""},
                { "V2CHIS_DTMOVTO" , ""},
                { "V2CHIS_TIPSGU" , ""},
                { "V2CHIS_PRM_TAR" , ""},
                { "V2CHIS_VAL_DES" , ""},
                { "V2CHIS_VLPRMLIQ" , ""},
                { "V2CHIS_VLADIFRA" , ""},
                { "V2CHIS_VLCOMIS" , ""},
                { "V2CHIS_VLPRMTOT" , ""},
                { "V2CHIS_DTQITBCO" , ""},
                { "V2CHIS_SIT_FINANC" , ""},
                { "V2CHIS_SIT_LIBRECUP" , ""},
                { "V2CHIS_NUMOCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_OCORHIST" , ""},
                { "V2CPRE_NUM_ORDEM" , ""},
                { "V2CHIS_CONGENER" , ""},
                { "V2CHIS_NUM_APOL" , ""},
                { "V2CHIS_NRPARCEL" , ""},
                { "V2CHIS_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q22);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0011B_Tests_Fact()
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

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2024-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_QTDE_REG" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0011B_V1HISTOPARC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_NUM_APOL" , "6501000001"},
                { "V1HISP_NRENDOS" , "200003"},
                { "V1HISP_NRPARCEL" , "1"},
                { "V1HISP_OCORHIST" , "1"},
                { "V1HISP_OPERACAO" , "0610"},
                { "V1HISP_DTMOVTO" , "2024-01-01"},
                { "V1HISP_PRM_TAR" , "1"},
                { "V1HISP_VAL_DES" , "1"},
                { "V1HISP_VLADIFRA" , "1"},
                { "V1HISP_VLCUSEMI" , "1"},
                { "V1HISP_DTQITBCO" , "2024-01-01"},
                { "V0APOL_ORGAO" , "100"},
                { "V0APOL_RAMO" , "1"},
                { "V0APOL_CODPRODU" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("AC0011B_V1HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0011B_V1HISTOPARC", q2);

                #endregion

                #region AC0011B_V1APOLCOSCED

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1APCD_CODCOSS" , "1"},
                { "V1APCD_PCPARTIC" , "1"},
                { "V1APCD_PCCOMCOS" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("AC0011B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("AC0011B_V1APOLCOSCED", q3);

                #endregion

                #region R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , "6501000001"},
                { "V0ENDO_NRENDOS" , "200001"},
                { "V0ENDO_DTEMIS" , ""},
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_CDFRACIO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q4);

                #endregion

                #region AC0011B_V2HISTOPARC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V2HISP_NUM_APOL" , ""},
                { "V2HISP_NRENDOS" , ""},
                { "V2HISP_NRPARCEL" , ""},
                { "V2HISP_OCORHIST" , ""},
                { "V2HISP_OPERACAO" , ""},
                { "V2HISP_DTMOVTO" , ""},
                { "V2HISP_PRM_TAR" , ""},
                { "V2HISP_VAL_DES" , ""},
                { "V2HISP_VLADIFRA" , ""},
                { "V2HISP_VLCUSEMI" , ""},
                { "V2HISP_DTQITBCO" , ""},
                { "V2PARC_PRM_TAR" , ""},
                { "V2PARC_VAL_DES" , ""},
                { "V2PARC_OTNADFRA" , ""},
                { "V2PARC_OTNCUSTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("AC0011B_V2HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0011B_V2HISTOPARC", q5);

                #endregion

                #region R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1ORDC_ORD_CEDIDO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0COSP_PCADMCOS" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V1PCOM_NUM_APOL" , ""},
                { "V1PCOM_NRENDOS" , ""},
                { "V1PCOM_NRPARCEL" , ""},
                { "V1PCOM_VLR_COMPL_IX" , ""},
                { "V1PCOM_VLR_COMPL" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1PLCO_PCCOMSEG" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V3PARC_PRM_TAR" , ""},
                { "V3PARC_VAL_DES" , ""},
                { "V3PARC_OTNADFRA" , ""},
                { "V3PARC_OTNCUSTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V3HISP_PRM_TAR" , ""},
                { "V3HISP_VAL_DES" , ""},
                { "V3HISP_VLADIFRA" , ""},
                { "V3HISP_VLCUSEMI" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1", q12);

                #endregion

                #region R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V2PCOM_VLR_COMPL_IX" , ""},
                { "V2PCOM_VLR_COMPL" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0CPRE_COD_EMPR" , "0"},
                { "V0CPRE_TIPSGU" , "1"},
                { "V0CPRE_CONGENER" , "1015"},
                { "V0CPRE_NUM_ORDEM" , "10151100000001"},
                { "V0CPRE_NUM_APOL" , "1103101481585"},
                { "V0CPRE_NRENDOS" , "0"},
                { "V0CPRE_NRPARCEL" , "1"},
                { "V0CPRE_PRM_TAR_IX" , "268.02000"},
                { "V0CPRE_VAL_DES_IX" , "0"},
                { "V0CPRE_OTNPRLIQ" , "268.02000"},
                { "V0CPRE_OTNADFRA" , "0"},
                { "V0CPRE_VLCOMISIX" , "18.76000"},
                { "V0CPRE_OTNTOTAL" , "249.26000"},
                { "V0CPRE_SITUACAO" , "1"},
                { "V0CPRE_SIT_CONG" , "1"},
                { "V0CPRE_OCORHIST" , "3"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q14);

                #endregion

                #region R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "0"},
                { "V0CHIS_CONGENER" , "6645"},
                { "V0CHIS_NUM_APOL" , "902200000093"},
                { "V0CHIS_NRENDOS" , "804753"},
                { "V0CHIS_NRPARCEL" , "0"},
                { "V0CHIS_OCORHIST" , "1"},
                { "V0CHIS_OPERACAO" , "101"},
                { "V0CHIS_DTMOVTO" , "1986-07-31"},
                { "V0CHIS_TIPSGU" , "0"},
                { "V0CHIS_PRM_TAR" , "0"},
                { "V0CHIS_VAL_DES" , "0"},
                { "V0CHIS_VLPRMLIQ" , "0"},
                { "V0CHIS_VLADIFRA" , "0"},
                { "V0CHIS_VLCOMIS" , "0"},
                { "V0CHIS_VLPRMTOT" , "0"},
                { "V0CHIS_DTQITBCO" , "0"},
                { "V0CHIS_SIT_FINANC" , ""},
                { "V0CHIS_SIT_LIBRECUP" , "0"},
                { "V0CHIS_NUMOCOR" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1", q15);

                #endregion

                #region R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V3HISP_NUM_APOL" , ""},
                { "V3HISP_NRENDOS" , ""},
                { "V3HISP_NRPARCEL" , ""},
                { "V3HISP_OCORHIST" , ""},
                { "V3HISP_OPERACAO" , ""},
                { "V3HISP_DTMOVTO" , ""},
                { "V3HISP_PRM_TAR" , ""},
                { "V3HISP_VAL_DES" , ""},
                { "V3HISP_VLADIFRA" , ""},
                { "V3HISP_VLCUSEMI" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1", q16);

                #endregion

                #region R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_OCORHIST" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q17);

                #endregion

                #region R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V3CHIS_TIPSGU" , ""},
                { "V3CHIS_CONGENER" , "6238"},
                { "V3CHIS_NUM_APOL" , ""},
                { "V3CHIS_NRENDOS" , ""},
                { "V3CHIS_NRPARCEL" , ""},
                { "V3CHIS_OCORHIST" , ""},
                { "V3CHIS_OPERACAO" , ""},
                { "V3CHIS_PRM_TAR" , ""},
                { "V3CHIS_VAL_DES" , ""},
                { "V3CHIS_VLADIFRA" , ""},
                { "V3CHIS_VLCOMIS" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1", q18);

                #endregion

                #region R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_OCORHIST" , "3"},
                { "WSHOST_SITUACAO" , "1"},
                { "V1ORDC_ORD_CEDIDO" , "1"},
                { "V1HISP_NUM_APOL" , "1103101481585"},
                { "V1HISP_NRPARCEL" , "1"},
                { "V1APCD_CODCOSS" , "5045"},
                { "V1HISP_NRENDOS" , "200003"},
            });
                AppSettings.TestSet.DynamicData.Remove("R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V2CPRE_COD_EMPR" , "0"},
                { "V2CPRE_TIPSGU" , "1"},
                { "V2CPRE_CONGENER" , "1015"},
                { "V2CPRE_NUM_ORDEM" , "10151100000001"},
                { "V2CPRE_NUM_APOL" , "1103101481585"},
                { "V2CPRE_NRENDOS" , "0"},
                { "V2CPRE_NRPARCEL" , "1"},
                { "V2CPRE_PRM_TAR_IX" , "268.02000"},
                { "V2CPRE_VAL_DES_IX" , "0"},
                { "V2CPRE_OTNPRLIQ" , "268.02000"},
                { "V2CPRE_OTNADFRA" , "0"},
                { "V2CPRE_VLCOMISIX" , "18.76000"},
                { "V2CPRE_OTNTOTAL" , "249.26000"},
                { "V2CPRE_SITUACAO" , "1"},
                { "V2CPRE_SIT_CONG" , "1"},
                { "V2CPRE_OCORHIST" , "3"},
            });
                AppSettings.TestSet.DynamicData.Remove("R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_COD_EMPR" , "0"},
                { "V2CHIS_CONGENER" , "6645"},
                { "V2CHIS_NUM_APOL" , "902200000092"},
                { "V2CHIS_NRENDOS" , "0"},
                { "V2CHIS_NRPARCEL" , "0"},
                { "V2CHIS_OCORHIST" , "1"},
                { "V2CHIS_OPERACAO" , "101"},
                { "V2CHIS_DTMOVTO" , "1986-07-31"},
                { "V2CHIS_TIPSGU" , "0"},
                { "V2CHIS_PRM_TAR" , "0"},
                { "V2CHIS_VAL_DES" , "0"},
                { "V2CHIS_VLPRMLIQ" , "0"},
                { "V2CHIS_VLADIFRA" , "0"},
                { "V2CHIS_VLCOMIS" , "0"},
                { "V2CHIS_VLPRMTOT" , "0"},
                { "V2CHIS_DTQITBCO" , "0"},
                { "V2CHIS_SIT_FINANC" , "0"},
                { "V2CHIS_SIT_LIBRECUP" , "0"},
                { "V2CHIS_NUMOCOR" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1", q21);

                #endregion

                #region R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_OCORHIST" , "3"},
                { "V2CPRE_NUM_ORDEM" , "10151100000001"},
                { "V2CHIS_CONGENER" , "1015"},
                { "V2CHIS_NUM_APOL" , "1103101481585"},
                { "V2CHIS_NRPARCEL" , "1"},
                { "V2CHIS_NRENDOS" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q22);

                #endregion

                #endregion
                var program = new AC0011B();

                program.Execute();

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                var envList = AppSettings.TestSet.DynamicData["R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[0].TryGetValue("V0CPRE_TIPSGU", out var valor) && valor.Contains("1"));                
                Assert.True(envList.Count > 0);

                var envList2 = AppSettings.TestSet.DynamicData["R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[0].TryGetValue("V0CHIS_CONGENER", out var valor2) && valor2.Contains("6645"));
                Assert.True(envList2.Count > 0);

                var envList3 = AppSettings.TestSet.DynamicData["R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[0].TryGetValue("WSHOST_SITUACAO", out var valor3) && valor3.Contains("1"));
                Assert.True(envList3.Count > 0);

                var envList4 = AppSettings.TestSet.DynamicData["R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[0].TryGetValue("V2CPRE_TIPSGU", out var valor4) && valor4.Contains("1"));
                Assert.True(envList4.Count > 0);

                var envList5 = AppSettings.TestSet.DynamicData["R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[0].TryGetValue("V2CHIS_CONGENER", out var valor5) && valor5.Contains("6645"));
                Assert.True(envList5.Count > 0);

                var envList6 = AppSettings.TestSet.DynamicData["R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList6[0].TryGetValue("V2CPRE_NUM_ORDEM", out var valor6) && valor6.Contains("10151100000001"));
                Assert.True(envList6.Count > 0);


                Assert.True(program.RETURN_CODE == 00);
            }
        }


        [Fact]
        public static void AC0011B_Tests_FactReturn99()
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

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2024-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_QTDE_REG" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0011B_V1HISTOPARC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_NUM_APOL" , ""},
                { "V1HISP_NRENDOS" , ""},
                { "V1HISP_NRPARCEL" , ""},
                { "V1HISP_OCORHIST" , ""},
                { "V1HISP_OPERACAO" , ""},
                { "V1HISP_DTMOVTO" , ""},
                { "V1HISP_PRM_TAR" , ""},
                { "V1HISP_VAL_DES" , ""},
                { "V1HISP_VLADIFRA" , ""},
                { "V1HISP_VLCUSEMI" , ""},
                { "V1HISP_DTQITBCO" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , "31"},
                { "V0APOL_CODPRODU" , "3133"},
            });
                AppSettings.TestSet.DynamicData.Remove("AC0011B_V1HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0011B_V1HISTOPARC", q2);

                #endregion

                #region AC0011B_V1APOLCOSCED

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
     
            });
                AppSettings.TestSet.DynamicData.Remove("AC0011B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("AC0011B_V1APOLCOSCED", q3);

                #endregion

                #region R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_DTEMIS" , ""},
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_CDFRACIO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q4);

                #endregion

                #region AC0011B_V2HISTOPARC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V2HISP_NUM_APOL" , ""},
                { "V2HISP_NRENDOS" , ""},
                { "V2HISP_NRPARCEL" , ""},
                { "V2HISP_OCORHIST" , ""},
                { "V2HISP_OPERACAO" , ""},
                { "V2HISP_DTMOVTO" , ""},
                { "V2HISP_PRM_TAR" , ""},
                { "V2HISP_VAL_DES" , ""},
                { "V2HISP_VLADIFRA" , ""},
                { "V2HISP_VLCUSEMI" , ""},
                { "V2HISP_DTQITBCO" , ""},
                { "V2PARC_PRM_TAR" , ""},
                { "V2PARC_VAL_DES" , ""},
                { "V2PARC_OTNADFRA" , ""},
                { "V2PARC_OTNCUSTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("AC0011B_V2HISTOPARC");
                AppSettings.TestSet.DynamicData.Add("AC0011B_V2HISTOPARC", q5);

                #endregion

                #region R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1ORDC_ORD_CEDIDO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0COSP_PCADMCOS" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V1PCOM_NUM_APOL" , ""},
                { "V1PCOM_NRENDOS" , ""},
                { "V1PCOM_NRPARCEL" , ""},
                { "V1PCOM_VLR_COMPL_IX" , ""},
                { "V1PCOM_VLR_COMPL" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1PLCO_PCCOMSEG" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V3PARC_PRM_TAR" , ""},
                { "V3PARC_VAL_DES" , ""},
                { "V3PARC_OTNADFRA" , ""},
                { "V3PARC_OTNCUSTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V3HISP_PRM_TAR" , ""},
                { "V3HISP_VAL_DES" , ""},
                { "V3HISP_VLADIFRA" , ""},
                { "V3HISP_VLCUSEMI" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1", q12);

                #endregion

                #region R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V2PCOM_VLR_COMPL_IX" , ""},
                { "V2PCOM_VLR_COMPL" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0CPRE_COD_EMPR" , ""},
                { "V0CPRE_TIPSGU" , ""},
                { "V0CPRE_CONGENER" , ""},
                { "V0CPRE_NUM_ORDEM" , "1"},
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
                AppSettings.TestSet.DynamicData.Remove("R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q14);

                #endregion

                #region R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "0"},
                { "V0CHIS_CONGENER" , "6645"},
                { "V0CHIS_NUM_APOL" , "902200000093"},
                { "V0CHIS_NRENDOS" , "804753"},
                { "V0CHIS_NRPARCEL" , "0"},
                { "V0CHIS_OCORHIST" , "1"},
                { "V0CHIS_OPERACAO" , "101"},
                { "V0CHIS_DTMOVTO" , "1986-07-31"},
                { "V0CHIS_TIPSGU" , "0"},
                { "V0CHIS_PRM_TAR" , "0"},
                { "V0CHIS_VAL_DES" , "0"},
                { "V0CHIS_VLPRMLIQ" , "0"},
                { "V0CHIS_VLADIFRA" , "0"},
                { "V0CHIS_VLCOMIS" , "0"},
                { "V0CHIS_VLPRMTOT" , "0"},
                { "V0CHIS_DTQITBCO" , "0"},
                { "V0CHIS_SIT_FINANC" , ""},
                { "V0CHIS_SIT_LIBRECUP" , "0"},
                { "V0CHIS_NUMOCOR" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1", q15);

                #endregion

                #region R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V3HISP_NUM_APOL" , ""},
                { "V3HISP_NRENDOS" , ""},
                { "V3HISP_NRPARCEL" , ""},
                { "V3HISP_OCORHIST" , ""},
                { "V3HISP_OPERACAO" , ""},
                { "V3HISP_DTMOVTO" , ""},
                { "V3HISP_PRM_TAR" , ""},
                { "V3HISP_VAL_DES" , ""},
                { "V3HISP_VLADIFRA" , ""},
                { "V3HISP_VLCUSEMI" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1", q16);

                #endregion

                #region R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_OCORHIST" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q17);

                #endregion

                #region R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V3CHIS_TIPSGU" , ""},
                { "V3CHIS_CONGENER" , ""},
                { "V3CHIS_NUM_APOL" , ""},
                { "V3CHIS_NRENDOS" , ""},
                { "V3CHIS_NRPARCEL" , ""},
                { "V3CHIS_OCORHIST" , ""},
                { "V3CHIS_OPERACAO" , ""},
                { "V3CHIS_PRM_TAR" , ""},
                { "V3CHIS_VAL_DES" , ""},
                { "V3CHIS_VLADIFRA" , ""},
                { "V3CHIS_VLCOMIS" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1", q18);

                #endregion

                #region R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_OCORHIST" , ""},
                { "WSHOST_SITUACAO" , ""},
                { "V1ORDC_ORD_CEDIDO" , ""},
                { "V1HISP_NUM_APOL" , ""},
                { "V1HISP_NRPARCEL" , ""},
                { "V1APCD_CODCOSS" , ""},
                { "V1HISP_NRENDOS" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V2CPRE_COD_EMPR" , ""},
                { "V2CPRE_TIPSGU" , ""},
                { "V2CPRE_CONGENER" , ""},
                { "V2CPRE_NUM_ORDEM" , ""},
                { "V2CPRE_NUM_APOL" , ""},
                { "V2CPRE_NRENDOS" , ""},
                { "V2CPRE_NRPARCEL" , ""},
                { "V2CPRE_PRM_TAR_IX" , ""},
                { "V2CPRE_VAL_DES_IX" , ""},
                { "V2CPRE_OTNPRLIQ" , ""},
                { "V2CPRE_OTNADFRA" , ""},
                { "V2CPRE_VLCOMISIX" , ""},
                { "V2CPRE_OTNTOTAL" , ""},
                { "V2CPRE_SITUACAO" , ""},
                { "V2CPRE_SIT_CONG" , ""},
                { "V2CPRE_OCORHIST" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_COD_EMPR" , ""},
                { "V2CHIS_CONGENER" , ""},
                { "V2CHIS_NUM_APOL" , ""},
                { "V2CHIS_NRENDOS" , ""},
                { "V2CHIS_NRPARCEL" , ""},
                { "V2CHIS_OCORHIST" , ""},
                { "V2CHIS_OPERACAO" , ""},
                { "V2CHIS_DTMOVTO" , ""},
                { "V2CHIS_TIPSGU" , ""},
                { "V2CHIS_PRM_TAR" , ""},
                { "V2CHIS_VAL_DES" , ""},
                { "V2CHIS_VLPRMLIQ" , ""},
                { "V2CHIS_VLADIFRA" , ""},
                { "V2CHIS_VLCOMIS" , ""},
                { "V2CHIS_VLPRMTOT" , ""},
                { "V2CHIS_DTQITBCO" , ""},
                { "V2CHIS_SIT_FINANC" , ""},
                { "V2CHIS_SIT_LIBRECUP" , ""},
                { "V2CHIS_NUMOCOR" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1", q21);

                #endregion

                #region R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_OCORHIST" , ""},
                { "V2CPRE_NUM_ORDEM" , ""},
                { "V2CHIS_CONGENER" , ""},
                { "V2CHIS_NUM_APOL" , ""},
                { "V2CHIS_NRPARCEL" , ""},
                { "V2CHIS_NRENDOS" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1", q22);

                #endregion

                #endregion
                var program = new AC0011B();
                program.Execute();

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}