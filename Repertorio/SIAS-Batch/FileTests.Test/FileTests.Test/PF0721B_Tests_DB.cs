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
using static Code.PF0721B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("PF0721B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0721B_Tests_DB
    {

        [Fact]
        public static void PF0721B_Database()
        {
            var program = new PF0721B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_INICIALIZA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2021-03-03";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2021-03-03";
                program.R0200_00_OBTER_MAX_NSAS_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0200_00_OBTER_MAX_NSAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2021-01-01";
                program.R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1(); 
                program.R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}