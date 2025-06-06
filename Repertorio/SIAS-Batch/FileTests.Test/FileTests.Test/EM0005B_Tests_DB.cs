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
using static Code.EM0005B;

namespace FileTests.Test_DB
{
    [Collection("EM0005B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0005B_Tests_DB
    {

        [Fact]
        public static void EM0005B_Database()
        {
            var program = new EM0005B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try
            {
                /*1*/
                program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*2*/
                program.R0900_00_DECLARE_V1PROPOSTA_DB_DECLARE_1();
                program.R0900_00_DECLARE_V1PROPOSTA_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*3*/
                program.R2100_00_DECLARE_V1PROPCORRET_DB_DECLARE_1();
                program.R2100_00_DECLARE_V1PROPCORRET_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*4*/
                program.R1200_00_SELECT_V1FONTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*5*/
                program.V1PROP_DTINIVIG.Value = "2021-01-01";

                program.R1300_00_SELECT_V1RAMOIND_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*6*/
                program.R1400_00_SELECT_NUMERO_AES_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*7*/
                program.R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*8*/
                program.R2200_00_DECLARE_V1PROPCOSCED_DB_DECLARE_1();
                program.R2200_00_DECLARE_V1PROPCOSCED_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*9*/
                program.R2400_00_DECLARE_V1COBERPROP_DB_DECLARE_1();
                program.R2400_00_DECLARE_V1COBERPROP_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*10*/
                program.R2250_00_SELECT_V1COBERPROP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*11*/
                program.R2300_00_SELECT_V1COBERPROP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*12*/
                program.R2500_00_DECLARE_V1COSSEGSORT_DB_DECLARE_1(); 
                program.R2500_00_DECLARE_V1COSSEGSORT_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*13*/
                program.R3220_00_DECLARE_V1ACOMPROP_DB_DECLARE_1(); 
                program.R3220_00_DECLARE_V1ACOMPROP_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*14*/
                program.V0APOL_DATA_SORT.Value = "2021-01-01";

                program.R3100_00_INSERT_V0APOLICE_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*15*/
                program.V0ENDO_DATPRO.Value = "2021-01-01";
                program.V0ENDO_DT_LIBER.Value = "2021-01-01";
                program.V0ENDO_DTEMIS.Value = "2021-01-01";
                program.V0ENDO_DTINIVIG.Value = "2021-01-01";
                program.V0ENDO_DTTERVIG.Value = "2021-01-01";
                program.V0ENDO_DTVENCTO.Value = "2021-01-01";
                program.V0ENDO_DATARCAP.Value = "2021-01-01";

                program.R3200_10_INSERT_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*16*/
                program.R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*17*/
                program.R3212_00_RECUPERA_RCAP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*18*/
                program.R3215_00_RECUPERA_AU085_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*19*/
                program.V0ACOR_DTINIVIG.Value = "2021-01-01";
                program.V0ACOR_DTTERVIG.Value = "2021-01-01";

                program.R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*20*/
                program.V0ACCD_DTINIVIG.Value = "2021-01-01";
                program.V0ACCD_DTTERVIG.Value = "2021-01-01";

                program.R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*21*/
                program.V0COBA_DATA_INIVI.Value = "2021-01-01";
                program.V0COBA_DATA_TERVI.Value = "2021-01-01";

                program.R3530_00_INSERE_V0COBERAPOL_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*22*/
                program.V0APRO_DATOPR.Value = "2021-01-01";
                program.V0APRO_HORAOPER.Value = "04:00:00";

                program.R3600_00_INSERT_V0ACOMPROP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*23*/
                program.R3620_00_SELECT_V1CONTPROP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*24*/
                program.V0EDIA_DTMOVTO.Value = "2025-01-01";

                program.R3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*25*/
                program.R4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*26*/
                program.R4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*27*/
                program.R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*28*/
                program.R4310_00_UPDATE_V0APOLICE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*29*/
                program.R4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*30*/
                program.R4450_00_LER_LTMVPROP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*31*/
                program.R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*32*/
                program.R4550_00_UPDATE_LTMVPROP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*33*/
                program.R5600_00_INSERT_V0MALHAPROD_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*34*/
                program.R6000_00_TRATA_APOLCORRET_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}