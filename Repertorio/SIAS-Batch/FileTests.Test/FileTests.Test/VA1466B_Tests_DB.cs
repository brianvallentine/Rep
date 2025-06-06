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
using static Code.VA1466B;

namespace FileTests.Test_DB
{
    [Collection("VA1466B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA1466B_Tests_DB
    {

        [Fact]
        public static void VA1466B_Database()
        {
            var program = new VA1466B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_V0COMISICOB_DB_DECLARE_1(); program.R0900_00_DECLARE_V0COMISICOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R3100_00_DECLARE_FONTES_DB_DECLARE_1(); program.R3100_00_DECLARE_FONTES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1100_00_SELECT_V0CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1010_00_SELECT_CONVERSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1200_00_SELECT_V0ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1500_00_SELECT_PROP_ERRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R2500_00_SELECT_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R3200_00_DECLARE_ESCNEG_DB_DECLARE_1(); program.R3200_00_DECLARE_ESCNEG_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R3190_00_SELECT_ESCNEG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R3250_00_VERIFICA_PEP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.DB100_ACESSA_RCAPS_TITULO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}