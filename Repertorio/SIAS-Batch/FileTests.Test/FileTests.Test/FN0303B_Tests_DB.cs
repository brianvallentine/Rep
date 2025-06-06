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
using static Code.FN0303B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    [Collection("FN0303B_Tests_DB")]
    public class FN0303B_Tests_DB
    {

        [Fact]
        public static void FN0303B_Database()
        {
            var program = new FN0303B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.SIST_DTMOVABE_T1.Value = "2025-10-10 00:00:00";
                program.M_0000_PRINCIPAL_DB_DECLARE_1(); program.M_0000_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.NRAPOLICE_CODSUBES.NRAPOLICE.Value = 123;
                program.NRAPOLICE_CODSUBES.CODSUBES.Value = 1;
                program.M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.NRCERTIF.Value = 1;
                program.NRPARCEL.Value = 2;
                program.OCORHIST.Value = 3;
                program.M_1010_SELECT_HISTCONTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.NRCERTIF.Value = 1;
                program.NRPARCEL.Value = 0;
                program.M_1020_SELECT_HISTCONTABIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.NRAPOLICE_CODSUBES.NRAPOLICE.Value = 1;
                program.NRCERTIF.Value = 2;
                program.NRPARCEL.Value  = 3 ;
                program.M_1020_SELECT_HISTCONTABIL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}