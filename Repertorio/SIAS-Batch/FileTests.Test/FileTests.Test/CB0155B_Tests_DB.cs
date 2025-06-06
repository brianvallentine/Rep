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
using static Code.CB0155B;

namespace FileTests.Test_DB
{
    [Collection("CB0155B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB0155B_Tests_DB
    {

        [Fact]
        public static void CB0155B_Database()
        {
            var program = new CB0155B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try
            {
                /*1*/
                program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*2*/
                program.R0300_00_DECLARE_AVISOCRE_DB_DECLARE_1();
                program.R0300_00_DECLARE_AVISOCRE_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*3*/
                program.R0400_00_DECLARE_RCAP_DB_DECLARE_1();
                program.R0400_00_DECLARE_RCAP_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*4*/
                program.R0500_00_DECLARE_FOLLOW_DB_DECLARE_1();
                program.R0500_00_DECLARE_FOLLOW_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*5*/
                program.R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*6*/
                program.R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*7*/
                program.R0600_00_DECLARE_MOVICOB_DB_DECLARE_1();
                program.R0600_00_DECLARE_MOVICOB_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*8*/
                program.R3100_00_DECLARE_MOVICOB_DB_DECLARE_1();
                program.R3100_00_DECLARE_MOVICOB_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*9*/
                program.R1015_00_SELECT_V0ORIGEM_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*10*/
                program.R1610_00_SELECT_V0RCAPCOMP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*11*/
                program.R1620_00_SELECT_V0RCAPCOMP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*12*/
                program.R1630_00_SELECT_V0RCAPCOMP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*13*/
                program.R1640_00_SELECT_V0FOLLOWUP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*14*/
                program.R1800_00_SELECT_V0PARCEHIS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*15*/
                program.R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*16*/
                program.R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*17*/
                program.R1900_00_SELECT_V0RCAPCOMP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*18*/
                program.R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*19*/
                program.R1950_00_SELECT_V0RCAPCOMP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*20*/
                program.R1960_00_SELECT_V0RCAPCOMP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*21*/
                program.R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*22*/
                program.R2200_00_SELECT_V0CONDESCE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*23*/
                program.R3200_00_DECLARE_FOLLOW_DB_DECLARE_1();
                program.R3200_00_DECLARE_FOLLOW_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*24*/
                program.R3400_00_DECLARE_RCAP_DB_DECLARE_1();
                program.R3400_00_DECLARE_RCAP_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}