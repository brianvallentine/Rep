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
using static Code.CB6249B;

namespace FileTests.Test_DB
{
    [Collection("CB6249B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB6249B_Tests_DB
    {

        [Fact]
        public static void CB6249B_Database()
        {
            var program = new CB6249B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO.Value = "2000-10-10";
            program.CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO.Value = "2000-10-10";
            program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.Value = "2000-10-10";
            program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.Value = "2000-10-10";

            program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO.Value = "2000-10-10";
            program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.Value = "2000-10-10";

            program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO.Value = "2000-10-10";
            program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.Value = "2000-10-10";

            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0340_00_SELECT_MOVIMCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0420_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0450_00_SELECT_MOVIMCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0510_00_SELECT_V0CEDENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1100_00_INSERT_CONVERSI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R4000_00_INSERT_MOVIMCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R4600_LER_AVISO_CREDITO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R4900_LER_AVISOS_SALDOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}