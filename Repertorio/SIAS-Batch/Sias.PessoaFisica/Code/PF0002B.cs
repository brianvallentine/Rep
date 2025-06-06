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
using Sias.PessoaFisica.DB2.PF0002B;

namespace Code
{
    public class PF0002B
    {
        public bool IsCall { get; set; }

        public PF0002B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  PF0002B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  11/02/2000                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONSISTENCIA E CONTROLE DO         *      */
        /*"      *                             MOVIMENTO DE COBRANCA              *      */
        /*"      *                             'CAIXA ECONOMICA FEDERAL (SIVPF)'. *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                       ALTERACOES                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 37   - HISTORIA 181017                               *       */
        /*"      *               - ALTERAR A APLICACAO PARA O TRATAMENTO DA NOVA  *      */
        /*"      *                 EMPRESA (JV1) E SEUS PRODUTOS.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/01/2019 - LUIZ FERNANDO      PROCURE POR V.37          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36 - CAD 126.077                                      *      */
        /*"      *               - CORRECAO DE ABEND - CODIGO PRODUTO PREENCHIDO  *      */
        /*"      *                 INCORRETAMENTE COM NUMERO DE AGENCIA.          *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/11/2015 - FRANK CARVALHO      PROCURE POR V.36         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  DAIRO LOPES  23/01/2015     V.35   *      */
        /*"      *      - INCLUIR NOVO PRODUTO 3181         CADMUS 105721         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 34 - CAD 102.399                                      *      */
        /*"      *               - HABILITACAO CANAL DE VENDA = 3                 *      */
        /*"      *                 SICAQ_WEB(CORRESPONDENTE CAIXAQUI)             *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/11/2014 - BRICE HO            PROCURE POR V.34         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. CADMUS 97056                        *      */
        /*"      *             ..............  28/04/2014 - DIEGO DIAS     V.33   *      */
        /*"      *                             AJUSTE PARA RETIRAR CADASTRO DE    *      */
        /*"      *                             RCAPS DO RAMO 46 NO PRODUTO AUTO   *      */
        /*"      *                             3146.                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  06/03/2014 - CLOVIS         V.32   *      */
        /*"      *                             AJUSTE PRODUTOS SIES.              *      */
        /*"      *                             COMPLEMENTO V.14 E V.15            *      */
        /*"      *                             VERIFICADO QUE O SIES ESTA         *      */
        /*"      *                             UTILIZANDO O CEDENTE DEMAIS        *      */
        /*"      *                             PARCELAS PARA ADESAO.              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. CADMUS 84644              V.31      *      */
        /*"      *                                                                *      */
        /*"      *   AUMENTO DAS OCORRENCIAS DA TABELA WS-AGENCIACEF, DE 4000     *      */
        /*"      *   PARA 6000 OCORRENCIAS.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/10/2013 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.31         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ATENDE CADMUS 84809        DB2.V10  SELECTS           SET/2013 *      */
        /*"      * V.30                       REGINALDO DA SILVA                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. CADMUS 85673              V.29      *      */
        /*"      *   ABEND 85673                                                  *      */
        /*"      *   EM 05/08/2013 - RILDO                                        *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. CADMUS 84333              V.28      *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTE NO ENQUADRAMENTO DOS PRODUTOS DO AUTO                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/07/2013 - RILDO                                        *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. - AJUSTE RESSARCIMENTO    V.27      *      */
        /*"      *                                                                *      */
        /*"      *   ALTERA CONDICAO DE BUSCA TITULOS RESSARCIMENTO               *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/08/2011 - CLOVIS              CADMUS 60014             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.27         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. -CADMUS 59326             V.26      *      */
        /*"      *                                                                *      */
        /*"      *   BUSCA MAX(COD_PRODUTO) TABELA PRODUTOS_SIVPF                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/07/2011 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. -CADMUS 54479             V.25      *      */
        /*"      *                                                                *      */
        /*"      *   COLOCAR CLAUSULA WITH UR NOS COMANDO DB2 SELECT.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/06/2011 - SERGIO LORETO                                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.25         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .............. -CADMUS 44951             V.24      *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTA FILIAL OUTROS BANCOS.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/05/2011 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.24         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 23 - PROJETO AUTO - SUL AMERICA                       *      */
        /*"      *                                                                *      */
        /*"      *               - PREVISAO DOS NOVOS CEDENTES                    *      */
        /*"      *                 063087000000319-8 - ADESAO                     *      */
        /*"      *                 063087000000320-1 - DEMAIS PARCELAS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/05/2011 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.23         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22 - CAD 41.441                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE PARA GRAVAR CORRETAMENTO O PRODUTO      *      */
        /*"      *                 QUANDO FOR BILHETE.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/04/2010 - TERCIO FREITAS - (FAST COMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CAD 36.549                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE PARA GRAVAR CORRETAMENTO O PRODUTO      *      */
        /*"      *                 QUANDO FOR BILHETE.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/02/2010 - FAST COMPUTER - MARCO PAIVA                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - CAD 35.006                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE    PARA ATENDER O NOVO CEDENTE E CANAL  *      */
        /*"      *                 DE VENDA QUE SERA CRIADO PARA O AIC.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/01/2010 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 - CAD 31.471                                       *      */
        /*"      *                                                                *      */
        /*"      *               - ALTERACAO PARA ATENDER O NOVO CEDENTE E CANAL  *      */
        /*"      *                 DE VENDA QUE SERA CRIADO PARA O AIC.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/11/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  15/10/2009                  V.18   *      */
        /*"      *                             SSI 23145/2008                     *      */
        /*"      *                             AJUSTE FAIXA NUMERACAO.            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  28/09/2009                  V.17   *      */
        /*"      *                             SSI 23145/2008                     *      */
        /*"      *                             AJUSTE RENOVACAO.                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  24/09/2009                  V.16   *      */
        /*"      *                             SSI 23145/2008                     *      */
        /*"      *                             AJUSTE RENOVACAO.                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  16/09/2009 - CLOVIS         V.15   *      */
        /*"      *                             SSI 23145/2008                     *      */
        /*"      *                             AJUSTE PRODUTOS SIES.              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  26/08/2009 - CLOVIS         V.14   *      */
        /*"      *                             SSI 23145/2008                     *      */
        /*"      *                             AJUSTE PARA IMPLANTACAO SIES.      *      */
        /*"      *                                                                *      */
        /*"      *   OS REGISTROS ENVIADOS PARA O SIES DEIXAM DE SER GRAVADOS     *      */
        /*"      *   NO SIAS. PARA POSTERIOR RECUPERACAO OS DADOS SERAO GRAVADOS  *      */
        /*"      *   NA TABELA MOVIMENTO_COBRANCA COM SITUACAO = '*'.             *      */
        /*"      *   PROGRAMA QUE GERA INFORMACOES PARA O SIES - CB7300B.         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO CADMUS 24207 :  JULHO/2009 - BRSEG                 *      */
        /*"      *   PROJETO SINISTRO JUDICIAL/RESSARCIMENTO                      *      */
        /*"      *                                                                *      */
        /*"      *   - INCLUIR O TRATAMENTO PARA O NOVO CODIGO DE CEDENTE:        *      */
        /*"      *     0630.87000000282-5 (RESSARCIMENTO AUTOMOVEL MAPFRE)        *      */
        /*"      *                                                                *      */
        /*"      *   - PARA O NOVO CEDENTE, GERAR:                                *      */
        /*"      *     . AGEAVISO = 7284                                          *      */
        /*"      *     . ORIGAVISO = 0021                                         *      */
        /*"      *     . TIPAVI = 'C'                                             *      */
        /*"      *                                                                *      */
        /*"      *   (VER C24207)                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA ...............  FAST COMPUTER                        *      */
        /*"      *                                                                *      */
        /*"      * EM 18/05/2009             TRATA CODIGO RETORNO -803.           *      */
        /*"      *                                                                *      */
        /*"      * PROCURAR POR V.13                  ATENDE SSI 23190/2009       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA ...............  CLOVIS                               *      */
        /*"      *                                                                *      */
        /*"      * EM 15/12/2008             ALTERA CONTA CONTABIL                *      */
        /*"      *                630870000000725 DE 7999 PARA 7011               *      */
        /*"      *                630870000000750 DE 7011 PARA 7999               *      */
        /*"      *                630870000001144 DE 7011 PARA 7999               *      */
        /*"      *                630870000001306 DE 7011 PARA 7999               *      */
        /*"      *                                                                *      */
        /*"      * PROCURAR POR V.12                  ATENDE SSI 24048/2008       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA ...............  LUCIA VIEIRA                         *      */
        /*"      *                                                                *      */
        /*"      * EM 13/11/2008 ALTERACAO CONTA  PARA CEDENTE 630870000002337    *      */
        /*"      *               AGENCIA AVISO PASSA DE 7011 PARA 7245            *      */
        /*"      *                                                                *      */
        /*"      * PROCURAR POR V.11                  ATENDE SSI 23862            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  LUCIA VIEIRA                       *      */
        /*"      *   EM 29/01/2008 TRATAMENTO DO PRODUTO 77 PRESTAMISTA           *      */
        /*"      *                 COBRAN-CODEMPRESA = 630870000002337            *      */
        /*"      *   PROCURAR POR V.10                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  WANGER C SILVA                     *      */
        /*"      *   EM 05/09/2006 TRATAMENTO DO PRODUTO 3146.                    *      */
        /*"      *             QDO CANAL 8 E AUX-PRDSIVPF 44 MOVE PROD 3146.      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   EM 06/07/2006 TRATAMENTO DO CANAL 5 (GITEL).                 *      */
        /*"      *                 INIBE ADIANTAMENTOS DE COMISSAO (BILHETE).     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   EM 23/07/2004 TRATAMENTO DO CEDENTE VIDA EMPRESA(CL0704).    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   EM 02/03/2004 TRATAMENTO DO CEDENTE MULTIRISCO  (CL0750).    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   EM 03/04/2003 TRATAMENTO DOS CEDENTES VERA CRUZ (CL0304).    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   EM 31/01/2003 TRATAMENTO DO PRODUTO BILHETE (CL0103).        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  LUIZ CARLOS                        *      */
        /*"      *   EM 30/08/2002 PASSOU A ATUALIZAR AS TABELAS CONVERSAO_SICOB E*      */
        /*"      *   PROPOSTAS_FIDELIZ, QUANDO A CONVERSAO FOR GERADA PELO PROGRA-*      */
        /*"      *   MA PF0600B.  PROCURE POR LC0830.                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   EM 17/04/2002 TRATAMENTO DO CEDENTE (630.870.00000044-0)     *      */
        /*"      *   RECEBIMENTO DE COBRANCA RESSARCIMENTO DE SINISTRO.           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  LUIZ CARLOS.                       *      */
        /*"      *   EM 24/08/2001 PASSOU VERIFICAR SE PROPOSTA JA ESTA CADASTRADA*      */
        /*"      *   NA TABELA CONVERSAO-SICOB. ESTAS PROPOSTAS FORAM INCLUIDAS PE*      */
        /*"      *   LO PROGRAMA PF0600B, POSSIBILITANDO QUE A PROPOSTA SEJA  IN- *      */
        /*"      *   CLUIDA NA ESTRUTURA DO SISTEMA PF, PARA POSTERIOR EMISSAO.   *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR LC0824.                                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   EM 15/08/2001 INCLUIDO ROTINA R0400-00-TRATA-NRTIT-ZERO      *      */
        /*"      *   POIS NO CAMPO RESERVADO PARA CEF INFORMAR O TITULO COM       *      */
        /*"      *   16 POSICOES ALGUNS TITULOS ESTAO COM BRANCOS.                *      */
        /*"      *   PARA SE EVITAR A GRANDE QTDE DE REGISTROS INCLUIDOS EM       *      */
        /*"      *   FOLLOWUP A ROTINA TRATA O CAMPO NOSSO NUMERO COM 11 POSICOES.*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   EM 21/06/2001 INCLUIDO SORT INTERNO PARA CADASTRO DE         *      */
        /*"      *   AVISOS DE CREDITO DEVIDO A INFORMACAO PELA CEF DE DIVERSOS   *      */
        /*"      *   CEDENTES NO ARQUIVO.                                         *      */
        /*"      *   COMO OS CEDENTES CRIADOS PELA GETEC SAO UTILIZADOS TANTO     *      */
        /*"      *   PARA O SIVPF COMO PARA PROPOSTAS IMPRESSAS PELA GRAFICA      *      */
        /*"      *   TRATA OS REGISTROS DO SIVPF CONVERTENDO NUMERO DO TITULO     *      */
        /*"      *   DE 14 PARA 11 POSICOES, NAO HAVENDO NECESSIDADE DE CONVERSAO *      */
        /*"      *   PARA OS TITULOS IMPRESSOS PELA GRAFICA.                      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   EM 22/05/2001 PASSOU A TRATAR COBRANCA DO AZULCAR.           *      */
        /*"      *                         PROCURE POR LC0522                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   EM 26/09/2000 GERA ADIANTAMENTOS PARA CORRETOR 17256         *      */
        /*"      *   DE ACORDO COM VALOR DO BILHETE (0,5% POR BILHETE)            *      */
        /*"      *   PREVENDO DESCONTO DOS IMPOSTOS (IOCC - ISS - IRF)            *      */
        /*"      *                         PROCURE POR CL0900                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  WANGER                             *      */
        /*"      *   EM 13/04/2006 ALTERA A GRAVACAO DA AGENCIA DE COBRANCA       *      */
        /*"      *   PARA A AGENCIA QUE ENCONTRA-SE NAS POSICOES 3 A 6 CONTIDA    *      */
        /*"      *   NO NUMERO DA PROPOSTA SIGPF                                  *      */
        /*"      *                         PROCURE POR WA1304                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  CADMUS 51169 - AUMENTAR O TAMANHO DA TABELA INTERNA P/ 800    *      */
        /*"      *  08/12/2010     WELLINGTON VERAS - TE39902                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V0SISTEMA         INPUT    *      */
        /*"      * CEDENTE                             V0CEDENTE         INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO_COBRANCA { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis MOVIMENTO_COBRANCA
        {
            get
            {
                _.Move(REG_COBRANCA, _MOVIMENTO_COBRANCA); VarBasis.RedefinePassValue(REG_COBRANCA, _MOVIMENTO_COBRANCA, REG_COBRANCA); return _MOVIMENTO_COBRANCA;
            }
        }
        public FileBasis _PF0002B1 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis PF0002B1
        {
            get
            {
                _.Move(REG_PF0002B1, _PF0002B1); VarBasis.RedefinePassValue(REG_PF0002B1, _PF0002B1, REG_PF0002B1); return _PF0002B1;
            }
        }
        public SortBasis<PF0002B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<PF0002B_REG_ARQSORT>(new PF0002B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public PF0002B_REG_ARQSORT REG_ARQSORT { get; set; } = new PF0002B_REG_ARQSORT();
        public class PF0002B_REG_ARQSORT : VarBasis
        {
            /*"  05      SOR-CODREGISTR      PIC  X(001).*/
            public StringBasis SOR_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-DETALHE         PIC  X(366).*/
            public StringBasis SOR_DETALHE { get; set; } = new StringBasis(new PIC("X", "366", "X(366)."), @"");
            /*"  05      SOR-CEDENTE         PIC  9(016).*/
            public IntBasis SOR_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      SOR-TIPO            PIC  9(001).*/
            public IntBasis SOR_TIPO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      SOR-CANAL           PIC  9(001).*/
            public IntBasis SOR_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      SOR-SPACES          PIC  X(015).*/
            public StringBasis SOR_SPACES { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"01        REG-COBRANCA.*/
        }
        public PF0002B_REG_COBRANCA REG_COBRANCA { get; set; } = new PF0002B_REG_COBRANCA();
        public class PF0002B_REG_COBRANCA : VarBasis
        {
            /*"  05      ENT-CODREGISTR      PIC  X(001).*/
            public StringBasis ENT_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      ENT-DETALHE         PIC  X(399).*/
            public StringBasis ENT_DETALHE { get; set; } = new StringBasis(new PIC("X", "399", "X(399)."), @"");
            /*"01  REG-PF0002B1                 PIC  X(400).*/
        }
        public StringBasis REG_PF0002B1 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_PRO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_COB { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_CED { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77    VIND-CODEMP               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORIGAVISO            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADT               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COUNT                PIC S9(004)     COMP.*/
        public IntBasis VIND_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTLIBER              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORDLIDER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPSGU               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_TIPSGU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-APOLIDER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_APOLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ENDOSLID             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ENDOSLID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODLIDER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-FONTE                PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRRCAP               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMAPOL              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRENDOS              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRPARCEL             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRTIT                PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRTIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODU             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGECOBR              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RECUPERA             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_RECUPERA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ACRESCIMO            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ACRESCIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRCERTIF             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRGER            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRMATRGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTGER            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VALADTGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGGER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTPAGGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTCANCEL             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTCANCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRSUN            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRMATRSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTSUN            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VALADTSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGSUN             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTPAGSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPO                 PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_TIPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTVENCTO             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis WSHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-CODPRODU            PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-NRCERTIF           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-SITUACAO           PIC  X(001).*/
        public StringBasis WSHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0SIST-DTMOVABE           PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0AGEN-BANCO              PIC S9(004)    COMP.*/
        public IntBasis V0AGEN_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AGEN-AGENCIA            PIC S9(004)    COMP.*/
        public IntBasis V0AGEN_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AGEN-ESTADO             PIC  X(002).*/
        public StringBasis V0AGEN_ESTADO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77    V0ACEF-AGENCIA            PIC S9(004)    COMP.*/
        public IntBasis V0ACEF_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ACEF-ESCNEG             PIC S9(004)    COMP.*/
        public IntBasis V0ACEF_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ACEF-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0ACEF_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PRPF-CODSIVPF           PIC S9(004)    COMP.*/
        public IntBasis V0PRPF_CODSIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PRPF-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0PRPF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PROD-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SFRC-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0SFRC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SFRC-NRTIT              PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0SFRC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MSIN-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0MSIN_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MSIN-NUMAPOL            PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0MSIN_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MSIN-NUM-APOL-SINISTRO  PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0MSIN_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MSIN-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0MSIN_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MSIN-ACORDO             PIC S9(009)    COMP.*/
        public IntBasis V0MSIN_ACORDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0BCOB-RAMOFR             PIC S9(004)     COMP.*/
        public IntBasis V0BCOB_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BCOB-CODOPCAO           PIC S9(004)     COMP.*/
        public IntBasis V0BCOB_CODOPCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BCOB-VLPRMTAR           PIC S9(010)V9(5)     COMP-3.*/
        public DoubleBasis V0BCOB_VLPRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77    V0BCOB-VLPRMTOT           PIC S9(013)V99       COMP-3.*/
        public DoubleBasis V0BCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0BCOB-PCIOCC             PIC S9(003)V99       COMP-3.*/
        public DoubleBasis V0BCOB_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77    VIND-VLPRMTOT             PIC S9(004)     COMP.*/
        public IntBasis VIND_VLPRMTOT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-PCIOCC               PIC S9(004)     COMP.*/
        public IntBasis VIND_PCIOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CEDE-NUMTIT             PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0CEDE_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CEDE-NUMTITMAX          PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0CEDE_NUMTITMAX { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CNAB-COD-EMP            PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CNAB-ORGAO              PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CNAB-NRCTACED           PIC S9(015)    VALUE +0   COMP-3*/
        public IntBasis V0CNAB_NRCTACED { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CNAB-TIPOCOB            PIC  X(001).*/
        public StringBasis V0CNAB_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0CNAB-DTMOVTO            PIC  X(010).*/
        public StringBasis V0CNAB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CNAB-DATCEF             PIC  X(010).*/
        public StringBasis V0CNAB_DATCEF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CNAB-NRSEQ              PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CNAB-QTDREG             PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_QTDREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0AVIS_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0AVIS_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0AVIS_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0AVIS-NRSEQ              PIC S9(009)     COMP.*/
        public IntBasis V0AVIS_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0AVIS-DTMOVTO            PIC  X(010).*/
        public StringBasis V0AVIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0AVIS-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0AVIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-TIPAVI             PIC  X(001).*/
        public StringBasis V0AVIS_TIPAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0AVIS-DTAVISO            PIC  X(010).*/
        public StringBasis V0AVIS_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0AVIS-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-VLDESPES           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-PRECED             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_PRECED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-VLPRMLIQ           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-SITCONTB           PIC  X(001).*/
        public StringBasis V0AVIS_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0AVIS-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0AVIS_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0AVIS-ORIGAVISO          PIC S9(004)     COMP.*/
        public IntBasis V0AVIS_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-VALADT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-COUNT              PIC S9(004)     COMP.*/
        public IntBasis V0AVIS_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SALD-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0SALD_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SALD-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0SALD_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SALD-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0SALD_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SALD-TIPSGU             PIC  X(001).*/
        public StringBasis V0SALD_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0SALD-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0SALD_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SALD-DTAVISO            PIC  X(010).*/
        public StringBasis V0SALD_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SALD-DTMOVTO            PIC  X(010).*/
        public StringBasis V0SALD_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SALD-SDOATU             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0SALD_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0SALD-SITUACAO           PIC  X(001).*/
        public StringBasis V0SALD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0SICB-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0SICB_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SICB-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0SICB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0SICB_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SICB-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0SICB_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0SICB-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0SICB_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-NRMATRVEN          PIC S9(015)     COMP-3.*/
        public IntBasis V0SICB_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0SICB-AGECTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0SICB_AGECTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-OPRCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0SICB_OPRCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-NUMCTAVEN          PIC S9(009)     COMP.*/
        public IntBasis V0SICB_NUMCTAVEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SICB-DIGCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0SICB_DIGCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-VLCOMIS            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0SICB_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0SICB-DTCREDITO          PIC  X(010).*/
        public StringBasis V0SICB_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SICB-DTQITBCO           PIC  X(010).*/
        public StringBasis V0SICB_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SICB-DTMOVTO            PIC  X(010).*/
        public StringBasis V0SICB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SICB-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0SICB_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0SICB-SITUACAO           PIC  X(001).*/
        public StringBasis V0SICB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FILT-NUMSIVPF           PIC S9(015)    VALUE +0   COMP-3*/
        public IntBasis V0FILT_NUMSIVPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FILT-NUMSICOB           PIC S9(015)    VALUE +0   COMP-3*/
        public IntBasis V0FILT_NUMSICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FILT-CODEMP             PIC S9(004)    COMP.*/
        public IntBasis V0FILT_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FILT-CODSIVPF           PIC S9(004)    COMP.*/
        public IntBasis V0FILT_CODSIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FILT-AGECOBR            PIC S9(004)    COMP.*/
        public IntBasis V0FILT_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FILT-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FILT_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FILT-DTQITBCO           PIC  X(010).*/
        public StringBasis V0FILT_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FILT-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0FILT_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FILT-CODUSU             PIC  X(008).*/
        public StringBasis V0FILT_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0FILT-COUNT              PIC S9(004)     COMP.*/
        public IntBasis V0FILT_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    CONVSICOB-NR-SICOB        PIC S9(015)    VALUE +0   COMP-3*/
        public IntBasis CONVSICOB_NR_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    CONVSICOB-AGEPGTO         PIC S9(004)               COMP.*/
        public IntBasis CONVSICOB_AGEPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    CONVSICOB-DTQITBCO        PIC  X(010).*/
        public StringBasis CONVSICOB_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    CONVSICOB-VAL-RCAP        PIC S9(015)V99 VALUE +0   COMP-3*/
        public DoubleBasis CONVSICOB_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77    CONVSICOB-COD-USUARIO      PIC X(08).*/
        public StringBasis CONVSICOB_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77    V0PARC-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0PARC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0PARC-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0PARC-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PARC-NRTIT              PIC S9(013)     COMP-3.*/
        public IntBasis V0PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V1ENDO-CODPRODU           PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-CODMOV             PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_CODMOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-BANCO              PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-AGENCIA            PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-NUMFITA            PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_NUMFITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-DTMOVTO            PIC  X(010).*/
        public StringBasis V0MCOB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0MCOB-DTQITBCO           PIC  X(010).*/
        public StringBasis V0MCOB_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0MCOB-NRTIT              PIC S9(013)     COMP-3.*/
        public IntBasis V0MCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MCOB-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0MCOB_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MCOB-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-VALTIT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MCOB_VALTIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MCOB-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MCOB_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MCOB-VALCDT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MCOB_VALCDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MCOB-SITUACAO           PIC  X(001).*/
        public StringBasis V0MCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0MCOB-NOME               PIC  X(040).*/
        public StringBasis V0MCOB_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0MCOB-TIPOMOV            PIC  X(001).*/
        public StringBasis V0MCOB_TIPOMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0MCOB-NUM-NOSSO-TITULO   PIC S9(16)  COMP-3 VALUE +0.*/
        public IntBasis V0MCOB_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
        /*"77    V0FOLL-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0FOLL_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0FOLL-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-DACPARC            PIC  X(001).*/
        public StringBasis V0FOLL_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FOLL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-HORAOPER           PIC  X(008).*/
        public StringBasis V0FOLL_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0FOLL-VLPREMIO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0FOLL_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FOLL-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-CODBAIXA           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_CODBAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-CDERRO01           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO02           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO03           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO04           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO05           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO06           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITUACAO           PIC  X(001).*/
        public StringBasis V0FOLL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITCONTB           PIC  X(001).*/
        public StringBasis V0FOLL_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-DTLIBER            PIC  X(010).*/
        public StringBasis V0FOLL_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-DTQITBCO           PIC  X(010).*/
        public StringBasis V0FOLL_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-ORDLIDER           PIC S9(015)     COMP-3.*/
        public IntBasis V0FOLL_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FOLL-TIPSGU             PIC  X(001).*/
        public StringBasis V0FOLL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-APOLIDER           PIC  X(015).*/
        public StringBasis V0FOLL_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77    V0FOLL-ENDOSLID           PIC  X(015).*/
        public StringBasis V0FOLL_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77    V0FOLL-CODLIDER           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NUM-NOSSO-TITULO   PIC S9(16)  COMP-3 VALUE +0.*/
        public IntBasis V0FOLL_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
        /*"77    V0RCAP-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NRPROPOS           PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NOME               PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0RCAP-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-VALPRI             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-DTCADAST           PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCAP-DTMOVTO            PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCAP-SITUACAO           PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCAP-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0RCAP_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0RCAP-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-NRTIT              PIC S9(013)     COMP-3.*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0RCAP-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-RECUPERA           PIC  X(001).*/
        public StringBasis V0RCAP_RECUPERA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCAP-ACRESCIMO          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCAP_ACRESCIMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-NRCERTIF           PIC S9(015)     COMP-3.*/
        public IntBasis V0RCAP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0RCOM-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-NRRCAPCO           PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-DTMOVTO            PIC  X(010).*/
        public StringBasis V0RCOM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-HORAOPER           PIC  X(010).*/
        public StringBasis V0RCOM_HORAOPER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-SITUACAO           PIC  X(001).*/
        public StringBasis V0RCOM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCOM-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCOM_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCOM-DATARCAP           PIC  X(010).*/
        public StringBasis V0RCOM_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-DTCADAST           PIC  X(010).*/
        public StringBasis V0RCOM_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-SITCONTB           PIC  X(001).*/
        public StringBasis V0RCOM_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCOM-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V1RCAP-NRTIT              PIC S9(013) VALUE +0  COMP-3.*/
        public IntBasis V1RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CFEN-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0CFEN_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CFEN-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-VALADT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTCREDITO          PIC  X(010).*/
        public StringBasis V0CFEN_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-NRMATRVEN          PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-AGECTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_AGECTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-OPRCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_OPRCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-NUMCTAVEN          PIC S9(009)     COMP.*/
        public IntBasis V0CFEN_NUMCTAVEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CFEN-DIGCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_DIGCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-AGECTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-OPRCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-NUMCTADEB          PIC S9(009)     COMP.*/
        public IntBasis V0CFEN_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CFEN-DIGCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-SINDICO            PIC  X(040).*/
        public StringBasis V0CFEN_SINDICO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0CFEN-DTQITBCO           PIC  X(010).*/
        public StringBasis V0CFEN_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTMOVTO            PIC  X(010).*/
        public StringBasis V0CFEN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-SITUACAO           PIC  X(001).*/
        public StringBasis V0CFEN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0CFEN-NRMATRGER          PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NRMATRGER { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-VALADTGER          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VALADTGER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTPAGGER           PIC  X(010).*/
        public StringBasis V0CFEN_DTPAGGER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-DTCANCEL           PIC  X(010).*/
        public StringBasis V0CFEN_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-NRMATRSUN          PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NRMATRSUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-VALADTSUN          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VALADTSUN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTPAGSUN           PIC  X(010).*/
        public StringBasis V0CFEN_DTPAGSUN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0VEND-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0VEND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0VEND-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0VEND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0VEND-DTQITBCO           PIC  X(010).*/
        public StringBasis V0VEND_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0VEND-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0VEND_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0VEND-DTMOVTO            PIC  X(010).*/
        public StringBasis V0VEND_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0TRBL-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0TRBL_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0TRBL-MATRICULA          PIC S9(015)     COMP-3.*/
        public IntBasis V0TRBL_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0TRBL-TIPOFUNC           PIC  X(001).*/
        public StringBasis V0TRBL_TIPOFUNC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0TRBL-NRCERTIF           PIC S9(015)     COMP-3.*/
        public IntBasis V0TRBL_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0TRBL-DTMOVTO            PIC  X(010).*/
        public StringBasis V0TRBL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0TRBL-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-SITUACAO           PIC  X(001).*/
        public StringBasis V0TRBL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0TRBL-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-ESCNEG             PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0TRBL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0TRBL-TARIFA             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0TRBL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0TRBL-BALCAO             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0TRBL_BALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0ADIA-CODPDT             PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0ADIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ADIA-NUMOPG             PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-VALADT             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0ADIA_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0ADIA-QTPRESTA           PIC S9(004)    COMP.*/
        public IntBasis V0ADIA_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ADIA-NRPROPOS           PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0ADIA_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0ADIA-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0ADIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ADIA-DTMOVTO            PIC  X(010).*/
        public StringBasis V0ADIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0ADIA-SITUACAO           PIC  X(001).*/
        public StringBasis V0ADIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0ADIA-CODEMP             PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-TIPO               PIC  X(001).*/
        public StringBasis V0ADIA_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FREC-CODPDT             PIC S9(009)    COMP.*/
        public IntBasis V0FREC_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FREC-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0FREC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FREC-NUMOPG             PIC S9(009)    COMP.*/
        public IntBasis V0FREC_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FREC-NRPROPOS           PIC S9(009)    COMP.*/
        public IntBasis V0FREC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FREC-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0FREC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0FREC-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0FREC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FREC-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0FREC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FREC-NUMPTC             PIC S9(004)    COMP.*/
        public IntBasis V0FREC_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FREC-VALRCP             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0FREC_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FREC-PCGACM             PIC S9(002)V999 COMP-3.*/
        public DoubleBasis V0FREC_PCGACM { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V999"), 3);
        /*"77    V0FREC-SITUACAO           PIC  X(001).*/
        public StringBasis V0FREC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FREC-VALSDO             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0FREC_VALSDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FREC-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FREC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FREC-DTVENCTO           PIC  X(010).*/
        public StringBasis V0FREC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FREC-CODEMP             PIC S9(009)    COMP.*/
        public IntBasis V0FREC_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-CODPDT             PIC S9(009)    COMP.*/
        public IntBasis V0HREC_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0HREC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HREC-NUMOPG             PIC S9(009)    COMP.*/
        public IntBasis V0HREC_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-NRPROPOS           PIC S9(009)    COMP.*/
        public IntBasis V0HREC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0HREC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0HREC-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0HREC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0HREC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HREC-NUMPTC             PIC S9(004)    COMP.*/
        public IntBasis V0HREC_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HREC-VALRCP             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0HREC_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0HREC-NUMREC             PIC S9(009)    COMP.*/
        public IntBasis V0HREC_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-DTMOVTO            PIC  X(010).*/
        public StringBasis V0HREC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0HREC-OPERACAO           PIC S9(004)    COMP.*/
        public IntBasis V0HREC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HREC-HORSIS             PIC  X(008).*/
        public StringBasis V0HREC_HORSIS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0HREC-CODEMP             PIC S9(009)    COMP.*/
        public IntBasis V0HREC_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-ANOREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_ANOREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-MESREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_MESREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-TIPOREG            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0DPCF-SITUACAO           PIC  X(001).*/
        public StringBasis V0DPCF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0DPCF-TIPOCOB            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0DPCF-DTMOVTO            PIC  X(010).*/
        public StringBasis V0DPCF_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0DPCF-DTAVISO            PIC  X(010).*/
        public StringBasis V0DPCF_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0DPCF-QTDREG             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_QTDREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLPRMLIQ           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLJUROS            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLJUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLMULTA            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WS-AUX-ARQUIVO.*/
        public PF0002B_WS_AUX_ARQUIVO WS_AUX_ARQUIVO { get; set; } = new PF0002B_WS_AUX_ARQUIVO();
        public class PF0002B_WS_AUX_ARQUIVO : VarBasis
        {
            /*"  03         WFIM-AGENCIAS      PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_AGENCIAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WFIM-PRODUTO       PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WFIM-BILCOBER      PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_BILCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WFIM-SORT          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         WS-SUBS            PIC  9(005)    VALUE   ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03         WS-SUBS1           PIC  9(005)    VALUE   ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03         WS-SUBS2           PIC  9(005)    VALUE   ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03         AC-INSERT          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_INSERT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-HEADER          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_HEADER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-TRAILL          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_TRAILL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-GRAFICA         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_GRAFICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-GRAFICA         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_GRAFICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         TT-OPCAO           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_OPCAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-OPCAO           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_OPCAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-SALVA           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_SALVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-SALVA1          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_SALVA1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WFIM-COBRANCA      PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WCHV-ERRO          PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WCHV_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         FLG-GRAFICA        PIC  X(001)    VALUE   SPACES.*/
            public StringBasis FLG_GRAFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         FLG-MALA           PIC  X(001)    VALUE   SPACES.*/
            public StringBasis FLG_MALA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         LD-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DE-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DE_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         NP-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis NP_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         IN-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         UP-MOVICOB         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_MOVICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AD-QTDEBIL         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AD_QTDEBIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AD-VLRABIL         PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AD_VLRABIL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         WS-VLPRMTAR        PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLPRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         IN-V0RCAP          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_V0RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         IN-CONVERSAO       PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_CONVERSAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-PRODUTO         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WS-VALADT          PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WS_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         WS-RESULT          PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         WS-RESTO           PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         WPARM11-AUX        PIC S9(007) VALUE ZEROS COMP-3.*/
            public IntBasis WPARM11_AUX { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03         CONVEN-DATAOCORREN PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis CONVEN_DATAOCORREN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         CONVEN-DTVENCTO    PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis CONVEN_DTVENCTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         CONVEN-DATA-CRED   PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis CONVEN_DATA_CRED { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         CONVEN-FONTE       PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis CONVEN_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         CONVEN-AGECOBR     PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis CONVEN_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         CONVEN-ESCNEG      PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis CONVEN_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         CONVEN-CODPRODU    PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis CONVEN_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         IN-FOLLOWUP        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AUX-NRENDOS        PIC S9(009)    COMP.*/
            public IntBasis AUX_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         AC-DUPLICA         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-CREDITO         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_CREDITO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-CED1144         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_CED1144 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-CAN1144         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_CAN1144 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-AGE1144         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_AGE1144 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-SFR1144         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_SFR1144 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WTEM-SIES          PIC  X(001)    VALUE  'N'.*/
            public StringBasis WTEM_SIES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WTEM-PROPOSTA      PIC  X(003)    VALUE  'NAO'.*/
            public StringBasis WTEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  03         AUX-NOME.*/
            public PF0002B_AUX_NOME AUX_NOME { get; set; } = new PF0002B_AUX_NOME();
            public class PF0002B_AUX_NOME : VarBasis
            {
                /*"    10       AUX-DESCRICAO      PIC  X(030).*/
                public StringBasis AUX_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10       AUX-DTVEN-DD       PIC  9(002).*/
                public IntBasis AUX_DTVEN_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-DTVEN-01       PIC  X(001).*/
                public StringBasis AUX_DTVEN_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       AUX-DTVEN-MM       PIC  9(002).*/
                public IntBasis AUX_DTVEN_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-DTVEN-02       PIC  X(001).*/
                public StringBasis AUX_DTVEN_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       AUX-DTVEN-A1       PIC  9(002).*/
                public IntBasis AUX_DTVEN_A1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-DTVEN-A2       PIC  9(002).*/
                public IntBasis AUX_DTVEN_A2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WWORK-MIN-NRTIT    PIC  9(011)    VALUE   ZEROS.*/
            }
            public IntBasis WWORK_MIN_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WWORK-MIN-NRTIT.*/
            private _REDEF_PF0002B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0002B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0002B_FILLER_0(); _.Move(WWORK_MIN_NRTIT, _filler_0); VarBasis.RedefinePassValue(WWORK_MIN_NRTIT, _filler_0, WWORK_MIN_NRTIT); _filler_0.ValueChanged += () => { _.Move(_filler_0, WWORK_MIN_NRTIT); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WWORK_MIN_NRTIT); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_0 : VarBasis
            {
                /*"    10       WWORK-MINNRO       PIC  9(010).*/
                public IntBasis WWORK_MINNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MINDIG       PIC  9(001).*/
                public IntBasis WWORK_MINDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-MAX-NRTIT    PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF0002B_FILLER_0()
                {
                    WWORK_MINNRO.ValueChanged += OnValueChanged;
                    WWORK_MINDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MAX_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WWORK-MAX-NRTIT.*/
            private _REDEF_PF0002B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0002B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0002B_FILLER_1(); _.Move(WWORK_MAX_NRTIT, _filler_1); VarBasis.RedefinePassValue(WWORK_MAX_NRTIT, _filler_1, WWORK_MAX_NRTIT); _filler_1.ValueChanged += () => { _.Move(_filler_1, WWORK_MAX_NRTIT); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WWORK_MAX_NRTIT); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_1 : VarBasis
            {
                /*"    10       WWORK-MAXNRO       PIC  9(010).*/
                public IntBasis WWORK_MAXNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MAXDIG       PIC  9(001).*/
                public IntBasis WWORK_MAXDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-NSO-NUMERO   PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF0002B_FILLER_1()
                {
                    WWORK_MAXNRO.ValueChanged += OnValueChanged;
                    WWORK_MAXDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NSO_NUMERO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WWORK-NSO-NUMERO.*/
            private _REDEF_PF0002B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0002B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0002B_FILLER_2(); _.Move(WWORK_NSO_NUMERO, _filler_2); VarBasis.RedefinePassValue(WWORK_NSO_NUMERO, _filler_2, WWORK_NSO_NUMERO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WWORK_NSO_NUMERO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WWORK_NSO_NUMERO); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_2 : VarBasis
            {
                /*"    10       WWORK-PRETIT       PIC  9(001).*/
                public IntBasis WWORK_PRETIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WWORK-NRRCAP       PIC  9(009).*/
                public IntBasis WWORK_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       WWORK-DIGTIT       PIC  9(001).*/
                public IntBasis WWORK_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WS-NRTIT           PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF0002B_FILLER_2()
                {
                    WWORK_PRETIT.ValueChanged += OnValueChanged;
                    WWORK_NRRCAP.ValueChanged += OnValueChanged;
                    WWORK_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WS-NRTIT.*/
            private _REDEF_PF0002B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0002B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0002B_FILLER_3(); _.Move(WS_NRTIT, _filler_3); VarBasis.RedefinePassValue(WS_NRTIT, _filler_3, WS_NRTIT); _filler_3.ValueChanged += () => { _.Move(_filler_3, WS_NRTIT); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_3 : VarBasis
            {
                /*"      10     WS-NUMTIT          PIC  9(010).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10     WS-DIGTIT          PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-TIT-CED1144    PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_PF0002B_FILLER_3()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_TIT_CED1144 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-TIT-CED1144.*/
            private _REDEF_PF0002B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0002B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0002B_FILLER_4(); _.Move(AUX_TIT_CED1144, _filler_4); VarBasis.RedefinePassValue(AUX_TIT_CED1144, _filler_4, AUX_TIT_CED1144); _filler_4.ValueChanged += () => { _.Move(_filler_4, AUX_TIT_CED1144); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, AUX_TIT_CED1144); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_4 : VarBasis
            {
                /*"    10       FILLER             PIC  X(004).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       AUX-NUM-CED1144    PIC  9(010).*/
                public IntBasis AUX_NUM_CED1144 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"  03         AUX-TIT-GRAFICA    PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_PF0002B_FILLER_4()
                {
                    FILLER_5.ValueChanged += OnValueChanged;
                    AUX_NUM_CED1144.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_TIT_GRAFICA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-TIT-GRAFICA.*/
            private _REDEF_PF0002B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PF0002B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PF0002B_FILLER_6(); _.Move(AUX_TIT_GRAFICA, _filler_6); VarBasis.RedefinePassValue(AUX_TIT_GRAFICA, _filler_6, AUX_TIT_GRAFICA); _filler_6.ValueChanged += () => { _.Move(_filler_6, AUX_TIT_GRAFICA); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, AUX_TIT_GRAFICA); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_6 : VarBasis
            {
                /*"    10       FILLER             PIC  X(003).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10       AUX-NUM-GRAFICA    PIC  9(011).*/
                public IntBasis AUX_NUM_GRAFICA { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"  03         AUX-USO-EMPRESA.*/

                public _REDEF_PF0002B_FILLER_6()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                    AUX_NUM_GRAFICA.ValueChanged += OnValueChanged;
                }

            }
            public PF0002B_AUX_USO_EMPRESA AUX_USO_EMPRESA { get; set; } = new PF0002B_AUX_USO_EMPRESA();
            public class PF0002B_AUX_USO_EMPRESA : VarBasis
            {
                /*"    10       AUX-OITO           PIC  X(001).*/
                public StringBasis AUX_OITO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       AUX-TITSIVPF       PIC  9(014).*/
                public IntBasis AUX_TITSIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10       AUX-ESPACOS        PIC  X(010).*/
                public StringBasis AUX_ESPACOS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03         AUX-NRO-SIVPF      PIC  9(014)    VALUE   ZEROS.*/
            }
            public IntBasis AUX_NRO_SIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-NRO-SIVPF.*/
            private _REDEF_PF0002B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PF0002B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PF0002B_FILLER_8(); _.Move(AUX_NRO_SIVPF, _filler_8); VarBasis.RedefinePassValue(AUX_NRO_SIVPF, _filler_8, AUX_NRO_SIVPF); _filler_8.ValueChanged += () => { _.Move(_filler_8, AUX_NRO_SIVPF); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, AUX_NRO_SIVPF); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_8 : VarBasis
            {
                /*"    10       AUX-CANAL          PIC  9(001).*/
                public IntBasis AUX_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       AUX-AGENCIA        PIC  9(004).*/
                public IntBasis AUX_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       AUX-PRDSIVPF       PIC  9(002).*/
                public IntBasis AUX_PRDSIVPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-NRSEQ          PIC  9(006).*/
                public IntBasis AUX_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       AUX-DIGITO         PIC  9(001).*/
                public IntBasis AUX_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-APOLICE        PIC  9(014)    VALUE   ZEROS.*/

                public _REDEF_PF0002B_FILLER_8()
                {
                    AUX_CANAL.ValueChanged += OnValueChanged;
                    AUX_AGENCIA.ValueChanged += OnValueChanged;
                    AUX_PRDSIVPF.ValueChanged += OnValueChanged;
                    AUX_NRSEQ.ValueChanged += OnValueChanged;
                    AUX_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_APOLICE { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-APOLICE.*/
            private _REDEF_PF0002B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_PF0002B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_PF0002B_FILLER_9(); _.Move(AUX_APOLICE, _filler_9); VarBasis.RedefinePassValue(AUX_APOLICE, _filler_9, AUX_APOLICE); _filler_9.ValueChanged += () => { _.Move(_filler_9, AUX_APOLICE); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, AUX_APOLICE); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_9 : VarBasis
            {
                /*"    10       AUX-NUMAPOL        PIC  9(013).*/
                public IntBasis AUX_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       AUX-DIGAPOL        PIC  9(001).*/
                public IntBasis AUX_DIGAPOL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-ENDOSLID.*/

                public _REDEF_PF0002B_FILLER_9()
                {
                    AUX_NUMAPOL.ValueChanged += OnValueChanged;
                    AUX_DIGAPOL.ValueChanged += OnValueChanged;
                }

            }
            public PF0002B_AUX_ENDOSLID AUX_ENDOSLID { get; set; } = new PF0002B_AUX_ENDOSLID();
            public class PF0002B_AUX_ENDOSLID : VarBasis
            {
                /*"    10       AUX-CODPRODU       PIC  9(004).*/
                public IntBasis AUX_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(011).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"  03         AUX-NRO-RESSA      PIC  9(014)    VALUE   ZEROS.*/
            }
            public IntBasis AUX_NRO_RESSA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-NRO-RESSA.*/
            private _REDEF_PF0002B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_PF0002B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_PF0002B_FILLER_11(); _.Move(AUX_NRO_RESSA, _filler_11); VarBasis.RedefinePassValue(AUX_NRO_RESSA, _filler_11, AUX_NRO_RESSA); _filler_11.ValueChanged += () => { _.Move(_filler_11, AUX_NRO_RESSA); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, AUX_NRO_RESSA); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_11 : VarBasis
            {
                /*"    10       AUX-NRO-APOL       PIC  9(010).*/
                public IntBasis AUX_NRO_APOL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       AUX-NRO-PARC       PIC  9(004).*/
                public IntBasis AUX_NRO_PARC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         RES-APOLICE        PIC  9(013)    VALUE   ZEROS.*/

                public _REDEF_PF0002B_FILLER_11()
                {
                    AUX_NRO_APOL.ValueChanged += OnValueChanged;
                    AUX_NRO_PARC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis RES_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      RES-APOLICE.*/
            private _REDEF_PF0002B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_PF0002B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_PF0002B_FILLER_12(); _.Move(RES_APOLICE, _filler_12); VarBasis.RedefinePassValue(RES_APOLICE, _filler_12, RES_APOLICE); _filler_12.ValueChanged += () => { _.Move(_filler_12, RES_APOLICE); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, RES_APOLICE); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_12 : VarBasis
            {
                /*"    10       RES-PREAPOL        PIC  9(003).*/
                public IntBasis RES_PREAPOL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       RES-NUMAPOL        PIC  9(010).*/
                public IntBasis RES_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"  03         SIN-NRO-RESSA      PIC  9(014)    VALUE   ZEROS.*/

                public _REDEF_PF0002B_FILLER_12()
                {
                    RES_PREAPOL.ValueChanged += OnValueChanged;
                    RES_NUMAPOL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis SIN_NRO_RESSA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      SIN-NRO-RESSA.*/
            private _REDEF_PF0002B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_PF0002B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_PF0002B_FILLER_13(); _.Move(SIN_NRO_RESSA, _filler_13); VarBasis.RedefinePassValue(SIN_NRO_RESSA, _filler_13, SIN_NRO_RESSA); _filler_13.ValueChanged += () => { _.Move(_filler_13, SIN_NRO_RESSA); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, SIN_NRO_RESSA); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_13 : VarBasis
            {
                /*"    10       SIN-NRO-RAMO       PIC  9(002).*/
                public IntBasis SIN_NRO_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       SIN-NRO-APOL       PIC  9(006).*/
                public IntBasis SIN_NRO_APOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       FILLER             PIC  9(006).*/
                public IntBasis FILLER_14 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  03         SIN-APOLICE        PIC  9(013)    VALUE   ZEROS.*/

                public _REDEF_PF0002B_FILLER_13()
                {
                    SIN_NRO_RAMO.ValueChanged += OnValueChanged;
                    SIN_NRO_APOL.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis SIN_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      SIN-APOLICE.*/
            private _REDEF_PF0002B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_PF0002B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_PF0002B_FILLER_15(); _.Move(SIN_APOLICE, _filler_15); VarBasis.RedefinePassValue(SIN_APOLICE, _filler_15, SIN_APOLICE); _filler_15.ValueChanged += () => { _.Move(_filler_15, SIN_APOLICE); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, SIN_APOLICE); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_15 : VarBasis
            {
                /*"    10       SIN-AUX-ORGAO      PIC  9(003).*/
                public IntBasis SIN_AUX_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       SIN-AUX-RAMO       PIC  9(002).*/
                public IntBasis SIN_AUX_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       SIN-AUX-ZERO       PIC  9(002).*/
                public IntBasis SIN_AUX_ZERO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       SIN-AUX-APOL       PIC  9(006).*/
                public IntBasis SIN_AUX_APOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"01  WS-AUX-DATAS.*/

                public _REDEF_PF0002B_FILLER_15()
                {
                    SIN_AUX_ORGAO.ValueChanged += OnValueChanged;
                    SIN_AUX_RAMO.ValueChanged += OnValueChanged;
                    SIN_AUX_ZERO.ValueChanged += OnValueChanged;
                    SIN_AUX_APOL.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0002B_WS_AUX_DATAS WS_AUX_DATAS { get; set; } = new PF0002B_WS_AUX_DATAS();
        public class PF0002B_WS_AUX_DATAS : VarBasis
        {
            /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_PF0002B_FILLER_16 _filler_16 { get; set; }
            public _REDEF_PF0002B_FILLER_16 FILLER_16
            {
                get { _filler_16 = new _REDEF_PF0002B_FILLER_16(); _.Move(WDATA_REL, _filler_16); VarBasis.RedefinePassValue(WDATA_REL, _filler_16, WDATA_REL); _filler_16.ValueChanged += () => { _.Move(_filler_16, WDATA_REL); }; return _filler_16; }
                set { VarBasis.RedefinePassValue(value, _filler_16, WDATA_REL); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_16 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDAT-REL-LIT.*/

                public _REDEF_PF0002B_FILLER_16()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_17.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_18.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public PF0002B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new PF0002B_WDAT_REL_LIT();
            public class PF0002B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA       PIC  9(002).*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '/'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES       PIC  9(002).*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '/'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO       PIC  9(004).*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-FITA.*/
            }
            public PF0002B_WDATA_FITA WDATA_FITA { get; set; } = new PF0002B_WDATA_FITA();
            public class PF0002B_WDATA_FITA : VarBasis
            {
                /*"    10       WDAT-FITA-DIA      PIC  X(002).*/
                public StringBasis WDAT_FITA_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WDAT-FITA-MES      PIC  X(002).*/
                public StringBasis WDAT_FITA_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WDAT-FITA-ANO.*/
                public PF0002B_WDAT_FITA_ANO WDAT_FITA_ANO { get; set; } = new PF0002B_WDAT_FITA_ANO();
                public class PF0002B_WDAT_FITA_ANO : VarBasis
                {
                    /*"      15     WDAT-FITA-ANO-A    PIC  X(001).*/
                    public StringBasis WDAT_FITA_ANO_A { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WDAT-FITA-ANO-D    PIC  X(001).*/
                    public StringBasis WDAT_FITA_ANO_D { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"  03         WDATA-TABELA.*/
                }
            }
            public PF0002B_WDATA_TABELA WDATA_TABELA { get; set; } = new PF0002B_WDATA_TABELA();
            public class PF0002B_WDATA_TABELA : VarBasis
            {
                /*"    10       WDAT-TAB-SEC       PIC  9(002).*/
                public IntBasis WDAT_TAB_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-TAB-ANO       PIC  9(002).*/
                public IntBasis WDAT_TAB_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-MES       PIC  9(002).*/
                public IntBasis WDAT_TAB_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-DIA       PIC  9(002).*/
                public IntBasis WDAT_TAB_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-SECULO       PIC  9(008)    VALUE   ZEROS.*/
            }
            public IntBasis WDATA_SECULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER             REDEFINES      WDATA-SECULO.*/
            private _REDEF_PF0002B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_PF0002B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_PF0002B_FILLER_23(); _.Move(WDATA_SECULO, _filler_23); VarBasis.RedefinePassValue(WDATA_SECULO, _filler_23, WDATA_SECULO); _filler_23.ValueChanged += () => { _.Move(_filler_23, WDATA_SECULO); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, WDATA_SECULO); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_23 : VarBasis
            {
                /*"    10       WDAT-SEC-SEC       PIC  9(002).*/
                public IntBasis WDAT_SEC_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-SEC-ANO       PIC  9(002).*/
                public IntBasis WDAT_SEC_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-SEC-MES       PIC  9(002).*/
                public IntBasis WDAT_SEC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-SEC-DIA       PIC  9(002).*/
                public IntBasis WDAT_SEC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS000-DATA         PIC  9(008)    VALUE   ZEROS.*/

                public _REDEF_PF0002B_FILLER_23()
                {
                    WDAT_SEC_SEC.ValueChanged += OnValueChanged;
                    WDAT_SEC_ANO.ValueChanged += OnValueChanged;
                    WDAT_SEC_MES.ValueChanged += OnValueChanged;
                    WDAT_SEC_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS000_DATA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER             REDEFINES      WS000-DATA.*/
            private _REDEF_PF0002B_FILLER_24 _filler_24 { get; set; }
            public _REDEF_PF0002B_FILLER_24 FILLER_24
            {
                get { _filler_24 = new _REDEF_PF0002B_FILLER_24(); _.Move(WS000_DATA, _filler_24); VarBasis.RedefinePassValue(WS000_DATA, _filler_24, WS000_DATA); _filler_24.ValueChanged += () => { _.Move(_filler_24, WS000_DATA); }; return _filler_24; }
                set { VarBasis.RedefinePassValue(value, _filler_24, WS000_DATA); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_24 : VarBasis
            {
                /*"    10       WS000-ANO          PIC  9(004).*/
                public IntBasis WS000_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS000-MES          PIC  9(002).*/
                public IntBasis WS000_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS000-DIA          PIC  9(002).*/
                public IntBasis WS000_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_PF0002B_FILLER_24()
                {
                    WS000_ANO.ValueChanged += OnValueChanged;
                    WS000_MES.ValueChanged += OnValueChanged;
                    WS000_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_PF0002B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_PF0002B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_PF0002B_FILLER_25(); _.Move(WTIME_DAY, _filler_25); VarBasis.RedefinePassValue(WTIME_DAY, _filler_25, WTIME_DAY); _filler_25.ValueChanged += () => { _.Move(_filler_25, WTIME_DAY); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_25 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public PF0002B_WTIME_DAYR WTIME_DAYR { get; set; } = new PF0002B_WTIME_DAYR();
                public class PF0002B_WTIME_DAYR : VarBasis
                {
                    /*"      10     WTIME-HORA         PIC  9(002).*/
                    public IntBasis WTIME_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-MINU         PIC  9(002).*/
                    public IntBasis WTIME_MINU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-SEGU         PIC  9(002).*/
                    public IntBasis WTIME_SEGU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WTIME-2PT3         PIC  X(001).*/

                    public PF0002B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WTIME-CCSE         PIC  9(002).*/
                public IntBasis WTIME_CCSE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-TIME.*/

                public _REDEF_PF0002B_FILLER_25()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public PF0002B_WS_TIME WS_TIME { get; set; } = new PF0002B_WS_TIME();
            public class PF0002B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  WS-AUX-AVISO.*/
            }
        }
        public PF0002B_WS_AUX_AVISO WS_AUX_AVISO { get; set; } = new PF0002B_WS_AUX_AVISO();
        public class PF0002B_WS_AUX_AVISO : VarBasis
        {
            /*"  03  WWORK-BCOAVISO            PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WWORK_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WWORK-NUMFITA             PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis WWORK_NUMFITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  WWORK-DATCEF              PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis WWORK_DATCEF { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03  WWORK-DATCEF1             PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis WWORK_DATCEF1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  WWORK-DTAVISO             PIC  X(010)    VALUE   SPACES.*/
            public StringBasis WWORK_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03  WWORK-ORIGAVISO           PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WWORK_ORIGAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WWORK-TIPAVI              PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WWORK_TIPAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WWORK-CODMOV              PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WWORK_CODMOV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WWORK-SITUACAO            PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WWORK_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         WWORK-CODEMPRE     PIC  9(016)    VALUE   ZEROS.*/
            public IntBasis WWORK_CODEMPRE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03         FILLER             REDEFINES      WWORK-CODEMPRE.*/
            private _REDEF_PF0002B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_PF0002B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_PF0002B_FILLER_26(); _.Move(WWORK_CODEMPRE, _filler_26); VarBasis.RedefinePassValue(WWORK_CODEMPRE, _filler_26, WWORK_CODEMPRE); _filler_26.ValueChanged += () => { _.Move(_filler_26, WWORK_CODEMPRE); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, WWORK_CODEMPRE); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_26 : VarBasis
            {
                /*"    10       WWORK-NRCTACED     PIC  9(015).*/
                public IntBasis WWORK_NRCTACED { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       FILLER             PIC  9(001).*/
                public IntBasis FILLER_27 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-CEDENTE     PIC  9(016)    VALUE ZEROS.*/

                public _REDEF_PF0002B_FILLER_26()
                {
                    WWORK_NRCTACED.ValueChanged += OnValueChanged;
                    FILLER_27.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03         FILLER            REDEFINES      WWORK-CEDENTE.*/
            private _REDEF_PF0002B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_PF0002B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_PF0002B_FILLER_28(); _.Move(WWORK_CEDENTE, _filler_28); VarBasis.RedefinePassValue(WWORK_CEDENTE, _filler_28, WWORK_CEDENTE); _filler_28.ValueChanged += () => { _.Move(_filler_28, WWORK_CEDENTE); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, WWORK_CEDENTE); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_28 : VarBasis
            {
                /*"    10       WWORK-CED-AGE     PIC  9(004).*/
                public IntBasis WWORK_CED_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-CED-OPE     PIC  9(003).*/
                public IntBasis WWORK_CED_OPE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-CED-CTA1    PIC  9(005).*/
                public IntBasis WWORK_CED_CTA1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10       WWORK-CED-CTA2    PIC  9(003).*/
                public IntBasis WWORK_CED_CTA2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-CED-DIG     PIC  9(001).*/
                public IntBasis WWORK_CED_DIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-AGEAVISO    PIC  9(004)    VALUE ZEROS.*/

                public _REDEF_PF0002B_FILLER_28()
                {
                    WWORK_CED_AGE.ValueChanged += OnValueChanged;
                    WWORK_CED_OPE.ValueChanged += OnValueChanged;
                    WWORK_CED_CTA1.ValueChanged += OnValueChanged;
                    WWORK_CED_CTA2.ValueChanged += OnValueChanged;
                    WWORK_CED_DIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         FILLER            REDEFINES      WWORK-AGEAVISO.*/
            private _REDEF_PF0002B_FILLER_29 _filler_29 { get; set; }
            public _REDEF_PF0002B_FILLER_29 FILLER_29
            {
                get { _filler_29 = new _REDEF_PF0002B_FILLER_29(); _.Move(WWORK_AGEAVISO, _filler_29); VarBasis.RedefinePassValue(WWORK_AGEAVISO, _filler_29, WWORK_AGEAVISO); _filler_29.ValueChanged += () => { _.Move(_filler_29, WWORK_AGEAVISO); }; return _filler_29; }
                set { VarBasis.RedefinePassValue(value, _filler_29, WWORK_AGEAVISO); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_29 : VarBasis
            {
                /*"    10       WWORK-TIP-AGE     PIC  9(001).*/
                public IntBasis WWORK_TIP_AGE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WWORK-COD-AGE     PIC  9(003).*/
                public IntBasis WWORK_COD_AGE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  03         WWORK-NRAVISO     PIC  9(009)    VALUE ZEROS.*/

                public _REDEF_PF0002B_FILLER_29()
                {
                    WWORK_TIP_AGE.ValueChanged += OnValueChanged;
                    WWORK_COD_AGE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      WWORK-NRAVISO.*/
            private _REDEF_PF0002B_FILLER_30 _filler_30 { get; set; }
            public _REDEF_PF0002B_FILLER_30 FILLER_30
            {
                get { _filler_30 = new _REDEF_PF0002B_FILLER_30(); _.Move(WWORK_NRAVISO, _filler_30); VarBasis.RedefinePassValue(WWORK_NRAVISO, _filler_30, WWORK_NRAVISO); _filler_30.ValueChanged += () => { _.Move(_filler_30, WWORK_NRAVISO); }; return _filler_30; }
                set { VarBasis.RedefinePassValue(value, _filler_30, WWORK_NRAVISO); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_30 : VarBasis
            {
                /*"    10       WWORK-AVS-AGE     PIC  9(004).*/
                public IntBasis WWORK_AVS_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-AVS-NRO     PIC  9(005).*/
                public IntBasis WWORK_AVS_NRO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03         WABEND.*/

                public _REDEF_PF0002B_FILLER_30()
                {
                    WWORK_AVS_AGE.ValueChanged += OnValueChanged;
                    WWORK_AVS_NRO.ValueChanged += OnValueChanged;
                }

            }
            public PF0002B_WABEND WABEND { get; set; } = new PF0002B_WABEND();
            public class PF0002B_WABEND : VarBasis
            {
                /*"    05       FILLER             PIC  X(010)    VALUE            ' PF0002B  '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PF0002B  ");
                /*"    05       FILLER             PIC  X(028)    VALUE            ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05       WNR-EXEC-SQL       PIC  X(004).*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    05       FILLER             PIC  X(014)    VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05       WSQLCODE           PIC  ZZZZZ999-.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
                /*"    05      FILLER              PIC  X(014)    VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05       WSQLERRD1          PIC  ZZZZZ999-.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
                /*"    05       FILLER             PIC  X(014)    VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05       WSQLERRD2          PIC  ZZZZZ999-.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
                /*"01        HEADER-REGISTRO.*/
            }
        }
        public PF0002B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new PF0002B_HEADER_REGISTRO();
        public class PF0002B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTR   PIC  X(001).*/
            public StringBasis HEADER_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODRETORNO   PIC  X(001).*/
            public StringBasis HEADER_CODRETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-LITRETORNO   PIC  X(007).*/
            public StringBasis HEADER_LITRETORNO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"  05      HEADER-CODSERVICO   PIC  X(002).*/
            public StringBasis HEADER_CODSERVICO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      HEADER-LITSERVICO   PIC  X(015).*/
            public StringBasis HEADER_LITSERVICO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      HEADER-CODEMPRESA   PIC  9(016).*/
            public IntBasis HEADER_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              REDEFINES     HEADER-CODEMPRESA.*/
            private _REDEF_PF0002B_FILLER_36 _filler_36 { get; set; }
            public _REDEF_PF0002B_FILLER_36 FILLER_36
            {
                get { _filler_36 = new _REDEF_PF0002B_FILLER_36(); _.Move(HEADER_CODEMPRESA, _filler_36); VarBasis.RedefinePassValue(HEADER_CODEMPRESA, _filler_36, HEADER_CODEMPRESA); _filler_36.ValueChanged += () => { _.Move(_filler_36, HEADER_CODEMPRESA); }; return _filler_36; }
                set { VarBasis.RedefinePassValue(value, _filler_36, HEADER_CODEMPRESA); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_36 : VarBasis
            {
                /*"    10    HEADER-AGENCIA      PIC  9(004).*/
                public IntBasis HEADER_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-OPERACAO     PIC  9(003).*/
                public IntBasis HEADER_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    HEADER-NUMCONTA     PIC  9(008).*/
                public IntBasis HEADER_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10    HEADER-DIGCONTA     PIC  9(001).*/
                public IntBasis HEADER_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05      FILLER              PIC  X(004).*/

                public _REDEF_PF0002B_FILLER_36()
                {
                    HEADER_AGENCIA.ValueChanged += OnValueChanged;
                    HEADER_OPERACAO.ValueChanged += OnValueChanged;
                    HEADER_NUMCONTA.ValueChanged += OnValueChanged;
                    HEADER_DIGCONTA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(030).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  X(003).*/
            public StringBasis HEADER_CODBANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      HEADER-NOMEBANCO    PIC  X(015).*/
            public StringBasis HEADER_NOMEBANCO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      HEADER-DATAGRAVAC   PIC  9(006).*/
            public IntBasis HEADER_DATAGRAVAC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-MSGREJEIC    PIC  X(058).*/
            public StringBasis HEADER_MSGREJEIC { get; set; } = new StringBasis(new PIC("X", "58", "X(058)."), @"");
            /*"  05      FILLER              PIC  X(209).*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "209", "X(209)."), @"");
            /*"  05      HEADER-CEDENTE      PIC  9(016).*/
            public IntBasis HEADER_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      HEADER-TIPO         PIC  9(001).*/
            public IntBasis HEADER_TIPO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CANAL        PIC  9(001).*/
            public IntBasis HEADER_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER              PIC  X(004).*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      HEADER-NUMFITA      PIC  9(005).*/
            public IntBasis HEADER_NUMFITA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      HEADER-NRSEQ        PIC  9(006).*/
            public IntBasis HEADER_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        COBRAN-REGISTRO.*/
        }
        public PF0002B_COBRAN_REGISTRO COBRAN_REGISTRO { get; set; } = new PF0002B_COBRAN_REGISTRO();
        public class PF0002B_COBRAN_REGISTRO : VarBasis
        {
            /*"  05      COBRAN-CODREGISTR   PIC  X(001).*/
            public StringBasis COBRAN_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      COBRAN-INSCEMPRES   PIC  9(002).*/
            public IntBasis COBRAN_INSCEMPRES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-NUMINSCRIC   PIC  9(014).*/
            public IntBasis COBRAN_NUMINSCRIC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05      COBRAN-CODEMPRESA   PIC  9(016).*/
            public IntBasis COBRAN_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      COBRAN-CONSISTE1    PIC  X(004).*/
            public StringBasis COBRAN_CONSISTE1 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      COBRAN-USO-EMPRESA.*/
            public PF0002B_COBRAN_USO_EMPRESA COBRAN_USO_EMPRESA { get; set; } = new PF0002B_COBRAN_USO_EMPRESA();
            public class PF0002B_COBRAN_USO_EMPRESA : VarBasis
            {
                /*"    10    COBRAN-TITULO16     PIC  9(016).*/
                public IntBasis COBRAN_TITULO16 { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10    COBRAN-CONSISTE2    PIC  X(009).*/
                public StringBasis COBRAN_CONSISTE2 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"  05      COBRAN-NOSS-NUMERO  PIC  9(011).*/
            }
            public IntBasis COBRAN_NOSS_NUMERO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  05      COBRAN-FILLER2      PIC  X(006).*/
            public StringBasis COBRAN_FILLER2 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05      COBRAN-CODREJEIC    PIC  9(003).*/
            public IntBasis COBRAN_CODREJEIC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      COBRAN-USO-BANCO    PIC  X(024).*/
            public StringBasis COBRAN_USO_BANCO { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
            /*"  05      COBRAN-CODCARTEIRA  PIC  X(002).*/
            public StringBasis COBRAN_CODCARTEIRA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      COBRAN-CODOCORRENC  PIC  9(002).*/
            public IntBasis COBRAN_CODOCORRENC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-DATAOCORREN  PIC  9(006).*/
            public IntBasis COBRAN_DATAOCORREN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      COBRAN-SEU-NUMERO   PIC  X(010).*/
            public StringBasis COBRAN_SEU_NUMERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      COBRAN-FILLER3      PIC  X(020).*/
            public StringBasis COBRAN_FILLER3 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      COBRAN-DTVENCTO     PIC  9(006).*/
            public IntBasis COBRAN_DTVENCTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      COBRAN-VLR-CRS      PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_CRS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-COD-BCO      PIC  9(003).*/
            public IntBasis COBRAN_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      COBRAN-AGE-BCO      PIC  9(005).*/
            public IntBasis COBRAN_AGE_BCO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      FILLER              REDEFINES     COBRAN-AGE-BCO.*/
            private _REDEF_PF0002B_FILLER_40 _filler_40 { get; set; }
            public _REDEF_PF0002B_FILLER_40 FILLER_40
            {
                get { _filler_40 = new _REDEF_PF0002B_FILLER_40(); _.Move(COBRAN_AGE_BCO, _filler_40); VarBasis.RedefinePassValue(COBRAN_AGE_BCO, _filler_40, COBRAN_AGE_BCO); _filler_40.ValueChanged += () => { _.Move(_filler_40, COBRAN_AGE_BCO); }; return _filler_40; }
                set { VarBasis.RedefinePassValue(value, _filler_40, COBRAN_AGE_BCO); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_40 : VarBasis
            {
                /*"    10    COBRAN-AGE-COBRAN   PIC  9(004).*/
                public IntBasis COBRAN_AGE_COBRAN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    COBRAN-AGE-DIGITO   PIC  9(001).*/
                public IntBasis COBRAN_AGE_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05      COBRAN-ESPECIE      PIC  X(002).*/

                public _REDEF_PF0002B_FILLER_40()
                {
                    COBRAN_AGE_COBRAN.ValueChanged += OnValueChanged;
                    COBRAN_AGE_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis COBRAN_ESPECIE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      COBRAN-DESPESAS     PIC  9(011)V99.*/
            public DoubleBasis COBRAN_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-FILLER4      PIC  X(026).*/
            public StringBasis COBRAN_FILLER4 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"  05      COBRAN-IOF          PIC  9(011)V99.*/
            public DoubleBasis COBRAN_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-ABATIMENTO   PIC  9(011)V99.*/
            public DoubleBasis COBRAN_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-DESC-CONCED  PIC  9(011)V99.*/
            public DoubleBasis COBRAN_DESC_CONCED { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-PRINC    PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_PRINC { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-JUROS        PIC  9(011)V99.*/
            public DoubleBasis COBRAN_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-MULTA        PIC  9(011)V99.*/
            public DoubleBasis COBRAN_MULTA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-COD-MOEDA    PIC  X(001).*/
            public StringBasis COBRAN_COD_MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      COBRAN-DATA-CRED    PIC  9(006).*/
            public IntBasis COBRAN_DATA_CRED { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      COBRAN-CC-INDICADOR PIC  X(023).*/
            public StringBasis COBRAN_CC_INDICADOR { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
            /*"  05      FILLER              REDEFINES     COBRAN-CC-INDICADOR.*/
            private _REDEF_PF0002B_FILLER_41 _filler_41 { get; set; }
            public _REDEF_PF0002B_FILLER_41 FILLER_41
            {
                get { _filler_41 = new _REDEF_PF0002B_FILLER_41(); _.Move(COBRAN_CC_INDICADOR, _filler_41); VarBasis.RedefinePassValue(COBRAN_CC_INDICADOR, _filler_41, COBRAN_CC_INDICADOR); _filler_41.ValueChanged += () => { _.Move(_filler_41, COBRAN_CC_INDICADOR); }; return _filler_41; }
                set { VarBasis.RedefinePassValue(value, _filler_41, COBRAN_CC_INDICADOR); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_41 : VarBasis
            {
                /*"    10    COBRAN-AGE-INDIC    PIC  9(004).*/
                public IntBasis COBRAN_AGE_INDIC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    COBRAN-OPER-INDIC   PIC  9(003).*/
                public IntBasis COBRAN_OPER_INDIC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    COBRAN-CC-INDIC     PIC  9(008).*/
                public IntBasis COBRAN_CC_INDIC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10    COBRAN-DIG-INDIC    PIC  9(001).*/
                public IntBasis COBRAN_DIG_INDIC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    COBRAN-MATR-INDIC   PIC  9(007).*/
                public IntBasis COBRAN_MATR_INDIC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05      FILLER              PIC  X(011).*/

                public _REDEF_PF0002B_FILLER_41()
                {
                    COBRAN_AGE_INDIC.ValueChanged += OnValueChanged;
                    COBRAN_OPER_INDIC.ValueChanged += OnValueChanged;
                    COBRAN_CC_INDIC.ValueChanged += OnValueChanged;
                    COBRAN_DIG_INDIC.ValueChanged += OnValueChanged;
                    COBRAN_MATR_INDIC.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
            /*"  05      COBRAN-CONCILIA     PIC  9(016).*/
            public IntBasis COBRAN_CONCILIA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              PIC  X(014).*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"  05      COBRAN-CODPRODU     PIC  9(004).*/
            public IntBasis COBRAN_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      COBRAN-CEDENTE      PIC  9(016).*/
            public IntBasis COBRAN_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      COBRAN-TIPO         PIC  9(001).*/
            public IntBasis COBRAN_TIPO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-CANAL        PIC  9(001).*/
            public IntBasis COBRAN_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER              PIC  X(009).*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05      COBRAN-NRSEQ        PIC  9(006).*/
            public IntBasis COBRAN_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public PF0002B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new PF0002B_TRAILL_REGISTRO();
        public class PF0002B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTR   PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-COD-RETORNO  PIC  9(001).*/
            public IntBasis TRAILL_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      TRAILL-COD-SERVICO  PIC  9(002).*/
            public IntBasis TRAILL_COD_SERVICO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      TRAILL-COD-BANCO    PIC  9(003).*/
            public IntBasis TRAILL_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      FILLER              PIC  X(360).*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "360", "X(360)."), @"");
            /*"  05      TRAILL-CEDENTE      PIC  9(016).*/
            public IntBasis TRAILL_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      TRAILL-TIPO         PIC  9(001).*/
            public IntBasis TRAILL_TIPO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      TRAILL-CANAL        PIC  9(001).*/
            public IntBasis TRAILL_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER              PIC  X(009).*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05      TRAILL-NRSEQ        PIC  9(006).*/
            public IntBasis TRAILL_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01             WS-TIT-AUTO.*/
        }
        public PF0002B_WS_TIT_AUTO WS_TIT_AUTO { get; set; } = new PF0002B_WS_TIT_AUTO();
        public class PF0002B_WS_TIT_AUTO : VarBasis
        {
            /*"  03           WS-TIT-AUTO-16     PIC  9(016).*/
            public IntBasis WS_TIT_AUTO_16 { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  03           FILLER             REDEFINES   WS-TIT-AUTO-16.*/
            private _REDEF_PF0002B_FILLER_47 _filler_47 { get; set; }
            public _REDEF_PF0002B_FILLER_47 FILLER_47
            {
                get { _filler_47 = new _REDEF_PF0002B_FILLER_47(); _.Move(WS_TIT_AUTO_16, _filler_47); VarBasis.RedefinePassValue(WS_TIT_AUTO_16, _filler_47, WS_TIT_AUTO_16); _filler_47.ValueChanged += () => { _.Move(_filler_47, WS_TIT_AUTO_16); }; return _filler_47; }
                set { VarBasis.RedefinePassValue(value, _filler_47, WS_TIT_AUTO_16); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_47 : VarBasis
            {
                /*"    05         WS-1-POS           PIC  9(001).*/
                public IntBasis WS_1_POS { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         WS-CANAL-AUTO      PIC  9(001).*/
                public IntBasis WS_CANAL_AUTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         WS-AGE-COB-AUTO    PIC  9(004).*/
                public IntBasis WS_AGE_COB_AUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05         WS-PROD-AUTO       PIC  9(002).*/
                public IntBasis WS_PROD_AUTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05         RESTO-TIT-AUTO     PIC  X(008).*/
                public StringBasis RESTO_TIT_AUTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01             LPARM11X.*/

                public _REDEF_PF0002B_FILLER_47()
                {
                    WS_1_POS.ValueChanged += OnValueChanged;
                    WS_CANAL_AUTO.ValueChanged += OnValueChanged;
                    WS_AGE_COB_AUTO.ValueChanged += OnValueChanged;
                    WS_PROD_AUTO.ValueChanged += OnValueChanged;
                    RESTO_TIT_AUTO.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0002B_LPARM11X LPARM11X { get; set; } = new PF0002B_LPARM11X();
        public class PF0002B_LPARM11X : VarBasis
        {
            /*"  03           LPARM11            PIC  9(010).*/
            public IntBasis LPARM11 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03           FILLER             REDEFINES   LPARM11.*/
            private _REDEF_PF0002B_FILLER_48 _filler_48 { get; set; }
            public _REDEF_PF0002B_FILLER_48 FILLER_48
            {
                get { _filler_48 = new _REDEF_PF0002B_FILLER_48(); _.Move(LPARM11, _filler_48); VarBasis.RedefinePassValue(LPARM11, _filler_48, LPARM11); _filler_48.ValueChanged += () => { _.Move(_filler_48, LPARM11); }; return _filler_48; }
                set { VarBasis.RedefinePassValue(value, _filler_48, LPARM11); }
            }  //Redefines
            public class _REDEF_PF0002B_FILLER_48 : VarBasis
            {
                /*"    05         LPARM11-1          PIC  9(001).*/
                public IntBasis LPARM11_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-2          PIC  9(001).*/
                public IntBasis LPARM11_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-3          PIC  9(001).*/
                public IntBasis LPARM11_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-4          PIC  9(001).*/
                public IntBasis LPARM11_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-5          PIC  9(001).*/
                public IntBasis LPARM11_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-6          PIC  9(001).*/
                public IntBasis LPARM11_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-7          PIC  9(001).*/
                public IntBasis LPARM11_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-8          PIC  9(001).*/
                public IntBasis LPARM11_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-9          PIC  9(001).*/
                public IntBasis LPARM11_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-10         PIC  9(001).*/
                public IntBasis LPARM11_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01  WS-AGENCIACEF.*/

                public _REDEF_PF0002B_FILLER_48()
                {
                    LPARM11_1.ValueChanged += OnValueChanged;
                    LPARM11_2.ValueChanged += OnValueChanged;
                    LPARM11_3.ValueChanged += OnValueChanged;
                    LPARM11_4.ValueChanged += OnValueChanged;
                    LPARM11_5.ValueChanged += OnValueChanged;
                    LPARM11_6.ValueChanged += OnValueChanged;
                    LPARM11_7.ValueChanged += OnValueChanged;
                    LPARM11_8.ValueChanged += OnValueChanged;
                    LPARM11_9.ValueChanged += OnValueChanged;
                    LPARM11_10.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0002B_WS_AGENCIACEF WS_AGENCIACEF { get; set; } = new PF0002B_WS_AGENCIACEF();
        public class PF0002B_WS_AGENCIACEF : VarBasis
        {
            /*"  03          WACEF-AGENCIAS.*/
            public PF0002B_WACEF_AGENCIAS WACEF_AGENCIAS { get; set; } = new PF0002B_WACEF_AGENCIAS();
            public class PF0002B_WACEF_AGENCIAS : VarBasis
            {
                /*"    05        WACEF-OCORREAGE     OCCURS       6000  TIMES                                  INDEXED      BY    WS-AGE.*/
                public ListBasis<PF0002B_WACEF_OCORREAGE> WACEF_OCORREAGE { get; set; } = new ListBasis<PF0002B_WACEF_OCORREAGE>(6000);
                public class PF0002B_WACEF_OCORREAGE : VarBasis
                {
                    /*"    10        WACEF-AGENCIA       PIC S9(004)        COMP.*/
                    public IntBasis WACEF_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"    10        WACEF-ESCNEG        PIC S9(004)        COMP.*/
                    public IntBasis WACEF_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"    10        WACEF-FONTE         PIC S9(004)        COMP.*/
                    public IntBasis WACEF_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"01  WS-PRODUTOSIVPF.*/
                }
            }
            public PF0002B_WS_PRODUTOSIVPF WS_PRODUTOSIVPF { get; set; } = new PF0002B_WS_PRODUTOSIVPF();
            public class PF0002B_WS_PRODUTOSIVPF : VarBasis
            {
                /*"  03          WPROD-PRODUTOS.*/
                public PF0002B_WPROD_PRODUTOS WPROD_PRODUTOS { get; set; } = new PF0002B_WPROD_PRODUTOS();
                public class PF0002B_WPROD_PRODUTOS : VarBasis
                {
                    /*"    05        WPROD-OCORREPRD     OCCURS       100   TIMES                                  INDEXED      BY    WS-PRD.*/
                    public ListBasis<PF0002B_WPROD_OCORREPRD> WPROD_OCORREPRD { get; set; } = new ListBasis<PF0002B_WPROD_OCORREPRD>(100);
                    public class PF0002B_WPROD_OCORREPRD : VarBasis
                    {
                        /*"    10        WPROD-PRDSIVPF      PIC S9(004)        COMP.*/
                        public IntBasis WPROD_PRDSIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                        /*"    10        WPROD-CODPRODU      PIC S9(004)        COMP.*/
                        public IntBasis WPROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                        /*"01  AUX-TABELAS.*/
                    }
                }
                public PF0002B_AUX_TABELAS AUX_TABELAS { get; set; } = new PF0002B_AUX_TABELAS();
                public class PF0002B_AUX_TABELAS : VarBasis
                {
                    /*"  03          WTABG-VALORES.*/
                    public PF0002B_WTABG_VALORES WTABG_VALORES { get; set; } = new PF0002B_WTABG_VALORES();
                    public class PF0002B_WTABG_VALORES : VarBasis
                    {
                        /*"    05        WTABG-OCORREPRD     OCCURS       2000  TIMES                                  INDEXED      BY    WS-PRO.*/
                        public ListBasis<PF0002B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<PF0002B_WTABG_OCORREPRD>(2000);
                        public class PF0002B_WTABG_OCORREPRD : VarBasis
                        {
                            /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                            public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"      10      WTABG-OCORRETIP     OCCURS       005   TIMES                                  INDEXED      BY    WS-TIP.*/
                            public ListBasis<PF0002B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<PF0002B_WTABG_OCORRETIP>(005);
                            public class PF0002B_WTABG_OCORRETIP : VarBasis
                            {
                                /*"        15    WTABG-TIPO          PIC  X(001).*/
                                public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                                /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                                public ListBasis<PF0002B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<PF0002B_WTABG_OCORRESIT>(002);
                                public class PF0002B_WTABG_OCORRESIT : VarBasis
                                {
                                    /*"          20  WTABG-SITUACAO      PIC  X(001).*/
                                    public StringBasis WTABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                                    /*"          20  WTABG-QTDE          PIC S9(009)        COMP.*/
                                    public IntBasis WTABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                                    /*"          20  WTABG-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"          20  WTABG-VLTARIFA      PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"          20  WTABG-VLBALCAO      PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"          20  WTABG-VLIOCC        PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"          20  WTABG-VLDESCON      PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"01  WS-COBERTURAS.*/
                                }
                            }
                        }
                    }
                }
                public PF0002B_WS_COBERTURAS WS_COBERTURAS { get; set; } = new PF0002B_WS_COBERTURAS();
                public class PF0002B_WS_COBERTURAS : VarBasis
                {
                    /*"  03          WCOBE-COBERTUR.*/
                    public PF0002B_WCOBE_COBERTUR WCOBE_COBERTUR { get; set; } = new PF0002B_WCOBE_COBERTUR();
                    public class PF0002B_WCOBE_COBERTUR : VarBasis
                    {
                        /*"    05        WCOBE-OCORRECOB     OCCURS       100   TIMES                                  INDEXED      BY    WS-COB.*/
                        public ListBasis<PF0002B_WCOBE_OCORRECOB> WCOBE_OCORRECOB { get; set; } = new ListBasis<PF0002B_WCOBE_OCORRECOB>(100);
                        public class PF0002B_WCOBE_OCORRECOB : VarBasis
                        {
                            /*"      10      WCOBE-RAMOFR        PIC S9(004)        COMP.*/
                            public IntBasis WCOBE_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"      10      WCOBE-CODOPCAO      PIC S9(004)        COMP.*/
                            public IntBasis WCOBE_CODOPCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"      10      WCOBE-VLPRMTAR      PIC S9(010)V9(05)  COMP-3.*/
                            public DoubleBasis WCOBE_VLPRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
                            /*"      10      WCOBE-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WCOBE_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"      10      WCOBE-PCIOCC        PIC S9(003)V99     COMP-3.*/
                            public DoubleBasis WCOBE_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
                            /*"01  WS-CEDENTES.*/
                        }
                    }
                }
                public PF0002B_WS_CEDENTES WS_CEDENTES { get; set; } = new PF0002B_WS_CEDENTES();
                public class PF0002B_WS_CEDENTES : VarBasis
                {
                    /*"  03          WCEDE-CCEDENTE.*/
                    public PF0002B_WCEDE_CCEDENTE WCEDE_CCEDENTE { get; set; } = new PF0002B_WCEDE_CCEDENTE();
                    public class PF0002B_WCEDE_CCEDENTE : VarBasis
                    {
                        /*"    05        WCEDE-OCORRECED     OCCURS       010   TIMES                                  INDEXED      BY    WS-CED.*/
                        public ListBasis<PF0002B_WCEDE_OCORRECED> WCEDE_OCORRECED { get; set; } = new ListBasis<PF0002B_WCEDE_OCORRECED>(010);
                        public class PF0002B_WCEDE_OCORRECED : VarBasis
                        {
                            /*"      10      WCEDE-CODEMPRESA    PIC  9(016).*/
                            public IntBasis WCEDE_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                        }
                    }
                }
            }
        }


        public Copies.LBWPF004 LBWPF004 { get; set; } = new Copies.LBWPF004();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PROPOSTA PROPOSTA { get; set; } = new Dclgens.PROPOSTA();
        public Dclgens.MR028 MR028 { get; set; } = new Dclgens.MR028();
        public Dclgens.PROPOAUT PROPOAUT { get; set; } = new Dclgens.PROPOAUT();
        public PF0002B_V0AGENCIAS V0AGENCIAS { get; set; } = new PF0002B_V0AGENCIAS();
        public PF0002B_V0PRDSIVPF V0PRDSIVPF { get; set; } = new PF0002B_V0PRDSIVPF();
        public PF0002B_V0PRODUTO V0PRODUTO { get; set; } = new PF0002B_V0PRODUTO();
        public PF0002B_V0BILCOBER V0BILCOBER { get; set; } = new PF0002B_V0BILCOBER();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string MOVIMENTO_COBRANCA_FILE_NAME_P, string PF0002B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                MOVIMENTO_COBRANCA.SetFile(MOVIMENTO_COBRANCA_FILE_NAME_P);
                PF0002B1.SetFile(PF0002B1_FILE_NAME_P);

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
            /*" -1341- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1342- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1344- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1346- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1349- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -1350- DISPLAY '*               PROGRAMA PF0002B               *' . */
            _.Display($"*               PROGRAMA PF0002B               *");

            /*" -1351- DISPLAY '*   CONSISTENCIA E CONTROLE DO MOV. COBRANCA   *' . */
            _.Display($"*   CONSISTENCIA E CONTROLE DO MOV. COBRANCA   *");

            /*" -1352- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -1362- DISPLAY '*  PF0002B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0002B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1363- DISPLAY '*' . */
            _.Display($"*");

            /*" -1364- DISPLAY 'VERSAO V.36 126077 26/11/2015 ' . */
            _.Display($"VERSAO V.36 126077 26/11/2015 ");

            /*" -1379- DISPLAY '*' . */
            _.Display($"*");

            /*" -1381- PERFORM R0050-00-INICIALIZA. */

            R0050_00_INICIALIZA_SECTION();

            /*" -1391- SORT ARQSORT ON ASCENDING KEY SOR-CEDENTE SOR-TIPO SOR-CANAL INPUT PROCEDURE R0300-00-INPUT-SORT THRU R0300-99-SAIDA OUTPUT PROCEDURE R1500-00-OUTPUT-SORT THRU R1500-99-SAIDA. */
            ARQSORT.Sort("SOR-CEDENTE,SOR-TIPO,SOR-CANAL", () => R0300_00_INPUT_SORT_SECTION(), () => R1500_00_OUTPUT_SORT_SECTION());

            /*" -1394- GO TO R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIALIZA-SECTION */
        private void R0050_00_INICIALIZA_SECTION()
        {
            /*" -1407- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1408- OPEN INPUT MOVIMENTO-COBRANCA */
            MOVIMENTO_COBRANCA.Open(REG_COBRANCA);

            /*" -1411- OUTPUT PF0002B1. */
            PF0002B1.Open(REG_PF0002B1);

            /*" -1413- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -1416- PERFORM R0105-00-SELECT-V0RELATORIOS. */

            R0105_00_SELECT_V0RELATORIOS_SECTION();

            /*" -1417- SET WS-AGE TO 1. */
            WS_AGE.Value = 1;

            /*" -1418- MOVE SPACES TO WFIM-AGENCIAS */
            _.Move("", WS_AUX_ARQUIVO.WFIM_AGENCIAS);

            /*" -1420- PERFORM R0110-00-DECLARE-V0AGENCIAS. */

            R0110_00_DECLARE_V0AGENCIAS_SECTION();

            /*" -1424- PERFORM R0120-00-FETCH-V0AGENCIAS UNTIL WFIM-AGENCIAS NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_AGENCIAS.IsEmpty()))
            {

                R0120_00_FETCH_V0AGENCIAS_SECTION();
            }

            /*" -1430- MOVE 9999 TO V0ACEF-AGENCIA V0ACEF-ESCNEG V0ACEF-FONTE. */
            _.Move(9999, V0ACEF_AGENCIA, V0ACEF_ESCNEG, V0ACEF_FONTE);

            /*" -1431- SET WS-SUBS TO WS-AGE */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_AGE;

            /*" -1436- PERFORM R0130-00-LIMPA-TABELA UNTIL WS-SUBS GREATER 6000. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 6000))
            {

                R0130_00_LIMPA_TABELA_SECTION();
            }

            /*" -1436- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1440- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -1441- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", WS_AUX_ARQUIVO.WFIM_PRODUTO);

            /*" -1443- PERFORM R0150-00-DECLARE-V0PRDSIVPF. */

            R0150_00_DECLARE_V0PRDSIVPF_SECTION();

            /*" -1447- PERFORM R0160-00-FETCH-V0PRDSIVPF UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_PRODUTO.IsEmpty()))
            {

                R0160_00_FETCH_V0PRDSIVPF_SECTION();
            }

            /*" -1452- MOVE 9999 TO V0PRPF-CODSIVPF V0PRPF-CODPRODU. */
            _.Move(9999, V0PRPF_CODSIVPF, V0PRPF_CODPRODU);

            /*" -1453- SET WS-SUBS TO WS-PRD */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRD;

            /*" -1457- PERFORM R0170-00-LIMPA-TABELA UNTIL WS-SUBS GREATER 100. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 100))
            {

                R0170_00_LIMPA_TABELA_SECTION();
            }

            /*" -1458- SET WS-CED TO 1 */
            WS_CED.Value = 1;

            /*" -1461- PERFORM R0180-00-ZERA-CEDENTE 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R0180_00_ZERA_CEDENTE_SECTION();

            }

            /*" -1461- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1470- SET WS-PRO TO 1. */
            WS_PRO.Value = 1;

            /*" -1473- MOVE ZEROS TO V0PROD-CODPRODU. */
            _.Move(0, V0PROD_CODPRODU);

            /*" -1476- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

            /*" -1477- MOVE 1 TO LD-PRODUTO */
            _.Move(1, WS_AUX_ARQUIVO.LD_PRODUTO);

            /*" -1478- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", WS_AUX_ARQUIVO.WFIM_PRODUTO);

            /*" -1480- PERFORM R0200-00-DECLARE-V0PRODUTO. */

            R0200_00_DECLARE_V0PRODUTO_SECTION();

            /*" -1484- PERFORM R0210-00-FETCH-V0PRODUTO UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_PRODUTO.IsEmpty()))
            {

                R0210_00_FETCH_V0PRODUTO_SECTION();
            }

            /*" -1488- MOVE 9999 TO V0PROD-CODPRODU. */
            _.Move(9999, V0PROD_CODPRODU);

            /*" -1493- PERFORM R0220-00-MOVE-DADOS UNTIL WS-SUBS GREATER 2000. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 2000))
            {

                R0220_00_MOVE_DADOS_SECTION();
            }

            /*" -1493- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1502- SET WS-COB TO 1. */
            WS_COB.Value = 1;

            /*" -1503- MOVE SPACES TO WFIM-BILCOBER */
            _.Move("", WS_AUX_ARQUIVO.WFIM_BILCOBER);

            /*" -1505- PERFORM R0265-00-DECLARE-V0BILCOBER. */

            R0265_00_DECLARE_V0BILCOBER_SECTION();

            /*" -1509- PERFORM R0270-00-FETCH-V0BILCOBER UNTIL WFIM-BILCOBER NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_BILCOBER.IsEmpty()))
            {

                R0270_00_FETCH_V0BILCOBER_SECTION();
            }

            /*" -1517- MOVE ZEROS TO V0BCOB-RAMOFR V0BCOB-CODOPCAO V0BCOB-VLPRMTAR V0BCOB-VLPRMTOT V0BCOB-PCIOCC. */
            _.Move(0, V0BCOB_RAMOFR, V0BCOB_CODOPCAO, V0BCOB_VLPRMTAR, V0BCOB_VLPRMTOT, V0BCOB_PCIOCC);

            /*" -1518- SET WS-SUBS TO WS-COB */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_COB;

            /*" -1521- PERFORM R0280-00-LIMPA-TABELA UNTIL WS-SUBS GREATER 100. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 100))
            {

                R0280_00_LIMPA_TABELA_SECTION();
            }

            /*" -1525- MOVE ZEROS TO AC-HEADER AC-TRAILL. */
            _.Move(0, WS_AUX_ARQUIVO.AC_HEADER, WS_AUX_ARQUIVO.AC_TRAILL);

            /*" -1525- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1532- PERFORM R0290-00-SELECT-V0CEDENTE. */

            R0290_00_SELECT_V0CEDENTE_SECTION();

            /*" -1533- IF V0SIST-DTMOVABE EQUAL '2005-11-04' */

            if (V0SIST_DTMOVABE == "2005-11-04")
            {

                /*" -1533- PERFORM R7600-00-UPDATE-V0MOVICOB. */

                R7600_00_UPDATE_V0MOVICOB_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -1546- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1552- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -1555- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1556- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)");

                /*" -1556- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -1552- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0105-00-SELECT-V0RELATORIOS-SECTION */
        private void R0105_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -1569- MOVE '0105' TO WNR-EXEC-SQL. */
            _.Move("0105", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1576- PERFORM R0105_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0105_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -1580- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1581- DISPLAY 'R0105-00 - PROBLEMAS NO SELECT(RELATORIOS)' */
                _.Display($"R0105-00 - PROBLEMAS NO SELECT(RELATORIOS)");

                /*" -1581- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0105-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0105_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -1576- EXEC SQL SELECT DATA_REFERENCIA INTO :RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'CB' AND COD_RELATORIO = 'CB7300B1' WITH UR END-EXEC. */

            var r0105_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0105_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0105_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0105_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0105_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-DECLARE-V0AGENCIAS-SECTION */
        private void R0110_00_DECLARE_V0AGENCIAS_SECTION()
        {
            /*" -1594- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1607- PERFORM R0110_00_DECLARE_V0AGENCIAS_DB_DECLARE_1 */

            R0110_00_DECLARE_V0AGENCIAS_DB_DECLARE_1();

            /*" -1609- PERFORM R0110_00_DECLARE_V0AGENCIAS_DB_OPEN_1 */

            R0110_00_DECLARE_V0AGENCIAS_DB_OPEN_1();

            /*" -1613- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1614- DISPLAY 'R0110-00 - PROBLEMAS DECLARE (V0AGENCIAS)' */
                _.Display($"R0110-00 - PROBLEMAS DECLARE (V0AGENCIAS)");

                /*" -1614- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0110-00-DECLARE-V0AGENCIAS-DB-DECLARE-1 */
        public void R0110_00_DECLARE_V0AGENCIAS_DB_DECLARE_1()
        {
            /*" -1607- EXEC SQL DECLARE V0AGENCIAS CURSOR FOR SELECT A.COD_AGENCIA , A.COD_ESCNEG , B.COD_FONTE FROM SEGUROS.V0AGENCIACEF A, SEGUROS.V0MALHACEF B WHERE A.COD_AGENCIA > 0 AND A.COD_SUREG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            V0AGENCIAS = new PF0002B_V0AGENCIAS(false);
            string GetQuery_V0AGENCIAS()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							A.COD_ESCNEG
							, 
							B.COD_FONTE 
							FROM SEGUROS.V0AGENCIACEF A
							, 
							SEGUROS.V0MALHACEF B 
							WHERE A.COD_AGENCIA > 0 
							AND A.COD_SUREG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            V0AGENCIAS.GetQueryEvent += GetQuery_V0AGENCIAS;

        }

        [StopWatch]
        /*" R0110-00-DECLARE-V0AGENCIAS-DB-OPEN-1 */
        public void R0110_00_DECLARE_V0AGENCIAS_DB_OPEN_1()
        {
            /*" -1609- EXEC SQL OPEN V0AGENCIAS END-EXEC. */

            V0AGENCIAS.Open();

        }

        [StopWatch]
        /*" R0150-00-DECLARE-V0PRDSIVPF-DB-DECLARE-1 */
        public void R0150_00_DECLARE_V0PRDSIVPF_DB_DECLARE_1()
        {
            /*" -1707- EXEC SQL DECLARE V0PRDSIVPF CURSOR FOR SELECT COD_PRODUTO_SIVPF, MAX(COD_PRODUTO) FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 GROUP BY COD_PRODUTO_SIVPF ORDER BY COD_PRODUTO_SIVPF WITH UR END-EXEC. */
            V0PRDSIVPF = new PF0002B_V0PRDSIVPF(false);
            string GetQuery_V0PRDSIVPF()
            {
                var query = @$"SELECT COD_PRODUTO_SIVPF
							, 
							MAX(COD_PRODUTO) 
							FROM SEGUROS.PRODUTOS_SIVPF 
							WHERE COD_EMPRESA_SIVPF = 1 
							GROUP BY COD_PRODUTO_SIVPF 
							ORDER BY COD_PRODUTO_SIVPF";

                return query;
            }
            V0PRDSIVPF.GetQueryEvent += GetQuery_V0PRDSIVPF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-FETCH-V0AGENCIAS-SECTION */
        private void R0120_00_FETCH_V0AGENCIAS_SECTION()
        {
            /*" -1627- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1631- PERFORM R0120_00_FETCH_V0AGENCIAS_DB_FETCH_1 */

            R0120_00_FETCH_V0AGENCIAS_DB_FETCH_1();

            /*" -1635- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1635- PERFORM R0120_00_FETCH_V0AGENCIAS_DB_CLOSE_1 */

                R0120_00_FETCH_V0AGENCIAS_DB_CLOSE_1();

                /*" -1637- MOVE 'S' TO WFIM-AGENCIAS */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_AGENCIAS);

                /*" -1639- GO TO R0120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1640- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1641- DISPLAY 'R0120-00 - PROBLEMAS FETCH (V0AGENCIAS)  ' */
                _.Display($"R0120-00 - PROBLEMAS FETCH (V0AGENCIAS)  ");

                /*" -1644- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1647- MOVE V0ACEF-AGENCIA TO WACEF-AGENCIA(WS-AGE). */
            _.Move(V0ACEF_AGENCIA, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA);

            /*" -1650- MOVE V0ACEF-ESCNEG TO WACEF-ESCNEG(WS-AGE). */
            _.Move(V0ACEF_ESCNEG, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG);

            /*" -1654- MOVE V0ACEF-FONTE TO WACEF-FONTE(WS-AGE). */
            _.Move(V0ACEF_FONTE, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE);

            /*" -1656- SET WS-AGE UP BY 1. */
            WS_AGE.Value += 1;

            /*" -1657- IF WS-AGE GREATER 6000 */

            if (WS_AGE > 6000)
            {

                /*" -1658- DISPLAY 'R0120-00 - ESTOUROU TABELA WACEF-AGENCIAS' */
                _.Display($"R0120-00 - ESTOUROU TABELA WACEF-AGENCIAS");

                /*" -1658- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-00-FETCH-V0AGENCIAS-DB-FETCH-1 */
        public void R0120_00_FETCH_V0AGENCIAS_DB_FETCH_1()
        {
            /*" -1631- EXEC SQL FETCH V0AGENCIAS INTO :V0ACEF-AGENCIA , :V0ACEF-ESCNEG , :V0ACEF-FONTE END-EXEC. */

            if (V0AGENCIAS.Fetch())
            {
                _.Move(V0AGENCIAS.V0ACEF_AGENCIA, V0ACEF_AGENCIA);
                _.Move(V0AGENCIAS.V0ACEF_ESCNEG, V0ACEF_ESCNEG);
                _.Move(V0AGENCIAS.V0ACEF_FONTE, V0ACEF_FONTE);
            }

        }

        [StopWatch]
        /*" R0120-00-FETCH-V0AGENCIAS-DB-CLOSE-1 */
        public void R0120_00_FETCH_V0AGENCIAS_DB_CLOSE_1()
        {
            /*" -1635- EXEC SQL CLOSE V0AGENCIAS END-EXEC */

            V0AGENCIAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-LIMPA-TABELA-SECTION */
        private void R0130_00_LIMPA_TABELA_SECTION()
        {
            /*" -1671- MOVE '0130' TO WNR-EXEC-SQL. */
            _.Move("0130", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1674- MOVE V0ACEF-AGENCIA TO WACEF-AGENCIA(WS-AGE). */
            _.Move(V0ACEF_AGENCIA, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA);

            /*" -1677- MOVE V0ACEF-ESCNEG TO WACEF-ESCNEG(WS-AGE). */
            _.Move(V0ACEF_ESCNEG, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG);

            /*" -1681- MOVE V0ACEF-FONTE TO WACEF-FONTE(WS-AGE). */
            _.Move(V0ACEF_FONTE, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE);

            /*" -1682- SET WS-AGE UP BY 1. */
            WS_AGE.Value += 1;

            /*" -1682- SET WS-SUBS TO WS-AGE. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_AGE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-DECLARE-V0PRDSIVPF-SECTION */
        private void R0150_00_DECLARE_V0PRDSIVPF_SECTION()
        {
            /*" -1695- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1707- PERFORM R0150_00_DECLARE_V0PRDSIVPF_DB_DECLARE_1 */

            R0150_00_DECLARE_V0PRDSIVPF_DB_DECLARE_1();

            /*" -1709- PERFORM R0150_00_DECLARE_V0PRDSIVPF_DB_OPEN_1 */

            R0150_00_DECLARE_V0PRDSIVPF_DB_OPEN_1();

            /*" -1713- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1714- DISPLAY 'R0150-00 - PROBLEMAS DECLARE (V0PRDSIVPF)' */
                _.Display($"R0150-00 - PROBLEMAS DECLARE (V0PRDSIVPF)");

                /*" -1714- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0150-00-DECLARE-V0PRDSIVPF-DB-OPEN-1 */
        public void R0150_00_DECLARE_V0PRDSIVPF_DB_OPEN_1()
        {
            /*" -1709- EXEC SQL OPEN V0PRDSIVPF END-EXEC. */

            V0PRDSIVPF.Open();

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1()
        {
            /*" -1811- EXEC SQL DECLARE V0PRODUTO CURSOR FOR SELECT CODPRODU FROM SEGUROS.V0PRODUTO WHERE COD_EMPRESA IN (0, 10, 11) ORDER BY CODPRODU WITH UR END-EXEC. */
            V0PRODUTO = new PF0002B_V0PRODUTO(false);
            string GetQuery_V0PRODUTO()
            {
                var query = @$"SELECT CODPRODU 
							FROM SEGUROS.V0PRODUTO 
							WHERE COD_EMPRESA IN (0
							, 10
							, 11) 
							ORDER BY CODPRODU";

                return query;
            }
            V0PRODUTO.GetQueryEvent += GetQuery_V0PRODUTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-FETCH-V0PRDSIVPF-SECTION */
        private void R0160_00_FETCH_V0PRDSIVPF_SECTION()
        {
            /*" -1727- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1730- PERFORM R0160_00_FETCH_V0PRDSIVPF_DB_FETCH_1 */

            R0160_00_FETCH_V0PRDSIVPF_DB_FETCH_1();

            /*" -1734- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1734- PERFORM R0160_00_FETCH_V0PRDSIVPF_DB_CLOSE_1 */

                R0160_00_FETCH_V0PRDSIVPF_DB_CLOSE_1();

                /*" -1736- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_PRODUTO);

                /*" -1738- GO TO R0160-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1739- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1740- DISPLAY 'R0160-00 - PROBLEMAS FETCH (V0PRDSIVPF)  ' */
                _.Display($"R0160-00 - PROBLEMAS FETCH (V0PRDSIVPF)  ");

                /*" -1743- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1746- MOVE V0PRPF-CODSIVPF TO WPROD-PRDSIVPF(WS-PRD). */
            _.Move(V0PRPF_CODSIVPF, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF);

            /*" -1750- MOVE V0PRPF-CODPRODU TO WPROD-CODPRODU(WS-PRD). */
            _.Move(V0PRPF_CODPRODU, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_CODPRODU);

            /*" -1750- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

        }

        [StopWatch]
        /*" R0160-00-FETCH-V0PRDSIVPF-DB-FETCH-1 */
        public void R0160_00_FETCH_V0PRDSIVPF_DB_FETCH_1()
        {
            /*" -1730- EXEC SQL FETCH V0PRDSIVPF INTO :V0PRPF-CODSIVPF , :V0PRPF-CODPRODU END-EXEC. */

            if (V0PRDSIVPF.Fetch())
            {
                _.Move(V0PRDSIVPF.V0PRPF_CODSIVPF, V0PRPF_CODSIVPF);
                _.Move(V0PRDSIVPF.V0PRPF_CODPRODU, V0PRPF_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0160-00-FETCH-V0PRDSIVPF-DB-CLOSE-1 */
        public void R0160_00_FETCH_V0PRDSIVPF_DB_CLOSE_1()
        {
            /*" -1734- EXEC SQL CLOSE V0PRDSIVPF END-EXEC */

            V0PRDSIVPF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0170-00-LIMPA-TABELA-SECTION */
        private void R0170_00_LIMPA_TABELA_SECTION()
        {
            /*" -1763- MOVE '0170' TO WNR-EXEC-SQL. */
            _.Move("0170", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1766- MOVE V0PRPF-CODSIVPF TO WPROD-PRDSIVPF(WS-PRD). */
            _.Move(V0PRPF_CODSIVPF, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF);

            /*" -1770- MOVE V0PRPF-CODPRODU TO WPROD-CODPRODU(WS-PRD). */
            _.Move(V0PRPF_CODPRODU, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_CODPRODU);

            /*" -1771- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

            /*" -1771- SET WS-SUBS TO WS-PRD. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0180-00-ZERA-CEDENTE-SECTION */
        private void R0180_00_ZERA_CEDENTE_SECTION()
        {
            /*" -1784- MOVE '0180' TO WNR-EXEC-SQL. */
            _.Move("0180", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1788- MOVE ZEROS TO WCEDE-CODEMPRESA(WS-CED). */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA);

            /*" -1788- SET WS-CED UP BY 1. */
            WS_CED.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-SECTION */
        private void R0200_00_DECLARE_V0PRODUTO_SECTION()
        {
            /*" -1801- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1811- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1();

            /*" -1813- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1();

            /*" -1817- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1818- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ");

                /*" -1818- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1()
        {
            /*" -1813- EXEC SQL OPEN V0PRODUTO END-EXEC. */

            V0PRODUTO.Open();

        }

        [StopWatch]
        /*" R0265-00-DECLARE-V0BILCOBER-DB-DECLARE-1 */
        public void R0265_00_DECLARE_V0BILCOBER_DB_DECLARE_1()
        {
            /*" -1998- EXEC SQL DECLARE V0BILCOBER CURSOR FOR SELECT RAMOFR , COD_OPCAO , PRM_TARIFARIO_IX , VLPRMTOT , PCIOCC FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR IN (14,72,82) AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' AND DTTERVIG = '9999-12-31' ORDER BY RAMOFR, COD_OPCAO WITH UR END-EXEC. */
            V0BILCOBER = new PF0002B_V0BILCOBER(false);
            string GetQuery_V0BILCOBER()
            {
                var query = @$"SELECT RAMOFR
							, 
							COD_OPCAO
							, 
							PRM_TARIFARIO_IX
							, 
							VLPRMTOT
							, 
							PCIOCC 
							FROM SEGUROS.V0BILHETE_COBER 
							WHERE RAMOFR IN (14
							,72
							,82) 
							AND PCCOMCOR > 0 
							AND IDE_COBERTURA = '1' 
							AND DTTERVIG = '9999-12-31' 
							ORDER BY RAMOFR
							, COD_OPCAO";

                return query;
            }
            V0BILCOBER.GetQueryEvent += GetQuery_V0BILCOBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-SECTION */
        private void R0210_00_FETCH_V0PRODUTO_SECTION()
        {
            /*" -1831- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1833- PERFORM R0210_00_FETCH_V0PRODUTO_DB_FETCH_1 */

            R0210_00_FETCH_V0PRODUTO_DB_FETCH_1();

            /*" -1837- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1837- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1();

                /*" -1839- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_PRODUTO);

                /*" -1841- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1842- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1843- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ");

                /*" -1846- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1849- ADD 1 TO LD-PRODUTO. */
            WS_AUX_ARQUIVO.LD_PRODUTO.Value = WS_AUX_ARQUIVO.LD_PRODUTO + 1;

            /*" -1850- IF LD-PRODUTO GREATER 2000 */

            if (WS_AUX_ARQUIVO.LD_PRODUTO > 2000)
            {

                /*" -1850- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2();

                /*" -1852- DISPLAY 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"R0210-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -1855- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1855- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-FETCH-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_FETCH_1()
        {
            /*" -1833- EXEC SQL FETCH V0PRODUTO INTO :V0PROD-CODPRODU END-EXEC. */

            if (V0PRODUTO.Fetch())
            {
                _.Move(V0PRODUTO.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1()
        {
            /*" -1837- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-2 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2()
        {
            /*" -1850- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }

        [StopWatch]
        /*" R0220-00-MOVE-DADOS-SECTION */
        private void R0220_00_MOVE_DADOS_SECTION()
        {
            /*" -1868- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1872- MOVE V0PROD-CODPRODU TO WTABG-CODPRODU(WS-PRO). */
            _.Move(V0PROD_CODPRODU, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU);

            /*" -1873- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -1876- PERFORM R0250-00-MOVE-TIPO 05 TIMES. */

            for (int i = 0; i < 5; i++)
            {

                R0250_00_MOVE_TIPO_SECTION();

            }

            /*" -1877- SET WS-PRO UP BY 1. */
            WS_PRO.Value += 1;

            /*" -1877- SET WS-SUBS TO WS-PRO. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-MOVE-TIPO-SECTION */
        private void R0250_00_MOVE_TIPO_SECTION()
        {
            /*" -1890- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1895- SET WS-SUBS1 TO WS-TIP. */
            WS_AUX_ARQUIVO.WS_SUBS1.Value = WS_TIP;

            /*" -1896- IF WS-SUBS1 EQUAL 1 */

            if (WS_AUX_ARQUIVO.WS_SUBS1 == 1)
            {

                /*" -1898- MOVE 'A' TO WTABG-TIPO(WS-PRO WS-TIP) */
                _.Move("A", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                /*" -1902- ELSE */
            }
            else
            {


                /*" -1903- IF WS-SUBS1 EQUAL 2 */

                if (WS_AUX_ARQUIVO.WS_SUBS1 == 2)
                {

                    /*" -1905- MOVE 'G' TO WTABG-TIPO(WS-PRO WS-TIP) */
                    _.Move("G", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -1909- ELSE */
                }
                else
                {


                    /*" -1910- IF WS-SUBS1 EQUAL 3 */

                    if (WS_AUX_ARQUIVO.WS_SUBS1 == 3)
                    {

                        /*" -1912- MOVE '2' TO WTABG-TIPO(WS-PRO WS-TIP) */
                        _.Move("2", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                        /*" -1913- ELSE */
                    }
                    else
                    {


                        /*" -1917- IF WS-SUBS1 EQUAL 4 */

                        if (WS_AUX_ARQUIVO.WS_SUBS1 == 4)
                        {

                            /*" -1919- MOVE 'D' TO WTABG-TIPO(WS-PRO WS-TIP) */
                            _.Move("D", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                            /*" -1923- ELSE */
                        }
                        else
                        {


                            /*" -1927- MOVE 'M' TO WTABG-TIPO(WS-PRO WS-TIP). */
                            _.Move("M", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);
                        }

                    }

                }

            }


            /*" -1928- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -1931- PERFORM R0260-00-MOVE-SITUACAO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R0260_00_MOVE_SITUACAO_SECTION();

            }

            /*" -1931- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-MOVE-SITUACAO-SECTION */
        private void R0260_00_MOVE_SITUACAO_SECTION()
        {
            /*" -1944- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1953- MOVE ZEROS TO WTABG-QTDE(WS-PRO WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRO WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRO WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRO WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRO WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRO WS-TIP WS-SIT). */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -1958- SET WS-SUBS2 TO WS-SIT. */
            WS_AUX_ARQUIVO.WS_SUBS2.Value = WS_SIT;

            /*" -1959- IF WS-SUBS2 EQUAL 1 */

            if (WS_AUX_ARQUIVO.WS_SUBS2 == 1)
            {

                /*" -1961- MOVE '0' TO WTABG-SITUACAO(WS-PRO WS-TIP WS-SIT) */
                _.Move("0", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -1965- ELSE */
            }
            else
            {


                /*" -1969- MOVE '2' TO WTABG-SITUACAO(WS-PRO WS-TIP WS-SIT). */
                _.Move("2", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);
            }


            /*" -1969- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0265-00-DECLARE-V0BILCOBER-SECTION */
        private void R0265_00_DECLARE_V0BILCOBER_SECTION()
        {
            /*" -1982- MOVE '0265' TO WNR-EXEC-SQL. */
            _.Move("0265", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1998- PERFORM R0265_00_DECLARE_V0BILCOBER_DB_DECLARE_1 */

            R0265_00_DECLARE_V0BILCOBER_DB_DECLARE_1();

            /*" -2000- PERFORM R0265_00_DECLARE_V0BILCOBER_DB_OPEN_1 */

            R0265_00_DECLARE_V0BILCOBER_DB_OPEN_1();

            /*" -2004- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2005- DISPLAY 'R0265-00 - PROBLEMAS DECLARE (V0BILCOBER)' */
                _.Display($"R0265-00 - PROBLEMAS DECLARE (V0BILCOBER)");

                /*" -2005- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0265-00-DECLARE-V0BILCOBER-DB-OPEN-1 */
        public void R0265_00_DECLARE_V0BILCOBER_DB_OPEN_1()
        {
            /*" -2000- EXEC SQL OPEN V0BILCOBER END-EXEC. */

            V0BILCOBER.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0265_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-FETCH-V0BILCOBER-SECTION */
        private void R0270_00_FETCH_V0BILCOBER_SECTION()
        {
            /*" -2018- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2024- PERFORM R0270_00_FETCH_V0BILCOBER_DB_FETCH_1 */

            R0270_00_FETCH_V0BILCOBER_DB_FETCH_1();

            /*" -2028- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2028- PERFORM R0270_00_FETCH_V0BILCOBER_DB_CLOSE_1 */

                R0270_00_FETCH_V0BILCOBER_DB_CLOSE_1();

                /*" -2030- MOVE 'S' TO WFIM-BILCOBER */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_BILCOBER);

                /*" -2032- GO TO R0270-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2033- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2034- DISPLAY 'R0270-00 - PROBLEMAS FETCH (V0BILCOBER)  ' */
                _.Display($"R0270-00 - PROBLEMAS FETCH (V0BILCOBER)  ");

                /*" -2037- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2038- IF VIND-VLPRMTOT LESS ZEROS */

            if (VIND_VLPRMTOT < 00)
            {

                /*" -2040- MOVE ZEROS TO V0BCOB-VLPRMTOT. */
                _.Move(0, V0BCOB_VLPRMTOT);
            }


            /*" -2041- IF VIND-PCIOCC LESS ZEROS */

            if (VIND_PCIOCC < 00)
            {

                /*" -2044- MOVE ZEROS TO V0BCOB-PCIOCC. */
                _.Move(0, V0BCOB_PCIOCC);
            }


            /*" -2046- MOVE V0BCOB-RAMOFR TO WCOBE-RAMOFR(WS-COB). */
            _.Move(V0BCOB_RAMOFR, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_RAMOFR);

            /*" -2048- MOVE V0BCOB-CODOPCAO TO WCOBE-CODOPCAO(WS-COB). */
            _.Move(V0BCOB_CODOPCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_CODOPCAO);

            /*" -2050- MOVE V0BCOB-VLPRMTAR TO WCOBE-VLPRMTAR(WS-COB). */
            _.Move(V0BCOB_VLPRMTAR, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTAR);

            /*" -2052- MOVE V0BCOB-VLPRMTOT TO WCOBE-VLPRMTOT(WS-COB). */
            _.Move(V0BCOB_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTOT);

            /*" -2056- MOVE V0BCOB-PCIOCC TO WCOBE-PCIOCC(WS-COB). */
            _.Move(V0BCOB_PCIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_PCIOCC);

            /*" -2056- SET WS-COB UP BY 1. */
            WS_COB.Value += 1;

        }

        [StopWatch]
        /*" R0270-00-FETCH-V0BILCOBER-DB-FETCH-1 */
        public void R0270_00_FETCH_V0BILCOBER_DB_FETCH_1()
        {
            /*" -2024- EXEC SQL FETCH V0BILCOBER INTO :V0BCOB-RAMOFR , :V0BCOB-CODOPCAO , :V0BCOB-VLPRMTAR , :V0BCOB-VLPRMTOT:VIND-VLPRMTOT , :V0BCOB-PCIOCC:VIND-PCIOCC END-EXEC. */

            if (V0BILCOBER.Fetch())
            {
                _.Move(V0BILCOBER.V0BCOB_RAMOFR, V0BCOB_RAMOFR);
                _.Move(V0BILCOBER.V0BCOB_CODOPCAO, V0BCOB_CODOPCAO);
                _.Move(V0BILCOBER.V0BCOB_VLPRMTAR, V0BCOB_VLPRMTAR);
                _.Move(V0BILCOBER.V0BCOB_VLPRMTOT, V0BCOB_VLPRMTOT);
                _.Move(V0BILCOBER.VIND_VLPRMTOT, VIND_VLPRMTOT);
                _.Move(V0BILCOBER.V0BCOB_PCIOCC, V0BCOB_PCIOCC);
                _.Move(V0BILCOBER.VIND_PCIOCC, VIND_PCIOCC);
            }

        }

        [StopWatch]
        /*" R0270-00-FETCH-V0BILCOBER-DB-CLOSE-1 */
        public void R0270_00_FETCH_V0BILCOBER_DB_CLOSE_1()
        {
            /*" -2028- EXEC SQL CLOSE V0BILCOBER END-EXEC */

            V0BILCOBER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0280-00-LIMPA-TABELA-SECTION */
        private void R0280_00_LIMPA_TABELA_SECTION()
        {
            /*" -2069- MOVE '0280' TO WNR-EXEC-SQL. */
            _.Move("0280", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2071- MOVE V0BCOB-RAMOFR TO WCOBE-RAMOFR(WS-COB). */
            _.Move(V0BCOB_RAMOFR, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_RAMOFR);

            /*" -2073- MOVE V0BCOB-CODOPCAO TO WCOBE-CODOPCAO(WS-COB). */
            _.Move(V0BCOB_CODOPCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_CODOPCAO);

            /*" -2075- MOVE V0BCOB-VLPRMTAR TO WCOBE-VLPRMTAR(WS-COB). */
            _.Move(V0BCOB_VLPRMTAR, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTAR);

            /*" -2077- MOVE V0BCOB-VLPRMTOT TO WCOBE-VLPRMTOT(WS-COB). */
            _.Move(V0BCOB_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTOT);

            /*" -2081- MOVE V0BCOB-PCIOCC TO WCOBE-PCIOCC(WS-COB). */
            _.Move(V0BCOB_PCIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_PCIOCC);

            /*" -2082- SET WS-COB UP BY 1. */
            WS_COB.Value += 1;

            /*" -2082- SET WS-SUBS TO WS-COB. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_COB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/

        [StopWatch]
        /*" R0290-00-SELECT-V0CEDENTE-SECTION */
        private void R0290_00_SELECT_V0CEDENTE_SECTION()
        {
            /*" -2095- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2103- PERFORM R0290_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R0290_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -2107- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2108- DISPLAY 'R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)' */
                _.Display($"R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)");

                /*" -2111- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2112- MOVE V0CEDE-NUMTIT TO WWORK-MIN-NRTIT */
            _.Move(V0CEDE_NUMTIT, WS_AUX_ARQUIVO.WWORK_MIN_NRTIT);

            /*" -2118- MOVE V0CEDE-NUMTITMAX TO WWORK-MAX-NRTIT. */
            _.Move(V0CEDE_NUMTITMAX, WS_AUX_ARQUIVO.WWORK_MAX_NRTIT);

            /*" -2119- IF V0CEDE-NUMTIT LESS 95322401400 */

            if (V0CEDE_NUMTIT < 95322401400)
            {

                /*" -2120- DISPLAY 'R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)' */
                _.Display($"R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)");

                /*" -2121- DISPLAY '*- PF0002B - ABEND CONTROLADO -----------*' */
                _.Display($"*- PF0002B - ABEND CONTROLADO -----------*");

                /*" -2122- DISPLAY '*  FAIXA NUMERACAO INVALIDA CEDENTE = 26 *' */
                _.Display($"*  FAIXA NUMERACAO INVALIDA CEDENTE = 26 *");

                /*" -2123- DISPLAY ' TITULO ' V0CEDE-NUMTIT */
                _.Display($" TITULO {V0CEDE_NUMTIT}");

                /*" -2123- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0290-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R0290_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -2103- EXEC SQL SELECT NUMTIT , NUMTITMAX INTO :V0CEDE-NUMTIT , :V0CEDE-NUMTITMAX FROM SEGUROS.V0CEDENTE WHERE CODCDT = 26 WITH UR END-EXEC. */

            var r0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 = new R0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1.Execute(r0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CEDE_NUMTIT, V0CEDE_NUMTIT);
                _.Move(executed_1.V0CEDE_NUMTITMAX, V0CEDE_NUMTITMAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-INPUT-SORT-SECTION */
        private void R0300_00_INPUT_SORT_SECTION()
        {
            /*" -2136- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2137- MOVE SPACES TO WFIM-COBRANCA. */
            _.Move("", WS_AUX_ARQUIVO.WFIM_COBRANCA);

            /*" -2140- PERFORM R0310-00-LE-COBRANCA. */

            R0310_00_LE_COBRANCA_SECTION();

            /*" -2141- IF WFIM-COBRANCA NOT EQUAL SPACES */

            if (!WS_AUX_ARQUIVO.WFIM_COBRANCA.IsEmpty())
            {

                /*" -2142- DISPLAY '****** ARQUIVO VAZIO ******' */
                _.Display($"****** ARQUIVO VAZIO ******");

                /*" -2143- PERFORM R9800-00-ENCERRA-SEM-MOVTO */

                R9800_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -2146- GO TO R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -2147- IF ENT-CODREGISTR NOT EQUAL '0' */

            if (REG_COBRANCA.ENT_CODREGISTR != "0")
            {

                /*" -2148- DISPLAY '****** ARQUIVO SEM HEADER ******' */
                _.Display($"****** ARQUIVO SEM HEADER ******");

                /*" -2151- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2155- PERFORM R0350-00-GRAVA-SORT UNTIL WFIM-COBRANCA NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_COBRANCA.IsEmpty()))
            {

                R0350_00_GRAVA_SORT_SECTION();
            }

            /*" -2156- IF AC-HEADER NOT EQUAL AC-TRAILL */

            if (WS_AUX_ARQUIVO.AC_HEADER != WS_AUX_ARQUIVO.AC_TRAILL)
            {

                /*" -2157- DISPLAY '****** ARQUIVO SEM TRAILLER ******' */
                _.Display($"****** ARQUIVO SEM TRAILLER ******");

                /*" -2157- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-LE-COBRANCA-SECTION */
        private void R0310_00_LE_COBRANCA_SECTION()
        {
            /*" -2170- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2171- READ MOVIMENTO-COBRANCA AT END */
            try
            {
                MOVIMENTO_COBRANCA.Read(() =>
                {

                    /*" -2173- MOVE 'S' TO WFIM-COBRANCA */
                    _.Move("S", WS_AUX_ARQUIVO.WFIM_COBRANCA);

                    /*" -2175- GO TO R0310-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOVIMENTO_COBRANCA.Value, REG_COBRANCA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2182- ADD 1 TO LD-COBRANCA. */
            WS_AUX_ARQUIVO.LD_COBRANCA.Value = WS_AUX_ARQUIVO.LD_COBRANCA + 1;

            /*" -2183- IF REG-COBRANCA EQUAL SPACES */

            if (REG_COBRANCA.IsEmpty())
            {

                /*" -2184- ADD 1 TO DP-COBRANCA */
                WS_AUX_ARQUIVO.DP_COBRANCA.Value = WS_AUX_ARQUIVO.DP_COBRANCA + 1;

                /*" -2184- GO TO R0310-00-LE-COBRANCA. */
                new Task(() => R0310_00_LE_COBRANCA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-GRAVA-SORT-SECTION */
        private void R0350_00_GRAVA_SORT_SECTION()
        {
            /*" -2196- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2197- IF ENT-CODREGISTR EQUAL '0' */

            if (REG_COBRANCA.ENT_CODREGISTR == "0")
            {

                /*" -2198- ADD 1 TO AC-HEADER */
                WS_AUX_ARQUIVO.AC_HEADER.Value = WS_AUX_ARQUIVO.AC_HEADER + 1;

                /*" -2199- MOVE REG-COBRANCA TO HEADER-REGISTRO */
                _.Move(MOVIMENTO_COBRANCA?.Value, HEADER_REGISTRO);

                /*" -2200- PERFORM R0360-00-TRATA-HEADER */

                R0360_00_TRATA_HEADER_SECTION();

                /*" -2201- GO TO R0350-90-LEITURA */

                R0350_90_LEITURA(); //GOTO
                return;

                /*" -2202- ELSE */
            }
            else
            {


                /*" -2203- IF ENT-CODREGISTR EQUAL '9' */

                if (REG_COBRANCA.ENT_CODREGISTR == "9")
                {

                    /*" -2204- ADD 1 TO AC-TRAILL */
                    WS_AUX_ARQUIVO.AC_TRAILL.Value = WS_AUX_ARQUIVO.AC_TRAILL + 1;

                    /*" -2205- MOVE REG-COBRANCA TO TRAILL-REGISTRO */
                    _.Move(MOVIMENTO_COBRANCA?.Value, TRAILL_REGISTRO);

                    /*" -2206- PERFORM R0370-00-TRATA-TRAILLER */

                    R0370_00_TRATA_TRAILLER_SECTION();

                    /*" -2207- GO TO R0350-90-LEITURA */

                    R0350_90_LEITURA(); //GOTO
                    return;

                    /*" -2208- ELSE */
                }
                else
                {


                    /*" -2209- IF ENT-CODREGISTR NOT EQUAL '1' */

                    if (REG_COBRANCA.ENT_CODREGISTR != "1")
                    {

                        /*" -2210- ADD 1 TO NP-COBRANCA */
                        WS_AUX_ARQUIVO.NP_COBRANCA.Value = WS_AUX_ARQUIVO.NP_COBRANCA + 1;

                        /*" -2211- GO TO R0350-90-LEITURA */

                        R0350_90_LEITURA(); //GOTO
                        return;

                        /*" -2212- ELSE */
                    }
                    else
                    {


                        /*" -2215- MOVE REG-COBRANCA TO COBRAN-REGISTRO. */
                        _.Move(MOVIMENTO_COBRANCA?.Value, COBRAN_REGISTRO);
                    }

                }

            }


            /*" -2217- ADD 1 TO DE-COBRANCA. */
            WS_AUX_ARQUIVO.DE_COBRANCA.Value = WS_AUX_ARQUIVO.DE_COBRANCA + 1;

            /*" -2242- IF COBRAN-CODEMPRESA NOT EQUAL 630870000000113 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000130 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000318 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000342 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000326 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000334 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000440 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000601 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000610 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000628 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000725 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000750 AND COBRAN-CODEMPRESA NOT EQUAL 630870000001004 AND COBRAN-CODEMPRESA NOT EQUAL 630870000001136 AND COBRAN-CODEMPRESA NOT EQUAL 630870000001144 AND COBRAN-CODEMPRESA NOT EQUAL 630870000001306 AND COBRAN-CODEMPRESA NOT EQUAL 630870000002337 AND COBRAN-CODEMPRESA NOT EQUAL 630870000002825 AND COBRAN-CODEMPRESA NOT EQUAL 630870000002876 AND COBRAN-CODEMPRESA NOT EQUAL 630870000002884 AND COBRAN-CODEMPRESA NOT EQUAL 630870000003198 AND COBRAN-CODEMPRESA NOT EQUAL 630870000003201 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000113 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000130 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000318 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000342 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000326 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000334 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000440 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000601 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000610 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000628 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000725 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000750 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000001004 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000001136 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000001144 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000001306 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000002337 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000002825 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000002876 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000002884 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000003198 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000003201)
            {

                /*" -2243- ADD 1 TO DP-COBRANCA */
                WS_AUX_ARQUIVO.DP_COBRANCA.Value = WS_AUX_ARQUIVO.DP_COBRANCA + 1;

                /*" -2258- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -2259- IF COBRAN-CONCILIA NOT EQUAL ZEROS */

            if (COBRAN_REGISTRO.COBRAN_CONCILIA != 00)
            {

                /*" -2260- ADD 1 TO DP-CREDITO */
                WS_AUX_ARQUIVO.DP_CREDITO.Value = WS_AUX_ARQUIVO.DP_CREDITO + 1;

                /*" -2266- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -2268- IF COBRAN-CONSISTE1 NOT EQUAL SPACES OR COBRAN-CONSISTE2 NOT EQUAL SPACES */

            if (!COBRAN_REGISTRO.COBRAN_CONSISTE1.IsEmpty() || !COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_CONSISTE2.IsEmpty())
            {

                /*" -2269- DISPLAY 'TITULO FORA DA POSICAO ' LD-COBRANCA */
                _.Display($"TITULO FORA DA POSICAO {WS_AUX_ARQUIVO.LD_COBRANCA}");

                /*" -2272- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2273- IF COBRAN-MATR-INDIC NOT NUMERIC */

            if (!COBRAN_REGISTRO.FILLER_41.COBRAN_MATR_INDIC.IsNumeric())
            {

                /*" -2275- MOVE ZEROS TO COBRAN-MATR-INDIC. */
                _.Move(0, COBRAN_REGISTRO.FILLER_41.COBRAN_MATR_INDIC);
            }


            /*" -2276- IF COBRAN-TITULO16 NOT NUMERIC */

            if (!COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16.IsNumeric())
            {

                /*" -2279- MOVE ZEROS TO COBRAN-TITULO16. */
                _.Move(0, COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16);
            }


            /*" -2288- IF COBRAN-CODEMPRESA EQUAL 630870000000334 OR 630870000000440 OR 630870000000610 OR 630870000000628 OR 630870000000725 OR 630870000001144 OR 630870000002825 OR 630870000003201 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA.In("630870000000334", "630870000000440", "630870000000610", "630870000000628", "630870000000725", "630870000001144", "630870000002825", "630870000003201"))
            {

                /*" -2291- MOVE ZEROS TO COBRAN-ABATIMENTO. */
                _.Move(0, COBRAN_REGISTRO.COBRAN_ABATIMENTO);
            }


            /*" -2296- IF COBRAN-CODEMPRESA NOT EQUAL 630870000000440 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000628 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000725 AND COBRAN-CODEMPRESA NOT EQUAL 630870000002825 AND COBRAN-CODEMPRESA NOT EQUAL 630870000003201 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000440 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000628 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000725 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000002825 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000003201)
            {

                /*" -2297- IF COBRAN-TITULO16 EQUAL ZEROS */

                if (COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 == 00)
                {

                    /*" -2303- PERFORM R0400-00-TRATA-NRTIT-ZERO. */

                    R0400_00_TRATA_NRTIT_ZERO_SECTION();
                }

            }


            /*" -2304- IF COBRAN-CODEMPRESA EQUAL 630870000001144 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000001144)
            {

                /*" -2305- IF COBRAN-TITULO16 NOT EQUAL ZEROS */

                if (COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 != 00)
                {

                    /*" -2308- PERFORM R0420-00-TRATA-NRTIT-MULT. */

                    R0420_00_TRATA_NRTIT_MULT_SECTION();
                }

            }


            /*" -2309- MOVE COBRAN-USO-EMPRESA TO AUX-USO-EMPRESA */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA);

            /*" -2312- MOVE AUX-TITSIVPF TO AUX-NRO-SIVPF AUX-TIT-GRAFICA. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, WS_AUX_ARQUIVO.AUX_NRO_SIVPF, WS_AUX_ARQUIVO.AUX_TIT_GRAFICA);

            /*" -2313- MOVE COBRAN-CODEMPRESA TO COBRAN-CEDENTE */
            _.Move(COBRAN_REGISTRO.COBRAN_CODEMPRESA, COBRAN_REGISTRO.COBRAN_CEDENTE);

            /*" -2314- MOVE COBRAN-CODREGISTR TO COBRAN-TIPO */
            _.Move(COBRAN_REGISTRO.COBRAN_CODREGISTR, COBRAN_REGISTRO.COBRAN_TIPO);

            /*" -2315- MOVE AUX-CANAL TO COBRAN-CANAL */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.AUX_CANAL, COBRAN_REGISTRO.COBRAN_CANAL);

            /*" -2322- MOVE ZEROS TO COBRAN-CODPRODU. */
            _.Move(0, COBRAN_REGISTRO.COBRAN_CODPRODU);

            /*" -2327- IF COBRAN-CODEMPRESA NOT EQUAL 630870000000440 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000628 AND COBRAN-CODEMPRESA NOT EQUAL 630870000000725 AND COBRAN-CODEMPRESA NOT EQUAL 630870000002825 AND COBRAN-CODEMPRESA NOT EQUAL 630870000003201 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000440 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000628 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000000725 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000002825 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630870000003201)
            {

                /*" -2329- IF COBRAN-CANAL EQUAL ZEROS AND COBRAN-TITULO16 NOT EQUAL ZEROS */

                if (COBRAN_REGISTRO.COBRAN_CANAL == 00 && COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 != 00)
                {

                    /*" -2330- MOVE AUX-NUM-GRAFICA TO V0SFRC-NRTIT */
                    _.Move(WS_AUX_ARQUIVO.FILLER_6.AUX_NUM_GRAFICA, V0SFRC_NRTIT);

                    /*" -2333- PERFORM R0700-00-SELECT-SICOB-FAIXA. */

                    R0700_00_SELECT_SICOB_FAIXA_SECTION();
                }

            }


            /*" -2334- IF COBRAN-CODPRODU EQUAL 8201 */

            if (COBRAN_REGISTRO.COBRAN_CODPRODU == 8201)
            {

                /*" -2335- MOVE 8202 TO COBRAN-CODPRODU */
                _.Move(8202, COBRAN_REGISTRO.COBRAN_CODPRODU);

                /*" -2336- ELSE */
            }
            else
            {


                /*" -2338- IF COBRAN-CODPRODU EQUAL 7106 OR 7108 */

                if (COBRAN_REGISTRO.COBRAN_CODPRODU.In("7106", "7108"))
                {

                    /*" -2341- MOVE 1402 TO COBRAN-CODPRODU. */
                    _.Move(1402, COBRAN_REGISTRO.COBRAN_CODPRODU);
                }

            }


            /*" -2342- MOVE COBRAN-REGISTRO TO REG-ARQSORT */
            _.Move(COBRAN_REGISTRO, REG_ARQSORT);

            /*" -2348- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -2349- SET WS-CED TO 1 */
            WS_CED.Value = 1;

            /*" -2350- SEARCH WCEDE-OCORRECED */
            for (; WS_CED < WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED.Items.Count; WS_CED.Value++)
            {

                /*" -2354- WHEN (COBRAN-CODEMPRESA EQUAL WCEDE-CODEMPRESA(WS-CED) OR WCEDE-CODEMPRESA(WS-CED) EQUAL ZEROS) */

                if ((COBRAN_REGISTRO.COBRAN_CODEMPRESA == WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA || WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA == 00))
                {


                    /*" -2355- MOVE COBRAN-CODEMPRESA TO WCEDE-CODEMPRESA(WS-CED)  END-SEARCH. */
                    break;
                }
            }


            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -2360- PERFORM R0310-00-LE-COBRANCA. */

            R0310_00_LE_COBRANCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-TRATA-HEADER-SECTION */
        private void R0360_00_TRATA_HEADER_SECTION()
        {
            /*" -2371- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2374- MOVE SPACES TO WCHV-ERRO. */
            _.Move("", WS_AUX_ARQUIVO.WCHV_ERRO);

            /*" -2375- MOVE ZEROS TO DP-CREDITO. */
            _.Move(0, WS_AUX_ARQUIVO.DP_CREDITO);

            /*" -2378- DISPLAY ' CEDENTE  =  ' HEADER-CODEMPRESA. */
            _.Display($" CEDENTE  =  {HEADER_REGISTRO.HEADER_CODEMPRESA}");

            /*" -2379- IF HEADER-CODEMPRESA EQUAL 630003000009997 */

            if (HEADER_REGISTRO.HEADER_CODEMPRESA == 630003000009997)
            {

                /*" -2383- MOVE 630870000000725 TO HEADER-CODEMPRESA. */
                _.Move(630870000000725, HEADER_REGISTRO.HEADER_CODEMPRESA);
            }


            /*" -2405- IF HEADER-CODEMPRESA NOT EQUAL 630870000000113 AND HEADER-CODEMPRESA NOT EQUAL 630870000000130 AND HEADER-CODEMPRESA NOT EQUAL 630870000000318 AND HEADER-CODEMPRESA NOT EQUAL 630870000000342 AND HEADER-CODEMPRESA NOT EQUAL 630870000000326 AND HEADER-CODEMPRESA NOT EQUAL 630870000000334 AND HEADER-CODEMPRESA NOT EQUAL 630870000000440 AND HEADER-CODEMPRESA NOT EQUAL 630870000000601 AND HEADER-CODEMPRESA NOT EQUAL 630870000000610 AND HEADER-CODEMPRESA NOT EQUAL 630870000000628 AND HEADER-CODEMPRESA NOT EQUAL 630870000000725 AND HEADER-CODEMPRESA NOT EQUAL 630870000000750 AND HEADER-CODEMPRESA NOT EQUAL 630870000001004 AND HEADER-CODEMPRESA NOT EQUAL 630870000001136 AND HEADER-CODEMPRESA NOT EQUAL 630870000001144 AND HEADER-CODEMPRESA NOT EQUAL 630870000001306 AND HEADER-CODEMPRESA NOT EQUAL 630870000002337 AND HEADER-CODEMPRESA NOT EQUAL 630870000002825 AND HEADER-CODEMPRESA NOT EQUAL 630870000002876 AND HEADER-CODEMPRESA NOT EQUAL 630870000002884 AND HEADER-CODEMPRESA NOT EQUAL 630870000003198 AND HEADER-CODEMPRESA NOT EQUAL 630870000003201 */

            if (HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000113 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000130 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000318 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000342 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000326 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000334 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000440 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000601 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000610 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000628 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000725 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000000750 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000001004 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000001136 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000001144 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000001306 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000002337 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000002825 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000002876 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000002884 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000003198 && HEADER_REGISTRO.HEADER_CODEMPRESA != 630870000003201)
            {

                /*" -2406- DISPLAY 'CEDENTE NAO PREVISTO - VER ARQUIVO' */
                _.Display($"CEDENTE NAO PREVISTO - VER ARQUIVO");

                /*" -2409- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2410- IF HEADER-CODREGISTR NOT EQUAL '0' */

            if (HEADER_REGISTRO.HEADER_CODREGISTR != "0")
            {

                /*" -2411- DISPLAY 'TIPO DE REGISTRO INVALIDO PARA O HEADER ' */
                _.Display($"TIPO DE REGISTRO INVALIDO PARA O HEADER ");

                /*" -2413- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2414- IF HEADER-CODRETORNO NOT EQUAL '2' */

            if (HEADER_REGISTRO.HEADER_CODRETORNO != "2")
            {

                /*" -2415- DISPLAY 'CODIGO DA FITA INVALIDA PARA O HEADER ' */
                _.Display($"CODIGO DA FITA INVALIDA PARA O HEADER ");

                /*" -2417- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2418- IF HEADER-LITRETORNO NOT EQUAL 'RETORNO' */

            if (HEADER_REGISTRO.HEADER_LITRETORNO != "RETORNO")
            {

                /*" -2419- DISPLAY 'LITERAL DA FITA INVALIDO PARA O HEADER ' */
                _.Display($"LITERAL DA FITA INVALIDO PARA O HEADER ");

                /*" -2421- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2422- IF HEADER-CODSERVICO NOT EQUAL '01' */

            if (HEADER_REGISTRO.HEADER_CODSERVICO != "01")
            {

                /*" -2423- DISPLAY 'CODIGO DO SERVICO INVALIDO PARA O HEADER ' */
                _.Display($"CODIGO DO SERVICO INVALIDO PARA O HEADER ");

                /*" -2425- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2426- IF HEADER-LITSERVICO NOT EQUAL 'COBRANCA       ' */

            if (HEADER_REGISTRO.HEADER_LITSERVICO != "COBRANCA       ")
            {

                /*" -2427- DISPLAY 'LITERAL DO SERVICO INVALIDO PARA O HEADER ' */
                _.Display($"LITERAL DO SERVICO INVALIDO PARA O HEADER ");

                /*" -2429- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2430- IF HEADER-CODBANCO NOT EQUAL '104' */

            if (HEADER_REGISTRO.HEADER_CODBANCO != "104")
            {

                /*" -2431- DISPLAY 'CODIGO DO BANCO INVALIDO PARA O HEADER ' */
                _.Display($"CODIGO DO BANCO INVALIDO PARA O HEADER ");

                /*" -2433- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2434- IF HEADER-DATAGRAVAC NOT NUMERIC */

            if (!HEADER_REGISTRO.HEADER_DATAGRAVAC.IsNumeric())
            {

                /*" -2435- DISPLAY 'DATA DO AVISO   INVALIDO PARA O HEADER ' */
                _.Display($"DATA DO AVISO   INVALIDO PARA O HEADER ");

                /*" -2437- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2438- IF HEADER-CODEMPRESA NOT NUMERIC */

            if (!HEADER_REGISTRO.HEADER_CODEMPRESA.IsNumeric())
            {

                /*" -2439- DISPLAY 'CODIGO CEDENTE  INVALIDO PARA O HEADER ' */
                _.Display($"CODIGO CEDENTE  INVALIDO PARA O HEADER ");

                /*" -2442- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2443- IF WCHV-ERRO NOT EQUAL SPACES */

            if (!WS_AUX_ARQUIVO.WCHV_ERRO.IsEmpty())
            {

                /*" -2446- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2447- SET WS-CED TO 1 */
            WS_CED.Value = 1;

            /*" -2448- SEARCH WCEDE-OCORRECED */
            for (; WS_CED < WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED.Items.Count; WS_CED.Value++)
            {

                /*" -2452- WHEN (HEADER-CODEMPRESA EQUAL WCEDE-CODEMPRESA(WS-CED) OR WCEDE-CODEMPRESA(WS-CED) EQUAL ZEROS) */

                if ((HEADER_REGISTRO.HEADER_CODEMPRESA == WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA || WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA == 00))
                {


                    /*" -2453- MOVE HEADER-CODEMPRESA TO WCEDE-CODEMPRESA(WS-CED)  END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-TRATA-TRAILLER-SECTION */
        private void R0370_00_TRATA_TRAILLER_SECTION()
        {
            /*" -2466- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2467- SET WS-CED TO 1 */
            WS_CED.Value = 1;

            /*" -2470- PERFORM R0380-00-GRAVA-HEADTRAI 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R0380_00_GRAVA_HEADTRAI_SECTION();

            }

            /*" -2470- DISPLAY ' CREDITOS SIGPF FINANCEIRO = ' DP-CREDITO. */
            _.Display($" CREDITOS SIGPF FINANCEIRO = {WS_AUX_ARQUIVO.DP_CREDITO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0380-00-GRAVA-HEADTRAI-SECTION */
        private void R0380_00_GRAVA_HEADTRAI_SECTION()
        {
            /*" -2483- MOVE '0380' TO WNR-EXEC-SQL. */
            _.Move("0380", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2484- IF WCEDE-CODEMPRESA(WS-CED) EQUAL ZEROS */

            if (WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA == 00)
            {

                /*" -2485- SET WS-CED UP BY 1 */
                WS_CED.Value += 1;

                /*" -2491- GO TO R0380-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0380_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2494- MOVE WCEDE-CODEMPRESA(WS-CED) TO HEADER-CODEMPRESA HEADER-CEDENTE. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA, HEADER_REGISTRO.HEADER_CODEMPRESA, HEADER_REGISTRO.HEADER_CEDENTE);

            /*" -2498- MOVE HEADER-CODREGISTR TO HEADER-TIPO HEADER-CANAL. */
            _.Move(HEADER_REGISTRO.HEADER_CODREGISTR, HEADER_REGISTRO.HEADER_TIPO, HEADER_REGISTRO.HEADER_CANAL);

            /*" -2499- MOVE HEADER-REGISTRO TO REG-ARQSORT */
            _.Move(HEADER_REGISTRO, REG_ARQSORT);

            /*" -2506- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -2508- MOVE WCEDE-CODEMPRESA(WS-CED) TO TRAILL-CEDENTE */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA, TRAILL_REGISTRO.TRAILL_CEDENTE);

            /*" -2512- MOVE TRAILL-CODREGISTR TO TRAILL-TIPO TRAILL-CANAL. */
            _.Move(TRAILL_REGISTRO.TRAILL_CODREGISTR, TRAILL_REGISTRO.TRAILL_TIPO, TRAILL_REGISTRO.TRAILL_CANAL);

            /*" -2513- MOVE TRAILL-REGISTRO TO REG-ARQSORT */
            _.Move(TRAILL_REGISTRO, REG_ARQSORT);

            /*" -2516- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -2520- MOVE ZEROS TO WCEDE-CODEMPRESA(WS-CED). */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA);

            /*" -2520- SET WS-CED UP BY 1. */
            WS_CED.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0380_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-TRATA-NRTIT-ZERO-SECTION */
        private void R0400_00_TRATA_NRTIT_ZERO_SECTION()
        {
            /*" -2533- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2534- MOVE COBRAN-NOSS-NUMERO TO WS-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, WS_AUX_ARQUIVO.WS_NRTIT);

            /*" -2536- PERFORM R0410-00-CONFERE-TITULO. */

            R0410_00_CONFERE_TITULO_SECTION();

            /*" -2537- IF COBRAN-NOSS-NUMERO NOT EQUAL WS-NRTIT */

            if (COBRAN_REGISTRO.COBRAN_NOSS_NUMERO != WS_AUX_ARQUIVO.WS_NRTIT)
            {

                /*" -2540- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2541- MOVE COBRAN-NOSS-NUMERO TO V0SFRC-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, V0SFRC_NRTIT);

            /*" -2543- PERFORM R0450-00-SELECT-SICOB-FAIXA. */

            R0450_00_SELECT_SICOB_FAIXA_SECTION();

            /*" -2544- IF V0SFRC-NRTIT EQUAL ZEROS */

            if (V0SFRC_NRTIT == 00)
            {

                /*" -2547- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2548- MOVE '8' TO AUX-OITO */
            _.Move("8", WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_OITO);

            /*" -2549- MOVE COBRAN-NOSS-NUMERO TO AUX-TITSIVPF */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF);

            /*" -2550- MOVE '0         ' TO AUX-ESPACOS */
            _.Move("0         ", WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_ESPACOS);

            /*" -2554- MOVE AUX-USO-EMPRESA TO COBRAN-USO-EMPRESA. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA, COBRAN_REGISTRO.COBRAN_USO_EMPRESA);

            /*" -2554- ADD 1 TO AC-SALVA. */
            WS_AUX_ARQUIVO.AC_SALVA.Value = WS_AUX_ARQUIVO.AC_SALVA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-CONFERE-TITULO-SECTION */
        private void R0410_00_CONFERE_TITULO_SECTION()
        {
            /*" -2567- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2570- MOVE WS-NUMTIT TO LPARM11. */
            _.Move(WS_AUX_ARQUIVO.FILLER_3.WS_NUMTIT, LPARM11X.LPARM11);

            /*" -2581- COMPUTE WPARM11-AUX = LPARM11-1 * 3 + LPARM11-2 * 2 + LPARM11-3 * 9 + LPARM11-4 * 8 + LPARM11-5 * 7 + LPARM11-6 * 6 + LPARM11-7 * 5 + LPARM11-8 * 4 + LPARM11-9 * 3 + LPARM11-10 * 2. */
            WS_AUX_ARQUIVO.WPARM11_AUX.Value = LPARM11X.FILLER_48.LPARM11_1 * 3 + LPARM11X.FILLER_48.LPARM11_2 * 2 + LPARM11X.FILLER_48.LPARM11_3 * 9 + LPARM11X.FILLER_48.LPARM11_4 * 8 + LPARM11X.FILLER_48.LPARM11_5 * 7 + LPARM11X.FILLER_48.LPARM11_6 * 6 + LPARM11X.FILLER_48.LPARM11_7 * 5 + LPARM11X.FILLER_48.LPARM11_8 * 4 + LPARM11X.FILLER_48.LPARM11_9 * 3 + LPARM11X.FILLER_48.LPARM11_10 * 2;

            /*" -2584- DIVIDE WPARM11-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(WS_AUX_ARQUIVO.WPARM11_AUX, 11, WS_AUX_ARQUIVO.WS_RESULT, WS_AUX_ARQUIVO.WS_RESTO);

            /*" -2585- IF WS-RESTO EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.WS_RESTO == 00)
            {

                /*" -2586- MOVE 0 TO WS-DIGTIT */
                _.Move(0, WS_AUX_ARQUIVO.FILLER_3.WS_DIGTIT);

                /*" -2587- ELSE */
            }
            else
            {


                /*" -2588- SUBTRACT WS-RESTO FROM 11 GIVING WS-DIGTIT. */
                WS_AUX_ARQUIVO.FILLER_3.WS_DIGTIT.Value = 11 - WS_AUX_ARQUIVO.WS_RESTO;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-TRATA-NRTIT-MULT-SECTION */
        private void R0420_00_TRATA_NRTIT_MULT_SECTION()
        {
            /*" -2601- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2604- ADD 1 TO AC-CED1144. */
            WS_AUX_ARQUIVO.AC_CED1144.Value = WS_AUX_ARQUIVO.AC_CED1144 + 1;

            /*" -2605- MOVE COBRAN-USO-EMPRESA TO AUX-USO-EMPRESA. */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA);

            /*" -2607- MOVE AUX-TITSIVPF TO AUX-NRO-SIVPF. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, WS_AUX_ARQUIVO.AUX_NRO_SIVPF);

            /*" -2608- IF AUX-CANAL NOT EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.FILLER_8.AUX_CANAL != 00)
            {

                /*" -2609- ADD 1 TO DP-CAN1144 */
                WS_AUX_ARQUIVO.DP_CAN1144.Value = WS_AUX_ARQUIVO.DP_CAN1144 + 1;

                /*" -2611- GO TO R0420-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2612- IF AUX-AGENCIA NOT EQUAL 0008 */

            if (WS_AUX_ARQUIVO.FILLER_8.AUX_AGENCIA != 0008)
            {

                /*" -2613- ADD 1 TO DP-AGE1144 */
                WS_AUX_ARQUIVO.DP_AGE1144.Value = WS_AUX_ARQUIVO.DP_AGE1144 + 1;

                /*" -2616- GO TO R0420-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2617- MOVE AUX-TITSIVPF TO AUX-TIT-CED1144. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, WS_AUX_ARQUIVO.AUX_TIT_CED1144);

            /*" -2619- MOVE AUX-NUM-CED1144 TO WS-NUMTIT. */
            _.Move(WS_AUX_ARQUIVO.FILLER_4.AUX_NUM_CED1144, WS_AUX_ARQUIVO.FILLER_3.WS_NUMTIT);

            /*" -2622- PERFORM R0410-00-CONFERE-TITULO. */

            R0410_00_CONFERE_TITULO_SECTION();

            /*" -2623- MOVE WS-NRTIT TO V0SFRC-NRTIT */
            _.Move(WS_AUX_ARQUIVO.WS_NRTIT, V0SFRC_NRTIT);

            /*" -2625- PERFORM R0450-00-SELECT-SICOB-FAIXA. */

            R0450_00_SELECT_SICOB_FAIXA_SECTION();

            /*" -2626- IF V0SFRC-NRTIT EQUAL ZEROS */

            if (V0SFRC_NRTIT == 00)
            {

                /*" -2627- ADD 1 TO DP-SFR1144 */
                WS_AUX_ARQUIVO.DP_SFR1144.Value = WS_AUX_ARQUIVO.DP_SFR1144 + 1;

                /*" -2630- GO TO R0420-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2631- MOVE WS-NRTIT TO AUX-TITSIVPF */
            _.Move(WS_AUX_ARQUIVO.WS_NRTIT, WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF);

            /*" -2635- MOVE AUX-USO-EMPRESA TO COBRAN-USO-EMPRESA. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA, COBRAN_REGISTRO.COBRAN_USO_EMPRESA);

            /*" -2635- ADD 1 TO AC-SALVA1. */
            WS_AUX_ARQUIVO.AC_SALVA1.Value = WS_AUX_ARQUIVO.AC_SALVA1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-SICOB-FAIXA-SECTION */
        private void R0450_00_SELECT_SICOB_FAIXA_SECTION()
        {
            /*" -2648- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2655- PERFORM R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1 */

            R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1();

            /*" -2659- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -2660- DISPLAY 'R0450-00 - PROBLEMAS NO SELECT(SICOB-FAI)' */
                _.Display($"R0450-00 - PROBLEMAS NO SELECT(SICOB-FAI)");

                /*" -2663- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2664- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2665- MOVE ZEROS TO V0SFRC-NRTIT */
                _.Move(0, V0SFRC_NRTIT);

                /*" -2666- ELSE */
            }
            else
            {


                /*" -2667- IF VIND-NRTIT LESS ZEROS */

                if (VIND_NRTIT < 00)
                {

                    /*" -2667- MOVE ZEROS TO V0SFRC-NRTIT. */
                    _.Move(0, V0SFRC_NRTIT);
                }

            }


        }

        [StopWatch]
        /*" R0450-00-SELECT-SICOB-FAIXA-DB-SELECT-1 */
        public void R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1()
        {
            /*" -2655- EXEC SQL SELECT NUM_SICOB_INI INTO :V0SFRC-NRTIT:VIND-NRTIT FROM SEGUROS.SICOB_FAIXA_RCAP WHERE NUM_SICOB_INI <= :V0SFRC-NRTIT AND NUM_SICOB_FIM >= :V0SFRC-NRTIT WITH UR END-EXEC. */

            var r0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1 = new R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1()
            {
                V0SFRC_NRTIT = V0SFRC_NRTIT.ToString(),
            };

            var executed_1 = R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1.Execute(r0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SFRC_NRTIT, V0SFRC_NRTIT);
                _.Move(executed_1.VIND_NRTIT, VIND_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-SICOB-FAIXA-SECTION */
        private void R0700_00_SELECT_SICOB_FAIXA_SECTION()
        {
            /*" -2680- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2687- PERFORM R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1 */

            R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1();

            /*" -2691- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -2692- DISPLAY 'R0700-00 - PROBLEMAS NO SELECT(SICOB-FAI)' */
                _.Display($"R0700-00 - PROBLEMAS NO SELECT(SICOB-FAI)");

                /*" -2695- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2697- ADD 1 TO DP-GRAFICA */
                WS_AUX_ARQUIVO.DP_GRAFICA.Value = WS_AUX_ARQUIVO.DP_GRAFICA + 1;

                /*" -2698- MOVE ZEROS TO COBRAN-CODPRODU */
                _.Move(0, COBRAN_REGISTRO.COBRAN_CODPRODU);

                /*" -2699- ELSE */
            }
            else
            {


                /*" -2700- ADD 1 TO AC-GRAFICA */
                WS_AUX_ARQUIVO.AC_GRAFICA.Value = WS_AUX_ARQUIVO.AC_GRAFICA + 1;

                /*" -2703- IF V0SFRC-CODPRODU EQUAL 400 OR 401 OR 402 */

                if (V0SFRC_CODPRODU.In("400", "401", "402"))
                {

                    /*" -2704- MOVE 004 TO COBRAN-CODPRODU */
                    _.Move(004, COBRAN_REGISTRO.COBRAN_CODPRODU);

                    /*" -2705- ELSE */
                }
                else
                {


                    /*" -2705- MOVE V0SFRC-CODPRODU TO COBRAN-CODPRODU. */
                    _.Move(V0SFRC_CODPRODU, COBRAN_REGISTRO.COBRAN_CODPRODU);
                }

            }


        }

        [StopWatch]
        /*" R0700-00-SELECT-SICOB-FAIXA-DB-SELECT-1 */
        public void R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1()
        {
            /*" -2687- EXEC SQL SELECT COD_PRODUTO INTO :V0SFRC-CODPRODU FROM SEGUROS.SICOB_FAIXA_RCAP WHERE NUM_SICOB_INI <= :V0SFRC-NRTIT AND NUM_SICOB_FIM >= :V0SFRC-NRTIT WITH UR END-EXEC. */

            var r0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1 = new R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1()
            {
                V0SFRC_NRTIT = V0SFRC_NRTIT.ToString(),
            };

            var executed_1 = R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SFRC_CODPRODU, V0SFRC_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-OUTPUT-SORT-SECTION */
        private void R1500_00_OUTPUT_SORT_SECTION()
        {
            /*" -2718- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2719- MOVE SPACES TO WFIM-SORT. */
            _.Move("", WS_AUX_ARQUIVO.WFIM_SORT);

            /*" -2722- PERFORM R1510-00-LE-ARQSORT. */

            R1510_00_LE_ARQSORT_SECTION();

            /*" -2723- IF WFIM-SORT NOT EQUAL SPACES */

            if (!WS_AUX_ARQUIVO.WFIM_SORT.IsEmpty())
            {

                /*" -2726- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2730- PERFORM R1550-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_SORT.IsEmpty()))
            {

                R1550_00_PROCESSA_SORT_SECTION();
            }

            /*" -2730- PERFORM R7500-00-UPDATE-V0CEDENTE. */

            R7500_00_UPDATE_V0CEDENTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-LE-ARQSORT-SECTION */
        private void R1510_00_LE_ARQSORT_SECTION()
        {
            /*" -2743- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2745- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -2745- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WS_AUX_ARQUIVO.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-PROCESSA-SORT-SECTION */
        private void R1550_00_PROCESSA_SORT_SECTION()
        {
            /*" -2758- MOVE '1550' TO WNR-EXEC-SQL. */
            _.Move("1550", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2759- IF SOR-CODREGISTR EQUAL '0' */

            if (REG_ARQSORT.SOR_CODREGISTR == "0")
            {

                /*" -2760- MOVE REG-ARQSORT TO HEADER-REGISTRO */
                _.Move(REG_ARQSORT, HEADER_REGISTRO);

                /*" -2761- PERFORM R2350-00-CONSISTE-HEADER */

                R2350_00_CONSISTE_HEADER_SECTION();

                /*" -2762- GO TO R1550-90-LEITURA */

                R1550_90_LEITURA(); //GOTO
                return;

                /*" -2763- ELSE */
            }
            else
            {


                /*" -2764- IF SOR-CODREGISTR EQUAL '9' */

                if (REG_ARQSORT.SOR_CODREGISTR == "9")
                {

                    /*" -2765- MOVE REG-ARQSORT TO TRAILL-REGISTRO */
                    _.Move(REG_ARQSORT, TRAILL_REGISTRO);

                    /*" -2766- PERFORM R4500-00-TRATA-TRAILLER */

                    R4500_00_TRATA_TRAILLER_SECTION();

                    /*" -2767- GO TO R1550-90-LEITURA */

                    R1550_90_LEITURA(); //GOTO
                    return;

                    /*" -2768- ELSE */
                }
                else
                {


                    /*" -2771- MOVE REG-ARQSORT TO COBRAN-REGISTRO. */
                    _.Move(REG_ARQSORT, COBRAN_REGISTRO);
                }

            }


            /*" -2780- ADD 1 TO V0CNAB-QTDREG. */
            V0CNAB_QTDREG.Value = V0CNAB_QTDREG + 1;

            /*" -2781- IF COBRAN-DATAOCORREN NOT NUMERIC */

            if (!COBRAN_REGISTRO.COBRAN_DATAOCORREN.IsNumeric())
            {

                /*" -2782- MOVE ZEROS TO WDATA-SECULO */
                _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                /*" -2783- ELSE */
            }
            else
            {


                /*" -2784- IF COBRAN-DATAOCORREN EQUAL ZEROS */

                if (COBRAN_REGISTRO.COBRAN_DATAOCORREN == 00)
                {

                    /*" -2785- MOVE ZEROS TO WDATA-SECULO */
                    _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                    /*" -2786- ELSE */
                }
                else
                {


                    /*" -2787- MOVE COBRAN-DATAOCORREN TO WDATA-FITA */
                    _.Move(COBRAN_REGISTRO.COBRAN_DATAOCORREN, WS_AUX_DATAS.WDATA_FITA);

                    /*" -2788- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA);

                    /*" -2789- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES);

                    /*" -2790- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO);

                    /*" -2791- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

                    if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
                    {

                        /*" -2792- MOVE 19 TO WDAT-SEC-SEC */
                        _.Move(19, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);

                        /*" -2793- ELSE */
                    }
                    else
                    {


                        /*" -2795- MOVE 20 TO WDAT-SEC-SEC. */
                        _.Move(20, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);
                    }

                }

            }


            /*" -2797- MOVE WDATA-SECULO TO CONVEN-DATAOCORREN. */
            _.Move(WS_AUX_DATAS.WDATA_SECULO, WS_AUX_ARQUIVO.CONVEN_DATAOCORREN);

            /*" -2798- IF COBRAN-DTVENCTO NOT NUMERIC */

            if (!COBRAN_REGISTRO.COBRAN_DTVENCTO.IsNumeric())
            {

                /*" -2799- MOVE ZEROS TO WDATA-SECULO */
                _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                /*" -2800- ELSE */
            }
            else
            {


                /*" -2801- IF COBRAN-DTVENCTO EQUAL ZEROS */

                if (COBRAN_REGISTRO.COBRAN_DTVENCTO == 00)
                {

                    /*" -2802- MOVE ZEROS TO WDATA-SECULO */
                    _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                    /*" -2803- ELSE */
                }
                else
                {


                    /*" -2804- MOVE COBRAN-DTVENCTO TO WDATA-FITA */
                    _.Move(COBRAN_REGISTRO.COBRAN_DTVENCTO, WS_AUX_DATAS.WDATA_FITA);

                    /*" -2805- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA);

                    /*" -2806- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES);

                    /*" -2807- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO);

                    /*" -2808- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

                    if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
                    {

                        /*" -2809- MOVE 19 TO WDAT-SEC-SEC */
                        _.Move(19, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);

                        /*" -2810- ELSE */
                    }
                    else
                    {


                        /*" -2812- MOVE 20 TO WDAT-SEC-SEC. */
                        _.Move(20, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);
                    }

                }

            }


            /*" -2818- MOVE WDATA-SECULO TO CONVEN-DTVENCTO. */
            _.Move(WS_AUX_DATAS.WDATA_SECULO, WS_AUX_ARQUIVO.CONVEN_DTVENCTO);

            /*" -2819- MOVE WDAT-SEC-DIA TO AUX-DTVEN-DD. */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_ARQUIVO.AUX_NOME.AUX_DTVEN_DD);

            /*" -2820- MOVE '/' TO AUX-DTVEN-01. */
            _.Move("/", WS_AUX_ARQUIVO.AUX_NOME.AUX_DTVEN_01);

            /*" -2821- MOVE WDAT-SEC-MES TO AUX-DTVEN-MM. */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_ARQUIVO.AUX_NOME.AUX_DTVEN_MM);

            /*" -2822- MOVE '/' TO AUX-DTVEN-02. */
            _.Move("/", WS_AUX_ARQUIVO.AUX_NOME.AUX_DTVEN_02);

            /*" -2823- MOVE WDAT-SEC-SEC TO AUX-DTVEN-A1. */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_ARQUIVO.AUX_NOME.AUX_DTVEN_A1);

            /*" -2829- MOVE WDAT-SEC-ANO TO AUX-DTVEN-A2. */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_ARQUIVO.AUX_NOME.AUX_DTVEN_A2);

            /*" -2830- IF COBRAN-DATA-CRED NOT NUMERIC */

            if (!COBRAN_REGISTRO.COBRAN_DATA_CRED.IsNumeric())
            {

                /*" -2831- MOVE ZEROS TO WDATA-SECULO */
                _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                /*" -2832- ELSE */
            }
            else
            {


                /*" -2833- IF COBRAN-DATA-CRED EQUAL ZEROS */

                if (COBRAN_REGISTRO.COBRAN_DATA_CRED == 00)
                {

                    /*" -2834- MOVE ZEROS TO WDATA-SECULO */
                    _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                    /*" -2835- ELSE */
                }
                else
                {


                    /*" -2836- MOVE COBRAN-DATA-CRED TO WDATA-FITA */
                    _.Move(COBRAN_REGISTRO.COBRAN_DATA_CRED, WS_AUX_DATAS.WDATA_FITA);

                    /*" -2837- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA);

                    /*" -2838- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES);

                    /*" -2839- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO);

                    /*" -2840- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

                    if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
                    {

                        /*" -2841- MOVE 19 TO WDAT-SEC-SEC */
                        _.Move(19, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);

                        /*" -2842- ELSE */
                    }
                    else
                    {


                        /*" -2844- MOVE 20 TO WDAT-SEC-SEC. */
                        _.Move(20, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);
                    }

                }

            }


            /*" -2847- MOVE WDATA-SECULO TO CONVEN-DATA-CRED. */
            _.Move(WS_AUX_DATAS.WDATA_SECULO, WS_AUX_ARQUIVO.CONVEN_DATA_CRED);

            /*" -2848- MOVE ZEROS TO CONVEN-FONTE */
            _.Move(0, WS_AUX_ARQUIVO.CONVEN_FONTE);

            /*" -2849- MOVE 9999 TO CONVEN-ESCNEG */
            _.Move(9999, WS_AUX_ARQUIVO.CONVEN_ESCNEG);

            /*" -2852- MOVE COBRAN-AGE-COBRAN TO V0RCAP-AGECOBR CONVEN-AGECOBR. */
            _.Move(COBRAN_REGISTRO.FILLER_40.COBRAN_AGE_COBRAN, V0RCAP_AGECOBR, WS_AUX_ARQUIVO.CONVEN_AGECOBR);

            /*" -2853- MOVE COBRAN-TITULO16 TO WS-TIT-AUTO-16 */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16, WS_TIT_AUTO.WS_TIT_AUTO_16);

            /*" -2855- IF WS-CANAL-AUTO EQUAL 8 OR 9 OR 1 OR 6 OR 5 */

            if (WS_TIT_AUTO.FILLER_47.WS_CANAL_AUTO.In("8", "9", "1", "6", "5"))
            {

                /*" -2862- MOVE WS-AGE-COB-AUTO TO V0RCAP-AGECOBR CONVEN-AGECOBR. */
                _.Move(WS_TIT_AUTO.FILLER_47.WS_AGE_COB_AUTO, V0RCAP_AGECOBR, WS_AUX_ARQUIVO.CONVEN_AGECOBR);
            }


            /*" -2863- IF COBRAN-COD-BCO EQUAL 104 */

            if (COBRAN_REGISTRO.COBRAN_COD_BCO == 104)
            {

                /*" -2864- PERFORM R1560-00-VERIFICA-CEF */

                R1560_00_VERIFICA_CEF_SECTION();

                /*" -2865- ELSE */
            }
            else
            {


                /*" -2868- PERFORM R1700-00-VERIFICA-OUTROS. */

                R1700_00_VERIFICA_OUTROS_SECTION();
            }


            /*" -2868- PERFORM R2600-00-PROCESSA-RCAP. */

            R2600_00_PROCESSA_RCAP_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1550_90_LEITURA */

            R1550_90_LEITURA();

        }

        [StopWatch]
        /*" R1550-90-LEITURA */
        private void R1550_90_LEITURA(bool isPerform = false)
        {
            /*" -2873- PERFORM R1510-00-LE-ARQSORT. */

            R1510_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1560-00-VERIFICA-CEF-SECTION */
        private void R1560_00_VERIFICA_CEF_SECTION()
        {
            /*" -2885- MOVE '1560' TO WNR-EXEC-SQL. */
            _.Move("1560", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2886- SET WS-AGE TO 1 */
            WS_AGE.Value = 1;

            /*" -2887- SEARCH WACEF-OCORREAGE */
            for (; WS_AGE < WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE.Items.Count; WS_AGE.Value++)
            {

                /*" -2889- WHEN V0RCAP-AGECOBR EQUAL WACEF-AGENCIA(WS-AGE) */

                if (V0RCAP_AGECOBR == WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA)
                {


                    /*" -2891- MOVE WACEF-ESCNEG(WS-AGE) TO CONVEN-ESCNEG */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG, WS_AUX_ARQUIVO.CONVEN_ESCNEG);

                    /*" -2892- MOVE WACEF-FONTE(WS-AGE) TO CONVEN-FONTE  END-SEARCH. */
                    break;
                }
            }


            /*" -2899- IF CONVEN-ESCNEG EQUAL 9999 */

            if (WS_AUX_ARQUIVO.CONVEN_ESCNEG == 9999)
            {

                /*" -2900- PERFORM R1600-00-PESQUISA-AGENCIA */

                R1600_00_PESQUISA_AGENCIA_SECTION();

                /*" -2901- ELSE */
            }
            else
            {


                /*" -2901- MOVE V0RCAP-AGECOBR TO COBRAN-AGE-COBRAN. */
                _.Move(V0RCAP_AGECOBR, COBRAN_REGISTRO.FILLER_40.COBRAN_AGE_COBRAN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1560_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-PESQUISA-AGENCIA-SECTION */
        private void R1600_00_PESQUISA_AGENCIA_SECTION()
        {
            /*" -2914- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2915- MOVE ZEROS TO CONVEN-FONTE */
            _.Move(0, WS_AUX_ARQUIVO.CONVEN_FONTE);

            /*" -2916- MOVE 9999 TO CONVEN-ESCNEG */
            _.Move(9999, WS_AUX_ARQUIVO.CONVEN_ESCNEG);

            /*" -2920- MOVE COBRAN-AGE-COBRAN TO V0RCAP-AGECOBR CONVEN-AGECOBR. */
            _.Move(COBRAN_REGISTRO.FILLER_40.COBRAN_AGE_COBRAN, V0RCAP_AGECOBR, WS_AUX_ARQUIVO.CONVEN_AGECOBR);

            /*" -2921- SET WS-AGE TO 1 */
            WS_AGE.Value = 1;

            /*" -2922- SEARCH WACEF-OCORREAGE */
            for (; WS_AGE < WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE.Items.Count; WS_AGE.Value++)
            {

                /*" -2924- WHEN V0RCAP-AGECOBR EQUAL WACEF-AGENCIA(WS-AGE) */

                if (V0RCAP_AGECOBR == WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA)
                {


                    /*" -2926- MOVE WACEF-ESCNEG(WS-AGE) TO CONVEN-ESCNEG */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG, WS_AUX_ARQUIVO.CONVEN_ESCNEG);

                    /*" -2927- MOVE WACEF-FONTE(WS-AGE) TO CONVEN-FONTE  END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-VERIFICA-OUTROS-SECTION */
        private void R1700_00_VERIFICA_OUTROS_SECTION()
        {
            /*" -2940- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2942- MOVE COBRAN-COD-BCO TO V0AGEN-BANCO. */
            _.Move(COBRAN_REGISTRO.COBRAN_COD_BCO, V0AGEN_BANCO);

            /*" -2945- MOVE V0RCAP-AGECOBR TO V0AGEN-AGENCIA. */
            _.Move(V0RCAP_AGECOBR, V0AGEN_AGENCIA);

            /*" -2948- PERFORM R1750-00-SELECT-V0AGENCIAS. */

            R1750_00_SELECT_V0AGENCIAS_SECTION();

            /*" -2949- IF V0AGEN-ESTADO EQUAL 'RJ' */

            if (V0AGEN_ESTADO == "RJ")
            {

                /*" -2950- MOVE 01 TO CONVEN-FONTE */
                _.Move(01, WS_AUX_ARQUIVO.CONVEN_FONTE);

                /*" -2951- ELSE */
            }
            else
            {


                /*" -2952- IF V0AGEN-ESTADO EQUAL 'BA' */

                if (V0AGEN_ESTADO == "BA")
                {

                    /*" -2953- MOVE 04 TO CONVEN-FONTE */
                    _.Move(04, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2954- ELSE */
                }
                else
                {


                    /*" -2955- IF V0AGEN-ESTADO EQUAL 'CE' */

                    if (V0AGEN_ESTADO == "CE")
                    {

                        /*" -2956- MOVE 06 TO CONVEN-FONTE */
                        _.Move(06, WS_AUX_ARQUIVO.CONVEN_FONTE);

                        /*" -2957- ELSE */
                    }
                    else
                    {


                        /*" -2958- IF V0AGEN-ESTADO EQUAL 'ES' */

                        if (V0AGEN_ESTADO == "ES")
                        {

                            /*" -2959- MOVE 07 TO CONVEN-FONTE */
                            _.Move(07, WS_AUX_ARQUIVO.CONVEN_FONTE);

                            /*" -2960- ELSE */
                        }
                        else
                        {


                            /*" -2961- IF V0AGEN-ESTADO EQUAL 'GO' */

                            if (V0AGEN_ESTADO == "GO")
                            {

                                /*" -2962- MOVE 09 TO CONVEN-FONTE */
                                _.Move(09, WS_AUX_ARQUIVO.CONVEN_FONTE);

                                /*" -2963- ELSE */
                            }
                            else
                            {


                                /*" -2964- IF V0AGEN-ESTADO EQUAL 'MG' */

                                if (V0AGEN_ESTADO == "MG")
                                {

                                    /*" -2965- MOVE 12 TO CONVEN-FONTE */
                                    _.Move(12, WS_AUX_ARQUIVO.CONVEN_FONTE);

                                    /*" -2966- ELSE */
                                }
                                else
                                {


                                    /*" -2967- IF V0AGEN-ESTADO EQUAL 'PA' */

                                    if (V0AGEN_ESTADO == "PA")
                                    {

                                        /*" -2968- MOVE 13 TO CONVEN-FONTE */
                                        _.Move(13, WS_AUX_ARQUIVO.CONVEN_FONTE);

                                        /*" -2969- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2970- IF V0AGEN-ESTADO EQUAL 'PR' */

                                        if (V0AGEN_ESTADO == "PR")
                                        {

                                            /*" -2971- MOVE 15 TO CONVEN-FONTE */
                                            _.Move(15, WS_AUX_ARQUIVO.CONVEN_FONTE);

                                            /*" -2972- ELSE */
                                        }
                                        else
                                        {


                                            /*" -2973- IF V0AGEN-ESTADO EQUAL 'PE' */

                                            if (V0AGEN_ESTADO == "PE")
                                            {

                                                /*" -2974- MOVE 16 TO CONVEN-FONTE */
                                                _.Move(16, WS_AUX_ARQUIVO.CONVEN_FONTE);

                                                /*" -2975- ELSE */
                                            }
                                            else
                                            {


                                                /*" -2976- IF V0AGEN-ESTADO EQUAL 'RS' */

                                                if (V0AGEN_ESTADO == "RS")
                                                {

                                                    /*" -2977- MOVE 19 TO CONVEN-FONTE */
                                                    _.Move(19, WS_AUX_ARQUIVO.CONVEN_FONTE);

                                                    /*" -2978- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -2979- IF V0AGEN-ESTADO EQUAL 'SC' */

                                                    if (V0AGEN_ESTADO == "SC")
                                                    {

                                                        /*" -2980- MOVE 20 TO CONVEN-FONTE */
                                                        _.Move(20, WS_AUX_ARQUIVO.CONVEN_FONTE);

                                                        /*" -2981- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -2982- IF V0AGEN-ESTADO EQUAL 'SP' */

                                                        if (V0AGEN_ESTADO == "SP")
                                                        {

                                                            /*" -2983- MOVE 21 TO CONVEN-FONTE */
                                                            _.Move(21, WS_AUX_ARQUIVO.CONVEN_FONTE);

                                                            /*" -2984- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -2985- IF V0AGEN-ESTADO EQUAL 'MS' */

                                                            if (V0AGEN_ESTADO == "MS")
                                                            {

                                                                /*" -2986- MOVE 23 TO CONVEN-FONTE */
                                                                _.Move(23, WS_AUX_ARQUIVO.CONVEN_FONTE);

                                                                /*" -2987- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -2987- MOVE 10 TO CONVEN-FONTE. */
                                                                _.Move(10, WS_AUX_ARQUIVO.CONVEN_FONTE);
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1750-00-SELECT-V0AGENCIAS-SECTION */
        private void R1750_00_SELECT_V0AGENCIAS_SECTION()
        {
            /*" -3000- MOVE '1750' TO WNR-EXEC-SQL. */
            _.Move("1750", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3007- PERFORM R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1 */

            R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1();

            /*" -3011- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3012- MOVE 'DF' TO V0AGEN-ESTADO */
                _.Move("DF", V0AGEN_ESTADO);

                /*" -3013- ELSE */
            }
            else
            {


                /*" -3014- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3015- DISPLAY 'R1750-00 - PROBLEMAS NO SELECT(V0AGENCIAS)' */
                    _.Display($"R1750-00 - PROBLEMAS NO SELECT(V0AGENCIAS)");

                    /*" -3015- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1750-00-SELECT-V0AGENCIAS-DB-SELECT-1 */
        public void R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1()
        {
            /*" -3007- EXEC SQL SELECT ESTADO INTO :V0AGEN-ESTADO FROM SEGUROS.V0AGENCIAS WHERE BANCO = :V0AGEN-BANCO AND AGENCIA = :V0AGEN-AGENCIA WITH UR END-EXEC. */

            var r1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1 = new R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1()
            {
                V0AGEN_AGENCIA = V0AGEN_AGENCIA.ToString(),
                V0AGEN_BANCO = V0AGEN_BANCO.ToString(),
            };

            var executed_1 = R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1.Execute(r1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AGEN_ESTADO, V0AGEN_ESTADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-CONSISTE-HEADER-SECTION */
        private void R2350_00_CONSISTE_HEADER_SECTION()
        {
            /*" -3028- MOVE '2350' TO WNR-EXEC-SQL. */
            _.Move("2350", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3029- IF HEADER-CEDENTE EQUAL 630870000000440 */

            if (HEADER_REGISTRO.HEADER_CEDENTE == 630870000000440)
            {

                /*" -3030- MOVE HEADER-REGISTRO TO REG-PF0002B1 */
                _.Move(HEADER_REGISTRO, REG_PF0002B1);

                /*" -3037- WRITE REG-PF0002B1. */
                PF0002B1.Write(REG_PF0002B1.GetMoveValues().ToString());
            }


            /*" -3039- MOVE HEADER-CODEMPRESA TO WWORK-CODEMPRE WWORK-CEDENTE */
            _.Move(HEADER_REGISTRO.HEADER_CODEMPRESA, WS_AUX_AVISO.WWORK_CODEMPRE, WS_AUX_AVISO.WWORK_CEDENTE);

            /*" -3040- MOVE HEADER-CODBANCO TO WWORK-BCOAVISO */
            _.Move(HEADER_REGISTRO.HEADER_CODBANCO, WS_AUX_AVISO.WWORK_BCOAVISO);

            /*" -3043- MOVE HEADER-NUMFITA TO WWORK-NUMFITA. */
            _.Move(HEADER_REGISTRO.HEADER_NUMFITA, WS_AUX_AVISO.WWORK_NUMFITA);

            /*" -3046- PERFORM R2450-00-MONTA-CONTROLE. */

            R2450_00_MONTA_CONTROLE_SECTION();

            /*" -3048- PERFORM R2500-00-SELECT-V0AVISOCRED. */

            R2500_00_SELECT_V0AVISOCRED_SECTION();

            /*" -3049- IF V0AVIS-COUNT NOT EQUAL ZEROS */

            if (V0AVIS_COUNT != 00)
            {

                /*" -3051- DISPLAY 'AVISO DE CREDITO JA CADASTRADO         ' WWORK-AGEAVISO ' ' WWORK-NRAVISO */

                $"AVISO DE CREDITO JA CADASTRADO         {WS_AUX_AVISO.WWORK_AGEAVISO} {WS_AUX_AVISO.WWORK_NRAVISO}"
                .Display();

                /*" -3051- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-MONTA-CONTROLE-SECTION */
        private void R2450_00_MONTA_CONTROLE_SECTION()
        {
            /*" -3066- MOVE '2450' TO WNR-EXEC-SQL. */
            _.Move("2450", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3068- MOVE HEADER-DATAGRAVAC TO WDATA-FITA WWORK-DATCEF1 */
            _.Move(HEADER_REGISTRO.HEADER_DATAGRAVAC, WS_AUX_DATAS.WDATA_FITA, WS_AUX_AVISO.WWORK_DATCEF1);

            /*" -3069- MOVE WDAT-FITA-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -3070- MOVE WDAT-FITA-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -3072- MOVE WDAT-FITA-ANO TO WDAT-TAB-ANO. */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -3073- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

            if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
            {

                /*" -3074- MOVE 19 TO WDAT-TAB-SEC */
                _.Move(19, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

                /*" -3075- ELSE */
            }
            else
            {


                /*" -3077- MOVE 20 TO WDAT-TAB-SEC. */
                _.Move(20, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);
            }


            /*" -3078- MOVE WDAT-TAB-SEC TO WDAT-SEC-SEC */
            _.Move(WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);

            /*" -3079- MOVE WDAT-TAB-ANO TO WDAT-SEC-ANO */
            _.Move(WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO, WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO);

            /*" -3080- MOVE WDAT-TAB-MES TO WDAT-SEC-MES */
            _.Move(WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES, WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES);

            /*" -3082- MOVE WDAT-TAB-DIA TO WDAT-SEC-DIA. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA, WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA);

            /*" -3083- MOVE WDATA-SECULO TO WWORK-DATCEF */
            _.Move(WS_AUX_DATAS.WDATA_SECULO, WS_AUX_AVISO.WWORK_DATCEF);

            /*" -3090- MOVE WDATA-TABELA TO WWORK-DTAVISO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, WS_AUX_AVISO.WWORK_DTAVISO);

            /*" -3091- MOVE ZEROS TO V0CNAB-COD-EMP */
            _.Move(0, V0CNAB_COD_EMP);

            /*" -3092- MOVE ZEROS TO V0CNAB-ORGAO */
            _.Move(0, V0CNAB_ORGAO);

            /*" -3093- MOVE 'A' TO V0CNAB-TIPOCOB */
            _.Move("A", V0CNAB_TIPOCOB);

            /*" -3094- MOVE WWORK-NRCTACED TO V0CNAB-NRCTACED */
            _.Move(WS_AUX_AVISO.FILLER_26.WWORK_NRCTACED, V0CNAB_NRCTACED);

            /*" -3095- MOVE V0SIST-DTMOVABE TO V0CNAB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0CNAB_DTMOVTO);

            /*" -3096- MOVE WWORK-DTAVISO TO V0CNAB-DATCEF */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0CNAB_DATCEF);

            /*" -3097- MOVE WWORK-NUMFITA TO V0CNAB-NRSEQ */
            _.Move(WS_AUX_AVISO.WWORK_NUMFITA, V0CNAB_NRSEQ);

            /*" -3104- MOVE ZEROS TO V0CNAB-QTDREG. */
            _.Move(0, V0CNAB_QTDREG);

            /*" -3105- MOVE WWORK-CED-CTA2 TO WWORK-COD-AGE */
            _.Move(WS_AUX_AVISO.FILLER_28.WWORK_CED_CTA2, WS_AUX_AVISO.FILLER_29.WWORK_COD_AGE);

            /*" -3106- MOVE 8 TO WWORK-TIP-AGE */
            _.Move(8, WS_AUX_AVISO.FILLER_29.WWORK_TIP_AGE);

            /*" -3107- MOVE WWORK-AGEAVISO TO WWORK-AVS-AGE */
            _.Move(WS_AUX_AVISO.WWORK_AGEAVISO, WS_AUX_AVISO.FILLER_30.WWORK_AVS_AGE);

            /*" -3108- MOVE WWORK-NUMFITA TO WWORK-AVS-NRO */
            _.Move(WS_AUX_AVISO.WWORK_NUMFITA, WS_AUX_AVISO.FILLER_30.WWORK_AVS_NRO);

            /*" -3109- MOVE 7 TO WWORK-TIP-AGE. */
            _.Move(7, WS_AUX_AVISO.FILLER_29.WWORK_TIP_AGE);

            /*" -3114- MOVE 'R' TO WWORK-TIPAVI. */
            _.Move("R", WS_AUX_AVISO.WWORK_TIPAVI);

            /*" -3117- IF WWORK-CODEMPRE EQUAL 630870000000601 OR 630870000000610 OR 630870000003198 */

            if (WS_AUX_AVISO.WWORK_CODEMPRE.In("630870000000601", "630870000000610", "630870000003198"))
            {

                /*" -3118- MOVE 7250 TO WWORK-AGEAVISO */
                _.Move(7250, WS_AUX_AVISO.WWORK_AGEAVISO);

                /*" -3119- MOVE 0014 TO WWORK-ORIGAVISO */
                _.Move(0014, WS_AUX_AVISO.WWORK_ORIGAVISO);

                /*" -3123- ELSE */
            }
            else
            {


                /*" -3125- IF WWORK-CODEMPRE EQUAL 630870000000628 OR 630870000003201 */

                if (WS_AUX_AVISO.WWORK_CODEMPRE.In("630870000000628", "630870000003201"))
                {

                    /*" -3126- MOVE 7250 TO WWORK-AGEAVISO */
                    _.Move(7250, WS_AUX_AVISO.WWORK_AGEAVISO);

                    /*" -3127- MOVE 0002 TO WWORK-ORIGAVISO */
                    _.Move(0002, WS_AUX_AVISO.WWORK_ORIGAVISO);

                    /*" -3128- MOVE 'C' TO WWORK-TIPAVI */
                    _.Move("C", WS_AUX_AVISO.WWORK_TIPAVI);

                    /*" -3132- ELSE */
                }
                else
                {


                    /*" -3134- IF WWORK-CODEMPRE EQUAL 630870000000725 */

                    if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000725)
                    {

                        /*" -3135- MOVE 7011 TO WWORK-AGEAVISO */
                        _.Move(7011, WS_AUX_AVISO.WWORK_AGEAVISO);

                        /*" -3136- MOVE 0002 TO WWORK-ORIGAVISO */
                        _.Move(0002, WS_AUX_AVISO.WWORK_ORIGAVISO);

                        /*" -3137- MOVE 'C' TO WWORK-TIPAVI */
                        _.Move("C", WS_AUX_AVISO.WWORK_TIPAVI);

                        /*" -3141- ELSE */
                    }
                    else
                    {


                        /*" -3143- IF WWORK-CODEMPRE EQUAL 630870000000113 */

                        if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000113)
                        {

                            /*" -3144- MOVE 7011 TO WWORK-AGEAVISO */
                            _.Move(7011, WS_AUX_AVISO.WWORK_AGEAVISO);

                            /*" -3145- MOVE 0011 TO WWORK-ORIGAVISO */
                            _.Move(0011, WS_AUX_AVISO.WWORK_ORIGAVISO);

                            /*" -3149- ELSE */
                        }
                        else
                        {


                            /*" -3152- IF WWORK-CODEMPRE EQUAL 630870000000750 OR WWORK-CODEMPRE EQUAL 630870000001306 */

                            if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000750 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000001306)
                            {

                                /*" -3154- MOVE 7999 TO WWORK-AGEAVISO */
                                _.Move(7999, WS_AUX_AVISO.WWORK_AGEAVISO);

                                /*" -3155- MOVE 0001 TO WWORK-ORIGAVISO */
                                _.Move(0001, WS_AUX_AVISO.WWORK_ORIGAVISO);

                                /*" -3159- ELSE */
                            }
                            else
                            {


                                /*" -3160- IF WWORK-CODEMPRE EQUAL 630870000002337 */

                                if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000002337)
                                {

                                    /*" -3161- MOVE 7245 TO WWORK-AGEAVISO */
                                    _.Move(7245, WS_AUX_AVISO.WWORK_AGEAVISO);

                                    /*" -3162- MOVE 0008 TO WWORK-ORIGAVISO */
                                    _.Move(0008, WS_AUX_AVISO.WWORK_ORIGAVISO);

                                    /*" -3164- ELSE */
                                }
                                else
                                {


                                    /*" -3173- IF WWORK-CODEMPRE EQUAL 630870000000130 OR WWORK-CODEMPRE EQUAL 630870000000318 OR WWORK-CODEMPRE EQUAL 630870000000342 OR WWORK-CODEMPRE EQUAL 630870000001004 OR WWORK-CODEMPRE EQUAL 630870000001136 OR WWORK-CODEMPRE EQUAL 630870000002876 OR WWORK-CODEMPRE EQUAL 630870000002884 */

                                    if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000130 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000318 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000342 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000001004 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000001136 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000002876 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000002884)
                                    {

                                        /*" -3174- MOVE 7011 TO WWORK-AGEAVISO */
                                        _.Move(7011, WS_AUX_AVISO.WWORK_AGEAVISO);

                                        /*" -3175- MOVE 0008 TO WWORK-ORIGAVISO */
                                        _.Move(0008, WS_AUX_AVISO.WWORK_ORIGAVISO);

                                        /*" -3179- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3181- IF WWORK-CODEMPRE EQUAL 630870000000326 */

                                        if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000326)
                                        {

                                            /*" -3182- MOVE 7011 TO WWORK-AGEAVISO */
                                            _.Move(7011, WS_AUX_AVISO.WWORK_AGEAVISO);

                                            /*" -3183- MOVE 0014 TO WWORK-ORIGAVISO */
                                            _.Move(0014, WS_AUX_AVISO.WWORK_ORIGAVISO);

                                            /*" -3187- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3189- IF WWORK-CODEMPRE EQUAL 630870000000334 */

                                            if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000334)
                                            {

                                                /*" -3191- MOVE 7011 TO WWORK-AGEAVISO */
                                                _.Move(7011, WS_AUX_AVISO.WWORK_AGEAVISO);

                                                /*" -3192- MOVE 0001 TO WWORK-ORIGAVISO */
                                                _.Move(0001, WS_AUX_AVISO.WWORK_ORIGAVISO);

                                                /*" -3193- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3196- IF WWORK-CODEMPRE EQUAL 630870000001144 */

                                                if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000001144)
                                                {

                                                    /*" -3198- MOVE 7999 TO WWORK-AGEAVISO */
                                                    _.Move(7999, WS_AUX_AVISO.WWORK_AGEAVISO);

                                                    /*" -3199- MOVE 0001 TO WWORK-ORIGAVISO */
                                                    _.Move(0001, WS_AUX_AVISO.WWORK_ORIGAVISO);

                                                    /*" -3203- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3204- IF WWORK-CODEMPRE EQUAL 630870000000440 */

                                                    if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000440)
                                                    {

                                                        /*" -3205- MOVE 7003 TO WWORK-AGEAVISO */
                                                        _.Move(7003, WS_AUX_AVISO.WWORK_AGEAVISO);

                                                        /*" -3206- MOVE 0018 TO WWORK-ORIGAVISO */
                                                        _.Move(0018, WS_AUX_AVISO.WWORK_ORIGAVISO);

                                                        /*" -3207- MOVE 'C' TO WWORK-TIPAVI */
                                                        _.Move("C", WS_AUX_AVISO.WWORK_TIPAVI);

                                                        /*" -3211- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -3212- IF WWORK-CODEMPRE EQUAL 630870000002825 */

                                                        if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000002825)
                                                        {

                                                            /*" -3213- MOVE 7282 TO WWORK-AGEAVISO */
                                                            _.Move(7282, WS_AUX_AVISO.WWORK_AGEAVISO);

                                                            /*" -3214- MOVE 0021 TO WWORK-ORIGAVISO */
                                                            _.Move(0021, WS_AUX_AVISO.WWORK_ORIGAVISO);

                                                            /*" -3216- MOVE 'C' TO WWORK-TIPAVI. */
                                                            _.Move("C", WS_AUX_AVISO.WWORK_TIPAVI);
                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -3217- MOVE WWORK-BCOAVISO TO V0AVIS-BCOAVISO */
            _.Move(WS_AUX_AVISO.WWORK_BCOAVISO, V0AVIS_BCOAVISO);

            /*" -3218- MOVE WWORK-AGEAVISO TO V0AVIS-AGEAVISO */
            _.Move(WS_AUX_AVISO.WWORK_AGEAVISO, V0AVIS_AGEAVISO);

            /*" -3219- MOVE WWORK-NRAVISO TO V0AVIS-NRAVISO */
            _.Move(WS_AUX_AVISO.WWORK_NRAVISO, V0AVIS_NRAVISO);

            /*" -3220- MOVE 1 TO V0AVIS-NRSEQ */
            _.Move(1, V0AVIS_NRSEQ);

            /*" -3221- MOVE V0SIST-DTMOVABE TO V0AVIS-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0AVIS_DTMOVTO);

            /*" -3222- MOVE 100 TO V0AVIS-OPERACAO */
            _.Move(100, V0AVIS_OPERACAO);

            /*" -3223- MOVE WWORK-TIPAVI TO V0AVIS-TIPAVI */
            _.Move(WS_AUX_AVISO.WWORK_TIPAVI, V0AVIS_TIPAVI);

            /*" -3224- MOVE WWORK-DTAVISO TO V0AVIS-DTAVISO */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0AVIS_DTAVISO);

            /*" -3229- MOVE ZEROS TO V0AVIS-VLIOCC V0AVIS-VLDESPES V0AVIS-PRECED V0AVIS-VLPRMLIQ V0AVIS-VLPRMTOT */
            _.Move(0, V0AVIS_VLIOCC, V0AVIS_VLDESPES, V0AVIS_PRECED, V0AVIS_VLPRMLIQ, V0AVIS_VLPRMTOT);

            /*" -3230- MOVE '0' TO V0AVIS-SITCONTB */
            _.Move("0", V0AVIS_SITCONTB);

            /*" -3231- MOVE ZEROS TO V0AVIS-CODEMP */
            _.Move(0, V0AVIS_CODEMP);

            /*" -3232- MOVE WWORK-ORIGAVISO TO V0AVIS-ORIGAVISO */
            _.Move(WS_AUX_AVISO.WWORK_ORIGAVISO, V0AVIS_ORIGAVISO);

            /*" -3234- MOVE ZEROS TO V0AVIS-VALADT. */
            _.Move(0, V0AVIS_VALADT);

            /*" -3242- MOVE ZEROS TO VIND-CODEMP VIND-ORIGAVISO VIND-VALADT. */
            _.Move(0, VIND_CODEMP, VIND_ORIGAVISO, VIND_VALADT);

            /*" -3243- MOVE V0AVIS-CODEMP TO V0SALD-CODEMP */
            _.Move(V0AVIS_CODEMP, V0SALD_CODEMP);

            /*" -3244- MOVE V0AVIS-BCOAVISO TO V0SALD-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0SALD_BCOAVISO);

            /*" -3245- MOVE V0AVIS-AGEAVISO TO V0SALD-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0SALD_AGEAVISO);

            /*" -3246- MOVE '1' TO V0SALD-TIPSGU */
            _.Move("1", V0SALD_TIPSGU);

            /*" -3247- MOVE V0AVIS-NRAVISO TO V0SALD-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0SALD_NRAVISO);

            /*" -3248- MOVE V0AVIS-DTAVISO TO V0SALD-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0SALD_DTAVISO);

            /*" -3249- MOVE V0AVIS-DTMOVTO TO V0SALD-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0SALD_DTMOVTO);

            /*" -3250- MOVE '0' TO V0SALD-SITUACAO */
            _.Move("0", V0SALD_SITUACAO);

            /*" -3252- MOVE ZEROS TO V0SALD-SDOATU AD-QTDEBIL AD-VLRABIL. */
            _.Move(0, V0SALD_SDOATU, WS_AUX_ARQUIVO.AD_QTDEBIL, WS_AUX_ARQUIVO.AD_VLRABIL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-V0AVISOCRED-SECTION */
        private void R2500_00_SELECT_V0AVISOCRED_SECTION()
        {
            /*" -3265- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3273- PERFORM R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1 */

            R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1();

            /*" -3277- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3278- MOVE ZEROS TO V0AVIS-COUNT */
                _.Move(0, V0AVIS_COUNT);

                /*" -3279- ELSE */
            }
            else
            {


                /*" -3280- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3281- DISPLAY 'R2500-00 - PROBLEMAS NO SELECT(V0AVISOCRED)' */
                    _.Display($"R2500-00 - PROBLEMAS NO SELECT(V0AVISOCRED)");

                    /*" -3282- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3283- ELSE */
                }
                else
                {


                    /*" -3284- IF VIND-COUNT LESS ZEROS */

                    if (VIND_COUNT < 00)
                    {

                        /*" -3284- MOVE ZEROS TO V0AVIS-COUNT. */
                        _.Move(0, V0AVIS_COUNT);
                    }

                }

            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-V0AVISOCRED-DB-SELECT-1 */
        public void R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1()
        {
            /*" -3273- EXEC SQL SELECT COUNT(*) INTO :V0AVIS-COUNT:VIND-COUNT FROM SEGUROS.V0AVISOCRED WHERE AGEAVISO = :V0AVIS-AGEAVISO AND NRAVISO = :V0AVIS-NRAVISO AND NRSEQ = :V0AVIS-NRSEQ WITH UR END-EXEC. */

            var r2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1 = new R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1()
            {
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0AVIS_NRSEQ = V0AVIS_NRSEQ.ToString(),
            };

            var executed_1 = R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1.Execute(r2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AVIS_COUNT, V0AVIS_COUNT);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-PROCESSA-RCAP-SECTION */
        private void R2600_00_PROCESSA_RCAP_SECTION()
        {
            /*" -3297- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3305- MOVE 'N' TO FLG-GRAFICA FLG-MALA. */
            _.Move("N", WS_AUX_ARQUIVO.FLG_GRAFICA, WS_AUX_ARQUIVO.FLG_MALA);

            /*" -3306- MOVE ZEROS TO WSHOST-CODPRODU */
            _.Move(0, WSHOST_CODPRODU);

            /*" -3308- MOVE COBRAN-NOSS-NUMERO TO WSHOST-NRCERTIF */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, WSHOST_NRCERTIF);

            /*" -3309- MOVE COBRAN-VLR-PRINC TO WSHOST-VLPRMTOT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, WSHOST_VLPRMTOT);

            /*" -3310- MOVE COBRAN-DESPESAS TO WSHOST-VLTARIFA */
            _.Move(COBRAN_REGISTRO.COBRAN_DESPESAS, WSHOST_VLTARIFA);

            /*" -3311- MOVE COBRAN-ABATIMENTO TO WSHOST-VLBALCAO */
            _.Move(COBRAN_REGISTRO.COBRAN_ABATIMENTO, WSHOST_VLBALCAO);

            /*" -3312- MOVE COBRAN-IOF TO WSHOST-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_IOF, WSHOST_VLIOCC);

            /*" -3313- MOVE COBRAN-DESC-CONCED TO WSHOST-VLDESCON */
            _.Move(COBRAN_REGISTRO.COBRAN_DESC_CONCED, WSHOST_VLDESCON);

            /*" -3319- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -3320- MOVE COBRAN-USO-EMPRESA TO AUX-USO-EMPRESA */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA);

            /*" -3326- MOVE AUX-TITSIVPF TO AUX-APOLICE AUX-TIT-GRAFICA AUX-NRO-SIVPF AUX-NRO-RESSA SIN-NRO-RESSA V0FILT-NUMSIVPF. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, WS_AUX_ARQUIVO.AUX_APOLICE, WS_AUX_ARQUIVO.AUX_TIT_GRAFICA, WS_AUX_ARQUIVO.AUX_NRO_SIVPF, WS_AUX_ARQUIVO.AUX_NRO_RESSA, WS_AUX_ARQUIVO.SIN_NRO_RESSA, V0FILT_NUMSIVPF);

            /*" -3329- MOVE ZEROS TO WWORK-NSO-NUMERO. */
            _.Move(0, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

            /*" -3330- MOVE 'N' TO WTEM-SIES. */
            _.Move("N", WS_AUX_ARQUIVO.WTEM_SIES);

            /*" -3331- PERFORM R2650-00-VERIFICA-SIES. */

            R2650_00_VERIFICA_SIES_SECTION();

            /*" -3332- IF WTEM-SIES EQUAL 'S' */

            if (WS_AUX_ARQUIVO.WTEM_SIES == "S")
            {

                /*" -3333- PERFORM R2680-00-GRAVA-MOVIMCOB */

                R2680_00_GRAVA_MOVIMCOB_SECTION();

                /*" -3340- GO TO R2600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3342- ADD COBRAN-VLR-PRINC TO V0AVIS-VLPRMTOT V0SALD-SDOATU */
            V0AVIS_VLPRMTOT.Value = V0AVIS_VLPRMTOT + COBRAN_REGISTRO.COBRAN_VLR_PRINC;
            V0SALD_SDOATU.Value = V0SALD_SDOATU + COBRAN_REGISTRO.COBRAN_VLR_PRINC;

            /*" -3343- ADD COBRAN-IOF TO V0AVIS-VLIOCC */
            V0AVIS_VLIOCC.Value = V0AVIS_VLIOCC + COBRAN_REGISTRO.COBRAN_IOF;

            /*" -3344- ADD COBRAN-DESPESAS TO V0AVIS-VLDESPES */
            V0AVIS_VLDESPES.Value = V0AVIS_VLDESPES + COBRAN_REGISTRO.COBRAN_DESPESAS;

            /*" -3347- ADD COBRAN-ABATIMENTO TO V0AVIS-VLDESPES. */
            V0AVIS_VLDESPES.Value = V0AVIS_VLDESPES + COBRAN_REGISTRO.COBRAN_ABATIMENTO;

            /*" -3350- IF COBRAN-CODEMPRESA EQUAL 630870000000628 OR 630870000000725 OR 630870000003201 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA.In("630870000000628", "630870000000725", "630870000003201"))
            {

                /*" -3351- PERFORM R3200-00-TRATA-DEMAIS-PARCELAS */

                R3200_00_TRATA_DEMAIS_PARCELAS_SECTION();

                /*" -3354- GO TO R2600-90-DESPESAS. */

                R2600_90_DESPESAS(); //GOTO
                return;
            }


            /*" -3356- IF COBRAN-CODEMPRESA EQUAL 630870000000440 OR COBRAN-CODEMPRESA EQUAL 630870000002825 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000440 || COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000002825)
            {

                /*" -3357- PERFORM R2700-00-TRATA-RESSARCIMENTO */

                R2700_00_TRATA_RESSARCIMENTO_SECTION();

                /*" -3360- GO TO R2600-90-DESPESAS. */

                R2600_90_DESPESAS(); //GOTO
                return;
            }


            /*" -3361- IF COBRAN-TITULO16 EQUAL ZEROS */

            if (COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 == 00)
            {

                /*" -3362- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -3364- MOVE 'COBRANCA SEM TITULO INFORMADO' TO V0MCOB-NOME */
                _.Move("COBRANCA SEM TITULO INFORMADO", V0MCOB_NOME);

                /*" -3366- MOVE ZEROS TO V0FOLL-NRRCAP */
                _.Move(0, V0FOLL_NRRCAP);

                /*" -3367- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -3370- GO TO R2600-90-DESPESAS. */

                R2600_90_DESPESAS(); //GOTO
                return;
            }


            /*" -3372- IF COBRAN-CANAL EQUAL ZEROS AND COBRAN-CODPRODU EQUAL ZEROS */

            if (COBRAN_REGISTRO.COBRAN_CANAL == 00 && COBRAN_REGISTRO.COBRAN_CODPRODU == 00)
            {

                /*" -3373- MOVE 'S' TO FLG-GRAFICA */
                _.Move("S", WS_AUX_ARQUIVO.FLG_GRAFICA);

                /*" -3374- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -3376- MOVE 'TITULO GRAFICA SEM IDENTIFICACAO' TO V0MCOB-NOME */
                _.Move("TITULO GRAFICA SEM IDENTIFICACAO", V0MCOB_NOME);

                /*" -3378- MOVE ZEROS TO V0FOLL-NRRCAP */
                _.Move(0, V0FOLL_NRRCAP);

                /*" -3379- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -3382- GO TO R2600-90-DESPESAS. */

                R2600_90_DESPESAS(); //GOTO
                return;
            }


            /*" -3390- IF COBRAN-CANAL NOT EQUAL ZEROS AND COBRAN-CANAL NOT EQUAL 1 AND COBRAN-CANAL NOT EQUAL 2 AND COBRAN-CANAL NOT EQUAL 3 AND COBRAN-CANAL NOT EQUAL 5 AND COBRAN-CANAL NOT EQUAL 6 AND COBRAN-CANAL NOT EQUAL 8 AND COBRAN-CANAL NOT EQUAL 9 */

            if (COBRAN_REGISTRO.COBRAN_CANAL != 00 && COBRAN_REGISTRO.COBRAN_CANAL != 1 && COBRAN_REGISTRO.COBRAN_CANAL != 2 && COBRAN_REGISTRO.COBRAN_CANAL != 3 && COBRAN_REGISTRO.COBRAN_CANAL != 5 && COBRAN_REGISTRO.COBRAN_CANAL != 6 && COBRAN_REGISTRO.COBRAN_CANAL != 8 && COBRAN_REGISTRO.COBRAN_CANAL != 9)
            {

                /*" -3391- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -3393- MOVE 'CANAL DE VENDA NAO PREVISTO  ' TO V0MCOB-NOME */
                _.Move("CANAL DE VENDA NAO PREVISTO  ", V0MCOB_NOME);

                /*" -3395- MOVE ZEROS TO V0FOLL-NRRCAP */
                _.Move(0, V0FOLL_NRRCAP);

                /*" -3396- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -3401- GO TO R2600-90-DESPESAS. */

                R2600_90_DESPESAS(); //GOTO
                return;
            }


            /*" -3402- MOVE 1 TO V0FILT-CODEMP */
            _.Move(1, V0FILT_CODEMP);

            /*" -3403- MOVE AUX-PRDSIVPF TO V0FILT-CODSIVPF */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.AUX_PRDSIVPF, V0FILT_CODSIVPF);

            /*" -3404- MOVE CONVEN-AGECOBR TO V0FILT-AGECOBR */
            _.Move(WS_AUX_ARQUIVO.CONVEN_AGECOBR, V0FILT_AGECOBR);

            /*" -3405- MOVE V0SIST-DTMOVABE TO V0FILT-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0FILT_DTMOVTO);

            /*" -3406- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -3407- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -3408- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -3409- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -3410- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -3411- MOVE WDATA-TABELA TO V0FILT-DTQITBCO */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0FILT_DTQITBCO);

            /*" -3412- MOVE COBRAN-VLR-PRINC TO V0FILT-VLRCAP */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0FILT_VLRCAP);

            /*" -3414- MOVE 'PF0002B' TO V0FILT-CODUSU. */
            _.Move("PF0002B", V0FILT_CODUSU);

            /*" -3416- MOVE ZEROS TO V1RCAP-NRTIT. */
            _.Move(0, V1RCAP_NRTIT);

            /*" -3423- IF COBRAN-CANAL EQUAL 1 OR 2 OR 3 OR 5 OR 6 OR 8 OR 9 */

            if (COBRAN_REGISTRO.COBRAN_CANAL.In("1", "2", "3", "5", "6", "8", "9"))
            {

                /*" -3424- PERFORM R2800-00-LER-CONVERSAO */

                R2800_00_LER_CONVERSAO_SECTION();

                /*" -3425- IF V0FILT-COUNT NOT EQUAL ZEROS */

                if (V0FILT_COUNT != 00)
                {

                    /*" -3427- MOVE CONVSICOB-NR-SICOB TO V0RCAP-NRTIT WWORK-NSO-NUMERO */
                    _.Move(CONVSICOB_NR_SICOB, V0RCAP_NRTIT, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

                    /*" -3428- PERFORM R3710-00-SELECT-V1RCAP */

                    R3710_00_SELECT_V1RCAP_SECTION();

                    /*" -3429- IF V1RCAP-NRTIT EQUAL 9999999 */

                    if (V1RCAP_NRTIT == 9999999)
                    {

                        /*" -3430- MOVE '1' TO V0FOLL-CDERRO02 */
                        _.Move("1", V0FOLL_CDERRO02);

                        /*" -3432- MOVE 'TITULO DUPLICADO CONVERSAO' TO V0MCOB-NOME */
                        _.Move("TITULO DUPLICADO CONVERSAO", V0MCOB_NOME);

                        /*" -3433- MOVE ZEROS TO V0FOLL-NRRCAP */
                        _.Move(0, V0FOLL_NRRCAP);

                        /*" -3434- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                        R3900_00_MONTA_V0FOLLOWUP_SECTION();

                        /*" -3435- GO TO R2600-90-DESPESAS */

                        R2600_90_DESPESAS(); //GOTO
                        return;

                        /*" -3437- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -3438- ELSE */
                    }

                }
                else
                {


                    /*" -3439- PERFORM R3000-00-TRATA-SIVPF */

                    R3000_00_TRATA_SIVPF_SECTION();

                    /*" -3440- ELSE */
                }

            }
            else
            {


                /*" -3441- MOVE 'S' TO FLG-GRAFICA */
                _.Move("S", WS_AUX_ARQUIVO.FLG_GRAFICA);

                /*" -3442- MOVE AUX-NUM-GRAFICA TO WWORK-NSO-NUMERO */
                _.Move(WS_AUX_ARQUIVO.FILLER_6.AUX_NUM_GRAFICA, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

                /*" -3444- MOVE COBRAN-CODPRODU TO CONVEN-CODPRODU WSHOST-CODPRODU */
                _.Move(COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                /*" -3445- IF COBRAN-CODPRODU EQUAL 8201 */

                if (COBRAN_REGISTRO.COBRAN_CODPRODU == 8201)
                {

                    /*" -3448- MOVE 8202 TO COBRAN-CODPRODU CONVEN-CODPRODU WSHOST-CODPRODU */
                    _.Move(8202, COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                    /*" -3449- ELSE */
                }
                else
                {


                    /*" -3451- IF COBRAN-CODPRODU EQUAL 7106 OR 7108 */

                    if (COBRAN_REGISTRO.COBRAN_CODPRODU.In("7106", "7108"))
                    {

                        /*" -3455- MOVE 1402 TO COBRAN-CODPRODU CONVEN-CODPRODU WSHOST-CODPRODU. */
                        _.Move(1402, COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);
                    }

                }

            }


            /*" -3457- IF COBRAN-TITULO16(2:1) EQUAL 2 AND V0PRPF-CODSIVPF NOT EQUAL 48 */

            if (COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16.Substring(2, 1) == 2 && V0PRPF_CODSIVPF != 48)
            {

                /*" -3460- MOVE COBRAN-TITULO16(3:4) TO COBRAN-CODPRODU CONVEN-CODPRODU WSHOST-CODPRODU. */
                _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16.Substring(3, 4), COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);
            }


            /*" -3461- MOVE WWORK-NRRCAP TO V0RCAP-NRRCAP */
            _.Move(WS_AUX_ARQUIVO.FILLER_2.WWORK_NRRCAP, V0RCAP_NRRCAP);

            /*" -3463- MOVE COBRAN-VLR-PRINC TO V0RCAP-VLRCAP V0RCAP-VALPRI */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0RCAP_VLRCAP, V0RCAP_VALPRI);

            /*" -3464- MOVE WWORK-NSO-NUMERO TO V0RCAP-NRTIT */
            _.Move(WS_AUX_ARQUIVO.WWORK_NSO_NUMERO, V0RCAP_NRTIT);

            /*" -3466- MOVE CONVEN-CODPRODU TO V0RCAP-CODPRODU */
            _.Move(WS_AUX_ARQUIVO.CONVEN_CODPRODU, V0RCAP_CODPRODU);

            /*" -3468- MOVE AUX-TITSIVPF TO V0RCAP-NRCERTIF. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0RCAP_NRCERTIF);

            /*" -3470- PERFORM R3700-00-INSERT-V0RCAP. */

            R3700_00_INSERT_V0RCAP_SECTION();

            /*" -3471- IF V1RCAP-NRTIT EQUAL 9999999 */

            if (V1RCAP_NRTIT == 9999999)
            {

                /*" -3472- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -3474- MOVE 'TITULO DUPLICADO RCAP     ' TO V0MCOB-NOME */
                _.Move("TITULO DUPLICADO RCAP     ", V0MCOB_NOME);

                /*" -3476- MOVE WWORK-NRRCAP TO V0FOLL-NRRCAP */
                _.Move(WS_AUX_ARQUIVO.FILLER_2.WWORK_NRRCAP, V0FOLL_NRRCAP);

                /*" -3477- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -3480- GO TO R2600-90-DESPESAS. */

                R2600_90_DESPESAS(); //GOTO
                return;
            }


            /*" -3482- PERFORM R3750-00-INSERT-V0RCAPCOMP. */

            R3750_00_INSERT_V0RCAPCOMP_SECTION();

            /*" -3489- IF COBRAN-CANAL EQUAL 1 OR 2 OR 3 OR 5 OR 6 OR 8 OR 9 */

            if (COBRAN_REGISTRO.COBRAN_CANAL.In("1", "2", "3", "5", "6", "8", "9"))
            {

                /*" -3490- IF V0FILT-COUNT EQUAL ZEROS */

                if (V0FILT_COUNT == 00)
                {

                    /*" -3491- PERFORM R3800-00-INSERT-CONVERSAO */

                    R3800_00_INSERT_CONVERSAO_SECTION();

                    /*" -3496- ELSE */
                }
                else
                {


                    /*" -3499- PERFORM R3950-00-UPDATE-CONVERSAO. */

                    R3950_00_UPDATE_CONVERSAO_SECTION();
                }

            }


            /*" -3500- IF COBRAN-CODEMPRESA EQUAL 630870000000113 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000113)
            {

                /*" -3505- PERFORM R6000-00-TRATA-BILHETES. */

                R6000_00_TRATA_BILHETES_SECTION();
            }


            /*" -3508- IF COBRAN-CODEMPRESA EQUAL 630870000000326 OR COBRAN-CODEMPRESA EQUAL 630870000000601 OR COBRAN-CODEMPRESA EQUAL 630870000003198 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000326 || COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000601 || COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000003198)
            {

                /*" -3511- PERFORM R8800-00-TRATA-AZULCAR. */

                R8800_00_TRATA_AZULCAR_SECTION();
            }


            /*" -3511- PERFORM R6500-00-TARIFA-BALCAO. */

            R6500_00_TARIFA_BALCAO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2600_90_DESPESAS */

            R2600_90_DESPESAS();

        }

        [StopWatch]
        /*" R2600-90-DESPESAS */
        private void R2600_90_DESPESAS(bool isPerform = false)
        {
            /*" -3517- PERFORM R8000-00-TRATA-DESPESAS. */

            R8000_00_TRATA_DESPESAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2650-00-VERIFICA-SIES-SECTION */
        private void R2650_00_VERIFICA_SIES_SECTION()
        {
            /*" -3530- MOVE '2650' TO WNR-EXEC-SQL. */
            _.Move("2650", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3531- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -3532- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -3533- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -3534- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -3537- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC. */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -3540- IF WDATA-TABELA GREATER RELATORI-DATA-REFERENCIA NEXT SENTENCE */

            if (WS_AUX_DATAS.WDATA_TABELA > RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA)
            {

                /*" -3541- ELSE */
            }
            else
            {


                /*" -3547- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3549- IF COBRAN-TITULO16 GREATER 8071000000000000 AND COBRAN-TITULO16 LESS 8072000000000000 */

            if (COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 > 8071000000000000 && COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 < 8072000000000000)
            {

                /*" -3550- MOVE 'S' TO WTEM-SIES */
                _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);

                /*" -3595- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3598- IF COBRAN-CODEMPRESA EQUAL 0630870000002671 OR 0630870000002680 OR 0630870000002698 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA.In("0630870000002671", "0630870000002680", "0630870000002698"))
            {

                /*" -3599- MOVE 'S' TO WTEM-SIES */
                _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);

                /*" -3600- GO TO R2650-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;

                /*" -3601- ELSE */
            }
            else
            {


                /*" -3602- IF AUX-CANAL NOT EQUAL ZEROS */

                if (WS_AUX_ARQUIVO.FILLER_8.AUX_CANAL != 00)
                {

                    /*" -3606- IF AUX-PRDSIVPF EQUAL 10 OR 50 OR 71 OR 72 */

                    if (WS_AUX_ARQUIVO.FILLER_8.AUX_PRDSIVPF.In("10", "50", "71", "72"))
                    {

                        /*" -3607- MOVE 'S' TO WTEM-SIES */
                        _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);

                        /*" -3608- GO TO R2650-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                        return;

                        /*" -3609- ELSE */
                    }
                    else
                    {


                        /*" -3610- GO TO R2650-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                        return;

                        /*" -3611- ELSE */
                    }

                }
                else
                {


                    /*" -3613- IF COBRAN-CODPRODU EQUAL 1403 OR 1404 */

                    if (COBRAN_REGISTRO.COBRAN_CODPRODU.In("1403", "1404"))
                    {

                        /*" -3614- PERFORM R2670-00-SELECT-RENOVACAO */

                        R2670_00_SELECT_RENOVACAO_SECTION();

                        /*" -3615- ELSE */
                    }
                    else
                    {


                        /*" -3622- IF COBRAN-CODPRODU EQUAL 1402 OR 1403 OR 1404 OR 1405 OR 1804 OR 1802 OR 7114 */

                        if (COBRAN_REGISTRO.COBRAN_CODPRODU.In("1402", "1403", "1404", "1405", "1804", "1802", "7114"))
                        {

                            /*" -3622- MOVE 'S' TO WTEM-SIES. */
                            _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2670-00-SELECT-RENOVACAO-SECTION */
        private void R2670_00_SELECT_RENOVACAO_SECTION()
        {
            /*" -3634- MOVE '2670' TO WNR-EXEC-SQL. */
            _.Move("2670", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3637- MOVE AUX-TITSIVPF TO MR028-NUM-TITULO. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, MR028.DCLMR_PROP_RENOVACAO.MR028_NUM_TITULO);

            /*" -3646- PERFORM R2670_00_SELECT_RENOVACAO_DB_SELECT_1 */

            R2670_00_SELECT_RENOVACAO_DB_SELECT_1();

            /*" -3650- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -3651- DISPLAY 'R2670-00 - PROBLEMAS NO SELECT(PROPOSTAS)' */
                _.Display($"R2670-00 - PROBLEMAS NO SELECT(PROPOSTAS)");

                /*" -3654- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3656- IF SQLCODE EQUAL ZEROS AND PROPOSTA-DATA-INIVIGENCIA LESS '2009-10-01' */

            if (DB.SQLCODE == 00 && PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA < "2009-10-01")
            {

                /*" -3657- MOVE 'N' TO WTEM-SIES */
                _.Move("N", WS_AUX_ARQUIVO.WTEM_SIES);

                /*" -3658- ELSE */
            }
            else
            {


                /*" -3658- MOVE 'S' TO WTEM-SIES. */
                _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);
            }


        }

        [StopWatch]
        /*" R2670-00-SELECT-RENOVACAO-DB-SELECT-1 */
        public void R2670_00_SELECT_RENOVACAO_DB_SELECT_1()
        {
            /*" -3646- EXEC SQL SELECT B.DATA_INIVIGENCIA INTO :PROPOSTA-DATA-INIVIGENCIA FROM SEGUROS.MR_PROP_RENOVACAO A, SEGUROS.PROPOSTAS B WHERE A.NUM_TITULO = :MR028-NUM-TITULO AND B.COD_FONTE = A.COD_FONTE AND B.NUM_PROPOSTA = A.NUM_PROPOSTA WITH UR END-EXEC. */

            var r2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1 = new R2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1()
            {
                MR028_NUM_TITULO = MR028.DCLMR_PROP_RENOVACAO.MR028_NUM_TITULO.ToString(),
            };

            var executed_1 = R2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1.Execute(r2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOSTA_DATA_INIVIGENCIA, PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2670_99_SAIDA*/

        [StopWatch]
        /*" R2680-00-GRAVA-MOVIMCOB-SECTION */
        private void R2680_00_GRAVA_MOVIMCOB_SECTION()
        {
            /*" -3671- MOVE '2680' TO WNR-EXEC-SQL. */
            _.Move("2680", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3672- MOVE AUX-TITSIVPF TO V0MCOB-NRTIT */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0MCOB_NRTIT);

            /*" -3673- MOVE COBRAN-VLR-PRINC TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0MCOB_VALTIT);

            /*" -3674- MOVE COBRAN-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_IOF, V0MCOB_VLIOCC);

            /*" -3675- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -3680- COMPUTE V0MCOB-VALCDT EQUAL COBRAN-VLR-PRINC - COBRAN-IOF - COBRAN-DESPESAS - COBRAN-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PRINC - COBRAN_REGISTRO.COBRAN_IOF - COBRAN_REGISTRO.COBRAN_DESPESAS - COBRAN_REGISTRO.COBRAN_ABATIMENTO;

            /*" -3681- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -3682- MOVE COBRAN-CODOCORRENC TO V0MCOB-CODMOV */
            _.Move(COBRAN_REGISTRO.COBRAN_CODOCORRENC, V0MCOB_CODMOV);

            /*" -3683- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -3684- MOVE V0AVIS-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(V0AVIS_AGEAVISO, V0MCOB_AGENCIA);

            /*" -3685- MOVE V0AVIS-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0MCOB_NRAVISO);

            /*" -3686- MOVE WWORK-NUMFITA TO V0MCOB-NUMFITA */
            _.Move(WS_AUX_AVISO.WWORK_NUMFITA, V0MCOB_NUMFITA);

            /*" -3687- MOVE V0SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -3690- MOVE ZEROS TO V0MCOB-NUMAPOL V0MCOB-NRENDOS V0MCOB-NRPARCEL */
            _.Move(0, V0MCOB_NUMAPOL, V0MCOB_NRENDOS, V0MCOB_NRPARCEL);

            /*" -3691- MOVE 'SIES' TO V0MCOB-NOME */
            _.Move("SIES", V0MCOB_NOME);

            /*" -3692- MOVE '*' TO V0MCOB-SITUACAO */
            _.Move("*", V0MCOB_SITUACAO);

            /*" -3694- MOVE '*' TO V0MCOB-TIPOMOV. */
            _.Move("*", V0MCOB_TIPOMOV);

            /*" -3695- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -3696- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -3697- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -3698- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -3699- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -3701- MOVE WDATA-TABELA TO V0MCOB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0MCOB_DTQITBCO);

            /*" -3703- MOVE COBRAN-TITULO16 TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16, V0MCOB_NUM_NOSSO_TITULO);

            /*" -3745- PERFORM R2680_00_GRAVA_MOVIMCOB_DB_INSERT_1 */

            R2680_00_GRAVA_MOVIMCOB_DB_INSERT_1();

            /*" -3748- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3749- DISPLAY 'R2680-00 - PROBLEMAS INSERT (V0MOVICOB)  ' */
                _.Display($"R2680-00 - PROBLEMAS INSERT (V0MOVICOB)  ");

                /*" -3749- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2680-00-GRAVA-MOVIMCOB-DB-INSERT-1 */
        public void R2680_00_GRAVA_MOVIMCOB_DB_INSERT_1()
        {
            /*" -3745- EXEC SQL INSERT INTO SEGUROS.V0MOVICOB ( COD_EMPRESA, CODMOV, BANCO, AGENCIA, NRAVISO, NUMFITA, DTMOVTO, DTQITBCO, NRTIT, NUM_APOLICE, NRENDOS, NRPARCEL, VALTIT, VLIOCC, VALCDT, SITUACAO, TIMESTAMP, NOME, TIPO_MOVIMENTO, NUM_NOSSO_TITULO) VALUES (:V0MCOB-CODEMP , :V0MCOB-CODMOV , :V0MCOB-BANCO , :V0MCOB-AGENCIA , :V0MCOB-NRAVISO , :V0MCOB-NUMFITA , :V0MCOB-DTMOVTO , :V0MCOB-DTQITBCO , :V0MCOB-NRTIT , :V0MCOB-NUMAPOL , :V0MCOB-NRENDOS , :V0MCOB-NRPARCEL , :V0MCOB-VALTIT , :V0MCOB-VLIOCC , :V0MCOB-VALCDT , :V0MCOB-SITUACAO , CURRENT TIMESTAMP , :V0MCOB-NOME , :V0MCOB-TIPOMOV , :V0MCOB-NUM-NOSSO-TITULO) END-EXEC. */

            var r2680_00_GRAVA_MOVIMCOB_DB_INSERT_1_Insert1 = new R2680_00_GRAVA_MOVIMCOB_DB_INSERT_1_Insert1()
            {
                V0MCOB_CODEMP = V0MCOB_CODEMP.ToString(),
                V0MCOB_CODMOV = V0MCOB_CODMOV.ToString(),
                V0MCOB_BANCO = V0MCOB_BANCO.ToString(),
                V0MCOB_AGENCIA = V0MCOB_AGENCIA.ToString(),
                V0MCOB_NRAVISO = V0MCOB_NRAVISO.ToString(),
                V0MCOB_NUMFITA = V0MCOB_NUMFITA.ToString(),
                V0MCOB_DTMOVTO = V0MCOB_DTMOVTO.ToString(),
                V0MCOB_DTQITBCO = V0MCOB_DTQITBCO.ToString(),
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
                V0MCOB_NUMAPOL = V0MCOB_NUMAPOL.ToString(),
                V0MCOB_NRENDOS = V0MCOB_NRENDOS.ToString(),
                V0MCOB_NRPARCEL = V0MCOB_NRPARCEL.ToString(),
                V0MCOB_VALTIT = V0MCOB_VALTIT.ToString(),
                V0MCOB_VLIOCC = V0MCOB_VLIOCC.ToString(),
                V0MCOB_VALCDT = V0MCOB_VALCDT.ToString(),
                V0MCOB_SITUACAO = V0MCOB_SITUACAO.ToString(),
                V0MCOB_NOME = V0MCOB_NOME.ToString(),
                V0MCOB_TIPOMOV = V0MCOB_TIPOMOV.ToString(),
                V0MCOB_NUM_NOSSO_TITULO = V0MCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R2680_00_GRAVA_MOVIMCOB_DB_INSERT_1_Insert1.Execute(r2680_00_GRAVA_MOVIMCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2680_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-TRATA-RESSARCIMENTO-SECTION */
        private void R2700_00_TRATA_RESSARCIMENTO_SECTION()
        {
            /*" -3767- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3768- IF COBRAN-CODEMPRESA EQUAL 630870000000440 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000440)
            {

                /*" -3769- MOVE COBRAN-REGISTRO TO REG-PF0002B1 */
                _.Move(COBRAN_REGISTRO, REG_PF0002B1);

                /*" -3772- WRITE REG-PF0002B1. */
                PF0002B1.Write(REG_PF0002B1.GetMoveValues().ToString());
            }


            /*" -3780- MOVE SPACES TO V0FOLL-CDERRO01 V0FOLL-CDERRO02 V0FOLL-CDERRO03 V0FOLL-CDERRO04 V0FOLL-CDERRO05 V0FOLL-CDERRO06. */
            _.Move("", V0FOLL_CDERRO01, V0FOLL_CDERRO02, V0FOLL_CDERRO03, V0FOLL_CDERRO04, V0FOLL_CDERRO05, V0FOLL_CDERRO06);

            /*" -3788- PERFORM R2710-00-SELECT-V0MESTSINI. */

            R2710_00_SELECT_V0MESTSINI_SECTION();

            /*" -3790- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -3791- MOVE COBRAN-NOSS-NUMERO TO V0MCOB-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, V0MCOB_NRTIT);

            /*" -3792- MOVE COBRAN-VLR-PRINC TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0MCOB_VALTIT);

            /*" -3793- MOVE COBRAN-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_IOF, V0MCOB_VLIOCC);

            /*" -3794- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -3799- COMPUTE V0MCOB-VALCDT EQUAL COBRAN-VLR-PRINC - COBRAN-IOF - COBRAN-DESPESAS - COBRAN-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PRINC - COBRAN_REGISTRO.COBRAN_IOF - COBRAN_REGISTRO.COBRAN_DESPESAS - COBRAN_REGISTRO.COBRAN_ABATIMENTO;

            /*" -3800- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -3801- MOVE COBRAN-CODOCORRENC TO V0MCOB-CODMOV */
            _.Move(COBRAN_REGISTRO.COBRAN_CODOCORRENC, V0MCOB_CODMOV);

            /*" -3802- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -3803- MOVE V0AVIS-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(V0AVIS_AGEAVISO, V0MCOB_AGENCIA);

            /*" -3804- MOVE V0AVIS-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0MCOB_NRAVISO);

            /*" -3805- MOVE WWORK-NUMFITA TO V0MCOB-NUMFITA */
            _.Move(WS_AUX_AVISO.WWORK_NUMFITA, V0MCOB_NUMFITA);

            /*" -3806- MOVE V0SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -3808- MOVE AUX-NRENDOS TO V0MCOB-NRENDOS */
            _.Move(WS_AUX_ARQUIVO.AUX_NRENDOS, V0MCOB_NRENDOS);

            /*" -3809- MOVE AUX-NOME TO V0MCOB-NOME */
            _.Move(WS_AUX_ARQUIVO.AUX_NOME, V0MCOB_NOME);

            /*" -3812- MOVE AUX-NRO-PARC TO V0MCOB-NRPARCEL */
            _.Move(WS_AUX_ARQUIVO.FILLER_11.AUX_NRO_PARC, V0MCOB_NRPARCEL);

            /*" -3813- MOVE ' ' TO V0MCOB-SITUACAO */
            _.Move(" ", V0MCOB_SITUACAO);

            /*" -3815- MOVE COBRAN-TITULO16 TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16, V0MCOB_NUM_NOSSO_TITULO);

            /*" -3818- MOVE V0MSIN-NUM-APOL-SINISTRO TO V0MCOB-NUMAPOL */
            _.Move(V0MSIN_NUM_APOL_SINISTRO, V0MCOB_NUMAPOL);

            /*" -3819- MOVE '7' TO V0MCOB-TIPOMOV. */
            _.Move("7", V0MCOB_TIPOMOV);

            /*" -3820- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -3821- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -3822- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -3823- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -3824- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -3827- MOVE WDATA-TABELA TO V0MCOB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0MCOB_DTQITBCO);

            /*" -3833- IF V0FOLL-CDERRO01 NOT EQUAL SPACES OR V0FOLL-CDERRO02 NOT EQUAL SPACES OR V0FOLL-CDERRO03 NOT EQUAL SPACES OR V0FOLL-CDERRO04 NOT EQUAL SPACES OR V0FOLL-CDERRO05 NOT EQUAL SPACES OR V0FOLL-CDERRO06 NOT EQUAL SPACES */

            if (!V0FOLL_CDERRO01.IsEmpty() || !V0FOLL_CDERRO02.IsEmpty() || !V0FOLL_CDERRO03.IsEmpty() || !V0FOLL_CDERRO04.IsEmpty() || !V0FOLL_CDERRO05.IsEmpty() || !V0FOLL_CDERRO06.IsEmpty())
            {

                /*" -3835- MOVE '2' TO V0MCOB-SITUACAO WSHOST-SITUACAO */
                _.Move("2", V0MCOB_SITUACAO, WSHOST_SITUACAO);

                /*" -3837- MOVE ZEROS TO AC-DUPLICA V0FOLL-NRRCAP */
                _.Move(0, WS_AUX_ARQUIVO.AC_DUPLICA, V0FOLL_NRRCAP);

                /*" -3838- PERFORM R4000-00-MONTA-V0FOLLOWUP */

                R4000_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -3841- PERFORM R4100-00-INSERT-V0FOLLOWUP. */

                R4100_00_INSERT_V0FOLLOWUP_SECTION();
            }


            /*" -3884- PERFORM R2700_00_TRATA_RESSARCIMENTO_DB_INSERT_1 */

            R2700_00_TRATA_RESSARCIMENTO_DB_INSERT_1();

            /*" -3887- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3888- DISPLAY 'R2700-00 - PROBLEMAS INSERT (V0MOVICOB)  ' */
                _.Display($"R2700-00 - PROBLEMAS INSERT (V0MOVICOB)  ");

                /*" -3890- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3890- ADD 1 TO IN-COBRANCA. */
            WS_AUX_ARQUIVO.IN_COBRANCA.Value = WS_AUX_ARQUIVO.IN_COBRANCA + 1;

        }

        [StopWatch]
        /*" R2700-00-TRATA-RESSARCIMENTO-DB-INSERT-1 */
        public void R2700_00_TRATA_RESSARCIMENTO_DB_INSERT_1()
        {
            /*" -3884- EXEC SQL INSERT INTO SEGUROS.V0MOVICOB ( COD_EMPRESA, CODMOV, BANCO, AGENCIA, NRAVISO, NUMFITA, DTMOVTO, DTQITBCO, NRTIT, NUM_APOLICE, NRENDOS, NRPARCEL, VALTIT, VLIOCC, VALCDT, SITUACAO, TIMESTAMP, NOME, TIPO_MOVIMENTO, NUM_NOSSO_TITULO) VALUES (:V0MCOB-CODEMP , :V0MCOB-CODMOV , :V0MCOB-BANCO , :V0MCOB-AGENCIA , :V0MCOB-NRAVISO , :V0MCOB-NUMFITA , :V0MCOB-DTMOVTO , :V0MCOB-DTQITBCO , :V0MCOB-NRTIT , :V0MCOB-NUMAPOL , :V0MCOB-NRENDOS , :V0MCOB-NRPARCEL , :V0MCOB-VALTIT , :V0MCOB-VLIOCC , :V0MCOB-VALCDT , :V0MCOB-SITUACAO , CURRENT TIMESTAMP , :V0MCOB-NOME , :V0MCOB-TIPOMOV , :V0MCOB-NUM-NOSSO-TITULO) END-EXEC. */

            var r2700_00_TRATA_RESSARCIMENTO_DB_INSERT_1_Insert1 = new R2700_00_TRATA_RESSARCIMENTO_DB_INSERT_1_Insert1()
            {
                V0MCOB_CODEMP = V0MCOB_CODEMP.ToString(),
                V0MCOB_CODMOV = V0MCOB_CODMOV.ToString(),
                V0MCOB_BANCO = V0MCOB_BANCO.ToString(),
                V0MCOB_AGENCIA = V0MCOB_AGENCIA.ToString(),
                V0MCOB_NRAVISO = V0MCOB_NRAVISO.ToString(),
                V0MCOB_NUMFITA = V0MCOB_NUMFITA.ToString(),
                V0MCOB_DTMOVTO = V0MCOB_DTMOVTO.ToString(),
                V0MCOB_DTQITBCO = V0MCOB_DTQITBCO.ToString(),
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
                V0MCOB_NUMAPOL = V0MCOB_NUMAPOL.ToString(),
                V0MCOB_NRENDOS = V0MCOB_NRENDOS.ToString(),
                V0MCOB_NRPARCEL = V0MCOB_NRPARCEL.ToString(),
                V0MCOB_VALTIT = V0MCOB_VALTIT.ToString(),
                V0MCOB_VLIOCC = V0MCOB_VLIOCC.ToString(),
                V0MCOB_VALCDT = V0MCOB_VALCDT.ToString(),
                V0MCOB_SITUACAO = V0MCOB_SITUACAO.ToString(),
                V0MCOB_NOME = V0MCOB_NOME.ToString(),
                V0MCOB_TIPOMOV = V0MCOB_TIPOMOV.ToString(),
                V0MCOB_NUM_NOSSO_TITULO = V0MCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R2700_00_TRATA_RESSARCIMENTO_DB_INSERT_1_Insert1.Execute(r2700_00_TRATA_RESSARCIMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2710-00-SELECT-V0MESTSINI-SECTION */
        private void R2710_00_SELECT_V0MESTSINI_SECTION()
        {
            /*" -3904- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3907- MOVE COBRAN-TITULO16 TO SI111-NUM-NOSSO-TITULO. */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO);

            /*" -3911- MOVE ZEROS TO AUX-NRENDOS AUX-NRO-PARC V0MSIN-NUM-APOL-SINISTRO. */
            _.Move(0, WS_AUX_ARQUIVO.AUX_NRENDOS, WS_AUX_ARQUIVO.FILLER_11.AUX_NRO_PARC, V0MSIN_NUM_APOL_SINISTRO);

            /*" -3914- MOVE SPACES TO AUX-DESCRICAO. */
            _.Move("", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

            /*" -3930- PERFORM R2710_00_SELECT_V0MESTSINI_DB_SELECT_1 */

            R2710_00_SELECT_V0MESTSINI_DB_SELECT_1();

            /*" -3934- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -3935- DISPLAY 'R2710-00 - PROBLEMAS NO SELECT(MESTSINI)' */
                _.Display($"R2710-00 - PROBLEMAS NO SELECT(MESTSINI)");

                /*" -3938- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3939- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3941- MOVE V0MSIN-ACORDO TO AUX-NRENDOS */
                _.Move(V0MSIN_ACORDO, WS_AUX_ARQUIVO.AUX_NRENDOS);

                /*" -3943- MOVE V0MSIN-NRPARCEL TO AUX-NRO-PARC */
                _.Move(V0MSIN_NRPARCEL, WS_AUX_ARQUIVO.FILLER_11.AUX_NRO_PARC);

                /*" -3944- MOVE V0MSIN-CODPRODU TO WSHOST-CODPRODU */
                _.Move(V0MSIN_CODPRODU, WSHOST_CODPRODU);

                /*" -3947- GO TO R2710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3949- MOVE COBRAN-TITULO16 TO V0MSIN-NUM-APOL-SINISTRO. */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16, V0MSIN_NUM_APOL_SINISTRO);

            /*" -3954- MOVE ZEROS TO WSHOST-CODPRODU AUX-NRENDOS AUX-NRO-PARC. */
            _.Move(0, WSHOST_CODPRODU, WS_AUX_ARQUIVO.AUX_NRENDOS, WS_AUX_ARQUIVO.FILLER_11.AUX_NRO_PARC);

            /*" -3955- IF SQLCODE EQUAL -811 */

            if (DB.SQLCODE == -811)
            {

                /*" -3956- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -3958- MOVE 'TITULO DUPLICADO RESSARC.     ' TO AUX-DESCRICAO */
                _.Move("TITULO DUPLICADO RESSARC.     ", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                /*" -3959- ELSE */
            }
            else
            {


                /*" -3960- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3961- IF COBRAN-TITULO16 EQUAL ZEROS */

                    if (COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 == 00)
                    {

                        /*" -3962- MOVE '1' TO V0FOLL-CDERRO02 */
                        _.Move("1", V0FOLL_CDERRO02);

                        /*" -3964- MOVE 'TITULO NAO INFORMADO BANCO    ' TO AUX-DESCRICAO */
                        _.Move("TITULO NAO INFORMADO BANCO    ", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                        /*" -3965- ELSE */
                    }
                    else
                    {


                        /*" -3966- MOVE '1' TO V0FOLL-CDERRO01 */
                        _.Move("1", V0FOLL_CDERRO01);

                        /*" -3968- MOVE 'TITULO NAO CADASTRADO RESSARC.' TO AUX-DESCRICAO */
                        _.Move("TITULO NAO CADASTRADO RESSARC.", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                        /*" -3969- ELSE */
                    }

                }
                else
                {


                    /*" -3970- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WS_AUX_AVISO.WABEND.WSQLCODE);

                    /*" -3971- DISPLAY 'OUTRAS DIVERGENCIAS  ' WSQLCODE */
                    _.Display($"OUTRAS DIVERGENCIAS  {WS_AUX_AVISO.WABEND.WSQLCODE}");

                    /*" -3973- MOVE 'OUTRAS DIVERGENCIAS RESSARC.  ' TO AUX-DESCRICAO */
                    _.Move("OUTRAS DIVERGENCIAS RESSARC.  ", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                    /*" -3974- DISPLAY 'R2710-00 - PROBLEMAS NO SELECT(MESTSINI)' */
                    _.Display($"R2710-00 - PROBLEMAS NO SELECT(MESTSINI)");

                    /*" -3974- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2710-00-SELECT-V0MESTSINI-DB-SELECT-1 */
        public void R2710_00_SELECT_V0MESTSINI_DB_SELECT_1()
        {
            /*" -3930- EXEC SQL SELECT M.COD_PRODUTO, M.NUM_APOL_SINISTRO, P.NUM_RESSARC , P.NUM_PARCELA INTO :V0MSIN-CODPRODU , :V0MSIN-NUM-APOL-SINISTRO , :V0MSIN-ACORDO , :V0MSIN-NRPARCEL FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SI_RESSARC_PARCELA P WHERE P.NUM_NOSSO_TITULO = :SI111-NUM-NOSSO-TITULO AND P.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND P.COD_OPERACAO = 4000 WITH UR END-EXEC. */

            var r2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 = new R2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1()
            {
                SI111_NUM_NOSSO_TITULO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO.ToString(),
            };

            var executed_1 = R2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1.Execute(r2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MSIN_CODPRODU, V0MSIN_CODPRODU);
                _.Move(executed_1.V0MSIN_NUM_APOL_SINISTRO, V0MSIN_NUM_APOL_SINISTRO);
                _.Move(executed_1.V0MSIN_ACORDO, V0MSIN_ACORDO);
                _.Move(executed_1.V0MSIN_NRPARCEL, V0MSIN_NRPARCEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2740-00-SELECT-V0MESTSINI-SECTION */
        private void R2740_00_SELECT_V0MESTSINI_SECTION()
        {
            /*" -4027- MOVE '2750' TO WNR-EXEC-SQL. */
            _.Move("2750", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4030- MOVE COBRAN-TITULO16 TO SI111-NUM-NOSSO-TITULO. */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO);

            /*" -4034- MOVE ZEROS TO AUX-NRENDOS AUX-NRO-PARC V0MSIN-NUM-APOL-SINISTRO. */
            _.Move(0, WS_AUX_ARQUIVO.AUX_NRENDOS, WS_AUX_ARQUIVO.FILLER_11.AUX_NRO_PARC, V0MSIN_NUM_APOL_SINISTRO);

            /*" -4037- MOVE SPACES TO AUX-DESCRICAO. */
            _.Move("", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

            /*" -4053- PERFORM R2740_00_SELECT_V0MESTSINI_DB_SELECT_1 */

            R2740_00_SELECT_V0MESTSINI_DB_SELECT_1();

            /*" -4057- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -4058- DISPLAY 'R2740-00 - PROBLEMAS NO SELECT(MESTSINI)' */
                _.Display($"R2740-00 - PROBLEMAS NO SELECT(MESTSINI)");

                /*" -4061- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4062- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4063- PERFORM R2750-00-SELECT-V0MESTSINI */

                R2750_00_SELECT_V0MESTSINI_SECTION();

                /*" -4064- ELSE */
            }
            else
            {


                /*" -4066- MOVE V0MSIN-ACORDO TO AUX-NRENDOS */
                _.Move(V0MSIN_ACORDO, WS_AUX_ARQUIVO.AUX_NRENDOS);

                /*" -4068- MOVE V0MSIN-NRPARCEL TO AUX-NRO-PARC */
                _.Move(V0MSIN_NRPARCEL, WS_AUX_ARQUIVO.FILLER_11.AUX_NRO_PARC);

                /*" -4068- MOVE V0MSIN-CODPRODU TO WSHOST-CODPRODU. */
                _.Move(V0MSIN_CODPRODU, WSHOST_CODPRODU);
            }


        }

        [StopWatch]
        /*" R2740-00-SELECT-V0MESTSINI-DB-SELECT-1 */
        public void R2740_00_SELECT_V0MESTSINI_DB_SELECT_1()
        {
            /*" -4053- EXEC SQL SELECT M.CODPRODU, M.NUM_APOL_SINISTRO, P.NUM_RESSARC , P.NUM_PARCELA INTO :V0MSIN-CODPRODU , :V0MSIN-NUM-APOL-SINISTRO , :V0MSIN-ACORDO , :V0MSIN-NRPARCEL FROM SEGUROS.V0MESTSINI M, SEGUROS.SI_RESSARC_PARCELA P WHERE P.NUM_NOSSO_TITULO = :SI111-NUM-NOSSO-TITULO AND P.COD_OPERACAO = 4000 AND M.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO WITH UR END-EXEC. */

            var r2740_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 = new R2740_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1()
            {
                SI111_NUM_NOSSO_TITULO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO.ToString(),
            };

            var executed_1 = R2740_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1.Execute(r2740_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MSIN_CODPRODU, V0MSIN_CODPRODU);
                _.Move(executed_1.V0MSIN_NUM_APOL_SINISTRO, V0MSIN_NUM_APOL_SINISTRO);
                _.Move(executed_1.V0MSIN_ACORDO, V0MSIN_ACORDO);
                _.Move(executed_1.V0MSIN_NRPARCEL, V0MSIN_NRPARCEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2740_99_SAIDA*/

        [StopWatch]
        /*" R2750-00-SELECT-V0MESTSINI-SECTION */
        private void R2750_00_SELECT_V0MESTSINI_SECTION()
        {
            /*" -4083- MOVE '2750' TO WNR-EXEC-SQL. */
            _.Move("2750", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4084- IF SQLCODE EQUAL -811 */

            if (DB.SQLCODE == -811)
            {

                /*" -4085- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -4087- MOVE 'TITULO DUPLICADO RESSARC.     ' TO AUX-DESCRICAO */
                _.Move("TITULO DUPLICADO RESSARC.     ", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                /*" -4088- ELSE */
            }
            else
            {


                /*" -4089- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4090- IF COBRAN-TITULO16 EQUAL ZEROS */

                    if (COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 == 00)
                    {

                        /*" -4091- MOVE '1' TO V0FOLL-CDERRO02 */
                        _.Move("1", V0FOLL_CDERRO02);

                        /*" -4093- MOVE 'TITULO NAO INFORMADO BANCO    ' TO AUX-DESCRICAO */
                        _.Move("TITULO NAO INFORMADO BANCO    ", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                        /*" -4094- ELSE */
                    }
                    else
                    {


                        /*" -4095- MOVE '1' TO V0FOLL-CDERRO01 */
                        _.Move("1", V0FOLL_CDERRO01);

                        /*" -4097- MOVE 'TITULO NAO CADASTRADO RESSARC.' TO AUX-DESCRICAO */
                        _.Move("TITULO NAO CADASTRADO RESSARC.", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                        /*" -4098- ELSE */
                    }

                }
                else
                {


                    /*" -4099- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WS_AUX_AVISO.WABEND.WSQLCODE);

                    /*" -4100- DISPLAY 'OUTRAS DIVERGENCIAS  ' WSQLCODE */
                    _.Display($"OUTRAS DIVERGENCIAS  {WS_AUX_AVISO.WABEND.WSQLCODE}");

                    /*" -4104- MOVE 'OUTRAS DIVERGENCIAS RESSARC.  ' TO AUX-DESCRICAO. */
                    _.Move("OUTRAS DIVERGENCIAS RESSARC.  ", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);
                }

            }


            /*" -4105- MOVE 010 TO SIN-AUX-ORGAO */
            _.Move(010, WS_AUX_ARQUIVO.FILLER_15.SIN_AUX_ORGAO);

            /*" -4106- MOVE SIN-NRO-RAMO TO SIN-AUX-RAMO */
            _.Move(WS_AUX_ARQUIVO.FILLER_13.SIN_NRO_RAMO, WS_AUX_ARQUIVO.FILLER_15.SIN_AUX_RAMO);

            /*" -4107- MOVE ZEROS TO SIN-AUX-ZERO */
            _.Move(0, WS_AUX_ARQUIVO.FILLER_15.SIN_AUX_ZERO);

            /*" -4109- MOVE SIN-NRO-APOL TO SIN-AUX-APOL. */
            _.Move(WS_AUX_ARQUIVO.FILLER_13.SIN_NRO_APOL, WS_AUX_ARQUIVO.FILLER_15.SIN_AUX_APOL);

            /*" -4114- MOVE SIN-APOLICE TO V0MSIN-NUMAPOL V0MSIN-NUM-APOL-SINISTRO. */
            _.Move(WS_AUX_ARQUIVO.SIN_APOLICE, V0MSIN_NUMAPOL, V0MSIN_NUM_APOL_SINISTRO);

            /*" -4120- PERFORM R2750_00_SELECT_V0MESTSINI_DB_SELECT_1 */

            R2750_00_SELECT_V0MESTSINI_DB_SELECT_1();

            /*" -4124- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -4125- DISPLAY 'R2750-00 - PROBLEMAS NO SELECT(MESTSINI)' */
                _.Display($"R2750-00 - PROBLEMAS NO SELECT(MESTSINI)");

                /*" -4128- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4129- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4130- PERFORM R2760-00-SELECT-V0MESTSINI */

                R2760_00_SELECT_V0MESTSINI_SECTION();

                /*" -4131- ELSE */
            }
            else
            {


                /*" -4132- MOVE SIN-APOLICE TO RES-APOLICE */
                _.Move(WS_AUX_ARQUIVO.SIN_APOLICE, WS_AUX_ARQUIVO.RES_APOLICE);

                /*" -4133- IF VIND-CODPRODU LESS ZEROS */

                if (VIND_CODPRODU < 00)
                {

                    /*" -4135- DISPLAY ' PRODUTO AVULSO 2750   ' SI111-NUM-NOSSO-TITULO */
                    _.Display($" PRODUTO AVULSO 2750   {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO}");

                    /*" -4136- MOVE ZEROS TO WSHOST-CODPRODU */
                    _.Move(0, WSHOST_CODPRODU);

                    /*" -4137- ELSE */
                }
                else
                {


                    /*" -4137- MOVE V0MSIN-CODPRODU TO WSHOST-CODPRODU. */
                    _.Move(V0MSIN_CODPRODU, WSHOST_CODPRODU);
                }

            }


        }

        [StopWatch]
        /*" R2750-00-SELECT-V0MESTSINI-DB-SELECT-1 */
        public void R2750_00_SELECT_V0MESTSINI_DB_SELECT_1()
        {
            /*" -4120- EXEC SQL SELECT CODPRODU INTO :V0MSIN-CODPRODU:VIND-CODPRODU FROM SEGUROS.V0MESTSINI WHERE NUM_APOL_SINISTRO = :V0MSIN-NUMAPOL WITH UR END-EXEC. */

            var r2750_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 = new R2750_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1()
            {
                V0MSIN_NUMAPOL = V0MSIN_NUMAPOL.ToString(),
            };

            var executed_1 = R2750_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1.Execute(r2750_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MSIN_CODPRODU, V0MSIN_CODPRODU);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/

        [StopWatch]
        /*" R2760-00-SELECT-V0MESTSINI-SECTION */
        private void R2760_00_SELECT_V0MESTSINI_SECTION()
        {
            /*" -4150- MOVE '2760' TO WNR-EXEC-SQL. */
            _.Move("2760", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4152- MOVE AUX-NRO-APOL TO RES-NUMAPOL. */
            _.Move(WS_AUX_ARQUIVO.FILLER_11.AUX_NRO_APOL, WS_AUX_ARQUIVO.FILLER_12.RES_NUMAPOL);

            /*" -4153- MOVE 010 TO RES-PREAPOL. */
            _.Move(010, WS_AUX_ARQUIVO.FILLER_12.RES_PREAPOL);

            /*" -4158- MOVE RES-APOLICE TO V0MSIN-NUMAPOL V0MSIN-NUM-APOL-SINISTRO. */
            _.Move(WS_AUX_ARQUIVO.RES_APOLICE, V0MSIN_NUMAPOL, V0MSIN_NUM_APOL_SINISTRO);

            /*" -4164- PERFORM R2760_00_SELECT_V0MESTSINI_DB_SELECT_1 */

            R2760_00_SELECT_V0MESTSINI_DB_SELECT_1();

            /*" -4168- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -4169- DISPLAY 'R2760-00 - PROBLEMAS NO SELECT(MESTSINI)' */
                _.Display($"R2760-00 - PROBLEMAS NO SELECT(MESTSINI)");

                /*" -4172- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4173- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4175- MOVE ZEROS TO V0MSIN-NUM-APOL-SINISTRO */
                _.Move(0, V0MSIN_NUM_APOL_SINISTRO);

                /*" -4176- MOVE SIN-APOLICE TO RES-APOLICE */
                _.Move(WS_AUX_ARQUIVO.SIN_APOLICE, WS_AUX_ARQUIVO.RES_APOLICE);

                /*" -4177- MOVE ZEROS TO WSHOST-CODPRODU */
                _.Move(0, WSHOST_CODPRODU);

                /*" -4179- DISPLAY ' PRODUTO AVULSO 2760 A ' SI111-NUM-NOSSO-TITULO */
                _.Display($" PRODUTO AVULSO 2760 A {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO}");

                /*" -4180- ELSE */
            }
            else
            {


                /*" -4181- IF VIND-CODPRODU LESS ZEROS */

                if (VIND_CODPRODU < 00)
                {

                    /*" -4182- MOVE ZEROS TO WSHOST-CODPRODU */
                    _.Move(0, WSHOST_CODPRODU);

                    /*" -4184- DISPLAY ' PRODUTO AVULSO 2760 B ' SI111-NUM-NOSSO-TITULO */
                    _.Display($" PRODUTO AVULSO 2760 B {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO}");

                    /*" -4185- ELSE */
                }
                else
                {


                    /*" -4185- MOVE V0MSIN-CODPRODU TO WSHOST-CODPRODU. */
                    _.Move(V0MSIN_CODPRODU, WSHOST_CODPRODU);
                }

            }


        }

        [StopWatch]
        /*" R2760-00-SELECT-V0MESTSINI-DB-SELECT-1 */
        public void R2760_00_SELECT_V0MESTSINI_DB_SELECT_1()
        {
            /*" -4164- EXEC SQL SELECT CODPRODU INTO :V0MSIN-CODPRODU:VIND-CODPRODU FROM SEGUROS.V0MESTSINI WHERE NUM_APOL_SINISTRO = :V0MSIN-NUMAPOL WITH UR END-EXEC. */

            var r2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 = new R2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1()
            {
                V0MSIN_NUMAPOL = V0MSIN_NUMAPOL.ToString(),
            };

            var executed_1 = R2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1.Execute(r2760_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MSIN_CODPRODU, V0MSIN_CODPRODU);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2760_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-LER-CONVERSAO-SECTION */
        private void R2800_00_LER_CONVERSAO_SECTION()
        {
            /*" -4198- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4199- MOVE ZEROS TO CONVEN-CODPRODU. */
            _.Move(0, WS_AUX_ARQUIVO.CONVEN_CODPRODU);

            /*" -4203- MOVE AUX-PRDSIVPF TO V0PRPF-CODSIVPF. */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.AUX_PRDSIVPF, V0PRPF_CODSIVPF);

            /*" -4204- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -4205- SEARCH WPROD-OCORREPRD */
            for (; WS_PRD < WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -4207- WHEN V0PRPF-CODSIVPF EQUAL WPROD-PRDSIVPF(WS-PRD) */

                if (V0PRPF_CODSIVPF == WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF)
                {


                    /*" -4209- MOVE WPROD-CODPRODU(WS-PRD) TO CONVEN-CODPRODU WSHOST-CODPRODU  END-SEARCH. */
                    break;
                }
            }


            /*" -4213- IF V0PRPF-CODSIVPF EQUAL 33 OR 34 OR 36 OR 38 OR 42 OR 44 OR 45 */

            if (V0PRPF_CODSIVPF.In("33", "34", "36", "38", "42", "44", "45"))
            {

                /*" -4215- MOVE AUX-TITSIVPF TO PROPOAUT-NUM-PROPOSTA-CONV */
                _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV);

                /*" -4217- PERFORM R7050-00-SELECT-PROPOSTA */

                R7050_00_SELECT_PROPOSTA_SECTION();

                /*" -4218- IF WTEM-PROPOSTA EQUAL 'SIM' */

                if (WS_AUX_ARQUIVO.WTEM_PROPOSTA == "SIM")
                {

                    /*" -4220- MOVE PROPOSTA-COD-PRODUTO TO CONVEN-CODPRODU WSHOST-CODPRODU */
                    _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_PRODUTO, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                    /*" -4221- ELSE */
                }
                else
                {


                    /*" -4223- IF COBRAN-CODEMPRESA EQUAL 630870000003198 OR 630870000001011 */

                    if (COBRAN_REGISTRO.COBRAN_CODEMPRESA.In("630870000003198", "630870000001011"))
                    {

                        /*" -4224- IF V0PRPF-CODSIVPF EQUAL 33 */

                        if (V0PRPF_CODSIVPF == 33)
                        {

                            /*" -4226- MOVE 3173 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3173, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4227- END-IF */
                        }


                        /*" -4228- IF V0PRPF-CODSIVPF EQUAL 34 */

                        if (V0PRPF_CODSIVPF == 34)
                        {

                            /*" -4230- MOVE 3172 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3172, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4231- END-IF */
                        }


                        /*" -4232- IF V0PRPF-CODSIVPF EQUAL 36 */

                        if (V0PRPF_CODSIVPF == 36)
                        {

                            /*" -4234- MOVE 3174 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3174, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4235- END-IF */
                        }


                        /*" -4236- IF V0PRPF-CODSIVPF EQUAL 38 */

                        if (V0PRPF_CODSIVPF == 38)
                        {

                            /*" -4238- MOVE 3175 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3175, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4239- END-IF */
                        }


                        /*" -4240- IF V0PRPF-CODSIVPF EQUAL 42 */

                        if (V0PRPF_CODSIVPF == 42)
                        {

                            /*" -4242- MOVE 3176 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3176, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4243- END-IF */
                        }


                        /*" -4244- IF V0PRPF-CODSIVPF EQUAL 44 */

                        if (V0PRPF_CODSIVPF == 44)
                        {

                            /*" -4246- MOVE 3180 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3180, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4247- END-IF */
                        }


                        /*" -4248- IF V0PRPF-CODSIVPF EQUAL 45 */

                        if (V0PRPF_CODSIVPF == 45)
                        {

                            /*" -4250- MOVE 3181 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3181, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4251- END-IF */
                        }


                        /*" -4252- END-IF */
                    }


                    /*" -4254- IF COBRAN-CODEMPRESA EQUAL 630870000000601 OR 630870000000610 */

                    if (COBRAN_REGISTRO.COBRAN_CODEMPRESA.In("630870000000601", "630870000000610"))
                    {

                        /*" -4255- IF V0PRPF-CODSIVPF EQUAL 33 */

                        if (V0PRPF_CODSIVPF == 33)
                        {

                            /*" -4257- MOVE 5303 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(5303, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4258- END-IF */
                        }


                        /*" -4259- IF V0PRPF-CODSIVPF EQUAL 34 */

                        if (V0PRPF_CODSIVPF == 34)
                        {

                            /*" -4260- CONTINUE */

                            /*" -4261- END-IF */
                        }


                        /*" -4262- IF V0PRPF-CODSIVPF EQUAL 36 */

                        if (V0PRPF_CODSIVPF == 36)
                        {

                            /*" -4263- CONTINUE */

                            /*" -4264- END-IF */
                        }


                        /*" -4265- IF V0PRPF-CODSIVPF EQUAL 38 */

                        if (V0PRPF_CODSIVPF == 38)
                        {

                            /*" -4266- CONTINUE */

                            /*" -4267- END-IF */
                        }


                        /*" -4268- IF V0PRPF-CODSIVPF EQUAL 42 */

                        if (V0PRPF_CODSIVPF == 42)
                        {

                            /*" -4270- MOVE 5302 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(5302, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4271- END-IF */
                        }


                        /*" -4272- IF V0PRPF-CODSIVPF EQUAL 44 OR 45 */

                        if (V0PRPF_CODSIVPF.In("44", "45"))
                        {

                            /*" -4273- CONTINUE */

                            /*" -4274- END-IF */
                        }


                        /*" -4275- END-IF */
                    }


                    /*" -4277- END-IF */
                }


                /*" -4297- END-IF. */
            }


            /*" -4298- IF CONVEN-CODPRODU EQUAL 8201 */

            if (WS_AUX_ARQUIVO.CONVEN_CODPRODU == 8201)
            {

                /*" -4300- MOVE 8202 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                _.Move(8202, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                /*" -4301- ELSE */
            }
            else
            {


                /*" -4303- IF CONVEN-CODPRODU EQUAL 7106 OR 7108 */

                if (WS_AUX_ARQUIVO.CONVEN_CODPRODU.In("7106", "7108"))
                {

                    /*" -4311- MOVE 1402 TO CONVEN-CODPRODU WSHOST-CODPRODU. */
                    _.Move(1402, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);
                }

            }


            /*" -4313- IF V0PRPF-CODSIVPF EQUAL 11 OR V0PRPF-CODSIVPF EQUAL 16 */

            if (V0PRPF_CODSIVPF == 11 || V0PRPF_CODSIVPF == 16)
            {

                /*" -4314- ADD 1 TO TT-OPCAO */
                WS_AUX_ARQUIVO.TT_OPCAO.Value = WS_AUX_ARQUIVO.TT_OPCAO + 1;

                /*" -4316- MOVE AUX-TITSIVPF TO OPCPAGVI-NUM-CERTIFICADO */
                _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

                /*" -4325- PERFORM R2850-00-SELECT-OPCPAGVI. */

                R2850_00_SELECT_OPCPAGVI_SECTION();
            }


            /*" -4328- IF AUX-CANAL EQUAL 2 AND V0PRPF-CODSIVPF NOT EQUAL 48 */

            if (WS_AUX_ARQUIVO.FILLER_8.AUX_CANAL == 2 && V0PRPF_CODSIVPF != 48)
            {

                /*" -4330- MOVE AUX-TITSIVPF(2:4) TO V0FILT-CODSIVPF WSHOST-CODPRODU */
                _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF.Substring(2, 4), V0FILT_CODSIVPF, WSHOST_CODPRODU);

                /*" -4334- END-IF. */
            }


            /*" -4335- IF V0PRPF-CODSIVPF EQUAL 9 */

            if (V0PRPF_CODSIVPF == 9)
            {

                /*" -4336- PERFORM R2810-00-SEL-PRODUTO */

                R2810_00_SEL_PRODUTO_SECTION();

                /*" -4338- END-IF. */
            }


            /*" -4339- MOVE AUX-TITSIVPF TO V0FILT-NUMSIVPF */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0FILT_NUMSIVPF);

            /*" -4339- PERFORM R2900-00-SELECT-CONVERSAO. */

            R2900_00_SELECT_CONVERSAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2810-00-SEL-PRODUTO-SECTION */
        private void R2810_00_SEL_PRODUTO_SECTION()
        {
            /*" -4349- MOVE '2810' TO WNR-EXEC-SQL. */
            _.Move("2810", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4359- PERFORM R2810_00_SEL_PRODUTO_DB_SELECT_1 */

            R2810_00_SEL_PRODUTO_DB_SELECT_1();

            /*" -4362- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4363- DISPLAY 'R2810-00 - PROBLEMAS BILHETE_COBERTURA' */
                _.Display($"R2810-00 - PROBLEMAS BILHETE_COBERTURA");

                /*" -4364- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4365- ELSE */
            }
            else
            {


                /*" -4367- MOVE WHOST-CODPRODU TO CONVEN-CODPRODU WSHOST-CODPRODU */
                _.Move(WHOST_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                /*" -4367- END-IF. */
            }


        }

        [StopWatch]
        /*" R2810-00-SEL-PRODUTO-DB-SELECT-1 */
        public void R2810_00_SEL_PRODUTO_DB_SELECT_1()
        {
            /*" -4359- EXEC SQL SELECT MAX(COD_PRODUTO) INTO :WHOST-CODPRODU FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = 0 AND MODALI_COBERTURA = 0 AND RAMO_COBERTURA = 81 AND DATA_TERVIGENCIA = '9999-12-31' AND COD_PRODUTO NOT IN (8105) WITH UR END-EXEC. */

            var r2810_00_SEL_PRODUTO_DB_SELECT_1_Query1 = new R2810_00_SEL_PRODUTO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R2810_00_SEL_PRODUTO_DB_SELECT_1_Query1.Execute(r2810_00_SEL_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CODPRODU, WHOST_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2810_99_SAIDA*/

        [StopWatch]
        /*" R2850-00-SELECT-OPCPAGVI-SECTION */
        private void R2850_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -4377- MOVE '2850' TO WNR-EXEC-SQL. */
            _.Move("2850", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4384- PERFORM R2850_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R2850_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -4388- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -4389- DISPLAY 'R2850-00 - PROBLEMAS NO SELECT(OPCAOVID)' */
                _.Display($"R2850-00 - PROBLEMAS NO SELECT(OPCAOVID)");

                /*" -4392- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4394- ADD 1 TO DP-OPCAO */
                WS_AUX_ARQUIVO.DP_OPCAO.Value = WS_AUX_ARQUIVO.DP_OPCAO + 1;

                /*" -4395- ELSE */
            }
            else
            {


                /*" -4396- IF V0PRPF-CODSIVPF EQUAL 11 */

                if (V0PRPF_CODSIVPF == 11)
                {

                    /*" -4397- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 01 */

                    if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 01)
                    {

                        /*" -4400- MOVE 9318 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                        _.Move(9318, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                        /*" -4401- ELSE */
                    }
                    else
                    {


                        /*" -4402- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 12 */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 12)
                        {

                            /*" -4405- MOVE 9319 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(9319, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4406- ELSE */
                        }
                        else
                        {


                            /*" -4407- ADD 1 TO DP-OPCAO */
                            WS_AUX_ARQUIVO.DP_OPCAO.Value = WS_AUX_ARQUIVO.DP_OPCAO + 1;

                            /*" -4408- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -4409- IF V0PRPF-CODSIVPF EQUAL 16 */

                    if (V0PRPF_CODSIVPF == 16)
                    {

                        /*" -4410- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 01 */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 01)
                        {

                            /*" -4413- MOVE 9322 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(9322, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -4414- ELSE */
                        }
                        else
                        {


                            /*" -4415- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 02 */

                            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 02)
                            {

                                /*" -4418- MOVE 9323 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                _.Move(9323, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                /*" -4419- ELSE */
                            }
                            else
                            {


                                /*" -4420- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 03 */

                                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 03)
                                {

                                    /*" -4423- MOVE 9324 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                    _.Move(9324, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                    /*" -4424- ELSE */
                                }
                                else
                                {


                                    /*" -4425- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 06 */

                                    if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 06)
                                    {

                                        /*" -4428- MOVE 9325 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                        _.Move(9325, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                        /*" -4429- ELSE */
                                    }
                                    else
                                    {


                                        /*" -4430- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 12 */

                                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 12)
                                        {

                                            /*" -4433- MOVE 9326 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                            _.Move(9326, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                            /*" -4434- ELSE */
                                        }
                                        else
                                        {


                                            /*" -4434- ADD 1 TO DP-OPCAO. */
                                            WS_AUX_ARQUIVO.DP_OPCAO.Value = WS_AUX_ARQUIVO.DP_OPCAO + 1;
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R2850-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R2850_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -4384- EXEC SQL SELECT PERI_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2850_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-SELECT-CONVERSAO-SECTION */
        private void R2900_00_SELECT_CONVERSAO_SECTION()
        {
            /*" -4446- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4460- PERFORM R2900_00_SELECT_CONVERSAO_DB_SELECT_1 */

            R2900_00_SELECT_CONVERSAO_DB_SELECT_1();

            /*" -4463- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -4464- MOVE 1 TO V0FILT-COUNT */
                _.Move(1, V0FILT_COUNT);

                /*" -4465- ELSE */
            }
            else
            {


                /*" -4466- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4467- MOVE ZEROS TO V0FILT-COUNT */
                    _.Move(0, V0FILT_COUNT);

                    /*" -4468- ELSE */
                }
                else
                {


                    /*" -4470- DISPLAY 'R2900-00 - PROBLEMAS NO SELECT(CONVERSAO)  ' SQLCODE '  ' V0FILT-NUMSIVPF */

                    $"R2900-00 - PROBLEMAS NO SELECT(CONVERSAO)  {DB.SQLCODE}  {V0FILT_NUMSIVPF}"
                    .Display();

                    /*" -4470- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2900-00-SELECT-CONVERSAO-DB-SELECT-1 */
        public void R2900_00_SELECT_CONVERSAO_DB_SELECT_1()
        {
            /*" -4460- EXEC SQL SELECT NUM_SICOB, AGEPGTO, DATA_QUITACAO, VAL_RCAP, COD_USUARIO INTO :CONVSICOB-NR-SICOB, :CONVSICOB-AGEPGTO, :CONVSICOB-DTQITBCO, :CONVSICOB-VAL-RCAP, :CONVSICOB-COD-USUARIO FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF WITH UR END-EXEC. */

            var r2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 = new R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1()
            {
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
            };

            var executed_1 = R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1.Execute(r2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVSICOB_NR_SICOB, CONVSICOB_NR_SICOB);
                _.Move(executed_1.CONVSICOB_AGEPGTO, CONVSICOB_AGEPGTO);
                _.Move(executed_1.CONVSICOB_DTQITBCO, CONVSICOB_DTQITBCO);
                _.Move(executed_1.CONVSICOB_VAL_RCAP, CONVSICOB_VAL_RCAP);
                _.Move(executed_1.CONVSICOB_COD_USUARIO, CONVSICOB_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-TRATA-SIVPF-SECTION */
        private void R3000_00_TRATA_SIVPF_SECTION()
        {
            /*" -4481- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4483- PERFORM R3100-00-CALCULA-TITULO. */

            R3100_00_CALCULA_TITULO_SECTION();

            /*" -4484- MOVE WWORK-MIN-NRTIT TO V0FILT-NUMSICOB WWORK-NSO-NUMERO. */
            _.Move(WS_AUX_ARQUIVO.WWORK_MIN_NRTIT, V0FILT_NUMSICOB, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-CALCULA-TITULO-SECTION */
        private void R3100_00_CALCULA_TITULO_SECTION()
        {
            /*" -4496- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4497- ADD 1 TO WWORK-MINNRO */
            WS_AUX_ARQUIVO.FILLER_0.WWORK_MINNRO.Value = WS_AUX_ARQUIVO.FILLER_0.WWORK_MINNRO + 1;

            /*" -4500- MOVE WWORK-MINNRO TO LPARM11. */
            _.Move(WS_AUX_ARQUIVO.FILLER_0.WWORK_MINNRO, LPARM11X.LPARM11);

            /*" -4511- COMPUTE WPARM11-AUX = LPARM11-1 * 3 + LPARM11-2 * 2 + LPARM11-3 * 9 + LPARM11-4 * 8 + LPARM11-5 * 7 + LPARM11-6 * 6 + LPARM11-7 * 5 + LPARM11-8 * 4 + LPARM11-9 * 3 + LPARM11-10 * 2. */
            WS_AUX_ARQUIVO.WPARM11_AUX.Value = LPARM11X.FILLER_48.LPARM11_1 * 3 + LPARM11X.FILLER_48.LPARM11_2 * 2 + LPARM11X.FILLER_48.LPARM11_3 * 9 + LPARM11X.FILLER_48.LPARM11_4 * 8 + LPARM11X.FILLER_48.LPARM11_5 * 7 + LPARM11X.FILLER_48.LPARM11_6 * 6 + LPARM11X.FILLER_48.LPARM11_7 * 5 + LPARM11X.FILLER_48.LPARM11_8 * 4 + LPARM11X.FILLER_48.LPARM11_9 * 3 + LPARM11X.FILLER_48.LPARM11_10 * 2;

            /*" -4514- DIVIDE WPARM11-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(WS_AUX_ARQUIVO.WPARM11_AUX, 11, WS_AUX_ARQUIVO.WS_RESULT, WS_AUX_ARQUIVO.WS_RESTO);

            /*" -4515- IF WS-RESTO EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.WS_RESTO == 00)
            {

                /*" -4516- MOVE 0 TO WWORK-MINDIG */
                _.Move(0, WS_AUX_ARQUIVO.FILLER_0.WWORK_MINDIG);

                /*" -4517- ELSE */
            }
            else
            {


                /*" -4521- SUBTRACT WS-RESTO FROM 11 GIVING WWORK-MINDIG. */
                WS_AUX_ARQUIVO.FILLER_0.WWORK_MINDIG.Value = 11 - WS_AUX_ARQUIVO.WS_RESTO;
            }


            /*" -4522- IF WWORK-MIN-NRTIT GREATER WWORK-MAX-NRTIT */

            if (WS_AUX_ARQUIVO.WWORK_MIN_NRTIT > WS_AUX_ARQUIVO.WWORK_MAX_NRTIT)
            {

                /*" -4523- DISPLAY '*- PF0002B - ABEND CONTROLADO -------------*' */
                _.Display($"*- PF0002B - ABEND CONTROLADO -------------*");

                /*" -4524- DISPLAY '*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    *' */
                _.Display($"*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    *");

                /*" -4525- DISPLAY '    ' WWORK-MIN-NRTIT */
                _.Display($"    {WS_AUX_ARQUIVO.WWORK_MIN_NRTIT}");

                /*" -4525- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-TRATA-DEMAIS-PARCELAS-SECTION */
        private void R3200_00_TRATA_DEMAIS_PARCELAS_SECTION()
        {
            /*" -4538- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4540- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -4541- MOVE AUX-TITSIVPF TO V0MCOB-NRTIT */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0MCOB_NRTIT);

            /*" -4542- MOVE COBRAN-VLR-PRINC TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0MCOB_VALTIT);

            /*" -4543- MOVE COBRAN-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_IOF, V0MCOB_VLIOCC);

            /*" -4544- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -4549- COMPUTE V0MCOB-VALCDT EQUAL COBRAN-VLR-PRINC - COBRAN-IOF - COBRAN-DESPESAS - COBRAN-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PRINC - COBRAN_REGISTRO.COBRAN_IOF - COBRAN_REGISTRO.COBRAN_DESPESAS - COBRAN_REGISTRO.COBRAN_ABATIMENTO;

            /*" -4550- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -4551- MOVE COBRAN-CODOCORRENC TO V0MCOB-CODMOV */
            _.Move(COBRAN_REGISTRO.COBRAN_CODOCORRENC, V0MCOB_CODMOV);

            /*" -4552- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -4553- MOVE V0AVIS-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(V0AVIS_AGEAVISO, V0MCOB_AGENCIA);

            /*" -4554- MOVE V0AVIS-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0MCOB_NRAVISO);

            /*" -4555- MOVE WWORK-NUMFITA TO V0MCOB-NUMFITA */
            _.Move(WS_AUX_AVISO.WWORK_NUMFITA, V0MCOB_NUMFITA);

            /*" -4556- MOVE V0SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -4559- MOVE ZEROS TO V0MCOB-NUMAPOL V0MCOB-NRENDOS V0MCOB-NRPARCEL */
            _.Move(0, V0MCOB_NUMAPOL, V0MCOB_NRENDOS, V0MCOB_NRPARCEL);

            /*" -4561- MOVE SPACES TO V0MCOB-NOME V0MCOB-SITUACAO */
            _.Move("", V0MCOB_NOME, V0MCOB_SITUACAO);

            /*" -4563- MOVE '1' TO V0MCOB-TIPOMOV. */
            _.Move("1", V0MCOB_TIPOMOV);

            /*" -4564- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -4565- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -4566- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -4567- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -4568- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -4570- MOVE WDATA-TABELA TO V0MCOB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0MCOB_DTQITBCO);

            /*" -4572- MOVE COBRAN-TITULO16 TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16, V0MCOB_NUM_NOSSO_TITULO);

            /*" -4614- PERFORM R3200_00_TRATA_DEMAIS_PARCELAS_DB_INSERT_1 */

            R3200_00_TRATA_DEMAIS_PARCELAS_DB_INSERT_1();

            /*" -4617- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4618- DISPLAY 'R3200-00 - PROBLEMAS INSERT (V0MOVICOB)  ' */
                _.Display($"R3200-00 - PROBLEMAS INSERT (V0MOVICOB)  ");

                /*" -4620- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4623- ADD 1 TO IN-COBRANCA. */
            WS_AUX_ARQUIVO.IN_COBRANCA.Value = WS_AUX_ARQUIVO.IN_COBRANCA + 1;

            /*" -4623- PERFORM R3250-00-SELECT-V1ENDOSSO. */

            R3250_00_SELECT_V1ENDOSSO_SECTION();

        }

        [StopWatch]
        /*" R3200-00-TRATA-DEMAIS-PARCELAS-DB-INSERT-1 */
        public void R3200_00_TRATA_DEMAIS_PARCELAS_DB_INSERT_1()
        {
            /*" -4614- EXEC SQL INSERT INTO SEGUROS.V0MOVICOB ( COD_EMPRESA, CODMOV, BANCO, AGENCIA, NRAVISO, NUMFITA, DTMOVTO, DTQITBCO, NRTIT, NUM_APOLICE, NRENDOS, NRPARCEL, VALTIT, VLIOCC, VALCDT, SITUACAO, TIMESTAMP, NOME, TIPO_MOVIMENTO, NUM_NOSSO_TITULO) VALUES (:V0MCOB-CODEMP , :V0MCOB-CODMOV , :V0MCOB-BANCO , :V0MCOB-AGENCIA , :V0MCOB-NRAVISO , :V0MCOB-NUMFITA , :V0MCOB-DTMOVTO , :V0MCOB-DTQITBCO , :V0MCOB-NRTIT , :V0MCOB-NUMAPOL , :V0MCOB-NRENDOS , :V0MCOB-NRPARCEL , :V0MCOB-VALTIT , :V0MCOB-VLIOCC , :V0MCOB-VALCDT , :V0MCOB-SITUACAO , CURRENT TIMESTAMP , :V0MCOB-NOME , :V0MCOB-TIPOMOV , :V0MCOB-NUM-NOSSO-TITULO) END-EXEC. */

            var r3200_00_TRATA_DEMAIS_PARCELAS_DB_INSERT_1_Insert1 = new R3200_00_TRATA_DEMAIS_PARCELAS_DB_INSERT_1_Insert1()
            {
                V0MCOB_CODEMP = V0MCOB_CODEMP.ToString(),
                V0MCOB_CODMOV = V0MCOB_CODMOV.ToString(),
                V0MCOB_BANCO = V0MCOB_BANCO.ToString(),
                V0MCOB_AGENCIA = V0MCOB_AGENCIA.ToString(),
                V0MCOB_NRAVISO = V0MCOB_NRAVISO.ToString(),
                V0MCOB_NUMFITA = V0MCOB_NUMFITA.ToString(),
                V0MCOB_DTMOVTO = V0MCOB_DTMOVTO.ToString(),
                V0MCOB_DTQITBCO = V0MCOB_DTQITBCO.ToString(),
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
                V0MCOB_NUMAPOL = V0MCOB_NUMAPOL.ToString(),
                V0MCOB_NRENDOS = V0MCOB_NRENDOS.ToString(),
                V0MCOB_NRPARCEL = V0MCOB_NRPARCEL.ToString(),
                V0MCOB_VALTIT = V0MCOB_VALTIT.ToString(),
                V0MCOB_VLIOCC = V0MCOB_VLIOCC.ToString(),
                V0MCOB_VALCDT = V0MCOB_VALCDT.ToString(),
                V0MCOB_SITUACAO = V0MCOB_SITUACAO.ToString(),
                V0MCOB_NOME = V0MCOB_NOME.ToString(),
                V0MCOB_TIPOMOV = V0MCOB_TIPOMOV.ToString(),
                V0MCOB_NUM_NOSSO_TITULO = V0MCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R3200_00_TRATA_DEMAIS_PARCELAS_DB_INSERT_1_Insert1.Execute(r3200_00_TRATA_DEMAIS_PARCELAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3250-00-SELECT-V1ENDOSSO-SECTION */
        private void R3250_00_SELECT_V1ENDOSSO_SECTION()
        {
            /*" -4635- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4650- PERFORM R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1 */

            R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1();

            /*" -4654- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -4655- DISPLAY 'R3250-00 - PROBLEMAS NO SELECT(PARCELAS)' */
                _.Display($"R3250-00 - PROBLEMAS NO SELECT(PARCELAS)");

                /*" -4658- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4659- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4660- MOVE ZEROS TO WSHOST-CODPRODU */
                _.Move(0, WSHOST_CODPRODU);

                /*" -4661- ELSE */
            }
            else
            {


                /*" -4662- IF VIND-CODPRODU LESS ZEROS */

                if (VIND_CODPRODU < 00)
                {

                    /*" -4663- MOVE ZEROS TO WSHOST-CODPRODU */
                    _.Move(0, WSHOST_CODPRODU);

                    /*" -4664- ELSE */
                }
                else
                {


                    /*" -4665- MOVE V1ENDO-CODPRODU TO WSHOST-CODPRODU */
                    _.Move(V1ENDO_CODPRODU, WSHOST_CODPRODU);

                    /*" -4668- PERFORM R3300-00-SELECT-CBMALPAR. */

                    R3300_00_SELECT_CBMALPAR_SECTION();
                }

            }


            /*" -4669- IF WSHOST-CODPRODU EQUAL ZEROS */

            if (WSHOST_CODPRODU == 00)
            {

                /*" -4669- PERFORM R3400-00-SELECT-V0PROPOSTAVA. */

                R3400_00_SELECT_V0PROPOSTAVA_SECTION();
            }


        }

        [StopWatch]
        /*" R3250-00-SELECT-V1ENDOSSO-DB-SELECT-1 */
        public void R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -4650- EXEC SQL SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , B.CODPRODU INTO :V0PARC-NUMAPOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V1ENDO-CODPRODU:VIND-CODPRODU FROM SEGUROS.V0PARCELA A, SEGUROS.V1ENDOSSO B WHERE A.NRTIT = :V0MCOB-NRTIT AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NRENDOS = A.NRENDOS WITH UR END-EXEC. */

            var r3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 = new R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1.Execute(r3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_NUMAPOL, V0PARC_NUMAPOL);
                _.Move(executed_1.V0PARC_NRENDOS, V0PARC_NRENDOS);
                _.Move(executed_1.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-SELECT-CBMALPAR-SECTION */
        private void R3300_00_SELECT_CBMALPAR_SECTION()
        {
            /*" -4681- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4696- PERFORM R3300_00_SELECT_CBMALPAR_DB_SELECT_1 */

            R3300_00_SELECT_CBMALPAR_DB_SELECT_1();

            /*" -4700- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -4701- DISPLAY 'R3300-00 - PROBLEMAS NO SELECT(CBMALA)' */
                _.Display($"R3300-00 - PROBLEMAS NO SELECT(CBMALA)");

                /*" -4704- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4705- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4706- IF V0MCOB-NRTIT EQUAL V0PARC-NRTIT */

                if (V0MCOB_NRTIT == V0PARC_NRTIT)
                {

                    /*" -4706- MOVE 'S' TO FLG-MALA. */
                    _.Move("S", WS_AUX_ARQUIVO.FLG_MALA);
                }

            }


        }

        [StopWatch]
        /*" R3300-00-SELECT-CBMALPAR-DB-SELECT-1 */
        public void R3300_00_SELECT_CBMALPAR_DB_SELECT_1()
        {
            /*" -4696- EXEC SQL SELECT VALUE(A.NUM_TITULO,0) INTO :V0PARC-NRTIT FROM SEGUROS.CB_MALA_PARCATRASO A WHERE A.NUM_APOLICE = :V0PARC-NUMAPOL AND A.NUM_ENDOSSO = :V0PARC-NRENDOS AND A.NUM_PARCELA = :V0PARC-NRPARCEL AND A.DATA_MOVIMENTO = (SELECT MAX(B.DATA_MOVIMENTO) FROM SEGUROS.CB_MALA_PARCATRASO B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA) WITH UR END-EXEC. */

            var r3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1 = new R3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1()
            {
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_NUMAPOL = V0PARC_NUMAPOL.ToString(),
                V0PARC_NRENDOS = V0PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1.Execute(r3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_NRTIT, V0PARC_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-SELECT-V0PROPOSTAVA-SECTION */
        private void R3400_00_SELECT_V0PROPOSTAVA_SECTION()
        {
            /*" -4718- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4726- PERFORM R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1 */

            R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1();

            /*" -4730- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -4731- DISPLAY 'R3400-00 - PROBLEMAS NO SELECT(PROPOSTAVA)' */
                _.Display($"R3400-00 - PROBLEMAS NO SELECT(PROPOSTAVA)");

                /*" -4734- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4735- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4735- MOVE V1ENDO-CODPRODU TO WSHOST-CODPRODU. */
                _.Move(V1ENDO_CODPRODU, WSHOST_CODPRODU);
            }


        }

        [StopWatch]
        /*" R3400-00-SELECT-V0PROPOSTAVA-DB-SELECT-1 */
        public void R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1()
        {
            /*" -4726- EXEC SQL SELECT B.CODPRODU INTO :V1ENDO-CODPRODU FROM SEGUROS.V0HISTCOBVA A, SEGUROS.V0PROPOSTAVA B WHERE A.NRTIT = :V0MCOB-NRTIT AND B.NRCERTIF = A.NRCERTIF WITH UR END-EXEC. */

            var r3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 = new R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1()
            {
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1.Execute(r3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-INSERT-V0RCAP-SECTION */
        private void R3700_00_INSERT_V0RCAP_SECTION()
        {
            /*" -4748- MOVE '3700' TO WNR-EXEC-SQL. */
            _.Move("3700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4749- MOVE CONVEN-FONTE TO V0RCAP-FONTE */
            _.Move(WS_AUX_ARQUIVO.CONVEN_FONTE, V0RCAP_FONTE);

            /*" -4750- MOVE ZEROS TO V0RCAP-NRPROPOS */
            _.Move(0, V0RCAP_NRPROPOS);

            /*" -4751- MOVE SPACES TO V0RCAP-NOME */
            _.Move("", V0RCAP_NOME);

            /*" -4752- MOVE WWORK-DTAVISO TO V0RCAP-DTCADAST */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0RCAP_DTCADAST);

            /*" -4753- MOVE V0SIST-DTMOVABE TO V0RCAP-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0RCAP_DTMOVTO);

            /*" -4754- MOVE '0' TO V0RCAP-SITUACAO */
            _.Move("0", V0RCAP_SITUACAO);

            /*" -4755- MOVE 110 TO V0RCAP-OPERACAO */
            _.Move(110, V0RCAP_OPERACAO);

            /*" -4759- MOVE ZEROS TO V0RCAP-CODEMP V0RCAP-NUMAPOL V0RCAP-NRENDOS V0RCAP-NRPARCEL */
            _.Move(0, V0RCAP_CODEMP, V0RCAP_NUMAPOL, V0RCAP_NRENDOS, V0RCAP_NRPARCEL);

            /*" -4760- MOVE COBRAN-AGE-COBRAN TO V0RCAP-AGECOBR */
            _.Move(COBRAN_REGISTRO.FILLER_40.COBRAN_AGE_COBRAN, V0RCAP_AGECOBR);

            /*" -4761- MOVE SPACES TO V0RCAP-RECUPERA */
            _.Move("", V0RCAP_RECUPERA);

            /*" -4763- MOVE ZEROS TO V0RCAP-ACRESCIMO. */
            _.Move(0, V0RCAP_ACRESCIMO);

            /*" -4769- MOVE ZEROS TO VIND-CODEMP VIND-NRTIT VIND-CODPRODU VIND-AGECOBR VIND-NRCERTIF. */
            _.Move(0, VIND_CODEMP, VIND_NRTIT, VIND_CODPRODU, VIND_AGECOBR, VIND_NRCERTIF);

            /*" -4778- MOVE -1 TO VIND-NUMAPOL VIND-NRENDOS VIND-NRPARCEL VIND-RECUPERA VIND-ACRESCIMO. */
            _.Move(-1, VIND_NUMAPOL, VIND_NRENDOS, VIND_NRPARCEL, VIND_RECUPERA, VIND_ACRESCIMO);

            /*" -4779- IF V1RCAP-NRTIT EQUAL 9999999 */

            if (V1RCAP_NRTIT == 9999999)
            {

                /*" -4781- GO TO R3700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4783- PERFORM R3710-00-SELECT-V1RCAP. */

            R3710_00_SELECT_V1RCAP_SECTION();

            /*" -4784- IF V1RCAP-NRTIT EQUAL 9999999 */

            if (V1RCAP_NRTIT == 9999999)
            {

                /*" -4786- GO TO R3700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4809- PERFORM R3700_00_INSERT_V0RCAP_DB_INSERT_1 */

            R3700_00_INSERT_V0RCAP_DB_INSERT_1();

            /*" -4814- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4815- MOVE 9999999 TO V1RCAP-NRTIT */
                _.Move(9999999, V1RCAP_NRTIT);

                /*" -4816- GO TO R3700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;

                /*" -4817- ELSE */
            }
            else
            {


                /*" -4818- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4819- DISPLAY 'R3700-00 - PROBLEMAS INSERT (V0RCAP)     ' */
                    _.Display($"R3700-00 - PROBLEMAS INSERT (V0RCAP)     ");

                    /*" -4822- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4822- ADD 1 TO IN-V0RCAP. */
            WS_AUX_ARQUIVO.IN_V0RCAP.Value = WS_AUX_ARQUIVO.IN_V0RCAP + 1;

        }

        [StopWatch]
        /*" R3700-00-INSERT-V0RCAP-DB-INSERT-1 */
        public void R3700_00_INSERT_V0RCAP_DB_INSERT_1()
        {
            /*" -4809- EXEC SQL INSERT INTO SEGUROS.V0RCAP VALUES (:V0RCAP-FONTE , :V0RCAP-NRRCAP , :V0RCAP-NRPROPOS , :V0RCAP-NOME , :V0RCAP-VLRCAP , :V0RCAP-VALPRI , :V0RCAP-DTCADAST , :V0RCAP-DTMOVTO , :V0RCAP-SITUACAO , :V0RCAP-OPERACAO , :V0RCAP-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0RCAP-NUMAPOL:VIND-NUMAPOL , :V0RCAP-NRENDOS:VIND-NRENDOS , :V0RCAP-NRPARCEL:VIND-NRPARCEL , :V0RCAP-NRTIT:VIND-NRTIT , :V0RCAP-CODPRODU:VIND-CODPRODU , :V0RCAP-AGECOBR:VIND-AGECOBR , :V0RCAP-RECUPERA:VIND-RECUPERA , :V0RCAP-ACRESCIMO:VIND-ACRESCIMO, :V0RCAP-NRCERTIF:VIND-NRCERTIF) END-EXEC. */

            var r3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1 = new R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1()
            {
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_NRPROPOS = V0RCAP_NRPROPOS.ToString(),
                V0RCAP_NOME = V0RCAP_NOME.ToString(),
                V0RCAP_VLRCAP = V0RCAP_VLRCAP.ToString(),
                V0RCAP_VALPRI = V0RCAP_VALPRI.ToString(),
                V0RCAP_DTCADAST = V0RCAP_DTCADAST.ToString(),
                V0RCAP_DTMOVTO = V0RCAP_DTMOVTO.ToString(),
                V0RCAP_SITUACAO = V0RCAP_SITUACAO.ToString(),
                V0RCAP_OPERACAO = V0RCAP_OPERACAO.ToString(),
                V0RCAP_CODEMP = V0RCAP_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0RCAP_NUMAPOL = V0RCAP_NUMAPOL.ToString(),
                VIND_NUMAPOL = VIND_NUMAPOL.ToString(),
                V0RCAP_NRENDOS = V0RCAP_NRENDOS.ToString(),
                VIND_NRENDOS = VIND_NRENDOS.ToString(),
                V0RCAP_NRPARCEL = V0RCAP_NRPARCEL.ToString(),
                VIND_NRPARCEL = VIND_NRPARCEL.ToString(),
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
                VIND_NRTIT = VIND_NRTIT.ToString(),
                V0RCAP_CODPRODU = V0RCAP_CODPRODU.ToString(),
                VIND_CODPRODU = VIND_CODPRODU.ToString(),
                V0RCAP_AGECOBR = V0RCAP_AGECOBR.ToString(),
                VIND_AGECOBR = VIND_AGECOBR.ToString(),
                V0RCAP_RECUPERA = V0RCAP_RECUPERA.ToString(),
                VIND_RECUPERA = VIND_RECUPERA.ToString(),
                V0RCAP_ACRESCIMO = V0RCAP_ACRESCIMO.ToString(),
                VIND_ACRESCIMO = VIND_ACRESCIMO.ToString(),
                V0RCAP_NRCERTIF = V0RCAP_NRCERTIF.ToString(),
                VIND_NRCERTIF = VIND_NRCERTIF.ToString(),
            };

            R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1.Execute(r3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R3710-00-SELECT-V1RCAP-SECTION */
        private void R3710_00_SELECT_V1RCAP_SECTION()
        {
            /*" -4834- MOVE '3710' TO WNR-EXEC-SQL. */
            _.Move("3710", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4840- PERFORM R3710_00_SELECT_V1RCAP_DB_SELECT_1 */

            R3710_00_SELECT_V1RCAP_DB_SELECT_1();

            /*" -4844- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4845- DISPLAY 'R3710-00 - PROBLEMAS NO SELECT(V1RCAP)   ' */
                _.Display($"R3710-00 - PROBLEMAS NO SELECT(V1RCAP)   ");

                /*" -4846- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4847- ELSE */
            }
            else
            {


                /*" -4848- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -4849- MOVE 9999999 TO V1RCAP-NRTIT */
                    _.Move(9999999, V1RCAP_NRTIT);

                    /*" -4850- ELSE */
                }
                else
                {


                    /*" -4850- MOVE ZEROS TO V1RCAP-NRTIT. */
                    _.Move(0, V1RCAP_NRTIT);
                }

            }


        }

        [StopWatch]
        /*" R3710-00-SELECT-V1RCAP-DB-SELECT-1 */
        public void R3710_00_SELECT_V1RCAP_DB_SELECT_1()
        {
            /*" -4840- EXEC SQL SELECT NRTIT INTO :V1RCAP-NRTIT FROM SEGUROS.V1RCAP WHERE NRTIT = :V0RCAP-NRTIT WITH UR END-EXEC. */

            var r3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1 = new R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1.Execute(r3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAP_NRTIT, V1RCAP_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3710_99_SAIDA*/

        [StopWatch]
        /*" R3750-00-INSERT-V0RCAPCOMP-SECTION */
        private void R3750_00_INSERT_V0RCAPCOMP_SECTION()
        {
            /*" -4863- MOVE '3750' TO WNR-EXEC-SQL. */
            _.Move("3750", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4864- MOVE V0RCAP-FONTE TO V0RCOM-FONTE */
            _.Move(V0RCAP_FONTE, V0RCOM_FONTE);

            /*" -4865- MOVE V0RCAP-NRRCAP TO V0RCOM-NRRCAP */
            _.Move(V0RCAP_NRRCAP, V0RCOM_NRRCAP);

            /*" -4866- MOVE 0 TO V0RCOM-NRRCAPCO */
            _.Move(0, V0RCOM_NRRCAPCO);

            /*" -4867- MOVE V0RCAP-OPERACAO TO V0RCOM-OPERACAO */
            _.Move(V0RCAP_OPERACAO, V0RCOM_OPERACAO);

            /*" -4868- MOVE V0RCAP-DTMOVTO TO V0RCOM-DTMOVTO */
            _.Move(V0RCAP_DTMOVTO, V0RCOM_DTMOVTO);

            /*" -4870- MOVE V0RCAP-SITUACAO TO V0RCOM-SITUACAO */
            _.Move(V0RCAP_SITUACAO, V0RCOM_SITUACAO);

            /*" -4871- MOVE V0AVIS-BCOAVISO TO V0RCOM-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0RCOM_BCOAVISO);

            /*" -4872- MOVE V0AVIS-AGEAVISO TO V0RCOM-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0RCOM_AGEAVISO);

            /*" -4874- MOVE V0AVIS-NRAVISO TO V0RCOM-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0RCOM_NRAVISO);

            /*" -4875- MOVE V0RCAP-VLRCAP TO V0RCOM-VLRCAP */
            _.Move(V0RCAP_VLRCAP, V0RCOM_VLRCAP);

            /*" -4876- MOVE V0RCAP-DTCADAST TO V0RCOM-DTCADAST */
            _.Move(V0RCAP_DTCADAST, V0RCOM_DTCADAST);

            /*" -4877- MOVE '0' TO V0RCOM-SITCONTB */
            _.Move("0", V0RCOM_SITCONTB);

            /*" -4879- MOVE V0RCAP-CODEMP TO V0RCOM-CODEMP. */
            _.Move(V0RCAP_CODEMP, V0RCOM_CODEMP);

            /*" -4880- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

            /*" -4881- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_HORA);

            /*" -4882- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_2PT1);

            /*" -4883- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_MINU);

            /*" -4884- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_2PT2);

            /*" -4885- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_SEGU);

            /*" -4887- MOVE WTIME-DAYR TO V0RCOM-HORAOPER. */
            _.Move(WS_AUX_DATAS.FILLER_25.WTIME_DAYR, V0RCOM_HORAOPER);

            /*" -4888- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -4889- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -4890- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -4891- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -4892- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -4895- MOVE WDATA-TABELA TO V0RCOM-DATARCAP. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0RCOM_DATARCAP);

            /*" -4913- PERFORM R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -4916- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4917- DISPLAY 'R3750-00 - PROBLEMAS INSERT (V0RCAPCOMP) ' */
                _.Display($"R3750-00 - PROBLEMAS INSERT (V0RCAPCOMP) ");

                /*" -4917- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3750-00-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -4913- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V0RCOM-FONTE , :V0RCOM-NRRCAP , :V0RCOM-NRRCAPCO , :V0RCOM-OPERACAO , :V0RCOM-DTMOVTO , :V0RCOM-HORAOPER , :V0RCOM-SITUACAO , :V0RCOM-BCOAVISO , :V0RCOM-AGEAVISO , :V0RCOM-NRAVISO , :V0RCOM-VLRCAP , :V0RCOM-DATARCAP , :V0RCOM-DTCADAST , :V0RCOM-SITCONTB , :V0RCOM-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP) END-EXEC. */

            var r3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V0RCOM_FONTE = V0RCOM_FONTE.ToString(),
                V0RCOM_NRRCAP = V0RCOM_NRRCAP.ToString(),
                V0RCOM_NRRCAPCO = V0RCOM_NRRCAPCO.ToString(),
                V0RCOM_OPERACAO = V0RCOM_OPERACAO.ToString(),
                V0RCOM_DTMOVTO = V0RCOM_DTMOVTO.ToString(),
                V0RCOM_HORAOPER = V0RCOM_HORAOPER.ToString(),
                V0RCOM_SITUACAO = V0RCOM_SITUACAO.ToString(),
                V0RCOM_BCOAVISO = V0RCOM_BCOAVISO.ToString(),
                V0RCOM_AGEAVISO = V0RCOM_AGEAVISO.ToString(),
                V0RCOM_NRAVISO = V0RCOM_NRAVISO.ToString(),
                V0RCOM_VLRCAP = V0RCOM_VLRCAP.ToString(),
                V0RCOM_DATARCAP = V0RCOM_DATARCAP.ToString(),
                V0RCOM_DTCADAST = V0RCOM_DTCADAST.ToString(),
                V0RCOM_SITCONTB = V0RCOM_SITCONTB.ToString(),
                V0RCOM_CODEMP = V0RCOM_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
            };

            R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_99_SAIDA*/

        [StopWatch]
        /*" R3800-00-INSERT-CONVERSAO-SECTION */
        private void R3800_00_INSERT_CONVERSAO_SECTION()
        {
            /*" -4928- MOVE '3800' TO WNR-EXEC-SQL. */
            _.Move("3800", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4940- PERFORM R3800_00_INSERT_CONVERSAO_DB_INSERT_1 */

            R3800_00_INSERT_CONVERSAO_DB_INSERT_1();

            /*" -4943- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4944- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -4945- PERFORM R3850-00-TRATA-DUPLICI-SICOB */

                    R3850_00_TRATA_DUPLICI_SICOB_SECTION();

                    /*" -4946- ELSE */
                }
                else
                {


                    /*" -4947- DISPLAY 'R3800-00 - PROBLEMAS INSERT (CONVERSAO)  ' */
                    _.Display($"R3800-00 - PROBLEMAS INSERT (CONVERSAO)  ");

                    /*" -4949- DISPLAY '           TITULO......................  ' V0FILT-NUMSIVPF */
                    _.Display($"           TITULO......................  {V0FILT_NUMSIVPF}");

                    /*" -4951- DISPLAY '           SICOB.......................  ' V0FILT-NUMSICOB */
                    _.Display($"           SICOB.......................  {V0FILT_NUMSICOB}");

                    /*" -4953- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4953- ADD 1 TO IN-CONVERSAO. */
            WS_AUX_ARQUIVO.IN_CONVERSAO.Value = WS_AUX_ARQUIVO.IN_CONVERSAO + 1;

        }

        [StopWatch]
        /*" R3800-00-INSERT-CONVERSAO-DB-INSERT-1 */
        public void R3800_00_INSERT_CONVERSAO_DB_INSERT_1()
        {
            /*" -4940- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES (:V0FILT-NUMSIVPF , :V0FILT-NUMSICOB , :V0FILT-CODEMP , :V0FILT-CODSIVPF , :V0FILT-AGECOBR , :V0FILT-DTMOVTO , :V0FILT-DTQITBCO , :V0FILT-VLRCAP , :V0FILT-CODUSU , CURRENT TIMESTAMP) END-EXEC. */

            var r3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1 = new R3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1()
            {
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
                V0FILT_NUMSICOB = V0FILT_NUMSICOB.ToString(),
                V0FILT_CODEMP = V0FILT_CODEMP.ToString(),
                V0FILT_CODSIVPF = V0FILT_CODSIVPF.ToString(),
                V0FILT_AGECOBR = V0FILT_AGECOBR.ToString(),
                V0FILT_DTMOVTO = V0FILT_DTMOVTO.ToString(),
                V0FILT_DTQITBCO = V0FILT_DTQITBCO.ToString(),
                V0FILT_VLRCAP = V0FILT_VLRCAP.ToString(),
                V0FILT_CODUSU = V0FILT_CODUSU.ToString(),
            };

            R3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1.Execute(r3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/

        [StopWatch]
        /*" R3850-00-TRATA-DUPLICI-SICOB-SECTION */
        private void R3850_00_TRATA_DUPLICI_SICOB_SECTION()
        {
            /*" -4964- MOVE '3850' TO WNR-EXEC-SQL. */
            _.Move("3850", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4965- PERFORM R3000-00-TRATA-SIVPF */

            R3000_00_TRATA_SIVPF_SECTION();

            /*" -4966- PERFORM R3800-00-INSERT-CONVERSAO. */

            R3800_00_INSERT_CONVERSAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3850_99_SAIDA*/

        [StopWatch]
        /*" R3900-00-MONTA-V0FOLLOWUP-SECTION */
        private void R3900_00_MONTA_V0FOLLOWUP_SECTION()
        {
            /*" -4977- MOVE '3900' TO WNR-EXEC-SQL. */
            _.Move("3900", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4979- MOVE '2' TO WSHOST-SITUACAO. */
            _.Move("2", WSHOST_SITUACAO);

            /*" -4980- MOVE COBRAN-NOSS-NUMERO TO V0MCOB-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, V0MCOB_NRTIT);

            /*" -4981- MOVE COBRAN-VLR-PRINC TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0MCOB_VALTIT);

            /*" -4982- MOVE COBRAN-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_IOF, V0MCOB_VLIOCC);

            /*" -4983- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -4989- COMPUTE V0MCOB-VALCDT EQUAL COBRAN-VLR-PRINC - COBRAN-IOF - COBRAN-DESPESAS - COBRAN-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PRINC - COBRAN_REGISTRO.COBRAN_IOF - COBRAN_REGISTRO.COBRAN_DESPESAS - COBRAN_REGISTRO.COBRAN_ABATIMENTO;

            /*" -4991- PERFORM R4050-00-INSERT-V0MOVICOB. */

            R4050_00_INSERT_V0MOVICOB_SECTION();

            /*" -4997- MOVE SPACES TO V0FOLL-CDERRO01 V0FOLL-CDERRO03 V0FOLL-CDERRO04 V0FOLL-CDERRO05 V0FOLL-CDERRO06. */
            _.Move("", V0FOLL_CDERRO01, V0FOLL_CDERRO03, V0FOLL_CDERRO04, V0FOLL_CDERRO05, V0FOLL_CDERRO06);

            /*" -4999- MOVE ZEROS TO AC-DUPLICA. */
            _.Move(0, WS_AUX_ARQUIVO.AC_DUPLICA);

            /*" -5000- PERFORM R4000-00-MONTA-V0FOLLOWUP. */

            R4000_00_MONTA_V0FOLLOWUP_SECTION();

            /*" -5000- PERFORM R4100-00-INSERT-V0FOLLOWUP. */

            R4100_00_INSERT_V0FOLLOWUP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_99_SAIDA*/

        [StopWatch]
        /*" R3950-00-UPDATE-CONVERSAO-SECTION */
        private void R3950_00_UPDATE_CONVERSAO_SECTION()
        {
            /*" -5010- MOVE '3950' TO WNR-EXEC-SQL. */
            _.Move("3950", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5011- IF CONVSICOB-AGEPGTO EQUAL ZEROS */

            if (CONVSICOB_AGEPGTO == 00)
            {

                /*" -5013- MOVE V0FILT-AGECOBR TO CONVSICOB-AGEPGTO. */
                _.Move(V0FILT_AGECOBR, CONVSICOB_AGEPGTO);
            }


            /*" -5014- IF CONVSICOB-DTQITBCO EQUAL '0001-01-01' */

            if (CONVSICOB_DTQITBCO == "0001-01-01")
            {

                /*" -5016- MOVE V0FILT-DTQITBCO TO CONVSICOB-DTQITBCO. */
                _.Move(V0FILT_DTQITBCO, CONVSICOB_DTQITBCO);
            }


            /*" -5018- MOVE V0FILT-VLRCAP TO CONVSICOB-VAL-RCAP. */
            _.Move(V0FILT_VLRCAP, CONVSICOB_VAL_RCAP);

            /*" -5024- PERFORM R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1 */

            R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1();

            /*" -5027- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5028- DISPLAY 'R3950-00 - PROBLEMAS UPDATE (CONVERSAO)  ' */
                _.Display($"R3950-00 - PROBLEMAS UPDATE (CONVERSAO)  ");

                /*" -5030- DISPLAY '           PROPOSTA SIVPF..............  ' V0FILT-NUMSIVPF */
                _.Display($"           PROPOSTA SIVPF..............  {V0FILT_NUMSIVPF}");

                /*" -5032- DISPLAY '           SICOB.......................  ' V0FILT-NUMSICOB */
                _.Display($"           SICOB.......................  {V0FILT_NUMSICOB}");

                /*" -5035- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5042- PERFORM R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2 */

            R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2();

            /*" -5045- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -5046- DISPLAY 'R3950-00 - PROBLEMAS UPDATE PROPOSTA FIDELIZ' */
                _.Display($"R3950-00 - PROBLEMAS UPDATE PROPOSTA FIDELIZ");

                /*" -5048- DISPLAY '           PROPOSTA SIVPF..............  ' V0FILT-NUMSIVPF */
                _.Display($"           PROPOSTA SIVPF..............  {V0FILT_NUMSIVPF}");

                /*" -5048- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3950-00-UPDATE-CONVERSAO-DB-UPDATE-1 */
        public void R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1()
        {
            /*" -5024- EXEC SQL UPDATE SEGUROS.CONVERSAO_SICOB SET AGEPGTO = :CONVSICOB-AGEPGTO , DATA_QUITACAO = :CONVSICOB-DTQITBCO , VAL_RCAP = :CONVSICOB-VAL-RCAP WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF END-EXEC. */

            var r3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1 = new R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1()
            {
                CONVSICOB_DTQITBCO = CONVSICOB_DTQITBCO.ToString(),
                CONVSICOB_VAL_RCAP = CONVSICOB_VAL_RCAP.ToString(),
                CONVSICOB_AGEPGTO = CONVSICOB_AGEPGTO.ToString(),
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
            };

            R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1.Execute(r3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3950_99_SAIDA*/

        [StopWatch]
        /*" R3950-00-UPDATE-CONVERSAO-DB-UPDATE-2 */
        public void R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2()
        {
            /*" -5042- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DATA_CREDITO = :V0RCOM-DTMOVTO , AGEPGTO = :CONVSICOB-AGEPGTO , DTQITBCO = :CONVSICOB-DTQITBCO , VAL_PAGO = :CONVSICOB-VAL-RCAP WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF END-EXEC. */

            var r3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1 = new R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1()
            {
                CONVSICOB_DTQITBCO = CONVSICOB_DTQITBCO.ToString(),
                CONVSICOB_VAL_RCAP = CONVSICOB_VAL_RCAP.ToString(),
                CONVSICOB_AGEPGTO = CONVSICOB_AGEPGTO.ToString(),
                V0RCOM_DTMOVTO = V0RCOM_DTMOVTO.ToString(),
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
            };

            R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1.Execute(r3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R4050-00-INSERT-V0MOVICOB-SECTION */
        private void R4050_00_INSERT_V0MOVICOB_SECTION()
        {
            /*" -5059- MOVE '4050' TO WNR-EXEC-SQL. */
            _.Move("4050", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5060- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -5061- MOVE COBRAN-CODOCORRENC TO V0MCOB-CODMOV */
            _.Move(COBRAN_REGISTRO.COBRAN_CODOCORRENC, V0MCOB_CODMOV);

            /*" -5062- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -5063- MOVE V0AVIS-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(V0AVIS_AGEAVISO, V0MCOB_AGENCIA);

            /*" -5064- MOVE V0AVIS-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0MCOB_NRAVISO);

            /*" -5065- MOVE WWORK-NUMFITA TO V0MCOB-NUMFITA */
            _.Move(WS_AUX_AVISO.WWORK_NUMFITA, V0MCOB_NUMFITA);

            /*" -5066- MOVE V0SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -5068- MOVE ZEROS TO V0MCOB-NRENDOS V0MCOB-NRPARCEL */
            _.Move(0, V0MCOB_NRENDOS, V0MCOB_NRPARCEL);

            /*" -5069- MOVE '2' TO V0MCOB-SITUACAO */
            _.Move("2", V0MCOB_SITUACAO);

            /*" -5071- MOVE '1' TO V0MCOB-TIPOMOV. */
            _.Move("1", V0MCOB_TIPOMOV);

            /*" -5072- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -5073- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -5074- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -5075- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -5076- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -5078- MOVE WDATA-TABELA TO V0MCOB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0MCOB_DTQITBCO);

            /*" -5079- IF AUX-APOLICE LESS 10000000000000 */

            if (WS_AUX_ARQUIVO.AUX_APOLICE < 10000000000000)
            {

                /*" -5080- MOVE AUX-APOLICE TO V0MCOB-NUMAPOL */
                _.Move(WS_AUX_ARQUIVO.AUX_APOLICE, V0MCOB_NUMAPOL);

                /*" -5081- ELSE */
            }
            else
            {


                /*" -5083- MOVE AUX-NUMAPOL TO V0MCOB-NUMAPOL. */
                _.Move(WS_AUX_ARQUIVO.FILLER_9.AUX_NUMAPOL, V0MCOB_NUMAPOL);
            }


            /*" -5085- MOVE COBRAN-TITULO16 TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16, V0MCOB_NUM_NOSSO_TITULO);

            /*" -5127- PERFORM R4050_00_INSERT_V0MOVICOB_DB_INSERT_1 */

            R4050_00_INSERT_V0MOVICOB_DB_INSERT_1();

            /*" -5130- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5131- DISPLAY 'R4050-00 - PROBLEMAS INSERT (V0MOVICOB)  ' */
                _.Display($"R4050-00 - PROBLEMAS INSERT (V0MOVICOB)  ");

                /*" -5133- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5133- ADD 1 TO IN-COBRANCA. */
            WS_AUX_ARQUIVO.IN_COBRANCA.Value = WS_AUX_ARQUIVO.IN_COBRANCA + 1;

        }

        [StopWatch]
        /*" R4050-00-INSERT-V0MOVICOB-DB-INSERT-1 */
        public void R4050_00_INSERT_V0MOVICOB_DB_INSERT_1()
        {
            /*" -5127- EXEC SQL INSERT INTO SEGUROS.V0MOVICOB ( COD_EMPRESA, CODMOV, BANCO, AGENCIA, NRAVISO, NUMFITA, DTMOVTO, DTQITBCO, NRTIT, NUM_APOLICE, NRENDOS, NRPARCEL, VALTIT, VLIOCC, VALCDT, SITUACAO, TIMESTAMP, NOME, TIPO_MOVIMENTO, NUM_NOSSO_TITULO) VALUES (:V0MCOB-CODEMP , :V0MCOB-CODMOV , :V0MCOB-BANCO , :V0MCOB-AGENCIA , :V0MCOB-NRAVISO , :V0MCOB-NUMFITA , :V0MCOB-DTMOVTO , :V0MCOB-DTQITBCO , :V0MCOB-NRTIT , :V0MCOB-NUMAPOL , :V0MCOB-NRENDOS , :V0MCOB-NRPARCEL , :V0MCOB-VALTIT , :V0MCOB-VLIOCC , :V0MCOB-VALCDT , :V0MCOB-SITUACAO , CURRENT TIMESTAMP , :V0MCOB-NOME , :V0MCOB-TIPOMOV , :V0MCOB-NUM-NOSSO-TITULO) END-EXEC. */

            var r4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1 = new R4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1()
            {
                V0MCOB_CODEMP = V0MCOB_CODEMP.ToString(),
                V0MCOB_CODMOV = V0MCOB_CODMOV.ToString(),
                V0MCOB_BANCO = V0MCOB_BANCO.ToString(),
                V0MCOB_AGENCIA = V0MCOB_AGENCIA.ToString(),
                V0MCOB_NRAVISO = V0MCOB_NRAVISO.ToString(),
                V0MCOB_NUMFITA = V0MCOB_NUMFITA.ToString(),
                V0MCOB_DTMOVTO = V0MCOB_DTMOVTO.ToString(),
                V0MCOB_DTQITBCO = V0MCOB_DTQITBCO.ToString(),
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
                V0MCOB_NUMAPOL = V0MCOB_NUMAPOL.ToString(),
                V0MCOB_NRENDOS = V0MCOB_NRENDOS.ToString(),
                V0MCOB_NRPARCEL = V0MCOB_NRPARCEL.ToString(),
                V0MCOB_VALTIT = V0MCOB_VALTIT.ToString(),
                V0MCOB_VLIOCC = V0MCOB_VLIOCC.ToString(),
                V0MCOB_VALCDT = V0MCOB_VALCDT.ToString(),
                V0MCOB_SITUACAO = V0MCOB_SITUACAO.ToString(),
                V0MCOB_NOME = V0MCOB_NOME.ToString(),
                V0MCOB_TIPOMOV = V0MCOB_TIPOMOV.ToString(),
                V0MCOB_NUM_NOSSO_TITULO = V0MCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1.Execute(r4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4050_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-MONTA-V0FOLLOWUP-SECTION */
        private void R4000_00_MONTA_V0FOLLOWUP_SECTION()
        {
            /*" -5146- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5147- IF V0MCOB-NUMAPOL EQUAL ZEROS */

            if (V0MCOB_NUMAPOL == 00)
            {

                /*" -5148- MOVE V0MCOB-NRTIT TO V0FOLL-NUMAPOL */
                _.Move(V0MCOB_NRTIT, V0FOLL_NUMAPOL);

                /*" -5149- ELSE */
            }
            else
            {


                /*" -5151- MOVE V0MCOB-NUMAPOL TO V0FOLL-NUMAPOL. */
                _.Move(V0MCOB_NUMAPOL, V0FOLL_NUMAPOL);
            }


            /*" -5152- MOVE V0MCOB-NRENDOS TO V0FOLL-NRENDOS */
            _.Move(V0MCOB_NRENDOS, V0FOLL_NRENDOS);

            /*" -5153- MOVE V0MCOB-NRPARCEL TO V0FOLL-NRPARCEL */
            _.Move(V0MCOB_NRPARCEL, V0FOLL_NRPARCEL);

            /*" -5154- MOVE SPACES TO V0FOLL-DACPARC */
            _.Move("", V0FOLL_DACPARC);

            /*" -5155- MOVE V0MCOB-DTMOVTO TO V0FOLL-DTMOVTO */
            _.Move(V0MCOB_DTMOVTO, V0FOLL_DTMOVTO);

            /*" -5156- MOVE V0MCOB-VALTIT TO V0FOLL-VLPREMIO */
            _.Move(V0MCOB_VALTIT, V0FOLL_VLPREMIO);

            /*" -5157- MOVE V0MCOB-BANCO TO V0FOLL-BCOAVISO */
            _.Move(V0MCOB_BANCO, V0FOLL_BCOAVISO);

            /*" -5158- MOVE V0MCOB-AGENCIA TO V0FOLL-AGEAVISO */
            _.Move(V0MCOB_AGENCIA, V0FOLL_AGEAVISO);

            /*" -5159- MOVE V0MCOB-NRAVISO TO V0FOLL-NRAVISO */
            _.Move(V0MCOB_NRAVISO, V0FOLL_NRAVISO);

            /*" -5160- MOVE 30 TO V0FOLL-CODBAIXA */
            _.Move(30, V0FOLL_CODBAIXA);

            /*" -5161- MOVE '0' TO V0FOLL-SITUACAO */
            _.Move("0", V0FOLL_SITUACAO);

            /*" -5162- MOVE SPACES TO V0FOLL-SITCONTB */
            _.Move("", V0FOLL_SITCONTB);

            /*" -5163- MOVE 103 TO V0FOLL-OPERACAO */
            _.Move(103, V0FOLL_OPERACAO);

            /*" -5164- MOVE SPACES TO V0FOLL-DTLIBER */
            _.Move("", V0FOLL_DTLIBER);

            /*" -5165- MOVE V0MCOB-DTQITBCO TO V0FOLL-DTQITBCO */
            _.Move(V0MCOB_DTQITBCO, V0FOLL_DTQITBCO);

            /*" -5166- MOVE ZEROS TO V0FOLL-CODEMP */
            _.Move(0, V0FOLL_CODEMP);

            /*" -5167- MOVE '1' TO V0FOLL-TIPSGU */
            _.Move("1", V0FOLL_TIPSGU);

            /*" -5168- MOVE ZEROS TO V0FOLL-ORDLIDER */
            _.Move(0, V0FOLL_ORDLIDER);

            /*" -5169- MOVE COBRAN-AGE-COBRAN TO V0FOLL-CODLIDER */
            _.Move(COBRAN_REGISTRO.FILLER_40.COBRAN_AGE_COBRAN, V0FOLL_CODLIDER);

            /*" -5170- MOVE CONVEN-FONTE TO V0FOLL-FONTE */
            _.Move(WS_AUX_ARQUIVO.CONVEN_FONTE, V0FOLL_FONTE);

            /*" -5172- MOVE SPACES TO V0FOLL-APOLIDER. */
            _.Move("", V0FOLL_APOLIDER);

            /*" -5173- MOVE WSHOST-CODPRODU TO AUX-CODPRODU */
            _.Move(WSHOST_CODPRODU, WS_AUX_ARQUIVO.AUX_ENDOSLID.AUX_CODPRODU);

            /*" -5176- MOVE AUX-ENDOSLID TO V0FOLL-ENDOSLID. */
            _.Move(WS_AUX_ARQUIVO.AUX_ENDOSLID, V0FOLL_ENDOSLID);

            /*" -5180- MOVE V0MCOB-NUM-NOSSO-TITULO TO V0FOLL-NUM-NOSSO-TITULO. */
            _.Move(V0MCOB_NUM_NOSSO_TITULO, V0FOLL_NUM_NOSSO_TITULO);

            /*" -5181- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

            /*" -5182- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_HORA);

            /*" -5183- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_2PT1);

            /*" -5184- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_MINU);

            /*" -5185- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_2PT2);

            /*" -5186- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_SEGU);

            /*" -5189- MOVE WTIME-DAYR TO V0FOLL-HORAOPER. */
            _.Move(WS_AUX_DATAS.FILLER_25.WTIME_DAYR, V0FOLL_HORAOPER);

            /*" -5193- MOVE ZEROS TO VIND-CODEMP VIND-TIPSGU VIND-ENDOSLID. */
            _.Move(0, VIND_CODEMP, VIND_TIPSGU, VIND_ENDOSLID);

            /*" -5197- MOVE -1 TO VIND-DTLIBER VIND-ORDLIDER VIND-APOLIDER. */
            _.Move(-1, VIND_DTLIBER, VIND_ORDLIDER, VIND_APOLIDER);

            /*" -5198- IF V0FOLL-CODLIDER NOT EQUAL ZEROS */

            if (V0FOLL_CODLIDER != 00)
            {

                /*" -5199- MOVE ZEROS TO VIND-CODLIDER */
                _.Move(0, VIND_CODLIDER);

                /*" -5200- ELSE */
            }
            else
            {


                /*" -5202- MOVE -1 TO VIND-CODLIDER. */
                _.Move(-1, VIND_CODLIDER);
            }


            /*" -5203- IF V0FOLL-DTQITBCO NOT EQUAL SPACES */

            if (!V0FOLL_DTQITBCO.IsEmpty())
            {

                /*" -5204- MOVE ZEROS TO VIND-DTQITBCO */
                _.Move(0, VIND_DTQITBCO);

                /*" -5205- ELSE */
            }
            else
            {


                /*" -5207- MOVE -1 TO VIND-DTQITBCO. */
                _.Move(-1, VIND_DTQITBCO);
            }


            /*" -5208- IF V0FOLL-FONTE NOT EQUAL ZEROS */

            if (V0FOLL_FONTE != 00)
            {

                /*" -5209- MOVE ZEROS TO VIND-FONTE */
                _.Move(0, VIND_FONTE);

                /*" -5210- ELSE */
            }
            else
            {


                /*" -5212- MOVE -1 TO VIND-FONTE. */
                _.Move(-1, VIND_FONTE);
            }


            /*" -5213- IF V0FOLL-NRRCAP NOT EQUAL ZEROS */

            if (V0FOLL_NRRCAP != 00)
            {

                /*" -5214- MOVE ZEROS TO VIND-NRRCAP */
                _.Move(0, VIND_NRRCAP);

                /*" -5215- ELSE */
            }
            else
            {


                /*" -5215- MOVE -1 TO VIND-NRRCAP. */
                _.Move(-1, VIND_NRRCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-INSERT-V0FOLLOWUP-SECTION */
        private void R4100_00_INSERT_V0FOLLOWUP_SECTION()
        {
            /*" -5228- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5262- PERFORM R4100_00_INSERT_V0FOLLOWUP_DB_INSERT_1 */

            R4100_00_INSERT_V0FOLLOWUP_DB_INSERT_1();

            /*" -5265- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -5266- ADD 1 TO AC-DUPLICA */
                WS_AUX_ARQUIVO.AC_DUPLICA.Value = WS_AUX_ARQUIVO.AC_DUPLICA + 1;

                /*" -5267- IF AC-DUPLICA LESS 10 */

                if (WS_AUX_ARQUIVO.AC_DUPLICA < 10)
                {

                    /*" -5268- PERFORM R4110-00-ADICIONA-TIME */

                    R4110_00_ADICIONA_TIME_SECTION();

                    /*" -5269- GO TO R4100-00-INSERT-V0FOLLOWUP */
                    new Task(() => R4100_00_INSERT_V0FOLLOWUP_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -5270- ELSE */
                }
                else
                {


                    /*" -5275- DISPLAY 'R4100-00 - PROBLEMAS INSERT (V0FOLLOWUP) ' V0FOLL-NUMAPOL '  ' V0FOLL-NRENDOS '  ' V0FOLL-NRPARCEL '  ' V0FOLL-NRAVISO */

                    $"R4100-00 - PROBLEMAS INSERT (V0FOLLOWUP) {V0FOLL_NUMAPOL}  {V0FOLL_NRENDOS}  {V0FOLL_NRPARCEL}  {V0FOLL_NRAVISO}"
                    .Display();

                    /*" -5276- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5277- ELSE */
                }

            }
            else
            {


                /*" -5278- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5283- DISPLAY 'R4100-00 - PROBLEMAS INSERT (V0FOLLOWUP) ' V0FOLL-NUMAPOL '  ' V0FOLL-NRENDOS '  ' V0FOLL-NRPARCEL '  ' V0FOLL-NRAVISO */

                    $"R4100-00 - PROBLEMAS INSERT (V0FOLLOWUP) {V0FOLL_NUMAPOL}  {V0FOLL_NRENDOS}  {V0FOLL_NRPARCEL}  {V0FOLL_NRAVISO}"
                    .Display();

                    /*" -5286- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5286- ADD 1 TO IN-FOLLOWUP. */
            WS_AUX_ARQUIVO.IN_FOLLOWUP.Value = WS_AUX_ARQUIVO.IN_FOLLOWUP + 1;

        }

        [StopWatch]
        /*" R4100-00-INSERT-V0FOLLOWUP-DB-INSERT-1 */
        public void R4100_00_INSERT_V0FOLLOWUP_DB_INSERT_1()
        {
            /*" -5262- EXEC SQL INSERT INTO SEGUROS.V0FOLLOWUP VALUES (:V0FOLL-NUMAPOL , :V0FOLL-NRENDOS , :V0FOLL-NRPARCEL , :V0FOLL-DACPARC , :V0FOLL-DTMOVTO , :V0FOLL-HORAOPER , :V0FOLL-VLPREMIO , :V0FOLL-BCOAVISO , :V0FOLL-AGEAVISO , :V0FOLL-NRAVISO , :V0FOLL-CODBAIXA , :V0FOLL-CDERRO01 , :V0FOLL-CDERRO02 , :V0FOLL-CDERRO03 , :V0FOLL-CDERRO04 , :V0FOLL-CDERRO05 , :V0FOLL-CDERRO06 , :V0FOLL-SITUACAO , :V0FOLL-SITCONTB , :V0FOLL-OPERACAO , :V0FOLL-DTLIBER:VIND-DTLIBER , :V0FOLL-DTQITBCO:VIND-DTQITBCO , :V0FOLL-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0FOLL-ORDLIDER:VIND-ORDLIDER , :V0FOLL-TIPSGU:VIND-TIPSGU , :V0FOLL-APOLIDER:VIND-APOLIDER , :V0FOLL-ENDOSLID:VIND-ENDOSLID , :V0FOLL-CODLIDER:VIND-CODLIDER , :V0FOLL-FONTE:VIND-FONTE , :V0FOLL-NRRCAP:VIND-NRRCAP , :V0FOLL-NUM-NOSSO-TITULO) END-EXEC. */

            var r4100_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 = new R4100_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1()
            {
                V0FOLL_NUMAPOL = V0FOLL_NUMAPOL.ToString(),
                V0FOLL_NRENDOS = V0FOLL_NRENDOS.ToString(),
                V0FOLL_NRPARCEL = V0FOLL_NRPARCEL.ToString(),
                V0FOLL_DACPARC = V0FOLL_DACPARC.ToString(),
                V0FOLL_DTMOVTO = V0FOLL_DTMOVTO.ToString(),
                V0FOLL_HORAOPER = V0FOLL_HORAOPER.ToString(),
                V0FOLL_VLPREMIO = V0FOLL_VLPREMIO.ToString(),
                V0FOLL_BCOAVISO = V0FOLL_BCOAVISO.ToString(),
                V0FOLL_AGEAVISO = V0FOLL_AGEAVISO.ToString(),
                V0FOLL_NRAVISO = V0FOLL_NRAVISO.ToString(),
                V0FOLL_CODBAIXA = V0FOLL_CODBAIXA.ToString(),
                V0FOLL_CDERRO01 = V0FOLL_CDERRO01.ToString(),
                V0FOLL_CDERRO02 = V0FOLL_CDERRO02.ToString(),
                V0FOLL_CDERRO03 = V0FOLL_CDERRO03.ToString(),
                V0FOLL_CDERRO04 = V0FOLL_CDERRO04.ToString(),
                V0FOLL_CDERRO05 = V0FOLL_CDERRO05.ToString(),
                V0FOLL_CDERRO06 = V0FOLL_CDERRO06.ToString(),
                V0FOLL_SITUACAO = V0FOLL_SITUACAO.ToString(),
                V0FOLL_SITCONTB = V0FOLL_SITCONTB.ToString(),
                V0FOLL_OPERACAO = V0FOLL_OPERACAO.ToString(),
                V0FOLL_DTLIBER = V0FOLL_DTLIBER.ToString(),
                VIND_DTLIBER = VIND_DTLIBER.ToString(),
                V0FOLL_DTQITBCO = V0FOLL_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0FOLL_CODEMP = V0FOLL_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0FOLL_ORDLIDER = V0FOLL_ORDLIDER.ToString(),
                VIND_ORDLIDER = VIND_ORDLIDER.ToString(),
                V0FOLL_TIPSGU = V0FOLL_TIPSGU.ToString(),
                VIND_TIPSGU = VIND_TIPSGU.ToString(),
                V0FOLL_APOLIDER = V0FOLL_APOLIDER.ToString(),
                VIND_APOLIDER = VIND_APOLIDER.ToString(),
                V0FOLL_ENDOSLID = V0FOLL_ENDOSLID.ToString(),
                VIND_ENDOSLID = VIND_ENDOSLID.ToString(),
                V0FOLL_CODLIDER = V0FOLL_CODLIDER.ToString(),
                VIND_CODLIDER = VIND_CODLIDER.ToString(),
                V0FOLL_FONTE = V0FOLL_FONTE.ToString(),
                VIND_FONTE = VIND_FONTE.ToString(),
                V0FOLL_NRRCAP = V0FOLL_NRRCAP.ToString(),
                VIND_NRRCAP = VIND_NRRCAP.ToString(),
                V0FOLL_NUM_NOSSO_TITULO = V0FOLL_NUM_NOSSO_TITULO.ToString(),
            };

            R4100_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1.Execute(r4100_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4110-00-ADICIONA-TIME-SECTION */
        private void R4110_00_ADICIONA_TIME_SECTION()
        {
            /*" -5299- MOVE '4110' TO WNR-EXEC-SQL. */
            _.Move("4110", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5301- IF WTIME-SEGU GREATER ZEROS AND WTIME-SEGU LESS 59 */

            if (WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_SEGU > 00 && WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_SEGU < 59)
            {

                /*" -5302- ADD 1 TO WTIME-SEGU */
                WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_SEGU.Value = WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_SEGU + 1;

                /*" -5303- ELSE */
            }
            else
            {


                /*" -5305- IF WTIME-MINU GREATER ZEROS AND WTIME-MINU LESS 59 */

                if (WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_MINU > 00 && WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_MINU < 59)
                {

                    /*" -5306- ADD 1 TO WTIME-MINU */
                    WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_MINU.Value = WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_MINU + 1;

                    /*" -5307- MOVE 1 TO WTIME-SEGU */
                    _.Move(1, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_SEGU);

                    /*" -5308- ELSE */
                }
                else
                {


                    /*" -5310- IF WTIME-HORA GREATER ZEROS AND WTIME-HORA LESS 23 */

                    if (WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_HORA > 00 && WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_HORA < 23)
                    {

                        /*" -5311- ADD 1 TO WTIME-HORA */
                        WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_HORA.Value = WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_HORA + 1;

                        /*" -5313- MOVE 1 TO WTIME-MINU WTIME-SEGU */
                        _.Move(1, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_MINU);
                        _.Move(1, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_SEGU);


                        /*" -5314- ELSE */
                    }
                    else
                    {


                        /*" -5319- MOVE 01 TO WTIME-HORA WTIME-MINU WTIME-SEGU. */
                        _.Move(01, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_HORA);
                        _.Move(01, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_MINU);
                        _.Move(01, WS_AUX_DATAS.FILLER_25.WTIME_DAYR.WTIME_SEGU);

                    }

                }

            }


            /*" -5319- MOVE WTIME-DAYR TO V0FOLL-HORAOPER. */
            _.Move(WS_AUX_DATAS.FILLER_25.WTIME_DAYR, V0FOLL_HORAOPER);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4110_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-TRATA-TRAILLER-SECTION */
        private void R4500_00_TRATA_TRAILLER_SECTION()
        {
            /*" -5333- MOVE '4500' TO WNR-EXEC-SQL. */
            _.Move("4500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5335- IF TRAILL-CEDENTE EQUAL 630870000000440 */

            if (TRAILL_REGISTRO.TRAILL_CEDENTE == 630870000000440)
            {

                /*" -5336- MOVE TRAILL-REGISTRO TO REG-PF0002B1 */
                _.Move(TRAILL_REGISTRO, REG_PF0002B1);

                /*" -5340- WRITE REG-PF0002B1. */
                PF0002B1.Write(REG_PF0002B1.GetMoveValues().ToString());
            }


            /*" -5341- IF V0AVIS-VLPRMTOT NOT EQUAL ZEROS */

            if (V0AVIS_VLPRMTOT != 00)
            {

                /*" -5342- PERFORM R4550-00-INSERT-V0AVISOCRED */

                R4550_00_INSERT_V0AVISOCRED_SECTION();

                /*" -5345- PERFORM R4600-00-INSERT-V0AVISOSALDO. */

                R4600_00_INSERT_V0AVISOSALDO_SECTION();
            }


            /*" -5348- PERFORM R4650-00-INSERT-V0CONTROCNAB. */

            R4650_00_INSERT_V0CONTROCNAB_SECTION();

            /*" -5349- IF AD-QTDEBIL NOT EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.AD_QTDEBIL != 00)
            {

                /*" -5352- PERFORM R7000-00-TRATA-ADIANTA. */

                R7000_00_TRATA_ADIANTA_SECTION();
            }


            /*" -5353- IF V0AVIS-VLPRMTOT NOT EQUAL ZEROS */

            if (V0AVIS_VLPRMTOT != 00)
            {

                /*" -5355- SET WS-PRO TO 1 */
                WS_PRO.Value = 1;

                /*" -5355- PERFORM R8500-00-GRAVA-DESPESAS 2000 TIMES. */

                for (int i = 0; i < 2000; i++)
                {

                    R8500_00_GRAVA_DESPESAS_SECTION();

                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4550-00-INSERT-V0AVISOCRED-SECTION */
        private void R4550_00_INSERT_V0AVISOCRED_SECTION()
        {
            /*" -5367- MOVE '4550' TO WNR-EXEC-SQL. */
            _.Move("4550", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5373- COMPUTE V0AVIS-VLPRMLIQ EQUAL V0AVIS-VLPRMTOT - V0AVIS-VLIOCC - V0AVIS-VLDESPES - V0AVIS-VALADT. */
            V0AVIS_VLPRMLIQ.Value = V0AVIS_VLPRMTOT - V0AVIS_VLIOCC - V0AVIS_VLDESPES - V0AVIS_VALADT;

            /*" -5411- PERFORM R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1 */

            R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1();

            /*" -5414- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5415- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_AUX_AVISO.WABEND.WSQLCODE);

                /*" -5416- DISPLAY '---  PF0002B  --- SQLCODE = ' WSQLCODE */
                _.Display($"---  PF0002B  --- SQLCODE = {WS_AUX_AVISO.WABEND.WSQLCODE}");

                /*" -5417- DISPLAY 'R4550-00 - PROBLEMAS INSERT (V0AVISOCRED)' */
                _.Display($"R4550-00 - PROBLEMAS INSERT (V0AVISOCRED)");

                /*" -5418- DISPLAY 'V0AVIS-BCOAVISO .... ' V0AVIS-BCOAVISO */
                _.Display($"V0AVIS-BCOAVISO .... {V0AVIS_BCOAVISO}");

                /*" -5419- DISPLAY 'V0AVIS-AGEAVISO .... ' V0AVIS-AGEAVISO */
                _.Display($"V0AVIS-AGEAVISO .... {V0AVIS_AGEAVISO}");

                /*" -5420- DISPLAY 'V0AVIS-NRAVISO ..... ' V0AVIS-NRAVISO */
                _.Display($"V0AVIS-NRAVISO ..... {V0AVIS_NRAVISO}");

                /*" -5421- DISPLAY 'V0AVIS-NRSEQ ....... ' V0AVIS-NRSEQ */
                _.Display($"V0AVIS-NRSEQ ....... {V0AVIS_NRSEQ}");

                /*" -5422- DISPLAY 'V0AVIS-DTMOVTO ..... ' V0AVIS-DTMOVTO */
                _.Display($"V0AVIS-DTMOVTO ..... {V0AVIS_DTMOVTO}");

                /*" -5423- DISPLAY 'V0AVIS-OPERACAO .... ' V0AVIS-OPERACAO */
                _.Display($"V0AVIS-OPERACAO .... {V0AVIS_OPERACAO}");

                /*" -5424- DISPLAY 'V0AVIS-TIPAVI ...... ' V0AVIS-TIPAVI */
                _.Display($"V0AVIS-TIPAVI ...... {V0AVIS_TIPAVI}");

                /*" -5425- DISPLAY 'V0AVIS-DTAVISO ..... ' V0AVIS-DTAVISO */
                _.Display($"V0AVIS-DTAVISO ..... {V0AVIS_DTAVISO}");

                /*" -5426- DISPLAY 'V0AVIS-VLIOCC ...... ' V0AVIS-VLIOCC */
                _.Display($"V0AVIS-VLIOCC ...... {V0AVIS_VLIOCC}");

                /*" -5427- DISPLAY 'V0AVIS-VLDESPES .... ' V0AVIS-VLDESPES */
                _.Display($"V0AVIS-VLDESPES .... {V0AVIS_VLDESPES}");

                /*" -5428- DISPLAY 'V0AVIS-PRECED ...... ' V0AVIS-PRECED */
                _.Display($"V0AVIS-PRECED ...... {V0AVIS_PRECED}");

                /*" -5430- DISPLAY 'V0AVIS-VLPRMLIQ .... ' V0AVIS-VLPRMLIQ */
                _.Display($"V0AVIS-VLPRMLIQ .... {V0AVIS_VLPRMLIQ}");

                /*" -5431- IF SQLCODE NOT EQUAL -803 */

                if (DB.SQLCODE != -803)
                {

                    /*" -5432- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5434- END-IF */
                }


                /*" -5434- END-IF. */
            }


        }

        [StopWatch]
        /*" R4550-00-INSERT-V0AVISOCRED-DB-INSERT-1 */
        public void R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1()
        {
            /*" -5411- EXEC SQL INSERT INTO SEGUROS.V0AVISOCRED ( BCOAVISO, AGEAVISO, NRAVISO, NRSEQ, DTMOVTO, OPERACAO, TIPAVI, DTAVISO, VLIOCC, VLDESPES, PRECED, VLPRMLIQ, VLPRMTOT, SITCONTB, COD_EMPRESA, TIMESTAMP, ORIGAVISO, VALADT ) VALUES (:V0AVIS-BCOAVISO , :V0AVIS-AGEAVISO , :V0AVIS-NRAVISO , :V0AVIS-NRSEQ , :V0AVIS-DTMOVTO , :V0AVIS-OPERACAO , :V0AVIS-TIPAVI , :V0AVIS-DTAVISO , :V0AVIS-VLIOCC , :V0AVIS-VLDESPES , :V0AVIS-PRECED , :V0AVIS-VLPRMLIQ , :V0AVIS-VLPRMTOT , :V0AVIS-SITCONTB , :V0AVIS-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0AVIS-ORIGAVISO:VIND-ORIGAVISO , :V0AVIS-VALADT:VIND-VALADT) END-EXEC. */

            var r4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1 = new R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1()
            {
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0AVIS_NRSEQ = V0AVIS_NRSEQ.ToString(),
                V0AVIS_DTMOVTO = V0AVIS_DTMOVTO.ToString(),
                V0AVIS_OPERACAO = V0AVIS_OPERACAO.ToString(),
                V0AVIS_TIPAVI = V0AVIS_TIPAVI.ToString(),
                V0AVIS_DTAVISO = V0AVIS_DTAVISO.ToString(),
                V0AVIS_VLIOCC = V0AVIS_VLIOCC.ToString(),
                V0AVIS_VLDESPES = V0AVIS_VLDESPES.ToString(),
                V0AVIS_PRECED = V0AVIS_PRECED.ToString(),
                V0AVIS_VLPRMLIQ = V0AVIS_VLPRMLIQ.ToString(),
                V0AVIS_VLPRMTOT = V0AVIS_VLPRMTOT.ToString(),
                V0AVIS_SITCONTB = V0AVIS_SITCONTB.ToString(),
                V0AVIS_CODEMP = V0AVIS_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0AVIS_ORIGAVISO = V0AVIS_ORIGAVISO.ToString(),
                VIND_ORIGAVISO = VIND_ORIGAVISO.ToString(),
                V0AVIS_VALADT = V0AVIS_VALADT.ToString(),
                VIND_VALADT = VIND_VALADT.ToString(),
            };

            R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1.Execute(r4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4550_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-INSERT-V0AVISOSALDO-SECTION */
        private void R4600_00_INSERT_V0AVISOSALDO_SECTION()
        {
            /*" -5450- MOVE '4600' TO WNR-EXEC-SQL. */
            _.Move("4600", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5472- PERFORM R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1 */

            R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1();

            /*" -5475- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5476- DISPLAY 'R4600-00 - PROBLEMAS INSERT (V0AVISOSALD)' */
                _.Display($"R4600-00 - PROBLEMAS INSERT (V0AVISOSALD)");

                /*" -5477- DISPLAY 'CODEMP   = ' V0SALD-CODEMP */
                _.Display($"CODEMP   = {V0SALD_CODEMP}");

                /*" -5478- DISPLAY 'BCOAVISO = ' V0SALD-BCOAVISO */
                _.Display($"BCOAVISO = {V0SALD_BCOAVISO}");

                /*" -5479- DISPLAY 'AGEAVISO = ' V0SALD-AGEAVISO */
                _.Display($"AGEAVISO = {V0SALD_AGEAVISO}");

                /*" -5480- DISPLAY 'TIPSGU   = ' V0SALD-TIPSGU */
                _.Display($"TIPSGU   = {V0SALD_TIPSGU}");

                /*" -5481- DISPLAY 'DTAVISO  = ' V0SALD-DTAVISO */
                _.Display($"DTAVISO  = {V0SALD_DTAVISO}");

                /*" -5482- DISPLAY 'DTMVTO   = ' V0SALD-DTMOVTO */
                _.Display($"DTMVTO   = {V0SALD_DTMOVTO}");

                /*" -5482- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4600-00-INSERT-V0AVISOSALDO-DB-INSERT-1 */
        public void R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1()
        {
            /*" -5472- EXEC SQL INSERT INTO SEGUROS.V0AVISOS_SALDOS ( COD_EMPRESA, BCOAVISO, AGEAVISO, TIPSGU, NRAVISO, DTAVISO, DTMOVTO, SDOATU, SITUACAO, TIMESTAMP ) VALUES (:V0SALD-CODEMP , :V0SALD-BCOAVISO , :V0SALD-AGEAVISO , :V0SALD-TIPSGU , :V0SALD-NRAVISO , :V0SALD-DTAVISO , :V0SALD-DTMOVTO , :V0SALD-SDOATU , :V0SALD-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

            var r4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1 = new R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1()
            {
                V0SALD_CODEMP = V0SALD_CODEMP.ToString(),
                V0SALD_BCOAVISO = V0SALD_BCOAVISO.ToString(),
                V0SALD_AGEAVISO = V0SALD_AGEAVISO.ToString(),
                V0SALD_TIPSGU = V0SALD_TIPSGU.ToString(),
                V0SALD_NRAVISO = V0SALD_NRAVISO.ToString(),
                V0SALD_DTAVISO = V0SALD_DTAVISO.ToString(),
                V0SALD_DTMOVTO = V0SALD_DTMOVTO.ToString(),
                V0SALD_SDOATU = V0SALD_SDOATU.ToString(),
                V0SALD_SITUACAO = V0SALD_SITUACAO.ToString(),
            };

            R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1.Execute(r4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R4650-00-INSERT-V0CONTROCNAB-SECTION */
        private void R4650_00_INSERT_V0CONTROCNAB_SECTION()
        {
            /*" -5495- MOVE '4650' TO WNR-EXEC-SQL. */
            _.Move("4650", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5506- PERFORM R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1 */

            R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1();

            /*" -5509- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -5514- DISPLAY 'R4650-00 - REGISTRO DUPLICADO (V0CONTROCNAB)' ' ' V0CNAB-ORGAO ' ' V0CNAB-NRCTACED ' ' V0CNAB-TIPOCOB ' ' V0CNAB-DTMOVTO */

                $"R4650-00 - REGISTRO DUPLICADO (V0CONTROCNAB) {V0CNAB_ORGAO} {V0CNAB_NRCTACED} {V0CNAB_TIPOCOB} {V0CNAB_DTMOVTO}"
                .Display();

                /*" -5516- GO TO R4650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5517- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5522- DISPLAY 'R4650-00 - PROBLEMAS NO INSERT(V0CONTROCNAB)' ' ' V0CNAB-ORGAO ' ' V0CNAB-NRCTACED ' ' V0CNAB-TIPOCOB ' ' V0CNAB-DTMOVTO */

                $"R4650-00 - PROBLEMAS NO INSERT(V0CONTROCNAB) {V0CNAB_ORGAO} {V0CNAB_NRCTACED} {V0CNAB_TIPOCOB} {V0CNAB_DTMOVTO}"
                .Display();

                /*" -5522- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4650-00-INSERT-V0CONTROCNAB-DB-INSERT-1 */
        public void R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1()
        {
            /*" -5506- EXEC SQL INSERT INTO SEGUROS.V0CONTROCNAB VALUES (:V0CNAB-COD-EMP , :V0CNAB-ORGAO , :V0CNAB-NRCTACED , :V0CNAB-TIPOCOB , :V0CNAB-DTMOVTO , :V0CNAB-DATCEF , :V0CNAB-NRSEQ , :V0CNAB-QTDREG , CURRENT TIMESTAMP) END-EXEC. */

            var r4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1 = new R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1()
            {
                V0CNAB_COD_EMP = V0CNAB_COD_EMP.ToString(),
                V0CNAB_ORGAO = V0CNAB_ORGAO.ToString(),
                V0CNAB_NRCTACED = V0CNAB_NRCTACED.ToString(),
                V0CNAB_TIPOCOB = V0CNAB_TIPOCOB.ToString(),
                V0CNAB_DTMOVTO = V0CNAB_DTMOVTO.ToString(),
                V0CNAB_DATCEF = V0CNAB_DATCEF.ToString(),
                V0CNAB_NRSEQ = V0CNAB_NRSEQ.ToString(),
                V0CNAB_QTDREG = V0CNAB_QTDREG.ToString(),
            };

            R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1.Execute(r4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4650_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-TRATA-BILHETES-SECTION */
        private void R6000_00_TRATA_BILHETES_SECTION()
        {
            /*" -5549- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5550- IF V0AVIS-DTAVISO LESS '2000-10-01' */

            if (V0AVIS_DTAVISO < "2000-10-01")
            {

                /*" -5551- ADD 1 TO AD-QTDEBIL */
                WS_AUX_ARQUIVO.AD_QTDEBIL.Value = WS_AUX_ARQUIVO.AD_QTDEBIL + 1;

                /*" -5552- ELSE */
            }
            else
            {


                /*" -5555- PERFORM R6050-00-CALCULA-ADIANTA. */

                R6050_00_CALCULA_ADIANTA_SECTION();
            }


            /*" -5558- MOVE COBRAN-DESC-CONCED TO WS-VALADT. */
            _.Move(COBRAN_REGISTRO.COBRAN_DESC_CONCED, WS_AUX_ARQUIVO.WS_VALADT);

            /*" -5562- COMPUTE V0AVIS-VALADT EQUAL V0AVIS-VALADT + WS-VALADT. */
            V0AVIS_VALADT.Value = V0AVIS_VALADT + WS_AUX_ARQUIVO.WS_VALADT;

            /*" -5564- MOVE ZEROS TO V0CFEN-CODEMP */
            _.Move(0, V0CFEN_CODEMP);

            /*" -5566- MOVE AUX-TITSIVPF TO V0CFEN-NUMBIL */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0CFEN_NUMBIL);

            /*" -5567- MOVE CONVEN-AGECOBR TO V0CFEN-AGECOBR */
            _.Move(WS_AUX_ARQUIVO.CONVEN_AGECOBR, V0CFEN_AGECOBR);

            /*" -5568- MOVE WS-VALADT TO V0CFEN-VALADT */
            _.Move(WS_AUX_ARQUIVO.WS_VALADT, V0CFEN_VALADT);

            /*" -5573- MOVE ZEROS TO V0CFEN-NRMATRVEN V0CFEN-AGECTAVEN V0CFEN-OPRCTAVEN V0CFEN-NUMCTAVEN V0CFEN-DIGCTAVEN */
            _.Move(0, V0CFEN_NRMATRVEN, V0CFEN_AGECTAVEN, V0CFEN_OPRCTAVEN, V0CFEN_NUMCTAVEN, V0CFEN_DIGCTAVEN);

            /*" -5577- MOVE ZEROS TO V0CFEN-AGECTADEB V0CFEN-OPRCTADEB V0CFEN-NUMCTADEB V0CFEN-DIGCTADEB */
            _.Move(0, V0CFEN_AGECTADEB, V0CFEN_OPRCTADEB, V0CFEN_NUMCTADEB, V0CFEN_DIGCTADEB);

            /*" -5578- MOVE SPACES TO V0CFEN-SINDICO */
            _.Move("", V0CFEN_SINDICO);

            /*" -5579- MOVE COBRAN-VLR-PRINC TO V0CFEN-VLRCAP */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0CFEN_VLRCAP);

            /*" -5580- MOVE V0SIST-DTMOVABE TO V0CFEN-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0CFEN_DTMOVTO);

            /*" -5581- MOVE '0' TO V0CFEN-SITUACAO */
            _.Move("0", V0CFEN_SITUACAO);

            /*" -5585- MOVE ZEROS TO V0CFEN-NRMATRGER V0CFEN-VALADTGER V0CFEN-NRMATRSUN V0CFEN-VALADTSUN */
            _.Move(0, V0CFEN_NRMATRGER, V0CFEN_VALADTGER, V0CFEN_NRMATRSUN, V0CFEN_VALADTSUN);

            /*" -5589- MOVE SPACES TO V0CFEN-DTPAGGER V0CFEN-DTCANCEL V0CFEN-DTPAGSUN. */
            _.Move("", V0CFEN_DTPAGGER, V0CFEN_DTCANCEL, V0CFEN_DTPAGSUN);

            /*" -5590- MOVE COBRAN-DATA-CRED TO WDATA-FITA */
            _.Move(COBRAN_REGISTRO.COBRAN_DATA_CRED, WS_AUX_DATAS.WDATA_FITA);

            /*" -5591- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA);

            /*" -5592- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES);

            /*" -5593- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO);

            /*" -5594- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

            if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
            {

                /*" -5595- MOVE 19 TO WDAT-SEC-SEC */
                _.Move(19, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);

                /*" -5596- ELSE */
            }
            else
            {


                /*" -5598- MOVE 20 TO WDAT-SEC-SEC. */
                _.Move(20, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);
            }


            /*" -5599- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -5600- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -5601- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -5602- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -5604- MOVE WDATA-TABELA TO V0CFEN-DTCREDITO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0CFEN_DTCREDITO);

            /*" -5605- MOVE COBRAN-DATAOCORREN TO WDATA-FITA */
            _.Move(COBRAN_REGISTRO.COBRAN_DATAOCORREN, WS_AUX_DATAS.WDATA_FITA);

            /*" -5606- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA);

            /*" -5607- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES);

            /*" -5608- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO);

            /*" -5609- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

            if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
            {

                /*" -5610- MOVE 19 TO WDAT-SEC-SEC */
                _.Move(19, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);

                /*" -5611- ELSE */
            }
            else
            {


                /*" -5613- MOVE 20 TO WDAT-SEC-SEC. */
                _.Move(20, WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC);
            }


            /*" -5614- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -5615- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -5616- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -5617- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -5619- MOVE WDATA-TABELA TO V0CFEN-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0CFEN_DTQITBCO);

            /*" -5628- MOVE -1 TO VIND-NRMATRGER VIND-VALADTGER VIND-DTPAGGER VIND-DTCANCEL VIND-NRMATRSUN VIND-VALADTSUN VIND-DTPAGSUN. */
            _.Move(-1, VIND_NRMATRGER, VIND_VALADTGER, VIND_DTPAGGER, VIND_DTCANCEL, VIND_NRMATRSUN, VIND_VALADTSUN, VIND_DTPAGSUN);

            /*" -5634- PERFORM R6100-00-INSERT-V0COMISFENAE. */

            R6100_00_INSERT_V0COMISFENAE_SECTION();

            /*" -5635- MOVE V0CFEN-NUMBIL TO V0VEND-NUMBIL */
            _.Move(V0CFEN_NUMBIL, V0VEND_NUMBIL);

            /*" -5636- MOVE V0CFEN-AGECOBR TO V0VEND-AGECOBR */
            _.Move(V0CFEN_AGECOBR, V0VEND_AGECOBR);

            /*" -5637- MOVE V0CFEN-VLRCAP TO V0VEND-VLRCAP */
            _.Move(V0CFEN_VLRCAP, V0VEND_VLRCAP);

            /*" -5638- MOVE WWORK-DTAVISO TO V0VEND-DTMOVTO */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0VEND_DTMOVTO);

            /*" -5641- MOVE V0CFEN-DTQITBCO TO V0VEND-DTQITBCO. */
            _.Move(V0CFEN_DTQITBCO, V0VEND_DTQITBCO);

            /*" -5641- PERFORM R6200-00-INSERT-V0VENDASBIL. */

            R6200_00_INSERT_V0VENDASBIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6050-00-CALCULA-ADIANTA-SECTION */
        private void R6050_00_CALCULA_ADIANTA_SECTION()
        {
            /*" -5653- MOVE '6050' TO WNR-EXEC-SQL. */
            _.Move("6050", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5654- MOVE ZEROS TO WS-SUBS */
            _.Move(0, WS_AUX_ARQUIVO.WS_SUBS);

            /*" -5656- SET WS-COB TO 1. */
            WS_COB.Value = 1;

            /*" -5657- SEARCH WCOBE-OCORRECOB */
            for (; WS_COB < WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB.Items.Count; WS_COB.Value++)
            {

                /*" -5659- WHEN V0RCOM-VLRCAP EQUAL WCOBE-VLPRMTOT(WS-COB) */

                if (V0RCOM_VLRCAP == WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTOT)
                {


                    /*" -5659- SET WS-SUBS TO WS-COB  END-SEARCH. */
                    WS_AUX_ARQUIVO.WS_SUBS.Value = WS_COB;
                    break;
                }
            }


            /*" -5663- IF WS-SUBS EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.WS_SUBS == 00)
            {

                /*" -5670- GO TO R6050-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6050_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5673- MOVE WCOBE-VLPRMTAR(WS-COB) TO WS-VLPRMTAR. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTAR, WS_AUX_ARQUIVO.WS_VLPRMTAR);

            /*" -5676- COMPUTE WS-VLPRMTAR EQUAL WS-VLPRMTAR * 0,005. */
            WS_AUX_ARQUIVO.WS_VLPRMTAR.Value = WS_AUX_ARQUIVO.WS_VLPRMTAR * 0.005;

            /*" -5680- COMPUTE WS-VLPRMTAR EQUAL WS-VLPRMTAR * 0,90. */
            WS_AUX_ARQUIVO.WS_VLPRMTAR.Value = WS_AUX_ARQUIVO.WS_VLPRMTAR * 0.90;

            /*" -5681- IF WS-VLPRMTAR GREATER ZEROS */

            if (WS_AUX_ARQUIVO.WS_VLPRMTAR > 00)
            {

                /*" -5682- ADD 1 TO AD-QTDEBIL */
                WS_AUX_ARQUIVO.AD_QTDEBIL.Value = WS_AUX_ARQUIVO.AD_QTDEBIL + 1;

                /*" -5682- ADD WS-VLPRMTAR TO AD-VLRABIL. */
                WS_AUX_ARQUIVO.AD_VLRABIL.Value = WS_AUX_ARQUIVO.AD_VLRABIL + WS_AUX_ARQUIVO.WS_VLPRMTAR;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6050_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-INSERT-V0COMISFENAE-SECTION */
        private void R6100_00_INSERT_V0COMISFENAE_SECTION()
        {
            /*" -5695- MOVE '6100' TO WNR-EXEC-SQL. */
            _.Move("6100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5724- PERFORM R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1 */

            R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1();

            /*" -5727- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -5729- DISPLAY 'R6100-00 - REGISTRO DUPLICADO     ' V0CFEN-NUMBIL */
                _.Display($"R6100-00 - REGISTRO DUPLICADO     {V0CFEN_NUMBIL}");

                /*" -5730- ELSE */
            }
            else
            {


                /*" -5731- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5732- DISPLAY 'R6100-00 - PROBLEMAS INSERT (V0COMISFENAE)' */
                    _.Display($"R6100-00 - PROBLEMAS INSERT (V0COMISFENAE)");

                    /*" -5732- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6100-00-INSERT-V0COMISFENAE-DB-INSERT-1 */
        public void R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1()
        {
            /*" -5724- EXEC SQL INSERT INTO SEGUROS.V0COMISSAO_FENAE VALUES (:V0CFEN-CODEMP , :V0CFEN-NUMBIL , :V0CFEN-AGECOBR , :V0CFEN-VALADT , :V0CFEN-DTCREDITO , :V0CFEN-NRMATRVEN , :V0CFEN-AGECTAVEN , :V0CFEN-OPRCTAVEN , :V0CFEN-NUMCTAVEN , :V0CFEN-DIGCTAVEN , :V0CFEN-AGECTADEB , :V0CFEN-OPRCTADEB , :V0CFEN-NUMCTADEB , :V0CFEN-DIGCTADEB , :V0CFEN-SINDICO , :V0CFEN-DTQITBCO , :V0CFEN-VLRCAP , :V0CFEN-DTMOVTO , :V0CFEN-SITUACAO , CURRENT TIMESTAMP , :V0CFEN-NRMATRGER:VIND-NRMATRGER , :V0CFEN-VALADTGER:VIND-VALADTGER , :V0CFEN-DTPAGGER:VIND-DTPAGGER , :V0CFEN-DTCANCEL:VIND-DTCANCEL , :V0CFEN-NRMATRSUN:VIND-NRMATRSUN , :V0CFEN-VALADTSUN:VIND-VALADTSUN , :V0CFEN-DTPAGSUN:VIND-DTPAGSUN) END-EXEC. */

            var r6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1 = new R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1()
            {
                V0CFEN_CODEMP = V0CFEN_CODEMP.ToString(),
                V0CFEN_NUMBIL = V0CFEN_NUMBIL.ToString(),
                V0CFEN_AGECOBR = V0CFEN_AGECOBR.ToString(),
                V0CFEN_VALADT = V0CFEN_VALADT.ToString(),
                V0CFEN_DTCREDITO = V0CFEN_DTCREDITO.ToString(),
                V0CFEN_NRMATRVEN = V0CFEN_NRMATRVEN.ToString(),
                V0CFEN_AGECTAVEN = V0CFEN_AGECTAVEN.ToString(),
                V0CFEN_OPRCTAVEN = V0CFEN_OPRCTAVEN.ToString(),
                V0CFEN_NUMCTAVEN = V0CFEN_NUMCTAVEN.ToString(),
                V0CFEN_DIGCTAVEN = V0CFEN_DIGCTAVEN.ToString(),
                V0CFEN_AGECTADEB = V0CFEN_AGECTADEB.ToString(),
                V0CFEN_OPRCTADEB = V0CFEN_OPRCTADEB.ToString(),
                V0CFEN_NUMCTADEB = V0CFEN_NUMCTADEB.ToString(),
                V0CFEN_DIGCTADEB = V0CFEN_DIGCTADEB.ToString(),
                V0CFEN_SINDICO = V0CFEN_SINDICO.ToString(),
                V0CFEN_DTQITBCO = V0CFEN_DTQITBCO.ToString(),
                V0CFEN_VLRCAP = V0CFEN_VLRCAP.ToString(),
                V0CFEN_DTMOVTO = V0CFEN_DTMOVTO.ToString(),
                V0CFEN_SITUACAO = V0CFEN_SITUACAO.ToString(),
                V0CFEN_NRMATRGER = V0CFEN_NRMATRGER.ToString(),
                VIND_NRMATRGER = VIND_NRMATRGER.ToString(),
                V0CFEN_VALADTGER = V0CFEN_VALADTGER.ToString(),
                VIND_VALADTGER = VIND_VALADTGER.ToString(),
                V0CFEN_DTPAGGER = V0CFEN_DTPAGGER.ToString(),
                VIND_DTPAGGER = VIND_DTPAGGER.ToString(),
                V0CFEN_DTCANCEL = V0CFEN_DTCANCEL.ToString(),
                VIND_DTCANCEL = VIND_DTCANCEL.ToString(),
                V0CFEN_NRMATRSUN = V0CFEN_NRMATRSUN.ToString(),
                VIND_NRMATRSUN = VIND_NRMATRSUN.ToString(),
                V0CFEN_VALADTSUN = V0CFEN_VALADTSUN.ToString(),
                VIND_VALADTSUN = VIND_VALADTSUN.ToString(),
                V0CFEN_DTPAGSUN = V0CFEN_DTPAGSUN.ToString(),
                VIND_DTPAGSUN = VIND_DTPAGSUN.ToString(),
            };

            R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1.Execute(r6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6200-00-INSERT-V0VENDASBIL-SECTION */
        private void R6200_00_INSERT_V0VENDASBIL_SECTION()
        {
            /*" -5745- MOVE '6200' TO WNR-EXEC-SQL. */
            _.Move("6200", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5752- PERFORM R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1 */

            R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1();

            /*" -5755- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -5757- DISPLAY 'R6200-00 - REGISTRO DUPLICADO     ' V0VEND-NUMBIL */
                _.Display($"R6200-00 - REGISTRO DUPLICADO     {V0VEND_NUMBIL}");

                /*" -5758- ELSE */
            }
            else
            {


                /*" -5759- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5760- DISPLAY 'R6200-00 - PROBLEMAS INSERT (V0VENDASBIL) ' */
                    _.Display($"R6200-00 - PROBLEMAS INSERT (V0VENDASBIL) ");

                    /*" -5760- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6200-00-INSERT-V0VENDASBIL-DB-INSERT-1 */
        public void R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1()
        {
            /*" -5752- EXEC SQL INSERT INTO SEGUROS.V0VENDAS_BILHETES VALUES (:V0VEND-NUMBIL , :V0VEND-AGECOBR , :V0VEND-DTQITBCO , :V0VEND-VLRCAP , :V0VEND-DTMOVTO) END-EXEC. */

            var r6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1 = new R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1()
            {
                V0VEND_NUMBIL = V0VEND_NUMBIL.ToString(),
                V0VEND_AGECOBR = V0VEND_AGECOBR.ToString(),
                V0VEND_DTQITBCO = V0VEND_DTQITBCO.ToString(),
                V0VEND_VLRCAP = V0VEND_VLRCAP.ToString(),
                V0VEND_DTMOVTO = V0VEND_DTMOVTO.ToString(),
            };

            R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1.Execute(r6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6500-00-TARIFA-BALCAO-SECTION */
        private void R6500_00_TARIFA_BALCAO_SECTION()
        {
            /*" -5773- MOVE '6500' TO WNR-EXEC-SQL. */
            _.Move("6500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5774- MOVE ZEROS TO V0TRBL-CODEMP */
            _.Move(0, V0TRBL_CODEMP);

            /*" -5775- MOVE 9999999 TO V0TRBL-MATRICULA */
            _.Move(9999999, V0TRBL_MATRICULA);

            /*" -5777- MOVE '5' TO V0TRBL-TIPOFUNC */
            _.Move("5", V0TRBL_TIPOFUNC);

            /*" -5779- MOVE AUX-TITSIVPF TO V0TRBL-NRCERTIF */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0TRBL_NRCERTIF);

            /*" -5780- MOVE V0SIST-DTMOVABE TO V0TRBL-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0TRBL_DTMOVTO);

            /*" -5781- MOVE CONVEN-CODPRODU TO V0TRBL-CODPRODU */
            _.Move(WS_AUX_ARQUIVO.CONVEN_CODPRODU, V0TRBL_CODPRODU);

            /*" -5782- MOVE '0' TO V0TRBL-SITUACAO */
            _.Move("0", V0TRBL_SITUACAO);

            /*" -5783- MOVE V0AVIS-BCOAVISO TO V0TRBL-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0TRBL_BCOAVISO);

            /*" -5784- MOVE V0AVIS-AGEAVISO TO V0TRBL-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0TRBL_AGEAVISO);

            /*" -5786- MOVE V0AVIS-NRAVISO TO V0TRBL-NRAVISO. */
            _.Move(V0AVIS_NRAVISO, V0TRBL_NRAVISO);

            /*" -5787- MOVE CONVEN-FONTE TO V0TRBL-FONTE */
            _.Move(WS_AUX_ARQUIVO.CONVEN_FONTE, V0TRBL_FONTE);

            /*" -5788- MOVE CONVEN-AGECOBR TO V0TRBL-AGECOBR */
            _.Move(WS_AUX_ARQUIVO.CONVEN_AGECOBR, V0TRBL_AGECOBR);

            /*" -5793- MOVE CONVEN-ESCNEG TO V0TRBL-ESCNEG. */
            _.Move(WS_AUX_ARQUIVO.CONVEN_ESCNEG, V0TRBL_ESCNEG);

            /*" -5794- MOVE COBRAN-DESPESAS TO V0TRBL-TARIFA */
            _.Move(COBRAN_REGISTRO.COBRAN_DESPESAS, V0TRBL_TARIFA);

            /*" -5797- MOVE COBRAN-ABATIMENTO TO V0TRBL-BALCAO. */
            _.Move(COBRAN_REGISTRO.COBRAN_ABATIMENTO, V0TRBL_BALCAO);

            /*" -5799- IF V0TRBL-BALCAO NOT EQUAL ZEROS OR V0TRBL-TARIFA NOT EQUAL ZEROS */

            if (V0TRBL_BALCAO != 00 || V0TRBL_TARIFA != 00)
            {

                /*" -5799- PERFORM R6700-00-INSERT-TARIFA-BALCAO. */

                R6700_00_INSERT_TARIFA_BALCAO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/

        [StopWatch]
        /*" R6700-00-INSERT-TARIFA-BALCAO-SECTION */
        private void R6700_00_INSERT_TARIFA_BALCAO_SECTION()
        {
            /*" -5811- MOVE '6700' TO WNR-EXEC-SQL. */
            _.Move("6700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5829- PERFORM R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1 */

            R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1();

            /*" -5832- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5833- DISPLAY 'R6700-00 - PROBLEMAS INSERT (TARIFA)     ' */
                _.Display($"R6700-00 - PROBLEMAS INSERT (TARIFA)     ");

                /*" -5833- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6700-00-INSERT-TARIFA-BALCAO-DB-INSERT-1 */
        public void R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1()
        {
            /*" -5829- EXEC SQL INSERT INTO SEGUROS.TARIFA_BALCAO_CEF VALUES (:V0TRBL-CODEMP , :V0TRBL-MATRICULA , :V0TRBL-TIPOFUNC , :V0TRBL-NRCERTIF , :V0TRBL-DTMOVTO , :V0TRBL-CODPRODU , :V0TRBL-SITUACAO , :V0TRBL-FONTE , :V0TRBL-ESCNEG , :V0TRBL-AGECOBR , :V0TRBL-BCOAVISO , :V0TRBL-AGEAVISO , :V0TRBL-NRAVISO , :V0TRBL-TARIFA , :V0TRBL-BALCAO , CURRENT TIMESTAMP) END-EXEC. */

            var r6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1 = new R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1()
            {
                V0TRBL_CODEMP = V0TRBL_CODEMP.ToString(),
                V0TRBL_MATRICULA = V0TRBL_MATRICULA.ToString(),
                V0TRBL_TIPOFUNC = V0TRBL_TIPOFUNC.ToString(),
                V0TRBL_NRCERTIF = V0TRBL_NRCERTIF.ToString(),
                V0TRBL_DTMOVTO = V0TRBL_DTMOVTO.ToString(),
                V0TRBL_CODPRODU = V0TRBL_CODPRODU.ToString(),
                V0TRBL_SITUACAO = V0TRBL_SITUACAO.ToString(),
                V0TRBL_FONTE = V0TRBL_FONTE.ToString(),
                V0TRBL_ESCNEG = V0TRBL_ESCNEG.ToString(),
                V0TRBL_AGECOBR = V0TRBL_AGECOBR.ToString(),
                V0TRBL_BCOAVISO = V0TRBL_BCOAVISO.ToString(),
                V0TRBL_AGEAVISO = V0TRBL_AGEAVISO.ToString(),
                V0TRBL_NRAVISO = V0TRBL_NRAVISO.ToString(),
                V0TRBL_TARIFA = V0TRBL_TARIFA.ToString(),
                V0TRBL_BALCAO = V0TRBL_BALCAO.ToString(),
            };

            R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1.Execute(r6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6700_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-TRATA-ADIANTA-SECTION */
        private void R7000_00_TRATA_ADIANTA_SECTION()
        {
            /*" -5850- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5875- GO TO R7000-99-SAIDA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/ //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7050-00-SELECT-PROPOSTA-SECTION */
        private void R7050_00_SELECT_PROPOSTA_SECTION()
        {
            /*" -5962- MOVE '7050' TO WNR-EXEC-SQL. */
            _.Move("7050", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -5964- MOVE 'NAO' TO WTEM-PROPOSTA. */
            _.Move("NAO", WS_AUX_ARQUIVO.WTEM_PROPOSTA);

            /*" -5974- PERFORM R7050_00_SELECT_PROPOSTA_DB_SELECT_1 */

            R7050_00_SELECT_PROPOSTA_DB_SELECT_1();

            /*" -5977- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5978- MOVE 'SIM' TO WTEM-PROPOSTA */
                _.Move("SIM", WS_AUX_ARQUIVO.WTEM_PROPOSTA);

                /*" -5979- GO TO R7050-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7050_99_SAIDA*/ //GOTO
                return;

                /*" -5980- ELSE */
            }
            else
            {


                /*" -5981- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -5982- DISPLAY '-----------------------' */
                    _.Display($"-----------------------");

                    /*" -5983- DISPLAY '                       ' */
                    _.Display($"                       ");

                    /*" -5984- DISPLAY 'R7050-00 - PROPOSTA (1)' */
                    _.Display($"R7050-00 - PROPOSTA (1)");

                    /*" -5985- DISPLAY '                       ' */
                    _.Display($"                       ");

                    /*" -5986- DISPLAY '-----------------------' */
                    _.Display($"-----------------------");

                    /*" -5987- DISPLAY 'PROPOSTA CONV : ' PROPOAUT-NUM-PROPOSTA-CONV */
                    _.Display($"PROPOSTA CONV : {PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV}");

                    /*" -5988- DISPLAY '-----------------------' */
                    _.Display($"-----------------------");

                    /*" -5989- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5991- END-IF */
                }


                /*" -5997- PERFORM R7050_00_SELECT_PROPOSTA_DB_SELECT_2 */

                R7050_00_SELECT_PROPOSTA_DB_SELECT_2();

                /*" -5999- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -6000- MOVE 'SIM' TO WTEM-PROPOSTA */
                    _.Move("SIM", WS_AUX_ARQUIVO.WTEM_PROPOSTA);

                    /*" -6001- ELSE */
                }
                else
                {


                    /*" -6002- IF SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 100)
                    {

                        /*" -6003- DISPLAY '-----------------------' */
                        _.Display($"-----------------------");

                        /*" -6004- DISPLAY '                       ' */
                        _.Display($"                       ");

                        /*" -6005- DISPLAY 'R7050-00 - PROPOSTA (2)' */
                        _.Display($"R7050-00 - PROPOSTA (2)");

                        /*" -6006- DISPLAY '                       ' */
                        _.Display($"                       ");

                        /*" -6007- DISPLAY '-----------------------' */
                        _.Display($"-----------------------");

                        /*" -6008- DISPLAY 'PROPOSTA : ' PROPOAUT-NUM-PROPOSTA-CONV */
                        _.Display($"PROPOSTA : {PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV}");

                        /*" -6009- DISPLAY '-----------------------' */
                        _.Display($"-----------------------");

                        /*" -6010- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -6011- END-IF */
                    }


                    /*" -6012- END-IF */
                }


                /*" -6012- END-IF. */
            }


        }

        [StopWatch]
        /*" R7050-00-SELECT-PROPOSTA-DB-SELECT-1 */
        public void R7050_00_SELECT_PROPOSTA_DB_SELECT_1()
        {
            /*" -5974- EXEC SQL SELECT P.COD_PRODUTO INTO :PROPOSTA-COD-PRODUTO FROM SEGUROS.PROPOSTA_AUTO A, SEGUROS.PROPOSTAS P WHERE A.NUM_PROPOSTA_CONV = :PROPOAUT-NUM-PROPOSTA-CONV AND P.NUM_PROPOSTA = A.NUM_PROPOSTA AND P.COD_FONTE = A.COD_FONTE AND A.NUM_ITEM = 101 WITH UR END-EXEC. */

            var r7050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 = new R7050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOAUT_NUM_PROPOSTA_CONV = PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV.ToString(),
            };

            var executed_1 = R7050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1.Execute(r7050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOSTA_COD_PRODUTO, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7050_99_SAIDA*/

        [StopWatch]
        /*" R7050-00-SELECT-PROPOSTA-DB-SELECT-2 */
        public void R7050_00_SELECT_PROPOSTA_DB_SELECT_2()
        {
            /*" -5997- EXEC SQL SELECT P.COD_PRODUTO INTO :PROPOSTA-COD-PRODUTO FROM SEGUROS.AU_VENDA_ONLINE P WHERE P.NUM_PROPOSTA_CONV = :PROPOAUT-NUM-PROPOSTA-CONV WITH UR END-EXEC */

            var r7050_00_SELECT_PROPOSTA_DB_SELECT_2_Query1 = new R7050_00_SELECT_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPOAUT_NUM_PROPOSTA_CONV = PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV.ToString(),
            };

            var executed_1 = R7050_00_SELECT_PROPOSTA_DB_SELECT_2_Query1.Execute(r7050_00_SELECT_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOSTA_COD_PRODUTO, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R7100-00-INSERT-V0ADIANTA-SECTION */
        private void R7100_00_INSERT_V0ADIANTA_SECTION()
        {
            /*" -6024- MOVE '7100' TO WNR-EXEC-SQL. */
            _.Move("7100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6041- PERFORM R7100_00_INSERT_V0ADIANTA_DB_INSERT_1 */

            R7100_00_INSERT_V0ADIANTA_DB_INSERT_1();

            /*" -6045- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6046- DISPLAY 'R7100-00 - PROBLEMAS NO INSERT(V0ADIANTA) ' */
                _.Display($"R7100-00 - PROBLEMAS NO INSERT(V0ADIANTA) ");

                /*" -6046- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7100-00-INSERT-V0ADIANTA-DB-INSERT-1 */
        public void R7100_00_INSERT_V0ADIANTA_DB_INSERT_1()
        {
            /*" -6041- EXEC SQL INSERT INTO SEGUROS.V0ADIANTA VALUES (:V0ADIA-CODPDT , :V0ADIA-FONTE , :V0ADIA-NUMOPG , :V0ADIA-VALADT , :V0ADIA-QTPRESTA , :V0ADIA-NRPROPOS , :V0ADIA-NUMAPOL , :V0ADIA-NRENDOS , :V0ADIA-NRPARCEL , :V0ADIA-DTMOVTO , :V0ADIA-SITUACAO , :V0ADIA-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0ADIA-TIPO:VIND-TIPO) END-EXEC. */

            var r7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1 = new R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1()
            {
                V0ADIA_CODPDT = V0ADIA_CODPDT.ToString(),
                V0ADIA_FONTE = V0ADIA_FONTE.ToString(),
                V0ADIA_NUMOPG = V0ADIA_NUMOPG.ToString(),
                V0ADIA_VALADT = V0ADIA_VALADT.ToString(),
                V0ADIA_QTPRESTA = V0ADIA_QTPRESTA.ToString(),
                V0ADIA_NRPROPOS = V0ADIA_NRPROPOS.ToString(),
                V0ADIA_NUMAPOL = V0ADIA_NUMAPOL.ToString(),
                V0ADIA_NRENDOS = V0ADIA_NRENDOS.ToString(),
                V0ADIA_NRPARCEL = V0ADIA_NRPARCEL.ToString(),
                V0ADIA_DTMOVTO = V0ADIA_DTMOVTO.ToString(),
                V0ADIA_SITUACAO = V0ADIA_SITUACAO.ToString(),
                V0ADIA_CODEMP = V0ADIA_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0ADIA_TIPO = V0ADIA_TIPO.ToString(),
                VIND_TIPO = VIND_TIPO.ToString(),
            };

            R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1.Execute(r7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R7200-00-INSERT-V0FORMAREC-SECTION */
        private void R7200_00_INSERT_V0FORMAREC_SECTION()
        {
            /*" -6059- MOVE '7200' TO WNR-EXEC-SQL. */
            _.Move("7200", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6078- PERFORM R7200_00_INSERT_V0FORMAREC_DB_INSERT_1 */

            R7200_00_INSERT_V0FORMAREC_DB_INSERT_1();

            /*" -6082- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6083- DISPLAY 'R7200-00 - PROBLEMAS NO INSERT(V0FORMAREC)' */
                _.Display($"R7200-00 - PROBLEMAS NO INSERT(V0FORMAREC)");

                /*" -6083- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7200-00-INSERT-V0FORMAREC-DB-INSERT-1 */
        public void R7200_00_INSERT_V0FORMAREC_DB_INSERT_1()
        {
            /*" -6078- EXEC SQL INSERT INTO SEGUROS.V0FORMAREC VALUES (:V0FREC-CODPDT , :V0FREC-FONTE , :V0FREC-NUMOPG , :V0FREC-NRPROPOS , :V0FREC-NUMAPOL , :V0FREC-NRENDOS , :V0FREC-NRPARCEL , :V0FREC-NUMPTC , :V0FREC-VALRCP , :V0FREC-PCGACM , :V0FREC-SITUACAO , :V0FREC-VALSDO , :V0FREC-DTMOVTO , :V0FREC-DTVENCTO:VIND-DTVENCTO , :V0FREC-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP) END-EXEC. */

            var r7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1 = new R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1()
            {
                V0FREC_CODPDT = V0FREC_CODPDT.ToString(),
                V0FREC_FONTE = V0FREC_FONTE.ToString(),
                V0FREC_NUMOPG = V0FREC_NUMOPG.ToString(),
                V0FREC_NRPROPOS = V0FREC_NRPROPOS.ToString(),
                V0FREC_NUMAPOL = V0FREC_NUMAPOL.ToString(),
                V0FREC_NRENDOS = V0FREC_NRENDOS.ToString(),
                V0FREC_NRPARCEL = V0FREC_NRPARCEL.ToString(),
                V0FREC_NUMPTC = V0FREC_NUMPTC.ToString(),
                V0FREC_VALRCP = V0FREC_VALRCP.ToString(),
                V0FREC_PCGACM = V0FREC_PCGACM.ToString(),
                V0FREC_SITUACAO = V0FREC_SITUACAO.ToString(),
                V0FREC_VALSDO = V0FREC_VALSDO.ToString(),
                V0FREC_DTMOVTO = V0FREC_DTMOVTO.ToString(),
                V0FREC_DTVENCTO = V0FREC_DTVENCTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                V0FREC_CODEMP = V0FREC_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
            };

            R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1.Execute(r7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/

        [StopWatch]
        /*" R7300-00-INSERT-V0HISTOREC-SECTION */
        private void R7300_00_INSERT_V0HISTOREC_SECTION()
        {
            /*" -6096- MOVE '7300' TO WNR-EXEC-SQL. */
            _.Move("7300", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6114- PERFORM R7300_00_INSERT_V0HISTOREC_DB_INSERT_1 */

            R7300_00_INSERT_V0HISTOREC_DB_INSERT_1();

            /*" -6118- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6119- DISPLAY 'R7300-00 - PROBLEMAS NO INSERT(V0HISTOREC)' */
                _.Display($"R7300-00 - PROBLEMAS NO INSERT(V0HISTOREC)");

                /*" -6119- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7300-00-INSERT-V0HISTOREC-DB-INSERT-1 */
        public void R7300_00_INSERT_V0HISTOREC_DB_INSERT_1()
        {
            /*" -6114- EXEC SQL INSERT INTO SEGUROS.V0HISTOREC VALUES (:V0HREC-CODPDT , :V0HREC-FONTE , :V0HREC-NUMOPG , :V0HREC-NRPROPOS , :V0HREC-NUMAPOL , :V0HREC-NRENDOS , :V0HREC-NRPARCEL , :V0HREC-NUMPTC , :V0HREC-VALRCP , :V0HREC-NUMREC , :V0HREC-DTMOVTO , :V0HREC-OPERACAO , :V0HREC-HORSIS , :V0HREC-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP) END-EXEC. */

            var r7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1 = new R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1()
            {
                V0HREC_CODPDT = V0HREC_CODPDT.ToString(),
                V0HREC_FONTE = V0HREC_FONTE.ToString(),
                V0HREC_NUMOPG = V0HREC_NUMOPG.ToString(),
                V0HREC_NRPROPOS = V0HREC_NRPROPOS.ToString(),
                V0HREC_NUMAPOL = V0HREC_NUMAPOL.ToString(),
                V0HREC_NRENDOS = V0HREC_NRENDOS.ToString(),
                V0HREC_NRPARCEL = V0HREC_NRPARCEL.ToString(),
                V0HREC_NUMPTC = V0HREC_NUMPTC.ToString(),
                V0HREC_VALRCP = V0HREC_VALRCP.ToString(),
                V0HREC_NUMREC = V0HREC_NUMREC.ToString(),
                V0HREC_DTMOVTO = V0HREC_DTMOVTO.ToString(),
                V0HREC_OPERACAO = V0HREC_OPERACAO.ToString(),
                V0HREC_HORSIS = V0HREC_HORSIS.ToString(),
                V0HREC_CODEMP = V0HREC_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
            };

            R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1.Execute(r7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7300_99_SAIDA*/

        [StopWatch]
        /*" R7500-00-UPDATE-V0CEDENTE-SECTION */
        private void R7500_00_UPDATE_V0CEDENTE_SECTION()
        {
            /*" -6131- MOVE '7500' TO WNR-EXEC-SQL. */
            _.Move("7500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6133- MOVE WWORK-MIN-NRTIT TO V0CEDE-NUMTIT. */
            _.Move(WS_AUX_ARQUIVO.WWORK_MIN_NRTIT, V0CEDE_NUMTIT);

            /*" -6137- PERFORM R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1 */

            R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1();

            /*" -6140- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6141- DISPLAY 'R7500-00 - PROBLEMAS UPDATE (V0CEDENTE)   ' */
                _.Display($"R7500-00 - PROBLEMAS UPDATE (V0CEDENTE)   ");

                /*" -6141- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7500-00-UPDATE-V0CEDENTE-DB-UPDATE-1 */
        public void R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1()
        {
            /*" -6137- EXEC SQL UPDATE SEGUROS.V0CEDENTE SET NUMTIT = :V0CEDE-NUMTIT WHERE CODCDT = 26 END-EXEC. */

            var r7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 = new R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1()
            {
                V0CEDE_NUMTIT = V0CEDE_NUMTIT.ToString(),
            };

            R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1.Execute(r7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7500_99_SAIDA*/

        [StopWatch]
        /*" R7600-00-UPDATE-V0MOVICOB-SECTION */
        private void R7600_00_UPDATE_V0MOVICOB_SECTION()
        {
            /*" -6154- MOVE '7600' TO WNR-EXEC-SQL. */
            _.Move("7600", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6165- PERFORM R7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1 */

            R7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1();

            /*" -6168- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -6169- DISPLAY 'R7600-00 - PROBLEMAS NO SELECT(MOVICOB)' */
                _.Display($"R7600-00 - PROBLEMAS NO SELECT(MOVICOB)");

                /*" -6172- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6173- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6173- ADD 1 TO UP-MOVICOB. */
                WS_AUX_ARQUIVO.UP_MOVICOB.Value = WS_AUX_ARQUIVO.UP_MOVICOB + 1;
            }


        }

        [StopWatch]
        /*" R7600-00-UPDATE-V0MOVICOB-DB-UPDATE-1 */
        public void R7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1()
        {
            /*" -6165- EXEC SQL UPDATE SEGUROS.V0MOVICOB SET SITUACAO = '*' WHERE BANCO = 104 AND AGENCIA = 7003 AND NRAVISO = 804401329 AND NUM_APOLICE = 104800047007 AND DTQITBCO = '2005-10-11' AND DTMOVTO = '2005-11-04' AND NUM_NOSSO_TITULO = 8000100003890510 AND SITUACAO = ' ' END-EXEC. */

            var r7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 = new R7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1()
            {
            };

            R7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1.Execute(r7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7600_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-TRATA-DESPESAS-SECTION */
        private void R8000_00_TRATA_DESPESAS_SECTION()
        {
            /*" -6186- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6187- MOVE ZEROS TO WS-SUBS. */
            _.Move(0, WS_AUX_ARQUIVO.WS_SUBS);

            /*" -6188- SET WS-PRO TO 1 */
            WS_PRO.Value = 1;

            /*" -6189- SEARCH WTABG-OCORREPRD */
            for (; WS_PRO < WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD.Items.Count; WS_PRO.Value++)
            {

                /*" -6191- WHEN WSHOST-CODPRODU EQUAL WTABG-CODPRODU(WS-PRO) */

                if (WSHOST_CODPRODU == WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU)
                {


                    /*" -6191- SET WS-SUBS TO WS-PRO  END-SEARCH. */
                    WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRO;
                    break;
                }
            }


            /*" -6198- IF WS-SUBS EQUAL ZEROS OR WS-SUBS GREATER 2000 */

            if (WS_AUX_ARQUIVO.WS_SUBS == 00 || WS_AUX_ARQUIVO.WS_SUBS > 2000)
            {

                /*" -6201- SET WS-PRO TO 1. */
                WS_PRO.Value = 1;
            }


            /*" -6201- PERFORM R8050-00-VERIFICA-TIPO. */

            R8050_00_VERIFICA_TIPO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8050-00-VERIFICA-TIPO-SECTION */
        private void R8050_00_VERIFICA_TIPO_SECTION()
        {
            /*" -6217- MOVE '8050' TO WNR-EXEC-SQL. */
            _.Move("8050", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6219- IF COBRAN-CODEMPRESA EQUAL 630870000000440 OR COBRAN-CODEMPRESA EQUAL 630870000002825 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000440 || COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000002825)
            {

                /*" -6220- SET WS-TIP TO 3 */
                WS_TIP.Value = 3;

                /*" -6224- ELSE */
            }
            else
            {


                /*" -6225- IF FLG-MALA EQUAL 'S' */

                if (WS_AUX_ARQUIVO.FLG_MALA == "S")
                {

                    /*" -6226- SET WS-TIP TO 5 */
                    WS_TIP.Value = 5;

                    /*" -6230- ELSE */
                }
                else
                {


                    /*" -6231- IF FLG-GRAFICA EQUAL 'S' */

                    if (WS_AUX_ARQUIVO.FLG_GRAFICA == "S")
                    {

                        /*" -6232- SET WS-TIP TO 2 */
                        WS_TIP.Value = 2;

                        /*" -6236- ELSE */
                    }
                    else
                    {


                        /*" -6240- IF WSHOST-CODPRODU EQUAL ZEROS OR COBRAN-CODEMPRESA EQUAL 630870000000628 OR COBRAN-CODEMPRESA EQUAL 630870000000725 OR COBRAN-CODEMPRESA EQUAL 630870000003201 */

                        if (WSHOST_CODPRODU == 00 || COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000628 || COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000725 || COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000003201)
                        {

                            /*" -6241- SET WS-TIP TO 4 */
                            WS_TIP.Value = 4;

                            /*" -6245- ELSE */
                        }
                        else
                        {


                            /*" -6251- SET WS-TIP TO 1. */
                            WS_TIP.Value = 1;
                        }

                    }

                }

            }


            /*" -6252- IF WSHOST-SITUACAO EQUAL '0' */

            if (WSHOST_SITUACAO == "0")
            {

                /*" -6253- SET WS-SIT TO 1 */
                WS_SIT.Value = 1;

                /*" -6257- ELSE */
            }
            else
            {


                /*" -6260- SET WS-SIT TO 2. */
                WS_SIT.Value = 2;
            }


            /*" -6263- ADD 1 TO WTABG-QTDE(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE + 1;

            /*" -6266- ADD WSHOST-VLPRMTOT TO WTABG-VLPRMTOT(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -6269- ADD WSHOST-VLTARIFA TO WTABG-VLTARIFA(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA + WSHOST_VLTARIFA;

            /*" -6272- ADD WSHOST-VLBALCAO TO WTABG-VLBALCAO(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO + WSHOST_VLBALCAO;

            /*" -6275- ADD WSHOST-VLIOCC TO WTABG-VLIOCC(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC + WSHOST_VLIOCC;

            /*" -6276- ADD WSHOST-VLDESCON TO WTABG-VLDESCON(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON + WSHOST_VLDESCON;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8050_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-GRAVA-DESPESAS-SECTION */
        private void R8500_00_GRAVA_DESPESAS_SECTION()
        {
            /*" -6289- MOVE '8500' TO WNR-EXEC-SQL. */
            _.Move("8500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6290- IF WTABG-CODPRODU(WS-PRO) EQUAL 9999 */

            if (WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU == 9999)
            {

                /*" -6291- SET WS-PRO UP BY 1 */
                WS_PRO.Value += 1;

                /*" -6294- GO TO R8500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6297- MOVE WTABG-CODPRODU(WS-PRO) TO V0DPCF-CODPRODU. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU, V0DPCF_CODPRODU);

            /*" -6298- MOVE ZEROS TO V0DPCF-CODEMP */
            _.Move(0, V0DPCF_CODEMP);

            /*" -6299- MOVE V0AVIS-BCOAVISO TO V0DPCF-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0DPCF_BCOAVISO);

            /*" -6300- MOVE V0AVIS-AGEAVISO TO V0DPCF-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0DPCF_AGEAVISO);

            /*" -6301- MOVE V0AVIS-NRAVISO TO V0DPCF-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0DPCF_NRAVISO);

            /*" -6302- MOVE '0' TO V0DPCF-TIPOCOB */
            _.Move("0", V0DPCF_TIPOCOB);

            /*" -6303- MOVE V0AVIS-DTMOVTO TO V0DPCF-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0DPCF_DTMOVTO);

            /*" -6304- MOVE V0AVIS-DTAVISO TO V0DPCF-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0DPCF_DTAVISO);

            /*" -6307- MOVE ZEROS TO V0DPCF-VLJUROS V0DPCF-VLMULTA. */
            _.Move(0, V0DPCF_VLJUROS, V0DPCF_VLMULTA);

            /*" -6308- MOVE V0AVIS-DTAVISO TO WDATA-REL */
            _.Move(V0AVIS_DTAVISO, WS_AUX_DATAS.WDATA_REL);

            /*" -6309- MOVE WDAT-REL-ANO TO V0DPCF-ANOREF */
            _.Move(WS_AUX_DATAS.FILLER_16.WDAT_REL_ANO, V0DPCF_ANOREF);

            /*" -6312- MOVE WDAT-REL-MES TO V0DPCF-MESREF. */
            _.Move(WS_AUX_DATAS.FILLER_16.WDAT_REL_MES, V0DPCF_MESREF);

            /*" -6313- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -6316- PERFORM R8550-00-GRAVA-TIPO 05 TIMES. */

            for (int i = 0; i < 5; i++)
            {

                R8550_00_GRAVA_TIPO_SECTION();

            }

            /*" -6316- SET WS-PRO UP BY 1. */
            WS_PRO.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/

        [StopWatch]
        /*" R8550-00-GRAVA-TIPO-SECTION */
        private void R8550_00_GRAVA_TIPO_SECTION()
        {
            /*" -6329- MOVE '8550' TO WNR-EXEC-SQL. */
            _.Move("8550", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6333- MOVE WTABG-TIPO(WS-PRO WS-TIP) TO V0DPCF-TIPOREG. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO, V0DPCF_TIPOREG);

            /*" -6334- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -6337- PERFORM R8600-00-GRAVA-REGISTRO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R8600_00_GRAVA_REGISTRO_SECTION();

            }

            /*" -6337- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/

        [StopWatch]
        /*" R8600-00-GRAVA-REGISTRO-SECTION */
        private void R8600_00_GRAVA_REGISTRO_SECTION()
        {
            /*" -6350- MOVE '8600' TO WNR-EXEC-SQL. */
            _.Move("8600", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6352- MOVE WTABG-SITUACAO(WS-PRO WS-TIP WS-SIT) TO V0DPCF-SITUACAO. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO, V0DPCF_SITUACAO);

            /*" -6354- MOVE WTABG-QTDE(WS-PRO WS-TIP WS-SIT) TO V0DPCF-QTDREG. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, V0DPCF_QTDREG);

            /*" -6356- MOVE WTABG-VLPRMTOT(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLPRMTOT. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, V0DPCF_VLPRMTOT);

            /*" -6358- MOVE WTABG-VLTARIFA(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLTARIFA. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, V0DPCF_VLTARIFA);

            /*" -6360- MOVE WTABG-VLBALCAO(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLBALCAO. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, V0DPCF_VLBALCAO);

            /*" -6362- MOVE WTABG-VLIOCC(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLIOCC. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, V0DPCF_VLIOCC);

            /*" -6366- MOVE WTABG-VLDESCON(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLDESCON. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON, V0DPCF_VLDESCON);

            /*" -6373- COMPUTE V0DPCF-VLPRMLIQ EQUAL (V0DPCF-VLPRMTOT - V0DPCF-VLTARIFA - V0DPCF-VLBALCAO - V0DPCF-VLIOCC - V0DPCF-VLDESCON - V0DPCF-VLJUROS - V0DPCF-VLMULTA). */
            V0DPCF_VLPRMLIQ.Value = (V0DPCF_VLPRMTOT - V0DPCF_VLTARIFA - V0DPCF_VLBALCAO - V0DPCF_VLIOCC - V0DPCF_VLDESCON - V0DPCF_VLJUROS - V0DPCF_VLMULTA);

            /*" -6378- IF V0DPCF-QTDREG EQUAL ZEROS AND V0DPCF-VLPRMTOT EQUAL ZEROS AND V0DPCF-VLPRMLIQ EQUAL ZEROS AND V0DPCF-VLTARIFA EQUAL ZEROS AND V0DPCF-VLBALCAO EQUAL ZEROS */

            if (V0DPCF_QTDREG == 00 && V0DPCF_VLPRMTOT == 00 && V0DPCF_VLPRMLIQ == 00 && V0DPCF_VLTARIFA == 00 && V0DPCF_VLBALCAO == 00)
            {

                /*" -6379- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -6382- GO TO R8600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6385- PERFORM R8700-00-INSERT-DESPESAS. */

            R8700_00_INSERT_DESPESAS_SECTION();

            /*" -6394- MOVE ZEROS TO WTABG-QTDE(WS-PRO WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRO WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRO WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRO WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRO WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRO WS-TIP WS-SIT). */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -6394- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-SECTION */
        private void R8700_00_INSERT_DESPESAS_SECTION()
        {
            /*" -6407- MOVE '8700' TO WNR-EXEC-SQL. */
            _.Move("8700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6453- PERFORM R8700_00_INSERT_DESPESAS_DB_INSERT_1 */

            R8700_00_INSERT_DESPESAS_DB_INSERT_1();

            /*" -6457- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6458- DISPLAY 'R8700-00 - PROBLEMAS INSERT (DESPESAS)   ' */
                _.Display($"R8700-00 - PROBLEMAS INSERT (DESPESAS)   ");

                /*" -6459- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6460- ELSE */
            }
            else
            {


                /*" -6460- ADD 1 TO AC-INSERT. */
                WS_AUX_ARQUIVO.AC_INSERT.Value = WS_AUX_ARQUIVO.AC_INSERT + 1;
            }


        }

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-DB-INSERT-1 */
        public void R8700_00_INSERT_DESPESAS_DB_INSERT_1()
        {
            /*" -6453- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF (COD_EMPRESA, ANO_REFERENCIA, MES_REFERENCIA, BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, COD_PRODUTO, TIPO_REGISTRO, SITUACAO, TIPO_COBRANCA, DATA_MOVIMENTO, DATA_AVISO, QTD_REGISTROS, PRM_TOTAL, PRM_LIQUIDO, VAL_TARIFA, VAL_BALCAO, VAL_IOCC, VAL_DESCONTO, VAL_JUROS, VAL_MULTA, TIMESTAMP) VALUES (:V0DPCF-CODEMP , :V0DPCF-ANOREF , :V0DPCF-MESREF , :V0DPCF-BCOAVISO , :V0DPCF-AGEAVISO , :V0DPCF-NRAVISO , :V0DPCF-CODPRODU , :V0DPCF-TIPOREG , :V0DPCF-SITUACAO , :V0DPCF-TIPOCOB , :V0DPCF-DTMOVTO , :V0DPCF-DTAVISO , :V0DPCF-QTDREG , :V0DPCF-VLPRMTOT , :V0DPCF-VLPRMLIQ , :V0DPCF-VLTARIFA , :V0DPCF-VLBALCAO , :V0DPCF-VLIOCC , :V0DPCF-VLDESCON , :V0DPCF-VLJUROS , :V0DPCF-VLMULTA , CURRENT TIMESTAMP) END-EXEC. */

            var r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 = new R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1()
            {
                V0DPCF_CODEMP = V0DPCF_CODEMP.ToString(),
                V0DPCF_ANOREF = V0DPCF_ANOREF.ToString(),
                V0DPCF_MESREF = V0DPCF_MESREF.ToString(),
                V0DPCF_BCOAVISO = V0DPCF_BCOAVISO.ToString(),
                V0DPCF_AGEAVISO = V0DPCF_AGEAVISO.ToString(),
                V0DPCF_NRAVISO = V0DPCF_NRAVISO.ToString(),
                V0DPCF_CODPRODU = V0DPCF_CODPRODU.ToString(),
                V0DPCF_TIPOREG = V0DPCF_TIPOREG.ToString(),
                V0DPCF_SITUACAO = V0DPCF_SITUACAO.ToString(),
                V0DPCF_TIPOCOB = V0DPCF_TIPOCOB.ToString(),
                V0DPCF_DTMOVTO = V0DPCF_DTMOVTO.ToString(),
                V0DPCF_DTAVISO = V0DPCF_DTAVISO.ToString(),
                V0DPCF_QTDREG = V0DPCF_QTDREG.ToString(),
                V0DPCF_VLPRMTOT = V0DPCF_VLPRMTOT.ToString(),
                V0DPCF_VLPRMLIQ = V0DPCF_VLPRMLIQ.ToString(),
                V0DPCF_VLTARIFA = V0DPCF_VLTARIFA.ToString(),
                V0DPCF_VLBALCAO = V0DPCF_VLBALCAO.ToString(),
                V0DPCF_VLIOCC = V0DPCF_VLIOCC.ToString(),
                V0DPCF_VLDESCON = V0DPCF_VLDESCON.ToString(),
                V0DPCF_VLJUROS = V0DPCF_VLJUROS.ToString(),
                V0DPCF_VLMULTA = V0DPCF_VLMULTA.ToString(),
            };

            R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1.Execute(r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8700_99_SAIDA*/

        [StopWatch]
        /*" R8800-00-TRATA-AZULCAR-SECTION */
        private void R8800_00_TRATA_AZULCAR_SECTION()
        {
            /*" -6476- MOVE '8800' TO WNR-EXEC-SQL. */
            _.Move("8800", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6477- MOVE ZEROS TO V0SICB-CODEMP */
            _.Move(0, V0SICB_CODEMP);

            /*" -6478- MOVE V0RCAP-FONTE TO V0SICB-FONTE */
            _.Move(V0RCAP_FONTE, V0SICB_FONTE);

            /*" -6479- MOVE V0RCAP-NRRCAP TO V0SICB-NRRCAP */
            _.Move(V0RCAP_NRRCAP, V0SICB_NRRCAP);

            /*" -6480- MOVE ZEROS TO V0SICB-NUMBIL */
            _.Move(0, V0SICB_NUMBIL);

            /*" -6481- MOVE COBRAN-AGE-COBRAN TO V0SICB-AGECOBR */
            _.Move(COBRAN_REGISTRO.FILLER_40.COBRAN_AGE_COBRAN, V0SICB_AGECOBR);

            /*" -6482- MOVE COBRAN-MATR-INDIC TO V0SICB-NRMATRVEN */
            _.Move(COBRAN_REGISTRO.FILLER_41.COBRAN_MATR_INDIC, V0SICB_NRMATRVEN);

            /*" -6483- MOVE COBRAN-AGE-INDIC TO V0SICB-AGECTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_41.COBRAN_AGE_INDIC, V0SICB_AGECTAVEN);

            /*" -6484- MOVE COBRAN-OPER-INDIC TO V0SICB-OPRCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_41.COBRAN_OPER_INDIC, V0SICB_OPRCTAVEN);

            /*" -6485- MOVE COBRAN-CC-INDIC TO V0SICB-NUMCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_41.COBRAN_CC_INDIC, V0SICB_NUMCTAVEN);

            /*" -6486- MOVE COBRAN-DIG-INDIC TO V0SICB-DIGCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_41.COBRAN_DIG_INDIC, V0SICB_DIGCTAVEN);

            /*" -6487- MOVE COBRAN-DESC-CONCED TO V0SICB-VLCOMIS */
            _.Move(COBRAN_REGISTRO.COBRAN_DESC_CONCED, V0SICB_VLCOMIS);

            /*" -6488- MOVE V0SIST-DTMOVABE TO V0SICB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0SICB_DTMOVTO);

            /*" -6489- MOVE COBRAN-VLR-PRINC TO V0SICB-VLRCAP */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0SICB_VLRCAP);

            /*" -6496- MOVE ' ' TO V0SICB-SITUACAO. */
            _.Move(" ", V0SICB_SITUACAO);

            /*" -6498- MOVE CONVEN-DATA-CRED TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATA_CRED, WS_AUX_DATAS.WDATA_SECULO);

            /*" -6499- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -6500- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -6501- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -6502- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -6509- MOVE WDATA-TABELA TO V0SICB-DTCREDITO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0SICB_DTCREDITO);

            /*" -6511- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -6512- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -6513- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -6514- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -6515- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_23.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -6518- MOVE WDATA-TABELA TO V0SICB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0SICB_DTQITBCO);

            /*" -6522- COMPUTE V0AVIS-VALADT EQUAL V0AVIS-VALADT + COBRAN-DESC-CONCED. */
            V0AVIS_VALADT.Value = V0AVIS_VALADT + COBRAN_REGISTRO.COBRAN_DESC_CONCED;

            /*" -6528- PERFORM R8850-00-INSERT-V0COMISICOB. */

            R8850_00_INSERT_V0COMISICOB_SECTION();

            /*" -6529- MOVE 9999999 TO V0SICB-NRMATRVEN */
            _.Move(9999999, V0SICB_NRMATRVEN);

            /*" -6530- MOVE COBRAN-AGE-INDIC TO V0SICB-AGECTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_41.COBRAN_AGE_INDIC, V0SICB_AGECTAVEN);

            /*" -6531- MOVE COBRAN-OPER-INDIC TO V0SICB-OPRCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_41.COBRAN_OPER_INDIC, V0SICB_OPRCTAVEN);

            /*" -6532- MOVE COBRAN-CC-INDIC TO V0SICB-NUMCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_41.COBRAN_CC_INDIC, V0SICB_NUMCTAVEN);

            /*" -6533- MOVE COBRAN-DIG-INDIC TO V0SICB-DIGCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_41.COBRAN_DIG_INDIC, V0SICB_DIGCTAVEN);

            /*" -6534- MOVE COBRAN-DESPESAS TO V0SICB-VLCOMIS */
            _.Move(COBRAN_REGISTRO.COBRAN_DESPESAS, V0SICB_VLCOMIS);

            /*" -6536- ADD COBRAN-ABATIMENTO TO V0SICB-VLCOMIS. */
            V0SICB_VLCOMIS.Value = V0SICB_VLCOMIS + COBRAN_REGISTRO.COBRAN_ABATIMENTO;

            /*" -6536- PERFORM R8850-00-INSERT-V0COMISICOB. */

            R8850_00_INSERT_V0COMISICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8800_99_SAIDA*/

        [StopWatch]
        /*" R8850-00-INSERT-V0COMISICOB-SECTION */
        private void R8850_00_INSERT_V0COMISICOB_SECTION()
        {
            /*" -6547- MOVE '8850' TO WNR-EXEC-SQL. */
            _.Move("8850", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -6566- PERFORM R8850_00_INSERT_V0COMISICOB_DB_INSERT_1 */

            R8850_00_INSERT_V0COMISICOB_DB_INSERT_1();

            /*" -6569- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6570- DISPLAY 'R8850-00 - PROBLEMAS INSERT (V0COMISICOB)' */
                _.Display($"R8850-00 - PROBLEMAS INSERT (V0COMISICOB)");

                /*" -6570- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8850-00-INSERT-V0COMISICOB-DB-INSERT-1 */
        public void R8850_00_INSERT_V0COMISICOB_DB_INSERT_1()
        {
            /*" -6566- EXEC SQL INSERT INTO SEGUROS.V0COMIS_SICOB VALUES (:V0SICB-CODEMP , :V0SICB-FONTE , :V0SICB-NRRCAP , :V0SICB-NUMBIL , :V0SICB-AGECOBR , :V0SICB-NRMATRVEN , :V0SICB-AGECTAVEN , :V0SICB-OPRCTAVEN , :V0SICB-NUMCTAVEN , :V0SICB-DIGCTAVEN , :V0SICB-VLCOMIS , :V0SICB-DTCREDITO , :V0SICB-DTQITBCO , :V0SICB-DTMOVTO , :V0SICB-VLRCAP , :V0SICB-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

            var r8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1 = new R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1()
            {
                V0SICB_CODEMP = V0SICB_CODEMP.ToString(),
                V0SICB_FONTE = V0SICB_FONTE.ToString(),
                V0SICB_NRRCAP = V0SICB_NRRCAP.ToString(),
                V0SICB_NUMBIL = V0SICB_NUMBIL.ToString(),
                V0SICB_AGECOBR = V0SICB_AGECOBR.ToString(),
                V0SICB_NRMATRVEN = V0SICB_NRMATRVEN.ToString(),
                V0SICB_AGECTAVEN = V0SICB_AGECTAVEN.ToString(),
                V0SICB_OPRCTAVEN = V0SICB_OPRCTAVEN.ToString(),
                V0SICB_NUMCTAVEN = V0SICB_NUMCTAVEN.ToString(),
                V0SICB_DIGCTAVEN = V0SICB_DIGCTAVEN.ToString(),
                V0SICB_VLCOMIS = V0SICB_VLCOMIS.ToString(),
                V0SICB_DTCREDITO = V0SICB_DTCREDITO.ToString(),
                V0SICB_DTQITBCO = V0SICB_DTQITBCO.ToString(),
                V0SICB_DTMOVTO = V0SICB_DTMOVTO.ToString(),
                V0SICB_VLRCAP = V0SICB_VLRCAP.ToString(),
                V0SICB_SITUACAO = V0SICB_SITUACAO.ToString(),
            };

            R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1.Execute(r8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8850_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -6581- DISPLAY ' ' */
            _.Display($" ");

            /*" -6582- DISPLAY 'PF0002B - FIM NORMAL' . */
            _.Display($"PF0002B - FIM NORMAL");

            /*" -6583- DISPLAY ' ' */
            _.Display($" ");

            /*" -6584- DISPLAY 'LIDOS COBRANCA ........ ' LD-COBRANCA */
            _.Display($"LIDOS COBRANCA ........ {WS_AUX_ARQUIVO.LD_COBRANCA}");

            /*" -6585- DISPLAY 'DESPREZADOS COBRANCA .. ' DP-COBRANCA */
            _.Display($"DESPREZADOS COBRANCA .. {WS_AUX_ARQUIVO.DP_COBRANCA}");

            /*" -6586- DISPLAY 'OUTRAS COBRANCAS ...... ' NP-COBRANCA */
            _.Display($"OUTRAS COBRANCAS ...... {WS_AUX_ARQUIVO.NP_COBRANCA}");

            /*" -6587- DISPLAY 'MOVIMENTO   COBRANCA .. ' DE-COBRANCA */
            _.Display($"MOVIMENTO   COBRANCA .. {WS_AUX_ARQUIVO.DE_COBRANCA}");

            /*" -6588- DISPLAY 'ALTERA MOVIMENTO ...... ' UP-MOVICOB */
            _.Display($"ALTERA MOVIMENTO ...... {WS_AUX_ARQUIVO.UP_MOVICOB}");

            /*" -6589- DISPLAY 'INSERIDOS COBRANCA .... ' IN-COBRANCA */
            _.Display($"INSERIDOS COBRANCA .... {WS_AUX_ARQUIVO.IN_COBRANCA}");

            /*" -6590- DISPLAY ' ' */
            _.Display($" ");

            /*" -6591- DISPLAY 'CONVERSAO SIVPF ....... ' IN-CONVERSAO */
            _.Display($"CONVERSAO SIVPF ....... {WS_AUX_ARQUIVO.IN_CONVERSAO}");

            /*" -6592- DISPLAY 'COBRANCA GRAFICA ...... ' AC-GRAFICA */
            _.Display($"COBRANCA GRAFICA ...... {WS_AUX_ARQUIVO.AC_GRAFICA}");

            /*" -6593- DISPLAY 'COBRANCA GRAFICA (DP) . ' DP-GRAFICA */
            _.Display($"COBRANCA GRAFICA (DP) . {WS_AUX_ARQUIVO.DP_GRAFICA}");

            /*" -6594- DISPLAY 'SALVA TITULO ZERO ..... ' AC-SALVA */
            _.Display($"SALVA TITULO ZERO ..... {WS_AUX_ARQUIVO.AC_SALVA}");

            /*" -6595- DISPLAY 'SALVA TITULO 114-4 .... ' AC-SALVA1 */
            _.Display($"SALVA TITULO 114-4 .... {WS_AUX_ARQUIVO.AC_SALVA1}");

            /*" -6596- DISPLAY 'TRATA CEDENTE 114-4 ... ' AC-CED1144. */
            _.Display($"TRATA CEDENTE 114-4 ... {WS_AUX_ARQUIVO.AC_CED1144}");

            /*" -6597- DISPLAY 'DESPREZA CANAL 114-4 .. ' DP-CAN1144. */
            _.Display($"DESPREZA CANAL 114-4 .. {WS_AUX_ARQUIVO.DP_CAN1144}");

            /*" -6598- DISPLAY 'DESPREZA AGENC 114-4 .. ' DP-AGE1144. */
            _.Display($"DESPREZA AGENC 114-4 .. {WS_AUX_ARQUIVO.DP_AGE1144}");

            /*" -6599- DISPLAY 'DESPREZA SFRC  114-4 .. ' DP-SFR1144. */
            _.Display($"DESPREZA SFRC  114-4 .. {WS_AUX_ARQUIVO.DP_SFR1144}");

            /*" -6600- DISPLAY ' ' */
            _.Display($" ");

            /*" -6601- DISPLAY 'V0RCAP ................ ' IN-V0RCAP */
            _.Display($"V0RCAP ................ {WS_AUX_ARQUIVO.IN_V0RCAP}");

            /*" -6602- DISPLAY 'V0FOLLOWUP ............ ' IN-FOLLOWUP */
            _.Display($"V0FOLLOWUP ............ {WS_AUX_ARQUIVO.IN_FOLLOWUP}");

            /*" -6603- DISPLAY ' ' */
            _.Display($" ");

            /*" -6604- DISPLAY 'INSERT DESPESAS ....... ' AC-INSERT */
            _.Display($"INSERT DESPESAS ....... {WS_AUX_ARQUIVO.AC_INSERT}");

            /*" -6605- DISPLAY ' ' */
            _.Display($" ");

            /*" -6606- DISPLAY 'TRATA OPCAO VIDAZUL ... ' TT-OPCAO */
            _.Display($"TRATA OPCAO VIDAZUL ... {WS_AUX_ARQUIVO.TT_OPCAO}");

            /*" -6607- DISPLAY 'DESPR OPCAO VIDAZUL ... ' DP-OPCAO */
            _.Display($"DESPR OPCAO VIDAZUL ... {WS_AUX_ARQUIVO.DP_OPCAO}");

            /*" -6608- DISPLAY ' ' */
            _.Display($" ");

            /*" -6611- DISPLAY 'PF0002B - FIM NORMAL' . */
            _.Display($"PF0002B - FIM NORMAL");

            /*" -6614- CLOSE MOVIMENTO-COBRANCA PF0002B1. */
            MOVIMENTO_COBRANCA.Close();
            PF0002B1.Close();

            /*" -6614- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -6619- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -6619- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9800_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -6627- MOVE V0SIST-DTMOVABE TO WDATA-REL */
            _.Move(V0SIST_DTMOVABE, WS_AUX_DATAS.WDATA_REL);

            /*" -6628- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(WS_AUX_DATAS.FILLER_16.WDAT_REL_DIA, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -6629- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(WS_AUX_DATAS.FILLER_16.WDAT_REL_MES, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -6632- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(WS_AUX_DATAS.FILLER_16.WDAT_REL_ANO, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -6633- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -6634- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6635- DISPLAY '*   PF0002B - PROCESSA FITA RETORNO SIVPF  *' */
            _.Display($"*   PF0002B - PROCESSA FITA RETORNO SIVPF  *");

            /*" -6636- DISPLAY '*   -------   -------- ---- ------- -----  *' */
            _.Display($"*   -------   -------- ---- ------- -----  *");

            /*" -6637- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6638- DISPLAY '*    NAO HOUVE MOVIMENTACAO NESTA DATA     *' */
            _.Display($"*    NAO HOUVE MOVIMENTACAO NESTA DATA     *");

            /*" -6640- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {WS_AUX_DATAS.WDAT_REL_LIT}                   *"
            .Display();

            /*" -6641- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6641- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-COM-ERRO-SECTION */
        private void R9900_00_ENCERRA_COM_ERRO_SECTION()
        {
            /*" -6653- MOVE V0SIST-DTMOVABE TO WDATA-REL */
            _.Move(V0SIST_DTMOVABE, WS_AUX_DATAS.WDATA_REL);

            /*" -6654- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(WS_AUX_DATAS.FILLER_16.WDAT_REL_DIA, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -6655- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(WS_AUX_DATAS.FILLER_16.WDAT_REL_MES, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -6658- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(WS_AUX_DATAS.FILLER_16.WDAT_REL_ANO, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -6659- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -6660- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6661- DISPLAY '*   PF0002B - PROCESSA FITA RETORNO SIVPF  *' */
            _.Display($"*   PF0002B - PROCESSA FITA RETORNO SIVPF  *");

            /*" -6662- DISPLAY '*   -------   -------- ---- ------- -----  *' */
            _.Display($"*   -------   -------- ---- ------- -----  *");

            /*" -6663- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6664- DISPLAY '*    PROCESSAMENTO COM ERRO NESTA DATA     *' */
            _.Display($"*    PROCESSAMENTO COM ERRO NESTA DATA     *");

            /*" -6666- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {WS_AUX_DATAS.WDAT_REL_LIT}                   *"
            .Display();

            /*" -6667- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6670- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -6673- CLOSE MOVIMENTO-COBRANCA PF0002B1. */
            MOVIMENTO_COBRANCA.Close();
            PF0002B1.Close();

            /*" -6673- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -6677- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -6677- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -6685- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WS_AUX_AVISO.WABEND.WSQLCODE);

            /*" -6686- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WS_AUX_AVISO.WABEND.WSQLERRD1);

            /*" -6687- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WS_AUX_AVISO.WABEND.WSQLERRD2);

            /*" -6689- DISPLAY WABEND. */
            _.Display(WS_AUX_AVISO.WABEND);

            /*" -6692- CLOSE MOVIMENTO-COBRANCA PF0002B1. */
            MOVIMENTO_COBRANCA.Close();
            PF0002B1.Close();

            /*" -6692- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -6696- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -6696- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}