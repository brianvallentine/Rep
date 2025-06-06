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
using Sias.VidaAzul.DB2.VA6005B;

namespace Code
{
    public class VA6005B
    {
        public bool IsCall { get; set; }

        public VA6005B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES DE SEGURO (SASSE)         *      */
        /*"      *   PROGRAMA ...............  VA6005B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  WANGER C.SILVA / ALEXANDRE BURGOS  *      */
        /*"      *   PROGRAMADOR ............  ALEXANDRE BURGOS / ENRICO / WANGER *      */
        /*"      *   DATA CODIFICACAO .......  MARCO / 1995                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO MOVIMENTO DE BILHETES  *      */
        /*"      *                             (V0BILHETE), ATUALIZA O DB DE APO- *      */
        /*"      *                             LICES.                             *      */
        /*"      *                             PROGRAMA ESPECIFICO PARA:          *      */
        /*"      *                             RENOVACAO(VERSAO DO VA6005B).      *      */
        /*"      *                             O ID INTERNO FOI MANTIDO. ESTA     *      */
        /*"      *                             VERSAO NAO EH A DEFINITIVA.        *      */
        /*"      ******************************************************************      */
        /*"V.52  * VERSAO 52 ..: DEMANDA 538808 - PRODUTOS AP BEM ESTAR NO CCA    *      */
        /*"      *               8533 - AP BEM ESTAR - PU (12 MESES)              *      */
        /*"      *               8534 - AP BEM ESTAR - PU (36 MESES)              *      */
        /*"      *               (ESTES 2 PRODUTOS SAO COPIAS DO 8528 E 8529,     *      */
        /*"      *                APENAS FORAM CRIADOS PARA ATENDER CANAL CCA)    *      */
        /*"      *                                                                *      */
        /*"      * EM 04/09/2024 - CANETTA              PROCURE POR V.52          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.51  *  VERSAO 51  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2024 - TERCIO CARVALHO/SERGIO LORETO                *      */
        /*"      *                                       PROCURE POR V.51         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.50  *  VERSAO 50  - DEMANDA 564.320                                  *      */
        /*"      *             - SUBSTITUIR A CHAMADA DA ROTINA FC0105S DA CAP    *      */
        /*"      *               PELA VG0105S                                     *      */
        /*"      *             - PORQUE A CAP ESTA DEIXANDO O MAINFRAME.          *      */
        /*"      *                                                                *      */
        /*"      *  EM 19/01/2024 - RAUL BASILI ROTTA                             *      */
        /*"      *                                        PROCURE POR V.50        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.49  * VERSAO 49 ..: DEMANDA 489284 - MEI (8530, 8531, 8532)          *      */
        /*"      * DATA .......: 27/12/2023                                       *      */
        /*"      * RESPONSAVEL.: CANETTA                             PROCURE V.49 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 48...: DEMANDA 507447                                   *      */
        /*"      *               SUBSTITUIR SITUACAO DE BILHETE '2' POR '0'       *      */
        /*"      * DATA .......: 19/10/2023                                       *      */
        /*"      * RESPONSAVEL.: BRICE HO                                         *      */
        /*"      *                                                   PROCURE V.48 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 47...: INCIDENTE 495312                                 *      */
        /*"      *               RENOVACAO NAO PREVISTA DE BILHETE PU.            *      */
        /*"      * DATA .......: 10/05/2023                                       *      */
        /*"      * RESPONSAVEL.: TERCIO CARVALHO                                  *      */
        /*"      *                                                   PROCURE V.47 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 46...: DEMANDA 306086/TAREFA 307030                     *      */
        /*"      *               CADASTRAR APOLICE CORRETOR COMO CAIXA SEGURIDADE *      */
        /*"      *               (25267) PARA PROPOSTAS COM PRODUTO XS2 E DATA DE *      */
        /*"      *               EMISSAO MAIOR IGUAL A 16/08/2021 E TIPO COMISSAO *      */
        /*"      *               = 1 (CORRETAGEM) QUE HOJE S�O TRATADOS PELO      *      */
        /*"      *               WIZ                                              *      */
        /*"      *             - CONFORME ORIENTACAO DO REINALDO N�O SERA PAGO    *      */
        /*"      *               CORRETAGEM PARA INDICADOR SE PRODUTO JV1 E DATA  *      */
        /*"      *               MAIOR IGUAL A 16/08/2021                         *      */
        /*"      * DATA .......: 16/08/2021                                       *      */
        /*"      * RESPONSAVEL.: HUSNI ALI HUSNI                                  *      */
        /*"      *                                                   PROCURE V.46 *      */
        /*"JV145 *----------------------------------------------------------------*      */
        /*"JV145 *VERSAO 45: JV1 DEMANDA 262179 - KINKAS 23/10/2020               *      */
        /*"JV145 *           EXCLUI APOLICES/PRODUTOS JV1 - FASE 2                *      */
        /*"JV145 *           - PROCURAR POR JV145                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV144 *VERSAO 44: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV144 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV144 *           - PROCURAR POR JV144                                 *      */
        /*"JV144 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 43 - HISTORIA SEM NUMERO                              *      */
        /*"      *             - ALTERACAO DO CODIGO DO PARCEIRO DA CAPITALIZACAO,*      */
        /*"      *               DE CAIXA SEGUROS (01) PARA CAIXA VIDA E          *      */
        /*"      *               PREVIDENCIA (03).                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/12/2019 - LUIZ FERNANDO GON�ALVES               X      *      */
        /*"      *                                        PROCURE POR V.43        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 42 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - CORRE��ES NAS ALTRERA��ES. NOVA DETERMINA��O.    *      */
        /*"=     *             - POR DETERMINA��O DE FERNAND�O A RENOVA��O SE FOR *      */
        /*"=     *               SERA NA MESMA EMPRESA DA EMISS�O DA APOLICE.     *      */
        /*"=     *               CVP/SEGURADORA  OU JV1.                          *      */
        /*"=     *             - Historia: 206622   TAREFA: 223152                *      */
        /*"=     *    EM 04/02/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 41 - HISTORIA 204146                                  *      */
        /*"      *             - retira vigencia da cobertura                     *      */
        /*"      *               (V0BILHETE_COBER)                                *      */
        /*"      *  03/06/2019 - clovis                                           *      */
        /*"      *                                        PROCURE POR  V.41       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 40 - HISTORIA 200604                                  *      */
        /*"      *             - ALTERAR PESQUISA NA BILHETE_COBERTURA            *      */
        /*"      *               (V0BILHETE_COBER)                                *      */
        /*"      *  14/05/2019 - HUSNI ALI HUSNI                                  *      */
        /*"      *                                        PROCURE POR JV.01       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 39 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - Historia: 181586.                                *      */
        /*"=     *    EM 04/02/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 22/01/2019    RIBAMAR MARQUES (ALTRAN)     V.38  *      */
        /*"      *                                                                *      */
        /*"      *   HISTORIA 180290 - MUDANCAS DE PRODUTOS ACOPLADOS - CAP       *      */
        /*"      *                     PARA ATENDER A CIRCULAR SUSEP 569/576      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 13/09/2018    FRANK CARVALHO               V.37  *      */
        /*"      *                                                                *      */
        /*"      *   INCIDENTE 172.141 - ALTERAR O PLANO DE 810 PARA 818 PARA O   *      */
        /*"      *                   PRODUTO 8105. O PLANO 810 FOI INATIVADO.     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 01/06/2017    FRANK CARVALHO               V.36  *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 150867 - ALTERAR O PLANO DE 810 PARA 818 CONFORME     *      */
        /*"      *                   SOLICITACAO DA BU PARA OS PRODUTOS 8201 E    *      */
        /*"      *                   8104.                                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 11/07/2016    FRANK CARVALHO               V.35  *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 139687 - ABEND PRODUCAO - ERRO NO RETORNO DA FC0105S  *      */
        /*"      *                   PRODUTO 8201 NAO ESTA CADASTRADO NAS TABELAS *      */
        /*"      *                   DA CAP. PROGRAMA ALTERADO PARA NAO ABENDAR   *      */
        /*"      *                   CASO NAO COMPRE TITULO DE CAPITALIZACAO.     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 07/03/2016    ELIERMES OLIVEIRA            V.34  *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 132642 - ABEND PRODUCAO - ERRO NO RETORNO DA FC0105S  *      */
        /*"      *                   ALTERADO PARA NAO ABENDAR CASO NAO COMPRE    *      */
        /*"      *                   TITULO DE CAPITALIZACAO QUANDO O PRODUTO     *      */
        /*"      *                   ESTIVER COM STATUS INATIVO.                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 25/02/2016    CLOVIS                       V.33  *      */
        /*"      *                                                                *      */
        /*"      *   LIBERA RENOVACAO DO RAMO 37                                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 32 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.32         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 17/12/2014    RIBAMAR MARQUES              V.14  *      */
        /*"      *                             CORRIGIR ABEND - TEMPO EXCEDIDO    *      */
        /*"      *   CADMUS 107272- ABEND PRODUCAO - TEMPO EXCEDIDO               *      */
        /*"      *   RECUPERADA A VERSAO ANTERIOR (V.13) PARA SOLUCIONAR PROBLEMA.*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 30/04/2014    CLOVIS                       V.13  *      */
        /*"      *                             PREMIO EMITIDO DE FORMA INCORRETA  *      */
        /*"      *   BUSCA PREMIO TOTAL NA  SEGUROS.V0BILHETE_COBER               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 25/04/2014    CLOVIS                       V.12  *      */
        /*"      *                             CADMUS 97186 - IOF ZERO            *      */
        /*"      *   PESQUISA IOF NA TABELA SEGUROS.RAMO_COMPLEMENTAR             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 95.972                                       *      */
        /*"      *                                                                *      */
        /*"      *           ATENDIMENTO DA CIRC-SUSEP 360:                       *      */
        /*"      *           DATA DA PROPOSTA NAO PODE SER MAIOR QUE A DATA       *      */
        /*"      *           DE INICIO DE VIGENCIA NA TABELA DE ENDOSSOS          *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/04/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 08/10/2012    CLOVIS                       V.10  *      */
        /*"      *                             ALTERACAO REGRA COMISSIONAMENTO    *      */
        /*"      *                             EVOGEPES 016-2012 DIRVI/SUCOM      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 74.744                                       *      */
        /*"      *                                                                *      */
        /*"      *           CORRECAO DO ABEND SQLCODE = -811                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/09/2012 - FAST COMPUTER - CLAUDIO FREITAS              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NOVA VERSAO DO SISTEMA                                         *      */
        /*"      *                                                                *      */
        /*"      *   SUBSTITUIDA A TABELA V0MOVIBIL PELA V0BILHETE                *      */
        /*"      *   EMITE-SE UMA APOLICE COLETIVA PARA CADA RAMO+OPCAO           *      */
        /*"      *   GERA O ADIANTAMENTO DE COMISSAO DA FENAE                     *      */
        /*"      *   ELIMINADA A GERACAO DE V0CLIENTE E V0ENDERECO (CB0006B)      *      */
        /*"      *   ELIMINADA A GERACAO DE TABELAS DO VG/APC                     *      */
        /*"      *   ELIMINADA A GERACAO DA V0OUTROS_COBER                        *      */
        /*"      *                                                                *      */
        /*"      *                                              FONSECA - NOV/96  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   A VERSAO DE APOLICE COLETIVA NAO FOI IMPLANTADA.             *      */
        /*"      *   O PROGRAMA EMITE UMA APOLICE PARA CADA BILHETE,              *      */
        /*"      *     BAIXANDO O RCAP CORRESPONDENTE                             *      */
        /*"      *                                                                *      */
        /*"      *                                              FONSECA - JAN/97  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   AGENCIA NAO CADASTRADA VER CL001.                            *      */
        /*"      *                                                                *      */
        /*"      *                                              CLOVIS  - 21/07/98*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   23/11/1998                CLOVIS                             *      */
        /*"      *                             ALTERA V0AVISOS_SALDOS.            *      */
        /*"      *                             PROCURE CL9811.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   12/02/2000                TERCIO                             *      */
        /*"      *                             O PROGRAMA PASSA A NAO MAIS TRATAR *      */
        /*"      *                             POR FAIXA BILHETES ORIUDOS DO      *      */
        /*"      *                             SIVPF                              *      */
        /*"      *                             PROCURE TL0002.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   26/06/2000                LUIZ CARLOS                        *      */
        /*"      *   PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'ANA', AO *      */
        /*"      *   INVEZ DE 'REJ', CASO A PROPOSTA TENHA ALGUM ERRO.            *      */
        /*"      *                            PROCURE LC0600.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   28/08/2000                LUIZ CARLOS                        *      */
        /*"      *   PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'PEN', AO *      */
        /*"      *   INVEZ DE 'ANA', CASO A PROPOSTA TENHA ALGUM ERRO.            *      */
        /*"      *                            PROCURE LC0800.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 25/09/2000                                                *      */
        /*"      *   ALTERA COMISSAO FENAE PARA 0,5% DO PREMIO TOTAL.             *      */
        /*"      *   CORRETOR 17256 PARA DOCUMENTOS COM INICIO APOS 01/10/2000    *      */
        /*"      *                         PROCURE POR CL0900                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 12/08/2002                                                *      */
        /*"      *   PASSA A CRITICAR PRFISSAO DECLINAVEL.                        *      */
        /*"      *                         PROCURE POR TL0208                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 26/08/2002                                                *      */
        /*"      *   CRITICAR PROFISSAO DECLINAVEL SOMENTE PARA O RAMO 82.        *      */
        /*"      *                         PROCURE POR MM2608                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 26/09/2002                                                *      */
        /*"      *   NAO DEIXAR ABENDAR QUANDO A OPCAO DE COBERTURA ESTIVER ZERADA*      */
        /*"      *                         PROCURE POR MM2609                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 11/12/2003                                                *      */
        /*"      *   SUBSTITUIDA A LEITURA NA V0APOLICE (R3270), POIS, EM ALGUNS  *      */
        /*"      *   CASOS RETORNAVA COM SQLCODE -811 PELO BILHETE TER SIDO CADAS-*      */
        /*"      *   TRADO NO RAMO ERRADO (NESTE CASO RAMO 72).                   *      */
        /*"      *                         PROCURE POR MM1203                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 01/03/2004                                                *      */
        /*"      *   ALTERA COMISSAO FENAE PARA R$2,02 (FIXO).                    *      */
        /*"      *   CORRETOR 17256 PARA DOCUMENTOS COM QUITACAO                  *      */
        /*"      *                  A PARTIR DE 01/12/2003.                       *      */
        /*"      *                         PROCURE POR CL0304                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 06/07/2006     LUCIA VIEIRA                               *      */
        /*"      *                                                                *      */
        /*"      *   CORRIGE ABEND ATENDENDO SSI 10366  PROCURAR POR L.V          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 14/07/2006     LUCIA VIEIRA                               *      */
        /*"      *                                                                *      */
        /*"      *   CORRIGE ABEND DEVIDO SELECAO DE REGISTRO CURSOR CCBO         *      */
        /*"      *                                      PROCURAR POR LV0706       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 05/03/2009     CELIA SILVA                                *      */
        /*"      *                                                                *      */
        /*"      *   CORRIGE ABEND DEVIDO CALCULAR DATA DE RENOVACAO BASEADA EM   *      */
        /*"      *     29/02/2008  CADMUS 21595         PROCURAR POR MCS          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     01 - 17/07/09 - FAST COMPUTER -  ANDERSON OLIVEIRA         *      */
        /*"      *                                                                *      */
        /*"      *     PASSA A TRATAR RAMO 81 (PRODUTOS 8103 E 8104)              *      */
        /*"      *                                                                *      */
        /*"      *     CAD 27.011                    PROCURE POR V.01             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     02 - 19/08/09 - FAST COMPUTER -  EDIVALDO GOMES            *      */
        /*"      *                                                                *      */
        /*"      *     AJUSTE DE CRITICAS PARA RENOVACAO DE BILHETES              *      */
        /*"      *                                                                *      */
        /*"      *     CAD 28.552                    PROCURE POR V.02             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - CAD 32.919                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PARAMETRIZACAO DO CALCULO DE COMISSAO          *      */
        /*"      *                 PARA O BILHETE AP (8104)                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2009 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CAD 33.936                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE NO CALCULO PARA BILHETE AP(8104).       *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/12/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 39.036                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PROCESSA OS BILHETES CANAL ATM                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/05/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 201.084                                      *      */
        /*"      *                                                                *      */
        /*"      *               - ALTERA O PLANO DE CAPITALIZACAO DE 810 PARA    *      */
        /*"      *                 PARA 818.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/07/2011 - FAST COMPUTER - BRUNO RIBEIRO                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - CAD 64.999                                       *      */
        /*"      *                                                                *      */
        /*"      *           ADAPTAR OS PROGRAMAS DE VIDA PARA UTILIZAREM A NOVA  *      */
        /*"      *           ROTINA DE COMPRA DA CAP QUE SOFREU ALTERACAO,        *      */
        /*"      *           MODIFICANDO A CHAMADA DA ROTINA FC0105B PARA FC0105  *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/12/2011 - FAST COMPUTER - ROGERIO PEREIRA              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD 65.522                                       *      */
        /*"      *                                                                *      */
        /*"      *           PASSA A TRATAR O CODIGO DA EMPRESA O ACESSO  A       *      */
        /*"      *           SEGUROS.BILHETE_COBERTURA PARA DISTINGUIR OS         *      */
        /*"      *           PRODUTOS DE REDE COM OS DE EXTRA-REDE.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/01/2012 - FAST COMPUTER - TERCIO CARVALHO              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * FONTES PRODUTORAS                   V1FONTE           I-O      *      */
        /*"      * FUNCIONARIOS CEF                    V0FUNCIOCEF       I-O      *      */
        /*"      * APOLICES                            V0APOLICE         I-O      *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         OUTPUT   *      */
        /*"      * APOLICE CORRETOR                    V0APOLCORRET      OUTPUT   *      */
        /*"      * COSSEGURO PRODUTO                   V1COSSEGPROD      INPUT    *      */
        /*"      * APOLICE COSSEGURO CEDIDO            V0APOLCOSCED      OUTPUT   *      */
        /*"      * PARCELAS                            V0PARCELA         OUTPUT   *      */
        /*"      * HISTORICO DE PARCELAS               V0HISTOPARC       OUTPUT   *      */
        /*"      * COBERTURA APOLICES                  V0COBERAPOL       OUTPUT   *      */
        /*"      * RECIBO PROVISORIO                   V0RCAP            I-O      *      */
        /*"      * RECIBO PROVISORIO COMPLEMENTAR      V0RCAPCOMP        I-O      *      */
        /*"      * ORDEM COSSEGURO CEDIDO              V0ORDECOSCED      OUTPUT   *      */
        /*"      * NUMERO OUTROS                       V0NUMERO_OUTROS   I-O      *      */
        /*"      * NUMERACAO GERAL                     V0NUMERO_AES      I-O      *      */
        /*"      * COMISSAO FENAE                      V0COMISSAO_FENAE  I-O      *      */
        /*"      * COMISSAO_ADIANTA                    V0ADIANTA         OUTPUT   *      */
        /*"      * FORMA_RECUPERACAO                   V0FORMAREC        OUTPUT   *      */
        /*"      * HISTORICO_RECUPERACAO               V0HISTOREC        OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           12/09/1998  *      */
        /*"      *                                                                *      */
        /*"      *    29/12/98 - CONSEDA4                                         *      */
        /*"      *    ALTERACAO DO CALCULO DO IOF - ACESSO A TABELA V2RAMO        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WS-COD-PRODUTO      PIC S9(004)      COMP-5 VALUE 0.*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NUM-BIL-ANT   PIC S9(015)      COMP-3 VALUE +0.*/
        public IntBasis WHOST_NUM_BIL_ANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         W77-DECIMAL         PIC  9(015)      VALUE ZEROS.*/
        public IntBasis W77_DECIMAL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"77         W77-DECIMAL-D1      PIC  9(008),99   VALUE ZEROS.*/
        public DoubleBasis W77_DECIMAL_D1 { get; set; } = new DoubleBasis(new PIC("9", "8", "9(008)V99"), 2);
        /*"77         W77-SMALLINT-D1     PIC  9(004)      VALUE ZEROS.*/
        public IntBasis W77_SMALLINT_D1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77         W77-SMALLINT-D2     PIC  9(004)      VALUE ZEROS.*/
        public IntBasis W77_SMALLINT_D2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77         FILLER              PIC  X(001)      VALUE SPACES.*/

        public SelectorBasis FILLER_0 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88         W88-REPETIR                        VALUE '0'. */
							new SelectorItemBasis("W88_REPETIR", "0"),
							/*" 88         W88-NAO-REPETIR                    VALUE '1'. */
							new SelectorItemBasis("W88_NAO_REPETIR", "1")
                }
        };

        /*"77         FILLER              PIC  X(001)      VALUE SPACES.*/

        public SelectorBasis FILLER_1 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88         W88-LIGAR-TRACE                    VALUE '0'. */
							new SelectorItemBasis("W88_LIGAR_TRACE", "0"),
							/*" 88         W88-DESLIGAR-TRACE                 VALUE '1'. */
							new SelectorItemBasis("W88_DESLIGAR_TRACE", "1")
                }
        };

        /*"77         WHOST-NRRCAP        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-SIT-PROP-SIVPF PIC X(003).*/
        public StringBasis WHOST_SIT_PROP_SIVPF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         WHOST-NUMOPG        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUMREC        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUMBIL        PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis WHOST_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WWORK-RAMO-ANT      PIC S9(004)                COMP.*/
        public IntBasis WWORK_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WWORK-OPCAO-ANT     PIC S9(004)                COMP.*/
        public IntBasis WWORK_OPCAO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WWORK-MIN-DTINIVIG  PIC X(010).*/
        public StringBasis WWORK_MIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WWORK-MAX-DTTERVIG  PIC X(010).*/
        public StringBasis WWORK_MAX_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WS-INDICA-NULL      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis WS_INDICA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMPRESA    PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DATARCAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DATARCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTQITBCO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTVENCTO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLCUSEMI       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VLCUSEMI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CFPREFIX       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CFPREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-ANGAR      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_COD_ANGAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SITUACAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_SITUACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTLIBER        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PRMTOTAL       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PRMTOTAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVACB     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVACB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    CBO-COD-CBO               PIC S9(004)    COMP.*/
        public IntBasis CBO_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    CBO-DESCR-CBO             PIC  X(050).*/
        public StringBasis CBO_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"77    PESSOA-FISICA-COD-CBO     PIC S9(004)    COMP.*/
        public IntBasis PESSOA_FISICA_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-COD-PESSOA       PIC S9(009)    COMP.*/
        public IntBasis PRPFIDEL_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SIVPF-SIT-PROPOSTA PIC  X(003)     VALUE    SPACES.*/
        public StringBasis V0SIVPF_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77         V0CONV-NUM-SICOB     PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis V0CONV_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CONV-NUM-PROPOSTA-SIVPF PIC S9(015) VALUE +0 COMP-3*/
        public IntBasis V0CONV_NUM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1BILH-NUMBIL       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0BILH-NUMBIL       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0BILH-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-AGECOBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-NUM-MATR     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUM_MATR { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0BILH-AGENCIA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0BILH_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0BILH-PROFISSAO    PIC  X(020).*/
        public StringBasis V0BILH_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V0BILH-NOME         PIC  X(040).*/
        public StringBasis V0BILH_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0BILH-CGCCPF       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0BILH-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-NUMCTA-DEB   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0BILH-DIGCTA-DEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-OPCAO-COBER  PIC S9(004)               COMP.*/
        public IntBasis V0BILH_OPCAO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-DTA-VENDA    PIC  X(010).*/
        public StringBasis V0BILH_DTA_VENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BILH-DTQITBCO     PIC  X(010).*/
        public StringBasis V0BILH_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BILH-VLRCAP       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0BILH_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0BILH-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-SITUACAO     PIC  X(001).*/
        public StringBasis V0BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0BILH-CODUSU       PIC  X(008).*/
        public StringBasis V0BILH_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0BILH-NUM-APO-ANT  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUM_APO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COFE-COD-EMPR     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1COFE_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COFE-NUMBIL       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1COFE_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1COFE-AGECOBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-VALADT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V1COFE_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1COFE-DTCRED-ADT   PIC  X(010).*/
        public StringBasis V1COFE_DTCRED_ADT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COFE-NUM-MATR     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1COFE_NUM_MATR { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1COFE-AGENCIA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-OPERACAO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-NUMCTA       PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V1COFE_NUMCTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COFE-DIGCTA       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_DIGCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-NUMCTA-DEB   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V1COFE_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COFE-DIGCTA-DEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-NOME-SIND    PIC  X(040).*/
        public StringBasis V1COFE_NOME_SIND { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1COFE-DTQITBCO     PIC  X(010).*/
        public StringBasis V1COFE_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COFE-VLRCAP       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V1COFE_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1COFE-DTMOVTO      PIC  X(010).*/
        public StringBasis V1COFE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COFE-SITUACAO     PIC  X(001).*/
        public StringBasis V1COFE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COFE-NUMBIL       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0COFE_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0COFE-AGECOBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-NUM-MATR     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0COFE_NUM_MATR { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0COFE-AGENCIA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-OPERACAO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-NUMCTA       PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0COFE_NUMCTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COFE-DIGCTA       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_DIGCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-NUMCTA-DEB   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0COFE_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COFE-DIGCTA-DEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-NOME-SIND    PIC  X(040).*/
        public StringBasis V0COFE_NOME_SIND { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0COFE-SITUACAO     PIC  X(001).*/
        public StringBasis V0COFE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COFE-VALADT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COFE_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1FONT-PROPAUTOM    PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RAMO-RAMO       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V1RAMO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1RCAP-DATARCAP     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V1RCAP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1PROD-CODPDT       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PROD_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROD-TIPO-PROD    PIC  X(001)       VALUE  SPACES.*/
        public StringBasis V1PROD_TIPO_PROD { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1PROD-ENDERECO     PIC  X(040).*/
        public StringBasis V1PROD_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1PROD-CIDADE       PIC  X(020).*/
        public StringBasis V1PROD_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V1BILP-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-COD-EMPR   PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1BILC_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1BILC-CODPRODU   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-RAMOFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-MODALIFR   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-OPCAO      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_OPCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-COBERTURA  PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-DTINIVIG   PIC  X(010).*/
        public StringBasis V1BILC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BILC-DTTERVIG   PIC  X(010).*/
        public StringBasis V1BILC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BILC-IDECOBER   PIC  X(001).*/
        public StringBasis V1BILC_IDECOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1BILC-IMPSEG-IX  PIC S9(013)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_IMPSEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"77         V1BILC-PRMTAR-IX  PIC S9(010)V9(005) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_PRMTAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(005)"), 5);
        /*"77         V1BILC-IOCC       PIC S9(010)V9(005) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(005)"), 5);
        /*"77         V1BILC-PRMTOTAL   PIC S9(013)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_PRMTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"77         V1BILC-CODUNIMO   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-PCCOMCOR   PIC S9(003)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(002)"), 2);
        /*"77         V1BILC-COBERBAS   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1BILC_COBERBAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILC-PCTMAX     PIC S9(003)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_PCTMAX { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(002)"), 2);
        /*"77         V1BILC-VALMAX     PIC S9(013)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_VALMAX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"77         V1BILC-PCIOCC     PIC S9(013)V9(002) VALUE +0 COMP-3.*/
        public DoubleBasis V1BILC_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"77         V1AGEN-AGENCIA      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AGEN_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CONG-CONGENER     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1CONG_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FUNC-NUM-MATRIC   PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V1FUNC_NUM_MATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1FUNC-NOME-FUN     PIC  X(040).*/
        public StringBasis V1FUNC_NOME_FUN { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1FUNC-ENDERECO     PIC  X(049).*/
        public StringBasis V1FUNC_ENDERECO { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
        /*"77         V1FUNC-CIDADE       PIC  X(022).*/
        public StringBasis V1FUNC_CIDADE { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
        /*"77         V1FUNC-SIGLA-UF     PIC  X(002).*/
        public StringBasis V1FUNC_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1FUNC-CEP          PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1FUNC_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FUNC-NUM-CPF      PIC S9(011)       VALUE +0 COMP-3*/
        public IntBasis V1FUNC_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
        /*"77         V1FUNC-COD-ANGAR    PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1FUNC_COD_ANGAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1NOUT-NUMCLIENTE   PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NOUT_NUMCLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1NOUT-CODANGAR     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NOUT_CODANGAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1NOUT-NUMCERVG     PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V1NOUT_NUMCERVG { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1NOUT-NUMOPG       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NOUT_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1NAES-SEQ-APOL     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NAES_SEQ_APOL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-SEQ-APOL     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0NAES_SEQ_APOL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COSP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COSP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSP-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COSP_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSP-CONGENER     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COSP_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSP-PCPARTIC     PIC S9(004)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1COSP_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1COSP-PCCOMCOS     PIC S9(003)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V1COSP_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1COSP-PCADMCOS     PIC S9(003)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V1COSP_PCADMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1COSP-DTINIVIG     PIC  X(010).*/
        public StringBasis V1COSP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COSP-DTTERVIG     PIC  X(010).*/
        public StringBasis V1COSP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COSP-SITUACAO     PIC  X(001).*/
        public StringBasis V1COSP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ACEF-COD-FONTE    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1ACEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ACEF-CODESCNEG    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1ACEF_CODESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SURG-PCDESISS     PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1SURG_PCDESISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1MCEF-COD-FONTE    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1MCEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILER-COD-ERRO    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0BILER_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APOL-NUMBIL       PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V1APOL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1APOL-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V1APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-CODCLIEN     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-NUM-ITEM     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOL_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-MODALIDA     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-ORGAO        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-RAMO         PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-NUM-APO-ANT  PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APOL_NUM_APO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-NUMBIL       PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V0APOL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0APOL-TIPSGU       PIC  X(001).*/
        public StringBasis V0APOL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-TIPAPO       PIC  X(001).*/
        public StringBasis V0APOL_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-TIPCALC      PIC  X(001).*/
        public StringBasis V0APOL_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-PODPUBL      PIC  X(001).*/
        public StringBasis V0APOL_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-NUM-ATA      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOL_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-ANO-ATA      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-IDEMAN       PIC  X(001).*/
        public StringBasis V0APOL_IDEMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-PCDESCON     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0APOL_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0APOL-PCIOCC       PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0APOL_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0APOL-TPCOSCED     PIC  X(001).*/
        public StringBasis V0APOL_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-QTCOSSEG     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-PCTCED       PIC S9(004)V9(05) VALUE +0 COMP-3*/
        public DoubleBasis V0APOL_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(05)"), 5);
        /*"77         V0APOL-DATA-SORT    PIC  X(010).*/
        public StringBasis V0APOL_DATA_SORT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOL-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APOL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APOL-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-TPCORRET     PIC  X(001).*/
        public StringBasis V0APOL_TPCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ENDO-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CODSUBES     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-DATPRO       PIC  X(010).*/
        public StringBasis V0ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DT-LIBER     PIC  X(010).*/
        public StringBasis V0ENDO_DT_LIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTEMIS       PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-VLRCAP       PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0ENDO-BCORCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGERCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACRCAP      PIC  X(001).*/
        public StringBasis V0ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-IDRCAP       PIC  X(001).*/
        public StringBasis V0ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACCOBR      PIC  X(001).*/
        public StringBasis V0ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CDFRACIO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-PCENTRAD     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PCADICIO     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PRESTA1      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPRESTA     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTITENS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODTXT       PIC  X(003).*/
        public StringBasis V0ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0ENDO-CDACEITA     PIC  X(001).*/
        public StringBasis V0ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-MOEDA-IMP    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-MOEDA-PRM    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V0ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-COD-USUAR    PIC  X(008).*/
        public StringBasis V0ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0ENDO-OCORR-END    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-SITUACAO     PIC  X(001).*/
        public StringBasis V0ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DATARCAP     PIC  X(010).*/
        public StringBasis V0ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CORRECAO     PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-ISENTA-CST   PIC  X(001).*/
        public StringBasis V0ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ENDO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0ENDO-DTVENCTO     PIC  X(010).*/
        public StringBasis V0ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CFPREFIX     PIC S9(004)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0ENDO-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0ENDO-RAMO         PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-INIVIG-ANT    PIC  X(010).*/
        public StringBasis V0ENDO_INIVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-TERVIG-ANT    PIC  X(010).*/
        public StringBasis V0ENDO_TERVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-COD-PRODU-ANT PIC S9(004) COMP VALUE 0.*/
        public IntBasis V0ENDO_COD_PRODU_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCAP-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCAP-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RCAP-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RCAP-NOME         PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0RCAP-VALPRI       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0RCAP-DTCADAST     PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RCAP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RCAP-SITUACAO     PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0RCAP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCAP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RCAP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0RCAP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0RCAP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0RCAP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RCAP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCAP-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V2RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V2RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1RCAC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAC-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RCAC-NRRCAPCO     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RCAC-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAC-DTMOVTO      PIC  X(010).*/
        public StringBasis V1RCAC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RCAC-HORAOPER     PIC  X(008).*/
        public StringBasis V1RCAC_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1RCAC-SITUACAO     PIC  X(001).*/
        public StringBasis V1RCAC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1RCAC-BCOAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAC-AGEAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAC-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RCAC-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAC_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1RCAC-DATARCAP     PIC  X(010).*/
        public StringBasis V1RCAC_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RCAC-DTCADAST     PIC  X(010).*/
        public StringBasis V1RCAC_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RCAC-SITCONTB     PIC  X(001).*/
        public StringBasis V1RCAC_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1RCAC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RCAC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1RCAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APCR-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APCR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCR-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCR_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCR-MODALIFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCR_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCR-CODCORR      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APCR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCR-CODSUBES     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCR_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCR-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APCR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCR-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APCR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCR-PCPARCOR     PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0APCR_PCPARCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0APCR-PCCOMCOR     PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0APCR_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0APCR-TIPCOM       PIC  X(001).*/
        public StringBasis V0APCR_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APCR-INDCRT       PIC  X(001).*/
        public StringBasis V0APCR_INDCRT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APCR-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APCR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCR-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APCR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APCR-COD-USUARIO  PIC  X(008).*/
        public StringBasis V0APCR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1APCR-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V1APCR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1APCR-CODCORR      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1APCR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCC-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APCC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCC-CODCOSS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCC-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCC_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCC-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APCC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCC-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APCC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCC-PCPARTIC     PIC S9(004)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0APCC_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0APCC-PCCOMCOS     PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0APCC_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0APCC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APCC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APCC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1NCOS-CONGENER     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1NCOS-ORGAO        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1NCOS-NRORDEM      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-DACPARC      PIC  X(001).*/
        public StringBasis V0PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-VAL-DES-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNPRLIQ     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNADFRA     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNCUSTO     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNIOF       PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNTOTAL     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-QTDDOC       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PARC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0PARC-SIT-COBR     PIC  X(001).*/
        public StringBasis V0PARC_SIT_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-DACPARC      PIC  X(001).*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-HORAOPER     PIC  X(008).*/
        public StringBasis V0HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISP-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-PRM-TARIFA   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_PRM_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VAL-DESCON   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VAL_DESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLPRMLIQ     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLADIFRA     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLIOCC       PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLPRMTOT     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-VLPREMIO     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRENDOCA     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-COD-USUAR    PIC  X(008).*/
        public StringBasis V0HISP_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISP-RNUDOC       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0HISP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0COBA-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COBA-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-NUM-ITEM     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-MODALIFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-COD-COBER    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-IMP-SEG-IX   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-IMP-SEG-VR   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-VR   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PCT-COBERT   PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0COBA-FATOR-MULT   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0COBA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0COBA-SITUACAO     PIC  X(001)       VALUE '0'.*/
        public StringBasis V0COBA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
        /*"77         V0ORDC-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ORDC-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ORDC-CODCOSS      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ORDC-ORDEM-CED    PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_ORDEM_CED { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0ORDC-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ORDC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ORDC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1CROT-CGCCPF       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1CROT_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1CROT-BILH-AP      PIC  X(001).*/
        public StringBasis V1CROT_BILH_AP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CROT-BILH-RES     PIC  X(001).*/
        public StringBasis V1CROT_BILH_RES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CROT-BILH-VDAZUL  PIC  X(001).*/
        public StringBasis V1CROT_BILH_VDAZUL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CROT-DTMOVABE     PIC  X(010).*/
        public StringBasis V1CROT_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CROT-CGCCPF       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0CROT_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CROT-BILH-AP      PIC  X(001).*/
        public StringBasis V0CROT_BILH_AP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CROT-BILH-RES     PIC  X(001).*/
        public StringBasis V0CROT_BILH_RES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CROT-BILH-VDAZUL  PIC  X(001).*/
        public StringBasis V0CROT_BILH_VDAZUL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CROT-DTMOVABE     PIC  X(010).*/
        public StringBasis V0CROT_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBI-COD-ESCNEG   PIC S9(004) COMP.*/
        public IntBasis V1COBI_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBI-RAMO         PIC S9(004) COMP.*/
        public IntBasis V1COBI_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBI-DTINIVIG     PIC  X(010).*/
        public StringBasis V1COBI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBI-COBERTURA1   PIC  X(001).*/
        public StringBasis V1COBI_COBERTURA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COBI-COBERTURA2   PIC  X(001).*/
        public StringBasis V1COBI_COBERTURA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COBI-COBERTURA3   PIC  X(001).*/
        public StringBasis V1COBI_COBERTURA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0C396-NUMBIL     PIC S9(015)    COMP-3 VALUE  ZEROS.*/
        public IntBasis V0C396_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0C396-DTMOVTO    PIC  X(010)           VALUE SPACES.*/
        public StringBasis V0C396_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0C396-SITUACAO   PIC  X(001)           VALUE SPACES.*/
        public StringBasis V0C396_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V0C396-TIMESTAMP  PIC  X(026)           VALUE SPACES.*/
        public StringBasis V0C396_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"77         V0ADIA-CODPDT        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-FONTE         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ADIA-NUMOPG        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-VALADT        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0ADIA_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0ADIA-QTPRESTA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ADIA-NRPROPOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-NUM-APOL      PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0ADIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ADIA-NRENDOS       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-NRPARCEL      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ADIA-DTMOVTO       PIC  X(010).*/
        public StringBasis V0ADIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ADIA-SITUACAO      PIC  X(001).*/
        public StringBasis V0ADIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ADIA-COD-EMP       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0ADIA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0ADIA-TIPO-ADT      PIC  X(001).*/
        public StringBasis V0ADIA_TIPO_ADT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FORM-CODPDT        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-FONTE         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0FORM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FORM-NUMOPG        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-NRPROPOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-NUM-APOL      PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0FORM_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FORM-NRENDOS       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-NRPARCEL      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FORM-NUMPTC        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FORM-VALRCP        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0FORM_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FORM-PCGACM        PIC S9(002)V9(3) VALUE +0 COMP-3*/
        public DoubleBasis V0FORM_PCGACM { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(3)"), 3);
        /*"77         V0FORM-SITUACAO      PIC  X(001).*/
        public StringBasis V0FORM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FORM-VALSDO        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0FORM_VALSDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FORM-DTMOVTO       PIC  X(010).*/
        public StringBasis V0FORM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FORM-DTVENCTO      PIC  X(010).*/
        public StringBasis V0FORM_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FORM-COD-EMP       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0FORM_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0HISR-CODPDT        PIC S9(009)               COMP.*/
        public IntBasis V0HISR_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-FONTE         PIC S9(004)               COMP.*/
        public IntBasis V0HISR_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-NUMOPG        PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-NRPROPOS      PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V0HISR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISR-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-NRPARCEL      PIC S9(004)               COMP.*/
        public IntBasis V0HISR_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-NUMPTC        PIC S9(004)               COMP.*/
        public IntBasis V0HISR_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-VALRCP        PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISR_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISR-NUMREC        PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-DTMOVTO       PIC  X(010).*/
        public StringBasis V0HISR_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISR-OPERACAO      PIC S9(004)               COMP.*/
        public IntBasis V0HISR_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-HORSIS        PIC  X(008).*/
        public StringBasis V0HISR_HORSIS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISR-COD-EMP       PIC S9(009)               COMP.*/
        public IntBasis V0HISR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0HISR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0BILFX-VERSAO       PIC S9(004)               COMP.*/
        public IntBasis V0BILFX_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILFX-VALADT       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0BILFX_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PROE-CODPRODU      PIC S9(004)               COMP.*/
        public IntBasis V0PROE_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         PROD-COD-EMPRESA     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PROD_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         PROD-COD-PRODUTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PROD_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         PARM-COD-EMPR-CAP    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PARM_COD_EMPR_CAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WORK-JV1.*/
        public VA6005B_WORK_JV1 WORK_JV1 { get; set; } = new VA6005B_WORK_JV1();
        public class VA6005B_WORK_JV1 : VarBasis
        {
            /*" 05 WH-JV1-COD-ORGAO                 PIC S9(004) COMP-5 VALUE +0*/
            public IntBasis WH_JV1_COD_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TAB-CBO1.*/
        }
        public VA6005B_TAB_CBO1 TAB_CBO1 { get; set; } = new VA6005B_TAB_CBO1();
        public class VA6005B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public VA6005B_TAB_CBO TAB_CBO { get; set; } = new VA6005B_TAB_CBO();
            public class VA6005B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<VA6005B_FILLER_2> FILLER_2 { get; set; } = new ListBasis<VA6005B_FILLER_2>(999);
                public class VA6005B_FILLER_2 : VarBasis
                {
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"01           WS-TIME.*/
                }
            }
        }
        public VA6005B_WS_TIME WS_TIME { get; set; } = new VA6005B_WS_TIME();
        public class VA6005B_WS_TIME : VarBasis
        {
            /*"  05         WS000-H            PIC  9(002).*/
            public IntBasis WS000_H { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-M            PIC  9(002).*/
            public IntBasis WS000_M { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-S            PIC  9(002).*/
            public IntBasis WS000_S { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-C            PIC  9(002).*/
            public IntBasis WS000_C { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WS000-HORA-TIME    PIC X(008).*/
        }
        public StringBasis WS000_HORA_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01           WS000-HORA-TIME-REDF    REDEFINES             WS000-HORA-TIME.*/
        private _REDEF_VA6005B_WS000_HORA_TIME_REDF _ws000_hora_time_redf { get; set; }
        public _REDEF_VA6005B_WS000_HORA_TIME_REDF WS000_HORA_TIME_REDF
        {
            get { _ws000_hora_time_redf = new _REDEF_VA6005B_WS000_HORA_TIME_REDF(); _.Move(WS000_HORA_TIME, _ws000_hora_time_redf); VarBasis.RedefinePassValue(WS000_HORA_TIME, _ws000_hora_time_redf, WS000_HORA_TIME); _ws000_hora_time_redf.ValueChanged += () => { _.Move(_ws000_hora_time_redf, WS000_HORA_TIME); }; return _ws000_hora_time_redf; }
            set { VarBasis.RedefinePassValue(value, _ws000_hora_time_redf, WS000_HORA_TIME); }
        }  //Redefines
        public class _REDEF_VA6005B_WS000_HORA_TIME_REDF : VarBasis
        {
            /*"  05         WS000-HT           PIC  9(002).*/
            public IntBasis WS000_HT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-P1           PIC  X(001).*/
            public StringBasis WS000_P1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         WS000-MT           PIC  9(002).*/
            public IntBasis WS000_MT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WS000-P2           PIC  X(001).*/
            public StringBasis WS000_P2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         WS000-ST           PIC  9(002).*/
            public IntBasis WS000_ST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WS000-PARM-PROSOMD1.*/

            public _REDEF_VA6005B_WS000_HORA_TIME_REDF()
            {
                WS000_HT.ValueChanged += OnValueChanged;
                WS000_P1.ValueChanged += OnValueChanged;
                WS000_MT.ValueChanged += OnValueChanged;
                WS000_P2.ValueChanged += OnValueChanged;
                WS000_ST.ValueChanged += OnValueChanged;
            }

        }
        public VA6005B_WS000_PARM_PROSOMD1 WS000_PARM_PROSOMD1 { get; set; } = new VA6005B_WS000_PARM_PROSOMD1();
        public class VA6005B_WS000_PARM_PROSOMD1 : VarBasis
        {
            /*"  05         WS000-DATA01       PIC  9(008).*/
            public IntBasis WS000_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         WS000-QTDIAS       PIC S9(005) COMP-3.*/
            public IntBasis WS000_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WS000-DATA02       PIC  9(008).*/
            public IntBasis WS000_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01         WS002-ACUMULADORES.*/
        }
        public VA6005B_WS002_ACUMULADORES WS002_ACUMULADORES { get; set; } = new VA6005B_WS002_ACUMULADORES();
        public class VA6005B_WS002_ACUMULADORES : VarBasis
        {
            /*"  05       WS002-IMP-SEG-IX  PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       WS002-IMP-SEG-VR  PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       WS002-PRM-TAR-IX  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05       WS002-PRM-TAR-VR  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"01     LK-PLANO                PIC S9(4)      USAGE COMP.*/
        }
        public IntBasis LK_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-SERIE                PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-TITULO               PIC S9(9)      USAGE COMP.*/
        public IntBasis LK_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01     LK-NUM-PROPOSTA         PIC S9(15)V    USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01     LK-QTD-TITULOS          PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-VLR-TITULO           PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"01     LK-PARCEIRO             PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_PARCEIRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-RAMO                 PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-COD-USUARIO          PIC  X(8).*/
        public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01     LK-NUM-NSA              PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-TRACE                PIC X(009).*/

        public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88   LK-TRACE-ON             VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88   LK-TRACE-OFF            VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
        };

        /*"01     LK-OUT-COD-RETORNO     PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     LK-OUT-SQLCODE         PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     LK-OUT-MENSAGEM        PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01     LK-OUT-SQLERRMC        PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01     LK-OUT-SQLSTATE        PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01           AREA-DE-WORK.*/
        public VA6005B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA6005B_AREA_DE_WORK();
        public class VA6005B_AREA_DE_WORK : VarBasis
        {
            /*"  05   WS-SIT-PRODUTO           PIC  9(001)  VALUE 0.*/

            public SelectorBasis WS_SIT_PRODUTO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 WS-PROD-RUNON                         VALUE 1. */
							new SelectorItemBasis("WS_PROD_RUNON", "1"),
							/*" 88 WS-PROD-RUNOFF                        VALUE 2. */
							new SelectorItemBasis("WS_PROD_RUNOFF", "2")
                }
            };

            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-PCTCED       PIC S9(004)V9(05) VALUE +0 COMP-3*/
            public DoubleBasis WACC_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(05)"), 5);
            /*"  05         WACC-QTCOSSEG     PIC  9(004)       VALUE  ZEROS.*/
            public IntBasis WACC_QTCOSSEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-DISPLAY      PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_DISPLAY { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-PROCESSADOS  PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_PROCESSADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-CBO          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0BILHETE    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1BILCOBER   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1BILCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1CLIENTE    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1CLIENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COMIFENAE  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1COMIFENAE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1FUNCIOCEF  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1FUNCIOCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RCAP       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RCAPCOMP   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1RCAPCOMP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COMERC-BIL PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1COMERC_BIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-SIVPF          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_SIVPF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-RENOVACAO      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WWORK-FUNDAO      PIC  X(001)    VALUE SPACE.*/
            public StringBasis WWORK_FUNDAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WPROC-BILHETES    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WPROC_BILHETES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WTEM-PROPESTIP    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_PROPESTIP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WWORK-NUM-APOL    PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-APOL.*/
            private _REDEF_VA6005B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_VA6005B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_VA6005B_FILLER_3(); _.Move(WWORK_NUM_APOL, _filler_3); VarBasis.RedefinePassValue(WWORK_NUM_APOL, _filler_3, WWORK_NUM_APOL); _filler_3.ValueChanged += () => { _.Move(_filler_3, WWORK_NUM_APOL); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WWORK_NUM_APOL); }
            }  //Redefines
            public class _REDEF_VA6005B_FILLER_3 : VarBasis
            {
                /*"    10       WWORK-ORG-APOL    PIC  9(003).*/
                public IntBasis WWORK_ORG_APOL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-RMO-APOL    PIC  9(002).*/
                public IntBasis WWORK_RMO_APOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-SEQ-APOL    PIC  9(008).*/
                public IntBasis WWORK_SEQ_APOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WWORK-PCPARCOR-I  PIC S9(003)V99   COMP-3.*/

                public _REDEF_VA6005B_FILLER_3()
                {
                    WWORK_ORG_APOL.ValueChanged += OnValueChanged;
                    WWORK_RMO_APOL.ValueChanged += OnValueChanged;
                    WWORK_SEQ_APOL.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WWORK_PCPARCOR_I { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         WWORK-PCPARCOR-F  PIC S9(003)V99   COMP-3.*/
            public DoubleBasis WWORK_PCPARCOR_F { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         WWORK-PCCOMCOR-I  PIC S9(003)V99   COMP-3.*/
            public DoubleBasis WWORK_PCCOMCOR_I { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         WWORK-PCCOMCOR-F  PIC S9(003)V99   COMP-3.*/
            public DoubleBasis WWORK_PCCOMCOR_F { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         WWORK-PCPARCOR    PIC S9(003)V9(5) COMP-3.*/
            public DoubleBasis WWORK_PCPARCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(5)"), 5);
            /*"  05         WWORK-PCCOMCOR    PIC S9(003)V9(5) COMP-3.*/
            public DoubleBasis WWORK_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(5)"), 5);
            /*"  05         WWORK-IS-APOL     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WWORK_IS_APOL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WWORK-PR-APOL     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WWORK_PR_APOL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WWORK-IOCC        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WWORK_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WWORK-PR-TOT      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WWORK_PR_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-VALORDIF       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VALORDIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-VALORMAIS      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VALORMAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-VLDIFE         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VLDIFE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-VLMAIOR        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VLMAIOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AUX-VALBAS        PIC S9(013)V99       COMP-3.*/
            public DoubleBasis AUX_VALBAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AUX-PERCENT       PIC S9(003)V9999     COMP-3.*/
            public DoubleBasis AUX_PERCENT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
            /*"  05         WWORK-NUM-ITENS   PIC S9(009)    COMP.*/
            public IntBasis WWORK_NUM_ITENS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WWORK-NUM-ORDEM   PIC  9(014)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_ORDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-ORDEM.*/
            private _REDEF_VA6005B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VA6005B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VA6005B_FILLER_4(); _.Move(WWORK_NUM_ORDEM, _filler_4); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_4, WWORK_NUM_ORDEM); _filler_4.ValueChanged += () => { _.Move(_filler_4, WWORK_NUM_ORDEM); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_VA6005B_FILLER_4 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-NUMBIL      PIC  9(015)    VALUE ZEROS.*/

                public _REDEF_VA6005B_FILLER_4()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUMBIL.*/
            private _REDEF_VA6005B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VA6005B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VA6005B_FILLER_5(); _.Move(WWORK_NUMBIL, _filler_5); VarBasis.RedefinePassValue(WWORK_NUMBIL, _filler_5, WWORK_NUMBIL); _filler_5.ValueChanged += () => { _.Move(_filler_5, WWORK_NUMBIL); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WWORK_NUMBIL); }
            }  //Redefines
            public class _REDEF_VA6005B_FILLER_5 : VarBasis
            {
                /*"    10       FILLER            PIC  9(004).*/
                public IntBasis FILLER_6 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-NRRCAP      PIC  9(009).*/
                public IntBasis WWORK_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       FILLER            PIC  9(002).*/
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WWORK-NR-PROPOSTA PIC  9(014)    VALUE ZEROS.*/

                public _REDEF_VA6005B_FILLER_5()
                {
                    FILLER_6.ValueChanged += OnValueChanged;
                    WWORK_NRRCAP.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NR_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NR-PROPOSTA.*/
            private _REDEF_VA6005B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VA6005B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VA6005B_FILLER_8(); _.Move(WWORK_NR_PROPOSTA, _filler_8); VarBasis.RedefinePassValue(WWORK_NR_PROPOSTA, _filler_8, WWORK_NR_PROPOSTA); _filler_8.ValueChanged += () => { _.Move(_filler_8, WWORK_NR_PROPOSTA); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WWORK_NR_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA6005B_FILLER_8 : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL          VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF            VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL         VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR             VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO              VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-ATM                  VALUE 4. */
							new SelectorItemBasis("CANAL_ATM", "4"),
							/*" 88 CANAL-GITEL                VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET             VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-INTRANET             VALUE 8. */
							new SelectorItemBasis("CANAL_INTRANET", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_9 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_VA6005B_FILLER_8()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                }

            }
            public VA6005B_WWORK_DATA WWORK_DATA { get; set; } = new VA6005B_WWORK_DATA();
            public class VA6005B_WWORK_DATA : VarBasis
            {
                /*"    10       WWORK-ANO         PIC  9(004).*/
                public IntBasis WWORK_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-MES         PIC  9(002).*/
                public IntBasis WWORK_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-DIA         PIC  9(002).*/
                public IntBasis WWORK_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WWORK-ANO-BI      PIC  9(009)    COMP-3.*/
            }
            public IntBasis WWORK_ANO_BI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WDATA-SISTEMA.*/
            public VA6005B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VA6005B_WDATA_SISTEMA();
            public class VA6005B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  X(004).*/
                public StringBasis WDATA_SIS_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  X(002).*/
                public StringBasis WDATA_SIS_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  X(002).*/
                public StringBasis WDATA_SIS_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WWORK-DATAINI     PIC  9(008)  VALUE ZEROS.*/
            }
            public IntBasis WWORK_DATAINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATAINI.*/
            private _REDEF_VA6005B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VA6005B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VA6005B_FILLER_14(); _.Move(WWORK_DATAINI, _filler_14); VarBasis.RedefinePassValue(WWORK_DATAINI, _filler_14, WWORK_DATAINI); _filler_14.ValueChanged += () => { _.Move(_filler_14, WWORK_DATAINI); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WWORK_DATAINI); }
            }  //Redefines
            public class _REDEF_VA6005B_FILLER_14 : VarBasis
            {
                /*"    10       WWORK-DIAINI      PIC  9(002).*/
                public IntBasis WWORK_DIAINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESINI      PIC  9(002).*/
                public IntBasis WWORK_MESINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOINI      PIC  9(004).*/
                public IntBasis WWORK_ANOINI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-DATATER     PIC  9(008)  VALUE ZEROS.*/

                public _REDEF_VA6005B_FILLER_14()
                {
                    WWORK_DIAINI.ValueChanged += OnValueChanged;
                    WWORK_MESINI.ValueChanged += OnValueChanged;
                    WWORK_ANOINI.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_DATATER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATATER.*/
            private _REDEF_VA6005B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_VA6005B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_VA6005B_FILLER_15(); _.Move(WWORK_DATATER, _filler_15); VarBasis.RedefinePassValue(WWORK_DATATER, _filler_15, WWORK_DATATER); _filler_15.ValueChanged += () => { _.Move(_filler_15, WWORK_DATATER); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WWORK_DATATER); }
            }  //Redefines
            public class _REDEF_VA6005B_FILLER_15 : VarBasis
            {
                /*"    10       WWORK-DIATER      PIC  9(002).*/
                public IntBasis WWORK_DIATER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESTER      PIC  9(002).*/
                public IntBasis WWORK_MESTER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOTER      PIC  9(004).*/
                public IntBasis WWORK_ANOTER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-QTCOSSEG    PIC  9(002)  VALUE ZEROS.*/

                public _REDEF_VA6005B_FILLER_15()
                {
                    WWORK_DIATER.ValueChanged += OnValueChanged;
                    WWORK_MESTER.ValueChanged += OnValueChanged;
                    WWORK_ANOTER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_QTCOSSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WDATA-CURR.*/
            public VA6005B_WDATA_CURR WDATA_CURR { get; set; } = new VA6005B_WDATA_CURR();
            public class VA6005B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public VA6005B_WDATA_CABEC WDATA_CABEC { get; set; } = new VA6005B_WDATA_CABEC();
            public class VA6005B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-CODANGAR-R.*/
            }
            public VA6005B_WS_CODANGAR_R WS_CODANGAR_R { get; set; } = new VA6005B_WS_CODANGAR_R();
            public class VA6005B_WS_CODANGAR_R : VarBasis
            {
                /*"    10       WS-NUM-ANGAR      PIC  9(006)   VALUE 0.*/
                public IntBasis WS_NUM_ANGAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    10       WS-DAC-ANGAR      PIC  9(001)   VALUE 0.*/
                public IntBasis WS_DAC_ANGAR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"  05         WS-CODANGAR       REDEFINES     WS-CODANGAR-R                               PIC  9(007).*/
            }
            private _REDEF_IntBasis _ws_codangar { get; set; }
            public _REDEF_IntBasis WS_CODANGAR
            {
                get { _ws_codangar = new _REDEF_IntBasis(new PIC("9", "007", "9(007).")); ; _.Move(WS_CODANGAR_R, _ws_codangar); VarBasis.RedefinePassValue(WS_CODANGAR_R, _ws_codangar, WS_CODANGAR_R); _ws_codangar.ValueChanged += () => { _.Move(_ws_codangar, WS_CODANGAR_R); }; return _ws_codangar; }
                set { VarBasis.RedefinePassValue(value, _ws_codangar, WS_CODANGAR_R); }
            }  //Redefines
            /*"  05         PROM11W099.*/
            public VA6005B_PROM11W099 PROM11W099 { get; set; } = new VA6005B_PROM11W099();
            public class VA6005B_PROM11W099 : VarBasis
            {
                /*"    10       PROM11W099-NUMERO   PIC  9(015).*/
                public IntBasis PROM11W099_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       PROM11W099-TAM      PIC S9(004)   COMP.*/
                public IntBasis PROM11W099_TAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       PROM11W099-DAC      PIC  X(001).*/
                public StringBasis PROM11W099_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         WS-NUMREC-R.*/
            }
            public VA6005B_WS_NUMREC_R WS_NUMREC_R { get; set; } = new VA6005B_WS_NUMREC_R();
            public class VA6005B_WS_NUMREC_R : VarBasis
            {
                /*"    10       WS-AA-NUMREC        PIC  9(004)   VALUE 0.*/
                public IntBasis WS_AA_NUMREC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WS-NN-NUMREC        PIC  9(004)   VALUE 0.*/
                public IntBasis WS_NN_NUMREC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-NUMREC           REDEFINES     WS-NUMREC-R                                 PIC  9(008).*/
            }
            private _REDEF_IntBasis _ws_numrec { get; set; }
            public _REDEF_IntBasis WS_NUMREC
            {
                get { _ws_numrec = new _REDEF_IntBasis(new PIC("9", "008", "9(008).")); ; _.Move(WS_NUMREC_R, _ws_numrec); VarBasis.RedefinePassValue(WS_NUMREC_R, _ws_numrec, WS_NUMREC_R); _ws_numrec.ValueChanged += () => { _.Move(_ws_numrec, WS_NUMREC_R); }; return _ws_numrec; }
                set { VarBasis.RedefinePassValue(value, _ws_numrec, WS_NUMREC_R); }
            }  //Redefines
            /*"  05         WLINK-DATATER         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WLINK_DATATER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WLINK-DATAINI         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WLINK_DATAINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WLINK-QTDDIAS         PIC S9(005)   VALUE +0 COMP-3*/
            public IntBasis WLINK_QTDDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         AC-I-V0APOLICE        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLICE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ENDOSSO        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0RCAPCOMP       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLCORRET     PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLCOSCED     PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ORDECOSCED     PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ORDECOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0PARCELA        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0HISTOPARC      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0COBERAPOL      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0COBERAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0PRODUTOR       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0PRODUTOR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0CLIE-CROT      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0CLIE_CROT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ADIANTA        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ADIANTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0APOLICE        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0APOLICE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0RCAP           PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0RCAPCOMP       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMEROUT       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMEROUT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMERAES       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERAES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0FONTE          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0FUNCIOCEF      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0FUNCIOCEF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0BILHETE        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0BILHETE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMERO-COSSEGURO PIC  9(005) VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERO_COSSEGURO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0COMIFENAE      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0COMIFENAE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0CLIE-CROT      PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0CLIE_CROT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05   WS-SQLCODE                    PIC  ----9.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
            /*"  05        WABEND.*/
            public VA6005B_WABEND WABEND { get; set; } = new VA6005B_WABEND();
            public class VA6005B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VA6005B '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA6005B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01         WS-IND-CORRETOR      PIC  9(001)     VALUE 0.*/
            }
        }
        public IntBasis WS_IND_CORRETOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01         WS-COD-CORRETOR      PIC  9(009)     VALUE 0.*/

        public SelectorBasis WS_COD_CORRETOR { get; set; } = new SelectorBasis("009", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88       N88-COD-CORRETOR    VALUES  2496,  2933,  6327,  7005,                                      9440, 17256, 17604, 17752,                                     18040, 19224, 23914, 23922,                                     23931, 23949, 23957, 24112,                                     24121, 24163, 24236, 24287,                                     24295, 24309, 24317, 24333,                                     24341, 24368, 24384, 24392,                                     24431, 24449, 24457, 24481,                                     24716, 24937, 24945, 24970,                                     24996, 25003, 101150. */
							new SelectorItemBasis("N88_COD_CORRETOR", "2496,2933,6327,7005,9440,17256,17604,17752,18040,19224,23914,23922,23931,23949,23957,24112,24121,24163,24236,24287,24295,24309,24317,24333,24341,24368,24384,24392,24431,24449,24457,24481,24716,24937,24945,24970,24996,25003,101150")
                }
        };

        /*"01  WS-JV1-PROGRAMA             PIC X(008) VALUE SPACES.*/
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");


        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PARAMPRO PARAMPRO { get; set; } = new Dclgens.PARAMPRO();
        public Dclgens.GE101 GE101 { get; set; } = new Dclgens.GE101();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public VA6005B_V0BILHETE V0BILHETE { get; set; } = new VA6005B_V0BILHETE();
        public VA6005B_V1COSSEGPROD V1COSSEGPROD { get; set; } = new VA6005B_V1COSSEGPROD();
        public VA6005B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new VA6005B_V1RCAPCOMP();
        public VA6005B_CCBO CCBO { get; set; } = new VA6005B_CCBO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1395- DISPLAY ' ' */
            _.Display($" ");

            /*" -1397- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1405- DISPLAY 'PROGRAMA VA6005B - VERSAO V.51' '- DEMANDA 589106 - 12/08/2024.' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VA6005B - VERSAO V.51- DEMANDA 589106 - 12/08/2024.FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1408- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1409- MOVE 'VA6005B' TO LK-GEJVW002-NOM-PROG-ORIGEM */
            _.Move("VA6005B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -1410- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -1410- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WS_JV1_PROGRAMA);

            /*" -1411- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -1412- IF LK-GEJVWCNT-IND-ERRO NOT = 0 */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 0)
            {

                /*" -1413- DISPLAY 'IND ERRO    = ' LK-GEJVWCNT-IND-ERRO */
                _.Display($"IND ERRO    = {GEJVWCNT.LK_GEJVWCNT_IND_ERRO}");

                /*" -1414- DISPLAY 'MENSAGEM    = ' LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM    = {GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO}");

                /*" -1415- DISPLAY 'TABELA      = ' LK-GEJVWCNT-NOME-TABELA */
                _.Display($"TABELA      = {GEJVWCNT.LK_GEJVWCNT_NOME_TABELA}");

                /*" -1416- DISPLAY 'SQLCODE     = ' LK-GEJVWCNT-SQLCODE */
                _.Display($"SQLCODE     = {GEJVWCNT.LK_GEJVWCNT_SQLCODE}");

                /*" -1417- MOVE LK-GEJVWCNT-SQLCODE TO WSQLCODE */
                _.Move(GEJVWCNT.LK_GEJVWCNT_SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1418- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1420- END-IF */
            }


            /*" -1422- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1424- INITIALIZE TAB-CBO1. */
            _.Initialize(
                TAB_CBO1
            );

            /*" -1426- PERFORM R8100-00-DECLARE-CBO. */

            R8100_00_DECLARE_CBO_SECTION();

            /*" -1428- PERFORM R8110-00-FETCH-CBO. */

            R8110_00_FETCH_CBO_SECTION();

            /*" -1429- IF WFIM-CBO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CBO.IsEmpty())
            {

                /*" -1430- DISPLAY '8110 - PROBLEMA NO FETCH DA CBO 1ª LEITURA' */
                _.Display($"8110 - PROBLEMA NO FETCH DA CBO 1ª LEITURA");

                /*" -1432- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1435- PERFORM R8120-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_CBO == "S"))
            {

                R8120_00_CARREGA_CBO_SECTION();
            }

            /*" -1436- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1438- DISPLAY 'INICIO DO DECLARE ...... ' WS-TIME. */
            _.Display($"INICIO DO DECLARE ...... {WS_TIME}");

            /*" -1440- PERFORM R0900-00-DECLARE-V0BILHETE. */

            R0900_00_DECLARE_V0BILHETE_SECTION();

            /*" -1441- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1443- DISPLAY 'FIM DO DECLARE ......... ' WS-TIME. */
            _.Display($"FIM DO DECLARE ......... {WS_TIME}");

            /*" -1445- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

            /*" -1446- IF WFIM-V0BILHETE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty())
            {

                /*" -1448- DISPLAY 'VA6005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...' */
                _.Display($"VA6005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...");

                /*" -1450- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1453- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0BILHETE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1455- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -1455- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1461- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1462- DISPLAY ' ' */
            _.Display($" ");

            /*" -1464- DISPLAY '*--------  VA6005B - FIM NORMAL  --------*' */
            _.Display($"*--------  VA6005B - FIM NORMAL  --------*");

            /*" -1464- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1475- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1480- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1483- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1484- DISPLAY 'ERRO SELECT V1SISTEMA EM' */
                _.Display($"ERRO SELECT V1SISTEMA EM");

                /*" -1486- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1488- MOVE '0101' TO WNR-EXEC-SQL. */
            _.Move("0101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1493- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_2 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_2();

            /*" -1496- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1497- DISPLAY 'ERRO SELECT V1SISTEMA CB' */
                _.Display($"ERRO SELECT V1SISTEMA CB");

                /*" -1499- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1500- MOVE 5 TO WS-VLMAIOR */
            _.Move(5, AREA_DE_WORK.WS_VLMAIOR);

            /*" -1502- MOVE 1 TO WS-VLDIFE. */
            _.Move(1, AREA_DE_WORK.WS_VLDIFE);

            /*" -1502- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1480- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-2 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_2()
        {
            /*" -1493- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVACB FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVACB, V1SIST_DTMOVACB);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-SECTION */
        private void R0900_00_DECLARE_V0BILHETE_SECTION()
        {
            /*" -1513- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1515- MOVE SPACE TO WFIM-V0BILHETE. */
            _.Move("", AREA_DE_WORK.WFIM_V0BILHETE);

            /*" -1543- PERFORM R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1 */

            R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1();

            /*" -1545- PERFORM R0900_00_DECLARE_V0BILHETE_DB_OPEN_1 */

            R0900_00_DECLARE_V0BILHETE_DB_OPEN_1();

            /*" -1548- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1549- DISPLAY 'PROBLEMAS NO OPEN (V0BILHETE) ... ' */
                _.Display($"PROBLEMAS NO OPEN (V0BILHETE) ... ");

                /*" -1549- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1()
        {
            /*" -1543- EXEC SQL DECLARE V0BILHETE CURSOR WITH HOLD FOR SELECT NUMBIL , FONTE , AGECOBR , NUM_MATRICULA , COD_AGENCIA , CODCLIEN , PROFISSAO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_VENDA , DTQITBCO , VLRCAP , RAMO , COD_USUARIO , SITUACAO , NUM_APOL_ANTERIOR FROM SEGUROS.V0BILHETE WHERE SITUACAO = '0' AND NUM_APOL_ANTERIOR > 0 AND RAMO IN (37,81,82) END-EXEC. */
            V0BILHETE = new VA6005B_V0BILHETE(false);
            string GetQuery_V0BILHETE()
            {
                var query = @$"SELECT NUMBIL
							, 
							FONTE
							, 
							AGECOBR
							, 
							NUM_MATRICULA
							, 
							COD_AGENCIA
							, 
							CODCLIEN
							, 
							PROFISSAO
							, 
							COD_AGENCIA_DEB
							, 
							OPERACAO_CONTA_DEB
							, 
							NUM_CONTA_DEB
							, 
							DIG_CONTA_DEB
							, 
							OPC_COBERTURA
							, 
							DATA_VENDA
							, 
							DTQITBCO
							, 
							VLRCAP
							, 
							RAMO
							, 
							COD_USUARIO
							, 
							SITUACAO
							, 
							NUM_APOL_ANTERIOR 
							FROM SEGUROS.V0BILHETE 
							WHERE SITUACAO = '0' 
							AND NUM_APOL_ANTERIOR > 0 
							AND RAMO IN (37
							,81
							,82)";

                return query;
            }
            V0BILHETE.GetQueryEvent += GetQuery_V0BILHETE;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_OPEN_1()
        {
            /*" -1545- EXEC SQL OPEN V0BILHETE END-EXEC. */

            V0BILHETE.Open();

        }

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-DB-DECLARE-1 */
        public void R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1()
        {
            /*" -3320- EXEC SQL DECLARE V1COSSEGPROD CURSOR FOR SELECT CODPRODU , RAMO , CONGENER , PCPARTIC , PCCOMCOS , PCADMCOS , DTINIVIG , DTTERVIG , SITUACAO FROM SEGUROS.V1COSSEGPROD WHERE CODPRODU = :V1BILP-CODPRODU AND RAMO = :WWORK-RAMO-ANT AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG AND SUBPRODU = :WWORK-OPCAO-ANT END-EXEC. */
            V1COSSEGPROD = new VA6005B_V1COSSEGPROD(true);
            string GetQuery_V1COSSEGPROD()
            {
                var query = @$"SELECT CODPRODU
							, 
							RAMO
							, 
							CONGENER
							, 
							PCPARTIC
							, 
							PCCOMCOS
							, 
							PCADMCOS
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							SITUACAO 
							FROM SEGUROS.V1COSSEGPROD 
							WHERE CODPRODU = '{V1BILP_CODPRODU}' 
							AND RAMO = '{WWORK_RAMO_ANT}' 
							AND DTINIVIG <= '{V0ENDO_DTINIVIG}' 
							AND DTTERVIG >= '{V0ENDO_DTINIVIG}' 
							AND SUBPRODU = '{WWORK_OPCAO_ANT}'";

                return query;
            }
            V1COSSEGPROD.GetQueryEvent += GetQuery_V1COSSEGPROD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0BILHETE-SECTION */
        private void R0910_00_FETCH_V0BILHETE_SECTION()
        {
            /*" -1558- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0910_10_LE */

            R0910_10_LE();

        }

        [StopWatch]
        /*" R0910-10-LE */
        private void R0910_10_LE(bool isPerform = false)
        {
            /*" -1582- PERFORM R0910_10_LE_DB_FETCH_1 */

            R0910_10_LE_DB_FETCH_1();

            /*" -1585- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1586- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1586- PERFORM R0910_10_LE_DB_CLOSE_1 */

                    R0910_10_LE_DB_CLOSE_1();

                    /*" -1588- MOVE 'S' TO WFIM-V0BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIM_V0BILHETE);

                    /*" -1589- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1590- ELSE */
                }
                else
                {


                    /*" -1591- DISPLAY 'R0910-00 (ERRO -  FETCH V0BILHETE)...' */
                    _.Display($"R0910-00 (ERRO -  FETCH V0BILHETE)...");

                    /*" -1593- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1596- ADD 1 TO WACC-LIDOS WACC-DISPLAY. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_DISPLAY.Value = AREA_DE_WORK.WACC_DISPLAY + 1;

            /*" -1597- IF WACC-PROCESSADOS EQUAL 500 */

            if (AREA_DE_WORK.WACC_PROCESSADOS == 500)
            {

                /*" -1598- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1599- DISPLAY 'TOTAL ATUALIZADO.. ' WPROC-BILHETES '  ' WS-TIME */

                $"TOTAL ATUALIZADO.. {AREA_DE_WORK.WPROC_BILHETES}  {WS_TIME}"
                .Display();

                /*" -1599- MOVE ZEROS TO WACC-PROCESSADOS. */
                _.Move(0, AREA_DE_WORK.WACC_PROCESSADOS);
            }


        }

        [StopWatch]
        /*" R0910-10-LE-DB-FETCH-1 */
        public void R0910_10_LE_DB_FETCH_1()
        {
            /*" -1582- EXEC SQL FETCH V0BILHETE INTO :V0BILH-NUMBIL , :V0BILH-FONTE , :V0BILH-AGECOBR , :V0BILH-NUM-MATR , :V0BILH-AGENCIA , :V0BILH-CODCLIEN , :V0BILH-PROFISSAO , :V0BILH-AGENCIA-DEB , :V0BILH-OPERACAO-DEB , :V0BILH-NUMCTA-DEB , :V0BILH-DIGCTA-DEB , :V0BILH-OPCAO-COBER , :V0BILH-DTA-VENDA , :V0BILH-DTQITBCO , :V0BILH-VLRCAP , :V0BILH-RAMO , :V0BILH-CODUSU , :V0BILH-SITUACAO , :V0BILH-NUM-APO-ANT END-EXEC. */

            if (V0BILHETE.Fetch())
            {
                _.Move(V0BILHETE.V0BILH_NUMBIL, V0BILH_NUMBIL);
                _.Move(V0BILHETE.V0BILH_FONTE, V0BILH_FONTE);
                _.Move(V0BILHETE.V0BILH_AGECOBR, V0BILH_AGECOBR);
                _.Move(V0BILHETE.V0BILH_NUM_MATR, V0BILH_NUM_MATR);
                _.Move(V0BILHETE.V0BILH_AGENCIA, V0BILH_AGENCIA);
                _.Move(V0BILHETE.V0BILH_CODCLIEN, V0BILH_CODCLIEN);
                _.Move(V0BILHETE.V0BILH_PROFISSAO, V0BILH_PROFISSAO);
                _.Move(V0BILHETE.V0BILH_AGENCIA_DEB, V0BILH_AGENCIA_DEB);
                _.Move(V0BILHETE.V0BILH_OPERACAO_DEB, V0BILH_OPERACAO_DEB);
                _.Move(V0BILHETE.V0BILH_NUMCTA_DEB, V0BILH_NUMCTA_DEB);
                _.Move(V0BILHETE.V0BILH_DIGCTA_DEB, V0BILH_DIGCTA_DEB);
                _.Move(V0BILHETE.V0BILH_OPCAO_COBER, V0BILH_OPCAO_COBER);
                _.Move(V0BILHETE.V0BILH_DTA_VENDA, V0BILH_DTA_VENDA);
                _.Move(V0BILHETE.V0BILH_DTQITBCO, V0BILH_DTQITBCO);
                _.Move(V0BILHETE.V0BILH_VLRCAP, V0BILH_VLRCAP);
                _.Move(V0BILHETE.V0BILH_RAMO, V0BILH_RAMO);
                _.Move(V0BILHETE.V0BILH_CODUSU, V0BILH_CODUSU);
                _.Move(V0BILHETE.V0BILH_SITUACAO, V0BILH_SITUACAO);
                _.Move(V0BILHETE.V0BILH_NUM_APO_ANT, V0BILH_NUM_APO_ANT);
            }

        }

        [StopWatch]
        /*" R0910-10-LE-DB-CLOSE-1 */
        public void R0910_10_LE_DB_CLOSE_1()
        {
            /*" -1586- EXEC SQL CLOSE V0BILHETE END-EXEC */

            V0BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1610- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1611- MOVE V0BILH-RAMO TO WWORK-RAMO-ANT */
            _.Move(V0BILH_RAMO, WWORK_RAMO_ANT);

            /*" -1613- MOVE V0BILH-OPCAO-COBER TO WWORK-OPCAO-ANT. */
            _.Move(V0BILH_OPCAO_COBER, WWORK_OPCAO_ANT);

            /*" -1614- MOVE ZEROES TO V0ADIA-VALADT. */
            _.Move(0, V0ADIA_VALADT);

            /*" -1615- MOVE SPACES TO WWORK-MIN-DTINIVIG. */
            _.Move("", WWORK_MIN_DTINIVIG);

            /*" -1616- MOVE SPACES TO WWORK-MAX-DTTERVIG. */
            _.Move("", WWORK_MAX_DTTERVIG);

            /*" -1617- MOVE SPACES TO WS-RENOVACAO. */
            _.Move("", AREA_DE_WORK.WS_RENOVACAO);

            /*" -1622- MOVE ZEROES TO WWORK-NUM-ITENS */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_ITENS);

            /*" -1623- IF V0BILH-NUM-APO-ANT GREATER 0 */

            if (V0BILH_NUM_APO_ANT > 0)
            {

                /*" -1624- PERFORM R3270-00-SELECT-APOLICE-ANT */

                R3270_00_SELECT_APOLICE_ANT_SECTION();

                /*" -1625- PERFORM R3275-00-SELECT-ENDOSSO-ANT */

                R3275_00_SELECT_ENDOSSO_ANT_SECTION();

                /*" -1626- IF WS-RENOVACAO EQUAL '*' */

                if (AREA_DE_WORK.WS_RENOVACAO == "*")
                {

                    /*" -1628- GO TO R1000-00-LEITURA. */

                    R1000_00_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -1629- PERFORM R3280-00-SELECT-PRODUTO */

            R3280_00_SELECT_PRODUTO_SECTION();

            /*" -1636- IF BILHETE-COD-PRODUTO EQUAL 8528 OR 8521 OR 8529 OR 8531 OR 8532 OR 8533 OR 8534 */

            if (BILHETE.DCLBILHETE.BILHETE_COD_PRODUTO.In("8528", "8521", "8529", "8531", "8532", "8533", "8534"))
            {

                /*" -1638- DISPLAY '------> RENOVACAO DE BILHETE PU NAO PREVISTA - ' 'BILHETE: ' V0BILH-NUMBIL */

                $"------> RENOVACAO DE BILHETE PU NAO PREVISTA - BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -1641- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -1647- MOVE V0ENDO-COD-PRODU-ANT TO V1BILP-CODPRODU */
            _.Move(V0ENDO_COD_PRODU_ANT, V1BILP_CODPRODU);

            /*" -1649- MOVE V1BILP-CODPRODU TO PRODUTO-COD-PRODUTO WS-COD-PRODUTO. */
            _.Move(V1BILP_CODPRODU, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, WS_COD_PRODUTO);

            /*" -1650- INITIALIZE WS-SIT-PRODUTO. */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -1652- PERFORM R1040-PRODUTO-RUNOFF. */

            R1040_PRODUTO_RUNOFF_SECTION();

            /*" -1654- PERFORM R8000-JV1-BUSCA-EMPRESA. */

            R8000_JV1_BUSCA_EMPRESA_SECTION();

            /*" -1655- IF (PRODUTO-COD-EMPRESA = 10 OR 11) */

            if ((PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.In("10", "11")))
            {

                /*" -1656- IF WS-PROD-RUNON */

                if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                {

                    /*" -1657- MOVE 300 TO WH-JV1-COD-ORGAO */
                    _.Move(300, WORK_JV1.WH_JV1_COD_ORGAO);

                    /*" -1658- ELSE */
                }
                else
                {


                    /*" -1659- MOVE 10 TO WH-JV1-COD-ORGAO */
                    _.Move(10, WORK_JV1.WH_JV1_COD_ORGAO);

                    /*" -1660- END-IF */
                }


                /*" -1662- END-IF. */
            }


            /*" -1664- MOVE 0 TO WS-IND-CORRETOR */
            _.Move(0, WS_IND_CORRETOR);

            /*" -1666- IF WS-PROD-RUNON AND V1SIST-DTMOVACB >= '2021-08-16' */

            if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] && V1SIST_DTMOVACB >= "2021-08-16")
            {

                /*" -1667- MOVE 1 TO WS-IND-CORRETOR */
                _.Move(1, WS_IND_CORRETOR);

                /*" -1669- END-IF */
            }


            /*" -1671- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1678- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -1681- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1682- DISPLAY 'R1000-00 (ERRO - SELECT V1NUMERO_AES)...' */
                _.Display($"R1000-00 (ERRO - SELECT V1NUMERO_AES)...");

                /*" -1684- DISPLAY 'ORGAO: ' WH-JV1-COD-ORGAO 'RAMO : ' V0BILH-RAMO */

                $"ORGAO: {WORK_JV1.WH_JV1_COD_ORGAO}RAMO : {V0BILH_RAMO}"
                .Display();

                /*" -1686- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1689- COMPUTE V0NAES-SEQ-APOL = V1NAES-SEQ-APOL + 1. */
            V0NAES_SEQ_APOL.Value = V1NAES_SEQ_APOL + 1;

            /*" -1690- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1692- MOVE 'S' TO WS-SIVPF. */
            _.Move("S", AREA_DE_WORK.WS_SIVPF);

            /*" -1702- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -1705- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1706- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1707- MOVE 'N' TO WS-SIVPF */
                    _.Move("N", AREA_DE_WORK.WS_SIVPF);

                    /*" -1709- MOVE ZEROS TO V0CONV-NUM-PROPOSTA-SIVPF */
                    _.Move(0, V0CONV_NUM_PROPOSTA_SIVPF);

                    /*" -1710- ELSE */
                }
                else
                {


                    /*" -1711- DISPLAY 'R1020-00 (ERRO - SELECT PROPOSTA_FIDELIZ)' */
                    _.Display($"R1020-00 (ERRO - SELECT PROPOSTA_FIDELIZ)");

                    /*" -1713- DISPLAY 'BILHETE: ' V0BILH-NUMBIL ' ' 'RAMO:    ' V0BILH-RAMO */

                    $"BILHETE: {V0BILH_NUMBIL} RAMO:    {V0BILH_RAMO}"
                    .Display();

                    /*" -1715- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1716- IF WS-SIVPF EQUAL 'N' */

            if (AREA_DE_WORK.WS_SIVPF == "N")
            {

                /*" -1717- MOVE '1021' TO WNR-EXEC-SQL */
                _.Move("1021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1718- MOVE 'S' TO WS-SIVPF */
                _.Move("S", AREA_DE_WORK.WS_SIVPF);

                /*" -1723- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

                R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

                /*" -1725- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1726- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1727- MOVE 'N' TO WS-SIVPF */
                        _.Move("N", AREA_DE_WORK.WS_SIVPF);

                        /*" -1729- MOVE ZEROS TO V0CONV-NUM-PROPOSTA-SIVPF */
                        _.Move(0, V0CONV_NUM_PROPOSTA_SIVPF);

                        /*" -1730- ELSE */
                    }
                    else
                    {


                        /*" -1731- DISPLAY 'R1021-00 (ERRO - SELECT CONVERSAO_SICOB)' */
                        _.Display($"R1021-00 (ERRO - SELECT CONVERSAO_SICOB)");

                        /*" -1733- DISPLAY 'BILHETE: ' V0BILH-NUMBIL ' ' 'RAMO:    ' V0BILH-RAMO */

                        $"BILHETE: {V0BILH_NUMBIL} RAMO:    {V0BILH_RAMO}"
                        .Display();

                        /*" -1736- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -1738- MOVE V0CONV-NUM-PROPOSTA-SIVPF TO WWORK-NR-PROPOSTA */
            _.Move(V0CONV_NUM_PROPOSTA_SIVPF, AREA_DE_WORK.WWORK_NR_PROPOSTA);

            /*" -1741- MOVE ZEROS TO WWORK-NUM-APOL */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_APOL);

            /*" -1742- MOVE WH-JV1-COD-ORGAO TO WWORK-ORG-APOL. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, AREA_DE_WORK.FILLER_3.WWORK_ORG_APOL);

            /*" -1743- MOVE V0BILH-RAMO TO WWORK-RMO-APOL. */
            _.Move(V0BILH_RAMO, AREA_DE_WORK.FILLER_3.WWORK_RMO_APOL);

            /*" -1744- MOVE V0NAES-SEQ-APOL TO WWORK-SEQ-APOL. */
            _.Move(V0NAES_SEQ_APOL, AREA_DE_WORK.FILLER_3.WWORK_SEQ_APOL);

            /*" -1747- MOVE WWORK-NUM-APOL TO V0APOL-NUM-APOL. */
            _.Move(AREA_DE_WORK.WWORK_NUM_APOL, V0APOL_NUM_APOL);

            /*" -1749- MOVE '1040' TO WNR-EXEC-SQL. */
            _.Move("1040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1750- MOVE V0ENDO-INIVIG-ANT TO WWORK-DATA */
            _.Move(V0ENDO_INIVIG_ANT, AREA_DE_WORK.WWORK_DATA);

            /*" -1751- IF WWORK-MES = 2 AND WWORK-DIA = 29 */

            if (AREA_DE_WORK.WWORK_DATA.WWORK_MES == 2 && AREA_DE_WORK.WWORK_DATA.WWORK_DIA == 29)
            {

                /*" -1752- MOVE 03 TO WWORK-MES */
                _.Move(03, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

                /*" -1753- MOVE 01 TO WWORK-DIA */
                _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

                /*" -1755- END-IF */
            }


            /*" -1756- COMPUTE WWORK-ANO = WWORK-ANO + 1 */
            AREA_DE_WORK.WWORK_DATA.WWORK_ANO.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO + 1;

            /*" -1757- MOVE WWORK-DATA TO V0ENDO-DTINIVIG */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTINIVIG);

            /*" -1759- MOVE V0ENDO-TERVIG-ANT TO WWORK-DATA */
            _.Move(V0ENDO_TERVIG_ANT, AREA_DE_WORK.WWORK_DATA);

            /*" -1760- IF WWORK-MES = 2 AND WWORK-DIA = 29 */

            if (AREA_DE_WORK.WWORK_DATA.WWORK_MES == 2 && AREA_DE_WORK.WWORK_DATA.WWORK_DIA == 29)
            {

                /*" -1761- MOVE 03 TO WWORK-MES */
                _.Move(03, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

                /*" -1762- MOVE 01 TO WWORK-DIA */
                _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

                /*" -1763- END-IF */
            }


            /*" -1764- COMPUTE WWORK-ANO = WWORK-ANO + 1 */
            AREA_DE_WORK.WWORK_DATA.WWORK_ANO.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO + 1;

            /*" -1766- MOVE WWORK-DATA TO V0ENDO-DTTERVIG */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTTERVIG);

            /*" -1767- MOVE 0 TO V1BILC-COD-EMPR */
            _.Move(0, V1BILC_COD_EMPR);

            /*" -1768- MOVE V1BILP-CODPRODU TO V1BILC-CODPRODU */
            _.Move(V1BILP_CODPRODU, V1BILC_CODPRODU);

            /*" -1769- MOVE WWORK-RAMO-ANT TO V1BILC-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V1BILC_RAMOFR);

            /*" -1770- MOVE 0 TO V1BILC-MODALIFR */
            _.Move(0, V1BILC_MODALIFR);

            /*" -1772- MOVE WWORK-OPCAO-ANT TO V1BILC-OPCAO */
            _.Move(WWORK_OPCAO_ANT, V1BILC_OPCAO);

            /*" -1792- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

            /*" -1795- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1796- MOVE 1503 TO V0BILER-COD-ERRO */
                _.Move(1503, V0BILER_COD_ERRO);

                /*" -1797- PERFORM R3045-00-INSERE-ERRO */

                R3045_00_INSERE_ERRO_SECTION();

                /*" -1798- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -1799- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -1800- DISPLAY 'R1040-00 (ERRO SELECT V1BILCOBER)' */
                _.Display($"R1040-00 (ERRO SELECT V1BILCOBER)");

                /*" -1801- DISPLAY 'COD_EMPRESA: ' V1BILC-COD-EMPR */
                _.Display($"COD_EMPRESA: {V1BILC_COD_EMPR}");

                /*" -1802- DISPLAY 'CODPRODU   : ' V1BILC-CODPRODU */
                _.Display($"CODPRODU   : {V1BILC_CODPRODU}");

                /*" -1803- DISPLAY 'RAMOFR     : ' V1BILC-RAMOFR */
                _.Display($"RAMOFR     : {V1BILC_RAMOFR}");

                /*" -1804- DISPLAY 'MODALIFR   : ' V1BILC-MODALIFR */
                _.Display($"MODALIFR   : {V1BILC_MODALIFR}");

                /*" -1805- DISPLAY 'COD_OPCAO  : ' V1BILC-OPCAO */
                _.Display($"COD_OPCAO  : {V1BILC_OPCAO}");

                /*" -1807- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -1808- IF VIND-PRMTOTAL LESS ZEROS */

            if (VIND_PRMTOTAL < 00)
            {

                /*" -1809- MOVE V0BILH-VLRCAP TO V1BILC-PRMTOTAL */
                _.Move(V0BILH_VLRCAP, V1BILC_PRMTOTAL);

                /*" -1810- ELSE */
            }
            else
            {


                /*" -1811- IF V1BILC-PRMTOTAL EQUAL ZEROS */

                if (V1BILC_PRMTOTAL == 00)
                {

                    /*" -1818- MOVE V0BILH-VLRCAP TO V1BILC-PRMTOTAL. */
                    _.Move(V0BILH_VLRCAP, V1BILC_PRMTOTAL);
                }

            }


            /*" -1820- PERFORM R3000-00-ACUMULA-BILHETE. */

            R3000_00_ACUMULA_BILHETE_SECTION();

            /*" -1821- IF WWORK-NUM-ITENS EQUAL ZEROES */

            if (AREA_DE_WORK.WWORK_NUM_ITENS == 00)
            {

                /*" -1823- DISPLAY "========> VA6005B - BILHETE NAO RENOVADO " V0BILH-NUMBIL */
                _.Display($"========> VA6005B - BILHETE NAO RENOVADO {V0BILH_NUMBIL}");

                /*" -1825- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -1827- MOVE '1025' TO WNR-EXEC-SQL. */
            _.Move("1025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1833- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -1836- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1838- DISPLAY 'R1025-00 (ERRO - UPDATE V0NUMERO_AES)...' */
                _.Display($"R1025-00 (ERRO - UPDATE V0NUMERO_AES)...");

                /*" -1840- DISPLAY 'ORGAO: ' WH-JV1-COD-ORGAO ' ' 'RAMO:  ' WWORK-RAMO-ANT */

                $"ORGAO: {WORK_JV1.WH_JV1_COD_ORGAO} RAMO:  {WWORK_RAMO_ANT}"
                .Display();

                /*" -1842- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1844- ADD +1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + +1;

            /*" -1847- ADD +1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + +1;

            /*" -1848- COMPUTE WWORK-IS-APOL = V1BILC-IMPSEG-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_IS_APOL.Value = V1BILC_IMPSEG_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -1849- COMPUTE WWORK-PR-APOL = V1BILC-PRMTAR-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_PR_APOL.Value = V1BILC_PRMTAR_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -1851- COMPUTE WWORK-PR-TOT = V1BILC-PRMTOTAL * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_PR_TOT.Value = V1BILC_PRMTOTAL * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -1853- MOVE V0BILH-CODCLIEN TO V0APOL-CODCLIEN. */
            _.Move(V0BILH_CODCLIEN, V0APOL_CODCLIEN);

            /*" -1854- MOVE WWORK-NUM-ITENS TO V0APOL-NUM-ITEM */
            _.Move(AREA_DE_WORK.WWORK_NUM_ITENS, V0APOL_NUM_ITEM);

            /*" -1856- MOVE ZEROS TO V0APOL-MODALIDA */
            _.Move(0, V0APOL_MODALIDA);

            /*" -1857- MOVE WH-JV1-COD-ORGAO TO V0APOL-ORGAO. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, V0APOL_ORGAO);

            /*" -1861- MOVE WWORK-RAMO-ANT TO V0APOL-RAMO */
            _.Move(WWORK_RAMO_ANT, V0APOL_RAMO);

            /*" -1866- MOVE V1APOL-NUM-APOL TO V0APOL-NUM-APO-ANT */
            _.Move(V1APOL_NUM_APOL, V0APOL_NUM_APO_ANT);

            /*" -1867- MOVE '1' TO V0APOL-TIPSGU */
            _.Move("1", V0APOL_TIPSGU);

            /*" -1868- MOVE '2' TO V0APOL-TIPAPO */
            _.Move("2", V0APOL_TIPAPO);

            /*" -1869- MOVE '3' TO V0APOL-TIPCALC */
            _.Move("3", V0APOL_TIPCALC);

            /*" -1870- MOVE 'N' TO V0APOL-PODPUBL */
            _.Move("N", V0APOL_PODPUBL);

            /*" -1871- MOVE ZEROS TO V0APOL-NUM-ATA */
            _.Move(0, V0APOL_NUM_ATA);

            /*" -1872- MOVE ZEROS TO V0APOL-ANO-ATA */
            _.Move(0, V0APOL_ANO_ATA);

            /*" -1873- MOVE SPACES TO V0APOL-IDEMAN */
            _.Move("", V0APOL_IDEMAN);

            /*" -1875- MOVE ZEROS TO V0APOL-PCDESCON */
            _.Move(0, V0APOL_PCDESCON);

            /*" -1876- MOVE ZEROS TO V0APOL-PCTCED */
            _.Move(0, V0APOL_PCTCED);

            /*" -1877- MOVE '4' TO V0APOL-TPCOSCED */
            _.Move("4", V0APOL_TPCOSCED);

            /*" -1878- MOVE ZEROS TO V0APOL-QTCOSSEG */
            _.Move(0, V0APOL_QTCOSSEG);

            /*" -1880- MOVE ZEROS TO V0APOL-COD-EMPRESA */
            _.Move(0, V0APOL_COD_EMPRESA);

            /*" -1882- MOVE '2' TO V0APOL-TPCORRET. */
            _.Move("2", V0APOL_TPCORRET);

            /*" -1884- MOVE '1070' TO WNR-EXEC-SQL. */
            _.Move("1070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1902- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

            /*" -1905- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1906- DISPLAY 'R1070-00 (ERRO - SELECT V0BILHETE_COBER)...' */
                _.Display($"R1070-00 (ERRO - SELECT V0BILHETE_COBER)...");

                /*" -1913- DISPLAY 'EMPR: ' V1BILC-COD-EMPR ' ' 'PROD: ' V1BILC-CODPRODU ' ' 'RAMO: ' V1BILC-RAMOFR ' ' 'MODA: ' V1BILC-MODALIFR ' ' 'OPCA: ' V1BILC-OPCAO ' ' 'DAT1: ' V0ENDO-DTINIVIG ' ' 'DAT2: ' V0ENDO-DTTERVIG */

                $"EMPR: {V1BILC_COD_EMPR} PROD: {V1BILC_CODPRODU} RAMO: {V1BILC_RAMOFR} MODA: {V1BILC_MODALIFR} OPCA: {V1BILC_OPCAO} DAT1: {V0ENDO_DTINIVIG} DAT2: {V0ENDO_DTTERVIG}"
                .Display();

                /*" -1915- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1916- IF V0BILH-DTQITBCO > '2004-08-31' */

            if (V0BILH_DTQITBCO > "2004-08-31")
            {

                /*" -1918- MOVE 4 TO V1BILC-PCIOCC. */
                _.Move(4, V1BILC_PCIOCC);
            }


            /*" -1919- IF V0BILH-DTQITBCO > '2005-08-31' */

            if (V0BILH_DTQITBCO > "2005-08-31")
            {

                /*" -1921- MOVE 2 TO V1BILC-PCIOCC. */
                _.Move(2, V1BILC_PCIOCC);
            }


            /*" -1922- IF V0BILH-DTQITBCO > '2006-08-31' */

            if (V0BILH_DTQITBCO > "2006-08-31")
            {

                /*" -1926- MOVE 0 TO V1BILC-PCIOCC. */
                _.Move(0, V1BILC_PCIOCC);
            }


            /*" -1934- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_6 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_6();

            /*" -1937- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1938- DISPLAY 'R1070-00 (ERRO - SELECT RAMOCOMP)          ' */
                _.Display($"R1070-00 (ERRO - SELECT RAMOCOMP)          ");

                /*" -1940- DISPLAY 'RAMO: ' V1BILC-RAMOFR ' ' 'DATA: ' V0BILH-DTQITBCO */

                $"RAMO: {V1BILC_RAMOFR} DATA: {V0BILH_DTQITBCO}"
                .Display();

                /*" -1942- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1946- MOVE RAMOCOMP-PCT-IOCC-RAMO TO V1BILC-PCIOCC. */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO, V1BILC_PCIOCC);

            /*" -1954- MOVE V1BILC-PCIOCC TO V0APOL-PCIOCC */
            _.Move(V1BILC_PCIOCC, V0APOL_PCIOCC);

            /*" -1957- COMPUTE WWORK-IOCC ROUNDED = WWORK-PR-TOT * V1BILC-PCIOCC / 100. */
            AREA_DE_WORK.WWORK_IOCC.Value = AREA_DE_WORK.WWORK_PR_TOT * V1BILC_PCIOCC / 100f;

            /*" -1959- COMPUTE WWORK-PR-APOL = WWORK-PR-TOT - WWORK-IOCC. */
            AREA_DE_WORK.WWORK_PR_APOL.Value = AREA_DE_WORK.WWORK_PR_TOT - AREA_DE_WORK.WWORK_IOCC;

            /*" -1962- MOVE WWORK-PR-APOL TO V1BILC-PRMTAR-IX. */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V1BILC_PRMTAR_IX);

            /*" -1964- MOVE ' ' TO WTEM-PROPESTIP. */
            _.Move(" ", AREA_DE_WORK.WTEM_PROPESTIP);

            /*" -1972- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_7 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_7();

            /*" -1975- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1976- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1977- MOVE 'N' TO WTEM-PROPESTIP */
                    _.Move("N", AREA_DE_WORK.WTEM_PROPESTIP);

                    /*" -1978- ELSE */
                }
                else
                {


                    /*" -1979- DISPLAY 'R1070-00 (ERRO - SELECT V0PROP_ESTIPULANTE).' */
                    _.Display($"R1070-00 (ERRO - SELECT V0PROP_ESTIPULANTE).");

                    /*" -1982- DISPLAY 'EMPR: ' V1BILC-COD-EMPR ' ' 'PROD: ' V1BILC-CODPRODU ' ' 'BILH: ' V0BILH-NUMBIL */

                    $"EMPR: {V1BILC_COD_EMPR} PROD: {V1BILC_CODPRODU} BILH: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -1983- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1984- ELSE */
                }

            }
            else
            {


                /*" -1988- MOVE 'S' TO WTEM-PROPESTIP. */
                _.Move("S", AREA_DE_WORK.WTEM_PROPESTIP);
            }


            /*" -1989- IF WTEM-PROPESTIP EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PROPESTIP == "S")
            {

                /*" -1990- MOVE V0PROE-CODPRODU TO V0APOL-CODPRODU */
                _.Move(V0PROE_CODPRODU, V0APOL_CODPRODU);

                /*" -1991- ELSE */
            }
            else
            {


                /*" -1993- MOVE V1BILP-CODPRODU TO V0APOL-CODPRODU. */
                _.Move(V1BILP_CODPRODU, V0APOL_CODPRODU);
            }


            /*" -1995- MOVE '1065' TO WNR-EXEC-SQL. */
            _.Move("1065", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2047- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_1();

            /*" -2050- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2051- DISPLAY 'R1065-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"R1065-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -2053- DISPLAY 'APOLICE: ' V0APOL-NUM-APOL ' ' 'OPCAO:   ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APOL_NUM_APOL} OPCAO:   {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2055- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2056- ADD +1 TO AC-I-V0APOLICE. */
            AREA_DE_WORK.AC_I_V0APOLICE.Value = AREA_DE_WORK.AC_I_V0APOLICE + +1;

            /*" -2057- MOVE V0APOL-NUM-APOL TO V0ENDO-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0ENDO_NUM_APOL);

            /*" -2058- MOVE ZEROS TO V0ENDO-NRENDOS */
            _.Move(0, V0ENDO_NRENDOS);

            /*" -2059- MOVE ZEROS TO V0ENDO-CODSUBES */
            _.Move(0, V0ENDO_CODSUBES);

            /*" -2060- MOVE V0BILH-FONTE TO V0ENDO-FONTE */
            _.Move(V0BILH_FONTE, V0ENDO_FONTE);

            /*" -2061- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -2062- MOVE V1SIST-DTMOVACB TO V0ENDO-DT-LIBER */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DT_LIBER);

            /*" -2064- MOVE V1SIST-DTMOVACB TO V0ENDO-DTEMIS */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DTEMIS);

            /*" -2066- MOVE 104 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR. */
            _.Move(104, V0ENDO_BCORCAP, V0ENDO_BCOCOBR);

            /*" -2067- MOVE V0BILH-AGECOBR TO V0ENDO-AGERCAP. */
            _.Move(V0BILH_AGECOBR, V0ENDO_AGERCAP);

            /*" -2068- MOVE V1RCAC-AGEAVISO TO V0ENDO-AGECOBR. */
            _.Move(V1RCAC_AGEAVISO, V0ENDO_AGECOBR);

            /*" -2070- MOVE '0' TO V0ENDO-DACCOBR */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -2071- MOVE WWORK-NRRCAP TO V0ENDO-NRRCAP */
            _.Move(AREA_DE_WORK.FILLER_5.WWORK_NRRCAP, V0ENDO_NRRCAP);

            /*" -2072- MOVE V0BILH-VLRCAP TO V0ENDO-VLRCAP. */
            _.Move(V0BILH_VLRCAP, V0ENDO_VLRCAP);

            /*" -2073- MOVE '0' TO V0ENDO-DACRCAP */
            _.Move("0", V0ENDO_DACRCAP);

            /*" -2074- MOVE '0' TO V0ENDO-IDRCAP */
            _.Move("0", V0ENDO_IDRCAP);

            /*" -2075- MOVE V0BILH-DTQITBCO TO V0ENDO-DATARCAP */
            _.Move(V0BILH_DTQITBCO, V0ENDO_DATARCAP);

            /*" -2085- MOVE +0 TO VIND-DATARCAP. */
            _.Move(+0, VIND_DATARCAP);

            /*" -2098- MOVE V0ENDO-DTINIVIG TO V0ENDO-DATPRO */
            _.Move(V0ENDO_DTINIVIG, V0ENDO_DATPRO);

            /*" -2099- MOVE ZEROS TO V0ENDO-PCENTRAD */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -2100- MOVE ZEROS TO V0ENDO-PCADICIO */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -2101- MOVE ZEROS TO V0ENDO-PRESTA1 */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -2102- MOVE ZEROS TO V0ENDO-QTPARCEL */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -2103- MOVE ZEROS TO V0ENDO-CDFRACIO */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -2104- MOVE ZEROS TO V0ENDO-QTPRESTA */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -2105- MOVE 1 TO V0ENDO-QTITENS */
            _.Move(1, V0ENDO_QTITENS);

            /*" -2106- MOVE SPACES TO V0ENDO-CODTXT */
            _.Move("", V0ENDO_CODTXT);

            /*" -2108- MOVE ZEROS TO V0ENDO-CDACEITA */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -2111- MOVE V1BILC-CODUNIMO TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(V1BILC_CODUNIMO, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -2112- MOVE '0' TO V0ENDO-TIPO-ENDO */
            _.Move("0", V0ENDO_TIPO_ENDO);

            /*" -2114- MOVE 'VA6005B' TO V0ENDO-COD-USUAR */
            _.Move("VA6005B", V0ENDO_COD_USUAR);

            /*" -2116- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -2118- MOVE '1' TO V0ENDO-SITUACAO. */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -2119- MOVE ZEROS TO V0ENDO-COD-EMPRESA */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -2120- MOVE '1' TO V0ENDO-CORRECAO */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -2121- MOVE 'S' TO V0ENDO-ISENTA-CST */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -2122- MOVE -1 TO VIND-DTVENCTO */
            _.Move(-1, VIND_DTVENCTO);

            /*" -2124- MOVE -1 TO VIND-VLCUSEMI */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -2126- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -2127- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -2130- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -2132- MOVE '1075' TO WNR-EXEC-SQL. */
            _.Move("1075", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2222- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_2();

            /*" -2225- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2226- DISPLAY 'R1075-00 (ERRO - INSERT V0ENDOSSO)...' */
                _.Display($"R1075-00 (ERRO - INSERT V0ENDOSSO)...");

                /*" -2227- DISPLAY 'V0ENDO-NUM-APOL   = ' V0ENDO-NUM-APOL */
                _.Display($"V0ENDO-NUM-APOL   = {V0ENDO_NUM_APOL}");

                /*" -2228- DISPLAY 'V0ENDO-NRENDOS    = ' V0ENDO-NRENDOS */
                _.Display($"V0ENDO-NRENDOS    = {V0ENDO_NRENDOS}");

                /*" -2229- DISPLAY 'V0ENDO-FONTE      = ' V0ENDO-FONTE */
                _.Display($"V0ENDO-FONTE      = {V0ENDO_FONTE}");

                /*" -2230- DISPLAY 'V0ENDO-NRPROPOS   = ' V0ENDO-NRPROPOS */
                _.Display($"V0ENDO-NRPROPOS   = {V0ENDO_NRPROPOS}");

                /*" -2231- DISPLAY 'RAMO              = ' WWORK-RAMO-ANT */
                _.Display($"RAMO              = {WWORK_RAMO_ANT}");

                /*" -2232- DISPLAY 'OPCAO             = ' WWORK-OPCAO-ANT */
                _.Display($"OPCAO             = {WWORK_OPCAO_ANT}");

                /*" -2234- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2250- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

            /*" -2453- PERFORM R1066-00-TRATA-EVOGEPES016. */

            R1066_00_TRATA_EVOGEPES016_SECTION();

            /*" -2454- IF V1BILC-VALMAX GREATER ZEROS */

            if (V1BILC_VALMAX > 00)
            {

                /*" -2457- PERFORM R4280-00-TRATA-FC0105S. */

                R4280_00_TRATA_FC0105S_SECTION();
            }


            /*" -2459- PERFORM R1080-00-GRAVA-V0APOLCOSCED. */

            R1080_00_GRAVA_V0APOLCOSCED_SECTION();

            /*" -2461- IF WACC-PCTCED GREATER ZEROS AND WACC-QTCOSSEG GREATER ZEROS */

            if (AREA_DE_WORK.WACC_PCTCED > 00 && AREA_DE_WORK.WACC_QTCOSSEG > 00)
            {

                /*" -2463- PERFORM R1090-00-UPDATE-V0APOLICE. */

                R1090_00_UPDATE_V0APOLICE_SECTION();
            }


            /*" -2464- MOVE V0APOL-NUM-APOL TO V0PARC-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0PARC_NUM_APOL);

            /*" -2465- MOVE 0 TO V0PARC-NRENDOS */
            _.Move(0, V0PARC_NRENDOS);

            /*" -2467- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -2468- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -2469- MOVE V0BILH-FONTE TO V0PARC-FONTE */
            _.Move(V0BILH_FONTE, V0PARC_FONTE);

            /*" -2470- MOVE V0BILH-NUMBIL TO V0PARC-NRTIT */
            _.Move(V0BILH_NUMBIL, V0PARC_NRTIT);

            /*" -2471- MOVE WWORK-PR-APOL TO V0PARC-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_PRM_TAR_IX);

            /*" -2472- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -2473- MOVE WWORK-PR-APOL TO V0PARC-OTNPRLIQ */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_OTNPRLIQ);

            /*" -2474- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -2480- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -2482- MOVE WWORK-IOCC TO V0PARC-OTNIOF. */
            _.Move(AREA_DE_WORK.WWORK_IOCC, V0PARC_OTNIOF);

            /*" -2487- COMPUTE V0PARC-OTNTOTAL = V0PARC-OTNPRLIQ + V0PARC-OTNADFRA + V0PARC-OTNCUSTO + V0PARC-OTNIOF. */
            V0PARC_OTNTOTAL.Value = V0PARC_OTNPRLIQ + V0PARC_OTNADFRA + V0PARC_OTNCUSTO + V0PARC_OTNIOF;

            /*" -2488- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -2489- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -2490- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -2492- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -2494- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2515- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_3();

            /*" -2518- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2519- DISPLAY 'R2000-00 (ERRO - INSERT V0PARCELA)...' */
                _.Display($"R2000-00 (ERRO - INSERT V0PARCELA)...");

                /*" -2523- DISPLAY 'APOL: ' V0PARC-NUM-APOL '  ' 'ENDO: ' V0PARC-NRENDOS '  ' 'PARC: ' V0PARC-NRPARCEL '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0PARC_NUM_APOL}  ENDO: {V0PARC_NRENDOS}  PARC: {V0PARC_NRPARCEL}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -2525- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2527- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

            /*" -2529- PERFORM R2010-00-GRAVA-V0HISTOPARC. */

            R2010_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -2531- PERFORM R2020-00-GRAVA-OPERACAO-BAIXA. */

            R2020_00_GRAVA_OPERACAO_BAIXA_SECTION();

            /*" -2532- MOVE V0APOL-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0COBA_NUM_APOL);

            /*" -2533- MOVE 0 TO V0COBA-NRENDOS */
            _.Move(0, V0COBA_NRENDOS);

            /*" -2534- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -2535- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -2536- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -2537- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -2538- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -2540- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -2541- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -2542- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -2543- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -2544- MOVE WWORK-RAMO-ANT TO V0COBA-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0COBA_RAMOFR);

            /*" -2546- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
            _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

            /*" -2547- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-IX */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_IX);

            /*" -2548- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_IX);

            /*" -2549- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-VR */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_VR);

            /*" -2551- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-VR */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_VR);

            /*" -2553- MOVE 100 TO V0COBA-PCT-COBERT. */
            _.Move(100, V0COBA_PCT_COBERT);

            /*" -2555- MOVE '2001' TO WNR-EXEC-SQL. */
            _.Move("2001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2575- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_4 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_4();

            /*" -2578- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2579- DISPLAY 'R2030-00 (ERRO - INSERT V0COBERAPOL)...' */
                _.Display($"R2030-00 (ERRO - INSERT V0COBERAPOL)...");

                /*" -2582- DISPLAY 'APOL: ' V0COBA-NUM-APOL '  ' 'ENDO: ' V0COBA-NRENDOS '  ' 'RAMO: ' V0COBA-RAMOFR '  ' */

                $"APOL: {V0COBA_NUM_APOL}  ENDO: {V0COBA_NRENDOS}  RAMO: {V0COBA_RAMOFR}  "
                .Display();

                /*" -2584- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2591- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

            /*" -2592- IF WWORK-FUNDAO EQUAL 'S' */

            if (AREA_DE_WORK.WWORK_FUNDAO == "S")
            {

                /*" -2597- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -2598- MOVE 17256 TO V0ADIA-CODPDT */
            _.Move(17256, V0ADIA_CODPDT);

            /*" -2600- MOVE 010 TO V0ADIA-FONTE */
            _.Move(010, V0ADIA_FONTE);

            /*" -2601- MOVE '2034' TO WNR-EXEC-SQL. */
            _.Move("2034", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2603- MOVE V0APOL-NUMBIL TO WHOST-NUMBIL. */
            _.Move(V0APOL_NUMBIL, WHOST_NUMBIL);

            /*" -2610- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_8 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_8();

            /*" -2613- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2614- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -2615- ELSE */
            }
            else
            {


                /*" -2616- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2617- DISPLAY 'R2034-00 (ERRO - SELECT V0ADIANTA)...' */
                    _.Display($"R2034-00 (ERRO - SELECT V0ADIANTA)...");

                    /*" -2618- DISPLAY 'APOLICE = ' WHOST-NUMBIL */
                    _.Display($"APOLICE = {WHOST_NUMBIL}");

                    /*" -2620- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2622- MOVE '2035' TO WNR-EXEC-SQL. */
            _.Move("2035", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2626- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_9 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_9();

            /*" -2629- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2630- DISPLAY 'R2035-00 (ERRO - SELECT V0NUMERO_OUTROS)...' */
                _.Display($"R2035-00 (ERRO - SELECT V0NUMERO_OUTROS)...");

                /*" -2632- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2633- COMPUTE V1NOUT-NUMOPG = V1NOUT-NUMOPG + 1. */
            V1NOUT_NUMOPG.Value = V1NOUT_NUMOPG + 1;

            /*" -2635- MOVE V1NOUT-NUMOPG TO V0ADIA-NUMOPG */
            _.Move(V1NOUT_NUMOPG, V0ADIA_NUMOPG);

            /*" -2637- MOVE '2040' TO WNR-EXEC-SQL. */
            _.Move("2040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2641- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2();

            /*" -2644- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2645- DISPLAY 'R2040-00 (ERRO - UPDATE V0NUMERO_OUTROS)...' */
                _.Display($"R2040-00 (ERRO - UPDATE V0NUMERO_OUTROS)...");

                /*" -2646- DISPLAY 'NUMOPG: ' V1NOUT-NUMOPG */
                _.Display($"NUMOPG: {V1NOUT_NUMOPG}");

                /*" -2648- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2649- MOVE ZEROS TO V0ADIA-QTPRESTA */
            _.Move(0, V0ADIA_QTPRESTA);

            /*" -2650- MOVE ZEROS TO V0ADIA-NRPROPOS */
            _.Move(0, V0ADIA_NRPROPOS);

            /*" -2651- MOVE V0APOL-NUM-APOL TO V0ADIA-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0ADIA_NUM_APOL);

            /*" -2652- MOVE ZEROS TO V0ADIA-NRENDOS */
            _.Move(0, V0ADIA_NRENDOS);

            /*" -2653- MOVE ZEROS TO V0ADIA-NRPARCEL */
            _.Move(0, V0ADIA_NRPARCEL);

            /*" -2654- MOVE V1SIST-DTMOVABE TO V0ADIA-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0ADIA_DTMOVTO);

            /*" -2655- MOVE '0' TO V0ADIA-SITUACAO */
            _.Move("0", V0ADIA_SITUACAO);

            /*" -2656- MOVE ZEROS TO V0ADIA-COD-EMP */
            _.Move(0, V0ADIA_COD_EMP);

            /*" -2658- MOVE '2' TO V0ADIA-TIPO-ADT */
            _.Move("2", V0ADIA_TIPO_ADT);

            /*" -2660- MOVE '2045' TO WNR-EXEC-SQL. */
            _.Move("2045", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2676- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_5();

            /*" -2679- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2686- DISPLAY 'R2045-00 (ERRO - INSERT V0ADIANTA)...' 'CODPDT: ' V0ADIA-CODPDT '  ' 'NUMOPG: ' V0ADIA-NUMOPG '  ' 'APOL: ' V0ADIA-NUM-APOL '  ' 'ENDO: ' V0ADIA-NRENDOS '  ' 'PARC: ' V0ADIA-NRPARCEL '  ' 'FONTE: ' V0ADIA-FONTE */

                $"R2045-00 (ERRO - INSERT V0ADIANTA)...CODPDT: {V0ADIA_CODPDT}  NUMOPG: {V0ADIA_NUMOPG}  APOL: {V0ADIA_NUM_APOL}  ENDO: {V0ADIA_NRENDOS}  PARC: {V0ADIA_NRPARCEL}  FONTE: {V0ADIA_FONTE}"
                .Display();

                /*" -2688- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2693- ADD +1 TO AC-I-V0ADIANTA. */
            AREA_DE_WORK.AC_I_V0ADIANTA.Value = AREA_DE_WORK.AC_I_V0ADIANTA + +1;

            /*" -2694- MOVE 17256 TO V0FORM-CODPDT */
            _.Move(17256, V0FORM_CODPDT);

            /*" -2695- MOVE 010 TO V0FORM-FONTE */
            _.Move(010, V0FORM_FONTE);

            /*" -2696- MOVE V0ADIA-NUMOPG TO V0FORM-NUMOPG */
            _.Move(V0ADIA_NUMOPG, V0FORM_NUMOPG);

            /*" -2697- MOVE ZEROS TO V0FORM-NRPROPOS */
            _.Move(0, V0FORM_NRPROPOS);

            /*" -2698- MOVE V0APOL-NUM-APOL TO V0FORM-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0FORM_NUM_APOL);

            /*" -2699- MOVE ZEROS TO V0FORM-NRENDOS */
            _.Move(0, V0FORM_NRENDOS);

            /*" -2700- MOVE ZEROS TO V0FORM-NRPARCEL */
            _.Move(0, V0FORM_NRPARCEL);

            /*" -2701- MOVE ZEROS TO V0FORM-NUMPTC */
            _.Move(0, V0FORM_NUMPTC);

            /*" -2702- MOVE V0ADIA-VALADT TO V0FORM-VALRCP */
            _.Move(V0ADIA_VALADT, V0FORM_VALRCP);

            /*" -2703- MOVE ZEROS TO V0FORM-PCGACM */
            _.Move(0, V0FORM_PCGACM);

            /*" -2704- MOVE '0' TO V0FORM-SITUACAO */
            _.Move("0", V0FORM_SITUACAO);

            /*" -2705- MOVE V0ADIA-VALADT TO V0FORM-VALSDO */
            _.Move(V0ADIA_VALADT, V0FORM_VALSDO);

            /*" -2706- MOVE V1SIST-DTMOVABE TO V0FORM-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0FORM_DTMOVTO);

            /*" -2707- MOVE V1SIST-DTMOVABE TO V0FORM-DTVENCTO */
            _.Move(V1SIST_DTMOVABE, V0FORM_DTVENCTO);

            /*" -2709- MOVE ZEROS TO V0FORM-COD-EMP */
            _.Move(0, V0FORM_COD_EMP);

            /*" -2711- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2729- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_6 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_6();

            /*" -2732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2739- DISPLAY 'PROBLEMAS NA INSERCAO (V0FORMAREC) ... ' ' ' V0FORM-CODPDT ' ' V0FORM-NUMOPG ' ' V0FORM-NUM-APOL ' ' V0FORM-NRENDOS ' ' V0FORM-NRPARCEL ' ' V0FORM-FONTE */

                $"PROBLEMAS NA INSERCAO (V0FORMAREC) ...  {V0FORM_CODPDT} {V0FORM_NUMOPG} {V0FORM_NUM_APOL} {V0FORM_NRENDOS} {V0FORM_NRPARCEL} {V0FORM_FONTE}"
                .Display();

                /*" -2744- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2745- MOVE 17256 TO V0HISR-CODPDT */
            _.Move(17256, V0HISR_CODPDT);

            /*" -2746- MOVE 010 TO V0HISR-FONTE */
            _.Move(010, V0HISR_FONTE);

            /*" -2747- MOVE V0ADIA-NUMOPG TO V0HISR-NUMOPG */
            _.Move(V0ADIA_NUMOPG, V0HISR_NUMOPG);

            /*" -2748- MOVE ZEROS TO V0HISR-NRPROPOS */
            _.Move(0, V0HISR_NRPROPOS);

            /*" -2749- MOVE V0APOL-NUM-APOL TO V0HISR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISR_NUM_APOL);

            /*" -2750- MOVE ZEROS TO V0HISR-NRENDOS */
            _.Move(0, V0HISR_NRENDOS);

            /*" -2751- MOVE ZEROS TO V0HISR-NRPARCEL */
            _.Move(0, V0HISR_NRPARCEL);

            /*" -2752- MOVE ZEROS TO V0HISR-NUMPTC */
            _.Move(0, V0HISR_NUMPTC);

            /*" -2753- MOVE V0ADIA-VALADT TO V0HISR-VALRCP */
            _.Move(V0ADIA_VALADT, V0HISR_VALRCP);

            /*" -2754- MOVE 999999 TO V0HISR-NUMREC */
            _.Move(999999, V0HISR_NUMREC);

            /*" -2755- MOVE V1SIST-DTMOVABE TO V0HISR-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISR_DTMOVTO);

            /*" -2756- MOVE 1401 TO V0HISR-OPERACAO */
            _.Move(1401, V0HISR_OPERACAO);

            /*" -2758- MOVE ZEROS TO V0HISR-COD-EMP */
            _.Move(0, V0HISR_COD_EMP);

            /*" -2760- MOVE '2055' TO WNR-EXEC-SQL. */
            _.Move("2055", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2777- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_7 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_7();

            /*" -2780- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2787- DISPLAY 'PROBLEMAS NA INSERCAO (V0HISTOREC) ... ' ' ' V0HISR-CODPDT ' ' V0HISR-NUMOPG ' ' V0HISR-NUM-APOL ' ' V0HISR-NRENDOS ' ' V0HISR-NRPARCEL ' ' V0HISR-FONTE */

                $"PROBLEMAS NA INSERCAO (V0HISTOREC) ...  {V0HISR_CODPDT} {V0HISR_NUMOPG} {V0HISR_NUM_APOL} {V0HISR_NRENDOS} {V0HISR_NRPARCEL} {V0HISR_FONTE}"
                .Display();

                /*" -2787- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_00_LEITURA */

            R1000_00_LEITURA();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -1678- EXEC SQL SELECT SEQ_APOLICE INTO :V1NAES-SEQ-APOL FROM SEGUROS.V1NUMERO_AES WHERE COD_ORGAO = :WH-JV1-COD-ORGAO AND COD_RAMO = :V0BILH-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                WH_JV1_COD_ORGAO = WORK_JV1.WH_JV1_COD_ORGAO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NAES_SEQ_APOL, V1NAES_SEQ_APOL);
            }


        }

        [StopWatch]
        /*" R1000-00-LEITURA */
        private void R1000_00_LEITURA(bool isPerform = false)
        {
            /*" -2793- IF WS-SIVPF EQUAL 'S' */

            if (AREA_DE_WORK.WS_SIVPF == "S")
            {

                /*" -2794- IF V0BILH-SITUACAO EQUAL '9' */

                if (V0BILH_SITUACAO == "9")
                {

                    /*" -2795- MOVE 'EMT' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("EMT", WHOST_SIT_PROP_SIVPF);

                    /*" -2796- ELSE */
                }
                else
                {


                    /*" -2797- MOVE 'PEN' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("PEN", WHOST_SIT_PROP_SIVPF);

                    /*" -2799- END-IF */
                }


                /*" -2801- IF V0SIVPF-SIT-PROPOSTA EQUAL WHOST-SIT-PROP-SIVPF NEXT SENTENCE */

                if (V0SIVPF_SIT_PROPOSTA == WHOST_SIT_PROP_SIVPF)
                {

                    /*" -2802- ELSE */
                }
                else
                {


                    /*" -2803- MOVE '2060' TO WNR-EXEC-SQL */
                    _.Move("2060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2810- PERFORM R1000_00_LEITURA_DB_UPDATE_1 */

                    R1000_00_LEITURA_DB_UPDATE_1();

                    /*" -2812- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -2814- DISPLAY 'PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ) ' ' ' V0BILH-NUMBIL */

                        $"PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ)  {V0BILH_NUMBIL}"
                        .Display();

                        /*" -2816- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2816- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

        }

        [StopWatch]
        /*" R1000-00-LEITURA-DB-UPDATE-1 */
        public void R1000_00_LEITURA_DB_UPDATE_1()
        {
            /*" -2810- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROP-SIVPF, SITUACAO_ENVIO = 'S' , COD_USUARIO = 'VA6005B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_SICOB = :V0BILH-NUMBIL END-EXEC */

            var r1000_00_LEITURA_DB_UPDATE_1_Update1 = new R1000_00_LEITURA_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROP_SIVPF = WHOST_SIT_PROP_SIVPF.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R1000_00_LEITURA_DB_UPDATE_1_Update1.Execute(r1000_00_LEITURA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -1702- EXEC SQL SELECT NUM_SICOB, SIT_PROPOSTA, NUM_PROPOSTA_SIVPF INTO :V0CONV-NUM-SICOB, :V0SIVPF-SIT-PROPOSTA, :V0CONV-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :V0BILH-NUMBIL END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_SICOB, V0CONV_NUM_SICOB);
                _.Move(executed_1.V0SIVPF_SIT_PROPOSTA, V0SIVPF_SIT_PROPOSTA);
                _.Move(executed_1.V0CONV_NUM_PROPOSTA_SIVPF, V0CONV_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -1833- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET SEQ_APOLICE = :V0NAES-SEQ-APOL WHERE COD_ORGAO = :WH-JV1-COD-ORGAO AND COD_RAMO = :WWORK-RAMO-ANT END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0NAES_SEQ_APOL = V0NAES_SEQ_APOL.ToString(),
                WH_JV1_COD_ORGAO = WORK_JV1.WH_JV1_COD_ORGAO.ToString(),
                WWORK_RAMO_ANT = WWORK_RAMO_ANT.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -1723- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :V0CONV-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :V0BILH-NUMBIL END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_PROPOSTA_SIVPF, V0CONV_NUM_PROPOSTA_SIVPF);
            }


        }

        [StopWatch]
        /*" R1040-PRODUTO-RUNOFF-SECTION */
        private void R1040_PRODUTO_RUNOFF_SECTION()
        {
            /*" -2824- SET WS-IND-PROD TO 1 */
            JVBKINCL.WS_IND_PROD.Value = 1;

            /*" -2826- SEARCH CVPPROD AT END */
            void SearchAtEnd0()
            {

                /*" -2827- SET WS-PROD-RUNON TO TRUE */
                AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] = true;

                /*" -2828- WHEN CVPPROD(WS-IND-PROD) EQUAL WS-COD-PRODUTO */
            };

            var mustSearchAtEnd0 = true;
            for (; JVBKINCL.WS_IND_PROD < JVBKINCL.CVP_PRODUTO.CVPPROD.Items.Count; JVBKINCL.WS_IND_PROD.Value++)
            {

                if (JVBKINCL.CVP_PRODUTO.CVPPROD[JVBKINCL.WS_IND_PROD] == WS_COD_PRODUTO)
                {

                    mustSearchAtEnd0 = false;

                    /*" -2829- SET WS-PROD-RUNOFF TO TRUE */
                    AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNOFF"] = true;

                    /*" -2831- END-SEARCH */

                    /*" -2831- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -1792- EXEC SQL SELECT SUM(VAL_COBERTURA_IX), SUM(PRM_TARIFARIO_IX), SUM(VALMAX_COBERBAS), SUM(VLPRMTOT) INTO :V1BILC-IMPSEG-IX, :V1BILC-PRMTAR-IX, :V1BILC-VALMAX, :V1BILC-PRMTOTAL:VIND-PRMTOTAL FROM SEGUROS.V0BILHETE_COBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO AND CODPRODU = :V1BILC-CODPRODU END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
                V1BILC_CODPRODU = V1BILC_CODPRODU.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
                V1BILC_OPCAO = V1BILC_OPCAO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_IMPSEG_IX, V1BILC_IMPSEG_IX);
                _.Move(executed_1.V1BILC_PRMTAR_IX, V1BILC_PRMTAR_IX);
                _.Move(executed_1.V1BILC_VALMAX, V1BILC_VALMAX);
                _.Move(executed_1.V1BILC_PRMTOTAL, V1BILC_PRMTOTAL);
                _.Move(executed_1.VIND_PRMTOTAL, VIND_PRMTOTAL);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_1()
        {
            /*" -2047- EXEC SQL INSERT INTO SEGUROS.V0APOLICE (CODCLIEN , NUM_APOLICE , NUM_ITEM , MODALIDA , ORGAO , RAMO , NUM_APOL_ANTERIOR , NUMBIL , TIPSGU , TIPAPO , TIPCALC , PODPUBL , NUM_ATA , ANO_ATA , IDEMAN , PCDESCON , PCIOCC , TPCOSCED , QTCOSSEG , PCTCED , DATA_SORTEIO , COD_EMPRESA , TIMESTAMP , CODPRODU , TPCORRET) VALUES (:V0APOL-CODCLIEN , :V0APOL-NUM-APOL , :V0APOL-NUM-ITEM , :V0APOL-MODALIDA , :V0APOL-ORGAO , :V0APOL-RAMO , :V0APOL-NUM-APO-ANT , :V0APOL-NUMBIL , :V0APOL-TIPSGU , :V0APOL-TIPAPO , :V0APOL-TIPCALC , :V0APOL-PODPUBL , :V0APOL-NUM-ATA , :V0APOL-ANO-ATA , :V0APOL-IDEMAN , :V0APOL-PCDESCON , :V0APOL-PCIOCC , :V0APOL-TPCOSCED , :V0APOL-QTCOSSEG , :V0APOL-PCTCED , NULL , :V0APOL-COD-EMPRESA , CURRENT TIMESTAMP , :V0APOL-CODPRODU , :V0APOL-TPCORRET) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1()
            {
                V0APOL_CODCLIEN = V0APOL_CODCLIEN.ToString(),
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0APOL_NUM_ITEM = V0APOL_NUM_ITEM.ToString(),
                V0APOL_MODALIDA = V0APOL_MODALIDA.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
                V0APOL_NUM_APO_ANT = V0APOL_NUM_APO_ANT.ToString(),
                V0APOL_NUMBIL = V0APOL_NUMBIL.ToString(),
                V0APOL_TIPSGU = V0APOL_TIPSGU.ToString(),
                V0APOL_TIPAPO = V0APOL_TIPAPO.ToString(),
                V0APOL_TIPCALC = V0APOL_TIPCALC.ToString(),
                V0APOL_PODPUBL = V0APOL_PODPUBL.ToString(),
                V0APOL_NUM_ATA = V0APOL_NUM_ATA.ToString(),
                V0APOL_ANO_ATA = V0APOL_ANO_ATA.ToString(),
                V0APOL_IDEMAN = V0APOL_IDEMAN.ToString(),
                V0APOL_PCDESCON = V0APOL_PCDESCON.ToString(),
                V0APOL_PCIOCC = V0APOL_PCIOCC.ToString(),
                V0APOL_TPCOSCED = V0APOL_TPCOSCED.ToString(),
                V0APOL_QTCOSSEG = V0APOL_QTCOSSEG.ToString(),
                V0APOL_PCTCED = V0APOL_PCTCED.ToString(),
                V0APOL_COD_EMPRESA = V0APOL_COD_EMPRESA.ToString(),
                V0APOL_CODPRODU = V0APOL_CODPRODU.ToString(),
                V0APOL_TPCORRET = V0APOL_TPCORRET.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_2()
        {
            /*" -2222- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-CODSUBES , :V0ENDO-FONTE , :V0ENDO-NRPROPOS , :V0ENDO-DATPRO , :V0ENDO-DT-LIBER , :V0ENDO-DTEMIS , :V0ENDO-NRRCAP , :V0ENDO-VLRCAP , :V0ENDO-BCORCAP , :V0ENDO-AGERCAP , :V0ENDO-DACRCAP , :V0ENDO-IDRCAP , :V0ENDO-BCOCOBR , :V0ENDO-AGECOBR , :V0ENDO-DACCOBR , :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG , :V0ENDO-CDFRACIO , :V0ENDO-PCENTRAD , :V0ENDO-PCADICIO , :V0ENDO-PRESTA1 , :V0ENDO-QTPARCEL , :V0ENDO-QTPRESTA , :V0ENDO-QTITENS , :V0ENDO-CODTXT , :V0ENDO-CDACEITA , :V0ENDO-MOEDA-IMP , :V0ENDO-MOEDA-PRM , :V0ENDO-TIPO-ENDO , :V0ENDO-COD-USUAR , :V0ENDO-OCORR-END , :V0ENDO-SITUACAO , :V0ENDO-DATARCAP:VIND-DATARCAP , :V0ENDO-COD-EMPRESA , :V0ENDO-CORRECAO , :V0ENDO-ISENTA-CST , CURRENT TIMESTAMP , :V0ENDO-DTVENCTO:VIND-DTVENCTO , :V0ENDO-CFPREFIX:VIND-CFPREFIX , :V0ENDO-VLCUSEMI:VIND-VLCUSEMI , :V0ENDO-RAMO , :V0ENDO-CODPRODU) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1()
            {
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
                V0ENDO_NRPROPOS = V0ENDO_NRPROPOS.ToString(),
                V0ENDO_DATPRO = V0ENDO_DATPRO.ToString(),
                V0ENDO_DT_LIBER = V0ENDO_DT_LIBER.ToString(),
                V0ENDO_DTEMIS = V0ENDO_DTEMIS.ToString(),
                V0ENDO_NRRCAP = V0ENDO_NRRCAP.ToString(),
                V0ENDO_VLRCAP = V0ENDO_VLRCAP.ToString(),
                V0ENDO_BCORCAP = V0ENDO_BCORCAP.ToString(),
                V0ENDO_AGERCAP = V0ENDO_AGERCAP.ToString(),
                V0ENDO_DACRCAP = V0ENDO_DACRCAP.ToString(),
                V0ENDO_IDRCAP = V0ENDO_IDRCAP.ToString(),
                V0ENDO_BCOCOBR = V0ENDO_BCOCOBR.ToString(),
                V0ENDO_AGECOBR = V0ENDO_AGECOBR.ToString(),
                V0ENDO_DACCOBR = V0ENDO_DACCOBR.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                V0ENDO_CDFRACIO = V0ENDO_CDFRACIO.ToString(),
                V0ENDO_PCENTRAD = V0ENDO_PCENTRAD.ToString(),
                V0ENDO_PCADICIO = V0ENDO_PCADICIO.ToString(),
                V0ENDO_PRESTA1 = V0ENDO_PRESTA1.ToString(),
                V0ENDO_QTPARCEL = V0ENDO_QTPARCEL.ToString(),
                V0ENDO_QTPRESTA = V0ENDO_QTPRESTA.ToString(),
                V0ENDO_QTITENS = V0ENDO_QTITENS.ToString(),
                V0ENDO_CODTXT = V0ENDO_CODTXT.ToString(),
                V0ENDO_CDACEITA = V0ENDO_CDACEITA.ToString(),
                V0ENDO_MOEDA_IMP = V0ENDO_MOEDA_IMP.ToString(),
                V0ENDO_MOEDA_PRM = V0ENDO_MOEDA_PRM.ToString(),
                V0ENDO_TIPO_ENDO = V0ENDO_TIPO_ENDO.ToString(),
                V0ENDO_COD_USUAR = V0ENDO_COD_USUAR.ToString(),
                V0ENDO_OCORR_END = V0ENDO_OCORR_END.ToString(),
                V0ENDO_SITUACAO = V0ENDO_SITUACAO.ToString(),
                V0ENDO_DATARCAP = V0ENDO_DATARCAP.ToString(),
                VIND_DATARCAP = VIND_DATARCAP.ToString(),
                V0ENDO_COD_EMPRESA = V0ENDO_COD_EMPRESA.ToString(),
                V0ENDO_CORRECAO = V0ENDO_CORRECAO.ToString(),
                V0ENDO_ISENTA_CST = V0ENDO_ISENTA_CST.ToString(),
                V0ENDO_DTVENCTO = V0ENDO_DTVENCTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                V0ENDO_CFPREFIX = V0ENDO_CFPREFIX.ToString(),
                VIND_CFPREFIX = VIND_CFPREFIX.ToString(),
                V0ENDO_VLCUSEMI = V0ENDO_VLCUSEMI.ToString(),
                VIND_VLCUSEMI = VIND_VLCUSEMI.ToString(),
                V0ENDO_RAMO = V0ENDO_RAMO.ToString(),
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_5()
        {
            /*" -1902- EXEC SQL SELECT CODUNIMO, PCCOMCOR, PCIOCC INTO :V1BILC-CODUNIMO, :V1BILC-PCCOMCOR, :V1BILC-PCIOCC FROM SEGUROS.V0BILHETE_COBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO AND CODPRODU = :V1BILC-CODPRODU AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
                V1BILC_CODPRODU = V1BILC_CODPRODU.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
                V1BILC_OPCAO = V1BILC_OPCAO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_CODUNIMO, V1BILC_CODUNIMO);
                _.Move(executed_1.V1BILC_PCCOMCOR, V1BILC_PCCOMCOR);
                _.Move(executed_1.V1BILC_PCIOCC, V1BILC_PCIOCC);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_3()
        {
            /*" -2515- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1()
            {
                V0PARC_NUM_APOL = V0PARC_NUM_APOL.ToString(),
                V0PARC_NRENDOS = V0PARC_NRENDOS.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_DACPARC = V0PARC_DACPARC.ToString(),
                V0PARC_FONTE = V0PARC_FONTE.ToString(),
                V0PARC_NRTIT = V0PARC_NRTIT.ToString(),
                V0PARC_PRM_TAR_IX = V0PARC_PRM_TAR_IX.ToString(),
                V0PARC_VAL_DES_IX = V0PARC_VAL_DES_IX.ToString(),
                V0PARC_OTNPRLIQ = V0PARC_OTNPRLIQ.ToString(),
                V0PARC_OTNADFRA = V0PARC_OTNADFRA.ToString(),
                V0PARC_OTNCUSTO = V0PARC_OTNCUSTO.ToString(),
                V0PARC_OTNIOF = V0PARC_OTNIOF.ToString(),
                V0PARC_OTNTOTAL = V0PARC_OTNTOTAL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0PARC_QTDDOC = V0PARC_QTDDOC.ToString(),
                V0PARC_SITUACAO = V0PARC_SITUACAO.ToString(),
                V0PARC_COD_EMPRESA = V0PARC_COD_EMPRESA.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" R1050-00-TRATA-FUNDAO-SECTION */
        private void R1050_00_TRATA_FUNDAO_SECTION()
        {
            /*" -2844- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2851- MOVE 'S' TO WWORK-FUNDAO. */
            _.Move("S", AREA_DE_WORK.WWORK_FUNDAO);

            /*" -2857- PERFORM R1050_00_TRATA_FUNDAO_DB_SELECT_1 */

            R1050_00_TRATA_FUNDAO_DB_SELECT_1();

            /*" -2860- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2861- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2862- IF V0ENDO-CODPRODU EQUAL 8113 */

                    if (V0ENDO_CODPRODU == 8113)
                    {

                        /*" -2863- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD */
                        _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);

                        /*" -2864- ELSE */
                    }
                    else
                    {


                        /*" -2865- MOVE 2,74 TO PARAMPRO-VALOR-COMISSAO-PRD */
                        _.Move(2.74, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);

                        /*" -2866- END-IF */
                    }


                    /*" -2867- ELSE */
                }
                else
                {


                    /*" -2868- DISPLAY 'R1050-00 (ERRO 1 - SELECT PARAM_PRODUTO)...' */
                    _.Display($"R1050-00 (ERRO 1 - SELECT PARAM_PRODUTO)...");

                    /*" -2870- DISPLAY 'BILHETE : ' V0BILH-NUMBIL '  ' 'PRODUTO : ' V0ENDO-CODPRODU */

                    $"BILHETE : {V0BILH_NUMBIL}  PRODUTO : {V0ENDO_CODPRODU}"
                    .Display();

                    /*" -2872- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2873- MOVE 19224 TO V0APCR-CODCORR */
            _.Move(19224, V0APCR_CODCORR);

            /*" -2875- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -2878- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -2881- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -2886- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -2888- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -2889- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -2890- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -2891- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -2892- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -2893- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -2894- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -2895- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -2896- MOVE '2' TO V0APCR-INDCRT */
            _.Move("2", V0APCR_INDCRT);

            /*" -2898- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -2900- MOVE 'VA6005B' TO V0APCR-COD-USUARIO. */
            _.Move("VA6005B", V0APCR_COD_USUARIO);

            /*" -2901- IF PARAMPRO-VALOR-COMISSAO-PRD EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD == 00)
            {

                /*" -2902- GO TO R1050-20-TRATA-FENAE */

                R1050_20_TRATA_FENAE(); //GOTO
                return;

                /*" -2904- END-IF. */
            }


            /*" -2906- MOVE '105A' TO WNR-EXEC-SQL. */
            _.Move("105A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2922- PERFORM R1050_00_TRATA_FUNDAO_DB_INSERT_1 */

            R1050_00_TRATA_FUNDAO_DB_INSERT_1();

            /*" -2925- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2926- DISPLAY 'R1077-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1077-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -2929- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2931- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2931- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

            /*" -0- FLUXCONTROL_PERFORM R1050_20_TRATA_FENAE */

            R1050_20_TRATA_FENAE();

        }

        [StopWatch]
        /*" R1050-00-TRATA-FUNDAO-DB-SELECT-1 */
        public void R1050_00_TRATA_FUNDAO_DB_SELECT_1()
        {
            /*" -2857- EXEC SQL SELECT VALOR_COMISSAO_PRD INTO :PARAMPRO-VALOR-COMISSAO-PRD FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :V0ENDO-CODPRODU AND TIPO_FUNCIONARIO = '1' END-EXEC. */

            var r1050_00_TRATA_FUNDAO_DB_SELECT_1_Query1 = new R1050_00_TRATA_FUNDAO_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            var executed_1 = R1050_00_TRATA_FUNDAO_DB_SELECT_1_Query1.Execute(r1050_00_TRATA_FUNDAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
            }


        }

        [StopWatch]
        /*" R1050-00-TRATA-FUNDAO-DB-INSERT-1 */
        public void R1050_00_TRATA_FUNDAO_DB_INSERT_1()
        {
            /*" -2922- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1 = new R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1()
            {
                V0APCR_NUM_APOL = V0APCR_NUM_APOL.ToString(),
                V0APCR_RAMOFR = V0APCR_RAMOFR.ToString(),
                V0APCR_MODALIFR = V0APCR_MODALIFR.ToString(),
                V0APCR_CODCORR = V0APCR_CODCORR.ToString(),
                V0APCR_CODSUBES = V0APCR_CODSUBES.ToString(),
                V0APCR_DTINIVIG = V0APCR_DTINIVIG.ToString(),
                V0APCR_DTTERVIG = V0APCR_DTTERVIG.ToString(),
                V0APCR_PCPARCOR = V0APCR_PCPARCOR.ToString(),
                V0APCR_PCCOMCOR = V0APCR_PCCOMCOR.ToString(),
                V0APCR_TIPCOM = V0APCR_TIPCOM.ToString(),
                V0APCR_INDCRT = V0APCR_INDCRT.ToString(),
                V0APCR_COD_EMPRESA = V0APCR_COD_EMPRESA.ToString(),
                V0APCR_COD_USUARIO = V0APCR_COD_USUARIO.ToString(),
            };

            R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1.Execute(r1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_4()
        {
            /*" -2575- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_4_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_4_Insert1()
            {
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_COD_COBER = V0COBA_COD_COBER.ToString(),
                V0COBA_IMP_SEG_IX = V0COBA_IMP_SEG_IX.ToString(),
                V0COBA_PRM_TAR_IX = V0COBA_PRM_TAR_IX.ToString(),
                V0COBA_IMP_SEG_VR = V0COBA_IMP_SEG_VR.ToString(),
                V0COBA_PRM_TAR_VR = V0COBA_PRM_TAR_VR.ToString(),
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_FATOR_MULT = V0COBA_FATOR_MULT.ToString(),
                V0COBA_DATA_INIVI = V0COBA_DATA_INIVI.ToString(),
                V0COBA_DATA_TERVI = V0COBA_DATA_TERVI.ToString(),
                V0COBA_COD_EMPRESA = V0COBA_COD_EMPRESA.ToString(),
                V0COBA_SITUACAO = V0COBA_SITUACAO.ToString(),
                VIND_SITUACAO = VIND_SITUACAO.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_4_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_4_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2()
        {
            /*" -2641- EXEC SQL UPDATE SEGUROS.V0NUMERO_OUTROS SET NUMOPG = :V1NOUT-NUMOPG WHERE NUMOPG > 0 END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1()
            {
                V1NOUT_NUMOPG = V1NOUT_NUMOPG.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-6 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_6()
        {
            /*" -1934- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :V1BILC-RAMOFR AND DATA_INIVIGENCIA <= :V0BILH-DTQITBCO AND DATA_TERVIGENCIA >= :V0BILH-DTQITBCO WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1()
            {
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }

        [StopWatch]
        /*" R1050-20-TRATA-FENAE */
        private void R1050_20_TRATA_FENAE(bool isPerform = false)
        {
            /*" -2947- PERFORM R1050_20_TRATA_FENAE_DB_SELECT_1 */

            R1050_20_TRATA_FENAE_DB_SELECT_1();

            /*" -2950- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2951- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2952- MOVE 3,32 TO PARAMPRO-VALOR-COMISSAO-PRD */
                    _.Move(3.32, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);

                    /*" -2953- ELSE */
                }
                else
                {


                    /*" -2954- DISPLAY 'R1050-00 (ERRO 2 - SELECT PARAM_PRODUTO)...' */
                    _.Display($"R1050-00 (ERRO 2 - SELECT PARAM_PRODUTO)...");

                    /*" -2956- DISPLAY 'BILHETE : ' V0BILH-NUMBIL '  ' 'PRODUTO : ' V0ENDO-CODPRODU */

                    $"BILHETE : {V0BILH_NUMBIL}  PRODUTO : {V0ENDO_CODPRODU}"
                    .Display();

                    /*" -2958- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2959- MOVE 17256 TO V0APCR-CODCORR */
            _.Move(17256, V0APCR_CODCORR);

            /*" -2961- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -2964- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -2967- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -2972- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -3002- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -3003- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -3004- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -3005- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -3006- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -3007- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -3008- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -3009- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -3010- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -3012- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -3014- MOVE 'VA6005B' TO V0APCR-COD-USUARIO. */
            _.Move("VA6005B", V0APCR_COD_USUARIO);

            /*" -3016- MOVE '105B' TO WNR-EXEC-SQL. */
            _.Move("105B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3032- PERFORM R1050_20_TRATA_FENAE_DB_INSERT_1 */

            R1050_20_TRATA_FENAE_DB_INSERT_1();

            /*" -3035- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3036- DISPLAY 'R1077-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1077-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -3039- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -3041- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3041- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

        }

        [StopWatch]
        /*" R1050-20-TRATA-FENAE-DB-SELECT-1 */
        public void R1050_20_TRATA_FENAE_DB_SELECT_1()
        {
            /*" -2947- EXEC SQL SELECT VALOR_COMISSAO_PRD INTO :PARAMPRO-VALOR-COMISSAO-PRD FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :V0ENDO-CODPRODU AND TIPO_FUNCIONARIO = '8' AND :V1SIST-DTMOVABE BETWEEN DATA_INIVIGENCIA AND DATA_TERVIGENCIA END-EXEC. */

            var r1050_20_TRATA_FENAE_DB_SELECT_1_Query1 = new R1050_20_TRATA_FENAE_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R1050_20_TRATA_FENAE_DB_SELECT_1_Query1.Execute(r1050_20_TRATA_FENAE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
            }


        }

        [StopWatch]
        /*" R1050-20-TRATA-FENAE-DB-INSERT-1 */
        public void R1050_20_TRATA_FENAE_DB_INSERT_1()
        {
            /*" -3032- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1050_20_TRATA_FENAE_DB_INSERT_1_Insert1 = new R1050_20_TRATA_FENAE_DB_INSERT_1_Insert1()
            {
                V0APCR_NUM_APOL = V0APCR_NUM_APOL.ToString(),
                V0APCR_RAMOFR = V0APCR_RAMOFR.ToString(),
                V0APCR_MODALIFR = V0APCR_MODALIFR.ToString(),
                V0APCR_CODCORR = V0APCR_CODCORR.ToString(),
                V0APCR_CODSUBES = V0APCR_CODSUBES.ToString(),
                V0APCR_DTINIVIG = V0APCR_DTINIVIG.ToString(),
                V0APCR_DTTERVIG = V0APCR_DTTERVIG.ToString(),
                V0APCR_PCPARCOR = V0APCR_PCPARCOR.ToString(),
                V0APCR_PCCOMCOR = V0APCR_PCCOMCOR.ToString(),
                V0APCR_TIPCOM = V0APCR_TIPCOM.ToString(),
                V0APCR_INDCRT = V0APCR_INDCRT.ToString(),
                V0APCR_COD_EMPRESA = V0APCR_COD_EMPRESA.ToString(),
                V0APCR_COD_USUARIO = V0APCR_COD_USUARIO.ToString(),
            };

            R1050_20_TRATA_FENAE_DB_INSERT_1_Insert1.Execute(r1050_20_TRATA_FENAE_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-7 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_7()
        {
            /*" -1972- EXEC SQL SELECT COD_PRODUTO INTO :V0PROE-CODPRODU FROM SEGUROS.V0PROP_ESTIPULANTE WHERE NUMBIL = :V0BILH-NUMBIL AND FONTE = 0 AND NUM_PROPOSTA = 0 AND COD_FROTA = '0' END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROE_CODPRODU, V0PROE_CODPRODU);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_5()
        {
            /*" -2676- EXEC SQL INSERT INTO SEGUROS.V0ADIANTA VALUES (:V0ADIA-CODPDT , :V0ADIA-FONTE , :V0ADIA-NUMOPG , :V0ADIA-VALADT , :V0ADIA-QTPRESTA , :V0ADIA-NRPROPOS , :V0ADIA-NUM-APOL , :V0ADIA-NRENDOS , :V0ADIA-NRPARCEL , :V0ADIA-DTMOVTO , :V0ADIA-SITUACAO , :V0ADIA-COD-EMP , CURRENT TIMESTAMP , :V0ADIA-TIPO-ADT) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_5_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_5_Insert1()
            {
                V0ADIA_CODPDT = V0ADIA_CODPDT.ToString(),
                V0ADIA_FONTE = V0ADIA_FONTE.ToString(),
                V0ADIA_NUMOPG = V0ADIA_NUMOPG.ToString(),
                V0ADIA_VALADT = V0ADIA_VALADT.ToString(),
                V0ADIA_QTPRESTA = V0ADIA_QTPRESTA.ToString(),
                V0ADIA_NRPROPOS = V0ADIA_NRPROPOS.ToString(),
                V0ADIA_NUM_APOL = V0ADIA_NUM_APOL.ToString(),
                V0ADIA_NRENDOS = V0ADIA_NRENDOS.ToString(),
                V0ADIA_NRPARCEL = V0ADIA_NRPARCEL.ToString(),
                V0ADIA_DTMOVTO = V0ADIA_DTMOVTO.ToString(),
                V0ADIA_SITUACAO = V0ADIA_SITUACAO.ToString(),
                V0ADIA_COD_EMP = V0ADIA_COD_EMP.ToString(),
                V0ADIA_TIPO_ADT = V0ADIA_TIPO_ADT.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_5_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_5_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-6 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_6()
        {
            /*" -2729- EXEC SQL INSERT INTO SEGUROS.V0FORMAREC VALUES (:V0FORM-CODPDT , :V0FORM-FONTE , :V0FORM-NUMOPG , :V0FORM-NRPROPOS , :V0FORM-NUM-APOL , :V0FORM-NRENDOS , :V0FORM-NRPARCEL , :V0FORM-NUMPTC , :V0FORM-VALRCP , :V0FORM-PCGACM , :V0FORM-SITUACAO , :V0FORM-VALSDO , :V0FORM-DTMOVTO , :V0FORM-DTVENCTO , :V0FORM-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1()
            {
                V0FORM_CODPDT = V0FORM_CODPDT.ToString(),
                V0FORM_FONTE = V0FORM_FONTE.ToString(),
                V0FORM_NUMOPG = V0FORM_NUMOPG.ToString(),
                V0FORM_NRPROPOS = V0FORM_NRPROPOS.ToString(),
                V0FORM_NUM_APOL = V0FORM_NUM_APOL.ToString(),
                V0FORM_NRENDOS = V0FORM_NRENDOS.ToString(),
                V0FORM_NRPARCEL = V0FORM_NRPARCEL.ToString(),
                V0FORM_NUMPTC = V0FORM_NUMPTC.ToString(),
                V0FORM_VALRCP = V0FORM_VALRCP.ToString(),
                V0FORM_PCGACM = V0FORM_PCGACM.ToString(),
                V0FORM_SITUACAO = V0FORM_SITUACAO.ToString(),
                V0FORM_VALSDO = V0FORM_VALSDO.ToString(),
                V0FORM_DTMOVTO = V0FORM_DTMOVTO.ToString(),
                V0FORM_DTVENCTO = V0FORM_DTVENCTO.ToString(),
                V0FORM_COD_EMP = V0FORM_COD_EMP.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_6_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-8 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_8()
        {
            /*" -2610- EXEC SQL SELECT NUMOPG INTO :WHOST-NUMOPG FROM SEGUROS.V0ADIANTA WHERE CODPDT = 17256 AND NUM_APOLICE = :WHOST-NUMBIL AND NUMOPG > 0 END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1()
            {
                WHOST_NUMBIL = WHOST_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NUMOPG, WHOST_NUMOPG);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-7 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_7()
        {
            /*" -2777- EXEC SQL INSERT INTO SEGUROS.V0HISTOREC VALUES (:V0HISR-CODPDT , :V0HISR-FONTE , :V0HISR-NUMOPG , :V0HISR-NRPROPOS , :V0HISR-NUM-APOL , :V0HISR-NRENDOS , :V0HISR-NRPARCEL , :V0HISR-NUMPTC , :V0HISR-VALRCP , :V0HISR-NUMREC , :V0HISR-DTMOVTO , :V0HISR-OPERACAO , CURRENT TIME, :V0HISR-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_7_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_7_Insert1()
            {
                V0HISR_CODPDT = V0HISR_CODPDT.ToString(),
                V0HISR_FONTE = V0HISR_FONTE.ToString(),
                V0HISR_NUMOPG = V0HISR_NUMOPG.ToString(),
                V0HISR_NRPROPOS = V0HISR_NRPROPOS.ToString(),
                V0HISR_NUM_APOL = V0HISR_NUM_APOL.ToString(),
                V0HISR_NRENDOS = V0HISR_NRENDOS.ToString(),
                V0HISR_NRPARCEL = V0HISR_NRPARCEL.ToString(),
                V0HISR_NUMPTC = V0HISR_NUMPTC.ToString(),
                V0HISR_VALRCP = V0HISR_VALRCP.ToString(),
                V0HISR_NUMREC = V0HISR_NUMREC.ToString(),
                V0HISR_DTMOVTO = V0HISR_DTMOVTO.ToString(),
                V0HISR_OPERACAO = V0HISR_OPERACAO.ToString(),
                V0HISR_COD_EMP = V0HISR_COD_EMP.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_7_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_7_Insert1);

        }

        [StopWatch]
        /*" R1060-00-TRATA-FENAE-SECTION */
        private void R1060_00_TRATA_FENAE_SECTION()
        {
            /*" -3059- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3060- MOVE 17256 TO V0APCR-CODCORR */
            _.Move(17256, V0APCR_CODCORR);

            /*" -3062- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -3065- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -3068- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -3072- COMPUTE AUX-PERCENT EQUAL (2,02 / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (2.02 / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -3072- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-9 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_9()
        {
            /*" -2626- EXEC SQL SELECT NUMOPG INTO :V1NOUT-NUMOPG FROM SEGUROS.V0NUMERO_OUTROS END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1()
            {
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NOUT_NUMOPG, V1NOUT_NUMOPG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1066-00-TRATA-EVOGEPES016-SECTION */
        private void R1066_00_TRATA_EVOGEPES016_SECTION()
        {
            /*" -3084- MOVE '1066' TO WNR-EXEC-SQL. */
            _.Move("1066", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3090- MOVE 'S' TO WWORK-FUNDAO. */
            _.Move("S", AREA_DE_WORK.WWORK_FUNDAO);

            /*" -3100- PERFORM R1066_00_TRATA_EVOGEPES016_DB_SELECT_1 */

            R1066_00_TRATA_EVOGEPES016_DB_SELECT_1();

            /*" -3104- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3105- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3108- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC */
                    _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);

                    /*" -3109- ELSE */
                }
                else
                {


                    /*" -3110- DISPLAY 'R1066-00 - PROBLEMAS SELECT PARAMPRO TIPO 1' */
                    _.Display($"R1066-00 - PROBLEMAS SELECT PARAMPRO TIPO 1");

                    /*" -3113- DISPLAY 'BILHETE : ' V0BILH-NUMBIL '  ' 'PRODUTO : ' V0ENDO-CODPRODU 'INICIO  : ' V0ENDO-DTINIVIG */

                    $"BILHETE : {V0BILH_NUMBIL}  PRODUTO : {V0ENDO_CODPRODU}INICIO  : {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -3116- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3117- IF CANAL-ATM */

            if (AREA_DE_WORK.FILLER_8.W_CANAL_PROPOSTA["CANAL_ATM"])
            {

                /*" -3122- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC. */
                _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);
            }


            /*" -3124- IF PARAMPRO-VALOR-COMISSAO-PRD EQUAL ZEROS AND PARAMPRO-PERCEN-COMIS-FUNC EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD == 00 && PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC == 00)
            {

                /*" -3125- MOVE 17256 TO V0APCR-CODCORR */
                _.Move(17256, V0APCR_CODCORR);

                /*" -3126- MOVE 100 TO V0APCR-PCPARCOR */
                _.Move(100, V0APCR_PCPARCOR);

                /*" -3127- PERFORM R1067-00-TRATA-CORRETOR */

                R1067_00_TRATA_CORRETOR_SECTION();

                /*" -3130- GO TO R1066-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1066_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3131- MOVE 19224 TO V0APCR-CODCORR. */
            _.Move(19224, V0APCR_CODCORR);

            /*" -3133- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -3136- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -3137- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00)
            {

                /*" -3139- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-PERCEN-COMIS-FUNC * 2) */
                AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC * 2);

                /*" -3140- ELSE */
            }
            else
            {


                /*" -3143- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100 */
                AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

                /*" -3147- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100. */
                AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;
            }


            /*" -3149- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -3150- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -3151- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -3152- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -3153- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -3154- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -3155- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -3156- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -3157- MOVE '2' TO V0APCR-INDCRT */
            _.Move("2", V0APCR_INDCRT);

            /*" -3159- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -3161- MOVE 'VA6005B' TO V0APCR-COD-USUARIO. */
            _.Move("VA6005B", V0APCR_COD_USUARIO);

            /*" -3164- PERFORM R1068-00-INSERT-APOLCORRET. */

            R1068_00_INSERT_APOLCORRET_SECTION();

            /*" -3165- MOVE 17256 TO V0APCR-CODCORR */
            _.Move(17256, V0APCR_CODCORR);

            /*" -3166- MOVE 50 TO V0APCR-PCPARCOR */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -3168- PERFORM R1067-00-TRATA-CORRETOR. */

            R1067_00_TRATA_CORRETOR_SECTION();

        }

        [StopWatch]
        /*" R1066-00-TRATA-EVOGEPES016-DB-SELECT-1 */
        public void R1066_00_TRATA_EVOGEPES016_DB_SELECT_1()
        {
            /*" -3100- EXEC SQL SELECT VALOR_COMISSAO_PRD , PERCEN_COMIS_FUNC INTO :PARAMPRO-VALOR-COMISSAO-PRD , :PARAMPRO-PERCEN-COMIS-FUNC FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :V0ENDO-CODPRODU AND TIPO_FUNCIONARIO = '1' AND DATA_INIVIGENCIA <= :V0ENDO-DTINIVIG AND DATA_TERVIGENCIA >= :V0ENDO-DTINIVIG END-EXEC. */

            var r1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1 = new R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1.Execute(r1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
                _.Move(executed_1.PARAMPRO_PERCEN_COMIS_FUNC, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1066_99_SAIDA*/

        [StopWatch]
        /*" R1067-00-TRATA-CORRETOR-SECTION */
        private void R1067_00_TRATA_CORRETOR_SECTION()
        {
            /*" -3182- MOVE '1067' TO WNR-EXEC-SQL. */
            _.Move("1067", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3192- PERFORM R1067_00_TRATA_CORRETOR_DB_SELECT_1 */

            R1067_00_TRATA_CORRETOR_DB_SELECT_1();

            /*" -3196- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3197- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3200- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC */
                    _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);

                    /*" -3201- ELSE */
                }
                else
                {


                    /*" -3202- DISPLAY 'R1067-00 - PROBLEMAS SELECT PARAMPRO TIPO 8' */
                    _.Display($"R1067-00 - PROBLEMAS SELECT PARAMPRO TIPO 8");

                    /*" -3205- DISPLAY 'BILHETE : ' V0BILH-NUMBIL '  ' 'PRODUTO : ' V0ENDO-CODPRODU 'INICIO  : ' V0ENDO-DTINIVIG */

                    $"BILHETE : {V0BILH_NUMBIL}  PRODUTO : {V0ENDO_CODPRODU}INICIO  : {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -3208- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3211- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -3213- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS AND V0APCR-PCPARCOR EQUAL 100 */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00 && V0APCR_PCPARCOR == 100)
            {

                /*" -3215- MOVE PARAMPRO-PERCEN-COMIS-FUNC TO AUX-PERCENT */
                _.Move(PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC, AREA_DE_WORK.AUX_PERCENT);

                /*" -3216- ELSE */
            }
            else
            {


                /*" -3217- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS */

                if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00)
                {

                    /*" -3219- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-PERCEN-COMIS-FUNC * 2) */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC * 2);

                    /*" -3220- ELSE */
                }
                else
                {


                    /*" -3223- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100 */
                    AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

                    /*" -3227- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100. */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;
                }

            }


            /*" -3229- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -3230- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -3231- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -3232- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -3233- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -3234- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -3235- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -3236- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -3237- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -3239- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -3241- MOVE 'VA6005B' TO V0APCR-COD-USUARIO. */
            _.Move("VA6005B", V0APCR_COD_USUARIO);

            /*" -3243- PERFORM R1068-00-INSERT-APOLCORRET. */

            R1068_00_INSERT_APOLCORRET_SECTION();

        }

        [StopWatch]
        /*" R1067-00-TRATA-CORRETOR-DB-SELECT-1 */
        public void R1067_00_TRATA_CORRETOR_DB_SELECT_1()
        {
            /*" -3192- EXEC SQL SELECT VALOR_COMISSAO_PRD , PERCEN_COMIS_FUNC INTO :PARAMPRO-VALOR-COMISSAO-PRD , :PARAMPRO-PERCEN-COMIS-FUNC FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :V0ENDO-CODPRODU AND TIPO_FUNCIONARIO = '8' AND DATA_INIVIGENCIA <= :V0ENDO-DTINIVIG AND DATA_TERVIGENCIA >= :V0ENDO-DTINIVIG END-EXEC. */

            var r1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1 = new R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1.Execute(r1067_00_TRATA_CORRETOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
                _.Move(executed_1.PARAMPRO_PERCEN_COMIS_FUNC, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1066_99_SAIDA*/

        [StopWatch]
        /*" R1068-00-INSERT-APOLCORRET-SECTION */
        private void R1068_00_INSERT_APOLCORRET_SECTION()
        {
            /*" -3253- MOVE '1068' TO WNR-EXEC-SQL. */
            _.Move("1068", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3254- MOVE V0APCR-CODCORR TO WS-COD-CORRETOR */
            _.Move(V0APCR_CODCORR, WS_COD_CORRETOR);

            /*" -3258- IF WS-IND-CORRETOR = 1 AND N88-COD-CORRETOR AND V0APCR-TIPCOM = '1' */

            if (WS_IND_CORRETOR == 1 && WS_COD_CORRETOR["N88_COD_CORRETOR"] && V0APCR_TIPCOM == "1")
            {

                /*" -3259- IF WS-COD-CORRETOR = 19224 */

                if (WS_COD_CORRETOR == 19224)
                {

                    /*" -3260- GO TO R1068-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1068_99_SAIDA*/ //GOTO
                    return;

                    /*" -3261- END-IF */
                }


                /*" -3262- MOVE 25267 TO V0APCR-CODCORR */
                _.Move(25267, V0APCR_CODCORR);

                /*" -3264- END-IF */
            }


            /*" -3280- PERFORM R1068_00_INSERT_APOLCORRET_DB_INSERT_1 */

            R1068_00_INSERT_APOLCORRET_DB_INSERT_1();

            /*" -3283- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3284- DISPLAY 'R1068-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1068-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -3287- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO:    ' V0APCR-RAMOFR '  ' 'OPCAO:   ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO:    {V0APCR_RAMOFR}  OPCAO:   {WWORK_OPCAO_ANT}"
                .Display();

                /*" -3289- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3292- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

        }

        [StopWatch]
        /*" R1068-00-INSERT-APOLCORRET-DB-INSERT-1 */
        public void R1068_00_INSERT_APOLCORRET_DB_INSERT_1()
        {
            /*" -3280- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1 = new R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1()
            {
                V0APCR_NUM_APOL = V0APCR_NUM_APOL.ToString(),
                V0APCR_RAMOFR = V0APCR_RAMOFR.ToString(),
                V0APCR_MODALIFR = V0APCR_MODALIFR.ToString(),
                V0APCR_CODCORR = V0APCR_CODCORR.ToString(),
                V0APCR_CODSUBES = V0APCR_CODSUBES.ToString(),
                V0APCR_DTINIVIG = V0APCR_DTINIVIG.ToString(),
                V0APCR_DTTERVIG = V0APCR_DTTERVIG.ToString(),
                V0APCR_PCPARCOR = V0APCR_PCPARCOR.ToString(),
                V0APCR_PCCOMCOR = V0APCR_PCCOMCOR.ToString(),
                V0APCR_TIPCOM = V0APCR_TIPCOM.ToString(),
                V0APCR_INDCRT = V0APCR_INDCRT.ToString(),
                V0APCR_COD_EMPRESA = V0APCR_COD_EMPRESA.ToString(),
                V0APCR_COD_USUARIO = V0APCR_COD_USUARIO.ToString(),
            };

            R1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1.Execute(r1068_00_INSERT_APOLCORRET_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1068_99_SAIDA*/

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-SECTION */
        private void R1080_00_GRAVA_V0APOLCOSCED_SECTION()
        {
            /*" -3302- MOVE '1080' TO WNR-EXEC-SQL. */
            _.Move("1080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3320- PERFORM R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1 */

            R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1();

            /*" -3322- PERFORM R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1 */

            R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1();

            /*" -3325- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3326- DISPLAY 'R1080-00 (ERRO OPEN CURSOR V1COSSEGPROD)...' */
                _.Display($"R1080-00 (ERRO OPEN CURSOR V1COSSEGPROD)...");

                /*" -3330- DISPLAY 'PRODUTO: ' V1BILP-CODPRODU '  ' 'RAMO: ' WWORK-RAMO-ANT ' ' 'OPCA: ' WWORK-OPCAO-ANT ' ' 'INIVIG: ' V0ENDO-DTINIVIG */

                $"PRODUTO: {V1BILP_CODPRODU}  RAMO: {WWORK_RAMO_ANT} OPCA: {WWORK_OPCAO_ANT} INIVIG: {V0ENDO_DTINIVIG}"
                .Display();

                /*" -3332- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3333- MOVE 0 TO WACC-PCTCED WACC-QTCOSSEG. */
            _.Move(0, AREA_DE_WORK.WACC_PCTCED, AREA_DE_WORK.WACC_QTCOSSEG);

            /*" -0- FLUXCONTROL_PERFORM R1080_10_FETCH_V1COSSEGPROD */

            R1080_10_FETCH_V1COSSEGPROD();

        }

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-DB-OPEN-1 */
        public void R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1()
        {
            /*" -3322- EXEC SQL OPEN V1COSSEGPROD END-EXEC. */

            V1COSSEGPROD.Open();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -4688- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */
            V1RCAPCOMP = new VA6005B_V1RCAPCOMP(true);
            string GetQuery_V1RCAPCOMP()
            {
                var query = @$"SELECT FONTE
							, 
							NRRCAP
							, 
							NRRCAPCO
							, 
							OPERACAO
							, 
							DTMOVTO
							, 
							HORAOPER
							, 
							SITUACAO
							, 
							BCOAVISO
							, 
							AGEAVISO
							, 
							NRAVISO
							, 
							VLRCAP
							, 
							DATARCAP
							, 
							DTCADAST
							, 
							SITCONTB 
							FROM SEGUROS.V1RCAPCOMP 
							WHERE FONTE = '{V0RCAP_FONTE}' 
							AND NRRCAP = '{V0RCAP_NRRCAP}'";

                return query;
            }
            V1RCAPCOMP.GetQueryEvent += GetQuery_V1RCAPCOMP;

        }

        [StopWatch]
        /*" R1080-10-FETCH-V1COSSEGPROD */
        private void R1080_10_FETCH_V1COSSEGPROD(bool isPerform = false)
        {
            /*" -3339- MOVE '1081' TO WNR-EXEC-SQL. */
            _.Move("1081", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3349- PERFORM R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1 */

            R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1();

            /*" -3352- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3368- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3368- PERFORM R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1 */

                    R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1();

                    /*" -3370- GO TO R1080-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/ //GOTO
                    return;

                    /*" -3371- ELSE */
                }
                else
                {


                    /*" -3372- DISPLAY 'R1080-10 (ERRO - FETCH V1COSSEGPROD)...' */
                    _.Display($"R1080-10 (ERRO - FETCH V1COSSEGPROD)...");

                    /*" -3376- DISPLAY 'PRODUTO: ' V1BILP-CODPRODU '  ' 'RAMO: ' WWORK-RAMO-ANT ' ' 'OPCA: ' WWORK-OPCAO-ANT ' ' 'INIVIG: ' V0ENDO-DTINIVIG */

                    $"PRODUTO: {V1BILP_CODPRODU}  RAMO: {WWORK_RAMO_ANT} OPCA: {WWORK_OPCAO_ANT} INIVIG: {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -3378- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3379- MOVE V1COSP-CONGENER TO V0APCC-CODCOSS */
            _.Move(V1COSP_CONGENER, V0APCC_CODCOSS);

            /*" -3380- MOVE V0APOL-NUM-APOL TO V0APCC-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCC_NUM_APOL);

            /*" -3381- MOVE WWORK-RAMO-ANT TO V0APCC-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCC_RAMOFR);

            /*" -3382- MOVE V0ENDO-DTINIVIG TO V0APCC-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCC_DTINIVIG);

            /*" -3383- MOVE V0ENDO-DTTERVIG TO V0APCC-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCC_DTTERVIG);

            /*" -3384- MOVE V1COSP-PCPARTIC TO V0APCC-PCPARTIC */
            _.Move(V1COSP_PCPARTIC, V0APCC_PCPARTIC);

            /*" -3385- MOVE V1COSP-PCCOMCOS TO V0APCC-PCCOMCOS */
            _.Move(V1COSP_PCCOMCOS, V0APCC_PCCOMCOS);

            /*" -3387- MOVE ZEROS TO V0APCC-COD-EMPRESA */
            _.Move(0, V0APCC_COD_EMPRESA);

            /*" -3388- ADD V1COSP-PCPARTIC TO WACC-PCTCED */
            AREA_DE_WORK.WACC_PCTCED.Value = AREA_DE_WORK.WACC_PCTCED + V1COSP_PCPARTIC;

            /*" -3390- ADD 1 TO WACC-QTCOSSEG. */
            AREA_DE_WORK.WACC_QTCOSSEG.Value = AREA_DE_WORK.WACC_QTCOSSEG + 1;

            /*" -3392- PERFORM R1082-00-INSERT-V0APOLCOSCED. */

            R1082_00_INSERT_V0APOLCOSCED_SECTION();

            /*" -3392- GO TO R1080-10-FETCH-V1COSSEGPROD. */
            new Task(() => R1080_10_FETCH_V1COSSEGPROD()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1080-10-FETCH-V1COSSEGPROD-DB-FETCH-1 */
        public void R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1()
        {
            /*" -3349- EXEC SQL FETCH V1COSSEGPROD INTO :V1COSP-CODPRODU , :V1COSP-RAMO , :V1COSP-CONGENER , :V1COSP-PCPARTIC , :V1COSP-PCCOMCOS , :V1COSP-PCADMCOS , :V1COSP-DTINIVIG , :V1COSP-DTTERVIG , :V1COSP-SITUACAO END-EXEC. */

            if (V1COSSEGPROD.Fetch())
            {
                _.Move(V1COSSEGPROD.V1COSP_CODPRODU, V1COSP_CODPRODU);
                _.Move(V1COSSEGPROD.V1COSP_RAMO, V1COSP_RAMO);
                _.Move(V1COSSEGPROD.V1COSP_CONGENER, V1COSP_CONGENER);
                _.Move(V1COSSEGPROD.V1COSP_PCPARTIC, V1COSP_PCPARTIC);
                _.Move(V1COSSEGPROD.V1COSP_PCCOMCOS, V1COSP_PCCOMCOS);
                _.Move(V1COSSEGPROD.V1COSP_PCADMCOS, V1COSP_PCADMCOS);
                _.Move(V1COSSEGPROD.V1COSP_DTINIVIG, V1COSP_DTINIVIG);
                _.Move(V1COSSEGPROD.V1COSP_DTTERVIG, V1COSP_DTTERVIG);
                _.Move(V1COSSEGPROD.V1COSP_SITUACAO, V1COSP_SITUACAO);
            }

        }

        [StopWatch]
        /*" R1080-10-FETCH-V1COSSEGPROD-DB-CLOSE-1 */
        public void R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1()
        {
            /*" -3368- EXEC SQL CLOSE V1COSSEGPROD END-EXEC */

            V1COSSEGPROD.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/

        [StopWatch]
        /*" R1082-00-INSERT-V0APOLCOSCED-SECTION */
        private void R1082_00_INSERT_V0APOLCOSCED_SECTION()
        {
            /*" -3403- MOVE '1082' TO WNR-EXEC-SQL. */
            _.Move("1082", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3414- PERFORM R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1 */

            R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1();

            /*" -3417- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3418- DISPLAY 'R1082-00 (ERRO INSERT V0APOLCOSCED)...' */
                _.Display($"R1082-00 (ERRO INSERT V0APOLCOSCED)...");

                /*" -3421- DISPLAY 'APOLICE: ' V0APCC-NUM-APOL '  ' 'CODCOSS: ' V0APCC-CODCOSS '  ' 'RAMO: ' V0APCC-RAMOFR */

                $"APOLICE: {V0APCC_NUM_APOL}  CODCOSS: {V0APCC_CODCOSS}  RAMO: {V0APCC_RAMOFR}"
                .Display();

                /*" -3423- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3425- ADD +1 TO AC-I-V0APOLCOSCED. */
            AREA_DE_WORK.AC_I_V0APOLCOSCED.Value = AREA_DE_WORK.AC_I_V0APOLCOSCED + +1;

            /*" -3425- PERFORM R1083-00-INSERT-V0ORDECOSCED. */

            R1083_00_INSERT_V0ORDECOSCED_SECTION();

        }

        [StopWatch]
        /*" R1082-00-INSERT-V0APOLCOSCED-DB-INSERT-1 */
        public void R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1()
        {
            /*" -3414- EXEC SQL INSERT INTO SEGUROS.V0APOLCOSCED VALUES (:V0APCC-NUM-APOL , :V0APCC-CODCOSS , :V0APCC-RAMOFR , :V0APCC-DTINIVIG , :V0APCC-DTTERVIG , :V0APCC-PCPARTIC , :V0APCC-PCCOMCOS , :V0APCC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 = new R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1()
            {
                V0APCC_NUM_APOL = V0APCC_NUM_APOL.ToString(),
                V0APCC_CODCOSS = V0APCC_CODCOSS.ToString(),
                V0APCC_RAMOFR = V0APCC_RAMOFR.ToString(),
                V0APCC_DTINIVIG = V0APCC_DTINIVIG.ToString(),
                V0APCC_DTTERVIG = V0APCC_DTTERVIG.ToString(),
                V0APCC_PCPARTIC = V0APCC_PCPARTIC.ToString(),
                V0APCC_PCCOMCOS = V0APCC_PCCOMCOS.ToString(),
                V0APCC_COD_EMPRESA = V0APCC_COD_EMPRESA.ToString(),
            };

            R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1.Execute(r1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1082_99_SAIDA*/

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-SECTION */
        private void R1083_00_INSERT_V0ORDECOSCED_SECTION()
        {
            /*" -3436- MOVE '1083' TO WNR-EXEC-SQL. */
            _.Move("1083", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3437- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -3438- MOVE V0APCC-NUM-APOL TO V0ORDC-NUM-APOL */
            _.Move(V0APCC_NUM_APOL, V0ORDC_NUM_APOL);

            /*" -3439- MOVE 0 TO V0ORDC-NRENDOS */
            _.Move(0, V0ORDC_NRENDOS);

            /*" -3442- MOVE V0APCC-CODCOSS TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V0APCC_CODCOSS, V0ORDC_CODCOSS);
            _.Move(V0APCC_CODCOSS, AREA_DE_WORK.FILLER_4.WWORK_ORD_CONGE);


            /*" -3444- MOVE WH-JV1-COD-ORGAO TO WWORK-ORD-ORGAO. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, AREA_DE_WORK.FILLER_4.WWORK_ORD_ORGAO);

            /*" -3446- MOVE V0APCC-CODCOSS TO V1NCOS-CONGENER */
            _.Move(V0APCC_CODCOSS, V1NCOS_CONGENER);

            /*" -3448- MOVE WH-JV1-COD-ORGAO TO V1NCOS-ORGAO. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, V1NCOS_ORGAO);

            /*" -3454- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1();

            /*" -3457- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3458- DISPLAY 'R1083-00 (ERRO - SELECT V1NUMERO_COSSEGURO)...' */
                _.Display($"R1083-00 (ERRO - SELECT V1NUMERO_COSSEGURO)...");

                /*" -3461- DISPLAY 'ORGAO: ' V1NCOS-ORGAO '  ' 'CONGENER: ' V1NCOS-CONGENER '  ' 'BILHETE : ' V0BILH-NUMBIL */

                $"ORGAO: {V1NCOS_ORGAO}  CONGENER: {V1NCOS_CONGENER}  BILHETE : {V0BILH_NUMBIL}"
                .Display();

                /*" -3463- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3465- MOVE '1084' TO WNR-EXEC-SQL. */
            _.Move("1084", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3467- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -3469- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_4.WWORK_ORD_SEQUE);

            /*" -3471- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -3479- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1();

            /*" -3482- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3483- DISPLAY 'R1084-00 (ERRO - INSERT V0ORDECOSCED)...' */
                _.Display($"R1084-00 (ERRO - INSERT V0ORDECOSCED)...");

                /*" -3487- DISPLAY 'APOLICE: ' V0ORDC-NUM-APOL '  ' 'ENDOSSO: ' V0ORDC-NRENDOS '  ' 'CODCOSS: ' V0ORDC-CODCOSS '  ' 'NRORDEM: ' V0ORDC-ORDEM-CED */

                $"APOLICE: {V0ORDC_NUM_APOL}  ENDOSSO: {V0ORDC_NRENDOS}  CODCOSS: {V0ORDC_CODCOSS}  NRORDEM: {V0ORDC_ORDEM_CED}"
                .Display();

                /*" -3488- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -3490- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3492- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -3494- MOVE '1085' TO WNR-EXEC-SQL. */
            _.Move("1085", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3496- MOVE V0APCC-CODCOSS TO V1NCOS-CONGENER */
            _.Move(V0APCC_CODCOSS, V1NCOS_CONGENER);

            /*" -3498- MOVE WH-JV1-COD-ORGAO TO V1NCOS-ORGAO. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, V1NCOS_ORGAO);

            /*" -3504- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1();

            /*" -3507- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3508- DISPLAY 'R1085-00 (ERRO - UPDATE V0NUMERO_COSSEGURO)...' */
                _.Display($"R1085-00 (ERRO - UPDATE V0NUMERO_COSSEGURO)...");

                /*" -3511- DISPLAY 'ORGAO: ' V1NCOS-ORGAO '  ' 'CONGENER: ' V1NCOS-CONGENER '  ' 'BILHETE : ' V0BILH-NUMBIL */

                $"ORGAO: {V1NCOS_ORGAO}  CONGENER: {V1NCOS_CONGENER}  BILHETE : {V0BILH_NUMBIL}"
                .Display();

                /*" -3513- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3513- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

        }

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-DB-SELECT-1 */
        public void R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1()
        {
            /*" -3454- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1 = new R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1()
            {
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            var executed_1 = R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1.Execute(r1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NCOS_NRORDEM, V1NCOS_NRORDEM);
            }


        }

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-DB-INSERT-1 */
        public void R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1()
        {
            /*" -3479- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1 = new R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1()
            {
                V0ORDC_NUM_APOL = V0ORDC_NUM_APOL.ToString(),
                V0ORDC_NRENDOS = V0ORDC_NRENDOS.ToString(),
                V0ORDC_CODCOSS = V0ORDC_CODCOSS.ToString(),
                V0ORDC_ORDEM_CED = V0ORDC_ORDEM_CED.ToString(),
                V0ORDC_COD_EMPRESA = V0ORDC_COD_EMPRESA.ToString(),
            };

            R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1.Execute(r1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-DB-UPDATE-1 */
        public void R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1()
        {
            /*" -3504- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1 = new R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1()
            {
                V1NCOS_NRORDEM = V1NCOS_NRORDEM.ToString(),
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1.Execute(r1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1083_99_SAIDA*/

        [StopWatch]
        /*" R1090-00-UPDATE-V0APOLICE-SECTION */
        private void R1090_00_UPDATE_V0APOLICE_SECTION()
        {
            /*" -3524- MOVE '1090' TO WNR-EXEC-SQL. */
            _.Move("1090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3525- MOVE WACC-QTCOSSEG TO V0APOL-QTCOSSEG */
            _.Move(AREA_DE_WORK.WACC_QTCOSSEG, V0APOL_QTCOSSEG);

            /*" -3527- MOVE WACC-PCTCED TO V0APOL-PCTCED. */
            _.Move(AREA_DE_WORK.WACC_PCTCED, V0APOL_PCTCED);

            /*" -3532- PERFORM R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1 */

            R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1();

            /*" -3535- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3536- DISPLAY 'R1090-00 (ERRO - UPDATE V0APOLICE)...' */
                _.Display($"R1090-00 (ERRO - UPDATE V0APOLICE)...");

                /*" -3537- DISPLAY 'APOLICE: ' V0APOL-NUM-APOL */
                _.Display($"APOLICE: {V0APOL_NUM_APOL}");

                /*" -3539- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3539- ADD +1 TO AC-U-V0APOLICE. */
            AREA_DE_WORK.AC_U_V0APOLICE.Value = AREA_DE_WORK.AC_U_V0APOLICE + +1;

        }

        [StopWatch]
        /*" R1090-00-UPDATE-V0APOLICE-DB-UPDATE-1 */
        public void R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1()
        {
            /*" -3532- EXEC SQL UPDATE SEGUROS.V0APOLICE SET QTCOSSEG = :V0APOL-QTCOSSEG , PCTCED = :V0APOL-PCTCED WHERE NUM_APOLICE = :V0APOL-NUM-APOL END-EXEC. */

            var r1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 = new R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1()
            {
                V0APOL_QTCOSSEG = V0APOL_QTCOSSEG.ToString(),
                V0APOL_PCTCED = V0APOL_PCTCED.ToString(),
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
            };

            R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1.Execute(r1090_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1090_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-GRAVA-V0HISTOPARC-SECTION */
        private void R2010_00_GRAVA_V0HISTOPARC_SECTION()
        {
            /*" -3550- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3551- MOVE V0APOL-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3553- MOVE 0 TO V0HISP-NRENDOS */
            _.Move(0, V0HISP_NRENDOS);

            /*" -3554- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3555- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3556- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -3558- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3559- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3560- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3561- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3562- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3564- MOVE '.' TO WS000-P1 WS000-P2. */
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P1);
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P2);


            /*" -3566- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3568- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -3569- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3570- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3571- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3572- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3573- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3574- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3575- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3576- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -3577- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -3578- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3579- MOVE V0ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V0ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -3580- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3581- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3582- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3583- MOVE 'VA6005B' TO V0HISP-COD-USUAR */
            _.Move("VA6005B", V0HISP_COD_USUAR);

            /*" -3585- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3587- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3589- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3589- PERFORM R2030-00-INSERT-V0HISTOPARC. */

            R2030_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2020-00-GRAVA-OPERACAO-BAIXA-SECTION */
        private void R2020_00_GRAVA_OPERACAO_BAIXA_SECTION()
        {
            /*" -3600- MOVE '2020' TO WNR-EXEC-SQL. */
            _.Move("2020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3601- MOVE V0APOL-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3602- MOVE 0 TO V0HISP-NRENDOS */
            _.Move(0, V0HISP_NRENDOS);

            /*" -3604- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3605- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3606- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3608- MOVE 0201 TO V0HISP-OPERACAO */
            _.Move(0201, V0HISP_OPERACAO);

            /*" -3609- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3610- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3611- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3612- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3614- MOVE '.' TO WS000-P1 WS000-P2. */
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P1);
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P2);


            /*" -3616- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3618- MOVE 2 TO V0HISP-OCORHIST */
            _.Move(2, V0HISP_OCORHIST);

            /*" -3619- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3620- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3621- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3622- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3623- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3624- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3628- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3629- MOVE V0HISP-VLPRMTOT TO V0HISP-VLPREMIO */
            _.Move(V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

            /*" -3630- MOVE V2RCAP-VLRCAP TO V0HISP-VLPREMIO */
            _.Move(V2RCAP_VLRCAP, V0HISP_VLPREMIO);

            /*" -3634- MOVE V0ENDO-DATARCAP TO V0HISP-DTVENCTO */
            _.Move(V0ENDO_DATARCAP, V0HISP_DTVENCTO);

            /*" -3635- MOVE ZEROS TO V0HISP-BCOCOBR */
            _.Move(0, V0HISP_BCOCOBR);

            /*" -3636- MOVE ZEROS TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -3637- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3638- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3639- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3640- MOVE 'VA6005B' TO V0HISP-COD-USUAR */
            _.Move("VA6005B", V0HISP_COD_USUAR);

            /*" -3642- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3643- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -3645- MOVE V0BILH-DTQITBCO TO V0HISP-DTQITBCO. */
            _.Move(V0BILH_DTQITBCO, V0HISP_DTQITBCO);

            /*" -3647- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3647- PERFORM R2030-00-INSERT-V0HISTOPARC. */

            R2030_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_99_SAIDA*/

        [StopWatch]
        /*" R2030-00-INSERT-V0HISTOPARC-SECTION */
        private void R2030_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -3658- MOVE '2030' TO WNR-EXEC-SQL. */
            _.Move("2030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3687- PERFORM R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -3690- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3691- DISPLAY 'R2030-00 (ERRO - INSERT V0HISTOPARC)...' */
                _.Display($"R2030-00 (ERRO - INSERT V0HISTOPARC)...");

                /*" -3696- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -3698- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3698- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R2030-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -3687- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_DACPARC = V0HISP_DACPARC.ToString(),
                V0HISP_DTMOVTO = V0HISP_DTMOVTO.ToString(),
                V0HISP_OPERACAO = V0HISP_OPERACAO.ToString(),
                V0HISP_HORAOPER = V0HISP_HORAOPER.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_PRM_TARIFA = V0HISP_PRM_TARIFA.ToString(),
                V0HISP_VAL_DESCON = V0HISP_VAL_DESCON.ToString(),
                V0HISP_VLPRMLIQ = V0HISP_VLPRMLIQ.ToString(),
                V0HISP_VLADIFRA = V0HISP_VLADIFRA.ToString(),
                V0HISP_VLCUSEMI = V0HISP_VLCUSEMI.ToString(),
                V0HISP_VLIOCC = V0HISP_VLIOCC.ToString(),
                V0HISP_VLPRMTOT = V0HISP_VLPRMTOT.ToString(),
                V0HISP_VLPREMIO = V0HISP_VLPREMIO.ToString(),
                V0HISP_DTVENCTO = V0HISP_DTVENCTO.ToString(),
                V0HISP_BCOCOBR = V0HISP_BCOCOBR.ToString(),
                V0HISP_AGECOBR = V0HISP_AGECOBR.ToString(),
                V0HISP_NRAVISO = V0HISP_NRAVISO.ToString(),
                V0HISP_NRENDOCA = V0HISP_NRENDOCA.ToString(),
                V0HISP_SITCONTB = V0HISP_SITCONTB.ToString(),
                V0HISP_COD_USUAR = V0HISP_COD_USUAR.ToString(),
                V0HISP_RNUDOC = V0HISP_RNUDOC.ToString(),
                V0HISP_DTQITBCO = V0HISP_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0HISP_COD_EMPRESA = V0HISP_COD_EMPRESA.ToString(),
            };

            R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_99_SAIDA*/

        [StopWatch]
        /*" R2990-00-VERIFICA-PROFISSAO-SECTION */
        private void R2990_00_VERIFICA_PROFISSAO_SECTION()
        {
            /*" -3709- MOVE '2990' TO WNR-EXEC-SQL. */
            _.Move("2990", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3714- PERFORM R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1 */

            R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1();

            /*" -3717- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3719- GO TO R2990-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2990_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3721- MOVE '299A' TO WNR-EXEC-SQL. */
            _.Move("299A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3726- PERFORM R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2 */

            R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2();

            /*" -3729- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3734- IF PESSOA-FISICA-COD-CBO EQUAL 296 OR 297 OR 298 OR 996 NEXT SENTENCE */

                if (PESSOA_FISICA_COD_CBO.In("296", "297", "298", "996"))
                {

                    /*" -3735- ELSE */
                }
                else
                {


                    /*" -3737- MOVE TAB-DESCR-CBO-C(PESSOA-FISICA-COD-CBO) TO CBO-DESCR-CBO */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_2[PESSOA_FISICA_COD_CBO].TAB_DESCR_CBO_C, CBO_DESCR_CBO);

                    /*" -3753- IF CBO-DESCR-CBO (1:5) EQUAL 'POLIC' OR 'MILIT' OR 'VIGIA' OR 'VIGIL' OR 'SEGUR' OR 'PILOT' OR 'INSTR' OR 'PARAQ' OR 'MOTOB' OR 'MOTOC' OR 'MOTOQ' OR 'MERGU' OR 'ALPIN' OR 'AGENT' OR 'PERIT' OR 'SERVE' */

                    if (CBO_DESCR_CBO.Substring(1, 5).In("POLIC", "MILIT", "VIGIA", "VIGIL", "SEGUR", "PILOT", "INSTR", "PARAQ", "MOTOB", "MOTOC", "MOTOQ", "MERGU", "ALPIN", "AGENT", "PERIT", "SERVE"))
                    {

                        /*" -3754- MOVE 1803 TO V0BILER-COD-ERRO */
                        _.Move(1803, V0BILER_COD_ERRO);

                        /*" -3754- PERFORM R3045-00-INSERE-ERRO. */

                        R3045_00_INSERE_ERRO_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R2990-00-VERIFICA-PROFISSAO-DB-SELECT-1 */
        public void R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1()
        {
            /*" -3714- EXEC SQL SELECT COD_PESSOA INTO :PRPFIDEL-COD-PESSOA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :V0BILH-NUMBIL END-EXEC. */

            var r2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1 = new R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1.Execute(r2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRPFIDEL_COD_PESSOA, PRPFIDEL_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2990_99_SAIDA*/

        [StopWatch]
        /*" R2990-00-VERIFICA-PROFISSAO-DB-SELECT-2 */
        public void R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2()
        {
            /*" -3726- EXEC SQL SELECT COD_CBO INTO :PESSOA-FISICA-COD-CBO FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :PRPFIDEL-COD-PESSOA END-EXEC. */

            var r2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1 = new R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1()
            {
                PRPFIDEL_COD_PESSOA = PRPFIDEL_COD_PESSOA.ToString(),
            };

            var executed_1 = R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1.Execute(r2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_FISICA_COD_CBO, PESSOA_FISICA_COD_CBO);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-SECTION */
        private void R3000_00_ACUMULA_BILHETE_SECTION()
        {
            /*" -3765- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3768- MOVE '.' TO WS000-P1 WS000-P2. */
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P1);
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P2);


            /*" -3770- MOVE SPACES TO WFIM-V1RCAP */
            _.Move("", AREA_DE_WORK.WFIM_V1RCAP);

            /*" -3773- MOVE V0BILH-NUMBIL TO WWORK-NUMBIL V0APOL-NUMBIL. */
            _.Move(V0BILH_NUMBIL, AREA_DE_WORK.WWORK_NUMBIL, V0APOL_NUMBIL);

            /*" -3777- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3780- MOVE V0BILH-NUMBIL TO V0RCAP-NRTIT. */
            _.Move(V0BILH_NUMBIL, V0RCAP_NRTIT);

            /*" -3799- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_1 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_1();

            /*" -3803- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3804- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3805- MOVE 'S' TO WFIM-V1RCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                    /*" -3806- ELSE */
                }
                else
                {


                    /*" -3807- DISPLAY 'R3000-00 (ERRO - SELECT V0RCAP)...' */
                    _.Display($"R3000-00 (ERRO - SELECT V0RCAP)...");

                    /*" -3810- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP */

                    $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}"
                    .Display();

                    /*" -3811- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3813- ELSE */
                }

            }
            else
            {


                /*" -3814- IF V0RCAP-SITUACAO NOT EQUAL '0' */

                if (V0RCAP_SITUACAO != "0")
                {

                    /*" -3815- MOVE 'S' TO WFIM-V1RCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                    /*" -3816- ELSE */
                }
                else
                {


                    /*" -3818- IF V0RCAP-OPERACAO GREATER 199 AND V0RCAP-OPERACAO LESS 300 */

                    if (V0RCAP_OPERACAO > 199 && V0RCAP_OPERACAO < 300)
                    {

                        /*" -3819- MOVE 'S' TO WFIM-V1RCAP */
                        _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                        /*" -3820- ELSE */
                    }
                    else
                    {


                        /*" -3822- IF V0RCAP-OPERACAO GREATER 399 AND V0RCAP-OPERACAO LESS 500 */

                        if (V0RCAP_OPERACAO > 399 && V0RCAP_OPERACAO < 500)
                        {

                            /*" -3826- MOVE 'S' TO WFIM-V1RCAP. */
                            _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);
                        }

                    }

                }

            }


            /*" -3828- IF WFIM-V1RCAP EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1RCAP == "S")
            {

                /*" -3829- IF V0BILH-SITUACAO EQUAL '2' OR '0' */

                if (V0BILH_SITUACAO.In("2", "0"))
                {

                    /*" -3830- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -3832- ELSE */
                }
                else
                {


                    /*" -3833- MOVE '0' TO V0BILH-SITUACAO */
                    _.Move("0", V0BILH_SITUACAO);

                    /*" -3834- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -3836- GO TO R3000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3837- MOVE V0RCAP-NRRCAP TO WWORK-NRRCAP */
            _.Move(V0RCAP_NRRCAP, AREA_DE_WORK.FILLER_5.WWORK_NRRCAP);

            /*" -3839- MOVE V0RCAP-NRRCAP TO WHOST-NRRCAP. */
            _.Move(V0RCAP_NRRCAP, WHOST_NRRCAP);

            /*" -3842- MOVE '3025' TO WNR-EXEC-SQL. */
            _.Move("3025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3857- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_2 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_2();

            /*" -3861- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3862- DISPLAY 'R3025-00 (ERRO - SELECT V1RCAPCOMP)... ' */
                _.Display($"R3025-00 (ERRO - SELECT V1RCAPCOMP)... ");

                /*" -3865- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -3879- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3880- IF WS-SIVPF EQUAL 'S' */

            if (AREA_DE_WORK.WS_SIVPF == "S")
            {

                /*" -3882- GO TO R3000-10-CONTINUA. */

                R3000_10_CONTINUA(); //GOTO
                return;
            }


            /*" -3882- MOVE '3030' TO WNR-EXEC-SQL. */
            _.Move("3030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3000_10_CONTINUA */

            R3000_10_CONTINUA();

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-1 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_1()
        {
            /*" -3799- EXEC SQL SELECT FONTE, NRRCAP, VLRCAP, SITUACAO, OPERACAO INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP, :V2RCAP-VLRCAP, :V0RCAP-SITUACAO, :V0RCAP-OPERACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
                _.Move(executed_1.V2RCAP_VLRCAP, V2RCAP_VLRCAP);
                _.Move(executed_1.V0RCAP_SITUACAO, V0RCAP_SITUACAO);
                _.Move(executed_1.V0RCAP_OPERACAO, V0RCAP_OPERACAO);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA */
        private void R3000_10_CONTINUA(bool isPerform = false)
        {
            /*" -3917- COMPUTE WS-VALORDIF EQUAL V0BILH-VLRCAP - V2RCAP-VLRCAP. */
            AREA_DE_WORK.WS_VALORDIF.Value = V0BILH_VLRCAP - V2RCAP_VLRCAP;

            /*" -3918- IF WS-VALORDIF LESS ZEROS */

            if (AREA_DE_WORK.WS_VALORDIF < 00)
            {

                /*" -3921- COMPUTE WS-VALORDIF EQUAL WS-VALORDIF * -1. */
                AREA_DE_WORK.WS_VALORDIF.Value = AREA_DE_WORK.WS_VALORDIF * -1;
            }


            /*" -3924- COMPUTE WS-VALORMAIS EQUAL V2RCAP-VLRCAP - V0BILH-VLRCAP. */
            AREA_DE_WORK.WS_VALORMAIS.Value = V2RCAP_VLRCAP - V0BILH_VLRCAP;

            /*" -3925- IF WS-VALORMAIS LESS ZEROS */

            if (AREA_DE_WORK.WS_VALORMAIS < 00)
            {

                /*" -3928- MOVE 10 TO WS-VALORMAIS. */
                _.Move(10, AREA_DE_WORK.WS_VALORMAIS);
            }


            /*" -3929- IF WS-VALORDIF GREATER WS-VLDIFE */

            if (AREA_DE_WORK.WS_VALORDIF > AREA_DE_WORK.WS_VLDIFE)
            {

                /*" -3930- IF WS-VALORMAIS GREATER WS-VLMAIOR */

                if (AREA_DE_WORK.WS_VALORMAIS > AREA_DE_WORK.WS_VLMAIOR)
                {

                    /*" -3931- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -3932- PERFORM R3040-00-MONTA-V0BILHETE */

                    R3040_00_MONTA_V0BILHETE_SECTION();

                    /*" -3933- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -3935- GO TO R3000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3937- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3938- MOVE SPACES TO WFIM-V1COMIFENAE. */
            _.Move("", AREA_DE_WORK.WFIM_V1COMIFENAE);

            /*" -3941- MOVE V0BILH-NUMBIL TO V1COFE-NUMBIL. */
            _.Move(V0BILH_NUMBIL, V1COFE_NUMBIL);

            /*" -3948- PERFORM R3000_10_CONTINUA_DB_SELECT_1 */

            R3000_10_CONTINUA_DB_SELECT_1();

            /*" -3951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3952- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3953- DISPLAY 'R3050-00 (SELECT V1COMISSAO_FENAE)...' */
                    _.Display($"R3050-00 (SELECT V1COMISSAO_FENAE)...");

                    /*" -3954- DISPLAY 'BILHETE: ' V0BILH-NUMBIL ' NAO ENCONTRADO...' */

                    $"BILHETE: {V0BILH_NUMBIL} NAO ENCONTRADO..."
                    .Display();

                    /*" -3955- DISPLAY 'BILHETE NAO SERA TRATADO PELO PROGR. VA6005B' */
                    _.Display($"BILHETE NAO SERA TRATADO PELO PROGR. VA6005B");

                    /*" -3956- MOVE 'S' TO WFIM-V1COMIFENAE */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COMIFENAE);

                    /*" -3957- ELSE */
                }
                else
                {


                    /*" -3958- DISPLAY 'R3050-00 (ERRO - SELECT V1COMISSAO_FENAE)...' */
                    _.Display($"R3050-00 (ERRO - SELECT V1COMISSAO_FENAE)...");

                    /*" -3959- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -3966- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3969- MOVE '3055' TO WNR-EXEC-SQL. */
            _.Move("3055", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3974- PERFORM R3000_10_CONTINUA_DB_SELECT_2 */

            R3000_10_CONTINUA_DB_SELECT_2();

            /*" -3978- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3979- MOVE '4' TO V0BILH-SITUACAO */
                _.Move("4", V0BILH_SITUACAO);

                /*" -3980- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -3981- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -3982- ELSE */
            }
            else
            {


                /*" -3983- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3984- DISPLAY 'R3055-00 (ERRO - SELECT V1AGENCIACEF)...' */
                    _.Display($"R3055-00 (ERRO - SELECT V1AGENCIACEF)...");

                    /*" -3985- DISPLAY 'BILHETE    : ' V0BILH-NUMBIL */
                    _.Display($"BILHETE    : {V0BILH_NUMBIL}");

                    /*" -3986- DISPLAY 'COD.AGENCIA: ' V1COFE-AGECOBR */
                    _.Display($"COD.AGENCIA: {V1COFE_AGECOBR}");

                    /*" -3988- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3991- MOVE '3060' TO WNR-EXEC-SQL. */
            _.Move("3060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3996- PERFORM R3000_10_CONTINUA_DB_SELECT_3 */

            R3000_10_CONTINUA_DB_SELECT_3();

            /*" -4000- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4001- MOVE '4' TO V0BILH-SITUACAO */
                _.Move("4", V0BILH_SITUACAO);

                /*" -4002- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -4003- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -4004- ELSE */
            }
            else
            {


                /*" -4005- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4006- DISPLAY 'R3060-00 (ERRO SELECT V1MALHACEF)...' */
                    _.Display($"R3060-00 (ERRO SELECT V1MALHACEF)...");

                    /*" -4007- DISPLAY 'ESCNEG : ' V1ACEF-CODESCNEG */
                    _.Display($"ESCNEG : {V1ACEF_CODESCNEG}");

                    /*" -4008- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -4010- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4011- IF V1COFE-AGECOBR NOT EQUAL V0BILH-AGECOBR */

            if (V1COFE_AGECOBR != V0BILH_AGECOBR)
            {

                /*" -4012- MOVE V1COFE-AGECOBR TO V0BILH-AGECOBR */
                _.Move(V1COFE_AGECOBR, V0BILH_AGECOBR);

                /*" -4014- PERFORM R3095-00-UPDATE-V0BILHETE. */

                R3095_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -4016- ADD V0BILFX-VALADT TO V0ADIA-VALADT. */
            V0ADIA_VALADT.Value = V0ADIA_VALADT + V0BILFX_VALADT;

            /*" -4017- IF V1MCEF-COD-FONTE NOT EQUAL V0BILH-FONTE */

            if (V1MCEF_COD_FONTE != V0BILH_FONTE)
            {

                /*" -4018- MOVE V1MCEF-COD-FONTE TO V0BILH-FONTE */
                _.Move(V1MCEF_COD_FONTE, V0BILH_FONTE);

                /*" -4023- PERFORM R3090-00-UPDATE-V0BILHETE. */

                R3090_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -4024- MOVE V1ACEF-CODESCNEG TO V1COBI-COD-ESCNEG */
            _.Move(V1ACEF_CODESCNEG, V1COBI_COD_ESCNEG);

            /*" -4025- MOVE V0BILH-RAMO TO V1COBI-RAMO */
            _.Move(V0BILH_RAMO, V1COBI_RAMO);

            /*" -4027- MOVE V1COFE-DTQITBCO TO V1COBI-DTINIVIG. */
            _.Move(V1COFE_DTQITBCO, V1COBI_DTINIVIG);

            /*" -4029- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4041- PERFORM R3000_10_CONTINUA_DB_SELECT_4 */

            R3000_10_CONTINUA_DB_SELECT_4();

            /*" -4045- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4046- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4047- MOVE 'S' TO WFIM-V1COMERC-BIL */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COMERC_BIL);

                    /*" -4048- ELSE */
                }
                else
                {


                    /*" -4049- DISPLAY 'R3100-00 (ERRO - SELECT V0COMERC_BILHETE.. ' */
                    _.Display($"R3100-00 (ERRO - SELECT V0COMERC_BILHETE.. ");

                    /*" -4052- DISPLAY 'ESCNEG   : ' V1COBI-COD-ESCNEG ' ' 'RAMO     : ' V1COBI-RAMO '  ' 'DTINIVIG ; ' V1COBI-DTINIVIG */

                    $"ESCNEG   : {V1COBI_COD_ESCNEG} RAMO     : {V1COBI_RAMO} DTINIVIG;{V1COBI_DTINIVIG}"
                    .Display();

                    /*" -4054- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4055- IF WFIM-V1COMERC-BIL NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1COMERC_BIL != "S")
            {

                /*" -4057- IF V0BILH-OPCAO-COBER EQUAL 1 AND V1COBI-COBERTURA1 EQUAL 'B' */

                if (V0BILH_OPCAO_COBER == 1 && V1COBI_COBERTURA1 == "B")
                {

                    /*" -4058- PERFORM R3110-00-INSERT-V0BIL-CC00396 */

                    R3110_00_INSERT_V0BIL_CC00396_SECTION();

                    /*" -4059- ELSE */
                }
                else
                {


                    /*" -4061- IF V0BILH-OPCAO-COBER EQUAL 2 AND V1COBI-COBERTURA2 EQUAL 'B' */

                    if (V0BILH_OPCAO_COBER == 2 && V1COBI_COBERTURA2 == "B")
                    {

                        /*" -4062- PERFORM R3110-00-INSERT-V0BIL-CC00396 */

                        R3110_00_INSERT_V0BIL_CC00396_SECTION();

                        /*" -4063- ELSE */
                    }
                    else
                    {


                        /*" -4065- IF V0BILH-OPCAO-COBER EQUAL 3 AND V1COBI-COBERTURA3 EQUAL 'B' */

                        if (V0BILH_OPCAO_COBER == 3 && V1COBI_COBERTURA3 == "B")
                        {

                            /*" -4067- PERFORM R3110-00-INSERT-V0BIL-CC00396. */

                            R3110_00_INSERT_V0BIL_CC00396_SECTION();
                        }

                    }

                }

            }


            /*" -4069- MOVE '3120' TO WNR-EXEC-SQL. */
            _.Move("3120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4072- MOVE SPACES TO WFIM-V1FUNCIOCEF. */
            _.Move("", AREA_DE_WORK.WFIM_V1FUNCIOCEF);

            /*" -4091- PERFORM R3000_10_CONTINUA_DB_SELECT_5 */

            R3000_10_CONTINUA_DB_SELECT_5();

            /*" -4095- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4096- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4097- MOVE 0701 TO V0BILER-COD-ERRO */
                    _.Move(0701, V0BILER_COD_ERRO);

                    /*" -4098- PERFORM R3045-00-INSERE-ERRO */

                    R3045_00_INSERE_ERRO_SECTION();

                    /*" -4099- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -4100- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4101- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4102- ELSE */
                }
                else
                {


                    /*" -4103- DISPLAY 'R3120-00 (ERRO - SELECT V1FUNCIOCEF)...' */
                    _.Display($"R3120-00 (ERRO - SELECT V1FUNCIOCEF)...");

                    /*" -4104- DISPLAY 'MATRICULA: ' V0BILH-NUM-MATR */
                    _.Display($"MATRICULA: {V0BILH_NUM_MATR}");

                    /*" -4105- DISPLAY 'BILHETE  : ' V0BILH-NUMBIL */
                    _.Display($"BILHETE  : {V0BILH_NUMBIL}");

                    /*" -4107- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4108- IF VIND-COD-ANGAR LESS ZEROS */

            if (VIND_COD_ANGAR < 00)
            {

                /*" -4110- MOVE ZEROS TO V1FUNC-COD-ANGAR. */
                _.Move(0, V1FUNC_COD_ANGAR);
            }


            /*" -4111- IF V1FUNC-COD-ANGAR NOT EQUAL ZEROS */

            if (V1FUNC_COD_ANGAR != 00)
            {

                /*" -4113- GO TO R3000-90-CONTINUA. */

                R3000_90_CONTINUA(); //GOTO
                return;
            }


            /*" -4116- MOVE '3130' TO WNR-EXEC-SQL. */
            _.Move("3130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4120- PERFORM R3000_10_CONTINUA_DB_SELECT_6 */

            R3000_10_CONTINUA_DB_SELECT_6();

            /*" -4124- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4125- DISPLAY 'R3130-00 (ERRO - SELECT V1NUMERO_OUTROS)...' */
                _.Display($"R3130-00 (ERRO - SELECT V1NUMERO_OUTROS)...");

                /*" -4126- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4128- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4129- MOVE V1NOUT-CODANGAR TO WS-NUM-ANGAR */
            _.Move(V1NOUT_CODANGAR, AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR);

            /*" -4130- ADD 1 TO WS-NUM-ANGAR */
            AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR.Value = AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR + 1;

            /*" -4131- MOVE WS-NUM-ANGAR TO PROM11W099-NUMERO */
            _.Move(AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR, AREA_DE_WORK.PROM11W099.PROM11W099_NUMERO);

            /*" -4133- MOVE 6 TO PROM11W099-TAM */
            _.Move(6, AREA_DE_WORK.PROM11W099.PROM11W099_TAM);

            /*" -4134- CALL 'PROM1101' USING PROM11W099 */
            _.Call("PROM1101", AREA_DE_WORK.PROM11W099);

            /*" -4135- MOVE PROM11W099-DAC TO WS-DAC-ANGAR */
            _.Move(AREA_DE_WORK.PROM11W099.PROM11W099_DAC, AREA_DE_WORK.WS_CODANGAR_R.WS_DAC_ANGAR);

            /*" -4137- MOVE WS-CODANGAR TO V1FUNC-COD-ANGAR */
            _.Move(AREA_DE_WORK.WS_CODANGAR, V1FUNC_COD_ANGAR);

            /*" -4140- MOVE '3140' TO WNR-EXEC-SQL. */
            _.Move("3140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4147- PERFORM R3000_10_CONTINUA_DB_SELECT_7 */

            R3000_10_CONTINUA_DB_SELECT_7();

            /*" -4151- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4152- DISPLAY 'R3140-00 (ERRO - SELECT V1AGENCIACEF)...' */
                _.Display($"R3140-00 (ERRO - SELECT V1AGENCIACEF)...");

                /*" -4153- DISPLAY 'COD.AGENCIA: ' V1COFE-AGECOBR */
                _.Display($"COD.AGENCIA: {V1COFE_AGECOBR}");

                /*" -4154- DISPLAY 'BILHETE    : ' V0BILH-NUMBIL */
                _.Display($"BILHETE    : {V0BILH_NUMBIL}");

                /*" -4156- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4159- MOVE '3150' TO WNR-EXEC-SQL. */
            _.Move("3150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4164- PERFORM R3000_10_CONTINUA_DB_UPDATE_1 */

            R3000_10_CONTINUA_DB_UPDATE_1();

            /*" -4168- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4169- DISPLAY 'R3150-00 (ERRO - UPDATE V0FUNCIOCEF)...' */
                _.Display($"R3150-00 (ERRO - UPDATE V0FUNCIOCEF)...");

                /*" -4172- DISPLAY 'MATRICULA: ' V1FUNC-NUM-MATRIC '  ' 'CPF: ' V1FUNC-NUM-CPF '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"MATRICULA: {V1FUNC_NUM_MATRIC}  CPF: {V1FUNC_NUM_CPF}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -4174- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4176- ADD +1 TO AC-U-V0FUNCIOCEF. */
            AREA_DE_WORK.AC_U_V0FUNCIOCEF.Value = AREA_DE_WORK.AC_U_V0FUNCIOCEF + +1;

            /*" -4177- MOVE V1FUNC-ENDERECO TO V1PROD-ENDERECO */
            _.Move(V1FUNC_ENDERECO, V1PROD_ENDERECO);

            /*" -4179- MOVE V1FUNC-CIDADE TO V1PROD-CIDADE */
            _.Move(V1FUNC_CIDADE, V1PROD_CIDADE);

            /*" -4180- MOVE V1SIST-DTMOVACB TO WDATA-SISTEMA */
            _.Move(V1SIST_DTMOVACB, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -4181- MOVE WDATA-SIS-ANO TO WS-AA-NUMREC */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO, AREA_DE_WORK.WS_NUMREC_R.WS_AA_NUMREC);

            /*" -4182- MOVE ZEROS TO WS-NN-NUMREC */
            _.Move(0, AREA_DE_WORK.WS_NUMREC_R.WS_NN_NUMREC);

            /*" -4184- MOVE WS-NUMREC TO WHOST-NUMREC. */
            _.Move(AREA_DE_WORK.WS_NUMREC, WHOST_NUMREC);

            /*" -4187- MOVE '3160' TO WNR-EXEC-SQL. */
            _.Move("3160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4231- PERFORM R3000_10_CONTINUA_DB_INSERT_1 */

            R3000_10_CONTINUA_DB_INSERT_1();

            /*" -4235- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4236- DISPLAY 'R3160-00 (ERRO - INSERT V0PRODUTOR)...' */
                _.Display($"R3160-00 (ERRO - INSERT V0PRODUTOR)...");

                /*" -4239- DISPLAY 'FONTE: ' V1MCEF-COD-FONTE '  ' 'COD.: ' V1FUNC-COD-ANGAR '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V1MCEF_COD_FONTE}  COD.: {V1FUNC_COD_ANGAR}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -4241- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4243- ADD +1 TO AC-I-V0PRODUTOR */
            AREA_DE_WORK.AC_I_V0PRODUTOR.Value = AREA_DE_WORK.AC_I_V0PRODUTOR + +1;

            /*" -4246- MOVE '3170' TO WNR-EXEC-SQL. */
            _.Move("3170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4251- PERFORM R3000_10_CONTINUA_DB_UPDATE_2 */

            R3000_10_CONTINUA_DB_UPDATE_2();

            /*" -4255- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4256- DISPLAY 'R3170-00 (ERRO - UPDATE V0NUMERO_OUTROS)...' */
                _.Display($"R3170-00 (ERRO - UPDATE V0NUMERO_OUTROS)...");

                /*" -4257- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4259- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4259- ADD +1 TO AC-U-V0NUMEROUT. */
            AREA_DE_WORK.AC_U_V0NUMEROUT.Value = AREA_DE_WORK.AC_U_V0NUMEROUT + +1;

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-1 */
        public void R3000_10_CONTINUA_DB_SELECT_1()
        {
            /*" -3948- EXEC SQL SELECT AGECOBR, DTQITBCO INTO :V1COFE-AGECOBR, :V1COFE-DTQITBCO FROM SEGUROS.V1COMISSAO_FENAE WHERE NUMBIL = :V1COFE-NUMBIL END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_1_Query1 = new R3000_10_CONTINUA_DB_SELECT_1_Query1()
            {
                V1COFE_NUMBIL = V1COFE_NUMBIL.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_1_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COFE_AGECOBR, V1COFE_AGECOBR);
                _.Move(executed_1.V1COFE_DTQITBCO, V1COFE_DTQITBCO);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-2 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_2()
        {
            /*" -3857- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :WHOST-NRRCAP AND NRRCAPCO = 0 AND OPERACAO = :V0RCAP-OPERACAO AND SITUACAO = '0' END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1()
            {
                V0RCAP_OPERACAO = V0RCAP_OPERACAO.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
                WHOST_NRRCAP = WHOST_NRRCAP.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-2 */
        public void R3000_10_CONTINUA_DB_SELECT_2()
        {
            /*" -3974- EXEC SQL SELECT COD_ESCNEG INTO :V1ACEF-CODESCNEG FROM SEGUROS.V1AGENCIACEF WHERE COD_AGENCIA = :V1COFE-AGECOBR END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_2_Query1 = new R3000_10_CONTINUA_DB_SELECT_2_Query1()
            {
                V1COFE_AGECOBR = V1COFE_AGECOBR.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_2_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ACEF_CODESCNEG, V1ACEF_CODESCNEG);
            }


        }

        [StopWatch]
        /*" R3000-90-CONTINUA */
        private void R3000_90_CONTINUA(bool isPerform = false)
        {
            /*" -4295- MOVE '3172' TO WNR-EXEC-SQL. */
            _.Move("3172", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4300- PERFORM R3000_90_CONTINUA_DB_SELECT_1 */

            R3000_90_CONTINUA_DB_SELECT_1();

            /*" -4303- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4304- DISPLAY 'R3172-00 (ERRO - SELECT V1FONTE)...' */
                _.Display($"R3172-00 (ERRO - SELECT V1FONTE)...");

                /*" -4305- DISPLAY 'FONTE = ' V0BILH-FONTE */
                _.Display($"FONTE = {V0BILH_FONTE}");

                /*" -4307- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4310- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -4310- MOVE '3173' TO WNR-EXEC-SQL. */
            _.Move("3173", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

        }

        [StopWatch]
        /*" R3000-90-CONTINUA-DB-SELECT-1 */
        public void R3000_90_CONTINUA_DB_SELECT_1()
        {
            /*" -4300- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0BILH-FONTE END-EXEC. */

            var r3000_90_CONTINUA_DB_SELECT_1_Query1 = new R3000_90_CONTINUA_DB_SELECT_1_Query1()
            {
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            var executed_1 = R3000_90_CONTINUA_DB_SELECT_1_Query1.Execute(r3000_90_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-3 */
        public void R3000_10_CONTINUA_DB_SELECT_3()
        {
            /*" -3996- EXEC SQL SELECT COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.V1MALHACEF WHERE COD_SUREG = :V1ACEF-CODESCNEG END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_3_Query1 = new R3000_10_CONTINUA_DB_SELECT_3_Query1()
            {
                V1ACEF_CODESCNEG = V1ACEF_CODESCNEG.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_3_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO */
        private void R3000_91_LE_ENDOSSO(bool isPerform = false)
        {
            /*" -4319- PERFORM R3000_91_LE_ENDOSSO_DB_SELECT_1 */

            R3000_91_LE_ENDOSSO_DB_SELECT_1();

            /*" -4322- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4323- DISPLAY '(PROPOSTA DUPLICADO NA ENDOSSO)... ' */
                _.Display($"(PROPOSTA DUPLICADO NA ENDOSSO)... ");

                /*" -4324- DISPLAY ' FONTE    - ' V0BILH-FONTE */
                _.Display($" FONTE    - {V0BILH_FONTE}");

                /*" -4325- DISPLAY ' PROPOSTA - ' V1FONT-PROPAUTOM */
                _.Display($" PROPOSTA - {V1FONT_PROPAUTOM}");

                /*" -4327- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1 */
                V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

                /*" -4328- GO TO R3000-91-LE-ENDOSSO */
                new Task(() => R3000_91_LE_ENDOSSO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -4329- ELSE */
            }
            else
            {


                /*" -4331- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -4332- ELSE */
                }
                else
                {


                    /*" -4333- DISPLAY 'R3173-00 (ERRO - SELECT V1ENDOSSO)... ' */
                    _.Display($"R3173-00 (ERRO - SELECT V1ENDOSSO)... ");

                    /*" -4335- DISPLAY 'FONTE    = ' V0BILH-FONTE ' ' 'NRPROPOS = ' V1FONT-PROPAUTOM */

                    $"FONTE    = {V0BILH_FONTE} NRPROPOS = {V1FONT_PROPAUTOM}"
                    .Display();

                    /*" -4337- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4339- MOVE '3174' TO WNR-EXEC-SQL. */
            _.Move("3174", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4343- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_1 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_1();

            /*" -4346- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4347- DISPLAY 'R3173-00 (ERRO - UPDATE V0FONTE)...' */
                _.Display($"R3173-00 (ERRO - UPDATE V0FONTE)...");

                /*" -4348- DISPLAY 'FONTE    = ' V0BILH-FONTE ' ' */

                $"FONTE    = {V0BILH_FONTE} "
                .Display();

                /*" -4350- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4351- MOVE '9' TO V0BILH-SITUACAO. */
            _.Move("9", V0BILH_SITUACAO);

            /*" -4353- ADD 1 TO WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_NUM_ITENS.Value = AREA_DE_WORK.WWORK_NUM_ITENS + 1;

            /*" -4355- MOVE '3180' TO WNR-EXEC-SQL. */
            _.Move("3180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4361- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_2 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_2();

            /*" -4364- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4365- DISPLAY 'R3180-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3180-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4366- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -4368- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4373- ADD +1 TO WPROC-BILHETES WACC-PROCESSADOS. */
            AREA_DE_WORK.WPROC_BILHETES.Value = AREA_DE_WORK.WPROC_BILHETES + +1;
            AREA_DE_WORK.WACC_PROCESSADOS.Value = AREA_DE_WORK.WACC_PROCESSADOS + +1;

            /*" -4375- MOVE '3190' TO WNR-EXEC-SQL. */
            _.Move("3190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4376- MOVE V0BILH-NUMBIL TO V0COFE-NUMBIL. */
            _.Move(V0BILH_NUMBIL, V0COFE_NUMBIL);

            /*" -4377- MOVE V0BILH-AGECOBR TO V0COFE-AGECOBR */
            _.Move(V0BILH_AGECOBR, V0COFE_AGECOBR);

            /*" -4378- MOVE V0BILH-NUM-MATR TO V0COFE-NUM-MATR */
            _.Move(V0BILH_NUM_MATR, V0COFE_NUM_MATR);

            /*" -4379- MOVE V0BILH-AGENCIA-DEB TO V0COFE-AGENCIA-DEB */
            _.Move(V0BILH_AGENCIA_DEB, V0COFE_AGENCIA_DEB);

            /*" -4380- MOVE V0BILH-OPERACAO-DEB TO V0COFE-OPERACAO-DEB */
            _.Move(V0BILH_OPERACAO_DEB, V0COFE_OPERACAO_DEB);

            /*" -4381- MOVE V0BILH-NUMCTA-DEB TO V0COFE-NUMCTA-DEB */
            _.Move(V0BILH_NUMCTA_DEB, V0COFE_NUMCTA_DEB);

            /*" -4382- MOVE V0BILH-DIGCTA-DEB TO V0COFE-DIGCTA-DEB */
            _.Move(V0BILH_DIGCTA_DEB, V0COFE_DIGCTA_DEB);

            /*" -4383- MOVE SPACES TO V0COFE-NOME-SIND */
            _.Move("", V0COFE_NOME_SIND);

            /*" -4385- MOVE '9' TO V0COFE-SITUACAO. */
            _.Move("9", V0COFE_SITUACAO);

            /*" -4397- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_3 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_3();

            /*" -4400- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4401- DISPLAY 'R3190-00 (ERRO - UPDATE V0COMISSAO_FENAE)...' */
                _.Display($"R3190-00 (ERRO - UPDATE V0COMISSAO_FENAE)...");

                /*" -4402- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4404- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4406- ADD +1 TO AC-U-V0COMIFENAE. */
            AREA_DE_WORK.AC_U_V0COMIFENAE.Value = AREA_DE_WORK.AC_U_V0COMIFENAE + +1;

            /*" -4408- PERFORM R3200-00-BAIXA-RCAP. */

            R3200_00_BAIXA_RCAP_SECTION();

            /*" -4410- MOVE '3210' TO WNR-EXEC-SQL. */
            _.Move("3210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4420- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_4 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_4();

            /*" -4423- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4424- DISPLAY 'R3210-00 (ERRO - UPDATE V0RCAP)...' */
                _.Display($"R3210-00 (ERRO - UPDATE V0RCAP)...");

                /*" -4427- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0RCAP-FONTE '  ' 'NRRCAP: ' V0RCAP-NRRCAP */

                $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0RCAP_FONTE}  NRRCAP: {V0RCAP_NRRCAP}"
                .Display();

                /*" -4429- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4434- ADD 1 TO AC-U-V0RCAP. */
            AREA_DE_WORK.AC_U_V0RCAP.Value = AREA_DE_WORK.AC_U_V0RCAP + 1;

            /*" -4436- MOVE '3220' TO WNR-EXEC-SQL. */
            _.Move("3220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4443- PERFORM R3000_91_LE_ENDOSSO_DB_SELECT_2 */

            R3000_91_LE_ENDOSSO_DB_SELECT_2();

            /*" -4446- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4447- DISPLAY 'R3220-00 - ERRO SELECT V0CLIENTE ' */
                _.Display($"R3220-00 - ERRO SELECT V0CLIENTE ");

                /*" -4448- DISPLAY 'BILHETE ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN */

                $"BILHETE {V0BILH_NUMBIL} {V0BILH_CODCLIEN}"
                .Display();

                /*" -4450- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4452- MOVE '3230' TO WNR-EXEC-SQL. */
            _.Move("3230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4454- MOVE V0BILH-CGCCPF TO V1CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V1CROT_CGCCPF);

            /*" -4467- PERFORM R3000_91_LE_ENDOSSO_DB_SELECT_3 */

            R3000_91_LE_ENDOSSO_DB_SELECT_3();

            /*" -4470- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4471- DISPLAY 'PROBLEMAS DE LEITURA CREDITO ROTATIVO' */
                _.Display($"PROBLEMAS DE LEITURA CREDITO ROTATIVO");

                /*" -4472- DISPLAY 'CODIGO DE ERRO ... ' SQLCODE */
                _.Display($"CODIGO DE ERRO ... {DB.SQLCODE}");

                /*" -4473- DISPLAY 'NR. BILHETE    ... ' V0BILH-NUMBIL */
                _.Display($"NR. BILHETE    ... {V0BILH_NUMBIL}");

                /*" -4474- DISPLAY 'NR. CGCCPF     ... ' V0BILH-CGCCPF */
                _.Display($"NR. CGCCPF     ... {V0BILH_CGCCPF}");

                /*" -4475- DISPLAY 'NAO FOI INCLUIDO NA TAB. CLIENTE_CROT' */
                _.Display($"NAO FOI INCLUIDO NA TAB. CLIENTE_CROT");

                /*" -4477- DISPLAY 'BILHETE EMITIDO. PROCESSAMENTO CONTINUA' . */
                _.Display($"BILHETE EMITIDO. PROCESSAMENTO CONTINUA");
            }


            /*" -4479- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4482- IF V0BILH-RAMO EQUAL 81 OR 82 OR 37 */

                if (V0BILH_RAMO.In("81", "82", "37"))
                {

                    /*" -4483- PERFORM R3240-00-UPDATE-CROT-AP */

                    R3240_00_UPDATE_CROT_AP_SECTION();

                    /*" -4484- ELSE */
                }
                else
                {


                    /*" -4485- PERFORM R3250-00-UPDATE-CROT-RES */

                    R3250_00_UPDATE_CROT_RES_SECTION();

                    /*" -4487- ELSE */
                }

            }
            else
            {


                /*" -4490- IF V0BILH-RAMO EQUAL 81 OR 82 OR 37 */

                if (V0BILH_RAMO.In("81", "82", "37"))
                {

                    /*" -4491- MOVE 'S' TO V0CROT-BILH-AP */
                    _.Move("S", V0CROT_BILH_AP);

                    /*" -4492- MOVE 'N' TO V0CROT-BILH-RES */
                    _.Move("N", V0CROT_BILH_RES);

                    /*" -4493- ELSE */
                }
                else
                {


                    /*" -4494- MOVE 'N' TO V0CROT-BILH-AP */
                    _.Move("N", V0CROT_BILH_AP);

                    /*" -4495- MOVE 'S' TO V0CROT-BILH-RES */
                    _.Move("S", V0CROT_BILH_RES);

                    /*" -4496- END-IF */
                }


                /*" -4496- PERFORM R3260-00-INSERT-V0CLIEN-CROT. */

                R3260_00_INSERT_V0CLIEN_CROT_SECTION();
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-SELECT-1 */
        public void R3000_91_LE_ENDOSSO_DB_SELECT_1()
        {
            /*" -4319- EXEC SQL SELECT NRPROPOS INTO :V0ENDO-NRPROPOS FROM SEGUROS.V1ENDOSSO WHERE FONTE = :V0BILH-FONTE AND NRPROPOS = :V1FONT-PROPAUTOM END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_SELECT_1_Query1 = new R3000_91_LE_ENDOSSO_DB_SELECT_1_Query1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            var executed_1 = R3000_91_LE_ENDOSSO_DB_SELECT_1_Query1.Execute(r3000_91_LE_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRPROPOS, V0ENDO_NRPROPOS);
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-1 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_1()
        {
            /*" -4343- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0BILH-FONTE END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-4 */
        public void R3000_10_CONTINUA_DB_SELECT_4()
        {
            /*" -4041- EXEC SQL SELECT COBERTURA1 , COBERTURA2 , COBERTURA3 INTO :V1COBI-COBERTURA1 , :V1COBI-COBERTURA2 , :V1COBI-COBERTURA3 FROM SEGUROS.V1COMERC_BILHETE WHERE COD_ESCNEG = :V1COBI-COD-ESCNEG AND RAMO = :V1COBI-RAMO AND DTINIVIG <= :V1COBI-DTINIVIG AND DTTERVIG >= :V1COBI-DTINIVIG END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_4_Query1 = new R3000_10_CONTINUA_DB_SELECT_4_Query1()
            {
                V1COBI_COD_ESCNEG = V1COBI_COD_ESCNEG.ToString(),
                V1COBI_DTINIVIG = V1COBI_DTINIVIG.ToString(),
                V1COBI_RAMO = V1COBI_RAMO.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_4_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COBI_COBERTURA1, V1COBI_COBERTURA1);
                _.Move(executed_1.V1COBI_COBERTURA2, V1COBI_COBERTURA2);
                _.Move(executed_1.V1COBI_COBERTURA3, V1COBI_COBERTURA3);
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-2 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_2()
        {
            /*" -4361- EXEC SQL UPDATE SEGUROS.V0BILHETE SET NUM_APOLICE = :V0APOL-NUM-APOL, SITUACAO = :V0BILH-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1()
            {
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-UPDATE-1 */
        public void R3000_10_CONTINUA_DB_UPDATE_1()
        {
            /*" -4164- EXEC SQL UPDATE SEGUROS.V0FUNCIOCEF SET COD_ANGARIADOR = :V1FUNC-COD-ANGAR WHERE NUM_MATRICULA = :V1FUNC-NUM-MATRIC AND NUM_CPF = :V1FUNC-NUM-CPF END-EXEC. */

            var r3000_10_CONTINUA_DB_UPDATE_1_Update1 = new R3000_10_CONTINUA_DB_UPDATE_1_Update1()
            {
                V1FUNC_COD_ANGAR = V1FUNC_COD_ANGAR.ToString(),
                V1FUNC_NUM_MATRIC = V1FUNC_NUM_MATRIC.ToString(),
                V1FUNC_NUM_CPF = V1FUNC_NUM_CPF.ToString(),
            };

            R3000_10_CONTINUA_DB_UPDATE_1_Update1.Execute(r3000_10_CONTINUA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-3 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_3()
        {
            /*" -4397- EXEC SQL UPDATE SEGUROS.V0COMISSAO_FENAE SET AGECOBR = :V0COFE-AGECOBR , NUM_MATRICULA = :V0COFE-NUM-MATR , COD_AGENCIA_DEB = :V0COFE-AGENCIA-DEB , OPERACAO_DEB = :V0COFE-OPERACAO-DEB , NUM_CONTA_DEB = :V0COFE-NUMCTA-DEB , DIG_CONTA_DEB = :V0COFE-DIGCTA-DEB , NOM_SINDICO = :V0COFE-NOME-SIND , SITUACAO = :V0COFE-SITUACAO , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0COFE-NUMBIL END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1()
            {
                V0COFE_OPERACAO_DEB = V0COFE_OPERACAO_DEB.ToString(),
                V0COFE_AGENCIA_DEB = V0COFE_AGENCIA_DEB.ToString(),
                V0COFE_NUMCTA_DEB = V0COFE_NUMCTA_DEB.ToString(),
                V0COFE_DIGCTA_DEB = V0COFE_DIGCTA_DEB.ToString(),
                V0COFE_NOME_SIND = V0COFE_NOME_SIND.ToString(),
                V0COFE_NUM_MATR = V0COFE_NUM_MATR.ToString(),
                V0COFE_SITUACAO = V0COFE_SITUACAO.ToString(),
                V0COFE_AGECOBR = V0COFE_AGECOBR.ToString(),
                V0COFE_NUMBIL = V0COFE_NUMBIL.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-SELECT-2 */
        public void R3000_91_LE_ENDOSSO_DB_SELECT_2()
        {
            /*" -4443- EXEC SQL SELECT CGCCPF, NOME_RAZAO INTO :V0BILH-CGCCPF, :V0BILH-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0BILH-CODCLIEN END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_SELECT_2_Query1 = new R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1()
            {
                V0BILH_CODCLIEN = V0BILH_CODCLIEN.ToString(),
            };

            var executed_1 = R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1.Execute(r3000_91_LE_ENDOSSO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_CGCCPF, V0BILH_CGCCPF);
                _.Move(executed_1.V0BILH_NOME, V0BILH_NOME);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-INSERT-1 */
        public void R3000_10_CONTINUA_DB_INSERT_1()
        {
            /*" -4231- EXEC SQL INSERT INTO SEGUROS.V0PRODUTOR VALUES (:V1MCEF-COD-FONTE , :V1FUNC-COD-ANGAR , '3' , :V1FUNC-NOME-FUN , :V1FUNC-NUM-MATRIC , 0 , ' ' , :V1PROD-ENDERECO , ' ' , :V1PROD-CIDADE , :V1FUNC-SIGLA-UF , :V1FUNC-CEP , 0 , 0 , 0 , ' ' , ' ' , 0 , :V1FUNC-NUM-CPF , 0 , 0 , 'F' , 'S' , :V1SURG-PCDESISS , ' ' , ' ' , 104 , :V0BILH-AGENCIA , 0 , '0' , 0 , 0 , 0 , 0 , :V1SIST-DTMOVACB , :V1SIST-DTMOVACB , :V1SIST-DTMOVACB , :WHOST-NUMREC , 0 , '0' , NULL , CURRENT TIMESTAMP) END-EXEC. */

            var r3000_10_CONTINUA_DB_INSERT_1_Insert1 = new R3000_10_CONTINUA_DB_INSERT_1_Insert1()
            {
                V1MCEF_COD_FONTE = V1MCEF_COD_FONTE.ToString(),
                V1FUNC_COD_ANGAR = V1FUNC_COD_ANGAR.ToString(),
                V1FUNC_NOME_FUN = V1FUNC_NOME_FUN.ToString(),
                V1FUNC_NUM_MATRIC = V1FUNC_NUM_MATRIC.ToString(),
                V1PROD_ENDERECO = V1PROD_ENDERECO.ToString(),
                V1PROD_CIDADE = V1PROD_CIDADE.ToString(),
                V1FUNC_SIGLA_UF = V1FUNC_SIGLA_UF.ToString(),
                V1FUNC_CEP = V1FUNC_CEP.ToString(),
                V1FUNC_NUM_CPF = V1FUNC_NUM_CPF.ToString(),
                V1SURG_PCDESISS = V1SURG_PCDESISS.ToString(),
                V0BILH_AGENCIA = V0BILH_AGENCIA.ToString(),
                V1SIST_DTMOVACB = V1SIST_DTMOVACB.ToString(),
                WHOST_NUMREC = WHOST_NUMREC.ToString(),
            };

            R3000_10_CONTINUA_DB_INSERT_1_Insert1.Execute(r3000_10_CONTINUA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-SELECT-3 */
        public void R3000_91_LE_ENDOSSO_DB_SELECT_3()
        {
            /*" -4467- EXEC SQL SELECT CGCCPF , BILH_AP , BILH_RES , BILH_VDAZUL , DTMOVABE INTO :V1CROT-CGCCPF , :V1CROT-BILH-AP , :V1CROT-BILH-RES , :V1CROT-BILH-VDAZUL , :V1CROT-DTMOVABE FROM SEGUROS.V1CLIENTE_CROT WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_SELECT_3_Query1 = new R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1()
            {
                V0BILH_CGCCPF = V0BILH_CGCCPF.ToString(),
            };

            var executed_1 = R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1.Execute(r3000_91_LE_ENDOSSO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CROT_CGCCPF, V1CROT_CGCCPF);
                _.Move(executed_1.V1CROT_BILH_AP, V1CROT_BILH_AP);
                _.Move(executed_1.V1CROT_BILH_RES, V1CROT_BILH_RES);
                _.Move(executed_1.V1CROT_BILH_VDAZUL, V1CROT_BILH_VDAZUL);
                _.Move(executed_1.V1CROT_DTMOVABE, V1CROT_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-4 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_4()
        {
            /*" -4420- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :V0APOL-NUM-APOL , NRENDOS = 0, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1()
            {
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-UPDATE-2 */
        public void R3000_10_CONTINUA_DB_UPDATE_2()
        {
            /*" -4251- EXEC SQL UPDATE SEGUROS.V0NUMERO_OUTROS SET CODANGAR = CODANGAR + 1 WHERE CODANGAR = :V1NOUT-CODANGAR END-EXEC. */

            var r3000_10_CONTINUA_DB_UPDATE_2_Update1 = new R3000_10_CONTINUA_DB_UPDATE_2_Update1()
            {
                V1NOUT_CODANGAR = V1NOUT_CODANGAR.ToString(),
            };

            R3000_10_CONTINUA_DB_UPDATE_2_Update1.Execute(r3000_10_CONTINUA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-5 */
        public void R3000_10_CONTINUA_DB_SELECT_5()
        {
            /*" -4091- EXEC SQL SELECT NUM_MATRICULA , NOME_FUNCIONARIO , ENDERECO_CEF , CIDADE_CEF , SIGLA_UF , CEP , NUM_CPF , COD_ANGARIADOR INTO :V1FUNC-NUM-MATRIC , :V1FUNC-NOME-FUN , :V1FUNC-ENDERECO , :V1FUNC-CIDADE , :V1FUNC-SIGLA-UF , :V1FUNC-CEP , :V1FUNC-NUM-CPF , :V1FUNC-COD-ANGAR:VIND-COD-ANGAR FROM SEGUROS.V1FUNCIOCEF WHERE NUM_MATRICULA = :V0BILH-NUM-MATR END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_5_Query1 = new R3000_10_CONTINUA_DB_SELECT_5_Query1()
            {
                V0BILH_NUM_MATR = V0BILH_NUM_MATR.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_5_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FUNC_NUM_MATRIC, V1FUNC_NUM_MATRIC);
                _.Move(executed_1.V1FUNC_NOME_FUN, V1FUNC_NOME_FUN);
                _.Move(executed_1.V1FUNC_ENDERECO, V1FUNC_ENDERECO);
                _.Move(executed_1.V1FUNC_CIDADE, V1FUNC_CIDADE);
                _.Move(executed_1.V1FUNC_SIGLA_UF, V1FUNC_SIGLA_UF);
                _.Move(executed_1.V1FUNC_CEP, V1FUNC_CEP);
                _.Move(executed_1.V1FUNC_NUM_CPF, V1FUNC_NUM_CPF);
                _.Move(executed_1.V1FUNC_COD_ANGAR, V1FUNC_COD_ANGAR);
                _.Move(executed_1.VIND_COD_ANGAR, VIND_COD_ANGAR);
            }


        }

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-SECTION */
        private void R3020_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -4507- MOVE '3020' TO WNR-EXEC-SQL. */
            _.Move("3020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4512- PERFORM R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4515- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4516- DISPLAY 'R3020-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3020-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4517- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -4519- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4519- ADD +1 TO AC-U-V0BILHETE. */
            AREA_DE_WORK.AC_U_V0BILHETE.Value = AREA_DE_WORK.AC_U_V0BILHETE + +1;

        }

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4512- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-6 */
        public void R3000_10_CONTINUA_DB_SELECT_6()
        {
            /*" -4120- EXEC SQL SELECT CODANGAR INTO :V1NOUT-CODANGAR FROM SEGUROS.V1NUMERO_OUTROS END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_6_Query1 = new R3000_10_CONTINUA_DB_SELECT_6_Query1()
            {
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_6_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NOUT_CODANGAR, V1NOUT_CODANGAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-7 */
        public void R3000_10_CONTINUA_DB_SELECT_7()
        {
            /*" -4147- EXEC SQL SELECT B.PCDESISS INTO :V1SURG-PCDESISS FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1SUREG B WHERE A.COD_AGENCIA = :V1COFE-AGECOBR AND B.COD_SUREG = A.COD_ESCNEG END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_7_Query1 = new R3000_10_CONTINUA_DB_SELECT_7_Query1()
            {
                V1COFE_AGECOBR = V1COFE_AGECOBR.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_7_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SURG_PCDESISS, V1SURG_PCDESISS);
            }


        }

        [StopWatch]
        /*" R3040-00-MONTA-V0BILHETE-SECTION */
        private void R3040_00_MONTA_V0BILHETE_SECTION()
        {
            /*" -4530- MOVE '3040' TO WNR-EXEC-SQL. */
            _.Move("3040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4531- IF (V0BILH-DTQITBCO NOT EQUAL V1RCAC-DATARCAP) */

            if ((V0BILH_DTQITBCO != V1RCAC_DATARCAP))
            {

                /*" -4532- MOVE 1901 TO V0BILER-COD-ERRO */
                _.Move(1901, V0BILER_COD_ERRO);

                /*" -4534- PERFORM R3045-00-INSERE-ERRO. */

                R3045_00_INSERE_ERRO_SECTION();
            }


            /*" -4535- IF (V0BILH-VLRCAP NOT EQUAL V2RCAP-VLRCAP) */

            if ((V0BILH_VLRCAP != V2RCAP_VLRCAP))
            {

                /*" -4536- MOVE 2101 TO V0BILER-COD-ERRO */
                _.Move(2101, V0BILER_COD_ERRO);

                /*" -4536- PERFORM R3045-00-INSERE-ERRO. */

                R3045_00_INSERE_ERRO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3045-00-INSERE-ERRO-SECTION */
        private void R3045_00_INSERE_ERRO_SECTION()
        {
            /*" -4547- MOVE '3045' TO WNR-EXEC-SQL. */
            _.Move("3045", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4551- PERFORM R3045_00_INSERE_ERRO_DB_INSERT_1 */

            R3045_00_INSERE_ERRO_DB_INSERT_1();

            /*" -4554- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4555- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -4556- DISPLAY 'R1951-00 (ERRO - DUPLICADO V0BILHETE_ERROS)' */
                    _.Display($"R1951-00 (ERRO - DUPLICADO V0BILHETE_ERROS)");

                    /*" -4557- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -4558- ELSE */
                }
                else
                {


                    /*" -4559- DISPLAY 'R1951-00 (ERRO - INSERT V0BILHETE_ERROS)...' */
                    _.Display($"R1951-00 (ERRO - INSERT V0BILHETE_ERROS)...");

                    /*" -4560- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -4560- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3045-00-INSERE-ERRO-DB-INSERT-1 */
        public void R3045_00_INSERE_ERRO_DB_INSERT_1()
        {
            /*" -4551- EXEC SQL INSERT INTO SEGUROS.V0BILHETE_ERROS VALUES (:V0BILH-NUMBIL, :V0BILER-COD-ERRO) END-EXEC. */

            var r3045_00_INSERE_ERRO_DB_INSERT_1_Insert1 = new R3045_00_INSERE_ERRO_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V0BILER_COD_ERRO = V0BILER_COD_ERRO.ToString(),
            };

            R3045_00_INSERE_ERRO_DB_INSERT_1_Insert1.Execute(r3045_00_INSERE_ERRO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3045_99_SAIDA*/

        [StopWatch]
        /*" R3080-00-UPDATE-V0BILHETE-SECTION */
        private void R3080_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -4571- MOVE '3080' TO WNR-EXEC-SQL. */
            _.Move("3080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4575- PERFORM R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4578- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4579- DISPLAY 'R3080-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3080-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4580- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4582- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4584- MOVE 205 TO V0BILER-COD-ERRO. */
            _.Move(205, V0BILER_COD_ERRO);

            /*" -4584- PERFORM R3045-00-INSERE-ERRO. */

            R3045_00_INSERE_ERRO_SECTION();

        }

        [StopWatch]
        /*" R3080-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4575- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3080_99_SAIDA*/

        [StopWatch]
        /*" R3090-00-UPDATE-V0BILHETE-SECTION */
        private void R3090_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -4595- MOVE '3090' TO WNR-EXEC-SQL. */
            _.Move("3090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4599- PERFORM R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4602- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4603- DISPLAY 'R3090-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3090-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4604- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -4604- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3090-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4599- EXEC SQL UPDATE SEGUROS.V0BILHETE SET FONTE = :V1MCEF-COD-FONTE WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V1MCEF_COD_FONTE = V1MCEF_COD_FONTE.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3090_99_SAIDA*/

        [StopWatch]
        /*" R3095-00-UPDATE-V0BILHETE-SECTION */
        private void R3095_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -4615- MOVE '3095' TO WNR-EXEC-SQL. */
            _.Move("3095", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4619- PERFORM R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4623- DISPLAY 'R3095-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3095-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4624- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -4624- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3095-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4619- EXEC SQL UPDATE SEGUROS.V0BILHETE SET AGECOBR = :V1COFE-AGECOBR WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V1COFE_AGECOBR = V1COFE_AGECOBR.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3095_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-INSERT-V0BIL-CC00396-SECTION */
        private void R3110_00_INSERT_V0BIL_CC00396_SECTION()
        {
            /*" -4635- MOVE '3110' TO WNR-EXEC-SQL. */
            _.Move("3110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4636- MOVE V0BILH-NUMBIL TO V0C396-NUMBIL */
            _.Move(V0BILH_NUMBIL, V0C396_NUMBIL);

            /*" -4637- MOVE V1SIST-DTMOVACB TO V0C396-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0C396_DTMOVTO);

            /*" -4639- MOVE '0' TO V0C396-SITUACAO */
            _.Move("0", V0C396_SITUACAO);

            /*" -4645- PERFORM R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1 */

            R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1();

            /*" -4648- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4650- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -4651- ELSE */
                }
                else
                {


                    /*" -4655- DISPLAY '3110-00 (ERRO - INSERT TABELA V0BIL_CC00396)..' 'NUMBIL : ' V0C396-NUMBIL '  ' 'DTMOVTO: ' V0C396-DTMOVTO '  ' 'SITUACAO: ' V0C396-SITUACAO */

                    $"3110-00 (ERRO - INSERT TABELA V0BIL_CC00396)..NUMBIL : {V0C396_NUMBIL}  DTMOVTO: {V0C396_DTMOVTO}  SITUACAO: {V0C396_SITUACAO}"
                    .Display();

                    /*" -4655- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3110-00-INSERT-V0BIL-CC00396-DB-INSERT-1 */
        public void R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1()
        {
            /*" -4645- EXEC SQL INSERT INTO SEGUROS.V0BIL_CC00396 VALUES (:V0C396-NUMBIL , :V0C396-DTMOVTO , :V0C396-SITUACAO, CURRENT TIMESTAMP) END-EXEC. */

            var r3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1 = new R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1()
            {
                V0C396_NUMBIL = V0C396_NUMBIL.ToString(),
                V0C396_DTMOVTO = V0C396_DTMOVTO.ToString(),
                V0C396_SITUACAO = V0C396_SITUACAO.ToString(),
            };

            R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1.Execute(r3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3110_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-BAIXA-RCAP-SECTION */
        private void R3200_00_BAIXA_RCAP_SECTION()
        {
            /*" -4664- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3200_10_DECLARE_V0RCAPCOMP */

            R3200_10_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP */
        private void R3200_10_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4688- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -4690- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -4690- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R8100_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -5399- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO WHERE COD_CBO > 0 AND COD_CBO < 1000 ORDER BY COD_CBO END-EXEC. */
            CCBO = new VA6005B_CCBO(false);
            string GetQuery_CCBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							WHERE COD_CBO > 0 
							AND COD_CBO < 1000 
							ORDER BY COD_CBO";

                return query;
            }
            CCBO.GetQueryEvent += GetQuery_CCBO;

        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP */
        private void R3200_20_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4696- MOVE '3201' TO WNR-EXEC-SQL. */
            _.Move("3201", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4711- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -4714- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4715- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4715- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -4717- GO TO R3200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                    return;

                    /*" -4718- ELSE */
                }
                else
                {


                    /*" -4719- DISPLAY 'R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ' */
                    _.Display($"R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ");

                    /*" -4722- DISPLAY 'FONTE: ' V0RCAP-FONTE '  ' 'RECIBO: ' V0RCAP-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                    $"FONTE: {V0RCAP_FONTE}  RECIBO: {V0RCAP_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -4727- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4728- IF V1RCAC-SITUACAO NOT EQUAL '0' */

            if (V1RCAC_SITUACAO != "0")
            {

                /*" -4730- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4732- IF V1RCAC-OPERACAO GREATER 199 AND V1RCAC-OPERACAO LESS 300 */

            if (V1RCAC_OPERACAO > 199 && V1RCAC_OPERACAO < 300)
            {

                /*" -4734- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4736- IF V1RCAC-OPERACAO GREATER 399 AND V1RCAC-OPERACAO LESS 500 */

            if (V1RCAC_OPERACAO > 399 && V1RCAC_OPERACAO < 500)
            {

                /*" -4736- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -4711- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

            if (V1RCAPCOMP.Fetch())
            {
                _.Move(V1RCAPCOMP.V1RCAC_FONTE, V1RCAC_FONTE);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAP, V1RCAC_NRRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAPCO, V1RCAC_NRRCAPCO);
                _.Move(V1RCAPCOMP.V1RCAC_OPERACAO, V1RCAC_OPERACAO);
                _.Move(V1RCAPCOMP.V1RCAC_DTMOVTO, V1RCAC_DTMOVTO);
                _.Move(V1RCAPCOMP.V1RCAC_HORAOPER, V1RCAC_HORAOPER);
                _.Move(V1RCAPCOMP.V1RCAC_SITUACAO, V1RCAC_SITUACAO);
                _.Move(V1RCAPCOMP.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_VLRCAP, V1RCAC_VLRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DTCADAST, V1RCAC_DTCADAST);
                _.Move(V1RCAPCOMP.V1RCAC_SITCONTB, V1RCAC_SITCONTB);
            }

        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -4715- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP */
        private void R3200_30_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4745- MOVE '3202' TO WNR-EXEC-SQL. */
            _.Move("3202", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4755- PERFORM R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -4758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4759- DISPLAY 'R3200-30 (ERRO - UPDATE V0RCAPCOMP)...' */
                _.Display($"R3200-30 (ERRO - UPDATE V0RCAPCOMP)...");

                /*" -4762- DISPLAY 'FONTE: ' V1RCAC-FONTE ' ' 'RECIBO: ' V1RCAC-NRRCAP 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V1RCAC_FONTE} RECIBO: {V1RCAC_NRRCAP}BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -4764- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4764- ADD +1 TO AC-U-V0RCAPCOMP. */
            AREA_DE_WORK.AC_U_V0RCAPCOMP.Value = AREA_DE_WORK.AC_U_V0RCAPCOMP + +1;

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -4755- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

            var r3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_DTMOVTO = V1RCAC_DTMOVTO.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
            };

            R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(r3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3200-40-INSERT-V0RCAPCOMP */
        private void R3200_40_INSERT_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4770- MOVE '3203' TO WNR-EXEC-SQL. */
            _.Move("3203", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4771- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -4772- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -4773- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -4774- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -4775- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -4776- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -4777- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -4779- MOVE WS000-HORA-TIME TO V1RCAC-HORAOPER. */
            _.Move(WS000_HORA_TIME, V1RCAC_HORAOPER);

            /*" -4797- PERFORM R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -4800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4801- DISPLAY 'R3200-40 (ERRO - INSERT V0RCAPCOMP)...' */
                _.Display($"R3200-40 (ERRO - INSERT V0RCAPCOMP)...");

                /*" -4804- DISPLAY 'BILHETE:  ' V0BILH-NUMBIL '  ' 'AGENCIA:  ' V1RCAC-AGEAVISO '  ' 'BANCO:    ' V1RCAC-BCOAVISO */

                $"BILHETE:  {V0BILH_NUMBIL}  AGENCIA:  {V1RCAC_AGEAVISO}  BANCO:    {V1RCAC_BCOAVISO}"
                .Display();

                /*" -4807- DISPLAY 'DATARCAP: ' V1RCAC-DATARCAP '  ' 'FONTE:    ' V1RCAC-FONTE '  ' 'NRRCAP:   ' V1RCAC-NRRCAP */

                $"DATARCAP: {V1RCAC_DATARCAP}  FONTE:    {V1RCAC_FONTE}  NRRCAP:   {V1RCAC_NRRCAP}"
                .Display();

                /*" -4809- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4812- ADD 1 TO AC-I-V0RCAPCOMP. */
            AREA_DE_WORK.AC_I_V0RCAPCOMP.Value = AREA_DE_WORK.AC_I_V0RCAPCOMP + 1;

        }

        [StopWatch]
        /*" R3200-40-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -4797- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1SIST-DTMOVACB , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1SIST_DTMOVACB = V1SIST_DTMOVACB.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_SITUACAO = V1RCAC_SITUACAO.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_DATARCAP = V1RCAC_DATARCAP.ToString(),
                V1RCAC_DTCADAST = V1RCAC_DTCADAST.ToString(),
                V1RCAC_SITCONTB = V1RCAC_SITCONTB.ToString(),
                V1RCAC_COD_EMPRESA = V1RCAC_COD_EMPRESA.ToString(),
            };

            R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R3200-50-UPDATE-V0AVISOSALDO */
        private void R3200_50_UPDATE_V0AVISOSALDO(bool isPerform = false)
        {
            /*" -4818- MOVE '3204' TO WNR-EXEC-SQL. */
            _.Move("3204", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4825- PERFORM R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -4829- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4833- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4833- GO TO R3200-20-FETCH-V0RCAPCOMP. */

            R3200_20_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3200-50-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -4825- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

            var r3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 = new R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1()
            {
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
            };

            R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1.Execute(r3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3240-00-UPDATE-CROT-AP-SECTION */
        private void R3240_00_UPDATE_CROT_AP_SECTION()
        {
            /*" -4844- MOVE '3240' TO WNR-EXEC-SQL. */
            _.Move("3240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4846- MOVE 'S' TO V0CROT-BILH-AP */
            _.Move("S", V0CROT_BILH_AP);

            /*" -4847- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -4848- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -4849- ELSE */
            }
            else
            {


                /*" -4851- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -4856- PERFORM R3240_00_UPDATE_CROT_AP_DB_UPDATE_1 */

            R3240_00_UPDATE_CROT_AP_DB_UPDATE_1();

            /*" -4859- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4860- DISPLAY 'R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -4861- DISPLAY 'ATUALIZANDO ACIDENTES PESSOAIS         ...' */
                _.Display($"ATUALIZANDO ACIDENTES PESSOAIS         ...");

                /*" -4862- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -4864- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4864- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3240-00-UPDATE-CROT-AP-DB-UPDATE-1 */
        public void R3240_00_UPDATE_CROT_AP_DB_UPDATE_1()
        {
            /*" -4856- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_AP = :V0CROT-BILH-AP , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

            var r3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1 = new R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1()
            {
                V0CROT_DTMOVABE = V0CROT_DTMOVABE.ToString(),
                V0CROT_BILH_AP = V0CROT_BILH_AP.ToString(),
                V0BILH_CGCCPF = V0BILH_CGCCPF.ToString(),
            };

            R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1.Execute(r3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3240_99_SAIDA*/

        [StopWatch]
        /*" R3250-00-UPDATE-CROT-RES-SECTION */
        private void R3250_00_UPDATE_CROT_RES_SECTION()
        {
            /*" -4875- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4877- MOVE 'S' TO V0CROT-BILH-RES */
            _.Move("S", V0CROT_BILH_RES);

            /*" -4878- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -4879- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -4880- ELSE */
            }
            else
            {


                /*" -4882- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -4887- PERFORM R3250_00_UPDATE_CROT_RES_DB_UPDATE_1 */

            R3250_00_UPDATE_CROT_RES_DB_UPDATE_1();

            /*" -4890- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4891- DISPLAY 'R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -4892- DISPLAY 'ATUALIZANDO RESIDENCIAIS               ...' */
                _.Display($"ATUALIZANDO RESIDENCIAIS               ...");

                /*" -4893- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -4895- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4895- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3250-00-UPDATE-CROT-RES-DB-UPDATE-1 */
        public void R3250_00_UPDATE_CROT_RES_DB_UPDATE_1()
        {
            /*" -4887- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_RES = :V0CROT-BILH-RES , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

            var r3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1 = new R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1()
            {
                V0CROT_BILH_RES = V0CROT_BILH_RES.ToString(),
                V0CROT_DTMOVABE = V0CROT_DTMOVABE.ToString(),
                V0BILH_CGCCPF = V0BILH_CGCCPF.ToString(),
            };

            R3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1.Execute(r3250_00_UPDATE_CROT_RES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/

        [StopWatch]
        /*" R3260-00-INSERT-V0CLIEN-CROT-SECTION */
        private void R3260_00_INSERT_V0CLIEN_CROT_SECTION()
        {
            /*" -4906- MOVE '3260' TO WNR-EXEC-SQL. */
            _.Move("3260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4907- MOVE V0BILH-CGCCPF TO V0CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V0CROT_CGCCPF);

            /*" -4908- MOVE 'N' TO V0CROT-BILH-VDAZUL */
            _.Move("N", V0CROT_BILH_VDAZUL);

            /*" -4910- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
            _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

            /*" -4917- PERFORM R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1 */

            R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1();

            /*" -4920- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4921- DISPLAY 'R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...' */
                _.Display($"R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...");

                /*" -4922- DISPLAY 'CGCCPF: ' V0BILH-CGCCPF */
                _.Display($"CGCCPF: {V0BILH_CGCCPF}");

                /*" -4924- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4924- ADD +1 TO AC-I-V0CLIE-CROT. */
            AREA_DE_WORK.AC_I_V0CLIE_CROT.Value = AREA_DE_WORK.AC_I_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3260-00-INSERT-V0CLIEN-CROT-DB-INSERT-1 */
        public void R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1()
        {
            /*" -4917- EXEC SQL INSERT INTO SEGUROS.V0CLIENTE_CROT VALUES (:V0CROT-CGCCPF , :V0CROT-BILH-AP , :V0CROT-BILH-RES , :V0CROT-BILH-VDAZUL , :V0CROT-DTMOVABE) END-EXEC. */

            var r3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1 = new R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1()
            {
                V0CROT_CGCCPF = V0CROT_CGCCPF.ToString(),
                V0CROT_BILH_AP = V0CROT_BILH_AP.ToString(),
                V0CROT_BILH_RES = V0CROT_BILH_RES.ToString(),
                V0CROT_BILH_VDAZUL = V0CROT_BILH_VDAZUL.ToString(),
                V0CROT_DTMOVABE = V0CROT_DTMOVABE.ToString(),
            };

            R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1.Execute(r3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3260_99_SAIDA*/

        [StopWatch]
        /*" R3270-00-SELECT-APOLICE-ANT-SECTION */
        private void R3270_00_SELECT_APOLICE_ANT_SECTION()
        {
            /*" -4935- MOVE '3270' TO WNR-EXEC-SQL. */
            _.Move("3270", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4944- MOVE V0BILH-NUM-APO-ANT TO V1APOL-NUMBIL */
            _.Move(V0BILH_NUM_APO_ANT, V1APOL_NUMBIL);

            /*" -4952- PERFORM R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1 */

            R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1();

            /*" -4955- IF WS-INDICA-NULL EQUAL -1 */

            if (WS_INDICA_NULL == -1)
            {

                /*" -4956- MOVE ZEROS TO V1APOL-NUM-APOL */
                _.Move(0, V1APOL_NUM_APOL);

                /*" -4957- GO TO R3270-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3270_99_SAIDA*/ //GOTO
                return;

                /*" -4959- END-IF. */
            }


            /*" -4963- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4964- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4965- IF V1APOL-NUMBIL EQUAL 95307578980 */

                    if (V1APOL_NUMBIL == 95307578980)
                    {

                        /*" -4966- MOVE 0 TO V1APOL-NUM-APOL */
                        _.Move(0, V1APOL_NUM_APOL);

                        /*" -4967- ELSE */
                    }
                    else
                    {


                        /*" -4968- DISPLAY 'R3270-00 (ERRO SELECT V0APOLICE)' */
                        _.Display($"R3270-00 (ERRO SELECT V0APOLICE)");

                        /*" -4969- DISPLAY 'RENOVACAO DE BILHETE...........)' */
                        _.Display($"RENOVACAO DE BILHETE...........)");

                        /*" -4970- DISPLAY 'NUMBIL     : ' V1APOL-NUMBIL */
                        _.Display($"NUMBIL     : {V1APOL_NUMBIL}");

                        /*" -4971- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4972- ELSE */
                    }

                }
                else
                {


                    /*" -4973- DISPLAY 'R3270-00 (ERRO SELECT V0APOLICE)' */
                    _.Display($"R3270-00 (ERRO SELECT V0APOLICE)");

                    /*" -4974- DISPLAY 'RENOVACAO DE BILHETE...........)' */
                    _.Display($"RENOVACAO DE BILHETE...........)");

                    /*" -4975- DISPLAY 'NUMBIL     : ' V1APOL-NUMBIL */
                    _.Display($"NUMBIL     : {V1APOL_NUMBIL}");

                    /*" -4975- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3270-00-SELECT-APOLICE-ANT-DB-SELECT-1 */
        public void R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1()
        {
            /*" -4952- EXEC SQL SELECT MAX(NUM_APOLICE) INTO :V1APOL-NUM-APOL :WS-INDICA-NULL FROM SEGUROS.V1ENDOSSO WHERE NUMBIL = :V1APOL-NUMBIL AND NRENDOS = 0 END-EXEC. */

            var r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1 = new R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1()
            {
                V1APOL_NUMBIL = V1APOL_NUMBIL.ToString(),
            };

            var executed_1 = R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1.Execute(r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NUM_APOL, V1APOL_NUM_APOL);
                _.Move(executed_1.WS_INDICA_NULL, WS_INDICA_NULL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3270_99_SAIDA*/

        [StopWatch]
        /*" R3275-00-SELECT-ENDOSSO-ANT-SECTION */
        private void R3275_00_SELECT_ENDOSSO_ANT_SECTION()
        {
            /*" -4986- MOVE '3275' TO WNR-EXEC-SQL. */
            _.Move("3275", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4996- PERFORM R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1 */

            R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1();

            /*" -5000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5001- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -5002- MOVE '*' TO WS-RENOVACAO */
                    _.Move("*", AREA_DE_WORK.WS_RENOVACAO);

                    /*" -5003- DISPLAY 'RENOVACAO DE BILHETE...........)' */
                    _.Display($"RENOVACAO DE BILHETE...........)");

                    /*" -5004- DISPLAY 'APOLICE ANT: ' V1APOL-NUM-APOL */
                    _.Display($"APOLICE ANT: {V1APOL_NUM_APOL}");

                    /*" -5005- DISPLAY 'NUMBIL  ANT: ' V1APOL-NUMBIL */
                    _.Display($"NUMBIL  ANT: {V1APOL_NUMBIL}");

                    /*" -5006- ELSE */
                }
                else
                {


                    /*" -5007- DISPLAY 'R3275-00 (ERRO SELECT V0ENDOSSO)' */
                    _.Display($"R3275-00 (ERRO SELECT V0ENDOSSO)");

                    /*" -5008- DISPLAY 'RENOVACAO DE BILHETE...........)' */
                    _.Display($"RENOVACAO DE BILHETE...........)");

                    /*" -5009- DISPLAY 'NUMBIL     : ' V1APOL-NUMBIL */
                    _.Display($"NUMBIL     : {V1APOL_NUMBIL}");

                    /*" -5009- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3275-00-SELECT-ENDOSSO-ANT-DB-SELECT-1 */
        public void R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1()
        {
            /*" -4996- EXEC SQL SELECT DTINIVIG, DTTERVIG, CODPRODU INTO :V0ENDO-INIVIG-ANT, :V0ENDO-TERVIG-ANT, :V0ENDO-COD-PRODU-ANT FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1APOL-NUM-APOL AND NRENDOS = 0 END-EXEC. */

            var r3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1 = new R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1()
            {
                V1APOL_NUM_APOL = V1APOL_NUM_APOL.ToString(),
            };

            var executed_1 = R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1.Execute(r3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_INIVIG_ANT, V0ENDO_INIVIG_ANT);
                _.Move(executed_1.V0ENDO_TERVIG_ANT, V0ENDO_TERVIG_ANT);
                _.Move(executed_1.V0ENDO_COD_PRODU_ANT, V0ENDO_COD_PRODU_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3275_99_SAIDA*/

        [StopWatch]
        /*" R3280-00-SELECT-PRODUTO-SECTION */
        private void R3280_00_SELECT_PRODUTO_SECTION()
        {
            /*" -5021- MOVE '3280' TO WNR-EXEC-SQL. */
            _.Move("3280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5023- MOVE V0BILH-NUM-APO-ANT TO WHOST-NUM-BIL-ANT */
            _.Move(V0BILH_NUM_APO_ANT, WHOST_NUM_BIL_ANT);

            /*" -5030- PERFORM R3280_00_SELECT_PRODUTO_DB_SELECT_1 */

            R3280_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -5033- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5034- DISPLAY 'R3280-00 (ERRO SELECT BILHETES )' */
                _.Display($"R3280-00 (ERRO SELECT BILHETES )");

                /*" -5035- DISPLAY 'RENOVACAO DE BILHETE...........)' */
                _.Display($"RENOVACAO DE BILHETE...........)");

                /*" -5036- DISPLAY 'NUMBIL     : ' V0BILH-NUMBIL */
                _.Display($"NUMBIL     : {V0BILH_NUMBIL}");

                /*" -5038- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5039- IF WS-INDICA-NULL EQUAL +0 */

            if (WS_INDICA_NULL == +0)
            {

                /*" -5040- GO TO R3280-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3280_99_SAIDA*/ //GOTO
                return;

                /*" -5042- END-IF. */
            }


            /*" -5048- PERFORM R3280_00_SELECT_PRODUTO_DB_SELECT_2 */

            R3280_00_SELECT_PRODUTO_DB_SELECT_2();

            /*" -5051- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5052- DISPLAY 'R3280-00 (ERRO SELECT ENDOSSOS )' */
                _.Display($"R3280-00 (ERRO SELECT ENDOSSOS )");

                /*" -5053- DISPLAY 'RENOVACAO DE BILHETE...........)' */
                _.Display($"RENOVACAO DE BILHETE...........)");

                /*" -5054- DISPLAY 'NUMBIL     : ' V0BILH-NUMBIL */
                _.Display($"NUMBIL     : {V0BILH_NUMBIL}");

                /*" -5054- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3280-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R3280_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -5030- EXEC SQL SELECT NUM_APOLICE , COD_PRODUTO INTO :BILHETE-NUM-APOLICE ,:BILHETE-COD-PRODUTO:WS-INDICA-NULL FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :WHOST-NUM-BIL-ANT END-EXEC. */

            var r3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                WHOST_NUM_BIL_ANT = WHOST_NUM_BIL_ANT.ToString(),
            };

            var executed_1 = R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(executed_1.BILHETE_COD_PRODUTO, BILHETE.DCLBILHETE.BILHETE_COD_PRODUTO);
                _.Move(executed_1.WS_INDICA_NULL, WS_INDICA_NULL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3280_99_SAIDA*/

        [StopWatch]
        /*" R3280-00-SELECT-PRODUTO-DB-SELECT-2 */
        public void R3280_00_SELECT_PRODUTO_DB_SELECT_2()
        {
            /*" -5048- EXEC SQL SELECT COD_PRODUTO INTO :BILHETE-COD-PRODUTO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1 = new R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1()
            {
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1.Execute(r3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_COD_PRODUTO, BILHETE.DCLBILHETE.BILHETE_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -5068- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5069- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -5070- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -5071- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -5073- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -5075- DISPLAY '+------------------------------------------------ '-----------------+' */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -5077- DISPLAY 'I BILHETES DE SEGUROS '                 I' */
            _.Display($"I BILHETES DE SEGUROS I");

            /*" -5079- DISPLAY 'I '                 I' */
            _.Display($"I I");

            /*" -5081- DISPLAY 'I                TOTAIS DE CONTROLE EM ' WDATA-CABEC '                   I' */

            $"I                TOTAIS DE CONTROLE EM {AREA_DE_WORK.WDATA_CABEC}                   I"
            .Display();

            /*" -5084- DISPLAY '+------------------------------------------------ '-----------------+' . */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -5086- DISPLAY 'I T A B E L A S A T U A L I Z A D A ' S               I' . */

            $"I T A B E L A S A T U A L I Z A D A SI"
            .Display();

            /*" -5088- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5090- DISPLAY 'I NOME DA TABELA I IN 'SERT   I UPDATE  I' */

            $"I NOME DA TABELA I IN SERTIUPDATEI"
            .Display();

            /*" -5092- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5095- DISPLAY 'I NUMERO OUTROS             (V0NUMERO_OUTS)  I  ' '     ' '   I  ' AC-U-V0NUMEROUT '  I' */

            $"I NUMERO OUTROS             (V0NUMERO_OUTS)  I          I  {AREA_DE_WORK.AC_U_V0NUMEROUT}  I"
            .Display();

            /*" -5098- DISPLAY 'I NUMERACAO GERAL           (V0NUMERO_AES)   I  ' '     ' '   I  ' AC-U-V0NUMERAES '  I' */

            $"I NUMERACAO GERAL           (V0NUMERO_AES)   I          I  {AREA_DE_WORK.AC_U_V0NUMERAES}  I"
            .Display();

            /*" -5101- DISPLAY 'I APOLICES                  (V0APOLICE)      I  ' AC-I-V0APOLICE '   I  ' AC-U-V0APOLICE '  I' */

            $"I APOLICES                  (V0APOLICE)      I  {AREA_DE_WORK.AC_I_V0APOLICE}   I  {AREA_DE_WORK.AC_U_V0APOLICE}  I"
            .Display();

            /*" -5104- DISPLAY 'I ENDOSSOS                  (V0ENDOSSO)      I  ' AC-I-V0ENDOSSO '   I  ' '     ' '  I' */

            $"I ENDOSSOS                  (V0ENDOSSO)      I  {AREA_DE_WORK.AC_I_V0ENDOSSO}   I         I"
            .Display();

            /*" -5107- DISPLAY 'I RECIBOS COB ANTECIPADA    (V0RCAP)         I  ' '     ' '   I  ' AC-U-V0RCAP '  I' */

            $"I RECIBOS COB ANTECIPADA    (V0RCAP)         I          I  {AREA_DE_WORK.AC_U_V0RCAP}  I"
            .Display();

            /*" -5110- DISPLAY 'I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  ' AC-I-V0RCAPCOMP '   I  ' AC-U-V0RCAPCOMP '  I' */

            $"I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  {AREA_DE_WORK.AC_I_V0RCAPCOMP}   I  {AREA_DE_WORK.AC_U_V0RCAPCOMP}  I"
            .Display();

            /*" -5113- DISPLAY 'I PRODUTORES                (V0PRODUTOR)     I  ' AC-I-V0PRODUTOR '   I  ' '     ' '  I' */

            $"I PRODUTORES                (V0PRODUTOR)     I  {AREA_DE_WORK.AC_I_V0PRODUTOR}   I         I"
            .Display();

            /*" -5116- DISPLAY 'I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I  ' '     ' '   I  ' AC-U-V0FUNCIOCEF '  I' */

            $"I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I          I  {AREA_DE_WORK.AC_U_V0FUNCIOCEF}  I"
            .Display();

            /*" -5119- DISPLAY 'I APOLICE CORRETOR          (V0APOLCORRET)   I  ' AC-I-V0APOLCORRET '   I  ' '     ' '  I' */

            $"I APOLICE CORRETOR          (V0APOLCORRET)   I  {AREA_DE_WORK.AC_I_V0APOLCORRET}   I         I"
            .Display();

            /*" -5122- DISPLAY 'I APOLICE COSSEGURO         (V0APOLCOSCED)   I  ' AC-I-V0APOLCOSCED '   I  ' '     ' '  I' */

            $"I APOLICE COSSEGURO         (V0APOLCOSCED)   I  {AREA_DE_WORK.AC_I_V0APOLCOSCED}   I         I"
            .Display();

            /*" -5125- DISPLAY 'I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  ' AC-I-V0ORDECOSCED '   I  ' '     ' '  I' */

            $"I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  {AREA_DE_WORK.AC_I_V0ORDECOSCED}   I         I"
            .Display();

            /*" -5128- DISPLAY 'I PARCELAS                  (V0PARCELAS)     I  ' AC-I-V0PARCELA '   I  ' '     ' '  I' */

            $"I PARCELAS                  (V0PARCELAS)     I  {AREA_DE_WORK.AC_I_V0PARCELA}   I         I"
            .Display();

            /*" -5131- DISPLAY 'I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  ' AC-I-V0HISTOPARC '   I  ' '     ' '  I' */

            $"I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  {AREA_DE_WORK.AC_I_V0HISTOPARC}   I         I"
            .Display();

            /*" -5134- DISPLAY 'I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  ' AC-I-V0COBERAPOL '   I  ' '     ' '  I' */

            $"I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  {AREA_DE_WORK.AC_I_V0COBERAPOL}   I         I"
            .Display();

            /*" -5137- DISPLAY 'I COMISSAO FENAE            (V0COMISSAO_FENAEI  ' '     ' '   I  ' AC-U-V0COMIFENAE '  I' */

            $"I COMISSAO FENAE            (V0COMISSAO_FENAEI          I  {AREA_DE_WORK.AC_U_V0COMIFENAE}  I"
            .Display();

            /*" -5140- DISPLAY 'I CLIENTE CROT              (V0CLIENTE_CROT  I  ' AC-I-V0CLIE-CROT '   I  ' AC-U-V0CLIE-CROT '  I' */

            $"I CLIENTE CROT              (V0CLIENTE_CROT  I  {AREA_DE_WORK.AC_I_V0CLIE_CROT}   I  {AREA_DE_WORK.AC_U_V0CLIE_CROT}  I"
            .Display();

            /*" -5143- DISPLAY 'I ADIANTAMENTOS             (V0ADIANTA)      I  ' AC-I-V0ADIANTA '   I  ' '     ' '  I' */

            $"I ADIANTAMENTOS             (V0ADIANTA)      I  {AREA_DE_WORK.AC_I_V0ADIANTA}   I         I"
            .Display();

            /*" -5145- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5147- DISPLAY 'I QUANTIDADE DE BILHETES REJEITADOS          I  ' AC-U-V0BILHETE '   I         I' */

            $"I QUANTIDADE DE BILHETES REJEITADOS          I  {AREA_DE_WORK.AC_U_V0BILHETE}   I         I"
            .Display();

            /*" -5148- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4280-00-TRATA-FC0105S-SECTION */
        private void R4280_00_TRATA_FC0105S_SECTION()
        {
            /*" -5159- MOVE '4280' TO WNR-EXEC-SQL */
            _.Move("4280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5161- SET W88-DESLIGAR-TRACE TO TRUE */
            FILLER_1["W88_DESLIGAR_TRACE"] = true;

            /*" -5163- PERFORM R4290-00-INSERT-MOVFEDCA. */

            R4290_00_INSERT_MOVFEDCA_SECTION();

            /*" -5164- PERFORM R4400-00-INSERT-COMFEDCA. */

            R4400_00_INSERT_COMFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4280_99_SAIDA*/

        [StopWatch]
        /*" R4290-00-INSERT-MOVFEDCA-SECTION */
        private void R4290_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -5174- MOVE '4290' TO WNR-EXEC-SQL */
            _.Move("4290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5202- INITIALIZE LK-PLANO LK-SERIE LK-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-PARCEIRO LK-RAMO LK-COD-USUARIO LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE. */
            _.Initialize(
                LK_PLANO
                , LK_SERIE
                , LK_TITULO
                , LK_NUM_PROPOSTA
                , LK_QTD_TITULOS
                , LK_VLR_TITULO
                , LK_PARCEIRO
                , LK_RAMO
                , LK_COD_USUARIO
                , LK_TRACE
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -5205- IF V1BILP-CODPRODU EQUAL 8112 OR 8113 OR 3709 OR 8201 OR 8104 OR 8105 OR JVPRD3709 */

            if (V1BILP_CODPRODU.In("8112", "8113", "3709", "8201", "8104", "8105", JVBKINCL.JV_PRODUTOS.JVPRD3709.ToString()))
            {

                /*" -5208- MOVE 858 TO LK-PLANO W77-SMALLINT-D1 */
                _.Move(858, LK_PLANO, W77_SMALLINT_D1);

                /*" -5209- ELSE */
            }
            else
            {


                /*" -5212- MOVE 850 TO LK-PLANO W77-SMALLINT-D1 */
                _.Move(850, LK_PLANO, W77_SMALLINT_D1);

                /*" -5214- END-IF */
            }


            /*" -5217- MOVE V0BILH-NUMBIL TO LK-NUM-PROPOSTA W77-DECIMAL */
            _.Move(V0BILH_NUMBIL, LK_NUM_PROPOSTA, W77_DECIMAL);

            /*" -5219- MOVE 1 TO LK-QTD-TITULOS */
            _.Move(1, LK_QTD_TITULOS);

            /*" -5223- MOVE V1BILC-VALMAX TO LK-VLR-TITULO W77-DECIMAL-D1 */
            _.Move(V1BILC_VALMAX, LK_VLR_TITULO, W77_DECIMAL_D1);

            /*" -5225- MOVE V1BILP-CODPRODU TO PROD-COD-PRODUTO. */
            _.Move(V1BILP_CODPRODU, PROD_COD_PRODUTO);

            /*" -5228- PERFORM R5000-00-SELECT-EMP-CAP. */

            R5000_00_SELECT_EMP_CAP_SECTION();

            /*" -5230- MOVE PARM-COD-EMPR-CAP TO LK-PARCEIRO. */
            _.Move(PARM_COD_EMPR_CAP, LK_PARCEIRO);

            /*" -5232- MOVE 'VA6005B' TO LK-COD-USUARIO */
            _.Move("VA6005B", LK_COD_USUARIO);

            /*" -5235- MOVE V1BILP-CODPRODU TO LK-RAMO W77-SMALLINT-D2 */
            _.Move(V1BILP_CODPRODU, LK_RAMO, W77_SMALLINT_D2);

            /*" -5237- MOVE ZEROS TO LK-NUM-NSA. */
            _.Move(0, LK_NUM_NSA);

            /*" -5238- IF W88-LIGAR-TRACE */

            if (FILLER_1["W88_LIGAR_TRACE"])
            {

                /*" -5239- MOVE 'TRACE ON ' TO LK-TRACE */
                _.Move("TRACE ON ", LK_TRACE);

                /*" -5240- SET W88-NAO-REPETIR TO TRUE */
                FILLER_0["W88_NAO_REPETIR"] = true;

                /*" -5241- ELSE */
            }
            else
            {


                /*" -5242- MOVE 'TRACE OFF' TO LK-TRACE */
                _.Move("TRACE OFF", LK_TRACE);

                /*" -5243- SET W88-REPETIR TO TRUE */
                FILLER_0["W88_REPETIR"] = true;

                /*" -5245- END-IF */
            }


            /*" -5265- CALL 'VG0105S' USING LK-PLANO , LK-SERIE , LK-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-PARCEIRO , LK-RAMO , LK-COD-USUARIO , LK-NUM-NSA , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE. */
            _.Call("VG0105S", LK_PLANO, LK_SERIE, LK_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_PARCEIRO, LK_RAMO, LK_COD_USUARIO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE);

            /*" -5266- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -5267- MOVE LK-OUT-SQLCODE TO WS-SQLCODE */
                _.Move(LK_OUT_SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                /*" -5268- DISPLAY 'LK-NUM-PLANO       <' W77-SMALLINT-D1 '>' */

                $"LK-NUM-PLANO       <{W77_SMALLINT_D1}>"
                .Display();

                /*" -5269- DISPLAY 'LK-NUM-PROPOSTA    <' W77-DECIMAL '>' */

                $"LK-NUM-PROPOSTA    <{W77_DECIMAL}>"
                .Display();

                /*" -5270- DISPLAY 'LK-VLR-TITULO      <' W77-DECIMAL-D1 '>' */

                $"LK-VLR-TITULO      <{W77_DECIMAL_D1}>"
                .Display();

                /*" -5271- DISPLAY 'LK-NUM-PARCEIRO    <001>' */
                _.Display($"LK-NUM-PARCEIRO    <001>");

                /*" -5272- DISPLAY 'LK-RAMO            <' W77-SMALLINT-D2 '>' */

                $"LK-RAMO            <{W77_SMALLINT_D2}>"
                .Display();

                /*" -5273- DISPLAY ' ' */
                _.Display($" ");

                /*" -5274- DISPLAY 'LK-OUT-COD-RETORNO <' LK-OUT-COD-RETORNO '>' */

                $"LK-OUT-COD-RETORNO <{LK_OUT_COD_RETORNO}>"
                .Display();

                /*" -5275- DISPLAY 'WS-SQLCODE         <' WS-SQLCODE '>' */

                $"WS-SQLCODE         <{AREA_DE_WORK.WS_SQLCODE}>"
                .Display();

                /*" -5276- DISPLAY 'LK-OUT-MENSAGEM    <' LK-OUT-MENSAGEM '>' */

                $"LK-OUT-MENSAGEM    <{LK_OUT_MENSAGEM}>"
                .Display();

                /*" -5277- DISPLAY 'LK-OUT-SQLERRMC    <' LK-OUT-SQLERRMC '>' */

                $"LK-OUT-SQLERRMC    <{LK_OUT_SQLERRMC}>"
                .Display();

                /*" -5278- DISPLAY 'LK-OUT-SQLSTATE    <' LK-OUT-SQLSTATE '>' */

                $"LK-OUT-SQLSTATE    <{LK_OUT_SQLSTATE}>"
                .Display();

                /*" -5280- DISPLAY ' ' */
                _.Display($" ");

                /*" -5281- IF W88-REPETIR */

                if (FILLER_0["W88_REPETIR"])
                {

                    /*" -5282- SET W88-LIGAR-TRACE TO TRUE */
                    FILLER_1["W88_LIGAR_TRACE"] = true;

                    /*" -5283- GO TO R4290-00-INSERT-MOVFEDCA */
                    new Task(() => R4290_00_INSERT_MOVFEDCA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -5284- ELSE */
                }
                else
                {


                    /*" -5286- IF (LK-OUT-MENSAGEM(1:46) EQUAL 'STATUS DA PARCERIA COM EMPRESA/PRODUTO INATIVO' ) */

                    if ((LK_OUT_MENSAGEM.Substring(1, 46) == "STATUS DA PARCERIA COM EMPRESA/PRODUTO INATIVO"))
                    {

                        /*" -5287- DISPLAY 'ATENCAO -- ATENCAO ---->> ' LK-OUT-MENSAGEM */
                        _.Display($"ATENCAO -- ATENCAO ---->> {LK_OUT_MENSAGEM}");

                        /*" -5288- ELSE */
                    }
                    else
                    {


                        /*" -5290- IF LK-OUT-MENSAGEM(1:36) EQUAL 'PROD <8201> NAO VINCULADO AO PLA/EMP' */

                        if (LK_OUT_MENSAGEM.Substring(1, 36) == "PROD <8201> NAO VINCULADO AO PLA/EMP")
                        {

                            /*" -5292- DISPLAY 'ATENCAO -- ATENCAO ---->> ' LK-OUT-MENSAGEM */
                            _.Display($"ATENCAO -- ATENCAO ---->> {LK_OUT_MENSAGEM}");

                            /*" -5293- ELSE */
                        }
                        else
                        {


                            /*" -5294- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -5295- END-IF */
                        }


                        /*" -5297- END-IF */
                    }


                    /*" -5298- END-IF */
                }


                /*" -5298- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4290_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-SECTION */
        private void R4400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -5309- MOVE '4400' TO WNR-EXEC-SQL. */
            _.Move("4400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5320- PERFORM R4400_00_INSERT_COMFEDCA_DB_INSERT_1 */

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1();

            /*" -5323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5324- DISPLAY 'R4300 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R4300 - ERRO NO INSERT DA TITFEDCA ");

                /*" -5325- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -5326- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5327- END-IF. */
            }


        }

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-DB-INSERT-1 */
        public void R4400_00_INSERT_COMFEDCA_DB_INSERT_1()
        {
            /*" -5320- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :V0BILH-NUMBIL , '0' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP ) END-EXEC. */

            var r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 = new R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1.Execute(r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-SELECT-EMP-CAP-SECTION */
        private void R5000_00_SELECT_EMP_CAP_SECTION()
        {
            /*" -5341- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5350- PERFORM R5000_00_SELECT_EMP_CAP_DB_SELECT_1 */

            R5000_00_SELECT_EMP_CAP_DB_SELECT_1();

            /*" -5353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5354- DISPLAY 'R1000-00 (ERRO - SELECT PRODUTO )...' */
                _.Display($"R1000-00 (ERRO - SELECT PRODUTO )...");

                /*" -5355- DISPLAY 'PRODUTO: ' PROD-COD-PRODUTO */
                _.Display($"PRODUTO: {PROD_COD_PRODUTO}");

                /*" -5355- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-SELECT-EMP-CAP-DB-SELECT-1 */
        public void R5000_00_SELECT_EMP_CAP_DB_SELECT_1()
        {
            /*" -5350- EXEC SQL SELECT PR.COD_EMPRESA , PG.COD_EMPRESA_CAP INTO :PROD-COD-EMPRESA, :PARM-COD-EMPR-CAP FROM SEGUROS.PRODUTO PR, SEGUROS.PARAMETROS_GERAIS PG WHERE PR.COD_PRODUTO = :PROD-COD-PRODUTO AND PR.COD_EMPRESA = PG.COD_EMPRESA END-EXEC. */

            var r5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1 = new R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1()
            {
                PROD_COD_PRODUTO = PROD_COD_PRODUTO.ToString(),
            };

            var executed_1 = R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1.Execute(r5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROD_COD_EMPRESA, PROD_COD_EMPRESA);
                _.Move(executed_1.PARM_COD_EMPR_CAP, PARM_COD_EMPR_CAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R8000-JV1-BUSCA-EMPRESA-SECTION */
        private void R8000_JV1_BUSCA_EMPRESA_SECTION()
        {
            /*" -5366- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5374- PERFORM R8000_JV1_BUSCA_EMPRESA_DB_SELECT_1 */

            R8000_JV1_BUSCA_EMPRESA_DB_SELECT_1();

            /*" -5377- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5378- DISPLAY 'R8000-JV1-BUSCA-EMPRESA  ..' */
                _.Display($"R8000-JV1-BUSCA-EMPRESA  ..");

                /*" -5379- DISPLAY 'PRODUTO - ' PRODUTO-COD-PRODUTO */
                _.Display($"PRODUTO - {PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO}");

                /*" -5380- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -5381- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5381- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-JV1-BUSCA-EMPRESA-DB-SELECT-1 */
        public void R8000_JV1_BUSCA_EMPRESA_DB_SELECT_1()
        {
            /*" -5374- EXEC SQL SELECT COD_EMPRESA ,RAMO_EMISSOR INTO :PRODUTO-COD-EMPRESA ,:PRODUTO-RAMO-EMISSOR FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUTO-COD-PRODUTO WITH UR END-EXEC. */

            var r8000_JV1_BUSCA_EMPRESA_DB_SELECT_1_Query1 = new R8000_JV1_BUSCA_EMPRESA_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R8000_JV1_BUSCA_EMPRESA_DB_SELECT_1_Query1.Execute(r8000_JV1_BUSCA_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
                _.Move(executed_1.PRODUTO_RAMO_EMISSOR, PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-SECTION */
        private void R8100_00_DECLARE_CBO_SECTION()
        {
            /*" -5392- MOVE '8100' TO WNR-EXEC-SQL. */
            _.Move("8100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5399- PERFORM R8100_00_DECLARE_CBO_DB_DECLARE_1 */

            R8100_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -5401- PERFORM R8100_00_DECLARE_CBO_DB_OPEN_1 */

            R8100_00_DECLARE_CBO_DB_OPEN_1();

            /*" -5404- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5405- DISPLAY 'R8100 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R8100 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -5406- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -5407- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-OPEN-1 */
        public void R8100_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -5401- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8110-00-FETCH-CBO-SECTION */
        private void R8110_00_FETCH_CBO_SECTION()
        {
            /*" -5417- MOVE '8110' TO WNR-EXEC-SQL. */
            _.Move("8110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5420- PERFORM R8110_00_FETCH_CBO_DB_FETCH_1 */

            R8110_00_FETCH_CBO_DB_FETCH_1();

            /*" -5423- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5424- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5425- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", AREA_DE_WORK.WFIM_CBO);

                    /*" -5425- PERFORM R8110_00_FETCH_CBO_DB_CLOSE_1 */

                    R8110_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -5428- ELSE */
                }
                else
                {


                    /*" -5430- DISPLAY '8110 - PROBLEMAS NO FETCH CCBO SQLCODE = ' SQLCODE */
                    _.Display($"8110 - PROBLEMAS NO FETCH CCBO SQLCODE = {DB.SQLCODE}");

                    /*" -5431- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-FETCH-1 */
        public void R8110_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -5420- EXEC SQL FETCH CCBO INTO :CBO-COD-CBO, :CBO-DESCR-CBO END-EXEC. */

            if (CCBO.Fetch())
            {
                _.Move(CCBO.CBO_COD_CBO, CBO_COD_CBO);
                _.Move(CCBO.CBO_DESCR_CBO, CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-CLOSE-1 */
        public void R8110_00_FETCH_CBO_DB_CLOSE_1()
        {
            /*" -5425- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8110_99_SAIDA*/

        [StopWatch]
        /*" R8120-00-CARREGA-CBO-SECTION */
        private void R8120_00_CARREGA_CBO_SECTION()
        {
            /*" -5441- MOVE '8120' TO WNR-EXEC-SQL. */
            _.Move("8120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5444- MOVE CBO-DESCR-CBO TO TAB-DESCR-CBO-C (CBO-COD-CBO) */
            _.Move(CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_2[CBO_COD_CBO].TAB_DESCR_CBO_C);

            /*" -5445- PERFORM R8110-00-FETCH-CBO. */

            R8110_00_FETCH_CBO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8120_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5457- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -5459- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -5459- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -5461- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5465- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -5465- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}