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
using static Code.BI0075B;

namespace FileTests.Test_DB
{
    [Collection("BI0075B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0075B_Tests_DB
    {

        [Fact]
        public static void BI0075B_Database()
        {
            var program = new BI0075B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0120_00_MONTA_EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1(); program.R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0900_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1(); program.R0900_00_DECLARE_V0MOVDEBCC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1050_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*6*/
                program.V0BILH_NUMAPOL.Value = 108209802928;
                program.R1160_00_SELECT_V1BILHETE_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1170_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1440_00_CANCELA_BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2110_00_SELECT_AVISOCRE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*12*/
                program.V0AVIS_DTMOVTO.Value = "2024-12-13";
                program.V0AVIS_DTAVISO.Value = "2024-12-13";
                program.R2200_00_INSERT_V0AVISOCRED_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*13*/
                program.V0AVSD_DTAVISO.Value = "2024-12-13";
                program.V0AVSD_DTMOVTO.Value = "2024-12-13";
                program.R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*16*/
                program.V0MCOB_DTMOVTO.Value = "2024-12-13";
                program.V0MCOB_DTQITBCO.Value = "2024-12-13";
                program.R3500_00_INSERT_V0MOVICOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*17*/
                program.V0COMI_DATCLO.Value = "2024-12-13";
                program.V0COMI_DTMOVTO.Value = "2024-12-13";
                program.V0COMI_DTQITBCO.Value = "2024-12-13";
                program.V0COMI_DATSEL.Value = "2024-12-13";
                program.V0COMI_DTQITBCO.Value = "2024-12-13";
                program.R4050_00_TRATA_COMISSAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R4150_00_SELECT_BILCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R4300_00_INSERT_COMFEDCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R4350_00_INSERT_RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R5000_00_SELECT_EMP_CAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*22*/
                program.V0DPCF_DTMOVTO.Value = "2024-12-13";
                program.V0DPCF_DTAVISO.Value = "2024-12-13";
                program.R8700_00_INSERT_DESPESAS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}