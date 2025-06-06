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
using static Code.SI0502S;
using Dclgens;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0502S_Tests_DB")]
    public class SI0502S_Tests_DB
    {

        [Fact]
        public static void SI0502S_Database()
        {
            var program = new SI0502S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1210_00_ALTERA_SINISMES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try {
                /*6*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO.Value = "2025-04-01";
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA.Value = "2025-04-01";
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Value = "2025-04-01";

                program.R1240_00_INCLUI_SINISHIS_DB_INSERT_1(); 

            } catch (Exception ex) 
            {
                _.ThreatableTestError(ex);
            }
            
            try { /*7*/ program.R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}