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
using Sias.VidaEmpresarial.DB2.VE0414B;

namespace Code
{
    public class VE0414B
    {
        public bool IsCall { get; set; }

        public VE0414B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      * FUNCAO ......... EMISSAO DE CERTIFICADO EMPRESA FORMULARIOs    *      */
        /*"      *                  VA55 e VA95) DO PRODUTO CAIXA SEGURO VIDA     *      */
        /*"      *                  EMPRESARIAL GLOBAL EMISSAO VIA FAC            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMA......... CAIXA SEGURO VIDA EMPRESARIAL                 *      */
        /*"      * ANALISTA........ FREDERICO J FONSECA                           *      */
        /*"      * DATA CRIACAO ... 28 DE OUTUBRO DE 2004                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                  A L T E R A C O E S                           *      */
        /*"      ******************************************************************      */
        /*"V.29  *  VERSAO 29  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2024 - TERCIO CARVALHO/SERGIO LORETO                *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.28  *  VERSAO 28  - DEMANDA 564.320                                  *      */
        /*"      *               SUBSTITUIR A CHAMADA DA SPBFC012 PELA SPBVG012   *      */
        /*"      *             - PORQUE A CAP ESTA DEIXANDO O MAINFRAME.          *      */
        /*"      *                                                                *      */
        /*"      *  EM 19/01/2024 - RAUL BASILI ROTTA                             *      */
        /*"      *                                        PROCURE POR V.28        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO 27: DEMANDA 228540  TARAFE 291343                        *      */
        /*"      *           01/06/2021 - HUSNI ALI HUSNI                         *      */
        /*"      *           BLOQUEAR A EMISSAO DE FORMULARIOS PARA PRODUTOS      *      */
        /*"      *           8205, 8209, 8241, 8242, 9315, 9316, 9323, 9324,      *      */
        /*"      *           9325, 9326, 9329, 9343, 9381, 9382, 9706, 9712,      *      */
        /*"      *           9713, 9714, 9715                                     *      */
        /*"      *           - PROCURAR POR V.27                                  *      */
        /*"JV126#*----------------------------------------------------------------*      */
        /*"JV126#*VERSAO 26: JV1 DEMANDA 262179 - KINKAS 28/10/2020               *      */
        /*"JV126#*           TROCA REFERENCIAS PRODUTOS JV1 POR JVPRDXXXX         *      */
        /*"JV126#*           - PROCURAR POR JV126                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV126 *VERSAO 26: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV126 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV126 *           - PROCURAR POR JV126                                 *      */
        /*"JV126 *----------------------------------------------------------------*      */
        /*"JV125 *VERSAO 25: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV125 *           ALTERA FORMULARIOS PARA EMPRESA 11 - JV1                    */
        /*"JV125 *           - PROCURAR POR JV125                                        */
        /*"JV125 *-----------------------------------------------------------------      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 24 - ALTERA CONSULTA AOS DADOS DO TITULO ACOPLADO,    *      */
        /*"      *               INSERINDO CHAMADA DA SPBFC012. CADMUS 179924     *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/03/2020 - ALCIONE ARAUJO (STEFANINI)                   *      */
        /*"      *      13/04/2020 - HUSNI ALI HUSNI     MERGE CAP x CVP          *      */
        /*"      *                                       PROCURE POR V.24         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23 - HIST 206.622     TAREFA: 228.884                 *      */
        /*"      *             - RETIRAR FORMULARIOS CVP                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/01/2020 - HERVAL SOUZA                                 *      */
        /*"      *      27/03/2020 - HUSNI ALI HUSNI     VOLTAR V.23              *      */
        /*"      *                                       PROCURE POR JV.01        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22 - HIST 181.608                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CAD 149.542                                      *      */
        /*"      *                                                                *      */
        /*"      *             - PARA ATENDIMENTO AO UNIC, FOI INCLUIDO TRATAMENTO*      */
        /*"      *               DE PROCESSAMENTO DAS SOLICITACOES DE RELATORIO   *      */
        /*"      *               PARA O DIA SISTEMA ABERTO MENOS 05 DIA.          *      */
        /*"      *               ASSIM O PROGRAMA CONSEGUE ENVIAR O NUMERO DE     *      */
        /*"      *               SORTEIO, DEVIDO A ROTINA DA CAP PROCESSAR APOS.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/04/2017 - LUIGI CONTE                                  *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.21        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - CAD 119.494                                      *      */
        /*"      *                                                                *      */
        /*"      *             - PROJETO UNIC - MODULO DE RETENCAO                *      */
        /*"      *             - INCLUSAO DOS FILTROS PARA AS OPCOES DE ENVIO     *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/01/2016 - RIBAMAR MARQUES                              *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.20        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18                                                    *      */
        /*"      *             - CAD 107.292                                      *      */
        /*"      *               CRIACAO DE COLUNA COD-PRODUTO NO TEXTO DA TABELA *      */
        /*"      *               GE_OBJETO_ECT                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/01/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.18             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17                                                    *      */
        /*"      *             - CAD 98.769                                       *      */
        /*"      *               MODIFICACAO DA CONSULTA DO NUMERO DO SORTEIO PARA*      */
        /*"      *               A BASE DE DADOS DA CAPITALIZACAO. SUBSTITUICAO DA*      */
        /*"      *               TABELA SEGUROS.TITULOS_FED_CAP_VA POR            *      */
        /*"      *               FDRCAP.FC_COMB_TITULOS.                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/08/2014 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.17             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - CAD 90.740                                       *      */
        /*"      *                                                                *      */
        /*"      *               - GERAR O CERTIFICADO IMPRESSO NO FORMULARIO     *      */
        /*"      *                 VA95, PARA OS PRODUTOS ABAIXO;                 *      */
        /*"      *                                                                *      */
        /*"      *                 9322 - 9323 - 9324 - 9325 - 9326               *      */
        /*"      *                 9706 - 9712 - 9713 - 9714 - 9715               *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/02/2014 - TERCIO FREITAS                               *      */
        /*"      *                                            PROCURE POR V.16    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - CAD 90.449                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTES NO CONTROLE DE CERTIFICADOS EMITIDOS.  *      */
        /*"      *                 PERDENDO EMISSAO DE CERTIFICADOS               *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/11/2013 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.15    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - CAD 87.762                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUIR O NUMERO DO SORTEIO PARA IMPRESSAO.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 - TERCIO FREITAS                               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.14    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 - CAD 83.473                                       *      */
        /*"      *                                                                *      */
        /*"      *               - TRATA ABEND POR TER RECUPERADO APOLICE ZERADA  *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/06/2012 - FAST COMPUTER - PEDRO SILVERIO               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.13    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD 83.382                                       *      */
        /*"      *                                                                *      */
        /*"      *               - TRATAR AS APOLICE 108210933403 E 109300002585  *      */
        /*"      *                 QUE TEM COMO CARACTERISTICA O PAGAMENTO        *      */
        /*"      *                 ANTECIPADO.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/06/2012 - FAST COMPUTER - PEDRO SILVERIO               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.12    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 82.874                                       *      */
        /*"      *                                                                *      */
        /*"      *               - CORRECAO DO ABEND SQLCODE (-811) OCORRIDO NA   *      */
        /*"      *                 TABELA SEGUROS.HIS_COBER_PROPOST               *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/05/2013 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.11    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 73.003                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUSAO DA APOLICE 109300002142               *      */
        /*"      *                 EM SUBSTITUICAO DA  109300001819 EM FUNCAO     *      */
        /*"      *                 DE ESTOURO NA COLUNA COD_SUBGRUPO DA TABELA    *      */
        /*"      *                 SEGUROS.SUBGRUPOS_VGAP.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/08/2012 - AUGUSTO ANASTACIO   (FAST COMPUTER)          *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.10    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 61.042                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUSAO DA APOLICE 109300001819 EM            *      */
        /*"      *                 EM SUBSTITUICAO DA  109300001670 EM FUNCAO     *      */
        /*"      *                 DE ESTOURO NA COLUNA COD_SUBGUPO DA TABELA     *      */
        /*"      *                 SEGUROS.SUBGRUPOS_VGAP.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/08/2011 - ALESSANDRO G. RAMOS (FAST COMPUTER)          *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.09    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 59.221                                       *      */
        /*"      *             - TRATAMENTO DO ABEND :                            *      */
        /*"      *                'R1500 - ERRO AO OBTER DADOS AGENCIA AGENCIA'   *      */
        /*"      *   EM 13/07/2011 - LOPES           (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.08    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 39.522                                       *      */
        /*"      *             - AJUSTE NO NOME RAZAO DO ARQUIVO A SER IMPRESSO.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/03/2010 - TERCIO FREITAS  (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    CAD 35728/38105 EM 03/03/2010  MARCO PAIVA -  FAST COMPUTER *      */
        /*"      *                                                                *      */
        /*"      *  - PASSA A ENVIAR CARTA DE DECLINIO PARA OS PRODUTOS SICOOB-   *      */
        /*"      *    CREDIMINAS.                                                 *      */
        /*"      *                                           PROCURAR POR  V.06   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 35.742                                       *      */
        /*"      *             - TRATA NOVO CODIGO DE PRODUTO EMPRESARIAL         *      */
        /*"      *               PARA APOLICE 109300000959 E AJUSTA REGRAS PARA   *      */
        /*"      *               A NOVA APOLICE 109300001670.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/01/2010 - TERCIO FREITAS  (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 30.959                                       *      */
        /*"      *             - INCLUI PERIODICIDADE DE PAGAMENTO NO ARQUIVO  DE *      */
        /*"      *               IMPRESSAO DE FORMULARIO                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/10/2009 - CESAR DALAZUANA (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 28.593                                       *      */
        /*"      *                                                                *      */
        /*"      *               PASSA A TRATAR AS APOLICES CACB                  *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/09/2009 - FAST COMPUTER - BERNAL   PROCURE POR V.03    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  002 - 26/02/2009 - FAST COMPUTER - LEANDRO CORTES             *      */
        /*"      *                                                                *      */
        /*"      * - ALTERAR O VALOR DO CAPITAL GLOBAL CONTRATADO                 *      */
        /*"      *                                                                *      */
        /*"      * - INCLUIR DADOS DAS TABELAS ATUALIZADAS                        *      */
        /*"      *                                                                *      */
        /*"      *  .CADMUS - 20.367                                              *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 18/07/2006 - FAST COMPUTER                              *      */
        /*"      *   ADEQUACAO DO NOVO FORMULARIO DO CERTIFICADO EMPRESA DEVIDO   *      */
        /*"      *   A REFORMULACAO DO VIDA.                                      *      */
        /*"      *                                            PROCURE POR FC0706  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 29257 - EVITAR A REJEICAO DE CORRESPONDENCIAS, RECU-  *      */
        /*"      *   PERANDO O CEP NAS BASES DNE DOS CORREIOS PELO ENDERECO.      *      */
        /*"      *   BRSEG - NOVEMBRO/2009 - VER: BR.V01                          *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RVE0414B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RVE0414B
        {
            get
            {
                _.Move(RVE0414B_RECORD, _RVE0414B); VarBasis.RedefinePassValue(RVE0414B_RECORD, _RVE0414B, RVE0414B_RECORD); return _RVE0414B;
            }
        }
        public FileBasis _RVE0414I { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RVE0414I
        {
            get
            {
                _.Move(RVE0414I_RECORD, _RVE0414I); VarBasis.RedefinePassValue(RVE0414I_RECORD, _RVE0414I, RVE0414I_RECORD); return _RVE0414I;
            }
        }
        public FileBasis _RVE0414P { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RVE0414P
        {
            get
            {
                _.Move(RVE0414P_RECORD, _RVE0414P); VarBasis.RedefinePassValue(RVE0414P_RECORD, _RVE0414P, RVE0414P_RECORD); return _RVE0414P;
            }
        }
        public FileBasis _RVE0414H { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RVE0414H
        {
            get
            {
                _.Move(RVE0414H_RECORD, _RVE0414H); VarBasis.RedefinePassValue(RVE0414H_RECORD, _RVE0414H, RVE0414H_RECORD); return _RVE0414H;
            }
        }
        public FileBasis _FVE0414B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis FVE0414B
        {
            get
            {
                _.Move(FVE0414B_RECORD, _FVE0414B); VarBasis.RedefinePassValue(FVE0414B_RECORD, _FVE0414B, FVE0414B_RECORD); return _FVE0414B;
            }
        }
        public SortBasis<VE0414B_REG_SVE0414B> SVE0414B { get; set; } = new SortBasis<VE0414B_REG_SVE0414B>(new VE0414B_REG_SVE0414B());
        /*"01  RVE0414B-RECORD.*/
        public VE0414B_RVE0414B_RECORD RVE0414B_RECORD { get; set; } = new VE0414B_RVE0414B_RECORD();
        public class VE0414B_RVE0414B_RECORD : VarBasis
        {
            /*"    03            REG-DADOS       PIC  X(3500).*/
            public StringBasis REG_DADOS { get; set; } = new StringBasis(new PIC("X", "3500", "X(3500)."), @"");
            /*"01  RVE0414I-RECORD.*/
        }
        public VE0414B_RVE0414I_RECORD RVE0414I_RECORD { get; set; } = new VE0414B_RVE0414I_RECORD();
        public class VE0414B_RVE0414I_RECORD : VarBasis
        {
            /*"    03            REG-DADOS-I     PIC  X(3500).*/
            public StringBasis REG_DADOS_I { get; set; } = new StringBasis(new PIC("X", "3500", "X(3500)."), @"");
            /*"01  RVE0414P-RECORD.*/
        }
        public VE0414B_RVE0414P_RECORD RVE0414P_RECORD { get; set; } = new VE0414B_RVE0414P_RECORD();
        public class VE0414B_RVE0414P_RECORD : VarBasis
        {
            /*"    03            REG-DADOS-P     PIC  X(3500).*/
            public StringBasis REG_DADOS_P { get; set; } = new StringBasis(new PIC("X", "3500", "X(3500)."), @"");
            /*"01  RVE0414H-RECORD.*/
        }
        public VE0414B_RVE0414H_RECORD RVE0414H_RECORD { get; set; } = new VE0414B_RVE0414H_RECORD();
        public class VE0414B_RVE0414H_RECORD : VarBasis
        {
            /*"    03            REG-DADOS-H     PIC  X(3500).*/
            public StringBasis REG_DADOS_H { get; set; } = new StringBasis(new PIC("X", "3500", "X(3500)."), @"");
            /*"01  FVE0414B-RECORD               PIC X(132).*/
        }
        public StringBasis FVE0414B_RECORD { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01  REG-SVE0414B.*/
        public VE0414B_REG_SVE0414B REG_SVE0414B { get; set; } = new VE0414B_REG_SVE0414B();
        public class VE0414B_REG_SVE0414B : VarBasis
        {
            /*"    05            SVA-NRAPOLICE           PIC  9(013).*/
            public IntBasis SVA_NRAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05            SVA-CODSUBES            PIC  9(005).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05            SVA-CEP-G               PIC  9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05            SVA-NUM-CEP.*/
            public VE0414B_SVA_NUM_CEP SVA_NUM_CEP { get; set; } = new VE0414B_SVA_NUM_CEP();
            public class VE0414B_SVA_NUM_CEP : VarBasis
            {
                /*"      15          SVA-CEP                 PIC  9(005).*/
                public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      15          SVA-CEP-COMPL           PIC  9(003).*/
                public IntBasis SVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05            SVA-NUM-TERMO           PIC  9(015).*/
            }
            public IntBasis SVA_NUM_TERMO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            SVA-DATA-ADESAO         PIC  X(010).*/
            public StringBasis SVA_DATA_ADESAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            SVA-COD-AGENCIA-OP      PIC  9(004).*/
            public IntBasis SVA_COD_AGENCIA_OP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-NOME-AGENCIA        PIC  X(040).*/
            public StringBasis SVA_NOME_AGENCIA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05            SVA-MODALIDADE-CAPITAL  PIC  X(001).*/
            public StringBasis SVA_MODALIDADE_CAPITAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-TIPO-PLANO          PIC  X(001).*/
            public StringBasis SVA_TIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-OCOREND             PIC  9(005).*/
            public IntBasis SVA_OCOREND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05            SVA-COD-PLANO-APC       PIC  9(009).*/
            public IntBasis SVA_COD_PLANO_APC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            SVA-VAL-CONTRATADO      PIC  9(013)V99.*/
            public DoubleBasis SVA_VAL_CONTRATADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05            SVA-VAL-PREMIO          PIC  9(013)V99.*/
            public DoubleBasis SVA_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05            SVA-QUANT-VIDAS         PIC  9(009).*/
            public IntBasis SVA_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            SVA-TIPO-COBERTURA      PIC  X(001).*/
            public StringBasis SVA_TIPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-PERI-PAGAMENTO      PIC  9(004).*/
            public IntBasis SVA_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-COD-CLIENTE         PIC  9(009).*/
            public IntBasis SVA_COD_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            SVA-NOME-CORREIO        PIC  X(046).*/
            public StringBasis SVA_NOME_CORREIO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"    05            SVA-ENDERECO            PIC  X(072).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05            SVA-BAIRRO              PIC  X(072).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05            SVA-CIDADE              PIC  X(072).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05            SVA-UF                  PIC  X(002).*/
            public StringBasis SVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05            SVA-FONTE               PIC  9(004).*/
            public IntBasis SVA_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-NUM-PROPOSTA-SIVPF  PIC  9(015).*/
            public IntBasis SVA_NUM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            SVA-DTH-DIA-DEBITO      PIC  9(002).*/
            public IntBasis SVA_DTH_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            SVA-COD-AGENCIA-DEB     PIC  9(004).*/
            public IntBasis SVA_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-OPERACAO-CONTA-DEB  PIC  9(004).*/
            public IntBasis SVA_OPERACAO_CONTA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-NUM-CONTA-DEBITO    PIC  9(012).*/
            public IntBasis SVA_NUM_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05            SVA-DIG-CONTA-DEBITO    PIC  9(001).*/
            public IntBasis SVA_DIG_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05            SVA-NUM-CARTAO-CREDITO  PIC  9(016).*/
            public IntBasis SVA_NUM_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"    05            SVA-PERIODICIDADE       PIC  X(010).*/
            public StringBasis SVA_PERIODICIDADE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            SVA-CODPRODU            PIC  9(004).*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-NUM-PLANO           PIC  9(003).*/
            public IntBasis SVA_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05            SVA-SORTEIO             PIC  X(009).*/
            public StringBasis SVA_SORTEIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"    05            SVA-FORMULARIO          PIC  X(008).*/
            public StringBasis SVA_FORMULARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77       WS-COD-PRODUTO           PIC S9(004)   COMP-5 VALUE 0.*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       W77-MES                  PIC  9(002)   VALUE 0.*/
        public IntBasis W77_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"77       CONTA-LINHAS             PIC  9(006)   VALUE 0.*/
        public IntBasis CONTA_LINHAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77       P                        PIC  9(002)   VALUE 0.*/
        public IntBasis P { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"77       LADO                     PIC  X(001)   VALUE 'E'.*/
        public StringBasis LADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"E");
        /*"77       VIND-NRCOPIAS            PIC S9(004)   COMP VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77       VIND-VLRCAP              PIC S9(004)   COMP VALUE -1.*/
        public IntBasis VIND_VLRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77       WACHOU-UNIC              PIC  X(001) VALUE SPACES.*/
        public StringBasis WACHOU_UNIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77       WIND-AGENCIA             PIC S9(004)   COMP.*/
        public IntBasis WIND_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       WIND-OPER                PIC S9(004)   COMP.*/
        public IntBasis WIND_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       WIND-CTADEB              PIC S9(004)   COMP.*/
        public IntBasis WIND_CTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       WIND-DGCTA               PIC S9(004)   COMP.*/
        public IntBasis WIND_DGCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       WIND-CARTAO              PIC S9(004)   COMP.*/
        public IntBasis WIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        W77-COD-PRODUTO    PIC  9(004)      VALUE ZEROS.*/
        public IntBasis W77_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77  WHOST-DATA-MOV-ABERTO         PIC  X(010)   VALUE SPACES.*/
        public StringBasis WHOST_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V1SIST-MESREFER               PIC S9(004)   COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1SIST-ANOREFER               PIC S9(004)   COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WIND-PRODUTO                  PIC S9(004)   COMP.*/
        public IntBasis WIND_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LINHAS-AMARRADO.*/
        public VE0414B_LINHAS_AMARRADO LINHAS_AMARRADO { get; set; } = new VE0414B_LINHAS_AMARRADO();
        public class VE0414B_LINHAS_AMARRADO : VarBasis
        {
            /*"   05  L1-JDT.*/
            public VE0414B_L1_JDT L1_JDT { get; set; } = new VE0414B_L1_JDT();
            public class VE0414B_L1_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(02)  VALUE '%!'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"%!");
                /*"   05  L2-JDT.*/
            }
            public VE0414B_L2_JDT L2_JDT { get; set; } = new VE0414B_L2_JDT();
            public class VE0414B_L2_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(18)  VALUE '(co05.jdt) STARTLM'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"(co05.jdt) STARTLM");
                /*"   05  L3-JDT.*/
            }
            public VE0414B_L3_JDT L3_JDT { get; set; } = new VE0414B_L3_JDT();
            public class VE0414B_L3_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  CONTRATO-ECT  PIC X(11)  VALUE '100134700-6'.*/
                public StringBasis CONTRATO_ECT { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"100134700-6");
                /*"   05  L4-JDT.*/
            }
            public VE0414B_L4_JDT L4_JDT { get; set; } = new VE0414B_L4_JDT();
            public class VE0414B_L4_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  USUARIO       PIC X(13)  VALUE 'CAIXA SEGUROS'.*/
                public StringBasis USUARIO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"CAIXA SEGUROS");
                /*"   05  L5-JDT.*/
            }
            public VE0414B_L5_JDT L5_JDT { get; set; } = new VE0414B_L5_JDT();
            public class VE0414B_L5_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  ENDERECO      PIC X(40)  VALUE    'SCN QUADRA 1 LOTE A ED.NUMBER ONE - 11 A'.*/
                public StringBasis ENDERECO_0 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"SCN QUADRA 1 LOTE A ED.NUMBER ONE - 11 A");
                /*"   05  L6-JDT.*/
            }
            public VE0414B_L6_JDT L6_JDT { get; set; } = new VE0414B_L6_JDT();
            public class VE0414B_L6_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  UNIDADE-DE-POSTAGEMT PIC X(13) VALUE 'BRASILIA - DF'.*/
                public StringBasis UNIDADE_DE_POSTAGEMT { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"BRASILIA - DF");
                /*"   05  L7-JDT.*/
            }
            public VE0414B_L7_JDT L7_JDT { get; set; } = new VE0414B_L7_JDT();
            public class VE0414B_L7_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  LISTAGEM-NUMERO        PIC X(15).*/
                public StringBasis LISTAGEM_NUMERO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"   05  L8-JDT.*/
            }
            public VE0414B_L8_JDT L8_JDT { get; set; } = new VE0414B_L8_JDT();
            public class VE0414B_L8_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  TIPO8-JDT  PIC X(29).*/
                public StringBasis TIPO8_JDT { get; set; } = new StringBasis(new PIC("X", "29", "X(29)."), @"");
                /*"   05  L9-JDT.*/
            }
            public VE0414B_L9_JDT L9_JDT { get; set; } = new VE0414B_L9_JDT();
            public class VE0414B_L9_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  DATA9-JDT     PIC X(10).*/
                public StringBasis DATA9_JDT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"   05  L10-JDT.*/
            }
            public VE0414B_L10_JDT L10_JDT { get; set; } = new VE0414B_L10_JDT();
            public class VE0414B_L10_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  NUCLEO        PIC X(13)  VALUE 'BRASILIA - DF'.*/
                public StringBasis NUCLEO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"BRASILIA - DF");
                /*"   05  L11-JDT.*/
            }
            public VE0414B_L11_JDT L11_JDT { get; set; } = new VE0414B_L11_JDT();
            public class VE0414B_L11_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  PAGINA11-JDT  PIC X(07).*/
                public StringBasis PAGINA11_JDT { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
                /*"   05  SEPARA-JDT        PIC X(03)  VALUE '1  '.*/
            }
            public StringBasis SEPARA_JDT { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"1  ");
            /*"01 TODAS-AS-LINHAS.*/
        }
        public VE0414B_TODAS_AS_LINHAS TODAS_AS_LINHAS { get; set; } = new VE0414B_TODAS_AS_LINHAS();
        public class VE0414B_TODAS_AS_LINHAS : VarBasis
        {
            /*"   05 LAISER-01       PIC X(02)     VALUE    '%!'.*/
            public StringBasis LAISER_01 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"%!");
            /*"   05 LAISER-02       PIC X(47)     VALUE    '%%DocumentMedia: papel1 595 842 75 white normal'.*/
            public StringBasis LAISER_02 { get; set; } = new StringBasis(new PIC("X", "47", "X(47)"), @"%%DocumentMedia: papel1 595 842 75 white normal");
            /*"   05 LAISER-03       PIC X(30)     VALUE    '%%+papel2 595 842 75 blue azul'.*/
            public StringBasis LAISER_03 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"%%+papel2 595 842 75 blue azul");
            /*"   05 LAISER-04       PIC X(25)     VALUE    '%%XRXrequeriments: duplex'.*/
            public StringBasis LAISER_04 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"%%XRXrequeriments: duplex");
            /*"   05 LAISER-05       PIC X(28)     VALUE    '%%BeginFeature: *Duplex True'.*/
            public StringBasis LAISER_05 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"%%BeginFeature: *Duplex True");
            /*"   05 LAISER-06       PIC X(30)     VALUE    '<</Duplex true>> setpagedevice'.*/
            public StringBasis LAISER_06 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"<</Duplex true>> setpagedevice");
            /*"   05 LAISER-07       PIC X(12)     VALUE    '%%EndFeature'.*/
            public StringBasis LAISER_07 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"%%EndFeature");
            /*"   05 LAISER-08       PIC X(12)     VALUE    '(|) SETDBSEP'.*/
            public StringBasis LAISER_08 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"(|) SETDBSEP");
            /*"   05 LAISER-09       PIC X(23)     VALUE    '(va55.dbm) STARTDBM'.*/
            public StringBasis LAISER_09 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"(va55.dbm) STARTDBM");
            /*"   05 VA46-HEADER.*/
            public VE0414B_VA46_HEADER VA46_HEADER { get; set; } = new VE0414B_VA46_HEADER();
            public class VE0414B_VA46_HEADER : VarBasis
            {
                /*"      10  FILLER      PIC X(50)     VALUE         'NUMPROPOSTA|APOLICE|SUBGRUPO|DTADESAO|DTEMISSAO|SU'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"NUMPROPOSTA|APOLICE|SUBGRUPO|DTADESAO|DTEMISSAO|SU");
                /*"      10  FILLER      PIC X(50)     VALUE         'BESTIPULANTE|CNPJ|AGENCIAVENDA|CONTA|DIACOB|CAPITA'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"BESTIPULANTE|CNPJ|AGENCIAVENDA|CONTA|DIACOB|CAPITA");
                /*"      10  FILLER      PIC X(50)     VALUE         'L|CUSTO|NUMVIDAS|COBERTURAB1|COBERTURAB2|COBERTURA'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"L|CUSTO|NUMVIDAS|COBERTURAB1|COBERTURAB2|COBERTURA");
                /*"      10  FILLER      PIC X(50)     VALUE         'B3|COBERTURAB4|COBERTURAB5|COBERTURAB6|COBERTURAB7'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"B3|COBERTURAB4|COBERTURAB5|COBERTURAB6|COBERTURAB7");
                /*"      10  FILLER      PIC X(50)     VALUE         '|COBERTURAB8|COBERTURAA1|COBERTURAA2|COBERTURAA3|C'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"|COBERTURAB8|COBERTURAA1|COBERTURAA2|COBERTURAA3|C");
                /*"      10  FILLER      PIC X(50)     VALUE         'OBERTURAA4|COBERTURAA5|COBERTURAA6|COBERTURAA7|COB'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"OBERTURAA4|COBERTURAA5|COBERTURAA6|COBERTURAA7|COB");
                /*"      10  FILLER      PIC X(38)     VALUE         'ERTURAA8|NUMOBJETO|DTPOSTAGEM|DESTINAT'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"ERTURAA8|NUMOBJETO|DTPOSTAGEM|DESTINAT");
                /*"      10  FILLER      PIC X(50)     VALUE         'ARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|REMET'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"ARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|REMET");
                /*"      10  FILLER      PIC X(50)     VALUE         '-ENDERECO|REMET-BAIRRO|REMET-CIDADE|REMET-UF|REMET'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"_ENDERECO|REMET_BAIRRO|REMET_CIDADE|REMET_UF|REMET");
                /*"      10  FILLER      PIC X(53)     VALUE         '-CEP|CODIGO-CIF|POSTNET|DATADIA|CLIENTE|PERIODICIDADE'*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "53", "X(53)"), @"_CEP|CODIGO_CIF|POSTNET|DATADIA|CLIENTE|PERIODICIDADE");
                /*"      10  FILLER      PIC X(20)     VALUE         '|SORTEIO|COD-PRODUTO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"|SORTEIO|COD_PRODUTO");
                /*"   05  VA46-DETALHE.*/
            }
            public VE0414B_VA46_DETALHE VA46_DETALHE { get; set; } = new VE0414B_VA46_DETALHE();
            public class VE0414B_VA46_DETALHE : VarBasis
            {
                /*"       10  VA46DET-NUM-PROPOSTA-ES PIC X(015).*/
                public StringBasis VA46DET_NUM_PROPOSTA_ES { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"       10  SEPARA-001              PIC X(001).*/
                public StringBasis SEPARA_001 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-NUM-APOLICE-ES  PIC X(013).*/
                public StringBasis VA46DET_NUM_APOLICE_ES { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"       10  SEPARA-002              PIC X(001).*/
                public StringBasis SEPARA_002 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-SUBG-ES         PIC X(005).*/
                public StringBasis VA46DET_SUBG_ES { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"       10  SEPARA-003              PIC X(001).*/
                public StringBasis SEPARA_003 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-DT-ADESAO-ES    PIC X(010).*/
                public StringBasis VA46DET_DT_ADESAO_ES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10  SEPARA-004              PIC X(001).*/
                public StringBasis SEPARA_004 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-DT-EMISSAO-ES   PIC X(010).*/
                public StringBasis VA46DET_DT_EMISSAO_ES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10  SEPARA-005              PIC X(001).*/
                public StringBasis SEPARA_005 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-EMPRESA-ES      PIC X(050).*/
                public StringBasis VA46DET_EMPRESA_ES { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"       10  SEPARA-006              PIC X(001).*/
                public StringBasis SEPARA_006 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-CNPJ-ES         PIC X(019).*/
                public StringBasis VA46DET_CNPJ_ES { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"       10  SEPARA-007              PIC X(001).*/
                public StringBasis SEPARA_007 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-COD-AGENCIA-ES  PIC X(009).*/
                public StringBasis VA46DET_COD_AGENCIA_ES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"       10  SEPARA-008              PIC X(001).*/
                public StringBasis SEPARA_008 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-NOME-AGEN-ES    PIC X(040).*/
                public StringBasis VA46DET_NOME_AGEN_ES { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10  SEPARA-009              PIC X(001).*/
                public StringBasis SEPARA_009 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-CONTA-CORR-ES   PIC X(024).*/
                public StringBasis VA46DET_CONTA_CORR_ES { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
                /*"       10  SEPARA-011              PIC X(001).*/
                public StringBasis SEPARA_011 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-DIA-COBRANCA    PIC X(002).*/
                public StringBasis VA46DET_DIA_COBRANCA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10  SEPARA-012              PIC X(001).*/
                public StringBasis SEPARA_012 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-IS-ES           PIC X(013) JUST RIGHT.*/
                public StringBasis VA46DET_IS_ES { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"       10  SEPARA-012-A            PIC X(001).*/
                public StringBasis SEPARA_012_A { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-CUSTO-ES        PIC X(013) JUST RIGHT.*/
                public StringBasis VA46DET_CUSTO_ES { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"       10  SEPARA-013              PIC X(001).*/
                public StringBasis SEPARA_013 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-N-VIDA-ES       PIC X(015).*/
                public StringBasis VA46DET_N_VIDA_ES { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"       10  SEPARA-014              PIC X(001).*/
                public StringBasis SEPARA_014 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-COBERTURAS OCCURS  08  TIMES.*/
                public ListBasis<VE0414B_VA46DET_COBERTURAS> VA46DET_COBERTURAS { get; set; } = new ListBasis<VE0414B_VA46DET_COBERTURAS>(08);
                public class VE0414B_VA46DET_COBERTURAS : VarBasis
                {
                    /*"           15  VA46DET-COBERTURA   PIC X(040).*/
                    public StringBasis VA46DET_COBERTURA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"           15  VA46DET-COB-SEPARA  PIC X(001).*/
                    public StringBasis VA46DET_COB_SEPARA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"       10  VA46DET-COBERTURAS-AC OCCURS  08  TIMES.*/
                }
                public ListBasis<VE0414B_VA46DET_COBERTURAS_AC> VA46DET_COBERTURAS_AC { get; set; } = new ListBasis<VE0414B_VA46DET_COBERTURAS_AC>(08);
                public class VE0414B_VA46DET_COBERTURAS_AC : VarBasis
                {
                    /*"           15  VA46DET-COBERTURA-AC   PIC X(040).*/
                    public StringBasis VA46DET_COBERTURA_AC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"           15  VA46DET-COB-SEPARA-AC  PIC X(001).*/
                    public StringBasis VA46DET_COB_SEPARA_AC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"       10  VA46DET-DT-POSTAGEM-ES  PIC X(010).*/
                }
                public StringBasis VA46DET_DT_POSTAGEM_ES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10  SEPARA-023              PIC X(001).*/
                public StringBasis SEPARA_023 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-NUM-OBJETO-ES   PIC X(007).*/
                public StringBasis VA46DET_NUM_OBJETO_ES { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"       10  SEPARA-025              PIC X(001).*/
                public StringBasis SEPARA_025 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-DESTINATARIO-ES PIC X(040).*/
                public StringBasis VA46DET_DESTINATARIO_ES { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10  SEPARA-026              PIC X(001).*/
                public StringBasis SEPARA_026 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-ENDERECO-ES     PIC X(072).*/
                public StringBasis VA46DET_ENDERECO_ES { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10  SEPARA-027              PIC X(001).*/
                public StringBasis SEPARA_027 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-BAIRRO-ES       PIC X(072).*/
                public StringBasis VA46DET_BAIRRO_ES { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10  SEPARA-028              PIC X(001).*/
                public StringBasis SEPARA_028 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-CIDADE-ES       PIC X(072).*/
                public StringBasis VA46DET_CIDADE_ES { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10  SEPARA-029              PIC X(001).*/
                public StringBasis SEPARA_029 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-UF-ES           PIC X(002).*/
                public StringBasis VA46DET_UF_ES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10  SEPARA-030              PIC X(001).*/
                public StringBasis SEPARA_030 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-CEP-ES          PIC X(009).*/
                public StringBasis VA46DET_CEP_ES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"       10  SEPARA-031              PIC X(001).*/
                public StringBasis SEPARA_031 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-RETENTE-ES      PIC X(040).*/
                public StringBasis VA46DET_RETENTE_ES { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10  SEPARA-032              PIC X(001).*/
                public StringBasis SEPARA_032 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-REMET-ENDE-ES   PIC X(040).*/
                public StringBasis VA46DET_REMET_ENDE_ES { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10  SEPARA-033              PIC X(001).*/
                public StringBasis SEPARA_033 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-REMET-BAIRRO-ES PIC X(020).*/
                public StringBasis VA46DET_REMET_BAIRRO_ES { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10  SEPARA-034              PIC X(001).*/
                public StringBasis SEPARA_034 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-REMET-CIDADE-ES PIC X(020).*/
                public StringBasis VA46DET_REMET_CIDADE_ES { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10  SEPARA-035              PIC X(001).*/
                public StringBasis SEPARA_035 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-REMET-UF-ES     PIC X(002).*/
                public StringBasis VA46DET_REMET_UF_ES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10  SEPARA-036              PIC X(001).*/
                public StringBasis SEPARA_036 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-REMET-CEP-ES    PIC X(009).*/
                public StringBasis VA46DET_REMET_CEP_ES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"       10  SEPARA-037              PIC X(001).*/
                public StringBasis SEPARA_037 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-CODIGO-CIF-ES   PIC X(034).*/
                public StringBasis VA46DET_CODIGO_CIF_ES { get; set; } = new StringBasis(new PIC("X", "34", "X(034)."), @"");
                /*"       10  SEPARA-038              PIC X(001).*/
                public StringBasis SEPARA_038 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-POSTNET-ES      PIC X(011).*/
                public StringBasis VA46DET_POSTNET_ES { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"       10  SEPARA-039              PIC X(001).*/
                public StringBasis SEPARA_039 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-DATADIA-ES      PIC X(030).*/
                public StringBasis VA46DET_DATADIA_ES { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"       10  SEPARA-040              PIC X(001).*/
                public StringBasis SEPARA_040 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-CLIENTE-ES      PIC X(090).*/
                public StringBasis VA46DET_CLIENTE_ES { get; set; } = new StringBasis(new PIC("X", "90", "X(090)."), @"");
                /*"       10  SEPARA-041                  PIC X(001).*/
                public StringBasis SEPARA_041 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-PERIODICIDADE-ES    PIC X(010).*/
                public StringBasis VA46DET_PERIODICIDADE_ES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10  SEPARA-042                  PIC X(001).*/
                public StringBasis SEPARA_042 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-SORTEIO             PIC X(009).*/
                public StringBasis VA46DET_SORTEIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"       10  SEPARA-043                  PIC X(001).*/
                public StringBasis SEPARA_043 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  VA46DET-COD-PRODUTO         PIC 9999.*/
                public IntBasis VA46DET_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"   05  LAISERFAC-FINAL  PIC X(05) VALUE    '%%EOF'.*/
            }
            public StringBasis LAISERFAC_FINAL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"%%EOF");
            /*"   05  FAC-01           PIC X(02) VALUE    '%!'.*/
            public StringBasis FAC_01 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"%!");
            /*"   05  FAC-02           PIC X(78) VALUE    '<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>> setpa    'gedevice'.*/
            public StringBasis FAC_02 { get; set; } = new StringBasis(new PIC("X", "78", "X(78)"), @"<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>> setpa    ");
            /*"   05  FAC-04           PIC X(12) VALUE    '(|) SETDBSEP'.*/
            public StringBasis FAC_04 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"(|) SETDBSEP");
            /*"   05  FAC-05           PIC X(19) VALUE    '(co04.dbm) STARTDBM'.*/
            public StringBasis FAC_05 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"(co04.dbm) STARTDBM");
            /*"   05  FAC-HEADER       PIC X(43) VALUE    'LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA'.*/
            public StringBasis FAC_HEADER { get; set; } = new StringBasis(new PIC("X", "43", "X(43)"), @"LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA");
            /*"   05  FAC-DETALHE.*/
            public VE0414B_FAC_DETALHE FAC_DETALHE { get; set; } = new VE0414B_FAC_DETALHE();
            public class VE0414B_FAC_DETALHE : VarBasis
            {
                /*"       10  CO04-DET-LOCALIDADE        PIC X(072).*/
                public StringBasis CO04_DET_LOCALIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10  SEPA-01                    PIC X(001).*/
                public StringBasis SEPA_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  CO04-DET-FAIXA             PIC X(023).*/
                public StringBasis CO04_DET_FAIXA { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"       10  SEPA-02                    PIC X(001).*/
                public StringBasis SEPA_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  CO04-DET-OBJETOS           PIC 9(003).*/
                public IntBasis CO04_DET_OBJETOS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  SEPA-03                    PIC X(001).*/
                public StringBasis SEPA_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  CO04-DET-AMARRADO          PIC 9(003).*/
                public IntBasis CO04_DET_AMARRADO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  SEPA-04                    PIC X(001).*/
                public StringBasis SEPA_04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  CO04-DET-SEQUENCIA         PIC X(015).*/
                public StringBasis CO04_DET_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"01  AREA-DE-WORK.*/
            }
        }
        public VE0414B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VE0414B_AREA_DE_WORK();
        public class VE0414B_AREA_DE_WORK : VarBasis
        {
            /*"05  WS-SIT-PRODUTO                PIC  9(001)   VALUE 0.*/

            public SelectorBasis WS_SIT_PRODUTO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 WS-PROD-RUNON                            VALUE 1. */
							new SelectorItemBasis("WS_PROD_RUNON", "1"),
							/*" 88 WS-PROD-RUNOFF                           VALUE 2. */
							new SelectorItemBasis("WS_PROD_RUNOFF", "2")
                }
            };

            /*"05  DET-JDE-VA46.*/
            public VE0414B_DET_JDE_VA46 DET_JDE_VA46 { get; set; } = new VE0414B_DET_JDE_VA46();
            public class VE0414B_DET_JDE_VA46 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(052)   VALUE       '$DJDE$ JDE=VA46,JDL=VA,END;'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"$DJDE$ JDE=VA46,JDL=VA,END;");
                /*"05  DET-JDE-1VZ6.*/
            }
            public VE0414B_DET_JDE_1VZ6 DET_JDE_1VZ6 { get; set; } = new VE0414B_DET_JDE_1VZ6();
            public class VE0414B_DET_JDE_1VZ6 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(052)   VALUE       '$DJDE$ JDE=1VZ6,JDL=DFAULT,END;'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"$DJDE$ JDE=1VZ6,JDL=DFAULT,END;");
                /*"05  LD00A.*/
            }
            public VE0414B_LD00A LD00A { get; set; } = new VE0414B_LD00A();
            public class VE0414B_LD00A : VarBasis
            {
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACE.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LD00A-DATADIA             PIC  X(030)   VALUE SPACES.*/
                public StringBasis LD00A_DATADIA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"05  LD00B.*/
            }
            public VE0414B_LD00B LD00B { get; set; } = new VE0414B_LD00B();
            public class VE0414B_LD00B : VarBasis
            {
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LD00B-NOME-CLIENTE        PIC  X(090)   VALUE SPACES.*/
                public StringBasis LD00B_NOME_CLIENTE { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"05  LD01.*/
            }
            public VE0414B_LD01 LD01 { get; set; } = new VE0414B_LD01();
            public class VE0414B_LD01 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACE.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LD01-NUM-PROPOSTA         PIC  ZZZZZZZZZZZZZZZ.*/
                public StringBasis LD01_NUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
                /*"    10  FILLER                    PIC  X(010)   VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10  LD01-NUM-APOLICE          PIC  9(013).*/
                public IntBasis LD01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10  FILLER                    PIC  X(014)   VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    10  LD01-SUBGRUPO             PIC  99999.*/
                public IntBasis LD01_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"    10  FILLER                    PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10  LD01-DATA-ADESAO.*/
                public VE0414B_LD01_DATA_ADESAO LD01_DATA_ADESAO { get; set; } = new VE0414B_LD01_DATA_ADESAO();
                public class VE0414B_LD01_DATA_ADESAO : VarBasis
                {
                    /*"        15  LD01-DIA-ADESAO       PIC  9(002).*/
                    public IntBasis LD01_DIA_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15  FILLER                PIC  X(001)   VALUE '.'.*/
                    public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15  LD01-MES-ADESAO       PIC  9(002).*/
                    public IntBasis LD01_MES_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15  FILLER                PIC  X(001)   VALUE '.'.*/
                    public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15  LD01-ANO-ADESAO       PIC  9(004).*/
                    public IntBasis LD01_ANO_ADESAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10  FILLER                    PIC  X(009)   VALUE SPACES.*/
                }
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10  LD01-DATA-EMISSAO.*/
                public VE0414B_LD01_DATA_EMISSAO LD01_DATA_EMISSAO { get; set; } = new VE0414B_LD01_DATA_EMISSAO();
                public class VE0414B_LD01_DATA_EMISSAO : VarBasis
                {
                    /*"        15  LD01-DIA-EMISSAO      PIC  9(002).*/
                    public IntBasis LD01_DIA_EMISSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15  FILLER                PIC  X(001)   VALUE '.'.*/
                    public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15  LD01-MES-EMISSAO      PIC  9(002).*/
                    public IntBasis LD01_MES_EMISSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15  FILLER                PIC  X(001)   VALUE '.'.*/
                    public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15  LD01-ANO-EMISSAO      PIC  9(004).*/
                    public IntBasis LD01_ANO_EMISSAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"05  LD02.*/
                }
            }
            public VE0414B_LD02 LD02 { get; set; } = new VE0414B_LD02();
            public class VE0414B_LD02 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACE.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LD02-NOME-EMPRESA         PIC  X(062).*/
                public StringBasis LD02_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "62", "X(062)."), @"");
                /*"    10  FILLER                    PIC  X(011)   VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10  CNPJ-INT.*/
                public VE0414B_CNPJ_INT CNPJ_INT { get; set; } = new VE0414B_CNPJ_INT();
                public class VE0414B_CNPJ_INT : VarBasis
                {
                    /*"     15 LD02-NRO-CGC              PIC  999.999.999.*/
                    public IntBasis LD02_NRO_CGC { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                    /*"     15 FILLER                    PIC  X(001)   VALUE '/'.*/
                    public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"     15 LD02-CNT-CGC              PIC  9999.*/
                    public IntBasis LD02_CNT_CGC { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"     15 FILLER                    PIC  X(001)   VALUE '-'.*/
                    public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"     15 LD02-DIG-CGC              PIC  99.*/
                    public IntBasis LD02_DIG_CGC { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"05  LD03.*/
                }
            }
            public VE0414B_LD03 LD03 { get; set; } = new VE0414B_LD03();
            public class VE0414B_LD03 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACE.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LD03-COD-AGENCIA          PIC  ZZZZZZZZZ.*/
                public StringBasis LD03_COD_AGENCIA { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZ."), @"");
                /*"    10  FILLER                    PIC  X(003)   VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10  LD03-NOME-AGENCIA         PIC  X(056).*/
                public StringBasis LD03_NOME_AGENCIA { get; set; } = new StringBasis(new PIC("X", "56", "X(056)."), @"");
                /*"05  LD04.*/
            }
            public VE0414B_LD04 LD04 { get; set; } = new VE0414B_LD04();
            public class VE0414B_LD04 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACE.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LD04-MODALIDADE           PIC  X(013).*/
                public StringBasis LD04_MODALIDADE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    10  FILLER                    PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10  LD04-PAGAMENTO            PIC  X(032).*/
                public StringBasis LD04_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "32", "X(032)."), @"");
                /*"05  LD05.*/
            }
            public VE0414B_LD05 LD05 { get; set; } = new VE0414B_LD05();
            public class VE0414B_LD05 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACE.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LD05-TIPO-COBERTURA       PIC  X(046).*/
                public StringBasis LD05_TIPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
                /*"    10  FILLER                    PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10  LD05-PLANO                PIC  X(032).*/
                public StringBasis LD05_PLANO { get; set; } = new StringBasis(new PIC("X", "32", "X(032)."), @"");
                /*"05  LD06.*/
            }
            public VE0414B_LD06 LD06 { get; set; } = new VE0414B_LD06();
            public class VE0414B_LD06 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACE.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LD06-PLANO-VG             PIC  ZZZZZZZZZ.*/
                public StringBasis LD06_PLANO_VG { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZ."), @"");
                /*"    10  FILLER                    PIC  X(004)   VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10  LD06-PLANO-AP             PIC  ZZZZZZZZ.*/
                public StringBasis LD06_PLANO_AP { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZ."), @"");
                /*"    10  FILLER                    PIC  X(003)   VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10  LD06-CAPITAL              PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD06_CAPITAL { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10  FILLER                    PIC  X(009)   VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10  LD06-CUSTO                PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD06_CUSTO { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10  FILLER                    PIC  X(014)   VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    10  LD06-VIDAS                PIC  ZZZZZZZZZZZZZ99.*/
                public IntBasis LD06_VIDAS { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZ99."));
                /*"05  LD07.*/
            }
            public VE0414B_LD07 LD07 { get; set; } = new VE0414B_LD07();
            public class VE0414B_LD07 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(002)   VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10  LD07-MSG                  PIC  X(060).*/
                public StringBasis LD07_MSG { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
                /*"05  BASICA-VGAPC.*/
            }
            public VE0414B_BASICA_VGAPC BASICA_VGAPC { get; set; } = new VE0414B_BASICA_VGAPC();
            public class VE0414B_BASICA_VGAPC : VarBasis
            {
                /*"    10  FILLER                    PIC  X(060)   VALUE       'MORTE QUALQUER CAUSA; MORTE ACIDENTAL; INV. PERM. P/ ACID       'E.;'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"MORTE QUALQUER CAUSA; MORTE ACIDENTAL; INV. PERM. P/ ACID       ");
                /*"05  BASICA-VG.*/
            }
            public VE0414B_BASICA_VG BASICA_VG { get; set; } = new VE0414B_BASICA_VG();
            public class VE0414B_BASICA_VG : VarBasis
            {
                /*"    10  FILLER                    PIC  X(040)   VALUE       'MORTE QUALQUER CAUSA; MORTE ACIDENTAL; '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"MORTE QUALQUER CAUSA; MORTE ACIDENTAL; ");
                /*"05  BASICA-APC.*/
            }
            public VE0414B_BASICA_APC BASICA_APC { get; set; } = new VE0414B_BASICA_APC();
            public class VE0414B_BASICA_APC : VarBasis
            {
                /*"    10  FILLER                    PIC  X(047)   VALUE       'MORTE ACIDENTAL; INV. PERMANENTE POR ACIDENTE; '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"MORTE ACIDENTAL; INV. PERMANENTE POR ACIDENTE; ");
                /*"05  ADIC-IEA.*/
            }
            public VE0414B_ADIC_IEA ADIC_IEA { get; set; } = new VE0414B_ADIC_IEA();
            public class VE0414B_ADIC_IEA : VarBasis
            {
                /*"    10  FILLER                    PIC  X(035)   VALUE       'INDENIZACAO ESPECIAL POR ACIDENTE; '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"INDENIZACAO ESPECIAL POR ACIDENTE; ");
                /*"05  ADIC-IPD.*/
            }
            public VE0414B_ADIC_IPD ADIC_IPD { get; set; } = new VE0414B_ADIC_IPD();
            public class VE0414B_ADIC_IPD : VarBasis
            {
                /*"    10  FILLER                    PIC  X(031)   VALUE       'INV. PERMANENTE POR DOENCA; '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"INV. PERMANENTE POR DOENCA; ");
                /*"05  ADIC-IPA.*/
            }
            public VE0414B_ADIC_IPA ADIC_IPA { get; set; } = new VE0414B_ADIC_IPA();
            public class VE0414B_ADIC_IPA : VarBasis
            {
                /*"    10  FILLER                    PIC  X(031)   VALUE       'INV. PERMANENTE POR ACIDENTE; '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"INV. PERMANENTE POR ACIDENTE; ");
                /*"05  ADIC-CONJUGE.*/
            }
            public VE0414B_ADIC_CONJUGE ADIC_CONJUGE { get; set; } = new VE0414B_ADIC_CONJUGE();
            public class VE0414B_ADIC_CONJUGE : VarBasis
            {
                /*"    10  FILLER                    PIC  X(018)   VALUE       'MORTE DO CONJUGE; '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"MORTE DO CONJUGE; ");
                /*"05  ADIC-FILHOS.*/
            }
            public VE0414B_ADIC_FILHOS ADIC_FILHOS { get; set; } = new VE0414B_ADIC_FILHOS();
            public class VE0414B_ADIC_FILHOS : VarBasis
            {
                /*"    10  FILLER                    PIC  X(018)   VALUE       'FILHOS; '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"FILHOS; ");
                /*"05  LC02-LINHA02.*/
            }
            public VE0414B_LC02_LINHA02 LC02_LINHA02 { get; set; } = new VE0414B_LC02_LINHA02();
            public class VE0414B_LC02_LINHA02 : VarBasis
            {
                /*"    10  LC02-CANAL                PIC  X(001)   VALUE '1'.*/
                public StringBasis LC02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  LC02-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LC02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(029)   VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"    10  LC02-DD-HOJE              PIC  9(002).*/
                public IntBasis LC02_DD_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LC02-MM-HOJE              PIC  X(012).*/
                public StringBasis LC02_MM_HOJE { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LC02-AA-HOJE              PIC  9(004).*/
                public IntBasis LC02_AA_HOJE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  FILLER                    PIC  X(001)   VALUE '.'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"05  LC03-LINHA03.*/
            }
            public VE0414B_LC03_LINHA03 LC03_LINHA03 { get; set; } = new VE0414B_LC03_LINHA03();
            public class VE0414B_LC03_LINHA03 : VarBasis
            {
                /*"    10  LC03-CANAL                PIC  X(001)   VALUE '2'.*/
                public StringBasis LC03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"    10  LC03-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LC03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(011)   VALUE SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10  LC03-NOME-RAZAO           PIC  X(045).*/
                public StringBasis LC03_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "45", "X(045)."), @"");
                /*"05  LC88-LINHA88.*/
            }
            public VE0414B_LC88_LINHA88 LC88_LINHA88 { get; set; } = new VE0414B_LC88_LINHA88();
            public class VE0414B_LC88_LINHA88 : VarBasis
            {
                /*"    10  LC88-CANAL                PIC  X(001)   VALUE '1'.*/
                public StringBasis LC88_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"05  LE01-LINHA01.*/
            }
            public VE0414B_LE01_LINHA01 LE01_LINHA01 { get; set; } = new VE0414B_LE01_LINHA01();
            public class VE0414B_LE01_LINHA01 : VarBasis
            {
                /*"    10  LE01-CANAL                PIC  X(001)   VALUE 'C'.*/
                public StringBasis LE01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
                /*"    10  LE01-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(036)   VALUE SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10  LE01-DTPOSTAGEM           PIC  X(010).*/
                public StringBasis LE01_DTPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10  FILLER                    PIC  X(002)   VALUE SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10  LE01-SEQUENCIA            PIC  X(007).*/
                public StringBasis LE01_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"05  LE02-LINHA02.*/
            }
            public VE0414B_LE02_LINHA02 LE02_LINHA02 { get; set; } = new VE0414B_LE02_LINHA02();
            public class VE0414B_LE02_LINHA02 : VarBasis
            {
                /*"    10  LE02-CANAL                PIC  X(001)   VALUE 'C'.*/
                public StringBasis LE02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
                /*"    10  LE02-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LE02-NOME-RAZAO           PIC  X(040).*/
                public StringBasis LE02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"05  LE03-LINHA03.*/
            }
            public VE0414B_LE03_LINHA03 LE03_LINHA03 { get; set; } = new VE0414B_LE03_LINHA03();
            public class VE0414B_LE03_LINHA03 : VarBasis
            {
                /*"    10  LE03-CANAL                PIC  X(001)   VALUE '0'.*/
                public StringBasis LE03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"    10  LE03-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LE03-ENDERECO             PIC  X(072).*/
                public StringBasis LE03_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"05  LE04-LINHA04.*/
            }
            public VE0414B_LE04_LINHA04 LE04_LINHA04 { get; set; } = new VE0414B_LE04_LINHA04();
            public class VE0414B_LE04_LINHA04 : VarBasis
            {
                /*"    10  LE04-CANAL                PIC  X(001)   VALUE '0'.*/
                public StringBasis LE04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"    10  LE04-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE04_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LE04-BAIRRO               PIC  X(072).*/
                public StringBasis LE04_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    10  FILLER                    PIC  X(002)   VALUE SPACES.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10  LE04-CIDADE               PIC  X(072).*/
                public StringBasis LE04_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    10  FILLER                    PIC  X(002)   VALUE SPACES.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10  LE04-UF                   PIC  X(002).*/
                public StringBasis LE04_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"05  LE05-LINHA05.*/
            }
            public VE0414B_LE05_LINHA05 LE05_LINHA05 { get; set; } = new VE0414B_LE05_LINHA05();
            public class VE0414B_LE05_LINHA05 : VarBasis
            {
                /*"    10  LE05-CANAL                PIC  X(001)   VALUE '0'.*/
                public StringBasis LE05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"    10  LE05-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE05_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  CEP-INT-DEST.*/
                public VE0414B_CEP_INT_DEST CEP_INT_DEST { get; set; } = new VE0414B_CEP_INT_DEST();
                public class VE0414B_CEP_INT_DEST : VarBasis
                {
                    /*"     15 LE05-CEP                  PIC  99999.*/
                    public IntBasis LE05_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                    /*"     15 FILLER                    PIC  X(001)   VALUE '-'.*/
                    public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"     15 LE05-CEP-COMPL            PIC  999.*/
                    public IntBasis LE05_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                    /*"05  LE00-LINHA00.*/
                }
            }
            public VE0414B_LE00_LINHA00 LE00_LINHA00 { get; set; } = new VE0414B_LE00_LINHA00();
            public class VE0414B_LE00_LINHA00 : VarBasis
            {
                /*"    10  LE00-CANAL                PIC  X(001)   VALUE 'C'.*/
                public StringBasis LE00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
                /*"    10  LE00-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE00_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(016)   VALUE SPACES.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"    10  LE00-GEPES                PIC  X(008)   VALUE                                 'GEPES - '.*/
                public StringBasis LE00_GEPES { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES - ");
                /*"    10  LE00-PRODUTO              PIC  X(032).*/
                public StringBasis LE00_PRODUTO { get; set; } = new StringBasis(new PIC("X", "32", "X(032)."), @"");
                /*"05  LE06-LINHA06.*/
            }
            public VE0414B_LE06_LINHA06 LE06_LINHA06 { get; set; } = new VE0414B_LE06_LINHA06();
            public class VE0414B_LE06_LINHA06 : VarBasis
            {
                /*"    10  LE06-CANAL                PIC  X(001)   VALUE '0'.*/
                public StringBasis LE06_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"    10  LE06-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE06_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(008)   VALUE SPACES.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10  REMET-INT.*/
                public VE0414B_REMET_INT REMET_INT { get; set; } = new VE0414B_REMET_INT();
                public class VE0414B_REMET_INT : VarBasis
                {
                    /*"     15 LE06-FILIAL               PIC  X(009)   VALUE                                 'FILIAL - '.*/
                    public StringBasis LE06_FILIAL { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FILIAL - ");
                    /*"     15 LE06-REMETENTE            PIC  X(031)   VALUE SPACES.*/
                    public StringBasis LE06_REMETENTE { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"");
                    /*"05  LE07-LINHA07.*/
                }
            }
            public VE0414B_LE07_LINHA07 LE07_LINHA07 { get; set; } = new VE0414B_LE07_LINHA07();
            public class VE0414B_LE07_LINHA07 : VarBasis
            {
                /*"    10  LE07-CANAL                PIC  X(001)   VALUE '0'.*/
                public StringBasis LE07_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"    10  LE07-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE07_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(008)   VALUE SPACES.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10  LE07-ENDERECO             PIC  X(040).*/
                public StringBasis LE07_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"05  LE08-LINHA08.*/
            }
            public VE0414B_LE08_LINHA08 LE08_LINHA08 { get; set; } = new VE0414B_LE08_LINHA08();
            public class VE0414B_LE08_LINHA08 : VarBasis
            {
                /*"    10  LE08-CANAL                PIC  X(001)   VALUE '0'.*/
                public StringBasis LE08_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"    10  LE08-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE08_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(008)   VALUE SPACES.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10  LE08-BAIRRO               PIC  X(020).*/
                public StringBasis LE08_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10  FILLER                    PIC  X(002)   VALUE SPACES.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10  LE08-CIDADE               PIC  X(020).*/
                public StringBasis LE08_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10  FILLER                    PIC  X(002)   VALUE SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10  LE08-UF                   PIC  X(002).*/
                public StringBasis LE08_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"05  LE09-LINHA09.*/
            }
            public VE0414B_LE09_LINHA09 LE09_LINHA09 { get; set; } = new VE0414B_LE09_LINHA09();
            public class VE0414B_LE09_LINHA09 : VarBasis
            {
                /*"    10  LE09-CANAL                PIC  X(001)   VALUE '0'.*/
                public StringBasis LE09_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"    10  LE09-FONTE                PIC  X(001)   VALUE '1'.*/
                public StringBasis LE09_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    10  FILLER                    PIC  X(008)   VALUE SPACES.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10  CEP-INT-REMET.*/
                public VE0414B_CEP_INT_REMET CEP_INT_REMET { get; set; } = new VE0414B_CEP_INT_REMET();
                public class VE0414B_CEP_INT_REMET : VarBasis
                {
                    /*"     15 LE09-CEP                  PIC  99999.*/
                    public IntBasis LE09_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                    /*"     15 FILLER                    PIC  X(001)   VALUE '-'.*/
                    public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"     15 LE09-CEP-COMPL            PIC  999.*/
                    public IntBasis LE09_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                    /*"05  LF01-LINHA01.*/
                }
            }
            public VE0414B_LF01_LINHA01 LF01_LINHA01 { get; set; } = new VE0414B_LF01_LINHA01();
            public class VE0414B_LF01_LINHA01 : VarBasis
            {
                /*"    10  LF01-CANAL                PIC  X(001)   VALUE '+'.*/
                public StringBasis LF01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10  LF01-FONTE                PIC  X(001)   VALUE ' '.*/
                public StringBasis LF01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    10  FILLER                    PIC  X(070)   VALUE       '$DJDE$ JDE=FACPEQ,JDL=VIDAZ,FEED=AUX,END;'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"$DJDE$ JDE=FACPEQ,JDL=VIDAZ,FEED=AUX,END;");
                /*"05  LF02-LINHA02.*/
            }
            public VE0414B_LF02_LINHA02 LF02_LINHA02 { get; set; } = new VE0414B_LF02_LINHA02();
            public class VE0414B_LF02_LINHA02 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LF02-NOME-FAIXA           PIC  X(072).*/
                public StringBasis LF02_NOME_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"05  LF03-LINHA03.*/
            }
            public VE0414B_LF03_LINHA03 LF03_LINHA03 { get; set; } = new VE0414B_LF03_LINHA03();
            public class VE0414B_LF03_LINHA03 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10  FAIXA-INT.*/
                public VE0414B_FAIXA_INT FAIXA_INT { get; set; } = new VE0414B_FAIXA_INT();
                public class VE0414B_FAIXA_INT : VarBasis
                {
                    /*"     15 LF03-FAIXA1               PIC  X(005).*/
                    public StringBasis LF03_FAIXA1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                    /*"     15 FILLER                    PIC  X(001)   VALUE '-'.*/
                    public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"     15 LF03-FAIXA1C              PIC  X(003).*/
                    public StringBasis LF03_FAIXA1C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"     15 FILLER                    PIC  X(005)   VALUE '  A '.*/
                    public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  A ");
                    /*"     15 LF03-FAIXA2               PIC  X(005).*/
                    public StringBasis LF03_FAIXA2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                    /*"     15 FILLER                    PIC  X(001)   VALUE '-'.*/
                    public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"     15 LF03-FAIXA2C              PIC  X(003).*/
                    public StringBasis LF03_FAIXA2C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"05  LF04-LINHA04.*/
                }
            }
            public VE0414B_LF04_LINHA04 LF04_LINHA04 { get; set; } = new VE0414B_LF04_LINHA04();
            public class VE0414B_LF04_LINHA04 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(003)   VALUE SPACES.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10  LF04-QTD-OBJ              PIC  9(003).*/
                public IntBasis LF04_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"05  LF05-LINHA05.*/
            }
            public VE0414B_LF05_LINHA05 LF05_LINHA05 { get; set; } = new VE0414B_LF05_LINHA05();
            public class VE0414B_LF05_LINHA05 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(003)   VALUE SPACES.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10  LF05-AMARRADO             PIC  ZZZ.999.*/
                public IntBasis LF05_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(013)   VALUE SPACES.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10  SE-INT.*/
                public VE0414B_SE_INT SE_INT { get; set; } = new VE0414B_SE_INT();
                public class VE0414B_SE_INT : VarBasis
                {
                    /*"     15 LF05-SEQ-INICIAL          PIC  ZZZ.999.*/
                    public IntBasis LF05_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                    /*"     15 FILLER                    PIC  X(001)   VALUE '/'.*/
                    public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"     15 LF05-SEQ-FINAL            PIC  ZZZ.999.*/
                    public IntBasis LF05_SEQ_FINAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                    /*"05  LR01-LINHA01.*/
                }
            }
            public VE0414B_LR01_LINHA01 LR01_LINHA01 { get; set; } = new VE0414B_LR01_LINHA01();
            public class VE0414B_LR01_LINHA01 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(070)   VALUE       '$DJDE$ JDE=FACLST,JDL=VIDAZ,END;'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"$DJDE$ JDE=FACLST,JDL=VIDAZ,END;");
                /*"05  LR02-LINHA02.*/
            }
            public VE0414B_LR02_LINHA02 LR02_LINHA02 { get; set; } = new VE0414B_LR02_LINHA02();
            public class VE0414B_LR02_LINHA02 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(090)   VALUE SPACES.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"    10  LISTAGEM-INT.*/
                public VE0414B_LISTAGEM_INT LISTAGEM_INT { get; set; } = new VE0414B_LISTAGEM_INT();
                public class VE0414B_LISTAGEM_INT : VarBasis
                {
                    /*"     15 LR02-SEQ                  PIC  ZZ9.*/
                    public IntBasis LR02_SEQ { get; set; } = new IntBasis(new PIC("9", "3", "ZZ9."));
                    /*"     15 FILLER                    PIC  X(003)   VALUE ' / '.*/
                    public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" / ");
                    /*"     15 LR02-MES                  PIC  X(009).*/
                    public StringBasis LR02_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                    /*"    10  FILLER                    PIC  X(017)   VALUE SPACES.*/
                }
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"    10  LR02-PAG-INT.*/
                public VE0414B_LR02_PAG_INT LR02_PAG_INT { get; set; } = new VE0414B_LR02_PAG_INT();
                public class VE0414B_LR02_PAG_INT : VarBasis
                {
                    /*"     15 LR02-PAGINA               PIC  999.*/
                    public IntBasis LR02_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                    /*"     15 FILLER                    PIC  X(001)   VALUE '/'.*/
                    public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"     15 LR02-PAG-FINAL            PIC  999      VALUE 003.*/
                    public IntBasis LR02_PAG_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "999"), 003);
                    /*"05  LR03-LINHA03.*/
                }
            }
            public VE0414B_LR03_LINHA03 LR03_LINHA03 { get; set; } = new VE0414B_LR03_LINHA03();
            public class VE0414B_LR03_LINHA03 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(100)   VALUE SPACES.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"    10  LR03-GEPES                PIC  X(008)   VALUE                                 'GEPES - '.*/
                public StringBasis LR03_GEPES { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES - ");
                /*"    10  LR03-TP-PGTO              PIC  X(022)   VALUE SPACES.*/
                public StringBasis LR03_TP_PGTO { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"05  LR04-LINHA04.*/
            }
            public VE0414B_LR04_LINHA04 LR04_LINHA04 { get; set; } = new VE0414B_LR04_LINHA04();
            public class VE0414B_LR04_LINHA04 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(086)   VALUE SPACES.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"");
                /*"    10  LR04-DATA                 PIC  X(010).*/
                public StringBasis LR04_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"05  LR05-LINHA05.*/
            }
            public VE0414B_LR05_LINHA05 LR05_LINHA05 { get; set; } = new VE0414B_LR05_LINHA05();
            public class VE0414B_LR05_LINHA05 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(004)   VALUE SPACES.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LR05-CEPI                 PIC  9(005).*/
                public IntBasis LR05_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10  FILLER                    PIC  X(001)   VALUE '-'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  LR05-COMPL-CEPI           PIC  9(003).*/
                public IntBasis LR05_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10  FILLER                    PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10  LR05-CEPF                 PIC  9(005).*/
                public IntBasis LR05_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10  FILLER                    PIC  X(001)   VALUE '-'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  LR05-COMPL-CEPF           PIC  9(003).*/
                public IntBasis LR05_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10  FILLER                    PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10  LR05-OBJI                 PIC  ZZZ.999.*/
                public IntBasis LR05_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LR05-OBJF                 PIC  ZZZ.999.*/
                public IntBasis LR05_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(005)   VALUE SPACES.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10  LR05-AMARI                PIC  ZZZ.999.*/
                public IntBasis LR05_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(005)   VALUE SPACES.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10  LR05-AMARF                PIC  ZZZ.999.*/
                public IntBasis LR05_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(005)   VALUE SPACES.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10  LR05-QTD-OBJ              PIC  ZZZ.999.*/
                public IntBasis LR05_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LR05-QTD-AMAR             PIC  ZZZ.999.*/
                public IntBasis LR05_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(004)   VALUE SPACES.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10  LR05-OBS                  PIC  X(023).*/
                public StringBasis LR05_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"05  LR06-LINHA06.*/
            }
            public VE0414B_LR06_LINHA06 LR06_LINHA06 { get; set; } = new VE0414B_LR06_LINHA06();
            public class VE0414B_LR06_LINHA06 : VarBasis
            {
                /*"    10  FILLER                    PIC  X(004)   VALUE SPACES.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10  FILLER                    PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  LR06-CEPI                 PIC  9(005).*/
                public IntBasis LR06_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10  FILLER                    PIC  X(001)   VALUE '-'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  LR06-COMPL-CEPI           PIC  9(003).*/
                public IntBasis LR06_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10  FILLER                    PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10  LR06-CEPF                 PIC  9(005).*/
                public IntBasis LR06_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10  FILLER                    PIC  X(001)   VALUE '-'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  LR06-COMPL-CEPF           PIC  9(003).*/
                public IntBasis LR06_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10  FILLER                    PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10  LR06-OBJI                 PIC  ZZZ.999.*/
                public IntBasis LR06_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LR06-OBJF                 PIC  ZZZ.999.*/
                public IntBasis LR06_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(005)   VALUE SPACES.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10  LR06-AMARI                PIC  ZZZ.999.*/
                public IntBasis LR06_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(005)   VALUE SPACES.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10  LR06-AMARF                PIC  ZZZ.999.*/
                public IntBasis LR06_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(005)   VALUE SPACES.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10  LR06-QTD-OBJ              PIC  ZZZ.999.*/
                public IntBasis LR06_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(006)   VALUE SPACES.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10  LR06-QTD-AMAR             PIC  ZZZ.999.*/
                public IntBasis LR06_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                    PIC  X(004)   VALUE SPACES.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10  LR06-OBS                  PIC  X(023).*/
                public StringBasis LR06_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"05        WS-FORM-LINHA           PIC  X(023) VALUE SPACES.*/
            }
            public StringBasis WS_FORM_LINHA { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
            /*"05        WS-NRTITFED            PIC  9(012)    VALUE ZEROS.*/
            public IntBasis WS_NRTITFED { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
            /*"05        FILLER              REDEFINES     WS-NRTITFED.*/
            private _REDEF_VE0414B_FILLER_122 _filler_122 { get; set; }
            public _REDEF_VE0414B_FILLER_122 FILLER_122
            {
                get { _filler_122 = new _REDEF_VE0414B_FILLER_122(); _.Move(WS_NRTITFED, _filler_122); VarBasis.RedefinePassValue(WS_NRTITFED, _filler_122, WS_NRTITFED); _filler_122.ValueChanged += () => { _.Move(_filler_122, WS_NRTITFED); }; return _filler_122; }
                set { VarBasis.RedefinePassValue(value, _filler_122, WS_NRTITFED); }
            }  //Redefines
            public class _REDEF_VE0414B_FILLER_122 : VarBasis
            {
                /*"  15      WS-NRTITFED-PLANO      PIC  9(003).*/
                public IntBasis WS_NRTITFED_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  15      WS-NRTITFED-COMPL      PIC  9(009).*/
                public IntBasis WS_NRTITFED_COMPL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"05  AC-LINHAS                     PIC  9(002)   VALUE 80.*/

                public _REDEF_VE0414B_FILLER_122()
                {
                    WS_NRTITFED_PLANO.ValueChanged += OnValueChanged;
                    WS_NRTITFED_COMPL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"05        WWORK-QTDE01.*/
            public VE0414B_WWORK_QTDE01 WWORK_QTDE01 { get; set; } = new VE0414B_WWORK_QTDE01();
            public class VE0414B_WWORK_QTDE01 : VarBasis
            {
                /*"   10     WWORK-QTDE11            PIC  9(004).*/
                public IntBasis WWORK_QTDE11 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10     WWORK-QTDE12            PIC  9(002).*/
                public IntBasis WWORK_QTDE12 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"05        WWORK-QTDE  REDEFINES  WWORK-QTDE01                                  PIC S9(004)V99.*/
            }
            private _REDEF_DoubleBasis _wwork_qtde { get; set; }
            public _REDEF_DoubleBasis WWORK_QTDE
            {
                get { _wwork_qtde = new _REDEF_DoubleBasis(new PIC("S9", "004", "S9(004)V99."), 2); ; _.Move(WWORK_QTDE01, _wwork_qtde); VarBasis.RedefinePassValue(WWORK_QTDE01, _wwork_qtde, WWORK_QTDE01); _wwork_qtde.ValueChanged += () => { _.Move(_wwork_qtde, WWORK_QTDE01); }; return _wwork_qtde; }
                set { VarBasis.RedefinePassValue(value, _wwork_qtde, WWORK_QTDE01); }
            }  //Redefines
            /*"05  WS-COUNT                      PIC  9(002)   VALUE ZEROS.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"05  WHOST-PROXIMA-DATA            PIC  X(010)   VALUE SPACES.*/
            public StringBasis WHOST_PROXIMA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"05  AC-PAGINA                     PIC  9(003)   VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"05  AC-CONTA1                     PIC  9(006)   VALUE ZEROS.*/
            public IntBasis AC_CONTA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"05  AC-I-RELATORIOS               PIC S9(005)   COMP-3 VALUE +0.*/
            public IntBasis AC_I_RELATORIOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"05  WS-OCORR                      PIC  9(006)   VALUE ZEROS.*/
            public IntBasis WS_OCORR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"05  WS-AMARRADO                   PIC  9(006)   VALUE ZEROS.*/
            public IntBasis WS_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"05  WS-SEQ                        PIC  9(006)   VALUE ZEROS.*/
            public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"05  WS-SEQ-INICIAL                PIC  9(006)   VALUE ZEROS.*/
            public IntBasis WS_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"05  AC-QTD-OBJ                    PIC  9(006)   VALUE ZEROS.*/
            public IntBasis AC_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"05  WS-CONTR-AMAR                 PIC  9(006)   VALUE ZEROS.*/
            public IntBasis WS_CONTR_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"05  WS-CONTR-OBJ                  PIC  9(006)   VALUE ZEROS.*/
            public IntBasis WS_CONTR_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"05  WS-CONTR-200                  PIC  9(006)   VALUE ZEROS.*/
            public IntBasis WS_CONTR_200 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"05  WS-CONTR-PRODU                PIC  X(001).*/
            public StringBasis WS_CONTR_PRODU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"05  WS-CEP-G-ANT                  PIC  9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"05  WS-NOME-COR-ANT.*/
            public VE0414B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new VE0414B_WS_NOME_COR_ANT();
            public class VE0414B_WS_NOME_COR_ANT : VarBasis
            {
                /*"  10  WS-FAIXA1-ANT               PIC  9(008).*/
                public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  10  WS-FAIXA2-ANT               PIC  9(008).*/
                public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  10  WS-NOME-ANT                 PIC  X(030).*/
                public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"05  WS-CEP-ANT                    PIC  9(005).*/
            }
            public IntBasis WS_CEP_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"05  WS-COMPL-ANT                  PIC  9(003).*/
            public IntBasis WS_COMPL_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"05  WS-INF                        PIC  9(009).*/
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"05  WS-SUP                        PIC  9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"05  WIND                          PIC S9(004)   VALUE +0 COMP.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"05  IDX1                          PIC S9(004)   VALUE +0 COMP.*/
            public IntBasis IDX1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"05  IDX2                          PIC S9(004)   VALUE +0 COMP.*/
            public IntBasis IDX2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"05  IDX3                          PIC S9(004)   VALUE +0 COMP.*/
            public IntBasis IDX3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"05  IDX4                          PIC S9(004)   VALUE +0 COMP.*/
            public IntBasis IDX4 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"05  IDX5                          PIC S9(004)   VALUE +0 COMP.*/
            public IntBasis IDX5 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"05  IDX6                          PIC S9(004)   VALUE +0 COMP.*/
            public IntBasis IDX6 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"05  IDX7                          PIC S9(004)   VALUE +0 COMP.*/
            public IntBasis IDX7 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"05  IDXN                    PIC  9(002)   VALUE  0.*/
            public IntBasis IDXN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"05  DEST-NUM-CEP.*/
            public VE0414B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new VE0414B_DEST_NUM_CEP();
            public class VE0414B_DEST_NUM_CEP : VarBasis
            {
                /*"  15  DEST-CEP                    PIC  9(005)   VALUE ZEROS.*/
                public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"  15  DEST-CEP-COMPL              PIC  9(003)   VALUE ZEROS.*/
                public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05        WWRK-CODPRODU       PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WWRK_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05        DESW-NUM-CEP        PIC  9(008)    VALUE ZEROS.*/
                public IntBasis DESW_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    05        FILLER              REDEFINES      DESW-NUM-CEP.*/
                private _REDEF_VE0414B_FILLER_123 _filler_123 { get; set; }
                public _REDEF_VE0414B_FILLER_123 FILLER_123
                {
                    get { _filler_123 = new _REDEF_VE0414B_FILLER_123(); _.Move(DESW_NUM_CEP, _filler_123); VarBasis.RedefinePassValue(DESW_NUM_CEP, _filler_123, DESW_NUM_CEP); _filler_123.ValueChanged += () => { _.Move(_filler_123, DESW_NUM_CEP); }; return _filler_123; }
                    set { VarBasis.RedefinePassValue(value, _filler_123, DESW_NUM_CEP); }
                }  //Redefines
                public class _REDEF_VE0414B_FILLER_123 : VarBasis
                {
                    /*"      15      DESW-CEP            PIC  9(005).*/
                    public IntBasis DESW_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15      DESW-CEP-COMPL      PIC  9(003).*/
                    public IntBasis DESW_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"05  CGC                           PIC  9(015).*/

                    public _REDEF_VE0414B_FILLER_123()
                    {
                        DESW_CEP.ValueChanged += OnValueChanged;
                        DESW_CEP_COMPL.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public IntBasis CGC { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
        /*"05  CGC-R                         REDEFINES  CGC.*/
        private _REDEF_VE0414B_CGC_R _cgc_r { get; set; }
        public _REDEF_VE0414B_CGC_R CGC_R
        {
            get { _cgc_r = new _REDEF_VE0414B_CGC_R(); _.Move(CGC, _cgc_r); VarBasis.RedefinePassValue(CGC, _cgc_r, CGC); _cgc_r.ValueChanged += () => { _.Move(_cgc_r, CGC); }; return _cgc_r; }
            set { VarBasis.RedefinePassValue(value, _cgc_r, CGC); }
        }  //Redefines
        public class _REDEF_VE0414B_CGC_R : VarBasis
        {
            /*"  10  NRO-CGC                     PIC  9(009).*/
            public IntBasis NRO_CGC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  10  CNT-CGC                     PIC  9(004).*/
            public IntBasis CNT_CGC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10  DIG-CGC                     PIC  9(002).*/
            public IntBasis DIG_CGC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"05  WS-DATA-SQL.*/

            public _REDEF_VE0414B_CGC_R()
            {
                NRO_CGC.ValueChanged += OnValueChanged;
                CNT_CGC.ValueChanged += OnValueChanged;
                DIG_CGC.ValueChanged += OnValueChanged;
            }

        }
        public VE0414B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VE0414B_WS_DATA_SQL();
        public class VE0414B_WS_DATA_SQL : VarBasis
        {
            /*"  10  WS-ANO-SQL                  PIC  9(004).*/
            public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10  FILLER                      PIC  X(001).*/
            public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-MES-SQL                  PIC  9(002)   VALUE ZEROS.*/
            public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10  FILLER                      PIC  X(001).*/
            public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-DIA-SQL                  PIC  9(002)   VALUE ZEROS.*/
            public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"05  WS-DATA.*/
        }
        public VE0414B_WS_DATA WS_DATA { get; set; } = new VE0414B_WS_DATA();
        public class VE0414B_WS_DATA : VarBasis
        {
            /*"  10  WS-ANO                      PIC  9(004)   VALUE ZEROS.*/
            public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10  FILLER                      PIC  X(001)   VALUE SPACE.*/
            public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  10  WS-MES                      PIC  9(002)   VALUE ZEROS.*/
            public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10  FILLER                      PIC  X(001)   VALUE SPACE.*/
            public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  10  WS-DIA                      PIC  9(002)   VALUE ZEROS.*/
            public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"05  WS-DATA-I.*/
        }
        public VE0414B_WS_DATA_I WS_DATA_I { get; set; } = new VE0414B_WS_DATA_I();
        public class VE0414B_WS_DATA_I : VarBasis
        {
            /*"  10  WS-DIA-I                    PIC  9(002)   VALUE ZEROS.*/
            public IntBasis WS_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10  FILLERB1                    PIC  X(001).*/
            public StringBasis FILLERB1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-MES-I                    PIC  9(002)   VALUE ZEROS.*/
            public IntBasis WS_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10  FILLERB2                    PIC  X(001).*/
            public StringBasis FILLERB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-ANO-I                    PIC  9(004)   VALUE ZEROS.*/
            public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"05  WHORA-CURR                    PIC  9(006)   VALUE ZEROS.*/
        }
        public IntBasis WHORA_CURR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"05  WHORA-CURR-DISP               PIC  99.99.99 .*/
        public IntBasis WHORA_CURR_DISP { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99"));
        /*"05  WS-NOME-RAZAO.*/
        public VE0414B_WS_NOME_RAZAO WS_NOME_RAZAO { get; set; } = new VE0414B_WS_NOME_RAZAO();
        public class VE0414B_WS_NOME_RAZAO : VarBasis
        {
            /*"  10  WS-LETRA-NOME               OCCURS        41 TIMES                                  PIC  X(001).*/
            public ListBasis<StringBasis, string> WS_LETRA_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 41);
            /*"05  WS-NUM-CEP-AUX                PIC  9(008).*/
        }
        public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"05  WS-NUM-CEP-AUX-R              REDEFINES      WS-NUM-CEP-AUX.*/
        private _REDEF_VE0414B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
        public _REDEF_VE0414B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
        {
            get { _ws_num_cep_aux_r = new _REDEF_VE0414B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
            set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
        }  //Redefines
        public class _REDEF_VE0414B_WS_NUM_CEP_AUX_R : VarBasis
        {
            /*"  10  WS-CEP-AUX                  PIC  9(005).*/
            public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10  WS-CEP-COMPL-AUX            PIC  9(003).*/
            public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"05  WS-NUM-CEP-AUX-R1             REDEFINES      WS-NUM-CEP-AUX.*/

            public _REDEF_VE0414B_WS_NUM_CEP_AUX_R()
            {
                WS_CEP_AUX.ValueChanged += OnValueChanged;
                WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
            }

        }
        private _REDEF_VE0414B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
        public _REDEF_VE0414B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
        {
            get { _ws_num_cep_aux_r1 = new _REDEF_VE0414B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
            set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
        }  //Redefines
        public class _REDEF_VE0414B_WS_NUM_CEP_AUX_R1 : VarBasis
        {
            /*"  10  WS-CEP-COMPL-AUX1           PIC  9(003).*/
            public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10  WS-CEP-AUX1                 PIC  9(005).*/
            public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"05  WS-OPCAO-PAGAMENTO            PIC X(024).*/

            public _REDEF_VE0414B_WS_NUM_CEP_AUX_R1()
            {
                WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                WS_CEP_AUX1.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
        /*"05  WS-CONTA-CORRENTE             REDEFINES      WS-OPCAO-PAGAMENTO.*/
        private _REDEF_VE0414B_WS_CONTA_CORRENTE _ws_conta_corrente { get; set; }
        public _REDEF_VE0414B_WS_CONTA_CORRENTE WS_CONTA_CORRENTE
        {
            get { _ws_conta_corrente = new _REDEF_VE0414B_WS_CONTA_CORRENTE(); _.Move(WS_OPCAO_PAGAMENTO, _ws_conta_corrente); VarBasis.RedefinePassValue(WS_OPCAO_PAGAMENTO, _ws_conta_corrente, WS_OPCAO_PAGAMENTO); _ws_conta_corrente.ValueChanged += () => { _.Move(_ws_conta_corrente, WS_OPCAO_PAGAMENTO); }; return _ws_conta_corrente; }
            set { VarBasis.RedefinePassValue(value, _ws_conta_corrente, WS_OPCAO_PAGAMENTO); }
        }  //Redefines
        public class _REDEF_VE0414B_WS_CONTA_CORRENTE : VarBasis
        {
            /*"  10  WS-AGECTADEB                PIC 9(004).*/
            public IntBasis WS_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10  WS-PONTO1                   PIC X(001).*/
            public StringBasis WS_PONTO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-OPRCTADEB                PIC 9(004).*/
            public IntBasis WS_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10  WS-PONTO2                   PIC X(001).*/
            public StringBasis WS_PONTO2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-NUMCTADEB                PIC 9(012).*/
            public IntBasis WS_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  10  WS-TRACO                    PIC X(001).*/
            public StringBasis WS_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-DIGCTADEB                PIC 9(001).*/
            public IntBasis WS_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"05  WS-CARTAO-CREDITO             REDEFINES      WS-OPCAO-PAGAMENTO.*/

            public _REDEF_VE0414B_WS_CONTA_CORRENTE()
            {
                WS_AGECTADEB.ValueChanged += OnValueChanged;
                WS_PONTO1.ValueChanged += OnValueChanged;
                WS_OPRCTADEB.ValueChanged += OnValueChanged;
                WS_PONTO2.ValueChanged += OnValueChanged;
                WS_NUMCTADEB.ValueChanged += OnValueChanged;
                WS_TRACO.ValueChanged += OnValueChanged;
                WS_DIGCTADEB.ValueChanged += OnValueChanged;
            }

        }
        private _REDEF_VE0414B_WS_CARTAO_CREDITO _ws_cartao_credito { get; set; }
        public _REDEF_VE0414B_WS_CARTAO_CREDITO WS_CARTAO_CREDITO
        {
            get { _ws_cartao_credito = new _REDEF_VE0414B_WS_CARTAO_CREDITO(); _.Move(WS_OPCAO_PAGAMENTO, _ws_cartao_credito); VarBasis.RedefinePassValue(WS_OPCAO_PAGAMENTO, _ws_cartao_credito, WS_OPCAO_PAGAMENTO); _ws_cartao_credito.ValueChanged += () => { _.Move(_ws_cartao_credito, WS_OPCAO_PAGAMENTO); }; return _ws_cartao_credito; }
            set { VarBasis.RedefinePassValue(value, _ws_cartao_credito, WS_OPCAO_PAGAMENTO); }
        }  //Redefines
        public class _REDEF_VE0414B_WS_CARTAO_CREDITO : VarBasis
        {
            /*"  10  WS-FILLER                   PIC 9(005).*/
            public IntBasis WS_FILLER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10  WS-CCRED1                   PIC 9(004).*/
            public IntBasis WS_CCRED1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10  WS-CCRED1-PTO               PIC X(001).*/
            public StringBasis WS_CCRED1_PTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-CCRED2                   PIC 9(004).*/
            public IntBasis WS_CCRED2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10  WS-CCRED2-PTO               PIC X(001).*/
            public StringBasis WS_CCRED2_PTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-CCRED3                   PIC 9(004).*/
            public IntBasis WS_CCRED3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10  WS-CCRED3-PTO               PIC X(001).*/
            public StringBasis WS_CCRED3_PTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10  WS-CCRED4                   PIC 9(004).*/
            public IntBasis WS_CCRED4 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"05  GARAN-ADIC-DMH                PIC  9(001)   VALUE ZEROS.*/

            public _REDEF_VE0414B_WS_CARTAO_CREDITO()
            {
                WS_FILLER.ValueChanged += OnValueChanged;
                WS_CCRED1.ValueChanged += OnValueChanged;
                WS_CCRED1_PTO.ValueChanged += OnValueChanged;
                WS_CCRED2.ValueChanged += OnValueChanged;
                WS_CCRED2_PTO.ValueChanged += OnValueChanged;
                WS_CCRED3.ValueChanged += OnValueChanged;
                WS_CCRED3_PTO.ValueChanged += OnValueChanged;
                WS_CCRED4.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis GARAN_ADIC_DMH { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"05  GARAN-ADIC-IPA                PIC  9(001)   VALUE ZEROS.*/
        public IntBasis GARAN_ADIC_IPA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"05  CARREGA-CONJUGE               PIC  9(001)   VALUE ZEROS.*/
        public IntBasis CARREGA_CONJUGE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"05  WS-NUM-APOLICE-ANT            PIC  9(013)   VALUE ZEROS.*/
        public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"05  WS-CODSUBES-ANT               PIC  9(005)   VALUE ZEROS.*/
        public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"05  AC-LIDOS                      PIC  9(009)   VALUE ZEROES.*/
        public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"05  AC-LIDOS-R                    PIC  9(009)   VALUE ZEROS.*/
        public IntBasis AC_LIDOS_R { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"05  AC-PENDE                      PIC  9(009)   VALUE ZEROS.*/
        public IntBasis AC_PENDE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"05  AC-SELEC                      PIC  9(009)   VALUE ZEROS.*/
        public IntBasis AC_SELEC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"05  AC-CONTA                      PIC  9(009)   VALUE ZEROES.*/
        public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"05  AC-DESPR-TITULO               PIC  9(009)   VALUE ZEROES.*/
        public IntBasis AC_DESPR_TITULO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"05  AC-IMPRESSOS                  PIC  9(009)   VALUE ZEROS.*/
        public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"05  WFIM-V1AGENCEF                PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WFIM-V0FAIXACEP               PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_V0FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WFIM-V0RELAT                  PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_V0RELAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WFIM-SORT                     PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WFIM-COBERTURAS               PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_COBERTURAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WFIM-ADICIONAIS               PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_ADICIONAIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WFIM-TABELA                   PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_TABELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WFIM-CURSOR-COBERTURAS        PIC  X(003)   VALUE SPACES.*/
        public StringBasis WFIM_CURSOR_COBERTURAS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"05  WTEM-TERMO                    PIC  X(001)   VALUE SPACES.*/
        public StringBasis WTEM_TERMO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WTEM-OPCAO                    PIC  X(001)   VALUE SPACES.*/
        public StringBasis WTEM_OPCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WTEM-ENDERECO                 PIC  X(001)   VALUE SPACES.*/
        public StringBasis WTEM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WTEM-HISCOBPR                 PIC  X(001)   VALUE SPACES.*/
        public StringBasis WTEM_HISCOBPR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WTEM-PERIPGTO                 PIC  X(001)   VALUE SPACES.*/
        public StringBasis WTEM_PERIPGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  WTEM-SORTEIO                  PIC  X(001)   VALUE SPACES.*/
        public StringBasis WTEM_SORTEIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"05  LK-PROSOMU1.*/
        public VE0414B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new VE0414B_LK_PROSOMU1();
        public class VE0414B_LK_PROSOMU1 : VarBasis
        {
            /*"  10  LK-DATA-SOM                 PIC  9(008).*/
            public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  10  LK-DATA-SOM-R               REDEFINES        LK-DATA-SOM.*/
            private _REDEF_VE0414B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
            public _REDEF_VE0414B_LK_DATA_SOM_R LK_DATA_SOM_R
            {
                get { _lk_data_som_r = new _REDEF_VE0414B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
            }  //Redefines
            public class _REDEF_VE0414B_LK_DATA_SOM_R : VarBasis
            {
                /*"    15  LK-DIA-SOM                PIC  9(002).*/
                public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15  LK-MES-SOM                PIC  9(002).*/
                public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15  LK-ANO-SOM                PIC  9(004).*/
                public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  10  LK-QTDIAS                   PIC S9(005)   COMP-3 VALUE +2.*/

                public _REDEF_VE0414B_LK_DATA_SOM_R()
                {
                    LK_DIA_SOM.ValueChanged += OnValueChanged;
                    LK_MES_SOM.ValueChanged += OnValueChanged;
                    LK_ANO_SOM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +2);
            /*"  10  LK-DATA-CALC                PIC  9(008).*/
            public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  10  LK-DATA-CALC-R              REDEFINES        LK-DATA-CALC.*/
            private _REDEF_VE0414B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
            public _REDEF_VE0414B_LK_DATA_CALC_R LK_DATA_CALC_R
            {
                get { _lk_data_calc_r = new _REDEF_VE0414B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
            }  //Redefines
            public class _REDEF_VE0414B_LK_DATA_CALC_R : VarBasis
            {
                /*"    15  LK-DIA-CALC               PIC  9(002).*/
                public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15  LK-MES-CALC               PIC  9(002).*/
                public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15  LK-ANO-CALC               PIC  9(004).*/
                public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  WS-NUM-PLANO                  PIC  9(003) VALUE ZEROS.*/

                public _REDEF_VE0414B_LK_DATA_CALC_R()
                {
                    LK_DIA_CALC.ValueChanged += OnValueChanged;
                    LK_MES_CALC.ValueChanged += OnValueChanged;
                    LK_ANO_CALC.ValueChanged += OnValueChanged;
                }

            }
        }
        public IntBasis WS_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-COD-RAMO                   PIC  9(004) VALUE ZEROS.*/
        public IntBasis WS_COD_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01  WS-NUM-PROPOSTA               PIC  9(015) VALUE ZEROS.*/
        public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"01  WS-COD-RETORNO                PIC  9(003) VALUE ZEROS.*/
        public IntBasis WS_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-IND                        PIC  9(003) VALUE ZEROS.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  LK-NUM-PLANO-FC12              PIC S9(004)  USAGE COMP.*/
        public IntBasis LK_NUM_PLANO_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-NUM-PROPOSTA-FC12           PIC S9(015)V USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA_FC12 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
        /*"01  LK-COD-RAMO-FC12               PIC S9(004)  USAGE COMP.*/
        public IntBasis LK_COD_RAMO_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-TRACE-FC12                  PIC  X(009).*/

        public SelectorBasis LK_TRACE_FC12 { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 LK-TRACE-ON-FC12              VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON_FC12", "TRACE ON "),
							/*" 88 LK-TRACE-OFF-FC12             VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF_FC12", "TRACE OFF")
                }
        };

        /*"01  LK-NUM-PLANO-ED-FC12           PIC 9(009).*/
        public IntBasis LK_NUM_PLANO_ED_FC12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  LK-NUM-PROPOSTA-ED-FC12        PIC 9(015)V.*/
        public DoubleBasis LK_NUM_PROPOSTA_ED_FC12 { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V."), 0);
        /*"01  LK-COD-RAMO-ED-FC12            PIC 9(009).*/
        public IntBasis LK_COD_RAMO_ED_FC12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  LK-OUT-COD-RET-FC12        PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RET_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-OUT-SQLCODE-FC12            PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-OUT-MENSAGEM-FC12           PIC  X(070).*/
        public StringBasis LK_OUT_MENSAGEM_FC12 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01  LK-OUT-SQLERRMC-FC12           PIC  X(070).*/
        public StringBasis LK_OUT_SQLERRMC_FC12 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01  LK-OUT-SQLSTATE-FC12           PIC  X(005).*/
        public StringBasis LK_OUT_SQLSTATE_FC12 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01  WF-NUM-PLANO                   PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-NUM-SERIE                   PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-NUM-TITULO                  PIC S9(009)            COMP.*/
        public IntBasis WF_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WF-COD-STA-TITULO              PIC  X(003).*/
        public StringBasis WF_COD_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WF-COD-SUB-STATUS              PIC  X(003).*/
        public StringBasis WF_COD_SUB_STATUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WF-DTH-ATIVACAO                PIC  X(026).*/
        public StringBasis WF_DTH_ATIVACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WF-DTH-CADUCACAO               PIC  X(010).*/
        public StringBasis WF_DTH_CADUCACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-CRIACAO                 PIC  X(026).*/
        public StringBasis WF_DTH_CRIACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WF-DTH-FIM-VIGENCIA            PIC  X(010).*/
        public StringBasis WF_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-INI-SORTEIO             PIC  X(010).*/
        public StringBasis WF_DTH_INI_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-INI-VIGENCIA            PIC  X(010).*/
        public StringBasis WF_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-SUSPENSAO               PIC  X(010).*/
        public StringBasis WF_DTH_SUSPENSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-IND-DV                      PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-VLR-MENSALIDADE             PIC S9(008)V9(2) USAGE COMP-3*/
        public DoubleBasis WF_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
        /*"01  WF-NUM-PROPOSTA                PIC S9(015)V     USAGE COMP-3*/
        public DoubleBasis WF_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
        /*"01  WF-NUM-MOD-PLANO               PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-DES-COMBINACAO              PIC  X(020).*/
        public StringBasis WF_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WS-EOF.*/
        public VE0414B_WS_EOF WS_EOF { get; set; } = new VE0414B_WS_EOF();
        public class VE0414B_WS_EOF : VarBasis
        {
            /*"    03  WS-EOF-FD001               PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_FD001 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    03  WS-EOF-RESULT              PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_RESULT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01  WL-LOCATOR     USAGE SQL TYPE IS RESULT-SET-LOCATOR VARYING.*/
        }
        public IntBasis WL_LOCATOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01                TAB-MESES1.*/
        public VE0414B_TAB_MESES1 TAB_MESES1 { get; set; } = new VE0414B_TAB_MESES1();
        public class VE0414B_TAB_MESES1 : VarBasis
        {
            /*"    05            FILLER     PIC X(009) VALUE ' janeiro '.*/
            public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" janeiro ");
            /*"    05            FILLER     PIC X(009) VALUE 'fevereiro'.*/
            public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"fevereiro");
            /*"    05            FILLER     PIC X(009) VALUE '  marco  '.*/
            public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  marco  ");
            /*"    05            FILLER     PIC X(009) VALUE '  abril  '.*/
            public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  abril  ");
            /*"    05            FILLER     PIC X(009) VALUE '  maio   '.*/
            public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  maio   ");
            /*"    05            FILLER     PIC X(009) VALUE '  junho  '.*/
            public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  junho  ");
            /*"    05            FILLER     PIC X(009) VALUE '  julho  '.*/
            public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  julho  ");
            /*"    05            FILLER     PIC X(009) VALUE '  agosto '.*/
            public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  agosto ");
            /*"    05            FILLER     PIC X(009) VALUE 'setembro '.*/
            public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"setembro ");
            /*"    05            FILLER     PIC X(009) VALUE ' outubro '.*/
            public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" outubro ");
            /*"    05            FILLER     PIC X(009) VALUE 'novembro '.*/
            public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"novembro ");
            /*"    05            FILLER     PIC X(009) VALUE 'dezembro '.*/
            public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"dezembro ");
            /*"01                TAB-MESES1-R REDEFINES TAB-MESES1.*/
        }
        private _REDEF_VE0414B_TAB_MESES1_R _tab_meses1_r { get; set; }
        public _REDEF_VE0414B_TAB_MESES1_R TAB_MESES1_R
        {
            get { _tab_meses1_r = new _REDEF_VE0414B_TAB_MESES1_R(); _.Move(TAB_MESES1, _tab_meses1_r); VarBasis.RedefinePassValue(TAB_MESES1, _tab_meses1_r, TAB_MESES1); _tab_meses1_r.ValueChanged += () => { _.Move(_tab_meses1_r, TAB_MESES1); }; return _tab_meses1_r; }
            set { VarBasis.RedefinePassValue(value, _tab_meses1_r, TAB_MESES1); }
        }  //Redefines
        public class _REDEF_VE0414B_TAB_MESES1_R : VarBasis
        {
            /*"    05            TAB-MES1   OCCURS 12 TIMES                             PIC X(009).*/
            public ListBasis<StringBasis, string> TAB_MES1 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
            /*"01  TAB-NIVEIS-VA46.*/

            public _REDEF_VE0414B_TAB_MESES1_R()
            {
                TAB_MES1.ValueChanged += OnValueChanged;
            }

        }
        public VE0414B_TAB_NIVEIS_VA46 TAB_NIVEIS_VA46 { get; set; } = new VE0414B_TAB_NIVEIS_VA46();
        public class VE0414B_TAB_NIVEIS_VA46 : VarBasis
        {
            /*"  05    TB46DET-COD-NIVEL         PIC 9(002).*/
            public IntBasis TB46DET_COD_NIVEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    TB46DET-NIV-CAPITAL       PIC ZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis TB46DET_NIV_CAPITAL { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
            /*"01  TAB-FILIAL.*/
        }
        public VE0414B_TAB_FILIAL TAB_FILIAL { get; set; } = new VE0414B_TAB_FILIAL();
        public class VE0414B_TAB_FILIAL : VarBasis
        {
            /*"  05  FILLER                      OCCURS        19 TIMES.*/
            public ListBasis<VE0414B_FILLER_140> FILLER_140 { get; set; } = new ListBasis<VE0414B_FILLER_140>(19);
            public class VE0414B_FILLER_140 : VarBasis
            {
                /*"    10  TAB-FONTE                 PIC  9(04).*/
                public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    10  TAB-NOMEFTE               PIC  X(40).*/
                public StringBasis TAB_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    10  TAB-ENDERFTE              PIC  X(40).*/
                public StringBasis TAB_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    10  TAB-BAIRRO                PIC  X(20).*/
                public StringBasis TAB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"    10  TAB-CIDADE                PIC  X(20).*/
                public StringBasis TAB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"    10  TAB-CEP                   PIC  9(08).*/
                public IntBasis TAB_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"    10  TAB-UF                    PIC  X(02).*/
                public StringBasis TAB_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"01  TABELA-CEP.*/
            }
        }
        public VE0414B_TABELA_CEP TABELA_CEP { get; set; } = new VE0414B_TABELA_CEP();
        public class VE0414B_TABELA_CEP : VarBasis
        {
            /*"  05  CEP                         OCCURS       2000 TIMES.*/
            public ListBasis<VE0414B_CEP> CEP { get; set; } = new ListBasis<VE0414B_CEP>(2000);
            public class VE0414B_CEP : VarBasis
            {
                /*"    10  TAB-FX-CEP-G              PIC  9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  TAB-FAIXAS.*/
                public VE0414B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new VE0414B_TAB_FAIXAS();
                public class VE0414B_TAB_FAIXAS : VarBasis
                {
                    /*"      15  TAB-FX-INI              PIC  9(008).*/
                    public IntBasis TAB_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      15  TAB-FX-FIM              PIC  9(008).*/
                    public IntBasis TAB_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      15  TAB-FX-NOME             PIC  X(072).*/
                    public StringBasis TAB_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"      15  TAB-FX-CENTR            PIC  X(072).*/
                    public StringBasis TAB_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"01  TABELA-TOTAIS.*/
                }
            }
        }
        public VE0414B_TABELA_TOTAIS TABELA_TOTAIS { get; set; } = new VE0414B_TABELA_TOTAIS();
        public class VE0414B_TABELA_TOTAIS : VarBasis
        {
            /*"  05  TAB-TOTAIS                  OCCURS       2000 TIMES.*/
            public ListBasis<VE0414B_TAB_TOTAIS> TAB_TOTAIS { get; set; } = new ListBasis<VE0414B_TAB_TOTAIS>(2000);
            public class VE0414B_TAB_TOTAIS : VarBasis
            {
                /*"    10  TAB1-OBJI                 PIC  9(006).*/
                public IntBasis TAB1_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10  TAB1-OBJF                 PIC  9(006).*/
                public IntBasis TAB1_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10  TAB1-AMARI                PIC  9(006).*/
                public IntBasis TAB1_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10  TAB1-AMARF                PIC  9(006).*/
                public IntBasis TAB1_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10  TAB1-QTD-OBJ              PIC  9(006).*/
                public IntBasis TAB1_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10  TAB1-QTD-AMAR             PIC  9(006).*/
                public IntBasis TAB1_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"01      TABELA-MESES.*/
            }
        }
        public VE0414B_TABELA_MESES TABELA_MESES { get; set; } = new VE0414B_TABELA_MESES();
        public class VE0414B_TABELA_MESES : VarBasis
        {
            /*"  05    TAB-MESES.*/
            public VE0414B_TAB_MESES TAB_MESES { get; set; } = new VE0414B_TAB_MESES();
            public class VE0414B_TAB_MESES : VarBasis
            {
                /*"    10  FILLER                    PIC  X(009)  VALUE '  JANEIRO'*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"    10  FILLER                    PIC  X(009)  VALUE 'FEVEREIRO'*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"    10  FILLER                    PIC  X(009)  VALUE '    MARCO'*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"    10  FILLER                    PIC  X(009)  VALUE '    ABRIL'*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"    10  FILLER                    PIC  X(009)  VALUE '     MAIO'*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"    10  FILLER                    PIC  X(009)  VALUE '    JUNHO'*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"    10  FILLER                    PIC  X(009)  VALUE '    JULHO'*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"    10  FILLER                    PIC  X(009)  VALUE '   AGOSTO'*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"    10  FILLER                    PIC  X(009)  VALUE ' SETEMBRO'*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"    10  FILLER                    PIC  X(009)  VALUE '  OUTUBRO'*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"    10  FILLER                    PIC  X(009)  VALUE ' NOVEMBRO'*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"    10  FILLER                    PIC  X(009)  VALUE ' DEZEMBRO'*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"  05    TAB-MESES-R                   REDEFINES        TAB-MESES.*/
            }
            private _REDEF_VE0414B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_VE0414B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_VE0414B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_VE0414B_TAB_MESES_R : VarBasis
            {
                /*"    10  TAB-MES                     OCCURS       12 TIMES                                  PIC  X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"  05                WS-DESCRICAO-DIA.*/

                public _REDEF_VE0414B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
            public VE0414B_WS_DESCRICAO_DIA WS_DESCRICAO_DIA { get; set; } = new VE0414B_WS_DESCRICAO_DIA();
            public class VE0414B_WS_DESCRICAO_DIA : VarBasis
            {
                /*"    10            FILLER              PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10            WS-DESC-DIA         PIC 9(002).*/
                public IntBasis WS_DESC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10            FILLER              PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10            WS-DESC-MES         PIC X(009).*/
                public StringBasis WS_DESC_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"    10            FILLER              PIC X(006) VALUE '  de  '.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"  de  ");
                /*"    10            WS-DESC-ANO         PIC 9(004).*/
                public IntBasis WS_DESC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  AREA-MONTAGEM                 PIC  X(1519).*/
            }
        }
        public StringBasis AREA_MONTAGEM { get; set; } = new StringBasis(new PIC("X", "1519", "X(1519)."), @"");
        /*"  05  MONTAGEM                    OCCURS       2  TIMES.*/
        public ListBasis<VE0414B_MONTAGEM> MONTAGEM { get; set; } = new ListBasis<VE0414B_MONTAGEM>(2);
        public class VE0414B_MONTAGEM : VarBasis
        {
            /*"    10  TB-NUM-TERMO              PIC  9(015).*/
            public IntBasis TB_NUM_TERMO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    10  TB-SUBGRUPO               PIC  9(005).*/
            public IntBasis TB_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    10  TB-DATA-ADESAO.*/
            public VE0414B_TB_DATA_ADESAO TB_DATA_ADESAO { get; set; } = new VE0414B_TB_DATA_ADESAO();
            public class VE0414B_TB_DATA_ADESAO : VarBasis
            {
                /*"      15  TB-DIA-ADESAO           PIC  9(002).*/
                public IntBasis TB_DIA_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      15  TB-MES-ADESAO           PIC  9(002).*/
                public IntBasis TB_MES_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      15  TB-ANO-ADESAO           PIC  9(004).*/
                public IntBasis TB_ANO_ADESAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  TB-DATA-EMISSAO.*/
            }
            public VE0414B_TB_DATA_EMISSAO TB_DATA_EMISSAO { get; set; } = new VE0414B_TB_DATA_EMISSAO();
            public class VE0414B_TB_DATA_EMISSAO : VarBasis
            {
                /*"      15  TB-DIA-EMISSAO          PIC 9(002).*/
                public IntBasis TB_DIA_EMISSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      15  TB-MES-EMISSAO          PIC 9(002).*/
                public IntBasis TB_MES_EMISSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      15  TB-ANO-EMISSAO          PIC 9(004).*/
                public IntBasis TB_ANO_EMISSAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  TB-NUM-APOLICE            PIC  X(013).*/
            }
            public StringBasis TB_NUM_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"    10  TB-NOME-EMPRESA           PIC  X(040).*/
            public StringBasis TB_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    10  TB-CGC                    PIC  9(015).*/
            public IntBasis TB_CGC { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    10  TB-COD-AGENCIA            PIC  9(004).*/
            public IntBasis TB_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10  TB-NOME-AGENCIA           PIC  X(040).*/
            public StringBasis TB_NOME_AGENCIA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    10  TB-MODALIDADE             PIC  X(012).*/
            public StringBasis TB_MODALIDADE { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"    10  TB-PAGAMENTO              PIC  X(010).*/
            public StringBasis TB_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10  TB-TIPO-COBERTURA         PIC  X(008).*/
            public StringBasis TB_TIPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    10  TB-PLANO                  PIC  X(020).*/
            public StringBasis TB_PLANO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    10  TB-OCOREND                PIC  9(005).*/
            public IntBasis TB_OCOREND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    10  TB-PLANO-AP               PIC  9(006).*/
            public IntBasis TB_PLANO_AP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    10  TB-CAPITAL                PIC  9(013)V99.*/
            public DoubleBasis TB_CAPITAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10  TB-CUSTO                  PIC  9(013)V99.*/
            public DoubleBasis TB_CUSTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10  TB-VIDAS                  PIC  9(005).*/
            public IntBasis TB_VIDAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    10  TB-MSG1                   PIC  X(060).*/
            public StringBasis TB_MSG1 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"    10  TB-MSG2                   PIC  X(060).*/
            public StringBasis TB_MSG2 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"    10  TB-MSG3                   PIC  X(060).*/
            public StringBasis TB_MSG3 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"    10  TB-MSG4                   PIC  X(060).*/
            public StringBasis TB_MSG4 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"    10  TB-EMPR-ENDER             PIC  X(040).*/
            public StringBasis TB_EMPR_ENDER { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    10  TB-ENDERECO               PIC  X(072).*/
            public StringBasis TB_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    10  TB-BAIRRO                 PIC  X(072).*/
            public StringBasis TB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    10  TB-CIDADE                 PIC  X(072).*/
            public StringBasis TB_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    10  TB-UF                     PIC  X(002).*/
            public StringBasis TB_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    10  TB-NUMCEP                 PIC  9(008).*/
            public IntBasis TB_NUMCEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    10  FILLER                    REDEFINES     TB-NUMCEP.*/
            private _REDEF_VE0414B_FILLER_156 _filler_156 { get; set; }
            public _REDEF_VE0414B_FILLER_156 FILLER_156
            {
                get { _filler_156 = new _REDEF_VE0414B_FILLER_156(); _.Move(TB_NUMCEP, _filler_156); VarBasis.RedefinePassValue(TB_NUMCEP, _filler_156, TB_NUMCEP); _filler_156.ValueChanged += () => { _.Move(_filler_156, TB_NUMCEP); }; return _filler_156; }
                set { VarBasis.RedefinePassValue(value, _filler_156, TB_NUMCEP); }
            }  //Redefines
            public class _REDEF_VE0414B_FILLER_156 : VarBasis
            {
                /*"      15  TB-CEP                  PIC  9(005).*/
                public IntBasis TB_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      15  TB-CEP-COMPL            PIC  9(003).*/
                public IntBasis TB_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10  TB-FONTE                  PIC  9(004).*/

                public _REDEF_VE0414B_FILLER_156()
                {
                    TB_CEP.ValueChanged += OnValueChanged;
                    TB_CEP_COMPL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis TB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10  TB-NUM-PROPOSTA-SIVPF     PIC  9(015).*/
            public IntBasis TB_NUM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    10  TB-DTH-DIA-DEBITO         PIC  9(002).*/
            public IntBasis TB_DTH_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10  TB-COD-AGENCIA-DEB        PIC  9(004).*/
            public IntBasis TB_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10  TB-OPERACAO-CONTA-DEB     PIC  9(004).*/
            public IntBasis TB_OPERACAO_CONTA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10  TB-NUM-CONTA-DEBITO       PIC  9(012).*/
            public IntBasis TB_NUM_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    10  TB-DIG-CONTA-DEBITO       PIC  9(001).*/
            public IntBasis TB_DIG_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    10  TB-NUM-CARTAO-CREDITO     PIC  9(016).*/
            public IntBasis TB_NUM_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"    10  TB-NUM-CARTAO-CREDITOR REDEFINES TB-NUM-CARTAO-CREDITO.*/
            private _REDEF_VE0414B_TB_NUM_CARTAO_CREDITOR _tb_num_cartao_creditor { get; set; }
            public _REDEF_VE0414B_TB_NUM_CARTAO_CREDITOR TB_NUM_CARTAO_CREDITOR
            {
                get { _tb_num_cartao_creditor = new _REDEF_VE0414B_TB_NUM_CARTAO_CREDITOR(); _.Move(TB_NUM_CARTAO_CREDITO, _tb_num_cartao_creditor); VarBasis.RedefinePassValue(TB_NUM_CARTAO_CREDITO, _tb_num_cartao_creditor, TB_NUM_CARTAO_CREDITO); _tb_num_cartao_creditor.ValueChanged += () => { _.Move(_tb_num_cartao_creditor, TB_NUM_CARTAO_CREDITO); }; return _tb_num_cartao_creditor; }
                set { VarBasis.RedefinePassValue(value, _tb_num_cartao_creditor, TB_NUM_CARTAO_CREDITO); }
            }  //Redefines
            public class _REDEF_VE0414B_TB_NUM_CARTAO_CREDITOR : VarBasis
            {
                /*"      15  TB-CARTAO1              PIC  9(004).*/
                public IntBasis TB_CARTAO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      15  TB-CARTAO2              PIC  9(004).*/
                public IntBasis TB_CARTAO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      15  TB-CARTAO3              PIC  9(004).*/
                public IntBasis TB_CARTAO3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      15  TB-CARTAO4              PIC  9(004).*/
                public IntBasis TB_CARTAO4 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  TB-DATADIA                PIC  X(030).*/

                public _REDEF_VE0414B_TB_NUM_CARTAO_CREDITOR()
                {
                    TB_CARTAO1.ValueChanged += OnValueChanged;
                    TB_CARTAO2.ValueChanged += OnValueChanged;
                    TB_CARTAO3.ValueChanged += OnValueChanged;
                    TB_CARTAO4.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis TB_DATADIA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    10  TB-CODPRODU               PIC  9(004).*/
            public IntBasis TB_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01  TRUNCAO                       PIC  X(180).*/
        }
        public StringBasis TRUNCAO { get; set; } = new StringBasis(new PIC("X", "180", "X(180)."), @"");
        /*"01  R-TRUNCA-MSG                  REDEFINES     TRUNCAO.*/
        private _REDEF_VE0414B_R_TRUNCA_MSG _r_trunca_msg { get; set; }
        public _REDEF_VE0414B_R_TRUNCA_MSG R_TRUNCA_MSG
        {
            get { _r_trunca_msg = new _REDEF_VE0414B_R_TRUNCA_MSG(); _.Move(TRUNCAO, _r_trunca_msg); VarBasis.RedefinePassValue(TRUNCAO, _r_trunca_msg, TRUNCAO); _r_trunca_msg.ValueChanged += () => { _.Move(_r_trunca_msg, TRUNCAO); }; return _r_trunca_msg; }
            set { VarBasis.RedefinePassValue(value, _r_trunca_msg, TRUNCAO); }
        }  //Redefines
        public class _REDEF_VE0414B_R_TRUNCA_MSG : VarBasis
        {
            /*"  03  TRUNCA-MSG                  OCCURS        3  TIMES.*/
            public ListBasis<VE0414B_TRUNCA_MSG> TRUNCA_MSG { get; set; } = new ListBasis<VE0414B_TRUNCA_MSG>(3);
            public class VE0414B_TRUNCA_MSG : VarBasis
            {
                /*"    05  TRUNCA1                   PIC  X(035).*/
                public StringBasis TRUNCA1 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
                /*"    05  TRUNCA2                   PIC  X(025).*/
                public StringBasis TRUNCA2 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"01  TRUNCA35                      PIC  X(035).*/

                public VE0414B_TRUNCA_MSG()
                {
                    TRUNCA1.ValueChanged += OnValueChanged;
                    TRUNCA2.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VE0414B_R_TRUNCA_MSG()
            {
                TRUNCA_MSG.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis TRUNCA35 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
        /*"01  TRUNCA25                      PIC  X(025).*/
        public StringBasis TRUNCA25 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"01  WABEND.*/
        public VE0414B_WABEND WABEND { get; set; } = new VE0414B_WABEND();
        public class VE0414B_WABEND : VarBasis
        {
            /*"  05  FILLER                      PIC  X(010) VALUE     ' VE0414B'.*/
            public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VE0414B");
            /*"  05  FILLER                      PIC  X(026) VALUE     ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05  WNR-EXEC-SQL                PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05  FILLER                      PIC  X(013)   VALUE     ' *** SQLCODE '.*/
            public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05  WSQLCODE                    PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.VGPROSIA VGPROSIA { get; set; } = new Dclgens.VGPROSIA();
        public Dclgens.VGCOMTRO VGCOMTRO { get; set; } = new Dclgens.VGCOMTRO();
        public Dclgens.VGCOBTER VGCOBTER { get; set; } = new Dclgens.VGCOBTER();
        public Dclgens.VGTERNIV VGTERNIV { get; set; } = new Dclgens.VGTERNIV();
        public Dclgens.VGARANTI VGARANTI { get; set; } = new Dclgens.VGARANTI();
        public Dclgens.VETEMCOB VETEMCOB { get; set; } = new Dclgens.VETEMCOB();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.GEFAICEP GEFAICEP { get; set; } = new Dclgens.GEFAICEP();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.GEOBJECT GEOBJECT { get; set; } = new Dclgens.GEOBJECT();
        public Dclgens.GE101 GE101 { get; set; } = new Dclgens.GE101();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public VE0414B_CFAIXACEP CFAIXACEP { get; set; } = new VE0414B_CFAIXACEP();
        public VE0414B_V1AGENCEF V1AGENCEF { get; set; } = new VE0414B_V1AGENCEF();
        public VE0414B_CRELAT CRELAT { get; set; } = new VE0414B_CRELAT();
        public VE0414B_CADIC CADIC { get; set; } = new VE0414B_CADIC();
        public VE0414B_C01_RESULT C01_RESULT { get; set; } = new VE0414B_C01_RESULT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVE0414B_FILE_NAME_P, string RVE0414I_FILE_NAME_P, string RVE0414P_FILE_NAME_P, string RVE0414H_FILE_NAME_P, string SVE0414B_FILE_NAME_P, string FVE0414B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVE0414B.SetFile(RVE0414B_FILE_NAME_P);
                RVE0414I.SetFile(RVE0414I_FILE_NAME_P);
                RVE0414P.SetFile(RVE0414P_FILE_NAME_P);
                RVE0414H.SetFile(RVE0414H_FILE_NAME_P);
                SVE0414B.SetFile(SVE0414B_FILE_NAME_P);
                FVE0414B.SetFile(FVE0414B_FILE_NAME_P);

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
            /*" -1425- DISPLAY ' ' */
            _.Display($" ");

            /*" -1427- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1435- DISPLAY 'PROGRAMA VE0414B - VERSAO V.29' '- DEMANDA 589106 - 12/08/2024.' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VE0414B - VERSAO V.29- DEMANDA 589106 - 12/08/2024.FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1437- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1438- DISPLAY ' ' */
            _.Display($" ");

            /*" -1445- DISPLAY 'INICIOU PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1447- DISPLAY ' ' */
            _.Display($" ");

            /*" -1449- PERFORM R0001-00-INICIALIZAR. */

            R0001_00_INICIALIZAR_SECTION();

            /*" -1451- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1457- SORT SVE0414B ON ASCENDING KEY SVA-CEP-G, SVA-NUM-CEP, SVA-NUM-TERMO INPUT PROCEDURE R0010-00-SELECIONA OUTPUT PROCEDURE R0020-00-IMPRIME. */
            SORT_RETURN.Value = SVE0414B.Sort("SVA-CEP-G,,SVA-NUM-CEP,,SVA-NUM-TERMO", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -1460- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1461- DISPLAY '*** VE0414B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VE0414B *** PROBLEMAS NO SORT ");

                /*" -1462- DISPLAY '*** VE0414B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VE0414B *** SORT-RETURN = {SORT_RETURN}");

                /*" -1462- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1464- MOVE 98 TO RETURN-CODE */
                _.Move(98, RETURN_CODE);

                /*" -1468- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1469- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1469- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1472- DISPLAY ' ' */
            _.Display($" ");

            /*" -1473- DISPLAY 'VE0414B - MOVTO LIDOS  = ' AC-LIDOS-R. */
            _.Display($"VE0414B - MOVTO LIDOS  = {AC_LIDOS_R}");

            /*" -1474- DISPLAY '          MOVTO C/PEND = ' AC-PENDE. */
            _.Display($"          MOVTO C/PEND = {AC_PENDE}");

            /*" -1475- DISPLAY '          TITULO S/VIG = ' AC-DESPR-TITULO. */
            _.Display($"          TITULO S/VIG = {AC_DESPR_TITULO}");

            /*" -1476- DISPLAY '          SELECIONADOS = ' AC-SELEC. */
            _.Display($"          SELECIONADOS = {AC_SELEC}");

            /*" -1477- DISPLAY '          IMPRESSOS    = ' AC-IMPRESSOS */
            _.Display($"          IMPRESSOS    = {AC_IMPRESSOS}");

            /*" -1479- DISPLAY ' ' */
            _.Display($" ");

            /*" -1480- DISPLAY '*** VE0414B - TERMINO NORMAL ***' */
            _.Display($"*** VE0414B - TERMINO NORMAL ***");

            /*" -1480- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0001-00-INICIALIZAR-SECTION */
        private void R0001_00_INICIALIZAR_SECTION()
        {
            /*" -1491- INITIALIZE TAB-FILIAL. */
            _.Initialize(
                TAB_FILIAL
            );

            /*" -1493- PERFORM R0500-00-DECLARE-V1AGENCEF. */

            R0500_00_DECLARE_V1AGENCEF_SECTION();

            /*" -1495- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

            /*" -1496- IF WFIM-V1AGENCEF NOT EQUAL SPACES */

            if (!WFIM_V1AGENCEF.IsEmpty())
            {

                /*" -1497- DISPLAY 'R0001 - PROBLEMA NO FETCH DA V1AGENCIACEF' */
                _.Display($"R0001 - PROBLEMA NO FETCH DA V1AGENCIACEF");

                /*" -1499- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1504- PERFORM R0520-00-CARREGA-FILIAL VARYING IDX1 FROM 1 BY 1 UNTIL IDX1 > 19 OR WFIM-V1AGENCEF EQUAL 'S' . */

            for (AREA_DE_WORK.IDX1.Value = 1; !(AREA_DE_WORK.IDX1 > 19 || WFIM_V1AGENCEF == "S"); AREA_DE_WORK.IDX1.Value += 1)
            {

                R0520_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1506- PERFORM R0900-00-DECLARE-V0RELATORIOS. */

            R0900_00_DECLARE_V0RELATORIOS_SECTION();

            /*" -1508- PERFORM R0910-00-FETCH-V0RELATORIOS. */

            R0910_00_FETCH_V0RELATORIOS_SECTION();

            /*" -1509- IF WFIM-V0RELAT EQUAL 'S' */

            if (WFIM_V0RELAT == "S")
            {

                /*" -1510- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1511- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1513- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1515- MOVE ZEROS TO TABELA-TOTAIS. */
            _.Move(0, TABELA_TOTAIS);

            /*" -1517- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1517- PERFORM R0200-00-CARREGA-V0FAIXACEP. */

            R0200_00_CARREGA_V0FAIXACEP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_FIM*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1527- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0RELAT EQUAL 'S' . */

            while (!(WFIM_V0RELAT == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -1538- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1540- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -1543- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -1547- MOVE SPACES TO RVE0414B-RECORD RVE0414I-RECORD RVE0414P-RECORD RVE0414H-RECORD. */
            _.Move("", RVE0414B_RECORD, RVE0414I_RECORD, RVE0414P_RECORD, RVE0414H_RECORD);

            /*" -1552- MOVE DET-JDE-1VZ6 TO REG-DADOS REG-DADOS-I REG-DADOS-P REG-DADOS-H. */
            _.Move(AREA_DE_WORK.DET_JDE_1VZ6, RVE0414B_RECORD.REG_DADOS, RVE0414I_RECORD.REG_DADOS_I, RVE0414P_RECORD.REG_DADOS_P, RVE0414H_RECORD.REG_DADOS_H);

            /*" -1552- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1564- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -1567- MOVE 'FI' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("FI", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -1579- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1582- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1583- DISPLAY 'R0100 - SISTEMA FI NAO ESTA CADASTRADO' */
                _.Display($"R0100 - SISTEMA FI NAO ESTA CADASTRADO");

                /*" -1585- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1588- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO WS-DESC-DIA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), TABELA_MESES.WS_DESCRICAO_DIA.WS_DESC_DIA);

            /*" -1591- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO W77-MES */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), W77_MES);

            /*" -1594- MOVE TAB-MES1 (W77-MES) TO WS-DESC-MES. */
            _.Move(TAB_MESES1_R.TAB_MES1[W77_MES], TABELA_MESES.WS_DESCRICAO_DIA.WS_DESC_MES);

            /*" -1597- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO WS-DESC-ANO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), TABELA_MESES.WS_DESCRICAO_DIA.WS_DESC_ANO);

            /*" -1598- MOVE WS-DESCRICAO-DIA TO LD00A-DATADIA. */
            _.Move(TABELA_MESES.WS_DESCRICAO_DIA, AREA_DE_WORK.LD00A.LD00A_DATADIA);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1579- EXEC SQL SELECT DATA_MOV_ABERTO, MONTH(DATA_MOV_ABERTO), YEAR(DATA_MOV_ABERTO), (DATA_MOV_ABERTO + 1 DAY) INTO :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-MESREFER, :V1SIST-ANOREFER, :WHOST-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
                _.Move(executed_1.WHOST_DATA_MOV_ABERTO, WHOST_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-SECTION */
        private void R0200_00_CARREGA_V0FAIXACEP_SECTION()
        {
            /*" -1610- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -1623- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1();

            /*" -1625- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1();

            /*" -1628- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1629- DISPLAY 'R0200 - PROBLEMAS NO DECLARE CFAIXACEP' */
                _.Display($"R0200 - PROBLEMAS NO DECLARE CFAIXACEP");

                /*" -1631- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1632- PERFORM R0210-00-FETCH-V0FAIXACEP UNTIL WFIM-V0FAIXACEP EQUAL 'S' . */

            while (!(WFIM_V0FAIXACEP == "S"))
            {

                R0210_00_FETCH_V0FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1()
        {
            /*" -1623- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO ORDER BY FAIXA END-EXEC. */
            CFAIXACEP = new VE0414B_CFAIXACEP(true);
            string GetQuery_CFAIXACEP()
            {
                var query = @$"SELECT FAIXA
							, 
							CEP_INICIAL
							, 
							CEP_FINAL
							, 
							DESCRICAO_FAIXA
							, 
							CENTRALIZADOR 
							FROM SEGUROS.GE_FAIXA_CEP 
							WHERE DATA_INIVIGENCIA <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DATA_TERVIGENCIA >= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY FAIXA";

                return query;
            }
            CFAIXACEP.GetQueryEvent += GetQuery_CFAIXACEP;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-DB-OPEN-1 */
        public void R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1()
        {
            /*" -1625- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1()
        {
            /*" -1851- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT DISTINCT B.COD_FONTE, C.NOME_FONTE, C.ENDERECO, C.BAIRRO, C.CIDADE, C.CEP, C.SIGLA_UF FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B, SEGUROS.FONTES C WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND B.COD_FONTE = C.COD_FONTE ORDER BY B.COD_FONTE, C.NOME_FONTE, C.ENDERECO, C.BAIRRO, C.CIDADE, C.CEP, C.SIGLA_UF END-EXEC. */
            V1AGENCEF = new VE0414B_V1AGENCEF(false);
            string GetQuery_V1AGENCEF()
            {
                var query = @$"SELECT DISTINCT 
							B.COD_FONTE
							, 
							C.NOME_FONTE
							, 
							C.ENDERECO
							, 
							C.BAIRRO
							, 
							C.CIDADE
							, 
							C.CEP
							, 
							C.SIGLA_UF 
							FROM SEGUROS.AGENCIAS_CEF A
							, 
							SEGUROS.MALHA_CEF B
							, 
							SEGUROS.FONTES C 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							AND B.COD_FONTE = C.COD_FONTE 
							ORDER BY B.COD_FONTE
							, 
							C.NOME_FONTE
							, 
							C.ENDERECO
							, 
							C.BAIRRO
							, 
							C.CIDADE
							, 
							C.CEP
							, 
							C.SIGLA_UF";

                return query;
            }
            V1AGENCEF.GetQueryEvent += GetQuery_V1AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-SECTION */
        private void R0210_00_FETCH_V0FAIXACEP_SECTION()
        {
            /*" -1644- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", WABEND.WNR_EXEC_SQL);

            /*" -1651- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1 */

            R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1();

            /*" -1654- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1655- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1656- MOVE 'S' TO WFIM-V0FAIXACEP */
                    _.Move("S", WFIM_V0FAIXACEP);

                    /*" -1658- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                    _.Move(0, AC_CONTA, AC_LIDOS);

                    /*" -1658- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1 */

                    R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1();

                    /*" -1660- GO TO R0210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1661- ELSE */
                }
                else
                {


                    /*" -1662- DISPLAY 'R0210 - PROBLEMAS NO FETCH CFAIXACEP' */
                    _.Display($"R0210 - PROBLEMAS NO FETCH CFAIXACEP");

                    /*" -1664- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1668- MOVE GEFAICEP-FAIXA OF DCLGE-FAIXA-CEP TO TAB-FX-CEP-G (GEFAICEP-FAIXA OF DCLGE-FAIXA-CEP) */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FX_CEP_G);

            /*" -1672- MOVE GEFAICEP-CEP-INICIAL OF DCLGE-FAIXA-CEP TO TAB-FX-INI (GEFAICEP-FAIXA OF DCLGE-FAIXA-CEP) */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -1676- MOVE GEFAICEP-CEP-FINAL OF DCLGE-FAIXA-CEP TO TAB-FX-FIM (GEFAICEP-FAIXA OF DCLGE-FAIXA-CEP) */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -1680- MOVE GEFAICEP-DESCRICAO-FAIXA OF DCLGE-FAIXA-CEP TO TAB-FX-NOME (GEFAICEP-FAIXA OF DCLGE-FAIXA-CEP) */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -1684- MOVE GEFAICEP-DESCRICAO-FAIXA OF DCLGE-FAIXA-CEP TO TAB-FX-NOME (GEFAICEP-FAIXA OF DCLGE-FAIXA-CEP) */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -1688- MOVE GEFAICEP-CENTRALIZADOR OF DCLGE-FAIXA-CEP TO TAB-FX-CENTR (GEFAICEP-FAIXA OF DCLGE-FAIXA-CEP) */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -1688- GO TO R0210-00-FETCH-V0FAIXACEP. */
            new Task(() => R0210_00_FETCH_V0FAIXACEP_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-DB-FETCH-1 */
        public void R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1()
        {
            /*" -1651- EXEC SQL FETCH CFAIXACEP INTO :DCLGE-FAIXA-CEP.GEFAICEP-FAIXA, :DCLGE-FAIXA-CEP.GEFAICEP-CEP-INICIAL, :DCLGE-FAIXA-CEP.GEFAICEP-CEP-FINAL, :DCLGE-FAIXA-CEP.GEFAICEP-DESCRICAO-FAIXA, :DCLGE-FAIXA-CEP.GEFAICEP-CENTRALIZADOR END-EXEC. */

            if (CFAIXACEP.Fetch())
            {
                _.Move(CFAIXACEP.DCLGE_FAIXA_CEP_GEFAICEP_FAIXA, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA);
                _.Move(CFAIXACEP.DCLGE_FAIXA_CEP_GEFAICEP_CEP_INICIAL, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL);
                _.Move(CFAIXACEP.DCLGE_FAIXA_CEP_GEFAICEP_CEP_FINAL, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL);
                _.Move(CFAIXACEP.DCLGE_FAIXA_CEP_GEFAICEP_DESCRICAO_FAIXA, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA);
                _.Move(CFAIXACEP.DCLGE_FAIXA_CEP_GEFAICEP_CENTRALIZADOR, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1()
        {
            /*" -1658- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-OBTEM-NUMERACAO-SECTION */
        private void R0300_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -1705- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -1713- PERFORM R0300_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R0300_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -1716- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1717- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1718- MOVE ZEROS TO RELATORI-NUM-COPIAS OF DCLRELATORIOS */
                    _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

                    /*" -1720- ELSE */
                }
                else
                {


                    /*" -1721- DISPLAY 'R0300 - PROBLEMAS SELECT MAX NA RELATORIOS' */
                    _.Display($"R0300 - PROBLEMAS SELECT MAX NA RELATORIOS");

                    /*" -1722- DISPLAY 'MES REFERENCIA ' V1SIST-MESREFER */
                    _.Display($"MES REFERENCIA {V1SIST_MESREFER}");

                    /*" -1723- DISPLAY 'ANO REFERENCIA ' V1SIST-ANOREFER */
                    _.Display($"ANO REFERENCIA {V1SIST_ANOREFER}");

                    /*" -1724- DISPLAY 'SQLCODE        ' SQLCODE */
                    _.Display($"SQLCODE        {DB.SQLCODE}");

                    /*" -1726- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1727- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -1735- MOVE ZEROS TO RELATORI-NUM-COPIAS OF DCLRELATORIOS. */
                _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
            }


            /*" -1738- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", WABEND.WNR_EXEC_SQL);

            /*" -1740- ADD 1 TO RELATORI-NUM-COPIAS OF DCLRELATORIOS. */
            RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.Value = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS + 1;

            /*" -1742- ADD 1 TO AC-I-RELATORIOS. */
            AREA_DE_WORK.AC_I_RELATORIOS.Value = AREA_DE_WORK.AC_I_RELATORIOS + 1;

            /*" -1745- MOVE RELATORI-NUM-COPIAS OF DCLRELATORIOS TO LR02-SEQ. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS, AREA_DE_WORK.LR02_LINHA02.LISTAGEM_INT.LR02_SEQ);

            /*" -1748- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO WS-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_DATA_SQL);

            /*" -1751- MOVE TAB-MES(WS-MES-SQL) TO LR02-MES LC02-MM-HOJE. */
            _.Move(TABELA_MESES.TAB_MESES_R.TAB_MES[WS_DATA_SQL.WS_MES_SQL], AREA_DE_WORK.LR02_LINHA02.LISTAGEM_INT.LR02_MES, AREA_DE_WORK.LC02_LINHA02.LC02_MM_HOJE);

            /*" -1753- MOVE LISTAGEM-INT TO LISTAGEM-NUMERO. */
            _.Move(AREA_DE_WORK.LR02_LINHA02.LISTAGEM_INT, LINHAS_AMARRADO.L7_JDT.LISTAGEM_NUMERO);

            /*" -1754- MOVE WS-DIA-SQL TO LC02-DD-HOJE. */
            _.Move(WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.LC02_LINHA02.LC02_DD_HOJE);

            /*" -1756- MOVE WS-ANO-SQL TO LC02-AA-HOJE. */
            _.Move(WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.LC02_LINHA02.LC02_AA_HOJE);

            /*" -1757- MOVE ZEROS TO WS-COUNT. */
            _.Move(0, AREA_DE_WORK.WS_COUNT);

            /*" -1759- MOVE WHOST-DATA-MOV-ABERTO TO WHOST-PROXIMA-DATA. */
            _.Move(WHOST_DATA_MOV_ABERTO, AREA_DE_WORK.WHOST_PROXIMA_DATA);

            /*" -1762- PERFORM R0400-00-CALC-DIAS-UTEIS UNTIL WS-COUNT EQUAL 2. */

            while (!(AREA_DE_WORK.WS_COUNT == 2))
            {

                R0400_00_CALC_DIAS_UTEIS_SECTION();
            }

            /*" -1763- MOVE CALENDAR-DATA-CALENDARIO TO WS-DATA-SQL. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WS_DATA_SQL);

            /*" -1764- MOVE WS-DIA-SQL TO WS-DIA-I. */
            _.Move(WS_DATA_SQL.WS_DIA_SQL, WS_DATA_I.WS_DIA_I);

            /*" -1765- MOVE WS-MES-SQL TO WS-MES-I. */
            _.Move(WS_DATA_SQL.WS_MES_SQL, WS_DATA_I.WS_MES_I);

            /*" -1766- MOVE WS-ANO-SQL TO WS-ANO-I. */
            _.Move(WS_DATA_SQL.WS_ANO_SQL, WS_DATA_I.WS_ANO_I);

            /*" -1768- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", WS_DATA_I.FILLERB1, WS_DATA_I.FILLERB2);

            /*" -1769- MOVE WS-DATA-I TO LR04-DATA */
            _.Move(WS_DATA_I, AREA_DE_WORK.LR04_LINHA04.LR04_DATA);

            /*" -1769- MOVE 'XX/XX/XXXX' TO LE01-DTPOSTAGEM. */
            _.Move("XX/XX/XXXX", AREA_DE_WORK.LE01_LINHA01.LE01_DTPOSTAGEM);

        }

        [StopWatch]
        /*" R0300-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R0300_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -1713- EXEC SQL SELECT MAX(NUM_COPIAS) INTO :DCLRELATORIOS.RELATORI-NUM-COPIAS :VIND-NRCOPIAS FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER END-EXEC. */

            var r0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 = new R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1()
            {
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
            };

            var executed_1 = R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1.Execute(r0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_NUM_COPIAS, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
                _.Move(executed_1.VIND_NRCOPIAS, VIND_NRCOPIAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-CALC-DIAS-UTEIS-SECTION */
        private void R0400_00_CALC_DIAS_UTEIS_SECTION()
        {
            /*" -1780- PERFORM R0410-00-CALCULA-DIA-UTIL. */

            R0410_00_CALCULA_DIA_UTIL_SECTION();

            /*" -1784- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO EQUAL 'N' NEXT SENTENCE */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "S" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "D" || CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N")
            {

                /*" -1785- ELSE */
            }
            else
            {


                /*" -1785- ADD 1 TO WS-COUNT. */
                AREA_DE_WORK.WS_COUNT.Value = AREA_DE_WORK.WS_COUNT + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-CALCULA-DIA-UTIL-SECTION */
        private void R0410_00_CALCULA_DIA_UTIL_SECTION()
        {
            /*" -1797- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", WABEND.WNR_EXEC_SQL);

            /*" -1811- PERFORM R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1 */

            R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1();

            /*" -1815- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1816- DISPLAY 'R0410 - PROBLEMAS ACESSO TABELA CALENDARIO' */
                _.Display($"R0410 - PROBLEMAS ACESSO TABELA CALENDARIO");

                /*" -1816- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0410-00-CALCULA-DIA-UTIL-DB-SELECT-1 */
        public void R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1()
        {
            /*" -1811- EXEC SQL SELECT DATA_CALENDARIO, (DATA_CALENDARIO + 1 DAY), DIA_SEMANA, FERIADO INTO :CALENDAR-DATA-CALENDARIO, :WHOST-PROXIMA-DATA, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-PROXIMA-DATA END-EXEC. */

            var r0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 = new R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1()
            {
                WHOST_PROXIMA_DATA = AREA_DE_WORK.WHOST_PROXIMA_DATA.ToString(),
            };

            var executed_1 = R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1.Execute(r0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.WHOST_PROXIMA_DATA, AREA_DE_WORK.WHOST_PROXIMA_DATA);
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-SECTION */
        private void R0500_00_DECLARE_V1AGENCEF_SECTION()
        {
            /*" -1828- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -1851- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1();

            /*" -1853- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1();

            /*" -1856- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1857- DISPLAY 'R0500 - PROBLEMAS DECLARE V1AGENCEF' */
                _.Display($"R0500 - PROBLEMAS DECLARE V1AGENCEF");

                /*" -1858- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1858- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-OPEN-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1()
        {
            /*" -1853- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0RELATORIOS-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -1995- EXEC SQL DECLARE CRELAT CURSOR FOR SELECT DISTINCT A.NUM_TITULO, A.NUM_APOLICE, A.COD_SUBGRUPO FROM SEGUROS.RELATORIOS A, SEGUROS.PRODUTOS_VG B WHERE A.COD_RELATORIO = 'VE0401B1' AND A.SIT_REGISTRO = '0' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.ORIG_PRODU IN ( 'EMPRE' , 'GLOBAL' ) ORDER BY A.NUM_TITULO, A.NUM_APOLICE, A.COD_SUBGRUPO END-EXEC. */
            CRELAT = new VE0414B_CRELAT(false);
            string GetQuery_CRELAT()
            {
                var query = @$"SELECT DISTINCT 
							A.NUM_TITULO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE A.COD_RELATORIO = 'VE0401B1' 
							AND A.SIT_REGISTRO = '0' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.ORIG_PRODU IN ( 'EMPRE'
							, 'GLOBAL' ) 
							ORDER BY A.NUM_TITULO
							, A.NUM_APOLICE
							, A.COD_SUBGRUPO";

                return query;
            }
            CRELAT.GetQueryEvent += GetQuery_CRELAT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-SECTION */
        private void R0510_00_FETCH_V1AGENCEF_SECTION()
        {
            /*" -1870- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -1879- PERFORM R0510_00_FETCH_V1AGENCEF_DB_FETCH_1 */

            R0510_00_FETCH_V1AGENCEF_DB_FETCH_1();

            /*" -1882- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1883- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1884- MOVE 'S' TO WFIM-V1AGENCEF */
                    _.Move("S", WFIM_V1AGENCEF);

                    /*" -1884- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1();

                    /*" -1886- ELSE */
                }
                else
                {


                    /*" -1886- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2();

                    /*" -1888- DISPLAY 'R0510 - PROBLEMAS NO FETCH V1AGENCEF' */
                    _.Display($"R0510 - PROBLEMAS NO FETCH V1AGENCEF");

                    /*" -1889- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1889- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-FETCH-1 */
        public void R0510_00_FETCH_V1AGENCEF_DB_FETCH_1()
        {
            /*" -1879- EXEC SQL FETCH V1AGENCEF INTO :DCLMALHA-CEF.MALHACEF-COD-FONTE, :DCLFONTES.FONTES-NOME-FONTE, :DCLFONTES.FONTES-ENDERECO, :DCLFONTES.FONTES-BAIRRO, :DCLFONTES.FONTES-CIDADE, :DCLFONTES.FONTES-CEP, :DCLFONTES.FONTES-SIGLA-UF END-EXEC. */

            if (V1AGENCEF.Fetch())
            {
                _.Move(V1AGENCEF.DCLMALHA_CEF_MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
                _.Move(V1AGENCEF.DCLFONTES_FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
                _.Move(V1AGENCEF.DCLFONTES_FONTES_ENDERECO, FONTES.DCLFONTES.FONTES_ENDERECO);
                _.Move(V1AGENCEF.DCLFONTES_FONTES_BAIRRO, FONTES.DCLFONTES.FONTES_BAIRRO);
                _.Move(V1AGENCEF.DCLFONTES_FONTES_CIDADE, FONTES.DCLFONTES.FONTES_CIDADE);
                _.Move(V1AGENCEF.DCLFONTES_FONTES_CEP, FONTES.DCLFONTES.FONTES_CEP);
                _.Move(V1AGENCEF.DCLFONTES_FONTES_SIGLA_UF, FONTES.DCLFONTES.FONTES_SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-CLOSE-1 */
        public void R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1()
        {
            /*" -1884- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-CLOSE-2 */
        public void R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2()
        {
            /*" -1886- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0520-00-CARREGA-FILIAL-SECTION */
        private void R0520_00_CARREGA_FILIAL_SECTION()
        {
            /*" -1901- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -1904- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-FONTE (IDX1) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_FONTE);

            /*" -1907- MOVE FONTES-NOME-FONTE OF DCLFONTES TO TAB-NOMEFTE(IDX1) */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_NOMEFTE);

            /*" -1910- MOVE FONTES-ENDERECO OF DCLFONTES TO TAB-ENDERFTE(IDX1) */
            _.Move(FONTES.DCLFONTES.FONTES_ENDERECO, TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_ENDERFTE);

            /*" -1913- MOVE FONTES-BAIRRO OF DCLFONTES TO TAB-BAIRRO (IDX1) */
            _.Move(FONTES.DCLFONTES.FONTES_BAIRRO, TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_BAIRRO);

            /*" -1916- MOVE FONTES-CIDADE OF DCLFONTES TO TAB-CIDADE (IDX1) */
            _.Move(FONTES.DCLFONTES.FONTES_CIDADE, TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_CIDADE);

            /*" -1919- MOVE FONTES-CEP OF DCLFONTES TO TAB-CEP (IDX1) */
            _.Move(FONTES.DCLFONTES.FONTES_CEP, TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_CEP);

            /*" -1922- MOVE FONTES-SIGLA-UF OF DCLFONTES TO TAB-UF (IDX1) */
            _.Move(FONTES.DCLFONTES.FONTES_SIGLA_UF, TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_UF);

            /*" -1922- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0RELATORIOS-SECTION */
        private void R0900_00_DECLARE_V0RELATORIOS_SECTION()
        {
            /*" -1967- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -1995- PERFORM R0900_00_DECLARE_V0RELATORIOS_DB_DECLARE_1 */

            R0900_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();

            /*" -1997- PERFORM R0900_00_DECLARE_V0RELATORIOS_DB_OPEN_1 */

            R0900_00_DECLARE_V0RELATORIOS_DB_OPEN_1();

            /*" -2000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2001- DISPLAY 'R0900 - PROBLEMAS NO OPEN CRELAT' */
                _.Display($"R0900 - PROBLEMAS NO OPEN CRELAT");

                /*" -2001- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0RELATORIOS-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -1997- EXEC SQL OPEN CRELAT END-EXEC. */

            CRELAT.Open();

        }

        [StopWatch]
        /*" R2300-00-MONTA-LINHAS-DB-DECLARE-1 */
        public void R2300_00_MONTA_LINHAS_DB_DECLARE_1()
        {
            /*" -3401- EXEC SQL DECLARE CADIC CURSOR FOR SELECT B.NUM_GARANTIA, B.DES_GARANTIA FROM SEGUROS.VG_COBER_TERMO A, SEGUROS.VG_GARANTIA B WHERE A.NUM_PROPOSTA_SIVPF = :VGCOBTER-NUM-PROPOSTA-SIVPF AND A.DTH_INI_VIGENCIA <= CURRENT DATE AND A.COD_GARANTIA > 0 AND A.DTH_FIM_VIGENCIA >= CURRENT DATE AND A.COD_GARANTIA = B.NUM_GARANTIA AND B.COD_TIPO_GARANTIA NOT IN ( 'B' , 'T' ) AND B.STA_GARANTIA = 'A' UNION SELECT B.NUM_GARANTIA, B.DES_GARANTIA FROM SEGUROS.VG_GARANTIA B WHERE B.COD_TIPO_GARANTIA = 'O' AND B.STA_GARANTIA = 'A' ORDER BY 1 END-EXEC. */
            CADIC = new VE0414B_CADIC(true);
            string GetQuery_CADIC()
            {
                var query = @$"SELECT 
							B.NUM_GARANTIA
							, B.DES_GARANTIA 
							FROM SEGUROS.VG_COBER_TERMO A
							, 
							SEGUROS.VG_GARANTIA B 
							WHERE 
							A.NUM_PROPOSTA_SIVPF = '{VGCOBTER.DCLVG_COBER_TERMO.VGCOBTER_NUM_PROPOSTA_SIVPF}' 
							AND A.DTH_INI_VIGENCIA <= CURRENT DATE 
							AND A.COD_GARANTIA > 0 
							AND A.DTH_FIM_VIGENCIA >= CURRENT DATE 
							AND A.COD_GARANTIA = B.NUM_GARANTIA 
							AND B.COD_TIPO_GARANTIA NOT IN ( 'B'
							, 'T' ) 
							AND B.STA_GARANTIA = 'A' 
							UNION 
							SELECT 
							B.NUM_GARANTIA
							, B.DES_GARANTIA 
							FROM SEGUROS.VG_GARANTIA B 
							WHERE 
							B.COD_TIPO_GARANTIA = 'O' 
							AND B.STA_GARANTIA = 'A' 
							ORDER BY 1";

                return query;
            }
            CADIC.GetQueryEvent += GetQuery_CADIC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0RELATORIOS-SECTION */
        private void R0910_00_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -2014- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WABEND.WNR_EXEC_SQL);

            /*" -2019- PERFORM R0910_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            R0910_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -2022- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2023- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2024- MOVE 'S' TO WFIM-V0RELAT */
                    _.Move("S", WFIM_V0RELAT);

                    /*" -2026- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                    _.Move(0, AC_CONTA, AC_LIDOS);

                    /*" -2026- PERFORM R0910_00_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                    R0910_00_FETCH_V0RELATORIOS_DB_CLOSE_1();

                    /*" -2028- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -2029- ELSE */
                }
                else
                {


                    /*" -2030- DISPLAY 'R0910 - PROBLEMAS NO FETCH CRELAT' */
                    _.Display($"R0910 - PROBLEMAS NO FETCH CRELAT");

                    /*" -2032- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2034- ADD 1 TO AC-CONTA AC-LIDOS-R AC-LIDOS. */
            AC_CONTA.Value = AC_CONTA + 1;
            AC_LIDOS_R.Value = AC_LIDOS_R + 1;
            AC_LIDOS.Value = AC_LIDOS + 1;

            /*" -2035- IF AC-CONTA > 99 */

            if (AC_CONTA > 99)
            {

                /*" -2036- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -2037- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), WHORA_CURR);

                /*" -2038- MOVE WHORA-CURR TO WHORA-CURR-DISP */
                _.Move(WHORA_CURR, WHORA_CURR_DISP);

                /*" -2039- DISPLAY '** QTD LIDOS RELATORIOS ' AC-LIDOS ' AS ' WHORA-CURR-DISP ' HS' . */

                $"** QTD LIDOS RELATORIOS {AC_LIDOS} AS {WHORA_CURR_DISP} HS"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void R0910_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -2019- EXEC SQL FETCH CRELAT INTO :DCLRELATORIOS.RELATORI-NUM-TITULO , :DCLRELATORIOS.RELATORI-NUM-APOLICE, :DCLRELATORIOS.RELATORI-COD-SUBGRUPO END-EXEC. */

            if (CRELAT.Fetch())
            {
                _.Move(CRELAT.DCLRELATORIOS_RELATORI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);
                _.Move(CRELAT.DCLRELATORIOS_RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(CRELAT.DCLRELATORIOS_RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0RELATORIOS-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -2026- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -2055- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -2056- PERFORM R1100-00-SELECT-V1TERMOADESAO. */

            R1100_00_SELECT_V1TERMOADESAO_SECTION();

            /*" -2057- IF WTEM-TERMO EQUAL 'N' */

            if (WTEM_TERMO == "N")
            {

                /*" -2058- ADD 1 TO AC-PENDE */
                AC_PENDE.Value = AC_PENDE + 1;

                /*" -2060- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2065- IF VGPROSIA-COD-PRODUTO = 8205 OR = 8209 OR = 8241 OR = 8242 OR = 9315 OR = 9316 OR = 9323 OR = 9324 OR = 9325 OR = 9326 OR = 9329 OR = 9343 OR = 9381 OR = 9382 OR = 9706 OR = 9712 OR = 9713 OR = 9714 OR = 9715 */

            if (VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO.In("8205", "8209", "8241", "8242", "9315", "9316", "9323", "9324", "9325", "9326", "9329", "9343", "9381", "9382", "9706", "9712", "9713", "9714", "9715"))
            {

                /*" -2066- ADD 1 TO AC-PENDE */
                AC_PENDE.Value = AC_PENDE + 1;

                /*" -2067- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2069- END-IF */
            }


            /*" -2070- PERFORM R1300-00-SELECT-V0ENDERECO. */

            R1300_00_SELECT_V0ENDERECO_SECTION();

            /*" -2071- IF WTEM-ENDERECO EQUAL 'N' */

            if (WTEM_ENDERECO == "N")
            {

                /*" -2072- ADD 1 TO AC-PENDE */
                AC_PENDE.Value = AC_PENDE + 1;

                /*" -2074- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2079- IF RELATORI-NUM-APOLICE = 108210105792 OR 109300001350 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.In("108210105792", "109300001350"))
            {

                /*" -2081- MOVE 05 TO MALHACEF-COD-FONTE */
                _.Move(05, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);

                /*" -2083- MOVE 'EMPRESARIAL CACB' TO AGENCCEF-NOME-AGENCIA */
                _.Move("EMPRESARIAL CACB", AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA);

                /*" -2084- ELSE */
            }
            else
            {


                /*" -2087- IF RELATORI-NUM-APOLICE = 109300001661 OR 108210554769 */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.In("109300001661", "108210554769"))
                {

                    /*" -2089- MOVE 05 TO MALHACEF-COD-FONTE */
                    _.Move(05, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);

                    /*" -2091- MOVE 'EMPRESARIAL OURO' TO AGENCCEF-NOME-AGENCIA */
                    _.Move("EMPRESARIAL OURO", AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA);

                    /*" -2092- ELSE */
                }
                else
                {


                    /*" -2093- PERFORM R1500-00-SELECT-V1AGENCEF */

                    R1500_00_SELECT_V1AGENCEF_SECTION();

                    /*" -2095- END-IF. */
                }

            }


            /*" -2098- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO SVA-FONTE. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, REG_SVE0414B.SVA_FONTE);

            /*" -2101- MOVE AGENCCEF-NOME-AGENCIA OF DCLAGENCIAS-CEF TO SVA-NOME-AGENCIA. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA, REG_SVE0414B.SVA_NOME_AGENCIA);

            /*" -2104- MOVE RELATORI-NUM-TITULO OF DCLRELATORIOS TO SVA-NUM-TERMO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO, REG_SVE0414B.SVA_NUM_TERMO);

            /*" -2107- MOVE RELATORI-NUM-APOLICE OF DCLRELATORIOS TO SVA-NRAPOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, REG_SVE0414B.SVA_NRAPOLICE);

            /*" -2110- MOVE RELATORI-COD-SUBGRUPO OF DCLRELATORIOS TO SVA-CODSUBES. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, REG_SVE0414B.SVA_CODSUBES);

            /*" -2113- MOVE TERMOADE-DATA-ADESAO OF DCLTERMO-ADESAO TO SVA-DATA-ADESAO. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, REG_SVE0414B.SVA_DATA_ADESAO);

            /*" -2116- MOVE TERMOADE-COD-AGENCIA-OP OF DCLTERMO-ADESAO TO SVA-COD-AGENCIA-OP. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP, REG_SVE0414B.SVA_COD_AGENCIA_OP);

            /*" -2119- MOVE TERMOADE-TIPO-PLANO OF DCLTERMO-ADESAO TO SVA-TIPO-PLANO. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_PLANO, REG_SVE0414B.SVA_TIPO_PLANO);

            /*" -2122- MOVE TERMOADE-MODALIDADE-CAPITAL OF DCLTERMO-ADESAO TO SVA-MODALIDADE-CAPITAL. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_MODALIDADE_CAPITAL, REG_SVE0414B.SVA_MODALIDADE_CAPITAL);

            /*" -2125- MOVE SUBGVGAP-OCORR-ENDERECO TO SVA-OCOREND. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO, REG_SVE0414B.SVA_OCOREND);

            /*" -2128- MOVE TERMOADE-COD-PLANO-APC OF DCLTERMO-ADESAO TO SVA-COD-PLANO-APC. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC, REG_SVE0414B.SVA_COD_PLANO_APC);

            /*" -2130- PERFORM R1940-00-SELECT-HISCOBPR. */

            R1940_00_SELECT_HISCOBPR_SECTION();

            /*" -2131- IF WTEM-HISCOBPR EQUAL 'N' */

            if (WTEM_HISCOBPR == "N")
            {

                /*" -2133- MOVE TERMOADE-VAL-CONTRATADO OF DCLTERMO-ADESAO TO SVA-VAL-CONTRATADO */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_CONTRATADO, REG_SVE0414B.SVA_VAL_CONTRATADO);

                /*" -2135- MOVE TERMOADE-VAL-RCAP OF DCLTERMO-ADESAO TO SVA-VAL-PREMIO */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_RCAP, REG_SVE0414B.SVA_VAL_PREMIO);

                /*" -2137- MOVE TERMOADE-QUANT-VIDAS OF DCLTERMO-ADESAO TO SVA-QUANT-VIDAS */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_QUANT_VIDAS, REG_SVE0414B.SVA_QUANT_VIDAS);

                /*" -2138- ELSE */
            }
            else
            {


                /*" -2139- MOVE HISCOBPR-IMPSEGUR TO SVA-VAL-CONTRATADO */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, REG_SVE0414B.SVA_VAL_CONTRATADO);

                /*" -2140- MOVE HISCOBPR-VLPREMIO TO SVA-VAL-PREMIO */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, REG_SVE0414B.SVA_VAL_PREMIO);

                /*" -2141- MOVE HISCOBPR-QUANT-VIDAS TO SVA-QUANT-VIDAS */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS, REG_SVE0414B.SVA_QUANT_VIDAS);

                /*" -2156- END-IF. */
            }


            /*" -2158- MOVE TERMOADE-TIPO-COBERTURA OF DCLTERMO-ADESAO TO SVA-TIPO-COBERTURA */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_COBERTURA, REG_SVE0414B.SVA_TIPO_COBERTURA);

            /*" -2160- MOVE TERMOADE-PERI-PAGAMENTO OF DCLTERMO-ADESAO TO SVA-PERI-PAGAMENTO */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO, REG_SVE0414B.SVA_PERI_PAGAMENTO);

            /*" -2162- MOVE TERMOADE-COD-CLIENTE OF DCLTERMO-ADESAO TO SVA-COD-CLIENTE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE, REG_SVE0414B.SVA_COD_CLIENTE);

            /*" -2164- MOVE ENDERECO-ENDERECO OF DCLENDERECOS TO SVA-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, REG_SVE0414B.SVA_ENDERECO);

            /*" -2166- MOVE ENDERECO-BAIRRO OF DCLENDERECOS TO SVA-BAIRRO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, REG_SVE0414B.SVA_BAIRRO);

            /*" -2168- MOVE ENDERECO-CIDADE OF DCLENDERECOS TO SVA-CIDADE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, REG_SVE0414B.SVA_CIDADE);

            /*" -2170- MOVE ENDERECO-SIGLA-UF OF DCLENDERECOS TO SVA-UF */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SVE0414B.SVA_UF);

            /*" -2173- MOVE ENDERECO-CEP OF DCLENDERECOS TO WS-NUM-CEP-AUX. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, WS_NUM_CEP_AUX);

            /*" -2174- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -2175- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SVE0414B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -2176- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SVE0414B.SVA_NUM_CEP.SVA_CEP);

                /*" -2177- ELSE */
            }
            else
            {


                /*" -2178- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SVE0414B.SVA_NUM_CEP.SVA_CEP);

                /*" -2180- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL. */
                _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SVE0414B.SVA_NUM_CEP.SVA_CEP_COMPL);
            }


            /*" -2191- MOVE SPACES TO SVA-NOME-CORREIO */
            _.Move("", REG_SVE0414B.SVA_NOME_CORREIO);

            /*" -2203- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO SVA-NUM-PROPOSTA-SIVPF. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, REG_SVE0414B.SVA_NUM_PROPOSTA_SIVPF);

            /*" -2205- PERFORM R1200-00-SELECT-OPCAO-PAG. */

            R1200_00_SELECT_OPCAO_PAG_SECTION();

            /*" -2206- IF WTEM-OPCAO EQUAL 'N' */

            if (WTEM_OPCAO == "N")
            {

                /*" -2208- MOVE VGCOMTRO-NUM-CONTA-DEBITO TO SVA-NUM-CONTA-DEBITO */
                _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CONTA_DEBITO, REG_SVE0414B.SVA_NUM_CONTA_DEBITO);

                /*" -2210- MOVE VGCOMTRO-DIG-CONTA-DEBITO TO SVA-DIG-CONTA-DEBITO */
                _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DIG_CONTA_DEBITO, REG_SVE0414B.SVA_DIG_CONTA_DEBITO);

                /*" -2212- MOVE VGCOMTRO-DTH-DIA-DEBITO TO SVA-DTH-DIA-DEBITO */
                _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DTH_DIA_DEBITO, REG_SVE0414B.SVA_DTH_DIA_DEBITO);

                /*" -2214- MOVE VGCOMTRO-COD-AGENCIA-DEB TO SVA-COD-AGENCIA-DEB */
                _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_COD_AGENCIA_DEB, REG_SVE0414B.SVA_COD_AGENCIA_DEB);

                /*" -2216- MOVE VGCOMTRO-OPERACAO-CONTA-DEB TO SVA-OPERACAO-CONTA-DEB */
                _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_OPERACAO_CONTA_DEB, REG_SVE0414B.SVA_OPERACAO_CONTA_DEB);

                /*" -2218- MOVE VGCOMTRO-NUM-CARTAO-CREDITO TO SVA-NUM-CARTAO-CREDITO */
                _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CARTAO_CREDITO, REG_SVE0414B.SVA_NUM_CARTAO_CREDITO);

                /*" -2219- ELSE */
            }
            else
            {


                /*" -2221- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO SVA-NUM-CONTA-DEBITO */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, REG_SVE0414B.SVA_NUM_CONTA_DEBITO);

                /*" -2223- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO SVA-DIG-CONTA-DEBITO */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, REG_SVE0414B.SVA_DIG_CONTA_DEBITO);

                /*" -2225- MOVE OPCPAGVI-DIA-DEBITO TO SVA-DTH-DIA-DEBITO */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, REG_SVE0414B.SVA_DTH_DIA_DEBITO);

                /*" -2227- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO SVA-COD-AGENCIA-DEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, REG_SVE0414B.SVA_COD_AGENCIA_DEB);

                /*" -2229- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO SVA-OPERACAO-CONTA-DEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, REG_SVE0414B.SVA_OPERACAO_CONTA_DEB);

                /*" -2231- MOVE OPCPAGVI-NUM-CARTAO-CREDITO TO SVA-NUM-CARTAO-CREDITO */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO, REG_SVE0414B.SVA_NUM_CARTAO_CREDITO);

                /*" -2233- END-IF. */
            }


            /*" -2234- PERFORM R1400-00-SELECT-PERIPGTO. */

            R1400_00_SELECT_PERIPGTO_SECTION();

            /*" -2235- IF WTEM-PERIPGTO EQUAL 'N' */

            if (WTEM_PERIPGTO == "N")
            {

                /*" -2236- ADD 1 TO AC-PENDE */
                AC_PENDE.Value = AC_PENDE + 1;

                /*" -2237- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2238- ELSE */
            }
            else
            {


                /*" -2239- EVALUATE OPCPAGVI-PERI-PAGAMENTO */
                switch (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO.Value)
                {

                    /*" -2240- WHEN 1 */
                    case 1:

                        /*" -2241- MOVE 'MENSAL' TO SVA-PERIODICIDADE */
                        _.Move("MENSAL", REG_SVE0414B.SVA_PERIODICIDADE);

                        /*" -2242- WHEN 12 */
                        break;
                    case 12:

                        /*" -2243- MOVE 'ANUAL' TO SVA-PERIODICIDADE */
                        _.Move("ANUAL", REG_SVE0414B.SVA_PERIODICIDADE);

                        /*" -2244- WHEN OTHER */
                        break;
                    default:

                        /*" -2245- MOVE SPACES TO SVA-PERIODICIDADE */
                        _.Move("", REG_SVE0414B.SVA_PERIODICIDADE);

                        /*" -2246- END-EVALUATE */
                        break;
                }


                /*" -2248- END-IF. */
            }


            /*" -2251- MOVE VGPROSIA-COD-PRODUTO TO SVA-CODPRODU W77-COD-PRODUTO WS-COD-PRODUTO. */
            _.Move(VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO, REG_SVE0414B.SVA_CODPRODU, W77_COD_PRODUTO, WS_COD_PRODUTO);

            /*" -2252- INITIALIZE WS-SIT-PRODUTO. */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -2256- PERFORM R1040-PRODUTO-RUNOFF. */

            R1040_PRODUTO_RUNOFF_SECTION();

            /*" -2258- MOVE SPACES TO SVA-SORTEIO. */
            _.Move("", REG_SVE0414B.SVA_SORTEIO);

            /*" -2268- IF W77-COD-PRODUTO = 8205 OR JVPRD8205 OR 8207 OR JVPRD8205 OR 8208 OR 8209 OR JVPRD8209 OR 8222 OR 9329 OR JVPRD9329 OR 9331 OR 9343 OR JVPRD9343 OR 9344 OR 9363 */

            if (W77_COD_PRODUTO.In("8205", JVBKINCL.JV_PRODUTOS.JVPRD8205.ToString(), "8207", JVBKINCL.JV_PRODUTOS.JVPRD8205.ToString(), "8208", "8209", JVBKINCL.JV_PRODUTOS.JVPRD8209.ToString(), "8222", "9329", JVBKINCL.JV_PRODUTOS.JVPRD9329.ToString(), "9331", "9343", JVBKINCL.JV_PRODUTOS.JVPRD9343.ToString(), "9344", "9363"))
            {

                /*" -2269- PERFORM R1600-00-SELECT-TITFEDCAP */

                R1600_00_SELECT_TITFEDCAP_SECTION();

                /*" -2271- END-IF. */
            }


            /*" -2273- IF RELATORI-NUM-APOLICE = 108210105792 OR 109300001350 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.In("108210105792", "109300001350"))
            {

                /*" -2274- MOVE 'VA62' TO SVA-FORMULARIO */
                _.Move("VA62", REG_SVE0414B.SVA_FORMULARIO);

                /*" -2275- ELSE */
            }
            else
            {


                /*" -2276- IF RELATORI-NUM-APOLICE = 109300001661 */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE == 109300001661)
                {

                    /*" -2277- MOVE 'VA71' TO SVA-FORMULARIO */
                    _.Move("VA71", REG_SVE0414B.SVA_FORMULARIO);

                    /*" -2278- ELSE */
                }
                else
                {


                    /*" -2279- IF RELATORI-NUM-APOLICE = 108210554769 */

                    if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE == 108210554769)
                    {

                        /*" -2280- MOVE 'VA72' TO SVA-FORMULARIO */
                        _.Move("VA72", REG_SVE0414B.SVA_FORMULARIO);

                        /*" -2281- ELSE */
                    }
                    else
                    {


                        /*" -2283- IF RELATORI-NUM-APOLICE = 97010000889 OR 109300000672 */

                        if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.In("97010000889", "109300000672"))
                        {

                            /*" -2284- MOVE 'VA95' TO SVA-FORMULARIO */
                            _.Move("VA95", REG_SVE0414B.SVA_FORMULARIO);

                            /*" -2286- ELSE */
                        }
                        else
                        {


                            /*" -2287- EVALUATE PRODUTO-COD-EMPRESA */
                            switch (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.Value)
                            {

                                /*" -2288- WHEN 10 */
                                case 10:

                                    /*" -2290- WHEN 11 */
                                    break;
                                case 11:

                                    /*" -2292- MOVE 'VA55' TO SVA-FORMULARIO */
                                    _.Move("VA55", REG_SVE0414B.SVA_FORMULARIO);

                                    /*" -2294- IF WS-PROD-RUNON */

                                    if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                                    {

                                        /*" -2295- MOVE 'VIDA09' TO SVA-FORMULARIO */
                                        _.Move("VIDA09", REG_SVE0414B.SVA_FORMULARIO);

                                        /*" -2296- END-IF */
                                    }


                                    /*" -2297- WHEN OTHER */
                                    break;
                                default:

                                    /*" -2298- MOVE 'VA55' TO SVA-FORMULARIO */
                                    _.Move("VA55", REG_SVE0414B.SVA_FORMULARIO);

                                    /*" -2301- END-EVALUATE */
                                    break;
                            }


                            /*" -2302- END-IF */
                        }


                        /*" -2303- END-IF */
                    }


                    /*" -2304- END-IF */
                }


                /*" -2306- END-IF. */
            }


            /*" -2310- IF WTEM-SORTEIO EQUAL 'N' AND ( SVA-FORMULARIO EQUAL 'VA55' OR = 'VIDA09' ) */

            if (WTEM_SORTEIO == "N" && (REG_SVE0414B.SVA_FORMULARIO.In("VA55", "VIDA09")))
            {

                /*" -2311- ADD 1 TO AC-DESPR-TITULO */
                AC_DESPR_TITULO.Value = AC_DESPR_TITULO + 1;

                /*" -2312- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2314- END-IF. */
            }


            /*" -2315- ADD 1 TO AC-SELEC */
            AC_SELEC.Value = AC_SELEC + 1;

            /*" -2315- RELEASE REG-SVE0414B. */
            SVE0414B.Release(REG_SVE0414B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -2319- PERFORM R0910-00-FETCH-V0RELATORIOS. */

            R0910_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1040-PRODUTO-RUNOFF-SECTION */
        private void R1040_PRODUTO_RUNOFF_SECTION()
        {
            /*" -2327- SET WS-IND-PROD TO 1 */
            JVBKINCL.WS_IND_PROD.Value = 1;

            /*" -2329- SEARCH CVPPROD AT END */
            void SearchAtEnd0()
            {

                /*" -2330- SET WS-PROD-RUNON TO TRUE */
                AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] = true;

                /*" -2331- WHEN CVPPROD(WS-IND-PROD) EQUAL WS-COD-PRODUTO */
            };

            var mustSearchAtEnd0 = true;
            for (; JVBKINCL.WS_IND_PROD < JVBKINCL.CVP_PRODUTO.CVPPROD.Items.Count; JVBKINCL.WS_IND_PROD.Value++)
            {

                if (JVBKINCL.CVP_PRODUTO.CVPPROD[JVBKINCL.WS_IND_PROD] == WS_COD_PRODUTO)
                {

                    mustSearchAtEnd0 = false;

                    /*" -2332- SET WS-PROD-RUNOFF TO TRUE */
                    AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNOFF"] = true;

                    /*" -2334- END-SEARCH */

                    /*" -2334- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1TERMOADESAO-SECTION */
        private void R1100_00_SELECT_V1TERMOADESAO_SECTION()
        {
            /*" -2345- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -2347- MOVE 'S' TO WTEM-TERMO. */
            _.Move("S", WTEM_TERMO);

            /*" -2402- PERFORM R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1 */

            R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1();

            /*" -2405- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2406- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2407- MOVE 'N' TO WTEM-TERMO */
                    _.Move("N", WTEM_TERMO);

                    /*" -2408- ELSE */
                }
                else
                {


                    /*" -2409- DISPLAY 'R1100 - PROBLEMAS ACESSO TERMO_ADESAO' */
                    _.Display($"R1100 - PROBLEMAS ACESSO TERMO_ADESAO");

                    /*" -2411- DISPLAY 'NUM-TITULO  ' RELATORI-NUM-TITULO OF DCLRELATORIOS */
                    _.Display($"NUM-TITULO  {RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO}");

                    /*" -2412- DISPLAY 'SQLCODE     ' SQLCODE */
                    _.Display($"SQLCODE     {DB.SQLCODE}");

                    /*" -2414- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2415- IF VIND-VLRCAP LESS ZEROS */

            if (VIND_VLRCAP < 00)
            {

                /*" -2418- MOVE ZEROS TO TERMOADE-VAL-RCAP OF DCLTERMO-ADESAO. */
                _.Move(0, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_RCAP);
            }


            /*" -2419- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2421- MOVE '11A' TO WNR-EXEC-SQL */
                _.Move("11A", WABEND.WNR_EXEC_SQL);

                /*" -2422- MOVE TERMOADE-NUM-APOLICE TO VGPROSIA-NUM-APOLICE */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_APOLICE);

                /*" -2424- MOVE TERMOADE-PERI-PAGAMENTO TO VGPROSIA-NUM-PERIODO-PAG */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG);

                /*" -2438- PERFORM R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2 */

                R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2();

                /*" -2442- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -2443- IF VGPROSIA-COD-PRODUTO-EMP NOT EQUAL 16 AND 01 */

                    if (!VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP.In("16", "01"))
                    {

                        /*" -2444- MOVE 'N' TO WTEM-TERMO */
                        _.Move("N", WTEM_TERMO);

                        /*" -2445- GO TO R1100-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                        return;

                        /*" -2446- END-IF */
                    }


                    /*" -2447- ELSE */
                }
                else
                {


                    /*" -2448- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2449- MOVE 'N' TO WTEM-TERMO */
                        _.Move("N", WTEM_TERMO);

                        /*" -2450- GO TO R1100-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                        return;

                        /*" -2451- ELSE */
                    }
                    else
                    {


                        /*" -2452- DISPLAY 'R1100 - PROBLEMAS ACESSO VG_PRODUTO_SIAS' */
                        _.Display($"R1100 - PROBLEMAS ACESSO VG_PRODUTO_SIAS");

                        /*" -2453- DISPLAY 'NUM-APOLICE ' TERMOADE-NUM-APOLICE */
                        _.Display($"NUM-APOLICE {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE}");

                        /*" -2454- DISPLAY 'PERIPAGTO   ' TERMOADE-PERI-PAGAMENTO */
                        _.Display($"PERIPAGTO   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO}");

                        /*" -2455- DISPLAY 'SQLCODE     ' SQLCODE */
                        _.Display($"SQLCODE     {DB.SQLCODE}");

                        /*" -2455- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V1TERMOADESAO-DB-SELECT-1 */
        public void R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1()
        {
            /*" -2402- EXEC SQL SELECT A.NUM_APOLICE, A.NUM_TERMO, A.COD_SUBGRUPO, A.DATA_ADESAO, A.COD_AGENCIA_OP, A.MODALIDADE_CAPITAL, A.TIPO_PLANO, A.COD_PLANO_VGAPC, A.COD_PLANO_APC, A.VAL_CONTRATADO, A.VAL_RCAP, A.QUANT_VIDAS, A.TIPO_COBERTURA, A.PERI_PAGAMENTO, A.COD_CLIENTE, B.NUM_PROPOSTA_SIVPF, B.DTH_DIA_DEBITO, B.COD_AGENCIA_DEB, B.OPERACAO_CONTA_DEB, B.NUM_CONTA_DEBITO, B.DIG_CONTA_DEBITO, B.NUM_CARTAO_CREDITO, C.OCORR_ENDERECO INTO :DCLTERMO-ADESAO.TERMOADE-NUM-APOLICE, :DCLTERMO-ADESAO.TERMOADE-NUM-TERMO, :DCLTERMO-ADESAO.TERMOADE-COD-SUBGRUPO, :DCLTERMO-ADESAO.TERMOADE-DATA-ADESAO, :DCLTERMO-ADESAO.TERMOADE-COD-AGENCIA-OP, :DCLTERMO-ADESAO.TERMOADE-MODALIDADE-CAPITAL, :DCLTERMO-ADESAO.TERMOADE-TIPO-PLANO, :DCLTERMO-ADESAO.TERMOADE-COD-PLANO-VGAPC, :DCLTERMO-ADESAO.TERMOADE-COD-PLANO-APC, :DCLTERMO-ADESAO.TERMOADE-VAL-CONTRATADO, :DCLTERMO-ADESAO.TERMOADE-VAL-RCAP:VIND-VLRCAP, :DCLTERMO-ADESAO.TERMOADE-QUANT-VIDAS, :DCLTERMO-ADESAO.TERMOADE-TIPO-COBERTURA, :DCLTERMO-ADESAO.TERMOADE-PERI-PAGAMENTO, :DCLTERMO-ADESAO.TERMOADE-COD-CLIENTE, :VGCOMTRO-NUM-PROPOSTA-SIVPF, :VGCOMTRO-DTH-DIA-DEBITO, :VGCOMTRO-COD-AGENCIA-DEB, :VGCOMTRO-OPERACAO-CONTA-DEB, :VGCOMTRO-NUM-CONTA-DEBITO, :VGCOMTRO-DIG-CONTA-DEBITO, :VGCOMTRO-NUM-CARTAO-CREDITO, :SUBGVGAP-OCORR-ENDERECO FROM SEGUROS.TERMO_ADESAO A, SEGUROS.VG_COMPL_TERMO B, SEGUROS.SUBGRUPOS_VGAP C WHERE A.NUM_TERMO = :DCLRELATORIOS.RELATORI-NUM-TITULO AND A.NUM_TERMO = B.NUM_TERMO AND A.NUM_APOLICE = C.NUM_APOLICE AND A.COD_SUBGRUPO = C.COD_SUBGRUPO END-EXEC. */

            var r1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TERMOADE_NUM_APOLICE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);
                _.Move(executed_1.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
                _.Move(executed_1.TERMOADE_COD_SUBGRUPO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO);
                _.Move(executed_1.TERMOADE_DATA_ADESAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO);
                _.Move(executed_1.TERMOADE_COD_AGENCIA_OP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP);
                _.Move(executed_1.TERMOADE_MODALIDADE_CAPITAL, TERMOADE.DCLTERMO_ADESAO.TERMOADE_MODALIDADE_CAPITAL);
                _.Move(executed_1.TERMOADE_TIPO_PLANO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_PLANO);
                _.Move(executed_1.TERMOADE_COD_PLANO_VGAPC, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC);
                _.Move(executed_1.TERMOADE_COD_PLANO_APC, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC);
                _.Move(executed_1.TERMOADE_VAL_CONTRATADO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_CONTRATADO);
                _.Move(executed_1.TERMOADE_VAL_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_RCAP);
                _.Move(executed_1.VIND_VLRCAP, VIND_VLRCAP);
                _.Move(executed_1.TERMOADE_QUANT_VIDAS, TERMOADE.DCLTERMO_ADESAO.TERMOADE_QUANT_VIDAS);
                _.Move(executed_1.TERMOADE_TIPO_COBERTURA, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_COBERTURA);
                _.Move(executed_1.TERMOADE_PERI_PAGAMENTO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO);
                _.Move(executed_1.TERMOADE_COD_CLIENTE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE);
                _.Move(executed_1.VGCOMTRO_NUM_PROPOSTA_SIVPF, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.VGCOMTRO_DTH_DIA_DEBITO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DTH_DIA_DEBITO);
                _.Move(executed_1.VGCOMTRO_COD_AGENCIA_DEB, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_COD_AGENCIA_DEB);
                _.Move(executed_1.VGCOMTRO_OPERACAO_CONTA_DEB, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_OPERACAO_CONTA_DEB);
                _.Move(executed_1.VGCOMTRO_NUM_CONTA_DEBITO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CONTA_DEBITO);
                _.Move(executed_1.VGCOMTRO_DIG_CONTA_DEBITO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DIG_CONTA_DEBITO);
                _.Move(executed_1.VGCOMTRO_NUM_CARTAO_CREDITO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CARTAO_CREDITO);
                _.Move(executed_1.SUBGVGAP_OCORR_ENDERECO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1TERMOADESAO-DB-SELECT-2 */
        public void R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2()
        {
            /*" -2438- EXEC SQL SELECT A.COD_PRODUTO_EMP, A.COD_PRODUTO, B.COD_EMPRESA INTO :VGPROSIA-COD-PRODUTO-EMP, :VGPROSIA-COD-PRODUTO, :PRODUTO-COD-EMPRESA FROM SEGUROS.VG_PRODUTO_SIAS A ,SEGUROS.PRODUTO B WHERE A.NUM_APOLICE = :VGPROSIA-NUM-APOLICE AND A.NUM_PERIODO_PAG = :VGPROSIA-NUM-PERIODO-PAG AND B.COD_PRODUTO = A.COD_PRODUTO END-EXEC */

            var r1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1 = new R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1()
            {
                VGPROSIA_NUM_PERIODO_PAG = VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG.ToString(),
                VGPROSIA_NUM_APOLICE = VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1.Execute(r1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGPROSIA_COD_PRODUTO_EMP, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP);
                _.Move(executed_1.VGPROSIA_COD_PRODUTO, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO);
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-OPCAO-PAG-SECTION */
        private void R1200_00_SELECT_OPCAO_PAG_SECTION()
        {
            /*" -2467- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -2469- MOVE 'S' TO WTEM-OPCAO. */
            _.Move("S", WTEM_OPCAO);

            /*" -2486- PERFORM R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1 */

            R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1();

            /*" -2489- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2490- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2491- MOVE 'N' TO WTEM-OPCAO */
                    _.Move("N", WTEM_OPCAO);

                    /*" -2492- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -2493- ELSE */
                }
                else
                {


                    /*" -2494- DISPLAY 'R1200-PROBLEMAS NO SEL OPCAO_PAG_VIDAZUL' */
                    _.Display($"R1200-PROBLEMAS NO SEL OPCAO_PAG_VIDAZUL");

                    /*" -2495- DISPLAY 'CERTIFICADO: ' RELATORI-NUM-TITULO */
                    _.Display($"CERTIFICADO: {RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO}");

                    /*" -2496- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2497- END-IF */
                }


                /*" -2499- END-IF. */
            }


            /*" -2500- IF WIND-CTADEB LESS THAN ZERO */

            if (WIND_CTADEB < 00)
            {

                /*" -2501- MOVE ZEROS TO OPCPAGVI-NUM-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

                /*" -2503- END-IF. */
            }


            /*" -2504- IF WIND-DGCTA LESS THAN ZERO */

            if (WIND_DGCTA < 00)
            {

                /*" -2505- MOVE ZEROS TO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -2507- END-IF. */
            }


            /*" -2508- IF WIND-AGENCIA LESS THAN ZERO */

            if (WIND_AGENCIA < 00)
            {

                /*" -2509- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

                /*" -2511- END-IF. */
            }


            /*" -2512- IF WIND-OPER LESS THAN ZERO */

            if (WIND_OPER < 00)
            {

                /*" -2513- MOVE ZEROS TO OPCPAGVI-OPE-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

                /*" -2515- END-IF. */
            }


            /*" -2516- IF WIND-CARTAO LESS THAN ZERO */

            if (WIND_CARTAO < 00)
            {

                /*" -2517- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -2517- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-OPCAO-PAG-DB-SELECT-1 */
        public void R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1()
        {
            /*" -2486- EXEC SQL SELECT NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CARTAO_CREDITO INTO :OPCPAGVI-NUM-CONTA-DEBITO:WIND-CTADEB , :OPCPAGVI-DIG-CONTA-DEBITO:WIND-DGCTA , :OPCPAGVI-DIA-DEBITO , :OPCPAGVI-COD-AGENCIA-DEBITO:WIND-AGENCIA , :OPCPAGVI-OPE-CONTA-DEBITO:WIND-OPER , :OPCPAGVI-NUM-CARTAO-CREDITO:WIND-CARTAO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :DCLRELATORIOS.RELATORI-NUM-TITULO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1 = new R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.WIND_CTADEB, WIND_CTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.WIND_DGCTA, WIND_DGCTA);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.WIND_AGENCIA, WIND_AGENCIA);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.WIND_OPER, WIND_OPER);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.WIND_CARTAO, WIND_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDERECO-SECTION */
        private void R1300_00_SELECT_V0ENDERECO_SECTION()
        {
            /*" -2528- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -2530- MOVE 'S' TO WTEM-ENDERECO. */
            _.Move("S", WTEM_ENDERECO);

            /*" -2545- PERFORM R1300_00_SELECT_V0ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_V0ENDERECO_DB_SELECT_1();

            /*" -2548- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2549- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2550- MOVE 'N' TO WTEM-ENDERECO */
                    _.Move("N", WTEM_ENDERECO);

                    /*" -2551- ELSE */
                }
                else
                {


                    /*" -2552- DISPLAY 'R1300 - PROBLEMAS ACESSO TAB. ENDERECOS' */
                    _.Display($"R1300 - PROBLEMAS ACESSO TAB. ENDERECOS");

                    /*" -2554- DISPLAY 'NUM-TITULO  ' RELATORI-NUM-TITULO OF DCLRELATORIOS */
                    _.Display($"NUM-TITULO  {RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO}");

                    /*" -2556- DISPLAY 'CLIENTE     ' TERMOADE-COD-CLIENTE OF DCLTERMO-ADESAO */
                    _.Display($"CLIENTE     {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                    /*" -2557- DISPLAY 'SQLCODE     ' SQLCODE */
                    _.Display($"SQLCODE     {DB.SQLCODE}");

                    /*" -2557- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0ENDERECO_DB_SELECT_1()
        {
            /*" -2545- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :DCLENDERECOS.ENDERECO-ENDERECO, :DCLENDERECOS.ENDERECO-BAIRRO, :DCLENDERECOS.ENDERECO-CIDADE, :DCLENDERECOS.ENDERECO-SIGLA-UF, :DCLENDERECOS.ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLTERMO-ADESAO.TERMOADE-COD-CLIENTE AND OCORR_ENDERECO = 1 END-EXEC. */

            var r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1()
            {
                TERMOADE_COD_CLIENTE = TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PERIPGTO-SECTION */
        private void R1400_00_SELECT_PERIPGTO_SECTION()
        {
            /*" -2569- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -2571- MOVE SPACES TO SVA-PERIODICIDADE */
            _.Move("", REG_SVE0414B.SVA_PERIODICIDADE);

            /*" -2573- MOVE 'S' TO WTEM-PERIPGTO. */
            _.Move("S", WTEM_PERIPGTO);

            /*" -2579- PERFORM R1400_00_SELECT_PERIPGTO_DB_SELECT_1 */

            R1400_00_SELECT_PERIPGTO_DB_SELECT_1();

            /*" -2582- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2583- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2584- MOVE 'N' TO WTEM-PERIPGTO */
                    _.Move("N", WTEM_PERIPGTO);

                    /*" -2585- GO TO R1400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                    return;

                    /*" -2586- ELSE */
                }
                else
                {


                    /*" -2587- DISPLAY 'R1400-PROBLEMAS NO SEL OPCAO_PAG_VIDAZUL' */
                    _.Display($"R1400-PROBLEMAS NO SEL OPCAO_PAG_VIDAZUL");

                    /*" -2588- DISPLAY 'CERTIFICADO...: ' RELATORI-NUM-TITULO */
                    _.Display($"CERTIFICADO...: {RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO}");

                    /*" -2589- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2590- END-IF */
                }


                /*" -2590- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-PERIPGTO-DB-SELECT-1 */
        public void R1400_00_SELECT_PERIPGTO_DB_SELECT_1()
        {
            /*" -2579- EXEC SQL SELECT PERI_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-TITULO AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var r1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1 = new R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-SECTION */
        private void R1500_00_SELECT_V1AGENCEF_SECTION()
        {
            /*" -2602- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -2606- MOVE TERMOADE-COD-AGENCIA-OP OF DCLTERMO-ADESAO TO AGENCCEF-COD-AGENCIA OF DCLAGENCIAS-CEF. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

            /*" -2617- PERFORM R1500_00_SELECT_V1AGENCEF_DB_SELECT_1 */

            R1500_00_SELECT_V1AGENCEF_DB_SELECT_1();

            /*" -2627- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2628- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2630- MOVE 05 TO MALHACEF-COD-FONTE OF DCLMALHA-CEF */
                    _.Move(05, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);

                    /*" -2632- MOVE 'VIDA EMPRESARIAL' TO AGENCCEF-NOME-AGENCIA OF DCLAGENCIAS-CEF */
                    _.Move("VIDA EMPRESARIAL", AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA);

                    /*" -2633- ELSE */
                }
                else
                {


                    /*" -2634- DISPLAY 'R1500 - ERRO ACESSO AGENCIAS_CEF' */
                    _.Display($"R1500 - ERRO ACESSO AGENCIAS_CEF");

                    /*" -2636- DISPLAY 'AGENCIA - ' AGENCCEF-COD-AGENCIA OF DCLAGENCIAS-CEF */
                    _.Display($"AGENCIA - {AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA}");

                    /*" -2637- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -2637- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_V1AGENCEF_DB_SELECT_1()
        {
            /*" -2617- EXEC SQL SELECT A.NOME_AGENCIA, B.COD_FONTE INTO :DCLAGENCIAS-CEF.AGENCCEF-NOME-AGENCIA, :DCLMALHA-CEF.MALHACEF-COD-FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :DCLAGENCIAS-CEF.AGENCCEF-COD-AGENCIA END-EXEC. */

            var r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 = new R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_NOME_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA);
                _.Move(executed_1.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-TITFEDCAP-SECTION */
        private void R1600_00_SELECT_TITFEDCAP_SECTION()
        {
            /*" -2649- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -2720- MOVE 'S' TO WTEM-SORTEIO */
            _.Move("S", WTEM_SORTEIO);

            /*" -2742- INITIALIZE WF-NUM-PLANO , WF-NUM-SERIE , WF-NUM-TITULO , WF-COD-STA-TITULO , WF-COD-SUB-STATUS , WF-DTH-ATIVACAO , WF-DTH-CADUCACAO , WF-DTH-CRIACAO , WF-DTH-FIM-VIGENCIA , WF-DTH-INI-SORTEIO , WF-DTH-INI-VIGENCIA , WF-DTH-SUSPENSAO , WF-IND-DV , WF-VLR-MENSALIDADE , WF-NUM-PROPOSTA , WF-NUM-MOD-PLANO , LK-OUT-COD-RET-FC12 , LK-OUT-SQLCODE-FC12 , LK-OUT-MENSAGEM-FC12 , LK-OUT-SQLERRMC-FC12 , LK-OUT-SQLSTATE-FC12 */
            _.Initialize(
                WF_NUM_PLANO
                , WF_NUM_SERIE
                , WF_NUM_TITULO
                , WF_COD_STA_TITULO
                , WF_COD_SUB_STATUS
                , WF_DTH_ATIVACAO
                , WF_DTH_CADUCACAO
                , WF_DTH_CRIACAO
                , WF_DTH_FIM_VIGENCIA
                , WF_DTH_INI_SORTEIO
                , WF_DTH_INI_VIGENCIA
                , WF_DTH_SUSPENSAO
                , WF_IND_DV
                , WF_VLR_MENSALIDADE
                , WF_NUM_PROPOSTA
                , WF_NUM_MOD_PLANO
                , LK_OUT_COD_RET_FC12
                , LK_OUT_SQLCODE_FC12
                , LK_OUT_MENSAGEM_FC12
                , LK_OUT_SQLERRMC_FC12
                , LK_OUT_SQLSTATE_FC12
            );

            /*" -2744- MOVE RELATORI-NUM-TITULO TO LK-NUM-PROPOSTA-FC12 WS-NUM-PROPOSTA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO, LK_NUM_PROPOSTA_FC12, WS_NUM_PROPOSTA);

            /*" -2746- MOVE ZEROS TO LK-NUM-PLANO-FC12 WS-NUM-PLANO */
            _.Move(0, LK_NUM_PLANO_FC12, WS_NUM_PLANO);

            /*" -2748- MOVE VGPROSIA-COD-PRODUTO TO LK-COD-RAMO-FC12 WS-COD-RAMO */
            _.Move(VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO, LK_COD_RAMO_FC12, WS_COD_RAMO);

            /*" -2750- MOVE 'TRACE OFF' TO LK-TRACE-FC12 */
            _.Move("TRACE OFF", LK_TRACE_FC12);

            /*" -2762- PERFORM R1600_00_SELECT_TITFEDCAP_DB_CALL_1 */

            R1600_00_SELECT_TITFEDCAP_DB_CALL_1();

            /*" -2765- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2767- MOVE LK-OUT-COD-RET-FC12 TO WS-COD-RETORNO */
            _.Move(LK_OUT_COD_RET_FC12, WS_COD_RETORNO);

            /*" -2768- IF SQLCODE NOT = 000 AND +466 */

            if (!DB.SQLCODE.In("000", "+466"))
            {

                /*" -2771- DISPLAY 'ERRO NA CONSULTA - SPBVG012 - ' ' COD-RET <' WS-COD-RETORNO '>' ' SQLCODE <' WSQLCODE '>' */

                $"ERRO NA CONSULTA - SPBVG012 -  COD-RET <{WS_COD_RETORNO}> SQLCODE <{WABEND.WSQLCODE}>"
                .Display();

                /*" -2775- DISPLAY ' BILHETE <' LK-NUM-PROPOSTA-FC12 '/' LK-OUT-COD-RET-FC12 '/' LK-OUT-MENSAGEM-FC12 '/' LK-OUT-SQLSTATE-FC12 '>' */

                $" BILHETE <{LK_NUM_PROPOSTA_FC12}/{LK_OUT_COD_RET_FC12}/{LK_OUT_MENSAGEM_FC12}/{LK_OUT_SQLSTATE_FC12}>"
                .Display();

                /*" -2776- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2778- END-IF */
            }


            /*" -2779- IF LK-OUT-COD-RET-FC12 NOT EQUAL ZEROES */

            if (LK_OUT_COD_RET_FC12 != 00)
            {

                /*" -2780- DISPLAY 'LK-OUT-COD-RETORNO = ' WS-COD-RETORNO */
                _.Display($"LK-OUT-COD-RETORNO = {WS_COD_RETORNO}");

                /*" -2783- DISPLAY 'ERRO NA RETORNO DA SPBVG012 - ' ' COD-RET <' WS-COD-RETORNO '>' ' SQLCODE <' WSQLCODE '>' */

                $"ERRO NA RETORNO DA SPBVG012 -  COD-RET <{WS_COD_RETORNO}> SQLCODE <{WABEND.WSQLCODE}>"
                .Display();

                /*" -2788- DISPLAY ' BILHETE <' LK-NUM-PROPOSTA-FC12 '/' LK-OUT-COD-RET-FC12 '/' LK-OUT-MENSAGEM-FC12 '/' LK-OUT-SQLERRMC-FC12 '/' LK-OUT-SQLSTATE-FC12 '>' */

                $" BILHETE <{LK_NUM_PROPOSTA_FC12}/{LK_OUT_COD_RET_FC12}/{LK_OUT_MENSAGEM_FC12}/{LK_OUT_SQLERRMC_FC12}/{LK_OUT_SQLSTATE_FC12}>"
                .Display();

                /*" -2789- MOVE 'N' TO WTEM-SORTEIO */
                _.Move("N", WTEM_SORTEIO);

                /*" -2791- END-IF */
            }


            /*" -2792- IF LK-OUT-COD-RET-FC12 EQUAL ZEROES */

            if (LK_OUT_COD_RET_FC12 == 00)
            {

                /*" -2793- MOVE ZEROS TO WS-EOF-RESULT */
                _.Move(0, WS_EOF.WS_EOF_RESULT);

                /*" -2794- IF SQLCODE = +466 */

                if (DB.SQLCODE == +466)
                {

                    /*" -2795- PERFORM R9140-TRATAR-RESULT */

                    R9140_TRATAR_RESULT_SECTION();

                    /*" -2797- PERFORM R9150-LER-RESULT UNTIL WS-EOF-RESULT NOT EQUAL ZEROES */

                    while (!(WS_EOF.WS_EOF_RESULT != 00))
                    {

                        R9150_LER_RESULT_SECTION();
                    }

                    /*" -2798- PERFORM R9160-FECHAR-CURSOR */

                    R9160_FECHAR_CURSOR_SECTION();

                    /*" -2799- END-IF */
                }


                /*" -2800- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-TITFEDCAP-DB-CALL-1 */
        public void R1600_00_SELECT_TITFEDCAP_DB_CALL_1()
        {
            /*" -2762- EXEC SQL CALL SEGUROS.SPBVG012 ( :LK-NUM-PLANO-FC12 , :LK-NUM-PROPOSTA-FC12 , :LK-COD-RAMO-FC12 , :LK-TRACE-FC12 , :LK-OUT-COD-RET-FC12 , :LK-OUT-SQLCODE-FC12 , :LK-OUT-MENSAGEM-FC12 , :LK-OUT-SQLERRMC-FC12 , :LK-OUT-SQLSTATE-FC12 ) END-EXEC */

            var sEGUROS_SPBVG012_Call1 = new SEGUROS_SPBVG012_Call1()
            {
                LK_NUM_PLANO_FC12 = LK_NUM_PLANO_FC12.ToString(),
                LK_NUM_PROPOSTA_FC12 = LK_NUM_PROPOSTA_FC12.ToString(),
                LK_COD_RAMO_FC12 = LK_COD_RAMO_FC12.ToString(),
                LK_TRACE_FC12 = LK_TRACE_FC12.ToString(),
                LK_OUT_COD_RET_FC12 = LK_OUT_COD_RET_FC12.ToString(),
                LK_OUT_SQLCODE_FC12 = LK_OUT_SQLCODE_FC12.ToString(),
                LK_OUT_MENSAGEM_FC12 = LK_OUT_MENSAGEM_FC12.ToString(),
                LK_OUT_SQLERRMC_FC12 = LK_OUT_SQLERRMC_FC12.ToString(),
                LK_OUT_SQLSTATE_FC12 = LK_OUT_SQLSTATE_FC12.ToString(),
            };

            var executed_1 = SEGUROS_SPBVG012_Call1.Execute(sEGUROS_SPBVG012_Call1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_NUM_PLANO_FC12, LK_NUM_PLANO_FC12);
                _.Move(executed_1.LK_NUM_PROPOSTA_FC12, LK_NUM_PROPOSTA_FC12);
                _.Move(executed_1.LK_COD_RAMO_FC12, LK_COD_RAMO_FC12);
                _.Move(executed_1.LK_TRACE_FC12, LK_TRACE_FC12);
                _.Move(executed_1.LK_OUT_COD_RET_FC12, LK_OUT_COD_RET_FC12);
                _.Move(executed_1.LK_OUT_SQLCODE_FC12, LK_OUT_SQLCODE_FC12);
                _.Move(executed_1.LK_OUT_MENSAGEM_FC12, LK_OUT_MENSAGEM_FC12);
                _.Move(executed_1.LK_OUT_SQLERRMC_FC12, LK_OUT_SQLERRMC_FC12);
                _.Move(executed_1.LK_OUT_SQLSTATE_FC12, LK_OUT_SQLSTATE_FC12);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1940-00-SELECT-HISCOBPR-SECTION */
        private void R1940_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -2846- MOVE '1940' TO WNR-EXEC-SQL. */
            _.Move("1940", WABEND.WNR_EXEC_SQL);

            /*" -2848- MOVE 'S' TO WTEM-HISCOBPR. */
            _.Move("S", WTEM_HISCOBPR);

            /*" -2860- PERFORM R1940_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1940_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -2863- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2864- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2877- PERFORM R1940_00_SELECT_HISCOBPR_DB_SELECT_2 */

                    R1940_00_SELECT_HISCOBPR_DB_SELECT_2();

                    /*" -2880- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2881- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -2882- MOVE 'N' TO WTEM-HISCOBPR */
                            _.Move("N", WTEM_HISCOBPR);

                            /*" -2883- GO TO R1940-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1940_99_SAIDA*/ //GOTO
                            return;

                            /*" -2884- ELSE */
                        }
                        else
                        {


                            /*" -2885- DISPLAY 'R1940 - ERRO 2� ACESSO HIS_COBER_PROPOST' */
                            _.Display($"R1940 - ERRO 2� ACESSO HIS_COBER_PROPOST");

                            /*" -2886- DISPLAY 'CERTIFICADO : ' RELATORI-NUM-TITULO */
                            _.Display($"CERTIFICADO : {RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO}");

                            /*" -2887- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -2888- END-IF */
                        }


                        /*" -2889- END-IF */
                    }


                    /*" -2890- ELSE */
                }
                else
                {


                    /*" -2891- DISPLAY 'R1940 - ERRO 1� ACESSO HIS_COBER_PROPOST' */
                    _.Display($"R1940 - ERRO 1� ACESSO HIS_COBER_PROPOST");

                    /*" -2892- DISPLAY 'CERTIFICADO: ' VGCOMTRO-NUM-PROPOSTA-SIVPF */
                    _.Display($"CERTIFICADO: {VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF}");

                    /*" -2893- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2894- END-IF */
                }


                /*" -2894- END-IF. */
            }


        }

        [StopWatch]
        /*" R1940-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1940_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -2860- EXEC SQL SELECT IMPSEGUR , QUANT_VIDAS, VLPREMIO INTO :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS, :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :VGCOMTRO-NUM-PROPOSTA-SIVPF AND DATA_TERVIGENCIA = '9999-12-31' ORDER BY OCORR_HISTORICO DESC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                VGCOMTRO_NUM_PROPOSTA_SIVPF = VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
                _.Move(executed_1.HISCOBPR_QUANT_VIDAS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1940_99_SAIDA*/

        [StopWatch]
        /*" R1940-00-SELECT-HISCOBPR-DB-SELECT-2 */
        public void R1940_00_SELECT_HISCOBPR_DB_SELECT_2()
        {
            /*" -2877- EXEC SQL SELECT IMPSEGUR , QUANT_VIDAS, VLPREMIO INTO :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS, :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :DCLRELATORIOS.RELATORI-NUM-TITULO AND DATA_TERVIGENCIA = '9999-12-31' ORDER BY OCORR_HISTORICO DESC FETCH FIRST 1 ROWS ONLY END-EXEC */

            var r1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1 = new R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            var executed_1 = R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1.Execute(r1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
                _.Move(executed_1.HISCOBPR_QUANT_VIDAS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }


        }

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -2937- MOVE 'N' TO WACHOU-UNIC */
            _.Move("N", WACHOU_UNIC);

            /*" -2940- PERFORM R9200-00-PESQUISA-FORMULARIO */

            R9200_00_PESQUISA_FORMULARIO_SECTION();

            /*" -2942- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE-ANT */
            _.Move(REG_SVE0414B.SVA_NRAPOLICE, WS_NUM_APOLICE_ANT);

            /*" -2944- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT */
            _.Move(REG_SVE0414B.SVA_CODSUBES, WS_CODSUBES_ANT);

            /*" -2946- PERFORM R0300-00-OBTEM-NUMERACAO */

            R0300_00_OBTEM_NUMERACAO_SECTION();

            /*" -2948- MOVE 'VIDA EMPRESARIAL' TO LE00-PRODUTO LR03-TP-PGTO. */
            _.Move("VIDA EMPRESARIAL", AREA_DE_WORK.LE00_LINHA00.LE00_PRODUTO, AREA_DE_WORK.LR03_LINHA03.LR03_TP_PGTO);

            /*" -2950- MOVE LR03-TP-PGTO TO TIPO8-JDT. */
            _.Move(AREA_DE_WORK.LR03_LINHA03.LR03_TP_PGTO, LINHAS_AMARRADO.L8_JDT.TIPO8_JDT);

            /*" -2951- MOVE SPACES TO RVE0414B-RECORD. */
            _.Move("", RVE0414B_RECORD);

            /*" -2953- MOVE DET-JDE-VA46 TO REG-DADOS. */
            _.Move(AREA_DE_WORK.DET_JDE_VA46, RVE0414B_RECORD.REG_DADOS);

            /*" -2957- PERFORM R2010-00-PROCESSA-PRODUTO UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVE0414B.SVA_NRAPOLICE != WS_NUM_APOLICE_ANT || WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_SECTION();
            }

            /*" -2959- MOVE 'C' TO WS-CONTR-PRODU. */
            _.Move("C", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -2961- PERFORM R3000-00-IMPRIME-LST. */

            R3000_00_IMPRIME_LST_SECTION();

            /*" -2963- MOVE 'R' TO WS-CONTR-PRODU. */
            _.Move("R", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -2974- MOVE ZEROS TO TABELA-TOTAIS WS-AMARRADO WS-CONTR-AMAR WS-CONTR-OBJ WS-CONTR-200 WS-SEQ AC-QTD-OBJ AC-CONTA1 AC-PAGINA WS-OCORR. */
            _.Move(0, TABELA_TOTAIS, AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ, AREA_DE_WORK.WS_CONTR_200, AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.WS_OCORR);

            /*" -2975- MOVE SPACES TO LAISER-09 */
            _.Move("", TODAS_AS_LINHAS.LAISER_09);

            /*" -2978- MOVE FUNCTION LOWER-CASE(SVA-FORMULARIO) TO WS-FORM-LINHA */
            _.Move(REG_SVE0414B.SVA_FORMULARIO.ToString().ToLower(), AREA_DE_WORK.WS_FORM_LINHA);

            /*" -2999- STRING '(' WS-FORM-LINHA DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LAISER-09. */
            #region STRING
            var spl1 = "(" + AREA_DE_WORK.WS_FORM_LINHA.GetMoveValues().Split(" ").FirstOrDefault();
            spl1 += ".DBM".ToString().ToLower();
            spl1 += ") STARTDBM";
            spl1 += "(";
            var spl2 = AREA_DE_WORK.WS_FORM_LINHA.GetMoveValues();
            spl2 += ".DBM".ToString().ToLower();
            spl2 += ") STARTDBM";
            var results3 = spl1 + spl2;
            _.Move(results3, TODAS_AS_LINHAS.LAISER_09);
            #endregion

            /*" -3000- IF WFIM-SORT NOT = 'S' */

            if (WFIM_SORT != "S")
            {

                /*" -3001- WRITE RVE0414B-RECORD FROM LAISERFAC-FINAL */
                _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3002- WRITE RVE0414B-RECORD FROM LAISER-01 */
                _.Move(TODAS_AS_LINHAS.LAISER_01.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3003- WRITE RVE0414B-RECORD FROM FAC-04 */
                _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3004- WRITE RVE0414B-RECORD FROM LAISER-09 */
                _.Move(TODAS_AS_LINHAS.LAISER_09.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3005- WRITE RVE0414B-RECORD FROM VA46-HEADER */
                _.Move(TODAS_AS_LINHAS.VA46_HEADER.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3006- WRITE FVE0414B-RECORD FROM SEPARA-JDT */
                _.Move(LINHAS_AMARRADO.SEPARA_JDT.GetMoveValues(), FVE0414B_RECORD);

                FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3007- IF WACHOU-UNIC EQUAL 'S' */

                if (WACHOU_UNIC == "S")
                {

                    /*" -3008- IF RELATORI-TIPO-CORRECAO = 'I' */

                    if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "I")
                    {

                        /*" -3009- WRITE RVE0414I-RECORD FROM LAISERFAC-FINAL */
                        _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3010- WRITE RVE0414I-RECORD FROM LAISER-01 */
                        _.Move(TODAS_AS_LINHAS.LAISER_01.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3011- WRITE RVE0414I-RECORD FROM FAC-04 */
                        _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3012- WRITE RVE0414I-RECORD FROM LAISER-09 */
                        _.Move(TODAS_AS_LINHAS.LAISER_09.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3013- WRITE RVE0414I-RECORD FROM VA46-HEADER */
                        _.Move(TODAS_AS_LINHAS.VA46_HEADER.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3014- END-IF */
                    }


                    /*" -3015- IF RELATORI-TIPO-CORRECAO = 'P' */

                    if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "P")
                    {

                        /*" -3016- WRITE RVE0414P-RECORD FROM LAISERFAC-FINAL */
                        _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3017- WRITE RVE0414P-RECORD FROM LAISER-01 */
                        _.Move(TODAS_AS_LINHAS.LAISER_01.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3018- WRITE RVE0414P-RECORD FROM FAC-04 */
                        _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3019- WRITE RVE0414P-RECORD FROM LAISER-09 */
                        _.Move(TODAS_AS_LINHAS.LAISER_09.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3020- WRITE RVE0414P-RECORD FROM VA46-HEADER */
                        _.Move(TODAS_AS_LINHAS.VA46_HEADER.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3021- END-IF */
                    }


                    /*" -3022- IF RELATORI-NUM-APOL-LIDER NOT EQUAL SPACES */

                    if (!RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.IsEmpty())
                    {

                        /*" -3023- WRITE RVE0414H-RECORD FROM LAISERFAC-FINAL */
                        _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3024- WRITE RVE0414H-RECORD FROM LAISER-01 */
                        _.Move(TODAS_AS_LINHAS.LAISER_01.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3025- WRITE RVE0414H-RECORD FROM FAC-04 */
                        _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3026- WRITE RVE0414H-RECORD FROM LAISER-09 */
                        _.Move(TODAS_AS_LINHAS.LAISER_09.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3027- WRITE RVE0414H-RECORD FROM VA46-HEADER */
                        _.Move(TODAS_AS_LINHAS.VA46_HEADER.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3028- END-IF */
                    }


                    /*" -3029- END-IF */
                }


                /*" -3030- ELSE */
            }
            else
            {


                /*" -3031- WRITE RVE0414B-RECORD FROM LAISERFAC-FINAL */
                _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3032- IF WACHOU-UNIC EQUAL 'S' */

                if (WACHOU_UNIC == "S")
                {

                    /*" -3033- IF RELATORI-TIPO-CORRECAO = 'I' */

                    if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "I")
                    {

                        /*" -3034- WRITE RVE0414I-RECORD FROM LAISERFAC-FINAL */
                        _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3035- END-IF */
                    }


                    /*" -3036- IF RELATORI-TIPO-CORRECAO = 'P' */

                    if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "P")
                    {

                        /*" -3037- WRITE RVE0414P-RECORD FROM LAISERFAC-FINAL */
                        _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3038- END-IF */
                    }


                    /*" -3039- IF RELATORI-NUM-APOL-LIDER NOT EQUAL SPACES */

                    if (!RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.IsEmpty())
                    {

                        /*" -3040- WRITE RVE0414H-RECORD FROM LAISERFAC-FINAL */
                        _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3041- END-IF */
                    }


                    /*" -3042- END-IF */
                }


                /*" -3042- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -3052- MOVE SVA-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SVE0414B.SVA_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -3053- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SVE0414B.SVA_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -3056- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -3057- MOVE TAB-FX-INI(SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVE0414B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_INI, WS_NUM_CEP_AUX);

            /*" -3058- MOVE WS-CEP-AUX TO LF03-FAIXA1. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF03_LINHA03.FAIXA_INT.LF03_FAIXA1);

            /*" -3059- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA1C. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF03_LINHA03.FAIXA_INT.LF03_FAIXA1C);

            /*" -3060- MOVE TAB-FX-FIM(SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVE0414B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_FIM, WS_NUM_CEP_AUX);

            /*" -3061- MOVE WS-CEP-AUX TO LF03-FAIXA2. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF03_LINHA03.FAIXA_INT.LF03_FAIXA2);

            /*" -3062- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA2C. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF03_LINHA03.FAIXA_INT.LF03_FAIXA2C);

            /*" -3064- MOVE FAIXA-INT TO CO04-DET-FAIXA. */
            _.Move(AREA_DE_WORK.LF03_LINHA03.FAIXA_INT, TODAS_AS_LINHAS.FAC_DETALHE.CO04_DET_FAIXA);

            /*" -3069- PERFORM R2100-00-PROCESSA-CEP UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVE0414B.SVA_NRAPOLICE != WS_NUM_APOLICE_ANT || REG_SVE0414B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

            /*" -3070- MOVE WS-AMARRADO TO TAB1-AMARF(WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARF);

            /*" -3070- MOVE WS-SEQ TO TAB1-OBJF (WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_OBJF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -3082- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -3088- PERFORM R2200-00-PROCESSA-FAC UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 > 199. */

            while (!(REG_SVE0414B.SVA_NRAPOLICE != WS_NUM_APOLICE_ANT || REG_SVE0414B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

            /*" -3090- ADD 1 TO WS-AMARRADO TAB1-QTD-AMAR(WS-CEP-G-ANT). */
            AREA_DE_WORK.WS_AMARRADO.Value = AREA_DE_WORK.WS_AMARRADO + 1;
            TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR.Value = TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR + 1;

            /*" -3091- IF WS-CONTR-AMAR EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_AMAR == 00)
            {

                /*" -3092- MOVE 1 TO WS-CONTR-AMAR */
                _.Move(1, AREA_DE_WORK.WS_CONTR_AMAR);

                /*" -3095- MOVE WS-AMARRADO TO TAB1-AMARI(WS-CEP-G-ANT). */
                _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARI);
            }


            /*" -3096- MOVE WS-AMARRADO TO LF05-AMARRADO */
            _.Move(AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.LF05_LINHA05.LF05_AMARRADO);

            /*" -3097- MOVE LF05-AMARRADO TO CO04-DET-AMARRADO */
            _.Move(AREA_DE_WORK.LF05_LINHA05.LF05_AMARRADO, TODAS_AS_LINHAS.FAC_DETALHE.CO04_DET_AMARRADO);

            /*" -3098- MOVE AC-QTD-OBJ TO LF04-QTD-OBJ */
            _.Move(AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ);

            /*" -3099- MOVE LF04-QTD-OBJ TO CO04-DET-OBJETOS */
            _.Move(AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ, TODAS_AS_LINHAS.FAC_DETALHE.CO04_DET_OBJETOS);

            /*" -3100- MOVE WS-SEQ-INICIAL TO LF05-SEQ-INICIAL. */
            _.Move(AREA_DE_WORK.WS_SEQ_INICIAL, AREA_DE_WORK.LF05_LINHA05.SE_INT.LF05_SEQ_INICIAL);

            /*" -3101- MOVE WS-SEQ TO LF05-SEQ-FINAL. */
            _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.LF05_LINHA05.SE_INT.LF05_SEQ_FINAL);

            /*" -3103- MOVE SE-INT TO CO04-DET-SEQUENCIA. */
            _.Move(AREA_DE_WORK.LF05_LINHA05.SE_INT, TODAS_AS_LINHAS.FAC_DETALHE.CO04_DET_SEQUENCIA);

            /*" -3104- IF AC-CONTA1 GREATER 199 */

            if (AREA_DE_WORK.AC_CONTA1 > 199)
            {

                /*" -3107- MOVE TAB-FX-NOME (WS-CEP-G-ANT) TO LF02-NOME-FAIXA CO04-DET-LOCALIDADE */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_NOME, AREA_DE_WORK.LF02_LINHA02.LF02_NOME_FAIXA, TODAS_AS_LINHAS.FAC_DETALHE.CO04_DET_LOCALIDADE);

                /*" -3108- ELSE */
            }
            else
            {


                /*" -3112- MOVE TAB-FX-CENTR(WS-CEP-G-ANT) TO LF02-NOME-FAIXA CO04-DET-LOCALIDADE. */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_CENTR, AREA_DE_WORK.LF02_LINHA02.LF02_NOME_FAIXA, TODAS_AS_LINHAS.FAC_DETALHE.CO04_DET_LOCALIDADE);
            }


            /*" -3113- WRITE RVE0414B-RECORD FROM LAISERFAC-FINAL. */
            _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -3114- WRITE RVE0414B-RECORD FROM FAC-01. */
            _.Move(TODAS_AS_LINHAS.FAC_01.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -3115- WRITE RVE0414B-RECORD FROM FAC-02. */
            _.Move(TODAS_AS_LINHAS.FAC_02.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -3116- WRITE RVE0414B-RECORD FROM FAC-04. */
            _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -3117- WRITE RVE0414B-RECORD FROM FAC-05 */
            _.Move(TODAS_AS_LINHAS.FAC_05.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -3118- WRITE RVE0414B-RECORD FROM FAC-HEADER. */
            _.Move(TODAS_AS_LINHAS.FAC_HEADER.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -3119- WRITE RVE0414B-RECORD FROM FAC-DETALHE. */
            _.Move(TODAS_AS_LINHAS.FAC_DETALHE.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -3120- IF WACHOU-UNIC EQUAL 'S' */

            if (WACHOU_UNIC == "S")
            {

                /*" -3121- IF RELATORI-TIPO-CORRECAO = 'I' */

                if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "I")
                {

                    /*" -3122- WRITE RVE0414I-RECORD FROM LAISERFAC-FINAL */
                    _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414I_RECORD);

                    RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                    /*" -3123- WRITE RVE0414I-RECORD FROM FAC-01 */
                    _.Move(TODAS_AS_LINHAS.FAC_01.GetMoveValues(), RVE0414I_RECORD);

                    RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                    /*" -3124- WRITE RVE0414I-RECORD FROM FAC-02 */
                    _.Move(TODAS_AS_LINHAS.FAC_02.GetMoveValues(), RVE0414I_RECORD);

                    RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                    /*" -3125- WRITE RVE0414I-RECORD FROM FAC-04 */
                    _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414I_RECORD);

                    RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                    /*" -3126- WRITE RVE0414I-RECORD FROM FAC-05 */
                    _.Move(TODAS_AS_LINHAS.FAC_05.GetMoveValues(), RVE0414I_RECORD);

                    RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                    /*" -3127- WRITE RVE0414I-RECORD FROM FAC-HEADER */
                    _.Move(TODAS_AS_LINHAS.FAC_HEADER.GetMoveValues(), RVE0414I_RECORD);

                    RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                    /*" -3128- WRITE RVE0414I-RECORD FROM FAC-DETALHE */
                    _.Move(TODAS_AS_LINHAS.FAC_DETALHE.GetMoveValues(), RVE0414I_RECORD);

                    RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                    /*" -3129- END-IF */
                }


                /*" -3130- IF RELATORI-TIPO-CORRECAO = 'P' */

                if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "P")
                {

                    /*" -3131- WRITE RVE0414P-RECORD FROM LAISERFAC-FINAL */
                    _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414P_RECORD);

                    RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                    /*" -3132- WRITE RVE0414P-RECORD FROM FAC-01 */
                    _.Move(TODAS_AS_LINHAS.FAC_01.GetMoveValues(), RVE0414P_RECORD);

                    RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                    /*" -3133- WRITE RVE0414P-RECORD FROM FAC-02 */
                    _.Move(TODAS_AS_LINHAS.FAC_02.GetMoveValues(), RVE0414P_RECORD);

                    RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                    /*" -3134- WRITE RVE0414P-RECORD FROM FAC-04 */
                    _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414P_RECORD);

                    RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                    /*" -3135- WRITE RVE0414P-RECORD FROM FAC-05 */
                    _.Move(TODAS_AS_LINHAS.FAC_05.GetMoveValues(), RVE0414P_RECORD);

                    RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                    /*" -3136- WRITE RVE0414P-RECORD FROM FAC-HEADER */
                    _.Move(TODAS_AS_LINHAS.FAC_HEADER.GetMoveValues(), RVE0414P_RECORD);

                    RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                    /*" -3137- WRITE RVE0414P-RECORD FROM FAC-DETALHE */
                    _.Move(TODAS_AS_LINHAS.FAC_DETALHE.GetMoveValues(), RVE0414P_RECORD);

                    RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                    /*" -3138- END-IF */
                }


                /*" -3139- IF RELATORI-NUM-APOL-LIDER NOT EQUAL SPACES */

                if (!RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.IsEmpty())
                {

                    /*" -3140- WRITE RVE0414H-RECORD FROM LAISERFAC-FINAL */
                    _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414H_RECORD);

                    RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                    /*" -3141- WRITE RVE0414H-RECORD FROM FAC-01 */
                    _.Move(TODAS_AS_LINHAS.FAC_01.GetMoveValues(), RVE0414H_RECORD);

                    RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                    /*" -3142- WRITE RVE0414H-RECORD FROM FAC-02 */
                    _.Move(TODAS_AS_LINHAS.FAC_02.GetMoveValues(), RVE0414H_RECORD);

                    RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                    /*" -3143- WRITE RVE0414H-RECORD FROM FAC-04 */
                    _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414H_RECORD);

                    RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                    /*" -3144- WRITE RVE0414H-RECORD FROM FAC-05 */
                    _.Move(TODAS_AS_LINHAS.FAC_05.GetMoveValues(), RVE0414H_RECORD);

                    RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                    /*" -3145- WRITE RVE0414H-RECORD FROM FAC-HEADER */
                    _.Move(TODAS_AS_LINHAS.FAC_HEADER.GetMoveValues(), RVE0414H_RECORD);

                    RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                    /*" -3146- WRITE RVE0414H-RECORD FROM FAC-DETALHE */
                    _.Move(TODAS_AS_LINHAS.FAC_DETALHE.GetMoveValues(), RVE0414H_RECORD);

                    RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                    /*" -3147- END-IF */
                }


                /*" -3148- END-IF */
            }


            /*" -3150- PERFORM R9100-00-LIMPA-DET-FAC. */

            R9100_00_LIMPA_DET_FAC_SECTION();

            /*" -3152- IF WFIM-SORT NOT = 'S' AND SVA-NRAPOLICE = WS-NUM-APOLICE-ANT */

            if (WFIM_SORT != "S" && REG_SVE0414B.SVA_NRAPOLICE == WS_NUM_APOLICE_ANT)
            {

                /*" -3153- MOVE SPACES TO LAISER-09 */
                _.Move("", TODAS_AS_LINHAS.LAISER_09);

                /*" -3155- MOVE FUNCTION LOWER-CASE(SVA-FORMULARIO) TO WS-FORM-LINHA */
                _.Move(REG_SVE0414B.SVA_FORMULARIO.ToString().ToLower(), AREA_DE_WORK.WS_FORM_LINHA);

                /*" -3174- STRING '(' WS-FORM-LINHA DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LAISER-09 */
                #region STRING
                var spl3 = "(" + AREA_DE_WORK.WS_FORM_LINHA.GetMoveValues().Split(" ").FirstOrDefault();
                spl3 += ".DBM".ToString().ToLower();
                spl3 += ") STARTDBM";
                spl3 += "(";
                var spl4 = AREA_DE_WORK.WS_FORM_LINHA.GetMoveValues();
                spl4 += ".DBM".ToString().ToLower();
                spl4 += ") STARTDBM";
                var results5 = spl3 + spl4;
                _.Move(results5, TODAS_AS_LINHAS.LAISER_09);
                #endregion

                /*" -3175- WRITE RVE0414B-RECORD FROM LAISERFAC-FINAL */
                _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3176- WRITE RVE0414B-RECORD FROM LAISER-01 */
                _.Move(TODAS_AS_LINHAS.LAISER_01.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3177- WRITE RVE0414B-RECORD FROM FAC-04 */
                _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3178- WRITE RVE0414B-RECORD FROM LAISER-09 */
                _.Move(TODAS_AS_LINHAS.LAISER_09.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3179- WRITE RVE0414B-RECORD FROM VA46-HEADER */
                _.Move(TODAS_AS_LINHAS.VA46_HEADER.GetMoveValues(), RVE0414B_RECORD);

                RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

                /*" -3180- IF WACHOU-UNIC EQUAL 'S' */

                if (WACHOU_UNIC == "S")
                {

                    /*" -3181- IF RELATORI-TIPO-CORRECAO = 'I' */

                    if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "I")
                    {

                        /*" -3182- WRITE RVE0414I-RECORD FROM LAISERFAC-FINAL */
                        _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3183- WRITE RVE0414I-RECORD FROM LAISER-01 */
                        _.Move(TODAS_AS_LINHAS.LAISER_01.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3184- WRITE RVE0414I-RECORD FROM FAC-04 */
                        _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3185- WRITE RVE0414I-RECORD FROM LAISER-09 */
                        _.Move(TODAS_AS_LINHAS.LAISER_09.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3186- WRITE RVE0414I-RECORD FROM VA46-HEADER */
                        _.Move(TODAS_AS_LINHAS.VA46_HEADER.GetMoveValues(), RVE0414I_RECORD);

                        RVE0414I.Write(RVE0414I_RECORD.GetMoveValues().ToString());

                        /*" -3187- END-IF */
                    }


                    /*" -3188- IF RELATORI-TIPO-CORRECAO = 'P' */

                    if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "P")
                    {

                        /*" -3189- WRITE RVE0414P-RECORD FROM LAISERFAC-FINAL */
                        _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3190- WRITE RVE0414P-RECORD FROM LAISER-01 */
                        _.Move(TODAS_AS_LINHAS.LAISER_01.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3191- WRITE RVE0414P-RECORD FROM FAC-04 */
                        _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3192- WRITE RVE0414P-RECORD FROM LAISER-09 */
                        _.Move(TODAS_AS_LINHAS.LAISER_09.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3193- WRITE RVE0414P-RECORD FROM VA46-HEADER */
                        _.Move(TODAS_AS_LINHAS.VA46_HEADER.GetMoveValues(), RVE0414P_RECORD);

                        RVE0414P.Write(RVE0414P_RECORD.GetMoveValues().ToString());

                        /*" -3194- END-IF */
                    }


                    /*" -3195- IF RELATORI-NUM-APOL-LIDER NOT EQUAL SPACES */

                    if (!RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.IsEmpty())
                    {

                        /*" -3196- WRITE RVE0414H-RECORD FROM LAISERFAC-FINAL */
                        _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3197- WRITE RVE0414H-RECORD FROM LAISER-01 */
                        _.Move(TODAS_AS_LINHAS.LAISER_01.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3198- WRITE RVE0414H-RECORD FROM FAC-04 */
                        _.Move(TODAS_AS_LINHAS.FAC_04.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3199- WRITE RVE0414H-RECORD FROM LAISER-09 */
                        _.Move(TODAS_AS_LINHAS.LAISER_09.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3200- WRITE RVE0414H-RECORD FROM VA46-HEADER */
                        _.Move(TODAS_AS_LINHAS.VA46_HEADER.GetMoveValues(), RVE0414H_RECORD);

                        RVE0414H.Write(RVE0414H_RECORD.GetMoveValues().ToString());

                        /*" -3201- END-IF */
                    }


                    /*" -3202- END-IF */
                }


                /*" -3203- END-IF */
            }


            /*" -3205- MOVE ZEROS TO AC-QTD-OBJ. */
            _.Move(0, AREA_DE_WORK.AC_QTD_OBJ);

            /*" -3206- IF WFIM-SORT NOT EQUAL 'S' */

            if (WFIM_SORT != "S")
            {

                /*" -3210- MOVE SPACES TO RVE0414B-RECORD RVE0414I-RECORD RVE0414P-RECORD RVE0414H-RECORD */
                _.Move("", RVE0414B_RECORD, RVE0414I_RECORD, RVE0414P_RECORD, RVE0414H_RECORD);

                /*" -3213- MOVE DET-JDE-VA46 TO REG-DADOS REG-DADOS-I REG-DADOS-P REG-DADOS-H. */
                _.Move(AREA_DE_WORK.DET_JDE_VA46, RVE0414B_RECORD.REG_DADOS, RVE0414I_RECORD.REG_DADOS_I, RVE0414P_RECORD.REG_DADOS_P, RVE0414H_RECORD.REG_DADOS_H);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -3223- MOVE 1 TO IDX2 IDX3 */
            _.Move(1, AREA_DE_WORK.IDX2, AREA_DE_WORK.IDX3);

            /*" -3224- PERFORM R2250-00-LIMPA-TABELA */

            R2250_00_LIMPA_TABELA_SECTION();

            /*" -3225- PERFORM R2300-00-MONTA-LINHAS */

            R2300_00_MONTA_LINHAS_SECTION();

            /*" -3226- PERFORM R2500-00-IMPRIME-CERTIFICADO */

            R2500_00_IMPRIME_CERTIFICADO_SECTION();

            /*" -3232- PERFORM R2600-00-IMPRIME-ENDERECO */

            R2600_00_IMPRIME_ENDERECO_SECTION();

            /*" -3233- ADD 1 TO AC-IMPRESSOS */
            AC_IMPRESSOS.Value = AC_IMPRESSOS + 1;

            /*" -3235- PERFORM R5000-00-ATU-RELATORIOS */

            R5000_00_ATU_RELATORIOS_SECTION();

            /*" -3235- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-LIMPA-TABELA-SECTION */
        private void R2250_00_LIMPA_TABELA_SECTION()
        {
            /*" -3246- MOVE SPACES TO VA46-DETALHE. */
            _.Move("", TODAS_AS_LINHAS.VA46_DETALHE);

            /*" -3274- MOVE ZEROS TO TB-NUM-TERMO (IDX2) TB-SUBGRUPO (IDX2) TB-DIA-ADESAO (IDX2) TB-MES-ADESAO (IDX2) TB-ANO-ADESAO (IDX2) TB-DIA-EMISSAO (IDX2) TB-MES-EMISSAO (IDX2) TB-ANO-EMISSAO (IDX2) TB-CGC (IDX2) TB-COD-AGENCIA (IDX2) TB-OCOREND (IDX2) TB-PLANO-AP (IDX2) TB-CAPITAL (IDX2) TB-CUSTO (IDX2) TB-VIDAS (IDX2) TB-CEP (IDX2) TB-CEP-COMPL (IDX2) TB-FONTE (IDX2) TB-NUM-PROPOSTA-SIVPF (IDX2) TB-DTH-DIA-DEBITO (IDX2) TB-COD-AGENCIA-DEB (IDX2) TB-OPERACAO-CONTA-DEB (IDX2) TB-NUM-CONTA-DEBITO (IDX2) TB-DIG-CONTA-DEBITO (IDX2) TB-NUM-CARTAO-CREDITO (IDX2) TB-CODPRODU (IDX2). */
            _.Move(0, MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_TERMO, MONTAGEM[AREA_DE_WORK.IDX2].TB_SUBGRUPO, MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_ADESAO.TB_DIA_ADESAO, MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_ADESAO.TB_MES_ADESAO, MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_ADESAO.TB_ANO_ADESAO, MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_EMISSAO.TB_DIA_EMISSAO, MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_EMISSAO.TB_MES_EMISSAO, MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_EMISSAO.TB_ANO_EMISSAO, MONTAGEM[AREA_DE_WORK.IDX2].TB_CGC, MONTAGEM[AREA_DE_WORK.IDX2].TB_COD_AGENCIA, MONTAGEM[AREA_DE_WORK.IDX2].TB_OCOREND, MONTAGEM[AREA_DE_WORK.IDX2].TB_PLANO_AP, MONTAGEM[AREA_DE_WORK.IDX2].TB_CAPITAL, MONTAGEM[AREA_DE_WORK.IDX2].TB_CUSTO, MONTAGEM[AREA_DE_WORK.IDX2].TB_VIDAS, MONTAGEM[AREA_DE_WORK.IDX2].FILLER_156.TB_CEP, MONTAGEM[AREA_DE_WORK.IDX2].FILLER_156.TB_CEP_COMPL, MONTAGEM[AREA_DE_WORK.IDX2].TB_FONTE, MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_PROPOSTA_SIVPF, MONTAGEM[AREA_DE_WORK.IDX2].TB_DTH_DIA_DEBITO, MONTAGEM[AREA_DE_WORK.IDX2].TB_COD_AGENCIA_DEB, MONTAGEM[AREA_DE_WORK.IDX2].TB_OPERACAO_CONTA_DEB, MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_CONTA_DEBITO, MONTAGEM[AREA_DE_WORK.IDX2].TB_DIG_CONTA_DEBITO, MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_CARTAO_CREDITO, MONTAGEM[AREA_DE_WORK.IDX2].TB_CODPRODU);

            /*" -3291- MOVE SPACES TO TB-NUM-APOLICE (IDX2) TB-NOME-EMPRESA (IDX2) TB-NOME-AGENCIA (IDX2) TB-MODALIDADE (IDX2) TB-PAGAMENTO (IDX2) TB-TIPO-COBERTURA (IDX2) TB-PLANO (IDX2) TB-MSG1 (IDX2) TB-MSG2 (IDX2) TB-MSG3 (IDX2) TB-MSG4 (IDX2) TB-EMPR-ENDER (IDX2) TB-ENDERECO (IDX2) TB-BAIRRO (IDX2) TB-CIDADE (IDX2) TB-UF (IDX2) TB-DATADIA (IDX2). */
            _.Move("", MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_APOLICE, MONTAGEM[AREA_DE_WORK.IDX2].TB_NOME_EMPRESA, MONTAGEM[AREA_DE_WORK.IDX2].TB_NOME_AGENCIA, MONTAGEM[AREA_DE_WORK.IDX2].TB_MODALIDADE, MONTAGEM[AREA_DE_WORK.IDX2].TB_PAGAMENTO, MONTAGEM[AREA_DE_WORK.IDX2].TB_TIPO_COBERTURA, MONTAGEM[AREA_DE_WORK.IDX2].TB_PLANO, MONTAGEM[AREA_DE_WORK.IDX2].TB_MSG1, MONTAGEM[AREA_DE_WORK.IDX2].TB_MSG2, MONTAGEM[AREA_DE_WORK.IDX2].TB_MSG3, MONTAGEM[AREA_DE_WORK.IDX2].TB_MSG4, MONTAGEM[AREA_DE_WORK.IDX2].TB_EMPR_ENDER, MONTAGEM[AREA_DE_WORK.IDX2].TB_ENDERECO, MONTAGEM[AREA_DE_WORK.IDX2].TB_BAIRRO, MONTAGEM[AREA_DE_WORK.IDX2].TB_CIDADE, MONTAGEM[AREA_DE_WORK.IDX2].TB_UF, MONTAGEM[AREA_DE_WORK.IDX2].TB_DATADIA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_SAIDA*/

        [StopWatch]
        /*" R2300-00-MONTA-LINHAS-SECTION */
        private void R2300_00_MONTA_LINHAS_SECTION()
        {
            /*" -3302- PERFORM R2301-00-SELECT-V0CLIENTE. */

            R2301_00_SELECT_V0CLIENTE_SECTION();

            /*" -3303- MOVE SVA-NUM-TERMO TO TB-NUM-TERMO(IDX3) */
            _.Move(REG_SVE0414B.SVA_NUM_TERMO, MONTAGEM[AREA_DE_WORK.IDX3].TB_NUM_TERMO);

            /*" -3304- MOVE SVA-CODSUBES TO TB-SUBGRUPO(IDX3) */
            _.Move(REG_SVE0414B.SVA_CODSUBES, MONTAGEM[AREA_DE_WORK.IDX3].TB_SUBGRUPO);

            /*" -3305- MOVE SVA-DATA-ADESAO TO WS-DATA */
            _.Move(REG_SVE0414B.SVA_DATA_ADESAO, WS_DATA);

            /*" -3306- MOVE WS-DIA TO TB-DIA-ADESAO(IDX3) */
            _.Move(WS_DATA.WS_DIA, MONTAGEM[AREA_DE_WORK.IDX3].TB_DATA_ADESAO.TB_DIA_ADESAO);

            /*" -3307- MOVE WS-MES TO TB-MES-ADESAO(IDX3) */
            _.Move(WS_DATA.WS_MES, MONTAGEM[AREA_DE_WORK.IDX3].TB_DATA_ADESAO.TB_MES_ADESAO);

            /*" -3308- MOVE WS-ANO TO TB-ANO-ADESAO(IDX3) */
            _.Move(WS_DATA.WS_ANO, MONTAGEM[AREA_DE_WORK.IDX3].TB_DATA_ADESAO.TB_ANO_ADESAO);

            /*" -3310- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO WS-DATA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_DATA);

            /*" -3311- MOVE WS-DIA TO TB-DIA-EMISSAO(IDX3) */
            _.Move(WS_DATA.WS_DIA, MONTAGEM[AREA_DE_WORK.IDX3].TB_DATA_EMISSAO.TB_DIA_EMISSAO);

            /*" -3312- MOVE WS-MES TO TB-MES-EMISSAO(IDX3) */
            _.Move(WS_DATA.WS_MES, MONTAGEM[AREA_DE_WORK.IDX3].TB_DATA_EMISSAO.TB_MES_EMISSAO);

            /*" -3313- MOVE WS-ANO TO TB-ANO-EMISSAO(IDX3) */
            _.Move(WS_DATA.WS_ANO, MONTAGEM[AREA_DE_WORK.IDX3].TB_DATA_EMISSAO.TB_ANO_EMISSAO);

            /*" -3315- MOVE SVA-NRAPOLICE TO TB-NUM-APOLICE(IDX3) */
            _.Move(REG_SVE0414B.SVA_NRAPOLICE, MONTAGEM[AREA_DE_WORK.IDX3].TB_NUM_APOLICE);

            /*" -3318- MOVE CLIENTES-NOME-RAZAO OF DCLCLIENTES TO TB-NOME-EMPRESA(IDX3) */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, MONTAGEM[AREA_DE_WORK.IDX3].TB_NOME_EMPRESA);

            /*" -3321- MOVE CLIENTES-CGCCPF OF DCLCLIENTES TO TB-CGC(IDX3) */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, MONTAGEM[AREA_DE_WORK.IDX3].TB_CGC);

            /*" -3322- MOVE SVA-COD-AGENCIA-OP TO TB-COD-AGENCIA(IDX3) */
            _.Move(REG_SVE0414B.SVA_COD_AGENCIA_OP, MONTAGEM[AREA_DE_WORK.IDX3].TB_COD_AGENCIA);

            /*" -3324- MOVE SVA-NOME-AGENCIA TO TB-NOME-AGENCIA(IDX3) */
            _.Move(REG_SVE0414B.SVA_NOME_AGENCIA, MONTAGEM[AREA_DE_WORK.IDX3].TB_NOME_AGENCIA);

            /*" -3325- IF SVA-MODALIDADE-CAPITAL EQUAL '0' */

            if (REG_SVE0414B.SVA_MODALIDADE_CAPITAL == "0")
            {

                /*" -3327- MOVE 'CONTRATADO' TO TB-MODALIDADE(IDX3). */
                _.Move("CONTRATADO", MONTAGEM[AREA_DE_WORK.IDX3].TB_MODALIDADE);
            }


            /*" -3328- IF SVA-MODALIDADE-CAPITAL EQUAL '1' */

            if (REG_SVE0414B.SVA_MODALIDADE_CAPITAL == "1")
            {

                /*" -3330- MOVE 'OPCIONAL  ' TO TB-MODALIDADE(IDX3). */
                _.Move("OPCIONAL  ", MONTAGEM[AREA_DE_WORK.IDX3].TB_MODALIDADE);
            }


            /*" -3331- IF SVA-MODALIDADE-CAPITAL EQUAL '2' */

            if (REG_SVE0414B.SVA_MODALIDADE_CAPITAL == "2")
            {

                /*" -3333- MOVE 'UNICO     ' TO TB-MODALIDADE(IDX3). */
                _.Move("UNICO     ", MONTAGEM[AREA_DE_WORK.IDX3].TB_MODALIDADE);
            }


            /*" -3334- IF SVA-MODALIDADE-CAPITAL EQUAL '3' */

            if (REG_SVE0414B.SVA_MODALIDADE_CAPITAL == "3")
            {

                /*" -3336- MOVE 'DIFERENCIADO' TO TB-MODALIDADE(IDX3). */
                _.Move("DIFERENCIADO", MONTAGEM[AREA_DE_WORK.IDX3].TB_MODALIDADE);
            }


            /*" -3337- IF SVA-PERI-PAGAMENTO EQUAL 01 */

            if (REG_SVE0414B.SVA_PERI_PAGAMENTO == 01)
            {

                /*" -3338- MOVE 'MENSAL' TO TB-PAGAMENTO(IDX3) */
                _.Move("MENSAL", MONTAGEM[AREA_DE_WORK.IDX3].TB_PAGAMENTO);

                /*" -3339- ELSE */
            }
            else
            {


                /*" -3340- IF SVA-PERI-PAGAMENTO EQUAL 02 */

                if (REG_SVE0414B.SVA_PERI_PAGAMENTO == 02)
                {

                    /*" -3341- MOVE 'BIMESTRAL' TO TB-PAGAMENTO(IDX3) */
                    _.Move("BIMESTRAL", MONTAGEM[AREA_DE_WORK.IDX3].TB_PAGAMENTO);

                    /*" -3342- ELSE */
                }
                else
                {


                    /*" -3343- IF SVA-PERI-PAGAMENTO EQUAL 03 */

                    if (REG_SVE0414B.SVA_PERI_PAGAMENTO == 03)
                    {

                        /*" -3344- MOVE 'TRIMESTRAL' TO TB-PAGAMENTO(IDX3) */
                        _.Move("TRIMESTRAL", MONTAGEM[AREA_DE_WORK.IDX3].TB_PAGAMENTO);

                        /*" -3345- ELSE */
                    }
                    else
                    {


                        /*" -3346- IF SVA-PERI-PAGAMENTO EQUAL 06 */

                        if (REG_SVE0414B.SVA_PERI_PAGAMENTO == 06)
                        {

                            /*" -3347- MOVE 'SEMESTRAL ' TO TB-PAGAMENTO(IDX3) */
                            _.Move("SEMESTRAL ", MONTAGEM[AREA_DE_WORK.IDX3].TB_PAGAMENTO);

                            /*" -3348- ELSE */
                        }
                        else
                        {


                            /*" -3349- IF SVA-PERI-PAGAMENTO EQUAL 12 */

                            if (REG_SVE0414B.SVA_PERI_PAGAMENTO == 12)
                            {

                                /*" -3350- MOVE 'ANUAL     ' TO TB-PAGAMENTO(IDX3) */
                                _.Move("ANUAL     ", MONTAGEM[AREA_DE_WORK.IDX3].TB_PAGAMENTO);

                                /*" -3351- ELSE */
                            }
                            else
                            {


                                /*" -3353- MOVE '          ' TO TB-PAGAMENTO(IDX3). */
                                _.Move("          ", MONTAGEM[AREA_DE_WORK.IDX3].TB_PAGAMENTO);
                            }

                        }

                    }

                }

            }


            /*" -3354- MOVE SVA-OCOREND TO TB-OCOREND(IDX3) */
            _.Move(REG_SVE0414B.SVA_OCOREND, MONTAGEM[AREA_DE_WORK.IDX3].TB_OCOREND);

            /*" -3355- MOVE SVA-COD-PLANO-APC TO TB-PLANO-AP(IDX3) */
            _.Move(REG_SVE0414B.SVA_COD_PLANO_APC, MONTAGEM[AREA_DE_WORK.IDX3].TB_PLANO_AP);

            /*" -3356- MOVE SVA-VAL-CONTRATADO TO TB-CAPITAL(IDX3) */
            _.Move(REG_SVE0414B.SVA_VAL_CONTRATADO, MONTAGEM[AREA_DE_WORK.IDX3].TB_CAPITAL);

            /*" -3357- MOVE SVA-VAL-PREMIO TO TB-CUSTO(IDX3) */
            _.Move(REG_SVE0414B.SVA_VAL_PREMIO, MONTAGEM[AREA_DE_WORK.IDX3].TB_CUSTO);

            /*" -3359- MOVE SVA-QUANT-VIDAS TO TB-VIDAS(IDX3) */
            _.Move(REG_SVE0414B.SVA_QUANT_VIDAS, MONTAGEM[AREA_DE_WORK.IDX3].TB_VIDAS);

            /*" -3360- IF SVA-TIPO-COBERTURA EQUAL '1' */

            if (REG_SVE0414B.SVA_TIPO_COBERTURA == "1")
            {

                /*" -3361- MOVE BASICA-VGAPC TO TB-MSG1(IDX3) */
                _.Move(AREA_DE_WORK.BASICA_VGAPC, MONTAGEM[AREA_DE_WORK.IDX3].TB_MSG1);

                /*" -3362- ELSE */
            }
            else
            {


                /*" -3363- IF SVA-TIPO-COBERTURA EQUAL '2' */

                if (REG_SVE0414B.SVA_TIPO_COBERTURA == "2")
                {

                    /*" -3364- MOVE BASICA-VG TO TB-MSG1(IDX3) */
                    _.Move(AREA_DE_WORK.BASICA_VG, MONTAGEM[AREA_DE_WORK.IDX3].TB_MSG1);

                    /*" -3365- ELSE */
                }
                else
                {


                    /*" -3367- MOVE BASICA-APC TO TB-MSG1(IDX3). */
                    _.Move(AREA_DE_WORK.BASICA_APC, MONTAGEM[AREA_DE_WORK.IDX3].TB_MSG1);
                }

            }


            /*" -3368- MOVE ZEROS TO IDX4. */
            _.Move(0, AREA_DE_WORK.IDX4);

            /*" -3370- PERFORM R2305-00-SELECT-V0CONDTEC. */

            R2305_00_SELECT_V0CONDTEC_SECTION();

            /*" -3373- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -3375- MOVE 'N' TO WFIM-ADICIONAIS. */
            _.Move("N", WFIM_ADICIONAIS);

            /*" -3377- MOVE SVA-NUM-PROPOSTA-SIVPF TO VGCOBTER-NUM-PROPOSTA-SIVPF. */
            _.Move(REG_SVE0414B.SVA_NUM_PROPOSTA_SIVPF, VGCOBTER.DCLVG_COBER_TERMO.VGCOBTER_NUM_PROPOSTA_SIVPF);

            /*" -3401- PERFORM R2300_00_MONTA_LINHAS_DB_DECLARE_1 */

            R2300_00_MONTA_LINHAS_DB_DECLARE_1();

            /*" -3404- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3405- DISPLAY 'R2300 - PROBLEMAS DECLARE CURSOR CADIC' */
                _.Display($"R2300 - PROBLEMAS DECLARE CURSOR CADIC");

                /*" -3406- DISPLAY 'CERTIFICADO: ' SVA-NUM-PROPOSTA-SIVPF */
                _.Display($"CERTIFICADO: {REG_SVE0414B.SVA_NUM_PROPOSTA_SIVPF}");

                /*" -3408- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3411- MOVE '230A' TO WNR-EXEC-SQL. */
            _.Move("230A", WABEND.WNR_EXEC_SQL);

            /*" -3411- PERFORM R2300_00_MONTA_LINHAS_DB_OPEN_1 */

            R2300_00_MONTA_LINHAS_DB_OPEN_1();

            /*" -3414- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3415- DISPLAY 'R2300 - PROBLEMAS OPEN CURSOR CADIC   ' */
                _.Display($"R2300 - PROBLEMAS OPEN CURSOR CADIC   ");

                /*" -3416- DISPLAY 'NUM-PROPOSTA ' VGCOBTER-NUM-PROPOSTA-SIVPF */
                _.Display($"NUM-PROPOSTA {VGCOBTER.DCLVG_COBER_TERMO.VGCOBTER_NUM_PROPOSTA_SIVPF}");

                /*" -3417- DISPLAY 'SQLCODE     ' SQLCODE */
                _.Display($"SQLCODE     {DB.SQLCODE}");

                /*" -3419- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3422- MOVE '230B' TO WNR-EXEC-SQL. */
            _.Move("230B", WABEND.WNR_EXEC_SQL);

            /*" -3426- PERFORM R2300_00_MONTA_LINHAS_DB_FETCH_1 */

            R2300_00_MONTA_LINHAS_DB_FETCH_1();

            /*" -3429- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3430- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3431- MOVE 'S' TO WFIM-ADICIONAIS */
                    _.Move("S", WFIM_ADICIONAIS);

                    /*" -3431- PERFORM R2300_00_MONTA_LINHAS_DB_CLOSE_1 */

                    R2300_00_MONTA_LINHAS_DB_CLOSE_1();

                    /*" -3433- ELSE */
                }
                else
                {


                    /*" -3434- DISPLAY 'R2300 - PROBLEMAS  FETCH  CADIC  ' SQLCODE */
                    _.Display($"R2300 - PROBLEMAS  FETCH  CADIC  {DB.SQLCODE}");

                    /*" -3435- DISPLAY 'CERTIFICADO: ' RELATORI-NUM-TITULO */
                    _.Display($"CERTIFICADO: {RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO}");

                    /*" -3436- DISPLAY 'APOLICE    : ' RELATORI-NUM-APOLICE */
                    _.Display($"APOLICE    : {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                    /*" -3437- DISPLAY 'SUBGRUPO   : ' RELATORI-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO   : {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO}");

                    /*" -3439- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3442- PERFORM R2320-00-TRATA-ADICIONAIS VARYING IDX4 FROM 1 BY 1 UNTIL IDX4 > 08. */

            for (AREA_DE_WORK.IDX4.Value = 1; !(AREA_DE_WORK.IDX4 > 08); AREA_DE_WORK.IDX4.Value += 1)
            {

                R2320_00_TRATA_ADICIONAIS_SECTION();
            }

            /*" -3443- IF WFIM-ADICIONAIS = 'S' */

            if (WFIM_ADICIONAIS == "S")
            {

                /*" -3443- PERFORM R2300_00_MONTA_LINHAS_DB_CLOSE_2 */

                R2300_00_MONTA_LINHAS_DB_CLOSE_2();

                /*" -3448- MOVE CLIENTES-NOME-RAZAO OF DCLCLIENTES TO TB-EMPR-ENDER(IDX3) */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, MONTAGEM[AREA_DE_WORK.IDX3].TB_EMPR_ENDER);

                /*" -3450- MOVE SVA-ENDERECO TO TB-ENDERECO(IDX3) */
                _.Move(REG_SVE0414B.SVA_ENDERECO, MONTAGEM[AREA_DE_WORK.IDX3].TB_ENDERECO);

                /*" -3452- MOVE SVA-BAIRRO TO TB-BAIRRO (IDX3) */
                _.Move(REG_SVE0414B.SVA_BAIRRO, MONTAGEM[AREA_DE_WORK.IDX3].TB_BAIRRO);

                /*" -3454- MOVE SVA-CIDADE TO TB-CIDADE (IDX3) */
                _.Move(REG_SVE0414B.SVA_CIDADE, MONTAGEM[AREA_DE_WORK.IDX3].TB_CIDADE);

                /*" -3456- MOVE SVA-UF TO TB-UF (IDX3) */
                _.Move(REG_SVE0414B.SVA_UF, MONTAGEM[AREA_DE_WORK.IDX3].TB_UF);

                /*" -3458- MOVE SVA-NUM-CEP TO TB-NUMCEP (IDX3) */
                _.Move(REG_SVE0414B.SVA_NUM_CEP, MONTAGEM[AREA_DE_WORK.IDX3].TB_NUMCEP);

                /*" -3460- MOVE SVA-FONTE TO TB-FONTE (IDX3). */
                _.Move(REG_SVE0414B.SVA_FONTE, MONTAGEM[AREA_DE_WORK.IDX3].TB_FONTE);
            }


            /*" -3461- MOVE SVA-NUM-PROPOSTA-SIVPF TO TB-NUM-PROPOSTA-SIVPF (IDX3). */
            _.Move(REG_SVE0414B.SVA_NUM_PROPOSTA_SIVPF, MONTAGEM[AREA_DE_WORK.IDX3].TB_NUM_PROPOSTA_SIVPF);

            /*" -3462- MOVE SVA-DTH-DIA-DEBITO TO TB-DTH-DIA-DEBITO (IDX3). */
            _.Move(REG_SVE0414B.SVA_DTH_DIA_DEBITO, MONTAGEM[AREA_DE_WORK.IDX3].TB_DTH_DIA_DEBITO);

            /*" -3463- MOVE SVA-COD-AGENCIA-DEB TO TB-COD-AGENCIA-DEB (IDX3). */
            _.Move(REG_SVE0414B.SVA_COD_AGENCIA_DEB, MONTAGEM[AREA_DE_WORK.IDX3].TB_COD_AGENCIA_DEB);

            /*" -3464- MOVE SVA-OPERACAO-CONTA-DEB TO TB-OPERACAO-CONTA-DEB (IDX3). */
            _.Move(REG_SVE0414B.SVA_OPERACAO_CONTA_DEB, MONTAGEM[AREA_DE_WORK.IDX3].TB_OPERACAO_CONTA_DEB);

            /*" -3465- MOVE SVA-NUM-CONTA-DEBITO TO TB-NUM-CONTA-DEBITO (IDX3). */
            _.Move(REG_SVE0414B.SVA_NUM_CONTA_DEBITO, MONTAGEM[AREA_DE_WORK.IDX3].TB_NUM_CONTA_DEBITO);

            /*" -3466- MOVE SVA-DIG-CONTA-DEBITO TO TB-DIG-CONTA-DEBITO (IDX3). */
            _.Move(REG_SVE0414B.SVA_DIG_CONTA_DEBITO, MONTAGEM[AREA_DE_WORK.IDX3].TB_DIG_CONTA_DEBITO);

            /*" -3468- MOVE SVA-NUM-CARTAO-CREDITO TO TB-NUM-CARTAO-CREDITO (IDX3). */
            _.Move(REG_SVE0414B.SVA_NUM_CARTAO_CREDITO, MONTAGEM[AREA_DE_WORK.IDX3].TB_NUM_CARTAO_CREDITO);

            /*" -3468- MOVE SVA-CODPRODU TO TB-CODPRODU (IDX3). */
            _.Move(REG_SVE0414B.SVA_CODPRODU, MONTAGEM[AREA_DE_WORK.IDX3].TB_CODPRODU);

        }

        [StopWatch]
        /*" R2300-00-MONTA-LINHAS-DB-OPEN-1 */
        public void R2300_00_MONTA_LINHAS_DB_OPEN_1()
        {
            /*" -3411- EXEC SQL OPEN CADIC END-EXEC. */

            CADIC.Open();

        }

        [StopWatch]
        /*" R2300-00-MONTA-LINHAS-DB-FETCH-1 */
        public void R2300_00_MONTA_LINHAS_DB_FETCH_1()
        {
            /*" -3426- EXEC SQL FETCH CADIC INTO :VGARANTI-NUM-GARANTIA, :VGARANTI-DES-GARANTIA END-EXEC. */

            if (CADIC.Fetch())
            {
                _.Move(CADIC.VGARANTI_NUM_GARANTIA, VGARANTI.DCLVG_GARANTIA.VGARANTI_NUM_GARANTIA);
                _.Move(CADIC.VGARANTI_DES_GARANTIA, VGARANTI.DCLVG_GARANTIA.VGARANTI_DES_GARANTIA);
            }

        }

        [StopWatch]
        /*" R2300-00-MONTA-LINHAS-DB-CLOSE-1 */
        public void R2300_00_MONTA_LINHAS_DB_CLOSE_1()
        {
            /*" -3431- EXEC SQL CLOSE CADIC END-EXEC */

            CADIC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-MONTA-LINHAS-DB-CLOSE-2 */
        public void R2300_00_MONTA_LINHAS_DB_CLOSE_2()
        {
            /*" -3443- EXEC SQL CLOSE CADIC END-EXEC. */

            CADIC.Close();

        }

        [StopWatch]
        /*" R2301-00-SELECT-V0CLIENTE-SECTION */
        private void R2301_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -3480- MOVE '2301' TO WNR-EXEC-SQL. */
            _.Move("2301", WABEND.WNR_EXEC_SQL);

            /*" -3483- MOVE SVA-COD-CLIENTE TO CLIENTES-COD-CLIENTE OF DCLCLIENTES. */
            _.Move(REG_SVE0414B.SVA_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -3491- PERFORM R2301_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R2301_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -3494- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3495- DISPLAY 'R2301 - PROBLEMAS ACESSO TAB. CLIENTES' */
                _.Display($"R2301 - PROBLEMAS ACESSO TAB. CLIENTES");

                /*" -3496- DISPLAY 'NUM-TERMO   ' SVA-NUM-TERMO */
                _.Display($"NUM-TERMO   {REG_SVE0414B.SVA_NUM_TERMO}");

                /*" -3497- DISPLAY 'CODCLIENTE  ' SVA-COD-CLIENTE */
                _.Display($"CODCLIENTE  {REG_SVE0414B.SVA_COD_CLIENTE}");

                /*" -3498- DISPLAY 'SQLCODE     ' SQLCODE */
                _.Display($"SQLCODE     {DB.SQLCODE}");

                /*" -3498- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2301-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R2301_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -3491- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :DCLCLIENTES.CLIENTES-NOME-RAZAO, :DCLCLIENTES.CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.CLIENTES-COD-CLIENTE END-EXEC. */

            var r2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2301_99_SAIDA*/

        [StopWatch]
        /*" R2305-00-SELECT-V0CONDTEC-SECTION */
        private void R2305_00_SELECT_V0CONDTEC_SECTION()
        {
            /*" -3510- MOVE '2305' TO WNR-EXEC-SQL. */
            _.Move("2305", WABEND.WNR_EXEC_SQL);

            /*" -3511- MOVE 'N' TO WFIM-COBERTURAS. */
            _.Move("N", WFIM_COBERTURAS);

            /*" -3512- MOVE SVA-NRAPOLICE TO RELATORI-NUM-APOLICE */
            _.Move(REG_SVE0414B.SVA_NRAPOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -3513- MOVE SVA-CODSUBES TO RELATORI-COD-SUBGRUPO */
            _.Move(REG_SVE0414B.SVA_CODSUBES, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);

            /*" -3515- MOVE SVA-NUM-PROPOSTA-SIVPF TO VGTERNIV-NUM-PROPOSTA-SIVPF */
            _.Move(REG_SVE0414B.SVA_NUM_PROPOSTA_SIVPF, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF);

            /*" -3531- PERFORM R2305_00_SELECT_V0CONDTEC_DB_SELECT_1 */

            R2305_00_SELECT_V0CONDTEC_DB_SELECT_1();

            /*" -3534- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3535- DISPLAY 'R2305 - PROBLEMAS ACESSO CONDICOES_TECNICAS' */
                _.Display($"R2305 - PROBLEMAS ACESSO CONDICOES_TECNICAS");

                /*" -3536- DISPLAY 'APOLICE     ' RELATORI-NUM-APOLICE */
                _.Display($"APOLICE     {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -3537- DISPLAY 'SUBGRUPO    ' RELATORI-COD-SUBGRUPO */
                _.Display($"SUBGRUPO    {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO}");

                /*" -3538- DISPLAY 'SQLCODE     ' SQLCODE */
                _.Display($"SQLCODE     {DB.SQLCODE}");

                /*" -3540- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3543- MOVE '235A' TO WNR-EXEC-SQL. */
            _.Move("235A", WABEND.WNR_EXEC_SQL);

            /*" -3550- PERFORM R2305_00_SELECT_V0CONDTEC_DB_SELECT_2 */

            R2305_00_SELECT_V0CONDTEC_DB_SELECT_2();

            /*" -3553- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3554- DISPLAY 'R2305 - PROBLEMAS ACESSO APOLICES' */
                _.Display($"R2305 - PROBLEMAS ACESSO APOLICES");

                /*" -3555- DISPLAY 'APOLICE: ' RELATORI-NUM-APOLICE */
                _.Display($"APOLICE: {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -3557- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3559- MOVE APOLICES-COD-PRODUTO TO VA46DET-COD-PRODUTO */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COD_PRODUTO);

            /*" -3559- PERFORM R2307-00-CARREGA-BASICA. */

            R2307_00_CARREGA_BASICA_SECTION();

        }

        [StopWatch]
        /*" R2305-00-SELECT-V0CONDTEC-DB-SELECT-1 */
        public void R2305_00_SELECT_V0CONDTEC_DB_SELECT_1()
        {
            /*" -3531- EXEC SQL SELECT CARREGA_CONJUGE, CARREGA_FILHOS, GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD INTO :CONDITEC-CARREGA-CONJUGE, :CONDITEC-CARREGA-FILHOS, :CONDITEC-GARAN-ADIC-IEA, :CONDITEC-GARAN-ADIC-IPA, :CONDITEC-GARAN-ADIC-IPD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND COD_SUBGRUPO = :RELATORI-COD-SUBGRUPO END-EXEC. */

            var r2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 = new R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1()
            {
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1.Execute(r2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
                _.Move(executed_1.CONDITEC_CARREGA_FILHOS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/

        [StopWatch]
        /*" R2305-00-SELECT-V0CONDTEC-DB-SELECT-2 */
        public void R2305_00_SELECT_V0CONDTEC_DB_SELECT_2()
        {
            /*" -3550- EXEC SQL SELECT RAMO_EMISSOR, COD_PRODUTO INTO :APOLICES-RAMO-EMISSOR, :APOLICES-COD-PRODUTO FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE END-EXEC. */

            var r2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1 = new R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1()
            {
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1.Execute(r2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R2307-00-CARREGA-BASICA-SECTION */
        private void R2307_00_CARREGA_BASICA_SECTION()
        {
            /*" -3570- MOVE '                                  ' TO VA46DET-COBERTURA (1) */
            _.Move("                                  ", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[1].VA46DET_COBERTURA);

            /*" -3573- MOVE '|' TO VA46DET-COB-SEPARA(1) */
            _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[1].VA46DET_COB_SEPARA);

            /*" -3574- IF APOLICES-RAMO-EMISSOR = 93 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 93)
            {

                /*" -3576- MOVE 'MORTE CAUSAS NATURAIS E ACIDENTAIS' TO VA46DET-COBERTURA (2) */
                _.Move("MORTE CAUSAS NATURAIS E ACIDENTAIS", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[2].VA46DET_COBERTURA);

                /*" -3578- MOVE '|' TO VA46DET-COB-SEPARA(2) */
                _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[2].VA46DET_COB_SEPARA);

                /*" -3579- ELSE */
            }
            else
            {


                /*" -3581- MOVE 'MORTE ACIDENTAL' TO VA46DET-COBERTURA (2) */
                _.Move("MORTE ACIDENTAL", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[2].VA46DET_COBERTURA);

                /*" -3583- MOVE '|' TO VA46DET-COB-SEPARA(2) */
                _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[2].VA46DET_COB_SEPARA);

                /*" -3585- END-IF. */
            }


            /*" -3587- MOVE '                                  ' TO VA46DET-COBERTURA (3) */
            _.Move("                                  ", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[3].VA46DET_COBERTURA);

            /*" -3590- MOVE '|' TO VA46DET-COB-SEPARA(3) */
            _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[3].VA46DET_COB_SEPARA);

            /*" -3592- MOVE '                                  ' TO VA46DET-COBERTURA (4) */
            _.Move("                                  ", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[4].VA46DET_COBERTURA);

            /*" -3595- MOVE '|' TO VA46DET-COB-SEPARA(4) */
            _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[4].VA46DET_COB_SEPARA);

            /*" -3597- MOVE '                                  ' TO VA46DET-COBERTURA (5) */
            _.Move("                                  ", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[5].VA46DET_COBERTURA);

            /*" -3600- MOVE '|' TO VA46DET-COB-SEPARA(5) */
            _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[5].VA46DET_COB_SEPARA);

            /*" -3602- MOVE '                                  ' TO VA46DET-COBERTURA (6) */
            _.Move("                                  ", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[6].VA46DET_COBERTURA);

            /*" -3605- MOVE '|' TO VA46DET-COB-SEPARA(6) */
            _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[6].VA46DET_COB_SEPARA);

            /*" -3607- MOVE '                                  ' TO VA46DET-COBERTURA (7) */
            _.Move("                                  ", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[7].VA46DET_COBERTURA);

            /*" -3610- MOVE '|' TO VA46DET-COB-SEPARA(7) */
            _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[7].VA46DET_COB_SEPARA);

            /*" -3612- MOVE '                                  ' TO VA46DET-COBERTURA (8) */
            _.Move("                                  ", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[8].VA46DET_COBERTURA);

            /*" -3613- MOVE '|' TO VA46DET-COB-SEPARA(8) . */
            _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS[8].VA46DET_COB_SEPARA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2307_99_SAIDA*/

        [StopWatch]
        /*" R2320-00-TRATA-ADICIONAIS-SECTION */
        private void R2320_00_TRATA_ADICIONAIS_SECTION()
        {
            /*" -3628- MOVE '2320' TO WNR-EXEC-SQL. */
            _.Move("2320", WABEND.WNR_EXEC_SQL);

            /*" -3630- MOVE '                                 ' TO VA46DET-COBERTURA-AC(IDX4) */
            _.Move("                                 ", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS_AC[AREA_DE_WORK.IDX4].VA46DET_COBERTURA_AC);

            /*" -3632- MOVE '|' TO VA46DET-COB-SEPARA-AC(IDX4) */
            _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS_AC[AREA_DE_WORK.IDX4].VA46DET_COB_SEPARA_AC);

            /*" -3656- ADD 1 TO IDX4. */
            AREA_DE_WORK.IDX4.Value = AREA_DE_WORK.IDX4 + 1;

            /*" -3657- IF CONDITEC-CARREGA-CONJUGE GREATER ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE > 00)
            {

                /*" -3658- IF APOLICES-RAMO-EMISSOR = 82 */

                if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 82)
                {

                    /*" -3660- MOVE 'MORTE ACIDENTAL DO CONJUGE' TO VA46DET-COBERTURA-AC (IDX4) */
                    _.Move("MORTE ACIDENTAL DO CONJUGE", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS_AC[AREA_DE_WORK.IDX4].VA46DET_COBERTURA_AC);

                    /*" -3662- MOVE '|' TO VA46DET-COB-SEPARA-AC(IDX4) */
                    _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS_AC[AREA_DE_WORK.IDX4].VA46DET_COB_SEPARA_AC);

                    /*" -3662- ADD 1 TO IDX4. */
                    AREA_DE_WORK.IDX4.Value = AREA_DE_WORK.IDX4 + 1;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R2320_10 */

            R2320_10();

        }

        [StopWatch]
        /*" R2320-10 */
        private void R2320_10(bool isPerform = false)
        {
            /*" -3667- IF WFIM-ADICIONAIS NOT EQUAL 'S' */

            if (WFIM_ADICIONAIS != "S")
            {

                /*" -3669- IF APOLICES-RAMO-EMISSOR = 82 AND VGARANTI-NUM-GARANTIA = 5 */

                if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 82 && VGARANTI.DCLVG_GARANTIA.VGARANTI_NUM_GARANTIA == 5)
                {

                    /*" -3670- SUBTRACT 1 FROM IDX4 */
                    AREA_DE_WORK.IDX4.Value = AREA_DE_WORK.IDX4 - 1;

                    /*" -3671- ELSE */
                }
                else
                {


                    /*" -3672- MOVE VGARANTI-DES-GARANTIA TO VA46DET-COBERTURA-AC(IDX4) */
                    _.Move(VGARANTI.DCLVG_GARANTIA.VGARANTI_DES_GARANTIA, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS_AC[AREA_DE_WORK.IDX4].VA46DET_COBERTURA_AC);

                    /*" -3673- MOVE '|' TO VA46DET-COB-SEPARA-AC(IDX4) */
                    _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS_AC[AREA_DE_WORK.IDX4].VA46DET_COB_SEPARA_AC);

                    /*" -3674- ELSE */
                }

            }
            else
            {


                /*" -3675- MOVE SPACES TO VA46DET-COBERTURA-AC(IDX4) */
                _.Move("", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS_AC[AREA_DE_WORK.IDX4].VA46DET_COBERTURA_AC);

                /*" -3676- MOVE '|' TO VA46DET-COB-SEPARA-AC(IDX4) */
                _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COBERTURAS_AC[AREA_DE_WORK.IDX4].VA46DET_COB_SEPARA_AC);

                /*" -3677- ADD 1 TO IDX4 */
                AREA_DE_WORK.IDX4.Value = AREA_DE_WORK.IDX4 + 1;

                /*" -3678- IF IDX4 LESS 9 */

                if (AREA_DE_WORK.IDX4 < 9)
                {

                    /*" -3679- GO TO R2320-10 */
                    new Task(() => R2320_10()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3680- ELSE */
                }
                else
                {


                    /*" -3682- GO TO R2320-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3685- MOVE '232X' TO WNR-EXEC-SQL. */
            _.Move("232X", WABEND.WNR_EXEC_SQL);

            /*" -3689- PERFORM R2320_10_DB_FETCH_1 */

            R2320_10_DB_FETCH_1();

            /*" -3692- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3693- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3695- MOVE 'S' TO WFIM-ADICIONAIS */
                    _.Move("S", WFIM_ADICIONAIS);

                    /*" -3696- ADD 1 TO IDX4 */
                    AREA_DE_WORK.IDX4.Value = AREA_DE_WORK.IDX4 + 1;

                    /*" -3697- GO TO R2320-10 */
                    new Task(() => R2320_10()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3698- ELSE */
                }
                else
                {


                    /*" -3699- DISPLAY 'R2320 - PROBLEMAS  FETCH  CADIC ' */
                    _.Display($"R2320 - PROBLEMAS  FETCH  CADIC ");

                    /*" -3700- DISPLAY 'APOLICE     ' RELATORI-NUM-APOLICE */
                    _.Display($"APOLICE     {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                    /*" -3701- DISPLAY 'SUBGRUPO    ' RELATORI-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO    {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO}");

                    /*" -3703- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3704- ADD 1 TO IDX4 */
            AREA_DE_WORK.IDX4.Value = AREA_DE_WORK.IDX4 + 1;

            /*" -3704- GO TO R2320-10. */
            new Task(() => R2320_10()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2320-10-DB-FETCH-1 */
        public void R2320_10_DB_FETCH_1()
        {
            /*" -3689- EXEC SQL FETCH CADIC INTO :VGARANTI-NUM-GARANTIA, :VGARANTI-DES-GARANTIA END-EXEC. */

            if (CADIC.Fetch())
            {
                _.Move(CADIC.VGARANTI_NUM_GARANTIA, VGARANTI.DCLVG_GARANTIA.VGARANTI_NUM_GARANTIA);
                _.Move(CADIC.VGARANTI_DES_GARANTIA, VGARANTI.DCLVG_GARANTIA.VGARANTI_DES_GARANTIA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -3781- RETURN SVE0414B AT END */
            try
            {
                SVE0414B.Return(REG_SVE0414B, () =>
                {

                    /*" -3782- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", WFIM_SORT);

                    /*" -3784- GO TO R2400-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -3786- ADD 1 TO AC-LIDOS AC-CONTA. */
            AC_LIDOS.Value = AC_LIDOS + 1;
            AC_CONTA.Value = AC_CONTA + 1;

            /*" -3787- IF AC-CONTA GREATER 99 */

            if (AC_CONTA > 99)
            {

                /*" -3788- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -3789- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), WHORA_CURR);

                /*" -3789- DISPLAY 'LIDOS SORT     ' AC-LIDOS ' ' WHORA-CURR. */

                $"LIDOS SORT     {AC_LIDOS} {WHORA_CURR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-IMPRIME-CERTIFICADO-SECTION */
        private void R2500_00_IMPRIME_CERTIFICADO_SECTION()
        {
            /*" -3799- IF TB-NUM-TERMO(IDX2) EQUAL ZEROS */

            if (MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_TERMO == 00)
            {

                /*" -3801- GO TO R2500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3804- MOVE LD00A-DATADIA TO VA46DET-DATADIA-ES. */
            _.Move(AREA_DE_WORK.LD00A.LD00A_DATADIA, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_DATADIA_ES);

            /*" -3805- MOVE '-' TO SEPARA-008 */
            _.Move("-", TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_008);

            /*" -3815- MOVE '|' TO SEPARA-001 SEPARA-011 SEPARA-029 SEPARA-038 SEPARA-002 SEPARA-012 SEPARA-030 SEPARA-039 SEPARA-003 SEPARA-013 SEPARA-031 SEPARA-040 SEPARA-004 SEPARA-014 SEPARA-032 SEPARA-041 SEPARA-005 SEPARA-023 SEPARA-033 SEPARA-042 SEPARA-006 SEPARA-025 SEPARA-034 SEPARA-043 SEPARA-007 SEPARA-026 SEPARA-035 SEPARA-009 SEPARA-027 SEPARA-036 SEPARA-012-A SEPARA-028 SEPARA-037 */
            _.Move("|", TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_001, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_011, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_029, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_038, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_002, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_012, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_030, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_039, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_003, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_013, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_031, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_040, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_004, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_014, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_032, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_041, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_005, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_023, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_033, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_042, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_006, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_025, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_034, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_043, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_007, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_026, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_035, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_009, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_027, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_036, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_012_A, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_028, TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_037);

            /*" -3816- MOVE LE01-DTPOSTAGEM TO VA46DET-DT-POSTAGEM-ES */
            _.Move(AREA_DE_WORK.LE01_LINHA01.LE01_DTPOSTAGEM, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_DT_POSTAGEM_ES);

            /*" -3817- MOVE ALL '@' TO VA46DET-CODIGO-CIF-ES */
            _.MoveAll("@", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_CODIGO_CIF_ES);

            /*" -3822- MOVE ALL '#' TO VA46DET-POSTNET-ES */
            _.MoveAll("#", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_POSTNET_ES);

            /*" -3824- MOVE SPACES TO REG-DADOS */
            _.Move("", RVE0414B_RECORD.REG_DADOS);

            /*" -3826- MOVE LD00A TO REG-DADOS */
            _.Move(AREA_DE_WORK.LD00A, RVE0414B_RECORD.REG_DADOS);

            /*" -3827- MOVE SPACES TO RVE0414B-RECORD */
            _.Move("", RVE0414B_RECORD);

            /*" -3828- MOVE TB-NUM-PROPOSTA-SIVPF(IDX2) TO LD01-NUM-PROPOSTA */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_PROPOSTA_SIVPF, AREA_DE_WORK.LD01.LD01_NUM_PROPOSTA);

            /*" -3829- MOVE TB-NUM-APOLICE(IDX2) TO LD01-NUM-APOLICE */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_APOLICE, AREA_DE_WORK.LD01.LD01_NUM_APOLICE);

            /*" -3830- MOVE TB-SUBGRUPO(IDX2) TO LD01-SUBGRUPO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_SUBGRUPO, AREA_DE_WORK.LD01.LD01_SUBGRUPO);

            /*" -3831- MOVE TB-DIA-ADESAO(IDX2) TO LD01-DIA-ADESAO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_ADESAO.TB_DIA_ADESAO, AREA_DE_WORK.LD01.LD01_DATA_ADESAO.LD01_DIA_ADESAO);

            /*" -3832- MOVE TB-MES-ADESAO(IDX2) TO LD01-MES-ADESAO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_ADESAO.TB_MES_ADESAO, AREA_DE_WORK.LD01.LD01_DATA_ADESAO.LD01_MES_ADESAO);

            /*" -3833- MOVE TB-ANO-ADESAO(IDX2) TO LD01-ANO-ADESAO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_ADESAO.TB_ANO_ADESAO, AREA_DE_WORK.LD01.LD01_DATA_ADESAO.LD01_ANO_ADESAO);

            /*" -3834- MOVE TB-DIA-EMISSAO(IDX2) TO LD01-DIA-EMISSAO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_EMISSAO.TB_DIA_EMISSAO, AREA_DE_WORK.LD01.LD01_DATA_EMISSAO.LD01_DIA_EMISSAO);

            /*" -3835- MOVE TB-MES-EMISSAO(IDX2) TO LD01-MES-EMISSAO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_EMISSAO.TB_MES_EMISSAO, AREA_DE_WORK.LD01.LD01_DATA_EMISSAO.LD01_MES_EMISSAO);

            /*" -3836- MOVE TB-ANO-EMISSAO(IDX2) TO LD01-ANO-EMISSAO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_DATA_EMISSAO.TB_ANO_EMISSAO, AREA_DE_WORK.LD01.LD01_DATA_EMISSAO.LD01_ANO_EMISSAO);

            /*" -3838- MOVE LD01 TO REG-DADOS */
            _.Move(AREA_DE_WORK.LD01, RVE0414B_RECORD.REG_DADOS);

            /*" -3839- MOVE SPACES TO RVE0414B-RECORD */
            _.Move("", RVE0414B_RECORD);

            /*" -3840- MOVE TB-NOME-EMPRESA(IDX2) TO LD02-NOME-EMPRESA */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NOME_EMPRESA, AREA_DE_WORK.LD02.LD02_NOME_EMPRESA);

            /*" -3841- MOVE TB-CGC(IDX2) TO CGC */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_CGC, CGC);

            /*" -3842- MOVE NRO-CGC TO LD02-NRO-CGC */
            _.Move(CGC_R.NRO_CGC, AREA_DE_WORK.LD02.CNPJ_INT.LD02_NRO_CGC);

            /*" -3843- MOVE CNT-CGC TO LD02-CNT-CGC */
            _.Move(CGC_R.CNT_CGC, AREA_DE_WORK.LD02.CNPJ_INT.LD02_CNT_CGC);

            /*" -3844- MOVE DIG-CGC TO LD02-DIG-CGC */
            _.Move(CGC_R.DIG_CGC, AREA_DE_WORK.LD02.CNPJ_INT.LD02_DIG_CGC);

            /*" -3846- MOVE LD02 TO REG-DADOS */
            _.Move(AREA_DE_WORK.LD02, RVE0414B_RECORD.REG_DADOS);

            /*" -3847- MOVE SPACES TO RVE0414B-RECORD */
            _.Move("", RVE0414B_RECORD);

            /*" -3848- MOVE TB-COD-AGENCIA(IDX2) TO LD03-COD-AGENCIA */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_COD_AGENCIA, AREA_DE_WORK.LD03.LD03_COD_AGENCIA);

            /*" -3850- MOVE TB-NOME-AGENCIA(IDX2) TO LD03-NOME-AGENCIA */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NOME_AGENCIA, AREA_DE_WORK.LD03.LD03_NOME_AGENCIA);

            /*" -3851- MOVE LD01-SUBGRUPO TO VA46DET-SUBG-ES */
            _.Move(AREA_DE_WORK.LD01.LD01_SUBGRUPO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_SUBG_ES);

            /*" -3852- MOVE LD01-NUM-APOLICE TO VA46DET-NUM-APOLICE-ES */
            _.Move(AREA_DE_WORK.LD01.LD01_NUM_APOLICE, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_NUM_APOLICE_ES);

            /*" -3853- MOVE LD01-NUM-PROPOSTA TO VA46DET-NUM-PROPOSTA-ES */
            _.Move(AREA_DE_WORK.LD01.LD01_NUM_PROPOSTA, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_NUM_PROPOSTA_ES);

            /*" -3854- MOVE LD01-DATA-ADESAO TO VA46DET-DT-ADESAO-ES */
            _.Move(AREA_DE_WORK.LD01.LD01_DATA_ADESAO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_DT_ADESAO_ES);

            /*" -3855- MOVE LD01-DATA-EMISSAO TO VA46DET-DT-EMISSAO-ES */
            _.Move(AREA_DE_WORK.LD01.LD01_DATA_EMISSAO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_DT_EMISSAO_ES);

            /*" -3856- MOVE LD02-NOME-EMPRESA TO VA46DET-EMPRESA-ES */
            _.Move(AREA_DE_WORK.LD02.LD02_NOME_EMPRESA, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_EMPRESA_ES);

            /*" -3857- MOVE CNPJ-INT TO VA46DET-CNPJ-ES */
            _.Move(AREA_DE_WORK.LD02.CNPJ_INT, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_CNPJ_ES);

            /*" -3858- MOVE LD03-COD-AGENCIA TO VA46DET-COD-AGENCIA-ES */
            _.Move(AREA_DE_WORK.LD03.LD03_COD_AGENCIA, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_COD_AGENCIA_ES);

            /*" -3859- MOVE '-' TO SEPARA-008. */
            _.Move("-", TODAS_AS_LINHAS.VA46_DETALHE.SEPARA_008);

            /*" -3860- MOVE LD03-NOME-AGENCIA TO VA46DET-NOME-AGEN-ES */
            _.Move(AREA_DE_WORK.LD03.LD03_NOME_AGENCIA, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_NOME_AGEN_ES);

            /*" -3862- MOVE LD03 TO REG-DADOS */
            _.Move(AREA_DE_WORK.LD03, RVE0414B_RECORD.REG_DADOS);

            /*" -3863- MOVE SPACES TO RVE0414B-RECORD */
            _.Move("", RVE0414B_RECORD);

            /*" -3864- MOVE TB-MODALIDADE(IDX2) TO LD04-MODALIDADE */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_MODALIDADE, AREA_DE_WORK.LD04.LD04_MODALIDADE);

            /*" -3867- MOVE TB-PAGAMENTO(IDX2) TO LD04-PAGAMENTO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_PAGAMENTO, AREA_DE_WORK.LD04.LD04_PAGAMENTO);

            /*" -3869- MOVE LD04 TO REG-DADOS */
            _.Move(AREA_DE_WORK.LD04, RVE0414B_RECORD.REG_DADOS);

            /*" -3870- MOVE SPACES TO RVE0414B-RECORD */
            _.Move("", RVE0414B_RECORD);

            /*" -3872- MOVE TB-TIPO-COBERTURA(IDX2) TO LD05-TIPO-COBERTURA */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_TIPO_COBERTURA, AREA_DE_WORK.LD05.LD05_TIPO_COBERTURA);

            /*" -3873- MOVE TB-PLANO(IDX2) TO LD05-PLANO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_PLANO, AREA_DE_WORK.LD05.LD05_PLANO);

            /*" -3875- MOVE LD05 TO REG-DADOS */
            _.Move(AREA_DE_WORK.LD05, RVE0414B_RECORD.REG_DADOS);

            /*" -3876- MOVE SPACES TO RVE0414B-RECORD */
            _.Move("", RVE0414B_RECORD);

            /*" -3877- MOVE TB-PLANO-AP(IDX2) TO LD06-PLANO-AP */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_PLANO_AP, AREA_DE_WORK.LD06.LD06_PLANO_AP);

            /*" -3878- MOVE TB-CAPITAL(IDX2) TO LD06-CAPITAL */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_CAPITAL, AREA_DE_WORK.LD06.LD06_CAPITAL);

            /*" -3879- MOVE TB-VIDAS(IDX2) TO LD06-VIDAS */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_VIDAS, AREA_DE_WORK.LD06.LD06_VIDAS);

            /*" -3880- MOVE TB-CUSTO(IDX2) TO LD06-CUSTO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_CUSTO, AREA_DE_WORK.LD06.LD06_CUSTO);

            /*" -3881- MOVE LD06-CAPITAL TO VA46DET-IS-ES */
            _.Move(AREA_DE_WORK.LD06.LD06_CAPITAL, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_IS_ES);

            /*" -3882- MOVE LD06-VIDAS TO VA46DET-N-VIDA-ES */
            _.Move(AREA_DE_WORK.LD06.LD06_VIDAS, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_N_VIDA_ES);

            /*" -3883- MOVE LD06-CUSTO TO VA46DET-CUSTO-ES */
            _.Move(AREA_DE_WORK.LD06.LD06_CUSTO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_CUSTO_ES);

            /*" -3885- MOVE LD06 TO REG-DADOS */
            _.Move(AREA_DE_WORK.LD06, RVE0414B_RECORD.REG_DADOS);

            /*" -3886- MOVE TB-DTH-DIA-DEBITO(IDX2) TO VA46DET-DIA-COBRANCA. */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_DTH_DIA_DEBITO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_DIA_COBRANCA);

            /*" -3887- MOVE TB-COD-AGENCIA-DEB(IDX2) TO WS-AGECTADEB. */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_COD_AGENCIA_DEB, WS_CONTA_CORRENTE.WS_AGECTADEB);

            /*" -3888- MOVE TB-OPERACAO-CONTA-DEB(IDX2) TO WS-OPRCTADEB. */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_OPERACAO_CONTA_DEB, WS_CONTA_CORRENTE.WS_OPRCTADEB);

            /*" -3889- MOVE TB-NUM-CONTA-DEBITO(IDX2) TO WS-NUMCTADEB. */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_CONTA_DEBITO, WS_CONTA_CORRENTE.WS_NUMCTADEB);

            /*" -3890- MOVE TB-DIG-CONTA-DEBITO(IDX2) TO WS-DIGCTADEB. */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_DIG_CONTA_DEBITO, WS_CONTA_CORRENTE.WS_DIGCTADEB);

            /*" -3891- MOVE '.' TO WS-PONTO1. */
            _.Move(".", WS_CONTA_CORRENTE.WS_PONTO1);

            /*" -3892- MOVE '.' TO WS-PONTO2. */
            _.Move(".", WS_CONTA_CORRENTE.WS_PONTO2);

            /*" -3893- MOVE '-' TO WS-TRACO. */
            _.Move("-", WS_CONTA_CORRENTE.WS_TRACO);

            /*" -3895- MOVE WS-OPCAO-PAGAMENTO TO VA46DET-CONTA-CORR-ES. */
            _.Move(WS_OPCAO_PAGAMENTO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_CONTA_CORR_ES);

            /*" -3896- IF TB-NUM-CARTAO-CREDITO(IDX2) GREATER ZEROS */

            if (MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_CARTAO_CREDITO > 00)
            {

                /*" -3897- MOVE SPACES TO WS-OPCAO-PAGAMENTO */
                _.Move("", WS_OPCAO_PAGAMENTO);

                /*" -3898- MOVE SPACES TO VA46DET-CONTA-CORR-ES */
                _.Move("", TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_CONTA_CORR_ES);

                /*" -3899- MOVE TB-CARTAO1(IDX2) TO WS-CCRED1 */
                _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_CARTAO_CREDITOR.TB_CARTAO1, WS_CARTAO_CREDITO.WS_CCRED1);

                /*" -3900- MOVE '.' TO WS-CCRED1-PTO */
                _.Move(".", WS_CARTAO_CREDITO.WS_CCRED1_PTO);

                /*" -3901- MOVE TB-CARTAO2(IDX2) TO WS-CCRED2 */
                _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_CARTAO_CREDITOR.TB_CARTAO2, WS_CARTAO_CREDITO.WS_CCRED2);

                /*" -3902- MOVE '.' TO WS-CCRED2-PTO */
                _.Move(".", WS_CARTAO_CREDITO.WS_CCRED2_PTO);

                /*" -3903- MOVE TB-CARTAO3(IDX2) TO WS-CCRED3 */
                _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_CARTAO_CREDITOR.TB_CARTAO3, WS_CARTAO_CREDITO.WS_CCRED3);

                /*" -3904- MOVE '.' TO WS-CCRED3-PTO */
                _.Move(".", WS_CARTAO_CREDITO.WS_CCRED3_PTO);

                /*" -3905- MOVE TB-CARTAO4(IDX2) TO WS-CCRED4 */
                _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_CARTAO_CREDITOR.TB_CARTAO4, WS_CARTAO_CREDITO.WS_CCRED4);

                /*" -3907- MOVE WS-OPCAO-PAGAMENTO TO VA46DET-CONTA-CORR-ES. */
                _.Move(WS_OPCAO_PAGAMENTO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_CONTA_CORR_ES);
            }


            /*" -3921- MOVE SVA-PERIODICIDADE TO VA46DET-PERIODICIDADE-ES. */
            _.Move(REG_SVE0414B.SVA_PERIODICIDADE, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_PERIODICIDADE_ES);

            /*" -3921- MOVE SVA-SORTEIO TO VA46DET-SORTEIO. */
            _.Move(REG_SVE0414B.SVA_SORTEIO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_SORTEIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-IMPRIME-ENDERECO-SECTION */
        private void R2600_00_IMPRIME_ENDERECO_SECTION()
        {
            /*" -3931- MOVE 1 TO IDX2. */
            _.Move(1, AREA_DE_WORK.IDX2);

            /*" -3932- IF TB-NUM-TERMO(IDX2) EQUAL ZEROS */

            if (MONTAGEM[AREA_DE_WORK.IDX2].TB_NUM_TERMO == 00)
            {

                /*" -3934- GO TO R2600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3936- MOVE TB-NOME-EMPRESA(IDX2) TO WS-NOME-RAZAO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_NOME_EMPRESA, WS_NOME_RAZAO);

            /*" -3938- PERFORM R2900-00-FORMATA-NOME-RAZAO */

            R2900_00_FORMATA_NOME_RAZAO_SECTION();

            /*" -3939- MOVE LD00B-NOME-CLIENTE TO VA46DET-CLIENTE-ES */
            _.Move(AREA_DE_WORK.LD00B.LD00B_NOME_CLIENTE, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_CLIENTE_ES);

            /*" -3941- MOVE LD00B TO REG-DADOS */
            _.Move(AREA_DE_WORK.LD00B, RVE0414B_RECORD.REG_DADOS);

            /*" -3943- MOVE TB-CEP (IDX2) TO LE05-CEP DESW-CEP */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].FILLER_156.TB_CEP, AREA_DE_WORK.LE05_LINHA05.CEP_INT_DEST.LE05_CEP, AREA_DE_WORK.DEST_NUM_CEP.FILLER_123.DESW_CEP);

            /*" -3945- MOVE TB-CEP-COMPL(IDX2) TO LE05-CEP-COMPL DESW-CEP-COMPL */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].FILLER_156.TB_CEP_COMPL, AREA_DE_WORK.LE05_LINHA05.CEP_INT_DEST.LE05_CEP_COMPL, AREA_DE_WORK.DEST_NUM_CEP.FILLER_123.DESW_CEP_COMPL);

            /*" -3946- MOVE TB-CIDADE (IDX2) TO LE04-CIDADE */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_CIDADE, AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE);

            /*" -3947- MOVE TB-BAIRRO (IDX2) TO LE04-BAIRRO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_BAIRRO, AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO);

            /*" -3948- MOVE TB-UF (IDX2) TO LE04-UF */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_UF, AREA_DE_WORK.LE04_LINHA04.LE04_UF);

            /*" -3950- MOVE TB-ENDERECO (IDX2) TO LE03-ENDERECO */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_ENDERECO, AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO);

            /*" -3951- MOVE LE03-ENDERECO TO VA46DET-ENDERECO-ES */
            _.Move(AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_ENDERECO_ES);

            /*" -3952- MOVE LE04-CIDADE TO VA46DET-CIDADE-ES */
            _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_CIDADE_ES);

            /*" -3953- MOVE LE04-BAIRRO TO VA46DET-BAIRRO-ES */
            _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_BAIRRO_ES);

            /*" -3954- MOVE LE04-UF TO VA46DET-UF-ES */
            _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_UF, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_UF_ES);

            /*" -3956- MOVE CEP-INT-DEST TO VA46DET-CEP-ES. */
            _.Move(AREA_DE_WORK.LE05_LINHA05.CEP_INT_DEST, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_CEP_ES);

            /*" -3957- ADD 1 TO WS-SEQ TAB1-QTD-OBJ(WS-CEP-G-ANT) AC-QTD-OBJ */
            AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
            TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_OBJ.Value = TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_OBJ + 1;
            AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;

            /*" -3959- ADD 1 TO AC-CONTA1 */
            AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

            /*" -3960- MOVE 'XXX.XXX' TO LE01-SEQUENCIA */
            _.Move("XXX.XXX", AREA_DE_WORK.LE01_LINHA01.LE01_SEQUENCIA);

            /*" -3962- MOVE LE01-SEQUENCIA TO VA46DET-NUM-OBJETO-ES */
            _.Move(AREA_DE_WORK.LE01_LINHA01.LE01_SEQUENCIA, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_NUM_OBJETO_ES);

            /*" -3963- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
            {

                /*" -3964- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                /*" -3966- MOVE WS-SEQ TO TAB1-OBJI (WS-CEP-G-ANT) */
                _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_OBJI);

                /*" -3968- END-IF. */
            }


            /*" -3969- IF WS-CONTR-200 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_200 == 00)
            {

                /*" -3970- MOVE 1 TO WS-CONTR-200 */
                _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                /*" -3971- MOVE WS-SEQ TO WS-SEQ-INICIAL */
                _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);

                /*" -3974- END-IF. */
            }


            /*" -3980- PERFORM R2600-00-BUSCA-FONTE */

            R2600_00_BUSCA_FONTE_SECTION();

            /*" -3981- WRITE RVE0414B-RECORD FROM VA46-DETALHE */
            _.Move(TODAS_AS_LINHAS.VA46_DETALHE.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -3982- MOVE TB-CODPRODU (IDX2) TO WWRK-CODPRODU */
            _.Move(MONTAGEM[AREA_DE_WORK.IDX2].TB_CODPRODU, AREA_DE_WORK.DEST_NUM_CEP.WWRK_CODPRODU);

            /*" -3982- PERFORM R4000-00-GERA-OBJETO. */

            R4000_00_GERA_OBJETO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-BUSCA-FONTE-SECTION */
        private void R2600_00_BUSCA_FONTE_SECTION()
        {
            /*" -3994- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WABEND.WNR_EXEC_SQL);

            /*" -3994- MOVE ZEROS TO IDX1. */
            _.Move(0, AREA_DE_WORK.IDX1);

            /*" -0- FLUXCONTROL_PERFORM R2600_LOOP */

            R2600_LOOP();

        }

        [StopWatch]
        /*" R2600-LOOP */
        private void R2600_LOOP(bool isPerform = false)
        {
            /*" -4000- ADD 1 TO IDX1. */
            AREA_DE_WORK.IDX1.Value = AREA_DE_WORK.IDX1 + 1;

            /*" -4001- IF IDX1 > 19 */

            if (AREA_DE_WORK.IDX1 > 19)
            {

                /*" -4003- GO TO R2600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4004- IF TB-FONTE(IDX2) = TAB-FONTE (IDX1) */

            if (MONTAGEM[AREA_DE_WORK.IDX2].TB_FONTE == TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_FONTE)
            {

                /*" -4006- MOVE TAB-NOMEFTE (IDX1) TO LE06-REMETENTE */
                _.Move(TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_NOMEFTE, AREA_DE_WORK.LE06_LINHA06.REMET_INT.LE06_REMETENTE);

                /*" -4008- MOVE TAB-ENDERFTE(IDX1) TO LE07-ENDERECO */
                _.Move(TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_ENDERFTE, AREA_DE_WORK.LE07_LINHA07.LE07_ENDERECO);

                /*" -4010- MOVE TAB-BAIRRO (IDX1) TO LE08-BAIRRO */
                _.Move(TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_BAIRRO, AREA_DE_WORK.LE08_LINHA08.LE08_BAIRRO);

                /*" -4012- MOVE TAB-CIDADE (IDX1) TO LE08-CIDADE */
                _.Move(TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_CIDADE, AREA_DE_WORK.LE08_LINHA08.LE08_CIDADE);

                /*" -4014- MOVE TAB-UF (IDX1) TO LE08-UF */
                _.Move(TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_UF, AREA_DE_WORK.LE08_LINHA08.LE08_UF);

                /*" -4016- MOVE TAB-CEP (IDX1) TO DEST-NUM-CEP */
                _.Move(TAB_FILIAL.FILLER_140[AREA_DE_WORK.IDX1].TAB_CEP, AREA_DE_WORK.DEST_NUM_CEP);

                /*" -4017- MOVE DEST-CEP TO LE09-CEP */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP, AREA_DE_WORK.LE09_LINHA09.CEP_INT_REMET.LE09_CEP);

                /*" -4018- MOVE DEST-CEP-COMPL TO LE09-CEP-COMPL */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP_COMPL, AREA_DE_WORK.LE09_LINHA09.CEP_INT_REMET.LE09_CEP_COMPL);

                /*" -4019- MOVE REMET-INT TO VA46DET-RETENTE-ES */
                _.Move(AREA_DE_WORK.LE06_LINHA06.REMET_INT, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_RETENTE_ES);

                /*" -4020- MOVE LE07-ENDERECO TO VA46DET-REMET-ENDE-ES */
                _.Move(AREA_DE_WORK.LE07_LINHA07.LE07_ENDERECO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_REMET_ENDE_ES);

                /*" -4021- MOVE LE08-BAIRRO TO VA46DET-REMET-BAIRRO-ES */
                _.Move(AREA_DE_WORK.LE08_LINHA08.LE08_BAIRRO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_REMET_BAIRRO_ES);

                /*" -4022- MOVE LE08-CIDADE TO VA46DET-REMET-CIDADE-ES */
                _.Move(AREA_DE_WORK.LE08_LINHA08.LE08_CIDADE, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_REMET_CIDADE_ES);

                /*" -4023- MOVE LE08-UF TO VA46DET-REMET-UF-ES */
                _.Move(AREA_DE_WORK.LE08_LINHA08.LE08_UF, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_REMET_UF_ES);

                /*" -4024- MOVE CEP-INT-REMET TO VA46DET-REMET-CEP-ES */
                _.Move(AREA_DE_WORK.LE09_LINHA09.CEP_INT_REMET, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_REMET_CEP_ES);

                /*" -4026- GO TO R2600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4026- GO TO R2600-LOOP. */
            new Task(() => R2600_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-FORMATA-NOME-RAZAO-SECTION */
        private void R2900_00_FORMATA_NOME_RAZAO_SECTION()
        {
            /*" -4036- IF WS-LETRA-NOME(40) NOT EQUAL SPACES */

            if (WS_NOME_RAZAO.WS_LETRA_NOME[40] != string.Empty)
            {

                /*" -4037- MOVE ',' TO WS-LETRA-NOME(41) */
                _.Move(",", WS_NOME_RAZAO.WS_LETRA_NOME[41]);

                /*" -4039- MOVE WS-NOME-RAZAO TO LC03-NOME-RAZAO LD00B-NOME-CLIENTE */
                _.Move(WS_NOME_RAZAO, AREA_DE_WORK.LC03_LINHA03.LC03_NOME_RAZAO, AREA_DE_WORK.LD00B.LD00B_NOME_CLIENTE);

                /*" -4040- MOVE ' ' TO WS-LETRA-NOME(41) */
                _.Move(" ", WS_NOME_RAZAO.WS_LETRA_NOME[41]);

                /*" -4041- MOVE WS-NOME-RAZAO TO LE02-NOME-RAZAO */
                _.Move(WS_NOME_RAZAO, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -4042- MOVE LE02-NOME-RAZAO TO VA46DET-DESTINATARIO-ES */
                _.Move(AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_DESTINATARIO_ES);

                /*" -4044- GO TO R2900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4044- MOVE 40 TO IDX5. */
            _.Move(40, AREA_DE_WORK.IDX5);

            /*" -0- FLUXCONTROL_PERFORM R2900_10_LOOP */

            R2900_10_LOOP();

        }

        [StopWatch]
        /*" R2900-10-LOOP */
        private void R2900_10_LOOP(bool isPerform = false)
        {
            /*" -4050- SUBTRACT 1 FROM IDX5. */
            AREA_DE_WORK.IDX5.Value = AREA_DE_WORK.IDX5 - 1;

            /*" -4051- IF IDX3 LESS 1 */

            if (AREA_DE_WORK.IDX3 < 1)
            {

                /*" -4053- MOVE SPACES TO LC03-NOME-RAZAO LE02-NOME-RAZAO */
                _.Move("", AREA_DE_WORK.LC03_LINHA03.LC03_NOME_RAZAO, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -4054- MOVE LE02-NOME-RAZAO TO VA46DET-DESTINATARIO-ES */
                _.Move(AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_DESTINATARIO_ES);

                /*" -4056- GO TO R2900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4057- IF WS-LETRA-NOME(IDX5) NOT EQUAL SPACES */

            if (WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.IDX5] != string.Empty)
            {

                /*" -4058- ADD 1 TO IDX5 */
                AREA_DE_WORK.IDX5.Value = AREA_DE_WORK.IDX5 + 1;

                /*" -4059- MOVE ',' TO WS-LETRA-NOME(IDX5) */
                _.Move(",", WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.IDX5]);

                /*" -4061- MOVE WS-NOME-RAZAO TO LC03-NOME-RAZAO LD00B-NOME-CLIENTE */
                _.Move(WS_NOME_RAZAO, AREA_DE_WORK.LC03_LINHA03.LC03_NOME_RAZAO, AREA_DE_WORK.LD00B.LD00B_NOME_CLIENTE);

                /*" -4062- MOVE ' ' TO WS-LETRA-NOME(IDX5) */
                _.Move(" ", WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.IDX5]);

                /*" -4063- MOVE WS-NOME-RAZAO TO LE02-NOME-RAZAO */
                _.Move(WS_NOME_RAZAO, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -4064- MOVE LE02-NOME-RAZAO TO VA46DET-DESTINATARIO-ES */
                _.Move(AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO, TODAS_AS_LINHAS.VA46_DETALHE.VA46DET_DESTINATARIO_ES);

                /*" -4066- GO TO R2900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4066- GO TO R2900-10-LOOP. */
            new Task(() => R2900_10_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-IMPRIME-LST-SECTION */
        private void R3000_00_IMPRIME_LST_SECTION()
        {
            /*" -4076- MOVE 1 TO IDX7. */
            _.Move(1, AREA_DE_WORK.IDX7);

            /*" -4076- MOVE 0 TO CONTA-LINHAS. */
            _.Move(0, CONTA_LINHAS);

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LOOP_OCORR */

            R3000_10_LOOP_OCORR();

        }

        [StopWatch]
        /*" R3000-10-LOOP-OCORR */
        private void R3000_10_LOOP_OCORR(bool isPerform = false)
        {
            /*" -4081- IF IDX7 GREATER 2000 */

            if (AREA_DE_WORK.IDX7 > 2000)
            {

                /*" -4082- MOVE 1 TO IDX7 */
                _.Move(1, AREA_DE_WORK.IDX7);

                /*" -4084- GO TO R3000-20-INT. */

                R3000_20_INT(); //GOTO
                return;
            }


            /*" -4085- IF TAB1-QTD-OBJ (IDX7) NOT EQUAL ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_QTD_OBJ != 00)
            {

                /*" -4087- ADD 1 TO WS-OCORR. */
                AREA_DE_WORK.WS_OCORR.Value = AREA_DE_WORK.WS_OCORR + 1;
            }


            /*" -4088- ADD 1 TO IDX7. */
            AREA_DE_WORK.IDX7.Value = AREA_DE_WORK.IDX7 + 1;

            /*" -4088- GO TO R3000-10-LOOP-OCORR. */
            new Task(() => R3000_10_LOOP_OCORR()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3000-20-INT */
        private void R3000_20_INT(bool isPerform = false)
        {
            /*" -4093- COMPUTE WWORK-QTDE = (WS-OCORR / 18) */
            AREA_DE_WORK.WWORK_QTDE.Value = (AREA_DE_WORK.WS_OCORR / 18f);

            /*" -4094- IF WWORK-QTDE12 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE12 != 00)
            {

                /*" -4096- COMPUTE WWORK-QTDE11 = WWORK-QTDE11 + 1. */
                AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11.Value = AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11 + 1;
            }


            /*" -4096- MOVE WWORK-QTDE11 TO LR02-PAG-FINAL. */
            _.Move(AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11, AREA_DE_WORK.LR02_LINHA02.LR02_PAG_INT.LR02_PAG_FINAL);

        }

        [StopWatch]
        /*" R3000-30-LOOP-CABEC */
        private void R3000_30_LOOP_CABEC(bool isPerform = false)
        {
            /*" -4101- IF IDX7 > 2000 */

            if (AREA_DE_WORK.IDX7 > 2000)
            {

                /*" -4102- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -4104- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4105- IF TAB1-QTD-OBJ (IDX7) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_QTD_OBJ == 00)
            {

                /*" -4106- ADD 1 TO IDX7 */
                AREA_DE_WORK.IDX7.Value = AREA_DE_WORK.IDX7 + 1;

                /*" -4108- GO TO R3000-30-LOOP-CABEC. */
                new Task(() => R3000_30_LOOP_CABEC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4109- ADD 1 TO AC-PAGINA. */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -4110- MOVE AC-PAGINA TO LR02-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LR02_LINHA02.LR02_PAG_INT.LR02_PAGINA);

            /*" -4111- MOVE LR02-PAG-INT TO PAGINA11-JDT */
            _.Move(AREA_DE_WORK.LR02_LINHA02.LR02_PAG_INT, LINHAS_AMARRADO.L11_JDT.PAGINA11_JDT);

            /*" -4113- MOVE 1 TO AC-LINHAS. */
            _.Move(1, AREA_DE_WORK.AC_LINHAS);

            /*" -4114- MOVE TAB-FX-INI(IDX7) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.IDX7].TAB_FAIXAS.TAB_FX_INI, WS_NUM_CEP_AUX);

            /*" -4115- MOVE WS-CEP-AUX TO LR05-CEPI. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_CEPI);

            /*" -4116- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPI. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_COMPL_CEPI);

            /*" -4117- MOVE TAB-FX-FIM(IDX7) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.IDX7].TAB_FAIXAS.TAB_FX_FIM, WS_NUM_CEP_AUX);

            /*" -4118- MOVE WS-CEP-AUX TO LR05-CEPF. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_CEPF);

            /*" -4119- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPF. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_COMPL_CEPF);

            /*" -4120- MOVE TAB1-OBJI(IDX7) TO LR05-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_OBJI, AREA_DE_WORK.LR05_LINHA05.LR05_OBJI);

            /*" -4121- MOVE TAB1-OBJF(IDX7) TO LR05-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_OBJF, AREA_DE_WORK.LR05_LINHA05.LR05_OBJF);

            /*" -4122- MOVE TAB1-AMARI(IDX7) TO LR05-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_AMARI, AREA_DE_WORK.LR05_LINHA05.LR05_AMARI);

            /*" -4123- MOVE TAB1-AMARF(IDX7) TO LR05-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_AMARF, AREA_DE_WORK.LR05_LINHA05.LR05_AMARF);

            /*" -4124- MOVE TAB1-QTD-OBJ(IDX7) TO LR05-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_QTD_OBJ, AREA_DE_WORK.LR05_LINHA05.LR05_QTD_OBJ);

            /*" -4125- MOVE TAB1-QTD-AMAR(IDX7) TO LR05-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_QTD_AMAR, AREA_DE_WORK.LR05_LINHA05.LR05_QTD_AMAR);

            /*" -4126- MOVE SPACES TO LR05-OBS. */
            _.Move("", AREA_DE_WORK.LR05_LINHA05.LR05_OBS);

            /*" -4127- WRITE FVE0414B-RECORD FROM L3-JDT. */
            _.Move(LINHAS_AMARRADO.L3_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4128- WRITE FVE0414B-RECORD FROM L4-JDT. */
            _.Move(LINHAS_AMARRADO.L4_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4129- WRITE FVE0414B-RECORD FROM L5-JDT. */
            _.Move(LINHAS_AMARRADO.L5_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4130- WRITE FVE0414B-RECORD FROM L6-JDT. */
            _.Move(LINHAS_AMARRADO.L6_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4131- WRITE FVE0414B-RECORD FROM L7-JDT. */
            _.Move(LINHAS_AMARRADO.L7_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4132- WRITE FVE0414B-RECORD FROM L8-JDT. */
            _.Move(LINHAS_AMARRADO.L8_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4133- WRITE FVE0414B-RECORD FROM L9-JDT. */
            _.Move(LINHAS_AMARRADO.L9_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4134- WRITE FVE0414B-RECORD FROM L10-JDT. */
            _.Move(LINHAS_AMARRADO.L10_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4135- WRITE FVE0414B-RECORD FROM L11-JDT. */
            _.Move(LINHAS_AMARRADO.L11_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4136- WRITE FVE0414B-RECORD FROM LR05-LINHA05. */
            _.Move(AREA_DE_WORK.LR05_LINHA05.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4136- ADD 1 TO CONTA-LINHAS. */
            CONTA_LINHAS.Value = CONTA_LINHAS + 1;

        }

        [StopWatch]
        /*" R3000-40-LOOP-DET */
        private void R3000_40_LOOP_DET(bool isPerform = false)
        {
            /*" -4142- ADD 1 TO IDX7. */
            AREA_DE_WORK.IDX7.Value = AREA_DE_WORK.IDX7 + 1;

            /*" -4143- IF IDX7 > 2000 */

            if (AREA_DE_WORK.IDX7 > 2000)
            {

                /*" -4144- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -4146- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4147- IF TAB1-QTD-OBJ (IDX7) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_QTD_OBJ == 00)
            {

                /*" -4149- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4150- MOVE TAB-FX-INI(IDX7) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.IDX7].TAB_FAIXAS.TAB_FX_INI, WS_NUM_CEP_AUX);

            /*" -4151- MOVE WS-CEP-AUX TO LR06-CEPI. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_CEPI);

            /*" -4152- MOVE WS-CEP-COMPL-AUX TO LR06-COMPL-CEPI. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_COMPL_CEPI);

            /*" -4153- MOVE TAB-FX-FIM(IDX7) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.IDX7].TAB_FAIXAS.TAB_FX_FIM, WS_NUM_CEP_AUX);

            /*" -4154- MOVE WS-CEP-AUX TO LR06-CEPF. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_CEPF);

            /*" -4155- MOVE WS-CEP-COMPL-AUX TO LR06-COMPL-CEPF. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_COMPL_CEPF);

            /*" -4156- MOVE TAB1-OBJI(IDX7) TO LR06-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_OBJI, AREA_DE_WORK.LR06_LINHA06.LR06_OBJI);

            /*" -4157- MOVE TAB1-OBJF(IDX7) TO LR06-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_OBJF, AREA_DE_WORK.LR06_LINHA06.LR06_OBJF);

            /*" -4158- MOVE TAB1-AMARI(IDX7) TO LR06-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_AMARI, AREA_DE_WORK.LR06_LINHA06.LR06_AMARI);

            /*" -4159- MOVE TAB1-AMARF(IDX7) TO LR06-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_AMARF, AREA_DE_WORK.LR06_LINHA06.LR06_AMARF);

            /*" -4160- MOVE TAB1-QTD-OBJ(IDX7) TO LR06-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_QTD_OBJ, AREA_DE_WORK.LR06_LINHA06.LR06_QTD_OBJ);

            /*" -4161- MOVE TAB1-QTD-AMAR(IDX7) TO LR06-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.IDX7].TAB1_QTD_AMAR, AREA_DE_WORK.LR06_LINHA06.LR06_QTD_AMAR);

            /*" -4162- MOVE SPACES TO LR06-OBS. */
            _.Move("", AREA_DE_WORK.LR06_LINHA06.LR06_OBS);

            /*" -4163- WRITE FVE0414B-RECORD FROM LR06-LINHA06. */
            _.Move(AREA_DE_WORK.LR06_LINHA06.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4164- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -4166- ADD 1 TO CONTA-LINHAS. */
            CONTA_LINHAS.Value = CONTA_LINHAS + 1;

            /*" -4167- IF AC-LINHAS > 17 */

            if (AREA_DE_WORK.AC_LINHAS > 17)
            {

                /*" -4169- ADD 1 TO IDX7 */
                AREA_DE_WORK.IDX7.Value = AREA_DE_WORK.IDX7 + 1;

                /*" -4170- PERFORM R3010-00-GRAVA-SEP-JDT */

                R3010_00_GRAVA_SEP_JDT_SECTION();

                /*" -4171- GO TO R3000-30-LOOP-CABEC */

                R3000_30_LOOP_CABEC(); //GOTO
                return;

                /*" -4172- ELSE */
            }
            else
            {


                /*" -4172- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-GRAVA-SEP-JDT-SECTION */
        private void R3010_00_GRAVA_SEP_JDT_SECTION()
        {
            /*" -4182- IF WS-OCORR NOT = CONTA-LINHAS */

            if (AREA_DE_WORK.WS_OCORR != CONTA_LINHAS)
            {

                /*" -4182- WRITE FVE0414B-RECORD FROM SEPARA-JDT. */
                _.Move(LINHAS_AMARRADO.SEPARA_JDT.GetMoveValues(), FVE0414B_RECORD);

                FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-GERA-OBJETO-SECTION */
        private void R4000_00_GERA_OBJETO_SECTION()
        {
            /*" -4241- IF RELATORI-NUM-APOLICE = 108210105792 OR 109300001350 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.In("108210105792", "109300001350"))
            {

                /*" -4242- MOVE 'VA62' TO GEOBJECT-COD-FORMULARIO */
                _.Move("VA62", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

                /*" -4243- ELSE */
            }
            else
            {


                /*" -4244- IF RELATORI-NUM-APOLICE = 109300001661 */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE == 109300001661)
                {

                    /*" -4245- MOVE 'VA71' TO GEOBJECT-COD-FORMULARIO */
                    _.Move("VA71", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

                    /*" -4246- ELSE */
                }
                else
                {


                    /*" -4247- IF RELATORI-NUM-APOLICE = 108210554769 */

                    if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE == 108210554769)
                    {

                        /*" -4248- MOVE 'VA72' TO GEOBJECT-COD-FORMULARIO */
                        _.Move("VA72", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

                        /*" -4249- ELSE */
                    }
                    else
                    {


                        /*" -4251- IF RELATORI-NUM-APOLICE = 97010000889 OR 109300000672 */

                        if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.In("97010000889", "109300000672"))
                        {

                            /*" -4252- MOVE 'VA95' TO GEOBJECT-COD-FORMULARIO */
                            _.Move("VA95", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

                            /*" -4253- ELSE */
                        }
                        else
                        {


                            /*" -4254- MOVE SVA-FORMULARIO TO GEOBJECT-COD-FORMULARIO */
                            _.Move(REG_SVE0414B.SVA_FORMULARIO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

                            /*" -4256- END-IF. */
                        }

                    }

                }

            }


            /*" -4267- PERFORM R4000_00_GERA_OBJETO_DB_SELECT_1 */

            R4000_00_GERA_OBJETO_DB_SELECT_1();

            /*" -4270- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -4271- PERFORM R4000-03-VALUES-DETALHE */

                R4000_03_VALUES_DETALHE_SECTION();

                /*" -4272- PERFORM R4000-02-INSERT-OBJETO */

                R4000_02_INSERT_OBJETO_SECTION();

                /*" -4274- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4275- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -4276- DISPLAY 'R4000-00 - ERRO DE ACESSO GE_OBJETO_ECT.' */
                _.Display($"R4000-00 - ERRO DE ACESSO GE_OBJETO_ECT.");

                /*" -4277- DISPLAY 'FORMULARIO: ' GEOBJECT-COD-FORMULARIO */
                _.Display($"FORMULARIO: {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO}");

                /*" -4278- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4279- ELSE */
            }
            else
            {


                /*" -4280- PERFORM R4000-01-VALUES-HEADER */

                R4000_01_VALUES_HEADER_SECTION();

                /*" -4281- PERFORM R4000-02-INSERT-OBJETO */

                R4000_02_INSERT_OBJETO_SECTION();

                /*" -4282- PERFORM R4000-03-VALUES-DETALHE. */

                R4000_03_VALUES_DETALHE_SECTION();
            }


            /*" -4282- PERFORM R4000-02-INSERT-OBJETO. */

            R4000_02_INSERT_OBJETO_SECTION();

        }

        [StopWatch]
        /*" R4000-00-GERA-OBJETO-DB-SELECT-1 */
        public void R4000_00_GERA_OBJETO_DB_SELECT_1()
        {
            /*" -4267- EXEC SQL SELECT DISTINCT STA_REGISTRO INTO :GEOBJECT-STA-REGISTRO FROM SEGUROS.GE_OBJETO_ECT WHERE NUM_CEP = 0 AND NOM_PROGRAMA = 'VE0414B' AND COD_FORMULARIO = :GEOBJECT-COD-FORMULARIO AND STA_REGISTRO = 'H' AND DATE(DTH_TIMESTAMP) <> '9999-12-31' ORDER BY STA_REGISTRO END-EXEC. */

            var r4000_00_GERA_OBJETO_DB_SELECT_1_Query1 = new R4000_00_GERA_OBJETO_DB_SELECT_1_Query1()
            {
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
            };

            var executed_1 = R4000_00_GERA_OBJETO_DB_SELECT_1_Query1.Execute(r4000_00_GERA_OBJETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOBJECT_STA_REGISTRO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4000-01-VALUES-HEADER-SECTION */
        private void R4000_01_VALUES_HEADER_SECTION()
        {
            /*" -4292- MOVE 0 TO GEOBJECT-NUM-CEP */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -4293- MOVE 'H' TO GEOBJECT-STA-REGISTRO */
            _.Move("H", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -4294- MOVE -1 TO WIND-PRODUTO */
            _.Move(-1, WIND_PRODUTO);

            /*" -4295- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -4296- MOVE 0 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -4297- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -4298- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -4299- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -4299- MOVE VA46-HEADER TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(TODAS_AS_LINHAS.VA46_HEADER, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_01_SAIDA*/

        [StopWatch]
        /*" R4000-02-INSERT-OBJETO-SECTION */
        private void R4000_02_INSERT_OBJETO_SECTION()
        {
            /*" -4323- PERFORM R4000_02_INSERT_OBJETO_DB_INSERT_1 */

            R4000_02_INSERT_OBJETO_DB_INSERT_1();

            /*" -4326- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4327- DISPLAY 'R4000-02 - ERRO NO INSERT DA GE-OBJETO-ECT ' */
                _.Display($"R4000-02 - ERRO NO INSERT DA GE-OBJETO-ECT ");

                /*" -4329- DISPLAY 'H = HEADER D = DETALHE.' GEOBJECT-STA-REGISTRO */
                _.Display($"H = HEADER D = DETALHE.{GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO}");

                /*" -4330- DISPLAY 'PROGRAMA VE0414B.......' */
                _.Display($"PROGRAMA VE0414B.......");

                /*" -4332- DISPLAY 'FORMULARIO............ ' GEOBJECT-COD-FORMULARIO */
                _.Display($"FORMULARIO............ {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO}");

                /*" -4333- DISPLAY 'SQLCODE............... ' SQLCODE */
                _.Display($"SQLCODE............... {DB.SQLCODE}");

                /*" -4333- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-02-INSERT-OBJETO-DB-INSERT-1 */
        public void R4000_02_INSERT_OBJETO_DB_INSERT_1()
        {
            /*" -4323- EXEC SQL INSERT INTO SEGUROS.GE_OBJETO_ECT VALUES (:GEOBJECT-NUM-CEP, 'VE0414B' , :GEOBJECT-COD-FORMULARIO, :GEOBJECT-STA-REGISTRO, CURRENT TIMESTAMP, :GEOBJECT-COD-PRODUTO:WIND-PRODUTO, :GEOBJECT-NUM-INI-POS-VERSO, :GEOBJECT-QTD-PESO-GRAMAS, :GEOBJECT-VLR-DECLARADO, :GEOBJECT-COD-IDENT-OBJETO, :GEOBJECT-DES-OBJETO) END-EXEC. */

            var r4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1 = new R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1()
            {
                GEOBJECT_NUM_CEP = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP.ToString(),
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
                GEOBJECT_STA_REGISTRO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO.ToString(),
                GEOBJECT_COD_PRODUTO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO.ToString(),
                WIND_PRODUTO = WIND_PRODUTO.ToString(),
                GEOBJECT_NUM_INI_POS_VERSO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO.ToString(),
                GEOBJECT_QTD_PESO_GRAMAS = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS.ToString(),
                GEOBJECT_VLR_DECLARADO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO.ToString(),
                GEOBJECT_COD_IDENT_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO.ToString(),
                GEOBJECT_DES_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.ToString(),
            };

            R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1.Execute(r4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_02_SAIDA*/

        [StopWatch]
        /*" R4000-03-VALUES-DETALHE-SECTION */
        private void R4000_03_VALUES_DETALHE_SECTION()
        {
            /*" -4343- MOVE DESW-NUM-CEP TO GEOBJECT-NUM-CEP */
            _.Move(AREA_DE_WORK.DEST_NUM_CEP.DESW_NUM_CEP, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -4344- MOVE 'D' TO GEOBJECT-STA-REGISTRO */
            _.Move("D", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -4345- MOVE WWRK-CODPRODU TO GEOBJECT-COD-PRODUTO */
            _.Move(AREA_DE_WORK.DEST_NUM_CEP.WWRK_CODPRODU, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO);

            /*" -4346- MOVE ZEROS TO WIND-PRODUTO */
            _.Move(0, WIND_PRODUTO);

            /*" -4347- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -4348- MOVE 4,6 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(4.6, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -4349- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -4350- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -4351- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -4351- MOVE VA46-DETALHE TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(TODAS_AS_LINHAS.VA46_DETALHE, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_03_SAIDA*/

        [StopWatch]
        /*" R5000-00-ATU-RELATORIOS-SECTION */
        private void R5000_00_ATU_RELATORIOS_SECTION()
        {
            /*" -4365- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", WABEND.WNR_EXEC_SQL);

            /*" -4366- MOVE 'VE0401B1' TO RELATORI-COD-RELATORIO */
            _.Move("VE0401B1", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -4367- MOVE '0' TO RELATORI-SIT-REGISTRO */
            _.Move("0", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -4368- MOVE SVA-NRAPOLICE TO RELATORI-NUM-APOLICE */
            _.Move(REG_SVE0414B.SVA_NRAPOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -4370- MOVE SVA-CODSUBES TO RELATORI-COD-SUBGRUPO */
            _.Move(REG_SVE0414B.SVA_CODSUBES, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);

            /*" -4378- PERFORM R5000_00_ATU_RELATORIOS_DB_UPDATE_1 */

            R5000_00_ATU_RELATORIOS_DB_UPDATE_1();

            /*" -4381- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4382- DISPLAY 'R5000 - PROBLEMAS UPDATE RELATORIOS' */
                _.Display($"R5000 - PROBLEMAS UPDATE RELATORIOS");

                /*" -4383- DISPLAY 'COD RELATORIO: ' RELATORI-COD-RELATORIO */
                _.Display($"COD RELATORIO: {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}");

                /*" -4384- DISPLAY 'SIT REGISTRO : ' RELATORI-COD-RELATORIO */
                _.Display($"SIT REGISTRO : {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}");

                /*" -4385- DISPLAY 'NUM APOLICE  : ' RELATORI-NUM-APOLICE */
                _.Display($"NUM APOLICE  : {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -4386- DISPLAY 'COD SUBGRUPO : ' RELATORI-COD-SUBGRUPO */
                _.Display($"COD SUBGRUPO : {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO}");

                /*" -4386- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-ATU-RELATORIOS-DB-UPDATE-1 */
        public void R5000_00_ATU_RELATORIOS_DB_UPDATE_1()
        {
            /*" -4378- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' ,TIMESTAMP = CURRENT TIMESTAMP WHERE COD_RELATORIO = :RELATORI-COD-RELATORIO AND SIT_REGISTRO = :RELATORI-SIT-REGISTRO AND NUM_APOLICE = :RELATORI-NUM-APOLICE AND COD_SUBGRUPO = :RELATORI-COD-SUBGRUPO END-EXEC. */

            var r5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1 = new R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1.Execute(r5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -4401- OPEN OUTPUT RVE0414B FVE0414B RVE0414I RVE0414P RVE0414H. */
            RVE0414B.Open(RVE0414B_RECORD);
            FVE0414B.Open(FVE0414B_RECORD);
            RVE0414I.Open(RVE0414I_RECORD);
            RVE0414P.Open(RVE0414P_RECORD);
            RVE0414H.Open(RVE0414H_RECORD);

            /*" -4402- WRITE RVE0414B-RECORD FROM LAISER-01. */
            _.Move(TODAS_AS_LINHAS.LAISER_01.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4403- WRITE RVE0414B-RECORD FROM LAISER-02. */
            _.Move(TODAS_AS_LINHAS.LAISER_02.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4404- WRITE RVE0414B-RECORD FROM LAISER-03. */
            _.Move(TODAS_AS_LINHAS.LAISER_03.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4405- WRITE RVE0414B-RECORD FROM LAISER-04. */
            _.Move(TODAS_AS_LINHAS.LAISER_04.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4406- WRITE RVE0414B-RECORD FROM LAISER-05. */
            _.Move(TODAS_AS_LINHAS.LAISER_05.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4407- WRITE RVE0414B-RECORD FROM LAISER-06. */
            _.Move(TODAS_AS_LINHAS.LAISER_06.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4408- WRITE RVE0414B-RECORD FROM LAISER-07. */
            _.Move(TODAS_AS_LINHAS.LAISER_07.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4409- WRITE RVE0414B-RECORD FROM LAISER-08. */
            _.Move(TODAS_AS_LINHAS.LAISER_08.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4410- WRITE RVE0414B-RECORD FROM LAISER-09. */
            _.Move(TODAS_AS_LINHAS.LAISER_09.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4411- WRITE RVE0414B-RECORD FROM VA46-HEADER. */
            _.Move(TODAS_AS_LINHAS.VA46_HEADER.GetMoveValues(), RVE0414B_RECORD);

            RVE0414B.Write(RVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4412- WRITE FVE0414B-RECORD FROM L1-JDT. */
            _.Move(LINHAS_AMARRADO.L1_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4413- WRITE FVE0414B-RECORD FROM L2-JDT. */
            _.Move(LINHAS_AMARRADO.L2_JDT.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4413- PERFORM R9100-00-LIMPA-DET-FAC. */

            R9100_00_LIMPA_DET_FAC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -4423- WRITE FVE0414B-RECORD FROM LAISERFAC-FINAL. */
            _.Move(TODAS_AS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), FVE0414B_RECORD);

            FVE0414B.Write(FVE0414B_RECORD.GetMoveValues().ToString());

            /*" -4427- CLOSE RVE0414B FVE0414B RVE0414I RVE0414P RVE0414H. */
            RVE0414B.Close();
            FVE0414B.Close();
            RVE0414I.Close();
            RVE0414P.Close();
            RVE0414H.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-LIMPA-DET-FAC-SECTION */
        private void R9100_00_LIMPA_DET_FAC_SECTION()
        {
            /*" -4437- MOVE SPACES TO FAC-DETALHE. */
            _.Move("", TODAS_AS_LINHAS.FAC_DETALHE);

            /*" -4437- MOVE '|' TO SEPA-01 SEPA-02 SEPA-03 SEPA-04. */
            _.Move("|", TODAS_AS_LINHAS.FAC_DETALHE.SEPA_01, TODAS_AS_LINHAS.FAC_DETALHE.SEPA_02, TODAS_AS_LINHAS.FAC_DETALHE.SEPA_03, TODAS_AS_LINHAS.FAC_DETALHE.SEPA_04);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9140-TRATAR-RESULT-SECTION */
        private void R9140_TRATAR_RESULT_SECTION()
        {
            /*" -4448- EXEC SQL ASSOCIATE LOCATORS (:WL-LOCATOR) WITH PROCEDURE SEGUROS.SPBVG012 END-EXEC */
            /*-Linha desconsiderada por ser -inútil- no .NET por segurança adicionado SQLCODE = 0*/
            DB.SQLCODE.Value = 0;

            /*" -4452- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -4453- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4455- DISPLAY 'ERRO NO R9140 - SPBVG012 - ' ' SQLCODE <' WSQLCODE '>' */

                $"ERRO NO R9140 - SPBVG012 -  SQLCODE <{WABEND.WSQLCODE}>"
                .Display();

                /*" -4456- DISPLAY ' BILHETE <' WS-NUM-PROPOSTA '>' */

                $" BILHETE <{WS_NUM_PROPOSTA}>"
                .Display();

                /*" -4457- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4459- END-IF */
            }


            /*" -4462- EXEC SQL ALLOCATE C01-RESULT CURSOR FOR RESULT SET :WL-LOCATOR END-EXEC */
            C01_RESULT.Allocate($"SEGUROS.SPBVG012");

            /*" -4463- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9140_99_SAIDA*/

        [StopWatch]
        /*" R9150-LER-RESULT-SECTION */
        private void R9150_LER_RESULT_SECTION()
        {
            /*" -4488- PERFORM R9150_LER_RESULT_DB_FETCH_1 */

            R9150_LER_RESULT_DB_FETCH_1();

            /*" -4492- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -4493- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4495- DISPLAY 'ERRO CURSOR <C01-RESULT> SQLCODE <' WSQLCODE '>' */

                $"ERRO CURSOR <C01-RESULT> SQLCODE <{WABEND.WSQLCODE}>"
                .Display();

                /*" -4496- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4497- ELSE */
            }
            else
            {


                /*" -4500- IF WF-COD-STA-TITULO EQUAL 'ATV' OR (WF-COD-STA-TITULO EQUAL 'EMT' AND WF-COD-SUB-STATUS EQUAL 'RSV' ) */

                if (WF_COD_STA_TITULO == "ATV" || (WF_COD_STA_TITULO == "EMT" && WF_COD_SUB_STATUS == "RSV"))
                {

                    /*" -4502- INITIALIZE SVA-SORTEIO SVA-NUM-PLANO */
                    _.Initialize(
                        REG_SVE0414B.SVA_SORTEIO
                        , REG_SVE0414B.SVA_NUM_PLANO
                    );

                    /*" -4503- MOVE WF-DES-COMBINACAO(1:9) TO SVA-SORTEIO */
                    _.Move(WF_DES_COMBINACAO.Substring(1, 9), REG_SVE0414B.SVA_SORTEIO);

                    /*" -4504- MOVE WF-NUM-PLANO TO SVA-NUM-PLANO */
                    _.Move(WF_NUM_PLANO, REG_SVE0414B.SVA_NUM_PLANO);

                    /*" -4505- MOVE 1 TO WS-EOF-RESULT */
                    _.Move(1, WS_EOF.WS_EOF_RESULT);

                    /*" -4506- ELSE */
                }
                else
                {


                    /*" -4507- MOVE 'N' TO WTEM-SORTEIO */
                    _.Move("N", WTEM_SORTEIO);

                    /*" -4508- MOVE 1 TO WS-EOF-RESULT */
                    _.Move(1, WS_EOF.WS_EOF_RESULT);

                    /*" -4509- END-IF */
                }


                /*" -4510- END-IF */
            }


            /*" -4510- . */

        }

        [StopWatch]
        /*" R9150-LER-RESULT-DB-FETCH-1 */
        public void R9150_LER_RESULT_DB_FETCH_1()
        {
            /*" -4488- EXEC SQL FETCH C01-RESULT INTO :WF-NUM-PLANO , :WF-NUM-SERIE , :WF-NUM-TITULO , :WF-COD-STA-TITULO , :WF-COD-SUB-STATUS , :WF-DTH-ATIVACAO , :WF-DTH-CADUCACAO , :WF-DTH-CRIACAO , :WF-DTH-FIM-VIGENCIA , :WF-DTH-INI-SORTEIO , :WF-DTH-INI-VIGENCIA , :WF-DTH-SUSPENSAO , :WF-IND-DV , :WF-VLR-MENSALIDADE , :WF-NUM-PROPOSTA , :WF-NUM-MOD-PLANO , :WF-DES-COMBINACAO END-EXEC */

            if (C01_RESULT.Fetch())
            {
                _.Move(C01_RESULT.WF_NUM_PLANO, WF_NUM_PLANO);
                _.Move(C01_RESULT.WF_NUM_SERIE, WF_NUM_SERIE);
                _.Move(C01_RESULT.WF_NUM_TITULO, WF_NUM_TITULO);
                _.Move(C01_RESULT.WF_COD_STA_TITULO, WF_COD_STA_TITULO);
                _.Move(C01_RESULT.WF_COD_SUB_STATUS, WF_COD_SUB_STATUS);
                _.Move(C01_RESULT.WF_DTH_ATIVACAO, WF_DTH_ATIVACAO);
                _.Move(C01_RESULT.WF_DTH_CADUCACAO, WF_DTH_CADUCACAO);
                _.Move(C01_RESULT.WF_DTH_CRIACAO, WF_DTH_CRIACAO);
                _.Move(C01_RESULT.WF_DTH_FIM_VIGENCIA, WF_DTH_FIM_VIGENCIA);
                _.Move(C01_RESULT.WF_DTH_INI_SORTEIO, WF_DTH_INI_SORTEIO);
                _.Move(C01_RESULT.WF_DTH_INI_VIGENCIA, WF_DTH_INI_VIGENCIA);
                _.Move(C01_RESULT.WF_DTH_SUSPENSAO, WF_DTH_SUSPENSAO);
                _.Move(C01_RESULT.WF_IND_DV, WF_IND_DV);
                _.Move(C01_RESULT.WF_VLR_MENSALIDADE, WF_VLR_MENSALIDADE);
                _.Move(C01_RESULT.WF_NUM_PROPOSTA, WF_NUM_PROPOSTA);
                _.Move(C01_RESULT.WF_NUM_MOD_PLANO, WF_NUM_MOD_PLANO);
                _.Move(C01_RESULT.WF_DES_COMBINACAO, WF_DES_COMBINACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9150_99_SAIDA*/

        [StopWatch]
        /*" R9160-FECHAR-CURSOR-SECTION */
        private void R9160_FECHAR_CURSOR_SECTION()
        {
            /*" -4516- PERFORM R9160_FECHAR_CURSOR_DB_CLOSE_1 */

            R9160_FECHAR_CURSOR_DB_CLOSE_1();

            /*" -4520- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -4521- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4523- DISPLAY 'R9160 - ERRO NO CLOSE DO CURSOR <C01-RESULT> ' 'SQLCODE <' WSQLCODE '>' */

                $"R9160 - ERRO NO CLOSE DO CURSOR <C01-RESULT> SQLCODE <{WABEND.WSQLCODE}>"
                .Display();

                /*" -4524- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4525- END-IF. */
            }


        }

        [StopWatch]
        /*" R9160-FECHAR-CURSOR-DB-CLOSE-1 */
        public void R9160_FECHAR_CURSOR_DB_CLOSE_1()
        {
            /*" -4516- EXEC SQL CLOSE C01-RESULT END-EXEC */

            C01_RESULT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9160_99_SAIDA*/

        [StopWatch]
        /*" R9200-00-PESQUISA-FORMULARIO-SECTION */
        private void R9200_00_PESQUISA_FORMULARIO_SECTION()
        {
            /*" -4537- MOVE '9200' TO WNR-EXEC-SQL. */
            _.Move("9200", WABEND.WNR_EXEC_SQL);

            /*" -4538- MOVE SVA-CODPRODU TO RELATORI-COD-PLANO */
            _.Move(REG_SVE0414B.SVA_CODPRODU, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);

            /*" -4540- MOVE SVA-FORMULARIO TO RELATORI-COD-RELATORIO */
            _.Move(REG_SVE0414B.SVA_FORMULARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -4552- PERFORM R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1 */

            R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1();

            /*" -4555- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4556- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4557- MOVE 'N' TO WACHOU-UNIC */
                    _.Move("N", WACHOU_UNIC);

                    /*" -4558- GO TO R9200-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9200_FIM*/ //GOTO
                    return;

                    /*" -4559- ELSE */
                }
                else
                {


                    /*" -4560- DISPLAY 'R9200 - PROBLEMAS SELECT RELATORIOS' */
                    _.Display($"R9200 - PROBLEMAS SELECT RELATORIOS");

                    /*" -4561- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4562- END-IF */
                }


                /*" -4564- END-IF */
            }


            /*" -4565- MOVE 'S' TO WACHOU-UNIC. */
            _.Move("S", WACHOU_UNIC);

        }

        [StopWatch]
        /*" R9200-00-PESQUISA-FORMULARIO-DB-SELECT-1 */
        public void R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1()
        {
            /*" -4552- EXEC SQL SELECT TIPO_CORRECAO , NUM_APOL_LIDER INTO :RELATORI-TIPO-CORRECAO , :RELATORI-NUM-APOL-LIDER FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'VG' AND NUM_APOLICE = 9999999999999 AND COD_SUBGRUPO = 9999 AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND COD_PLANO = :RELATORI-COD-PLANO WITH UR END-EXEC */

            var r9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1 = new R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
            };

            var executed_1 = R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1.Execute(r9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_TIPO_CORRECAO, RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);
                _.Move(executed_1.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9200_FIM*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -4577- DISPLAY '*----------------------------------*' */
            _.Display($"*----------------------------------*");

            /*" -4578- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -4579- DISPLAY '*        VE0414B - FIM NORMAL      *' */
            _.Display($"*        VE0414B - FIM NORMAL      *");

            /*" -4580- DISPLAY '*        -------   ----------      *' */
            _.Display($"*        -------   ----------      *");

            /*" -4581- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -4582- DISPLAY '*        NAO HOUVE SOLICITACAO     *' */
            _.Display($"*        NAO HOUVE SOLICITACAO     *");

            /*" -4583- DISPLAY '*              NESTA DATA          *' */
            _.Display($"*              NESTA DATA          *");

            /*" -4583- DISPLAY '*----------------------------------*' . */
            _.Display($"*----------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -4597- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -4599- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -4599- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -4601- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4605- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -4605- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}