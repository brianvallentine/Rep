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
using static Code.SI0890B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0890B_Tests_DB")]
    public class SI0890B_Tests_DB
    {

        [Fact]
        public static void SI0890B_Database()
        {
            var program = new SI0890B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try 
            { /*1*/
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Value = "2024-01-01";
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = "2025-01-01";
                program.R1100_OPEN_CR_LOTER_DB_OPEN_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            
            try { /*2*/ program.R100_OPEN_CR_RELAT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R111000_PESQUISA_ADIANTAMENTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0130_LER_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0140_LER_DESC_CAUSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R111010_PESQUISA_FRANQUIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*7*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA.Value = "2024-01-01";
                program.R111020_LE_LOTERICO01_DB_SELECT_1(); 
            } catch (Exception ex) 
            {
                _.ThreatableTestError(ex); 
            }
            
            try { /*8*/ program.R111030_LE_APOLICES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*9*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA.Value = "2024-01-01";
                program.R111040_LE_OUTROS_COB_DB_SELECT_1();
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex);
            }
            
            try { /*10*/ program.R111050_LE_AGENCIAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R20_UPDATE_RELATORIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}