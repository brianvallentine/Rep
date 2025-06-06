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
using Sias.VidaAzul.DB2.VA0130B;

namespace Code
{
    public class VA0130B
    {
        public bool IsCall { get; set; }

        public VA0130B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  EFETUA AUMENTO PELO IGP-M E        *      */
        /*"      *                             FAZ REENQUADRAMENTO POR MUDANCA    *      */
        /*"      *                             DE FAIXA ETARIA                    *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0130B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  09/06/2010                         *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 00 - CAD 42.835                                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *         A L T E R A C O E S    E F E T U A D A S               *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 37 - D 575149 T 585141                                *      */
        /*"      *             - ACERTAR INSERT'S NA HIS_COBER_PROPOST  E         *      */
        /*"      *             V0COBERPROPVA                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/05/2024 - HUSNI ALI HUSNI                              *      */
        /*"      *                                            PROCURE POR V.37    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36 -DEMANDAS JUDICIAIS                                *      */
        /*"      *                                                                *      */
        /*"      *              DEVIDO A UMA ACAO JUDICIAL, NAO PERMITIR QUE      *      */
        /*"      *              O CERTIFICADO  10001759026 SEJA REENQUADRADO POR  *      */
        /*"      *              FAIXA ETARIA  DEMANDA  409681                     *      */
        /*"      *                                                                *      */
        /*"      *              DEVIDO A UMA ACAO JUDICIAL, NAO PERMITIR QUE      *      */
        /*"      *              O CERTIFICADO 10163130002363 SEJA REENQUADRADO POR*      */
        /*"      *              FAIXA   ETARIA DEMANDA  384008                    *      */
        /*"      *                                                                *      */
        /*"      *              DEVIDO A UMA ACAO JUDICIAL, NAO PERMITIR QUE      *      */
        /*"      *              O CERTIFICADO  10001756277 SEJA REENQUADRADO POR  *      */
        /*"      *              FAIXA   ETARIA DEMANDA  334889                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/05/2023 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.36         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 35 - INCIDENTE 421922                                 *      */
        /*"      *               MELHORAR OS DISPLAYS DO PROGRAMA PARA FUTURAS    *      */
        /*"      *               ANALISES DE INCIDENTES.                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/08/2022 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.35         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.34  *VERSAO 34: DEMANDA 288241 - FLAVIO BICALHO 29/10/2021           *      */
        /*"      *           ACERTO NA BUSCA DA DATA DE ANIVERSARIO DOS           *      */
        /*"      *           CERTIFICADOS UTILIZADO NO CURSOR PRINCIPAL           *      */
        /*"      *           - PROCURAR POR V.34                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.33  *VERSAO V.33-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV132#*VERSAO 32: JV1 DEMANDA 262179 - KINKAS 28/10/2020               *      */
        /*"JV132#*           TROCA REFERENCIAS PRODUTOS JV1 POR JVPRDXXXX         *      */
        /*"JV132#*           - PROCURAR POR JV132                                 *      */
        /*"JV132#*----------------------------------------------------------------*      */
        /*"JV131 *VERSAO 31: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV131 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV131 *           - PROCURAR POR JV131                                 *      */
        /*"JV131 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 30 - INCIDENTE 239573                                 *      */
        /*"      *               ABEND SYSTEM COMPLETION CODE=0C7                 *      */
        /*"      *               AJUSTE VALIDACAO PREMIOS VG/AP ZERADOS.          *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/04/2020 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.30         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 29 - HISTORIA  212238                                 *      */
        /*"      *               REVISAO GERAL - PGM ESTAVA DEIXANDO CERTIFICADOS *      */
        /*"      *               SEM EFETUAR A CORRECAO MONETARIA.                *      */
        /*"      *               AJUSTES NO CURSOR CPROPVA.                       *      */
        /*"      *               AJUSTES DAS DATA VIGENCIAS DA HIS_COBER_PROPOST. *      */
        /*"      *               INCLUSAO DE NOVOS RELATORIOS.                    *      */
        /*"      *               TOTAL LIDOS = CORRIGIDOS + DESPREZADOS           *      */
        /*"      *               OBS. TODOS OS CERTIFICADOS PENDENTES DE CORRECAO,*      */
        /*"      *                    INCLUSIVE ANOS ANTERIORES,FORAM REGULARIZA- *      */
        /*"      *                    EM NOV/2019 PELO VA0130Z.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/09/2019 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 28 - INCIDENTE 217477                                 *      */
        /*"      *               OCORRENCIA DE FALHA N� 177438                    *      */
        /*"      *               ABEND -305 NO 'SELECT V0SEGURAVG 1'              *      */
        /*"      *               DESABILITADO ACESSO AO CAMPO DATA_ADMISSAO POR   *      */
        /*"      *               NAO SER UTILIZADO.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/09/2019 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 27 - DEMANDA 204638                                   *      */
        /*"      *             - AJUSTAR A CORRECAO DE IGPM PARA OS CASOS EM QUE  *      */
        /*"      *               HOUVE MIGRACAO, POIS NA APOLICE_COBERTURA ESTAVA *      */
        /*"      *               FICANDO O VALOR DO PREMIO DO SEGURO ANUAL, MESMO *      */
        /*"      *               APOS A MIGRACAO PARA MENSAL.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/07/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.27         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26 -  ADAILTON DIAS                                   *      */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 05/02/2019 - ATOS BR                                      *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   DEMAIS HISTORICOS - VIDE FINAL DO PROGRAMA                          */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _VAMOVTO { get; set; } = new FileBasis(new PIC("X", "180", "X(180)"));

        public FileBasis VAMOVTO
        {
            get
            {
                _.Move(REG_VAMOVTO, _VAMOVTO); VarBasis.RedefinePassValue(REG_VAMOVTO, _VAMOVTO, REG_VAMOVTO); return _VAMOVTO;
            }
        }
        public FileBasis _MOVCORR { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis MOVCORR
        {
            get
            {
                _.Move(REG_MOVCORR, _MOVCORR); VarBasis.RedefinePassValue(REG_MOVCORR, _MOVCORR, REG_MOVCORR); return _MOVCORR;
            }
        }
        public FileBasis _MOVDESP { get; set; } = new FileBasis(new PIC("X", "180", "X(180)"));

        public FileBasis MOVDESP
        {
            get
            {
                _.Move(REG_MOVDESP, _MOVDESP); VarBasis.RedefinePassValue(REG_MOVDESP, _MOVDESP, REG_MOVDESP); return _MOVDESP;
            }
        }
        /*"01  REG-VAMOVTO                      PIC  X(180).*/
        public StringBasis REG_VAMOVTO { get; set; } = new StringBasis(new PIC("X", "180", "X(180)."), @"");
        /*"01  REG-MOVCORR                      PIC  X(250).*/
        public StringBasis REG_MOVCORR { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01  REG-MOVDESP                      PIC  X(180).*/
        public StringBasis REG_MOVDESP { get; set; } = new StringBasis(new PIC("X", "180", "X(180)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  SOCORR-HISTORICO                 PIC S9(04)     COMP.*/
        public IntBasis SOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-FLAG-ERRO                     PIC  X(01).*/
        public StringBasis WS_FLAG_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  FLAG-IGPM                        PIC  X(01).*/
        public StringBasis FLAG_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  WS-SEM-IGPM                      PIC  9(01).*/
        public IntBasis WS_SEM_IGPM { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
        /*"01  WS-VALOR1-A.*/
        public VA0130B_WS_VALOR1_A WS_VALOR1_A { get; set; } = new VA0130B_WS_VALOR1_A();
        public class VA0130B_WS_VALOR1_A : VarBasis
        {
            /*"    03  WS-VALOR1N                   PIC ZZZZ.ZZ9,99.*/
            public DoubleBasis WS_VALOR1N { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
            /*"01  WS-VALOR2-A.*/
        }
        public VA0130B_WS_VALOR2_A WS_VALOR2_A { get; set; } = new VA0130B_WS_VALOR2_A();
        public class VA0130B_WS_VALOR2_A : VarBasis
        {
            /*"    03  WS-VALOR2N                   PIC ZZZZ.ZZ9,99.*/
            public DoubleBasis WS_VALOR2N { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
            /*"01  VALOR-AP                         PIC S9(13)V99  COMP-3.*/
        }
        public DoubleBasis VALOR_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  INDAGE                           PIC S9(04)     COMP.*/
        public IntBasis INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  INDOPR                           PIC S9(04)     COMP.*/
        public IntBasis INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  INDNUM                           PIC S9(04)     COMP.*/
        public IntBasis INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  INDDIG                           PIC S9(04)     COMP.*/
        public IntBasis INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-CDG                     PIC S9(04)     COMP.*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-SAF                     PIC S9(04)     COMP.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-IGPM                    PIC S9(04)     COMP.*/
        public IntBasis VIND_TEM_IGPM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-FAIXAETA                PIC S9(04)     COMP.*/
        public IntBasis VIND_TEM_FAIXAETA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PLAVAVGA-IMPSEGAUXF-I            PIC S9(04)     COMP.*/
        public IntBasis PLAVAVGA_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PLAVAVGA-VLCUSTAUXF-I            PIC S9(04)     COMP.*/
        public IntBasis PLAVAVGA_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PLAVAVGA-PRMDIT-I                PIC S9(04)     COMP.*/
        public IntBasis PLAVAVGA_PRMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PLAVAVGA-QTDIT-I                 PIC S9(04)     COMP.*/
        public IntBasis PLAVAVGA_QTDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  RESIDUO                          PIC S9(04)V99  VALUE ZEROS.*/
        public DoubleBasis RESIDUO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V99"), 2);
        /*"01  QUOCIENTE                        PIC  9(04)     VALUE ZEROS.*/
        public IntBasis QUOCIENTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  RESTO                            PIC  9(04)     VALUE ZEROS.*/
        public IntBasis RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  V0RIND-PCIOF-ATU                 PIC S9(03)V9999.*/
        public DoubleBasis V0RIND_PCIOF_ATU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999."), 4);
        /*"01  WS-ANO-NASC                      PIC  9(04)     VALUE ZEROS.*/
        public IntBasis WS_ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-ANO-ATUAL                     PIC S9(04)     COMP.*/
        public IntBasis WS_ANO_ATUAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-MES-ATUALIZACAO               PIC S9(04)     COMP.*/
        public IntBasis WS_MES_ATUALIZACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-ANO-ATUALIZACAO               PIC S9(04)     COMP.*/
        public IntBasis WS_ANO_ATUALIZACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-DIA-CONSULTA                  PIC S9(04)     COMP.*/
        public IntBasis WS_DIA_CONSULTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-ANO-MOVABERTO                 PIC S9(04)     COMP.*/
        public IntBasis WS_ANO_MOVABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-MES-MOVABERTO                 PIC S9(04)     COMP.*/
        public IntBasis WS_MES_MOVABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WTEM-REENQUADRAMENTO             PIC  X(03)     VALUE SPACES*/
        public StringBasis WTEM_REENQUADRAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01  WHOST-DATA-INCLUSAO              PIC  X(10).*/
        public StringBasis WHOST_DATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-DATA-INICIAL               PIC  X(10).*/
        public StringBasis WHOST_DATA_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-DATA-FINAL                 PIC  X(10).*/
        public StringBasis WHOST_DATA_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-IDADE                      PIC S9(04)     COMP.*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  DATA-MOVIMENTO                   PIC  X(10).*/
        public StringBasis DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COD-OPERACAO                     PIC S9(04)     COMP.*/
        public IntBasis COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WHOST-COUNT                      PIC S9(15)     COMP-3.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  WHOST-TXAPIP                     PIC S9(03)V9(4) COMP-3.*/
        public DoubleBasis WHOST_TXAPIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01  PROPVA-NRCERTIF                  PIC S9(15)     COMP-3.*/
        public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-NRPROPAZ                  PIC S9(13)     COMP-3.*/
        public IntBasis PROPVA_NRPROPAZ { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODCLIEN                  PIC S9(09)     COMP.*/
        public IntBasis PROPVA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROPVA-OCOREND                   PIC S9(04)     COMP.*/
        public IntBasis PROPVA_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-CODPRODU                  PIC S9(04)     COMP.*/
        public IntBasis PROPVA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-FONTE                     PIC S9(04)     COMP.*/
        public IntBasis PROPVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-AGECOBR                   PIC S9(04)     COMP.*/
        public IntBasis PROPVA_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-OPCAO-COBER               PIC  X(01).*/
        public StringBasis PROPVA_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PROPVA-STA-ANTECIPACAO           PIC  X(01).*/
        public StringBasis PROPVA_STA_ANTECIPACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PROPVA-STA-MUDANCA-PLANO         PIC  X(01).*/
        public StringBasis PROPVA_STA_MUDANCA_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PROPVA-DTPROXVEN                 PIC  X(10).*/
        public StringBasis PROPVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTPROXVEN-1               PIC  X(10).*/
        public StringBasis PROPVA_DTPROXVEN_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-NRPARCEL                  PIC S9(04)     COMP.*/
        public IntBasis PROPVA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-CODOPER                   PIC S9(04)     COMP.*/
        public IntBasis PROPVA_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-DTMOVTO                   PIC  X(10).*/
        public StringBasis PROPVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-NUM-APOLICE               PIC S9(13)     COMP-3.*/
        public IntBasis PROPVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODSUBES                  PIC S9(04)     COMP.*/
        public IntBasis PROPVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-OCORHIST                  PIC S9(04)     COMP.*/
        public IntBasis PROPVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-SIT-INTERF                PIC  X(01).*/
        public StringBasis PROPVA_SIT_INTERF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PROPVA-TIMESTAMP                 PIC  X(26).*/
        public StringBasis PROPVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01  PROPVA-SEXO                      PIC  X(01).*/
        public StringBasis PROPVA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PROPVA-EST-CIV                   PIC  X(01).*/
        public StringBasis PROPVA_EST_CIV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PROPVA-DTQITBCO-1YEAR            PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTQITBCO                  PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-IDADE                     PIC S9(04)     COMP.*/
        public IntBasis PROPVA_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-TEM-ANTECIP               PIC  X(01).*/
        public StringBasis PROPVA_TEM_ANTECIP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  OPCAOP-PERIPGTO                  PIC S9(04)     COMP.*/
        public IntBasis OPCAOP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  OPCAOP-AGECTADEB                 PIC S9(04)     COMP.*/
        public IntBasis OPCAOP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  OPCAOP-OPRCTADEB                 PIC S9(04)     COMP.*/
        public IntBasis OPCAOP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  OPCAOP-NUMCTADEB                 PIC S9(13)     COMP-3.*/
        public IntBasis OPCAOP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  OPCAOP-DIGCTADEB                 PIC S9(04)     COMP.*/
        public IntBasis OPCAOP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-NRCERTIF                  PIC S9(15)     COMP-3.*/
        public IntBasis COBERP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  COBERP-OCORHIST                  PIC S9(04)     COMP.*/
        public IntBasis COBERP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-OCORHIST-ANT              PIC S9(04)     COMP.*/
        public IntBasis COBERP_OCORHIST_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-IMPSEGUR                  PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-QUANT-VIDAS               PIC S9(09)     COMP.*/
        public IntBasis COBERP_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  COBERP-IMPSEGIND                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPSEGIND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-CODOPER                   PIC S9(04)     COMP.*/
        public IntBasis COBERP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-OPCAO-COBER               PIC  X(01).*/
        public StringBasis COBERP_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  COBERP-IMPSEGUR-ANT              PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPSEGUR_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-QUANT-VIDAS-ANT           PIC S9(09)     COMP.*/
        public IntBasis COBERP_QUANT_VIDAS_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  COBERP-IMPSEGIND-ANT             PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPSEGIND_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-OPCAO-COBER-ANT           PIC  X(01).*/
        public StringBasis COBERP_OPCAO_COBER_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  COBERP-IMPMORNATU-ANT            PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPMORNATU_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORACID-ANT            PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPMORACID_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPINVPERM-ANT            PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPINVPERM_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPAMDS-ANT               PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPAMDS_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDH-ANT                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPDH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDIT-ANT                PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPDIT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLPREMIO-ANT              PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_VLPREMIO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG-ANT                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_PRMVG_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP-ANT                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_PRMAP_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMDIT-ANT                PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_PRMDIT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORNATU-ATU            PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPMORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORACID-ATU            PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPMORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPINVPERM-ATU            PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPINVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPAMDS-ATU               PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPAMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDH-ATU                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPDH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDIT-ATU                PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPDIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLPREMIO-ATU              PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_VLPREMIO_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG-ATU                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_PRMVG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP-ATU                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_PRMAP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMDIT-ATU                PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_PRMDIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMDIT-I                  PIC S9(04)     COMP.*/
        public IntBasis COBERP_PRMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-QTTITCAP                  PIC S9(04)     COMP.*/
        public IntBasis COBERP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-VLTITCAP                  PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_VLTITCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCAP                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGCDG                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCDG                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGAUXF                PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTAUXF                PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGAUXF-I              PIC S9(04)     COMP.*/
        public IntBasis COBERP_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-VLCUSTAUXF-I              PIC S9(04)     COMP.*/
        public IntBasis COBERP_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-QTDIT                     PIC S9(13)V99  COMP-3.*/
        public DoubleBasis COBERP_QTDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-QTDIT-I                   PIC S9(04)     COMP.*/
        public IntBasis COBERP_QTDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-DTTERVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTTERVIG-ANT              PIC  X(10).*/
        public StringBasis COBERP_DTTERVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTINIVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTINIVIG-ANT              PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTINIVIG-NEW              PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG_NEW { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-CAPITAL-ANT                   PIC S9(13)V99.*/
        public DoubleBasis WS_CAPITAL_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99."), 2);
        /*"01  WS-PREMIO-ANT                    PIC S9(13)V99.*/
        public DoubleBasis WS_PREMIO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99."), 2);
        /*"01  WS-CAPITAL-ATU                   PIC S9(13)V99.*/
        public DoubleBasis WS_CAPITAL_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99."), 2);
        /*"01  WS-PREMIO-ATU                    PIC S9(13)V99.*/
        public DoubleBasis WS_PREMIO_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99."), 2);
        /*"01  WS-PREMIO-REENQ                  PIC S9(13)V99.*/
        public DoubleBasis WS_PREMIO_REENQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99."), 2);
        /*"01  WS-PRMVG-ATU                     PIC S9(13)V99.*/
        public DoubleBasis WS_PRMVG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99."), 2);
        /*"01  WS-PRMAP-ATU                     PIC S9(13)V99.*/
        public DoubleBasis WS_PRMAP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99."), 2);
        /*"01  WS-PRMDIT-ATU                    PIC S9(13)V99.*/
        public DoubleBasis WS_PRMDIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99."), 2);
        /*"01  VGHISR-NRCERTIF                  PIC S9(15)     COMP-3.*/
        public IntBasis VGHISR_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  VGHISR-NUM-RAMO                  PIC S9(04)     COMP.*/
        public IntBasis VGHISR_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISR-NUM-COBERTURA             PIC S9(04)     COMP.*/
        public IntBasis VGHISR_NUM_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISR-QTD-COBERTURA             PIC S9(04)     COMP.*/
        public IntBasis VGHISR_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISR-IMPSEGURADA               PIC S9(13)V99  COMP-3.*/
        public DoubleBasis VGHISR_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISR-CUSTO                     PIC S9(13)V99  COMP-3.*/
        public DoubleBasis VGHISR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISR-PREMIO                    PIC S9(13)V99  COMP-3.*/
        public DoubleBasis VGHISR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISR-TAXA                      PIC S9(03)V9999 COMP-3.*/
        public DoubleBasis VGHISR_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"01  VGHISA-NRCERTIF                  PIC S9(15)     COMP-3.*/
        public IntBasis VGHISA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  VGHISA-NUM-ACESSORIO             PIC S9(04)     COMP.*/
        public IntBasis VGHISA_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISA-QTD-COBERTURA             PIC S9(04)     COMP.*/
        public IntBasis VGHISA_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISA-IMPSEGURADA               PIC S9(13)V99  COMP-3.*/
        public DoubleBasis VGHISA_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISA-CUSTO                     PIC S9(13)V99  COMP-3.*/
        public DoubleBasis VGHISA_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISA-PREMIO                    PIC S9(13)V99  COMP-3.*/
        public DoubleBasis VGHISA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PRODVG-TEM-CDG                   PIC  X(01).*/
        public StringBasis PRODVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-TEM-SAF                   PIC  X(01).*/
        public StringBasis PRODVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-TEM-IGPM                  PIC  X(01).*/
        public StringBasis PRODVG_TEM_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-TEM-FAIXAETA              PIC  X(01).*/
        public StringBasis PRODVG_TEM_FAIXAETA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-COBERADIC-PREMIO          PIC  X(01).*/
        public StringBasis PRODVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-CUSTOCAP-TOTAL            PIC  X(01).*/
        public StringBasis PRODVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-RAMO                      PIC S9(04)     COMP.*/
        public IntBasis PRODVG_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-COD-PRODUTO               PIC S9(04)     COMP.*/
        public IntBasis PRODVG_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-NOME-PRODUTO              PIC  X(30).*/
        public StringBasis PRODVG_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"01  SEGURA-NUM-ITEM                  PIC S9(09)     COMP.*/
        public IntBasis SEGURA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  SEGURA-DTINIVIG                  PIC  X(10).*/
        public StringBasis SEGURA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SEGURA-SIT-REGISTRO              PIC  X(01).*/
        public StringBasis SEGURA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  SEGURA-DTNASC-I                  PIC S9(04)     COMP.*/
        public IntBasis SEGURA_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SEGURA-FAIXA                     PIC S9(04)     COMP.*/
        public IntBasis SEGURA_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SEGURA-TXVG                      PIC S9(03)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01  SEGURA-TXAPMA                    PIC S9(03)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPMA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01  SEGURA-TXAPIP                    PIC S9(03)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01  SEGURA-TXAPAMDS                  PIC S9(03)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01  SEGURA-TXAPDH                    PIC S9(03)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPDH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01  SEGURA-TXAPDIT                   PIC S9(03)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPDIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01  SEGURA-LOT-EMP-SEGURADO          PIC  X(30).*/
        public StringBasis SEGURA_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"01  SEGURA-OCORHIST                  PIC S9(04)     COMP.*/
        public IntBasis SEGURA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  MIMP-MORNATU-ATU                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis MIMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  MIMP-MORACID-ATU                 PIC S9(13)V99  COMP-3.*/
        public DoubleBasis MIMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  MPRM-VG-ATU                      PIC S9(13)V99  COMP-3.*/
        public DoubleBasis MPRM_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  MPRM-AP-ATU                      PIC S9(13)V99  COMP-3.*/
        public DoubleBasis MPRM_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  WLOT-EMP-SEGURADO                PIC S9(04)     COMP.*/
        public IntBasis WLOT_EMP_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  HISTSG-DTMOVTO-1YEAR             PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HISTSG-DTMOVTO                   PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HISTSG-DTMOVTO-1DAY              PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO_1DAY { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HISTSG-DTMOVTO-DTTERVIG          PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HISTSG-ANO-ATUALIZ               PIC S9(04)     COMP.*/
        public IntBasis HISTSG_ANO_ATUALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  HISTSG-OCORHIST                  PIC S9(04)     COMP.*/
        public IntBasis HISTSG_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  HISTSG-CODOPER                   PIC S9(04)     COMP.*/
        public IntBasis HISTSG_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAA-NUM-ACESSORIO             PIC S9(04)     COMP.*/
        public IntBasis VGPLAA_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAA-QTD-COBERTURA             PIC S9(04)     COMP.*/
        public IntBasis VGPLAA_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAA-IMPSEGURADA               PIC S9(13)V99  COMP-3.*/
        public DoubleBasis VGPLAA_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-CUSTO                     PIC S9(13)V99  COMP-3.*/
        public DoubleBasis VGPLAA_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-PREMIO                    PIC S9(13)V99  COMP-3.*/
        public DoubleBasis VGPLAA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-TAXA                      PIC S9(03)V9999 COMP-3.*/
        public DoubleBasis VGPLAA_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"01  CLIENT-DTNASC                    PIC  X(10).*/
        public StringBasis CLIENT_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC-I                  PIC S9(04)     COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FONTE-PROPAUTOM                  PIC S9(09)     COMP.*/
        public IntBasis FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  SISTEMA-DTMOVABE                 PIC  X(10).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMA-CURRENT                  PIC  X(10).*/
        public StringBasis SISTEMA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMA-DTMAXALTIGPM             PIC  X(10).*/
        public StringBasis SISTEMA_DTMAXALTIGPM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMA-ANOMAXALTIGPM            PIC S9(04)     COMP.*/
        public IntBasis SISTEMA_ANOMAXALTIGPM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SISTEMA-DTMAXALTIGPM-1           PIC  X(10).*/
        public StringBasis SISTEMA_DTMAXALTIGPM_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMA-DTMAXALTIGPM-2           PIC  X(10).*/
        public StringBasis SISTEMA_DTMAXALTIGPM_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMA-DTTERCOT                 PIC  X(10).*/
        public StringBasis SISTEMA_DTTERCOT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMA-DTINICOT                 PIC  X(10).*/
        public StringBasis SISTEMA_DTINICOT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMA-DTMOV01M                 PIC  X(10).*/
        public StringBasis SISTEMA_DTMOV01M { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMA-DTMOV20D                 PIC  X(10).*/
        public StringBasis SISTEMA_DTMOV20D { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  MNUM-CTA-CORRENTE                PIC S9(17)     COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "17", "S9(17)"));
        /*"01  MDAC-CTA-CORRENTE                PIC  X(01).*/
        public StringBasis MDAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  COTACAO-DTINIVIG                 PIC  X(10).*/
        public StringBasis COTACAO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COTACAO-VAL-VENDA                PIC S9(06)V9(09) COMP-3.*/
        public DoubleBasis COTACAO_VAL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(09)"), 9);
        /*"01  VG077-COD-MOEDA                  PIC S9(04)       COMP.*/
        public IntBasis VG077_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-WORK-AREAS.*/
        public VA0130B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA0130B_WS_WORK_AREAS();
        public class VA0130B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-PROCESSA-INDICE           PIC  X(03)  VALUE SPACES.*/
            public StringBasis WS_PROCESSA_INDICE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    03  WS-EOF                       PIC  9      VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOC                       PIC  X      VALUE SPACES.*/
            public StringBasis WS_EOC { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WFIM-VGHISRAMC               PIC  X      VALUE SPACES.*/
            public StringBasis WFIM_VGHISRAMC { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WFIM-VGHISTACE               PIC  X      VALUE SPACES.*/
            public StringBasis WFIM_VGHISTACE { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WFIM-VGPLAACES               PIC  X      VALUE SPACES.*/
            public StringBasis WFIM_VGPLAACES { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WIND-1                       PIC  9(03)  VALUE 0.*/
            public IntBasis WIND_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    03  WS-IND                       PIC  9(03)  VALUE 0.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    03  WS-IND-ACUM                  PIC S9(06)V9(09)  COMP-3                                     VALUE 0.*/
            public DoubleBasis WS_IND_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(09)"), 9);
            /*"    03  WS-IGPM-ACUM                 PIC S9(06)V9(09)  COMP-3                                     VALUE 0.*/
            public DoubleBasis WS_IGPM_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(09)"), 9);
            /*"    03  WS-IGPM-ACUM-DISPLAY1        PIC ----.--9,999999999                                     VALUE   SPACES.*/
            public DoubleBasis WS_IGPM_ACUM_DISPLAY1 { get; set; } = new DoubleBasis(new PIC("9", "7", "----.--9V999999999"), 9);
            /*"    03  WS-IGPM-ACUM-DISPLAY2        PIC ----.--9,999999999                                     VALUE   SPACES.*/
            public DoubleBasis WS_IGPM_ACUM_DISPLAY2 { get; set; } = new DoubleBasis(new PIC("9", "7", "----.--9V999999999"), 9);
            /*"    03  WS-PRMADIC                   PIC S9(13)V99     COMP-3                                     VALUE 0.*/
            public DoubleBasis WS_PRMADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  WS-GUARDA-PRMADIC            PIC S9(13)V99     COMP-3                                     VALUE 0.*/
            public DoubleBasis WS_GUARDA_PRMADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W01A0100.*/
            public VA0130B_W01A0100 W01A0100 { get; set; } = new VA0130B_W01A0100();
            public class VA0130B_W01A0100 : VarBasis
            {
                /*"        05 W01N0100                  PIC  9(01)   VALUE ZERO.*/
                public IntBasis W01N0100 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"    03  APOLICE-ANT                  PIC  9(13)                                     VALUE 9999999999999.*/
            }
            public IntBasis APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"), 9999999999999);
            /*"    03  SUBGRUPO-ANT                 PIC  9(05)                                     VALUE 99999.*/
            public IntBasis SUBGRUPO_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"), 99999);
            /*"    03  NRCERTIF-ANT                 PIC  9(15)                                     VALUE 999999999999999.*/
            public IntBasis NRCERTIF_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"), 999999999999999);
            /*"    03  TABELA-ULTIMOS-DIAS.*/
            public VA0130B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA0130B_TABELA_ULTIMOS_DIAS();
            public class VA0130B_TABELA_ULTIMOS_DIAS : VarBasis
            {
                /*"        05  FILLER                   PIC  X(024)            VALUE '312831303130313130313031'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                /*"    03  TAB-ULTIMOS-DIAS REDEFINES TABELA-ULTIMOS-DIAS.*/
            }
            private _REDEF_VA0130B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
            public _REDEF_VA0130B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
            {
                get { _tab_ultimos_dias = new _REDEF_VA0130B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
                set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
            }  //Redefines
            public class _REDEF_VA0130B_TAB_ULTIMOS_DIAS : VarBasis
            {
                /*"        05  TAB-DIA-MESES  OCCURS  12.*/
                public ListBasis<VA0130B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA0130B_TAB_DIA_MESES>(12);
                public class VA0130B_TAB_DIA_MESES : VarBasis
                {
                    /*"            10 TAB-ULT-DIA           PIC  9(002).*/
                    public IntBasis TAB_ULT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    03  W01DTSQL.*/

                    public VA0130B_TAB_DIA_MESES()
                    {
                        TAB_ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA0130B_TAB_ULTIMOS_DIAS()
                {
                    TAB_DIA_MESES.ValueChanged += OnValueChanged;
                }

            }
            public VA0130B_W01DTSQL W01DTSQL { get; set; } = new VA0130B_W01DTSQL();
            public class VA0130B_W01DTSQL : VarBasis
            {
                /*"        05  W01AASQL                 PIC  9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        05  W01T1SQL                 PIC  X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        05  W01MMSQL                 PIC  9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05  W01T2SQL                 PIC  X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        05  W01DDSQL                 PIC  9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  W02DTSQL.*/
            }
            public VA0130B_W02DTSQL W02DTSQL { get; set; } = new VA0130B_W02DTSQL();
            public class VA0130B_W02DTSQL : VarBasis
            {
                /*"        05  W02AASQL                 PIC  9(004).*/
                public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        05  W02T1SQL                 PIC  X(001).*/
                public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        05  W02MMSQL                 PIC  9(002).*/
                public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05  W02T2SQL                 PIC  X(001).*/
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        05  W02DDSQL                 PIC  9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WS-CTA-CORRENTE-R.*/
            }
            public VA0130B_WS_CTA_CORRENTE_R WS_CTA_CORRENTE_R { get; set; } = new VA0130B_WS_CTA_CORRENTE_R();
            public class VA0130B_WS_CTA_CORRENTE_R : VarBasis
            {
                /*"        05  WS-OPER-SEG              PIC  9(004).*/
                public IntBasis WS_OPER_SEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        05  WS-CTA-SEG               PIC  9(012).*/
                public IntBasis WS_CTA_SEG { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03  WS-CTA-CORRENTE              REDEFINES        WS-CTA-CORRENTE-R            PIC  9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_corrente { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTE
            {
                get { _ws_cta_corrente = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_R, _ws_cta_corrente); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_R, _ws_cta_corrente, WS_CTA_CORRENTE_R); _ws_cta_corrente.ValueChanged += () => { _.Move(_ws_cta_corrente, WS_CTA_CORRENTE_R); }; return _ws_cta_corrente; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_corrente, WS_CTA_CORRENTE_R); }
            }  //Redefines
            /*"    03       WS-DATA-INF             PIC  9(006).*/
            public IntBasis WS_DATA_INF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-INF-R REDEFINES WS-DATA-INF.*/
            private _REDEF_VA0130B_WS_DATA_INF_R _ws_data_inf_r { get; set; }
            public _REDEF_VA0130B_WS_DATA_INF_R WS_DATA_INF_R
            {
                get { _ws_data_inf_r = new _REDEF_VA0130B_WS_DATA_INF_R(); _.Move(WS_DATA_INF, _ws_data_inf_r); VarBasis.RedefinePassValue(WS_DATA_INF, _ws_data_inf_r, WS_DATA_INF); _ws_data_inf_r.ValueChanged += () => { _.Move(_ws_data_inf_r, WS_DATA_INF); }; return _ws_data_inf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_inf_r, WS_DATA_INF); }
            }  //Redefines
            public class _REDEF_VA0130B_WS_DATA_INF_R : VarBasis
            {
                /*"      05     WS-ANO-INF              PIC  9(004).*/
                public IntBasis WS_ANO_INF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-INF              PIC  9(002).*/
                public IntBasis WS_MES_INF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-SUP             PIC  9(006).*/

                public _REDEF_VA0130B_WS_DATA_INF_R()
                {
                    WS_ANO_INF.ValueChanged += OnValueChanged;
                    WS_MES_INF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_SUP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-SUP-R REDEFINES WS-DATA-SUP.*/
            private _REDEF_VA0130B_WS_DATA_SUP_R _ws_data_sup_r { get; set; }
            public _REDEF_VA0130B_WS_DATA_SUP_R WS_DATA_SUP_R
            {
                get { _ws_data_sup_r = new _REDEF_VA0130B_WS_DATA_SUP_R(); _.Move(WS_DATA_SUP, _ws_data_sup_r); VarBasis.RedefinePassValue(WS_DATA_SUP, _ws_data_sup_r, WS_DATA_SUP); _ws_data_sup_r.ValueChanged += () => { _.Move(_ws_data_sup_r, WS_DATA_SUP); }; return _ws_data_sup_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_sup_r, WS_DATA_SUP); }
            }  //Redefines
            public class _REDEF_VA0130B_WS_DATA_SUP_R : VarBasis
            {
                /*"      05     WS-ANO-SUP              PIC  9(004).*/
                public IntBasis WS_ANO_SUP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-SUP              PIC  9(002).*/
                public IntBasis WS_MES_SUP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WDATA1                  PIC  9(006).*/

                public _REDEF_VA0130B_WS_DATA_SUP_R()
                {
                    WS_ANO_SUP.ValueChanged += OnValueChanged;
                    WS_MES_SUP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WDATA1-R REDEFINES WDATA1.*/
            private _REDEF_VA0130B_WDATA1_R _wdata1_r { get; set; }
            public _REDEF_VA0130B_WDATA1_R WDATA1_R
            {
                get { _wdata1_r = new _REDEF_VA0130B_WDATA1_R(); _.Move(WDATA1, _wdata1_r); VarBasis.RedefinePassValue(WDATA1, _wdata1_r, WDATA1); _wdata1_r.ValueChanged += () => { _.Move(_wdata1_r, WDATA1); }; return _wdata1_r; }
                set { VarBasis.RedefinePassValue(value, _wdata1_r, WDATA1); }
            }  //Redefines
            public class _REDEF_VA0130B_WDATA1_R : VarBasis
            {
                /*"      05     WDATA1-AA               PIC  9(004).*/
                public IntBasis WDATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WDATA1-MM               PIC  9(002).*/
                public IntBasis WDATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WDTINIVIG               PIC  9(006).*/

                public _REDEF_VA0130B_WDATA1_R()
                {
                    WDATA1_AA.ValueChanged += OnValueChanged;
                    WDATA1_MM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDTINIVIG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WDTINIVIG-R REDEFINES WDTINIVIG.*/
            private _REDEF_VA0130B_WDTINIVIG_R _wdtinivig_r { get; set; }
            public _REDEF_VA0130B_WDTINIVIG_R WDTINIVIG_R
            {
                get { _wdtinivig_r = new _REDEF_VA0130B_WDTINIVIG_R(); _.Move(WDTINIVIG, _wdtinivig_r); VarBasis.RedefinePassValue(WDTINIVIG, _wdtinivig_r, WDTINIVIG); _wdtinivig_r.ValueChanged += () => { _.Move(_wdtinivig_r, WDTINIVIG); }; return _wdtinivig_r; }
                set { VarBasis.RedefinePassValue(value, _wdtinivig_r, WDTINIVIG); }
            }  //Redefines
            public class _REDEF_VA0130B_WDTINIVIG_R : VarBasis
            {
                /*"      05     WAAINIVIG               PIC  9(004).*/
                public IntBasis WAAINIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WMMINIVIG               PIC  9(002).*/
                public IntBasis WMMINIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-MAX             PIC  9(006).*/

                public _REDEF_VA0130B_WDTINIVIG_R()
                {
                    WAAINIVIG.ValueChanged += OnValueChanged;
                    WMMINIVIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_MAX { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-MAX-R REDEFINES WS-DATA-MAX.*/
            private _REDEF_VA0130B_WS_DATA_MAX_R _ws_data_max_r { get; set; }
            public _REDEF_VA0130B_WS_DATA_MAX_R WS_DATA_MAX_R
            {
                get { _ws_data_max_r = new _REDEF_VA0130B_WS_DATA_MAX_R(); _.Move(WS_DATA_MAX, _ws_data_max_r); VarBasis.RedefinePassValue(WS_DATA_MAX, _ws_data_max_r, WS_DATA_MAX); _ws_data_max_r.ValueChanged += () => { _.Move(_ws_data_max_r, WS_DATA_MAX); }; return _ws_data_max_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_max_r, WS_DATA_MAX); }
            }  //Redefines
            public class _REDEF_VA0130B_WS_DATA_MAX_R : VarBasis
            {
                /*"      05     WS-ANO-MAX              PIC  9(004).*/
                public IntBasis WS_ANO_MAX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-MAX              PIC  9(002).*/
                public IntBasis WS_MES_MAX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-MIN             PIC  9(006).*/

                public _REDEF_VA0130B_WS_DATA_MAX_R()
                {
                    WS_ANO_MAX.ValueChanged += OnValueChanged;
                    WS_MES_MAX.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_MIN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-MIN-R REDEFINES WS-DATA-MIN.*/
            private _REDEF_VA0130B_WS_DATA_MIN_R _ws_data_min_r { get; set; }
            public _REDEF_VA0130B_WS_DATA_MIN_R WS_DATA_MIN_R
            {
                get { _ws_data_min_r = new _REDEF_VA0130B_WS_DATA_MIN_R(); _.Move(WS_DATA_MIN, _ws_data_min_r); VarBasis.RedefinePassValue(WS_DATA_MIN, _ws_data_min_r, WS_DATA_MIN); _ws_data_min_r.ValueChanged += () => { _.Move(_ws_data_min_r, WS_DATA_MIN); }; return _ws_data_min_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_min_r, WS_DATA_MIN); }
            }  //Redefines
            public class _REDEF_VA0130B_WS_DATA_MIN_R : VarBasis
            {
                /*"      05     WS-ANO-MIN              PIC  9(004).*/
                public IntBasis WS_ANO_MIN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-MIN              PIC  9(002).*/
                public IntBasis WS_MES_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       TABELA-IGPM.*/

                public _REDEF_VA0130B_WS_DATA_MIN_R()
                {
                    WS_ANO_MIN.ValueChanged += OnValueChanged;
                    WS_MES_MIN.ValueChanged += OnValueChanged;
                }

            }
            public VA0130B_TABELA_IGPM TABELA_IGPM { get; set; } = new VA0130B_TABELA_IGPM();
            public class VA0130B_TABELA_IGPM : VarBasis
            {
                /*"      05     FILLER            OCCURS 300 TIMES.*/
                public ListBasis<VA0130B_FILLER_1> FILLER_1 { get; set; } = new ListBasis<VA0130B_FILLER_1>(300);
                public class VA0130B_FILLER_1 : VarBasis
                {
                    /*"        10   TB-DATA-IGPM      PIC  9(006).*/
                    public IntBasis TB_DATA_IGPM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"        10   TB-DATA-IGPM-R REDEFINES TB-DATA-IGPM.*/
                    private _REDEF_VA0130B_TB_DATA_IGPM_R _tb_data_igpm_r { get; set; }
                    public _REDEF_VA0130B_TB_DATA_IGPM_R TB_DATA_IGPM_R
                    {
                        get { _tb_data_igpm_r = new _REDEF_VA0130B_TB_DATA_IGPM_R(); _.Move(TB_DATA_IGPM, _tb_data_igpm_r); VarBasis.RedefinePassValue(TB_DATA_IGPM, _tb_data_igpm_r, TB_DATA_IGPM); _tb_data_igpm_r.ValueChanged += () => { _.Move(_tb_data_igpm_r, TB_DATA_IGPM); }; return _tb_data_igpm_r; }
                        set { VarBasis.RedefinePassValue(value, _tb_data_igpm_r, TB_DATA_IGPM); }
                    }  //Redefines
                    public class _REDEF_VA0130B_TB_DATA_IGPM_R : VarBasis
                    {
                        /*"          15 TB-ANO-IGPM       PIC  9(004).*/
                        public IntBasis TB_ANO_IGPM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"          15 TB-MES-IGPM       PIC  9(002).*/
                        public IntBasis TB_MES_IGPM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        10   TB-VAL-IGPM       PIC S9(006)V9(9)  COMP-3.*/

                        public _REDEF_VA0130B_TB_DATA_IGPM_R()
                        {
                            TB_ANO_IGPM.ValueChanged += OnValueChanged;
                            TB_MES_IGPM.ValueChanged += OnValueChanged;
                        }

                    }
                    public DoubleBasis TB_VAL_IGPM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
                    /*"    03 AC-LIDOS                      PIC  9(006) VALUE  0.*/
                }
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-LIDOS-2                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_LIDOS_2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-REENQUAD                   PIC  9(006) VALUE  0.*/
            public IntBasis AC_REENQUAD { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-IGPM                       PIC  9(006) VALUE  0.*/
            public IntBasis AC_IGPM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-IGPM-1                     PIC  9(006) VALUE  0.*/
            public IntBasis AC_IGPM_1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-IGPM-2                     PIC  9(006) VALUE  0.*/
            public IntBasis AC_IGPM_2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 WS-ERRO-COBER                 PIC  9(006) VALUE  0.*/
            public IntBasis WS_ERRO_COBER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-ERRO-DADOS                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_ERRO_DADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-ERRO-SISTEMA               PIC  9(006) VALUE  0.*/
            public IntBasis AC_ERRO_SISTEMA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-NOT-NIVER             PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_NOT_NIVER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-JA-ATUAL              PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_JA_ATUAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-ATUAL-1               PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_ATUAL_1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-ATUAL-2               PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_ATUAL_2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-PRODUTO               PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_PRODUTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-ANTECIP-2                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_ANTECIP_2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-PROXVEN-FORA               PIC  9(006) VALUE  0.*/
            public IntBasis AC_PROXVEN_FORA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-TOTAL                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_TOTAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-MOVSELE                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_MOVSELE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-SEM-IGPM                   PIC  9(006) VALUE  0.*/
            public IntBasis AC_SEM_IGPM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-MOVDESP                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_MOVDESP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-NAO-MIGRADO                PIC  9(006) VALUE  0.*/
            public IntBasis AC_NAO_MIGRADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01  WS-REGISTRO.*/
        }
        public VA0130B_WS_REGISTRO WS_REGISTRO { get; set; } = new VA0130B_WS_REGISTRO();
        public class VA0130B_WS_REGISTRO : VarBasis
        {
            /*"    03  RM-TEM-ANTECIP               PIC  X(01).*/
            public StringBasis RM_TEM_ANTECIP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-NUM-APOLICE               PIC  9(13).*/
            public IntBasis RM_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-CODSUBES                  PIC  9(05).*/
            public IntBasis RM_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-NRCERTIF                  PIC  9(15).*/
            public IntBasis RM_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-CODCLIEN                  PIC  9(09).*/
            public IntBasis RM_CODCLIEN { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-OCOREND                   PIC  9(02).*/
            public IntBasis RM_OCOREND { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-FONTE                     PIC  9(02).*/
            public IntBasis RM_FONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-AGECOBR                   PIC  9(04).*/
            public IntBasis RM_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-OPCAO-COBER               PIC  X(01).*/
            public StringBasis RM_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-DTPROXVEN                 PIC  X(10).*/
            public StringBasis RM_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-DTPROXVEN-ANT             PIC  X(10).*/
            public StringBasis RM_DTPROXVEN_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-NRPARCE                   PIC  9(03).*/
            public IntBasis RM_NRPARCE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-CODOPER                   PIC  9(03).*/
            public IntBasis RM_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-DTMOVTO                   PIC  X(10).*/
            public StringBasis RM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-OCORHIST                  PIC  9(03).*/
            public IntBasis RM_OCORHIST { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-SIT-INTERFACE             PIC  X(01).*/
            public StringBasis RM_SIT_INTERFACE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-DTQITBCO-PROX             PIC  X(10).*/
            public StringBasis RM_DTQITBCO_PROX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-DTQITBCO                  PIC  X(10).*/
            public StringBasis RM_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-IDADE                     PIC  9(03).*/
            public IntBasis RM_IDADE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-CODPRODU                  PIC  9(04).*/
            public IntBasis RM_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-STA-ANTECIPACAO           PIC  X(01).*/
            public StringBasis RM_STA_ANTECIPACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-STA-MUDANCA-PLANO         PIC  X(01).*/
            public StringBasis RM_STA_MUDANCA_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-IGPM                      PIC  X(01).*/
            public StringBasis RM_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03  RM-REENQUAD                  PIC  X(01).*/
            public StringBasis RM_REENQUAD { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  FILLER                       PIC  X(34)  VALUE ' '.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @" ");
            /*"01  LD-CAB-MOVTO.*/
        }
        public VA0130B_LD_CAB_MOVTO LD_CAB_MOVTO { get; set; } = new VA0130B_LD_CAB_MOVTO();
        public class VA0130B_LD_CAB_MOVTO : VarBasis
        {
            /*"    03  FILLER                       PIC  X(46)  VALUE       'TP;APOLICE;SUBGP;NRCERTIF;CLIENTE;END;FTE;AGE;'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "46", "X(46)"), @"TP;APOLICE;SUBGP;NRCERTIF;CLIENTE;END;FTE;AGE;");
            /*"    03  FILLER                       PIC  X(43)  VALUE       'COBER;PROXVEN;PXVENANT;PARCEL;OPER;DTMOVTO;'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "43", "X(43)"), @"COBER;PROXVEN;PXVENANT;PARCEL;OPER;DTMOVTO;");
            /*"    03  FILLER                       PIC  X(37)  VALUE       'OCHST;SIT;PXDTQUIT;DTQUIT;IDADE;PROD;'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "37", "X(37)"), @"OCHST;SIT;PXDTQUIT;DTQUIT;IDADE;PROD;");
            /*"    03  FILLER                       PIC  X(33)  VALUE       'ANTECIP;MDPLAN;TEM-IGPM;TEM-FXETA'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "33", "X(33)"), @"ANTECIP;MDPLAN;TEM-IGPM;TEM-FXETA");
            /*"    03  FILLER                       PIC  X(21)  VALUE SPACES.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"");
            /*"01  LD-CAB-MOVCOR.*/
        }
        public VA0130B_LD_CAB_MOVCOR LD_CAB_MOVCOR { get; set; } = new VA0130B_LD_CAB_MOVCOR();
        public class VA0130B_LD_CAB_MOVCOR : VarBasis
        {
            /*"    03  FILLER                       PIC  X(46)  VALUE       'TP;APOLICE;SUBGP;NRCERTIF;CLIENTE;END;FTE;AGE;'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "46", "X(46)"), @"TP;APOLICE;SUBGP;NRCERTIF;CLIENTE;END;FTE;AGE;");
            /*"    03  FILLER                       PIC  X(43)  VALUE       'COBER;PROXVEN;PXVENANT;PARCEL;OPER;DTMOVTO;'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "43", "X(43)"), @"COBER;PROXVEN;PXVENANT;PARCEL;OPER;DTMOVTO;");
            /*"    03  FILLER                       PIC  X(37)  VALUE       'OCHST;SIT;PXDTQUIT;DTQUIT;IDADE;PROD;'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "37", "X(37)"), @"OCHST;SIT;PXDTQUIT;DTQUIT;IDADE;PROD;");
            /*"    03  FILLER                       PIC  X(25)  VALUE       'ANTECIP;MDPLAN;IGPM;REENQ'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"ANTECIP;MDPLAN;IGPM;REENQ");
            /*"    03  FILLER                       PIC  X(24)  VALUE       ';IDX;PERINI;PERFIM;FATOR'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @";IDX;PERINI;PERFIM;FATOR");
            /*"    03  FILLER                       PIC  X(45)  VALUE       ';CAPANT;PRMANT;CAPATU;PRMIGPM;PRMREENQ;%REENQ'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "45", "X(45)"), @";CAPANT;PRMANT;CAPATU;PRMIGPM;PRMREENQ;%REENQ");
            /*"    03  FILLER                       PIC  X(30)  VALUE SPACES.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"01  LD-CAB-MVDESP.*/
        }
        public VA0130B_LD_CAB_MVDESP LD_CAB_MVDESP { get; set; } = new VA0130B_LD_CAB_MVDESP();
        public class VA0130B_LD_CAB_MVDESP : VarBasis
        {
            /*"    03  FILLER                       PIC  X(32)  VALUE       'TP;NRCERTIF;APOLICE;SUBGP;MOTIVO'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @"TP;NRCERTIF;APOLICE;SUBGP;MOTIVO");
            /*"    03  FILLER                       PIC  X(148) VALUE SPACES.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "148", "X(148)"), @"");
            /*"01  WS-MOVDESP.*/
        }
        public VA0130B_WS_MOVDESP WS_MOVDESP { get; set; } = new VA0130B_WS_MOVDESP();
        public class VA0130B_WS_MOVDESP : VarBasis
        {
            /*"    03 RD-TEM-ANTECIP                PIC  X(01).*/
            public StringBasis RD_TEM_ANTECIP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RD-SEP-01                     PIC  X(01).*/
            public StringBasis RD_SEP_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RD-NUM-CERTIF                 PIC  9(15).*/
            public IntBasis RD_NUM_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"    03 RD-SEP-02                     PIC  X(01).*/
            public StringBasis RD_SEP_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RD-NUM-APOLICE                PIC  9(13).*/
            public IntBasis RD_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    03 RD-SEP-03                     PIC  X(01).*/
            public StringBasis RD_SEP_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RD-CODSUBES                   PIC  9(05).*/
            public IntBasis RD_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    03 RD-SEP-04                     PIC  X(01).*/
            public StringBasis RD_SEP_04 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RD-DES-MOTIVO                 PIC  X(62).*/
            public StringBasis RD_DES_MOTIVO { get; set; } = new StringBasis(new PIC("X", "62", "X(62)."), @"");
            /*"    03 FILLER                        PIC  X(80).*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"01  WS-MOVCORR.*/
        }
        public VA0130B_WS_MOVCORR WS_MOVCORR { get; set; } = new VA0130B_WS_MOVCORR();
        public class VA0130B_WS_MOVCORR : VarBasis
        {
            /*"    03 FILLER                        PIC  X(146).*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "146", "X(146)."), @"");
            /*"    03 RC-SEP-01                     PIC  X(01).*/
            public StringBasis RC_SEP_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-MOEDA                      PIC  X(04).*/
            public StringBasis RC_MOEDA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    03 RC-SEP-02                     PIC  X(01).*/
            public StringBasis RC_SEP_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-PERINI                     PIC  X(07).*/
            public StringBasis RC_PERINI { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
            /*"    03 RC-SEP-03                     PIC  X(01).*/
            public StringBasis RC_SEP_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-PERFIM                     PIC  X(07).*/
            public StringBasis RC_PERFIM { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
            /*"    03 RC-SEP-04                     PIC  X(01).*/
            public StringBasis RC_SEP_04 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-FATOR                      PIC  9,999999999.*/
            public DoubleBasis RC_FATOR { get; set; } = new DoubleBasis(new PIC("9", "1", "9V999999999."), 9);
            /*"    03 RC-SEP-05                     PIC  X(01).*/
            public StringBasis RC_SEP_05 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-CAPITAL-ANT                PIC  ZZZZZZ9,99.*/
            public DoubleBasis RC_CAPITAL_ANT { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZZZ9V99."), 2);
            /*"    03 RC-SEP-06                     PIC  X(01).*/
            public StringBasis RC_SEP_06 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-PREMIO-ANT                 PIC  ZZZZ9,99.*/
            public DoubleBasis RC_PREMIO_ANT { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZZZ9V99."), 2);
            /*"    03 RC-SEP-07                     PIC  X(01).*/
            public StringBasis RC_SEP_07 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-CAPITAL-ATU                PIC  ZZZZZZ9,99.*/
            public DoubleBasis RC_CAPITAL_ATU { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZZZ9V99."), 2);
            /*"    03 RC-SEP-08                     PIC  X(01).*/
            public StringBasis RC_SEP_08 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-PREMIO-ATU                 PIC  ZZZZ9,99.*/
            public DoubleBasis RC_PREMIO_ATU { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZZZ9V99."), 2);
            /*"    03 RC-SEP-09                     PIC  X(01).*/
            public StringBasis RC_SEP_09 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-PREMIO-REENQ               PIC  ZZZZ9,99.*/
            public DoubleBasis RC_PREMIO_REENQ { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZZZ9V99."), 2);
            /*"    03 RC-SEP-10                     PIC  X(01).*/
            public StringBasis RC_SEP_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 RC-PERC-REENQ                 PIC  ZZ9,9999.*/
            public DoubleBasis RC_PERC_REENQ { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V9999."), 4);
            /*"    03 FILLER                        PIC  X(13).*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"01  WABEND*/
        }
        public VA0130B_WABEND WABEND { get; set; } = new VA0130B_WABEND();
        public class VA0130B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public VA0130B_FILLER_43 FILLER_43 { get; set; } = new VA0130B_FILLER_43();
            public class VA0130B_FILLER_43 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0130B  '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0130B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA0130B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0130B_LOCALIZA_ABEND_1();
            public class VA0130B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0130B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0130B_LOCALIZA_ABEND_2();
            public class VA0130B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  CSP-NRCERTIF                     PIC S9(015)   COMP-3.*/
            }
        }
        public IntBasis CSP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  H-OUT-COD-RETORNO                PIC S9(004)   COMP.*/
        public IntBasis H_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  H-OUT-COD-RETORNO-SQL            PIC S9(004)   COMP.*/
        public IntBasis H_OUT_COD_RETORNO_SQL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  H-OUT-MENSAGEM                   PIC  X(060).*/
        public StringBasis H_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"01  H-OUT-SQLERRMC                   PIC  X(060).*/
        public StringBasis H_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"01  H-OUT-SQLSTATE                   PIC  X(005).*/
        public StringBasis H_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01  LK-PARAMETRO.*/
        public VA0130B_LK_PARAMETRO LK_PARAMETRO { get; set; } = new VA0130B_LK_PARAMETRO();
        public class VA0130B_LK_PARAMETRO : VarBasis
        {
            /*"    03 FILLER                        PIC  X(002).*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    03 LK-DATA-INI-PROC              PIC  X(010).*/
            public StringBasis LK_DATA_INI_PROC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        }


        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA0130B_V0COTACAO V0COTACAO { get; set; } = new VA0130B_V0COTACAO();
        public VA0130B_CPROPVA CPROPVA { get; set; } = new VA0130B_CPROPVA();
        public VA0130B_VGHISRAMC VGHISRAMC { get; set; } = new VA0130B_VGHISRAMC();
        public VA0130B_VGHISTACE VGHISTACE { get; set; } = new VA0130B_VGHISTACE();
        public VA0130B_VGPLAACES VGPLAACES { get; set; } = new VA0130B_VGPLAACES();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA0130B_LK_PARAMETRO VA0130B_LK_PARAMETRO_P, string VAMOVTO_FILE_NAME_P, string MOVCORR_FILE_NAME_P, string MOVDESP_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LK_PARAMETRO*/
        {
            try
            {
                this.LK_PARAMETRO = VA0130B_LK_PARAMETRO_P;
                VAMOVTO.SetFile(VAMOVTO_FILE_NAME_P);
                MOVCORR.SetFile(MOVCORR_FILE_NAME_P);
                MOVDESP.SetFile(MOVDESP_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAMETRO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -697- DISPLAY ' ' */
            _.Display($" ");

            /*" -699- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -706- DISPLAY 'PROGRAMA VA0130B - VERSAO V.37 - DEMANDA 585141 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VA0130B - VERSAO V.37 - DEMANDA 585141 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -708- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -709- DISPLAY ' ' */
            _.Display($" ");

            /*" -716- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -717- DISPLAY ' ' */
            _.Display($" ");

            /*" -719- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -720- IF LK-DATA-INI-PROC NOT EQUAL '0001-01-01' */

            if (LK_PARAMETRO.LK_DATA_INI_PROC != "0001-01-01")
            {

                /*" -722- DISPLAY 'DATA INICIO PROCESSAMENTO DA LINKAGE: ' LK-DATA-INI-PROC */
                _.Display($"DATA INICIO PROCESSAMENTO DA LINKAGE: {LK_PARAMETRO.LK_DATA_INI_PROC}");

                /*" -723- ELSE */
            }
            else
            {


                /*" -724- DISPLAY 'PROCESSAMENTO SEM DATA INICIO DA LINKAGE' */
                _.Display($"PROCESSAMENTO SEM DATA INICIO DA LINKAGE");

                /*" -726- END-IF. */
            }


            /*" -730- OPEN OUTPUT VAMOVTO MOVCORR MOVDESP. */
            VAMOVTO.Open(REG_VAMOVTO);
            MOVCORR.Open(REG_MOVCORR);
            MOVDESP.Open(REG_MOVDESP);

            /*" -731- WRITE REG-VAMOVTO FROM LD-CAB-MOVTO. */
            _.Move(LD_CAB_MOVTO.GetMoveValues(), REG_VAMOVTO);

            VAMOVTO.Write(REG_VAMOVTO.GetMoveValues().ToString());

            /*" -732- WRITE REG-MOVCORR FROM LD-CAB-MOVCOR. */
            _.Move(LD_CAB_MOVCOR.GetMoveValues(), REG_MOVCORR);

            MOVCORR.Write(REG_MOVCORR.GetMoveValues().ToString());

            /*" -734- WRITE REG-MOVDESP FROM LD-CAB-MVDESP. */
            _.Move(LD_CAB_MVDESP.GetMoveValues(), REG_MOVDESP);

            MOVDESP.Write(REG_MOVDESP.GetMoveValues().ToString());

            /*" -739- MOVE ZEROS TO PROPVA-NUM-APOLICE PROPVA-CODSUBES PROPVA-NRCERTIF PRODVG-COD-PRODUTO. */
            _.Move(0, PROPVA_NUM_APOLICE, PROPVA_CODSUBES, PROPVA_NRCERTIF, PRODVG_COD_PRODUTO);

            /*" -743- MOVE SPACES TO PRODVG-NOME-PRODUTO PROPVA-DTPROXVEN WS-MOVDESP. */
            _.Move("", PRODVG_NOME_PRODUTO, PROPVA_DTPROXVEN, WS_MOVDESP);

            /*" -745- PERFORM 0010-SELECT-SISTEMAS THRU 0010-FIM. */

            M_0010_SELECT_SISTEMAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/


            /*" -747- PERFORM 0050-DATA-ENCERRAMENTO THRU 0050-FIM. */

            M_0050_DATA_ENCERRAMENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0050_FIM*/


            /*" -749- PERFORM 0109-DECLARE-PROPOSTAS THRU 0109-FIM. */

            M_0109_DECLARE_PROPOSTAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0109_FIM*/


            /*" -751- PERFORM 0110-FETCH-PROPOSTAS THRU 0110-FIM. */

            M_0110_FETCH_PROPOSTAS(true);

            M_0110_CONTINUA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -754- PERFORM 0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -756- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -757- DISPLAY ' ' */
            _.Display($" ");

            /*" -758- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -765- DISPLAY 'TERMINOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"TERMINOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -767- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -767- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0010-SELECT-SISTEMAS */
        private void M_0010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -775- MOVE '0010-SELECT-SISTEMAS' TO PARAGRAFO. */
            _.Move("0010-SELECT-SISTEMAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -776- IF LK-DATA-INI-PROC NOT EQUAL '0001-01-01' */

            if (LK_PARAMETRO.LK_DATA_INI_PROC != "0001-01-01")
            {

                /*" -778- MOVE 'SELECT SISTEMAS 1' TO COMANDO */
                _.Move("SELECT SISTEMAS 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -794- PERFORM M_0010_SELECT_SISTEMAS_DB_SELECT_1 */

                M_0010_SELECT_SISTEMAS_DB_SELECT_1();

                /*" -796- ELSE */
            }
            else
            {


                /*" -797- MOVE 'SELECT SISTEMAS 2' TO COMANDO */
                _.Move("SELECT SISTEMAS 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -813- PERFORM M_0010_SELECT_SISTEMAS_DB_SELECT_2 */

                M_0010_SELECT_SISTEMAS_DB_SELECT_2();

                /*" -816- END-IF. */
            }


            /*" -817- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -818- DISPLAY 'ERRO ACESSO V0SISTEMA' */
                _.Display($"ERRO ACESSO V0SISTEMA");

                /*" -819- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -821- END-IF. */
            }


            /*" -822- MOVE SISTEMA-DTTERCOT TO W01DTSQL. */
            _.Move(SISTEMA_DTTERCOT, WS_WORK_AREAS.W01DTSQL);

            /*" -823- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -825- MOVE W01DTSQL TO SISTEMA-DTTERCOT. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMA_DTTERCOT);

            /*" -826- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -827- DISPLAY 'DATA MOVIMENTO ABERTO.... ' SISTEMA-DTMOVABE. */
            _.Display($"DATA MOVIMENTO ABERTO.... {SISTEMA_DTMOVABE}");

            /*" -828- DISPLAY 'SISTEMA-DTMOVABE......... ' SISTEMA-DTMOVABE. */
            _.Display($"SISTEMA-DTMOVABE......... {SISTEMA_DTMOVABE}");

            /*" -829- DISPLAY 'SISTEMA-CURRENT.......... ' SISTEMA-CURRENT. */
            _.Display($"SISTEMA-CURRENT.......... {SISTEMA_CURRENT}");

            /*" -830- DISPLAY 'SISTEMA-DTTERCOT......... ' SISTEMA-DTTERCOT. */
            _.Display($"SISTEMA-DTTERCOT......... {SISTEMA_DTTERCOT}");

            /*" -831- DISPLAY 'SISTEMA-DTINICOT......... ' SISTEMA-DTINICOT. */
            _.Display($"SISTEMA-DTINICOT......... {SISTEMA_DTINICOT}");

            /*" -832- DISPLAY 'SISTEMA-DTMOV01M......... ' SISTEMA-DTMOV01M. */
            _.Display($"SISTEMA-DTMOV01M......... {SISTEMA_DTMOV01M}");

            /*" -833- DISPLAY 'SISTEMA-DTMOV20D......... ' SISTEMA-DTMOV20D. */
            _.Display($"SISTEMA-DTMOV20D......... {SISTEMA_DTMOV20D}");

            /*" -836- DISPLAY '    ' . */
            _.Display($"    ");

            /*" -838- MOVE 'SELECT COTACAO 28 IPCA' TO COMANDO. */
            _.Move("SELECT COTACAO 28 IPCA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -845- PERFORM M_0010_SELECT_SISTEMAS_DB_SELECT_3 */

            M_0010_SELECT_SISTEMAS_DB_SELECT_3();

            /*" -848- IF WHOST-COUNT EQUAL ZEROS */

            if (WHOST_COUNT == 00)
            {

                /*" -850- DISPLAY 'INDICE IPCA DO MES ' W01MMSQL '/' W01AASQL ' NAO CADASTRADO OU NAO DIVULGADO ' */

                $"INDICE IPCA DO MES {WS_WORK_AREAS.W01DTSQL.W01MMSQL}/{WS_WORK_AREAS.W01DTSQL.W01AASQL} NAO CADASTRADO OU NAO DIVULGADO "
                .Display();

                /*" -851- GO TO 9998-ERRO */

                M_9998_ERRO(); //GOTO
                return;

                /*" -853- END-IF. */
            }


            /*" -855- MOVE 'SELECT COTACAO 23 IGPM' TO COMANDO. */
            _.Move("SELECT COTACAO 23 IGPM", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -862- PERFORM M_0010_SELECT_SISTEMAS_DB_SELECT_4 */

            M_0010_SELECT_SISTEMAS_DB_SELECT_4();

            /*" -865- IF WHOST-COUNT EQUAL ZEROS */

            if (WHOST_COUNT == 00)
            {

                /*" -867- DISPLAY 'INDICE IGPM DO MES ' W01MMSQL '/' W01AASQL ' NAO CADASTRADO OU NAO DIVULGADO ' */

                $"INDICE IGPM DO MES {WS_WORK_AREAS.W01DTSQL.W01MMSQL}/{WS_WORK_AREAS.W01DTSQL.W01AASQL} NAO CADASTRADO OU NAO DIVULGADO "
                .Display();

                /*" -868- GO TO 9998-ERRO */

                M_9998_ERRO(); //GOTO
                return;

                /*" -870- END-IF. */
            }


            /*" -871- MOVE SISTEMA-DTMOVABE(9:2) TO W01DDSQL */
            _.Move(SISTEMA_DTMOVABE.Substring(9, 2), WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -872- MOVE SISTEMA-DTMOVABE(6:2) TO W01MMSQL WS-MES-MOVABERTO */
            _.Move(SISTEMA_DTMOVABE.Substring(6, 2), WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_MES_MOVABERTO);

            /*" -872- MOVE SISTEMA-DTMOVABE(1:4) TO W01AASQL WS-ANO-MOVABERTO. */
            _.Move(SISTEMA_DTMOVABE.Substring(1, 4), WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_ANO_MOVABERTO);

        }

        [StopWatch]
        /*" M-0010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void M_0010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -794- EXEC SQL SELECT DATE(:LK-DATA-INI-PROC), CURRENT DATE, DATE(:LK-DATA-INI-PROC) - 2 MONTH, DATE(:LK-DATA-INI-PROC) - 13 MONTH, DATE(:LK-DATA-INI-PROC) + 1 MONTH, DATE(:LK-DATA-INI-PROC) + 20 DAYS INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRENT, :SISTEMA-DTTERCOT, :SISTEMA-DTINICOT, :SISTEMA-DTMOV01M, :SISTEMA-DTMOV20D FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC */

            var m_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
                LK_DATA_INI_PROC = LK_PARAMETRO.LK_DATA_INI_PROC.ToString(),
            };

            var executed_1 = M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(m_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRENT, SISTEMA_CURRENT);
                _.Move(executed_1.SISTEMA_DTTERCOT, SISTEMA_DTTERCOT);
                _.Move(executed_1.SISTEMA_DTINICOT, SISTEMA_DTINICOT);
                _.Move(executed_1.SISTEMA_DTMOV01M, SISTEMA_DTMOV01M);
                _.Move(executed_1.SISTEMA_DTMOV20D, SISTEMA_DTMOV20D);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-0010-SELECT-SISTEMAS-DB-SELECT-2 */
        public void M_0010_SELECT_SISTEMAS_DB_SELECT_2()
        {
            /*" -813- EXEC SQL SELECT DTMOVABE, CURRENT DATE, DTMOVABE - 2 MONTH, DTMOVABE - 13 MONTH, DTMOVABE + 1 MONTH, DTMOVABE + 20 DAYS INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRENT, :SISTEMA-DTTERCOT, :SISTEMA-DTINICOT, :SISTEMA-DTMOV01M, :SISTEMA-DTMOV20D FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC */

            var m_0010_SELECT_SISTEMAS_DB_SELECT_2_Query1 = new M_0010_SELECT_SISTEMAS_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0010_SELECT_SISTEMAS_DB_SELECT_2_Query1.Execute(m_0010_SELECT_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRENT, SISTEMA_CURRENT);
                _.Move(executed_1.SISTEMA_DTTERCOT, SISTEMA_DTTERCOT);
                _.Move(executed_1.SISTEMA_DTINICOT, SISTEMA_DTINICOT);
                _.Move(executed_1.SISTEMA_DTMOV01M, SISTEMA_DTMOV01M);
                _.Move(executed_1.SISTEMA_DTMOV20D, SISTEMA_DTMOV20D);
            }


        }

        [StopWatch]
        /*" M-0020-CARGA-INDICE */
        private void M_0020_CARGA_INDICE(bool isPerform = false)
        {
            /*" -882- MOVE '0020-CARGA-INDICE' TO PARAGRAFO. */
            _.Move("0020-CARGA-INDICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -883- MOVE SISTEMA-DTINICOT TO W01DTSQL */
            _.Move(SISTEMA_DTINICOT, WS_WORK_AREAS.W01DTSQL);

            /*" -884- MOVE 01 TO W01DDSQL */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -886- MOVE W01DTSQL TO SISTEMA-DTINICOT */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMA_DTINICOT);

            /*" -887- MOVE W01MMSQL TO WS-MES-MIN */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.WS_DATA_MIN_R.WS_MES_MIN);

            /*" -889- MOVE W01AASQL TO WS-ANO-MIN */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.WS_DATA_MIN_R.WS_ANO_MIN);

            /*" -890- MOVE SISTEMA-DTTERCOT TO W01DTSQL */
            _.Move(SISTEMA_DTTERCOT, WS_WORK_AREAS.W01DTSQL);

            /*" -891- MOVE 01 TO W01DDSQL */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -893- MOVE W01DTSQL TO SISTEMA-DTTERCOT */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMA_DTTERCOT);

            /*" -894- MOVE W01MMSQL TO WS-MES-MAX */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.WS_DATA_MAX_R.WS_MES_MAX);

            /*" -903- MOVE W01AASQL TO WS-ANO-MAX */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.WS_DATA_MAX_R.WS_ANO_MAX);

            /*" -911- PERFORM M_0020_CARGA_INDICE_DB_DECLARE_1 */

            M_0020_CARGA_INDICE_DB_DECLARE_1();

            /*" -914- MOVE 'OPEN V0COTACAO' TO COMANDO. */
            _.Move("OPEN V0COTACAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -914- PERFORM M_0020_CARGA_INDICE_DB_OPEN_1 */

            M_0020_CARGA_INDICE_DB_OPEN_1();

            /*" -917- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -918- DISPLAY 'ERRO OPEN V0COTACAO' */
                _.Display($"ERRO OPEN V0COTACAO");

                /*" -919- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -921- END-IF. */
            }


            /*" -923- MOVE SPACES TO WS-EOC. */
            _.Move("", WS_WORK_AREAS.WS_EOC);

            /*" -925- PERFORM 0035-FETCH-V0COTACAO THRU 0035-FIM. */

            M_0035_FETCH_V0COTACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0035_FIM*/


            /*" -926- IF WS-EOC NOT EQUAL SPACES */

            if (!WS_WORK_AREAS.WS_EOC.IsEmpty())
            {

                /*" -928- DISPLAY 'ENVIADO E-MAIL PARA GESTOR ATUALIZAR INDICES IGP 'M E IPCA' */

                $"ENVIADO E-MAIL PARA GESTOR ATUALIZAR INDICES IGP MEIPCA"
                .Display();

                /*" -929- GO TO 9998-ERRO */

                M_9998_ERRO(); //GOTO
                return;

                /*" -932- END-IF. */
            }


            /*" -933- MOVE 1 TO WIND-1. */
            _.Move(1, WS_WORK_AREAS.WIND_1);

            /*" -934- MOVE COTACAO-DTINIVIG TO W01DTSQL. */
            _.Move(COTACAO_DTINIVIG, WS_WORK_AREAS.W01DTSQL);

            /*" -935- MOVE W01MMSQL TO TB-MES-IGPM (WIND-1). */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.TABELA_IGPM.FILLER_1[WS_WORK_AREAS.WIND_1].TB_DATA_IGPM_R.TB_MES_IGPM);

            /*" -937- MOVE W01AASQL TO TB-ANO-IGPM (WIND-1). */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.TABELA_IGPM.FILLER_1[WS_WORK_AREAS.WIND_1].TB_DATA_IGPM_R.TB_ANO_IGPM);

            /*" -938- IF COTACAO-VAL-VENDA < 0 */

            if (COTACAO_VAL_VENDA < 0)
            {

                /*" -939- MOVE ZEROS TO COTACAO-VAL-VENDA */
                _.Move(0, COTACAO_VAL_VENDA);

                /*" -941- END-IF. */
            }


            /*" -944- MOVE COTACAO-VAL-VENDA TO TB-VAL-IGPM (WIND-1) WS-IGPM-ACUM. */
            _.Move(COTACAO_VAL_VENDA, WS_WORK_AREAS.TABELA_IGPM.FILLER_1[WS_WORK_AREAS.WIND_1].TB_VAL_IGPM, WS_WORK_AREAS.WS_IGPM_ACUM);

            /*" -946- PERFORM 0035-FETCH-V0COTACAO THRU 0035-FIM. */

            M_0035_FETCH_V0COTACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0035_FIM*/


            /*" -947- PERFORM 0030-CARGA-V0COTACAO THRU 0030-FIM UNTIL WS-EOC NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WS_EOC.IsEmpty()))
            {

                M_0030_CARGA_V0COTACAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0030_FIM*/

            }

        }

        [StopWatch]
        /*" M-0020-CARGA-INDICE-DB-DECLARE-1 */
        public void M_0020_CARGA_INDICE_DB_DECLARE_1()
        {
            /*" -911- EXEC SQL DECLARE V0COTACAO CURSOR FOR SELECT DTINIVIG, VAL_VENDA FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :VG077-COD-MOEDA AND DTINIVIG >= :SISTEMA-DTINICOT ORDER BY 1 FETCH FIRST 12 ROWS ONLY END-EXEC. */
            V0COTACAO = new VA0130B_V0COTACAO(true);
            string GetQuery_V0COTACAO()
            {
                var query = @$"SELECT DTINIVIG
							, 
							VAL_VENDA 
							FROM SEGUROS.V0COTACAO 
							WHERE CODUNIMO = '{VG077_COD_MOEDA}' 
							AND DTINIVIG >= '{SISTEMA_DTINICOT}' 
							ORDER BY 1 
							FETCH FIRST 12 ROWS ONLY";

                return query;
            }
            V0COTACAO.GetQueryEvent += GetQuery_V0COTACAO;

        }

        [StopWatch]
        /*" M-0020-CARGA-INDICE-DB-OPEN-1 */
        public void M_0020_CARGA_INDICE_DB_OPEN_1()
        {
            /*" -914- EXEC SQL OPEN V0COTACAO END-EXEC. */

            V0COTACAO.Open();

        }

        [StopWatch]
        /*" M-0109-DECLARE-PROPOSTAS-DB-DECLARE-1 */
        public void M_0109_DECLARE_PROPOSTAS_DB_DECLARE_1()
        {
            /*" -1794- EXEC SQL DECLARE CPROPVA CURSOR WITH HOLD FOR SELECT '1' , A.NUM_APOLICE, A.CODSUBES, A.NRCERTIF, A.CODCLIEN, A.OCOREND, A.FONTE, A.AGECOBR, A.OPCAO_COBER, A.DTPROXVEN, A.DTPROXVEN - 1 DAY, A.NRPARCE, A.CODOPER, A.DTMOVTO, A.OCORHIST, A.SIT_INTERFACE, A.TIMESTAMP, A.IDE_SEXO, A.ESTADO_CIVIL, A.DTQITBCO + 1 YEAR, A.DTQITBCO, A.IDADE, A.CODPRODU, IFNULL(A.STA_ANTECIPACAO , ' ' ), IFNULL(A.STA_MUDANCA_PLANO, ' ' ) FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.APOLICES B WHERE A.SITUACAO NOT IN ( '2' , '4' , '5' , '8' , 'C' , '*' ) AND A.DTPROXVEN <> '9999-12-31' AND YEAR(A.DTQITBCO) < :WS-ANO-ATUALIZACAO AND MONTH(A.DTQITBCO) = :WS-MES-ATUALIZACAO AND DAY(A.DTQITBCO) <= :WS-DIA-CONSULTA AND A.NUM_APOLICE = B.NUM_APOLICE AND A.CODPRODU NOT IN ( 8205, :JVPRD8205 , 8209, :JVPRD8209 , 9329, :JVPRD9329 , 9343, :JVPRD9343) AND (A.STA_ANTECIPACAO IS NULL OR A.STA_ANTECIPACAO = ' ' OR A.STA_ANTECIPACAO = 'N' ) AND A.NRPARCE <> 2 AND B.RAMO_EMISSOR <> 77 AND 0 = (SELECT COUNT(*) FROM SEGUROS.HIS_COBER_PROPOST C WHERE C.NUM_CERTIFICADO = A.NRCERTIF AND C.COD_OPERACAO = 895 AND YEAR(C.DATA_INIVIGENCIA) >= :WS-ANO-ATUALIZACAO) UNION SELECT '2' , A.NUM_APOLICE, A.CODSUBES, A.NRCERTIF, A.CODCLIEN, A.OCOREND, A.FONTE, A.AGECOBR, A.OPCAO_COBER, A.DTVENCTO, A.DTVENCTO - 10 MONTH, A.NRPARCE, A.CODOPER, A.DTMOVTO, A.OCORHIST, A.SIT_INTERFACE, A.TIMESTAMP, A.IDE_SEXO, A.ESTADO_CIVIL, A.DTQITBCO + 1 YEAR, A.DTQITBCO, A.IDADE, A.CODPRODU, IFNULL(A.STA_ANTECIPACAO , ' ' ), IFNULL(A.STA_MUDANCA_PLANO, ' ' ) FROM SEGUROS.V0PROPOSTAVA A WHERE A.SITUACAO = '3' AND A.NUM_APOLICE <> 107700000011 AND A.STA_ANTECIPACAO = 'N' AND A.STA_MUDANCA_PLANO = 'S' AND A.DTVENCTO BETWEEN :SISTEMA-DTMOV20D AND :SISTEMA-DTMOV01M AND A.CODPRODU NOT IN ( 8205, :JVPRD8205 , 8209, :JVPRD8209 , 9329, :JVPRD9329 , 9343, :JVPRD9343) AND A.NRPARCE = 2 AND 0 = (SELECT COUNT(*) FROM SEGUROS.HIS_COBER_PROPOST C WHERE C.NUM_CERTIFICADO = A.NRCERTIF AND C.COD_OPERACAO = 895 AND YEAR(C.DATA_INIVIGENCIA) = YEAR(A.DTQITBCO) + 1) ORDER BY 2, 3, 4, 1 END-EXEC. */
            CPROPVA = new VA0130B_CPROPVA(true);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT '1'
							, 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.NRCERTIF
							, 
							A.CODCLIEN
							, 
							A.OCOREND
							, 
							A.FONTE
							, 
							A.AGECOBR
							, 
							A.OPCAO_COBER
							, 
							A.DTPROXVEN
							, 
							A.DTPROXVEN - 1 DAY
							, 
							A.NRPARCE
							, 
							A.CODOPER
							, 
							A.DTMOVTO
							, 
							A.OCORHIST
							, 
							A.SIT_INTERFACE
							, 
							A.TIMESTAMP
							, 
							A.IDE_SEXO
							, 
							A.ESTADO_CIVIL
							, 
							A.DTQITBCO + 1 YEAR
							, 
							A.DTQITBCO
							, 
							A.IDADE
							, 
							A.CODPRODU
							, 
							IFNULL(A.STA_ANTECIPACAO
							, ' ' )
							, 
							IFNULL(A.STA_MUDANCA_PLANO
							, ' ' ) 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.APOLICES B 
							WHERE A.SITUACAO NOT IN ( '2'
							, '4'
							, '5'
							, '8'
							, 'C'
							, '*' ) 
							AND A.DTPROXVEN <> '9999-12-31' 
							AND YEAR(A.DTQITBCO) < '{WS_ANO_ATUALIZACAO}' 
							AND MONTH(A.DTQITBCO) = '{WS_MES_ATUALIZACAO}' 
							AND DAY(A.DTQITBCO) <= '{WS_DIA_CONSULTA}' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.CODPRODU NOT IN ( 8205
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8205}' 
							, 8209
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8209}' 
							, 9329
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9329}' 
							, 9343
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9343}') 
							AND (A.STA_ANTECIPACAO IS NULL OR 
							A.STA_ANTECIPACAO = ' ' OR 
							A.STA_ANTECIPACAO = 'N' ) 
							AND A.NRPARCE <> 2 
							AND B.RAMO_EMISSOR <> 77 
							AND 0 = 
							(SELECT COUNT(*) 
							FROM SEGUROS.HIS_COBER_PROPOST C 
							WHERE C.NUM_CERTIFICADO = A.NRCERTIF 
							AND C.COD_OPERACAO = 895 
							AND YEAR(C.DATA_INIVIGENCIA) >= '{WS_ANO_ATUALIZACAO}') 
							UNION 
							SELECT '2'
							, 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.NRCERTIF
							, 
							A.CODCLIEN
							, 
							A.OCOREND
							, 
							A.FONTE
							, 
							A.AGECOBR
							, 
							A.OPCAO_COBER
							, 
							A.DTVENCTO
							, 
							A.DTVENCTO - 10 MONTH
							, 
							A.NRPARCE
							, 
							A.CODOPER
							, 
							A.DTMOVTO
							, 
							A.OCORHIST
							, 
							A.SIT_INTERFACE
							, 
							A.TIMESTAMP
							, 
							A.IDE_SEXO
							, 
							A.ESTADO_CIVIL
							, 
							A.DTQITBCO + 1 YEAR
							, 
							A.DTQITBCO
							, 
							A.IDADE
							, 
							A.CODPRODU
							, 
							IFNULL(A.STA_ANTECIPACAO
							, ' ' )
							, 
							IFNULL(A.STA_MUDANCA_PLANO
							, ' ' ) 
							FROM SEGUROS.V0PROPOSTAVA A 
							WHERE A.SITUACAO = '3' 
							AND A.NUM_APOLICE <> 107700000011 
							AND A.STA_ANTECIPACAO = 'N' 
							AND A.STA_MUDANCA_PLANO = 'S' 
							AND A.DTVENCTO BETWEEN '{SISTEMA_DTMOV20D}' 
							AND '{SISTEMA_DTMOV01M}' 
							AND A.CODPRODU NOT IN ( 8205
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8205}' 
							, 8209
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8209}' 
							, 9329
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9329}' 
							, 9343
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9343}') 
							AND A.NRPARCE = 2 
							AND 0 = 
							(SELECT COUNT(*) 
							FROM SEGUROS.HIS_COBER_PROPOST C 
							WHERE C.NUM_CERTIFICADO = A.NRCERTIF 
							AND C.COD_OPERACAO = 895 
							AND YEAR(C.DATA_INIVIGENCIA) = YEAR(A.DTQITBCO) + 1) 
							ORDER BY 2
							, 3
							, 4
							, 1";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0010-SELECT-SISTEMAS-DB-SELECT-3 */
        public void M_0010_SELECT_SISTEMAS_DB_SELECT_3()
        {
            /*" -845- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.V0COTACAO WHERE CODUNIMO = 28 AND DTINIVIG = :SISTEMA-DTTERCOT WITH UR END-EXEC. */

            var m_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1 = new M_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1()
            {
                SISTEMA_DTTERCOT = SISTEMA_DTTERCOT.ToString(),
            };

            var executed_1 = M_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1.Execute(m_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

        [StopWatch]
        /*" M-0010-SELECT-SISTEMAS-DB-SELECT-4 */
        public void M_0010_SELECT_SISTEMAS_DB_SELECT_4()
        {
            /*" -862- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.V0COTACAO WHERE CODUNIMO = 23 AND DTINIVIG = :SISTEMA-DTTERCOT WITH UR END-EXEC. */

            var m_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1 = new M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1()
            {
                SISTEMA_DTTERCOT = SISTEMA_DTTERCOT.ToString(),
            };

            var executed_1 = M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1.Execute(m_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }

        [StopWatch]
        /*" M-0030-CARGA-V0COTACAO */
        private void M_0030_CARGA_V0COTACAO(bool isPerform = false)
        {
            /*" -957- ADD 1 TO WIND-1. */
            WS_WORK_AREAS.WIND_1.Value = WS_WORK_AREAS.WIND_1 + 1;

            /*" -958- IF WIND-1 > 300 */

            if (WS_WORK_AREAS.WIND_1 > 300)
            {

                /*" -959- DISPLAY '*** VA0130B ESTOURO TAB. INTERNA TB-IGPM ' */
                _.Display($"*** VA0130B ESTOURO TAB. INTERNA TB-IGPM ");

                /*" -960- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -962- END-IF. */
            }


            /*" -963- MOVE COTACAO-DTINIVIG TO W01DTSQL. */
            _.Move(COTACAO_DTINIVIG, WS_WORK_AREAS.W01DTSQL);

            /*" -964- MOVE W01MMSQL TO TB-MES-IGPM (WIND-1). */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.TABELA_IGPM.FILLER_1[WS_WORK_AREAS.WIND_1].TB_DATA_IGPM_R.TB_MES_IGPM);

            /*" -966- MOVE W01AASQL TO TB-ANO-IGPM (WIND-1). */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.TABELA_IGPM.FILLER_1[WS_WORK_AREAS.WIND_1].TB_DATA_IGPM_R.TB_ANO_IGPM);

            /*" -967- IF COTACAO-VAL-VENDA < 0 */

            if (COTACAO_VAL_VENDA < 0)
            {

                /*" -968- MOVE ZEROS TO COTACAO-VAL-VENDA */
                _.Move(0, COTACAO_VAL_VENDA);

                /*" -970- END-IF. */
            }


            /*" -972- MOVE COTACAO-VAL-VENDA TO TB-VAL-IGPM (WIND-1). */
            _.Move(COTACAO_VAL_VENDA, WS_WORK_AREAS.TABELA_IGPM.FILLER_1[WS_WORK_AREAS.WIND_1].TB_VAL_IGPM);

            /*" -976- IF COTACAO-VAL-VENDA EQUAL 0 */

            if (COTACAO_VAL_VENDA == 0)
            {

                /*" -977- CONTINUE */

                /*" -978- ELSE */
            }
            else
            {


                /*" -981- COMPUTE WS-IGPM-ACUM = (((COTACAO-VAL-VENDA / 100 + 1) * (WS-IGPM-ACUM / 100 + 1) - 1 ) * 100) */
                WS_WORK_AREAS.WS_IGPM_ACUM.Value = (((COTACAO_VAL_VENDA / 100f + 1) * (WS_WORK_AREAS.WS_IGPM_ACUM / 100f + 1) - 1) * 100);

                /*" -983- END-IF. */
            }


            /*" -983- PERFORM 0035-FETCH-V0COTACAO THRU 0035-FIM. */

            M_0035_FETCH_V0COTACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0035_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0030_FIM*/

        [StopWatch]
        /*" M-0035-FETCH-V0COTACAO */
        private void M_0035_FETCH_V0COTACAO(bool isPerform = false)
        {
            /*" -992- MOVE '0035-FETCH-V0COTACAO' TO PARAGRAFO */
            _.Move("0035-FETCH-V0COTACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -994- MOVE 'FETCH V0COTACAO' TO COMANDO. */
            _.Move("FETCH V0COTACAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -997- PERFORM M_0035_FETCH_V0COTACAO_DB_FETCH_1 */

            M_0035_FETCH_V0COTACAO_DB_FETCH_1();

            /*" -1000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1001- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1002- MOVE 'S' TO WS-EOC */
                    _.Move("S", WS_WORK_AREAS.WS_EOC);

                    /*" -1002- PERFORM M_0035_FETCH_V0COTACAO_DB_CLOSE_1 */

                    M_0035_FETCH_V0COTACAO_DB_CLOSE_1();

                    /*" -1004- ELSE */
                }
                else
                {


                    /*" -1005- DISPLAY 'ERRO NO FETCH V0COTACAO' */
                    _.Display($"ERRO NO FETCH V0COTACAO");

                    /*" -1006- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1007- END-IF */
                }


                /*" -1007- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0035-FETCH-V0COTACAO-DB-FETCH-1 */
        public void M_0035_FETCH_V0COTACAO_DB_FETCH_1()
        {
            /*" -997- EXEC SQL FETCH V0COTACAO INTO :COTACAO-DTINIVIG, :COTACAO-VAL-VENDA END-EXEC. */

            if (V0COTACAO.Fetch())
            {
                _.Move(V0COTACAO.COTACAO_DTINIVIG, COTACAO_DTINIVIG);
                _.Move(V0COTACAO.COTACAO_VAL_VENDA, COTACAO_VAL_VENDA);
            }

        }

        [StopWatch]
        /*" M-0035-FETCH-V0COTACAO-DB-CLOSE-1 */
        public void M_0035_FETCH_V0COTACAO_DB_CLOSE_1()
        {
            /*" -1002- EXEC SQL CLOSE V0COTACAO END-EXEC */

            V0COTACAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0035_FIM*/

        [StopWatch]
        /*" M-0040-SELECT-VG-INDICE */
        private void M_0040_SELECT_VG_INDICE(bool isPerform = false)
        {
            /*" -1017- MOVE '0040-SELECT-VG-INDICE' TO PARAGRAFO. */
            _.Move("0040-SELECT-VG-INDICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1021- MOVE 'SELECT VG_INDICE' TO COMANDO. */
            _.Move("SELECT VG_INDICE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1029- PERFORM M_0040_SELECT_VG_INDICE_DB_SELECT_1 */

            M_0040_SELECT_VG_INDICE_DB_SELECT_1();

            /*" -1032- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1033- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1034- DISPLAY 'CODIGO MOEDA DE REAJUSTE NAO ENCONTRADO ' */
                    _.Display($"CODIGO MOEDA DE REAJUSTE NAO ENCONTRADO ");

                    /*" -1036- DISPLAY 'APOLICE=' PROPVA-NUM-APOLICE ' SUBGRUPO=' PROPVA-CODSUBES */

                    $"APOLICE={PROPVA_NUM_APOLICE} SUBGRUPO={PROPVA_CODSUBES}"
                    .Display();

                    /*" -1037- MOVE 'NAO' TO WS-PROCESSA-INDICE */
                    _.Move("NAO", WS_WORK_AREAS.WS_PROCESSA_INDICE);

                    /*" -1038- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -1040- MOVE 'CODIGO MOEDA NAO CADASTRADO' TO RD-DES-MOTIVO */
                    _.Move("CODIGO MOEDA NAO CADASTRADO", WS_MOVDESP.RD_DES_MOTIVO);

                    /*" -1041- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -1042- GO TO 0040-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_FIM*/ //GOTO
                    return;

                    /*" -1043- ELSE */
                }
                else
                {


                    /*" -1044- DISPLAY 'ERRO ACESSO A VG_INDICES' */
                    _.Display($"ERRO ACESSO A VG_INDICES");

                    /*" -1045- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1046- END-IF */
                }


                /*" -1048- END-IF. */
            }


            /*" -1050- PERFORM 0045-SELECT-COTACAO THRU 0045-FIM */

            M_0045_SELECT_COTACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0045_FIM*/


            /*" -1051- IF WS-PROCESSA-INDICE EQUAL 'NAO' */

            if (WS_WORK_AREAS.WS_PROCESSA_INDICE == "NAO")
            {

                /*" -1053- GO TO 0040-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_FIM*/ //GOTO
                return;
            }


            /*" -1054- PERFORM 0020-CARGA-INDICE THRU 0020-FIM */

            M_0020_CARGA_INDICE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/


            /*" -1056- MOVE WS-IGPM-ACUM TO WS-IGPM-ACUM-DISPLAY1 */
            _.Move(WS_WORK_AREAS.WS_IGPM_ACUM, WS_WORK_AREAS.WS_IGPM_ACUM_DISPLAY1);

            /*" -1056- PERFORM 0055-CRITICA-INDICE THRU 0055-FIM. */

            M_0055_CRITICA_INDICE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0055_FIM*/


        }

        [StopWatch]
        /*" M-0040-SELECT-VG-INDICE-DB-SELECT-1 */
        public void M_0040_SELECT_VG_INDICE_DB_SELECT_1()
        {
            /*" -1029- EXEC SQL SELECT COD_MOEDA INTO :VG077-COD-MOEDA FROM SEGUROS.VG_INDICES WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES AND DTH_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var m_0040_SELECT_VG_INDICE_DB_SELECT_1_Query1 = new M_0040_SELECT_VG_INDICE_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0040_SELECT_VG_INDICE_DB_SELECT_1_Query1.Execute(m_0040_SELECT_VG_INDICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG077_COD_MOEDA, VG077_COD_MOEDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_FIM*/

        [StopWatch]
        /*" M-0045-SELECT-COTACAO */
        private void M_0045_SELECT_COTACAO(bool isPerform = false)
        {
            /*" -1070- MOVE '0045-SELECT-COTACAO' TO PARAGRAFO. */
            _.Move("0045-SELECT-COTACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1072- MOVE 'SELECT V0COTACAO' TO COMANDO. */
            _.Move("SELECT V0COTACAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1079- PERFORM M_0045_SELECT_COTACAO_DB_SELECT_1 */

            M_0045_SELECT_COTACAO_DB_SELECT_1();

            /*" -1082- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1083- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1086- DISPLAY 'INDICE ' VG077-COD-MOEDA ' DO MES ' W01MMSQL '/' W01AASQL ' NAO CADASTRADO OU NAO DIVULGADO' */

                    $"INDICE {VG077_COD_MOEDA} DO MES {WS_WORK_AREAS.W01DTSQL.W01MMSQL}/{WS_WORK_AREAS.W01DTSQL.W01AASQL} NAO CADASTRADO OU NAO DIVULGADO"
                    .Display();

                    /*" -1087- MOVE SISTEMA-CURRENT TO W02DTSQL */
                    _.Move(SISTEMA_CURRENT, WS_WORK_AREAS.W02DTSQL);

                    /*" -1088- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -1090- MOVE 'INDICE MES NAO CADASTRADO' TO RD-DES-MOTIVO */
                    _.Move("INDICE MES NAO CADASTRADO", WS_MOVDESP.RD_DES_MOTIVO);

                    /*" -1091- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -1092- MOVE 'NAO' TO WS-PROCESSA-INDICE */
                    _.Move("NAO", WS_WORK_AREAS.WS_PROCESSA_INDICE);

                    /*" -1093- ELSE */
                }
                else
                {


                    /*" -1094- DISPLAY 'ERRO ACESSO V0COTACAO' */
                    _.Display($"ERRO ACESSO V0COTACAO");

                    /*" -1095- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1096- END-IF */
                }


                /*" -1096- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0045-SELECT-COTACAO-DB-SELECT-1 */
        public void M_0045_SELECT_COTACAO_DB_SELECT_1()
        {
            /*" -1079- EXEC SQL SELECT DTINIVIG INTO :COTACAO-DTINIVIG FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :VG077-COD-MOEDA AND DTINIVIG = :SISTEMA-DTTERCOT WITH UR END-EXEC. */

            var m_0045_SELECT_COTACAO_DB_SELECT_1_Query1 = new M_0045_SELECT_COTACAO_DB_SELECT_1_Query1()
            {
                SISTEMA_DTTERCOT = SISTEMA_DTTERCOT.ToString(),
                VG077_COD_MOEDA = VG077_COD_MOEDA.ToString(),
            };

            var executed_1 = M_0045_SELECT_COTACAO_DB_SELECT_1_Query1.Execute(m_0045_SELECT_COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COTACAO_DTINIVIG, COTACAO_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0045_FIM*/

        [StopWatch]
        /*" M-0050-DATA-ENCERRAMENTO */
        private void M_0050_DATA_ENCERRAMENTO(bool isPerform = false)
        {
            /*" -1108- MOVE SISTEMA-DTMOVABE TO W01DTSQL. */
            _.Move(SISTEMA_DTMOVABE, WS_WORK_AREAS.W01DTSQL);

            /*" -1109- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -1111- MOVE W01DTSQL TO SISTEMA-DTMAXALTIGPM-2 */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMA_DTMAXALTIGPM_2);

            /*" -1112- MOVE SISTEMA-DTMOV01M TO W01DTSQL. */
            _.Move(SISTEMA_DTMOV01M, WS_WORK_AREAS.W01DTSQL);

            /*" -1113- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -1115- MOVE W01DTSQL TO SISTEMA-DTMAXALTIGPM-1. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMA_DTMAXALTIGPM_1);

            /*" -1117- COMPUTE W01DDSQL = W01DDSQL - 1. */
            WS_WORK_AREAS.W01DTSQL.W01DDSQL.Value = WS_WORK_AREAS.W01DTSQL.W01DDSQL - 1;

            /*" -1118- IF W01DDSQL EQUAL ZEROS */

            if (WS_WORK_AREAS.W01DTSQL.W01DDSQL == 00)
            {

                /*" -1120- COMPUTE W01MMSQL = W01MMSQL - 1 */
                WS_WORK_AREAS.W01DTSQL.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL.W01MMSQL - 1;

                /*" -1121- IF W01MMSQL = 0 */

                if (WS_WORK_AREAS.W01DTSQL.W01MMSQL == 0)
                {

                    /*" -1122- MOVE 12 TO W01MMSQL */
                    _.Move(12, WS_WORK_AREAS.W01DTSQL.W01MMSQL);

                    /*" -1123- COMPUTE W01AASQL = W01AASQL - 1 */
                    WS_WORK_AREAS.W01DTSQL.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL.W01AASQL - 1;

                    /*" -1125- END-IF */
                }


                /*" -1126- MOVE TAB-ULT-DIA(W01MMSQL) TO W01DDSQL */
                _.Move(WS_WORK_AREAS.TAB_ULTIMOS_DIAS.TAB_DIA_MESES[WS_WORK_AREAS.W01DTSQL.W01MMSQL].TAB_ULT_DIA, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

                /*" -1128- END-IF. */
            }


            /*" -1130- DIVIDE W01AASQL BY 4 GIVING QUOCIENTE REMAINDER RESTO. */
            _.Divide(WS_WORK_AREAS.W01DTSQL.W01AASQL, 4, QUOCIENTE, RESTO);

            /*" -1131- IF RESTO = 0 AND W01MMSQL = 2 */

            if (RESTO == 0 && WS_WORK_AREAS.W01DTSQL.W01MMSQL == 2)
            {

                /*" -1132- ADD 1 TO W01DDSQL */
                WS_WORK_AREAS.W01DTSQL.W01DDSQL.Value = WS_WORK_AREAS.W01DTSQL.W01DDSQL + 1;

                /*" -1134- END-IF. */
            }


            /*" -1136- MOVE W01DTSQL TO COBERP-DTTERVIG-ANT. */
            _.Move(WS_WORK_AREAS.W01DTSQL, COBERP_DTTERVIG_ANT);

            /*" -1137- MOVE SISTEMA-DTMAXALTIGPM-1(01:04) TO WS-ANO-ATUALIZACAO */
            _.Move(SISTEMA_DTMAXALTIGPM_1.Substring(1, 4), WS_ANO_ATUALIZACAO);

            /*" -1138- MOVE SISTEMA-DTMAXALTIGPM-1(06:02) TO WS-MES-ATUALIZACAO */
            _.Move(SISTEMA_DTMAXALTIGPM_1.Substring(6, 2), WS_MES_ATUALIZACAO);

            /*" -1140- MOVE SISTEMA-DTMOVABE(09:02) TO WS-DIA-CONSULTA */
            _.Move(SISTEMA_DTMOVABE.Substring(9, 2), WS_DIA_CONSULTA);

            /*" -1150- PERFORM M_0050_DATA_ENCERRAMENTO_DB_SELECT_1 */

            M_0050_DATA_ENCERRAMENTO_DB_SELECT_1();

            /*" -1153- IF SISTEMA-DTMOVABE = CALENDAR-DATA-CALENDARIO */

            if (SISTEMA_DTMOVABE == CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO)
            {

                /*" -1154- MOVE 30 TO WS-DIA-CONSULTA */
                _.Move(30, WS_DIA_CONSULTA);

                /*" -1156- END-IF */
            }


            /*" -1158- ADD 1 TO WS-DIA-CONSULTA. */
            WS_DIA_CONSULTA.Value = WS_DIA_CONSULTA + 1;

            /*" -1159- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1160- DISPLAY ' SISTEMA-DTMAXALTIGPM-2.. ' SISTEMA-DTMAXALTIGPM-2 */
            _.Display($" SISTEMA-DTMAXALTIGPM-2.. {SISTEMA_DTMAXALTIGPM_2}");

            /*" -1161- DISPLAY ' SISTEMA-DTMAXALTIGPM-1.. ' SISTEMA-DTMAXALTIGPM-1 */
            _.Display($" SISTEMA-DTMAXALTIGPM-1.. {SISTEMA_DTMAXALTIGPM_1}");

            /*" -1162- DISPLAY ' COBERP-DTTERVIG-ANT..... ' COBERP-DTTERVIG-ANT */
            _.Display($" COBERP-DTTERVIG-ANT..... {COBERP_DTTERVIG_ANT}");

            /*" -1163- DISPLAY ' ANO DE ANIVERSARIO...... ' WS-ANO-ATUALIZACAO */
            _.Display($" ANO DE ANIVERSARIO...... {WS_ANO_ATUALIZACAO}");

            /*" -1164- DISPLAY ' MES DE ANIVERSARIO...... ' WS-MES-ATUALIZACAO */
            _.Display($" MES DE ANIVERSARIO...... {WS_MES_ATUALIZACAO}");

            /*" -1165- DISPLAY ' DIA DA CONSULTA......... ' WS-DIA-CONSULTA */
            _.Display($" DIA DA CONSULTA......... {WS_DIA_CONSULTA}");

            /*" -1165- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

        }

        [StopWatch]
        /*" M-0050-DATA-ENCERRAMENTO-DB-SELECT-1 */
        public void M_0050_DATA_ENCERRAMENTO_DB_SELECT_1()
        {
            /*" -1150- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE YEAR(DATA_CALENDARIO) = :WS-ANO-MOVABERTO AND MONTH(DATA_CALENDARIO) = :WS-MES-MOVABERTO AND FERIADO <> 'N' AND DIA_SEMANA NOT IN ( 'D' , 'S' ) ORDER BY DATA_CALENDARIO DESC FETCH FIRST 1 ROWS ONLY END-EXEC */

            var m_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1 = new M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1()
            {
                WS_ANO_MOVABERTO = WS_ANO_MOVABERTO.ToString(),
                WS_MES_MOVABERTO = WS_MES_MOVABERTO.ToString(),
            };

            var executed_1 = M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1.Execute(m_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0050_FIM*/

        [StopWatch]
        /*" M-0055-CRITICA-INDICE */
        private void M_0055_CRITICA_INDICE(bool isPerform = false)
        {
            /*" -1175- MOVE '0055-CRITICA-INDICE' TO PARAGRAFO. */
            _.Move("0055-CRITICA-INDICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1177- MOVE 'CRITICA-INDICE' TO COMANDO. */
            _.Move("CRITICA-INDICE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1179- COMPUTE WS-IGPM-ACUM ROUNDED = WS-IGPM-ACUM / 100. */
            WS_WORK_AREAS.WS_IGPM_ACUM.Value = WS_WORK_AREAS.WS_IGPM_ACUM / 100f;

            /*" -1180- IF WS-IGPM-ACUM GREATER ZEROS */

            if (WS_WORK_AREAS.WS_IGPM_ACUM > 00)
            {

                /*" -1181- CONTINUE */

                /*" -1182- ELSE */
            }
            else
            {


                /*" -1183- MOVE 'NAO' TO WS-PROCESSA-INDICE */
                _.Move("NAO", WS_WORK_AREAS.WS_PROCESSA_INDICE);

                /*" -1184- ADD 1 TO AC-DESP-PRODUTO */
                WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                /*" -1186- MOVE 'INDICE ACUMULADO NEGATIVO OU ZERO' TO RD-DES-MOTIVO */
                _.Move("INDICE ACUMULADO NEGATIVO OU ZERO", WS_MOVDESP.RD_DES_MOTIVO);

                /*" -1187- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -1188- GO TO 0055-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0055_FIM*/ //GOTO
                return;

                /*" -1190- END-IF. */
            }


            /*" -1191- ADD 1 TO WS-IGPM-ACUM. */
            WS_WORK_AREAS.WS_IGPM_ACUM.Value = WS_WORK_AREAS.WS_IGPM_ACUM + 1;

            /*" -1191- MOVE WS-IGPM-ACUM TO WS-IGPM-ACUM-DISPLAY2. */
            _.Move(WS_WORK_AREAS.WS_IGPM_ACUM, WS_WORK_AREAS.WS_IGPM_ACUM_DISPLAY2);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0055_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -1200- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1202- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1217- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

            /*" -1220- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1221- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1222- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -1223- MOVE 'OPCAOPAG NAO CADASTRADO' TO RD-DES-MOTIVO */
                    _.Move("OPCAOPAG NAO CADASTRADO", WS_MOVDESP.RD_DES_MOTIVO);

                    /*" -1224- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -1225- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1226- ELSE */
                }
                else
                {


                    /*" -1227- DISPLAY 'ERRO ACESSO SEGUROS.V0OPCAOPAGVA' */
                    _.Display($"ERRO ACESSO SEGUROS.V0OPCAOPAGVA");

                    /*" -1228- DISPLAY 'NRCERTIF=' PROPVA-NRCERTIF */
                    _.Display($"NRCERTIF={PROPVA_NRCERTIF}");

                    /*" -1229- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1230- END-IF */
                }


                /*" -1232- END-IF. */
            }


            /*" -1235- MOVE 'SELECT V0SEGURAVG 1' TO COMANDO. */
            _.Move("SELECT V0SEGURAVG 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1264- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

            /*" -1267- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1268- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1269- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -1270- MOVE 'SEGURADO NAO CADASTRADO' TO RD-DES-MOTIVO */
                    _.Move("SEGURADO NAO CADASTRADO", WS_MOVDESP.RD_DES_MOTIVO);

                    /*" -1271- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -1272- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1273- ELSE */
                }
                else
                {


                    /*" -1274- DISPLAY 'ERRO ACESSO SEGUROS.V0SEGURAVG' */
                    _.Display($"ERRO ACESSO SEGUROS.V0SEGURAVG");

                    /*" -1275- DISPLAY 'NUM_APOLICE    =' PROPVA-NUM-APOLICE */
                    _.Display($"NUM_APOLICE    ={PROPVA_NUM_APOLICE}");

                    /*" -1276- DISPLAY 'COD_SUBGRUPO   =' PROPVA-CODSUBES */
                    _.Display($"COD_SUBGRUPO   ={PROPVA_CODSUBES}");

                    /*" -1277- DISPLAY 'NUM_CERTIFICADO=' PROPVA-NRCERTIF */
                    _.Display($"NUM_CERTIFICADO={PROPVA_NRCERTIF}");

                    /*" -1278- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1279- END-IF */
                }


                /*" -1281- END-IF. */
            }


            /*" -1282- IF SEGURA-SIT-REGISTRO EQUAL '2' OR '9' OR 'N' */

            if (SEGURA_SIT_REGISTRO.In("2", "9", "N"))
            {

                /*" -1283- ADD 1 TO AC-DESP-PRODUTO */
                WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                /*" -1284- MOVE 'SEGURADO CANCELADO' TO RD-DES-MOTIVO */
                _.Move("SEGURADO CANCELADO", WS_MOVDESP.RD_DES_MOTIVO);

                /*" -1285- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -1286- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -1288- END-IF. */
            }


            /*" -1290- PERFORM 2500-SELECT-V0COBERAPOL THRU 2500-FIM */

            M_2500_SELECT_V0COBERAPOL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2500_FIM*/


            /*" -1291- IF WS-FLAG-ERRO EQUAL 'S' */

            if (WS_FLAG_ERRO == "S")
            {

                /*" -1292- ADD 1 TO WS-ERRO-COBER */
                WS_WORK_AREAS.WS_ERRO_COBER.Value = WS_WORK_AREAS.WS_ERRO_COBER + 1;

                /*" -1293- MOVE 'ERRO ACESSO V0COBERAPOL' TO RD-DES-MOTIVO */
                _.Move("ERRO ACESSO V0COBERAPOL", WS_MOVDESP.RD_DES_MOTIVO);

                /*" -1294- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -1295- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -1297- END-IF. */
            }


            /*" -1300- MOVE 'SELECT V0HISTSEGVG' TO COMANDO. */
            _.Move("SELECT V0HISTSEGVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1310- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

            /*" -1313- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1314- DISPLAY 'ERRO ACESSO SEGUROS.V0HISTSEGVG' */
                _.Display($"ERRO ACESSO SEGUROS.V0HISTSEGVG");

                /*" -1315- DISPLAY 'NUM_APOLICE    =' PROPVA-NUM-APOLICE */
                _.Display($"NUM_APOLICE    ={PROPVA_NUM_APOLICE}");

                /*" -1316- DISPLAY 'NUM_ITEM       =' SEGURA-NUM-ITEM */
                _.Display($"NUM_ITEM       ={SEGURA_NUM_ITEM}");

                /*" -1317- DISPLAY 'OCORR_HISTORICO=' SEGURA-OCORHIST */
                _.Display($"OCORR_HISTORICO={SEGURA_OCORHIST}");

                /*" -1318- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1320- END-IF. */
            }


            /*" -1323- MOVE 'SELECT V0HISTSEGVG MAX' TO COMANDO. */
            _.Move("SELECT V0HISTSEGVG MAX", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1325- MOVE '0001-01-01' TO HISTSG-DTMOVTO-1YEAR. */
            _.Move("0001-01-01", HISTSG_DTMOVTO_1YEAR);

            /*" -1333- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

            /*" -1336- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1337- DISPLAY 'ERRO ACESSO SEGUROS.V0HISTSEGVG 1' */
                _.Display($"ERRO ACESSO SEGUROS.V0HISTSEGVG 1");

                /*" -1338- DISPLAY 'NUM_APOLICE    =' PROPVA-NUM-APOLICE */
                _.Display($"NUM_APOLICE    ={PROPVA_NUM_APOLICE}");

                /*" -1339- DISPLAY 'NUM_ITEM       =' SEGURA-NUM-ITEM */
                _.Display($"NUM_ITEM       ={SEGURA_NUM_ITEM}");

                /*" -1340- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1342- END-IF. */
            }


            /*" -1343- IF HISTSG-OCORHIST NOT EQUAL ZEROS */

            if (HISTSG_OCORHIST != 00)
            {

                /*" -1344- MOVE 'SELECT V0HISTSEGVG 2' TO COMANDO */
                _.Move("SELECT V0HISTSEGVG 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1352- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

                /*" -1355- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1356- DISPLAY 'ERRO ACESSO SEGUROS.V0HISTSEGVG 2' */
                    _.Display($"ERRO ACESSO SEGUROS.V0HISTSEGVG 2");

                    /*" -1357- DISPLAY 'NUM_APOLICE  =' PROPVA-NUM-APOLICE */
                    _.Display($"NUM_APOLICE  ={PROPVA_NUM_APOLICE}");

                    /*" -1358- DISPLAY 'NUM_ITEM     =' SEGURA-NUM-ITEM */
                    _.Display($"NUM_ITEM     ={SEGURA_NUM_ITEM}");

                    /*" -1359- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1360- END-IF */
                }


                /*" -1362- END-IF. */
            }


            /*" -1364- MOVE HISTSG-DTMOVTO-1YEAR(1:4) TO HISTSG-ANO-ATUALIZ */
            _.Move(HISTSG_DTMOVTO_1YEAR.Substring(1, 4), HISTSG_ANO_ATUALIZ);

            /*" -1366- IF PROPVA-NRPARCEL EQUAL 2 AND PROPVA-TEM-ANTECIP EQUAL '2' */

            if (PROPVA_NRPARCEL == 2 && PROPVA_TEM_ANTECIP == "2")
            {

                /*" -1367- IF HISTSG-OCORHIST EQUAL ZEROS */

                if (HISTSG_OCORHIST == 00)
                {

                    /*" -1368- MOVE SISTEMA-DTMAXALTIGPM-2 TO SISTEMA-DTMAXALTIGPM */
                    _.Move(SISTEMA_DTMAXALTIGPM_2, SISTEMA_DTMAXALTIGPM);

                    /*" -1370- MOVE SISTEMA-DTMAXALTIGPM(1:4) TO SISTEMA-ANOMAXALTIGPM */
                    _.Move(SISTEMA_DTMAXALTIGPM.Substring(1, 4), SISTEMA_ANOMAXALTIGPM);

                    /*" -1378- ELSE */
                }
                else
                {


                    /*" -1379- ADD 1 TO AC-DESP-JA-ATUAL */
                    WS_WORK_AREAS.AC_DESP_JA_ATUAL.Value = WS_WORK_AREAS.AC_DESP_JA_ATUAL + 1;

                    /*" -1381- MOVE 'CERTIFICADO JA ATUALIZADO' TO RD-DES-MOTIVO */
                    _.Move("CERTIFICADO JA ATUALIZADO", WS_MOVDESP.RD_DES_MOTIVO);

                    /*" -1382- IF PROPVA-TEM-ANTECIP = '2' */

                    if (PROPVA_TEM_ANTECIP == "2")
                    {

                        /*" -1383- ADD 1 TO AC-DESP-ATUAL-2 */
                        WS_WORK_AREAS.AC_DESP_ATUAL_2.Value = WS_WORK_AREAS.AC_DESP_ATUAL_2 + 1;

                        /*" -1384- ELSE */
                    }
                    else
                    {


                        /*" -1385- ADD 1 TO AC-DESP-ATUAL-1 */
                        WS_WORK_AREAS.AC_DESP_ATUAL_1.Value = WS_WORK_AREAS.AC_DESP_ATUAL_1 + 1;

                        /*" -1386- END-IF */
                    }


                    /*" -1387- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -1388- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1389- END-IF */
                }


                /*" -1395- ELSE */
            }
            else
            {


                /*" -1396- MOVE SISTEMA-DTMAXALTIGPM-1 TO SISTEMA-DTMAXALTIGPM */
                _.Move(SISTEMA_DTMAXALTIGPM_1, SISTEMA_DTMAXALTIGPM);

                /*" -1398- MOVE SISTEMA-DTMAXALTIGPM(1:4) TO SISTEMA-ANOMAXALTIGPM */
                _.Move(SISTEMA_DTMAXALTIGPM.Substring(1, 4), SISTEMA_ANOMAXALTIGPM);

                /*" -1400- IF SISTEMA-DTMAXALTIGPM(06:02) EQUAL PROPVA-DTQITBCO(06:02) */

                if (SISTEMA_DTMAXALTIGPM.Substring(06, 02) == PROPVA_DTQITBCO.Substring(06, 02))
                {

                    /*" -1401- IF HISTSG-ANO-ATUALIZ EQUAL SISTEMA-ANOMAXALTIGPM */

                    if (HISTSG_ANO_ATUALIZ == SISTEMA_ANOMAXALTIGPM)
                    {

                        /*" -1402- ADD 1 TO AC-DESP-JA-ATUAL */
                        WS_WORK_AREAS.AC_DESP_JA_ATUAL.Value = WS_WORK_AREAS.AC_DESP_JA_ATUAL + 1;

                        /*" -1404- MOVE 'CERTIFICADO JA ATUALIZADO' TO RD-DES-MOTIVO */
                        _.Move("CERTIFICADO JA ATUALIZADO", WS_MOVDESP.RD_DES_MOTIVO);

                        /*" -1405- IF PROPVA-TEM-ANTECIP = '2' */

                        if (PROPVA_TEM_ANTECIP == "2")
                        {

                            /*" -1406- ADD 1 TO AC-DESP-ATUAL-2 */
                            WS_WORK_AREAS.AC_DESP_ATUAL_2.Value = WS_WORK_AREAS.AC_DESP_ATUAL_2 + 1;

                            /*" -1407- ELSE */
                        }
                        else
                        {


                            /*" -1408- ADD 1 TO AC-DESP-ATUAL-1 */
                            WS_WORK_AREAS.AC_DESP_ATUAL_1.Value = WS_WORK_AREAS.AC_DESP_ATUAL_1 + 1;

                            /*" -1409- END-IF */
                        }


                        /*" -1410- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                        M_8200_GRAVA_MOVDESP(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                        /*" -1411- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1412- END-IF */
                    }


                    /*" -1413- ELSE */
                }
                else
                {


                    /*" -1414- ADD 1 TO AC-DESP-NOT-NIVER */
                    WS_WORK_AREAS.AC_DESP_NOT_NIVER.Value = WS_WORK_AREAS.AC_DESP_NOT_NIVER + 1;

                    /*" -1418- STRING 'NAO FAZ ANIVERSARIO, MES PROPOSTA = ' PROPVA-DTQITBCO(06:02) DELIMITED BY SIZE INTO RD-DES-MOTIVO */
                    #region STRING
                    var spl1 = "NAO FAZ ANIVERSARIO, MES PROPOSTA = " + PROPVA_DTQITBCO.Substring(06, 02).GetMoveValues();
                    _.Move(spl1, WS_MOVDESP.RD_DES_MOTIVO);
                    #endregion

                    /*" -1419- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -1420- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1421- END-IF */
                }


                /*" -1423- END-IF. */
            }


            /*" -1425- MOVE 'SELECT V0CLIENTE' TO COMANDO. */
            _.Move("SELECT V0CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1431- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_6 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_6();

            /*" -1435- IF (SQLCODE NOT EQUAL ZEROES) OR (CLIENT-DTNASC-I LESS ZEROES) */

            if ((DB.SQLCODE != 00) || (CLIENT_DTNASC_I < 00))
            {

                /*" -1437- MOVE 'SELECT V0SEGURAVG 2' TO COMANDO */
                _.Move("SELECT V0SEGURAVG 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1445- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_7 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_7();

                /*" -1448- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1449- IF SQLCODE EQUAL +100 */

                    if (DB.SQLCODE == +100)
                    {

                        /*" -1450- ADD 1 TO AC-DESP-PRODUTO */
                        WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                        /*" -1452- MOVE 'SEGURADO SEM DT.NASC NA V0SEGURAVG' TO RD-DES-MOTIVO */
                        _.Move("SEGURADO SEM DT.NASC NA V0SEGURAVG", WS_MOVDESP.RD_DES_MOTIVO);

                        /*" -1453- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                        M_8200_GRAVA_MOVDESP(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                        /*" -1454- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1455- ELSE */
                    }
                    else
                    {


                        /*" -1456- DISPLAY 'ERRO ACESSO SEGUROS.V0SEGURAVG 2' */
                        _.Display($"ERRO ACESSO SEGUROS.V0SEGURAVG 2");

                        /*" -1457- DISPLAY 'NUM_APOLICE     =' PROPVA-NUM-APOLICE */
                        _.Display($"NUM_APOLICE     ={PROPVA_NUM_APOLICE}");

                        /*" -1458- DISPLAY 'COD_SUBGRUPO    =' PROPVA-CODSUBES */
                        _.Display($"COD_SUBGRUPO    ={PROPVA_CODSUBES}");

                        /*" -1459- DISPLAY 'NUM_CERTIFICADO =' PROPVA-NRCERTIF */
                        _.Display($"NUM_CERTIFICADO ={PROPVA_NRCERTIF}");

                        /*" -1460- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -1461- END-IF */
                    }


                    /*" -1462- ELSE */
                }
                else
                {


                    /*" -1463- IF SEGURA-DTNASC-I LESS ZEROS */

                    if (SEGURA_DTNASC_I < 00)
                    {

                        /*" -1464- ADD 1 TO AC-DESP-PRODUTO */
                        WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                        /*" -1466- MOVE 'DATA NASC. NULO NA V0SEGURAVG' TO RD-DES-MOTIVO */
                        _.Move("DATA NASC. NULO NA V0SEGURAVG", WS_MOVDESP.RD_DES_MOTIVO);

                        /*" -1467- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                        M_8200_GRAVA_MOVDESP(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                        /*" -1468- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1469- END-IF */
                    }


                    /*" -1470- END-IF */
                }


                /*" -1472- END-IF. */
            }


            /*" -1473- MOVE 'SELECT V0COBERPROPVA 1' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1475- PERFORM 0120-SELECT-V0COBERPROPVA THRU 0120-FIM. */

            M_0120_SELECT_V0COBERPROPVA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_FIM*/


            /*" -1476- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1477- ADD 1 TO AC-DESP-PRODUTO */
                WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                /*" -1479- MOVE 'CERTIFICADO SEM COBERTURA VIGENTE' TO RD-DES-MOTIVO */
                _.Move("CERTIFICADO SEM COBERTURA VIGENTE", WS_MOVDESP.RD_DES_MOTIVO);

                /*" -1480- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -1481- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -1487- END-IF. */
            }


            /*" -1489- IF COBERP-IMPMORNATU-ANT EQUAL ZEROS AND COBERP-IMPMORACID-ANT EQUAL ZEROS */

            if (COBERP_IMPMORNATU_ANT == 00 && COBERP_IMPMORACID_ANT == 00)
            {

                /*" -1490- ADD 1 TO AC-DESP-PRODUTO */
                WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                /*" -1492- MOVE 'IMPORTANCIAS ZERADAS NA V0COBERPROPVA' TO RD-DES-MOTIVO */
                _.Move("IMPORTANCIAS ZERADAS NA V0COBERPROPVA", WS_MOVDESP.RD_DES_MOTIVO);

                /*" -1493- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -1494- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -1496- END-IF. */
            }


            /*" -1498- IF COBERP-PRMVG-ANT EQUAL ZEROS AND COBERP-PRMAP-ANT EQUAL ZEROS */

            if (COBERP_PRMVG_ANT == 00 && COBERP_PRMAP_ANT == 00)
            {

                /*" -1499- ADD 1 TO AC-DESP-PRODUTO */
                WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                /*" -1501- MOVE 'PREMIOS VG/AP ZERADOS NA V0COBERPROPVA' TO RD-DES-MOTIVO */
                _.Move("PREMIOS VG/AP ZERADOS NA V0COBERPROPVA", WS_MOVDESP.RD_DES_MOTIVO);

                /*" -1502- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -1503- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -1505- END-IF. */
            }


            /*" -1507- MOVE 'NAO' TO WTEM-REENQUADRAMENTO. */
            _.Move("NAO", WTEM_REENQUADRAMENTO);

            /*" -1508- IF PRODVG-TEM-FAIXAETA EQUAL 'S' */

            if (PRODVG_TEM_FAIXAETA == "S")
            {

                /*" -1509- PERFORM 0130-VERIFICA-MUDANCA THRU 0130-FIM */

                M_0130_VERIFICA_MUDANCA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_FIM*/


                /*" -1516- END-IF. */
            }


            /*" -1517- MOVE 'SELECT MOVIMENTO_VGAP ' TO COMANDO. */
            _.Move("SELECT MOVIMENTO_VGAP ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1531- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_8 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_8();

            /*" -1534- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1535- DISPLAY 'ERRO ACESSO MOVIMENTO_VGAP' */
                _.Display($"ERRO ACESSO MOVIMENTO_VGAP");

                /*" -1536- DISPLAY 'NUM_APOLICE     =' PROPVA-NUM-APOLICE */
                _.Display($"NUM_APOLICE     ={PROPVA_NUM_APOLICE}");

                /*" -1537- DISPLAY 'COD_SUBGRUPO    =' PROPVA-CODSUBES */
                _.Display($"COD_SUBGRUPO    ={PROPVA_CODSUBES}");

                /*" -1538- DISPLAY 'NUM_CERTIFICADO =' PROPVA-NRCERTIF */
                _.Display($"NUM_CERTIFICADO ={PROPVA_NRCERTIF}");

                /*" -1539- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1541- END-IF. */
            }


            /*" -1544- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1546- IF MIMP-MORNATU-ATU EQUAL ZEROS AND MIMP-MORACID-ATU EQUAL ZEROS */

                if (MIMP_MORNATU_ATU == 00 && MIMP_MORACID_ATU == 00)
                {

                    /*" -1547- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -1549- MOVE 'IMPORTANCIAS ZERADAS NA MOVIMENTO_VGAP' TO RD-DES-MOTIVO */
                    _.Move("IMPORTANCIAS ZERADAS NA MOVIMENTO_VGAP", WS_MOVDESP.RD_DES_MOTIVO);

                    /*" -1550- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -1551- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1553- END-IF */
                }


                /*" -1555- IF MPRM-VG-ATU EQUAL ZEROS AND MPRM-AP-ATU EQUAL ZEROS */

                if (MPRM_VG_ATU == 00 && MPRM_AP_ATU == 00)
                {

                    /*" -1556- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -1558- MOVE 'PREMIOS VG/AP ZERADOS NA MOVIMENTO_VGAP' TO RD-DES-MOTIVO */
                    _.Move("PREMIOS VG/AP ZERADOS NA MOVIMENTO_VGAP", WS_MOVDESP.RD_DES_MOTIVO);

                    /*" -1559- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -1560- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1561- END-IF */
                }


                /*" -1563- END-IF. */
            }


            /*" -1565- MOVE ZEROS TO VALOR-AP. */
            _.Move(0, VALOR_AP);

            /*" -1568- COMPUTE VALOR-AP = COBERP-IMPMORACID-ANT - COBERP-IMPMORNATU-ANT. */
            VALOR_AP.Value = COBERP_IMPMORACID_ANT - COBERP_IMPMORNATU_ANT;

            /*" -1570- IF (VALOR-AP NOT LESS ZEROS) AND (VALOR-AP NOT GREATER 01) */

            if ((VALOR_AP >= 00) && (VALOR_AP <= 01))
            {

                /*" -1572- COMPUTE COBERP-PRMVG-ANT = COBERP-PRMVG-ANT + COBERP-PRMAP-ANT */
                COBERP_PRMVG_ANT.Value = COBERP_PRMVG_ANT + COBERP_PRMAP_ANT;

                /*" -1573- MOVE ZEROS TO COBERP-PRMAP-ANT */
                _.Move(0, COBERP_PRMAP_ANT);

                /*" -1575- END-IF. */
            }


            /*" -1576- IF COBERP-PRMDIT-I LESS ZEROS */

            if (COBERP_PRMDIT_I < 00)
            {

                /*" -1577- MOVE ZEROS TO COBERP-PRMDIT-ANT */
                _.Move(0, COBERP_PRMDIT_ANT);

                /*" -1579- END-IF. */
            }


            /*" -1580- IF COBERP-VLCUSTAUXF-I LESS ZEROS */

            if (COBERP_VLCUSTAUXF_I < 00)
            {

                /*" -1581- MOVE ZEROS TO COBERP-VLCUSTAUXF */
                _.Move(0, COBERP_VLCUSTAUXF);

                /*" -1583- END-IF. */
            }


            /*" -1585- MOVE 'N' TO FLAG-IGPM */
            _.Move("N", FLAG_IGPM);

            /*" -1600- PERFORM 0300-CORRIGE-IGPM THRU 0300-FIM. */

            M_0300_CORRIGE_IGPM(true);

            M_0300_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/


            /*" -1606- IF (PROPVA-NRCERTIF EQUAL 84500172740 OR 84822343100 OR 84825053642 OR 84824198582 OR 84820787770 OR 84820368190 OR 83511130000931 OR 10568110000272 OR 84820363856 OR 10001759026 OR 10001756277 OR 10163130002363) */

            if ((PROPVA_NRCERTIF.In("84500172740", "84822343100", "84825053642", "84824198582", "84820787770", "84820368190", "83511130000931", "10568110000272", "84820363856", "10001759026", "10001756277", "10163130002363")))
            {

                /*" -1607- MOVE 'NAO' TO WTEM-REENQUADRAMENTO */
                _.Move("NAO", WTEM_REENQUADRAMENTO);

                /*" -1614- END-IF. */
            }


            /*" -1615- IF WTEM-REENQUADRAMENTO EQUAL 'SIM' */

            if (WTEM_REENQUADRAMENTO == "SIM")
            {

                /*" -1619- IF (PROPVA-NUM-APOLICE EQUAL 109300000559 OR 3009300000559 OR 3009300001559 OR 109300000680) */

                if ((PROPVA_NUM_APOLICE.In("109300000559", "3009300000559", "3009300001559", "109300000680")))
                {

                    /*" -1620- PERFORM 1000-MUDA-FAIXA-ETARIA THRU 1000-FIM */

                    M_1000_MUDA_FAIXA_ETARIA(true);

                    M_1000_PROPAUTOM(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/


                    /*" -1621- ELSE */
                }
                else
                {


                    /*" -1622- PERFORM 2000-MUDA-FAIXA-ETARIA THRU 2000-FIM */

                    M_2000_MUDA_FAIXA_ETARIA(true);

                    M_2000_PROPAUTOM(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/


                    /*" -1623- END-IF */
                }


                /*" -1625- END-IF. */
            }


            /*" -1627- MOVE PROPVA-NRCERTIF TO CSP-NRCERTIF */
            _.Move(PROPVA_NRCERTIF, CSP_NRCERTIF);

            /*" -1633- INITIALIZE H-OUT-COD-RETORNO , H-OUT-COD-RETORNO-SQL, H-OUT-MENSAGEM , H-OUT-SQLERRMC , H-OUT-SQLSTATE . */
            _.Initialize(
                H_OUT_COD_RETORNO
                , H_OUT_COD_RETORNO_SQL
                , H_OUT_MENSAGEM
                , H_OUT_SQLERRMC
                , H_OUT_SQLSTATE
            );

            /*" -1640- CALL 'VG9020S' USING CSP-NRCERTIF , H-OUT-COD-RETORNO , H-OUT-COD-RETORNO-SQL, H-OUT-MENSAGEM , H-OUT-SQLERRMC , H-OUT-SQLSTATE . */
            _.Call("VG9020S", CSP_NRCERTIF, H_OUT_COD_RETORNO, H_OUT_COD_RETORNO_SQL, H_OUT_MENSAGEM, H_OUT_SQLERRMC, H_OUT_SQLSTATE, JVBKINCL.FILLER);

            /*" -1641- IF H-OUT-COD-RETORNO GREATER ZEROS */

            if (H_OUT_COD_RETORNO > 00)
            {

                /*" -1643- DISPLAY 'ERRO VG9020S - CERTIF ' PROPVA-NRCERTIF ' - ' H-OUT-MENSAGEM */

                $"ERRO VG9020S - CERTIF {PROPVA_NRCERTIF} - {H_OUT_MENSAGEM}"
                .Display();

                /*" -1645- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1646- PERFORM 8100-GRAVA-MOVCORRIG THRU 8100-FIM */

            M_8100_GRAVA_MOVCORRIG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8100_FIM*/


            /*" -1647- ADD 1 TO AC-IGPM */
            WS_WORK_AREAS.AC_IGPM.Value = WS_WORK_AREAS.AC_IGPM + 1;

            /*" -1648- IF PROPVA-TEM-ANTECIP EQUAL '2' */

            if (PROPVA_TEM_ANTECIP == "2")
            {

                /*" -1649- ADD 1 TO AC-IGPM-2 */
                WS_WORK_AREAS.AC_IGPM_2.Value = WS_WORK_AREAS.AC_IGPM_2 + 1;

                /*" -1650- ELSE */
            }
            else
            {


                /*" -1651- ADD 1 TO AC-IGPM-1 */
                WS_WORK_AREAS.AC_IGPM_1.Value = WS_WORK_AREAS.AC_IGPM_1 + 1;

                /*" -1653- END-IF. */
            }


            /*" -1653- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -1217- EXEC SQL SELECT PERIPGTO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB INTO :OPCAOP-PERIPGTO, :OPCAOP-AGECTADEB:INDAGE, :OPCAOP-OPRCTADEB:INDOPR, :OPCAOP-NUMCTADEB:INDNUM, :OPCAOP-DIGCTADEB:INDDIG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCAOP_PERIPGTO, OPCAOP_PERIPGTO);
                _.Move(executed_1.OPCAOP_AGECTADEB, OPCAOP_AGECTADEB);
                _.Move(executed_1.INDAGE, INDAGE);
                _.Move(executed_1.OPCAOP_OPRCTADEB, OPCAOP_OPRCTADEB);
                _.Move(executed_1.INDOPR, INDOPR);
                _.Move(executed_1.OPCAOP_NUMCTADEB, OPCAOP_NUMCTADEB);
                _.Move(executed_1.INDNUM, INDNUM);
                _.Move(executed_1.OPCAOP_DIGCTADEB, OPCAOP_DIGCTADEB);
                _.Move(executed_1.INDDIG, INDDIG);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -1657- PERFORM 0110-FETCH-PROPOSTAS THRU 0110-FIM. */

            M_0110_FETCH_PROPOSTAS(true);

            M_0110_CONTINUA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -1264- EXEC SQL SELECT NUM_ITEM, FAIXA, TAXA_VG, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, SIT_REGISTRO, LOT_EMP_SEGURADO, OCORR_HISTORICO INTO :SEGURA-NUM-ITEM, :SEGURA-FAIXA, :SEGURA-TXVG, :SEGURA-TXAPMA, :SEGURA-TXAPIP, :SEGURA-TXAPAMDS, :SEGURA-TXAPDH, :SEGURA-TXAPDIT, :SEGURA-SIT-REGISTRO, :SEGURA-LOT-EMP-SEGURADO:WLOT-EMP-SEGURADO, :SEGURA-OCORHIST FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES AND NUM_CERTIFICADO = :PROPVA-NRCERTIF AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURA_NUM_ITEM, SEGURA_NUM_ITEM);
                _.Move(executed_1.SEGURA_FAIXA, SEGURA_FAIXA);
                _.Move(executed_1.SEGURA_TXVG, SEGURA_TXVG);
                _.Move(executed_1.SEGURA_TXAPMA, SEGURA_TXAPMA);
                _.Move(executed_1.SEGURA_TXAPIP, SEGURA_TXAPIP);
                _.Move(executed_1.SEGURA_TXAPAMDS, SEGURA_TXAPAMDS);
                _.Move(executed_1.SEGURA_TXAPDH, SEGURA_TXAPDH);
                _.Move(executed_1.SEGURA_TXAPDIT, SEGURA_TXAPDIT);
                _.Move(executed_1.SEGURA_SIT_REGISTRO, SEGURA_SIT_REGISTRO);
                _.Move(executed_1.SEGURA_LOT_EMP_SEGURADO, SEGURA_LOT_EMP_SEGURADO);
                _.Move(executed_1.WLOT_EMP_SEGURADO, WLOT_EMP_SEGURADO);
                _.Move(executed_1.SEGURA_OCORHIST, SEGURA_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -1310- EXEC SQL SELECT DATA_MOVIMENTO, DATA_MOVIMENTO + 1 DAY INTO :HISTSG-DTMOVTO-DTTERVIG, :HISTSG-DTMOVTO-1DAY FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :SEGURA-NUM-ITEM AND OCORR_HISTORICO = :SEGURA-OCORHIST WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SEGURA_NUM_ITEM = SEGURA_NUM_ITEM.ToString(),
                SEGURA_OCORHIST = SEGURA_OCORHIST.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSG_DTMOVTO_DTTERVIG, HISTSG_DTMOVTO_DTTERVIG);
                _.Move(executed_1.HISTSG_DTMOVTO_1DAY, HISTSG_DTMOVTO_1DAY);
            }


        }

        [StopWatch]
        /*" M-0109-DECLARE-PROPOSTAS */
        private void M_0109_DECLARE_PROPOSTAS(bool isPerform = false)
        {
            /*" -1694- MOVE '0109-DECLARE-PROPOSTAS' TO PARAGRAFO. */
            _.Move("0109-DECLARE-PROPOSTAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1696- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1794- PERFORM M_0109_DECLARE_PROPOSTAS_DB_DECLARE_1 */

            M_0109_DECLARE_PROPOSTAS_DB_DECLARE_1();

            /*" -1806- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1806- PERFORM M_0109_DECLARE_PROPOSTAS_DB_OPEN_1 */

            M_0109_DECLARE_PROPOSTAS_DB_OPEN_1();

            /*" -1809- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1810- DISPLAY 'ERRO OPEN CURSOR CPROPVA' */
                _.Display($"ERRO OPEN CURSOR CPROPVA");

                /*" -1811- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1811- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0109-DECLARE-PROPOSTAS-DB-OPEN-1 */
        public void M_0109_DECLARE_PROPOSTAS_DB_OPEN_1()
        {
            /*" -1806- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0410-00-DECLARE-VGHISTRAMCOB-DB-DECLARE-1 */
        public void M_0410_00_DECLARE_VGHISTRAMCOB_DB_DECLARE_1()
        {
            /*" -2830- EXEC SQL DECLARE VGHISRAMC CURSOR FOR SELECT NUM_CERTIFICADO, NUM_RAMO, NUM_COBERTURA, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_HIST_RAMO_COB WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND OCORR_HISTORICO = :COBERP-OCORHIST-ANT ORDER BY NUM_RAMO, NUM_COBERTURA WITH UR END-EXEC. */
            VGHISRAMC = new VA0130B_VGHISRAMC(true);
            string GetQuery_VGHISRAMC()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							NUM_RAMO
							, 
							NUM_COBERTURA
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_HIST_RAMO_COB 
							WHERE NUM_CERTIFICADO = '{PROPVA_NRCERTIF}' 
							AND OCORR_HISTORICO = '{COBERP_OCORHIST_ANT}' 
							ORDER BY NUM_RAMO
							, 
							NUM_COBERTURA";

                return query;
            }
            VGHISRAMC.GetQueryEvent += GetQuery_VGHISRAMC;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -1333- EXEC SQL SELECT VALUE(MAX(OCORR_HISTORICO),0) INTO :HISTSG-OCORHIST FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :SEGURA-NUM-ITEM AND COD_OPERACAO = 895 WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SEGURA_NUM_ITEM = SEGURA_NUM_ITEM.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSG_OCORHIST, HISTSG_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0109_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -1352- EXEC SQL SELECT DATA_MOVIMENTO INTO :HISTSG-DTMOVTO-1YEAR FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :SEGURA-NUM-ITEM AND OCORR_HISTORICO = :HISTSG-OCORHIST WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SEGURA_NUM_ITEM = SEGURA_NUM_ITEM.ToString(),
                HISTSG_OCORHIST = HISTSG_OCORHIST.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSG_DTMOVTO_1YEAR, HISTSG_DTMOVTO_1YEAR);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-PROPOSTAS */
        private void M_0110_FETCH_PROPOSTAS(bool isPerform = false)
        {
            /*" -1828- MOVE '0110-FETCH-PROPOSTAS' TO PARAGRAFO. */
            _.Move("0110-FETCH-PROPOSTAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1830- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1865- PERFORM M_0110_FETCH_PROPOSTAS_DB_FETCH_1 */

            M_0110_FETCH_PROPOSTAS_DB_FETCH_1();

            /*" -1868- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1869- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1870- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -1871- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1871- PERFORM M_0110_FETCH_PROPOSTAS_DB_CLOSE_1 */

                    M_0110_FETCH_PROPOSTAS_DB_CLOSE_1();

                    /*" -1873- GO TO 0110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;

                    /*" -1874- ELSE */
                }
                else
                {


                    /*" -1875- DISPLAY 'ERRO FETCH CPROPVA' */
                    _.Display($"ERRO FETCH CPROPVA");

                    /*" -1876- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1877- END-IF */
                }


                /*" -1879- END-IF. */
            }


            /*" -1881- ADD 1 TO AC-MOVSELE. */
            WS_WORK_AREAS.AC_MOVSELE.Value = WS_WORK_AREAS.AC_MOVSELE + 1;

            /*" -1882- IF PROPVA-TEM-ANTECIP = '2' */

            if (PROPVA_TEM_ANTECIP == "2")
            {

                /*" -1883- ADD 1 TO AC-LIDOS-2 */
                WS_WORK_AREAS.AC_LIDOS_2.Value = WS_WORK_AREAS.AC_LIDOS_2 + 1;

                /*" -1884- ELSE */
            }
            else
            {


                /*" -1885- ADD 1 TO AC-LIDOS */
                WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

                /*" -1887- END-IF. */
            }


            /*" -1895- IF PROPVA-NUM-APOLICE EQUAL APOLICE-ANT AND PROPVA-CODSUBES EQUAL SUBGRUPO-ANT AND PROPVA-NRCERTIF EQUAL NRCERTIF-ANT */

            if (PROPVA_NUM_APOLICE == WS_WORK_AREAS.APOLICE_ANT && PROPVA_CODSUBES == WS_WORK_AREAS.SUBGRUPO_ANT && PROPVA_NRCERTIF == WS_WORK_AREAS.NRCERTIF_ANT)
            {

                /*" -1896- ADD 1 TO AC-DESP-JA-ATUAL */
                WS_WORK_AREAS.AC_DESP_JA_ATUAL.Value = WS_WORK_AREAS.AC_DESP_JA_ATUAL + 1;

                /*" -1897- IF PROPVA-TEM-ANTECIP = '2' */

                if (PROPVA_TEM_ANTECIP == "2")
                {

                    /*" -1898- ADD 1 TO AC-DESP-ATUAL-2 */
                    WS_WORK_AREAS.AC_DESP_ATUAL_2.Value = WS_WORK_AREAS.AC_DESP_ATUAL_2 + 1;

                    /*" -1899- ELSE */
                }
                else
                {


                    /*" -1900- ADD 1 TO AC-DESP-ATUAL-1 */
                    WS_WORK_AREAS.AC_DESP_ATUAL_1.Value = WS_WORK_AREAS.AC_DESP_ATUAL_1 + 1;

                    /*" -1901- END-IF */
                }


                /*" -1902- PERFORM 8000-GRAVA-MOVIMENTO THRU 8000-FIM */

                M_8000_GRAVA_MOVIMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


                /*" -1904- MOVE 'CERTIFICADO JA ATUALIZADO' TO RD-DES-MOTIVO */
                _.Move("CERTIFICADO JA ATUALIZADO", WS_MOVDESP.RD_DES_MOTIVO);

                /*" -1905- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -1906- GO TO 0110-FETCH-PROPOSTAS */
                new Task(() => M_0110_FETCH_PROPOSTAS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1908- END-IF. */
            }


            /*" -1910- MOVE PROPVA-NRCERTIF TO NRCERTIF-ANT. */
            _.Move(PROPVA_NRCERTIF, WS_WORK_AREAS.NRCERTIF_ANT);

            /*" -1912- IF PROPVA-NUM-APOLICE EQUAL APOLICE-ANT AND PROPVA-CODSUBES EQUAL SUBGRUPO-ANT */

            if (PROPVA_NUM_APOLICE == WS_WORK_AREAS.APOLICE_ANT && PROPVA_CODSUBES == WS_WORK_AREAS.SUBGRUPO_ANT)
            {

                /*" -1914- GO TO 0110-CONTINUA. */

                M_0110_CONTINUA(); //GOTO
                return;
            }


            /*" -1915- MOVE 'SIM' TO WS-PROCESSA-INDICE. */
            _.Move("SIM", WS_WORK_AREAS.WS_PROCESSA_INDICE);

            /*" -1916- MOVE ZEROS TO WS-SEM-IGPM. */
            _.Move(0, WS_SEM_IGPM);

            /*" -1917- MOVE PROPVA-NUM-APOLICE TO APOLICE-ANT */
            _.Move(PROPVA_NUM_APOLICE, WS_WORK_AREAS.APOLICE_ANT);

            /*" -1923- MOVE PROPVA-CODSUBES TO SUBGRUPO-ANT. */
            _.Move(PROPVA_CODSUBES, WS_WORK_AREAS.SUBGRUPO_ANT);

            /*" -1926- MOVE 'SELECT V0PRODUTOSVG' TO COMANDO */
            _.Move("SELECT V0PRODUTOSVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1949- PERFORM M_0110_FETCH_PROPOSTAS_DB_SELECT_1 */

            M_0110_FETCH_PROPOSTAS_DB_SELECT_1();

            /*" -1952- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1953- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1954- MOVE 'NAO' TO WS-PROCESSA-INDICE */
                    _.Move("NAO", WS_WORK_AREAS.WS_PROCESSA_INDICE);

                    /*" -1955- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -1957- MOVE 'SUBGRUPO NAO CADASTRADO' TO RD-DES-MOTIVO */
                    _.Move("SUBGRUPO NAO CADASTRADO", WS_MOVDESP.RD_DES_MOTIVO);

                    /*" -1958- GO TO 0110-CONTINUA */

                    M_0110_CONTINUA(); //GOTO
                    return;

                    /*" -1959- ELSE */
                }
                else
                {


                    /*" -1960- DISPLAY 'ERRO ACESSO V0PRODUTOSVG' */
                    _.Display($"ERRO ACESSO V0PRODUTOSVG");

                    /*" -1961- DISPLAY 'NUM_APOLICE     =' PROPVA-NUM-APOLICE */
                    _.Display($"NUM_APOLICE     ={PROPVA_NUM_APOLICE}");

                    /*" -1962- DISPLAY 'COD_SUBGRUPO    =' PROPVA-CODSUBES */
                    _.Display($"COD_SUBGRUPO    ={PROPVA_CODSUBES}");

                    /*" -1963- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1964- END-IF */
                }


                /*" -1966- END-IF. */
            }


            /*" -1967- IF VIND-TEM-CDG < ZEROS */

            if (VIND_TEM_CDG < 00)
            {

                /*" -1968- MOVE 'N' TO PRODVG-TEM-CDG */
                _.Move("N", PRODVG_TEM_CDG);

                /*" -1970- END-IF. */
            }


            /*" -1971- IF VIND-TEM-SAF < ZEROS */

            if (VIND_TEM_SAF < 00)
            {

                /*" -1972- MOVE 'N' TO PRODVG-TEM-SAF */
                _.Move("N", PRODVG_TEM_SAF);

                /*" -1974- END-IF. */
            }


            /*" -1975- IF VIND-TEM-IGPM < ZEROS */

            if (VIND_TEM_IGPM < 00)
            {

                /*" -1976- MOVE 'N' TO PRODVG-TEM-IGPM */
                _.Move("N", PRODVG_TEM_IGPM);

                /*" -1978- END-IF. */
            }


            /*" -1979- IF VIND-TEM-FAIXAETA < ZEROS */

            if (VIND_TEM_FAIXAETA < 00)
            {

                /*" -1980- MOVE 'N' TO PRODVG-TEM-FAIXAETA */
                _.Move("N", PRODVG_TEM_FAIXAETA);

                /*" -1982- END-IF. */
            }


            /*" -1983- IF PRODVG-TEM-IGPM NOT EQUAL 'S' */

            if (PRODVG_TEM_IGPM != "S")
            {

                /*" -1984- PERFORM 8000-GRAVA-MOVIMENTO THRU 8000-FIM */

                M_8000_GRAVA_MOVIMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


                /*" -1985- MOVE 'NAO' TO WS-PROCESSA-INDICE */
                _.Move("NAO", WS_WORK_AREAS.WS_PROCESSA_INDICE);

                /*" -1986- MOVE 1 TO WS-SEM-IGPM */
                _.Move(1, WS_SEM_IGPM);

                /*" -1988- MOVE 'PRODUTO SEM CORRECAO IGPM' TO RD-DES-MOTIVO */
                _.Move("PRODUTO SEM CORRECAO IGPM", WS_MOVDESP.RD_DES_MOTIVO);

                /*" -1989- ADD 1 TO AC-SEM-IGPM */
                WS_WORK_AREAS.AC_SEM_IGPM.Value = WS_WORK_AREAS.AC_SEM_IGPM + 1;

                /*" -1990- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -1991- GO TO 0110-FETCH-PROPOSTAS */
                new Task(() => M_0110_FETCH_PROPOSTAS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1993- END-IF. */
            }


            /*" -1993- PERFORM 0040-SELECT-VG-INDICE THRU 0040-FIM. */

            M_0040_SELECT_VG_INDICE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_FIM*/


        }

        [StopWatch]
        /*" M-0110-FETCH-PROPOSTAS-DB-FETCH-1 */
        public void M_0110_FETCH_PROPOSTAS_DB_FETCH_1()
        {
            /*" -1865- EXEC SQL FETCH CPROPVA INTO :PROPVA-TEM-ANTECIP, :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-NRCERTIF, :PROPVA-CODCLIEN, :PROPVA-OCOREND, :PROPVA-FONTE, :PROPVA-AGECOBR, :PROPVA-OPCAO-COBER, :PROPVA-DTPROXVEN, :PROPVA-DTPROXVEN-1, :PROPVA-NRPARCEL, :PROPVA-CODOPER, :PROPVA-DTMOVTO, :PROPVA-OCORHIST, :PROPVA-SIT-INTERF, :PROPVA-TIMESTAMP, :PROPVA-SEXO, :PROPVA-EST-CIV, :PROPVA-DTQITBCO-1YEAR, :PROPVA-DTQITBCO, :PROPVA-IDADE, :PROPVA-CODPRODU, :PROPVA-STA-ANTECIPACAO, :PROPVA-STA-MUDANCA-PLANO END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPVA_TEM_ANTECIP, PROPVA_TEM_ANTECIP);
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
                _.Move(CPROPVA.PROPVA_CODCLIEN, PROPVA_CODCLIEN);
                _.Move(CPROPVA.PROPVA_OCOREND, PROPVA_OCOREND);
                _.Move(CPROPVA.PROPVA_FONTE, PROPVA_FONTE);
                _.Move(CPROPVA.PROPVA_AGECOBR, PROPVA_AGECOBR);
                _.Move(CPROPVA.PROPVA_OPCAO_COBER, PROPVA_OPCAO_COBER);
                _.Move(CPROPVA.PROPVA_DTPROXVEN, PROPVA_DTPROXVEN);
                _.Move(CPROPVA.PROPVA_DTPROXVEN_1, PROPVA_DTPROXVEN_1);
                _.Move(CPROPVA.PROPVA_NRPARCEL, PROPVA_NRPARCEL);
                _.Move(CPROPVA.PROPVA_CODOPER, PROPVA_CODOPER);
                _.Move(CPROPVA.PROPVA_DTMOVTO, PROPVA_DTMOVTO);
                _.Move(CPROPVA.PROPVA_OCORHIST, PROPVA_OCORHIST);
                _.Move(CPROPVA.PROPVA_SIT_INTERF, PROPVA_SIT_INTERF);
                _.Move(CPROPVA.PROPVA_TIMESTAMP, PROPVA_TIMESTAMP);
                _.Move(CPROPVA.PROPVA_SEXO, PROPVA_SEXO);
                _.Move(CPROPVA.PROPVA_EST_CIV, PROPVA_EST_CIV);
                _.Move(CPROPVA.PROPVA_DTQITBCO_1YEAR, PROPVA_DTQITBCO_1YEAR);
                _.Move(CPROPVA.PROPVA_DTQITBCO, PROPVA_DTQITBCO);
                _.Move(CPROPVA.PROPVA_IDADE, PROPVA_IDADE);
                _.Move(CPROPVA.PROPVA_CODPRODU, PROPVA_CODPRODU);
                _.Move(CPROPVA.PROPVA_STA_ANTECIPACAO, PROPVA_STA_ANTECIPACAO);
                _.Move(CPROPVA.PROPVA_STA_MUDANCA_PLANO, PROPVA_STA_MUDANCA_PLANO);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-PROPOSTAS-DB-CLOSE-1 */
        public void M_0110_FETCH_PROPOSTAS_DB_CLOSE_1()
        {
            /*" -1871- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0110-FETCH-PROPOSTAS-DB-SELECT-1 */
        public void M_0110_FETCH_PROPOSTAS_DB_SELECT_1()
        {
            /*" -1949- EXEC SQL SELECT TEM_IGPM, TEM_FAIXAETA, RAMO, COBERADIC_PREMIO, CUSTOCAP_TOTAL, TEM_CDG, TEM_SAF, CODPRODU, NOMPRODU INTO :PRODVG-TEM-IGPM:VIND-TEM-IGPM, :PRODVG-TEM-FAIXAETA:VIND-TEM-FAIXAETA, :PRODVG-RAMO, :PRODVG-COBERADIC-PREMIO, :PRODVG-CUSTOCAP-TOTAL, :PRODVG-TEM-CDG:VIND-TEM-CDG, :PRODVG-TEM-SAF:VIND-TEM-SAF, :PRODVG-COD-PRODUTO, :PRODVG-NOME-PRODUTO FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES WITH UR END-EXEC. */

            var m_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1 = new M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1.Execute(m_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODVG_TEM_IGPM, PRODVG_TEM_IGPM);
                _.Move(executed_1.VIND_TEM_IGPM, VIND_TEM_IGPM);
                _.Move(executed_1.PRODVG_TEM_FAIXAETA, PRODVG_TEM_FAIXAETA);
                _.Move(executed_1.VIND_TEM_FAIXAETA, VIND_TEM_FAIXAETA);
                _.Move(executed_1.PRODVG_RAMO, PRODVG_RAMO);
                _.Move(executed_1.PRODVG_COBERADIC_PREMIO, PRODVG_COBERADIC_PREMIO);
                _.Move(executed_1.PRODVG_CUSTOCAP_TOTAL, PRODVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.PRODVG_TEM_CDG, PRODVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.PRODVG_TEM_SAF, PRODVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.PRODVG_COD_PRODUTO, PRODVG_COD_PRODUTO);
                _.Move(executed_1.PRODVG_NOME_PRODUTO, PRODVG_NOME_PRODUTO);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-6 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_6()
        {
            /*" -1431- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:CLIENT-DTNASC-I FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }

        [StopWatch]
        /*" M-0110-CONTINUA */
        private void M_0110_CONTINUA(bool isPerform = false)
        {
            /*" -1999- PERFORM 8000-GRAVA-MOVIMENTO THRU 8000-FIM. */

            M_8000_GRAVA_MOVIMENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


            /*" -2002- IF WS-PROCESSA-INDICE = 'NAO' */

            if (WS_WORK_AREAS.WS_PROCESSA_INDICE == "NAO")
            {

                /*" -2003- IF WS-SEM-IGPM EQUAL 1 */

                if (WS_SEM_IGPM == 1)
                {

                    /*" -2004- ADD 1 TO AC-SEM-IGPM */
                    WS_WORK_AREAS.AC_SEM_IGPM.Value = WS_WORK_AREAS.AC_SEM_IGPM + 1;

                    /*" -2005- ELSE */
                }
                else
                {


                    /*" -2006- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -2007- END-IF */
                }


                /*" -2008- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -2009- GO TO 0110-FETCH-PROPOSTAS */

                M_0110_FETCH_PROPOSTAS(); //GOTO
                return;

                /*" -2016- END-IF. */
            }


            /*" -2020- IF (PROPVA-TEM-ANTECIP EQUAL '1' ) AND (PROPVA-STA-ANTECIPACAO EQUAL 'S' ) AND (PROPVA-CODPRODU NOT EQUAL 8209 AND JVPRD8209 AND 9343 AND JVPRD9343 ) */

            if ((PROPVA_TEM_ANTECIP == "1") && (PROPVA_STA_ANTECIPACAO == "S") && (!PROPVA_CODPRODU.In("8209", JVBKINCL.JV_PRODUTOS.JVPRD8209.ToString(), "9343", JVBKINCL.JV_PRODUTOS.JVPRD9343.ToString())))
            {

                /*" -2021- ADD 1 TO AC-NAO-MIGRADO */
                WS_WORK_AREAS.AC_NAO_MIGRADO.Value = WS_WORK_AREAS.AC_NAO_MIGRADO + 1;

                /*" -2023- MOVE 'CERTIFICADO NAO MIGRADO' TO RD-DES-MOTIVO */
                _.Move("CERTIFICADO NAO MIGRADO", WS_MOVDESP.RD_DES_MOTIVO);

                /*" -2024- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                M_8200_GRAVA_MOVDESP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                /*" -2026- GO TO 0110-FETCH-PROPOSTAS. */

                M_0110_FETCH_PROPOSTAS(); //GOTO
                return;
            }


            /*" -2028- IF (PROPVA-DTPROXVEN > SISTEMA-DTMOV01M) OR (PROPVA-DTPROXVEN < SISTEMA-DTMOV20D) */

            if ((PROPVA_DTPROXVEN > SISTEMA_DTMOV01M) || (PROPVA_DTPROXVEN < SISTEMA_DTMOV20D))
            {

                /*" -2029- IF (PROPVA-TEM-ANTECIP EQUAL '2' ) */

                if ((PROPVA_TEM_ANTECIP == "2"))
                {

                    /*" -2030- ADD 1 TO AC-PROXVEN-FORA */
                    WS_WORK_AREAS.AC_PROXVEN_FORA.Value = WS_WORK_AREAS.AC_PROXVEN_FORA + 1;

                    /*" -2031- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -2033- MOVE 'DTPROXVEN FORA PERIODO' TO RD-DES-MOTIVO */
                    _.Move("DTPROXVEN FORA PERIODO", WS_MOVDESP.RD_DES_MOTIVO);

                    /*" -2034- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -2035- GO TO 0110-FETCH-PROPOSTAS */

                    M_0110_FETCH_PROPOSTAS(); //GOTO
                    return;

                    /*" -2036- END-IF */
                }


                /*" -2036- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-7 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_7()
        {
            /*" -1445- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:SEGURA-DTNASC-I FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES AND NUM_CERTIFICADO = :PROPVA-NRCERTIF WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.SEGURA_DTNASC_I, SEGURA_DTNASC_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-8 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_8()
        {
            /*" -1531- EXEC SQL SELECT IMP_MORNATU_ATU , IMP_MORACID_ATU , PRM_VG_ATU , PRM_AP_ATU INTO :MIMP-MORNATU-ATU ,:MIMP-MORACID-ATU ,:MPRM-VG-ATU ,:MPRM-AP-ATU FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND COD_OPERACAO BETWEEN 700 AND 899 AND DATA_AVERBACAO IS NOT NULL AND DATA_INCLUSAO IS NULL END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MIMP_MORNATU_ATU, MIMP_MORNATU_ATU);
                _.Move(executed_1.MIMP_MORACID_ATU, MIMP_MORACID_ATU);
                _.Move(executed_1.MPRM_VG_ATU, MPRM_VG_ATU);
                _.Move(executed_1.MPRM_AP_ATU, MPRM_AP_ATU);
            }


        }

        [StopWatch]
        /*" M-0120-SELECT-V0COBERPROPVA */
        private void M_0120_SELECT_V0COBERPROPVA(bool isPerform = false)
        {
            /*" -2103- PERFORM M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -2106- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2107- DISPLAY 'ERRO ACESSO V0COBERPROPVA' */
                _.Display($"ERRO ACESSO V0COBERPROPVA");

                /*" -2108- DISPLAY 'NUM_CERTIFICADO =' PROPVA-NRCERTIF */
                _.Display($"NUM_CERTIFICADO ={PROPVA_NRCERTIF}");

                /*" -2109- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2109- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0120-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -2103- EXEC SQL SELECT IMPSEGUR, QUANT_VIDAS, IMPSEGIND, OPCAO_COBER, IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDC, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT, DTINIVIG, DTINIVIG + 1 DAY INTO :COBERP-IMPSEGUR-ANT, :COBERP-QUANT-VIDAS-ANT, :COBERP-IMPSEGIND-ANT, :COBERP-OPCAO-COBER-ANT, :COBERP-IMPMORNATU-ANT, :COBERP-IMPMORACID-ANT, :COBERP-IMPINVPERM-ANT, :COBERP-IMPAMDS-ANT, :COBERP-IMPDH-ANT, :COBERP-IMPDIT-ANT, :COBERP-VLPREMIO-ANT, :COBERP-PRMVG-ANT, :COBERP-PRMAP-ANT, :COBERP-QTTITCAP, :COBERP-VLTITCAP, :COBERP-VLCUSTCAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I, :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I, :COBERP-PRMDIT-ANT:COBERP-PRMDIT-I, :COBERP-QTDIT:COBERP-QTDIT-I, :COBERP-DTINIVIG-ANT, :COBERP-DTINIVIG-NEW FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = (SELECT MAX(T1.OCORHIST) FROM SEGUROS.V0COBERPROPVA T1 WHERE T1.NRCERTIF = :PROPVA-NRCERTIF AND T1.DTTERVIG = '9999-12-31' ) WITH UR END-EXEC. */

            var m_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(m_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_IMPSEGUR_ANT, COBERP_IMPSEGUR_ANT);
                _.Move(executed_1.COBERP_QUANT_VIDAS_ANT, COBERP_QUANT_VIDAS_ANT);
                _.Move(executed_1.COBERP_IMPSEGIND_ANT, COBERP_IMPSEGIND_ANT);
                _.Move(executed_1.COBERP_OPCAO_COBER_ANT, COBERP_OPCAO_COBER_ANT);
                _.Move(executed_1.COBERP_IMPMORNATU_ANT, COBERP_IMPMORNATU_ANT);
                _.Move(executed_1.COBERP_IMPMORACID_ANT, COBERP_IMPMORACID_ANT);
                _.Move(executed_1.COBERP_IMPINVPERM_ANT, COBERP_IMPINVPERM_ANT);
                _.Move(executed_1.COBERP_IMPAMDS_ANT, COBERP_IMPAMDS_ANT);
                _.Move(executed_1.COBERP_IMPDH_ANT, COBERP_IMPDH_ANT);
                _.Move(executed_1.COBERP_IMPDIT_ANT, COBERP_IMPDIT_ANT);
                _.Move(executed_1.COBERP_VLPREMIO_ANT, COBERP_VLPREMIO_ANT);
                _.Move(executed_1.COBERP_PRMVG_ANT, COBERP_PRMVG_ANT);
                _.Move(executed_1.COBERP_PRMAP_ANT, COBERP_PRMAP_ANT);
                _.Move(executed_1.COBERP_QTTITCAP, COBERP_QTTITCAP);
                _.Move(executed_1.COBERP_VLTITCAP, COBERP_VLTITCAP);
                _.Move(executed_1.COBERP_VLCUSTCAP, COBERP_VLCUSTCAP);
                _.Move(executed_1.COBERP_IMPSEGCDG, COBERP_IMPSEGCDG);
                _.Move(executed_1.COBERP_VLCUSTCDG, COBERP_VLCUSTCDG);
                _.Move(executed_1.COBERP_IMPSEGAUXF, COBERP_IMPSEGAUXF);
                _.Move(executed_1.COBERP_IMPSEGAUXF_I, COBERP_IMPSEGAUXF_I);
                _.Move(executed_1.COBERP_VLCUSTAUXF, COBERP_VLCUSTAUXF);
                _.Move(executed_1.COBERP_VLCUSTAUXF_I, COBERP_VLCUSTAUXF_I);
                _.Move(executed_1.COBERP_PRMDIT_ANT, COBERP_PRMDIT_ANT);
                _.Move(executed_1.COBERP_PRMDIT_I, COBERP_PRMDIT_I);
                _.Move(executed_1.COBERP_QTDIT, COBERP_QTDIT);
                _.Move(executed_1.COBERP_QTDIT_I, COBERP_QTDIT_I);
                _.Move(executed_1.COBERP_DTINIVIG_ANT, COBERP_DTINIVIG_ANT);
                _.Move(executed_1.COBERP_DTINIVIG_NEW, COBERP_DTINIVIG_NEW);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_FIM*/

        [StopWatch]
        /*" M-0130-VERIFICA-MUDANCA */
        private void M_0130_VERIFICA_MUDANCA(bool isPerform = false)
        {
            /*" -2119- MOVE '0130-VERIFICA-MUDANCA' TO PARAGRAFO. */
            _.Move("0130-VERIFICA-MUDANCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2120- MOVE CLIENT-DTNASC (1:4) TO WS-ANO-NASC */
            _.Move(CLIENT_DTNASC.Substring(1, 4), WS_ANO_NASC);

            /*" -2122- MOVE PROPVA-DTPROXVEN(1:4) TO WS-ANO-ATUAL */
            _.Move(PROPVA_DTPROXVEN.Substring(1, 4), WS_ANO_ATUAL);

            /*" -2124- COMPUTE WHOST-IDADE = WS-ANO-ATUAL - WS-ANO-NASC */
            WHOST_IDADE.Value = WS_ANO_ATUAL - WS_ANO_NASC;

            /*" -2125- IF CLIENT-DTNASC(6:5) GREATER PROPVA-DTPROXVEN(6:5) */

            if (CLIENT_DTNASC.Substring(6, 5) > PROPVA_DTPROXVEN.Substring(6, 5))
            {

                /*" -2126- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -2128- END-IF. */
            }


            /*" -2129- MOVE ZEROS TO PLAVAVGA-PCT-FAIXA-ETARIA. */
            _.Move(0, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA);

            /*" -2130- MOVE ZEROS TO PLAVAVGA-FAIXA. */
            _.Move(0, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA);

            /*" -2134- MOVE 9999 TO PLAVAVGA-IDADE-FINAL. */
            _.Move(9999, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IDADE_FINAL);

            /*" -2137- MOVE 'SELECT PLANOS_VA_VGAP 1' TO COMANDO. */
            _.Move("SELECT PLANOS_VA_VGAP 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2156- PERFORM M_0130_VERIFICA_MUDANCA_DB_SELECT_1 */

            M_0130_VERIFICA_MUDANCA_DB_SELECT_1();

            /*" -2159- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2160- DISPLAY 'ERRO ACESSO PLANOS_VA_VGAP' */
                _.Display($"ERRO ACESSO PLANOS_VA_VGAP");

                /*" -2161- DISPLAY 'NUM_CERTIFICADO =' PROPVA-NRCERTIF */
                _.Display($"NUM_CERTIFICADO ={PROPVA_NRCERTIF}");

                /*" -2162- DISPLAY 'NUM_APOLICE     =' PROPVA-NUM-APOLICE */
                _.Display($"NUM_APOLICE     ={PROPVA_NUM_APOLICE}");

                /*" -2163- DISPLAY 'COD_SUBGRUPO    =' PROPVA-CODSUBES */
                _.Display($"COD_SUBGRUPO    ={PROPVA_CODSUBES}");

                /*" -2164- DISPLAY 'OPCAO_COBER     =' PROPVA-OPCAO-COBER */
                _.Display($"OPCAO_COBER     ={PROPVA_OPCAO_COBER}");

                /*" -2165- DISPLAY 'IDADE           =' WHOST-IDADE */
                _.Display($"IDADE           ={WHOST_IDADE}");

                /*" -2166- DISPLAY 'PERIPGTO        =' OPCAOP-PERIPGTO */
                _.Display($"PERIPGTO        ={OPCAOP_PERIPGTO}");

                /*" -2167- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2169- END-IF. */
            }


            /*" -2170- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2173- MOVE 'SELECT PLANOS_VA_VGAP 2' TO COMANDO */
                _.Move("SELECT PLANOS_VA_VGAP 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2192- PERFORM M_0130_VERIFICA_MUDANCA_DB_SELECT_2 */

                M_0130_VERIFICA_MUDANCA_DB_SELECT_2();

                /*" -2195- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -2196- DISPLAY 'ERRO ACESSO PLANOS_VA_VGAP 2' */
                    _.Display($"ERRO ACESSO PLANOS_VA_VGAP 2");

                    /*" -2197- DISPLAY 'NUM_CERTIFICADO =' PROPVA-NRCERTIF */
                    _.Display($"NUM_CERTIFICADO ={PROPVA_NRCERTIF}");

                    /*" -2198- DISPLAY 'NUM_APOLICE     =' PROPVA-NUM-APOLICE */
                    _.Display($"NUM_APOLICE     ={PROPVA_NUM_APOLICE}");

                    /*" -2199- DISPLAY 'COD_SUBGRUPO    =' PROPVA-CODSUBES */
                    _.Display($"COD_SUBGRUPO    ={PROPVA_CODSUBES}");

                    /*" -2200- DISPLAY 'IMPMORNATU      =' COBERP-IMPMORNATU-ANT */
                    _.Display($"IMPMORNATU      ={COBERP_IMPMORNATU_ANT}");

                    /*" -2201- DISPLAY 'IDADE           =' WHOST-IDADE */
                    _.Display($"IDADE           ={WHOST_IDADE}");

                    /*" -2202- DISPLAY 'PERIPGTO        =' OPCAOP-PERIPGTO */
                    _.Display($"PERIPGTO        ={OPCAOP_PERIPGTO}");

                    /*" -2203- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2204- END-IF */
                }


                /*" -2206- END-IF. */
            }


            /*" -2207- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2208- MOVE ZEROS TO PLAVAVGA-PCT-FAIXA-ETARIA */
                _.Move(0, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA);

                /*" -2210- GO TO 0130-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_FIM*/ //GOTO
                return;
            }


            /*" -2211- IF PLAVAVGA-PCT-FAIXA-ETARIA EQUAL ZEROS */

            if (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA == 00)
            {

                /*" -2213- GO TO 0130-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_FIM*/ //GOTO
                return;
            }


            /*" -2216- COMPUTE PLAVAVGA-PCT-FAIXA-ETARIA = PLAVAVGA-PCT-FAIXA-ETARIA / 100 + 1 */
            PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA / 100f + 1;

            /*" -2218- IF (PLAVAVGA-FAIXA NOT EQUAL SEGURA-FAIXA) OR (PLAVAVGA-IDADE-FINAL EQUAL 999) */

            if ((PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA != SEGURA_FAIXA) || (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IDADE_FINAL == 999))
            {

                /*" -2219- MOVE 'SIM' TO WTEM-REENQUADRAMENTO */
                _.Move("SIM", WTEM_REENQUADRAMENTO);

                /*" -2219- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0130-VERIFICA-MUDANCA-DB-SELECT-1 */
        public void M_0130_VERIFICA_MUDANCA_DB_SELECT_1()
        {
            /*" -2156- EXEC SQL SELECT IDADE_FINAL , TAXAAP , FAIXA , PCT_FAIXA_ETARIA INTO :PLAVAVGA-IDADE-FINAL, :PLAVAVGA-TAXAAP , :PLAVAVGA-FAIXA , :PLAVAVGA-PCT-FAIXA-ETARIA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND DTINIVIG <= :SISTEMA-DTMOVABE AND DTTERVIG >= :SISTEMA-DTMOVABE AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO WITH UR END-EXEC. */

            var m_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1 = new M_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = M_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1.Execute(m_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLAVAVGA_IDADE_FINAL, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IDADE_FINAL);
                _.Move(executed_1.PLAVAVGA_TAXAAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_TAXAAP);
                _.Move(executed_1.PLAVAVGA_FAIXA, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA);
                _.Move(executed_1.PLAVAVGA_PCT_FAIXA_ETARIA, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_FIM*/

        [StopWatch]
        /*" M-0130-VERIFICA-MUDANCA-DB-SELECT-2 */
        public void M_0130_VERIFICA_MUDANCA_DB_SELECT_2()
        {
            /*" -2192- EXEC SQL SELECT IDADE_FINAL , TAXAAP , FAIXA , PCT_FAIXA_ETARIA INTO :PLAVAVGA-IDADE-FINAL, :PLAVAVGA-TAXAAP , :PLAVAVGA-FAIXA , :PLAVAVGA-PCT-FAIXA-ETARIA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND IMPMORNATU = :COBERP-IMPMORNATU-ANT AND DTINIVIG <= :SISTEMA-DTMOVABE AND DTTERVIG >= :SISTEMA-DTMOVABE AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO WITH UR END-EXEC */

            var m_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1 = new M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1()
            {
                COBERP_IMPMORNATU_ANT = COBERP_IMPMORNATU_ANT.ToString(),
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1.Execute(m_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLAVAVGA_IDADE_FINAL, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IDADE_FINAL);
                _.Move(executed_1.PLAVAVGA_TAXAAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_TAXAAP);
                _.Move(executed_1.PLAVAVGA_FAIXA, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA);
                _.Move(executed_1.PLAVAVGA_PCT_FAIXA_ETARIA, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA);
            }


        }

        [StopWatch]
        /*" M-0300-CORRIGE-IGPM */
        private void M_0300_CORRIGE_IGPM(bool isPerform = false)
        {
            /*" -2232- MOVE '0300-CORRIGE-IGPM' TO PARAGRAFO. */
            _.Move("0300-CORRIGE-IGPM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2234- MOVE 'UPDATE V0COBERPROPVA' TO COMANDO. */
            _.Move("UPDATE V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2236- COMPUTE COBERP-IMPMORNATU-ATU ROUNDED = COBERP-IMPMORNATU-ANT * WS-IGPM-ACUM. */
            COBERP_IMPMORNATU_ATU.Value = COBERP_IMPMORNATU_ANT * WS_WORK_AREAS.WS_IGPM_ACUM;

            /*" -2239- COMPUTE COBERP-IMPMORACID-ATU ROUNDED = COBERP-IMPMORACID-ANT * WS-IGPM-ACUM. */
            COBERP_IMPMORACID_ATU.Value = COBERP_IMPMORACID_ANT * WS_WORK_AREAS.WS_IGPM_ACUM;

            /*" -2240- IF COBERP-IMPMORNATU-ANT > ZEROS */

            if (COBERP_IMPMORNATU_ANT > 00)
            {

                /*" -2245- IF (COBERP-IMPMORNATU-ATU < COBERP-IMPMORNATU-ANT) OR (COBERP-IMPMORNATU-ATU = COBERP-IMPMORNATU-ANT) */

                if ((COBERP_IMPMORNATU_ATU < COBERP_IMPMORNATU_ANT) || (COBERP_IMPMORNATU_ATU == COBERP_IMPMORNATU_ANT))
                {

                    /*" -2246- MOVE COBERP-IMPMORNATU-ANT TO WS-VALOR1N */
                    _.Move(COBERP_IMPMORNATU_ANT, WS_VALOR1_A.WS_VALOR1N);

                    /*" -2247- MOVE COBERP-IMPMORNATU-ATU TO WS-VALOR2N */
                    _.Move(COBERP_IMPMORNATU_ATU, WS_VALOR2_A.WS_VALOR2N);

                    /*" -2251- STRING 'IMPMORNATU-ANT ' WS-VALOR1-A ' IMPMORNATU-ATU ' WS-VALOR2-A DELIMITED BY SIZE INTO RD-DES-MOTIVO */
                    #region STRING
                    var spl2 = "IMPMORNATU-ANT " + WS_VALOR1_A.GetMoveValues();
                    spl2 += " IMPMORNATU-ATU ";
                    var spl3 = WS_VALOR2_A.GetMoveValues();
                    var results4 = spl2 + spl3;
                    _.Move(results4, WS_MOVDESP.RD_DES_MOTIVO);
                    #endregion

                    /*" -2252- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -2253- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -2254- GO TO 0300-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/ //GOTO
                    return;

                    /*" -2255- END-IF */
                }


                /*" -2257- END-IF. */
            }


            /*" -2258- IF (COBERP-IMPMORACID-ANT > ZEROS) */

            if ((COBERP_IMPMORACID_ANT > 00))
            {

                /*" -2263- IF (COBERP-IMPMORACID-ATU < COBERP-IMPMORACID-ANT) OR (COBERP-IMPMORACID-ATU = COBERP-IMPMORACID-ANT) */

                if ((COBERP_IMPMORACID_ATU < COBERP_IMPMORACID_ANT) || (COBERP_IMPMORACID_ATU == COBERP_IMPMORACID_ANT))
                {

                    /*" -2264- MOVE COBERP-IMPMORACID-ANT TO WS-VALOR1N */
                    _.Move(COBERP_IMPMORACID_ANT, WS_VALOR1_A.WS_VALOR1N);

                    /*" -2265- MOVE COBERP-IMPMORACID-ATU TO WS-VALOR2N */
                    _.Move(COBERP_IMPMORACID_ATU, WS_VALOR2_A.WS_VALOR2N);

                    /*" -2269- STRING 'IMPMORACID-ANT ' WS-VALOR1-A ' IMPMORACID-ATU ' WS-VALOR2-A DELIMITED BY SIZE INTO RD-DES-MOTIVO */
                    #region STRING
                    var spl4 = "IMPMORACID-ANT " + WS_VALOR1_A.GetMoveValues();
                    spl4 += " IMPMORACID-ATU ";
                    var spl5 = WS_VALOR2_A.GetMoveValues();
                    var results6 = spl4 + spl5;
                    _.Move(results6, WS_MOVDESP.RD_DES_MOTIVO);
                    #endregion

                    /*" -2270- ADD 1 TO AC-DESP-PRODUTO */
                    WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                    /*" -2271- PERFORM 8200-GRAVA-MOVDESP THRU 8200-FIM */

                    M_8200_GRAVA_MOVDESP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/


                    /*" -2272- GO TO 0300-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/ //GOTO
                    return;

                    /*" -2273- END-IF */
                }


                /*" -2288- END-IF. */
            }


            /*" -2289- IF (COBERP-DTTERVIG-ANT < COBERP-DTINIVIG-ANT) */

            if ((COBERP_DTTERVIG_ANT < COBERP_DTINIVIG_ANT))
            {

                /*" -2290- MOVE COBERP-DTINIVIG-ANT TO COBERP-DTTERVIG */
                _.Move(COBERP_DTINIVIG_ANT, COBERP_DTTERVIG);

                /*" -2291- ELSE */
            }
            else
            {


                /*" -2292- MOVE COBERP-DTTERVIG-ANT TO COBERP-DTTERVIG */
                _.Move(COBERP_DTTERVIG_ANT, COBERP_DTTERVIG);

                /*" -2294- END-IF. */
            }


            /*" -2295- IF (SISTEMA-DTMAXALTIGPM < COBERP-DTINIVIG-NEW) */

            if ((SISTEMA_DTMAXALTIGPM < COBERP_DTINIVIG_NEW))
            {

                /*" -2296- MOVE COBERP-DTINIVIG-NEW TO COBERP-DTINIVIG */
                _.Move(COBERP_DTINIVIG_NEW, COBERP_DTINIVIG);

                /*" -2297- ELSE */
            }
            else
            {


                /*" -2298- MOVE SISTEMA-DTMAXALTIGPM TO COBERP-DTINIVIG */
                _.Move(SISTEMA_DTMAXALTIGPM, COBERP_DTINIVIG);

                /*" -2300- END-IF. */
            }


            /*" -2301- IF (HISTSG-DTMOVTO-1DAY > COBERP-DTINIVIG) */

            if ((HISTSG_DTMOVTO_1DAY > COBERP_DTINIVIG))
            {

                /*" -2302- MOVE HISTSG-DTMOVTO-1DAY TO COBERP-DTINIVIG */
                _.Move(HISTSG_DTMOVTO_1DAY, COBERP_DTINIVIG);

                /*" -2303- MOVE HISTSG-DTMOVTO-DTTERVIG TO COBERP-DTTERVIG */
                _.Move(HISTSG_DTMOVTO_DTTERVIG, COBERP_DTTERVIG);

                /*" -2309- END-IF. */
            }


            /*" -2310- IF PROPVA-TEM-ANTECIP EQUAL '2' */

            if (PROPVA_TEM_ANTECIP == "2")
            {

                /*" -2311- MOVE PROPVA-DTQITBCO TO W01DTSQL */
                _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

                /*" -2312- ADD 1 TO W01AASQL */
                WS_WORK_AREAS.W01DTSQL.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL.W01AASQL + 1;

                /*" -2313- MOVE 01 TO W01DDSQL */
                _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

                /*" -2314- MOVE W01DTSQL TO COBERP-DTINIVIG */
                _.Move(WS_WORK_AREAS.W01DTSQL, COBERP_DTINIVIG);

                /*" -2316- END-IF. */
            }


            /*" -2321- PERFORM M_0300_CORRIGE_IGPM_DB_UPDATE_1 */

            M_0300_CORRIGE_IGPM_DB_UPDATE_1();

            /*" -2324- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2325- DISPLAY 'ERRO UPDATE V0COBERPROPVA' */
                _.Display($"ERRO UPDATE V0COBERPROPVA");

                /*" -2326- DISPLAY 'NRCERTIF = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF = {PROPVA_NRCERTIF}");

                /*" -2327- DISPLAY 'OCORHIST = ' PROPVA-OCORHIST */
                _.Display($"OCORHIST = {PROPVA_OCORHIST}");

                /*" -2328- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2330- END-IF. */
            }


            /*" -2332- MOVE PROPVA-OCORHIST TO COBERP-OCORHIST-ANT. */
            _.Move(PROPVA_OCORHIST, COBERP_OCORHIST_ANT);

            /*" -2334- COMPUTE PROPVA-OCORHIST = PROPVA-OCORHIST + 1. */
            PROPVA_OCORHIST.Value = PROPVA_OCORHIST + 1;

            /*" -2336- MOVE 'UPDATE V0PROPOSTAVA' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2345- PERFORM M_0300_CORRIGE_IGPM_DB_UPDATE_2 */

            M_0300_CORRIGE_IGPM_DB_UPDATE_2();

            /*" -2348- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2349- DISPLAY 'ERRO UPDATE V0PROPOSTAVA' */
                _.Display($"ERRO UPDATE V0PROPOSTAVA");

                /*" -2350- DISPLAY 'NRCERTIF = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF = {PROPVA_NRCERTIF}");

                /*" -2351- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2353- END-IF. */
            }


            /*" -2355- COMPUTE COBERP-IMPINVPERM-ATU ROUNDED = COBERP-IMPINVPERM-ANT * WS-IGPM-ACUM. */
            COBERP_IMPINVPERM_ATU.Value = COBERP_IMPINVPERM_ANT * WS_WORK_AREAS.WS_IGPM_ACUM;

            /*" -2357- COMPUTE COBERP-IMPAMDS-ATU ROUNDED = COBERP-IMPAMDS-ANT * WS-IGPM-ACUM. */
            COBERP_IMPAMDS_ATU.Value = COBERP_IMPAMDS_ANT * WS_WORK_AREAS.WS_IGPM_ACUM;

            /*" -2359- COMPUTE COBERP-IMPDH-ATU ROUNDED = COBERP-IMPDH-ANT * WS-IGPM-ACUM. */
            COBERP_IMPDH_ATU.Value = COBERP_IMPDH_ANT * WS_WORK_AREAS.WS_IGPM_ACUM;

            /*" -2362- COMPUTE COBERP-IMPDIT-ATU ROUNDED = COBERP-IMPDIT-ANT * WS-IGPM-ACUM. */
            COBERP_IMPDIT_ATU.Value = COBERP_IMPDIT_ANT * WS_WORK_AREAS.WS_IGPM_ACUM;

            /*" -2369- MOVE COBERP-PRMVG-ANT TO COBERP-PRMVG-ATU. */
            _.Move(COBERP_PRMVG_ANT, COBERP_PRMVG_ATU);

            /*" -2371- COMPUTE COBERP-PRMVG-ATU ROUNDED = COBERP-PRMVG-ATU * WS-IGPM-ACUM. */
            COBERP_PRMVG_ATU.Value = COBERP_PRMVG_ATU * WS_WORK_AREAS.WS_IGPM_ACUM;

            /*" -2373- COMPUTE COBERP-PRMAP-ATU ROUNDED = COBERP-PRMAP-ANT * WS-IGPM-ACUM. */
            COBERP_PRMAP_ATU.Value = COBERP_PRMAP_ANT * WS_WORK_AREAS.WS_IGPM_ACUM;

            /*" -2380- COMPUTE COBERP-PRMDIT-ATU ROUNDED = COBERP-PRMDIT-ANT * WS-IGPM-ACUM. */
            COBERP_PRMDIT_ATU.Value = COBERP_PRMDIT_ANT * WS_WORK_AREAS.WS_IGPM_ACUM;

            /*" -2381- IF PRODVG-COBERADIC-PREMIO = 'S' */

            if (PRODVG_COBERADIC_PREMIO == "S")
            {

                /*" -2383- COMPUTE COBERP-VLPREMIO-ATU = COBERP-PRMVG-ATU + COBERP-PRMAP-ATU */
                COBERP_VLPREMIO_ATU.Value = COBERP_PRMVG_ATU + COBERP_PRMAP_ATU;

                /*" -2384- ELSE */
            }
            else
            {


                /*" -2387- COMPUTE COBERP-VLPREMIO-ATU = COBERP-PRMVG-ATU + COBERP-PRMAP-ATU + WS-GUARDA-PRMADIC */
                COBERP_VLPREMIO_ATU.Value = COBERP_PRMVG_ATU + COBERP_PRMAP_ATU + WS_WORK_AREAS.WS_GUARDA_PRMADIC;

                /*" -2390- END-IF. */
            }


            /*" -2391- MOVE COBERP-IMPMORNATU-ANT TO WS-CAPITAL-ANT */
            _.Move(COBERP_IMPMORNATU_ANT, WS_CAPITAL_ANT);

            /*" -2392- MOVE COBERP-VLPREMIO-ANT TO WS-PREMIO-ANT */
            _.Move(COBERP_VLPREMIO_ANT, WS_PREMIO_ANT);

            /*" -2393- MOVE COBERP-IMPMORNATU-ATU TO WS-CAPITAL-ATU */
            _.Move(COBERP_IMPMORNATU_ATU, WS_CAPITAL_ATU);

            /*" -2394- MOVE COBERP-VLPREMIO-ATU TO WS-PREMIO-ATU */
            _.Move(COBERP_VLPREMIO_ATU, WS_PREMIO_ATU);

            /*" -2395- MOVE COBERP-PRMVG-ATU TO WS-PRMVG-ATU */
            _.Move(COBERP_PRMVG_ATU, WS_PRMVG_ATU);

            /*" -2396- MOVE COBERP-PRMAP-ATU TO WS-PRMAP-ATU */
            _.Move(COBERP_PRMAP_ATU, WS_PRMAP_ATU);

            /*" -2398- MOVE COBERP-PRMDIT-ATU TO WS-PRMDIT-ATU */
            _.Move(COBERP_PRMDIT_ATU, WS_PRMDIT_ATU);

            /*" -2400- MOVE 'INSERT V0COBERPROPVA' TO COMANDO. */
            _.Move("INSERT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2460- PERFORM M_0300_CORRIGE_IGPM_DB_INSERT_1 */

            M_0300_CORRIGE_IGPM_DB_INSERT_1();

            /*" -2463- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2464- DISPLAY 'ERRO INSERT V0COBERPROPVA' */
                _.Display($"ERRO INSERT V0COBERPROPVA");

                /*" -2465- DISPLAY 'NRCERTIF = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF = {PROPVA_NRCERTIF}");

                /*" -2466- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2468- END-IF. */
            }


            /*" -2470- IF (INDAGE < ZEROS) OR (INDOPR < ZEROS) OR (INDNUM < ZEROS) OR (INDDIG < ZEROS) */

            if ((INDAGE < 00) || (INDOPR < 00) || (INDNUM < 00) || (INDDIG < 00))
            {

                /*" -2471- MOVE 0 TO MNUM-CTA-CORRENTE */
                _.Move(0, MNUM_CTA_CORRENTE);

                /*" -2472- MOVE ' ' TO MDAC-CTA-CORRENTE */
                _.Move(" ", MDAC_CTA_CORRENTE);

                /*" -2473- ELSE */
            }
            else
            {


                /*" -2474- MOVE OPCAOP-OPRCTADEB TO WS-OPER-SEG */
                _.Move(OPCAOP_OPRCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_OPER_SEG);

                /*" -2475- MOVE OPCAOP-NUMCTADEB TO WS-CTA-SEG */
                _.Move(OPCAOP_NUMCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_CTA_SEG);

                /*" -2476- MOVE WS-CTA-CORRENTE TO MNUM-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.WS_CTA_CORRENTE, MNUM_CTA_CORRENTE);

                /*" -2477- MOVE OPCAOP-DIGCTADEB TO W01N0100 */
                _.Move(OPCAOP_DIGCTADEB, WS_WORK_AREAS.W01A0100.W01N0100);

                /*" -2478- MOVE W01A0100 TO MDAC-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.W01A0100, MDAC_CTA_CORRENTE);

                /*" -2480- END-IF. */
            }


            /*" -2482- MOVE 'SELECT V0FONTE 1' TO COMANDO. */
            _.Move("SELECT V0FONTE 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2488- PERFORM M_0300_CORRIGE_IGPM_DB_SELECT_1 */

            M_0300_CORRIGE_IGPM_DB_SELECT_1();

            /*" -2491- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2492- DISPLAY 'ERRO SELECT V0FONTE' */
                _.Display($"ERRO SELECT V0FONTE");

                /*" -2493- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2495- END-IF. */
            }


            /*" -2497- IF PRODVG-RAMO = 93 OR COBERP-PRMAP-ANT = 0 */

            if (PRODVG_RAMO == 93 || COBERP_PRMAP_ANT == 0)
            {

                /*" -2501- MOVE 0 TO COBERP-IMPMORACID-ATU COBERP-IMPMORACID-ANT COBERP-IMPINVPERM-ATU COBERP-IMPINVPERM-ANT */
                _.Move(0, COBERP_IMPMORACID_ATU, COBERP_IMPMORACID_ANT, COBERP_IMPINVPERM_ATU, COBERP_IMPINVPERM_ANT);

                /*" -2503- END-IF. */
            }


            /*" -2506- IF (PRODVG-RAMO = 81) OR (PRODVG-RAMO = 82) OR (COBERP-PRMVG-ANT = 0 ) */

            if ((PRODVG_RAMO == 81) || (PRODVG_RAMO == 82) || (COBERP_PRMVG_ANT == 0))
            {

                /*" -2508- MOVE 0 TO COBERP-IMPMORNATU-ATU COBERP-IMPMORNATU-ANT */
                _.Move(0, COBERP_IMPMORNATU_ATU, COBERP_IMPMORNATU_ANT);

                /*" -2510- END-IF. */
            }


            /*" -2513- IF (PRODVG-RAMO = 97) OR ((COBERP-PRMVG-ANT > 0) AND (COBERP-PRMAP-ANT > 0)) */

            if ((PRODVG_RAMO == 97) || ((COBERP_PRMVG_ANT > 0) && (COBERP_PRMAP_ANT > 0)))
            {

                /*" -2515- COMPUTE COBERP-IMPMORACID-ATU = COBERP-IMPMORACID-ATU - COBERP-IMPMORNATU-ATU */
                COBERP_IMPMORACID_ATU.Value = COBERP_IMPMORACID_ATU - COBERP_IMPMORNATU_ATU;

                /*" -2517- COMPUTE COBERP-IMPMORACID-ANT = COBERP-IMPMORACID-ANT - COBERP-IMPMORNATU-ANT */
                COBERP_IMPMORACID_ANT.Value = COBERP_IMPMORACID_ANT - COBERP_IMPMORNATU_ANT;

                /*" -2520- COMPUTE RESIDUO = COBERP-IMPMORACID-ATU - COBERP-IMPMORNATU-ATU */
                RESIDUO.Value = COBERP_IMPMORACID_ATU - COBERP_IMPMORNATU_ATU;

                /*" -2522- IF (RESIDUO NOT LESS -0,05) AND (RESIDUO NOT GREATER 0,05) */

                if ((RESIDUO >= -0.05) && (RESIDUO <= 0.05))
                {

                    /*" -2523- MOVE COBERP-IMPMORNATU-ATU TO COBERP-IMPMORACID-ATU */
                    _.Move(COBERP_IMPMORNATU_ATU, COBERP_IMPMORACID_ATU);

                    /*" -2524- MOVE COBERP-IMPMORNATU-ANT TO COBERP-IMPMORACID-ANT */
                    _.Move(COBERP_IMPMORNATU_ANT, COBERP_IMPMORACID_ANT);

                    /*" -2525- END-IF */
                }


                /*" -2527- END-IF. */
            }


            /*" -2528- IF (WLOT-EMP-SEGURADO < ZEROS) */

            if ((WLOT_EMP_SEGURADO < 00))
            {

                /*" -2529- MOVE SPACES TO SEGURA-LOT-EMP-SEGURADO */
                _.Move("", SEGURA_LOT_EMP_SEGURADO);

                /*" -2529- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0300-CORRIGE-IGPM-DB-UPDATE-1 */
        public void M_0300_CORRIGE_IGPM_DB_UPDATE_1()
        {
            /*" -2321- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET DTTERVIG = DATE(:COBERP-DTINIVIG) - 1 DAY WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = :PROPVA-OCORHIST END-EXEC. */

            var m_0300_CORRIGE_IGPM_DB_UPDATE_1_Update1 = new M_0300_CORRIGE_IGPM_DB_UPDATE_1_Update1()
            {
                COBERP_DTINIVIG = COBERP_DTINIVIG.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_0300_CORRIGE_IGPM_DB_UPDATE_1_Update1.Execute(m_0300_CORRIGE_IGPM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0300-PROPAUTOM */
        private void M_0300_PROPAUTOM(bool isPerform = false)
        {
            /*" -2535- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

            /*" -2536- IF COBERP-IMPMORNATU-ANT LESS ZEROS */

            if (COBERP_IMPMORNATU_ANT < 00)
            {

                /*" -2537- MOVE ZEROS TO COBERP-IMPMORNATU-ANT */
                _.Move(0, COBERP_IMPMORNATU_ANT);

                /*" -2539- END-IF */
            }


            /*" -2540- IF COBERP-IMPMORNATU-ATU LESS ZEROS */

            if (COBERP_IMPMORNATU_ATU < 00)
            {

                /*" -2541- MOVE ZEROS TO COBERP-IMPMORNATU-ATU */
                _.Move(0, COBERP_IMPMORNATU_ATU);

                /*" -2543- END-IF */
            }


            /*" -2544- IF COBERP-IMPMORACID-ANT LESS ZEROS */

            if (COBERP_IMPMORACID_ANT < 00)
            {

                /*" -2545- MOVE ZEROS TO COBERP-IMPMORACID-ANT */
                _.Move(0, COBERP_IMPMORACID_ANT);

                /*" -2547- END-IF */
            }


            /*" -2548- IF COBERP-IMPMORACID-ATU LESS ZEROS */

            if (COBERP_IMPMORACID_ATU < 00)
            {

                /*" -2549- MOVE ZEROS TO COBERP-IMPMORACID-ATU */
                _.Move(0, COBERP_IMPMORACID_ATU);

                /*" -2551- END-IF */
            }


            /*" -2552- IF COBERP-IMPINVPERM-ANT LESS ZEROS */

            if (COBERP_IMPINVPERM_ANT < 00)
            {

                /*" -2553- MOVE ZEROS TO COBERP-IMPINVPERM-ANT */
                _.Move(0, COBERP_IMPINVPERM_ANT);

                /*" -2555- END-IF */
            }


            /*" -2556- IF COBERP-IMPINVPERM-ATU LESS ZEROS */

            if (COBERP_IMPINVPERM_ATU < 00)
            {

                /*" -2557- MOVE ZEROS TO COBERP-IMPINVPERM-ATU */
                _.Move(0, COBERP_IMPINVPERM_ATU);

                /*" -2559- END-IF */
            }


            /*" -2560- IF COBERP-IMPAMDS-ANT LESS ZEROS */

            if (COBERP_IMPAMDS_ANT < 00)
            {

                /*" -2561- MOVE ZEROS TO COBERP-IMPAMDS-ANT */
                _.Move(0, COBERP_IMPAMDS_ANT);

                /*" -2563- END-IF */
            }


            /*" -2564- IF COBERP-IMPAMDS-ATU LESS ZEROS */

            if (COBERP_IMPAMDS_ATU < 00)
            {

                /*" -2565- MOVE ZEROS TO COBERP-IMPAMDS-ATU */
                _.Move(0, COBERP_IMPAMDS_ATU);

                /*" -2567- END-IF */
            }


            /*" -2568- IF COBERP-IMPDH-ANT LESS ZEROS */

            if (COBERP_IMPDH_ANT < 00)
            {

                /*" -2569- MOVE ZEROS TO COBERP-IMPDH-ANT */
                _.Move(0, COBERP_IMPDH_ANT);

                /*" -2571- END-IF */
            }


            /*" -2572- IF COBERP-IMPDH-ATU LESS ZEROS */

            if (COBERP_IMPDH_ATU < 00)
            {

                /*" -2573- MOVE ZEROS TO COBERP-IMPDH-ATU */
                _.Move(0, COBERP_IMPDH_ATU);

                /*" -2575- END-IF */
            }


            /*" -2576- IF COBERP-IMPDIT-ANT LESS ZEROS */

            if (COBERP_IMPDIT_ANT < 00)
            {

                /*" -2577- MOVE ZEROS TO COBERP-IMPDIT-ANT */
                _.Move(0, COBERP_IMPDIT_ANT);

                /*" -2579- END-IF */
            }


            /*" -2580- IF COBERP-IMPDIT-ATU LESS ZEROS */

            if (COBERP_IMPDIT_ATU < 00)
            {

                /*" -2581- MOVE ZEROS TO COBERP-IMPDIT-ATU */
                _.Move(0, COBERP_IMPDIT_ATU);

                /*" -2583- END-IF */
            }


            /*" -2584- IF COBERP-PRMVG-ANT LESS ZEROS */

            if (COBERP_PRMVG_ANT < 00)
            {

                /*" -2585- MOVE ZEROS TO COBERP-PRMVG-ANT */
                _.Move(0, COBERP_PRMVG_ANT);

                /*" -2587- END-IF */
            }


            /*" -2588- IF COBERP-PRMVG-ATU LESS ZEROS */

            if (COBERP_PRMVG_ATU < 00)
            {

                /*" -2589- MOVE ZEROS TO COBERP-PRMVG-ATU */
                _.Move(0, COBERP_PRMVG_ATU);

                /*" -2591- END-IF */
            }


            /*" -2592- IF COBERP-PRMAP-ANT LESS ZEROS */

            if (COBERP_PRMAP_ANT < 00)
            {

                /*" -2593- MOVE ZEROS TO COBERP-PRMAP-ANT */
                _.Move(0, COBERP_PRMAP_ANT);

                /*" -2595- END-IF */
            }


            /*" -2596- IF COBERP-PRMAP-ATU LESS ZEROS */

            if (COBERP_PRMAP_ATU < 00)
            {

                /*" -2597- MOVE ZEROS TO COBERP-PRMAP-ATU */
                _.Move(0, COBERP_PRMAP_ATU);

                /*" -2599- END-IF */
            }


            /*" -2603- MOVE 'INSERT V0MOVIMENTO' TO COMANDO. */
            _.Move("INSERT V0MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2680- PERFORM M_0300_PROPAUTOM_DB_INSERT_1 */

            M_0300_PROPAUTOM_DB_INSERT_1();

            /*" -2683- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2687- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2688- GO TO 0300-PROPAUTOM */
                    new Task(() => M_0300_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2689- ELSE */
                }
                else
                {


                    /*" -2690- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -2691- DISPLAY 'VA0130B - ERRO INSERT DA V0MOVIMENTO' */
                    _.Display($"VA0130B - ERRO INSERT DA V0MOVIMENTO");

                    /*" -2693- DISPLAY '          APOLICE..........  ' PROPVA-NUM-APOLICE */
                    _.Display($"          APOLICE..........  {PROPVA_NUM_APOLICE}");

                    /*" -2694- DISPLAY '          SUBGRUPO.........  ' PROPVA-CODSUBES */
                    _.Display($"          SUBGRUPO.........  {PROPVA_CODSUBES}");

                    /*" -2695- DISPLAY '          FONTE............  ' PROPVA-FONTE */
                    _.Display($"          FONTE............  {PROPVA_FONTE}");

                    /*" -2696- DISPLAY '          NUM. PROPOSTA....  ' FONTE-PROPAUTOM */
                    _.Display($"          NUM. PROPOSTA....  {FONTE_PROPAUTOM}");

                    /*" -2697- DISPLAY '          CERTIFICADO......  ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO......  {PROPVA_NRCERTIF}");

                    /*" -2698- DISPLAY '          SQLCODE..........  ' SQLCODE */
                    _.Display($"          SQLCODE..........  {DB.SQLCODE}");

                    /*" -2699- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2700- END-IF */
                }


                /*" -2702- END-IF. */
            }


            /*" -2704- MOVE 'UPDATE V0FONTE 1' TO COMANDO. */
            _.Move("UPDATE V0FONTE 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2709- PERFORM M_0300_PROPAUTOM_DB_UPDATE_1 */

            M_0300_PROPAUTOM_DB_UPDATE_1();

            /*" -2712- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2713- DISPLAY 'ERRO UPDATE V0FONTE' */
                _.Display($"ERRO UPDATE V0FONTE");

                /*" -2714- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2716- END-IF. */
            }


            /*" -2718- PERFORM 0400-00-SELECT-V0COBERPROPVA THRU 0400-FIM. */

            M_0400_00_SELECT_V0COBERPROPVA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/


            /*" -2720- PERFORM 0410-00-DECLARE-VGHISTRAMCOB THRU 0410-FIM. */

            M_0410_00_DECLARE_VGHISTRAMCOB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0410_FIM*/


            /*" -2722- MOVE WS-IGPM-ACUM TO WS-IND-ACUM */
            _.Move(WS_WORK_AREAS.WS_IGPM_ACUM, WS_WORK_AREAS.WS_IND_ACUM);

            /*" -2724- PERFORM M-0500-00-DECLARE-VGHISTACESSCOB THRU 0500-FIM. */

            M_0500_00_DECLARE_VGHISTACESSCOB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0500_FIM*/


            /*" -2724- MOVE 'S' TO FLAG-IGPM. */
            _.Move("S", FLAG_IGPM);

        }

        [StopWatch]
        /*" M-0300-PROPAUTOM-DB-INSERT-1 */
        public void M_0300_PROPAUTOM_DB_INSERT_1()
        {
            /*" -2680- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :PROPVA-NRCERTIF, ' ' , '4' , :PROPVA-CODCLIEN, 0, 0, 0, 0, :SEGURA-FAIXA, 'S' , 'S' , :OPCAOP-PERIPGTO, 12, ' ' , :PROPVA-EST-CIV, :PROPVA-SEXO, 0, ' ' , 1, 1, 104, :PROPVA-AGECOBR, ' ' , 0, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, :SEGURA-TXAPMA, :SEGURA-TXAPIP, :SEGURA-TXAPAMDS, :SEGURA-TXAPDH, :SEGURA-TXAPDIT, :SEGURA-TXVG, :COBERP-IMPMORNATU-ANT, :COBERP-IMPMORNATU-ATU, :COBERP-IMPMORACID-ANT, :COBERP-IMPMORACID-ATU, :COBERP-IMPINVPERM-ANT, :COBERP-IMPINVPERM-ATU, :COBERP-IMPAMDS-ANT, :COBERP-IMPAMDS-ATU, :COBERP-IMPDH-ANT, :COBERP-IMPDH-ATU, :COBERP-IMPDIT-ANT, :COBERP-IMPDIT-ATU, :COBERP-PRMVG-ANT, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ANT, :COBERP-PRMAP-ATU, 895, :SISTEMA-DTMOVABE, 0, '1' , 'VA0130B' , :SISTEMA-DTMOVABE, NULL, NULL, :CLIENT-DTNASC, NULL, :SISTEMA-DTMAXALTIGPM, :COBERP-DTINIVIG, NULL, :SEGURA-LOT-EMP-SEGURADO) END-EXEC. */

            var m_0300_PROPAUTOM_DB_INSERT_1_Insert1 = new M_0300_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                SEGURA_FAIXA = SEGURA_FAIXA.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_EST_CIV = PROPVA_EST_CIV.ToString(),
                PROPVA_SEXO = PROPVA_SEXO.ToString(),
                PROPVA_AGECOBR = PROPVA_AGECOBR.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                SEGURA_TXAPMA = SEGURA_TXAPMA.ToString(),
                SEGURA_TXAPIP = SEGURA_TXAPIP.ToString(),
                SEGURA_TXAPAMDS = SEGURA_TXAPAMDS.ToString(),
                SEGURA_TXAPDH = SEGURA_TXAPDH.ToString(),
                SEGURA_TXAPDIT = SEGURA_TXAPDIT.ToString(),
                SEGURA_TXVG = SEGURA_TXVG.ToString(),
                COBERP_IMPMORNATU_ANT = COBERP_IMPMORNATU_ANT.ToString(),
                COBERP_IMPMORNATU_ATU = COBERP_IMPMORNATU_ATU.ToString(),
                COBERP_IMPMORACID_ANT = COBERP_IMPMORACID_ANT.ToString(),
                COBERP_IMPMORACID_ATU = COBERP_IMPMORACID_ATU.ToString(),
                COBERP_IMPINVPERM_ANT = COBERP_IMPINVPERM_ANT.ToString(),
                COBERP_IMPINVPERM_ATU = COBERP_IMPINVPERM_ATU.ToString(),
                COBERP_IMPAMDS_ANT = COBERP_IMPAMDS_ANT.ToString(),
                COBERP_IMPAMDS_ATU = COBERP_IMPAMDS_ATU.ToString(),
                COBERP_IMPDH_ANT = COBERP_IMPDH_ANT.ToString(),
                COBERP_IMPDH_ATU = COBERP_IMPDH_ATU.ToString(),
                COBERP_IMPDIT_ANT = COBERP_IMPDIT_ANT.ToString(),
                COBERP_IMPDIT_ATU = COBERP_IMPDIT_ATU.ToString(),
                COBERP_PRMVG_ANT = COBERP_PRMVG_ANT.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                COBERP_PRMAP_ANT = COBERP_PRMAP_ANT.ToString(),
                COBERP_PRMAP_ATU = COBERP_PRMAP_ATU.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                CLIENT_DTNASC = CLIENT_DTNASC.ToString(),
                SISTEMA_DTMAXALTIGPM = SISTEMA_DTMAXALTIGPM.ToString(),
                COBERP_DTINIVIG = COBERP_DTINIVIG.ToString(),
                SEGURA_LOT_EMP_SEGURADO = SEGURA_LOT_EMP_SEGURADO.ToString(),
            };

            M_0300_PROPAUTOM_DB_INSERT_1_Insert1.Execute(m_0300_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0300-PROPAUTOM-DB-UPDATE-1 */
        public void M_0300_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -2709- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_0300_PROPAUTOM_DB_UPDATE_1_Update1 = new M_0300_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            M_0300_PROPAUTOM_DB_UPDATE_1_Update1.Execute(m_0300_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0300-CORRIGE-IGPM-DB-INSERT-1 */
        public void M_0300_CORRIGE_IGPM_DB_INSERT_1()
        {
            /*" -2460- EXEC SQL INSERT INTO SEGUROS.V0COBERPROPVA ( NRCERTIF ,OCORHIST ,DTINIVIG ,DTTERVIG ,IMPSEGUR ,QUANT_VIDAS ,IMPSEGIND ,CODOPER ,OPCAO_COBER ,IMPMORNATU ,IMPMORACID ,IMPINVPERM ,IMPAMDS ,IMPDH ,IMPDIT ,VLPREMIO ,PRMVG ,PRMAP ,QTTITCAP ,VLTITCAP ,VLCUSTCAP ,IMPSEGCDC ,VLCUSTCDG ,CODUSU ,TIMESTAMP ,IMPSEGAUXF ,VLCUSTAUXF ,PRMDIT ,QTDIT ) VALUES (:PROPVA-NRCERTIF, :PROPVA-OCORHIST, :COBERP-DTINIVIG, '9999-12-31' , :COBERP-IMPMORNATU-ATU, 1, :COBERP-IMPMORNATU-ATU, 895, :PROPVA-OPCAO-COBER, :COBERP-IMPMORNATU-ATU, :COBERP-IMPMORACID-ATU, :COBERP-IMPINVPERM-ATU, :COBERP-IMPAMDS-ATU, :COBERP-IMPDH-ATU, :COBERP-IMPDIT-ATU, :COBERP-VLPREMIO-ATU, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ATU, :COBERP-QTTITCAP, :COBERP-VLTITCAP, :COBERP-VLCUSTCAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, 'VA0130B' , CURRENT TIMESTAMP, :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I, :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I, :COBERP-PRMDIT-ATU:COBERP-PRMDIT-I, :COBERP-QTDIT:COBERP-QTDIT-I) END-EXEC. */

            var m_0300_CORRIGE_IGPM_DB_INSERT_1_Insert1 = new M_0300_CORRIGE_IGPM_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                COBERP_DTINIVIG = COBERP_DTINIVIG.ToString(),
                COBERP_IMPMORNATU_ATU = COBERP_IMPMORNATU_ATU.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                COBERP_IMPMORACID_ATU = COBERP_IMPMORACID_ATU.ToString(),
                COBERP_IMPINVPERM_ATU = COBERP_IMPINVPERM_ATU.ToString(),
                COBERP_IMPAMDS_ATU = COBERP_IMPAMDS_ATU.ToString(),
                COBERP_IMPDH_ATU = COBERP_IMPDH_ATU.ToString(),
                COBERP_IMPDIT_ATU = COBERP_IMPDIT_ATU.ToString(),
                COBERP_VLPREMIO_ATU = COBERP_VLPREMIO_ATU.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                COBERP_PRMAP_ATU = COBERP_PRMAP_ATU.ToString(),
                COBERP_QTTITCAP = COBERP_QTTITCAP.ToString(),
                COBERP_VLTITCAP = COBERP_VLTITCAP.ToString(),
                COBERP_VLCUSTCAP = COBERP_VLCUSTCAP.ToString(),
                COBERP_IMPSEGCDG = COBERP_IMPSEGCDG.ToString(),
                COBERP_VLCUSTCDG = COBERP_VLCUSTCDG.ToString(),
                COBERP_IMPSEGAUXF = COBERP_IMPSEGAUXF.ToString(),
                COBERP_IMPSEGAUXF_I = COBERP_IMPSEGAUXF_I.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                COBERP_VLCUSTAUXF_I = COBERP_VLCUSTAUXF_I.ToString(),
                COBERP_PRMDIT_ATU = COBERP_PRMDIT_ATU.ToString(),
                COBERP_PRMDIT_I = COBERP_PRMDIT_I.ToString(),
                COBERP_QTDIT = COBERP_QTDIT.ToString(),
                COBERP_QTDIT_I = COBERP_QTDIT_I.ToString(),
            };

            M_0300_CORRIGE_IGPM_DB_INSERT_1_Insert1.Execute(m_0300_CORRIGE_IGPM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0300-CORRIGE-IGPM-DB-SELECT-1 */
        public void M_0300_CORRIGE_IGPM_DB_SELECT_1()
        {
            /*" -2488- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :PROPVA-FONTE WITH UR END-EXEC. */

            var m_0300_CORRIGE_IGPM_DB_SELECT_1_Query1 = new M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1()
            {
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1.Execute(m_0300_CORRIGE_IGPM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" M-0300-CORRIGE-IGPM-DB-UPDATE-2 */
        public void M_0300_CORRIGE_IGPM_DB_UPDATE_2()
        {
            /*" -2345- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET CODOPER = 895, DTMOVTO = :SISTEMA-DTMOVABE, OCORHIST = :PROPVA-OCORHIST, SIT_INTERFACE = '0' , CODUSU = 'VA0130B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF END-EXEC. */

            var m_0300_CORRIGE_IGPM_DB_UPDATE_2_Update1 = new M_0300_CORRIGE_IGPM_DB_UPDATE_2_Update1()
            {
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_0300_CORRIGE_IGPM_DB_UPDATE_2_Update1.Execute(m_0300_CORRIGE_IGPM_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/

        [StopWatch]
        /*" M-0400-00-SELECT-V0COBERPROPVA */
        private void M_0400_00_SELECT_V0COBERPROPVA(bool isPerform = false)
        {
            /*" -2733- MOVE '0400-00-SELECT-V0COBERPROPVA' TO PARAGRAFO */
            _.Move("0400-00-SELECT-V0COBERPROPVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2735- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2798- PERFORM M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -2801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2802- DISPLAY 'ERRO SELECT V0COBERPROPVA' */
                _.Display($"ERRO SELECT V0COBERPROPVA");

                /*" -2803- DISPLAY 'NRCERTIF = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF = {PROPVA_NRCERTIF}");

                /*" -2804- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2804- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0400-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -2798- EXEC SQL SELECT NRCERTIF, OCORHIST, DTINIVIG, DTTERVIG, IMPSEGUR, QUANT_VIDAS, IMPSEGIND, CODOPER, OPCAO_COBER, IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDC, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT INTO :COBERP-NRCERTIF, :COBERP-OCORHIST, :COBERP-DTINIVIG, :COBERP-DTTERVIG, :COBERP-IMPSEGUR, :COBERP-QUANT-VIDAS, :COBERP-IMPSEGIND, :COBERP-CODOPER, :COBERP-OPCAO-COBER, :COBERP-IMPMORNATU-ATU, :COBERP-IMPMORACID-ATU, :COBERP-IMPINVPERM-ATU, :COBERP-IMPAMDS-ATU, :COBERP-IMPDH-ATU, :COBERP-IMPDIT-ATU, :COBERP-VLPREMIO-ATU, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ATU, :COBERP-QTTITCAP, :COBERP-VLTITCAP, :COBERP-VLCUSTCAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I, :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I, :COBERP-PRMDIT-ATU:COBERP-PRMDIT-I, :COBERP-QTDIT:COBERP-QTDIT-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = (SELECT MAX(T1.OCORHIST) FROM SEGUROS.V0COBERPROPVA T1 WHERE T1.NRCERTIF = :PROPVA-NRCERTIF AND T1.DTTERVIG = '9999-12-31' ) WITH UR END-EXEC. */

            var m_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(m_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_NRCERTIF, COBERP_NRCERTIF);
                _.Move(executed_1.COBERP_OCORHIST, COBERP_OCORHIST);
                _.Move(executed_1.COBERP_DTINIVIG, COBERP_DTINIVIG);
                _.Move(executed_1.COBERP_DTTERVIG, COBERP_DTTERVIG);
                _.Move(executed_1.COBERP_IMPSEGUR, COBERP_IMPSEGUR);
                _.Move(executed_1.COBERP_QUANT_VIDAS, COBERP_QUANT_VIDAS);
                _.Move(executed_1.COBERP_IMPSEGIND, COBERP_IMPSEGIND);
                _.Move(executed_1.COBERP_CODOPER, COBERP_CODOPER);
                _.Move(executed_1.COBERP_OPCAO_COBER, COBERP_OPCAO_COBER);
                _.Move(executed_1.COBERP_IMPMORNATU_ATU, COBERP_IMPMORNATU_ATU);
                _.Move(executed_1.COBERP_IMPMORACID_ATU, COBERP_IMPMORACID_ATU);
                _.Move(executed_1.COBERP_IMPINVPERM_ATU, COBERP_IMPINVPERM_ATU);
                _.Move(executed_1.COBERP_IMPAMDS_ATU, COBERP_IMPAMDS_ATU);
                _.Move(executed_1.COBERP_IMPDH_ATU, COBERP_IMPDH_ATU);
                _.Move(executed_1.COBERP_IMPDIT_ATU, COBERP_IMPDIT_ATU);
                _.Move(executed_1.COBERP_VLPREMIO_ATU, COBERP_VLPREMIO_ATU);
                _.Move(executed_1.COBERP_PRMVG_ATU, COBERP_PRMVG_ATU);
                _.Move(executed_1.COBERP_PRMAP_ATU, COBERP_PRMAP_ATU);
                _.Move(executed_1.COBERP_QTTITCAP, COBERP_QTTITCAP);
                _.Move(executed_1.COBERP_VLTITCAP, COBERP_VLTITCAP);
                _.Move(executed_1.COBERP_VLCUSTCAP, COBERP_VLCUSTCAP);
                _.Move(executed_1.COBERP_IMPSEGCDG, COBERP_IMPSEGCDG);
                _.Move(executed_1.COBERP_VLCUSTCDG, COBERP_VLCUSTCDG);
                _.Move(executed_1.COBERP_IMPSEGAUXF, COBERP_IMPSEGAUXF);
                _.Move(executed_1.COBERP_IMPSEGAUXF_I, COBERP_IMPSEGAUXF_I);
                _.Move(executed_1.COBERP_VLCUSTAUXF, COBERP_VLCUSTAUXF);
                _.Move(executed_1.COBERP_VLCUSTAUXF_I, COBERP_VLCUSTAUXF_I);
                _.Move(executed_1.COBERP_PRMDIT_ATU, COBERP_PRMDIT_ATU);
                _.Move(executed_1.COBERP_PRMDIT_I, COBERP_PRMDIT_I);
                _.Move(executed_1.COBERP_QTDIT, COBERP_QTDIT);
                _.Move(executed_1.COBERP_QTDIT_I, COBERP_QTDIT_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/

        [StopWatch]
        /*" M-0410-00-DECLARE-VGHISTRAMCOB */
        private void M_0410_00_DECLARE_VGHISTRAMCOB(bool isPerform = false)
        {
            /*" -2813- MOVE '0410-00-DECLARE-VGHISTRAMCOB' TO PARAGRAFO */
            _.Move("0410-00-DECLARE-VGHISTRAMCOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2815- MOVE 'DECLARE VGHISRAMC' TO COMANDO. */
            _.Move("DECLARE VGHISRAMC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2830- PERFORM M_0410_00_DECLARE_VGHISTRAMCOB_DB_DECLARE_1 */

            M_0410_00_DECLARE_VGHISTRAMCOB_DB_DECLARE_1();

            /*" -2834- MOVE 'OPEN  VGHISRAMC' TO COMANDO. */
            _.Move("OPEN  VGHISRAMC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2834- PERFORM M_0410_00_DECLARE_VGHISTRAMCOB_DB_OPEN_1 */

            M_0410_00_DECLARE_VGHISTRAMCOB_DB_OPEN_1();

            /*" -2837- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2838- DISPLAY 'ERRO OPEN CURSOR VGHISRAMC' */
                _.Display($"ERRO OPEN CURSOR VGHISRAMC");

                /*" -2839- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2841- END-IF. */
            }


            /*" -2843- MOVE SPACES TO WFIM-VGHISRAMC. */
            _.Move("", WS_WORK_AREAS.WFIM_VGHISRAMC);

            /*" -2844- PERFORM 0420-00-FETCH-VG-HISTRAMCOB THRU 0420-FIM UNTIL WFIM-VGHISRAMC NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_VGHISRAMC.IsEmpty()))
            {

                M_0420_00_FETCH_VG_HISTRAMCOB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0420_FIM*/

            }

        }

        [StopWatch]
        /*" M-0410-00-DECLARE-VGHISTRAMCOB-DB-OPEN-1 */
        public void M_0410_00_DECLARE_VGHISTRAMCOB_DB_OPEN_1()
        {
            /*" -2834- EXEC SQL OPEN VGHISRAMC END-EXEC. */

            VGHISRAMC.Open();

        }

        [StopWatch]
        /*" M-0500-00-DECLARE-VGHISTACESSCOB-DB-DECLARE-1 */
        public void M_0500_00_DECLARE_VGHISTACESSCOB_DB_DECLARE_1()
        {
            /*" -2965- EXEC SQL DECLARE VGHISTACE CURSOR FOR SELECT NUM_CERTIFICADO, NUM_ACESSORIO, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_HIST_ACESS_COB WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND OCORR_HISTORICO = :COBERP-OCORHIST-ANT ORDER BY NUM_ACESSORIO WITH UR END-EXEC. */
            VGHISTACE = new VA0130B_VGHISTACE(true);
            string GetQuery_VGHISTACE()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							NUM_ACESSORIO
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_HIST_ACESS_COB 
							WHERE NUM_CERTIFICADO = '{PROPVA_NRCERTIF}' 
							AND OCORR_HISTORICO = '{COBERP_OCORHIST_ANT}' 
							ORDER BY NUM_ACESSORIO";

                return query;
            }
            VGHISTACE.GetQueryEvent += GetQuery_VGHISTACE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0410_FIM*/

        [StopWatch]
        /*" M-0420-00-FETCH-VG-HISTRAMCOB */
        private void M_0420_00_FETCH_VG_HISTRAMCOB(bool isPerform = false)
        {
            /*" -2854- MOVE '0420-00-FETCH-VG-HISTRAMCOB' TO PARAGRAFO */
            _.Move("0420-00-FETCH-VG-HISTRAMCOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2856- MOVE 'FETCH VGHISRAMC' TO COMANDO. */
            _.Move("FETCH VGHISRAMC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2865- PERFORM M_0420_00_FETCH_VG_HISTRAMCOB_DB_FETCH_1 */

            M_0420_00_FETCH_VG_HISTRAMCOB_DB_FETCH_1();

            /*" -2868- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2869- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2870- MOVE 'S' TO WFIM-VGHISRAMC */
                    _.Move("S", WS_WORK_AREAS.WFIM_VGHISRAMC);

                    /*" -2870- PERFORM M_0420_00_FETCH_VG_HISTRAMCOB_DB_CLOSE_1 */

                    M_0420_00_FETCH_VG_HISTRAMCOB_DB_CLOSE_1();

                    /*" -2872- GO TO 0420-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0420_FIM*/ //GOTO
                    return;

                    /*" -2873- ELSE */
                }
                else
                {


                    /*" -2874- DISPLAY 'ERRO FETCH CURSOR VGHISRAMC' */
                    _.Display($"ERRO FETCH CURSOR VGHISRAMC");

                    /*" -2875- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                    _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                    /*" -2876- DISPLAY 'OCORHIST = ' COBERP-OCORHIST-ANT */
                    _.Display($"OCORHIST = {COBERP_OCORHIST_ANT}");

                    /*" -2877- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2878- END-IF */
                }


                /*" -2880- END-IF. */
            }


            /*" -2880- PERFORM 0430-00-INSERT-VG-HISTRAMCOB THRU 0430-FIM. */

            M_0430_00_INSERT_VG_HISTRAMCOB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0430_FIM*/


        }

        [StopWatch]
        /*" M-0420-00-FETCH-VG-HISTRAMCOB-DB-FETCH-1 */
        public void M_0420_00_FETCH_VG_HISTRAMCOB_DB_FETCH_1()
        {
            /*" -2865- EXEC SQL FETCH VGHISRAMC INTO :VGHISR-NRCERTIF, :VGHISR-NUM-RAMO, :VGHISR-NUM-COBERTURA, :VGHISR-QTD-COBERTURA, :VGHISR-IMPSEGURADA, :VGHISR-CUSTO, :VGHISR-PREMIO END-EXEC. */

            if (VGHISRAMC.Fetch())
            {
                _.Move(VGHISRAMC.VGHISR_NRCERTIF, VGHISR_NRCERTIF);
                _.Move(VGHISRAMC.VGHISR_NUM_RAMO, VGHISR_NUM_RAMO);
                _.Move(VGHISRAMC.VGHISR_NUM_COBERTURA, VGHISR_NUM_COBERTURA);
                _.Move(VGHISRAMC.VGHISR_QTD_COBERTURA, VGHISR_QTD_COBERTURA);
                _.Move(VGHISRAMC.VGHISR_IMPSEGURADA, VGHISR_IMPSEGURADA);
                _.Move(VGHISRAMC.VGHISR_CUSTO, VGHISR_CUSTO);
                _.Move(VGHISRAMC.VGHISR_PREMIO, VGHISR_PREMIO);
            }

        }

        [StopWatch]
        /*" M-0420-00-FETCH-VG-HISTRAMCOB-DB-CLOSE-1 */
        public void M_0420_00_FETCH_VG_HISTRAMCOB_DB_CLOSE_1()
        {
            /*" -2870- EXEC SQL CLOSE VGHISRAMC END-EXEC */

            VGHISRAMC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0420_FIM*/

        [StopWatch]
        /*" M-0430-00-INSERT-VG-HISTRAMCOB */
        private void M_0430_00_INSERT_VG_HISTRAMCOB(bool isPerform = false)
        {
            /*" -2889- MOVE '0430-00-INSERT-VG-HISTRAMCOB' TO PARAGRAFO */
            _.Move("0430-00-INSERT-VG-HISTRAMCOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2891- MOVE 'INSERT VG_HIST_RAMO_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_RAMO_COB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2892- IF (VGHISR-NUM-RAMO EQUAL 81) */

            if ((VGHISR_NUM_RAMO == 81))
            {

                /*" -2893- IF (VGHISR-NUM-COBERTURA EQUAL 01) */

                if ((VGHISR_NUM_COBERTURA == 01))
                {

                    /*" -2894- MOVE COBERP-IMPMORACID-ATU TO VGHISR-IMPSEGURADA */
                    _.Move(COBERP_IMPMORACID_ATU, VGHISR_IMPSEGURADA);

                    /*" -2896- MOVE COBERP-PRMAP-ATU TO VGHISR-CUSTO VGHISR-PREMIO */
                    _.Move(COBERP_PRMAP_ATU, VGHISR_CUSTO, VGHISR_PREMIO);

                    /*" -2897- END-IF */
                }


                /*" -2898- IF (VGHISR-NUM-COBERTURA EQUAL 02) */

                if ((VGHISR_NUM_COBERTURA == 02))
                {

                    /*" -2899- MOVE COBERP-IMPINVPERM-ATU TO VGHISR-IMPSEGURADA */
                    _.Move(COBERP_IMPINVPERM_ATU, VGHISR_IMPSEGURADA);

                    /*" -2900- END-IF */
                }


                /*" -2901- IF (VGHISR-NUM-COBERTURA EQUAL 03) */

                if ((VGHISR_NUM_COBERTURA == 03))
                {

                    /*" -2902- MOVE COBERP-IMPAMDS-ATU TO VGHISR-IMPSEGURADA */
                    _.Move(COBERP_IMPAMDS_ATU, VGHISR_IMPSEGURADA);

                    /*" -2903- END-IF */
                }


                /*" -2904- IF (VGHISR-NUM-COBERTURA EQUAL 04) */

                if ((VGHISR_NUM_COBERTURA == 04))
                {

                    /*" -2905- MOVE COBERP-IMPDH-ATU TO VGHISR-IMPSEGURADA */
                    _.Move(COBERP_IMPDH_ATU, VGHISR_IMPSEGURADA);

                    /*" -2906- END-IF */
                }


                /*" -2907- IF (VGHISR-NUM-COBERTURA EQUAL 05) */

                if ((VGHISR_NUM_COBERTURA == 05))
                {

                    /*" -2908- MOVE COBERP-IMPDIT-ATU TO VGHISR-IMPSEGURADA */
                    _.Move(COBERP_IMPDIT_ATU, VGHISR_IMPSEGURADA);

                    /*" -2910- MOVE COBERP-PRMDIT-ATU TO VGHISR-CUSTO VGHISR-PREMIO */
                    _.Move(COBERP_PRMDIT_ATU, VGHISR_CUSTO, VGHISR_PREMIO);

                    /*" -2911- END-IF */
                }


                /*" -2913- IF (VGHISR-NUM-COBERTURA EQUAL 06) NEXT SENTENCE */

                if ((VGHISR_NUM_COBERTURA == 06))
                {

                    /*" -2914- END-IF */
                }


                /*" -2915- ELSE */
            }
            else
            {


                /*" -2916- IF (VGHISR-NUM-RAMO EQUAL 93) */

                if ((VGHISR_NUM_RAMO == 93))
                {

                    /*" -2917- IF (VGHISR-NUM-COBERTURA EQUAL 11) */

                    if ((VGHISR_NUM_COBERTURA == 11))
                    {

                        /*" -2918- MOVE COBERP-IMPMORNATU-ATU TO VGHISR-IMPSEGURADA */
                        _.Move(COBERP_IMPMORNATU_ATU, VGHISR_IMPSEGURADA);

                        /*" -2920- MOVE COBERP-PRMVG-ATU TO VGHISR-CUSTO VGHISR-PREMIO */
                        _.Move(COBERP_PRMVG_ATU, VGHISR_CUSTO, VGHISR_PREMIO);

                        /*" -2921- END-IF */
                    }


                    /*" -2922- END-IF */
                }


                /*" -2924- END-IF. */
            }


            /*" -2934- PERFORM M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1 */

            M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1();

            /*" -2937- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2938- DISPLAY 'ERRO INSERT VG_HIST_RAMO_COB' */
                _.Display($"ERRO INSERT VG_HIST_RAMO_COB");

                /*" -2939- DISPLAY 'NRCERTIF  = ' VGHISR-NRCERTIF */
                _.Display($"NRCERTIF  = {VGHISR_NRCERTIF}");

                /*" -2940- DISPLAY 'OCORHIST  = ' COBERP-OCORHIST */
                _.Display($"OCORHIST  = {COBERP_OCORHIST}");

                /*" -2941- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2941- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0430-00-INSERT-VG-HISTRAMCOB-DB-INSERT-1 */
        public void M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1()
        {
            /*" -2934- EXEC SQL INSERT INTO SEGUROS.VG_HIST_RAMO_COB VALUES (:VGHISR-NRCERTIF, :COBERP-OCORHIST, :VGHISR-NUM-RAMO, :VGHISR-NUM-COBERTURA, :VGHISR-QTD-COBERTURA, :VGHISR-IMPSEGURADA, :VGHISR-CUSTO, :VGHISR-PREMIO) END-EXEC. */

            var m_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1 = new M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1()
            {
                VGHISR_NRCERTIF = VGHISR_NRCERTIF.ToString(),
                COBERP_OCORHIST = COBERP_OCORHIST.ToString(),
                VGHISR_NUM_RAMO = VGHISR_NUM_RAMO.ToString(),
                VGHISR_NUM_COBERTURA = VGHISR_NUM_COBERTURA.ToString(),
                VGHISR_QTD_COBERTURA = VGHISR_QTD_COBERTURA.ToString(),
                VGHISR_IMPSEGURADA = VGHISR_IMPSEGURADA.ToString(),
                VGHISR_CUSTO = VGHISR_CUSTO.ToString(),
                VGHISR_PREMIO = VGHISR_PREMIO.ToString(),
            };

            M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1.Execute(m_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0430_FIM*/

        [StopWatch]
        /*" M-0500-00-DECLARE-VGHISTACESSCOB */
        private void M_0500_00_DECLARE_VGHISTACESSCOB(bool isPerform = false)
        {
            /*" -2950- MOVE '0500-00-DECLARE-VGHISTACESSCOB' TO PARAGRAFO */
            _.Move("0500-00-DECLARE-VGHISTACESSCOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2952- MOVE 'DECLARE VGHISTACESSCOB' TO COMANDO. */
            _.Move("DECLARE VGHISTACESSCOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2965- PERFORM M_0500_00_DECLARE_VGHISTACESSCOB_DB_DECLARE_1 */

            M_0500_00_DECLARE_VGHISTACESSCOB_DB_DECLARE_1();

            /*" -2968- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2969- DISPLAY 'ERRO DECLARE CURSOR VGHISTACE' */
                _.Display($"ERRO DECLARE CURSOR VGHISTACE");

                /*" -2970- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2972- END-IF. */
            }


            /*" -2974- MOVE 'OPEN  VGHISTACE' TO COMANDO. */
            _.Move("OPEN  VGHISTACE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2974- PERFORM M_0500_00_DECLARE_VGHISTACESSCOB_DB_OPEN_1 */

            M_0500_00_DECLARE_VGHISTACESSCOB_DB_OPEN_1();

            /*" -2977- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2978- DISPLAY 'ERRO OPEN CURSOR VGHISTACE' */
                _.Display($"ERRO OPEN CURSOR VGHISTACE");

                /*" -2979- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2981- END-IF. */
            }


            /*" -2983- MOVE SPACES TO WFIM-VGHISTACE. */
            _.Move("", WS_WORK_AREAS.WFIM_VGHISTACE);

            /*" -2984- PERFORM 0510-00-FETCH-VG-HISTACESCOB THRU 0510-FIM UNTIL WFIM-VGHISTACE NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_VGHISTACE.IsEmpty()))
            {

                M_0510_00_FETCH_VG_HISTACESCOB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0510_FIM*/

            }

        }

        [StopWatch]
        /*" M-0500-00-DECLARE-VGHISTACESSCOB-DB-OPEN-1 */
        public void M_0500_00_DECLARE_VGHISTACESSCOB_DB_OPEN_1()
        {
            /*" -2974- EXEC SQL OPEN VGHISTACE END-EXEC. */

            VGHISTACE.Open();

        }

        [StopWatch]
        /*" M-2200-00-DECLARE-VGPLANACESS-DB-DECLARE-1 */
        public void M_2200_00_DECLARE_VGPLANACESS_DB_DECLARE_1()
        {
            /*" -3744- EXEC SQL DECLARE VGPLAACES CURSOR FOR SELECT NUM_ACESSORIO, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_PLANO_ACESSORIO WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND DTINIVIG <= :SISTEMA-DTMOVABE AND DTTERVIG >= :SISTEMA-DTMOVABE AND IDADE_INICIAL <= :PROPVA-IDADE AND IDADE_FINAL >= :PROPVA-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO ORDER BY NUM_ACESSORIO WITH UR END-EXEC. */
            VGPLAACES = new VA0130B_VGPLAACES(true);
            string GetQuery_VGPLAACES()
            {
                var query = @$"SELECT NUM_ACESSORIO
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_PLANO_ACESSORIO 
							WHERE NUM_APOLICE = '{PROPVA_NUM_APOLICE}' 
							AND CODSUBES = '{PROPVA_CODSUBES}' 
							AND OPCAO_COBER = '{PROPVA_OPCAO_COBER}' 
							AND DTINIVIG <= '{SISTEMA_DTMOVABE}' 
							AND DTTERVIG >= '{SISTEMA_DTMOVABE}' 
							AND IDADE_INICIAL <= '{PROPVA_IDADE}' 
							AND IDADE_FINAL >= '{PROPVA_IDADE}' 
							AND PERIPGTO = '{OPCAOP_PERIPGTO}' 
							ORDER BY NUM_ACESSORIO";

                return query;
            }
            VGPLAACES.GetQueryEvent += GetQuery_VGPLAACES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0500_FIM*/

        [StopWatch]
        /*" M-0510-00-FETCH-VG-HISTACESCOB */
        private void M_0510_00_FETCH_VG_HISTACESCOB(bool isPerform = false)
        {
            /*" -2993- MOVE '0510-00-FETCH-VG-HISTACESCOB' TO PARAGRAFO */
            _.Move("0510-00-FETCH-VG-HISTACESCOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2995- MOVE 'FETCH VGHISTACE' TO COMANDO. */
            _.Move("FETCH VGHISTACE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3003- PERFORM M_0510_00_FETCH_VG_HISTACESCOB_DB_FETCH_1 */

            M_0510_00_FETCH_VG_HISTACESCOB_DB_FETCH_1();

            /*" -3006- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3007- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3008- MOVE 'S' TO WFIM-VGHISTACE */
                    _.Move("S", WS_WORK_AREAS.WFIM_VGHISTACE);

                    /*" -3008- PERFORM M_0510_00_FETCH_VG_HISTACESCOB_DB_CLOSE_1 */

                    M_0510_00_FETCH_VG_HISTACESCOB_DB_CLOSE_1();

                    /*" -3010- GO TO 0510-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0510_FIM*/ //GOTO
                    return;

                    /*" -3011- ELSE */
                }
                else
                {


                    /*" -3012- DISPLAY 'ERRO FETCH CURSOR VHHISTACE' */
                    _.Display($"ERRO FETCH CURSOR VHHISTACE");

                    /*" -3013- DISPLAY 'NRCERTIF  = ' VGHISR-NRCERTIF */
                    _.Display($"NRCERTIF  = {VGHISR_NRCERTIF}");

                    /*" -3014- DISPLAY 'OCORHIST  = ' COBERP-OCORHIST-ANT */
                    _.Display($"OCORHIST  = {COBERP_OCORHIST_ANT}");

                    /*" -3015- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -3016- END-IF */
                }


                /*" -3018- END-IF. */
            }


            /*" -3018- PERFORM 0520-00-INSERT-VG-HISTACESCOB THRU 0520-FIM. */

            M_0520_00_INSERT_VG_HISTACESCOB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0520_FIM*/


        }

        [StopWatch]
        /*" M-0510-00-FETCH-VG-HISTACESCOB-DB-FETCH-1 */
        public void M_0510_00_FETCH_VG_HISTACESCOB_DB_FETCH_1()
        {
            /*" -3003- EXEC SQL FETCH VGHISTACE INTO :VGHISA-NRCERTIF , :VGHISA-NUM-ACESSORIO, :VGHISA-QTD-COBERTURA, :VGHISA-IMPSEGURADA, :VGHISA-CUSTO, :VGHISA-PREMIO END-EXEC. */

            if (VGHISTACE.Fetch())
            {
                _.Move(VGHISTACE.VGHISA_NRCERTIF, VGHISA_NRCERTIF);
                _.Move(VGHISTACE.VGHISA_NUM_ACESSORIO, VGHISA_NUM_ACESSORIO);
                _.Move(VGHISTACE.VGHISA_QTD_COBERTURA, VGHISA_QTD_COBERTURA);
                _.Move(VGHISTACE.VGHISA_IMPSEGURADA, VGHISA_IMPSEGURADA);
                _.Move(VGHISTACE.VGHISA_CUSTO, VGHISA_CUSTO);
                _.Move(VGHISTACE.VGHISA_PREMIO, VGHISA_PREMIO);
            }

        }

        [StopWatch]
        /*" M-0510-00-FETCH-VG-HISTACESCOB-DB-CLOSE-1 */
        public void M_0510_00_FETCH_VG_HISTACESCOB_DB_CLOSE_1()
        {
            /*" -3008- EXEC SQL CLOSE VGHISTACE END-EXEC */

            VGHISTACE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0510_FIM*/

        [StopWatch]
        /*" M-0520-00-INSERT-VG-HISTACESCOB */
        private void M_0520_00_INSERT_VG_HISTACESCOB(bool isPerform = false)
        {
            /*" -3027- MOVE '0520-00-INSERT-VG-HISTACESCOB' TO PARAGRAFO. */
            _.Move("0520-00-INSERT-VG-HISTACESCOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3032- MOVE 'INSERT VG_HIST_ACESS_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_ACESS_COB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3033- IF (VGHISA-NUM-ACESSORIO EQUAL 05) */

            if ((VGHISA_NUM_ACESSORIO == 05))
            {

                /*" -3035- COMPUTE VGHISA-IMPSEGURADA ROUNDED = VGHISA-IMPSEGURADA * WS-IND-ACUM */
                VGHISA_IMPSEGURADA.Value = VGHISA_IMPSEGURADA * WS_WORK_AREAS.WS_IND_ACUM;

                /*" -3037- COMPUTE VGHISA-PREMIO ROUNDED = VGHISA-PREMIO * WS-IND-ACUM */
                VGHISA_PREMIO.Value = VGHISA_PREMIO * WS_WORK_AREAS.WS_IND_ACUM;

                /*" -3039- COMPUTE VGHISA-CUSTO ROUNDED = VGHISA-CUSTO * WS-IND-ACUM */
                VGHISA_CUSTO.Value = VGHISA_CUSTO * WS_WORK_AREAS.WS_IND_ACUM;

                /*" -3041- END-IF. */
            }


            /*" -3050- PERFORM M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1 */

            M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1();

            /*" -3053- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3054- DISPLAY 'ERRO INSERT VG_HIST_ACESS_COB' */
                _.Display($"ERRO INSERT VG_HIST_ACESS_COB");

                /*" -3055- DISPLAY 'NRCERTIF  = ' VGHISA-NRCERTIF */
                _.Display($"NRCERTIF  = {VGHISA_NRCERTIF}");

                /*" -3056- DISPLAY 'OCORHIST  = ' COBERP-OCORHIST */
                _.Display($"OCORHIST  = {COBERP_OCORHIST}");

                /*" -3057- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3057- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0520-00-INSERT-VG-HISTACESCOB-DB-INSERT-1 */
        public void M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1()
        {
            /*" -3050- EXEC SQL INSERT INTO SEGUROS.VG_HIST_ACESS_COB VALUES (:VGHISA-NRCERTIF, :COBERP-OCORHIST, :VGHISA-NUM-ACESSORIO, :VGHISA-QTD-COBERTURA, :VGHISA-IMPSEGURADA, :VGHISA-CUSTO, :VGHISA-PREMIO) END-EXEC. */

            var m_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1 = new M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1()
            {
                VGHISA_NRCERTIF = VGHISA_NRCERTIF.ToString(),
                COBERP_OCORHIST = COBERP_OCORHIST.ToString(),
                VGHISA_NUM_ACESSORIO = VGHISA_NUM_ACESSORIO.ToString(),
                VGHISA_QTD_COBERTURA = VGHISA_QTD_COBERTURA.ToString(),
                VGHISA_IMPSEGURADA = VGHISA_IMPSEGURADA.ToString(),
                VGHISA_CUSTO = VGHISA_CUSTO.ToString(),
                VGHISA_PREMIO = VGHISA_PREMIO.ToString(),
            };

            M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1.Execute(m_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0520_FIM*/

        [StopWatch]
        /*" M-1000-MUDA-FAIXA-ETARIA */
        private void M_1000_MUDA_FAIXA_ETARIA(bool isPerform = false)
        {
            /*" -3068- MOVE '1000-MUDA-FAIXA-ETARIA' TO PARAGRAFO. */
            _.Move("1000-MUDA-FAIXA-ETARIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3070- MOVE 'SELECT V0COBERPROPVA 2' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3072- PERFORM 0120-SELECT-V0COBERPROPVA THRU 0120-FIM. */

            M_0120_SELECT_V0COBERPROPVA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_FIM*/


            /*" -3075- COMPUTE COBERP-PRMVG-ATU = COBERP-PRMVG-ANT * PLAVAVGA-PCT-FAIXA-ETARIA. */
            COBERP_PRMVG_ATU.Value = COBERP_PRMVG_ANT * PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA;

            /*" -3077- MOVE COBERP-PRMVG-ATU TO WS-PREMIO-REENQ */
            _.Move(COBERP_PRMVG_ATU, WS_PREMIO_REENQ);

            /*" -3078- IF COBERP-PRMVG-ATU < COBERP-VLPREMIO-ANT */

            if (COBERP_PRMVG_ATU < COBERP_VLPREMIO_ANT)
            {

                /*" -3079- GO TO 1000-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/ //GOTO
                return;

                /*" -3081- END-IF. */
            }


            /*" -3085- MOVE COBERP-DTINIVIG TO COBERP-DTTERVIG PROPVA-DTMOVTO DATA-MOVIMENTO. */
            _.Move(COBERP_DTINIVIG, COBERP_DTTERVIG, PROPVA_DTMOVTO, DATA_MOVIMENTO);

            /*" -3087- MOVE 'UPDATE V0SEGURAVG  ' TO COMANDO. */
            _.Move("UPDATE V0SEGURAVG  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3092- PERFORM M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1 */

            M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1();

            /*" -3095- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3096- DISPLAY 'ERRO UPDATE V0SEGURAVG' */
                _.Display($"ERRO UPDATE V0SEGURAVG");

                /*" -3097- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -3098- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3100- END-IF. */
            }


            /*" -3102- MOVE 'UPDATE V0COBERPROPVA' TO COMANDO. */
            _.Move("UPDATE V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3107- PERFORM M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2 */

            M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2();

            /*" -3110- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3111- DISPLAY 'ERRO UPDATE V0COBERPROPVA' */
                _.Display($"ERRO UPDATE V0COBERPROPVA");

                /*" -3112- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -3113- DISPLAY 'OCORHIST  = ' PROPVA-OCORHIST */
                _.Display($"OCORHIST  = {PROPVA_OCORHIST}");

                /*" -3114- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3116- END-IF. */
            }


            /*" -3118- COMPUTE PROPVA-OCORHIST = PROPVA-OCORHIST + 1. */
            PROPVA_OCORHIST.Value = PROPVA_OCORHIST + 1;

            /*" -3120- MOVE 'UPDATE V0PROPOSTAVA' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3130- PERFORM M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3 */

            M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3();

            /*" -3133- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3134- DISPLAY 'ERRO UPDATE V0PROPOSTAVA' */
                _.Display($"ERRO UPDATE V0PROPOSTAVA");

                /*" -3135- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -3136- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3138- END-IF. */
            }


            /*" -3140- MOVE 'INSERT V0COBERPROPVA' TO COMANDO. */
            _.Move("INSERT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3200- PERFORM M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1 */

            M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1();

            /*" -3203- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3204- DISPLAY 'ERRO INSERT V0COBERPROPVA' */
                _.Display($"ERRO INSERT V0COBERPROPVA");

                /*" -3205- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -3206- DISPLAY 'OCORHIST  = ' PROPVA-OCORHIST */
                _.Display($"OCORHIST  = {PROPVA_OCORHIST}");

                /*" -3207- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3209- END-IF. */
            }


            /*" -3211- IF (INDAGE < 0) OR (INDOPR < 0) OR (INDNUM < 0) OR (INDDIG < 0) */

            if ((INDAGE < 0) || (INDOPR < 0) || (INDNUM < 0) || (INDDIG < 0))
            {

                /*" -3212- MOVE 0 TO MNUM-CTA-CORRENTE */
                _.Move(0, MNUM_CTA_CORRENTE);

                /*" -3213- MOVE ' ' TO MDAC-CTA-CORRENTE */
                _.Move(" ", MDAC_CTA_CORRENTE);

                /*" -3214- ELSE */
            }
            else
            {


                /*" -3215- MOVE OPCAOP-OPRCTADEB TO WS-OPER-SEG */
                _.Move(OPCAOP_OPRCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_OPER_SEG);

                /*" -3216- MOVE OPCAOP-NUMCTADEB TO WS-CTA-SEG */
                _.Move(OPCAOP_NUMCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_CTA_SEG);

                /*" -3217- MOVE WS-CTA-CORRENTE TO MNUM-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.WS_CTA_CORRENTE, MNUM_CTA_CORRENTE);

                /*" -3218- MOVE OPCAOP-DIGCTADEB TO W01N0100 */
                _.Move(OPCAOP_DIGCTADEB, WS_WORK_AREAS.W01A0100.W01N0100);

                /*" -3219- MOVE W01A0100 TO MDAC-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.W01A0100, MDAC_CTA_CORRENTE);

                /*" -3221- END-IF. */
            }


            /*" -3223- MOVE 'SELECT V0FONTE 2' TO COMANDO. */
            _.Move("SELECT V0FONTE 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3229- PERFORM M_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1 */

            M_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1();

            /*" -3232- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3233- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3233- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1000-MUDA-FAIXA-ETARIA-DB-UPDATE-1 */
        public void M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1()
        {
            /*" -3092- EXEC SQL UPDATE SEGUROS.V0SEGURAVG SET FAIXA = :PLAVAVGA-FAIXA WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var m_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1 = new M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1()
            {
                PLAVAVGA_FAIXA = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1.Execute(m_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1000-PROPAUTOM */
        private void M_1000_PROPAUTOM(bool isPerform = false)
        {
            /*" -3238- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

            /*" -3240- MOVE 'INSERT V0MOVIMENTO' TO COMANDO. */
            _.Move("INSERT V0MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3317- PERFORM M_1000_PROPAUTOM_DB_INSERT_1 */

            M_1000_PROPAUTOM_DB_INSERT_1();

            /*" -3320- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3323- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3324- GO TO 1000-PROPAUTOM */
                    new Task(() => M_1000_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3325- ELSE */
                }
                else
                {


                    /*" -3326- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -3327- DISPLAY 'VA0130B - ERRO INSERT DA V0MOVIMENTO' */
                    _.Display($"VA0130B - ERRO INSERT DA V0MOVIMENTO");

                    /*" -3329- DISPLAY '          APOLICE..........  ' PROPVA-NUM-APOLICE */
                    _.Display($"          APOLICE..........  {PROPVA_NUM_APOLICE}");

                    /*" -3330- DISPLAY '          SUBGRUPO.........  ' PROPVA-CODSUBES */
                    _.Display($"          SUBGRUPO.........  {PROPVA_CODSUBES}");

                    /*" -3331- DISPLAY '          FONTE............  ' PROPVA-FONTE */
                    _.Display($"          FONTE............  {PROPVA_FONTE}");

                    /*" -3332- DISPLAY '          NUM. PROPOSTA....  ' FONTE-PROPAUTOM */
                    _.Display($"          NUM. PROPOSTA....  {FONTE_PROPAUTOM}");

                    /*" -3333- DISPLAY '          CERTIFICADO......  ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO......  {PROPVA_NRCERTIF}");

                    /*" -3334- DISPLAY '          SQLCODE..........  ' SQLCODE */
                    _.Display($"          SQLCODE..........  {DB.SQLCODE}");

                    /*" -3335- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -3336- END-IF */
                }


                /*" -3338- END-IF. */
            }


            /*" -3340- MOVE 'UPDATE V0FONTE 2' TO COMANDO. */
            _.Move("UPDATE V0FONTE 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3345- PERFORM M_1000_PROPAUTOM_DB_UPDATE_1 */

            M_1000_PROPAUTOM_DB_UPDATE_1();

            /*" -3348- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3349- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3351- END-IF. */
            }


            /*" -3351- ADD 1 TO AC-REENQUAD. */
            WS_WORK_AREAS.AC_REENQUAD.Value = WS_WORK_AREAS.AC_REENQUAD + 1;

        }

        [StopWatch]
        /*" M-1000-PROPAUTOM-DB-INSERT-1 */
        public void M_1000_PROPAUTOM_DB_INSERT_1()
        {
            /*" -3317- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :PROPVA-NRCERTIF, ' ' , '4' , :PROPVA-CODCLIEN, 0, 0, 0, 0, :PLAVAVGA-FAIXA, 'S' , 'S' , :OPCAOP-PERIPGTO, 12, ' ' , :PROPVA-EST-CIV, :PROPVA-SEXO, 0, ' ' , 1, 1, 104, :PROPVA-AGECOBR, ' ' , 0, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :COBERP-IMPMORNATU-ANT, :COBERP-IMPMORNATU-ATU, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :COBERP-PRMVG-ANT, :COBERP-PRMVG-ATU, 0, 0, 820, :SISTEMA-DTMOVABE, 0, '1' , 'VA0130B' , :SISTEMA-DTMOVABE, NULL, NULL, :CLIENT-DTNASC, NULL, :PROPVA-DTMOVTO, :PROPVA-DTMOVTO, NULL, NULL) END-EXEC. */

            var m_1000_PROPAUTOM_DB_INSERT_1_Insert1 = new M_1000_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                PLAVAVGA_FAIXA = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_EST_CIV = PROPVA_EST_CIV.ToString(),
                PROPVA_SEXO = PROPVA_SEXO.ToString(),
                PROPVA_AGECOBR = PROPVA_AGECOBR.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                COBERP_IMPMORNATU_ANT = COBERP_IMPMORNATU_ANT.ToString(),
                COBERP_IMPMORNATU_ATU = COBERP_IMPMORNATU_ATU.ToString(),
                COBERP_PRMVG_ANT = COBERP_PRMVG_ANT.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                CLIENT_DTNASC = CLIENT_DTNASC.ToString(),
                PROPVA_DTMOVTO = PROPVA_DTMOVTO.ToString(),
            };

            M_1000_PROPAUTOM_DB_INSERT_1_Insert1.Execute(m_1000_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1000-PROPAUTOM-DB-UPDATE-1 */
        public void M_1000_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -3345- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_1000_PROPAUTOM_DB_UPDATE_1_Update1 = new M_1000_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            M_1000_PROPAUTOM_DB_UPDATE_1_Update1.Execute(m_1000_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1000-MUDA-FAIXA-ETARIA-DB-UPDATE-2 */
        public void M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2()
        {
            /*" -3107- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET DTTERVIG = :COBERP-DTINIVIG WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = :PROPVA-OCORHIST END-EXEC. */

            var m_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1 = new M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1()
            {
                COBERP_DTINIVIG = COBERP_DTINIVIG.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1.Execute(m_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-1000-MUDA-FAIXA-ETARIA-DB-INSERT-1 */
        public void M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1()
        {
            /*" -3200- EXEC SQL INSERT INTO SEGUROS.V0COBERPROPVA ( NRCERTIF ,OCORHIST ,DTINIVIG ,DTTERVIG ,IMPSEGUR ,QUANT_VIDAS ,IMPSEGIND ,CODOPER ,OPCAO_COBER ,IMPMORNATU ,IMPMORACID ,IMPINVPERM ,IMPAMDS ,IMPDH ,IMPDIT ,VLPREMIO ,PRMVG ,PRMAP ,QTTITCAP ,VLTITCAP ,VLCUSTCAP ,IMPSEGCDC ,VLCUSTCDG ,CODUSU ,TIMESTAMP ,IMPSEGAUXF ,VLCUSTAUXF ,PRMDIT ,QTDIT ) VALUES (:PROPVA-NRCERTIF, :PROPVA-OCORHIST, DATE(:COBERP-DTINIVIG) + 1 DAY , '9999-12-31' , :COBERP-IMPMORNATU-ANT, 1, :COBERP-IMPMORNATU-ANT, 820, :PROPVA-OPCAO-COBER, :COBERP-IMPMORNATU-ANT, :COBERP-IMPMORACID-ANT, :COBERP-IMPINVPERM-ANT, :COBERP-IMPAMDS-ANT, :COBERP-IMPDH-ANT, :COBERP-IMPDIT-ANT, :COBERP-PRMVG-ATU, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ANT, :COBERP-QTTITCAP, :COBERP-VLTITCAP, :COBERP-VLCUSTCAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, 'VA0130B' , CURRENT TIMESTAMP, :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I, :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I, :COBERP-PRMDIT-ANT:COBERP-PRMDIT-I, :COBERP-QTDIT:COBERP-QTDIT-I) END-EXEC. */

            var m_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1 = new M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                COBERP_DTINIVIG = COBERP_DTINIVIG.ToString(),
                COBERP_IMPMORNATU_ANT = COBERP_IMPMORNATU_ANT.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                COBERP_IMPMORACID_ANT = COBERP_IMPMORACID_ANT.ToString(),
                COBERP_IMPINVPERM_ANT = COBERP_IMPINVPERM_ANT.ToString(),
                COBERP_IMPAMDS_ANT = COBERP_IMPAMDS_ANT.ToString(),
                COBERP_IMPDH_ANT = COBERP_IMPDH_ANT.ToString(),
                COBERP_IMPDIT_ANT = COBERP_IMPDIT_ANT.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                COBERP_PRMAP_ANT = COBERP_PRMAP_ANT.ToString(),
                COBERP_QTTITCAP = COBERP_QTTITCAP.ToString(),
                COBERP_VLTITCAP = COBERP_VLTITCAP.ToString(),
                COBERP_VLCUSTCAP = COBERP_VLCUSTCAP.ToString(),
                COBERP_IMPSEGCDG = COBERP_IMPSEGCDG.ToString(),
                COBERP_VLCUSTCDG = COBERP_VLCUSTCDG.ToString(),
                COBERP_IMPSEGAUXF = COBERP_IMPSEGAUXF.ToString(),
                COBERP_IMPSEGAUXF_I = COBERP_IMPSEGAUXF_I.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                COBERP_VLCUSTAUXF_I = COBERP_VLCUSTAUXF_I.ToString(),
                COBERP_PRMDIT_ANT = COBERP_PRMDIT_ANT.ToString(),
                COBERP_PRMDIT_I = COBERP_PRMDIT_I.ToString(),
                COBERP_QTDIT = COBERP_QTDIT.ToString(),
                COBERP_QTDIT_I = COBERP_QTDIT_I.ToString(),
            };

            M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1.Execute(m_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1000-MUDA-FAIXA-ETARIA-DB-SELECT-1 */
        public void M_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1()
        {
            /*" -3229- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :PROPVA-FONTE WITH UR END-EXEC. */

            var m_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1 = new M_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1()
            {
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1.Execute(m_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1000-MUDA-FAIXA-ETARIA-DB-UPDATE-3 */
        public void M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3()
        {
            /*" -3130- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET CODOPER = 820, DTMOVTO = :PROPVA-DTMOVTO, OCORHIST = :PROPVA-OCORHIST, SIT_INTERFACE = '0' , TIMESTAMP = CURRENT TIMESTAMP, CODUSU = 'VA0130B' , IDADE = :PROPVA-IDADE WHERE NRCERTIF = :PROPVA-NRCERTIF END-EXEC. */

            var m_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1 = new M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1()
            {
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                PROPVA_DTMOVTO = PROPVA_DTMOVTO.ToString(),
                PROPVA_IDADE = PROPVA_IDADE.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1.Execute(m_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" M-2000-MUDA-FAIXA-ETARIA */
        private void M_2000_MUDA_FAIXA_ETARIA(bool isPerform = false)
        {
            /*" -3364- MOVE '2000-MUDA-FAIXA-ETARIA' TO PARAGRAFO. */
            _.Move("2000-MUDA-FAIXA-ETARIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3366- MOVE 'SELECT V0COBERPROPVA 3' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA 3", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3368- PERFORM 0120-SELECT-V0COBERPROPVA THRU 0120-FIM. */

            M_0120_SELECT_V0COBERPROPVA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_FIM*/


            /*" -3369- IF (COBERP-IMPSEGAUXF-I < ZEROS) */

            if ((COBERP_IMPSEGAUXF_I < 00))
            {

                /*" -3370- MOVE ZEROS TO COBERP-IMPSEGAUXF */
                _.Move(0, COBERP_IMPSEGAUXF);

                /*" -3372- END-IF. */
            }


            /*" -3373- IF (COBERP-VLCUSTAUXF-I < ZEROS) */

            if ((COBERP_VLCUSTAUXF_I < 00))
            {

                /*" -3374- MOVE ZEROS TO COBERP-VLCUSTAUXF */
                _.Move(0, COBERP_VLCUSTAUXF);

                /*" -3376- END-IF. */
            }


            /*" -3377- IF (COBERP-PRMDIT-I < ZEROS) */

            if ((COBERP_PRMDIT_I < 00))
            {

                /*" -3378- MOVE ZEROS TO COBERP-PRMDIT-ANT */
                _.Move(0, COBERP_PRMDIT_ANT);

                /*" -3380- END-IF. */
            }


            /*" -3381- IF (COBERP-QTDIT-I < ZEROS) */

            if ((COBERP_QTDIT_I < 00))
            {

                /*" -3382- MOVE ZEROS TO COBERP-QTDIT */
                _.Move(0, COBERP_QTDIT);

                /*" -3384- END-IF. */
            }


            /*" -3385- COMPUTE WHOST-TXAPIP = PLAVAVGA-TAXAAP / 2. */
            WHOST_TXAPIP.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_TAXAAP / 2f;

            /*" -3387- COMPUTE PLAVAVGA-TAXAAP = PLAVAVGA-TAXAAP - WHOST-TXAPIP. */
            PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_TAXAAP.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_TAXAAP - WHOST_TXAPIP;

            /*" -3394- MOVE 820 TO COD-OPERACAO. */
            _.Move(820, COD_OPERACAO);

            /*" -3398- MOVE COBERP-DTINIVIG TO COBERP-DTTERVIG PROPVA-DTMOVTO DATA-MOVIMENTO. */
            _.Move(COBERP_DTINIVIG, COBERP_DTTERVIG, PROPVA_DTMOVTO, DATA_MOVIMENTO);

            /*" -3400- MOVE 'UPDATE V0SEGURAVG' TO COMANDO. */
            _.Move("UPDATE V0SEGURAVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3405- PERFORM M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1 */

            M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1();

            /*" -3408- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3409- DISPLAY '2000-ERRO AO ATUALIZAR A V0SEGURAVG' */
                _.Display($"2000-ERRO AO ATUALIZAR A V0SEGURAVG");

                /*" -3410- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -3411- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3413- END-IF. */
            }


            /*" -3415- MOVE 'UPDATE V0COBERPROPVA' TO COMANDO. */
            _.Move("UPDATE V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3420- PERFORM M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2 */

            M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2();

            /*" -3423- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3424- DISPLAY '2000-ERRO AO ATUALIZAR A V0COBERPROPVA' */
                _.Display($"2000-ERRO AO ATUALIZAR A V0COBERPROPVA");

                /*" -3425- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -3426- DISPLAY 'OCORHIST  = ' PROPVA-OCORHIST */
                _.Display($"OCORHIST  = {PROPVA_OCORHIST}");

                /*" -3427- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3429- END-IF. */
            }


            /*" -3431- MOVE PROPVA-OCORHIST TO COBERP-OCORHIST-ANT. */
            _.Move(PROPVA_OCORHIST, COBERP_OCORHIST_ANT);

            /*" -3433- COMPUTE PROPVA-OCORHIST = PROPVA-OCORHIST + 1. */
            PROPVA_OCORHIST.Value = PROPVA_OCORHIST + 1;

            /*" -3435- MOVE 'UPDATE V0PROPOSTAVA' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3444- PERFORM M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3 */

            M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3();

            /*" -3447- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3448- DISPLAY '2000-ERRO AO ATUALIZAR A V0PROPOSTAVA' */
                _.Display($"2000-ERRO AO ATUALIZAR A V0PROPOSTAVA");

                /*" -3449- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -3450- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3452- END-IF. */
            }


            /*" -3459- MOVE COBERP-PRMVG-ANT TO COBERP-PRMVG-ATU. */
            _.Move(COBERP_PRMVG_ANT, COBERP_PRMVG_ATU);

            /*" -3461- MOVE PLAVAVGA-PCT-FAIXA-ETARIA TO V0RIND-PCIOF-ATU */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA, V0RIND_PCIOF_ATU);

            /*" -3464- COMPUTE COBERP-PRMVG-ATU ROUNDED = COBERP-PRMVG-ATU * V0RIND-PCIOF-ATU. */
            COBERP_PRMVG_ATU.Value = COBERP_PRMVG_ATU * V0RIND_PCIOF_ATU;

            /*" -3467- COMPUTE COBERP-PRMAP-ATU ROUNDED = COBERP-PRMAP-ANT * V0RIND-PCIOF-ATU. */
            COBERP_PRMAP_ATU.Value = COBERP_PRMAP_ANT * V0RIND_PCIOF_ATU;

            /*" -3472- COMPUTE COBERP-PRMDIT-ATU ROUNDED = COBERP-PRMDIT-ANT * V0RIND-PCIOF-ATU. */
            COBERP_PRMDIT_ATU.Value = COBERP_PRMDIT_ANT * V0RIND_PCIOF_ATU;

            /*" -3473- IF (PRODVG-COBERADIC-PREMIO = 'S' ) */

            if ((PRODVG_COBERADIC_PREMIO == "S"))
            {

                /*" -3475- COMPUTE COBERP-VLPREMIO-ATU = COBERP-PRMVG-ATU + COBERP-PRMAP-ATU */
                COBERP_VLPREMIO_ATU.Value = COBERP_PRMVG_ATU + COBERP_PRMAP_ATU;

                /*" -3476- ELSE */
            }
            else
            {


                /*" -3479- COMPUTE COBERP-VLPREMIO-ATU = COBERP-PRMVG-ATU + COBERP-PRMAP-ATU + WS-GUARDA-PRMADIC */
                COBERP_VLPREMIO_ATU.Value = COBERP_PRMVG_ATU + COBERP_PRMAP_ATU + WS_WORK_AREAS.WS_GUARDA_PRMADIC;

                /*" -3481- END-IF. */
            }


            /*" -3483- MOVE COBERP-VLPREMIO-ATU TO WS-PREMIO-REENQ */
            _.Move(COBERP_VLPREMIO_ATU, WS_PREMIO_REENQ);

            /*" -3485- MOVE 'INSERT HIS_COBER_PROPOST' TO COMANDO. */
            _.Move("INSERT HIS_COBER_PROPOST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3546- PERFORM M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1 */

            M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1();

            /*" -3549- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3550- DISPLAY 'ERRO INSERT HIS_COBER_PROPOST' */
                _.Display($"ERRO INSERT HIS_COBER_PROPOST");

                /*" -3551- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -3552- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3554- END-IF. */
            }


            /*" -3556- IF (INDAGE < 0) OR (INDOPR < 0) OR (INDNUM < 0) OR (INDDIG < 0) */

            if ((INDAGE < 0) || (INDOPR < 0) || (INDNUM < 0) || (INDDIG < 0))
            {

                /*" -3557- MOVE 0 TO MNUM-CTA-CORRENTE */
                _.Move(0, MNUM_CTA_CORRENTE);

                /*" -3558- MOVE ' ' TO MDAC-CTA-CORRENTE */
                _.Move(" ", MDAC_CTA_CORRENTE);

                /*" -3559- ELSE */
            }
            else
            {


                /*" -3560- MOVE OPCAOP-OPRCTADEB TO WS-OPER-SEG */
                _.Move(OPCAOP_OPRCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_OPER_SEG);

                /*" -3561- MOVE OPCAOP-NUMCTADEB TO WS-CTA-SEG */
                _.Move(OPCAOP_NUMCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_CTA_SEG);

                /*" -3562- MOVE WS-CTA-CORRENTE TO MNUM-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.WS_CTA_CORRENTE, MNUM_CTA_CORRENTE);

                /*" -3563- MOVE OPCAOP-DIGCTADEB TO W01N0100 */
                _.Move(OPCAOP_DIGCTADEB, WS_WORK_AREAS.W01A0100.W01N0100);

                /*" -3564- MOVE W01A0100 TO MDAC-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.W01A0100, MDAC_CTA_CORRENTE);

                /*" -3566- END-IF. */
            }


            /*" -3568- MOVE 'SELECT V0FONTE 3' TO COMANDO. */
            _.Move("SELECT V0FONTE 3", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3574- PERFORM M_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1 */

            M_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1();

            /*" -3577- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3578- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3580- END-IF. */
            }


            /*" -3581- IF COBERP-PRMAP-ANT EQUAL ZEROS */

            if (COBERP_PRMAP_ANT == 00)
            {

                /*" -3583- MOVE ZEROS TO COBERP-IMPINVPERM-ANT COBERP-IMPINVPERM-ATU */
                _.Move(0, COBERP_IMPINVPERM_ANT, COBERP_IMPINVPERM_ATU);

                /*" -3583- END-IF. */
            }


        }

        [StopWatch]
        /*" M-2000-MUDA-FAIXA-ETARIA-DB-UPDATE-1 */
        public void M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1()
        {
            /*" -3405- EXEC SQL UPDATE SEGUROS.V0SEGURAVG SET FAIXA = :PLAVAVGA-FAIXA WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1 = new M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1()
            {
                PLAVAVGA_FAIXA = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1.Execute(m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-2000-PROPAUTOM */
        private void M_2000_PROPAUTOM(bool isPerform = false)
        {
            /*" -3589- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

            /*" -3591- MOVE SPACES TO SEGURA-LOT-EMP-SEGURADO. */
            _.Move("", SEGURA_LOT_EMP_SEGURADO);

            /*" -3593- MOVE 'INSERT V0MOVIMENTO  ' TO COMANDO. */
            _.Move("INSERT V0MOVIMENTO  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3670- PERFORM M_2000_PROPAUTOM_DB_INSERT_1 */

            M_2000_PROPAUTOM_DB_INSERT_1();

            /*" -3673- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3677- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3678- GO TO 2000-PROPAUTOM */
                    new Task(() => M_2000_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3679- ELSE */
                }
                else
                {


                    /*" -3680- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -3681- DISPLAY 'VA0130B - ERRO INSERT DA V0MOVIMENTO' */
                    _.Display($"VA0130B - ERRO INSERT DA V0MOVIMENTO");

                    /*" -3683- DISPLAY '          APOLICE..........  ' PROPVA-NUM-APOLICE */
                    _.Display($"          APOLICE..........  {PROPVA_NUM_APOLICE}");

                    /*" -3684- DISPLAY '          SUBGRUPO.........  ' PROPVA-CODSUBES */
                    _.Display($"          SUBGRUPO.........  {PROPVA_CODSUBES}");

                    /*" -3685- DISPLAY '          FONTE............  ' PROPVA-FONTE */
                    _.Display($"          FONTE............  {PROPVA_FONTE}");

                    /*" -3686- DISPLAY '          NUM. PROPOSTA....  ' FONTE-PROPAUTOM */
                    _.Display($"          NUM. PROPOSTA....  {FONTE_PROPAUTOM}");

                    /*" -3687- DISPLAY '          CERTIFICADO......  ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO......  {PROPVA_NRCERTIF}");

                    /*" -3688- DISPLAY '          SQLCODE..........  ' SQLCODE */
                    _.Display($"          SQLCODE..........  {DB.SQLCODE}");

                    /*" -3689- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -3690- END-IF */
                }


                /*" -3692- END-IF. */
            }


            /*" -3694- MOVE 'UPDATE V0FONTE 3' TO COMANDO. */
            _.Move("UPDATE V0FONTE 3", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3699- PERFORM M_2000_PROPAUTOM_DB_UPDATE_1 */

            M_2000_PROPAUTOM_DB_UPDATE_1();

            /*" -3702- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3703- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3705- END-IF. */
            }


            /*" -3707- ADD 1 TO AC-REENQUAD. */
            WS_WORK_AREAS.AC_REENQUAD.Value = WS_WORK_AREAS.AC_REENQUAD + 1;

            /*" -3709- PERFORM 0400-00-SELECT-V0COBERPROPVA THRU 0400-FIM. */

            M_0400_00_SELECT_V0COBERPROPVA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/


            /*" -3711- COMPUTE COBERP-OCORHIST-ANT = COBERP-OCORHIST - 1. */
            COBERP_OCORHIST_ANT.Value = COBERP_OCORHIST - 1;

            /*" -3713- PERFORM 0410-00-DECLARE-VGHISTRAMCOB. */

            M_0410_00_DECLARE_VGHISTRAMCOB(true);

            /*" -3715- MOVE 1 TO WS-IND-ACUM. */
            _.Move(1, WS_WORK_AREAS.WS_IND_ACUM);

            /*" -3715- PERFORM 2200-00-DECLARE-VGPLANACESS THRU 2200-FIM. */

            M_2200_00_DECLARE_VGPLANACESS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2200_FIM*/


        }

        [StopWatch]
        /*" M-2000-PROPAUTOM-DB-INSERT-1 */
        public void M_2000_PROPAUTOM_DB_INSERT_1()
        {
            /*" -3670- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :PROPVA-NRCERTIF, ' ' , '4' , :PROPVA-CODCLIEN, 0, 0, 0, 0, :PLAVAVGA-FAIXA, 'S' , 'S' , :OPCAOP-PERIPGTO, 12, ' ' , :PROPVA-EST-CIV, :PROPVA-SEXO, 0, ' ' , 1, 1, 104, :PROPVA-AGECOBR, ' ' , 0, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, :PLAVAVGA-TAXAAP, :WHOST-TXAPIP, :SEGURA-TXAPAMDS, :SEGURA-TXAPDH, :SEGURA-TXAPDIT, :SEGURA-TXVG, :COBERP-IMPMORNATU-ANT, :COBERP-IMPMORNATU-ATU, :COBERP-IMPMORACID-ANT, :COBERP-IMPMORACID-ATU, :COBERP-IMPINVPERM-ANT, :COBERP-IMPINVPERM-ATU, :COBERP-IMPAMDS-ANT, :COBERP-IMPAMDS-ATU, :COBERP-IMPDH-ANT, :COBERP-IMPDH-ATU, :COBERP-IMPDIT-ANT, :COBERP-IMPDIT-ATU, :COBERP-PRMVG-ANT, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ANT, :COBERP-PRMAP-ATU, :COD-OPERACAO, :SISTEMA-DTMOVABE, 0, '1' , 'VA0130B' , :SISTEMA-DTMOVABE, NULL, NULL, :CLIENT-DTNASC, NULL, :SISTEMA-DTMOVABE, :DATA-MOVIMENTO, NULL, :SEGURA-LOT-EMP-SEGURADO) END-EXEC. */

            var m_2000_PROPAUTOM_DB_INSERT_1_Insert1 = new M_2000_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                PLAVAVGA_FAIXA = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_EST_CIV = PROPVA_EST_CIV.ToString(),
                PROPVA_SEXO = PROPVA_SEXO.ToString(),
                PROPVA_AGECOBR = PROPVA_AGECOBR.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                PLAVAVGA_TAXAAP = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_TAXAAP.ToString(),
                WHOST_TXAPIP = WHOST_TXAPIP.ToString(),
                SEGURA_TXAPAMDS = SEGURA_TXAPAMDS.ToString(),
                SEGURA_TXAPDH = SEGURA_TXAPDH.ToString(),
                SEGURA_TXAPDIT = SEGURA_TXAPDIT.ToString(),
                SEGURA_TXVG = SEGURA_TXVG.ToString(),
                COBERP_IMPMORNATU_ANT = COBERP_IMPMORNATU_ANT.ToString(),
                COBERP_IMPMORNATU_ATU = COBERP_IMPMORNATU_ATU.ToString(),
                COBERP_IMPMORACID_ANT = COBERP_IMPMORACID_ANT.ToString(),
                COBERP_IMPMORACID_ATU = COBERP_IMPMORACID_ATU.ToString(),
                COBERP_IMPINVPERM_ANT = COBERP_IMPINVPERM_ANT.ToString(),
                COBERP_IMPINVPERM_ATU = COBERP_IMPINVPERM_ATU.ToString(),
                COBERP_IMPAMDS_ANT = COBERP_IMPAMDS_ANT.ToString(),
                COBERP_IMPAMDS_ATU = COBERP_IMPAMDS_ATU.ToString(),
                COBERP_IMPDH_ANT = COBERP_IMPDH_ANT.ToString(),
                COBERP_IMPDH_ATU = COBERP_IMPDH_ATU.ToString(),
                COBERP_IMPDIT_ANT = COBERP_IMPDIT_ANT.ToString(),
                COBERP_IMPDIT_ATU = COBERP_IMPDIT_ATU.ToString(),
                COBERP_PRMVG_ANT = COBERP_PRMVG_ANT.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                COBERP_PRMAP_ANT = COBERP_PRMAP_ANT.ToString(),
                COBERP_PRMAP_ATU = COBERP_PRMAP_ATU.ToString(),
                COD_OPERACAO = COD_OPERACAO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                CLIENT_DTNASC = CLIENT_DTNASC.ToString(),
                DATA_MOVIMENTO = DATA_MOVIMENTO.ToString(),
                SEGURA_LOT_EMP_SEGURADO = SEGURA_LOT_EMP_SEGURADO.ToString(),
            };

            M_2000_PROPAUTOM_DB_INSERT_1_Insert1.Execute(m_2000_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-2000-PROPAUTOM-DB-UPDATE-1 */
        public void M_2000_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -3699- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_2000_PROPAUTOM_DB_UPDATE_1_Update1 = new M_2000_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            M_2000_PROPAUTOM_DB_UPDATE_1_Update1.Execute(m_2000_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-2000-MUDA-FAIXA-ETARIA-DB-UPDATE-2 */
        public void M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2()
        {
            /*" -3420- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET DTTERVIG = :COBERP-DTTERVIG WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = :PROPVA-OCORHIST END-EXEC. */

            var m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1 = new M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1()
            {
                COBERP_DTTERVIG = COBERP_DTTERVIG.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1.Execute(m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-2000-MUDA-FAIXA-ETARIA-DB-INSERT-1 */
        public void M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1()
        {
            /*" -3546- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO, OCORR_HISTORICO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMPSEGUR, QUANT_VIDAS, IMPSEGIND, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ, VAL_CUSTO_CAPITALI, IMPSEGCDG, VLCUSTCDG, COD_USUARIO, TIMESTAMP, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTMDIT) VALUES ( :PROPVA-NRCERTIF, :PROPVA-OCORHIST, DATE(:COBERP-DTINIVIG) + 1 DAY , '9999-12-31' , :COBERP-IMPSEGUR-ANT, :COBERP-QUANT-VIDAS-ANT, :COBERP-IMPSEGIND-ANT, :COD-OPERACAO, :COBERP-OPCAO-COBER-ANT, :COBERP-IMPMORNATU-ANT, :COBERP-IMPMORACID-ANT, :COBERP-IMPINVPERM-ANT, :COBERP-IMPAMDS-ANT, :COBERP-IMPDH-ANT, :COBERP-IMPDIT-ANT, :COBERP-VLPREMIO-ATU, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ATU, :COBERP-QTTITCAP, :COBERP-VLTITCAP, :COBERP-VLCUSTCAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, 'VA0130B' , CURRENT TIMESTAMP, :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I, :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I, :COBERP-PRMDIT-ATU:COBERP-PRMDIT-I, :COBERP-QTDIT:COBERP-QTDIT-I) END-EXEC. */

            var m_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1 = new M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                COBERP_DTINIVIG = COBERP_DTINIVIG.ToString(),
                COBERP_IMPSEGUR_ANT = COBERP_IMPSEGUR_ANT.ToString(),
                COBERP_QUANT_VIDAS_ANT = COBERP_QUANT_VIDAS_ANT.ToString(),
                COBERP_IMPSEGIND_ANT = COBERP_IMPSEGIND_ANT.ToString(),
                COD_OPERACAO = COD_OPERACAO.ToString(),
                COBERP_OPCAO_COBER_ANT = COBERP_OPCAO_COBER_ANT.ToString(),
                COBERP_IMPMORNATU_ANT = COBERP_IMPMORNATU_ANT.ToString(),
                COBERP_IMPMORACID_ANT = COBERP_IMPMORACID_ANT.ToString(),
                COBERP_IMPINVPERM_ANT = COBERP_IMPINVPERM_ANT.ToString(),
                COBERP_IMPAMDS_ANT = COBERP_IMPAMDS_ANT.ToString(),
                COBERP_IMPDH_ANT = COBERP_IMPDH_ANT.ToString(),
                COBERP_IMPDIT_ANT = COBERP_IMPDIT_ANT.ToString(),
                COBERP_VLPREMIO_ATU = COBERP_VLPREMIO_ATU.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                COBERP_PRMAP_ATU = COBERP_PRMAP_ATU.ToString(),
                COBERP_QTTITCAP = COBERP_QTTITCAP.ToString(),
                COBERP_VLTITCAP = COBERP_VLTITCAP.ToString(),
                COBERP_VLCUSTCAP = COBERP_VLCUSTCAP.ToString(),
                COBERP_IMPSEGCDG = COBERP_IMPSEGCDG.ToString(),
                COBERP_VLCUSTCDG = COBERP_VLCUSTCDG.ToString(),
                COBERP_IMPSEGAUXF = COBERP_IMPSEGAUXF.ToString(),
                COBERP_IMPSEGAUXF_I = COBERP_IMPSEGAUXF_I.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                COBERP_VLCUSTAUXF_I = COBERP_VLCUSTAUXF_I.ToString(),
                COBERP_PRMDIT_ATU = COBERP_PRMDIT_ATU.ToString(),
                COBERP_PRMDIT_I = COBERP_PRMDIT_I.ToString(),
                COBERP_QTDIT = COBERP_QTDIT.ToString(),
                COBERP_QTDIT_I = COBERP_QTDIT_I.ToString(),
            };

            M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1.Execute(m_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-2000-MUDA-FAIXA-ETARIA-DB-SELECT-1 */
        public void M_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1()
        {
            /*" -3574- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :PROPVA-FONTE WITH UR END-EXEC. */

            var m_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1 = new M_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1()
            {
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1.Execute(m_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-2000-MUDA-FAIXA-ETARIA-DB-UPDATE-3 */
        public void M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3()
        {
            /*" -3444- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET CODOPER = :COD-OPERACAO, DTMOVTO = :DATA-MOVIMENTO, OCORHIST = :PROPVA-OCORHIST, SIT_INTERFACE = '0' , CODUSU = 'VA0130B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF END-EXEC. */

            var m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1 = new M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1()
            {
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                DATA_MOVIMENTO = DATA_MOVIMENTO.ToString(),
                COD_OPERACAO = COD_OPERACAO.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1.Execute(m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" M-2200-00-DECLARE-VGPLANACESS */
        private void M_2200_00_DECLARE_VGPLANACESS(bool isPerform = false)
        {
            /*" -3724- MOVE '2200-00-DECLARE-VGPLANACESS' TO PARAGRAFO. */
            _.Move("2200-00-DECLARE-VGPLANACESS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3726- MOVE 'DECLARE VGPLAACES' TO COMANDO. */
            _.Move("DECLARE VGPLAACES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3744- PERFORM M_2200_00_DECLARE_VGPLANACESS_DB_DECLARE_1 */

            M_2200_00_DECLARE_VGPLANACESS_DB_DECLARE_1();

            /*" -3749- MOVE 'OPEN  VGPLAACES' TO COMANDO. */
            _.Move("OPEN  VGPLAACES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3749- PERFORM M_2200_00_DECLARE_VGPLANACESS_DB_OPEN_1 */

            M_2200_00_DECLARE_VGPLANACESS_DB_OPEN_1();

            /*" -3753- MOVE SPACES TO WFIM-VGPLAACES. */
            _.Move("", WS_WORK_AREAS.WFIM_VGPLAACES);

            /*" -3754- PERFORM 2210-00-FETCH-VG-PLAACES THRU 2210-FIM UNTIL WFIM-VGPLAACES NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_VGPLAACES.IsEmpty()))
            {

                M_2210_00_FETCH_VG_PLAACES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2210_FIM*/

            }

        }

        [StopWatch]
        /*" M-2200-00-DECLARE-VGPLANACESS-DB-OPEN-1 */
        public void M_2200_00_DECLARE_VGPLANACESS_DB_OPEN_1()
        {
            /*" -3749- EXEC SQL OPEN VGPLAACES END-EXEC. */

            VGPLAACES.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2200_FIM*/

        [StopWatch]
        /*" M-2210-00-FETCH-VG-PLAACES */
        private void M_2210_00_FETCH_VG_PLAACES(bool isPerform = false)
        {
            /*" -3764- MOVE '2210-00-FETCH-VG-PLAACES' TO PARAGRAFO. */
            _.Move("2210-00-FETCH-VG-PLAACES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3766- MOVE 'FETCH VGPLAACES' TO COMANDO. */
            _.Move("FETCH VGPLAACES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3773- PERFORM M_2210_00_FETCH_VG_PLAACES_DB_FETCH_1 */

            M_2210_00_FETCH_VG_PLAACES_DB_FETCH_1();

            /*" -3776- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3777- MOVE 'S' TO WFIM-VGPLAACES */
                _.Move("S", WS_WORK_AREAS.WFIM_VGPLAACES);

                /*" -3777- PERFORM M_2210_00_FETCH_VG_PLAACES_DB_CLOSE_1 */

                M_2210_00_FETCH_VG_PLAACES_DB_CLOSE_1();

                /*" -3779- GO TO 2210-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2210_FIM*/ //GOTO
                return;

                /*" -3781- END-IF. */
            }


            /*" -3781- PERFORM 2220-00-INSERT-VG-HISTACESSCOB THRU 2220-FIM. */

            M_2220_00_INSERT_VG_HISTACESSCOB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2220_FIM*/


        }

        [StopWatch]
        /*" M-2210-00-FETCH-VG-PLAACES-DB-FETCH-1 */
        public void M_2210_00_FETCH_VG_PLAACES_DB_FETCH_1()
        {
            /*" -3773- EXEC SQL FETCH VGPLAACES INTO :VGPLAA-NUM-ACESSORIO, :VGPLAA-QTD-COBERTURA, :VGPLAA-IMPSEGURADA, :VGPLAA-CUSTO, :VGPLAA-PREMIO END-EXEC. */

            if (VGPLAACES.Fetch())
            {
                _.Move(VGPLAACES.VGPLAA_NUM_ACESSORIO, VGPLAA_NUM_ACESSORIO);
                _.Move(VGPLAACES.VGPLAA_QTD_COBERTURA, VGPLAA_QTD_COBERTURA);
                _.Move(VGPLAACES.VGPLAA_IMPSEGURADA, VGPLAA_IMPSEGURADA);
                _.Move(VGPLAACES.VGPLAA_CUSTO, VGPLAA_CUSTO);
                _.Move(VGPLAACES.VGPLAA_PREMIO, VGPLAA_PREMIO);
            }

        }

        [StopWatch]
        /*" M-2210-00-FETCH-VG-PLAACES-DB-CLOSE-1 */
        public void M_2210_00_FETCH_VG_PLAACES_DB_CLOSE_1()
        {
            /*" -3777- EXEC SQL CLOSE VGPLAACES END-EXEC */

            VGPLAACES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2210_FIM*/

        [StopWatch]
        /*" M-2220-00-INSERT-VG-HISTACESSCOB */
        private void M_2220_00_INSERT_VG_HISTACESSCOB(bool isPerform = false)
        {
            /*" -3791- MOVE '2220-00-INSERT-VG-HISTACESSCOB' TO PARAGRAFO. */
            _.Move("2220-00-INSERT-VG-HISTACESSCOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3793- MOVE 'INSERT VG_HIST_ACESS_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_ACESS_COB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3802- PERFORM M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1 */

            M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1();

            /*" -3805- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3806- DISPLAY '2220-ERRO AO INSERIR NA TABELA VG_HIST_ACESS_COB' */
                _.Display($"2220-ERRO AO INSERIR NA TABELA VG_HIST_ACESS_COB");

                /*" -3807- DISPLAY 'NRCERTIF = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF = {PROPVA_NRCERTIF}");

                /*" -3808- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3808- END-IF. */
            }


        }

        [StopWatch]
        /*" M-2220-00-INSERT-VG-HISTACESSCOB-DB-INSERT-1 */
        public void M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1()
        {
            /*" -3802- EXEC SQL INSERT INTO SEGUROS.VG_HIST_ACESS_COB VALUES (:PROPVA-NRCERTIF, :PROPVA-OCORHIST, :VGPLAA-NUM-ACESSORIO, :VGPLAA-QTD-COBERTURA, :VGPLAA-IMPSEGURADA, :VGPLAA-CUSTO, :VGPLAA-PREMIO) END-EXEC. */

            var m_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1 = new M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                VGPLAA_NUM_ACESSORIO = VGPLAA_NUM_ACESSORIO.ToString(),
                VGPLAA_QTD_COBERTURA = VGPLAA_QTD_COBERTURA.ToString(),
                VGPLAA_IMPSEGURADA = VGPLAA_IMPSEGURADA.ToString(),
                VGPLAA_CUSTO = VGPLAA_CUSTO.ToString(),
                VGPLAA_PREMIO = VGPLAA_PREMIO.ToString(),
            };

            M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1.Execute(m_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2220_FIM*/

        [StopWatch]
        /*" M-2500-SELECT-V0COBERAPOL */
        private void M_2500_SELECT_V0COBERAPOL(bool isPerform = false)
        {
            /*" -3817- MOVE '2500-SELECT-V0COBERAPOL ' TO PARAGRAFO. */
            _.Move("2500-SELECT-V0COBERAPOL ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3822- MOVE 'SELECT MAX V0COBERAPOL' TO COMANDO. */
            _.Move("SELECT MAX V0COBERAPOL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3824- MOVE 'N' TO WS-FLAG-ERRO */
            _.Move("N", WS_FLAG_ERRO);

            /*" -3833- PERFORM M_2500_SELECT_V0COBERAPOL_DB_SELECT_1 */

            M_2500_SELECT_V0COBERAPOL_DB_SELECT_1();

            /*" -3836- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3837- DISPLAY 'ERRO SELECT V0COBERAPOL' */
                _.Display($"ERRO SELECT V0COBERAPOL");

                /*" -3838- DISPLAY 'NRCERTIF = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF = {PROPVA_NRCERTIF}");

                /*" -3839- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3841- END-IF */
            }


            /*" -3842- IF SOCORR-HISTORICO EQUAL ZEROS */

            if (SOCORR_HISTORICO == 00)
            {

                /*" -3843- MOVE 'S' TO WS-FLAG-ERRO */
                _.Move("S", WS_FLAG_ERRO);

                /*" -3843- END-IF. */
            }


        }

        [StopWatch]
        /*" M-2500-SELECT-V0COBERAPOL-DB-SELECT-1 */
        public void M_2500_SELECT_V0COBERAPOL_DB_SELECT_1()
        {
            /*" -3833- EXEC SQL SELECT VALUE(MAX(B.OCORHIST), 0) INTO :SOCORR-HISTORICO FROM SEGUROS.V1SEGURAVG A, SEGUROS.V0COBERAPOL B WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ITEM = B.NUM_ITEM WITH UR END-EXEC. */

            var m_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 = new M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1.Execute(m_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SOCORR_HISTORICO, SOCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2500_FIM*/

        [StopWatch]
        /*" M-8000-GRAVA-MOVIMENTO */
        private void M_8000_GRAVA_MOVIMENTO(bool isPerform = false)
        {
            /*" -3852- MOVE PROPVA-TEM-ANTECIP TO RM-TEM-ANTECIP */
            _.Move(PROPVA_TEM_ANTECIP, WS_REGISTRO.RM_TEM_ANTECIP);

            /*" -3853- MOVE PROPVA-NUM-APOLICE TO RM-NUM-APOLICE */
            _.Move(PROPVA_NUM_APOLICE, WS_REGISTRO.RM_NUM_APOLICE);

            /*" -3854- MOVE PROPVA-CODSUBES TO RM-CODSUBES */
            _.Move(PROPVA_CODSUBES, WS_REGISTRO.RM_CODSUBES);

            /*" -3855- MOVE PROPVA-NRCERTIF TO RM-NRCERTIF */
            _.Move(PROPVA_NRCERTIF, WS_REGISTRO.RM_NRCERTIF);

            /*" -3856- MOVE PROPVA-CODCLIEN TO RM-CODCLIEN */
            _.Move(PROPVA_CODCLIEN, WS_REGISTRO.RM_CODCLIEN);

            /*" -3857- MOVE PROPVA-OCOREND TO RM-OCOREND */
            _.Move(PROPVA_OCOREND, WS_REGISTRO.RM_OCOREND);

            /*" -3858- MOVE PROPVA-FONTE TO RM-FONTE */
            _.Move(PROPVA_FONTE, WS_REGISTRO.RM_FONTE);

            /*" -3859- MOVE PROPVA-AGECOBR TO RM-AGECOBR */
            _.Move(PROPVA_AGECOBR, WS_REGISTRO.RM_AGECOBR);

            /*" -3860- MOVE PROPVA-OPCAO-COBER TO RM-OPCAO-COBER */
            _.Move(PROPVA_OPCAO_COBER, WS_REGISTRO.RM_OPCAO_COBER);

            /*" -3861- MOVE PROPVA-DTPROXVEN TO RM-DTPROXVEN */
            _.Move(PROPVA_DTPROXVEN, WS_REGISTRO.RM_DTPROXVEN);

            /*" -3862- MOVE PROPVA-DTPROXVEN-1 TO RM-DTPROXVEN-ANT */
            _.Move(PROPVA_DTPROXVEN_1, WS_REGISTRO.RM_DTPROXVEN_ANT);

            /*" -3863- MOVE PROPVA-NRPARCEL TO RM-NRPARCE */
            _.Move(PROPVA_NRPARCEL, WS_REGISTRO.RM_NRPARCE);

            /*" -3864- MOVE PROPVA-CODOPER TO RM-CODOPER */
            _.Move(PROPVA_CODOPER, WS_REGISTRO.RM_CODOPER);

            /*" -3865- MOVE PROPVA-DTMOVTO TO RM-DTMOVTO */
            _.Move(PROPVA_DTMOVTO, WS_REGISTRO.RM_DTMOVTO);

            /*" -3866- MOVE PROPVA-OCORHIST TO RM-OCORHIST */
            _.Move(PROPVA_OCORHIST, WS_REGISTRO.RM_OCORHIST);

            /*" -3867- MOVE PROPVA-SIT-INTERF TO RM-SIT-INTERFACE */
            _.Move(PROPVA_SIT_INTERF, WS_REGISTRO.RM_SIT_INTERFACE);

            /*" -3868- MOVE PROPVA-DTQITBCO-1YEAR TO RM-DTQITBCO-PROX */
            _.Move(PROPVA_DTQITBCO_1YEAR, WS_REGISTRO.RM_DTQITBCO_PROX);

            /*" -3869- MOVE PROPVA-DTQITBCO TO RM-DTQITBCO */
            _.Move(PROPVA_DTQITBCO, WS_REGISTRO.RM_DTQITBCO);

            /*" -3870- MOVE PROPVA-IDADE TO RM-IDADE */
            _.Move(PROPVA_IDADE, WS_REGISTRO.RM_IDADE);

            /*" -3871- MOVE PROPVA-CODPRODU TO RM-CODPRODU */
            _.Move(PROPVA_CODPRODU, WS_REGISTRO.RM_CODPRODU);

            /*" -3872- MOVE PROPVA-STA-ANTECIPACAO TO RM-STA-ANTECIPACAO */
            _.Move(PROPVA_STA_ANTECIPACAO, WS_REGISTRO.RM_STA_ANTECIPACAO);

            /*" -3873- MOVE PROPVA-STA-MUDANCA-PLANO TO RM-STA-MUDANCA-PLANO. */
            _.Move(PROPVA_STA_MUDANCA_PLANO, WS_REGISTRO.RM_STA_MUDANCA_PLANO);

            /*" -3874- MOVE PRODVG-TEM-IGPM TO RM-IGPM */
            _.Move(PRODVG_TEM_IGPM, WS_REGISTRO.RM_IGPM);

            /*" -3875- MOVE PRODVG-TEM-FAIXAETA TO RM-REENQUAD */
            _.Move(PRODVG_TEM_FAIXAETA, WS_REGISTRO.RM_REENQUAD);

            /*" -3876- WRITE REG-VAMOVTO FROM WS-REGISTRO. */
            _.Move(WS_REGISTRO.GetMoveValues(), REG_VAMOVTO);

            VAMOVTO.Write(REG_VAMOVTO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/

        [StopWatch]
        /*" M-8100-GRAVA-MOVCORRIG */
        private void M_8100_GRAVA_MOVCORRIG(bool isPerform = false)
        {
            /*" -3884- IF FLAG-IGPM EQUAL 'S' */

            if (FLAG_IGPM == "S")
            {

                /*" -3885- MOVE 'S' TO RM-IGPM */
                _.Move("S", WS_REGISTRO.RM_IGPM);

                /*" -3886- ELSE */
            }
            else
            {


                /*" -3887- MOVE 'N' TO RM-IGPM */
                _.Move("N", WS_REGISTRO.RM_IGPM);

                /*" -3889- END-IF. */
            }


            /*" -3890- IF WTEM-REENQUADRAMENTO EQUAL 'SIM' */

            if (WTEM_REENQUADRAMENTO == "SIM")
            {

                /*" -3891- MOVE 'S' TO RM-REENQUAD */
                _.Move("S", WS_REGISTRO.RM_REENQUAD);

                /*" -3892- ELSE */
            }
            else
            {


                /*" -3893- MOVE 'N' TO RM-REENQUAD */
                _.Move("N", WS_REGISTRO.RM_REENQUAD);

                /*" -3895- END-IF. */
            }


            /*" -3897- MOVE WS-REGISTRO TO WS-MOVCORR. */
            _.Move(WS_REGISTRO, WS_MOVCORR);

            /*" -3898- IF FLAG-IGPM EQUAL 'S' */

            if (FLAG_IGPM == "S")
            {

                /*" -3899- IF VG077-COD-MOEDA EQUAL 23 */

                if (VG077_COD_MOEDA == 23)
                {

                    /*" -3900- MOVE 'IGPM' TO RC-MOEDA */
                    _.Move("IGPM", WS_MOVCORR.RC_MOEDA);

                    /*" -3901- ELSE */
                }
                else
                {


                    /*" -3902- MOVE 'IPCA' TO RC-MOEDA */
                    _.Move("IPCA", WS_MOVCORR.RC_MOEDA);

                    /*" -3903- END-IF */
                }


                /*" -3906- STRING WS-MES-MIN '/' WS-ANO-MIN DELIMITED BY SIZE INTO RC-PERINI */
                #region STRING
                var spl6 = WS_WORK_AREAS.WS_DATA_MIN_R.WS_MES_MIN.GetMoveValues();
                spl6 += "/";
                var spl7 = WS_WORK_AREAS.WS_DATA_MIN_R.WS_ANO_MIN.GetMoveValues();
                var results8 = spl6 + spl7;
                _.Move(results8, WS_MOVCORR.RC_PERINI);
                #endregion

                /*" -3909- STRING WS-MES-MAX '/' WS-ANO-MAX DELIMITED BY SIZE INTO RC-PERFIM */
                #region STRING
                var spl8 = WS_WORK_AREAS.WS_DATA_MAX_R.WS_MES_MAX.GetMoveValues();
                spl8 += "/";
                var spl9 = WS_WORK_AREAS.WS_DATA_MAX_R.WS_ANO_MAX.GetMoveValues();
                var results10 = spl8 + spl9;
                _.Move(results10, WS_MOVCORR.RC_PERFIM);
                #endregion

                /*" -3910- MOVE WS-IGPM-ACUM TO RC-FATOR */
                _.Move(WS_WORK_AREAS.WS_IGPM_ACUM, WS_MOVCORR.RC_FATOR);

                /*" -3911- MOVE WS-CAPITAL-ANT TO RC-CAPITAL-ANT */
                _.Move(WS_CAPITAL_ANT, WS_MOVCORR.RC_CAPITAL_ANT);

                /*" -3912- MOVE WS-PREMIO-ANT TO RC-PREMIO-ANT */
                _.Move(WS_PREMIO_ANT, WS_MOVCORR.RC_PREMIO_ANT);

                /*" -3913- MOVE WS-CAPITAL-ATU TO RC-CAPITAL-ATU */
                _.Move(WS_CAPITAL_ATU, WS_MOVCORR.RC_CAPITAL_ATU);

                /*" -3914- MOVE WS-PREMIO-ATU TO RC-PREMIO-ATU */
                _.Move(WS_PREMIO_ATU, WS_MOVCORR.RC_PREMIO_ATU);

                /*" -3915- IF WTEM-REENQUADRAMENTO EQUAL 'SIM' */

                if (WTEM_REENQUADRAMENTO == "SIM")
                {

                    /*" -3917- MOVE WS-PREMIO-REENQ TO RC-PREMIO-REENQ */
                    _.Move(WS_PREMIO_REENQ, WS_MOVCORR.RC_PREMIO_REENQ);

                    /*" -3919- MOVE PLAVAVGA-PCT-FAIXA-ETARIA TO RC-PERC-REENQ */
                    _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA, WS_MOVCORR.RC_PERC_REENQ);

                    /*" -3920- ELSE */
                }
                else
                {


                    /*" -3922- MOVE ZEROS TO RC-PREMIO-REENQ RC-PERC-REENQ */
                    _.Move(0, WS_MOVCORR.RC_PREMIO_REENQ, WS_MOVCORR.RC_PERC_REENQ);

                    /*" -3923- END-IF */
                }


                /*" -3924- ELSE */
            }
            else
            {


                /*" -3925- MOVE SPACES TO RC-MOEDA */
                _.Move("", WS_MOVCORR.RC_MOEDA);

                /*" -3926- MOVE SPACES TO RC-PERINI */
                _.Move("", WS_MOVCORR.RC_PERINI);

                /*" -3927- MOVE SPACES TO RC-PERFIM */
                _.Move("", WS_MOVCORR.RC_PERFIM);

                /*" -3932- MOVE ZEROS TO RC-FATOR RC-CAPITAL-ANT RC-PREMIO-ANT RC-CAPITAL-ATU RC-PREMIO-ATU */
                _.Move(0, WS_MOVCORR.RC_FATOR, WS_MOVCORR.RC_CAPITAL_ANT, WS_MOVCORR.RC_PREMIO_ANT, WS_MOVCORR.RC_CAPITAL_ATU, WS_MOVCORR.RC_PREMIO_ATU);

                /*" -3934- END-IF. */
            }


            /*" -3945- MOVE ';' TO RC-SEP-01 RC-SEP-02 RC-SEP-03 RC-SEP-04 RC-SEP-05 RC-SEP-06 RC-SEP-07 RC-SEP-08 RC-SEP-09 RC-SEP-10. */
            _.Move(";", WS_MOVCORR.RC_SEP_01, WS_MOVCORR.RC_SEP_02, WS_MOVCORR.RC_SEP_03, WS_MOVCORR.RC_SEP_04, WS_MOVCORR.RC_SEP_05, WS_MOVCORR.RC_SEP_06, WS_MOVCORR.RC_SEP_07, WS_MOVCORR.RC_SEP_08, WS_MOVCORR.RC_SEP_09, WS_MOVCORR.RC_SEP_10);

            /*" -3946- WRITE REG-MOVCORR FROM WS-MOVCORR. */
            _.Move(WS_MOVCORR.GetMoveValues(), REG_MOVCORR);

            MOVCORR.Write(REG_MOVCORR.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8100_FIM*/

        [StopWatch]
        /*" M-8200-GRAVA-MOVDESP */
        private void M_8200_GRAVA_MOVDESP(bool isPerform = false)
        {
            /*" -3954- MOVE PROPVA-TEM-ANTECIP TO RD-TEM-ANTECIP */
            _.Move(PROPVA_TEM_ANTECIP, WS_MOVDESP.RD_TEM_ANTECIP);

            /*" -3955- MOVE PROPVA-NRCERTIF TO RD-NUM-CERTIF */
            _.Move(PROPVA_NRCERTIF, WS_MOVDESP.RD_NUM_CERTIF);

            /*" -3956- MOVE PROPVA-NUM-APOLICE TO RD-NUM-APOLICE */
            _.Move(PROPVA_NUM_APOLICE, WS_MOVDESP.RD_NUM_APOLICE);

            /*" -3957- MOVE PROPVA-CODSUBES TO RD-CODSUBES */
            _.Move(PROPVA_CODSUBES, WS_MOVDESP.RD_CODSUBES);

            /*" -3961- MOVE ';' TO RD-SEP-01 RD-SEP-02 RD-SEP-03 RD-SEP-04 */
            _.Move(";", WS_MOVDESP.RD_SEP_01, WS_MOVDESP.RD_SEP_02, WS_MOVDESP.RD_SEP_03, WS_MOVDESP.RD_SEP_04);

            /*" -3962- WRITE REG-MOVDESP FROM WS-MOVDESP */
            _.Move(WS_MOVDESP.GetMoveValues(), REG_MOVDESP);

            MOVDESP.Write(REG_MOVDESP.GetMoveValues().ToString());

            /*" -3963- ADD 1 TO AC-MOVDESP. */
            WS_WORK_AREAS.AC_MOVDESP.Value = WS_WORK_AREAS.AC_MOVDESP + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -3971- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3972- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3972- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -3976- PERFORM 9100-TOTAIS-CONTROLE THRU 9100-FIM */

            M_9100_TOTAIS_CONTROLE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9100_FIM*/


            /*" -3977- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3979- DISPLAY '*** VA0130B *** TERMINO NORMAL' . */
            _.Display($"*** VA0130B *** TERMINO NORMAL");

            /*" -3981- CLOSE VAMOVTO MOVCORR MOVDESP. */
            VAMOVTO.Close();
            MOVCORR.Close();
            MOVDESP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9100-TOTAIS-CONTROLE */
        private void M_9100_TOTAIS_CONTROLE(bool isPerform = false)
        {
            /*" -3989- DISPLAY ' ' */
            _.Display($" ");

            /*" -3990- DISPLAY 'MOVIMENTO LIDO ................ ' AC-MOVSELE */
            _.Display($"MOVIMENTO LIDO ................ {WS_WORK_AREAS.AC_MOVSELE}");

            /*" -3991- DISPLAY ' ' */
            _.Display($" ");

            /*" -3992- DISPLAY 'LIDOS NAO ANTECIPADOS.......... ' AC-LIDOS. */
            _.Display($"LIDOS NAO ANTECIPADOS.......... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -3993- DISPLAY 'LIDOS ANTECIPADOS MIGRADOS..... ' AC-LIDOS-2. */
            _.Display($"LIDOS ANTECIPADOS MIGRADOS..... {WS_WORK_AREAS.AC_LIDOS_2}");

            /*" -3994- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3995- DISPLAY 'TOTAL CORRECOES IGP-M.......... ' AC-IGPM. */
            _.Display($"TOTAL CORRECOES IGP-M.......... {WS_WORK_AREAS.AC_IGPM}");

            /*" -3996- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3997- DISPLAY 'CORRECOES IGP-M CURSOR-1....... ' AC-IGPM-1 */
            _.Display($"CORRECOES IGP-M CURSOR-1....... {WS_WORK_AREAS.AC_IGPM_1}");

            /*" -3998- DISPLAY 'CORRECOES IGP-M ANTECIP.MIGRADO ' AC-IGPM-2. */
            _.Display($"CORRECOES IGP-M ANTECIP.MIGRADO {WS_WORK_AREAS.AC_IGPM_2}");

            /*" -3999- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4000- DISPLAY 'MUDANCAS DE FAIXA ETARIA....... ' AC-REENQUAD. */
            _.Display($"MUDANCAS DE FAIXA ETARIA....... {WS_WORK_AREAS.AC_REENQUAD}");

            /*" -4001- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4002- DISPLAY '----------------- DESPREZADOS ------------------' */
            _.Display($"----------------- DESPREZADOS ------------------");

            /*" -4004- DISPLAY 'MOVIMENTO C/ERRO............... ' AC-DESP-PRODUTO */
            _.Display($"MOVIMENTO C/ERRO............... {WS_WORK_AREAS.AC_DESP_PRODUTO}");

            /*" -4006- DISPLAY 'MOVIMENTO S/CORRECAO IGPM...... ' AC-SEM-IGPM */
            _.Display($"MOVIMENTO S/CORRECAO IGPM...... {WS_WORK_AREAS.AC_SEM_IGPM}");

            /*" -4008- DISPLAY 'ANTECIP. NAO MIGRADOS.......... ' AC-NAO-MIGRADO */
            _.Display($"ANTECIP. NAO MIGRADOS.......... {WS_WORK_AREAS.AC_NAO_MIGRADO}");

            /*" -4010- DISPLAY 'SEM OCORRENCIA NA V0COBERAPOL.. ' WS-ERRO-COBER */
            _.Display($"SEM OCORRENCIA NA V0COBERAPOL.. {WS_WORK_AREAS.WS_ERRO_COBER}");

            /*" -4012- DISPLAY 'FORA DO PERIODO DE CORRECAO.....' AC-PROXVEN-FORA */
            _.Display($"FORA DO PERIODO DE CORRECAO.....{WS_WORK_AREAS.AC_PROXVEN_FORA}");

            /*" -4014- DISPLAY 'NAO EH MES ANIVERSARIO SEGURO.. ' AC-DESP-NOT-NIVER */
            _.Display($"NAO EH MES ANIVERSARIO SEGURO.. {WS_WORK_AREAS.AC_DESP_NOT_NIVER}");

            /*" -4016- DISPLAY 'ATUALIZACAO JA REALIZADA....... ' AC-DESP-JA-ATUAL */
            _.Display($"ATUALIZACAO JA REALIZADA....... {WS_WORK_AREAS.AC_DESP_JA_ATUAL}");

            /*" -4018- DISPLAY '     NAO ANTECIPADOS........... ' AC-DESP-ATUAL-1 */
            _.Display($"     NAO ANTECIPADOS........... {WS_WORK_AREAS.AC_DESP_ATUAL_1}");

            /*" -4020- DISPLAY '     ANTECIPADOS MIGRADOS...... ' AC-DESP-ATUAL-2 */
            _.Display($"     ANTECIPADOS MIGRADOS...... {WS_WORK_AREAS.AC_DESP_ATUAL_2}");

            /*" -4021- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4029- COMPUTE AC-DESP-TOTAL = AC-DESP-PRODUTO + AC-SEM-IGPM + AC-NAO-MIGRADO + WS-ERRO-COBER + AC-PROXVEN-FORA + AC-DESP-NOT-NIVER + AC-DESP-JA-ATUAL */
            WS_WORK_AREAS.AC_DESP_TOTAL.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + WS_WORK_AREAS.AC_SEM_IGPM + WS_WORK_AREAS.AC_NAO_MIGRADO + WS_WORK_AREAS.WS_ERRO_COBER + WS_WORK_AREAS.AC_PROXVEN_FORA + WS_WORK_AREAS.AC_DESP_NOT_NIVER + WS_WORK_AREAS.AC_DESP_JA_ATUAL;

            /*" -4031- DISPLAY 'TOTAL DESPREZADOS.............. ' AC-DESP-TOTAL. */
            _.Display($"TOTAL DESPREZADOS.............. {WS_WORK_AREAS.AC_DESP_TOTAL}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9100_FIM*/

        [StopWatch]
        /*" M-9998-ERRO */
        private void M_9998_ERRO(bool isPerform = false)
        {
            /*" -4038- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4042- MOVE 3 TO RETURN-CODE. */
            _.Move(3, RETURN_CODE);

            /*" -4044- PERFORM 9100-TOTAIS-CONTROLE THRU 9100-FIM. */

            M_9100_TOTAIS_CONTROLE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9100_FIM*/


            /*" -4044- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -4051- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4053- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4054- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.FILLER_43.WSQLCODE);

            /*" -4055- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.FILLER_43.WSQLERRD1);

            /*" -4056- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.FILLER_43.WSQLERRD2);

            /*" -4058- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -4060- DISPLAY '*** VA0130B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA0130B *** ROLLBACK EM ANDAMENTO ...");

            /*" -4060- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4063- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4065- DISPLAY '*** VA0130B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA0130B *** ERRO DE EXECUCAO");

            /*" -4067- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -4067- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}