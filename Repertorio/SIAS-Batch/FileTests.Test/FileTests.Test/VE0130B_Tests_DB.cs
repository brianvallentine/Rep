using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VE0130B;

namespace FileTests.Test_DB
{
    [Collection("VE0130B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VE0130B_Tests_DB
    {
        private static string pData = "2021-03-03";

        [Fact]
        public static void VE0130B_Database()
        {
            var program = new VE0130B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/
                program.SISTEMAS_DTMOV_ABERTO_30.Value = pData;
                program.SISTEMAS_DTMOV_MONTH.Value = 0003;
                program.SISTEMAS_DTMOV_YEAR.Value = 2020;
                program.R0300_00_OPEN_CURS01_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/
                program.SISTEMAS_DTINI_COTACAO.Value = pData;
                program.SISTEMAS_DTINI_COTACAO.Value = pData;
                program.R0250_00_APURAR_INDICE_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.SISTEMAS_DTTER_COTACAO.Value = pData;
                program.R0200_00_VERIFICA_COTACAO_DB_SELECT_1(); 

            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ 
                program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Value = pData;
                program.R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/
                program.R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R8000_00_SELECT_HISCOBPR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R8100_00_SELECT_OPCPAGVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.Value = pData;
                program.R8300_00_INSERT_HISCOBPR_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }


        }
    }
}