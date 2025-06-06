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
using static Code.PF0618B;

namespace FileTests.Test_DB
{
    [Collection("PF0618B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0618B_Tests_DB
    {

        [Fact]
        public static void PF0618B_Database()
        {
            var program = new PF0618B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0007_00_OBTER_DT_PROCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/

                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2000-10-10";
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2000-10-10";

                program.R0050_00_SELECIONA_MOVTO_DB_DECLARE_1(); program.R0050_00_SELECIONA_MOVTO_DB_OPEN_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO.Value = "2000-10-10";

                program.R0156_00_OBTER_PERIPGTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0157_00_OBTER_PERIPGTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO.Value = "2000-10-10";

                program.R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                //cobol esta desatualizado perante a tabela
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = "2000-10-10";
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF.Value = "0";
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.Value = "0";

                program.R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/

                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.Value = "2000-10-10";
                program.R0515_00_OBTER_VIGENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/

                program.SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO.Value = "2000-10-10";

                program.R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/

                program.SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_OPERACAO.Value = "2000-10-10";

                program.R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0517_00_ACESSAR_COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                //TimeOut
                program.R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0520_00_ACESSA_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/

                program.RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA.Value = "2000-10-10";

                program.R0525_00_OBTER_PCT_IOF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0586_00_OBTER_DT_MOVTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                //Erro de FOREIGN KEY
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.Value = "0";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2000-10-10";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2000-10-10";

                program.R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/

                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2000-10-10";

                program.R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}