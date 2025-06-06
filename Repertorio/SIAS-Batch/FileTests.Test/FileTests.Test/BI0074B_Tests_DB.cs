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
using static Code.BI0074B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("BI0074B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0074B_Tests_DB
    {

        [Fact]
        public static void BI0074B_Database()
        {
            var program = new BI0074B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1(); program.R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0351_00_SELECT_PROPOFID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0360_00_SELECT_MOVCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0370_00_SELECT_AVISOCRED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0370_00_SELECT_AVISOCRED_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.WSHOST_NUM_NOSSO_TITULO.Value = 123;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2024-12-12";
                program.R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0370_00_SELECT_AVISOCRED_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0370_00_SELECT_AVISOCRED_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1200_00_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1250_00_UPDATE_FONTES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO.Value = "2024-12-12";
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO.Value = "00:00:00";
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO.Value = "2024-12-12";
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO.Value = "2024-12-12";
                program.R4100_00_INSERT_FOLLOWUP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.Value = 123;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2024-12-12";
                program.R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R4500_00_UPDATE_AVISOSAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*16*/ 
                program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.Value = "2024-12-12";
                program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO.Value = "2024-12-12";
                program.R5100_00_INSERT_AVISOCRE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*17*/
                program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO.Value = "2024-12-12";
                program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.Value = "2024-12-12";
                program.R5200_00_INSERT_AVISOSAL_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*18*/
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO.Value = "2024-12-12";
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO.Value = "2024-12-12";
                program.R5300_00_INSERT_CONDESCE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}