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
using static Code.VA0458B;

namespace FileTests.Test_DB
{
    [Collection("VA0458B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0458B_Tests_DB
    {

        [Fact]
        public static void VA0458B_Database()
        {
            var program = new VA0458B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*2*/
                program.WHOST_DT_CALENDARIO.Value = "2024-12-10";
                program.R0300_00_SELECT_CALENDARIO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0310_00_SELECT_FERIADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0900_00_DECLARE_PROPOSTAS_VA_DB_DECLARE_1(); program.R0900_00_DECLARE_PROPOSTAS_VA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1015_00_SELECT_OPCAOPAG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1010_00_SELECT_CONVERSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1020_00_SELECT_V0RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1025_00_SELECT_V0RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1030_00_SELECT_VG078_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1100_00_SELECT_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1110_00_SELECT_RELATORI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2000_00_INSERT_RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2000_00_INSERT_RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2100_00_INSERT_ERRPROVI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*18*/
                program.WHOST_DTA_DECLINIO.Value = "2024-12-10";
                program.V1SIST_DTMOVABE.Value = "2024-12-10";
                program.R2200_00_UPDATE_PROPOVA_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R3110_00_CONSULTA_PENDENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R3170_00_UPDATE_PROPOVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}