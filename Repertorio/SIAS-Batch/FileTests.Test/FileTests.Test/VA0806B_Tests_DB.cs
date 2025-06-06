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
using static Code.VA0806B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VA0806B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA0806B_Tests_DB
    {
        private static string pData = "2023-02-02";

        [Fact]
        public static void VA0806B_Database()
        {
            var program = new VA0806B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MOVIMENTO.Value = pData;
            program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO.Value = pData;
            program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_RECEPCAO.Value = pData;

            try { /*1*/ program.R0001_00_FITA_CREDITO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0020_00_PROCESSA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0220_00_PROCESSA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.DB010_ACESSA_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.DB015_ACESSA_GEARDETALHE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.DB020_INSERT_GEARDETALHE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}