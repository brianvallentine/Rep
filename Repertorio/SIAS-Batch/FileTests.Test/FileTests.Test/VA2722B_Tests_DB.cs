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
using static Code.VA2722B;

namespace FileTests.Test_DB
{
    [Collection("VA2722B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA2722B_Tests_DB
    {

        [Fact]
        
        public static void VA2722B_Database()
        {
            var program = new VA2722B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { 
                /*1*/
                program.R0010_00_OPEN_CURSOR_DB_OPEN_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*2*/
                program.R0012_00_VER_PRODUVG_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*3*/
                program.RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.Value = 1;
                program.R0013_00_UPDATE_RELAT_DB_UPDATE_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*4*/
                program.R0015_00_UPDATE_COD_RELAT_DB_UPDATE_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*5*/
                program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*6*/ program.R1000_00_PROCESSA_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { 
                /*7*/
                program.R1300_00_SELECT_PROPOFID_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*8*/ program.R1400_00_SELECT_ENDOSSOS_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*9*/ program.R1500_00_SELECT_HISCOBPR_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*10*/ program.R1510_00_SELECT_HISCOBPR_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*11*/
                program.R1700_00_SELECT_RAMOCOMP_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}