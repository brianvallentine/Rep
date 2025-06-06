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
using Sias.PessoaFisica.DB2.PF0602B;

namespace Code
{
    public class PF0602B
    {
        public bool IsCall { get; set; }

        public PF0602B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *--------------------------------------------------------------- *      */
        /*"      * SISTEMA ............. SISTEM DE PRODUTOS DE FIDELIZACAO        *      */
        /*"      * ANALISTA ............ LUIZ CARLOS CONCEICAO                    *      */
        /*"      * REVISAO PROGRAMACAO.. REGINALDO SILVA                          *      */
        /*"      * OBJETIVO............. CARREGAR A TABELA BILHETE                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.57  * VERSAO 57 ..: DEMANDA 592593                                   *      */
        /*"      *               INSERIR E-MAIL DA BASE PESSOA NA BASE DE CLIENTE *      */
        /*"      *                                                                *      */
        /*"      * EM 17/09/2024 - FRANK CARVALHO       PROCURE POR V.57          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.56  * VERSAO 56 ..: DEMANDA 538808 - PRODUTOS AP BEM ESTAR NO CCA    *      */
        /*"      *               8533 - AP BEM ESTAR - PU (12 MESES)              *      */
        /*"      *               8534 - AP BEM ESTAR - PU (36 MESES)              *      */
        /*"      *                                                                *      */
        /*"      * EM 02/09/2024 - CANETTA              PROCURE POR V.56          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.55  *   VERSAO 55 - INCIDENTE 598524 E DEMANDA 575716                *      */
        /*"      *             - INSERIR CRITICA PARA ENDERECO NAO CADASTRADO     *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/08/2024 - TERCIO CARVALHO     PROCURE POR V.55         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.54  *   VERSAO 54 - INCIDENTE 593493                                 *      */
        /*"      *             - IGNORAR PRODUTO-SIVPF 56                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/06/2024 - CANETTA             PROCURE POR V.54         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.53  *   VERSAO 53 - DEMANDA 538.869                                  *      */
        /*"      *             - RETIRAR ERRO 10902 QUANDO CPF MENOR QUE 100000   *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/01/2024 - ELIERMES OLIVEIRA   PROCURE POR V.53         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.52  * VERSAO 52 ..: DEMANDA 489284 - PRODUTOS MEI                    *      */
        /*"      *               8530 - EMPREENDEDOR - MENSAL                     *      */
        /*"      *               8531 - EMPREENDEDOR - PU (12 MESES)              *      */
        /*"      *               8532 - EMPREENDEDOR - PU (36 MESES)              *      */
        /*"      *                                                                *      */
        /*"      * EM 27/12/2023 - CANETTA              PROCURE POR V.52          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.51  *   VERSAO 51 - DEMANDA 559.665                                  *      */
        /*"      *             - ARMAZENAR AS INFORMACOES DO CCA QUANDO A ORIGEM: *      */
        /*"      *               15 - LOTERICO                                    *      */
        /*"      *               22 - CAIXA AQUI                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/12/2023 - FRANK CARVALHO      PROCURE POR V.51         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.50  *   VERSAO 50 - DEMANDA 554.757                                  *      */
        /*"      *             - NAO CRITICAR A MATRICULA QUANDO O PRODUTO FOR    *      */
        /*"      *               AMPARO E A ORIGEM FOR:                           *      */
        /*"      *               15 - LOTERICO                                    *      */
        /*"      *               22 - CAIXA AQUI                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/11/2023 - FRANK CARVALHO      PROCURE POR V.50         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.49  *  VERSAO 49  - DEMANDA 496381 - IMPLANTACAO AMPARO - 22-CX AQUI *      */
        /*"      *               3721 - MICRO SEGURO AMPARO - PU (12 MESES)       *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/10/2023 - ELIERMES OLIVEIRA   PROCURE POR V.49         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.48  *  VERSAO 48  - DEMANDA 538832-IMPLANTACAO AMPARO - 13-LOTERICO  *      */
        /*"      *               3721 - MICRO SEGURO AMPARO - PU (12 MESES)       *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/10/2023 - ELIERMES OLIVEIRA   PROCURE POR V.48         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.47  *  VERSAO 47  - DEMANDA 496381 - IMPLANTACAO AMPARO - 15-SISPL   *      */
        /*"      *               3721 - MICRO SEGURO AMPARO - PU (12 MESES)       *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/10/2023 - ELIERMES OLIVEIRA   PROCURE POR V.47         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.46  *  VERSAO 46  - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA TABELA  *      */
        /*"      *               BILHETE_ERROS                                    *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *             - SOMAR 10000 AOS COD-ERRO UTILIZADOS NAS TABELAS  *      */
        /*"      *               DE BILHETE E VIDA AO MESMO TEMPO                 *      */
        /*"      *                                                                *      */
        /*"      *  EM 14/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.46        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.45  *  VERSAO 45  - PLD Circular 612 - Fase 2 -  Demanda 379166      *      */
        /*"      *             - INCLUIDO ROTINA SPBVG001 PARA CONSULTA DE RISCO  *      */
        /*"      *               DA PROPOSTA. CASO EXISTA RISCO CRITICO NAO       *      */
        /*"      *               SOLUCIONADO AGUARDA CONCLUSAO DO TRATAMENTO      *      */
        /*"      *               PELO GESTOR, CASO NAO ENCONTRE RISCO CADASTRADO, *      */
        /*"      *               VERIFICA SE MOTOR GEROU CLASSIFICACAO, SE GEROU  *      */
        /*"      *               INSERE CLASSIFICACAO, SE NAO GEROU INFORMA QUE A *      */
        /*"      *               PROPOSTA SERAH EMITIDA SEM ANALISE DE RISCO      *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/10/2022 - ELIERMES OLIVEIRA   PROCURE POR V.45         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.44  * VERSAO 44...: DEMANDA 323720 - IMPLANTACAO PRODUTOS CANAL AIC  *      */
        /*"      *               8521 - CAIXA FACIL APOIO FAMILIA ( MENSAL )      *      */
        /*"      *               8528 - BILHETE AP BEM-ESTAR - PU (12 MESES)      *      */
        /*"      *               8529 - BILHETE AP BEM-ESTAR - PU (36 MESES)      *      */
        /*"      *                                                                *      */
        /*"      * EM 26/04/2022 - ELIERMES OLIVEIRA    PROCURE POR V.44          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.43  * VERSAO 43...: DEMANDA 317042 - CAIXA FACIL FAMILIA 3721 (PU)   *      */
        /*"      *               RECEBER VIA ATM PRODUTOS 3721                    *      */
        /*"      * RESPONSAVEL.: CANETTA                         PROCURE V.43     *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *   VERSAO 42   - TAREFA 274356                                  *      */
        /*"      *               - CORRIGIR IDENTIFICACAO DO PRODUTO              *      */
        /*"      *   EM 16/01/2020 - HERVAL / HUSNI     PROCURE POR V.42          *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *   VERSAO 41   - HISTORIA 218161                                *      */
        /*"      *               - VENDA DE BILHETE FACIL AP (3709) NO CAIXA      *      */
        /*"      *                 EXECUTIVO.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/10/2019 - BRICE HO           PROCURE POR V.41          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 40   - HISTORIA 197908                                *      */
        /*"      *               - AJUSTES NO ACESSO BILHETE_COBERTURA PARA       *      */
        /*"      *                 PRODUTO 3709 (REJEITAR BILHETES ATM COM        *      */
        /*"      *                 PREMIO DIVERGENTE DE R$9,90).                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/04/2019 - BRICE HO           PROCURE POR V.40          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39   - HISTORIA 181017                               *       */
        /*"      *               - ALTERAR A APLICA��O PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1) E SEUS PRODUTOS.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/01/2019 - LUIZ FERNANDO      PROCURE POR V.39          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      * VERSAO 38             IMPLANTACAO DE PRODUTOS NO CANAL ATM     *      */
        /*"      * ATENDE CADMUS 152120  8144 - CAIXA FACIL APOIO FAMILIA         *      */
        /*"      *                       8145 - CAIXA FACIL DESCONTO REMEDIO      *      */
        /*"      *                       8146 - CAIXA FACIL APOIO PROFISSIONAL    *      */
        /*"      *                       8147 - CAIXA FACIL SOS INFORMATICA       *      */
        /*"      *                       8148 - CAIXA FACIL VIAGEM SEGURA         *      */
        /*"      *                       8149 - CAIXA FACIL APOIO NUTRICAO        *      */
        /*"      *                       8150 - CAIXA FACIL REVISAO DO LAR        *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.38          FRANK CARVALHO                           *      */
        /*"      *                       16/07/2017                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 37             AJUSTE NA ORIGEM_VENDA 1014 BACKSEG      *      */
        /*"      * ATENDE JIRA 160       PREPARAR PARA ACEITAR VARIAS ORIGENS     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.37          REGINALDO DA SILVA                       *      */
        /*"      *                       06/12/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 36             AJUSTE NO COD-CBO - NAO ESTOURAR 999     *      */
        /*"      * ATENDE CADMUS 134904                                           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.36          REGINALDO DA SILVA                       *      */
        /*"      *                       06/04/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 35             MIGRACAO DOS PRODUTOS 8112 E 8113 PARA   *      */
        /*"      * ATENDE CADMUS 104952  MICROSEGURO CODIGO 3709                  *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.35          RIBAMAR MARQUES                          *      */
        /*"      *                       20/11/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 34             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.34          REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       15/10/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 33             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.33          REGINALDO SILVA                          *      */
        /*"      *                       06/01/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 32 - PROJETO AIC                                      *      */
        /*"      *               RECUPERAR TELEFONES CLIENTE                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/11/2011 - MARCUS ANDRE DIAS                            *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.32             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 31 - CADMUS 54479                                     *      */
        /*"      *               COLOCAR CLAUSULA WITH UR NOS COMANDOS DB2 SELECT *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/06/2011 - SERGIO LORETO                                *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.31             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 30 - CAD 201.040                                      *      */
        /*"      *               AJUSTE NO PROGRAMA PARA TRATAR O NOVO PRODUTO    *      */
        /*"      *               8112 - BILHE AP.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/04/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.30             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  29.2 - CADMUS 51629                                    *      */
        /*"      * ABEND PRODUCAO               LUIZ CARLOS/REGINALDO             *      */
        /*"      *                                                                *      */
        /*"      * 21/12/2010 - INCLUIR NO CURSOR A SEGUINTE CONDICAO             *      */
        /*"      *              AND C.ORIGEM_PROPOSTA   <> 1001                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  29.1 - CADMUS 49336/48499/48281                        *      */
        /*"      * PROJETO NPG                  SERGIO LORETO/STEFANINI           *      */
        /*"      *                                                                *      */
        /*"      * 26/10/2010 - INCLUIR NO CURSOR A SEGUINTE CONDICAO             *      */
        /*"      *              AND C.ORIGEM_PROPOSTA   <> 1001                   *      */
        /*"      * PROCURAR==> C49336                                             *      */
        /*"      *                                                                *      */
        /*"      * 30/09/2010 - ADEQUAR O PROGRAMA PARA PROCESSAR PROPOSTAS       *      */
        /*"      *              COMERCIALIZADAS E NAO ENVIADAS NO SIGPF NPG       *      */
        /*"      * PROCURAR POR: C48499                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  29 - CAD39036                                          *      */
        /*"      * PROJETO ATM                  EDIVALDO/ FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      * 29/03/2010   ADEQUAR O PROGRAMA PARA PROCESSAR O BILHETE ATM   *      */
        /*"      *                                                                *      */
        /*"      * PROCURAR POR: V.29                                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  28                                                     *      */
        /*"      *                                                                *      */
        /*"      * 10/03/2010   ADEQUAR O PROGRAMA PARA NAO PROCESSAR ATM         *      */
        /*"      *                                                                *      */
        /*"      * PROCURAR POR: V.28                                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  27                                                     *      */
        /*"      * PROJETO SIES(ALTERACOES)     EDILANA / LUIS CARLOS             *      */
        /*"      *                                                                *      */
        /*"      * 31/08/2009   PASSA A NAO TRATAR PRODUTO 10 - BILHETE RD QUE    *      */
        /*"      *              SERA TRATADO PELO PROJETO SIES                    *      */
        /*"      * PROCURAR POR: V.27                                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  CRITICA PROPOSTAS DE PRODUTOS DE BILHETE RD E AP              *      */
        /*"      *  VISANDO INCLUSAO NA V0BILHETE                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  26                                                     *      */
        /*"      *   SSI 21364  - CONSISTIR O NOME PARA NAO PERMITIR A ENTRADA    *      */
        /*"      *                DE NOVOS BILHETE COM O NOME EM BRANCO.          *      */
        /*"      *                                                                *      */
        /*"      * 05/03/2009    PROCURAR POR V.26     ROGERIO PEREIRA MACIEL     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  25                                                     *      */
        /*"      *   SSI 23872  - CORRECAO ABEND CADMUS 17250                     *      */
        /*"      *                                                                *      */
        /*"      * 12/11/2008    PROCURAR POR V.25     LUCIA VIEIRA               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  24                                                     *      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 08/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 23 - CAD12889                                         *      */
        /*"      *               NOVOS PRODUTOS FACIL RD                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/08/2008 - TERCIO (FAST COMPUTER)   PROCURE POR V.23    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 - CAD12997                                         *      */
        /*"      *               NOVOS PRODUTOS FACIL AP                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/08/2008 - TERCIO (FAST COMPUTER)   PROCURE POR V.22    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CAD 11.248/2008                                  *      */
        /*"      *               VENDA DE BILHETE RD VIA CARTAO                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/07/2008 - WANGER (FAST COMPUTER)   PROCURE POR V.21    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 20 - SSI 21.058/2008 - TRATA SQLCODE -803 NO INSERT CLIENTES   *      */
        /*"      *                                                                *      */
        /*"      *      (PROCURAR POR V.20) LUCIA VIEIRA    - EM 17/03/2008       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 19 - SSI 17.210/2007 - PROJETO DE VENDAS PELO CANAL ATM E      *      */
        /*"      *                        CENTRAIS DE RELACIONAMENTO              *      */
        /*"      *                                                                *      */
        /*"      *      (PROCURAR POR V.19) FAST COMPUTER   - EM 14/11/2007       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 18 - SSI 12.092/2006 - PREENCHE A WHOST-PROFISSAO QUE DEIXOU   *      */
        /*"      *                        QUE DEIXOU DE SER PREENCHIDA QUANDO DA  *      */
        /*"      *                        ELIMINACAO DA CRITICA DE BILHETE.       *      */
        /*"      *                                                                *      */
        /*"      *      (PROCURAR POR V.18) FAST COMPUTER   - EM 22/11/2006       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 17 - SSI     /2006 - TRATAR CANAL DE VENDA GITEL               *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *      (PROCURAR POR V.17) FAST COMPUTER   - EM 07/09/2006       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 16 - SSI 0911/2005 - INCLUIR NO BILHETE TIPO RESIDENCIA        *      */
        /*"      *                                                                *      */
        /*"      *                    - INCLUIR TRATAMENTO P/ TIPO RESIDENCIA:    *      */
        /*"      *                        TABELA GE_TP_MORAD_IMOVEL               *      */
        /*"      *                                                                *      */
        /*"      *      (PROCURAR POR V.16) SANDRA / LUCIA  - EM 19/05/2006       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 15 - SSI 8426/2006 - LIBERADA A CRITICA DE PROFISSAO           *      */
        /*"      *      (PROCURAR POR V.15) TERCIO CARVALHO - EM 13/04/2006       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 14 - PASSOU A TRATAR PROFISSAO QUALIFICADA PARA BILHETE AP     *      */
        /*"      *      (PROCURAR POR V.14) LUIZ CARLOS - EM 28/12/2004.          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 13 - IMPLEMENTACAO CONTROLE CIRCULAR 200 SUSEP - DATA EXPEDICAO*      */
        /*"      *      (PROCURAR POR LC0304) LUIZ CARLOS - EM 17/04/2003.        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 12 - PASSA A CRITICAR CGCCPF. CRITICA TAMBEM A PROFISSAO       *      */
        /*"      *      OUTROS.                                                   *      */
        /*"      *                                                                *      */
        /*"      *      PROCURE 'TL0301'                                          *      */
        /*"      *                                                                *      */
        /*"      *      TERCIO CARVALHO 04/02/2003                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 11 - INIBIDA A CONSISTENCIA DE CONVENIO CAIXA DO TRABALHADOR   *      */
        /*"      *      A PEDIDO DO USUARIO.                                      *      */
        /*"      *      PROCURE TL0212                                            *      */
        /*"      *                                                                *      */
        /*"      *      TERCIO CARVALHO 10/12/2002.                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 10 - INCLUIDO PROCESSO PARA OBTER NA BILHETE_COBER O CODIGO DA *      */
        /*"      *      OPCAO DE PLANO (OPCAO DE COBERTURA), EM FUNCAO DA CRIACAO *      */
        /*"      *      DE CODIGOS COM MAIS DE 1 BYTE - 21/22/23/31/32/33.        *      */
        /*"      *      PROCURE 020911                                            *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS     11/09/2002.                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 09 - RETIRADO DA CRITICA DE PROFISSAO OS CODIGOS 296, 297, 298 *      */
        /*"      *      E 996 POR SE TRATAREM DE PROFISSOES NAO DECLINAVEIS.      *      */
        /*"      *      PROCURE TL0206                                            *      */
        /*"      *                                                                *      */
        /*"      *      TERCIO CARVALHO 27/06/2002.                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 08 - IMPLEMENTADA A CRITICA DE PROFISSOES DECLINAVEIS PARA     *      */
        /*"      *      BILHETE AP. PROCURE TL0205                                *      */
        /*"      *                                                                *      */
        /*"      *      TERCIO CARVALHO 28/05/2002.                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 07 - PASSOU A TRATAR PROPOSTAS REMOTAS COM SIT-PROPOSTA = 'POB'*      */
        /*"      *      SAO AS PROPOSTAS REMOTAS SEM AS INFORMACOES DO SICOB.     *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  02/08/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 06 - PASSOU A TRATAR QUALQUER ABEND NA V0CLIENTE, PASSANDO A   *      */
        /*"      *      NAO PROCESSAR A REFERIDA PROPOSTA. PROCURE POR LC0606.    *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  06/06/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 05 - PASSOU A GERAR COMO 'REJ  - PROPOSTAS REJEITADAS', AS PRO-*      */
        /*"      *      POSTAS REMOTAS QUE ESTEJAM FORA DA FAIXA DE NUMERACAO DE  *      */
        /*"      *      BILHETE. PROCURE POR LC0424.                              *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  24/04/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 03 - PASSOU A CALCULAR O DV DA MATRICULA DO VENDEDOR E ATUALI- *      */
        /*"      *      ZAR A TABELA PROPOSTA_FIDELIZ.   PROCURE POR LC2411.      *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  24/11/2000.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 02 - PASSOU A ACESSAR A TABELA RCAPS UTILIZANDO TAMBEM O CODI- *      */
        /*"      *      GO DA FONTE DA AGENCIA DE COBRANCA.                       *      */
        /*"      *                                PROCURE LC1100.                 *      */
        /*"      *      LUIZ CARLOS  23/11/2000.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 01 - PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'PEN', *      */
        /*"      *      AO INVEZ DE 'ANA', CASO A PROPOSTA TENHA ALGUM ERRO.      *      */
        /*"      *                                PROCURE LC0800.                 *      */
        /*"      *      LUIZ CARLOS  28/08/2000.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 00 - PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'ANA', *      */
        /*"      *      AO INVEZ DE 'REJ', CASO A PROPOSTA TENHA ALGUM ERRO.      *      */
        /*"      *                                PROCURE LC0600.                 *      */
        /*"      *      LUIZ CARLOS  26/06/2000.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPLEMENTACAO DE CONTROLE DE MOVTO CLIENTE           JAN/2002  *      */
        /*"      * (PROCURAR POR EB0102)     ENRICO (PRODEXTER)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPLEMENTACAO DA NOVA CODIFICACAO DE ESCRITORIO DE NEGOCIOS    *      */
        /*"      * (PROCURAR POR EB0202) - ENRICO (PRODEXTER)            FEV/2002 *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-NOME-RAZAO        PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_NOME_RAZAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TIPO-PESSOA       PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-IDE-SEXO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_IDE_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-EST-CIVIL         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_EST_CIVIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OCORR-END         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ENDERECO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-BAIRRO            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CIDADE            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIGLA-UF          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_SIGLA_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CEP               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DDD               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TELEFONE          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-FAX               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CGCCPF            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTNASC            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODUSU            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-UF-EXPEDIDORA     PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_UF_EXPEDIDORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CNAE-MEI          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CNAE_MEI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-I      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-F      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-PREMIO-MIN       PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_PREMIO_MIN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PREMIO-MAX       PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_PREMIO_MAX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01     WS-TEM-ERRO-CRITICO    PIC X(001) VALUE 'N'.*/
        public StringBasis WS_TEM_ERRO_CRITICO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01     WS-QT-RISCO-CRITICO    PIC 9(005) VALUE 0.*/
        public IntBasis WS_QT_RISCO_CRITICO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01     WS-QT-EM-CRITICA       PIC 9(005) VALUE 0.*/
        public IntBasis WS_QT_EM_CRITICA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01     WS-QT-EMISSAO-S-RISCO  PIC 9(005) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_S_RISCO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01     WS-QT-EMISSAO-C-RISCO  PIC 9(005) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_C_RISCO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01     WS-QT-LIBERADO-EMISSAO PIC 9(005) VALUE 0.*/
        public IntBasis WS_QT_LIBERADO_EMISSAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01     WS-ERRO-VG009          PIC 9(001) VALUE 0.*/
        public IntBasis WS_ERRO_VG009 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01     WS-PROGRAMA            PIC X(008) VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01     WS-COD-CRITICA         PIC 9(005) VALUE ZEROS.*/
        public IntBasis WS_COD_CRITICA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-I-ERRO                   PIC  9(003) VALUE ZEROS.*/
        public IntBasis WS_I_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-FLAG-TEM-ERRO            PIC  X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WORK-TAB-ERROS-CERT.*/
        public PF0602B_WORK_TAB_ERROS_CERT WORK_TAB_ERROS_CERT { get; set; } = new PF0602B_WORK_TAB_ERROS_CERT();
        public class PF0602B_WORK_TAB_ERROS_CERT : VarBasis
        {
            /*"    05  WS-TAB-ERROS-CERT   OCCURS 100 TIMES.*/
            public ListBasis<PF0602B_WS_TAB_ERROS_CERT> WS_TAB_ERROS_CERT { get; set; } = new ListBasis<PF0602B_WS_TAB_ERROS_CERT>(100);
            public class PF0602B_WS_TAB_ERROS_CERT : VarBasis
            {
                /*"      10  TB-ERRO-CERT          PIC S9(004) COMP.*/
                public IntBasis TB_ERRO_CERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"01  WS-JV1-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
            }
        }
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01           N88-PRODUTO-MEI    PIC  X(001)    VALUE     '#'.*/

        public SelectorBasis N88_PRODUTO_MEI { get; set; } = new SelectorBasis("001", "#")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88         PRODUTO-MEI                       VALUE     'S'. */
							new SelectorItemBasis("PRODUTO_MEI", "S")
                }
        };

        /*"01           W-COD-CLIENTE-FIS  PIC S9(009) USAGE COMP.*/
        public IntBasis W_COD_CLIENTE_FIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01           W-COD-CLIENTE-JUR  PIC S9(009) USAGE COMP.*/
        public IntBasis W_COD_CLIENTE_JUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01           W-CODIGO-CNAE      PIC  X(010) VALUE ZEROS.*/
        public StringBasis W_CODIGO_CNAE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01           FILLER             REDEFINES   W-CODIGO-CNAE.*/
        private _REDEF_PF0602B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_PF0602B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_PF0602B_FILLER_0(); _.Move(W_CODIGO_CNAE, _filler_0); VarBasis.RedefinePassValue(W_CODIGO_CNAE, _filler_0, W_CODIGO_CNAE); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_CODIGO_CNAE); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, W_CODIGO_CNAE); }
        }  //Redefines
        public class _REDEF_PF0602B_FILLER_0 : VarBasis
        {
            /*"  03         FILLE              PIC  X(003).*/
            public StringBasis FILLE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  03         W-CODIGO-CNAE-7P   PIC  X(007).*/
            public StringBasis W_CODIGO_CNAE_7P { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"01  W-SQLCODE                         PIC  ---9.*/

            public _REDEF_PF0602B_FILLER_0()
            {
                FILLE.ValueChanged += OnValueChanged;
                W_CODIGO_CNAE_7P.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis W_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01  W-DATA-PIC9                       PIC  9(008)   VALUE ZEROS.*/
        public IntBasis W_DATA_PIC9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"01  FILLER  REDEFINES  W-DATA-PIC9.*/
        private _REDEF_PF0602B_FILLER_1 _filler_1 { get; set; }
        public _REDEF_PF0602B_FILLER_1 FILLER_1
        {
            get { _filler_1 = new _REDEF_PF0602B_FILLER_1(); _.Move(W_DATA_PIC9, _filler_1); VarBasis.RedefinePassValue(W_DATA_PIC9, _filler_1, W_DATA_PIC9); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_PIC9); }; return _filler_1; }
            set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_PIC9); }
        }  //Redefines
        public class _REDEF_PF0602B_FILLER_1 : VarBasis
        {
            /*"  03 W-DIA-PIC9                        PIC  9(002).*/
            public IntBasis W_DIA_PIC9 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03 W-MES-PIC9                        PIC  9(002).*/
            public IntBasis W_MES_PIC9 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03 W-ANO-PIC9                        PIC  9(004).*/
            public IntBasis W_ANO_PIC9 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01  WHOST-INFO-COMPL                  PIC  X(050).*/

            public _REDEF_PF0602B_FILLER_1()
            {
                W_DIA_PIC9.ValueChanged += OnValueChanged;
                W_MES_PIC9.ValueChanged += OnValueChanged;
                W_ANO_PIC9.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WHOST_INFO_COMPL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"01  WHOST-PROFISSAO                   PIC  X(020).*/
        public StringBasis WHOST_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WHOST-PROFISSAO-CONJUGE           PIC  X(020).*/
        public StringBasis WHOST_PROFISSAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WHOST-SIT-PROPOSTA                PIC  X(003).*/
        public StringBasis WHOST_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WHOST-SIT-ENVIO                   PIC  X(001).*/
        public StringBasis WHOST_SIT_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-SIT-REGISTRO                PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-OPCAOPAG                    PIC  X(001).*/
        public StringBasis WHOST_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-OPCAO-COBER                 PIC S9(004)      COMP.*/
        public IntBasis WHOST_OPCAO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-FONTE                       PIC S9(004)      COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-RAMO                        PIC S9(004)      COMP.*/
        public IntBasis WHOST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PROPAUTOM                   PIC S9(004)      COMP.*/
        public IntBasis WHOST_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DTPROXVEN                   PIC  X(010).*/
        public StringBasis WHOST_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  VIND-AGECTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-OPRCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NUMCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DIGCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DTMOVTO                      PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-IMPSEGAUXF                   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_IMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-VLCUSTAUXF                   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_VLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PRMDIT                       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_PRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-QTDIT                        PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_QTDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-OCOR                         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-EXPEDICAO               PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_EXPEDICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-NASCIMENTO              PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CGC-CONVENENTE               PIC S9(004)      COMP.*/
        public IntBasis VIND_CGC_CONVENENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NOME-CONJUGE                 PIC S9(004)      COMP.*/
        public IntBasis VIND_NOME_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-NASC-CONJUGE            PIC S9(004)      COMP.*/
        public IntBasis VIND_DATA_NASC_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PROFISSAO-CONJUGE            PIC S9(004)      COMP.*/
        public IntBasis VIND_PROFISSAO_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-FAIXA-RENDA-IND              PIC S9(004)      COMP.*/
        public IntBasis VIND_FAIXA_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-FAIXA-RENDA-FAM              PIC S9(004)      COMP.*/
        public IntBasis VIND_FAIXA_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-IDADE                     PIC S9(004)      COMP.*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-CODPRODU                   PIC S9(004)      COMP.*/
        public IntBasis PRVG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-CODPRODU                   PIC S9(004)      COMP.*/
        public IntBasis PRVG_CODPRODU_0 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-PERIPGTO                   PIC S9(004)      COMP.*/
        public IntBasis PRVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  ESTIP-COD-CCT                   PIC S9(015)      COMP-3.*/
        public IntBasis ESTIP_COD_CCT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  ESTIP-NOME                      PIC  X(040).*/
        public StringBasis ESTIP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  WHOST-DDD                       PIC S9(004)      COMP.*/
        public IntBasis WHOST_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-TELEFONE                  PIC S9(009)      COMP.*/
        public IntBasis WHOST_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FAX                       PIC S9(009)      COMP.*/
        public IntBasis WHOST_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LPARM01                     PIC  9(007).*/
        public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
        /*"01  LPARM01-R                   REDEFINES   LPARM01.*/
        private _REDEF_PF0602B_LPARM01_R _lparm01_r { get; set; }
        public _REDEF_PF0602B_LPARM01_R LPARM01_R
        {
            get { _lparm01_r = new _REDEF_PF0602B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
            set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
        }  //Redefines
        public class _REDEF_PF0602B_LPARM01_R : VarBasis
        {
            /*"    05          LPARM01-1       PIC  9(001).*/
            public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-2       PIC  9(001).*/
            public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-3       PIC  9(001).*/
            public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-4       PIC  9(001).*/
            public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-5       PIC  9(001).*/
            public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-6       PIC  9(001).*/
            public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              LPARM03         PIC  9(001).*/

            public _REDEF_PF0602B_LPARM01_R()
            {
                LPARM01_1.ValueChanged += OnValueChanged;
                LPARM01_2.ValueChanged += OnValueChanged;
                LPARM01_3.ValueChanged += OnValueChanged;
                LPARM01_4.ValueChanged += OnValueChanged;
                LPARM01_5.ValueChanged += OnValueChanged;
                LPARM01_6.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01              LPARM03-R       REDEFINES   LPARM03                                PIC  X(001).*/
        private _REDEF_StringBasis _lparm03_r { get; set; }
        public _REDEF_StringBasis LPARM03_R
        {
            get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
            set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
        }  //Redefines
        /*"01  W-NRMATRICULA               PIC  9(007)  VALUE ZEROS.*/
        public IntBasis W_NRMATRICULA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01  FILLER                      REDEFINES   W-NRMATRICULA.*/
        private _REDEF_PF0602B_FILLER_2 _filler_2 { get; set; }
        public _REDEF_PF0602B_FILLER_2 FILLER_2
        {
            get { _filler_2 = new _REDEF_PF0602B_FILLER_2(); _.Move(W_NRMATRICULA, _filler_2); VarBasis.RedefinePassValue(W_NRMATRICULA, _filler_2, W_NRMATRICULA); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_NRMATRICULA); }; return _filler_2; }
            set { VarBasis.RedefinePassValue(value, _filler_2, W_NRMATRICULA); }
        }  //Redefines
        public class _REDEF_PF0602B_FILLER_2 : VarBasis
        {
            /*"    05          W-NRMATRICULA1  PIC  9(006).*/
            public IntBasis W_NRMATRICULA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          W-DV-MATRICULA  PIC  9(001).*/
            public IntBasis W_DV_MATRICULA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  WORK-AREA.*/

            public _REDEF_PF0602B_FILLER_2()
            {
                W_NRMATRICULA1.ValueChanged += OnValueChanged;
                W_DV_MATRICULA.ValueChanged += OnValueChanged;
            }

        }
        public PF0602B_WORK_AREA WORK_AREA { get; set; } = new PF0602B_WORK_AREA();
        public class PF0602B_WORK_AREA : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0602B_FAIXAS _faixas { get; set; }
            public _REDEF_PF0602B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_PF0602B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0602B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-BILHETE    VALUE               823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_BILHETE", "823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-SENIOR     VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_SENIOR", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-EXECUTIVO  VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_EXECUTIVO", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-AUTO       VALUE               828, 837, 847, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_AUTO", "828,837,847,845,846")
                }
                };

                /*"        07  W-FILLER                  PIC 9(008).*/
                public IntBasis W_FILLER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_PF0602B_FAIXAS()
                {
                    FILLER_3.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    W_FILLER.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0602B_CANAL _canal { get; set; }
            public _REDEF_PF0602B_CANAL CANAL
            {
                get { _canal = new _REDEF_PF0602B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0602B_CANAL : VarBasis
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
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05  W-ORIGEM-PROPOSTA             PIC 9(002).*/

                public _REDEF_PF0602B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_ORIGEM_PROPOSTA { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ORIGEM-SIGPF                   VALUE 01. */
							new SelectorItemBasis("ORIGEM_SIGPF", "01"),
							/*" 88 ORIGEM-CAIXA-PREV              VALUE 02. */
							new SelectorItemBasis("ORIGEM_CAIXA_PREV", "02"),
							/*" 88 ORIGEM-SIGAT                   VALUE 03. */
							new SelectorItemBasis("ORIGEM_SIGAT", "03"),
							/*" 88 ORIGEM-SASSE                   VALUE 04. */
							new SelectorItemBasis("ORIGEM_SASSE", "04"),
							/*" 88 ORIGEM-CAIXA-CAP               VALUE 05. */
							new SelectorItemBasis("ORIGEM_CAIXA_CAP", "05"),
							/*" 88 ORIGEM-SIFEC                   VALUE 06. */
							new SelectorItemBasis("ORIGEM_SIFEC", "06"),
							/*" 88 ORIGEM-REMOTA                  VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88 ORIGEM-INTRANET                VALUE 08. */
							new SelectorItemBasis("ORIGEM_INTRANET", "08"),
							/*" 88 ORIGEM-INTERNET                VALUE 09. */
							new SelectorItemBasis("ORIGEM_INTERNET", "09"),
							/*" 88 ORIGEM-CORRET-VIT              VALUE 10. */
							new SelectorItemBasis("ORIGEM_CORRET_VIT", "10"),
							/*" 88 ORIGEM-FILIAL                  VALUE 11. */
							new SelectorItemBasis("ORIGEM_FILIAL", "11"),
							/*" 88 ORIGEM-MARSH                   VALUE 12. */
							new SelectorItemBasis("ORIGEM_MARSH", "12"),
							/*" 88 ORIGEM-SIVPFWEB-REMOTA         VALUE 13. */
							new SelectorItemBasis("ORIGEM_SIVPFWEB_REMOTA", "13"),
							/*" 88 ORIGEM-CORRESPOND              VALUE 14. */
							new SelectorItemBasis("ORIGEM_CORRESPOND", "14"),
							/*" 88 ORIGEM-LOTERICO                VALUE 15. */
							new SelectorItemBasis("ORIGEM_LOTERICO", "15"),
							/*" 88 ORIGEM-SIPEN-CAIXATEM          VALUE 17. */
							new SelectorItemBasis("ORIGEM_SIPEN_CAIXATEM", "17"),
							/*" 88 ORIGEM-CX-AQUI-CCA             VALUE 22. */
							new SelectorItemBasis("ORIGEM_CX_AQUI_CCA", "22"),
							/*" 88 ORIGEM-CX-EXECUTIVO            VALUE 34 35 36 . */
							new SelectorItemBasis("ORIGEM_CX_EXECUTIVO", "34 35 36 ")
                }
            };

            /*"    05  W-CONVENIO-CX-TR              PIC 9(001).*/

            public SelectorBasis W_CONVENIO_CX_TR { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-CONVENIO-CX-TRAB           VALUE 01. */
							new SelectorItemBasis("TEM_CONVENIO_CX_TRAB", "01")
                }
            };

            /*"    05  W-ENDERECO                    PIC 9(001).*/

            public SelectorBasis W_ENDERECO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 END-CORRES-CADASTRADO          VALUE 01. */
							new SelectorItemBasis("END_CORRES_CADASTRADO", "01"),
							/*" 88 END-CORRES-N-CADASTRADO        VALUE 02. */
							new SelectorItemBasis("END_CORRES_N_CADASTRADO", "02"),
							/*" 88 DEMAIS-END-CADASTRADO          VALUE 03. */
							new SelectorItemBasis("DEMAIS_END_CADASTRADO", "03"),
							/*" 88 DEMAIS-END-N-CADASTRADO        VALUE 04. */
							new SelectorItemBasis("DEMAIS_END_N_CADASTRADO", "04")
                }
            };

            /*"    05  W-PESSOA-EMAIL                PIC 9(001) VALUE ZEROS.*/

            public SelectorBasis W_PESSOA_EMAIL { get; set; } = new SelectorBasis("001", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EMAIL-CADASTRADO               VALUE 01. */
							new SelectorItemBasis("EMAIL_CADASTRADO", "01"),
							/*" 88 EMAIL-N-CADASTRADO             VALUE 02. */
							new SelectorItemBasis("EMAIL_N_CADASTRADO", "02")
                }
            };

            /*"    05  W-CNPJ-CONVENENTE             PIC 9(001).*/

            public SelectorBasis W_CNPJ_CONVENENTE { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CNPJ-CADASTRADO                VALUE 01. */
							new SelectorItemBasis("CNPJ_CADASTRADO", "01"),
							/*" 88 CNPJ-NAO-CADASTRADO            VALUE 02. */
							new SelectorItemBasis("CNPJ_NAO_CADASTRADO", "02"),
							/*" 88 CNPJ-INATIVO                   VALUE 03. */
							new SelectorItemBasis("CNPJ_INATIVO", "03"),
							/*" 88 CNPJ-DESATIVADO                VALUE 04. */
							new SelectorItemBasis("CNPJ_DESATIVADO", "04"),
							/*" 88 CNPJ-CANCELADO                 VALUE 05. */
							new SelectorItemBasis("CNPJ_CANCELADO", "05")
                }
            };

            /*"    05  W-TRATA-CLIENTE               PIC 9(002).*/

            public SelectorBasis W_TRATA_CLIENTE { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CLIENTE-INSERIDO               VALUE 01. */
							new SelectorItemBasis("CLIENTE_INSERIDO", "01"),
							/*" 88 CLIENTE-ERRO                   VALUE 02. */
							new SelectorItemBasis("CLIENTE_ERRO", "02")
                }
            };

            /*"    05 W-TEM-COBERTURA               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_COBERTURA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 COBERTURA-NAO-CADASTRADA        VALUE 1. */
							new SelectorItemBasis("COBERTURA_NAO_CADASTRADA", "1"),
							/*" 88 COBERTURA-DUPLICADA             VALUE 2. */
							new SelectorItemBasis("COBERTURA_DUPLICADA", "2")
                }
            };

            /*"    05 W-TEM-BILHETE                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_BILHETE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 BILHETE-CADASTRADO              VALUE 1. */
							new SelectorItemBasis("BILHETE_CADASTRADO", "1")
                }
            };

            /*"    05 W-ATUALIZA                    PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_ATUALIZA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ATUALIZA-PROPOSTA               VALUE 1. */
							new SelectorItemBasis("ATUALIZA_PROPOSTA", "1")
                }
            };

            /*"    05 W-TIPO-PRODUTO                PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TIPO_PRODUTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROD-CAIXA-FACIL                VALUE 1. */
							new SelectorItemBasis("PROD_CAIXA_FACIL", "1"),
							/*" 88 PRODUTO-MICROSEGURO             VALUE 2. */
							new SelectorItemBasis("PRODUTO_MICROSEGURO", "2")
                }
            };

            /*"    05 WS-OPCAO-COBER-X              PIC  X(001).*/
            public StringBasis WS_OPCAO_COBER_X { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 WS-OPCAO-COBER-9              REDEFINES       WS-OPCAO-COBER-X              PIC  9(001).*/
            private _REDEF_IntBasis _ws_opcao_cober_9 { get; set; }
            public _REDEF_IntBasis WS_OPCAO_COBER_9
            {
                get { _ws_opcao_cober_9 = new _REDEF_IntBasis(new PIC("9", "001", "9(001).")); ; _.Move(WS_OPCAO_COBER_X, _ws_opcao_cober_9); VarBasis.RedefinePassValue(WS_OPCAO_COBER_X, _ws_opcao_cober_9, WS_OPCAO_COBER_X); _ws_opcao_cober_9.ValueChanged += () => { _.Move(_ws_opcao_cober_9, WS_OPCAO_COBER_X); }; return _ws_opcao_cober_9; }
                set { VarBasis.RedefinePassValue(value, _ws_opcao_cober_9, WS_OPCAO_COBER_X); }
            }  //Redefines
            /*"    05 WS-VLPREMIOTOT-CCT            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VLPREMIOTOT_CCT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-JA-E-CLIENTE               PIC  9(001) VALUE 0.*/
            public IntBasis WS_JA_E_CLIENTE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-EOR                        PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO                   PIC  9(001) VALUE 0.*/
            public IntBasis WS_TEM_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-SICOB                  PIC  9(001) VALUE 0.*/
            public IntBasis WS_TEM_SICOB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 MUDA-SITUACAO                 PIC  X(001) VALUE ' '.*/
            public StringBasis MUDA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WS-FONTE                      PIC  9(005) VALUE 0.*/
            public IntBasis WS_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 WFIM-AGENCEF                  PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-CBO                      PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-FONTES                   PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 IND                           PIC  9(005) VALUE 0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 WS-IDADE-INICIAL              PIC  9(004) VALUE 0.*/
            public IntBasis WS_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 AC-L-MOVIMENTO                PIC  9(006) VALUE 0.*/
            public IntBasis AC_L_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-BILHETE                  PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_BILHETE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-COMPL-SICAQ              PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_COMPL_SICAQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 DATA-SQL1                     PIC  X(010).*/
            public StringBasis DATA_SQL1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 DATA-SQL  REDEFINES DATA-SQL1.*/
            private _REDEF_PF0602B_DATA_SQL _data_sql { get; set; }
            public _REDEF_PF0602B_DATA_SQL DATA_SQL
            {
                get { _data_sql = new _REDEF_PF0602B_DATA_SQL(); _.Move(DATA_SQL1, _data_sql); VarBasis.RedefinePassValue(DATA_SQL1, _data_sql, DATA_SQL1); _data_sql.ValueChanged += () => { _.Move(_data_sql, DATA_SQL1); }; return _data_sql; }
                set { VarBasis.RedefinePassValue(value, _data_sql, DATA_SQL1); }
            }  //Redefines
            public class _REDEF_PF0602B_DATA_SQL : VarBasis
            {
                /*"       10 ANO-SQL                    PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 MES-SQL                    PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 DIA-SQL                    PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 HORA-SQL1                     PIC  X(008).*/

                public _REDEF_PF0602B_DATA_SQL()
                {
                    ANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    MES_SQL.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis HORA_SQL1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 HORA-SQL  REDEFINES HORA-SQL1.*/
            private _REDEF_PF0602B_HORA_SQL _hora_sql { get; set; }
            public _REDEF_PF0602B_HORA_SQL HORA_SQL
            {
                get { _hora_sql = new _REDEF_PF0602B_HORA_SQL(); _.Move(HORA_SQL1, _hora_sql); VarBasis.RedefinePassValue(HORA_SQL1, _hora_sql, HORA_SQL1); _hora_sql.ValueChanged += () => { _.Move(_hora_sql, HORA_SQL1); }; return _hora_sql; }
                set { VarBasis.RedefinePassValue(value, _hora_sql, HORA_SQL1); }
            }  //Redefines
            public class _REDEF_PF0602B_HORA_SQL : VarBasis
            {
                /*"       10 HH-SQL                     PIC  9(002).*/
                public IntBasis HH_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 MM-SQL                     PIC  9(002).*/
                public IntBasis MM_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 SS-SQL                     PIC  9(002).*/
                public IntBasis SS_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-NOM-ORGAO-EXP               PIC X(030).*/

                public _REDEF_PF0602B_HORA_SQL()
                {
                    HH_SQL.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    MM_SQL.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    SS_SQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
            private _REDEF_PF0602B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_PF0602B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_PF0602B_FILLER_9(); _.Move(W_NOM_ORGAO_EXP, _filler_9); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_9, W_NOM_ORGAO_EXP); _filler_9.ValueChanged += () => { _.Move(_filler_9, W_NOM_ORGAO_EXP); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, W_NOM_ORGAO_EXP); }
            }  //Redefines
            public class _REDEF_PF0602B_FILLER_9 : VarBasis
            {
                /*"        07  W-ORGAO-EXPEDIDOR         PIC X(005).*/
                public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"        07  FILLER                    PIC X(025).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    05 WS-DTNASC.*/

                public _REDEF_PF0602B_FILLER_9()
                {
                    W_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                }

            }
            public PF0602B_WS_DTNASC WS_DTNASC { get; set; } = new PF0602B_WS_DTNASC();
            public class PF0602B_WS_DTNASC : VarBasis
            {
                /*"       10 WS-AA-DTNASC               PIC  9(004).*/
                public IntBasis WS_AA_DTNASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTNASC               PIC  9(002).*/
                public IntBasis WS_MM_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DD-DTNASC               PIC  9(002).*/
                public IntBasis WS_DD_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTPROP.*/
            }
            public PF0602B_WS_DTPROP WS_DTPROP { get; set; } = new PF0602B_WS_DTPROP();
            public class PF0602B_WS_DTPROP : VarBasis
            {
                /*"       10 WS-AA-DTPROP               PIC  9(004).*/
                public IntBasis WS_AA_DTPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTPROP               PIC  9(002).*/
                public IntBasis WS_MM_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DD-DTPROP               PIC  9(002).*/
                public IntBasis WS_DD_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTINIVIG                   PIC  9(008).*/
            }
            public IntBasis WS_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 WS-DTTERVIG                   PIC  9(008).*/
            public IntBasis WS_DTTERVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 DATA-DDMMAA                   PIC  9(008).*/
            public IntBasis DATA_DDMMAA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 DATA-DDMMAA-R REDEFINES DATA-DDMMAA.*/
            private _REDEF_PF0602B_DATA_DDMMAA_R _data_ddmmaa_r { get; set; }
            public _REDEF_PF0602B_DATA_DDMMAA_R DATA_DDMMAA_R
            {
                get { _data_ddmmaa_r = new _REDEF_PF0602B_DATA_DDMMAA_R(); _.Move(DATA_DDMMAA, _data_ddmmaa_r); VarBasis.RedefinePassValue(DATA_DDMMAA, _data_ddmmaa_r, DATA_DDMMAA); _data_ddmmaa_r.ValueChanged += () => { _.Move(_data_ddmmaa_r, DATA_DDMMAA); }; return _data_ddmmaa_r; }
                set { VarBasis.RedefinePassValue(value, _data_ddmmaa_r, DATA_DDMMAA); }
            }  //Redefines
            public class _REDEF_PF0602B_DATA_DDMMAA_R : VarBasis
            {
                /*"       10 DIA-DDMMAA                 PIC  9(002).*/
                public IntBasis DIA_DDMMAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 MES-DDMMAA                 PIC  9(002).*/
                public IntBasis MES_DDMMAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 ANO-DDMMAA                 PIC  9(004).*/
                public IntBasis ANO_DDMMAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05 WS-VLCONJUGE                  PIC  9(013)V99.*/

                public _REDEF_PF0602B_DATA_DDMMAA_R()
                {
                    DIA_DDMMAA.ValueChanged += OnValueChanged;
                    MES_DDMMAA.ValueChanged += OnValueChanged;
                    ANO_DDMMAA.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WS_VLCONJUGE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"01  TAB-FILIAIS.*/
        }
        public PF0602B_TAB_FILIAIS TAB_FILIAIS { get; set; } = new PF0602B_TAB_FILIAIS();
        public class PF0602B_TAB_FILIAIS : VarBasis
        {
            /*"    05      TAB-FILIAL.*/
            public PF0602B_TAB_FILIAL TAB_FILIAL { get; set; } = new PF0602B_TAB_FILIAL();
            public class PF0602B_TAB_FILIAL : VarBasis
            {
                /*"      10    FILLER    OCCURS    9999   TIMES.*/
                public ListBasis<PF0602B_FILLER_15> FILLER_15 { get; set; } = new ListBasis<PF0602B_FILLER_15>(9999);
                public class PF0602B_FILLER_15 : VarBasis
                {
                    /*"        15  TAB-AGENCIA              PIC  9(4).*/
                    public IntBasis TAB_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"        15  TAB-FONTE                PIC  9(4).*/
                    public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"01  TAB-CBO1.*/
                }
            }
        }
        public PF0602B_TAB_CBO1 TAB_CBO1 { get; set; } = new PF0602B_TAB_CBO1();
        public class PF0602B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public PF0602B_TAB_CBO TAB_CBO { get; set; } = new PF0602B_TAB_CBO();
            public class PF0602B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<PF0602B_FILLER_16> FILLER_16 { get; set; } = new ListBasis<PF0602B_FILLER_16>(999);
                public class PF0602B_FILLER_16 : VarBasis
                {
                    /*"        15  TAB-COD-CBO              PIC  9(4).*/
                    public IntBasis TAB_COD_CBO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"        15  TAB-DESCR-CBO            PIC  X(5).*/
                    public StringBasis TAB_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"01         WS-GECLIMOV.*/
                }
            }
        }
        public PF0602B_WS_GECLIMOV WS_GECLIMOV { get; set; } = new PF0602B_WS_GECLIMOV();
        public class PF0602B_WS_GECLIMOV : VarBasis
        {
            /*"  05       WWORK-COD-CLIENTE      PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-TIPO-MOVIMENTO   PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-DATA-ULT-MANUTEN PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WWORK-NOME-RAZAO       PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-TIPO-PESSOA      PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-IDE-SEXO         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-ESTADO-CIVIL     PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-OCORR-ENDERECO   PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-ENDERECO         PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-BAIRRO           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-CIDADE           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-SIGLA-UF         PIC  X(002)    VALUE  SPACES.*/
            public StringBasis WWORK_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05       WWORK-CEP              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-DDD              PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-TELEFONE         PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-FAX              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-CGCCPF           PIC S9(015)    VALUE +0 COMP-3*/
            public IntBasis WWORK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05       WWORK-DATA-NASCIMENTO  PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WS-EDIT.*/
            public PF0602B_WS_EDIT WS_EDIT { get; set; } = new PF0602B_WS_EDIT();
            public class PF0602B_WS_EDIT : VarBasis
            {
                /*"     10    WS-SMALLINT            PIC ZZ.ZZ9-    OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 5);
                /*"     10    WS-INTEGER             PIC Z.ZZZ.ZZZ.ZZ9-                                                OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"     10    WS-BIGINT              PIC 99999999999999                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"     10    WS-DECIMAL             PIC ZZZZZZZZZZZZZZ9,99                                                 OCCURS 5 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "15", "ZZZZZZZZZZZZZZ9V99"), 5);
                /*"  05       WTEM-GECLIMOV          PIC  X(001)    VALUE  SPACES.*/
            }
            public StringBasis WTEM_GECLIMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WTEM-CARTAO            PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_CARTAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  WSRC-INF-SICAQWEB.*/
        }
        public PF0602B_WSRC_INF_SICAQWEB WSRC_INF_SICAQWEB { get; set; } = new PF0602B_WSRC_INF_SICAQWEB();
        public class PF0602B_WSRC_INF_SICAQWEB : VarBasis
        {
            /*"    05  WSRC-COD-OPERADOR            PIC X(009).*/
            public StringBasis WSRC_COD_OPERADOR { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"    05  WSRC-NUM-CORRESPONDENTE      PIC 9(009).*/
            public IntBasis WSRC_NUM_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  WSRC-DATA-CONTRATACAO.*/
            public PF0602B_WSRC_DATA_CONTRATACAO WSRC_DATA_CONTRATACAO { get; set; } = new PF0602B_WSRC_DATA_CONTRATACAO();
            public class PF0602B_WSRC_DATA_CONTRATACAO : VarBasis
            {
                /*"        07  WSRC-DIA-CONTRATACAO     PIC 9(002).*/
                public IntBasis WSRC_DIA_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WSRC-MES-CONTRATACAO     PIC 9(002).*/
                public IntBasis WSRC_MES_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WSRC-ANO-CONTRATACAO     PIC 9(004).*/
                public IntBasis WSRC_ANO_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  WSRC-HORA-CONTRATACAO.*/
            }
            public PF0602B_WSRC_HORA_CONTRATACAO WSRC_HORA_CONTRATACAO { get; set; } = new PF0602B_WSRC_HORA_CONTRATACAO();
            public class PF0602B_WSRC_HORA_CONTRATACAO : VarBasis
            {
                /*"        07  WSRC-HH-CONTRATACAO      PIC 9(002).*/
                public IntBasis WSRC_HH_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WSRC-MM-CONTRATACAO      PIC 9(002).*/
                public IntBasis WSRC_MM_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WSRC-SS-CONTRATACAO      PIC 9(002).*/
                public IntBasis WSRC_SS_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WSRC-NRO-PROPOSTA-SICAQ      PIC 9(010).*/
            }
            public IntBasis WSRC_NRO_PROPOSTA_SICAQ { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05  WSRC-TIPO-CORRESPONDENTE     PIC 9(002).*/
            public IntBasis WSRC_TIPO_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  WSRC-ORIGEM-PROPOSTA         PIC X(005).*/
            public StringBasis WSRC_ORIGEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"    05  FILLER                       PIC X(206).*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "206", "X(206)."), @"");
            /*"01  AREA-ABEND.*/
        }
        public PF0602B_AREA_ABEND AREA_ABEND { get; set; } = new PF0602B_AREA_ABEND();
        public class PF0602B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public PF0602B_WABEND WABEND { get; set; } = new PF0602B_WABEND();
            public class PF0602B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0602B  '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0602B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0602B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0602B_LOCALIZA_ABEND_1();
            public class PF0602B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0602B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0602B_LOCALIZA_ABEND_2();
            public class PF0602B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LBFPF160 LBFPF160 { get; set; } = new Copies.LBFPF160();
        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Copies.BIEMPCOM BIEMPCOM { get; set; } = new Copies.BIEMPCOM();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.BILHECOB BILHECOB { get; set; } = new Dclgens.BILHECOB();
        public Dclgens.BILERROS BILERROS { get; set; } = new Dclgens.BILERROS();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.ESTIPULA ESTIPULA { get; set; } = new Dclgens.ESTIPULA();
        public Dclgens.ERPROPAZ ERPROPAZ { get; set; } = new Dclgens.ERPROPAZ();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.FUNCICEF FUNCICEF { get; set; } = new Dclgens.FUNCICEF();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public Dclgens.PLVAVGAP PLVAVGAP { get; set; } = new Dclgens.PLVAVGAP();
        public Dclgens.PRODVG PRODVG { get; set; } = new Dclgens.PRODVG();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.PROFIDCO PROFIDCO { get; set; } = new Dclgens.PROFIDCO();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPSSBI PROPSSBI { get; set; } = new Dclgens.PROPSSBI();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.OPPAGVA OPPAGVA { get; set; } = new Dclgens.OPPAGVA();
        public Dclgens.PROPESTI PROPESTI { get; set; } = new Dclgens.PROPESTI();
        public Dclgens.NUMOUTRO NUMOUTRO { get; set; } = new Dclgens.NUMOUTRO();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public Dclgens.VG084 VG084 { get; set; } = new Dclgens.VG084();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.GE085 GE085 { get; set; } = new Dclgens.GE085();
        public Dclgens.BI004 BI004 { get; set; } = new Dclgens.BI004();
        public Dclgens.VG092 VG092 { get; set; } = new Dclgens.VG092();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public PF0602B_CPROPOSTA CPROPOSTA { get; set; } = new PF0602B_CPROPOSTA();
        public PF0602B_CPESENDER CPESENDER { get; set; } = new PF0602B_CPESENDER();
        public PF0602B_CPESENDERR CPESENDERR { get; set; } = new PF0602B_CPESENDERR();
        public PF0602B_CFONE CFONE { get; set; } = new PF0602B_CFONE();
        public PF0602B_CCLIENTES CCLIENTES { get; set; } = new PF0602B_CCLIENTES();
        public PF0602B_C01_AGENCEF C01_AGENCEF { get; set; } = new PF0602B_C01_AGENCEF();
        public PF0602B_CCBO CCBO { get; set; } = new PF0602B_CCBO();
        public PF0602B_C01_GECLIMOV C01_GECLIMOV { get; set; } = new PF0602B_C01_GECLIMOV();
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
            /*" -888- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -891- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -894- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -901- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -902- DISPLAY '*               PROGRAMA PF0602B               *' . */
            _.Display($"*               PROGRAMA PF0602B               *");

            /*" -903- DISPLAY '*       CRITICA PROPOSTAS BILHETES AP/RD       *' . */
            _.Display($"*       CRITICA PROPOSTAS BILHETES AP/RD       *");

            /*" -904- DISPLAY '*              E GRAVA NA BILHETE              *' . */
            _.Display($"*              E GRAVA NA BILHETE              *");

            /*" -905- DISPLAY '*         VERSAO: 57 - DEMANDA 592.593         *' . */
            _.Display($"*         VERSAO: 57 - DEMANDA 592.593         *");

            /*" -907- DISPLAY '*         COMPILACAO: ' FUNCTION WHEN-COMPILED '  *' . */

            $"*         COMPILACAO: FUNCTION{_.WhenCompiled()}  *"
            .Display();

            /*" -908- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -909- DISPLAY ' ' */
            _.Display($" ");

            /*" -918- DISPLAY '*  PF0602B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0602B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -920- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -921- MOVE 'PF0602B' TO LK-GEJVW002-NOM-PROG-ORIGEM */
            _.Move("PF0602B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -922- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -922- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WS_JV1_PROGRAMA);

            /*" -923- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -924- IF LK-GEJVWCNT-IND-ERRO NOT = 0 */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 0)
            {

                /*" -925- DISPLAY 'IND ERRO    = ' LK-GEJVWCNT-IND-ERRO */
                _.Display($"IND ERRO    = {GEJVWCNT.LK_GEJVWCNT_IND_ERRO}");

                /*" -926- DISPLAY 'MENSAGEM    = ' LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM    = {GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO}");

                /*" -927- DISPLAY 'TABELA      = ' LK-GEJVWCNT-NOME-TABELA */
                _.Display($"TABELA      = {GEJVWCNT.LK_GEJVWCNT_NOME_TABELA}");

                /*" -928- DISPLAY 'SQLCODE     = ' LK-GEJVWCNT-SQLCODE */
                _.Display($"SQLCODE     = {GEJVWCNT.LK_GEJVWCNT_SQLCODE}");

                /*" -929- MOVE LK-GEJVWCNT-SQLCODE TO WSQLCODE */
                _.Move(GEJVWCNT.LK_GEJVWCNT_SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

                /*" -930- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -936- END-IF */
            }


            /*" -937- PERFORM R0900-00-DECLARE-PROPOSTA. */

            R0900_00_DECLARE_PROPOSTA_SECTION();

            /*" -939- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

            /*" -940- IF WS-EOR = 1 */

            if (WORK_AREA.WS_EOR == 1)
            {

                /*" -941- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -942- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -943- DISPLAY '*           PF0602B - TERMINO NORMAL           *' */
                _.Display($"*           PF0602B - TERMINO NORMAL           *");

                /*" -944- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -945- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -951- GO TO R0000-00-FINALIZA. */

                R0000_00_FINALIZA(); //GOTO
                return;
            }


            /*" -954- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WS-EOR = 1. */

            while (!(WORK_AREA.WS_EOR == 1))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -954- PERFORM R9100-00-UPDATE-NUM-OUTROS. */

            R9100_00_UPDATE_NUM_OUTROS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_00_FINALIZA */

            R0000_00_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-FINALIZA */
        private void R0000_00_FINALIZA(bool isPerform = false)
        {
            /*" -958- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -961- DISPLAY 'PROCESSAMENTO COM COMMIT ' */
            _.Display($"PROCESSAMENTO COM COMMIT ");

            /*" -962- DISPLAY '   ' */
            _.Display($"   ");

            /*" -963- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -965- DISPLAY '* LIDOS PROPOSTA-FIDELIZ...... ' AC-L-MOVIMENTO */
            _.Display($"* LIDOS PROPOSTA-FIDELIZ...... {WORK_AREA.AC_L_MOVIMENTO}");

            /*" -967- DISPLAY '* GRAVADOS BILHETE............ ' AC-I-BILHETE */
            _.Display($"* GRAVADOS BILHETE............ {WORK_AREA.AC_I_BILHETE}");

            /*" -968- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -970- DISPLAY '* QUANT. RISCO CRITICO........ ' WS-QT-RISCO-CRITICO */
            _.Display($"* QUANT. RISCO CRITICO........ {WS_QT_RISCO_CRITICO}");

            /*" -972- DISPLAY '* QUANT. BIL. ANALISE RISCO... ' WS-QT-EM-CRITICA */
            _.Display($"* QUANT. BIL. ANALISE RISCO... {WS_QT_EM_CRITICA}");

            /*" -974- DISPLAY '* QUANT. BIL. COM AVAL. RISCO. ' WS-QT-EMISSAO-C-RISCO */
            _.Display($"* QUANT. BIL. COM AVAL. RISCO. {WS_QT_EMISSAO_C_RISCO}");

            /*" -976- DISPLAY '* QUANT. BIL. SEM AVAL. RISCO. ' WS-QT-EMISSAO-S-RISCO */
            _.Display($"* QUANT. BIL. SEM AVAL. RISCO. {WS_QT_EMISSAO_S_RISCO}");

            /*" -978- DISPLAY '* QUANT. LIBERADA EMISSAO..... ' WS-QT-LIBERADO-EMISSAO */
            _.Display($"* QUANT. LIBERADA EMISSAO..... {WS_QT_LIBERADO_EMISSAO}");

            /*" -979- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -980- DISPLAY '* GRAVADOS COMPL-SICAQWEB..... ' AC-I-COMPL-SICAQ */
            _.Display($"* GRAVADOS COMPL-SICAQWEB..... {WORK_AREA.AC_I_COMPL_SICAQ}");

            /*" -981- DISPLAY '   ' */
            _.Display($"   ");

            /*" -982- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -983- DISPLAY '*                                                 *' */
            _.Display($"*                                                 *");

            /*" -984- DISPLAY '*             PF0602B - TERMINO NORMAL            *' */
            _.Display($"*             PF0602B - TERMINO NORMAL            *");

            /*" -985- DISPLAY '*                                                 *' */
            _.Display($"*                                                 *");

            /*" -987- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -988- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -988- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -993- MOVE '0100-00-INICIALIZA ' TO PARAGRAFO. */
            _.Move("0100-00-INICIALIZA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -994- MOVE 'SELECT SISTEMAS    ' TO COMANDO. */
            _.Move("SELECT SISTEMAS    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -996- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1002- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -1005- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1006- DISPLAY 'PF0602B - PROBLEMAS NO ACESSO  A SISTEMAS ' */
                _.Display($"PF0602B - PROBLEMAS NO ACESSO  A SISTEMAS ");

                /*" -1008- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1010- MOVE 'SELECT NUMERO_OUTROS          ' TO COMANDO */
            _.Move("SELECT NUMERO_OUTROS          ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1015- PERFORM R0100_00_INICIALIZA_DB_SELECT_2 */

            R0100_00_INICIALIZA_DB_SELECT_2();

            /*" -1018- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1019- DISPLAY 'PF0602B - PROBLEMAS NO ACESSO  A NUMERO OUTROS' */
                _.Display($"PF0602B - PROBLEMAS NO ACESSO  A NUMERO OUTROS");

                /*" -1020- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1022- DISPLAY 'SEL NUM CLIENTE: ' NUM-CLIENTE OF DCLNUMERO-OUTROS */
            _.Display($"SEL NUM CLIENTE: {NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE}");

            /*" -1024- MOVE ZEROS TO TAB-FILIAIS. */
            _.Move(0, TAB_FILIAIS);

            /*" -1026- PERFORM R6000-00-DECLARE-AGENCEF. */

            R6000_00_DECLARE_AGENCEF_SECTION();

            /*" -1028- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

            /*" -1029- IF WFIM-AGENCEF NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_AGENCEF.IsEmpty())
            {

                /*" -1030- DISPLAY '0000 - PROBLEMA NO FETCH DA AGENCIACEF' */
                _.Display($"0000 - PROBLEMA NO FETCH DA AGENCIACEF");

                /*" -1032- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1035- PERFORM R6020-00-CARREGA-FILIAL UNTIL WFIM-AGENCEF EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_AGENCEF == "S"))
            {

                R6020_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1037- MOVE ZEROS TO TAB-CBO1. */
            _.Move(0, TAB_CBO1);

            /*" -1039- PERFORM R6100-00-DECLARE-CBO. */

            R6100_00_DECLARE_CBO_SECTION();

            /*" -1041- PERFORM R6110-00-FETCH-CBO. */

            R6110_00_FETCH_CBO_SECTION();

            /*" -1042- IF WFIM-CBO NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_CBO.IsEmpty())
            {

                /*" -1043- DISPLAY 'PF0602B - 0100 - PROBLEMA NO FETCH DA CBO  ' */
                _.Display($"PF0602B - 0100 - PROBLEMA NO FETCH DA CBO  ");

                /*" -1045- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1046- PERFORM R6120-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_CBO == "S"))
            {

                R6120_00_CARREGA_CBO_SECTION();
            }

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-1 */
        public void R0100_00_INICIALIZA_DB_SELECT_1()
        {
            /*" -1002- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'PF' WITH UR END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_1_Query1 = new R0100_00_INICIALIZA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_1_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-2 */
        public void R0100_00_INICIALIZA_DB_SELECT_2()
        {
            /*" -1015- EXEC SQL SELECT NUM_CLIENTE INTO :DCLNUMERO-OUTROS.NUM-CLIENTE FROM SEGUROS.NUMERO_OUTROS WITH UR END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_2_Query1 = new R0100_00_INICIALIZA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_2_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_CLIENTE, NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-SECTION */
        private void R0900_00_DECLARE_PROPOSTA_SECTION()
        {
            /*" -1054- MOVE '0900-00-DECLARE-PROPOSTA           ' TO PARAGRAFO */
            _.Move("0900-00-DECLARE-PROPOSTA           ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1055- MOVE 'DECLARE CPROPOSTA                  ' TO COMANDO. */
            _.Move("DECLARE CPROPOSTA                  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1057- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1121- PERFORM R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1();

            /*" -1124- MOVE 'OPEN CPROPOSTA                     ' TO COMANDO. */
            _.Move("OPEN CPROPOSTA                     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1124- PERFORM R0900_00_DECLARE_PROPOSTA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOSTA_DB_OPEN_1();

            /*" -1127- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1128- DISPLAY 'PF0602B - ERRO OPEN CPROPOSTA  ' */
                _.Display($"PF0602B - ERRO OPEN CPROPOSTA  ");

                /*" -1128- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1()
        {
            /*" -1121- EXEC SQL DECLARE CPROPOSTA CURSOR FOR SELECT B.RENOVACAO_AUTOM, C.NUM_PROPOSTA_SIVPF, C.NUM_IDENTIFICACAO , C.COD_PESSOA , C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.OPCAO_COBER , C.COD_PLANO , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM FROM SEGUROS.PROP_SASSE_BILHETE B, SEGUROS.PROPOSTA_FIDELIZ C WHERE B.DATA_INCLUSAO IS NULL AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA IN ( 'ENV' , 'POB' , 'NPG' ) AND C.COD_PRODUTO_SIVPF <> 10 AND C.COD_PRODUTO_SIVPF <> 56 AND C.ORIGEM_PROPOSTA NOT BETWEEN 1001 AND 1099 ORDER BY C.NUM_PROPOSTA_SIVPF WITH UR END-EXEC. */
            CPROPOSTA = new PF0602B_CPROPOSTA(false);
            string GetQuery_CPROPOSTA()
            {
                var query = @$"SELECT B.RENOVACAO_AUTOM
							, 
							C.NUM_PROPOSTA_SIVPF
							, 
							C.NUM_IDENTIFICACAO
							, 
							C.COD_PESSOA
							, 
							C.NUM_SICOB
							, 
							C.DATA_PROPOSTA
							, 
							C.COD_PRODUTO_SIVPF
							, 
							C.COD_EMPRESA_SIVPF
							, 
							C.AGECOBR
							, 
							C.DIA_DEBITO
							, 
							C.OPCAOPAG
							, 
							C.AGECTADEB
							, 
							C.OPRCTADEB
							, 
							C.NUMCTADEB
							, 
							C.DIGCTADEB
							, 
							C.PERC_DESCONTO
							, 
							C.NRMATRVEN
							, 
							C.AGECTAVEN
							, 
							C.OPRCTAVEN
							, 
							C.NUMCTAVEN
							, 
							C.DIGCTAVEN
							, 
							C.CGC_CONVENENTE
							, 
							C.NOME_CONVENENTE
							, 
							C.NRMATRCON
							, 
							C.DTQITBCO
							, 
							C.DTQITBCO
							, 
							C.VAL_PAGO
							, 
							C.AGEPGTO
							, 
							C.VAL_TARIFA
							, 
							C.VAL_IOF
							, 
							C.DATA_CREDITO
							, 
							C.VAL_COMISSAO
							, 
							C.SIT_PROPOSTA
							, 
							C.COD_USUARIO
							, 
							C.CANAL_PROPOSTA
							, 
							C.NSAS_SIVPF
							, 
							C.ORIGEM_PROPOSTA
							, 
							C.TIMESTAMP
							, 
							C.NSL
							, 
							C.NSAC_SIVPF
							, 
							C.NOME_CONJUGE
							, 
							C.DATA_NASC_CONJUGE
							, 
							C.PROFISSAO_CONJUGE
							, 
							C.OPCAO_COBER
							, 
							C.COD_PLANO
							, 
							C.FAIXA_RENDA_IND
							, 
							C.FAIXA_RENDA_FAM 
							FROM 
							SEGUROS.PROP_SASSE_BILHETE B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE B.DATA_INCLUSAO IS NULL 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA IN ( 'ENV'
							, 'POB'
							, 'NPG' ) 
							AND C.COD_PRODUTO_SIVPF <> 10 
							AND C.COD_PRODUTO_SIVPF <> 56 
							AND C.ORIGEM_PROPOSTA NOT BETWEEN 
							1001 AND 1099 
							ORDER BY C.NUM_PROPOSTA_SIVPF";

                return query;
            }
            CPROPOSTA.GetQueryEvent += GetQuery_CPROPOSTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_OPEN_1()
        {
            /*" -1124- EXEC SQL OPEN CPROPOSTA END-EXEC. */

            CPROPOSTA.Open();

        }

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-DB-DECLARE-1 */
        public void R2220_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1()
        {
            /*" -2132- EXEC SQL DECLARE CPESENDER CURSOR FOR SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.COD-PESSOA AND TIPO_ENDER = 2 ORDER BY OCORR_ENDERECO DESC WITH UR END-EXEC. */
            CPESENDER = new PF0602B_CPESENDER(true);
            string GetQuery_CPESENDER()
            {
                var query = @$"SELECT OCORR_ENDERECO
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
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = '{PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA}' 
							AND TIPO_ENDER = 2 
							ORDER BY OCORR_ENDERECO DESC";

                return query;
            }
            CPESENDER.GetQueryEvent += GetQuery_CPESENDER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-SECTION */
        private void R0910_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -1139- MOVE '0910-00-FETCH-PROPOSTA      ' TO PARAGRAFO. */
            _.Move("0910-00-FETCH-PROPOSTA      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1140- MOVE 'FETCH CPROPOSTA             ' TO COMANDO. */
            _.Move("FETCH CPROPOSTA             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1142- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1196- PERFORM R0910_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -1200- IF VIND-FAIXA-RENDA-IND LESS 0 */

            if (VIND_FAIXA_RENDA_IND < 0)
            {

                /*" -1201- MOVE ZEROS TO FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ */
                _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND);

                /*" -1202- END-IF */
            }


            /*" -1203- IF FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ NOT NUMERIC */

            if (!PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND.IsNumeric())
            {

                /*" -1204- MOVE ZEROS TO FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ */
                _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND);

                /*" -1205- END-IF */
            }


            /*" -1206- IF VIND-FAIXA-RENDA-FAM LESS 0 */

            if (VIND_FAIXA_RENDA_FAM < 0)
            {

                /*" -1207- MOVE ZEROS TO FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ */
                _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM);

                /*" -1208- END-IF */
            }


            /*" -1209- IF FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ NOT NUMERIC */

            if (!PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM.IsNumeric())
            {

                /*" -1210- MOVE ZEROS TO FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ */
                _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM);

                /*" -1212- END-IF */
            }


            /*" -1213- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1213- PERFORM R0910_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0910_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -1215- MOVE 1 TO WS-EOR */
                _.Move(1, WORK_AREA.WS_EOR);

                /*" -1216- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -1217- ELSE */
            }
            else
            {


                /*" -1219- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
                {

                    /*" -1221- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1223- ADD 1 TO AC-L-MOVIMENTO. */
            WORK_AREA.AC_L_MOVIMENTO.Value = WORK_AREA.AC_L_MOVIMENTO + 1;

            /*" -1224- INITIALIZE WORK-TAB-ERROS-CERT */
            _.Initialize(
                WORK_TAB_ERROS_CERT
            );

            /*" -1225- MOVE ZEROS TO WS-I-ERRO */
            _.Move(0, WS_I_ERRO);

            /*" -1225- . */

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -1196- EXEC SQL FETCH CPROPOSTA INTO :DCLPROP-SASSE-BILHETE.PROPSSBI-RENOVACAO-AUTOM , :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF , :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO , :DCLPROPOSTA-FIDELIZ.COD-PESSOA , :DCLPROPOSTA-FIDELIZ.NUM-SICOB , :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA , :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF , :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF , :DCLPROPOSTA-FIDELIZ.AGECOBR , :DCLPROPOSTA-FIDELIZ.DIA-DEBITO , :DCLPROPOSTA-FIDELIZ.OPCAOPAG , :DCLPROPOSTA-FIDELIZ.AGECTADEB , :DCLPROPOSTA-FIDELIZ.OPRCTADEB , :DCLPROPOSTA-FIDELIZ.NUMCTADEB , :DCLPROPOSTA-FIDELIZ.DIGCTADEB , :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO , :DCLPROPOSTA-FIDELIZ.NRMATRVEN , :DCLPROPOSTA-FIDELIZ.AGECTAVEN , :DCLPROPOSTA-FIDELIZ.OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE , :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE , :DCLPROPOSTA-FIDELIZ.NRMATRCON , :DCLPROPOSTA-FIDELIZ.DTQITBCO , :WHOST-DTPROXVEN , :DCLPROPOSTA-FIDELIZ.VAL-PAGO , :DCLPROPOSTA-FIDELIZ.AGEPGTO , :DCLPROPOSTA-FIDELIZ.VAL-TARIFA , :DCLPROPOSTA-FIDELIZ.VAL-IOF , :DCLPROPOSTA-FIDELIZ.DATA-CREDITO , :DCLPROPOSTA-FIDELIZ.VAL-COMISSAO , :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA , :DCLPROPOSTA-FIDELIZ.COD-USUARIO , :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA , :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF , :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA , :DCLPROPOSTA-FIDELIZ.TIMESTAMP , :DCLPROPOSTA-FIDELIZ.NSL , :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF , :DCLPROPOSTA-FIDELIZ.NOME-CONJUGE :VIND-NOME-CONJUGE , :DCLPROPOSTA-FIDELIZ.DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE , :DCLPROPOSTA-FIDELIZ.OPCAO-COBER , :DCLPROPOSTA-FIDELIZ.COD-PLANO , :DCLPROPOSTA-FIDELIZ.FAIXA-RENDA-IND :VIND-FAIXA-RENDA-IND , :DCLPROPOSTA-FIDELIZ.FAIXA-RENDA-FAM :VIND-FAIXA-RENDA-FAM END-EXEC. */

            if (CPROPOSTA.Fetch())
            {
                _.Move(CPROPOSTA.DCLPROP_SASSE_BILHETE_PROPSSBI_RENOVACAO_AUTOM, PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_RENOVACAO_AUTOM);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_COD_PESSOA, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_AGECOBR, PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_DIA_DEBITO, PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_OPCAOPAG, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_AGECTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_OPRCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NUMCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_DIGCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PERC_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NRMATRVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_AGECTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_OPRCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NUMCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_DIGCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NRMATRCON, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_DTQITBCO, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);
                _.Move(CPROPOSTA.WHOST_DTPROXVEN, WHOST_DTPROXVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_VAL_IOF, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_DATA_CREDITO, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_COD_USUARIO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NSAS_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_TIMESTAMP, PROPFID.DCLPROPOSTA_FIDELIZ.TIMESTAMP);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NSL, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NSAC_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_NOME_CONJUGE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONJUGE);
                _.Move(CPROPOSTA.VIND_NOME_CONJUGE, VIND_NOME_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_DATA_NASC_CONJUGE, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_NASC_CONJUGE);
                _.Move(CPROPOSTA.VIND_DATA_NASC_CONJUGE, VIND_DATA_NASC_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROFISSAO_CONJUGE, PROPFID.DCLPROPOSTA_FIDELIZ.PROFISSAO_CONJUGE);
                _.Move(CPROPOSTA.VIND_PROFISSAO_CONJUGE, VIND_PROFISSAO_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_OPCAO_COBER, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAO_COBER);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_COD_PLANO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_IND, PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_IND);
                _.Move(CPROPOSTA.VIND_FAIXA_RENDA_IND, VIND_FAIXA_RENDA_IND);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_FAM, PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_FAM);
                _.Move(CPROPOSTA.VIND_FAIXA_RENDA_FAM, VIND_FAIXA_RENDA_FAM);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -1213- EXEC SQL CLOSE CPROPOSTA END-EXEC */

            CPROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1232- MOVE 'R1000-00-PROCESSA-REGISTRO ' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1233- MOVE 'PROCESSAR REGISTRO          ' TO COMANDO. */
            _.Move("PROCESSAR REGISTRO          ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1235- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1236- MOVE '#' TO N88-PRODUTO-MEI */
            _.Move("#", N88_PRODUTO_MEI);

            /*" -1239- MOVE ZEROS TO W-COD-CLIENTE-FIS W-COD-CLIENTE-JUR */
            _.Move(0, W_COD_CLIENTE_FIS, W_COD_CLIENTE_JUR);

            /*" -1242- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -1245- MOVE ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO W-ORIGEM-PROPOSTA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA, WORK_AREA.W_ORIGEM_PROPOSTA);

            /*" -1246- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1248- DISPLAY 'PROPOSTA A PROCESSAR >> ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
            _.Display($"PROPOSTA A PROCESSAR >> {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

            /*" -1249- DISPLAY 'W-CANAL-PROPOSTA  >> ' W-CANAL-PROPOSTA */
            _.Display($"W-CANAL-PROPOSTA  >> {WORK_AREA.CANAL.W_CANAL_PROPOSTA}");

            /*" -1251- DISPLAY 'W-ORIGEM-PROPOSTA >> ' W-ORIGEM-PROPOSTA */
            _.Display($"W-ORIGEM-PROPOSTA >> {WORK_AREA.W_ORIGEM_PROPOSTA}");

            /*" -1253- IF COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 8530 OR 8531 OR 8532 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.In("8530", "8531", "8532"))
            {

                /*" -1254- MOVE 'S' TO N88-PRODUTO-MEI */
                _.Move("S", N88_PRODUTO_MEI);

                /*" -1256- END-IF */
            }


            /*" -1258- PERFORM R1100-00-LER-BILHETE. */

            R1100_00_LER_BILHETE_SECTION();

            /*" -1259- IF BILHETE-CADASTRADO */

            if (WORK_AREA.W_TEM_BILHETE["BILHETE_CADASTRADO"])
            {

                /*" -1260- PERFORM R1150-ATUALIZA-ESTRUTURA-PF */

                R1150_ATUALIZA_ESTRUTURA_PF_SECTION();

                /*" -1264- GO TO R1000-88. */

                R1000_88(); //GOTO
                return;
            }


            /*" -1265- PERFORM R2200-00-SELECT-PESSOA. */

            R2200_00_SELECT_PESSOA_SECTION();

            /*" -1266- PERFORM R2210-00-SELECT-PESSOA-FISICA. */

            R2210_00_SELECT_PESSOA_FISICA_SECTION();

            /*" -1268- PERFORM R2220-00-OBTER-ENDERECO-CORRES. */

            R2220_00_OBTER_ENDERECO_CORRES_SECTION();

            /*" -1269- IF END-CORRES-N-CADASTRADO */

            if (WORK_AREA.W_ENDERECO["END_CORRES_N_CADASTRADO"])
            {

                /*" -1271- PERFORM R2225-00-OBTER-DEMAIS-ENDERECO */

                R2225_00_OBTER_DEMAIS_ENDERECO_SECTION();

                /*" -1274- IF DEMAIS-END-N-CADASTRADO */

                if (WORK_AREA.W_ENDERECO["DEMAIS_END_N_CADASTRADO"])
                {

                    /*" -1275- MOVE 11401 TO COD-ERRO OF DCLBILHETE-ERROS */
                    _.Move(11401, BILERROS.DCLBILHETE_ERROS.COD_ERRO);

                    /*" -1277- PERFORM R1900-00-GRAVA-TAB-ERRO. */

                    R1900_00_GRAVA_TAB_ERRO_SECTION();
                }

            }


            /*" -1279- PERFORM R2230-00-SELECT-PESSOA-FONE. */

            R2230_00_SELECT_PESSOA_FONE_SECTION();

            /*" -1282- MOVE ZEROS TO WS-TEM-ERRO, WS-TEM-SICOB. */
            _.Move(0, WORK_AREA.WS_TEM_ERRO, WORK_AREA.WS_TEM_SICOB);

            /*" -1284- MOVE 'S' TO MUDA-SITUACAO. */
            _.Move("S", WORK_AREA.MUDA_SITUACAO);

            /*" -1285- IF ORIGEM-LOTERICO OR ORIGEM-CX-AQUI-CCA */

            if (WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_LOTERICO"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_CX_AQUI_CCA"])
            {

                /*" -1286- MOVE '3' TO PROFIDCO-IND-TP-INFORMACAO */
                _.Move("3", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

                /*" -1287- PERFORM R2240-00-SELECT-PROPFIDC */

                R2240_00_SELECT_PROPFIDC_SECTION();

                /*" -1288- IF PROFIDCO-INFORMACAO-COMPL = SPACES */

                if (PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL.IsEmpty())
                {

                    /*" -1289- MOVE '1' TO PROFIDCO-IND-TP-INFORMACAO */
                    _.Move("1", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

                    /*" -1290- PERFORM R2240-00-SELECT-PROPFIDC */

                    R2240_00_SELECT_PROPFIDC_SECTION();

                    /*" -1291- END-IF */
                }


                /*" -1292- MOVE PROFIDCO-INFORMACAO-COMPL TO WSRC-INF-SICAQWEB */
                _.Move(PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL, WSRC_INF_SICAQWEB);

                /*" -1293- ELSE */
            }
            else
            {


                /*" -1294- MOVE '1' TO PROFIDCO-IND-TP-INFORMACAO */
                _.Move("1", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

                /*" -1295- PERFORM R2240-00-SELECT-PROPFIDC */

                R2240_00_SELECT_PROPFIDC_SECTION();

                /*" -1297- END-IF */
            }


            /*" -1302- PERFORM R2250-00-SELECT-PESSOA-EMAIL THRU R2250-99-SAIDA */

            R2250_00_SELECT_PESSOA_EMAIL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/


            /*" -1313- IF CPF OF DCLPESSOA-FISICA = 11111111111 OR 22222222222 OR 33333333333 OR 44444444444 OR 55555555555 OR 66666666666 OR 77777777777 OR 88888888888 OR 99999999999 */

            if (PESFIS.DCLPESSOA_FISICA.CPF.In("11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"))
            {

                /*" -1314- MOVE 10902 TO COD-ERRO OF DCLBILHETE-ERROS */
                _.Move(10902, BILERROS.DCLBILHETE_ERROS.COD_ERRO);

                /*" -1316- PERFORM R1900-00-GRAVA-TAB-ERRO. */

                R1900_00_GRAVA_TAB_ERRO_SECTION();
            }


            /*" -1329- IF CPF OF DCLPESSOA-FISICA = 000000000000000 OR 000000000000091 OR 000000000000101 OR 000000000000191 OR 000000000001910 OR 000000000019100 OR 000001910000000 OR 000009100000000 OR 000010000000000 OR 000011000000000 OR 000011111111111 OR 000017500000000 OR 000019100000000 OR 000020000000000 OR 000022222222222 OR 000030000000000 OR 000040000000000 OR 000050000000000 OR 000060000000000 OR 000070000000000 OR 000080000000000 OR 000090000000000 OR 000099000000000 OR 000099900000000 OR 000099990000000 OR 000099999000000 OR 000099999964001 OR 000099999999990 OR 000099999999999 OR 099999999999999 OR 000360306000104 OR 034020354000110 */

            if (PESFIS.DCLPESSOA_FISICA.CPF.In("000000000000000", "000000000000091", "000000000000101", "000000000000191", "000000000001910", "000000000019100", "000001910000000", "000009100000000", "000010000000000", "000011000000000", "000011111111111", "000017500000000", "000019100000000", "000020000000000", "000022222222222", "000030000000000", "000040000000000", "000050000000000", "000060000000000", "000070000000000", "000080000000000", "000090000000000", "000099000000000", "000099900000000", "000099990000000", "000099999000000", "000099999964001", "000099999999990", "000099999999999", "099999999999999", "000360306000104", "034020354000110"))
            {

                /*" -1330- MOVE 10902 TO COD-ERRO OF DCLBILHETE-ERROS */
                _.Move(10902, BILERROS.DCLBILHETE_ERROS.COD_ERRO);

                /*" -1337- PERFORM R1900-00-GRAVA-TAB-ERRO. */

                R1900_00_GRAVA_TAB_ERRO_SECTION();
            }


            /*" -1338- IF CANAL-ATM */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_ATM"])
            {

                /*" -1339- IF SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'NPG' */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA == "NPG")
                {

                    /*" -1340- MOVE 99 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(99, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1341- PERFORM R1900-00-GRAVA-TAB-ERRO */

                    R1900_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -1342- END-IF */
                }


                /*" -1401- END-IF */
            }


            /*" -1403- MOVE SPACES TO WHOST-PROFISSAO */
            _.Move("", WHOST_PROFISSAO);

            /*" -1405- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 09 OR (COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 29) */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 09 || (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 29))
            {

                /*" -1407- IF COD-CBO OF DCLPESSOA-FISICA EQUAL ZEROS NEXT SENTENCE */

                if (PESFIS.DCLPESSOA_FISICA.COD_CBO == 00)
                {

                    /*" -1408- ELSE */
                }
                else
                {


                    /*" -1411- MOVE TAB-DESCR-CBO-C (COD-CBO OF DCLPESSOA-FISICA) TO WHOST-PROFISSAO. */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_16[PESFIS.DCLPESSOA_FISICA.COD_CBO].TAB_DESCR_CBO_C, WHOST_PROFISSAO);
                }

            }


            /*" -1412- IF WHOST-PROFISSAO = SPACES OR 'OUTROS' */

            if (WHOST_PROFISSAO.In(string.Empty, "OUTROS"))
            {

                /*" -1414- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 09 OR (COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 29) */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 09 || (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 29))
                {

                    /*" -1419- PERFORM R5634-00-SELECT-SEGUROS-PF-CBO. */

                    R5634_00_SELECT_SEGUROS_PF_CBO_SECTION();
                }

            }


            /*" -1422- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO RCAPS-NUM-TITULO OF DCLRCAPS. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -1425- MOVE TAB-FONTE (AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE. */
            _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_15[PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR].TAB_FONTE, WHOST_FONTE);

            /*" -1427- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -1428- MOVE 5 TO WHOST-FONTE */
                _.Move(5, WHOST_FONTE);

                /*" -1430- END-IF */
            }


            /*" -1432- MOVE WHOST-FONTE TO RCAPS-COD-FONTE OF DCLRCAPS. */
            _.Move(WHOST_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);

            /*" -1436- IF CANAL-GITEL OR ORIGEM-MARSH OR CANAL-ATM OR PRODUTO-MEI NEXT SENTENCE */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_MARSH"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_ATM"] || N88_PRODUTO_MEI["PRODUTO_MEI"])
            {

                /*" -1437- ELSE */
            }
            else
            {


                /*" -1439- PERFORM R1500-00-SELECT-RCAPS */

                R1500_00_SELECT_RCAPS_SECTION();

                /*" -1440- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1442- PERFORM R1550-00-SELECT-RCAPS-SFONTE */

                    R1550_00_SELECT_RCAPS_SFONTE_SECTION();

                    /*" -1443- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1444- MOVE 1 TO WS-TEM-SICOB */
                        _.Move(1, WORK_AREA.WS_TEM_SICOB);

                        /*" -1446- MOVE 'N' TO MUDA-SITUACAO */
                        _.Move("N", WORK_AREA.MUDA_SITUACAO);

                        /*" -1447- MOVE 11802 TO COD-ERRO OF DCLBILHETE-ERROS */
                        _.Move(11802, BILERROS.DCLBILHETE_ERROS.COD_ERRO);

                        /*" -1448- PERFORM R1900-00-GRAVA-TAB-ERRO */

                        R1900_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -1449- END-IF */
                    }


                    /*" -1450- END-IF */
                }


                /*" -1452- END-IF. */
            }


            /*" -1462- IF CANAL-GITEL OR ORIGEM-MARSH OR CANAL-ATM */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_MARSH"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_ATM"])
            {

                /*" -1469- IF (ORIGEM-CX-EXECUTIVO AND (COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 3709 OR COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 3721)) OR ((ORIGEM-LOTERICO OR ORIGEM-SIVPFWEB-REMOTA OR ORIGEM-CX-AQUI-CCA) AND COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 3721) */

                if ((WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_CX_EXECUTIVO"] && (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO == 3709 || PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO == 3721)) || ((WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_LOTERICO"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_SIVPFWEB_REMOTA"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_CX_AQUI_CCA"]) && PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO == 3721))
                {

                    /*" -1470- CONTINUE */

                    /*" -1471- ELSE */
                }
                else
                {


                    /*" -1473- IF AGECTADEB OF DCLPROPOSTA-FIDELIZ = 0 */

                    if (PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB == 0)
                    {

                        /*" -1474- MOVE 12201 TO COD-ERRO OF DCLBILHETE-ERROS */
                        _.Move(12201, BILERROS.DCLBILHETE_ERROS.COD_ERRO);

                        /*" -1475- PERFORM R1900-00-GRAVA-TAB-ERRO */

                        R1900_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -1476- END-IF */
                    }


                    /*" -1477- IF OPRCTADEB OF DCLPROPOSTA-FIDELIZ = 0 */

                    if (PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB == 0)
                    {

                        /*" -1478- MOVE 2203 TO COD-ERRO OF DCLBILHETE-ERROS */
                        _.Move(2203, BILERROS.DCLBILHETE_ERROS.COD_ERRO);

                        /*" -1479- PERFORM R1900-00-GRAVA-TAB-ERRO */

                        R1900_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -1480- END-IF */
                    }


                    /*" -1481- IF NUMCTADEB OF DCLPROPOSTA-FIDELIZ = 0 */

                    if (PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB == 0)
                    {

                        /*" -1482- MOVE 2204 TO COD-ERRO OF DCLBILHETE-ERROS */
                        _.Move(2204, BILERROS.DCLBILHETE_ERROS.COD_ERRO);

                        /*" -1483- PERFORM R1900-00-GRAVA-TAB-ERRO */

                        R1900_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -1484- END-IF */
                    }


                    /*" -1485- END-IF */
                }


                /*" -1487- END-IF. */
            }


            /*" -1491- MOVE ZERO TO W-CONVENIO-CX-TR. */
            _.Move(0, WORK_AREA.W_CONVENIO_CX_TR);

            /*" -1493- PERFORM R2350-00-OBTER-COBERTURA */

            R2350_00_OBTER_COBERTURA_SECTION();

            /*" -1494- IF COBERTURA-NAO-CADASTRADA */

            if (WORK_AREA.W_TEM_COBERTURA["COBERTURA_NAO_CADASTRADA"])
            {

                /*" -1495- DISPLAY 'COBERTURA DUPLICADA - NAO E CORRETO' */
                _.Display($"COBERTURA DUPLICADA - NAO E CORRETO");

                /*" -1497- DISPLAY 'PF0602B - NUMERO DO BILHETE....... ' BILHETE-NUM-BILHETE OF DCLBILHETE */
                _.Display($"PF0602B - NUMERO DO BILHETE....... {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -1499- DISPLAY 'PF0602B - PLANO DO BILHETE........ ' COD-PLANO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"PF0602B - PLANO DO BILHETE........ {PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO}");

                /*" -1502- MOVE ZEROS TO BILHECOB-COD-OPCAO-PLANO OF DCLBILHETE-COBERTURA */
                _.Move(0, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO);

                /*" -1503- MOVE 11502 TO COD-ERRO OF DCLBILHETE-ERROS */
                _.Move(11502, BILERROS.DCLBILHETE_ERROS.COD_ERRO);

                /*" -1505- PERFORM R1900-00-GRAVA-TAB-ERRO. */

                R1900_00_GRAVA_TAB_ERRO_SECTION();
            }


            /*" -1506- IF COBERTURA-DUPLICADA */

            if (WORK_AREA.W_TEM_COBERTURA["COBERTURA_DUPLICADA"])
            {

                /*" -1507- DISPLAY 'COBERTURA DUPLICADA - NAO E CORRETO' */
                _.Display($"COBERTURA DUPLICADA - NAO E CORRETO");

                /*" -1509- DISPLAY 'PF0602B - NUMERO DO BILHETE....... ' BILHETE-NUM-BILHETE OF DCLBILHETE */
                _.Display($"PF0602B - NUMERO DO BILHETE....... {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -1511- DISPLAY 'PF0602B - PLANO DO BILHETE........ ' COD-PLANO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"PF0602B - PLANO DO BILHETE........ {PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO}");

                /*" -1514- MOVE ZEROS TO BILHECOB-COD-OPCAO-PLANO OF DCLBILHETE-COBERTURA */
                _.Move(0, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO);

                /*" -1515- MOVE 11802 TO COD-ERRO OF DCLBILHETE-ERROS */
                _.Move(11802, BILERROS.DCLBILHETE_ERROS.COD_ERRO);

                /*" -1516- PERFORM R1900-00-GRAVA-TAB-ERRO */

                R1900_00_GRAVA_TAB_ERRO_SECTION();

                /*" -1520- END-IF. */
            }


            /*" -1521- PERFORM R2300-00-TRATA-CLIENTES. */

            R2300_00_TRATA_CLIENTES_SECTION();

            /*" -1522- IF CLIENTE-ERRO */

            if (WORK_AREA.W_TRATA_CLIENTE["CLIENTE_ERRO"])
            {

                /*" -1524- GO TO R1000-88. */

                R1000_88(); //GOTO
                return;
            }


            /*" -1526- PERFORM R2400-00-TRATA-ENDERECOS. */

            R2400_00_TRATA_ENDERECOS_SECTION();

            /*" -1527- IF WWORK-TIPO-MOVIMENTO NOT EQUAL SPACES */

            if (!WS_GECLIMOV.WWORK_TIPO_MOVIMENTO.IsEmpty())
            {

                /*" -1528- PERFORM R9300-00-TRATA-MOVTO-CLIENTE */

                R9300_00_TRATA_MOVTO_CLIENTE_SECTION();

                /*" -1530- END-IF */
            }


            /*" -1531- IF EMAIL-CADASTRADO */

            if (WORK_AREA.W_PESSOA_EMAIL["EMAIL_CADASTRADO"])
            {

                /*" -1533- PERFORM R2600-00-TRATA-EMAIL THRU R2600-99-SAIDA */

                R2600_00_TRATA_EMAIL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/


                /*" -1537- END-IF */
            }


            /*" -1538- IF TEM-CONVENIO-CX-TRAB */

            if (WORK_AREA.W_CONVENIO_CX_TR["TEM_CONVENIO_CX_TRAB"])
            {

                /*" -1539- PERFORM R2500-00-INSERT-PROP-EST */

                R2500_00_INSERT_PROP_EST_SECTION();

                /*" -1541- END-IF */
            }


            /*" -1543- MOVE 'N' TO WS-TEM-ERRO-CRITICO */
            _.Move("N", WS_TEM_ERRO_CRITICO);

            /*" -1544- MOVE 1 TO WS-COD-CRITICA */
            _.Move(1, WS_COD_CRITICA);

            /*" -1546- PERFORM R8600-00-CONS-COD-CRITICA */

            R8600_00_CONS_COD_CRITICA_SECTION();

            /*" -1547- IF VG001-IND-EXISTE EQUAL 'N' */

            if (SPVG001V.VG001_IND_EXISTE == "N")
            {

                /*" -1548- PERFORM R8500-00-PROCURA-RISCO-PROP */

                R8500_00_PROCURA_RISCO_PROP_SECTION();

                /*" -1550- ELSE */
            }
            else
            {


                /*" -1551- IF LK-VG001-S-STA-CRITICA NOT EQUAL '6' */

                if (SPVG001W.LK_VG001_S_STA_CRITICA != "6")
                {

                    /*" -1554- DISPLAY 'BILHETE EM ANALISE DE CRITICA.......: ' NUM-SICOB OF DCLPROPOSTA-FIDELIZ ' >> ' LK-VG001-S-STA-CRITICA */

                    $"BILHETE EM ANALISE DE CRITICA.......: {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB} >> {SPVG001W.LK_VG001_S_STA_CRITICA}"
                    .Display();

                    /*" -1555- ADD 1 TO WS-QT-EM-CRITICA */
                    WS_QT_EM_CRITICA.Value = WS_QT_EM_CRITICA + 1;

                    /*" -1556- MOVE 1 TO WS-TEM-ERRO */
                    _.Move(1, WORK_AREA.WS_TEM_ERRO);

                    /*" -1557- MOVE 'S' TO WS-TEM-ERRO-CRITICO */
                    _.Move("S", WS_TEM_ERRO_CRITICO);

                    /*" -1558- ELSE */
                }
                else
                {


                    /*" -1559- DISPLAY 'LIBERADO PARA EMISSAO APOS ANALISE..: ' */
                    _.Display($"LIBERADO PARA EMISSAO APOS ANALISE..: ");

                    /*" -1560- ADD 1 TO WS-QT-LIBERADO-EMISSAO */
                    WS_QT_LIBERADO_EMISSAO.Value = WS_QT_LIBERADO_EMISSAO + 1;

                    /*" -1561- END-IF */
                }


                /*" -1563- END-IF. */
            }


            /*" -1564- PERFORM R3000-00-INSERT-BILHETE. */

            R3000_00_INSERT_BILHETE_SECTION();

            /*" -1565- PERFORM R1600-00-UPDATE-PROPFID. */

            R1600_00_UPDATE_PROPFID_SECTION();

            /*" -1567- PERFORM R9200-00-UPDATE-PROPSSBI. */

            R9200_00_UPDATE_PROPSSBI_SECTION();

            /*" -1568- IF PRODUTO-MEI */

            if (N88_PRODUTO_MEI["PRODUTO_MEI"])
            {

                /*" -1569- PERFORM R4000-00-TRATA-EMPRESA-MEI */

                R4000_00_TRATA_EMPRESA_MEI_SECTION();

                /*" -1572- END-IF */
            }


            /*" -1573- IF ORIGEM-LOTERICO OR ORIGEM-CX-AQUI-CCA */

            if (WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_LOTERICO"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_CX_AQUI_CCA"])
            {

                /*" -1575- PERFORM R3010-00-INSERT-COMPL_SICAQWEB THRU R3010-99-SAIDA */

                R3010_00_INSERT_COMPL_SICAQWEB_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/


                /*" -1577- END-IF */
            }


            /*" -1578- IF VG001-IND-EXISTE EQUAL 'N' */

            if (SPVG001V.VG001_IND_EXISTE == "N")
            {

                /*" -1579- PERFORM R8555-00-GRAVA-RISCO-MOTOR */

                R8555_00_GRAVA_RISCO_MOTOR_SECTION();

                /*" -1581- END-IF */
            }


            /*" -1582- IF WS-I-ERRO > ZEROS */

            if (WS_I_ERRO > 00)
            {

                /*" -1583- MOVE 'S' TO WS-FLAG-TEM-ERRO */
                _.Move("S", WS_FLAG_TEM_ERRO);

                /*" -1585- MOVE 1 TO WS-I-ERRO */
                _.Move(1, WS_I_ERRO);

                /*" -1587- PERFORM R1950-00-INSERT-BILHETE-ERROS UNTIL WS-FLAG-TEM-ERRO EQUAL 'N' */

                while (!(WS_FLAG_TEM_ERRO == "N"))
                {

                    R1950_00_INSERT_BILHETE_ERROS_SECTION();
                }

                /*" -1588- END-IF */
            }


            /*" -1588- . */

            /*" -0- FLUXCONTROL_PERFORM R1000_88 */

            R1000_88();

        }

        [StopWatch]
        /*" R1000-88 */
        private void R1000_88(bool isPerform = false)
        {
            /*" -1591- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LER-BILHETE-SECTION */
        private void R1100_00_LER_BILHETE_SECTION()
        {
            /*" -1599- MOVE '1100-00-LER-BILHETE' TO PARAGRAFO. */
            _.Move("1100-00-LER-BILHETE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1600- MOVE 'SELECT BILHETE     ' TO COMANDO. */
            _.Move("SELECT BILHETE     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1602- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1605- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO BILHETE-NUM-BILHETE OF DCLBILHETE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);

            /*" -1618- PERFORM R1100_00_LER_BILHETE_DB_SELECT_1 */

            R1100_00_LER_BILHETE_DB_SELECT_1();

            /*" -1621- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -1622- MOVE 1 TO W-TEM-BILHETE */
                _.Move(1, WORK_AREA.W_TEM_BILHETE);

                /*" -1623- ELSE */
            }
            else
            {


                /*" -1624- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1625- MOVE 0 TO W-TEM-BILHETE */
                    _.Move(0, WORK_AREA.W_TEM_BILHETE);

                    /*" -1626- ELSE */
                }
                else
                {


                    /*" -1627- DISPLAY 'PF0602B - PROBLEMAS SELECT BILHETE ' SQLCODE */
                    _.Display($"PF0602B - PROBLEMAS SELECT BILHETE {DB.SQLCODE}");

                    /*" -1629- DISPLAY 'PF0602B - NUMERO DO BILHETE....... ' BILHETE-NUM-BILHETE OF DCLBILHETE */
                    _.Display($"PF0602B - NUMERO DO BILHETE....... {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1629- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-LER-BILHETE-DB-SELECT-1 */
        public void R1100_00_LER_BILHETE_DB_SELECT_1()
        {
            /*" -1618- EXEC SQL SELECT DATA_QUITACAO , VAL_RCAP , DATA_MOVIMENTO, SITUACAO INTO :DCLBILHETE.BILHETE-DATA-QUITACAO , :DCLBILHETE.BILHETE-VAL-RCAP , :DCLBILHETE.BILHETE-DATA-MOVIMENTO, :DCLBILHETE.BILHETE-SITUACAO FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :DCLBILHETE.BILHETE-NUM-BILHETE AND SITUACAO <> 'R' WITH UR END-EXEC. */

            var r1100_00_LER_BILHETE_DB_SELECT_1_Query1 = new R1100_00_LER_BILHETE_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R1100_00_LER_BILHETE_DB_SELECT_1_Query1.Execute(r1100_00_LER_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(executed_1.BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(executed_1.BILHETE_DATA_MOVIMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO);
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-ATUALIZA-ESTRUTURA-PF-SECTION */
        private void R1150_ATUALIZA_ESTRUTURA_PF_SECTION()
        {
            /*" -1642- MOVE '1150-ATUALIZA-ESTRUTURA-PF   ' TO PARAGRAFO. */
            _.Move("1150-ATUALIZA-ESTRUTURA-PF   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1644- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1646- MOVE 1 TO W-ATUALIZA. */
            _.Move(1, WORK_AREA.W_ATUALIZA);

            /*" -1647- IF VAL-PAGO OF DCLPROPOSTA-FIDELIZ EQUAL ZEROS */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO == 00)
            {

                /*" -1650- MOVE BILHETE-VAL-RCAP OF DCLBILHETE TO VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);
            }


            /*" -1652- IF DTQITBCO OF DCLPROPOSTA-FIDELIZ EQUAL '0001-01-01' OR DTQITBCO OF DCLPROPOSTA-FIDELIZ EQUAL '1900-01-01' */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO == "0001-01-01" || PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO == "1900-01-01")
            {

                /*" -1655- MOVE BILHETE-DATA-QUITACAO OF DCLBILHETE TO DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);
            }


            /*" -1657- IF DATA-CREDITO OF DCLPROPOSTA-FIDELIZ EQUAL '0001-01-01' OR DATA-CREDITO OF DCLPROPOSTA-FIDELIZ EQUAL '1900-01-01' */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO == "0001-01-01" || PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO == "1900-01-01")
            {

                /*" -1660- MOVE BILHETE-DATA-MOVIMENTO OF DCLBILHETE TO DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);
            }


            /*" -1663- MOVE 'S' TO WHOST-SIT-ENVIO. */
            _.Move("S", WHOST_SIT_ENVIO);

            /*" -1664- IF BILHETE-SITUACAO OF DCLBILHETE EQUAL '1' */

            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "1")
            {

                /*" -1665- MOVE 'PEN' TO WHOST-SIT-PROPOSTA */
                _.Move("PEN", WHOST_SIT_PROPOSTA);

                /*" -1666- ELSE */
            }
            else
            {


                /*" -1667- IF BILHETE-SITUACAO OF DCLBILHETE EQUAL '2' OR '3' */

                if (BILHETE.DCLBILHETE.BILHETE_SITUACAO.In("2", "3"))
                {

                    /*" -1668- MOVE 'POB' TO WHOST-SIT-PROPOSTA */
                    _.Move("POB", WHOST_SIT_PROPOSTA);

                    /*" -1669- ELSE */
                }
                else
                {


                    /*" -1670- IF BILHETE-SITUACAO OF DCLBILHETE EQUAL '9' */

                    if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "9")
                    {

                        /*" -1671- MOVE 'EMT' TO WHOST-SIT-PROPOSTA */
                        _.Move("EMT", WHOST_SIT_PROPOSTA);

                        /*" -1672- ELSE */
                    }
                    else
                    {


                        /*" -1674- MOVE ZERO TO W-ATUALIZA. */
                        _.Move(0, WORK_AREA.W_ATUALIZA);
                    }

                }

            }


            /*" -1676- IF SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL WHOST-SIT-PROPOSTA */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA == WHOST_SIT_PROPOSTA)
            {

                /*" -1678- MOVE ZERO TO W-ATUALIZA. */
                _.Move(0, WORK_AREA.W_ATUALIZA);
            }


            /*" -1679- IF NOT ATUALIZA-PROPOSTA */

            if (!WORK_AREA.W_ATUALIZA["ATUALIZA_PROPOSTA"])
            {

                /*" -1681- GO TO R1150-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1683- MOVE 'UPDATE PROPOSTA_FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA_FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1692- PERFORM R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1 */

            R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1();

            /*" -1695- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1696- DISPLAY 'PF0602B - FIM ANORMAL' */
                _.Display($"PF0602B - FIM ANORMAL");

                /*" -1697- DISPLAY '          PROBLEMAS NO UPDATE DA PROPFID' */
                _.Display($"          PROBLEMAS NO UPDATE DA PROPFID");

                /*" -1699- DISPLAY '          NUMERO DA PROPOSTA............ ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO DA PROPOSTA............ {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -1701- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1703- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1705- MOVE 'UPDATE PROP_SASSE_BILHETE' TO COMANDO. */
            _.Move("UPDATE PROP_SASSE_BILHETE", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1711- PERFORM R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2 */

            R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2();

            /*" -1714- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1715- DISPLAY 'PF0602B - FIM ANORMAL' */
                _.Display($"PF0602B - FIM ANORMAL");

                /*" -1716- DISPLAY '          PROBLEMAS NO UPDATE PRO-SASSE-BILHETE' */
                _.Display($"          PROBLEMAS NO UPDATE PRO-SASSE-BILHETE");

                /*" -1718- DISPLAY '          NUMERO IDENTIFICACAO.......... ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO IDENTIFICACAO.......... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -1720- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1720- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1150-ATUALIZA-ESTRUTURA-PF-DB-UPDATE-1 */
        public void R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1()
        {
            /*" -1692- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROPOSTA, SITUACAO_ENVIO = :WHOST-SIT-ENVIO, DTQITBCO = :DCLPROPOSTA-FIDELIZ.DTQITBCO, VAL_PAGO = :DCLPROPOSTA-FIDELIZ.VAL-PAGO, DATA_CREDITO = :DCLPROPOSTA-FIDELIZ.DATA-CREDITO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1 = new R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1()
            {
                DATA_CREDITO = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO.ToString(),
                DTQITBCO = PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.ToString(),
                VAL_PAGO = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO.ToString(),
                WHOST_SIT_PROPOSTA = WHOST_SIT_PROPOSTA.ToString(),
                WHOST_SIT_ENVIO = WHOST_SIT_ENVIO.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1.Execute(r1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1150-ATUALIZA-ESTRUTURA-PF-DB-UPDATE-2 */
        public void R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2()
        {
            /*" -1711- EXEC SQL UPDATE SEGUROS.PROP_SASSE_BILHETE SET DATA_INCLUSAO = :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO WHERE NUM_IDENTIFICACAO = :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO END-EXEC. */

            var r1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2_Update1 = new R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                NUM_IDENTIFICACAO = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO.ToString(),
            };

            R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2_Update1.Execute(r1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1200-00-SELECT-ESTIPULANTE-SECTION */
        private void R1200_00_SELECT_ESTIPULANTE_SECTION()
        {
            /*" -1728- MOVE '1200-00-SELECT-ESTIPULANTE   ' TO PARAGRAFO. */
            _.Move("1200-00-SELECT-ESTIPULANTE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1729- MOVE 'SELECT MAX ESTIPULANTE       ' TO COMANDO. */
            _.Move("SELECT MAX ESTIPULANTE       ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1731- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1733- MOVE '0' TO ESTIPULA-COD-FROTA OF DCLESTIPULANTE. */
            _.Move("0", ESTIPULA.DCLESTIPULANTE.ESTIPULA_COD_FROTA);

            /*" -1742- PERFORM R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1 */

            R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1();

            /*" -1745- IF VIND-OCOR LESS ZEROS */

            if (VIND_OCOR < 00)
            {

                /*" -1746- MOVE 2 TO W-CNPJ-CONVENENTE */
                _.Move(2, WORK_AREA.W_CNPJ_CONVENENTE);

                /*" -1748- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1749- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1750- MOVE 1 TO W-CNPJ-CONVENENTE */
                _.Move(1, WORK_AREA.W_CNPJ_CONVENENTE);

                /*" -1751- GO TO R1200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;

                /*" -1752- ELSE */
            }
            else
            {


                /*" -1753- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1754- MOVE 2 TO W-CNPJ-CONVENENTE */
                    _.Move(2, WORK_AREA.W_CNPJ_CONVENENTE);

                    /*" -1755- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -1756- ELSE */
                }
                else
                {


                    /*" -1757- DISPLAY 'PF0602B - PROBLEMAS NO SELECT MAX ESTIPULANTE' */
                    _.Display($"PF0602B - PROBLEMAS NO SELECT MAX ESTIPULANTE");

                    /*" -1759- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1761- MOVE 'SELECT ESTIPULANTE           ' TO COMANDO. */
            _.Move("SELECT ESTIPULANTE           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1774- PERFORM R1200_00_SELECT_ESTIPULANTE_DB_SELECT_2 */

            R1200_00_SELECT_ESTIPULANTE_DB_SELECT_2();

            /*" -1777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1778- DISPLAY 'PROBLEMAS NO SELECT DA ESTIPULANTE' */
                _.Display($"PROBLEMAS NO SELECT DA ESTIPULANTE");

                /*" -1780- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1781- IF ESTIPULA-SITUACAO OF DCLESTIPULANTE EQUAL '0' */

            if (ESTIPULA.DCLESTIPULANTE.ESTIPULA_SITUACAO == "0")
            {

                /*" -1782- MOVE 3 TO W-CNPJ-CONVENENTE */
                _.Move(3, WORK_AREA.W_CNPJ_CONVENENTE);

                /*" -1783- ELSE */
            }
            else
            {


                /*" -1784- IF ESTIPULA-SITUACAO OF DCLESTIPULANTE EQUAL '2' */

                if (ESTIPULA.DCLESTIPULANTE.ESTIPULA_SITUACAO == "2")
                {

                    /*" -1785- MOVE 4 TO W-CNPJ-CONVENENTE */
                    _.Move(4, WORK_AREA.W_CNPJ_CONVENENTE);

                    /*" -1786- ELSE */
                }
                else
                {


                    /*" -1787- IF ESTIPULA-SITUACAO OF DCLESTIPULANTE EQUAL '3' */

                    if (ESTIPULA.DCLESTIPULANTE.ESTIPULA_SITUACAO == "3")
                    {

                        /*" -1787- MOVE 5 TO W-CNPJ-CONVENENTE. */
                        _.Move(5, WORK_AREA.W_CNPJ_CONVENENTE);
                    }

                }

            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-ESTIPULANTE-DB-SELECT-1 */
        public void R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -1742- EXEC SQL SELECT MAX(OCORR_HISTORICO) INTO :DCLESTIPULANTE.ESTIPULA-OCORR-HISTORICO:VIND-OCOR FROM SEGUROS.ESTIPULANTE WHERE COD_CCT = :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DTQITBCO AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DTQITBCO AND COD_FROTA = :DCLESTIPULANTE.ESTIPULA-COD-FROTA WITH UR END-EXEC. */

            var r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1 = new R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1()
            {
                CGC_CONVENENTE = PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE.ToString(),
                ESTIPULA_COD_FROTA = ESTIPULA.DCLESTIPULANTE.ESTIPULA_COD_FROTA.ToString(),
                DTQITBCO = PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ESTIPULA_OCORR_HISTORICO, ESTIPULA.DCLESTIPULANTE.ESTIPULA_OCORR_HISTORICO);
                _.Move(executed_1.VIND_OCOR, VIND_OCOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-ESTIPULANTE-DB-SELECT-2 */
        public void R1200_00_SELECT_ESTIPULANTE_DB_SELECT_2()
        {
            /*" -1774- EXEC SQL SELECT NOME_ESTIPULANTE, SITUACAO INTO :DCLESTIPULANTE.ESTIPULA-NOME-ESTIPULANTE, :DCLESTIPULANTE.ESTIPULA-SITUACAO FROM SEGUROS.ESTIPULANTE WHERE COD_CCT = :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DTQITBCO AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DTQITBCO AND OCORR_HISTORICO = :DCLESTIPULANTE.ESTIPULA-OCORR-HISTORICO AND COD_FROTA = :DCLESTIPULANTE.ESTIPULA-COD-FROTA WITH UR END-EXEC. */

            var r1200_00_SELECT_ESTIPULANTE_DB_SELECT_2_Query1 = new R1200_00_SELECT_ESTIPULANTE_DB_SELECT_2_Query1()
            {
                ESTIPULA_OCORR_HISTORICO = ESTIPULA.DCLESTIPULANTE.ESTIPULA_OCORR_HISTORICO.ToString(),
                CGC_CONVENENTE = PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE.ToString(),
                ESTIPULA_COD_FROTA = ESTIPULA.DCLESTIPULANTE.ESTIPULA_COD_FROTA.ToString(),
                DTQITBCO = PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_ESTIPULANTE_DB_SELECT_2_Query1.Execute(r1200_00_SELECT_ESTIPULANTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ESTIPULA_NOME_ESTIPULANTE, ESTIPULA.DCLESTIPULANTE.ESTIPULA_NOME_ESTIPULANTE);
                _.Move(executed_1.ESTIPULA_SITUACAO, ESTIPULA.DCLESTIPULANTE.ESTIPULA_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-RCAPS-SECTION */
        private void R1500_00_SELECT_RCAPS_SECTION()
        {
            /*" -1816- MOVE '1500-00-SELECT-RCAPS         ' TO PARAGRAFO. */
            _.Move("1500-00-SELECT-RCAPS         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1818- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1825- PERFORM R1500_00_SELECT_RCAPS_DB_SELECT_1 */

            R1500_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -1828- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1829- DISPLAY 'PF0602B - PROBLEMAS NO SELECT A RCAPS ' */
                _.Display($"PF0602B - PROBLEMAS NO SELECT A RCAPS ");

                /*" -1829- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R1500_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -1825- EXEC SQL SELECT VAL_RCAP INTO :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO AND COD_FONTE =:DCLRCAPS.RCAPS-COD-FONTE WITH UR END-EXEC. */

            var r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
            };

            var executed_1 = R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-SELECT-RCAPS-SFONTE-SECTION */
        private void R1550_00_SELECT_RCAPS_SFONTE_SECTION()
        {
            /*" -1837- MOVE '1550-00-SELECT-RCAPS-SFONTE  ' TO PARAGRAFO. */
            _.Move("1550-00-SELECT-RCAPS-SFONTE  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1839- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1845- PERFORM R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1 */

            R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1();

            /*" -1848- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1849- DISPLAY 'PF0602B - R1550 - PROBLEMAS NO SELECT A RCAPS ' */
                _.Display($"PF0602B - R1550 - PROBLEMAS NO SELECT A RCAPS ");

                /*" -1850- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1850- END-IF. */
            }


        }

        [StopWatch]
        /*" R1550-00-SELECT-RCAPS-SFONTE-DB-SELECT-1 */
        public void R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1()
        {
            /*" -1845- EXEC SQL SELECT VAL_RCAP INTO :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO = :DCLRCAPS.RCAPS-NUM-TITULO WITH UR END-EXEC. */

            var r1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1_Query1 = new R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1_Query1.Execute(r1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-UPDATE-PROPFID-SECTION */
        private void R1600_00_UPDATE_PROPFID_SECTION()
        {
            /*" -1860- MOVE '1600-00-UPDATE-PROPFID       ' TO PARAGRAFO. */
            _.Move("1600-00-UPDATE-PROPFID       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1862- IF WS-TEM-ERRO EQUAL ZEROS AND WS-TEM-ERRO-CRITICO EQUAL 'N' */

            if (WORK_AREA.WS_TEM_ERRO == 00 && WS_TEM_ERRO_CRITICO == "N")
            {

                /*" -1863- MOVE 'PAI' TO WHOST-SIT-PROPOSTA */
                _.Move("PAI", WHOST_SIT_PROPOSTA);

                /*" -1864- MOVE ' ' TO WHOST-SIT-ENVIO */
                _.Move(" ", WHOST_SIT_ENVIO);

                /*" -1865- ELSE */
            }
            else
            {


                /*" -1866- MOVE 'S' TO WHOST-SIT-ENVIO */
                _.Move("S", WHOST_SIT_ENVIO);

                /*" -1867- IF WS-TEM-SICOB EQUAL ZEROS */

                if (WORK_AREA.WS_TEM_SICOB == 00)
                {

                    /*" -1868- MOVE 'PEN' TO WHOST-SIT-PROPOSTA */
                    _.Move("PEN", WHOST_SIT_PROPOSTA);

                    /*" -1869- ELSE */
                }
                else
                {


                    /*" -1871- MOVE 'POB' TO WHOST-SIT-PROPOSTA. */
                    _.Move("POB", WHOST_SIT_PROPOSTA);
                }

            }


            /*" -1874- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -1875- IF WHOST-SIT-PROPOSTA NOT EQUAL 'PAI' */

            if (WHOST_SIT_PROPOSTA != "PAI")
            {

                /*" -1876- IF CANAL-VENDA-PAPEL */

                if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                {

                    /*" -1877- IF NOT FAIXA-NUMERACAO-BILHETE */

                    if (!WORK_AREA.FAIXAS.FAIXA_NUMERACAO["FAIXA_NUMERACAO_BILHETE"])
                    {

                        /*" -1879- MOVE 'REJ' TO WHOST-SIT-PROPOSTA. */
                        _.Move("REJ", WHOST_SIT_PROPOSTA);
                    }

                }

            }


            /*" -1880- IF CANAL-ATM */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_ATM"])
            {

                /*" -1881- IF SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'NPG' */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA == "NPG")
                {

                    /*" -1882- MOVE 'REJ' TO WHOST-SIT-PROPOSTA */
                    _.Move("REJ", WHOST_SIT_PROPOSTA);

                    /*" -1883- MOVE 'R' TO WHOST-SIT-ENVIO */
                    _.Move("R", WHOST_SIT_ENVIO);

                    /*" -1884- PERFORM R1610-00-INSERT-HISPROPFID */

                    R1610_00_INSERT_HISPROPFID_SECTION();

                    /*" -1885- END-IF */
                }


                /*" -1887- END-IF */
            }


            /*" -1895- PERFORM R1600_00_UPDATE_PROPFID_DB_UPDATE_1 */

            R1600_00_UPDATE_PROPFID_DB_UPDATE_1();

            /*" -1898- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1899- DISPLAY 'PROBLEMAS NO UPDATE DA PROPFID      ' */
                _.Display($"PROBLEMAS NO UPDATE DA PROPFID      ");

                /*" -1899- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1600-00-UPDATE-PROPFID-DB-UPDATE-1 */
        public void R1600_00_UPDATE_PROPFID_DB_UPDATE_1()
        {
            /*" -1895- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROPOSTA, SITUACAO_ENVIO = :WHOST-SIT-ENVIO, COD_USUARIO = 'PF0602B' WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 = new R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROPOSTA = WHOST_SIT_PROPOSTA.ToString(),
                WHOST_SIT_ENVIO = WHOST_SIT_ENVIO.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1.Execute(r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1610-00-INSERT-HISPROPFID-SECTION */
        private void R1610_00_INSERT_HISPROPFID_SECTION()
        {
            /*" -1907- MOVE '1610-00-INSERT-HISPROPFID       ' TO PARAGRAFO. */
            _.Move("1610-00-INSERT-HISPROPFID       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1909- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1931- PERFORM R1610_00_INSERT_HISPROPFID_DB_INSERT_1 */

            R1610_00_INSERT_HISPROPFID_DB_INSERT_1();

            /*" -1934- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1935- DISPLAY 'PF0602B - FIM ANORMAL' */
                _.Display($"PF0602B - FIM ANORMAL");

                /*" -1936- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -1938- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -1940- DISPLAY '          NUMERO IDENTIFICACAO..........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -1942- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1943- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1943- END-IF. */
            }


        }

        [StopWatch]
        /*" R1610-00-INSERT-HISPROPFID-DB-INSERT-1 */
        public void R1610_00_INSERT_HISPROPFID_DB_INSERT_1()
        {
            /*" -1931- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ ( NUM_IDENTIFICACAO , DATA_SITUACAO , NSAS_SIVPF , NSL , SIT_PROPOSTA , SIT_COBRANCA_SIVPF , SIT_MOTIVO_SIVPF , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF ) VALUES (:DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO:VIND-DTMOVTO , :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF , :DCLPROPOSTA-FIDELIZ.NSL , 'REJ' , 'SUS' , 99 , :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF , :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF) END-EXEC. */

            var r1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1 = new R1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1()
            {
                NUM_IDENTIFICACAO = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
                NSAC_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF.ToString(),
                NSL = PROPFID.DCLPROPOSTA_FIDELIZ.NSL.ToString(),
                COD_EMPRESA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF.ToString(),
                COD_PRODUTO_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF.ToString(),
            };

            R1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1.Execute(r1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-GRAVA-TAB-ERRO-SECTION */
        private void R1900_00_GRAVA_TAB_ERRO_SECTION()
        {
            /*" -1953- MOVE '1900-00-INSERT-BILHETE-ERROS ' TO PARAGRAFO. */
            _.Move("1900-00-INSERT-BILHETE-ERROS ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1954- MOVE 'INSERT BILHETE_ERROS         ' TO COMANDO. */
            _.Move("INSERT BILHETE_ERROS         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1956- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1958- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -1959- MOVE COD-ERRO OF DCLBILHETE-ERROS TO TB-ERRO-CERT(WS-I-ERRO) */
            _.Move(BILERROS.DCLBILHETE_ERROS.COD_ERRO, WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT);

            /*" -1959- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1950-00-INSERT-BILHETE-ERROS-SECTION */
        private void R1950_00_INSERT_BILHETE_ERROS_SECTION()
        {
            /*" -1969- MOVE '1950-00-INSERT-BILHETE-ERROS ' TO PARAGRAFO. */
            _.Move("1950-00-INSERT-BILHETE-ERROS ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1970- MOVE 'INSERT BILHETE_ERROS         ' TO COMANDO. */
            _.Move("INSERT BILHETE_ERROS         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1972- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1974- MOVE 1 TO WS-TEM-ERRO. */
            _.Move(1, WORK_AREA.WS_TEM_ERRO);

            /*" -1976- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -1977- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -1978- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -1980- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -1981- MOVE TB-ERRO-CERT(WS-I-ERRO) TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -1982- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -1983- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -1984- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -1985- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -1986- MOVE 'PF0602B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("PF0602B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -1987- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -1988- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -1989- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -1992- MOVE 'INSERCAO DE ERRO NA EMISSAO DA PROPOSTA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("INSERCAO DE ERRO NA EMISSAO DA PROPOSTA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -1994- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -1995- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -1996- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -2000- DISPLAY 'ERRO JAH GRAVADO 1900 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 1900 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -2001- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2002- ELSE */
                }
                else
                {


                    /*" -2003- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2004- DISPLAY '* 1900 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 1900 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -2005- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2006- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -2007- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -2008- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2009- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -2010- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -2011- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -2013- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2014- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -2015- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2016- END-IF */
                }


                /*" -2018- END-IF */
            }


            /*" -2020- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -2021- IF TB-ERRO-CERT(WS-I-ERRO) EQUAL ZEROS */

            if (WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT == 00)
            {

                /*" -2022- MOVE 'N' TO WS-FLAG-TEM-ERRO */
                _.Move("N", WS_FLAG_TEM_ERRO);

                /*" -2023- END-IF */
            }


            /*" -2023- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-PESSOA-SECTION */
        private void R2200_00_SELECT_PESSOA_SECTION()
        {
            /*" -2045- MOVE '2200-00-SELECT-PESSOA        ' TO PARAGRAFO. */
            _.Move("2200-00-SELECT-PESSOA        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2047- MOVE 'SELECT SEGUROS.PESSOA        ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2053- PERFORM R2200_00_SELECT_PESSOA_DB_SELECT_1 */

            R2200_00_SELECT_PESSOA_DB_SELECT_1();

            /*" -2055- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2056- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2057- DISPLAY 'PF0602B - PESSOA FISICA NAO CADASTRADA ' */
                    _.Display($"PF0602B - PESSOA FISICA NAO CADASTRADA ");

                    /*" -2058- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2059- ELSE */
                }
                else
                {


                    /*" -2060- DISPLAY 'PF0602B - PROBLEMAS ACESSO PESSOA FISICA ' */
                    _.Display($"PF0602B - PROBLEMAS ACESSO PESSOA FISICA ");

                    /*" -2060- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-PESSOA-DB-SELECT-1 */
        public void R2200_00_SELECT_PESSOA_DB_SELECT_1()
        {
            /*" -2053- EXEC SQL SELECT NOME_PESSOA INTO :DCLPESSOA.PESSOA-NOME-PESSOA FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.COD-PESSOA WITH UR END-EXEC. */

            var r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1 = new R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA.ToString(),
            };

            var executed_1 = R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-SELECT-PESSOA-FISICA-SECTION */
        private void R2210_00_SELECT_PESSOA_FISICA_SECTION()
        {
            /*" -2068- MOVE '2210-00-SELECT-PESSOA-FISICA ' TO PARAGRAFO. */
            _.Move("2210-00-SELECT-PESSOA-FISICA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2070- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2072- MOVE 'SELECT SEGUROS.PESSOA_FISICA ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_FISICA ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2096- PERFORM R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1 */

            R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1();

            /*" -2099- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2100- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2101- DISPLAY 'PF0602B - PESSOA FISICA NAO CADASTRADA ' */
                    _.Display($"PF0602B - PESSOA FISICA NAO CADASTRADA ");

                    /*" -2102- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2103- ELSE */
                }
                else
                {


                    /*" -2104- DISPLAY 'PF0602B - PROBLEMAS ACESSO PESSOA FISICA ' */
                    _.Display($"PF0602B - PROBLEMAS ACESSO PESSOA FISICA ");

                    /*" -2106- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2107- IF COD-CBO OF DCLPESSOA-FISICA GREATER 999 */

            if (PESFIS.DCLPESSOA_FISICA.COD_CBO > 999)
            {

                /*" -2108- MOVE 999 TO COD-CBO OF DCLPESSOA-FISICA */
                _.Move(999, PESFIS.DCLPESSOA_FISICA.COD_CBO);

                /*" -2108- END-IF. */
            }


        }

        [StopWatch]
        /*" R2210-00-SELECT-PESSOA-FISICA-DB-SELECT-1 */
        public void R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -2096- EXEC SQL SELECT CPF, DATA_NASCIMENTO, SEXO, COD_CBO, ESTADO_CIVIL, ORGAO_EXPEDIDOR, NUM_IDENTIDADE, DATA_EXPEDICAO, UF_EXPEDIDORA INTO :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.DATA-EXPEDICAO :VIND-DATA-EXPEDICAO, :DCLPESSOA-FISICA.UF-EXPEDIDORA :VIND-UF-EXPEDIDORA FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.COD-PESSOA WITH UR END-EXEC. */

            var r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1 = new R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA.ToString(),
            };

            var executed_1 = R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CPF, PESFIS.DCLPESSOA_FISICA.CPF);
                _.Move(executed_1.DATA_NASCIMENTO, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
                _.Move(executed_1.SEXO, PESFIS.DCLPESSOA_FISICA.SEXO);
                _.Move(executed_1.COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);
                _.Move(executed_1.ESTADO_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                _.Move(executed_1.ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);
                _.Move(executed_1.NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);
                _.Move(executed_1.DATA_EXPEDICAO, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DATA_EXPEDICAO, VIND_DATA_EXPEDICAO);
                _.Move(executed_1.UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UF_EXPEDIDORA, VIND_UF_EXPEDIDORA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-SECTION */
        private void R2220_00_OBTER_ENDERECO_CORRES_SECTION()
        {
            /*" -2116- MOVE '2220-00-OBTER-ENDERECO-CORRES' TO PARAGRAFO. */
            _.Move("2220-00-OBTER-ENDERECO-CORRES", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2118- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2120- MOVE 'DECLARE PESSOA_ENDERECO CORRESPONDENCIA' TO COMANDO. */
            _.Move("DECLARE PESSOA_ENDERECO CORRESPONDENCIA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2132- PERFORM R2220_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1 */

            R2220_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1();

            /*" -2134- PERFORM R2220_00_OBTER_ENDERECO_CORRES_DB_OPEN_1 */

            R2220_00_OBTER_ENDERECO_CORRES_DB_OPEN_1();

            /*" -2136- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2137- MOVE 2 TO W-ENDERECO */
                _.Move(2, WORK_AREA.W_ENDERECO);

                /*" -2138- GO TO R2220-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/ //GOTO
                return;

                /*" -2139- ELSE */
            }
            else
            {


                /*" -2140- MOVE 'FETCH CPESENDER              ' TO COMANDO */
                _.Move("FETCH CPESENDER              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2148- PERFORM R2220_00_OBTER_ENDERECO_CORRES_DB_FETCH_1 */

                R2220_00_OBTER_ENDERECO_CORRES_DB_FETCH_1();

                /*" -2150- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2151- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2151- PERFORM R2220_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1 */

                        R2220_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1();

                        /*" -2153- MOVE 2 TO W-ENDERECO */
                        _.Move(2, WORK_AREA.W_ENDERECO);

                        /*" -2154- GO TO R2220-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/ //GOTO
                        return;

                        /*" -2155- ELSE */
                    }
                    else
                    {


                        /*" -2156- DISPLAY 'PF0602B - PROBLEMAS FETCH ENDERECOS      ' */
                        _.Display($"PF0602B - PROBLEMAS FETCH ENDERECOS      ");

                        /*" -2158- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2158- PERFORM R2220_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2 */

            R2220_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2();

            /*" -2160- MOVE 1 TO W-ENDERECO. */
            _.Move(1, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-DB-OPEN-1 */
        public void R2220_00_OBTER_ENDERECO_CORRES_DB_OPEN_1()
        {
            /*" -2134- EXEC SQL OPEN CPESENDER END-EXEC. */

            CPESENDER.Open();

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-DECLARE-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1()
        {
            /*" -2184- EXEC SQL DECLARE CPESENDERR CURSOR FOR SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.COD-PESSOA ORDER BY OCORR_ENDERECO DESC WITH UR END-EXEC. */
            CPESENDERR = new PF0602B_CPESENDERR(true);
            string GetQuery_CPESENDERR()
            {
                var query = @$"SELECT OCORR_ENDERECO
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
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = '{PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA}' 
							ORDER BY OCORR_ENDERECO DESC";

                return query;
            }
            CPESENDERR.GetQueryEvent += GetQuery_CPESENDERR;

        }

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-DB-FETCH-1 */
        public void R2220_00_OBTER_ENDERECO_CORRES_DB_FETCH_1()
        {
            /*" -2148- EXEC SQL FETCH CPESENDER INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            if (CPESENDER.Fetch())
            {
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-DB-CLOSE-1 */
        public void R2220_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1()
        {
            /*" -2151- EXEC SQL CLOSE CPESENDER END-EXEC */

            CPESENDER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-DB-CLOSE-2 */
        public void R2220_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2()
        {
            /*" -2158- EXEC SQL CLOSE CPESENDER END-EXEC. */

            CPESENDER.Close();

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-SECTION */
        private void R2225_00_OBTER_DEMAIS_ENDERECO_SECTION()
        {
            /*" -2169- MOVE '2225-00-OBTER-DEMAIS-ENDERECO' TO PARAGRAFO. */
            _.Move("2225-00-OBTER-DEMAIS-ENDERECO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2171- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2173- MOVE 'DECLARE PESSOA_ENDERECO - OUTRO ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA_ENDERECO - OUTRO ENDERECO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2184- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1();

            /*" -2186- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1();

            /*" -2188- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2189- MOVE 4 TO W-ENDERECO */
                _.Move(4, WORK_AREA.W_ENDERECO);

                /*" -2190- GO TO R2225-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/ //GOTO
                return;

                /*" -2191- ELSE */
            }
            else
            {


                /*" -2192- MOVE 'FETCH CPESENDERR             ' TO COMANDO */
                _.Move("FETCH CPESENDERR             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2200- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1 */

                R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1();

                /*" -2202- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2203- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2203- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1 */

                        R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1();

                        /*" -2205- MOVE 4 TO W-ENDERECO */
                        _.Move(4, WORK_AREA.W_ENDERECO);

                        /*" -2206- GO TO R2225-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/ //GOTO
                        return;

                        /*" -2207- ELSE */
                    }
                    else
                    {


                        /*" -2208- DISPLAY 'PF0602B - PROBLEMAS FETCH ENDERECOS ' */
                        _.Display($"PF0602B - PROBLEMAS FETCH ENDERECOS ");

                        /*" -2210- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2210- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2();

            /*" -2212- MOVE 3 TO W-ENDERECO. */
            _.Move(3, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-OPEN-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1()
        {
            /*" -2186- EXEC SQL OPEN CPESENDERR END-EXEC. */

            CPESENDERR.Open();

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-DECLARE-1 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_DECLARE_1()
        {
            /*" -2236- EXEC SQL DECLARE CFONE CURSOR FOR SELECT TIPO_FONE, DDD, NUM_FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.COD-PESSOA ORDER BY TIPO_FONE DESC, TIMESTAMP WITH UR END-EXEC. */
            CFONE = new PF0602B_CFONE(true);
            string GetQuery_CFONE()
            {
                var query = @$"SELECT TIPO_FONE
							, 
							DDD
							, 
							NUM_FONE 
							FROM SEGUROS.PESSOA_TELEFONE 
							WHERE COD_PESSOA = '{PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA}' 
							ORDER BY TIPO_FONE DESC
							, TIMESTAMP";

                return query;
            }
            CFONE.GetQueryEvent += GetQuery_CFONE;

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-FETCH-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1()
        {
            /*" -2200- EXEC SQL FETCH CPESENDERR INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            if (CPESENDERR.Fetch())
            {
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-CLOSE-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1()
        {
            /*" -2203- EXEC SQL CLOSE CPESENDERR END-EXEC */

            CPESENDERR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-CLOSE-2 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2()
        {
            /*" -2210- EXEC SQL CLOSE CPESENDERR END-EXEC. */

            CPESENDERR.Close();

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-SECTION */
        private void R2230_00_SELECT_PESSOA_FONE_SECTION()
        {
            /*" -2220- MOVE '2230-00-SELECT-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2230-00-SELECT-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2222- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2226- MOVE ZEROS TO WHOST-DDD WHOST-TELEFONE WHOST-FAX. */
            _.Move(0, WHOST_DDD, WHOST_TELEFONE, WHOST_FAX);

            /*" -2228- MOVE 'DECLARE CURSOR PESSOA_TELEFONE' TO COMANDO. */
            _.Move("DECLARE CURSOR PESSOA_TELEFONE", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2236- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_DECLARE_1 */

            R2230_00_SELECT_PESSOA_FONE_DB_DECLARE_1();

            /*" -2238- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_OPEN_1 */

            R2230_00_SELECT_PESSOA_FONE_DB_OPEN_1();

            /*" -2240- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2241- DISPLAY 'PF0602B - PROBLEMAS NO DECLARE PESSOA TELEFONE' */
                _.Display($"PF0602B - PROBLEMAS NO DECLARE PESSOA TELEFONE");

                /*" -2241- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2230_10_FETCH_PESSOA_FONE */

            R2230_10_FETCH_PESSOA_FONE();

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-OPEN-1 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_OPEN_1()
        {
            /*" -2238- EXEC SQL OPEN CFONE END-EXEC. */

            CFONE.Open();

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-DECLARE-1 */
        public void R2300_00_TRATA_CLIENTES_DB_DECLARE_1()
        {
            /*" -2404- EXEC SQL DECLARE CCLIENTES CURSOR FOR SELECT COD_CLIENTE FROM SEGUROS.CLIENTES WHERE CGCCPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND NOME_RAZAO <> ' ' ORDER BY COD_CLIENTE DESC WITH UR END-EXEC. */
            CCLIENTES = new PF0602B_CCLIENTES(true);
            string GetQuery_CCLIENTES()
            {
                var query = @$"SELECT COD_CLIENTE 
							FROM SEGUROS.CLIENTES 
							WHERE CGCCPF = '{PESFIS.DCLPESSOA_FISICA.CPF}' 
							AND DATA_NASCIMENTO = '{PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}' 
							AND NOME_RAZAO <> ' ' 
							ORDER BY COD_CLIENTE DESC";

                return query;
            }
            CCLIENTES.GetQueryEvent += GetQuery_CCLIENTES;

        }

        [StopWatch]
        /*" R2230-10-FETCH-PESSOA-FONE */
        private void R2230_10_FETCH_PESSOA_FONE(bool isPerform = false)
        {
            /*" -2246- MOVE 'FETCH CFONE                  ' TO COMANDO. */
            _.Move("FETCH CFONE                  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2251- PERFORM R2230_10_FETCH_PESSOA_FONE_DB_FETCH_1 */

            R2230_10_FETCH_PESSOA_FONE_DB_FETCH_1();

            /*" -2254- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2255- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2255- PERFORM R2230_10_FETCH_PESSOA_FONE_DB_CLOSE_1 */

                    R2230_10_FETCH_PESSOA_FONE_DB_CLOSE_1();

                    /*" -2257- GO TO R2230-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/ //GOTO
                    return;

                    /*" -2258- ELSE */
                }
                else
                {


                    /*" -2259- DISPLAY 'PF0602B - PROBLEMAS FETCH ENDERECOS ' */
                    _.Display($"PF0602B - PROBLEMAS FETCH ENDERECOS ");

                    /*" -2261- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2262- IF TIPO-FONE EQUAL 1 OR 2 */

            if (PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.In("1", "2"))
            {

                /*" -2263- IF WHOST-TELEFONE EQUAL ZEROS */

                if (WHOST_TELEFONE == 00)
                {

                    /*" -2264- MOVE DDD OF DCLPESSOA-TELEFONE TO WHOST-DDD */
                    _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, WHOST_DDD);

                    /*" -2265- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-TELEFONE */
                    _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_TELEFONE);

                    /*" -2266- END-IF */
                }


                /*" -2267- ELSE */
            }
            else
            {


                /*" -2268- IF TIPO-FONE EQUAL 3 OR 4 */

                if (PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.In("3", "4"))
                {

                    /*" -2269- IF WHOST-FAX EQUAL ZEROS */

                    if (WHOST_FAX == 00)
                    {

                        /*" -2270- MOVE DDD OF DCLPESSOA-TELEFONE TO WHOST-DDD */
                        _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, WHOST_DDD);

                        /*" -2271- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-FAX */
                        _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_FAX);

                        /*" -2272- END-IF */
                    }


                    /*" -2273- END-IF */
                }


                /*" -2275- END-IF. */
            }


            /*" -2275- GO TO R2230-10-FETCH-PESSOA-FONE. */
            new Task(() => R2230_10_FETCH_PESSOA_FONE()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2230-10-FETCH-PESSOA-FONE-DB-FETCH-1 */
        public void R2230_10_FETCH_PESSOA_FONE_DB_FETCH_1()
        {
            /*" -2251- EXEC SQL FETCH CFONE INTO :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE END-EXEC. */

            if (CFONE.Fetch())
            {
                _.Move(CFONE.DCLPESSOA_TELEFONE_TIPO_FONE, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);
                _.Move(CFONE.DCLPESSOA_TELEFONE_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);
                _.Move(CFONE.DCLPESSOA_TELEFONE_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);
            }

        }

        [StopWatch]
        /*" R2230-10-FETCH-PESSOA-FONE-DB-CLOSE-1 */
        public void R2230_10_FETCH_PESSOA_FONE_DB_CLOSE_1()
        {
            /*" -2255- EXEC SQL CLOSE CFONE END-EXEC */

            CFONE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2240-00-SELECT-PROPFIDC-SECTION */
        private void R2240_00_SELECT_PROPFIDC_SECTION()
        {
            /*" -2285- MOVE '2240-00-SELECT-PROPFIDC      ' TO PARAGRAFO. */
            _.Move("2240-00-SELECT-PROPFIDC      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2287- MOVE 'SELECT PROPFIDC              ' TO COMANDO. */
            _.Move("SELECT PROPFIDC              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2295- PERFORM R2240_00_SELECT_PROPFIDC_DB_SELECT_1 */

            R2240_00_SELECT_PROPFIDC_DB_SELECT_1();

            /*" -2298- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2299- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2301- MOVE SPACES TO PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP */
                    _.Move("", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);

                    /*" -2302- ELSE */
                }
                else
                {


                    /*" -2303- DISPLAY 'PF0602B - PROBLEMAS NO ACESSOA A PROPFIDC ' */
                    _.Display($"PF0602B - PROBLEMAS NO ACESSOA A PROPFIDC ");

                    /*" -2305- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -2307- DISPLAY '          NUMERO IDENTIFICACAO..........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                    /*" -2309- DISPLAY '          IND TIPO INFORMACAO...........  ' PROFIDCO-IND-TP-INFORMACAO OF DCLPROP-FIDELIZ-COMP */
                    _.Display($"          IND TIPO INFORMACAO...........  {PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO}");

                    /*" -2310- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2311- END-IF */
                }


                /*" -2313- END-IF */
            }


            /*" -2313- . */

        }

        [StopWatch]
        /*" R2240-00-SELECT-PROPFIDC-DB-SELECT-1 */
        public void R2240_00_SELECT_PROPFIDC_DB_SELECT_1()
        {
            /*" -2295- EXEC SQL SELECT INFORMACAO_COMPL INTO :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL FROM SEGUROS.PROP_FIDELIZ_COMP WHERE NUM_IDENTIFICACAO = :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO AND IND_TP_INFORMACAO = :DCLPROP-FIDELIZ-COMP.PROFIDCO-IND-TP-INFORMACAO END-EXEC. */

            var r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1 = new R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1()
            {
                PROFIDCO_IND_TP_INFORMACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO.ToString(),
                NUM_IDENTIFICACAO = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1.Execute(r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROFIDCO_INFORMACAO_COMPL, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2240_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-SELECT-PESSOA-EMAIL-SECTION */
        private void R2250_00_SELECT_PESSOA_EMAIL_SECTION()
        {
            /*" -2324- MOVE 'R2250-00-SELECT-PESSOA-EMAIL' TO PARAGRAFO */
            _.Move("R2250-00-SELECT-PESSOA-EMAIL", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2326- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2327- MOVE ZEROS TO W-PESSOA-EMAIL */
            _.Move(0, WORK_AREA.W_PESSOA_EMAIL);

            /*" -2330- MOVE COD-PESSOA OF DCLPROPOSTA-FIDELIZ TO COD-PESSOA OF DCLPESSOA-EMAIL */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2336- PERFORM R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1 */

            R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1();

            /*" -2339- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2340- DISPLAY 'PF0602B - PROBLEMAS NO ACESSO A PESSOA_EMAIL' */
                _.Display($"PF0602B - PROBLEMAS NO ACESSO A PESSOA_EMAIL");

                /*" -2342- DISPLAY 'CODIGO PESSOA...............  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"CODIGO PESSOA...............  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -2344- DISPLAY 'NUMERO PROPOSTA.............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO PROPOSTA.............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -2346- DISPLAY 'NUMERO IDENTIFICACAO........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO IDENTIFICACAO........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -2347- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2349- END-IF */
            }


            /*" -2350- IF SEQ-EMAIL OF DCLPESSOA-EMAIL EQUAL ZEROS */

            if (PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL == 00)
            {

                /*" -2351- SET EMAIL-N-CADASTRADO TO TRUE */
                WORK_AREA.W_PESSOA_EMAIL["EMAIL_N_CADASTRADO"] = true;

                /*" -2352- GO TO R2250-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/ //GOTO
                return;

                /*" -2354- END-IF */
            }


            /*" -2363- PERFORM R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2 */

            R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2();

            /*" -2366- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2367- SET EMAIL-CADASTRADO TO TRUE */
                WORK_AREA.W_PESSOA_EMAIL["EMAIL_CADASTRADO"] = true;

                /*" -2368- ELSE */
            }
            else
            {


                /*" -2369- DISPLAY 'PF0602B - PROBLEMAS NO ACESSO A PESSOA_EMAIL II' */
                _.Display($"PF0602B - PROBLEMAS NO ACESSO A PESSOA_EMAIL II");

                /*" -2371- DISPLAY 'CODIGO PESSOA...............  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"CODIGO PESSOA...............  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -2373- DISPLAY 'SEQUENCIAL EMAIL............  ' SEQ-EMAIL OF DCLPESSOA-EMAIL */
                _.Display($"SEQUENCIAL EMAIL............  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -2375- DISPLAY 'NUMERO PROPOSTA.............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO PROPOSTA.............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -2377- DISPLAY 'NUMERO IDENTIFICACAO........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO IDENTIFICACAO........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -2378- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2380- END-IF */
            }


            /*" -2380- . */

        }

        [StopWatch]
        /*" R2250-00-SELECT-PESSOA-EMAIL-DB-SELECT-1 */
        public void R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1()
        {
            /*" -2336- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC */

            var r2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1 = new R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1.Execute(r2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-SELECT-PESSOA-EMAIL-DB-SELECT-2 */
        public void R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2()
        {
            /*" -2363- EXEC SQL SELECT EMAIL , SITUACAO_EMAIL INTO :DCLPESSOA-EMAIL.EMAIL , :DCLPESSOA-EMAIL.SITUACAO-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL WITH UR END-EXEC */

            var r2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1 = new R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
            };

            var executed_1 = R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1.Execute(r2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(executed_1.SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
            }


        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-SECTION */
        private void R2300_00_TRATA_CLIENTES_SECTION()
        {
            /*" -2389- MOVE 1 TO W-TRATA-CLIENTE. */
            _.Move(1, WORK_AREA.W_TRATA_CLIENTE);

            /*" -2391- MOVE 0 TO WS-JA-E-CLIENTE. */
            _.Move(0, WORK_AREA.WS_JA_E_CLIENTE);

            /*" -2392- MOVE '2300-00-TRATA-CLIENTE        ' TO PARAGRAFO. */
            _.Move("2300-00-TRATA-CLIENTE        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2394- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2396- MOVE 'DECLARE CURSOR CLIENTES      ' TO COMANDO. */
            _.Move("DECLARE CURSOR CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2404- PERFORM R2300_00_TRATA_CLIENTES_DB_DECLARE_1 */

            R2300_00_TRATA_CLIENTES_DB_DECLARE_1();

            /*" -2406- PERFORM R2300_00_TRATA_CLIENTES_DB_OPEN_1 */

            R2300_00_TRATA_CLIENTES_DB_OPEN_1();

            /*" -2409- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2410- DISPLAY 'PF0602B - PROBLEMAS NO DECLARE CLIENTES ' */
                _.Display($"PF0602B - PROBLEMAS NO DECLARE CLIENTES ");

                /*" -2412- DISPLAY '          NUM PROPOSTA                  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA                  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -2414- DISPLAY '          CODIGO CLIENTE                ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          CODIGO CLIENTE                {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -2416- DISPLAY '          SQLCODE                       ' SQLCODE */
                _.Display($"          SQLCODE                       {DB.SQLCODE}");

                /*" -2418- MOVE 2 TO W-TRATA-CLIENTE. */
                _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
            }


            /*" -2419- MOVE 'FETCH CLIENTES               ' TO COMANDO. */
            _.Move("FETCH CLIENTES               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2422- PERFORM R2300_00_TRATA_CLIENTES_DB_FETCH_1 */

            R2300_00_TRATA_CLIENTES_DB_FETCH_1();

            /*" -2425- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2426- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2426- PERFORM R2300_00_TRATA_CLIENTES_DB_CLOSE_1 */

                    R2300_00_TRATA_CLIENTES_DB_CLOSE_1();

                    /*" -2429- PERFORM R2310-00-INSERT-CLIENTES */

                    R2310_00_INSERT_CLIENTES_SECTION();

                    /*" -2430- IF VIND-DATA-EXPEDICAO EQUAL ZEROS */

                    if (VIND_DATA_EXPEDICAO == 00)
                    {

                        /*" -2431- PERFORM R2315-00-INSERT-GE-DOC */

                        R2315_00_INSERT_GE_DOC_SECTION();

                        /*" -2433- END-IF */
                    }


                    /*" -2434- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
                    _.Move("I", WS_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                    /*" -2435- GO TO R2300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                    /*" -2436- ELSE */
                }
                else
                {


                    /*" -2437- DISPLAY 'PF0602B - PROBLEMAS NO FETCH CLIENTES   ' */
                    _.Display($"PF0602B - PROBLEMAS NO FETCH CLIENTES   ");

                    /*" -2439- DISPLAY '          NUM PROPOSTA                  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUM PROPOSTA                  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -2441- DISPLAY '          CODIGO CLIENTE                ' COD-CLIENTE OF DCLCLIENTES */
                    _.Display($"          CODIGO CLIENTE                {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                    /*" -2443- DISPLAY '          SQLCODE                       ' SQLCODE */
                    _.Display($"          SQLCODE                       {DB.SQLCODE}");

                    /*" -2445- MOVE 2 TO W-TRATA-CLIENTE. */
                    _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
                }

            }


            /*" -2445- PERFORM R2300_00_TRATA_CLIENTES_DB_CLOSE_2 */

            R2300_00_TRATA_CLIENTES_DB_CLOSE_2();

            /*" -2448- MOVE 1 TO WS-JA-E-CLIENTE. */
            _.Move(1, WORK_AREA.WS_JA_E_CLIENTE);

            /*" -2449- MOVE COD-CLIENTE OF DCLCLIENTES TO W-COD-CLIENTE-FIS. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, W_COD_CLIENTE_FIS);

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-OPEN-1 */
        public void R2300_00_TRATA_CLIENTES_DB_OPEN_1()
        {
            /*" -2406- EXEC SQL OPEN CCLIENTES END-EXEC. */

            CCLIENTES.Open();

        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-DECLARE-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_DECLARE_1()
        {
            /*" -4362- EXEC SQL DECLARE C01_AGENCEF CURSOR FOR SELECT A.COD_AGENCIA, B.COD_FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            C01_AGENCEF = new PF0602B_C01_AGENCEF(false);
            string GetQuery_C01_AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							B.COD_FONTE 
							FROM SEGUROS.AGENCIAS_CEF A
							, 
							SEGUROS.MALHA_CEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            C01_AGENCEF.GetQueryEvent += GetQuery_C01_AGENCEF;

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-FETCH-1 */
        public void R2300_00_TRATA_CLIENTES_DB_FETCH_1()
        {
            /*" -2422- EXEC SQL FETCH CCLIENTES INTO :DCLCLIENTES.COD-CLIENTE END-EXEC. */

            if (CCLIENTES.Fetch())
            {
                _.Move(CCLIENTES.DCLCLIENTES_COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);
            }

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-CLOSE-1 */
        public void R2300_00_TRATA_CLIENTES_DB_CLOSE_1()
        {
            /*" -2426- EXEC SQL CLOSE CCLIENTES END-EXEC */

            CCLIENTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-CLOSE-2 */
        public void R2300_00_TRATA_CLIENTES_DB_CLOSE_2()
        {
            /*" -2445- EXEC SQL CLOSE CCLIENTES END-EXEC. */

            CCLIENTES.Close();

        }

        [StopWatch]
        /*" R2310-00-INSERT-CLIENTES-SECTION */
        private void R2310_00_INSERT_CLIENTES_SECTION()
        {
            /*" -2458- ADD 1 TO NUM-CLIENTE OF DCLNUMERO-OUTROS. */
            NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.Value = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE + 1;

            /*" -2461- MOVE NUM-CLIENTE OF DCLNUMERO-OUTROS TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -2462- MOVE '2310-00-INSERT-CLIENTES      ' TO PARAGRAFO. */
            _.Move("2310-00-INSERT-CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2464- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2502- PERFORM R2310_00_INSERT_CLIENTES_DB_INSERT_1 */

            R2310_00_INSERT_CLIENTES_DB_INSERT_1();

            /*" -2505- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2506- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2507- GO TO R2310-00-INSERT-CLIENTES */
                    new Task(() => R2310_00_INSERT_CLIENTES_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2509- END-IF */
                }


                /*" -2510- DISPLAY 'PF0602B - PROBLEMAS NO INSERT A CLIENTES ' */
                _.Display($"PF0602B - PROBLEMAS NO INSERT A CLIENTES ");

                /*" -2512- DISPLAY '          NUM PROPOSTA                   ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA                   {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -2514- DISPLAY '          CODIGO CLIENTE                 ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          CODIGO CLIENTE                 {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -2516- DISPLAY '          SQLCODE                        ' SQLCODE */
                _.Display($"          SQLCODE                        {DB.SQLCODE}");

                /*" -2518- MOVE 2 TO W-TRATA-CLIENTE. */
                _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
            }


            /*" -2520- MOVE COD-CLIENTE OF DCLCLIENTES TO W-COD-CLIENTE-FIS */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, W_COD_CLIENTE_FIS);

            /*" -2520- . */

        }

        [StopWatch]
        /*" R2310-00-INSERT-CLIENTES-DB-INSERT-1 */
        public void R2310_00_INSERT_CLIENTES_DB_INSERT_1()
        {
            /*" -2502- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES (:DCLCLIENTES.COD-CLIENTE, :DCLPESSOA.PESSOA-NOME-PESSOA, 'F' , :DCLPESSOA-FISICA.CPF, '0' , :DCLPESSOA-FISICA.DATA-NASCIMENTO :VIND-DATA-NASCIMENTO, 0, NULL, NULL, NULL, NULL, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.ESTADO-CIVIL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1 = new R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                VIND_DATA_NASCIMENTO = VIND_DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
            };

            R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1.Execute(r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-INSERT-GE-DOC-SECTION */
        private void R2315_00_INSERT_GE_DOC_SECTION()
        {
            /*" -2527- MOVE '2315-00-INSERT-GE-DOC        ' TO PARAGRAFO. */
            _.Move("2315-00-INSERT-GE-DOC        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2529- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2532- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -2535- MOVE NUM-IDENTIDADE OF DCLPESSOA-FISICA TO GEDOCCLI-COD-IDENTIFICACAO */
            _.Move(PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO);

            /*" -2538- MOVE ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA TO W-NOM-ORGAO-EXP */
            _.Move(PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR, WORK_AREA.W_NOM_ORGAO_EXP);

            /*" -2541- MOVE W-ORGAO-EXPEDIDOR TO GEDOCCLI-NOM-ORGAO-EXP. */
            _.Move(WORK_AREA.FILLER_9.W_ORGAO_EXPEDIDOR, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP);

            /*" -2544- MOVE DATA-EXPEDICAO OF DCLPESSOA-FISICA TO GEDOCCLI-DTH-EXPEDICAO. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO);

            /*" -2545- IF VIND-UF-EXPEDIDORA NOT LESS ZEROS */

            if (VIND_UF_EXPEDIDORA >= 00)
            {

                /*" -2548- MOVE UF-EXPEDIDORA OF DCLPESSOA-FISICA TO GEDOCCLI-COD-UF. */
                _.Move(PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);
            }


            /*" -2561- PERFORM R2315_00_INSERT_GE_DOC_DB_INSERT_1 */

            R2315_00_INSERT_GE_DOC_DB_INSERT_1();

            /*" -2564- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2565- DISPLAY 'PF0602B - PROBLEMAS INSERT DA GE_DOC_CLIENTES' */
                _.Display($"PF0602B - PROBLEMAS INSERT DA GE_DOC_CLIENTES");

                /*" -2567- DISPLAY '          NUM PROPOSTA....................... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA....................... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -2569- DISPLAY '          COD CLIENTE........................ ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE........................ {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -2571- DISPLAY '          SQLCODE............................ ' SQLCODE */
                _.Display($"          SQLCODE............................ {DB.SQLCODE}");

                /*" -2571- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2315-00-INSERT-GE-DOC-DB-INSERT-1 */
        public void R2315_00_INSERT_GE_DOC_DB_INSERT_1()
        {
            /*" -2561- EXEC SQL INSERT INTO SEGUROS.GE_DOC_CLIENTE (COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF) VALUES (:GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO, :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF:VIND-UF-EXPEDIDORA) END-EXEC. */

            var r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 = new R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1()
            {
                GEDOCCLI_COD_CLIENTE = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.ToString(),
                GEDOCCLI_COD_IDENTIFICACAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO.ToString(),
                GEDOCCLI_NOM_ORGAO_EXP = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP.ToString(),
                GEDOCCLI_DTH_EXPEDICAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO.ToString(),
                GEDOCCLI_COD_UF = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF.ToString(),
                VIND_UF_EXPEDIDORA = VIND_UF_EXPEDIDORA.ToString(),
            };

            R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1.Execute(r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2315_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-OBTER-COBERTURA-SECTION */
        private void R2350_00_OBTER_COBERTURA_SECTION()
        {
            /*" -2579- MOVE '2350-00-OBTER-COBERTURA      ' TO PARAGRAFO */
            _.Move("2350-00-OBTER-COBERTURA      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2581- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2583- MOVE 'SELECT BILHETE COBERTURA     ' TO COMANDO */
            _.Move("SELECT BILHETE COBERTURA     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2589- MOVE ZEROS TO BILHECOB-COD-EMPRESA OF DCLBILHETE-COBERTURA BILHECOB-MODALI-COBERTURA OF DCLBILHETE-COBERTURA BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA W-TEM-COBERTURA */
            _.Move(0, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO, WORK_AREA.W_TEM_COBERTURA);

            /*" -2592- MOVE VAL-PAGO OF DCLPROPOSTA-FIDELIZ TO BILHECOB-PRM-TOTAL OF DCLBILHETE-COBERTURA */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL);

            /*" -2597- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 09 AND (ORIGEM-INTRANET OR ORIGEM-SIPEN-CAIXATEM OR ORIGEM-CX-AQUI-CCA) AND (CANAL-VENDA-PAPEL OR CANAL-INTERNET OR CANAL-INTRANET OR CANAL-CORRETOR) */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 09 && (WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_INTRANET"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_SIPEN_CAIXATEM"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_CX_AQUI_CCA"]) && (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_INTERNET"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_INTRANET"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_CORRETOR"]))
            {

                /*" -2600- DISPLAY 'ENTROU 01.0 ' W-ORIGEM-PROPOSTA '/' W-CANAL-PROPOSTA '/' COD-PLANO OF DCLPROPOSTA-FIDELIZ */

                $"ENTROU 01.0 {WORK_AREA.W_ORIGEM_PROPOSTA}/{WORK_AREA.CANAL.W_CANAL_PROPOSTA}/{PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO}"
                .Display();

                /*" -2604- IF COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 8521 OR 8528 OR 8529 OR 8530 OR 8531 OR 8532 OR 8533 OR 8534 */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.In("8521", "8528", "8529", "8530", "8531", "8532", "8533", "8534"))
                {

                    /*" -2605- DISPLAY 'ENTROU 01.1' */
                    _.Display($"ENTROU 01.1");

                    /*" -2607- MOVE COD-PLANO IN DCLPROPOSTA-FIDELIZ TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                    _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                    /*" -2609- DISPLAY 'COD PRD 01: ' BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                    _.Display($"COD PRD 01: {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO}");

                    /*" -2610- END-IF */
                }


                /*" -2612- IF COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 8530 OR 8531 OR 8532 */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.In("8530", "8531", "8532"))
                {

                    /*" -2613- DISPLAY 'entrou 01.2' */
                    _.Display($"entrou 01.2");

                    /*" -2614- MOVE 'S' TO N88-PRODUTO-MEI */
                    _.Move("S", N88_PRODUTO_MEI);

                    /*" -2615- END-IF */
                }


                /*" -2616- DISPLAY 'entrou 01.3' */
                _.Display($"entrou 01.3");

                /*" -2618- MOVE 81 TO BILHECOB-RAMO-COBERTURA OF DCLBILHETE-COBERTURA */
                _.Move(81, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

                /*" -2619- PERFORM R2354-00-OBTER-COBERTURA */

                R2354_00_OBTER_COBERTURA_SECTION();

                /*" -2620- GO TO R2350-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                return;

                /*" -2622- END-IF */
            }


            /*" -2624- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 29 AND COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 3721 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 29 && PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO == 3721)
            {

                /*" -2625- DISPLAY 'entrou 02.0' */
                _.Display($"entrou 02.0");

                /*" -2626- MOVE 002 TO W-TIPO-PRODUTO */
                _.Move(002, WORK_AREA.W_TIPO_PRODUTO);

                /*" -2628- MOVE 3721 TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                _.Move(3721, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                /*" -2630- DISPLAY 'COD PRD 02: ' BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                _.Display($"COD PRD 02: {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO}");

                /*" -2632- MOVE 37 TO BILHECOB-RAMO-COBERTURA OF DCLBILHETE-COBERTURA */
                _.Move(37, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

                /*" -2633- PERFORM R2352-00-OBTER-COBERTURA */

                R2352_00_OBTER_COBERTURA_SECTION();

                /*" -2634- GO TO R2350-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                return;

                /*" -2636- END-IF */
            }


            /*" -2637- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 09 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 09)
            {

                /*" -2638- IF CANAL-ATM */

                if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_ATM"])
                {

                    /*" -2647- IF COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 8144 OR JVPROD(8144) OR 8145 OR JVPROD(8145) OR 8146 OR JVPROD(8146) OR 8147 OR JVPROD(8147) OR 8148 OR JVPROD(8148) OR 8149 OR JVPROD(8149) OR 8150 OR JVPROD(8150) */

                    if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.In("8144", JVBKINCL.FILLER.JVPROD[8144].ToString(), "8145", JVBKINCL.FILLER.JVPROD[8145].ToString(), "8146", JVBKINCL.FILLER.JVPROD[8146].ToString(), "8147", JVBKINCL.FILLER.JVPROD[8147].ToString(), "8148", JVBKINCL.FILLER.JVPROD[8148].ToString(), "8149", JVBKINCL.FILLER.JVPROD[8149].ToString(), "8150", JVBKINCL.FILLER.JVPROD[8150].ToString()))
                    {

                        /*" -2648- MOVE 1 TO W-TIPO-PRODUTO */
                        _.Move(1, WORK_AREA.W_TIPO_PRODUTO);

                        /*" -2650- IF DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ < LK-GEJVW002-JV-DTA-INI */

                        if (PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA < GEJVW002.LK_GEJVW002_JV_DTA_INI)
                        {

                            /*" -2652- MOVE COD-PLANO IN DCLPROPOSTA-FIDELIZ TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                            /*" -2653- ELSE */
                        }
                        else
                        {


                            /*" -2654- IF JVPROD(COD-PLANO IN DCLPROPOSTA-FIDELIZ) > 0 */

                            if (JVBKINCL.FILLER.JVPROD[PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO] > 0)
                            {

                                /*" -2657- MOVE JVPROD(COD-PLANO IN DCLPROPOSTA-FIDELIZ) TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                                _.Move(JVBKINCL.FILLER.JVPROD[PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO], BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                                /*" -2658- ELSE */
                            }
                            else
                            {


                                /*" -2661- MOVE COD-PLANO IN DCLPROPOSTA-FIDELIZ TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                                /*" -2662- END-IF */
                            }


                            /*" -2665- END-IF */
                        }


                        /*" -2667- MOVE 81 TO BILHECOB-RAMO-COBERTURA OF DCLBILHETE-COBERTURA */
                        _.Move(81, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

                        /*" -2668- PERFORM R2351-00-OBTER-COBERTURA */

                        R2351_00_OBTER_COBERTURA_SECTION();

                        /*" -2669- GO TO R2350-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                        return;

                        /*" -2670- ELSE */
                    }
                    else
                    {


                        /*" -2672- MOVE 2 TO W-TIPO-PRODUTO */
                        _.Move(2, WORK_AREA.W_TIPO_PRODUTO);

                        /*" -2674- IF DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ < LK-GEJVW002-JV-DTA-INI */

                        if (PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA < GEJVW002.LK_GEJVW002_JV_DTA_INI)
                        {

                            /*" -2676- MOVE 3709 TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                            _.Move(3709, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                            /*" -2677- ELSE */
                        }
                        else
                        {


                            /*" -2679- MOVE JVPROD(3709) TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                            _.Move(JVBKINCL.FILLER.JVPROD[3709], BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                            /*" -2681- END-IF */
                        }


                        /*" -2683- MOVE 37 TO BILHECOB-RAMO-COBERTURA OF DCLBILHETE-COBERTURA */
                        _.Move(37, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

                        /*" -2684- PERFORM R2352-00-OBTER-COBERTURA */

                        R2352_00_OBTER_COBERTURA_SECTION();

                        /*" -2685- GO TO R2350-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                        return;

                        /*" -2686- END-IF */
                    }


                    /*" -2687- ELSE */
                }
                else
                {


                    /*" -2689- IF CANAL-VENDA-PAPEL OR CANAL-VENDA-CEF */

                    if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_CEF"])
                    {

                        /*" -2691- IF DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ < LK-GEJVW002-JV-DTA-INI */

                        if (PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA < GEJVW002.LK_GEJVW002_JV_DTA_INI)
                        {

                            /*" -2693- MOVE 3709 TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                            _.Move(3709, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                            /*" -2694- ELSE */
                        }
                        else
                        {


                            /*" -2696- MOVE JVPROD(3709) TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                            _.Move(JVBKINCL.FILLER.JVPROD[3709], BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                            /*" -2698- END-IF */
                        }


                        /*" -2700- MOVE 37 TO BILHECOB-RAMO-COBERTURA OF DCLBILHETE-COBERTURA */
                        _.Move(37, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

                        /*" -2701- PERFORM R2353-00-OBTER-COBERTURA */

                        R2353_00_OBTER_COBERTURA_SECTION();

                        /*" -2702- GO TO R2350-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                        return;

                        /*" -2703- ELSE */
                    }
                    else
                    {


                        /*" -2706- IF ORIGEM-MARSH OR BILHECOB-PRM-TOTAL EQUAL 60,00 OR 60,77 */

                        if (WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_MARSH"] || BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL.In("60.00", "60.77"))
                        {

                            /*" -2708- IF DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ < LK-GEJVW002-JV-DTA-INI */

                            if (PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA < GEJVW002.LK_GEJVW002_JV_DTA_INI)
                            {

                                /*" -2710- MOVE 8104 TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                                _.Move(8104, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                                /*" -2711- ELSE */
                            }
                            else
                            {


                                /*" -2713- MOVE JVPROD(8104) TO BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                                _.Move(JVBKINCL.FILLER.JVPROD[8104], BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                                /*" -2715- END-IF */
                            }


                            /*" -2717- MOVE 81 TO BILHECOB-RAMO-COBERTURA OF DCLBILHETE-COBERTURA */
                            _.Move(81, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

                            /*" -2718- PERFORM R2351-00-OBTER-COBERTURA */

                            R2351_00_OBTER_COBERTURA_SECTION();

                            /*" -2719- GO TO R2350-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                            return;

                            /*" -2720- ELSE */
                        }
                        else
                        {


                            /*" -2722- MOVE 82 TO BILHECOB-RAMO-COBERTURA OF DCLBILHETE-COBERTURA */
                            _.Move(82, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

                            /*" -2723- END-IF */
                        }


                        /*" -2724- END-IF */
                    }


                    /*" -2725- END-IF */
                }


                /*" -2726- ELSE */
            }
            else
            {


                /*" -2727- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 10 */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 10)
                {

                    /*" -2728- IF BILHECOB-PRM-TOTAL EQUAL 69,90 OR 79,90 */

                    if (BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL.In("69.90", "79.90"))
                    {

                        /*" -2729- MOVE 14 TO BILHECOB-RAMO-COBERTURA */
                        _.Move(14, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

                        /*" -2730- ELSE */
                    }
                    else
                    {


                        /*" -2731- MOVE 72 TO BILHECOB-RAMO-COBERTURA */
                        _.Move(72, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

                        /*" -2732- END-IF */
                    }


                    /*" -2733- ELSE */
                }
                else
                {


                    /*" -2734- DISPLAY 'PF0602B - PRODUTO INVALIDO NA PROPOSTA FIDELIZ' */
                    _.Display($"PF0602B - PRODUTO INVALIDO NA PROPOSTA FIDELIZ");

                    /*" -2736- DISPLAY 'PROPOSTA  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -2738- DISPLAY 'PRODUTO   ' COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PRODUTO   {PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF}");

                    /*" -2739- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2740- END-IF */
                }


                /*" -2742- END-IF */
            }


            /*" -2743- IF COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 3721 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO == 3721)
            {

                /*" -2744- DISPLAY 'DISPLAY LOGICO - AMPARO' */
                _.Display($"LOGICO - AMPARO");

                /*" -2745- DISPLAY 'DISPLAY NAO DEVERIA CHEGAR AQUI PARA O AMPARO' */
                _.Display($"NAO DEVERIA CHEGAR AQUI PARA O AMPARO");

                /*" -2747- DISPLAY 'PROPOSTA   = ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"PROPOSTA   = {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -2748- DISPLAY ' PREMIO    = ' BILHECOB-PRM-TOTAL */
                _.Display($" PREMIO    = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL}");

                /*" -2749- DISPLAY ' EMPRESA   = ' BILHECOB-COD-EMPRESA */
                _.Display($" EMPRESA   = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA}");

                /*" -2750- DISPLAY ' MODALID   = ' BILHECOB-MODALI-COBERTURA */
                _.Display($" MODALID   = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA}");

                /*" -2751- DISPLAY ' RAMO      = ' BILHECOB-RAMO-COBERTURA */
                _.Display($" RAMO      = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA}");

                /*" -2752- DISPLAY ' PRODUTO   = ' BILHECOB-COD-PRODUTO */
                _.Display($" PRODUTO   = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO}");

                /*" -2753- DISPLAY ' PRM MIN   = ' WHOST-PREMIO-MIN */
                _.Display($" PRM MIN   = {WHOST_PREMIO_MIN}");

                /*" -2754- DISPLAY ' PRM MAX   = ' WHOST-PREMIO-MAX */
                _.Display($" PRM MAX   = {WHOST_PREMIO_MAX}");

                /*" -2755- DISPLAY ' DT PROP   = ' DATA-PROPOSTA */
                _.Display($" DT PROP   = {PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA}");

                /*" -2756- DISPLAY ' CODPLAN   = ' BILHECOB-COD-OPCAO-PLANO */
                _.Display($" CODPLAN   = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO}");

                /*" -2757- DISPLAY ' WTEMCOBER = ' W-TEM-COBERTURA */
                _.Display($" WTEMCOBER = {WORK_AREA.W_TEM_COBERTURA}");

                /*" -2758- DISPLAY ' PARAGRAFO = ' PARAGRAFO */
                _.Display($" PARAGRAFO = {AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO}");

                /*" -2760- END-IF */
            }


            /*" -2777- PERFORM R2350_00_OBTER_COBERTURA_DB_SELECT_1 */

            R2350_00_OBTER_COBERTURA_DB_SELECT_1();

            /*" -2780- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -2781- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2782- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -2783- MOVE 2 TO W-TEM-COBERTURA */
                    _.Move(2, WORK_AREA.W_TEM_COBERTURA);

                    /*" -2784- DISPLAY 'PROBLEMAS SELECT BILHETE COBERTURA' */
                    _.Display($"PROBLEMAS SELECT BILHETE COBERTURA");

                    /*" -2786- DISPLAY 'PROPOSTA=' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA={PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -2787- DISPLAY ' PREMIO =' BILHECOB-PRM-TOTAL */
                    _.Display($" PREMIO ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL}");

                    /*" -2788- DISPLAY ' EMPRESA=' BILHECOB-COD-EMPRESA */
                    _.Display($" EMPRESA={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA}");

                    /*" -2789- DISPLAY ' MODALID=' BILHECOB-MODALI-COBERTURA */
                    _.Display($" MODALID={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA}");

                    /*" -2790- DISPLAY ' RAMO   =' BILHECOB-RAMO-COBERTURA */
                    _.Display($" RAMO   ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA}");

                    /*" -2791- DISPLAY ' PRM TOT=' BILHECOB-PRM-TOTAL */
                    _.Display($" PRM TOT={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL}");

                    /*" -2792- DISPLAY ' DT PROP=' DATA-PROPOSTA */
                    _.Display($" DT PROP={PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA}");

                    /*" -2794- DISPLAY 'PARAGRAFO=' PARAGRAFO ' SQLCODE ' WSQLCODE */

                    $"PARAGRAFO={AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO} SQLCODE {AREA_ABEND.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2795- GO TO R2350-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                    return;

                    /*" -2796- ELSE */
                }
                else
                {


                    /*" -2797- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2798- MOVE 1 TO W-TEM-COBERTURA */
                        _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                        /*" -2799- ELSE */
                    }
                    else
                    {


                        /*" -2800- MOVE 1 TO W-TEM-COBERTURA */
                        _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                        /*" -2801- DISPLAY 'PROBLEMAS SELECT BILHETE COBERTURA' */
                        _.Display($"PROBLEMAS SELECT BILHETE COBERTURA");

                        /*" -2803- DISPLAY 'PROPOSTA=' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                        _.Display($"PROPOSTA={PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                        /*" -2804- DISPLAY ' PREMIO =' BILHECOB-PRM-TOTAL */
                        _.Display($" PREMIO ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL}");

                        /*" -2805- DISPLAY ' EMPRESA=' BILHECOB-COD-EMPRESA */
                        _.Display($" EMPRESA={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA}");

                        /*" -2806- DISPLAY ' MODALID=' BILHECOB-MODALI-COBERTURA */
                        _.Display($" MODALID={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA}");

                        /*" -2807- DISPLAY ' RAMO   =' BILHECOB-RAMO-COBERTURA */
                        _.Display($" RAMO   ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA}");

                        /*" -2808- DISPLAY ' DT PROP=' DATA-PROPOSTA */
                        _.Display($" DT PROP={PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA}");

                        /*" -2809- DISPLAY ' PRM TOT=' BILHECOB-PRM-TOTAL */
                        _.Display($" PRM TOT={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL}");

                        /*" -2810- DISPLAY ' PRM MIN=' WHOST-PREMIO-MIN */
                        _.Display($" PRM MIN={WHOST_PREMIO_MIN}");

                        /*" -2811- DISPLAY ' PRM MAX=' WHOST-PREMIO-MAX */
                        _.Display($" PRM MAX={WHOST_PREMIO_MAX}");

                        /*" -2813- DISPLAY 'PARAGRAFO=' PARAGRAFO ' SQLCODE ' WSQLCODE */

                        $"PARAGRAFO={AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO} SQLCODE {AREA_ABEND.WABEND.WSQLCODE}"
                        .Display();

                        /*" -2814- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2815- END-IF */
                    }


                    /*" -2816- END-IF */
                }


                /*" -2817- ELSE */
            }
            else
            {


                /*" -2818- MOVE 0 TO W-TEM-COBERTURA */
                _.Move(0, WORK_AREA.W_TEM_COBERTURA);

                /*" -2818- END-IF. */
            }


        }

        [StopWatch]
        /*" R2350-00-OBTER-COBERTURA-DB-SELECT-1 */
        public void R2350_00_OBTER_COBERTURA_DB_SELECT_1()
        {
            /*" -2777- EXEC SQL SELECT COD_OPCAO_PLANO INTO :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = :DCLBILHETE-COBERTURA.BILHECOB-COD-EMPRESA AND MODALI_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-MODALI-COBERTURA AND RAMO_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-RAMO-COBERTURA AND PRM_TOTAL = :DCLBILHETE-COBERTURA.BILHECOB-PRM-TOTAL AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA WITH UR END-EXEC */

            var r2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1 = new R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1()
            {
                BILHECOB_MODALI_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA.ToString(),
                BILHECOB_RAMO_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA.ToString(),
                BILHECOB_COD_EMPRESA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA.ToString(),
                BILHECOB_PRM_TOTAL = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL.ToString(),
                DATA_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.ToString(),
            };

            var executed_1 = R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1.Execute(r2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHECOB_COD_OPCAO_PLANO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2351-00-OBTER-COBERTURA-SECTION */
        private void R2351_00_OBTER_COBERTURA_SECTION()
        {
            /*" -2826- MOVE '2351-00-OBTER-COBERTURA      ' TO PARAGRAFO. */
            _.Move("2351-00-OBTER-COBERTURA      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2828- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2830- MOVE 'SELECT BILHETE COBERTURA     ' TO COMANDO. */
            _.Move("SELECT BILHETE COBERTURA     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2831- IF PROD-CAIXA-FACIL */

            if (WORK_AREA.W_TIPO_PRODUTO["PROD_CAIXA_FACIL"])
            {

                /*" -2834- MOVE BILHECOB-PRM-TOTAL OF DCLBILHETE-COBERTURA TO WHOST-PREMIO-MIN WHOST-PREMIO-MAX */
                _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL, WHOST_PREMIO_MIN, WHOST_PREMIO_MAX);

                /*" -2835- ELSE */
            }
            else
            {


                /*" -2836- COMPUTE WHOST-PREMIO-MIN = BILHECOB-PRM-TOTAL - 1 */
                WHOST_PREMIO_MIN.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL - 1;

                /*" -2837- COMPUTE WHOST-PREMIO-MAX = BILHECOB-PRM-TOTAL + 1 */
                WHOST_PREMIO_MAX.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL + 1;

                /*" -2839- END-IF */
            }


            /*" -2863- PERFORM R2351_00_OBTER_COBERTURA_DB_SELECT_1 */

            R2351_00_OBTER_COBERTURA_DB_SELECT_1();

            /*" -2867- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -2868- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2869- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -2870- MOVE 2 TO W-TEM-COBERTURA */
                    _.Move(2, WORK_AREA.W_TEM_COBERTURA);

                    /*" -2871- DISPLAY 'PROBLEMAS SELECT BILHETE COBERTURA' */
                    _.Display($"PROBLEMAS SELECT BILHETE COBERTURA");

                    /*" -2873- DISPLAY 'PROPOSTA ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -2874- DISPLAY ' PREMIO =' BILHECOB-PRM-TOTAL */
                    _.Display($" PREMIO ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL}");

                    /*" -2875- DISPLAY ' EMPRESA=' BILHECOB-COD-EMPRESA */
                    _.Display($" EMPRESA={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA}");

                    /*" -2876- DISPLAY ' MODALID=' BILHECOB-MODALI-COBERTURA */
                    _.Display($" MODALID={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA}");

                    /*" -2877- DISPLAY ' RAMO   =' BILHECOB-RAMO-COBERTURA */
                    _.Display($" RAMO   ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA}");

                    /*" -2878- DISPLAY ' PRODUTO=' BILHECOB-COD-PRODUTO */
                    _.Display($" PRODUTO={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO}");

                    /*" -2879- DISPLAY ' PRM MIN=' WHOST-PREMIO-MIN */
                    _.Display($" PRM MIN={WHOST_PREMIO_MIN}");

                    /*" -2880- DISPLAY ' PRM MAX=' WHOST-PREMIO-MAX */
                    _.Display($" PRM MAX={WHOST_PREMIO_MAX}");

                    /*" -2881- DISPLAY ' DT PROP=' DATA-PROPOSTA */
                    _.Display($" DT PROP={PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA}");

                    /*" -2882- DISPLAY ' CODPLAN=' BILHECOB-COD-OPCAO-PLANO */
                    _.Display($" CODPLAN={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO}");

                    /*" -2883- DISPLAY ' WTEMCOBER=' W-TEM-COBERTURA */
                    _.Display($" WTEMCOBER={WORK_AREA.W_TEM_COBERTURA}");

                    /*" -2885- DISPLAY 'PARAGRAFO=' PARAGRAFO ' SQLCODE ' WSQLCODE */

                    $"PARAGRAFO={AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO} SQLCODE {AREA_ABEND.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2886- GO TO R2351-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2351_99_SAIDA*/ //GOTO
                    return;

                    /*" -2887- ELSE */
                }
                else
                {


                    /*" -2888- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2889- MOVE 1 TO W-TEM-COBERTURA */
                        _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                        /*" -2890- ELSE */
                    }
                    else
                    {


                        /*" -2891- MOVE 1 TO W-TEM-COBERTURA */
                        _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                        /*" -2892- DISPLAY 'PROBLEMAS SELECT BILHETE COBERTURA' */
                        _.Display($"PROBLEMAS SELECT BILHETE COBERTURA");

                        /*" -2894- DISPLAY 'PROPOSTA ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                        _.Display($"PROPOSTA {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                        /*" -2895- DISPLAY ' PREMIO =' BILHECOB-PRM-TOTAL */
                        _.Display($" PREMIO ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL}");

                        /*" -2896- DISPLAY ' EMPRESA=' BILHECOB-COD-EMPRESA */
                        _.Display($" EMPRESA={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA}");

                        /*" -2897- DISPLAY ' MODALID=' BILHECOB-MODALI-COBERTURA */
                        _.Display($" MODALID={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA}");

                        /*" -2898- DISPLAY ' RAMO   =' BILHECOB-RAMO-COBERTURA */
                        _.Display($" RAMO   ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA}");

                        /*" -2899- DISPLAY ' PRM MIN=' WHOST-PREMIO-MIN */
                        _.Display($" PRM MIN={WHOST_PREMIO_MIN}");

                        /*" -2900- DISPLAY ' PRM MAX=' WHOST-PREMIO-MAX */
                        _.Display($" PRM MAX={WHOST_PREMIO_MAX}");

                        /*" -2901- DISPLAY ' DT PROP=' DATA-PROPOSTA */
                        _.Display($" DT PROP={PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA}");

                        /*" -2902- DISPLAY ' CODPLAN=' BILHECOB-COD-OPCAO-PLANO */
                        _.Display($" CODPLAN={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO}");

                        /*" -2903- DISPLAY ' WTEMCOBER=' W-TEM-COBERTURA */
                        _.Display($" WTEMCOBER={WORK_AREA.W_TEM_COBERTURA}");

                        /*" -2905- DISPLAY 'PARAGRAFO=' PARAGRAFO ' SQLCODE ' WSQLCODE */

                        $"PARAGRAFO={AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO} SQLCODE {AREA_ABEND.WABEND.WSQLCODE}"
                        .Display();

                        /*" -2906- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2907- ELSE */
                    }

                }

            }
            else
            {


                /*" -2907- MOVE 0 TO W-TEM-COBERTURA. */
                _.Move(0, WORK_AREA.W_TEM_COBERTURA);
            }


        }

        [StopWatch]
        /*" R2351-00-OBTER-COBERTURA-DB-SELECT-1 */
        public void R2351_00_OBTER_COBERTURA_DB_SELECT_1()
        {
            /*" -2863- EXEC SQL SELECT COD_OPCAO_PLANO , COD_PRODUTO INTO :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO, :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = :DCLBILHETE-COBERTURA.BILHECOB-COD-EMPRESA AND MODALI_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-MODALI-COBERTURA AND RAMO_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-RAMO-COBERTURA AND PRM_TOTAL >= :WHOST-PREMIO-MIN AND PRM_TOTAL <= :WHOST-PREMIO-MAX AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA <> '9998-12-31' AND COD_PRODUTO = :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO WITH UR END-EXEC */

            var r2351_00_OBTER_COBERTURA_DB_SELECT_1_Query1 = new R2351_00_OBTER_COBERTURA_DB_SELECT_1_Query1()
            {
                BILHECOB_MODALI_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA.ToString(),
                BILHECOB_RAMO_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA.ToString(),
                BILHECOB_COD_EMPRESA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA.ToString(),
                BILHECOB_COD_PRODUTO = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO.ToString(),
                DATA_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.ToString(),
                WHOST_PREMIO_MIN = WHOST_PREMIO_MIN.ToString(),
                WHOST_PREMIO_MAX = WHOST_PREMIO_MAX.ToString(),
            };

            var executed_1 = R2351_00_OBTER_COBERTURA_DB_SELECT_1_Query1.Execute(r2351_00_OBTER_COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHECOB_COD_OPCAO_PLANO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO);
                _.Move(executed_1.BILHECOB_COD_PRODUTO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2351_99_SAIDA*/

        [StopWatch]
        /*" R2352-00-OBTER-COBERTURA-SECTION */
        private void R2352_00_OBTER_COBERTURA_SECTION()
        {
            /*" -2915- MOVE '2352-00-OBTER-COBERTURA      ' TO PARAGRAFO. */
            _.Move("2352-00-OBTER-COBERTURA      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2917- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2919- MOVE 'SELECT BILHETE COBERTURA     ' TO COMANDO. */
            _.Move("SELECT BILHETE COBERTURA     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2920- COMPUTE WHOST-PREMIO-MIN = BILHECOB-PRM-TOTAL - 1 */
            WHOST_PREMIO_MIN.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL - 1;

            /*" -2922- COMPUTE WHOST-PREMIO-MAX = BILHECOB-PRM-TOTAL + 1 */
            WHOST_PREMIO_MAX.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL + 1;

            /*" -2946- PERFORM R2352_00_OBTER_COBERTURA_DB_SELECT_1 */

            R2352_00_OBTER_COBERTURA_DB_SELECT_1();

            /*" -2949- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -2950- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2951- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2952- MOVE 1 TO W-TEM-COBERTURA */
                    _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                    /*" -2953- ELSE */
                }
                else
                {


                    /*" -2954- MOVE 1 TO W-TEM-COBERTURA */
                    _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                    /*" -2955- DISPLAY 'PROBLEMAS SELECT BILHETE COBERTURA' */
                    _.Display($"PROBLEMAS SELECT BILHETE COBERTURA");

                    /*" -2957- DISPLAY 'PROPOSTA ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -2958- DISPLAY ' PREMIO =' BILHECOB-PRM-TOTAL */
                    _.Display($" PREMIO ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL}");

                    /*" -2959- DISPLAY ' EMPRESA=' BILHECOB-COD-EMPRESA */
                    _.Display($" EMPRESA={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA}");

                    /*" -2960- DISPLAY ' MODALID=' BILHECOB-MODALI-COBERTURA */
                    _.Display($" MODALID={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA}");

                    /*" -2961- DISPLAY ' RAMO   =' BILHECOB-RAMO-COBERTURA */
                    _.Display($" RAMO   ={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA}");

                    /*" -2962- DISPLAY ' PRM MIN=' WHOST-PREMIO-MIN */
                    _.Display($" PRM MIN={WHOST_PREMIO_MIN}");

                    /*" -2963- DISPLAY ' PRM MAX=' WHOST-PREMIO-MAX */
                    _.Display($" PRM MAX={WHOST_PREMIO_MAX}");

                    /*" -2964- DISPLAY ' DT PROP=' DATA-PROPOSTA */
                    _.Display($" DT PROP={PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA}");

                    /*" -2965- DISPLAY ' CODPLAN=' BILHECOB-COD-OPCAO-PLANO */
                    _.Display($" CODPLAN={BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO}");

                    /*" -2966- DISPLAY ' WTEMCOBER=' W-TEM-COBERTURA */
                    _.Display($" WTEMCOBER={WORK_AREA.W_TEM_COBERTURA}");

                    /*" -2968- DISPLAY 'PARAGRAFO=' PARAGRAFO ' SQLCODE ' WSQLCODE */

                    $"PARAGRAFO={AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO} SQLCODE {AREA_ABEND.WABEND.WSQLCODE}"
                    .Display();

                    /*" -2969- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2970- END-IF */
                }


                /*" -2971- ELSE */
            }
            else
            {


                /*" -2976- IF BILHECOB-COD-OPCAO-PLANO EQUAL 11 */

                if (BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO == 11)
                {

                    /*" -2977- MOVE 1 TO W-TEM-COBERTURA */
                    _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                    /*" -2978- ELSE */
                }
                else
                {


                    /*" -2979- MOVE 0 TO W-TEM-COBERTURA */
                    _.Move(0, WORK_AREA.W_TEM_COBERTURA);

                    /*" -2980- END-IF */
                }


                /*" -2980- END-IF. */
            }


        }

        [StopWatch]
        /*" R2352-00-OBTER-COBERTURA-DB-SELECT-1 */
        public void R2352_00_OBTER_COBERTURA_DB_SELECT_1()
        {
            /*" -2946- EXEC SQL SELECT COD_OPCAO_PLANO , COD_PRODUTO INTO :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO, :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = :DCLBILHETE-COBERTURA.BILHECOB-COD-EMPRESA AND MODALI_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-MODALI-COBERTURA AND RAMO_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-RAMO-COBERTURA AND PRM_TOTAL >= :WHOST-PREMIO-MIN AND PRM_TOTAL <= :WHOST-PREMIO-MAX AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA = '9999-12-31' AND COD_PRODUTO = :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO WITH UR END-EXEC */

            var r2352_00_OBTER_COBERTURA_DB_SELECT_1_Query1 = new R2352_00_OBTER_COBERTURA_DB_SELECT_1_Query1()
            {
                BILHECOB_MODALI_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA.ToString(),
                BILHECOB_RAMO_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA.ToString(),
                BILHECOB_COD_EMPRESA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA.ToString(),
                BILHECOB_COD_PRODUTO = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO.ToString(),
                DATA_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.ToString(),
                WHOST_PREMIO_MIN = WHOST_PREMIO_MIN.ToString(),
                WHOST_PREMIO_MAX = WHOST_PREMIO_MAX.ToString(),
            };

            var executed_1 = R2352_00_OBTER_COBERTURA_DB_SELECT_1_Query1.Execute(r2352_00_OBTER_COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHECOB_COD_OPCAO_PLANO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO);
                _.Move(executed_1.BILHECOB_COD_PRODUTO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2352_99_SAIDA*/

        [StopWatch]
        /*" R2353-00-OBTER-COBERTURA-SECTION */
        private void R2353_00_OBTER_COBERTURA_SECTION()
        {
            /*" -2988- MOVE '2353-00-OBTER-COBERTURA      ' TO PARAGRAFO. */
            _.Move("2353-00-OBTER-COBERTURA      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2990- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2992- MOVE 'SELECT BILHETE COBERTURA     ' TO COMANDO. */
            _.Move("SELECT BILHETE COBERTURA     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2993- COMPUTE WHOST-PREMIO-MIN = BILHECOB-PRM-TOTAL - 1 */
            WHOST_PREMIO_MIN.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL - 1;

            /*" -2995- COMPUTE WHOST-PREMIO-MAX = BILHECOB-PRM-TOTAL + 1 */
            WHOST_PREMIO_MAX.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL + 1;

            /*" -3015- PERFORM R2353_00_OBTER_COBERTURA_DB_SELECT_1 */

            R2353_00_OBTER_COBERTURA_DB_SELECT_1();

            /*" -3018- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3019- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3020- MOVE 1 TO W-TEM-COBERTURA */
                    _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                    /*" -3021- ELSE */
                }
                else
                {


                    /*" -3022- MOVE 1 TO W-TEM-COBERTURA */
                    _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                    /*" -3023- DISPLAY 'PF0602B*PROBLEMAS SELECT BILHETE COBERTURA' */
                    _.Display($"PF0602B*PROBLEMAS SELECT BILHETE COBERTURA");

                    /*" -3025- DISPLAY 'PROPOSTA ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -3026- DISPLAY 'SQLCODE  ' SQLCODE */
                    _.Display($"SQLCODE  {DB.SQLCODE}");

                    /*" -3027- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3028- ELSE */
                }

            }
            else
            {


                /*" -3029- MOVE 0 TO W-TEM-COBERTURA. */
                _.Move(0, WORK_AREA.W_TEM_COBERTURA);
            }


        }

        [StopWatch]
        /*" R2353-00-OBTER-COBERTURA-DB-SELECT-1 */
        public void R2353_00_OBTER_COBERTURA_DB_SELECT_1()
        {
            /*" -3015- EXEC SQL SELECT COD_OPCAO_PLANO , COD_PRODUTO INTO :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO, :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = :DCLBILHETE-COBERTURA.BILHECOB-COD-EMPRESA AND MODALI_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-MODALI-COBERTURA AND RAMO_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-RAMO-COBERTURA AND PRM_TOTAL >= :WHOST-PREMIO-MIN AND PRM_TOTAL <= :WHOST-PREMIO-MAX AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA = '9997-12-31' WITH UR END-EXEC */

            var r2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1 = new R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1()
            {
                BILHECOB_MODALI_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA.ToString(),
                BILHECOB_RAMO_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA.ToString(),
                BILHECOB_COD_EMPRESA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA.ToString(),
                DATA_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.ToString(),
                WHOST_PREMIO_MIN = WHOST_PREMIO_MIN.ToString(),
                WHOST_PREMIO_MAX = WHOST_PREMIO_MAX.ToString(),
            };

            var executed_1 = R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1.Execute(r2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHECOB_COD_OPCAO_PLANO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO);
                _.Move(executed_1.BILHECOB_COD_PRODUTO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2353_99_SAIDA*/

        [StopWatch]
        /*" R2354-00-OBTER-COBERTURA-SECTION */
        private void R2354_00_OBTER_COBERTURA_SECTION()
        {
            /*" -3036- MOVE '2354-00-OBTER-COBERTURA      ' TO PARAGRAFO. */
            _.Move("2354-00-OBTER-COBERTURA      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3038- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3040- MOVE 'SELECT BILHETE COBERTURA     ' TO COMANDO. */
            _.Move("SELECT BILHETE COBERTURA     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3041- COMPUTE WHOST-PREMIO-MIN = BILHECOB-PRM-TOTAL - 1 */
            WHOST_PREMIO_MIN.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL - 1;

            /*" -3044- COMPUTE WHOST-PREMIO-MAX = BILHECOB-PRM-TOTAL + 1 */
            WHOST_PREMIO_MAX.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL + 1;

            /*" -3046- IF COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 8528 OR 8529 OR 8533 OR 8534 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.In("8528", "8529", "8533", "8534"))
            {

                /*" -3047- PERFORM R23543-00-OBTER-COBER-COM-PRO */

                R23543_00_OBTER_COBER_COM_PRO_SECTION();

                /*" -3048- ELSE */
            }
            else
            {


                /*" -3049- PERFORM R23541-00-OBTER-COBER-SEM-PRO */

                R23541_00_OBTER_COBER_SEM_PRO_SECTION();

                /*" -3051- END-IF */
            }


            /*" -3052- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3053- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3054- MOVE 1 TO W-TEM-COBERTURA */
                    _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                    /*" -3055- ELSE */
                }
                else
                {


                    /*" -3056- MOVE 1 TO W-TEM-COBERTURA */
                    _.Move(1, WORK_AREA.W_TEM_COBERTURA);

                    /*" -3057- DISPLAY 'PF0602B*PROBLEMAS SELECT BILHETE COBERTURA' */
                    _.Display($"PF0602B*PROBLEMAS SELECT BILHETE COBERTURA");

                    /*" -3059- DISPLAY 'PROPOSTA ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -3060- DISPLAY 'SQLCODE  ' SQLCODE */
                    _.Display($"SQLCODE  {DB.SQLCODE}");

                    /*" -3061- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3062- ELSE */
                }

            }
            else
            {


                /*" -3062- MOVE 0 TO W-TEM-COBERTURA. */
                _.Move(0, WORK_AREA.W_TEM_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2354_99_SAIDA*/

        [StopWatch]
        /*" R23541-00-OBTER-COBER-SEM-PRO-SECTION */
        private void R23541_00_OBTER_COBER_SEM_PRO_SECTION()
        {
            /*" -3071- MOVE 'R23541-00-OBTER-COBER-SEM-PRO' TO PARAGRAFO. */
            _.Move("R23541-00-OBTER-COBER-SEM-PRO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3072- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3074- MOVE 'SELECT BILHETE COBERTURA (1) ' TO COMANDO. */
            _.Move("SELECT BILHETE COBERTURA (1) ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3095- PERFORM R23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1 */

            R23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1();

            /*" -3097- . */

        }

        [StopWatch]
        /*" R23541-00-OBTER-COBER-SEM-PRO-DB-SELECT-1 */
        public void R23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1()
        {
            /*" -3095- EXEC SQL SELECT COD_OPCAO_PLANO , COD_PRODUTO INTO :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO, :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = :DCLBILHETE-COBERTURA.BILHECOB-COD-EMPRESA AND MODALI_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-MODALI-COBERTURA AND RAMO_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-RAMO-COBERTURA AND PRM_TOTAL >= :WHOST-PREMIO-MIN AND PRM_TOTAL <= :WHOST-PREMIO-MAX AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA ORDER BY DATA_INIVIGENCIA DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1_Query1 = new R23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1_Query1()
            {
                BILHECOB_MODALI_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA.ToString(),
                BILHECOB_RAMO_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA.ToString(),
                BILHECOB_COD_EMPRESA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA.ToString(),
                DATA_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.ToString(),
                WHOST_PREMIO_MIN = WHOST_PREMIO_MIN.ToString(),
                WHOST_PREMIO_MAX = WHOST_PREMIO_MAX.ToString(),
            };

            var executed_1 = R23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1_Query1.Execute(r23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHECOB_COD_OPCAO_PLANO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO);
                _.Move(executed_1.BILHECOB_COD_PRODUTO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R23541_99_SAIDA*/

        [StopWatch]
        /*" R23543-00-OBTER-COBER-COM-PRO-SECTION */
        private void R23543_00_OBTER_COBER_COM_PRO_SECTION()
        {
            /*" -3110- MOVE 'R23543-00-OBTER-COBER-COM-PRO' TO PARAGRAFO. */
            _.Move("R23543-00-OBTER-COBER-COM-PRO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3111- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3113- MOVE 'SELECT BILHETE COBERTURA (2) ' TO COMANDO. */
            _.Move("SELECT BILHETE COBERTURA (2) ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3136- PERFORM R23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1 */

            R23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1();

            /*" -3138- . */

        }

        [StopWatch]
        /*" R23543-00-OBTER-COBER-COM-PRO-DB-SELECT-1 */
        public void R23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1()
        {
            /*" -3136- EXEC SQL SELECT COD_OPCAO_PLANO , COD_PRODUTO INTO :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO, :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = :DCLBILHETE-COBERTURA.BILHECOB-COD-EMPRESA AND MODALI_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-MODALI-COBERTURA AND RAMO_COBERTURA = :DCLBILHETE-COBERTURA.BILHECOB-RAMO-COBERTURA AND PRM_TOTAL >= :WHOST-PREMIO-MIN AND PRM_TOTAL <= :WHOST-PREMIO-MAX AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND COD_PRODUTO = :DCLPROPOSTA-FIDELIZ.COD-PLANO ORDER BY DATA_INIVIGENCIA DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1_Query1 = new R23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1_Query1()
            {
                BILHECOB_MODALI_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA.ToString(),
                BILHECOB_RAMO_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA.ToString(),
                BILHECOB_COD_EMPRESA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_EMPRESA.ToString(),
                DATA_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.ToString(),
                COD_PLANO = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.ToString(),
                WHOST_PREMIO_MIN = WHOST_PREMIO_MIN.ToString(),
                WHOST_PREMIO_MAX = WHOST_PREMIO_MAX.ToString(),
            };

            var executed_1 = R23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1_Query1.Execute(r23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHECOB_COD_OPCAO_PLANO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO);
                _.Move(executed_1.BILHECOB_COD_PRODUTO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R23543_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-TRATA-ENDERECOS-SECTION */
        private void R2400_00_TRATA_ENDERECOS_SECTION()
        {
            /*" -3146- MOVE '2400-00-TRATA-ENDERECOS      ' TO PARAGRAFO. */
            _.Move("2400-00-TRATA-ENDERECOS      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3148- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3149- IF WS-JA-E-CLIENTE EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE == 1)
            {

                /*" -3150- MOVE 'SELECT SEGUROS.ENDERECOS     ' TO COMANDO */
                _.Move("SELECT SEGUROS.ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -3166- PERFORM R2400_00_TRATA_ENDERECOS_DB_SELECT_1 */

                R2400_00_TRATA_ENDERECOS_DB_SELECT_1();

                /*" -3168- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3169- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -3170- PERFORM R2420-00-INSERT-ENDERECOS */

                        R2420_00_INSERT_ENDERECOS_SECTION();

                        /*" -3171- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
                        _.Move("I", WS_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                        /*" -3172- ELSE */
                    }
                    else
                    {


                        /*" -3173- DISPLAY 'PF0602B - PROBLEMAS ACESSO ENDERECOS ' */
                        _.Display($"PF0602B - PROBLEMAS ACESSO ENDERECOS ");

                        /*" -3174- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3175- END-IF */
                    }


                    /*" -3176- ELSE */
                }
                else
                {


                    /*" -3177- PERFORM R2410-00-ALTERA-ENDERECOS */

                    R2410_00_ALTERA_ENDERECOS_SECTION();

                    /*" -3178- END-IF */
                }


                /*" -3179- ELSE */
            }
            else
            {


                /*" -3180- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
                _.Move("I", WS_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                /*" -3181- PERFORM R2420-00-INSERT-ENDERECOS */

                R2420_00_INSERT_ENDERECOS_SECTION();

                /*" -3181- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-00-TRATA-ENDERECOS-DB-SELECT-1 */
        public void R2400_00_TRATA_ENDERECOS_DB_SELECT_1()
        {
            /*" -3166- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :DCLENDERECOS.ENDERECO-ENDERECO, :DCLENDERECOS.ENDERECO-BAIRRO, :DCLENDERECOS.ENDERECO-CIDADE, :DCLENDERECOS.ENDERECO-SIGLA-UF, :DCLENDERECOS.ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE AND OCORR_ENDERECO = 1 AND COD_ENDERECO = 2 WITH UR END-EXEC */

            var r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 = new R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1.Execute(r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-ALTERA-ENDERECOS-SECTION */
        private void R2410_00_ALTERA_ENDERECOS_SECTION()
        {
            /*" -3189- MOVE '2410-00-ALTERA-ENDERECOS     ' TO PARAGRAFO. */
            _.Move("2410-00-ALTERA-ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3191- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3192- MOVE SPACES TO WWORK-TIPO-MOVIMENTO */
            _.Move("", WS_GECLIMOV.WWORK_TIPO_MOVIMENTO);

            /*" -3203- IF ENDERECO-ENDERECO OF DCLENDERECOS EQUAL ENDERECO OF DCLPESSOA-ENDERECO AND ENDERECO-BAIRRO OF DCLENDERECOS EQUAL BAIRRO OF DCLPESSOA-ENDERECO AND ENDERECO-CIDADE OF DCLENDERECOS EQUAL CIDADE OF DCLPESSOA-ENDERECO AND ENDERECO-SIGLA-UF OF DCLENDERECOS EQUAL SIGLA-UF OF DCLPESSOA-ENDERECO AND ENDERECO-CEP OF DCLENDERECOS EQUAL CEP OF DCLPESSOA-ENDERECO NEXT SENTENCE */

            if (ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO == PESENDER.DCLPESSOA_ENDERECO.ENDERECO && ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO == PESENDER.DCLPESSOA_ENDERECO.BAIRRO && ENDERECO.DCLENDERECOS.ENDERECO_CIDADE == PESENDER.DCLPESSOA_ENDERECO.CIDADE && ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF == PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF && ENDERECO.DCLENDERECOS.ENDERECO_CEP == PESENDER.DCLPESSOA_ENDERECO.CEP)
            {

                /*" -3204- ELSE */
            }
            else
            {


                /*" -3205- MOVE 'UPDATE SEGUROS.ENDERECOS     ' TO COMANDO */
                _.Move("UPDATE SEGUROS.ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -3206- MOVE 'A' TO WWORK-TIPO-MOVIMENTO */
                _.Move("A", WS_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                /*" -3219- PERFORM R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1 */

                R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1();

                /*" -3221- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3222- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -3223- DISPLAY 'PF0602B - ENDERECO NAO CADASTRADO ' */
                        _.Display($"PF0602B - ENDERECO NAO CADASTRADO ");

                        /*" -3224- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3225- ELSE */
                    }
                    else
                    {


                        /*" -3226- DISPLAY 'PF0602B - PROBLEMAS ACESSO ENDERECOS ' */
                        _.Display($"PF0602B - PROBLEMAS ACESSO ENDERECOS ");

                        /*" -3226- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R2410-00-ALTERA-ENDERECOS-DB-UPDATE-1 */
        public void R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1()
        {
            /*" -3219- EXEC SQL UPDATE SEGUROS.ENDERECOS SET ENDERECO = :DCLPESSOA-ENDERECO.ENDERECO, BAIRRO = :DCLPESSOA-ENDERECO.BAIRRO, CIDADE = :DCLPESSOA-ENDERECO.CIDADE, SIGLA_UF = :DCLPESSOA-ENDERECO.SIGLA-UF, CEP = :DCLPESSOA-ENDERECO.CEP, DDD = :WHOST-DDD, TELEFONE = :WHOST-TELEFONE, FAX = :WHOST-FAX WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE AND OCORR_ENDERECO = 1 AND COD_ENDERECO = 2 END-EXEC */

            var r2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1 = new R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1()
            {
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                WHOST_TELEFONE = WHOST_TELEFONE.ToString(),
                WHOST_DDD = WHOST_DDD.ToString(),
                WHOST_FAX = WHOST_FAX.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1.Execute(r2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-SECTION */
        private void R2420_00_INSERT_ENDERECOS_SECTION()
        {
            /*" -3234- MOVE '2420-00-INSERT-ENDERECOS     ' TO PARAGRAFO. */
            _.Move("2420-00-INSERT-ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3236- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3254- PERFORM R2420_00_INSERT_ENDERECOS_DB_INSERT_1 */

            R2420_00_INSERT_ENDERECOS_DB_INSERT_1();

            /*" -3257- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -3258- DISPLAY 'PF0602B - PROBLEMAS NO INSERT (ENDERECOS)... ' */
                _.Display($"PF0602B - PROBLEMAS NO INSERT (ENDERECOS)... ");

                /*" -3259- DISPLAY 'PF0602B - CODCLIEN ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"PF0602B - CODCLIEN {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -3259- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-DB-INSERT-1 */
        public void R2420_00_INSERT_ENDERECOS_DB_INSERT_1()
        {
            /*" -3254- EXEC SQL INSERT INTO SEGUROS.ENDERECOS VALUES (:DCLCLIENTES.COD-CLIENTE, 2, 1, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.CEP, :WHOST-DDD, :WHOST-TELEFONE, :WHOST-FAX, 0, '0' , NULL , NULL) END-EXEC. */

            var r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 = new R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                WHOST_DDD = WHOST_DDD.ToString(),
                WHOST_TELEFONE = WHOST_TELEFONE.ToString(),
                WHOST_FAX = WHOST_FAX.ToString(),
            };

            R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1.Execute(r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2420_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-INSERT-PROP-EST-SECTION */
        private void R2500_00_INSERT_PROP_EST_SECTION()
        {
            /*" -3267- MOVE '2500-00-INSERT-PROP-EST' TO PARAGRAFO. */
            _.Move("2500-00-INSERT-PROP-EST", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3269- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3270- MOVE 0 TO PROPESTI-COD-FONTE */
            _.Move(0, PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_COD_FONTE);

            /*" -3271- MOVE 0 TO PROPESTI-NUM-PROPOSTA */
            _.Move(0, PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_NUM_PROPOSTA);

            /*" -3272- MOVE '0' TO PROPESTI-COD-FROTA */
            _.Move("0", PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_COD_FROTA);

            /*" -3273- MOVE 0 TO PROPESTI-NUM-APOLICE */
            _.Move(0, PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_NUM_APOLICE);

            /*" -3276- MOVE BILHETE-NUM-BILHETE OF DCLBILHETE TO PROPESTI-NUM-BILHETE */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_NUM_BILHETE);

            /*" -3277- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 9 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 9)
            {

                /*" -3278- MOVE 8299 TO PROPESTI-COD-PRODUTO */
                _.Move(8299, PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_COD_PRODUTO);

                /*" -3279- ELSE */
            }
            else
            {


                /*" -3281- MOVE 7107 TO PROPESTI-COD-PRODUTO. */
                _.Move(7107, PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_COD_PRODUTO);
            }


            /*" -3284- MOVE CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ TO PROPESTI-COD-CCT. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE, PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_COD_CCT);

            /*" -3294- PERFORM R2500_00_INSERT_PROP_EST_DB_INSERT_1 */

            R2500_00_INSERT_PROP_EST_DB_INSERT_1();

            /*" -3297- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3298- DISPLAY 'PF0602B*PROBLEMAS NO INSERT DA PROP-ESTIPULANTE' */
                _.Display($"PF0602B*PROBLEMAS NO INSERT DA PROP-ESTIPULANTE");

                /*" -3298- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-INSERT-PROP-EST-DB-INSERT-1 */
        public void R2500_00_INSERT_PROP_EST_DB_INSERT_1()
        {
            /*" -3294- EXEC SQL INSERT INTO SEGUROS.PROP_ESTIPULANTE VALUES (:PROPESTI-COD-FONTE , :PROPESTI-NUM-PROPOSTA, :PROPESTI-COD-PRODUTO , :PROPESTI-COD-CCT , :PROPESTI-COD-FROTA , :PROPESTI-NUM-APOLICE , :PROPESTI-NUM-BILHETE , CURRENT TIMESTAMP) END-EXEC. */

            var r2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1 = new R2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1()
            {
                PROPESTI_COD_FONTE = PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_COD_FONTE.ToString(),
                PROPESTI_NUM_PROPOSTA = PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_NUM_PROPOSTA.ToString(),
                PROPESTI_COD_PRODUTO = PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_COD_PRODUTO.ToString(),
                PROPESTI_COD_CCT = PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_COD_CCT.ToString(),
                PROPESTI_COD_FROTA = PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_COD_FROTA.ToString(),
                PROPESTI_NUM_APOLICE = PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_NUM_APOLICE.ToString(),
                PROPESTI_NUM_BILHETE = PROPESTI.DCLPROP_ESTIPULANTE.PROPESTI_NUM_BILHETE.ToString(),
            };

            R2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1.Execute(r2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-TRATA-EMAIL-SECTION */
        private void R2600_00_TRATA_EMAIL_SECTION()
        {
            /*" -3306- MOVE 'R2600-00-TRATA-EMAIL' TO PARAGRAFO. */
            _.Move("R2600-00-TRATA-EMAIL", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3308- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3311- MOVE COD-CLIENTE OF DCLCLIENTES TO CLIENEMA-COD-CLIENTE */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE);

            /*" -3312- IF WS-JA-E-CLIENTE EQUAL 0 */

            if (WORK_AREA.WS_JA_E_CLIENTE == 0)
            {

                /*" -3314- PERFORM R2610-00-INSERE-CLIENTE-EMAIL THRU R2610-99-SAIDA */

                R2610_00_INSERE_CLIENTE_EMAIL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/


                /*" -3315- GO TO R2600-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/ //GOTO
                return;

                /*" -3317- END-IF */
            }


            /*" -3323- PERFORM R2600_00_TRATA_EMAIL_DB_SELECT_1 */

            R2600_00_TRATA_EMAIL_DB_SELECT_1();

            /*" -3326- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3327- DISPLAY 'PF0602B - PROBLEMAS NO ACESSO A CLIENTE_EMAIL I' */
                _.Display($"PF0602B - PROBLEMAS NO ACESSO A CLIENTE_EMAIL I");

                /*" -3329- DISPLAY 'CODIGO CLIENTE..............  ' CLIENEMA-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE..............  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE}");

                /*" -3331- DISPLAY 'NUMERO PROPOSTA.............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO PROPOSTA.............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -3333- DISPLAY 'NUMERO IDENTIFICACAO........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO IDENTIFICACAO........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -3334- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3336- END-IF */
            }


            /*" -3337- IF CLIENEMA-SEQ-EMAIL EQUAL ZEROS */

            if (CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL == 00)
            {

                /*" -3339- PERFORM R2610-00-INSERE-CLIENTE-EMAIL THRU R2610-99-SAIDA */

                R2610_00_INSERE_CLIENTE_EMAIL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/


                /*" -3340- GO TO R2600-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/ //GOTO
                return;

                /*" -3342- END-IF */
            }


            /*" -3349- PERFORM R2600_00_TRATA_EMAIL_DB_SELECT_2 */

            R2600_00_TRATA_EMAIL_DB_SELECT_2();

            /*" -3352- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3353- DISPLAY 'PF0602B - PROBLEMAS NO ACESSO A CLIENTE_EMAIL II' */
                _.Display($"PF0602B - PROBLEMAS NO ACESSO A CLIENTE_EMAIL II");

                /*" -3355- DISPLAY 'CODIGO CLIENTE..............  ' CLIENEMA-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE..............  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE}");

                /*" -3357- DISPLAY 'SEQUENCIAL EMAIL............  ' CLIENEMA-SEQ-EMAIL */
                _.Display($"SEQUENCIAL EMAIL............  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL}");

                /*" -3359- DISPLAY 'NUMERO PROPOSTA.............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO PROPOSTA.............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -3361- DISPLAY 'NUMERO IDENTIFICACAO........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO IDENTIFICACAO........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -3362- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3364- END-IF */
            }


            /*" -3365- IF CLIENEMA-EMAIL NOT EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL != PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -3367- PERFORM R2620-00-UPDATE-CLIENTE-EMAIL THRU R2620-99-SAIDA */

                R2620_00_UPDATE_CLIENTE_EMAIL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2620_99_SAIDA*/


                /*" -3369- END-IF */
            }


            /*" -3369- . */

        }

        [StopWatch]
        /*" R2600-00-TRATA-EMAIL-DB-SELECT-1 */
        public void R2600_00_TRATA_EMAIL_DB_SELECT_1()
        {
            /*" -3323- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL), 0) INTO :CLIENEMA-SEQ-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :CLIENEMA-COD-CLIENTE WITH UR END-EXEC */

            var r2600_00_TRATA_EMAIL_DB_SELECT_1_Query1 = new R2600_00_TRATA_EMAIL_DB_SELECT_1_Query1()
            {
                CLIENEMA_COD_CLIENTE = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2600_00_TRATA_EMAIL_DB_SELECT_1_Query1.Execute(r2600_00_TRATA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_SEQ_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-TRATA-EMAIL-DB-SELECT-2 */
        public void R2600_00_TRATA_EMAIL_DB_SELECT_2()
        {
            /*" -3349- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :CLIENEMA-COD-CLIENTE AND SEQ_EMAIL = :CLIENEMA-SEQ-EMAIL WITH UR END-EXEC */

            var r2600_00_TRATA_EMAIL_DB_SELECT_2_Query1 = new R2600_00_TRATA_EMAIL_DB_SELECT_2_Query1()
            {
                CLIENEMA_COD_CLIENTE = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE.ToString(),
                CLIENEMA_SEQ_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.ToString(),
            };

            var executed_1 = R2600_00_TRATA_EMAIL_DB_SELECT_2_Query1.Execute(r2600_00_TRATA_EMAIL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }

        [StopWatch]
        /*" R2610-00-INSERE-CLIENTE-EMAIL-SECTION */
        private void R2610_00_INSERE_CLIENTE_EMAIL_SECTION()
        {
            /*" -3377- MOVE 'R2610-00-INSERE-CLIENTE-EMAIL' TO PARAGRAFO */
            _.Move("R2610-00-INSERE-CLIENTE-EMAIL", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3379- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3380- MOVE 1 TO CLIENEMA-SEQ-EMAIL */
            _.Move(1, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL);

            /*" -3383- MOVE EMAIL OF DCLPESSOA-EMAIL TO CLIENEMA-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);

            /*" -3389- PERFORM R2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1 */

            R2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1();

            /*" -3392- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3393- DISPLAY 'PF0602B - PROBLEMAS AO INSERIR CLIENTE_EMAIL' */
                _.Display($"PF0602B - PROBLEMAS AO INSERIR CLIENTE_EMAIL");

                /*" -3395- DISPLAY 'CODIGO CLIENTE..............  ' CLIENEMA-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE..............  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE}");

                /*" -3397- DISPLAY 'SEQUENCIAL EMAIL............  ' CLIENEMA-SEQ-EMAIL */
                _.Display($"SEQUENCIAL EMAIL............  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL}");

                /*" -3399- DISPLAY 'EMAIL.......................  ' CLIENEMA-EMAIL */
                _.Display($"EMAIL.......................  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL}");

                /*" -3401- DISPLAY 'NUMERO PROPOSTA.............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO PROPOSTA.............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -3403- DISPLAY 'NUMERO IDENTIFICACAO........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO IDENTIFICACAO........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -3404- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3406- END-IF */
            }


            /*" -3406- . */

        }

        [StopWatch]
        /*" R2610-00-INSERE-CLIENTE-EMAIL-DB-INSERT-1 */
        public void R2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1()
        {
            /*" -3389- EXEC SQL INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES ( :CLIENEMA-COD-CLIENTE , :CLIENEMA-SEQ-EMAIL , :CLIENEMA-EMAIL ) END-EXEC */

            var r2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1_Insert1 = new R2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1_Insert1()
            {
                CLIENEMA_COD_CLIENTE = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE.ToString(),
                CLIENEMA_SEQ_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.ToString(),
                CLIENEMA_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL.ToString(),
            };

            R2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1_Insert1.Execute(r2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R2620-00-UPDATE-CLIENTE-EMAIL-SECTION */
        private void R2620_00_UPDATE_CLIENTE_EMAIL_SECTION()
        {
            /*" -3414- MOVE 'R2620-00-UPDATE-CLIENTE-EMAIL' TO PARAGRAFO */
            _.Move("R2620-00-UPDATE-CLIENTE-EMAIL", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3416- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3419- MOVE EMAIL OF DCLPESSOA-EMAIL TO CLIENEMA-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);

            /*" -3424- PERFORM R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1 */

            R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1();

            /*" -3427- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3428- DISPLAY 'PF0602B - PROBLEMAS AO ATUALIZAR CLIENTE_EMAIL' */
                _.Display($"PF0602B - PROBLEMAS AO ATUALIZAR CLIENTE_EMAIL");

                /*" -3430- DISPLAY 'CODIGO CLIENTE..............  ' CLIENEMA-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE..............  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE}");

                /*" -3432- DISPLAY 'SEQUENCIAL EMAIL............  ' CLIENEMA-SEQ-EMAIL */
                _.Display($"SEQUENCIAL EMAIL............  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL}");

                /*" -3434- DISPLAY 'EMAIL.......................  ' CLIENEMA-EMAIL */
                _.Display($"EMAIL.......................  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL}");

                /*" -3436- DISPLAY 'NUMERO PROPOSTA.............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO PROPOSTA.............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -3438- DISPLAY 'NUMERO IDENTIFICACAO........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO IDENTIFICACAO........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -3439- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3441- END-IF */
            }


            /*" -3441- . */

        }

        [StopWatch]
        /*" R2620-00-UPDATE-CLIENTE-EMAIL-DB-UPDATE-1 */
        public void R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1()
        {
            /*" -3424- EXEC SQL UPDATE SEGUROS.CLIENTE_EMAIL SET EMAIL = :CLIENEMA-EMAIL WHERE COD_CLIENTE = :CLIENEMA-COD-CLIENTE AND SEQ_EMAIL = :CLIENEMA-SEQ-EMAIL END-EXEC */

            var r2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1 = new R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1()
            {
                CLIENEMA_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL.ToString(),
                CLIENEMA_COD_CLIENTE = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE.ToString(),
                CLIENEMA_SEQ_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.ToString(),
            };

            R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1.Execute(r2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2620_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERT-BILHETE-SECTION */
        private void R3000_00_INSERT_BILHETE_SECTION()
        {
            /*" -3449- MOVE '3000-00-INSERT-BILHETE      ' TO PARAGRAFO. */
            _.Move("3000-00-INSERT-BILHETE      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3451- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3455- IF WS-TEM-ERRO EQUAL 0 */

            if (WORK_AREA.WS_TEM_ERRO == 0)
            {

                /*" -3456- IF MUDA-SITUACAO EQUAL 'N' */

                if (WORK_AREA.MUDA_SITUACAO == "N")
                {

                    /*" -3457- MOVE '2' TO WHOST-SIT-REGISTRO */
                    _.Move("2", WHOST_SIT_REGISTRO);

                    /*" -3458- ELSE */
                }
                else
                {


                    /*" -3459- MOVE '0' TO WHOST-SIT-REGISTRO */
                    _.Move("0", WHOST_SIT_REGISTRO);

                    /*" -3460- ELSE */
                }

            }
            else
            {


                /*" -3461- IF MUDA-SITUACAO EQUAL 'N' */

                if (WORK_AREA.MUDA_SITUACAO == "N")
                {

                    /*" -3462- MOVE '3' TO WHOST-SIT-REGISTRO */
                    _.Move("3", WHOST_SIT_REGISTRO);

                    /*" -3463- ELSE */
                }
                else
                {


                    /*" -3465- MOVE '1' TO WHOST-SIT-REGISTRO. */
                    _.Move("1", WHOST_SIT_REGISTRO);
                }

            }


            /*" -3467- IF CANAL-GITEL AND WHOST-SIT-REGISTRO = '0' */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] && WHOST_SIT_REGISTRO == "0")
            {

                /*" -3468- MOVE '5' TO WHOST-SIT-REGISTRO */
                _.Move("5", WHOST_SIT_REGISTRO);

                /*" -3470- END-IF. */
            }


            /*" -3471- IF CANAL-ATM */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_ATM"])
            {

                /*" -3472- IF WHOST-SIT-REGISTRO = '0' */

                if (WHOST_SIT_REGISTRO == "0")
                {

                    /*" -3473- MOVE '0' TO WHOST-SIT-REGISTRO */
                    _.Move("0", WHOST_SIT_REGISTRO);

                    /*" -3474- ELSE */
                }
                else
                {


                    /*" -3475- MOVE '1' TO WHOST-SIT-REGISTRO */
                    _.Move("1", WHOST_SIT_REGISTRO);

                    /*" -3476- END-IF */
                }


                /*" -3478- END-IF. */
            }


            /*" -3479- IF ORIGEM-MARSH */

            if (WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_MARSH"])
            {

                /*" -3480- IF WHOST-SIT-REGISTRO = '0' */

                if (WHOST_SIT_REGISTRO == "0")
                {

                    /*" -3481- MOVE '5' TO WHOST-SIT-REGISTRO */
                    _.Move("5", WHOST_SIT_REGISTRO);

                    /*" -3482- ELSE */
                }
                else
                {


                    /*" -3483- MOVE 'F' TO WHOST-SIT-REGISTRO */
                    _.Move("F", WHOST_SIT_REGISTRO);

                    /*" -3484- END-IF */
                }


                /*" -3486- END-IF. */
            }


            /*" -3489- MOVE TAB-FONTE (AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE. */
            _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_15[PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR].TAB_FONTE, WHOST_FONTE);

            /*" -3491- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -3493- MOVE 5 TO WHOST-FONTE. */
                _.Move(5, WHOST_FONTE);
            }


            /*" -3494- IF VIND-FAIXA-RENDA-IND LESS ZEROS */

            if (VIND_FAIXA_RENDA_IND < 00)
            {

                /*" -3497- MOVE '0' TO FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ. */
                _.Move("0", PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND);
            }


            /*" -3498- IF VIND-FAIXA-RENDA-FAM LESS ZEROS */

            if (VIND_FAIXA_RENDA_FAM < 00)
            {

                /*" -3501- MOVE '0' TO FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ. */
                _.Move("0", PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM);
            }


            /*" -3502- IF FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ EQUAL SPACE */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND == " ")
            {

                /*" -3504- MOVE ZEROS TO BILHETE-BI-FAIXA-RENDA-IND */
                _.Move(0, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND);

                /*" -3505- ELSE */
            }
            else
            {


                /*" -3508- MOVE FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ TO BILHETE-BI-FAIXA-RENDA-IND. */
                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND);
            }


            /*" -3509- IF FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ EQUAL SPACE */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM == " ")
            {

                /*" -3511- MOVE ZEROS TO BILHETE-BI-FAIXA-RENDA-FAM */
                _.Move(0, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM);

                /*" -3512- ELSE */
            }
            else
            {


                /*" -3515- MOVE FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ TO BILHETE-BI-FAIXA-RENDA-FAM. */
                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM);
            }


            /*" -3516- IF FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ > 5 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND > 5)
            {

                /*" -3518- MOVE 5 TO BILHETE-BI-FAIXA-RENDA-IND */
                _.Move(5, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND);

                /*" -3519- ELSE */
            }
            else
            {


                /*" -3522- MOVE FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ TO BILHETE-BI-FAIXA-RENDA-IND. */
                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND);
            }


            /*" -3523- IF FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ > 5 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM > 5)
            {

                /*" -3525- MOVE 5 TO BILHETE-BI-FAIXA-RENDA-FAM */
                _.Move(5, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM);

                /*" -3526- ELSE */
            }
            else
            {


                /*" -3531- MOVE FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ TO BILHETE-BI-FAIXA-RENDA-FAM. */
                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM);
            }


            /*" -3532- IF BILHECOB-COD-OPCAO-PLANO EQUAL ZEROS */

            if (BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO == 00)
            {

                /*" -3533- IF WHOST-SIT-REGISTRO EQUAL '0' */

                if (WHOST_SIT_REGISTRO == "0")
                {

                    /*" -3536- DISPLAY 'BILHETE COM COBERTURA E SITUACAO ZERO' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '  ' NUM-SICOB OF DCLPROPOSTA-FIDELIZ */

                    $"BILHETE COM COBERTURA E SITUACAO ZERO{PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB}"
                    .Display();

                    /*" -3539- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3544- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 09 AND (ORIGEM-INTRANET OR ORIGEM-SIPEN-CAIXATEM OR ORIGEM-CX-AQUI-CCA) AND (CANAL-VENDA-PAPEL OR CANAL-INTERNET OR CANAL-INTRANET OR CANAL-CORRETOR) */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 09 && (WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_INTRANET"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_SIPEN_CAIXATEM"] || WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_CX_AQUI_CCA"]) && (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_INTERNET"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_INTRANET"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_CORRETOR"]))
            {

                /*" -3548- IF (COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 8521 OR 8528 OR 8529 OR 8530 OR 8531 OR 8532 OR 8533 OR 8534) */

                if ((PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.In("8521", "8528", "8529", "8530", "8531", "8532", "8533", "8534")))
                {

                    /*" -3549- MOVE 81 TO WHOST-RAMO */
                    _.Move(81, WHOST_RAMO);

                    /*" -3550- ELSE */
                }
                else
                {


                    /*" -3551- MOVE 37 TO WHOST-RAMO */
                    _.Move(37, WHOST_RAMO);

                    /*" -3552- END-IF */
                }


                /*" -3553- PERFORM R3002-01-ESQ-DEBITO-CARTAO */

                R3002_01_ESQ_DEBITO_CARTAO_SECTION();

                /*" -3554- IF WTEM-CARTAO EQUAL 'S' */

                if (WS_GECLIMOV.WTEM_CARTAO == "S")
                {

                    /*" -3555- MOVE 'C' TO WHOST-SIT-REGISTRO */
                    _.Move("C", WHOST_SIT_REGISTRO);

                    /*" -3556- END-IF */
                }


                /*" -3557- GO TO R3000-10-CONTINUA */

                R3000_10_CONTINUA(); //GOTO
                return;

                /*" -3559- END-IF. */
            }


            /*" -3561- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 29 AND COD-PLANO OF DCLPROPOSTA-FIDELIZ EQUAL 3721 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 29 && PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO == 3721)
            {

                /*" -3562- MOVE 37 TO WHOST-RAMO */
                _.Move(37, WHOST_RAMO);

                /*" -3563- PERFORM R3002-01-ESQ-DEBITO-CARTAO */

                R3002_01_ESQ_DEBITO_CARTAO_SECTION();

                /*" -3564- IF WTEM-CARTAO EQUAL 'S' */

                if (WS_GECLIMOV.WTEM_CARTAO == "S")
                {

                    /*" -3565- MOVE 'C' TO WHOST-SIT-REGISTRO */
                    _.Move("C", WHOST_SIT_REGISTRO);

                    /*" -3566- END-IF */
                }


                /*" -3567- GO TO R3000-10-CONTINUA */

                R3000_10_CONTINUA(); //GOTO
                return;

                /*" -3569- END-IF */
            }


            /*" -3570- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 09 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 09)
            {

                /*" -3571- IF CANAL-ATM */

                if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_ATM"])
                {

                    /*" -3572- IF PROD-CAIXA-FACIL */

                    if (WORK_AREA.W_TIPO_PRODUTO["PROD_CAIXA_FACIL"])
                    {

                        /*" -3573- MOVE 81 TO WHOST-RAMO */
                        _.Move(81, WHOST_RAMO);

                        /*" -3574- ELSE */
                    }
                    else
                    {


                        /*" -3575- MOVE 37 TO WHOST-RAMO */
                        _.Move(37, WHOST_RAMO);

                        /*" -3576- END-IF */
                    }


                    /*" -3577- PERFORM R3002-01-ESQ-DEBITO-CARTAO */

                    R3002_01_ESQ_DEBITO_CARTAO_SECTION();

                    /*" -3578- IF WTEM-CARTAO EQUAL 'S' */

                    if (WS_GECLIMOV.WTEM_CARTAO == "S")
                    {

                        /*" -3579- MOVE 'C' TO WHOST-SIT-REGISTRO */
                        _.Move("C", WHOST_SIT_REGISTRO);

                        /*" -3580- END-IF */
                    }


                    /*" -3581- GO TO R3000-10-CONTINUA */

                    R3000_10_CONTINUA(); //GOTO
                    return;

                    /*" -3582- END-IF */
                }


                /*" -3584- END-IF. */
            }


            /*" -3585- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 9 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 9)
            {

                /*" -3587- IF ORIGEM-MARSH OR BILHECOB-PRM-TOTAL EQUAL 60,00 OR 60,77 */

                if (WORK_AREA.W_ORIGEM_PROPOSTA["ORIGEM_MARSH"] || BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL.In("60.00", "60.77"))
                {

                    /*" -3588- MOVE 81 TO WHOST-RAMO */
                    _.Move(81, WHOST_RAMO);

                    /*" -3589- ELSE */
                }
                else
                {


                    /*" -3590- MOVE 82 TO WHOST-RAMO */
                    _.Move(82, WHOST_RAMO);

                    /*" -3591- END-IF */
                }


                /*" -3592- ELSE */
            }
            else
            {


                /*" -3593- PERFORM R3002-01-ESQ-DEBITO-CARTAO */

                R3002_01_ESQ_DEBITO_CARTAO_SECTION();

                /*" -3594- IF WTEM-CARTAO EQUAL 'S' */

                if (WS_GECLIMOV.WTEM_CARTAO == "S")
                {

                    /*" -3595- MOVE 'C' TO WHOST-SIT-REGISTRO */
                    _.Move("C", WHOST_SIT_REGISTRO);

                    /*" -3596- END-IF */
                }


                /*" -3597- IF BILHECOB-PRM-TOTAL EQUAL 69,90 OR 79,90 */

                if (BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL.In("69.90", "79.90"))
                {

                    /*" -3598- MOVE 14 TO WHOST-RAMO */
                    _.Move(14, WHOST_RAMO);

                    /*" -3599- ELSE */
                }
                else
                {


                    /*" -3600- MOVE 72 TO WHOST-RAMO */
                    _.Move(72, WHOST_RAMO);

                    /*" -3601- END-IF */
                }


                /*" -3601- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R3000_10_CONTINUA */

            R3000_10_CONTINUA();

        }

        [StopWatch]
        /*" R3000-10-CONTINUA */
        private void R3000_10_CONTINUA(bool isPerform = false)
        {
            /*" -3606- IF CANAL-ATM */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_ATM"])
            {

                /*" -3607- IF SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'NPG' */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA == "NPG")
                {

                    /*" -3608- MOVE 'R' TO WHOST-SIT-REGISTRO */
                    _.Move("R", WHOST_SIT_REGISTRO);

                    /*" -3609- END-IF */
                }


                /*" -3611- END-IF */
            }


            /*" -3612- IF WS-TEM-ERRO-CRITICO EQUAL 'S' */

            if (WS_TEM_ERRO_CRITICO == "S")
            {

                /*" -3613- MOVE '1' TO WHOST-SIT-REGISTRO */
                _.Move("1", WHOST_SIT_REGISTRO);

                /*" -3615- END-IF */
            }


            /*" -3617- MOVE 'INSERT BILHETE              ' TO COMANDO. */
            _.Move("INSERT BILHETE              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3691- PERFORM R3000_10_CONTINUA_DB_INSERT_1 */

            R3000_10_CONTINUA_DB_INSERT_1();

            /*" -3694- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3695- DISPLAY 'PF0602B - PROBLEMAS NO INSERT BILHETE ' */
                _.Display($"PF0602B - PROBLEMAS NO INSERT BILHETE ");

                /*" -3697- DISPLAY 'BILHECOB-COD-PRODUTO >> ' BILHECOB-COD-PRODUTO OF DCLBILHETE-COBERTURA */
                _.Display($"BILHECOB-COD-PRODUTO >> {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO}");

                /*" -3699- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3699- ADD 1 TO AC-I-BILHETE. */
            WORK_AREA.AC_I_BILHETE.Value = WORK_AREA.AC_I_BILHETE + 1;

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-INSERT-1 */
        public void R3000_10_CONTINUA_DB_INSERT_1()
        {
            /*" -3691- EXEC SQL INSERT INTO SEGUROS.BILHETE ( NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , TIMESTAMP , DATA_CANCELAMENTO , BI_FAIXA_RENDA_IND, BI_FAIXA_RENDA_FAM, COD_PRODUTO ) VALUES ( :DCLPROPOSTA-FIDELIZ.NUM-SICOB , 0, :WHOST-FONTE, :DCLPROPOSTA-FIDELIZ.AGECOBR , :DCLPROPOSTA-FIDELIZ.NRMATRVEN , :DCLPROPOSTA-FIDELIZ.AGECTAVEN , :DCLPROPOSTA-FIDELIZ.OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.DIGCTAVEN , :DCLCLIENTES.COD-CLIENTE , :WHOST-PROFISSAO , :DCLPESSOA-FISICA.SEXO , :DCLPESSOA-FISICA.ESTADO-CIVIL , 1, :DCLPROPOSTA-FIDELIZ.AGECTADEB , :DCLPROPOSTA-FIDELIZ.OPRCTADEB , :DCLPROPOSTA-FIDELIZ.NUMCTADEB , :DCLPROPOSTA-FIDELIZ.DIGCTADEB , :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO, :DCLPROPOSTA-FIDELIZ.DTQITBCO , :DCLPROPOSTA-FIDELIZ.VAL-PAGO , :WHOST-RAMO , :DCLPROPOSTA-FIDELIZ.DTQITBCO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , 0, :WHOST-SIT-REGISTRO , '0' , '0' , 'PF0602B' , CURRENT TIMESTAMP, NULL, :BILHETE-BI-FAIXA-RENDA-IND, :BILHETE-BI-FAIXA-RENDA-FAM, :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO ) END-EXEC. */

            var r3000_10_CONTINUA_DB_INSERT_1_Insert1 = new R3000_10_CONTINUA_DB_INSERT_1_Insert1()
            {
                NUM_SICOB = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                AGECOBR = PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR.ToString(),
                NRMATRVEN = PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN.ToString(),
                AGECTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN.ToString(),
                OPRCTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN.ToString(),
                NUMCTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN.ToString(),
                DIGCTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                WHOST_PROFISSAO = WHOST_PROFISSAO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                AGECTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB.ToString(),
                OPRCTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB.ToString(),
                NUMCTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB.ToString(),
                DIGCTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB.ToString(),
                BILHECOB_COD_OPCAO_PLANO = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO.ToString(),
                DTQITBCO = PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.ToString(),
                VAL_PAGO = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO.ToString(),
                WHOST_RAMO = WHOST_RAMO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WHOST_SIT_REGISTRO = WHOST_SIT_REGISTRO.ToString(),
                BILHETE_BI_FAIXA_RENDA_IND = BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND.ToString(),
                BILHETE_BI_FAIXA_RENDA_FAM = BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM.ToString(),
                BILHECOB_COD_PRODUTO = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO.ToString(),
            };

            R3000_10_CONTINUA_DB_INSERT_1_Insert1.Execute(r3000_10_CONTINUA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3002-01-ESQ-DEBITO-CARTAO-SECTION */
        private void R3002_01_ESQ_DEBITO_CARTAO_SECTION()
        {
            /*" -3707- MOVE '3002-01-ESQ-DEBITO-CARTAO    ' TO PARAGRAFO. */
            _.Move("3002-01-ESQ-DEBITO-CARTAO    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3708- MOVE 'SELECT OPCAO_PAG_VIDAZUL     ' TO COMANDO. */
            _.Move("SELECT OPCAO_PAG_VIDAZUL     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3710- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3712- MOVE 'S' TO WTEM-CARTAO. */
            _.Move("S", WS_GECLIMOV.WTEM_CARTAO);

            /*" -3715- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO OPPAGVA-NUM-CERTIFICADO. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO);

            /*" -3721- PERFORM R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1 */

            R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1();

            /*" -3724- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3725- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3726- MOVE 'N' TO WTEM-CARTAO */
                    _.Move("N", WS_GECLIMOV.WTEM_CARTAO);

                    /*" -3727- ELSE */
                }
                else
                {


                    /*" -3728- DISPLAY 'PF0602B - PROBLEMAS SELECT OPCAO_PAG_VIDAZUL' */
                    _.Display($"PF0602B - PROBLEMAS SELECT OPCAO_PAG_VIDAZUL");

                    /*" -3729- DISPLAY '     **   VENDA CARTAO DE CREDITO    **     ' */
                    _.Display($"     **   VENDA CARTAO DE CREDITO    **     ");

                    /*" -3731- DISPLAY '          NUM PROPOSTA                  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUM PROPOSTA                  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -3733- DISPLAY '          SQLCODE                       ' SQLCODE */
                    _.Display($"          SQLCODE                       {DB.SQLCODE}");

                    /*" -3734- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3735- END-IF */
                }


                /*" -3735- END-IF. */
            }


        }

        [StopWatch]
        /*" R3002-01-ESQ-DEBITO-CARTAO-DB-SELECT-1 */
        public void R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1()
        {
            /*" -3721- EXEC SQL SELECT NUM_CARTAO_CREDITO INTO :OPPAGVA-NUM-CARTAO-CREDITO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPPAGVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1 = new R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1()
            {
                OPPAGVA_NUM_CERTIFICADO = OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1.Execute(r3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPPAGVA_NUM_CARTAO_CREDITO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CARTAO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3002_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-INSERT-COMPL-SICAQWEB-SECTION */
        private void R3010_00_INSERT_COMPL_SICAQWEB_SECTION()
        {
            /*" -3745- MOVE 'R3010-00-INSERT-COMPL_SICAQWEB' TO PARAGRAFO. */
            _.Move("R3010-00-INSERT-COMPL_SICAQWEB", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3747- MOVE 'INSERT COMPL_SICAQWEB         ' TO COMANDO. */
            _.Move("INSERT COMPL_SICAQWEB         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3748- MOVE WSRC-COD-OPERADOR TO VG084-COD-OPERADOR */
            _.Move(WSRC_INF_SICAQWEB.WSRC_COD_OPERADOR, VG084.DCLVG_COMPL_SICAQWEB.VG084_COD_OPERADOR);

            /*" -3749- MOVE WSRC-NUM-CORRESPONDENTE TO VG084-NUM-CORRESP-CX-AQUI */
            _.Move(WSRC_INF_SICAQWEB.WSRC_NUM_CORRESPONDENTE, VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_CORRESP_CX_AQUI);

            /*" -3751- MOVE WSRC-TIPO-CORRESPONDENTE TO VG084-IND-TP-CORRESP-SICAQ */
            _.Move(WSRC_INF_SICAQWEB.WSRC_TIPO_CORRESPONDENTE, VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_TP_CORRESP_SICAQ);

            /*" -3752- MOVE '0001-01-01' TO DATA-SQL1 */
            _.Move("0001-01-01", WORK_AREA.DATA_SQL1);

            /*" -3753- MOVE WSRC-ANO-CONTRATACAO TO ANO-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_ANO_CONTRATACAO, WORK_AREA.DATA_SQL.ANO_SQL);

            /*" -3754- MOVE WSRC-MES-CONTRATACAO TO MES-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_MES_CONTRATACAO, WORK_AREA.DATA_SQL.MES_SQL);

            /*" -3755- MOVE WSRC-DIA-CONTRATACAO TO DIA-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO.WSRC_DIA_CONTRATACAO, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -3757- MOVE DATA-SQL1 TO VG084-DTA-CONTRATACAO */
            _.Move(WORK_AREA.DATA_SQL1, VG084.DCLVG_COMPL_SICAQWEB.VG084_DTA_CONTRATACAO);

            /*" -3758- MOVE '01:01:01' TO HORA-SQL1 */
            _.Move("01:01:01", WORK_AREA.HORA_SQL1);

            /*" -3759- MOVE WSRC-HH-CONTRATACAO TO HH-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO.WSRC_HH_CONTRATACAO, WORK_AREA.HORA_SQL.HH_SQL);

            /*" -3760- MOVE WSRC-MM-CONTRATACAO TO MM-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO.WSRC_MM_CONTRATACAO, WORK_AREA.HORA_SQL.MM_SQL);

            /*" -3761- MOVE WSRC-SS-CONTRATACAO TO SS-SQL */
            _.Move(WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO.WSRC_SS_CONTRATACAO, WORK_AREA.HORA_SQL.SS_SQL);

            /*" -3763- MOVE HORA-SQL1 TO VG084-HRA-CONTRATACAO */
            _.Move(WORK_AREA.HORA_SQL1, VG084.DCLVG_COMPL_SICAQWEB.VG084_HRA_CONTRATACAO);

            /*" -3764- MOVE WSRC-NRO-PROPOSTA-SICAQ TO VG084-NUM-PROPOSTA-SICAQ */
            _.Move(WSRC_INF_SICAQWEB.WSRC_NRO_PROPOSTA_SICAQ, VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_PROPOSTA_SICAQ);

            /*" -3765- MOVE WSRC-ORIGEM-PROPOSTA TO VG084-IND-ORIGEM-PROPOSTA */
            _.Move(WSRC_INF_SICAQWEB.WSRC_ORIGEM_PROPOSTA, VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_ORIGEM_PROPOSTA);

            /*" -3767- MOVE 'PF0602B' TO VG084-NOM-PROGRAMA. */
            _.Move("PF0602B", VG084.DCLVG_COMPL_SICAQWEB.VG084_NOM_PROGRAMA);

            /*" -3789- PERFORM R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1 */

            R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1();

            /*" -3792- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3793- DISPLAY 'PROBLEMAS NO INSERT VG_COMPL_SICAQWEB' */
                _.Display($"PROBLEMAS NO INSERT VG_COMPL_SICAQWEB");

                /*" -3795- DISPLAY 'PROPOSTA = ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"PROPOSTA = {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -3797- DISPLAY 'VG084-COD-OPERADOR        : ' VG084-COD-OPERADOR */
                _.Display($"VG084-COD-OPERADOR        : {VG084.DCLVG_COMPL_SICAQWEB.VG084_COD_OPERADOR}");

                /*" -3799- DISPLAY 'VG084-NUM-CORRESP-CX-AQUI : ' VG084-NUM-CORRESP-CX-AQUI */
                _.Display($"VG084-NUM-CORRESP-CX-AQUI : {VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_CORRESP_CX_AQUI}");

                /*" -3801- DISPLAY 'VG084-IND-TP-CORRESP-SICAQ: ' VG084-IND-TP-CORRESP-SICAQ */
                _.Display($"VG084-IND-TP-CORRESP-SICAQ: {VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_TP_CORRESP_SICAQ}");

                /*" -3803- DISPLAY 'VG084-DTA-CONTRATACAOSICAQ: ' VG084-DTA-CONTRATACAO */
                _.Display($"VG084-DTA-CONTRATACAOSICAQ: {VG084.DCLVG_COMPL_SICAQWEB.VG084_DTA_CONTRATACAO}");

                /*" -3805- DISPLAY 'VG084-HRA-CONTRATACAOSICAQ: ' VG084-HRA-CONTRATACAO */
                _.Display($"VG084-HRA-CONTRATACAOSICAQ: {VG084.DCLVG_COMPL_SICAQWEB.VG084_HRA_CONTRATACAO}");

                /*" -3807- DISPLAY 'VG084-NUM-PROPOSTA-SICAQAQ: ' VG084-NUM-PROPOSTA-SICAQ */
                _.Display($"VG084-NUM-PROPOSTA-SICAQAQ: {VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_PROPOSTA_SICAQ}");

                /*" -3809- DISPLAY 'VG084-IND-ORIGEM-PROPOSTA : ' VG084-IND-ORIGEM-PROPOSTA */
                _.Display($"VG084-IND-ORIGEM-PROPOSTA : {VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_ORIGEM_PROPOSTA}");

                /*" -3811- DISPLAY 'VG084-NOM-PROGRAMA        : ' VG084-NOM-PROGRAMA */
                _.Display($"VG084-NOM-PROGRAMA        : {VG084.DCLVG_COMPL_SICAQWEB.VG084_NOM_PROGRAMA}");

                /*" -3812- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3814- END-IF */
            }


            /*" -3815- ADD 1 TO AC-I-COMPL-SICAQ. */
            WORK_AREA.AC_I_COMPL_SICAQ.Value = WORK_AREA.AC_I_COMPL_SICAQ + 1;

        }

        [StopWatch]
        /*" R3010-00-INSERT-COMPL-SICAQWEB-DB-INSERT-1 */
        public void R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1()
        {
            /*" -3789- EXEC SQL INSERT INTO SEGUROS.VG_COMPL_SICAQWEB ( NUM_CERTIFICADO , COD_OPERADOR , NUM_CORRESP_CX_AQUI , IND_TP_CORRESP_SICAQ , DTA_CONTRATACAO , HRA_CONTRATACAO , NUM_PROPOSTA_SICAQ , IND_ORIGEM_PROPOSTA , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF ,:VG084-COD-OPERADOR ,:VG084-NUM-CORRESP-CX-AQUI ,:VG084-IND-TP-CORRESP-SICAQ ,:VG084-DTA-CONTRATACAO ,:VG084-HRA-CONTRATACAO ,:VG084-NUM-PROPOSTA-SICAQ ,:VG084-IND-ORIGEM-PROPOSTA ,:VG084-NOM-PROGRAMA , CURRENT TIMESTAMP ) END-EXEC. */

            var r3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1 = new R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
                VG084_COD_OPERADOR = VG084.DCLVG_COMPL_SICAQWEB.VG084_COD_OPERADOR.ToString(),
                VG084_NUM_CORRESP_CX_AQUI = VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_CORRESP_CX_AQUI.ToString(),
                VG084_IND_TP_CORRESP_SICAQ = VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_TP_CORRESP_SICAQ.ToString(),
                VG084_DTA_CONTRATACAO = VG084.DCLVG_COMPL_SICAQWEB.VG084_DTA_CONTRATACAO.ToString(),
                VG084_HRA_CONTRATACAO = VG084.DCLVG_COMPL_SICAQWEB.VG084_HRA_CONTRATACAO.ToString(),
                VG084_NUM_PROPOSTA_SICAQ = VG084.DCLVG_COMPL_SICAQWEB.VG084_NUM_PROPOSTA_SICAQ.ToString(),
                VG084_IND_ORIGEM_PROPOSTA = VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_ORIGEM_PROPOSTA.ToString(),
                VG084_NOM_PROGRAMA = VG084.DCLVG_COMPL_SICAQWEB.VG084_NOM_PROGRAMA.ToString(),
            };

            R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1.Execute(r3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-EMPRESA-MEI-SECTION */
        private void R4000_00_TRATA_EMPRESA_MEI_SECTION()
        {
            /*" -3824- MOVE 'R4000-00-TRATA-EMPRESA' TO PARAGRAFO */
            _.Move("R4000-00-TRATA-EMPRESA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3825- MOVE ' ' TO COMANDO */
            _.Move(" ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3827- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3829- PERFORM R4300-00-SEL-PROP-FIDELIZ-COMP */

            R4300_00_SEL_PROP_FIDELIZ_COMP_SECTION();

            /*" -3830- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -3832- DISPLAY 'NAO TEM PROP-FIDELIZ-COMP ' PROFIDCO-NUM-IDENTIFICACAO */
                _.Display($"NAO TEM PROP-FIDELIZ-COMP {PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO}");

                /*" -3833- GO TO R4000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;

                /*" -3836- END-IF */
            }


            /*" -3838- PERFORM R4400-00-SEL-CLIENTE-JUR */

            R4400_00_SEL_CLIENTE_JUR_SECTION();

            /*" -3839- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3840- PERFORM R4500-00-INS-CLIENTE-JUR */

                R4500_00_INS_CLIENTE_JUR_SECTION();

                /*" -3841- PERFORM R4600-00-INS-COMPLEMENTO-JUR */

                R4600_00_INS_COMPLEMENTO_JUR_SECTION();

                /*" -3844- END-IF */
            }


            /*" -3846- PERFORM R4700-00-INS-RELACIONAMENTO */

            R4700_00_INS_RELACIONAMENTO_SECTION();

            /*" -3846- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-SEL-PROP-FIDELIZ-COMP-SECTION */
        private void R4300_00_SEL_PROP_FIDELIZ_COMP_SECTION()
        {
            /*" -3855- MOVE 'R4300-00-SEL-PROP-FIDE' TO PARAGRAFO */
            _.Move("R4300-00-SEL-PROP-FIDE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3856- MOVE 'SEL PROP_FIDELIZ_COMP' TO COMANDO */
            _.Move("SEL PROP_FIDELIZ_COMP", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3859- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3862- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROFIDCO-NUM-IDENTIFICACAO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO);

            /*" -3870- PERFORM R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1 */

            R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1();

            /*" -3873- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -3874- DISPLAY 'ANTES DE MOVER ' SQLCODE */
                _.Display($"ANTES DE MOVER {DB.SQLCODE}");

                /*" -3876- MOVE PROFIDCO-INFORMACAO-COMPL TO R6C-EMPRESA-COMPACTADO */
                _.Move(PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL, BIEMPCOM.R6C_EMPRESA_COMPACTADO);

                /*" -3877- DISPLAY 'DEPOIS DE MOVER ' SQLCODE */
                _.Display($"DEPOIS DE MOVER {DB.SQLCODE}");

                /*" -3879- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO WS-BIGINT(2) */
                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, WS_GECLIMOV.WS_EDIT.WS_BIGINT[2]);

                /*" -3880- DISPLAY '-------------------------------------------------' */
                _.Display($"-------------------------------------------------");

                /*" -3881- DISPLAY 'NUM-IDENTIFICACAO ' WS-BIGINT(2) */
                _.Display($"NUM-IDENTIFICACAO {WS_GECLIMOV.WS_EDIT.WS_BIGINT[2]}");

                /*" -3882- DISPLAY '-------------------------------------------------' */
                _.Display($"-------------------------------------------------");

                /*" -3883- DISPLAY 'RAZAO-SOCIAL-MEI  ' R6C-RAZAO-SOCIAL-MEI */
                _.Display($"RAZAO-SOCIAL-MEI  {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_RAZAO_SOCIAL_MEI}");

                /*" -3884- DISPLAY 'DATA-CONSTIT-MEI  ' R6C-DATA-CONSTITUICAO-MEI */
                _.Display($"DATA-CONSTIT-MEI  {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DATA_CONSTITUICAO_MEI}");

                /*" -3885- DISPLAY 'DAT-FAT-ANUAL-MEI ' R6C-DAT-FAT-ANUAL-MEI */
                _.Display($"DAT-FAT-ANUAL-MEI {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DAT_FAT_ANUAL_MEI}");

                /*" -3886- DISPLAY 'EMAIL             ' R6C-EMAIL */
                _.Display($"EMAIL             {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_EMAIL}");

                /*" -3887- DISPLAY 'ENDERECO          ' R6C-ENDERECO */
                _.Display($"ENDERECO          {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_ENDERECO}");

                /*" -3888- DISPLAY 'BAIRRO            ' R6C-BAIRRO */
                _.Display($"BAIRRO            {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_BAIRRO}");

                /*" -3889- DISPLAY 'CIDADE            ' R6C-CIDADE */
                _.Display($"CIDADE            {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CIDADE}");

                /*" -3890- DISPLAY 'UF                ' R6C-UF */
                _.Display($"UF                {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_UF}");

                /*" -3891- DISPLAY 'CEP               ' R6C-CEP */
                _.Display($"CEP               {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CEP}");

                /*" -3892- MOVE R6C-COD-PORTE-MEI TO WS-SMALLINT(1) */
                _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_COD_PORTE_MEI, WS_GECLIMOV.WS_EDIT.WS_SMALLINT[1]);

                /*" -3893- DISPLAY 'COD-PORTE-MEI     ' WS-SMALLINT(1) */
                _.Display($"COD-PORTE-MEI     {WS_GECLIMOV.WS_EDIT.WS_SMALLINT[1]}");

                /*" -3894- MOVE R6C-CNAE-MEI TO WS-INTEGER(1) */
                _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNAE_MEI, WS_GECLIMOV.WS_EDIT.WS_INTEGER[1]);

                /*" -3895- DISPLAY 'CNAE-MEI          ' WS-INTEGER(1) */
                _.Display($"CNAE-MEI          {WS_GECLIMOV.WS_EDIT.WS_INTEGER[1]}");

                /*" -3896- MOVE R6C-VAL-FAT-ANUAL-MEI TO WS-DECIMAL(1) */
                _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_VAL_FAT_ANUAL_MEI, WS_GECLIMOV.WS_EDIT.WS_DECIMAL[1]);

                /*" -3897- DISPLAY 'VAL-FAT-ANUAL-MEI ' WS-DECIMAL(1) */
                _.Display($"VAL-FAT-ANUAL-MEI {WS_GECLIMOV.WS_EDIT.WS_DECIMAL[1]}");

                /*" -3898- MOVE R6C-CNPJ-MEI TO WS-BIGINT(1) */
                _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNPJ_MEI, WS_GECLIMOV.WS_EDIT.WS_BIGINT[1]);

                /*" -3899- DISPLAY 'CNPJ-MEI          ' WS-BIGINT(1) */
                _.Display($"CNPJ-MEI          {WS_GECLIMOV.WS_EDIT.WS_BIGINT[1]}");

                /*" -3900- MOVE R6C-DDD-COMERCIAL TO WS-SMALLINT(2) */
                _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DDD_COMERCIAL, WS_GECLIMOV.WS_EDIT.WS_SMALLINT[2]);

                /*" -3901- DISPLAY 'DDD-COMERCIAL     ' WS-SMALLINT(2) */
                _.Display($"DDD-COMERCIAL     {WS_GECLIMOV.WS_EDIT.WS_SMALLINT[2]}");

                /*" -3902- MOVE R6C-TELEFONE-COMERCIAL TO WS-BIGINT(1) */
                _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_TELEFONE_COMERCIAL, WS_GECLIMOV.WS_EDIT.WS_BIGINT[1]);

                /*" -3903- DISPLAY 'TELEFONE-COMERCL  ' WS-BIGINT(1) */
                _.Display($"TELEFONE-COMERCL  {WS_GECLIMOV.WS_EDIT.WS_BIGINT[1]}");

                /*" -3904- MOVE R6C-TIPO-ENDERECO TO WS-SMALLINT(3) */
                _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_TIPO_ENDERECO, WS_GECLIMOV.WS_EDIT.WS_SMALLINT[3]);

                /*" -3905- DISPLAY 'TIPO-ENDERECO     ' WS-SMALLINT(3) */
                _.Display($"TIPO-ENDERECO     {WS_GECLIMOV.WS_EDIT.WS_SMALLINT[3]}");

                /*" -3906- DISPLAY '-------------------------------------------------' */
                _.Display($"-------------------------------------------------");

                /*" -3907- ELSE */
            }
            else
            {


                /*" -3908- IF (SQLCODE NOT EQUAL +100) */

                if ((DB.SQLCODE != +100))
                {

                    /*" -3909- DISPLAY 'PF0602B - PROBLEMAS NO SEL PROP_FIDELIZ_COMP' */
                    _.Display($"PF0602B - PROBLEMAS NO SEL PROP_FIDELIZ_COMP");

                    /*" -3911- DISPLAY 'NUM PROPOSTA: ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"NUM PROPOSTA: {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -3913- DISPLAY 'NUMERO IDENTIFICACAO: ' PROFIDCO-NUM-IDENTIFICACAO */
                    _.Display($"NUMERO IDENTIFICACAO: {PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO}");

                    /*" -3914- DISPLAY 'SQLCODE: ' SQLCODE */
                    _.Display($"SQLCODE: {DB.SQLCODE}");

                    /*" -3915- DISPLAY 'PF0602B - ERRO SEL PROP_FIDELIZ_COMP' */
                    _.Display($"PF0602B - ERRO SEL PROP_FIDELIZ_COMP");

                    /*" -3916- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3917- END-IF */
                }


                /*" -3919- END-IF */
            }


            /*" -3919- . */

        }

        [StopWatch]
        /*" R4300-00-SEL-PROP-FIDELIZ-COMP-DB-SELECT-1 */
        public void R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1()
        {
            /*" -3870- EXEC SQL SELECT VALUE(INFORMACAO_COMPL, ' ' ) INTO :PROFIDCO-INFORMACAO-COMPL FROM SEGUROS.PROP_FIDELIZ_COMP WHERE NUM_IDENTIFICACAO = :PROFIDCO-NUM-IDENTIFICACAO AND IND_TP_INFORMACAO = '4' WITH UR END-EXEC */

            var r4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1 = new R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1()
            {
                PROFIDCO_NUM_IDENTIFICACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1.Execute(r4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROFIDCO_INFORMACAO_COMPL, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-SEL-CLIENTE-JUR-SECTION */
        private void R4400_00_SEL_CLIENTE_JUR_SECTION()
        {
            /*" -3928- MOVE 'R4400-00-SEL-CLIENTE-JU' TO PARAGRAFO */
            _.Move("R4400-00-SEL-CLIENTE-JU", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3929- MOVE 'SEL CLIENTES         ' TO COMANDO */
            _.Move("SEL CLIENTES         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3932- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3934- MOVE R6C-CNPJ-MEI TO CGCCPF OF DCLCLIENTES */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNPJ_MEI, CLIENTE.DCLCLIENTES.CGCCPF);

            /*" -3937- DISPLAY 'CGCCPF: ' CGCCPF OF DCLCLIENTES */
            _.Display($"CGCCPF: {CLIENTE.DCLCLIENTES.CGCCPF}");

            /*" -3943- PERFORM R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1 */

            R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1();

            /*" -3946- DISPLAY 'SQLCODE: ' SQLCODE */
            _.Display($"SQLCODE: {DB.SQLCODE}");

            /*" -3947- DISPLAY 'CODCLI : ' COD-CLIENTE OF DCLCLIENTES */
            _.Display($"CODCLI : {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

            /*" -3948- IF SQLCODE EQUAL ZEROS OR 100 */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -3950- MOVE COD-CLIENTE OF DCLCLIENTES TO W-COD-CLIENTE-JUR */
                _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, W_COD_CLIENTE_JUR);

                /*" -3951- ELSE */
            }
            else
            {


                /*" -3952- DISPLAY 'PF0602B - PROBLEMAS NO SEL CLIENTES(JUR)' */
                _.Display($"PF0602B - PROBLEMAS NO SEL CLIENTES(JUR)");

                /*" -3954- DISPLAY 'NUM PROPOSTA: ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUM PROPOSTA: {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -3956- DISPLAY 'CODIGO CLIENTE: ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"CODIGO CLIENTE: {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -3957- DISPLAY 'SQLCODE: ' SQLCODE */
                _.Display($"SQLCODE: {DB.SQLCODE}");

                /*" -3958- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3960- END-IF */
            }


            /*" -3960- . */

        }

        [StopWatch]
        /*" R4400-00-SEL-CLIENTE-JUR-DB-SELECT-1 */
        public void R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1()
        {
            /*" -3943- EXEC SQL SELECT COD_CLIENTE INTO :DCLCLIENTES.COD-CLIENTE FROM SEGUROS.CLIENTES WHERE CGCCPF = :DCLCLIENTES.CGCCPF WITH UR END-EXEC */

            var r4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1 = new R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1()
            {
                CGCCPF = CLIENTE.DCLCLIENTES.CGCCPF.ToString(),
            };

            var executed_1 = R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1.Execute(r4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-INS-CLIENTE-JUR-SECTION */
        private void R4500_00_INS_CLIENTE_JUR_SECTION()
        {
            /*" -3969- MOVE 'R4500-00-INS-CLIENTE-JU' TO PARAGRAFO */
            _.Move("R4500-00-INS-CLIENTE-JU", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3970- MOVE 'INS CLIENTES         ' TO COMANDO */
            _.Move("INS CLIENTES         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3973- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3976- ADD 001 TO NUM-CLIENTE OF DCLNUMERO-OUTROS */
            NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.Value = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE + 001;

            /*" -3978- DISPLAY 'R6C-RAZAO-SOCIAL-MEI     : ' R6C-RAZAO-SOCIAL-MEI */
            _.Display($"R6C-RAZAO-SOCIAL-MEI     : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_RAZAO_SOCIAL_MEI}");

            /*" -3980- DISPLAY 'R6C-DATA-CONSTITUICAO-MEI: ' R6C-DATA-CONSTITUICAO-MEI */
            _.Display($"R6C-DATA-CONSTITUICAO-MEI: {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DATA_CONSTITUICAO_MEI}");

            /*" -3982- DISPLAY 'R6C-COD-PORTE-MEI        : ' R6C-COD-PORTE-MEI */
            _.Display($"R6C-COD-PORTE-MEI        : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_COD_PORTE_MEI}");

            /*" -3984- DISPLAY 'R6C-CNAE-MEI             : ' R6C-CNAE-MEI */
            _.Display($"R6C-CNAE-MEI             : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNAE_MEI}");

            /*" -3986- DISPLAY 'R6C-VAL-FAT-ANUAL-MEI    : ' R6C-VAL-FAT-ANUAL-MEI */
            _.Display($"R6C-VAL-FAT-ANUAL-MEI    : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_VAL_FAT_ANUAL_MEI}");

            /*" -3988- DISPLAY 'R6C-DAT-FAT-ANUAL-MEI    : ' R6C-DAT-FAT-ANUAL-MEI */
            _.Display($"R6C-DAT-FAT-ANUAL-MEI    : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DAT_FAT_ANUAL_MEI}");

            /*" -3991- DISPLAY 'R6C-CNPJ-MEI             : ' R6C-CNPJ-MEI */
            _.Display($"R6C-CNPJ-MEI             : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNPJ_MEI}");

            /*" -3994- MOVE NUM-CLIENTE OF DCLNUMERO-OUTROS TO COD-CLIENTE OF DCLCLIENTES W-COD-CLIENTE-JUR */
            _.Move(NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE, W_COD_CLIENTE_JUR);

            /*" -3996- MOVE R6C-RAZAO-SOCIAL-MEI TO NOME-RAZAO OF DCLCLIENTES */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_RAZAO_SOCIAL_MEI, CLIENTE.DCLCLIENTES.NOME_RAZAO);

            /*" -3999- MOVE R6C-CNPJ-MEI TO CGCCPF OF DCLCLIENTES */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNPJ_MEI, CLIENTE.DCLCLIENTES.CGCCPF);

            /*" -4036- PERFORM R4500_00_INS_CLIENTE_JUR_DB_INSERT_1 */

            R4500_00_INS_CLIENTE_JUR_DB_INSERT_1();

            /*" -4039- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4040- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -4041- GO TO R4500-00-INS-CLIENTE-JUR */
                    new Task(() => R4500_00_INS_CLIENTE_JUR_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -4042- END-IF */
                }


                /*" -4043- DISPLAY 'PF0602B - PROBLEMAS NO INSERT A CLIENTES JUR' */
                _.Display($"PF0602B - PROBLEMAS NO INSERT A CLIENTES JUR");

                /*" -4045- DISPLAY 'NUM PROPOSTA: ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUM PROPOSTA: {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -4047- DISPLAY 'CODIGO CLIENTE: ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"CODIGO CLIENTE: {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -4048- DISPLAY 'SQLCODE: ' SQLCODE */
                _.Display($"SQLCODE: {DB.SQLCODE}");

                /*" -4049- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4052- END-IF */
            }


            /*" -4054- PERFORM R4510-00-INS-ENDERECO-JUR */

            R4510_00_INS_ENDERECO_JUR_SECTION();

            /*" -4057- PERFORM R4530-00-INS-EMAIL-JUR */

            R4530_00_INS_EMAIL_JUR_SECTION();

            /*" -4057- . */

        }

        [StopWatch]
        /*" R4500-00-INS-CLIENTE-JUR-DB-INSERT-1 */
        public void R4500_00_INS_CLIENTE_JUR_DB_INSERT_1()
        {
            /*" -4036- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES (:DCLCLIENTES.COD-CLIENTE, :DCLCLIENTES.NOME-RAZAO, 'J' , :DCLCLIENTES.CGCCPF, '0' , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL ) END-EXEC */

            var r4500_00_INS_CLIENTE_JUR_DB_INSERT_1_Insert1 = new R4500_00_INS_CLIENTE_JUR_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                NOME_RAZAO = CLIENTE.DCLCLIENTES.NOME_RAZAO.ToString(),
                CGCCPF = CLIENTE.DCLCLIENTES.CGCCPF.ToString(),
            };

            R4500_00_INS_CLIENTE_JUR_DB_INSERT_1_Insert1.Execute(r4500_00_INS_CLIENTE_JUR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4510-00-INS-ENDERECO-JUR-SECTION */
        private void R4510_00_INS_ENDERECO_JUR_SECTION()
        {
            /*" -4066- MOVE 'R4510-00-INS-ENDERECO-JUR' TO PARAGRAFO */
            _.Move("R4510-00-INS-ENDERECO-JUR", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4067- MOVE 'INS ENDERECO         ' TO COMANDO */
            _.Move("INS ENDERECO         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4069- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4071- DISPLAY 'R6C-DDD-COMERCIAL        : ' R6C-DDD-COMERCIAL */
            _.Display($"R6C-DDD-COMERCIAL        : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DDD_COMERCIAL}");

            /*" -4073- DISPLAY 'R6C-TELEFONE-COMERCIAL   : ' R6C-TELEFONE-COMERCIAL */
            _.Display($"R6C-TELEFONE-COMERCIAL   : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_TELEFONE_COMERCIAL}");

            /*" -4075- DISPLAY 'R6C-EMAIL                : ' R6C-EMAIL */
            _.Display($"R6C-EMAIL                : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_EMAIL}");

            /*" -4077- DISPLAY 'R6C-TIPO-ENDERECO        : ' R6C-TIPO-ENDERECO */
            _.Display($"R6C-TIPO-ENDERECO        : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_TIPO_ENDERECO}");

            /*" -4079- DISPLAY 'R6C-ENDERECO             : ' R6C-ENDERECO */
            _.Display($"R6C-ENDERECO             : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_ENDERECO}");

            /*" -4081- DISPLAY 'R6C-BAIRRO               : ' R6C-BAIRRO */
            _.Display($"R6C-BAIRRO               : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_BAIRRO}");

            /*" -4083- DISPLAY 'R6C-CIDADE               : ' R6C-CIDADE */
            _.Display($"R6C-CIDADE               : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CIDADE}");

            /*" -4085- DISPLAY 'R6C-UF                   : ' R6C-UF */
            _.Display($"R6C-UF                   : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_UF}");

            /*" -4089- DISPLAY 'R6C-CEP                  : ' R6C-CEP */
            _.Display($"R6C-CEP                  : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CEP}");

            /*" -4092- MOVE NUM-CLIENTE OF DCLNUMERO-OUTROS TO ENDERECO-COD-CLIENTE */
            _.Move(NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -4093- MOVE 001 TO ENDERECO-OCORR-ENDERECO */
            _.Move(001, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);

            /*" -4094- MOVE R6C-ENDERECO TO ENDERECO-ENDERECO */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -4095- MOVE R6C-BAIRRO TO ENDERECO-BAIRRO */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -4096- MOVE R6C-CIDADE TO ENDERECO-CIDADE */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -4097- MOVE R6C-UF TO ENDERECO-SIGLA-UF */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

            /*" -4098- MOVE R6C-CEP TO ENDERECO-CEP */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -4099- MOVE R6C-DDD-COMERCIAL TO ENDERECO-DDD */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DDD_COMERCIAL, ENDERECO.DCLENDERECOS.ENDERECO_DDD);

            /*" -4101- MOVE R6C-TELEFONE-COMERCIAL TO ENDERECO-TELEFONE */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_TELEFONE_COMERCIAL, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);

            /*" -4119- PERFORM R4510_00_INS_ENDERECO_JUR_DB_INSERT_1 */

            R4510_00_INS_ENDERECO_JUR_DB_INSERT_1();

            /*" -4123- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4124- DISPLAY 'PF0602B - PROBLEMAS NO INS ENDERECO(JUR)' */
                _.Display($"PF0602B - PROBLEMAS NO INS ENDERECO(JUR)");

                /*" -4125- DISPLAY 'R4510-00-INS-ENDERECO-JUR' */
                _.Display($"R4510-00-INS-ENDERECO-JUR");

                /*" -4126- DISPLAY 'BILHETE: ' NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Display($"BILHETE: {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB}");

                /*" -4128- DISPLAY 'CODIGO CLIENTE: ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"CODIGO CLIENTE: {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -4129- MOVE SQLCODE TO W-SQLCODE */
                _.Move(DB.SQLCODE, W_SQLCODE);

                /*" -4130- DISPLAY 'SQLCODE: ' W-SQLCODE */
                _.Display($"SQLCODE: {W_SQLCODE}");

                /*" -4131- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4133- END-IF */
            }


            /*" -4133- . */

        }

        [StopWatch]
        /*" R4510-00-INS-ENDERECO-JUR-DB-INSERT-1 */
        public void R4510_00_INS_ENDERECO_JUR_DB_INSERT_1()
        {
            /*" -4119- EXEC SQL INSERT INTO SEGUROS.ENDERECOS VALUES (:DCLCLIENTES.COD-CLIENTE , 2 , 1 , :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , 0 , 0 , '0' , NULL , NULL ) END-EXEC. */

            var r4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1 = new R4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                ENDERECO_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.ToString(),
                ENDERECO_BAIRRO = ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO.ToString(),
                ENDERECO_CIDADE = ENDERECO.DCLENDERECOS.ENDERECO_CIDADE.ToString(),
                ENDERECO_SIGLA_UF = ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF.ToString(),
                ENDERECO_CEP = ENDERECO.DCLENDERECOS.ENDERECO_CEP.ToString(),
                ENDERECO_DDD = ENDERECO.DCLENDERECOS.ENDERECO_DDD.ToString(),
                ENDERECO_TELEFONE = ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE.ToString(),
            };

            R4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1.Execute(r4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4510_99_SAIDA*/

        [StopWatch]
        /*" R4530-00-INS-EMAIL-JUR-SECTION */
        private void R4530_00_INS_EMAIL_JUR_SECTION()
        {
            /*" -4143- MOVE 'R4530-00-INS-EMAIL-JUR' TO PARAGRAFO */
            _.Move("R4530-00-INS-EMAIL-JUR", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4144- MOVE 'INS EMAIL            ' TO COMANDO */
            _.Move("INS EMAIL            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4147- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4150- DISPLAY 'R6C-EMAIL                : ' R6C-EMAIL */
            _.Display($"R6C-EMAIL                : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_EMAIL}");

            /*" -4152- MOVE NUM-CLIENTE OF DCLNUMERO-OUTROS TO CLIENEMA-COD-CLIENTE */
            _.Move(NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE);

            /*" -4153- MOVE 001 TO CLIENEMA-SEQ-EMAIL */
            _.Move(001, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL);

            /*" -4155- MOVE R6C-EMAIL TO CLIENEMA-EMAIL */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);

            /*" -4160- PERFORM R4530_00_INS_EMAIL_JUR_DB_INSERT_1 */

            R4530_00_INS_EMAIL_JUR_DB_INSERT_1();

            /*" -4163- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4164- DISPLAY 'PF0602B - PROBLEMAS NO INS CLIENTE_EMAIL' */
                _.Display($"PF0602B - PROBLEMAS NO INS CLIENTE_EMAIL");

                /*" -4165- DISPLAY 'R4530-00-INS-EMAIL-JUR' */
                _.Display($"R4530-00-INS-EMAIL-JUR");

                /*" -4166- DISPLAY 'BILHETE: ' NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Display($"BILHETE: {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB}");

                /*" -4167- DISPLAY 'CODIGO CLIENTE: ' CLIENEMA-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE: {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE}");

                /*" -4168- MOVE SQLCODE TO W-SQLCODE */
                _.Move(DB.SQLCODE, W_SQLCODE);

                /*" -4169- DISPLAY 'SQLCODE: ' W-SQLCODE */
                _.Display($"SQLCODE: {W_SQLCODE}");

                /*" -4170- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4172- END-IF */
            }


            /*" -4172- . */

        }

        [StopWatch]
        /*" R4530-00-INS-EMAIL-JUR-DB-INSERT-1 */
        public void R4530_00_INS_EMAIL_JUR_DB_INSERT_1()
        {
            /*" -4160- EXEC SQL INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES (:CLIENEMA-COD-CLIENTE , :CLIENEMA-SEQ-EMAIL , :CLIENEMA-EMAIL ) END-EXEC */

            var r4530_00_INS_EMAIL_JUR_DB_INSERT_1_Insert1 = new R4530_00_INS_EMAIL_JUR_DB_INSERT_1_Insert1()
            {
                CLIENEMA_COD_CLIENTE = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE.ToString(),
                CLIENEMA_SEQ_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.ToString(),
                CLIENEMA_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL.ToString(),
            };

            R4530_00_INS_EMAIL_JUR_DB_INSERT_1_Insert1.Execute(r4530_00_INS_EMAIL_JUR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4530_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-INS-COMPLEMENTO-JUR-SECTION */
        private void R4600_00_INS_COMPLEMENTO_JUR_SECTION()
        {
            /*" -4181- MOVE 'R4600-00-INS-COMPLEMEN' TO PARAGRAFO */
            _.Move("R4600-00-INS-COMPLEMEN", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4182- MOVE 'INS VG_COMPL_CLI_EMP ' TO COMANDO */
            _.Move("INS VG_COMPL_CLI_EMP ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4185- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4187- DISPLAY 'R6C-DATA-CONSTITUICAO-MEI: ' R6C-DATA-CONSTITUICAO-MEI */
            _.Display($"R6C-DATA-CONSTITUICAO-MEI: {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DATA_CONSTITUICAO_MEI}");

            /*" -4189- DISPLAY 'R6C-CNAE-MEI             : ' R6C-CNAE-MEI */
            _.Display($"R6C-CNAE-MEI             : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNAE_MEI}");

            /*" -4191- DISPLAY 'R6C-VAL-FAT-ANUAL-MEI    : ' R6C-VAL-FAT-ANUAL-MEI */
            _.Display($"R6C-VAL-FAT-ANUAL-MEI    : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_VAL_FAT_ANUAL_MEI}");

            /*" -4194- DISPLAY 'R6C-DAT-FAT-ANUAL-MEI    : ' R6C-DAT-FAT-ANUAL-MEI */
            _.Display($"R6C-DAT-FAT-ANUAL-MEI    : {BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DAT_FAT_ANUAL_MEI}");

            /*" -4196- MOVE W-COD-CLIENTE-JUR TO VG092-COD-CLIENTE */
            _.Move(W_COD_CLIENTE_JUR, VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE);

            /*" -4197- MOVE R6C-DAT-FAT-ANUAL-MEI TO W-DATA-PIC9 */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DAT_FAT_ANUAL_MEI, W_DATA_PIC9);

            /*" -4200- IF W-ANO-PIC9 EQUAL ZEROS OR W-MES-PIC9 EQUAL ZEROS OR W-DIA-PIC9 EQUAL ZEROS */

            if (FILLER_1.W_ANO_PIC9 == 00 || FILLER_1.W_MES_PIC9 == 00 || FILLER_1.W_DIA_PIC9 == 00)
            {

                /*" -4201- MOVE '0001-01-01' TO VG092-DTA-FAT-ANUAL */
                _.Move("0001-01-01", VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL);

                /*" -4202- ELSE */
            }
            else
            {


                /*" -4207- STRING W-ANO-PIC9 '-' W-MES-PIC9 '-' W-DIA-PIC9 DELIMITED BY SIZE INTO VG092-DTA-FAT-ANUAL END-STRING */
                #region STRING
                var spl1 = FILLER_1.W_ANO_PIC9.GetMoveValues();
                spl1 += "-";
                var spl2 = FILLER_1.W_MES_PIC9.GetMoveValues();
                spl2 += "-";
                var spl3 = FILLER_1.W_DIA_PIC9.GetMoveValues();
                var results4 = spl1 + spl2 + spl3;
                _.Move(results4, VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL);
                #endregion

                /*" -4209- END-IF */
            }


            /*" -4210- MOVE R6C-CNAE-MEI TO W-CODIGO-CNAE */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNAE_MEI, W_CODIGO_CNAE);

            /*" -4211- IF W-CODIGO-CNAE-7P EQUAL ZEROS */

            if (FILLER_0.W_CODIGO_CNAE_7P == 00)
            {

                /*" -4212- MOVE -001 TO VIND-CNAE-MEI */
                _.Move(-001, VIND_CNAE_MEI);

                /*" -4213- ELSE */
            }
            else
            {


                /*" -4214- MOVE ZEROS TO VIND-CNAE-MEI */
                _.Move(0, VIND_CNAE_MEI);

                /*" -4215- MOVE W-CODIGO-CNAE-7P TO VG092-COD-CNAE-ATIVIDADE */
                _.Move(FILLER_0.W_CODIGO_CNAE_7P, VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE);

                /*" -4217- END-IF */
            }


            /*" -4219- MOVE R6C-VAL-FAT-ANUAL-MEI TO VG092-VLR-FAT-ANUAL */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_VAL_FAT_ANUAL_MEI, VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL);

            /*" -4220- MOVE R6C-DATA-CONSTITUICAO-MEI TO W-DATA-PIC9 */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DATA_CONSTITUICAO_MEI, W_DATA_PIC9);

            /*" -4223- IF W-ANO-PIC9 EQUAL ZEROS OR W-MES-PIC9 EQUAL ZEROS OR W-DIA-PIC9 EQUAL ZEROS */

            if (FILLER_1.W_ANO_PIC9 == 00 || FILLER_1.W_MES_PIC9 == 00 || FILLER_1.W_DIA_PIC9 == 00)
            {

                /*" -4224- MOVE '0001-01-01' TO VG092-DTA-CONSTITUICAO */
                _.Move("0001-01-01", VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO);

                /*" -4225- ELSE */
            }
            else
            {


                /*" -4230- STRING W-ANO-PIC9 '-' W-MES-PIC9 '-' W-DIA-PIC9 DELIMITED BY SIZE INTO VG092-DTA-CONSTITUICAO END-STRING */
                #region STRING
                var spl4 = FILLER_1.W_ANO_PIC9.GetMoveValues();
                spl4 += "-";
                var spl5 = FILLER_1.W_MES_PIC9.GetMoveValues();
                spl5 += "-";
                var spl6 = FILLER_1.W_DIA_PIC9.GetMoveValues();
                var results7 = spl4 + spl5 + spl6;
                _.Move(results7, VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO);
                #endregion

                /*" -4233- END-IF */
            }


            /*" -4235- DISPLAY 'VG092-COD-CLIENTE       : ' VG092-COD-CLIENTE */
            _.Display($"VG092-COD-CLIENTE       : {VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE}");

            /*" -4237- DISPLAY 'VG092-DTA-FAT-ANUAL     : ' VG092-DTA-FAT-ANUAL */
            _.Display($"VG092-DTA-FAT-ANUAL     : {VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL}");

            /*" -4239- DISPLAY 'VG092-VLR-FAT-ANUAL     : ' VG092-VLR-FAT-ANUAL */
            _.Display($"VG092-VLR-FAT-ANUAL     : {VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL}");

            /*" -4241- DISPLAY 'VG092-DTA-CONSTITUICAO  : ' VG092-DTA-CONSTITUICAO */
            _.Display($"VG092-DTA-CONSTITUICAO  : {VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO}");

            /*" -4244- DISPLAY 'VG092-COD-CNAE-ATIVIDADE: ' VG092-COD-CNAE-ATIVIDADE */
            _.Display($"VG092-COD-CNAE-ATIVIDADE: {VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE}");

            /*" -4257- PERFORM R4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1 */

            R4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1();

            /*" -4260- IF SQLCODE NOT EQUAL ZEROS AND -802 */

            if (!DB.SQLCODE.In("00", "-802"))
            {

                /*" -4261- DISPLAY 'PF0602B - PROBLEMAS NO INS VG_COMPL_CLI_EMP ' */
                _.Display($"PF0602B - PROBLEMAS NO INS VG_COMPL_CLI_EMP ");

                /*" -4263- DISPLAY 'NUM PROPOSTA: ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUM PROPOSTA: {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -4264- DISPLAY 'CODIGO CLIENTE: ' VG092-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE: {VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE}");

                /*" -4265- DISPLAY 'SQLCODE: ' SQLCODE */
                _.Display($"SQLCODE: {DB.SQLCODE}");

                /*" -4266- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4268- END-IF */
            }


            /*" -4268- . */

        }

        [StopWatch]
        /*" R4600-00-INS-COMPLEMENTO-JUR-DB-INSERT-1 */
        public void R4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1()
        {
            /*" -4257- EXEC SQL INSERT INTO SEGUROS.VG_COMPL_CLI_EMP ( COD_CLIENTE ,DTA_FAT_ANUAL ,VLR_FAT_ANUAL ,DTA_CONSTITUICAO ,COD_CNAE_ATIVIDADE ) VALUES ( :VG092-COD-CLIENTE ,:VG092-DTA-FAT-ANUAL ,:VG092-VLR-FAT-ANUAL ,:VG092-DTA-CONSTITUICAO ,:VG092-COD-CNAE-ATIVIDADE:VIND-CNAE-MEI ) END-EXEC */

            var r4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1_Insert1 = new R4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1_Insert1()
            {
                VG092_COD_CLIENTE = VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE.ToString(),
                VG092_DTA_FAT_ANUAL = VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL.ToString(),
                VG092_VLR_FAT_ANUAL = VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL.ToString(),
                VG092_DTA_CONSTITUICAO = VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO.ToString(),
                VG092_COD_CNAE_ATIVIDADE = VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE.ToString(),
                VIND_CNAE_MEI = VIND_CNAE_MEI.ToString(),
            };

            R4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1_Insert1.Execute(r4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R4700-00-INS-RELACIONAMENTO-SECTION */
        private void R4700_00_INS_RELACIONAMENTO_SECTION()
        {
            /*" -4277- MOVE 'R4700-00-INS-RELACIONA' TO PARAGRAFO */
            _.Move("R4700-00-INS-RELACIONA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4278- MOVE 'INS .................' TO COMANDO */
            _.Move("INS .................", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4280- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4282- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO GE085-NUM-CERTIFICADO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, GE085.DCLGE_CLIENTE_EMPRESA.GE085_NUM_CERTIFICADO);

            /*" -4283- MOVE 'BI' TO GE085-IND-TP-PROPOSTA */
            _.Move("BI", GE085.DCLGE_CLIENTE_EMPRESA.GE085_IND_TP_PROPOSTA);

            /*" -4284- MOVE 001 TO GE085-COD-ENDERECO-PJ */
            _.Move(001, GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_ENDERECO_PJ);

            /*" -4285- MOVE W-COD-CLIENTE-JUR TO GE085-COD-CLIENTE-PJ */
            _.Move(W_COD_CLIENTE_JUR, GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_CLIENTE_PJ);

            /*" -4287- MOVE W-COD-CLIENTE-FIS TO GE085-COD-CLIENTE-PF */
            _.Move(W_COD_CLIENTE_FIS, GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_CLIENTE_PF);

            /*" -4306- PERFORM R4700_00_INS_RELACIONAMENTO_DB_INSERT_1 */

            R4700_00_INS_RELACIONAMENTO_DB_INSERT_1();

            /*" -4310- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4311- DISPLAY 'PF0602B - ERRO NO INS GE_CLIENTE_EMPRESA' */
                _.Display($"PF0602B - ERRO NO INS GE_CLIENTE_EMPRESA");

                /*" -4312- DISPLAY 'BILHETE: ' GE085-NUM-CERTIFICADO */
                _.Display($"BILHETE: {GE085.DCLGE_CLIENTE_EMPRESA.GE085_NUM_CERTIFICADO}");

                /*" -4313- DISPLAY 'SQLCODE: ' SQLCODE */
                _.Display($"SQLCODE: {DB.SQLCODE}");

                /*" -4314- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4316- END-IF */
            }


            /*" -4316- . */

        }

        [StopWatch]
        /*" R4700-00-INS-RELACIONAMENTO-DB-INSERT-1 */
        public void R4700_00_INS_RELACIONAMENTO_DB_INSERT_1()
        {
            /*" -4306- EXEC SQL INSERT INTO SEGUROS.GE_CLIENTE_EMPRESA ( NUM_CERTIFICADO , IND_TP_PROPOSTA , COD_CLIENTE_PJ , COD_ENDERECO_PJ , COD_CLIENTE_PF , COD_USUARIO , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( :GE085-NUM-CERTIFICADO , :GE085-IND-TP-PROPOSTA , :GE085-COD-CLIENTE-PJ , :GE085-COD-ENDERECO-PJ , :GE085-COD-CLIENTE-PF , 'PF0602B' , 'PF0602B' , CURRENT TIMESTAMP ) END-EXEC */

            var r4700_00_INS_RELACIONAMENTO_DB_INSERT_1_Insert1 = new R4700_00_INS_RELACIONAMENTO_DB_INSERT_1_Insert1()
            {
                GE085_NUM_CERTIFICADO = GE085.DCLGE_CLIENTE_EMPRESA.GE085_NUM_CERTIFICADO.ToString(),
                GE085_IND_TP_PROPOSTA = GE085.DCLGE_CLIENTE_EMPRESA.GE085_IND_TP_PROPOSTA.ToString(),
                GE085_COD_CLIENTE_PJ = GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_CLIENTE_PJ.ToString(),
                GE085_COD_ENDERECO_PJ = GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_ENDERECO_PJ.ToString(),
                GE085_COD_CLIENTE_PF = GE085.DCLGE_CLIENTE_EMPRESA.GE085_COD_CLIENTE_PF.ToString(),
            };

            R4700_00_INS_RELACIONAMENTO_DB_INSERT_1_Insert1.Execute(r4700_00_INS_RELACIONAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4700_99_SAIDA*/

        [StopWatch]
        /*" R5634-00-SELECT-SEGUROS-PF-CBO-SECTION */
        private void R5634_00_SELECT_SEGUROS_PF_CBO_SECTION()
        {
            /*" -4322- MOVE 'R5634-00-SELECT-SEGUROS-PF-CBO     ' TO PARAGRAFO. */
            _.Move("R5634-00-SELECT-SEGUROS-PF-CBO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4323- MOVE 'SELECT PF_CBO                      ' TO COMANDO. */
            _.Move("SELECT PF_CBO                      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4325- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4328- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PF062-NUM-PROPOSTA-SIVPF */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF);

            /*" -4334- PERFORM R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1 */

            R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1();

            /*" -4337- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -4338- MOVE PF062-DES-CBO TO WHOST-PROFISSAO */
                _.Move(PF062.DCLPF_CBO.PF062_DES_CBO, WHOST_PROFISSAO);

                /*" -4339- ELSE */
            }
            else
            {


                /*" -4340- IF WHOST-PROFISSAO = SPACES */

                if (WHOST_PROFISSAO.IsEmpty())
                {

                    /*" -4341- MOVE 'NAO INFORMADA' TO WHOST-PROFISSAO */
                    _.Move("NAO INFORMADA", WHOST_PROFISSAO);

                    /*" -4342- END-IF */
                }


                /*" -4342- MOVE ZEROS TO SQLCODE. */
                _.Move(0, DB.SQLCODE);
            }


        }

        [StopWatch]
        /*" R5634-00-SELECT-SEGUROS-PF-CBO-DB-SELECT-1 */
        public void R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1()
        {
            /*" -4334- EXEC SQL SELECT DES_CBO INTO :PF062-DES-CBO FROM SEGUROS.PF_CBO WHERE NUM_PROPOSTA_SIVPF = :PF062-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1 = new R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1()
            {
                PF062_NUM_PROPOSTA_SIVPF = PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1.Execute(r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF062_DES_CBO, PF062.DCLPF_CBO.PF062_DES_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5634_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-SECTION */
        private void R6000_00_DECLARE_AGENCEF_SECTION()
        {
            /*" -4350- MOVE 'R6000-DECLA-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6000-DECLA-AGENCEF   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4351- MOVE 'DECLARE AGENCIACEF   ' TO COMANDO. */
            _.Move("DECLARE AGENCIACEF   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4353- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4362- PERFORM R6000_00_DECLARE_AGENCEF_DB_DECLARE_1 */

            R6000_00_DECLARE_AGENCEF_DB_DECLARE_1();

            /*" -4364- PERFORM R6000_00_DECLARE_AGENCEF_DB_OPEN_1 */

            R6000_00_DECLARE_AGENCEF_DB_OPEN_1();

            /*" -4367- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4368- DISPLAY 'R6000 - PROBLEMAS DECLARE (AGENCEF) ..' */
                _.Display($"R6000 - PROBLEMAS DECLARE (AGENCEF) ..");

                /*" -4369- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -4369- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-OPEN-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_OPEN_1()
        {
            /*" -4364- EXEC SQL OPEN C01_AGENCEF END-EXEC. */

            C01_AGENCEF.Open();

        }

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R6100_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -4425- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO ORDER BY COD_CBO WITH UR END-EXEC. */
            CCBO = new PF0602B_CCBO(false);
            string GetQuery_CCBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							ORDER BY COD_CBO";

                return query;
            }
            CCBO.GetQueryEvent += GetQuery_CCBO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-SECTION */
        private void R6010_00_FETCH_AGENCEF_SECTION()
        {
            /*" -4377- MOVE 'R6010-FETCH-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6010-FETCH-AGENCEF   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4380- MOVE 'FETCH   AGENCIACEF    ' TO COMANDO. */
            _.Move("FETCH   AGENCIACEF    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4383- PERFORM R6010_00_FETCH_AGENCEF_DB_FETCH_1 */

            R6010_00_FETCH_AGENCEF_DB_FETCH_1();

            /*" -4386- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4387- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4388- MOVE 'S' TO WFIM-AGENCEF */
                    _.Move("S", WORK_AREA.WFIM_AGENCEF);

                    /*" -4388- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_1 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_1();

                    /*" -4390- ELSE */
                }
                else
                {


                    /*" -4390- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_2 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_2();

                    /*" -4392- DISPLAY '3100 - (PROBLEMAS NO FETCH AGENCEF) ..' */
                    _.Display($"3100 - (PROBLEMAS NO FETCH AGENCEF) ..");

                    /*" -4393- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -4393- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-FETCH-1 */
        public void R6010_00_FETCH_AGENCEF_DB_FETCH_1()
        {
            /*" -4383- EXEC SQL FETCH C01_AGENCEF INTO :DCLAGENCIAS-CEF.COD-AGENCIA, :DCLMALHA-CEF.MALHACEF-COD-FONTE END-EXEC. */

            if (C01_AGENCEF.Fetch())
            {
                _.Move(C01_AGENCEF.DCLAGENCIAS_CEF_COD_AGENCIA, AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA);
                _.Move(C01_AGENCEF.DCLMALHA_CEF_MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-1 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_1()
        {
            /*" -4388- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-2 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_2()
        {
            /*" -4390- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }

        [StopWatch]
        /*" R6020-00-CARREGA-FILIAL-SECTION */
        private void R6020_00_CARREGA_FILIAL_SECTION()
        {
            /*" -4403- MOVE 'R6020-CARREGA-FILIAL    ' TO PARAGRAFO. */
            _.Move("R6020-CARREGA-FILIAL    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4405- MOVE COD-AGENCIA OF DCLAGENCIAS-CEF TO TAB-AGENCIA (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA, TAB_FILIAIS.TAB_FILIAL.FILLER_15[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_AGENCIA);

            /*" -4408- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-FONTE (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAIS.TAB_FILIAL.FILLER_15[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_FONTE);

            /*" -4408- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6020_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-SECTION */
        private void R6100_00_DECLARE_CBO_SECTION()
        {
            /*" -4416- MOVE 'R6100-DECLA-CBO         ' TO PARAGRAFO. */
            _.Move("R6100-DECLA-CBO         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4417- MOVE 'DECLARE CBO             ' TO COMANDO. */
            _.Move("DECLARE CBO             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4419- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4425- PERFORM R6100_00_DECLARE_CBO_DB_DECLARE_1 */

            R6100_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -4427- PERFORM R6100_00_DECLARE_CBO_DB_OPEN_1 */

            R6100_00_DECLARE_CBO_DB_OPEN_1();

            /*" -4430- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4431- DISPLAY 'R6100 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R6100 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -4432- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -4432- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-DB-OPEN-1 */
        public void R6100_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -4427- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-DECLARE-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_DECLARE_1()
        {
            /*" -5063- EXEC SQL DECLARE C01_GECLIMOV CURSOR FOR SELECT TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_ENDERECO BETWEEN :WHOST-OCORR-END-I AND :WHOST-OCORR-END-F ORDER BY OCORR_HIST DESC WITH UR END-EXEC. */
            C01_GECLIMOV = new PF0602B_C01_GECLIMOV(true);
            string GetQuery_C01_GECLIMOV()
            {
                var query = @$"SELECT TIPO_MOVIMENTO
							, 
							DATA_ULT_MANUTEN
							, 
							NOME_RAZAO
							, 
							TIPO_PESSOA
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							CEP
							, 
							DDD
							, 
							TELEFONE
							, 
							FAX
							, 
							OCORR_HIST
							, 
							CGCCPF
							, 
							DATA_NASCIMENTO 
							FROM SEGUROS.GE_CLIENTES_MOVTO 
							WHERE COD_CLIENTE = '{GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}' 
							AND OCORR_ENDERECO BETWEEN '{WHOST_OCORR_END_I}' 
							AND '{WHOST_OCORR_END_F}' 
							ORDER BY OCORR_HIST DESC";

                return query;
            }
            C01_GECLIMOV.GetQueryEvent += GetQuery_C01_GECLIMOV;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-FETCH-CBO-SECTION */
        private void R6110_00_FETCH_CBO_SECTION()
        {
            /*" -4440- MOVE '6110-00-FETCH-CBO       ' TO PARAGRAFO. */
            _.Move("6110-00-FETCH-CBO       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4443- MOVE 'FETCH  CCBO             ' TO COMANDO. */
            _.Move("FETCH  CCBO             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4446- PERFORM R6110_00_FETCH_CBO_DB_FETCH_1 */

            R6110_00_FETCH_CBO_DB_FETCH_1();

            /*" -4449- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4450- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4451- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", WORK_AREA.WFIM_CBO);

                    /*" -4451- PERFORM R6110_00_FETCH_CBO_DB_CLOSE_1 */

                    R6110_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -4453- ELSE */
                }
                else
                {


                    /*" -4453- PERFORM R6110_00_FETCH_CBO_DB_CLOSE_2 */

                    R6110_00_FETCH_CBO_DB_CLOSE_2();

                    /*" -4455- DISPLAY '6110 - (PROBLEMAS NO FETCH CCBO     ) ..' */
                    _.Display($"6110 - (PROBLEMAS NO FETCH CCBO     ) ..");

                    /*" -4456- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -4456- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-FETCH-1 */
        public void R6110_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -4446- EXEC SQL FETCH CCBO INTO :DCLCBO.CBO-COD-CBO, :DCLCBO.CBO-DESCR-CBO END-EXEC. */

            if (CCBO.Fetch())
            {
                _.Move(CCBO.DCLCBO_CBO_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);
                _.Move(CCBO.DCLCBO_CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-CLOSE-1 */
        public void R6110_00_FETCH_CBO_DB_CLOSE_1()
        {
            /*" -4451- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6110_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-CLOSE-2 */
        public void R6110_00_FETCH_CBO_DB_CLOSE_2()
        {
            /*" -4453- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }

        [StopWatch]
        /*" R6120-00-CARREGA-CBO-SECTION */
        private void R6120_00_CARREGA_CBO_SECTION()
        {
            /*" -4466- MOVE '6120-00-CARREGA-CBO     ' TO PARAGRAFO. */
            _.Move("6120-00-CARREGA-CBO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4468- IF CBO-COD-CBO OF DCLCBO > 0 AND CBO-COD-CBO OF DCLCBO < 1000 */

            if (CBO.DCLCBO.CBO_COD_CBO > 0 && CBO.DCLCBO.CBO_COD_CBO < 1000)
            {

                /*" -4470- MOVE CBO-COD-CBO OF DCLCBO TO TAB-COD-CBO (CBO-COD-CBO OF DCLCBO) */
                _.Move(CBO.DCLCBO.CBO_COD_CBO, TAB_CBO1.TAB_CBO.FILLER_16[CBO.DCLCBO.CBO_COD_CBO].TAB_COD_CBO);

                /*" -4473- MOVE CBO-DESCR-CBO OF DCLCBO TO TAB-DESCR-CBO (CBO-COD-CBO OF DCLCBO) TAB-DESCR-CBO-C (CBO-COD-CBO OF DCLCBO) */
                _.Move(CBO.DCLCBO.CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_16[CBO.DCLCBO.CBO_COD_CBO].TAB_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_16[CBO.DCLCBO.CBO_COD_CBO].TAB_DESCR_CBO_C);

                /*" -4475- END-IF */
            }


            /*" -4475- PERFORM R6110-00-FETCH-CBO. */

            R6110_00_FETCH_CBO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6120_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-PROCURA-RISCO-PROP-SECTION */
        private void R8500_00_PROCURA_RISCO_PROP_SECTION()
        {
            /*" -4488- MOVE 'R8500-00-PROCURA-RISCO-PROP ' TO PARAGRAFO. */
            _.Move("R8500-00-PROCURA-RISCO-PROP ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4490- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4491- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -4493- MOVE 'PF0602B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("PF0602B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -4494- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -4497- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -4498- MOVE 0 TO LK-VG009-IND-ERRO */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO);

            /*" -4500- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA);

            /*" -4502- MOVE 0 TO LK-VG009-SQLCODE WS-ERRO-VG009 */
            _.Move(0, SPVG009W.LK_VG009_SQLCODE, WS_ERRO_VG009);

            /*" -4504- MOVE SPACES TO LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_SQLERRMC);

            /*" -4506- MOVE 'SPBVG009' TO WS-PROGRAMA */
            _.Move("SPBVG009", WS_PROGRAMA);

            /*" -4527- CALL WS-PROGRAMA USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_PROGRAMA, SPVG009W);

            /*" -4528- IF LK-VG009-IND-ERRO NOT EQUAL ZEROS AND 1 */

            if (!SPVG009W.LK_VG009_IND_ERRO.In("00", "1"))
            {

                /*" -4529- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -4530- DISPLAY '* R8500 - PROBLEMAS CALL SUBROTINA SPBVG009   *' */
                _.Display($"* R8500 - PROBLEMAS CALL SUBROTINA SPBVG009   *");

                /*" -4531- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -4532- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -4533- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -4534- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -4535- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -4536- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -4537- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -4538- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -4539- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -4540- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -4541- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4543- END-IF */
            }


            /*" -4544- IF LK-VG009-S-COD-CLASSIF-RISCO EQUAL 04 */

            if (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO == 04)
            {

                /*" -4546- DISPLAY 'DESPREZADO RISCO CRITICO.: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"DESPREZADO RISCO CRITICO.: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -4547- ADD 1 TO WS-QT-EM-CRITICA */
                WS_QT_EM_CRITICA.Value = WS_QT_EM_CRITICA + 1;

                /*" -4548- MOVE 1 TO WS-TEM-ERRO */
                _.Move(1, WORK_AREA.WS_TEM_ERRO);

                /*" -4549- MOVE 'S' TO WS-TEM-ERRO-CRITICO */
                _.Move("S", WS_TEM_ERRO_CRITICO);

                /*" -4550- END-IF */
            }


            /*" -4550- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_EXIT*/

        [StopWatch]
        /*" R8555-00-GRAVA-RISCO-MOTOR-SECTION */
        private void R8555_00_GRAVA_RISCO_MOTOR_SECTION()
        {
            /*" -4560- MOVE 'R8555-00-GRAVA-RISCO-MOTOR  ' TO PARAGRAFO. */
            _.Move("R8555-00-GRAVA-RISCO-MOTOR  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4562- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4564- MOVE 0 TO WS-ERRO-VG009 */
            _.Move(0, WS_ERRO_VG009);

            /*" -4565-  EVALUATE TRUE  */

            /*" -4566-  WHEN LK-VG009-IND-ERRO = 00  */

            /*" -4566- IF LK-VG009-IND-ERRO = 00 */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -4567- PERFORM R8550-00-GRAVA-CLASSIF-RISCO */

                R8550_00_GRAVA_CLASSIF_RISCO_SECTION();

                /*" -4568-  WHEN LK-VG009-IND-ERRO = 01  */

                /*" -4568- ELSE IF LK-VG009-IND-ERRO = 01 */
            }
            else

            if (SPVG009W.LK_VG009_IND_ERRO == 01)
            {

                /*" -4569- IF LK-VG009-SQLCODE = +100 */

                if (SPVG009W.LK_VG009_SQLCODE == +100)
                {

                    /*" -4570- PERFORM R8560-00-GRAVA-EMITE-SEM-RISCO */

                    R8560_00_GRAVA_EMITE_SEM_RISCO_SECTION();

                    /*" -4571- ELSE */
                }
                else
                {


                    /*" -4572- MOVE 1 TO WS-ERRO-VG009 */
                    _.Move(1, WS_ERRO_VG009);

                    /*" -4573- END-IF */
                }


                /*" -4574-  WHEN OTHER  */

                /*" -4574- ELSE */
            }
            else
            {


                /*" -4575- MOVE 1 TO WS-ERRO-VG009 */
                _.Move(1, WS_ERRO_VG009);

                /*" -4577-  END-EVALUATE  */

                /*" -4577- END-IF */
            }


            /*" -4578- IF WS-ERRO-VG009 NOT EQUAL ZEROS */

            if (WS_ERRO_VG009 != 00)
            {

                /*" -4579- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -4580- DISPLAY '* 8555 - PROBLEMAS CALL SUBROTINA SPBVG009    *' */
                _.Display($"* 8555 - PROBLEMAS CALL SUBROTINA SPBVG009    *");

                /*" -4581- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -4582- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -4583- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -4584- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -4585- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -4586- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -4587- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -4588- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -4590- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -4591- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4592- END-IF */
            }


            /*" -4592- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8555_99_SAIDA*/

        [StopWatch]
        /*" R8550-00-GRAVA-CLASSIF-RISCO-SECTION */
        private void R8550_00_GRAVA_CLASSIF_RISCO_SECTION()
        {
            /*" -4604- MOVE 'R8550-00-GRAVA-CLASSIF-RISCO ' TO PARAGRAFO. */
            _.Move("R8550-00-GRAVA-CLASSIF-RISCO ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4606- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4607- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -4608- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -4610- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -4611- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -4612- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -4613- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -4614- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -4615- MOVE 'PF0602B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("PF0602B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -4616- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -4617- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -4618- MOVE 35 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(35, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -4620- MOVE 'CADASTRAMENTO DE AVALIACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CADASTRAMENTO DE AVALIACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -4622- ADD 1 TO WS-QT-EMISSAO-C-RISCO */
            WS_QT_EMISSAO_C_RISCO.Value = WS_QT_EMISSAO_C_RISCO + 1;

            /*" -4624- EVALUATE LK-VG009-S-COD-CLASSIF-RISCO */
            switch (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO.Value)
            {

                /*" -4625- WHEN 01 */
                case 01:

                    /*" -4627- MOVE 2 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(2, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -4628- WHEN 02 */
                    break;
                case 02:

                    /*" -4630- MOVE 3 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(3, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -4631- WHEN 03 */
                    break;
                case 03:

                    /*" -4633- MOVE 4 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(4, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -4634- WHEN 04 */
                    break;
                case 04:

                    /*" -4635- MOVE 1 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(1, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -4636- WHEN OTHER */
                    break;
                default:

                    /*" -4639- DISPLAY 'ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA' LK-VG009-S-COD-CLASSIF-RISCO */
                    _.Display($"ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA{SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO}");

                    /*" -4640- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4642- END-EVALUATE */
                    break;
            }


            /*" -4644- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -4645- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -4646- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -4650- DISPLAY 'ERRO JAH GRAVADO 8550 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8550 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -4651- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4652- ELSE */
                }
                else
                {


                    /*" -4653- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4654- DISPLAY '* 8550 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 8550 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -4655- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4656- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -4657- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -4658- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4659- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -4660- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -4661- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -4663- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4664- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -4665- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4666- END-IF */
                }


                /*" -4667- END-IF */
            }


            /*" -4667- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/

        [StopWatch]
        /*" R8560-00-GRAVA-EMITE-SEM-RISCO-SECTION */
        private void R8560_00_GRAVA_EMITE_SEM_RISCO_SECTION()
        {
            /*" -4678- MOVE 'R8560-00-GRAVA-EMITE-SEM-RISCO' TO PARAGRAFO. */
            _.Move("R8560-00-GRAVA-EMITE-SEM-RISCO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4680- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4681- MOVE 5 TO WS-COD-CRITICA */
            _.Move(5, WS_COD_CRITICA);

            /*" -4683- PERFORM R8600-00-CONS-COD-CRITICA */

            R8600_00_CONS_COD_CRITICA_SECTION();

            /*" -4684- IF VG001-IND-EXISTE EQUAL 'S' */

            if (SPVG001V.VG001_IND_EXISTE == "S")
            {

                /*" -4685- GO TO R8560-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8560_99_SAIDA*/ //GOTO
                return;

                /*" -4689- END-IF */
            }


            /*" -4691- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -4692- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -4693- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -4695- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -4696- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -4697- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -4698- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -4699- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -4700- MOVE 'PF0602B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("PF0602B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -4701- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -4702- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -4703- MOVE 45 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(45, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -4704- MOVE 5 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(5, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -4706- MOVE 'EMISSAO DE BILHETE SEM CLASSIFICACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EMISSAO DE BILHETE SEM CLASSIFICACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -4708- ADD 1 TO WS-QT-EMISSAO-S-RISCO */
            WS_QT_EMISSAO_S_RISCO.Value = WS_QT_EMISSAO_S_RISCO + 1;

            /*" -4710- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -4711- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -4712- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -4716- DISPLAY 'ERRO JAH GRAVADO 8560 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8560 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -4717- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4718- ELSE */
                }
                else
                {


                    /*" -4719- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4720- DISPLAY '* 8560 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 8560 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -4721- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4722- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -4723- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -4724- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4725- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -4726- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -4727- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -4729- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4730- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -4731- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4732- END-IF */
                }


                /*" -4733- END-IF */
            }


            /*" -4733- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8560_99_SAIDA*/

        [StopWatch]
        /*" R8600-00-CONS-COD-CRITICA-SECTION */
        private void R8600_00_CONS_COD_CRITICA_SECTION()
        {
            /*" -4742- MOVE 'R8600-00-CONS-COD-CRITICA' TO PARAGRAFO. */
            _.Move("R8600-00-CONS-COD-CRITICA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4744- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4745- MOVE 'N' TO VG001-IND-EXISTE */
            _.Move("N", SPVG001V.VG001_IND_EXISTE);

            /*" -4746- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -4747- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -4749- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -4750- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -4751- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -4752- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -4753- MOVE WS-COD-CRITICA TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WS_COD_CRITICA, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -4754- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -4755- MOVE 'PF0602B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("PF0602B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -4756- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -4757- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -4758- MOVE 00 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(00, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -4760- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -4762- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -4763- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -4764- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -4765- MOVE 'S' TO VG001-IND-EXISTE */
                    _.Move("S", SPVG001V.VG001_IND_EXISTE);

                    /*" -4766- ELSE */
                }
                else
                {


                    /*" -4767- MOVE 'N' TO VG001-IND-EXISTE */
                    _.Move("N", SPVG001V.VG001_IND_EXISTE);

                    /*" -4768- END-IF */
                }


                /*" -4769- ELSE */
            }
            else
            {


                /*" -4770- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4771- DISPLAY '* 8600 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"* 8600 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -4772- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4773- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -4774- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -4775- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -4776- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -4777- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -4778- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -4780- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4781- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -4782- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4783- END-IF */
            }


            /*" -4783- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-UPDATE-NUM-OUTROS-SECTION */
        private void R9100_00_UPDATE_NUM_OUTROS_SECTION()
        {
            /*" -4793- MOVE '9100-00-UPDATE-NUM-OUTROS    ' TO PARAGRAFO. */
            _.Move("9100-00-UPDATE-NUM-OUTROS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4794- MOVE 'UPDATE NUM_OUTROS            ' TO COMANDO. */
            _.Move("UPDATE NUM_OUTROS            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4796- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4800- PERFORM R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1 */

            R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1();

            /*" -4803- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4804- DISPLAY 'PROBLEMAS NO UPDATE DA NUMERO OUTROS' */
                _.Display($"PROBLEMAS NO UPDATE DA NUMERO OUTROS");

                /*" -4804- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9100-00-UPDATE-NUM-OUTROS-DB-UPDATE-1 */
        public void R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1()
        {
            /*" -4800- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CLIENTE = :DCLNUMERO-OUTROS.NUM-CLIENTE WHERE 1 = 1 END-EXEC. */

            var r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1 = new R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1()
            {
                NUM_CLIENTE = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.ToString(),
            };

            R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1.Execute(r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9200-00-UPDATE-PROPSSBI-SECTION */
        private void R9200_00_UPDATE_PROPSSBI_SECTION()
        {
            /*" -4812- MOVE '9200-00-UPDATE-PROPSSBI      ' TO PARAGRAFO */
            _.Move("9200-00-UPDATE-PROPSSBI      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4813- MOVE 'UPDATE PROP_SASSE_BILHETE    ' TO COMANDO. */
            _.Move("UPDATE PROP_SASSE_BILHETE    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4815- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4822- PERFORM R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1 */

            R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1();

            /*" -4824- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4825- DISPLAY 'PROBLEMAS NO UPDATE DA PROP_SASSE_BILHETE' */
                _.Display($"PROBLEMAS NO UPDATE DA PROP_SASSE_BILHETE");

                /*" -4825- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9200-00-UPDATE-PROPSSBI-DB-UPDATE-1 */
        public void R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1()
        {
            /*" -4822- EXEC SQL UPDATE SEGUROS.PROP_SASSE_BILHETE SET DATA_INCLUSAO = :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO:VIND-DTMOVTO, COD_USUARIO = 'PF0602B' WHERE NUM_IDENTIFICACAO = :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO END-EXEC */

            var r9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1 = new R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
                NUM_IDENTIFICACAO = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO.ToString(),
            };

            R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1.Execute(r9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9200_99_SAIDA*/

        [StopWatch]
        /*" R9300-00-TRATA-MOVTO-CLIENTE-SECTION */
        private void R9300_00_TRATA_MOVTO_CLIENTE_SECTION()
        {
            /*" -4833- MOVE '9300-00-TRATA-MOVTO-CLIENTE' TO PARAGRAFO */
            _.Move("9300-00-TRATA-MOVTO-CLIENTE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4835- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4837- MOVE COD-CLIENTE OF DCLCLIENTES TO WWORK-COD-CLIENTE */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, WS_GECLIMOV.WWORK_COD_CLIENTE);

            /*" -4839- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO WWORK-DATA-ULT-MANUTEN */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_GECLIMOV.WWORK_DATA_ULT_MANUTEN);

            /*" -4841- MOVE PESSOA-NOME-PESSOA OF DCLPESSOA TO WWORK-NOME-RAZAO */
            _.Move(PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA, WS_GECLIMOV.WWORK_NOME_RAZAO);

            /*" -4843- MOVE 'F' TO WWORK-TIPO-PESSOA */
            _.Move("F", WS_GECLIMOV.WWORK_TIPO_PESSOA);

            /*" -4844- IF SEXO OF DCLPESSOA-FISICA EQUAL 'M' OR 'F' */

            if (PESFIS.DCLPESSOA_FISICA.SEXO.In("M", "F"))
            {

                /*" -4845- MOVE SEXO OF DCLPESSOA-FISICA TO WWORK-IDE-SEXO */
                _.Move(PESFIS.DCLPESSOA_FISICA.SEXO, WS_GECLIMOV.WWORK_IDE_SEXO);

                /*" -4846- ELSE */
            }
            else
            {


                /*" -4847- MOVE SPACES TO WWORK-IDE-SEXO */
                _.Move("", WS_GECLIMOV.WWORK_IDE_SEXO);

                /*" -4848- END-IF */
            }


            /*" -4850- IF ESTADO-CIVIL OF DCLPESSOA-FISICA EQUAL 'S' OR 'C' OR 'V' OR 'D' OR 'O' */

            if (PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.In("S", "C", "V", "D", "O"))
            {

                /*" -4852- MOVE ESTADO-CIVIL OF DCLPESSOA-FISICA TO WWORK-ESTADO-CIVIL */
                _.Move(PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL, WS_GECLIMOV.WWORK_ESTADO_CIVIL);

                /*" -4853- ELSE */
            }
            else
            {


                /*" -4854- MOVE SPACES TO WWORK-ESTADO-CIVIL */
                _.Move("", WS_GECLIMOV.WWORK_ESTADO_CIVIL);

                /*" -4856- END-IF */
            }


            /*" -4857- MOVE 1 TO WWORK-OCORR-ENDERECO */
            _.Move(1, WS_GECLIMOV.WWORK_OCORR_ENDERECO);

            /*" -4859- MOVE ENDERECO OF DCLPESSOA-ENDERECO TO WWORK-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.ENDERECO, WS_GECLIMOV.WWORK_ENDERECO);

            /*" -4861- MOVE BAIRRO OF DCLPESSOA-ENDERECO TO WWORK-BAIRRO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.BAIRRO, WS_GECLIMOV.WWORK_BAIRRO);

            /*" -4863- MOVE CIDADE OF DCLPESSOA-ENDERECO TO WWORK-CIDADE */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CIDADE, WS_GECLIMOV.WWORK_CIDADE);

            /*" -4865- MOVE SIGLA-UF OF DCLPESSOA-ENDERECO TO WWORK-SIGLA-UF */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF, WS_GECLIMOV.WWORK_SIGLA_UF);

            /*" -4867- MOVE CEP OF DCLPESSOA-ENDERECO TO WWORK-CEP */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CEP, WS_GECLIMOV.WWORK_CEP);

            /*" -4868- MOVE WHOST-DDD TO WWORK-DDD */
            _.Move(WHOST_DDD, WS_GECLIMOV.WWORK_DDD);

            /*" -4869- MOVE WHOST-TELEFONE TO WWORK-TELEFONE */
            _.Move(WHOST_TELEFONE, WS_GECLIMOV.WWORK_TELEFONE);

            /*" -4870- MOVE WHOST-FAX TO WWORK-FAX */
            _.Move(WHOST_FAX, WS_GECLIMOV.WWORK_FAX);

            /*" -4871- MOVE CPF OF DCLPESSOA-FISICA TO WWORK-CGCCPF */
            _.Move(PESFIS.DCLPESSOA_FISICA.CPF, WS_GECLIMOV.WWORK_CGCCPF);

            /*" -4874- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WWORK-DATA-NASCIMENTO */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WS_GECLIMOV.WWORK_DATA_NASCIMENTO);

            /*" -4875- MOVE WWORK-COD-CLIENTE TO GECLIMOV-COD-CLIENTE */
            _.Move(WS_GECLIMOV.WWORK_COD_CLIENTE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE);

            /*" -4876- MOVE WWORK-OCORR-ENDERECO TO GECLIMOV-OCORR-ENDERECO */
            _.Move(WS_GECLIMOV.WWORK_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);

            /*" -4878- MOVE WWORK-TIPO-MOVIMENTO TO GECLIMOV-TIPO-MOVIMENTO */
            _.Move(WS_GECLIMOV.WWORK_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);

            /*" -4883- MOVE WWORK-DATA-ULT-MANUTEN TO GECLIMOV-DATA-ULT-MANUTEN */
            _.Move(WS_GECLIMOV.WWORK_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);

            /*" -4884- PERFORM R9310-00-MAX-GECLIMOV */

            R9310_00_MAX_GECLIMOV_SECTION();

            /*" -4886- ADD 1 TO GECLIMOV-OCORR-HIST */
            GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.Value = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST + 1;

            /*" -4887- IF GECLIMOV-OCORR-ENDERECO EQUAL ZEROS */

            if (GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO == 00)
            {

                /*" -4888- MOVE 0 TO WHOST-OCORR-END-I */
                _.Move(0, WHOST_OCORR_END_I);

                /*" -4889- MOVE 9999 TO WHOST-OCORR-END-F */
                _.Move(9999, WHOST_OCORR_END_F);

                /*" -4890- ELSE */
            }
            else
            {


                /*" -4893- MOVE GECLIMOV-OCORR-ENDERECO TO WHOST-OCORR-END-I WHOST-OCORR-END-F. */
                _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO, WHOST_OCORR_END_I, WHOST_OCORR_END_F);
            }


            /*" -4895- PERFORM R9320-00-SELECT-GECLIMOV */

            R9320_00_SELECT_GECLIMOV_SECTION();

            /*" -4896- IF WWORK-NOME-RAZAO EQUAL SPACES */

            if (WS_GECLIMOV.WWORK_NOME_RAZAO.IsEmpty())
            {

                /*" -4897- MOVE -1 TO VIND-NOME-RAZAO */
                _.Move(-1, VIND_NOME_RAZAO);

                /*" -4898- ELSE */
            }
            else
            {


                /*" -4899- MOVE +0 TO VIND-NOME-RAZAO */
                _.Move(+0, VIND_NOME_RAZAO);

                /*" -4901- MOVE WWORK-NOME-RAZAO TO GECLIMOV-NOME-RAZAO. */
                _.Move(WS_GECLIMOV.WWORK_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
            }


            /*" -4902- IF WWORK-TIPO-PESSOA EQUAL SPACES */

            if (WS_GECLIMOV.WWORK_TIPO_PESSOA.IsEmpty())
            {

                /*" -4903- MOVE -1 TO VIND-TIPO-PESSOA */
                _.Move(-1, VIND_TIPO_PESSOA);

                /*" -4904- ELSE */
            }
            else
            {


                /*" -4905- MOVE +0 TO VIND-TIPO-PESSOA */
                _.Move(+0, VIND_TIPO_PESSOA);

                /*" -4907- MOVE WWORK-TIPO-PESSOA TO GECLIMOV-TIPO-PESSOA. */
                _.Move(WS_GECLIMOV.WWORK_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
            }


            /*" -4908- IF WWORK-IDE-SEXO EQUAL SPACES */

            if (WS_GECLIMOV.WWORK_IDE_SEXO.IsEmpty())
            {

                /*" -4909- MOVE -1 TO VIND-IDE-SEXO */
                _.Move(-1, VIND_IDE_SEXO);

                /*" -4910- ELSE */
            }
            else
            {


                /*" -4911- MOVE +0 TO VIND-IDE-SEXO */
                _.Move(+0, VIND_IDE_SEXO);

                /*" -4913- MOVE WWORK-IDE-SEXO TO GECLIMOV-IDE-SEXO. */
                _.Move(WS_GECLIMOV.WWORK_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
            }


            /*" -4914- IF WWORK-ESTADO-CIVIL EQUAL SPACES */

            if (WS_GECLIMOV.WWORK_ESTADO_CIVIL.IsEmpty())
            {

                /*" -4915- MOVE -1 TO VIND-EST-CIVIL */
                _.Move(-1, VIND_EST_CIVIL);

                /*" -4916- ELSE */
            }
            else
            {


                /*" -4917- MOVE +0 TO VIND-EST-CIVIL */
                _.Move(+0, VIND_EST_CIVIL);

                /*" -4919- MOVE WWORK-ESTADO-CIVIL TO GECLIMOV-ESTADO-CIVIL. */
                _.Move(WS_GECLIMOV.WWORK_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
            }


            /*" -4920- IF WWORK-OCORR-ENDERECO EQUAL ZEROS */

            if (WS_GECLIMOV.WWORK_OCORR_ENDERECO == 00)
            {

                /*" -4921- MOVE -1 TO VIND-OCORR-END */
                _.Move(-1, VIND_OCORR_END);

                /*" -4922- ELSE */
            }
            else
            {


                /*" -4924- MOVE +0 TO VIND-OCORR-END. */
                _.Move(+0, VIND_OCORR_END);
            }


            /*" -4925- IF WWORK-ENDERECO EQUAL SPACES */

            if (WS_GECLIMOV.WWORK_ENDERECO.IsEmpty())
            {

                /*" -4926- MOVE -1 TO VIND-ENDERECO */
                _.Move(-1, VIND_ENDERECO);

                /*" -4927- ELSE */
            }
            else
            {


                /*" -4928- MOVE +0 TO VIND-ENDERECO */
                _.Move(+0, VIND_ENDERECO);

                /*" -4930- MOVE WWORK-ENDERECO TO GECLIMOV-ENDERECO. */
                _.Move(WS_GECLIMOV.WWORK_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
            }


            /*" -4931- IF WWORK-BAIRRO EQUAL SPACES */

            if (WS_GECLIMOV.WWORK_BAIRRO.IsEmpty())
            {

                /*" -4932- MOVE -1 TO VIND-BAIRRO */
                _.Move(-1, VIND_BAIRRO);

                /*" -4933- ELSE */
            }
            else
            {


                /*" -4934- MOVE +0 TO VIND-BAIRRO */
                _.Move(+0, VIND_BAIRRO);

                /*" -4936- MOVE WWORK-BAIRRO TO GECLIMOV-BAIRRO. */
                _.Move(WS_GECLIMOV.WWORK_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
            }


            /*" -4937- IF WWORK-CIDADE EQUAL SPACES */

            if (WS_GECLIMOV.WWORK_CIDADE.IsEmpty())
            {

                /*" -4938- MOVE -1 TO VIND-CIDADE */
                _.Move(-1, VIND_CIDADE);

                /*" -4939- ELSE */
            }
            else
            {


                /*" -4940- MOVE +0 TO VIND-CIDADE */
                _.Move(+0, VIND_CIDADE);

                /*" -4942- MOVE WWORK-CIDADE TO GECLIMOV-CIDADE. */
                _.Move(WS_GECLIMOV.WWORK_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
            }


            /*" -4943- IF WWORK-SIGLA-UF EQUAL SPACES */

            if (WS_GECLIMOV.WWORK_SIGLA_UF.IsEmpty())
            {

                /*" -4944- MOVE -1 TO VIND-SIGLA-UF */
                _.Move(-1, VIND_SIGLA_UF);

                /*" -4945- ELSE */
            }
            else
            {


                /*" -4946- MOVE +0 TO VIND-SIGLA-UF */
                _.Move(+0, VIND_SIGLA_UF);

                /*" -4948- MOVE WWORK-SIGLA-UF TO GECLIMOV-SIGLA-UF. */
                _.Move(WS_GECLIMOV.WWORK_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
            }


            /*" -4949- IF WWORK-CEP EQUAL ZEROS */

            if (WS_GECLIMOV.WWORK_CEP == 00)
            {

                /*" -4950- MOVE -1 TO VIND-CEP */
                _.Move(-1, VIND_CEP);

                /*" -4951- ELSE */
            }
            else
            {


                /*" -4952- MOVE +0 TO VIND-CEP */
                _.Move(+0, VIND_CEP);

                /*" -4954- MOVE WWORK-CEP TO GECLIMOV-CEP. */
                _.Move(WS_GECLIMOV.WWORK_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
            }


            /*" -4955- IF WWORK-DDD EQUAL ZEROS */

            if (WS_GECLIMOV.WWORK_DDD == 00)
            {

                /*" -4956- MOVE -1 TO VIND-DDD */
                _.Move(-1, VIND_DDD);

                /*" -4957- ELSE */
            }
            else
            {


                /*" -4958- MOVE +0 TO VIND-DDD */
                _.Move(+0, VIND_DDD);

                /*" -4960- MOVE WWORK-DDD TO GECLIMOV-DDD. */
                _.Move(WS_GECLIMOV.WWORK_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
            }


            /*" -4961- IF WWORK-TELEFONE EQUAL ZEROS */

            if (WS_GECLIMOV.WWORK_TELEFONE == 00)
            {

                /*" -4962- MOVE -1 TO VIND-TELEFONE */
                _.Move(-1, VIND_TELEFONE);

                /*" -4963- ELSE */
            }
            else
            {


                /*" -4964- MOVE +0 TO VIND-TELEFONE */
                _.Move(+0, VIND_TELEFONE);

                /*" -4966- MOVE WWORK-TELEFONE TO GECLIMOV-TELEFONE. */
                _.Move(WS_GECLIMOV.WWORK_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
            }


            /*" -4967- IF WWORK-FAX EQUAL ZEROS */

            if (WS_GECLIMOV.WWORK_FAX == 00)
            {

                /*" -4968- MOVE -1 TO VIND-FAX */
                _.Move(-1, VIND_FAX);

                /*" -4969- ELSE */
            }
            else
            {


                /*" -4970- MOVE +0 TO VIND-FAX */
                _.Move(+0, VIND_FAX);

                /*" -4972- MOVE WWORK-FAX TO GECLIMOV-FAX. */
                _.Move(WS_GECLIMOV.WWORK_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
            }


            /*" -4973- IF WWORK-CGCCPF EQUAL ZEROS */

            if (WS_GECLIMOV.WWORK_CGCCPF == 00)
            {

                /*" -4974- MOVE -1 TO VIND-CGCCPF */
                _.Move(-1, VIND_CGCCPF);

                /*" -4975- ELSE */
            }
            else
            {


                /*" -4976- MOVE +0 TO VIND-CGCCPF */
                _.Move(+0, VIND_CGCCPF);

                /*" -4978- MOVE WWORK-CGCCPF TO GECLIMOV-CGCCPF. */
                _.Move(WS_GECLIMOV.WWORK_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
            }


            /*" -4979- IF WWORK-DATA-NASCIMENTO EQUAL SPACES */

            if (WS_GECLIMOV.WWORK_DATA_NASCIMENTO.IsEmpty())
            {

                /*" -4980- MOVE -1 TO VIND-DTNASC */
                _.Move(-1, VIND_DTNASC);

                /*" -4981- ELSE */
            }
            else
            {


                /*" -4982- MOVE +0 TO VIND-DTNASC */
                _.Move(+0, VIND_DTNASC);

                /*" -4984- MOVE WWORK-DATA-NASCIMENTO TO GECLIMOV-DATA-NASCIMENTO. */
                _.Move(WS_GECLIMOV.WWORK_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
            }


            /*" -4986- MOVE 'PF0602B' TO GECLIMOV-COD-USUARIO */
            _.Move("PF0602B", GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO);

            /*" -4987- IF WTEM-GECLIMOV EQUAL 'N' */

            if (WS_GECLIMOV.WTEM_GECLIMOV == "N")
            {

                /*" -5003- IF VIND-NOME-RAZAO LESS ZEROS AND VIND-TIPO-PESSOA LESS ZEROS AND VIND-IDE-SEXO LESS ZEROS AND VIND-EST-CIVIL LESS ZEROS AND VIND-OCORR-END LESS ZEROS AND VIND-ENDERECO LESS ZEROS AND VIND-BAIRRO LESS ZEROS AND VIND-CIDADE LESS ZEROS AND VIND-SIGLA-UF LESS ZEROS AND VIND-CEP LESS ZEROS AND VIND-DDD LESS ZEROS AND VIND-TELEFONE LESS ZEROS AND VIND-FAX LESS ZEROS AND VIND-CGCCPF LESS ZEROS AND VIND-DTNASC LESS ZEROS NEXT SENTENCE */

                if (VIND_NOME_RAZAO < 00 && VIND_TIPO_PESSOA < 00 && VIND_IDE_SEXO < 00 && VIND_EST_CIVIL < 00 && VIND_OCORR_END < 00 && VIND_ENDERECO < 00 && VIND_BAIRRO < 00 && VIND_CIDADE < 00 && VIND_SIGLA_UF < 00 && VIND_CEP < 00 && VIND_DDD < 00 && VIND_TELEFONE < 00 && VIND_FAX < 00 && VIND_CGCCPF < 00 && VIND_DTNASC < 00)
                {

                    /*" -5004- ELSE */
                }
                else
                {


                    /*" -5005- PERFORM R9400-00-INSERT-GECLIMOV */

                    R9400_00_INSERT_GECLIMOV_SECTION();

                    /*" -5006- ELSE */
                }

            }
            else
            {


                /*" -5006- PERFORM R9450-00-UPDATE-GECLIMOV. */

                R9450_00_UPDATE_GECLIMOV_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9300_99_SAIDA*/

        [StopWatch]
        /*" R9310-00-MAX-GECLIMOV-SECTION */
        private void R9310_00_MAX_GECLIMOV_SECTION()
        {
            /*" -5014- MOVE '9310-00-MAX-GECLIMOV' TO PARAGRAFO */
            _.Move("9310-00-MAX-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5016- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5022- PERFORM R9310_00_MAX_GECLIMOV_DB_SELECT_1 */

            R9310_00_MAX_GECLIMOV_DB_SELECT_1();

            /*" -5025- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5026- DISPLAY 'PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ' */
                _.Display($"PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ");

                /*" -5027- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -5027- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9310-00-MAX-GECLIMOV-DB-SELECT-1 */
        public void R9310_00_MAX_GECLIMOV_DB_SELECT_1()
        {
            /*" -5022- EXEC SQL SELECT VALUE(MAX(OCORR_HIST), 0) INTO :GECLIMOV-OCORR-HIST FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE WITH UR END-EXEC. */

            var r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1 = new R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
            };

            var executed_1 = R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1.Execute(r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9310_99_SAIDA*/

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-SECTION */
        private void R9320_00_SELECT_GECLIMOV_SECTION()
        {
            /*" -5035- MOVE '9320-00-SELECT-GECLIMOV      ' TO PARAGRAFO */
            _.Move("9320-00-SELECT-GECLIMOV      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5036- MOVE 'DECLARE GECLIMOV             ' TO COMANDO. */
            _.Move("DECLARE GECLIMOV             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5038- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5063- PERFORM R9320_00_SELECT_GECLIMOV_DB_DECLARE_1 */

            R9320_00_SELECT_GECLIMOV_DB_DECLARE_1();

            /*" -5065- PERFORM R9320_00_SELECT_GECLIMOV_DB_OPEN_1 */

            R9320_00_SELECT_GECLIMOV_DB_OPEN_1();

            /*" -5068- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5069- DISPLAY 'PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ");

                /*" -5070- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -5071- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                /*" -5072- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                /*" -5073- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5075- END-IF. */
            }


            /*" -5077- MOVE 'FETCH C01_GECLIMOV ' TO COMANDO. */
            _.Move("FETCH C01_GECLIMOV ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5096- PERFORM R9320_00_SELECT_GECLIMOV_DB_FETCH_1 */

            R9320_00_SELECT_GECLIMOV_DB_FETCH_1();

            /*" -5099- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5100- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5100- PERFORM R9320_00_SELECT_GECLIMOV_DB_CLOSE_1 */

                    R9320_00_SELECT_GECLIMOV_DB_CLOSE_1();

                    /*" -5102- MOVE 'N' TO WTEM-GECLIMOV */
                    _.Move("N", WS_GECLIMOV.WTEM_GECLIMOV);

                    /*" -5103- ELSE */
                }
                else
                {


                    /*" -5104- DISPLAY 'PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ' */
                    _.Display($"PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ");

                    /*" -5105- DISPLAY 'CODCLIEN    ' GECLIMOV-COD-CLIENTE */
                    _.Display($"CODCLIEN    {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                    /*" -5106- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                    _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                    /*" -5107- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                    _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                    /*" -5108- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5109- END-IF */
                }


                /*" -5110- ELSE */
            }
            else
            {


                /*" -5111- MOVE 'S' TO WTEM-GECLIMOV */
                _.Move("S", WS_GECLIMOV.WTEM_GECLIMOV);

                /*" -5111- PERFORM R9320_00_SELECT_GECLIMOV_DB_CLOSE_2 */

                R9320_00_SELECT_GECLIMOV_DB_CLOSE_2();

                /*" -5112- END-IF. */
            }


        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-OPEN-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_OPEN_1()
        {
            /*" -5065- EXEC SQL OPEN C01_GECLIMOV END-EXEC. */

            C01_GECLIMOV.Open();

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-FETCH-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_FETCH_1()
        {
            /*" -5096- EXEC SQL FETCH C01_GECLIMOV INTO :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC END-EXEC. */

            if (C01_GECLIMOV.Fetch())
            {
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);
                _.Move(C01_GECLIMOV.GECLIMOV_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
                _.Move(C01_GECLIMOV.VIND_NOME_RAZAO, VIND_NOME_RAZAO);
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.VIND_TIPO_PESSOA, VIND_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.GECLIMOV_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
                _.Move(C01_GECLIMOV.VIND_IDE_SEXO, VIND_IDE_SEXO);
                _.Move(C01_GECLIMOV.GECLIMOV_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
                _.Move(C01_GECLIMOV.VIND_EST_CIVIL, VIND_EST_CIVIL);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_OCORR_END, VIND_OCORR_END);
                _.Move(C01_GECLIMOV.GECLIMOV_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_ENDERECO, VIND_ENDERECO);
                _.Move(C01_GECLIMOV.GECLIMOV_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
                _.Move(C01_GECLIMOV.VIND_BAIRRO, VIND_BAIRRO);
                _.Move(C01_GECLIMOV.GECLIMOV_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
                _.Move(C01_GECLIMOV.VIND_CIDADE, VIND_CIDADE);
                _.Move(C01_GECLIMOV.GECLIMOV_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
                _.Move(C01_GECLIMOV.VIND_SIGLA_UF, VIND_SIGLA_UF);
                _.Move(C01_GECLIMOV.GECLIMOV_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
                _.Move(C01_GECLIMOV.VIND_CEP, VIND_CEP);
                _.Move(C01_GECLIMOV.GECLIMOV_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
                _.Move(C01_GECLIMOV.VIND_DDD, VIND_DDD);
                _.Move(C01_GECLIMOV.GECLIMOV_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
                _.Move(C01_GECLIMOV.VIND_TELEFONE, VIND_TELEFONE);
                _.Move(C01_GECLIMOV.GECLIMOV_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
                _.Move(C01_GECLIMOV.VIND_FAX, VIND_FAX);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
                _.Move(C01_GECLIMOV.GECLIMOV_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
                _.Move(C01_GECLIMOV.VIND_CGCCPF, VIND_CGCCPF);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
                _.Move(C01_GECLIMOV.VIND_DTNASC, VIND_DTNASC);
            }

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-CLOSE-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_CLOSE_1()
        {
            /*" -5100- EXEC SQL CLOSE C01_GECLIMOV END-EXEC */

            C01_GECLIMOV.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9320_99_SAIDA*/

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-CLOSE-2 */
        public void R9320_00_SELECT_GECLIMOV_DB_CLOSE_2()
        {
            /*" -5111- EXEC SQL CLOSE C01_GECLIMOV END-EXEC */

            C01_GECLIMOV.Close();

        }

        [StopWatch]
        /*" R9400-00-INSERT-GECLIMOV-SECTION */
        private void R9400_00_INSERT_GECLIMOV_SECTION()
        {
            /*" -5120- MOVE '9400-00-INSERT-GECLIMOV      ' TO PARAGRAFO */
            _.Move("9400-00-INSERT-GECLIMOV      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5121- MOVE 'INSERT GE_CLIENTES_MOVTO     ' TO COMANDO. */
            _.Move("INSERT GE_CLIENTES_MOVTO     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5123- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5169- PERFORM R9400_00_INSERT_GECLIMOV_DB_INSERT_1 */

            R9400_00_INSERT_GECLIMOV_DB_INSERT_1();

            /*" -5172- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5173- DISPLAY 'PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ");

                /*" -5174- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -5175- DISPLAY 'OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -5175- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9400-00-INSERT-GECLIMOV-DB-INSERT-1 */
        public void R9400_00_INSERT_GECLIMOV_DB_INSERT_1()
        {
            /*" -5169- EXEC SQL INSERT INTO SEGUROS.GE_CLIENTES_MOVTO (COD_CLIENTE , TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO , COD_USUARIO , TIMESTAMP , DES_COMPLEMENTO) VALUES (:GECLIMOV-COD-CLIENTE , :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC , :GECLIMOV-COD-USUARIO:VIND-CODUSU , CURRENT TIMESTAMP , NULL) END-EXEC. */

            var r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1 = new R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                VIND_CODUSU = VIND_CODUSU.ToString(),
            };

            R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1.Execute(r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9400_99_SAIDA*/

        [StopWatch]
        /*" R9450-00-UPDATE-GECLIMOV-SECTION */
        private void R9450_00_UPDATE_GECLIMOV_SECTION()
        {
            /*" -5183- MOVE '9450-00-UPDATE-GECLIMOV ' TO PARAGRAFO */
            _.Move("9450-00-UPDATE-GECLIMOV ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5184- MOVE 'UPDATE GE_CLIENTES_MOVTO     ' TO COMANDO. */
            _.Move("UPDATE GE_CLIENTES_MOVTO     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5186- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5210- PERFORM R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1 */

            R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1();

            /*" -5213- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5214- DISPLAY 'PF0602B-PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ' */
                _.Display($"PF0602B-PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ");

                /*" -5215- DISPLAY 'PF0602B-CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"PF0602B-CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -5216- DISPLAY 'PF0602B-OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"PF0602B-OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -5216- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9450-00-UPDATE-GECLIMOV-DB-UPDATE-1 */
        public void R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1()
        {
            /*" -5210- EXEC SQL UPDATE SEGUROS.GE_CLIENTES_MOVTO SET TIPO_MOVIMENTO = :GECLIMOV-TIPO-MOVIMENTO, DATA_ULT_MANUTEN = :GECLIMOV-DATA-ULT-MANUTEN, NOME_RAZAO = :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO, TIPO_PESSOA = :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA, IDE_SEXO = :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO, ESTADO_CIVIL = :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL, OCORR_ENDERECO = :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END, ENDERECO = :GECLIMOV-ENDERECO:VIND-ENDERECO, BAIRRO = :GECLIMOV-BAIRRO:VIND-BAIRRO, CIDADE = :GECLIMOV-CIDADE:VIND-CIDADE, SIGLA_UF = :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF, CEP = :GECLIMOV-CEP:VIND-CEP , DDD = :GECLIMOV-DDD:VIND-DDD , TELEFONE = :GECLIMOV-TELEFONE:VIND-TELEFONE , FAX = :GECLIMOV-FAX:VIND-FAX , CGCCPF = :GECLIMOV-CGCCPF:VIND-CGCCPF , DATA_NASCIMENTO = :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC, COD_USUARIO = :GECLIMOV-COD-USUARIO , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_HIST = :GECLIMOV-OCORR-HIST END-EXEC. */

            var r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1 = new R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1()
            {
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
            };

            R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1.Execute(r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9450_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5227- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -5228- MOVE SQLCODE TO RETURN-CODE. */
            _.Move(DB.SQLCODE, RETURN_CODE);

            /*" -5229- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -5230- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -5231- DISPLAY WABEND. */
            _.Display(AREA_ABEND.WABEND);

            /*" -5232- DISPLAY 'SQLERRMC   ' SQLERRMC */
            _.Display($"SQLERRMC   {DB.SQLERRMC}");

            /*" -5233- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1);

            /*" -5235- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_2);

            /*" -5238- DISPLAY 'PROPOSTA ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Display($"PROPOSTA {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

            /*" -5238- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -5240- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5244- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5244- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}