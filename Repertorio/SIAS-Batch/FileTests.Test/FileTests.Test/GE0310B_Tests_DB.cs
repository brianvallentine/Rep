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
using static Code.GE0310B;

namespace FileTests.Test_DB
{
    [Collection("GE0310B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class GE0310B_Tests_DB
    {

        [Fact]
        public static void GE0310B_Database()
        {
            var program = new GE0310B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.Value = 1123;
                program.R0030_PESQUISAR_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ 
                program.APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.Value = 123;
                program.R0040_PESQUISAR_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.GE612.DCLGE_TP_SERVICO_INSS.GE612_SEQ_TP_SERVICO_INSS.Value = 123;
                program.RT_SELECT_TP_SERV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}