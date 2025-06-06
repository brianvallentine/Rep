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
using static Code.BI0072B;

namespace FileTests.Test_DB
{
    [Collection("BI0072B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0072B_Tests_DB
    {

        [Fact]
        public static void BI0072B_Database()
        {
            var program = new BI0072B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0120_00_MONTA_EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1(); program.R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1(); program.R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1471_00_DECLARE_V0PARC_DB_DECLARE_1(); program.R1471_00_DECLARE_V0PARC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1000_50_SAIDA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1050_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1060_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1160_00_SELECT_V1BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1440_00_CANCELA_BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1474_00_CANCELA_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1475_00_CANCELA_PARCHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1476_00_SELECT_NRENDOCA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1477_00_SELECT_APOLICES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*20*/
                program.V1MVDB_DTCREDITO.Value = "2024-12-19";
                program.V1MVDB_DTRETORNO.Value = "2024-12-19";
                program.V1MVDB_DTMOVTO.Value = "2024-12-19";
                program.R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R3462_00_UPDATE_BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*23*/ 
                program.V0FOLL_DTMOVTO.Value = "2024-12-19";
                program.V0FOLL_HORAOPER.Value = "00:00:00";
                program.V0FOLL_DTLIBER.Value = "2024-12-19";
                program.V0FOLL_DTQITBCO.Value = "2024-12-19";
                program.R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}