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
using static Code.CB6248B;

namespace FileTests.Test_DB
{
    [Collection("CB6248B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class CB6248B_Tests_DB
    {
        private static string pData = "2022-02-02";

        [Fact]
        public static void CB6248B_Database()
        {
            var program = new CB6248B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0340_00_SELECT_MOVIMCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0420_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0430_00_SELECT_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0450_00_SELECT_MOVIMCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0510_00_SELECT_V0CEDENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1000_00_DELETE_BILHETE_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO.Value = pData;
                program.CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO.Value = pData;
                program.R1100_00_INSERT_CONVERSI_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/
                program.BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.Value = pData;
                program.BILHETE.DCLBILHETE.BILHETE_DATA_VENDA.Value = pData;
                program.BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO.Value = pData;
                program.BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO.Value = pData;
                program.BILHETE.DCLBILHETE.BILHETE_TIMESTAMP.Value = pData;
                program.R1200_00_INSERT_BILHETE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.Value = pData;
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.Value= pData;
                program.R4000_00_INSERT_MOVIMCOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/ program.R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}