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
using static Code.AC0812B;

namespace FileTests.Test
{
    [Collection("AC0812B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class AC0812B_Tests
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

            #region AC0812B_V1RELATORIOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , ""},
                { "V1RELA_DATA_SOL" , ""},
                { "V1RELA_IDSISTEM" , ""},
                { "V1RELA_CODRELAT" , ""},
                { "V1RELA_PERI_INI" , ""},
                { "V1RELA_PERI_FIN" , ""},
                { "V1RELA_DATA_REF" , ""},
                { "V1RELA_CONGENER" , ""},
                { "V1RELA_CODUNIMO" , ""},
                { "V1RELA_CORRECAO" , ""},
                { "V1RELA_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0812B_V1RELATORIOS", q1);

            #endregion

            #region AC0812B_V0COSCEDCHEQUE

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , ""},
                { "V1CCHQ_DTLIBERA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0812B_V0COSCEDCHEQUE", q2);

            #endregion

            #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

            #endregion

            #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

            #endregion

            #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

            #endregion

            #region AC0812B_V1COSGHISTP

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , ""},
                { "V1CHIS_CONGENER" , ""},
                { "V1CHIS_NUM_APOL" , ""},
                { "V1CHIS_NUM_ENDS" , ""},
                { "V1CHIS_NRPARCEL" , ""},
                { "V1CHIS_OCORHIST" , ""},
                { "V1CHIS_OPERACAO" , ""},
                { "V1CHIS_TIP_SEGU" , ""},
                { "V1CHIS_PRM_TARF" , ""},
                { "V1CHIS_VAL_DESC" , ""},
                { "V1CHIS_VLPRMLIQ" , ""},
                { "V1CHIS_VLADIFRA" , ""},
                { "V1CHIS_VLCOMISS" , ""},
                { "V1CHIS_VLPRMTOT" , ""},
                { "V1CHIS_DAT_MOVT" , ""},
                { "V1CHIS_DTQITBCO" , ""},
                { "V1CHIS_NUM_OCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSGHISTP", q8);

            #endregion

            #region AC0812B_V1COSSEGHIS

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , ""},
                { "V1CHIS_CONGENER" , ""},
                { "V1CHIS_NUM_APOL" , ""},
                { "V1CHIS_NUM_ENDS" , ""},
                { "V1CHIS_NRPARCEL" , ""},
                { "V1CHIS_OCORHIST" , ""},
                { "V1CHIS_OPERACAO" , ""},
                { "V1CHIS_TIP_SEGU" , ""},
                { "V1CHIS_PRM_TARF" , ""},
                { "V1CHIS_VAL_DESC" , ""},
                { "V1CHIS_VLPRMLIQ" , ""},
                { "V1CHIS_VLADIFRA" , ""},
                { "V1CHIS_VLCOMISS" , ""},
                { "V1CHIS_VLPRMTOT" , ""},
                { "V1CHIS_DAT_MOVT" , ""},
                { "V1CHIS_DTQITBCO" , ""},
                { "V1CHIS_NUM_OCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSSEGHIS", q9);

            #endregion

            #region R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , ""},
                { "V1RELA_DATA_SOL" , ""},
                { "V1RELA_IDSISTEM" , ""},
                { "V1RELA_CODRELAT" , ""},
                { "V1RELA_CONGENER" , ""},
                { "V1RELA_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q11);

            #endregion

            #region R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , ""},
                { "V0ENDO_TIPO_ENDO" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_DTINIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , ""},
                { "V1CPRE_PRMTAR_IX" , ""},
                { "V1CPRE_VLDESC_IX" , ""},
                { "V1CPRE_OTNPRLIQ" , ""},
                { "V1CPRE_OTNADFRA" , ""},
                { "V1CPRE_VLCOMS_IX" , ""},
                { "V1CPRE_OTNTOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , ""},
                { "V1CHIS_VAL_DESC" , ""},
                { "V1CHIS_VLPRMLIQ" , ""},
                { "V1CHIS_VLADIFRA" , ""},
                { "V1CHIS_VLCOMISS" , ""},
                { "V1CHIS_VLPRMTOT" , ""},
                { "V1CHIS_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_PRM_TARF" , ""},
                { "V2CHIS_VAL_DESC" , ""},
                { "V2CHIS_VLPRMLIQ" , ""},
                { "V2CHIS_VLADIFRA" , ""},
                { "V2CHIS_VLCOMISS" , ""},
                { "V2CHIS_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1", q16);

            #endregion

            #region R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q17);

            #endregion

            #region R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , ""},
                { "V0CHIS_CONGENER" , ""},
                { "V0CHIS_NUM_APOL" , ""},
                { "V0CHIS_NUM_ENDS" , ""},
                { "V0CHIS_NRPARCEL" , ""},
                { "V0CHIS_OCORHIST" , ""},
                { "V0CHIS_OPERACAO" , ""},
                { "V0CHIS_DAT_MOVT" , ""},
                { "V0CHIS_TIP_SEGU" , ""},
                { "V0CHIS_PRM_TARF" , ""},
                { "V0CHIS_VAL_DESC" , ""},
                { "V0CHIS_VLPRMLIQ" , ""},
                { "V0CHIS_VLADIFRA" , ""},
                { "V0CHIS_VLCOMISS" , ""},
                { "V0CHIS_VLPRMTOT" , ""},
                { "V0CHIS_DTQITBCO" , ""},
                { "V0CHIS_SIT_FINC" , ""},
                { "V0CHIS_SIT_LIBR" , ""},
                { "V0CHIS_NUM_OCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , ""},
                { "V1CHIS_CONGENER" , ""},
                { "V1CHIS_NUM_APOL" , ""},
                { "V1CHIS_NUM_ENDS" , ""},
                { "V1CHIS_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , ""},
                { "V1CHIS_NUM_APOL" , ""},
                { "V1CHIS_NUM_ENDS" , ""},
                { "V1CHIS_NRPARCEL" , ""},
                { "V1CHIS_OCORHIST" , ""},
                { "V1CHIS_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_AC" , ""},
                { "WHOST_DTMOVTO_AC1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q21);

            #endregion

            #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLRPREMIO" , ""},
                { "WHOST_VLRDESCON" , ""},
                { "WHOST_VLRADIFRA" , ""},
                { "WHOST_VLR_COMIS" , ""},
                { "WHOST_VLR_SINIS" , ""},
                { "WHOST_VLDESPESA" , ""},
                { "WHOST_VLR_HONOR" , ""},
                { "WHOST_VLR_SALVD" , ""},
                { "WHOST_VLRESSARC" , ""},
                { "WHOST_VALOR_EDI" , ""},
                { "WHOST_VALOR_USS" , ""},
                { "WHOST_VLEQPVNDA" , ""},
                { "WHOST_VLDESPADM" , ""},
                { "WHOST_OUTRDEBIT" , ""},
                { "WHOST_OUTRCREDT" , ""},
                { "WHOST_VLRSLDANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1", q22);

            #endregion

            #region R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , ""},
                { "V0CCHQ_CONGENER" , ""},
                { "V0CCHQ_DTMOVTO_AC" , ""},
                { "V0CCHQ_CODUSU_AC" , ""},
                { "V0CCHQ_DTLIBERA" , ""},
                { "V0CCHQ_VLPREMIO" , ""},
                { "V0CCHQ_VLRDESCON" , ""},
                { "V0CCHQ_VLRADIFRA" , ""},
                { "V0CCHQ_VLRCOMIS" , ""},
                { "V0CCHQ_OUTRDEBIT" , ""},
                { "V0CCHQ_VLRSLDANT" , ""},
                { "V0CCHQ_COD_MOEDA" , ""},
                { "V0CCHQ_DTMOVTO_FI" , ""},
                { "V0CCHQ_CODUSU_FI" , ""},
                { "V0CCHQ_DTCORRECAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1", q23);

            #endregion

            #endregion
        }
        [Fact]
        public void AC0812B_Test_Cenario_1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0812B_V1RELATORIOS

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_PERI_INI" , "2023-01-01" },
                { "V1RELA_PERI_FIN" , "2023-12-01" },
                { "V1RELA_DATA_REF" , "2023-12-01" },
                { "V1RELA_CONGENER" , "general01" },
                { "V1RELA_CODUNIMO" , "unit001" },
                { "V1RELA_CORRECAO" , "correction01" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1RELATORIOS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1RELATORIOS", q1);

                #endregion

                #region AC0812B_V0COSCEDCHEQUE

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "general02" },
                { "V1CCHQ_DTLIBERA" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V0COSCEDCHEQUE");
AppSettings.TestSet.DynamicData.Add("AC0812B_V0COSCEDCHEQUE", q2);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "5" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "5" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "5" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "5" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                #endregion

                #region AC0812B_V1COSGHISTP

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "3" },
                { "V1CHIS_OCORHIST" , "history01" },
                { "V1CHIS_OPERACAO" , "operation01" },
                { "V1CHIS_TIP_SEGU" , "insuranceType01" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSGHISTP");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSGHISTP", q8);

                #endregion

                #region AC0812B_V1COSSEGHIS

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "3" },
                { "V1CHIS_OCORHIST" , "history01" },
                { "V1CHIS_OPERACAO" , "operation01" },
                { "V1CHIS_TIP_SEGU" , "insuranceType01" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSSEGHIS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSSEGHIS", q9);

                #endregion

                #region R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "200.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "general01" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q11);

                #endregion

                #region R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "type01" },
                { "V0ENDO_CORRECAO" , "correction02" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history02" },
                { "V1CPRE_PRMTAR_IX" , "120.0" },
                { "V1CPRE_VLDESC_IX" , "12.0" },
                { "V1CPRE_OTNPRLIQ" , "108.0" },
                { "V1CPRE_OTNADFRA" , "6.0" },
                { "V1CPRE_VLCOMS_IX" , "18.0" },
                { "V1CPRE_OTNTOTAL" , "126.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_PRM_TARF" , "130.0" },
                { "V2CHIS_VAL_DESC" , "13.0" },
                { "V2CHIS_VLPRMLIQ" , "117.0" },
                { "V2CHIS_VLADIFRA" , "7.0" },
                { "V2CHIS_VLCOMISS" , "19.0" },
                { "V2CHIS_VLPRMTOT" , "136.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "1000.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "general04" },
                { "V0CHIS_NUM_APOL" , "policy002" },
                { "V0CHIS_NUM_ENDS" , "endorsement002" },
                { "V0CHIS_NRPARCEL" , "4" },
                { "V0CHIS_OCORHIST" , "history03" },
                { "V0CHIS_OPERACAO" , "operation02" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "insuranceType02" },
                { "V0CHIS_PRM_TARF" , "140.0" },
                { "V0CHIS_VAL_DESC" , "14.0" },
                { "V0CHIS_VLPRMLIQ" , "126.0" },
                { "V0CHIS_VLADIFRA" , "8.0" },
                { "V0CHIS_VLCOMISS" , "20.0" },
                { "V0CHIS_VLPRMTOT" , "146.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-01" },
                { "V0CHIS_SIT_FINC" , "situation01" },
                { "V0CHIS_SIT_LIBR" , "situation02" },
                { "V0CHIS_NUM_OCOR" , "occurrence002" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history02" },
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "3" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "3" },
                { "V1CHIS_OCORHIST" , "history01" },
                { "V1CHIS_OPERACAO" , "operation01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q20);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_AC" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q21);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLRPREMIO" , "1500.0" },
                { "WHOST_VLRDESCON" , "150.0" },
                { "WHOST_VLRADIFRA" , "75.0" },
                { "WHOST_VLR_COMIS" , "225.0" },
                { "WHOST_VLR_SINIS" , "500.0" },
                { "WHOST_VLDESPESA" , "100.0" },
                { "WHOST_VLR_HONOR" , "50.0" },
                { "WHOST_VLR_SALVD" , "25.0" },
                { "WHOST_VLRESSARC" , "200.0" },
                { "WHOST_VALOR_EDI" , "10000.0" },
                { "WHOST_VALOR_USS" , "5000.0" },
                { "WHOST_VLEQPVNDA" , "7500.0" },
                { "WHOST_VLDESPADM" , "300.0" },
                { "WHOST_OUTRDEBIT" , "400.0" },
                { "WHOST_OUTRCREDT" , "500.0" },
                { "WHOST_VLRSLDANT" , "600.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1", q22);

                #endregion

                #region R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1

    var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , "company004" },
                { "V0CCHQ_CONGENER" , "general05" },
                { "V0CCHQ_DTMOVTO_AC" , "2023-12-01" },
                { "V0CCHQ_CODUSU_AC" , "user124" },
                { "V0CCHQ_DTLIBERA" , "2023-12-01" },
                { "V0CCHQ_VLPREMIO" , "1600.0" },
                { "V0CCHQ_VLRDESCON" , "160.0" },
                { "V0CCHQ_VLRADIFRA" , "80.0" },
                { "V0CCHQ_VLRCOMIS" , "240.0" },
                { "V0CCHQ_OUTRDEBIT" , "500.0" },
                { "V0CCHQ_VLRSLDANT" , "700.0" },
                { "V0CCHQ_COD_MOEDA" , "EUR" },
                { "V0CCHQ_DTMOVTO_FI" , "2023-12-01" },
                { "V0CCHQ_CODUSU_FI" , "user125" },
                { "V0CCHQ_DTCORRECAO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1", q23);

                #endregion
#endregion
#endregion


                var program = new AC0812B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Fact]
        public void AC0812B_Test_Cenario_2()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0812B_V1RELATORIOS

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_PERI_INI" , "2023-01-01" },
                { "V1RELA_PERI_FIN" , "2023-12-01" },
                { "V1RELA_DATA_REF" , "2023-12-01" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_CODUNIMO" , "unit001" },
                { "V1RELA_CORRECAO" , "N" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1RELATORIOS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1RELATORIOS", q1);

                #endregion

                #region AC0812B_V0COSCEDCHEQUE

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "N" },
                { "V1CCHQ_DTLIBERA" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V0COSCEDCHEQUE");
AppSettings.TestSet.DynamicData.Add("AC0812B_V0COSCEDCHEQUE", q2);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                #endregion

                #region AC0812B_V1COSGHISTP

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "history002" },
                { "V1CHIS_OPERACAO" , "operation002" },
                { "V1CHIS_TIP_SEGU" , "type002" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "5.0" },
                { "V1CHIS_VLPRMLIQ" , "95.0" },
                { "V1CHIS_VLADIFRA" , "0.0" },
                { "V1CHIS_VLCOMISS" , "10.0" },
                { "V1CHIS_VLPRMTOT" , "105.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence002" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSGHISTP");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSGHISTP", q8);

                #endregion

                #region AC0812B_V1COSSEGHIS

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "history002" },
                { "V1CHIS_OPERACAO" , "operation002" },
                { "V1CHIS_TIP_SEGU" , "type002" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "5.0" },
                { "V1CHIS_VLPRMLIQ" , "95.0" },
                { "V1CHIS_VLADIFRA" , "0.0" },
                { "V1CHIS_VLCOMISS" , "10.0" },
                { "V1CHIS_VLPRMTOT" , "105.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence002" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSSEGHIS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSSEGHIS", q9);

                #endregion

                #region R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q11);

                #endregion

                #region R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "typeE002" },
                { "V0ENDO_CORRECAO" , "N" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history003" },
                { "V1CPRE_PRMTAR_IX" , "100.0" },
                { "V1CPRE_VLDESC_IX" , "5.0" },
                { "V1CPRE_OTNPRLIQ" , "95.0" },
                { "V1CPRE_OTNADFRA" , "0.0" },
                { "V1CPRE_VLCOMS_IX" , "10.0" },
                { "V1CPRE_OTNTOTAL" , "105.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "5.0" },
                { "V1CHIS_VLPRMLIQ" , "95.0" },
                { "V1CHIS_VLADIFRA" , "0.0" },
                { "V1CHIS_VLCOMISS" , "10.0" },
                { "V1CHIS_VLPRMTOT" , "105.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_PRM_TARF" , "100.0" },
                { "V2CHIS_VAL_DESC" , "5.0" },
                { "V2CHIS_VLPRMLIQ" , "95.0" },
                { "V2CHIS_VLADIFRA" , "0.0" },
                { "V2CHIS_VLCOMISS" , "10.0" },
                { "V2CHIS_VLPRMTOT" , "105.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "1000.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "N" },
                { "V0CHIS_NUM_APOL" , "policy003" },
                { "V0CHIS_NUM_ENDS" , "endorse003" },
                { "V0CHIS_NRPARCEL" , "1" },
                { "V0CHIS_OCORHIST" , "history004" },
                { "V0CHIS_OPERACAO" , "operation003" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "type003" },
                { "V0CHIS_PRM_TARF" , "100.0" },
                { "V0CHIS_VAL_DESC" , "5.0" },
                { "V0CHIS_VLPRMLIQ" , "95.0" },
                { "V0CHIS_VLADIFRA" , "0.0" },
                { "V0CHIS_VLCOMISS" , "10.0" },
                { "V0CHIS_VLPRMTOT" , "105.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-01" },
                { "V0CHIS_SIT_FINC" , "N" },
                { "V0CHIS_SIT_LIBR" , "N" },
                { "V0CHIS_NUM_OCOR" , "occurrence003" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history003" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "history002" },
                { "V1CHIS_OPERACAO" , "operation002" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q20);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_AC" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q21);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLRPREMIO" , "100.0" },
                { "WHOST_VLRDESCON" , "5.0" },
                { "WHOST_VLRADIFRA" , "0.0" },
                { "WHOST_VLR_COMIS" , "10.0" },
                { "WHOST_VLR_SINIS" , "50.0" },
                { "WHOST_VLDESPESA" , "20.0" },
                { "WHOST_VLR_HONOR" , "30.0" },
                { "WHOST_VLR_SALVD" , "40.0" },
                { "WHOST_VLRESSARC" , "60.0" },
                { "WHOST_VALOR_EDI" , "70.0" },
                { "WHOST_VALOR_USS" , "80.0" },
                { "WHOST_VLEQPVNDA" , "90.0" },
                { "WHOST_VLDESPADM" , "25.0" },
                { "WHOST_OUTRDEBIT" , "15.0" },
                { "WHOST_OUTRCREDT" , "35.0" },
                { "WHOST_VLRSLDANT" , "45.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1", q22);

                #endregion

                #region R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1

    var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , "company004" },
                { "V0CCHQ_CONGENER" , "N" },
                { "V0CCHQ_DTMOVTO_AC" , "2023-12-01" },
                { "V0CCHQ_CODUSU_AC" , "user004" },
                { "V0CCHQ_DTLIBERA" , "2023-12-01" },
                { "V0CCHQ_VLPREMIO" , "100.0" },
                { "V0CCHQ_VLRDESCON" , "5.0" },
                { "V0CCHQ_VLRADIFRA" , "0.0" },
                { "V0CCHQ_VLRCOMIS" , "10.0" },
                { "V0CCHQ_OUTRDEBIT" , "15.0" },
                { "V0CCHQ_VLRSLDANT" , "45.0" },
                { "V0CCHQ_COD_MOEDA" , "USD" },
                { "V0CCHQ_DTMOVTO_FI" , "2023-12-01" },
                { "V0CCHQ_CODUSU_FI" , "user005" },
                { "V0CCHQ_DTCORRECAO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1", q23);

                #endregion
#endregion
#endregion


                var program = new AC0812B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Fact]
        public void AC0812B_Test_Cenario_3()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0812B_V1RELATORIOS

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_PERI_INI" , "2023-11-01" },
                { "V1RELA_PERI_FIN" , "2023-11-30" },
                { "V1RELA_DATA_REF" , "2023-11-15" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_CODUNIMO" , "unit001" },
                { "V1RELA_CORRECAO" , "N" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1RELATORIOS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1RELATORIOS", q1);

                #endregion

                #region AC0812B_V0COSCEDCHEQUE

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "N" },
                { "V1CCHQ_DTLIBERA" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V0COSCEDCHEQUE");
AppSettings.TestSet.DynamicData.Add("AC0812B_V0COSCEDCHEQUE", q2);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "5" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                #endregion

                #region AC0812B_V1COSGHISTP

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "0.0" },
                { "V1CHIS_VLCOMISS" , "5.0" },
                { "V1CHIS_VLPRMTOT" , "95.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-02" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSGHISTP");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSGHISTP", q8);

                #endregion

                #region AC0812B_V1COSSEGHIS

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "0.0" },
                { "V1CHIS_VLCOMISS" , "5.0" },
                { "V1CHIS_VLPRMTOT" , "95.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-02" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSSEGHIS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSSEGHIS", q9);

                #endregion

                #region R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "50.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q11);

                #endregion

                #region R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "type002" },
                { "V0ENDO_CORRECAO" , "N" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "event002" },
                { "V1CPRE_PRMTAR_IX" , "200.0" },
                { "V1CPRE_VLDESC_IX" , "20.0" },
                { "V1CPRE_OTNPRLIQ" , "180.0" },
                { "V1CPRE_OTNADFRA" , "0.0" },
                { "V1CPRE_VLCOMS_IX" , "10.0" },
                { "V1CPRE_OTNTOTAL" , "190.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "0.0" },
                { "V1CHIS_VLCOMISS" , "5.0" },
                { "V1CHIS_VLPRMTOT" , "95.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-02" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_PRM_TARF" , "300.0" },
                { "V2CHIS_VAL_DESC" , "30.0" },
                { "V2CHIS_VLPRMLIQ" , "270.0" },
                { "V2CHIS_VLADIFRA" , "0.0" },
                { "V2CHIS_VLCOMISS" , "15.0" },
                { "V2CHIS_VLPRMTOT" , "285.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "1000.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "N" },
                { "V0CHIS_NUM_APOL" , "policy002" },
                { "V0CHIS_NUM_ENDS" , "endorsement002" },
                { "V0CHIS_NRPARCEL" , "2" },
                { "V0CHIS_OCORHIST" , "event003" },
                { "V0CHIS_OPERACAO" , "operation002" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "type003" },
                { "V0CHIS_PRM_TARF" , "400.0" },
                { "V0CHIS_VAL_DESC" , "40.0" },
                { "V0CHIS_VLPRMLIQ" , "360.0" },
                { "V0CHIS_VLADIFRA" , "0.0" },
                { "V0CHIS_VLCOMISS" , "20.0" },
                { "V0CHIS_VLPRMTOT" , "380.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-03" },
                { "V0CHIS_SIT_FINC" , "status001" },
                { "V0CHIS_SIT_LIBR" , "status002" },
                { "V0CHIS_NUM_OCOR" , "occurrence002" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "event002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event001" },
                { "V1CHIS_OPERACAO" , "operation001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q20);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_AC" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q21);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLRPREMIO" , "500.0" },
                { "WHOST_VLRDESCON" , "50.0" },
                { "WHOST_VLRADIFRA" , "0.0" },
                { "WHOST_VLR_COMIS" , "25.0" },
                { "WHOST_VLR_SINIS" , "100.0" },
                { "WHOST_VLDESPESA" , "30.0" },
                { "WHOST_VLR_HONOR" , "20.0" },
                { "WHOST_VLR_SALVD" , "10.0" },
                { "WHOST_VLRESSARC" , "5.0" },
                { "WHOST_VALOR_EDI" , "200.0" },
                { "WHOST_VALOR_USS" , "100.0" },
                { "WHOST_VLEQPVNDA" , "150.0" },
                { "WHOST_VLDESPADM" , "25.0" },
                { "WHOST_OUTRDEBIT" , "5.0" },
                { "WHOST_OUTRCREDT" , "10.0" },
                { "WHOST_VLRSLDANT" , "95.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1", q22);

                #endregion

                #region R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1

    var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , "company004" },
                { "V0CCHQ_CONGENER" , "N" },
                { "V0CCHQ_DTMOVTO_AC" , "2023-12-01" },
                { "V0CCHQ_CODUSU_AC" , "user124" },
                { "V0CCHQ_DTLIBERA" , "2023-12-01" },
                { "V0CCHQ_VLPREMIO" , "600.0" },
                { "V0CCHQ_VLRDESCON" , "60.0" },
                { "V0CCHQ_VLRADIFRA" , "0.0" },
                { "V0CCHQ_VLRCOMIS" , "30.0" },
                { "V0CCHQ_OUTRDEBIT" , "10.0" },
                { "V0CCHQ_VLRSLDANT" , "620.0" },
                { "V0CCHQ_COD_MOEDA" , "EUR" },
                { "V0CCHQ_DTMOVTO_FI" , "2023-12-02" },
                { "V0CCHQ_CODUSU_FI" , "user125" },
                { "V0CCHQ_DTCORRECAO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1", q23);

                #endregion
#endregion
#endregion


                var program = new AC0812B();
                program.Execute();

                var CVPAGSIN_FILE_NAME_P = (string)(    AppSettings.TestSet.DynamicData        .Where(dd => dd.Value.DynamicList.Any(            d => d.ContainsKey("CVPAGSIN_FILE_NAME_P")))        .Select(dd => dd.Value.DynamicList.First()                           .GetValueOrDefault("CVPAGSIN_FILE_NAME_P"))        .FirstOrDefault()        ?? "");

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Fact]
        public void AC0812B_Test_Cenario_4()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0812B_V1RELATORIOS

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_PERI_INI" , "2023-01-01" },
                { "V1RELA_PERI_FIN" , "2023-12-01" },
                { "V1RELA_DATA_REF" , "2023-12-01" },
                { "V1RELA_CONGENER" , "general01" },
                { "V1RELA_CODUNIMO" , "unit001" },
                { "V1RELA_CORRECAO" , "correction01" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1RELATORIOS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1RELATORIOS", q1);

                #endregion

                #region AC0812B_V0COSCEDCHEQUE

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "general02" },
                { "V1CCHQ_DTLIBERA" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V0COSCEDCHEQUE");
AppSettings.TestSet.DynamicData.Add("AC0812B_V0COSCEDCHEQUE", q2);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "1" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                #endregion

                #region AC0812B_V1COSGHISTP

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "history001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSGHISTP");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSGHISTP", q8);

                #endregion

                #region AC0812B_V1COSSEGHIS

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "history001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSSEGHIS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSSEGHIS", q9);

                #endregion

                #region R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "50.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "general01" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q11);

                #endregion

                #region R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "type002" },
                { "V0ENDO_CORRECAO" , "correction02" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history002" },
                { "V1CPRE_PRMTAR_IX" , "200.0" },
                { "V1CPRE_VLDESC_IX" , "20.0" },
                { "V1CPRE_OTNPRLIQ" , "180.0" },
                { "V1CPRE_OTNADFRA" , "10.0" },
                { "V1CPRE_VLCOMS_IX" , "30.0" },
                { "V1CPRE_OTNTOTAL" , "220.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_PRM_TARF" , "300.0" },
                { "V2CHIS_VAL_DESC" , "30.0" },
                { "V2CHIS_VLPRMLIQ" , "270.0" },
                { "V2CHIS_VLADIFRA" , "15.0" },
                { "V2CHIS_VLCOMISS" , "45.0" },
                { "V2CHIS_VLPRMTOT" , "330.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "1000.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "general04" },
                { "V0CHIS_NUM_APOL" , "policy002" },
                { "V0CHIS_NUM_ENDS" , "endorsement002" },
                { "V0CHIS_NRPARCEL" , "2" },
                { "V0CHIS_OCORHIST" , "history003" },
                { "V0CHIS_OPERACAO" , "operation002" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "type003" },
                { "V0CHIS_PRM_TARF" , "400.0" },
                { "V0CHIS_VAL_DESC" , "40.0" },
                { "V0CHIS_VLPRMLIQ" , "360.0" },
                { "V0CHIS_VLADIFRA" , "20.0" },
                { "V0CHIS_VLCOMISS" , "60.0" },
                { "V0CHIS_VLPRMTOT" , "440.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-01" },
                { "V0CHIS_SIT_FINC" , "situation01" },
                { "V0CHIS_SIT_LIBR" , "situation02" },
                { "V0CHIS_NUM_OCOR" , "2" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history002" },
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "history001" },
                { "V1CHIS_OPERACAO" , "operation001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q20);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_AC" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q21);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLRPREMIO" , "500.0" },
                { "WHOST_VLRDESCON" , "50.0" },
                { "WHOST_VLRADIFRA" , "25.0" },
                { "WHOST_VLR_COMIS" , "75.0" },
                { "WHOST_VLR_SINIS" , "100.0" },
                { "WHOST_VLDESPESA" , "30.0" },
                { "WHOST_VLR_HONOR" , "20.0" },
                { "WHOST_VLR_SALVD" , "10.0" },
                { "WHOST_VLRESSARC" , "5.0" },
                { "WHOST_VALOR_EDI" , "2000.0" },
                { "WHOST_VALOR_USS" , "1500.0" },
                { "WHOST_VLEQPVNDA" , "2500.0" },
                { "WHOST_VLDESPADM" , "100.0" },
                { "WHOST_OUTRDEBIT" , "50.0" },
                { "WHOST_OUTRCREDT" , "25.0" },
                { "WHOST_VLRSLDANT" , "500.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1", q22);

                #endregion

                #region R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1

    var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , "company004" },
                { "V0CCHQ_CONGENER" , "general05" },
                { "V0CCHQ_DTMOVTO_AC" , "2023-12-01" },
                { "V0CCHQ_CODUSU_AC" , "user124" },
                { "V0CCHQ_DTLIBERA" , "2023-12-01" },
                { "V0CCHQ_VLPREMIO" , "600.0" },
                { "V0CCHQ_VLRDESCON" , "60.0" },
                { "V0CCHQ_VLRADIFRA" , "30.0" },
                { "V0CCHQ_VLRCOMIS" , "90.0" },
                { "V0CCHQ_OUTRDEBIT" , "60.0" },
                { "V0CCHQ_VLRSLDANT" , "600.0" },
                { "V0CCHQ_COD_MOEDA" , "EUR" },
                { "V0CCHQ_DTMOVTO_FI" , "2023-12-01" },
                { "V0CCHQ_CODUSU_FI" , "user125" },
                { "V0CCHQ_DTCORRECAO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1", q23);

                #endregion
#endregion
#endregion


                var program = new AC0812B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Fact]
        public void AC0812B_Test_Cenario_5()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0812B_V1RELATORIOS

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_PERI_INI" , "2023-01-01" },
                { "V1RELA_PERI_FIN" , "2023-12-01" },
                { "V1RELA_DATA_REF" , "2023-12-01" },
                { "V1RELA_CONGENER" , "general01" },
                { "V1RELA_CODUNIMO" , "unit001" },
                { "V1RELA_CORRECAO" , "correction01" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1RELATORIOS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1RELATORIOS", q1);

                #endregion

                #region AC0812B_V0COSCEDCHEQUE

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "general02" },
                { "V1CCHQ_DTLIBERA" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V0COSCEDCHEQUE");
AppSettings.TestSet.DynamicData.Add("AC0812B_V0COSCEDCHEQUE", q2);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "1" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                #endregion

                #region AC0812B_V1COSGHISTP

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "history01" },
                { "V1CHIS_OPERACAO" , "operation01" },
                { "V1CHIS_TIP_SEGU" , "type01" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSGHISTP");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSGHISTP", q8);

                #endregion

                #region AC0812B_V1COSSEGHIS

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "history01" },
                { "V1CHIS_OPERACAO" , "operation01" },
                { "V1CHIS_TIP_SEGU" , "type01" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSSEGHIS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSSEGHIS", q9);

                #endregion

                #region R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "50.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "general01" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q11);

                #endregion

                #region R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "type02" },
                { "V0ENDO_CORRECAO" , "correction02" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history02" },
                { "V1CPRE_PRMTAR_IX" , "200.0" },
                { "V1CPRE_VLDESC_IX" , "20.0" },
                { "V1CPRE_OTNPRLIQ" , "180.0" },
                { "V1CPRE_OTNADFRA" , "10.0" },
                { "V1CPRE_VLCOMS_IX" , "30.0" },
                { "V1CPRE_OTNTOTAL" , "220.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_PRM_TARF" , "300.0" },
                { "V2CHIS_VAL_DESC" , "30.0" },
                { "V2CHIS_VLPRMLIQ" , "270.0" },
                { "V2CHIS_VLADIFRA" , "15.0" },
                { "V2CHIS_VLCOMISS" , "45.0" },
                { "V2CHIS_VLPRMTOT" , "330.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "1000.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "general04" },
                { "V0CHIS_NUM_APOL" , "policy002" },
                { "V0CHIS_NUM_ENDS" , "endorsement002" },
                { "V0CHIS_NRPARCEL" , "2" },
                { "V0CHIS_OCORHIST" , "history03" },
                { "V0CHIS_OPERACAO" , "operation02" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "type03" },
                { "V0CHIS_PRM_TARF" , "400.0" },
                { "V0CHIS_VAL_DESC" , "40.0" },
                { "V0CHIS_VLPRMLIQ" , "360.0" },
                { "V0CHIS_VLADIFRA" , "20.0" },
                { "V0CHIS_VLCOMISS" , "60.0" },
                { "V0CHIS_VLPRMTOT" , "440.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-01" },
                { "V0CHIS_SIT_FINC" , "situation01" },
                { "V0CHIS_SIT_LIBR" , "situation02" },
                { "V0CHIS_NUM_OCOR" , "occurrence002" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history02" },
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "general03" },
                { "V1CHIS_NUM_APOL" , "policy001" },
                { "V1CHIS_NUM_ENDS" , "endorsement001" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "history01" },
                { "V1CHIS_OPERACAO" , "operation01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q20);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_AC" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q21);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLRPREMIO" , "500.0" },
                { "WHOST_VLRDESCON" , "50.0" },
                { "WHOST_VLRADIFRA" , "25.0" },
                { "WHOST_VLR_COMIS" , "75.0" },
                { "WHOST_VLR_SINIS" , "100.0" },
                { "WHOST_VLDESPESA" , "30.0" },
                { "WHOST_VLR_HONOR" , "20.0" },
                { "WHOST_VLR_SALVD" , "10.0" },
                { "WHOST_VLRESSARC" , "5.0" },
                { "WHOST_VALOR_EDI" , "2000.0" },
                { "WHOST_VALOR_USS" , "1500.0" },
                { "WHOST_VLEQPVNDA" , "2500.0" },
                { "WHOST_VLDESPADM" , "100.0" },
                { "WHOST_OUTRDEBIT" , "50.0" },
                { "WHOST_OUTRCREDT" , "75.0" },
                { "WHOST_VLRSLDANT" , "500.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1", q22);

                #endregion

                #region R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1

    var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , "company004" },
                { "V0CCHQ_CONGENER" , "general05" },
                { "V0CCHQ_DTMOVTO_AC" , "2023-12-01" },
                { "V0CCHQ_CODUSU_AC" , "user124" },
                { "V0CCHQ_DTLIBERA" , "2023-12-01" },
                { "V0CCHQ_VLPREMIO" , "600.0" },
                { "V0CCHQ_VLRDESCON" , "60.0" },
                { "V0CCHQ_VLRADIFRA" , "30.0" },
                { "V0CCHQ_VLRCOMIS" , "90.0" },
                { "V0CCHQ_OUTRDEBIT" , "55.0" },
                { "V0CCHQ_VLRSLDANT" , "550.0" },
                { "V0CCHQ_COD_MOEDA" , "EUR" },
                { "V0CCHQ_DTMOVTO_FI" , "2023-12-01" },
                { "V0CCHQ_CODUSU_FI" , "user125" },
                { "V0CCHQ_DTCORRECAO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1", q23);

                #endregion
#endregion
#endregion


                var program = new AC0812B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Fact]
        public void AC0812B_Test_Cenario_6()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0812B_V1RELATORIOS

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_PERI_INI" , "2023-01-01" },
                { "V1RELA_PERI_FIN" , "2023-12-31" },
                { "V1RELA_DATA_REF" , "2023-12-01" },
                { "V1RELA_CONGENER" , "general" },
                { "V1RELA_CODUNIMO" , "unit001" },
                { "V1RELA_CORRECAO" , "none" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1RELATORIOS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1RELATORIOS", q1);

                #endregion

                #region AC0812B_V0COSCEDCHEQUE

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "general" },
                { "V1CCHQ_DTLIBERA" , "2023-11-30" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V0COSCEDCHEQUE");
AppSettings.TestSet.DynamicData.Add("AC0812B_V0COSCEDCHEQUE", q2);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "5" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                #endregion

                #region AC0812B_V1COSGHISTP

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "12" },
                { "V1CHIS_OCORHIST" , "history001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSGHISTP");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSGHISTP", q8);

                #endregion

                #region AC0812B_V1COSSEGHIS

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "12" },
                { "V1CHIS_OCORHIST" , "history001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            });
            AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSSEGHIS");
AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSSEGHIS", q9);

                #endregion

                #region R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "200.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "general" },
                { "V1RELA_COD_EMPR" , "company001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q11);

                #endregion

                #region R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-11-30" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "type002" },
                { "V0ENDO_CORRECAO" , "none" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history002" },
                { "V1CPRE_PRMTAR_IX" , "150.0" },
                { "V1CPRE_VLDESC_IX" , "15.0" },
                { "V1CPRE_OTNPRLIQ" , "135.0" },
                { "V1CPRE_OTNADFRA" , "7.5" },
                { "V1CPRE_VLCOMS_IX" , "22.5" },
                { "V1CPRE_OTNTOTAL" , "165.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_PRM_TARF" , "120.0" },
                { "V2CHIS_VAL_DESC" , "12.0" },
                { "V2CHIS_VLPRMLIQ" , "108.0" },
                { "V2CHIS_VLADIFRA" , "6.0" },
                { "V2CHIS_VLCOMISS" , "18.0" },
                { "V2CHIS_VLPRMTOT" , "132.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "300.0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "general" },
                { "V0CHIS_NUM_APOL" , "policy124" },
                { "V0CHIS_NUM_ENDS" , "endorsement124" },
                { "V0CHIS_NRPARCEL" , "24" },
                { "V0CHIS_OCORHIST" , "history003" },
                { "V0CHIS_OPERACAO" , "operation002" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "type003" },
                { "V0CHIS_PRM_TARF" , "130.0" },
                { "V0CHIS_VAL_DESC" , "13.0" },
                { "V0CHIS_VLPRMLIQ" , "117.0" },
                { "V0CHIS_VLADIFRA" , "6.5" },
                { "V0CHIS_VLCOMISS" , "19.5" },
                { "V0CHIS_VLPRMTOT" , "143.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-01" },
                { "V0CHIS_SIT_FINC" , "settled" },
                { "V0CHIS_SIT_LIBR" , "released" },
                { "V0CHIS_NUM_OCOR" , "occurrence002" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history002" },
                { "V1CHIS_CONGENER" , "general" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "12" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "general" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "12" },
                { "V1CHIS_OCORHIST" , "history001" },
                { "V1CHIS_OPERACAO" , "operation001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q20);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_AC" , "2023-12-02" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q21);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLRPREMIO" , "500.0" },
                { "WHOST_VLRDESCON" , "50.0" },
                { "WHOST_VLRADIFRA" , "25.0" },
                { "WHOST_VLR_COMIS" , "75.0" },
                { "WHOST_VLR_SINIS" , "400.0" },
                { "WHOST_VLDESPESA" , "100.0" },
                { "WHOST_VLR_HONOR" , "200.0" },
                { "WHOST_VLR_SALVD" , "150.0" },
                { "WHOST_VLRESSARC" , "350.0" },
                { "WHOST_VALOR_EDI" , "1000.0" },
                { "WHOST_VALOR_USS" , "800.0" },
                { "WHOST_VLEQPVNDA" , "1200.0" },
                { "WHOST_VLDESPADM" , "300.0" },
                { "WHOST_OUTRDEBIT" , "400.0" },
                { "WHOST_OUTRCREDT" , "500.0" },
                { "WHOST_VLRSLDANT" , "600.0" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1", q22);

                #endregion

                #region R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1

    var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , "company004" },
                { "V0CCHQ_CONGENER" , "general" },
                { "V0CCHQ_DTMOVTO_AC" , "2023-12-01" },
                { "V0CCHQ_CODUSU_AC" , "user124" },
                { "V0CCHQ_DTLIBERA" , "2023-11-30" },
                { "V0CCHQ_VLPREMIO" , "550.0" },
                { "V0CCHQ_VLRDESCON" , "55.0" },
                { "V0CCHQ_VLRADIFRA" , "27.5" },
                { "V0CCHQ_VLRCOMIS" , "82.5" },
                { "V0CCHQ_OUTRDEBIT" , "450.0" },
                { "V0CCHQ_VLRSLDANT" , "650.0" },
                { "V0CCHQ_COD_MOEDA" , "EUR" },
                { "V0CCHQ_DTMOVTO_FI" , "2023-12-01" },
                { "V0CCHQ_CODUSU_FI" , "user125" },
                { "V0CCHQ_DTCORRECAO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1", q23);

                #endregion
#endregion
#endregion


                var program = new AC0812B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);

            }
        }

        [Fact]
        public void AC0812B_Test_Cenario_6_Return99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0812B_V1RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_PERI_INI" , "2023-01-01" },
                { "V1RELA_PERI_FIN" , "2023-12-31" },
                { "V1RELA_DATA_REF" , "2023-12-01" },
                { "V1RELA_CONGENER" , "general" },
                { "V1RELA_CODUNIMO" , "unit001" },
                { "V1RELA_CORRECAO" , "none" },
                { "V1RELA_COD_EMPR" , "company001" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0812B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("AC0812B_V1RELATORIOS", q1);

                #endregion

                #region AC0812B_V0COSCEDCHEQUE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "general" },
                { "V1CCHQ_DTLIBERA" , "2023-11-30" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0812B_V0COSCEDCHEQUE");
                AppSettings.TestSet.DynamicData.Add("AC0812B_V0COSCEDCHEQUE", q2);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                #endregion

                #region R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "5" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                #endregion

                #region AC0812B_V1COSGHISTP

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "12" },
                { "V1CHIS_OCORHIST" , "history001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSGHISTP");
                AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSGHISTP", q8);

                #endregion

                #region AC0812B_V1COSSEGHIS

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "general" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "12" },
                { "V1CHIS_OCORHIST" , "history001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0812B_V1COSSEGHIS");
                AppSettings.TestSet.DynamicData.Add("AC0812B_V1COSSEGHIS", q9);

                #endregion

                #region R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "200.0" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "general" },
                { "V1RELA_COD_EMPR" , "company001" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q11);

                #endregion

                #region R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-11-30" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "type002" },
                { "V0ENDO_CORRECAO" , "none" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history002" },
                { "V1CPRE_PRMTAR_IX" , "150.0" },
                { "V1CPRE_VLDESC_IX" , "15.0" },
                { "V1CPRE_OTNPRLIQ" , "135.0" },
                { "V1CPRE_OTNADFRA" , "7.5" },
                { "V1CPRE_VLCOMS_IX" , "22.5" },
                { "V1CPRE_OTNTOTAL" , "165.0" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "110.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q15);

                #endregion

                #region R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V2CHIS_PRM_TARF" , "120.0" },
                { "V2CHIS_VAL_DESC" , "12.0" },
                { "V2CHIS_VLPRMLIQ" , "108.0" },
                { "V2CHIS_VLADIFRA" , "6.0" },
                { "V2CHIS_VLCOMISS" , "18.0" },
                { "V2CHIS_VLPRMTOT" , "132.0" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "300.0" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "general" },
                { "V0CHIS_NUM_APOL" , "policy124" },
                { "V0CHIS_NUM_ENDS" , "endorsement124" },
                { "V0CHIS_NRPARCEL" , "24" },
                { "V0CHIS_OCORHIST" , "history003" },
                { "V0CHIS_OPERACAO" , "operation002" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "type003" },
                { "V0CHIS_PRM_TARF" , "130.0" },
                { "V0CHIS_VAL_DESC" , "13.0" },
                { "V0CHIS_VLPRMLIQ" , "117.0" },
                { "V0CHIS_VLADIFRA" , "6.5" },
                { "V0CHIS_VLCOMISS" , "19.5" },
                { "V0CHIS_VLPRMTOT" , "143.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-01" },
                { "V0CHIS_SIT_FINC" , "settled" },
                { "V0CHIS_SIT_LIBR" , "released" },
                { "V0CHIS_NUM_OCOR" , "occurrence002" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "history002" },
                { "V1CHIS_CONGENER" , "general" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "12" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "general" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "12" },
                { "V1CHIS_OCORHIST" , "history001" },
                { "V1CHIS_OPERACAO" , "operation001" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q20);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_AC" , "2023-12-02" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q21);

                #endregion

                #region R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLRPREMIO" , "500.0" },
                { "WHOST_VLRDESCON" , "50.0" },
                { "WHOST_VLRADIFRA" , "25.0" },
                { "WHOST_VLR_COMIS" , "75.0" },
                { "WHOST_VLR_SINIS" , "400.0" },
                { "WHOST_VLDESPESA" , "100.0" },
                { "WHOST_VLR_HONOR" , "200.0" },
                { "WHOST_VLR_SALVD" , "150.0" },
                { "WHOST_VLRESSARC" , "350.0" },
                { "WHOST_VALOR_EDI" , "1000.0" },
                { "WHOST_VALOR_USS" , "800.0" },
                { "WHOST_VLEQPVNDA" , "1200.0" },
                { "WHOST_VLDESPADM" , "300.0" },
                { "WHOST_OUTRDEBIT" , "400.0" },
                { "WHOST_OUTRCREDT" , "500.0" },
                { "WHOST_VLRSLDANT" , "600.0" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1", q22);

                #endregion

                #region R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COD_EMPR" , "company004" },
                { "V0CCHQ_CONGENER" , "general" },
                { "V0CCHQ_DTMOVTO_AC" , "2023-12-01" },
                { "V0CCHQ_CODUSU_AC" , "user124" },
                { "V0CCHQ_DTLIBERA" , "2023-11-30" },
                { "V0CCHQ_VLPREMIO" , "550.0" },
                { "V0CCHQ_VLRDESCON" , "55.0" },
                { "V0CCHQ_VLRADIFRA" , "27.5" },
                { "V0CCHQ_VLRCOMIS" , "82.5" },
                { "V0CCHQ_OUTRDEBIT" , "450.0" },
                { "V0CCHQ_VLRSLDANT" , "650.0" },
                { "V0CCHQ_COD_MOEDA" , "EUR" },
                { "V0CCHQ_DTMOVTO_FI" , "2023-12-01" },
                { "V0CCHQ_CODUSU_FI" , "user125" },
                { "V0CCHQ_DTCORRECAO" , "2023-12-01" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1", q23);

                #endregion
                #endregion
                #endregion


                var program = new AC0812B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);

            }
        }






    }

        
}