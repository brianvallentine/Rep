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
using static Code.EM0914S;

namespace FileTests.Test_DB
{
    [Collection("EM0914S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0914S_Tests_DB
    {
        private static string pData = "2020-01-01";

        [Fact]
        public static void EM0914S_Database()
        {
            var program = new EM0914S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R2100_00_DECLARE_MR_PROP_ITEM_DB_DECLARE_1(); program.R2100_00_DECLARE_MR_PROP_ITEM_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R2200_00_DECLARE_MR017_DB_DECLARE_1(); program.R2200_00_DECLARE_MR017_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_DTH_INI_VIG_ITEM.Value = pData;
                program.MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_DTH_FIM_VIG_ITEM.Value = pData;
                program.R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.R2300_00_DECLARE_MR_PROP_COBER_DB_DECLARE_1(); program.R2300_00_DECLARE_MR_PROP_COBER_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R2210_00_INSERT_MR022_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R2400_00_DECLARE_MR026_DB_DECLARE_1(); program.R2400_00_DECLARE_MR026_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_DTH_INI_VIG_COBER.Value = pData;
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_DTH_FIM_VIG_COBER.Value = pData;
                program.R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ 
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.Value = pData;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.Value = pData;
                program.R2340_00_INSERT_APOLICOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/ program.R2600_00_DECLARE_PROP_CLAUS_DB_DECLARE_1(); program.R2600_00_DECLARE_PROP_CLAUS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.MR027.DCLMR_APOL_SUB_COBER.MR027_DTH_INI_VIGENCIA.Value = pData;
                program.MR027.DCLMR_APOL_SUB_COBER.MR027_DTH_FIM_VIGENCIA.Value = pData;
                program.R2410_00_INSERT_MR027_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/
                program.APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_DATA_INIVIGENCIA.Value = pData;
                program.APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_DATA_TERVIGENCIA.Value = pData;
                program.R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}