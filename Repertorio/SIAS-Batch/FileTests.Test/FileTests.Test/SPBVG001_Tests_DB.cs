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
using static Code.SPBVG001;

namespace FileTests.Test_DB
{
    [Collection("SPBVG001_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SPBVG001_Tests_DB
    {
        private static string pData = "2024-12-11";

        [Fact]
        public static void SPBVG001_Database()
        {
            var program = new SPBVG001();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.P0050_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.P0110_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.P0111_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.P0112_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.P0120_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.P0121_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.P0130_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.P0131_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.P0132_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.P0308_05_INICIO_DB_DECLARE_1(); program.P0308_05_INICIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.P0351_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.Value = 10;
                program.P0801_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.P0802_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.P0803_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.P0804_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.P0805_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_OCORRENCIA.Value = pData;
                program.VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTA_RCAP.Value = pData;
                program.VG103.DCLVG_CRITICA_PROPOSTA.VG103_DTH_CADASTRAMENTO.Value = pData;
                program.P0820_05_INICIO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*18*/ program.P0821_05_INICIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.P0822_05_INICIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.P0850_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.P0851_01_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA.Value = pData;
                program.P1010_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.P1010_05_INICIO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}