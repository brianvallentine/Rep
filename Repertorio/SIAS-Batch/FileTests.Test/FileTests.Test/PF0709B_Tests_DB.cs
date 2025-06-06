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
using static Code.PF0709B;

namespace FileTests.Test_DB
{
    [Collection("PF0709B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0709B_Tests_DB
    {

        [Fact]
        public static void PF0709B_Database()
        {
            var program = new PF0709B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_INICIALIZA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA.Value = "2021-01-01";
                program.R0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/ program.R0340_00_VERIFICAR_PGTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0350_00_SELECT_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = "2021-11-11";
                program.R0400_00_SELECT_HISTORICO_DB_SELECT_1(); }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R0430_00_LER_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0500_00_INCLUIR_HISTORICO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0550_00_UPDATE_PROPFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2021-12-12";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2022-10-10";
                program.R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); } 
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/
                program.WHOST_DT_INI_ATR.Value = "1990-01-01";
                program.R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1(); 
                program.R0900_00_DECLARE_PROPOSTA_DB_OPEN_1(); } 
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}