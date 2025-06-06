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
using static Code.VA0127B;

namespace FileTests.Test_DB
{
    [Collection("VA0127B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0127B_Tests_DB
    {

        [Fact]
        public static void VA0127B_Database()
        {
            var program = new VA0127B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/

                program.V0RIND_DTMOVTO.Value = "2000-10-10";

                program.M_0000_PRINCIPAL_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                //TimeOut
                program.M_0000_PRINCIPAL_DB_DECLARE_1(); program.M_0000_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                //foreign key
                program.DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_DATA_VENCIMENTO.Value = "2000-10-10";

                program.M_0100_GERA_DIFERENCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/

                program.WS_WORK_AREAS.WS_DATA_FIM.Value = "2000-10-10";
                program.WS_WORK_AREAS.WS_DATA_INI.Value = "2000-10-10";

                program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/

                program.V0RIND_DTMOVTO_1DAY.Value = "2000-10-10";

                program.M_0000_PRINCIPAL_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/

                program.WS_WORK_AREAS.WS_DATA_INI.Value = "2000-10-10";

                program.M_0000_PRINCIPAL_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/

                program.V0PARC_DTVENCTO.Value = "2000-10-10";

                program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/

                program.WS_WORK_AREAS.WS_DATA_INI.Value = "2000-10-10";
                program.WS_WORK_AREAS.WS_DATA_FIM.Value = "2000-10-10";

                program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_10(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_11(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}