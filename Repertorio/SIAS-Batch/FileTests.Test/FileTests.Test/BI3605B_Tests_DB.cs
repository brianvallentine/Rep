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
using static Code.BI3605B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("BI3605B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI3605B_Tests_DB
    {

        [Fact]
        public static void BI3605B_Database()
        {
            var program = new BI3605B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0006_00_OBTER_RELATORI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*3*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2024-12-16";
                program.R0006_00_OBTER_RELATORI_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0050_00_SELECIONA_MOVTO_DB_DECLARE_1(); program.R0050_00_SELECIONA_MOVTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0188_00_SEL_BILHETE_ERROS_DB_DECLARE_1(); program.R0188_00_SEL_BILHETE_ERROS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0180_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0181_00_SELECT_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0200_00_UPD_BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0220_00_VERIFICA_CANCEL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0220_00_VERIFICA_CANCEL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*12*/ 
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2024-12-16";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2024-12-16";
                program.R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}