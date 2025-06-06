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
using static Code.SPBFC003;

namespace FileTests.Test_DB
{
    [Collection("SPBFC003_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SPBFC003_Tests_DB
    {

        [Fact]
        public static void SPBFC003_Database()
        {
            var program = new SPBFC003();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
                        program.InitializeGetQuery();

            try { /*1*/
                
                //erro de privilegio do usuario da base H
                
                program.P050_PROCESSA_FC_SEQUENCE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/

                //erro de privilegio do usuario da base H

                program.P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.P100_ACESSA_SEQUENCE_FC302SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.P100_ACESSA_SEQUENCE_FC103SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.P100_ACESSA_SEQUENCE_FC222SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.P100_ACESSA_SEQUENCE_FC035SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.P100_ACESSA_SEQUENCE_FC036SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.P100_ACESSA_SEQUENCE_FC105SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.P100_ACESSA_SEQUENCE_FC106SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.P100_ACESSA_SEQUENCE_FC092SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.P100_ACESSA_SEQUENCE_FC084SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.P100_ACESSA_SEQUENCE_FC216SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.P100_ACESSA_SEQUENCE_FC002SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.P100_ACESSA_SEQUENCE_FC074SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.P100_ACESSA_SEQUENCE_FC072SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.P100_ACESSA_SEQUENCE_FC037SQ_DB_SEQUENCE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}