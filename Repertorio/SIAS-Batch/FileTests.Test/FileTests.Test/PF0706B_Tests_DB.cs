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
using static Code.PF0706B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("PF0706B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0706B_Tests_DB
    {

        [Fact]
        public static void PF0706B_Database()
        {
            var program = new PF0706B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            try { /*1*/ program.SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.Value = "AD";
                program.R0010_00_OBTER_DATA_DIA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/ program.R0015_00_OBTER_DT_PROCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/
                program.WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR.Value = "2017-05-05";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2017-05-05";
                program.R0025_00_SELECIONA_MOVTO_DB_DECLARE_1(); 
                program.R0025_00_SELECIONA_MOVTO_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/
                program.BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA.Value = "2020-01-01";
                program.R0080_00_SELECIONA_BIL_COB_DB_DECLARE_1(); 
                program.R0080_00_SELECIONA_BIL_COB_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.Value = 80000000017;
                program.R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R0055_00_LER_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0056_00_LER_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = "2020-01-01";
                program.R0060_00_LER_HISTORICO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try{ /*10*/
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = "2020-01-01";
                program.R0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0101_00_LER_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0125_00_LER_H_PROP_FIDEL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0125_00_LER_H_PROP_FIDEL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO.Value = "2020-01-01";
                program.R0130_00_OBTER_PRM_DEV_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*16*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2020-01-01";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2020-01-01";
                program.R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*17*/ program.R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}