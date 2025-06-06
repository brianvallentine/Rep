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
using static Code.AC0815B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    [Collection("AC0815B_Tests")]
    public class AC0815B_Tests
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

            #region AC0815B_V1RELATORIOS

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
            AppSettings.TestSet.DynamicData.Add("AC0815B_V1RELATORIOS", q1);

            #endregion

            #region AC0815B_V0COSCEDCHEQUE

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , ""},
                { "V1CCHQ_DTLIBERA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0815B_V0COSCEDCHEQUE", q2);

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

            #region AC0815B_V1COSGHISTP

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
            AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSGHISTP", q8);

            #endregion

            #region AC0815B_V1COSSEGHIS

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
            AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSSEGHIS", q9);

            #endregion

            #region R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , ""},
                { "V0ENDO_TIPO_ENDO" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_CDFRACIO" , ""},
                { "V0ENDO_QTPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , ""},
                { "V1RELA_DATA_SOL" , ""},
                { "V1RELA_IDSISTEM" , ""},
                { "V1RELA_CODRELAT" , ""},
                { "V1RELA_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q12);

            #endregion

            #region R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_SIT_CONG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_EM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1APCC_PCCOMCOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1", q16);

            #endregion

            #region R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , ""},
                { "V1CPRE_PRMTAR_IX" , ""},
                { "V1CPRE_VLDESC_IX" , ""},
                { "V1CPRE_OTNPRLIQ" , ""},
                { "V1CPRE_OTNADFRA" , ""},
                { "V1CPRE_VLCOMS_IX" , ""},
                { "V1CPRE_OTNTOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q17);

            #endregion

            #region R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , ""},
                { "V1CHIS_VAL_DESC" , ""},
                { "V1CHIS_VLPRMLIQ" , ""},
                { "V1CHIS_VLADIFRA" , ""},
                { "V1CHIS_VLCOMISS" , ""},
                { "V1CHIS_VLPRMTOT" , ""},
                { "V1CHIS_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q18);

            #endregion

            #region R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q19);

            #endregion

            #region R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , ""},
                { "V0CHIS_CONGENER" , ""},
                { "V0CHIS_NUM_APOL" , ""},
                { "V0CHIS_NUM_ENDS" , ""},
                { "V0CHIS_NRPARCEL" , ""},
                { "V0CHIS_OCORHIST" , ""},
                { "V0CHIS_OPERACAO" , ""},
                { "V0CHIS_DAT_MOVT" , ""},
                { "V0CHIS_TIP_SEGU" , ""},
                { "V0CHIS_VLCOMISS" , ""},
                { "V0CHIS_VLPRMTOT" , ""},
                { "V0CHIS_DTQITBCO" , ""},
                { "V0CHIS_SIT_FINC" , ""},
                { "V0CHIS_SIT_LIBR" , ""},
                { "V0CHIS_NUM_OCOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , ""},
                { "V1CHIS_CONGENER" , ""},
                { "V1CHIS_NUM_APOL" , ""},
                { "V1CHIS_NUM_ENDS" , ""},
                { "V1CHIS_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q21);

            #endregion

            #region R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , ""},
                { "V1CHIS_NUM_APOL" , ""},
                { "V1CHIS_NUM_ENDS" , ""},
                { "V1CHIS_NRPARCEL" , ""},
                { "V1CHIS_OCORHIST" , ""},
                { "V1CHIS_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COMISSAO" , ""},
                { "V0CCHQ_OUTRDEBIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q23);

            #endregion

            #region R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_OUTRDEBIT" , ""},
                { "V0CCHQ_COMISSAO" , ""},
                { "V1RELA_COD_EMPR" , ""},
                { "V1RELA_CONGENER" , ""},
                { "V1RELA_DATA_SOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q24);

            #endregion

            #region R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , ""},
                { "V1RELA_DATA_SOL" , ""},
                { "V1RELA_IDSISTEM" , ""},
                { "V1RELA_CODRELAT" , ""},
                { "V1RELA_CONGENER" , ""},
                { "V1RELA_COD_EMPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q25);

            #endregion

            #endregion
        }

        [Fact]
        public void AC0815B_Test_Cenario_1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

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
                { "V1RELA_CORRECAO" , "none" },
                { "V1RELA_COD_EMPR" , "company001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1RELATORIOS", q1);

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "N" },
                { "V1CCHQ_DTLIBERA" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V0COSCEDCHEQUE");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V0COSCEDCHEQUE", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "105.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-02" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1COSGHISTP");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSGHISTP", q8);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                { "V1CHIS_TIP_SEGU" , "type001" },
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "105.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-02" },
                { "V1CHIS_NUM_OCOR" , "occurrence001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1COSSEGHIS");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSSEGHIS", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "type002" },
                { "V0ENDO_CORRECAO" , "none" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_CDFRACIO" , "fraction001" },
                { "V0ENDO_QTPARCEL" , "2" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q10);

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1.0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q11);

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_COD_EMPR" , "company001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q12);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q13);

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_SIT_CONG" , "N" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1", q14);

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_EM" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1", q15);

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1APCC_PCCOMCOS" , "0.5" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1", q16);

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "event002" },
                { "V1CPRE_PRMTAR_IX" , "100.0" },
                { "V1CPRE_VLDESC_IX" , "10.0" },
                { "V1CPRE_OTNPRLIQ" , "90.0" },
                { "V1CPRE_OTNADFRA" , "5.0" },
                { "V1CPRE_VLCOMS_IX" , "15.0" },
                { "V1CPRE_OTNTOTAL" , "105.0" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q17);

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "10.0" },
                { "V1CHIS_VLPRMLIQ" , "90.0" },
                { "V1CHIS_VLADIFRA" , "5.0" },
                { "V1CHIS_VLCOMISS" , "15.0" },
                { "V1CHIS_VLPRMTOT" , "105.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-02" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q18);

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "1000.0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q19);

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "N" },
                { "V0CHIS_NUM_APOL" , "policy124" },
                { "V0CHIS_NUM_ENDS" , "endorsement124" },
                { "V0CHIS_NRPARCEL" , "1" },
                { "V0CHIS_OCORHIST" , "event003" },
                { "V0CHIS_OPERACAO" , "operation002" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "type003" },
                { "V0CHIS_VLCOMISS" , "20.0" },
                { "V0CHIS_VLPRMTOT" , "120.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-03" },
                { "V0CHIS_SIT_FINC" , "N" },
                { "V0CHIS_SIT_LIBR" , "N" },
                { "V0CHIS_NUM_OCOR" , "occurrence002" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q20);

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "event002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "1" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q21);

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy123" },
                { "V1CHIS_NUM_ENDS" , "endorsement123" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event001" },
                { "V1CHIS_OPERACAO" , "operation001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q22);

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COMISSAO" , "25.0" },
                { "V0CCHQ_OUTRDEBIT" , "5.0" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q23);

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_OUTRDEBIT" , "5.0" },
                { "V0CCHQ_COMISSAO" , "25.0" },
                { "V1RELA_COD_EMPR" , "company001" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q24);

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_COD_EMPR" , "company001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q25);

                var program = new AC0815B();
                program.Execute();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);
            }
        }
        
        [Fact]
        public void AC0815B_Test_Cenario_2()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

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
                { "V1RELA_CORRECAO" , "none" },
                { "V1RELA_COD_EMPR" , "company001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1RELATORIOS", q1);

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "N" },
                { "V1CCHQ_DTLIBERA" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V0COSCEDCHEQUE");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V0COSCEDCHEQUE", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event002" },
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
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1COSGHISTP");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSGHISTP", q8);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event002" },
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
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1COSSEGHIS");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSSEGHIS", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "typeE002" },
                { "V0ENDO_CORRECAO" , "none" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_CDFRACIO" , "fraction002" },
                { "V0ENDO_QTPARCEL" , "1" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q10);

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1.0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q11);

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_COD_EMPR" , "company001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q12);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q13);

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_SIT_CONG" , "N" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1", q14);

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_EM" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1", q15);

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1APCC_PCCOMCOS" , "0.0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1", q16);

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "event003" },
                { "V1CPRE_PRMTAR_IX" , "100.0" },
                { "V1CPRE_VLDESC_IX" , "5.0" },
                { "V1CPRE_OTNPRLIQ" , "95.0" },
                { "V1CPRE_OTNADFRA" , "0.0" },
                { "V1CPRE_VLCOMS_IX" , "10.0" },
                { "V1CPRE_OTNTOTAL" , "105.0" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q17);

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "5.0" },
                { "V1CHIS_VLPRMLIQ" , "95.0" },
                { "V1CHIS_VLADIFRA" , "0.0" },
                { "V1CHIS_VLCOMISS" , "10.0" },
                { "V1CHIS_VLPRMTOT" , "105.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q18);

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "1000.0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q19);

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "N" },
                { "V0CHIS_NUM_APOL" , "policy003" },
                { "V0CHIS_NUM_ENDS" , "endorse003" },
                { "V0CHIS_NRPARCEL" , "1" },
                { "V0CHIS_OCORHIST" , "event004" },
                { "V0CHIS_OPERACAO" , "operation003" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "type003" },
                { "V0CHIS_VLCOMISS" , "10.0" },
                { "V0CHIS_VLPRMTOT" , "105.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-01" },
                { "V0CHIS_SIT_FINC" , "N" },
                { "V0CHIS_SIT_LIBR" , "N" },
                { "V0CHIS_NUM_OCOR" , "occurrence003" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q20);

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "event003" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q21);

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event002" },
                { "V1CHIS_OPERACAO" , "operation002" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q22);

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COMISSAO" , "10.0" },
                { "V0CCHQ_OUTRDEBIT" , "0.0" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q23);

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_OUTRDEBIT" , "0.0" },
                { "V0CCHQ_COMISSAO" , "10.0" },
                { "V1RELA_COD_EMPR" , "company001" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q24);

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_COD_EMPR" , "company001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q25);

                var program = new AC0815B();
                program.Execute();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);
            }
        }
        
        [Fact]
        public void AC0815B_Test_Cenario_3()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "SYS001" },
                { "V1RELA_CODRELAT" , "RPT100" },
                { "V1RELA_PERI_INI" , "2023-11-01" },
                { "V1RELA_PERI_FIN" , "2023-11-30" },
                { "V1RELA_DATA_REF" , "2023-11-15" },
                { "V1RELA_CONGENER" , "Yes" },
                { "V1RELA_CODUNIMO" , "UNI123" },
                { "V1RELA_CORRECAO" , "No" },
                { "V1RELA_COD_EMPR" , "EMP456" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1RELATORIOS", q1);

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "Yes" },
                { "V1CCHQ_DTLIBERA" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V0COSCEDCHEQUE");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V0COSCEDCHEQUE", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "10" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "5" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "EMP789" },
                { "V1CHIS_CONGENER" , "Yes" },
                { "V1CHIS_NUM_APOL" , "APL321" },
                { "V1CHIS_NUM_ENDS" , "END654" },
                { "V1CHIS_NRPARCEL" , "3" },
                { "V1CHIS_OCORHIST" , "OC123" },
                { "V1CHIS_OPERACAO" , "OP456" },
                { "V1CHIS_TIP_SEGU" , "TypeA" },
                { "V1CHIS_PRM_TARF" , "1500.0" },
                { "V1CHIS_VAL_DESC" , "100.0" },
                { "V1CHIS_VLPRMLIQ" , "1400.0" },
                { "V1CHIS_VLADIFRA" , "50.0" },
                { "V1CHIS_VLCOMISS" , "200.0" },
                { "V1CHIS_VLPRMTOT" , "1600.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-02" },
                { "V1CHIS_NUM_OCOR" , "NOC789" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1COSGHISTP");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSGHISTP", q8);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "EMP789" },
                { "V1CHIS_CONGENER" , "Yes" },
                { "V1CHIS_NUM_APOL" , "APL321" },
                { "V1CHIS_NUM_ENDS" , "END654" },
                { "V1CHIS_NRPARCEL" , "3" },
                { "V1CHIS_OCORHIST" , "OC123" },
                { "V1CHIS_OPERACAO" , "OP456" },
                { "V1CHIS_TIP_SEGU" , "TypeA" },
                { "V1CHIS_PRM_TARF" , "1500.0" },
                { "V1CHIS_VAL_DESC" , "100.0" },
                { "V1CHIS_VLPRMLIQ" , "1400.0" },
                { "V1CHIS_VLADIFRA" , "50.0" },
                { "V1CHIS_VLCOMISS" , "200.0" },
                { "V1CHIS_VLPRMTOT" , "1600.0" },
                { "V1CHIS_DAT_MOVT" , "2023-12-01" },
                { "V1CHIS_DTQITBCO" , "2023-12-02" },
                { "V1CHIS_NUM_OCOR" , "NOC789" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1COSSEGHIS");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSSEGHIS", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "TypeB" },
                { "V0ENDO_CORRECAO" , "No" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_CDFRACIO" , "FR123" },
                { "V0ENDO_QTPARCEL" , "4" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q10);

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1.1" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q11);

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "SYS001" },
                { "V1RELA_CODRELAT" , "RPT100" },
                { "V1RELA_COD_EMPR" , "EMP456" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q12);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q13);

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_SIT_CONG" , "Active" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1", q14);

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_EM" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1", q15);

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1APCC_PCCOMCOS" , "Cost100" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1", q16);

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "Hist200" },
                { "V1CPRE_PRMTAR_IX" , "1200.0" },
                { "V1CPRE_VLDESC_IX" , "80.0" },
                { "V1CPRE_OTNPRLIQ" , "1120.0" },
                { "V1CPRE_OTNADFRA" , "30.0" },
                { "V1CPRE_VLCOMS_IX" , "150.0" },
                { "V1CPRE_OTNTOTAL" , "1300.0" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "1500.0" },
                { "V1CHIS_VAL_DESC" , "100.0" },
                { "V1CHIS_VLPRMLIQ" , "1400.0" },
                { "V1CHIS_VLADIFRA" , "50.0" },
                { "V1CHIS_VLCOMISS" , "200.0" },
                { "V1CHIS_VLPRMTOT" , "1600.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-02" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q18);

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "5000.0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q19);

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "EMP123" },
                { "V0CHIS_CONGENER" , "Yes" },
                { "V0CHIS_NUM_APOL" , "APL456" },
                { "V0CHIS_NUM_ENDS" , "END789" },
                { "V0CHIS_NRPARCEL" , "2" },
                { "V0CHIS_OCORHIST" , "OC456" },
                { "V0CHIS_OPERACAO" , "OP789" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "TypeC" },
                { "V0CHIS_VLCOMISS" , "300.0" },
                { "V0CHIS_VLPRMTOT" , "1800.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-03" },
                { "V0CHIS_SIT_FINC" , "Pending" },
                { "V0CHIS_SIT_LIBR" , "Released" },
                { "V0CHIS_NUM_OCOR" , "NOC012" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q20);

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "Hist200" },
                { "V1CHIS_CONGENER" , "Yes" },
                { "V1CHIS_NUM_APOL" , "APL321" },
                { "V1CHIS_NUM_ENDS" , "END654" },
                { "V1CHIS_NRPARCEL" , "3" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q21);

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "Yes" },
                { "V1CHIS_NUM_APOL" , "APL321" },
                { "V1CHIS_NUM_ENDS" , "END654" },
                { "V1CHIS_NRPARCEL" , "3" },
                { "V1CHIS_OCORHIST" , "OC123" },
                { "V1CHIS_OPERACAO" , "OP456" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q22);

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COMISSAO" , "250.0" },
                { "V0CCHQ_OUTRDEBIT" , "50.0" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q23);

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_OUTRDEBIT" , "50.0" },
                { "V0CCHQ_COMISSAO" , "250.0" },
                { "V1RELA_COD_EMPR" , "EMP456" },
                { "V1RELA_CONGENER" , "Yes" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q24);

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "SYS001" },
                { "V1RELA_CODRELAT" , "RPT100" },
                { "V1RELA_CONGENER" , "Yes" },
                { "V1RELA_COD_EMPR" , "EMP456" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q25);

                var program = new AC0815B();
                program.Execute();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);
            }
        }
        
        [Fact]
        public void AC0815B_Test_Cenario_4()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

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
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1RELATORIOS", q1);

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_CONGENER" , "N" },
                { "V1CCHQ_DTLIBERA" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V0COSCEDCHEQUE");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V0COSCEDCHEQUE", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1", q5);

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_RELAT" , "2" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1", q6);

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_CONGN" , "0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1", q7);

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event002" },
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
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1COSGHISTP");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSGHISTP", q8);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_COD_EMPR" , "company002" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event002" },
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
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0815B_V1COSSEGHIS");
                AppSettings.TestSet.DynamicData.Add("AC0815B_V1COSSEGHIS", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_MOEDA_PRM" , "USD" },
                { "V0ENDO_TIPO_ENDO" , "typeE002" },
                { "V0ENDO_CORRECAO" , "N" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_CDFRACIO" , "fraction002" },
                { "V0ENDO_QTPARCEL" , "1" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q10);

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1.0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q11);

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_COD_EMPR" , "company001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q12);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1CCHQ_DTLIBERA" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1", q13);

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_SIT_CONG" , "N" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1", q14);

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_EM" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1", q15);

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1APCC_PCCOMCOS" , "0.1" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1", q16);

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "event003" },
                { "V1CPRE_PRMTAR_IX" , "100.0" },
                { "V1CPRE_VLDESC_IX" , "5.0" },
                { "V1CPRE_OTNPRLIQ" , "95.0" },
                { "V1CPRE_OTNADFRA" , "0.0" },
                { "V1CPRE_VLCOMS_IX" , "10.0" },
                { "V1CPRE_OTNTOTAL" , "105.0" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1", q17);

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_PRM_TARF" , "100.0" },
                { "V1CHIS_VAL_DESC" , "5.0" },
                { "V1CHIS_VLPRMLIQ" , "95.0" },
                { "V1CHIS_VLADIFRA" , "0.0" },
                { "V1CHIS_VLCOMISS" , "10.0" },
                { "V1CHIS_VLPRMTOT" , "105.0" },
                { "V1CHIS_DTQITBCO" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1", q18);

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VAL_VENDA" , "1000.0" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q19);

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_COD_EMPR" , "company003" },
                { "V0CHIS_CONGENER" , "N" },
                { "V0CHIS_NUM_APOL" , "policy003" },
                { "V0CHIS_NUM_ENDS" , "endorse003" },
                { "V0CHIS_NRPARCEL" , "1" },
                { "V0CHIS_OCORHIST" , "event004" },
                { "V0CHIS_OPERACAO" , "operation003" },
                { "V0CHIS_DAT_MOVT" , "2023-12-01" },
                { "V0CHIS_TIP_SEGU" , "type003" },
                { "V0CHIS_VLCOMISS" , "10.0" },
                { "V0CHIS_VLPRMTOT" , "105.0" },
                { "V0CHIS_DTQITBCO" , "2023-12-01" },
                { "V0CHIS_SIT_FINC" , "N" },
                { "V0CHIS_SIT_LIBR" , "N" },
                { "V0CHIS_NUM_OCOR" , "occurrence003" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1", q20);

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V1CPRE_OCORHIST" , "event003" },
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1", q21);

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1CHIS_CONGENER" , "N" },
                { "V1CHIS_NUM_APOL" , "policy002" },
                { "V1CHIS_NUM_ENDS" , "endorse002" },
                { "V1CHIS_NRPARCEL" , "1" },
                { "V1CHIS_OCORHIST" , "event002" },
                { "V1CHIS_OPERACAO" , "operation002" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1", q22);

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_COMISSAO" , "10.0" },
                { "V0CCHQ_OUTRDEBIT" , "0.0" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1", q23);

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V0CCHQ_OUTRDEBIT" , "0.0" },
                { "V0CCHQ_COMISSAO" , "10.0" },
                { "V1RELA_COD_EMPR" , "company001" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1", q24);

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_COD_USU" , "user123" },
                { "V1RELA_DATA_SOL" , "2023-12-01" },
                { "V1RELA_IDSISTEM" , "system01" },
                { "V1RELA_CODRELAT" , "report001" },
                { "V1RELA_CONGENER" , "N" },
                { "V1RELA_COD_EMPR" , "company001" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q25);

                var program = new AC0815B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);

            }
        }
        

    }
}