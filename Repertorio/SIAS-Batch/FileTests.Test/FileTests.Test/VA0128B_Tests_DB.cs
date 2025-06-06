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
using static Code.VA0128B;

namespace FileTests.Test_DB
{
    [Collection("VA0128B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0128B_Tests_DB
    {
        private static string pData = "2021-01-01";

        [Fact]
        public static void VA0128B_Database()
        {
            var program = new VA0128B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0000_PRINCIPAL_DB_DECLARE_1(); 
                program.M_0000_PRINCIPAL_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0410_00_DECLARE_VGHISTRAMCOB_DB_DECLARE_1(); program.M_0410_00_DECLARE_VGHISTRAMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V0RIND_DTMOVTO.Value = pData;
                program.M_0000_PRINCIPAL_DB_SELECT_3(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ 
                program.V0RIND_DTMOVTO_1DAY.Value = pData;
                program.M_0000_PRINCIPAL_DB_SELECT_4(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_0200_VERIFICA_COBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_10(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_0200_VERIFICA_COBER_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_0200_VERIFICA_COBER_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.DATA_MOVIMENTO.Value = pData;
                program.M_0300_CORRIGE_IOF_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*21*/ 
                program.SISTEMA_DTMOVABE.Value = pData;
                program.CLIENT_DTNASC.Value = pData;
                program.M_0300_PROPAUTOM_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*22*/ program.M_0300_PROPAUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_0300_CORRIGE_IOF_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_0300_CORRIGE_IOF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_0300_CORRIGE_IOF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_0300_CORRIGE_IOF_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.M_0500_00_DECLARE_VGHISTACESSCOB_DB_DECLARE_1(); program.M_0500_00_DECLARE_VGHISTACESSCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}