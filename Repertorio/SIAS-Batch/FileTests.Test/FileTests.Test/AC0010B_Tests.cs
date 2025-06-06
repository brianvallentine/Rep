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
using static Code.AC0010B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("AC0010B_Tests")]
    public class AC0010B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region AC0010B_V1HISTOPARC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_NUM_APOL" , ""},
                { "V1HISP_NRENDOS" , ""},
                { "V1HISP_NRPARCEL" , ""},
                { "V1HISP_DTMOVTO" , ""},
                { "V1HISP_OPERACAO" , ""},
                { "V1HISP_OCORHIST" , ""},
                { "V1HISP_PRM_TAR" , ""},
                { "V1HISP_VAL_DES" , ""},
                { "V1HISP_VLADIFRA" , ""},
                { "V1HISP_DTQITBCO" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0010B_V1HISTOPARC", q2);

            #endregion

            #region AC0010B_V1APOLCOSCED

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1APCD_CODCOSS" , ""},
                { "V1APCD_PCPARTIC" , ""},
                { "V1APCD_PCCOMCOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0010B_V1APOLCOSCED", q3);

            #endregion

            #region R0700_00_SELECT_GE397_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_GE397_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_CDFRACIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q5);

            #endregion

            #region AC0010B_V2HISTOPARC

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V2HISP_DTMOVTO" , ""},
                { "V2HISP_OCORHIST" , ""},
                { "V2HISP_OPERACAO" , ""},
                { "V2HISP_PRM_TAR" , ""},
                { "V2HISP_VAL_DES" , ""},
                { "V2HISP_VLADIFRA" , ""},
                { "V2HISP_DTQITBCO" , ""},
                { "V2PARC_PRM_TAR" , ""},
                { "V2PARC_VAL_DES" , ""},
                { "V2PARC_OTNADFRA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0010B_V2HISTOPARC", q6);

            #endregion

            #region R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1ORDC_ORD_CEDIDO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1300_00_SUM_V1PARC_COMPL_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V3PCOM_VLR_COMPL_IX" , ""},
                { "V3PCOM_VLR_COMPL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SUM_V1PARC_COMPL_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1400_00_SUM_V1HISTOPARC_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V3HISP_PRM_TAR" , ""},
                { "V3HISP_VAL_DES" , ""},
                { "V3HISP_VLADIFRA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SUM_V1HISTOPARC_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MOVHBT_NUM_APOL" , ""},
                { "MOVHBT_NUM_ENDS" , ""},
                { "MOVHBT_VAL_REMUN" , ""},
                { "MOVHBT_VAL_SUSEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNADFRA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1PCOM_VLR_COMPL_IX" , ""},
                { "V1PCOM_VLR_COMPL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1PLCO_PCCOMSEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2400_00_SUM_V1PARCELA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V3PARC_PRM_TAR" , ""},
                { "V3PARC_VAL_DES" , ""},
                { "V3PARC_OTNADFRA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SUM_V1PARCELA_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2600_00_INSERT_COSSEG_PREM_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSEG_PREM_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R2900_00_INSERT_COSSEG_HIST_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
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
                { "V0CHIS_SIT_LIBREC" , ""},
                { "V0CHIS_NUM_OCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2900_00_INSERT_COSSEG_HIST_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R3100_00_EMISSAO_HISTOPARC_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V3HISP_DTMOVTO" , ""},
                { "V3HISP_PRM_TAR" , ""},
                { "V3HISP_VAL_DES" , ""},
                { "V3HISP_VLADIFRA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_EMISSAO_HISTOPARC_DB_SELECT_1_Query1", q17);

            #endregion

            #region R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1", q18);

            #endregion

            #region R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V3CHIS_PRM_TAR" , ""},
                { "V3CHIS_VAL_DES" , ""},
                { "V3CHIS_VLADIFRA" , ""},
                { "V3CHIS_VLCOMIS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1", q19);

            #endregion

            #region R3600_00_UPDATE_COSSEG_PREM_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""},
                { "WHOST_OCORHIST" , ""},
                { "V1HISP_NUM_APOL" , ""},
                { "V1HISP_NRPARCEL" , ""},
                { "V1APCD_CODCOSS" , ""},
                { "V1HISP_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3600_00_UPDATE_COSSEG_PREM_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
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
                { "V2CHIS_SIT_LIBREC" , ""},
                { "V2CHIS_NUM_OCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_OCORHIST" , ""},
                { "V2CHIS_CONGENER" , ""},
                { "V2CHIS_NUM_APOL" , ""},
                { "V2CHIS_NRPARCEL" , ""},
                { "V2CHIS_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1", q23);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0010B_Tests_Fact()
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
                var program = new AC0010B();
                program.Execute();

                Assert.True(true);
            }
        }
    }
}