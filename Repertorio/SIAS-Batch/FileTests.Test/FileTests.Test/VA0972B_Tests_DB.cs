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
using static Code.VA0972B;

namespace FileTests.Test_DB
{
    [Collection("VA0972B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA0972B_Tests_DB
    {

        [Fact]
        public static void VA0972B_Database()
        {
            var program = new VA0972B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();
            
            try { /*1*/ program.R0000_00_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R2030_00_UPDATE_RELATORI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R2035_00_INSERT_RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R7050_00_RECUPERA_CONTROLE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_MOVIMENTO.Value = "1988-04-30";
                program.R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}