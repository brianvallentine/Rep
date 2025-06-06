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
using static Code.SI0874B;
using Dclgens;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{
    [Collection("SI0874B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0874B_Tests_DB
    {

        [Fact]
        public static void SI0874B_Database()
        {
            var program = new SI0874B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R010_LE_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.W_GDA_DATA_INICIO.Value = "2020-01-01";
                program.R010_LE_SISTEMA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.W_GDA_DATA_INICIO.Value = "2020-01-01";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R030_DECLARE_CTRAB_DB_DECLARE_1(); program.R030_DECLARE_CTRAB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG.Value = 1 ;
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA.Value = 1;
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.Value = 1;
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO.Value = 1;
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO.Value = 1;
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_SIT_REGISTRO.Value = "x";
                program.R940_ACESSO_SINCREDINT_DB_DECLARE_1(); program.R940_ACESSO_SINCREDINT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = 1;
                program.R120_LE_GESISFUO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 1;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = 1;
                program.R310_PESQUISA_OPERACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1;
                program.R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1;
                program.R312_PESQUISA_VAL_AVISADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ 
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.Value = 1;    
                program.R400_PESQUISA_FORNECEDORES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.HOST_COD_CAUSA.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.Value = 1;
                program.R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.Value = 1;
                program.R600_BUSCA_NOME_RAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.Value = 1; 
                program.R700_BUSCA_NOME_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1;
                program.R920_ACESSO_SINI_HABIT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value =1;
                program.R940_ACESSO_SINCREDINT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ 
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value=1;
                program.R960_ACESSO_SINI_PENHOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.Value = 1;
                program.R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ 
                program.R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ 
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.Value =1;
                program.R1010_ACESSO_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ 
                program.R1100_ACESSO_PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/ 
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1;
                program.R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_ENDOSSO.Value = 1;
                program.SINISAUT.DCLSINISTRO_AUTO1.SINISAUT_NUM_ITEM.Value = 1;
                program.R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ 
                program.R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.Value = 1;
                program.R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.Value = 1;
                program.R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ 
                program.HOST_COD_CLIENTE.Value = 1;
                program.R1600_ACESSO_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 1;
                program.R1700_BUSCA_AGENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value=1;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value=1;
                program.R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123456;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 123;
                program.R1810_BUSCA_SIVAT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO.Value = "x";
                program.R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/
                program.SITRATEM.DCLSI_TRAB_TEMP01.SITRATEM_COD_PRODUTO.Value = 1;
                program.R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}