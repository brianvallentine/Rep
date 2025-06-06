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
using static Code.EM0911S;

namespace FileTests.Test_DB
{
    [Collection("EM0911S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0911S_Tests_DB
    {
        private static string pData = "2020-01-01";

        [Fact]
        public static void EM0911S_Database()
        {
            var program = new EM0911S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.WHOST_DTINIVIG.Value = pData;
                program.R1200_00_SELECT_V1MOEDA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/ program.R2100_00_DECLARE_V1OUTROSPROP_DB_DECLARE_1(); program.R2100_00_DECLARE_V1OUTROSPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R2300_00_DECLARE_OUTRCOBERPROP_DB_DECLARE_1(); program.R2300_00_DECLARE_OUTRCOBERPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R2400_00_DECLAR_V1OUTRBENSPROP_DB_DECLARE_1(); program.R2400_00_DECLAR_V1OUTRBENSPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.V0APOC_DTINIVIG.Value = pData;
                program.V0APOC_DTTERVIG.Value = pData;
                program.R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2500_00_DECLA_V1BENSCOBERPROP_DB_DECLARE_1(); program.R2500_00_DECLA_V1BENSCOBERPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.V0APOB_DTINIVIG.Value = pData;
                program.V0APOB_DTTERVIG.Value = pData;
                program.R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/ program.R2600_00_DECLA_V1PROPCLAU_DB_DECLARE_1(); program.R2600_00_DECLA_V1PROPCLAU_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R4200_00_DECLA_V1OUTRCOBERPROP_DB_DECLARE_1(); program.R4200_00_DECLA_V1OUTRCOBERPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.V0APCL_DTINIVIG.Value = pData;
                program.V0APCL_DTTERVIG.Value = pData;
                program.R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/ 
                program.V0EDIA_DTMOVTO.Value = pData;   
                program.R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/ program.R4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ 
                program.V0COBA_DATA_INIVI.Value = pData;
                program.V0COBA_DATA_TERVI.Value = pData;
                program.R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*17*/ program.R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}