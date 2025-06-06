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
using Sias.VidaAzul.DB2.VA4437B;

namespace Code
{
    public class VA4437B
    {
        public bool IsCall { get; set; }

        public VA4437B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  EMITE CERTIFICADOS DAS APOLICES PESSOA FISICA NO PADRAO FAC.  *      */
        /*"V.24  *  VERSAO 24  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2024 - TERCIO CARVALHO/SERGIO LORETO                *      */
        /*"      *                                       PROCURE POR V.24         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *  VERSAO 23  - DEMANDA 578503 / TAREFA 583607                   *      */
        /*"      *                                                                *      */
        /*"      *    - 3 CAMPOS DE NOME SOCIAL ADICIONADOS NO FINAL DOS ARQUIVOS:*      */
        /*"      *      => SEGURADO_SOCIAL, DESTINATARIO_SOCIAL, CLIENTE_SOCIAL   *      */
        /*"      *                                                                *      */
        /*"      *    UTILIDADE:                                                  *      */
        /*"      *    . SE SEGURADO_SOCIAL, DESTINATARIO_SOCIAL, CLIENTE_SOCIAL   *      */
        /*"      *    ESTIVEREM PREENCHIDOS NO ARQUIVO, O CCM DEVERA UTILIZA-LOS  *      */
        /*"      *    NA COMUNICACAO AO CLIENTE, CASO CONTRARIO, CONTINUAR COM OS *      */
        /*"      *    CAMPOS: SEGURADO, DESTINATARIO E CLIENTE.                   *      */
        /*"      *                                                                *      */
        /*"      *  EM 13/05/2024 - ANSELMO SOUSA                                 *      */
        /*"      *                                        PROCURE POR V.23        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.22  *VERSAO V.22-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV121 *VERSAO 21: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV121 *           AJUSTA MONTAGEM STARTDBM                                    */
        /*"JV121 *           - PROCURAR POR JV121                                        */
        /*"JV120#*----------------------------------------------------------------*      */
        /*"JV120#*VERSAO 20: JV1 DEMANDA 262179 - KINKAS 28/10/2020               *      */
        /*"JV120#*           TROCA REFERENCIAS PRODUTOS JV1 POR JVPRDXXXX         *      */
        /*"JV120#*           - PROCURAR POR JV120                                 *      */
        /*"JV120#*----------------------------------------------------------------*      */
        /*"JV119 *VERSAO 19: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV119 *           ALTERA FORMULARIOS PARA EMPRESA 11 - JV1                    */
        /*"JV119 *           - PROCURAR POR JV119                                        */
        /*"JV119 *-----------------------------------------------------------------      */
        /*"      *   VERSAO 18 - HIST 206.622     TAREFA: 228.884                 *      */
        /*"      *             - RETIRAR FORMULARIOS CVP                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/01/2020 - HERVAL SOUZA                                 *      */
        /*"      *                                       PROCURE POR JV.01        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17 -                                                  *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *             - FOLHETERIA                                       *      */
        /*"      *   EM 17/02/2019 - JOAO ARAUJO                                  *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - HIST 181.577                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 15 - CAD 146.446                                       *      */
        /*"      *            - NAO GERAR MAIS FORMULARIO VA54, SERA GERADO PELO  *      */
        /*"      *              PGM VA5437B, COM CIRCULAR SUSEP 491               *      */
        /*"      *                                                                *      */
        /*"      *  EM 24/04/2017 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                       PROCURE POR V.15         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 14 - CAD 148.799                                       *      */
        /*"      *            - ALTERAR O NOME DA COBERTURA 22 PARA "COBERTURA DE *      */
        /*"      *              DOENCAS CRONICAS GRAVES EM ESTAGIO AVANCADO" PARA *      */
        /*"      *              APOLICE 109300000559.                             *      */
        /*"      *            - EXCLUIR COBERTURA 24 E INCLUIR COBERTURA 86 PARA  *      */
        /*"      *              HOMOLOGACAO E 44 PARA PRODUCAO PARA SUBGRUPOS     *      */
        /*"      *              01, 02, 06, 08, 10, 12, 14, 16 e 18 DA APOLICE    *      */
        /*"      *              109300000559.                                     *      */
        /*"      *                                                                *      */
        /*"      *  EM 10/04/2017 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 13 - CAD 117.316                                       *      */
        /*"      *            - ALTERAR PARA GERAR FORMULARIO VA54 PARA PRODUTOS  *      */
        /*"      *              "PARA APROVEITAR A VIDA".                         *      */
        /*"      *            - INSERIR O DIZER "HERDEIROS LEGAIS" QUANDO NAO     *      */
        /*"      *              HOUVER BENEFICIARIOS CADASTRADOS, COM 100%.       *      */
        /*"      *            - INSERIR O DIZER "NAO CONTEMPLA" NO CAMPO SORTEIOS *      */
        /*"      *              PARA OS PRODUTOS 9328, 9334, 9357, 9358, 9314,    *      */
        /*"      *              9703 E 9705                                       *      */
        /*"      *                                                                *      */
        /*"      *  EM 03/11/2015 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 12   - INCLUIR FILTRO UNIC - FORMULARIO VD09.          *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2017 - LUIGI CONTE                                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 11   - INCLUIR CAMPO COD_SUSEPCAP NO ARQUIVO DE SAIDA. *      */
        /*"      *              - INCLUIR FILTRO DE 15 DIAS NA DATA DE SOLICITACAO*      */
        /*"      *                NO CURSOR PRINCIPAL                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/12/2016 - LUIGI CONTE                                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 10   - ABEND - CAD 142921                              *      */
        /*"      *              - RETIRAR O FILTRO POR COD_MODALIDADE DO SELECTS  *      */
        /*"      *                NA TABELA APOLICE_COBERTURAS.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/10/2016 - LUIGI CONTE                                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 09 -  CAD 116.938                                      *      */
        /*"      *              - AJUSTE NA CONSULTA DA INFORMACAO DE ENDERECO    *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/07/2016 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD 119494                                       *      */
        /*"      *               MODULO DE RETENCAO - PROJETO UNIC                *      */
        /*"      *               INCLUIR FILTROS DE ENVIO DOS FORMULARIOS E       *      */
        /*"      *               RETIRADA DO ARQUIVO DE LOG.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/06/2016 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.08             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 07 -  CAD 116.938                                      *      */
        /*"      *              - AJUSTE NA CONSULTA DA INFORMACAO DE ENDERECO    *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/07/2015 - RIBAMAR MARQUES (STEFANINI)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 06 -   NSGD - CADMUS 103659.                           *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 110.125                                      *      */
        /*"      *             - ALTERACAO DO NOME-PRODUTO PARA PEGAR NA TABELA   *      */
        /*"      *               SEGUROS.PRODUTO                                  *      */
        /*"      *                                                                *      */
        /*"      *   12/03/2015 - ELIERMES OLIVEIRA                               *      */
        /*"      *                                              PROCURE POR V.05  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - 28/08/2014 LUIZ GUSTAVO DE OLIVEIRA              *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 101217- RESSEGURO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.04       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - 31/01/2014 TERCIO FREITAS                        *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 82426 - INCLUIR DATA DE NASCIMENTO E CODIGO SUSEP     *      */
        /*"      *                  NO LAYOUT DO ARQUIVO.                         *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.03       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - 20/01/2014 TERCIO FREITAS                        *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 83623 - INCLUIR A IMPRESSAO DA COBERTURA SAF PARA OS  *      */
        /*"      *                  CERTIFICADOS PF.                              *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 84924 - AJUSTE NA QUANTIDADE DE OCORRENCIA DAS COBER- *      */
        /*"      *                  TURAS E ASSISTENCIAS NO AQUIVO DE SAIDA.      *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.02       *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 01 - CAD 80.884                                       *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTE DEVIDO A LOCK NA TABELAS CAP.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/07/2012 - CASSIANO (COREON)                            *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.01        *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RVA4437B { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RVA4437B
        {
            get
            {
                _.Move(RVA4437B_RECORD, _RVA4437B); VarBasis.RedefinePassValue(RVA4437B_RECORD, _RVA4437B, RVA4437B_RECORD); return _RVA4437B;
            }
        }
        public FileBasis _RVA4437I { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RVA4437I
        {
            get
            {
                _.Move(RVA4437I_RECORD, _RVA4437I); VarBasis.RedefinePassValue(RVA4437I_RECORD, _RVA4437I, RVA4437I_RECORD); return _RVA4437I;
            }
        }
        public FileBasis _RVA4437P { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RVA4437P
        {
            get
            {
                _.Move(RVA4437P_RECORD, _RVA4437P); VarBasis.RedefinePassValue(RVA4437P_RECORD, _RVA4437P, RVA4437P_RECORD); return _RVA4437P;
            }
        }
        public FileBasis _RVA4437H { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RVA4437H
        {
            get
            {
                _.Move(RVA4437H_RECORD, _RVA4437H); VarBasis.RedefinePassValue(RVA4437H_RECORD, _RVA4437H, RVA4437H_RECORD); return _RVA4437H;
            }
        }
        public SortBasis<VA4437B_REG_SVA4437B> SVA4437B { get; set; } = new SortBasis<VA4437B_REG_SVA4437B>(new VA4437B_REG_SVA4437B());
        /*"01                RVA4437B-RECORD     PIC X(4500).*/
        public StringBasis RVA4437B_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01                RVA4437I-RECORD     PIC X(4500).*/
        public StringBasis RVA4437I_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01                RVA4437P-RECORD     PIC X(4500).*/
        public StringBasis RVA4437P_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01                RVA4437H-RECORD     PIC X(4500).*/
        public StringBasis RVA4437H_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01                REG-SVA4437B.*/
        public VA4437B_REG_SVA4437B REG_SVA4437B { get; set; } = new VA4437B_REG_SVA4437B();
        public class VA4437B_REG_SVA4437B : VarBasis
        {
            /*"    05            SVA-CEP-G           PIC 9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05            SVA-NUM-CEP.*/
            public VA4437B_SVA_NUM_CEP SVA_NUM_CEP { get; set; } = new VA4437B_SVA_NUM_CEP();
            public class VA4437B_SVA_NUM_CEP : VarBasis
            {
                /*"      07          SVA-CEP             PIC 9(005).*/
                public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      07          SVA-CEP-COMPL       PIC 9(003).*/
                public IntBasis SVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05            SVA-CPF             PIC 9(011).*/
            }
            public IntBasis SVA_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"    05            SVA-NRCERTIF        PIC 9(015).*/
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            SVA-TIPOSEGU        PIC X(001).*/
            public StringBasis SVA_TIPOSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-NRAPOLICE       PIC 9(013).*/
            public IntBasis SVA_NRAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05            SVA-CODSUBES        PIC 9(004).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-CODUSU          PIC X(008).*/
            public StringBasis SVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05            SVA-RAMO            PIC 9(004).*/
            public IntBasis SVA_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-CODRELAT        PIC X(006).*/
            public StringBasis SVA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"    05            SVA-CODRELATVG      PIC X(008).*/
            public StringBasis SVA_CODRELATVG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05            SVA-NUM-ITEM        PIC 9(009).*/
            public IntBasis SVA_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            SVA-CODCLIEN        PIC 9(009).*/
            public IntBasis SVA_CODCLIEN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            SVA-OCORHIST        PIC 9(004).*/
            public IntBasis SVA_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-DTINIVIG        PIC X(010).*/
            public StringBasis SVA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            SVA-DTMOVTO         PIC X(010).*/
            public StringBasis SVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            SVA-CODOPER         PIC 9(004).*/
            public IntBasis SVA_CODOPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-IDFORM          PIC X(002).*/
            public StringBasis SVA_IDFORM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05            SVA-IMPSEGCDG       PIC 9(013)V99.*/
            public DoubleBasis SVA_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05            SVA-VLPREMIO        PIC 9(013)V99.*/
            public DoubleBasis SVA_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05            SVA-OPCAOPAG        PIC X(001).*/
            public StringBasis SVA_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-AGECTADEB       PIC 9(004).*/
            public IntBasis SVA_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-OPRCTADEB       PIC 9(004).*/
            public IntBasis SVA_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-NUMCTADEB       PIC 9(012).*/
            public IntBasis SVA_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05            SVA-DIGCTADEB       PIC 9(001).*/
            public IntBasis SVA_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05            SVA-DIA-DEBITO      PIC 9(002).*/
            public IntBasis SVA_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            SVA-PLANO           PIC 9(004).*/
            public IntBasis SVA_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-ENDERECO        PIC X(072).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05            SVA-BAIRRO          PIC X(072).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05            SVA-CIDADE          PIC X(072).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05            SVA-UF              PIC X(002).*/
            public StringBasis SVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05            SVA-NOME-RAZAO      PIC X(040).*/
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05            SVA-IDSEXO          PIC X(001).*/
            public StringBasis SVA_IDSEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-NOME-CORREIO    PIC X(046).*/
            public StringBasis SVA_NOME_CORREIO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"    05            SVA-SITSEG          PIC X(001).*/
            public StringBasis SVA_SITSEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-SITPROP         PIC X(001).*/
            public StringBasis SVA_SITPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-FONTE           PIC 9(004).*/
            public IntBasis SVA_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-PERI-PAGAMENTO  PIC 9(004).*/
            public IntBasis SVA_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-DTTERVIG        PIC X(010).*/
            public StringBasis SVA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            SVA-IND-VIGENCIA    PIC X(001).*/
            public StringBasis SVA_IND_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-PRODUTO         PIC 9(004).*/
            public IntBasis SVA_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-DTQUIT          PIC X(010).*/
            public StringBasis SVA_DTQUIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            SVA-EMAIL           PIC X(040).*/
            public StringBasis SVA_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05            SVA-NUM-PLANO       PIC 9(003).*/
            public IntBasis SVA_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05            SVA-RENDA-IND       PIC 9(002).*/
            public IntBasis SVA_RENDA_IND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            SVA-RENDA-FAM       PIC 9(002).*/
            public IntBasis SVA_RENDA_FAM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            SVA-OPCAO-PAG       PIC X(001).*/
            public StringBasis SVA_OPCAO_PAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-DTNASC          PIC X(010).*/
            public StringBasis SVA_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            SVA-NRSORTE  OCCURS 5 TIMES PIC 9(009).*/
            public ListBasis<IntBasis, Int64> SVA_NRSORTE { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "9", "9(009)."), 5);
            /*"    05            SVA-COD-SUSEP       PIC X(025).*/
            public StringBasis SVA_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"    05            SVA-COD-SUSEPCAP    PIC X(025).*/
            public StringBasis SVA_COD_SUSEPCAP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"    05            SVA-COD-EMPRESA     PIC 9(004).*/
            public IntBasis SVA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            SVA-DESCR-PRODUTO   PIC X(040).*/
            public StringBasis SVA_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05         SVA-NUM-PROCESSO-SUSEP PIC X(025).*/
            public StringBasis SVA_NUM_PROCESSO_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WHOST-DATA-TERVIG-PREMIO       PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIG_PREMIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  W77-MES                        PIC  9(002).*/
        public IntBasis W77_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"77  WED-SEQ                        PIC  9(007).*/
        public IntBasis WED_SEQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
        /*"77  WS-CONTROLE                    PIC  9(001)  VALUE ZEROS.*/
        public IntBasis WS_CONTROLE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"77  ENDOSSOS-DATA-TERVIGENCIA-1    PIC  X(010).*/
        public StringBasis ENDOSSOS_DATA_TERVIGENCIA_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-1     PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-15D   PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_15D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WINDC                          PIC S9(004)   COMP.*/
        public IntBasis WINDC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WPI                            PIC S9(004)   COMP.*/
        public IntBasis WPI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  I1                             PIC S9(004)   COMP.*/
        public IntBasis I1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  I2                             PIC S9(004)   COMP.*/
        public IntBasis I2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HOST-COUNT1                    PIC S9(004)   COMP.*/
        public IntBasis HOST_COUNT1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  FCPROSUS-COD-PROCESSO-SUSEP    PIC  X(025).*/
        public StringBasis FCPROSUS_COD_PROCESSO_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"77  FCPROSUS-NUM-PLANO             PIC S9(004) USAGE COMP.*/
        public IntBasis FCPROSUS_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  W-EXISTE-TIPO-CORRECAO         PIC  X(001)  VALUE 'N'.*/
        public StringBasis W_EXISTE_TIPO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  W-GRAVA-ARQUIVO                PIC  X(012) VALUE SPACES.*/
        public StringBasis W_GRAVA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
        /*"77  FILLER                         PIC X(001) VALUE SPACES.*/

        public SelectorBasis FILLER_0 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88  W88-IMPRESS-RVA4437B-CIF-OK             VALUE '0'. */
							new SelectorItemBasis("W88_IMPRESS_RVA4437B_CIF_OK", "0"),
							/*" 88  W88-IMPRESS-RVA4437B-CIF-NOK            VALUE '1'. */
							new SelectorItemBasis("W88_IMPRESS_RVA4437B_CIF_NOK", "1"),
							/*" 88  W88-IMPRESS-RVA4437I-IMP-OK             VALUE '0'. */
							new SelectorItemBasis("W88_IMPRESS_RVA4437I_IMP_OK", "0"),
							/*" 88  W88-IMPRESS-RVA4437I-IMP-NOK            VALUE '1'. */
							new SelectorItemBasis("W88_IMPRESS_RVA4437I_IMP_NOK", "1"),
							/*" 88  W88-IMPRESS-RVA4437P-PDF-OK             VALUE '0'. */
							new SelectorItemBasis("W88_IMPRESS_RVA4437P_PDF_OK", "0"),
							/*" 88  W88-IMPRESS-RVA4437P-PDF-NOK            VALUE '1'. */
							new SelectorItemBasis("W88_IMPRESS_RVA4437P_PDF_NOK", "1"),
							/*" 88  W88-IMPRESS-RVA4437H-HTML-OK            VALUE '0'. */
							new SelectorItemBasis("W88_IMPRESS_RVA4437H_HTML_OK", "0"),
							/*" 88  W88-IMPRESS-RVA4437H-HTML-NOK           VALUE '1'. */
							new SelectorItemBasis("W88_IMPRESS_RVA4437H_HTML_NOK", "1")
                }
        };

        /*"77  FILLER                         PIC X(001) VALUE SPACES.*/

        public SelectorBasis FILLER_1 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88  W88-IMPR-CTR-RVA4437B-CIF-OK        VALUE '0'. */
							new SelectorItemBasis("W88_IMPR_CTR_RVA4437B_CIF_OK", "0"),
							/*" 88  W88-IMPR-CTR-RVA4437B-CIF-NOK       VALUE '1'. */
							new SelectorItemBasis("W88_IMPR_CTR_RVA4437B_CIF_NOK", "1"),
							/*" 88  W88-IMPR-CTR-RVA4437I-IMP-OK        VALUE '0'. */
							new SelectorItemBasis("W88_IMPR_CTR_RVA4437I_IMP_OK", "0"),
							/*" 88  W88-IMPR-CTR-RVA4437I-IMP-NOK       VALUE '1'. */
							new SelectorItemBasis("W88_IMPR_CTR_RVA4437I_IMP_NOK", "1"),
							/*" 88  W88-IMPR-CTR-RVA4437P-PDF-OK        VALUE '0'. */
							new SelectorItemBasis("W88_IMPR_CTR_RVA4437P_PDF_OK", "0"),
							/*" 88  W88-IMPR-CTR-RVA4437P-PDF-NOK       VALUE '1'. */
							new SelectorItemBasis("W88_IMPR_CTR_RVA4437P_PDF_NOK", "1"),
							/*" 88  W88-IMPR-CTR-RVA4437H-HTML-OK       VALUE '0'. */
							new SelectorItemBasis("W88_IMPR_CTR_RVA4437H_HTML_OK", "0"),
							/*" 88  W88-IMPR-CTR-RVA4437H-HTML-NOK      VALUE '1'. */
							new SelectorItemBasis("W88_IMPR_CTR_RVA4437H_HTML_NOK", "1")
                }
        };

        /*"77  W88-PRODUTO-VIDA               PIC 9(004) VALUE ZEROS.*/
        public IntBasis W88_PRODUTO_VIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77    VIND-CODPRODUTO     PIC S9(004)    COMP VALUE  0.*/
        public IntBasis VIND_CODPRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODMOEDA-I     PIC S9(004) COMP VALUE -1.*/
        public IntBasis VIND_CODMOEDA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77    VIND-NRCOPIAS       PIC S9(004) COMP VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77    VIND-AGECTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-OPRCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DIGCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-QTMDIT         PIC S9(004) COMP.*/
        public IntBasis VIND_QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SEXO           PIC S9(004) COMP.*/
        public IntBasis VIND_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RENDA-IND      PIC S9(004) COMP.*/
        public IntBasis VIND_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RENDA-FAM      PIC S9(004) COMP.*/
        public IntBasis VIND_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTNASC         PIC S9(004) COMP.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                WS-DUPLICADO        PIC S9(004) COMP.*/
        public IntBasis WS_DUPLICADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                WS-COBERTURA        PIC  X(065).*/
        public StringBasis WS_COBERTURA { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
        /*"77                W77-IND             PIC 9(005)    VALUE ZEROS.*/
        public IntBasis W77_IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77                WS-CERTIFICADO-ATU  PIC S9(15) COMP-3 VALUE +0*/
        public IntBasis WS_CERTIFICADO_ATU { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77                WS-CERTIFICADO-ANT  PIC S9(15) COMP-3 VALUE +0*/
        public IntBasis WS_CERTIFICADO_ANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77                WS-RETURN-CODE      PIC S9(04).*/
        public IntBasis WS_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)."));
        /*"77                WS-RETURN-CODE-M    PIC ----9.*/
        public IntBasis WS_RETURN_CODE_M { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
        /*"77                WS-PCTCONJUGE       PIC 9(003)V99 VALUE ZEROS.*/
        public DoubleBasis WS_PCTCONJUGE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
        /*"77                WS-IMPCONJUGE       PIC S9(013)V99 COMP-3                                                  VALUE +0.*/
        public DoubleBasis WS_IMPCONJUGE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77                WHOST-TIPOSEGU      PIC  X(001).*/
        public StringBasis WHOST_TIPOSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77                WHOST-NRCERTIF      PIC S9(015) COMP-3                                                  VALUE +0.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77                WHOST-NRAPOLICE     PIC S9(013) COMP-3                                                  VALUE +0.*/
        public IntBasis WHOST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77                WHOST-CODUSU        PIC  X(008).*/
        public StringBasis WHOST_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77                WHOST-CODSUBES      PIC S9(004) COMP VALUE +0.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                WHOST-CODOPER       PIC S9(004) COMP VALUE +0.*/
        public IntBasis WHOST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                WHOST-CODRELAT      PIC  X(008) VALUE SPACES.*/
        public StringBasis WHOST_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77                WHOST-CODCLIEN      PIC S9(009) COMP VALUE +0.*/
        public IntBasis WHOST_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77                WHOST-VALDIT        PIC S9(013)V99 COMP-3                                                  VALUE +0.*/
        public DoubleBasis WHOST_VALDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77                WHOST-CODENDER      PIC S9(004) COMP VALUE +0.*/
        public IntBasis WHOST_CODENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                V1SIST-MESREFER     PIC S9(004) COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                V1SIST-ANOREFER     PIC S9(004) COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                WS-IMP-ADIANT-CDG                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_IMP_ADIANT_CDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                WS-IMP-SEGURADA-AP                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_IMP_SEGURADA_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                WS-IMP-SEGURADA-DIT                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_IMP_SEGURADA_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-VG                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-AP                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-IP                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_IP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-IPA                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_IPA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-AMDS                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-DH                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-DIT                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-PRM-TARIFARIO-VG                                      PIC S9(10)V9(5) COMP-3.*/
        public DoubleBasis APOLICOB_PRM_TARIFARIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77                APOLICOB-PRM-TARIFARIO-AP                                      PIC S9(10)V9(5) COMP-3.*/
        public DoubleBasis APOLICOB_PRM_TARIFARIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77                WS-COD-PRODUTO      PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-FORM-LINHA                    PIC  X(023) VALUE SPACES.*/
        public StringBasis WS_FORM_LINHA { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
        /*"01  AREA-DE-WORK.*/
        public VA4437B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA4437B_AREA_DE_WORK();
        public class VA4437B_AREA_DE_WORK : VarBasis
        {
            /*"    05            WS-SIT-PRODUTO    PIC  9(001)  VALUE 0.*/

            public SelectorBasis WS_SIT_PRODUTO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88          WS-PROD-RUNON                  VALUE 1. */
							new SelectorItemBasis("WS_PROD_RUNON", "1"),
							/*" 88          WS-PROD-RUNOFF                 VALUE 2. */
							new SelectorItemBasis("WS_PROD_RUNOFF", "2")
                }
            };

            /*"    05            WS-DTNASC         PIC X(010).*/
            public StringBasis WS_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            WS-DTNASC-R       REDEFINES                  WS-DTNASC.*/
            private _REDEF_VA4437B_WS_DTNASC_R _ws_dtnasc_r { get; set; }
            public _REDEF_VA4437B_WS_DTNASC_R WS_DTNASC_R
            {
                get { _ws_dtnasc_r = new _REDEF_VA4437B_WS_DTNASC_R(); _.Move(WS_DTNASC, _ws_dtnasc_r); VarBasis.RedefinePassValue(WS_DTNASC, _ws_dtnasc_r, WS_DTNASC); _ws_dtnasc_r.ValueChanged += () => { _.Move(_ws_dtnasc_r, WS_DTNASC); }; return _ws_dtnasc_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dtnasc_r, WS_DTNASC); }
            }  //Redefines
            public class _REDEF_VA4437B_WS_DTNASC_R : VarBasis
            {
                /*"     10           WS-ANO-DTNASC     PIC 9(004).*/
                public IntBasis WS_ANO_DTNASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-MES-DTNASC     PIC 9(002).*/
                public IntBasis WS_MES_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-DIA-DTNASC     PIC 9(002).*/
                public IntBasis WS_DIA_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WS-DTMOVABE       PIC X(010).*/

                public _REDEF_VA4437B_WS_DTNASC_R()
                {
                    WS_ANO_DTNASC.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_MES_DTNASC.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WS_DIA_DTNASC.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            WS-DTMOVABE-R     REDEFINES                  WS-DTMOVABE.*/
            private _REDEF_VA4437B_WS_DTMOVABE_R _ws_dtmovabe_r { get; set; }
            public _REDEF_VA4437B_WS_DTMOVABE_R WS_DTMOVABE_R
            {
                get { _ws_dtmovabe_r = new _REDEF_VA4437B_WS_DTMOVABE_R(); _.Move(WS_DTMOVABE, _ws_dtmovabe_r); VarBasis.RedefinePassValue(WS_DTMOVABE, _ws_dtmovabe_r, WS_DTMOVABE); _ws_dtmovabe_r.ValueChanged += () => { _.Move(_ws_dtmovabe_r, WS_DTMOVABE); }; return _ws_dtmovabe_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dtmovabe_r, WS_DTMOVABE); }
            }  //Redefines
            public class _REDEF_VA4437B_WS_DTMOVABE_R : VarBasis
            {
                /*"     10           WS-ANO-DTMOVABE   PIC 9(004).*/
                public IntBasis WS_ANO_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-MES-DTMOVABE   PIC 9(002).*/
                public IntBasis WS_MES_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-DIA-DTMOVABE   PIC 9(002).*/
                public IntBasis WS_DIA_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WS-IDADE          PIC 9(004).*/

                public _REDEF_VA4437B_WS_DTMOVABE_R()
                {
                    WS_ANO_DTMOVABE.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_MES_DTMOVABE.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WS_DIA_DTMOVABE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-NRTITFDCAP     PIC 9(012).*/
            public IntBasis WS_NRTITFDCAP { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05            WS-NRSORTE        PIC 9(009).*/
            public IntBasis WS_NRSORTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  WS-VALORES-AX.*/
            public VA4437B_WS_VALORES_AX WS_VALORES_AX { get; set; } = new VA4437B_WS_VALORES_AX();
            public class VA4437B_WS_VALORES_AX : VarBasis
            {
                /*"     10           WS-VALOR-9          PIC S9(11)V99.*/
                public DoubleBasis WS_VALOR_9 { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99."), 2);
                /*"     10           WS-VALOR-INT        PIC Z9.*/
                public IntBasis WS_VALOR_INT { get; set; } = new IntBasis(new PIC("9", "2", "Z9."));
                /*"     10           WS-VALOR-INT-X      PIC X(10).*/
                public StringBasis WS_VALOR_INT_X { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10           WS-VALOR            PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_VALOR { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"    05  WS-COBER-DESC                 PIC X(40).*/
            }
            public StringBasis WS_COBER_DESC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 CEP-TOTAL            PIC 9(8).*/
            public IntBasis CEP_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(8)."));
            /*"    05 CEP-LEGAL  REDEFINES CEP-TOTAL.*/
            private _REDEF_VA4437B_CEP_LEGAL _cep_legal { get; set; }
            public _REDEF_VA4437B_CEP_LEGAL CEP_LEGAL
            {
                get { _cep_legal = new _REDEF_VA4437B_CEP_LEGAL(); _.Move(CEP_TOTAL, _cep_legal); VarBasis.RedefinePassValue(CEP_TOTAL, _cep_legal, CEP_TOTAL); _cep_legal.ValueChanged += () => { _.Move(_cep_legal, CEP_TOTAL); }; return _cep_legal; }
                set { VarBasis.RedefinePassValue(value, _cep_legal, CEP_TOTAL); }
            }  //Redefines
            public class _REDEF_VA4437B_CEP_LEGAL : VarBasis
            {
                /*"      10  CEP-PARTE1      PIC 9(5).*/
                public IntBasis CEP_PARTE1 { get; set; } = new IntBasis(new PIC("9", "5", "9(5)."));
                /*"      10  CEP-PARTE2      PIC 9(3).*/
                public IntBasis CEP_PARTE2 { get; set; } = new IntBasis(new PIC("9", "3", "9(3)."));
                /*"    05            LC01-LINHA01.*/

                public _REDEF_VA4437B_CEP_LEGAL()
                {
                    CEP_PARTE1.ValueChanged += OnValueChanged;
                    CEP_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public VA4437B_LC01_LINHA01 LC01_LINHA01 { get; set; } = new VA4437B_LC01_LINHA01();
            public class VA4437B_LC01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(002) VALUE '%!'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"%!");
                /*"    05            LC08-LINHA08.*/
            }
            public VA4437B_LC08_LINHA08 LC08_LINHA08 { get; set; } = new VA4437B_LC08_LINHA08();
            public class VA4437B_LC08_LINHA08 : VarBasis
            {
                /*"      10          LC08-FILLER          PIC X(070) VALUE    '(|) SETDBSEP'.*/
                public StringBasis LC08_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"(|) SETDBSEP");
                /*"    05            LC09-LINHA09.*/
            }
            public VA4437B_LC09_LINHA09 LC09_LINHA09 { get; set; } = new VA4437B_LC09_LINHA09();
            public class VA4437B_LC09_LINHA09 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LC09-FORM.*/
                public VA4437B_LC09_FORM LC09_FORM { get; set; } = new VA4437B_LC09_FORM();
                public class VA4437B_LC09_FORM : VarBasis
                {
                    /*"        15        LC09-JDE             PIC X(008).*/
                    public StringBasis LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'DBM'.*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DBM");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            FILLER     REDEFINES LC09-LINHA09.*/
            }
            private _REDEF_VA4437B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_VA4437B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_VA4437B_FILLER_12(); _.Move(LC09_LINHA09, _filler_12); VarBasis.RedefinePassValue(LC09_LINHA09, _filler_12, LC09_LINHA09); _filler_12.ValueChanged += () => { _.Move(_filler_12, LC09_LINHA09); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, LC09_LINHA09); }
            }  //Redefines
            public class _REDEF_VA4437B_FILLER_12 : VarBasis
            {
                /*"      10          LC09-LIN09           PIC X(023).*/
                public StringBasis LC09_LIN09 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05            LC10-LINHA10.*/

                public _REDEF_VA4437B_FILLER_12()
                {
                    LC09_LIN09.ValueChanged += OnValueChanged;
                }

            }
            public VA4437B_LC10_LINHA10 LC10_LINHA10 { get; set; } = new VA4437B_LC10_LINHA10();
            public class VA4437B_LC10_LINHA10 : VarBasis
            {
                /*"      10         FILLER              PIC X(051) VALUE     'ESTIPULANTE|APOLICE|NUM-CERTIF|DT-VIG|SEGURADO|CPF|'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ESTIPULANTE|APOLICE|NUM_CERTIF|DT_VIG|SEGURADO|CPF|");
                /*"      10         FILLER              PIC X(051) VALUE     'CAPIT1|CAPIT2|CAPIT3|CAPIT4|CAPIT5|CAPIT6|CAPIT7|CA'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"CAPIT1|CAPIT2|CAPIT3|CAPIT4|CAPIT5|CAPIT6|CAPIT7|CA");
                /*"      10         FILLER              PIC X(051) VALUE     'PIT8|CAPIT9|CAPIT10|CAPIT11|CAPIT12|CAPIT13|CAPIT14'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"PIT8|CAPIT9|CAPIT10|CAPIT11|CAPIT12|CAPIT13|CAPIT14");
                /*"      10         FILLER              PIC X(051) VALUE     '|CAPIT15|CAPIT16|CAPIT17|CAPIT18|CAPIT19|CAPIT20|DT'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"|CAPIT15|CAPIT16|CAPIT17|CAPIT18|CAPIT19|CAPIT20|DT");
                /*"      10         FILLER              PIC X(014) VALUE     '-CAPIT|CONTA-D'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"_CAPIT|CONTA_D");
                /*"      10         FILLER              PIC X(051) VALUE     'EBITO|CUSTO|DIA-COB|BENEF1|PARENT1|PART1|BENEF2|PAR'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"EBITO|CUSTO|DIA_COB|BENEF1|PARENT1|PART1|BENEF2|PAR");
                /*"      10         FILLER              PIC X(051) VALUE     'ENT2|PART2|BENEF3|PARENT3|PART3|BENEF4|PARENT4|PART'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ENT2|PART2|BENEF3|PARENT3|PART3|BENEF4|PARENT4|PART");
                /*"      10         FILLER              PIC X(051) VALUE     '4|BENEF5|PARENT5|PART5|DTPOSTAGEM|NUMOBJETO|DESTINA'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"4|BENEF5|PARENT5|PART5|DTPOSTAGEM|NUMOBJETO|DESTINA");
                /*"      10         FILLER              PIC X(051) VALUE     'TARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|REMET'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"TARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|REMET");
                /*"      10         FILLER              PIC X(051) VALUE     '-ENDERECO|REMET-BAIRRO|REMET-CIDADE|REMET-UF|CODIGO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_ENDERECO|REMET_BAIRRO|REMET_CIDADE|REMET_UF|CODIGO");
                /*"      10         FILLER              PIC X(051) VALUE     '-CIF|POSTNET|REMET-CEP|N-CUSTO|DATADIA|CLIENTE|DT-V'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_CIF|POSTNET|REMET_CEP|N_CUSTO|DATADIA|CLIENTE|DT_V");
                /*"      10         FILLER              PIC X(051) VALUE     'IG1|DT-VIG2|TEXTO|EMAIL|OPCAO-PAG|IDADE|ID-SEXO|REN'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"IG1|DT_VIG2|TEXTO|EMAIL|OPCAO_PAG|IDADE|ID_SEXO|REN");
                /*"      10         FILLER              PIC X(051) VALUE     'DA-IND|RENDA-FAM|COD-PRODUTO|NOME-PRODUTO|OPCAO-CON'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"DA_IND|RENDA_FAM|COD_PRODUTO|NOME_PRODUTO|OPCAO_CON");
                /*"      10         FILLER              PIC X(051) VALUE     'JUGE|FORM-CAMP|SORTE1|SORTE2|SORTE3|SORTE4|SORTE5|D'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"JUGE|FORM_CAMP|SORTE1|SORTE2|SORTE3|SORTE4|SORTE5|D");
                /*"      10         FILLER              PIC X(031) VALUE     'AT-NASC|COD-SUSEP|COD-SUSEPCAP|'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"AT_NASC|COD_SUSEP|COD_SUSEPCAP|");
                /*"      10         FILLER              PIC X(051) VALUE     'SEGURADO-SOCIAL|DESTINATARIO-SOCIAL|CLIENTE-SOCIAL|'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"SEGURADO_SOCIAL|DESTINATARIO_SOCIAL|CLIENTE_SOCIAL|");
                /*"    05            LC11-LINHA11.*/
            }
            public VA4437B_LC11_LINHA11 LC11_LINHA11 { get; set; } = new VA4437B_LC11_LINHA11();
            public class VA4437B_LC11_LINHA11 : VarBasis
            {
                /*"       10         LC11-ESTIPULANTE    PIC X(040).*/
                public StringBasis LC11_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-APOLICE        PIC ZZZZZZZZZZZZZ.*/
                public StringBasis LC11_APOLICE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NRCERTIF       PIC ZZZZZZZZZZZZZZZ.*/
                public StringBasis LC11_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-DVCERTIF       PIC 9(001).*/
                public IntBasis LC11_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTINIVIG       PIC X(010).*/
                public StringBasis LC11_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO     PIC X(040).*/
                public StringBasis LC11_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NRCPF          PIC 999.999.999.*/
                public IntBasis LC11_NRCPF { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-DVCPF          PIC 9(002).*/
                public IntBasis LC11_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COBERTURAS.*/
                public VA4437B_LC11_COBERTURAS LC11_COBERTURAS { get; set; } = new VA4437B_LC11_COBERTURAS();
                public class VA4437B_LC11_COBERTURAS : VarBasis
                {
                    /*"         15       LC11-COBER-OCC OCCURS 20 TIMES.*/
                    public ListBasis<VA4437B_LC11_COBER_OCC> LC11_COBER_OCC { get; set; } = new ListBasis<VA4437B_LC11_COBER_OCC>(20);
                    public class VA4437B_LC11_COBER_OCC : VarBasis
                    {
                        /*"           20     LC11-STRING1        PIC X(065) VALUE SPACES.*/
                        public StringBasis LC11_STRING1 { get; set; } = new StringBasis(new PIC("X", "65", "X(065)"), @"");
                        /*"           20     LC11-VALORA         PIC X(013).*/
                        public StringBasis LC11_VALORA { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                        /*"           20     LC11-DELIMIT-00     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_00 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         LC11-DTALTCAP       PIC X(010).*/
                    }
                }
                public StringBasis LC11_DTALTCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-OPCAOPAG       PIC X(030) VALUE SPACES.*/
                public StringBasis LC11_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"       10         LC11-OPCAOPAG-R     REDEFINES                  LC11-OPCAOPAG.*/
                private _REDEF_VA4437B_LC11_OPCAOPAG_R _lc11_opcaopag_r { get; set; }
                public _REDEF_VA4437B_LC11_OPCAOPAG_R LC11_OPCAOPAG_R
                {
                    get { _lc11_opcaopag_r = new _REDEF_VA4437B_LC11_OPCAOPAG_R(); _.Move(LC11_OPCAOPAG, _lc11_opcaopag_r); VarBasis.RedefinePassValue(LC11_OPCAOPAG, _lc11_opcaopag_r, LC11_OPCAOPAG); _lc11_opcaopag_r.ValueChanged += () => { _.Move(_lc11_opcaopag_r, LC11_OPCAOPAG); }; return _lc11_opcaopag_r; }
                    set { VarBasis.RedefinePassValue(value, _lc11_opcaopag_r, LC11_OPCAOPAG); }
                }  //Redefines
                public class _REDEF_VA4437B_LC11_OPCAOPAG_R : VarBasis
                {
                    /*"         15       LC11-AGECTADEB      PIC 9(004).*/
                    public IntBasis LC11_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"         15       LC11-PONTO1         PIC X(001).*/
                    public StringBasis LC11_PONTO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15       LC11-OPRCTADEB      PIC 9(004).*/
                    public IntBasis LC11_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"         15       LC11-PONTO2         PIC X(001).*/
                    public StringBasis LC11_PONTO2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15       LC11-NUMCTADEB      PIC 9(012).*/
                    public IntBasis LC11_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"         15       LC11-TRACO          PIC X(001).*/
                    public StringBasis LC11_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15       LC11-DIGCTADEB      PIC 9(001).*/
                    public IntBasis LC11_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"         15       LC11-FILLER         PIC X(006).*/
                    public StringBasis LC11_FILLER { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                    public _REDEF_VA4437B_LC11_OPCAOPAG_R()
                    {
                        LC11_AGECTADEB.ValueChanged += OnValueChanged;
                        LC11_PONTO1.ValueChanged += OnValueChanged;
                        LC11_OPRCTADEB.ValueChanged += OnValueChanged;
                        LC11_PONTO2.ValueChanged += OnValueChanged;
                        LC11_NUMCTADEB.ValueChanged += OnValueChanged;
                        LC11_TRACO.ValueChanged += OnValueChanged;
                        LC11_DIGCTADEB.ValueChanged += OnValueChanged;
                        LC11_FILLER.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NCUSTO1        PIC X(015) VALUE SPACES.*/
                public StringBasis LC11_NCUSTO1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"       10         LC11-VLPREMIO       PIC ZZZZZ9,99.*/
                public DoubleBasis LC11_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DIA-DEB        PIC 9(002).*/
                public IntBasis LC11_DIA_DEB { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         LC11-DIA-DEB-R REDEFINES LC11-DIA-DEB.*/
                private _REDEF_VA4437B_LC11_DIA_DEB_R _lc11_dia_deb_r { get; set; }
                public _REDEF_VA4437B_LC11_DIA_DEB_R LC11_DIA_DEB_R
                {
                    get { _lc11_dia_deb_r = new _REDEF_VA4437B_LC11_DIA_DEB_R(); _.Move(LC11_DIA_DEB, _lc11_dia_deb_r); VarBasis.RedefinePassValue(LC11_DIA_DEB, _lc11_dia_deb_r, LC11_DIA_DEB); _lc11_dia_deb_r.ValueChanged += () => { _.Move(_lc11_dia_deb_r, LC11_DIA_DEB); }; return _lc11_dia_deb_r; }
                    set { VarBasis.RedefinePassValue(value, _lc11_dia_deb_r, LC11_DIA_DEB); }
                }  //Redefines
                public class _REDEF_VA4437B_LC11_DIA_DEB_R : VarBasis
                {
                    /*"         15       LC11-DIA-DEB-ALFA   PIC X(002).*/
                    public StringBasis LC11_DIA_DEB_ALFA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                    public _REDEF_VA4437B_LC11_DIA_DEB_R()
                    {
                        LC11_DIA_DEB_ALFA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BENEFICIARIOS.*/
                public VA4437B_LC11_BENEFICIARIOS LC11_BENEFICIARIOS { get; set; } = new VA4437B_LC11_BENEFICIARIOS();
                public class VA4437B_LC11_BENEFICIARIOS : VarBasis
                {
                    /*"         15       LC11-BENEF-OCC OCCURS 5 TIMES.*/
                    public ListBasis<VA4437B_LC11_BENEF_OCC> LC11_BENEF_OCC { get; set; } = new ListBasis<VA4437B_LC11_BENEF_OCC>(5);
                    public class VA4437B_LC11_BENEF_OCC : VarBasis
                    {
                        /*"           20     LC11-NOME-BENEF     PIC X(040).*/
                        public StringBasis LC11_NOME_BENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                        /*"           20     LC11-DELIMIT-01     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"           20     LC11-PARENTESCO     PIC X(020).*/
                        public StringBasis LC11_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                        /*"           20     LC11-DELIMIT-02     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"           20     LC11-PARTICIP-X     PIC X(006).*/
                        public StringBasis LC11_PARTICIP_X { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                        /*"           20     LC11-PARTICIP       REDEFINES                  LC11-PARTICIP-X     PIC ZZ9,99.*/
                        private _REDEF_DoubleBasis _lc11_particip { get; set; }
                        public _REDEF_DoubleBasis LC11_PARTICIP
                        {
                            get { _lc11_particip = new _REDEF_DoubleBasis(new PIC("9", "ZZ9,99", "ZZ9V99."), 2); ; _.Move(LC11_PARTICIP_X, _lc11_particip); VarBasis.RedefinePassValue(LC11_PARTICIP_X, _lc11_particip, LC11_PARTICIP_X); _lc11_particip.ValueChanged += () => { _.Move(_lc11_particip, LC11_PARTICIP_X); }; return _lc11_particip; }
                            set { VarBasis.RedefinePassValue(value, _lc11_particip, LC11_PARTICIP_X); }
                        }  //Redefines
                        /*"           20     LC11-DELIMIT-03     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         LC11-DTPOSTAGEM     PIC X(010).*/
                    }
                }
                public StringBasis LC11_DTPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-SEQUENCIA      PIC X(007).*/
                public StringBasis LC11_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-END PIC X(040).*/
                public StringBasis LC11_NOME_RAZAO_END { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO       PIC X(072).*/
                public StringBasis LC11_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BAIRRO         PIC X(072).*/
                public StringBasis LC11_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE         PIC X(072).*/
                public StringBasis LC11_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF             PIC X(002).*/
                public StringBasis LC11_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP            PIC 99999.*/
                public IntBasis LC11_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP-COMPL      PIC 999.*/
                public IntBasis LC11_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         FILLER              PIC X(014) VALUE                 'CAIXA SEGUROS'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CAIXA SEGUROS");
                /*"       10         LC11-REMETENTE-G.*/
                public VA4437B_LC11_REMETENTE_G LC11_REMETENTE_G { get; set; } = new VA4437B_LC11_REMETENTE_G();
                public class VA4437B_LC11_REMETENTE_G : VarBasis
                {
                    /*"         15       LC11-REMETENTE-S    PIC X(007).*/
                    public StringBasis LC11_REMETENTE_S { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"         15       LC11-REMETENTE      PIC X(024).*/
                    public StringBasis LC11_REMETENTE { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                }
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO-REM   PIC X(040).*/
                public StringBasis LC11_ENDERECO_REM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BAIRRO-REM     PIC X(020).*/
                public StringBasis LC11_BAIRRO_REM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE-REM     PIC X(020).*/
                public StringBasis LC11_CIDADE_REM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF-REM         PIC X(002).*/
                public StringBasis LC11_UF_REM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         CODIGO-CIF          PIC X(034) VALUE ALL '@'.*/
                public StringBasis CODIGO_CIF { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"ALL");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         POSTNET             PIC X(011) VALUE ALL '#'.*/
                public StringBasis POSTNET { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"ALL");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP-REM        PIC 99999.*/
                public IntBasis LC11_CEP_REM { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP-COMPL-REM  PIC 999.*/
                public IntBasis LC11_CEP_COMPL_REM { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NCUSTO         PIC X(015) VALUE SPACES.*/
                public StringBasis LC11_NCUSTO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DATADIA        PIC X(010) VALUE SPACES.*/
                public StringBasis LC11_DATADIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CLIENTE        PIC X(090) VALUE SPACES.*/
                public StringBasis LC11_CLIENTE { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTVIG-PRIN     PIC X(060) VALUE SPACES.*/
                public StringBasis LC11_DTVIG_PRIN { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTVIG-DEPE     PIC X(060) VALUE SPACES.*/
                public StringBasis LC11_DTVIG_DEPE { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-TEXTO          PIC X(090) VALUE SPACES.*/
                public StringBasis LC11_TEXTO { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-EMAIL          PIC X(050) VALUE SPACES.*/
                public StringBasis LC11_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-OPCAO-PAG      PIC X(025) VALUE SPACES.*/
                public StringBasis LC11_OPCAO_PAG { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-IDADE          PIC 9(003) VALUE ZEROS.*/
                public IntBasis LC11_IDADE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-SEXO           PIC X(001) VALUE SPACES.*/
                public StringBasis LC11_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-RENDA-IND      PIC 9(002) VALUE ZEROS.*/
                public IntBasis LC11_RENDA_IND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-RENDA-FAM      PIC X(002) VALUE ZEROS.*/
                public StringBasis LC11_RENDA_FAM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COD-PRODUTO    PIC 9(004) VALUE ZEROS.*/
                public IntBasis LC11_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-PRODUTO   PIC X(030) VALUE SPACES.*/
                public StringBasis LC11_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-OPCAO-CONJ     PIC X(015) VALUE SPACES.*/
                public StringBasis LC11_OPCAO_CONJ { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-FORM-CAMP      PIC X(050) VALUE SPACES.*/
                public StringBasis LC11_FORM_CAMP { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-SORTE.*/
                public VA4437B_LC11_SORTE LC11_SORTE { get; set; } = new VA4437B_LC11_SORTE();
                public class VA4437B_LC11_SORTE : VarBasis
                {
                    /*"         15       LC11-SORTE1         OCCURS 5 TIMES.*/
                    public ListBasis<VA4437B_LC11_SORTE1> LC11_SORTE1 { get; set; } = new ListBasis<VA4437B_LC11_SORTE1>(5);
                    public class VA4437B_LC11_SORTE1 : VarBasis
                    {
                        /*"           20     LC11-NRSORTE        PIC X(009) VALUE SPACES.*/
                        public StringBasis LC11_NRSORTE { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                        /*"           20     LC11-NRSORTE-S      PIC X(001).*/
                        public StringBasis LC11_NRSORTE_S { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         LC11-SORTE-R        REDEFINES                  LC11-SORTE          PIC X(050).*/
                    }
                }
                private _REDEF_StringBasis _lc11_sorte_r { get; set; }
                public _REDEF_StringBasis LC11_SORTE_R
                {
                    get { _lc11_sorte_r = new _REDEF_StringBasis(new PIC("X", "050", "X(050).")); ; _.Move(LC11_SORTE, _lc11_sorte_r); VarBasis.RedefinePassValue(LC11_SORTE, _lc11_sorte_r, LC11_SORTE); _lc11_sorte_r.ValueChanged += () => { _.Move(_lc11_sorte_r, LC11_SORTE); }; return _lc11_sorte_r; }
                    set { VarBasis.RedefinePassValue(value, _lc11_sorte_r, LC11_SORTE); }
                }  //Redefines
                /*"       10         LC11-DAT-NASC       PIC X(010) VALUE SPACES.*/
                public StringBasis LC11_DAT_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COD-SUSEP      PIC X(025) VALUE SPACES.*/
                public StringBasis LC11_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COD-SUSEPCAP   PIC X(025) VALUE SPACES.*/
                public StringBasis LC11_COD_SUSEPCAP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-SOC PIC X(100).*/
                public StringBasis LC11_NOME_RAZAO_SOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-END-SOC PIC X(100).*/
                public StringBasis LC11_NOME_RAZAO_END_SOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CLIENTE-SOC    PIC X(100) VALUE SPACES.*/
                public StringBasis LC11_CLIENTE_SOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05            LC12-LINHA12.*/
            }
            public VA4437B_LC12_LINHA12 LC12_LINHA12 { get; set; } = new VA4437B_LC12_LINHA12();
            public class VA4437B_LC12_LINHA12 : VarBasis
            {
                /*"      10          LC12-FILLER          PIC X(005) VALUE    '%%EOF'.*/
                public StringBasis LC12_FILLER { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"%%EOF");
                /*"    05            AC-LINHAS           PIC 9(002) VALUE 80.*/
            }
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"    05            AC-PAGINA           PIC 9(003) VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05            WS-CAR-CONJUGE      PIC 9(003)V99                                                 VALUE ZEROS.*/
            public DoubleBasis WS_CAR_CONJUGE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
            /*"    05            AC-CONTA1           PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_CONTA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-QUOCIENTE        PIC 9(009) VALUE ZEROS.*/
            public IntBasis WS_QUOCIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05            WS-RESTO            PIC 9(009) VALUE ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05            WS-OCORR            PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_OCORR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-SEQ              PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-ED-SEQ           PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_ED_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-QTD-OBJ          PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-CONTR-OBJ        PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_CONTR_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-CONTR-200        PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_CONTR_200 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-CONTR-PRODU      PIC X(001).*/
            public StringBasis WS_CONTR_PRODU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            WS-NUM-APOLICE-ANT  PIC 9(013).*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05            WS-CODSUBES-ANT     PIC 9(004).*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-JDE-ANT          PIC X(023) VALUE ALL '*'.*/
            public StringBasis WS_JDE_ANT { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"ALL");
            /*"    05            WS-LC09-JDE         PIC X(008).*/
            public StringBasis WS_LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05            WS-OPER-ANT         PIC 9(004).*/
            public IntBasis WS_OPER_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-CEP-G-ANT        PIC 9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05            WS-NOME-COR-ANT.*/
            public VA4437B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new VA4437B_WS_NOME_COR_ANT();
            public class VA4437B_WS_NOME_COR_ANT : VarBasis
            {
                /*"      10          WS-FAIXA1-ANT       PIC 9(008).*/
                public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          WS-FAIXA2-ANT       PIC 9(008).*/
                public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          WS-NOME-ANT         PIC X(072).*/
                public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05            WS-FIM-SORT         PIC  X(001) VALUE ' '.*/
            }
            public StringBasis WS_FIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05            WS-GRAVA-ARQ        PIC  9(006) VALUE 0.*/
            public IntBasis WS_GRAVA_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-REJEITA-SORT     PIC  9(006) VALUE 0.*/
            public IntBasis WS_REJEITA_SORT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-LIDOS-ARQ        PIC  9(006) VALUE 0.*/
            public IntBasis WS_LIDOS_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-GRAVA-SORT       PIC  9(006) VALUE 0.*/
            public IntBasis WS_GRAVA_SORT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-IND1             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WS-IND2             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WS-SALVA-CERTIF     PIC  9(015) COMP-3                                                  VALUE  0.*/
            public IntBasis WS_SALVA_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05            WS-INF              PIC 9(009).*/
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            WS-SUP              PIC 9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            WS-IND              PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND                PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-N              PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_N { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-N-S            PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_N_S { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WINDM               PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WINDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-77             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_77 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-88             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_88 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-99             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_99 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            IDX-IND1            PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis IDX_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            CONTROLA-IMP        PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis CONTROLA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            INF                 PIC S9(009) COMP                                                  VALUE +0.*/
            public IntBasis INF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05            SUP                 PIC S9(009) COMP                                                  VALUE +0.*/
            public IntBasis SUP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05            DEST-NUM-CEP.*/
            public VA4437B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new VA4437B_DEST_NUM_CEP();
            public class VA4437B_DEST_NUM_CEP : VarBasis
            {
                /*"      15          DEST-CEP            PIC 9(005) VALUE ZEROS.*/
                public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      15          DEST-CEP-COMPL      PIC 9(003) VALUE ZEROS.*/
                public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05            WS-CPF              PIC 9(015).*/
            }
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            WS-CPF-R            REDEFINES                  WS-CPF.*/
            private _REDEF_VA4437B_WS_CPF_R _ws_cpf_r { get; set; }
            public _REDEF_VA4437B_WS_CPF_R WS_CPF_R
            {
                get { _ws_cpf_r = new _REDEF_VA4437B_WS_CPF_R(); _.Move(WS_CPF, _ws_cpf_r); VarBasis.RedefinePassValue(WS_CPF, _ws_cpf_r, WS_CPF); _ws_cpf_r.ValueChanged += () => { _.Move(_ws_cpf_r, WS_CPF); }; return _ws_cpf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cpf_r, WS_CPF); }
            }  //Redefines
            public class _REDEF_VA4437B_WS_CPF_R : VarBasis
            {
                /*"      10          WS-NRCPF            PIC 9(013).*/
                public IntBasis WS_NRCPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10          WS-DVCPF            PIC 9(002).*/
                public IntBasis WS_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WS-CERTIF           PIC 9(015).*/

                public _REDEF_VA4437B_WS_CPF_R()
                {
                    WS_NRCPF.ValueChanged += OnValueChanged;
                    WS_DVCPF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            WS-CERTIF-R         REDEFINES                  WS-CERTIF.*/
            private _REDEF_VA4437B_WS_CERTIF_R _ws_certif_r { get; set; }
            public _REDEF_VA4437B_WS_CERTIF_R WS_CERTIF_R
            {
                get { _ws_certif_r = new _REDEF_VA4437B_WS_CERTIF_R(); _.Move(WS_CERTIF, _ws_certif_r); VarBasis.RedefinePassValue(WS_CERTIF, _ws_certif_r, WS_CERTIF); _ws_certif_r.ValueChanged += () => { _.Move(_ws_certif_r, WS_CERTIF); }; return _ws_certif_r; }
                set { VarBasis.RedefinePassValue(value, _ws_certif_r, WS_CERTIF); }
            }  //Redefines
            public class _REDEF_VA4437B_WS_CERTIF_R : VarBasis
            {
                /*"      10          WS-NRCERTIF         PIC 9(014).*/
                public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10          WS-DVCERTIF         PIC 9(001).*/
                public IntBasis WS_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05            WDATA1.*/

                public _REDEF_VA4437B_WS_CERTIF_R()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                    WS_DVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public VA4437B_WDATA1 WDATA1 { get; set; } = new VA4437B_WDATA1();
            public class VA4437B_WDATA1 : VarBasis
            {
                /*"      10          WDATA1-ANO          PIC 9(004) VALUE ZEROS.*/
                public IntBasis WDATA1_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WDATA1-MES          PIC 9(002) VALUE ZEROS.*/
                public IntBasis WDATA1_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WDATA1-DIA          PIC 9(002) VALUE ZEROS.*/
                public IntBasis WDATA1_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05            WS-DATA-SQL.*/
            }
            public VA4437B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VA4437B_WS_DATA_SQL();
            public class VA4437B_WS_DATA_SQL : VarBasis
            {
                /*"      10          WS-SEC-ANO          PIC 9(004) VALUE ZEROS.*/
                public IntBasis WS_SEC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10          WS-SEC-ANO-R        REDEFINES                  WS-SEC-ANO.*/
                private _REDEF_VA4437B_WS_SEC_ANO_R _ws_sec_ano_r { get; set; }
                public _REDEF_VA4437B_WS_SEC_ANO_R WS_SEC_ANO_R
                {
                    get { _ws_sec_ano_r = new _REDEF_VA4437B_WS_SEC_ANO_R(); _.Move(WS_SEC_ANO, _ws_sec_ano_r); VarBasis.RedefinePassValue(WS_SEC_ANO, _ws_sec_ano_r, WS_SEC_ANO); _ws_sec_ano_r.ValueChanged += () => { _.Move(_ws_sec_ano_r, WS_SEC_ANO); }; return _ws_sec_ano_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_sec_ano_r, WS_SEC_ANO); }
                }  //Redefines
                public class _REDEF_VA4437B_WS_SEC_ANO_R : VarBasis
                {
                    /*"        15        WS-ANO-SQL          PIC 9(004).*/
                    public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10          FILLER              PIC X(001).*/

                    public _REDEF_VA4437B_WS_SEC_ANO_R()
                    {
                        WS_ANO_SQL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-MES-SQL          PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-DIA-SQL          PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05            WS-DATA.*/
            }
            public VA4437B_WS_DATA WS_DATA { get; set; } = new VA4437B_WS_DATA();
            public class VA4437B_WS_DATA : VarBasis
            {
                /*"      10          WS-DIA              PIC 9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          WS-MES              PIC 9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          WS-ANO              PIC 9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05            WS-DATA-I.*/
            }
            public VA4437B_WS_DATA_I WS_DATA_I { get; set; } = new VA4437B_WS_DATA_I();
            public class VA4437B_WS_DATA_I : VarBasis
            {
                /*"      10          WS-DIA-I            PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLERB1            PIC X(001).*/
                public StringBasis FILLERB1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-MES-I            PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLERB2            PIC X(001).*/
                public StringBasis FILLERB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-SEC-ANO-I        PIC 9(004).*/
                public IntBasis WS_SEC_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          WS-SEC-ANO-IR       REDEFINES                  WS-SEC-ANO-I.*/
                private _REDEF_VA4437B_WS_SEC_ANO_IR _ws_sec_ano_ir { get; set; }
                public _REDEF_VA4437B_WS_SEC_ANO_IR WS_SEC_ANO_IR
                {
                    get { _ws_sec_ano_ir = new _REDEF_VA4437B_WS_SEC_ANO_IR(); _.Move(WS_SEC_ANO_I, _ws_sec_ano_ir); VarBasis.RedefinePassValue(WS_SEC_ANO_I, _ws_sec_ano_ir, WS_SEC_ANO_I); _ws_sec_ano_ir.ValueChanged += () => { _.Move(_ws_sec_ano_ir, WS_SEC_ANO_I); }; return _ws_sec_ano_ir; }
                    set { VarBasis.RedefinePassValue(value, _ws_sec_ano_ir, WS_SEC_ANO_I); }
                }  //Redefines
                public class _REDEF_VA4437B_WS_SEC_ANO_IR : VarBasis
                {
                    /*"        15        WS-ANO-I            PIC 9(004).*/
                    public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05            WS-DATA-SEG.*/

                    public _REDEF_VA4437B_WS_SEC_ANO_IR()
                    {
                        WS_ANO_I.ValueChanged += OnValueChanged;
                    }

                }
            }
            public VA4437B_WS_DATA_SEG WS_DATA_SEG { get; set; } = new VA4437B_WS_DATA_SEG();
            public class VA4437B_WS_DATA_SEG : VarBasis
            {
                /*"      10          WS-STRING1          PIC X(020) VALUE SPACES.*/
                public StringBasis WS_STRING1 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      10          WS-DTINIVIG.*/
                public VA4437B_WS_DTINIVIG WS_DTINIVIG { get; set; } = new VA4437B_WS_DTINIVIG();
                public class VA4437B_WS_DTINIVIG : VarBasis
                {
                    /*"        15        WS-DIA-INI          PIC X(002).*/
                    public StringBasis WS_DIA_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15        WS-BARRA1           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"        15        WS-MES-INI          PIC X(002).*/
                    public StringBasis WS_MES_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15        WS-BARRA2           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"        15        WS-ANO-INI          PIC X(004).*/
                    public StringBasis WS_ANO_INI { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"      10          WS-FIL-A            PIC X(003) VALUE ' A '.*/
                }
                public StringBasis WS_FIL_A { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"      10          WS-DTTERVIG.*/
                public VA4437B_WS_DTTERVIG WS_DTTERVIG { get; set; } = new VA4437B_WS_DTTERVIG();
                public class VA4437B_WS_DTTERVIG : VarBasis
                {
                    /*"        15        WS-DIA-TER          PIC X(002).*/
                    public StringBasis WS_DIA_TER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15        WS-BARRA3           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"        15        WS-MES-TER          PIC X(002).*/
                    public StringBasis WS_MES_TER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15        WS-BARRA4           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"        15        WS-ANO-TER          PIC X(004).*/
                    public StringBasis WS_ANO_TER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"      10          WS-STRING2          PIC X(003) VALUE '(*)'.*/
                }
                public StringBasis WS_STRING2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(*)");
                /*"    05            WS-DATA-INV.*/
            }
            public VA4437B_WS_DATA_INV WS_DATA_INV { get; set; } = new VA4437B_WS_DATA_INV();
            public class VA4437B_WS_DATA_INV : VarBasis
            {
                /*"      10          WS-ANO-INV          PIC 9(004).*/
                public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-MES-INV          PIC 9(002).*/
                public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-DIA-INV          PIC 9(002).*/
                public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WHORA-CURR          PIC X(008) VALUE SPACES.*/
            }
            public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05            WS-NUM-CEP-AUX      PIC 9(008).*/
            public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05            WS-NUM-CEP-AUX-R    REDEFINES                  WS-NUM-CEP-AUX.*/
            private _REDEF_VA4437B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
            public _REDEF_VA4437B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
            {
                get { _ws_num_cep_aux_r = new _REDEF_VA4437B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VA4437B_WS_NUM_CEP_AUX_R : VarBasis
            {
                /*"      10          WS-CEP-AUX          PIC 9(005).*/
                public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          WS-CEP-COMPL-AUX    PIC 9(003).*/
                public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05            WS-NUM-CEP-AUX-R1   REDEFINES                  WS-NUM-CEP-AUX.*/

                public _REDEF_VA4437B_WS_NUM_CEP_AUX_R()
                {
                    WS_CEP_AUX.ValueChanged += OnValueChanged;
                    WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA4437B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
            public _REDEF_VA4437B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
            {
                get { _ws_num_cep_aux_r1 = new _REDEF_VA4437B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VA4437B_WS_NUM_CEP_AUX_R1 : VarBasis
            {
                /*"      10          WS-CEP-COMPL-AUX1   PIC 9(003).*/
                public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          WS-CEP-AUX1         PIC 9(005).*/
                public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05        WS-JDE-GER.*/

                public _REDEF_VA4437B_WS_NUM_CEP_AUX_R1()
                {
                    WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                    WS_CEP_AUX1.ValueChanged += OnValueChanged;
                }

            }
            public VA4437B_WS_JDE_GER WS_JDE_GER { get; set; } = new VA4437B_WS_JDE_GER();
            public class VA4437B_WS_JDE_GER : VarBasis
            {
                /*"        15        WS-JDE               PIC X(008).*/
                public StringBasis WS_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    05        WS-RAMO.*/
            }
            public VA4437B_WS_RAMO WS_RAMO { get; set; } = new VA4437B_WS_RAMO();
            public class VA4437B_WS_RAMO : VarBasis
            {
                /*"      10      WS-RAMOFR                PIC 9(002).*/
                public IntBasis WS_RAMOFR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-RAMOFR-99             PIC 9(002).*/
                public IntBasis WS_RAMOFR_99 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-CHAVE            PIC  X(022).*/
            }
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
            /*"    05        WS-CHAVE-R          REDEFINES              WS-CHAVE.*/
            private _REDEF_VA4437B_WS_CHAVE_R _ws_chave_r { get; set; }
            public _REDEF_VA4437B_WS_CHAVE_R WS_CHAVE_R
            {
                get { _ws_chave_r = new _REDEF_VA4437B_WS_CHAVE_R(); _.Move(WS_CHAVE, _ws_chave_r); VarBasis.RedefinePassValue(WS_CHAVE, _ws_chave_r, WS_CHAVE); _ws_chave_r.ValueChanged += () => { _.Move(_ws_chave_r, WS_CHAVE); }; return _ws_chave_r; }
                set { VarBasis.RedefinePassValue(value, _ws_chave_r, WS_CHAVE); }
            }  //Redefines
            public class _REDEF_VA4437B_WS_CHAVE_R : VarBasis
            {
                /*"      10      WS-NUM-APOLICE      PIC  9(013).*/
                public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-CODSUBES         PIC  9(004).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WS-CODOPER          PIC  9(003).*/
                public IntBasis WS_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WS-IDFORM           PIC  X(002).*/
                public StringBasis WS_IDFORM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05            AC-LIDOS            PIC 9(006) VALUE ZEROES.*/

                public _REDEF_VA4437B_WS_CHAVE_R()
                {
                    WS_NUM_APOLICE.ValueChanged += OnValueChanged;
                    WS_CODSUBES.ValueChanged += OnValueChanged;
                    WS_CODOPER.ValueChanged += OnValueChanged;
                    WS_IDFORM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-CONTA            PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-IMPRESSOS        PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-I-RELATORI       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_I_RELATORI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-L-RELATORI       PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_L_RELATORI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-PRODUTO    PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_PRODUTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-CANCEL     PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_CANCEL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-CODRELAT   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_CODRELAT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-MOEDACOT   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_MOEDACOT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-APOLICOB   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_APOLICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-SEGVGAPH   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_SEGVGAPH { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-SEGURAVG   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_SEGURAVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-OPCAOPAG   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_OPCAOPAG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-CLIENTE    PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_CLIENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-ENDERECO   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-COBERPRO   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_COBERPRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-PLANOVID   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_PLANOVID { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-TITULO     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_TITULO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-QTD-PDF          PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_QTD_PDF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-QTD-IMP          PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_QTD_IMP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-QTD-HTML         PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_QTD_HTML { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WFIM-SISTEMAS       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-COBER          PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-BENEFICIA      PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_BENEFICIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-FAIXACEP       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-RELATORI       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_RELATORI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-AGENCCEF       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_AGENCCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-COBMENVG       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_COBMENVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-SORT           PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-TABELA         PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_TABELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-TITFEDCA       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_TITFEDCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-FCPLANO        PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_FCPLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-COBER-ESPOSA   PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_COBER_ESPOSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-ENDERECO       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-USUARIOS       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_USUARIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-CLIENTES       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-OPCPAGVI       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_OPCPAGVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-HISCOBPR       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_HISCOBPR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-SEGURVGA       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-COBMENVG       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_COBMENVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-MULTIMSG       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_MULTIMSG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-PLANOVID       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_PLANOVID { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-CONDITEC       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_CONDITEC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-PRODUVGE       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_PRODUVGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WPRIM-LINHA         PIC X(001) VALUE SPACES.*/
            public StringBasis WPRIM_LINHA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            LK-PROSOMU1.*/
            public VA4437B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new VA4437B_LK_PROSOMU1();
            public class VA4437B_LK_PROSOMU1 : VarBasis
            {
                /*"      10          LK-DATA-SOM         PIC 9(008).*/
                public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          LK-DATA-SOM-R       REDEFINES                  LK-DATA-SOM.*/
                private _REDEF_VA4437B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
                public _REDEF_VA4437B_LK_DATA_SOM_R LK_DATA_SOM_R
                {
                    get { _lk_data_som_r = new _REDEF_VA4437B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
                }  //Redefines
                public class _REDEF_VA4437B_LK_DATA_SOM_R : VarBasis
                {
                    /*"        15        LK-DIA-SOM          PIC 9(002).*/
                    public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-MES-SOM          PIC 9(002).*/
                    public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-ANO-SOM          PIC 9(004).*/
                    public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10          LK-QTDIAS           PIC S9(005) COMP-3                                                  VALUE +3.*/

                    public _REDEF_VA4437B_LK_DATA_SOM_R()
                    {
                        LK_DIA_SOM.ValueChanged += OnValueChanged;
                        LK_MES_SOM.ValueChanged += OnValueChanged;
                        LK_ANO_SOM.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +3);
                /*"      10          LK-DATA-CALC        PIC 9(008).*/
                public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          LK-DATA-CALC-R      REDEFINES                  LK-DATA-CALC.*/
                private _REDEF_VA4437B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
                public _REDEF_VA4437B_LK_DATA_CALC_R LK_DATA_CALC_R
                {
                    get { _lk_data_calc_r = new _REDEF_VA4437B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
                }  //Redefines
                public class _REDEF_VA4437B_LK_DATA_CALC_R : VarBasis
                {
                    /*"        15        LK-DIA-CALC         PIC 9(002).*/
                    public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-MES-CALC         PIC 9(002).*/
                    public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-ANO-CALC         PIC 9(004).*/
                    public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"01                PARAMETROS.*/

                    public _REDEF_VA4437B_LK_DATA_CALC_R()
                    {
                        LK_DIA_CALC.ValueChanged += OnValueChanged;
                        LK_MES_CALC.ValueChanged += OnValueChanged;
                        LK_ANO_CALC.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public VA4437B_PARAMETROS PARAMETROS { get; set; } = new VA4437B_PARAMETROS();
        public class VA4437B_PARAMETROS : VarBasis
        {
            /*"  05              LK-APOLICE          PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05              LK-SUBGRUPO         PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05              LK-IDADE            PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05              LK-NASCIMENTO.*/
            public VA4437B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VA4437B_LK_NASCIMENTO();
            public class VA4437B_LK_NASCIMENTO : VarBasis
            {
                /*"     10           LK-DATA-NASCIMENTO  PIC 9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05              LK-SALARIO          PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-MORTE-NATURAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-MORTE-ACIDENTAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-INV-PERMANENTE                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-INV-POR-ACIDENTE                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-ASS-MEDICA                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-DIARIA-HOSPITALAR                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-DIARIA-INTERNACAO                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-MORTE-NATURAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-MORTE-ACIDENTAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-INV-PERMANENTE                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-ASS-MEDICA                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-DIARIA-HOSPITALAR                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-DIARIA-INTERNACAO                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PREM-MORTE-NATURAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PREM-ACIDENTES-PESSOAIS                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PREM-TOTAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-RETURN-CODE      PIC S9(003) COMP-3.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"    05            LK-MENSAGEM         PIC  X(077).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(077)."), @"");
            /*"01                WS-DESCRICAO-DIA.*/
        }
        public VA4437B_WS_DESCRICAO_DIA WS_DESCRICAO_DIA { get; set; } = new VA4437B_WS_DESCRICAO_DIA();
        public class VA4437B_WS_DESCRICAO_DIA : VarBasis
        {
            /*"    05            FILLER              PIC X(002) VALUE SPACES.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05            WS-DESC-DIA         PIC 9(002).*/
            public IntBasis WS_DESC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            FILLER              PIC X(002) VALUE SPACES.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05            WS-DESC-MES         PIC X(009).*/
            public StringBasis WS_DESC_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"    05            FILLER              PIC X(006) VALUE '  de  '.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"  de  ");
            /*"    05            WS-DESC-ANO         PIC 9(004).*/
            public IntBasis WS_DESC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01                TAB-FILIAL.*/
        }
        public VA4437B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA4437B_TAB_FILIAL();
        public class VA4437B_TAB_FILIAL : VarBasis
        {
            /*"    05            FILLER              OCCURS  99  TIMES.*/
            public ListBasis<VA4437B_FILLER_93> FILLER_93 { get; set; } = new ListBasis<VA4437B_FILLER_93>(99);
            public class VA4437B_FILLER_93 : VarBasis
            {
                /*"      10          TAB-FONTE           PIC 9(004).*/
                public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          TAB-NOMEFTE         PIC X(040).*/
                public StringBasis TAB_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10          TAB-ENDERFTE        PIC X(040).*/
                public StringBasis TAB_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10          TAB-BAIRRO          PIC X(020).*/
                public StringBasis TAB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10          TAB-CIDADE          PIC X(020).*/
                public StringBasis TAB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10          TAB-CEP             PIC 9(008).*/
                public IntBasis TAB_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          TAB-UF              PIC X(002).*/
                public StringBasis TAB_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"01                TABELA-CEP.*/
            }
        }
        public VA4437B_TABELA_CEP TABELA_CEP { get; set; } = new VA4437B_TABELA_CEP();
        public class VA4437B_TABELA_CEP : VarBasis
        {
            /*"    05            CEP                 OCCURS  2000 TIMES.*/
            public ListBasis<VA4437B_CEP> CEP { get; set; } = new ListBasis<VA4437B_CEP>(2000);
            public class VA4437B_CEP : VarBasis
            {
                /*"      10          TAB-FX-CEP-G        PIC 9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          TAB-FAIXAS.*/
                public VA4437B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new VA4437B_TAB_FAIXAS();
                public class VA4437B_TAB_FAIXAS : VarBasis
                {
                    /*"        15        TAB-FX-INI          PIC 9(008).*/
                    public IntBasis TAB_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15        TAB-FX-FIM          PIC 9(008).*/
                    public IntBasis TAB_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15        TAB-FX-NOME         PIC X(072).*/
                    public StringBasis TAB_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"        15        TAB-FX-CENTR        PIC X(072).*/
                    public StringBasis TAB_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"01            TABELA-MSG.*/
                }
            }
        }
        public VA4437B_TABELA_MSG TABELA_MSG { get; set; } = new VA4437B_TABELA_MSG();
        public class VA4437B_TABELA_MSG : VarBasis
        {
            /*"    05        TAB-MSG             OCCURS 3000  TIMES.*/
            public ListBasis<VA4437B_TAB_MSG> TAB_MSG { get; set; } = new ListBasis<VA4437B_TAB_MSG>(3000);
            public class VA4437B_TAB_MSG : VarBasis
            {
                /*"      10      TABJ-CHAVE          PIC  X(022).*/
                public StringBasis TABJ_CHAVE { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
                /*"      10      TABJ-CHAVE-R        REDEFINES              TABJ-CHAVE.*/
                private _REDEF_VA4437B_TABJ_CHAVE_R _tabj_chave_r { get; set; }
                public _REDEF_VA4437B_TABJ_CHAVE_R TABJ_CHAVE_R
                {
                    get { _tabj_chave_r = new _REDEF_VA4437B_TABJ_CHAVE_R(); _.Move(TABJ_CHAVE, _tabj_chave_r); VarBasis.RedefinePassValue(TABJ_CHAVE, _tabj_chave_r, TABJ_CHAVE); _tabj_chave_r.ValueChanged += () => { _.Move(_tabj_chave_r, TABJ_CHAVE); }; return _tabj_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tabj_chave_r, TABJ_CHAVE); }
                }  //Redefines
                public class _REDEF_VA4437B_TABJ_CHAVE_R : VarBasis
                {
                    /*"        15    TABJ-APOLICE        PIC  9(013).*/
                    public IntBasis TABJ_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"        15    TABJ-CODSUBES       PIC  9(004).*/
                    public IntBasis TABJ_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15    TABJ-CODOPER        PIC  9(003).*/
                    public IntBasis TABJ_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"        15    TABJ-IDFORM         PIC  X(002).*/
                    public StringBasis TABJ_IDFORM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      10      TABJ-JDE            PIC  X(008).*/

                    public _REDEF_VA4437B_TABJ_CHAVE_R()
                    {
                        TABJ_APOLICE.ValueChanged += OnValueChanged;
                        TABJ_CODSUBES.ValueChanged += OnValueChanged;
                        TABJ_CODOPER.ValueChanged += OnValueChanged;
                        TABJ_IDFORM.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis TABJ_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      10      TABJ-JDL            PIC  X(008).*/
                public StringBasis TABJ_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01            TAB-QTD-DIG-COMBINACAO.*/
            }
        }
        public VA4437B_TAB_QTD_DIG_COMBINACAO TAB_QTD_DIG_COMBINACAO { get; set; } = new VA4437B_TAB_QTD_DIG_COMBINACAO();
        public class VA4437B_TAB_QTD_DIG_COMBINACAO : VarBasis
        {
            /*"    05        TAB-COMB            OCCURS  1000 TIMES.*/
            public ListBasis<VA4437B_TAB_COMB> TAB_COMB { get; set; } = new ListBasis<VA4437B_TAB_COMB>(1000);
            public class VA4437B_TAB_COMB : VarBasis
            {
                /*"      10      TAB-QTD-DIG         PIC  9(001).*/
                public IntBasis TAB_QTD_DIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01                TB99.*/
            }
        }
        public VA4437B_TB99 TB99 { get; set; } = new VA4437B_TB99();
        public class VA4437B_TB99 : VarBasis
        {
            /*"    03            TB99-CONT           OCCURS  100  TIMES.*/
            public ListBasis<VA4437B_TB99_CONT> TB99_CONT { get; set; } = new ListBasis<VA4437B_TB99_CONT>(100);
            public class VA4437B_TB99_CONT : VarBasis
            {
                /*"       05         TB99-NOME-BENEF     PIC X(040).*/
                public StringBasis TB99_NOME_BENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       05         TB99-PARENTESCO     PIC X(010).*/
                public StringBasis TB99_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       05         TB99-PARTICIP       PIC 9(003)V99.*/
                public DoubleBasis TB99_PARTICIP { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"       05         TB99-DTINIVIG       PIC X(010).*/
                public StringBasis TB99_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       05         TB99-DTTERVIG       PIC X(010).*/
                public StringBasis TB99_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"01                TABELA-NOMES.*/
            }
        }
        public VA4437B_TABELA_NOMES TABELA_NOMES { get; set; } = new VA4437B_TABELA_NOMES();
        public class VA4437B_TABELA_NOMES : VarBasis
        {
            /*"    05            TAB-NOMES.*/
            public VA4437B_TAB_NOMES TAB_NOMES { get; set; } = new VA4437B_TAB_NOMES();
            public class VA4437B_TAB_NOMES : VarBasis
            {
                /*"      10          FILLER              PIC X(040).*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05            TAB-NOMES-R         REDEFINES  TAB-NOMES.*/
            }
            private _REDEF_VA4437B_TAB_NOMES_R _tab_nomes_r { get; set; }
            public _REDEF_VA4437B_TAB_NOMES_R TAB_NOMES_R
            {
                get { _tab_nomes_r = new _REDEF_VA4437B_TAB_NOMES_R(); _.Move(TAB_NOMES, _tab_nomes_r); VarBasis.RedefinePassValue(TAB_NOMES, _tab_nomes_r, TAB_NOMES); _tab_nomes_r.ValueChanged += () => { _.Move(_tab_nomes_r, TAB_NOMES); }; return _tab_nomes_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes_r, TAB_NOMES); }
            }  //Redefines
            public class _REDEF_VA4437B_TAB_NOMES_R : VarBasis
            {
                /*"      10          TAB-NOME            OCCURS  40  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 40);
                /*"01                TABELA-NOMES1.*/

                public _REDEF_VA4437B_TAB_NOMES_R()
                {
                    TAB_NOME.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA4437B_TABELA_NOMES1 TABELA_NOMES1 { get; set; } = new VA4437B_TABELA_NOMES1();
        public class VA4437B_TABELA_NOMES1 : VarBasis
        {
            /*"    05            TAB-NOMES1.*/
            public VA4437B_TAB_NOMES1 TAB_NOMES1 { get; set; } = new VA4437B_TAB_NOMES1();
            public class VA4437B_TAB_NOMES1 : VarBasis
            {
                /*"      10          FILLER              PIC X(040).*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05            TAB-NOMES1-R        REDEFINES  TAB-NOMES1.*/
            }
            private _REDEF_VA4437B_TAB_NOMES1_R _tab_nomes1_r { get; set; }
            public _REDEF_VA4437B_TAB_NOMES1_R TAB_NOMES1_R
            {
                get { _tab_nomes1_r = new _REDEF_VA4437B_TAB_NOMES1_R(); _.Move(TAB_NOMES1, _tab_nomes1_r); VarBasis.RedefinePassValue(TAB_NOMES1, _tab_nomes1_r, TAB_NOMES1); _tab_nomes1_r.ValueChanged += () => { _.Move(_tab_nomes1_r, TAB_NOMES1); }; return _tab_nomes1_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes1_r, TAB_NOMES1); }
            }  //Redefines
            public class _REDEF_VA4437B_TAB_NOMES1_R : VarBasis
            {
                /*"      10          TAB-NOME1           OCCURS  40  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME1 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 40);
                /*"01                TABELA-NOMES-SOC.*/

                public _REDEF_VA4437B_TAB_NOMES1_R()
                {
                    TAB_NOME1.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA4437B_TABELA_NOMES_SOC TABELA_NOMES_SOC { get; set; } = new VA4437B_TABELA_NOMES_SOC();
        public class VA4437B_TABELA_NOMES_SOC : VarBasis
        {
            /*"    05            TAB-NOMES-SOC.*/
            public VA4437B_TAB_NOMES_SOC TAB_NOMES_SOC { get; set; } = new VA4437B_TAB_NOMES_SOC();
            public class VA4437B_TAB_NOMES_SOC : VarBasis
            {
                /*"      10          FILLER              PIC X(100).*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"    05            TAB-NOMES-SOC-R     REDEFINES  TAB-NOMES-SOC.*/
            }
            private _REDEF_VA4437B_TAB_NOMES_SOC_R _tab_nomes_soc_r { get; set; }
            public _REDEF_VA4437B_TAB_NOMES_SOC_R TAB_NOMES_SOC_R
            {
                get { _tab_nomes_soc_r = new _REDEF_VA4437B_TAB_NOMES_SOC_R(); _.Move(TAB_NOMES_SOC, _tab_nomes_soc_r); VarBasis.RedefinePassValue(TAB_NOMES_SOC, _tab_nomes_soc_r, TAB_NOMES_SOC); _tab_nomes_soc_r.ValueChanged += () => { _.Move(_tab_nomes_soc_r, TAB_NOMES_SOC); }; return _tab_nomes_soc_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes_soc_r, TAB_NOMES_SOC); }
            }  //Redefines
            public class _REDEF_VA4437B_TAB_NOMES_SOC_R : VarBasis
            {
                /*"      10          TAB-NOME-SOC        OCCURS 100  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME_SOC { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 100);
                /*"01                TABELA-NOMES1-SOC.*/

                public _REDEF_VA4437B_TAB_NOMES_SOC_R()
                {
                    TAB_NOME_SOC.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA4437B_TABELA_NOMES1_SOC TABELA_NOMES1_SOC { get; set; } = new VA4437B_TABELA_NOMES1_SOC();
        public class VA4437B_TABELA_NOMES1_SOC : VarBasis
        {
            /*"    05            TAB-NOMES1-SOC.*/
            public VA4437B_TAB_NOMES1_SOC TAB_NOMES1_SOC { get; set; } = new VA4437B_TAB_NOMES1_SOC();
            public class VA4437B_TAB_NOMES1_SOC : VarBasis
            {
                /*"      10          FILLER              PIC X(100).*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"    05            TAB-NOMES1-SOC-R    REDEFINES  TAB-NOMES1-SOC.*/
            }
            private _REDEF_VA4437B_TAB_NOMES1_SOC_R _tab_nomes1_soc_r { get; set; }
            public _REDEF_VA4437B_TAB_NOMES1_SOC_R TAB_NOMES1_SOC_R
            {
                get { _tab_nomes1_soc_r = new _REDEF_VA4437B_TAB_NOMES1_SOC_R(); _.Move(TAB_NOMES1_SOC, _tab_nomes1_soc_r); VarBasis.RedefinePassValue(TAB_NOMES1_SOC, _tab_nomes1_soc_r, TAB_NOMES1_SOC); _tab_nomes1_soc_r.ValueChanged += () => { _.Move(_tab_nomes1_soc_r, TAB_NOMES1_SOC); }; return _tab_nomes1_soc_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes1_soc_r, TAB_NOMES1_SOC); }
            }  //Redefines
            public class _REDEF_VA4437B_TAB_NOMES1_SOC_R : VarBasis
            {
                /*"      10          TAB-NOME1-SOC       OCCURS 100  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME1_SOC { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 100);
                /*"01                LK-LINK.*/

                public _REDEF_VA4437B_TAB_NOMES1_SOC_R()
                {
                    TAB_NOME1_SOC.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA4437B_LK_LINK LK_LINK { get; set; } = new VA4437B_LK_LINK();
        public class VA4437B_LK_LINK : VarBasis
        {
            /*"    05            LK-RTCODE           PIC S9(004) VALUE +0 COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            LK-TAMANHO          PIC S9(004) VALUE +40 COMP*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"    05            LK-TITULO           PIC  X(132) VALUE SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01                TABELA-COBER.*/
        }
        public VA4437B_TABELA_COBER TABELA_COBER { get; set; } = new VA4437B_TABELA_COBER();
        public class VA4437B_TABELA_COBER : VarBasis
        {
            /*"    05            TAB-COBER.*/
            public VA4437B_TAB_COBER TAB_COBER { get; set; } = new VA4437B_TAB_COBER();
            public class VA4437B_TAB_COBER : VarBasis
            {
                /*"      10          FILLER              PIC X(040)  VALUE                 'COBERTURA DOENCA GRAVE.............: R$ '.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"COBERTURA DOENCA GRAVE.............: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'SERVICO ASSISTENCIA FUNERAL........: R$ '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SERVICO ASSISTENCIA FUNERAL........: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ADIANTAMENTO AUXILIO FUNERAL(ATE)..: R$ '.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ADIANTAMENTO AUXILIO FUNERAL(ATE)..: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'CESTA BASICA.......................: R$ '.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"CESTA BASICA.......................: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'AUXILIO ALIMENTACAO................: R$ '.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"AUXILIO ALIMENTACAO................: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'DOENCAS CONGENITAS GRAVES..........: R$ '.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DOENCAS CONGENITAS GRAVES..........: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'INDENIZACAO RESCISAO TRABALHISTA...: R$ '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"INDENIZACAO RESCISAO TRABALHISTA...: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'DESEMPREGO INVOLUNTARIO............: R$ '.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESEMPREGO INVOLUNTARIO............: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'PERDA DE RENDA (AUTONOMO)..........: R$ '.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"PERDA DE RENDA (AUTONOMO)..........: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'REMISSAO PREMIO DESEMPREGO INVOLUNTARIO '.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"REMISSAO PREMIO DESEMPREGO INVOLUNTARIO ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'DIAGNOSTICO DE CANCER..............: R$ '.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DIAGNOSTICO DE CANCER..............: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'SERVICO ASSISTENCIA VIAGEM.........: R$ '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SERVICO ASSISTENCIA VIAGEM.........: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'EXTRAVIO DE BAGAGEM................: R$ '.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"EXTRAVIO DE BAGAGEM................: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'REMISSAO PREMIO DIAGNOSTICO CANCER      '.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"REMISSAO PREMIO DIAGNOSTICO CANCER      ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'REMISSAO PREMIO INDENIZACAO CDG         '.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"REMISSAO PREMIO INDENIZACAO CDG         ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ASSISTENCIA FARMACIA                    '.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ASSISTENCIA FARMACIA                    ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ASSISTENCIA RESIDENCIAL                 '.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ASSISTENCIA RESIDENCIAL                 ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ASSISTENCIA VIAGEM                      '.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ASSISTENCIA VIAGEM                      ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ORIENTACAO NUTRICIONAL                  '.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ORIENTACAO NUTRICIONAL                  ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'PAGAMENTO ANTECIPADO ESPECIAL POR DOENCA'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"PAGAMENTO ANTECIPADO ESPECIAL POR DOENCA");
                /*"      10          FILLER              PIC X(040)  VALUE                 'DESP MEDICO HOSPITALAR ODONTOLOGICA ATE:'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESP MEDICO HOSPITALAR ODONTOLOGICA ATE:");
                /*"    05            TAB-COBER-R         REDEFINES                  TAB-COBER.*/
            }
            private _REDEF_VA4437B_TAB_COBER_R _tab_cober_r { get; set; }
            public _REDEF_VA4437B_TAB_COBER_R TAB_COBER_R
            {
                get { _tab_cober_r = new _REDEF_VA4437B_TAB_COBER_R(); _.Move(TAB_COBER, _tab_cober_r); VarBasis.RedefinePassValue(TAB_COBER, _tab_cober_r, TAB_COBER); _tab_cober_r.ValueChanged += () => { _.Move(_tab_cober_r, TAB_COBER); }; return _tab_cober_r; }
                set { VarBasis.RedefinePassValue(value, _tab_cober_r, TAB_COBER); }
            }  //Redefines
            public class _REDEF_VA4437B_TAB_COBER_R : VarBasis
            {
                /*"      10          TAB-COBER-DESCR     OCCURS  21  TIMES                                      PIC X(040).*/
                public ListBasis<StringBasis, string> TAB_COBER_DESCR { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "40", "X(040)."), 21);
                /*"01                TABELA-MESES.*/

                public _REDEF_VA4437B_TAB_COBER_R()
                {
                    TAB_COBER_DESCR.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA4437B_TABELA_MESES TABELA_MESES { get; set; } = new VA4437B_TABELA_MESES();
        public class VA4437B_TABELA_MESES : VarBasis
        {
            /*"    05            TAB-MESES.*/
            public VA4437B_TAB_MESES TAB_MESES { get; set; } = new VA4437B_TAB_MESES();
            public class VA4437B_TAB_MESES : VarBasis
            {
                /*"      10          FILLER           PIC X(009) VALUE '  Janeiro'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  Janeiro");
                /*"      10          FILLER           PIC X(009) VALUE 'Fevereiro'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"Fevereiro");
                /*"      10          FILLER           PIC X(009) VALUE '    Marco'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Marco");
                /*"      10          FILLER           PIC X(009) VALUE '    Abril'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Abril");
                /*"      10          FILLER           PIC X(009) VALUE '     Maio'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     Maio");
                /*"      10          FILLER           PIC X(009) VALUE '    Junho'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Junho");
                /*"      10          FILLER           PIC X(009) VALUE '    Julho'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Julho");
                /*"      10          FILLER           PIC X(009) VALUE '   Agosto'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   Agosto");
                /*"      10          FILLER           PIC X(009) VALUE ' Setembro'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" Setembro");
                /*"      10          FILLER           PIC X(009) VALUE '  Outubro'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  Outubro");
                /*"      10          FILLER           PIC X(009) VALUE ' Novembro'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" Novembro");
                /*"      10          FILLER           PIC X(009) VALUE ' Dezembro'.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" Dezembro");
                /*"    05            TAB-MESES-R         REDEFINES                  TAB-MESES.*/
            }
            private _REDEF_VA4437B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_VA4437B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_VA4437B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_VA4437B_TAB_MESES_R : VarBasis
            {
                /*"      10          TAB-MES             OCCURS  12  TIMES                                      PIC X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01                WABEND.*/

                public _REDEF_VA4437B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA4437B_WABEND WABEND { get; set; } = new VA4437B_WABEND();
        public class VA4437B_WABEND : VarBasis
        {
            /*"      05          FILLER              PIC X(010) VALUE                 ' VA4437B'.*/
            public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA4437B");
            /*"      05          FILLER              PIC X(026) VALUE                 ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05          WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05          FILLER              PIC X(013) VALUE                 ' *** SQLCODE '.*/
            public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05          WSQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  LK-PARAMETROS.*/
        }
        public VA4437B_LK_PARAMETROS LK_PARAMETROS { get; set; } = new VA4437B_LK_PARAMETROS();
        public class VA4437B_LK_PARAMETROS : VarBasis
        {
            /*"  04  FILLER                  PIC X(002).*/
            public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  04  LK-OPERACAO             PIC X(008).*/

            public SelectorBasis LK_OPERACAO { get; set; } = new SelectorBasis("008")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88  LK-COMMIT                 VALUE 'COMMIT  '. */
							new SelectorItemBasis("LK_COMMIT", "COMMIT "),
							/*" 88  LK-ROLLBACK               VALUE 'ROLLBACK'. */
							new SelectorItemBasis("LK_ROLLBACK", "ROLLBACK")
                }
            };

        }


        public Copies.SPGE053W SPGE053W { get; set; } = new Copies.SPGE053W();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.VGCOBSUB VGCOBSUB { get; set; } = new Dclgens.VGCOBSUB();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.GEFAICEP GEFAICEP { get; set; } = new Dclgens.GEFAICEP();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.BENEFICI BENEFICI { get; set; } = new Dclgens.BENEFICI();
        public Dclgens.COBMENVG COBMENVG { get; set; } = new Dclgens.COBMENVG();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.PLANOVID PLANOVID { get; set; } = new Dclgens.PLANOVID();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.FCPLANO FCPLANO { get; set; } = new Dclgens.FCPLANO();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.GE101 GE101 { get; set; } = new Dclgens.GE101();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA4437B_CFAIXACEP CFAIXACEP { get; set; } = new VA4437B_CFAIXACEP();
        public VA4437B_CMSG CMSG { get; set; } = new VA4437B_CMSG();
        public VA4437B_CFCPLANO CFCPLANO { get; set; } = new VA4437B_CFCPLANO();
        public VA4437B_V1AGENCEF V1AGENCEF { get; set; } = new VA4437B_V1AGENCEF();
        public VA4437B_CRELAT CRELAT { get; set; } = new VA4437B_CRELAT();
        public VA4437B_CTITFEDCA CTITFEDCA { get; set; } = new VA4437B_CTITFEDCA();
        public VA4437B_COBER COBER { get; set; } = new VA4437B_COBER();
        public VA4437B_V0BENEF V0BENEF { get; set; } = new VA4437B_V0BENEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA4437B_LK_PARAMETROS VA4437B_LK_PARAMETROS_P, string SVA4437B_FILE_NAME_P, string RVA4437B_FILE_NAME_P, string RVA4437I_FILE_NAME_P, string RVA4437P_FILE_NAME_P, string RVA4437H_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LK_PARAMETROS*/
        {
            try
            {
                this.LK_PARAMETROS = VA4437B_LK_PARAMETROS_P;
                SVA4437B.SetFile(SVA4437B_FILE_NAME_P);
                RVA4437B.SetFile(RVA4437B_FILE_NAME_P);
                RVA4437I.SetFile(RVA4437I_FILE_NAME_P);
                RVA4437P.SetFile(RVA4437P_FILE_NAME_P);
                RVA4437H.SetFile(RVA4437H_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1187- DISPLAY ' ' */
            _.Display($" ");

            /*" -1189- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1199- DISPLAY 'PROGRAMA VA4437B-VERSAO V.24 ' '- DEMANDA 582106 - 01/08/2024.' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VA4437B-VERSAO V.24 - DEMANDA 582106 - 01/08/2024.FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1201- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1202- DISPLAY ' ' */
            _.Display($" ");

            /*" -1209- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1210- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -1211- DISPLAY 'PARAMETRO INFORMADO <' LK-OPERACAO '>' */

            $"PARAMETRO INFORMADO <{LK_PARAMETROS.LK_OPERACAO}>"
            .Display();

            /*" -1213- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -1214- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1217- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1220- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1250- IF LK-COMMIT OR LK-ROLLBACK */

            if (LK_PARAMETROS.LK_OPERACAO["LK_COMMIT"] || LK_PARAMETROS.LK_OPERACAO["LK_ROLLBACK"])
            {

                /*" -1251- CONTINUE */

                /*" -1252- ELSE */
            }
            else
            {


                /*" -1254- DISPLAY '==> PARAMETROS COM ERRO. INFORME <COMMIT > OU <R 'OLLBACK>' */
                _.Display($"==> PARAMETROS COM ERRO. INFORME <COMMIT > OU <R OLLBACK>");

                /*" -1255- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -1256- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1258- END-IF */
            }


            /*" -1260- DISPLAY ' ' */
            _.Display($" ");

            /*" -1262- PERFORM R0100-00-SELECT-SISTEMAS */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -1263- IF WFIM-SISTEMAS NOT = SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMAS.IsEmpty())
            {

                /*" -1264- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -1266- END-IF */
            }


            /*" -1268- PERFORM R0900-00-DECLARE-RELATORI */

            R0900_00_DECLARE_RELATORI_SECTION();

            /*" -1270- PERFORM R0910-00-FETCH-RELATORI */

            R0910_00_FETCH_RELATORI_SECTION();

            /*" -1271- IF WFIM-RELATORI = 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -1272- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1273- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1274- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1276- END-IF */
            }


            /*" -1279- INITIALIZE TAB-FILIAL TAB-QTD-DIG-COMBINACAO */
            _.Initialize(
                TAB_FILIAL
                , TAB_QTD_DIG_COMBINACAO
            );

            /*" -1281- PERFORM R0500-00-DECLARE-AGENCCEF */

            R0500_00_DECLARE_AGENCCEF_SECTION();

            /*" -1283- PERFORM R0510-00-FETCH-AGENCCEF */

            R0510_00_FETCH_AGENCCEF_SECTION();

            /*" -1284- IF WFIM-AGENCCEF NOT = SPACES */

            if (!AREA_DE_WORK.WFIM_AGENCCEF.IsEmpty())
            {

                /*" -1285- DISPLAY 'R0000 - PROBLEMA NO FETCH DA AGENCCEF ' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA AGENCCEF ");

                /*" -1286- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1288- END-IF */
            }


            /*" -1290- PERFORM R0520-00-CARREGA-FILIAL UNTIL WFIM-AGENCCEF = 'S' */

            while (!(AREA_DE_WORK.WFIM_AGENCCEF == "S"))
            {

                R0520_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1292- PERFORM R0200-00-CARREGA-FAIXACEP */

            R0200_00_CARREGA_FAIXACEP_SECTION();

            /*" -1294- PERFORM R0300-00-CARREGA-COBMENVG */

            R0300_00_CARREGA_COBMENVG_SECTION();

            /*" -1298- PERFORM R0400-00-CARREGA-FCPLANO */

            R0400_00_CARREGA_FCPLANO_SECTION();

            /*" -1312- SORT SVA4437B ON ASCENDING KEY SVA-CODRELAT SVA-NRAPOLICE SVA-CODSUBES SVA-CEP-G SVA-NUM-CEP INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM IF SORT-RETURN NOT = ZEROS DISPLAY '--> VA4437B - PROBLEMAS NO SORT' DISPLAY '--> VA4437B - SORT-RETURN = ' SORT-RETURN MOVE 9 TO RETURN-CODE STOP RUN END-IF. */
            SORT_RETURN.Value = SVA4437B.Sort("SVA-CODRELAT,SVA-NRAPOLICE,SVA-CODSUBES,SVA-CEP-G,SVA-NUM-CEP", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1318- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1319- IF LK-COMMIT */

            if (LK_PARAMETROS.LK_OPERACAO["LK_COMMIT"])
            {

                /*" -1319- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1321- DISPLAY ' ' */
                _.Display($" ");

                /*" -1322- DISPLAY '==> COMMIT EXECUTADO POR PARAMETRO' */
                _.Display($"==> COMMIT EXECUTADO POR PARAMETRO");

                /*" -1323- ELSE */
            }
            else
            {


                /*" -1323- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1325- DISPLAY ' ' */
                _.Display($" ");

                /*" -1326- DISPLAY '==> ROLLBACK EXECUTADO POR PARAMETRO' */
                _.Display($"==> ROLLBACK EXECUTADO POR PARAMETRO");

                /*" -1446- END-IF */
            }


            /*" -1448- PERFORM R9000-00-CLOSE-ARQUIVOS */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -1449- DISPLAY 'ESTATISTICAS DO PROCESSAMENTO' */
            _.Display($"ESTATISTICAS DO PROCESSAMENTO");

            /*" -1450- DISPLAY '-----------------------------' */
            _.Display($"-----------------------------");

            /*" -1451- DISPLAY 'LIDOS V0RELATORIOS......: ' AC-L-RELATORI */
            _.Display($"LIDOS V0RELATORIOS......: {AREA_DE_WORK.AC_L_RELATORI}");

            /*" -1452- DISPLAY 'CERTIFICADOS IMPRESSOS..: ' AC-IMPRESSOS */
            _.Display($"CERTIFICADOS IMPRESSOS..: {AREA_DE_WORK.AC_IMPRESSOS}");

            /*" -1453- DISPLAY 'DESPREZADOS CANCELAMEN..: ' AC-DESPR-CANCEL */
            _.Display($"DESPREZADOS CANCELAMEN..: {AREA_DE_WORK.AC_DESPR_CANCEL}");

            /*" -1454- DISPLAY 'DESPREZADOS V0SEGURAVG..: ' AC-DESPR-SEGURAVG */
            _.Display($"DESPREZADOS V0SEGURAVG..: {AREA_DE_WORK.AC_DESPR_SEGURAVG}");

            /*" -1455- DISPLAY 'DESPREZADOS V0OPCAOPAGVA: ' AC-DESPR-OPCAOPAG */
            _.Display($"DESPREZADOS V0OPCAOPAGVA: {AREA_DE_WORK.AC_DESPR_OPCAOPAG}");

            /*" -1456- DISPLAY 'DESPREZADOS V0ENDERECO..: ' AC-DESPR-ENDERECO */
            _.Display($"DESPREZADOS V0ENDERECO..: {AREA_DE_WORK.AC_DESPR_ENDERECO}");

            /*" -1457- DISPLAY 'DESPREZADOS V0COBERPRO..: ' AC-DESPR-COBERPRO */
            _.Display($"DESPREZADOS V0COBERPRO..: {AREA_DE_WORK.AC_DESPR_COBERPRO}");

            /*" -1458- DISPLAY 'DESPREZADOS V0COBERAPOL.: ' AC-DESPR-APOLICOB */
            _.Display($"DESPREZADOS V0COBERAPOL.: {AREA_DE_WORK.AC_DESPR_APOLICOB}");

            /*" -1459- DISPLAY 'DESPREZADOS V0HISTSEGVG.: ' AC-DESPR-SEGVGAPH */
            _.Display($"DESPREZADOS V0HISTSEGVG.: {AREA_DE_WORK.AC_DESPR_SEGVGAPH}");

            /*" -1460- DISPLAY 'DESPREZADOS V0COTACAO...: ' AC-DESPR-MOEDACOT */
            _.Display($"DESPREZADOS V0COTACAO...: {AREA_DE_WORK.AC_DESPR_MOEDACOT}");

            /*" -1461- DISPLAY 'DESPREZADOS TITULO CAP..: ' AC-DESPR-TITULO */
            _.Display($"DESPREZADOS TITULO CAP..: {AREA_DE_WORK.AC_DESPR_TITULO}");

            /*" -1462- DISPLAY 'IMPRESSOS ARQUIVO PDF...: ' AC-QTD-PDF */
            _.Display($"IMPRESSOS ARQUIVO PDF...: {AREA_DE_WORK.AC_QTD_PDF}");

            /*" -1463- DISPLAY 'IMPRESSOS ARQUIVO IMP...: ' AC-QTD-IMP */
            _.Display($"IMPRESSOS ARQUIVO IMP...: {AREA_DE_WORK.AC_QTD_IMP}");

            /*" -1464- DISPLAY 'IMPRESSOS ARQUIVO HTM...: ' AC-QTD-HTML */
            _.Display($"IMPRESSOS ARQUIVO HTM...: {AREA_DE_WORK.AC_QTD_HTML}");

            /*" -1466- DISPLAY '*** VA4437B - TERMINO NORMAL ***' */
            _.Display($"*** VA4437B - TERMINO NORMAL ***");

            /*" -1466- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1475- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-RELATORI = 'S' . */

            while (!(AREA_DE_WORK.WFIM_RELATORI == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -1486- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1488- MOVE ZEROS TO WIND */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -1490- PERFORM R2300-00-LE-SORT */

            R2300_00_LE_SORT_SECTION();

            /*" -1490- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT = 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -1501- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -1514- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -1517- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1518- DISPLAY 'VA4437B - SISTEMA FI NAO ESTA CADASTRADO' */
                _.Display($"VA4437B - SISTEMA FI NAO ESTA CADASTRADO");

                /*" -1519- MOVE 'S' TO WFIM-SISTEMAS */
                _.Move("S", AREA_DE_WORK.WFIM_SISTEMAS);

                /*" -1520- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -1522- END-IF */
            }


            /*" -1525- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO LC11-DATADIA (1:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 1, 2);

            /*" -1528- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO LC11-DATADIA (4:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 4, 2);

            /*" -1531- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO LC11-DATADIA (7:4). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 7, 4);

            /*" -1533- MOVE '/' TO LC11-DATADIA(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 6, 1);

            /*" -1533- MOVE '/' TO LC11-DATADIA(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 3, 1);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1514- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 1 YEAR, DATA_MOV_ABERTO - 15 DAYS, MONTH(DATA_MOV_ABERTO), YEAR(DATA_MOV_ABERTO) INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO-1, :SISTEMAS-DATA-MOV-ABERTO-15D, :V1SIST-MESREFER, :V1SIST-ANOREFER FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_1, SISTEMAS_DATA_MOV_ABERTO_1);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_15D, SISTEMAS_DATA_MOV_ABERTO_15D);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXACEP-SECTION */
        private void R0200_00_CARREGA_FAIXACEP_SECTION()
        {
            /*" -1545- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -1558- PERFORM R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1 */

            R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1();

            /*" -1560- PERFORM R0200_00_CARREGA_FAIXACEP_DB_OPEN_1 */

            R0200_00_CARREGA_FAIXACEP_DB_OPEN_1();

            /*" -1563- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1564- DISPLAY 'VA4437B - PROBLEMAS NA FAIXA_CEP' */
                _.Display($"VA4437B - PROBLEMAS NA FAIXA_CEP");

                /*" -1566- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1567- PERFORM R0210-00-FETCH-FAIXACEP UNTIL WFIM-FAIXACEP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FAIXACEP == "S"))
            {

                R0210_00_FETCH_FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXACEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1()
        {
            /*" -1558- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO ORDER BY FAIXA END-EXEC. */
            CFAIXACEP = new VA4437B_CFAIXACEP(true);
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
        /*" R0200-00-CARREGA-FAIXACEP-DB-OPEN-1 */
        public void R0200_00_CARREGA_FAIXACEP_DB_OPEN_1()
        {
            /*" -1560- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-DB-DECLARE-1 */
        public void R0300_00_CARREGA_COBMENVG_DB_DECLARE_1()
        {
            /*" -1633- EXEC SQL DECLARE CMSG CURSOR FOR SELECT NUM_APOLICE, CODSUBES, COD_OPERACAO, JDE, JDL, IDFORM FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM IN ( 'A4' , 'A5' ) AND COD_OPERACAO IN ( 2, 6, 10 ) ORDER BY 1,2,3 END-EXEC. */
            CMSG = new VA4437B_CMSG(false);
            string GetQuery_CMSG()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							COD_OPERACAO
							, 
							JDE
							, 
							JDL
							, 
							IDFORM 
							FROM SEGUROS.COBRANCA_MENS_VGAP 
							WHERE IDFORM IN ( 'A4'
							, 'A5' ) 
							AND COD_OPERACAO IN ( 2
							, 6
							, 10 ) 
							ORDER BY 1
							,2
							,3";

                return query;
            }
            CMSG.GetQueryEvent += GetQuery_CMSG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-FAIXACEP-SECTION */
        private void R0210_00_FETCH_FAIXACEP_SECTION()
        {
            /*" -1581- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WABEND.WNR_EXEC_SQL);

            /*" -1588- PERFORM R0210_00_FETCH_FAIXACEP_DB_FETCH_1 */

            R0210_00_FETCH_FAIXACEP_DB_FETCH_1();

            /*" -1591- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1592- MOVE 'S' TO WFIM-FAIXACEP */
                _.Move("S", AREA_DE_WORK.WFIM_FAIXACEP);

                /*" -1592- PERFORM R0210_00_FETCH_FAIXACEP_DB_CLOSE_1 */

                R0210_00_FETCH_FAIXACEP_DB_CLOSE_1();

                /*" -1596- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1598- MOVE GEFAICEP-FAIXA TO TAB-FX-CEP-G (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FX_CEP_G);

            /*" -1600- MOVE GEFAICEP-CEP-INICIAL TO TAB-FX-INI (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -1602- MOVE GEFAICEP-CEP-FINAL TO TAB-FX-FIM (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -1604- MOVE GEFAICEP-DESCRICAO-FAIXA TO TAB-FX-NOME (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -1607- MOVE GEFAICEP-CENTRALIZADOR TO TAB-FX-CENTR (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -1607- GO TO R0210-00-FETCH-FAIXACEP. */
            new Task(() => R0210_00_FETCH_FAIXACEP_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-00-FETCH-FAIXACEP-DB-FETCH-1 */
        public void R0210_00_FETCH_FAIXACEP_DB_FETCH_1()
        {
            /*" -1588- EXEC SQL FETCH CFAIXACEP INTO :GEFAICEP-FAIXA, :GEFAICEP-CEP-INICIAL, :GEFAICEP-CEP-FINAL, :GEFAICEP-DESCRICAO-FAIXA, :GEFAICEP-CENTRALIZADOR END-EXEC. */

            if (CFAIXACEP.Fetch())
            {
                _.Move(CFAIXACEP.GEFAICEP_FAIXA, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA);
                _.Move(CFAIXACEP.GEFAICEP_CEP_INICIAL, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL);
                _.Move(CFAIXACEP.GEFAICEP_CEP_FINAL, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL);
                _.Move(CFAIXACEP.GEFAICEP_DESCRICAO_FAIXA, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA);
                _.Move(CFAIXACEP.GEFAICEP_CENTRALIZADOR, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-FAIXACEP-DB-CLOSE-1 */
        public void R0210_00_FETCH_FAIXACEP_DB_CLOSE_1()
        {
            /*" -1592- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-SECTION */
        private void R0300_00_CARREGA_COBMENVG_SECTION()
        {
            /*" -1621- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -1633- PERFORM R0300_00_CARREGA_COBMENVG_DB_DECLARE_1 */

            R0300_00_CARREGA_COBMENVG_DB_DECLARE_1();

            /*" -1635- PERFORM R0300_00_CARREGA_COBMENVG_DB_OPEN_1 */

            R0300_00_CARREGA_COBMENVG_DB_OPEN_1();

            /*" -1638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1639- DISPLAY 'VA4437B - PROBLEMAS NA COBRANCA_MENS_VGAP ' */
                _.Display($"VA4437B - PROBLEMAS NA COBRANCA_MENS_VGAP ");

                /*" -1641- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1642- PERFORM R0310-00-FETCH-COBMENVG UNTIL WFIM-COBMENVG EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_COBMENVG == "S"))
            {

                R0310_00_FETCH_COBMENVG_SECTION();
            }

        }

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-DB-OPEN-1 */
        public void R0300_00_CARREGA_COBMENVG_DB_OPEN_1()
        {
            /*" -1635- EXEC SQL OPEN CMSG END-EXEC. */

            CMSG.Open();

        }

        [StopWatch]
        /*" R0400-00-CARREGA-FCPLANO-DB-DECLARE-1 */
        public void R0400_00_CARREGA_FCPLANO_DB_DECLARE_1()
        {
            /*" -1714- EXEC SQL DECLARE CFCPLANO CURSOR FOR SELECT NUM_PLANO, QTD_DIG_COMBINACAO FROM FDRCAP.FC_PLANO WHERE NUM_PLANO > 0 ORDER BY NUM_PLANO WITH UR END-EXEC. */
            CFCPLANO = new VA4437B_CFCPLANO(false);
            string GetQuery_CFCPLANO()
            {
                var query = @$"SELECT NUM_PLANO
							, 
							QTD_DIG_COMBINACAO 
							FROM FDRCAP.FC_PLANO 
							WHERE NUM_PLANO > 0 
							ORDER BY NUM_PLANO";

                return query;
            }
            CFCPLANO.GetQueryEvent += GetQuery_CFCPLANO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-SECTION */
        private void R0310_00_FETCH_COBMENVG_SECTION()
        {
            /*" -1656- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", WABEND.WNR_EXEC_SQL);

            /*" -1664- PERFORM R0310_00_FETCH_COBMENVG_DB_FETCH_1 */

            R0310_00_FETCH_COBMENVG_DB_FETCH_1();

            /*" -1667- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1668- MOVE 'S' TO WFIM-COBMENVG */
                _.Move("S", AREA_DE_WORK.WFIM_COBMENVG);

                /*" -1668- PERFORM R0310_00_FETCH_COBMENVG_DB_CLOSE_1 */

                R0310_00_FETCH_COBMENVG_DB_CLOSE_1();

                /*" -1671- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1673- ADD 1 TO WINDM. */
            AREA_DE_WORK.WINDM.Value = AREA_DE_WORK.WINDM + 1;

            /*" -1674- IF WINDM > 3000 */

            if (AREA_DE_WORK.WINDM > 3000)
            {

                /*" -1675- MOVE 3000 TO WINDM */
                _.Move(3000, AREA_DE_WORK.WINDM);

                /*" -1676- MOVE 'S' TO WFIM-COBMENVG */
                _.Move("S", AREA_DE_WORK.WFIM_COBMENVG);

                /*" -1676- PERFORM R0310_00_FETCH_COBMENVG_DB_CLOSE_2 */

                R0310_00_FETCH_COBMENVG_DB_CLOSE_2();

                /*" -1679- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1681- MOVE COBMENVG-NUM-APOLICE TO TABJ-APOLICE (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_APOLICE);

            /*" -1683- MOVE COBMENVG-CODSUBES TO TABJ-CODSUBES (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_CODSUBES);

            /*" -1685- MOVE COBMENVG-COD-OPERACAO TO TABJ-CODOPER (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_CODOPER);

            /*" -1687- MOVE COBMENVG-JDE TO TABJ-JDE (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_JDE);

            /*" -1689- MOVE COBMENVG-JDL TO TABJ-JDL (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_JDL);

            /*" -1692- MOVE COBMENVG-IDFORM TO TABJ-IDFORM (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_IDFORM);

            /*" -1692- GO TO R0310-00-FETCH-COBMENVG. */
            new Task(() => R0310_00_FETCH_COBMENVG_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-FETCH-1 */
        public void R0310_00_FETCH_COBMENVG_DB_FETCH_1()
        {
            /*" -1664- EXEC SQL FETCH CMSG INTO :COBMENVG-NUM-APOLICE, :COBMENVG-CODSUBES, :COBMENVG-COD-OPERACAO, :COBMENVG-JDE, :COBMENVG-JDL, :COBMENVG-IDFORM END-EXEC. */

            if (CMSG.Fetch())
            {
                _.Move(CMSG.COBMENVG_NUM_APOLICE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE);
                _.Move(CMSG.COBMENVG_CODSUBES, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES);
                _.Move(CMSG.COBMENVG_COD_OPERACAO, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);
                _.Move(CMSG.COBMENVG_JDE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);
                _.Move(CMSG.COBMENVG_JDL, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);
                _.Move(CMSG.COBMENVG_IDFORM, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-CLOSE-1 */
        public void R0310_00_FETCH_COBMENVG_DB_CLOSE_1()
        {
            /*" -1668- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-CLOSE-2 */
        public void R0310_00_FETCH_COBMENVG_DB_CLOSE_2()
        {
            /*" -1676- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }

        [StopWatch]
        /*" R0400-00-CARREGA-FCPLANO-SECTION */
        private void R0400_00_CARREGA_FCPLANO_SECTION()
        {
            /*" -1706- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -1714- PERFORM R0400_00_CARREGA_FCPLANO_DB_DECLARE_1 */

            R0400_00_CARREGA_FCPLANO_DB_DECLARE_1();

            /*" -1716- PERFORM R0400_00_CARREGA_FCPLANO_DB_OPEN_1 */

            R0400_00_CARREGA_FCPLANO_DB_OPEN_1();

            /*" -1719- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1720- DISPLAY 'VA4437B - PROBLEMAS NA FC_PLANO           ' */
                _.Display($"VA4437B - PROBLEMAS NA FC_PLANO           ");

                /*" -1722- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1723- PERFORM R0410-00-FETCH-FCPLANO UNTIL WFIM-FCPLANO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FCPLANO == "S"))
            {

                R0410_00_FETCH_FCPLANO_SECTION();
            }

        }

        [StopWatch]
        /*" R0400-00-CARREGA-FCPLANO-DB-OPEN-1 */
        public void R0400_00_CARREGA_FCPLANO_DB_OPEN_1()
        {
            /*" -1716- EXEC SQL OPEN CFCPLANO END-EXEC. */

            CFCPLANO.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-DB-DECLARE-1 */
        public void R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1()
        {
            /*" -1776- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT COD_FONTE, NOME_FONTE, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.FONTES WHERE COD_FONTE < 99 ORDER BY COD_FONTE END-EXEC. */
            V1AGENCEF = new VA4437B_V1AGENCEF(false);
            string GetQuery_V1AGENCEF()
            {
                var query = @$"SELECT 
							COD_FONTE
							, 
							NOME_FONTE
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							CEP
							, 
							SIGLA_UF 
							FROM SEGUROS.FONTES 
							WHERE COD_FONTE < 99 
							ORDER BY COD_FONTE";

                return query;
            }
            V1AGENCEF.GetQueryEvent += GetQuery_V1AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-FETCH-FCPLANO-SECTION */
        private void R0410_00_FETCH_FCPLANO_SECTION()
        {
            /*" -1737- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", WABEND.WNR_EXEC_SQL);

            /*" -1741- PERFORM R0410_00_FETCH_FCPLANO_DB_FETCH_1 */

            R0410_00_FETCH_FCPLANO_DB_FETCH_1();

            /*" -1744- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1745- MOVE 'S' TO WFIM-FCPLANO */
                _.Move("S", AREA_DE_WORK.WFIM_FCPLANO);

                /*" -1745- PERFORM R0410_00_FETCH_FCPLANO_DB_CLOSE_1 */

                R0410_00_FETCH_FCPLANO_DB_CLOSE_1();

                /*" -1748- GO TO R0410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1749- MOVE FCPLANO-QTD-DIG-COMBINACAO TO TAB-QTD-DIG (FCPLANO-NUM-PLANO). */
            _.Move(FCPLANO.DCLFC_PLANO.FCPLANO_QTD_DIG_COMBINACAO, TAB_QTD_DIG_COMBINACAO.TAB_COMB[FCPLANO.DCLFC_PLANO.FCPLANO_NUM_PLANO].TAB_QTD_DIG);

        }

        [StopWatch]
        /*" R0410-00-FETCH-FCPLANO-DB-FETCH-1 */
        public void R0410_00_FETCH_FCPLANO_DB_FETCH_1()
        {
            /*" -1741- EXEC SQL FETCH CFCPLANO INTO :FCPLANO-NUM-PLANO, :FCPLANO-QTD-DIG-COMBINACAO END-EXEC. */

            if (CFCPLANO.Fetch())
            {
                _.Move(CFCPLANO.FCPLANO_NUM_PLANO, FCPLANO.DCLFC_PLANO.FCPLANO_NUM_PLANO);
                _.Move(CFCPLANO.FCPLANO_QTD_DIG_COMBINACAO, FCPLANO.DCLFC_PLANO.FCPLANO_QTD_DIG_COMBINACAO);
            }

        }

        [StopWatch]
        /*" R0410-00-FETCH-FCPLANO-DB-CLOSE-1 */
        public void R0410_00_FETCH_FCPLANO_DB_CLOSE_1()
        {
            /*" -1745- EXEC SQL CLOSE CFCPLANO END-EXEC */

            CFCPLANO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-SECTION */
        private void R0500_00_DECLARE_AGENCCEF_SECTION()
        {
            /*" -1763- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -1776- PERFORM R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1 */

            R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1();

            /*" -1778- PERFORM R0500_00_DECLARE_AGENCCEF_DB_OPEN_1 */

            R0500_00_DECLARE_AGENCCEF_DB_OPEN_1();

            /*" -1781- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1782- DISPLAY 'R0500 - PROBLEMAS DECLARE (AGENCCEF) ..' */
                _.Display($"R0500 - PROBLEMAS DECLARE (AGENCCEF) ..");

                /*" -1783- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1783- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-DB-OPEN-1 */
        public void R0500_00_DECLARE_AGENCCEF_DB_OPEN_1()
        {
            /*" -1778- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-DECLARE-1 */
        public void R0900_00_DECLARE_RELATORI_DB_DECLARE_1()
        {
            /*" -1906- EXEC SQL DECLARE CRELAT CURSOR FOR SELECT DISTINCT A.COD_OPERACAO, A.COD_USUARIO, A.COD_RELATORIO, A.NUM_PARCELA, A.TIMESTAMP, B.DATA_QUITACAO, B.NUM_APOLICE, B.COD_SUBGRUPO, B.NUM_CERTIFICADO, B.COD_PRODUTO, B.COD_CLIENTE, B.OCOREND, B.IDE_SEXO, B.SIT_REGISTRO, B.AGE_COBRANCA, B.COD_FONTE, B.IDADE, B.OCORR_HISTORICO, B.FAIXA_RENDA_IND, B.FAIXA_RENDA_FAM, C.CODRELAT, C.PERI_PAGAMENTO ,D.COD_EMPRESA , D.DESCR_PRODUTO , D.NUM_PROCESSO_SUSEP FROM SEGUROS.RELATORIOS A, SEGUROS.PROPOSTAS_VA B, SEGUROS.PRODUTOS_VG C ,SEGUROS.PRODUTO D WHERE A.SIT_REGISTRO = '0' AND A.COD_OPERACAO IN (2, 6, 10) AND A.NUM_PARCELA = 2 AND A.DATA_SOLICITACAO > :SISTEMAS-DATA-MOV-ABERTO-15D AND B.SIT_REGISTRO <> '2' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.RAMO <> 77 AND B.COD_PRODUTO = D.COD_PRODUTO ORDER BY B.NUM_CERTIFICADO WITH UR END-EXEC. */
            CRELAT = new VA4437B_CRELAT(true);
            string GetQuery_CRELAT()
            {
                var query = @$"SELECT DISTINCT 
							A.COD_OPERACAO
							, 
							A.COD_USUARIO
							, 
							A.COD_RELATORIO
							, 
							A.NUM_PARCELA
							, 
							A.TIMESTAMP
							, 
							B.DATA_QUITACAO
							, 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.COD_PRODUTO
							, 
							B.COD_CLIENTE
							, 
							B.OCOREND
							, 
							B.IDE_SEXO
							, 
							B.SIT_REGISTRO
							, 
							B.AGE_COBRANCA
							, 
							B.COD_FONTE
							, 
							B.IDADE
							, 
							B.OCORR_HISTORICO
							, 
							B.FAIXA_RENDA_IND
							, 
							B.FAIXA_RENDA_FAM
							, 
							C.CODRELAT
							, 
							C.PERI_PAGAMENTO 
							,D.COD_EMPRESA 
							, D.DESCR_PRODUTO 
							, D.NUM_PROCESSO_SUSEP 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.PROPOSTAS_VA B
							, 
							SEGUROS.PRODUTOS_VG C 
							,SEGUROS.PRODUTO D 
							WHERE A.SIT_REGISTRO = '0' 
							AND A.COD_OPERACAO IN (2
							, 6
							, 10) 
							AND A.NUM_PARCELA = 2 
							AND A.DATA_SOLICITACAO > 
							'{SISTEMAS_DATA_MOV_ABERTO_15D}' 
							AND B.SIT_REGISTRO <> '2' 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND C.RAMO <> 77 
							AND B.COD_PRODUTO = D.COD_PRODUTO 
							ORDER BY B.NUM_CERTIFICADO";

                return query;
            }
            CRELAT.GetQueryEvent += GetQuery_CRELAT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-SECTION */
        private void R0510_00_FETCH_AGENCCEF_SECTION()
        {
            /*" -1797- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -1806- PERFORM R0510_00_FETCH_AGENCCEF_DB_FETCH_1 */

            R0510_00_FETCH_AGENCCEF_DB_FETCH_1();

            /*" -1809- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1810- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1811- MOVE 'S' TO WFIM-AGENCCEF */
                    _.Move("S", AREA_DE_WORK.WFIM_AGENCCEF);

                    /*" -1811- PERFORM R0510_00_FETCH_AGENCCEF_DB_CLOSE_1 */

                    R0510_00_FETCH_AGENCCEF_DB_CLOSE_1();

                    /*" -1813- ELSE */
                }
                else
                {


                    /*" -1813- PERFORM R0510_00_FETCH_AGENCCEF_DB_CLOSE_2 */

                    R0510_00_FETCH_AGENCCEF_DB_CLOSE_2();

                    /*" -1815- DISPLAY 'R0510 - (PROBLEMAS NO FETCH AGENCCEF) ..' */
                    _.Display($"R0510 - (PROBLEMAS NO FETCH AGENCCEF) ..");

                    /*" -1816- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1816- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-FETCH-1 */
        public void R0510_00_FETCH_AGENCCEF_DB_FETCH_1()
        {
            /*" -1806- EXEC SQL FETCH V1AGENCEF INTO :MALHACEF-COD-FONTE, :FONTES-NOME-FONTE, :FONTES-ENDERECO, :FONTES-BAIRRO, :FONTES-CIDADE, :FONTES-CEP, :FONTES-SIGLA-UF END-EXEC. */

            if (V1AGENCEF.Fetch())
            {
                _.Move(V1AGENCEF.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
                _.Move(V1AGENCEF.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
                _.Move(V1AGENCEF.FONTES_ENDERECO, FONTES.DCLFONTES.FONTES_ENDERECO);
                _.Move(V1AGENCEF.FONTES_BAIRRO, FONTES.DCLFONTES.FONTES_BAIRRO);
                _.Move(V1AGENCEF.FONTES_CIDADE, FONTES.DCLFONTES.FONTES_CIDADE);
                _.Move(V1AGENCEF.FONTES_CEP, FONTES.DCLFONTES.FONTES_CEP);
                _.Move(V1AGENCEF.FONTES_SIGLA_UF, FONTES.DCLFONTES.FONTES_SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-CLOSE-1 */
        public void R0510_00_FETCH_AGENCCEF_DB_CLOSE_1()
        {
            /*" -1811- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-CLOSE-2 */
        public void R0510_00_FETCH_AGENCCEF_DB_CLOSE_2()
        {
            /*" -1813- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0520-00-CARREGA-FILIAL-SECTION */
        private void R0520_00_CARREGA_FILIAL_SECTION()
        {
            /*" -1830- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -1832- MOVE MALHACEF-COD-FONTE TO IDX-IND1. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, AREA_DE_WORK.IDX_IND1);

            /*" -1834- MOVE MALHACEF-COD-FONTE TO TAB-FONTE (IDX-IND1) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAL.FILLER_93[AREA_DE_WORK.IDX_IND1].TAB_FONTE);

            /*" -1836- MOVE FONTES-NOME-FONTE TO TAB-NOMEFTE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, TAB_FILIAL.FILLER_93[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE);

            /*" -1838- MOVE FONTES-ENDERECO TO TAB-ENDERFTE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_ENDERECO, TAB_FILIAL.FILLER_93[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE);

            /*" -1840- MOVE FONTES-BAIRRO TO TAB-BAIRRO (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_BAIRRO, TAB_FILIAL.FILLER_93[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO);

            /*" -1842- MOVE FONTES-CIDADE TO TAB-CIDADE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_CIDADE, TAB_FILIAL.FILLER_93[AREA_DE_WORK.IDX_IND1].TAB_CIDADE);

            /*" -1844- MOVE FONTES-CEP TO TAB-CEP (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_CEP, TAB_FILIAL.FILLER_93[AREA_DE_WORK.IDX_IND1].TAB_CEP);

            /*" -1847- MOVE FONTES-SIGLA-UF TO TAB-UF (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_SIGLA_UF, TAB_FILIAL.FILLER_93[AREA_DE_WORK.IDX_IND1].TAB_UF);

            /*" -1847- PERFORM R0510-00-FETCH-AGENCCEF. */

            R0510_00_FETCH_AGENCCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-SECTION */
        private void R0900_00_DECLARE_RELATORI_SECTION()
        {
            /*" -1861- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -1906- PERFORM R0900_00_DECLARE_RELATORI_DB_DECLARE_1 */

            R0900_00_DECLARE_RELATORI_DB_DECLARE_1();

            /*" -1908- PERFORM R0900_00_DECLARE_RELATORI_DB_OPEN_1 */

            R0900_00_DECLARE_RELATORI_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-OPEN-1 */
        public void R0900_00_DECLARE_RELATORI_DB_OPEN_1()
        {
            /*" -1908- EXEC SQL OPEN CRELAT END-EXEC. */

            CRELAT.Open();

        }

        [StopWatch]
        /*" R1120-00-DECLARE-TITFEDCA-DB-DECLARE-1 */
        public void R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1()
        {
            /*" -2341- EXEC SQL DECLARE CTITFEDCA CURSOR FOR SELECT NRTITFDCAP, NRSORTEIO FROM SEGUROS.TITULOS_FED_CAP_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA > :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */
            CTITFEDCA = new VA4437B_CTITFEDCA(true);
            string GetQuery_CTITFEDCA()
            {
                var query = @$"SELECT NRTITFDCAP
							, 
							NRSORTEIO 
							FROM SEGUROS.TITULOS_FED_CAP_VA 
							WHERE NUM_CERTIFICADO = 
							'{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}' 
							AND DATA_TERVIGENCIA > '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            CTITFEDCA.GetQueryEvent += GetQuery_CTITFEDCA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-SECTION */
        private void R0910_00_FETCH_RELATORI_SECTION()
        {
            /*" -1922- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -1949- PERFORM R0910_00_FETCH_RELATORI_DB_FETCH_1 */

            R0910_00_FETCH_RELATORI_DB_FETCH_1();

            /*" -1952- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1953- DISPLAY '**** LIDOS V0RELAT    ' AC-LIDOS ' ' WHORA-CURR */

                $"**** LIDOS V0RELAT    {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();

                /*" -1954- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -1956- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1956- PERFORM R0910_00_FETCH_RELATORI_DB_CLOSE_1 */

                R0910_00_FETCH_RELATORI_DB_CLOSE_1();

                /*" -1959- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1963- ADD 1 TO AC-L-RELATORI AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_L_RELATORI.Value = AREA_DE_WORK.AC_L_RELATORI + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -1964- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -1965- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1966- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -1968- DISPLAY '**** LIDOS V0RELAT    ' AC-LIDOS ' ' WHORA-CURR. */

                $"**** LIDOS V0RELAT    {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


            /*" -1971- MOVE PROPOVA-NUM-CERTIFICADO TO WS-CERTIFICADO-ATU. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WS_CERTIFICADO_ATU);

            /*" -1972- IF VIND-RENDA-IND LESS +0 */

            if (VIND_RENDA_IND < +0)
            {

                /*" -1975- MOVE ZEROS TO PROPOVA-FAIXA-RENDA-IND PROPOVA-FAIXA-RENDA-FAM */
                _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);

                /*" -1977- END-IF. */
            }


            /*" -1978- MOVE PROPOVA-COD-PRODUTO TO W88-PRODUTO-VIDA WS-COD-PRODUTO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, W88_PRODUTO_VIDA, WS_COD_PRODUTO);

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-FETCH-1 */
        public void R0910_00_FETCH_RELATORI_DB_FETCH_1()
        {
            /*" -1949- EXEC SQL FETCH CRELAT INTO :RELATORI-COD-OPERACAO, :RELATORI-COD-USUARIO, :RELATORI-COD-RELATORIO, :RELATORI-NUM-PARCELA, :RELATORI-TIMESTAMP, :PROPOVA-DATA-QUITACAO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-PRODUTO, :PROPOVA-COD-CLIENTE, :PROPOVA-OCOREND, :PROPOVA-IDE-SEXO, :PROPOVA-SIT-REGISTRO, :PROPOVA-AGE-COBRANCA, :PROPOVA-COD-FONTE, :PROPOVA-IDADE, :PROPOVA-OCORR-HISTORICO, :PROPOVA-FAIXA-RENDA-IND:VIND-RENDA-IND, :PROPOVA-FAIXA-RENDA-FAM:VIND-RENDA-FAM, :PRODUVG-CODRELAT, :PRODUVG-PERI-PAGAMENTO ,:PRODUTO-COD-EMPRESA , :PRODUTO-DESCR-PRODUTO , :PRODUTO-NUM-PROCESSO-SUSEP END-EXEC. */

            if (CRELAT.Fetch())
            {
                _.Move(CRELAT.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(CRELAT.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(CRELAT.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(CRELAT.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(CRELAT.RELATORI_TIMESTAMP, RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP);
                _.Move(CRELAT.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CRELAT.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CRELAT.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CRELAT.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CRELAT.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(CRELAT.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CRELAT.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(CRELAT.PROPOVA_IDE_SEXO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO);
                _.Move(CRELAT.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(CRELAT.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(CRELAT.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(CRELAT.PROPOVA_IDADE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE);
                _.Move(CRELAT.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(CRELAT.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND);
                _.Move(CRELAT.VIND_RENDA_IND, VIND_RENDA_IND);
                _.Move(CRELAT.PROPOVA_FAIXA_RENDA_FAM, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);
                _.Move(CRELAT.VIND_RENDA_FAM, VIND_RENDA_FAM);
                _.Move(CRELAT.PRODUVG_CODRELAT, PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT);
                _.Move(CRELAT.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CRELAT.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
                _.Move(CRELAT.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(CRELAT.PRODUTO_NUM_PROCESSO_SUSEP, PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-CLOSE-1 */
        public void R0910_00_FETCH_RELATORI_DB_CLOSE_1()
        {
            /*" -1956- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1993- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -1994- MOVE PROPOVA-NUM-APOLICE TO WS-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);

            /*" -1995- MOVE PROPOVA-COD-SUBGRUPO TO WS-CODSUBES. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);

            /*" -1998- MOVE RELATORI-COD-OPERACAO TO WHOST-CODOPER WS-CODOPER */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, WHOST_CODOPER);
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);


            /*" -1999- IF RELATORI-COD-USUARIO EQUAL 'VA0118B' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO == "VA0118B")
            {

                /*" -2000- MOVE 'A5' TO WS-IDFORM */
                _.Move("A5", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                /*" -2001- ELSE */
            }
            else
            {


                /*" -2002- MOVE 'A4' TO WS-IDFORM */
                _.Move("A4", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                /*" -2004- END-IF. */
            }


            /*" -2005- MOVE 1 TO INF. */
            _.Move(1, AREA_DE_WORK.INF);

            /*" -2007- MOVE WINDM TO SUP. */
            _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

            /*" -2009- INITIALIZE WS-SIT-PRODUTO */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -2011- PERFORM R2320-PRODUTO-RUNOFF */

            R2320_PRODUTO_RUNOFF_SECTION();

            /*" -2017- PERFORM R2310-00-IDENTIFICA-MSG */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -2025- IF (WS-JDE NOT EQUAL 'VA82' AND 'VIDA05' AND 'VD09' AND 'VIDA18' AND 'VA54' AND 'VIDA10' ) */

            if ((!AREA_DE_WORK.WS_JDE_GER.WS_JDE.In("VA82", "VIDA05", "VD09", "VIDA18", "VA54", "VIDA10")))
            {

                /*" -2026- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2028- END-IF */
            }


            /*" -2030- PERFORM R1400-00-SELECT-HISCOBPR */

            R1400_00_SELECT_HISCOBPR_SECTION();

            /*" -2031- IF WTEM-HISCOBPR EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_HISCOBPR == "N")
            {

                /*" -2032- ADD 1 TO AC-DESPR-COBERPRO */
                AREA_DE_WORK.AC_DESPR_COBERPRO.Value = AREA_DE_WORK.AC_DESPR_COBERPRO + 1;

                /*" -2033- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2035- END-IF */
            }


            /*" -2036- PERFORM R1120-00-DECLARE-TITFEDCA */

            R1120_00_DECLARE_TITFEDCA_SECTION();

            /*" -2038- PERFORM R1130-00-FETCH-TITFEDCA */

            R1130_00_FETCH_TITFEDCA_SECTION();

            /*" -2040- IF WFIM-TITFEDCA EQUAL 'S' AND HISCOBPR-VAL-CUSTO-CAPITALI GREATER ZEROS */

            if (AREA_DE_WORK.WFIM_TITFEDCA == "S" && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI > 00)
            {

                /*" -2041- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2043- END-IF */
            }


            /*" -2045- PERFORM R1140-00-PROCESSA-TITFEDCA UNTIL WFIM-TITFEDCA = 'S' */

            while (!(AREA_DE_WORK.WFIM_TITFEDCA == "S"))
            {

                R1140_00_PROCESSA_TITFEDCA_SECTION();
            }

            /*" -2046- IF WS-CERTIFICADO-ATU NOT = WS-CERTIFICADO-ANT */

            if (WS_CERTIFICADO_ATU != WS_CERTIFICADO_ANT)
            {

                /*" -2047- MOVE WS-CERTIFICADO-ATU TO WS-CERTIFICADO-ANT */
                _.Move(WS_CERTIFICADO_ATU, WS_CERTIFICADO_ANT);

                /*" -2048- ELSE */
            }
            else
            {


                /*" -2049- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2051- END-IF */
            }


            /*" -2053- MOVE ZEROS TO WS-DUPLICADO */
            _.Move(0, WS_DUPLICADO);

            /*" -2054- IF RELATORI-COD-RELATORIO EQUAL PRODUVG-CODRELAT */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT)
            {

                /*" -2063- PERFORM R1000_00_PROCESSA_INPUT_DB_SELECT_1 */

                R1000_00_PROCESSA_INPUT_DB_SELECT_1();

                /*" -2066- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2067- MOVE ZEROS TO WS-DUPLICADO */
                    _.Move(0, WS_DUPLICADO);

                    /*" -2068- END-IF */
                }


                /*" -2070- END-IF. */
            }


            /*" -2071- IF WS-DUPLICADO > 0 */

            if (WS_DUPLICADO > 0)
            {

                /*" -2072- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2074- END-IF */
            }


            /*" -2076- PERFORM R1010-00-SELECT-SEGURVGA. */

            R1010_00_SELECT_SEGURVGA_SECTION();

            /*" -2077- IF WTEM-SEGURVGA EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_SEGURVGA == "N")
            {

                /*" -2078- ADD 1 TO AC-DESPR-SEGURAVG */
                AREA_DE_WORK.AC_DESPR_SEGURAVG.Value = AREA_DE_WORK.AC_DESPR_SEGURAVG + 1;

                /*" -2080- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2082- PERFORM R1100-00-SELECT-OPCPAGVI. */

            R1100_00_SELECT_OPCPAGVI_SECTION();

            /*" -2083- IF WTEM-OPCPAGVI EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_OPCPAGVI == "N")
            {

                /*" -2084- ADD 1 TO AC-DESPR-OPCAOPAG */
                AREA_DE_WORK.AC_DESPR_OPCAOPAG.Value = AREA_DE_WORK.AC_DESPR_OPCAOPAG + 1;

                /*" -2085- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2087- END-IF */
            }


            /*" -2089- PERFORM R1200-00-SELECT-CLIENTES. */

            R1200_00_SELECT_CLIENTES_SECTION();

            /*" -2090- IF WTEM-CLIENTES EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_CLIENTES == "N")
            {

                /*" -2091- ADD 1 TO AC-DESPR-CLIENTE */
                AREA_DE_WORK.AC_DESPR_CLIENTE.Value = AREA_DE_WORK.AC_DESPR_CLIENTE + 1;

                /*" -2093- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2097- PERFORM R1210-00-SELECT-EMAIL. */

            R1210_00_SELECT_EMAIL_SECTION();

            /*" -2098- MOVE PROPOVA-OCOREND TO WHOST-CODENDER. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND, WHOST_CODENDER);

            /*" -2099- PERFORM R1300-00-SELECT-ENDERECO. */

            R1300_00_SELECT_ENDERECO_SECTION();

            /*" -2100- IF WTEM-ENDERECO EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_ENDERECO == "N")
            {

                /*" -2101- MOVE SEGURVGA-OCORR-ENDERECO TO WHOST-CODENDER */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO, WHOST_CODENDER);

                /*" -2102- PERFORM R1300-00-SELECT-ENDERECO */

                R1300_00_SELECT_ENDERECO_SECTION();

                /*" -2103- IF WTEM-ENDERECO EQUAL 'N' */

                if (AREA_DE_WORK.WTEM_ENDERECO == "N")
                {

                    /*" -2104- ADD 1 TO AC-DESPR-ENDERECO */
                    AREA_DE_WORK.AC_DESPR_ENDERECO.Value = AREA_DE_WORK.AC_DESPR_ENDERECO + 1;

                    /*" -2105- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -2106- END-IF */
                }


                /*" -2108- END-IF */
            }


            /*" -2110- PERFORM R1500-00-SELECT-AGENCCEF. */

            R1500_00_SELECT_AGENCCEF_SECTION();

            /*" -2112- PERFORM R1600-00-SELECT-APOLICE. */

            R1600_00_SELECT_APOLICE_SECTION();

            /*" -2116- PERFORM R1640-00-SELECT-ENDOSSOS. */

            R1640_00_SELECT_ENDOSSOS_SECTION();

            /*" -2118- MOVE PROPOVA-DATA-QUITACAO TO SVA-DTQUIT. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, REG_SVA4437B.SVA_DTQUIT);

            /*" -2119- MOVE ZEROS TO SVA-PLANO. */
            _.Move(0, REG_SVA4437B.SVA_PLANO);

            /*" -2121- MOVE APOLICES-COD-CLIENTE TO SVA-CODCLIEN. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, REG_SVA4437B.SVA_CODCLIEN);

            /*" -2123- MOVE APOLICES-RAMO-EMISSOR TO SVA-RAMO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, REG_SVA4437B.SVA_RAMO);

            /*" -2124- MOVE MALHACEF-COD-FONTE TO SVA-FONTE. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, REG_SVA4437B.SVA_FONTE);

            /*" -2126- MOVE PROPOVA-NUM-CERTIFICADO TO SVA-NRCERTIF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_SVA4437B.SVA_NRCERTIF);

            /*" -2127- MOVE PROPOVA-IDE-SEXO TO SVA-IDSEXO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO, REG_SVA4437B.SVA_IDSEXO);

            /*" -2129- MOVE SEGURVGA-DATA-INIVIGENCIA TO SVA-DTINIVIG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA, REG_SVA4437B.SVA_DTINIVIG);

            /*" -2130- MOVE PROPOVA-NUM-APOLICE TO SVA-NRAPOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, REG_SVA4437B.SVA_NRAPOLICE);

            /*" -2132- MOVE PROPOVA-COD-SUBGRUPO TO SVA-CODSUBES. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, REG_SVA4437B.SVA_CODSUBES);

            /*" -2134- MOVE PROPOVA-FAIXA-RENDA-IND TO SVA-RENDA-IND */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, REG_SVA4437B.SVA_RENDA_IND);

            /*" -2136- MOVE PROPOVA-FAIXA-RENDA-FAM TO SVA-RENDA-FAM */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, REG_SVA4437B.SVA_RENDA_FAM);

            /*" -2138- MOVE PRODUVG-CODRELAT TO SVA-CODRELAT. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT, REG_SVA4437B.SVA_CODRELAT);

            /*" -2140- MOVE RELATORI-COD-RELATORIO TO SVA-CODRELATVG. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO, REG_SVA4437B.SVA_CODRELATVG);

            /*" -2141- MOVE SEGURVGA-NUM-ITEM TO SVA-NUM-ITEM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, REG_SVA4437B.SVA_NUM_ITEM);

            /*" -2143- MOVE SEGURVGA-OCORR-HISTORICO TO SVA-OCORHIST. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO, REG_SVA4437B.SVA_OCORHIST);

            /*" -2145- MOVE HISCOBPR-DATA-INIVIGENCIA TO SVA-DTMOVTO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, REG_SVA4437B.SVA_DTMOVTO);

            /*" -2147- MOVE RELATORI-COD-OPERACAO TO SVA-CODOPER */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, REG_SVA4437B.SVA_CODOPER);

            /*" -2149- MOVE RELATORI-COD-USUARIO TO SVA-CODUSU. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SVA4437B.SVA_CODUSU);

            /*" -2151- MOVE PROPOVA-SIT-REGISTRO TO SVA-SITPROP. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO, REG_SVA4437B.SVA_SITPROP);

            /*" -2153- MOVE SEGURVGA-SIT-REGISTRO TO SVA-SITSEG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO, REG_SVA4437B.SVA_SITSEG);

            /*" -2154- MOVE HISCOBPR-VLPREMIO TO SVA-VLPREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, REG_SVA4437B.SVA_VLPREMIO);

            /*" -2155- MOVE HISCOBPR-IMPSEGCDG TO SVA-IMPSEGCDG. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, REG_SVA4437B.SVA_IMPSEGCDG);

            /*" -2156- MOVE OPCPAGVI-DIA-DEBITO TO SVA-DIA-DEBITO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, REG_SVA4437B.SVA_DIA_DEBITO);

            /*" -2157- MOVE CLIENTES-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SVA4437B.SVA_NOME_RAZAO);

            /*" -2158- MOVE CLIENTES-CGCCPF TO SVA-CPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SVA4437B.SVA_CPF);

            /*" -2160- MOVE CLIENTES-DATA-NASCIMENTO TO SVA-DTNASC */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, REG_SVA4437B.SVA_DTNASC);

            /*" -2162- MOVE CLIENEMA-EMAIL TO SVA-EMAIL. */
            _.Move(CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL, REG_SVA4437B.SVA_EMAIL);

            /*" -2164- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO SVA-OPCAO-PAG */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, REG_SVA4437B.SVA_OPCAO_PAG);

            /*" -2167- MOVE PRODUVG-PERI-PAGAMENTO TO SVA-PERI-PAGAMENTO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO, REG_SVA4437B.SVA_PERI_PAGAMENTO);

            /*" -2169- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -2171- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO SVA-AGECTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, REG_SVA4437B.SVA_AGECTADEB);

                /*" -2173- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO SVA-OPRCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, REG_SVA4437B.SVA_OPRCTADEB);

                /*" -2175- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO SVA-NUMCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, REG_SVA4437B.SVA_NUMCTADEB);

                /*" -2177- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO SVA-DIGCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, REG_SVA4437B.SVA_DIGCTADEB);

                /*" -2178- ELSE */
            }
            else
            {


                /*" -2183- MOVE ZEROS TO SVA-AGECTADEB SVA-OPRCTADEB SVA-NUMCTADEB SVA-DIGCTADEB. */
                _.Move(0, REG_SVA4437B.SVA_AGECTADEB, REG_SVA4437B.SVA_OPRCTADEB, REG_SVA4437B.SVA_NUMCTADEB, REG_SVA4437B.SVA_DIGCTADEB);
            }


            /*" -2186- MOVE ENDOSSOS-DATA-TERVIGENCIA TO SVA-DTTERVIG. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_SVA4437B.SVA_DTTERVIG);

            /*" -2189- IF WHOST-DATA-TERVIG-PREMIO > ENDOSSOS-DATA-TERVIGENCIA-1 NEXT SENTENCE */

            if (WHOST_DATA_TERVIG_PREMIO > ENDOSSOS_DATA_TERVIGENCIA_1)
            {

                /*" -2190- ELSE */
            }
            else
            {


                /*" -2192- IF WHOST-DATA-TERVIG-PREMIO (6:2) < ENDOSSOS-DATA-TERVIGENCIA-1 (6:2) */

                if (WHOST_DATA_TERVIG_PREMIO.Substring(6, 2) < ENDOSSOS_DATA_TERVIGENCIA_1.Substring(6, 2))
                {

                    /*" -2194- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO WHOST-DATA-TERVIG-PREMIO (1:4) */
                    _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), WHOST_DATA_TERVIG_PREMIO, 1, 4);

                    /*" -2195- ELSE */
                }
                else
                {


                    /*" -2197- MOVE SISTEMAS-DATA-MOV-ABERTO-1 (1:4) TO WHOST-DATA-TERVIG-PREMIO (1:4) */
                    _.MoveAtPosition(SISTEMAS_DATA_MOV_ABERTO_1.Substring(1, 4), WHOST_DATA_TERVIG_PREMIO, 1, 4);

                    /*" -2198- END-IF */
                }


                /*" -2200- END-IF. */
            }


            /*" -2201- IF WHOST-DATA-TERVIG-PREMIO > ENDOSSOS-DATA-TERVIGENCIA */

            if (WHOST_DATA_TERVIG_PREMIO > ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA)
            {

                /*" -2202- MOVE '*' TO SVA-IND-VIGENCIA */
                _.Move("*", REG_SVA4437B.SVA_IND_VIGENCIA);

                /*" -2203- ELSE */
            }
            else
            {


                /*" -2204- MOVE ' ' TO SVA-IND-VIGENCIA */
                _.Move(" ", REG_SVA4437B.SVA_IND_VIGENCIA);

                /*" -2206- END-IF. */
            }


            /*" -2208- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO SVA-OPCAOPAG. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, REG_SVA4437B.SVA_OPCAOPAG);

            /*" -2209- MOVE ENDERECO-ENDERECO TO SVA-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, REG_SVA4437B.SVA_ENDERECO);

            /*" -2210- MOVE ENDERECO-BAIRRO TO SVA-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, REG_SVA4437B.SVA_BAIRRO);

            /*" -2211- MOVE ENDERECO-CIDADE TO SVA-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, REG_SVA4437B.SVA_CIDADE);

            /*" -2212- MOVE ENDERECO-SIGLA-UF TO SVA-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SVA4437B.SVA_UF);

            /*" -2214- MOVE ENDERECO-CEP TO WS-NUM-CEP-AUX. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2216- MOVE PROPOVA-COD-PRODUTO TO SVA-PRODUTO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, REG_SVA4437B.SVA_PRODUTO);

            /*" -2217- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -2218- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SVA4437B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -2219- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SVA4437B.SVA_NUM_CEP.SVA_CEP);

                /*" -2220- ELSE */
            }
            else
            {


                /*" -2221- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SVA4437B.SVA_NUM_CEP.SVA_CEP);

                /*" -2223- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL. */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SVA4437B.SVA_NUM_CEP.SVA_CEP_COMPL);
            }


            /*" -2224- IF ENDERECO-CEP EQUAL ZEROS */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP == 00)
            {

                /*" -2225- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVA4437B.SVA_CEP_G);

                /*" -2226- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVA4437B.SVA_NOME_CORREIO);

                /*" -2227- ELSE */
            }
            else
            {


                /*" -2229- PERFORM R1900-00-LOCALIZA-CEP. */

                R1900_00_LOCALIZA_CEP_SECTION();
            }


            /*" -2231- MOVE PRODUTO-COD-EMPRESA TO SVA-COD-EMPRESA. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, REG_SVA4437B.SVA_COD_EMPRESA);

            /*" -2231- RELEASE REG-SVA4437B. */
            SVA4437B.Release(REG_SVA4437B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-DB-SELECT-1 */
        public void R1000_00_PROCESSA_INPUT_DB_SELECT_1()
        {
            /*" -2063- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-DUPLICADO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND COD_OPERACAO = :RELATORI-COD-OPERACAO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND TIMESTAMP < :RELATORI-TIMESTAMP END-EXEC */

            var r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_TIMESTAMP = RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DUPLICADO, WS_DUPLICADO);
            }


        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -2235- PERFORM R0910-00-FETCH-RELATORI. */

            R0910_00_FETCH_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-SECTION */
        private void R1010_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -2246- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", WABEND.WNR_EXEC_SQL);

            /*" -2248- MOVE 'S' TO WTEM-SEGURVGA */
            _.Move("S", AREA_DE_WORK.WTEM_SEGURVGA);

            /*" -2271- PERFORM R1010_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1010_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -2274- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2275- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2276- MOVE 'N' TO WTEM-SEGURVGA */
                    _.Move("N", AREA_DE_WORK.WTEM_SEGURVGA);

                    /*" -2277- ELSE */
                }
                else
                {


                    /*" -2279- DISPLAY '*** VA4437B PROBLEMAS NO ACESSO A V0SEGURAVG ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA4437B PROBLEMAS NO ACESSO A V0SEGURAVG {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2279- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1010_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -2271- EXEC SQL SELECT SIT_REGISTRO, COD_CLIENTE, DATA_INIVIGENCIA, DATA_INIVIGENCIA + :PRODUVG-PERI-PAGAMENTO MONTHS, COD_SUBGRUPO, OCORR_ENDERECO, NUM_ITEM, OCORR_HISTORICO INTO :SEGURVGA-SIT-REGISTRO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-DATA-INIVIGENCIA, :WHOST-DATA-TERVIG-PREMIO, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
            };

            var executed_1 = R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(executed_1.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
                _.Move(executed_1.WHOST_DATA_TERVIG_PREMIO, WHOST_DATA_TERVIG_PREMIO);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_OCORR_ENDERECO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-OPCPAGVI-SECTION */
        private void R1100_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -2290- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -2292- MOVE 'S' TO WTEM-OPCPAGVI. */
            _.Move("S", AREA_DE_WORK.WTEM_OPCPAGVI);

            /*" -2309- PERFORM R1100_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R1100_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -2312- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2313- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2314- MOVE 'N' TO WTEM-OPCPAGVI */
                    _.Move("N", AREA_DE_WORK.WTEM_OPCPAGVI);

                    /*" -2315- ELSE */
                }
                else
                {


                    /*" -2316- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -2317- MOVE 'N' TO WTEM-OPCPAGVI */
                        _.Move("N", AREA_DE_WORK.WTEM_OPCPAGVI);

                        /*" -2318- ELSE */
                    }
                    else
                    {


                        /*" -2320- DISPLAY '*** VA4437B PROBLEMAS NO ACESSO A V0OPCAOPAG ' PROPOVA-NUM-CERTIFICADO */
                        _.Display($"*** VA4437B PROBLEMAS NO ACESSO A V0OPCAOPAG {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                        /*" -2320- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R1100_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -2309- EXEC SQL SELECT OPCAO_PAGAMENTO, DIA_DEBITO, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO INTO :OPCPAGVI-OPCAO-PAGAMENTO, :OPCPAGVI-DIA-DEBITO, :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB, :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB, :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB, :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGCTADEB, VIND_DIGCTADEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-DECLARE-TITFEDCA-SECTION */
        private void R1120_00_DECLARE_TITFEDCA_SECTION()
        {
            /*" -2331- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", WABEND.WNR_EXEC_SQL);

            /*" -2332- MOVE 'N' TO WFIM-TITFEDCA */
            _.Move("N", AREA_DE_WORK.WFIM_TITFEDCA);

            /*" -2334- MOVE ZEROS TO WINDC */
            _.Move(0, WINDC);

            /*" -2341- PERFORM R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1 */

            R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1();

            /*" -2343- PERFORM R1120_00_DECLARE_TITFEDCA_DB_OPEN_1 */

            R1120_00_DECLARE_TITFEDCA_DB_OPEN_1();

            /*" -2345- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2347- DISPLAY '*** VA4437B PROBLEMAS NO OPEN CTITFEDCA      ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"*** VA4437B PROBLEMAS NO OPEN CTITFEDCA      {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2347- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-00-DECLARE-TITFEDCA-DB-OPEN-1 */
        public void R1120_00_DECLARE_TITFEDCA_DB_OPEN_1()
        {
            /*" -2343- EXEC SQL OPEN CTITFEDCA END-EXEC. */

            CTITFEDCA.Open();

        }

        [StopWatch]
        /*" R2210-00-IMP-CAPITAIS-DB-DECLARE-1 */
        public void R2210_00_IMP_CAPITAIS_DB_DECLARE_1()
        {
            /*" -3920- EXEC SQL DECLARE COBER CURSOR FOR SELECT COD_COBERTURA , IMP_SEGURADA_IX , DATA_INIVIGENCIA FROM SEGUROS.VG_COBERTURAS_SUBG WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES AND SIT_COBERTURA = '0' AND COD_COBERTURA <> 12 END-EXEC. */
            COBER = new VA4437B_COBER(true);
            string GetQuery_COBER()
            {
                var query = @$"SELECT COD_COBERTURA
							, 
							IMP_SEGURADA_IX
							, 
							DATA_INIVIGENCIA 
							FROM SEGUROS.VG_COBERTURAS_SUBG 
							WHERE NUM_APOLICE = '{WHOST_NRAPOLICE}' 
							AND COD_SUBGRUPO = '{WHOST_CODSUBES}' 
							AND SIT_COBERTURA = '0' 
							AND COD_COBERTURA <> 12";

                return query;
            }
            COBER.GetQueryEvent += GetQuery_COBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1130-00-FETCH-TITFEDCA-SECTION */
        private void R1130_00_FETCH_TITFEDCA_SECTION()
        {
            /*" -2359- MOVE '1130' TO WNR-EXEC-SQL. */
            _.Move("1130", WABEND.WNR_EXEC_SQL);

            /*" -2362- PERFORM R1130_00_FETCH_TITFEDCA_DB_FETCH_1 */

            R1130_00_FETCH_TITFEDCA_DB_FETCH_1();

            /*" -2365- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2366- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2367- MOVE 'S' TO WFIM-TITFEDCA */
                    _.Move("S", AREA_DE_WORK.WFIM_TITFEDCA);

                    /*" -2367- PERFORM R1130_00_FETCH_TITFEDCA_DB_CLOSE_1 */

                    R1130_00_FETCH_TITFEDCA_DB_CLOSE_1();

                    /*" -2369- ELSE */
                }
                else
                {


                    /*" -2371- DISPLAY '*** VA4437B PROBLEMAS NO FETCH CTITFEDCA     ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA4437B PROBLEMAS NO FETCH CTITFEDCA     {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2371- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1130-00-FETCH-TITFEDCA-DB-FETCH-1 */
        public void R1130_00_FETCH_TITFEDCA_DB_FETCH_1()
        {
            /*" -2362- EXEC SQL FETCH CTITFEDCA INTO :TITFEDCA-NRTITFDCAP, :TITFEDCA-NRSORTEIO END-EXEC. */

            if (CTITFEDCA.Fetch())
            {
                _.Move(CTITFEDCA.TITFEDCA_NRTITFDCAP, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRTITFDCAP);
                _.Move(CTITFEDCA.TITFEDCA_NRSORTEIO, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO);
            }

        }

        [StopWatch]
        /*" R1130-00-FETCH-TITFEDCA-DB-CLOSE-1 */
        public void R1130_00_FETCH_TITFEDCA_DB_CLOSE_1()
        {
            /*" -2367- EXEC SQL CLOSE CTITFEDCA END-EXEC */

            CTITFEDCA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/

        [StopWatch]
        /*" R1140-00-PROCESSA-TITFEDCA-SECTION */
        private void R1140_00_PROCESSA_TITFEDCA_SECTION()
        {
            /*" -2383- MOVE '1140' TO WNR-EXEC-SQL. */
            _.Move("1140", WABEND.WNR_EXEC_SQL);

            /*" -2384- MOVE TITFEDCA-NRTITFDCAP TO WS-NRTITFDCAP */
            _.Move(TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRTITFDCAP, AREA_DE_WORK.WS_NRTITFDCAP);

            /*" -2387- MOVE WS-NRTITFDCAP(1:3) TO SVA-NUM-PLANO FCPROSUS-NUM-PLANO */
            _.Move(AREA_DE_WORK.WS_NRTITFDCAP.Substring(1, 3), REG_SVA4437B.SVA_NUM_PLANO, FCPROSUS_NUM_PLANO);

            /*" -2388- PERFORM R1145-00-SELECT-PROC-SUSEP-CAP */

            R1145_00_SELECT_PROC_SUSEP_CAP_SECTION();

            /*" -2390- MOVE FCPROSUS-COD-PROCESSO-SUSEP TO SVA-COD-SUSEPCAP */
            _.Move(FCPROSUS_COD_PROCESSO_SUSEP, REG_SVA4437B.SVA_COD_SUSEPCAP);

            /*" -2391- ADD 1 TO WINDC */
            WINDC.Value = WINDC + 1;

            /*" -2393- MOVE TITFEDCA-NRSORTEIO TO SVA-NRSORTE(WINDC). */
            _.Move(TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO, REG_SVA4437B.SVA_NRSORTE[WINDC]);

            /*" -2393- PERFORM R1130-00-FETCH-TITFEDCA. */

            R1130_00_FETCH_TITFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/

        [StopWatch]
        /*" R1145-00-SELECT-PROC-SUSEP-CAP-SECTION */
        private void R1145_00_SELECT_PROC_SUSEP_CAP_SECTION()
        {
            /*" -2405- MOVE '1145' TO WNR-EXEC-SQL. */
            _.Move("1145", WABEND.WNR_EXEC_SQL);

            /*" -2411- PERFORM R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1 */

            R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1();

            /*" -2414- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2416- DISPLAY '*** VA4437B PROBLEMAS ACESSO PROC SUSEP CAP ' FCPROSUS-NUM-PLANO */
                _.Display($"*** VA4437B PROBLEMAS ACESSO PROC SUSEP CAP {FCPROSUS_NUM_PLANO}");

                /*" -2417- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2417- END-IF. */
            }


        }

        [StopWatch]
        /*" R1145-00-SELECT-PROC-SUSEP-CAP-DB-SELECT-1 */
        public void R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1()
        {
            /*" -2411- EXEC SQL SELECT VALUE(COD_PROCESSO_SUSEP, '********************' ) INTO :FCPROSUS-COD-PROCESSO-SUSEP FROM FDRCAP.FC_PROCESSO_SUSEP WHERE NUM_PLANO= :FCPROSUS-NUM-PLANO WITH UR END-EXEC. */

            var r1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1 = new R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1()
            {
                FCPROSUS_NUM_PLANO = FCPROSUS_NUM_PLANO.ToString(),
            };

            var executed_1 = R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1.Execute(r1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCPROSUS_COD_PROCESSO_SUSEP, FCPROSUS_COD_PROCESSO_SUSEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1145_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-CLIENTES-SECTION */
        private void R1200_00_SELECT_CLIENTES_SECTION()
        {
            /*" -2428- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -2430- MOVE 'S' TO WTEM-CLIENTES. */
            _.Move("S", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -2442- PERFORM R1200_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1200_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -2445- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2446- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2447- MOVE 'N' TO WTEM-CLIENTES */
                    _.Move("N", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -2448- ELSE */
                }
                else
                {


                    /*" -2450- DISPLAY '*** VA4437B PROBLEMAS NO ACESSO A CLIENTES   ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA4437B PROBLEMAS NO ACESSO A CLIENTES   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2452- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2453- IF VIND-SEXO LESS 0 */

            if (VIND_SEXO < 0)
            {

                /*" -2456- MOVE ' ' TO CLIENTES-IDE-SEXO. */
                _.Move(" ", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
            }


            /*" -2457- IF VIND-DTNASC LESS +0 */

            if (VIND_DTNASC < +0)
            {

                /*" -2459- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
                _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                /*" -2459- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1200_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -2442- EXEC SQL SELECT NOME_RAZAO, CGCCPF, IDE_SEXO, DATA_NASCIMENTO INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-IDE-SEXO:VIND-SEXO, :CLIENTES-DATA-NASCIMENTO:VIND-DTNASC FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
                _.Move(executed_1.VIND_SEXO, VIND_SEXO);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-SELECT-EMAIL-SECTION */
        private void R1210_00_SELECT_EMAIL_SECTION()
        {
            /*" -2471- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WABEND.WNR_EXEC_SQL);

            /*" -2477- PERFORM R1210_00_SELECT_EMAIL_DB_SELECT_1 */

            R1210_00_SELECT_EMAIL_DB_SELECT_1();

            /*" -2480- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2481- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2482- MOVE SPACES TO CLIENEMA-EMAIL */
                    _.Move("", CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);

                    /*" -2483- ELSE */
                }
                else
                {


                    /*" -2485- DISPLAY '*** VA4437B PROBLEMAS NO ACESSO A CLIENEMA   ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA4437B PROBLEMAS NO ACESSO A CLIENEMA   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2485- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-EMAIL-DB-SELECT-1 */
        public void R1210_00_SELECT_EMAIL_DB_SELECT_1()
        {
            /*" -2477- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1210_00_SELECT_EMAIL_DB_SELECT_1_Query1 = new R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1.Execute(r1210_00_SELECT_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECO-SECTION */
        private void R1300_00_SELECT_ENDERECO_SECTION()
        {
            /*" -2496- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -2498- MOVE 'S' TO WTEM-ENDERECO. */
            _.Move("S", AREA_DE_WORK.WTEM_ENDERECO);

            /*" -2515- PERFORM R1300_00_SELECT_ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -2518- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2519- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2520- MOVE 'N' TO WTEM-ENDERECO */
                    _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                    /*" -2521- ELSE */
                }
                else
                {


                    /*" -2523- DISPLAY '*** VA4437B PROBLEMAS NO ACESSO A V0ENDERECO ' PROPOVA-NUM-CERTIFICADO ' ' SEGURVGA-COD-CLIENTE */

                    $"*** VA4437B PROBLEMAS NO ACESSO A V0ENDERECO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE}"
                    .Display();

                    /*" -2523- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -2515- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE AND OCORR_ENDERECO = :WHOST-CODENDER END-EXEC. */

            var r1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                WHOST_CODENDER = WHOST_CODENDER.ToString(),
            };

            var executed_1 = R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1);
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
        /*" R1400-00-SELECT-HISCOBPR-SECTION */
        private void R1400_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -2534- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -2536- MOVE 'S' TO WTEM-HISCOBPR. */
            _.Move("S", AREA_DE_WORK.WTEM_HISCOBPR);

            /*" -2555- PERFORM R1400_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1400_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -2558- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2559- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2560- MOVE 'N' TO WTEM-HISCOBPR */
                    _.Move("N", AREA_DE_WORK.WTEM_HISCOBPR);

                    /*" -2561- ELSE */
                }
                else
                {


                    /*" -2563- DISPLAY '*** VA0436B PROBLEMAS ACESSO HIS_COBER_PROPOST' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA0436B PROBLEMAS ACESSO HIS_COBER_PROPOST{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2563- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1400_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -2555- EXEC SQL SELECT DATA_INIVIGENCIA, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPSEGCDG, VLPREMIO, VAL_CUSTO_CAPITALI INTO :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLPREMIO, :HISCOBPR-VAL-CUSTO-CAPITALI FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_COD_OPERACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);
                _.Move(executed_1.HISCOBPR_OPCAO_COBERTURA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-AGENCCEF-SECTION */
        private void R1500_00_SELECT_AGENCCEF_SECTION()
        {
            /*" -2575- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -2584- PERFORM R1500_00_SELECT_AGENCCEF_DB_SELECT_1 */

            R1500_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -2587- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2588- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2589- MOVE PROPOVA-COD-FONTE TO MALHACEF-COD-FONTE */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);

                    /*" -2590- ELSE */
                }
                else
                {


                    /*" -2591- DISPLAY 'R1500 - PROBLEMAS SELECT AGENCIAS_CEF ..' */
                    _.Display($"R1500 - PROBLEMAS SELECT AGENCIAS_CEF ..");

                    /*" -2592- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -2593- DISPLAY 'AGE COBR- ' PROPOVA-AGE-COBRANCA */
                    _.Display($"AGE COBR- {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA}");

                    /*" -2593- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -2584- EXEC SQL SELECT B.COD_FONTE INTO :MALHACEF-COD-FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :PROPOVA-AGE-COBRANCA END-EXEC. */

            var r1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 = new R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1()
            {
                PROPOVA_AGE_COBRANCA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA.ToString(),
            };

            var executed_1 = R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-APOLICE-SECTION */
        private void R1600_00_SELECT_APOLICE_SECTION()
        {
            /*" -2605- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -2613- PERFORM R1600_00_SELECT_APOLICE_DB_SELECT_1 */

            R1600_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -2616- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2617- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2618- DISPLAY 'APOLICE NAO CADASTRADA ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE NAO CADASTRADA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -2619- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2620- ELSE */
                }
                else
                {


                    /*" -2622- DISPLAY 'R1600 - PROBLEMAS SELECT APOLICES  ..' SQLCODE ' ' PROPOVA-NUM-APOLICE */

                    $"R1600 - PROBLEMAS SELECT APOLICES  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                    .Display();

                    /*" -2622- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-APOLICE-DB-SELECT-1 */
        public void R1600_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -2613- EXEC SQL SELECT COD_CLIENTE, RAMO_EMISSOR INTO :APOLICES-COD-CLIENTE, :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE END-EXEC. */

            var r1600_00_SELECT_APOLICE_DB_SELECT_1_Query1 = new R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1640-00-SELECT-ENDOSSOS-SECTION */
        private void R1640_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -2634- MOVE '1640' TO WNR-EXEC-SQL. */
            _.Move("1640", WABEND.WNR_EXEC_SQL);

            /*" -2643- PERFORM R1640_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1640_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -2646- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2647- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2648- DISPLAY 'ENDOSSO NAO CADASTRAD0 ' PROPOVA-NUM-APOLICE */
                    _.Display($"ENDOSSO NAO CADASTRAD0 {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -2649- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2650- ELSE */
                }
                else
                {


                    /*" -2652- DISPLAY 'R1640 - PROBLEMAS SELECT ENDOSSOS  ..' SQLCODE ' ' PROPOVA-NUM-APOLICE */

                    $"R1640 - PROBLEMAS SELECT ENDOSSOS  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                    .Display();

                    /*" -2652- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1640-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1640_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -2643- EXEC SQL SELECT DATA_TERVIGENCIA, DATA_TERVIGENCIA - 1 YEAR INTO :ENDOSSOS-DATA-TERVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA-1 FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA_1, ENDOSSOS_DATA_TERVIGENCIA_1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1640_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-CONDITEC-SECTION */
        private void R1800_00_SELECT_CONDITEC_SECTION()
        {
            /*" -2663- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -2665- MOVE 'S' TO WTEM-CONDITEC. */
            _.Move("S", AREA_DE_WORK.WTEM_CONDITEC);

            /*" -2681- PERFORM R1800_00_SELECT_CONDITEC_DB_SELECT_1 */

            R1800_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -2684- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2685- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2686- MOVE 'N' TO WTEM-CONDITEC */
                    _.Move("N", AREA_DE_WORK.WTEM_CONDITEC);

                    /*" -2687- MOVE ZEROS TO WS-CAR-CONJUGE */
                    _.Move(0, AREA_DE_WORK.WS_CAR_CONJUGE);

                    /*" -2688- GO TO R1800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/ //GOTO
                    return;

                    /*" -2689- ELSE */
                }
                else
                {


                    /*" -2690- DISPLAY 'VA4437B - NAO ENCONTRADO NA CONDITEC ' */
                    _.Display($"VA4437B - NAO ENCONTRADO NA CONDITEC ");

                    /*" -2691- DISPLAY 'APOLICE  ' WHOST-NRAPOLICE */
                    _.Display($"APOLICE  {WHOST_NRAPOLICE}");

                    /*" -2692- DISPLAY 'SUBGRUPO ' WHOST-CODSUBES */
                    _.Display($"SUBGRUPO {WHOST_CODSUBES}");

                    /*" -2694- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2697- MOVE CONDITEC-CARREGA-CONJUGE TO WS-CAR-CONJUGE. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE, AREA_DE_WORK.WS_CAR_CONJUGE);

            /*" -2699- COMPUTE WS-CAR-CONJUGE = WS-CAR-CONJUGE / 100. */
            AREA_DE_WORK.WS_CAR_CONJUGE.Value = AREA_DE_WORK.WS_CAR_CONJUGE / 100f;

        }

        [StopWatch]
        /*" R1800-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R1800_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -2681- EXEC SQL SELECT CARREGA_CONJUGE, GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :CONDITEC-CARREGA-CONJUGE, :CONDITEC-GARAN-ADIC-IEA, :CONDITEC-GARAN-ADIC-IPA, :CONDITEC-GARAN-ADIC-IPD, :CONDITEC-GARAN-ADIC-HD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES END-EXEC. */

            var r1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1 = new R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_HD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_HD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-LOCALIZA-CEP-SECTION */
        private void R1900_00_LOCALIZA_CEP_SECTION()
        {
            /*" -2710- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", WABEND.WNR_EXEC_SQL);

            /*" -2710- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R1900_10_LOOP */

            R1900_10_LOOP();

        }

        [StopWatch]
        /*" R1900-10-LOOP */
        private void R1900_10_LOOP(bool isPerform = false)
        {
            /*" -2715- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2718- DISPLAY '*** VA4437B CEP NAO ENCONTRADO ' ENDERECO-CEP ' ' PROPOVA-NUM-CERTIFICADO */

                $"*** VA4437B CEP NAO ENCONTRADO {ENDERECO.DCLENDERECOS.ENDERECO_CEP} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -2719- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVA4437B.SVA_CEP_G);

                /*" -2720- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVA4437B.SVA_NOME_CORREIO);

                /*" -2722- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2723- MOVE TAB-FX-FIM (WIND) TO WS-SUP. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_SUP);

            /*" -2725- MOVE TAB-FX-INI (WIND) TO WS-INF. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_INF);

            /*" -2726- ADD 1 TO WS-SUP. */
            AREA_DE_WORK.WS_SUP.Value = AREA_DE_WORK.WS_SUP + 1;

            /*" -2728- SUBTRACT 1 FROM WS-INF. */
            AREA_DE_WORK.WS_INF.Value = AREA_DE_WORK.WS_INF - 1;

            /*" -2730- IF ENDERECO-CEP GREATER WS-INF AND ENDERECO-CEP LESS WS-SUP */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP > AREA_DE_WORK.WS_INF && ENDERECO.DCLENDERECOS.ENDERECO_CEP < AREA_DE_WORK.WS_SUP)
            {

                /*" -2731- MOVE TAB-FX-CEP-G (WIND) TO SVA-CEP-G */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FX_CEP_G, REG_SVA4437B.SVA_CEP_G);

                /*" -2732- MOVE TAB-FAIXAS (WIND) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS, REG_SVA4437B.SVA_NOME_CORREIO);

                /*" -2733- ELSE */
            }
            else
            {


                /*" -2734- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -2734- GO TO R1900-10-LOOP. */
                new Task(() => R1900_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1950-00-PRIMEIRO-NOME-SECTION */
        private void R1950_00_PRIMEIRO_NOME_SECTION()
        {
            /*" -2745- MOVE '1950' TO WNR-EXEC-SQL. */
            _.Move("1950", WABEND.WNR_EXEC_SQL);

            /*" -2745- MOVE 1 TO WIND-N. */
            _.Move(1, AREA_DE_WORK.WIND_N);

            /*" -0- FLUXCONTROL_PERFORM R1950_10_LOOP */

            R1950_10_LOOP();

        }

        [StopWatch]
        /*" R1950-10-LOOP */
        private void R1950_10_LOOP(bool isPerform = false)
        {
            /*" -2750- IF WIND-N GREATER 40 */

            if (AREA_DE_WORK.WIND_N > 40)
            {

                /*" -2751- DISPLAY '*** VA1436B TAB NOMES ESTOURADA ' */
                _.Display($"*** VA1436B TAB NOMES ESTOURADA ");

                /*" -2753- GO TO R1950-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2755- IF TAB-NOME (WIND-N) EQUAL SPACES AND WIND-N EQUAL 1 */

            if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N] == string.Empty && AREA_DE_WORK.WIND_N == 1)
            {

                /*" -2756- ADD 1 TO WIND-N */
                AREA_DE_WORK.WIND_N.Value = AREA_DE_WORK.WIND_N + 1;

                /*" -2757- GO TO R1950-10-LOOP */
                new Task(() => R1950_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2758- ELSE */
            }
            else
            {


                /*" -2760- IF TAB-NOME (WIND-N) EQUAL SPACES AND WIND-N EQUAL 2 */

                if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N] == string.Empty && AREA_DE_WORK.WIND_N == 2)
                {

                    /*" -2761- DISPLAY 'PRIMEIRAS POSICOES DO NOME EM BRANCO ' */
                    _.Display($"PRIMEIRAS POSICOES DO NOME EM BRANCO ");

                    /*" -2762- ADD 1 TO WIND-N */
                    AREA_DE_WORK.WIND_N.Value = AREA_DE_WORK.WIND_N + 1;

                    /*" -2764- GO TO R1950-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2765- IF TAB-NOME (WIND-N) NOT EQUAL SPACES */

            if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N] != string.Empty)
            {

                /*" -2766- MOVE TAB-NOME (WIND-N) TO TAB-NOME1 (WIND-N) */
                _.Move(TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N], TABELA_NOMES1.TAB_NOMES1_R.TAB_NOME1[AREA_DE_WORK.WIND_N]);

                /*" -2767- ADD 1 TO WIND-N */
                AREA_DE_WORK.WIND_N.Value = AREA_DE_WORK.WIND_N + 1;

                /*" -2769- GO TO R1950-10-LOOP. */
                new Task(() => R1950_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2769- MOVE ',' TO TAB-NOME1 (WIND-N). */
            _.Move(",", TABELA_NOMES1.TAB_NOMES1_R.TAB_NOME1[AREA_DE_WORK.WIND_N]);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -2780- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -2785- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE-ANT COBMENVG-NUM-APOLICE WHOST-NRAPOLICE */
            _.Move(REG_SVA4437B.SVA_NRAPOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE, WHOST_NRAPOLICE);

            /*" -2789- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT COBMENVG-CODSUBES WHOST-CODSUBES */
            _.Move(REG_SVA4437B.SVA_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES, WHOST_CODSUBES);

            /*" -2790- PERFORM R2710-00-SELECT-ESTIP */

            R2710_00_SELECT_ESTIP_SECTION();

            /*" -2792- MOVE CLIENTES-NOME-RAZAO TO LC11-ESTIPULANTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_ESTIPULANTE);

            /*" -2796- PERFORM R2715-00-SELECT-SUBESTIP */

            R2715_00_SELECT_SUBESTIP_SECTION();

            /*" -2797- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-SQL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -2798- MOVE WS-ANO-SQL TO LK-ANO-CALC */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC);

            /*" -2799- MOVE WS-MES-SQL TO LK-MES-CALC */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC);

            /*" -2801- MOVE WS-DIA-SQL TO LK-DIA-CALC */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC);

            /*" -2802- MOVE LK-DATA-CALC TO LK-DATA-SOM */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_SOM);

            /*" -2804- CALL 'PROSOCU1' USING LK-PROSOMU1 */
            _.Call("PROSOCU1", AREA_DE_WORK.LK_PROSOMU1);

            /*" -2805- MOVE LK-DIA-CALC TO WS-DIA-I */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -2806- MOVE LK-MES-CALC TO WS-MES-I */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -2807- MOVE LK-ANO-CALC TO WS-ANO-I */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC, AREA_DE_WORK.WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -2810- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", AREA_DE_WORK.WS_DATA_I.FILLERB1, AREA_DE_WORK.WS_DATA_I.FILLERB2);

            /*" -2812- MOVE WS-DATA-I TO LC11-DTPOSTAGEM */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LC11_LINHA11.LC11_DTPOSTAGEM);

            /*" -2836- PERFORM R2910-00-OBTEM-NUMERACAO */

            R2910_00_OBTEM_NUMERACAO_SECTION();

            /*" -2837- MOVE SPACES TO LC11-COD-SUSEP */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEP);

            /*" -2838- MOVE PRODUTO-NUM-PROCESSO-SUSEP TO LC11-COD-SUSEP */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP, AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEP);

            /*" -2840- MOVE PRODUTO-DESCR-PRODUTO TO LC11-NOME-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_PRODUTO);

            /*" -2842- MOVE SVA-COD-SUSEPCAP TO LC11-COD-SUSEPCAP */
            _.Move(REG_SVA4437B.SVA_COD_SUSEPCAP, AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEPCAP);

            /*" -2846- PERFORM R2010-00-PROCESSA-PRODUTO UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA4437B.SVA_NRAPOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || REG_SVA4437B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -2858- MOVE '2010' TO WNR-EXEC-SQL */
            _.Move("2010", WABEND.WNR_EXEC_SQL);

            /*" -2859- MOVE SVA-CEP-G TO WS-CEP-G-ANT */
            _.Move(REG_SVA4437B.SVA_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -2860- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT */
            _.Move(REG_SVA4437B.SVA_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -2862- MOVE ZEROS TO WS-CONTR-OBJ */
            _.Move(0, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -2867- PERFORM R2100-00-PROCESSA-CEP UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA4437B.SVA_NRAPOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || REG_SVA4437B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || REG_SVA4437B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -2879- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -2885- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -2887- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE. */
            _.Move(REG_SVA4437B.SVA_NRAPOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);

            /*" -2889- MOVE SVA-CODSUBES TO WS-CODSUBES. */
            _.Move(REG_SVA4437B.SVA_CODSUBES, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);

            /*" -2893- MOVE SVA-CODOPER TO WS-OPER-ANT WHOST-CODOPER WS-CODOPER */
            _.Move(REG_SVA4437B.SVA_CODOPER, AREA_DE_WORK.WS_OPER_ANT, WHOST_CODOPER, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);

            /*" -2894- IF SVA-CODUSU EQUAL 'VA0118B' */

            if (REG_SVA4437B.SVA_CODUSU == "VA0118B")
            {

                /*" -2895- MOVE 'A5' TO WS-IDFORM */
                _.Move("A5", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                /*" -2896- ELSE */
            }
            else
            {


                /*" -2897- MOVE 'A4' TO WS-IDFORM */
                _.Move("A4", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                /*" -2899- END-IF. */
            }


            /*" -2900- MOVE 1 TO INF */
            _.Move(1, AREA_DE_WORK.INF);

            /*" -2902- MOVE WINDM TO SUP */
            _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

            /*" -2903- MOVE SVA-COD-EMPRESA TO PRODUTO-COD-EMPRESA */
            _.Move(REG_SVA4437B.SVA_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);

            /*" -2905- MOVE SVA-PRODUTO TO PROPOVA-COD-PRODUTO WS-COD-PRODUTO */
            _.Move(REG_SVA4437B.SVA_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, WS_COD_PRODUTO);

            /*" -2907- MOVE SVA-NRCERTIF TO PROPOVA-NUM-CERTIFICADO */
            _.Move(REG_SVA4437B.SVA_NRCERTIF, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -2909- INITIALIZE WS-SIT-PRODUTO */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -2911- PERFORM R2320-PRODUTO-RUNOFF */

            R2320_PRODUTO_RUNOFF_SECTION();

            /*" -2913- PERFORM R2310-00-IDENTIFICA-MSG */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -2915- MOVE SVA-NRCERTIF TO WS-SALVA-CERTIF */
            _.Move(REG_SVA4437B.SVA_NRCERTIF, AREA_DE_WORK.WS_SALVA_CERTIF);

            /*" -2918- PERFORM R3000-00-PESQUISA-FORMULARIO */

            R3000_00_PESQUISA_FORMULARIO_SECTION();

            /*" -2919- SET W88-IMPR-CTR-RVA4437B-CIF-OK TO TRUE */
            FILLER_1["W88_IMPR_CTR_RVA4437B_CIF_OK"] = true;

            /*" -2920- SET W88-IMPR-CTR-RVA4437I-IMP-OK TO TRUE */
            FILLER_1["W88_IMPR_CTR_RVA4437I_IMP_OK"] = true;

            /*" -2921- SET W88-IMPR-CTR-RVA4437P-PDF-OK TO TRUE */
            FILLER_1["W88_IMPR_CTR_RVA4437P_PDF_OK"] = true;

            /*" -2923- SET W88-IMPR-CTR-RVA4437H-HTML-OK TO TRUE */
            FILLER_1["W88_IMPR_CTR_RVA4437H_HTML_OK"] = true;

            /*" -2924- SET W88-IMPRESS-RVA4437B-CIF-NOK TO TRUE */
            FILLER_0["W88_IMPRESS_RVA4437B_CIF_NOK"] = true;

            /*" -2925- SET W88-IMPRESS-RVA4437I-IMP-NOK TO TRUE */
            FILLER_0["W88_IMPRESS_RVA4437I_IMP_NOK"] = true;

            /*" -2926- SET W88-IMPRESS-RVA4437P-PDF-NOK TO TRUE */
            FILLER_0["W88_IMPRESS_RVA4437P_PDF_NOK"] = true;

            /*" -2929- SET W88-IMPRESS-RVA4437H-HTML-NOK TO TRUE */
            FILLER_0["W88_IMPRESS_RVA4437H_HTML_NOK"] = true;

            /*" -2938- PERFORM R2200-00-PROCESSA-FAC UNTIL SVA-NRAPOLICE NOT = WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT = WS-CODSUBES-ANT OR SVA-CEP-G NOT = WS-CEP-G-ANT OR WFIM-SORT = 'S' OR AC-CONTA1 > 199 OR SVA-CODOPER NOT = WS-OPER-ANT. */

            while (!(REG_SVA4437B.SVA_NRAPOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || REG_SVA4437B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || REG_SVA4437B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199 || REG_SVA4437B.SVA_CODOPER != AREA_DE_WORK.WS_OPER_ANT))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

            /*" -2939- IF W88-IMPRESS-RVA4437B-CIF-OK */

            if (FILLER_0["W88_IMPRESS_RVA4437B_CIF_OK"])
            {

                /*" -2940- WRITE RVA4437B-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA4437B_RECORD);

                RVA4437B.Write(RVA4437B_RECORD.GetMoveValues().ToString());

                /*" -2941- END-IF */
            }


            /*" -2942- IF W88-IMPRESS-RVA4437I-IMP-OK */

            if (FILLER_0["W88_IMPRESS_RVA4437I_IMP_OK"])
            {

                /*" -2943- WRITE RVA4437I-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA4437I_RECORD);

                RVA4437I.Write(RVA4437I_RECORD.GetMoveValues().ToString());

                /*" -2944- END-IF */
            }


            /*" -2945- IF W88-IMPRESS-RVA4437P-PDF-OK */

            if (FILLER_0["W88_IMPRESS_RVA4437P_PDF_OK"])
            {

                /*" -2946- WRITE RVA4437P-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA4437P_RECORD);

                RVA4437P.Write(RVA4437P_RECORD.GetMoveValues().ToString());

                /*" -2947- END-IF */
            }


            /*" -2948- IF W88-IMPRESS-RVA4437H-HTML-OK */

            if (FILLER_0["W88_IMPRESS_RVA4437H_HTML_OK"])
            {

                /*" -2949- WRITE RVA4437H-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA4437H_RECORD);

                RVA4437H.Write(RVA4437H_RECORD.GetMoveValues().ToString());

                /*" -2950- END-IF */
            }


            /*" -2950- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -2961- MOVE '2200' TO WNR-EXEC-SQL */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -2962- MOVE SVA-NRAPOLICE TO LC11-APOLICE */
            _.Move(REG_SVA4437B.SVA_NRAPOLICE, AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE);

            /*" -2963- MOVE SVA-RENDA-IND TO LC11-RENDA-IND */
            _.Move(REG_SVA4437B.SVA_RENDA_IND, AREA_DE_WORK.LC11_LINHA11.LC11_RENDA_IND);

            /*" -2964- MOVE SVA-RENDA-FAM TO LC11-RENDA-FAM */
            _.Move(REG_SVA4437B.SVA_RENDA_FAM, AREA_DE_WORK.LC11_LINHA11.LC11_RENDA_FAM);

            /*" -2965- MOVE SVA-EMAIL TO LC11-EMAIL */
            _.Move(REG_SVA4437B.SVA_EMAIL, AREA_DE_WORK.LC11_LINHA11.LC11_EMAIL);

            /*" -2966- MOVE SVA-IDSEXO TO LC11-SEXO */
            _.Move(REG_SVA4437B.SVA_IDSEXO, AREA_DE_WORK.LC11_LINHA11.LC11_SEXO);

            /*" -2967- MOVE SVA-PRODUTO TO LC11-COD-PRODUTO */
            _.Move(REG_SVA4437B.SVA_PRODUTO, AREA_DE_WORK.LC11_LINHA11.LC11_COD_PRODUTO);

            /*" -2968- IF SVA-OPCAO-PAG EQUAL '1' OR '2' */

            if (REG_SVA4437B.SVA_OPCAO_PAG.In("1", "2"))
            {

                /*" -2969- MOVE 'DEBITO EM CONTA' TO LC11-OPCAO-PAG */
                _.Move("DEBITO EM CONTA", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                /*" -2970- ELSE */
            }
            else
            {


                /*" -2971- IF SVA-OPCAO-PAG EQUAL '2' */

                if (REG_SVA4437B.SVA_OPCAO_PAG == "2")
                {

                    /*" -2972- MOVE 'BOLETO' TO LC11-OPCAO-PAG */
                    _.Move("BOLETO", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                    /*" -2973- ELSE */
                }
                else
                {


                    /*" -2974- IF SVA-OPCAO-PAG EQUAL '3' */

                    if (REG_SVA4437B.SVA_OPCAO_PAG == "3")
                    {

                        /*" -2975- MOVE 'CARTAO DE CREDITO' TO LC11-OPCAO-PAG */
                        _.Move("CARTAO DE CREDITO", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                        /*" -2976- ELSE */
                    }
                    else
                    {


                        /*" -2978- MOVE 'OUTROS' TO LC11-OPCAO-PAG. */
                        _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);
                    }

                }

            }


            /*" -2980- INITIALIZE LC11-SORTE */
            _.Initialize(
                AREA_DE_WORK.LC11_LINHA11.LC11_SORTE
            );

            /*" -2984- MOVE SVA-PRODUTO TO W88-PRODUTO-VIDA WS-COD-PRODUTO */
            _.Move(REG_SVA4437B.SVA_PRODUTO, W88_PRODUTO_VIDA, WS_COD_PRODUTO);

            /*" -2991- IF W88-PRODUTO-VIDA = 9314 OR JVPRD9314 OR 9328 OR JVPRD9328 OR 9334 OR JVPRD9334 OR 9357 OR JVPRD9357 OR 9358 OR JVPRD9358 OR 9703 OR 9705 */

            if (W88_PRODUTO_VIDA.In("9314", JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9334", JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9358", JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), "9703", "9705"))
            {

                /*" -2992- MOVE 'NAO CONTEMPLA' TO LC11-SORTE-R */
                _.Move("NAO CONTEMPLA", AREA_DE_WORK.LC11_LINHA11.LC11_SORTE_R);

                /*" -2993- ELSE */
            }
            else
            {


                /*" -2994- IF (SVA-NUM-PLANO GREATER ZEROS) */

                if ((REG_SVA4437B.SVA_NUM_PLANO > 00))
                {

                    /*" -2995- MOVE TAB-QTD-DIG(SVA-NUM-PLANO) TO I2 */
                    _.Move(TAB_QTD_DIG_COMBINACAO.TAB_COMB[REG_SVA4437B.SVA_NUM_PLANO].TAB_QTD_DIG, I2);

                    /*" -2996- SUBTRACT TAB-QTD-DIG(SVA-NUM-PLANO) FROM 9 GIVING WPI */
                    WPI.Value = 9 - TAB_QTD_DIG_COMBINACAO.TAB_COMB[REG_SVA4437B.SVA_NUM_PLANO].TAB_QTD_DIG;

                    /*" -2997- ADD 1 TO WPI */
                    WPI.Value = WPI + 1;

                    /*" -2999- MOVE ZEROS TO I1 */
                    _.Move(0, I1);

                    /*" -3000- PERFORM UNTIL I1 GREATER 5 */

                    while (!(I1 > 5))
                    {

                        /*" -3001- ADD 1 TO I1 */
                        I1.Value = I1 + 1;

                        /*" -3002- IF (SVA-NRSORTE(I1) GREATER ZEROS) */

                        if ((REG_SVA4437B.SVA_NRSORTE[I1] > 00))
                        {

                            /*" -3003- MOVE SVA-NRSORTE(I1) TO WS-NRSORTE */
                            _.Move(REG_SVA4437B.SVA_NRSORTE[I1], AREA_DE_WORK.WS_NRSORTE);

                            /*" -3004- MOVE WS-NRSORTE(WPI:I2) TO LC11-NRSORTE(I1) */
                            _.Move(AREA_DE_WORK.WS_NRSORTE.Substring(WPI, I2), AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[I1].LC11_NRSORTE);

                            /*" -3005- ELSE */
                        }
                        else
                        {


                            /*" -3006- MOVE 6 TO I1 */
                            _.Move(6, I1);

                            /*" -3007- END-IF */
                        }


                        /*" -3008- END-PERFORM */
                    }

                    /*" -3010- END-IF */
                }


                /*" -3012- MOVE ZEROS TO I1 */
                _.Move(0, I1);

                /*" -3013- PERFORM UNTIL I1 GREATER 5 */

                while (!(I1 > 5))
                {

                    /*" -3014- ADD 1 TO I1 */
                    I1.Value = I1 + 1;

                    /*" -3015- MOVE '|' TO LC11-NRSORTE-S(I1) */
                    _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[I1].LC11_NRSORTE_S);

                    /*" -3016- END-PERFORM */
                }

                /*" -3043- END-IF. */
            }


            /*" -3044- MOVE SVA-DTNASC TO WS-DTNASC */
            _.Move(REG_SVA4437B.SVA_DTNASC, AREA_DE_WORK.WS_DTNASC);

            /*" -3047- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DTMOVABE */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DTMOVABE);

            /*" -3051- SUBTRACT WS-ANO-DTNASC FROM WS-ANO-DTMOVABE GIVING WS-IDADE */
            AREA_DE_WORK.WS_IDADE.Value = AREA_DE_WORK.WS_DTMOVABE_R.WS_ANO_DTMOVABE - AREA_DE_WORK.WS_DTNASC_R.WS_ANO_DTNASC;

            /*" -3053- IF WS-MES-DTNASC LESS OR EQUAL WS-ANO-DTMOVABE */

            if (AREA_DE_WORK.WS_DTNASC_R.WS_MES_DTNASC <= AREA_DE_WORK.WS_DTMOVABE_R.WS_ANO_DTMOVABE)
            {

                /*" -3055- ADD 1 TO WS-IDADE. */
                AREA_DE_WORK.WS_IDADE.Value = AREA_DE_WORK.WS_IDADE + 1;
            }


            /*" -3057- MOVE WS-IDADE TO LC11-IDADE. */
            _.Move(AREA_DE_WORK.WS_IDADE, AREA_DE_WORK.LC11_LINHA11.LC11_IDADE);

            /*" -3058- MOVE SVA-DTNASC(1:4) TO LC11-DAT-NASC(7:4) */
            _.MoveAtPosition(REG_SVA4437B.SVA_DTNASC.Substring(1, 4), AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 7, 4);

            /*" -3059- MOVE '/' TO LC11-DAT-NASC(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 3, 1);

            /*" -3060- MOVE SVA-DTNASC(6:2) TO LC11-DAT-NASC(4:2) */
            _.MoveAtPosition(REG_SVA4437B.SVA_DTNASC.Substring(6, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 4, 2);

            /*" -3061- MOVE '/' TO LC11-DAT-NASC(6:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 6, 1);

            /*" -3063- MOVE SVA-DTNASC(9:2) TO LC11-DAT-NASC(1:2) */
            _.MoveAtPosition(REG_SVA4437B.SVA_DTNASC.Substring(9, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 1, 2);

            /*" -3068- MOVE SVA-NRCERTIF TO WS-CERTIF WHOST-NRCERTIF */
            _.Move(REG_SVA4437B.SVA_NRCERTIF, AREA_DE_WORK.WS_CERTIF, WHOST_NRCERTIF);

            /*" -3069- IF SVA-SITSEG NOT EQUAL '0' */

            if (REG_SVA4437B.SVA_SITSEG != "0")
            {

                /*" -3070- MOVE SVA-CODUSU TO WHOST-CODUSU */
                _.Move(REG_SVA4437B.SVA_CODUSU, WHOST_CODUSU);

                /*" -3071- PERFORM R2205-00-SELECT-USUARIOS */

                R2205_00_SELECT_USUARIOS_SECTION();

                /*" -3072- IF WTEM-USUARIOS EQUAL 'N' */

                if (AREA_DE_WORK.WTEM_USUARIOS == "N")
                {

                    /*" -3073- ADD 1 TO AC-DESPR-CANCEL */
                    AREA_DE_WORK.AC_DESPR_CANCEL.Value = AREA_DE_WORK.AC_DESPR_CANCEL + 1;

                    /*" -3075- GO TO R2200-35-ATU-RELATORI. */

                    R2200_35_ATU_RELATORI(); //GOTO
                    return;
                }

            }


            /*" -3076- MOVE SVA-TIPOSEGU TO WHOST-TIPOSEGU */
            _.Move(REG_SVA4437B.SVA_TIPOSEGU, WHOST_TIPOSEGU);

            /*" -3077- MOVE WS-NRCERTIF TO LC11-NRCERTIF */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_NRCERTIF, AREA_DE_WORK.LC11_LINHA11.LC11_NRCERTIF);

            /*" -3078- MOVE WS-DVCERTIF TO LC11-DVCERTIF */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_DVCERTIF, AREA_DE_WORK.LC11_LINHA11.LC11_DVCERTIF);

            /*" -3079- MOVE SVA-DTINIVIG TO WS-DATA-SQL */
            _.Move(REG_SVA4437B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_SQL);

            /*" -3080- MOVE WS-ANO-SQL TO WS-ANO-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, AREA_DE_WORK.WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3081- MOVE WS-MES-SQL TO WS-MES-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -3082- MOVE WS-DIA-SQL TO WS-DIA-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -3084- MOVE WS-DATA-I TO LC11-DTINIVIG */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LC11_LINHA11.LC11_DTINIVIG);

            /*" -3088- MOVE SPACES TO TABELA-NOMES TABELA-NOMES1 LC11-CLIENTE */
            _.Move("", TABELA_NOMES, TABELA_NOMES1, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);

            /*" -3092- MOVE SPACES TO TABELA-NOMES-SOC TABELA-NOMES1-SOC LC11-CLIENTE-SOC. */
            _.Move("", TABELA_NOMES_SOC, TABELA_NOMES1_SOC, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

            /*" -3094- MOVE SVA-NOME-RAZAO TO LC11-NOME-RAZAO TAB-NOMES */
            _.Move(REG_SVA4437B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO, TABELA_NOMES.TAB_NOMES);

            /*" -3096- PERFORM R1950-00-PRIMEIRO-NOME. */

            R1950_00_PRIMEIRO_NOME_SECTION();

            /*" -3098- PERFORM R4000-00-BUSCA-NOM-SOCIAL. */

            R4000_00_BUSCA_NOM_SOCIAL_SECTION();

            /*" -3101- MOVE LC11-NOME-RAZAO-SOC TO TAB-NOMES-SOC TAB-NOMES1-SOC */
            _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_SOC, TABELA_NOMES_SOC.TAB_NOMES_SOC, TABELA_NOMES1_SOC.TAB_NOMES1_SOC);

            /*" -3103- PERFORM R4100-00-PRIMEIRO-NOME-SOCIAL. */

            R4100_00_PRIMEIRO_NOME_SOCIAL_SECTION();

            /*" -3107- MOVE TABELA-NOMES1-SOC TO LC11-CLIENTE-SOC */
            _.Move(TABELA_NOMES1_SOC, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

            /*" -3108- IF SVA-IDSEXO = 'F' */

            if (REG_SVA4437B.SVA_IDSEXO == "F")
            {

                /*" -3111- STRING ' ' TAB-NOMES1 DELIMITED BY '  ' INTO LC11-CLIENTE */
                #region STRING
                var spl1 = " " + TABELA_NOMES1.TAB_NOMES1.GetMoveValues().Split("  ").FirstOrDefault();
                _.Move(spl1, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);
                #endregion

                /*" -3112- ELSE */
            }
            else
            {


                /*" -3113- IF SVA-IDSEXO = 'M' */

                if (REG_SVA4437B.SVA_IDSEXO == "M")
                {

                    /*" -3116- STRING ' ' TAB-NOMES1 DELIMITED BY '  ' INTO LC11-CLIENTE */
                    #region STRING
                    var spl2 = " " + TABELA_NOMES1.TAB_NOMES1.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl2, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);
                    #endregion

                    /*" -3117- ELSE */
                }
                else
                {


                    /*" -3121- STRING ' ' TAB-NOMES1 DELIMITED BY '  ' INTO LC11-CLIENTE. */
                    #region STRING
                    var spl3 = " " + TABELA_NOMES1.TAB_NOMES1.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl3, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);
                    #endregion
                }

            }


            /*" -3122- MOVE SVA-CPF TO WS-CPF */
            _.Move(REG_SVA4437B.SVA_CPF, AREA_DE_WORK.WS_CPF);

            /*" -3123- MOVE WS-NRCPF TO LC11-NRCPF */
            _.Move(AREA_DE_WORK.WS_CPF_R.WS_NRCPF, AREA_DE_WORK.LC11_LINHA11.LC11_NRCPF);

            /*" -3127- MOVE WS-DVCPF TO LC11-DVCPF. */
            _.Move(AREA_DE_WORK.WS_CPF_R.WS_DVCPF, AREA_DE_WORK.LC11_LINHA11.LC11_DVCPF);

            /*" -3128- IF SVA-IDSEXO = 'F' */

            if (REG_SVA4437B.SVA_IDSEXO == "F")
            {

                /*" -3130- STRING ' ' TAB-NOMES1-SOC DELIMITED BY '  ' INTO LC11-CLIENTE-SOC */
                #region STRING
                var spl4 = " " + TABELA_NOMES1_SOC.TAB_NOMES1_SOC.GetMoveValues().Split("  ").FirstOrDefault();
                _.Move(spl4, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);
                #endregion

                /*" -3131- ELSE */
            }
            else
            {


                /*" -3132- IF SVA-IDSEXO = 'M' */

                if (REG_SVA4437B.SVA_IDSEXO == "M")
                {

                    /*" -3134- STRING ' ' TAB-NOMES1-SOC DELIMITED BY '  ' INTO LC11-CLIENTE-SOC */
                    #region STRING
                    var spl5 = " " + TABELA_NOMES1_SOC.TAB_NOMES1_SOC.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl5, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);
                    #endregion

                    /*" -3135- ELSE */
                }
                else
                {


                    /*" -3137- STRING ' ' TAB-NOMES1-SOC DELIMITED BY '  ' INTO LC11-CLIENTE-SOC */
                    #region STRING
                    var spl6 = " " + TABELA_NOMES1_SOC.TAB_NOMES1_SOC.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl6, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);
                    #endregion

                    /*" -3138- END-IF */
                }


                /*" -3143- END-IF */
            }


            /*" -3165- MOVE ZEROS TO LK-APOLICE LK-SUBGRUPO LK-IDADE LK-SALARIO LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-RETURN-CODE */
            _.Move(0, PARAMETROS.LK_APOLICE, PARAMETROS.LK_SUBGRUPO, PARAMETROS.LK_IDADE, PARAMETROS.LK_SALARIO, PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE, PARAMETROS.LK_COBT_ASS_MEDICA, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_INTERNACAO, PARAMETROS.LK_PREM_MORTE_NATURAL, PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS, PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_RETURN_CODE);

            /*" -3169- MOVE SPACES TO LK-NASCIMENTO LK-MENSAGEM. */
            _.Move("", PARAMETROS.LK_NASCIMENTO, PARAMETROS.LK_MENSAGEM);

            /*" -3170- MOVE SVA-NRAPOLICE TO LK-APOLICE. */
            _.Move(REG_SVA4437B.SVA_NRAPOLICE, PARAMETROS.LK_APOLICE);

            /*" -3172- MOVE SVA-CODSUBES TO LK-SUBGRUPO. */
            _.Move(REG_SVA4437B.SVA_CODSUBES, PARAMETROS.LK_SUBGRUPO);

            /*" -3174- MOVE '220A' TO WNR-EXEC-SQL. */
            _.Move("220A", WABEND.WNR_EXEC_SQL);

            /*" -3176- PERFORM R2800-00-SELECT-SEGURVGA. */

            R2800_00_SELECT_SEGURVGA_SECTION();

            /*" -3178- MOVE '220B' TO WNR-EXEC-SQL. */
            _.Move("220B", WABEND.WNR_EXEC_SQL);

            /*" -3190- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_1 */

            R2200_00_PROCESSA_FAC_DB_SELECT_1();

            /*" -3193- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3194- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3195- ADD 1 TO AC-DESPR-SEGVGAPH */
                    AREA_DE_WORK.AC_DESPR_SEGVGAPH.Value = AREA_DE_WORK.AC_DESPR_SEGVGAPH + 1;

                    /*" -3196- GO TO R2200-40-NEXT */

                    R2200_40_NEXT(); //GOTO
                    return;

                    /*" -3197- ELSE */
                }
                else
                {


                    /*" -3199- DISPLAY 'ERRO ACESSO SEGURADOSVGAP_HIST ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO SEGURADOSVGAP_HIST {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3200- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA4437B.SVA_NRCERTIF}");

                    /*" -3201- ADD 1 TO AC-DESPR-SEGVGAPH */
                    AREA_DE_WORK.AC_DESPR_SEGVGAPH.Value = AREA_DE_WORK.AC_DESPR_SEGVGAPH + 1;

                    /*" -3203- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3204- IF VIND-CODMOEDA-I < 0 */

            if (VIND_CODMOEDA_I < 0)
            {

                /*" -3207- MOVE 17 TO SEGVGAPH-COD-MOEDA-PRM. */
                _.Move(17, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM);
            }


            /*" -3209- MOVE '220C' TO WNR-EXEC-SQL. */
            _.Move("220C", WABEND.WNR_EXEC_SQL);

            /*" -3219- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_2 */

            R2200_00_PROCESSA_FAC_DB_SELECT_2();

            /*" -3222- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3223- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3224- ADD 1 TO AC-DESPR-MOEDACOT */
                    AREA_DE_WORK.AC_DESPR_MOEDACOT.Value = AREA_DE_WORK.AC_DESPR_MOEDACOT + 1;

                    /*" -3225- GO TO R2200-40-NEXT */

                    R2200_40_NEXT(); //GOTO
                    return;

                    /*" -3226- ELSE */
                }
                else
                {


                    /*" -3230- DISPLAY 'ERRO ACESSO MOEDAS_COTACAO     ' SQLCODE ' ' SEGVGAPH-COD-MOEDA-PRM ' ' SEGVGAPH-DATA-MOVIMENTO ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO MOEDAS_COTACAO     {DB.SQLCODE} {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM} {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3231- ADD 1 TO AC-DESPR-MOEDACOT */
                    AREA_DE_WORK.AC_DESPR_MOEDACOT.Value = AREA_DE_WORK.AC_DESPR_MOEDACOT + 1;

                    /*" -3233- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3235- PERFORM R2230-00-SELECT-APOLICE. */

            R2230_00_SELECT_APOLICE_SECTION();

            /*" -3237- MOVE '220D' TO WNR-EXEC-SQL. */
            _.Move("220D", WABEND.WNR_EXEC_SQL);

            /*" -3255- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_3 */

            R2200_00_PROCESSA_FAC_DB_SELECT_3();

            /*" -3258- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3259- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3263- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-VG APOLICOB-PRM-TARIFARIO-VG APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_VG, APOLICOB_PRM_TARIFARIO_VG, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3264- ELSE */
                }
                else
                {


                    /*" -3266- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS 77/93' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS 77/93{DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3267- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA4437B.SVA_NRCERTIF}");

                    /*" -3268- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3270- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3275- COMPUTE APOLICOB-IMP-SEGURADA-VG = APOLICOB-IMP-SEGURADA-VG * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_VG.Value = APOLICOB_IMP_SEGURADA_VG * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3280- COMPUTE APOLICOB-PRM-TARIFARIO-VG = APOLICOB-PRM-TARIFARIO-VG * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_PRM_TARIFARIO_VG.Value = APOLICOB_PRM_TARIFARIO_VG * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3282- MOVE '220E' TO WNR-EXEC-SQL. */
            _.Move("220E", WABEND.WNR_EXEC_SQL);

            /*" -3300- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_4 */

            R2200_00_PROCESSA_FAC_DB_SELECT_4();

            /*" -3303- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3304- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3308- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-AP APOLICOB-PRM-TARIFARIO-AP APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_AP, APOLICOB_PRM_TARIFARIO_AP, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3309- ELSE */
                }
                else
                {


                    /*" -3312- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-01 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-01 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3313- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA4437B.SVA_NRCERTIF}");

                    /*" -3314- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3316- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3321- COMPUTE APOLICOB-IMP-SEGURADA-AP = APOLICOB-IMP-SEGURADA-AP * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_AP.Value = APOLICOB_IMP_SEGURADA_AP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3326- COMPUTE APOLICOB-PRM-TARIFARIO-AP = APOLICOB-PRM-TARIFARIO-AP * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_PRM_TARIFARIO_AP.Value = APOLICOB_PRM_TARIFARIO_AP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3327- IF SVA-VLPREMIO EQUAL ZEROS */

            if (REG_SVA4437B.SVA_VLPREMIO == 00)
            {

                /*" -3331- COMPUTE SVA-VLPREMIO = APOLICOB-PRM-TARIFARIO-VG + APOLICOB-PRM-TARIFARIO-AP. */
                REG_SVA4437B.SVA_VLPREMIO.Value = APOLICOB_PRM_TARIFARIO_VG + APOLICOB_PRM_TARIFARIO_AP;
            }


            /*" -3333- MOVE '220F' TO WNR-EXEC-SQL. */
            _.Move("220F", WABEND.WNR_EXEC_SQL);

            /*" -3349- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_5 */

            R2200_00_PROCESSA_FAC_DB_SELECT_5();

            /*" -3352- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3353- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3356- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-IP APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_IP, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3357- ELSE */
                }
                else
                {


                    /*" -3360- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-02 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-02 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3361- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA4437B.SVA_NRCERTIF}");

                    /*" -3362- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3364- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3369- COMPUTE APOLICOB-IMP-SEGURADA-IP = APOLICOB-IMP-SEGURADA-IP * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_IP.Value = APOLICOB_IMP_SEGURADA_IP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3371- MOVE '220G' TO WNR-EXEC-SQL. */
            _.Move("220G", WABEND.WNR_EXEC_SQL);

            /*" -3387- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_6 */

            R2200_00_PROCESSA_FAC_DB_SELECT_6();

            /*" -3390- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3391- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3394- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-AMDS APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_AMDS, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3395- ELSE */
                }
                else
                {


                    /*" -3398- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-03 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-03 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3399- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA4437B.SVA_NRCERTIF}");

                    /*" -3400- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3402- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3407- COMPUTE APOLICOB-IMP-SEGURADA-AMDS = APOLICOB-IMP-SEGURADA-AMDS * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_AMDS.Value = APOLICOB_IMP_SEGURADA_AMDS * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3409- MOVE '220H' TO WNR-EXEC-SQL. */
            _.Move("220H", WABEND.WNR_EXEC_SQL);

            /*" -3425- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_7 */

            R2200_00_PROCESSA_FAC_DB_SELECT_7();

            /*" -3428- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3429- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3432- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-DH APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_DH, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3433- ELSE */
                }
                else
                {


                    /*" -3436- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-04 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-04 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3437- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA4437B.SVA_NRCERTIF}");

                    /*" -3438- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3440- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3445- COMPUTE APOLICOB-IMP-SEGURADA-DH = APOLICOB-IMP-SEGURADA-DH * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_DH.Value = APOLICOB_IMP_SEGURADA_DH * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3447- MOVE '220I' TO WNR-EXEC-SQL. */
            _.Move("220I", WABEND.WNR_EXEC_SQL);

            /*" -3463- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_8 */

            R2200_00_PROCESSA_FAC_DB_SELECT_8();

            /*" -3466- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3467- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3470- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-DIT APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_DIT, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3471- ELSE */
                }
                else
                {


                    /*" -3474- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-05 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-05 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3475- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA4437B.SVA_NRCERTIF}");

                    /*" -3476- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3478- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3485- COMPUTE APOLICOB-IMP-SEGURADA-DIT = APOLICOB-IMP-SEGURADA-DIT * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_DIT.Value = APOLICOB_IMP_SEGURADA_DIT * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3487- MOVE APOLICOB-IMP-SEGURADA-VG TO LK-PURO-MORTE-NATURAL */
            _.Move(APOLICOB_IMP_SEGURADA_VG, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -3489- MOVE APOLICOB-IMP-SEGURADA-AP TO LK-PURO-MORTE-ACIDENTAL */
            _.Move(APOLICOB_IMP_SEGURADA_AP, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -3491- MOVE APOLICOB-IMP-SEGURADA-IP TO LK-PURO-INV-PERMANENTE */
            _.Move(APOLICOB_IMP_SEGURADA_IP, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -3493- MOVE APOLICOB-IMP-SEGURADA-AMDS TO LK-PURO-ASS-MEDICA */
            _.Move(APOLICOB_IMP_SEGURADA_AMDS, PARAMETROS.LK_PURO_ASS_MEDICA);

            /*" -3495- MOVE APOLICOB-IMP-SEGURADA-DH TO LK-PURO-DIARIA-HOSPITALAR */
            _.Move(APOLICOB_IMP_SEGURADA_DH, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR);

            /*" -3498- MOVE APOLICOB-IMP-SEGURADA-DIT TO LK-PURO-DIARIA-INTERNACAO */
            _.Move(APOLICOB_IMP_SEGURADA_DIT, PARAMETROS.LK_PURO_DIARIA_INTERNACAO);

            /*" -3500- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -3501- MOVE LK-RETURN-CODE TO WS-RETURN-CODE. */
            _.Move(PARAMETROS.LK_RETURN_CODE, WS_RETURN_CODE);

            /*" -3503- MOVE WS-RETURN-CODE TO WS-RETURN-CODE-M. */
            _.Move(WS_RETURN_CODE, WS_RETURN_CODE_M);

            /*" -3504- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK_RETURN_CODE != 00)
            {

                /*" -3505- DISPLAY 'ERRO SUBROTINA VG0710S ' */
                _.Display($"ERRO SUBROTINA VG0710S ");

                /*" -3506- DISPLAY 'MENSAGEM ' LK-MENSAGEM */
                _.Display($"MENSAGEM {PARAMETROS.LK_MENSAGEM}");

                /*" -3507- DISPLAY 'ERRO     ' LK-RETURN-CODE */
                _.Display($"ERRO     {PARAMETROS.LK_RETURN_CODE}");

                /*" -3508- DISPLAY 'ERRO     ' WS-RETURN-CODE-M */
                _.Display($"ERRO     {WS_RETURN_CODE_M}");

                /*" -3509- DISPLAY 'APOLICE  ' SVA-NRAPOLICE */
                _.Display($"APOLICE  {REG_SVA4437B.SVA_NRAPOLICE}");

                /*" -3510- DISPLAY 'CODSUBES ' SVA-CODSUBES */
                _.Display($"CODSUBES {REG_SVA4437B.SVA_CODSUBES}");

                /*" -3511- DISPLAY 'CERTIF   ' WHOST-NRCERTIF */
                _.Display($"CERTIF   {WHOST_NRCERTIF}");

                /*" -3515- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3517- MOVE LK-COBT-MORTE-NATURAL TO APOLICOB-IMP-SEGURADA-VG */
            _.Move(PARAMETROS.LK_COBT_MORTE_NATURAL, APOLICOB_IMP_SEGURADA_VG);

            /*" -3519- MOVE LK-COBT-MORTE-ACIDENTAL TO APOLICOB-IMP-SEGURADA-AP */
            _.Move(PARAMETROS.LK_COBT_MORTE_ACIDENTAL, APOLICOB_IMP_SEGURADA_AP);

            /*" -3521- MOVE LK-COBT-INV-PERMANENTE TO APOLICOB-IMP-SEGURADA-IP */
            _.Move(PARAMETROS.LK_COBT_INV_PERMANENTE, APOLICOB_IMP_SEGURADA_IP);

            /*" -3523- MOVE LK-COBT-INV-POR-ACIDENTE TO APOLICOB-IMP-SEGURADA-IPA */
            _.Move(PARAMETROS.LK_COBT_INV_POR_ACIDENTE, APOLICOB_IMP_SEGURADA_IPA);

            /*" -3525- MOVE LK-COBT-ASS-MEDICA TO APOLICOB-IMP-SEGURADA-AMDS */
            _.Move(PARAMETROS.LK_COBT_ASS_MEDICA, APOLICOB_IMP_SEGURADA_AMDS);

            /*" -3527- MOVE LK-COBT-DIARIA-HOSPITALAR TO APOLICOB-IMP-SEGURADA-DH */
            _.Move(PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, APOLICOB_IMP_SEGURADA_DH);

            /*" -3530- MOVE LK-COBT-DIARIA-INTERNACAO TO APOLICOB-IMP-SEGURADA-DIT. */
            _.Move(PARAMETROS.LK_COBT_DIARIA_INTERNACAO, APOLICOB_IMP_SEGURADA_DIT);

            /*" -3535- MOVE SEGVGAPH-DATA-MOVIMENTO TO SVA-DTMOVTO. */
            _.Move(SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO, REG_SVA4437B.SVA_DTMOVTO);

            /*" -3536- IF LC09-LINHA09 NOT EQUAL WS-JDE-ANT */

            if (AREA_DE_WORK.LC09_LINHA09 != AREA_DE_WORK.WS_JDE_ANT)
            {

                /*" -3537- IF WS-CONTROLE EQUAL 1 */

                if (WS_CONTROLE == 1)
                {

                    /*" -3538- MOVE ZEROS TO WS-CONTROLE */
                    _.Move(0, WS_CONTROLE);

                    /*" -3539- MOVE LC09-LINHA09 TO WS-JDE-ANT */
                    _.Move(AREA_DE_WORK.LC09_LINHA09, AREA_DE_WORK.WS_JDE_ANT);

                    /*" -3540- ELSE */
                }
                else
                {


                    /*" -3541- MOVE LC09-LINHA09 TO WS-JDE-ANT */
                    _.Move(AREA_DE_WORK.LC09_LINHA09, AREA_DE_WORK.WS_JDE_ANT);

                    /*" -3542- END-IF */
                }


                /*" -3543- ELSE */
            }
            else
            {


                /*" -3544- IF WS-CONTROLE EQUAL 1 */

                if (WS_CONTROLE == 1)
                {

                    /*" -3545- MOVE ZEROS TO WS-CONTROLE */
                    _.Move(0, WS_CONTROLE);

                    /*" -3546- END-IF */
                }


                /*" -3548- END-IF */
            }


            /*" -3550- PERFORM R2210-00-IMP-CAPITAIS. */

            R2210_00_IMP_CAPITAIS_SECTION();

            /*" -3551- MOVE SVA-DTMOVTO TO WS-DATA-SQL */
            _.Move(REG_SVA4437B.SVA_DTMOVTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -3552- MOVE WS-ANO-SQL TO WS-ANO-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, AREA_DE_WORK.WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3553- MOVE WS-MES-SQL TO WS-MES-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -3554- MOVE WS-DIA-SQL TO WS-DIA-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -3556- MOVE WS-DATA-I TO LC11-DTALTCAP. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LC11_LINHA11.LC11_DTALTCAP);

            /*" -3558- MOVE SPACES TO LC11-OPCAOPAG. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);

            /*" -3559- IF SVA-OPCAOPAG EQUAL '1' OR '2' */

            if (REG_SVA4437B.SVA_OPCAOPAG.In("1", "2"))
            {

                /*" -3560- MOVE SVA-AGECTADEB TO LC11-AGECTADEB */
                _.Move(REG_SVA4437B.SVA_AGECTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_AGECTADEB);

                /*" -3561- MOVE SVA-OPRCTADEB TO LC11-OPRCTADEB */
                _.Move(REG_SVA4437B.SVA_OPRCTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_OPRCTADEB);

                /*" -3562- MOVE SVA-NUMCTADEB TO LC11-NUMCTADEB */
                _.Move(REG_SVA4437B.SVA_NUMCTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_NUMCTADEB);

                /*" -3563- MOVE SVA-DIGCTADEB TO LC11-DIGCTADEB */
                _.Move(REG_SVA4437B.SVA_DIGCTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_DIGCTADEB);

                /*" -3565- MOVE '.' TO LC11-PONTO1 LC11-PONTO2 */
                _.Move(".", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_PONTO1, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_PONTO2);

                /*" -3566- MOVE '-' TO LC11-TRACO */
                _.Move("-", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_TRACO);

                /*" -3567- MOVE SPACES TO LC11-FILLER */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_FILLER);

                /*" -3568- ELSE */
            }
            else
            {


                /*" -3569- IF SVA-OPCAOPAG EQUAL '3' */

                if (REG_SVA4437B.SVA_OPCAOPAG == "3")
                {

                    /*" -3571- MOVE 'BOLETO DE COBRANCA BANCARIA' TO LC11-OPCAOPAG */
                    _.Move("BOLETO DE COBRANCA BANCARIA", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);

                    /*" -3572- ELSE */
                }
                else
                {


                    /*" -3573- IF SVA-OPCAOPAG EQUAL '4' */

                    if (REG_SVA4437B.SVA_OPCAOPAG == "4")
                    {

                        /*" -3575- MOVE 'DESCONTO EM FOLHA DE PAGTO ' TO LC11-OPCAOPAG */
                        _.Move("DESCONTO EM FOLHA DE PAGTO ", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);

                        /*" -3576- ELSE */
                    }
                    else
                    {


                        /*" -3577- IF SVA-OPCAOPAG EQUAL '5' */

                        if (REG_SVA4437B.SVA_OPCAOPAG == "5")
                        {

                            /*" -3579- MOVE 'CARTAO DE CREDITO          ' TO LC11-OPCAOPAG */
                            _.Move("CARTAO DE CREDITO          ", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);

                            /*" -3580- ELSE */
                        }
                        else
                        {


                            /*" -3583- MOVE '  ************************ ' TO LC11-OPCAOPAG. */
                            _.Move("  ************************ ", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);
                        }

                    }

                }

            }


            /*" -3584- IF SVA-PERI-PAGAMENTO EQUAL 1 */

            if (REG_SVA4437B.SVA_PERI_PAGAMENTO == 1)
            {

                /*" -3586- MOVE 'MENSAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                _.Move("MENSAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                /*" -3587- ELSE */
            }
            else
            {


                /*" -3588- IF SVA-PERI-PAGAMENTO EQUAL 2 */

                if (REG_SVA4437B.SVA_PERI_PAGAMENTO == 2)
                {

                    /*" -3590- MOVE 'BIMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("BIMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3591- ELSE */
                }
                else
                {


                    /*" -3592- IF SVA-PERI-PAGAMENTO EQUAL 3 */

                    if (REG_SVA4437B.SVA_PERI_PAGAMENTO == 3)
                    {

                        /*" -3594- MOVE 'TRIMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                        _.Move("TRIMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                        /*" -3595- ELSE */
                    }
                    else
                    {


                        /*" -3596- IF SVA-PERI-PAGAMENTO EQUAL 4 */

                        if (REG_SVA4437B.SVA_PERI_PAGAMENTO == 4)
                        {

                            /*" -3598- MOVE 'QUADRIMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                            _.Move("QUADRIMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                            /*" -3599- ELSE */
                        }
                        else
                        {


                            /*" -3600- IF SVA-PERI-PAGAMENTO EQUAL 6 */

                            if (REG_SVA4437B.SVA_PERI_PAGAMENTO == 6)
                            {

                                /*" -3602- MOVE 'SEMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                                _.Move("SEMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                                /*" -3603- ELSE */
                            }
                            else
                            {


                                /*" -3604- IF SVA-PERI-PAGAMENTO EQUAL 12 */

                                if (REG_SVA4437B.SVA_PERI_PAGAMENTO == 12)
                                {

                                    /*" -3607- MOVE 'ANUAL' TO LC11-NCUSTO LC11-NCUSTO1. */
                                    _.Move("ANUAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);
                                }

                            }

                        }

                    }

                }

            }


            /*" -3609- MOVE SVA-VLPREMIO TO LC11-VLPREMIO. */
            _.Move(REG_SVA4437B.SVA_VLPREMIO, AREA_DE_WORK.LC11_LINHA11.LC11_VLPREMIO);

            /*" -3610- IF SVA-DIA-DEBITO GREATER ZEROS */

            if (REG_SVA4437B.SVA_DIA_DEBITO > 00)
            {

                /*" -3611- MOVE SVA-DIA-DEBITO TO LC11-DIA-DEB */
                _.Move(REG_SVA4437B.SVA_DIA_DEBITO, AREA_DE_WORK.LC11_LINHA11.LC11_DIA_DEB);

                /*" -3612- ELSE */
            }
            else
            {


                /*" -3615- MOVE '**' TO LC11-DIA-DEB-ALFA. */
                _.Move("**", AREA_DE_WORK.LC11_LINHA11.LC11_DIA_DEB_R.LC11_DIA_DEB_ALFA);
            }


            /*" -3616- IF SVA-IND-VIGENCIA EQUAL '*' */

            if (REG_SVA4437B.SVA_IND_VIGENCIA == "*")
            {

                /*" -3619- MOVE '(*) RESPEITADO O PERIODO CORREPONDENTE AO PREMIO PAGO' TO LC11-TEXTO */
                _.Move("(*) RESPEITADO O PERIODO CORREPONDENTE AO PREMIO PAGO", AREA_DE_WORK.LC11_LINHA11.LC11_TEXTO);

                /*" -3620- ELSE */
            }
            else
            {


                /*" -3621- MOVE SPACES TO LC11-TEXTO */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_TEXTO);

                /*" -3622- END-IF. */
            }


            /*" -3624- MOVE 'SEG. PRINCIPAL: ' TO WS-STRING1 */
            _.Move("SEG. PRINCIPAL: ", AREA_DE_WORK.WS_DATA_SEG.WS_STRING1);

            /*" -3625- MOVE SVA-DTINIVIG TO WS-DATA-INV */
            _.Move(REG_SVA4437B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -3626- MOVE WS-DIA-INV TO WS-DIA-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_DIA_INI);

            /*" -3627- MOVE WS-MES-INV TO WS-MES-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_MES_INI);

            /*" -3628- MOVE WS-ANO-INV TO WS-ANO-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_ANO_INI);

            /*" -3630- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA1, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA2);

            /*" -3631- MOVE ' A ' TO WS-FIL-A */
            _.Move(" A ", AREA_DE_WORK.WS_DATA_SEG.WS_FIL_A);

            /*" -3632- MOVE SVA-DTTERVIG TO WS-DATA-INV */
            _.Move(REG_SVA4437B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -3633- MOVE WS-DIA-INV TO WS-DIA-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_DIA_TER);

            /*" -3634- MOVE WS-MES-INV TO WS-MES-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_MES_TER);

            /*" -3635- MOVE WS-ANO-INV TO WS-ANO-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_ANO_TER);

            /*" -3637- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA3, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA4);

            /*" -3638- IF SVA-IND-VIGENCIA EQUAL '*' */

            if (REG_SVA4437B.SVA_IND_VIGENCIA == "*")
            {

                /*" -3639- MOVE '(*)' TO WS-STRING2 */
                _.Move("(*)", AREA_DE_WORK.WS_DATA_SEG.WS_STRING2);

                /*" -3640- ELSE */
            }
            else
            {


                /*" -3641- MOVE SPACES TO WS-STRING2 */
                _.Move("", AREA_DE_WORK.WS_DATA_SEG.WS_STRING2);

                /*" -3643- END-IF. */
            }


            /*" -3645- MOVE WS-DATA-SEG TO LC11-DTVIG-PRIN */
            _.Move(AREA_DE_WORK.WS_DATA_SEG, AREA_DE_WORK.LC11_LINHA11.LC11_DTVIG_PRIN);

            /*" -3647- IF CONDITEC-CARREGA-CONJUGE NOT EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE != 00)
            {

                /*" -3649- MOVE 'SEG. DEPENDENTE:' TO WS-STRING1 */
                _.Move("SEG. DEPENDENTE:", AREA_DE_WORK.WS_DATA_SEG.WS_STRING1);

                /*" -3650- MOVE SVA-DTINIVIG TO WS-DATA-INV */
                _.Move(REG_SVA4437B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_INV);

                /*" -3651- MOVE WS-DIA-INV TO WS-DIA-INI */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_DIA_INI);

                /*" -3652- MOVE WS-MES-INV TO WS-MES-INI */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_MES_INI);

                /*" -3653- MOVE WS-ANO-INV TO WS-ANO-INI */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_ANO_INI);

                /*" -3655- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
                _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA1, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA2);

                /*" -3656- MOVE ' A ' TO WS-FIL-A */
                _.Move(" A ", AREA_DE_WORK.WS_DATA_SEG.WS_FIL_A);

                /*" -3657- MOVE SVA-DTTERVIG TO WS-DATA-INV */
                _.Move(REG_SVA4437B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

                /*" -3658- MOVE WS-DIA-INV TO WS-DIA-TER */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_DIA_TER);

                /*" -3659- MOVE WS-MES-INV TO WS-MES-TER */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_MES_TER);

                /*" -3660- MOVE WS-ANO-INV TO WS-ANO-TER */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_ANO_TER);

                /*" -3662- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
                _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA3, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA4);

                /*" -3663- MOVE SPACES TO WS-STRING2 */
                _.Move("", AREA_DE_WORK.WS_DATA_SEG.WS_STRING2);

                /*" -3664- MOVE WS-DATA-SEG TO LC11-DTVIG-DEPE */
                _.Move(AREA_DE_WORK.WS_DATA_SEG, AREA_DE_WORK.LC11_LINHA11.LC11_DTVIG_DEPE);

                /*" -3665- ELSE */
            }
            else
            {


                /*" -3666- MOVE SPACES TO LC11-DTVIG-DEPE */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_DTVIG_DEPE);

                /*" -3668- END-IF. */
            }


            /*" -3670- PERFORM R9200-00-DELIMITADORES */

            R9200_00_DELIMITADORES_SECTION();

            /*" -3674- PERFORM R2400-00-BENEFICIARIOS */

            R2400_00_BENEFICIARIOS_SECTION();

            /*" -3675- IF (WIND-99 EQUAL ZEROS) */

            if ((AREA_DE_WORK.WIND_99 == 00))
            {

                /*" -3676- MOVE 'HERDEIROS LEGAIS' TO LC11-NOME-BENEF(1) */
                _.Move("HERDEIROS LEGAIS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_NOME_BENEF);

                /*" -3677- MOVE 'OUTROS' TO LC11-PARENTESCO(1) */
                _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARENTESCO);

                /*" -3679- MOVE 100 TO LC11-PARTICIP (1) */
                _.Move(100, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARTICIP);

                /*" -3680- MOVE SVA-NOME-RAZAO TO LC11-NOME-RAZAO-END */
                _.Move(REG_SVA4437B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END);

                /*" -3681- MOVE SVA-ENDERECO TO LC11-ENDERECO */
                _.Move(REG_SVA4437B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO);

                /*" -3682- MOVE SVA-CIDADE TO LC11-CIDADE */
                _.Move(REG_SVA4437B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE);

                /*" -3683- MOVE SVA-BAIRRO TO LC11-BAIRRO */
                _.Move(REG_SVA4437B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO);

                /*" -3684- MOVE SVA-UF TO LC11-UF */
                _.Move(REG_SVA4437B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF);

                /*" -3685- MOVE SVA-CEP TO LC11-CEP */
                _.Move(REG_SVA4437B.SVA_NUM_CEP.SVA_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP);

                /*" -3687- MOVE SVA-CEP-COMPL TO LC11-CEP-COMPL */
                _.Move(REG_SVA4437B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL);

                /*" -3689- PERFORM R2650-00-BUSCA-FONTE */

                R2650_00_BUSCA_FONTE_SECTION();

                /*" -3693- ADD 1 TO WS-SEQ AC-QTD-OBJ AC-CONTA1 */
                AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
                AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
                AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

                /*" -3694- MOVE WS-SEQ TO WED-SEQ */
                _.Move(AREA_DE_WORK.WS_SEQ, WED_SEQ);

                /*" -3696- MOVE WED-SEQ TO LC11-SEQUENCIA */
                _.Move(WED_SEQ, AREA_DE_WORK.LC11_LINHA11.LC11_SEQUENCIA);

                /*" -3697- IF WS-CONTR-OBJ = ZEROS */

                if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
                {

                    /*" -3698- MOVE 1 TO WS-CONTR-OBJ */
                    _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                    /*" -3700- END-IF */
                }


                /*" -3701- IF WS-CONTR-200 = ZEROS */

                if (AREA_DE_WORK.WS_CONTR_200 == 00)
                {

                    /*" -3702- MOVE 1 TO WS-CONTR-200 */
                    _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                    /*" -3704- END-IF */
                }


                /*" -3711- MOVE ZEROS TO WS-SALVA-CERTIF */
                _.Move(0, AREA_DE_WORK.WS_SALVA_CERTIF);

                /*" -3718- PERFORM R9100-GRAVA-FORMULARIOS */

                R9100_GRAVA_FORMULARIOS_SECTION();

                /*" -3719- ELSE */
            }
            else
            {


                /*" -3720- PERFORM R2220-00-IMP-BENEFICIARIOS */

                R2220_00_IMP_BENEFICIARIOS_SECTION();

                /*" -3720- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2200_35_ATU_RELATORI */

            R2200_35_ATU_RELATORI();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-1 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_1()
        {
            /*" -3190- EXEC SQL SELECT DATA_MOVIMENTO, COD_OPERACAO, COD_MOEDA_PRM INTO :SEGVGAPH-DATA-MOVIMENTO, :SEGVGAPH-COD-OPERACAO, :SEGVGAPH-COD-MOEDA-PRM:VIND-CODMOEDA-I FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAPH_DATA_MOVIMENTO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO);
                _.Move(executed_1.SEGVGAPH_COD_OPERACAO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_OPERACAO);
                _.Move(executed_1.SEGVGAPH_COD_MOEDA_PRM, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM);
                _.Move(executed_1.VIND_CODMOEDA_I, VIND_CODMOEDA_I);
            }


        }

        [StopWatch]
        /*" R2200-35-ATU-RELATORI */
        private void R2200_35_ATU_RELATORI(bool isPerform = false)
        {
            /*" -3725- MOVE SVA-CODRELATVG TO WHOST-CODRELAT */
            _.Move(REG_SVA4437B.SVA_CODRELATVG, WHOST_CODRELAT);

            /*" -3725- PERFORM R2500-00-UPDATE-RELATORI. */

            R2500_00_UPDATE_RELATORI_SECTION();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-2 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_2()
        {
            /*" -3219- EXEC SQL SELECT VAL_COMPRA INTO :MOEDACOT-VAL-COMPRA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = :SEGVGAPH-COD-MOEDA-PRM AND DATA_INIVIGENCIA <= :SEGVGAPH-DATA-MOVIMENTO AND DATA_TERVIGENCIA >= :SEGVGAPH-DATA-MOVIMENTO END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_2_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1()
            {
                SEGVGAPH_DATA_MOVIMENTO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO.ToString(),
                SEGVGAPH_COD_MOEDA_PRM = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDACOT_VAL_COMPRA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA);
            }


        }

        [StopWatch]
        /*" R2200-40-NEXT */
        private void R2200_40_NEXT(bool isPerform = false)
        {
            /*" -3731- PERFORM R2300-00-LE-SORT. */

            R2300_00_LE_SORT_SECTION();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-3 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_3()
        {
            /*" -3255- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-VG, :APOLICOB-PRM-TARIFARIO-VG, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (77,93) AND COD_COBERTURA = 11 END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_3_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_VG, APOLICOB_IMP_SEGURADA_VG);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_VG, APOLICOB_PRM_TARIFARIO_VG);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-4 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_4()
        {
            /*" -3300- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-AP, :APOLICOB-PRM-TARIFARIO-AP, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 01 END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_4_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_AP, APOLICOB_IMP_SEGURADA_AP);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_AP, APOLICOB_PRM_TARIFARIO_AP);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-USUARIOS-SECTION */
        private void R2205_00_SELECT_USUARIOS_SECTION()
        {
            /*" -3742- MOVE '2205' TO WNR-EXEC-SQL. */
            _.Move("2205", WABEND.WNR_EXEC_SQL);

            /*" -3744- MOVE 'S' TO WTEM-USUARIOS. */
            _.Move("S", AREA_DE_WORK.WTEM_USUARIOS);

            /*" -3749- PERFORM R2205_00_SELECT_USUARIOS_DB_SELECT_1 */

            R2205_00_SELECT_USUARIOS_DB_SELECT_1();

            /*" -3752- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3753- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3754- MOVE 'N' TO WTEM-USUARIOS */
                    _.Move("N", AREA_DE_WORK.WTEM_USUARIOS);

                    /*" -3755- ELSE */
                }
                else
                {


                    /*" -3757- DISPLAY '*** VA4437B PROBLEMAS NO ACESSO A USUARIOS   ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA4437B PROBLEMAS NO ACESSO A USUARIOS   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -3757- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-USUARIOS-DB-SELECT-1 */
        public void R2205_00_SELECT_USUARIOS_DB_SELECT_1()
        {
            /*" -3749- EXEC SQL SELECT COD_USUARIO INTO :USUARIOS-COD-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :WHOST-CODUSU END-EXEC. */

            var r2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1 = new R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1()
            {
                WHOST_CODUSU = WHOST_CODUSU.ToString(),
            };

            var executed_1 = R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1.Execute(r2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);
            }


        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-5 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_5()
        {
            /*" -3349- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-IP, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 02 END-EXEC */

            var r2200_00_PROCESSA_FAC_DB_SELECT_5_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IP, APOLICOB_IMP_SEGURADA_IP);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2205_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-6 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_6()
        {
            /*" -3387- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-AMDS, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 03 END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_6_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_AMDS, APOLICOB_IMP_SEGURADA_AMDS);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" R2210-00-IMP-CAPITAIS-SECTION */
        private void R2210_00_IMP_CAPITAIS_SECTION()
        {
            /*" -3769- MOVE '2210' TO WNR-EXEC-SQL. */
            _.Move("2210", WABEND.WNR_EXEC_SQL);

            /*" -3771- INITIALIZE LC11-COBERTURAS. */
            _.Initialize(
                AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS
            );

            /*" -3782- MOVE '|' TO LC11-DELIMIT-00 (1) LC11-DELIMIT-00 (11) LC11-DELIMIT-00 (2) LC11-DELIMIT-00 (12) LC11-DELIMIT-00 (3) LC11-DELIMIT-00 (13) LC11-DELIMIT-00 (4) LC11-DELIMIT-00 (14) LC11-DELIMIT-00 (5) LC11-DELIMIT-00 (15) LC11-DELIMIT-00 (6) LC11-DELIMIT-00 (16) LC11-DELIMIT-00 (7) LC11-DELIMIT-00 (17) LC11-DELIMIT-00 (8) LC11-DELIMIT-00 (18) LC11-DELIMIT-00 (9) LC11-DELIMIT-00 (19) LC11-DELIMIT-00 (10) LC11-DELIMIT-00 (20). */
            _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[1].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[11].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[2].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[12].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[3].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[13].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[4].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[14].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[5].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[15].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[6].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[16].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[7].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[17].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[8].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[18].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[9].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[19].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[10].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[20].LC11_DELIMIT_00);

            /*" -3785- MOVE ZEROS TO CONTROLA-IMP W77-IND. */
            _.Move(0, AREA_DE_WORK.CONTROLA_IMP, W77_IND);

            /*" -3786- PERFORM R1800-00-SELECT-CONDITEC */

            R1800_00_SELECT_CONDITEC_SECTION();

            /*" -3788- MOVE WS-CAR-CONJUGE TO WS-PCTCONJUGE */
            _.Move(AREA_DE_WORK.WS_CAR_CONJUGE, WS_PCTCONJUGE);

            /*" -3789- MOVE ZEROES TO WS-IMPCONJUGE. */
            _.Move(0, WS_IMPCONJUGE);

            /*" -3790- IF WS-PCTCONJUGE > ZEROES */

            if (WS_PCTCONJUGE > 00)
            {

                /*" -3796- COMPUTE WS-IMPCONJUGE = APOLICOB-IMP-SEGURADA-VG * WS-PCTCONJUGE. */
                WS_IMPCONJUGE.Value = APOLICOB_IMP_SEGURADA_VG * WS_PCTCONJUGE;
            }


            /*" -3798- IF APOLICOB-IMP-SEGURADA-VG > ZEROS */

            if (APOLICOB_IMP_SEGURADA_VG > 00)
            {

                /*" -3799- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3801- MOVE 'MORTE CAUSAS NATURAIS E ACIDENTAIS.: R$ ' TO LC11-STRING1 (W77-IND) */
                _.Move("MORTE CAUSAS NATURAIS E ACIDENTAIS.: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -3803- MOVE APOLICOB-IMP-SEGURADA-VG TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_VG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3805- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -3811- COMPUTE WS-IMP-SEGURADA-AP = APOLICOB-IMP-SEGURADA-AP - APOLICOB-IMP-SEGURADA-VG. */
            WS_IMP_SEGURADA_AP.Value = APOLICOB_IMP_SEGURADA_AP - APOLICOB_IMP_SEGURADA_VG;

            /*" -3813- IF WS-IMP-SEGURADA-AP > ZEROS */

            if (WS_IMP_SEGURADA_AP > 00)
            {

                /*" -3814- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3815- IF SVA-RAMO EQUAL 81 OR 82 */

                if (REG_SVA4437B.SVA_RAMO.In("81", "82"))
                {

                    /*" -3817- MOVE 'MORTE ACIDENTAL....................: R$ ' TO LC11-STRING1 (W77-IND) */
                    _.Move("MORTE ACIDENTAL....................: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                    /*" -3818- ELSE */
                }
                else
                {


                    /*" -3820- MOVE 'INDENIZ. ESPEC. POR MORTE ACIDENTAL: R$ ' TO LC11-STRING1 (W77-IND) */
                    _.Move("INDENIZ. ESPEC. POR MORTE ACIDENTAL: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                    /*" -3821- END-IF */
                }


                /*" -3823- MOVE WS-IMP-SEGURADA-AP TO WS-VALOR */
                _.Move(WS_IMP_SEGURADA_AP, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3825- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -3827- IF APOLICOB-IMP-SEGURADA-IP > ZEROS */

            if (APOLICOB_IMP_SEGURADA_IP > 00)
            {

                /*" -3828- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3830- MOVE 'INVALIDEZ PERMANENTE ACIDENTE(ATE).: R$ ' TO LC11-STRING1 (W77-IND) */
                _.Move("INVALIDEZ PERMANENTE ACIDENTE(ATE).: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -3832- MOVE APOLICOB-IMP-SEGURADA-IP TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_IP, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3834- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -3836- IF APOLICOB-IMP-SEGURADA-IPA > ZEROS */

            if (APOLICOB_IMP_SEGURADA_IPA > 00)
            {

                /*" -3837- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3839- MOVE 'INVALIDEZ PERMANENTE POR DOENCA....: R$ ' TO LC11-STRING1 (W77-IND) */
                _.Move("INVALIDEZ PERMANENTE POR DOENCA....: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -3841- MOVE APOLICOB-IMP-SEGURADA-IPA TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_IPA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3845- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -3847- IF SVA-NRAPOLICE = 97010000889 AND SVA-CODSUBES = 3603 OR 4190 */

            if (REG_SVA4437B.SVA_NRAPOLICE == 97010000889 && REG_SVA4437B.SVA_CODSUBES.In("3603", "4190"))
            {

                /*" -3848- IF SVA-IDSEXO = 'F' */

                if (REG_SVA4437B.SVA_IDSEXO == "F")
                {

                    /*" -3850- MOVE ZEROS TO WS-IMPCONJUGE. */
                    _.Move(0, WS_IMPCONJUGE);
                }

            }


            /*" -3851- IF WS-IMPCONJUGE > ZEROS */

            if (WS_IMPCONJUGE > 00)
            {

                /*" -3852- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3854- MOVE 'MORTE DO CONJUGE...................: R$ ' TO LC11-STRING1 (W77-IND) */
                _.Move("MORTE DO CONJUGE...................: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -3856- MOVE WS-IMPCONJUGE TO WS-VALOR */
                _.Move(WS_IMPCONJUGE, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3858- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -3860- IF APOLICOB-IMP-SEGURADA-AMDS > ZEROS */

            if (APOLICOB_IMP_SEGURADA_AMDS > 00)
            {

                /*" -3861- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3863- MOVE 'ASSISTENCIA MEDICA.................: R$ ' TO LC11-STRING1 (W77-IND) */
                _.Move("ASSISTENCIA MEDICA.................: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -3865- MOVE APOLICOB-IMP-SEGURADA-AMDS TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_AMDS, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3867- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -3869- IF APOLICOB-IMP-SEGURADA-DH > ZEROS */

            if (APOLICOB_IMP_SEGURADA_DH > 00)
            {

                /*" -3870- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3872- MOVE 'DIARIA HOSPITALAR..................: R$ ' TO LC11-STRING1 (W77-IND) */
                _.Move("DIARIA HOSPITALAR..................: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -3874- MOVE APOLICOB-IMP-SEGURADA-DH TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_DH, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3876- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -3878- IF APOLICOB-IMP-SEGURADA-DIT > ZEROES */

            if (APOLICOB_IMP_SEGURADA_DIT > 00)
            {

                /*" -3879- PERFORM R2750-00-SELECT-HISCOBPR */

                R2750_00_SELECT_HISCOBPR_SECTION();

                /*" -3880- IF HISCOBPR-QTMDIT EQUAL ZEROES */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT == 00)
                {

                    /*" -3881- MOVE 15 TO HISCOBPR-QTMDIT */
                    _.Move(15, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);

                    /*" -3882- END-IF */
                }


                /*" -3886- COMPUTE WS-IMP-SEGURADA-DIT = APOLICOB-IMP-SEGURADA-DIT / HISCOBPR-QTMDIT. */
                WS_IMP_SEGURADA_DIT.Value = APOLICOB_IMP_SEGURADA_DIT / HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT;
            }


            /*" -3888- IF APOLICOB-IMP-SEGURADA-DIT > ZEROS */

            if (APOLICOB_IMP_SEGURADA_DIT > 00)
            {

                /*" -3889- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3891- MOVE 'DIARIA INCAPACIDADE TEMPORARIA.....: R$ ' TO LC11-STRING1 (W77-IND) */
                _.Move("DIARIA INCAPACIDADE TEMPORARIA.....: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -3893- MOVE WS-IMP-SEGURADA-DIT TO WS-VALOR */
                _.Move(WS_IMP_SEGURADA_DIT, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3895- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -3896- IF WHOST-NRAPOLICE EQUAL 109300000567 */

            if (WHOST_NRAPOLICE == 109300000567)
            {

                /*" -3898- COMPUTE WS-IMP-ADIANT-CDG = APOLICOB-IMP-SEGURADA-VG * 0,5 */
                WS_IMP_ADIANT_CDG.Value = APOLICOB_IMP_SEGURADA_VG * 0.5;

                /*" -3899- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3901- MOVE 'ADIANTAMENTO DOENCA GRAVE .........: R$ ' TO LC11-STRING1 (W77-IND) */
                _.Move("ADIANTAMENTO DOENCA GRAVE .........: R$ ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -3903- MOVE WS-IMP-ADIANT-CDG TO WS-VALOR */
                _.Move(WS_IMP_ADIANT_CDG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3905- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -3907- MOVE '2111' TO WNR-EXEC-SQL. */
            _.Move("2111", WABEND.WNR_EXEC_SQL);

            /*" -3909- MOVE 'N' TO WFIM-COBER. */
            _.Move("N", AREA_DE_WORK.WFIM_COBER);

            /*" -3920- PERFORM R2210_00_IMP_CAPITAIS_DB_DECLARE_1 */

            R2210_00_IMP_CAPITAIS_DB_DECLARE_1();

            /*" -3922- PERFORM R2210_00_IMP_CAPITAIS_DB_OPEN_1 */

            R2210_00_IMP_CAPITAIS_DB_OPEN_1();

            /*" -3926- PERFORM R2215-00-FETCH-COBER. */

            R2215_00_FETCH_COBER_SECTION();

            /*" -3927- IF WFIM-COBER EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_COBER == "S")
            {

                /*" -3927- GO TO R2210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2210_10_ACESSORIAS */

            R2210_10_ACESSORIAS();

        }

        [StopWatch]
        /*" R2210-00-IMP-CAPITAIS-DB-OPEN-1 */
        public void R2210_00_IMP_CAPITAIS_DB_OPEN_1()
        {
            /*" -3922- EXEC SQL OPEN COBER END-EXEC. */

            COBER.Open();

        }

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-DB-DECLARE-1 */
        public void R2400_00_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -4406- EXEC SQL DECLARE V0BENEF CURSOR FOR SELECT NOME_BENEFICIARIO, GRAU_PARENTESCO, PCT_PART_BENEFICIA FROM SEGUROS.BENEFICIARIOS WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */
            V0BENEF = new VA4437B_V0BENEF(true);
            string GetQuery_V0BENEF()
            {
                var query = @$"SELECT NOME_BENEFICIARIO
							, 
							GRAU_PARENTESCO
							, 
							PCT_PART_BENEFICIA 
							FROM SEGUROS.BENEFICIARIOS 
							WHERE NUM_CERTIFICADO = '{WHOST_NRCERTIF}' 
							AND DATA_TERVIGENCIA IN 
							( '1999-12-31'
							, '9999-12-31' )";

                return query;
            }
            V0BENEF.GetQueryEvent += GetQuery_V0BENEF;

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-7 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_7()
        {
            /*" -3425- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-DH, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 04 END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_7_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_DH, APOLICOB_IMP_SEGURADA_DH);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" R2210-10-ACESSORIAS */
        private void R2210_10_ACESSORIAS(bool isPerform = false)
        {
            /*" -3940- ADD 1 TO W77-IND */
            W77_IND.Value = W77_IND + 1;

            /*" -3941- IF (VGCOBSUB-COD-COBERTURA EQUAL 11) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 11))
            {

                /*" -3942- MOVE '.: R$' TO WS-COBERTURA(40:5) */
                _.MoveAtPosition(".: R$", WS_COBERTURA, 40, 5);

                /*" -3944- END-IF. */
            }


            /*" -3945- IF VGCOBSUB-COD-COBERTURA EQUAL 005 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 005)
            {

                /*" -3946- MOVE TAB-COBER-DESCR(05) TO WS-COBERTURA */
                _.Move(TABELA_COBER.TAB_COBER_R.TAB_COBER_DESCR[05], WS_COBERTURA);

                /*" -3948- END-IF. */
            }


            /*" -3951- MOVE WS-COBERTURA TO LC11-STRING1 (W77-IND) WS-COBER-DESC. */
            _.Move(WS_COBERTURA, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1, AREA_DE_WORK.WS_COBER_DESC);

            /*" -3953- MOVE SPACES TO WS-VALOR-INT-X */
            _.Move("", AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X);

            /*" -3955- IF WS-COBER-DESC(1:8) = 'REMISSAO' OR WS-COBER-DESC(1:8) = 'REMISS�O' */

            if (AREA_DE_WORK.WS_COBER_DESC.Substring(1, 8) == "REMISSAO" || AREA_DE_WORK.WS_COBER_DESC.Substring(1, 8) == "REMISS�O")
            {

                /*" -3957- MOVE VGCOBSUB-IMP-SEGURADA-IX TO WS-VALOR-INT */
                _.Move(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT);

                /*" -3960- STRING '(' WS-VALOR-INT ' MESES) ' DELIMITED BY '  ' INTO WS-VALOR-INT-X */
                #region STRING
                var spl7 = "(" + AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT.GetMoveValues().Split("  ").FirstOrDefault();
                spl7 += " MESES) ";
                _.Move(spl7, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X);
                #endregion

                /*" -3961- ELSE */
            }
            else
            {


                /*" -3963- MOVE VGCOBSUB-IMP-SEGURADA-IX TO WS-VALOR */
                _.Move(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3965- END-IF */
            }


            /*" -3968- IF VGCOBSUB-COD-COBERTURA EQUAL 01 OR VGCOBSUB-COD-COBERTURA EQUAL 22 AND SVA-IMPSEGCDG GREATER ZEROS */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 01 || VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 22 && REG_SVA4437B.SVA_IMPSEGCDG > 00)
            {

                /*" -3969- MOVE SVA-IMPSEGCDG TO WS-VALOR */
                _.Move(REG_SVA4437B.SVA_IMPSEGCDG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3971- END-IF */
            }


            /*" -3974- IF VGCOBSUB-COD-COBERTURA EQUAL 02 OR 16 OR 17 OR 18 OR 19 OR 20 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.In("02", "16", "17", "18", "19", "20"))
            {

                /*" -3975- MOVE ZEROS TO WS-VALOR */
                _.Move(0, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3979- END-IF */
            }


            /*" -3980- IF VGCOBSUB-COD-COBERTURA EQUAL 11 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 11)
            {

                /*" -3982- COMPUTE WS-VALOR-9 = APOLICOB-IMP-SEGURADA-VG / 2 */
                AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9.Value = APOLICOB_IMP_SEGURADA_VG / 2f;

                /*" -3983- IF WS-VALOR-9 > 50000 */

                if (AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9 > 50000)
                {

                    /*" -3984- MOVE 50000 TO WS-VALOR */
                    _.Move(50000, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                    /*" -3985- ELSE */
                }
                else
                {


                    /*" -3986- MOVE WS-VALOR-9 TO WS-VALOR */
                    _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                    /*" -3987- END-IF */
                }


                /*" -3989- END-IF. */
            }


            /*" -3990- IF WS-VALOR-INT-X EQUAL SPACES */

            if (AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X.IsEmpty())
            {

                /*" -3991- MOVE WS-VALOR TO LC11-VALORA (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);

                /*" -3992- ELSE */
            }
            else
            {


                /*" -3993- MOVE WS-VALOR-INT-X TO LC11-VALORA (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);

                /*" -3995- END-IF */
            }


            /*" -3997- PERFORM R2215-00-FETCH-COBER. */

            R2215_00_FETCH_COBER_SECTION();

            /*" -3998- IF WFIM-COBER EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_COBER == "S")
            {

                /*" -3999- GO TO R2210-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;

                /*" -4000- ELSE */
            }
            else
            {


                /*" -4000- GO TO R2210-10-ACESSORIAS. */
                new Task(() => R2210_10_ACESSORIAS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-8 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_8()
        {
            /*" -3463- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-DIT, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 05 END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_8_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_DIT, APOLICOB_IMP_SEGURADA_DIT);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2215-00-FETCH-COBER-SECTION */
        private void R2215_00_FETCH_COBER_SECTION()
        {
            /*" -4012- MOVE '2215' TO WNR-EXEC-SQL. */
            _.Move("2215", WABEND.WNR_EXEC_SQL);

            /*" -4014- MOVE SPACES TO WS-COBERTURA. */
            _.Move("", WS_COBERTURA);

            /*" -4019- PERFORM R2215_00_FETCH_COBER_DB_FETCH_1 */

            R2215_00_FETCH_COBER_DB_FETCH_1();

            /*" -4022- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4023- MOVE 'S' TO WFIM-COBER */
                _.Move("S", AREA_DE_WORK.WFIM_COBER);

                /*" -4023- PERFORM R2215_00_FETCH_COBER_DB_CLOSE_1 */

                R2215_00_FETCH_COBER_DB_CLOSE_1();

                /*" -4026- GO TO R2215-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4027- IF (VGCOBSUB-COD-COBERTURA EQUAL 22) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 22))
            {

                /*" -4030- IF (SVA-DTQUIT LESS VGCOBSUB-DATA-INIVIGENCIA) AND NOT ( WHOST-NRAPOLICE = 109300000559 OR 3009300000559 OR 3009300001559) */

                if ((REG_SVA4437B.SVA_DTQUIT < VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA) && !(WHOST_NRAPOLICE.In("109300000559", "3009300000559", "3009300001559")))
                {

                    /*" -4031- MOVE 01 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(01, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4032- END-IF */
                }


                /*" -4034- END-IF. */
            }


            /*" -4036- MOVE '2215-I' TO WNR-EXEC-SQL. */
            _.Move("2215-I", WABEND.WNR_EXEC_SQL);

            /*" -4041- PERFORM R2215_00_FETCH_COBER_DB_SELECT_1 */

            R2215_00_FETCH_COBER_DB_SELECT_1();

            /*" -4044- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4045- DISPLAY 'R2215 - PROBLEMAS NO ACESSO A VG_ACESSORIO' */
                _.Display($"R2215 - PROBLEMAS NO ACESSO A VG_ACESSORIO");

                /*" -4046- DISPLAY 'NUM_ACESSORIO ' VGCOBSUB-COD-COBERTURA */
                _.Display($"NUM_ACESSORIO {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA}");

                /*" -4047- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4049- END-IF. */
            }


            /*" -4050- IF (VGCOBSUB-COD-COBERTURA EQUAL 22) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 22))
            {

                /*" -4052- IF (WHOST-NRAPOLICE EQUAL 109300000559 OR 3009300000559 OR 3009300001559) */

                if ((WHOST_NRAPOLICE.In("109300000559", "3009300000559", "3009300001559")))
                {

                    /*" -4054- MOVE 'COBERTURA DE DOENCAS CRONICAS GRAVES EM ESTAGIOAVANCADO.: R$' TO WS-COBERTURA */
                    _.Move("COBERTURA DE DOENCAS CRONICAS GRAVES EM ESTAGIOAVANCADO.: R$", WS_COBERTURA);

                    /*" -4055- IF (SVA-DTQUIT LESS VGCOBSUB-DATA-INIVIGENCIA) */

                    if ((REG_SVA4437B.SVA_DTQUIT < VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA))
                    {

                        /*" -4056- MOVE 01 TO VGCOBSUB-COD-COBERTURA */
                        _.Move(01, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                        /*" -4057- END-IF */
                    }


                    /*" -4058- END-IF */
                }


                /*" -4058- END-IF. */
            }


        }

        [StopWatch]
        /*" R2215-00-FETCH-COBER-DB-FETCH-1 */
        public void R2215_00_FETCH_COBER_DB_FETCH_1()
        {
            /*" -4019- EXEC SQL FETCH COBER INTO :VGCOBSUB-COD-COBERTURA, :VGCOBSUB-IMP-SEGURADA-IX, :VGCOBSUB-DATA-INIVIGENCIA END-EXEC. */

            if (COBER.Fetch())
            {
                _.Move(COBER.VGCOBSUB_COD_COBERTURA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);
                _.Move(COBER.VGCOBSUB_IMP_SEGURADA_IX, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);
                _.Move(COBER.VGCOBSUB_DATA_INIVIGENCIA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA);
            }

        }

        [StopWatch]
        /*" R2215-00-FETCH-COBER-DB-CLOSE-1 */
        public void R2215_00_FETCH_COBER_DB_CLOSE_1()
        {
            /*" -4023- EXEC SQL CLOSE COBER END-EXEC */

            COBER.Close();

        }

        [StopWatch]
        /*" R2215-00-FETCH-COBER-DB-SELECT-1 */
        public void R2215_00_FETCH_COBER_DB_SELECT_1()
        {
            /*" -4041- EXEC SQL SELECT DES_ACESSORIO INTO :WS-COBERTURA FROM SEGUROS.VG_ACESSORIO WHERE NUM_ACESSORIO = :VGCOBSUB-COD-COBERTURA END-EXEC. */

            var r2215_00_FETCH_COBER_DB_SELECT_1_Query1 = new R2215_00_FETCH_COBER_DB_SELECT_1_Query1()
            {
                VGCOBSUB_COD_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.ToString(),
            };

            var executed_1 = R2215_00_FETCH_COBER_DB_SELECT_1_Query1.Execute(r2215_00_FETCH_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COBERTURA, WS_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-IMP-BENEFICIARIOS-SECTION */
        private void R2220_00_IMP_BENEFICIARIOS_SECTION()
        {
            /*" -4071- MOVE '2220' TO WNR-EXEC-SQL. */
            _.Move("2220", WABEND.WNR_EXEC_SQL);

            /*" -4072- MOVE ZEROS TO WIND-88 */
            _.Move(0, AREA_DE_WORK.WIND_88);

            /*" -4073- MOVE 'N' TO WFIM-TABELA WPRIM-LINHA. */
            _.Move("N", AREA_DE_WORK.WFIM_TABELA, AREA_DE_WORK.WPRIM_LINHA);

            /*" -0- FLUXCONTROL_PERFORM R2220_10_INI_CERTIFICADO */

            R2220_10_INI_CERTIFICADO();

        }

        [StopWatch]
        /*" R2220-10-INI-CERTIFICADO */
        private void R2220_10_INI_CERTIFICADO(bool isPerform = false)
        {
            /*" -4079- MOVE ZEROS TO WIND-77. */
            _.Move(0, AREA_DE_WORK.WIND_77);

            /*" -4081- PERFORM R9200-00-DELIMITADORES */

            R9200_00_DELIMITADORES_SECTION();

            /*" -4084- ADD 1 TO WS-SEQ AC-QTD-OBJ AC-CONTA1 */
            AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
            AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
            AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

            /*" -4085- MOVE WS-SEQ TO WED-SEQ */
            _.Move(AREA_DE_WORK.WS_SEQ, WED_SEQ);

            /*" -4087- MOVE WED-SEQ TO LC11-SEQUENCIA */
            _.Move(WED_SEQ, AREA_DE_WORK.LC11_LINHA11.LC11_SEQUENCIA);

            /*" -4088- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
            {

                /*" -4090- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                /*" -4091- IF WS-CONTR-200 EQUAL ZEROS */

                if (AREA_DE_WORK.WS_CONTR_200 == 00)
                {

                    /*" -4093- MOVE 1 TO WS-CONTR-200. */
                    _.Move(1, AREA_DE_WORK.WS_CONTR_200);
                }

            }


            /*" -4094- IF WIND-88 > 4 */

            if (AREA_DE_WORK.WIND_88 > 4)
            {

                /*" -4095- PERFORM R2210-00-IMP-CAPITAIS */

                R2210_00_IMP_CAPITAIS_SECTION();

                /*" -4095- END-IF. */
            }


        }

        [StopWatch]
        /*" R2220-20-BENEFICIARIOS */
        private void R2220_20_BENEFICIARIOS(bool isPerform = false)
        {
            /*" -4106- ADD 1 TO WIND-77 WIND-88. */
            AREA_DE_WORK.WIND_77.Value = AREA_DE_WORK.WIND_77 + 1;
            AREA_DE_WORK.WIND_88.Value = AREA_DE_WORK.WIND_88 + 1;

            /*" -4107- IF WIND-88 > WIND-99 */

            if (AREA_DE_WORK.WIND_88 > AREA_DE_WORK.WIND_99)
            {

                /*" -4108- MOVE 'S' TO WFIM-TABELA */
                _.Move("S", AREA_DE_WORK.WFIM_TABELA);

                /*" -4110- GO TO R2220-30-ENDERECO. */

                R2220_30_ENDERECO(); //GOTO
                return;
            }


            /*" -4112- IF WIND-88 = 1 OR WPRIM-LINHA = 'S' */

            if (AREA_DE_WORK.WIND_88 == 1 || AREA_DE_WORK.WPRIM_LINHA == "S")
            {

                /*" -4113- MOVE 'N' TO WPRIM-LINHA */
                _.Move("N", AREA_DE_WORK.WPRIM_LINHA);

                /*" -4114- ELSE */
            }
            else
            {


                /*" -4116- DIVIDE WIND-88 BY 5 GIVING WS-QUOCIENTE REMAINDER WS-RESTO */
                _.Divide(AREA_DE_WORK.WIND_88, 5, AREA_DE_WORK.WS_QUOCIENTE, AREA_DE_WORK.WS_RESTO);

                /*" -4118- IF WS-RESTO = 1 AND WPRIM-LINHA = 'N' */

                if (AREA_DE_WORK.WS_RESTO == 1 && AREA_DE_WORK.WPRIM_LINHA == "N")
                {

                    /*" -4119- MOVE 'N' TO WFIM-TABELA */
                    _.Move("N", AREA_DE_WORK.WFIM_TABELA);

                    /*" -4120- MOVE 'S' TO WPRIM-LINHA */
                    _.Move("S", AREA_DE_WORK.WPRIM_LINHA);

                    /*" -4122- GO TO R2220-30-ENDERECO. */

                    R2220_30_ENDERECO(); //GOTO
                    return;
                }

            }


            /*" -4124- MOVE TB99-NOME-BENEF (WIND-88) TO LC11-NOME-BENEF (WIND-77). */
            _.Move(TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_NOME_BENEF, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_NOME_BENEF);

            /*" -4126- MOVE TB99-PARENTESCO (WIND-88) TO LC11-PARENTESCO (WIND-77). */
            _.Move(TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_PARENTESCO, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_PARENTESCO);

            /*" -4129- MOVE TB99-PARTICIP (WIND-88) TO LC11-PARTICIP (WIND-77). */
            _.Move(TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_PARTICIP, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_PARTICIP);

            /*" -4129- GO TO R2220-20-BENEFICIARIOS. */
            new Task(() => R2220_20_BENEFICIARIOS()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2220-30-ENDERECO */
        private void R2220_30_ENDERECO(bool isPerform = false)
        {
            /*" -4134- MOVE SVA-NOME-RAZAO TO LC11-NOME-RAZAO-END */
            _.Move(REG_SVA4437B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END);

            /*" -4135- MOVE SVA-ENDERECO TO LC11-ENDERECO. */
            _.Move(REG_SVA4437B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO);

            /*" -4136- MOVE SVA-CIDADE TO LC11-CIDADE. */
            _.Move(REG_SVA4437B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE);

            /*" -4137- MOVE SVA-BAIRRO TO LC11-BAIRRO. */
            _.Move(REG_SVA4437B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO);

            /*" -4138- MOVE SVA-UF TO LC11-UF. */
            _.Move(REG_SVA4437B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF);

            /*" -4139- MOVE SVA-NUM-CEP TO LC11-CEP. */
            _.Move(REG_SVA4437B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP);

            /*" -4141- MOVE SVA-CEP-COMPL TO LC11-CEP-COMPL. */
            _.Move(REG_SVA4437B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL);

            /*" -4143- PERFORM R2650-00-BUSCA-FONTE */

            R2650_00_BUSCA_FONTE_SECTION();

            /*" -4150- MOVE ZEROS TO WS-SALVA-CERTIF */
            _.Move(0, AREA_DE_WORK.WS_SALVA_CERTIF);

            /*" -4158- PERFORM R9100-GRAVA-FORMULARIOS */

            R9100_GRAVA_FORMULARIOS_SECTION();

            /*" -4159- IF WFIM-TABELA NOT = 'S' */

            if (AREA_DE_WORK.WFIM_TABELA != "S")
            {

                /*" -4160- SUBTRACT 1 FROM WIND-88 */
                AREA_DE_WORK.WIND_88.Value = AREA_DE_WORK.WIND_88 - 1;

                /*" -4161- GO TO R2220-10-INI-CERTIFICADO */

                R2220_10_INI_CERTIFICADO(); //GOTO
                return;

                /*" -4161- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-SELECT-APOLICE-SECTION */
        private void R2230_00_SELECT_APOLICE_SECTION()
        {
            /*" -4172- MOVE '2230' TO WNR-EXEC-SQL. */
            _.Move("2230", WABEND.WNR_EXEC_SQL);

            /*" -4177- PERFORM R2230_00_SELECT_APOLICE_DB_SELECT_1 */

            R2230_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -4180- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4182- DISPLAY '*** VA4437B PROBLEMAS ACESSO APOLICES ' WHOST-NRAPOLICE */
                _.Display($"*** VA4437B PROBLEMAS ACESSO APOLICES {WHOST_NRAPOLICE}");

                /*" -4183- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2230-00-SELECT-APOLICE-DB-SELECT-1 */
        public void R2230_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -4177- EXEC SQL SELECT COD_MODALIDADE INTO :APOLICES-COD-MODALIDADE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :WHOST-NRAPOLICE END-EXEC. */

            var r2230_00_SELECT_APOLICE_DB_SELECT_1_Query1 = new R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(r2230_00_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-LE-SORT-SECTION */
        private void R2300_00_LE_SORT_SECTION()
        {
            /*" -4196- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -4198- RETURN SVA4437B AT END */
            try
            {
                SVA4437B.Return(REG_SVA4437B, () =>
                {

                    /*" -4199- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -4201- GO TO R2300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -4204- ADD 1 TO AC-LIDOS AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -4205- MOVE SVA-PRODUTO TO PRODUTO-COD-PRODUTO */
            _.Move(REG_SVA4437B.SVA_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -4206- MOVE SVA-COD-EMPRESA TO PRODUTO-COD-EMPRESA */
            _.Move(REG_SVA4437B.SVA_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);

            /*" -4207- MOVE SVA-NUM-PROCESSO-SUSEP TO PRODUTO-NUM-PROCESSO-SUSEP */
            _.Move(REG_SVA4437B.SVA_NUM_PROCESSO_SUSEP, PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP);

            /*" -4207- MOVE SVA-DESCR-PRODUTO TO PRODUTO-DESCR-PRODUTO. */
            _.Move(REG_SVA4437B.SVA_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-IDENTIFICA-MSG-SECTION */
        private void R2310_00_IDENTIFICA_MSG_SECTION()
        {
            /*" -4218- MOVE '2310' TO WNR-EXEC-SQL. */
            _.Move("2310", WABEND.WNR_EXEC_SQL);

            /*" -4219- IF INF > SUP */

            if (AREA_DE_WORK.INF > AREA_DE_WORK.SUP)
            {

                /*" -4220- MOVE 'N' TO WTEM-MULTIMSG */
                _.Move("N", AREA_DE_WORK.WTEM_MULTIMSG);

                /*" -4221- ELSE */
            }
            else
            {


                /*" -4222- COMPUTE WS-IND = (SUP + INF) / 2 */
                AREA_DE_WORK.WS_IND.Value = (AREA_DE_WORK.SUP + AREA_DE_WORK.INF) / 2;

                /*" -4223- IF WS-CHAVE < TABJ-CHAVE(WS-IND) */

                if (AREA_DE_WORK.WS_CHAVE < TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_CHAVE)
                {

                    /*" -4224- COMPUTE SUP = WS-IND - 1 */
                    AREA_DE_WORK.SUP.Value = AREA_DE_WORK.WS_IND - 1;

                    /*" -4225- GO TO R2310-00-IDENTIFICA-MSG */
                    new Task(() => R2310_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -4226- ELSE */
                }
                else
                {


                    /*" -4227- IF WS-CHAVE > TABJ-CHAVE(WS-IND) */

                    if (AREA_DE_WORK.WS_CHAVE > TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_CHAVE)
                    {

                        /*" -4228- COMPUTE INF = WS-IND + 1 */
                        AREA_DE_WORK.INF.Value = AREA_DE_WORK.WS_IND + 1;

                        /*" -4229- GO TO R2310-00-IDENTIFICA-MSG */
                        new Task(() => R2310_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -4230- ELSE */
                    }
                    else
                    {


                        /*" -4232- MOVE 'S' TO WTEM-MULTIMSG. */
                        _.Move("S", AREA_DE_WORK.WTEM_MULTIMSG);
                    }

                }

            }


            /*" -4233- IF WTEM-MULTIMSG = 'S' */

            if (AREA_DE_WORK.WTEM_MULTIMSG == "S")
            {

                /*" -4236- MOVE TABJ-JDE (WS-IND) TO WS-JDE */
                _.Move(TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                /*" -4237- ELSE */
            }
            else
            {


                /*" -4238- PERFORM R2315-00-SELECT-V0MULTIMENS */

                R2315_00_SELECT_V0MULTIMENS_SECTION();

                /*" -4241- MOVE COBMENVG-JDE TO WS-JDE */
                _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                /*" -4243- END-IF. */
            }


            /*" -4244- MOVE SPACES TO LC09-LINHA09 */
            _.Move("", AREA_DE_WORK.LC09_LINHA09);

            /*" -4250- STRING '(' FUNCTION LOWER-CASE(WS-JDE) DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LC09-LINHA09 */
            #region STRING
            var spl8 = "(" + AREA_DE_WORK.WS_JDE_GER.WS_JDE.ToString().ToLower().Split(" ").FirstOrDefault() + ".DBM".ToString().ToLower() + ") STARTDBM";
            spl8 += "(";
            spl8 += AREA_DE_WORK.WS_JDE_GER.WS_JDE.ToString().ToLower();
            spl8 += ".DBM".ToString().ToLower();
            spl8 += ") STARTDBM";
            _.Move(spl8, AREA_DE_WORK.LC09_LINHA09);
            #endregion

            /*" -4281- IF W88-PRODUTO-VIDA = 0917 OR 9304 OR 9307 OR 9309 OR 9310 OR JVPRD9310 OR 9312 OR 9314 OR JVPRD9314 OR 9318 OR 9319 OR 9320 OR JVPRD9320 OR 9321 OR JVPRD9321 OR 9327 OR JVPRD9327 OR 9328 OR JVPRD9328 OR 9332 OR JVPRD9332 OR 9333 OR 9334 OR JVPRD9334 OR 9351 OR JVPRD9351 OR 9352 OR JVPRD9352 OR 9353 OR JVPRD9353 OR 9356 OR JVPRD9356 OR 9357 OR JVPRD9357 OR 9358 OR JVPRD9358 OR 9359 OR JVPRD9359 OR 9360 OR JVPRD9360 OR 9361 OR JVPRD9361 OR 9701 OR 9702 OR 9703 OR 9704 OR 9705 OR 9707 */

            if (W88_PRODUTO_VIDA.In("0917", "9304", "9307", "9309", "9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString(), "9312", "9314", JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString(), "9318", "9319", "9320", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), "9321", JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), "9327", JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9332", JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), "9333", "9334", JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9351", JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), "9352", JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), "9353", JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString(), "9356", JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9358", JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), "9359", JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), "9360", JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString(), "9361", JVBKINCL.JV_PRODUTOS.JVPRD9361.ToString(), "9701", "9702", "9703", "9704", "9705", "9707"))
            {

                /*" -4282- EVALUATE PRODUTO-COD-EMPRESA */
                switch (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.Value)
                {

                    /*" -4283- WHEN 10 */
                    case 10:

                        /*" -4285- WHEN 11 */
                        break;
                    case 11:

                        /*" -4287- MOVE 'VA54' TO COBMENVG-JDE WS-JDE */
                        _.Move("VA54", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                        /*" -4289- IF WS-PROD-RUNON */

                        if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                        {

                            /*" -4290- MOVE 'VIDA10' TO COBMENVG-JDE WS-JDE */
                            _.Move("VIDA10", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                            /*" -4291- END-IF */
                        }


                        /*" -4292- WHEN OTHER */
                        break;
                    default:

                        /*" -4293- MOVE 'VA54' TO COBMENVG-JDE WS-JDE */
                        _.Move("VA54", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                        /*" -4294- END-EVALUATE */
                        break;
                }


                /*" -4296- MOVE 'VA' TO COBMENVG-JDL */
                _.Move("VA", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);

                /*" -4298- END-IF. */
            }


            /*" -4299- MOVE SPACES TO LC09-LINHA09 */
            _.Move("", AREA_DE_WORK.LC09_LINHA09);

            /*" -4302- STRING '(' FUNCTION LOWER-CASE(WS-JDE) DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LC09-LINHA09. */
            #region STRING
            var spl9 = "(" + AREA_DE_WORK.WS_JDE_GER.WS_JDE.ToString().ToLower().Split(" ").FirstOrDefault() + ".DBM".ToString().ToLower() + ") STARTDBM";
            spl9 += "(";
            spl9 += AREA_DE_WORK.WS_JDE_GER.WS_JDE.ToString().ToLower();
            spl9 += ".DBM".ToString().ToLower();
            spl9 += ") STARTDBM";
            _.Move(spl9, AREA_DE_WORK.LC09_LINHA09);
            #endregion

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-SECTION */
        private void R2315_00_SELECT_V0MULTIMENS_SECTION()
        {
            /*" -4333- MOVE '2315' TO WNR-EXEC-SQL */
            _.Move("2315", WABEND.WNR_EXEC_SQL);

            /*" -4336- MOVE WS-IDFORM TO COBMENVG-IDFORM. */
            _.Move(AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM);

            /*" -4347- PERFORM R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1 */

            R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1();

            /*" -4350- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4351- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4353- MOVE 'VA44' TO COBMENVG-JDE */
                    _.Move("VA44", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);

                    /*" -4354- IF WS-PROD-RUNON */

                    if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                    {

                        /*" -4355- MOVE 'VIDA05' TO COBMENVG-JDE */
                        _.Move("VIDA05", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);

                        /*" -4356- END-IF */
                    }


                    /*" -4357- MOVE 'VA' TO COBMENVG-JDL */
                    _.Move("VA", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);

                    /*" -4358- ELSE */
                }
                else
                {


                    /*" -4359- DISPLAY 'R2315 - NAO ENCONTRADO NA COBRANCA_MENS_VGAP ' */
                    _.Display($"R2315 - NAO ENCONTRADO NA COBRANCA_MENS_VGAP ");

                    /*" -4360- DISPLAY 'APOLICE     => ' COBMENVG-NUM-APOLICE */
                    _.Display($"APOLICE     => {COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE}");

                    /*" -4361- DISPLAY 'SUBGRUPO    => ' COBMENVG-CODSUBES */
                    _.Display($"SUBGRUPO    => {COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES}");

                    /*" -4362- DISPLAY 'OPERACAO    => ' WHOST-CODOPER */
                    _.Display($"OPERACAO    => {WHOST_CODOPER}");

                    /*" -4363- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4364- END-IF */
                }


                /*" -4364- END-IF. */
            }


        }

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-DB-SELECT-1 */
        public void R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1()
        {
            /*" -4347- EXEC SQL SELECT JDE, JDL INTO :COBMENVG-JDE, :COBMENVG-JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = :COBMENVG-IDFORM AND NUM_APOLICE = :COBMENVG-NUM-APOLICE AND CODSUBES = :COBMENVG-CODSUBES AND COD_OPERACAO = :WHOST-CODOPER END-EXEC. */

            var r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 = new R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1()
            {
                COBMENVG_NUM_APOLICE = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE.ToString(),
                COBMENVG_CODSUBES = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES.ToString(),
                COBMENVG_IDFORM = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM.ToString(),
                WHOST_CODOPER = WHOST_CODOPER.ToString(),
            };

            var executed_1 = R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1.Execute(r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBMENVG_JDE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);
                _.Move(executed_1.COBMENVG_JDL, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2315_99_SAIDA*/

        [StopWatch]
        /*" R2320-PRODUTO-RUNOFF-SECTION */
        private void R2320_PRODUTO_RUNOFF_SECTION()
        {
            /*" -4374- MOVE '2320' TO WNR-EXEC-SQL. */
            _.Move("2320", WABEND.WNR_EXEC_SQL);

            /*" -4375- SET WS-IND-PROD TO 1 */
            JVBKINCL.WS_IND_PROD.Value = 1;

            /*" -4377- SEARCH CVPPROD AT END */
            void SearchAtEnd0()
            {

                /*" -4378- SET WS-PROD-RUNON TO TRUE */
                AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] = true;

                /*" -4379- WHEN CVPPROD(WS-IND-PROD) EQUAL WS-COD-PRODUTO */
            };

            var mustSearchAtEnd0 = true;
            for (; JVBKINCL.WS_IND_PROD < JVBKINCL.CVP_PRODUTO.CVPPROD.Items.Count; JVBKINCL.WS_IND_PROD.Value++)
            {

                if (JVBKINCL.CVP_PRODUTO.CVPPROD[JVBKINCL.WS_IND_PROD] == WS_COD_PRODUTO)
                {

                    mustSearchAtEnd0 = false;

                    /*" -4380- SET WS-PROD-RUNOFF TO TRUE */
                    AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNOFF"] = true;

                    /*" -4382- END-SEARCH */

                    /*" -4382- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-SECTION */
        private void R2400_00_BENEFICIARIOS_SECTION()
        {
            /*" -4394- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -4395- MOVE 'N' TO WFIM-BENEFICIA. */
            _.Move("N", AREA_DE_WORK.WFIM_BENEFICIA);

            /*" -4397- MOVE ZEROS TO WIND-99. */
            _.Move(0, AREA_DE_WORK.WIND_99);

            /*" -4406- PERFORM R2400_00_BENEFICIARIOS_DB_DECLARE_1 */

            R2400_00_BENEFICIARIOS_DB_DECLARE_1();

            /*" -4408- PERFORM R2400_00_BENEFICIARIOS_DB_OPEN_1 */

            R2400_00_BENEFICIARIOS_DB_OPEN_1();

            /*" -4411- PERFORM R2410-00-FETCH-V0BENEF UNTIL WFIM-BENEFICIA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_BENEFICIA == "S"))
            {

                R2410_00_FETCH_V0BENEF_SECTION();
            }

        }

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-DB-OPEN-1 */
        public void R2400_00_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -4408- EXEC SQL OPEN V0BENEF END-EXEC. */

            V0BENEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-SECTION */
        private void R2410_00_FETCH_V0BENEF_SECTION()
        {
            /*" -4423- MOVE '2410' TO WNR-EXEC-SQL. */
            _.Move("2410", WABEND.WNR_EXEC_SQL);

            /*" -4428- PERFORM R2410_00_FETCH_V0BENEF_DB_FETCH_1 */

            R2410_00_FETCH_V0BENEF_DB_FETCH_1();

            /*" -4431- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4432- MOVE 'S' TO WFIM-BENEFICIA */
                _.Move("S", AREA_DE_WORK.WFIM_BENEFICIA);

                /*" -4432- PERFORM R2410_00_FETCH_V0BENEF_DB_CLOSE_1 */

                R2410_00_FETCH_V0BENEF_DB_CLOSE_1();

                /*" -4434- MOVE 'HERDEIROS LEGAIS' TO LC11-NOME-BENEF(1) */
                _.Move("HERDEIROS LEGAIS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_NOME_BENEF);

                /*" -4435- MOVE 'OUTROS' TO LC11-PARENTESCO(1) */
                _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARENTESCO);

                /*" -4436- MOVE 100 TO LC11-PARTICIP (1) */
                _.Move(100, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARTICIP);

                /*" -4438- GO TO R2410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4440- ADD 1 TO WIND-99. */
            AREA_DE_WORK.WIND_99.Value = AREA_DE_WORK.WIND_99 + 1;

            /*" -4442- MOVE BENEFICI-NOME-BENEFICIARIO TO TB99-NOME-BENEF (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO, TB99.TB99_CONT[AREA_DE_WORK.WIND_99].TB99_NOME_BENEF);

            /*" -4444- MOVE BENEFICI-GRAU-PARENTESCO TO TB99-PARENTESCO (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO, TB99.TB99_CONT[AREA_DE_WORK.WIND_99].TB99_PARENTESCO);

            /*" -4445- MOVE BENEFICI-PCT-PART-BENEFICIA TO TB99-PARTICIP (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA, TB99.TB99_CONT[AREA_DE_WORK.WIND_99].TB99_PARTICIP);

        }

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-DB-FETCH-1 */
        public void R2410_00_FETCH_V0BENEF_DB_FETCH_1()
        {
            /*" -4428- EXEC SQL FETCH V0BENEF INTO :BENEFICI-NOME-BENEFICIARIO, :BENEFICI-GRAU-PARENTESCO, :BENEFICI-PCT-PART-BENEFICIA END-EXEC. */

            if (V0BENEF.Fetch())
            {
                _.Move(V0BENEF.BENEFICI_NOME_BENEFICIARIO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO);
                _.Move(V0BENEF.BENEFICI_GRAU_PARENTESCO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO);
                _.Move(V0BENEF.BENEFICI_PCT_PART_BENEFICIA, BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA);
            }

        }

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-DB-CLOSE-1 */
        public void R2410_00_FETCH_V0BENEF_DB_CLOSE_1()
        {
            /*" -4432- EXEC SQL CLOSE V0BENEF END-EXEC */

            V0BENEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-SECTION */
        private void R2500_00_UPDATE_RELATORI_SECTION()
        {
            /*" -4457- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -4466- PERFORM R2500_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R2500_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -4469- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4469- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R2500_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -4466- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_RELATORIO = :WHOST-CODRELAT AND SIT_REGISTRO = '0' AND COD_OPERACAO IN (2,6,10) AND NUM_PARCELA = 2 AND NUM_CERTIFICADO = :WHOST-NRCERTIF END-EXEC. */

            var r2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                WHOST_CODRELAT = WHOST_CODRELAT.ToString(),
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2650-00-BUSCA-FONTE-SECTION */
        private void R2650_00_BUSCA_FONTE_SECTION()
        {
            /*" -4481- MOVE '2650' TO WNR-EXEC-SQL */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -4482- IF SVA-FONTE EQUAL 10 */

            if (REG_SVA4437B.SVA_FONTE == 10)
            {

                /*" -4483- MOVE 'MATRIZ' TO LC11-REMETENTE-G */
                _.Move("MATRIZ", AREA_DE_WORK.LC11_LINHA11.LC11_REMETENTE_G);

                /*" -4484- ELSE */
            }
            else
            {


                /*" -4485- MOVE 'FILIAL' TO LC11-REMETENTE-S */
                _.Move("FILIAL", AREA_DE_WORK.LC11_LINHA11.LC11_REMETENTE_G.LC11_REMETENTE_S);

                /*" -4488- MOVE TAB-NOMEFTE (SVA-FONTE) TO LC11-REMETENTE. */
                _.Move(TAB_FILIAL.FILLER_93[REG_SVA4437B.SVA_FONTE].TAB_NOMEFTE, AREA_DE_WORK.LC11_LINHA11.LC11_REMETENTE_G.LC11_REMETENTE);
            }


            /*" -4490- MOVE TAB-ENDERFTE(SVA-FONTE) TO LC11-ENDERECO-REM */
            _.Move(TAB_FILIAL.FILLER_93[REG_SVA4437B.SVA_FONTE].TAB_ENDERFTE, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO_REM);

            /*" -4492- MOVE TAB-BAIRRO (SVA-FONTE) TO LC11-BAIRRO-REM */
            _.Move(TAB_FILIAL.FILLER_93[REG_SVA4437B.SVA_FONTE].TAB_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO_REM);

            /*" -4494- MOVE TAB-CIDADE (SVA-FONTE) TO LC11-CIDADE-REM */
            _.Move(TAB_FILIAL.FILLER_93[REG_SVA4437B.SVA_FONTE].TAB_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE_REM);

            /*" -4496- MOVE TAB-UF (SVA-FONTE) TO LC11-UF-REM */
            _.Move(TAB_FILIAL.FILLER_93[REG_SVA4437B.SVA_FONTE].TAB_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF_REM);

            /*" -4498- MOVE TAB-CEP (SVA-FONTE) TO DEST-NUM-CEP */
            _.Move(TAB_FILIAL.FILLER_93[REG_SVA4437B.SVA_FONTE].TAB_CEP, AREA_DE_WORK.DEST_NUM_CEP);

            /*" -4499- MOVE DEST-CEP TO LC11-CEP-REM */
            _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_REM);

            /*" -4499- MOVE DEST-CEP-COMPL TO LC11-CEP-COMPL-REM. */
            _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL_REM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2710-00-SELECT-ESTIP-SECTION */
        private void R2710_00_SELECT_ESTIP_SECTION()
        {
            /*" -4511- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", WABEND.WNR_EXEC_SQL);

            /*" -4518- PERFORM R2710_00_SELECT_ESTIP_DB_SELECT_1 */

            R2710_00_SELECT_ESTIP_DB_SELECT_1();

            /*" -4521- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4522- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4523- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                    _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -4524- ELSE */
                }
                else
                {


                    /*" -4525- DISPLAY 'R2710 - PROBLEMAS NO ACESSO A CLIENTES ' */
                    _.Display($"R2710 - PROBLEMAS NO ACESSO A CLIENTES ");

                    /*" -4527- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                    $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                    .Display();

                    /*" -4527- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2710-00-SELECT-ESTIP-DB-SELECT-1 */
        public void R2710_00_SELECT_ESTIP_DB_SELECT_1()
        {
            /*" -4518- EXEC SQL SELECT B.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.APOLICES A, SEGUROS.CLIENTES B WHERE A.NUM_APOLICE = :WHOST-NRAPOLICE AND B.COD_CLIENTE = A.COD_CLIENTE END-EXEC. */

            var r2710_00_SELECT_ESTIP_DB_SELECT_1_Query1 = new R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1.Execute(r2710_00_SELECT_ESTIP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2715-00-SELECT-SUBESTIP-SECTION */
        private void R2715_00_SELECT_SUBESTIP_SECTION()
        {
            /*" -4539- MOVE '2715' TO WNR-EXEC-SQL. */
            _.Move("2715", WABEND.WNR_EXEC_SQL);

            /*" -4545- PERFORM R2715_00_SELECT_SUBESTIP_DB_SELECT_1 */

            R2715_00_SELECT_SUBESTIP_DB_SELECT_1();

            /*" -4548- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4549- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4550- MOVE SPACES TO SUBGVGAP-OPCAO-CONJUGE */
                    _.Move("", SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);

                    /*" -4551- ELSE */
                }
                else
                {


                    /*" -4552- DISPLAY 'R2710 - PROBLEMAS NO ACESSO A SUBGVGAP    ' */
                    _.Display($"R2710 - PROBLEMAS NO ACESSO A SUBGVGAP    ");

                    /*" -4554- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                    $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                    .Display();

                    /*" -4556- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4557- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '1' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "1")
            {

                /*" -4558- MOVE 'OPCIONAL' TO LC11-OPCAO-CONJ */
                _.Move("OPCIONAL", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);

                /*" -4559- ELSE */
            }
            else
            {


                /*" -4560- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '2' */

                if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "2")
                {

                    /*" -4561- MOVE 'OBRIGATORIO' TO LC11-OPCAO-CONJ */
                    _.Move("OBRIGATORIO", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);

                    /*" -4562- ELSE */
                }
                else
                {


                    /*" -4563- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '3' */

                    if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "3")
                    {

                        /*" -4564- MOVE 'SEM CONJUGE' TO LC11-OPCAO-CONJ */
                        _.Move("SEM CONJUGE", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);

                        /*" -4565- ELSE */
                    }
                    else
                    {


                        /*" -4565- MOVE 'OUTROS' TO LC11-OPCAO-CONJ. */
                        _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);
                    }

                }

            }


        }

        [StopWatch]
        /*" R2715-00-SELECT-SUBESTIP-DB-SELECT-1 */
        public void R2715_00_SELECT_SUBESTIP_DB_SELECT_1()
        {
            /*" -4545- EXEC SQL SELECT OPCAO_CONJUGE INTO :SUBGVGAP-OPCAO-CONJUGE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES END-EXEC. */

            var r2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1 = new R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1.Execute(r2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_OPCAO_CONJUGE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2715_99_SAIDA*/

        [StopWatch]
        /*" R2750-00-SELECT-HISCOBPR-SECTION */
        private void R2750_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -4576- MOVE '2750' TO WNR-EXEC-SQL. */
            _.Move("2750", WABEND.WNR_EXEC_SQL);

            /*" -4578- MOVE 'S' TO WTEM-HISCOBPR. */
            _.Move("S", AREA_DE_WORK.WTEM_HISCOBPR);

            /*" -4587- PERFORM R2750_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R2750_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -4590- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4591- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4592- MOVE 'N' TO WTEM-HISCOBPR */
                    _.Move("N", AREA_DE_WORK.WTEM_HISCOBPR);

                    /*" -4594- MOVE ZEROS TO HISCOBPR-QTMDIT VIND-QTMDIT */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT, VIND_QTMDIT);

                    /*" -4595- ELSE */
                }
                else
                {


                    /*" -4597- DISPLAY '*** VA4437B PROBLEMAS ACESSO HIS_COBER_PROPOST' WHOST-NRCERTIF */
                    _.Display($"*** VA4437B PROBLEMAS ACESSO HIS_COBER_PROPOST{WHOST_NRCERTIF}");

                    /*" -4599- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4600- IF VIND-QTMDIT LESS ZEROES */

            if (VIND_QTMDIT < 00)
            {

                /*" -4600- MOVE ZEROES TO HISCOBPR-QTMDIT. */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
            }


        }

        [StopWatch]
        /*" R2750-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R2750_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -4587- EXEC SQL SELECT QTMDIT INTO :HISCOBPR-QTMDIT:VIND-QTMDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND DATA_INIVIGENCIA <= CURRENT DATE AND DATA_TERVIGENCIA >= CURRENT DATE END-EXEC. */

            var r2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_QTMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
                _.Move(executed_1.VIND_QTMDIT, VIND_QTMDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-SELECT-SEGURVGA-SECTION */
        private void R2800_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -4645- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WABEND.WNR_EXEC_SQL);

            /*" -4657- PERFORM R2800_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R2800_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -4660- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4661- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4663- DISPLAY '*** VA4437B DESPREZADO SEGURADOS_VGAP ' WHOST-NRCERTIF */
                    _.Display($"*** VA4437B DESPREZADO SEGURADOS_VGAP {WHOST_NRCERTIF}");

                    /*" -4664- ELSE */
                }
                else
                {


                    /*" -4666- DISPLAY '*** VA4437B PROBLEMAS ACESSO SEGURADOS_VGAP ' WHOST-NRCERTIF */
                    _.Display($"*** VA4437B PROBLEMAS ACESSO SEGURADOS_VGAP {WHOST_NRCERTIF}");

                    /*" -4666- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R2800_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -4657- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_ITEM, OCORR_HISTORICO INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-SECTION */
        private void R2910_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -4678- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", WABEND.WNR_EXEC_SQL);

            /*" -4685- PERFORM R2910_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R2910_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -4688- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4689- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4691- MOVE ZEROS TO RELATORI-NUM-COPIAS */
                    _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

                    /*" -4692- ELSE */
                }
                else
                {


                    /*" -4693- DISPLAY 'R2910 - PROBLEMAS SELECT RELATORIOS' */
                    _.Display($"R2910 - PROBLEMAS SELECT RELATORIOS");

                    /*" -4695- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4696- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -4697- MOVE ZEROS TO RELATORI-NUM-COPIAS. */
                _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R2910_10_INCLUI_RELATORIO */

            R2910_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R2910_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -4685- EXEC SQL SELECT MAX(NUM_COPIAS) INTO :RELATORI-NUM-COPIAS:VIND-NRCOPIAS FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER END-EXEC. */

            var r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 = new R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1()
            {
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
            };

            var executed_1 = R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1.Execute(r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_NUM_COPIAS, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
                _.Move(executed_1.VIND_NRCOPIAS, VIND_NRCOPIAS);
            }


        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO */
        private void R2910_10_INCLUI_RELATORIO(bool isPerform = false)
        {
            /*" -4703- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -4706- ADD 1 TO RELATORI-NUM-COPIAS. */
            RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.Value = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS + 1;

            /*" -4749- PERFORM R2910_10_INCLUI_RELATORIO_DB_INSERT_1 */

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -4752- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -4753- DISPLAY 'R2910 - (REGISTRO DUPLICADO) ... ' */
                _.Display($"R2910 - (REGISTRO DUPLICADO) ... ");

                /*" -4755- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4757- DISPLAY 'R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -4759- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4759- ADD 1 TO AC-I-RELATORI. */
            AREA_DE_WORK.AC_I_RELATORI.Value = AREA_DE_WORK.AC_I_RELATORI + 1;

        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO-DB-INSERT-1 */
        public void R2910_10_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -4749- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'EM0600B' , :SISTEMAS-DATA-MOV-ABERTO, 'EM' , 'CARTAECT' , :RELATORI-NUM-COPIAS, 0, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-MESREFER, :V1SIST-ANOREFER, 0, 0, 0, 0, 0, 0, :WHOST-NRAPOLICE, 0, 0, 0, 0, :WHOST-CODSUBES, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 = new R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1.Execute(r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PESQUISA-FORMULARIO-SECTION */
        private void R3000_00_PESQUISA_FORMULARIO_SECTION()
        {
            /*" -4770- MOVE '9200' TO WNR-EXEC-SQL. */
            _.Move("9200", WABEND.WNR_EXEC_SQL);

            /*" -4771- MOVE SVA-PRODUTO TO RELATORI-COD-PLANO */
            _.Move(REG_SVA4437B.SVA_PRODUTO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);

            /*" -4773- MOVE WS-JDE TO RELATORI-COD-RELATORIO */
            _.Move(AREA_DE_WORK.WS_JDE_GER.WS_JDE, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -4785- PERFORM R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1 */

            R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1();

            /*" -4788- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -4789- DISPLAY 'R3500 - PROBLEMAS SELECT RELATORIOS' */
                _.Display($"R3500 - PROBLEMAS SELECT RELATORIOS");

                /*" -4790- DISPLAY 'COD_RELATORIO = ' RELATORI-COD-RELATORIO */
                _.Display($"COD_RELATORIO = {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}");

                /*" -4791- DISPLAY 'COD_PLANO     = ' RELATORI-COD-PLANO */
                _.Display($"COD_PLANO     = {RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO}");

                /*" -4792- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4794- END-IF */
            }


            /*" -4795- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -4796- MOVE 'S' TO W-EXISTE-TIPO-CORRECAO */
                _.Move("S", W_EXISTE_TIPO_CORRECAO);

                /*" -4797- ELSE */
            }
            else
            {


                /*" -4798- MOVE 'N' TO W-EXISTE-TIPO-CORRECAO */
                _.Move("N", W_EXISTE_TIPO_CORRECAO);

                /*" -4799- END-IF */
            }


            /*" -4799- . */

        }

        [StopWatch]
        /*" R3000-00-PESQUISA-FORMULARIO-DB-SELECT-1 */
        public void R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1()
        {
            /*" -4785- EXEC SQL SELECT TIPO_CORRECAO , NUM_APOL_LIDER INTO :RELATORI-TIPO-CORRECAO , :RELATORI-NUM-APOL-LIDER FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'VG' AND NUM_APOLICE = 9999999999999 AND COD_SUBGRUPO = 9999 AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND COD_PLANO = :RELATORI-COD-PLANO WITH UR END-EXEC */

            var r3000_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1 = new R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
            };

            var executed_1 = R3000_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1.Execute(r3000_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_TIPO_CORRECAO, RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);
                _.Move(executed_1.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-BUSCA-NOM-SOCIAL-SECTION */
        private void R4000_00_BUSCA_NOM_SOCIAL_SECTION()
        {
            /*" -4809- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -4831- INITIALIZE LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE */
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

            /*" -4832- MOVE 'N' TO LK-GE053-E-TRACE */
            _.Move("N", SPGE053W.LK_GE053_E_TRACE);

            /*" -4833- MOVE 'VA' TO LK-GE053-E-IDE-SISTEMA */
            _.Move("VA", SPGE053W.LK_GE053_E_IDE_SISTEMA);

            /*" -4834- MOVE 2 TO LK-GE053-E-IND-OPERACAO */
            _.Move(2, SPGE053W.LK_GE053_E_IND_OPERACAO);

            /*" -4836- MOVE SVA-CPF TO LK-GE053-I-NUM-CPF */
            _.Move(REG_SVA4437B.SVA_CPF, SPGE053W.LK_GE053_I_NUM_CPF);

            /*" -4858- CALL 'SPBGE053' USING LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE */
            _.Call("SPBGE053", SPGE053W);

            /*" -4860- . */

            /*" -4861- MOVE LK-GE053-SQLCODE TO WS-RETURN-CODE. */
            _.Move(SPGE053W.LK_GE053_SQLCODE, WS_RETURN_CODE);

            /*" -4863- MOVE WS-RETURN-CODE TO WS-RETURN-CODE-M. */
            _.Move(WS_RETURN_CODE, WS_RETURN_CODE_M);

            /*" -4865- IF (LK-GE053-SQLCODE NOT EQUAL ZEROS) AND (LK-GE053-SQLCODE NOT EQUAL 100) */

            if ((SPGE053W.LK_GE053_SQLCODE != 00) && (SPGE053W.LK_GE053_SQLCODE != 100))
            {

                /*" -4866- DISPLAY 'ERRO SUBROTINA SPBGE053' */
                _.Display($"ERRO SUBROTINA SPBGE053");

                /*" -4867- DISPLAY 'LK-GE053-MENSAGEM      ' LK-GE053-MENSAGEM */
                _.Display($"LK-GE053-MENSAGEM      {SPGE053W.LK_GE053_MENSAGEM}");

                /*" -4868- DISPLAY 'LK-GE053-SQLCODE       ' LK-GE053-SQLCODE */
                _.Display($"LK-GE053-SQLCODE       {SPGE053W.LK_GE053_SQLCODE}");

                /*" -4869- DISPLAY 'LK-GE053-E-IDE-SISTEMA ' LK-GE053-E-TRACE */
                _.Display($"LK-GE053-E-IDE-SISTEMA {SPGE053W.LK_GE053_E_TRACE}");

                /*" -4870- DISPLAY 'LK-GE053-E-IND-OPERACAO ' LK-GE053-E-IDE-SISTEMA */
                _.Display($"LK-GE053-E-IND-OPERACAO {SPGE053W.LK_GE053_E_IDE_SISTEMA}");

                /*" -4871- DISPLAY 'LK-GE053-E-TRACE       ' LK-GE053-E-IND-OPERACAO */
                _.Display($"LK-GE053-E-TRACE       {SPGE053W.LK_GE053_E_IND_OPERACAO}");

                /*" -4872- DISPLAY 'LK-GE053-I-NUM-CPF     ' LK-GE053-I-NUM-CPF */
                _.Display($"LK-GE053-I-NUM-CPF     {SPGE053W.LK_GE053_I_NUM_CPF}");

                /*" -4873- DISPLAY 'ERRO INESPERADO SUBROTINA SPBGE053' */
                _.Display($"ERRO INESPERADO SUBROTINA SPBGE053");

                /*" -4874- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4876- END-IF */
            }


            /*" -4877- IF LK-GE053-I-NOM-SOCIAL NOT EQUAL SPACES */

            if (!SPGE053W.LK_GE053_I_NOM_SOCIAL.IsEmpty())
            {

                /*" -4878- MOVE LK-GE053-I-NOM-SOCIAL TO LC11-NOME-RAZAO-SOC */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_SOC);

                /*" -4879- MOVE LK-GE053-I-NOM-SOCIAL TO LC11-NOME-RAZAO-END-SOC */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END_SOC);

                /*" -4880- MOVE LK-GE053-I-NOM-SOCIAL TO LC11-CLIENTE-SOC */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

                /*" -4881- ELSE */
            }
            else
            {


                /*" -4882- MOVE SPACES TO LC11-NOME-RAZAO-SOC */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_SOC);

                /*" -4883- MOVE SPACES TO LC11-NOME-RAZAO-END-SOC */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END_SOC);

                /*" -4884- MOVE SPACES TO LC11-CLIENTE-SOC */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

                /*" -4886- END-IF */
            }


            /*" -4887- DISPLAY 'LK-GE053-E-TRACE        ' LK-GE053-E-TRACE */
            _.Display($"LK-GE053-E-TRACE        {SPGE053W.LK_GE053_E_TRACE}");

            /*" -4888- DISPLAY 'LK-GE053-E-IDE-SISTEMA  ' LK-GE053-E-IDE-SISTEMA */
            _.Display($"LK-GE053-E-IDE-SISTEMA  {SPGE053W.LK_GE053_E_IDE_SISTEMA}");

            /*" -4889- DISPLAY 'LK-GE053-E-IND-OPERACAO ' LK-GE053-E-IND-OPERACAO */
            _.Display($"LK-GE053-E-IND-OPERACAO {SPGE053W.LK_GE053_E_IND_OPERACAO}");

            /*" -4890- DISPLAY 'LK-GE053-I-NUM-CPF      ' LK-GE053-I-NUM-CPF */
            _.Display($"LK-GE053-I-NUM-CPF      {SPGE053W.LK_GE053_I_NUM_CPF}");

            /*" -4891- DISPLAY 'LK-GE053-I-NOM-SOCIAL   ' LK-GE053-I-NOM-SOCIAL */
            _.Display($"LK-GE053-I-NOM-SOCIAL   {SPGE053W.LK_GE053_I_NOM_SOCIAL}");

            /*" -4892- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-PRIMEIRO-NOME-SOCIAL-SECTION */
        private void R4100_00_PRIMEIRO_NOME_SOCIAL_SECTION()
        {
            /*" -4903- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", WABEND.WNR_EXEC_SQL);

            /*" -4904- MOVE 1 TO WIND-N-S. */
            _.Move(1, AREA_DE_WORK.WIND_N_S);

            /*" -0- FLUXCONTROL_PERFORM R4100_10_LOOP */

            R4100_10_LOOP();

        }

        [StopWatch]
        /*" R4100-10-LOOP */
        private void R4100_10_LOOP(bool isPerform = false)
        {
            /*" -4908- IF WIND-N-S GREATER 100 */

            if (AREA_DE_WORK.WIND_N_S > 100)
            {

                /*" -4909- DISPLAY '*** VA3437B TAB NOMES ESTOURADA ' */
                _.Display($"*** VA3437B TAB NOMES ESTOURADA ");

                /*" -4910- GO TO R4100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/ //GOTO
                return;

                /*" -4912- END-IF */
            }


            /*" -4914- IF (TAB-NOME-SOC(WIND-N-S) EQUAL SPACES) AND (WIND-N-S EQUAL 1) */

            if ((TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S] == string.Empty) && (AREA_DE_WORK.WIND_N_S == 1))
            {

                /*" -4915- ADD 1 TO WIND-N-S */
                AREA_DE_WORK.WIND_N_S.Value = AREA_DE_WORK.WIND_N_S + 1;

                /*" -4916- GO TO R4100-10-LOOP */
                new Task(() => R4100_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -4917- ELSE */
            }
            else
            {


                /*" -4920- IF (TAB-NOME-SOC(WIND-N-S) EQUAL SPACES) AND (WIND-N-S EQUAL 2) */

                if ((TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S] == string.Empty) && (AREA_DE_WORK.WIND_N_S == 2))
                {

                    /*" -4921- ADD 1 TO WIND-N-S */
                    AREA_DE_WORK.WIND_N_S.Value = AREA_DE_WORK.WIND_N_S + 1;

                    /*" -4922- GO TO R4100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/ //GOTO
                    return;

                    /*" -4923- END-IF */
                }


                /*" -4925- END-IF */
            }


            /*" -4926- IF (TAB-NOME-SOC(WIND-N-S) NOT EQUAL SPACES) */

            if ((TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S] != string.Empty))
            {

                /*" -4927- MOVE TAB-NOME-SOC (WIND-N-S) TO TAB-NOME1-SOC(WIND-N-S) */
                _.Move(TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S], TABELA_NOMES1_SOC.TAB_NOMES1_SOC_R.TAB_NOME1_SOC[AREA_DE_WORK.WIND_N_S]);

                /*" -4928- ADD 1 TO WIND-N-S */
                AREA_DE_WORK.WIND_N_S.Value = AREA_DE_WORK.WIND_N_S + 1;

                /*" -4929- GO TO R4100-10-LOOP */
                new Task(() => R4100_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -4931- END-IF */
            }


            /*" -4933- MOVE ',' TO TAB-NOME1-SOC(WIND-N-S) */
            _.Move(",", TABELA_NOMES1_SOC.TAB_NOMES1_SOC_R.TAB_NOME1_SOC[AREA_DE_WORK.WIND_N_S]);

            /*" -4935- MOVE SPACES TO TABELA-NOMES1-SOC(WIND-N-S + 1:100 - WIND-N-S) */
            _.MoveAtPosition("", TABELA_NOMES1_SOC, AREA_DE_WORK.WIND_N_S + 1, 100 - AREA_DE_WORK.WIND_N_S);

            /*" -4936- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -4947- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -4950- OPEN OUTPUT RVA4437B RVA4437I RVA4437P RVA4437H. */
            RVA4437B.Open(RVA4437B_RECORD);
            RVA4437I.Open(RVA4437I_RECORD);
            RVA4437P.Open(RVA4437P_RECORD);
            RVA4437H.Open(RVA4437H_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -4963- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -4966- CLOSE RVA4437B RVA4437I RVA4437P RVA4437H. */
            RVA4437B.Close();
            RVA4437I.Close();
            RVA4437P.Close();
            RVA4437H.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-GRAVA-FORMULARIOS-SECTION */
        private void R9100_GRAVA_FORMULARIOS_SECTION()
        {
            /*" -4978- IF W88-IMPR-CTR-RVA4437B-CIF-OK */

            if (FILLER_1["W88_IMPR_CTR_RVA4437B_CIF_OK"])
            {

                /*" -4980- SET W88-IMPR-CTR-RVA4437B-CIF-NOK TO TRUE */
                FILLER_1["W88_IMPR_CTR_RVA4437B_CIF_NOK"] = true;

                /*" -4981- WRITE RVA4437B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA4437B_RECORD);

                RVA4437B.Write(RVA4437B_RECORD.GetMoveValues().ToString());

                /*" -4982- WRITE RVA4437B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA4437B_RECORD);

                RVA4437B.Write(RVA4437B_RECORD.GetMoveValues().ToString());

                /*" -4983- WRITE RVA4437B-RECORD FROM LC09-LINHA09 */
                _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVA4437B_RECORD);

                RVA4437B.Write(RVA4437B_RECORD.GetMoveValues().ToString());

                /*" -4984- WRITE RVA4437B-RECORD FROM LC10-LINHA10 */
                _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVA4437B_RECORD);

                RVA4437B.Write(RVA4437B_RECORD.GetMoveValues().ToString());

                /*" -4986- END-IF */
            }


            /*" -4987- WRITE RVA4437B-RECORD FROM LC11-LINHA11 */
            _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVA4437B_RECORD);

            RVA4437B.Write(RVA4437B_RECORD.GetMoveValues().ToString());

            /*" -4988- ADD 1 TO AC-IMPRESSOS */
            AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

            /*" -4991- SET W88-IMPRESS-RVA4437B-CIF-OK TO TRUE */
            FILLER_0["W88_IMPRESS_RVA4437B_CIF_OK"] = true;

            /*" -4992- IF W-EXISTE-TIPO-CORRECAO = 'S' */

            if (W_EXISTE_TIPO_CORRECAO == "S")
            {

                /*" -4993- GO TO R9100-GRAVA-FORMULARIOS-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_GRAVA_FORMULARIOS_EXIT*/ //GOTO
                return;

                /*" -4996- END-IF */
            }


            /*" -4998- IF RELATORI-TIPO-CORRECAO = 'I' AND SVA-EMAIL = SPACES */

            if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "I" && REG_SVA4437B.SVA_EMAIL.IsEmpty())
            {

                /*" -4999- IF W88-IMPR-CTR-RVA4437I-IMP-OK */

                if (FILLER_1["W88_IMPR_CTR_RVA4437I_IMP_OK"])
                {

                    /*" -5001- SET W88-IMPR-CTR-RVA4437I-IMP-NOK TO TRUE */
                    FILLER_1["W88_IMPR_CTR_RVA4437I_IMP_NOK"] = true;

                    /*" -5002- WRITE RVA4437I-RECORD FROM LC01-LINHA01 */
                    _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA4437I_RECORD);

                    RVA4437I.Write(RVA4437I_RECORD.GetMoveValues().ToString());

                    /*" -5003- WRITE RVA4437I-RECORD FROM LC08-LINHA08 */
                    _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA4437I_RECORD);

                    RVA4437I.Write(RVA4437I_RECORD.GetMoveValues().ToString());

                    /*" -5004- WRITE RVA4437I-RECORD FROM LC09-LINHA09 */
                    _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVA4437I_RECORD);

                    RVA4437I.Write(RVA4437I_RECORD.GetMoveValues().ToString());

                    /*" -5005- WRITE RVA4437I-RECORD FROM LC10-LINHA10 */
                    _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVA4437I_RECORD);

                    RVA4437I.Write(RVA4437I_RECORD.GetMoveValues().ToString());

                    /*" -5007- END-IF */
                }


                /*" -5008- WRITE RVA4437I-RECORD FROM LC11-LINHA11 */
                _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVA4437I_RECORD);

                RVA4437I.Write(RVA4437I_RECORD.GetMoveValues().ToString());

                /*" -5009- ADD 1 TO AC-QTD-IMP */
                AREA_DE_WORK.AC_QTD_IMP.Value = AREA_DE_WORK.AC_QTD_IMP + 1;

                /*" -5010- SET W88-IMPRESS-RVA4437I-IMP-OK TO TRUE */
                FILLER_0["W88_IMPRESS_RVA4437I_IMP_OK"] = true;

                /*" -5013- END-IF */
            }


            /*" -5015- IF RELATORI-TIPO-CORRECAO = 'P' AND SVA-EMAIL = SPACES */

            if (RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO == "P" && REG_SVA4437B.SVA_EMAIL.IsEmpty())
            {

                /*" -5016- IF W88-IMPR-CTR-RVA4437P-PDF-OK */

                if (FILLER_1["W88_IMPR_CTR_RVA4437P_PDF_OK"])
                {

                    /*" -5018- SET W88-IMPR-CTR-RVA4437P-PDF-NOK TO TRUE */
                    FILLER_1["W88_IMPR_CTR_RVA4437P_PDF_NOK"] = true;

                    /*" -5019- WRITE RVA4437P-RECORD FROM LC01-LINHA01 */
                    _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA4437P_RECORD);

                    RVA4437P.Write(RVA4437P_RECORD.GetMoveValues().ToString());

                    /*" -5020- WRITE RVA4437P-RECORD FROM LC08-LINHA08 */
                    _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA4437P_RECORD);

                    RVA4437P.Write(RVA4437P_RECORD.GetMoveValues().ToString());

                    /*" -5021- WRITE RVA4437P-RECORD FROM LC09-LINHA09 */
                    _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVA4437P_RECORD);

                    RVA4437P.Write(RVA4437P_RECORD.GetMoveValues().ToString());

                    /*" -5022- WRITE RVA4437P-RECORD FROM LC10-LINHA10 */
                    _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVA4437P_RECORD);

                    RVA4437P.Write(RVA4437P_RECORD.GetMoveValues().ToString());

                    /*" -5024- END-IF */
                }


                /*" -5025- WRITE RVA4437P-RECORD FROM LC11-LINHA11 */
                _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVA4437P_RECORD);

                RVA4437P.Write(RVA4437P_RECORD.GetMoveValues().ToString());

                /*" -5026- ADD 1 TO AC-QTD-PDF */
                AREA_DE_WORK.AC_QTD_PDF.Value = AREA_DE_WORK.AC_QTD_PDF + 1;

                /*" -5027- SET W88-IMPRESS-RVA4437P-PDF-OK TO TRUE */
                FILLER_0["W88_IMPRESS_RVA4437P_PDF_OK"] = true;

                /*" -5030- END-IF */
            }


            /*" -5032- IF RELATORI-NUM-APOL-LIDER NOT = SPACES AND SVA-EMAIL NOT = SPACES */

            if (!RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.IsEmpty() && !REG_SVA4437B.SVA_EMAIL.IsEmpty())
            {

                /*" -5033- IF W88-IMPR-CTR-RVA4437H-HTML-OK */

                if (FILLER_1["W88_IMPR_CTR_RVA4437H_HTML_OK"])
                {

                    /*" -5035- SET W88-IMPR-CTR-RVA4437H-HTML-NOK TO TRUE */
                    FILLER_1["W88_IMPR_CTR_RVA4437H_HTML_NOK"] = true;

                    /*" -5036- WRITE RVA4437H-RECORD FROM LC01-LINHA01 */
                    _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA4437H_RECORD);

                    RVA4437H.Write(RVA4437H_RECORD.GetMoveValues().ToString());

                    /*" -5037- WRITE RVA4437H-RECORD FROM LC08-LINHA08 */
                    _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA4437H_RECORD);

                    RVA4437H.Write(RVA4437H_RECORD.GetMoveValues().ToString());

                    /*" -5038- WRITE RVA4437H-RECORD FROM LC09-LINHA09 */
                    _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVA4437H_RECORD);

                    RVA4437H.Write(RVA4437H_RECORD.GetMoveValues().ToString());

                    /*" -5039- INSPECT LC10-LINHA10 REPLACING ALL '|' BY ';' */
                    AREA_DE_WORK.LC10_LINHA10.Replace("|", ";");

                    /*" -5040- WRITE RVA4437H-RECORD FROM LC10-LINHA10 */
                    _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVA4437H_RECORD);

                    RVA4437H.Write(RVA4437H_RECORD.GetMoveValues().ToString());

                    /*" -5041- INSPECT LC10-LINHA10 REPLACING ALL ';' BY '|' */
                    AREA_DE_WORK.LC10_LINHA10.Replace(";", "|");

                    /*" -5043- END-IF */
                }


                /*" -5044- WRITE RVA4437H-RECORD FROM LC11-LINHA11 */
                _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVA4437H_RECORD);

                RVA4437H.Write(RVA4437H_RECORD.GetMoveValues().ToString());

                /*" -5045- ADD 1 TO AC-QTD-HTML */
                AREA_DE_WORK.AC_QTD_HTML.Value = AREA_DE_WORK.AC_QTD_HTML + 1;

                /*" -5046- SET W88-IMPRESS-RVA4437H-HTML-OK TO TRUE */
                FILLER_0["W88_IMPRESS_RVA4437H_HTML_OK"] = true;

                /*" -5047- END-IF */
            }


            /*" -5047- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_GRAVA_FORMULARIOS_EXIT*/

        [StopWatch]
        /*" R9200-00-DELIMITADORES-SECTION */
        private void R9200_00_DELIMITADORES_SECTION()
        {
            /*" -5055- INITIALIZE LC11-BENEFICIARIOS */
            _.Initialize(
                AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS
            );

            /*" -5069- MOVE '|' TO LC11-DELIMIT-01 (1) LC11-DELIMIT-01 (2) LC11-DELIMIT-01 (3) LC11-DELIMIT-01 (4) LC11-DELIMIT-01 (5) LC11-DELIMIT-02 (1) LC11-DELIMIT-02 (2) LC11-DELIMIT-02 (3) LC11-DELIMIT-02 (4) LC11-DELIMIT-02 (5) LC11-DELIMIT-03 (1) LC11-DELIMIT-03 (2) LC11-DELIMIT-03 (3) LC11-DELIMIT-03 (4) LC11-DELIMIT-03 (5). */
            _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[2].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[3].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[4].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[5].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[2].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[3].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[4].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[5].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[2].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[3].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[4].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[5].LC11_DELIMIT_03);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9200_EXIT*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -5080- MOVE '9800' TO WNR-EXEC-SQL. */
            _.Move("9800", WABEND.WNR_EXEC_SQL);

            /*" -5081- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -5082- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -5083- DISPLAY '*   VA4437B - EMITE CERTIFICADO            *' */
            _.Display($"*   VA4437B - EMITE CERTIFICADO            *");

            /*" -5084- DISPLAY '*   -------   -----------------            *' */
            _.Display($"*   -------   -----------------            *");

            /*" -5085- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -5086- DISPLAY '*             NAO EXISTEM CERTIFICADOS A   *' */
            _.Display($"*             NAO EXISTEM CERTIFICADOS A   *");

            /*" -5087- DISPLAY '*             SEREM EMITIDOS.              *' */
            _.Display($"*             SEREM EMITIDOS.              *");

            /*" -5088- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -5088- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5099- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -5100- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -5101- DISPLAY 'SQLERRMC<' SQLERRMC '>' */

            $"SQLERRMC<{DB.SQLERRMC}>"
            .Display();

            /*" -5102- DISPLAY '*** VA4437B - LIDOS         ' AC-LIDOS. */
            _.Display($"*** VA4437B - LIDOS         {AREA_DE_WORK.AC_LIDOS}");

            /*" -5104- DISPLAY '*** VA4437B - CERTIFICADO   ' PROPOVA-NUM-CERTIFICADO. */
            _.Display($"*** VA4437B - CERTIFICADO   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -5106- DISPLAY '*** VA4437B - CERTIFICADO-W ' WHOST-NRCERTIF. */
            _.Display($"*** VA4437B - CERTIFICADO-W {WHOST_NRCERTIF}");

            /*" -5106- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -5108- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5112- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5112- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}