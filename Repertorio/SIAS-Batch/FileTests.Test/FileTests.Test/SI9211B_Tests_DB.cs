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
using Dclgens;
using Code;
using static Code.SI9211B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI9211B_Tests_DB")]
    public class SI9211B_Tests_DB
    {

        [Fact]
        public static void SI9211B_Database()
        {
            var program = new SI9211B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0510_00_MAX_GEARDETA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0520_00_INCLUI_GEARDETA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0700_00_ALTERA_GEARDETA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1(); program.R0900_00_DECLARA_SIARDEVC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1010_00_CHECA_ESTORNO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*8*/

                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Value = "2025-01-01";
                program.R1010_00_CHECA_ESTORNO_DB_SELECT_2(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            
            try { /*9*/ program.R1060_00_LE_CAUSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1070_00_LE_MESTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1100_00_LE_SIERRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1210_00_LE_MOVDEBCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1250_00_LE_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1300_00_INCLUI_SIARREVC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1450_CHECA_OP_BAIXA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1510_00_CONSULTA_SINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*18*/

                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Value = "2025-01-01";
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO.Value = "2025-01-01";
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA.Value = "2025-01-01";

                program.R1520_00_INCLUI_SINIS_DB_INSERT_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            
            try { /*19*/ program.R1610_00_ATUAL_SI_PESS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1610_00_ATUAL_SI_PESS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}