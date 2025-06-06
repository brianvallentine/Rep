using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Dclgens;
using Copies;
using Sias.VidaAzul.DB2.VA3118B;

namespace Code
{
    public class VA3118B
    {
        public bool IsCall { get; set; }

        public VA3118B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  TORNA A SITUACAO DA PROPOSTA       *      */
        /*"      *                             DE 9 PARA 0  DESDE QUE NAO TENHA   *      */
        /*"      *                             AS NOVAS CRITICAS PARA ACEITACAO   *      */
        /*"      *                             AUTOMATICA                         *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  TERCIO CARVALHO                    *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA3118B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  12/01/95                           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  29/06/2006                         *      */
        /*"      *                                                                *      */
        /*"      *   LIBERA PROPOSTAS COM MAIS DE 15 DIAS EM CRITICA PARA ATENDER *      */
        /*"      *   A SSI 10.186                                                 *      */
        /*"      *                  TERCIO CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 11/08/2008  INIBIR O COMANDO DISPLAY                  - WV0808 *      */
        /*"      * 11/09/2008  INCLUIR A CLAUS WITH UR NO COMANDO SELECT - WV0908 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  *   VERSAO 06 - DEMANDA 402.982                                  *      */
        /*"      *             - SUBSTITUIR CONSULTA DA VIEW V0ERROSPROPVA        *      */
        /*"      *               PELA NA NOVA TABELA VG_CRITICA_PROPOSTA          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.06        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 152.475                                      *      */
        /*"      *               MANTER PROPOSTA EM CR�TICA QUANDO TIVER ERRO     *      */
        /*"      *               1876 - CONSULTA CRIVO N�O RETORNOU RESULTADO     *      */
        /*"      *      18/08/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                   PROCURE POR V.05             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04                                                    *      */
        /*"      *             - CAD 145.335                                      *      */
        /*"      *                                                                *      */
        /*"      *               EMISS�O VIDA GENTE - CCA                         *      */
        /*"      *                1 - DEVEM ENTRAR EM CR�TICA E SEREM ACEITAS     *      */
        /*"      *                    EXCLUSIVAMENTE DE FORMA MANUAL;             *      */
        /*"      *                2 - DEVEM APRESENTAR A CR�TICA "1800 - AGUARDAR *      */
        /*"      *                    PROPOSTA F�SICA "                           *      */
        /*"      *      27/12/2016 - MAURO ROCHA DA CRUZ                          *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.04             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03                                                    *      */
        /*"      *             - CAD 92.564                                       *      */
        /*"      *               FALHA NA INTEGRAO DO PRODUTO VIDA DA GENTE     *      */
        /*"      *               ACESSAR O RCAPS TAMBEM PELO CERTIFICADO QUANDO   *      */
        /*"      *               A PROPOSTA FOR CANAL 0 (ZERO).                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/06/2014 - MAURO ROCHA DA CRUZ                          *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.03             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 30.598                                       *      */
        /*"      *                                                                *      */
        /*"      *               - DIRECIONAR PROPOSTAS COM ERROS 1703 E 1815 PARA*      */
        /*"      *                 ANALISE MANUAL.                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/10/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  INDAGE                           PIC S9(4) COMP.*/
        public IntBasis INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDOPR                           PIC S9(4) COMP.*/
        public IntBasis INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDNUM                           PIC S9(4) COMP.*/
        public IntBasis INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDDIG                           PIC S9(4) COMP.*/
        public IntBasis INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDCARTAO                        PIC S9(4) COMP.*/
        public IntBasis INDCARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CONDTE-IEA                       PIC S9(005)V9(02) COMP-3.*/
        public DoubleBasis CONDTE_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  CONDTE-IPA                       PIC S9(005)V9(02) COMP-3.*/
        public DoubleBasis CONDTE_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  DESCON-PERC                      PIC S9(003)V9(04) COMP-3.*/
        public DoubleBasis DESCON_PERC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
        /*"01  DESCON-DTINIVIG                  PIC  X(010).*/
        public StringBasis DESCON_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  DESCON-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DESCON_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DESCON-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DESCON_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DESCON-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DESCON_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VIND-COD-CRM                     PIC S9(4) COMP.*/
        public IntBasis VIND_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA                 PIC S9(4) COMP.*/
        public IntBasis VIND_FAIXA_RENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-COUNT                      PIC S9(4) COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SIVPF-NR-PROPOSTA                PIC S9(15) COMP-3.*/
        public IntBasis SIVPF_NR_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SIVPF-NR-SICOB                   PIC S9(15) COMP-3.*/
        public IntBasis SIVPF_NR_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SIVPF-NR-IDENTIFI                PIC S9(15) COMP-3.*/
        public IntBasis SIVPF_NR_IDENTIFI { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SIVPF-SIT-PROPOSTA               PIC  X(03).*/
        public StringBasis SIVPF_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  SIVPF-DTQITBCO                   PIC  X(10).*/
        public StringBasis SIVPF_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIVPF-DATA-CREDITO               PIC  X(10).*/
        public StringBasis SIVPF_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIVPF-VAL-PAGO                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis SIVPF_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  SIVPF-OPCAO-COBER                PIC  X(01).*/
        public StringBasis SIVPF_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  CONVER-NUM-SICOB                 PIC S9(15) COMP-3.*/
        public IntBasis CONVER_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  CONVER-NUM-PROPOSTA              PIC S9(15) COMP-3.*/
        public IntBasis CONVER_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0PARC-NRCERTIF                  PIC S9(15) COMP-3.*/
        public IntBasis V0PARC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-NRCERTIF                  PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-NRPROPAZ                  PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NRPROPAZ { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  WHOST-COD-ERRO                   PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WHOST-COD-ERRO-RCAP              PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_ERRO_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WHOST-COD-ERRO-COMUN             PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_ERRO_COMUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-CODPRODU                  PIC S9(04) COMP.*/
        public IntBasis PROPVA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-CODCLIEN                  PIC S9(09) COMP.*/
        public IntBasis PROPVA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROPVA-OCOREND                   PIC S9(04) COMP.*/
        public IntBasis PROPVA_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-FONTE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-AGECOBR                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OPCAO-COBER               PIC  X(1).*/
        public StringBasis PROPVA_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DTQITBCO                  PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTINICDG                  PIC  X(10).*/
        public StringBasis PROPVA_DTINICDG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTINISAF                  PIC  X(10).*/
        public StringBasis PROPVA_DTINISAF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-NRMATRVEN                 PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-CODOPER                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DIFPAR-CODOPER                   PIC S9(4) COMP.*/
        public IntBasis DIFPAR_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-DTMOVTO                   PIC  X(10).*/
        public StringBasis PROPVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTPROXVEN                 PIC  X(10).*/
        public StringBasis PROPVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTVENCTO                  PIC  X(10).*/
        public StringBasis PROPVA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTMINVEN                  PIC  X(10).*/
        public StringBasis PROPVA_DTMINVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-SITUACAO                  PIC  X(1).*/
        public StringBasis PROPVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-NUM-APOLICE               PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODSUBES                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OCORHIST                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRPARCEL                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-SIT-INTERF                PIC  X(1).*/
        public StringBasis PROPVA_SIT_INTERF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-TIMESTAMP                 PIC  X(26).*/
        public StringBasis PROPVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01  PROPVA-IDADE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-SEXO                      PIC  X(1).*/
        public StringBasis PROPVA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-EST-CIV                   PIC  X(1).*/
        public StringBasis PROPVA_EST_CIV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-COD-CRM                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRMATRFUN                 PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-INRMATRFUN                PIC S9(4) COMP.*/
        public IntBasis PROPVA_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRPROPOS                  PIC S9(09) COMP.*/
        public IntBasis PROPVA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROPVA-INRPROPOS                 PIC S9(04) COMP.*/
        public IntBasis PROPVA_INRPROPOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-DTADMIS                   PIC  X(10) VALUE SPACES.*/
        public StringBasis PROPVA_DTADMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  PROPVA-IDTADMIS                  PIC S9(04) COMP VALUE ZEROS*/
        public IntBasis PROPVA_IDTADMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WPROPVA-DTADMIS                  PIC  X(10).*/
        public StringBasis WPROPVA_DTADMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WPROPVA-IDTADMIS                 PIC S9(04).*/
        public IntBasis WPROPVA_IDTADMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)."));
        /*"01  PROPVA-CODCCT                    PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_CODCCT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-ICODCCT                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_ICODCCT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-CODUSU                    PIC  X(8).*/
        public StringBasis PROPVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  PROPVA-FAIXA-RENDA-IND           PIC  X(1).*/
        public StringBasis PROPVA_FAIXA_RENDA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DATA                      PIC  X(10).*/
        public StringBasis PROPVA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DPS-TITULAR               PIC  X(30).*/
        public StringBasis PROPVA_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"01  PRODVG-CODPRODAZ                 PIC  X(03).*/
        public StringBasis PRODVG_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  PRODVG-ESTR-COBR                 PIC  X(10).*/
        public StringBasis PRODVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PRODVG-ORIG-PRODU                PIC  X(10).*/
        public StringBasis PRODVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PRODVG-AGENCIADOR                PIC S9(9) COMP.*/
        public IntBasis PRODVG_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PRODVG-TEM-SAF                   PIC  X(1).*/
        public StringBasis PRODVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-TEM-CDG                   PIC  X(1).*/
        public StringBasis PRODVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-CODRELAT                  PIC  X(8).*/
        public StringBasis PRODVG_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  PRODVG-RISCO                     PIC  X(1).*/
        public StringBasis PRODVG_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-COBERADIC-PREMIO          PIC  X(1).*/
        public StringBasis PRODVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-CUSTOCAP-TOTAL            PIC  X(1).*/
        public StringBasis PRODVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-DESCONTO-ADESAO           PIC S9(003)V9(05) COMP-3.*/
        public DoubleBasis PRODVG_DESCONTO_ADESAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(05)"), 5);
        /*"01  PRODVG-SITPLANCEF                PIC  X(001).*/
        public StringBasis PRODVG_SITPLANCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  PRODVG-COD-PRODUTO               PIC S9(04) COMP.*/
        public IntBasis PRODVG_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  OPCAOP-OPCAOPAG                  PIC  X(1).*/
        public StringBasis OPCAOP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  OPCAOP-PERIPGTO                  PIC S9(4) COMP.*/
        public IntBasis OPCAOP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-DIA-DEB                   PIC S9(4) COMP.*/
        public IntBasis OPCAOP_DIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-AGECTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-OPRCTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-NUMCTADEB                 PIC S9(9) COMP.*/
        public IntBasis OPCAOP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  OPCAOP-DIGCTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-CARTAOCRED                PIC S9(16) COMP-3.*/
        public IntBasis OPCAOP_CARTAOCRED { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
        /*"01  V0AGCEF-COD-AGCOBR               PIC S9(4) COMP.*/
        public IntBasis V0AGCEF_COD_AGCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  COBERP-DTINIVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTTERVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-IMPMORNATU                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORACID                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPINVPERM                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPAMDS                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDH                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDIT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG-DIF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP-DIF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DIFPAR-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DIFPAR_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCAP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IIMPSEGAUXF               PIC S9(04)    COMP.*/
        public IntBasis COBERP_IIMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-IVLCUSTAUXF               PIC S9(04)    COMP.*/
        public IntBasis COBERP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBER-MINOCOR                 PIC S9(04)    COMP.*/
        public IntBasis V0COBER_MINOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COMISI-VALADT                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COMISI_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PARCOM-TIPCOM                   PIC  X(01).*/
        public StringBasis PARCOM_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  FUNDO-PCCOMCOR                  PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  V1RIND-PCIOF                    PIC S9(03)V99 COMP-3.*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  V1RIND-DTINIVIG                 PIC  X(10).*/
        public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V1APOL-RAMO                     PIC S9(04)    COMP.*/
        public IntBasis V1APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FUNDO-PCCOMIND                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMIND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-PCCOMGER                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-PCCOMSUP                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMSUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-PCCOMTOT                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMTOT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-VALBASVG                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VALBASVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNDO-VALBASAP                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VALBASAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNDO-VLCOMISVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VLCOMISVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNDO-VLCOMISAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VLCOMISAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  CLIENT-DTNASC                    PIC  X(10).*/
        public StringBasis CLIENT_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC-I                  PIC S9(04) COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CLIENT-CGCCPF                    PIC S9(15) COMP-3.*/
        public IntBasis CLIENT_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  CDGCOB-DTINIVIG                  PIC  X(010).*/
        public StringBasis CDGCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SAFCOB-DTINIVIG                  PIC  X(010).*/
        public StringBasis SAFCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  REPCDG-DTREF                     PIC  X(010).*/
        public StringBasis REPCDG_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  REPSAF-DTREF                     PIC  X(010).*/
        public StringBasis REPSAF_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  RELATO-CODRELAT                  PIC  X(008).*/
        public StringBasis RELATO_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  RELATO-NRPARCEL                  PIC S9(004) COMP VALUE +0.*/
        public IntBasis RELATO_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RELATO-OPERACAO                  PIC S9(004) COMP VALUE +0.*/
        public IntBasis RELATO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RELATO-NUM-APOLICE               PIC S9(13) COMP-3.*/
        public IntBasis RELATO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  RELATO-CODSUBES                  PIC S9(4) COMP.*/
        public IntBasis RELATO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CLIROT-DTMOVABE                  PIC  X(010).*/
        public StringBasis CLIROT_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  FONTE-PROPAUTOM                  PIC S9(009) COMP.*/
        public IntBasis FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  APCORR-RAMO                      PIC S9(004) COMP.*/
        public IntBasis APCORR_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  APCORR-DTINIVIG                  PIC  X(010).*/
        public StringBasis APCORR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SUBGRU-CODSUBES                  PIC S9(004) COMP.*/
        public IntBasis SUBGRU_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WSISTEMA-DTMOVABE                PIC  X(010).*/
        public StringBasis WSISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-CURRDATE                 PIC  X(010).*/
        public StringBasis SISTEMA_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE2                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE3                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE-15              PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MMFAIXA                          PIC S9(004)      COMP.*/
        public IntBasis MMFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MFAIXA                           PIC S9(004)      COMP.*/
        public IntBasis MFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MAGENCIADOR                      PIC S9(009)      COMP.*/
        public IntBasis MAGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  MDTMOVTO                         PIC  X(010).*/
        public StringBasis MDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MMDTMOVTO                        PIC  X(010).*/
        public StringBasis MMDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MCODOPER                         PIC S9(004)      COMP.*/
        public IntBasis MCODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MDTREF                           PIC  X(010).*/
        public StringBasis MDTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MTPBENEF                         PIC  X(001).*/
        public StringBasis MTPBENEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTPINCLUS                        PIC  X(001).*/
        public StringBasis MTPINCLUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MNUM-MATRICULA                   PIC S9(015)      COMP-3.*/
        public IntBasis MNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  MMNUM-MATRICULA                  PIC S9(015)      COMP-3.*/
        public IntBasis MMNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  MAGECOBR                         PIC S9(04)       COMP.*/
        public IntBasis MAGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  MNUM-CTA-CORRENTE                PIC S9(013)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  MDAC-CTA-CORRENTE                PIC  X(001).*/
        public StringBasis MDAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTXAPMA                          PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPMA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXAPIP                          PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXVG                            PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  BENEF-NRBENEF                    PIC S9(04)       COMP.*/
        public IntBasis BENEF_NRBENEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  BENEF-NOMBENEF                   PIC X(40).*/
        public StringBasis BENEF_NOMBENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  BENEF-GRAUPAR                    PIC X(10).*/
        public StringBasis BENEF_GRAUPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-PCTBENEF                   PIC S9(03)V99    COMP-3.*/
        public DoubleBasis BENEF_PCTBENEF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  BENEF-DTTERVIG                   PIC X(10).*/
        public StringBasis BENEF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTINIVIG                   PIC X(10).*/
        public StringBasis BENEF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTTERVIG-I                 PIC S9(04)       COMP.*/
        public IntBasis BENEF_DTTERVIG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  BANCOS-NRTIT                     PIC S9(013)      COMP-3.*/
        public IntBasis BANCOS_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  FATURC-DTREF                     PIC  X(010).*/
        public StringBasis FATURC_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  PARCEL-OCORHIST                  PIC S9(004)      COMP.*/
        public IntBasis PARCEL_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HOST-CODCONV                     PIC S9(004)      COMP.*/
        public IntBasis HOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CONVEN-CODCONV                   PIC S9(004)      COMP.*/
        public IntBasis CONVEN_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CONVEN-CARTAO                    PIC S9(004)      COMP.*/
        public IntBasis CONVEN_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HISTCB-DTVENCTO                  PIC  X(010).*/
        public StringBasis HISTCB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  HISTCB-SITUACAO                  PIC  X(001).*/
        public StringBasis HISTCB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  HISTCB-CODOPER                   PIC S9(004)      COMP.*/
        public IntBasis HISTCB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0HCOB-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01         V1RCAC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-NRRCAPCO     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-HORAOPER     PIC  X(008).*/
        public StringBasis V1RCAC_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V1RCAC-DTMOVTO      PIC  X(010).*/
        public StringBasis V1RCAC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITUACAO     PIC  X(001).*/
        public StringBasis V1RCAC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-BCOAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-AGEAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAC_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAC-DATARCAP     PIC  X(010).*/
        public StringBasis V1RCAC_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-DTCADAST     PIC  X(010).*/
        public StringBasis V1RCAC_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITCONTB     PIC  X(001).*/
        public StringBasis V1RCAC_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1RCAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V1RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAP-DATARCAP     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V1RCAP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0RCAP-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NOME         PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01         V0RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-VALPRI       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-DTCADAST     PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-SITUACAO     PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0RCAP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0RCAP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0RCAP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V2RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V2RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  V0FOLHM-COD-CARTA                PIC  X(001).*/
        public StringBasis V0FOLHM_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLHM-DTEMICAR                 PIC  X(010).*/
        public StringBasis V0FOLHM_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-COD-PRODUTO               PIC S9(004)      COMP.*/
        public IntBasis V0FOLH_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0FOLH-NRCERTIF                  PIC S9(015)      COMP-3.*/
        public IntBasis V0FOLH_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  V0FOLH-COD-CARTA                 PIC  X(001).*/
        public StringBasis V0FOLH_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLH-DTEMICAR                  PIC  X(010).*/
        public StringBasis V0FOLH_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-DTSOLICIT                 PIC  X(010).*/
        public StringBasis V0FOLH_DTSOLICIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-CODUSU                    PIC  X(008).*/
        public StringBasis V0FOLH_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  V0FOLH-SITUACAO                  PIC  X(001).*/
        public StringBasis V0FOLH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLH-TIMESTAMP                 PIC  X(026).*/
        public StringBasis V0FOLH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WS-WORK-AREAS.*/
        public VA3118B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA3118B_WS_WORK_AREAS();
        public class VA3118B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-CHAVE.*/
            public VA3118B_WS_CHAVE WS_CHAVE { get; set; } = new VA3118B_WS_CHAVE();
            public class VA3118B_WS_CHAVE : VarBasis
            {
                /*"        05 WS-NUM-APOLICE            PIC 9(13).*/
                public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"        05 WS-CODSUBES               PIC 9(04).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    03  WS-CHAVE-ANT.*/
            }
            public VA3118B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VA3118B_WS_CHAVE_ANT();
            public class VA3118B_WS_CHAVE_ANT : VarBasis
            {
                /*"        05 WS-NUM-APOLICE-ANT        PIC 9(13)      VALUE ZEROS.*/
                public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05 WS-CODSUBES-ANT           PIC 9(04)      VALUE ZEROS.*/
                public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  WS-VLPREMIO-MAX              PIC S9(13)V99 COMP-3.*/
            }
            public DoubleBasis WS_VLPREMIO_MAX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  WS-VLPREMIO-MIN              PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_VLPREMIO_MIN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  WS-COBERP-VLPREMIO           PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_COBERP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  WS-IMPMORNATU                PIC 999999999,99.*/
            public DoubleBasis WS_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("9", "9", "999999999V99."), 2);
            /*"    03  WS-VLPREMIO                  PIC 999999999,99.*/
            public DoubleBasis WS_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "9", "999999999V99."), 2);
            /*"    03  WS-COUNT                     PIC 9(02)      VALUE ZEROS.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03  WS-TAXA-VG                   PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_VG { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WS-TAXA-AP                   PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_AP { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WS-TAXA-TOT                  PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_TOT { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WTEM-SIVPF                   PIC 9 VALUE 0.*/
            public IntBasis WTEM_SIVPF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOF                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOP                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOP { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOS                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOS { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOF-D                     PIC 9 VALUE 0.*/
            public IntBasis WS_EOF_D { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WFIM-V1RCAP                  PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WTEM-V0RCAP                  PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WS-RATEIO                    PIC  9(003)V9(5).*/
            public DoubleBasis WS_RATEIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(5)."), 5);
            /*"    03  WS-IND-IOF                   PIC S9(001)V9(4) COMP-3.*/
            public DoubleBasis WS_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(001)V9(4)"), 4);
            /*"    03  WS-COD-CARTA                 PIC  X(001).*/
            public StringBasis WS_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  WS-CODPRODU-ANT              PIC S9(004)  COMP  VALUE +0*/
            public IntBasis WS_CODPRODU_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  W01A0100.*/
            public VA3118B_W01A0100 W01A0100 { get; set; } = new VA3118B_W01A0100();
            public class VA3118B_W01A0100 : VarBasis
            {
                /*"        05 W01N0100                  PIC 9(01).*/
                public IntBasis W01N0100 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    03  WSQLCODE3                    PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03  WSQLCODE-PLANOS              PIC S9(009) COMP.*/
            public IntBasis WSQLCODE_PLANOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03 W-DTEMICAR      PIC X(010) VALUE SPACES.*/
            public StringBasis W_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 FILLER  REDEFINES W-DTEMICAR.*/
            private _REDEF_VA3118B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA3118B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA3118B_FILLER_0(); _.Move(W_DTEMICAR, _filler_0); VarBasis.RedefinePassValue(W_DTEMICAR, _filler_0, W_DTEMICAR); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_DTEMICAR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_DTEMICAR); }
            }  //Redefines
            public class _REDEF_VA3118B_FILLER_0 : VarBasis
            {
                /*"       05 W-SSEMICAR                 PIC 9(004).*/
                public IntBasis W_SSEMICAR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                     PIC X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W-MMEMICAR                 PIC 9(002).*/
                public IntBasis W_MMEMICAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                     PIC X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W-DDEMICAR                 PIC 9(002).*/
                public IntBasis W_DDEMICAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-VIGENCIA.*/

                public _REDEF_VA3118B_FILLER_0()
                {
                    W_SSEMICAR.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    W_MMEMICAR.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    W_DDEMICAR.ValueChanged += OnValueChanged;
                }

            }
            public VA3118B_WS_VIGENCIA WS_VIGENCIA { get; set; } = new VA3118B_WS_VIGENCIA();
            public class VA3118B_WS_VIGENCIA : VarBasis
            {
                /*"       05  WS-VIG-ANO                PIC 9(004).*/
                public IntBasis WS_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-MES                PIC 9(002).*/
                public IntBasis WS_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-DIA                PIC 9(002).*/
                public IntBasis WS_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-VIGENCIA1.*/
            }
            public VA3118B_WS_VIGENCIA1 WS_VIGENCIA1 { get; set; } = new VA3118B_WS_VIGENCIA1();
            public class VA3118B_WS_VIGENCIA1 : VarBasis
            {
                /*"       05  WS-VIG-ANO1               PIC 9(004).*/
                public IntBasis WS_VIG_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-MES1               PIC 9(002).*/
                public IntBasis WS_VIG_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-DIA1               PIC 9(002).*/
                public IntBasis WS_VIG_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W01DTSQL                      PIC X(010).*/
            }
            public StringBasis W01DTSQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 W01DTSQL-R    REDEFINES W01DTSQL.*/
            private _REDEF_VA3118B_W01DTSQL_R _w01dtsql_r { get; set; }
            public _REDEF_VA3118B_W01DTSQL_R W01DTSQL_R
            {
                get { _w01dtsql_r = new _REDEF_VA3118B_W01DTSQL_R(); _.Move(W01DTSQL, _w01dtsql_r); VarBasis.RedefinePassValue(W01DTSQL, _w01dtsql_r, W01DTSQL); _w01dtsql_r.ValueChanged += () => { _.Move(_w01dtsql_r, W01DTSQL); }; return _w01dtsql_r; }
                set { VarBasis.RedefinePassValue(value, _w01dtsql_r, W01DTSQL); }
            }  //Redefines
            public class _REDEF_VA3118B_W01DTSQL_R : VarBasis
            {
                /*"       05  W01AASQL                  PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01T1SQL                  PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01MMSQL                  PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01T2SQL                  PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01DDSQL                  PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W02DTSQL.*/

                public _REDEF_VA3118B_W01DTSQL_R()
                {
                    W01AASQL.ValueChanged += OnValueChanged;
                    W01T1SQL.ValueChanged += OnValueChanged;
                    W01MMSQL.ValueChanged += OnValueChanged;
                    W01T2SQL.ValueChanged += OnValueChanged;
                    W01DDSQL.ValueChanged += OnValueChanged;
                }

            }
            public VA3118B_W02DTSQL W02DTSQL { get; set; } = new VA3118B_W02DTSQL();
            public class VA3118B_W02DTSQL : VarBasis
            {
                /*"       05  W02AAMMSQL.*/
                public VA3118B_W02AAMMSQL W02AAMMSQL { get; set; } = new VA3118B_W02AAMMSQL();
                public class VA3118B_W02AAMMSQL : VarBasis
                {
                    /*"           10  W02AASQL              PIC 9(004).*/
                    public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           10  W02T1SQL              PIC X(001).*/
                    public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           10  W02MMSQL              PIC 9(002).*/
                    public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       05  W02T2SQL                  PIC X(001).*/
                }
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W02DDSQL                  PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W03DTSQL.*/
            }
            public VA3118B_W03DTSQL W03DTSQL { get; set; } = new VA3118B_W03DTSQL();
            public class VA3118B_W03DTSQL : VarBasis
            {
                /*"       05  W03AAMMSQL.*/
                public VA3118B_W03AAMMSQL W03AAMMSQL { get; set; } = new VA3118B_W03AAMMSQL();
                public class VA3118B_W03AAMMSQL : VarBasis
                {
                    /*"           10  W03AASQL              PIC 9(004).*/
                    public IntBasis W03AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           10  W03T1SQL              PIC X(001).*/
                    public StringBasis W03T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           10  W03MMSQL              PIC 9(002).*/
                    public IntBasis W03MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       05  W03T2SQL                  PIC X(001).*/
                }
                public StringBasis W03T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W03DDSQL                  PIC 9(002).*/
                public IntBasis W03DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W04DTSQL.*/
            }
            public VA3118B_W04DTSQL W04DTSQL { get; set; } = new VA3118B_W04DTSQL();
            public class VA3118B_W04DTSQL : VarBasis
            {
                /*"       05  W04SASQL                  PIC 9(004).*/
                public IntBasis W04SASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W04SASQL-R                REDEFINES           W04SASQL.*/
                private _REDEF_VA3118B_W04SASQL_R _w04sasql_r { get; set; }
                public _REDEF_VA3118B_W04SASQL_R W04SASQL_R
                {
                    get { _w04sasql_r = new _REDEF_VA3118B_W04SASQL_R(); _.Move(W04SASQL, _w04sasql_r); VarBasis.RedefinePassValue(W04SASQL, _w04sasql_r, W04SASQL); _w04sasql_r.ValueChanged += () => { _.Move(_w04sasql_r, W04SASQL); }; return _w04sasql_r; }
                    set { VarBasis.RedefinePassValue(value, _w04sasql_r, W04SASQL); }
                }  //Redefines
                public class _REDEF_VA3118B_W04SASQL_R : VarBasis
                {
                    /*"         10  W04AASQL                PIC 9(004).*/
                    public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       05  W04T1SQL                  PIC X(001).*/

                    public _REDEF_VA3118B_W04SASQL_R()
                    {
                        W04AASQL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04MMSQL                  PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W04T2SQL                  PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04DDSQL                  PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W05DTSQL.*/
            }
            public VA3118B_W05DTSQL W05DTSQL { get; set; } = new VA3118B_W05DTSQL();
            public class VA3118B_W05DTSQL : VarBasis
            {
                /*"       05  W05AASQL                  PIC 9(004).*/
                public IntBasis W05AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W05T1SQL                  PIC X(001).*/
                public StringBasis W05T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W05MMSQL                  PIC 9(002).*/
                public IntBasis W05MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W05T2SQL                  PIC X(001).*/
                public StringBasis W05T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W05DDSQL                  PIC 9(002).*/
                public IntBasis W05DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-CONT-BENEF                 PIC  9(004) VALUE 0.*/
            }
            public IntBasis WS_CONT_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 WS-CTA-CORRENTE-R.*/
            public VA3118B_WS_CTA_CORRENTE_R WS_CTA_CORRENTE_R { get; set; } = new VA3118B_WS_CTA_CORRENTE_R();
            public class VA3118B_WS_CTA_CORRENTE_R : VarBasis
            {
                /*"       05 WS-OPER-SEG                PIC  9(003).*/
                public IntBasis WS_OPER_SEG { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       05 WS-CTA-SEG                 PIC  9(008).*/
                public IntBasis WS_CTA_SEG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    03  WS-CTA-CORRENTE              REDEFINES        WS-CTA-CORRENTE-R            PIC 9(011).*/
            }
            private _REDEF_IntBasis _ws_cta_corrente { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTE
            {
                get { _ws_cta_corrente = new _REDEF_IntBasis(new PIC("9", "011", "9(011).")); ; _.Move(WS_CTA_CORRENTE_R, _ws_cta_corrente); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_R, _ws_cta_corrente, WS_CTA_CORRENTE_R); _ws_cta_corrente.ValueChanged += () => { _.Move(_ws_cta_corrente, WS_CTA_CORRENTE_R); }; return _ws_cta_corrente; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_corrente, WS_CTA_CORRENTE_R); }
            }  //Redefines
            /*"    03 WS-CTA-CORRENTE-VR.*/
            public VA3118B_WS_CTA_CORRENTE_VR WS_CTA_CORRENTE_VR { get; set; } = new VA3118B_WS_CTA_CORRENTE_VR();
            public class VA3118B_WS_CTA_CORRENTE_VR : VarBasis
            {
                /*"       05 WS-OPER                    PIC  9(003).*/
                public IntBasis WS_OPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       05 WS-CTA                     PIC  9(008).*/
                public IntBasis WS_CTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    03 WS-CTA-CORRENTEV              REDEFINES       WS-CTA-CORRENTE-VR            PIC 9(011).*/
            }
            private _REDEF_IntBasis _ws_cta_correntev { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTEV
            {
                get { _ws_cta_correntev = new _REDEF_IntBasis(new PIC("9", "011", "9(011).")); ; _.Move(WS_CTA_CORRENTE_VR, _ws_cta_correntev); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_VR, _ws_cta_correntev, WS_CTA_CORRENTE_VR); _ws_cta_correntev.ValueChanged += () => { _.Move(_ws_cta_correntev, WS_CTA_CORRENTE_VR); }; return _ws_cta_correntev; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_correntev, WS_CTA_CORRENTE_VR); }
            }  //Redefines
            /*"    03 WS-ENCONTROU                  PIC  X(001) VALUE 'S'.*/

            public SelectorBasis WS_ENCONTROU { get; set; } = new SelectorBasis("001", "S")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU                  VALUE 'S'. */
							new SelectorItemBasis("ENCONTROU", "S"),
							/*" 88 NAO-ENCONTROU              VALUE 'N'. */
							new SelectorItemBasis("NAO_ENCONTROU", "N")
                }
            };

            /*"    03 WS-LEITUA-SIVPF               PIC  X(001) VALUE 'N'.*/

            public SelectorBasis WS_LEITUA_SIVPF { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 LEU-SIVPF                  VALUE 'S'. */
							new SelectorItemBasis("LEU_SIVPF", "S"),
							/*" 88 NAO-LEU-SIVPF              VALUE 'N'. */
							new SelectorItemBasis("NAO_LEU_SIVPF", "N")
                }
            };

            /*"    03 WS-ACESSO-CLIENTE             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis WS_ACESSO_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ACESSO-CLIENTE-OK                       VALUE 1. */
							new SelectorItemBasis("ACESSO_CLIENTE_OK", "1"),
							/*" 88 ACESSO-CLIENTE-ER                       VALUE 2. */
							new SelectorItemBasis("ACESSO_CLIENTE_ER", "2")
                }
            };

            /*"    03  W-RCAPS                      PIC 9(001).*/

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                       VALUE 01. */
							new SelectorItemBasis("RCAP_CADASTRADO", "01")
                }
            };

            /*"    03  W-RCAP-COMP                  PIC 9(001).*/

            public SelectorBasis W_RCAP_COMP { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-COMP-CADASTRADO                  VALUE 01. */
							new SelectorItemBasis("RCAP_COMP_CADASTRADO", "01")
                }
            };

            /*"    03 UPDATE-SIVPF-SIVPF            PIC  9(006) VALUE  0.*/
            public IntBasis UPDATE_SIVPF_SIVPF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-LIDOS                      PIC  9(006) VALUE  0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-ALTERACOES                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_ALTERACOES { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-FOLHETOS                   PIC  9(006) VALUE  ZEROS.*/
            public IntBasis AC_FOLHETOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  W-NUMR-TITULO                PIC  9(013)   VALUE ZEROS.*/
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03  FILLER                       REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VA3118B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VA3118B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VA3118B_FILLER_7(); _.Move(W_NUMR_TITULO, _filler_7); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_7, W_NUMR_TITULO); _filler_7.ValueChanged += () => { _.Move(_filler_7, W_NUMR_TITULO); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VA3118B_FILLER_7 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03              DPARM01X.*/

                public _REDEF_VA3118B_FILLER_7()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VA3118B_DPARM01X DPARM01X { get; set; } = new VA3118B_DPARM01X();
            public class VA3118B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VA3118B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VA3118B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VA3118B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VA3118B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1        PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2        PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3        PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4        PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5        PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6        PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7        PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8        PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9        PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10       PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      05            DPARM01-D1       PIC  9(001).*/

                    public _REDEF_VA3118B_DPARM01_R()
                    {
                        DPARM01_1.ValueChanged += OnValueChanged;
                        DPARM01_2.ValueChanged += OnValueChanged;
                        DPARM01_3.ValueChanged += OnValueChanged;
                        DPARM01_4.ValueChanged += OnValueChanged;
                        DPARM01_5.ValueChanged += OnValueChanged;
                        DPARM01_6.ValueChanged += OnValueChanged;
                        DPARM01_7.ValueChanged += OnValueChanged;
                        DPARM01_8.ValueChanged += OnValueChanged;
                        DPARM01_9.ValueChanged += OnValueChanged;
                        DPARM01_10.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05            DPARM01-RC       PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    03 PARM-PROSOMU1.*/
            }
            public VA3118B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA3118B_PARM_PROSOMU1();
            public class VA3118B_PARM_PROSOMU1 : VarBasis
            {
                /*"      05 SU1-DATA1.*/
                public VA3118B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA3118B_SU1_DATA1();
                public class VA3118B_SU1_DATA1 : VarBasis
                {
                    /*"        10 SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"      05 SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"      05 SU1-DATA2.*/
                public VA3118B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA3118B_SU1_DATA2();
                public class VA3118B_SU1_DATA2 : VarBasis
                {
                    /*"        10 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"01  WABEND*/
                }
            }
        }
        public VA3118B_WABEND WABEND { get; set; } = new VA3118B_WABEND();
        public class VA3118B_WABEND : VarBasis
        {
            /*"      05      FILLER.*/
            public VA3118B_FILLER_8 FILLER_8 { get; set; } = new VA3118B_FILLER_8();
            public class VA3118B_FILLER_8 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(010) VALUE              'VA3118B  '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA3118B  ");
                /*"        10    FILLER                   PIC  X(028) VALUE              ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"        10    FILLER                   PIC  X(014) VALUE              '    SQLCODE = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"        10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"        10    FILLER                   PIC  X(014)   VALUE              '   SQLERRD1 = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"        10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"        10    FILLER                   PIC  X(014)   VALUE              '   SQLERRD2 = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"        10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"        10    FILLER                   PIC  X(014)   VALUE              '   SQLERRD2 = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      05      LOCALIZA-ABEND-1.*/
            }
            public VA3118B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA3118B_LOCALIZA_ABEND_1();
            public class VA3118B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10    PARAGRAFO                PIC  X(040)   VALUE SPACES      05      LOCALIZA-ABEND-2.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"        10    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10    COMANDO                  PIC  X(060)   VALUE SPACES*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public VA3118B_CPROPVA CPROPVA { get; set; } = new VA3118B_CPROPVA();
        public VA3118B_CURSOR01 CURSOR01 { get; set; } = new VA3118B_CURSOR01();
        public VA3118B_CURSOR02 CURSOR02 { get; set; } = new VA3118B_CURSOR02();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -588- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -591- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -594- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -597- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -598- DISPLAY '          PROGRAMA EM EXECUCAO VA3118B             ' */
            _.Display($"          PROGRAMA EM EXECUCAO VA3118B             ");

            /*" -599- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -600- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -602- DISPLAY 'VERSAO V.06: ' FUNCTION WHEN-COMPILED ' - 402.982' */

            $"VERSAO V.06: FUNCTION{_.WhenCompiled()} - 402.982"
            .Display();

            /*" -603- DISPLAY ' ' */
            _.Display($" ");

            /*" -610- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -611- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -618- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -619- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -621- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -635- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -640- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -642- MOVE 'DECLARE TOPOPVA' TO COMANDO. */
            _.Move("DECLARE TOPOPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -706- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -709- DISPLAY '*** VA3118B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VA3118B *** ABRINDO CURSOR ...");

            /*" -710- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -710- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -713- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -715- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -717- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -718- DISPLAY '*** VA3118B *** PROCESSANDO ...' . */
            _.Display($"*** VA3118B *** PROCESSANDO ...");

            /*" -719- PERFORM M-0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -635- EXEC SQL SELECT DTMOVABE, CURRENT DATE, CURRENT DATE + 8 DAYS, CURRENT DATE + 1 MONTH, CURRENT DATE - 15 DAYS INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRDATE, :SISTEMA-DTMOVABE2, :SISTEMA-DTMOVABE3, :SISTEMA-DTMOVABE-15 FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRDATE, SISTEMA_CURRDATE);
                _.Move(executed_1.SISTEMA_DTMOVABE2, SISTEMA_DTMOVABE2);
                _.Move(executed_1.SISTEMA_DTMOVABE3, SISTEMA_DTMOVABE3);
                _.Move(executed_1.SISTEMA_DTMOVABE_15, SISTEMA_DTMOVABE_15);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -706- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NUM_APOLICE, CODSUBES, NRCERTIF, CODPRODU, CODCLIEN, OCOREND, FONTE, AGECOBR, OPCAO_COBER, DTQITBCO, DTQITBCO + 6 MONTHS, DTQITBCO + 1 MONTH, DTPROXVEN, DTQITBCO + 30 DAYS, NRMATRVEN, CODOPER, DTMOVTO, SITUACAO, NUM_APOLICE, CODSUBES, OCORHIST, NRPARCE, SIT_INTERFACE, TIMESTAMP, IDADE, IDE_SEXO, ESTADO_CIVIL, COD_CRM, NUM_MATRICULA, DATA_ADMISSAO, NRPROPOS, COD_CCT, CODUSU, DTVENCTO, FAIXA_RENDA_IND, DATE(TIMESTAMP), VALUE(DPS_TITULAR, '       ' ) FROM SEGUROS.V0PROPOSTAVA A WHERE A.SITUACAO IN ( '1' , '9' ) AND A.DTQITBCO > '2007-01-15' AND A.NRCERTIF NOT IN (84677241829, 84547054344, 84690719095, 84547054344, 84691024538, 84547054344, 10022577049, 10023181831, 84500413070, 84507108249, 84628255846, 84628255854, 57391776129896, 10759460000143, 84691591092) FOR UPDATE OF SITUACAO , CODUSU END-EXEC. */
            CPROPVA = new VA3118B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							NRCERTIF
							, 
							CODPRODU
							, 
							CODCLIEN
							, 
							OCOREND
							, 
							FONTE
							, 
							AGECOBR
							, 
							OPCAO_COBER
							, 
							DTQITBCO
							, 
							DTQITBCO + 6 MONTHS
							, 
							DTQITBCO + 1 MONTH
							, 
							DTPROXVEN
							, 
							DTQITBCO + 30 DAYS
							, 
							NRMATRVEN
							, 
							CODOPER
							, 
							DTMOVTO
							, 
							SITUACAO
							, 
							NUM_APOLICE
							, 
							CODSUBES
							, 
							OCORHIST
							, 
							NRPARCE
							, 
							SIT_INTERFACE
							, 
							TIMESTAMP
							, 
							IDADE
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							COD_CRM
							, 
							NUM_MATRICULA
							, 
							DATA_ADMISSAO
							, 
							NRPROPOS
							, 
							COD_CCT
							, 
							CODUSU
							, 
							DTVENCTO
							, 
							FAIXA_RENDA_IND
							, 
							DATE(TIMESTAMP)
							, 
							VALUE(DPS_TITULAR
							, ' ' ) 
							FROM SEGUROS.V0PROPOSTAVA A 
							WHERE A.SITUACAO IN ( '1'
							, '9' ) 
							AND A.DTQITBCO > '2007-01-15' 
							AND A.NRCERTIF NOT IN 
							(84677241829
							, 
							84547054344
							, 
							84690719095
							, 
							84547054344
							, 
							84691024538
							, 
							84547054344
							, 
							10022577049
							, 
							10023181831
							, 
							84500413070
							, 
							84507108249
							, 
							84628255846
							, 
							84628255854
							, 
							57391776129896
							, 
							10759460000143
							, 
							84691591092)";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -710- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-DECLARE-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_DECLARE_1()
        {
            /*" -815- EXEC SQL DECLARE CURSOR01 CURSOR FOR SELECT T1.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA T1, SEGUROS.VG_DM_MSG_CRITICA T2 WHERE T1.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND T1.COD_MSG_CRITICA NOT IN (1800, 1802, 1803, 1804, 1805, 1806, 1814, 1816, 1817) AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA AND T2.COD_TP_MSG_CRITICA <> '3' UNION ALL SELECT T1.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA T1 WHERE T1.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND SUBSTR(T1.NUM_CERTIFICADO,1,1) = 3 AND T1.COD_MSG_CRITICA = 1800 AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND T1.NUM_CERTIFICADO = (SELECT C.NUM_CERTIFICADO FROM SEGUROS.VG_COMPL_SICAQWEB C WHERE C.NUM_CERTIFICADO = T1.NUM_CERTIFICADO) END-EXEC */
            CURSOR01 = new VA3118B_CURSOR01(true);
            string GetQuery_CURSOR01()
            {
                var query = @$"SELECT T1.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA T1
							, 
							SEGUROS.VG_DM_MSG_CRITICA T2 
							WHERE T1.NUM_CERTIFICADO = '{PROPVA_NRCERTIF}' 
							AND T1.COD_MSG_CRITICA NOT IN (1800
							, 1802
							, 1803
							, 1804
							, 
							1805
							, 1806
							, 1814
							, 1816
							, 
							1817) 
							AND T1.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA 
							AND T2.COD_TP_MSG_CRITICA <> '3' 
							UNION ALL 
							SELECT T1.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA T1 
							WHERE T1.NUM_CERTIFICADO = '{PROPVA_NRCERTIF}' 
							AND SUBSTR(T1.NUM_CERTIFICADO
							,1
							,1) = 3 
							AND T1.COD_MSG_CRITICA = 1800 
							AND T1.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND T1.NUM_CERTIFICADO = 
							(SELECT C.NUM_CERTIFICADO 
							FROM SEGUROS.VG_COMPL_SICAQWEB C 
							WHERE C.NUM_CERTIFICADO = T1.NUM_CERTIFICADO)";

                return query;
            }
            CURSOR01.GetQueryEvent += GetQuery_CURSOR01;

        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -725- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -727- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -727- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0010-SOMA-DIAS */
        private void M_0010_SOMA_DIAS(bool isPerform = false)
        {
            /*" -736- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WS_WORK_AREAS.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -737- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WS_WORK_AREAS.PARM_PROSOMU1);

            /*" -737- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -750- IF PROPVA-FAIXA-RENDA-IND = '1' OR '2' OR '3' OR '4' OR '5' NEXT SENTENCE */

            if (PROPVA_FAIXA_RENDA_IND.In("1", "2", "3", "4", "5"))
            {

                /*" -751- ELSE */
            }
            else
            {


                /*" -752- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -754- END-IF. */
            }


            /*" -788- MOVE ZEROS TO WHOST-COUNT */
            _.Move(0, WHOST_COUNT);

            /*" -789- IF PROPVA-NUM-APOLICE = 109300001294 */

            if (PROPVA_NUM_APOLICE == 109300001294)
            {

                /*" -791- MOVE 'SELECT V0ERROSPROPVA 1' TO COMANDO */
                _.Move("SELECT V0ERROSPROPVA 1", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -815- PERFORM M_0100_PROCESSA_PROPOSTA_DB_DECLARE_1 */

                M_0100_PROCESSA_PROPOSTA_DB_DECLARE_1();

                /*" -817- PERFORM M_0100_PROCESSA_PROPOSTA_DB_OPEN_1 */

                M_0100_PROCESSA_PROPOSTA_DB_OPEN_1();

                /*" -821- PERFORM M_0100_PROCESSA_PROPOSTA_DB_FETCH_1 */

                M_0100_PROCESSA_PROPOSTA_DB_FETCH_1();

                /*" -823- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -824- MOVE ZEROS TO WHOST-COD-ERRO */
                    _.Move(0, WHOST_COD_ERRO);

                    /*" -826- END-IF */
                }


                /*" -826- PERFORM M_0100_PROCESSA_PROPOSTA_DB_CLOSE_1 */

                M_0100_PROCESSA_PROPOSTA_DB_CLOSE_1();

                /*" -828- ELSE */
            }
            else
            {


                /*" -853- MOVE 'SELECT V0ERROSPROPVA 2' TO COMANDO */
                _.Move("SELECT V0ERROSPROPVA 2", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -876- PERFORM M_0100_PROCESSA_PROPOSTA_DB_DECLARE_2 */

                M_0100_PROCESSA_PROPOSTA_DB_DECLARE_2();

                /*" -878- PERFORM M_0100_PROCESSA_PROPOSTA_DB_OPEN_2 */

                M_0100_PROCESSA_PROPOSTA_DB_OPEN_2();

                /*" -882- PERFORM M_0100_PROCESSA_PROPOSTA_DB_FETCH_2 */

                M_0100_PROCESSA_PROPOSTA_DB_FETCH_2();

                /*" -885- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -886- MOVE ZEROS TO WHOST-COD-ERRO */
                    _.Move(0, WHOST_COD_ERRO);

                    /*" -888- END-IF */
                }


                /*" -888- PERFORM M_0100_PROCESSA_PROPOSTA_DB_CLOSE_2 */

                M_0100_PROCESSA_PROPOSTA_DB_CLOSE_2();

                /*" -891- END-IF. */
            }


            /*" -893- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -902- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

            /*" -905- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -906- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -909- END-IF. */
            }


            /*" -911- MOVE ZEROS TO WHOST-COD-ERRO-COMUN */
            _.Move(0, WHOST_COD_ERRO_COMUN);

            /*" -918- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

            /*" -931- IF WHOST-COD-ERRO-COMUN > ZEROS */

            if (WHOST_COD_ERRO_COMUN > 00)
            {

                /*" -933- DISPLAY 'DESPREZADO - ERRO DE COMUNICACAO CRIVO ' PROPVA-NRCERTIF */
                _.Display($"DESPREZADO - ERRO DE COMUNICACAO CRIVO {PROPVA_NRCERTIF}");

                /*" -934- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -937- END-IF. */
            }


            /*" -939- MOVE 'SELECT V0ERROSPROPVA 3' TO COMANDO. */
            _.Move("SELECT V0ERROSPROPVA 3", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -949- MOVE ZEROS TO WHOST-COD-ERRO-RCAP. */
            _.Move(0, WHOST_COD_ERRO_RCAP);

            /*" -956- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

            /*" -960- IF WHOST-COD-ERRO-RCAP EQUAL ZEROS */

            if (WHOST_COD_ERRO_RCAP == 00)
            {

                /*" -962- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -963- IF WHOST-COD-ERRO-RCAP NOT EQUAL ZEROS */

            if (WHOST_COD_ERRO_RCAP != 00)
            {

                /*" -968- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

                /*" -974- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -976- DISPLAY 'SEM RCAP PRA 1501,1703,1815 - ' PROPVA-NRCERTIF ';' WHOST-COD-ERRO-RCAP */

                    $"SEM RCAP PRA 1501,1703,1815 - {PROPVA_NRCERTIF};{WHOST_COD_ERRO_RCAP}"
                    .Display();

                    /*" -977- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -979- END-IF */
                }


                /*" -981- COMPUTE WS-COBERP-VLPREMIO = COBERP-VLPREMIO / 100 * 10 */
                WS_WORK_AREAS.WS_COBERP_VLPREMIO.Value = COBERP_VLPREMIO / 100f * 10;

                /*" -983- COMPUTE WS-VLPREMIO-MAX = COBERP-VLPREMIO + WS-COBERP-VLPREMIO */
                WS_WORK_AREAS.WS_VLPREMIO_MAX.Value = COBERP_VLPREMIO + WS_WORK_AREAS.WS_COBERP_VLPREMIO;

                /*" -986- COMPUTE WS-VLPREMIO-MIN = COBERP-VLPREMIO - WS-COBERP-VLPREMIO */
                WS_WORK_AREAS.WS_VLPREMIO_MIN.Value = COBERP_VLPREMIO - WS_WORK_AREAS.WS_COBERP_VLPREMIO;

                /*" -988- IF RCAPS-VAL-RCAP GREATER WS-VLPREMIO-MAX OR RCAPS-VAL-RCAP LESS WS-VLPREMIO-MIN */

                if (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP > WS_WORK_AREAS.WS_VLPREMIO_MAX || RCAPS.DCLRCAPS.RCAPS_VAL_RCAP < WS_WORK_AREAS.WS_VLPREMIO_MIN)
                {

                    /*" -989- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -990- END-IF */
                }


                /*" -991- MOVE ZEROS TO WHOST-COD-ERRO */
                _.Move(0, WHOST_COD_ERRO);

                /*" -993- END-IF. */
            }


            /*" -1007- IF WHOST-COD-ERRO NOT EQUAL ZEROS */

            if (WHOST_COD_ERRO != 00)
            {

                /*" -1071- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -1072- IF WHOST-COD-ERRO-RCAP EQUAL ZEROS */

            if (WHOST_COD_ERRO_RCAP == 00)
            {

                /*" -1074- MOVE 'SELECT V0PARCELVA   ' TO COMANDO */
                _.Move("SELECT V0PARCELVA   ", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -1081- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

                /*" -1084- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1097- DISPLAY ' DESPREZADO PARCELA ---> ' ';' PROPVA-NRCERTIF */

                    $" DESPREZADO PARCELA ---> ;{PROPVA_NRCERTIF}"
                    .Display();

                    /*" -1098- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1099- END-IF */
                }


                /*" -1116- END-IF. */
            }


            /*" -1117- IF PROPVA-FAIXA-RENDA-IND = '1' */

            if (PROPVA_FAIXA_RENDA_IND == "1")
            {

                /*" -1130- IF COBERP-IMPMORNATU > 36000 */

                if (COBERP_IMPMORNATU > 36000)
                {

                    /*" -1132- GO TO 0100-NEXT. */

                    M_0100_NEXT(); //GOTO
                    return;
                }

            }


            /*" -1133- IF PROPVA-FAIXA-RENDA-IND = '2' */

            if (PROPVA_FAIXA_RENDA_IND == "2")
            {

                /*" -1146- IF COBERP-IMPMORNATU > 108000 */

                if (COBERP_IMPMORNATU > 108000)
                {

                    /*" -1148- GO TO 0100-NEXT. */

                    M_0100_NEXT(); //GOTO
                    return;
                }

            }


            /*" -1149- IF PROPVA-FAIXA-RENDA-IND = '3' */

            if (PROPVA_FAIXA_RENDA_IND == "3")
            {

                /*" -1162- IF COBERP-IMPMORNATU > 180000 */

                if (COBERP_IMPMORNATU > 180000)
                {

                    /*" -1164- GO TO 0100-NEXT. */

                    M_0100_NEXT(); //GOTO
                    return;
                }

            }


            /*" -1165- IF PROPVA-FAIXA-RENDA-IND = '4' OR '5' */

            if (PROPVA_FAIXA_RENDA_IND.In("4", "5"))
            {

                /*" -1178- IF COBERP-IMPMORNATU > 300000 */

                if (COBERP_IMPMORNATU > 300000)
                {

                    /*" -1180- GO TO 0100-NEXT. */

                    M_0100_NEXT(); //GOTO
                    return;
                }

            }


            /*" -1181- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1183- MOVE 'UPDATE V0PROPOSTAVA' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1188- PERFORM M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1 */

            M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1();

            /*" -1191- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1193- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1195- MOVE COBERP-IMPMORNATU TO WS-IMPMORNATU */
            _.Move(COBERP_IMPMORNATU, WS_WORK_AREAS.WS_IMPMORNATU);

            /*" -1211- MOVE COBERP-VLPREMIO TO WS-VLPREMIO */
            _.Move(COBERP_VLPREMIO, WS_WORK_AREAS.WS_VLPREMIO);

            /*" -1211- ADD 1 TO AC-ALTERACOES. */
            WS_WORK_AREAS.AC_ALTERACOES.Value = WS_WORK_AREAS.AC_ALTERACOES + 1;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-OPEN-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_OPEN_1()
        {
            /*" -817- EXEC SQL OPEN CURSOR01 END-EXEC */

            CURSOR01.Open();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-DECLARE-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_DECLARE_2()
        {
            /*" -876- EXEC SQL DECLARE CURSOR02 CURSOR FOR SELECT T1.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA T1, SEGUROS.VG_DM_MSG_CRITICA T2 WHERE T1.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND T1.COD_MSG_CRITICA NOT IN (1800, 1817) AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA AND T2.COD_TP_MSG_CRITICA <> '3' UNION ALL SELECT T1.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA T1 WHERE T1.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND SUBSTR(T1.NUM_CERTIFICADO,1,1) = 3 AND T1.COD_MSG_CRITICA = 1800 AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND T1.NUM_CERTIFICADO = (SELECT C.NUM_CERTIFICADO FROM SEGUROS.VG_COMPL_SICAQWEB C WHERE C.NUM_CERTIFICADO = T1.NUM_CERTIFICADO) WITH UR END-EXEC */
            CURSOR02 = new VA3118B_CURSOR02(true);
            string GetQuery_CURSOR02()
            {
                var query = @$"SELECT T1.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA T1
							, 
							SEGUROS.VG_DM_MSG_CRITICA T2 
							WHERE T1.NUM_CERTIFICADO = '{PROPVA_NRCERTIF}' 
							AND T1.COD_MSG_CRITICA NOT IN (1800
							, 1817) 
							AND T1.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA 
							AND T2.COD_TP_MSG_CRITICA <> '3' 
							UNION ALL 
							SELECT T1.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA T1 
							WHERE T1.NUM_CERTIFICADO = '{PROPVA_NRCERTIF}' 
							AND SUBSTR(T1.NUM_CERTIFICADO
							,1
							,1) = 3 
							AND T1.COD_MSG_CRITICA = 1800 
							AND T1.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND T1.NUM_CERTIFICADO = 
							(SELECT C.NUM_CERTIFICADO 
							FROM SEGUROS.VG_COMPL_SICAQWEB C 
							WHERE C.NUM_CERTIFICADO = T1.NUM_CERTIFICADO)";

                return query;
            }
            CURSOR02.GetQueryEvent += GetQuery_CURSOR02;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-FETCH-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_FETCH_1()
        {
            /*" -821- EXEC SQL FETCH CURSOR01 INTO :WHOST-COD-ERRO END-EXEC */

            if (CURSOR01.Fetch())
            {
                _.Move(CURSOR01.WHOST_COD_ERRO, WHOST_COD_ERRO);
            }

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-CLOSE-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_CLOSE_1()
        {
            /*" -826- EXEC SQL CLOSE CURSOR01 END-EXEC */

            CURSOR01.Close();

        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -1215- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-OPEN-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_OPEN_2()
        {
            /*" -878- EXEC SQL OPEN CURSOR02 END-EXEC */

            CURSOR02.Open();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-FETCH-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_FETCH_2()
        {
            /*" -882- EXEC SQL FETCH CURSOR02 INTO :WHOST-COD-ERRO END-EXEC */

            if (CURSOR02.Fetch())
            {
                _.Move(CURSOR02.WHOST_COD_ERRO, WHOST_COD_ERRO);
            }

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -902- EXEC SQL SELECT IMPMORNATU, VLPREMIO INTO :COBERP-IMPMORNATU, :COBERP-VLPREMIO FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_IMPMORNATU, COBERP_IMPMORNATU);
                _.Move(executed_1.COBERP_VLPREMIO, COBERP_VLPREMIO);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-CLOSE-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_CLOSE_2()
        {
            /*" -888- EXEC SQL CLOSE CURSOR02 END-EXEC */

            CURSOR02.Close();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -918- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WHOST-COD-ERRO-COMUN FROM SEGUROS.VG_CRITICA_PROPOSTA T1 WHERE T1.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND T1.COD_MSG_CRITICA = 1876 AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COD_ERRO_COMUN, WHOST_COD_ERRO_COMUN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -956- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WHOST-COD-ERRO-COMUN FROM SEGUROS.VG_CRITICA_PROPOSTA T1 WHERE T1.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND T1.COD_MSG_CRITICA IN (1501, 1703, 1815) AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COD_ERRO_COMUN, WHOST_COD_ERRO_COMUN);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-UPDATE-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1188- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '0' , CODUSU = 'VA3118B' WHERE CURRENT OF CPROPVA END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1 = new M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1(CPROPVA)
            {
            };

            M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1.Execute(m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -1226- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1228- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1267- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -1270- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1271- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1272- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -1273- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

                    /*" -1273- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -1275- GO TO 0110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;

                    /*" -1276- ELSE */
                }
                else
                {


                    /*" -1278- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1279- IF VIND-FAIXA-RENDA LESS +0 */

            if (VIND_FAIXA_RENDA < +0)
            {

                /*" -1280- MOVE ' ' TO PROPVA-FAIXA-RENDA-IND */
                _.Move(" ", PROPVA_FAIXA_RENDA_IND);

                /*" -1282- END-IF. */
            }


            /*" -1282- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -1267- EXEC SQL FETCH CPROPVA INTO :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-NRCERTIF, :PROPVA-CODPRODU, :PROPVA-CODCLIEN, :PROPVA-OCOREND, :PROPVA-FONTE, :PROPVA-AGECOBR, :PROPVA-OPCAO-COBER, :PROPVA-DTQITBCO, :PROPVA-DTINICDG, :PROPVA-DTINISAF, :PROPVA-DTPROXVEN, :PROPVA-DTMINVEN, :PROPVA-NRMATRVEN, :PROPVA-CODOPER, :PROPVA-DTMOVTO, :PROPVA-SITUACAO, :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-OCORHIST, :PROPVA-NRPARCEL, :PROPVA-SIT-INTERF, :PROPVA-TIMESTAMP, :PROPVA-IDADE, :PROPVA-SEXO, :PROPVA-EST-CIV, :PROPVA-COD-CRM:VIND-COD-CRM, :PROPVA-NRMATRFUN:PROPVA-INRMATRFUN, :PROPVA-DTADMIS:PROPVA-IDTADMIS, :PROPVA-NRPROPOS:PROPVA-INRPROPOS, :PROPVA-CODCCT:PROPVA-ICODCCT, :PROPVA-CODUSU, :PROPVA-DTVENCTO, :PROPVA-FAIXA-RENDA-IND:VIND-FAIXA-RENDA, :PROPVA-DATA, :PROPVA-DPS-TITULAR END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
                _.Move(CPROPVA.PROPVA_CODPRODU, PROPVA_CODPRODU);
                _.Move(CPROPVA.PROPVA_CODCLIEN, PROPVA_CODCLIEN);
                _.Move(CPROPVA.PROPVA_OCOREND, PROPVA_OCOREND);
                _.Move(CPROPVA.PROPVA_FONTE, PROPVA_FONTE);
                _.Move(CPROPVA.PROPVA_AGECOBR, PROPVA_AGECOBR);
                _.Move(CPROPVA.PROPVA_OPCAO_COBER, PROPVA_OPCAO_COBER);
                _.Move(CPROPVA.PROPVA_DTQITBCO, PROPVA_DTQITBCO);
                _.Move(CPROPVA.PROPVA_DTINICDG, PROPVA_DTINICDG);
                _.Move(CPROPVA.PROPVA_DTINISAF, PROPVA_DTINISAF);
                _.Move(CPROPVA.PROPVA_DTPROXVEN, PROPVA_DTPROXVEN);
                _.Move(CPROPVA.PROPVA_DTMINVEN, PROPVA_DTMINVEN);
                _.Move(CPROPVA.PROPVA_NRMATRVEN, PROPVA_NRMATRVEN);
                _.Move(CPROPVA.PROPVA_CODOPER, PROPVA_CODOPER);
                _.Move(CPROPVA.PROPVA_DTMOVTO, PROPVA_DTMOVTO);
                _.Move(CPROPVA.PROPVA_SITUACAO, PROPVA_SITUACAO);
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_OCORHIST, PROPVA_OCORHIST);
                _.Move(CPROPVA.PROPVA_NRPARCEL, PROPVA_NRPARCEL);
                _.Move(CPROPVA.PROPVA_SIT_INTERF, PROPVA_SIT_INTERF);
                _.Move(CPROPVA.PROPVA_TIMESTAMP, PROPVA_TIMESTAMP);
                _.Move(CPROPVA.PROPVA_IDADE, PROPVA_IDADE);
                _.Move(CPROPVA.PROPVA_SEXO, PROPVA_SEXO);
                _.Move(CPROPVA.PROPVA_EST_CIV, PROPVA_EST_CIV);
                _.Move(CPROPVA.PROPVA_COD_CRM, PROPVA_COD_CRM);
                _.Move(CPROPVA.VIND_COD_CRM, VIND_COD_CRM);
                _.Move(CPROPVA.PROPVA_NRMATRFUN, PROPVA_NRMATRFUN);
                _.Move(CPROPVA.PROPVA_INRMATRFUN, PROPVA_INRMATRFUN);
                _.Move(CPROPVA.PROPVA_DTADMIS, PROPVA_DTADMIS);
                _.Move(CPROPVA.PROPVA_IDTADMIS, PROPVA_IDTADMIS);
                _.Move(CPROPVA.PROPVA_NRPROPOS, PROPVA_NRPROPOS);
                _.Move(CPROPVA.PROPVA_INRPROPOS, PROPVA_INRPROPOS);
                _.Move(CPROPVA.PROPVA_CODCCT, PROPVA_CODCCT);
                _.Move(CPROPVA.PROPVA_ICODCCT, PROPVA_ICODCCT);
                _.Move(CPROPVA.PROPVA_CODUSU, PROPVA_CODUSU);
                _.Move(CPROPVA.PROPVA_DTVENCTO, PROPVA_DTVENCTO);
                _.Move(CPROPVA.PROPVA_FAIXA_RENDA_IND, PROPVA_FAIXA_RENDA_IND);
                _.Move(CPROPVA.VIND_FAIXA_RENDA, VIND_FAIXA_RENDA);
                _.Move(CPROPVA.PROPVA_DATA, PROPVA_DATA);
                _.Move(CPROPVA.PROPVA_DPS_TITULAR, PROPVA_DPS_TITULAR);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -1273- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -968- EXEC SQL SELECT VAL_RCAP INTO :RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -1081- EXEC SQL SELECT PRMVG INTO :COBERP-VLPREMIO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_VLPREMIO, COBERP_VLPREMIO);
            }


        }

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -1293- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1294- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1294- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1297- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1298- DISPLAY '*** VA3118B *** TERMINO NORMAL' . */
            _.Display($"*** VA3118B *** TERMINO NORMAL");

            /*" -1299- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1300- DISPLAY 'LIDOS ..................... ' AC-LIDOS. */
            _.Display($"LIDOS ..................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1300- DISPLAY 'ALTERACOES ................ ' AC-ALTERACOES. */
            _.Display($"ALTERACOES ................ {WS_WORK_AREAS.AC_ALTERACOES}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -1311- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.FILLER_8.WSQLCODE);

            /*" -1312- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.FILLER_8.WSQLERRD1);

            /*" -1313- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.FILLER_8.WSQLERRD2);

            /*" -1314- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -1316- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1318- DISPLAY '*** VA3118B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA3118B *** ROLLBACK EM ANDAMENTO ...");

            /*" -1318- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1321- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1322- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1322- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1325- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1326- DISPLAY 'LIDOS ................ ' AC-LIDOS. */
            _.Display($"LIDOS ................ {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1327- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1328- DISPLAY 'INCLUSOES ............ ' AC-ALTERACOES. */
            _.Display($"INCLUSOES ............ {WS_WORK_AREAS.AC_ALTERACOES}");

            /*" -1330- DISPLAY ' ' */
            _.Display($" ");

            /*" -1331- DISPLAY 'CERTIFICADO... ' PROPVA-NRCERTIF. */
            _.Display($"CERTIFICADO... {PROPVA_NRCERTIF}");

            /*" -1332- DISPLAY 'PROPAUTOM..... ' FONTE-PROPAUTOM. */
            _.Display($"PROPAUTOM..... {FONTE_PROPAUTOM}");

            /*" -1333- DISPLAY 'FONTE......... ' PROPVA-FONTE. */
            _.Display($"FONTE......... {PROPVA_FONTE}");

            /*" -1334- DISPLAY 'TITULO........ ' BANCOS-NRTIT. */
            _.Display($"TITULO........ {BANCOS_NRTIT}");

            /*" -1336- DISPLAY '*** VA3118B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA3118B *** ERRO DE EXECUCAO");

            /*" -1337- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1337- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}