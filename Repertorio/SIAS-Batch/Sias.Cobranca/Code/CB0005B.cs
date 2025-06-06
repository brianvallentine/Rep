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
using Sias.Cobranca.DB2.CB0005B;

namespace Code
{
    public class CB0005B
    {
        public bool IsCall { get; set; }

        public CB0005B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES DE SEGURO (SASSE)         *      */
        /*"      *   PROGRAMA ...............  CB0005B.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  WANGER C.SILVA / ALEXANDRE BURGOS  *      */
        /*"      *   PROGRAMADOR ............  ALEXANDRE BURGOS / ENRICO / WANGER *      */
        /*"      *   DATA CODIFICACAO .......  MARCO / 1995                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO MOVIMENTO DE BILHETES  *      */
        /*"      *                             (V0BILHETE), ATUALIZA O DB DE APO- *      */
        /*"      *                             LICES.                             *      */
        /*"      *                             PROGRAMA ESPECIFICO PARA:          *      */
        /*"      *                             SASSE CIA. NACIONAL DE SEGUROS     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.67  * VERSAO 67 ..: DEMANDA 538808 - PRODUTOS AP BEM ESTAR NO CCA    *      */
        /*"      *               8533 - AP BEM ESTAR - PU (12 MESES)              *      */
        /*"      *               8534 - AP BEM ESTAR - PU (36 MESES)              *      */
        /*"      *               (ESTES 2 PRODUTOS SAO COPIAS DO 8528 E 8529,     *      */
        /*"      *                APENAS FORAM CRIADOS PARA ATENDER CANAL CCA)    *      */
        /*"      *                                                                *      */
        /*"      * EM 03/09/2024 - CANETTA              PROCURE POR V.67          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.66  *  VERSAO 66  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/07/2024 - SERGIO LORETO                                *      */
        /*"      *                                       PROCURE POR V.66         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.65  *   VERSAO 65   - DEMANDA 575149 - APOIO +FUTURO (3729)          *      */
        /*"      *                 TIPO DE ENDOSSO '1' - NOVOS ACESSOS            *      */
        /*"      *                                                                *      */
        /*"      *   23/06/2024  - CANETTA               PROCURE POR V.65         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.64  *   VERSAO 64   - INCIDENTE 593096 - CORRIGIR CURSOR PRINCIPAL P/*      */
        /*"      *                 EMISSAO DE BILHETES REPRESADOS                 *      */
        /*"      *                                                                *      */
        /*"      *   26/06/2024  - ELIERMES/ROGER        PROCURE POR V.64         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.63  *   VERSAO 63   - DEMANDA 575149 - APOIO +FUTURO (3729)          *      */
        /*"      *                                                                *      */
        /*"      *   23/06/2024  - CANETTA               PROCURE POR V.63         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.63  *   VERSAO 63   - DEMANDA 575149 - APOIO +FUTURO (3729)          *      */
        /*"      *                                                                *      */
        /*"      *   28/06/2024  - CANETTA               PROCURE POR V.63         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.62  * 09/05/2024 RAUL ROTTA        V.62   INCLUINDO PRODUTOS 8120 E  *      */
        /*"      *                                     8511 QUE ESTAO EM RUNOFF   *      */
        /*"      *                                     PARA PODER PASSAR O PLANO  *      */
        /*"      *                                     CORRETO EM COMPRAS DE      *      */
        /*"      *                                     CORRECAO DO PASSADO        *      */
        /*"      *                                     BILHETES ATIVOS QUE NUNCA  *      */
        /*"      *                                     TIVERAM UM TITULO COMPRADO *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.61  *  VERSAO 61  - DEMANDA 489284 - PRODUTOS MEI                    *      */
        /*"      *             - ALTERACAO QTDE DE PRODUTOS POR CPF               *      */
        /*"      *                                                                *      */
        /*"      *  EM 20/02/2024 - CANETTA                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.60  *  VERSAO 60  - INCIDENTE 571891  TAREFA 571942                  *      */
        /*"      *             - NAO PERMITIR QUE SEJA SELECIONADO NO CURSOR      *      */
        /*"      *               BILHETE QUE POSSUAM DATA DE QUITACAO IGUAL       *      */
        /*"      *               '9999-12-31'                                     *      */
        /*"      *                                                                *      */
        /*"      *  EM 06/02/2024 - HUSNI ALI HUSNI                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.59  *  VERSAO 59  - DEMANDA 538869                                   *      */
        /*"      *             - ALTERA COD-FONTE PARA 5 CASO NAO ENCONTRE A FONTE*      */
        /*"      *               NA TABELA ESCRITORIO_NEGOCIO                     *      */
        /*"      *                                                                *      */
        /*"      *  EM 29/01/2024 - ELIERMES OLIVEIRA                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.58  *  VERSAO 58  - DEMANDA 564.320                                  *      */
        /*"      *             - SUBSTITUIR A CHAMADA DA ROTINA FC0105S DA CAP    *      */
        /*"      *               PELA VG0105S                                     *      */
        /*"      *                                                                *      */
        /*"      *  EM 19/01/2024 - RAUL BASILI ROTTA                             *      */
        /*"      *                                        PROCURE POR V.58        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.57  *  VERSAO 57  - DEMANDA 508682                                   *      */
        /*"      *             - BILHETES COM ERRO 834 (ACUMULO DE RISCO) PASSAM  *      */
        /*"      *               A RECEBER SITUACAO R - REJEITADO.                *      */
        /*"      *             - BILHETES COM SITUACAO 4 PASSAM A SER EMITIDOS.   *      */
        /*"      *                                                                *      */
        /*"      *  EM 10/01/2024 - FELIPE LARA                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"v.56  * VERSAO 56 ..: DEMANDA 489284 - PRODUTOS MEI                    *      */
        /*"      *               8530 - EMPREENDEDOR - MENSAL                     *      */
        /*"      *               8531 - EMPREENDEDOR - PU (12 MESES)              *      */
        /*"      *               8532 - EMPREENDEDOR - PU (36 MESES)              *      */
        /*"      *                                                                *      */
        /*"      * EM 27/12/2023 - CANETTA              PROCURE POR V.56          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.55  *   VERSAO 55 - DEMANDA 559.665                                  *      */
        /*"      *             - NAO VALIDAR A MATRICULA RECEBIDA NO MOMENTO DA   *      */
        /*"      *               VENDA.                                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/12/2023 - FRANK CARVALHO      PROCURE POR V.55         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.54  *   VERSAO 54 - DEMANDA 554.757                                  *      */
        /*"      *             - NAO CRITICAR A MATRICULA DO VENDEDOR PARA AS     *      */
        /*"      *               ORIGENS: 15 - LOTERICO E 22 - CCA.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/11/2023 - FRANK CARVALHO      PROCURE POR V.54         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.53  *   VERSAO 53 - DEMANDA 516136 - MAXIMO DE 04 BILHETES AMPARO POR*      */
        /*"      *               CPF, IDADE ENTRE 16/80 ANOS (ORIGEM 34-CX EXECUT)*      */
        /*"      *               3721 - BILHETE AMPARO                            *      */
        /*"      *                                                                *      */
        /*"      * EM 08/11/2023 - ELIERMES OLIVEIRA    PROCURE POR V.53          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.52  *   VERSAO 52 - DEMANDA 538832 - MAXIMO DE 04 BILHETES AMPARO POR*      */
        /*"      *               CPF, IDADE ENTRE 16/70 ANOS (ORIGEM 22-CX AQUI)  *      */
        /*"      *               3721 - BILHETE AMPARO - PU (12 MESES)            *      */
        /*"      *                                                                *      */
        /*"      * EM 25/10/2023 - ELIERMES OLIVEIRA    PROCURE POR V.52          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.51  *   VERSAO 51 - DEMANDA 538832 - MAXIMO DE 04 BILHETES AMPARO POR*      */
        /*"      *               CPF, IDADE ENTRE 16/70 ANOS (ORIGEM 13-LOTERICO) *      */
        /*"      *               3721 - BILHETE AMPARO - PU (12 MESES)            *      */
        /*"      *                                                                *      */
        /*"      * EM 19/10/2023 - ELIERMES OLIVEIRA    PROCURE POR V.51          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.50  *   VERSAO 50 - DEMANDA 496381 - MAXIMO DE 04 BILHETES AMPARO POR*      */
        /*"      *               CPF, IDADE ENTRE 16 E 70 ANOS (ORIGEM 15 - SISPL)*      */
        /*"      *               3721 - BILHETE AMPARO - PU (12 MESES)            *      */
        /*"      *                                                                *      */
        /*"      * EM 10/10/2023 - ELIERMES OLIVEIRA    PROCURE POR V.50          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.49  *   VERSAO 49 - DEMANDA 498670 - AUMENTO DE ACUMULO DE RISCO     *      */
        /*"      *               PARA 2MM POR CPF, NO MAXIMO DE 03 BILHETES       *      */
        /*"      *               8521 - CAIXA FACIL APOIO FAMILIA ( MENSAL )      *      */
        /*"      *               8528 - BILHETE AP BEM-ESTAR - PU (12 MESES)      *      */
        /*"      *               8529 - BILHETE AP BEM-ESTAR - PU (36 MESES)      *      */
        /*"      *                                                                *      */
        /*"      * EM 04/07/2023 - ELIERMES OLIVEIRA    PROCURE POR V.49          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.48  *  VERSAO 48  - DEMANDA 470437 - NOVO PORTAL DE VENDAS           *      */
        /*"      *             - AJUSTE DISPLAYS                                  *      */
        /*"      *                                                                *      */
        /*"      *  EM 11/04/2023 - CANETTA               PROCURE POR V.48        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.47  *  VERSAO 47  - DEMANDA 421441   TAREFA 466655                   *      */
        /*"      *             - NAO PERMITIR GRAVAR PROPOSTA NA SITUACAO 'R'     *      */
        /*"      *               TRATAMENTO DE CRITICAS DEVE SER REALIZADO PELA   *      */
        /*"      *               04.23                                            *      */
        /*"      *             - ALTERAR A PESQUISA DE PEPS DA GE_PESSOA_PEPS PARA*      */
        /*"      *               VG_PESSOA_PEPS E VG_PESSOA_PEPS_CRUZADO          *      */
        /*"      *                                                                *      */
        /*"      *  EM 27/02/2023 - HUSNI ALI HUSNI                               *      */
        /*"      *                                        PROCURE POR V.47        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.46  *  VERSAO 46  - DEMANDA 455.132                                  *      */
        /*"      *             - FAZ GRAVACAO DE CAMPOS NUM_CERTIFICADO E COD_IDLG*      */
        /*"      *               NA MOVTO_DEBITOCC_CEF                            *      */
        /*"      *                                                                *      */
        /*"      *  EM 18/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.46        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.45  *  VERSAO 45  - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA VIEW    *      */
        /*"      *               V0BILHETE_ERROS                                  *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *             - SOMAR 10000 AOS COD-ERRO UTILIZADOS NAS TABELAS  *      */
        /*"      *               DE BILHETE E VIDA AO MESMO TEMPO                 *      */
        /*"      *             - COLOCA BILHETE EM CRITICA QUANDO O MESMO ESTIVER *      */
        /*"      *               COM CRITICAS PENDENTES CADASTRADAS               *      */
        /*"      *                                                                *      */
        /*"      *  EM 14/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.45        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.44  *  VERSAO 44  - PLD Circular 612 - Fase 2 -  Demanda 379166      *      */
        /*"      *             - EXCLUIR CRITICA DE PEPS, JA QUE A MESMA FOI      *      */
        /*"      *               SUBSTITUIDA PELA AVALIACAO DE RISCO NO VA0601B   *      */
        /*"      *             - INCLUIDO ROTINA SPBVG001 PARA CONSULTA DE RISCO  *      */
        /*"      *               DA PROPOSTA. CASO EXISTA RISCO CRITICO NAO       *      */
        /*"      *               SOLUCIONADO AGUARDA CONCLUSAO DO TRATAMENTO      *      */
        /*"      *               PELO GESTOR, CASO NAO ENCONTRE RISCO CADASTRADO, *      */
        /*"      *               VERIFICA SE MOTOR GEROU CLASSIFICACAO, SE GEROU  *      */
        /*"      *               INSERE CLASSIFICACAO, SE NAO GEROU INFORMA QUE A *      */
        /*"      *               PROPOSTA SERAH EMITIDA SEM ANALISE DE RISCO      *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/10/2022 - ELIERMES OLIVEIRA   PROCURE POR V.44         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.43  *   VERSAO 43 - DEMANDA 365459 - CORRIGIR PARA CHAMAR O FC0105S  *      */
        /*"      *               2 VEZES (1- PARA DEIXAR RESERVADO 2-ATIVAR)      *      */
        /*"      *                                                                *      */
        /*"      * EM 24/08/2022 - RAUL BASILI ROTTA    PROCURE POR V.43          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.42  *   VERSAO 42 - DEMANDA 323720 - IMPLANTACAO PRODUTOS CANAL AIC  *      */
        /*"      *               8521 - CAIXA FACIL APOIO FAMILIA ( MENSAL )      *      */
        /*"      *               8528 - BILHETE AP BEM-ESTAR - PU (12 MESES)      *      */
        /*"      *               8529 - BILHETE AP BEM-ESTAR - PU (36 MESES)      *      */
        /*"      *                                                                *      */
        /*"      * EM 26/04/2022 - ELIERMES OLIVEIRA    PROCURE POR V.42          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.41  *   VERSAO 41 - CORRECAO DE ABEND  811 - Incidente 361008        *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/02/2022 - ELIERMES OLIVEIRA   PROCURE POR V.41         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.40  * VERSAO 40...: DEMANDA 317042 - CAIXA FACIL FAMILIA 3721 (PU)   *      */
        /*"      *               RECEBER VIA ATM PRODUTOS 3721                    *      */
        /*"      * RESPONSAVEL.: CANETTA                         PROCURE V.40     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.39  *   VERSAO 39 - DEMANDA 316897 - PRODUTO CAIXA FACIL             *      */
        /*"      *               CONSISTENCIA DE IDADE DE 80 ANOS PARA PRD 8144   *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/10/2021 - CANETTA             PROCURE POR V.39         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 38...: DEMANDA 306086/TAREFA 307030                     *      */
        /*"      *               CADASTRAR APOLICE CORRETOR COMO CAIXA SEGURIDADE *      */
        /*"      *               (25267) PARA PROPOSTAS COM PRODUTO XS2 E DATA DE *      */
        /*"      *               EMISSAO MAIOR IGUAL A 16/08/2021 E TIPO COMISSAO *      */
        /*"      *               = 1 (CORRETAGEM) QUE HOJE SAO TRATADOS PELO      *      */
        /*"      *               WIZ                                              *      */
        /*"      *             - CONFORME ORIENTACAO DO REINALDO NAO SERA PAGO    *      */
        /*"      *               CORRETAGEM PARA INDICADOR SE PRODUTO JV1 E DATA  *      */
        /*"      *               MAIOR IGUAL A 16/08/2021                         *      */
        /*"      * DATA .......: 12/08/2021                                       *      */
        /*"      * RESPONSAVEL.: HUSNI ALI HUSNI                                  *      */
        /*"      *                                                   PROCURE V.38 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.37  *   VERSAO 37   - JAZZ 274317                                    *      */
        /*"      *               - LIMITE DE IDADE PARA CONTRATACAO PARA OS PROD: *      */
        /*"      *                 3724 - FACIL ACIDENTES PESSOAIS MICROSSEGURO   *      */
        /*"      *                 8145 - CAIXA FACIL DESCONTO REMEDIO            *      */
        /*"      *                 8146 - CAIXA FACIL APOIO PROFISSIONAL          *      */
        /*"      *                 8147 - CAIXA FACIL SOS INFORMATICA             *      */
        /*"      *                 8148 - CAIXA FACIL VIAGEM SEGURA               *      */
        /*"      *                 8149 - CAIXA FACIL APOIO NUTRICAO              *      */
        /*"      *                 8150 - CAIXA FACIL REVISAO DO LAR              *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2021 - CANETTA            PROCURE POR V.37          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36   - HISTORIA 239409                                *      */
        /*"      *               - IDENTIFICAR CLIENTE PEP (PESSOA EXPOSTA POLITI-*      */
        /*"      *                 CAMENTE) QUANDO O SEGURO ESTIVER PRONTO PARA   *      */
        /*"      *                 A EMISSAO (TIVER PASSADO DE TODOS OS ERROS).   *      */
        /*"      *               - NAO PERMITIR EMITIR ESSES SEGUROS ATE QUE A BU *      */
        /*"      *                 AVALIE A SITUACAO DELES.                       *      */
        /*"      *               - INSERIR INFORMACAO DE PEPS NA TABELA VG_ANDAMEN-      */
        /*"      *                 TO_PROP (ESSA TABELA FOI A MAIS VIAVEL QUE EN- *      */
        /*"      *                 CONTREI NO PERIODO CURTO DE TEMPO QUE TINHAMOS)*      */
        /*"      *               - QUANDO A BU RETORNAR COM O OK, O SEGURO SERA   *      */
        /*"      *                 EMITIDO.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/11/2020 - BRICE HO                                     *      */
        /*"      *   EM 02/12/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                      PROCURE POR V.36          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.02 *   VERSAO 35   - HISTORIA 200604                                *      */
        /*"      *               - ALTERAR A APLICACAO PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1). CORRIGIR SELECT NAS TABELAS     *      */
        /*"      *                 'BILHETE_PLANCOBER' E 'BILHETE_COBERTURA'.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/05/2019 - HERVAL SOUZA       PROCURE POR JV.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 34   - HISTORIA 196716                                *      */
        /*"      *               - ALTERAR A APLICACAO PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1) E SEUS PRODUTOS.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/04/2019 - LUIZ FERNANDO      PROCURE POR V.34          *      */
        /*"      *                                                                *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 33 - HISTORIA 178780                                  *      */
        /*"      *             - MUDANCAS DE PRODUTOS ACOPLADOS - CAP             *      */
        /*"      *               PARA ATENDER A CIRCULAR SUSEP 569/576            *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - RIBAMAR MARQUES (ALTRAN)                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.33         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERADO EM 16/07/2017  - FRANK CARVALHO(INDRA)        V.32  *      */
        /*"      *   OBJETIVO: CADMUS 152120 - IMPLANTAR PRODUTOS NO CANAL ATM    *      */
        /*"      *                      8144 - CAIXA FACIL APOIO FAMILIA          *      */
        /*"      *                      8145 - CAIXA FACIL DESCONTO REMEDIO       *      */
        /*"      *                      8146 - CAIXA FACIL APOIO PROFISSIONAL     *      */
        /*"      *                      8147 - CAIXA FACIL SOS INFORMATICA        *      */
        /*"      *                      8148 - CAIXA FACIL VIAGEM SEGURA          *      */
        /*"      *                      8149 - CAIXA FACIL APOIO NUTRICAO         *      */
        /*"      *                      8150 - CAIXA FACIL REVISAO DO LAR         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 25/07/2016 - FRANK CARVALHO(INDRA)         V.31  *      */
        /*"      *   OBJETIVO: REVERTER ALTERACOES PARA O NOVO PRODUTO 3706.      *      */
        /*"      *             VERSOES V.29 E V.30.                                      */
        /*"      *                                                                *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 19/07/2016 - FRANK CARVALHO(INDRA)         V.30  *      */
        /*"      *   OBJETIVO: ABEND 139992 - ENVIAR NUM_PLANO 818 PARA O PRODUTO *      */
        /*"      *   3706 CONFORME CADASTRADO NAS TABELAS DA CAP.                 *      */
        /*"      *                                                                *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *   MOTIVO: ATENDE CADMUS 123932                                 *      */
        /*"      *           IMPLANTACAO DE PRODUTOS ATM:                         *      */
        /*"      *           8144, 8145, 8146, 8147, 8148, 8149, 8150, 3706       *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE V.29          RIBAMAR MARQUES   12/07/2016           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 03/11/2015 - CLAUDETE RADEL(MILLENIUM)     V.28  *      */
        /*"      *   OBJETIVO: CADMUS 123562 - RETIRAR A VALIDACAO DE IDADE MAIOR *      */
        /*"      *   DE 70 ANOS PARA O PRODUTO 3709.                              *      */
        /*"      *                                                                *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 30/01/2015 - FRANK CARVALHO(INDRA COMPANY) V.27  *      */
        /*"      *   OBJETIVO: CADMUS 106787 - ALTERAR REGRAS DE FAIXA ETARIA E   *      */
        /*"      *   LIMITE DE RISCO PARA DETERMINADOS PRODUTOS.                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 17/11/2014    RIBAMAR MARQUES              V.26  *      */
        /*"      *   OBJETIVO: CADMUS 104952 - MIGRACAO DOS PRODUTOS 8112 E 8113  *      */
        /*"      *   PARA MICROSSEGURO 3709.                                      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 23/06/2014    RICARDO PORTELA              V.25  *      */
        /*"      *                             COMPRAR NUMERO DE SORTEIOS PARA    *      */
        /*"      *   OS PRODUTOS REDE QUE COMPRAM NA ADESAO                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 30/04/2014    CLOVIS                       V.24  *      */
        /*"      *                             PREMIO EMITIDO DE FORMA INCORRETA  *      */
        /*"      *   BUSCA PREMIO TOTAL NA  SEGUROS.V0BILHETE_COBER               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 25/04/2014    CLOVIS                       V.23  *      */
        /*"      *                             CADMUS 97186 - IOF ZERO            *      */
        /*"      *   PESQUISA IOF NA TABELA SEGUROS.RAMO_COMPLEMENTAR             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 08/10/2012    CLOVIS                       V.22  *      */
        /*"      *                             ALTERACAO REGRA COMISSIONAMENTO    *      */
        /*"      *                             EVOGEPES 016-2012 DIRVI/SUCOM      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 - CAD 95.972                                       *      */
        /*"      *                                                                *      */
        /*"      *           ATENDIMENTO DA CIRC-SUSEP 360                        *      */
        /*"      *           DATA DA PROPOSTA NAO PODE SER MAIOR QUE A DATA       *      */
        /*"      *           DE INICIO DE VIGENCIA NA TABELA DE ENDOSSOS          *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/04/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CAD 74.701                                       *      */
        /*"      *                                                                *      */
        /*"      *           CORRECAO DO ABEND SQLCODE = -811                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/09/2012 - FAST COMPUTER - AUGUSTO ANASTACIO            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - CAD 64.999                                       *      */
        /*"      *                                                                *      */
        /*"      *           ADAPTAR OS PROGRAMAS DE VIDA PARA UTILIZAREM A NOVA  *      */
        /*"      *           ROTINA DE COMPRA DA CAP QUE SOFREU ALTERACAO,        *      */
        /*"      *           MODIFICANDO A CHAMADA DA ROTINA FC0105B PARA FC0105S.*      */
        /*"      *                                                                *      */
        /*"      *   EM 22/12/2011 - FAST COMPUTER - ROGERIO PEREIRA              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 - PROJETO AIC                                      *      */
        /*"      *                                                                *      */
        /*"      *               - COMPRA TITULO DE CAPITALIZACAO P/ BILHETE AP   *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/10/2011 - GESINC        - MARCUS ANDRE DIAS            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 - CAD 201.084                                      *      */
        /*"      *                                                                *      */
        /*"      *               - ALTERA O PLANO DE CAPITALIZACAO DE 810 PARA    *      */
        /*"      *                 818.                                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/07/2011 - FAST COMPUTER - BRUNO RIBEIRO                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - CAD 41.225                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INSERE O TITULO NA TABELA TITULOS_FED_CAP_VA   *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/04/2010 - FAST COMPUTER - MARCO PAIVA                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.17         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - CAD 39.036                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PROCESSA OS BILHETES CANAL ATM                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/03/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.16         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - CAD 33.871                                       *      */
        /*"      *                                                                *      */
        /*"      *               - REALIZA TRACE DINAMICO NA CHAMADA A FC0105B    *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/12/2009 - GEFAB - BARD                                 *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.15         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - CAD 33.936                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE NO CALCULO PARA BILHETE AP(8104).       *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/12/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 13 - 04/12/2009 - CAD33826 - DESLIGA TRACE NA CHAMADA A *      */
        /*"      *                          SUBROTINA FC0105B                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD 33617                                        *      */
        /*"      *                                                                *      */
        /*"      *               - LIGA O PARAMETRO TRACE ON NA CHAMADA A         *      */
        /*"      *                 SUBROTINA FC0105B                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/12/2009 - GEFAB - BARDUCCO                             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 32.918                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUI A GRAVACAO DE ERRO PARA AGENCIA         *      */
        /*"      *                 DE COBRANCA INVALIDA.                          *      */
        /*"      *                                                                *      */
        /*"      *               - PARAMETRIZACAO DO CALCULO DE COMISSAO          *      */
        /*"      *                 PARA O BILHETE AP (8104) - CAD 32.919          *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/11/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 31.934                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUSAO DO CAMPO LK-NUM-NSA NOS PARAMETROS DA *      */
        /*"      *                 CHAMADA DA ROTINA FC0105B.                     *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/09/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  009 - 07/07/2009 - ANDERSON DE OLIVEIRA (FAST COMPUTER)       *      */
        /*"      *  CAD 26.662                                                    *      */
        /*"      *               RETIRAR A CRITICA DE BILHETE FORA DE FAIXA.      *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.09    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  008 - 21/03/2009 - FAST COMPUTER                              *      */
        /*"      *  CAD 21.756                                                    *      */
        /*"      *               MUDANCA NOS PRODUTOS ACOPLADOS COM CAPITALIZACAO *      */
        /*"      *               PARA ATENDER A CIRCULAR SUSEP                    *      */
        /*"      *               CIRCULAR 365 DE 27 DE MAIO DE 2008               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.08    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  007 - 13/08/2008 - WANGER C SILVA (FAST COMPUTER)             *      */
        /*"      *  SSI CAD 12997                                                 *      */
        /*"      *      NOVO BILHETE AP COM CAPITALZACAO - PROD 8104              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  006 - 27/05/2008 - MARCO PAIVA (FAST COMPUTER)                *      */
        /*"      *  SSI CAD 10745                                                 *      */
        /*"      *                  CARREGA HOST DO PRODUTO DA TABELA             *      */
        /*"      *                  SEGUROS.V0BILHETE_PLCOBER  PARA CRITICAR O    *      */
        /*"      *                  LIMITE DE RISCO PARA O PRODUTO 8103           *      */
        /*"      *                                            PROCURE POR V.06    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  005 - 02/04/2008 - WANGER ( FAST COMPUTER )                   *      */
        /*"      *  SSI 19915/2007 E CAD 8560                                     *      */
        /*"      *                  ACEITAR VALOR DE ACUMULO DE RISCO PARA O      *      */
        /*"      *                  PRODUTO 8103                                  *      */
        /*"      *                                            PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  004 - 20/02/2008 - MARCO PAIVA (FAST COMPUTER)                *      */
        /*"      *                                                                *      */
        /*"      *  SSI 20573/2008- ALTERA SITUACAO DOS BILHETE 95344918145,      *      */
        /*"      *                84639305564,8259336748,8259357844,8259357843    *      */
        /*"      *                                                                *      */
        /*"      *  SSI 19779/2008- ALTERA SITUACAO DOS BILHETE 84637764910       *      */
        /*"      *                                                                *      */
        /*"      *  SSI 19783/2008- ALTERA SITUACAO DOS BILHETE 84638955530       *      */
        /*"      *                                                                *      */
        /*"      *  SSI 19367/2007- ALTERA SITUACAO DOS BILHETE 95335000718,      *      */
        /*"      *                                              95335000726       *      */
        /*"      *                                                                *      */
        /*"      *  SSI 18418/2007- ALTERA SITUACAO DOS BILHETE 84637255780       *      */
        /*"      *                                                                *      */
        /*"      *  SSI 18087/2007- ALTERA SITUACAO DOS BILHETES 84553030079,     *      */
        /*"      *                                               84571676635      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 16172/2007- ALTERA SITUACAO DOS BILHETES 84633012883,     *      */
        /*"      *                                84635706912,84625550006         *      */
        /*"      *                                                                *      */
        /*"      *  SSI 16044/2007- ALTERA SITUACAO DO  BILHETE  84627012397      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 17713/2007- ALTERA SITUACAO DO  BILHETE  84611840295      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 17708/2007- ALTERA SITUACAO DO  BILHETE  8259298302       *      */
        /*"      *                                                                *      */
        /*"      *  SSI 15736/2007- ALTERA SITUACAO DOS BILHETES 84626712620      *      */
        /*"      *                                                                *      */
        /*"      *  SSI-17113  (24/07/2007) - ALTERA SITUACAO DOS BILHETES        *      */
        /*"      *                                  84626958360, 84627259848,     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  003 - 24/04/2007 - MARCO PAIVA (FAST COMPUTER)                *      */
        /*"      *  SSI 15008/2007- ALTERA SITUACAO DOS BILHETES 84626006091      *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 02/04/2007 - FAST COMPUTER                              *      */
        /*"      *  SSI 14626/2007- ACEITAR RCAP COM DIFERENCA DE (+/-) R$ 10,00. *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 09/03/2007 - LUCIA VIEIRA                               *      */
        /*"      *  SSI 13465/2007- ALTERA SITUACAO DOS  BILHETES 84625537808     *      */
        /*"      *                                                84622520254     *      */
        /*"      *  SSI 13465/2007- ALTERA SITUACAO DOS  BILHETES 84570893497     *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ESTA VERSAO DO DIA 16SET2002- A PROMOCAO DESTA VERSAO SE DEU   *      */
        /*"      * EM 26AGO2002 PELO MESSIAS.                                     *      */
        /*"      * VERSAO RETORNADA POR VIRGINIA EM 27SET2002                     *      */
        /*"      * ALTERACAO DE 27SET2002 - PROCURAR VIRG                         *      */
        /*"      * NO DECLARE DA V0BILHETE FOI ACRESCIDO O NUM_APOL_ANTERIOR      *      */
        /*"      * IGUAL A ZERO (NAO IRA PEGAR RENOVACAO)                         *      */
        /*"      *                                              VIRGINIA- SET/02  *      */
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
        /*"      *   EM 27/09/2002                                                *      */
        /*"      *   PASSAR A CHECAR O LIMITE DE RISCO DO BILHETE AP (RAMO 82) POR*      */
        /*"      *   SEGURADO (CPF).                                              *      */
        /*"      *                         PROCURE POR MM2709                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 11/02/2003                                                *      */
        /*"      *   PASSAR A CRITICAR LIMITE DE IDADE.                           *      */
        /*"      *                                                                *      */
        /*"      *                         PROCURE POR TL0302                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 30/12/2003                                                *      */
        /*"      *   A LEITURA NA TABELA V0PROP_ESTIPULANTE ESTAVA MELANDO OS     *      */
        /*"      *   BILHETES, POIS, GRAVAVA COM O CODIGO DE PRODUTO 8299 O QUE   *      */
        /*"      *   EH UM CODIGO INVALIDO PARA O BILHETE.                        *      */
        /*"      *                                                                *      */
        /*"      *                         PROCURE POR MM1203                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 01/03/2004                                                *      */
        /*"      *   ALTERA COMISSAO FENAE PARA R$2,02 (FIXO).                    *      */
        /*"      *   CORRETOR 17256 PARA DOCUMENTOS COM QUITACAO                  *      */
        /*"      *                  A PARTIR DE 01/12/2003.                       *      */
        /*"      *                         PROCURE POR CL0304                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 13/04/2006 - TERCIO CARVALHO                              *      */
        /*"      *   SSI 8426/2006 - LIBERADA A CRITICA DE PROFISSAO              *      */
        /*"      *                         PROCURE POR FC0406                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 15/05/2006 - TERCIO CARVALHO                              *      */
        /*"      *                   INCLUIDO ERRO 202 EM FUNCAO DE ABEND         *      */
        /*"      *                         PROCURE POR FC0506                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
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
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-COD-PRODUTO          PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-PDT-LID-ANT            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis WS_PDT_LID_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WI                        PIC S9(003)     COMP VALUE +0.*/
        public IntBasis WI { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"77    IND-COB                   PIC S9(003)     COMP VALUE +0.*/
        public IntBasis IND_COB { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"77    WS-ANO-BASE               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis WS_ANO_BASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-ANO-NASC               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis WS_ANO_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-IDADE                  PIC S9(003)     COMP VALUE +0.*/
        public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"77    WS-DAT-LID-ANT            PIC  X(010)     VALUE SPACES.*/
        public StringBasis WS_DAT_LID_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77    WS-TER-VIG-HCP            PIC  X(010)     VALUE SPACES.*/
        public StringBasis WS_TER_VIG_HCP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77    WS-PGM-CALL               PIC  X(008)     VALUE SPACES.*/
        public StringBasis WS_PGM_CALL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77    WS-CPO-VLR-AUX            PIC S9(013)V99  VALUE +0 COMP-3.*/
        public DoubleBasis WS_CPO_VLR_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WS-CPO-SEQ-AUX            PIC S9(004)     VALUE +0 COMP-3.*/
        public IntBasis WS_CPO_SEQ_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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

        /*"77           N88-NOVOS-ACESSOS  PIC  X(001)    VALUE  '&'.*/

        public SelectorBasis N88_NOVOS_ACESSOS { get; set; } = new SelectorBasis("001", "&")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88         NOVOS-ACESSOS                     VALUE  'S'. */
							new SelectorItemBasis("NOVOS_ACESSOS", "S")
                }
        };

        /*"77           N88-VAI-LEITURA    PIC  X(001)    VALUE  '&'.*/

        public SelectorBasis N88_VAI_LEITURA { get; set; } = new SelectorBasis("001", "&")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88         VAI-LEITURA                       VALUE  'S'. */
							new SelectorItemBasis("VAI_LEITURA", "S")
                }
        };

        /*"77         W77-ERRO            PIC  X(001)      VALUE ' '.*/
        public StringBasis W77_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
        /*"77         WHOST-NRRCAP        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-COUNT         PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-SIT-PROP-SIVPF PIC X(003).*/
        public StringBasis WHOST_SIT_PROP_SIVPF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         WHOST-NUMOPG        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUMREC        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUMBIL        PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis WHOST_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WHOST-DTINIVIG      PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         WHOST-DTTERVIG      PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         BILACAT-NUMBIL      PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis BILACAT_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WWORK-RAMO-ANT      PIC S9(004)                COMP.*/
        public IntBasis WWORK_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WWORK-OPCAO-ANT     PIC S9(004)                COMP.*/
        public IntBasis WWORK_OPCAO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WIND                PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WWORK-MIN-DTINIVIG  PIC X(010).*/
        public StringBasis WWORK_MIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WWORK-MAX-DTTERVIG  PIC X(010).*/
        public StringBasis WWORK_MAX_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WS-INI-SEG-COMI     PIC X(010).*/
        public StringBasis WS_INI_SEG_COMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WS-TER-SEG-COMI     PIC X(010).*/
        public StringBasis WS_TER_SEG_COMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77         VIND-PRMTOTAL       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PRMTOTAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ACUM-RISCO     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_ACUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CARTAO-CREDITO PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DIADEBITO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DIADEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-AGENCIA        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OPERACAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUMCONTA       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUMCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DIGCONTA       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DIGCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTENVIO        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTRETORNO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODRETORNO     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-USUARIO        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-REQUISICAO     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SEQUENCIA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUM-LOTE       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTCREDITO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-STATUS         PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLCREDITO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VLCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NRCERTIF       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WSGER12-DATA-TERVIGENCIA  PIC  X(010)   VALUE SPACES.*/
        public StringBasis WSGER12_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   WSGER36-DATA-TERVIGENCIA  PIC  X(010)   VALUE SPACES.*/
        public StringBasis WSGER36_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   WSGER60-DATA-TERVIGENCIA  PIC  X(010)   VALUE SPACES.*/
        public StringBasis WSGER60_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVACB     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVACB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1SIST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77    CBO-COD-CBO               PIC S9(004)    COMP.*/
        public IntBasis CBO_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    CBO-DESCR-CBO             PIC  X(050).*/
        public StringBasis CBO_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"77    PESSOA-FISICA-COD-CBO     PIC S9(004)    COMP.*/
        public IntBasis PESSOA_FISICA_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-COD-PESSOA       PIC S9(009)    COMP.*/
        public IntBasis PRPFIDEL_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    PRPFIDEL-COD-PROD-SIVPF   PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_COD_PROD_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-ORIG-PROPOSTA    PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_ORIG_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-DIA-DEBITO       PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V0BILH-OPCOBER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_OPCOBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-NOME         PIC  X(040).*/
        public StringBasis V0BILH_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0BILH-CGCCPF       PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0BILH-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-NUMCTA-DEB   PIC S9(013)      VALUE +0 COMP.*/
        public IntBasis V0BILH_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0BILH-DIGCTA-DEB   PIC S9(005)      VALUE +0 COMP.*/
        public IntBasis V0BILH_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"77         V0BILH-OPCAO-COBER  PIC S9(005)               COMP.*/
        public IntBasis V0BILH_OPCAO_COBER { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"77         V0BILH-DTQITBCO     PIC  X(010).*/
        public StringBasis V0BILH_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BILH-DTVENDA      PIC  X(010).*/
        public StringBasis V0BILH_DTVENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BILH-DTVENCTO     PIC  X(010).*/
        public StringBasis V0BILH_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77         V0BILH-COD-PRODUTO  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V1COFE-NUMCTA       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1COFE_NUMCTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COFE-DIGCTA       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_DIGCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COFE_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COFE-NUMCTA-DEB   PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1COFE_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
        /*"77         V0COFE-NUMCTA       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0COFE_NUMCTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COFE-DIGCTA       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_DIGCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COFE_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COFE-NUMCTA-DEB   PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0COFE_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
        /*"77         V0APOL-NUMBIL       PIC S9(015)   VALUE +0 COMP-3.*/
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
        /*"77         V0CLIE-CGCCPF        PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis V0CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CLIE-DTNASC        PIC  X(010).*/
        public StringBasis V0CLIE_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         VIND-DTNASC          PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         GELMR-QTD-SEGUROS    PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis GELMR_QTD_SEGUROS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         GELMR-VLR-SOMA-IS    PIC S9(013)V99  VALUE +0 COMP-3.*/
        public DoubleBasis GELMR_VLR_SOMA_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WS-COD-PRODUTO       PIC S9(004)  COMP-5  VALUE 0.*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         WS-IND-CORRETOR      PIC  9(001)     VALUE 0.*/
        public IntBasis WS_IND_CORRETOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01         WS-COD-CORRETOR      PIC  9(009)     VALUE 0.*/

        public SelectorBasis WS_COD_CORRETOR { get; set; } = new SelectorBasis("009", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88       N88-COD-CORRETOR    VALUES  2496,  2933,  6327,  7005,                                      9440, 17256, 17604, 17752,                                     18040, 19224, 23914, 23922,                                     23931, 23949, 23957, 24112,                                     24121, 24163, 24236, 24287,                                     24295, 24309, 24317, 24333,                                     24341, 24368, 24384, 24392,                                     24431, 24449, 24457, 24481,                                     24716, 24937, 24945, 24970,                                     24996, 25003, 101150. */
							new SelectorItemBasis("N88_COD_CORRETOR", "2496,2933,6327,7005,9440,17256,17604,17752,18040,19224,23914,23922,23931,23949,23957,24112,24121,24163,24236,24287,24295,24309,24317,24333,24341,24368,24384,24392,24431,24449,24457,24481,24716,24937,24945,24970,24996,25003,101150")
                }
        };

        /*"01     WS-QTD-CAP-EMITIDO     PIC 9(005) VALUE 0.*/
        public IntBasis WS_QTD_CAP_EMITIDO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01     WS-QT-RISCO-CRITICO    PIC 9(005) VALUE 0.*/
        public IntBasis WS_QT_RISCO_CRITICO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01     WS-QT-RISCO-PEPS       PIC 9(005) VALUE 0.*/
        public IntBasis WS_QT_RISCO_PEPS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
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
        /*"01     WS-COD-CRITICA         PIC 9(005) VALUE 0.*/
        public IntBasis WS_COD_CRITICA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01     WS-ERRO-COUNT          PIC S9(04) VALUE +0 COMP.*/
        public IntBasis WS_ERRO_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01     WS-PROGRAMA            PIC X(008) VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-I-ERRO                   PIC  9(003) VALUE ZEROS.*/
        public IntBasis WS_I_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-FLAG-TEM-ERRO            PIC  X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WORK-TAB-ERROS-CERT.*/
        public CB0005B_WORK_TAB_ERROS_CERT WORK_TAB_ERROS_CERT { get; set; } = new CB0005B_WORK_TAB_ERROS_CERT();
        public class CB0005B_WORK_TAB_ERROS_CERT : VarBasis
        {
            /*"    05  WS-TAB-ERROS-CERT   OCCURS 100 TIMES.*/
            public ListBasis<CB0005B_WS_TAB_ERROS_CERT> WS_TAB_ERROS_CERT { get; set; } = new ListBasis<CB0005B_WS_TAB_ERROS_CERT>(100);
            public class CB0005B_WS_TAB_ERROS_CERT : VarBasis
            {
                /*"      10  TB-ERRO-CERT          PIC S9(004) COMP.*/
                public IntBasis TB_ERRO_CERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"01  WORK-JV1.*/
            }
        }
        public CB0005B_WORK_JV1 WORK_JV1 { get; set; } = new CB0005B_WORK_JV1();
        public class CB0005B_WORK_JV1 : VarBasis
        {
            /*" 05 WS-JV1-PROGRAMA                  PIC  X(008)    VALUE SPACES*/
            public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*" 05 WH-JV1-COD-ORGAO                 PIC S9(004) COMP-5 VALUE +0*/
            public IntBasis WH_JV1_COD_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 05 WS-JV1-ACHEI-PRODUTO             PIC  X(003)    VALUE  'SIM'*/
            public StringBasis WS_JV1_ACHEI_PRODUTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
            /*"01  TAB-CBO1.*/
        }
        public CB0005B_TAB_CBO1 TAB_CBO1 { get; set; } = new CB0005B_TAB_CBO1();
        public class CB0005B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public CB0005B_TAB_CBO TAB_CBO { get; set; } = new CB0005B_TAB_CBO();
            public class CB0005B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<CB0005B_FILLER_2> FILLER_2 { get; set; } = new ListBasis<CB0005B_FILLER_2>(999);
                public class CB0005B_FILLER_2 : VarBasis
                {
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"01           WS-TIME.*/
                }
            }
        }
        public CB0005B_WS_TIME WS_TIME { get; set; } = new CB0005B_WS_TIME();
        public class CB0005B_WS_TIME : VarBasis
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
        private _REDEF_CB0005B_WS000_HORA_TIME_REDF _ws000_hora_time_redf { get; set; }
        public _REDEF_CB0005B_WS000_HORA_TIME_REDF WS000_HORA_TIME_REDF
        {
            get { _ws000_hora_time_redf = new _REDEF_CB0005B_WS000_HORA_TIME_REDF(); _.Move(WS000_HORA_TIME, _ws000_hora_time_redf); VarBasis.RedefinePassValue(WS000_HORA_TIME, _ws000_hora_time_redf, WS000_HORA_TIME); _ws000_hora_time_redf.ValueChanged += () => { _.Move(_ws000_hora_time_redf, WS000_HORA_TIME); }; return _ws000_hora_time_redf; }
            set { VarBasis.RedefinePassValue(value, _ws000_hora_time_redf, WS000_HORA_TIME); }
        }  //Redefines
        public class _REDEF_CB0005B_WS000_HORA_TIME_REDF : VarBasis
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

            public _REDEF_CB0005B_WS000_HORA_TIME_REDF()
            {
                WS000_HT.ValueChanged += OnValueChanged;
                WS000_P1.ValueChanged += OnValueChanged;
                WS000_MT.ValueChanged += OnValueChanged;
                WS000_P2.ValueChanged += OnValueChanged;
                WS000_ST.ValueChanged += OnValueChanged;
            }

        }
        public CB0005B_WS000_PARM_PROSOMD1 WS000_PARM_PROSOMD1 { get; set; } = new CB0005B_WS000_PARM_PROSOMD1();
        public class CB0005B_WS000_PARM_PROSOMD1 : VarBasis
        {
            /*"  05         WS000-DATA01       PIC  9(008).*/
            public IntBasis WS000_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         WS000-QTDIAS       PIC S9(005) COMP-3.*/
            public IntBasis WS000_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WS000-DATA02       PIC  9(008).*/
            public IntBasis WS000_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01         WS002-ACUMULADORES.*/
        }
        public CB0005B_WS002_ACUMULADORES WS002_ACUMULADORES { get; set; } = new CB0005B_WS002_ACUMULADORES();
        public class CB0005B_WS002_ACUMULADORES : VarBasis
        {
            /*"  05       WS002-VAL-COB-IX  PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_VAL_COB_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       WS002-TOT-IMP-SEG PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis WS002_TOT_IMP_SEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
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
        public CB0005B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB0005B_AREA_DE_WORK();
        public class CB0005B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WS-SIT-PRODUTO   PIC  9(001)  VALUE 0.*/

            public SelectorBasis WS_SIT_PRODUTO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       WS-PROD-RUNON                 VALUE 1. */
							new SelectorItemBasis("WS_PROD_RUNON", "1"),
							/*" 88       WS-PROD-RUNOFF                VALUE 2. */
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
            /*"  05         WACC-LIDOS-RD REDEFINES WACC-LIDOS.*/
            private _REDEF_CB0005B_WACC_LIDOS_RD _wacc_lidos_rd { get; set; }
            public _REDEF_CB0005B_WACC_LIDOS_RD WACC_LIDOS_RD
            {
                get { _wacc_lidos_rd = new _REDEF_CB0005B_WACC_LIDOS_RD(); _.Move(WACC_LIDOS, _wacc_lidos_rd); VarBasis.RedefinePassValue(WACC_LIDOS, _wacc_lidos_rd, WACC_LIDOS); _wacc_lidos_rd.ValueChanged += () => { _.Move(_wacc_lidos_rd, WACC_LIDOS); }; return _wacc_lidos_rd; }
                set { VarBasis.RedefinePassValue(value, _wacc_lidos_rd, WACC_LIDOS); }
            }  //Redefines
            public class _REDEF_CB0005B_WACC_LIDOS_RD : VarBasis
            {
                /*"      07     WACC-LIDOS-A      PIC  9(003).*/
                public IntBasis WACC_LIDOS_A { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      07     WACC-LIDOS-B      PIC  9(003).*/
                public IntBasis WACC_LIDOS_B { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  05         WACC-DISPLAY      PIC  9(006)       VALUE  ZEROS.*/

                public _REDEF_CB0005B_WACC_LIDOS_RD()
                {
                    WACC_LIDOS_A.ValueChanged += OnValueChanged;
                    WACC_LIDOS_B.ValueChanged += OnValueChanged;
                }

            }
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
            /*"  05         WS-BILFOFA        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_BILFOFA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WWORK-FUNDAO      PIC  X(001)    VALUE SPACE.*/
            public StringBasis WWORK_FUNDAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WPROC-BILHETES    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WPROC_BILHETES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WTEM-PROPESTIP    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_PROPESTIP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-GELMR        PIC  X(003)    VALUE SPACES.*/
            public StringBasis WTEM_GELMR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WWORK-NUM-APOL    PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-APOL.*/
            private _REDEF_CB0005B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_CB0005B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_CB0005B_FILLER_3(); _.Move(WWORK_NUM_APOL, _filler_3); VarBasis.RedefinePassValue(WWORK_NUM_APOL, _filler_3, WWORK_NUM_APOL); _filler_3.ValueChanged += () => { _.Move(_filler_3, WWORK_NUM_APOL); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WWORK_NUM_APOL); }
            }  //Redefines
            public class _REDEF_CB0005B_FILLER_3 : VarBasis
            {
                /*"    10       WWORK-ORG-APOL    PIC  9(003).*/
                public IntBasis WWORK_ORG_APOL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-RMO-APOL    PIC  9(002).*/
                public IntBasis WWORK_RMO_APOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-SEQ-APOL    PIC  9(008).*/
                public IntBasis WWORK_SEQ_APOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WWORK-PCPARCOR-I  PIC S9(003)V99   COMP-3.*/

                public _REDEF_CB0005B_FILLER_3()
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
            /*"  05         WWORK-NRENDOS     PIC S9(009)    VALUE +0 COMP.*/
            public IntBasis WWORK_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WWORK-NUM-ORDEM   PIC  9(014)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_ORDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-ORDEM.*/
            private _REDEF_CB0005B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_CB0005B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_CB0005B_FILLER_4(); _.Move(WWORK_NUM_ORDEM, _filler_4); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_4, WWORK_NUM_ORDEM); _filler_4.ValueChanged += () => { _.Move(_filler_4, WWORK_NUM_ORDEM); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_CB0005B_FILLER_4 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-NUMBIL      PIC  9(015)    VALUE ZEROS.*/

                public _REDEF_CB0005B_FILLER_4()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUMBIL.*/
            private _REDEF_CB0005B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_CB0005B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_CB0005B_FILLER_5(); _.Move(WWORK_NUMBIL, _filler_5); VarBasis.RedefinePassValue(WWORK_NUMBIL, _filler_5, WWORK_NUMBIL); _filler_5.ValueChanged += () => { _.Move(_filler_5, WWORK_NUMBIL); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WWORK_NUMBIL); }
            }  //Redefines
            public class _REDEF_CB0005B_FILLER_5 : VarBasis
            {
                /*"    10       FILLER            PIC  9(004).*/
                public IntBasis FILLER_6 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-NRRCAP      PIC  9(009).*/
                public IntBasis WWORK_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       FILLER            PIC  9(002).*/
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WWORK-NR-PROPOSTA PIC  9(014)    VALUE ZEROS.*/

                public _REDEF_CB0005B_FILLER_5()
                {
                    FILLER_6.ValueChanged += OnValueChanged;
                    WWORK_NRRCAP.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NR_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NR-PROPOSTA.*/
            private _REDEF_CB0005B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_CB0005B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_CB0005B_FILLER_8(); _.Move(WWORK_NR_PROPOSTA, _filler_8); VarBasis.RedefinePassValue(WWORK_NR_PROPOSTA, _filler_8, WWORK_NR_PROPOSTA); _filler_8.ValueChanged += () => { _.Move(_filler_8, WWORK_NR_PROPOSTA); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WWORK_NR_PROPOSTA); }
            }  //Redefines
            public class _REDEF_CB0005B_FILLER_8 : VarBasis
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

                public _REDEF_CB0005B_FILLER_8()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                }

            }
            public CB0005B_WWORK_DATA WWORK_DATA { get; set; } = new CB0005B_WWORK_DATA();
            public class CB0005B_WWORK_DATA : VarBasis
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
                /*"  05         WWORK-IDADE       PIC  9(004).*/
            }
            public IntBasis WWORK_IDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WWORK-ANO-BI      PIC  9(009)    COMP-3.*/
            public IntBasis WWORK_ANO_BI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB0005B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_CB0005B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_CB0005B_FILLER_12(); _.Move(WDATA_REL, _filler_12); VarBasis.RedefinePassValue(WDATA_REL, _filler_12, WDATA_REL); _filler_12.ValueChanged += () => { _.Move(_filler_12, WDATA_REL); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB0005B_FILLER_12 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SISTEMA.*/

                public _REDEF_CB0005B_FILLER_12()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0005B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new CB0005B_WDATA_SISTEMA();
            public class CB0005B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  X(004).*/
                public StringBasis WDATA_SIS_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  X(002).*/
                public StringBasis WDATA_SIS_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  X(002).*/
                public StringBasis WDATA_SIS_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WWORK-DATAINI     PIC  9(008)  VALUE ZEROS.*/
            }
            public IntBasis WWORK_DATAINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATAINI.*/
            private _REDEF_CB0005B_FILLER_17 _filler_17 { get; set; }
            public _REDEF_CB0005B_FILLER_17 FILLER_17
            {
                get { _filler_17 = new _REDEF_CB0005B_FILLER_17(); _.Move(WWORK_DATAINI, _filler_17); VarBasis.RedefinePassValue(WWORK_DATAINI, _filler_17, WWORK_DATAINI); _filler_17.ValueChanged += () => { _.Move(_filler_17, WWORK_DATAINI); }; return _filler_17; }
                set { VarBasis.RedefinePassValue(value, _filler_17, WWORK_DATAINI); }
            }  //Redefines
            public class _REDEF_CB0005B_FILLER_17 : VarBasis
            {
                /*"    10       WWORK-DIAINI      PIC  9(002).*/
                public IntBasis WWORK_DIAINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESINI      PIC  9(002).*/
                public IntBasis WWORK_MESINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOINI      PIC  9(004).*/
                public IntBasis WWORK_ANOINI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-DATATER     PIC  9(008)  VALUE ZEROS.*/

                public _REDEF_CB0005B_FILLER_17()
                {
                    WWORK_DIAINI.ValueChanged += OnValueChanged;
                    WWORK_MESINI.ValueChanged += OnValueChanged;
                    WWORK_ANOINI.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_DATATER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATATER.*/
            private _REDEF_CB0005B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_CB0005B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_CB0005B_FILLER_18(); _.Move(WWORK_DATATER, _filler_18); VarBasis.RedefinePassValue(WWORK_DATATER, _filler_18, WWORK_DATATER); _filler_18.ValueChanged += () => { _.Move(_filler_18, WWORK_DATATER); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, WWORK_DATATER); }
            }  //Redefines
            public class _REDEF_CB0005B_FILLER_18 : VarBasis
            {
                /*"    10       WWORK-DIATER      PIC  9(002).*/
                public IntBasis WWORK_DIATER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESTER      PIC  9(002).*/
                public IntBasis WWORK_MESTER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOTER      PIC  9(004).*/
                public IntBasis WWORK_ANOTER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-QTCOSSEG    PIC  9(002)  VALUE ZEROS.*/

                public _REDEF_CB0005B_FILLER_18()
                {
                    WWORK_DIATER.ValueChanged += OnValueChanged;
                    WWORK_MESTER.ValueChanged += OnValueChanged;
                    WWORK_ANOTER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_QTCOSSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WDATA-CURR.*/
            public CB0005B_WDATA_CURR WDATA_CURR { get; set; } = new CB0005B_WDATA_CURR();
            public class CB0005B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public CB0005B_WDATA_CABEC WDATA_CABEC { get; set; } = new CB0005B_WDATA_CABEC();
            public class CB0005B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-CODANGAR-R.*/
            }
            public CB0005B_WS_CODANGAR_R WS_CODANGAR_R { get; set; } = new CB0005B_WS_CODANGAR_R();
            public class CB0005B_WS_CODANGAR_R : VarBasis
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
            public CB0005B_PROM11W099 PROM11W099 { get; set; } = new CB0005B_PROM11W099();
            public class CB0005B_PROM11W099 : VarBasis
            {
                /*"    10       PROM11W099-NUMERO   PIC  9(015).*/
                public IntBasis PROM11W099_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       PROM11W099-TAM      PIC S9(004)   COMP.*/
                public IntBasis PROM11W099_TAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       PROM11W099-DAC      PIC  X(001).*/
                public StringBasis PROM11W099_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         WS-NUMREC-R.*/
            }
            public CB0005B_WS_NUMREC_R WS_NUMREC_R { get; set; } = new CB0005B_WS_NUMREC_R();
            public class CB0005B_WS_NUMREC_R : VarBasis
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
            /*"  05         AC-I-GELMR            PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_GELMR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
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
            /*"  05         AC-U-GELMR            PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_GELMR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            WDATA-PROPOSTA.*/
            public CB0005B_WDATA_PROPOSTA WDATA_PROPOSTA { get; set; } = new CB0005B_WDATA_PROPOSTA();
            public class CB0005B_WDATA_PROPOSTA : VarBasis
            {
                /*"    10          WDATA-AA-PROP   PIC  9(004)     VALUE    ZEROS.*/
                public IntBasis WDATA_AA_PROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-MM-PROP   PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_MM_PROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-DD-PROP   PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_DD_PROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            WDATA-NASCIMENTO.*/
            }
            public CB0005B_WDATA_NASCIMENTO WDATA_NASCIMENTO { get; set; } = new CB0005B_WDATA_NASCIMENTO();
            public class CB0005B_WDATA_NASCIMENTO : VarBasis
            {
                /*"    10          WDATA-AA-NASC   PIC  9(004)     VALUE    ZEROS.*/
                public IntBasis WDATA_AA_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-MM-NASC   PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_MM_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-DD-NASC   PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_DD_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05   WS-COMBINACAO                 PIC  X(020).*/
            }
            public StringBasis WS_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05   WS-COMBINACAO-R               REDEFINES       WS-COMBINACAO.*/
            private _REDEF_CB0005B_WS_COMBINACAO_R _ws_combinacao_r { get; set; }
            public _REDEF_CB0005B_WS_COMBINACAO_R WS_COMBINACAO_R
            {
                get { _ws_combinacao_r = new _REDEF_CB0005B_WS_COMBINACAO_R(); _.Move(WS_COMBINACAO, _ws_combinacao_r); VarBasis.RedefinePassValue(WS_COMBINACAO, _ws_combinacao_r, WS_COMBINACAO); _ws_combinacao_r.ValueChanged += () => { _.Move(_ws_combinacao_r, WS_COMBINACAO); }; return _ws_combinacao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_combinacao_r, WS_COMBINACAO); }
            }  //Redefines
            public class _REDEF_CB0005B_WS_COMBINACAO_R : VarBasis
            {
                /*"       10  WS-COMB OCCURS 20 TIMES   PIC  X(001).*/
                public ListBasis<StringBasis, string> WS_COMB { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 20);
                /*"  05   WS-COMBINACAO-9               PIC  9(009).*/

                public _REDEF_CB0005B_WS_COMBINACAO_R()
                {
                    WS_COMB.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_COMBINACAO_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05   WS-NUM-TITULO-X.*/
            public CB0005B_WS_NUM_TITULO_X WS_NUM_TITULO_X { get; set; } = new CB0005B_WS_NUM_TITULO_X();
            public class CB0005B_WS_NUM_TITULO_X : VarBasis
            {
                /*"       10  WS-NUM-PLANO              PIC  9(003).*/
                public IntBasis WS_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-NUM-SERIE              PIC  9(003).*/
                public IntBasis WS_NUM_SERIE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-NUM-TITULO             PIC  9(006).*/
                public IntBasis WS_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  05   WS-NUM-TITULO-9               REDEFINES       WS-NUM-TITULO-X               PIC  9(012).*/
            }
            private _REDEF_IntBasis _ws_num_titulo_9 { get; set; }
            public _REDEF_IntBasis WS_NUM_TITULO_9
            {
                get { _ws_num_titulo_9 = new _REDEF_IntBasis(new PIC("9", "012", "9(012).")); ; _.Move(WS_NUM_TITULO_X, _ws_num_titulo_9); VarBasis.RedefinePassValue(WS_NUM_TITULO_X, _ws_num_titulo_9, WS_NUM_TITULO_X); _ws_num_titulo_9.ValueChanged += () => { _.Move(_ws_num_titulo_9, WS_NUM_TITULO_X); }; return _ws_num_titulo_9; }
                set { VarBasis.RedefinePassValue(value, _ws_num_titulo_9, WS_NUM_TITULO_X); }
            }  //Redefines
            /*"  05   WS-SQLCODE                    PIC  ----9.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
            /*"  05  WS-CLIENTE-PEP                 PIC X(001)  VALUE SPACE.*/
            public StringBasis WS_CLIENTE_PEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05  WS-PEP-AVALIADO                PIC X(001)  VALUE SPACE.*/
            public StringBasis WS_PEP_AVALIADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01           FC0001S-LINKAGE.*/
        }
        public CB0005B_FC0001S_LINKAGE FC0001S_LINKAGE { get; set; } = new CB0005B_FC0001S_LINKAGE();
        public class CB0005B_FC0001S_LINKAGE : VarBasis
        {
            /*"  05         FC0001S-NUM-PROPOSTA    PIC  S9(015)    COMP-3.*/
            public IntBasis FC0001S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05         FC0001S-VLR-MENSALIDADE PIC  S9(008)V99 COMP-3.*/
            public DoubleBasis FC0001S_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
            /*"  05         FC0001S-NUM-PLANO       PIC  S9(004) COMP.*/
            public IntBasis FC0001S_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-NUM-SERIE       PIC  S9(004) COMP.*/
            public IntBasis FC0001S_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-NUM-TITULO      PIC  S9(009) COMP.*/
            public IntBasis FC0001S_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         FC0001S-IND-DV          PIC  S9(004) COMP.*/
            public IntBasis FC0001S_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-DTH-INI-VIGENCIA PIC   X(010).*/
            public StringBasis FC0001S_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FC0001S-DTH-FIM-VIGENCIA PIC   X(010).*/
            public StringBasis FC0001S_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FC0001S-DES-COMBINACAO  PIC   X(020).*/
            public StringBasis FC0001S_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05         FC0001S-SQLCODE         PIC  S9(004) COMP.*/
            public IntBasis FC0001S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-COD-RETORNO     PIC  S9(004) COMP.*/
            public IntBasis FC0001S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-DES-MENSAGEM    PIC   X(070).*/
            public StringBasis FC0001S_DES_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05        WABEND.*/
            public CB0005B_WABEND WABEND { get; set; } = new CB0005B_WABEND();
            public class CB0005B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'CB0005B '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CB0005B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01            LPARM.*/
            }
        }
        public CB0005B_LPARM LPARM { get; set; } = new CB0005B_LPARM();
        public class CB0005B_LPARM : VarBasis
        {
            /*"  03          LPARM01.*/
            public CB0005B_LPARM01 LPARM01 { get; set; } = new CB0005B_LPARM01();
            public class CB0005B_LPARM01 : VarBasis
            {
                /*"    10        LPARM01-DD          PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-MM          PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-AA          PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03          LPARM02.*/
            }
            public CB0005B_LPARM02 LPARM02 { get; set; } = new CB0005B_LPARM02();
            public class CB0005B_LPARM02 : VarBasis
            {
                /*"    10        LPARM02-DD          PIC  9(002).*/
                public IntBasis LPARM02_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM02-MM          PIC  9(002).*/
                public IntBasis LPARM02_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM02-AA          PIC  9(004).*/
                public IntBasis LPARM02_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03          LPARM03             PIC S9(005)    COMP-3.*/
            }
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GE0070W GE0070W { get; set; } = new Copies.GE0070W();
        public Copies.GE0071W GE0071W { get; set; } = new Copies.GE0071W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.PARAMPRO PARAMPRO { get; set; } = new Dclgens.PARAMPRO();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.APOLCOBR APOLCOBR { get; set; } = new Dclgens.APOLCOBR();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.GE101 GE101 { get; set; } = new Dclgens.GE101();
        public Dclgens.PARAMGER PARAMGER { get; set; } = new Dclgens.PARAMGER();
        public Dclgens.VG078 VG078 { get; set; } = new Dclgens.VG078();
        public Dclgens.GE637 GE637 { get; set; } = new Dclgens.GE637();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.VG131 VG131 { get; set; } = new Dclgens.VG131();
        public Dclgens.VG132 VG132 { get; set; } = new Dclgens.VG132();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public CB0005B_V0BILHETE V0BILHETE { get; set; } = new CB0005B_V0BILHETE();
        public CB0005B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new CB0005B_V1RCAPCOMP();
        public CB0005B_CCBO CCBO { get; set; } = new CB0005B_CCBO();
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
            /*" -1824- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1827- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1830- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1834- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1841- DISPLAY 'PROGRAMA EM EXECUCAO CB0005B-' 'VERSAO V.67 - DEMANDA 588808 - 05/09/2024.' */
            _.Display($"PROGRAMA EM EXECUCAO CB0005B-VERSAO V.67 - DEMANDA 588808 - 05/09/2024.");

            /*" -1848- DISPLAY 'COMPILADO EM  ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"COMPILADO EM  FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1850- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1851- DISPLAY ' ' */
            _.Display($" ");

            /*" -1858- DISPLAY ' ' */
            _.Display($" ");

            /*" -1863- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1864- INITIALIZE LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-EMP-CAP. */
            _.Initialize(
                GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM
                , GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM
                , GEJVW002.LK_GEJVW002_SIAS_NUM_EMP
                , GEJVW002.LK_GEJVW002_SIAS_DTA_INI
                , GEJVW002.LK_GEJVW002_SIAS_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_SIAS_COD_LIDER
                , GEJVW002.LK_GEJVW002_SIAS_COD_EMP_CAP
                , GEJVW002.LK_GEJVW002_PREV_NUM_EMP
                , GEJVW002.LK_GEJVW002_PREV_DTA_INI
                , GEJVW002.LK_GEJVW002_PREV_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_PREV_COD_LIDER
                , GEJVW002.LK_GEJVW002_PREV_COD_EMP_CAP
                , GEJVW002.LK_GEJVW002_JV_NUM_EMP
                , GEJVW002.LK_GEJVW002_JV_DTA_INI
                , GEJVW002.LK_GEJVW002_JV_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_JV_COD_LIDER
                , GEJVW002.LK_GEJVW002_JV_COD_EMP_CAP
            );

            /*" -1868- INITIALIZE LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Initialize(
                GEJVWCNT.LK_GEJVWCNT_IND_ERRO
                , GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO
                , GEJVWCNT.LK_GEJVWCNT_NOME_TABELA
                , GEJVWCNT.LK_GEJVWCNT_SQLCODE
                , GEJVWCNT.LK_GEJVWCNT_SQLERRMC
            );

            /*" -1869- MOVE 'CB0005B' TO LK-GEJVW002-NOM-PROG-ORIGEM. */
            _.Move("CB0005B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -1870- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM. */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -1870- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WORK_JV1.WS_JV1_PROGRAMA);

            /*" -1872- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WORK_JV1.WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -1873- IF LK-GEJVWCNT-IND-ERRO NOT = ZEROS */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 00)
            {

                /*" -1874- DISPLAY 'CB0005B- ERRO NA CHAMADA DA GEJVS002 ' */
                _.Display($"CB0005B- ERRO NA CHAMADA DA GEJVS002 ");

                /*" -1875- DISPLAY 'CB0005B- ROTINA CANCELADA ' */
                _.Display($"CB0005B- ROTINA CANCELADA ");

                /*" -1876- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1879- END-IF. */
            }


            /*" -1881- INITIALIZE TAB-CBO1. */
            _.Initialize(
                TAB_CBO1
            );

            /*" -1883- PERFORM R8100-00-DECLARE-CBO. */

            R8100_00_DECLARE_CBO_SECTION();

            /*" -1885- PERFORM R8110-00-FETCH-CBO. */

            R8110_00_FETCH_CBO_SECTION();

            /*" -1886- IF WFIM-CBO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CBO.IsEmpty())
            {

                /*" -1887- DISPLAY '8110 - PROBLEMA NO FETCH DA CBO         ' */
                _.Display($"8110 - PROBLEMA NO FETCH DA CBO         ");

                /*" -1888- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1890- END-IF */
            }


            /*" -1893- PERFORM R8120-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_CBO == "S"))
            {

                R8120_00_CARREGA_CBO_SECTION();
            }

            /*" -1894- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1896- DISPLAY 'INICIO DO DECLARE ...... ' WS-TIME. */
            _.Display($"INICIO DO DECLARE ...... {WS_TIME}");

            /*" -1898- PERFORM R0900-00-DECLARE-V0BILHETE. */

            R0900_00_DECLARE_V0BILHETE_SECTION();

            /*" -1900- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

            /*" -1901- IF WFIM-V0BILHETE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty())
            {

                /*" -1903- DISPLAY 'CB0005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...' */
                _.Display($"CB0005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...");

                /*" -1904- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -1906- END-IF */
            }


            /*" -1909- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0BILHETE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1915- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -1915- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1918- DISPLAY 'PROCESSAMENTO COM COMMIT ' */
            _.Display($"PROCESSAMENTO COM COMMIT ");

            /*" -1918- . */

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1923- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1925- DISPLAY 'FIM DO PROCESSAMENTO ......... ' WS-TIME. */
            _.Display($"FIM DO PROCESSAMENTO ......... {WS_TIME}");

            /*" -1927- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1928- DISPLAY ' ' */
            _.Display($" ");

            /*" -1930- DISPLAY '*--------  CB0005B - FIM NORMAL  --------*' */
            _.Display($"*--------  CB0005B - FIM NORMAL  --------*");

            /*" -1930- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1941- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1942- DISPLAY 'R0100-00-SELECT-V1SISTEMA' */
            _.Display($"R0100-00-SELECT-V1SISTEMA");

            /*" -1947- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1952- DISPLAY 'SEL V1SISTEMA EM ' V1SIST-DTMOVABE '/' V1SIST-DTCURRENT '*SQLCODE: ' SQLCODE */

            $"SEL V1SISTEMA EM {V1SIST_DTMOVABE}/{V1SIST_DTCURRENT}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1953- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1954- DISPLAY 'ERRO SELECT V1SISTEMA EM' */
                _.Display($"ERRO SELECT V1SISTEMA EM");

                /*" -1956- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1959- MOVE '0101' TO WNR-EXEC-SQL. */
            _.Move("0101", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1964- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_2 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_2();

            /*" -1969- DISPLAY 'SEL V1SISTEMA CB ' V1SIST-DTMOVACB '/' V1SIST-TIMESTAMP '*SQLCODE: ' SQLCODE */

            $"SEL V1SISTEMA CB {V1SIST_DTMOVACB}/{V1SIST_TIMESTAMP}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1971- DISPLAY 'ERRO SELECT V1SISTEMA CB' */
                _.Display($"ERRO SELECT V1SISTEMA CB");

                /*" -1977- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1979- MOVE 10 TO WS-VLDIFE. */
            _.Move(10, AREA_DE_WORK.WS_VLDIFE);

            /*" -1979- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1947- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

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
            /*" -1964- EXEC SQL SELECT DTMOVABE,CURRENT TIMESTAMP INTO :V1SIST-DTMOVACB, :V1SIST-TIMESTAMP FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVACB, V1SIST_DTMOVACB);
                _.Move(executed_1.V1SIST_TIMESTAMP, V1SIST_TIMESTAMP);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-SECTION */
        private void R0900_00_DECLARE_V0BILHETE_SECTION()
        {
            /*" -1990- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1992- DISPLAY 'R0900-00-DECLARE-V0BILHETE' */
            _.Display($"R0900-00-DECLARE-V0BILHETE");

            /*" -1994- MOVE SPACE TO WFIM-V0BILHETE. */
            _.Move("", AREA_DE_WORK.WFIM_V0BILHETE);

            /*" -2093- PERFORM R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1 */

            R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1();

            /*" -2096- PERFORM R0900_00_DECLARE_V0BILHETE_DB_OPEN_1 */

            R0900_00_DECLARE_V0BILHETE_DB_OPEN_1();

            /*" -2100- DISPLAY 'OPE V0BILHETE ' '*SQLCODE: ' SQLCODE */

            $"OPE V0BILHETE *SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2101- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2102- DISPLAY 'PROBLEMAS NO OPEN (V0BILHETE) ... ' */
                _.Display($"PROBLEMAS NO OPEN (V0BILHETE) ... ");

                /*" -2102- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1()
        {
            /*" -2093- EXEC SQL DECLARE V0BILHETE CURSOR WITH HOLD FOR SELECT NUM_BILHETE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , COD_CLIENTE , PROFISSAO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , DATA_QUITACAO + 1 MONTH , VAL_RCAP , RAMO , DATA_VENDA , COD_USUARIO , SITUACAO , NUM_APOL_ANTERIOR , VALUE (COD_PRODUTO, 0), DATA_QUITACAO + 1 YEAR, DATA_QUITACAO + 3 YEAR, DATA_QUITACAO + 5 YEAR FROM SEGUROS.BILHETE WHERE SITUACAO IN ( '0' , '2' , '4' ) AND NUM_APOL_ANTERIOR = 0 AND RAMO IN (81, 82) AND TIMESTAMP < :V1SIST-TIMESTAMP AND DATA_QUITACAO <> '9999-12-31' UNION SELECT NUM_BILHETE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , COD_CLIENTE , PROFISSAO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , DATA_QUITACAO + 1 MONTH , VAL_RCAP , RAMO , DATA_VENDA , COD_USUARIO , SITUACAO , NUM_APOL_ANTERIOR , VALUE (COD_PRODUTO, 0), DATA_QUITACAO + 1 YEAR, DATA_QUITACAO + 3 YEAR, DATA_QUITACAO + 5 YEAR FROM SEGUROS.BILHETE WHERE SITUACAO IN ( '0' , '2' , '3' , '4' ) AND NUM_APOL_ANTERIOR = 0 AND RAMO = 37 AND OPC_COBERTURA IN(21, 31) AND TIMESTAMP < :V1SIST-TIMESTAMP AND DATA_QUITACAO <> '9999-12-31' UNION SELECT NUM_BILHETE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , COD_CLIENTE , PROFISSAO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , DATA_QUITACAO + 1 MONTH , VAL_RCAP , RAMO , DATA_VENDA , COD_USUARIO , SITUACAO , NUM_APOL_ANTERIOR , VALUE (COD_PRODUTO, 0), DATA_QUITACAO + 1 YEAR, DATA_QUITACAO + 3 YEAR, DATA_QUITACAO + 5 YEAR FROM SEGUROS.BILHETE WHERE SITUACAO IN ( '0' , '2' , '3' , '4' ) AND NUM_APOL_ANTERIOR = 0 AND RAMO = 37 AND COD_PRODUTO IN (3721, 3729) AND TIMESTAMP < :V1SIST-TIMESTAMP AND DATA_QUITACAO <> '9999-12-31' END-EXEC. */
            V0BILHETE = new CB0005B_V0BILHETE(true);
            string GetQuery_V0BILHETE()
            {
                var query = @$"SELECT NUM_BILHETE
							, 
							FONTE
							, 
							AGE_COBRANCA
							, 
							NUM_MATRICULA
							, 
							COD_AGENCIA
							, 
							COD_CLIENTE
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
							DATA_QUITACAO
							, 
							DATA_QUITACAO + 1 MONTH
							, 
							VAL_RCAP
							, 
							RAMO
							, 
							DATA_VENDA
							, 
							COD_USUARIO
							, 
							SITUACAO
							, 
							NUM_APOL_ANTERIOR
							, 
							VALUE (COD_PRODUTO
							, 0)
							, 
							DATA_QUITACAO + 1 YEAR
							, 
							DATA_QUITACAO + 3 YEAR
							, 
							DATA_QUITACAO + 5 YEAR 
							FROM SEGUROS.BILHETE 
							WHERE SITUACAO IN ( '0'
							, '2'
							, '4' ) 
							AND NUM_APOL_ANTERIOR = 0 
							AND RAMO IN (81
							, 82) 
							AND TIMESTAMP < '{V1SIST_TIMESTAMP}' 
							AND DATA_QUITACAO <> '9999-12-31' 
							UNION 
							SELECT NUM_BILHETE
							, 
							FONTE
							, 
							AGE_COBRANCA
							, 
							NUM_MATRICULA
							, 
							COD_AGENCIA
							, 
							COD_CLIENTE
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
							DATA_QUITACAO
							, 
							DATA_QUITACAO + 1 MONTH
							, 
							VAL_RCAP
							, 
							RAMO
							, 
							DATA_VENDA
							, 
							COD_USUARIO
							, 
							SITUACAO
							, 
							NUM_APOL_ANTERIOR
							, 
							VALUE (COD_PRODUTO
							, 0)
							, 
							DATA_QUITACAO + 1 YEAR
							, 
							DATA_QUITACAO + 3 YEAR
							, 
							DATA_QUITACAO + 5 YEAR 
							FROM SEGUROS.BILHETE 
							WHERE SITUACAO IN ( '0'
							, '2'
							, '3'
							, '4' ) 
							AND NUM_APOL_ANTERIOR = 0 
							AND RAMO = 37 
							AND OPC_COBERTURA IN(21
							, 31) 
							AND TIMESTAMP < '{V1SIST_TIMESTAMP}' 
							AND DATA_QUITACAO <> '9999-12-31' 
							UNION 
							SELECT NUM_BILHETE
							, 
							FONTE
							, 
							AGE_COBRANCA
							, 
							NUM_MATRICULA
							, 
							COD_AGENCIA
							, 
							COD_CLIENTE
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
							DATA_QUITACAO
							, 
							DATA_QUITACAO + 1 MONTH
							, 
							VAL_RCAP
							, 
							RAMO
							, 
							DATA_VENDA
							, 
							COD_USUARIO
							, 
							SITUACAO
							, 
							NUM_APOL_ANTERIOR
							, 
							VALUE (COD_PRODUTO
							, 0)
							, 
							DATA_QUITACAO + 1 YEAR
							, 
							DATA_QUITACAO + 3 YEAR
							, 
							DATA_QUITACAO + 5 YEAR 
							FROM SEGUROS.BILHETE 
							WHERE SITUACAO IN ( '0'
							, '2'
							, '3'
							, '4' ) 
							AND NUM_APOL_ANTERIOR = 0 
							AND RAMO = 37 
							AND COD_PRODUTO IN (3721
							, 3729) 
							AND TIMESTAMP < '{V1SIST_TIMESTAMP}' 
							AND DATA_QUITACAO <> '9999-12-31'";

                return query;
            }
            V0BILHETE.GetQueryEvent += GetQuery_V0BILHETE;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_OPEN_1()
        {
            /*" -2096- EXEC SQL OPEN V0BILHETE END-EXEC. */

            V0BILHETE.Open();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -5805- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */
            V1RCAPCOMP = new CB0005B_V1RCAPCOMP(true);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0BILHETE-SECTION */
        private void R0910_00_FETCH_V0BILHETE_SECTION()
        {
            /*" -2111- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0910_10_LE */

            R0910_10_LE();

        }

        [StopWatch]
        /*" R0910-10-LE */
        private void R0910_10_LE(bool isPerform = false)
        {
            /*" -2117- DISPLAY 'R0910-00-FETCH-V0BILHETE' */
            _.Display($"R0910-00-FETCH-V0BILHETE");

            /*" -2142- PERFORM R0910_10_LE_DB_FETCH_1 */

            R0910_10_LE_DB_FETCH_1();

            /*" -2148- DISPLAY 'FET V0BILHETE ' V0BILH-NUMBIL '/' V0BILH-COD-PRODUTO '*SQLCODE: ' SQLCODE */

            $"FET V0BILHETE {V0BILH_NUMBIL}/{V0BILH_COD_PRODUTO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2149- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2150- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2150- PERFORM R0910_10_LE_DB_CLOSE_1 */

                    R0910_10_LE_DB_CLOSE_1();

                    /*" -2152- MOVE 'S' TO WFIM-V0BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIM_V0BILHETE);

                    /*" -2153- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -2154- ELSE */
                }
                else
                {


                    /*" -2155- DISPLAY 'R0910-00 (ERRO -  FETCH V0BILHETE)...' */
                    _.Display($"R0910-00 (ERRO -  FETCH V0BILHETE)...");

                    /*" -2156- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2157- END-IF */
                }


                /*" -2159- END-IF */
            }


            /*" -2162- ADD 1 TO WACC-LIDOS WACC-DISPLAY */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_DISPLAY.Value = AREA_DE_WORK.WACC_DISPLAY + 1;

            /*" -2163- IF WACC-LIDOS-B EQUAL ZEROS OR 500 */

            if (AREA_DE_WORK.WACC_LIDOS_RD.WACC_LIDOS_B.In("00", "500"))
            {

                /*" -2164- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -2167- DISPLAY 'REGISTROS LIDOS.. ' WACC-LIDOS 'TOTAL ATUALIZADO.. ' WPROC-BILHETES '  ' WS-TIME */

                $"REGISTROS LIDOS.. {AREA_DE_WORK.WACC_LIDOS}TOTAL ATUALIZADO.. {AREA_DE_WORK.WPROC_BILHETES}  {WS_TIME}"
                .Display();

                /*" -2168- MOVE ZEROS TO WACC-PROCESSADOS */
                _.Move(0, AREA_DE_WORK.WACC_PROCESSADOS);

                /*" -2170- END-IF */
            }


            /*" -2171- INITIALIZE WORK-TAB-ERROS-CERT */
            _.Initialize(
                WORK_TAB_ERROS_CERT
            );

            /*" -2172- MOVE ZEROS TO WS-I-ERRO */
            _.Move(0, WS_I_ERRO);

            /*" -2173- . */

            /*" -2175- IF V0BILH-NUMBIL > 82120000000 AND < 82129999999 */

            if (V0BILH_NUMBIL > 82120000000 && V0BILH_NUMBIL < 82129999999)
            {

                /*" -2176- MOVE 'S' TO WS-BILFOFA */
                _.Move("S", AREA_DE_WORK.WS_BILFOFA);

                /*" -2177- ELSE */
            }
            else
            {


                /*" -2178- MOVE 'N' TO WS-BILFOFA */
                _.Move("N", AREA_DE_WORK.WS_BILFOFA);

                /*" -2179- END-IF */
            }


            /*" -2179- . */

        }

        [StopWatch]
        /*" R0910-10-LE-DB-FETCH-1 */
        public void R0910_10_LE_DB_FETCH_1()
        {
            /*" -2142- EXEC SQL FETCH V0BILHETE INTO :V0BILH-NUMBIL , :V0BILH-FONTE , :V0BILH-AGECOBR , :V0BILH-NUM-MATR , :V0BILH-AGENCIA , :V0BILH-CODCLIEN , :V0BILH-PROFISSAO , :V0BILH-AGENCIA-DEB , :V0BILH-OPERACAO-DEB , :V0BILH-NUMCTA-DEB , :V0BILH-DIGCTA-DEB , :V0BILH-OPCAO-COBER , :V0BILH-DTQITBCO , :V0BILH-DTVENCTO , :V0BILH-VLRCAP , :V0BILH-RAMO , :V0BILH-DTVENDA , :V0BILH-CODUSU , :V0BILH-SITUACAO , :V0BILH-NUM-APO-ANT , :V0BILH-COD-PRODUTO , :WSGER12-DATA-TERVIGENCIA , :WSGER36-DATA-TERVIGENCIA , :WSGER60-DATA-TERVIGENCIA END-EXEC */

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
                _.Move(V0BILHETE.V0BILH_DTQITBCO, V0BILH_DTQITBCO);
                _.Move(V0BILHETE.V0BILH_DTVENCTO, V0BILH_DTVENCTO);
                _.Move(V0BILHETE.V0BILH_VLRCAP, V0BILH_VLRCAP);
                _.Move(V0BILHETE.V0BILH_RAMO, V0BILH_RAMO);
                _.Move(V0BILHETE.V0BILH_DTVENDA, V0BILH_DTVENDA);
                _.Move(V0BILHETE.V0BILH_CODUSU, V0BILH_CODUSU);
                _.Move(V0BILHETE.V0BILH_SITUACAO, V0BILH_SITUACAO);
                _.Move(V0BILHETE.V0BILH_NUM_APO_ANT, V0BILH_NUM_APO_ANT);
                _.Move(V0BILHETE.V0BILH_COD_PRODUTO, V0BILH_COD_PRODUTO);
                _.Move(V0BILHETE.WSGER12_DATA_TERVIGENCIA, WSGER12_DATA_TERVIGENCIA);
                _.Move(V0BILHETE.WSGER36_DATA_TERVIGENCIA, WSGER36_DATA_TERVIGENCIA);
                _.Move(V0BILHETE.WSGER60_DATA_TERVIGENCIA, WSGER60_DATA_TERVIGENCIA);
            }

        }

        [StopWatch]
        /*" R0910-10-LE-DB-CLOSE-1 */
        public void R0910_10_LE_DB_CLOSE_1()
        {
            /*" -2150- EXEC SQL CLOSE V0BILHETE END-EXEC */

            V0BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -2189- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2226- DISPLAY 'R1000-00-PROCESSA-REGISTRO' */
            _.Display($"R1000-00-PROCESSA-REGISTRO");

            /*" -2227- PERFORM R1100-00-SELECT-CLIENTE */

            R1100_00_SELECT_CLIENTE_SECTION();

            /*" -2228- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2229- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -2232- END-IF */
            }


            /*" -2233- IF V0BILH-COD-PRODUTO GREATER ZEROS */

            if (V0BILH_COD_PRODUTO > 00)
            {

                /*" -2234- PERFORM R1700-00-ACESSA-GE0070S THRU R1700-99-SAIDA */

                R1700_00_ACESSA_GE0070S_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/


                /*" -2235- ELSE */
            }
            else
            {


                /*" -2236- MOVE 'N' TO N88-NOVOS-ACESSOS */
                _.Move("N", N88_NOVOS_ACESSOS);

                /*" -2239- END-IF */
            }


            /*" -2240- IF V0BILH-COD-PRODUTO EQUAL ZEROS */

            if (V0BILH_COD_PRODUTO == 00)
            {

                /*" -2241- PERFORM R1600-00-BUSCA-PRODUTO THRU R1600-99-SAIDA */

                R1600_00_BUSCA_PRODUTO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                /*" -2242- IF WS-JV1-ACHEI-PRODUTO = 'NAO' */

                if (WORK_JV1.WS_JV1_ACHEI_PRODUTO == "NAO")
                {

                    /*" -2243- DISPLAY 'R1015-00 (NAO ENCONTRADO BILHETE_COBERTURA)' */
                    _.Display($"R1015-00 (NAO ENCONTRADO BILHETE_COBERTURA)");

                    /*" -2245- DISPLAY 'BILHETE: ' V0BILH-NUMBIL ' ' V0BILH-RAMO ' ' V0BILH-OPCAO-COBER */

                    $"BILHETE: {V0BILH_NUMBIL} {V0BILH_RAMO} {V0BILH_OPCAO_COBER}"
                    .Display();

                    /*" -2246- GO TO R1000-00-LEITURA */

                    R1000_00_LEITURA(); //GOTO
                    return;

                    /*" -2247- END-IF */
                }


                /*" -2248- ELSE */
            }
            else
            {


                /*" -2249- MOVE V0BILH-COD-PRODUTO TO V1BILP-CODPRODU */
                _.Move(V0BILH_COD_PRODUTO, V1BILP_CODPRODU);

                /*" -2255- END-IF */
            }


            /*" -2257- IF V0BILH-DTQITBCO >= LK-GEJVW002-JV-DTA-INI AND JVPROD(V1BILP-CODPRODU) NOT = ZEROS */

            if (V0BILH_DTQITBCO >= GEJVW002.LK_GEJVW002_JV_DTA_INI && JVBKINCL.FILLER.JVPROD[V1BILP_CODPRODU] != 00)
            {

                /*" -2258- MOVE JVPROD(V1BILP-CODPRODU) TO V1BILP-CODPRODU */
                _.Move(JVBKINCL.FILLER.JVPROD[V1BILP_CODPRODU], V1BILP_CODPRODU);

                /*" -2262- END-IF. */
            }


            /*" -2264- MOVE V1BILP-CODPRODU TO PRODUTO-COD-PRODUTO WS-COD-PRODUTO. */
            _.Move(V1BILP_CODPRODU, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, WS_COD_PRODUTO);

            /*" -2265- INITIALIZE WS-SIT-PRODUTO. */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -2267- PERFORM R2320-PRODUTO-RUNOFF. */

            R2320_PRODUTO_RUNOFF_SECTION();

            /*" -2269- PERFORM R8000-JV1-BUSCA-PRODUTO. */

            R8000_JV1_BUSCA_PRODUTO_SECTION();

            /*" -2270- IF (PRODUTO-COD-EMPRESA = 10 OR 11) */

            if ((PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.In("10", "11")))
            {

                /*" -2271- IF WS-PROD-RUNON */

                if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                {

                    /*" -2272- MOVE 300 TO WH-JV1-COD-ORGAO */
                    _.Move(300, WORK_JV1.WH_JV1_COD_ORGAO);

                    /*" -2273- ELSE */
                }
                else
                {


                    /*" -2274- MOVE 10 TO WH-JV1-COD-ORGAO */
                    _.Move(10, WORK_JV1.WH_JV1_COD_ORGAO);

                    /*" -2275- END-IF */
                }


                /*" -2278- END-IF. */
            }


            /*" -2280- PERFORM R3060-00-VERIFICA-CRTCA-PEND */

            R3060_00_VERIFICA_CRTCA_PEND_SECTION();

            /*" -2281- IF WS-ERRO-COUNT > ZEROS */

            if (WS_ERRO_COUNT > 00)
            {

                /*" -2282- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -2283- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -2286- DISPLAY 'BILHETE POSSUI CRITICA PENDENTE CADASTRADA. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' WS-ERRO-COUNT */

                $"BILHETE POSSUI CRITICA PENDENTE CADASTRADA. {V0BILH_NUMBIL} {V0BILH_CODCLIEN} {V0CLIE_CGCCPF} {WS_ERRO_COUNT}"
                .Display();

                /*" -2287- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -2291- END-IF */
            }


            /*" -2310- IF (V0BILH-RAMO EQUAL 37 OR 81 OR 82) AND (V1BILP-CODPRODU EQUAL 3709 OR JVPRD3709 OR 3721 OR 8144 OR 8145 OR 8146 OR 8147 OR 8148 OR 8149 OR 8150 OR JVPRD8144 OR JVPRD8145 OR JVPRD8146 OR JVPRD8147 OR JVPRD8148 OR JVPRD8149 OR JVPRD8150 OR 8521 OR 8528 OR 8529 OR 8533 OR 8534) */

            if ((V0BILH_RAMO.In("37", "81", "82")) && (V1BILP_CODPRODU.In("3709", JVBKINCL.JV_PRODUTOS.JVPRD3709.ToString(), "3721", "8144", "8145", "8146", "8147", "8148", "8149", "8150", JVBKINCL.JV_PRODUTOS.JVPRD8144.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8145.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8146.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8147.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8148.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8149.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8150.ToString(), "8521", "8528", "8529", "8533", "8534")))
            {

                /*" -2311- PERFORM R1200-00-SELECT-GELIMRISCO */

                R1200_00_SELECT_GELIMRISCO_SECTION();

                /*" -2312- IF NOVOS-ACESSOS */

                if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -2313- MOVE LK-0071-S-VLR-TOTAL-IS TO V1BILC-IMPSEG-IX */
                    _.Move(GE0071W.LK_0071_S_VLR_TOTAL_IS, V1BILC_IMPSEG_IX);

                    /*" -2314- ELSE */
                }
                else
                {


                    /*" -2315- PERFORM R1300-00-SELECT-BIL-COBER */

                    R1300_00_SELECT_BIL_COBER_SECTION();

                    /*" -2316- END-IF */
                }


                /*" -2317- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2318- GO TO R1000-00-LEITURA */

                    R1000_00_LEITURA(); //GOTO
                    return;

                    /*" -2320- END-IF */
                }


                /*" -2328- COMPUTE GELMR-VLR-SOMA-IS = GELMR-VLR-SOMA-IS + V1BILC-IMPSEG-IX */
                GELMR_VLR_SOMA_IS.Value = GELMR_VLR_SOMA_IS + V1BILC_IMPSEG_IX;

                /*" -2336- IF V1BILP-CODPRODU EQUAL 8144 OR 8145 OR 8146 OR 8147 OR 8148 OR 8149 OR 8150 OR JVPRD8144 OR JVPRD8145 OR JVPRD8146 OR JVPRD8147 OR JVPRD8148 OR JVPRD8149 OR JVPRD8150 OR 8521 OR 8528 OR 8529 OR 8533 OR 8534 */

                if (V1BILP_CODPRODU.In("8144", "8145", "8146", "8147", "8148", "8149", "8150", JVBKINCL.JV_PRODUTOS.JVPRD8144.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8145.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8146.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8147.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8148.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8149.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8150.ToString(), "8521", "8528", "8529", "8533", "8534"))
                {

                    /*" -2337- IF GELMR-VLR-SOMA-IS > 2000000,01 */

                    if (GELMR_VLR_SOMA_IS > 2000000.01)
                    {

                        /*" -2338- MOVE 834 TO V0BILER-COD-ERRO */
                        _.Move(834, V0BILER_COD_ERRO);

                        /*" -2340- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -2341- MOVE 'R' TO V0BILH-SITUACAO */
                        _.Move("R", V0BILH_SITUACAO);

                        /*" -2342- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -2346- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(1) BILHETE REJEITA 'DO. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' GELMR-VLR-SOMA-IS */

                        $"ULTRAPASSA LIMITE DE RISCO(1) BILHETE REJEITA DO. V0BILH-NUMBIL  V0BILH-CODCLIEN  V0CLIE-CGCCPF  V1BILP-CODPRODU {GELMR_VLR_SOMA_IS}"
                        .Display();

                        /*" -2347- GO TO R1000-00-LEITURA */

                        R1000_00_LEITURA(); //GOTO
                        return;

                        /*" -2348- END-IF */
                    }


                    /*" -2349- ELSE */
                }
                else
                {


                    /*" -2351- IF GELMR-VLR-SOMA-IS > 100000,01 AND V1BILP-CODPRODU NOT EQUAL 8103 */

                    if (GELMR_VLR_SOMA_IS > 100000.01 && V1BILP_CODPRODU != 8103)
                    {

                        /*" -2352- MOVE 834 TO V0BILER-COD-ERRO */
                        _.Move(834, V0BILER_COD_ERRO);

                        /*" -2354- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -2355- MOVE 'R' TO V0BILH-SITUACAO */
                        _.Move("R", V0BILH_SITUACAO);

                        /*" -2356- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -2360- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(2) BILHETE REJEITA 'DO. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' GELMR-VLR-SOMA-IS */

                        $"ULTRAPASSA LIMITE DE RISCO(2) BILHETE REJEITA DO. V0BILH-NUMBIL  V0BILH-CODCLIEN  V0CLIE-CGCCPF  V1BILP-CODPRODU {GELMR_VLR_SOMA_IS}"
                        .Display();

                        /*" -2361- GO TO R1000-00-LEITURA */

                        R1000_00_LEITURA(); //GOTO
                        return;

                        /*" -2362- END-IF */
                    }


                    /*" -2363- END-IF */
                }


                /*" -2365- END-IF */
            }


            /*" -2366- MOVE V0BILH-RAMO TO WWORK-RAMO-ANT */
            _.Move(V0BILH_RAMO, WWORK_RAMO_ANT);

            /*" -2368- MOVE V0BILH-OPCAO-COBER TO WWORK-OPCAO-ANT. */
            _.Move(V0BILH_OPCAO_COBER, WWORK_OPCAO_ANT);

            /*" -2369- MOVE ZEROES TO V0ADIA-VALADT. */
            _.Move(0, V0ADIA_VALADT);

            /*" -2370- MOVE '9999-99-99' TO WWORK-MIN-DTINIVIG. */
            _.Move("9999-99-99", WWORK_MIN_DTINIVIG);

            /*" -2371- MOVE SPACES TO WWORK-MAX-DTTERVIG. */
            _.Move("", WWORK_MAX_DTTERVIG);

            /*" -2375- MOVE ZEROES TO WWORK-NUM-ITENS. */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_ITENS);

            /*" -2376- MOVE V0BILH-DTQITBCO TO WWORK-DATA. */
            _.Move(V0BILH_DTQITBCO, AREA_DE_WORK.WWORK_DATA);

            /*" -2377- MOVE WWORK-ANO TO WWORK-ANOINI. */
            _.Move(AREA_DE_WORK.WWORK_DATA.WWORK_ANO, AREA_DE_WORK.FILLER_17.WWORK_ANOINI);

            /*" -2378- MOVE WWORK-MES TO WWORK-MESINI. */
            _.Move(AREA_DE_WORK.WWORK_DATA.WWORK_MES, AREA_DE_WORK.FILLER_17.WWORK_MESINI);

            /*" -2380- MOVE WWORK-DIA TO WWORK-DIAINI. */
            _.Move(AREA_DE_WORK.WWORK_DATA.WWORK_DIA, AREA_DE_WORK.FILLER_17.WWORK_DIAINI);

            /*" -2381- MOVE WWORK-DATAINI TO WS000-DATA01. */
            _.Move(AREA_DE_WORK.WWORK_DATAINI, WS000_PARM_PROSOMD1.WS000_DATA01);

            /*" -2382- MOVE 1 TO WS000-QTDIAS. */
            _.Move(1, WS000_PARM_PROSOMD1.WS000_QTDIAS);

            /*" -2384- MOVE ZEROS TO WS000-DATA02. */
            _.Move(0, WS000_PARM_PROSOMD1.WS000_DATA02);

            /*" -2386- CALL 'PROSOMC1' USING WS000-PARM-PROSOMD1 */
            _.Call("PROSOMC1", WS000_PARM_PROSOMD1);

            /*" -2387- MOVE WS000-DATA02 TO WWORK-DATAINI. */
            _.Move(WS000_PARM_PROSOMD1.WS000_DATA02, AREA_DE_WORK.WWORK_DATAINI);

            /*" -2388- MOVE WWORK-ANOINI TO WWORK-ANO. */
            _.Move(AREA_DE_WORK.FILLER_17.WWORK_ANOINI, AREA_DE_WORK.WWORK_DATA.WWORK_ANO);

            /*" -2389- MOVE WWORK-MESINI TO WWORK-MES. */
            _.Move(AREA_DE_WORK.FILLER_17.WWORK_MESINI, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

            /*" -2391- MOVE WWORK-DIAINI TO WWORK-DIA. */
            _.Move(AREA_DE_WORK.FILLER_17.WWORK_DIAINI, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -2392- IF WWORK-MES EQUAL 02 */

            if (AREA_DE_WORK.WWORK_DATA.WWORK_MES == 02)
            {

                /*" -2393- IF WWORK-DIA EQUAL 29 */

                if (AREA_DE_WORK.WWORK_DATA.WWORK_DIA == 29)
                {

                    /*" -2394- COMPUTE WWORK-ANO-BI = WWORK-ANO / 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO / 4;

                    /*" -2395- COMPUTE WWORK-ANO-BI = WWORK-ANO-BI * 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_ANO_BI * 4;

                    /*" -2396- IF WWORK-ANO NOT EQUAL WWORK-ANO-BI */

                    if (AREA_DE_WORK.WWORK_DATA.WWORK_ANO != AREA_DE_WORK.WWORK_ANO_BI)
                    {

                        /*" -2397- MOVE 03 TO WWORK-MES */
                        _.Move(03, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

                        /*" -2399- MOVE 01 TO WWORK-DIA. */
                        _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);
                    }

                }

            }


            /*" -2400- IF WWORK-DATA < WWORK-MIN-DTINIVIG */

            if (AREA_DE_WORK.WWORK_DATA < WWORK_MIN_DTINIVIG)
            {

                /*" -2402- MOVE WWORK-DATA TO WWORK-MIN-DTINIVIG. */
                _.Move(AREA_DE_WORK.WWORK_DATA, WWORK_MIN_DTINIVIG);
            }


            /*" -2403- COMPUTE WWORK-ANOINI = WWORK-ANOINI + 1. */
            AREA_DE_WORK.FILLER_17.WWORK_ANOINI.Value = AREA_DE_WORK.FILLER_17.WWORK_ANOINI + 1;

            /*" -2405- MOVE WWORK-ANOINI TO WWORK-ANO. */
            _.Move(AREA_DE_WORK.FILLER_17.WWORK_ANOINI, AREA_DE_WORK.WWORK_DATA.WWORK_ANO);

            /*" -2406- IF WWORK-MES EQUAL 02 */

            if (AREA_DE_WORK.WWORK_DATA.WWORK_MES == 02)
            {

                /*" -2407- IF WWORK-DIA EQUAL 29 */

                if (AREA_DE_WORK.WWORK_DATA.WWORK_DIA == 29)
                {

                    /*" -2408- COMPUTE WWORK-ANO-BI = WWORK-ANO / 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO / 4;

                    /*" -2409- COMPUTE WWORK-ANO-BI = WWORK-ANO-BI * 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_ANO_BI * 4;

                    /*" -2410- IF WWORK-ANO NOT EQUAL WWORK-ANO-BI */

                    if (AREA_DE_WORK.WWORK_DATA.WWORK_ANO != AREA_DE_WORK.WWORK_ANO_BI)
                    {

                        /*" -2411- MOVE 03 TO WWORK-MES */
                        _.Move(03, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

                        /*" -2413- MOVE 01 TO WWORK-DIA. */
                        _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);
                    }

                }

            }


            /*" -2414- IF WWORK-DATA > WWORK-MAX-DTTERVIG */

            if (AREA_DE_WORK.WWORK_DATA > WWORK_MAX_DTTERVIG)
            {

                /*" -2416- MOVE WWORK-DATA TO WWORK-MAX-DTTERVIG. */
                _.Move(AREA_DE_WORK.WWORK_DATA, WWORK_MAX_DTTERVIG);
            }


            /*" -2419- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2420- EVALUATE V1BILP-CODPRODU */
            switch (V1BILP_CODPRODU.Value)
            {

                /*" -2421- WHEN 8521 */
                case 8521:

                    /*" -2422- WHEN 8530 */
                    break;
                case 8530:

                /*" -2423- WHEN 3729 */
                case 3729:

                    /*" -2424- MOVE WSGER60-DATA-TERVIGENCIA TO WWORK-MAX-DTTERVIG */
                    _.Move(WSGER60_DATA_TERVIGENCIA, WWORK_MAX_DTTERVIG);

                    /*" -2425- WHEN 8529 */
                    break;
                case 8529:

                /*" -2426- WHEN 8532 */
                case 8532:

                    /*" -2427- WHEN 8534 */
                    break;
                case 8534:

                    /*" -2428- MOVE WSGER36-DATA-TERVIGENCIA TO WWORK-MAX-DTTERVIG */
                    _.Move(WSGER36_DATA_TERVIGENCIA, WWORK_MAX_DTTERVIG);

                    /*" -2429- WHEN 8528 */
                    break;
                case 8528:

                /*" -2430- WHEN 8531 */
                case 8531:

                    /*" -2431- WHEN 8533 */
                    break;
                case 8533:

                    /*" -2432- MOVE WSGER12-DATA-TERVIGENCIA TO WWORK-MAX-DTTERVIG */
                    _.Move(WSGER12_DATA_TERVIGENCIA, WWORK_MAX_DTTERVIG);

                    /*" -2437- END-EVALUATE */
                    break;
            }


            /*" -2444- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -2449- DISPLAY 'SEL V1NUMERO_AES ' V1NAES-SEQ-APOL '*SQLCODE: ' SQLCODE */

            $"SEL V1NUMERO_AES {V1NAES_SEQ_APOL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2450- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2452- DISPLAY 'R1000-00 (ERRO - SELECT V1NUMERO_AES)...' */
                _.Display($"R1000-00 (ERRO - SELECT V1NUMERO_AES)...");

                /*" -2454- DISPLAY 'ORGAO: ' WH-JV1-COD-ORGAO 'RAMO: ' V0BILH-RAMO */

                $"ORGAO: {WORK_JV1.WH_JV1_COD_ORGAO}RAMO: {V0BILH_RAMO}"
                .Display();

                /*" -2456- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2459- COMPUTE V0NAES-SEQ-APOL = V1NAES-SEQ-APOL + 1. */
            V0NAES_SEQ_APOL.Value = V1NAES_SEQ_APOL + 1;

            /*" -2461- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2463- MOVE 'S' TO WS-SIVPF. */
            _.Move("S", AREA_DE_WORK.WS_SIVPF);

            /*" -2483- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -2488- DISPLAY 'SEL FIDELIZ ' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"SEL FIDELIZ {V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2489- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2490- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2491- MOVE 'N' TO WS-SIVPF */
                    _.Move("N", AREA_DE_WORK.WS_SIVPF);

                    /*" -2493- MOVE ZEROS TO V0CONV-NUM-PROPOSTA-SIVPF */
                    _.Move(0, V0CONV_NUM_PROPOSTA_SIVPF);

                    /*" -2494- ELSE */
                }
                else
                {


                    /*" -2495- DISPLAY 'R1020-00 (ERRO - SELECT PROPOSTA_FIDELIZ)' */
                    _.Display($"R1020-00 (ERRO - SELECT PROPOSTA_FIDELIZ)");

                    /*" -2497- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  "
                    .Display();

                    /*" -2499- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2500- IF WS-SIVPF EQUAL 'N' */

            if (AREA_DE_WORK.WS_SIVPF == "N")
            {

                /*" -2502- MOVE '1021' TO WNR-EXEC-SQL */
                _.Move("1021", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

                /*" -2503- MOVE 'S' TO WS-SIVPF */
                _.Move("S", AREA_DE_WORK.WS_SIVPF);

                /*" -2508- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

                R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

                /*" -2512- DISPLAY 'SEL CONVERSAO_SICOB ' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

                $"SEL CONVERSAO_SICOB {V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
                .Display();

                /*" -2513- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2514- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2515- MOVE 'N' TO WS-SIVPF */
                        _.Move("N", AREA_DE_WORK.WS_SIVPF);

                        /*" -2517- MOVE ZEROS TO V0CONV-NUM-PROPOSTA-SIVPF */
                        _.Move(0, V0CONV_NUM_PROPOSTA_SIVPF);

                        /*" -2518- ELSE */
                    }
                    else
                    {


                        /*" -2519- DISPLAY 'R1021-00 (ERRO - SELECT CONVERSAO_SICOB)' */
                        _.Display($"R1021-00 (ERRO - SELECT CONVERSAO_SICOB)");

                        /*" -2521- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' */

                        $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  "
                        .Display();

                        /*" -2523- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2525- MOVE V0CONV-NUM-PROPOSTA-SIVPF TO WWORK-NR-PROPOSTA */
            _.Move(V0CONV_NUM_PROPOSTA_SIVPF, AREA_DE_WORK.WWORK_NR_PROPOSTA);

            /*" -2528- MOVE ZEROS TO WWORK-NUM-APOL */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_APOL);

            /*" -2529- MOVE WH-JV1-COD-ORGAO TO WWORK-ORG-APOL. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, AREA_DE_WORK.FILLER_3.WWORK_ORG_APOL);

            /*" -2530- MOVE V0BILH-RAMO TO WWORK-RMO-APOL. */
            _.Move(V0BILH_RAMO, AREA_DE_WORK.FILLER_3.WWORK_RMO_APOL);

            /*" -2531- MOVE V0NAES-SEQ-APOL TO WWORK-SEQ-APOL. */
            _.Move(V0NAES_SEQ_APOL, AREA_DE_WORK.FILLER_3.WWORK_SEQ_APOL);

            /*" -2533- MOVE WWORK-NUM-APOL TO V0APOL-NUM-APOL. */
            _.Move(AREA_DE_WORK.WWORK_NUM_APOL, V0APOL_NUM_APOL);

            /*" -2536- MOVE '1040' TO WNR-EXEC-SQL. */
            _.Move("1040", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2537- MOVE 0 TO V1BILC-COD-EMPR */
            _.Move(0, V1BILC_COD_EMPR);

            /*" -2538- MOVE V1BILP-CODPRODU TO V1BILC-CODPRODU */
            _.Move(V1BILP_CODPRODU, V1BILC_CODPRODU);

            /*" -2539- MOVE WWORK-RAMO-ANT TO V1BILC-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V1BILC_RAMOFR);

            /*" -2540- MOVE 0 TO V1BILC-MODALIFR */
            _.Move(0, V1BILC_MODALIFR);

            /*" -2542- MOVE WWORK-OPCAO-ANT TO V1BILC-OPCAO */
            _.Move(WWORK_OPCAO_ANT, V1BILC_OPCAO);

            /*" -2543- IF NOVOS-ACESSOS */

            if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
            {

                /*" -2544- MOVE LK-0071-S-VLR-TOTAL-IS TO V1BILC-IMPSEG-IX */
                _.Move(GE0071W.LK_0071_S_VLR_TOTAL_IS, V1BILC_IMPSEG_IX);

                /*" -2549- COMPUTE V1BILC-PRMTAR-IX ROUNDED = (LK-0071-S-VLR-INI-PREMIO - (LK-0071-S-VLR-INI-PREMIO * LK-0071-S-PCT-IOF / 100)) */
                V1BILC_PRMTAR_IX.Value = (GE0071W.LK_0071_S_VLR_INI_PREMIO - (GE0071W.LK_0071_S_VLR_INI_PREMIO * GE0071W.LK_0071_S_PCT_IOF / 100f));

                /*" -2550- MOVE LK-0071-S-VLR-INI-PREMIO TO V1BILC-PRMTOTAL */
                _.Move(GE0071W.LK_0071_S_VLR_INI_PREMIO, V1BILC_PRMTOTAL);

                /*" -2551- ELSE */
            }
            else
            {


                /*" -2552- MOVE '%' TO N88-VAI-LEITURA */
                _.Move("%", N88_VAI_LEITURA);

                /*" -2553- PERFORM R1005-00-SEL-V0BILHETE-COBER THRU R1005-99-SAIDA */

                R1005_00_SEL_V0BILHETE_COBER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1005_99_SAIDA*/


                /*" -2554- IF VAI-LEITURA */

                if (N88_VAI_LEITURA["VAI_LEITURA"])
                {

                    /*" -2555- GO TO R1000-00-LEITURA */

                    R1000_00_LEITURA(); //GOTO
                    return;

                    /*" -2556- END-IF */
                }


                /*" -2557- END-IF */
            }


            /*" -2558- DISPLAY 'V1BILC-IMPSEG-IX: ' V1BILC-IMPSEG-IX */
            _.Display($"V1BILC-IMPSEG-IX: {V1BILC_IMPSEG_IX}");

            /*" -2559- DISPLAY 'V1BILC-PRMTAR-IX: ' V1BILC-PRMTAR-IX */
            _.Display($"V1BILC-PRMTAR-IX: {V1BILC_PRMTAR_IX}");

            /*" -2561- DISPLAY 'V1BILC-PRMTOTAL : ' V1BILC-PRMTOTAL */
            _.Display($"V1BILC-PRMTOTAL : {V1BILC_PRMTOTAL}");

            /*" -2562- MOVE '%' TO N88-VAI-LEITURA */
            _.Move("%", N88_VAI_LEITURA);

            /*" -2564- PERFORM R3000-00-ACUMULA-BILHETE */

            R3000_00_ACUMULA_BILHETE_SECTION();

            /*" -2566- IF WWORK-NUM-ITENS EQUAL ZEROES OR VAI-LEITURA */

            if (AREA_DE_WORK.WWORK_NUM_ITENS == 00 || N88_VAI_LEITURA["VAI_LEITURA"])
            {

                /*" -2567- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -2569- END-IF */
            }


            /*" -2572- MOVE '1025' TO WNR-EXEC-SQL. */
            _.Move("1025", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2578- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -2584- DISPLAY 'UPD V0NUMERO_AES ' WH-JV1-COD-ORGAO '/' WWORK-RAMO-ANT '*SQLCODE: ' SQLCODE */

            $"UPD V0NUMERO_AES {WORK_JV1.WH_JV1_COD_ORGAO}/{WWORK_RAMO_ANT}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2585- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2587- DISPLAY 'R1025-00 (ERRO - UPDATE V0NUMERO_AES)...' */
                _.Display($"R1025-00 (ERRO - UPDATE V0NUMERO_AES)...");

                /*" -2589- DISPLAY 'ORGAO: ' WH-JV1-COD-ORGAO 'RAMO: ' WWORK-RAMO-ANT */

                $"ORGAO: {WORK_JV1.WH_JV1_COD_ORGAO}RAMO: {WWORK_RAMO_ANT}"
                .Display();

                /*" -2591- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2593- ADD +1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + +1;

            /*" -2595- ADD +1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + +1;

            /*" -2596- COMPUTE WWORK-IS-APOL = V1BILC-IMPSEG-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_IS_APOL.Value = V1BILC_IMPSEG_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -2597- COMPUTE WWORK-PR-APOL = V1BILC-PRMTAR-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_PR_APOL.Value = V1BILC_PRMTAR_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -2599- COMPUTE WWORK-PR-TOT = V1BILC-PRMTOTAL * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_PR_TOT.Value = V1BILC_PRMTOTAL * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -2601- MOVE V0BILH-CODCLIEN TO V0APOL-CODCLIEN. */
            _.Move(V0BILH_CODCLIEN, V0APOL_CODCLIEN);

            /*" -2602- MOVE WWORK-NUM-ITENS TO V0APOL-NUM-ITEM */
            _.Move(AREA_DE_WORK.WWORK_NUM_ITENS, V0APOL_NUM_ITEM);

            /*" -2604- MOVE ZEROS TO V0APOL-MODALIDA */
            _.Move(0, V0APOL_MODALIDA);

            /*" -2605- MOVE WH-JV1-COD-ORGAO TO V0APOL-ORGAO */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, V0APOL_ORGAO);

            /*" -2607- MOVE WWORK-RAMO-ANT TO V0APOL-RAMO */
            _.Move(WWORK_RAMO_ANT, V0APOL_RAMO);

            /*" -2608- IF V0BILH-NUM-APO-ANT GREATER 0 */

            if (V0BILH_NUM_APO_ANT > 0)
            {

                /*" -2609- PERFORM R3270-00-SELECT-APOLICE-ANT */

                R3270_00_SELECT_APOLICE_ANT_SECTION();

                /*" -2610- MOVE V1APOL-NUM-APOL TO V0APOL-NUM-APO-ANT */
                _.Move(V1APOL_NUM_APOL, V0APOL_NUM_APO_ANT);

                /*" -2611- ELSE */
            }
            else
            {


                /*" -2613- MOVE 0 TO V0APOL-NUM-APO-ANT. */
                _.Move(0, V0APOL_NUM_APO_ANT);
            }


            /*" -2614- MOVE '1' TO V0APOL-TIPSGU */
            _.Move("1", V0APOL_TIPSGU);

            /*" -2615- MOVE '2' TO V0APOL-TIPAPO */
            _.Move("2", V0APOL_TIPAPO);

            /*" -2616- MOVE '3' TO V0APOL-TIPCALC */
            _.Move("3", V0APOL_TIPCALC);

            /*" -2617- MOVE 'N' TO V0APOL-PODPUBL */
            _.Move("N", V0APOL_PODPUBL);

            /*" -2618- MOVE ZEROS TO V0APOL-NUM-ATA */
            _.Move(0, V0APOL_NUM_ATA);

            /*" -2619- MOVE ZEROS TO V0APOL-ANO-ATA */
            _.Move(0, V0APOL_ANO_ATA);

            /*" -2620- MOVE SPACES TO V0APOL-IDEMAN */
            _.Move("", V0APOL_IDEMAN);

            /*" -2622- MOVE ZEROS TO V0APOL-PCDESCON */
            _.Move(0, V0APOL_PCDESCON);

            /*" -2623- MOVE ZEROS TO V0APOL-PCTCED */
            _.Move(0, V0APOL_PCTCED);

            /*" -2624- MOVE '0' TO V0APOL-TPCOSCED */
            _.Move("0", V0APOL_TPCOSCED);

            /*" -2625- MOVE ZEROS TO V0APOL-QTCOSSEG */
            _.Move(0, V0APOL_QTCOSSEG);

            /*" -2627- MOVE ZEROS TO V0APOL-COD-EMPRESA */
            _.Move(0, V0APOL_COD_EMPRESA);

            /*" -2629- MOVE '2' TO V0APOL-TPCORRET. */
            _.Move("2", V0APOL_TPCORRET);

            /*" -2632- IF NOVOS-ACESSOS */

            if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
            {

                /*" -2635- MOVE 001 TO V1BILC-CODUNIMO */
                _.Move(001, V1BILC_CODUNIMO);

                /*" -2636- MOVE 1,00 TO V1BILC-VALMAX */
                _.Move(1.00, V1BILC_VALMAX);

                /*" -2637- ELSE */
            }
            else
            {


                /*" -2639- PERFORM R1010-00-SEL-V0BILHETE-COBER2 THRU R1010-99-SAIDA */

                R1010_00_SEL_V0BILHETE_COBER2_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/


                /*" -2640- END-IF */
            }


            /*" -2643- DISPLAY 'V1BILC-CODUNIMO : ' V1BILC-CODUNIMO */
            _.Display($"V1BILC-CODUNIMO : {V1BILC_CODUNIMO}");

            /*" -2647- DISPLAY 'V1BILC-VALMAX   : ' V1BILC-VALMAX */
            _.Display($"V1BILC-VALMAX   : {V1BILC_VALMAX}");

            /*" -2655- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

            /*" -2661- DISPLAY 'SEL RAMO_COMPLEMENTAR ' V1BILC-RAMOFR '/' V0BILH-DTQITBCO '*SQLCODE: ' SQLCODE */

            $"SEL RAMO_COMPLEMENTAR {V1BILC_RAMOFR}/{V0BILH_DTQITBCO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2662- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2663- DISPLAY 'R1070-00 (ERRO - SELECT RAMOCOMP)          ' */
                _.Display($"R1070-00 (ERRO - SELECT RAMOCOMP)          ");

                /*" -2665- DISPLAY 'RAMO: ' V1BILC-RAMOFR '  ' 'DATA: ' V0BILH-DTQITBCO */

                $"RAMO: {V1BILC_RAMOFR}  DATA: {V0BILH_DTQITBCO}"
                .Display();

                /*" -2666- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2668- END-IF */
            }


            /*" -2675- MOVE RAMOCOMP-PCT-IOCC-RAMO TO V1BILC-PCIOCC */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO, V1BILC_PCIOCC);

            /*" -2678- COMPUTE WWORK-IOCC ROUNDED = WWORK-PR-TOT * V1BILC-PCIOCC / 100 */
            AREA_DE_WORK.WWORK_IOCC.Value = AREA_DE_WORK.WWORK_PR_TOT * V1BILC_PCIOCC / 100f;

            /*" -2680- COMPUTE WWORK-PR-APOL = WWORK-PR-TOT - WWORK-IOCC */
            AREA_DE_WORK.WWORK_PR_APOL.Value = AREA_DE_WORK.WWORK_PR_TOT - AREA_DE_WORK.WWORK_IOCC;

            /*" -2682- MOVE WWORK-PR-APOL TO V1BILC-PRMTAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V1BILC_PRMTAR_IX);

            /*" -2684- MOVE V1BILC-PCIOCC TO V0APOL-PCIOCC */
            _.Move(V1BILC_PCIOCC, V0APOL_PCIOCC);

            /*" -2686- MOVE ' ' TO WTEM-PROPESTIP */
            _.Move(" ", AREA_DE_WORK.WTEM_PROPESTIP);

            /*" -2694- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

            /*" -2699- DISPLAY 'SEL V0PROP_ESTIPULANTE ' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"SEL V0PROP_ESTIPULANTE {V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2700- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2701- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2702- MOVE 'N' TO WTEM-PROPESTIP */
                    _.Move("N", AREA_DE_WORK.WTEM_PROPESTIP);

                    /*" -2703- ELSE */
                }
                else
                {


                    /*" -2704- DISPLAY 'R1070-00 (ERRO - SELECT V0PROP_ESTIPULANTE).' */
                    _.Display($"R1070-00 (ERRO - SELECT V0PROP_ESTIPULANTE).");

                    /*" -2707- DISPLAY 'EMPR: ' V1BILC-COD-EMPR '  ' 'PROD: ' V1BILC-CODPRODU '  ' 'BILH: ' V0BILH-NUMBIL */

                    $"EMPR: {V1BILC_COD_EMPR}  PROD: {V1BILC_CODPRODU}  BILH: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -2708- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2709- END-IF */
                }


                /*" -2710- ELSE */
            }
            else
            {


                /*" -2711- MOVE 'S' TO WTEM-PROPESTIP */
                _.Move("S", AREA_DE_WORK.WTEM_PROPESTIP);

                /*" -2713- END-IF */
            }


            /*" -2715- IF WTEM-PROPESTIP EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PROPESTIP == "S")
            {

                /*" -2716- MOVE 8202 TO V0APOL-CODPRODU */
                _.Move(8202, V0APOL_CODPRODU);

                /*" -2717- ELSE */
            }
            else
            {


                /*" -2718- MOVE V1BILP-CODPRODU TO V0APOL-CODPRODU */
                _.Move(V1BILP_CODPRODU, V0APOL_CODPRODU);

                /*" -2720- END-IF */
            }


            /*" -2723- MOVE '1065' TO WNR-EXEC-SQL */
            _.Move("1065", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2775- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_1();

            /*" -2781- DISPLAY 'INS V0APOLICE ' V0APOL-CODCLIEN '/' V0APOL-NUM-APOL '*SQLCODE: ' SQLCODE */

            $"INS V0APOLICE {V0APOL_CODCLIEN}/{V0APOL_NUM_APOL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2782- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2783- DISPLAY 'R1065-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"R1065-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -2785- DISPLAY 'APOLICE: ' V0APOL-NUM-APOL '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APOL_NUM_APOL}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2786- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2788- END-IF */
            }


            /*" -2790- ADD +1 TO AC-I-V0APOLICE */
            AREA_DE_WORK.AC_I_V0APOLICE.Value = AREA_DE_WORK.AC_I_V0APOLICE + +1;

            /*" -2791- MOVE V0APOL-NUM-APOL TO V0ENDO-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0ENDO_NUM_APOL);

            /*" -2793- MOVE ZEROS TO V0ENDO-NRENDOS WWORK-NRENDOS */
            _.Move(0, V0ENDO_NRENDOS, AREA_DE_WORK.WWORK_NRENDOS);

            /*" -2794- MOVE ZEROS TO V0ENDO-CODSUBES */
            _.Move(0, V0ENDO_CODSUBES);

            /*" -2795- MOVE V0BILH-FONTE TO V0ENDO-FONTE */
            _.Move(V0BILH_FONTE, V0ENDO_FONTE);

            /*" -2796- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -2797- MOVE V1SIST-DTMOVACB TO V0ENDO-DT-LIBER */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DT_LIBER);

            /*" -2799- MOVE V1SIST-DTMOVACB TO V0ENDO-DTEMIS */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DTEMIS);

            /*" -2801- MOVE 104 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR */
            _.Move(104, V0ENDO_BCORCAP, V0ENDO_BCOCOBR);

            /*" -2802- MOVE V0BILH-AGECOBR TO V0ENDO-AGERCAP */
            _.Move(V0BILH_AGECOBR, V0ENDO_AGERCAP);

            /*" -2803- MOVE V1RCAC-AGEAVISO TO V0ENDO-AGECOBR */
            _.Move(V1RCAC_AGEAVISO, V0ENDO_AGECOBR);

            /*" -2805- MOVE '0' TO V0ENDO-DACCOBR */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -2806- MOVE WWORK-NRRCAP TO V0ENDO-NRRCAP */
            _.Move(AREA_DE_WORK.FILLER_5.WWORK_NRRCAP, V0ENDO_NRRCAP);

            /*" -2807- MOVE V0BILH-VLRCAP TO V0ENDO-VLRCAP */
            _.Move(V0BILH_VLRCAP, V0ENDO_VLRCAP);

            /*" -2808- MOVE '0' TO V0ENDO-DACRCAP */
            _.Move("0", V0ENDO_DACRCAP);

            /*" -2809- MOVE '0' TO V0ENDO-IDRCAP */
            _.Move("0", V0ENDO_IDRCAP);

            /*" -2810- MOVE V0BILH-DTQITBCO TO V0ENDO-DATARCAP */
            _.Move(V0BILH_DTQITBCO, V0ENDO_DATARCAP);

            /*" -2812- MOVE +0 TO VIND-DATARCAP */
            _.Move(+0, VIND_DATARCAP);

            /*" -2813- MOVE WWORK-MIN-DTINIVIG TO V0ENDO-DTINIVIG */
            _.Move(WWORK_MIN_DTINIVIG, V0ENDO_DTINIVIG);

            /*" -2814- MOVE WWORK-MIN-DTINIVIG TO V0ENDO-DATPRO */
            _.Move(WWORK_MIN_DTINIVIG, V0ENDO_DATPRO);

            /*" -2816- MOVE WWORK-MAX-DTTERVIG TO V0ENDO-DTTERVIG */
            _.Move(WWORK_MAX_DTTERVIG, V0ENDO_DTTERVIG);

            /*" -2817- MOVE ZEROS TO V0ENDO-PCENTRAD */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -2818- MOVE ZEROS TO V0ENDO-PCADICIO */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -2819- MOVE ZEROS TO V0ENDO-PRESTA1 */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -2820- MOVE ZEROS TO V0ENDO-QTPARCEL */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -2821- MOVE ZEROS TO V0ENDO-CDFRACIO */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -2822- MOVE ZEROS TO V0ENDO-QTPRESTA */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -2823- MOVE 1 TO V0ENDO-QTITENS */
            _.Move(1, V0ENDO_QTITENS);

            /*" -2824- MOVE SPACES TO V0ENDO-CODTXT */
            _.Move("", V0ENDO_CODTXT);

            /*" -2826- MOVE ZEROS TO V0ENDO-CDACEITA */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -2829- MOVE V1BILC-CODUNIMO TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM */
            _.Move(V1BILC_CODUNIMO, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -2830- MOVE '0' TO V0ENDO-TIPO-ENDO */
            _.Move("0", V0ENDO_TIPO_ENDO);

            /*" -2832- MOVE 'CB0005B' TO V0ENDO-COD-USUAR */
            _.Move("CB0005B", V0ENDO_COD_USUAR);

            /*" -2834- MOVE 1 TO V0ENDO-OCORR-END */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -2836- MOVE '1' TO V0ENDO-SITUACAO */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -2837- MOVE ZEROS TO V0ENDO-COD-EMPRESA */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -2838- MOVE '1' TO V0ENDO-CORRECAO */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -2839- MOVE 'S' TO V0ENDO-ISENTA-CST */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -2840- MOVE -1 TO VIND-DTVENCTO */
            _.Move(-1, VIND_DTVENCTO);

            /*" -2842- MOVE -1 TO VIND-VLCUSEMI */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -2844- MOVE -1 TO VIND-CFPREFIX */
            _.Move(-1, VIND_CFPREFIX);

            /*" -2845- MOVE V0APOL-RAMO TO V0ENDO-RAMO */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -2848- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -2850- PERFORM R5000-00-INSERE-ENDOSSO */

            R5000_00_INSERE_ENDOSSO_SECTION();

            /*" -2851- IF NOVOS-ACESSOS */

            if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
            {

                /*" -2852- PERFORM R1030-00-INS-HIS-COBER-PROP */

                R1030_00_INS_HIS_COBER_PROP_SECTION();

                /*" -2854- END-IF */
            }


            /*" -2857- MOVE 0 TO WS-IND-CORRETOR */
            _.Move(0, WS_IND_CORRETOR);

            /*" -2859- IF WS-PROD-RUNON AND V1SIST-DTMOVACB >= '2021-08-16' */

            if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] && V1SIST_DTMOVACB >= "2021-08-16")
            {

                /*" -2860- MOVE 1 TO WS-IND-CORRETOR */
                _.Move(1, WS_IND_CORRETOR);

                /*" -2862- END-IF */
            }


            /*" -2866- DISPLAY 'R1000-00-PROCESSA-REGISTRO ' '<NUM-APOLICE=' V0APOL-NUM-APOL '>' '<COD-PRODUTO=' V1BILP-CODPRODU '>' */

            $"R1000-00-PROCESSA-REGISTRO <NUM-APOLICE={V0APOL_NUM_APOL}><COD-PRODUTO={V1BILP_CODPRODU}>"
            .Display();

            /*" -2875- IF V1BILP-CODPRODU EQUAL 8144 OR 8145 OR 8146 OR 8147 OR 8148 OR 8149 OR 8150 OR 8530 OR JVPRD8144 OR JVPRD8145 OR JVPRD8146 OR JVPRD8147 OR JVPRD8148 OR JVPRD8149 OR JVPRD8150 OR 3729 */

            if (V1BILP_CODPRODU.In("8144", "8145", "8146", "8147", "8148", "8149", "8150", "8530", JVBKINCL.JV_PRODUTOS.JVPRD8144.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8145.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8146.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8147.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8148.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8149.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8150.ToString(), "3729"))
            {

                /*" -2877- PERFORM R7000-00-PROCESSA-MENSAL */

                R7000_00_PROCESSA_MENSAL_SECTION();

                /*" -2878- PERFORM R7500-00-TRATAR-APOL-CORRETOR */

                R7500_00_TRATAR_APOL_CORRETOR_SECTION();

                /*" -2880- ELSE */
            }
            else
            {


                /*" -2882- PERFORM R6000-00-PROCESSA-ANUAL */

                R6000_00_PROCESSA_ANUAL_SECTION();

                /*" -2883- PERFORM R1066-00-TRATA-EVOGEPES016 */

                R1066_00_TRATA_EVOGEPES016_SECTION();

                /*" -2891- END-IF */
            }


            /*" -2891- . */

            /*" -0- FLUXCONTROL_PERFORM R1000_15_FIM */

            R1000_15_FIM();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -2444- EXEC SQL SELECT SEQ_APOLICE INTO :V1NAES-SEQ-APOL FROM SEGUROS.V1NUMERO_AES WHERE COD_ORGAO = :WH-JV1-COD-ORGAO AND COD_RAMO = :V0BILH-RAMO END-EXEC */

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
        /*" R1000-15-FIM */
        private void R1000_15_FIM(bool isPerform = false)
        {
            /*" -2896- IF NOVOS-ACESSOS */

            if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
            {

                /*" -2897- IF LK-0070-S-IND-ACOPLADO EQUAL 'S' */

                if (GE0070W.LK_0070_S_IND_ACOPLADO == "S")
                {

                    /*" -2898- PERFORM R4280-00-TRATA-FC0105S */

                    R4280_00_TRATA_FC0105S_SECTION();

                    /*" -2899- END-IF */
                }


                /*" -2900- ELSE */
            }
            else
            {


                /*" -2901- IF V1BILC-VALMAX GREATER ZEROS */

                if (V1BILC_VALMAX > 00)
                {

                    /*" -2902- PERFORM R4280-00-TRATA-FC0105S */

                    R4280_00_TRATA_FC0105S_SECTION();

                    /*" -2903- END-IF */
                }


                /*" -2917- END-IF */
            }


            /*" -2918- IF WWORK-FUNDAO EQUAL 'S' */

            if (AREA_DE_WORK.WWORK_FUNDAO == "S")
            {

                /*" -2919- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -2921- END-IF */
            }


            /*" -2921- . */

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -2483- EXEC SQL SELECT NUM_SICOB, SIT_PROPOSTA, NUM_PROPOSTA_SIVPF, COD_PRODUTO_SIVPF, ORIGEM_PROPOSTA DIA_DEBITO, DTQITBCO, OPCAO_COBER INTO :V0CONV-NUM-SICOB, :V0SIVPF-SIT-PROPOSTA, :V0CONV-NUM-PROPOSTA-SIVPF, :PRPFIDEL-COD-PROD-SIVPF, :PRPFIDEL-ORIG-PROPOSTA :PRPFIDEL-DIA-DEBITO, :PROPOFID-DTQITBCO, :PROPOFID-OPCAO-COBER FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :V0BILH-NUMBIL AND COD_PRODUTO_SIVPF IN (09,10,29,56) END-EXEC */

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
                _.Move(executed_1.PRPFIDEL_COD_PROD_SIVPF, PRPFIDEL_COD_PROD_SIVPF);
                _.Move(executed_1.PRPFIDEL_ORIG_PROPOSTA, PRPFIDEL_ORIG_PROPOSTA);
                _.Move(executed_1.PRPFIDEL_DIA_DEBITO, PRPFIDEL_DIA_DEBITO);
                _.Move(executed_1.PROPOFID_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                _.Move(executed_1.PROPOFID_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -2578- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET SEQ_APOLICE = :V0NAES-SEQ-APOL WHERE COD_ORGAO = :WH-JV1-COD-ORGAO AND COD_RAMO = :WWORK-RAMO-ANT END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0NAES_SEQ_APOL = V0NAES_SEQ_APOL.ToString(),
                WH_JV1_COD_ORGAO = WORK_JV1.WH_JV1_COD_ORGAO.ToString(),
                WWORK_RAMO_ANT = WWORK_RAMO_ANT.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-LEITURA */
        private void R1000_00_LEITURA(bool isPerform = false)
        {
            /*" -2926- IF WS-I-ERRO > ZEROS */

            if (WS_I_ERRO > 00)
            {

                /*" -2927- MOVE 'S' TO WS-FLAG-TEM-ERRO */
                _.Move("S", WS_FLAG_TEM_ERRO);

                /*" -2929- MOVE 1 TO WS-I-ERRO */
                _.Move(1, WS_I_ERRO);

                /*" -2931- PERFORM R3050-00-INSERE-ERRO UNTIL WS-FLAG-TEM-ERRO EQUAL 'N' */

                while (!(WS_FLAG_TEM_ERRO == "N"))
                {

                    R3050_00_INSERE_ERRO_SECTION();
                }

                /*" -2933- END-IF */
            }


            /*" -2934- IF WS-SIVPF EQUAL 'S' */

            if (AREA_DE_WORK.WS_SIVPF == "S")
            {

                /*" -2935- IF V0BILH-SITUACAO EQUAL '9' */

                if (V0BILH_SITUACAO == "9")
                {

                    /*" -2936- MOVE 'EMT' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("EMT", WHOST_SIT_PROP_SIVPF);

                    /*" -2937- ELSE */
                }
                else
                {


                    /*" -2938- MOVE 'PEN' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("PEN", WHOST_SIT_PROP_SIVPF);

                    /*" -2940- END-IF */
                }


                /*" -2942- IF V0SIVPF-SIT-PROPOSTA EQUAL WHOST-SIT-PROP-SIVPF NEXT SENTENCE */

                if (V0SIVPF_SIT_PROPOSTA == WHOST_SIT_PROP_SIVPF)
                {

                    /*" -2943- ELSE */
                }
                else
                {


                    /*" -2945- MOVE '2060' TO WNR-EXEC-SQL */
                    _.Move("2060", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

                    /*" -2952- PERFORM R1000_00_LEITURA_DB_UPDATE_1 */

                    R1000_00_LEITURA_DB_UPDATE_1();

                    /*" -2956- DISPLAY 'UPD FIDELIZ ' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

                    $"UPD FIDELIZ {V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
                    .Display();

                    /*" -2957- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -2959- DISPLAY 'PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ) ' ' ' V0BILH-NUMBIL */

                        $"PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ)  {V0BILH_NUMBIL}"
                        .Display();

                        /*" -2961- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2962- IF V0BILH-RAMO EQUAL 82 */

            if (V0BILH_RAMO == 82)
            {

                /*" -2963- IF V0BILH-SITUACAO EQUAL '9' */

                if (V0BILH_SITUACAO == "9")
                {

                    /*" -2964- ADD 1 TO GELMR-QTD-SEGUROS */
                    GELMR_QTD_SEGUROS.Value = GELMR_QTD_SEGUROS + 1;

                    /*" -2965- IF WTEM-GELMR EQUAL 'SIM' */

                    if (AREA_DE_WORK.WTEM_GELMR == "SIM")
                    {

                        /*" -2966- PERFORM R1400-00-UPDATE-GELIMRISCO */

                        R1400_00_UPDATE_GELIMRISCO_SECTION();

                        /*" -2967- ELSE */
                    }
                    else
                    {


                        /*" -2969- PERFORM R1500-00-INSERT-GELIMRISCO. */

                        R1500_00_INSERT_GELIMRISCO_SECTION();
                    }

                }

            }


            /*" -2969- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

        }

        [StopWatch]
        /*" R1000-00-LEITURA-DB-UPDATE-1 */
        public void R1000_00_LEITURA_DB_UPDATE_1()
        {
            /*" -2952- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROP-SIVPF, SITUACAO_ENVIO = 'S' , COD_USUARIO = 'CB0005B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_SICOB = :V0BILH-NUMBIL END-EXEC */

            var r1000_00_LEITURA_DB_UPDATE_1_Update1 = new R1000_00_LEITURA_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROP_SIVPF = WHOST_SIT_PROP_SIVPF.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R1000_00_LEITURA_DB_UPDATE_1_Update1.Execute(r1000_00_LEITURA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -2508- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :V0CONV-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :V0BILH-NUMBIL END-EXEC */

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
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_1()
        {
            /*" -2775- EXEC SQL INSERT INTO SEGUROS.V0APOLICE (CODCLIEN , NUM_APOLICE , NUM_ITEM , MODALIDA , ORGAO , RAMO , NUM_APOL_ANTERIOR , NUMBIL , TIPSGU , TIPAPO , TIPCALC , PODPUBL , NUM_ATA , ANO_ATA , IDEMAN , PCDESCON , PCIOCC , TPCOSCED , QTCOSSEG , PCTCED , DATA_SORTEIO , COD_EMPRESA , TIMESTAMP , CODPRODU , TPCORRET) VALUES (:V0APOL-CODCLIEN , :V0APOL-NUM-APOL , :V0APOL-NUM-ITEM , :V0APOL-MODALIDA , :V0APOL-ORGAO , :V0APOL-RAMO , :V0APOL-NUM-APO-ANT , :V0APOL-NUMBIL , :V0APOL-TIPSGU , :V0APOL-TIPAPO , :V0APOL-TIPCALC , :V0APOL-PODPUBL , :V0APOL-NUM-ATA , :V0APOL-ANO-ATA , :V0APOL-IDEMAN , :V0APOL-PCDESCON , :V0APOL-PCIOCC , :V0APOL-TPCOSCED , :V0APOL-QTCOSSEG , :V0APOL-PCTCED , NULL , :V0APOL-COD-EMPRESA , CURRENT TIMESTAMP , :V0APOL-CODPRODU , :V0APOL-TPCORRET) END-EXEC */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -2655- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :V1BILC-RAMOFR AND DATA_INIVIGENCIA <= :V0BILH-DTQITBCO AND DATA_TERVIGENCIA >= :V0BILH-DTQITBCO WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }

        [StopWatch]
        /*" R1005-00-SEL-V0BILHETE-COBER-SECTION */
        private void R1005_00_SEL_V0BILHETE_COBER_SECTION()
        {
            /*" -2979- MOVE '1005' TO WNR-EXEC-SQL */
            _.Move("1005", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2982- DISPLAY 'R1005-00-SEL-V0BILHETE-COBER' */
            _.Display($"R1005-00-SEL-V0BILHETE-COBER");

            /*" -2996- PERFORM R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1 */

            R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1();

            /*" -3005- DISPLAY 'SEL V0BILHETE_COBER(1) ' V1BILC-RAMOFR '/' V1BILC-MODALIFR '/' V1BILC-OPCAO '/' V0BILH-DTQITBCO '/' V1BILC-CODPRODU '*SQLCODE: ' SQLCODE */

            $"SEL V0BILHETE_COBER(1) {V1BILC_RAMOFR}/{V1BILC_MODALIFR}/{V1BILC_OPCAO}/{V0BILH_DTQITBCO}/{V1BILC_CODPRODU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3006- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3007- MOVE 1503 TO V0BILER-COD-ERRO */
                _.Move(1503, V0BILER_COD_ERRO);

                /*" -3008- PERFORM R3045-00-GRAVA-TAB-ERRO */

                R3045_00_GRAVA_TAB_ERRO_SECTION();

                /*" -3009- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -3010- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -3011- DISPLAY 'R1040-00 (ERRO SELECT V1BILCOBER)' */
                _.Display($"R1040-00 (ERRO SELECT V1BILCOBER)");

                /*" -3012- DISPLAY 'PROPOSTA      : ' V0CONV-NUM-PROPOSTA-SIVPF */
                _.Display($"PROPOSTA      : {V0CONV_NUM_PROPOSTA_SIVPF}");

                /*" -3013- DISPLAY 'BILHETE       : ' V0BILH-NUMBIL */
                _.Display($"BILHETE       : {V0BILH_NUMBIL}");

                /*" -3014- DISPLAY 'COD_EMPRESA   : ' V1BILC-COD-EMPR */
                _.Display($"COD_EMPRESA   : {V1BILC_COD_EMPR}");

                /*" -3015- DISPLAY 'RAMOFR        : ' V1BILC-RAMOFR */
                _.Display($"RAMOFR        : {V1BILC_RAMOFR}");

                /*" -3016- DISPLAY 'MODALIFR      : ' V1BILC-MODALIFR */
                _.Display($"MODALIFR      : {V1BILC_MODALIFR}");

                /*" -3017- DISPLAY 'COD_OPCAO     : ' V1BILC-OPCAO */
                _.Display($"COD_OPCAO     : {V1BILC_OPCAO}");

                /*" -3018- DISPLAY 'DTINIVIG      : ' WWORK-MIN-DTINIVIG */
                _.Display($"DTINIVIG      : {WWORK_MIN_DTINIVIG}");

                /*" -3019- DISPLAY 'DTTERVIG      : ' WWORK-MAX-DTTERVIG */
                _.Display($"DTTERVIG      : {WWORK_MAX_DTTERVIG}");

                /*" -3020- DISPLAY 'DATA_QUITACAO : ' V0BILH-DTQITBCO */
                _.Display($"DATA_QUITACAO : {V0BILH_DTQITBCO}");

                /*" -3021- DISPLAY 'CODPRODU      : ' V1BILC-CODPRODU */
                _.Display($"CODPRODU      : {V1BILC_CODPRODU}");

                /*" -3022- MOVE 'S' TO N88-VAI-LEITURA */
                _.Move("S", N88_VAI_LEITURA);

                /*" -3024- GO TO R1005-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1005_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3025- IF VIND-PRMTOTAL LESS ZEROS */

            if (VIND_PRMTOTAL < 00)
            {

                /*" -3026- MOVE V0BILH-VLRCAP TO V1BILC-PRMTOTAL */
                _.Move(V0BILH_VLRCAP, V1BILC_PRMTOTAL);

                /*" -3027- ELSE */
            }
            else
            {


                /*" -3028- IF V1BILC-PRMTOTAL EQUAL ZEROS */

                if (V1BILC_PRMTOTAL == 00)
                {

                    /*" -3028- MOVE V0BILH-VLRCAP TO V1BILC-PRMTOTAL. */
                    _.Move(V0BILH_VLRCAP, V1BILC_PRMTOTAL);
                }

            }


        }

        [StopWatch]
        /*" R1005-00-SEL-V0BILHETE-COBER-DB-SELECT-1 */
        public void R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1()
        {
            /*" -2996- EXEC SQL SELECT SUM(VAL_COBERTURA_IX), SUM(PRM_TARIFARIO_IX), SUM(VLPRMTOT) INTO :V1BILC-IMPSEG-IX, :V1BILC-PRMTAR-IX, :V1BILC-PRMTOTAL:VIND-PRMTOTAL FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO AND CODPRODU = :V1BILC-CODPRODU END-EXEC. */

            var r1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1 = new R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V1BILC_CODPRODU = V1BILC_CODPRODU.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
                V1BILC_OPCAO = V1BILC_OPCAO.ToString(),
            };

            var executed_1 = R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1.Execute(r1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_IMPSEG_IX, V1BILC_IMPSEG_IX);
                _.Move(executed_1.V1BILC_PRMTAR_IX, V1BILC_PRMTAR_IX);
                _.Move(executed_1.V1BILC_PRMTOTAL, V1BILC_PRMTOTAL);
                _.Move(executed_1.VIND_PRMTOTAL, VIND_PRMTOTAL);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_5()
        {
            /*" -2694- EXEC SQL SELECT COD_PRODUTO INTO :V0PROE-CODPRODU FROM SEGUROS.V0PROP_ESTIPULANTE WHERE NUMBIL = :V0BILH-NUMBIL AND FONTE = 0 AND NUM_PROPOSTA = 0 AND COD_FROTA = '0' END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROE_CODPRODU, V0PROE_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1005_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SEL-V0BILHETE-COBER2-SECTION */
        private void R1010_00_SEL_V0BILHETE_COBER2_SECTION()
        {
            /*" -3039- MOVE '1010' TO WNR-EXEC-SQL */
            _.Move("1010", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3041- DISPLAY 'R1010-00-SEL-V0BILHETE-COBER2' */
            _.Display($"R1010-00-SEL-V0BILHETE-COBER2");

            /*" -3061- PERFORM R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1 */

            R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1();

            /*" -3070- DISPLAY 'SEL V0BILHETE_COBER (2) ' V1BILC-RAMOFR '/' V1BILC-MODALIFR '/' V1BILC-OPCAO '/' V0BILH-DTQITBCO '/' V1BILP-CODPRODU '*SQLCODE: ' SQLCODE */

            $"SEL V0BILHETE_COBER (2) {V1BILC_RAMOFR}/{V1BILC_MODALIFR}/{V1BILC_OPCAO}/{V0BILH_DTQITBCO}/{V1BILP_CODPRODU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3071- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3072- DISPLAY 'R1070-00 (ERRO - SELECT V0BILHETE_COBER)...' */
                _.Display($"R1070-00 (ERRO - SELECT V0BILHETE_COBER)...");

                /*" -3080- DISPLAY 'EMPR: ' V1BILC-COD-EMPR '  ' 'PROD: ' V1BILC-CODPRODU '  ' 'RAMO: ' V1BILC-RAMOFR '  ' 'MODA: ' V1BILC-MODALIFR '  ' 'OPCA: ' V1BILC-OPCAO '  ' 'DAT1: ' V0ENDO-DTINIVIG '  ' 'DAT2: ' V0ENDO-DTTERVIG '  ' 'QUITACAO: ' V0BILH-DTQITBCO */

                $"EMPR: {V1BILC_COD_EMPR}  PROD: {V1BILC_CODPRODU}  RAMO: {V1BILC_RAMOFR}  MODA: {V1BILC_MODALIFR}  OPCA: {V1BILC_OPCAO}  DAT1: {V0ENDO_DTINIVIG}  DAT2: {V0ENDO_DTTERVIG}  QUITACAO: {V0BILH_DTQITBCO}"
                .Display();

                /*" -3082- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3083- IF V0BILH-DTQITBCO > '2004-08-31' */

            if (V0BILH_DTQITBCO > "2004-08-31")
            {

                /*" -3085- MOVE 4 TO V1BILC-PCIOCC. */
                _.Move(4, V1BILC_PCIOCC);
            }


            /*" -3086- IF V0BILH-DTQITBCO > '2005-08-31' */

            if (V0BILH_DTQITBCO > "2005-08-31")
            {

                /*" -3088- MOVE 2 TO V1BILC-PCIOCC. */
                _.Move(2, V1BILC_PCIOCC);
            }


            /*" -3089- IF V0BILH-DTQITBCO > '2006-08-31' */

            if (V0BILH_DTQITBCO > "2006-08-31")
            {

                /*" -3089- MOVE 0 TO V1BILC-PCIOCC. */
                _.Move(0, V1BILC_PCIOCC);
            }


        }

        [StopWatch]
        /*" R1010-00-SEL-V0BILHETE-COBER2-DB-SELECT-1 */
        public void R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1()
        {
            /*" -3061- EXEC SQL SELECT CODUNIMO, PCCOMCOR, PCIOCC, VALMAX_COBERBAS INTO :V1BILC-CODUNIMO, :V1BILC-PCCOMCOR, :V1BILC-PCIOCC, :V1BILC-VALMAX FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO AND CODPRODU = :V1BILP-CODPRODU END-EXEC. */

            var r1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1 = new R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V1BILP_CODPRODU = V1BILP_CODPRODU.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
                V1BILC_OPCAO = V1BILC_OPCAO.ToString(),
            };

            var executed_1 = R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1.Execute(r1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_CODUNIMO, V1BILC_CODUNIMO);
                _.Move(executed_1.V1BILC_PCCOMCOR, V1BILC_PCCOMCOR);
                _.Move(executed_1.V1BILC_PCIOCC, V1BILC_PCIOCC);
                _.Move(executed_1.V1BILC_VALMAX, V1BILC_VALMAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-INS-HIS-COBER-PROP-SECTION */
        private void R1030_00_INS_HIS_COBER_PROP_SECTION()
        {
            /*" -3100- MOVE '1030' TO WNR-EXEC-SQL */
            _.Move("1030", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3103- DISPLAY 'R1030-00-INS-HIS-COBER-PROP ' */
            _.Display($"R1030-00-INS-HIS-COBER-PROP ");

            /*" -3104- MOVE LK-0071-S-VLR-TOTAL-IS TO WS-CPO-VLR-AUX */
            _.Move(GE0071W.LK_0071_S_VLR_TOTAL_IS, WS_CPO_VLR_AUX);

            /*" -3106- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO WS-CPO-SEQ-AUX */
            _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, WS_CPO_SEQ_AUX);

            /*" -3107- IF V0ENDO-CODPRODU EQUAL 3729 */

            if (V0ENDO_CODPRODU == 3729)
            {

                /*" -3108- MOVE WWORK-MAX-DTTERVIG TO WS-TER-VIG-HCP */
                _.Move(WWORK_MAX_DTTERVIG, WS_TER_VIG_HCP);

                /*" -3109- ELSE */
            }
            else
            {


                /*" -3110- MOVE '9999-12-31' TO WS-TER-VIG-HCP */
                _.Move("9999-12-31", WS_TER_VIG_HCP);

                /*" -3112- END-IF */
            }


            /*" -3146- PERFORM R1030_00_INS_HIS_COBER_PROP_DB_INSERT_1 */

            R1030_00_INS_HIS_COBER_PROP_DB_INSERT_1();

            /*" -3151- DISPLAY 'INS HIS_COBER_PROPOST ' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"INS HIS_COBER_PROPOST {V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3152- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -3153- DISPLAY 'R1030-00-INS-HIS-COBER-PROP' */
                _.Display($"R1030-00-INS-HIS-COBER-PROP");

                /*" -3154- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -3155- DISPLAY 'SQLCODE: ' SQLCODE */
                _.Display($"SQLCODE: {DB.SQLCODE}");

                /*" -3156- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3158- END-IF */
            }


            /*" -3158- . */

        }

        [StopWatch]
        /*" R1030-00-INS-HIS-COBER-PROP-DB-INSERT-1 */
        public void R1030_00_INS_HIS_COBER_PROP_DB_INSERT_1()
        {
            /*" -3146- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST VALUES (:V0BILH-NUMBIL , 1 , :PROPOFID-DTQITBCO , :WS-TER-VIG-HCP , :WS-CPO-VLR-AUX , 1 , :WS-CPO-VLR-AUX , 106 , :PROPOFID-OPCAO-COBER , :WS-CPO-VLR-AUX , :WS-CPO-VLR-AUX , :WS-CPO-VLR-AUX , 0 , 0 , 0 , :V0BILH-VLRCAP , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 'CB0005B' , CURRENT TIMESTAMP , 0 , 0 , 0 , 0 , :V1BILP-CODPRODU , :WS-CPO-SEQ-AUX , NULL ) END-EXEC */

            var r1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1 = new R1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WS_TER_VIG_HCP = WS_TER_VIG_HCP.ToString(),
                WS_CPO_VLR_AUX = WS_CPO_VLR_AUX.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                V0BILH_VLRCAP = V0BILH_VLRCAP.ToString(),
                V1BILP_CODPRODU = V1BILP_CODPRODU.ToString(),
                WS_CPO_SEQ_AUX = WS_CPO_SEQ_AUX.ToString(),
            };

            R1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1.Execute(r1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1066-00-TRATA-EVOGEPES016-SECTION */
        private void R1066_00_TRATA_EVOGEPES016_SECTION()
        {
            /*" -3167- MOVE '1066' TO WNR-EXEC-SQL */
            _.Move("1066", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3169- DISPLAY 'R1066-00-TRATA-EVOGEPES016' */
            _.Display($"R1066-00-TRATA-EVOGEPES016");

            /*" -3171- MOVE 'S' TO WWORK-FUNDAO */
            _.Move("S", AREA_DE_WORK.WWORK_FUNDAO);

            /*" -3173- PERFORM R7520-00-RECUPERA-INDICADOR */

            R7520_00_RECUPERA_INDICADOR_SECTION();

            /*" -3174- IF CANAL-ATM */

            if (AREA_DE_WORK.FILLER_8.W_CANAL_PROPOSTA["CANAL_ATM"])
            {

                /*" -3177- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC */
                _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);

                /*" -3179- END-IF */
            }


            /*" -3182- DISPLAY '1066-01' '<VALOR-COMISSAO=' PARAMPRO-VALOR-COMISSAO-PRD '>' '<PRCT-COMISSAO=' PARAMPRO-PERCEN-COMIS-FUNC '>' */

            $"1066-01<VALOR-COMISSAO={PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD}><PRCT-COMISSAO={PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC}>"
            .Display();

            /*" -3185- IF PARAMPRO-VALOR-COMISSAO-PRD EQUAL ZEROS AND PARAMPRO-PERCEN-COMIS-FUNC EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD == 00 && PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC == 00)
            {

                /*" -3186- MOVE 17256 TO V0APCR-CODCORR */
                _.Move(17256, V0APCR_CODCORR);

                /*" -3188- MOVE 100 TO V0APCR-PCPARCOR */
                _.Move(100, V0APCR_PCPARCOR);

                /*" -3189- PERFORM R7540-00-RECUPERA-CORRETOR */

                R7540_00_RECUPERA_CORRETOR_SECTION();

                /*" -3190- PERFORM R7550-00-INSERE-COMIS-CORRETOR */

                R7550_00_INSERE_COMIS_CORRETOR_SECTION();

                /*" -3191- GO TO R1066-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1066_99_SAIDA*/ //GOTO
                return;

                /*" -3193- END-IF */
            }


            /*" -3195- PERFORM R7530-00-INSERE-COMI-INDICADOR */

            R7530_00_INSERE_COMI_INDICADOR_SECTION();

            /*" -3198- DISPLAY '1066-02' '<VALOR-COMISSAO=' PARAMPRO-VALOR-COMISSAO-PRD '>' '<PRCT-COMISSAO=' PARAMPRO-PERCEN-COMIS-FUNC '>' */

            $"1066-02<VALOR-COMISSAO={PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD}><PRCT-COMISSAO={PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC}>"
            .Display();

            /*" -3201- MOVE 17256 TO V0APCR-CODCORR */
            _.Move(17256, V0APCR_CODCORR);

            /*" -3203- MOVE 100 TO V0APCR-PCPARCOR */
            _.Move(100, V0APCR_PCPARCOR);

            /*" -3204- PERFORM R7540-00-RECUPERA-CORRETOR */

            R7540_00_RECUPERA_CORRETOR_SECTION();

            /*" -3206- PERFORM R7550-00-INSERE-COMIS-CORRETOR */

            R7550_00_INSERE_COMIS_CORRETOR_SECTION();

            /*" -3206- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1066_99_SAIDA*/

        [StopWatch]
        /*" R1067-00-TRATA-CORRETOR-SECTION */
        private void R1067_00_TRATA_CORRETOR_SECTION()
        {
            /*" -3215- MOVE '1067' TO WNR-EXEC-SQL */
            _.Move("1067", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3217- DISPLAY 'R1067-00-TRATA-CORRETOR' */
            _.Display($"R1067-00-TRATA-CORRETOR");

            /*" -3218- PERFORM R7540-00-RECUPERA-CORRETOR */

            R7540_00_RECUPERA_CORRETOR_SECTION();

            /*" -3220- PERFORM R7550-00-INSERE-COMIS-CORRETOR */

            R7550_00_INSERE_COMIS_CORRETOR_SECTION();

            /*" -3223- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -3225- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS AND V0APCR-PCPARCOR EQUAL 100 */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00 && V0APCR_PCPARCOR == 100)
            {

                /*" -3226- MOVE PARAMPRO-PERCEN-COMIS-FUNC TO AUX-PERCENT */
                _.Move(PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC, AREA_DE_WORK.AUX_PERCENT);

                /*" -3227- ELSE */
            }
            else
            {


                /*" -3228- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS */

                if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00)
                {

                    /*" -3230- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-PERCEN-COMIS-FUNC * 2) */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC * 2);

                    /*" -3231- ELSE */
                }
                else
                {


                    /*" -3234- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100 */
                    AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

                    /*" -3237- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100 */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;

                    /*" -3238- END-IF */
                }


                /*" -3240- END-IF */
            }


            /*" -3242- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -3243- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -3244- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -3245- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -3246- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -3247- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -3248- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -3249- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -3250- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -3252- MOVE ZEROS TO V0APCR-COD-EMPRESA */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -3254- MOVE 'CB0005B' TO V0APCR-COD-USUARIO */
            _.Move("CB0005B", V0APCR_COD_USUARIO);

            /*" -3256- PERFORM R1068-00-INSERT-APOLCORRET */

            R1068_00_INSERT_APOLCORRET_SECTION();

            /*" -3256- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1067_99_SAIDA*/

        [StopWatch]
        /*" R1068-00-INSERT-APOLCORRET-SECTION */
        private void R1068_00_INSERT_APOLCORRET_SECTION()
        {
            /*" -3267- MOVE '1068' TO WNR-EXEC-SQL. */
            _.Move("1068", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3268- DISPLAY 'R1068-00-INSERT-APOLCORRET' */
            _.Display($"R1068-00-INSERT-APOLCORRET");

            /*" -3270- MOVE V0APCR-CODCORR TO WS-COD-CORRETOR */
            _.Move(V0APCR_CODCORR, WS_COD_CORRETOR);

            /*" -3274- IF WS-PROD-RUNON AND N88-COD-CORRETOR AND V0APCR-TIPCOM = '1' AND V1SIST-DTMOVACB >= '2021-08-16' */

            if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] && WS_COD_CORRETOR["N88_COD_CORRETOR"] && V0APCR_TIPCOM == "1" && V1SIST_DTMOVACB >= "2021-08-16")
            {

                /*" -3277- MOVE 25267 TO V0APCR-CODCORR */
                _.Move(25267, V0APCR_CODCORR);

                /*" -3279- END-IF */
            }


            /*" -3295- PERFORM R1068_00_INSERT_APOLCORRET_DB_INSERT_1 */

            R1068_00_INSERT_APOLCORRET_DB_INSERT_1();

            /*" -3300- DISPLAY 'INS V0APOLCORRET ' V0APCR-NUM-APOL '*SQLCODE: ' SQLCODE */

            $"INS V0APOLCORRET {V0APCR_NUM_APOL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3301- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3302- DISPLAY 'R1068-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1068-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -3313- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL ' ' 'RAMO:    ' V0APCR-RAMOFR ' ' 'MODALIDA:' V0APCR-MODALIFR ' ' 'CODCORR: ' V0APCR-CODCORR ' ' 'CODSUBES:' V0APCR-CODSUBES ' ' 'DTINIVIG:' V0APCR-DTINIVIG ' ' 'DTTERVIG:' V0APCR-DTTERVIG ' ' 'PCPARCOR:' V0APCR-PCPARCOR ' ' 'PCCOMCOR:' V0APCR-PCCOMCOR ' ' 'TIPCOM:  ' V0APCR-TIPCOM ' ' 'OPCAO:   ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL} RAMO:    {V0APCR_RAMOFR} MODALIDA:{V0APCR_MODALIFR} CODCORR: {V0APCR_CODCORR} CODSUBES:{V0APCR_CODSUBES} DTINIVIG:{V0APCR_DTINIVIG} DTTERVIG:{V0APCR_DTTERVIG} PCPARCOR:{V0APCR_PCPARCOR} PCCOMCOR:{V0APCR_PCCOMCOR} TIPCOM:  {V0APCR_TIPCOM} OPCAO:   {WWORK_OPCAO_ANT}"
                .Display();

                /*" -3314- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3316- END-IF */
            }


            /*" -3318- ADD +1 TO AC-I-V0APOLCORRET */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

            /*" -3318- . */

        }

        [StopWatch]
        /*" R1068-00-INSERT-APOLCORRET-DB-INSERT-1 */
        public void R1068_00_INSERT_APOLCORRET_DB_INSERT_1()
        {
            /*" -3295- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC */

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
        /*" R1100-00-SELECT-CLIENTE-SECTION */
        private void R1100_00_SELECT_CLIENTE_SECTION()
        {
            /*" -3328- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3331- DISPLAY 'R1100-00-SELECT-CLIENTE' */
            _.Display($"R1100-00-SELECT-CLIENTE");

            /*" -3338- PERFORM R1100_00_SELECT_CLIENTE_DB_SELECT_1 */

            R1100_00_SELECT_CLIENTE_DB_SELECT_1();

            /*" -3343- DISPLAY 'SEL V0CLIENTE ' V0BILH-CODCLIEN '*SQLCODE: ' SQLCODE */

            $"SEL V0CLIENTE {V0BILH_CODCLIEN}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3344- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3345- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3347- DISPLAY 'R1100 - REGISTRO NAO ENCONTRADO V0CLIENTE' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN */

                    $"R1100 - REGISTRO NAO ENCONTRADO V0CLIENTE{V0BILH_NUMBIL} {V0BILH_CODCLIEN}"
                    .Display();

                    /*" -3348- GO TO R1100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;

                    /*" -3349- ELSE */
                }
                else
                {


                    /*" -3350- DISPLAY 'R1100 - ERRO SELECT V0CLIENTE ' SQLCODE */
                    _.Display($"R1100 - ERRO SELECT V0CLIENTE {DB.SQLCODE}");

                    /*" -3351- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                    _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                    /*" -3352- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                    _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                    /*" -3353- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3354- END-IF */
                }


                /*" -3354- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTE-DB-SELECT-1 */
        public void R1100_00_SELECT_CLIENTE_DB_SELECT_1()
        {
            /*" -3338- EXEC SQL SELECT CGCCPF, DATA_NASCIMENTO INTO :V0CLIE-CGCCPF, :V0CLIE-DTNASC:VIND-DTNASC FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0BILH-CODCLIEN END-EXEC. */

            var r1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1 = new R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1()
            {
                V0BILH_CODCLIEN = V0BILH_CODCLIEN.ToString(),
            };

            var executed_1 = R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_CGCCPF, V0CLIE_CGCCPF);
                _.Move(executed_1.V0CLIE_DTNASC, V0CLIE_DTNASC);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-GELIMRISCO-SECTION */
        private void R1200_00_SELECT_GELIMRISCO_SECTION()
        {
            /*" -3364- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3366- DISPLAY 'R1200-00-SELECT-GELIMRISCO' */
            _.Display($"R1200-00-SELECT-GELIMRISCO");

            /*" -3368- MOVE 'SIM' TO WTEM-GELMR. */
            _.Move("SIM", AREA_DE_WORK.WTEM_GELMR);

            /*" -3375- PERFORM R1200_00_SELECT_GELIMRISCO_DB_SELECT_1 */

            R1200_00_SELECT_GELIMRISCO_DB_SELECT_1();

            /*" -3380- DISPLAY 'SEL GE_LIMITE_DE_RISCO ' V0CLIE-CGCCPF '*SQLCODE: ' SQLCODE */

            $"SEL GE_LIMITE_DE_RISCO {V0CLIE_CGCCPF}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3381- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3382- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3383- MOVE 'NAO' TO WTEM-GELMR */
                    _.Move("NAO", AREA_DE_WORK.WTEM_GELMR);

                    /*" -3385- MOVE ZEROES TO GELMR-QTD-SEGUROS GELMR-VLR-SOMA-IS */
                    _.Move(0, GELMR_QTD_SEGUROS, GELMR_VLR_SOMA_IS);

                    /*" -3386- ELSE */
                }
                else
                {


                    /*" -3388- DISPLAY 'R1200 - ERRO SELECT GE_LIMITE_DE_RISCO..' SQLCODE */
                    _.Display($"R1200 - ERRO SELECT GE_LIMITE_DE_RISCO..{DB.SQLCODE}");

                    /*" -3389- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                    _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                    /*" -3390- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                    _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                    /*" -3391- DISPLAY 'CGCCPF = ' V0CLIE-CGCCPF */
                    _.Display($"CGCCPF = {V0CLIE_CGCCPF}");

                    /*" -3391- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-GELIMRISCO-DB-SELECT-1 */
        public void R1200_00_SELECT_GELIMRISCO_DB_SELECT_1()
        {
            /*" -3375- EXEC SQL SELECT VALUE(QTD_SEGUROS, 0), VALUE(VLR_SOMA_IS, 0) INTO :GELMR-QTD-SEGUROS, :GELMR-VLR-SOMA-IS FROM SEGUROS.GE_LIMITE_DE_RISCO WHERE CGCCPF = :V0CLIE-CGCCPF END-EXEC. */

            var r1200_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1 = new R1200_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1()
            {
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            var executed_1 = R1200_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GELMR_QTD_SEGUROS, GELMR_QTD_SEGUROS);
                _.Move(executed_1.GELMR_VLR_SOMA_IS, GELMR_VLR_SOMA_IS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-BIL-COBER-SECTION */
        private void R1300_00_SELECT_BIL_COBER_SECTION()
        {
            /*" -3401- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3404- DISPLAY 'R1300-00-SELECT-BIL-COBER' */
            _.Display($"R1300-00-SELECT-BIL-COBER");

            /*" -3414- PERFORM R1300_00_SELECT_BIL_COBER_DB_SELECT_1 */

            R1300_00_SELECT_BIL_COBER_DB_SELECT_1();

            /*" -3421- DISPLAY 'SEL V0BILHETE_COBER (3) ' V0BILH-OPCAO-COBER '/' V0BILH-DTQITBCO '/' V1BILP-CODPRODU '*SQLCODE: ' SQLCODE */

            $"SEL V0BILHETE_COBER (3) {V0BILH_OPCAO_COBER}/{V0BILH_DTQITBCO}/{V1BILP_CODPRODU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3422- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3423- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3424- MOVE ZEROES TO V1BILC-IMPSEG-IX */
                    _.Move(0, V1BILC_IMPSEG_IX);

                    /*" -3425- ELSE */
                }
                else
                {


                    /*" -3426- DISPLAY 'R1300 - ERRO SELECT BILHETE_COBER' SQLCODE */
                    _.Display($"R1300 - ERRO SELECT BILHETE_COBER{DB.SQLCODE}");

                    /*" -3427- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                    _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                    /*" -3428- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                    _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                    /*" -3429- DISPLAY 'CGCCPF = ' V0CLIE-CGCCPF */
                    _.Display($"CGCCPF = {V0CLIE_CGCCPF}");

                    /*" -3429- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-BIL-COBER-DB-SELECT-1 */
        public void R1300_00_SELECT_BIL_COBER_DB_SELECT_1()
        {
            /*" -3414- EXEC SQL SELECT VALUE(VAL_COBERTURA_IX, 0) INTO :V1BILC-IMPSEG-IX FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND COD_OPCAO = :V0BILH-OPCAO-COBER AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO AND CODPRODU = :V1BILP-CODPRODU END-EXEC. */

            var r1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1 = new R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1()
            {
                V0BILH_OPCAO_COBER = V0BILH_OPCAO_COBER.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V1BILP_CODPRODU = V1BILP_CODPRODU.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_IMPSEG_IX, V1BILC_IMPSEG_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-UPDATE-GELIMRISCO-SECTION */
        private void R1400_00_UPDATE_GELIMRISCO_SECTION()
        {
            /*" -3439- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3442- DISPLAY 'R1400-00-UPDATE-GELIMRISCO' */
            _.Display($"R1400-00-UPDATE-GELIMRISCO");

            /*" -3449- PERFORM R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1 */

            R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1();

            /*" -3454- DISPLAY 'UPD GE_LIMITE_DE_RISCO ' V0CLIE-CGCCPF '*SQLCODE: ' SQLCODE */

            $"UPD GE_LIMITE_DE_RISCO {V0CLIE_CGCCPF}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3455- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3457- DISPLAY 'R1400 - ERRO UPDATE GE_LIMITE_DE_RISCO..' SQLCODE */
                _.Display($"R1400 - ERRO UPDATE GE_LIMITE_DE_RISCO..{DB.SQLCODE}");

                /*" -3458- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                /*" -3459- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                /*" -3460- DISPLAY 'CGCCPF = ' V0CLIE-CGCCPF */
                _.Display($"CGCCPF = {V0CLIE_CGCCPF}");

                /*" -3462- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3462- ADD +1 TO AC-U-GELMR. */
            AREA_DE_WORK.AC_U_GELMR.Value = AREA_DE_WORK.AC_U_GELMR + +1;

        }

        [StopWatch]
        /*" R1400-00-UPDATE-GELIMRISCO-DB-UPDATE-1 */
        public void R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1()
        {
            /*" -3449- EXEC SQL UPDATE SEGUROS.GE_LIMITE_DE_RISCO SET QTD_SEGUROS = :GELMR-QTD-SEGUROS, VLR_SOMA_IS = :GELMR-VLR-SOMA-IS, COD_USUARIO = 'CB0005B' , DTH_TIMESTAMP = CURRENT TIMESTAMP WHERE CGCCPF = :V0CLIE-CGCCPF END-EXEC. */

            var r1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1 = new R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1()
            {
                GELMR_QTD_SEGUROS = GELMR_QTD_SEGUROS.ToString(),
                GELMR_VLR_SOMA_IS = GELMR_VLR_SOMA_IS.ToString(),
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1.Execute(r1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-INSERT-GELIMRISCO-SECTION */
        private void R1500_00_INSERT_GELIMRISCO_SECTION()
        {
            /*" -3472- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3475- DISPLAY 'R1500-00-INSERT-GELIMRISCO' */
            _.Display($"R1500-00-INSERT-GELIMRISCO");

            /*" -3484- PERFORM R1500_00_INSERT_GELIMRISCO_DB_INSERT_1 */

            R1500_00_INSERT_GELIMRISCO_DB_INSERT_1();

            /*" -3489- DISPLAY 'INS GE_LIMITE_DE_RISCO ' V0CLIE-CGCCPF '*SQLCODE: ' SQLCODE */

            $"INS GE_LIMITE_DE_RISCO {V0CLIE_CGCCPF}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3490- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3492- DISPLAY 'R1500 - ERRO INSERT GE_LIMITE_DE_RISCO..' SQLCODE */
                _.Display($"R1500 - ERRO INSERT GE_LIMITE_DE_RISCO..{DB.SQLCODE}");

                /*" -3495- DISPLAY 'CGCCPF ' V0CLIE-CGCCPF '  ' 'NUMBIL ' V0BILH-NUMBIL '  ' 'CODCLI ' V0BILH-CODCLIEN */

                $"CGCCPF {V0CLIE_CGCCPF}  NUMBIL {V0BILH_NUMBIL}  CODCLI {V0BILH_CODCLIEN}"
                .Display();

                /*" -3497- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3497- ADD +1 TO AC-I-GELMR. */
            AREA_DE_WORK.AC_I_GELMR.Value = AREA_DE_WORK.AC_I_GELMR + +1;

        }

        [StopWatch]
        /*" R1500-00-INSERT-GELIMRISCO-DB-INSERT-1 */
        public void R1500_00_INSERT_GELIMRISCO_DB_INSERT_1()
        {
            /*" -3484- EXEC SQL INSERT INTO SEGUROS.GE_LIMITE_DE_RISCO VALUES (:V0CLIE-CGCCPF , :V0BILH-RAMO , :GELMR-QTD-SEGUROS , :GELMR-VLR-SOMA-IS , CURRENT DATE , 'CB0005B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1 = new R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1()
            {
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
                GELMR_QTD_SEGUROS = GELMR_QTD_SEGUROS.ToString(),
                GELMR_VLR_SOMA_IS = GELMR_VLR_SOMA_IS.ToString(),
            };

            R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1.Execute(r1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-BUSCA-PRODUTO-SECTION */
        private void R1600_00_BUSCA_PRODUTO_SECTION()
        {
            /*" -3508- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3509- DISPLAY 'R1600-00-BUSCA-PRODUTO' */
            _.Display($"R1600-00-BUSCA-PRODUTO");

            /*" -3511- MOVE 'SIM' TO WS-JV1-ACHEI-PRODUTO. */
            _.Move("SIM", WORK_JV1.WS_JV1_ACHEI_PRODUTO);

            /*" -3521- PERFORM R1600_00_BUSCA_PRODUTO_DB_SELECT_1 */

            R1600_00_BUSCA_PRODUTO_DB_SELECT_1();

            /*" -3528- DISPLAY 'SEL BILHETE_COBERTURA ' V0BILH-RAMO '/' V0BILH-OPCAO-COBER '/' V0BILH-DTQITBCO '*SQLCODE: ' SQLCODE */

            $"SEL BILHETE_COBERTURA {V0BILH_RAMO}/{V0BILH_OPCAO_COBER}/{V0BILH_DTQITBCO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3529- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3530- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3531- MOVE 'NAO' TO WS-JV1-ACHEI-PRODUTO */
                    _.Move("NAO", WORK_JV1.WS_JV1_ACHEI_PRODUTO);

                    /*" -3532- ELSE */
                }
                else
                {


                    /*" -3533- DISPLAY 'R1600-00 (ERRO - SELECT BILHETE_COBERTURA)' */
                    _.Display($"R1600-00 (ERRO - SELECT BILHETE_COBERTURA)");

                    /*" -3537- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' 'OPCAO PLANO: ' V0BILH-OPCAO-COBER ' ' 'DT. QUITACAO: ' V0BILH-DTQITBCO */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  OPCAO PLANO: {V0BILH_OPCAO_COBER} DT. QUITACAO: {V0BILH_DTQITBCO}"
                    .Display();

                    /*" -3538- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3539- END-IF */
                }


                /*" -3539- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-BUSCA-PRODUTO-DB-SELECT-1 */
        public void R1600_00_BUSCA_PRODUTO_DB_SELECT_1()
        {
            /*" -3521- EXEC SQL SELECT COD_PRODUTO INTO :V1BILP-CODPRODU FROM SEGUROS.BILHETE_COBERTURA WHERE RAMO_COBERTURA = :V0BILH-RAMO AND COD_OPCAO_PLANO = :V0BILH-OPCAO-COBER AND DATA_INIVIGENCIA <= :V0BILH-DTQITBCO AND DATA_TERVIGENCIA >= :V0BILH-DTQITBCO AND IDE_COBERTURA = '1' WITH UR END-EXEC */

            var r1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1 = new R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1()
            {
                V0BILH_OPCAO_COBER = V0BILH_OPCAO_COBER.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1.Execute(r1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILP_CODPRODU, V1BILP_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-ACESSA-GE0070S-SECTION */
        private void R1700_00_ACESSA_GE0070S_SECTION()
        {
            /*" -3549- MOVE '1700' TO WNR-EXEC-SQL */
            _.Move("1700", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3553- DISPLAY 'R1700-00-ACESSA-GE0070S' */
            _.Display($"R1700-00-ACESSA-GE0070S");

            /*" -3555- IF V0BILH-COD-PRODUTO EQUAL WS-PDT-LID-ANT AND V0BILH-DTVENDA EQUAL WS-DAT-LID-ANT */

            if (V0BILH_COD_PRODUTO == WS_PDT_LID_ANT && V0BILH_DTVENDA == WS_DAT_LID_ANT)
            {

                /*" -3556- IF NOVOS-ACESSOS */

                if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -3557- PERFORM R1710-00-ACESSA-GE0071S THRU R1710-99-SAIDA */

                    R1710_00_ACESSA_GE0071S_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/


                    /*" -3558- END-IF */
                }


                /*" -3559- GO TO R1700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;

                /*" -3560- ELSE */
            }
            else
            {


                /*" -3561- MOVE V0BILH-COD-PRODUTO TO WS-PDT-LID-ANT */
                _.Move(V0BILH_COD_PRODUTO, WS_PDT_LID_ANT);

                /*" -3562- MOVE V0BILH-DTVENDA TO WS-DAT-LID-ANT */
                _.Move(V0BILH_DTVENDA, WS_DAT_LID_ANT);

                /*" -3565- END-IF */
            }


            /*" -3566- MOVE 'N' TO LK-0070-E-TRACE */
            _.Move("N", GE0070W.LK_0070_E_TRACE);

            /*" -3567- MOVE 'BATCH' TO LK-0070-E-COD-USUARIO */
            _.Move("BATCH", GE0070W.LK_0070_E_COD_USUARIO);

            /*" -3568- MOVE 'CB0005B' TO LK-0070-E-NOM-PROGRAMA */
            _.Move("CB0005B", GE0070W.LK_0070_E_NOM_PROGRAMA);

            /*" -3569- MOVE 001 TO LK-0070-E-ACAO */
            _.Move(001, GE0070W.LK_0070_E_ACAO);

            /*" -3570- MOVE V0BILH-COD-PRODUTO TO LK-0070-I-COD-PRODUTO */
            _.Move(V0BILH_COD_PRODUTO, GE0070W.LK_0070_I_COD_PRODUTO);

            /*" -3571- MOVE ZEROS TO LK-0070-I-SEQ-PRODUTO-VRS */
            _.Move(0, GE0070W.LK_0070_I_SEQ_PRODUTO_VRS);

            /*" -3573- MOVE V0BILH-DTVENDA TO LK-0070-I-DTA-PROPOSTA */
            _.Move(V0BILH_DTVENDA, GE0070W.LK_0070_I_DTA_PROPOSTA);

            /*" -3574- MOVE 'GE0070S' TO WS-PGM-CALL */
            _.Move("GE0070S", WS_PGM_CALL);

            /*" -3616- CALL WS-PGM-CALL USING LK-0070-E-TRACE LK-0070-E-COD-USUARIO LK-0070-E-NOM-PROGRAMA LK-0070-E-ACAO LK-0070-I-COD-PRODUTO LK-0070-I-SEQ-PRODUTO-VRS LK-0070-I-DTA-PROPOSTA LK-0070-S-DTA-INI-VIGENCIA LK-0070-S-DTA-FIM-VIGENCIA LK-0070-S-IND-FLUXO-PARAM LK-0070-S-COD-PERIOD-VIGENCIA LK-0070-S-QTD-PERIOD-VIGENCIA LK-0070-S-COD-MOEDA LK-0070-S-IND-RENOVA LK-0070-S-IND-RENOVA-AUTOMAT LK-0070-S-QTD-RENOVA-AUTOMAT LK-0070-S-IND-DPS LK-0070-S-IND-REENQUADRA-PREM LK-0070-S-IND-REAJUSTE-PREMIO LK-0070-S-COD-INDICE-REAJUSTE LK-0070-S-COD-PERIOD-REAJUSTE LK-0070-S-COD-INDC-DEVOLUCAO LK-0070-S-PCT-JUROS-DEVOLUCAO LK-0070-S-PCT-MULTA-DEVOLUCAO LK-0070-S-IND-FLUXO-COMISSAO LK-0070-S-IND-ACOPLADO LK-0070-S-IND-FLUXO-SINISTRO LK-0070-S-IND-CONJUGE LK-0070-S-COD-USUARIO LK-0070-S-NOM-PROGRAMA LK-0070-S-DTH-CADASTRAMENTO LK-0070-IND-ERRO LK-0070-MSG-ERRO LK-0070-NOM-TABELA LK-0070-SQLCODE LK-0070-SQLERRMC LK-0070-SQLSTATE. */
            _.Call(WS_PGM_CALL, GE0070W);

            /*" -3617- IF LK-0070-IND-ERRO EQUAL ZEROS */

            if (GE0070W.LK_0070_IND_ERRO == 00)
            {

                /*" -3618- MOVE LK-0070-S-IND-FLUXO-PARAM TO N88-NOVOS-ACESSOS */
                _.Move(GE0070W.LK_0070_S_IND_FLUXO_PARAM, N88_NOVOS_ACESSOS);

                /*" -3619- DISPLAY 'N88-NOVOS-ACESSOS: ' N88-NOVOS-ACESSOS */
                _.Display($"N88-NOVOS-ACESSOS: {N88_NOVOS_ACESSOS}");

                /*" -3620- IF NOVOS-ACESSOS */

                if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -3621- PERFORM R1710-00-ACESSA-GE0071S THRU R1710-99-SAIDA */

                    R1710_00_ACESSA_GE0071S_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/


                    /*" -3622- END-IF */
                }


                /*" -3623- ELSE */
            }
            else
            {


                /*" -3624- DISPLAY '***' */
                _.Display($"***");

                /*" -3625- DISPLAY ' R1700-00-ACESSA-GE0070S   ' */
                _.Display($" R1700-00-ACESSA-GE0070S   ");

                /*" -3626- DISPLAY ' CALL GE0070S ' */
                _.Display($" CALL GE0070S ");

                /*" -3627- DISPLAY ' ERRO CALL GE0070S(' LK-0070-IND-ERRO ')' */

                $" ERRO CALL GE0070S({GE0070W.LK_0070_IND_ERRO})"
                .Display();

                /*" -3628- DISPLAY ' LK-0070-E-TRACE  : ' LK-0070-E-TRACE */
                _.Display($" LK-0070-E-TRACE  : {GE0070W.LK_0070_E_TRACE}");

                /*" -3629- DISPLAY ' LK-0070-E-COD-USU: ' LK-0070-E-COD-USUARIO */
                _.Display($" LK-0070-E-COD-USU: {GE0070W.LK_0070_E_COD_USUARIO}");

                /*" -3630- DISPLAY ' LK-0070-E-NOM-PRO: ' LK-0070-E-NOM-PROGRAMA */
                _.Display($" LK-0070-E-NOM-PRO: {GE0070W.LK_0070_E_NOM_PROGRAMA}");

                /*" -3631- DISPLAY ' LK-0070-E-ACAO   : ' LK-0070-E-ACAO */
                _.Display($" LK-0070-E-ACAO   : {GE0070W.LK_0070_E_ACAO}");

                /*" -3632- DISPLAY ' LK-0070-I-COD-PRO: ' LK-0070-I-COD-PRODUTO */
                _.Display($" LK-0070-I-COD-PRO: {GE0070W.LK_0070_I_COD_PRODUTO}");

                /*" -3633- DISPLAY ' LK-0070-I-SEQ-PRO: ' LK-0070-I-SEQ-PRODUTO-VRS */
                _.Display($" LK-0070-I-SEQ-PRO: {GE0070W.LK_0070_I_SEQ_PRODUTO_VRS}");

                /*" -3634- DISPLAY ' LK-0070-I-DTA-PRO: ' LK-0070-I-DTA-PROPOSTA */
                _.Display($" LK-0070-I-DTA-PRO: {GE0070W.LK_0070_I_DTA_PROPOSTA}");

                /*" -3635- DISPLAY '***' */
                _.Display($"***");

                /*" -3636- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3638- END-IF */
            }


            /*" -3638- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1710-00-ACESSA-GE0071S-SECTION */
        private void R1710_00_ACESSA_GE0071S_SECTION()
        {
            /*" -3647- MOVE '1710' TO WNR-EXEC-SQL */
            _.Move("1710", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3650- DISPLAY WNR-EXEC-SQL */
            _.Display(FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3651- MOVE 'N' TO LK-0071-E-TRACE */
            _.Move("N", GE0071W.LK_0071_E_TRACE);

            /*" -3652- MOVE 'BATCH' TO LK-0071-E-COD-USUARIO */
            _.Move("BATCH", GE0071W.LK_0071_E_COD_USUARIO);

            /*" -3653- MOVE 'CB0005B' TO LK-0071-E-NOM-PROGRAMA */
            _.Move("CB0005B", GE0071W.LK_0071_E_NOM_PROGRAMA);

            /*" -3654- MOVE 001 TO LK-0071-E-ACAO */
            _.Move(001, GE0071W.LK_0071_E_ACAO);

            /*" -3655- MOVE V0BILH-COD-PRODUTO TO LK-0071-I-COD-PRODUTO */
            _.Move(V0BILH_COD_PRODUTO, GE0071W.LK_0071_I_COD_PRODUTO);

            /*" -3657- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO LK-0071-I-SEQ-PRODUTO-VRS */
            _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, GE0071W.LK_0071_I_SEQ_PRODUTO_VRS);

            /*" -3658- MOVE SPACES TO LK-0071-I-COD-OPC-COBERTURA */
            _.Move("", GE0071W.LK_0071_I_COD_OPC_COBERTURA);

            /*" -3659- MOVE V0BILH-OPCAO-COBER TO LK-0071-I-COD-OPC-PLANO */
            _.Move(V0BILH_OPCAO_COBER, GE0071W.LK_0071_I_COD_OPC_PLANO);

            /*" -3660- MOVE 'N' TO LK-0071-I-IND-CONJUGE */
            _.Move("N", GE0071W.LK_0071_I_IND_CONJUGE);

            /*" -3661- MOVE V0BILH-DTVENDA(1:4) TO WS-ANO-BASE */
            _.Move(V0BILH_DTVENDA.Substring(1, 4), WS_ANO_BASE);

            /*" -3662- MOVE V0CLIE-DTNASC(1:4) TO WS-ANO-NASC */
            _.Move(V0CLIE_DTNASC.Substring(1, 4), WS_ANO_NASC);

            /*" -3663- COMPUTE WS-IDADE = WS-ANO-BASE - WS-ANO-NASC */
            WS_IDADE.Value = WS_ANO_BASE - WS_ANO_NASC;

            /*" -3665- IF V0CLIE-DTNASC(6:5) GREATER V0BILH-DTVENDA(6:5) */

            if (V0CLIE_DTNASC.Substring(6, 5) > V0BILH_DTVENDA.Substring(6, 5))
            {

                /*" -3666- COMPUTE WS-IDADE = WS-IDADE - 1 */
                WS_IDADE.Value = WS_IDADE - 1;

                /*" -3667- END-IF */
            }


            /*" -3670- MOVE WS-IDADE TO LK-0071-I-NUM-IDADE */
            _.Move(WS_IDADE, GE0071W.LK_0071_I_NUM_IDADE);

            /*" -3671- MOVE 'GE0071S' TO WS-PGM-CALL */
            _.Move("GE0071S", WS_PGM_CALL);

            /*" -3672- DISPLAY 'EXECUTOU: ' WS-PGM-CALL */
            _.Display($"EXECUTOU: {WS_PGM_CALL}");

            /*" -3704- CALL WS-PGM-CALL USING LK-0071-E-TRACE LK-0071-E-COD-USUARIO LK-0071-E-NOM-PROGRAMA LK-0071-E-ACAO LK-0071-I-COD-PRODUTO LK-0071-I-SEQ-PRODUTO-VRS LK-0071-I-COD-OPC-COBERTURA LK-0071-I-COD-OPC-PLANO LK-0071-I-IND-CONJUGE LK-0071-I-NUM-IDADE LK-0071-S-NUM-IDADE-INI LK-0071-S-NUM-IDADE-FIM LK-0071-S-VLR-INI-PREMIO LK-0071-S-VLR-FIM-PREMIO LK-0071-S-PCT-IOF LK-0071-S-PCT-REENQUADRAMENTO LK-0071-S-IND-PERMIT-VENDA LK-0071-S-VLR-TOTAL-IS LK-0071-S-QTD-OCC LK-0071-S-ARR LK-0071-IND-ERRO LK-0071-MSG-ERRO LK-0071-NOM-TABELA LK-0071-SQLCODE LK-0071-SQLERRMC LK-0071-SQLSTATE */
            _.Call(WS_PGM_CALL, GE0071W, GE0071W.LK_0071_S_ARR);

            /*" -3705- IF LK-0071-IND-ERRO NOT EQUAL ZEROS */

            if (GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO != 00)
            {

                /*" -3706- DISPLAY '***' */
                _.Display($"***");

                /*" -3707- DISPLAY ' 1710-00-OBTER-COBERTURA  ' */
                _.Display($" 1710-00-OBTER-COBERTURA  ");

                /*" -3708- DISPLAY ' CALL GE0071S ' */
                _.Display($" CALL GE0071S ");

                /*" -3709- DISPLAY ' ERRO CALL GE0071S(' LK-0071-IND-ERRO ')' */

                $" ERRO CALL GE0071S({GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO})"
                .Display();

                /*" -3710- DISPLAY ' LK-0071-E-TRACE  : ' LK-0071-E-TRACE */
                _.Display($" LK-0071-E-TRACE  : {GE0071W.LK_0071_E_TRACE}");

                /*" -3711- DISPLAY ' LK-0071-E-COD-USU: ' LK-0071-E-COD-USUARIO */
                _.Display($" LK-0071-E-COD-USU: {GE0071W.LK_0071_E_COD_USUARIO}");

                /*" -3712- DISPLAY ' LK-0071-E-NOM-PRO: ' LK-0071-E-NOM-PROGRAMA */
                _.Display($" LK-0071-E-NOM-PRO: {GE0071W.LK_0071_E_NOM_PROGRAMA}");

                /*" -3713- DISPLAY ' LK-0071-E-ACAO   : ' LK-0071-E-ACAO */
                _.Display($" LK-0071-E-ACAO   : {GE0071W.LK_0071_E_ACAO}");

                /*" -3714- DISPLAY ' LK-0071-I-COD-PRO: ' LK-0071-I-COD-PRODUTO */
                _.Display($" LK-0071-I-COD-PRO: {GE0071W.LK_0071_I_COD_PRODUTO}");

                /*" -3715- DISPLAY ' LK-0071-I-SEQ-PRO: ' LK-0071-I-SEQ-PRODUTO-VRS */
                _.Display($" LK-0071-I-SEQ-PRO: {GE0071W.LK_0071_I_SEQ_PRODUTO_VRS}");

                /*" -3716- DISPLAY ' LK-0071-I-COD-OPC: ' LK-0071-I-COD-OPC-COBERTURA */
                _.Display($" LK-0071-I-COD-OPC: {GE0071W.LK_0071_I_COD_OPC_COBERTURA}");

                /*" -3717- DISPLAY ' LK-0071-I-COD-PLA: ' LK-0071-I-COD-OPC-PLANO */
                _.Display($" LK-0071-I-COD-PLA: {GE0071W.LK_0071_I_COD_OPC_PLANO}");

                /*" -3718- DISPLAY ' LK-0071-I-IND-CON: ' LK-0071-I-IND-CONJUGE */
                _.Display($" LK-0071-I-IND-CON: {GE0071W.LK_0071_I_IND_CONJUGE}");

                /*" -3719- DISPLAY ' LK-0071-I-NUM-IDA: ' LK-0071-I-NUM-IDADE */
                _.Display($" LK-0071-I-NUM-IDA: {GE0071W.LK_0071_I_NUM_IDADE}");

                /*" -3720- DISPLAY '***' */
                _.Display($"***");

                /*" -3721- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3723- END-IF */
            }


            /*" -3724- DISPLAY '** NUM-IDADE-INI.......: ' LK-0071-S-NUM-IDADE-INI */
            _.Display($"** NUM-IDADE-INI.......: {GE0071W.LK_0071_S_NUM_IDADE_INI}");

            /*" -3725- DISPLAY '** COD-OPC-PLANO.......: ' LK-0071-I-COD-OPC-PLANO */
            _.Display($"** COD-OPC-PLANO.......: {GE0071W.LK_0071_I_COD_OPC_PLANO}");

            /*" -3726- DISPLAY '** NUM-IDADE-FIM.......: ' LK-0071-S-NUM-IDADE-FIM */
            _.Display($"** NUM-IDADE-FIM.......: {GE0071W.LK_0071_S_NUM_IDADE_FIM}");

            /*" -3727- DISPLAY '** VLR-INI-PREMIO......: ' LK-0071-S-VLR-INI-PREMIO */
            _.Display($"** VLR-INI-PREMIO......: {GE0071W.LK_0071_S_VLR_INI_PREMIO}");

            /*" -3728- DISPLAY '** VLR-FIM-PREMIO......: ' LK-0071-S-VLR-FIM-PREMIO */
            _.Display($"** VLR-FIM-PREMIO......: {GE0071W.LK_0071_S_VLR_FIM_PREMIO}");

            /*" -3729- DISPLAY '**PCT-IOF..............: ' LK-0071-S-PCT-IOF */
            _.Display($"**PCT-IOF..............: {GE0071W.LK_0071_S_PCT_IOF}");

            /*" -3731- DISPLAY '**PCT-REENQUADRAMENTO..: ' LK-0071-S-PCT-REENQUADRAMENTO */
            _.Display($"**PCT-REENQUADRAMENTO..: {GE0071W.LK_0071_S_PCT_REENQUADRAMENTO}");

            /*" -3733- DISPLAY '**IND-PERMIT-VENDA.....: ' LK-0071-S-IND-PERMIT-VENDA */
            _.Display($"**IND-PERMIT-VENDA.....: {GE0071W.LK_0071_S_IND_PERMIT_VENDA}");

            /*" -3734- IF LK-0071-S-IND-PERMIT-VENDA = 'N' */

            if (GE0071W.LK_0071_S_IND_PERMIT_VENDA == "N")
            {

                /*" -3735- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -3736- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -3737- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -3738- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -3739- END-IF */
            }


            /*" -3740- DISPLAY '** QTD-COBERTURAS......: ' LK-0071-S-QTD-OCC */
            _.Display($"** QTD-COBERTURAS......: {GE0071W.LK_0071_S_QTD_OCC}");

            /*" -3741- PERFORM VARYING WI FROM 1 BY 1 UNTIL WI > LK-0071-S-QTD-OCC */

            for (WI.Value = 1; !(WI > GE0071W.LK_0071_S_QTD_OCC); WI.Value += 1)
            {

                /*" -3743- DISPLAY '**   COD-COBERTURA.....: ' LK-0071-S-A-COD-COBERTURA(WI) */
                _.Display($"**   COD-COBERTURA.....: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WI]}");

                /*" -3745- DISPLAY '**   VLR-IS............: ' LK-0071-S-A-VLR-IS(WI) */
                _.Display($"**   VLR-IS............: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WI]}");

                /*" -3747- DISPLAY '**   VLR-PREMIO........: ' LK-0071-S-A-VLR-PREMIO(WI) */
                _.Display($"**   VLR-PREMIO........: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WI]}");

                /*" -3749- DISPLAY '**   PCT-PARTICIPACAO..: ' LK-0071-S-A-PCT-PARTICIPACAO(WI) */
                _.Display($"**   PCT-PARTICIPACAO..: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WI]}");

                /*" -3751- DISPLAY '**   IND-TP-COBER......: ' LK-0071-S-A-IND-TP-COBER(WI) */
                _.Display($"**   IND-TP-COBER......: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WI]}");

                /*" -3753- DISPLAY '**   IND-SINIS-CANC....: ' LK-0071-S-A-IND-SINIS-CANC(WI) */
                _.Display($"**   IND-SINIS-CANC....: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WI]}");

                /*" -3755- DISPLAY '**   IND-INDNZ-MAISVEZ.: ' LK-0071-S-A-IND-INDNZ-MAISVEZ(WI) */
                _.Display($"**   IND-INDNZ-MAISVEZ.: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WI]}");

                /*" -3757- DISPLAY '**   COD-RAMO-COBER....: ' LK-0071-S-A-COD-RAMO-COBER(WI) */
                _.Display($"**   COD-RAMO-COBER....: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WI]}");

                /*" -3759- DISPLAY '**   DES-APRES-DOC.....: ' LK-0071-S-A-DES-APRES-DOC(WI) */
                _.Display($"**   DES-APRES-DOC.....: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WI]}");

                /*" -3761- END-PERFORM */
            }

            /*" -3761- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-GRAVA-V0HISTOPARC-SECTION */
        private void R2010_00_GRAVA_V0HISTOPARC_SECTION()
        {
            /*" -3770- MOVE '2010' TO WNR-EXEC-SQL */
            _.Move("2010", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3773- DISPLAY 'R2010-00-GRAVA-V0HISTOPARC' */
            _.Display($"R2010-00-GRAVA-V0HISTOPARC");

            /*" -3775- MOVE V0APOL-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3776- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3777- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3778- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -3780- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3781- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3782- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3783- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3784- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3786- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3788- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -3789- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3790- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3791- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3792- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3793- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3794- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3795- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3796- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -3797- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -3798- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3799- MOVE V0ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V0ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -3800- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3801- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3802- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3803- MOVE 'CB0005B' TO V0HISP-COD-USUAR */
            _.Move("CB0005B", V0HISP_COD_USUAR);

            /*" -3805- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3807- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3809- MOVE ZEROS TO V0HISP-COD-EMPRESA */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3809- PERFORM R2030-00-INSERT-V0HISTOPARC. */

            R2030_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2020-00-GRAVA-OPERACAO-BAIXA-SECTION */
        private void R2020_00_GRAVA_OPERACAO_BAIXA_SECTION()
        {
            /*" -3819- MOVE '2020' TO WNR-EXEC-SQL. */
            _.Move("2020", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3822- DISPLAY 'R2020-00-GRAVA-OPERACAO-BAIXA' */
            _.Display($"R2020-00-GRAVA-OPERACAO-BAIXA");

            /*" -3823- MOVE V0APOL-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3825- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3826- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3827- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3829- MOVE 0201 TO V0HISP-OPERACAO */
            _.Move(0201, V0HISP_OPERACAO);

            /*" -3830- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3831- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3832- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3833- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3835- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3837- MOVE 2 TO V0HISP-OCORHIST */
            _.Move(2, V0HISP_OCORHIST);

            /*" -3838- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3839- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3840- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3841- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3842- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3843- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3846- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3847- MOVE V2RCAP-VLRCAP TO V0HISP-VLPREMIO */
            _.Move(V2RCAP_VLRCAP, V0HISP_VLPREMIO);

            /*" -3848- MOVE V0ENDO-DATARCAP TO V0HISP-DTVENCTO */
            _.Move(V0ENDO_DATARCAP, V0HISP_DTVENCTO);

            /*" -3849- MOVE V1RCAC-BCOAVISO TO V0HISP-BCOCOBR */
            _.Move(V1RCAC_BCOAVISO, V0HISP_BCOCOBR);

            /*" -3850- MOVE V1RCAC-AGEAVISO TO V0HISP-AGECOBR */
            _.Move(V1RCAC_AGEAVISO, V0HISP_AGECOBR);

            /*" -3851- MOVE V1RCAC-NRAVISO TO V0HISP-NRAVISO */
            _.Move(V1RCAC_NRAVISO, V0HISP_NRAVISO);

            /*" -3852- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3853- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3854- MOVE 'CB0005B' TO V0HISP-COD-USUAR */
            _.Move("CB0005B", V0HISP_COD_USUAR);

            /*" -3856- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3857- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -3859- MOVE V0BILH-DTQITBCO TO V0HISP-DTQITBCO. */
            _.Move(V0BILH_DTQITBCO, V0HISP_DTQITBCO);

            /*" -3861- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3861- PERFORM R2030-00-INSERT-V0HISTOPARC. */

            R2030_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_99_SAIDA*/

        [StopWatch]
        /*" R2030-00-INSERT-V0HISTOPARC-SECTION */
        private void R2030_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -3871- MOVE '2030' TO WNR-EXEC-SQL. */
            _.Move("2030", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3874- DISPLAY 'R2030-00-INSERT-V0HISTOPARC' */
            _.Display($"R2030-00-INSERT-V0HISTOPARC");

            /*" -3903- PERFORM R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -3909- DISPLAY 'INS V0HISTOPARC ' V0HISP-NUM-APOL '/' V0HISP-NRENDOS '*SQLCODE: ' SQLCODE */

            $"INS V0HISTOPARC {V0HISP_NUM_APOL}/{V0HISP_NRENDOS}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3910- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3911- DISPLAY 'R2030-00 (ERRO - INSERT V0HISTOPARC)...' */
                _.Display($"R2030-00 (ERRO - INSERT V0HISTOPARC)...");

                /*" -3912- DISPLAY 'APOL           : ' V0HISP-NUM-APOL '  ' */

                $"APOL           : {V0HISP_NUM_APOL}  "
                .Display();

                /*" -3913- DISPLAY 'ENDO           : ' V0HISP-NRENDOS '  ' */

                $"ENDO           : {V0HISP_NRENDOS}  "
                .Display();

                /*" -3914- DISPLAY 'PARC           : ' V0HISP-NRPARCEL '  ' */

                $"PARC           : {V0HISP_NRPARCEL}  "
                .Display();

                /*" -3915- DISPLAY 'OCOR           : ' V0HISP-OCORHIST '  ' */

                $"OCOR           : {V0HISP_OCORHIST}  "
                .Display();

                /*" -3916- DISPLAY 'BILH           : ' V0BILH-NUMBIL */
                _.Display($"BILH           : {V0BILH_NUMBIL}");

                /*" -3917- DISPLAY 'V0HISP-DTMOVTO : ' V0HISP-DTMOVTO */
                _.Display($"V0HISP-DTMOVTO : {V0HISP_DTMOVTO}");

                /*" -3918- DISPLAY 'V0HISP-DTVENCTO: ' V0HISP-DTVENCTO */
                _.Display($"V0HISP-DTVENCTO: {V0HISP_DTVENCTO}");

                /*" -3919- DISPLAY 'V0HISP-DTQITBCO: ' V0HISP-DTQITBCO */
                _.Display($"V0HISP-DTQITBCO: {V0HISP_DTQITBCO}");

                /*" -3920- DISPLAY 'SQLCODE        : ' SQLCODE */
                _.Display($"SQLCODE        : {DB.SQLCODE}");

                /*" -3922- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3922- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R2030-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -3903- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
        /*" R2320-PRODUTO-RUNOFF-SECTION */
        private void R2320_PRODUTO_RUNOFF_SECTION()
        {
            /*" -3930- SET WS-IND-PROD TO 1 */
            JVBKINCL.WS_IND_PROD.Value = 1;

            /*" -3932- SEARCH CVPPROD AT END */
            void SearchAtEnd0()
            {

                /*" -3933- SET WS-PROD-RUNON TO TRUE */
                AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] = true;

                /*" -3934- WHEN CVPPROD(WS-IND-PROD) EQUAL WS-COD-PRODUTO */
            };

            var mustSearchAtEnd0 = true;
            for (; JVBKINCL.WS_IND_PROD < JVBKINCL.CVP_PRODUTO.CVPPROD.Items.Count; JVBKINCL.WS_IND_PROD.Value++)
            {

                if (JVBKINCL.CVP_PRODUTO.CVPPROD[JVBKINCL.WS_IND_PROD] == WS_COD_PRODUTO)
                {

                    mustSearchAtEnd0 = false;

                    /*" -3935- SET WS-PROD-RUNOFF TO TRUE */
                    AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNOFF"] = true;

                    /*" -3937- END-SEARCH */

                    /*" -3937- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-SECTION */
        private void R3000_00_ACUMULA_BILHETE_SECTION()
        {
            /*" -3947- DISPLAY 'R3000-00-ACUMULA-BILHETE' */
            _.Display($"R3000-00-ACUMULA-BILHETE");

            /*" -3950- MOVE '.' TO WS000-P1 WS000-P2 */
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P1);
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P2);


            /*" -3952- MOVE SPACES TO WFIM-V1RCAP */
            _.Move("", AREA_DE_WORK.WFIM_V1RCAP);

            /*" -3955- MOVE V0BILH-NUMBIL TO WWORK-NUMBIL V0APOL-NUMBIL */
            _.Move(V0BILH_NUMBIL, AREA_DE_WORK.WWORK_NUMBIL, V0APOL_NUMBIL);

            /*" -3960- MOVE '3000' TO WNR-EXEC-SQL */
            _.Move("3000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3961- MOVE V0BILH-NUMBIL TO V0RCAP-NRTIT. */
            _.Move(V0BILH_NUMBIL, V0RCAP_NRTIT);

            /*" -3974- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_1 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_1();

            /*" -3980- DISPLAY 'SEL V0RCAP ' V0RCAP-NRTIT '/' V2RCAP-VLRCAP '*SQLCODE: ' SQLCODE */

            $"SEL V0RCAP {V0RCAP_NRTIT}/{V2RCAP_VLRCAP}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3981- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3982- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3983- MOVE 'S' TO WFIM-V1RCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                    /*" -3984- ELSE */
                }
                else
                {


                    /*" -3985- DISPLAY 'R3000-00 (ERRO - SELECT V0RCAP)...' */
                    _.Display($"R3000-00 (ERRO - SELECT V0RCAP)...");

                    /*" -3988- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP */

                    $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}"
                    .Display();

                    /*" -3989- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3990- END-IF */
                }


                /*" -3992- ELSE */
            }
            else
            {


                /*" -3993- IF V0RCAP-SITUACAO NOT EQUAL '0' */

                if (V0RCAP_SITUACAO != "0")
                {

                    /*" -3994- MOVE 'S' TO WFIM-V1RCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                    /*" -3995- ELSE */
                }
                else
                {


                    /*" -3997- IF V0RCAP-OPERACAO GREATER 199 AND V0RCAP-OPERACAO LESS 300 */

                    if (V0RCAP_OPERACAO > 199 && V0RCAP_OPERACAO < 300)
                    {

                        /*" -3998- MOVE 'S' TO WFIM-V1RCAP */
                        _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                        /*" -3999- ELSE */
                    }
                    else
                    {


                        /*" -4001- IF V0RCAP-OPERACAO GREATER 399 AND V0RCAP-OPERACAO LESS 500 */

                        if (V0RCAP_OPERACAO > 399 && V0RCAP_OPERACAO < 500)
                        {

                            /*" -4002- MOVE 'S' TO WFIM-V1RCAP */
                            _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                            /*" -4003- END-IF */
                        }


                        /*" -4004- END-IF */
                    }


                    /*" -4005- END-IF */
                }


                /*" -4008- END-IF */
            }


            /*" -4009- IF WFIM-V1RCAP EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1RCAP == "S")
            {

                /*" -4010- IF V0BILH-SITUACAO EQUAL '2' */

                if (V0BILH_SITUACAO == "2")
                {

                    /*" -4011- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4012- ELSE */
                }
                else
                {


                    /*" -4013- MOVE '2' TO V0BILH-SITUACAO */
                    _.Move("2", V0BILH_SITUACAO);

                    /*" -4014- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4015- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4016- END-IF */
                }


                /*" -4018- END-IF */
            }


            /*" -4021- MOVE V0RCAP-NRRCAP TO WWORK-NRRCAP WHOST-NRRCAP. */
            _.Move(V0RCAP_NRRCAP, AREA_DE_WORK.FILLER_5.WWORK_NRRCAP);
            _.Move(V0RCAP_NRRCAP, WHOST_NRRCAP);


            /*" -4024- MOVE '3025' TO WNR-EXEC-SQL. */
            _.Move("3025", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4039- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_2 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_2();

            /*" -4045- DISPLAY 'SEL V1RCAPCOMP ' V0RCAP-FONTE '/' WHOST-NRRCAP '*SQLCODE: ' SQLCODE */

            $"SEL V1RCAPCOMP {V0RCAP_FONTE}/{WHOST_NRRCAP}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -4046- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4047- DISPLAY 'R3025-00 (ERRO - SELECT V1RCAPCOMP)... ' */
                _.Display($"R3025-00 (ERRO - SELECT V1RCAPCOMP)... ");

                /*" -4050- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -4051- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4057- END-IF */
            }


            /*" -4064- IF (CANAL-ATM OR (V1BILP-CODPRODU EQUAL 3709 OR JVPRD3709 OR 3721 OR 3729)) OR (CANAL-INTRANET AND (V1BILP-CODPRODU EQUAL 8521 OR 8528 OR 8529 OR 8533 OR 8534)) */

            if ((AREA_DE_WORK.FILLER_8.W_CANAL_PROPOSTA["CANAL_ATM"] || (V1BILP_CODPRODU.In("3709", JVBKINCL.JV_PRODUTOS.JVPRD3709.ToString(), "3721", "3729"))) || (AREA_DE_WORK.FILLER_8.W_CANAL_PROPOSTA["CANAL_INTRANET"] && (V1BILP_CODPRODU.In("8521", "8528", "8529", "8533", "8534"))))
            {

                /*" -4065- PERFORM R1100-00-SELECT-CLIENTE */

                R1100_00_SELECT_CLIENTE_SECTION();

                /*" -4067- MOVE ZEROS TO WHOST-COUNT */
                _.Move(0, WHOST_COUNT);

                /*" -4083- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_3 */

                R3000_00_ACUMULA_BILHETE_DB_SELECT_3();

                /*" -4089- DISPLAY 'SEL COUNT 1 ' '/V1BILP-CODPRODU: ' V1BILP-CODPRODU '/WHOST-COUNT: ' WHOST-COUNT '*SQLCODE: ' SQLCODE */

                $"SEL COUNT 1 /V1BILP-CODPRODU: {V1BILP_CODPRODU}/WHOST-COUNT: {WHOST_COUNT}*SQLCODE: {DB.SQLCODE}"
                .Display();

                /*" -4090- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4091- DISPLAY 'R3025-00 (ERRO - COUNT BILHETE ATM)... ' */
                    _.Display($"R3025-00 (ERRO - COUNT BILHETE ATM)... ");

                    /*" -4094- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                    $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -4095- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4097- END-IF */
                }


                /*" -4102- IF WHOST-COUNT EQUAL ZEROS AND (V1BILP-CODPRODU EQUAL 3709 OR JVPRD3709 OR 3721 OR 3729) */

                if (WHOST_COUNT == 00 && (V1BILP_CODPRODU.In("3709", JVBKINCL.JV_PRODUTOS.JVPRD3709.ToString(), "3721", "3729")))
                {

                    /*" -4117- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_4 */

                    R3000_00_ACUMULA_BILHETE_DB_SELECT_4();

                    /*" -4119- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4120- DISPLAY 'R3025-00 (ERRO - COUNT BILHETE 3709)' */
                        _.Display($"R3025-00 (ERRO - COUNT BILHETE 3709)");

                        /*" -4123- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                        $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                        .Display();

                        /*" -4124- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4125- END-IF */
                    }


                    /*" -4126- END-IF */
                }


                /*" -4131- DISPLAY 'SEL COUNT 2 ' '/V1BILP-CODPRODU: ' V1BILP-CODPRODU '/WHOST-COUNT: ' WHOST-COUNT '*SQLCODE: ' SQLCODE */

                $"SEL COUNT 2 /V1BILP-CODPRODU: {V1BILP_CODPRODU}/WHOST-COUNT: {WHOST_COUNT}*SQLCODE: {DB.SQLCODE}"
                .Display();

                /*" -4133- IF V1BILP-CODPRODU EQUAL 8521 OR 8528 OR 8529 OR 8533 OR 8534 */

                if (V1BILP_CODPRODU.In("8521", "8528", "8529", "8533", "8534"))
                {

                    /*" -4134- IF WHOST-COUNT > 3 */

                    if (WHOST_COUNT > 3)
                    {

                        /*" -4135- MOVE 834 TO V0BILER-COD-ERRO */
                        _.Move(834, V0BILER_COD_ERRO);

                        /*" -4138- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -4139- MOVE 'R' TO V0BILH-SITUACAO */
                        _.Move("R", V0BILH_SITUACAO);

                        /*" -4141- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -4146- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(5) BILHETE ' 'REJEITADO. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' WHOST-COUNT */

                        $"ULTRAPASSA LIMITE DE RISCO(5) BILHETE REJEITADO. {V0BILH_NUMBIL} {V0BILH_CODCLIEN} {V0CLIE_CGCCPF} {V1BILP_CODPRODU} {WHOST_COUNT}"
                        .Display();

                        /*" -4147- MOVE 'S' TO N88-VAI-LEITURA */
                        _.Move("S", N88_VAI_LEITURA);

                        /*" -4149- GO TO R3000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                        return;

                        /*" -4150- END-IF */
                    }


                    /*" -4151- ELSE */
                }
                else
                {


                    /*" -4156- IF V1BILP-CODPRODU EQUAL 3721 AND (CANAL-CORRETOR OR CANAL-ATM) */

                    if (V1BILP_CODPRODU == 3721 && (AREA_DE_WORK.FILLER_8.W_CANAL_PROPOSTA["CANAL_CORRETOR"] || AREA_DE_WORK.FILLER_8.W_CANAL_PROPOSTA["CANAL_ATM"]))
                    {

                        /*" -4157- IF WHOST-COUNT > 3 */

                        if (WHOST_COUNT > 3)
                        {

                            /*" -4158- MOVE 834 TO V0BILER-COD-ERRO */
                            _.Move(834, V0BILER_COD_ERRO);

                            /*" -4160- PERFORM R3045-00-GRAVA-TAB-ERRO */

                            R3045_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -4162- MOVE '1' TO V0BILH-SITUACAO */
                            _.Move("1", V0BILH_SITUACAO);

                            /*" -4163- MOVE 'R' TO V0BILH-SITUACAO */
                            _.Move("R", V0BILH_SITUACAO);

                            /*" -4165- PERFORM R3020-00-UPDATE-V0BILHETE */

                            R3020_00_UPDATE_V0BILHETE_SECTION();

                            /*" -4170- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(8) BILHETE ' 'REJEITADO. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' WHOST-COUNT */

                            $"ULTRAPASSA LIMITE DE RISCO(8) BILHETE REJEITADO. {V0BILH_NUMBIL} {V0BILH_CODCLIEN} {V0CLIE_CGCCPF} {V1BILP_CODPRODU} {WHOST_COUNT}"
                            .Display();

                            /*" -4171- MOVE 'S' TO N88-VAI-LEITURA */
                            _.Move("S", N88_VAI_LEITURA);

                            /*" -4173- GO TO R3000-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                            return;

                            /*" -4174- END-IF */
                        }


                        /*" -4175- ELSE */
                    }
                    else
                    {


                        /*" -4176- IF V1BILP-CODPRODU EQUAL 3729 */

                        if (V1BILP_CODPRODU == 3729)
                        {

                            /*" -4177- IF WHOST-COUNT GREATER 003 */

                            if (WHOST_COUNT > 003)
                            {

                                /*" -4178- MOVE 834 TO V0BILER-COD-ERRO */
                                _.Move(834, V0BILER_COD_ERRO);

                                /*" -4179- PERFORM R3045-00-GRAVA-TAB-ERRO */

                                R3045_00_GRAVA_TAB_ERRO_SECTION();

                                /*" -4180- MOVE 'R' TO V0BILH-SITUACAO */
                                _.Move("R", V0BILH_SITUACAO);

                                /*" -4181- PERFORM R3020-00-UPDATE-V0BILHETE */

                                R3020_00_UPDATE_V0BILHETE_SECTION();

                                /*" -4185- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(11) BILHETE' ' REJEITADO: ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' WHOST-COUNT */

                                $"ULTRAPASSA LIMITE DE RISCO(11) BILHETE REJEITADO: {V0BILH_NUMBIL} {V0BILH_CODCLIEN} {V0CLIE_CGCCPF} {V1BILP_CODPRODU} {WHOST_COUNT}"
                                .Display();

                                /*" -4186- MOVE 'S' TO N88-VAI-LEITURA */
                                _.Move("S", N88_VAI_LEITURA);

                                /*" -4187- GO TO R3000-99-SAIDA */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                                return;

                                /*" -4188- END-IF */
                            }


                            /*" -4189- ELSE */
                        }
                        else
                        {


                            /*" -4190- IF WHOST-COUNT GREATER ZEROS */

                            if (WHOST_COUNT > 00)
                            {

                                /*" -4191- MOVE 834 TO V0BILER-COD-ERRO */
                                _.Move(834, V0BILER_COD_ERRO);

                                /*" -4193- PERFORM R3045-00-GRAVA-TAB-ERRO */

                                R3045_00_GRAVA_TAB_ERRO_SECTION();

                                /*" -4195- PERFORM R3020-00-UPDATE-V0BILHETE */

                                R3020_00_UPDATE_V0BILHETE_SECTION();

                                /*" -4196- MOVE 'R' TO V0BILH-SITUACAO */
                                _.Move("R", V0BILH_SITUACAO);

                                /*" -4198- PERFORM R3020-00-UPDATE-V0BILHETE */

                                R3020_00_UPDATE_V0BILHETE_SECTION();

                                /*" -4202- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(3) BILHETE ' 'REJEITADO. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' WHOST-COUNT */

                                $"ULTRAPASSA LIMITE DE RISCO(3) BILHETE REJEITADO. {V0BILH_NUMBIL} {V0BILH_CODCLIEN} {V0CLIE_CGCCPF} {V1BILP_CODPRODU} {WHOST_COUNT}"
                                .Display();

                                /*" -4203- MOVE 'S' TO N88-VAI-LEITURA */
                                _.Move("S", N88_VAI_LEITURA);

                                /*" -4205- GO TO R3000-99-SAIDA */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                                return;

                                /*" -4206- END-IF */
                            }


                            /*" -4207- END-IF */
                        }


                        /*" -4208- END-IF */
                    }


                    /*" -4211- END-IF */
                }


                /*" -4212- IF VIND-DTNASC LESS ZEROES */

                if (VIND_DTNASC < 00)
                {

                    /*" -4214- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -4215- MOVE 11001 TO V0BILER-COD-ERRO */
                    _.Move(11001, V0BILER_COD_ERRO);

                    /*" -4216- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4217- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4218- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4220- END-IF */
                }


                /*" -4222- MOVE V0BILH-DTQITBCO TO WDATA-PROPOSTA */
                _.Move(V0BILH_DTQITBCO, AREA_DE_WORK.WDATA_PROPOSTA);

                /*" -4223- MOVE V0CLIE-DTNASC TO WDATA-NASCIMENTO */
                _.Move(V0CLIE_DTNASC, AREA_DE_WORK.WDATA_NASCIMENTO);

                /*" -4224- COMPUTE WWORK-IDADE = WDATA-AA-PROP - WDATA-AA-NASC */
                AREA_DE_WORK.WWORK_IDADE.Value = AREA_DE_WORK.WDATA_PROPOSTA.WDATA_AA_PROP - AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_AA_NASC;

                /*" -4225- IF WDATA-MM-NASC > WDATA-MM-PROP */

                if (AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_MM_NASC > AREA_DE_WORK.WDATA_PROPOSTA.WDATA_MM_PROP)
                {

                    /*" -4226- SUBTRACT 1 FROM WWORK-IDADE */
                    AREA_DE_WORK.WWORK_IDADE.Value = AREA_DE_WORK.WWORK_IDADE - 1;

                    /*" -4227- ELSE */
                }
                else
                {


                    /*" -4228- IF WDATA-MM-NASC EQUAL WDATA-MM-PROP */

                    if (AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_MM_NASC == AREA_DE_WORK.WDATA_PROPOSTA.WDATA_MM_PROP)
                    {

                        /*" -4229- IF WDATA-DD-NASC GREATER WDATA-DD-PROP */

                        if (AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_DD_NASC > AREA_DE_WORK.WDATA_PROPOSTA.WDATA_DD_PROP)
                        {

                            /*" -4230- SUBTRACT 1 FROM WWORK-IDADE */
                            AREA_DE_WORK.WWORK_IDADE.Value = AREA_DE_WORK.WWORK_IDADE - 1;

                            /*" -4231- END-IF */
                        }


                        /*" -4232- END-IF */
                    }


                    /*" -4234- END-IF */
                }


                /*" -4242- IF V1BILP-CODPRODU EQUAL 3709 OR 8145 OR 8146 OR 8147 OR 8148 OR 8149 OR 8150 OR JVPRD3709 OR JVPRD8145 OR JVPRD8146 OR JVPRD8147 OR JVPRD8148 OR JVPRD8149 OR JVPRD8150 OR 3729 */

                if (V1BILP_CODPRODU.In("3709", "8145", "8146", "8147", "8148", "8149", "8150", JVBKINCL.JV_PRODUTOS.JVPRD3709.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8145.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8146.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8147.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8148.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8149.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8150.ToString(), "3729"))
                {

                    /*" -4244- IF WWORK-IDADE LESS 16 */

                    if (AREA_DE_WORK.WWORK_IDADE < 16)
                    {

                        /*" -4245- MOVE 11101 TO V0BILER-COD-ERRO */
                        _.Move(11101, V0BILER_COD_ERRO);

                        /*" -4246- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -4247- MOVE '1' TO V0BILH-SITUACAO */
                        _.Move("1", V0BILH_SITUACAO);

                        /*" -4248- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -4249- GO TO R3000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                        return;

                        /*" -4250- END-IF */
                    }


                    /*" -4252- END-IF */
                }


                /*" -4260- IF V1BILP-CODPRODU EQUAL 3724 OR 8145 OR 8146 OR 8147 OR 8148 OR 8149 OR 8150 OR JVPRD8145 OR JVPRD8146 OR JVPRD8147 OR JVPRD8148 OR JVPRD8149 OR JVPRD8150 OR 3729 */

                if (V1BILP_CODPRODU.In("3724", "8145", "8146", "8147", "8148", "8149", "8150", JVBKINCL.JV_PRODUTOS.JVPRD8145.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8146.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8147.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8148.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8149.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8150.ToString(), "3729"))
                {

                    /*" -4263- IF WWORK-IDADE LESS 16 OR WWORK-IDADE GREATER 70 */

                    if (AREA_DE_WORK.WWORK_IDADE < 16 || AREA_DE_WORK.WWORK_IDADE > 70)
                    {

                        /*" -4264- MOVE 11101 TO V0BILER-COD-ERRO */
                        _.Move(11101, V0BILER_COD_ERRO);

                        /*" -4265- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -4267- MOVE '1' TO V0BILH-SITUACAO */
                        _.Move("1", V0BILH_SITUACAO);

                        /*" -4268- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -4269- GO TO R3000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                        return;

                        /*" -4270- END-IF */
                    }


                    /*" -4272- END-IF */
                }


                /*" -4276- IF (V1BILP-CODPRODU EQUAL 8144 OR JVPRD8144 OR 3721 OR 8521 OR 8528 OR 8529 OR 8533 OR 8534) */

                if ((V1BILP_CODPRODU.In("8144", JVBKINCL.JV_PRODUTOS.JVPRD8144.ToString(), "3721", "8521", "8528", "8529", "8533", "8534")))
                {

                    /*" -4281- IF V1BILP-CODPRODU EQUAL 3721 AND (PRPFIDEL-ORIG-PROPOSTA EQUAL 15 OR 13 OR 22) AND (CANAL-CORRETOR OR CANAL-ATM) */

                    if (V1BILP_CODPRODU == 3721 && (PRPFIDEL_ORIG_PROPOSTA.In("15", "13", "22")) && (AREA_DE_WORK.FILLER_8.W_CANAL_PROPOSTA["CANAL_CORRETOR"] || AREA_DE_WORK.FILLER_8.W_CANAL_PROPOSTA["CANAL_ATM"]))
                    {

                        /*" -4283- IF WWORK-IDADE LESS 16 OR WWORK-IDADE GREATER 70 */

                        if (AREA_DE_WORK.WWORK_IDADE < 16 || AREA_DE_WORK.WWORK_IDADE > 70)
                        {

                            /*" -4284- MOVE 11101 TO V0BILER-COD-ERRO */
                            _.Move(11101, V0BILER_COD_ERRO);

                            /*" -4285- PERFORM R3045-00-GRAVA-TAB-ERRO */

                            R3045_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -4286- MOVE '1' TO V0BILH-SITUACAO */
                            _.Move("1", V0BILH_SITUACAO);

                            /*" -4287- PERFORM R3020-00-UPDATE-V0BILHETE */

                            R3020_00_UPDATE_V0BILHETE_SECTION();

                            /*" -4288- GO TO R3000-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                            return;

                            /*" -4289- END-IF */
                        }


                        /*" -4290- ELSE */
                    }
                    else
                    {


                        /*" -4293- IF WWORK-IDADE LESS 16 OR WWORK-IDADE GREATER 80 */

                        if (AREA_DE_WORK.WWORK_IDADE < 16 || AREA_DE_WORK.WWORK_IDADE > 80)
                        {

                            /*" -4294- MOVE 11101 TO V0BILER-COD-ERRO */
                            _.Move(11101, V0BILER_COD_ERRO);

                            /*" -4295- PERFORM R3045-00-GRAVA-TAB-ERRO */

                            R3045_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -4296- MOVE '1' TO V0BILH-SITUACAO */
                            _.Move("1", V0BILH_SITUACAO);

                            /*" -4297- PERFORM R3020-00-UPDATE-V0BILHETE */

                            R3020_00_UPDATE_V0BILHETE_SECTION();

                            /*" -4298- GO TO R3000-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                            return;

                            /*" -4299- END-IF */
                        }


                        /*" -4300- END-IF */
                    }


                    /*" -4302- END-IF */
                }


                /*" -4305- END-IF */
            }


            /*" -4313- IF CANAL-ATM AND V1BILP-CODPRODU EQUAL 8144 OR 8145 OR 8146 OR 8147 OR 8148 OR 8149 OR 8150 OR JVPRD8144 OR JVPRD8145 OR JVPRD8146 OR JVPRD8147 OR JVPRD8148 OR JVPRD8149 OR JVPRD8150 OR 3721 */

            if (AREA_DE_WORK.FILLER_8.W_CANAL_PROPOSTA["CANAL_ATM"] && V1BILP_CODPRODU.In("8144", "8145", "8146", "8147", "8148", "8149", "8150", JVBKINCL.JV_PRODUTOS.JVPRD8144.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8145.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8146.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8147.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8148.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8149.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8150.ToString(), "3721"))
            {

                /*" -4339- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_5 */

                R3000_00_ACUMULA_BILHETE_DB_SELECT_5();

                /*" -4342- DISPLAY 'SUM ' '*SQLCODE: ' SQLCODE */

                $"SUM *SQLCODE: {DB.SQLCODE}"
                .Display();

                /*" -4343- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4344- DISPLAY 'R3025-00 (ERRO - ACUMULO DE RISCO CX FACIL)' */
                    _.Display($"R3025-00 (ERRO - ACUMULO DE RISCO CX FACIL)");

                    /*" -4346- DISPLAY 'CPF: ' V0CLIE-CGCCPF ' ' 'BILHETE: ' V0BILH-NUMBIL */

                    $"CPF: {V0CLIE_CGCCPF} BILHETE: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -4347- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4349- END-IF */
                }


                /*" -4350- IF VIND-ACUM-RISCO LESS ZEROS */

                if (VIND_ACUM_RISCO < 00)
                {

                    /*" -4351- MOVE ZEROS TO WS002-VAL-COB-IX */
                    _.Move(0, WS002_ACUMULADORES.WS002_VAL_COB_IX);

                    /*" -4353- END-IF */
                }


                /*" -4354- IF NOVOS-ACESSOS */

                if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -4355- MOVE LK-0071-S-VLR-TOTAL-IS TO V1BILC-IMPSEG-IX */
                    _.Move(GE0071W.LK_0071_S_VLR_TOTAL_IS, V1BILC_IMPSEG_IX);

                    /*" -4356- ELSE */
                }
                else
                {


                    /*" -4357- PERFORM R1300-00-SELECT-BIL-COBER */

                    R1300_00_SELECT_BIL_COBER_SECTION();

                    /*" -4359- END-IF */
                }


                /*" -4362- COMPUTE WS002-TOT-IMP-SEG = WS002-VAL-COB-IX + V1BILC-IMPSEG-IX */
                WS002_ACUMULADORES.WS002_TOT_IMP_SEG.Value = WS002_ACUMULADORES.WS002_VAL_COB_IX + V1BILC_IMPSEG_IX;

                /*" -4364- IF V1BILP-CODPRODU EQUAL 8521 OR 8528 OR 8529 OR 8533 OR 8534 */

                if (V1BILP_CODPRODU.In("8521", "8528", "8529", "8533", "8534"))
                {

                    /*" -4365- IF WS002-TOT-IMP-SEG > 2000000,01 */

                    if (WS002_ACUMULADORES.WS002_TOT_IMP_SEG > 2000000.01)
                    {

                        /*" -4366- MOVE 834 TO V0BILER-COD-ERRO */
                        _.Move(834, V0BILER_COD_ERRO);

                        /*" -4368- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -4369- MOVE 'R' TO V0BILH-SITUACAO */
                        _.Move("R", V0BILH_SITUACAO);

                        /*" -4370- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -4374- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(7) BILHETE REJEI 'TADO. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' WS002-TOT-IMP-SEG */

                        $"ULTRAPASSA LIMITE DE RISCO(7) BILHETE REJEI TADO. V0BILH-NUMBIL  V0BILH-CODCLIEN  V0CLIE-CGCCPF  V1BILP-CODPRODU {WS002_ACUMULADORES.WS002_TOT_IMP_SEG}"
                        .Display();

                        /*" -4375- MOVE 'S' TO N88-VAI-LEITURA */
                        _.Move("S", N88_VAI_LEITURA);

                        /*" -4377- GO TO R3000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                        return;

                        /*" -4378- END-IF */
                    }


                    /*" -4379- ELSE */
                }
                else
                {


                    /*" -4380- IF WS002-TOT-IMP-SEG > 1000000,01 */

                    if (WS002_ACUMULADORES.WS002_TOT_IMP_SEG > 1000000.01)
                    {

                        /*" -4381- MOVE 834 TO V0BILER-COD-ERRO */
                        _.Move(834, V0BILER_COD_ERRO);

                        /*" -4383- PERFORM R3045-00-GRAVA-TAB-ERRO */

                        R3045_00_GRAVA_TAB_ERRO_SECTION();

                        /*" -4384- MOVE 'R' TO V0BILH-SITUACAO */
                        _.Move("R", V0BILH_SITUACAO);

                        /*" -4385- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -4389- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(4) BILHETE REJEI 'TADO. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' WS002-TOT-IMP-SEG */

                        $"ULTRAPASSA LIMITE DE RISCO(4) BILHETE REJEI TADO. V0BILH-NUMBIL  V0BILH-CODCLIEN  V0CLIE-CGCCPF  V1BILP-CODPRODU {WS002_ACUMULADORES.WS002_TOT_IMP_SEG}"
                        .Display();

                        /*" -4390- MOVE 'S' TO N88-VAI-LEITURA */
                        _.Move("S", N88_VAI_LEITURA);

                        /*" -4392- GO TO R3000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                        return;

                        /*" -4393- END-IF */
                    }


                    /*" -4394- END-IF */
                }


                /*" -4399- END-IF */
            }


            /*" -4401- IF V1BILP-CODPRODU EQUAL 8521 OR 8528 OR 8529 OR 8533 OR 8534 */

            if (V1BILP_CODPRODU.In("8521", "8528", "8529", "8533", "8534"))
            {

                /*" -4424- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_6 */

                R3000_00_ACUMULA_BILHETE_DB_SELECT_6();

                /*" -4428- DISPLAY 'SUM 2 ' '*SQLCODE: ' SQLCODE */

                $"SUM 2 *SQLCODE: {DB.SQLCODE}"
                .Display();

                /*" -4429- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4430- DISPLAY 'R3025-00 (ERRO - ACUMULO RISCO AP.BEM-ESTAR)' */
                    _.Display($"R3025-00 (ERRO - ACUMULO RISCO AP.BEM-ESTAR)");

                    /*" -4432- DISPLAY 'CPF: ' V0CLIE-CGCCPF ' ' 'BILHETE: ' V0BILH-NUMBIL */

                    $"CPF: {V0CLIE_CGCCPF} BILHETE: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -4433- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4435- END-IF */
                }


                /*" -4436- IF VIND-ACUM-RISCO LESS ZEROS */

                if (VIND_ACUM_RISCO < 00)
                {

                    /*" -4437- MOVE ZEROS TO WS002-VAL-COB-IX */
                    _.Move(0, WS002_ACUMULADORES.WS002_VAL_COB_IX);

                    /*" -4439- END-IF */
                }


                /*" -4440- IF NOVOS-ACESSOS */

                if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -4441- MOVE LK-0071-S-VLR-TOTAL-IS TO V1BILC-IMPSEG-IX */
                    _.Move(GE0071W.LK_0071_S_VLR_TOTAL_IS, V1BILC_IMPSEG_IX);

                    /*" -4442- ELSE */
                }
                else
                {


                    /*" -4443- PERFORM R1300-00-SELECT-BIL-COBER */

                    R1300_00_SELECT_BIL_COBER_SECTION();

                    /*" -4445- END-IF */
                }


                /*" -4448- COMPUTE WS002-TOT-IMP-SEG = WS002-VAL-COB-IX + V1BILC-IMPSEG-IX */
                WS002_ACUMULADORES.WS002_TOT_IMP_SEG.Value = WS002_ACUMULADORES.WS002_VAL_COB_IX + V1BILC_IMPSEG_IX;

                /*" -4449- IF WS002-TOT-IMP-SEG > 2000000,01 */

                if (WS002_ACUMULADORES.WS002_TOT_IMP_SEG > 2000000.01)
                {

                    /*" -4450- MOVE 834 TO V0BILER-COD-ERRO */
                    _.Move(834, V0BILER_COD_ERRO);

                    /*" -4452- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4453- MOVE 'R' TO V0BILH-SITUACAO */
                    _.Move("R", V0BILH_SITUACAO);

                    /*" -4454- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4458- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(6) BILHETE REJEITAD 'O. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' WS002-TOT-IMP-SEG */

                    $"ULTRAPASSA LIMITE DE RISCO(6) BILHETE REJEITAD {COBPRPVA.DCLHIS_COBER_PROPOST.OCORR_HISTORICO} V0BILH-NUMBIL  V0BILH-CODCLIEN  V0CLIE-CGCCPF  V1BILP-CODPRODU {WS002_ACUMULADORES.WS002_TOT_IMP_SEG}"
                    .Display();

                    /*" -4459- MOVE 'S' TO N88-VAI-LEITURA */
                    _.Move("S", N88_VAI_LEITURA);

                    /*" -4461- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4462- END-IF */
                }


                /*" -4474- END-IF */
            }


            /*" -4475- IF (V1BILP-CODPRODU EQUAL 8530 OR 8531 OR 8532) */

            if ((V1BILP_CODPRODU.In("8530", "8531", "8532")))
            {

                /*" -4476- PERFORM R1100-00-SELECT-CLIENTE */

                R1100_00_SELECT_CLIENTE_SECTION();

                /*" -4478- MOVE ZEROS TO WHOST-COUNT */
                _.Move(0, WHOST_COUNT);

                /*" -4494- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_7 */

                R3000_00_ACUMULA_BILHETE_DB_SELECT_7();

                /*" -4498- DISPLAY 'COUNT ' '*SQLCODE: ' SQLCODE */

                $"COUNT *SQLCODE: {DB.SQLCODE}"
                .Display();

                /*" -4499- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4500- DISPLAY 'R3025-04 (ERRO - COUNT BILHETE EMPR... ' */
                    _.Display($"R3025-04 (ERRO - COUNT BILHETE EMPR... ");

                    /*" -4503- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                    $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -4504- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4506- END-IF */
                }


                /*" -4507- IF (WHOST-COUNT EQUAL ZEROS) */

                if ((WHOST_COUNT == 00))
                {

                    /*" -4521- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_8 */

                    R3000_00_ACUMULA_BILHETE_DB_SELECT_8();

                    /*" -4525- DISPLAY 'COUNT ' '*SQLCODE: ' SQLCODE */

                    $"COUNT *SQLCODE: {DB.SQLCODE}"
                    .Display();

                    /*" -4526- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4527- DISPLAY 'R3025-05 (ERRO - COUNT BILHETE EMPR)' */
                        _.Display($"R3025-05 (ERRO - COUNT BILHETE EMPR)");

                        /*" -4530- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                        $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                        .Display();

                        /*" -4531- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4532- END-IF */
                    }


                    /*" -4534- END-IF */
                }


                /*" -4535- IF WHOST-COUNT > 4 */

                if (WHOST_COUNT > 4)
                {

                    /*" -4536- MOVE 834 TO V0BILER-COD-ERRO */
                    _.Move(834, V0BILER_COD_ERRO);

                    /*" -4539- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4540- MOVE 'R' TO V0BILH-SITUACAO */
                    _.Move("R", V0BILH_SITUACAO);

                    /*" -4542- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4546- DISPLAY 'ULTRAPASSA LIMITE DE RISCO(10) BILHETE ' 'REJEITADO. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF ' ' V1BILP-CODPRODU ' ' WHOST-COUNT */

                    $"ULTRAPASSA LIMITE DE RISCO(10) BILHETE REJEITADO. {V0BILH_NUMBIL} {V0BILH_CODCLIEN} {V0CLIE_CGCCPF} {V1BILP_CODPRODU} {WHOST_COUNT}"
                    .Display();

                    /*" -4547- MOVE 'S' TO N88-VAI-LEITURA */
                    _.Move("S", N88_VAI_LEITURA);

                    /*" -4549- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4552- END-IF */
                }


                /*" -4553- IF VIND-DTNASC LESS ZEROES */

                if (VIND_DTNASC < 00)
                {

                    /*" -4554- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -4555- MOVE 11001 TO V0BILER-COD-ERRO */
                    _.Move(11001, V0BILER_COD_ERRO);

                    /*" -4556- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4557- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4558- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4560- END-IF */
                }


                /*" -4561- MOVE V0BILH-DTQITBCO TO WDATA-PROPOSTA */
                _.Move(V0BILH_DTQITBCO, AREA_DE_WORK.WDATA_PROPOSTA);

                /*" -4562- MOVE V0CLIE-DTNASC TO WDATA-NASCIMENTO */
                _.Move(V0CLIE_DTNASC, AREA_DE_WORK.WDATA_NASCIMENTO);

                /*" -4564- COMPUTE WWORK-IDADE = WDATA-AA-PROP - WDATA-AA-NASC */
                AREA_DE_WORK.WWORK_IDADE.Value = AREA_DE_WORK.WDATA_PROPOSTA.WDATA_AA_PROP - AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_AA_NASC;

                /*" -4565- IF WDATA-MM-NASC > WDATA-MM-PROP */

                if (AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_MM_NASC > AREA_DE_WORK.WDATA_PROPOSTA.WDATA_MM_PROP)
                {

                    /*" -4566- SUBTRACT 1 FROM WWORK-IDADE */
                    AREA_DE_WORK.WWORK_IDADE.Value = AREA_DE_WORK.WWORK_IDADE - 1;

                    /*" -4567- ELSE */
                }
                else
                {


                    /*" -4568- IF WDATA-MM-NASC EQUAL WDATA-MM-PROP */

                    if (AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_MM_NASC == AREA_DE_WORK.WDATA_PROPOSTA.WDATA_MM_PROP)
                    {

                        /*" -4569- IF WDATA-DD-NASC GREATER WDATA-DD-PROP */

                        if (AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_DD_NASC > AREA_DE_WORK.WDATA_PROPOSTA.WDATA_DD_PROP)
                        {

                            /*" -4570- SUBTRACT 1 FROM WWORK-IDADE */
                            AREA_DE_WORK.WWORK_IDADE.Value = AREA_DE_WORK.WWORK_IDADE - 1;

                            /*" -4571- END-IF */
                        }


                        /*" -4572- END-IF */
                    }


                    /*" -4574- END-IF */
                }


                /*" -4576- IF WWORK-IDADE LESS 18 OR WWORK-IDADE GREATER 80 */

                if (AREA_DE_WORK.WWORK_IDADE < 18 || AREA_DE_WORK.WWORK_IDADE > 80)
                {

                    /*" -4577- MOVE 11101 TO V0BILER-COD-ERRO */
                    _.Move(11101, V0BILER_COD_ERRO);

                    /*" -4578- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4579- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -4580- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4581- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4582- END-IF */
                }


                /*" -4600- END-IF */
            }


            /*" -4601- IF WS-SIVPF EQUAL 'S' */

            if (AREA_DE_WORK.WS_SIVPF == "S")
            {

                /*" -4602- GO TO R3000-10-CONTINUA */

                R3000_10_CONTINUA(); //GOTO
                return;

                /*" -4605- END-IF */
            }


            /*" -4606- IF WS-BILFOFA EQUAL 'S' */

            if (AREA_DE_WORK.WS_BILFOFA == "S")
            {

                /*" -4607- MOVE 'N' TO WS-BILFOFA */
                _.Move("N", AREA_DE_WORK.WS_BILFOFA);

                /*" -4608- GO TO R3000-10-CONTINUA */

                R3000_10_CONTINUA(); //GOTO
                return;

                /*" -4610- END-IF */
            }


            /*" -4613- MOVE '3030' TO WNR-EXEC-SQL. */
            _.Move("3030", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4623- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_9 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_9();

            /*" -4628- DISPLAY 'SEL BILHETE_FAIXA ' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"SEL BILHETE_FAIXA {V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -4629- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4630- DISPLAY 'R3030-00 (ERRO - SELECT BILHETE_FAIXA)... ' */
                _.Display($"R3030-00 (ERRO - SELECT BILHETE_FAIXA)... ");

                /*" -4631- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -4632- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4634- END-IF */
            }


            /*" -4635- IF V0BILFX-VERSAO NOT EQUAL 01 */

            if (V0BILFX_VERSAO != 01)
            {

                /*" -4636- MOVE V1RCAC-DATARCAP TO V0BILH-DTQITBCO */
                _.Move(V1RCAC_DATARCAP, V0BILH_DTQITBCO);

                /*" -4638- END-IF */
            }


            /*" -4640- IF (V0BILH-DTQITBCO < '1995-03-27' ) OR (V0BILH-DTQITBCO NOT EQUAL V1RCAC-DATARCAP) */

            if ((V0BILH_DTQITBCO < "1995-03-27") || (V0BILH_DTQITBCO != V1RCAC_DATARCAP))
            {

                /*" -4641- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -4642- PERFORM R3040-00-MONTA-V0BILHETE */

                R3040_00_MONTA_V0BILHETE_SECTION();

                /*" -4643- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -4644- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -4648- END-IF */
            }


            /*" -4650- IF V0BILH-RAMO EQUAL 82 AND VIND-DTNASC LESS ZEROES */

            if (V0BILH_RAMO == 82 && VIND_DTNASC < 00)
            {

                /*" -4652- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -4653- MOVE 11001 TO V0BILER-COD-ERRO */
                _.Move(11001, V0BILER_COD_ERRO);

                /*" -4654- PERFORM R3045-00-GRAVA-TAB-ERRO */

                R3045_00_GRAVA_TAB_ERRO_SECTION();

                /*" -4655- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -4656- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -4660- END-IF */
            }


            /*" -4661- IF V0BILH-RAMO EQUAL 82 */

            if (V0BILH_RAMO == 82)
            {

                /*" -4663- MOVE V0BILH-DTQITBCO TO WDATA-PROPOSTA */
                _.Move(V0BILH_DTQITBCO, AREA_DE_WORK.WDATA_PROPOSTA);

                /*" -4664- MOVE V0CLIE-DTNASC TO WDATA-NASCIMENTO */
                _.Move(V0CLIE_DTNASC, AREA_DE_WORK.WDATA_NASCIMENTO);

                /*" -4665- COMPUTE WWORK-IDADE = WDATA-AA-PROP - WDATA-AA-NASC */
                AREA_DE_WORK.WWORK_IDADE.Value = AREA_DE_WORK.WDATA_PROPOSTA.WDATA_AA_PROP - AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_AA_NASC;

                /*" -4666- IF WDATA-MM-NASC > WDATA-MM-PROP */

                if (AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_MM_NASC > AREA_DE_WORK.WDATA_PROPOSTA.WDATA_MM_PROP)
                {

                    /*" -4667- SUBTRACT 1 FROM WWORK-IDADE */
                    AREA_DE_WORK.WWORK_IDADE.Value = AREA_DE_WORK.WWORK_IDADE - 1;

                    /*" -4668- ELSE */
                }
                else
                {


                    /*" -4669- IF WDATA-MM-NASC EQUAL WDATA-MM-PROP */

                    if (AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_MM_NASC == AREA_DE_WORK.WDATA_PROPOSTA.WDATA_MM_PROP)
                    {

                        /*" -4670- IF WDATA-DD-NASC GREATER WDATA-DD-PROP */

                        if (AREA_DE_WORK.WDATA_NASCIMENTO.WDATA_DD_NASC > AREA_DE_WORK.WDATA_PROPOSTA.WDATA_DD_PROP)
                        {

                            /*" -4671- SUBTRACT 1 FROM WWORK-IDADE */
                            AREA_DE_WORK.WWORK_IDADE.Value = AREA_DE_WORK.WWORK_IDADE - 1;

                            /*" -4672- END-IF */
                        }


                        /*" -4673- END-IF */
                    }


                    /*" -4675- END-IF */
                }


                /*" -4678- IF WWORK-IDADE LESS 12 OR WWORK-IDADE GREATER 71 */

                if (AREA_DE_WORK.WWORK_IDADE < 12 || AREA_DE_WORK.WWORK_IDADE > 71)
                {

                    /*" -4679- MOVE 11101 TO V0BILER-COD-ERRO */
                    _.Move(11101, V0BILER_COD_ERRO);

                    /*" -4680- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4681- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -4682- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4683- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4684- END-IF */
                }


                /*" -4684- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R3000_10_CONTINUA */

            R3000_10_CONTINUA();

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-1 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_1()
        {
            /*" -3974- EXEC SQL SELECT FONTE, NRRCAP, VLRCAP, SITUACAO, OPERACAO INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP, :V2RCAP-VLRCAP, :V0RCAP-SITUACAO, :V0RCAP-OPERACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT END-EXEC */

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
            /*" -4691- COMPUTE WS-VALORDIF EQUAL V0BILH-VLRCAP - V2RCAP-VLRCAP */
            AREA_DE_WORK.WS_VALORDIF.Value = V0BILH_VLRCAP - V2RCAP_VLRCAP;

            /*" -4692- IF WS-VALORDIF LESS ZEROS */

            if (AREA_DE_WORK.WS_VALORDIF < 00)
            {

                /*" -4694- COMPUTE WS-VALORDIF EQUAL WS-VALORDIF * -1 */
                AREA_DE_WORK.WS_VALORDIF.Value = AREA_DE_WORK.WS_VALORDIF * -1;

                /*" -4696- END-IF */
            }


            /*" -4697- IF WS-VALORDIF GREATER WS-VLDIFE */

            if (AREA_DE_WORK.WS_VALORDIF > AREA_DE_WORK.WS_VLDIFE)
            {

                /*" -4698- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -4699- PERFORM R3040-00-MONTA-V0BILHETE */

                R3040_00_MONTA_V0BILHETE_SECTION();

                /*" -4700- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -4701- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -4703- END-IF */
            }


            /*" -4705- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4706- MOVE SPACES TO WFIM-V1COMIFENAE. */
            _.Move("", AREA_DE_WORK.WFIM_V1COMIFENAE);

            /*" -4708- MOVE V0BILH-NUMBIL TO V1COFE-NUMBIL. */
            _.Move(V0BILH_NUMBIL, V1COFE_NUMBIL);

            /*" -4715- PERFORM R3000_10_CONTINUA_DB_SELECT_1 */

            R3000_10_CONTINUA_DB_SELECT_1();

            /*" -4720- DISPLAY 'SEL V1COMISSAO_FENAE ' V1COFE-NUMBIL '*SQLCODE: ' SQLCODE */

            $"SEL V1COMISSAO_FENAE {V1COFE_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -4721- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4722- DISPLAY 'R3050-00 (SELECT V1COMISSAO_FENAE)...' */
                _.Display($"R3050-00 (SELECT V1COMISSAO_FENAE)...");

                /*" -4724- DISPLAY 'BILHETE: ' V0BILH-NUMBIL ' NAO ENCONTRADO ' V0BILH-COD-PRODUTO */

                $"BILHETE: {V0BILH_NUMBIL} NAO ENCONTRADO {V0BILH_COD_PRODUTO}"
                .Display();

                /*" -4725- DISPLAY 'BILHETE NAO SERA TRATADO PELO PROGR. CB0005B' */
                _.Display($"BILHETE NAO SERA TRATADO PELO PROGR. CB0005B");

                /*" -4726- MOVE '4' TO V0BILH-SITUACAO */
                _.Move("4", V0BILH_SITUACAO);

                /*" -4727- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -4728- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -4729- ELSE */
            }
            else
            {


                /*" -4730- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4731- DISPLAY 'R3050-00 (ERRO - SELECT V1COMISSAO_FENAE)...' */
                    _.Display($"R3050-00 (ERRO - SELECT V1COMISSAO_FENAE)...");

                    /*" -4732- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -4733- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4735- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -4736- END-IF */
                }


                /*" -4738- END-IF */
            }


            /*" -4741- MOVE '3055' TO WNR-EXEC-SQL. */
            _.Move("3055", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4746- PERFORM R3000_10_CONTINUA_DB_SELECT_2 */

            R3000_10_CONTINUA_DB_SELECT_2();

            /*" -4751- DISPLAY 'SEL V1AGENCIACEF ' V1COFE-AGECOBR '*SQLCODE: ' SQLCODE */

            $"SEL V1AGENCIACEF {V1COFE_AGECOBR}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -4752- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4753- MOVE 9999 TO V1COFE-AGECOBR */
                _.Move(9999, V1COFE_AGECOBR);

                /*" -4754- MOVE 999 TO V1ACEF-CODESCNEG */
                _.Move(999, V1ACEF_CODESCNEG);

                /*" -4758- PERFORM R3105-00-UPDATE-V1COMIS-FENAE */

                R3105_00_UPDATE_V1COMIS_FENAE_SECTION();

                /*" -4759- ELSE */
            }
            else
            {


                /*" -4760- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4761- DISPLAY 'R3055-00 (ERRO - SELECT V1AGENCIACEF)...' */
                    _.Display($"R3055-00 (ERRO - SELECT V1AGENCIACEF)...");

                    /*" -4762- DISPLAY 'BILHETE    : ' V0BILH-NUMBIL */
                    _.Display($"BILHETE    : {V0BILH_NUMBIL}");

                    /*" -4763- DISPLAY 'COD.AGENCIA: ' V1COFE-AGECOBR */
                    _.Display($"COD.AGENCIA: {V1COFE_AGECOBR}");

                    /*" -4764- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4765- END-IF */
                }


                /*" -4767- END-IF */
            }


            /*" -4770- MOVE '3060' TO WNR-EXEC-SQL. */
            _.Move("3060", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4775- PERFORM R3000_10_CONTINUA_DB_SELECT_3 */

            R3000_10_CONTINUA_DB_SELECT_3();

            /*" -4780- DISPLAY 'SEL V1MALHACEF ' V1ACEF-CODESCNEG '*SQLCODE: ' SQLCODE */

            $"SEL V1MALHACEF {V1ACEF_CODESCNEG}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -4783- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4788- PERFORM R3000_10_CONTINUA_DB_SELECT_4 */

                R3000_10_CONTINUA_DB_SELECT_4();

                /*" -4793- DISPLAY 'SEL ESCRITORIO_NEGOCIO ' V1ACEF-CODESCNEG '*SQLCODE: ' SQLCODE */

                $"SEL ESCRITORIO_NEGOCIO {V1ACEF_CODESCNEG}*SQLCODE: {DB.SQLCODE}"
                .Display();

                /*" -4794- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4800- DISPLAY 'NAO ACHOU NA V1MALHACEF - ALTERAR FONTE P/ 05 ' V1ACEF-CODESCNEG ' ' V0BILH-NUMBIL */

                    $"NAO ACHOU NA V1MALHACEF - ALTERAR FONTE P/ 05 {V1ACEF_CODESCNEG} {V0BILH_NUMBIL}"
                    .Display();

                    /*" -4801- MOVE 5 TO V1MCEF-COD-FONTE */
                    _.Move(5, V1MCEF_COD_FONTE);

                    /*" -4802- ELSE */
                }
                else
                {


                    /*" -4803- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4805- DISPLAY 'R3060-00 (ERRO SELECT ESCRITORIO_NEGOCIO)...' */
                        _.Display($"R3060-00 (ERRO SELECT ESCRITORIO_NEGOCIO)...");

                        /*" -4806- DISPLAY 'ESCNEG : ' V1ACEF-CODESCNEG */
                        _.Display($"ESCNEG : {V1ACEF_CODESCNEG}");

                        /*" -4807- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                        _.Display($"BILHETE: {V0BILH_NUMBIL}");

                        /*" -4808- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4809- END-IF */
                    }


                    /*" -4811- END-IF */
                }


                /*" -4812- ELSE */
            }
            else
            {


                /*" -4813- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4814- DISPLAY 'R3060-00 (ERRO SELECT V1MALHACEF)...' */
                    _.Display($"R3060-00 (ERRO SELECT V1MALHACEF)...");

                    /*" -4815- DISPLAY 'ESCNEG : ' V1ACEF-CODESCNEG */
                    _.Display($"ESCNEG : {V1ACEF_CODESCNEG}");

                    /*" -4816- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -4817- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4818- END-IF */
                }


                /*" -4820- END-IF */
            }


            /*" -4821- IF V1COFE-AGECOBR NOT EQUAL V0BILH-AGECOBR */

            if (V1COFE_AGECOBR != V0BILH_AGECOBR)
            {

                /*" -4822- MOVE V1COFE-AGECOBR TO V0BILH-AGECOBR */
                _.Move(V1COFE_AGECOBR, V0BILH_AGECOBR);

                /*" -4823- PERFORM R3095-00-UPDATE-V0BILHETE */

                R3095_00_UPDATE_V0BILHETE_SECTION();

                /*" -4825- END-IF */
            }


            /*" -4827- ADD V0BILFX-VALADT TO V0ADIA-VALADT. */
            V0ADIA_VALADT.Value = V0ADIA_VALADT + V0BILFX_VALADT;

            /*" -4828- IF V1MCEF-COD-FONTE NOT EQUAL V0BILH-FONTE */

            if (V1MCEF_COD_FONTE != V0BILH_FONTE)
            {

                /*" -4829- MOVE V1MCEF-COD-FONTE TO V0BILH-FONTE */
                _.Move(V1MCEF_COD_FONTE, V0BILH_FONTE);

                /*" -4830- PERFORM R3090-00-UPDATE-V0BILHETE */

                R3090_00_UPDATE_V0BILHETE_SECTION();

                /*" -4834- END-IF */
            }


            /*" -4835- MOVE V1ACEF-CODESCNEG TO V1COBI-COD-ESCNEG */
            _.Move(V1ACEF_CODESCNEG, V1COBI_COD_ESCNEG);

            /*" -4836- MOVE V0BILH-RAMO TO V1COBI-RAMO */
            _.Move(V0BILH_RAMO, V1COBI_RAMO);

            /*" -4838- MOVE V1COFE-DTQITBCO TO V1COBI-DTINIVIG. */
            _.Move(V1COFE_DTQITBCO, V1COBI_DTINIVIG);

            /*" -4841- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4853- PERFORM R3000_10_CONTINUA_DB_SELECT_5 */

            R3000_10_CONTINUA_DB_SELECT_5();

            /*" -4860- DISPLAY 'SEL V1COMERC_BILHETE ' V1COBI-COD-ESCNEG '/' V1COBI-RAMO '/' V1COBI-DTINIVIG '*SQLCODE: ' SQLCODE */

            $"SEL V1COMERC_BILHETE {V1COBI_COD_ESCNEG}/{V1COBI_RAMO}/{V1COBI_DTINIVIG}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -4861- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4862- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4863- MOVE 'S' TO WFIM-V1COMERC-BIL */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COMERC_BIL);

                    /*" -4864- ELSE */
                }
                else
                {


                    /*" -4865- DISPLAY 'R3100-00 (ERRO - SELECT V0COMERC_BILHETE.. ' */
                    _.Display($"R3100-00 (ERRO - SELECT V0COMERC_BILHETE.. ");

                    /*" -4868- DISPLAY 'ESCNEG   : ' V1COBI-COD-ESCNEG ' ' 'RAMO     : ' V1COBI-RAMO '  ' 'DTINIVIG ; ' V1COBI-DTINIVIG */

                    $"ESCNEG   : {V1COBI_COD_ESCNEG} RAMO     : {V1COBI_RAMO} DTINIVIG;{V1COBI_DTINIVIG}"
                    .Display();

                    /*" -4869- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4870- END-IF */
                }


                /*" -4872- END-IF */
            }


            /*" -4873- IF WFIM-V1COMERC-BIL NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1COMERC_BIL != "S")
            {

                /*" -4875- IF V0BILH-OPCAO-COBER EQUAL 1 AND V1COBI-COBERTURA1 EQUAL 'B' */

                if (V0BILH_OPCAO_COBER == 1 && V1COBI_COBERTURA1 == "B")
                {

                    /*" -4876- PERFORM R3110-00-INSERT-V0BIL-CC00396 */

                    R3110_00_INSERT_V0BIL_CC00396_SECTION();

                    /*" -4877- ELSE */
                }
                else
                {


                    /*" -4879- IF V0BILH-OPCAO-COBER EQUAL 2 AND V1COBI-COBERTURA2 EQUAL 'B' */

                    if (V0BILH_OPCAO_COBER == 2 && V1COBI_COBERTURA2 == "B")
                    {

                        /*" -4880- PERFORM R3110-00-INSERT-V0BIL-CC00396 */

                        R3110_00_INSERT_V0BIL_CC00396_SECTION();

                        /*" -4881- ELSE */
                    }
                    else
                    {


                        /*" -4883- IF V0BILH-OPCAO-COBER EQUAL 3 AND V1COBI-COBERTURA3 EQUAL 'B' */

                        if (V0BILH_OPCAO_COBER == 3 && V1COBI_COBERTURA3 == "B")
                        {

                            /*" -4884- PERFORM R3110-00-INSERT-V0BIL-CC00396 */

                            R3110_00_INSERT_V0BIL_CC00396_SECTION();

                            /*" -4885- END-IF */
                        }


                        /*" -4886- END-IF */
                    }


                    /*" -4887- END-IF */
                }


                /*" -4889- END-IF */
            }


            /*" -5106- MOVE '3120' TO WNR-EXEC-SQL. */
            _.Move("3120", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5108- IF V0BILH-NUM-APO-ANT EQUAL ZEROS AND V1BILP-CODPRODU NOT EQUAL 3721 */

            if (V0BILH_NUM_APO_ANT == 00 && V1BILP_CODPRODU != 3721)
            {

                /*" -5109- MOVE 1 TO WS-COD-CRITICA */
                _.Move(1, WS_COD_CRITICA);

                /*" -5111- PERFORM R8600-00-CONS-COD-CRITICA */

                R8600_00_CONS_COD_CRITICA_SECTION();

                /*" -5112- IF VG001-IND-EXISTE EQUAL 'N' */

                if (SPVG001V.VG001_IND_EXISTE == "N")
                {

                    /*" -5113- MOVE '%' TO N88-VAI-LEITURA */
                    _.Move("%", N88_VAI_LEITURA);

                    /*" -5114- PERFORM R8500-00-PROCURA-RISCO-PROP */

                    R8500_00_PROCURA_RISCO_PROP_SECTION();

                    /*" -5115- IF VAI-LEITURA */

                    if (N88_VAI_LEITURA["VAI_LEITURA"])
                    {

                        /*" -5116- GO TO R3000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                        return;

                        /*" -5117- END-IF */
                    }


                    /*" -5119- ELSE */
                }
                else
                {


                    /*" -5120- IF LK-VG001-S-STA-CRITICA NOT EQUAL '6' */

                    if (SPVG001W.LK_VG001_S_STA_CRITICA != "6")
                    {

                        /*" -5124- DISPLAY 'BILHETE EM ANALISE DE CRITICA.......: ' V0BILH-NUMBIL ' >> ' V0CONV-NUM-PROPOSTA-SIVPF ' >> ' LK-VG001-S-STA-CRITICA */

                        $"BILHETE EM ANALISE DE CRITICA.......: {V0BILH_NUMBIL} >> {V0CONV_NUM_PROPOSTA_SIVPF} >> {SPVG001W.LK_VG001_S_STA_CRITICA}"
                        .Display();

                        /*" -5125- MOVE '1' TO V0BILH-SITUACAO */
                        _.Move("1", V0BILH_SITUACAO);

                        /*" -5126- ADD 1 TO WS-QT-EM-CRITICA */
                        WS_QT_EM_CRITICA.Value = WS_QT_EM_CRITICA + 1;

                        /*" -5127- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -5128- MOVE 'S' TO N88-VAI-LEITURA */
                        _.Move("S", N88_VAI_LEITURA);

                        /*" -5130- GO TO R3000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                        return;

                        /*" -5131- ELSE */
                    }
                    else
                    {


                        /*" -5134- DISPLAY 'LIBERADO PARA EMISSAO APOS ANALISE..: ' V0BILH-NUMBIL ' >> ' V0CONV-NUM-PROPOSTA-SIVPF */

                        $"LIBERADO PARA EMISSAO APOS ANALISE..: {V0BILH_NUMBIL} >> {V0CONV_NUM_PROPOSTA_SIVPF}"
                        .Display();

                        /*" -5135- ADD 1 TO WS-QT-LIBERADO-EMISSAO */
                        WS_QT_LIBERADO_EMISSAO.Value = WS_QT_LIBERADO_EMISSAO + 1;

                        /*" -5136- END-IF */
                    }


                    /*" -5137- END-IF */
                }


                /*" -5139- ELSE */
            }
            else
            {


                /*" -5144- IF V1BILP-CODPRODU EQUAL 3721 AND (PRPFIDEL-ORIG-PROPOSTA NOT EQUAL 15 AND 13 AND 22 AND 34) */

                if (V1BILP_CODPRODU == 3721 && (!PRPFIDEL_ORIG_PROPOSTA.In("15", "13", "22", "34")))
                {

                    /*" -5146- DISPLAY 'CRITICA DE PEPS >> ' V0BILH-NUMBIL ' >> ' V1BILP-CODPRODU */

                    $"CRITICA DE PEPS >> {V0BILH_NUMBIL} >> {V1BILP_CODPRODU}"
                    .Display();

                    /*" -5149- MOVE SPACES TO WS-CLIENTE-PEP WS-PEP-AVALIADO */
                    _.Move("", AREA_DE_WORK.WS_CLIENTE_PEP, AREA_DE_WORK.WS_PEP_AVALIADO);

                    /*" -5151- PERFORM R9998-00-VERIFICA-PEP */

                    R9998_00_VERIFICA_PEP_SECTION();

                    /*" -5153- IF WS-CLIENTE-PEP EQUAL 'S' AND WS-PEP-AVALIADO EQUAL 'N' */

                    if (AREA_DE_WORK.WS_CLIENTE_PEP == "S" && AREA_DE_WORK.WS_PEP_AVALIADO == "N")
                    {

                        /*" -5154- DISPLAY ' DESPREZADO PEPS..........  ' V0BILH-NUMBIL */
                        _.Display($" DESPREZADO PEPS..........  {V0BILH_NUMBIL}");

                        /*" -5155- MOVE 'G' TO V0BILH-SITUACAO */
                        _.Move("G", V0BILH_SITUACAO);

                        /*" -5156- MOVE 'CLIENTE PEP.' TO VG078-DES-ANDAMENTO-TEXT */
                        _.Move("CLIENTE PEP.", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                        /*" -5157- PERFORM R9997-00-INSERE-ANDAMENTO */

                        R9997_00_INSERE_ANDAMENTO_SECTION();

                        /*" -5159- PERFORM R3020-00-UPDATE-V0BILHETE */

                        R3020_00_UPDATE_V0BILHETE_SECTION();

                        /*" -5160- PERFORM R8650-00-GRAVA-RISCO-PEPS */

                        R8650_00_GRAVA_RISCO_PEPS_SECTION();

                        /*" -5161- MOVE 'S' TO N88-VAI-LEITURA */
                        _.Move("S", N88_VAI_LEITURA);

                        /*" -5163- GO TO R3000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                        return;

                        /*" -5164- END-IF */
                    }


                    /*" -5165- END-IF */
                }


                /*" -5170- END-IF */
            }


            /*" -5172- PERFORM R3001-00-LER-PROPAUTOM */

            R3001_00_LER_PROPAUTOM_SECTION();

            /*" -5174- PERFORM R3010-00-LER-ENDOSSO */

            R3010_00_LER_ENDOSSO_SECTION();

            /*" -5176- PERFORM R3015-00-ATUALIZA-PROPAUTOM */

            R3015_00_ATUALIZA_PROPAUTOM_SECTION();

            /*" -5177- MOVE '9' TO V0BILH-SITUACAO */
            _.Move("9", V0BILH_SITUACAO);

            /*" -5179- ADD 1 TO WWORK-NUM-ITENS */
            AREA_DE_WORK.WWORK_NUM_ITENS.Value = AREA_DE_WORK.WWORK_NUM_ITENS + 1;

            /*" -5182- MOVE '3180' TO WNR-EXEC-SQL */
            _.Move("3180", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5189- PERFORM R3000_10_CONTINUA_DB_UPDATE_1 */

            R3000_10_CONTINUA_DB_UPDATE_1();

            /*" -5194- DISPLAY 'UPD V0BILHETE1' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"UPD V0BILHETE1{V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5195- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5196- DISPLAY 'R3180-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3180-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5197- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -5198- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5200- END-IF */
            }


            /*" -5205- ADD +1 TO WPROC-BILHETES WACC-PROCESSADOS */
            AREA_DE_WORK.WPROC_BILHETES.Value = AREA_DE_WORK.WPROC_BILHETES + +1;
            AREA_DE_WORK.WACC_PROCESSADOS.Value = AREA_DE_WORK.WACC_PROCESSADOS + +1;

            /*" -5208- MOVE '3190' TO WNR-EXEC-SQL. */
            _.Move("3190", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5209- MOVE V0BILH-NUMBIL TO V0COFE-NUMBIL. */
            _.Move(V0BILH_NUMBIL, V0COFE_NUMBIL);

            /*" -5210- MOVE V0BILH-AGECOBR TO V0COFE-AGECOBR */
            _.Move(V0BILH_AGECOBR, V0COFE_AGECOBR);

            /*" -5211- MOVE V0BILH-NUM-MATR TO V0COFE-NUM-MATR */
            _.Move(V0BILH_NUM_MATR, V0COFE_NUM_MATR);

            /*" -5212- MOVE V0BILH-AGENCIA-DEB TO V0COFE-AGENCIA-DEB */
            _.Move(V0BILH_AGENCIA_DEB, V0COFE_AGENCIA_DEB);

            /*" -5213- MOVE V0BILH-OPERACAO-DEB TO V0COFE-OPERACAO-DEB */
            _.Move(V0BILH_OPERACAO_DEB, V0COFE_OPERACAO_DEB);

            /*" -5214- MOVE V0BILH-NUMCTA-DEB TO V0COFE-NUMCTA-DEB */
            _.Move(V0BILH_NUMCTA_DEB, V0COFE_NUMCTA_DEB);

            /*" -5215- MOVE V0BILH-DIGCTA-DEB TO V0COFE-DIGCTA-DEB */
            _.Move(V0BILH_DIGCTA_DEB, V0COFE_DIGCTA_DEB);

            /*" -5216- MOVE SPACES TO V0COFE-NOME-SIND */
            _.Move("", V0COFE_NOME_SIND);

            /*" -5218- MOVE '9' TO V0COFE-SITUACAO. */
            _.Move("9", V0COFE_SITUACAO);

            /*" -5230- PERFORM R3000_10_CONTINUA_DB_UPDATE_2 */

            R3000_10_CONTINUA_DB_UPDATE_2();

            /*" -5235- DISPLAY 'UPD V0COMISSAO_FENAE ' V0COFE-NUMBIL '*SQLCODE: ' SQLCODE */

            $"UPD V0COMISSAO_FENAE {V0COFE_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5236- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5237- DISPLAY 'R3190-00 (ERRO - UPDATE V0COMISSAO_FENAE)...' */
                _.Display($"R3190-00 (ERRO - UPDATE V0COMISSAO_FENAE)...");

                /*" -5238- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -5239- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5241- END-IF */
            }


            /*" -5243- ADD +1 TO AC-U-V0COMIFENAE */
            AREA_DE_WORK.AC_U_V0COMIFENAE.Value = AREA_DE_WORK.AC_U_V0COMIFENAE + +1;

            /*" -5245- PERFORM R3200-00-BAIXA-RCAP */

            R3200_00_BAIXA_RCAP_SECTION();

            /*" -5248- MOVE '3210' TO WNR-EXEC-SQL */
            _.Move("3210", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5258- PERFORM R3000_10_CONTINUA_DB_UPDATE_3 */

            R3000_10_CONTINUA_DB_UPDATE_3();

            /*" -5264- DISPLAY 'UPD V0RCAP ' V0RCAP-FONTE '/' V0RCAP-NRRCAP '*SQLCODE: ' SQLCODE */

            $"UPD V0RCAP {V0RCAP_FONTE}/{V0RCAP_NRRCAP}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5265- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5266- DISPLAY 'R3210-00 (ERRO - UPDATE V0RCAP)...' */
                _.Display($"R3210-00 (ERRO - UPDATE V0RCAP)...");

                /*" -5269- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0RCAP-FONTE '  ' 'NRRCAP: ' V0RCAP-NRRCAP */

                $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0RCAP_FONTE}  NRRCAP: {V0RCAP_NRRCAP}"
                .Display();

                /*" -5270- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5272- END-IF */
            }


            /*" -5277- ADD 1 TO AC-U-V0RCAP */
            AREA_DE_WORK.AC_U_V0RCAP.Value = AREA_DE_WORK.AC_U_V0RCAP + 1;

            /*" -5280- MOVE '3220' TO WNR-EXEC-SQL. */
            _.Move("3220", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5287- PERFORM R3000_10_CONTINUA_DB_SELECT_6 */

            R3000_10_CONTINUA_DB_SELECT_6();

            /*" -5292- DISPLAY 'SEL V0CLIENTE ' V0BILH-CODCLIEN '*SQLCODE: ' SQLCODE */

            $"SEL V0CLIENTE {V0BILH_CODCLIEN}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5293- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5294- DISPLAY 'R3220-00 - ERRO SELECT V0CLIENTE ' */
                _.Display($"R3220-00 - ERRO SELECT V0CLIENTE ");

                /*" -5295- DISPLAY 'BILHETE ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN */

                $"BILHETE {V0BILH_NUMBIL} {V0BILH_CODCLIEN}"
                .Display();

                /*" -5296- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5298- END-IF */
            }


            /*" -5301- MOVE '3230' TO WNR-EXEC-SQL. */
            _.Move("3230", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5303- MOVE V0BILH-CGCCPF TO V1CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V1CROT_CGCCPF);

            /*" -5316- PERFORM R3000_10_CONTINUA_DB_SELECT_7 */

            R3000_10_CONTINUA_DB_SELECT_7();

            /*" -5321- DISPLAY 'SEL V1CLIENTE_CROT ' V0BILH-CGCCPF '*SQLCODE: ' SQLCODE */

            $"SEL V1CLIENTE_CROT {V0BILH_CGCCPF}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5322- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -5323- DISPLAY 'PROBLEMAS DE LEITURA CREDITO ROTATIVO' */
                _.Display($"PROBLEMAS DE LEITURA CREDITO ROTATIVO");

                /*" -5324- DISPLAY 'CODIGO DE ERRO ... ' SQLCODE */
                _.Display($"CODIGO DE ERRO ... {DB.SQLCODE}");

                /*" -5325- DISPLAY 'NR. BILHETE    ... ' V0BILH-NUMBIL */
                _.Display($"NR. BILHETE    ... {V0BILH_NUMBIL}");

                /*" -5326- DISPLAY 'NR. CGCCPF     ... ' V0BILH-CGCCPF */
                _.Display($"NR. CGCCPF     ... {V0BILH_CGCCPF}");

                /*" -5327- DISPLAY 'NAO FOI INCLUIDO NA TAB. CLIENTE_CROT' */
                _.Display($"NAO FOI INCLUIDO NA TAB. CLIENTE_CROT");

                /*" -5328- DISPLAY 'BILHETE EMITIDO. PROCESSAMENTO CONTINUA' */
                _.Display($"BILHETE EMITIDO. PROCESSAMENTO CONTINUA");

                /*" -5330- END-IF */
            }


            /*" -5331- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5332- IF V0BILH-RAMO EQUAL 82 */

                if (V0BILH_RAMO == 82)
                {

                    /*" -5333- PERFORM R3240-00-UPDATE-CROT-AP */

                    R3240_00_UPDATE_CROT_AP_SECTION();

                    /*" -5334- ELSE */
                }
                else
                {


                    /*" -5335- PERFORM R3250-00-UPDATE-CROT-RES */

                    R3250_00_UPDATE_CROT_RES_SECTION();

                    /*" -5336- END-IF */
                }


                /*" -5337- ELSE */
            }
            else
            {


                /*" -5338- IF V0BILH-RAMO EQUAL 82 */

                if (V0BILH_RAMO == 82)
                {

                    /*" -5339- MOVE 'S' TO V0CROT-BILH-AP */
                    _.Move("S", V0CROT_BILH_AP);

                    /*" -5340- MOVE 'N' TO V0CROT-BILH-RES */
                    _.Move("N", V0CROT_BILH_RES);

                    /*" -5341- ELSE */
                }
                else
                {


                    /*" -5342- MOVE 'N' TO V0CROT-BILH-AP */
                    _.Move("N", V0CROT_BILH_AP);

                    /*" -5343- MOVE 'S' TO V0CROT-BILH-RES */
                    _.Move("S", V0CROT_BILH_RES);

                    /*" -5344- END-IF */
                }


                /*" -5345- PERFORM R3260-00-INSERT-V0CLIEN-CROT */

                R3260_00_INSERT_V0CLIEN_CROT_SECTION();

                /*" -5347- END-IF */
            }


            /*" -5347- . */

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-1 */
        public void R3000_10_CONTINUA_DB_SELECT_1()
        {
            /*" -4715- EXEC SQL SELECT AGECOBR, DTQITBCO INTO :V1COFE-AGECOBR, :V1COFE-DTQITBCO FROM SEGUROS.V1COMISSAO_FENAE WHERE NUMBIL = :V1COFE-NUMBIL END-EXEC */

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
            /*" -4039- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :WHOST-NRRCAP AND NRRCAPCO = 0 AND OPERACAO = :V0RCAP-OPERACAO AND SITUACAO = '0' END-EXEC. */

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
            /*" -4746- EXEC SQL SELECT COD_ESCNEG INTO :V1ACEF-CODESCNEG FROM SEGUROS.V1AGENCIACEF WHERE COD_AGENCIA = :V1COFE-AGECOBR END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-3 */
        public void R3000_10_CONTINUA_DB_SELECT_3()
        {
            /*" -4775- EXEC SQL SELECT COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.V1MALHACEF WHERE COD_SUREG = :V1ACEF-CODESCNEG END-EXEC. */

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
        /*" R3000-10-CONTINUA-DB-UPDATE-1 */
        public void R3000_10_CONTINUA_DB_UPDATE_1()
        {
            /*" -5189- EXEC SQL UPDATE SEGUROS.V0BILHETE SET NUM_APOLICE = :V0APOL-NUM-APOL, SITUACAO = :V0BILH-SITUACAO, COD_USUARIO = 'CB0005B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC */

            var r3000_10_CONTINUA_DB_UPDATE_1_Update1 = new R3000_10_CONTINUA_DB_UPDATE_1_Update1()
            {
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3000_10_CONTINUA_DB_UPDATE_1_Update1.Execute(r3000_10_CONTINUA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-3 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_3()
        {
            /*" -4083- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.CLIENTES A , SEGUROS.BILHETE B , SEGUROS.ENDOSSOS C , SEGUROS.CONVERSAO_SICOB D WHERE A.CGCCPF = :V0CLIE-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.SITUACAO = '9' AND C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_ENDOSSO = 0 AND C.DATA_TERVIGENCIA > CURRENT DATE AND D.NUM_SICOB = B.NUM_BILHETE AND C.COD_PRODUTO = :V1BILP-CODPRODU WITH UR END-EXEC */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1()
            {
                V1BILP_CODPRODU = V1BILP_CODPRODU.ToString(),
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-UPDATE-2 */
        public void R3000_10_CONTINUA_DB_UPDATE_2()
        {
            /*" -5230- EXEC SQL UPDATE SEGUROS.V0COMISSAO_FENAE SET AGECOBR = :V0COFE-AGECOBR , NUM_MATRICULA = :V0COFE-NUM-MATR , COD_AGENCIA_DEB = :V0COFE-AGENCIA-DEB , OPERACAO_DEB = :V0COFE-OPERACAO-DEB , NUM_CONTA_DEB = :V0COFE-NUMCTA-DEB , DIG_CONTA_DEB = :V0COFE-DIGCTA-DEB , NOM_SINDICO = :V0COFE-NOME-SIND , SITUACAO = :V0COFE-SITUACAO , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0COFE-NUMBIL END-EXEC */

            var r3000_10_CONTINUA_DB_UPDATE_2_Update1 = new R3000_10_CONTINUA_DB_UPDATE_2_Update1()
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

            R3000_10_CONTINUA_DB_UPDATE_2_Update1.Execute(r3000_10_CONTINUA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-4 */
        public void R3000_10_CONTINUA_DB_SELECT_4()
        {
            /*" -4788- EXEC SQL SELECT COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.ESCRITORIO_NEGOCIO WHERE COD_ESCNEG = :V1ACEF-CODESCNEG END-EXEC */

            var r3000_10_CONTINUA_DB_SELECT_4_Query1 = new R3000_10_CONTINUA_DB_SELECT_4_Query1()
            {
                V1ACEF_CODESCNEG = V1ACEF_CODESCNEG.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_4_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-UPDATE-3 */
        public void R3000_10_CONTINUA_DB_UPDATE_3()
        {
            /*" -5258- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :V0APOL-NUM-APOL , NRENDOS = 0, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC */

            var r3000_10_CONTINUA_DB_UPDATE_3_Update1 = new R3000_10_CONTINUA_DB_UPDATE_3_Update1()
            {
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R3000_10_CONTINUA_DB_UPDATE_3_Update1.Execute(r3000_10_CONTINUA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R3001-00-LER-PROPAUTOM-SECTION */
        private void R3001_00_LER_PROPAUTOM_SECTION()
        {
            /*" -5357- DISPLAY 'R3001-00-LER-PROPAUTOM' */
            _.Display($"R3001-00-LER-PROPAUTOM");

            /*" -5360- MOVE '3001' TO WNR-EXEC-SQL */
            _.Move("3001", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5365- PERFORM R3001_00_LER_PROPAUTOM_DB_SELECT_1 */

            R3001_00_LER_PROPAUTOM_DB_SELECT_1();

            /*" -5370- DISPLAY 'SEL V1FONTE ' V0BILH-FONTE '*SQLCODE: ' SQLCODE */

            $"SEL V1FONTE {V0BILH_FONTE}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5371- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5372- DISPLAY 'R3172-00 (ERRO - SELECT V1FONTE)...' */
                _.Display($"R3172-00 (ERRO - SELECT V1FONTE)...");

                /*" -5373- DISPLAY ' FONTE = ' V0BILH-FONTE */
                _.Display($" FONTE = {V0BILH_FONTE}");

                /*" -5374- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5376- END-IF */
            }


            /*" -5379- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1 */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -5379- . */

        }

        [StopWatch]
        /*" R3001-00-LER-PROPAUTOM-DB-SELECT-1 */
        public void R3001_00_LER_PROPAUTOM_DB_SELECT_1()
        {
            /*" -5365- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0BILH-FONTE END-EXEC */

            var r3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1 = new R3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1()
            {
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            var executed_1 = R3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1.Execute(r3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-5 */
        public void R3000_10_CONTINUA_DB_SELECT_5()
        {
            /*" -4853- EXEC SQL SELECT COBERTURA1 , COBERTURA2 , COBERTURA3 INTO :V1COBI-COBERTURA1 , :V1COBI-COBERTURA2 , :V1COBI-COBERTURA3 FROM SEGUROS.V1COMERC_BILHETE WHERE COD_ESCNEG = :V1COBI-COD-ESCNEG AND RAMO = :V1COBI-RAMO AND DTINIVIG <= :V1COBI-DTINIVIG AND DTTERVIG >= :V1COBI-DTINIVIG END-EXEC */

            var r3000_10_CONTINUA_DB_SELECT_5_Query1 = new R3000_10_CONTINUA_DB_SELECT_5_Query1()
            {
                V1COBI_COD_ESCNEG = V1COBI_COD_ESCNEG.ToString(),
                V1COBI_DTINIVIG = V1COBI_DTINIVIG.ToString(),
                V1COBI_RAMO = V1COBI_RAMO.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_5_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COBI_COBERTURA1, V1COBI_COBERTURA1);
                _.Move(executed_1.V1COBI_COBERTURA2, V1COBI_COBERTURA2);
                _.Move(executed_1.V1COBI_COBERTURA3, V1COBI_COBERTURA3);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-4 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_4()
        {
            /*" -4117- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.CLIENTES A , SEGUROS.BILHETE B , SEGUROS.ENDOSSOS C WHERE A.CGCCPF = :V0CLIE-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.SITUACAO = '9' AND C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_ENDOSSO = 0 AND C.DATA_TERVIGENCIA > CURRENT DATE AND C.COD_PRODUTO = :V1BILP-CODPRODU WITH UR END-EXEC */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1()
            {
                V1BILP_CODPRODU = V1BILP_CODPRODU.ToString(),
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-6 */
        public void R3000_10_CONTINUA_DB_SELECT_6()
        {
            /*" -5287- EXEC SQL SELECT CGCCPF, NOME_RAZAO INTO :V0BILH-CGCCPF, :V0BILH-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0BILH-CODCLIEN END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_6_Query1 = new R3000_10_CONTINUA_DB_SELECT_6_Query1()
            {
                V0BILH_CODCLIEN = V0BILH_CODCLIEN.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_6_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_CGCCPF, V0BILH_CGCCPF);
                _.Move(executed_1.V0BILH_NOME, V0BILH_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3001_99_SAIDA*/

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-7 */
        public void R3000_10_CONTINUA_DB_SELECT_7()
        {
            /*" -5316- EXEC SQL SELECT CGCCPF , BILH_AP , BILH_RES , BILH_VDAZUL , DTMOVABE INTO :V1CROT-CGCCPF , :V1CROT-BILH-AP , :V1CROT-BILH-RES , :V1CROT-BILH-VDAZUL , :V1CROT-DTMOVABE FROM SEGUROS.V1CLIENTE_CROT WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC */

            var r3000_10_CONTINUA_DB_SELECT_7_Query1 = new R3000_10_CONTINUA_DB_SELECT_7_Query1()
            {
                V0BILH_CGCCPF = V0BILH_CGCCPF.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_7_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_7_Query1);
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
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-5 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_5()
        {
            /*" -4339- EXEC SQL SELECT SUM(E.VAL_COBERTURA_IX) INTO :WS002-VAL-COB-IX:VIND-ACUM-RISCO FROM SEGUROS.CLIENTES A , SEGUROS.BILHETE B , SEGUROS.ENDOSSOS C , SEGUROS.CONVERSAO_SICOB D , SEGUROS.BILHETE_COBERTURA E WHERE A.CGCCPF = :V0CLIE-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.SITUACAO = '9' AND C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_ENDOSSO = 0 AND C.DATA_TERVIGENCIA > CURRENT DATE AND D.NUM_SICOB = B.NUM_BILHETE AND E.RAMO_COBERTURA = B.RAMO AND E.COD_PRODUTO = C.COD_PRODUTO AND E.COD_OPCAO_PLANO = B.OPC_COBERTURA AND E.DATA_INIVIGENCIA <= B.DATA_VENDA AND E.DATA_TERVIGENCIA >= B.DATA_VENDA AND C.COD_PRODUTO IN (8144, 8145, 8146, 8147, 8148, 8149, 8150, :JVPRD8144, :JVPRD8145, :JVPRD8146, :JVPRD8147, :JVPRD8148, :JVPRD8149, :JVPRD8150) WITH UR END-EXEC */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1()
            {
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
                JVPRD8144 = JVBKINCL.JV_PRODUTOS.JVPRD8144.ToString(),
                JVPRD8145 = JVBKINCL.JV_PRODUTOS.JVPRD8145.ToString(),
                JVPRD8146 = JVBKINCL.JV_PRODUTOS.JVPRD8146.ToString(),
                JVPRD8147 = JVBKINCL.JV_PRODUTOS.JVPRD8147.ToString(),
                JVPRD8148 = JVBKINCL.JV_PRODUTOS.JVPRD8148.ToString(),
                JVPRD8149 = JVBKINCL.JV_PRODUTOS.JVPRD8149.ToString(),
                JVPRD8150 = JVBKINCL.JV_PRODUTOS.JVPRD8150.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS002_VAL_COB_IX, WS002_ACUMULADORES.WS002_VAL_COB_IX);
                _.Move(executed_1.VIND_ACUM_RISCO, VIND_ACUM_RISCO);
            }


        }

        [StopWatch]
        /*" R3010-00-LER-ENDOSSO-SECTION */
        private void R3010_00_LER_ENDOSSO_SECTION()
        {
            /*" -5389- MOVE '3010' TO WNR-EXEC-SQL */
            _.Move("3010", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5392- DISPLAY 'R3010-00-LER-ENDOSSO' */
            _.Display($"R3010-00-LER-ENDOSSO");

            /*" -5398- PERFORM R3010_00_LER_ENDOSSO_DB_SELECT_1 */

            R3010_00_LER_ENDOSSO_DB_SELECT_1();

            /*" -5403- DISPLAY 'SEL V1FONTE ' V0BILH-FONTE '*SQLCODE: ' SQLCODE */

            $"SEL V1FONTE {V0BILH_FONTE}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5404- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5405- DISPLAY '(PROPOSTA DUPLICADO NA ENDOSSO)... ' */
                _.Display($"(PROPOSTA DUPLICADO NA ENDOSSO)... ");

                /*" -5406- DISPLAY ' FONTE    - ' V0BILH-FONTE */
                _.Display($" FONTE    - {V0BILH_FONTE}");

                /*" -5407- DISPLAY ' PROPOSTA - ' V1FONT-PROPAUTOM */
                _.Display($" PROPOSTA - {V1FONT_PROPAUTOM}");

                /*" -5409- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1 */
                V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

                /*" -5410- GO TO R3010-00-LER-ENDOSSO */
                new Task(() => R3010_00_LER_ENDOSSO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -5411- ELSE */
            }
            else
            {


                /*" -5413- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -5414- ELSE */
                }
                else
                {


                    /*" -5415- DISPLAY 'R3173-00 (ERRO - SELECT V1ENDOSSO)... ' */
                    _.Display($"R3173-00 (ERRO - SELECT V1ENDOSSO)... ");

                    /*" -5416- DISPLAY ' FONTE    - ' V0BILH-FONTE */
                    _.Display($" FONTE    - {V0BILH_FONTE}");

                    /*" -5417- DISPLAY ' PROPOSTA - ' V1FONT-PROPAUTOM */
                    _.Display($" PROPOSTA - {V1FONT_PROPAUTOM}");

                    /*" -5418- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5419- END-IF */
                }


                /*" -5421- END-IF */
            }


            /*" -5421- . */

        }

        [StopWatch]
        /*" R3010-00-LER-ENDOSSO-DB-SELECT-1 */
        public void R3010_00_LER_ENDOSSO_DB_SELECT_1()
        {
            /*" -5398- EXEC SQL SELECT NRPROPOS INTO :V0ENDO-NRPROPOS FROM SEGUROS.V1ENDOSSO WHERE FONTE = :V0BILH-FONTE AND NRPROPOS = :V1FONT-PROPAUTOM END-EXEC */

            var r3010_00_LER_ENDOSSO_DB_SELECT_1_Query1 = new R3010_00_LER_ENDOSSO_DB_SELECT_1_Query1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            var executed_1 = R3010_00_LER_ENDOSSO_DB_SELECT_1_Query1.Execute(r3010_00_LER_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRPROPOS, V0ENDO_NRPROPOS);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-6 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_6()
        {
            /*" -4424- EXEC SQL SELECT SUM(E.VAL_COBERTURA_IX) INTO :WS002-VAL-COB-IX:VIND-ACUM-RISCO FROM SEGUROS.CLIENTES A , SEGUROS.BILHETE B , SEGUROS.ENDOSSOS C , SEGUROS.CONVERSAO_SICOB D , SEGUROS.BILHETE_COBERTURA E WHERE A.CGCCPF = :V0CLIE-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.SITUACAO = '9' AND C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_ENDOSSO = 0 AND C.DATA_TERVIGENCIA > CURRENT DATE AND D.NUM_SICOB = B.NUM_BILHETE AND E.RAMO_COBERTURA = B.RAMO AND E.COD_PRODUTO = C.COD_PRODUTO AND E.COD_OPCAO_PLANO = B.OPC_COBERTURA AND E.DATA_INIVIGENCIA <= B.DATA_VENDA AND E.DATA_TERVIGENCIA >= B.DATA_VENDA AND C.COD_PRODUTO IN (8521, 8528, 8529, 8533, 8534) WITH UR END-EXEC */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_6_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_6_Query1()
            {
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_6_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS002_VAL_COB_IX, WS002_ACUMULADORES.WS002_VAL_COB_IX);
                _.Move(executed_1.VIND_ACUM_RISCO, VIND_ACUM_RISCO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-7 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_7()
        {
            /*" -4494- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.CLIENTES A , SEGUROS.BILHETE B , SEGUROS.ENDOSSOS C , SEGUROS.CONVERSAO_SICOB D WHERE A.CGCCPF = :V0CLIE-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.SITUACAO = '9' AND C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_ENDOSSO = 0 AND C.DATA_TERVIGENCIA > CURRENT DATE AND D.NUM_SICOB = B.NUM_BILHETE AND C.COD_PRODUTO IN (8530, 8531, 8532) WITH UR END-EXEC */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1()
            {
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }

        [StopWatch]
        /*" R3015-00-ATUALIZA-PROPAUTOM-SECTION */
        private void R3015_00_ATUALIZA_PROPAUTOM_SECTION()
        {
            /*" -5431- MOVE '3015' TO WNR-EXEC-SQL. */
            _.Move("3015", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5434- DISPLAY 'R3015-00-ATUALIZA-PROPAUTOM' */
            _.Display($"R3015-00-ATUALIZA-PROPAUTOM");

            /*" -5438- PERFORM R3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1 */

            R3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1();

            /*" -5443- DISPLAY 'UPD V0FONTE ' V0BILH-FONTE '*SQLCODE: ' SQLCODE */

            $"UPD V0FONTE {V0BILH_FONTE}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5444- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5445- DISPLAY 'R3173-00 (ERRO - UPDATE V0FONTE)...' */
                _.Display($"R3173-00 (ERRO - UPDATE V0FONTE)...");

                /*" -5446- DISPLAY ' FONTE = ' V0BILH-FONTE */
                _.Display($" FONTE = {V0BILH_FONTE}");

                /*" -5447- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5449- END-IF */
            }


            /*" -5449- . */

        }

        [StopWatch]
        /*" R3015-00-ATUALIZA-PROPAUTOM-DB-UPDATE-1 */
        public void R3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -5438- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0BILH-FONTE END-EXEC */

            var r3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1 = new R3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            R3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1.Execute(r3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-8 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_8()
        {
            /*" -4521- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.CLIENTES A , SEGUROS.BILHETE B , SEGUROS.ENDOSSOS C WHERE A.CGCCPF = :V0CLIE-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.SITUACAO = '9' AND C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_ENDOSSO = 0 AND C.DATA_TERVIGENCIA > CURRENT DATE AND C.COD_PRODUTO IN (8530, 8531, 8532) WITH UR END-EXEC */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_8_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_8_Query1()
            {
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_8_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3015_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-9 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_9()
        {
            /*" -4623- EXEC SQL SELECT VERSAO_BIL , VALADT_IND + VALADT_GER + VALADT_SUN INTO :V0BILFX-VERSAO , :V0BILFX-VALADT FROM SEGUROS.BILHETE_FAIXA WHERE NUMBIL_INI <= :V0BILH-NUMBIL AND NUMBIL_FIM >= :V0BILH-NUMBIL END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILFX_VERSAO, V0BILFX_VERSAO);
                _.Move(executed_1.V0BILFX_VALADT, V0BILFX_VALADT);
            }


        }

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-SECTION */
        private void R3020_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -5459- DISPLAY 'R3020-00-UPDATE-V0BILHETE' */
            _.Display($"R3020-00-UPDATE-V0BILHETE");

            /*" -5462- MOVE '3020' TO WNR-EXEC-SQL */
            _.Move("3020", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5468- PERFORM R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5473- DISPLAY 'UPD V0BILHETE2' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"UPD V0BILHETE2{V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5474- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5475- DISPLAY 'R3020-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3020-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5476- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -5477- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5479- END-IF */
            }


            /*" -5479- ADD +1 TO AC-U-V0BILHETE. */
            AREA_DE_WORK.AC_U_V0BILHETE.Value = AREA_DE_WORK.AC_U_V0BILHETE + +1;

        }

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5468- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP, COD_USUARIO = 'CB0005B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC */

            var r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-MONTA-V0BILHETE-SECTION */
        private void R3040_00_MONTA_V0BILHETE_SECTION()
        {
            /*" -5489- MOVE '3040' TO WNR-EXEC-SQL. */
            _.Move("3040", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5492- DISPLAY 'R3040-00-MONTA-V0BILHETE' */
            _.Display($"R3040-00-MONTA-V0BILHETE");

            /*" -5494- IF (V0BILH-DTQITBCO NOT EQUAL V1RCAC-DATARCAP) */

            if ((V0BILH_DTQITBCO != V1RCAC_DATARCAP))
            {

                /*" -5495- MOVE 11901 TO V0BILER-COD-ERRO */
                _.Move(11901, V0BILER_COD_ERRO);

                /*" -5497- PERFORM R3045-00-GRAVA-TAB-ERRO. */

                R3045_00_GRAVA_TAB_ERRO_SECTION();
            }


            /*" -5499- DISPLAY 'V0BILH-VLRCAP/V2RCAP-VLRCAP: ' V0BILH-VLRCAP '/' V2RCAP-VLRCAP */

            $"V0BILH-VLRCAP/V2RCAP-VLRCAP: {V0BILH_VLRCAP}/{V2RCAP_VLRCAP}"
            .Display();

            /*" -5501- IF (V0BILH-VLRCAP NOT EQUAL V2RCAP-VLRCAP) */

            if ((V0BILH_VLRCAP != V2RCAP_VLRCAP))
            {

                /*" -5502- MOVE 12101 TO V0BILER-COD-ERRO */
                _.Move(12101, V0BILER_COD_ERRO);

                /*" -5502- PERFORM R3045-00-GRAVA-TAB-ERRO. */

                R3045_00_GRAVA_TAB_ERRO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3045-00-GRAVA-TAB-ERRO-SECTION */
        private void R3045_00_GRAVA_TAB_ERRO_SECTION()
        {
            /*" -5512- DISPLAY 'R3045-00-GRAVA-TAB-ERRO' */
            _.Display($"R3045-00-GRAVA-TAB-ERRO");

            /*" -5514- MOVE '3045' TO WNR-EXEC-SQL. */
            _.Move("3045", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5516- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -5517- MOVE V0BILER-COD-ERRO TO TB-ERRO-CERT(WS-I-ERRO) */
            _.Move(V0BILER_COD_ERRO, WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT);

            /*" -5517- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3045_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-INSERE-ERRO-SECTION */
        private void R3050_00_INSERE_ERRO_SECTION()
        {
            /*" -5527- DISPLAY 'R3050-00-INSERE-ERRO' */
            _.Display($"R3050-00-INSERE-ERRO");

            /*" -5529- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5531- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -5532- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -5533- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -5534- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -5535- MOVE TB-ERRO-CERT(WS-I-ERRO) TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -5536- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -5537- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -5538- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -5539- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -5540- MOVE 'CB0005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("CB0005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -5541- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -5542- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -5543- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -5546- MOVE 'INSERCAO DE ERRO NA EMISSAO DA PROPOSTA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("INSERCAO DE ERRO NA EMISSAO DA PROPOSTA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -5548- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -5549- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -5550- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -5554- DISPLAY 'ERRO JAH GRAVADO 3050 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 3050 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -5555- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -5556- ELSE */
                }
                else
                {


                    /*" -5557- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5558- DISPLAY '* 3050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 3050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -5559- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5560- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -5561- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -5562- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -5563- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -5564- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -5565- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -5567- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5568- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -5569- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5570- END-IF */
                }


                /*" -5572- END-IF */
            }


            /*" -5574- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -5575- IF TB-ERRO-CERT(WS-I-ERRO) EQUAL ZEROS */

            if (WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT == 00)
            {

                /*" -5576- MOVE 'N' TO WS-FLAG-TEM-ERRO */
                _.Move("N", WS_FLAG_TEM_ERRO);

                /*" -5577- END-IF */
            }


            /*" -5577- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3060-00-VERIFICA-CRTCA-PEND-SECTION */
        private void R3060_00_VERIFICA_CRTCA_PEND_SECTION()
        {
            /*" -5602- MOVE '3060' TO WNR-EXEC-SQL. */
            _.Move("3060", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5604- DISPLAY 'R3060-00-VERIFICA-CRTCA-PEND' */
            _.Display($"R3060-00-VERIFICA-CRTCA-PEND");

            /*" -5606- MOVE ZEROS TO WS-ERRO-COUNT */
            _.Move(0, WS_ERRO_COUNT);

            /*" -5616- PERFORM R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1 */

            R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1();

            /*" -5621- DISPLAY 'SEL VG_CRITICA_PROPOSTA ' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"SEL VG_CRITICA_PROPOSTA {V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5622- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -5623- DISPLAY 'R1510-00 - PROBLEMAS NO SELECT(V0ERROS)  ' */
                _.Display($"R1510-00 - PROBLEMAS NO SELECT(V0ERROS)  ");

                /*" -5624- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5625- END-IF */
            }


            /*" -5625- . */

        }

        [StopWatch]
        /*" R3060-00-VERIFICA-CRTCA-PEND-DB-SELECT-1 */
        public void R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1()
        {
            /*" -5616- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-ERRO-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :V0BILH-NUMBIL AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> 3 WITH UR END-EXEC. */

            var r3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1 = new R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1.Execute(r3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_ERRO_COUNT, WS_ERRO_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3060_99_SAIDA*/

        [StopWatch]
        /*" R3080-00-UPDATE-V0BILHETE-SECTION */
        private void R3080_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -5635- DISPLAY 'R3080-00-UPDATE-V0BILHETE' */
            _.Display($"R3080-00-UPDATE-V0BILHETE");

            /*" -5638- MOVE '3080' TO WNR-EXEC-SQL. */
            _.Move("3080", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5643- PERFORM R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5648- DISPLAY 'UPD V0BILHETE3' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"UPD V0BILHETE3{V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5649- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5650- DISPLAY 'R3080-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3080-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5651- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -5654- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5656- MOVE 10205 TO V0BILER-COD-ERRO. */
            _.Move(10205, V0BILER_COD_ERRO);

            /*" -5656- PERFORM R3045-00-GRAVA-TAB-ERRO. */

            R3045_00_GRAVA_TAB_ERRO_SECTION();

        }

        [StopWatch]
        /*" R3080-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5643- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, COD_USUARIO = 'CB0005B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

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
            /*" -5666- MOVE '3090' TO WNR-EXEC-SQL. */
            _.Move("3090", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5669- DISPLAY 'R3090-00-UPDATE-V0BILHETE' */
            _.Display($"R3090-00-UPDATE-V0BILHETE");

            /*" -5674- PERFORM R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5679- DISPLAY 'UPD V0BILHETE4' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"UPD V0BILHETE4{V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5680- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5681- DISPLAY 'R3090-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3090-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5682- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -5682- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3090-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5674- EXEC SQL UPDATE SEGUROS.V0BILHETE SET FONTE = :V1MCEF-COD-FONTE, COD_USUARIO = 'CB0005B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

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
            /*" -5692- MOVE '3095' TO WNR-EXEC-SQL. */
            _.Move("3095", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5695- DISPLAY 'R3095-00-UPDATE-V0BILHETE' */
            _.Display($"R3095-00-UPDATE-V0BILHETE");

            /*" -5700- PERFORM R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5705- DISPLAY 'UPD V0BILHETE5' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"UPD V0BILHETE5{V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5706- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5707- DISPLAY 'R3095-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3095-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5708- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -5708- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3095-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5700- EXEC SQL UPDATE SEGUROS.V0BILHETE SET AGECOBR = :V1COFE-AGECOBR, COD_USUARIO = 'CB0005B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V1COFE_AGECOBR = V1COFE_AGECOBR.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3095_99_SAIDA*/

        [StopWatch]
        /*" R3105-00-UPDATE-V1COMIS-FENAE-SECTION */
        private void R3105_00_UPDATE_V1COMIS_FENAE_SECTION()
        {
            /*" -5718- MOVE '3105' TO WNR-EXEC-SQL. */
            _.Move("3105", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5721- DISPLAY 'R3105-00-UPDATE-V1COMIS-FENAE' */
            _.Display($"R3105-00-UPDATE-V1COMIS-FENAE");

            /*" -5725- PERFORM R3105_00_UPDATE_V1COMIS_FENAE_DB_UPDATE_1 */

            R3105_00_UPDATE_V1COMIS_FENAE_DB_UPDATE_1();

            /*" -5731- DISPLAY 'UPD V1COMISSAO_FENAE ' V1COFE-AGECOBR '/' V1COFE-NUMBIL '*SQLCODE: ' SQLCODE */

            $"UPD V1COMISSAO_FENAE {V1COFE_AGECOBR}/{V1COFE_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5733- DISPLAY 'R3105-00 (ERRO - UPDATE V1COMISSAO_FENAE)' */
                _.Display($"R3105-00 (ERRO - UPDATE V1COMISSAO_FENAE)");

                /*" -5734- DISPLAY 'BILHETE: ' V1COFE-NUMBIL '  ' */

                $"BILHETE: {V1COFE_NUMBIL}  "
                .Display();

                /*" -5735- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3105-00-UPDATE-V1COMIS-FENAE-DB-UPDATE-1 */
        public void R3105_00_UPDATE_V1COMIS_FENAE_DB_UPDATE_1()
        {
            /*" -5725- EXEC SQL UPDATE SEGUROS.V1COMISSAO_FENAE SET AGECOBR = :V1COFE-AGECOBR WHERE NUMBIL = :V1COFE-NUMBIL END-EXEC. */

            var r3105_00_UPDATE_V1COMIS_FENAE_DB_UPDATE_1_Update1 = new R3105_00_UPDATE_V1COMIS_FENAE_DB_UPDATE_1_Update1()
            {
                V1COFE_AGECOBR = V1COFE_AGECOBR.ToString(),
                V1COFE_NUMBIL = V1COFE_NUMBIL.ToString(),
            };

            R3105_00_UPDATE_V1COMIS_FENAE_DB_UPDATE_1_Update1.Execute(r3105_00_UPDATE_V1COMIS_FENAE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3105_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-INSERT-V0BIL-CC00396-SECTION */
        private void R3110_00_INSERT_V0BIL_CC00396_SECTION()
        {
            /*" -5744- MOVE '3110' TO WNR-EXEC-SQL. */
            _.Move("3110", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5747- DISPLAY 'R3110-00-INSERT-V0BIL-CC00396' */
            _.Display($"R3110-00-INSERT-V0BIL-CC00396");

            /*" -5748- MOVE V0BILH-NUMBIL TO V0C396-NUMBIL */
            _.Move(V0BILH_NUMBIL, V0C396_NUMBIL);

            /*" -5749- MOVE V1SIST-DTMOVACB TO V0C396-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0C396_DTMOVTO);

            /*" -5751- MOVE '0' TO V0C396-SITUACAO */
            _.Move("0", V0C396_SITUACAO);

            /*" -5757- PERFORM R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1 */

            R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1();

            /*" -5762- DISPLAY 'INS SEGUROS.V0BIL_CC00396 ' V0C396-NUMBIL '*SQLCODE: ' SQLCODE */

            $"INS SEGUROS.V0BIL_CC00396 {V0C396_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5763- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5765- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -5766- ELSE */
                }
                else
                {


                    /*" -5770- DISPLAY '3110-00 (ERRO - INSERT TABELA V0BIL_CC00396)..' 'NUMBIL : ' V0C396-NUMBIL '  ' 'DTMOVTO: ' V0C396-DTMOVTO '  ' 'SITUACAO: ' V0C396-SITUACAO */

                    $"3110-00 (ERRO - INSERT TABELA V0BIL_CC00396)..NUMBIL : {V0C396_NUMBIL}  DTMOVTO: {V0C396_DTMOVTO}  SITUACAO: {V0C396_SITUACAO}"
                    .Display();

                    /*" -5770- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3110-00-INSERT-V0BIL-CC00396-DB-INSERT-1 */
        public void R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1()
        {
            /*" -5757- EXEC SQL INSERT INTO SEGUROS.V0BIL_CC00396 VALUES (:V0C396-NUMBIL , :V0C396-DTMOVTO , :V0C396-SITUACAO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -5780- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5782- DISPLAY 'R3200-00-BAIXA-RCAP' */
            _.Display($"R3200-00-BAIXA-RCAP");

            /*" -5782- . */

            /*" -0- FLUXCONTROL_PERFORM R3200_10_DECLARE_V0RCAPCOMP */

            R3200_10_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP */
        private void R3200_10_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5805- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -5807- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -5810- DISPLAY 'OPE V1RCAPCOMP ' '*SQLCODE: ' SQLCODE */

            $"OPE V1RCAPCOMP *SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5810- . */

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -5807- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R8100_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -7593- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO WHERE COD_CBO BETWEEN 001 AND 999 ORDER BY COD_CBO END-EXEC. */
            CCBO = new CB0005B_CCBO(false);
            string GetQuery_CCBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							WHERE COD_CBO BETWEEN 001 AND 999 
							ORDER BY COD_CBO";

                return query;
            }
            CCBO.GetQueryEvent += GetQuery_CCBO;

        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP */
        private void R3200_20_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5816- MOVE '3201' TO WNR-EXEC-SQL. */
            _.Move("3201", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5831- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -5835- DISPLAY 'FET V1RCAPCOMP ' '*SQLCODE: ' SQLCODE */

            $"FET V1RCAPCOMP *SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5836- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5837- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5837- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -5839- GO TO R3200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                    return;

                    /*" -5840- ELSE */
                }
                else
                {


                    /*" -5841- DISPLAY 'R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ' */
                    _.Display($"R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ");

                    /*" -5844- DISPLAY 'FONTE: ' V0RCAP-FONTE '  ' 'RECIBO: ' V0RCAP-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                    $"FONTE: {V0RCAP_FONTE}  RECIBO: {V0RCAP_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -5849- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5850- IF V1RCAC-SITUACAO NOT EQUAL '0' */

            if (V1RCAC_SITUACAO != "0")
            {

                /*" -5852- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5854- IF V1RCAC-OPERACAO GREATER 199 AND V1RCAC-OPERACAO LESS 300 */

            if (V1RCAC_OPERACAO > 199 && V1RCAC_OPERACAO < 300)
            {

                /*" -5856- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5858- IF V1RCAC-OPERACAO GREATER 399 AND V1RCAC-OPERACAO LESS 500 */

            if (V1RCAC_OPERACAO > 399 && V1RCAC_OPERACAO < 500)
            {

                /*" -5861- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5861- GO TO R3200-30-UPDATE-V0RCAPCOMP. */

            R3200_30_UPDATE_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -5831- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

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
            /*" -5837- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP */
        private void R3200_30_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5868- MOVE '3202' TO WNR-EXEC-SQL. */
            _.Move("3202", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5878- PERFORM R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -5888- DISPLAY 'UPD V0RCAPCOMP ' V1RCAC-FONTE '/' V1RCAC-NRRCAP '/' V1RCAC-NRRCAPCO '/' V1RCAC-OPERACAO '/' V1RCAC-DTMOVTO '/' V1RCAC-HORAOPER '*SQLCODE: ' SQLCODE */

            $"UPD V0RCAPCOMP {V1RCAC_FONTE}/{V1RCAC_NRRCAP}/{V1RCAC_NRRCAPCO}/{V1RCAC_OPERACAO}/{V1RCAC_DTMOVTO}/{V1RCAC_HORAOPER}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5889- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5890- DISPLAY 'R3200-30 (ERRO - UPDATE V0RCAPCOMP)...' */
                _.Display($"R3200-30 (ERRO - UPDATE V0RCAPCOMP)...");

                /*" -5893- DISPLAY 'FONTE: ' V1RCAC-FONTE ' ' 'RECIBO: ' V1RCAC-NRRCAP 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V1RCAC_FONTE} RECIBO: {V1RCAC_NRRCAP}BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -5895- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5896- ADD +1 TO AC-U-V0RCAPCOMP. */
            AREA_DE_WORK.AC_U_V0RCAPCOMP.Value = AREA_DE_WORK.AC_U_V0RCAPCOMP + +1;

            /*" -5896- PERFORM R3200-40-INSERT-V0RCAPCOMP. */

            R3200_40_INSERT_V0RCAPCOMP(true);

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -5878- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

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
            /*" -5903- MOVE '3203' TO WNR-EXEC-SQL. */
            _.Move("3203", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5904- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -5905- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -5906- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -5907- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -5908- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -5909- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -5910- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -5912- MOVE WS000-HORA-TIME TO V1RCAC-HORAOPER. */
            _.Move(WS000_HORA_TIME, V1RCAC_HORAOPER);

            /*" -5930- PERFORM R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -5936- DISPLAY 'INS V0RCAPCOMP ' V1RCAC-FONTE '/' V1RCAC-NRRCAP '*SQLCODE: ' SQLCODE */

            $"INS V0RCAPCOMP {V1RCAC_FONTE}/{V1RCAC_NRRCAP}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5937- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5938- DISPLAY 'R3200-40 (ERRO - INSERT V0RCAPCOMP)...' */
                _.Display($"R3200-40 (ERRO - INSERT V0RCAPCOMP)...");

                /*" -5941- DISPLAY 'BILHETE:  ' V0BILH-NUMBIL '  ' 'AGENCIA:  ' V1RCAC-AGEAVISO '  ' 'BANCO:    ' V1RCAC-BCOAVISO */

                $"BILHETE:  {V0BILH_NUMBIL}  AGENCIA:  {V1RCAC_AGEAVISO}  BANCO:    {V1RCAC_BCOAVISO}"
                .Display();

                /*" -5944- DISPLAY 'DATARCAP: ' V1RCAC-DATARCAP '  ' 'FONTE:    ' V1RCAC-FONTE '  ' 'NRRCAP:   ' V1RCAC-NRRCAP */

                $"DATARCAP: {V1RCAC_DATARCAP}  FONTE:    {V1RCAC_FONTE}  NRRCAP:   {V1RCAC_NRRCAP}"
                .Display();

                /*" -5946- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5947- ADD 1 TO AC-I-V0RCAPCOMP. */
            AREA_DE_WORK.AC_I_V0RCAPCOMP.Value = AREA_DE_WORK.AC_I_V0RCAPCOMP + 1;

            /*" -5947- PERFORM R3200-50-UPDATE-V0AVISOSALDO. */

            R3200_50_UPDATE_V0AVISOSALDO(true);

        }

        [StopWatch]
        /*" R3200-40-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -5930- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1SIST-DTMOVACB , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -5953- MOVE '3204' TO WNR-EXEC-SQL. */
            _.Move("3204", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5960- PERFORM R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -5968- DISPLAY 'UPD V0AVISOS_SALDOS ' V1RCAC-VLRCAP '/' V1RCAC-BCOAVISO '/' V1RCAC-AGEAVISO '/' V1RCAC-NRAVISO '*SQLCODE: ' SQLCODE */

            $"UPD V0AVISOS_SALDOS {V1RCAC_VLRCAP}/{V1RCAC_BCOAVISO}/{V1RCAC_AGEAVISO}/{V1RCAC_NRAVISO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -5970- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5972- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5972- GO TO R3200-20-FETCH-V0RCAPCOMP. */

            R3200_20_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3200-50-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -5960- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

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
            /*" -5982- MOVE '3240' TO WNR-EXEC-SQL. */
            _.Move("3240", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5985- DISPLAY 'R3240-00-UPDATE-CROT-AP' */
            _.Display($"R3240-00-UPDATE-CROT-AP");

            /*" -5987- MOVE 'S' TO V0CROT-BILH-AP */
            _.Move("S", V0CROT_BILH_AP);

            /*" -5988- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -5989- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -5990- ELSE */
            }
            else
            {


                /*" -5992- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -5997- PERFORM R3240_00_UPDATE_CROT_AP_DB_UPDATE_1 */

            R3240_00_UPDATE_CROT_AP_DB_UPDATE_1();

            /*" -6002- DISPLAY 'UPD V0CLIENTE_CROT ' V0BILH-CGCCPF '*SQLCODE: ' SQLCODE */

            $"UPD V0CLIENTE_CROT {V0BILH_CGCCPF}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -6003- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6004- DISPLAY 'R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -6005- DISPLAY 'ATUALIZANDO ACIDENTES PESSOAIS         ...' */
                _.Display($"ATUALIZANDO ACIDENTES PESSOAIS         ...");

                /*" -6006- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -6008- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6008- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3240-00-UPDATE-CROT-AP-DB-UPDATE-1 */
        public void R3240_00_UPDATE_CROT_AP_DB_UPDATE_1()
        {
            /*" -5997- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_AP = :V0CROT-BILH-AP , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

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
            /*" -6018- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6021- DISPLAY 'R3250-00-UPDATE-CROT-RES' */
            _.Display($"R3250-00-UPDATE-CROT-RES");

            /*" -6023- MOVE 'S' TO V0CROT-BILH-RES */
            _.Move("S", V0CROT_BILH_RES);

            /*" -6024- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -6025- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -6026- ELSE */
            }
            else
            {


                /*" -6028- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -6033- PERFORM R3250_00_UPDATE_CROT_RES_DB_UPDATE_1 */

            R3250_00_UPDATE_CROT_RES_DB_UPDATE_1();

            /*" -6038- DISPLAY 'UPD V0CLIENTE_CROT ' V0BILH-CGCCPF '*SQLCODE: ' SQLCODE */

            $"UPD V0CLIENTE_CROT {V0BILH_CGCCPF}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -6039- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6040- DISPLAY 'R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -6041- DISPLAY 'ATUALIZANDO RESIDENCIAIS               ...' */
                _.Display($"ATUALIZANDO RESIDENCIAIS               ...");

                /*" -6042- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -6044- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6044- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3250-00-UPDATE-CROT-RES-DB-UPDATE-1 */
        public void R3250_00_UPDATE_CROT_RES_DB_UPDATE_1()
        {
            /*" -6033- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_RES = :V0CROT-BILH-RES , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

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
            /*" -6054- MOVE '3260' TO WNR-EXEC-SQL. */
            _.Move("3260", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6057- DISPLAY 'R3260-00-INSERT-V0CLIEN-CROT' */
            _.Display($"R3260-00-INSERT-V0CLIEN-CROT");

            /*" -6058- MOVE V0BILH-CGCCPF TO V0CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V0CROT_CGCCPF);

            /*" -6059- MOVE 'N' TO V0CROT-BILH-VDAZUL */
            _.Move("N", V0CROT_BILH_VDAZUL);

            /*" -6061- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
            _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

            /*" -6068- PERFORM R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1 */

            R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1();

            /*" -6073- DISPLAY 'INS V0CLIENTE_CROT ' V0CROT-CGCCPF '*SQLCODE: ' SQLCODE */

            $"INS V0CLIENTE_CROT {V0CROT_CGCCPF}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -6074- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6075- DISPLAY 'R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...' */
                _.Display($"R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...");

                /*" -6076- DISPLAY 'CGCCPF: ' V0BILH-CGCCPF */
                _.Display($"CGCCPF: {V0BILH_CGCCPF}");

                /*" -6078- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6078- ADD +1 TO AC-I-V0CLIE-CROT. */
            AREA_DE_WORK.AC_I_V0CLIE_CROT.Value = AREA_DE_WORK.AC_I_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3260-00-INSERT-V0CLIEN-CROT-DB-INSERT-1 */
        public void R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1()
        {
            /*" -6068- EXEC SQL INSERT INTO SEGUROS.V0CLIENTE_CROT VALUES (:V0CROT-CGCCPF , :V0CROT-BILH-AP , :V0CROT-BILH-RES , :V0CROT-BILH-VDAZUL , :V0CROT-DTMOVABE) END-EXEC. */

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
            /*" -6088- MOVE '3270' TO WNR-EXEC-SQL. */
            _.Move("3270", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6091- DISPLAY 'R3270-00-SELECT-APOLICE-ANT' */
            _.Display($"R3270-00-SELECT-APOLICE-ANT");

            /*" -6093- MOVE V0BILH-NUM-APO-ANT TO V1APOL-NUMBIL */
            _.Move(V0BILH_NUM_APO_ANT, V1APOL_NUMBIL);

            /*" -6098- PERFORM R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1 */

            R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1();

            /*" -6103- DISPLAY 'SEL V0APOLICE ' V1APOL-NUMBIL '*SQLCODE: ' SQLCODE */

            $"SEL V0APOLICE {V1APOL_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -6104- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6105- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6106- MOVE 0 TO V1APOL-NUM-APOL */
                    _.Move(0, V1APOL_NUM_APOL);

                    /*" -6107- ELSE */
                }
                else
                {


                    /*" -6108- DISPLAY 'R3270-00 (ERRO SELECT V0APOLICE)' */
                    _.Display($"R3270-00 (ERRO SELECT V0APOLICE)");

                    /*" -6109- DISPLAY 'NUMBIL     : ' V1APOL-NUMBIL */
                    _.Display($"NUMBIL     : {V1APOL_NUMBIL}");

                    /*" -6109- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3270-00-SELECT-APOLICE-ANT-DB-SELECT-1 */
        public void R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1()
        {
            /*" -6098- EXEC SQL SELECT NUM_APOLICE INTO :V1APOL-NUM-APOL FROM SEGUROS.V0APOLICE WHERE NUMBIL = :V1APOL-NUMBIL END-EXEC. */

            var r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1 = new R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1()
            {
                V1APOL_NUMBIL = V1APOL_NUMBIL.ToString(),
            };

            var executed_1 = R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1.Execute(r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NUM_APOL, V1APOL_NUM_APOL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3270_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -6122- MOVE '7100' TO WNR-EXEC-SQL. */
            _.Move("7100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6126- DISPLAY 'R4000-00-TOTAIS-CONTROLE' */
            _.Display($"R4000-00-TOTAIS-CONTROLE");

            /*" -6127- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -6128- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -6129- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -6131- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -6133- DISPLAY '+------------------------------------------------ '-----------------+' */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -6135- DISPLAY 'I BILHETES DE SEGUROS '                 I' */
            _.Display($"I BILHETES DE SEGUROS I");

            /*" -6137- DISPLAY 'I '                 I' */
            _.Display($"I I");

            /*" -6140- DISPLAY 'I                TOTAIS DE CONTROLE EM ' WDATA-CABEC '                 I' */

            $"I                TOTAIS DE CONTROLE EM {AREA_DE_WORK.WDATA_CABEC}                 I"
            .Display();

            /*" -6143- DISPLAY '+------------------------------------------------ '-----------------+' . */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -6145- DISPLAY 'I T A B E L A S A T U A L I Z A D A ' S               I' . */

            $"I T A B E L A S A T U A L I Z A D A {SISTEMAS.DCLSISTEMAS.SISTEMAS_IND_SGBD}I"
            .Display();

            /*" -6147- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -6149- DISPLAY 'I NOME DA TABELA I IN 'SERT   I UPDATE  I' */

            $"I NOME DA TABELA I IN SERT{COBPRPVA.DCLHIS_COBER_PROPOST.IMPDH}UPDATEI"
            .Display();

            /*" -6151- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -6154- DISPLAY 'I NUMERO OUTROS             (V0NUMERO_OUTS)  I  ' '     ' '   I  ' AC-U-V0NUMEROUT '  I' */

            $"I NUMERO OUTROS             (V0NUMERO_OUTS)  I          I  {AREA_DE_WORK.AC_U_V0NUMEROUT}  I"
            .Display();

            /*" -6157- DISPLAY 'I NUMERACAO GERAL           (V0NUMERO_AES)   I  ' '     ' '   I  ' AC-U-V0NUMERAES '  I' */

            $"I NUMERACAO GERAL           (V0NUMERO_AES)   I          I  {AREA_DE_WORK.AC_U_V0NUMERAES}  I"
            .Display();

            /*" -6160- DISPLAY 'I APOLICES                  (V0APOLICE)      I  ' AC-I-V0APOLICE '   I  ' AC-U-V0APOLICE '  I' */

            $"I APOLICES                  (V0APOLICE)      I  {AREA_DE_WORK.AC_I_V0APOLICE}   I  {AREA_DE_WORK.AC_U_V0APOLICE}  I"
            .Display();

            /*" -6163- DISPLAY 'I ENDOSSOS                  (V0ENDOSSO)      I  ' AC-I-V0ENDOSSO '   I  ' '     ' '  I' */

            $"I ENDOSSOS                  (V0ENDOSSO)      I  {AREA_DE_WORK.AC_I_V0ENDOSSO}   I         I"
            .Display();

            /*" -6166- DISPLAY 'I RECIBOS COB ANTECIPADA    (V0RCAP)         I  ' '     ' '   I  ' AC-U-V0RCAP '  I' */

            $"I RECIBOS COB ANTECIPADA    (V0RCAP)         I          I  {AREA_DE_WORK.AC_U_V0RCAP}  I"
            .Display();

            /*" -6169- DISPLAY 'I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  ' AC-I-V0RCAPCOMP '   I  ' AC-U-V0RCAPCOMP '  I' */

            $"I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  {AREA_DE_WORK.AC_I_V0RCAPCOMP}   I  {AREA_DE_WORK.AC_U_V0RCAPCOMP}  I"
            .Display();

            /*" -6172- DISPLAY 'I PRODUTORES                (V0PRODUTOR)     I  ' AC-I-V0PRODUTOR '   I  ' '     ' '  I' */

            $"I PRODUTORES                (V0PRODUTOR)     I  {AREA_DE_WORK.AC_I_V0PRODUTOR}   I         I"
            .Display();

            /*" -6175- DISPLAY 'I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I  ' '     ' '   I  ' AC-U-V0FUNCIOCEF '  I' */

            $"I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I          I  {AREA_DE_WORK.AC_U_V0FUNCIOCEF}  I"
            .Display();

            /*" -6178- DISPLAY 'I APOLICE CORRETOR          (V0APOLCORRET)   I  ' AC-I-V0APOLCORRET '   I  ' '     ' '  I' */

            $"I APOLICE CORRETOR          (V0APOLCORRET)   I  {AREA_DE_WORK.AC_I_V0APOLCORRET}   I         I"
            .Display();

            /*" -6181- DISPLAY 'I APOLICE COSSEGURO         (V0APOLCOSCED)   I  ' AC-I-V0APOLCOSCED '   I  ' '     ' '  I' */

            $"I APOLICE COSSEGURO         (V0APOLCOSCED)   I  {AREA_DE_WORK.AC_I_V0APOLCOSCED}   I         I"
            .Display();

            /*" -6184- DISPLAY 'I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  ' AC-I-V0ORDECOSCED '   I  ' '     ' '  I' */

            $"I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  {AREA_DE_WORK.AC_I_V0ORDECOSCED}   I         I"
            .Display();

            /*" -6187- DISPLAY 'I PARCELAS                  (V0PARCELAS)     I  ' AC-I-V0PARCELA '   I  ' '     ' '  I' */

            $"I PARCELAS                  (V0PARCELAS)     I  {AREA_DE_WORK.AC_I_V0PARCELA}   I         I"
            .Display();

            /*" -6190- DISPLAY 'I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  ' AC-I-V0HISTOPARC '   I  ' '     ' '  I' */

            $"I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  {AREA_DE_WORK.AC_I_V0HISTOPARC}   I         I"
            .Display();

            /*" -6193- DISPLAY 'I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  ' AC-I-V0COBERAPOL '   I  ' '     ' '  I' */

            $"I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  {AREA_DE_WORK.AC_I_V0COBERAPOL}   I         I"
            .Display();

            /*" -6196- DISPLAY 'I COMISSAO FENAE            (V0COMISSAO_FENAEI  ' '     ' '   I  ' AC-U-V0COMIFENAE '  I' */

            $"I COMISSAO FENAE            (V0COMISSAO_FENAEI          I  {AREA_DE_WORK.AC_U_V0COMIFENAE}  I"
            .Display();

            /*" -6199- DISPLAY 'I CLIENTE CROT              (V0CLIENTE_CROT) I  ' AC-I-V0CLIE-CROT '   I  ' AC-U-V0CLIE-CROT '  I' */

            $"I CLIENTE CROT              (V0CLIENTE_CROT) I  {AREA_DE_WORK.AC_I_V0CLIE_CROT}   I  {AREA_DE_WORK.AC_U_V0CLIE_CROT}  I"
            .Display();

            /*" -6202- DISPLAY 'I ADIANTAMENTOS             (V0ADIANTA)      I  ' AC-I-V0ADIANTA '   I  ' '     ' '  I' */

            $"I ADIANTAMENTOS             (V0ADIANTA)      I  {AREA_DE_WORK.AC_I_V0ADIANTA}   I         I"
            .Display();

            /*" -6205- DISPLAY 'I LIMITE DE RISCO                            I  ' AC-I-GELMR '   I  ' AC-U-GELMR '  I' */

            $"I LIMITE DE RISCO                            I  {AREA_DE_WORK.AC_I_GELMR}   I  {AREA_DE_WORK.AC_U_GELMR}  I"
            .Display();

            /*" -6207- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -6209- DISPLAY 'I QUANTIDADE DE BILHETES REJEITADOS          I  ' AC-U-V0BILHETE '   I         I' */

            $"I QUANTIDADE DE BILHETES REJEITADOS          I  {AREA_DE_WORK.AC_U_V0BILHETE}   I         I"
            .Display();

            /*" -6211- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -6215- DISPLAY 'I QUANTIDADE DE TITULOS EMITIDOS             I  ' WS-QTD-CAP-EMITIDO */
            _.Display($"I QUANTIDADE DE TITULOS EMITIDOS             I  {WS_QTD_CAP_EMITIDO}");

            /*" -6217- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -6219- DISPLAY 'I QUANTIDADE DE RISCO CRITICO DE ACEITACAO   I  ' WS-QT-RISCO-CRITICO '   I         I' */

            $"I QUANTIDADE DE RISCO CRITICO DE ACEITACAO   I  {WS_QT_RISCO_CRITICO}   I         I"
            .Display();

            /*" -6221- DISPLAY 'I QUANT. RISCO CRITICO PEPS BILHETE AMPARO   I  ' WS-QT-RISCO-PEPS '   I         I' */

            $"I QUANT. RISCO CRITICO PEPS BILHETE AMPARO   I  {WS_QT_RISCO_PEPS}   I         I"
            .Display();

            /*" -6223- DISPLAY 'I QUANTIDADE DE BILHETES EM ANALISE DE RISCO I  ' WS-QT-EM-CRITICA '   I         I' */

            $"I QUANTIDADE DE BILHETES EM ANALISE DE RISCO I  {WS_QT_EM_CRITICA}   I         I"
            .Display();

            /*" -6225- DISPLAY 'I QUANTIDADE EMISSOES COM AVALIACAO DE RISCO I  ' WS-QT-EMISSAO-C-RISCO '   I         I' */

            $"I QUANTIDADE EMISSOES COM AVALIACAO DE RISCO I  {WS_QT_EMISSAO_C_RISCO}   I         I"
            .Display();

            /*" -6227- DISPLAY 'I QUANTIDADE EMISSOES SEM AVALIACAO DE RISCO I  ' WS-QT-EMISSAO-S-RISCO '   I         I' */

            $"I QUANTIDADE EMISSOES SEM AVALIACAO DE RISCO I  {WS_QT_EMISSAO_S_RISCO}   I         I"
            .Display();

            /*" -6229- DISPLAY 'I QUANT. LIBERADA PARA EMISSAO APOS ANALISE  I  ' WS-QT-LIBERADO-EMISSAO '   I         I' */

            $"I QUANT. LIBERADA PARA EMISSAO APOS ANALISE  I  {WS_QT_LIBERADO_EMISSAO}   I         I"
            .Display();

            /*" -6230- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4280-00-TRATA-FC0105S-SECTION */
        private void R4280_00_TRATA_FC0105S_SECTION()
        {
            /*" -6239- MOVE '4280' TO WNR-EXEC-SQL */
            _.Move("4280", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6241- DISPLAY 'R4280-00-TRATA-FC0105S' */
            _.Display($"R4280-00-TRATA-FC0105S");

            /*" -6243- SET W88-DESLIGAR-TRACE TO TRUE */
            FILLER_1["W88_DESLIGAR_TRACE"] = true;

            /*" -6245- PERFORM R4290-00-INSERT-MOVFEDCA. */

            R4290_00_INSERT_MOVFEDCA_SECTION();

            /*" -6246- PERFORM R4400-00-INSERT-COMFEDCA. */

            R4400_00_INSERT_COMFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4280_99_SAIDA*/

        [StopWatch]
        /*" R4290-00-INSERT-MOVFEDCA-SECTION */
        private void R4290_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -6255- MOVE '4290' TO WNR-EXEC-SQL */
            _.Move("4290", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6258- DISPLAY 'R4290-00-INSERT-MOVFEDCA' */
            _.Display($"R4290-00-INSERT-MOVFEDCA");

            /*" -6275- INITIALIZE LK-PLANO LK-SERIE LK-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-PARCEIRO LK-RAMO LK-COD-USUARIO LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE. */
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

            /*" -6289- IF V1BILP-CODPRODU EQUAL 8112 OR 8113 OR 3709 OR 8144 OR 8145 OR 8146 OR 8147 OR 8148 OR 8149 OR 8150 OR 8521 OR 8528 OR 8529 OR 8530 OR 8531 OR 8532 OR 8533 OR 8534 OR JVPRD3709 OR JVPRD8144 OR JVPRD8145 OR JVPRD8146 OR JVPRD8147 OR JVPRD8148 OR JVPRD8149 OR JVPRD8150 OR 3721 OR 8120 OR 8511 OR 3729 */

            if (V1BILP_CODPRODU.In("8112", "8113", "3709", "8144", "8145", "8146", "8147", "8148", "8149", "8150", "8521", "8528", "8529", "8530", "8531", "8532", "8533", "8534", JVBKINCL.JV_PRODUTOS.JVPRD3709.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8144.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8145.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8146.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8147.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8148.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8149.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8150.ToString(), "3721", "8120", "8511", "3729"))
            {

                /*" -6292- MOVE 858 TO LK-PLANO W77-SMALLINT-D1 */
                _.Move(858, LK_PLANO, W77_SMALLINT_D1);

                /*" -6293- ELSE */
            }
            else
            {


                /*" -6296- MOVE 850 TO LK-PLANO W77-SMALLINT-D1 */
                _.Move(850, LK_PLANO, W77_SMALLINT_D1);

                /*" -6298- END-IF. */
            }


            /*" -6301- MOVE V0BILH-NUMBIL TO LK-NUM-PROPOSTA W77-DECIMAL */
            _.Move(V0BILH_NUMBIL, LK_NUM_PROPOSTA, W77_DECIMAL);

            /*" -6303- MOVE 1 TO LK-QTD-TITULOS */
            _.Move(1, LK_QTD_TITULOS);

            /*" -6306- MOVE V1BILC-VALMAX TO LK-VLR-TITULO W77-DECIMAL-D1 */
            _.Move(V1BILC_VALMAX, LK_VLR_TITULO, W77_DECIMAL_D1);

            /*" -6309- MOVE PARAMGER-COD-EMPRESA-CAP TO LK-PARCEIRO. */
            _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP, LK_PARCEIRO);

            /*" -6311- MOVE 'CB0005B' TO LK-COD-USUARIO */
            _.Move("CB0005B", LK_COD_USUARIO);

            /*" -6314- MOVE V1BILP-CODPRODU TO LK-RAMO W77-SMALLINT-D2 */
            _.Move(V1BILP_CODPRODU, LK_RAMO, W77_SMALLINT_D2);

            /*" -6316- MOVE ZEROS TO LK-NUM-NSA. */
            _.Move(0, LK_NUM_NSA);

            /*" -6317- IF W88-LIGAR-TRACE */

            if (FILLER_1["W88_LIGAR_TRACE"])
            {

                /*" -6318- MOVE 'TRACE ON ' TO LK-TRACE */
                _.Move("TRACE ON ", LK_TRACE);

                /*" -6319- SET W88-NAO-REPETIR TO TRUE */
                FILLER_0["W88_NAO_REPETIR"] = true;

                /*" -6320- ELSE */
            }
            else
            {


                /*" -6321- MOVE 'TRACE OFF' TO LK-TRACE */
                _.Move("TRACE OFF", LK_TRACE);

                /*" -6322- SET W88-REPETIR TO TRUE */
                FILLER_0["W88_REPETIR"] = true;

                /*" -6324- END-IF */
            }


            /*" -6343- CALL 'VG0105S' USING LK-PLANO , LK-SERIE , LK-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-PARCEIRO , LK-RAMO , LK-COD-USUARIO , LK-NUM-NSA , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE. */
            _.Call("VG0105S", LK_PLANO, LK_SERIE, LK_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_PARCEIRO, LK_RAMO, LK_COD_USUARIO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE);

            /*" -6344- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -6345- MOVE LK-OUT-SQLCODE TO WS-SQLCODE */
                _.Move(LK_OUT_SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                /*" -6352- DISPLAY 'PROBLEMAS NO ACESSO A VG0105S ' ' ' LK-NUM-PROPOSTA ' ' LK-OUT-COD-RETORNO ' ' WS-SQLCODE ' ' LK-OUT-MENSAGEM ' ' LK-OUT-SQLERRMC ' ' LK-OUT-SQLSTATE */

                $"PROBLEMAS NO ACESSO A VG0105S  {LK_NUM_PROPOSTA} {LK_OUT_COD_RETORNO} {AREA_DE_WORK.WS_SQLCODE} {LK_OUT_MENSAGEM} {LK_OUT_SQLERRMC} {LK_OUT_SQLSTATE}"
                .Display();

                /*" -6353- DISPLAY 'LK-NUM-PLANO       <' W77-SMALLINT-D1 '>' */

                $"LK-NUM-PLANO       <{W77_SMALLINT_D1}>"
                .Display();

                /*" -6354- DISPLAY 'LK-NUM-PROPOSTA    <' W77-DECIMAL '>' */

                $"LK-NUM-PROPOSTA    <{W77_DECIMAL}>"
                .Display();

                /*" -6355- DISPLAY 'LK-VLR-TITULO      <' W77-DECIMAL-D1 '>' */

                $"LK-VLR-TITULO      <{W77_DECIMAL_D1}>"
                .Display();

                /*" -6356- DISPLAY 'LK-NUM-PARCEIRO    <' LK-PARCEIRO '>' */

                $"LK-NUM-PARCEIRO    <{LK_PARCEIRO}>"
                .Display();

                /*" -6357- DISPLAY 'LK-RAMO            <' W77-SMALLINT-D2 '>' */

                $"LK-RAMO            <{W77_SMALLINT_D2}>"
                .Display();

                /*" -6358- DISPLAY ' ' */
                _.Display($" ");

                /*" -6359- DISPLAY 'LK-OUT-COD-RETORNO <' LK-OUT-COD-RETORNO '>' */

                $"LK-OUT-COD-RETORNO <{LK_OUT_COD_RETORNO}>"
                .Display();

                /*" -6360- DISPLAY 'WS-SQLCODE         <' WS-SQLCODE '>' */

                $"WS-SQLCODE         <{AREA_DE_WORK.WS_SQLCODE}>"
                .Display();

                /*" -6361- DISPLAY 'LK-OUT-MENSAGEM    <' LK-OUT-MENSAGEM '>' */

                $"LK-OUT-MENSAGEM    <{LK_OUT_MENSAGEM}>"
                .Display();

                /*" -6362- DISPLAY 'LK-OUT-SQLERRMC    <' LK-OUT-SQLERRMC '>' */

                $"LK-OUT-SQLERRMC    <{LK_OUT_SQLERRMC}>"
                .Display();

                /*" -6363- DISPLAY 'LK-OUT-SQLSTATE    <' LK-OUT-SQLSTATE '>' */

                $"LK-OUT-SQLSTATE    <{LK_OUT_SQLSTATE}>"
                .Display();

                /*" -6365- DISPLAY ' ' */
                _.Display($" ");

                /*" -6365- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4290_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-SECTION */
        private void R4400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -6382- MOVE '4400' TO WNR-EXEC-SQL. */
            _.Move("4400", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6385- DISPLAY 'R4400-00-INSERT-COMFEDCA' */
            _.Display($"R4400-00-INSERT-COMFEDCA");

            /*" -6396- PERFORM R4400_00_INSERT_COMFEDCA_DB_INSERT_1 */

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1();

            /*" -6401- DISPLAY 'INS COMUNIC_FED_CAP_VA ' V0BILH-NUMBIL '*SQLCODE: ' SQLCODE */

            $"INS COMUNIC_FED_CAP_VA {V0BILH_NUMBIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -6402- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6403- DISPLAY 'R4400 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R4400 - ERRO NO INSERT DA TITFEDCA ");

                /*" -6404- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -6405- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6406- END-IF. */
            }


        }

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-DB-INSERT-1 */
        public void R4400_00_INSERT_COMFEDCA_DB_INSERT_1()
        {
            /*" -6396- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :V0BILH-NUMBIL , '0' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP ) END-EXEC. */

            var r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 = new R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1.Execute(r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-INSERE-ENDOSSO-SECTION */
        private void R5000_00_INSERE_ENDOSSO_SECTION()
        {
            /*" -6415- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6418- DISPLAY 'R5000-00-INSERE-ENDOSSO ' */
            _.Display($"R5000-00-INSERE-ENDOSSO ");

            /*" -6508- PERFORM R5000_00_INSERE_ENDOSSO_DB_INSERT_1 */

            R5000_00_INSERE_ENDOSSO_DB_INSERT_1();

            /*" -6514- DISPLAY 'INS V0ENDOSSO ' V0ENDO-NUM-APOL '/' V0ENDO-NRENDOS '*SQLCODE: ' SQLCODE */

            $"INS V0ENDOSSO {V0ENDO_NUM_APOL}/{V0ENDO_NRENDOS}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -6515- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6516- DISPLAY 'R5000-00 (ERRO - INSERT V0ENDOSSO)...' */
                _.Display($"R5000-00 (ERRO - INSERT V0ENDOSSO)...");

                /*" -6517- DISPLAY 'V0ENDO-NUM-APOL   = ' V0ENDO-NUM-APOL */
                _.Display($"V0ENDO-NUM-APOL   = {V0ENDO_NUM_APOL}");

                /*" -6518- DISPLAY 'V0ENDO-NRENDOS    = ' V0ENDO-NRENDOS */
                _.Display($"V0ENDO-NRENDOS    = {V0ENDO_NRENDOS}");

                /*" -6519- DISPLAY 'V0ENDO-FONTE      = ' V0ENDO-FONTE */
                _.Display($"V0ENDO-FONTE      = {V0ENDO_FONTE}");

                /*" -6520- DISPLAY 'V0ENDO-NRPROPOS   = ' V0ENDO-NRPROPOS */
                _.Display($"V0ENDO-NRPROPOS   = {V0ENDO_NRPROPOS}");

                /*" -6521- DISPLAY 'RAMO   : ' WWORK-RAMO-ANT */
                _.Display($"RAMO   : {WWORK_RAMO_ANT}");

                /*" -6522- DISPLAY 'OPCAO  : ' WWORK-OPCAO-ANT */
                _.Display($"OPCAO  : {WWORK_OPCAO_ANT}");

                /*" -6523- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6525- END-IF */
            }


            /*" -6527- ADD +1 TO AC-I-V0ENDOSSO */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

            /*" -6527- . */

        }

        [StopWatch]
        /*" R5000-00-INSERE-ENDOSSO-DB-INSERT-1 */
        public void R5000_00_INSERE_ENDOSSO_DB_INSERT_1()
        {
            /*" -6508- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-CODSUBES , :V0ENDO-FONTE , :V0ENDO-NRPROPOS , :V0ENDO-DATPRO , :V0ENDO-DT-LIBER , :V0ENDO-DTEMIS , :V0ENDO-NRRCAP , :V0ENDO-VLRCAP , :V0ENDO-BCORCAP , :V0ENDO-AGERCAP , :V0ENDO-DACRCAP , :V0ENDO-IDRCAP , :V0ENDO-BCOCOBR , :V0ENDO-AGECOBR , :V0ENDO-DACCOBR , :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG , :V0ENDO-CDFRACIO , :V0ENDO-PCENTRAD , :V0ENDO-PCADICIO , :V0ENDO-PRESTA1 , :V0ENDO-QTPARCEL , :V0ENDO-QTPRESTA , :V0ENDO-QTITENS , :V0ENDO-CODTXT , :V0ENDO-CDACEITA , :V0ENDO-MOEDA-IMP , :V0ENDO-MOEDA-PRM , :V0ENDO-TIPO-ENDO , :V0ENDO-COD-USUAR , :V0ENDO-OCORR-END , :V0ENDO-SITUACAO , :V0ENDO-DATARCAP:VIND-DATARCAP , :V0ENDO-COD-EMPRESA , :V0ENDO-CORRECAO , :V0ENDO-ISENTA-CST , CURRENT TIMESTAMP , :V0ENDO-DTVENCTO:VIND-DTVENCTO , :V0ENDO-CFPREFIX:VIND-CFPREFIX , :V0ENDO-VLCUSEMI:VIND-VLCUSEMI , :V0ENDO-RAMO , :V0ENDO-CODPRODU) END-EXEC */

            var r5000_00_INSERE_ENDOSSO_DB_INSERT_1_Insert1 = new R5000_00_INSERE_ENDOSSO_DB_INSERT_1_Insert1()
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

            R5000_00_INSERE_ENDOSSO_DB_INSERT_1_Insert1.Execute(r5000_00_INSERE_ENDOSSO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5010-00-INSERE-PARCELA-SECTION */
        private void R5010_00_INSERE_PARCELA_SECTION()
        {
            /*" -6537- MOVE '5010' TO WNR-EXEC-SQL */
            _.Move("5010", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6540- DISPLAY 'R5010-00-INSERE-PARCELA' */
            _.Display($"R5010-00-INSERE-PARCELA");

            /*" -6561- PERFORM R5010_00_INSERE_PARCELA_DB_INSERT_1 */

            R5010_00_INSERE_PARCELA_DB_INSERT_1();

            /*" -6567- DISPLAY 'INS V0PARCELA ' V0PARC-NUM-APOL '/' V0PARC-NRENDOS '*SQLCODE: ' SQLCODE */

            $"INS V0PARCELA {V0PARC_NUM_APOL}/{V0PARC_NRENDOS}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -6568- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6569- DISPLAY 'R5010-00 (ERRO - INSERT V0PARCELA)...' */
                _.Display($"R5010-00 (ERRO - INSERT V0PARCELA)...");

                /*" -6573- DISPLAY 'APOL: ' V0PARC-NUM-APOL '  ' 'ENDO: ' V0PARC-NRENDOS '  ' 'PARC: ' V0PARC-NRPARCEL '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0PARC_NUM_APOL}  ENDO: {V0PARC_NRENDOS}  PARC: {V0PARC_NRPARCEL}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -6574- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6576- END-IF */
            }


            /*" -6578- ADD +1 TO AC-I-V0PARCELA */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

            /*" -6578- . */

        }

        [StopWatch]
        /*" R5010-00-INSERE-PARCELA-DB-INSERT-1 */
        public void R5010_00_INSERE_PARCELA_DB_INSERT_1()
        {
            /*" -6561- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC */

            var r5010_00_INSERE_PARCELA_DB_INSERT_1_Insert1 = new R5010_00_INSERE_PARCELA_DB_INSERT_1_Insert1()
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

            R5010_00_INSERE_PARCELA_DB_INSERT_1_Insert1.Execute(r5010_00_INSERE_PARCELA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5010_99_SAIDA*/

        [StopWatch]
        /*" R5020-00-INSERE-COBER-APOL-SECTION */
        private void R5020_00_INSERE_COBER_APOL_SECTION()
        {
            /*" -6588- MOVE '5020' TO WNR-EXEC-SQL */
            _.Move("5020", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6591- DISPLAY 'R5020-00-INSERE-COBER-APOL' */
            _.Display($"R5020-00-INSERE-COBER-APOL");

            /*" -6611- PERFORM R5020_00_INSERE_COBER_APOL_DB_INSERT_1 */

            R5020_00_INSERE_COBER_APOL_DB_INSERT_1();

            /*" -6617- DISPLAY 'INS V0COBERAPOL ' V0COBA-NUM-APOL '/' V0COBA-NRENDOS '*SQLCODE: ' SQLCODE */

            $"INS V0COBERAPOL {V0COBA_NUM_APOL}/{V0COBA_NRENDOS}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -6618- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6619- DISPLAY 'R5020-00 (ERRO - INSERT V0COBERAPOL)...' */
                _.Display($"R5020-00 (ERRO - INSERT V0COBERAPOL)...");

                /*" -6622- DISPLAY 'APOL: ' V0COBA-NUM-APOL '  ' 'ENDO: ' V0COBA-NRENDOS '  ' 'RAMO: ' V0COBA-RAMOFR '  ' */

                $"APOL: {V0COBA_NUM_APOL}  ENDO: {V0COBA_NRENDOS}  RAMO: {V0COBA_RAMOFR}  "
                .Display();

                /*" -6623- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6625- END-IF */
            }


            /*" -6627- ADD +1 TO AC-I-V0COBERAPOL */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

            /*" -6627- . */

        }

        [StopWatch]
        /*" R5020-00-INSERE-COBER-APOL-DB-INSERT-1 */
        public void R5020_00_INSERE_COBER_APOL_DB_INSERT_1()
        {
            /*" -6611- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC */

            var r5020_00_INSERE_COBER_APOL_DB_INSERT_1_Insert1 = new R5020_00_INSERE_COBER_APOL_DB_INSERT_1_Insert1()
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

            R5020_00_INSERE_COBER_APOL_DB_INSERT_1_Insert1.Execute(r5020_00_INSERE_COBER_APOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5020_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-PROCESSA-ANUAL-SECTION */
        private void R6000_00_PROCESSA_ANUAL_SECTION()
        {
            /*" -6637- MOVE '6000' TO WNR-EXEC-SQL */
            _.Move("6000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6640- DISPLAY 'R6000-00-PROCESSA-ANUAL' */
            _.Display($"R6000-00-PROCESSA-ANUAL");

            /*" -6642- MOVE V0APOL-NUM-APOL TO V0PARC-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0PARC_NUM_APOL);

            /*" -6646- MOVE ZEROS TO V0PARC-NRENDOS V0HISP-NRENDOS V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRENDOS, V0HISP_NRENDOS, V0PARC_NRPARCEL);

            /*" -6647- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -6648- MOVE V0BILH-FONTE TO V0PARC-FONTE */
            _.Move(V0BILH_FONTE, V0PARC_FONTE);

            /*" -6649- MOVE V0BILH-NUMBIL TO V0PARC-NRTIT */
            _.Move(V0BILH_NUMBIL, V0PARC_NRTIT);

            /*" -6650- MOVE WWORK-PR-APOL TO V0PARC-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_PRM_TAR_IX);

            /*" -6651- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -6652- MOVE WWORK-PR-APOL TO V0PARC-OTNPRLIQ */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_OTNPRLIQ);

            /*" -6653- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -6655- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -6657- MOVE WWORK-IOCC TO V0PARC-OTNIOF */
            _.Move(AREA_DE_WORK.WWORK_IOCC, V0PARC_OTNIOF);

            /*" -6662- COMPUTE V0PARC-OTNTOTAL = V0PARC-OTNPRLIQ + V0PARC-OTNADFRA + V0PARC-OTNCUSTO + V0PARC-OTNIOF */
            V0PARC_OTNTOTAL.Value = V0PARC_OTNPRLIQ + V0PARC_OTNADFRA + V0PARC_OTNCUSTO + V0PARC_OTNIOF;

            /*" -6663- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -6664- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -6665- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -6667- MOVE ZEROS TO V0PARC-COD-EMPRESA */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -6669- PERFORM R5010-00-INSERE-PARCELA */

            R5010_00_INSERE_PARCELA_SECTION();

            /*" -6671- PERFORM R2010-00-GRAVA-V0HISTOPARC */

            R2010_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -6673- PERFORM R2020-00-GRAVA-OPERACAO-BAIXA */

            R2020_00_GRAVA_OPERACAO_BAIXA_SECTION();

            /*" -6674- MOVE V0APOL-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0COBA_NUM_APOL);

            /*" -6675- MOVE 0 TO V0COBA-NRENDOS */
            _.Move(0, V0COBA_NRENDOS);

            /*" -6676- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -6677- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -6678- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -6679- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -6680- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -6682- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -6683- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -6684- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -6685- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -6686- MOVE WWORK-RAMO-ANT TO V0COBA-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0COBA_RAMOFR);

            /*" -6688- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
            _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

            /*" -6689- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-IX */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_IX);

            /*" -6690- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_IX);

            /*" -6691- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-VR */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_VR);

            /*" -6693- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-VR */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_VR);

            /*" -6695- MOVE 100 TO V0COBA-PCT-COBERT */
            _.Move(100, V0COBA_PCT_COBERT);

            /*" -6696- IF NOVOS-ACESSOS */

            if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
            {

                /*" -6697- PERFORM R5020-00-INSERE-COBER-APOL */

                R5020_00_INSERE_COBER_APOL_SECTION();

                /*" -6700- PERFORM R7100-00-VARIAS-APOLICES VARYING IND-cob FROM 001 BY 001 UNTIL IND-cob GREATER LK-0071-S-QTD-OCC */

                for (IND_COB.Value = 001; !(IND_COB > GE0071W.LK_0071_S_QTD_OCC); IND_COB.Value += 001)
                {

                    R7100_00_VARIAS_APOLICES_SECTION();
                }

                /*" -6701- ELSE */
            }
            else
            {


                /*" -6702- PERFORM R5020-00-INSERE-COBER-APOL */

                R5020_00_INSERE_COBER_APOL_SECTION();

                /*" -6704- END-IF */
            }


            /*" -6704- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-PROCESSA-MENSAL-SECTION */
        private void R7000_00_PROCESSA_MENSAL_SECTION()
        {
            /*" -6714- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6717- DISPLAY 'R7000-00-PROCESSA-MENSAL' */
            _.Display($"R7000-00-PROCESSA-MENSAL");

            /*" -6718- IF V0ENDO-NRENDOS EQUAL ZEROS */

            if (V0ENDO_NRENDOS == 00)
            {

                /*" -6721- ADD 1 TO WWORK-NRENDOS V1FONT-PROPAUTOM */
                AREA_DE_WORK.WWORK_NRENDOS.Value = AREA_DE_WORK.WWORK_NRENDOS + 1;
                V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

                /*" -6723- PERFORM R3010-00-LER-ENDOSSO */

                R3010_00_LER_ENDOSSO_SECTION();

                /*" -6724- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS */
                _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

                /*" -6726- MOVE '1' TO V0ENDO-SITUACAO */
                _.Move("1", V0ENDO_SITUACAO);

                /*" -6728- PERFORM R3015-00-ATUALIZA-PROPAUTOM */

                R3015_00_ATUALIZA_PROPAUTOM_SECTION();

                /*" -6733- PERFORM R7000_00_PROCESSA_MENSAL_DB_SELECT_1 */

                R7000_00_PROCESSA_MENSAL_DB_SELECT_1();

                /*" -6738- DISPLAY 'SEL SISTEMAS BI ' WHOST-DTINIVIG '*SQLCODE: ' SQLCODE */

                $"SEL SISTEMAS BI {WHOST_DTINIVIG}*SQLCODE: {DB.SQLCODE}"
                .Display();

                /*" -6739- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -6742- DISPLAY 'R7000-00 (ERRO - SELECT DATA-TERVIG)' ' BILHETE = ' V0BILH-NUMBIL ' DATA-INIVIG = ' V0ENDO-DTINIVIG */

                    $"R7000-00 (ERRO - SELECT DATA-TERVIG) BILHETE = {V0BILH_NUMBIL} DATA-INIVIG = {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -6743- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6745- END-IF */
                }


                /*" -6746- MOVE WHOST-DTINIVIG TO V0ENDO-DTTERVIG */
                _.Move(WHOST_DTINIVIG, V0ENDO_DTTERVIG);

                /*" -6747- MOVE WWORK-NRENDOS TO V0ENDO-NRENDOS */
                _.Move(AREA_DE_WORK.WWORK_NRENDOS, V0ENDO_NRENDOS);

                /*" -6749- MOVE '1' TO V0ENDO-TIPO-ENDO */
                _.Move("1", V0ENDO_TIPO_ENDO);

                /*" -6750- PERFORM R5000-00-INSERE-ENDOSSO */

                R5000_00_INSERE_ENDOSSO_SECTION();

                /*" -6756- END-IF */
            }


            /*" -6757- MOVE V0APOL-NUM-APOL TO V0PARC-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0PARC_NUM_APOL);

            /*" -6765- MOVE V0BILH-FONTE TO V0PARC-FONTE */
            _.Move(V0BILH_FONTE, V0PARC_FONTE);

            /*" -6769- MOVE ZEROS TO V0PARC-NRENDOS V0HISP-NRENDOS V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRENDOS, V0HISP_NRENDOS, V0PARC_NRPARCEL);

            /*" -6770- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -6771- MOVE V0BILH-FONTE TO V0PARC-FONTE */
            _.Move(V0BILH_FONTE, V0PARC_FONTE);

            /*" -6779- MOVE ZEROS TO V0PARC-NRTIT V0PARC-PRM-TAR-IX V0PARC-VAL-DES-IX V0PARC-OTNPRLIQ V0PARC-OTNADFRA V0PARC-OTNCUSTO V0PARC-OTNIOF V0PARC-OTNTOTAL */
            _.Move(0, V0PARC_NRTIT, V0PARC_PRM_TAR_IX, V0PARC_VAL_DES_IX, V0PARC_OTNPRLIQ, V0PARC_OTNADFRA, V0PARC_OTNCUSTO, V0PARC_OTNIOF, V0PARC_OTNTOTAL);

            /*" -6780- MOVE 1 TO V0PARC-OCORHIST */
            _.Move(1, V0PARC_OCORHIST);

            /*" -6784- MOVE ZEROS TO V0PARC-QTDDOC V0PARC-SITUACAO V0PARC-COD-EMPRESA */
            _.Move(0, V0PARC_QTDDOC, V0PARC_SITUACAO, V0PARC_COD_EMPRESA);

            /*" -6791- PERFORM R5010-00-INSERE-PARCELA */

            R5010_00_INSERE_PARCELA_SECTION();

            /*" -6798- PERFORM R2010-00-GRAVA-V0HISTOPARC */

            R2010_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -6799- MOVE V0APOL-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0COBA_NUM_APOL);

            /*" -6802- MOVE ZEROS TO V0COBA-NRENDOS V0COBA-NUM-ITEM V0COBA-OCORHIST */
            _.Move(0, V0COBA_NRENDOS, V0COBA_NUM_ITEM, V0COBA_OCORHIST);

            /*" -6803- MOVE WWORK-RAMO-ANT TO V0COBA-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0COBA_RAMOFR);

            /*" -6812- MOVE ZEROS TO V0COBA-MODALIFR V0COBA-COD-COBER V0COBA-IMP-SEG-IX V0COBA-PRM-TAR-IX V0COBA-IMP-SEG-VR V0COBA-PRM-TAR-VR V0COBA-PCT-COBERT V0COBA-FATOR-MULT V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_MODALIFR, V0COBA_COD_COBER, V0COBA_IMP_SEG_IX, V0COBA_PRM_TAR_IX, V0COBA_IMP_SEG_VR, V0COBA_PRM_TAR_VR, V0COBA_PCT_COBERT, V0COBA_FATOR_MULT, V0COBA_COD_EMPRESA);

            /*" -6813- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -6814- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -6815- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -6817- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -6818- IF NOVOS-ACESSOS */

            if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
            {

                /*" -6819- PERFORM R5020-00-INSERE-COBER-APOL */

                R5020_00_INSERE_COBER_APOL_SECTION();

                /*" -6822- PERFORM R7100-00-VARIAS-APOLICES VARYING IND-COB FROM 001 BY 001 UNTIL IND-COB GREATER LK-0071-S-QTD-OCC */

                for (IND_COB.Value = 001; !(IND_COB > GE0071W.LK_0071_S_QTD_OCC); IND_COB.Value += 001)
                {

                    R7100_00_VARIAS_APOLICES_SECTION();
                }

                /*" -6823- ELSE */
            }
            else
            {


                /*" -6824- PERFORM R5020-00-INSERE-COBER-APOL */

                R5020_00_INSERE_COBER_APOL_SECTION();

                /*" -6833- END-IF */
            }


            /*" -6835- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -6836- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -6837- MOVE V0BILH-NUMBIL TO V0PARC-NRTIT */
            _.Move(V0BILH_NUMBIL, V0PARC_NRTIT);

            /*" -6838- MOVE WWORK-PR-APOL TO V0PARC-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_PRM_TAR_IX);

            /*" -6839- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -6840- MOVE WWORK-PR-APOL TO V0PARC-OTNPRLIQ */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_OTNPRLIQ);

            /*" -6841- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -6843- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -6845- MOVE WWORK-IOCC TO V0PARC-OTNIOF */
            _.Move(AREA_DE_WORK.WWORK_IOCC, V0PARC_OTNIOF);

            /*" -6850- COMPUTE V0PARC-OTNTOTAL = V0PARC-OTNPRLIQ + V0PARC-OTNADFRA + V0PARC-OTNCUSTO + V0PARC-OTNIOF */
            V0PARC_OTNTOTAL.Value = V0PARC_OTNPRLIQ + V0PARC_OTNADFRA + V0PARC_OTNCUSTO + V0PARC_OTNIOF;

            /*" -6851- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -6852- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -6853- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -6856- MOVE ZEROS TO V0PARC-COD-EMPRESA */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -6859- MOVE WWORK-NRENDOS TO V0PARC-NRENDOS V0HISP-NRENDOS */
            _.Move(AREA_DE_WORK.WWORK_NRENDOS, V0PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -6861- PERFORM R5010-00-INSERE-PARCELA */

            R5010_00_INSERE_PARCELA_SECTION();

            /*" -6863- PERFORM R2010-00-GRAVA-V0HISTOPARC */

            R2010_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -6870- PERFORM R2020-00-GRAVA-OPERACAO-BAIXA */

            R2020_00_GRAVA_OPERACAO_BAIXA_SECTION();

            /*" -6871- MOVE V0APOL-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0COBA_NUM_APOL);

            /*" -6872- MOVE WWORK-NRENDOS TO V0COBA-NRENDOS */
            _.Move(AREA_DE_WORK.WWORK_NRENDOS, V0COBA_NRENDOS);

            /*" -6873- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -6874- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -6875- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -6876- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -6877- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -6879- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -6880- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -6881- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -6882- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -6883- MOVE WWORK-RAMO-ANT TO V0COBA-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0COBA_RAMOFR);

            /*" -6885- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
            _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

            /*" -6886- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-IX */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_IX);

            /*" -6887- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_IX);

            /*" -6888- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-VR */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_VR);

            /*" -6890- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-VR */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_VR);

            /*" -6892- MOVE 100 TO V0COBA-PCT-COBERT */
            _.Move(100, V0COBA_PCT_COBERT);

            /*" -6893- IF NOVOS-ACESSOS */

            if (N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
            {

                /*" -6894- PERFORM R5020-00-INSERE-COBER-APOL */

                R5020_00_INSERE_COBER_APOL_SECTION();

                /*" -6897- PERFORM R7100-00-VARIAS-APOLICES VARYING IND-cob FROM 001 BY 001 UNTIL IND-cob GREATER LK-0071-S-QTD-OCC */

                for (IND_COB.Value = 001; !(IND_COB > GE0071W.LK_0071_S_QTD_OCC); IND_COB.Value += 001)
                {

                    R7100_00_VARIAS_APOLICES_SECTION();
                }

                /*" -6898- ELSE */
            }
            else
            {


                /*" -6899- PERFORM R5020-00-INSERE-COBER-APOL */

                R5020_00_INSERE_COBER_APOL_SECTION();

                /*" -6904- END-IF */
            }


            /*" -6905- PERFORM R7055-00-TRATA-MOVDEBCC */

            R7055_00_TRATA_MOVDEBCC_SECTION();

            /*" -6907- PERFORM R7060-00-INSERT-APOLCOBR */

            R7060_00_INSERT_APOLCOBR_SECTION();

            /*" -6907- . */

        }

        [StopWatch]
        /*" R7000-00-PROCESSA-MENSAL-DB-SELECT-1 */
        public void R7000_00_PROCESSA_MENSAL_DB_SELECT_1()
        {
            /*" -6733- EXEC SQL SELECT DATE(:V0ENDO-DTINIVIG) + 1 MONTH - 1 DAY INTO :WHOST-DTINIVIG FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC */

            var r7000_00_PROCESSA_MENSAL_DB_SELECT_1_Query1 = new R7000_00_PROCESSA_MENSAL_DB_SELECT_1_Query1()
            {
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R7000_00_PROCESSA_MENSAL_DB_SELECT_1_Query1.Execute(r7000_00_PROCESSA_MENSAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-VARIAS-APOLICES-SECTION */
        private void R7100_00_VARIAS_APOLICES_SECTION()
        {
            /*" -6917- MOVE '7100' TO WNR-EXEC-SQL */
            _.Move("7100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6920- DISPLAY 'R7100-00-VARIAS-APOLICES' */
            _.Display($"R7100-00-VARIAS-APOLICES");

            /*" -6921- DISPLAY 'IND-COB: ' IND-COB */
            _.Display($"IND-COB: {IND_COB}");

            /*" -6923- DISPLAY 'LK-0071-S-A-COD-COBERTURA: ' LK-0071-S-A-COD-COBERTURA(IND-COB) */
            _.Display($"LK-0071-S-A-COD-COBERTURA: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB]}");

            /*" -6926- MOVE LK-0071-S-A-COD-COBERTURA(IND-COB) TO V0COBA-COD-COBER */
            _.Move(GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB].LK_0071_S_A_COD_COBERTURA, V0COBA_COD_COBER);

            /*" -6928- DISPLAY 'LK-0071-S-A-VLR-IS: ' LK-0071-S-A-VLR-IS(IND-COB) */
            _.Display($"LK-0071-S-A-VLR-IS: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB]}");

            /*" -6931- MOVE LK-0071-S-A-VLR-IS(IND-COB) TO V0COBA-IMP-SEG-VR */
            _.Move(GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB].LK_0071_S_A_VLR_IS, V0COBA_IMP_SEG_VR);

            /*" -6933- DISPLAY 'LK-0071-S-A-VLR-PREMIO: ' LK-0071-S-A-VLR-PREMIO(IND-COB) */
            _.Display($"LK-0071-S-A-VLR-PREMIO: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB]}");

            /*" -6936- MOVE LK-0071-S-A-VLR-PREMIO(IND-COB) TO V0COBA-PRM-TAR-VR */
            _.Move(GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB].LK_0071_S_A_VLR_PREMIO, V0COBA_PRM_TAR_VR);

            /*" -6938- DISPLAY 'LK-0071-S-A-PCT-PARTICIPACAO: ' LK-0071-S-A-PCT-PARTICIPACAO(IND-COB) */
            _.Display($"LK-0071-S-A-PCT-PARTICIPACAO: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB]}");

            /*" -6941- MOVE LK-0071-S-A-PCT-PARTICIPACAO(IND-COB) TO V0COBA-PCT-COBERT */
            _.Move(GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB].LK_0071_S_A_PCT_PARTICIPACAO, V0COBA_PCT_COBERT);

            /*" -6943- DISPLAY 'LK-0071-S-A-COD-RAMO-COBER: ' LK-0071-S-A-COD-RAMO-COBER(IND-COB) */
            _.Display($"LK-0071-S-A-COD-RAMO-COBER: {GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB]}");

            /*" -6947- MOVE LK-0071-S-A-COD-RAMO-COBER(IND-COB) TO V0COBA-RAMOFR */
            _.Move(GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[IND_COB].LK_0071_S_A_COD_RAMO_COBER, V0COBA_RAMOFR);

            /*" -6949- PERFORM R5020-00-INSERE-COBER-APOL */

            R5020_00_INSERE_COBER_APOL_SECTION();

            /*" -6949- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R7055-00-TRATA-MOVDEBCC-SECTION */
        private void R7055_00_TRATA_MOVDEBCC_SECTION()
        {
            /*" -6959- MOVE '7055' TO WNR-EXEC-SQL. */
            _.Move("7055", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -6966- DISPLAY 'R7055-00-TRATA-MOVDEBCC' */
            _.Display($"R7055-00-TRATA-MOVDEBCC");

            /*" -6967- MOVE V0ENDO-NUM-APOL TO MOVDEBCE-NUM-APOLICE */
            _.Move(V0ENDO_NUM_APOL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -6968- MOVE 'CB0005B' TO MOVDEBCE-COD-USUARIO */
            _.Move("CB0005B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -6969- MOVE 76114 TO MOVDEBCE-COD-CONVENIO */
            _.Move(76114, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -6970- MOVE V1SIST-DTMOVABE TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(V1SIST_DTMOVABE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -6971- MOVE V0BILH-DTVENCTO TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(V0BILH_DTVENCTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -6972- MOVE 2 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(2, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -6974- MOVE '6' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move("6", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -6977- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -6980- MOVE PRPFIDEL-DIA-DEBITO TO MOVDEBCE-DIA-DEBITO */
            _.Move(PRPFIDEL_DIA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -6983- MOVE V0BILH-AGENCIA-DEB TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(V0BILH_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -6986- MOVE V0BILH-OPERACAO-DEB TO MOVDEBCE-OPER-CONTA-DEB */
            _.Move(V0BILH_OPERACAO_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

            /*" -6989- MOVE V0BILH-NUMCTA-DEB TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(V0BILH_NUMCTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -6992- MOVE V0BILH-DIGCTA-DEB TO MOVDEBCE-DIG-CONTA-DEB */
            _.Move(V0BILH_DIGCTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -6995- MOVE V0BILH-VLRCAP TO MOVDEBCE-VALOR-DEBITO */
            _.Move(V0BILH_VLRCAP, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -6999- MOVE V0BILH-NUMBIL TO MOVDEBCE-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -7008- MOVE ZEROS TO MOVDEBCE-NUM-PARCELA MOVDEBCE-COD-EMPRESA MOVDEBCE-COD-RETORNO-CEF MOVDEBCE-NSAS MOVDEBCE-NUM-REQUISICAO MOVDEBCE-SEQUENCIA MOVDEBCE-NUM-LOTE MOVDEBCE-VLR-CREDITO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

            /*" -7013- MOVE SPACES TO MOVDEBCE-DTCREDITO MOVDEBCE-STATUS-CARTAO MOVDEBCE-DATA-ENVIO MOVDEBCE-DATA-RETORNO */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);

            /*" -7021- MOVE ZEROS TO VIND-DIADEBITO VIND-AGENCIA VIND-OPERACAO VIND-NUMCONTA VIND-DIGCONTA VIND-CARTAO-CREDITO VIND-USUARIO */
            _.Move(0, VIND_DIADEBITO, VIND_AGENCIA, VIND_OPERACAO, VIND_NUMCONTA, VIND_DIGCONTA, VIND_CARTAO_CREDITO, VIND_USUARIO);

            /*" -7031- MOVE -1 TO VIND-DTENVIO VIND-DTRETORNO VIND-CODRETORNO VIND-REQUISICAO VIND-SEQUENCIA VIND-NUM-LOTE VIND-DTCREDITO VIND-STATUS VIND-VLCREDITO */
            _.Move(-1, VIND_DTENVIO, VIND_DTRETORNO, VIND_CODRETORNO, VIND_REQUISICAO, VIND_SEQUENCIA, VIND_NUM_LOTE, VIND_DTCREDITO, VIND_STATUS, VIND_VLCREDITO);

            /*" -7090- PERFORM R7055_00_TRATA_MOVDEBCC_DB_INSERT_1 */

            R7055_00_TRATA_MOVDEBCC_DB_INSERT_1();

            /*" -7097- DISPLAY 'INS MOVTO_DEBITOCC_CEF ' MOVDEBCE-COD-EMPRESA '/' MOVDEBCE-NUM-APOLICE '/' MOVDEBCE-NUM-ENDOSSO '*SQLCODE: ' SQLCODE */

            $"INS MOVTO_DEBITOCC_CEF {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA}/{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}/{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -7098- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7099- DISPLAY 'R7055-00 (ERRO - INSERT MOVTODEBCC )...' */
                _.Display($"R7055-00 (ERRO - INSERT MOVTODEBCC )...");

                /*" -7104- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -7105- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7107- END-IF */
            }


            /*" -7107- . */

        }

        [StopWatch]
        /*" R7055-00-TRATA-MOVDEBCC-DB-INSERT-1 */
        public void R7055_00_TRATA_MOVDEBCC_DB_INSERT_1()
        {
            /*" -7090- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF ( COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO , NUM_CERTIFICADO) VALUES ( :MOVDEBCE-COD-EMPRESA , :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DATA-MOVIMENTO , CURRENT TIMESTAMP , :MOVDEBCE-DIA-DEBITO :VIND-DIADEBITO , :MOVDEBCE-COD-AGENCIA-DEB :VIND-AGENCIA , :MOVDEBCE-OPER-CONTA-DEB :VIND-OPERACAO , :MOVDEBCE-NUM-CONTA-DEB :VIND-NUMCONTA , :MOVDEBCE-DIG-CONTA-DEB :VIND-DIGCONTA , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-DATA-ENVIO :VIND-DTENVIO , :MOVDEBCE-DATA-RETORNO :VIND-DTRETORNO , :MOVDEBCE-COD-RETORNO-CEF :VIND-CODRETORNO , :MOVDEBCE-NSAS , :MOVDEBCE-COD-USUARIO :VIND-USUARIO , :MOVDEBCE-NUM-REQUISICAO :VIND-REQUISICAO , :MOVDEBCE-NUM-CARTAO :VIND-CARTAO-CREDITO , :MOVDEBCE-SEQUENCIA :VIND-SEQUENCIA , :MOVDEBCE-NUM-LOTE :VIND-NUM-LOTE , :MOVDEBCE-DTCREDITO :VIND-DTCREDITO , :MOVDEBCE-STATUS-CARTAO :VIND-STATUS , :MOVDEBCE-VLR-CREDITO :VIND-VLCREDITO , :MOVDEBCE-NUM-CERTIFICADO ) END-EXEC */

            var r7055_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1 = new R7055_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1()
            {
                MOVDEBCE_COD_EMPRESA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_VALOR_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_DIA_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO.ToString(),
                VIND_DIADEBITO = VIND_DIADEBITO.ToString(),
                MOVDEBCE_COD_AGENCIA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.ToString(),
                VIND_AGENCIA = VIND_AGENCIA.ToString(),
                MOVDEBCE_OPER_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.ToString(),
                VIND_OPERACAO = VIND_OPERACAO.ToString(),
                MOVDEBCE_NUM_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.ToString(),
                VIND_NUMCONTA = VIND_NUMCONTA.ToString(),
                MOVDEBCE_DIG_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.ToString(),
                VIND_DIGCONTA = VIND_DIGCONTA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_DATA_ENVIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.ToString(),
                VIND_DTENVIO = VIND_DTENVIO.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                VIND_DTRETORNO = VIND_DTRETORNO.ToString(),
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                VIND_CODRETORNO = VIND_CODRETORNO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                VIND_USUARIO = VIND_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                VIND_REQUISICAO = VIND_REQUISICAO.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
                VIND_CARTAO_CREDITO = VIND_CARTAO_CREDITO.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                VIND_SEQUENCIA = VIND_SEQUENCIA.ToString(),
                MOVDEBCE_NUM_LOTE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE.ToString(),
                VIND_NUM_LOTE = VIND_NUM_LOTE.ToString(),
                MOVDEBCE_DTCREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.ToString(),
                VIND_DTCREDITO = VIND_DTCREDITO.ToString(),
                MOVDEBCE_STATUS_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO.ToString(),
                VIND_STATUS = VIND_STATUS.ToString(),
                MOVDEBCE_VLR_CREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.ToString(),
                VIND_VLCREDITO = VIND_VLCREDITO.ToString(),
                MOVDEBCE_NUM_CERTIFICADO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO.ToString(),
            };

            R7055_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1.Execute(r7055_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7055_99_SAIDA*/

        [StopWatch]
        /*" R7060-00-INSERT-APOLCOBR-SECTION */
        private void R7060_00_INSERT_APOLCOBR_SECTION()
        {
            /*" -7117- MOVE '7060' TO WNR-EXEC-SQL */
            _.Move("7060", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7120- DISPLAY 'R7060-00-INSERT-APOLCOBR' */
            _.Display($"R7060-00-INSERT-APOLCOBR");

            /*" -7121- MOVE V0ENDO-COD-EMPRESA TO APOLCOBR-COD-EMPRESA */
            _.Move(V0ENDO_COD_EMPRESA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_EMPRESA);

            /*" -7122- MOVE V0ENDO-FONTE TO APOLCOBR-COD-FONTE */
            _.Move(V0ENDO_FONTE, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_FONTE);

            /*" -7123- MOVE V0ENDO-NUM-APOL TO APOLCOBR-NUM-APOLICE */
            _.Move(V0ENDO_NUM_APOL, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE);

            /*" -7124- MOVE V0ENDO-CODPRODU TO APOLCOBR-COD-PRODUTO */
            _.Move(V0ENDO_CODPRODU, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_PRODUTO);

            /*" -7125- MOVE V0BILH-NUM-MATR TO APOLCOBR-NUM-MATRICULA */
            _.Move(V0BILH_NUM_MATR, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_MATRICULA);

            /*" -7127- MOVE V0BILH-AGECOBR TO APOLCOBR-AGE-COBRANCA */
            _.Move(V0BILH_AGECOBR, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_AGE_COBRANCA);

            /*" -7129- MOVE '1' TO APOLCOBR-TIPO-COBRANCA */
            _.Move("1", APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA);

            /*" -7132- MOVE ZEROS TO APOLCOBR-NUM-CARTAO */
            _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO);

            /*" -7135- MOVE PRPFIDEL-DIA-DEBITO TO APOLCOBR-DIA-DEBITO */
            _.Move(PRPFIDEL_DIA_DEBITO, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIA_DEBITO);

            /*" -7138- MOVE V0BILH-AGENCIA-DEB TO APOLCOBR-COD-AGENCIA-DEB */
            _.Move(V0BILH_AGENCIA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB);

            /*" -7141- MOVE V0BILH-OPERACAO-DEB TO APOLCOBR-OPER-CONTA-DEB */
            _.Move(V0BILH_OPERACAO_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB);

            /*" -7144- MOVE V0BILH-NUMCTA-DEB TO APOLCOBR-NUM-CONTA-DEB */
            _.Move(V0BILH_NUMCTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB);

            /*" -7149- MOVE V0BILH-DIGCTA-DEB TO APOLCOBR-DIG-CONTA-DEB */
            _.Move(V0BILH_DIGCTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB);

            /*" -7152- MOVE 9999999 TO APOLCOBR-MARGEM-COMERCIAL */
            _.Move(9999999, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_MARGEM_COMERCIAL);

            /*" -7158- MOVE ZEROS TO APOLCOBR-OPERACAO-CONTA APOLCOBR-NUM-CONTA APOLCOBR-DIG-CONTA APOLCOBR-COD-AGENCIA APOLCOBR-NUM-ENDOSSO */
            _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPERACAO_CONTA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_ENDOSSO);

            /*" -7160- MOVE SPACES TO APOLCOBR-NR-CERTIF-AUTO */
            _.Move("", APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NR_CERTIF_AUTO);

            /*" -7168- MOVE ZEROS TO VIND-AGENCIA VIND-OPERACAO VIND-NUMCONTA VIND-DIGCONTA VIND-CARTAO-CREDITO VIND-DIADEBITO VIND-NRCERTIF */
            _.Move(0, VIND_AGENCIA, VIND_OPERACAO, VIND_NUMCONTA, VIND_DIGCONTA, VIND_CARTAO_CREDITO, VIND_DIADEBITO, VIND_NRCERTIF);

            /*" -7213- PERFORM R7060_00_INSERT_APOLCOBR_DB_INSERT_1 */

            R7060_00_INSERT_APOLCOBR_DB_INSERT_1();

            /*" -7221- DISPLAY 'INS APOLICE_COBRANCA ' APOLCOBR-COD-EMPRESA '/' APOLCOBR-COD-FONTE '/' APOLCOBR-NUM-APOLICE '/' APOLCOBR-NUM-ENDOSSO '*SQLCODE: ' SQLCODE */

            $"INS APOLICE_COBRANCA {APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_EMPRESA}/{APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_FONTE}/{APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE}/{APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_ENDOSSO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -7222- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7223- DISPLAY 'R7060-00 (ERRO - INSERT APOLCOBR   )...' */
                _.Display($"R7060-00 (ERRO - INSERT APOLCOBR   )...");

                /*" -7228- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -7229- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7231- END-IF */
            }


            /*" -7231- . */

        }

        [StopWatch]
        /*" R7060-00-INSERT-APOLCOBR-DB-INSERT-1 */
        public void R7060_00_INSERT_APOLCOBR_DB_INSERT_1()
        {
            /*" -7213- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBRANCA ( COD_EMPRESA , COD_FONTE , NUM_APOLICE , NUM_ENDOSSO , COD_PRODUTO , NUM_MATRICULA , TIPO_COBRANCA , AGE_COBRANCA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , NUM_CARTAO , DIA_DEBITO , NR_CERTIF_AUTO , TIMESTAMP , MARGEM_COMERCIAL) VALUES ( :APOLCOBR-COD-EMPRESA , :APOLCOBR-COD-FONTE , :APOLCOBR-NUM-APOLICE , :APOLCOBR-NUM-ENDOSSO , :APOLCOBR-COD-PRODUTO , :APOLCOBR-NUM-MATRICULA , :APOLCOBR-TIPO-COBRANCA , :APOLCOBR-AGE-COBRANCA , :APOLCOBR-COD-AGENCIA , :APOLCOBR-OPERACAO-CONTA , :APOLCOBR-NUM-CONTA , :APOLCOBR-DIG-CONTA , :APOLCOBR-COD-AGENCIA-DEB:VIND-AGENCIA , :APOLCOBR-OPER-CONTA-DEB :VIND-OPERACAO , :APOLCOBR-NUM-CONTA-DEB :VIND-NUMCONTA , :APOLCOBR-DIG-CONTA-DEB :VIND-DIGCONTA , :APOLCOBR-NUM-CARTAO :VIND-CARTAO-CREDITO , :APOLCOBR-DIA-DEBITO :VIND-DIADEBITO , :APOLCOBR-NR-CERTIF-AUTO :VIND-NRCERTIF , CURRENT TIMESTAMP , :APOLCOBR-MARGEM-COMERCIAL) END-EXEC */

            var r7060_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1 = new R7060_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1()
            {
                APOLCOBR_COD_EMPRESA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_EMPRESA.ToString(),
                APOLCOBR_COD_FONTE = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_FONTE.ToString(),
                APOLCOBR_NUM_APOLICE = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE.ToString(),
                APOLCOBR_NUM_ENDOSSO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_ENDOSSO.ToString(),
                APOLCOBR_COD_PRODUTO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_PRODUTO.ToString(),
                APOLCOBR_NUM_MATRICULA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_MATRICULA.ToString(),
                APOLCOBR_TIPO_COBRANCA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA.ToString(),
                APOLCOBR_AGE_COBRANCA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_AGE_COBRANCA.ToString(),
                APOLCOBR_COD_AGENCIA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA.ToString(),
                APOLCOBR_OPERACAO_CONTA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPERACAO_CONTA.ToString(),
                APOLCOBR_NUM_CONTA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA.ToString(),
                APOLCOBR_DIG_CONTA = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA.ToString(),
                APOLCOBR_COD_AGENCIA_DEB = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB.ToString(),
                VIND_AGENCIA = VIND_AGENCIA.ToString(),
                APOLCOBR_OPER_CONTA_DEB = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB.ToString(),
                VIND_OPERACAO = VIND_OPERACAO.ToString(),
                APOLCOBR_NUM_CONTA_DEB = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB.ToString(),
                VIND_NUMCONTA = VIND_NUMCONTA.ToString(),
                APOLCOBR_DIG_CONTA_DEB = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB.ToString(),
                VIND_DIGCONTA = VIND_DIGCONTA.ToString(),
                APOLCOBR_NUM_CARTAO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO.ToString(),
                VIND_CARTAO_CREDITO = VIND_CARTAO_CREDITO.ToString(),
                APOLCOBR_DIA_DEBITO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIA_DEBITO.ToString(),
                VIND_DIADEBITO = VIND_DIADEBITO.ToString(),
                APOLCOBR_NR_CERTIF_AUTO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NR_CERTIF_AUTO.ToString(),
                VIND_NRCERTIF = VIND_NRCERTIF.ToString(),
                APOLCOBR_MARGEM_COMERCIAL = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_MARGEM_COMERCIAL.ToString(),
            };

            R7060_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1.Execute(r7060_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7060_99_SAIDA*/

        [StopWatch]
        /*" R7500-00-TRATAR-APOL-CORRETOR-SECTION */
        private void R7500_00_TRATAR_APOL_CORRETOR_SECTION()
        {
            /*" -7242- MOVE '7500' TO WNR-EXEC-SQL */
            _.Move("7500", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7252- DISPLAY 'R7500-00-TRATAR-APOL-CORRETOR' */
            _.Display($"R7500-00-TRATAR-APOL-CORRETOR");

            /*" -7253- PERFORM R7510-00-CALCULA-DATAS */

            R7510_00_CALCULA_DATAS_SECTION();

            /*" -7258- PERFORM R7520-00-RECUPERA-INDICADOR */

            R7520_00_RECUPERA_INDICADOR_SECTION();

            /*" -7260- IF PARAMPRO-VALOR-COMISSAO-PRD EQUAL ZEROS AND PARAMPRO-PERCEN-COMIS-FUNC EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD == 00 && PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC == 00)
            {

                /*" -7261- CONTINUE */

                /*" -7262- ELSE */
            }
            else
            {


                /*" -7263- PERFORM R7530-00-INSERE-COMI-INDICADOR */

                R7530_00_INSERE_COMI_INDICADOR_SECTION();

                /*" -7265- END-IF */
            }


            /*" -7267- PERFORM R7540-00-RECUPERA-CORRETOR */

            R7540_00_RECUPERA_CORRETOR_SECTION();

            /*" -7270- DISPLAY '7500-02' '<VALOR-COMISSAO=' PARAMPRO-VALOR-COMISSAO-PRD '>' '<PRCT-COMISSAO=' PARAMPRO-PERCEN-COMIS-FUNC '>' */

            $"7500-02<VALOR-COMISSAO={PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD}><PRCT-COMISSAO={PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC}>"
            .Display();

            /*" -7272- IF PARAMPRO-VALOR-COMISSAO-PRD EQUAL ZEROS AND PARAMPRO-PERCEN-COMIS-FUNC EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD == 00 && PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC == 00)
            {

                /*" -7273- CONTINUE */

                /*" -7277- ELSE */
            }
            else
            {


                /*" -7293- DISPLAY '7500-03' '<DTINIVIG-END=' V0ENDO-DTINIVIG '>' '<DTTERVIG-END=' V0ENDO-DTTERVIG '>' */

                $"7500-03<DTINIVIG-END={V0ENDO_DTINIVIG}><DTTERVIG-END={V0ENDO_DTTERVIG}>"
                .Display();

                /*" -7295- MOVE WS-TER-SEG-COMI TO V0ENDO-DTTERVIG */
                _.Move(WS_TER_SEG_COMI, V0ENDO_DTTERVIG);

                /*" -7296- MOVE 17256 TO V0APCR-CODCORR */
                _.Move(17256, V0APCR_CODCORR);

                /*" -7301- MOVE 100 TO V0APCR-PCPARCOR */
                _.Move(100, V0APCR_PCPARCOR);

                /*" -7302- PERFORM R7550-00-INSERE-COMIS-CORRETOR */

                R7550_00_INSERE_COMIS_CORRETOR_SECTION();

                /*" -7304- END-IF */
            }


            /*" -7304- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7500_99_SAIDA*/

        [StopWatch]
        /*" R7510-00-CALCULA-DATAS-SECTION */
        private void R7510_00_CALCULA_DATAS_SECTION()
        {
            /*" -7314- MOVE '7510' TO WNR-EXEC-SQL */
            _.Move("7510", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7317- DISPLAY 'R7510-00-CALCULA-DATAS' */
            _.Display($"R7510-00-CALCULA-DATAS");

            /*" -7322- PERFORM R7510_00_CALCULA_DATAS_DB_SELECT_1 */

            R7510_00_CALCULA_DATAS_DB_SELECT_1();

            /*" -7327- DISPLAY 'SEL SISTEMAS BI ' WS-INI-SEG-COMI '*SQLCODE: ' SQLCODE */

            $"SEL SISTEMAS BI {WS_INI_SEG_COMI}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -7328- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7331- DISPLAY 'R7510-00 (ERRO - SELECT DATA-INIVIG)' ' BILHETE     = ' V0BILH-NUMBIL ' DATA-INIVIG = ' V0ENDO-DTINIVIG */

                $"R7510-00 (ERRO - SELECT DATA-INIVIG) BILHETE     = {V0BILH_NUMBIL} DATA-INIVIG = {V0ENDO_DTINIVIG}"
                .Display();

                /*" -7332- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7334- END-IF */
            }


            /*" -7339- PERFORM R7510_00_CALCULA_DATAS_DB_SELECT_2 */

            R7510_00_CALCULA_DATAS_DB_SELECT_2();

            /*" -7344- DISPLAY 'SEL SISTEMAS BI ' WS-TER-SEG-COMI '*SQLCODE: ' SQLCODE */

            $"SEL SISTEMAS BI {WS_TER_SEG_COMI}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -7345- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7348- DISPLAY 'R7510-00 (ERRO - SELECT DATA-TERVIG)' ' BILHETE     = ' V0BILH-NUMBIL ' DATA-INIVIG = ' V0ENDO-DTINIVIG */

                $"R7510-00 (ERRO - SELECT DATA-TERVIG) BILHETE     = {V0BILH_NUMBIL} DATA-INIVIG = {V0ENDO_DTINIVIG}"
                .Display();

                /*" -7349- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7352- END-IF */
            }


            /*" -7352- . */

        }

        [StopWatch]
        /*" R7510-00-CALCULA-DATAS-DB-SELECT-1 */
        public void R7510_00_CALCULA_DATAS_DB_SELECT_1()
        {
            /*" -7322- EXEC SQL SELECT DATE(:V0ENDO-DTINIVIG) + 1 DAY INTO :WS-INI-SEG-COMI FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC */

            var r7510_00_CALCULA_DATAS_DB_SELECT_1_Query1 = new R7510_00_CALCULA_DATAS_DB_SELECT_1_Query1()
            {
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R7510_00_CALCULA_DATAS_DB_SELECT_1_Query1.Execute(r7510_00_CALCULA_DATAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_INI_SEG_COMI, WS_INI_SEG_COMI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7510_99_SAIDA*/

        [StopWatch]
        /*" R7510-00-CALCULA-DATAS-DB-SELECT-2 */
        public void R7510_00_CALCULA_DATAS_DB_SELECT_2()
        {
            /*" -7339- EXEC SQL SELECT DATE(:WWORK-MAX-DTTERVIG) - 1 DAY INTO :WS-TER-SEG-COMI FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC */

            var r7510_00_CALCULA_DATAS_DB_SELECT_2_Query1 = new R7510_00_CALCULA_DATAS_DB_SELECT_2_Query1()
            {
                WWORK_MAX_DTTERVIG = WWORK_MAX_DTTERVIG.ToString(),
            };

            var executed_1 = R7510_00_CALCULA_DATAS_DB_SELECT_2_Query1.Execute(r7510_00_CALCULA_DATAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_TER_SEG_COMI, WS_TER_SEG_COMI);
            }


        }

        [StopWatch]
        /*" R7520-00-RECUPERA-INDICADOR-SECTION */
        private void R7520_00_RECUPERA_INDICADOR_SECTION()
        {
            /*" -7362- MOVE '7520' TO WNR-EXEC-SQL. */
            _.Move("7520", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7367- DISPLAY 'R7520-00-RECUPERA-INDICADOR' */
            _.Display($"R7520-00-RECUPERA-INDICADOR");

            /*" -7377- PERFORM R7520_00_RECUPERA_INDICADOR_DB_SELECT_1 */

            R7520_00_RECUPERA_INDICADOR_DB_SELECT_1();

            /*" -7382- DISPLAY 'SEL PARAM_PRODUTO ' V0ENDO-CODPRODU '*SQLCODE: ' SQLCODE */

            $"SEL PARAM_PRODUTO {V0ENDO_CODPRODU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -7383- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7384- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7387- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC */
                    _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);

                    /*" -7388- ELSE */
                }
                else
                {


                    /*" -7389- DISPLAY 'R1066-00 - PROBLEMAS SELECT PARAMPRO TIPO 1' */
                    _.Display($"R1066-00 - PROBLEMAS SELECT PARAMPRO TIPO 1");

                    /*" -7392- DISPLAY 'BILHETE : ' V0BILH-NUMBIL '  ' 'PRODUTO : ' V0ENDO-CODPRODU 'INICIO  : ' V0ENDO-DTINIVIG */

                    $"BILHETE : {V0BILH_NUMBIL}  PRODUTO : {V0ENDO_CODPRODU}INICIO  : {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -7393- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7394- END-IF */
                }


                /*" -7396- END-IF */
            }


            /*" -7396- . */

        }

        [StopWatch]
        /*" R7520-00-RECUPERA-INDICADOR-DB-SELECT-1 */
        public void R7520_00_RECUPERA_INDICADOR_DB_SELECT_1()
        {
            /*" -7377- EXEC SQL SELECT VALOR_COMISSAO_PRD , PERCEN_COMIS_FUNC INTO :PARAMPRO-VALOR-COMISSAO-PRD , :PARAMPRO-PERCEN-COMIS-FUNC FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :V0ENDO-CODPRODU AND TIPO_FUNCIONARIO = '1' AND DATA_INIVIGENCIA <= :V0ENDO-DTINIVIG AND DATA_TERVIGENCIA >= :V0ENDO-DTINIVIG END-EXEC */

            var r7520_00_RECUPERA_INDICADOR_DB_SELECT_1_Query1 = new R7520_00_RECUPERA_INDICADOR_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R7520_00_RECUPERA_INDICADOR_DB_SELECT_1_Query1.Execute(r7520_00_RECUPERA_INDICADOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
                _.Move(executed_1.PARAMPRO_PERCEN_COMIS_FUNC, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7520_99_SAIDA*/

        [StopWatch]
        /*" R7530-00-INSERE-COMI-INDICADOR-SECTION */
        private void R7530_00_INSERE_COMI_INDICADOR_SECTION()
        {
            /*" -7406- MOVE '7530' TO WNR-EXEC-SQL */
            _.Move("7530", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7411- DISPLAY 'R7530-00-INSERE-COMI-INDICADOR' */
            _.Display($"R7530-00-INSERE-COMI-INDICADOR");

            /*" -7412- IF WS-IND-CORRETOR = 1 */

            if (WS_IND_CORRETOR == 1)
            {

                /*" -7413- GO TO R7530-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7530_99_SAIDA*/ //GOTO
                return;

                /*" -7415- END-IF */
            }


            /*" -7416- MOVE 19224 TO V0APCR-CODCORR */
            _.Move(19224, V0APCR_CODCORR);

            /*" -7418- MOVE 50 TO V0APCR-PCPARCOR */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -7421- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -7422- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00)
            {

                /*" -7424- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-PERCEN-COMIS-FUNC * 2) */
                AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC * 2);

                /*" -7425- ELSE */
            }
            else
            {


                /*" -7427- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100 */
                AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

                /*" -7429- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100 */
                AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;

                /*" -7431- END-IF */
            }


            /*" -7433- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -7434- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -7435- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -7436- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -7437- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -7438- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -7439- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -7440- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -7441- MOVE '2' TO V0APCR-INDCRT */
            _.Move("2", V0APCR_INDCRT);

            /*" -7443- MOVE ZEROS TO V0APCR-COD-EMPRESA */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -7445- MOVE 'CB0005B' TO V0APCR-COD-USUARIO */
            _.Move("CB0005B", V0APCR_COD_USUARIO);

            /*" -7447- PERFORM R1068-00-INSERT-APOLCORRET */

            R1068_00_INSERT_APOLCORRET_SECTION();

            /*" -7447- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7530_99_SAIDA*/

        [StopWatch]
        /*" R7540-00-RECUPERA-CORRETOR-SECTION */
        private void R7540_00_RECUPERA_CORRETOR_SECTION()
        {
            /*" -7457- MOVE '7540' TO WNR-EXEC-SQL */
            _.Move("7540", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7460- DISPLAY 'R7540-00-RECUPERA-CORRETOR' */
            _.Display($"R7540-00-RECUPERA-CORRETOR");

            /*" -7470- PERFORM R7540_00_RECUPERA_CORRETOR_DB_SELECT_1 */

            R7540_00_RECUPERA_CORRETOR_DB_SELECT_1();

            /*" -7475- DISPLAY 'SEL PARAM_PRODUTO ' V0ENDO-CODPRODU '*SQLCODE: ' SQLCODE */

            $"SEL PARAM_PRODUTO {V0ENDO_CODPRODU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -7476- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7477- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7480- MOVE ZEROS TO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC */
                    _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);

                    /*" -7481- ELSE */
                }
                else
                {


                    /*" -7482- DISPLAY 'R1067-00 - PROBLEMAS SELECT PARAMPRO TIPO 8' */
                    _.Display($"R1067-00 - PROBLEMAS SELECT PARAMPRO TIPO 8");

                    /*" -7485- DISPLAY 'BILHETE : ' V0BILH-NUMBIL '  ' 'PRODUTO : ' V0ENDO-CODPRODU 'INICIO  : ' V0ENDO-DTINIVIG */

                    $"BILHETE : {V0BILH_NUMBIL}  PRODUTO : {V0ENDO_CODPRODU}INICIO  : {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -7486- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7487- END-IF */
                }


                /*" -7489- END-IF */
            }


            /*" -7489- . */

        }

        [StopWatch]
        /*" R7540-00-RECUPERA-CORRETOR-DB-SELECT-1 */
        public void R7540_00_RECUPERA_CORRETOR_DB_SELECT_1()
        {
            /*" -7470- EXEC SQL SELECT VALOR_COMISSAO_PRD , PERCEN_COMIS_FUNC INTO :PARAMPRO-VALOR-COMISSAO-PRD , :PARAMPRO-PERCEN-COMIS-FUNC FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :V0ENDO-CODPRODU AND TIPO_FUNCIONARIO = '8' AND DATA_INIVIGENCIA <= :V0ENDO-DTINIVIG AND DATA_TERVIGENCIA >= :V0ENDO-DTINIVIG END-EXEC */

            var r7540_00_RECUPERA_CORRETOR_DB_SELECT_1_Query1 = new R7540_00_RECUPERA_CORRETOR_DB_SELECT_1_Query1()
            {
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R7540_00_RECUPERA_CORRETOR_DB_SELECT_1_Query1.Execute(r7540_00_RECUPERA_CORRETOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
                _.Move(executed_1.PARAMPRO_PERCEN_COMIS_FUNC, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7540_99_SAIDA*/

        [StopWatch]
        /*" R7550-00-INSERE-COMIS-CORRETOR-SECTION */
        private void R7550_00_INSERE_COMIS_CORRETOR_SECTION()
        {
            /*" -7499- MOVE '7540' TO WNR-EXEC-SQL */
            _.Move("7540", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7502- DISPLAY 'R7550-00-INSERE-COMIS-CORRETOR' */
            _.Display($"R7550-00-INSERE-COMIS-CORRETOR");

            /*" -7505- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -7507- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS AND V0APCR-PCPARCOR EQUAL 100 */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00 && V0APCR_PCPARCOR == 100)
            {

                /*" -7508- MOVE PARAMPRO-PERCEN-COMIS-FUNC TO AUX-PERCENT */
                _.Move(PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC, AREA_DE_WORK.AUX_PERCENT);

                /*" -7509- ELSE */
            }
            else
            {


                /*" -7510- IF PARAMPRO-PERCEN-COMIS-FUNC NOT EQUAL ZEROS */

                if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC != 00)
                {

                    /*" -7512- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-PERCEN-COMIS-FUNC * 2) */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC * 2);

                    /*" -7513- ELSE */
                }
                else
                {


                    /*" -7515- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100 */
                    AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

                    /*" -7517- COMPUTE AUX-PERCENT EQUAL (PARAMPRO-VALOR-COMISSAO-PRD / AUX-VALBAS) * 100 */
                    AREA_DE_WORK.AUX_PERCENT.Value = (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD / AREA_DE_WORK.AUX_VALBAS) * 100;

                    /*" -7518- END-IF */
                }


                /*" -7520- END-IF */
            }


            /*" -7522- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -7523- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -7524- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -7525- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -7526- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -7527- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -7528- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -7529- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -7530- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -7532- MOVE ZEROS TO V0APCR-COD-EMPRESA */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -7534- MOVE 'CB0005B' TO V0APCR-COD-USUARIO */
            _.Move("CB0005B", V0APCR_COD_USUARIO);

            /*" -7536- PERFORM R1068-00-INSERT-APOLCORRET */

            R1068_00_INSERT_APOLCORRET_SECTION();

            /*" -7536- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7550_99_SAIDA*/

        [StopWatch]
        /*" R8000-JV1-BUSCA-PRODUTO-SECTION */
        private void R8000_JV1_BUSCA_PRODUTO_SECTION()
        {
            /*" -7547- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7551- DISPLAY 'R8000-JV1-BUSCA-PRODUTO' */
            _.Display($"R8000-JV1-BUSCA-PRODUTO");

            /*" -7563- PERFORM R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1 */

            R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1();

            /*" -7568- DISPLAY 'SEL PRODUTO/PARAMETROS_GERAIS ' PRODUTO-COD-PRODUTO '*SQLCODE: ' SQLCODE */

            $"SEL PRODUTO/PARAMETROS_GERAIS {PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -7569- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7570- DISPLAY 'R8000-JV1-BUSCA-PRODUTO  ..' */
                _.Display($"R8000-JV1-BUSCA-PRODUTO  ..");

                /*" -7571- DISPLAY 'PRODUTO - ' PRODUTO-COD-PRODUTO */
                _.Display($"PRODUTO - {PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO}");

                /*" -7572- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -7573- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7573- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-JV1-BUSCA-PRODUTO-DB-SELECT-1 */
        public void R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1()
        {
            /*" -7563- EXEC SQL SELECT PD.COD_EMPRESA ,PD.RAMO_EMISSOR ,PG.COD_EMPRESA_CAP INTO :PRODUTO-COD-EMPRESA ,:PRODUTO-RAMO-EMISSOR ,:PARAMGER-COD-EMPRESA-CAP FROM SEGUROS.PRODUTO PD, SEGUROS.PARAMETROS_GERAIS PG WHERE PD.COD_PRODUTO = :PRODUTO-COD-PRODUTO AND PD.COD_EMPRESA = PG.COD_EMPRESA WITH UR END-EXEC. */

            var r8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1 = new R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1.Execute(r8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
                _.Move(executed_1.PRODUTO_RAMO_EMISSOR, PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR);
                _.Move(executed_1.PARAMGER_COD_EMPRESA_CAP, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-SECTION */
        private void R8100_00_DECLARE_CBO_SECTION()
        {
            /*" -7587- MOVE '8100' TO WNR-EXEC-SQL. */
            _.Move("8100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7593- PERFORM R8100_00_DECLARE_CBO_DB_DECLARE_1 */

            R8100_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -7595- PERFORM R8100_00_DECLARE_CBO_DB_OPEN_1 */

            R8100_00_DECLARE_CBO_DB_OPEN_1();

            /*" -7600- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7601- DISPLAY 'R8100 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R8100 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -7602- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -7603- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-OPEN-1 */
        public void R8100_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -7595- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8110-00-FETCH-CBO-SECTION */
        private void R8110_00_FETCH_CBO_SECTION()
        {
            /*" -7614- MOVE '8110' TO WNR-EXEC-SQL. */
            _.Move("8110", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7617- PERFORM R8110_00_FETCH_CBO_DB_FETCH_1 */

            R8110_00_FETCH_CBO_DB_FETCH_1();

            /*" -7622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7623- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7624- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", AREA_DE_WORK.WFIM_CBO);

                    /*" -7624- PERFORM R8110_00_FETCH_CBO_DB_CLOSE_1 */

                    R8110_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -7626- ELSE */
                }
                else
                {


                    /*" -7626- PERFORM R8110_00_FETCH_CBO_DB_CLOSE_2 */

                    R8110_00_FETCH_CBO_DB_CLOSE_2();

                    /*" -7628- DISPLAY '8110 - (PROBLEMAS NO FETCH CCBO     ) ..' */
                    _.Display($"8110 - (PROBLEMAS NO FETCH CCBO     ) ..");

                    /*" -7629- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -7630- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-FETCH-1 */
        public void R8110_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -7617- EXEC SQL FETCH CCBO INTO :CBO-COD-CBO, :CBO-DESCR-CBO END-EXEC. */

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
            /*" -7624- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8110_99_SAIDA*/

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-CLOSE-2 */
        public void R8110_00_FETCH_CBO_DB_CLOSE_2()
        {
            /*" -7626- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }

        [StopWatch]
        /*" R8120-00-CARREGA-CBO-SECTION */
        private void R8120_00_CARREGA_CBO_SECTION()
        {
            /*" -7642- MOVE '8120' TO WNR-EXEC-SQL. */
            _.Move("8120", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7645- MOVE CBO-DESCR-CBO TO TAB-DESCR-CBO-C (CBO-COD-CBO) */
            _.Move(CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_2[CBO_COD_CBO].TAB_DESCR_CBO_C);

            /*" -7646- PERFORM R8110-00-FETCH-CBO. */

            R8110_00_FETCH_CBO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8120_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-PROCURA-RISCO-PROP-SECTION */
        private void R8500_00_PROCURA_RISCO_PROP_SECTION()
        {
            /*" -7657- MOVE 'R8500' TO WNR-EXEC-SQL */
            _.Move("R8500", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7661- DISPLAY 'R8500-00-PROCURA-RISCO-PROP' */
            _.Display($"R8500-00-PROCURA-RISCO-PROP");

            /*" -7662- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -7664- MOVE 'CB0005B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("CB0005B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -7665- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -7667- MOVE V0CONV-NUM-PROPOSTA-SIVPF TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(V0CONV_NUM_PROPOSTA_SIVPF, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -7668- MOVE 0 TO LK-VG009-IND-ERRO */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO);

            /*" -7670- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA);

            /*" -7672- MOVE 0 TO LK-VG009-SQLCODE WS-ERRO-VG009 */
            _.Move(0, SPVG009W.LK_VG009_SQLCODE, WS_ERRO_VG009);

            /*" -7674- MOVE SPACES TO LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_SQLERRMC);

            /*" -7676- MOVE 'SPBVG009' TO WS-PROGRAMA */
            _.Move("SPBVG009", WS_PROGRAMA);

            /*" -7697- CALL WS-PROGRAMA USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_PROGRAMA, SPVG009W);

            /*" -7698- IF LK-VG009-IND-ERRO NOT EQUAL ZEROS AND 1 */

            if (!SPVG009W.LK_VG009_IND_ERRO.In("00", "1"))
            {

                /*" -7699- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -7700- DISPLAY '* R8500 - PROBLEMAS CALL SUBROTINA SPBVG009   *' */
                _.Display($"* R8500 - PROBLEMAS CALL SUBROTINA SPBVG009   *");

                /*" -7701- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -7702- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -7703- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -7704- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -7705- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -7706- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -7707- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -7708- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -7709- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -7710- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -7711- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7713- END-IF */
            }


            /*" -7714-  EVALUATE TRUE  */

            /*" -7715-  WHEN LK-VG009-IND-ERRO = 00  */

            /*" -7715- IF LK-VG009-IND-ERRO = 00 */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -7718- PERFORM R8550-00-GRAVA-CLASSIF-RISCO */

                R8550_00_GRAVA_CLASSIF_RISCO_SECTION();

                /*" -7719- IF LK-VG009-S-COD-CLASSIF-RISCO EQUAL 04 */

                if (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO == 04)
                {

                    /*" -7722- DISPLAY 'DESPREZADO RISCO CRITICO.: ' V0BILH-NUMBIL ' >> ' V0CONV-NUM-PROPOSTA-SIVPF */

                    $"DESPREZADO RISCO CRITICO.: {V0BILH_NUMBIL} >> {V0CONV_NUM_PROPOSTA_SIVPF}"
                    .Display();

                    /*" -7723- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -7724- ADD 1 TO WS-QT-RISCO-CRITICO */
                    WS_QT_RISCO_CRITICO.Value = WS_QT_RISCO_CRITICO + 1;

                    /*" -7725- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -7726- MOVE 'S' TO N88-VAI-LEITURA */
                    _.Move("S", N88_VAI_LEITURA);

                    /*" -7728- GO TO R8500-99-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_EXIT*/ //GOTO
                    return;

                    /*" -7729- END-IF */
                }


                /*" -7730-  WHEN LK-VG009-IND-ERRO = 01  */

                /*" -7730- ELSE IF LK-VG009-IND-ERRO = 01 */
            }
            else

            if (SPVG009W.LK_VG009_IND_ERRO == 01)
            {

                /*" -7731- IF LK-VG009-SQLCODE = +100 */

                if (SPVG009W.LK_VG009_SQLCODE == +100)
                {

                    /*" -7732- PERFORM R8560-00-GRAVA-EMITE-SEM-RISCO */

                    R8560_00_GRAVA_EMITE_SEM_RISCO_SECTION();

                    /*" -7733- ELSE */
                }
                else
                {


                    /*" -7734- MOVE 1 TO WS-ERRO-VG009 */
                    _.Move(1, WS_ERRO_VG009);

                    /*" -7735- END-IF */
                }


                /*" -7736-  WHEN OTHER  */

                /*" -7736- ELSE */
            }
            else
            {


                /*" -7737- MOVE 1 TO WS-ERRO-VG009 */
                _.Move(1, WS_ERRO_VG009);

                /*" -7739-  END-EVALUATE  */

                /*" -7739- END-IF */
            }


            /*" -7740- IF WS-ERRO-VG009 NOT EQUAL ZEROS */

            if (WS_ERRO_VG009 != 00)
            {

                /*" -7741- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -7742- DISPLAY '* R8501 - PROBLEMAS CALL SUBROTINA SPBVG009   *' */
                _.Display($"* R8501 - PROBLEMAS CALL SUBROTINA SPBVG009   *");

                /*" -7743- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -7744- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -7745- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -7746- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -7747- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -7748- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -7749- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -7750- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -7752- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -7753- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -7754- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7755- END-IF */
            }


            /*" -7755- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_EXIT*/

        [StopWatch]
        /*" R8550-00-GRAVA-CLASSIF-RISCO-SECTION */
        private void R8550_00_GRAVA_CLASSIF_RISCO_SECTION()
        {
            /*" -7768- MOVE 'R8550' TO WNR-EXEC-SQL */
            _.Move("R8550", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7772- DISPLAY 'R8550-00-GRAVA-CLASSIF-RISCO ' */
            _.Display($"R8550-00-GRAVA-CLASSIF-RISCO ");

            /*" -7773- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -7774- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -7775- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -7776- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -7777- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -7778- MOVE V0CLIE-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(V0CLIE_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -7779- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -7780- MOVE 'CB0005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("CB0005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -7781- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -7782- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -7783- MOVE 35 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(35, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -7785- MOVE 'CADASTRAMENTO DE AVALIACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CADASTRAMENTO DE AVALIACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -7787- ADD 1 TO WS-QT-EMISSAO-C-RISCO */
            WS_QT_EMISSAO_C_RISCO.Value = WS_QT_EMISSAO_C_RISCO + 1;

            /*" -7789- EVALUATE LK-VG009-S-COD-CLASSIF-RISCO */
            switch (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO.Value)
            {

                /*" -7790- WHEN 01 */
                case 01:

                    /*" -7792- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO BAIXA' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO BAIXA", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7794- MOVE 2 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(2, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -7795- WHEN 02 */
                    break;
                case 02:

                    /*" -7797- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO MODERADO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO MODERADO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7799- MOVE 3 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(3, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -7800- WHEN 03 */
                    break;
                case 03:

                    /*" -7802- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO ELEVADO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO ELEVADO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7804- MOVE 4 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(4, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -7805- WHEN 04 */
                    break;
                case 04:

                    /*" -7807- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO CRITICO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO CRITICO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7808- MOVE 1 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(1, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -7809- WHEN OTHER */
                    break;
                default:

                    /*" -7812- DISPLAY 'ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA' LK-VG009-S-COD-CLASSIF-RISCO */
                    _.Display($"ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA{SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO}");

                    /*" -7813- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7815- END-EVALUATE */
                    break;
            }


            /*" -7817- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -7818- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -7819- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -7823- DISPLAY 'ERRO JAH GRAVADO 8550 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8550 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -7824- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -7825- ELSE */
                }
                else
                {


                    /*" -7826- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7827- DISPLAY '* 8550 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 8550 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -7828- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7829- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -7830- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -7831- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -7832- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -7833- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -7834- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -7836- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7837- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -7838- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7839- END-IF */
                }


                /*" -7841- END-IF */
            }


            /*" -7842- MOVE 'CB0005B' TO VG078-COD-USUARIO */
            _.Move("CB0005B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -7843- MOVE V0BILH-NUMBIL TO VG078-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -7845- MOVE 55 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(55, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -7846- PERFORM R9997-00-INSERE-ANDAMENTO */

            R9997_00_INSERE_ANDAMENTO_SECTION();

            /*" -7846- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/

        [StopWatch]
        /*" R8560-00-GRAVA-EMITE-SEM-RISCO-SECTION */
        private void R8560_00_GRAVA_EMITE_SEM_RISCO_SECTION()
        {
            /*" -7857- MOVE 'R8560' TO WNR-EXEC-SQL */
            _.Move("R8560", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7864- DISPLAY 'R8560-00-GRAVA-EMITE-SEM-RISCO' */
            _.Display($"R8560-00-GRAVA-EMITE-SEM-RISCO");

            /*" -7865- MOVE 5 TO WS-COD-CRITICA */
            _.Move(5, WS_COD_CRITICA);

            /*" -7867- PERFORM R8600-00-CONS-COD-CRITICA */

            R8600_00_CONS_COD_CRITICA_SECTION();

            /*" -7868- IF VG001-IND-EXISTE EQUAL 'S' */

            if (SPVG001V.VG001_IND_EXISTE == "S")
            {

                /*" -7869- GO TO R8560-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8560_99_SAIDA*/ //GOTO
                return;

                /*" -7871- END-IF */
            }


            /*" -7873- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -7874- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -7875- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -7876- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -7877- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -7878- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -7879- MOVE V0CLIE-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(V0CLIE_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -7880- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -7881- MOVE 'CB0005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("CB0005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -7882- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -7883- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -7884- MOVE 45 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(45, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -7885- MOVE 5 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(5, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -7888- MOVE 'EMISSAO DE BILHETE SEM CLASSIFICACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T VG078-DES-ANDAMENTO-TEXT */
            _.Move("EMISSAO DE BILHETE SEM CLASSIFICACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

            /*" -7890- ADD 1 TO WS-QT-EMISSAO-S-RISCO */
            WS_QT_EMISSAO_S_RISCO.Value = WS_QT_EMISSAO_S_RISCO + 1;

            /*" -7892- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -7893- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -7894- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -7898- DISPLAY 'ERRO JAH GRAVADO 8560 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8560 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -7899- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -7900- ELSE */
                }
                else
                {


                    /*" -7901- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7902- DISPLAY '* 8560 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 8560 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -7903- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7904- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -7905- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -7906- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -7907- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -7908- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -7909- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -7911- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7912- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -7913- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7914- END-IF */
                }


                /*" -7916- END-IF */
            }


            /*" -7917- MOVE 'CB0005B' TO VG078-COD-USUARIO */
            _.Move("CB0005B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -7918- MOVE V0BILH-NUMBIL TO VG078-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -7920- MOVE 55 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(55, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -7921- PERFORM R9997-00-INSERE-ANDAMENTO */

            R9997_00_INSERE_ANDAMENTO_SECTION();

            /*" -7921- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8560_99_SAIDA*/

        [StopWatch]
        /*" R8600-00-CONS-COD-CRITICA-SECTION */
        private void R8600_00_CONS_COD_CRITICA_SECTION()
        {
            /*" -7930- MOVE '8600' TO WNR-EXEC-SQL. */
            _.Move("8600", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7932- DISPLAY 'R8600-00-CONS-COD-CRITICA' */
            _.Display($"R8600-00-CONS-COD-CRITICA");

            /*" -7933- MOVE 'N' TO VG001-IND-EXISTE */
            _.Move("N", SPVG001V.VG001_IND_EXISTE);

            /*" -7934- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -7935- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -7936- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -7937- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -7938- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -7939- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -7940- MOVE WS-COD-CRITICA TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WS_COD_CRITICA, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -7941- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -7942- MOVE 'CB0005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("CB0005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -7943- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -7944- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -7945- MOVE 00 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(00, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -7947- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -7949- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -7950- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -7951- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -7952- MOVE 'S' TO VG001-IND-EXISTE */
                    _.Move("S", SPVG001V.VG001_IND_EXISTE);

                    /*" -7953- ELSE */
                }
                else
                {


                    /*" -7954- MOVE 'N' TO VG001-IND-EXISTE */
                    _.Move("N", SPVG001V.VG001_IND_EXISTE);

                    /*" -7955- END-IF */
                }


                /*" -7956- ELSE */
            }
            else
            {


                /*" -7957- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -7958- DISPLAY '* 8600 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"* 8600 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -7959- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -7960- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -7961- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -7962- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -7963- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -7964- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -7965- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -7967- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -7968- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -7969- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7970- END-IF */
            }


            /*" -7970- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/

        [StopWatch]
        /*" R8650-00-GRAVA-RISCO-PEPS-SECTION */
        private void R8650_00_GRAVA_RISCO_PEPS_SECTION()
        {
            /*" -7982- MOVE 'R8650' TO WNR-EXEC-SQL */
            _.Move("R8650", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -7988- DISPLAY 'R8650-00-GRAVA-RISCO-PEPS' */
            _.Display($"R8650-00-GRAVA-RISCO-PEPS");

            /*" -7990- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -7991- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -7992- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -7993- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -7994- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -7995- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -7996- MOVE V0CLIE-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(V0CLIE_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -7997- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -7998- MOVE 'CB0005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("CB0005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -7999- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -8000- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -8001- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -8002- MOVE 6 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(6, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -8004- MOVE 'CADASTRAMENTO DE BILHETE AMPARO COM CLIENTE PEPS' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CADASTRAMENTO DE BILHETE AMPARO COM CLIENTE PEPS", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -8006- ADD 1 TO WS-QT-RISCO-PEPS */
            WS_QT_RISCO_PEPS.Value = WS_QT_RISCO_PEPS + 1;

            /*" -8008- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -8009- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -8010- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -8014- DISPLAY 'ERRO JAH GRAVADO 8650 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8650 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -8015- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -8016- ELSE */
                }
                else
                {


                    /*" -8017- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -8018- DISPLAY '* 8650 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 8650 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -8019- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -8020- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -8021- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -8022- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -8023- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -8024- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -8025- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -8027- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -8028- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -8029- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -8030- END-IF */
                }


                /*" -8031- END-IF */
            }


            /*" -8031- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8650_99_SAIDA*/

        [StopWatch]
        /*" R9997-00-INSERE-ANDAMENTO-SECTION */
        private void R9997_00_INSERE_ANDAMENTO_SECTION()
        {
            /*" -8041- MOVE '9997' TO WNR-EXEC-SQL. */
            _.Move("9997", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -8044- DISPLAY 'R9997-00-INSERE-ANDAMENTO' */
            _.Display($"R9997-00-INSERE-ANDAMENTO");

            /*" -8045- MOVE V0BILH-NUMBIL TO VG078-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -8047- MOVE 61 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(61, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -8049- MOVE 'CB0005B' TO VG078-COD-USUARIO */
            _.Move("CB0005B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -8064- PERFORM R9997_00_INSERE_ANDAMENTO_DB_INSERT_1 */

            R9997_00_INSERE_ANDAMENTO_DB_INSERT_1();

            /*" -8069- DISPLAY 'INS VG_ANDAMENTO_PROP ' VG078-NUM-CERTIFICADO '*SQLCODE: ' SQLCODE */

            $"INS VG_ANDAMENTO_PROP {VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -8070- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -8071- CONTINUE */

                /*" -8072- ELSE */
            }
            else
            {


                /*" -8073- DISPLAY 'R9997-00 - PROBLEMAS NO INSERT VG_ANDAMENTO_PROP' */
                _.Display($"R9997-00 - PROBLEMAS NO INSERT VG_ANDAMENTO_PROP");

                /*" -8074- DISPLAY 'NUM-BILHETE     = ' VG078-NUM-CERTIFICADO */
                _.Display($"NUM-BILHETE     = {VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO}");

                /*" -8075- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -8076- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8078- END-IF */
            }


            /*" -8080- . */

        }

        [StopWatch]
        /*" R9997-00-INSERE-ANDAMENTO-DB-INSERT-1 */
        public void R9997_00_INSERE_ANDAMENTO_DB_INSERT_1()
        {
            /*" -8064- EXEC SQL INSERT INTO SEGUROS.VG_ANDAMENTO_PROP ( NUM_CERTIFICADO , DTH_CADASTRAMENTO , DES_ANDAMENTO , COD_USUARIO ) VALUES ( :VG078-NUM-CERTIFICADO , CURRENT TIMESTAMP , :VG078-DES-ANDAMENTO , :VG078-COD-USUARIO ) END-EXEC */

            var r9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1 = new R9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1()
            {
                VG078_NUM_CERTIFICADO = VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO.ToString(),
                VG078_DES_ANDAMENTO = VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.ToString(),
                VG078_COD_USUARIO = VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO.ToString(),
            };

            R9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1.Execute(r9997_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9997_99_SAIDA*/

        [StopWatch]
        /*" R9998-00-VERIFICA-PEP-SECTION */
        private void R9998_00_VERIFICA_PEP_SECTION()
        {
            /*" -8089- DISPLAY 'R9998-00-VERIFICA-PEP' */
            _.Display($"R9998-00-VERIFICA-PEP");

            /*" -8093- MOVE '9998' TO WNR-EXEC-SQL. */
            _.Move("9998", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -8096- MOVE V0CLIE-CGCCPF TO VG131-NUM-CPF-CNPJ VG132-NUM-CPF-CNPJ */
            _.Move(V0CLIE_CGCCPF, VG131.DCLVG_PESSOA_PEPS.VG131_NUM_CPF_CNPJ, VG132.DCLVG_PESSOA_PEPS_CRUZADO.VG132_NUM_CPF_CNPJ);

            /*" -8098- MOVE 'N' TO WS-CLIENTE-PEP */
            _.Move("N", AREA_DE_WORK.WS_CLIENTE_PEP);

            /*" -8115- PERFORM R9998_00_VERIFICA_PEP_DB_SELECT_1 */

            R9998_00_VERIFICA_PEP_DB_SELECT_1();

            /*" -8120- DISPLAY 'SEL VG_PESSOA_PEPS ' VG132-NUM-CPF-CNPJ '*SQLCODE: ' SQLCODE */

            $"SEL VG_PESSOA_PEPS {VG132.DCLVG_PESSOA_PEPS_CRUZADO.VG132_NUM_CPF_CNPJ}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -8121-  EVALUATE SQLCODE  */

            /*" -8122-  WHEN ZEROS  */

            /*" -8122- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -8123- MOVE 'S' TO WS-CLIENTE-PEP */
                _.Move("S", AREA_DE_WORK.WS_CLIENTE_PEP);

                /*" -8124-  WHEN +100  */

                /*" -8124- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -8125- MOVE 'N' TO WS-CLIENTE-PEP */
                _.Move("N", AREA_DE_WORK.WS_CLIENTE_PEP);

                /*" -8126-  WHEN OTHER  */

                /*" -8126- ELSE */
            }
            else
            {


                /*" -8127- DISPLAY 'R9998-00 - PROBLEMAS NO SELECT GE_PESSOA_PEPS ' */
                _.Display($"R9998-00 - PROBLEMAS NO SELECT GE_PESSOA_PEPS ");

                /*" -8128- DISPLAY 'NUM-BILHETE     = ' V0BILH-NUMBIL */
                _.Display($"NUM-BILHETE     = {V0BILH_NUMBIL}");

                /*" -8129- DISPLAY 'NUM-CPF         = ' VG131-NUM-CPF-CNPJ */
                _.Display($"NUM-CPF         = {VG131.DCLVG_PESSOA_PEPS.VG131_NUM_CPF_CNPJ}");

                /*" -8130- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -8131- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8135-  END-EVALUATE  */

                /*" -8135- END-IF */
            }


            /*" -8136- MOVE 'N' TO WS-PEP-AVALIADO */
            _.Move("N", AREA_DE_WORK.WS_PEP_AVALIADO);

            /*" -8138- MOVE V0BILH-NUMBIL TO VG078-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -8146- PERFORM R9998_00_VERIFICA_PEP_DB_SELECT_2 */

            R9998_00_VERIFICA_PEP_DB_SELECT_2();

            /*" -8151- DISPLAY 'SEL VG_ANDAMENTO_PROP ' VG078-NUM-CERTIFICADO '*SQLCODE: ' SQLCODE */

            $"SEL VG_ANDAMENTO_PROP {VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -8152-  EVALUATE SQLCODE  */

            /*" -8153-  WHEN ZEROS  */

            /*" -8153- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -8154- CONTINUE */

                /*" -8155-  WHEN +100  */

                /*" -8155- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -8156- MOVE 'N' TO WS-PEP-AVALIADO */
                _.Move("N", AREA_DE_WORK.WS_PEP_AVALIADO);

                /*" -8157-  WHEN OTHER  */

                /*" -8157- ELSE */
            }
            else
            {


                /*" -8158- DISPLAY 'R9998-00 - PROBLEMAS NO SELECT VG_ANDAMENTO_PROP' */
                _.Display($"R9998-00 - PROBLEMAS NO SELECT VG_ANDAMENTO_PROP");

                /*" -8159- DISPLAY 'NUM-BILHETE     = ' V0BILH-NUMBIL */
                _.Display($"NUM-BILHETE     = {V0BILH_NUMBIL}");

                /*" -8160- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -8161- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8163-  END-EVALUATE  */

                /*" -8163- END-IF */
            }


            /*" -8165- . */

        }

        [StopWatch]
        /*" R9998-00-VERIFICA-PEP-DB-SELECT-1 */
        public void R9998_00_VERIFICA_PEP_DB_SELECT_1()
        {
            /*" -8115- EXEC SQL SELECT A.NUM_CPF_CNPJ INTO :VG131-NUM-CPF-CNPJ FROM SEGUROS.VG_PESSOA_PEPS A WHERE A.NUM_CPF_CNPJ = :VG131-NUM-CPF-CNPJ AND A.DTA_FIM_VIGENCIA IS NULL UNION ALL SELECT B.NUM_CPF_CNPJ INTO :VG132-NUM-CPF-CNPJ FROM SEGUROS.VG_PESSOA_PEPS B WHERE B.NUM_CPF_CNPJ = :VG132-NUM-CPF-CNPJ AND B.DTA_EXONERACAO IS NULL FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r9998_00_VERIFICA_PEP_DB_SELECT_1_Query1 = new R9998_00_VERIFICA_PEP_DB_SELECT_1_Query1()
            {
                VG131_NUM_CPF_CNPJ = VG131.DCLVG_PESSOA_PEPS.VG131_NUM_CPF_CNPJ.ToString(),
                VG132_NUM_CPF_CNPJ = VG132.DCLVG_PESSOA_PEPS_CRUZADO.VG132_NUM_CPF_CNPJ.ToString(),
            };

            var executed_1 = R9998_00_VERIFICA_PEP_DB_SELECT_1_Query1.Execute(r9998_00_VERIFICA_PEP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG131_NUM_CPF_CNPJ, VG131.DCLVG_PESSOA_PEPS.VG131_NUM_CPF_CNPJ);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_99_SAIDA*/

        [StopWatch]
        /*" R9998-00-VERIFICA-PEP-DB-SELECT-2 */
        public void R9998_00_VERIFICA_PEP_DB_SELECT_2()
        {
            /*" -8146- EXEC SQL SELECT 'S' INTO :WS-PEP-AVALIADO FROM SEGUROS.VG_ANDAMENTO_PROP WHERE NUM_CERTIFICADO = :VG078-NUM-CERTIFICADO AND DES_ANDAMENTO LIKE '%CLIENTE PEP%' FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r9998_00_VERIFICA_PEP_DB_SELECT_2_Query1 = new R9998_00_VERIFICA_PEP_DB_SELECT_2_Query1()
            {
                VG078_NUM_CERTIFICADO = VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R9998_00_VERIFICA_PEP_DB_SELECT_2_Query1.Execute(r9998_00_VERIFICA_PEP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_PEP_AVALIADO, AREA_DE_WORK.WS_PEP_AVALIADO);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -8176- DISPLAY 'R9999-00-ROT-ERRO' */
            _.Display($"R9999-00-ROT-ERRO");

            /*" -8178- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, FC0001S_LINKAGE.WABEND.WSQLCODE);

            /*" -8179- DISPLAY WABEND */
            _.Display(FC0001S_LINKAGE.WABEND);

            /*" -8181- DISPLAY SQLERRMC */
            _.Display(DB.SQLERRMC);

            /*" -8181- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -8183- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -8187- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -8187- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}