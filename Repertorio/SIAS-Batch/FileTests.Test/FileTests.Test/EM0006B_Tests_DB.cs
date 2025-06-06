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
using static Code.EM0006B;

namespace FileTests.Test_DB
{
    [Collection("EM0006B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0006B_Tests_DB
    {

        [Fact]
        public static void EM0006B_Database()
        {
            var program = new EM0006B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_DECLARE_V1PROPOSTA_DB_DECLARE_1(); program.R0200_00_DECLARE_V1PROPOSTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1600_00_DECLARE_V1PROPCORRET_DB_DECLARE_1(); program.R1600_00_DECLARE_V1PROPCORRET_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1100_00_SELECT_V1FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*5*/
                program.V1PROP_DTINIVIG.Value = "2025-01-27";
                program.R1200_00_SELECT_V1RAMOIND_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1800_00_DECLARE_V1PROPCOSCED_DB_DECLARE_1(); program.R1800_00_DECLARE_V1PROPCOSCED_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*7*/
                program.V0ACOR_DTINIVIG.Value = "2025-01-27";
                program.V0ACOR_DTTERVIG.Value = "2025-01-27";
                program.R1700_00_INSERT_V0APOLCORRET_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2050_00_DECLARE_V1PROPLOCINC_DB_DECLARE_1(); program.R2050_00_DECLARE_V1PROPLOCINC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*9*/
                program.V0ACOS_DTINIVIG.Value = "2025-01-27";
                program.V0ACOS_DTTERVIG.Value = "2025-01-27";
                program.R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R2100_00_DECLARE_V1PROPINC_DB_DECLARE_1(); program.R2100_00_DECLARE_V1PROPINC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*11*/
                program.V0APLI_DTINIVIG.Value = "2025-01-27";
                program.V0APLI_DTTERVIG.Value = "2025-01-27";
                program.R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2200_00_DECLARE_V1PROPCLAUS_DB_DECLARE_1(); program.R2200_00_DECLARE_V1PROPCLAUS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*15*/
                program.V0APIN_DTINIVIG.Value = "2025-01-27";
                program.V0APIN_DTTERVIG.Value = "2025-01-27";
                program.R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R2500_00_DECLARE_V1COSSEGSORT_DB_DECLARE_1(); program.R2500_00_DECLARE_V1COSSEGSORT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*19*/
                program.V0APCL_DTINIVIG.Value = "2025-01-27";
                program.V0APCL_DTTERVIG.Value = "2025-01-27";
                program.R2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R2600_00_DECLARE_V1PROPDESINC_DB_DECLARE_1(); program.R2600_00_DECLARE_V1PROPDESINC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2800_00_DECLARE_V1PROPDESCO_DB_DECLARE_1(); program.R2800_00_DECLARE_V1PROPDESCO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*22*/
                program.V0APDI_DTINIVIG.Value = "2025-01-27";
                program.V0APDI_DTTERVIG.Value = "2025-01-27";
                program.R2700_00_INSERT_V0APODESITEM_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2860_00_DECLARE_V1PROPOUTR_DB_DECLARE_1(); program.R2860_00_DECLARE_V1PROPOUTR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*24*/
                program.V0APID_DTINIVIG.Value = "2025-01-27";
                program.V0APID_DTTERVIG.Value = "2025-01-27";
                program.R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2900_00_DECLARE_V1PROPDCOB_DB_DECLARE_1(); program.R2900_00_DECLARE_V1PROPDCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*26*/
                program.V0APOU_DTINIVIG.Value = "2025-01-27";
                program.V0APOU_DTTERVIG.Value = "2025-01-27";
                program.R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R3600_00_DECLARE_V1COBPROPINC_DB_DECLARE_1(); program.R3600_00_DECLARE_V1COBPROPINC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*28*/
                program.V0APDC_DTINIVIG.Value = "2025-01-27";
                program.V0APDC_DTTERVIG.Value = "2025-01-27";
                program.R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*29*/ 
                
                program.R3100_00_INSERT_V0APOLICE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*30*/
                program.V0ENDO_DATPRO.Value = "2025-01-27";
                program.V0ENDO_DT_LIBER.Value = "2025-01-27";
                program.V0ENDO_DTEMIS.Value = "2025-01-27";
                program.V0ENDO_DTINIVIG.Value = "2025-01-26";
                program.V0ENDO_DTTERVIG.Value = "2025-01-27";
                program.V0ENDO_DATARCAP.Value = "2025-01-27";
                program.V0ENDO_DTVENCTO.Value = "2025-01-27";
                program.R3200_00_INSERT_V0ENDOSSO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R3910_00_SELECT_V1PRAZOCURTO_DB_DECLARE_1(); program.R3910_00_SELECT_V1PRAZOCURTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*32*/
                program.V0COBI_DTINIVIG.Value = "2025-01-27";
                program.V0COBI_DTTERVIG.Value = "2025-01-27";
                program.R3800_00_MONTA_V0COBERINC_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R3850_00_UPDATE_V0COBERINC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R3920_00_SELECT_V1PRAZOLONGO_DB_DECLARE_1(); program.R3920_00_SELECT_V1PRAZOLONGO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R4800_00_ACESSA_V1ACOMPROP_DB_DECLARE_1(); program.R4800_00_ACESSA_V1ACOMPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*37*/
                program.V0COBA_DTINIVIG.Value = "2025-01-27";
                program.V0COBA_DTTERVIG.Value = "2025-01-27";
                program.R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R4600_00_SELECT_NUMERO_AES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*42*/
                program.V0EDIA_DTMOVTO.Value = "2025-01-27";
                program.R5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R5100_00_INSERT_V0ACOMPROP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*45*/
                program.V0APRO_DATOPR.Value = "2025-01-27";
                program.V0APRO_HORAOPER.Value = "00:00:00";
                program.R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R5600_00_UPDATE_V0PROPINC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}