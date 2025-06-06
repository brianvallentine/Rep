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
using Sias.Bilhetes.DB2.BI7028B;

namespace Code
{
    public class BI7028B
    {
        public bool IsCall { get; set; }

        public BI7028B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        F      */
        /*"      ******************************************************************      */
        /*"      *  CAD-51.476                                                    *      */
        /*"      *  DATA: 27/12/2010                                              *      */
        /*"      *  ANALISTA/PROGRAMADOR: MARCO PAIVA (FAST COMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *  EMITE BILHETES AP - KIT POS-VENDA DOS PRODUTOS ABAIXO:        *      */
        /*"      *                                                                *      */
        /*"      *        8114 - AP VIDA TRANQUILA PREMIADO EDUCACIONAL           *      */
        /*"      *        8115 - AP VIDA TRANQUILA PREMIADO SAF                   *      */
        /*"      *        8116 - AP VIDA TRANQUILA PREMIADO CHECK LAR             *      */
        /*"      *        8117 - AP VIDA TRANQUILA PREMIADO HELP DESK             *      */
        /*"      *        8118 - AP VIDA TRANQUILA PREMIADO NUTRICIONAL           *      */
        /*"      *        8119 - AP VIDA TRANQUILA PREMIADO NUTRICIONAL           *      */
        /*"      *        8120 - AP VIDA TRANQUILA PREMIADO SAF                   *      */
        /*"      *        8121 - AP VIDA TRANQUILA PREMIADO CHECK LAR             *      */
        /*"      *        8122 - AP VIDA TRANQUILA PREMIADO EDUCACIONAL           *      */
        /*"      *        8123 - AP VIDA TRANQUILA PREMIADO HELP DESK             *      */
        /*"      *        8124 - FACIL PLANO ODONTO                               *      */
        /*"      *        8125 - VIDA AP + RD                                     *      */
        /*"      *                                                                *      */
        /*"      *  CODIGO DA SOLICITACAO                                         *      */
        /*"      *        01 - EMISSAO DA 1.VIA                                   *      */
        /*"      *        02 - EMISSAO DA 2.VIA                                   *      */
        /*"      *        03 - RENOVACAO/ATUAL.MONETARIA                          *      */
        /*"      *        05 - 2.VIA DO CARTAO DE BENEFICIOS                      *      */
        /*"      *        06 - CARTA DO NUMERO DE SORTEIO                         *      */
        /*"      *        07 - 2.VIA DA CARTA DO NUMERO DE SORTEIO                *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                         ALTERACOES                             *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"V.24  *   VERSAO 24 - INCIDENTE 600300                                 *      */
        /*"      *             - RETIRAR BILHETES CANCELADOS NO CURSOR PRINCIPAL  *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/08/2024 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.24         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *  VERSAO 23  - DEMANDA 578503 / TAREFA 583612                   *      */
        /*"      *                                                                *      */
        /*"      *    - 3 CAMPOS DE NOME SOCIAL ADICIONADOS NO FINAL DOS ARQUIVOS:*      */
        /*"      *      => NOME-CLIENTE-SOCIAL, NOME-ESTIPULANTE-SOCIAL,          *      */
        /*"      *         NOME-SEGURADO-SOCIAL                                   *      */
        /*"      *                                                                *      */
        /*"      *    UTILIDADE:                                                  *      */
        /*"      *    SE OS CAMPOS NOME-CLIENTE-SOCIAL, NOME-ESTIPULANTE-SOCIAL E *      */
        /*"      *    NOME-SEGURADO-SOCIAL ESTIVEREM PREENCHIDOS NO ARQUIVO, O CCM*      */
        /*"      *    DEVERA UTILIZA-LOS NA COMUNICACAO AO CLIENTE, CASO CONTRARIO*      */
        /*"      *    CONTINUAR USANDO OS CAMPOS NOME-CLIENTE, NOME-ESTIPULANTE E *      */
        /*"      *    NOME-SEGURADO                                               *      */
        /*"      *                                                                *      */
        /*"      *  EM 19/05/2024 - ANSELMO SOUSA                                 *      */
        /*"      *                                        PROCURE POR V.23        *      */
        /*"JV122 *----------------------------------------------------------------*      */
        /*"JV122 *VERSAO 22: JV1 DEMANDA 259756 - KINKAS 10/10/2020               *      */
        /*"JV122 *           ALTERA FORMULARIOS FASE 2 PARA EMPRESA 11 - JV1      *      */
        /*"JV122 *           - PROCURAR POR JV122                                 *      */
        /*"JV121 *-----------------------------------------------------------------      */
        /*"JV121 *VERSAO 21: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV121 *           ALTERA FORMULARIOS PARA EMPRESA 11 - JV1                    */
        /*"JV121 *           - PROCURAR POR JV121                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - ALTERA CONSULTA AOS DADOS DO T�TULO ACOPLADO,    *      */
        /*"      *               PASSANDO O CONTROLE DE CONSULTAAPENAS PARA A     *      */
        /*"      *               SUBROTINA VG0716S, ONDE CHAMA A SPBFC012.        *      */
        /*"      *               CADMUS 179924                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/03/2020 - ALCIONE ARAUJO (STEFANINI)                   *      */
        /*"      *   EM 11/05/2020 - CLAUDETE RADEL - RETIRAR DISPLAYS            *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - HIST 181.576                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/02/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18 - CAD 149542                                       *      */
        /*"      *                                                                *      */
        /*"      *               PARA ATENDIMENTO AO UNIC, FOI ALTERADA A DATA    *      */
        /*"      *               DE PROCESSAMENTO DAS SOLICITA��ES DE RELAT�RIO   *      */
        /*"      *               PARA O DIA SISTEMA ABERTO MENOS 05 DIA.          *      */
        /*"      *               ASSIM O PROGRAMA CONSEGUE ENVIAR O N�MERO DE     *      */
        /*"      *               SORTEIO, DEVIDO A ROTINA DA CAP PROCESSAR AP�S.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/04/2017 - LUIGI CONTE                                  *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.18             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17 - CAD 119494                                       *      */
        /*"      *               PARA ATENDIMENTO AO UNIC, FOI ALTERADA A DATA    *      */
        /*"      *               DE PROCESSAMENTO DAS SOLICITA��ES DE RELAT�RIO   *      */
        /*"      *               PARA O DIA SISTEMA ABERTO MENOS 01 DIA.          *      */
        /*"      *               ASSIM O PROGRAMA CONSEGUE ENVIAR O N�MERO DE     *      */
        /*"      *               SORTEIO, DEVIDO A ROTINA DA CAP PROCESSAR AP�S.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/11/2016 - MAURO ROCHA DA CRUZ                          *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.17             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - CADMUS 139513                                    *      */
        /*"      *                                                                *      */
        /*"      *             - ACESSAR N�MERO DE SORTEIO DO F�CIL AP            *      */
        /*"      *               DIRETAMENTE NA CAP.                              *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *    EM 21/10/2016 - MAURO ROCHA DA CRUZ                         *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.16        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - CADMUS 139513 - ABEND                            *      */
        /*"      *                                                                *      */
        /*"      *             - RESOLU��O ABEND PRODU��O                         *      */
        /*"      *               RETIRAR DUPLICIDADE N�MERO SORTEIO               *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *    EM 06/07/2016 - MAURO ROCHA DA CRUZ                         *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.15        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - CADMUS 139456 - ABEND                            *      */
        /*"      *                                                                *      */
        /*"      *             - RESOLU��O ABEND PRODU��O                         *      */
        /*"      *               ALTERAR TAMANHO ARQUIVO NO PROGRAMA E NO JCL     *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *    EM 05/07/2016 - MAURO ROCHA DA CRUZ                         *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.14        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - CADMUS 124862                                    *      */
        /*"      *                                                                *      */
        /*"      *             - AP MEDICAMENTOS                                  *      */
        /*"      *               DESFAZER A ALTERA��O DA VERS�O 11.               *      */
        /*"      *               PREPARAR O PROGRAMA PARA IMPRIMIR FORMUL�RIOS    *      */
        /*"      *               DIFERENTES PARA ADES�O E SOLICITA��O DE 2� VIA.  *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *    EM 01/07/2016 - MAURO ROCHA DA CRUZ                         *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.13        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 - CAD 119494                                       *      */
        /*"      *               MODULO DE RETENCAO - PROJETO UNIC                *      */
        /*"      *               INCLUIR FILTROS DE ENVIO DOS FORMUL�RIOS         *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/06/2016 - LUIGI CONTE                                  *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.12             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - CADMUS 129012                                    *      */
        /*"      *                                                                *      */
        /*"      *             - AP MEDICAMENTOS                                  *      */
        /*"      *               SUSPENDER EMISSAO DO VA52 PARA O PRODUTO 3710    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *    EM 27/01/2016 - RIBAMAR MARQUES                             *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.11        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - CADMUS 124862                                    *      */
        /*"      *                                                                *      */
        /*"      *             - AP MEDICAMENTOS                                  *      */
        /*"      *               AJUSTE DO ARQUIVO SA�DA PARA NOVOS CAMPOS.       *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *    EM 23/11/2015 - MAURO ROCHA DA CRUZ                         *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.10        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - CADMUS 117098                                    *      */
        /*"      *                                                                *      */
        /*"      *             - PROJETO UNIC - CORRECAO DE FORMULARIOS           *      */
        /*"      *               AJUSTE DA INFORMACAO DE ENDERECO DO CLIENTE.     *      */
        /*"      *               UTILIZAR MAX DE OCORR_ENDERECO                   *      */
        /*"      *                                                                *      */
        /*"      *    EM 05/08/2015 - RIBAMAR MARQUES (STEFANINI)                 *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.09        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"V.07  *----------------------------------------------------------------*      */
        /*"      * VERSAO 07                                           16/01/2015 *      */
        /*"      *                                                                *      */
        /*"      * CADMUS 102506 - ELIERMES OLIVEIRA                                     */
        /*"      *                                                                *      */
        /*"      * - GERAR REGISTRO COM APENAS UMA LINHA PARA FACILITAR GERACAO DE*      */
        /*"      *   CERTIFIADO                                                   *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR: V.07 *      */
        /*"V.06  *----------------------------------------------------------------*      */
        /*"      * VERSAO 06                                           01/02/2013 *      */
        /*"      *                                                                *      */
        /*"      * CADMUS 75548 - SAC 44 - COREON                                 *      */
        /*"      * POS VENDA BILHETE PA MAIS ESTUDOS                              *      */
        /*"      *                                                                *      */
        /*"      * - RECUPERAR DESCRICAO DAS COBERTURAS PELAS TABELAS:            *      */
        /*"      *   CLAUSULAS E VG_ACESSORIO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR: V.06 *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 05                                                    *      */
        /*"      *             - CAD 69.948                                       *      */
        /*"      *             LOCKS DAS ROTINAS JPFCD01 E JPBID07.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/05/2012 - ROGERIO MACIEL (FAST COMPUTER)               *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD-68.235                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CUSTOMIZACAO PARA O CANAL DE VENDA MAIS ESTUDO   *      */
        /*"      *               OS PROGRAMAS                                     *      */
        /*"      *                                                                *      */
        /*"      *                  . BI3600B                                     *      */
        /*"      *                  . BI3602B                                     *      */
        /*"      *                  . BI0030B                                     *      */
        /*"      *                  . BI0031B                                     *      */
        /*"      *                  . BI0422B                                     *      */
        /*"      *                  . BI0602B                                     *      */
        /*"      *                  . BI6032B                                     *      */
        /*"      *                  . BI7028B                                     *      */
        /*"      *                  . BI7029B                                     *      */
        /*"      *                                                                *      */
        /*"      *                FORAM PREPARADOS PARA TRABALHAR COM PARAMETROS  *      */
        /*"      *                DEFINIDOS NA SEGUROS.ARQUIVOS_SIVPF.                   */
        /*"      *                                                                *      */
        /*"      *   EM 14/04/2012 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 03                                                    *      */
        /*"      *             - CAD 201.137                                      *      */
        /*"      *               - AJUSTE NO PROGRAMA CONFORME SOLICITADO NA DT   *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/08/2011 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 02                                                    *      */
        /*"      *             - CAD 201.059                                      *      */
        /*"      *               - AJUSTE NO PROGRAMA CONFORME SOLICITADO NA DT   *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/04/2011 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 201.037                                      *      */
        /*"      *               - AJUSTE NO PROGRAMA CONFORME SOLICITADO NA DT   *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/03/2011 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RBI7028B { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RBI7028B
        {
            get
            {
                _.Move(RBI7028B_RECORD, _RBI7028B); VarBasis.RedefinePassValue(RBI7028B_RECORD, _RBI7028B, RBI7028B_RECORD); return _RBI7028B;
            }
        }
        public FileBasis _RBI7028I { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RBI7028I
        {
            get
            {
                _.Move(RBI7028I_RECORD, _RBI7028I); VarBasis.RedefinePassValue(RBI7028I_RECORD, _RBI7028I, RBI7028I_RECORD); return _RBI7028I;
            }
        }
        public FileBasis _RBI7028P { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RBI7028P
        {
            get
            {
                _.Move(RBI7028P_RECORD, _RBI7028P); VarBasis.RedefinePassValue(RBI7028P_RECORD, _RBI7028P, RBI7028P_RECORD); return _RBI7028P;
            }
        }
        public FileBasis _RBI7028H { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RBI7028H
        {
            get
            {
                _.Move(RBI7028H_RECORD, _RBI7028H); VarBasis.RedefinePassValue(RBI7028H_RECORD, _RBI7028H, RBI7028H_RECORD); return _RBI7028H;
            }
        }
        public SortBasis<BI7028B_REG_SBI7028B> SBI7028B { get; set; } = new SortBasis<BI7028B_REG_SBI7028B>(new BI7028B_REG_SBI7028B());
        /*"01                RBI7028B-RECORD     PIC X(4500).*/
        public StringBasis RBI7028B_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01                RBI7028I-RECORD     PIC X(4500).*/
        public StringBasis RBI7028I_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01                RBI7028P-RECORD     PIC X(4500).*/
        public StringBasis RBI7028P_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01                RBI7028H-RECORD     PIC X(4500).*/
        public StringBasis RBI7028H_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01                REG-SBI7028B.*/
        public BI7028B_REG_SBI7028B REG_SBI7028B { get; set; } = new BI7028B_REG_SBI7028B();
        public class BI7028B_REG_SBI7028B : VarBasis
        {
            /*"   05            SVA-NUM-CEP         PIC 9(008).*/
            public IntBasis SVA_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   05            SVA-CPF             PIC 9(011).*/
            public IntBasis SVA_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"   05            SVA-BILHETE         PIC 9(015).*/
            public IntBasis SVA_BILHETE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"   05            SVA-NRAPOLICE       PIC 9(013).*/
            public IntBasis SVA_NRAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"   05            SVA-CODUSU          PIC X(008).*/
            public StringBasis SVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05            SVA-RAMO            PIC 9(004).*/
            public IntBasis SVA_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05            SVA-CODRELAT        PIC X(008).*/
            public StringBasis SVA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05            SVA-CODCLIEN        PIC 9(009).*/
            public IntBasis SVA_CODCLIEN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   05            SVA-TP-PESSOA       PIC X(001).*/
            public StringBasis SVA_TP_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05            SVA-DTMOVTO         PIC X(010).*/
            public StringBasis SVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05            SVA-CODOPER         PIC 9(004).*/
            public IntBasis SVA_CODOPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05            SVA-IMPSEGCDG       PIC 9(013)V99.*/
            public DoubleBasis SVA_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"   05            SVA-VLPREMIO        PIC 9(013)V99.*/
            public DoubleBasis SVA_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"   05            SVA-AGECTADEB       PIC 9(004).*/
            public IntBasis SVA_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05            SVA-OPRCTADEB       PIC 9(004).*/
            public IntBasis SVA_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05            SVA-NUMCTADEB       PIC 9(012).*/
            public IntBasis SVA_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"   05            SVA-DIGCTADEB       PIC 9(001).*/
            public IntBasis SVA_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05            SVA-NUMCARTAO       PIC 9(018).*/
            public IntBasis SVA_NUMCARTAO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"   05            SVA-DIA-DEBITO      PIC 9(002).*/
            public IntBasis SVA_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"   05            SVA-ENDERECO        PIC X(072).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05            SVA-BAIRRO          PIC X(072).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05            SVA-CIDADE          PIC X(072).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05            SVA-UF              PIC X(002).*/
            public StringBasis SVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05            SVA-NOME-RAZAO      PIC X(040).*/
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"   05            SVA-DT-NASC         PIC X(010).*/
            public StringBasis SVA_DT_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05            SVA-NOME-CORREIO    PIC X(046).*/
            public StringBasis SVA_NOME_CORREIO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"   05            SVA-DTINIVIG        PIC X(010).*/
            public StringBasis SVA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05            SVA-DTTERVIG        PIC X(010).*/
            public StringBasis SVA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05            SVA-COD-PRODUTO     PIC 9(004).*/
            public IntBasis SVA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05            SVA-ORIGEM          PIC 9(004).*/
            public IntBasis SVA_ORIGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05            SVA-DS-PRODUTO      PIC X(065).*/
            public StringBasis SVA_DS_PRODUTO { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
            /*"   05            SVA-DTQUIT          PIC X(010).*/
            public StringBasis SVA_DTQUIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05            SVA-SUSEP           PIC X(025).*/
            public StringBasis SVA_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05            SVA-EMAIL           PIC X(065).*/
            public StringBasis SVA_EMAIL { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
            /*"   05            SVA-CART-TITULAR    PIC 9(014).*/
            public IntBasis SVA_CART_TITULAR { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"   05            SVA-QTD-DIG         PIC 9(004).*/
            public IntBasis SVA_QTD_DIG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05            SVA-OPCAOPAG        PIC X(001).*/
            public StringBasis SVA_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05            SVA-FORMAPAG        PIC X(017).*/
            public StringBasis SVA_FORMAPAG { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"   05            SVA-VLIOF           PIC 9(013)V99.*/
            public DoubleBasis SVA_VLIOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"   05            SVA-VLPREMIO-LIQ    PIC 9(013)V99.*/
            public DoubleBasis SVA_VLPREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"   05            SVA-NUM-APOLICE-FORM PIC 9(13).*/
            public IntBasis SVA_NUM_APOLICE_FORM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   05            SVA-COD-EMPRESA     PIC 9(004).*/
            public IntBasis SVA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77  WHOST-DATA-TERVIG-PREMIO       PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIG_PREMIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-1     PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DATA-MOV-5DIA         PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_5DIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    VIND-AGECTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-OPRCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DIGCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CARTAO         PIC S9(004) COMP.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    HOST-COUNT1         PIC S9(004)    COMP.*/
        public IntBasis HOST_COUNT1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    W76-IND             PIC 9(005)    VALUE ZEROS.*/
        public IntBasis W76_IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77    WS-CONTADOR         PIC 9(004)    VALUE ZEROS.*/
        public IntBasis WS_CONTADOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77    WS-DIG-TOTAL        PIC 9(004)    VALUE ZEROS.*/
        public IntBasis WS_DIG_TOTAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77    IND-BEN             PIC 9(004)    VALUE ZEROS.*/
        public IntBasis IND_BEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77    W78-IND             PIC 9(005)    VALUE ZEROS.*/
        public IntBasis W78_IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77    W77-IND             PIC 9(005)    VALUE ZEROS.*/
        public IntBasis W77_IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77    WHOST-BILHETE       PIC S9(015) COMP-3     VALUE +0.*/
        public IntBasis WHOST_BILHETE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WHOST-NRAPOLICE     PIC S9(013) COMP-3     VALUE +0.*/
        public IntBasis WHOST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    WS-NUM-APOLICE      PIC S9(013) COMP-3     VALUE +0.*/
        public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    WHOST-CODRELAT      PIC  X(008) VALUE SPACES.*/
        public StringBasis WHOST_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77    WS-ABEND            PIC  ---9.*/
        public IntBasis WS_ABEND { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"77    WS-FORMULARIO       PIC X(008) VALUE SPACES.*/
        public StringBasis WS_FORMULARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77    WS-CPF              PIC 9(011).*/
        public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
        /*"77    WS-CGC              PIC 9(014).*/
        public IntBasis WS_CGC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
        /*"77    WS-DATA-ATUAL       PIC X(010).*/
        public StringBasis WS_DATA_ATUAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    VIND-NULL-SUSEP     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NULL_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-UNIC          PIC X(001) VALUE 'N'.*/
        public StringBasis WHOST_UNIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77    V0TITF-DTINIVIG       PIC  X(010).*/
        public StringBasis V0TITF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0TITF-DTTERVIG       PIC  X(010).*/
        public StringBasis V0TITF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0TITF-NRSORTEIO      PIC S9(009)    COMP.*/
        public IntBasis V0TITF_NRSORTEIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0TITF-QTTITCAP       PIC S9(004)    COMP.*/
        public IntBasis V0TITF_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    APOLICOB-IMP-SEGURADA-VG        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77    APOLICOB-IMP-SEGURADA-AP        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77    APOLICOB-IMP-SEGURADA-IP        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_IP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77    APOLICOB-IMP-SEGURADA-IPA       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_IPA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77    APOLICOB-IMP-SEGURADA-AMDS      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77    APOLICOB-IMP-SEGURADA-DH        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77    APOLICOB-IMP-SEGURADA-DIT       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77    APOLICOB-PRM-TARIFARIO-VG       PIC S9(10)V9(5) COMP-3.*/
        public DoubleBasis APOLICOB_PRM_TARIFARIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77    APOLICOB-PRM-TARIFARIO-AP       PIC S9(10)V9(5) COMP-3.*/
        public DoubleBasis APOLICOB_PRM_TARIFARIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"01  W-TAB-SISTEMA-ORIGEM.*/
        public BI7028B_W_TAB_SISTEMA_ORIGEM W_TAB_SISTEMA_ORIGEM { get; set; } = new BI7028B_W_TAB_SISTEMA_ORIGEM();
        public class BI7028B_W_TAB_SISTEMA_ORIGEM : VarBasis
        {
            /*"   05  WTAB-SISTEMA-ORIGEM   OCCURS    200  TIMES                                PIC  S9(004) COMP.*/
            public ListBasis<IntBasis, Int64> WTAB_SISTEMA_ORIGEM { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 200);
            /*"01  W-COMPLEMENTO-FETCH.*/
        }
        public BI7028B_W_COMPLEMENTO_FETCH W_COMPLEMENTO_FETCH { get; set; } = new BI7028B_W_COMPLEMENTO_FETCH();
        public class BI7028B_W_COMPLEMENTO_FETCH : VarBasis
        {
            /*"   05  WS-CURSOR-FORMAPAG      PIC X(017).*/
            public StringBasis WS_CURSOR_FORMAPAG { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"   05  WS-CURSOR-VLIOF         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_CURSOR_VLIOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"   05  WS-CURSOR-VLPREMIO-LIQ  PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_CURSOR_VLPREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  AREA-DE-WORK.*/
        }
        public BI7028B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI7028B_AREA_DE_WORK();
        public class BI7028B_AREA_DE_WORK : VarBasis
        {
            /*"   05  WINDI                 PIC S9(004) COMP VALUE +0.*/
            public IntBasis WINDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05  WIND1                 PIC S9(004) COMP VALUE +0.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05  WINF                  PIC S9(004) COMP VALUE +0.*/
            public IntBasis WINF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05  WSUP                  PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSUP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05  WTEM-SISTEMA-ORIGEM   PIC  X(003) VALUE SPACES.*/
            public StringBasis WTEM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05  WS-TEM-SEG-VIA        PIC  X(001) VALUE 'N'.*/
            public StringBasis WS_TEM_SEG_VIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"   05  WS-CABU-NUM-SORTEIO.*/
            public BI7028B_WS_CABU_NUM_SORTEIO WS_CABU_NUM_SORTEIO { get; set; } = new BI7028B_WS_CABU_NUM_SORTEIO();
            public class BI7028B_WS_CABU_NUM_SORTEIO : VarBasis
            {
                /*"       10 WS-CABU-SORTEIO-07    PIC  X(007) VALUE ZEROS.*/
                public StringBasis WS_CABU_SORTEIO_07 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"       10 FILLER                PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05  WS-RCABU-NUM-SORTEIO.*/
            }
            public BI7028B_WS_RCABU_NUM_SORTEIO WS_RCABU_NUM_SORTEIO { get; set; } = new BI7028B_WS_RCABU_NUM_SORTEIO();
            public class BI7028B_WS_RCABU_NUM_SORTEIO : VarBasis
            {
                /*"       10 WS-RCABU-SORTEIO-07 PIC X(007) VALUE ZEROS.*/
                public StringBasis WS_RCABU_SORTEIO_07 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"       10 FILLER              PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05    CABU-SORTEIO-RED.*/
            }
            public BI7028B_CABU_SORTEIO_RED CABU_SORTEIO_RED { get; set; } = new BI7028B_CABU_SORTEIO_RED();
            public class BI7028B_CABU_SORTEIO_RED : VarBasis
            {
                /*"       10      CABU-SORTEIO-OCC-RED OCCURS 5 TIMES.*/
                public ListBasis<BI7028B_CABU_SORTEIO_OCC_RED> CABU_SORTEIO_OCC_RED { get; set; } = new ListBasis<BI7028B_CABU_SORTEIO_OCC_RED>(5);
                public class BI7028B_CABU_SORTEIO_OCC_RED : VarBasis
                {
                    /*"         15    FILLER                PIC   X(001) VALUE '|'.*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"         15    CABU-NUM-SORTEIO-RED  PIC   X(009) VALUE ZEROS.*/
                    public StringBasis CABU_NUM_SORTEIO_RED { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                    /*"   05  WS-HORA-ACCEPT.*/
                }
            }
            public BI7028B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new BI7028B_WS_HORA_ACCEPT();
            public class BI7028B_WS_HORA_ACCEPT : VarBasis
            {
                /*"       10  WS-HOR-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10  WS-MIN-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10  WS-SEG-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05  WS-HORA-CURR.*/
            }
            public BI7028B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new BI7028B_WS_HORA_CURR();
            public class BI7028B_WS_HORA_CURR : VarBasis
            {
                /*"       10  WS-HOR-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10  FILLER              PIC  X(001)    VALUE  ':'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"       10  WS-MIN-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10  FILLER              PIC  X(001)    VALUE  ':'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"       10  WS-SEG-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05  WS-NUM-CARTAO         PIC  X(018).*/
            }
            public StringBasis WS_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
            /*"   05  WS-NUM-CARTAO-R  REDEFINES WS-NUM-CARTAO.*/
            private _REDEF_BI7028B_WS_NUM_CARTAO_R _ws_num_cartao_r { get; set; }
            public _REDEF_BI7028B_WS_NUM_CARTAO_R WS_NUM_CARTAO_R
            {
                get { _ws_num_cartao_r = new _REDEF_BI7028B_WS_NUM_CARTAO_R(); _.Move(WS_NUM_CARTAO, _ws_num_cartao_r); VarBasis.RedefinePassValue(WS_NUM_CARTAO, _ws_num_cartao_r, WS_NUM_CARTAO); _ws_num_cartao_r.ValueChanged += () => { _.Move(_ws_num_cartao_r, WS_NUM_CARTAO); }; return _ws_num_cartao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cartao_r, WS_NUM_CARTAO); }
            }  //Redefines
            public class _REDEF_BI7028B_WS_NUM_CARTAO_R : VarBasis
            {
                /*"       10  WS-NUM-CARTAO-NUM   PIC 9(018).*/
                public IntBasis WS_NUM_CARTAO_NUM { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
                /*"   05  WS-NUM-TITULO         PIC  9(009).*/

                public _REDEF_BI7028B_WS_NUM_CARTAO_R()
                {
                    WS_NUM_CARTAO_NUM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   05  WS-NUM-TITULO-R  REDEFINES WS-NUM-TITULO.*/
            private _REDEF_BI7028B_WS_NUM_TITULO_R _ws_num_titulo_r { get; set; }
            public _REDEF_BI7028B_WS_NUM_TITULO_R WS_NUM_TITULO_R
            {
                get { _ws_num_titulo_r = new _REDEF_BI7028B_WS_NUM_TITULO_R(); _.Move(WS_NUM_TITULO, _ws_num_titulo_r); VarBasis.RedefinePassValue(WS_NUM_TITULO, _ws_num_titulo_r, WS_NUM_TITULO); _ws_num_titulo_r.ValueChanged += () => { _.Move(_ws_num_titulo_r, WS_NUM_TITULO); }; return _ws_num_titulo_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_titulo_r, WS_NUM_TITULO); }
            }  //Redefines
            public class _REDEF_BI7028B_WS_NUM_TITULO_R : VarBasis
            {
                /*"       10  WS-NUM-TITULO-NUM   PIC X(009).*/
                public StringBasis WS_NUM_TITULO_NUM { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"   05  WS-SORTEIO.*/

                public _REDEF_BI7028B_WS_NUM_TITULO_R()
                {
                    WS_NUM_TITULO_NUM.ValueChanged += OnValueChanged;
                }

            }
            public BI7028B_WS_SORTEIO WS_SORTEIO { get; set; } = new BI7028B_WS_SORTEIO();
            public class BI7028B_WS_SORTEIO : VarBasis
            {
                /*"       10  WS-SORTEIO-OCC OCCURS 9 TIMES.*/
                public ListBasis<BI7028B_WS_SORTEIO_OCC> WS_SORTEIO_OCC { get; set; } = new ListBasis<BI7028B_WS_SORTEIO_OCC>(9);
                public class BI7028B_WS_SORTEIO_OCC : VarBasis
                {
                    /*"         15  WS-NUM-SORTEIO  PIC X(001) VALUE SPACES.*/
                    public StringBasis WS_NUM_SORTEIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"   05  CABU-01.*/
                }
            }
            public BI7028B_CABU_01 CABU_01 { get; set; } = new BI7028B_CABU_01();
            public class BI7028B_CABU_01 : VarBasis
            {
                /*"       10         FILLER              PIC X(042) VALUE       'NUM-BILHETE|COD-FORMULARIO|COD-SOLICITACAO'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"NUM-BILHETE|COD-FORMULARIO|COD-SOLICITACAO");
                /*"       10         FILLER              PIC X(056) VALUE      '|CENTRO-CUSTO|COD-PRODUTO|DESC-PRODUTO|NOME-CLIENTE|LOGR'*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"|CENTRO-CUSTO|COD-PRODUTO|DESC-PRODUTO|NOME-CLIENTE|LOGR");
                /*"       10         FILLER              PIC X(056) VALUE      'ADOURO|BAIRRO|CIDADE|UF|CEP|EMAIL|NOME-ESTIPULANTE|CNPJ-'*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"ADOURO|BAIRRO|CIDADE|UF|CEP|EMAIL|NOME-ESTIPULANTE|CNPJ-");
                /*"       10         FILLER              PIC X(056) VALUE      'ESTIPULANTE|NUM-APOLICE|DT-ULT-ALTERACAO|DT-VIG-SEGURADO'*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"ESTIPULANTE|NUM-APOLICE|DT-ULT-ALTERACAO|DT-VIG-SEGURADO");
                /*"       10         FILLER              PIC X(056) VALUE      '|DT-VIG-DEPENDENTE|NOME-SEGURADO|CPF-SEGURADO|DT-NASCIME'*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"|DT-VIG-DEPENDENTE|NOME-SEGURADO|CPF-SEGURADO|DT-NASCIME");
                /*"       10         FILLER              PIC X(056) VALUE      'NTO|DESC-COBRANCA|BANCO|OPERACAO|AGENCIA|DV-AGENCIA|CONT'*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"NTO|DESC-COBRANCA|BANCO|OPERACAO|AGENCIA|DV-AGENCIA|CONT");
                /*"       10         FILLER              PIC X(056) VALUE      'A|CARTAO-CREDITO|PERIODO-PAGTO|VALOR-PREMIO|DIA-VENCIMEN'*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"A|CARTAO-CREDITO|PERIODO-PAGTO|VALOR-PREMIO|DIA-VENCIMEN");
                /*"       10         FILLER              PIC X(056) VALUE      'TO|COD-SUSEP|DESC-COBERTURA-1|VL-COBERTURA-1|DESC-COBERT'*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"TO|COD-SUSEP|DESC-COBERTURA-1|VL-COBERTURA-1|DESC-COBERT");
                /*"       10         FILLER              PIC X(053) VALUE      'URA-2|VL-COBERTURA-2|DESC-COBERTURA-3|VL-COBERTURA-3|'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"URA-2|VL-COBERTURA-2|DESC-COBERTURA-3|VL-COBERTURA-3|");
                /*"       10         FILLER              PIC X(049) VALUE      'DESC-COBERTURA-4|VL-COBERTURA-4|DESC-COBERTURA-5|'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"DESC-COBERTURA-4|VL-COBERTURA-4|DESC-COBERTURA-5|");
                /*"       10         FILLER              PIC X(047) VALUE      'VL-COBERTURA-5|DESC-COBERTURA-6|VL-COBERTURA-6|'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"VL-COBERTURA-5|DESC-COBERTURA-6|VL-COBERTURA-6|");
                /*"       10         FILLER              PIC X(049) VALUE      'DESC-COBERTURA-7|VL-COBERTURA-7|DESC-COBERTURA-8|'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"DESC-COBERTURA-7|VL-COBERTURA-7|DESC-COBERTURA-8|");
                /*"       10         FILLER              PIC X(047) VALUE      'VL-COBERTURA-8|DESC-COBERTURA-9|VL-COBERTURA-9|'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"VL-COBERTURA-8|DESC-COBERTURA-9|VL-COBERTURA-9|");
                /*"       10         FILLER              PIC X(052) VALUE      'DESC-COBERTURA-10|VL-COBERTURA-10|DESC-COBERTURA-11|'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"DESC-COBERTURA-10|VL-COBERTURA-10|DESC-COBERTURA-11|");
                /*"       10         FILLER              PIC X(050) VALUE      'VL-COBERTURA-11|DESC-COBERTURA-12|VL-COBERTURA-12|'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"VL-COBERTURA-11|DESC-COBERTURA-12|VL-COBERTURA-12|");
                /*"       10         FILLER              PIC X(040) VALUE      'DESC-BENEFICIARIO-1|DESC-BENEFICIARIO-2|'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESC-BENEFICIARIO-1|DESC-BENEFICIARIO-2|");
                /*"       10         FILLER              PIC X(040) VALUE      'DESC-BENEFICIARIO-3|DESC-BENEFICIARIO-4|'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESC-BENEFICIARIO-3|DESC-BENEFICIARIO-4|");
                /*"       10         FILLER              PIC X(040) VALUE      'DESC-BENEFICIARIO-5|DESC-BENEFICIARIO-6|'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESC-BENEFICIARIO-5|DESC-BENEFICIARIO-6|");
                /*"       10         FILLER              PIC X(040) VALUE      'DESC-BENEFICIARIO-7|DESC-BENEFICIARIO-8|'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESC-BENEFICIARIO-7|DESC-BENEFICIARIO-8|");
                /*"       10         FILLER              PIC X(041) VALUE      'DESC-BENEFICIARIO-9|DESC-BENEFICIARIO-10|'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DESC-BENEFICIARIO-9|DESC-BENEFICIARIO-10|");
                /*"       10         FILLER              PIC X(042) VALUE      'DESC-BENEFICIARIO-11|DESC-BENEFICIARIO-12|'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"DESC-BENEFICIARIO-11|DESC-BENEFICIARIO-12|");
                /*"       10         FILLER              PIC X(056) VALUE      'NUM-SORTEIO-1|NUM-SORTEIO-2|NUM-SORTEIO-3|NUM-SORTEIO-4|'*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"NUM-SORTEIO-1|NUM-SORTEIO-2|NUM-SORTEIO-3|NUM-SORTEIO-4|");
                /*"       10         FILLER              PIC X(051) VALUE      'NUM-SORTEIO-5|DESC-SORTEIO|NOME-SEGURADO|DT-ADESAO|'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NUM-SORTEIO-5|DESC-SORTEIO|NOME-SEGURADO|DT-ADESAO|");
                /*"       10         FILLER              PIC X(053) VALUE      'NUM-CARTAO|NOME-ASSOCIADO|COBERTURA-A|PARTICIPACAO-A|'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"NUM-CARTAO|NOME-ASSOCIADO|COBERTURA-A|PARTICIPACAO-A|");
                /*"       10         FILLER              PIC X(053) VALUE      'CARENCIA-A|DT-VALIDADE-A|COBERTURA-B|PARTICIPACAO-B|'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"CARENCIA-A|DT-VALIDADE-A|COBERTURA-B|PARTICIPACAO-B|");
                /*"       10         FILLER              PIC X(053) VALUE      'CARENCIA-B|DT-VALIDADE-B|COBERTURA-P|PARTICIPACAO-P|'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"CARENCIA-B|DT-VALIDADE-B|COBERTURA-P|PARTICIPACAO-P|");
                /*"       10         FILLER              PIC X(043) VALUE      'CARENCIA-P|DT-VALIDADE-P|SEQUECIA-ARQUIVO|'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"CARENCIA-P|DT-VALIDADE-P|SEQUECIA-ARQUIVO|");
                /*"       10         FILLER              PIC X(022) VALUE      'DT-QUITACAO|FORMA-PAG|'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"DT-QUITACAO|FORMA-PAG|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC01|GRAU-PARENTESCO01|PCT-PART-BENEFIC01|'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC01|GRAU-PARENTESCO01|PCT-PART-BENEFIC01|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC02|GRAU-PARENTESCO02|PCT-PART-BENEFIC02|'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC02|GRAU-PARENTESCO02|PCT-PART-BENEFIC02|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC03|GRAU-PARENTESCO03|PCT-PART-BENEFIC03|'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC03|GRAU-PARENTESCO03|PCT-PART-BENEFIC03|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC04|GRAU-PARENTESCO04|PCT-PART-BENEFIC04|'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC04|GRAU-PARENTESCO04|PCT-PART-BENEFIC04|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC05|GRAU-PARENTESCO05|PCT-PART-BENEFIC05|'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC05|GRAU-PARENTESCO05|PCT-PART-BENEFIC05|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC06|GRAU-PARENTESCO06|PCT-PART-BENEFIC06|'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC06|GRAU-PARENTESCO06|PCT-PART-BENEFIC06|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC07|GRAU-PARENTESCO07|PCT-PART-BENEFIC07|'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC07|GRAU-PARENTESCO07|PCT-PART-BENEFIC07|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC08|GRAU-PARENTESCO08|PCT-PART-BENEFIC08|'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC08|GRAU-PARENTESCO08|PCT-PART-BENEFIC08|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC09|GRAU-PARENTESCO09|PCT-PART-BENEFIC09|'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC09|GRAU-PARENTESCO09|PCT-PART-BENEFIC09|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC10|GRAU-PARENTESCO10|PCT-PART-BENEFIC10|'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC10|GRAU-PARENTESCO10|PCT-PART-BENEFIC10|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC11|GRAU-PARENTESCO11|PCT-PART-BENEFIC11|'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC11|GRAU-PARENTESCO11|PCT-PART-BENEFIC11|");
                /*"       10         FILLER              PIC X(052) VALUE      'NOME-BENEFIC12|GRAU-PARENTESCO12|PCT-PART-BENEFIC12|'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"NOME-BENEFIC12|GRAU-PARENTESCO12|PCT-PART-BENEFIC12|");
                /*"       10         FILLER              PIC X(032) VALUE      'VL-IOF|VL-PRM-LIQUIDO|CARENCIAS|'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"VL-IOF|VL-PRM-LIQUIDO|CARENCIAS|");
                /*"       10         FILLER              PIC X(014) VALUE      'COD-SUSEP-CAP|'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"COD-SUSEP-CAP|");
                /*"       10         FILLER              PIC X(020) VALUE      'NOME-CLIENTE-SOCIAL|'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"NOME-CLIENTE-SOCIAL|");
                /*"       10         FILLER              PIC X(024) VALUE      'NOME-ESTIPULANTE-SOCIAL|'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"NOME-ESTIPULANTE-SOCIAL|");
                /*"       10         FILLER              PIC X(021) VALUE      'NOME-SEGURADO-SOCIAL|'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"NOME-SEGURADO-SOCIAL|");
                /*"   05      CABU.*/
            }
            public BI7028B_CABU CABU { get; set; } = new BI7028B_CABU();
            public class BI7028B_CABU : VarBasis
            {
                /*"       10    CABU-NUM-BILHETE          PIC   9(015).*/
                public IntBasis CABU_NUM_BILHETE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-COD-FORMULARIO       PIC   X(010).*/
                public StringBasis CABU_COD_FORMULARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-COD-SOLICITA         PIC   X(002).*/
                public StringBasis CABU_COD_SOLICITA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NOM-CENTRO-CUSTO     PIC   X(017).*/
                public StringBasis CABU_NOM_CENTRO_CUSTO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-COD-PRODUTO          PIC   9(004).*/
                public IntBasis CABU_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DS-PRODUTO           PIC   X(065).*/
                public StringBasis CABU_DS_PRODUTO { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NOM-CLIENTE          PIC   X(065).*/
                public StringBasis CABU_NOM_CLIENTE { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DS-LOGRADOURO        PIC   X(065).*/
                public StringBasis CABU_DS_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DS-BAIRRO            PIC   X(040).*/
                public StringBasis CABU_DS_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DS-CIDADE            PIC   X(040).*/
                public StringBasis CABU_DS_CIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-SG-UF                PIC   X(002).*/
                public StringBasis CABU_SG_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-CEP                  PIC   X(010).*/
                public StringBasis CABU_CEP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-EMAIL                PIC   X(065).*/
                public StringBasis CABU_EMAIL { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NOM-ESTIPULANTE      PIC   X(040).*/
                public StringBasis CABU_NOM_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-CNPJ-ESTIPULANTE     PIC   X(018).*/
                public StringBasis CABU_CNPJ_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NUM-APOLICE          PIC   9(013).*/
                public IntBasis CABU_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DT-ULT-ALT           PIC   X(010).*/
                public StringBasis CABU_DT_ULT_ALT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DT-VIG-SEGURADO      PIC   X(040).*/
                public StringBasis CABU_DT_VIG_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DT-VIG-DEPENDENTE    PIC   X(040).*/
                public StringBasis CABU_DT_VIG_DEPENDENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NOM-SEGURADO3        PIC   X(065).*/
                public StringBasis CABU_NOM_SEGURADO3 { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-CPF-SEGURADO         PIC   X(014).*/
                public StringBasis CABU_CPF_SEGURADO { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DT-NASCIMENTO        PIC   X(010).*/
                public StringBasis CABU_DT_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DES-COBRANCA         PIC   X(045).*/
                public StringBasis CABU_DES_COBRANCA { get; set; } = new StringBasis(new PIC("X", "45", "X(045)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NUM-BANCO            PIC   9(004).*/
                public IntBasis CABU_NUM_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-OPER-BANCO           PIC   9(004).*/
                public IntBasis CABU_OPER_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NUM-AGENCIA          PIC   9(004).*/
                public IntBasis CABU_NUM_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DIG-AGENCIA          PIC   9(001).*/
                public IntBasis CABU_DIG_AGENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NUM-CONTA            PIC   9(012).*/
                public IntBasis CABU_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10    CABU-T1                   PIC   X(001).*/
                public StringBasis CABU_T1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10    CABU-DIG-CONTA            PIC   9(001).*/
                public IntBasis CABU_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-CARTAO-CREDITO       PIC   9(018).*/
                public IntBasis CABU_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-PERI-PAGTO           PIC   X(025).*/
                public StringBasis CABU_PERI_PAGTO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-VL-PRM-PAGO          PIC   ZZZ.ZZZ.ZZZ.ZZZ,99.*/
                public DoubleBasis CABU_VL_PRM_PAGO { get; set; } = new DoubleBasis(new PIC("9", "0", "ZZZ.ZZZ.ZZZ.ZZZV99."), 0);
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DIA-VENCTO           PIC   9(002).*/
                public IntBasis CABU_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10    CABU-DIA-VENTO-R REDEFINES CABU-DIA-VENCTO.*/
                private _REDEF_BI7028B_CABU_DIA_VENTO_R _cabu_dia_vento_r { get; set; }
                public _REDEF_BI7028B_CABU_DIA_VENTO_R CABU_DIA_VENTO_R
                {
                    get { _cabu_dia_vento_r = new _REDEF_BI7028B_CABU_DIA_VENTO_R(); _.Move(CABU_DIA_VENCTO, _cabu_dia_vento_r); VarBasis.RedefinePassValue(CABU_DIA_VENCTO, _cabu_dia_vento_r, CABU_DIA_VENCTO); _cabu_dia_vento_r.ValueChanged += () => { _.Move(_cabu_dia_vento_r, CABU_DIA_VENCTO); }; return _cabu_dia_vento_r; }
                    set { VarBasis.RedefinePassValue(value, _cabu_dia_vento_r, CABU_DIA_VENCTO); }
                }  //Redefines
                public class _REDEF_BI7028B_CABU_DIA_VENTO_R : VarBasis
                {
                    /*"         15  CABU-DIA-DEB-ALFA         PIC X(002).*/
                    public StringBasis CABU_DIA_DEB_ALFA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/

                    public _REDEF_BI7028B_CABU_DIA_VENTO_R()
                    {
                        CABU_DIA_DEB_ALFA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-COD-SUSEP            PIC   X(025).*/
                public StringBasis CABU_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NOM-CLIENTE-SOCIAL   PIC   X(100).*/
                public StringBasis CABU_NOM_CLIENTE_SOCIAL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NOM-ESTIPULANTE-SOCIAL PIC X(100).*/
                public StringBasis CABU_NOM_ESTIPULANTE_SOCIAL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NOM-SEGURADO3-SOCIAL PIC   X(100).*/
                public StringBasis CABU_NOM_SEGURADO3_SOCIAL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-COBERTURAS.*/
                public BI7028B_CABU_COBERTURAS CABU_COBERTURAS { get; set; } = new BI7028B_CABU_COBERTURAS();
                public class BI7028B_CABU_COBERTURAS : VarBasis
                {
                    /*"         15  CABU-COBER-OCC OCCURS 12 TIMES.*/
                    public ListBasis<BI7028B_CABU_COBER_OCC> CABU_COBER_OCC { get; set; } = new ListBasis<BI7028B_CABU_COBER_OCC>(12);
                    public class BI7028B_CABU_COBER_OCC : VarBasis
                    {
                        /*"           20    FILLER                PIC   X(001) VALUE '|'.*/
                        public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                        /*"           20    CABU-DES-COBERT       PIC   X(045) VALUE SPACES*/
                        public StringBasis CABU_DES_COBERT { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
                        /*"           20    FILLER                PIC   X(001) VALUE '|'.*/
                        public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                        /*"           20    CABU-VL-COBERT        PIC   X(018).*/
                        public StringBasis CABU_VL_COBERT { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
                        /*"       10    CABU-BENEFICIOS.*/
                    }
                }
                public BI7028B_CABU_BENEFICIOS CABU_BENEFICIOS { get; set; } = new BI7028B_CABU_BENEFICIOS();
                public class BI7028B_CABU_BENEFICIOS : VarBasis
                {
                    /*"         15       CABU-BENEF-OCC OCCURS 12 TIMES.*/
                    public ListBasis<BI7028B_CABU_BENEF_OCC> CABU_BENEF_OCC { get; set; } = new ListBasis<BI7028B_CABU_BENEF_OCC>(12);
                    public class BI7028B_CABU_BENEF_OCC : VarBasis
                    {
                        /*"           20     CABU-TRACO-BENEF     PIC X(001) VALUE SPACES.*/
                        public StringBasis CABU_TRACO_BENEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                        /*"           20     CABU-DES-BENEFIC     PIC X(045) VALUE SPACES.*/
                        public StringBasis CABU_DES_BENEFIC { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
                        /*"       10    CABU-SORTEIO.*/
                    }
                }
                public BI7028B_CABU_SORTEIO CABU_SORTEIO { get; set; } = new BI7028B_CABU_SORTEIO();
                public class BI7028B_CABU_SORTEIO : VarBasis
                {
                    /*"         15      CABU-SORTEIO-OCC OCCURS 5 TIMES.*/
                    public ListBasis<BI7028B_CABU_SORTEIO_OCC> CABU_SORTEIO_OCC { get; set; } = new ListBasis<BI7028B_CABU_SORTEIO_OCC>(5);
                    public class BI7028B_CABU_SORTEIO_OCC : VarBasis
                    {
                        /*"           20    FILLER                PIC   X(001) VALUE '|'.*/
                        public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                        /*"           20    CABU-NUM-SORTEIO      PIC   9(009) VALUE ZEROS.*/
                        public IntBasis CABU_NUM_SORTEIO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                        /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                    }
                }
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DS-SORTEIO           PIC   X(080).*/
                public StringBasis CABU_DS_SORTEIO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NOM-SEGURADO7        PIC   X(065).*/
                public StringBasis CABU_NOM_SEGURADO7 { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DT-ADESAO            PIC   X(010).*/
                public StringBasis CABU_DT_ADESAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NUM-CARTAO           PIC   9(015).*/
                public IntBasis CABU_NUM_CARTAO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-NOM-ASSOCIADO        PIC   X(065).*/
                public StringBasis CABU_NOM_ASSOCIADO { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-COBERTURA-A          PIC   X(002).*/
                public StringBasis CABU_COBERTURA_A { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-PARTICIPACAO-A       PIC   X(003).*/
                public StringBasis CABU_PARTICIPACAO_A { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-CARENCIA-A           PIC   Z99.*/
                public IntBasis CABU_CARENCIA_A { get; set; } = new IntBasis(new PIC("9", "3", "Z99."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DT-VALIDADE-A        PIC   X(010).*/
                public StringBasis CABU_DT_VALIDADE_A { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-COBERTURA-B          PIC   X(002).*/
                public StringBasis CABU_COBERTURA_B { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-PARTICIPACAO-B       PIC   X(003).*/
                public StringBasis CABU_PARTICIPACAO_B { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-CARENCIA-B           PIC   Z99.*/
                public IntBasis CABU_CARENCIA_B { get; set; } = new IntBasis(new PIC("9", "3", "Z99."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DT-VALIDADE-B        PIC   X(010).*/
                public StringBasis CABU_DT_VALIDADE_B { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-COBERTURA-P          PIC   X(002).*/
                public StringBasis CABU_COBERTURA_P { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-PARTICIPACAO-P       PIC   X(003).*/
                public StringBasis CABU_PARTICIPACAO_P { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-CARENCIA-P           PIC   Z99.*/
                public IntBasis CABU_CARENCIA_P { get; set; } = new IntBasis(new PIC("9", "3", "Z99."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DT-VALIDADE-P        PIC   X(010).*/
                public StringBasis CABU_DT_VALIDADE_P { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-SQ-ARQUIVO           PIC   9(010).*/
                public IntBasis CABU_SQ_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-DT-QUITACAO          PIC   X(010).*/
                public StringBasis CABU_DT_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-FORMA-PAG            PIC   X(017).*/
                public StringBasis CABU_FORMA_PAG { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
                /*"       10    FILLER                    PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-BENEFICIARIO.*/
                public BI7028B_CABU_BENEFICIARIO CABU_BENEFICIARIO { get; set; } = new BI7028B_CABU_BENEFICIARIO();
                public class BI7028B_CABU_BENEFICIARIO : VarBasis
                {
                    /*"         15    CABU-BENEFIC-OCC OCCURS 12 TIMES.*/
                    public ListBasis<BI7028B_CABU_BENEFIC_OCC> CABU_BENEFIC_OCC { get; set; } = new ListBasis<BI7028B_CABU_BENEFIC_OCC>(12);
                    public class BI7028B_CABU_BENEFIC_OCC : VarBasis
                    {
                        /*"           20  CABU-NOME-BENEFIC     PIC   X(040) VALUE SPACES.*/
                        public StringBasis CABU_NOME_BENEFIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                        /*"           20  CABU-TRACO1-BENEFIC   PIC   X(001) VALUE SPACES.*/
                        public StringBasis CABU_TRACO1_BENEFIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                        /*"           20  CABU-GRAU-PARENTESCO  PIC   X(010) VALUE SPACES.*/
                        public StringBasis CABU_GRAU_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                        /*"           20  CABU-TRACO2-BENEFIC   PIC   X(001) VALUE SPACES.*/
                        public StringBasis CABU_TRACO2_BENEFIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                        /*"           20  CABU-PCT-PART-BENEFIC PIC   ZZZ,ZZ.*/
                        public StringBasis CABU_PCT_PART_BENEFIC { get; set; } = new StringBasis(new PIC("X", "0", "ZZZVZZ."), @"");
                        /*"           20  CABU-TRACO3-BENEFIC   PIC   X(001) VALUE SPACES.*/
                        public StringBasis CABU_TRACO3_BENEFIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                        /*"       10    CABU-VL-IOF             PIC   ZZ.ZZ9,99.*/
                    }
                }
                public DoubleBasis CABU_VL_IOF { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"       10    FILLER                  PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-VL-PRM-LIQUIDO     PIC   ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis CABU_VL_PRM_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"       10    FILLER                  PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-VL-CARENCIAS.*/
                public BI7028B_CABU_VL_CARENCIAS CABU_VL_CARENCIAS { get; set; } = new BI7028B_CABU_VL_CARENCIAS();
                public class BI7028B_CABU_VL_CARENCIAS : VarBasis
                {
                    /*"         15    CABU-VL-CARENCIA-01   PIC   X(089).*/
                    public StringBasis CABU_VL_CARENCIA_01 { get; set; } = new StringBasis(new PIC("X", "89", "X(089)."), @"");
                    /*"         15    CABU-VL-CARENCIA-02   PIC   X(089).*/
                    public StringBasis CABU_VL_CARENCIA_02 { get; set; } = new StringBasis(new PIC("X", "89", "X(089)."), @"");
                    /*"         15    CABU-VL-CARENCIA-03   PIC   X(089).*/
                    public StringBasis CABU_VL_CARENCIA_03 { get; set; } = new StringBasis(new PIC("X", "89", "X(089)."), @"");
                    /*"         15    CABU-VL-CARENCIA-04   PIC   X(089).*/
                    public StringBasis CABU_VL_CARENCIA_04 { get; set; } = new StringBasis(new PIC("X", "89", "X(089)."), @"");
                    /*"         15    CABU-VL-CARENCIA-05   PIC   X(089).*/
                    public StringBasis CABU_VL_CARENCIA_05 { get; set; } = new StringBasis(new PIC("X", "89", "X(089)."), @"");
                    /*"       10    FILLER                  PIC   X(001) VALUE '|'.*/
                }
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    CABU-COD-SUSEP-CAP      PIC   X(025).*/
                public StringBasis CABU_COD_SUSEP_CAP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"       10    FILLER                  PIC   X(001) VALUE '|'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10    FILLER                  PIC   X(005) VALUE SPACES.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   05      CAB8.*/
            }
            public BI7028B_CAB8 CAB8 { get; set; } = new BI7028B_CAB8();
            public class BI7028B_CAB8 : VarBasis
            {
                /*"       10    CAB8-TP-REGISTRO          PIC   X(002).*/
                public StringBasis CAB8_TP_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10    CAB8-COD-FORMULARIO       PIC   X(010).*/
                public StringBasis CAB8_COD_FORMULARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10    CAB8-QTD                  PIC   9(009).*/
                public IntBasis CAB8_QTD { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"       10    CAB8-SQ-ARQUIVO           PIC   9(010).*/
                public IntBasis CAB8_SQ_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"   05  AC-LINHAS           PIC 9(002) VALUE 80.*/
            }
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"   05  WS-QTD-VAKS28AP     PIC 9(010).*/
            public IntBasis WS_QTD_VAKS28AP { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"   05  WS-QTD-VAKS28JV     PIC 9(010).*/
            public IntBasis WS_QTD_VAKS28JV { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"   05  WS-QTD-VAKS28RD     PIC 9(010).*/
            public IntBasis WS_QTD_VAKS28RD { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"   05  WS-QTD-VAKS28PO     PIC 9(010).*/
            public IntBasis WS_QTD_VAKS28PO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"   05  WS-SQ-ARQUIVO       PIC 9(010).*/
            public IntBasis WS_SQ_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"   05  WS-VALORES-AX.*/
            public BI7028B_WS_VALORES_AX WS_VALORES_AX { get; set; } = new BI7028B_WS_VALORES_AX();
            public class BI7028B_WS_VALORES_AX : VarBasis
            {
                /*"       10           WS-VALOR-9          PIC S9(11)V99.*/
                public DoubleBasis WS_VALOR_9 { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99."), 2);
                /*"       10           WS-VALOR-INT        PIC Z9.*/
                public IntBasis WS_VALOR_INT { get; set; } = new IntBasis(new PIC("9", "2", "Z9."));
                /*"       10           WS-VALOR-INT-X      PIC X(10).*/
                public StringBasis WS_VALOR_INT_X { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"       10           WS-VALOR            PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_VALOR { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"   05  WS-INF              PIC 9(009).*/
            }
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   05  WS-SUP              PIC 9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   05  WS-IND              PIC S9(004) COMP   VALUE +0.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05  WIND                PIC S9(004) COMP   VALUE +0.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05            WS-DATA.*/
            public BI7028B_WS_DATA WS_DATA { get; set; } = new BI7028B_WS_DATA();
            public class BI7028B_WS_DATA : VarBasis
            {
                /*"       10          WS-DIA              PIC 9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10          FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10          WS-MES              PIC 9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10          FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10          WS-ANO              PIC 9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05            WS-DATA-SEG.*/
            }
            public BI7028B_WS_DATA_SEG WS_DATA_SEG { get; set; } = new BI7028B_WS_DATA_SEG();
            public class BI7028B_WS_DATA_SEG : VarBasis
            {
                /*"       10          WS-DTINIVIG.*/
                public BI7028B_WS_DTINIVIG WS_DTINIVIG { get; set; } = new BI7028B_WS_DTINIVIG();
                public class BI7028B_WS_DTINIVIG : VarBasis
                {
                    /*"         15        WS-DIA-INI          PIC X(002).*/
                    public StringBasis WS_DIA_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"         15        WS-BARRA1           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"         15        WS-MES-INI          PIC X(002).*/
                    public StringBasis WS_MES_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"         15        WS-BARRA2           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"         15        WS-ANO-INI          PIC X(004).*/
                    public StringBasis WS_ANO_INI { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"       10          WS-FIL-A            PIC X(003) VALUE ' A '.*/
                }
                public StringBasis WS_FIL_A { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"       10          WS-DTTERVIG.*/
                public BI7028B_WS_DTTERVIG WS_DTTERVIG { get; set; } = new BI7028B_WS_DTTERVIG();
                public class BI7028B_WS_DTTERVIG : VarBasis
                {
                    /*"         15        WS-DIA-TER          PIC X(002).*/
                    public StringBasis WS_DIA_TER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"         15        WS-BARRA3           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"         15        WS-MES-TER          PIC X(002).*/
                    public StringBasis WS_MES_TER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"         15        WS-BARRA4           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"         15        WS-ANO-TER          PIC X(004).*/
                    public StringBasis WS_ANO_TER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"   05            WS-DATA-INV.*/
                }
            }
            public BI7028B_WS_DATA_INV WS_DATA_INV { get; set; } = new BI7028B_WS_DATA_INV();
            public class BI7028B_WS_DATA_INV : VarBasis
            {
                /*"       10          WS-ANO-INV          PIC 9(004).*/
                public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10          FILLER              PIC X(001).*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10          WS-MES-INV          PIC 9(002).*/
                public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10          FILLER              PIC X(001).*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10          WS-DIA-INV          PIC 9(002).*/
                public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05            WHORA-CURR          PIC X(008) VALUE SPACES.*/
            }
            public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"   05            WS-DATA-AUX.*/
            public BI7028B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new BI7028B_WS_DATA_AUX();
            public class BI7028B_WS_DATA_AUX : VarBasis
            {
                /*"       10          WS-DIA-AUX          PIC 9(002).*/
                public IntBasis WS_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10          WS-AUX-B1           PIC X(001).*/
                public StringBasis WS_AUX_B1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10          WS-MES-AUX          PIC 9(002).*/
                public IntBasis WS_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10          WS-AUX-B2           PIC X(001).*/
                public StringBasis WS_AUX_B2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10          WS-ANO-AUX          PIC 9(004).*/
                public IntBasis WS_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05  AC-LIDOS            PIC 9(006) VALUE ZEROES.*/
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-CONTA            PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-IMPRESSOS        PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-L-RELATORI       PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_L_RELATORI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-DESPR-CODRELAT   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_CODRELAT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-DESPR-APOLICOB   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_APOLICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-DESPR-CLIENTE    PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_CLIENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-DESPR-COBMENVG   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_COBMENVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-DESPR-ENDERECO   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-DESPR-COBERPRO   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_COBERPRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-DESPR-FCTITULO   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_FCTITULO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  AC-DESPR-ENDOSSOS   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05  WFIM-SISTEMAS       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WFIM-V0TITFDCAP     PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_V0TITFDCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WFIM-RELATORI       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_RELATORI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WFIM-SORT           PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WTEM-ENDERECO       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WTEM-CLIENTES       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WTEM-PRODUTO        PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WTEM-MOVDEBCE       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WTEM-COBMENVG       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_COBMENVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WFIM-BENEFICIA      PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_BENEFICIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WFIM-SISTEMA-ORIGEM PIC X(003) VALUE SPACES.*/
            public StringBasis WFIM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05  WTEM-FCTITULO       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_FCTITULO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WTEM-ENDOSSOS       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_ENDOSSOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WFIM-VG033          PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_VG033 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   05  WS-CGC-AUX.*/
            public BI7028B_WS_CGC_AUX WS_CGC_AUX { get; set; } = new BI7028B_WS_CGC_AUX();
            public class BI7028B_WS_CGC_AUX : VarBasis
            {
                /*"       10  WS-CGC-NUM1         PIC    9(002).*/
                public IntBasis WS_CGC_NUM1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  WS-CGC-P1           PIC    X(001).*/
                public StringBasis WS_CGC_P1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-CGC-NUM2         PIC    9(003).*/
                public IntBasis WS_CGC_NUM2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CGC-P2           PIC    X(001).*/
                public StringBasis WS_CGC_P2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-CGC-NUM3         PIC    9(003).*/
                public IntBasis WS_CGC_NUM3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CGC-BARRA1       PIC    X(001).*/
                public StringBasis WS_CGC_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-CGC-NUM4         PIC    9(004).*/
                public IntBasis WS_CGC_NUM4 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  WS-CGC-DIG          PIC    X(001).*/
                public StringBasis WS_CGC_DIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-CGC-NUM5         PIC    9(002).*/
                public IntBasis WS_CGC_NUM5 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05  WS-CGC-AUX1.*/
            }
            public BI7028B_WS_CGC_AUX1 WS_CGC_AUX1 { get; set; } = new BI7028B_WS_CGC_AUX1();
            public class BI7028B_WS_CGC_AUX1 : VarBasis
            {
                /*"       10  WS-CGC-AUX-NUM1     PIC    9(002).*/
                public IntBasis WS_CGC_AUX_NUM1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  WS-CGC-AUX-NUM2     PIC    9(003).*/
                public IntBasis WS_CGC_AUX_NUM2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CGC-AUX-NUM3     PIC    9(004).*/
                public IntBasis WS_CGC_AUX_NUM3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  WS-CGC-AUX-NUM4     PIC    9(004).*/
                public IntBasis WS_CGC_AUX_NUM4 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  WS-CGC-AUX-NUM5     PIC    9(002).*/
                public IntBasis WS_CGC_AUX_NUM5 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05  WS-CPF-AUX.*/
            }
            public BI7028B_WS_CPF_AUX WS_CPF_AUX { get; set; } = new BI7028B_WS_CPF_AUX();
            public class BI7028B_WS_CPF_AUX : VarBasis
            {
                /*"       10  WS-CPF-NUM1         PIC    9(003).*/
                public IntBasis WS_CPF_NUM1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CPF-P1           PIC    X(001).*/
                public StringBasis WS_CPF_P1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-CPF-NUM2         PIC    9(003).*/
                public IntBasis WS_CPF_NUM2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CPF-P2           PIC    X(001).*/
                public StringBasis WS_CPF_P2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-CPF-NUM3         PIC    9(003).*/
                public IntBasis WS_CPF_NUM3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CPF-DIG          PIC    X(001).*/
                public StringBasis WS_CPF_DIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-CPF-NUM4         PIC    9(002).*/
                public IntBasis WS_CPF_NUM4 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05  WS-CPF-AUX1.*/
            }
            public BI7028B_WS_CPF_AUX1 WS_CPF_AUX1 { get; set; } = new BI7028B_WS_CPF_AUX1();
            public class BI7028B_WS_CPF_AUX1 : VarBasis
            {
                /*"       10  WS-CPF-AUX-NUM1     PIC    9(003).*/
                public IntBasis WS_CPF_AUX_NUM1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CPF-AUX-NUM2     PIC    9(003).*/
                public IntBasis WS_CPF_AUX_NUM2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CPF-AUX-NUM3     PIC    9(003).*/
                public IntBasis WS_CPF_AUX_NUM3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CPF-AUX-NUM4     PIC    9(002).*/
                public IntBasis WS_CPF_AUX_NUM4 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05  WS-CEP-AUX.*/
            }
            public BI7028B_WS_CEP_AUX WS_CEP_AUX { get; set; } = new BI7028B_WS_CEP_AUX();
            public class BI7028B_WS_CEP_AUX : VarBasis
            {
                /*"       10  WS-CEP-NUM1         PIC    9(002).*/
                public IntBasis WS_CEP_NUM1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  WS-CEP-P1           PIC    X(001).*/
                public StringBasis WS_CEP_P1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-CEP-NUM2         PIC    9(003).*/
                public IntBasis WS_CEP_NUM2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CEP-DIG          PIC    X(001).*/
                public StringBasis WS_CEP_DIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-CEP-NUM3         PIC    9(003).*/
                public IntBasis WS_CEP_NUM3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   05  WS-CEP-AUX1.*/
            }
            public BI7028B_WS_CEP_AUX1 WS_CEP_AUX1 { get; set; } = new BI7028B_WS_CEP_AUX1();
            public class BI7028B_WS_CEP_AUX1 : VarBasis
            {
                /*"       10  WS-CEP-AUX-NUM1     PIC    9(002).*/
                public IntBasis WS_CEP_AUX_NUM1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  WS-CEP-AUX-NUM2     PIC    9(003).*/
                public IntBasis WS_CEP_AUX_NUM2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-CEP-AUX-NUM3     PIC    9(003).*/
                public IntBasis WS_CEP_AUX_NUM3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   05  WS-CONTA-DV.*/
            }
            public BI7028B_WS_CONTA_DV WS_CONTA_DV { get; set; } = new BI7028B_WS_CONTA_DV();
            public class BI7028B_WS_CONTA_DV : VarBasis
            {
                /*"       10  WS-CONTA            PIC    9(005).*/
                public IntBasis WS_CONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10  WS-CONTA-T1         PIC    X(001).*/
                public StringBasis WS_CONTA_T1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  WS-DIGITO           PIC    9(001).*/
                public IntBasis WS_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   05  WS-CONTA-AUX.*/
            }
            public BI7028B_WS_CONTA_AUX WS_CONTA_AUX { get; set; } = new BI7028B_WS_CONTA_AUX();
            public class BI7028B_WS_CONTA_AUX : VarBasis
            {
                /*"       10  WS-CONTA-AUX        PIC    9(005).*/
                public IntBasis WS_CONTA_AUX_0 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10  WS-DIGITO-AUX       PIC    9(001).*/
                public IntBasis WS_DIGITO_AUX { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01  VG0716S-COD-FONTE       PIC  S9(004) COMP.*/
            }
        }
        public IntBasis VG0716S_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-COD-PRODUTO     PIC  S9(004) COMP.*/
        public IntBasis VG0716S_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-NUM-PROPOSTA    PIC  S9(015)    COMP-3.*/
        public IntBasis VG0716S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  VG0716S-VLR-MENSALIDADE PIC  S9(008)V99 COMP-3.*/
        public DoubleBasis VG0716S_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
        /*"01  VG0716S-NUM-PLANO       PIC  S9(004) COMP.*/
        public IntBasis VG0716S_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-NUM-SERIE       PIC  S9(004) COMP.*/
        public IntBasis VG0716S_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-NUM-TITULO      PIC  S9(009) COMP.*/
        public IntBasis VG0716S_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  VG0716S-IND-DV          PIC  S9(004) COMP.*/
        public IntBasis VG0716S_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-DTH-INI-VIGENCIA PIC  X(010).*/
        public StringBasis VG0716S_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  VG0716S-DTH-FIM-VIGENCIA PIC  X(010).*/
        public StringBasis VG0716S_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  VG0716S-DES-COMBINACAO  PIC   X(020).*/
        public StringBasis VG0716S_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  VG0716S-COD-STA-TITULO  PIC   X(003).*/
        public StringBasis VG0716S_COD_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  VG0716S-SQLCODE         PIC  S9(004) COMP.*/
        public IntBasis VG0716S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-COD-RETORNO     PIC  S9(004) COMP.*/
        public IntBasis VG0716S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-DES-MENSAGEM    PIC   X(070).*/
        public StringBasis VG0716S_DES_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01                WABEND.*/
        public BI7028B_WABEND WABEND { get; set; } = new BI7028B_WABEND();
        public class BI7028B_WABEND : VarBasis
        {
            /*"   05          FILLER              PIC X(010) VALUE              ' BI7028B'.*/
            public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI7028B");
            /*"   05          FILLER              PIC X(026) VALUE              ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"   05          WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"   05          FILLER              PIC X(013) VALUE              ' *** SQLCODE '.*/
            public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"   05          WSQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  WS-JV1-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
        }
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01    WS-DESCRICAO-CARENCIA.*/
        public BI7028B_WS_DESCRICAO_CARENCIA WS_DESCRICAO_CARENCIA { get; set; } = new BI7028B_WS_DESCRICAO_CARENCIA();
        public class BI7028B_WS_DESCRICAO_CARENCIA : VarBasis
        {
            /*"   05 FILLER              PIC X(048) VALUE   'CAR�NCIA DE 30 (TRINTA) DIAS PARA UTILIZAR A ASS'.*/
            public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"CAR�NCIA DE 30 (TRINTA) DIAS PARA UTILIZAR A ASS");
            /*"   05 FILLER              PIC X(048) VALUE   'IST�NCIA MEDICAMENTO.                           '.*/
            public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"IST�NCIA MEDICAMENTO.                           ");
            /*"   05 FILLER              PIC X(048) VALUE SPACES.*/
            public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
            /*"   05 FILLER              PIC X(301) VALUE SPACES.*/
            public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "301", "X(301)"), @"");
        }


        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Copies.SPGE053W SPGE053W { get; set; } = new Copies.SPGE053W();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.COBMENVG COBMENVG { get; set; } = new Dclgens.COBMENVG();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.BENEFICI BENEFICI { get; set; } = new Dclgens.BENEFICI();
        public Dclgens.PESSOEMA PESSOEMA { get; set; } = new Dclgens.PESSOEMA();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.FCPLANO FCPLANO { get; set; } = new Dclgens.FCPLANO();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.VGCOBSUB VGCOBSUB { get; set; } = new Dclgens.VGCOBSUB();
        public Dclgens.VG033 VG033 { get; set; } = new Dclgens.VG033();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public BI7028B_CORIGEM CORIGEM { get; set; } = new BI7028B_CORIGEM();
        public BI7028B_CRELAT CRELAT { get; set; } = new BI7028B_CRELAT();
        public BI7028B_CVG033 CVG033 { get; set; } = new BI7028B_CVG033();
        public BI7028B_V0BENEF V0BENEF { get; set; } = new BI7028B_V0BENEF();
        public BI7028B_CTITFD CTITFD { get; set; } = new BI7028B_CTITFD();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RBI7028B_FILE_NAME_P, string RBI7028I_FILE_NAME_P, string RBI7028P_FILE_NAME_P, string RBI7028H_FILE_NAME_P, string SBI7028B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RBI7028B.SetFile(RBI7028B_FILE_NAME_P);
                RBI7028I.SetFile(RBI7028I_FILE_NAME_P);
                RBI7028P.SetFile(RBI7028P_FILE_NAME_P);
                RBI7028H.SetFile(RBI7028H_FILE_NAME_P);
                SBI7028B.SetFile(SBI7028B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1185- DISPLAY ' ' */
            _.Display($" ");

            /*" -1187- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1188- DISPLAY 'PROGRAMA EM EXECUCAO -' */
            _.Display($"PROGRAMA EM EXECUCAO -");

            /*" -1196- DISPLAY 'PROGRAMA BI7028B - V.24 - INCIDENTE 600300 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA BI7028B - V.24 - INCIDENTE 600300 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1198- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1201- DISPLAY ' ' */
            _.Display($" ");

            /*" -1202- DISPLAY ' ' */
            _.Display($" ");

            /*" -1209- DISPLAY 'INICIOU PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1211- DISPLAY ' ' */
            _.Display($" ");

            /*" -1212- MOVE 'BI7028B' TO LK-GEJVW002-NOM-PROG-ORIGEM */
            _.Move("BI7028B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -1213- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -1213- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WS_JV1_PROGRAMA);

            /*" -1214- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -1215- IF LK-GEJVWCNT-IND-ERRO NOT = 0 */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 0)
            {

                /*" -1216- DISPLAY 'IND ERRO    = ' LK-GEJVWCNT-IND-ERRO */
                _.Display($"IND ERRO    = {GEJVWCNT.LK_GEJVWCNT_IND_ERRO}");

                /*" -1217- DISPLAY 'MENSAGEM    = ' LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM    = {GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO}");

                /*" -1218- DISPLAY 'TABELA      = ' LK-GEJVWCNT-NOME-TABELA */
                _.Display($"TABELA      = {GEJVWCNT.LK_GEJVWCNT_NOME_TABELA}");

                /*" -1219- DISPLAY 'SQLCODE     = ' LK-GEJVWCNT-SQLCODE */
                _.Display($"SQLCODE     = {GEJVWCNT.LK_GEJVWCNT_SQLCODE}");

                /*" -1220- MOVE LK-GEJVWCNT-SQLCODE TO WSQLCODE */
                _.Move(GEJVWCNT.LK_GEJVWCNT_SQLCODE, WABEND.WSQLCODE);

                /*" -1221- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1223- END-IF. */
            }


            /*" -1224- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -1225- IF WFIM-SISTEMAS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMAS.IsEmpty())
            {

                /*" -1227- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1229- PERFORM R0200-00-CARREGA-ORIGEM. */

            R0200_00_CARREGA_ORIGEM_SECTION();

            /*" -1231- PERFORM R0900-00-DECLARE-RELATORI. */

            R0900_00_DECLARE_RELATORI_SECTION();

            /*" -1233- PERFORM R0910-00-FETCH-RELATORI. */

            R0910_00_FETCH_RELATORI_SECTION();

            /*" -1234- IF WFIM-RELATORI EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -1235- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1236- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1237- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1239- END-IF. */
            }


            /*" -1241- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1244- SORT SBI7028B ON ASCENDING KEY SVA-NRAPOLICE INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SBI7028B.Sort("SVA-NRAPOLICE", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -1247- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1248- DISPLAY '*** BI7028B *** PROBLEMAS NO SORT ' */
                _.Display($"*** BI7028B *** PROBLEMAS NO SORT ");

                /*" -1249- DISPLAY '*** BI7028B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** BI7028B *** SORT-RETURN = {SORT_RETURN}");

                /*" -1250- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -1251- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1251- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1260- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1260- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1263- DISPLAY '******  BI7028B *********' */
            _.Display($"******  BI7028B *********");

            /*" -1264- DISPLAY 'LIDOS V0RELATORIOS       ' AC-L-RELATORI. */
            _.Display($"LIDOS V0RELATORIOS       {AREA_DE_WORK.AC_L_RELATORI}");

            /*" -1265- DISPLAY 'CERTIFICADOS IMPRESSOS   ' AC-IMPRESSOS. */
            _.Display($"CERTIFICADOS IMPRESSOS   {AREA_DE_WORK.AC_IMPRESSOS}");

            /*" -1266- DISPLAY 'DESPREZADOS COBMENVGE    ' AC-DESPR-COBMENVG. */
            _.Display($"DESPREZADOS COBMENVGE    {AREA_DE_WORK.AC_DESPR_COBMENVG}");

            /*" -1267- DISPLAY 'DESPREZADOS V0CLIENTE    ' AC-DESPR-CLIENTE. */
            _.Display($"DESPREZADOS V0CLIENTE    {AREA_DE_WORK.AC_DESPR_CLIENTE}");

            /*" -1268- DISPLAY 'DESPREZADOS V0ENDERECO   ' AC-DESPR-ENDERECO. */
            _.Display($"DESPREZADOS V0ENDERECO   {AREA_DE_WORK.AC_DESPR_ENDERECO}");

            /*" -1269- DISPLAY 'DESPREZADOS TITULOS      ' AC-DESPR-FCTITULO. */
            _.Display($"DESPREZADOS TITULOS      {AREA_DE_WORK.AC_DESPR_FCTITULO}");

            /*" -1270- DISPLAY 'DESPREZADOS ENDOSSOS     ' AC-DESPR-ENDOSSOS. */
            _.Display($"DESPREZADOS ENDOSSOS     {AREA_DE_WORK.AC_DESPR_ENDOSSOS}");

            /*" -1271- DISPLAY '********  SORT  *********' */
            _.Display($"********  SORT  *********");

            /*" -1272- DISPLAY 'DESPREZADOS V0COBERAPOL  ' AC-DESPR-APOLICOB. */
            _.Display($"DESPREZADOS V0COBERAPOL  {AREA_DE_WORK.AC_DESPR_APOLICOB}");

            /*" -1274- DISPLAY '                         ' . */
            _.Display($"                         ");

            /*" -1275- DISPLAY '*** BI7028B - TERMINO NORMAL ***' */
            _.Display($"*** BI7028B - TERMINO NORMAL ***");

            /*" -1275- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1287- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-RELATORI EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_RELATORI == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -1287- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -1299- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1324- MOVE ZEROS TO WIND. */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -1325- WRITE RBI7028B-RECORD FROM CABU-01. */
            _.Move(AREA_DE_WORK.CABU_01.GetMoveValues(), RBI7028B_RECORD);

            RBI7028B.Write(RBI7028B_RECORD.GetMoveValues().ToString());

            /*" -1326- WRITE RBI7028I-RECORD FROM CABU-01. */
            _.Move(AREA_DE_WORK.CABU_01.GetMoveValues(), RBI7028I_RECORD);

            RBI7028I.Write(RBI7028I_RECORD.GetMoveValues().ToString());

            /*" -1327- WRITE RBI7028P-RECORD FROM CABU-01. */
            _.Move(AREA_DE_WORK.CABU_01.GetMoveValues(), RBI7028P_RECORD);

            RBI7028P.Write(RBI7028P_RECORD.GetMoveValues().ToString());

            /*" -1328- INSPECT CABU-01 REPLACING ALL '|' BY ';' . */
            AREA_DE_WORK.CABU_01.Replace("|", ";");

            /*" -1329- WRITE RBI7028H-RECORD FROM CABU-01. */
            _.Move(AREA_DE_WORK.CABU_01.GetMoveValues(), RBI7028H_RECORD);

            RBI7028H.Write(RBI7028H_RECORD.GetMoveValues().ToString());

            /*" -1331- INSPECT CABU-01 REPLACING ALL ';' BY '|' . */
            AREA_DE_WORK.CABU_01.Replace(";", "|");

            /*" -1333- PERFORM R2100-00-LE-SORT. */

            R2100_00_LE_SORT_SECTION();

            /*" -1336- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -1347- PERFORM R3300-00-IMPRIME-REG10. */

            R3300_00_IMPRIME_REG10_SECTION();

            /*" -1347- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -1360- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -1373- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -1376- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1377- DISPLAY 'BI7028B - SISTEMA BI NAO ESTA CADASTRADO' */
                _.Display($"BI7028B - SISTEMA BI NAO ESTA CADASTRADO");

                /*" -1378- MOVE 'S' TO WFIM-SISTEMAS */
                _.Move("S", AREA_DE_WORK.WFIM_SISTEMAS);

                /*" -1379- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -1387- END-IF. */
            }


            /*" -1387- INITIALIZE CABU. */
            _.Initialize(
                AREA_DE_WORK.CABU
            );

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1373- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 1 YEAR, DATA_MOV_ABERTO - 5 DAY , CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO-1, :SISTEMAS-DATA-MOV-5DIA, :WS-DATA-ATUAL FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_1, SISTEMAS_DATA_MOV_ABERTO_1);
                _.Move(executed_1.SISTEMAS_DATA_MOV_5DIA, SISTEMAS_DATA_MOV_5DIA);
                _.Move(executed_1.WS_DATA_ATUAL, WS_DATA_ATUAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-SECTION */
        private void R0200_00_CARREGA_ORIGEM_SECTION()
        {
            /*" -1400- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -1406- PERFORM R0200_00_CARREGA_ORIGEM_DB_DECLARE_1 */

            R0200_00_CARREGA_ORIGEM_DB_DECLARE_1();

            /*" -1408- PERFORM R0200_00_CARREGA_ORIGEM_DB_OPEN_1 */

            R0200_00_CARREGA_ORIGEM_DB_OPEN_1();

            /*" -1411- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1412- DISPLAY 'PROBLEMAS NO OPEN CORIGEM ' */
                _.Display($"PROBLEMAS NO OPEN CORIGEM ");

                /*" -1414- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1416- MOVE '0201' TO WNR-EXEC-SQL. */
            _.Move("0201", WABEND.WNR_EXEC_SQL);

            /*" -1417- PERFORM UNTIL WFIM-SISTEMA-ORIGEM EQUAL 'SIM' */

            while (!(AREA_DE_WORK.WFIM_SISTEMA_ORIGEM == "SIM"))
            {

                /*" -1419- PERFORM R0200_00_CARREGA_ORIGEM_DB_FETCH_1 */

                R0200_00_CARREGA_ORIGEM_DB_FETCH_1();

                /*" -1421- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1422- ADD 1 TO WIND1 */
                    AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 + 1;

                    /*" -1424- MOVE ARQSIVPF-SISTEMA-ORIGEM TO WTAB-SISTEMA-ORIGEM (WIND1) */
                    _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND1]);

                    /*" -1425- ELSE */
                }
                else
                {


                    /*" -1426- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1427- MOVE 'SIM' TO WFIM-SISTEMA-ORIGEM */
                        _.Move("SIM", AREA_DE_WORK.WFIM_SISTEMA_ORIGEM);

                        /*" -1427- PERFORM R0200_00_CARREGA_ORIGEM_DB_CLOSE_1 */

                        R0200_00_CARREGA_ORIGEM_DB_CLOSE_1();

                        /*" -1429- ELSE */
                    }
                    else
                    {


                        /*" -1430- DISPLAY 'PROBLEMAS NO FETCH CORIGEM ' */
                        _.Display($"PROBLEMAS NO FETCH CORIGEM ");

                        /*" -1431- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1432- END-IF */
                    }


                    /*" -1433- END-IF */
                }


                /*" -1433- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-DECLARE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_DECLARE_1()
        {
            /*" -1406- EXEC SQL DECLARE CORIGEM CURSOR FOR SELECT SISTEMA_ORIGEM FROM SEGUROS.ARQUIVOS_SIVPF WHERE DATA_GERACAO = '9999-12-31' AND QTDE_REG_GER = 981 ORDER BY SISTEMA_ORIGEM END-EXEC. */
            CORIGEM = new BI7028B_CORIGEM(false);
            string GetQuery_CORIGEM()
            {
                var query = @$"SELECT SISTEMA_ORIGEM 
							FROM SEGUROS.ARQUIVOS_SIVPF 
							WHERE DATA_GERACAO = '9999-12-31' 
							AND QTDE_REG_GER = 981 
							ORDER BY SISTEMA_ORIGEM";

                return query;
            }
            CORIGEM.GetQueryEvent += GetQuery_CORIGEM;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-OPEN-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_OPEN_1()
        {
            /*" -1408- EXEC SQL OPEN CORIGEM END-EXEC. */

            CORIGEM.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-DECLARE-1 */
        public void R0900_00_DECLARE_RELATORI_DB_DECLARE_1()
        {
            /*" -1499- EXEC SQL DECLARE CRELAT CURSOR FOR SELECT DISTINCT A.COD_OPERACAO , A.COD_USUARIO , A.COD_RELATORIO , A.DATA_SOLICITACAO , A.NUM_ENDOSSO , B.DATA_QUITACAO , B.NUM_APOLICE , B.NUM_BILHETE , B.COD_CLIENTE , B.OCORR_ENDERECO , B.RAMO , B.FONTE , B.DATA_MOVIMENTO , C.COD_PRODUTO_SIVPF , C.ORIGEM_PROPOSTA , C.COD_PESSOA , C.DIA_DEBITO , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.NOME_CONVENENTE , C.VAL_PAGO , C.CGC_CONVENENTE , B.OPC_COBERTURA , VALUE(C.OPCAOPAG, '0' ), CASE C.OPCAOPAG WHEN '1' THEN 'CONTA CORRENTE   ' WHEN '2' THEN 'CONTA POUPAN�A   ' WHEN '3' THEN 'CARN�            ' WHEN '4' THEN 'FOLHA PAGAMENTO  ' WHEN '5' THEN 'CARTAO DE CR�DITO' ELSE 'N�O CADASTRADO   ' END CASE, ROUND((C.VAL_PAGO * 0.38) / 100, 2), ROUND((C.VAL_PAGO - (C.VAL_PAGO * 0.38) / 100), 2) FROM SEGUROS.RELATORIOS A, SEGUROS.BILHETE B, SEGUROS.PROPOSTA_FIDELIZ C WHERE A.SIT_REGISTRO = '0' AND A.COD_RELATORIO IN ( 'BI3005B1' , 'BI7028B1' , 'BI0070B1' , 'BI0071B1' , 'BI0075B1' , 'BI7028B2' ) AND A.COD_OPERACAO IN (2,3,4) AND A.NUM_PARCELA = 0 AND A.NUM_TITULO = B.NUM_BILHETE AND B.NUM_BILHETE = C.NUM_SICOB AND B.SITUACAO NOT IN ( '8' , 'P' ) AND A.DATA_SOLICITACAO <= :SISTEMAS-DATA-MOV-5DIA ORDER BY B.NUM_BILHETE END-EXEC. */
            CRELAT = new BI7028B_CRELAT(true);
            string GetQuery_CRELAT()
            {
                var query = @$"SELECT DISTINCT 
							A.COD_OPERACAO
							, 
							A.COD_USUARIO
							, 
							A.COD_RELATORIO
							, 
							A.DATA_SOLICITACAO
							, 
							A.NUM_ENDOSSO
							, 
							B.DATA_QUITACAO
							, 
							B.NUM_APOLICE
							, 
							B.NUM_BILHETE
							, 
							B.COD_CLIENTE
							, 
							B.OCORR_ENDERECO
							, 
							B.RAMO
							, 
							B.FONTE
							, 
							B.DATA_MOVIMENTO
							, 
							C.COD_PRODUTO_SIVPF
							, 
							C.ORIGEM_PROPOSTA
							, 
							C.COD_PESSOA
							, 
							C.DIA_DEBITO
							, 
							C.AGECTADEB
							, 
							C.OPRCTADEB
							, 
							C.NUMCTADEB
							, 
							C.DIGCTADEB
							, 
							C.NOME_CONVENENTE
							, 
							C.VAL_PAGO
							, 
							C.CGC_CONVENENTE
							, 
							B.OPC_COBERTURA
							, 
							VALUE(C.OPCAOPAG
							, '0' )
							, 
							CASE C.OPCAOPAG 
							WHEN '1' THEN 'CONTA CORRENTE ' 
							WHEN '2' THEN 'CONTA POUPAN�A ' 
							WHEN '3' THEN 'CARN� ' 
							WHEN '4' THEN 'FOLHA PAGAMENTO ' 
							WHEN '5' THEN 'CARTAO DE CR�DITO' 
							ELSE 'N�O CADASTRADO ' 
							END CASE
							, 
							ROUND((C.VAL_PAGO * 0.38) / 100
							, 2)
							, 
							ROUND((C.VAL_PAGO - (C.VAL_PAGO * 0.38) 
							/ 100)
							, 2) 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.BILHETE B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE A.SIT_REGISTRO = '0' 
							AND A.COD_RELATORIO IN ( 'BI3005B1'
							, 'BI7028B1'
							, 
							'BI0070B1'
							, 'BI0071B1'
							, 'BI0075B1'
							, 'BI7028B2' ) 
							AND A.COD_OPERACAO IN (2
							,3
							,4) 
							AND A.NUM_PARCELA = 0 
							AND A.NUM_TITULO = B.NUM_BILHETE 
							AND B.NUM_BILHETE = C.NUM_SICOB 
							AND B.SITUACAO NOT IN ( '8'
							, 'P' ) 
							AND A.DATA_SOLICITACAO <= '{SISTEMAS_DATA_MOV_5DIA}' 
							ORDER BY B.NUM_BILHETE";

                return query;
            }
            CRELAT.GetQueryEvent += GetQuery_CRELAT;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-FETCH-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_FETCH_1()
        {
            /*" -1419- EXEC SQL FETCH CORIGEM INTO :ARQSIVPF-SISTEMA-ORIGEM END-EXEC */

            if (CORIGEM.Fetch())
            {
                _.Move(CORIGEM.ARQSIVPF_SISTEMA_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-CLOSE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_CLOSE_1()
        {
            /*" -1427- EXEC SQL CLOSE CORIGEM END-EXEC */

            CORIGEM.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-SECTION */
        private void R0900_00_DECLARE_RELATORI_SECTION()
        {
            /*" -1444- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -1499- PERFORM R0900_00_DECLARE_RELATORI_DB_DECLARE_1 */

            R0900_00_DECLARE_RELATORI_DB_DECLARE_1();

            /*" -1501- PERFORM R0900_00_DECLARE_RELATORI_DB_OPEN_1 */

            R0900_00_DECLARE_RELATORI_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-OPEN-1 */
        public void R0900_00_DECLARE_RELATORI_DB_OPEN_1()
        {
            /*" -1501- EXEC SQL OPEN CRELAT END-EXEC. */

            CRELAT.Open();

        }

        [StopWatch]
        /*" R2210-00-DECLARE-VG033-DB-DECLARE-1 */
        public void R2210_00_DECLARE_VG033_DB_DECLARE_1()
        {
            /*" -2633- EXEC SQL DECLARE CVG033 CURSOR FOR SELECT A.COD_COBERTURA , B.DES_ACESSORIO FROM SEGUROS.VG_COBERTURAS_SUBG A, SEGUROS.VG_ACESSORIO B WHERE A.NUM_APOLICE = :WHOST-NRAPOLICE AND A.COD_SUBGRUPO = :VGCOBSUB-COD-SUBGRUPO AND A.COD_COBERTURA = B.NUM_ACESSORIO ORDER BY A.COD_COBERTURA END-EXEC. */
            CVG033 = new BI7028B_CVG033(true);
            string GetQuery_CVG033()
            {
                var query = @$"SELECT A.COD_COBERTURA
							, 
							B.DES_ACESSORIO 
							FROM SEGUROS.VG_COBERTURAS_SUBG A
							, 
							SEGUROS.VG_ACESSORIO B 
							WHERE A.NUM_APOLICE = '{WHOST_NRAPOLICE}' 
							AND A.COD_SUBGRUPO = '{VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_SUBGRUPO}' 
							AND A.COD_COBERTURA = B.NUM_ACESSORIO 
							ORDER BY A.COD_COBERTURA";

                return query;
            }
            CVG033.GetQueryEvent += GetQuery_CVG033;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-SECTION */
        private void R0910_00_FETCH_RELATORI_SECTION()
        {
            /*" -1513- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -1544- PERFORM R0910_00_FETCH_RELATORI_DB_FETCH_1 */

            R0910_00_FETCH_RELATORI_DB_FETCH_1();

            /*" -1547- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1548- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -1550- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1550- PERFORM R0910_00_FETCH_RELATORI_DB_CLOSE_1 */

                R0910_00_FETCH_RELATORI_DB_CLOSE_1();

                /*" -1552- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -1554- END-IF. */
            }


            /*" -1558- ADD 1 TO AC-L-RELATORI AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_L_RELATORI.Value = AREA_DE_WORK.AC_L_RELATORI + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -1559- IF AC-CONTA GREATER 199 */

            if (AREA_DE_WORK.AC_CONTA > 199)
            {

                /*" -1560- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1561- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -1562- DISPLAY '**** LIDOS V0RELAT ' AC-LIDOS ' ' WHORA-CURR */

                $"**** LIDOS V0RELAT {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();

                /*" -1564- END-IF. */
            }


            /*" -1566- PERFORM R1010-00-VERIFICA-ORIGEM */

            R1010_00_VERIFICA_ORIGEM_SECTION();

            /*" -1567- IF WTEM-SISTEMA-ORIGEM EQUAL 'NAO' */

            if (AREA_DE_WORK.WTEM_SISTEMA_ORIGEM == "NAO")
            {

                /*" -1568- GO TO R0910-00-FETCH-RELATORI */
                new Task(() => R0910_00_FETCH_RELATORI_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1568- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-FETCH-1 */
        public void R0910_00_FETCH_RELATORI_DB_FETCH_1()
        {
            /*" -1544- EXEC SQL FETCH CRELAT INTO :RELATORI-COD-OPERACAO , :RELATORI-COD-USUARIO , :RELATORI-COD-RELATORIO , :RELATORI-DATA-SOLICITACAO , :RELATORI-NUM-ENDOSSO , :BILHETE-DATA-QUITACAO , :BILHETE-NUM-APOLICE , :BILHETE-NUM-BILHETE , :BILHETE-COD-CLIENTE , :BILHETE-OCORR-ENDERECO , :BILHETE-RAMO , :BILHETE-FONTE , :BILHETE-DATA-MOVIMENTO , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-COD-PESSOA , :PROPOFID-DIA-DEBITO , :PROPOFID-AGECTADEB , :PROPOFID-OPRCTADEB , :PROPOFID-NUMCTADEB , :PROPOFID-DIGCTADEB , :PROPOFID-NOME-CONVENENTE , :PROPOFID-VAL-PAGO , :PROPOFID-CGC-CONVENENTE , :BILHETE-OPC-COBERTURA , :PROPOFID-OPCAOPAG , :WS-CURSOR-FORMAPAG , :WS-CURSOR-VLIOF , :WS-CURSOR-VLPREMIO-LIQ END-EXEC. */

            if (CRELAT.Fetch())
            {
                _.Move(CRELAT.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(CRELAT.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(CRELAT.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(CRELAT.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(CRELAT.RELATORI_NUM_ENDOSSO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);
                _.Move(CRELAT.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(CRELAT.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(CRELAT.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(CRELAT.BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
                _.Move(CRELAT.BILHETE_OCORR_ENDERECO, BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO);
                _.Move(CRELAT.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(CRELAT.BILHETE_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);
                _.Move(CRELAT.BILHETE_DATA_MOVIMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO);
                _.Move(CRELAT.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(CRELAT.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(CRELAT.PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
                _.Move(CRELAT.PROPOFID_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);
                _.Move(CRELAT.PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);
                _.Move(CRELAT.PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);
                _.Move(CRELAT.PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);
                _.Move(CRELAT.PROPOFID_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);
                _.Move(CRELAT.PROPOFID_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);
                _.Move(CRELAT.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
                _.Move(CRELAT.PROPOFID_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);
                _.Move(CRELAT.BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(CRELAT.PROPOFID_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);
                _.Move(CRELAT.WS_CURSOR_FORMAPAG, W_COMPLEMENTO_FETCH.WS_CURSOR_FORMAPAG);
                _.Move(CRELAT.WS_CURSOR_VLIOF, W_COMPLEMENTO_FETCH.WS_CURSOR_VLIOF);
                _.Move(CRELAT.WS_CURSOR_VLPREMIO_LIQ, W_COMPLEMENTO_FETCH.WS_CURSOR_VLPREMIO_LIQ);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-CLOSE-1 */
        public void R0910_00_FETCH_RELATORI_DB_CLOSE_1()
        {
            /*" -1550- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1589- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -1590- PERFORM R1500-00-SELECT-ENDOSSOS. */

            R1500_00_SELECT_ENDOSSOS_SECTION();

            /*" -1591- IF WTEM-ENDOSSOS EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_ENDOSSOS == "N")
            {

                /*" -1592- ADD 1 TO AC-DESPR-ENDOSSOS */
                AREA_DE_WORK.AC_DESPR_ENDOSSOS.Value = AREA_DE_WORK.AC_DESPR_ENDOSSOS + 1;

                /*" -1593- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1595- END-IF */
            }


            /*" -1596- IF ENDOSSOS-DATA-INIVIGENCIA < LK-GEJVW002-JV-DTA-INI */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < GEJVW002.LK_GEJVW002_JV_DTA_INI)
            {

                /*" -1597- MOVE 108199999998 TO WHOST-NRAPOLICE */
                _.Move(108199999998, WHOST_NRAPOLICE);

                /*" -1598- ELSE */
            }
            else
            {


                /*" -1599- MOVE 3008199999998 TO WHOST-NRAPOLICE */
                _.Move(3008199999998, WHOST_NRAPOLICE);

                /*" -1601- END-IF */
            }


            /*" -1603- PERFORM R1020-00-SELECT-COBMENVG. */

            R1020_00_SELECT_COBMENVG_SECTION();

            /*" -1604- IF WTEM-COBMENVG EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_COBMENVG == "N")
            {

                /*" -1605- ADD 1 TO AC-DESPR-COBMENVG */
                AREA_DE_WORK.AC_DESPR_COBMENVG.Value = AREA_DE_WORK.AC_DESPR_COBMENVG + 1;

                /*" -1607- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -1608- PERFORM R1100-00-SELECT-CLIENTES. */

            R1100_00_SELECT_CLIENTES_SECTION();

            /*" -1609- IF WTEM-CLIENTES EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_CLIENTES == "N")
            {

                /*" -1610- ADD 1 TO AC-DESPR-CLIENTE */
                AREA_DE_WORK.AC_DESPR_CLIENTE.Value = AREA_DE_WORK.AC_DESPR_CLIENTE + 1;

                /*" -1611- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1613- END-IF. */
            }


            /*" -1614- PERFORM R1200-00-SELECT-ENDERECO. */

            R1200_00_SELECT_ENDERECO_SECTION();

            /*" -1615- IF WTEM-ENDERECO EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_ENDERECO == "N")
            {

                /*" -1616- ADD 1 TO AC-DESPR-ENDERECO */
                AREA_DE_WORK.AC_DESPR_ENDERECO.Value = AREA_DE_WORK.AC_DESPR_ENDERECO + 1;

                /*" -1617- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1619- END-IF. */
            }


            /*" -1620- PERFORM R1300-00-SELECT-PRODUTO. */

            R1300_00_SELECT_PRODUTO_SECTION();

            /*" -1621- IF WTEM-PRODUTO EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_PRODUTO == "N")
            {

                /*" -1622- ADD 1 TO AC-DESPR-COBERPRO */
                AREA_DE_WORK.AC_DESPR_COBERPRO.Value = AREA_DE_WORK.AC_DESPR_COBERPRO + 1;

                /*" -1623- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1625- END-IF. */
            }


            /*" -1637- PERFORM R1600-00-SELECT-BILCOBER. */

            R1600_00_SELECT_BILCOBER_SECTION();

            /*" -1641- IF RELATORI-COD-RELATORIO EQUAL 'BI0071B1' OR 'BI0075B1' OR 'BI7028B2' OR 'BI7028B1' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("BI0071B1", "BI0075B1", "BI7028B2", "BI7028B1"))
            {

                /*" -1643- PERFORM R3400-00-VERIFICA-CAP */

                R3400_00_VERIFICA_CAP_SECTION();

                /*" -1644- IF WTEM-FCTITULO EQUAL 'N' */

                if (AREA_DE_WORK.WTEM_FCTITULO == "N")
                {

                    /*" -1645- ADD 1 TO AC-DESPR-FCTITULO */
                    AREA_DE_WORK.AC_DESPR_FCTITULO.Value = AREA_DE_WORK.AC_DESPR_FCTITULO + 1;

                    /*" -1646- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1648- END-IF */
                }


                /*" -1650- IF VG0716S-COD-STA-TITULO EQUAL 'ATV' NEXT SENTENCE */

                if (VG0716S_COD_STA_TITULO == "ATV")
                {

                    /*" -1651- ELSE */
                }
                else
                {


                    /*" -1652- ADD 1 TO AC-DESPR-FCTITULO */
                    AREA_DE_WORK.AC_DESPR_FCTITULO.Value = AREA_DE_WORK.AC_DESPR_FCTITULO + 1;

                    /*" -1653- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1654- END-IF */
                }


                /*" -1656- END-IF. */
            }


            /*" -1663- IF RELATORI-COD-RELATORIO EQUAL 'BI3005B1' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "BI3005B1")
            {

                /*" -1664- PERFORM R3400-00-VERIFICA-CAP */

                R3400_00_VERIFICA_CAP_SECTION();

                /*" -1666- IF VG0716S-COD-STA-TITULO EQUAL 'ATV' NEXT SENTENCE */

                if (VG0716S_COD_STA_TITULO == "ATV")
                {

                    /*" -1667- ELSE */
                }
                else
                {


                    /*" -1668- ADD 1 TO AC-DESPR-FCTITULO */
                    AREA_DE_WORK.AC_DESPR_FCTITULO.Value = AREA_DE_WORK.AC_DESPR_FCTITULO + 1;

                    /*" -1669- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1673- END-IF */
                }


                /*" -1675- END-IF. */
            }


            /*" -1679- PERFORM R1550-00-SELECT-EMAIL. */

            R1550_00_SELECT_EMAIL_SECTION();

            /*" -1680- MOVE BILHETE-NUM-BILHETE TO SVA-BILHETE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, REG_SBI7028B.SVA_BILHETE);

            /*" -1681- MOVE BILHETE-NUM-APOLICE TO SVA-NRAPOLICE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, REG_SBI7028B.SVA_NRAPOLICE);

            /*" -1682- MOVE RELATORI-COD-USUARIO TO SVA-CODUSU. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SBI7028B.SVA_CODUSU);

            /*" -1683- MOVE BILHETE-RAMO TO SVA-RAMO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, REG_SBI7028B.SVA_RAMO);

            /*" -1684- MOVE RELATORI-COD-RELATORIO TO SVA-CODRELAT. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO, REG_SBI7028B.SVA_CODRELAT);

            /*" -1685- MOVE BILHETE-COD-CLIENTE TO SVA-CODCLIEN. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE, REG_SBI7028B.SVA_CODCLIEN);

            /*" -1686- MOVE ENDOSSOS-DATA-INIVIGENCIA TO SVA-DTINIVIG. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, REG_SBI7028B.SVA_DTINIVIG);

            /*" -1687- MOVE ENDOSSOS-DATA-TERVIGENCIA TO SVA-DTTERVIG. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_SBI7028B.SVA_DTTERVIG);

            /*" -1688- MOVE BILHETE-DATA-QUITACAO TO SVA-DTQUIT. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, REG_SBI7028B.SVA_DTQUIT);

            /*" -1689- MOVE BILHETE-DATA-MOVIMENTO TO SVA-DTMOVTO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO, REG_SBI7028B.SVA_DTMOVTO);

            /*" -1690- MOVE RELATORI-COD-OPERACAO TO SVA-CODOPER. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, REG_SBI7028B.SVA_CODOPER);

            /*" -1691- MOVE PROPOFID-DIA-DEBITO TO SVA-DIA-DEBITO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, REG_SBI7028B.SVA_DIA_DEBITO);

            /*" -1692- MOVE PROPOFID-AGECTADEB TO SVA-AGECTADEB. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB, REG_SBI7028B.SVA_AGECTADEB);

            /*" -1693- MOVE PROPOFID-OPRCTADEB TO SVA-OPRCTADEB. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB, REG_SBI7028B.SVA_OPRCTADEB);

            /*" -1694- MOVE PROPOFID-NUMCTADEB TO SVA-NUMCTADEB. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB, REG_SBI7028B.SVA_NUMCTADEB);

            /*" -1695- MOVE PROPOFID-DIGCTADEB TO SVA-DIGCTADEB. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB, REG_SBI7028B.SVA_DIGCTADEB);

            /*" -1696- MOVE PROPOFID-NOME-CONVENENTE TO WS-NUM-CARTAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE, AREA_DE_WORK.WS_NUM_CARTAO);

            /*" -1697- MOVE WS-NUM-CARTAO-NUM TO SVA-NUMCARTAO. */
            _.Move(AREA_DE_WORK.WS_NUM_CARTAO_R.WS_NUM_CARTAO_NUM, REG_SBI7028B.SVA_NUMCARTAO);

            /*" -1698- MOVE PROPOFID-VAL-PAGO TO SVA-VLPREMIO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, REG_SBI7028B.SVA_VLPREMIO);

            /*" -1699- MOVE PROPOFID-OPCAOPAG TO SVA-OPCAOPAG. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG, REG_SBI7028B.SVA_OPCAOPAG);

            /*" -1700- MOVE WS-CURSOR-FORMAPAG TO SVA-FORMAPAG. */
            _.Move(W_COMPLEMENTO_FETCH.WS_CURSOR_FORMAPAG, REG_SBI7028B.SVA_FORMAPAG);

            /*" -1701- MOVE WS-CURSOR-VLIOF TO SVA-VLIOF. */
            _.Move(W_COMPLEMENTO_FETCH.WS_CURSOR_VLIOF, REG_SBI7028B.SVA_VLIOF);

            /*" -1709- MOVE WS-CURSOR-VLPREMIO-LIQ TO SVA-VLPREMIO-LIQ. */
            _.Move(W_COMPLEMENTO_FETCH.WS_CURSOR_VLPREMIO_LIQ, REG_SBI7028B.SVA_VLPREMIO_LIQ);

            /*" -1710- MOVE CLIENTES-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SBI7028B.SVA_NOME_RAZAO);

            /*" -1711- MOVE CLIENTES-CGCCPF TO SVA-CPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SBI7028B.SVA_CPF);

            /*" -1712- MOVE CLIENTES-DATA-NASCIMENTO TO SVA-DT-NASC. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, REG_SBI7028B.SVA_DT_NASC);

            /*" -1713- MOVE CLIENTES-TIPO-PESSOA TO SVA-TP-PESSOA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, REG_SBI7028B.SVA_TP_PESSOA);

            /*" -1714- MOVE PROPOFID-ORIGEM-PROPOSTA TO SVA-ORIGEM. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, REG_SBI7028B.SVA_ORIGEM);

            /*" -1715- MOVE ENDERECO-ENDERECO TO SVA-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, REG_SBI7028B.SVA_ENDERECO);

            /*" -1716- MOVE ENDERECO-BAIRRO TO SVA-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, REG_SBI7028B.SVA_BAIRRO);

            /*" -1717- MOVE ENDERECO-CIDADE TO SVA-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, REG_SBI7028B.SVA_CIDADE);

            /*" -1718- MOVE ENDERECO-SIGLA-UF TO SVA-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SBI7028B.SVA_UF);

            /*" -1719- MOVE ENDERECO-CEP TO SVA-NUM-CEP. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, REG_SBI7028B.SVA_NUM_CEP);

            /*" -1720- MOVE PROPOFID-COD-PRODUTO-SIVPF TO SVA-COD-PRODUTO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, REG_SBI7028B.SVA_COD_PRODUTO);

            /*" -1721- MOVE PRODUTO-DESCR-PRODUTO TO SVA-DS-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, REG_SBI7028B.SVA_DS_PRODUTO);

            /*" -1722- MOVE PRODUTO-NUM-PROCESSO-SUSEP TO SVA-SUSEP. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP, REG_SBI7028B.SVA_SUSEP);

            /*" -1723- MOVE PESSOEMA-EMAIL TO SVA-EMAIL. */
            _.Move(PESSOEMA.DCLPESSOA_EMAIL.PESSOEMA_EMAIL, REG_SBI7028B.SVA_EMAIL);

            /*" -1724- MOVE PROPOFID-CGC-CONVENENTE TO SVA-CART-TITULAR. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE, REG_SBI7028B.SVA_CART_TITULAR);

            /*" -1730- MOVE WHOST-NRAPOLICE TO SVA-NUM-APOLICE-FORM */
            _.Move(WHOST_NRAPOLICE, REG_SBI7028B.SVA_NUM_APOLICE_FORM);

            /*" -1732- MOVE VG0716S-NUM-PLANO TO FCPLANO-NUM-PLANO */
            _.Move(VG0716S_NUM_PLANO, FCPLANO.DCLFC_PLANO.FCPLANO_NUM_PLANO);

            /*" -1738- PERFORM R1000_00_PROCESSA_INPUT_DB_SELECT_1 */

            R1000_00_PROCESSA_INPUT_DB_SELECT_1();

            /*" -1741- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -1743- DISPLAY 'PROBLEMA NO SELECT FC_PLANO <' FCPLANO-NUM-PLANO '>' */

                $"PROBLEMA NO SELECT FC_PLANO <{FCPLANO.DCLFC_PLANO.FCPLANO_NUM_PLANO}>"
                .Display();

                /*" -1744- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1745- ELSE */
            }
            else
            {


                /*" -1746- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1747- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1748- ELSE */
                }
                else
                {


                    /*" -1749- MOVE FCPLANO-QTD-DIG-COMBINACAO TO SVA-QTD-DIG */
                    _.Move(FCPLANO.DCLFC_PLANO.FCPLANO_QTD_DIG_COMBINACAO, REG_SBI7028B.SVA_QTD_DIG);

                    /*" -1750- END-IF */
                }


                /*" -1752- END-IF */
            }


            /*" -1754- MOVE PRODUTO-COD-EMPRESA TO SVA-COD-EMPRESA. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, REG_SBI7028B.SVA_COD_EMPRESA);

            /*" -1754- RELEASE REG-SBI7028B. */
            SBI7028B.Release(REG_SBI7028B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-DB-SELECT-1 */
        public void R1000_00_PROCESSA_INPUT_DB_SELECT_1()
        {
            /*" -1738- EXEC SQL SELECT QTD_DIG_COMBINACAO INTO :FCPLANO-QTD-DIG-COMBINACAO FROM FDRCAP.FC_PLANO WHERE NUM_PLANO = :FCPLANO-NUM-PLANO WITH UR END-EXEC. */

            var r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1()
            {
                FCPLANO_NUM_PLANO = FCPLANO.DCLFC_PLANO.FCPLANO_NUM_PLANO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCPLANO_QTD_DIG_COMBINACAO, FCPLANO.DCLFC_PLANO.FCPLANO_QTD_DIG_COMBINACAO);
            }


        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1758- PERFORM R0910-00-FETCH-RELATORI. */

            R0910_00_FETCH_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-VERIFICA-ORIGEM-SECTION */
        private void R1010_00_VERIFICA_ORIGEM_SECTION()
        {
            /*" -1771- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", WABEND.WNR_EXEC_SQL);

            /*" -1772- MOVE 1 TO WINF. */
            _.Move(1, AREA_DE_WORK.WINF);

            /*" -1773- MOVE WIND1 TO WSUP. */
            _.Move(AREA_DE_WORK.WIND1, AREA_DE_WORK.WSUP);

            /*" -1775- MOVE SPACES TO WTEM-SISTEMA-ORIGEM */
            _.Move("", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

            /*" -1776- PERFORM UNTIL WTEM-SISTEMA-ORIGEM NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WTEM_SISTEMA_ORIGEM.IsEmpty()))
            {

                /*" -1777- IF WINF > WSUP */

                if (AREA_DE_WORK.WINF > AREA_DE_WORK.WSUP)
                {

                    /*" -1778- MOVE 'NAO' TO WTEM-SISTEMA-ORIGEM */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                    /*" -1779- ELSE */
                }
                else
                {


                    /*" -1780- COMPUTE WINDI = (WSUP + WINF) / 2 */
                    AREA_DE_WORK.WINDI.Value = (AREA_DE_WORK.WSUP + AREA_DE_WORK.WINF) / 2;

                    /*" -1782- IF PROPOFID-ORIGEM-PROPOSTA < WTAB-SISTEMA-ORIGEM(WINDI) */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA < W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WINDI])
                    {

                        /*" -1783- COMPUTE WSUP = WINDI - 1 */
                        AREA_DE_WORK.WSUP.Value = AREA_DE_WORK.WINDI - 1;

                        /*" -1784- ELSE */
                    }
                    else
                    {


                        /*" -1786- IF PROPOFID-ORIGEM-PROPOSTA > WTAB-SISTEMA-ORIGEM(WINDI) */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA > W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WINDI])
                        {

                            /*" -1787- COMPUTE WINF = WINDI + 1 */
                            AREA_DE_WORK.WINF.Value = AREA_DE_WORK.WINDI + 1;

                            /*" -1788- ELSE */
                        }
                        else
                        {


                            /*" -1789- MOVE 'SIM' TO WTEM-SISTEMA-ORIGEM */
                            _.Move("SIM", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                            /*" -1790- END-IF */
                        }


                        /*" -1791- END-IF */
                    }


                    /*" -1792- END-IF */
                }


                /*" -1792- END-PERFORM. */
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-COBMENVG-SECTION */
        private void R1020_00_SELECT_COBMENVG_SECTION()
        {
            /*" -1804- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", WABEND.WNR_EXEC_SQL);

            /*" -1805- MOVE 'S' TO WTEM-COBMENVG. */
            _.Move("S", AREA_DE_WORK.WTEM_COBMENVG);

            /*" -1811- MOVE ZEROS TO HOST-COUNT1. */
            _.Move(0, HOST_COUNT1);

            /*" -1819- PERFORM R1020_00_SELECT_COBMENVG_DB_SELECT_1 */

            R1020_00_SELECT_COBMENVG_DB_SELECT_1();

            /*" -1822- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1823- DISPLAY 'R1020 - ERRO NA COBRANCA_MENS_VGAP ' */
                _.Display($"R1020 - ERRO NA COBRANCA_MENS_VGAP ");

                /*" -1824- DISPLAY 'APOLICE     => ' BILHETE-NUM-APOLICE */
                _.Display($"APOLICE     => {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}");

                /*" -1826- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1827- IF HOST-COUNT1 EQUAL ZEROS */

            if (HOST_COUNT1 == 00)
            {

                /*" -1828- MOVE 'N' TO WTEM-COBMENVG */
                _.Move("N", AREA_DE_WORK.WTEM_COBMENVG);

                /*" -1828- END-IF. */
            }


        }

        [StopWatch]
        /*" R1020-00-SELECT-COBMENVG-DB-SELECT-1 */
        public void R1020_00_SELECT_COBMENVG_DB_SELECT_1()
        {
            /*" -1819- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT1 FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :WHOST-NRAPOLICE AND CODSUBES = :PROPOFID-COD-PRODUTO-SIVPF AND COD_OPERACAO = 3 END-EXEC. */

            var r1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1 = new R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT1, HOST_COUNT1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTES-SECTION */
        private void R1100_00_SELECT_CLIENTES_SECTION()
        {
            /*" -1840- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -1842- INITIALIZE DCLCLIENTES. */
            _.Initialize(
                CLIENTES.DCLCLIENTES
            );

            /*" -1844- MOVE 'S' TO WTEM-CLIENTES. */
            _.Move("S", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -1855- PERFORM R1100_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1100_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -1858- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1859- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1860- MOVE 'N' TO WTEM-CLIENTES */
                    _.Move("N", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -1861- ELSE */
                }
                else
                {


                    /*" -1862- DISPLAY '* BI7028B PROBLEMAS NO ACESSO A CLIENTES' */
                    _.Display($"* BI7028B PROBLEMAS NO ACESSO A CLIENTES");

                    /*" -1863- DISPLAY ' ' BILHETE-NUM-BILHETE */
                    _.Display($" {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1864- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1865- END-IF */
                }


                /*" -1865- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1100_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -1855- EXEC SQL SELECT NOME_RAZAO, CGCCPF, DATA_NASCIMENTO, TIPO_PESSOA INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-DATA-NASCIMENTO, :CLIENTES-TIPO-PESSOA FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :BILHETE-COD-CLIENTE END-EXEC. */

            var r1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                BILHETE_COD_CLIENTE = BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-ENDERECO-SECTION */
        private void R1200_00_SELECT_ENDERECO_SECTION()
        {
            /*" -1877- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -1879- INITIALIZE DCLENDERECOS. */
            _.Initialize(
                ENDERECO.DCLENDERECOS
            );

            /*" -1881- MOVE 'S' TO WTEM-ENDERECO. */
            _.Move("S", AREA_DE_WORK.WTEM_ENDERECO);

            /*" -1900- PERFORM R1200_00_SELECT_ENDERECO_DB_SELECT_1 */

            R1200_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -1903- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1904- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1905- MOVE 'N' TO WTEM-ENDERECO */
                    _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                    /*" -1906- ELSE */
                }
                else
                {


                    /*" -1908- DISPLAY '* BI7028B PROBLEMAS NO ACESSO A ENDERECOS' BILHETE-NUM-BILHETE ' ' BILHETE-COD-CLIENTE */

                    $"* BI7028B PROBLEMAS NO ACESSO A ENDERECOS{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE} {BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE}"
                    .Display();

                    /*" -1909- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1910- END-IF */
                }


                /*" -1910- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R1200_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -1900- EXEC SQL SELECT A.ENDERECO, A.BAIRRO, A.CIDADE, A.SIGLA_UF, A.CEP INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP FROM SEGUROS.ENDERECOS A WHERE A.COD_CLIENTE = :BILHETE-COD-CLIENTE AND A.OCORR_ENDERECO = :BILHETE-OCORR-ENDERECO WITH UR END-EXEC. */

            var r1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                BILHETE_OCORR_ENDERECO = BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO.ToString(),
                BILHETE_COD_CLIENTE = BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-PRODUTO-SECTION */
        private void R1300_00_SELECT_PRODUTO_SECTION()
        {
            /*" -1922- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1924- INITIALIZE DCLPRODUTO. */
            _.Initialize(
                PRODUTO.DCLPRODUTO
            );

            /*" -1926- MOVE 'S' TO WTEM-PRODUTO. */
            _.Move("S", AREA_DE_WORK.WTEM_PRODUTO);

            /*" -1935- PERFORM R1300_00_SELECT_PRODUTO_DB_SELECT_1 */

            R1300_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -1938- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1939- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1940- MOVE 'N' TO WTEM-PRODUTO */
                    _.Move("N", AREA_DE_WORK.WTEM_PRODUTO);

                    /*" -1941- ELSE */
                }
                else
                {


                    /*" -1943- DISPLAY '* BI7028B PROBLEMAS ACESSO PRODUTO' BILHETE-NUM-BILHETE */
                    _.Display($"* BI7028B PROBLEMAS ACESSO PRODUTO{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1944- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1945- END-IF */
                }


                /*" -1947- END-IF. */
            }


            /*" -1948- IF VIND-NULL-SUSEP LESS ZEROS */

            if (VIND_NULL_SUSEP < 00)
            {

                /*" -1949- MOVE SPACES TO PRODUTO-NUM-PROCESSO-SUSEP */
                _.Move("", PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP);

                /*" -1949- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R1300_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -1935- EXEC SQL SELECT DESCR_PRODUTO, NUM_PROCESSO_SUSEP , COD_EMPRESA INTO :PRODUTO-DESCR-PRODUTO, :PRODUTO-NUM-PROCESSO-SUSEP:VIND-NULL-SUSEP , :PRODUTO-COD-EMPRESA FROM SEGUROS.PRODUTO WHERE COD_PRODUTO =:PROPOFID-COD-PRODUTO-SIVPF END-EXEC. */

            var r1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(executed_1.PRODUTO_NUM_PROCESSO_SUSEP, PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP);
                _.Move(executed_1.VIND_NULL_SUSEP, VIND_NULL_SUSEP);
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-MOVDEBCE-SECTION */
        private void R1400_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -1961- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -1963- INITIALIZE DCLMOVTO-DEBITOCC-CEF. */
            _.Initialize(
                MOVDEBCE.DCLMOVTO_DEBITOCC_CEF
            );

            /*" -1965- MOVE 'S' TO WTEM-MOVDEBCE. */
            _.Move("S", AREA_DE_WORK.WTEM_MOVDEBCE);

            /*" -1985- PERFORM R1400_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R1400_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -1988- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1989- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1990- MOVE 'N' TO WTEM-MOVDEBCE */
                    _.Move("N", AREA_DE_WORK.WTEM_MOVDEBCE);

                    /*" -1991- ELSE */
                }
                else
                {


                    /*" -1993- DISPLAY '* BI7028B PROBLEMAS ACESSO MOVTO_DEBITOCC_CEF' BILHETE-NUM-BILHETE */
                    _.Display($"* BI7028B PROBLEMAS ACESSO MOVTO_DEBITOCC_CEF{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1994- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1995- END-IF */
                }


                /*" -1997- END-IF. */
            }


            /*" -1998- IF VIND-AGECTADEB < ZEROS */

            if (VIND_AGECTADEB < 00)
            {

                /*" -1999- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

                /*" -2001- END-IF. */
            }


            /*" -2002- IF VIND-OPRCTADEB < ZEROS */

            if (VIND_OPRCTADEB < 00)
            {

                /*" -2003- MOVE ZEROS TO MOVDEBCE-OPER-CONTA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                /*" -2005- END-IF. */
            }


            /*" -2006- IF VIND-NUMCTADEB < ZEROS */

            if (VIND_NUMCTADEB < 00)
            {

                /*" -2007- MOVE ZEROS TO MOVDEBCE-NUM-CONTA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

                /*" -2009- END-IF. */
            }


            /*" -2010- IF VIND-DIGCTADEB < ZEROS */

            if (VIND_DIGCTADEB < 00)
            {

                /*" -2011- MOVE ZEROS TO MOVDEBCE-DIG-CONTA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -2013- END-IF. */
            }


            /*" -2014- IF VIND-CARTAO < ZEROS */

            if (VIND_CARTAO < 00)
            {

                /*" -2015- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

                /*" -2015- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R1400_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -1985- EXEC SQL SELECT DATA_VENCIMENTO , VALOR_DEBITO , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , NUM_CARTAO INTO :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DIA-DEBITO , :MOVDEBCE-COD-AGENCIA-DEB:VIND-AGECTADEB, :MOVDEBCE-OPER-CONTA-DEB:VIND-OPRCTADEB , :MOVDEBCE-NUM-CONTA-DEB:VIND-NUMCTADEB , :MOVDEBCE-DIG-CONTA-DEB:VIND-DIGCTADEB , :MOVDEBCE-NUM-CARTAO:VIND-CARTAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE AND NUM_ENDOSSO = :RELATORI-NUM-ENDOSSO END-EXEC. */

            var r1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(executed_1.MOVDEBCE_DIA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.VIND_DIGCTADEB, VIND_DIGCTADEB);
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                _.Move(executed_1.VIND_CARTAO, VIND_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-ENDOSSOS-SECTION */
        private void R1500_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -2026- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -2028- MOVE 'S' TO WTEM-ENDOSSOS. */
            _.Move("S", AREA_DE_WORK.WTEM_ENDOSSOS);

            /*" -2030- INITIALIZE DCLENDOSSOS. */
            _.Initialize(
                ENDOSSOS.DCLENDOSSOS
            );

            /*" -2038- PERFORM R1500_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1500_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -2041- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2042- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2043- MOVE 'N' TO WTEM-ENDOSSOS */
                    _.Move("N", AREA_DE_WORK.WTEM_ENDOSSOS);

                    /*" -2045- DISPLAY 'ENDOSSO NAO CADASTRADO ' 'APOLICE: ' BILHETE-NUM-APOLICE */

                    $"ENDOSSO NAO CADASTRADO APOLICE: {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}"
                    .Display();

                    /*" -2046- ELSE */
                }
                else
                {


                    /*" -2048- DISPLAY 'R1500 - PROBLEMAS SELECT ENDOSSOS  ..' SQLCODE ' ' BILHETE-NUM-APOLICE */

                    $"R1500 - PROBLEMAS SELECT ENDOSSOS  ..{DB.SQLCODE} {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}"
                    .Display();

                    /*" -2049- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2050- END-IF */
                }


                /*" -2050- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1500_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -2038- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :ENDOSSOS-DATA-INIVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-SELECT-EMAIL-SECTION */
        private void R1550_00_SELECT_EMAIL_SECTION()
        {
            /*" -2062- MOVE '1550' TO WNR-EXEC-SQL. */
            _.Move("1550", WABEND.WNR_EXEC_SQL);

            /*" -2064- INITIALIZE DCLPESSOA-EMAIL. */
            _.Initialize(
                PESSOEMA.DCLPESSOA_EMAIL
            );

            /*" -2071- PERFORM R1550_00_SELECT_EMAIL_DB_SELECT_1 */

            R1550_00_SELECT_EMAIL_DB_SELECT_1();

            /*" -2074- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2075- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2076- MOVE SPACES TO PESSOEMA-EMAIL */
                    _.Move("", PESSOEMA.DCLPESSOA_EMAIL.PESSOEMA_EMAIL);

                    /*" -2077- ELSE */
                }
                else
                {


                    /*" -2080- DISPLAY 'R1550 - PROBLEMAS SELECT PESSOEMA  ..' SQLCODE ' ' BILHETE-NUM-APOLICE ' ' BILHETE-COD-CLIENTE */

                    $"R1550 - PROBLEMAS SELECT PESSOEMA  ..{DB.SQLCODE} {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE} {BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE}"
                    .Display();

                    /*" -2081- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2082- END-IF */
                }


                /*" -2082- END-IF. */
            }


        }

        [StopWatch]
        /*" R1550-00-SELECT-EMAIL-DB-SELECT-1 */
        public void R1550_00_SELECT_EMAIL_DB_SELECT_1()
        {
            /*" -2071- EXEC SQL SELECT EMAIL INTO :PESSOEMA-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :PROPOFID-COD-PESSOA ORDER BY SEQ_EMAIL DESC FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1550_00_SELECT_EMAIL_DB_SELECT_1_Query1 = new R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1.Execute(r1550_00_SELECT_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOEMA_EMAIL, PESSOEMA.DCLPESSOA_EMAIL.PESSOEMA_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-BILCOBER-SECTION */
        private void R1600_00_SELECT_BILCOBER_SECTION()
        {
            /*" -2094- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -2096- INITIALIZE DCLBILHETE-COBERTURA. */
            _.Initialize(
                BILCOBER.DCLBILHETE_COBERTURA
            );

            /*" -2097- MOVE PROPOFID-COD-PRODUTO-SIVPF TO BILCOBER-COD-PRODUTO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO);

            /*" -2098- MOVE BILHETE-RAMO TO BILCOBER-RAMO-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA);

            /*" -2100- MOVE BILHETE-OPC-COBERTURA TO BILCOBER-COD-OPCAO-PLANO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO);

            /*" -2110- PERFORM R1600_00_SELECT_BILCOBER_DB_SELECT_1 */

            R1600_00_SELECT_BILCOBER_DB_SELECT_1();

            /*" -2113- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2114- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2115- MOVE ZEROS TO BILCOBER-VAL-MAX-COBER-BAS */
                    _.Move(0, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS);

                    /*" -2116- ELSE */
                }
                else
                {


                    /*" -2117- DISPLAY 'BI7028B  - PROBLEMAS SELECT BILCOBER' */
                    _.Display($"BI7028B  - PROBLEMAS SELECT BILCOBER");

                    /*" -2118- DISPLAY 'BILHETE ..: ' BILHETE-NUM-BILHETE */
                    _.Display($"BILHETE ..: {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -2119- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2120- END-IF */
                }


                /*" -2121- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-BILCOBER-DB-SELECT-1 */
        public void R1600_00_SELECT_BILCOBER_DB_SELECT_1()
        {
            /*" -2110- EXEC SQL SELECT VAL_MAX_COBER_BAS INTO :BILCOBER-VAL-MAX-COBER-BAS FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = 9999 AND COD_PRODUTO = :BILCOBER-COD-PRODUTO AND RAMO_COBERTURA = :BILCOBER-RAMO-COBERTURA AND MODALI_COBERTURA = 0 AND COD_OPCAO_PLANO = :BILCOBER-COD-OPCAO-PLANO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC */

            var r1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1 = new R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1()
            {
                BILCOBER_COD_OPCAO_PLANO = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO.ToString(),
                BILCOBER_RAMO_COBERTURA = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA.ToString(),
                BILCOBER_COD_PRODUTO = BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILCOBER_VAL_MAX_COBER_BAS, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -2132- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -2134- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE. */
            _.Move(REG_SBI7028B.SVA_NRAPOLICE, WS_NUM_APOLICE);

            /*" -2134- PERFORM R2200-00-PROCESSA-REGISTRO. */

            R2200_00_PROCESSA_REGISTRO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-LE-SORT-SECTION */
        private void R2100_00_LE_SORT_SECTION()
        {
            /*" -2146- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -2148- RETURN SBI7028B AT END */
            try
            {
                SBI7028B.Return(REG_SBI7028B, () =>
                {

                    /*" -2149- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -2151- GO TO R2100-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2154- ADD 1 TO AC-LIDOS AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -2156- MOVE SVA-COD-EMPRESA TO PRODUTO-COD-EMPRESA. */
            _.Move(REG_SBI7028B.SVA_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);

            /*" -2157- IF AC-CONTA GREATER 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -2158- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -2159- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -2159- DISPLAY '*** LIDOS SORT       ' AC-LIDOS ' ' WHORA-CURR. */

                $"*** LIDOS SORT       {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-REGISTRO-SECTION */
        private void R2200_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -2171- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -2173- PERFORM R2300-00-CARREGA-COBMENVG. */

            R2300_00_CARREGA_COBMENVG_SECTION();

            /*" -2177- MOVE COBMENVG-JDE TO WS-FORMULARIO. */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, WS_FORMULARIO);

            /*" -2178- IF SVA-CODRELAT EQUAL 'BI3005B1' */

            if (REG_SBI7028B.SVA_CODRELAT == "BI3005B1")
            {

                /*" -2179- MOVE '01' TO CABU-COD-SOLICITA */
                _.Move("01", AREA_DE_WORK.CABU.CABU_COD_SOLICITA);

                /*" -2180- END-IF. */
            }


            /*" -2181- IF SVA-CODRELAT EQUAL 'BI7028B1' */

            if (REG_SBI7028B.SVA_CODRELAT == "BI7028B1")
            {

                /*" -2182- PERFORM R2350-00-COBMENVG-SEGUNDA-VIA */

                R2350_00_COBMENVG_SEGUNDA_VIA_SECTION();

                /*" -2183- IF WS-TEM-SEG-VIA EQUAL 'S' */

                if (AREA_DE_WORK.WS_TEM_SEG_VIA == "S")
                {

                    /*" -2184- MOVE COBMENVG-JDE TO WS-FORMULARIO */
                    _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, WS_FORMULARIO);

                    /*" -2185- END-IF */
                }


                /*" -2186- MOVE '02' TO CABU-COD-SOLICITA */
                _.Move("02", AREA_DE_WORK.CABU.CABU_COD_SOLICITA);

                /*" -2187- END-IF. */
            }


            /*" -2188- IF SVA-CODRELAT EQUAL 'BI0070B1' */

            if (REG_SBI7028B.SVA_CODRELAT == "BI0070B1")
            {

                /*" -2189- MOVE '03' TO CABU-COD-SOLICITA */
                _.Move("03", AREA_DE_WORK.CABU.CABU_COD_SOLICITA);

                /*" -2190- END-IF. */
            }


            /*" -2191- IF SVA-CODRELAT EQUAL 'BI0071B1' OR 'BI0075B1' */

            if (REG_SBI7028B.SVA_CODRELAT.In("BI0071B1", "BI0075B1"))
            {

                /*" -2192- MOVE '06' TO CABU-COD-SOLICITA */
                _.Move("06", AREA_DE_WORK.CABU.CABU_COD_SOLICITA);

                /*" -2193- END-IF. */
            }


            /*" -2194- IF SVA-CODRELAT EQUAL 'BI7028B2' */

            if (REG_SBI7028B.SVA_CODRELAT == "BI7028B2")
            {

                /*" -2195- MOVE '07' TO CABU-COD-SOLICITA */
                _.Move("07", AREA_DE_WORK.CABU.CABU_COD_SOLICITA);

                /*" -2197- END-IF. */
            }


            /*" -2199- MOVE SVA-BILHETE TO CABU-NUM-BILHETE. */
            _.Move(REG_SBI7028B.SVA_BILHETE, AREA_DE_WORK.CABU.CABU_NUM_BILHETE);

            /*" -2200- MOVE WS-FORMULARIO TO CABU-COD-FORMULARIO. */
            _.Move(WS_FORMULARIO, AREA_DE_WORK.CABU.CABU_COD_FORMULARIO);

            /*" -2201- MOVE 'GEPES' TO CABU-NOM-CENTRO-CUSTO. */
            _.Move("GEPES", AREA_DE_WORK.CABU.CABU_NOM_CENTRO_CUSTO);

            /*" -2202- MOVE SVA-COD-PRODUTO TO CABU-COD-PRODUTO. */
            _.Move(REG_SBI7028B.SVA_COD_PRODUTO, AREA_DE_WORK.CABU.CABU_COD_PRODUTO);

            /*" -2203- MOVE SVA-DS-PRODUTO TO CABU-DS-PRODUTO. */
            _.Move(REG_SBI7028B.SVA_DS_PRODUTO, AREA_DE_WORK.CABU.CABU_DS_PRODUTO);

            /*" -2204- MOVE SVA-NOME-RAZAO TO CABU-NOM-CLIENTE. */
            _.Move(REG_SBI7028B.SVA_NOME_RAZAO, AREA_DE_WORK.CABU.CABU_NOM_CLIENTE);

            /*" -2205- MOVE SVA-ENDERECO TO CABU-DS-LOGRADOURO. */
            _.Move(REG_SBI7028B.SVA_ENDERECO, AREA_DE_WORK.CABU.CABU_DS_LOGRADOURO);

            /*" -2206- MOVE SVA-BAIRRO TO CABU-DS-BAIRRO. */
            _.Move(REG_SBI7028B.SVA_BAIRRO, AREA_DE_WORK.CABU.CABU_DS_BAIRRO);

            /*" -2207- MOVE SVA-CIDADE TO CABU-DS-CIDADE. */
            _.Move(REG_SBI7028B.SVA_CIDADE, AREA_DE_WORK.CABU.CABU_DS_CIDADE);

            /*" -2208- MOVE SVA-UF TO CABU-SG-UF. */
            _.Move(REG_SBI7028B.SVA_UF, AREA_DE_WORK.CABU.CABU_SG_UF);

            /*" -2210- MOVE SVA-EMAIL TO CABU-EMAIL. */
            _.Move(REG_SBI7028B.SVA_EMAIL, AREA_DE_WORK.CABU.CABU_EMAIL);

            /*" -2211- MOVE SVA-NUM-CEP TO WS-CEP-AUX1. */
            _.Move(REG_SBI7028B.SVA_NUM_CEP, AREA_DE_WORK.WS_CEP_AUX1);

            /*" -2212- MOVE WS-CEP-AUX-NUM1 TO WS-CEP-NUM1. */
            _.Move(AREA_DE_WORK.WS_CEP_AUX1.WS_CEP_AUX_NUM1, AREA_DE_WORK.WS_CEP_AUX.WS_CEP_NUM1);

            /*" -2213- MOVE WS-CEP-AUX-NUM2 TO WS-CEP-NUM2. */
            _.Move(AREA_DE_WORK.WS_CEP_AUX1.WS_CEP_AUX_NUM2, AREA_DE_WORK.WS_CEP_AUX.WS_CEP_NUM2);

            /*" -2214- MOVE WS-CEP-AUX-NUM3 TO WS-CEP-NUM3. */
            _.Move(AREA_DE_WORK.WS_CEP_AUX1.WS_CEP_AUX_NUM3, AREA_DE_WORK.WS_CEP_AUX.WS_CEP_NUM3);

            /*" -2215- MOVE '.' TO WS-CEP-P1. */
            _.Move(".", AREA_DE_WORK.WS_CEP_AUX.WS_CEP_P1);

            /*" -2216- MOVE '-' TO WS-CEP-DIG. */
            _.Move("-", AREA_DE_WORK.WS_CEP_AUX.WS_CEP_DIG);

            /*" -2229- MOVE WS-CEP-AUX TO CABU-CEP. */
            _.Move(AREA_DE_WORK.WS_CEP_AUX, AREA_DE_WORK.CABU.CABU_CEP);

            /*" -2231- PERFORM R2250-00-SELECT-ESTIP. */

            R2250_00_SELECT_ESTIP_SECTION();

            /*" -2232- IF CLIENTES-TIPO-PESSOA EQUAL 'J' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "J")
            {

                /*" -2233- MOVE CLIENTES-NOME-RAZAO TO CABU-NOM-ESTIPULANTE */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.CABU.CABU_NOM_ESTIPULANTE);

                /*" -2234- MOVE CLIENTES-CGCCPF TO WS-CGC */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WS_CGC);

                /*" -2235- MOVE WS-CGC TO WS-CGC-AUX1 */
                _.Move(WS_CGC, AREA_DE_WORK.WS_CGC_AUX1);

                /*" -2236- MOVE WS-CGC-AUX-NUM1 TO WS-CGC-NUM1 */
                _.Move(AREA_DE_WORK.WS_CGC_AUX1.WS_CGC_AUX_NUM1, AREA_DE_WORK.WS_CGC_AUX.WS_CGC_NUM1);

                /*" -2237- MOVE WS-CGC-AUX-NUM2 TO WS-CGC-NUM2 */
                _.Move(AREA_DE_WORK.WS_CGC_AUX1.WS_CGC_AUX_NUM2, AREA_DE_WORK.WS_CGC_AUX.WS_CGC_NUM2);

                /*" -2238- MOVE WS-CGC-AUX-NUM3 TO WS-CGC-NUM3 */
                _.Move(AREA_DE_WORK.WS_CGC_AUX1.WS_CGC_AUX_NUM3, AREA_DE_WORK.WS_CGC_AUX.WS_CGC_NUM3);

                /*" -2239- MOVE WS-CGC-AUX-NUM4 TO WS-CGC-NUM4 */
                _.Move(AREA_DE_WORK.WS_CGC_AUX1.WS_CGC_AUX_NUM4, AREA_DE_WORK.WS_CGC_AUX.WS_CGC_NUM4);

                /*" -2240- MOVE WS-CGC-AUX-NUM5 TO WS-CGC-NUM5 */
                _.Move(AREA_DE_WORK.WS_CGC_AUX1.WS_CGC_AUX_NUM5, AREA_DE_WORK.WS_CGC_AUX.WS_CGC_NUM5);

                /*" -2242- MOVE '.' TO WS-CGC-P1 WS-CGC-P2 */
                _.Move(".", AREA_DE_WORK.WS_CGC_AUX.WS_CGC_P1, AREA_DE_WORK.WS_CGC_AUX.WS_CGC_P2);

                /*" -2243- MOVE '/' TO WS-CGC-BARRA1 */
                _.Move("/", AREA_DE_WORK.WS_CGC_AUX.WS_CGC_BARRA1);

                /*" -2244- MOVE '-' TO WS-CGC-DIG */
                _.Move("-", AREA_DE_WORK.WS_CGC_AUX.WS_CGC_DIG);

                /*" -2245- MOVE WS-CGC-AUX TO CABU-CNPJ-ESTIPULANTE */
                _.Move(AREA_DE_WORK.WS_CGC_AUX, AREA_DE_WORK.CABU.CABU_CNPJ_ESTIPULANTE);

                /*" -2246- ELSE */
            }
            else
            {


                /*" -2247- MOVE SVA-NOME-RAZAO TO CABU-NOM-ESTIPULANTE */
                _.Move(REG_SBI7028B.SVA_NOME_RAZAO, AREA_DE_WORK.CABU.CABU_NOM_ESTIPULANTE);

                /*" -2248- MOVE SVA-CPF TO WS-CPF-AUX1 */
                _.Move(REG_SBI7028B.SVA_CPF, AREA_DE_WORK.WS_CPF_AUX1);

                /*" -2249- MOVE WS-CPF-AUX-NUM1 TO WS-CPF-NUM1 */
                _.Move(AREA_DE_WORK.WS_CPF_AUX1.WS_CPF_AUX_NUM1, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_NUM1);

                /*" -2250- MOVE WS-CPF-AUX-NUM2 TO WS-CPF-NUM2 */
                _.Move(AREA_DE_WORK.WS_CPF_AUX1.WS_CPF_AUX_NUM2, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_NUM2);

                /*" -2251- MOVE WS-CPF-AUX-NUM3 TO WS-CPF-NUM3 */
                _.Move(AREA_DE_WORK.WS_CPF_AUX1.WS_CPF_AUX_NUM3, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_NUM3);

                /*" -2252- MOVE WS-CPF-AUX-NUM4 TO WS-CPF-NUM4 */
                _.Move(AREA_DE_WORK.WS_CPF_AUX1.WS_CPF_AUX_NUM4, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_NUM4);

                /*" -2254- MOVE '.' TO WS-CPF-P1 WS-CPF-P2 */
                _.Move(".", AREA_DE_WORK.WS_CPF_AUX.WS_CPF_P1, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_P2);

                /*" -2255- MOVE '-' TO WS-CPF-DIG */
                _.Move("-", AREA_DE_WORK.WS_CPF_AUX.WS_CPF_DIG);

                /*" -2256- MOVE WS-CPF-AUX TO CABU-CNPJ-ESTIPULANTE */
                _.Move(AREA_DE_WORK.WS_CPF_AUX, AREA_DE_WORK.CABU.CABU_CNPJ_ESTIPULANTE);

                /*" -2257- PERFORM R4000-00-BUSCA-NOM-SOCIAL THRU R4000-99-SAIDA */

                R4000_00_BUSCA_NOM_SOCIAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/


                /*" -2259- END-IF */
            }


            /*" -2268- MOVE SVA-NRAPOLICE TO CABU-NUM-APOLICE. */
            _.Move(REG_SBI7028B.SVA_NRAPOLICE, AREA_DE_WORK.CABU.CABU_NUM_APOLICE);

            /*" -2271- MOVE SPACES TO CABU-DT-ULT-ALT. */
            _.Move("", AREA_DE_WORK.CABU.CABU_DT_ULT_ALT);

            /*" -2272- MOVE SVA-DTINIVIG TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -2273- MOVE WS-DIA-INV TO WS-DIA-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_DIA_INI);

            /*" -2274- MOVE WS-MES-INV TO WS-MES-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_MES_INI);

            /*" -2275- MOVE WS-ANO-INV TO WS-ANO-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_ANO_INI);

            /*" -2277- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA1, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA2);

            /*" -2278- MOVE ' A ' TO WS-FIL-A */
            _.Move(" A ", AREA_DE_WORK.WS_DATA_SEG.WS_FIL_A);

            /*" -2279- MOVE SVA-DTTERVIG TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -2280- MOVE WS-DIA-INV TO WS-DIA-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_DIA_TER);

            /*" -2281- MOVE WS-MES-INV TO WS-MES-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_MES_TER);

            /*" -2282- MOVE WS-ANO-INV TO WS-ANO-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_ANO_TER);

            /*" -2284- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA3, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA4);

            /*" -2286- MOVE WS-DATA-SEG TO CABU-DT-VIG-SEGURADO */
            _.Move(AREA_DE_WORK.WS_DATA_SEG, AREA_DE_WORK.CABU.CABU_DT_VIG_SEGURADO);

            /*" -2287- MOVE SPACES TO CABU-DT-VIG-DEPENDENTE. */
            _.Move("", AREA_DE_WORK.CABU.CABU_DT_VIG_DEPENDENTE);

            /*" -2289- MOVE SVA-NOME-RAZAO TO CABU-NOM-SEGURADO3. */
            _.Move(REG_SBI7028B.SVA_NOME_RAZAO, AREA_DE_WORK.CABU.CABU_NOM_SEGURADO3);

            /*" -2290- MOVE SVA-CPF TO WS-CPF-AUX1. */
            _.Move(REG_SBI7028B.SVA_CPF, AREA_DE_WORK.WS_CPF_AUX1);

            /*" -2291- MOVE WS-CPF-AUX-NUM1 TO WS-CPF-NUM1 */
            _.Move(AREA_DE_WORK.WS_CPF_AUX1.WS_CPF_AUX_NUM1, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_NUM1);

            /*" -2292- MOVE WS-CPF-AUX-NUM2 TO WS-CPF-NUM2 */
            _.Move(AREA_DE_WORK.WS_CPF_AUX1.WS_CPF_AUX_NUM2, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_NUM2);

            /*" -2293- MOVE WS-CPF-AUX-NUM3 TO WS-CPF-NUM3 */
            _.Move(AREA_DE_WORK.WS_CPF_AUX1.WS_CPF_AUX_NUM3, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_NUM3);

            /*" -2294- MOVE WS-CPF-AUX-NUM4 TO WS-CPF-NUM4 */
            _.Move(AREA_DE_WORK.WS_CPF_AUX1.WS_CPF_AUX_NUM4, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_NUM4);

            /*" -2296- MOVE '.' TO WS-CPF-P1 WS-CPF-P2. */
            _.Move(".", AREA_DE_WORK.WS_CPF_AUX.WS_CPF_P1, AREA_DE_WORK.WS_CPF_AUX.WS_CPF_P2);

            /*" -2297- MOVE '-' TO WS-CPF-DIG. */
            _.Move("-", AREA_DE_WORK.WS_CPF_AUX.WS_CPF_DIG);

            /*" -2299- MOVE WS-CPF-AUX TO CABU-CPF-SEGURADO. */
            _.Move(AREA_DE_WORK.WS_CPF_AUX, AREA_DE_WORK.CABU.CABU_CPF_SEGURADO);

            /*" -2300- MOVE SVA-DT-NASC TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DT_NASC, AREA_DE_WORK.WS_DATA_INV);

            /*" -2301- MOVE WS-DIA-INV TO WS-DIA-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_AUX.WS_DIA_AUX);

            /*" -2302- MOVE WS-MES-INV TO WS-MES-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_AUX.WS_MES_AUX);

            /*" -2303- MOVE WS-ANO-INV TO WS-ANO-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_AUX.WS_ANO_AUX);

            /*" -2305- MOVE '/' TO WS-AUX-B1 WS-AUX-B2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B1, AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B2);

            /*" -2307- MOVE WS-DATA-AUX TO CABU-DT-NASCIMENTO. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_NASCIMENTO);

            /*" -2308- MOVE SVA-DTQUIT TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DTQUIT, AREA_DE_WORK.WS_DATA_INV);

            /*" -2309- MOVE WS-DIA-INV TO WS-DIA-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_AUX.WS_DIA_AUX);

            /*" -2310- MOVE WS-MES-INV TO WS-MES-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_AUX.WS_MES_AUX);

            /*" -2311- MOVE WS-ANO-INV TO WS-ANO-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_AUX.WS_ANO_AUX);

            /*" -2313- MOVE '/' TO WS-AUX-B1 WS-AUX-B2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B1, AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B2);

            /*" -2315- MOVE WS-DATA-AUX TO CABU-DT-QUITACAO. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_QUITACAO);

            /*" -2316- IF SVA-NUMCARTAO NOT EQUAL ZEROS */

            if (REG_SBI7028B.SVA_NUMCARTAO != 00)
            {

                /*" -2317- MOVE SVA-NUMCARTAO TO CABU-CARTAO-CREDITO */
                _.Move(REG_SBI7028B.SVA_NUMCARTAO, AREA_DE_WORK.CABU.CABU_CARTAO_CREDITO);

                /*" -2318- MOVE SPACES TO CABU-DES-COBRANCA */
                _.Move("", AREA_DE_WORK.CABU.CABU_DES_COBRANCA);

                /*" -2319- END-IF. */
            }


            /*" -2320- IF SVA-NUMCTADEB NOT EQUAL ZEROS */

            if (REG_SBI7028B.SVA_NUMCTADEB != 00)
            {

                /*" -2321- MOVE SPACES TO CABU-DES-COBRANCA */
                _.Move("", AREA_DE_WORK.CABU.CABU_DES_COBRANCA);

                /*" -2322- MOVE 0104 TO CABU-NUM-BANCO */
                _.Move(0104, AREA_DE_WORK.CABU.CABU_NUM_BANCO);

                /*" -2323- MOVE SVA-OPRCTADEB TO CABU-OPER-BANCO */
                _.Move(REG_SBI7028B.SVA_OPRCTADEB, AREA_DE_WORK.CABU.CABU_OPER_BANCO);

                /*" -2324- MOVE SVA-AGECTADEB TO CABU-NUM-AGENCIA */
                _.Move(REG_SBI7028B.SVA_AGECTADEB, AREA_DE_WORK.CABU.CABU_NUM_AGENCIA);

                /*" -2325- MOVE ZEROS TO CABU-DIG-AGENCIA */
                _.Move(0, AREA_DE_WORK.CABU.CABU_DIG_AGENCIA);

                /*" -2326- MOVE SVA-NUMCTADEB TO CABU-NUM-CONTA */
                _.Move(REG_SBI7028B.SVA_NUMCTADEB, AREA_DE_WORK.CABU.CABU_NUM_CONTA);

                /*" -2327- MOVE SVA-DIGCTADEB TO CABU-DIG-CONTA */
                _.Move(REG_SBI7028B.SVA_DIGCTADEB, AREA_DE_WORK.CABU.CABU_DIG_CONTA);

                /*" -2328- MOVE '-' TO CABU-T1 */
                _.Move("-", AREA_DE_WORK.CABU.CABU_T1);

                /*" -2330- END-IF. */
            }


            /*" -2331- MOVE SVA-SUSEP TO CABU-COD-SUSEP. */
            _.Move(REG_SBI7028B.SVA_SUSEP, AREA_DE_WORK.CABU.CABU_COD_SUSEP);

            /*" -2332- MOVE 'MENSAL' TO CABU-PERI-PAGTO. */
            _.Move("MENSAL", AREA_DE_WORK.CABU.CABU_PERI_PAGTO);

            /*" -2333- MOVE SVA-VLPREMIO TO CABU-VL-PRM-PAGO. */
            _.Move(REG_SBI7028B.SVA_VLPREMIO, AREA_DE_WORK.CABU.CABU_VL_PRM_PAGO);

            /*" -2334- IF SVA-DIA-DEBITO GREATER ZEROS */

            if (REG_SBI7028B.SVA_DIA_DEBITO > 00)
            {

                /*" -2335- MOVE SVA-DIA-DEBITO TO CABU-DIA-VENCTO */
                _.Move(REG_SBI7028B.SVA_DIA_DEBITO, AREA_DE_WORK.CABU.CABU_DIA_VENCTO);

                /*" -2336- ELSE */
            }
            else
            {


                /*" -2337- MOVE '**' TO CABU-DIA-DEB-ALFA */
                _.Move("**", AREA_DE_WORK.CABU.CABU_DIA_VENTO_R.CABU_DIA_DEB_ALFA);

                /*" -2339- END-IF. */
            }


            /*" -2340- IF SVA-COD-PRODUTO EQUAL 3710 OR 3711 */

            if (REG_SBI7028B.SVA_COD_PRODUTO.In("3710", "3711"))
            {

                /*" -2341- MOVE WS-DESCRICAO-CARENCIA TO CABU-VL-CARENCIAS */
                _.Move(WS_DESCRICAO_CARENCIA, AREA_DE_WORK.CABU.CABU_VL_CARENCIAS);

                /*" -2342- ELSE */
            }
            else
            {


                /*" -2343- MOVE SPACES TO CABU-VL-CARENCIAS */
                _.Move("", AREA_DE_WORK.CABU.CABU_VL_CARENCIAS);

                /*" -2345- END-IF. */
            }


            /*" -2346- MOVE SVA-FORMAPAG TO CABU-FORMA-PAG. */
            _.Move(REG_SBI7028B.SVA_FORMAPAG, AREA_DE_WORK.CABU.CABU_FORMA_PAG);

            /*" -2347- MOVE SVA-VLIOF TO CABU-VL-IOF. */
            _.Move(REG_SBI7028B.SVA_VLIOF, AREA_DE_WORK.CABU.CABU_VL_IOF);

            /*" -2349- MOVE SVA-VLPREMIO-LIQ TO CABU-VL-PRM-LIQUIDO. */
            _.Move(REG_SBI7028B.SVA_VLPREMIO_LIQ, AREA_DE_WORK.CABU.CABU_VL_PRM_LIQUIDO);

            /*" -2351- MOVE 01 TO IND-BEN. */
            _.Move(01, IND_BEN);

            /*" -2352- PERFORM UNTIL IND-BEN > 12 */

            while (!(IND_BEN > 12))
            {

                /*" -2353- MOVE SPACES TO CABU-NOME-BENEFIC (IND-BEN) */
                _.Move("", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[IND_BEN].CABU_NOME_BENEFIC);

                /*" -2354- MOVE '|' TO CABU-TRACO1-BENEFIC (IND-BEN) */
                _.Move("|", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[IND_BEN].CABU_TRACO1_BENEFIC);

                /*" -2355- MOVE SPACES TO CABU-GRAU-PARENTESCO (IND-BEN) */
                _.Move("", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[IND_BEN].CABU_GRAU_PARENTESCO);

                /*" -2356- MOVE '|' TO CABU-TRACO2-BENEFIC (IND-BEN) */
                _.Move("|", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[IND_BEN].CABU_TRACO2_BENEFIC);

                /*" -2357- MOVE 0,00 TO CABU-PCT-PART-BENEFIC (IND-BEN) */
                _.Move(0.00, AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[IND_BEN].CABU_PCT_PART_BENEFIC);

                /*" -2358- MOVE '|' TO CABU-TRACO3-BENEFIC (IND-BEN) */
                _.Move("|", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[IND_BEN].CABU_TRACO3_BENEFIC);

                /*" -2359- MOVE '|' TO CABU-TRACO3-BENEFIC (IND-BEN) */
                _.Move("|", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[IND_BEN].CABU_TRACO3_BENEFIC);

                /*" -2360- ADD 1 TO IND-BEN */
                IND_BEN.Value = IND_BEN + 1;

                /*" -2362- END-PERFORM. */
            }

            /*" -2363- MOVE 'HERDEIROS LEGAIS' TO CABU-NOME-BENEFIC (1). */
            _.Move("HERDEIROS LEGAIS", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[1].CABU_NOME_BENEFIC);

            /*" -2364- MOVE '|' TO CABU-TRACO1-BENEFIC (1). */
            _.Move("|", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[1].CABU_TRACO1_BENEFIC);

            /*" -2365- MOVE SPACES TO CABU-GRAU-PARENTESCO (1). */
            _.Move("", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[1].CABU_GRAU_PARENTESCO);

            /*" -2366- MOVE '|' TO CABU-TRACO2-BENEFIC (1). */
            _.Move("|", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[1].CABU_TRACO2_BENEFIC);

            /*" -2367- MOVE 100,00 TO CABU-PCT-PART-BENEFIC (1). */
            _.Move(100.00, AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[1].CABU_PCT_PART_BENEFIC);

            /*" -2376- MOVE '|' TO CABU-TRACO3-BENEFIC (1). */
            _.Move("|", AREA_DE_WORK.CABU.CABU_BENEFICIARIO.CABU_BENEFIC_OCC[1].CABU_TRACO3_BENEFIC);

            /*" -2378- PERFORM R2400-00-SELECT-APOLICOB. */

            R2400_00_SELECT_APOLICOB_SECTION();

            /*" -2383- MOVE ZEROS TO W77-IND. */
            _.Move(0, W77_IND);

            /*" -2384- IF APOLICOB-IMP-SEGURADA-AP > ZEROS */

            if (APOLICOB_IMP_SEGURADA_AP > 00)
            {

                /*" -2387- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -2388- MOVE 'MORTE ACIDENTAL ' TO CABU-DES-COBERT(W77-IND) */
                _.Move("MORTE ACIDENTAL ", AREA_DE_WORK.CABU.CABU_COBERTURAS.CABU_COBER_OCC[W77_IND].CABU_DES_COBERT);

                /*" -2389- MOVE APOLICOB-IMP-SEGURADA-AP TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_AP, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -2421- MOVE WS-VALOR TO CABU-VL-COBERT (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.CABU.CABU_COBERTURAS.CABU_COBER_OCC[W77_IND].CABU_VL_COBERT);

                /*" -2426- MOVE ZEROS TO W77-IND. */
                _.Move(0, W77_IND);
            }


            /*" -2427- MOVE SPACES TO WFIM-VG033. */
            _.Move("", AREA_DE_WORK.WFIM_VG033);

            /*" -2428- MOVE SPACES TO CABU-BENEFICIOS. */
            _.Move("", AREA_DE_WORK.CABU.CABU_BENEFICIOS);

            /*" -2429- MOVE SVA-COD-PRODUTO TO VGCOBSUB-COD-SUBGRUPO. */
            _.Move(REG_SBI7028B.SVA_COD_PRODUTO, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_SUBGRUPO);

            /*" -2429- PERFORM R2210-00-DECLARE-VG033. */

            R2210_00_DECLARE_VG033_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2200_10_LOOP_ACESSORIO */

            R2200_10_LOOP_ACESSORIO();

        }

        [StopWatch]
        /*" R2200-10-LOOP-ACESSORIO */
        private void R2200_10_LOOP_ACESSORIO(bool isPerform = false)
        {
            /*" -2435- ADD 1 TO W77-IND. */
            W77_IND.Value = W77_IND + 1;

            /*" -2436- IF (W77-IND GREATER 12) */

            if ((W77_IND > 12))
            {

                /*" -2437- GO TO R2200-GRAVA-TP5 */

                R2200_GRAVA_TP5(); //GOTO
                return;

                /*" -2439- END-IF. */
            }


            /*" -2440- IF (WFIM-VG033 EQUAL SPACES) */

            if ((AREA_DE_WORK.WFIM_VG033.IsEmpty()))
            {

                /*" -2441- PERFORM R2211-00-FETCH-VG033 */

                R2211_00_FETCH_VG033_SECTION();

                /*" -2443- END-IF */
            }


            /*" -2444- IF (WFIM-VG033 NOT EQUAL SPACES) */

            if ((!AREA_DE_WORK.WFIM_VG033.IsEmpty()))
            {

                /*" -2445- MOVE SPACES TO CABU-DES-BENEFIC(W77-IND) */
                _.Move("", AREA_DE_WORK.CABU.CABU_BENEFICIOS.CABU_BENEF_OCC[W77_IND].CABU_DES_BENEFIC);

                /*" -2446- MOVE '|' TO CABU-TRACO-BENEF(W77-IND) */
                _.Move("|", AREA_DE_WORK.CABU.CABU_BENEFICIOS.CABU_BENEF_OCC[W77_IND].CABU_TRACO_BENEF);

                /*" -2447- ELSE */
            }
            else
            {


                /*" -2448- MOVE VG033-DES-ACESSORIO TO CABU-DES-BENEFIC(W77-IND) */
                _.Move(VG033.DCLVG_ACESSORIO.VG033_DES_ACESSORIO, AREA_DE_WORK.CABU.CABU_BENEFICIOS.CABU_BENEF_OCC[W77_IND].CABU_DES_BENEFIC);

                /*" -2449- MOVE '|' TO CABU-TRACO-BENEF(W77-IND) */
                _.Move("|", AREA_DE_WORK.CABU.CABU_BENEFICIOS.CABU_BENEF_OCC[W77_IND].CABU_TRACO_BENEF);

                /*" -2451- END-IF. */
            }


            /*" -2455- GO TO R2200-10-LOOP-ACESSORIO. */
            new Task(() => R2200_10_LOOP_ACESSORIO()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...


        }

        [StopWatch]
        /*" R2200-GRAVA-TP5 */
        private void R2200_GRAVA_TP5(bool isPerform = false)
        {
            /*" -2505- MOVE SVA-BILHETE TO WHOST-BILHETE. */
            _.Move(REG_SBI7028B.SVA_BILHETE, WHOST_BILHETE);

            /*" -2514- IF SVA-COD-PRODUTO EQUAL 3710 OR 3711 OR 8114 OR 8115 OR 8116 OR 8117 OR 8118 OR 8119 OR 8120 OR 8121 OR 8122 OR 8123 OR 8124 OR 8125 OR 8132 OR JVPRD8114 OR JVPRD8119 OR JVPRD8115 OR JVPRD8120 OR JVPRD8116 OR JVPRD8121 OR JVPRD8117 OR JVPRD8122 OR JVPRD8118 OR JVPRD8123 */

            if (REG_SBI7028B.SVA_COD_PRODUTO.In("3710", "3711", "8114", "8115", "8116", "8117", "8118", "8119", "8120", "8121", "8122", "8123", "8124", "8125", "8132", JVBKINCL.JV_PRODUTOS.JVPRD8114.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8119.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8115.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8120.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8116.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8121.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8117.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8122.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8118.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8123.ToString()))
            {

                /*" -2515- PERFORM R2650-LER-CAP */

                R2650_LER_CAP_SECTION();

                /*" -2516- ELSE */
            }
            else
            {


                /*" -2517- PERFORM R2600-00-DECLARE-V0TITFDCAP */

                R2600_00_DECLARE_V0TITFDCAP_SECTION();

                /*" -2518- PERFORM R2610-00-FETCH-V0TITFDCAP */

                R2610_00_FETCH_V0TITFDCAP_SECTION();

                /*" -2520- PERFORM R2620-00-LE-NRSORTEIO UNTIL WFIM-V0TITFDCAP EQUAL 'S' */

                while (!(AREA_DE_WORK.WFIM_V0TITFDCAP == "S"))
                {

                    R2620_00_LE_NRSORTEIO_SECTION();
                }

                /*" -2527- END-IF. */
            }


            /*" -2529- IF W78-IND EQUAL ZEROS */

            if (W78_IND == 00)
            {

                /*" -2541- IF SVA-COD-PRODUTO NOT EQUAL 8114 AND 8115 AND 8116 AND 8117 AND 8118 AND 8119 AND 8120 AND 8121 AND 8122 AND 8123 AND 8124 AND 8125 AND 8132 AND 3710 AND 3711 AND JVPRD8114 AND JVPRD8119 AND JVPRD8115 AND JVPRD8120 AND JVPRD8116 AND JVPRD8121 AND JVPRD8117 AND JVPRD8122 AND JVPRD8118 AND JVPRD8123 */

                if (!REG_SBI7028B.SVA_COD_PRODUTO.In("8114", "8115", "8116", "8117", "8118", "8119", "8120", "8121", "8122", "8123", "8124", "8125", "8132", "3710", "3711", JVBKINCL.JV_PRODUTOS.JVPRD8114.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8119.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8115.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8120.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8116.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8121.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8117.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8122.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8118.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8123.ToString()))
                {

                    /*" -2544- MOVE 'ENCAMINHADO EM DOCUMENTO POSTERIOR APOS O PAGAMENTO DA 3� PARCELA DO SEGURO' TO CABU-DS-SORTEIO */
                    _.Move("ENCAMINHADO EM DOCUMENTO POSTERIOR APOS O PAGAMENTO DA 3� PARCELA DO SEGURO", AREA_DE_WORK.CABU.CABU_DS_SORTEIO);

                    /*" -2545- END-IF */
                }


                /*" -2549- END-IF. */
            }


            /*" -2550- IF SVA-COD-PRODUTO EQUAL 8124 OR 8132 */

            if (REG_SBI7028B.SVA_COD_PRODUTO.In("8124", "8132"))
            {

                /*" -2551- PERFORM R2440-00-CARTEIRA */

                R2440_00_CARTEIRA_SECTION();

                /*" -2553- END-IF. */
            }


            /*" -2554- MOVE 'N' TO WHOST-UNIC */
            _.Move("N", WHOST_UNIC);

            /*" -2556- PERFORM R3500-00-PESQUISA-FORMULARIO */

            R3500_00_PESQUISA_FORMULARIO_SECTION();

            /*" -2557- ADD 1 TO WS-SQ-ARQUIVO. */
            AREA_DE_WORK.WS_SQ_ARQUIVO.Value = AREA_DE_WORK.WS_SQ_ARQUIVO + 1;

            /*" -2558- MOVE WS-SQ-ARQUIVO TO CABU-SQ-ARQUIVO. */
            _.Move(AREA_DE_WORK.WS_SQ_ARQUIVO, AREA_DE_WORK.CABU.CABU_SQ_ARQUIVO);

            /*" -2560- WRITE RBI7028B-RECORD FROM CABU. */
            _.Move(AREA_DE_WORK.CABU.GetMoveValues(), RBI7028B_RECORD);

            RBI7028B.Write(RBI7028B_RECORD.GetMoveValues().ToString());

            /*" -2561- IF WHOST-UNIC EQUAL 'S' */

            if (WHOST_UNIC == "S")
            {

                /*" -2563- IF RELATORI-TIPO-CORRECAO EQUAL 'I' AND CABU-EMAIL EQUAL SPACES */

                if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "I" && AREA_DE_WORK.CABU.CABU_EMAIL.IsEmpty())
                {

                    /*" -2564- WRITE RBI7028I-RECORD FROM CABU */
                    _.Move(AREA_DE_WORK.CABU.GetMoveValues(), RBI7028I_RECORD);

                    RBI7028I.Write(RBI7028I_RECORD.GetMoveValues().ToString());

                    /*" -2565- END-IF */
                }


                /*" -2567- IF RELATORI-TIPO-CORRECAO EQUAL 'P' AND CABU-EMAIL EQUAL SPACES */

                if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "P" && AREA_DE_WORK.CABU.CABU_EMAIL.IsEmpty())
                {

                    /*" -2568- WRITE RBI7028P-RECORD FROM CABU */
                    _.Move(AREA_DE_WORK.CABU.GetMoveValues(), RBI7028P_RECORD);

                    RBI7028P.Write(RBI7028P_RECORD.GetMoveValues().ToString());

                    /*" -2569- END-IF */
                }


                /*" -2571- IF RELATORI-NUM-APOL-LIDER NOT EQUAL SPACES AND CABU-EMAIL NOT EQUAL SPACES */

                if (!RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.IsEmpty() && !AREA_DE_WORK.CABU.CABU_EMAIL.IsEmpty())
                {

                    /*" -2572- INSPECT CABU REPLACING ALL '|' BY ';' */
                    AREA_DE_WORK.CABU.Replace("|", ";");

                    /*" -2573- WRITE RBI7028H-RECORD FROM CABU */
                    _.Move(AREA_DE_WORK.CABU.GetMoveValues(), RBI7028H_RECORD);

                    RBI7028H.Write(RBI7028H_RECORD.GetMoveValues().ToString());

                    /*" -2574- INSPECT CABU REPLACING ALL ';' BY '|' */
                    AREA_DE_WORK.CABU.Replace(";", "|");

                    /*" -2575- END-IF */
                }


                /*" -2579- END-IF. */
            }


            /*" -2580- IF WS-FORMULARIO EQUAL 'VAKS28AP' */

            if (WS_FORMULARIO == "VAKS28AP")
            {

                /*" -2581- ADD 1 TO WS-QTD-VAKS28AP */
                AREA_DE_WORK.WS_QTD_VAKS28AP.Value = AREA_DE_WORK.WS_QTD_VAKS28AP + 1;

                /*" -2582- END-IF. */
            }


            /*" -2583- IF WS-FORMULARIO EQUAL 'VAKS28JV' */

            if (WS_FORMULARIO == "VAKS28JV")
            {

                /*" -2584- ADD 1 TO WS-QTD-VAKS28JV */
                AREA_DE_WORK.WS_QTD_VAKS28JV.Value = AREA_DE_WORK.WS_QTD_VAKS28JV + 1;

                /*" -2585- END-IF. */
            }


            /*" -2586- IF WS-FORMULARIO EQUAL 'VAKS28RD' */

            if (WS_FORMULARIO == "VAKS28RD")
            {

                /*" -2587- ADD 1 TO WS-QTD-VAKS28RD */
                AREA_DE_WORK.WS_QTD_VAKS28RD.Value = AREA_DE_WORK.WS_QTD_VAKS28RD + 1;

                /*" -2588- END-IF. */
            }


            /*" -2589- IF WS-FORMULARIO EQUAL 'VAKS28PO' */

            if (WS_FORMULARIO == "VAKS28PO")
            {

                /*" -2590- ADD 1 TO WS-QTD-VAKS28PO */
                AREA_DE_WORK.WS_QTD_VAKS28PO.Value = AREA_DE_WORK.WS_QTD_VAKS28PO + 1;

                /*" -2592- END-IF. */
            }


            /*" -2598- ADD 1 TO AC-IMPRESSOS. */
            AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

            /*" -2600- INITIALIZE CABU. */
            _.Initialize(
                AREA_DE_WORK.CABU
            );

            /*" -2602- MOVE SVA-CODRELAT TO WHOST-CODRELAT. */
            _.Move(REG_SBI7028B.SVA_CODRELAT, WHOST_CODRELAT);

            /*" -2602- PERFORM R2500-00-UPDATE-RELATORI. */

            R2500_00_UPDATE_RELATORI_SECTION();

        }

        [StopWatch]
        /*" R2200-40-NEXT */
        private void R2200_40_NEXT(bool isPerform = false)
        {
            /*" -2608- PERFORM R2100-00-LE-SORT. */

            R2100_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-DECLARE-VG033-SECTION */
        private void R2210_00_DECLARE_VG033_SECTION()
        {
            /*" -2621- MOVE '2210' TO WNR-EXEC-SQL. */
            _.Move("2210", WABEND.WNR_EXEC_SQL);

            /*" -2623- MOVE SVA-NUM-APOLICE-FORM TO WHOST-NRAPOLICE */
            _.Move(REG_SBI7028B.SVA_NUM_APOLICE_FORM, WHOST_NRAPOLICE);

            /*" -2633- PERFORM R2210_00_DECLARE_VG033_DB_DECLARE_1 */

            R2210_00_DECLARE_VG033_DB_DECLARE_1();

            /*" -2635- PERFORM R2210_00_DECLARE_VG033_DB_OPEN_1 */

            R2210_00_DECLARE_VG033_DB_OPEN_1();

            /*" -2638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2639- DISPLAY 'R2210 ERRO OPEN CVG033' */
                _.Display($"R2210 ERRO OPEN CVG033");

                /*" -2640- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2640- END-IF. */
            }


        }

        [StopWatch]
        /*" R2210-00-DECLARE-VG033-DB-OPEN-1 */
        public void R2210_00_DECLARE_VG033_DB_OPEN_1()
        {
            /*" -2635- EXEC SQL OPEN CVG033 END-EXEC. */

            CVG033.Open();

        }

        [StopWatch]
        /*" R2450-00-BENEFICIARIOS-DB-DECLARE-1 */
        public void R2450_00_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -2920- EXEC SQL DECLARE V0BENEF CURSOR FOR SELECT NOME_BENEFICIARIO, NUM_CARTEIRINHA FROM SEGUROS.BENEFICIARIOS WHERE NUM_CERTIFICADO = :BENEFICI-NUM-CERTIFICADO AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */
            V0BENEF = new BI7028B_V0BENEF(true);
            string GetQuery_V0BENEF()
            {
                var query = @$"SELECT NOME_BENEFICIARIO
							, 
							NUM_CARTEIRINHA 
							FROM SEGUROS.BENEFICIARIOS 
							WHERE NUM_CERTIFICADO = '{BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO}' 
							AND DATA_TERVIGENCIA IN ( '1999-12-31'
							, '9999-12-31' )";

                return query;
            }
            V0BENEF.GetQueryEvent += GetQuery_V0BENEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2211-00-FETCH-VG033-SECTION */
        private void R2211_00_FETCH_VG033_SECTION()
        {
            /*" -2652- MOVE '2211' TO WNR-EXEC-SQL. */
            _.Move("2211", WABEND.WNR_EXEC_SQL);

            /*" -2656- PERFORM R2211_00_FETCH_VG033_DB_FETCH_1 */

            R2211_00_FETCH_VG033_DB_FETCH_1();

            /*" -2659- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2660- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2661- MOVE 'S' TO WFIM-VG033 */
                    _.Move("S", AREA_DE_WORK.WFIM_VG033);

                    /*" -2661- PERFORM R2211_00_FETCH_VG033_DB_CLOSE_1 */

                    R2211_00_FETCH_VG033_DB_CLOSE_1();

                    /*" -2663- GO TO R2211-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2211_99_SAIDA*/ //GOTO
                    return;

                    /*" -2664- ELSE */
                }
                else
                {


                    /*" -2668- DISPLAY 'R2211 ERRO FETCH CVG033. ' 'APOLICE: ' WHOST-NRAPOLICE 'SUBGRUPO: ' VGCOBSUB-COD-SUBGRUPO 'SQLCODE: ' SQLCODE */

                    $"R2211 ERRO FETCH CVG033. APOLICE: {WHOST_NRAPOLICE}SUBGRUPO: {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_SUBGRUPO}SQLCODE: {DB.SQLCODE}"
                    .Display();

                    /*" -2668- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R2211-00-FETCH-VG033-DB-FETCH-1 */
        public void R2211_00_FETCH_VG033_DB_FETCH_1()
        {
            /*" -2656- EXEC SQL FETCH CVG033 INTO :VGCOBSUB-COD-COBERTURA , :VG033-DES-ACESSORIO END-EXEC. */

            if (CVG033.Fetch())
            {
                _.Move(CVG033.VGCOBSUB_COD_COBERTURA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);
                _.Move(CVG033.VG033_DES_ACESSORIO, VG033.DCLVG_ACESSORIO.VG033_DES_ACESSORIO);
            }

        }

        [StopWatch]
        /*" R2211-00-FETCH-VG033-DB-CLOSE-1 */
        public void R2211_00_FETCH_VG033_DB_CLOSE_1()
        {
            /*" -2661- EXEC SQL CLOSE CVG033 END-EXEC */

            CVG033.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2211_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-SELECT-ESTIP-SECTION */
        private void R2250_00_SELECT_ESTIP_SECTION()
        {
            /*" -2679- MOVE '2250' TO WNR-EXEC-SQL. */
            _.Move("2250", WABEND.WNR_EXEC_SQL);

            /*" -2690- PERFORM R2250_00_SELECT_ESTIP_DB_SELECT_1 */

            R2250_00_SELECT_ESTIP_DB_SELECT_1();

            /*" -2693- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2694- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2695- MOVE SVA-NOME-RAZAO TO CLIENTES-NOME-RAZAO */
                    _.Move(REG_SBI7028B.SVA_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -2696- MOVE SVA-CPF TO CLIENTES-CGCCPF */
                    _.Move(REG_SBI7028B.SVA_CPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                    /*" -2697- MOVE 'F' TO CLIENTES-TIPO-PESSOA */
                    _.Move("F", CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

                    /*" -2698- ELSE */
                }
                else
                {


                    /*" -2699- DISPLAY 'R2250-PROBLEMAS NO ACESSO A APOLICE' */
                    _.Display($"R2250-PROBLEMAS NO ACESSO A APOLICE");

                    /*" -2700- DISPLAY 'NUM_APOLICE - ' WS-NUM-APOLICE ' ' */

                    $"NUM_APOLICE - {WS_NUM_APOLICE} "
                    .Display();

                    /*" -2701- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2702- END-IF */
                }


                /*" -2702- END-IF. */
            }


        }

        [StopWatch]
        /*" R2250-00-SELECT-ESTIP-DB-SELECT-1 */
        public void R2250_00_SELECT_ESTIP_DB_SELECT_1()
        {
            /*" -2690- EXEC SQL SELECT B.NOME_RAZAO, B.CGCCPF, B.TIPO_PESSOA INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-TIPO-PESSOA FROM SEGUROS.APOLICES A, SEGUROS.CLIENTES B WHERE A.NUM_APOLICE = :WS-NUM-APOLICE AND B.COD_CLIENTE = A.COD_CLIENTE END-EXEC. */

            var r2250_00_SELECT_ESTIP_DB_SELECT_1_Query1 = new R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1()
            {
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1.Execute(r2250_00_SELECT_ESTIP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-CARREGA-COBMENVG-SECTION */
        private void R2300_00_CARREGA_COBMENVG_SECTION()
        {
            /*" -2714- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -2721- INITIALIZE DCLCOBRANCA-MENS-VGAP. */
            _.Initialize(
                COBMENVG.DCLCOBRANCA_MENS_VGAP
            );

            /*" -2722- MOVE SVA-NUM-APOLICE-FORM TO WHOST-NRAPOLICE */
            _.Move(REG_SBI7028B.SVA_NUM_APOLICE_FORM, WHOST_NRAPOLICE);

            /*" -2724- MOVE SVA-COD-PRODUTO TO COBMENVG-CODSUBES. */
            _.Move(REG_SBI7028B.SVA_COD_PRODUTO, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES);

            /*" -2732- PERFORM R2300_00_CARREGA_COBMENVG_DB_SELECT_1 */

            R2300_00_CARREGA_COBMENVG_DB_SELECT_1();

            /*" -2735- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2736- DISPLAY 'BI7028B - PROBLEMAS NA COBRANCA_MENS_VGAP ' */
                _.Display($"BI7028B - PROBLEMAS NA COBRANCA_MENS_VGAP ");

                /*" -2736- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-CARREGA-COBMENVG-DB-SELECT-1 */
        public void R2300_00_CARREGA_COBMENVG_DB_SELECT_1()
        {
            /*" -2732- EXEC SQL SELECT JDE INTO :COBMENVG-JDE FROM SEGUROS.COBRANCA_MENS_VGAP WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND CODSUBES = :COBMENVG-CODSUBES AND IDFORM = 'A4' AND COD_OPERACAO = 3 END-EXEC. */

            var r2300_00_CARREGA_COBMENVG_DB_SELECT_1_Query1 = new R2300_00_CARREGA_COBMENVG_DB_SELECT_1_Query1()
            {
                COBMENVG_CODSUBES = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2300_00_CARREGA_COBMENVG_DB_SELECT_1_Query1.Execute(r2300_00_CARREGA_COBMENVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBMENVG_JDE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-COBMENVG-SEGUNDA-VIA-SECTION */
        private void R2350_00_COBMENVG_SEGUNDA_VIA_SECTION()
        {
            /*" -2748- MOVE '2350' TO WNR-EXEC-SQL. */
            _.Move("2350", WABEND.WNR_EXEC_SQL);

            /*" -2759- INITIALIZE DCLCOBRANCA-MENS-VGAP. */
            _.Initialize(
                COBMENVG.DCLCOBRANCA_MENS_VGAP
            );

            /*" -2760- MOVE SVA-NUM-APOLICE-FORM TO WHOST-NRAPOLICE */
            _.Move(REG_SBI7028B.SVA_NUM_APOLICE_FORM, WHOST_NRAPOLICE);

            /*" -2761- MOVE SVA-COD-PRODUTO TO COBMENVG-CODSUBES */
            _.Move(REG_SBI7028B.SVA_COD_PRODUTO, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES);

            /*" -2763- MOVE 'S' TO WS-TEM-SEG-VIA. */
            _.Move("S", AREA_DE_WORK.WS_TEM_SEG_VIA);

            /*" -2771- PERFORM R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1 */

            R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1();

            /*" -2774- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2775- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2776- DISPLAY 'BI7028B - PROBLEMAS NA COBRANCA_MENS_VGAP ' */
                    _.Display($"BI7028B - PROBLEMAS NA COBRANCA_MENS_VGAP ");

                    /*" -2777- DISPLAY 'ROTINA 2350' */
                    _.Display($"ROTINA 2350");

                    /*" -2778- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2779- ELSE */
                }
                else
                {


                    /*" -2780- MOVE 'N' TO WS-TEM-SEG-VIA */
                    _.Move("N", AREA_DE_WORK.WS_TEM_SEG_VIA);

                    /*" -2781- END-IF */
                }


                /*" -2781- END-IF. */
            }


        }

        [StopWatch]
        /*" R2350-00-COBMENVG-SEGUNDA-VIA-DB-SELECT-1 */
        public void R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1()
        {
            /*" -2771- EXEC SQL SELECT JDE INTO :COBMENVG-JDE FROM SEGUROS.COBRANCA_MENS_VGAP WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND CODSUBES = :COBMENVG-CODSUBES AND IDFORM = 'A4' AND COD_OPERACAO = 4 END-EXEC. */

            var r2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1 = new R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1()
            {
                COBMENVG_CODSUBES = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1.Execute(r2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBMENVG_JDE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-SELECT-APOLICOB-SECTION */
        private void R2400_00_SELECT_APOLICOB_SECTION()
        {
            /*" -2793- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -2795- INITIALIZE DCLAPOLICE-COBERTURAS. */
            _.Initialize(
                APOLICOB.DCLAPOLICE_COBERTURAS
            );

            /*" -2812- PERFORM R2400_00_SELECT_APOLICOB_DB_SELECT_1 */

            R2400_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -2815- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2816- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2820- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-AP APOLICOB-PRM-TARIFARIO-AP APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_AP, APOLICOB_PRM_TARIFARIO_AP, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -2821- ELSE */
                }
                else
                {


                    /*" -2823- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81 ' ' ' WS-NUM-APOLICE ' ' */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81  {WS_NUM_APOLICE} "
                    .Display();

                    /*" -2824- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -2825- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2826- END-IF */
                }


                /*" -2826- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R2400_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -2812- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-AP, :APOLICOB-PRM-TARIFARIO-AP, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WS-NUM-APOLICE AND NUM_ENDOSSO = 1 AND NUM_ITEM = 0 AND OCORR_HISTORICO IN (0,1) AND RAMO_COBERTURA IN (81, 82, 37) AND MODALI_COBERTURA = 0 ORDER BY TIMESTAMP DESC FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_AP, APOLICOB_IMP_SEGURADA_AP);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_AP, APOLICOB_PRM_TARIFARIO_AP);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2440-00-CARTEIRA-SECTION */
        private void R2440_00_CARTEIRA_SECTION()
        {
            /*" -2840- MOVE '2440' TO WNR-EXEC-SQL. */
            _.Move("2440", WABEND.WNR_EXEC_SQL);

            /*" -2842- MOVE SVA-NOME-RAZAO TO CABU-NOM-SEGURADO7. */
            _.Move(REG_SBI7028B.SVA_NOME_RAZAO, AREA_DE_WORK.CABU.CABU_NOM_SEGURADO7);

            /*" -2843- MOVE SVA-DTINIVIG TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -2844- MOVE WS-DIA-INV TO WS-DIA-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_AUX.WS_DIA_AUX);

            /*" -2845- MOVE WS-MES-INV TO WS-MES-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_AUX.WS_MES_AUX);

            /*" -2846- MOVE WS-ANO-INV TO WS-ANO-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_AUX.WS_ANO_AUX);

            /*" -2848- MOVE '/' TO WS-AUX-B1 WS-AUX-B2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B1, AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B2);

            /*" -2850- MOVE WS-DATA-AUX TO CABU-DT-ADESAO. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_ADESAO);

            /*" -2851- MOVE SVA-DTTERVIG TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -2852- MOVE WS-DIA-INV TO WS-DIA-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_AUX.WS_DIA_AUX);

            /*" -2853- MOVE WS-MES-INV TO WS-MES-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_AUX.WS_MES_AUX);

            /*" -2854- MOVE WS-ANO-INV TO WS-ANO-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_AUX.WS_ANO_AUX);

            /*" -2857- MOVE '/' TO WS-AUX-B1 WS-AUX-B2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B1, AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B2);

            /*" -2858- MOVE SVA-CART-TITULAR TO CABU-NUM-CARTAO. */
            _.Move(REG_SBI7028B.SVA_CART_TITULAR, AREA_DE_WORK.CABU.CABU_NUM_CARTAO);

            /*" -2859- MOVE SPACES TO CABU-NOM-ASSOCIADO. */
            _.Move("", AREA_DE_WORK.CABU.CABU_NOM_ASSOCIADO);

            /*" -2860- MOVE 'A' TO CABU-COBERTURA-A. */
            _.Move("A", AREA_DE_WORK.CABU.CABU_COBERTURA_A);

            /*" -2861- MOVE 'SIM' TO CABU-PARTICIPACAO-A. */
            _.Move("SIM", AREA_DE_WORK.CABU.CABU_PARTICIPACAO_A);

            /*" -2862- IF SVA-COD-PRODUTO EQUAL 8124 */

            if (REG_SBI7028B.SVA_COD_PRODUTO == 8124)
            {

                /*" -2865- MOVE 90 TO CABU-CARENCIA-A CABU-CARENCIA-B CABU-CARENCIA-P */
                _.Move(90, AREA_DE_WORK.CABU.CABU_CARENCIA_A, AREA_DE_WORK.CABU.CABU_CARENCIA_B, AREA_DE_WORK.CABU.CABU_CARENCIA_P);

                /*" -2866- END-IF. */
            }


            /*" -2867- IF SVA-COD-PRODUTO EQUAL 8132 */

            if (REG_SBI7028B.SVA_COD_PRODUTO == 8132)
            {

                /*" -2870- MOVE 60 TO CABU-CARENCIA-A CABU-CARENCIA-B CABU-CARENCIA-P */
                _.Move(60, AREA_DE_WORK.CABU.CABU_CARENCIA_A, AREA_DE_WORK.CABU.CABU_CARENCIA_B, AREA_DE_WORK.CABU.CABU_CARENCIA_P);

                /*" -2872- END-IF. */
            }


            /*" -2873- MOVE WS-DATA-AUX TO CABU-DT-VALIDADE-A. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_VALIDADE_A);

            /*" -2874- MOVE 'B' TO CABU-COBERTURA-B. */
            _.Move("B", AREA_DE_WORK.CABU.CABU_COBERTURA_B);

            /*" -2875- MOVE 'SIM' TO CABU-PARTICIPACAO-B. */
            _.Move("SIM", AREA_DE_WORK.CABU.CABU_PARTICIPACAO_B);

            /*" -2876- MOVE WS-DATA-AUX TO CABU-DT-VALIDADE-B. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_VALIDADE_B);

            /*" -2877- MOVE 'P' TO CABU-COBERTURA-P. */
            _.Move("P", AREA_DE_WORK.CABU.CABU_COBERTURA_P);

            /*" -2878- MOVE 'SIM' TO CABU-PARTICIPACAO-P. */
            _.Move("SIM", AREA_DE_WORK.CABU.CABU_PARTICIPACAO_P);

            /*" -2880- MOVE WS-DATA-AUX TO CABU-DT-VALIDADE-P. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_VALIDADE_P);

            /*" -2881- MOVE SVA-DTTERVIG TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -2882- MOVE WS-DIA-INV TO WS-DIA-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_AUX.WS_DIA_AUX);

            /*" -2883- MOVE WS-MES-INV TO WS-MES-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_AUX.WS_MES_AUX);

            /*" -2884- MOVE WS-ANO-INV TO WS-ANO-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_AUX.WS_ANO_AUX);

            /*" -2886- MOVE '/' TO WS-AUX-B1 WS-AUX-B2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B1, AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B2);

            /*" -2891- MOVE WS-DATA-AUX TO CABU-DT-VALIDADE-P. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_VALIDADE_P);

            /*" -2893- MOVE SVA-BILHETE TO BENEFICI-NUM-CERTIFICADO. */
            _.Move(REG_SBI7028B.SVA_BILHETE, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO);

            /*" -2895- MOVE 'N' TO WFIM-BENEFICIA. */
            _.Move("N", AREA_DE_WORK.WFIM_BENEFICIA);

            /*" -2895- PERFORM R2450-00-BENEFICIARIOS. */

            R2450_00_BENEFICIARIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2440_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-BENEFICIARIOS-SECTION */
        private void R2450_00_BENEFICIARIOS_SECTION()
        {
            /*" -2907- MOVE '2450' TO WNR-EXEC-SQL. */
            _.Move("2450", WABEND.WNR_EXEC_SQL);

            /*" -2909- INITIALIZE DCLBENEFICIARIOS. */
            _.Initialize(
                BENEFICI.DCLBENEFICIARIOS
            );

            /*" -2911- MOVE SVA-BILHETE TO BENEFICI-NUM-CERTIFICADO. */
            _.Move(REG_SBI7028B.SVA_BILHETE, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO);

            /*" -2913- MOVE 'N' TO WFIM-BENEFICIA. */
            _.Move("N", AREA_DE_WORK.WFIM_BENEFICIA);

            /*" -2920- PERFORM R2450_00_BENEFICIARIOS_DB_DECLARE_1 */

            R2450_00_BENEFICIARIOS_DB_DECLARE_1();

            /*" -2922- PERFORM R2450_00_BENEFICIARIOS_DB_OPEN_1 */

            R2450_00_BENEFICIARIOS_DB_OPEN_1();

            /*" -2925- PERFORM R2460-00-FETCH-V0BENEF UNTIL WFIM-BENEFICIA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_BENEFICIA == "S"))
            {

                R2460_00_FETCH_V0BENEF_SECTION();
            }

        }

        [StopWatch]
        /*" R2450-00-BENEFICIARIOS-DB-OPEN-1 */
        public void R2450_00_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -2922- EXEC SQL OPEN V0BENEF END-EXEC. */

            V0BENEF.Open();

        }

        [StopWatch]
        /*" R2600-00-DECLARE-V0TITFDCAP-DB-DECLARE-1 */
        public void R2600_00_DECLARE_V0TITFDCAP_DB_DECLARE_1()
        {
            /*" -3048- EXEC SQL DECLARE CTITFD CURSOR FOR SELECT NRSORTEIO FROM SEGUROS.V0TITFDCAPVA WHERE NRCERTIF = :WHOST-BILHETE AND SITUACAO = '0' AND DTTERVIG >= CURRENT DATE END-EXEC. */
            CTITFD = new BI7028B_CTITFD(true);
            string GetQuery_CTITFD()
            {
                var query = @$"SELECT NRSORTEIO 
							FROM SEGUROS.V0TITFDCAPVA 
							WHERE NRCERTIF = '{WHOST_BILHETE}' 
							AND SITUACAO = '0' 
							AND DTTERVIG >= CURRENT DATE";

                return query;
            }
            CTITFD.GetQueryEvent += GetQuery_CTITFD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2460-00-FETCH-V0BENEF-SECTION */
        private void R2460_00_FETCH_V0BENEF_SECTION()
        {
            /*" -2939- MOVE '2460' TO WNR-EXEC-SQL. */
            _.Move("2460", WABEND.WNR_EXEC_SQL);

            /*" -2943- PERFORM R2460_00_FETCH_V0BENEF_DB_FETCH_1 */

            R2460_00_FETCH_V0BENEF_DB_FETCH_1();

            /*" -2946- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2947- MOVE 'S' TO WFIM-BENEFICIA */
                _.Move("S", AREA_DE_WORK.WFIM_BENEFICIA);

                /*" -2947- PERFORM R2460_00_FETCH_V0BENEF_DB_CLOSE_1 */

                R2460_00_FETCH_V0BENEF_DB_CLOSE_1();

                /*" -2952- GO TO R2460-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2460_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2954- MOVE SVA-NOME-RAZAO TO CABU-NOM-SEGURADO7 */
            _.Move(REG_SBI7028B.SVA_NOME_RAZAO, AREA_DE_WORK.CABU.CABU_NOM_SEGURADO7);

            /*" -2955- MOVE SVA-DTINIVIG TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -2956- MOVE WS-DIA-INV TO WS-DIA-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_AUX.WS_DIA_AUX);

            /*" -2957- MOVE WS-MES-INV TO WS-MES-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_AUX.WS_MES_AUX);

            /*" -2958- MOVE WS-ANO-INV TO WS-ANO-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_AUX.WS_ANO_AUX);

            /*" -2960- MOVE '/' TO WS-AUX-B1 WS-AUX-B2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B1, AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B2);

            /*" -2962- MOVE WS-DATA-AUX TO CABU-DT-ADESAO. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_ADESAO);

            /*" -2963- MOVE SVA-DTTERVIG TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -2964- MOVE WS-DIA-INV TO WS-DIA-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_AUX.WS_DIA_AUX);

            /*" -2965- MOVE WS-MES-INV TO WS-MES-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_AUX.WS_MES_AUX);

            /*" -2966- MOVE WS-ANO-INV TO WS-ANO-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_AUX.WS_ANO_AUX);

            /*" -2969- MOVE '/' TO WS-AUX-B1 WS-AUX-B2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B1, AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B2);

            /*" -2970- MOVE BENEFICI-NUM-CARTEIRINHA TO CABU-NUM-CARTAO. */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CARTEIRINHA, AREA_DE_WORK.CABU.CABU_NUM_CARTAO);

            /*" -2971- MOVE BENEFICI-NOME-BENEFICIARIO TO CABU-NOM-ASSOCIADO. */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO, AREA_DE_WORK.CABU.CABU_NOM_ASSOCIADO);

            /*" -2972- MOVE 'A' TO CABU-COBERTURA-A. */
            _.Move("A", AREA_DE_WORK.CABU.CABU_COBERTURA_A);

            /*" -2973- MOVE 'SIM' TO CABU-PARTICIPACAO-A. */
            _.Move("SIM", AREA_DE_WORK.CABU.CABU_PARTICIPACAO_A);

            /*" -2974- IF SVA-COD-PRODUTO EQUAL 8124 */

            if (REG_SBI7028B.SVA_COD_PRODUTO == 8124)
            {

                /*" -2977- MOVE 90 TO CABU-CARENCIA-A CABU-CARENCIA-B CABU-CARENCIA-P */
                _.Move(90, AREA_DE_WORK.CABU.CABU_CARENCIA_A, AREA_DE_WORK.CABU.CABU_CARENCIA_B, AREA_DE_WORK.CABU.CABU_CARENCIA_P);

                /*" -2978- END-IF. */
            }


            /*" -2979- IF SVA-COD-PRODUTO EQUAL 8132 */

            if (REG_SBI7028B.SVA_COD_PRODUTO == 8132)
            {

                /*" -2982- MOVE 60 TO CABU-CARENCIA-A CABU-CARENCIA-B CABU-CARENCIA-P */
                _.Move(60, AREA_DE_WORK.CABU.CABU_CARENCIA_A, AREA_DE_WORK.CABU.CABU_CARENCIA_B, AREA_DE_WORK.CABU.CABU_CARENCIA_P);

                /*" -2984- END-IF. */
            }


            /*" -2985- MOVE WS-DATA-AUX TO CABU-DT-VALIDADE-A. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_VALIDADE_A);

            /*" -2986- MOVE 'B' TO CABU-COBERTURA-B. */
            _.Move("B", AREA_DE_WORK.CABU.CABU_COBERTURA_B);

            /*" -2987- MOVE 'SIM' TO CABU-PARTICIPACAO-B. */
            _.Move("SIM", AREA_DE_WORK.CABU.CABU_PARTICIPACAO_B);

            /*" -2988- MOVE WS-DATA-AUX TO CABU-DT-VALIDADE-B. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_VALIDADE_B);

            /*" -2989- MOVE 'P' TO CABU-COBERTURA-P. */
            _.Move("P", AREA_DE_WORK.CABU.CABU_COBERTURA_P);

            /*" -2990- MOVE 'SIM' TO CABU-PARTICIPACAO-P. */
            _.Move("SIM", AREA_DE_WORK.CABU.CABU_PARTICIPACAO_P);

            /*" -2992- MOVE WS-DATA-AUX TO CABU-DT-VALIDADE-P. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_VALIDADE_P);

            /*" -2993- MOVE SVA-DTTERVIG TO WS-DATA-INV */
            _.Move(REG_SBI7028B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -2994- MOVE WS-DIA-INV TO WS-DIA-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_AUX.WS_DIA_AUX);

            /*" -2995- MOVE WS-MES-INV TO WS-MES-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_AUX.WS_MES_AUX);

            /*" -2996- MOVE WS-ANO-INV TO WS-ANO-AUX */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_AUX.WS_ANO_AUX);

            /*" -2998- MOVE '/' TO WS-AUX-B1 WS-AUX-B2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B1, AREA_DE_WORK.WS_DATA_AUX.WS_AUX_B2);

            /*" -2998- MOVE WS-DATA-AUX TO CABU-DT-VALIDADE-P. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX, AREA_DE_WORK.CABU.CABU_DT_VALIDADE_P);

        }

        [StopWatch]
        /*" R2460-00-FETCH-V0BENEF-DB-FETCH-1 */
        public void R2460_00_FETCH_V0BENEF_DB_FETCH_1()
        {
            /*" -2943- EXEC SQL FETCH V0BENEF INTO :BENEFICI-NOME-BENEFICIARIO, :BENEFICI-NUM-CARTEIRINHA END-EXEC. */

            if (V0BENEF.Fetch())
            {
                _.Move(V0BENEF.BENEFICI_NOME_BENEFICIARIO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO);
                _.Move(V0BENEF.BENEFICI_NUM_CARTEIRINHA, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CARTEIRINHA);
            }

        }

        [StopWatch]
        /*" R2460-00-FETCH-V0BENEF-DB-CLOSE-1 */
        public void R2460_00_FETCH_V0BENEF_DB_CLOSE_1()
        {
            /*" -2947- EXEC SQL CLOSE V0BENEF END-EXEC */

            V0BENEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2460_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-SECTION */
        private void R2500_00_UPDATE_RELATORI_SECTION()
        {
            /*" -3014- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -3023- PERFORM R2500_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R2500_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -3026- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3026- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R2500_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -3023- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_RELATORIO = :WHOST-CODRELAT AND SIT_REGISTRO = '0' AND COD_OPERACAO IN (2,3,4) AND NUM_APOLICE = :WS-NUM-APOLICE END-EXEC. */

            var r2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                WHOST_CODRELAT = WHOST_CODRELAT.ToString(),
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
            };

            R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-DECLARE-V0TITFDCAP-SECTION */
        private void R2600_00_DECLARE_V0TITFDCAP_SECTION()
        {
            /*" -3038- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WABEND.WNR_EXEC_SQL);

            /*" -3039- MOVE 'N' TO WFIM-V0TITFDCAP. */
            _.Move("N", AREA_DE_WORK.WFIM_V0TITFDCAP);

            /*" -3041- MOVE ZEROS TO W78-IND. */
            _.Move(0, W78_IND);

            /*" -3048- PERFORM R2600_00_DECLARE_V0TITFDCAP_DB_DECLARE_1 */

            R2600_00_DECLARE_V0TITFDCAP_DB_DECLARE_1();

            /*" -3050- PERFORM R2600_00_DECLARE_V0TITFDCAP_DB_OPEN_1 */

            R2600_00_DECLARE_V0TITFDCAP_DB_OPEN_1();

            /*" -3053- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3054- DISPLAY 'PROBLEMA NO OPEN CTITFC         ' */
                _.Display($"PROBLEMA NO OPEN CTITFC         ");

                /*" -3055- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3055- END-IF. */
            }


        }

        [StopWatch]
        /*" R2600-00-DECLARE-V0TITFDCAP-DB-OPEN-1 */
        public void R2600_00_DECLARE_V0TITFDCAP_DB_OPEN_1()
        {
            /*" -3050- EXEC SQL OPEN CTITFD END-EXEC. */

            CTITFD.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-FETCH-V0TITFDCAP-SECTION */
        private void R2610_00_FETCH_V0TITFDCAP_SECTION()
        {
            /*" -3066- MOVE '2610' TO WNR-EXEC-SQL. */
            _.Move("2610", WABEND.WNR_EXEC_SQL);

            /*" -3069- PERFORM R2610_00_FETCH_V0TITFDCAP_DB_FETCH_1 */

            R2610_00_FETCH_V0TITFDCAP_DB_FETCH_1();

            /*" -3072- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3073- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3074- MOVE 'S' TO WFIM-V0TITFDCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_V0TITFDCAP);

                    /*" -3074- PERFORM R2610_00_FETCH_V0TITFDCAP_DB_CLOSE_1 */

                    R2610_00_FETCH_V0TITFDCAP_DB_CLOSE_1();

                    /*" -3076- ELSE */
                }
                else
                {


                    /*" -3077- DISPLAY 'BI7028B - PROBLEMA NO FETCH CTITFC    ' */
                    _.Display($"BI7028B - PROBLEMA NO FETCH CTITFC    ");

                    /*" -3078- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3079- END-IF */
                }


                /*" -3081- END-IF. */
            }


            /*" -3082- IF SVA-QTD-DIG EQUAL ZEROS */

            if (REG_SBI7028B.SVA_QTD_DIG == 00)
            {

                /*" -3083- MOVE 'S' TO WFIM-V0TITFDCAP */
                _.Move("S", AREA_DE_WORK.WFIM_V0TITFDCAP);

                /*" -3083- PERFORM R2610_00_FETCH_V0TITFDCAP_DB_CLOSE_2 */

                R2610_00_FETCH_V0TITFDCAP_DB_CLOSE_2();

                /*" -3084- END-IF. */
            }


        }

        [StopWatch]
        /*" R2610-00-FETCH-V0TITFDCAP-DB-FETCH-1 */
        public void R2610_00_FETCH_V0TITFDCAP_DB_FETCH_1()
        {
            /*" -3069- EXEC SQL FETCH CTITFD INTO :V0TITF-NRSORTEIO END-EXEC. */

            if (CTITFD.Fetch())
            {
                _.Move(CTITFD.V0TITF_NRSORTEIO, V0TITF_NRSORTEIO);
            }

        }

        [StopWatch]
        /*" R2610-00-FETCH-V0TITFDCAP-DB-CLOSE-1 */
        public void R2610_00_FETCH_V0TITFDCAP_DB_CLOSE_1()
        {
            /*" -3074- EXEC SQL CLOSE CTITFD END-EXEC */

            CTITFD.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-FETCH-V0TITFDCAP-DB-CLOSE-2 */
        public void R2610_00_FETCH_V0TITFDCAP_DB_CLOSE_2()
        {
            /*" -3083- EXEC SQL CLOSE CTITFD END-EXEC */

            CTITFD.Close();

        }

        [StopWatch]
        /*" R2620-00-LE-NRSORTEIO-SECTION */
        private void R2620_00_LE_NRSORTEIO_SECTION()
        {
            /*" -3095- MOVE '2620' TO WNR-EXEC-SQL. */
            _.Move("2620", WABEND.WNR_EXEC_SQL);

            /*" -3098- ADD 1 TO W78-IND. */
            W78_IND.Value = W78_IND + 1;

            /*" -3100- MOVE V0TITF-NRSORTEIO TO WS-NUM-TITULO. */
            _.Move(V0TITF_NRSORTEIO, AREA_DE_WORK.WS_NUM_TITULO);

            /*" -3101- MOVE ZEROS TO W76-IND. */
            _.Move(0, W76_IND);

            /*" -3102- MOVE ZEROS TO WS-CONTADOR. */
            _.Move(0, WS_CONTADOR);

            /*" -3103- MOVE WS-NUM-TITULO-NUM TO WS-SORTEIO. */
            _.Move(AREA_DE_WORK.WS_NUM_TITULO_R.WS_NUM_TITULO_NUM, AREA_DE_WORK.WS_SORTEIO);

            /*" -3104- MOVE 9 TO WS-DIG-TOTAL. */
            _.Move(9, WS_DIG_TOTAL);

            /*" -3105- COMPUTE WS-CONTADOR = WS-DIG-TOTAL - SVA-QTD-DIG. */
            WS_CONTADOR.Value = WS_DIG_TOTAL - REG_SBI7028B.SVA_QTD_DIG;

            /*" -3108- PERFORM R2630-00-LE-DIGITO UNTIL W76-IND EQUAL WS-CONTADOR. */

            while (!(W76_IND == WS_CONTADOR))
            {

                R2630_00_LE_DIGITO_SECTION();
            }

            /*" -3109- MOVE WS-SORTEIO TO CABU-NUM-SORTEIO (W78-IND). */
            _.Move(AREA_DE_WORK.WS_SORTEIO, AREA_DE_WORK.CABU.CABU_SORTEIO.CABU_SORTEIO_OCC[W78_IND].CABU_NUM_SORTEIO);

            /*" -3109- PERFORM R2610-00-FETCH-V0TITFDCAP. */

            R2610_00_FETCH_V0TITFDCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2620_99_SAIDA*/

        [StopWatch]
        /*" R2630-00-LE-DIGITO-SECTION */
        private void R2630_00_LE_DIGITO_SECTION()
        {
            /*" -3120- MOVE '2630' TO WNR-EXEC-SQL. */
            _.Move("2630", WABEND.WNR_EXEC_SQL);

            /*" -3122- ADD 1 TO W76-IND. */
            W76_IND.Value = W76_IND + 1;

            /*" -3123- IF WS-NUM-SORTEIO (W76-IND) EQUAL ZEROS */

            if (AREA_DE_WORK.WS_SORTEIO.WS_SORTEIO_OCC[W76_IND].WS_NUM_SORTEIO == 00)
            {

                /*" -3124- MOVE SPACES TO WS-NUM-SORTEIO (W76-IND) */
                _.Move("", AREA_DE_WORK.WS_SORTEIO.WS_SORTEIO_OCC[W76_IND].WS_NUM_SORTEIO);

                /*" -3124- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2630_99_SAIDA*/

        [StopWatch]
        /*" R2650-LER-CAP-SECTION */
        private void R2650_LER_CAP_SECTION()
        {
            /*" -3133- MOVE '2650' TO WNR-EXEC-SQL. */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -3134- MOVE SPACES TO WS-CABU-NUM-SORTEIO. */
            _.Move("", AREA_DE_WORK.WS_CABU_NUM_SORTEIO);

            /*" -3136- MOVE SPACES TO CABU-COD-SUSEP-CAP. */
            _.Move("", AREA_DE_WORK.CABU.CABU_COD_SUSEP_CAP);

            /*" -3167- PERFORM R2650_LER_CAP_DB_SELECT_1 */

            R2650_LER_CAP_DB_SELECT_1();

            /*" -3173- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3174- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3175- ELSE */
            }
            else
            {


                /*" -3176- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3177- MOVE WS-CABU-SORTEIO-07 TO WS-RCABU-SORTEIO-07 */
                    _.Move(AREA_DE_WORK.WS_CABU_NUM_SORTEIO.WS_CABU_SORTEIO_07, AREA_DE_WORK.WS_RCABU_NUM_SORTEIO.WS_RCABU_SORTEIO_07);

                    /*" -3178- MOVE WS-RCABU-NUM-SORTEIO TO CABU-NUM-SORTEIO-RED (01) */
                    _.Move(AREA_DE_WORK.WS_RCABU_NUM_SORTEIO, AREA_DE_WORK.CABU_SORTEIO_RED.CABU_SORTEIO_OCC_RED[01].CABU_NUM_SORTEIO_RED);

                    /*" -3179- MOVE SPACES TO WS-CABU-NUM-SORTEIO */
                    _.Move("", AREA_DE_WORK.WS_CABU_NUM_SORTEIO);

                    /*" -3183- MOVE WS-CABU-NUM-SORTEIO TO CABU-NUM-SORTEIO-RED (02) CABU-NUM-SORTEIO-RED (03) CABU-NUM-SORTEIO-RED (04) CABU-NUM-SORTEIO-RED (05) */
                    _.Move(AREA_DE_WORK.WS_CABU_NUM_SORTEIO, AREA_DE_WORK.CABU_SORTEIO_RED.CABU_SORTEIO_OCC_RED[02].CABU_NUM_SORTEIO_RED, AREA_DE_WORK.CABU_SORTEIO_RED.CABU_SORTEIO_OCC_RED[03].CABU_NUM_SORTEIO_RED, AREA_DE_WORK.CABU_SORTEIO_RED.CABU_SORTEIO_OCC_RED[04].CABU_NUM_SORTEIO_RED, AREA_DE_WORK.CABU_SORTEIO_RED.CABU_SORTEIO_OCC_RED[05].CABU_NUM_SORTEIO_RED);

                    /*" -3183- MOVE CABU-SORTEIO-RED TO CABU-SORTEIO. */
                    _.Move(AREA_DE_WORK.CABU_SORTEIO_RED, AREA_DE_WORK.CABU.CABU_SORTEIO);
                }

            }


        }

        [StopWatch]
        /*" R2650-LER-CAP-DB-SELECT-1 */
        public void R2650_LER_CAP_DB_SELECT_1()
        {
            /*" -3167- EXEC SQL SELECT CASE C.QTD_DIG_COMBINACAO WHEN 5 THEN SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 6,5) WHEN 6 THEN SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 5,6) WHEN 7 THEN SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 4,7) WHEN 8 THEN SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 3,8) WHEN 9 THEN SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 2,9) END, E.COD_PROCESSO_SUSEP INTO :WS-CABU-SORTEIO-07, :CABU-COD-SUSEP-CAP FROM FDRCAP.FC_TITULO AS B, FDRCAP.FC_COMB_TITULOS AS D, FDRCAP.FC_PLANO AS C, FDRCAP.FC_PROCESSO_SUSEP AS E WHERE B.NUM_PROPOSTA = :WHOST-BILHETE AND B.COD_STA_TITULO = 'ATV' AND D.NUM_TITULO = B.NUM_TITULO AND D.NUM_COMBINACAO = 1 AND D.IDE_SERIEPADRAO = B.IDE_SERIEPADRAO AND B.NUM_PLANO = C.NUM_PLANO AND C.NUM_PLANO = E.NUM_PLANO FETCH FIRST 01 ROWS ONLY WITH UR END-EXEC. */

            var r2650_LER_CAP_DB_SELECT_1_Query1 = new R2650_LER_CAP_DB_SELECT_1_Query1()
            {
                WHOST_BILHETE = WHOST_BILHETE.ToString(),
            };

            var executed_1 = R2650_LER_CAP_DB_SELECT_1_Query1.Execute(r2650_LER_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CABU_SORTEIO_07, AREA_DE_WORK.WS_CABU_NUM_SORTEIO.WS_CABU_SORTEIO_07);
                _.Move(executed_1.CABU_COD_SUSEP_CAP, AREA_DE_WORK.CABU.CABU_COD_SUSEP_CAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-IMPRIME-REG10-SECTION */
        private void R3300_00_IMPRIME_REG10_SECTION()
        {
            /*" -3195- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", WABEND.WNR_EXEC_SQL);

            /*" -3196- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -3197- DISPLAY 'QUANTIDADE POR COD-FORMULARIO ' */
            _.Display($"QUANTIDADE POR COD-FORMULARIO ");

            /*" -3198- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -3199- IF WS-QTD-VAKS28AP GREATER ZEROS */

            if (AREA_DE_WORK.WS_QTD_VAKS28AP > 00)
            {

                /*" -3200- MOVE '10' TO CAB8-TP-REGISTRO */
                _.Move("10", AREA_DE_WORK.CAB8.CAB8_TP_REGISTRO);

                /*" -3201- MOVE 'VAKS28AP' TO CAB8-COD-FORMULARIO */
                _.Move("VAKS28AP", AREA_DE_WORK.CAB8.CAB8_COD_FORMULARIO);

                /*" -3205- MOVE WS-QTD-VAKS28AP TO CAB8-QTD */
                _.Move(AREA_DE_WORK.WS_QTD_VAKS28AP, AREA_DE_WORK.CAB8.CAB8_QTD);

                /*" -3206- DISPLAY CAB8 */
                _.Display(AREA_DE_WORK.CAB8);

                /*" -3208- END-IF. */
            }


            /*" -3209- IF WS-QTD-VAKS28JV GREATER ZEROS */

            if (AREA_DE_WORK.WS_QTD_VAKS28JV > 00)
            {

                /*" -3210- MOVE '10' TO CAB8-TP-REGISTRO */
                _.Move("10", AREA_DE_WORK.CAB8.CAB8_TP_REGISTRO);

                /*" -3211- MOVE 'VAKS28JV' TO CAB8-COD-FORMULARIO */
                _.Move("VAKS28JV", AREA_DE_WORK.CAB8.CAB8_COD_FORMULARIO);

                /*" -3212- MOVE WS-QTD-VAKS28JV TO CAB8-QTD */
                _.Move(AREA_DE_WORK.WS_QTD_VAKS28JV, AREA_DE_WORK.CAB8.CAB8_QTD);

                /*" -3213- DISPLAY CAB8 */
                _.Display(AREA_DE_WORK.CAB8);

                /*" -3215- END-IF. */
            }


            /*" -3216- IF WS-QTD-VAKS28RD GREATER ZEROS */

            if (AREA_DE_WORK.WS_QTD_VAKS28RD > 00)
            {

                /*" -3217- MOVE '10' TO CAB8-TP-REGISTRO */
                _.Move("10", AREA_DE_WORK.CAB8.CAB8_TP_REGISTRO);

                /*" -3218- MOVE 'VAKS28RD' TO CAB8-COD-FORMULARIO */
                _.Move("VAKS28RD", AREA_DE_WORK.CAB8.CAB8_COD_FORMULARIO);

                /*" -3222- MOVE WS-QTD-VAKS28RD TO CAB8-QTD */
                _.Move(AREA_DE_WORK.WS_QTD_VAKS28RD, AREA_DE_WORK.CAB8.CAB8_QTD);

                /*" -3223- DISPLAY CAB8 */
                _.Display(AREA_DE_WORK.CAB8);

                /*" -3225- END-IF. */
            }


            /*" -3226- IF WS-QTD-VAKS28PO GREATER ZEROS */

            if (AREA_DE_WORK.WS_QTD_VAKS28PO > 00)
            {

                /*" -3227- MOVE '10' TO CAB8-TP-REGISTRO */
                _.Move("10", AREA_DE_WORK.CAB8.CAB8_TP_REGISTRO);

                /*" -3228- MOVE 'VAKS28PO' TO CAB8-COD-FORMULARIO */
                _.Move("VAKS28PO", AREA_DE_WORK.CAB8.CAB8_COD_FORMULARIO);

                /*" -3232- MOVE WS-QTD-VAKS28PO TO CAB8-QTD */
                _.Move(AREA_DE_WORK.WS_QTD_VAKS28PO, AREA_DE_WORK.CAB8.CAB8_QTD);

                /*" -3233- DISPLAY CAB8 */
                _.Display(AREA_DE_WORK.CAB8);

                /*" -3235- END-IF. */
            }


            /*" -3235- DISPLAY '-------------------------------------------' . */
            _.Display($"-------------------------------------------");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-VERIFICA-CAP-SECTION */
        private void R3400_00_VERIFICA_CAP_SECTION()
        {
            /*" -3289- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", WABEND.WNR_EXEC_SQL);

            /*" -3306- INITIALIZE VG0716S-COD-FONTE , VG0716S-COD-PRODUTO , VG0716S-NUM-PROPOSTA , VG0716S-VLR-MENSALIDADE , VG0716S-NUM-PLANO , VG0716S-NUM-SERIE , VG0716S-NUM-TITULO , VG0716S-IND-DV , VG0716S-DTH-INI-VIGENCIA , VG0716S-DTH-FIM-VIGENCIA , VG0716S-DES-COMBINACAO , VG0716S-COD-STA-TITULO , VG0716S-SQLCODE , VG0716S-COD-RETORNO , VG0716S-DES-MENSAGEM. */
            _.Initialize(
                VG0716S_COD_FONTE
                , VG0716S_COD_PRODUTO
                , VG0716S_NUM_PROPOSTA
                , VG0716S_VLR_MENSALIDADE
                , VG0716S_NUM_PLANO
                , VG0716S_NUM_SERIE
                , VG0716S_NUM_TITULO
                , VG0716S_IND_DV
                , VG0716S_DTH_INI_VIGENCIA
                , VG0716S_DTH_FIM_VIGENCIA
                , VG0716S_DES_COMBINACAO
                , VG0716S_COD_STA_TITULO
                , VG0716S_SQLCODE
                , VG0716S_COD_RETORNO
                , VG0716S_DES_MENSAGEM
            );

            /*" -3307- MOVE BILHETE-FONTE TO VG0716S-COD-FONTE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_FONTE, VG0716S_COD_FONTE);

            /*" -3309- MOVE PROPOFID-COD-PRODUTO-SIVPF TO VG0716S-COD-PRODUTO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, VG0716S_COD_PRODUTO);

            /*" -3310- MOVE ZEROS TO VG0716S-NUM-PLANO. */
            _.Move(0, VG0716S_NUM_PLANO);

            /*" -3312- MOVE BILHETE-NUM-BILHETE TO VG0716S-NUM-PROPOSTA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, VG0716S_NUM_PROPOSTA);

            /*" -3314- MOVE ZEROS TO VG0716S-VLR-MENSALIDADE. */
            _.Move(0, VG0716S_VLR_MENSALIDADE);

            /*" -3331- CALL 'VG0716S' USING VG0716S-COD-FONTE , VG0716S-COD-PRODUTO , VG0716S-NUM-PROPOSTA , VG0716S-VLR-MENSALIDADE , VG0716S-NUM-PLANO , VG0716S-NUM-SERIE , VG0716S-NUM-TITULO , VG0716S-IND-DV , VG0716S-DTH-INI-VIGENCIA , VG0716S-DTH-FIM-VIGENCIA , VG0716S-DES-COMBINACAO , VG0716S-COD-STA-TITULO , VG0716S-SQLCODE , VG0716S-COD-RETORNO , VG0716S-DES-MENSAGEM. */
            _.Call("VG0716S", VG0716S_COD_FONTE, VG0716S_COD_PRODUTO, VG0716S_NUM_PROPOSTA, VG0716S_VLR_MENSALIDADE, VG0716S_NUM_PLANO, VG0716S_NUM_SERIE, VG0716S_NUM_TITULO, VG0716S_IND_DV, VG0716S_DTH_INI_VIGENCIA, VG0716S_DTH_FIM_VIGENCIA, VG0716S_DES_COMBINACAO, VG0716S_COD_STA_TITULO, VG0716S_SQLCODE, VG0716S_COD_RETORNO, VG0716S_DES_MENSAGEM);

            /*" -3332- IF VG0716S-COD-RETORNO NOT EQUAL ZEROS */

            if (VG0716S_COD_RETORNO != 00)
            {

                /*" -3333- DISPLAY 'PROBLEMAS NO ACESSO A VG0716S ' */
                _.Display($"PROBLEMAS NO ACESSO A VG0716S ");

                /*" -3334- DISPLAY 'VG0716S-COD-FONTE        ' VG0716S-COD-FONTE */
                _.Display($"VG0716S-COD-FONTE        {VG0716S_COD_FONTE}");

                /*" -3335- DISPLAY 'VG0716S-COD-PRODUTO      ' VG0716S-COD-PRODUTO */
                _.Display($"VG0716S-COD-PRODUTO      {VG0716S_COD_PRODUTO}");

                /*" -3336- DISPLAY 'VG0716S-NUM-PROPOSTA     ' VG0716S-NUM-PROPOSTA */
                _.Display($"VG0716S-NUM-PROPOSTA     {VG0716S_NUM_PROPOSTA}");

                /*" -3337- DISPLAY 'VG0716S-VLR-MENSALIDADE  ' VG0716S-VLR-MENSALIDADE */
                _.Display($"VG0716S-VLR-MENSALIDADE  {VG0716S_VLR_MENSALIDADE}");

                /*" -3338- DISPLAY 'VG0716S-NUM-PLANO        ' VG0716S-NUM-PLANO */
                _.Display($"VG0716S-NUM-PLANO        {VG0716S_NUM_PLANO}");

                /*" -3339- DISPLAY 'VG0716S-NUM-SERIE        ' VG0716S-NUM-SERIE */
                _.Display($"VG0716S-NUM-SERIE        {VG0716S_NUM_SERIE}");

                /*" -3340- DISPLAY 'VG0716S-NUM-TITULO       ' VG0716S-NUM-TITULO */
                _.Display($"VG0716S-NUM-TITULO       {VG0716S_NUM_TITULO}");

                /*" -3341- DISPLAY 'VG0716S-IND-DV           ' VG0716S-IND-DV */
                _.Display($"VG0716S-IND-DV           {VG0716S_IND_DV}");

                /*" -3342- DISPLAY 'VG0716S-DTH-INI-VIGENCIA ' VG0716S-DTH-INI-VIGENCIA */
                _.Display($"VG0716S-DTH-INI-VIGENCIA {VG0716S_DTH_INI_VIGENCIA}");

                /*" -3343- DISPLAY 'VG0716S-DTH-FIM-VIGENCIA ' VG0716S-DTH-FIM-VIGENCIA */
                _.Display($"VG0716S-DTH-FIM-VIGENCIA {VG0716S_DTH_FIM_VIGENCIA}");

                /*" -3344- DISPLAY 'VG0716S-DES-COMBINACAO   ' VG0716S-DES-COMBINACAO */
                _.Display($"VG0716S-DES-COMBINACAO   {VG0716S_DES_COMBINACAO}");

                /*" -3345- DISPLAY 'VG0716S-COD-STA-TITULO   ' VG0716S-COD-STA-TITULO */
                _.Display($"VG0716S-COD-STA-TITULO   {VG0716S_COD_STA_TITULO}");

                /*" -3346- MOVE VG0716S-SQLCODE TO WS-ABEND */
                _.Move(VG0716S_SQLCODE, WS_ABEND);

                /*" -3347- DISPLAY 'VG0716S-SQLCODE          ' WS-ABEND */
                _.Display($"VG0716S-SQLCODE          {WS_ABEND}");

                /*" -3348- DISPLAY 'VG0716S-COD-RETORNO      ' VG0716S-COD-RETORNO */
                _.Display($"VG0716S-COD-RETORNO      {VG0716S_COD_RETORNO}");

                /*" -3349- DISPLAY 'VG0716S-DES-MENSAGEM     ' VG0716S-DES-MENSAGEM */
                _.Display($"VG0716S-DES-MENSAGEM     {VG0716S_DES_MENSAGEM}");

                /*" -3350- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3352- END-IF. */
            }


            /*" -3353- IF VG0716S-SQLCODE EQUAL 100 */

            if (VG0716S_SQLCODE == 100)
            {

                /*" -3354- MOVE 'N' TO WTEM-FCTITULO */
                _.Move("N", AREA_DE_WORK.WTEM_FCTITULO);

                /*" -3355- ELSE */
            }
            else
            {


                /*" -3356- MOVE 'S' TO WTEM-FCTITULO */
                _.Move("S", AREA_DE_WORK.WTEM_FCTITULO);

                /*" -3356- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-PESQUISA-FORMULARIO-SECTION */
        private void R3500_00_PESQUISA_FORMULARIO_SECTION()
        {
            /*" -3373- MOVE '9200' TO WNR-EXEC-SQL. */
            _.Move("9200", WABEND.WNR_EXEC_SQL);

            /*" -3374- MOVE SVA-COD-PRODUTO TO RELATORI-COD-PLANO */
            _.Move(REG_SBI7028B.SVA_COD_PRODUTO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);

            /*" -3376- MOVE CABU-COD-FORMULARIO TO RELATORI-COD-RELATORIO */
            _.Move(AREA_DE_WORK.CABU.CABU_COD_FORMULARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -3388- PERFORM R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1 */

            R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1();

            /*" -3391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3392- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3393- MOVE 'N' TO WHOST-UNIC */
                    _.Move("N", WHOST_UNIC);

                    /*" -3394- GO TO R3500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/ //GOTO
                    return;

                    /*" -3395- ELSE */
                }
                else
                {


                    /*" -3396- DISPLAY 'R3500 - PROBLEMAS SELECT RELATORIOS' */
                    _.Display($"R3500 - PROBLEMAS SELECT RELATORIOS");

                    /*" -3397- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3398- END-IF */
                }


                /*" -3400- END-IF */
            }


            /*" -3401- MOVE 'S' TO WHOST-UNIC. */
            _.Move("S", WHOST_UNIC);

        }

        [StopWatch]
        /*" R3500-00-PESQUISA-FORMULARIO-DB-SELECT-1 */
        public void R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1()
        {
            /*" -3388- EXEC SQL SELECT TIPO_CORRECAO , NUM_APOL_LIDER INTO :RELATORI-TIPO-CORRECAO , :RELATORI-NUM-APOL-LIDER FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'VG' AND NUM_APOLICE = 9999999999999 AND COD_SUBGRUPO = 9999 AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND COD_PLANO = :RELATORI-COD-PLANO WITH UR END-EXEC */

            var r3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1 = new R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
            };

            var executed_1 = R3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1.Execute(r3500_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_TIPO_CORRECAO, RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);
                _.Move(executed_1.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-BUSCA-NOM-SOCIAL-SECTION */
        private void R4000_00_BUSCA_NOM_SOCIAL_SECTION()
        {
            /*" -3411- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -3433- INITIALIZE LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE */
            _.Initialize(
                SPGE053W.LK_GE053_E_TRACE
                , SPGE053W.LK_GE053_E_IDE_SISTEMA
                , SPGE053W.LK_GE053_E_IND_OPERACAO
                , SPGE053W.LK_GE053_I_NUM_CPF
                , SPGE053W.LK_GE053_I_DTH_OPERACAO
                , SPGE053W.LK_GE053_I_NOM_SOCIAL
                , SPGE053W.LK_GE053_I_IND_TIPO_ACAO
                , SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL
                , SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO
                , SPGE053W.LK_GE053_I_NUM_PROPOSTA
                , SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM
                , SPGE053W.LK_GE053_I_NUM_MATRICULA
                , SPGE053W.LK_GE053_I_NOM_PROGRAMA
                , SPGE053W.LK_GE053_I_DTH_CADASTRAMENTO
                , SPGE053W.LK_GE053_IND_ERRO
                , SPGE053W.LK_GE053_ID_ERRO
                , SPGE053W.LK_GE053_MENSAGEM
                , SPGE053W.LK_GE053_NOM_TABELA
                , SPGE053W.LK_GE053_SQLCODE
                , SPGE053W.LK_GE053_SQLERRMC
                , SPGE053W.LK_GE053_SQLSTATE
            );

            /*" -3434- MOVE 'N' TO LK-GE053-E-TRACE */
            _.Move("N", SPGE053W.LK_GE053_E_TRACE);

            /*" -3435- MOVE 'VA' TO LK-GE053-E-IDE-SISTEMA */
            _.Move("VA", SPGE053W.LK_GE053_E_IDE_SISTEMA);

            /*" -3436- MOVE 2 TO LK-GE053-E-IND-OPERACAO */
            _.Move(2, SPGE053W.LK_GE053_E_IND_OPERACAO);

            /*" -3438- MOVE SVA-CPF TO LK-GE053-I-NUM-CPF */
            _.Move(REG_SBI7028B.SVA_CPF, SPGE053W.LK_GE053_I_NUM_CPF);

            /*" -3460- CALL 'SPBGE053' USING LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE */
            _.Call("SPBGE053", SPGE053W);

            /*" -3462- . */

            /*" -3464- MOVE LK-GE053-SQLCODE TO SQLCODE */
            _.Move(SPGE053W.LK_GE053_SQLCODE, DB.SQLCODE);

            /*" -3466- IF (LK-GE053-SQLCODE NOT EQUAL ZEROS) AND (LK-GE053-SQLCODE NOT EQUAL 100) */

            if ((SPGE053W.LK_GE053_SQLCODE != 00) && (SPGE053W.LK_GE053_SQLCODE != 100))
            {

                /*" -3467- DISPLAY 'ERRO SUBROTINA SPBGE053' */
                _.Display($"ERRO SUBROTINA SPBGE053");

                /*" -3468- DISPLAY 'LK-GE053-MENSAGEM      ' LK-GE053-MENSAGEM */
                _.Display($"LK-GE053-MENSAGEM      {SPGE053W.LK_GE053_MENSAGEM}");

                /*" -3469- DISPLAY 'LK-GE053-SQLCODE       ' LK-GE053-SQLCODE */
                _.Display($"LK-GE053-SQLCODE       {SPGE053W.LK_GE053_SQLCODE}");

                /*" -3470- DISPLAY 'LK-GE053-E-IDE-SISTEMA ' LK-GE053-E-TRACE */
                _.Display($"LK-GE053-E-IDE-SISTEMA {SPGE053W.LK_GE053_E_TRACE}");

                /*" -3471- DISPLAY 'LK-GE053-E-IND-OPERACAO ' LK-GE053-E-IDE-SISTEMA */
                _.Display($"LK-GE053-E-IND-OPERACAO {SPGE053W.LK_GE053_E_IDE_SISTEMA}");

                /*" -3472- DISPLAY 'LK-GE053-E-TRACE       ' LK-GE053-E-IND-OPERACAO */
                _.Display($"LK-GE053-E-TRACE       {SPGE053W.LK_GE053_E_IND_OPERACAO}");

                /*" -3473- DISPLAY 'LK-GE053-I-NUM-CPF     ' LK-GE053-I-NUM-CPF */
                _.Display($"LK-GE053-I-NUM-CPF     {SPGE053W.LK_GE053_I_NUM_CPF}");

                /*" -3474- DISPLAY 'ERRO INESPERADO SUBROTINA SPBGE053' */
                _.Display($"ERRO INESPERADO SUBROTINA SPBGE053");

                /*" -3475- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3477- END-IF */
            }


            /*" -3478- IF LK-GE053-I-NOM-SOCIAL NOT EQUAL SPACES */

            if (!SPGE053W.LK_GE053_I_NOM_SOCIAL.IsEmpty())
            {

                /*" -3479- MOVE LK-GE053-I-NOM-SOCIAL TO CABU-NOM-CLIENTE-SOCIAL */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.CABU.CABU_NOM_CLIENTE_SOCIAL);

                /*" -3480- MOVE LK-GE053-I-NOM-SOCIAL TO CABU-NOM-ESTIPULANTE-SOCIAL */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.CABU.CABU_NOM_ESTIPULANTE_SOCIAL);

                /*" -3481- MOVE LK-GE053-I-NOM-SOCIAL TO CABU-NOM-SEGURADO3-SOCIAL */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.CABU.CABU_NOM_SEGURADO3_SOCIAL);

                /*" -3482- ELSE */
            }
            else
            {


                /*" -3483- MOVE SPACES TO CABU-NOM-CLIENTE-SOCIAL */
                _.Move("", AREA_DE_WORK.CABU.CABU_NOM_CLIENTE_SOCIAL);

                /*" -3484- MOVE SPACES TO CABU-NOM-ESTIPULANTE-SOCIAL */
                _.Move("", AREA_DE_WORK.CABU.CABU_NOM_ESTIPULANTE_SOCIAL);

                /*" -3485- MOVE SPACES TO CABU-NOM-SEGURADO3-SOCIAL */
                _.Move("", AREA_DE_WORK.CABU.CABU_NOM_SEGURADO3_SOCIAL);

                /*" -3487- END-IF */
            }


            /*" -3488- DISPLAY 'LK-GE053-E-TRACE        ' LK-GE053-E-TRACE */
            _.Display($"LK-GE053-E-TRACE        {SPGE053W.LK_GE053_E_TRACE}");

            /*" -3489- DISPLAY 'LK-GE053-E-IDE-SISTEMA  ' LK-GE053-E-IDE-SISTEMA */
            _.Display($"LK-GE053-E-IDE-SISTEMA  {SPGE053W.LK_GE053_E_IDE_SISTEMA}");

            /*" -3490- DISPLAY 'LK-GE053-E-IND-OPERACAO ' LK-GE053-E-IND-OPERACAO */
            _.Display($"LK-GE053-E-IND-OPERACAO {SPGE053W.LK_GE053_E_IND_OPERACAO}");

            /*" -3491- DISPLAY 'LK-GE053-I-NUM-CPF      ' LK-GE053-I-NUM-CPF */
            _.Display($"LK-GE053-I-NUM-CPF      {SPGE053W.LK_GE053_I_NUM_CPF}");

            /*" -3492- DISPLAY 'LK-GE053-I-NOM-SOCIAL   ' LK-GE053-I-NOM-SOCIAL */
            _.Display($"LK-GE053-I-NOM-SOCIAL   {SPGE053W.LK_GE053_I_NOM_SOCIAL}");

            /*" -3493- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -3504- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -3507- OPEN OUTPUT RBI7028B RBI7028I RBI7028P RBI7028H. */
            RBI7028B.Open(RBI7028B_RECORD);
            RBI7028I.Open(RBI7028I_RECORD);
            RBI7028P.Open(RBI7028P_RECORD);
            RBI7028H.Open(RBI7028H_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -3519- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -3522- CLOSE RBI7028B RBI7028I RBI7028P RBI7028H. */
            RBI7028B.Close();
            RBI7028I.Close();
            RBI7028P.Close();
            RBI7028H.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -3537- MOVE '9800' TO WNR-EXEC-SQL. */
            _.Move("9800", WABEND.WNR_EXEC_SQL);

            /*" -3538- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3539- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3540- DISPLAY '*   BI7028B - EMITE BILHETE                *' */
            _.Display($"*   BI7028B - EMITE BILHETE                *");

            /*" -3541- DISPLAY '*   -------   -----------------            *' */
            _.Display($"*   -------   -----------------            *");

            /*" -3542- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3543- DISPLAY '*      NAO EXISTEM BILHETES A              *' */
            _.Display($"*      NAO EXISTEM BILHETES A              *");

            /*" -3544- DISPLAY '*         SEREM EMITIDOS.                  *' */
            _.Display($"*         SEREM EMITIDOS.                  *");

            /*" -3545- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3545- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3559- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -3560- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -3561- DISPLAY '*** BI7028B - LIDOS   ' AC-LIDOS. */
            _.Display($"*** BI7028B - LIDOS   {AREA_DE_WORK.AC_LIDOS}");

            /*" -3564- DISPLAY '*** BI7028B - BILHETE ' BILHETE-NUM-BILHETE. */
            _.Display($"*** BI7028B - BILHETE {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

            /*" -3564- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -3566- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3570- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3570- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}