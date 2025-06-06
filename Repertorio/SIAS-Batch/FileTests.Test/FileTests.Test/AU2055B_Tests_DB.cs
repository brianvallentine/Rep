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
using static Code.AU2055B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("AU2055B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AU2055B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void AU2055B_Database()
        {
            var program = new AU2055B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R2100_00_DECLARE_PROPOSTA_DB_DECLARE_1(); program.R2100_00_DECLARE_PROPOSTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R3100_00_DECLARE_MOVIMCOB_DB_DECLARE_1(); program.R3100_00_DECLARE_MOVIMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R2210_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R2220_00_SELECT_PROPOAUT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R3210_00_SELECT_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R3215_00_SELECT_AU085_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R3241_00_SELECT_PROPOAUT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R5030_00_SELECT_AU055_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R5040_00_INSERT_AU055_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO.Value = pData;
                program.AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_MOVTO_ARQUIVO.Value = pData;
                program.R5040_00_INSERT_AU055_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R5045_00_UPDATE_AU055_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R5050_00_UPDATE_AU057_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}