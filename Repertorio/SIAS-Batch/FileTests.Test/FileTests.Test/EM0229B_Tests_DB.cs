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
using static Code.EM0229B;

namespace FileTests.Test_DB
{
    [Collection("EM0229B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0229B_Tests_DB
    {
        private static string pData = "2020-01-01";

        [Fact]
        public static void EM0229B_Database()
        {
            var program = new EM0229B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_V1EMISDIARIA_DB_DECLARE_1(); program.R0900_00_DECLARE_V1EMISDIARIA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1500_00_DECLARE_V1PARCELA_DB_DECLARE_1(); program.R1500_00_DECLARE_V1PARCELA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.S2000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1(); program.S2000_00_DECLARE_V1RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2100_00_SELECT_V0TOMADOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.V0ESIC_DTVENCTO.Value = pData;
                program.V0ESIC_DTMOVTO.Value = pData;
                program.V0ESIC_DTDOCTO.Value = pData;
                program.R3000_00_INSERT_V0EMISICOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/
                program.V1EDIA_DTMOVTO.Value = pData;
                program.S3000_00_PROCESSA_REGISTRO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.V1SIST_DTMOVABE.Value = pData;
                program.S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}