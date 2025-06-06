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
using static Code.VA2721B;

namespace FileTests.Test_DB
{
    [Collection("VA2721B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA2721B_Tests_DB
    {

        [Fact]
        public static void VA2721B_Database()
        {
            var program = new VA2721B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try
            {
                /*1*/
                program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*2*/
                program.R0100_00_SELECT_SISTEMAS_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*3*/
                program.R0900_00_DECLARE_PROPOVA_DB_DECLARE_1();
                program.R0900_00_DECLARE_PROPOVA_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*4*/
                program.R1400_00_SELECT_PROPOFID_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*5*/
                program.R1500_00_SELECT_HISCOBPR_DB_SELECT_1();
            }
            catch (Exception ex)
            {
                _.ThreatableTestError(ex);
            }
            try
            {
                /*6*/
                program.R1600_00_SELECT_PARCEVID_DB_SELECT_1();
            }
            catch (Exception ex)
            {
                _.ThreatableTestError(ex);
            }
            try
            {
                /*7*/
                program.R8000_00_UPDATE_RELATORI_DB_UPDATE_1();
            }
            catch (Exception ex)
            {
                _.ThreatableTestError(ex);
            }

        }
    }
}