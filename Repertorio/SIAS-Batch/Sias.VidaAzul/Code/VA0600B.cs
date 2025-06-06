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
using Sias.VidaAzul.DB2.VA0600B;

namespace Code
{
    public class VA0600B
    {
        public bool IsCall { get; set; }

        public VA0600B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ................:  LER MOVIMENTO ENVIADO PELO f sivpf *      */
        /*"      *                             GERA AS TABELAS CORPORATIVAS PRODU-*      */
        /*"      *                             TOS DE FIDELIZACAO DA CAIXA SEGURO,*      */
        /*"      *                             ALEM DOS ARQUIVOS TXT:             *      */
        /*"      *                             ARQAUTO  - PROPOSTAS AUTO;         *      */
        /*"      *                             ARQRISCO - PROPOSTAS MULTIRISCO    *      */
        /*"      *                             ARQVDEMP - PROPOSTAS VIDA EMPRESA- *      */
        /*"      *                                                  RIAL SUPER .  *      */
        /*"      *                                                                *      */
        /*"      *           * * * VERSAO DO VA0600B CRIADA PARA O AIC * * *      *      */
        /*"      *                                                                *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS                        *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0600B.                           *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  27/12/1999.                        *      */
        /*"      *================================================================*      */
        /*"V.116 *  VERSAO 116 - DEMANDA 571983 / RITM0004370                     *      */
        /*"      *             - NOVOS PRODUTOS VIDA CONFORTO EM SUBSTITUICAO     *      */
        /*"      *               AOS PRODUTOS CONTIDOS NA APOLICE 97010000889.    *      */
        /*"      *                                                                *      */
        /*"      *             - OS SEGURADOS DO MULTIPREMIADO SERAO MIGRADOS     *      */
        /*"      *               PARA APOLICE ABAIXO POR JAH TEREM                *      */
        /*"      *               REENQUADRAMENTO POR FAIXA ETARIA.                *      */
        /*"      *                                                                *      */
        /*"      *               APOLICE       SG  PRD DESCRICAO                  *      */
        /*"      *               3009300007815  1 9320 MULTIPREMIADO ME C/CONJ    *      */
        /*"      *               3009300007815  2 9320 MULTIPREMIADO ME S/CONJ    *      */
        /*"      *                                                                *      */
        /*"      *             - SERAO MIGRADOS PARA AS NOVAS APOLICES OS         *      */
        /*"      *               PRODUTOS VIDAZUL:                                *      */
        /*"      *                                                                *      */
        /*"      *                      - TRADICIONAL;                            *      */
        /*"      *                      - MASTER;                                 *      */
        /*"      *                      - PREMIADO; E                             *      */
        /*"      *                      - EXECUTIVO.                              *      */
        /*"      *                                                                *      */
        /*"      *             - O VIDAZUL SENIOR NAO SERAH MIGRADO EM FUNCAO     *      */
        /*"      *               DOS SEGURADOS ESTAREM TODOS COM IDADE ACIMA DE   *      */
        /*"      *               80 ANOS QUANDO DO CANCELAMENTO DA APOLICE        *      */
        /*"      *               QUE SERAH FEITO EM AGOSTO DE 2024.               *      */
        /*"      *                                                                *      */
        /*"      *               APOLICE       SG  PRD DESCRICAO                  *      */
        /*"      *               3009300007651  1 9753 VIDA CONFORTO ME S/CONJ    *      */
        /*"      *               3009300007651  2 9753 VIDA CONFORTO ME C/CONJ    *      */
        /*"      *               3009300007652  1 9754 VIDA CONFORTO AN S/CONJ    *      */
        /*"      *               3009300007652  2 9754 VIDA CONFORTO AN C/CONJ    *      */
        /*"      *                                                                *      */
        /*"      *  EM 08/10/2024 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.116       *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.115 *  VERSAO 115 - INCIDENTE 602385                                 *      */
        /*"      *               ACEITAR -811 NO ACESSO A PESSOA-TELEFONE         *      */
        /*"      *                                                                *      */
        /*"      *  EM 13/09/2024 - canetta             PROCURE POR V.115         *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.114 *  VERSAO 114 - DEMANDA 577291 - TRATAMENTO DO NOME SOCIAL       *      */
        /*"      *                                                                *      */
        /*"      *  EM 10/04/2024 - ROGER PIRES DOS SANTOS      PROCURE POR V.114 *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.113 *  VERSAO 113 - INCIDENTE 484074                                 *      */
        /*"      *               INCLUSAO DOS PRODUTOS SEGURO PROTECAO EXECUTIVA  *      */
        /*"      *                                                                *      */
        /*"      *  EM 26/09/2023 - TERCIO CARVALHO     PROCURE POR V.113         *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.112 *  VERSAO 112 - INCIDENTE 529030                                 *      */
        /*"      *               erro calculo idade                               *      */
        /*"      *                                                                *      */
        /*"      *  EM 08/09/2023 - CANETTA             PROCURE POR V.112         *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.111 *  VERSAO 111 - INCIDENTE 516797                                 *      */
        /*"      *               ACESSO A VA_VGAP COM DATA DA PROPOSTA E QUITACAO *      */
        /*"      *                                                                *      */
        /*"      *  EM 25/07/2023 - CANETTA             PROCURE POR V.111         *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.110 *  VERSAO 110 - DEMANDA 470437 - NOVO PORTAL DE VENDAS           *      */
        /*"      *               CORRECAO DE CONSISTENCIAS MATRIZ                 *      */
        /*"      *               CORRECAO DE CONSISTENCIAS PESSOA_FISICA          *      */
        /*"      *               CORRECAO DE CPO RH-AGE-GERADORA                  *      */
        /*"      *               CORRECAO NOME EM BRANCO SEGUROS.PESSOA           *      */
        /*"      *                                                                *      */
        /*"      *  EM 03/05/2023 - CANETTA             PROCURE POR V.110         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.109 *  VERSAO 109 - DEMANDA 470437 - Novo portal de vendas           *      */
        /*"      *                                                                *      */
        /*"      *  EM 11/03/2023 - CANETTA             PROCURE POR V.109         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 108 - ABEND 449744                                    *      */
        /*"      *              - VALIDAR PLANO COMERCIALIZADO PELO AIC E NAO     *      */
        /*"      *                INTERROMPER A EXECUCAO DO PROGRAMA.             *      */
        /*"      *              - ARQUIVO RVA0600B SERA ENVIADO A GEFEA PARA CON- *      */
        /*"      *                DAS PROPOSTAS RECUSADAS NO PROGRAMA.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/12/2022 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.108        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 107 - ABEND 445797                                    *      */
        /*"      *              - IGNORAR PROPOSTA COM ERRO DE SUBSCRICAO DINAMICA*      */
        /*"      *   DEVIDO A UMA FALHA NO AIC.                                   *      */
        /*"      *              - REMOVIDO NA V.108.                                     */
        /*"      *                                                                *      */
        /*"      *   EM 22/11/2022 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.107        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.106 *  VERSAO 106 - PLD Circular 612 - Fase 2 -  Demanda 379166      *      */
        /*"      *             - INCLUIDO ROTINA SPBVG009 PARA CONSULTA DO RISCO  *      */
        /*"      *               DA PROPOSTA GERADA PELO MOTOR ANTES DA EMISSAO   *      */
        /*"      *             - MARCA SITUACAO PENDENTE DE CLASSIFICACAO DE RISCO*      */
        /*"      *               NA TABELA SEGUROS.PROPOSTA_FIDELIZ PARA POSTERIOR*      */
        /*"      *               RECLASSIFICACAO PELO VA0603B APOS CHEGADA DE     *      */
        /*"      *               ARQUIVO COM CLASSIFICACAO DE RISCO, CASO NAO SEJA*      */
        /*"      *               ENCONTRADO NA CONSULTA DO SPBVG009               *      */
        /*"      *                                                                *      */
        /*"      *  EM 11/10/2022 - ELIERMES OLIVEIRA   PROCURE POR V.106         *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.105 *  VERSAO 105 - DEMANDA 400813 - REFORMULACAO DAS ASSISTENCIAS   *      */
        /*"      *                                                                *      */
        /*"      *  EM 25/08/2022 - CANETTA             PROCURE POR V.105         *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.104 *  VERSAO 104 - INCIDENTE 386.755                                *      */
        /*"      *             - ALTERAR A APOLICE PADRAO DO EMPRESARIAL GLOBAL.  *      */
        /*"      *                                                                *      */
        /*"      *  EM 03/05/2022 - FRANK CARVALHO      PROCURE POR V.104         *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.103 *  VERSAO 103 - CIRCULAR 612/2020 - PLDFT -  DEMANDA 294878      *      */
        /*"      *             - TRATA REGISTRO TIPO D - INFO ADICIONAIS TERCEIROS*      */
        /*"      *                                                                *      */
        /*"      *  EM 25/03/2022 - ELIERMES OLIVEIRA   PROCURE POR V.103         *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"V.102 *   VERSAO 102- DEMANDA 330476                                   *      */
        /*"      *             - IMPLANTACAO MATRIZ DE DESCONTOS E AGRAVOS POR    *      */
        /*"      *               PROFISSAO.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/02/2022 - CANETTA             PROCURE POR V.102        *      */
        /*"      *                                                                *      */
        /*"      *================================================================*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 101- DEMANDA 327.863                                  *      */
        /*"      *             - TODO SEGURO PESSOA FISICA COM PERIODICIDADE DE   *      */
        /*"      *               PAGAMENTO ANUAL (12 MESES) DEVERAO ENTRAR NO SIAS*      */
        /*"      *               COM A MARCACAO DE ANTECIPADO. NAO HA MAIS VENDAS *      */
        /*"      *               DE PRODUTOS ANUAIS, APENAS SE O CLIENTE SOLICITAR*      */
        /*"      *               ATRAVES DA CENTRAL PERMANECERAO COMO ANUAL.      *      */
        /*"      *             - SOLICITA ATRAVES DA VLNXA E SPBSC056.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2022 - FRANK CARVALHO      PROCURE POR V.101        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.100 *VERSAO V.100-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 99 - PROJETO AUTO COMPRA - DEMANDA 244.137            *      */
        /*"      *             - PREPARA A ORIGEM 09 PARA VENDAS DA INTERNET(LOJA)*      */
        /*"      *               PARA DIFERENCIAR AS VENDAS REALIZADAS NO IBC     *      */
        /*"      *               ORIGEM 1010.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/10/2020 - FRANK CARVALHO      PROCURE POR V.99         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV198 *VERSAO 98: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV198 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV198 *           - PROCURAR POR JV198                                 *      */
        /*"JV198 *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 97 - RETIRADA DO PROCEDIMENTO EMERGENCIAL/TEMPORARIO  *      */
        /*"      *         OBS - EMERGENCIAL/TEMPORARIA - DEMANDA 228539          *      */
        /*"      *               DEVIDO AO PROBLEMA NO R3-INDIC-TIPO-PROPOSTA     *      */
        /*"      *                ORIGINADO DO AIC/SIGPF EM BRANCO PARA PARCERIAS *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/08/2020 - CANETTA             PROCURE POR V.97         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  VERSAO 96 - INCIDENTE 251.599                                 *      */
        /*"      *            - CORRIGIR ABEND 0C7 CAUSADO PELOS CAMPOS           *      */
        /*"      *              PRODUVG-NUM-APOLICE / PRODUVG-COD-SUBGRUPO.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/07/2020 - CANETTA E FRANK     PROCURE POR V.96         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  VERSAO 95 - DEMANDA 176.725                                   *      */
        /*"      *            - REALIZAR OS AJUSTES DE SUBSCRICAO DINAMINCA       *      */
        /*"      *              E VOLTAR A VERSAO 86.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/04/2020 - JOAO ARAUJO         PROCURE POR V.95         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 94 - EMERGENCIAL/TEMPORARIA - DEMANDA 228539          *      */
        /*"      *             - DEVIDO AO PROBLEMA NO R3-INDIC-TIPO-PROPOSTA     *      */
        /*"      *                ORIGINADO DO AIC/SIGPF EM BRANCO PARA PARCERIAS *      */
        /*"      *             - DEVERA SER RETIRADO APOS CORRECAO                *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/05/2020 - CANETTA             PROCURE POR V.94         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 93 - INCIDENTE 242.185 - ABEND 182467                 *      */
        /*"      *             - REALIZAR A BUSCA DO PLANO CALCULANDO A IDADE DO  *      */
        /*"      *               CLIENTE A PARTIR DA DATA DA PROPOSTA. POIS, HA   *      */
        /*"      *               CASOS DO CLIENTE COMPRAR O SEGURO PROXIMO DO     *      */
        /*"      *               ANIVERSARIO E AO QUITAR A PROPOSTA JA COMPLETOU  *      */
        /*"      *               A NOVA IDADE, GERANDO DIFERENCA DE VALOR NO PLANO*      */
        /*"      *             - REGRA VALIDADA COM A BU ATRAVES DA ADRIELLE             */
        /*"      *                                                                *      */
        /*"      *   EM 24/04/2020 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.93         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 92 - DEMANDA 228539                                   *      */
        /*"      *               PRODUTOS DE ORIGEM-PROPOSTA DE PARCEIROS         *      */
        /*"      *             - ACEITAR NOVO TIPO DE INDIC-TIPO-PROPOSTA (V)     *      */
        /*"      *               VOCAL PARA CANAL DE VENDA:                       *      */
        /*"      *               1021 AIC PARCEIROS - ALGAR                       *      */
        /*"      *               1022 AIC PARCEIROS - WIZ                         *      */
        /*"      *               1023 AIC PARCEIROS - ALMA VIVA                   *      */
        /*"      *               1024 AIC PARCEIROS - AEC                         *      */
        /*"      *               1025 AIC PARCEIROS - SERCOM                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/04/2020 - CANETTA                                      *      */
        /*"      *                                       PROCURE POR V.92         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 91 - PROJETO AUTO COMPRA VIDA - DEMANDA 244.137       *      */
        /*"      *             - PERMITIR A EMISSAO DE SEGUROS COMERCIALIZADOS EM *      */
        /*"      *               UMA NOVA ORIGEM E FAZER COM QUE O SIAS REALIZE A *      */
        /*"      *               COBRANCA DA PARCELA DE ADESAO DESTAS VENDAS.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/04/2020 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.91         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 90 - DEMANDA 200.141                                  *      */
        /*"      *             - IMPLEMENTACAO DA PARAMETRIZACAO NO PARCEIRO      *      */
        /*"      *            (PRODUTO VIDA DA GENTE, VIDA MULHER E MULTIPREMIADO)*      */
        /*"      *                                                                *      */
        /*"      *   OBS. FORAM RETIRADAS AS CRITICAS DE 'PRPVIGEN' DA VERSAO V.77*      */
        /*"      *                                                                *      */
        /*"      *   EM 23/07/2019 - JOAO ARAUJO                                  *      */
        /*"      *                                       PROCURE POR V.90         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 89 - DEMANDA 174.877.                                 *      */
        /*"      *               GRAVAR O REGISTRO TIPO 'C' NA TABELA             *      */
        /*"      *               PROP_FIDELIZ_COMP COM IND_TP_INFORMACAO = '3'    *      */
        /*"      *               PARA OS PRODUTOS VIDA-MULHER E PREMIADO          *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/07/2019 - KINKAS              PROCURE POR V.89         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 88 - PROJETO - PROJETO CARTAO DE CREDITO CIELO        *      */
        /*"      *             - REALIZAR A EMISSAO DE SEGUROS COMERCIALIZADOS COM*      */
        /*"      *             - A OPCAO DE PAGAMENTO CARTAO DE CREDITO PARA      *      */
        /*"      *             - ADESAO E DEMAIS PARCELAS.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/05/2019 - DANIEL MEDINA                                *      */
        /*"      *                                       PROCURE POR V.88         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 87 - ABEND 174601                                     *      */
        /*"      *             - INCLUIR O TERMO ACEITARCOMRESTRICOES PARA QUE O  *      */
        /*"      *               PROGRAMA NAO ABENDE QUANDO HOUVER ENVIO DESSA    *      */
        /*"      *               INFORMACAO PELO AIC.                             *      */
        /*"      *                                                                *      */
        /*"      *             - VALIDAR A FALTA DE RETORNO DO VALOR PAGO SICOB   *      */
        /*"      *               PRINCIPALMENTE PARA OS CASOS EM QUE O AIC NOS EN-*      */
        /*"      *               VIA OS ARQUIVOS SEM ESSA INFORMACAO.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/05/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.87         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 86 - DEMANDA 176.725                                  *      */
        /*"      *             - VENDA DO VIDA EXCLUSIVO NO BALCAO.               *      */
        /*"      *               COMENTEI OS AJUSTES PORQUE ENVIARAM ALGUMAS PROP.*      */
        /*"      *               EM PRODUCAO E ELAS CAIRAM NO FLUXO ERRADO (ESTA- *      */
        /*"      *               VAM SENDO EXECUTADAS PELO PF0602B). TEM QUE VER  *      */
        /*"      *               O PORQUE.                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/08/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.86         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 85 - DEMANDA 175.167                                  *      */
        /*"      *             - OPERACAO CONTA SALARIO                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/02/2019 - MARCUS VALERIO                               *      */
        /*"      *                                       PROCURE POR V.85         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 84 - ABEND 171917 (VERSAO COMENTADA DIA 25/06/2019)   *      */
        /*"      *             - IGNORAR PROPOSTAS COM ERRO DE SUBSCRICAO DINAMICA*      */
        /*"      *   DEVIDO A UMA FALHA NO AIC.                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/01/2019 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.84         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO JV1- PROJETO JV1                                      *      */
        /*"      *             - ALTERACOES NECESSARIAS PARA ATENDER A NECESSIDADE*      */
        /*"      *   DO PROJETO JV1.                                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - JOAO ARAUJO                                  *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 83 - HISTORIA 173.146                                 *      */
        /*"      *             - IMPLEMENTAR A CONSULTA AO PLANO ATRAVES DO CAMPO *      */
        /*"      *  COM O PREMIO ORIGINAL ENVIADO PELO AIC NO REGISTRO DO TIPO 'B'*      */
        /*"      *                                                                *      */
        /*"      *   EM 08/11/2018 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.83         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 82 - ABEND 171610                                     *      */
        /*"      *             - IGNORAR REGISTROS QUE ESTAO VINDO COM A PERIODIC.*      */
        /*"      *  DE PAGAMENTO ZERADA DO AIC. ESSE AJUSTE SERA RETIRADO.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/01/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.82         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 81 - HISTORIA 39.875                                  *      */
        /*"      *             - IMPLEMENTAR NOVA REGRA DE SUBSCRIACAO DINAMICA.  *      */
        /*"      *  O AIC CONSULTA A DIRETRIX.ON NO MOMENTO DA VENDA E NOS ENVIA  *      */
        /*"      *  O RISCO DE ACEITACAO DO SEGURO E SE HOUVE AGRAVAMENTO NO      *      */
        /*"      *  VALOR DO PREMIO.                                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/07/2018 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.81         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 80 - CAD 156.786 E CAD 157.494                        *      */
        /*"      *             - DEMANDA SOLICITA QUE VENDA NO CANAL (2) AIC-PAR- *      */
        /*"      *  CEIROS SEJA RECEPCIONADA PELO ARQUIVO DO SIGPF(MJUNMOV/ARQ-VG)*      */
        /*"      *   - ORIGEM DA PROPOSTA = 10 (INDICA AIC-PARCEIROS)             *      */
        /*"      *   - FOI CRIADO O CAMPO ORIG-PARCEIROS NO REGISTRO TIPO "B". O  *      */
        /*"      *  CAMPO SERA UTILIZADO PARA IDENTIFICAR UMA VENDA COM CAMPANHA  *      */
        /*"      *  OU SEM CAMPANHA. ESTE VALOR IRA SUBSTITUIR O VALOR DO CAMPO   *      */
        /*"      *  ORIGEM DA PROPOSTA QUANDO COMERCIALIZADAS PELO CANAL DE VENDA *      */
        /*"      *  (2).                                                          *      */
        /*"      *     - ORIG-PARCEIROS =   23 - PV'S COM VENDA SEM CAMPANHA      *      */
        /*"      *     - ORIG-PARCEIROS = 1018 - PV'S COM VENDA SO DA CAMPANHA    *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/01/2018 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.80         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 79 - CAD 154835 - ABEND                               *      */
        /*"      *             - VERIFICAR SE O VALOR NAO ESTA ZERADO ANTES DE    *      */
        /*"      *               MOVER PARA O VALOR PAGO.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/10/2017 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.79    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 78 - CAD 154492 - ABEND                               *      */
        /*"      *             - ALTERAR A BUSCA DE PLANOS PARA O CANAL 3         *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/09/2017 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.78    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 77 - CAD 153.596                                      *      */
        /*"      *             - IMPLANTACAO DO NOVO CANAL DE AIC PARCEIROS.      *      */
        /*"      *             - OS PRODUTOS VIDA DA GENTE, VIDA MULHER E         *      */
        /*"      *               MULTIPREMIADO SUPER SERAO COMERCIALIZADOS NESSE  *      */
        /*"      *               CANAL DE VENDA (2) E FARAO PARTE DA CAMPANHA DE  *      */
        /*"      *               ISENCAO DE CARENCIA.                             *      */
        /*"      *             - FOI CRIADO PARAMETRO DE INICIO E FIM DE VIGENCIA *      */
        /*"      *               DESSA CAMPANHA.(VIDE VA0601B)                    *      */
        /*"      *             - HAVERA PV'S QUE COMERCIALIZARAO SO CAMPANHA E    *      */
        /*"      *               OUTROS SEM CAMPANHA. PARA ISSO HAVERA ORIGENS DE *      */
        /*"      *               PROPOSTAS DISTINTAS:                             *      */
        /*"      *                 ORIGEM   23 - PV'S COM VENDA SEM CAMPANHA      *      */
        /*"      *                 ORIGEM 1018 - PV'S COM VENDA SO DA CAMPANHA    *      */
        /*"      *             - TODAS AS REGRAS DE NEGOCIO IMPLANTADAS PARA O    *      */
        /*"      *               CADMUS 152.055 SAO VALIDAS PARA O 153.596.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/09/2017 - MAURO ROCHA DA CRUZ                          *      */
        /*"      *                                       PROCURE POR V.77         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 76 - CAD 149.441                                      *      */
        /*"      *             - INCLUIR NOVOS INDICADORES DE TIPO PROPOSTA.      *      */
        /*"      *               'D' - PROPOSTA ASSINADAS DIGITALMENTE            *      */
        /*"      *               'E' - PROPOSTA ASSINADAS DIGITALMENTE POR E-MAIL *      */
        /*"      *               'S' - PROPOSTA ASSINADAS DIGITALMENTE POR SMS    *      */
        /*"      *               'NULO' - PROPOSTA ASSINADAS MANUALMENTE          *      */
        /*"      *   EM 30/03/2017 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.76    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 75 - ABEND                                            *      */
        /*"      *             - TRATAR ABEND                                     *      */
        /*"      *               PROBLEMA UPDATE PESSOA-FISICA                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2017 - THIAGO BLAIER                                *      */
        /*"      *                                            PROCURE POR V.75    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 74 - CAD 145.153                                      *      */
        /*"      *             - PROPOSTAS COM ASSINATURA DIGITAL PRECISAM SER    *      */
        /*"      *               ATUALIZADOS OS DADOS QUE ESTAO NA PROPOSTA SEM   *      */
        /*"      *               APROVEITAMENTO DE INFORMACOES DA TABELA          *      */
        /*"      *   EM 06/10/2016 - THIAGO BLAIER                                *      */
        /*"      *                                            PROCURE POR V.74    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 73 - CAD 140.553                                      *      */
        /*"      *             - ARMANEZAR INFORMACAO DO TIPO DE COMERCIALIZACAO  *      */
        /*"      *               DA PROPOSTA, SE FOI VIA IMPRESSAO/ASSINATURA     *      */
        /*"      *               MANUAL VIRA 'NULO' OU SE FOI ASSINATURA DIGITAL  *      */
        /*"      *               OU TOKEN VIRA PREENCHIDO COM 'D' NO NOVO CAMPO   *      */
        /*"      *               INDIC-TIPO-PROPOSTA E ARMAZENADO NA TABELA       *      */
        /*"      *               PROPOSTA_FIDELIZ NO CAMPO IND_TP_PROPOSTA.       *      */
        /*"      *   EM 06/10/2016 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.73    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 72   CAD 140.623                                      *      */
        /*"      *                                                                *      */
        /*"      *       - RETIRADA DA ATUALIZACAO DA TABELA PROPOSTAS_FIDELIZ    *      */
        /*"      *         NAO ALTERAR A AGENCIA QUE CHEGA NO ARQUIVO DO RCAP,    *      */
        /*"      *         MANTER A AGENCIA ATUAL.                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/09/2016 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.72         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 71 - CAD 135713                                       *      */
        /*"      *             - TRATAR PROFISSAO QUANDO O PRODUTO SIGPF CHEGAR   *      */
        /*"      *               93 NA PROPOSTA.                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/05/2016 - THIAGO BLAIER                                *      */
        /*"      *                                            PROCURE POR V.71    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 70 - CAD 134769 - ABEND                               *      */
        /*"      *             - TRATAR BUSCA DE PLANOS QUANDO A IDADE DO CLIENTE *      */
        /*"      *               JA ALTERADA ANTES DA QUITACAO.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/04/2016 - CLAUDETE RADEL                               *      */
        /*"      *                                            PROCURE POR V.70    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 69 - CAD 129048                                       *      */
        /*"      *             - TRATAR COD-CBO QUANDO REGISTRO R1 FOR 999 OU 0,  *      */
        /*"      *               CONSIDERANDO COD-CBO DO REGISTRO TIPO 'B'        *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/02/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.69    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 68 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.68         *      */
        /*"      *  - RECOMPILACAO DE BOOKS                                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 67 - CAD 102399                                       *      */
        /*"      *                                                                *      */
        /*"      *             - TRATAMENTO REGISTRO 'C' ( SICAQWEB-CCA )         *      */
        /*"      *                                                                *      */
        /*"      *             - EM 05/11/2014 -  BRICE HO                        *      */
        /*"      *                                            PROCURE POR V.67    *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      *   VERSAO 66 - CAD 104470                                       *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTE NO PROGRAMA PARA TRATAR AS NOVAS APOLICES *      */
        /*"      *               VIDA DA GENTE 109300001679 E 109300001680        *      */
        /*"      *                                                                *      */
        /*"      *             - EM 13/10/2014 -  THIAGO BLAIER - MAURO ROCHA     *      */
        /*"      *                                            PROCURE POR V.66    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 65 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.65    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 64 - CAD 40.852 E 83.216                              *      */
        /*"      *                                                                *      */
        /*"      *          EMPRESARIAL COM OPCPAG CARTAO DE CREDITO              *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/08/2013 - BRICE HO                                     *      */
        /*"      *                                   PROCURE POR V.64             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 63 - CAD  86.103                                      *      */
        /*"      *                                                                *      */
        /*"      *   TROCA DE APOLICES/SUBGRUPOS (MENSAL)                         *      */
        /*"      *                                                                *      */
        /*"      *   DE: 109300002001/01 P/: 109300002002/03 MULTIPR SUPER C/C    *      */
        /*"      *   DE: 109300002001/02 P/: 109300002002/04 MULTIPR SUPER S/C    *      */
        /*"      *                                                                *      */
        /*"      *   DE: 109300001966/01 P/: 109300001970/03 MULTIPR TOTAL C/C    *      */
        /*"      *   DE: 109300001966/02 P/: 109300001970/04 MULTIPR TOTAL S/C    *      */
        /*"      *                                                                *      */
        /*"      *   DE: 109300002004/01 P/: 109300002005/03 VIDA MULHER <30M C/C *      */
        /*"      *   DE: 109300002004/02 P/: 109300002005/04 VIDA MULHER <30M S/C *      */
        /*"      *                                                                *      */
        /*"      *   DE: 109300002007/01 P/: 109300002008/03 VIDA MULHER >30M C/C *      */
        /*"      *   DE: 109300002007/02 P/: 109300002008/04 VIDA MULHER >30M S/C *      */
        /*"      *                                                                *      */
        /*"      *   DE: 109300001976/01 P/: 109300001977/03 VIDA MULHER TOT  C/C *      */
        /*"      *   DE: 109300001976/02 P/: 109300001977/04 VIDA MULHER TOT  S/C *      */
        /*"      *                                                                *      */
        /*"      *   DE: 109300002357/01 P/: 109300002344/02 VIDA DA GENTE        *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/08/2013 - BRICE HO                                     *      */
        /*"      *                                   PROCURE POR V.63             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 62 - CAD  82.716                                      *      */
        /*"      *                                                                *      */
        /*"      *          MELHORIAS MSG ABEND DA R7500-00-SELECT-APOL-PRM-PLANO *      */
        /*"      *          GARANTIR QUE O AJUSTE NAO SEJA EFETUADO NAS PROPOSTAS *      */
        /*"      *          MANUAIS.                                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/05/2013 - BRICE HO                                     *      */
        /*"      *                                   PROCURE POR V.62             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 61 - CAD  81.121                                      *      */
        /*"      *                                                                *      */
        /*"      *               AJUSTE PARA ENQUADRAR PROPOSTAS VIDA DA GENTE DO *      */
        /*"      *               AIC QUE ESTEJAM SENDO ENVIADOS COM VALOR PAGO    *      */
        /*"      *               DIFERENTE DO PREMIO E DATA QUITACAO DIFERENTE    *      */
        /*"      *               DA DATA DA PROPOSTA.                             *      */
        /*"      *               ABENDAR SE NAO CONSEGUIR ENQUADRAR.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/04/2013 - BRICE HO                                     *      */
        /*"      *                                   PROCURE POR V.61             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 60 - CAD  79.205                                      *      */
        /*"      *                                                                *      */
        /*"      *               AJUSTE PARA ENQUADRAR PROPOSTA MANUAL DO AIC E   *      */
        /*"      *               CERAT.                                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/02/2013 - MAURO  ROCHA                                 *      */
        /*"      *                   TERCIO FREITAS(FAST COMPUTER)                *      */
        /*"      *                                   PROCURE POR V.60             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 59 - CAD  76.510                                      *      */
        /*"      *               PASSA A TRATAR A NOVA TABELA DE PLANOS E NOVAS   *      */
        /*"      *               APOLICES DO VIDA DA GENTE.                       *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO      AJUSTE PARA ENQUADRAR PROPOSTA MANUAL DO AIC E   *      */
        /*"      *               CERAT .                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/01/2013 - LUIZ MARQUES (FAST COMPUTER)                 *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.59             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 58 - CAD  76.727                                      *      */
        /*"      *               AJUSTE NA AGENCIA DE COBRANCA PARA PAGAMENTO     *      */
        /*"      *               A VISTA NO CANAL DE VENDAS GITEL / CERAT         *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/11/2012 - PEDRO SILVERIO (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.58             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 57 - CAD  76.831                                      *      */
        /*"      *               PASSA A TRATAR O REGISTRO TIPO 'A' - FINANCEIRO  *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/11/2012 - PEDRO SILVERIO (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.57             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 56 - CAD  67.646                                      *      */
        /*"      *               AJUSTE NO PROGRAMA PARA TRATAR AS NOVAS APOLICES *      */
        /*"      *               PARA OS PRODUTOS VIDA MULHER E MULTIPREMIADO     *      */
        /*"      *               SUPER DA NOVA LINHA.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/04/2012 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.56             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 55 - PROJETO AIC CADMUS 65.013                        *      */
        /*"      *               TRATAMENTO DE NULIDADE CAMPO DATA EXPEDICAO      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/12/2011 - MARCUS ANDRE DIAS        PROCURE POR V.55    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 54 - CAD 201.040                                      *      */
        /*"      *               AJUSTE NO PROGRAMA PARA TRATAR AS NOVAS APOLICES *      */
        /*"      *               VIDA DA GENTE 109300001679 E 109300001680 E NAO  *      */
        /*"      *               CRITICAR DPS.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/04/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.54             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 53 - CAD 52.945                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE NO PERIODO DE PAGAMENTO AO INSERIR NA    *      */
        /*"      *                TABELA SEGUROS.OPCAO_PAG_VIDAZUL.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/02/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.53             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 52 - CAD 40.447                                       *      */
        /*"      *                                                                *      */
        /*"      *              - TRATAMENTO DO -803 NO INSERT DA TABELA          *      */
        /*"      *                SEGUROS.PF_CBO.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/04/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.52             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 51 - CAD 32.475/38.104                                *      */
        /*"      *                                                                *      */
        /*"      *              - ALTERACAO PARA PROCESSAR AS INFORMACOES         *      */
        /*"      *                PROVENIENTES DO SISTEMA AIC.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/12/2009 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.51             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 50 - CAD 34.386/37.242                                *      */
        /*"      *               ADEQUACAO PARA QUE OS PRODUTOS VIDA DA GENTE,    *      */
        /*"      *               VIDA   MULHER   E   MULTIPREMIADO   SUPER, DE    *      */
        /*"      *               PERIODICIDADE ANUAL, POSSAM PASSAR PARA MENSAL   *      */
        /*"      *               APOS 12 MESES.                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2010 - EDIVALDO GOMES   (FAST COMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.50             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 49 - CAD 33.381                                       *      */
        /*"      *               CORRECAO NO LOOPING OCORRIDO EM FUNCAO DO ESTOURO*      */
        /*"      *               DA TABELA INTERNA QUE GUARDA ENDERECOS.          *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/11/2009 - MARCO PAIVA  (FAST COMPUTER)                 *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.49             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 48 - CAD 31.879                                       *      */
        /*"      *               CORRECAO DO ABEND OCORRIDO NA INCLUSAO NA TABELA *      */
        /*"      *               SEGUROS.CONVERSAO_SICOB DANDO SQLCODE = -180.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/10/2009 - MARCO PAIVA  (FAST COMPUTER)                 *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.48             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 47 - CAD 27.301                                       *      */
        /*"      *               VERSAO CRIADA A PARTIR DO PROGRAMA PF0600B PARA  *      */
        /*"      *               SEPARACAO DAS ROTINAS MINIMIZANDO A DEPENDENCIA  *      */
        /*"      *               DA ROTINA JPFD00.                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/08/2009 - FAST COMPUTER            PROCURE POR V.47    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 46 - CAD 24.543                                       *      */
        /*"      *               TRATA APOLICE 107700000013, PRODUTO 7707         *      */
        /*"      *               - PRESTAMISTA GITEL - SEM PLANO                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/06/2009 - FAST COMPUTER            PROCURE POR V.46    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 45 - CAD 24.245                                       *      */
        /*"      *               TRATAMENTO DE CODIGO DE RETORNO -803             *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/05/2009 - FAST COMPUTER            PROCURE POR V.45    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 44 - CAD 24.545                                       *      */
        /*"      *               TRATAMENTO DO PRESTAMISTA 7707 - GITEL           *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/05/2009 - TERCIO   (FAST)          PROCURE POR V.44    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 43 - CAD 22.910                                       *      */
        /*"      *               PROCEDE AJUSTES PARA O PRESTAMISTA CONSIGNACAO   *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/04/2009 - TERCIO   (FAST)          PROCURE POR V.43    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 42 - CAD 18.704/2008, 19.507/2009, 20.967/2009        *      */
        /*"      *               IMPLEMENTA NOVA TABELA DE PREMIOS                *      */
        /*"      *               PARA OS PRODUTOS VIDA.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/03/2009 - EDIVALDO (FAST)          PROCURE POR V.42    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 41 - CAD 19.395/2009                                  *      */
        /*"      *               ENQUADRAMENTO DAS APOLICES PU                    *      */
        /*"      *               POR ESTAREM COM OS SUBGRUPOS INVERTIDOS          *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/01/2009 - EDIVALDO (FAST)          PROCURE POR V.41    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 40 - CAD 11.248/2008                                  *      */
        /*"      *               VENDA DE BILHETE RD VIA CARTAO                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/01/2009 - WANGER (GEFAB)           PROCURE POR V.40    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39                                                    *      */
        /*"      *             - SSI 24.168    CORRECAO ABAND CADMUS 19010        *      */
        /*"      *               GRAVA ERROPF PARA GRAU DE PARENTESCO INVALIDO    *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/12/2008 - LUCIA VIEIRA             PROCURE POR V.39    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 38                                                    *      */
        /*"      *             - CAD 13.762                                       *      */
        /*"      *               REVISAO DO PRODUTOS DE PAGAMENTO UNICO           *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2008 - FAST COMPUTER            PROCURE POR V.38    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 37                                                    *      */
        /*"      *             - CAD 09.373                                       *      */
        /*"      *               DISPENSA DE DPS PARA VIDA SENIOR                 *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 10.010                                       *      */
        /*"      *               DISPENSA DE DPS PARA VIDA MULHER                 *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 10.559                                       *      */
        /*"      *               PAGAMENTO UNICO COM VIGENCIA DE 36 MESES PARA    *      */
        /*"      *               OS PRODUTOS:                                     *      */
        /*"      *                  . 9333 - VIDA DA GENTE       - 109300001391   *      */
        /*"      *                  . 9334 - VIDA MULHER <=30000 - 109300001392   *      */
        /*"      *                  . 9334 - VIDA MULHER         - 109300001393   *      */
        /*"      *                  . 9332 - MULTIPREMIADO SUPER - 109300001394   *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 11.105                                       *      */
        /*"      *               MUDANCA DE LIMITE DE LIBERACAO AUTOMATICA DE     *      */
        /*"      *               R$30.000,00 PARA R$200.000,00                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/05/2008 - FAST COMPUTER            PROCURE POR V.37    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 36 - SSI 20430                                        *      */
        /*"      *               CORRIGE ABEND -803 NA TAB PESSOA_ENDERECO        *      */
        /*"      *               PARAGRAFO: R0620-INCLUIR-NOVO-ENDERECO           *      */
        /*"      *   EM 22/04/2008 - LUCIA VIEIRA             PROCURE POR V.36    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 35 - ESPECIFICACOES 036, 039 E 040 DE 2007.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/04/2008 - MAURICIO LINKE           PROCURE POR V.35    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 34 - SSI ESP004/2008                                  *      */
        /*"      *               TRATA O PRODUTO 77 PRESTAMISTA CONSIGNACAO       *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/02/2008 - FAST COMPUTER            PROCURE POR V.34    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 33 - SSI S/N   2008                                   *      */
        /*"      *               TRATA NOVA APOLICE VIDA DA GENTE                 *      */
        /*"      *               SOMENTE PARA PROPOSTA DE VIDA                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/02/2008 - FAST COMPUTER            PROCURE POR V.33    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 32 - SSI 20350/2008                                   *      */
        /*"      *               PASSA A EXECUTAR R0860-TRATA-INC-CARTAO          *      */
        /*"      *               SOMENTE PARA PROPOSTA DE VIDA                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/02/2008 - LUCIA VIEIRA             PROCURE POR V.32    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 31 - SSI 17.210/2007                                  *      */
        /*"      *               PASSA A TRABALHAR COM CANAL DE VENDA ATM         *      */
        /*"      *               E BILHETES COM 60 PARCELAS ORIUNDOS DAS VENDAS   *      */
        /*"      *               PELA MARSH.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/01/2008 - FAST COMPUTER            PROCURE POR V.31    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SSI 19.947- REFORMULACAO VIDA DA GENTE                       *      */
        /*"      *               ATENDENDO SSI 19.947 - PROCESSO A SER RETIRADO   *      */
        /*"      *               APOS LIBERACAO PELO USUARIO.                     *      */
        /*"      *   EM 02/01/2008 -         LUIZ CARLOS      PROCURE POR 19947   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 30 - REFORMULACAO VIDA DA GENTE                       *      */
        /*"      *               ATENDENDO SSI 19.656                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/12/2007 - LUCIA / LUIZ CARLOS      PROCURE POR V.30    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 29 - PASSA A TRATAR PRODUTO-SIVPF = 77 PRESTAMISTA    *      */
        /*"      *               ATENDENDO SSI 19891.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/12/2007 - LUCIA / LUIZ CARLOS      PROCURE POR V.29    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 28 - MOVE  VALOR RENOVACAO AUTOMATICA DO REG TIPO "6" *      */
        /*"      *               PARA  R3-RENOVACAO-AUTOM (REG TIPO "3").         *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/04/2007 - LUCIA VIEIRA             PROCURE POR V.28    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27 - TRATADA A VARIAVEL INDICADORA PARA DATA          *      */
        /*"      *               NASCIMENTO DO CONJUGE E PROFISSAO DO CONJUGE     *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/12/2006 - FAST COMPUTER            PROCURE POR V.27    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 26 - AJUSTADO PARA PREENCHER O VALOR PAGO PARA        *      */
        /*"      *               BILHETES AP E RD EM FUNCAO DO SICOB ESTAR        *      */
        /*"      *               ACEITANDO VALORES DIFERENTES DO CONSTANTE        *      */
        /*"      *               NA PROPOSTA FISICA, FAZENDO COM QUE              *      */
        /*"      *               NAO TENHA COMO SER ENQUADRADO NA BILHETE_COBER   *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/12/2006 - FAST COMPUTER            PROCURE POR V.26    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 25 - AJUSTADO PARA TRATAR DIA DEBITO - ORIGEM GITEL   *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/10/2006 - FAST COMPUTER            PROCURE POR V.25    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 24 - PASSOU A TRATAR CANAL GITEL PARA BILHETES        *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/09/2006 - FAST COMPUTER            PROCURE POR V.24    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 23 - PASSOU A TRATAR OS NOVOS SUBGRUPOS DOS PRODUTOS  *      */
        /*"      *               VIDA DA GENTE, MULTIPREMIADO SUPER, SENIOR E     *      */
        /*"      *               VIDA MULHER NA REFORMULACAO DO VIDA.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/07/2006 - FAST COMPUTER            PROCURE POR V.23    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 - INCLUIR TRATAMENTO DO TIPO DE RESIDENCIA PARA    *      */
        /*"      *               OS BILHETES (COLUNA NUM_TP_MORA_IMOVEL DA        *      */
        /*"      *               TABELA PROP_SASSE_BILHETE)                       *      */
        /*"      *                                                                *      */
        /*"      *   SSI 0911/2005                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/05/2006 - ALEXANDRE / LUCIA VIEIRA   PROCURE POR V.22  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - PASSOU A GRAVAR AS NAO CONFORMIDADES EM RELACAO  *      */
        /*"      *               A DESCRICAO DA PROFISSAO NA TABELA PF_CBO        *      */
        /*"      *               PARA QUE O PROGRAMA PF0601B TRATE ATUALIZE COM   *      */
        /*"      *               O NUMERO DA PROPOSTA.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2006 - ALEXANDRE BERNARDES      PROCURE POR V.21    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - PASSOU A GRAVAR A OCORRENCIA DE ENDERECO DA      *      */
        /*"      *               PESSOA_ENDERECO NA PROPOSTAS_VA PARA QUE O       *      */
        /*"      *               PF0601B RECUPERE O ENDERECO DA PROPOSTA PARA     *      */
        /*"      *               BATER COM O ENDERECO DA ENDERECOS.               *      */
        /*"      *                                                                *      */
        /*"      *               PASSOU TAMBEM A MARCAR O CAMPO EMAIL PARA        *      */
        /*"      *               POSTERIOR GRAVACAO NA CLIENTE_MAIL PARA O VIDA   *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/02/2006 - FAST COMPUTER            PROCURE POR V.20    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 - PASSOU A TRATAR O NUMERO DO CARTAO DE CREDITO    *      */
        /*"      *               NO REGISTRO DE TIPO 'B'. O REGISTRO DE TIPO 'A'  *      */
        /*"      *               NAO DEVE SER PROCESSADO E NAO PODE ABENDAR O     *      */
        /*"      *               PROGRAMA.                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/09/2005 - TERCIO CARVALHO          PROCURE POR V.19    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 - PASSOU A TRATAR O SEGURO VIDA MULHER.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2005 - LUIZ CARLOS              PROCURE POR V.18           */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - PASSOU A GERAR A TABELA PF_CBO. TABELA UTILIZADA *      */
        /*"      *               PARA NO CASO DE VIDA E BILHETE AP, MELHOR QUALI- *      */
        /*"      *               FICAR A PROFISSAO DO SEGURADO.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/12/2004 - LUIZ CARLOS              PROCURE POR V.17           */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - PASSOU A GERAR A TABELA OPCAO_PAG_VIDAZUL, PARA  *      */
        /*"      *               OS PAGAMENTO DE VIDA COM CARTAO DE CREDITO       *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/09/2004 - LUIZ CARLOS              PROCURE POR V.16    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - PASSA A TRATAR PROPOSTAS VIDA EMPRESARIAL SUPER  *      */
        /*"      *               RECEBIDAS DO SIGPF.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/11/2003 - LUIZ CARLOS              PROCURE POR V.15    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14  NAO MAIS ATUALIZA A PROPOSTA_FIDELIZ E NAO GERA   *      */
        /*"      *              A HIST_PROP_FIDELIZ, PARA PROPOSTAS DE AUTO V.C,  *      */
        /*"      *              RETORNADAS DO SIGPF NO DIA (PROPOSTAS COM SITUACAO*      */
        /*"      *              'CAV' RETORNADA 'POB'). O 'POB' SERA GERADO NO PGM*      */
        /*"      *              CV0005B.                    PROCURE POR V.14      *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/09/2003 - LUIZ CARLOS              PROCURE POR V.14    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13  PASSOU A TRATAR PROPOSTAS COMERCIALIZADAS NA CEN- *      */
        /*"      *              TRAL DE ATENDIMENTO, QUANDO RETORNANDO DO SIGPF.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/09/2003 - LUIZ CARLOS              PROCURE POR V.13    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12  FOI INIBIDO O SELECT  DA COLUNA COD_PRODUTO NA    *      */
        /*"      *            TABELA PRODUTOS_SIVPF.                              *      */
        /*"      *            PROCURAR V.12.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/07/2003 - CHICON.                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11                                                    *      */
        /*"      *   FORAM EXCLUIDOS DO REGISTRO DE CLIENTES, O DD E TELEFONE CE- *      */
        /*"      *   LULAR E INCLUIDOS A 'DATA DE EXPEDICAO DO RG' E O 'CODIGO DO *      */
        /*"      *   SEGMENTO'.                                                   *      */
        /*"      *   DATA ..... 10/04/2003 - PROCURE POR V.11                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 10. ADEQUACAO PARA TRATAR O NOVO MULTIPREMIADO SUPER E O*      */
        /*"      *            VIDA DA GENTE. (EM FUNCAO DO SIGAT IREMOS RECEBER O *      */
        /*"      *            MULTIPREMIADO NA VERSAO NOVA E NA ANTIGA - EM RELA- *      */
        /*"      *            CAO A TABELA DE PLANOS).                            *      */
        /*"      *                                                                *      */
        /*"      * EM 13/01/2003 - LUIZ CARLOS.          PROCURE V10              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 09. ADEQUACAO DO CONVENIO AUTO VERA CRUZ - CAV.         *      */
        /*"      *                                                                *      */
        /*"      *            ESTE PROCESSO, CONSISTE EM RECEBER DO SIGPF AS PRO- *      */
        /*"      *            POSTAS VENDIDAS NO KIT V.C, J  CADASTRADAS NAS  BA- *      */
        /*"      *            SES DO PF. ESSAS PROPOSTAS FORAM CADASTRADAS   PELO *      */
        /*"      *            PROGRAMA PF0001B E PODERAO RETORNAR 'ENV' OU 'POB'. *      */
        /*"      *                                                                *      */
        /*"      * EM 26/11/2002 - LUIZ CARLOS.          PROCURE V.09             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 08. POR SOLICITACAO DA GEAUT, O SISPF PASSA A RECEBER DO*      */
        /*"      *            SIGPF, PROPOSTAS DE AUTO (VR,VL), PENDENTES DE SICOB*      */
        /*"      *                                                                *      */
        /*"      * EM 28/08/2002 - LUIZ CARLOS.          PROCURE LC0830.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 07. PASSOU A RECEBER DA CEF, MOVIMENTO DE PRODUTOS DE   *      */
        /*"      *            MULTIRISCO E GERAR ARQUIVO PARA CADASTRAMENTO NA BA-*      */
        /*"      *            SE DO SIAS.                                         *      */
        /*"      *                                                                *      */
        /*"      * EM 08/01/2002 - LUIZ CARLOS.          PROCURE V.07.            *      */
        /*"      *                                                                *      */
        /*"      *       -------------------------------------------------------- *      */
        /*"      * OBS.: DEVIDO A PROBLEMAS DIVEERSOS A VERSAO V.07, SO FOI PROMO *      */
        /*"      *       VIDA A PRODUCAO EM 17/12/2003.                           *      */
        /*"      *       -------------------------------------------------------- *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06. ABENDAR CASO IDENTIFIQUE PROPOSTA DE AUTO VENDIDA   *      */
        /*"      *            PELA FILIAL. CONFORME COMBINADO COM PASTORE.        *      */
        /*"      *                                                                *      */
        /*"      *            PROPOSTAS AUTO/SIVPF: QUE A COBRANCA NAO CHEGOU, O  *      */
        /*"      *            NUN-SICOB DO ARQUIVO GERADO PARA O SISTEMA AUTO, SE *      */
        /*"      *            RA GERADO COM ZEROS, E SERA TRATADO NO AU6800B.   O *      */
        /*"      *            SICOB DA PROPOSTA DE FIDELIZACAO SERA PREENCHIDO COM*      */
        /*"      *            O NUMERO DA PROPOSTA.                               *      */
        /*"      *                                                                *      */
        /*"      * EM 31/07/2001 - LUIZ CARLOS.          PROCURE LC0731.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05. PASSOU A GERAR RELATORIOS DE CRITICAS DO MOVIMENTO. *      */
        /*"      *                                                                *      */
        /*"      * EM 24/04/2001 - LUIZ CARLOS.          PROCURE LC0424.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 04. PASSOU A ASSUMIR A ORIGEM DA PROPOSTA INFORMADA PE- *      */
        /*"      *            LA CEF, PARA PROPOSTAS GERADAS PELO SIGPF.          *      */
        /*"      *                                                                *      */
        /*"      * EM 21/02/2001 - LUIZ CARLOS.          PROCURE LC0102.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 03. PASSOU A GERAR ARQUIVO MOVIMENTO DE AUTOMOVEIS      *      */
        /*"      *            ARQUIVO DE SAIDA ARQAUTO.                           *      */
        /*"      *                                                                *      */
        /*"      *            PASSOU A GERAR ARQUIVO A SER ENVIADO A CEF, COM O   *      */
        /*"      *            MOVIMENTO GERADO NAS FILIAIS (SIVPF).               *      */
        /*"      *                                                                *      */
        /*"      * EM 19/01/2001 - LUIZ CARLOS.          PROCURE LC0101.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 02. PASSOU A TRATAR PROPOSTA MANUAL, PROPOSTAS DO SIGPF *      */
        /*"      *            PENDENTE DE SICOB.                                  *      */
        /*"      *                                                                *      */
        /*"      * EM 09/10/2000 - LUIZ CARLOS.          PROCURE LC1000           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 01. ESTE PROGRAMA POSSOU PROCESSAR SOMENTE O MOVIMENTO  *      */
        /*"      *            DA SASSE.  FOI CRIADO UMA VERSAO PF1600B, QUE PAS-  *      */
        /*"      *            SOU A PROCESSAR CAP. E PREV.                        *      */
        /*"      *                                                                *      */
        /*"      * EM 18/02/2000 - LUIZ CARLOS.                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *=================================================================      */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_SIGAT { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_SIGAT
        {
            get
            {
                _.Move(REG_SIGAT, _MOV_SIGAT); VarBasis.RedefinePassValue(REG_SIGAT, _MOV_SIGAT, REG_SIGAT); return _MOV_SIGAT;
            }
        }
        public FileBasis _MOV_VDEMP { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_VDEMP
        {
            get
            {
                _.Move(REG_MOV_VDEMP, _MOV_VDEMP); VarBasis.RedefinePassValue(REG_MOV_VDEMP, _MOV_VDEMP, REG_MOV_VDEMP); return _MOV_VDEMP;
            }
        }
        public FileBasis _RVA0600B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVA0600B
        {
            get
            {
                _.Move(REG_RVA0600B, _RVA0600B); VarBasis.RedefinePassValue(REG_RVA0600B, _RVA0600B, REG_RVA0600B); return _RVA0600B;
            }
        }
        /*"01   REG-SIGAT.*/
        public VA0600B_REG_SIGAT REG_SIGAT { get; set; } = new VA0600B_REG_SIGAT();
        public class VA0600B_REG_SIGAT : VarBasis
        {
            /*"     10  REG-TIPO-SIGAT                  PIC X(001).*/
            public StringBasis REG_TIPO_SIGAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  REG-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis REG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  FILLER REDEFINES REG-NUM-PROPOSTA.*/
            private _REDEF_VA0600B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0600B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0600B_FILLER_0(); _.Move(REG_NUM_PROPOSTA, _filler_0); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_0, REG_NUM_PROPOSTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_NUM_PROPOSTA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, REG_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_0 : VarBasis
            {
                /*"         15  REG-NOME-ARQUIVO            PIC X(008).*/
                public StringBasis REG_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"         15  FILLER                      PIC X(006).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"     10  FILLER                          PIC X(259).*/

                public _REDEF_VA0600B_FILLER_0()
                {
                    REG_NOME_ARQUIVO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "259", "X(259)."), @"");
            /*"     10  REG-ORIGEM-AIC                  PIC 9(004).*/
            public IntBasis REG_ORIGEM_AIC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  REG-ORIGEM-SIV                  REDEFINES         REG-ORIGEM-AIC.*/
            private _REDEF_VA0600B_REG_ORIGEM_SIV _reg_origem_siv { get; set; }
            public _REDEF_VA0600B_REG_ORIGEM_SIV REG_ORIGEM_SIV
            {
                get { _reg_origem_siv = new _REDEF_VA0600B_REG_ORIGEM_SIV(); _.Move(REG_ORIGEM_AIC, _reg_origem_siv); VarBasis.RedefinePassValue(REG_ORIGEM_AIC, _reg_origem_siv, REG_ORIGEM_AIC); _reg_origem_siv.ValueChanged += () => { _.Move(_reg_origem_siv, REG_ORIGEM_AIC); }; return _reg_origem_siv; }
                set { VarBasis.RedefinePassValue(value, _reg_origem_siv, REG_ORIGEM_AIC); }
            }  //Redefines
            public class _REDEF_VA0600B_REG_ORIGEM_SIV : VarBasis
            {
                /*"      15 FILLER                          PIC X(002).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      15 REG-ORIGEM                      PIC 9(002).*/
                public IntBasis REG_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10  FILLER                          PIC X(022).*/

                public _REDEF_VA0600B_REG_ORIGEM_SIV()
                {
                    FILLER_3.ValueChanged += OnValueChanged;
                    REG_ORIGEM.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
            /*"01   REG-MOV-VDEMP                       PIC X(300).*/
        }
        public StringBasis REG_MOV_VDEMP { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-RVA0600B                       PIC X(132).*/
        public StringBasis REG_RVA0600B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I03 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I04 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I05 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I06 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I07 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I08 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  REG-TIPO-6-AUX.*/
        public VA0600B_REG_TIPO_6_AUX REG_TIPO_6_AUX { get; set; } = new VA0600B_REG_TIPO_6_AUX();
        public class VA0600B_REG_TIPO_6_AUX : VarBasis
        {
            /*"    05  FILLER                          PIC X(159).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "159", "X(159)."), @"");
            /*"    05  RENOV-AUTOM-6-AUX               PIC X(001).*/
            public StringBasis RENOV_AUTOM_6_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  FILLER                          PIC X(140).*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "140", "X(140)."), @"");
            /*"01  WS-JV1-PROGRAMA                  PIC  X(008) VALUE SPACES.*/
        }
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WHOST-COD-PESSOA-PJ                 PIC S9(009) COMP.*/
        public IntBasis WHOST_COD_PESSOA_PJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-COD-PESSOA-PF                 PIC S9(009) COMP.*/
        public IntBasis WHOST_COD_PESSOA_PF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-APOLICE-PLANO              PIC S9(013) COMP-3.*/
        public IntBasis WHOST_APOLICE_PLANO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  WHOST-CODSUBES-PLANO             PIC S9(004) COMP.*/
        public IntBasis WHOST_CODSUBES_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-CODPRODU-PLANO             PIC S9(004) COMP.*/
        public IntBasis WHOST_CODPRODU_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-APOLICE                    PIC S9(013) COMP-3.*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  WHOST-PRODUTO                    PIC S9(004) COMP.*/
        public IntBasis WHOST_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PERIPGTO                   PIC S9(004) COMP.*/
        public IntBasis WHOST_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DATA-PROPOSTA              PIC  X(010).*/
        public StringBasis WHOST_DATA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-DATA-QUITACAO              PIC  X(010).*/
        public StringBasis WHOST_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-PRM-PAGO-MA                PIC S9(013)V9(002) COMP-3.*/
        public DoubleBasis WHOST_PRM_PAGO_MA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"01  WHOST-DATA-EXP-RG                PIC  X(010).*/
        public StringBasis WHOST_DATA_EXP_RG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  IND-RG                           PIC S9(004) COMP.*/
        public IntBasis IND_RG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W-QTD-DIG-RG                     PIC S9(007) COMP.*/
        public IntBasis W_QTD_DIG_RG { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
        /*"01  W-LIT-RG.*/
        public VA0600B_W_LIT_RG W_LIT_RG { get; set; } = new VA0600B_W_LIT_RG();
        public class VA0600B_W_LIT_RG : VarBasis
        {
            /*" 03 W-LIT-RG-NUM      OCCURS         015  TIMES     PIC  9(001).*/
            public ListBasis<IntBasis, Int64> W_LIT_RG_NUM { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 015);
            /*"01  WHOST-DATA-TRABALHO              PIC  X(008) VALUE SPACES.*/
        }
        public StringBasis WHOST_DATA_TRABALHO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WHOST-OPCAO-CONJUGE              PIC  X(001).*/
        public StringBasis WHOST_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-OPCAO-COBER                PIC  X(001).*/
        public StringBasis WHOST_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-IDADE                      PIC S9(004) COMP.*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PRM-TOTAL-MA               PIC S9(013)V9(002) COMP-3.*/
        public DoubleBasis WHOST_PRM_TOTAL_MA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"01  WHOST-TAXA-MULT                  PIC S9(005)V9(004) COMP-3.*/
        public DoubleBasis WHOST_TAXA_MULT { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(004)"), 4);
        /*"01  WHOST-PRM-MAIS                   PIC S9(013)V9(002) COMP-3.*/
        public DoubleBasis WHOST_PRM_MAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"01  WHOST-PRM-MENOS                  PIC S9(013)V9(002) COMP-3.*/
        public DoubleBasis WHOST_PRM_MENOS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"01  WHOST-VLR-RANGE                  PIC S9(013)V9(002) COMP-3.*/
        public DoubleBasis WHOST_VLR_RANGE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"01  WS-PROGRAMA                      PIC X(008)  VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-ENCONTROU-RISCO               PIC X(003)  VALUE SPACES.*/
        public StringBasis WS_ENCONTROU_RISCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  WS-QT-SITUACAO-PCR               PIC 9(008)  VALUE ZEROS.*/
        public IntBasis WS_QT_SITUACAO_PCR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"01  VIND-STA-ANTECIPACAO             PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_STA_ANTECIPACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NULL                        PIC S9(4) COMP VALUE -1.*/
        public IntBasis VIND_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"), -1);
        /*"01  VIND-OPER-CREDITO                PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_OPER_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUM-PRAZO                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUM_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ZEROS                       PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ZEROS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CPF                         PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-SEXO                        PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-UF-EXP                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_UF_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DT-NASCI                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DT_NASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASCI                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTNASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CBO-CONJ                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CBO_CONJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-CBO                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TP-IDENT                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TP_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTEXPEDI                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTEXPEDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-USUR                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_USUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUM-IDENT                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUM_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ORGAO-EXP                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ORGAO_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TIMESTAMP                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TIMESTAMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-RCAPS-AGE                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_RCAPS_AGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-PESSOA                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASC-ESPOSA               PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTNASC_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-DTPROXVEN                  PIC  X(010).*/
        public StringBasis WHOST_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-FONTE                      PIC S9(004) COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PROPAUTOM                  PIC S9(009) COMP.*/
        public IntBasis WHOST_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-SIT-REGISTRO               PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  VIND-AGECTADEB                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-OPRCTADEB                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUMCTADEB                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CARTAO                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DIGCTADEB                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TP-PROP                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TP_PROP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  W-REG-HEADER.*/
        public VA0600B_W_REG_HEADER W_REG_HEADER { get; set; } = new VA0600B_W_REG_HEADER();
        public class VA0600B_W_REG_HEADER : VarBasis
        {
            /*"    05  W-RH-TIPO-REG               PIC  X(001).*/
            public StringBasis W_RH_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  W-RH-NOME                   PIC  X(008).*/
            public StringBasis W_RH_NOME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  W-RH-DATA-GERACAO           PIC  9(008).*/
            public IntBasis W_RH_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  W-RH-SIST-ORIGEM            PIC  9(001).*/
            public IntBasis W_RH_SIST_ORIGEM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05  W-RH-SIST-DESTINO           PIC  9(001).*/
            public IntBasis W_RH_SIST_DESTINO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05  W-RH-NSAS                   PIC  9(006).*/
            public IntBasis W_RH_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-RH-TIPO-ARQUIVO           PIC  9(001).*/
            public IntBasis W_RH_TIPO_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05  FILLER                      PIC  X(044).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
            /*"    05  W-RH-AGE-GERADORA           PIC  9(004).*/
            public IntBasis W_RH_AGE_GERADORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  FILLER                      PIC  X(226).*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "226", "X(226)."), @"");
            /*"01  WAREA-AUXILIAR.*/
        }
        public VA0600B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new VA0600B_WAREA_AUXILIAR();
        public class VA0600B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  WS-DTQITBCO                   PIC X(010).*/
            public StringBasis WS_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  WS-DTQITBCO-R REDEFINES       WS-DTQITBCO.*/
            private _REDEF_VA0600B_WS_DTQITBCO_R _ws_dtqitbco_r { get; set; }
            public _REDEF_VA0600B_WS_DTQITBCO_R WS_DTQITBCO_R
            {
                get { _ws_dtqitbco_r = new _REDEF_VA0600B_WS_DTQITBCO_R(); _.Move(WS_DTQITBCO, _ws_dtqitbco_r); VarBasis.RedefinePassValue(WS_DTQITBCO, _ws_dtqitbco_r, WS_DTQITBCO); _ws_dtqitbco_r.ValueChanged += () => { _.Move(_ws_dtqitbco_r, WS_DTQITBCO); }; return _ws_dtqitbco_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dtqitbco_r, WS_DTQITBCO); }
            }  //Redefines
            public class _REDEF_VA0600B_WS_DTQITBCO_R : VarBasis
            {
                /*"     10 WS-DTQITBCO-ANO               PIC 9(004).*/
                public IntBasis WS_DTQITBCO_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 FILLER                        PIC X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 WS-DTQITBCO-MES               PIC 9(002).*/
                public IntBasis WS_DTQITBCO_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 FILLER                        PIC X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 WS-DTQITBCO-DIA               PIC 9(002).*/
                public IntBasis WS_DTQITBCO_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WS-CHAVE-ATU.*/

                public _REDEF_VA0600B_WS_DTQITBCO_R()
                {
                    WS_DTQITBCO_ANO.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WS_DTQITBCO_MES.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WS_DTQITBCO_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VA0600B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VA0600B_WS_CHAVE_ATU();
            public class VA0600B_WS_CHAVE_ATU : VarBasis
            {
                /*"     10 WS-APOLICE-ATU                PIC 9(013)  VALUE ZEROS.*/
                public IntBasis WS_APOLICE_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"     10 WS-SUBGRUPO-ATU               PIC 9(005)  VALUE ZEROS.*/
                public IntBasis WS_SUBGRUPO_ATU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    05  WS-CHAVE-ANT.*/
            }
            public VA0600B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VA0600B_WS_CHAVE_ANT();
            public class VA0600B_WS_CHAVE_ANT : VarBasis
            {
                /*"     10 WS-APOLICE-ANT                PIC 9(013)  VALUE 99999999*/
                public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"), 99999999);
                /*"     10 WS-SUBGRUPO-ANT               PIC 9(005)  VALUE 99999.*/
                public IntBasis WS_SUBGRUPO_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"), 99999);
                /*"    05  W-FIM-CBO                     PIC X(003)  VALUE SPACES.*/
            }
            public StringBasis W_FIM_CBO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-FONTES                  PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_FONTES { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-MOVTO-SIGAT             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_SIGAT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-EMAIL            PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-ENDERECO         PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  WS-COD-CBO                    PIC S9(9)   USAGE COMP.*/
            public IntBasis WS_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    05  WS-DESCR-CBO                  PIC X(020)  VALUE SPACES.*/
            public StringBasis WS_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"    05  WS-DESCR-CBO-1                PIC X(020)  VALUE SPACES.*/
            public StringBasis WS_DESCR_CBO_1 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"    05  WS-DESCR-CBO-R                REDEFINES        WS-DESCR-CBO-1.*/
            private _REDEF_VA0600B_WS_DESCR_CBO_R _ws_descr_cbo_r { get; set; }
            public _REDEF_VA0600B_WS_DESCR_CBO_R WS_DESCR_CBO_R
            {
                get { _ws_descr_cbo_r = new _REDEF_VA0600B_WS_DESCR_CBO_R(); _.Move(WS_DESCR_CBO_1, _ws_descr_cbo_r); VarBasis.RedefinePassValue(WS_DESCR_CBO_1, _ws_descr_cbo_r, WS_DESCR_CBO_1); _ws_descr_cbo_r.ValueChanged += () => { _.Move(_ws_descr_cbo_r, WS_DESCR_CBO_1); }; return _ws_descr_cbo_r; }
                set { VarBasis.RedefinePassValue(value, _ws_descr_cbo_r, WS_DESCR_CBO_1); }
            }  //Redefines
            public class _REDEF_VA0600B_WS_DESCR_CBO_R : VarBasis
            {
                /*"     15 WS-DESCR-INI                  PIC X(007).*/
                public StringBasis WS_DESCR_INI { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"     15 WS-DESCR-FIM                  PIC X(013).*/
                public StringBasis WS_DESCR_FIM { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05  W-LIDO-MOVTO-SIGAT            PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VA0600B_WS_DESCR_CBO_R()
                {
                    WS_DESCR_INI.ValueChanged += OnValueChanged;
                    WS_DESCR_FIM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_LIDO_MOVTO_SIGAT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-AC-CONTROLE                 PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-OBTER-MAX-PESSOA            PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_PESSOA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-EXISTE-PROPOSTA             PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_EXISTE_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-EXISTE-OPCAOPAGVA           PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_EXISTE_OPCAOPAGVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-EXISTE-TP-2                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-TP-4                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-TP-5                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_5 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-TP-6                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-TP-B                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_B { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-TP-C                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-TP-D                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_D { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-TP-W                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_W { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-INDEX                       PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_INDEX { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-IND-BENEF                   PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-BENEF-N                 PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF_N { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-INFO                    PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_INFO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-INFO1                   PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_INFO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-INFO-N                  PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_INFO_N { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-INDICE-1                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_INDICE_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-INDICE-2                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_INDICE_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-INDICE-ERRO                 PIC 9(002)  VALUE ZEROS.*/
            public IntBasis W_INDICE_ERRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  W-CONT-LINHAS                 PIC 9(003)  VALUE 100.*/
            public IntBasis W_CONT_LINHAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 100);
            /*"    05  W-IND-RISCO                   PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_RISCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-RISCO-N                 PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_RISCO_N { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-VDEMP                   PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_VDEMP { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-VDEMP-N                 PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_VDEMP_N { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-CLAU                    PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_CLAU { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-CLAU-N                  PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_CLAU_N { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-ENDER                   PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-ENDER1                  PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-ENDER-A                 PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER_A { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-ENDER-N                 PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER_N { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 W-IND                         PIC  S9(004)  COMP VALUE +0*/
            public IntBasis W_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-QTD                        PIC  S9(004)  COMP VALUE +0*/
            public IntBasis WS_QTD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-INF                        PIC  9(009).*/
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05 WS-SUP                        PIC  9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05 WS-IND                        PIC  S9(004)  VALUE +0 COMP*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-IND1                       PIC  S9(004)  VALUE +0 COMP*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-IND2                       PIC  S9(004)  VALUE +0 COMP*/
            public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WTEM-TAB                      PIC   X(001)  VALUE  SPACES*/
            public StringBasis WTEM_TAB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 WTEM-SUBGRUPO                 PIC   X(001)  VALUE  SPACES*/
            public StringBasis WTEM_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 WS-EOF                        PIC   X(001)  VALUE  SPACES*/
            public StringBasis WS_EOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 WS-ANO-BASE                   PIC   9(004)  VALUE  0.*/
            public IntBasis WS_ANO_BASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 WS-ANO-NASC                   PIC   9(004)  VALUE  0.*/
            public IntBasis WS_ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-CONTROLE-TP-0               PIC  9(01)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-QTD-LD-SIVPF-0              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-1              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-2              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-3              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-4              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-5              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-6              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-7              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-8              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-9              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-A              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-B              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-C              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-D              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-E              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-F              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-G              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-H              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-I              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-J              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-SIVPF-W              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_W { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-CRITICA                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MATRIZ                  PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MATRIZ { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-0               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-1               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-2               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-3               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-4               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-5               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-6               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-7               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-8               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-9               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-A               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-B               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-C               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-D               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-E               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-F               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-G               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-H               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-I               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-AUTO-J               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-0              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-1              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-2              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-3              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-4              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-5              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-6              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-7              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-8              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-9              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-A              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-B              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-C              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-D              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-E              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-F              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-G              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-H              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-I              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-RISCO-J              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_RISCO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-0              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-1              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-2              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-3              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-4              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-5              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-6              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-7              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-8              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-9              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-A              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-B              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-C              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-D              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-E              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-F              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-G              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-H              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-I              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-J              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-VDEMP-W              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_VDEMP_W { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-0             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-1             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-2             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-3             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-4             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-5             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-6             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-7             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-8             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-9             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-A             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-B             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-C             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-D             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-E             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-F             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-G             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-H             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-I             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-FILIAL-J             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_FILIAL_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LH-TIPO-2               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LH_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LH-TIPO-3               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LH_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-SEQ-FONE                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_FONE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-SEQ-EMAIL                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-COD-PESSOA                  PIC 9(009)  VALUE ZEROS.*/
            public IntBasis W_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05  W-ACHOU-SICOB                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_SICOB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-EMAIL                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-COD-RELACION                PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_RELACION { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-ACHOU-ENDERECO              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-TELEFONE              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-RELACIONAMENTO        PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_RELACIONAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OCORR-ENDERECO              PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-NUM-PROPOSTA-ANT            PIC 9(014)  VALUE ZEROS.*/
            public IntBasis W_NUM_PROPOSTA_ANT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  W-NUM-IDENTIF                 PIC 9(015)  VALUE ZEROS.*/
            public IntBasis W_NUM_IDENTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  W-NUM-BENEF                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_NUM_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-CANAL-ANT                   PIC 9(002).*/
            public IntBasis W_CANAL_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  W-NSAS-ANT                    PIC 9(006).*/
            public IntBasis W_NSAS_ANT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  WS-ESTADO-CIVIL               PIC X(001).*/
            public StringBasis WS_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  W-NSL-SASSE                   PIC 9(006).*/
            public IntBasis W_NSL_SASSE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSAS-FILIAL                 PIC 9(006).*/
            public IntBasis W_NSAS_FILIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSAS-PRP-CEF                PIC 9(006).*/
            public IntBasis W_NSAS_PRP_CEF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-SIGLA-ARQUIVO               PIC X(008)  VALUE SPACES.*/
            public StringBasis W_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05  FILLER REDEFINES W-SIGLA-ARQUIVO.*/
            private _REDEF_VA0600B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_VA0600B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_VA0600B_FILLER_11(); _.Move(W_SIGLA_ARQUIVO, _filler_11); VarBasis.RedefinePassValue(W_SIGLA_ARQUIVO, _filler_11, W_SIGLA_ARQUIVO); _filler_11.ValueChanged += () => { _.Move(_filler_11, W_SIGLA_ARQUIVO); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, W_SIGLA_ARQUIVO); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_11 : VarBasis
            {
                /*"        07  W-IDE-SIGLA               PIC X(004).*/
                public StringBasis W_IDE_SIGLA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"        07  W-IDE-FILIAL              PIC 9(004).*/
                public IntBasis W_IDE_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-NR-SICOB                    PIC 9(015).*/

                public _REDEF_VA0600B_FILLER_11()
                {
                    W_IDE_SIGLA.ValueChanged += OnValueChanged;
                    W_IDE_FILIAL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  FILLER REDEFINES W-NR-SICOB.*/
            private _REDEF_VA0600B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_VA0600B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_VA0600B_FILLER_12(); _.Move(W_NR_SICOB, _filler_12); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_12, W_NR_SICOB); _filler_12.ValueChanged += () => { _.Move(_filler_12, W_NR_SICOB); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_12 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/

                public _REDEF_VA0600B_FILLER_12()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05  FILLER                      REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VA0600B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_VA0600B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_VA0600B_FILLER_13(); _.Move(W_NUMR_TITULO, _filler_13); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_13, W_NUMR_TITULO); _filler_13.ValueChanged += () => { _.Move(_filler_13, W_NUMR_TITULO); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_13 : VarBasis
            {
                /*"      10    WTITL-ZEROS             PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    WTITL-SEQUENCIA         PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10    WTITL-DIGITO            PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-PROPOSTA-DPS              PIC  X(300)   VALUE SPACES.*/

                public _REDEF_VA0600B_FILLER_13()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_PROPOSTA_DPS { get; set; } = new StringBasis(new PIC("X", "300", "X(300)"), @"");
            /*"    05  FILLER                      REDEFINES     W-PROPOSTA-DPS*/
            private _REDEF_VA0600B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VA0600B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VA0600B_FILLER_14(); _.Move(W_PROPOSTA_DPS, _filler_14); VarBasis.RedefinePassValue(W_PROPOSTA_DPS, _filler_14, W_PROPOSTA_DPS); _filler_14.ValueChanged += () => { _.Move(_filler_14, W_PROPOSTA_DPS); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, W_PROPOSTA_DPS); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_14 : VarBasis
            {
                /*"      10 W-NRPROPOSTA-DPS           PIC  X(017).*/
                public StringBasis W_NRPROPOSTA_DPS { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
                /*"      10 W-DPS-VDMULHER             PIC  X(026).*/
                public StringBasis W_DPS_VDMULHER { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
                /*"      10 W-FILLER                   PIC  X(257).*/
                public StringBasis W_FILLER { get; set; } = new StringBasis(new PIC("X", "257", "X(257)."), @"");
                /*"    05  W-DPS-NEW-V-GENTE           PIC  X(007)   VALUE SPACES.*/

                public _REDEF_VA0600B_FILLER_14()
                {
                    W_NRPROPOSTA_DPS.ValueChanged += OnValueChanged;
                    W_DPS_VDMULHER.ValueChanged += OnValueChanged;
                    W_FILLER.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DPS_NEW_V_GENTE { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"    05  FILLER                      REDEFINES W-DPS-NEW-V-GENTE.*/
            private _REDEF_VA0600B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_VA0600B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_VA0600B_FILLER_15(); _.Move(W_DPS_NEW_V_GENTE, _filler_15); VarBasis.RedefinePassValue(W_DPS_NEW_V_GENTE, _filler_15, W_DPS_NEW_V_GENTE); _filler_15.ValueChanged += () => { _.Move(_filler_15, W_DPS_NEW_V_GENTE); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, W_DPS_NEW_V_GENTE); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_15 : VarBasis
            {
                /*"      10 W-DPS-NEW-V-GENTE1         PIC  X(001).*/
                public StringBasis W_DPS_NEW_V_GENTE1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 W-DPS-NEW-V-GENTE2         PIC  X(001).*/
                public StringBasis W_DPS_NEW_V_GENTE2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 W-DPS-NEW-V-GENTE3         PIC  X(001).*/
                public StringBasis W_DPS_NEW_V_GENTE3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 W-DPS-NEW-V-GENTE4         PIC  X(001).*/
                public StringBasis W_DPS_NEW_V_GENTE4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 W-DPS-NEW-V-GENTE5         PIC  X(001).*/
                public StringBasis W_DPS_NEW_V_GENTE5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 W-DPS-NEW-V-GENTE6         PIC  X(001).*/
                public StringBasis W_DPS_NEW_V_GENTE6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 W-DPS-NEW-V-GENTE7         PIC  X(001).*/
                public StringBasis W_DPS_NEW_V_GENTE7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05  WS-CHAVE.*/

                public _REDEF_VA0600B_FILLER_15()
                {
                    W_DPS_NEW_V_GENTE1.ValueChanged += OnValueChanged;
                    W_DPS_NEW_V_GENTE2.ValueChanged += OnValueChanged;
                    W_DPS_NEW_V_GENTE3.ValueChanged += OnValueChanged;
                    W_DPS_NEW_V_GENTE4.ValueChanged += OnValueChanged;
                    W_DPS_NEW_V_GENTE5.ValueChanged += OnValueChanged;
                    W_DPS_NEW_V_GENTE6.ValueChanged += OnValueChanged;
                    W_DPS_NEW_V_GENTE7.ValueChanged += OnValueChanged;
                }

            }
            public VA0600B_WS_CHAVE WS_CHAVE { get; set; } = new VA0600B_WS_CHAVE();
            public class VA0600B_WS_CHAVE : VarBasis
            {
                /*"        10  WS-CH-APOLICE             PIC 9(15).*/
                public IntBasis WS_CH_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"        10  WS-CH-PERI-PGTO           PIC 9(02).*/
                public IntBasis WS_CH_PERI_PGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"        10  WS-CH-OPCAO-CONJ          PIC X(01).*/
                public StringBasis WS_CH_OPCAO_CONJ { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    05       W-TAB-BENEFICIARIOS.*/
            }
            public VA0600B_W_TAB_BENEFICIARIOS W_TAB_BENEFICIARIOS { get; set; } = new VA0600B_W_TAB_BENEFICIARIOS();
            public class VA0600B_W_TAB_BENEFICIARIOS : VarBasis
            {
                /*"       10    W-TAB-BENEF-REG   OCCURS 30  TIMES INDEXED BY I01.*/
                public ListBasis<VA0600B_W_TAB_BENEF_REG> W_TAB_BENEF_REG { get; set; } = new ListBasis<VA0600B_W_TAB_BENEF_REG>(30);
                public class VA0600B_W_TAB_BENEF_REG : VarBasis
                {
                    /*"          15 W-TB-REG-BENEFI   PIC  X(300).*/
                    public StringBasis W_TB_REG_BENEFI { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TAB-INFORMACOES.*/
                }
            }
            public VA0600B_W_TAB_INFORMACOES W_TAB_INFORMACOES { get; set; } = new VA0600B_W_TAB_INFORMACOES();
            public class VA0600B_W_TAB_INFORMACOES : VarBasis
            {
                /*"       10    W-TAB-INFO-REG   OCCURS 90  TIMES INDEXED BY I02.*/
                public ListBasis<VA0600B_W_TAB_INFO_REG> W_TAB_INFO_REG { get; set; } = new ListBasis<VA0600B_W_TAB_INFO_REG>(90);
                public class VA0600B_W_TAB_INFO_REG : VarBasis
                {
                    /*"          15 W-TB-REG-INFORMACOES PIC  X(300).*/
                    public StringBasis W_TB_REG_INFORMACOES { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TAB-DIV-M-RISCO.*/
                }
            }
            public VA0600B_W_TAB_DIV_M_RISCO W_TAB_DIV_M_RISCO { get; set; } = new VA0600B_W_TAB_DIV_M_RISCO();
            public class VA0600B_W_TAB_DIV_M_RISCO : VarBasis
            {
                /*"       10    W-TAB-RISCO-REG   OCCURS 999 TIMES INDEXED BY I03.*/
                public ListBasis<VA0600B_W_TAB_RISCO_REG> W_TAB_RISCO_REG { get; set; } = new ListBasis<VA0600B_W_TAB_RISCO_REG>(999);
                public class VA0600B_W_TAB_RISCO_REG : VarBasis
                {
                    /*"          15 W-TB-REG-DIV-M-RISCO PIC  X(300).*/
                    public StringBasis W_TB_REG_DIV_M_RISCO { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TAB-DIV-VDEMP.*/
                }
            }
            public VA0600B_W_TAB_DIV_VDEMP W_TAB_DIV_VDEMP { get; set; } = new VA0600B_W_TAB_DIV_VDEMP();
            public class VA0600B_W_TAB_DIV_VDEMP : VarBasis
            {
                /*"       10    W-TAB-VDEMP-REG   OCCURS 999 TIMES INDEXED BY I04.*/
                public ListBasis<VA0600B_W_TAB_VDEMP_REG> W_TAB_VDEMP_REG { get; set; } = new ListBasis<VA0600B_W_TAB_VDEMP_REG>(999);
                public class VA0600B_W_TAB_VDEMP_REG : VarBasis
                {
                    /*"          15 W-TB-REG-DIV-VDEMP   PIC  X(300).*/
                    public StringBasis W_TB_REG_DIV_VDEMP { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TAB-CLAUSULAS.*/
                }
            }
            public VA0600B_W_TAB_CLAUSULAS W_TAB_CLAUSULAS { get; set; } = new VA0600B_W_TAB_CLAUSULAS();
            public class VA0600B_W_TAB_CLAUSULAS : VarBasis
            {
                /*"       10    W-TAB-CLAU-REG   OCCURS 300 TIMES INDEXED BY I05.*/
                public ListBasis<VA0600B_W_TAB_CLAU_REG> W_TAB_CLAU_REG { get; set; } = new ListBasis<VA0600B_W_TAB_CLAU_REG>(300);
                public class VA0600B_W_TAB_CLAU_REG : VarBasis
                {
                    /*"          15 W-TB-REG-CLAUSULA PIC  X(300).*/
                    public StringBasis W_TB_REG_CLAUSULA { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TB-ENDERECOS-N.*/
                }
            }
            public VA0600B_W_TB_ENDERECOS_N W_TB_ENDERECOS_N { get; set; } = new VA0600B_W_TB_ENDERECOS_N();
            public class VA0600B_W_TB_ENDERECOS_N : VarBasis
            {
                /*"       10    W-TAB-END-REG-N   OCCURS 30 TIMES INDEXED BY I06.*/
                public ListBasis<VA0600B_W_TAB_END_REG_N> W_TAB_END_REG_N { get; set; } = new ListBasis<VA0600B_W_TAB_END_REG_N>(30);
                public class VA0600B_W_TAB_END_REG_N : VarBasis
                {
                    /*"          15 W-TB-REG-ENDERECOS-N     PIC  X(300).*/
                    public StringBasis W_TB_REG_ENDERECOS_N { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05      W-TB-ENDERECOS-A.*/
                }
            }
            public VA0600B_W_TB_ENDERECOS_A W_TB_ENDERECOS_A { get; set; } = new VA0600B_W_TB_ENDERECOS_A();
            public class VA0600B_W_TB_ENDERECOS_A : VarBasis
            {
                /*"      07    W-TAB-END-REG-A OCCURS 30 TIMES INDEXED BY I07.*/
                public ListBasis<VA0600B_W_TAB_END_REG_A> W_TAB_END_REG_A { get; set; } = new ListBasis<VA0600B_W_TAB_END_REG_A>(30);
                public class VA0600B_W_TAB_END_REG_A : VarBasis
                {
                    /*"        10  W-TB-REG-ENDERECOS-A.*/
                    public VA0600B_W_TB_REG_ENDERECOS_A W_TB_REG_ENDERECOS_A { get; set; } = new VA0600B_W_TB_REG_ENDERECOS_A();
                    public class VA0600B_W_TB_REG_ENDERECOS_A : VarBasis
                    {
                        /*"            15 COD-PESSOA           PIC S9(9) USAGE COMP.*/
                        public IntBasis COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                        /*"            15 OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
                        public IntBasis OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                        /*"            15 ENDERECO             PIC X(40).*/
                        public StringBasis ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                        /*"            15 TIPO-ENDER           PIC S9(4) USAGE COMP.*/
                        public IntBasis TIPO_ENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                        /*"            15 COMPL-ENDER          PIC X(15).*/
                        public StringBasis COMPL_ENDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                        /*"            15 BAIRRO               PIC X(20).*/
                        public StringBasis BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                        /*"            15 CEP                  PIC S9(9) USAGE COMP.*/
                        public IntBasis CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                        /*"            15 CIDADE               PIC X(20).*/
                        public StringBasis CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                        /*"            15 SIGLA-UF             PIC X(2).*/
                        public StringBasis SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
                        /*"            15 SITUACAO-ENDERECO    PIC X(1).*/
                        public StringBasis SITUACAO_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
                        /*"            15 COD-USUARIO          PIC X(8).*/
                        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                        /*"            15 TIMESTAMP            PIC X(26).*/
                        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
                        /*"    05      TAB-CBO.*/
                    }
                }
            }
            public VA0600B_TAB_CBO TAB_CBO { get; set; } = new VA0600B_TAB_CBO();
            public class VA0600B_TAB_CBO : VarBasis
            {
                /*"     10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<VA0600B_FILLER_16> FILLER_16 { get; set; } = new ListBasis<VA0600B_FILLER_16>(999);
                public class VA0600B_FILLER_16 : VarBasis
                {
                    /*"       15  TAB-COD-CBO         PIC  9(4).*/
                    public IntBasis TAB_COD_CBO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"       15  TAB-DESCR-CBO       PIC  X(5).*/
                    public StringBasis TAB_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
                    /*"       15  TAB-DESCR-CBO-C     PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"    05      TAB-FILIAL.*/
                }
            }
            public VA0600B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA0600B_TAB_FILIAL();
            public class VA0600B_TAB_FILIAL : VarBasis
            {
                /*"     10    TAB-FILIAIS OCCURS    9999   TIMES INDEXED BY I08.*/
                public ListBasis<VA0600B_TAB_FILIAIS> TAB_FILIAIS { get; set; } = new ListBasis<VA0600B_TAB_FILIAIS>(9999);
                public class VA0600B_TAB_FILIAIS : VarBasis
                {
                    /*"       15  TAB-COD-FILIAL           PIC  9(4).*/
                    public IntBasis TAB_COD_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"    05  W-DATA-PROPOSTA               PIC 9(008)  VALUE ZEROS.*/
                }
            }
            public IntBasis W_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-PROPOSTA.*/
            private _REDEF_VA0600B_FILLER_17 _filler_17 { get; set; }
            public _REDEF_VA0600B_FILLER_17 FILLER_17
            {
                get { _filler_17 = new _REDEF_VA0600B_FILLER_17(); _.Move(W_DATA_PROPOSTA, _filler_17); VarBasis.RedefinePassValue(W_DATA_PROPOSTA, _filler_17, W_DATA_PROPOSTA); _filler_17.ValueChanged += () => { _.Move(_filler_17, W_DATA_PROPOSTA); }; return _filler_17; }
                set { VarBasis.RedefinePassValue(value, _filler_17, W_DATA_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_17 : VarBasis
            {
                /*"        07  W-ANO-PROPOSTA            PIC 9(004).*/
                public IntBasis W_ANO_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-MES-PROPOSTA            PIC 9(002).*/
                public IntBasis W_MES_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-DIA-PROPOSTA            PIC 9(002).*/
                public IntBasis W_DIA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DATA-DDMMAAAA               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VA0600B_FILLER_17()
                {
                    W_ANO_PROPOSTA.ValueChanged += OnValueChanged;
                    W_MES_PROPOSTA.ValueChanged += OnValueChanged;
                    W_DIA_PROPOSTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-DDMMAAAA.*/
            private _REDEF_VA0600B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_VA0600B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_VA0600B_FILLER_18(); _.Move(W_DATA_DDMMAAAA, _filler_18); VarBasis.RedefinePassValue(W_DATA_DDMMAAAA, _filler_18, W_DATA_DDMMAAAA); _filler_18.ValueChanged += () => { _.Move(_filler_18, W_DATA_DDMMAAAA); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, W_DATA_DDMMAAAA); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_18 : VarBasis
            {
                /*"        07  W-DIA-DDMMAAAA            PIC 9(002).*/
                public IntBasis W_DIA_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-DDMMAAAA            PIC 9(002).*/
                public IntBasis W_MES_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-DDMMAAAA            PIC 9(004).*/
                public IntBasis W_ANO_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VA0600B_FILLER_18()
                {
                    W_DIA_DDMMAAAA.ValueChanged += OnValueChanged;
                    W_MES_DDMMAAAA.ValueChanged += OnValueChanged;
                    W_ANO_DDMMAAAA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_VA0600B_FILLER_19 _filler_19 { get; set; }
            public _REDEF_VA0600B_FILLER_19 FILLER_19
            {
                get { _filler_19 = new _REDEF_VA0600B_FILLER_19(); _.Move(W_DATA_NASCIMENTO, _filler_19); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_19, W_DATA_NASCIMENTO); _filler_19.ValueChanged += () => { _.Move(_filler_19, W_DATA_NASCIMENTO); }; return _filler_19; }
                set { VarBasis.RedefinePassValue(value, _filler_19, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_19 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_VA0600B_FILLER_19()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_VA0600B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_VA0600B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_VA0600B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_VA0600B_W_DTMOVABE1 : VarBasis
            {
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_VA0600B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_VA0600B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_VA0600B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_VA0600B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_VA0600B_W_DTMOVABE_I1 : VarBasis
            {
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_VA0600B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_VA0600B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_VA0600B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_VA0600B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_VA0600B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DATA-SITUACAO               PIC X(010).*/

                public _REDEF_VA0600B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SIT-RD REDEFINES W-DATA-SITUACAO.*/
            private _REDEF_VA0600B_W_DATA_SIT_RD _w_data_sit_rd { get; set; }
            public _REDEF_VA0600B_W_DATA_SIT_RD W_DATA_SIT_RD
            {
                get { _w_data_sit_rd = new _REDEF_VA0600B_W_DATA_SIT_RD(); _.Move(W_DATA_SITUACAO, _w_data_sit_rd); VarBasis.RedefinePassValue(W_DATA_SITUACAO, _w_data_sit_rd, W_DATA_SITUACAO); _w_data_sit_rd.ValueChanged += () => { _.Move(_w_data_sit_rd, W_DATA_SITUACAO); }; return _w_data_sit_rd; }
                set { VarBasis.RedefinePassValue(value, _w_data_sit_rd, W_DATA_SITUACAO); }
            }  //Redefines
            public class _REDEF_VA0600B_W_DATA_SIT_RD : VarBasis
            {
                /*"        07  W-DIA-SITUACAO            PIC 9(002).*/
                public IntBasis W_DIA_SITUACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SITUACAO            PIC 9(002).*/
                public IntBasis W_MES_SITUACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-SITUACAO            PIC 9(004).*/
                public IntBasis W_ANO_SITUACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05              DPARM01X.*/

                public _REDEF_VA0600B_W_DATA_SIT_RD()
                {
                    W_DIA_SITUACAO.ValueChanged += OnValueChanged;
                    W_BARRA1_2.ValueChanged += OnValueChanged;
                    W_MES_SITUACAO.ValueChanged += OnValueChanged;
                    W_BARRA2_2.ValueChanged += OnValueChanged;
                    W_ANO_SITUACAO.ValueChanged += OnValueChanged;
                }

            }
            public VA0600B_DPARM01X DPARM01X { get; set; } = new VA0600B_DPARM01X();
            public class VA0600B_DPARM01X : VarBasis
            {
                /*"      07            DPARM01           PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      07            DPARM01-R         REDEFINES   DPARM01.*/
                private _REDEF_VA0600B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VA0600B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VA0600B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VA0600B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1         PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2         PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3         PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4         PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5         PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6         PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7         PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8         PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9         PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10        PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      07            DPARM01-D1        PIC  9(001).*/

                    public _REDEF_VA0600B_DPARM01_R()
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
                /*"      07            DPARM01-RC        PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"01  WS-TIME.*/
            }
        }
        public VA0600B_WS_TIME WS_TIME { get; set; } = new VA0600B_WS_TIME();
        public class VA0600B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01  WABEND*/
        public VA0600B_WABEND WABEND { get; set; } = new VA0600B_WABEND();
        public class VA0600B_WABEND : VarBasis
        {
            /*"    05      FILLER.*/
            public VA0600B_FILLER_21 FILLER_21 { get; set; } = new VA0600B_FILLER_21();
            public class VA0600B_FILLER_21 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0600B  '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0600B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA0600B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0600B_LOCALIZA_ABEND_1();
            public class VA0600B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0600B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0600B_LOCALIZA_ABEND_2();
            public class VA0600B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05      WSQLERRO.*/
            }
            public VA0600B_WSQLERRO WSQLERRO { get; set; } = new VA0600B_WSQLERRO();
            public class VA0600B_WSQLERRO : VarBasis
            {
                /*"      10       FILLER                PIC  X(014) VALUE            ' *** SQLERRMC '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10    WSQLERRMC                PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01  WREA88.*/
            }
        }
        public VA0600B_WREA88 WREA88 { get; set; } = new VA0600B_WREA88();
        public class VA0600B_WREA88 : VarBasis
        {
            /*"    05  W-ORIGEM-PROPOSTA             PIC 9(004).*/

            public SelectorBasis W_ORIGEM_PROPOSTA { get; set; } = new SelectorBasis("004")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ORIGEM-SIGPF                             VALUE 01. */
							new SelectorItemBasis("ORIGEM_SIGPF", "01"),
							/*" 88 ORIGEM-CAIXA-PREV                        VALUE 02. */
							new SelectorItemBasis("ORIGEM_CAIXA_PREV", "02"),
							/*" 88 ORIGEM-SIGAT                             VALUE 03. */
							new SelectorItemBasis("ORIGEM_SIGAT", "03"),
							/*" 88 ORIGEM-SASSE                             VALUE 04. */
							new SelectorItemBasis("ORIGEM_SASSE", "04"),
							/*" 88 ORIGEM-CAIXA-CAP                         VALUE 05. */
							new SelectorItemBasis("ORIGEM_CAIXA_CAP", "05"),
							/*" 88 ORIGEM-MANUAL                            VALUE 06. */
							new SelectorItemBasis("ORIGEM_MANUAL", "06"),
							/*" 88 ORIGEM-REMOTA                            VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88 ORIGEM-INTRANET                          VALUE 08. */
							new SelectorItemBasis("ORIGEM_INTRANET", "08"),
							/*" 88 ORIGEM-INTERNET                          VALUE 09. */
							new SelectorItemBasis("ORIGEM_INTERNET", "09"),
							/*" 88 ORIGEM-CORRET-VIT                        VALUE 10. */
							new SelectorItemBasis("ORIGEM_CORRET_VIT", "10"),
							/*" 88 ORIGEM-FILIAL                            VALUE 11. */
							new SelectorItemBasis("ORIGEM_FILIAL", "11"),
							/*" 88 ORIGEM-MARSH                             VALUE 12. */
							new SelectorItemBasis("ORIGEM_MARSH", "12"),
							/*" 88 ORIGEM-LOTERICO                          VALUE 13. */
							new SelectorItemBasis("ORIGEM_LOTERICO", "13"),
							/*" 88 ORIGEM-CORRESPOND                        VALUE 14. */
							new SelectorItemBasis("ORIGEM_CORRESPOND", "14"),
							/*" 88 ORIGEM-AIC-PARC                          VALUE 23. */
							new SelectorItemBasis("ORIGEM_AIC_PARC", "23"),
							/*" 88 ORIGEM-AIC                               VALUE 1000. */
							new SelectorItemBasis("ORIGEM_AIC", "1000"),
							/*" 88 ORIGEM-AUTO-COMPRA-LOJA                  VALUE 1009. */
							new SelectorItemBasis("ORIGEM_AUTO_COMPRA_LOJA", "1009"),
							/*" 88 ORIGEM-AUTO-COMPRA-IBC                   VALUE 1010. */
							new SelectorItemBasis("ORIGEM_AUTO_COMPRA_IBC", "1010"),
							/*" 88 ORIGEM-AIC-PARC-CAMP                     VALUE 1018. */
							new SelectorItemBasis("ORIGEM_AIC_PARC_CAMP", "1018"),
							/*" 88 ORIGEM-AIC-PARC-ALGAR                    VALUE 1021. */
							new SelectorItemBasis("ORIGEM_AIC_PARC_ALGAR", "1021"),
							/*" 88 ORIGEM-AIC-WIZ                           VALUE 1022. */
							new SelectorItemBasis("ORIGEM_AIC_WIZ", "1022"),
							/*" 88 ORIGEM-AIC-ALMA-VIVA                     VALUE 1023. */
							new SelectorItemBasis("ORIGEM_AIC_ALMA_VIVA", "1023"),
							/*" 88 ORIGEM-AIC-AEC                           VALUE 1024. */
							new SelectorItemBasis("ORIGEM_AIC_AEC", "1024"),
							/*" 88 ORIGEM-AIC-SERCOM                        VALUE 1025. */
							new SelectorItemBasis("ORIGEM_AIC_SERCOM", "1025"),
							/*" 88 PARCERIAS-NOVO-JEITO-VENDER    VALUE 1021 THRU 1025. */
							new SelectorItemBasis("PARCERIAS_NOVO_JEITO_VENDER", "1021 THRU 1025")
                }
            };

            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA0600B_CANAL _canal { get; set; }
            public _REDEF_VA0600B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA0600B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0600B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-VENDA-SASSE                    VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR                 VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-ATM                      VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_ATM", "4"),
							/*" 88 CANAL-VENDA-GITEL                    VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET                 VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET                 VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_31 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VA0600B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_31.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA0600B_FAIXAS _faixas { get; set; }
            public _REDEF_VA0600B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_VA0600B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0600B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_32 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT-SUPER VALUE               845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT_SUPER", "845,846"),
							/*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850"),
							/*" 88 FAIXA-NUMERACAO-BILHETE    VALUE               823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_BILHETE", "823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-M-RISCO    VALUE               821, 823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_M_RISCO", "821,823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-SENIOR     VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_SENIOR", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-EXECUTIVO  VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_EXECUTIVO", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-AUTO       VALUE               828, 837, 847, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_AUTO", "828,837,847,845,846")
                }
                };

                /*"        07  FILLER                    PIC 9(008).*/
                public IntBasis FILLER_33 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05  FILLER  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VA0600B_FAIXAS()
                {
                    FILLER_32.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    FILLER_33.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA0600B_FILLER_34 _filler_34 { get; set; }
            public _REDEF_VA0600B_FILLER_34 FILLER_34
            {
                get { _filler_34 = new _REDEF_VA0600B_FILLER_34(); _.Move(W_NUM_PROPOSTA, _filler_34); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_34, W_NUM_PROPOSTA); _filler_34.ValueChanged += () => { _.Move(_filler_34, W_NUM_PROPOSTA); }; return _filler_34; }
                set { VarBasis.RedefinePassValue(value, _filler_34, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0600B_FILLER_34 : VarBasis
            {
                /*"        07  FILLER                    PIC 9(005).*/
                public IntBasis FILLER_35 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"        07  PRP-AUTO                  PIC 9(002).*/

                public SelectorBasis PRP_AUTO { get; set; } = new SelectorBasis("002")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-AUTOMOVEL      VALUE               30, 31, 32, 34, 35, 37, 39, 40, 41. */
							new SelectorItemBasis("PROPOSTA_AUTOMOVEL", "30,31,32,34,35,37,39,40,41")
                }
                };

                /*"        07  FILLER                    PIC 9(007).*/
                public IntBasis FILLER_36 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    05 W-LEITURA-CBO                  PIC  9(001) VALUE ZERO.*/

                public _REDEF_VA0600B_FILLER_34()
                {
                    FILLER_35.ValueChanged += OnValueChanged;
                    PRP_AUTO.ValueChanged += OnValueChanged;
                    FILLER_36.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_LEITURA_CBO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CBO-ENCONTRADO                          VALUE 1. */
							new SelectorItemBasis("CBO_ENCONTRADO", "1"),
							/*" 88 CBO-NAO-ENCONTRADO                      VALUE 2. */
							new SelectorItemBasis("CBO_NAO_ENCONTRADO", "2")
                }
            };

            /*"    05 W-LEITURA-SICOB                PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LEITURA_SICOB { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SICOB-JA-CADASTRADO                     VALUE 1. */
							new SelectorItemBasis("SICOB_JA_CADASTRADO", "1"),
							/*" 88 SICOB-NAO-CADASTRADO                    VALUE 2. */
							new SelectorItemBasis("SICOB_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-CONVENIO                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CONVENIO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 DEMAIS-CONVENIOS                        VALUE 1. */
							new SelectorItemBasis("DEMAIS_CONVENIOS", "1"),
							/*" 88 CONVENIO-VERA-CRUZ                      VALUE 2. */
							new SelectorItemBasis("CONVENIO_VERA_CRUZ", "2"),
							/*" 88 CONVENIO-CCA                            VALUE 3. */
							new SelectorItemBasis("CONVENIO_CCA", "3")
                }
            };

            /*"    05 W-GEROU-MOVTO-CEF              PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_GEROU_MOVTO_CEF { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 GEROU-MOVTO-CEF                         VALUE 1. */
							new SelectorItemBasis("GEROU_MOVTO_CEF", "1")
                }
            };

            /*"    05 W-LEITURA-RCAP                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LEITURA_RCAP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU-RCAP                          VALUE 1. */
							new SelectorItemBasis("ENCONTROU_RCAP", "1"),
							/*" 88 NAO-ENCONTROU-RCAP                      VALUE 2. */
							new SelectorItemBasis("NAO_ENCONTROU_RCAP", "2")
                }
            };

            /*"    05 W-LEITURA-RCAPCOMP             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LEITURA_RCAPCOMP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU-RCAPCOMP                      VALUE 1. */
							new SelectorItemBasis("ENCONTROU_RCAPCOMP", "1"),
							/*" 88 NAO-ENCONTROU-RCAPCOMP                  VALUE 2. */
							new SelectorItemBasis("NAO_ENCONTROU_RCAPCOMP", "2")
                }
            };

            /*"    05 W-COD-EMPRESA                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_COD_EMPRESA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SASSE                                   VALUE 1. */
							new SelectorItemBasis("SASSE", "1"),
							/*" 88 CAIXA-PREVIDENCIA                       VALUE 2. */
							new SelectorItemBasis("CAIXA_PREVIDENCIA", "2"),
							/*" 88 CAIXA-CAPITALIZACAO                     VALUE 3. */
							new SelectorItemBasis("CAIXA_CAPITALIZACAO", "3")
                }
            };

            /*"    05 W-RELACIONAMENTO               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RELACIONAMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SEGURO-VIDA                             VALUE 1. */
							new SelectorItemBasis("SEGURO_VIDA", "1"),
							/*" 88 CAPITALIZACAO                           VALUE 2. */
							new SelectorItemBasis("CAPITALIZACAO", "2"),
							/*" 88 PREVIDENCIA                             VALUE 3. */
							new SelectorItemBasis("PREVIDENCIA", "3"),
							/*" 88 BILHETE-R                               VALUE 4. */
							new SelectorItemBasis("BILHETE_R", "4"),
							/*" 88 AUTOMOVEIS                              VALUE 5. */
							new SelectorItemBasis("AUTOMOVEIS", "5"),
							/*" 88 MULTIRISCO                              VALUE 6. */
							new SelectorItemBasis("MULTIRISCO", "6"),
							/*" 88 CONSORCIO                               VALUE 7. */
							new SelectorItemBasis("CONSORCIO", "7"),
							/*" 88 SEGURO-CREDITO                          VALUE 8. */
							new SelectorItemBasis("SEGURO_CREDITO", "8")
                }
            };

            /*"    05       N88-CORRIGE-PF     PIC  X(001)    VALUE '*'.*/

            public SelectorBasis N88_CORRIGE_PF { get; set; } = new SelectorBasis("001", "*")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88      CORRIGE-PF                        VALUE 'S'. */
							new SelectorItemBasis("CORRIGE_PF", "S")
                }
            };

            /*"    05       N88-MATRIZ         PIC  X(001)    VALUE '*'.*/

            public SelectorBasis N88_MATRIZ { get; set; } = new SelectorBasis("001", "*")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88      COM-MATRIZ                        VALUE 'S'. */
							new SelectorItemBasis("COM_MATRIZ", "S"),
							/*" 88      SEM-MATRIZ                        VALUE 'N'. */
							new SelectorItemBasis("SEM_MATRIZ", "N")
                }
            };

            /*"    05       W-AIC-TIPO-ASSIST.*/
            public VA0600B_W_AIC_TIPO_ASSIST W_AIC_TIPO_ASSIST { get; set; } = new VA0600B_W_AIC_TIPO_ASSIST();
            public class VA0600B_W_AIC_TIPO_ASSIST : VarBasis
            {
                /*"     07      FILLER             PIC  X(002).*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"     07      W-COD-TIPO-ASSIST  PIC  9(002).*/
                public IntBasis W_COD_TIPO_ASSIST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       N88-TIPO-MATRIZ    PIC  X(015)    VALUE ALL '*'.*/
            }

            public SelectorBasis N88_TIPO_MATRIZ { get; set; } = new SelectorBasis("015", "ALL *")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88      AGRAVO                            VALUE 'AGRAVO'. */
							new SelectorItemBasis("AGRAVO", "AGRAVO"),
							/*" 88      DESCONTO                          VALUE 'DESCONTO'. */
							new SelectorItemBasis("DESCONTO", "DESCONTO")
                }
            };

            /*"    05       N88-ERRO-MATRIZ    PIC  X(001)    VALUE ALL '*'.*/

            public SelectorBasis N88_ERRO_MATRIZ { get; set; } = new SelectorBasis("001", "ALL *")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88      ERRO-MATRIZ                       VALUE 'S'. */
							new SelectorItemBasis("ERRO_MATRIZ", "S")
                }
            };

            /*"    05 W-POSSUI-PLANO                PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_POSSUI_PLANO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 POSSUI-PLANO                           VALUE 1. */
							new SelectorItemBasis("POSSUI_PLANO", "1")
                }
            };

            /*"    05 W-TP-MOVIMENTO                 PIC  9(002) VALUE ZEROS.*/

            public SelectorBasis W_TP_MOVIMENTO { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 MOVTO-CEF-SIGAT                         VALUE 1. */
							new SelectorItemBasis("MOVTO_CEF_SIGAT", "1"),
							/*" 88 MOVTO-SIVPF-FILIAL                      VALUE 2. */
							new SelectorItemBasis("MOVTO_SIVPF_FILIAL", "2"),
							/*" 88 MOVTO-AIC                               VALUE 3. */
							new SelectorItemBasis("MOVTO_AIC", "3"),
							/*" 88 MOVTO-AUTO-COMPRA                       VALUE 4. */
							new SelectorItemBasis("MOVTO_AUTO_COMPRA", "4")
                }
            };

            /*"    05 W-TP-REGISTRO                  PIC  X(001) VALUE SPACES.*/

            public SelectorBasis W_TP_REGISTRO { get; set; } = new SelectorBasis("001", "SPACES")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TPREG-HEADER                            VALUE 'H'. */
							new SelectorItemBasis("TPREG_HEADER", "H"),
							/*" 88 TPREG-TRAILLER                          VALUE 'T'. */
							new SelectorItemBasis("TPREG_TRAILLER", "T"),
							/*" 88 TPREG-PGTO-AVULSO                       VALUE '0'. */
							new SelectorItemBasis("TPREG_PGTO_AVULSO", "0"),
							/*" 88 TPREG-CLIENTE                           VALUE '1'. */
							new SelectorItemBasis("TPREG_CLIENTE", "1"),
							/*" 88 TPREG-ENDERECO                          VALUE '2'. */
							new SelectorItemBasis("TPREG_ENDERECO", "2"),
							/*" 88 TPREG-PROPOSTA                          VALUE '3'. */
							new SelectorItemBasis("TPREG_PROPOSTA", "3"),
							/*" 88 TPREG-BENEFICIARIO                      VALUE '4'. */
							new SelectorItemBasis("TPREG_BENEFICIARIO", "4"),
							/*" 88 TPREG-DADOS-AUTO                        VALUE '4'. */
							new SelectorItemBasis("TPREG_DADOS_AUTO", "4"),
							/*" 88 TPREG-INFO-COMPLEMENTAR                 VALUE '5'. */
							new SelectorItemBasis("TPREG_INFO_COMPLEMENTAR", "5"),
							/*" 88 TPREG-REGISTRO-DIVERSOS                 VALUE '6'. */
							new SelectorItemBasis("TPREG_REGISTRO_DIVERSOS", "6"),
							/*" 88 TPREG-TIPO-B                            VALUE 'B'. */
							new SelectorItemBasis("TPREG_TIPO_B", "B"),
							/*" 88 TPREG-TIPO-C                            VALUE 'C'. */
							new SelectorItemBasis("TPREG_TIPO_C", "C"),
							/*" 88 TPREG-TIPO-D                            VALUE 'D'. */
							new SelectorItemBasis("TPREG_TIPO_D", "D"),
							/*" 88 TPREG-TIPO-W                            VALUE 'W'. */
							new SelectorItemBasis("TPREG_TIPO_W", "W")
                }
            };

            /*"    05 W-PRP-REMOTO                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_PRP_REMOTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 W-EXISTE-PRP-REMOTO                     VALUE 1. */
							new SelectorItemBasis("W_EXISTE_PRP_REMOTO", "1")
                }
            };

            /*"    05 W-MOVTO-AUTO                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_MOVTO_AUTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-MOVTO-AUTO                       VALUE 1. */
							new SelectorItemBasis("EXISTE_MOVTO_AUTO", "1")
                }
            };

            /*"    05 W-MOVTO-RISCO                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_MOVTO_RISCO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-MOVTO-RISCO                      VALUE 1. */
							new SelectorItemBasis("EXISTE_MOVTO_RISCO", "1")
                }
            };

            /*"    05 W-MOVTO-VDEMP                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_MOVTO_VDEMP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-MOVTO-VDEMP                      VALUE 1. */
							new SelectorItemBasis("EXISTE_MOVTO_VDEMP", "1")
                }
            };

            /*"    05 W-MOVTO-PEXEC                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_MOVTO_PEXEC { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-MOVTO-PEXEC                      VALUE 1. */
							new SelectorItemBasis("EXISTE_MOVTO_PEXEC", "1")
                }
            };

            /*"    05 W-CRITICA-PROPOSTA             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CRITICA_PROPOSTA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-SEM-CRITICA                    VALUE 1. */
							new SelectorItemBasis("PROPOSTA_SEM_CRITICA", "1"),
							/*" 88 PROPOSTA-COM-CRITICA                    VALUE 2. */
							new SelectorItemBasis("PROPOSTA_COM_CRITICA", "2")
                }
            };

            /*"    05 W-HEADER-AUTO                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HEADER_AUTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HDAUTO-NAO-GERADO                       VALUE 1. */
							new SelectorItemBasis("HDAUTO_NAO_GERADO", "1"),
							/*" 88 HDAUTO-FOI-GERADO                       VALUE 2. */
							new SelectorItemBasis("HDAUTO_FOI_GERADO", "2")
                }
            };

            /*"    05 W-HEADER-RISCO                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HEADER_RISCO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HDRISCO-NAO-GERADO                      VALUE 1. */
							new SelectorItemBasis("HDRISCO_NAO_GERADO", "1"),
							/*" 88 HDRISCO-FOI-GERADO                      VALUE 2. */
							new SelectorItemBasis("HDRISCO_FOI_GERADO", "2")
                }
            };

            /*"    05 W-HEADER-VDEMP                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HEADER_VDEMP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HDVDEMP-NAO-GERADO                      VALUE 1. */
							new SelectorItemBasis("HDVDEMP_NAO_GERADO", "1"),
							/*" 88 HDVDEMP-FOI-GERADO                      VALUE 2. */
							new SelectorItemBasis("HDVDEMP_FOI_GERADO", "2")
                }
            };

            /*"    05 W-HEADER-PRP-FILIAL            PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HEADER_PRP_FILIAL { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HDFIL-NAO-GERADO                        VALUE 1. */
							new SelectorItemBasis("HDFIL_NAO_GERADO", "1"),
							/*" 88 HDFIL-FOI-GERADO                        VALUE 2. */
							new SelectorItemBasis("HDFIL_FOI_GERADO", "2")
                }
            };

            /*"    05 W-VERSAO-SIGAT                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_VERSAO_SIGAT { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 VERSAO-SIGAT-NOVA                       VALUE 1. */
							new SelectorItemBasis("VERSAO_SIGAT_NOVA", "1"),
							/*" 88 VERSAO-SIGAT-ANTERIOR                   VALUE 2. */
							new SelectorItemBasis("VERSAO_SIGAT_ANTERIOR", "2")
                }
            };

            /*"    05 W-PERI-PGTO                    PIC  9(002) VALUE ZEROS.*/

            public SelectorBasis W_PERI_PGTO { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PAGAMENTO-MENSAL                        VALUE 1. */
							new SelectorItemBasis("PAGAMENTO_MENSAL", "1"),
							/*" 88 PAGAMENTO-ANUAL                         VALUE 12. */
							new SelectorItemBasis("PAGAMENTO_ANUAL", "12"),
							/*" 88 PAGAMENTO-UNICO                         VALUE 36. */
							new SelectorItemBasis("PAGAMENTO_UNICO", "36")
                }
            };

            /*"    05 W-CONJUGE                      PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CONJUGE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CONJUGE-OPCIONAL                        VALUE 1. */
							new SelectorItemBasis("CONJUGE_OPCIONAL", "1"),
							/*" 88 SEM-CONJUGE                             VALUE 3. */
							new SelectorItemBasis("SEM_CONJUGE", "3")
                }
            };

            /*"01              LC00.*/
        }
        public VA0600B_LC00 LC00 { get; set; } = new VA0600B_LC00();
        public class VA0600B_LC00 : VarBasis
        {
            /*"    05            LC01.*/
            public VA0600B_LC01 LC01 { get; set; } = new VA0600B_LC01();
            public class VA0600B_LC01 : VarBasis
            {
                /*"      10          LC01-RELATORIO  PIC  X(008) VALUE 'RVA0600B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"RVA0600B");
                /*"      10          FILLER          PIC  X(033) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"      10          FILLER          PIC  X(050) VALUE      'C A I X A    V I D A    E    P R E V I D E N C I A'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"C A I X A    V I D A    E    P R E V I D E N C I A");
                /*"      10          FILLER          PIC  X(022) VALUE  SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"      10          FILLER          PIC  X(008) VALUE 'PAGINA: '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PAGINA: ");
                /*"      10          LC01-PAGINA     PIC  9(04).*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05            LC02.*/
            }
            public VA0600B_LC02 LC02 { get; set; } = new VA0600B_LC02();
            public class VA0600B_LC02 : VarBasis
            {
                /*"      10          FILLER          PIC  X(113) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "113", "X(113)"), @"");
                /*"      10          FILLER          PIC  X(008) VALUE 'DATA..: '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DATA..: ");
                /*"      10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05            LC03.*/
            }
            public VA0600B_LC03 LC03 { get; set; } = new VA0600B_LC03();
            public class VA0600B_LC03 : VarBasis
            {
                /*"      10          FILLER          PIC  X(035) VALUE  SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"      10          FILLER          PIC  X(056) VALUE      'RELATORIO DE CRITICAS DO MOVIMENTO DE PROPOSTAS SIVPF - '*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"RELATORIO DE CRITICAS DO MOVIMENTO DE PROPOSTAS SIVPF - ");
                /*"      10          LC03-CANAL      PIC  X(013) VALUE  SPACES.*/
                public StringBasis LC03_CANAL { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10          FILLER          PIC  X(009) VALUE  SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10          FILLER          PIC  X(008) VALUE 'HORA..: '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HORA..: ");
                /*"      10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    05            LC04.*/
            }
            public VA0600B_LC04 LC04 { get; set; } = new VA0600B_LC04();
            public class VA0600B_LC04 : VarBasis
            {
                /*"      10          FILLER            PIC  X(020) VALUE                 'ARQUIVO PROCESSADO: '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ARQUIVO PROCESSADO: ");
                /*"      10          LC04-NSAS-SIVPF   PIC  ZZZZZ9.*/
                public IntBasis LC04_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10          FILLER            PIC  X(013) VALUE                 ' - GERADO EM '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" - GERADO EM ");
                /*"      10          LC04-DATA-GERACAO PIC  X(010).*/
                public StringBasis LC04_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"      10          FILLER            PIC  X(082) VALUE  SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "82", "X(082)"), @"");
                /*"    05            LC05.*/
            }
            public VA0600B_LC05 LC05 { get; set; } = new VA0600B_LC05();
            public class VA0600B_LC05 : VarBasis
            {
                /*"      10          FILLER            PIC  X(013) VALUE                 '    PROPOSTA '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"    PROPOSTA ");
                /*"      10          FILLER            PIC  X(017) VALUE                 '       ORIGEM    '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"       ORIGEM    ");
                /*"      10          FILLER            PIC  X(015) VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"      10          FILLER            PIC  X(009) VALUE                 ' SITUACAO'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SITUACAO");
                /*"      10          FILLER            PIC  X(008) VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"      10          FILLER            PIC  X(013) VALUE                 'DATA SITUACAO'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"DATA SITUACAO");
                /*"      10          FILLER            PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10          FILLER            PIC  X(027) VALUE                 'DESCRICAO DA INCONSISTENCIA'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"DESCRICAO DA INCONSISTENCIA");
                /*"    05            LC06.*/
            }
            public VA0600B_LC06 LC06 { get; set; } = new VA0600B_LC06();
            public class VA0600B_LC06 : VarBasis
            {
                /*"      10          FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10          LC06-NUM-PROPOSTA   PIC  9(014).*/
                public IntBasis LC06_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10          FILLER              PIC  X(005) VALUE  SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LC06-ORIGEM         PIC  X(021).*/
                public StringBasis LC06_ORIGEM { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
                /*"      10          FILLER              PIC  X(007) VALUE  SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10          LC06-SITUACAO       PIC  X(003).*/
                public StringBasis LC06_SITUACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10          FILLER              PIC  X(012) VALUE  SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"      10          LC06-DATA-SITUACAO  PIC  X(010).*/
                public StringBasis LC06_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"      10          FILLER              PIC  X(006) VALUE  SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LC06-DESCRICAO      PIC  X(049).*/
                public StringBasis LC06_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
                /*"    05            LC07.*/
            }
            public VA0600B_LC07 LC07 { get; set; } = new VA0600B_LC07();
            public class VA0600B_LC07 : VarBasis
            {
                /*"      10          FILLER          PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"01  AREA-DAS-TABELAS.*/
            }
        }
        public VA0600B_AREA_DAS_TABELAS AREA_DAS_TABELAS { get; set; } = new VA0600B_AREA_DAS_TABELAS();
        public class VA0600B_AREA_DAS_TABELAS : VarBasis
        {
            /*"    05 W-TAB-CONSISTENCIA.*/
            public VA0600B_W_TAB_CONSISTENCIA W_TAB_CONSISTENCIA { get; set; } = new VA0600B_W_TAB_CONSISTENCIA();
            public class VA0600B_W_TAB_CONSISTENCIA : VarBasis
            {
                /*"       10 FILLER  OCCURS 2000 TIMES.*/
                public ListBasis<VA0600B_FILLER_65> FILLER_65 { get; set; } = new ListBasis<VA0600B_FILLER_65>(2000);
                public class VA0600B_FILLER_65 : VarBasis
                {
                    /*"          15 W-TB-CANAL        PIC  9(002).*/
                    public IntBasis W_TB_CANAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"          15 W-TB-NSAS         PIC  9(006).*/
                    public IntBasis W_TB_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"          15 W-TB-ORIGEM       PIC  9(002).*/
                    public IntBasis W_TB_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"          15 W-TB-NUM-PROPOSTA PIC  9(014).*/
                    public IntBasis W_TB_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"          15 W-TB-SIT-PROPOSTA PIC  X(003).*/
                    public StringBasis W_TB_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"          15 W-TB-DT-SITUACAO  PIC  9(008).*/
                    public IntBasis W_TB_DT_SITUACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"          15 W-TB-COD-DESCRI   PIC  9(002).*/
                    public IntBasis W_TB_COD_DESCRI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05 W-TAB-DESCRICAO.*/
                }
            }
            public VA0600B_W_TAB_DESCRICAO W_TAB_DESCRICAO { get; set; } = new VA0600B_W_TAB_DESCRICAO();
            public class VA0600B_W_TAB_DESCRICAO : VarBasis
            {
                /*"       10 FILLER               PIC  X(050)     VALUE          '01ORIGEM DA PROPOSTA NAO ESPERADA                 '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"01ORIGEM DA PROPOSTA NAO ESPERADA                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '02SICOB JA UTILIZADO EM OUTRA PROPOSTA            '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"02SICOB JA UTILIZADO EM OUTRA PROPOSTA            ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '03SICOB NAO CADASTRADO                            '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"03SICOB NAO CADASTRADO                            ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '04PROPOSTA EM DUPLICIDADE, JA CADASTRADA NO SIAS  '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"04PROPOSTA EM DUPLICIDADE, JA CADASTRADA NO SIAS  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '05RCAP JA BAIXADO EM OUTRA PROPOSTA               '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"05RCAP JA BAIXADO EM OUTRA PROPOSTA               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '06CANAL DE VENDA DA PROPOSTA NAO ESPERADO         '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"06CANAL DE VENDA DA PROPOSTA NAO ESPERADO         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '07NUMERO DA PROPOSTA INVALIDO                     '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"07NUMERO DA PROPOSTA INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '08PROPOSTA FORA DA FAIXA DE NUMERACAO DO PRODUTO  '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"08PROPOSTA FORA DA FAIXA DE NUMERACAO DO PRODUTO  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '09RCAP CANCELADO                                  '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"09RCAP CANCELADO                                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '10PROPOSTA DE SEGURO JA CADASTRADA NO SIAS        '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"10PROPOSTA DE SEGURO JA CADASTRADA NO SIAS        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '11PROPOSTA DE BILHETE JA CADASTRADA NO SIAS       '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"11PROPOSTA DE BILHETE JA CADASTRADA NO SIAS       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '12PROPOSTA ELETRONICA CEF, DIGITADA NA FILIAL     '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"12PROPOSTA ELETRONICA CEF, DIGITADA NA FILIAL     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '13OPCAO CONJUGE NAO INFORMADA, OU, DIFERE DE S/N  '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"13OPCAO CONJUGE NAO INFORMADA, OU, DIFERE DE S/N  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '14PROPOSTA REFORMULACAO VIDA DA GENTE             '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"14PROPOSTA REFORMULACAO VIDA DA GENTE             ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '15PERIODICIDADE DE PAGAMENTO INVALIDA             '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"15PERIODICIDADE DE PAGAMENTO INVALIDA             ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '16PROPOSTA COM ERRO NA MATRIZ                     '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"16PROPOSTA COM ERRO NA MATRIZ                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '17VALOR PAGO SICOB ZERADO                         '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"17VALOR PAGO SICOB ZERADO                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '18PRODUTO NAO ESPERADO                            '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"18PRODUTO NAO ESPERADO                            ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '19TIPO DE ASSISTENCIA INCORRETO                   '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"19TIPO DE ASSISTENCIA INCORRETO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '20PLANO COMERCIALIZADO NAO ENCONTRADO             '.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"20PLANO COMERCIALIZADO NAO ENCONTRADO             ");
                /*"    05 W-TAB-DESCRICAO-RD  REDEFINES W-TAB-DESCRICAO                              OCCURS 18.*/
            }
            private ListBasis<_REDEF_VA0600B_W_TAB_DESCRICAO_RD> _w_tab_descricao_rd { get; set; }
            public ListBasis<_REDEF_VA0600B_W_TAB_DESCRICAO_RD> W_TAB_DESCRICAO_RD
            {
                get { _w_tab_descricao_rd = new ListBasis<_REDEF_VA0600B_W_TAB_DESCRICAO_RD>(18); _.Move(W_TAB_DESCRICAO, _w_tab_descricao_rd); VarBasis.RedefinePassValue(W_TAB_DESCRICAO, _w_tab_descricao_rd, W_TAB_DESCRICAO); _w_tab_descricao_rd.ValueChanged += () => { _.Move(_w_tab_descricao_rd, W_TAB_DESCRICAO); }; return _w_tab_descricao_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_descricao_rd, W_TAB_DESCRICAO); }
            }  //Redefines
            public class _REDEF_VA0600B_W_TAB_DESCRICAO_RD : VarBasis
            {
                /*"       10 W-TB-CODIGO       PIC  9(002).*/
                public IntBasis W_TB_CODIGO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-ERRO  PIC  X(048).*/
                public StringBasis W_TB_DESCRI_ERRO { get; set; } = new StringBasis(new PIC("X", "48", "X(048)."), @"");
                /*"    05 W-TAB-CANAL.*/

                public _REDEF_VA0600B_W_TAB_DESCRICAO_RD()
                {
                    W_TB_CODIGO.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_ERRO.ValueChanged += OnValueChanged;
                }

            }
            public VA0600B_W_TAB_CANAL W_TAB_CANAL { get; set; } = new VA0600B_W_TAB_CANAL();
            public class VA0600B_W_TAB_CANAL : VarBasis
            {
                /*"       10 FILLER               PIC  X(015)     VALUE          '01CAIXA    '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"01CAIXA    ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '02CAIXA SEGUROS'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"02CAIXA SEGUROS");
                /*"       10 FILLER               PIC  X(015)     VALUE          '03CORRETOR '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"03CORRETOR ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '04ATM      '.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"04ATM      ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '05GITEL    '.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"05GITEL    ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '07INTERNET '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"07INTERNET ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '08INTRANET '.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"08INTRANET ");
                /*"    05 W-TAB-CANAL-RD      REDEFINES W-TAB-CANAL                           OCCURS 7.*/
            }
            private ListBasis<_REDEF_VA0600B_W_TAB_CANAL_RD> _w_tab_canal_rd { get; set; }
            public ListBasis<_REDEF_VA0600B_W_TAB_CANAL_RD> W_TAB_CANAL_RD
            {
                get { _w_tab_canal_rd = new ListBasis<_REDEF_VA0600B_W_TAB_CANAL_RD>(7); _.Move(W_TAB_CANAL, _w_tab_canal_rd); VarBasis.RedefinePassValue(W_TAB_CANAL, _w_tab_canal_rd, W_TAB_CANAL); _w_tab_canal_rd.ValueChanged += () => { _.Move(_w_tab_canal_rd, W_TAB_CANAL); }; return _w_tab_canal_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_canal_rd, W_TAB_CANAL); }
            }  //Redefines
            public class _REDEF_VA0600B_W_TAB_CANAL_RD : VarBasis
            {
                /*"       10 W-TB-COD-CANAL    PIC  9(002).*/
                public IntBasis W_TB_COD_CANAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-CANAL PIC  X(013).*/
                public StringBasis W_TB_DESCRI_CANAL { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05 W-TAB-ORIGEM.*/

                public _REDEF_VA0600B_W_TAB_CANAL_RD()
                {
                    W_TB_COD_CANAL.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_CANAL.ValueChanged += OnValueChanged;
                }

            }
            public VA0600B_W_TAB_ORIGEM W_TAB_ORIGEM { get; set; } = new VA0600B_W_TAB_ORIGEM();
            public class VA0600B_W_TAB_ORIGEM : VarBasis
            {
                /*"       10 FILLER               PIC  X(023)     VALUE          '01SIGPF                '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"01SIGPF                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '02CAIXA&PREVIDENCIA    '.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"02CAIXA&PREVIDENCIA    ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '03SIGAT                '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"03SIGAT                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '04SASSE                '.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"04SASSE                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '05CAIXA&CAPITALIZACAO  '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"05CAIXA&CAPITALIZACAO  ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '06MANUAL               '.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"06MANUAL               ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '07VENDAS REMOTAS       '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"07VENDAS REMOTAS       ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '08INTRANET'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"08INTRANET");
                /*"       10 FILLER               PIC  X(023)     VALUE          '09INTERNET             '.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"09INTERNET             ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '97REMOTA FILIAL        '.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"97REMOTA FILIAL        ");
                /*"    05 W-TAB-ORIGEM-RD      REDEFINES W-TAB-ORIGEM                           OCCURS 10.*/
            }
            private ListBasis<_REDEF_VA0600B_W_TAB_ORIGEM_RD> _w_tab_origem_rd { get; set; }
            public ListBasis<_REDEF_VA0600B_W_TAB_ORIGEM_RD> W_TAB_ORIGEM_RD
            {
                get { _w_tab_origem_rd = new ListBasis<_REDEF_VA0600B_W_TAB_ORIGEM_RD>(10); _.Move(W_TAB_ORIGEM, _w_tab_origem_rd); VarBasis.RedefinePassValue(W_TAB_ORIGEM, _w_tab_origem_rd, W_TAB_ORIGEM); _w_tab_origem_rd.ValueChanged += () => { _.Move(_w_tab_origem_rd, W_TAB_ORIGEM); }; return _w_tab_origem_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_origem_rd, W_TAB_ORIGEM); }
            }  //Redefines
            public class _REDEF_VA0600B_W_TAB_ORIGEM_RD : VarBasis
            {
                /*"       10 W-TB-COD-ORIGEM     PIC  9(002).*/
                public IntBasis W_TB_COD_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-ORIGEM  PIC  X(021).*/
                public StringBasis W_TB_DESCRI_ORIGEM { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
                /*"01  WSRC-INF-SICAQWEB.*/

                public _REDEF_VA0600B_W_TAB_ORIGEM_RD()
                {
                    W_TB_COD_ORIGEM.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_ORIGEM.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA0600B_WSRC_INF_SICAQWEB WSRC_INF_SICAQWEB { get; set; } = new VA0600B_WSRC_INF_SICAQWEB();
        public class VA0600B_WSRC_INF_SICAQWEB : VarBasis
        {
            /*"    05  WSRC-NUM-OPERADOR            PIC X(009).*/
            public StringBasis WSRC_NUM_OPERADOR { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"    05  WSRC-NUM-CORRESPONDENTE      PIC 9(009).*/
            public IntBasis WSRC_NUM_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  WSRC-DATA-CONTRATACAO        PIC 9(008).*/
            public IntBasis WSRC_DATA_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  WSRC-HORA-CONTRATACAO        PIC 9(006).*/
            public IntBasis WSRC_HORA_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  WSRC-NRO-PROPOSTA-SICAQ      PIC 9(010).*/
            public IntBasis WSRC_NRO_PROPOSTA_SICAQ { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05  WSRC-TIPO-CORRESPONDENTE     PIC 9(002).*/
            public IntBasis WSRC_TIPO_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  WSRC-ORIGEM-PROPOSTA         PIC X(005).*/
            public StringBasis WSRC_ORIGEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"    05  FILLER                       PIC X(206).*/
            public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "206", "X(206)."), @"");
        }


        public Copies.LBFPF990 LBFPF990 { get; set; } = new Copies.LBFPF990();
        public Copies.LBFPF000 LBFPF000 { get; set; } = new Copies.LBFPF000();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LBFPF014 LBFPF014 { get; set; } = new Copies.LBFPF014();
        public Copies.LBFPF015 LBFPF015 { get; set; } = new Copies.LBFPF015();
        public Copies.LBFPF016 LBFPF016 { get; set; } = new Copies.LBFPF016();
        public Copies.LBFPF161 LBFPF161 { get; set; } = new Copies.LBFPF161();
        public Copies.LBFPF162 LBFPF162 { get; set; } = new Copies.LBFPF162();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LXFPF003 LXFPF003 { get; set; } = new Copies.LXFPF003();
        public Copies.LXFPF004 LXFPF004 { get; set; } = new Copies.LXFPF004();
        public Copies.LXFPF024 LXFPF024 { get; set; } = new Copies.LXFPF024();
        public Copies.LXFPF027 LXFPF027 { get; set; } = new Copies.LXFPF027();
        public Copies.LXFPF028 LXFPF028 { get; set; } = new Copies.LXFPF028();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LBFPF026 LBFPF026 { get; set; } = new Copies.LBFPF026();
        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Copies.LBFPF164 LBFPF164 { get; set; } = new Copies.LBFPF164();
        public Copies.BIEMPCOM BIEMPCOM { get; set; } = new Copies.BIEMPCOM();
        public Copies.SPGE053W SPGE053W { get; set; } = new Copies.SPGE053W();
        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.PFACOPRO PFACOPRO { get; set; } = new Dclgens.PFACOPRO();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.COVSICOB COVSICOB { get; set; } = new Dclgens.COVSICOB();
        public Dclgens.ESCNEG ESCNEG { get; set; } = new Dclgens.ESCNEG();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPSSBI PROPSSBI { get; set; } = new Dclgens.PROPSSBI();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROFIDCO PROFIDCO { get; set; } = new Dclgens.PROFIDCO();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.TPRELAC TPRELAC { get; set; } = new Dclgens.TPRELAC();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.TPENDER TPENDER { get; set; } = new Dclgens.TPENDER();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.BENPROPZ BENPROPZ { get; set; } = new Dclgens.BENPROPZ();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.GETPMOIM GETPMOIM { get; set; } = new Dclgens.GETPMOIM();
        public Dclgens.GE372 GE372 { get; set; } = new Dclgens.GE372();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.GE406 GE406 { get; set; } = new Dclgens.GE406();
        public Dclgens.VG130 VG130 { get; set; } = new Dclgens.VG130();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA0600B_EMAIL EMAIL { get; set; } = new VA0600B_EMAIL();
        public VA0600B_ENDERECOS ENDERECOS { get; set; } = new VA0600B_ENDERECOS();
        public VA0600B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new VA0600B_FUNDOCOMISVA();
        public VA0600B_CFONTES CFONTES { get; set; } = new VA0600B_CFONTES();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_SIGAT_FILE_NAME_P, string MOV_VDEMP_FILE_NAME_P, string RVA0600B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_SIGAT.SetFile(MOV_SIGAT_FILE_NAME_P);
                MOV_VDEMP.SetFile(MOV_VDEMP_FILE_NAME_P);
                RVA0600B.SetFile(RVA0600B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -2323- DISPLAY ' ' */
            _.Display($" ");

            /*" -2325- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -2333- DISPLAY 'PROGRAMA EM EXECUCAO VA0600B - ' 'VERSAO V.116 - DEMANDA: 571983 / RITM0004370 ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VA0600B - VERSAO V.116 - DEMANDA: 571983 / RITM0004370 FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -2335- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -2337- DISPLAY ' ' */
            _.Display($" ");

            /*" -2338- MOVE 'VA0600B' TO LK-GEJVW002-NOM-PROG-ORIGEM */
            _.Move("VA0600B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -2339- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -2339- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WS_JV1_PROGRAMA);

            /*" -2340- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -2341- IF LK-GEJVWCNT-IND-ERRO NOT = 0 */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 0)
            {

                /*" -2342- DISPLAY 'IND ERRO    = ' LK-GEJVWCNT-IND-ERRO */
                _.Display($"IND ERRO    = {GEJVWCNT.LK_GEJVWCNT_IND_ERRO}");

                /*" -2343- DISPLAY 'MENSAGEM    = ' LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM    = {GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO}");

                /*" -2344- DISPLAY 'TABELA      = ' LK-GEJVWCNT-NOME-TABELA */
                _.Display($"TABELA      = {GEJVWCNT.LK_GEJVWCNT_NOME_TABELA}");

                /*" -2345- DISPLAY 'SQLCODE     = ' LK-GEJVWCNT-SQLCODE */
                _.Display($"SQLCODE     = {GEJVWCNT.LK_GEJVWCNT_SQLCODE}");

                /*" -2346- MOVE LK-GEJVWCNT-SQLCODE TO WSQLCODE */
                _.Move(GEJVWCNT.LK_GEJVWCNT_SQLCODE, WABEND.FILLER_21.WSQLCODE);

                /*" -2347- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2349- END-IF */
            }


            /*" -2351- PERFORM R0000-00-INICIALIZAR. */

            R0000_00_INICIALIZAR_SECTION();

            /*" -2353- PERFORM R0050-00-LER-MOV-SIGAT. */

            R0050_00_LER_MOV_SIGAT_SECTION();

            /*" -2355- MOVE 1 TO W-HEADER-PRP-FILIAL */
            _.Move(1, WREA88.W_HEADER_PRP_FILIAL);

            /*" -2358- PERFORM R0200-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-SIGAT EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM"))
            {

                R0200_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -2359- IF GEROU-MOVTO-CEF */

            if (WREA88.W_GEROU_MOVTO_CEF["GEROU_MOVTO_CEF"])
            {

                /*" -2361- PERFORM R2090-00-ATUALIZAR-ARQSIVPF. */

                R2090_00_ATUALIZAR_ARQSIVPF_SECTION();
            }


            /*" -2363- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -2364- IF W-INDICE-1 GREATER ZEROS */

            if (WAREA_AUXILIAR.W_INDICE_1 > 00)
            {

                /*" -2366- PERFORM R9980-00-GERAR-RELATORIO. */

                R9980_00_GERAR_RELATORIO_SECTION();
            }


            /*" -2366- GO TO R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" R0000-00-INICIALIZAR-SECTION */
        private void R0000_00_INICIALIZAR_SECTION()
        {
            /*" -2371- MOVE 'R0000-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0000-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2373- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2376- INITIALIZE TAB-FILIAL, W-TAB-CONSISTENCIA, TAB-CBO. */
            _.Initialize(
                WAREA_AUXILIAR.TAB_FILIAL
                , AREA_DAS_TABELAS.W_TAB_CONSISTENCIA
                , WAREA_AUXILIAR.TAB_CBO
            );

            /*" -2378- SET I08 TO 1. */
            I08.Value = 1;

            /*" -2380- PERFORM R6200-00-DECLARE-FONTES. */

            R6200_00_DECLARE_FONTES_SECTION();

            /*" -2382- PERFORM R6210-00-FETCH-FONTES. */

            R6210_00_FETCH_FONTES_SECTION();

            /*" -2383- IF W-FIM-FONTES NOT EQUAL SPACES */

            if (!WAREA_AUXILIAR.W_FIM_FONTES.IsEmpty())
            {

                /*" -2384- DISPLAY 'R0000 - PROBLEMA NO FETCH DA V0FONTES ' SQLCODE */
                _.Display($"R0000 - PROBLEMA NO FETCH DA V0FONTES {DB.SQLCODE}");

                /*" -2386- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -2389- PERFORM R6220-00-CARREGA-FONTES UNTIL W-FIM-FONTES EQUAL 'S' . */

            while (!(WAREA_AUXILIAR.W_FIM_FONTES == "S"))
            {

                R6220_00_CARREGA_FONTES_SECTION();
            }

            /*" -2391- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -2391- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -2399- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2401- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2403- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -2408- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -2413- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -2415- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -2417- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -2420- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -2422- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -2408- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -2429- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2431- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2432- OPEN INPUT MOV-SIGAT. */
            MOV_SIGAT.Open(REG_SIGAT);

            /*" -2432- OPEN OUTPUT MOV-VDEMP. */
            MOV_VDEMP.Open(REG_MOV_VDEMP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0050-00-LER-MOV-SIGAT-SECTION */
        private void R0050_00_LER_MOV_SIGAT_SECTION()
        {
            /*" -2439- MOVE 'R0050-00-LER-MOV-SIGAT' TO PARAGRAFO. */
            _.Move("R0050-00-LER-MOV-SIGAT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2441- MOVE 'READ' TO COMANDO. */
            _.Move("READ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2442- READ MOV-SIGAT AT END */
            try
            {
                MOV_SIGAT.Read(() =>
                {

                    /*" -2445- MOVE 'FIM' TO W-FIM-MOVTO-SIGAT. */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT);
                });

                _.Move(MOV_SIGAT.Value, REG_SIGAT);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2447- IF W-FIM-MOVTO-SIGAT NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT != "FIM")
            {

                /*" -2450- ADD 1 TO W-LIDO-MOVTO-SIGAT, W-AC-CONTROLE */
                WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT.Value = WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT + 1;
                WAREA_AUXILIAR.W_AC_CONTROLE.Value = WAREA_AUXILIAR.W_AC_CONTROLE + 1;

                /*" -2451- IF REG-TIPO-SIGAT EQUAL ' ' OR '0' OR 'A' */

                if (REG_SIGAT.REG_TIPO_SIGAT.In(" ", "0", "A"))
                {

                    /*" -2452- GO TO R0050-00-LER-MOV-SIGAT */
                    new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2453- ELSE */
                }
                else
                {


                    /*" -2454- IF REG-TIPO-SIGAT EQUAL 'H' */

                    if (REG_SIGAT.REG_TIPO_SIGAT == "H")
                    {

                        /*" -2456- MOVE REG-SIGAT TO REG-HEADER W-REG-HEADER */
                        _.Move(MOV_SIGAT?.Value, LBFPF990.REG_HEADER, W_REG_HEADER);

                        /*" -2460- IF RH-TIPO-ARQUIVO OF REG-HEADER EQUAL 1 AND RH-NOME OF REG-HEADER EQUAL 'PRPVG' OR 'PRPCTCRE' OR 'PRPATCOM' */

                        if (LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO == 1 && LBFPF990.REG_HEADER.RH_NOME.In("PRPVG", "PRPCTCRE", "PRPATCOM"))
                        {

                            /*" -2461- PERFORM R0100-00-VALIDAR-HEADER */

                            R0100_00_VALIDAR_HEADER_SECTION();

                            /*" -2462- END-IF */
                        }


                        /*" -2463- GO TO R0050-00-LER-MOV-SIGAT */
                        new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -2464- ELSE */
                    }
                    else
                    {


                        /*" -2465- IF REG-TIPO-SIGAT EQUAL 'T' */

                        if (REG_SIGAT.REG_TIPO_SIGAT == "T")
                        {

                            /*" -2466- MOVE REG-SIGAT TO REG-TRAILLER */
                            _.Move(MOV_SIGAT?.Value, LBFPF991.REG_TRAILLER);

                            /*" -2468- IF RH-TIPO-ARQUIVO OF REG-HEADER EQUAL 1 NEXT SENTENCE */

                            if (LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO == 1)
                            {

                                /*" -2469- ELSE */
                            }
                            else
                            {


                                /*" -2470- GO TO R0050-00-LER-MOV-SIGAT */
                                new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -2471- ELSE */
                            }

                        }
                        else
                        {


                            /*" -2472- IF RH-TIPO-ARQUIVO OF REG-HEADER EQUAL 2 */

                            if (LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO == 2)
                            {

                                /*" -2473- ADD 1 TO W-QTD-LH-TIPO-2 */
                                WAREA_AUXILIAR.W_QTD_LH_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LH_TIPO_2 + 1;

                                /*" -2474- GO TO R0050-00-LER-MOV-SIGAT */
                                new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -2475- ELSE */
                            }
                            else
                            {


                                /*" -2476- IF RH-TIPO-ARQUIVO OF REG-HEADER EQUAL 3 */

                                if (LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO == 3)
                                {

                                    /*" -2477- ADD 1 TO W-QTD-LH-TIPO-3 */
                                    WAREA_AUXILIAR.W_QTD_LH_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LH_TIPO_3 + 1;

                                    /*" -2478- GO TO R0050-00-LER-MOV-SIGAT */
                                    new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                                    return;//Recursividade detectada, cuidado...

                                    /*" -2479- ELSE */
                                }
                                else
                                {


                                    /*" -2481- IF RH-TIPO-ARQUIVO OF REG-HEADER NOT EQUAL 1 */

                                    if (LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO != 1)
                                    {

                                        /*" -2485- IF RH-NOME OF REG-HEADER NOT EQUAL 'PRPVG' AND 'PRPCTCRE' AND 'PRPATCOM' */

                                        if (!LBFPF990.REG_HEADER.RH_NOME.In("PRPVG", "PRPCTCRE", "PRPATCOM"))
                                        {

                                            /*" -2486- GO TO R0050-00-LER-MOV-SIGAT */
                                            new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                                            return;//Recursividade detectada, cuidado...

                                            /*" -2488- ELSE */
                                        }
                                        else
                                        {


                                            /*" -2489- DISPLAY 'VA0600B - FIM ANORMAL' */
                                            _.Display($"VA0600B - FIM ANORMAL");

                                            /*" -2491- DISPLAY '          TIPO ARQUIVO INVALIDO ' RH-TIPO-ARQUIVO OF REG-HEADER */
                                            _.Display($"          TIPO ARQUIVO INVALIDO {LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO}");

                                            /*" -2492- PERFORM R9988-00-FECHAR-ARQUIVOS */

                                            R9988_00_FECHAR_ARQUIVOS_SECTION();

                                            /*" -2493- GO TO R9999-00-FINALIZAR */

                                            R9999_00_FINALIZAR_SECTION(); //GOTO
                                            return;

                                            /*" -2494- END-IF */
                                        }


                                        /*" -2495- END-IF */
                                    }


                                    /*" -2496- END-IF */
                                }


                                /*" -2497- END-IF */
                            }


                            /*" -2498- END-IF */
                        }


                        /*" -2499- END-IF */
                    }


                    /*" -2500- END-IF */
                }


                /*" -2502- END-IF */
            }


            /*" -2503- IF W-FIM-MOVTO-SIGAT NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT != "FIM")
            {

                /*" -2506- IF RH-NOME OF REG-HEADER NOT EQUAL 'PRPVG' AND 'PRPCTCRE' AND 'PRPATCOM' */

                if (!LBFPF990.REG_HEADER.RH_NOME.In("PRPVG", "PRPCTCRE", "PRPATCOM"))
                {

                    /*" -2507- GO TO R0050-00-LER-MOV-SIGAT */
                    new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2508- ELSE */
                }
                else
                {


                    /*" -2509- IF W-AC-CONTROLE GREATER 1999 */

                    if (WAREA_AUXILIAR.W_AC_CONTROLE > 1999)
                    {

                        /*" -2510- ACCEPT WS-TIME FROM TIME */
                        _.Move(_.AcceptDate("TIME"), WS_TIME);

                        /*" -2511- MOVE WS-TIME-N TO WS-TIME-EDIT */
                        _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                        /*" -2512- DISPLAY ' ' */
                        _.Display($" ");

                        /*" -2515- DISPLAY 'VA0600B - TOTAL LIDO ' W-LIDO-MOVTO-SIGAT '  HORAS  ' WS-TIME-EDIT */

                        $"VA0600B - TOTAL LIDO {WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT}  HORAS  {WS_TIME_EDIT}"
                        .Display();

                        /*" -2516- MOVE ZEROS TO W-AC-CONTROLE */
                        _.Move(0, WAREA_AUXILIAR.W_AC_CONTROLE);

                        /*" -2517- END-IF */
                    }


                    /*" -2518- END-IF */
                }


                /*" -2520- END-IF */
            }


            /*" -2520- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0100-00-VALIDAR-HEADER-SECTION */
        private void R0100_00_VALIDAR_HEADER_SECTION()
        {
            /*" -2527- MOVE 'R0100-00-VALIDAR-HEADER' TO PARAGRAFO. */
            _.Move("R0100-00-VALIDAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2529- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2530- IF RH-TIPO-REG OF REG-HEADER NOT EQUAL 'H' */

            if (LBFPF990.REG_HEADER.RH_TIPO_REG != "H")
            {

                /*" -2531- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2534- DISPLAY '          MOVMENTO NAO POSSUI HEADER  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          MOVMENTO NAO POSSUI HEADER  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -2535- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2536- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2538- END-IF */
            }


            /*" -2541- IF RH-NOME OF REG-HEADER NOT EQUAL 'PRPVG' AND 'PRPCTCRE' AND 'PRPATCOM' */

            if (!LBFPF990.REG_HEADER.RH_NOME.In("PRPVG", "PRPCTCRE", "PRPATCOM"))
            {

                /*" -2542- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2543- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2546- DISPLAY '          NOME DO ARQUIVO INVALIDO  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          NOME DO ARQUIVO INVALIDO  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -2547- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2548- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2550- END-IF */
            }


            /*" -2552- PERFORM R0110-00-VALIDAR-CONVENIO. */

            R0110_00_VALIDAR_CONVENIO_SECTION();

            /*" -2553- MOVE 'R0100-00-VALIDAR-HEADER' TO PARAGRAFO. */
            _.Move("R0100-00-VALIDAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2554- IF RH-DATA-GERACAO OF REG-HEADER NOT NUMERIC */

            if (!LBFPF990.REG_HEADER.RH_DATA_GERACAO.IsNumeric())
            {

                /*" -2555- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2556- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2559- DISPLAY '          DATA DA GERACAO INVALIDA  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          DATA DA GERACAO INVALIDA  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -2560- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2561- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2563- END-IF */
            }


            /*" -2564- IF RH-DATA-GERACAO OF REG-HEADER EQUAL ZEROS */

            if (LBFPF990.REG_HEADER.RH_DATA_GERACAO == 00)
            {

                /*" -2565- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2566- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2569- DISPLAY '          DATA DA GERACAO INVALIDA  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          DATA DA GERACAO INVALIDA  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -2570- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2571- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2573- END-IF */
            }


            /*" -2575- IF RH-SIST-ORIGEM OF REG-HEADER NOT EQUAL 1 AND 9 AND 6 */

            if (!LBFPF990.REG_HEADER.RH_SIST_ORIGEM.In("1", "9", "6"))
            {

                /*" -2576- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2577- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2578- DISPLAY '          SISTEMA ORIGEM INVALIDO  ' */
                _.Display($"          SISTEMA ORIGEM INVALIDO  ");

                /*" -2580- DISPLAY '          RH-NOME        - ' RH-NOME OF REG-HEADER */
                _.Display($"          RH-NOME        - {LBFPF990.REG_HEADER.RH_NOME}");

                /*" -2582- DISPLAY '          RH-SIST-ORIGEM - ' RH-SIST-ORIGEM OF REG-HEADER */
                _.Display($"          RH-SIST-ORIGEM - {LBFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                /*" -2584- DISPLAY '          RH-DATA-GERACAO- ' RH-DATA-GERACAO OF REG-HEADER */
                _.Display($"          RH-DATA-GERACAO- {LBFPF990.REG_HEADER.RH_DATA_GERACAO}");

                /*" -2585- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2586- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2588- END-IF */
            }


            /*" -2589- IF RH-SIST-DESTINO OF REG-HEADER NOT EQUAL 4 */

            if (LBFPF990.REG_HEADER.RH_SIST_DESTINO != 4)
            {

                /*" -2590- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2591- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2595- DISPLAY '          SISTEMA DESTINO INVALIDO  ' RH-NOME OF REG-HEADER '  ' RH-SIST-DESTINO OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          SISTEMA DESTINO INVALIDO  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_SIST_DESTINO}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -2596- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2597- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2599- END-IF */
            }


            /*" -2602- IF RH-TIPO-ARQUIVO OF REG-HEADER NOT EQUAL 1 AND RH-TIPO-ARQUIVO OF REG-HEADER NOT EQUAL 2 AND RH-TIPO-ARQUIVO OF REG-HEADER NOT EQUAL 3 */

            if (LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO != 1 && LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO != 2 && LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO != 3)
            {

                /*" -2603- DISPLAY 'VA0600B  -  FIM ANORMAL' */
                _.Display($"VA0600B  -  FIM ANORMAL");

                /*" -2604- DISPLAY '            HEADER INVALIDO' */
                _.Display($"            HEADER INVALIDO");

                /*" -2608- DISPLAY '            TIPO DE ARQUIVO INVALIDO  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER '  ' RH-TIPO-ARQUIVO OF REG-HEADER */

                $"            TIPO DE ARQUIVO INVALIDO  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}  {LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO}"
                .Display();

                /*" -2609- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2610- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2620- END-IF */
            }


            /*" -2621- IF RH-SIST-ORIGEM OF REG-HEADER EQUAL 1 */

            if (LBFPF990.REG_HEADER.RH_SIST_ORIGEM == 1)
            {

                /*" -2622- MOVE 1 TO W-TP-MOVIMENTO */
                _.Move(1, WREA88.W_TP_MOVIMENTO);

                /*" -2623- ELSE */
            }
            else
            {


                /*" -2624- IF RH-SIST-ORIGEM OF REG-HEADER EQUAL 9 */

                if (LBFPF990.REG_HEADER.RH_SIST_ORIGEM == 9)
                {

                    /*" -2625- MOVE 3 TO W-TP-MOVIMENTO */
                    _.Move(3, WREA88.W_TP_MOVIMENTO);

                    /*" -2626- ELSE */
                }
                else
                {


                    /*" -2627- IF RH-SIST-ORIGEM OF REG-HEADER EQUAL 6 */

                    if (LBFPF990.REG_HEADER.RH_SIST_ORIGEM == 6)
                    {

                        /*" -2628- MOVE 4 TO W-TP-MOVIMENTO */
                        _.Move(4, WREA88.W_TP_MOVIMENTO);

                        /*" -2629- ELSE */
                    }
                    else
                    {


                        /*" -2630- IF RH-SIST-ORIGEM OF REG-HEADER EQUAL 3 */

                        if (LBFPF990.REG_HEADER.RH_SIST_ORIGEM == 3)
                        {

                            /*" -2631- IF RH-NSAS OF REG-HEADER EQUAL ZEROS */

                            if (LBFPF990.REG_HEADER.RH_NSAS == 00)
                            {

                                /*" -2632- MOVE 2 TO W-TP-MOVIMENTO */
                                _.Move(2, WREA88.W_TP_MOVIMENTO);

                                /*" -2633- ELSE */
                            }
                            else
                            {


                                /*" -2634- DISPLAY 'VA0600B - FIM ANORMAL' */
                                _.Display($"VA0600B - FIM ANORMAL");

                                /*" -2638- DISPLAY 'ORIGEM DO MOVIMENTO NAO IDENTIFICADA  ' RH-NOME OF REG-HEADER RH-SIST-ORIGEM OF REG-HEADER RH-DATA-GERACAO OF REG-HEADER */

                                $"ORIGEM DO MOVIMENTO NAO IDENTIFICADA  {LBFPF990.REG_HEADER.RH_NOME}{LBFPF990.REG_HEADER.RH_SIST_ORIGEM}{LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                                .Display();

                                /*" -2639- PERFORM R9988-00-FECHAR-ARQUIVOS */

                                R9988_00_FECHAR_ARQUIVOS_SECTION();

                                /*" -2640- GO TO R9999-00-FINALIZAR */

                                R9999_00_FINALIZAR_SECTION(); //GOTO
                                return;

                                /*" -2641- END-IF */
                            }


                            /*" -2642- ELSE */
                        }
                        else
                        {


                            /*" -2643- DISPLAY 'VA0600B - FIM ANORMAL' */
                            _.Display($"VA0600B - FIM ANORMAL");

                            /*" -2647- DISPLAY 'ORIGEM DO MOVIMENTO NAO IDENTIFICADA ' RH-NOME OF REG-HEADER '  ' RH-SIST-ORIGEM OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                            $"ORIGEM DO MOVIMENTO NAO IDENTIFICADA {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_SIST_ORIGEM}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                            .Display();

                            /*" -2648- PERFORM R9988-00-FECHAR-ARQUIVOS */

                            R9988_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -2649- GO TO R9999-00-FINALIZAR */

                            R9999_00_FINALIZAR_SECTION(); //GOTO
                            return;

                            /*" -2650- END-IF */
                        }


                        /*" -2651- END-IF */
                    }


                    /*" -2652- END-IF */
                }


                /*" -2659- END-IF */
            }


            /*" -2660- IF RH-TIPO-ARQUIVO OF REG-HEADER EQUAL 1 */

            if (LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO == 1)
            {

                /*" -2661- IF MOVTO-CEF-SIGAT */

                if (WREA88.W_TP_MOVIMENTO["MOVTO_CEF_SIGAT"])
                {

                    /*" -2662- PERFORM R0115-00-VAL-ARQUIVO-SIVPF */

                    R0115_00_VAL_ARQUIVO_SIVPF_SECTION();

                    /*" -2664- ELSE */
                }
                else
                {


                    /*" -2665- IF MOVTO-AIC OR MOVTO-AUTO-COMPRA */

                    if (WREA88.W_TP_MOVIMENTO["MOVTO_AIC"] || WREA88.W_TP_MOVIMENTO["MOVTO_AUTO_COMPRA"])
                    {

                        /*" -2666- PERFORM R0115-00-VAL-ARQUIVO-SIVPF */

                        R0115_00_VAL_ARQUIVO_SIVPF_SECTION();

                        /*" -2667- ELSE */
                    }
                    else
                    {


                        /*" -2668- IF MOVTO-SIVPF-FILIAL */

                        if (WREA88.W_TP_MOVIMENTO["MOVTO_SIVPF_FILIAL"])
                        {

                            /*" -2669- PERFORM R0116-00-VALIDAR-FILIAL */

                            R0116_00_VALIDAR_FILIAL_SECTION();

                            /*" -2670- PERFORM R0117-00-OBTER-NSAS-MOVTO */

                            R0117_00_OBTER_NSAS_MOVTO_SECTION();

                            /*" -2671- ELSE */
                        }
                        else
                        {


                            /*" -2672- DISPLAY 'VA0600B - FIM ANORMAL' */
                            _.Display($"VA0600B - FIM ANORMAL");

                            /*" -2673- DISPLAY '          MOVIMENTO INVALIDO ' */
                            _.Display($"          MOVIMENTO INVALIDO ");

                            /*" -2677- DISPLAY '          ORIGEM DO MOVIMENTO INVALIDA ' RH-NOME OF REG-HEADER ' ' RH-SIST-ORIGEM OF REG-HEADER ' ' RH-DATA-GERACAO OF REG-HEADER */

                            $"          ORIGEM DO MOVIMENTO INVALIDA {LBFPF990.REG_HEADER.RH_NOME} {LBFPF990.REG_HEADER.RH_SIST_ORIGEM} {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                            .Display();

                            /*" -2678- PERFORM R9988-00-FECHAR-ARQUIVOS */

                            R9988_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -2679- GO TO R9999-00-FINALIZAR */

                            R9999_00_FINALIZAR_SECTION(); //GOTO
                            return;

                            /*" -2680- END-IF */
                        }


                        /*" -2681- END-IF */
                    }


                    /*" -2682- END-IF */
                }


                /*" -2684- END-IF */
            }


            /*" -2685- IF RH-NSAS OF REG-HEADER EQUAL ZEROS */

            if (LBFPF990.REG_HEADER.RH_NSAS == 00)
            {

                /*" -2686- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2687- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2691- DISPLAY '          SEQUENCIAL DO ARQUIVO INVALIDO  ' RH-NOME OF REG-HEADER ' ' RH-SIST-ORIGEM OF REG-HEADER ' ' RH-DATA-GERACAO OF REG-HEADER */

                $"          SEQUENCIAL DO ARQUIVO INVALIDO  {LBFPF990.REG_HEADER.RH_NOME} {LBFPF990.REG_HEADER.RH_SIST_ORIGEM} {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -2692- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2693- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2695- END-IF */
            }


            /*" -2695- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/

        [StopWatch]
        /*" R0110-00-VALIDAR-CONVENIO-SECTION */
        private void R0110_00_VALIDAR_CONVENIO_SECTION()
        {
            /*" -2705- MOVE 'R0110-00-VALIDAR-CONVENIO' TO PARAGRAFO */
            _.Move("R0110-00-VALIDAR-CONVENIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2707- MOVE 'SELECT CONVEIO_SIVPF' TO COMANDO */
            _.Move("SELECT CONVEIO_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2710- MOVE RH-NOME OF REG-HEADER TO SIGLA-ARQUIVO OF DCLCONVENIO-SIVPF. */
            _.Move(LBFPF990.REG_HEADER.RH_NOME, COVSIVPF.DCLCONVENIO_SIVPF.SIGLA_ARQUIVO);

            /*" -2715- PERFORM R0110_00_VALIDAR_CONVENIO_DB_SELECT_1 */

            R0110_00_VALIDAR_CONVENIO_DB_SELECT_1();

            /*" -2718- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2719- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2720- DISPLAY '          CONVENIO NAO CADASTRADO' */
                _.Display($"          CONVENIO NAO CADASTRADO");

                /*" -2722- DISPLAY '          NOME ARQUIVO........ ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME ARQUIVO........ {LBFPF990.REG_HEADER.RH_NOME}");

                /*" -2724- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO OF REG-HEADER */
                _.Display($"          DATA GERACAO........ {LBFPF990.REG_HEADER.RH_DATA_GERACAO}");

                /*" -2726- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM OF REG-HEADER */
                _.Display($"          SISTEMA ORIGEM...... {LBFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                /*" -2728- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO OF REG-HEADER */
                _.Display($"          SISTEMA DESTINO..... {LBFPF990.REG_HEADER.RH_SIST_DESTINO}");

                /*" -2730- DISPLAY '          NSAS................ ' RH-NSAS OF REG-HEADER */
                _.Display($"          NSAS................ {LBFPF990.REG_HEADER.RH_NSAS}");

                /*" -2731- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2732- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2734- END-IF */
            }


            /*" -2734- . */

        }

        [StopWatch]
        /*" R0110-00-VALIDAR-CONVENIO-DB-SELECT-1 */
        public void R0110_00_VALIDAR_CONVENIO_DB_SELECT_1()
        {
            /*" -2715- EXEC SQL SELECT DESCR_ARQUIVO INTO :DCLCONVENIO-SIVPF.DESCR-ARQUIVO FROM SEGUROS.CONVENIO_SIVPF WHERE SIGLA_ARQUIVO = :DCLCONVENIO-SIVPF.SIGLA-ARQUIVO END-EXEC */

            var r0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1 = new R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1()
            {
                SIGLA_ARQUIVO = COVSIVPF.DCLCONVENIO_SIVPF.SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1.Execute(r0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DESCR_ARQUIVO, COVSIVPF.DCLCONVENIO_SIVPF.DESCR_ARQUIVO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_SAIDA*/

        [StopWatch]
        /*" R0115-00-VAL-ARQUIVO-SIVPF-SECTION */
        private void R0115_00_VAL_ARQUIVO_SIVPF_SECTION()
        {
            /*" -2741- MOVE 'R0115-00-VAL-ARQUIVO-SIVPF' TO PARAGRAFO. */
            _.Move("R0115-00-VAL-ARQUIVO-SIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2743- MOVE 'SELECT ARQUIVOS_SIVPF' TO COMANDO. */
            _.Move("SELECT ARQUIVOS_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2746- MOVE RH-NOME OF REG-HEADER TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF990.REG_HEADER.RH_NOME, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2749- MOVE RH-SIST-ORIGEM OF REG-HEADER TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF990.REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2752- MOVE RH-NSAS OF REG-HEADER TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF990.REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -2762- PERFORM R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1 */

            R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1();

            /*" -2765- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2766- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2767- DISPLAY '          MOVIMENTO JAH PROCESSADO' */
                _.Display($"          MOVIMENTO JAH PROCESSADO");

                /*" -2769- DISPLAY '          NOME ARQUIVO........ ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME ARQUIVO........ {LBFPF990.REG_HEADER.RH_NOME}");

                /*" -2771- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO OF REG-HEADER */
                _.Display($"          DATA GERACAO........ {LBFPF990.REG_HEADER.RH_DATA_GERACAO}");

                /*" -2773- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM OF REG-HEADER */
                _.Display($"          SISTEMA ORIGEM...... {LBFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                /*" -2775- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO OF REG-HEADER */
                _.Display($"          SISTEMA DESTINO..... {LBFPF990.REG_HEADER.RH_SIST_DESTINO}");

                /*" -2777- DISPLAY '          NSAS................ ' RH-NSAS OF REG-HEADER */
                _.Display($"          NSAS................ {LBFPF990.REG_HEADER.RH_NSAS}");

                /*" -2779- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -2780- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2781- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2782- ELSE */
            }
            else
            {


                /*" -2783- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2784- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -2785- DISPLAY '          ERRO ACESSO ARQUIVOS_SIVPF' */
                    _.Display($"          ERRO ACESSO ARQUIVOS_SIVPF");

                    /*" -2787- DISPLAY '          NOME ARQUIVO........ ' RH-NOME OF REG-HEADER */
                    _.Display($"          NOME ARQUIVO........ {LBFPF990.REG_HEADER.RH_NOME}");

                    /*" -2789- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO OF REG-HEADER */
                    _.Display($"          DATA GERACAO........ {LBFPF990.REG_HEADER.RH_DATA_GERACAO}");

                    /*" -2791- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM OF REG-HEADER */
                    _.Display($"          SISTEMA ORIGEM...... {LBFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                    /*" -2793- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO OF REG-HEADER */
                    _.Display($"          SISTEMA DESTINO..... {LBFPF990.REG_HEADER.RH_SIST_DESTINO}");

                    /*" -2795- DISPLAY '          NSAS................ ' RH-NSAS OF REG-HEADER */
                    _.Display($"          NSAS................ {LBFPF990.REG_HEADER.RH_NSAS}");

                    /*" -2797- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -2798- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2799- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -2800- END-IF */
                }


                /*" -2802- END-IF */
            }


            /*" -2802- . */

        }

        [StopWatch]
        /*" R0115-00-VAL-ARQUIVO-SIVPF-DB-SELECT-1 */
        public void R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1()
        {
            /*" -2762- EXEC SQL SELECT DATA_GERACAO INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM AND NSAS_SIVPF = :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF END-EXEC. */

            var r0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1 = new R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
            };

            var executed_1 = R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1.Execute(r0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0115_SAIDA*/

        [StopWatch]
        /*" R0116-00-VALIDAR-FILIAL-SECTION */
        private void R0116_00_VALIDAR_FILIAL_SECTION()
        {
            /*" -2809- MOVE 'R0116-00-VALIDAR-FILIAL' TO PARAGRAFO. */
            _.Move("R0116-00-VALIDAR-FILIAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2811- MOVE 'SEARCH TAB FONTES' TO COMANDO. */
            _.Move("SEARCH TAB FONTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2813- SET I08 TO 1 */
            I08.Value = 1;

            /*" -2816- SEARCH TAB-FILIAIS AT END */
            void SearchAtEnd0()
            {

                /*" -2817- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2820- DISPLAY '          AGENCIA GERADORA NAO CADASTRADA ' W-RH-AGE-GERADORA */
                _.Display($"          AGENCIA GERADORA NAO CADASTRADA {W_REG_HEADER.W_RH_AGE_GERADORA}");

                /*" -2821- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2824- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2827- WHEN W-RH-AGE-GERADORA EQUAL TAB-COD-FILIAL(I08) */
            };

            var mustSearchAtEnd0 = true;
            for (; I08 < WAREA_AUXILIAR.TAB_FILIAL.TAB_FILIAIS.Items.Count; I08.Value++)
            {

                if (W_REG_HEADER.W_RH_AGE_GERADORA == WAREA_AUXILIAR.TAB_FILIAL.TAB_FILIAIS[I08].TAB_COD_FILIAL)
                {

                    mustSearchAtEnd0 = false;

                    /*" -2828- MOVE W-RH-AGE-GERADORA TO FONTES-COD-FONTE OF DCLFONTES  END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0116_SAIDA*/

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-SECTION */
        private void R0117_00_OBTER_NSAS_MOVTO_SECTION()
        {
            /*" -2835- MOVE 'R0117-00-OBTER-NSAS-MOVTO' TO PARAGRAFO. */
            _.Move("R0117-00-OBTER-NSAS-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2837- MOVE 'SELECT COUNT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT COUNT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2840- MOVE 'PRPF' TO W-IDE-SIGLA. */
            _.Move("PRPF", WAREA_AUXILIAR.FILLER_11.W_IDE_SIGLA);

            /*" -2842- MOVE W-RH-AGE-GERADORA TO W-IDE-FILIAL */
            _.Move(W_REG_HEADER.W_RH_AGE_GERADORA, WAREA_AUXILIAR.FILLER_11.W_IDE_FILIAL);

            /*" -2845- MOVE W-SIGLA-ARQUIVO TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_SIGLA_ARQUIVO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2848- MOVE RH-SIST-ORIGEM OF REG-HEADER TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF990.REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2856- PERFORM R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1 */

            R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1();

            /*" -2859- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2862- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS-FILIAL */
                _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS_FILIAL);

                /*" -2863- COMPUTE W-NSAS-FILIAL = W-NSAS-FILIAL + 1 */
                WAREA_AUXILIAR.W_NSAS_FILIAL.Value = WAREA_AUXILIAR.W_NSAS_FILIAL + 1;

                /*" -2864- MOVE W-NSAS-FILIAL TO RH-NSAS OF REG-HEADER */
                _.Move(WAREA_AUXILIAR.W_NSAS_FILIAL, LBFPF990.REG_HEADER.RH_NSAS);

                /*" -2865- ELSE */
            }
            else
            {


                /*" -2866- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -2868- DISPLAY '          ERRO ACESSO TABELA ARQUIVOS-SIVPF ' SQLCODE */
                _.Display($"          ERRO ACESSO TABELA ARQUIVOS-SIVPF {DB.SQLCODE}");

                /*" -2870- DISPLAY '          SIGLA DO ARQUIVO................. ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO................. {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2871- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2871- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-DB-SELECT-1 */
        public void R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1()
        {
            /*" -2856- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM END-EXEC. */

            var r0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1 = new R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1.Execute(r0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0117_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0200_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -2879- MOVE 'R0200-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0200-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2881- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2888- MOVE ZERO TO W-MOVTO-AUTO, W-MOVTO-RISCO, W-MOVTO-VDEMP, W-MOVTO-PEXEC, W-QTD-CRITICA, W-QTD-MATRIZ */
            _.Move(0, WREA88.W_MOVTO_AUTO, WREA88.W_MOVTO_RISCO, WREA88.W_MOVTO_VDEMP, WREA88.W_MOVTO_PEXEC, WAREA_AUXILIAR.W_QTD_CRITICA, WAREA_AUXILIAR.W_QTD_MATRIZ);

            /*" -2892- MOVE 1 TO W-HEADER-AUTO, W-HEADER-RISCO, W-HEADER-VDEMP. */
            _.Move(1, WREA88.W_HEADER_AUTO, WREA88.W_HEADER_RISCO, WREA88.W_HEADER_VDEMP);

            /*" -2896- PERFORM R0250-00-TRATA-EMPRESA UNTIL W-FIM-MOVTO-SIGAT EQUAL 'FIM' OR REG-TIPO-SIGAT OF REG-SIGAT EQUAL 'T' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM" || REG_SIGAT.REG_TIPO_SIGAT == "T"))
            {

                R0250_00_TRATA_EMPRESA_SECTION();
            }

            /*" -2897- IF MOVTO-SIVPF-FILIAL */

            if (WREA88.W_TP_MOVIMENTO["MOVTO_SIVPF_FILIAL"])
            {

                /*" -2898- PERFORM R2060-00-ATUALIZA-ARQSIVPF */

                R2060_00_ATUALIZA_ARQSIVPF_SECTION();

                /*" -2900- END-IF */
            }


            /*" -2901- IF HDVDEMP-FOI-GERADO */

            if (WREA88.W_HEADER_VDEMP["HDVDEMP_FOI_GERADO"])
            {

                /*" -2902- PERFORM R2075-00-GERAR-TRAILLER-VDEMP */

                R2075_00_GERAR_TRAILLER_VDEMP_SECTION();

                /*" -2904- END-IF */
            }


            /*" -2906- IF MOVTO-CEF-SIGAT OR MOVTO-AUTO-COMPRA */

            if (WREA88.W_TP_MOVIMENTO["MOVTO_CEF_SIGAT"] || WREA88.W_TP_MOVIMENTO["MOVTO_AUTO_COMPRA"])
            {

                /*" -2907- PERFORM R2100-00-TB-CONTROLE */

                R2100_00_TB_CONTROLE_SECTION();

                /*" -2909- END-IF */
            }


            /*" -2909- PERFORM R2000-00-QUEBRA-EMPRESSA. */

            R2000_00_QUEBRA_EMPRESSA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0250-00-TRATA-EMPRESA-SECTION */
        private void R0250_00_TRATA_EMPRESA_SECTION()
        {
            /*" -2916- MOVE 'R0250-00-TRATA-EMPRESA' TO PARAGRAFO. */
            _.Move("R0250-00-TRATA-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2917- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2921- DISPLAY 'NUMERO DA PROPOSTA...... ' REG-NUM-PROPOSTA OF REG-SIGAT */
            _.Display($"NUMERO DA PROPOSTA...... {REG_SIGAT.REG_NUM_PROPOSTA}");

            /*" -2923- MOVE 1 TO W-CRITICA-PROPOSTA. */
            _.Move(1, WREA88.W_CRITICA_PROPOSTA);

            /*" -2925- PERFORM R0270-00-INICIALIZAR-AREAS. */

            R0270_00_INICIALIZAR_AREAS_SECTION();

            /*" -2931- PERFORM R0300-00-TRATA-MOVIMENTO UNTIL W-FIM-MOVTO-SIGAT EQUAL 'FIM' OR REG-TIPO-SIGAT OF REG-SIGAT EQUAL 'T' OR REG-NUM-PROPOSTA OF REG-SIGAT NOT EQUAL W-NUM-PROPOSTA-ANT. */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM" || REG_SIGAT.REG_TIPO_SIGAT == "T" || REG_SIGAT.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
            {

                R0300_00_TRATA_MOVIMENTO_SECTION();
            }

            /*" -2933- IF PROPOSTA-SEM-CRITICA */

            if (WREA88.W_CRITICA_PROPOSTA["PROPOSTA_SEM_CRITICA"])
            {

                /*" -2934- IF EXISTE-MOVTO-VDEMP */

                if (WREA88.W_MOVTO_VDEMP["EXISTE_MOVTO_VDEMP"])
                {

                    /*" -2935- IF HDVDEMP-NAO-GERADO */

                    if (WREA88.W_HEADER_VDEMP["HDVDEMP_NAO_GERADO"])
                    {

                        /*" -2936- PERFORM R0476-00-GERAR-HEADER-VDEMP */

                        R0476_00_GERAR_HEADER_VDEMP_SECTION();

                        /*" -2937- END-IF */
                    }


                    /*" -2939- END-IF */
                }


                /*" -2940- IF W-EXISTE-PROPOSTA NOT EQUAL 'SIM' */

                if (WAREA_AUXILIAR.W_EXISTE_PROPOSTA != "SIM")
                {

                    /*" -2941- PERFORM R0480-00-GERAR-TAB-PF */

                    R0480_00_GERAR_TAB_PF_SECTION();

                    /*" -2943- END-IF */
                }


                /*" -2944- IF VIDAZUL-EMPRESARIAL-SUPER */

                if (LBWPF002.W_PRODUTO["VIDAZUL_EMPRESARIAL_SUPER"])
                {

                    /*" -2945- PERFORM R1800-00-GERAR-MOV-VDEMP */

                    R1800_00_GERAR_MOV_VDEMP_SECTION();

                    /*" -2947- END-IF */
                }


                /*" -2947- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0270-00-INICIALIZAR-AREAS-SECTION */
        private void R0270_00_INICIALIZAR_AREAS_SECTION()
        {
            /*" -2954- MOVE 'R0270-00-INICIALIZAR-AREAS' TO PARAGRAFO */
            _.Move("R0270-00-INICIALIZAR-AREAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2956- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2961- MOVE REG-NUM-PROPOSTA OF REG-SIGAT TO W-NUM-PROPOSTA, W-NUM-PROPOSTA-ANT. */
            _.Move(REG_SIGAT.REG_NUM_PROPOSTA, WREA88.W_NUM_PROPOSTA, WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT);

            /*" -2980- INITIALIZE W-TAB-BENEFICIARIOS , W-TAB-INFORMACOES, W-TAB-CLAUSULAS , W-TB-ENDERECOS-N, W-IND-BENEF , W-IND-BENEF-N , W-IND-INFO , W-IND-INFO1 , W-IND-INFO-N , W-IND-CLAU , W-IND-CLAU-N , W-IND-ENDER , W-IND-RISCO-N , W-IND-RISCO , W-IND-VDEMP-N , W-IND-VDEMP , W-IND-ENDER1 , W-IND-ENDER-N , W-IND-ENDER-A , W-EXISTE-TP-2 , W-EXISTE-TP-4 , W-EXISTE-TP-5 , W-EXISTE-TP-6 , W-CONTROLE-TP-0 , REG-CLIENTES , REG-PROPOSTA-SASSE, REG-BENEFIC , REG-VAL-ACESSORIOS, REG-INFORMACOES , REG-PAG-AVULSO , W-TB-ENDERECOS-A , W-EXISTE-TP-B , DCLGE-OPER-CREDITO , W-EXISTE-TP-C , REG-TIPO-6-AUX , W-EXISTE-TP-D , REGISTRO-EMPRESA , W-EXISTE-TP-W */
            _.Initialize(
                WAREA_AUXILIAR.W_TAB_BENEFICIARIOS
                , WAREA_AUXILIAR.W_TAB_INFORMACOES
                , WAREA_AUXILIAR.W_TAB_CLAUSULAS
                , WAREA_AUXILIAR.W_TB_ENDERECOS_N
                , WAREA_AUXILIAR.W_IND_BENEF
                , WAREA_AUXILIAR.W_IND_BENEF_N
                , WAREA_AUXILIAR.W_IND_INFO
                , WAREA_AUXILIAR.W_IND_INFO1
                , WAREA_AUXILIAR.W_IND_INFO_N
                , WAREA_AUXILIAR.W_IND_CLAU
                , WAREA_AUXILIAR.W_IND_CLAU_N
                , WAREA_AUXILIAR.W_IND_ENDER
                , WAREA_AUXILIAR.W_IND_RISCO_N
                , WAREA_AUXILIAR.W_IND_RISCO
                , WAREA_AUXILIAR.W_IND_VDEMP_N
                , WAREA_AUXILIAR.W_IND_VDEMP
                , WAREA_AUXILIAR.W_IND_ENDER1
                , WAREA_AUXILIAR.W_IND_ENDER_N
                , WAREA_AUXILIAR.W_IND_ENDER_A
                , WAREA_AUXILIAR.W_EXISTE_TP_2
                , WAREA_AUXILIAR.W_EXISTE_TP_4
                , WAREA_AUXILIAR.W_EXISTE_TP_5
                , WAREA_AUXILIAR.W_EXISTE_TP_6
                , WAREA_AUXILIAR.W_CONTROLE_TP_0
                , LBFPF011.REG_CLIENTES
                , LXFCT004.REG_PROPOSTA_SASSE
                , LBFPF014.REG_BENEFIC
                , LBFPF016.REG_VAL_ACESSORIOS
                , LBFPF015.REG_INFORMACOES
                , LBFPF000.REG_PAG_AVULSO
                , WAREA_AUXILIAR.W_TB_ENDERECOS_A
                , WAREA_AUXILIAR.W_EXISTE_TP_B
                , GE372.DCLGE_OPER_CREDITO
                , WAREA_AUXILIAR.W_EXISTE_TP_C
                , REG_TIPO_6_AUX
                , WAREA_AUXILIAR.W_EXISTE_TP_D
                , LBFPF164.REGISTRO_EMPRESA
                , WAREA_AUXILIAR.W_EXISTE_TP_W
            );

            /*" -2980- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R0300-00-TRATA-MOVIMENTO-SECTION */
        private void R0300_00_TRATA_MOVIMENTO_SECTION()
        {
            /*" -2987- MOVE 'R0300-00-TRATA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0300-00-TRATA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2989- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2990- IF REG-TIPO-SIGAT EQUAL '3' */

            if (REG_SIGAT.REG_TIPO_SIGAT == "3")
            {

                /*" -2991- ADD 1 TO W-QTD-LD-SIVPF-3 */
                WAREA_AUXILIAR.W_QTD_LD_SIVPF_3.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_3 + 1;

                /*" -2992- PERFORM R0302-00-CRITICAS */

                R0302_00_CRITICAS_SECTION();

                /*" -2994- END-IF */
            }


            /*" -2997- IF PROPOSTA-COM-CRITICA */

            if (WREA88.W_CRITICA_PROPOSTA["PROPOSTA_COM_CRITICA"])
            {

                /*" -2998- GO TO R0300-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/ //GOTO
                return;

                /*" -3000- END-IF */
            }


            /*" -3002- MOVE REG-TIPO-SIGAT OF REG-SIGAT TO W-TP-REGISTRO. */
            _.Move(REG_SIGAT.REG_TIPO_SIGAT, WREA88.W_TP_REGISTRO);

            /*" -3003-  EVALUATE TRUE  */

            /*" -3004-  WHEN TPREG-PGTO-AVULSO  */

            /*" -3004- IF TPREG-PGTO-AVULSO */

            if (WREA88.W_TP_REGISTRO["TPREG_PGTO_AVULSO"])
            {

                /*" -3005- PERFORM R0310-00-MOVTO-AVULSO */

                R0310_00_MOVTO_AVULSO_SECTION();

                /*" -3006-  WHEN TPREG-CLIENTE  */

                /*" -3006- ELSE IF TPREG-CLIENTE */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_CLIENTE"])
            {

                /*" -3007- MOVE '#' TO N88-MATRIZ */
                _.Move("#", WREA88.N88_MATRIZ);

                /*" -3008- MOVE ZEROS TO W-AIC-TIPO-ASSIST */
                _.Move(0, WREA88.W_AIC_TIPO_ASSIST);

                /*" -3009- MOVE REG-SIGAT TO REG-CLIENTES */
                _.Move(MOV_SIGAT?.Value, LBFPF011.REG_CLIENTES);

                /*" -3010- MOVE R1-COD-CBO TO WS-COD-CBO */
                _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, WAREA_AUXILIAR.WS_COD_CBO);

                /*" -3011-  WHEN TPREG-ENDERECO  */

                /*" -3011- ELSE IF TPREG-ENDERECO */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_ENDERECO"])
            {

                /*" -3012- PERFORM R0315-00-MOVTO-ENDERECO */

                R0315_00_MOVTO_ENDERECO_SECTION();

                /*" -3013-  WHEN TPREG-PROPOSTA  */

                /*" -3013- ELSE IF TPREG-PROPOSTA */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_PROPOSTA"])
            {

                /*" -3014- PERFORM R0320-00-MOVTO-PROPOSTA */

                R0320_00_MOVTO_PROPOSTA_SECTION();

                /*" -3015-  WHEN TPREG-BENEFICIARIO  */

                /*" -3015- ELSE IF TPREG-BENEFICIARIO */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_BENEFICIARIO"])
            {

                /*" -3016- PERFORM R0325-00-MOVTO-BENEFICIARIO */

                R0325_00_MOVTO_BENEFICIARIO_SECTION();

                /*" -3017-  WHEN TPREG-TIPO-B  */

                /*" -3017- ELSE IF TPREG-TIPO-B */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_TIPO_B"])
            {

                /*" -3018- PERFORM R0327-00-MOVTO-TIPO-B */

                R0327_00_MOVTO_TIPO_B_SECTION();

                /*" -3019-  WHEN TPREG-TIPO-C  */

                /*" -3019- ELSE IF TPREG-TIPO-C */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_TIPO_C"])
            {

                /*" -3020- PERFORM R0328-00-MOVTO-TIPO-C */

                R0328_00_MOVTO_TIPO_C_SECTION();

                /*" -3021-  WHEN TPREG-TIPO-W  */

                /*" -3021- ELSE IF TPREG-TIPO-W */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_TIPO_W"])
            {

                /*" -3022- PERFORM R0329-00-MOVTO-TIPO-W */

                R0329_00_MOVTO_TIPO_W_SECTION();

                /*" -3023-  WHEN TPREG-INFO-COMPLEMENTAR  */

                /*" -3023- ELSE IF TPREG-INFO-COMPLEMENTAR */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_INFO_COMPLEMENTAR"])
            {

                /*" -3024- PERFORM R0330-00-MOVTO-INF-COMPLEME */

                R0330_00_MOVTO_INF_COMPLEME_SECTION();

                /*" -3025-  WHEN TPREG-TIPO-D  */

                /*" -3025- ELSE IF TPREG-TIPO-D */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_TIPO_D"])
            {

                /*" -3026- PERFORM R0331-00-MOVTO-TIPO-D */

                R0331_00_MOVTO_TIPO_D_SECTION();

                /*" -3027-  WHEN TPREG-REGISTRO-DIVERSOS  */

                /*" -3027- ELSE IF TPREG-REGISTRO-DIVERSOS */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_REGISTRO_DIVERSOS"])
            {

                /*" -3028- PERFORM R0335-00-MOVTO-REG-DIVERSOS */

                R0335_00_MOVTO_REG_DIVERSOS_SECTION();

                /*" -3029-  WHEN TPREG-HEADER  */

                /*" -3029- ELSE IF TPREG-HEADER */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_HEADER"])
            {

                /*" -3030- MOVE REG-SIGAT TO REG-HEADER */
                _.Move(MOV_SIGAT?.Value, LBFPF990.REG_HEADER);

                /*" -3031-  WHEN TPREG-TRAILLER  */

                /*" -3031- ELSE IF TPREG-TRAILLER */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_TRAILLER"])
            {

                /*" -3032- MOVE REG-SIGAT TO REG-TRAILLER */
                _.Move(MOV_SIGAT?.Value, LBFPF991.REG_TRAILLER);

                /*" -3033-  WHEN OTHER  */

                /*" -3033- ELSE */
            }
            else
            {


                /*" -3034- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -3035- DISPLAY '          TIPO REGISTRO NAO ESPERADO' */
                _.Display($"          TIPO REGISTRO NAO ESPERADO");

                /*" -3037- DISPLAY '          TIPO DE REGISTRO........  ' REG-TIPO-SIGAT OF REG-SIGAT */
                _.Display($"          TIPO DE REGISTRO........  {REG_SIGAT.REG_TIPO_SIGAT}");

                /*" -3039- DISPLAY '          NUMERO DA PROPOSTA......  ' REG-NUM-PROPOSTA OF REG-SIGAT */
                _.Display($"          NUMERO DA PROPOSTA......  {REG_SIGAT.REG_NUM_PROPOSTA}");

                /*" -3040- DISPLAY ' ' */
                _.Display($" ");

                /*" -3041- DISPLAY REG-SIGAT */
                _.Display(REG_SIGAT);

                /*" -3042- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3043- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -3047-  END-EVALUATE.  */

                /*" -3047- END-IF. */
            }


            /*" -3050- IF PROPOSTA-COM-CRITICA */

            if (WREA88.W_CRITICA_PROPOSTA["PROPOSTA_COM_CRITICA"])
            {

                /*" -3051- GO TO R0300-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/ //GOTO
                return;

                /*" -3051- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0300_10 */

            R0300_10();

        }

        [StopWatch]
        /*" R0300-10 */
        private void R0300_10(bool isPerform = false)
        {
            /*" -3055- PERFORM R0050-00-LER-MOV-SIGAT. */

            R0050_00_LER_MOV_SIGAT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0302-00-CRITICAS-SECTION */
        private void R0302_00_CRITICAS_SECTION()
        {
            /*" -3062- MOVE 'R0302-00-CRITICAS' TO PARAGRAFO. */
            _.Move("R0302-00-CRITICAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3064- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3066- MOVE REG-SIGAT TO REG-PROPOSTA-SASSE */
            _.Move(MOV_SIGAT?.Value, LXFCT004.REG_PROPOSTA_SASSE);

            /*" -3074- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO W-PRODUTO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, LBWPF002.W_PRODUTO);

            /*" -3075- IF MOVTO-SIVPF-FILIAL */

            if (WREA88.W_TP_MOVIMENTO["MOVTO_SIVPF_FILIAL"])
            {

                /*" -3077- IF REG-ORIGEM OF REG-SIGAT NOT NUMERIC OR REG-ORIGEM OF REG-SIGAT EQUAL ZEROS */

                if (!REG_SIGAT.REG_ORIGEM_SIV.REG_ORIGEM.IsNumeric() || REG_SIGAT.REG_ORIGEM_SIV.REG_ORIGEM == 00)
                {

                    /*" -3078- IF CANAL-VENDA-PAPEL */

                    if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                    {

                        /*" -3079- MOVE 7 TO REG-ORIGEM OF REG-SIGAT */
                        _.Move(7, REG_SIGAT.REG_ORIGEM_SIV.REG_ORIGEM);

                        /*" -3080- ELSE */
                    }
                    else
                    {


                        /*" -3081- MOVE 4 TO REG-ORIGEM OF REG-SIGAT */
                        _.Move(4, REG_SIGAT.REG_ORIGEM_SIV.REG_ORIGEM);

                        /*" -3082- END-IF */
                    }


                    /*" -3083- END-IF */
                }


                /*" -3085- END-IF */
            }


            /*" -3086- IF MOVTO-AUTO-COMPRA */

            if (WREA88.W_TP_MOVIMENTO["MOVTO_AUTO_COMPRA"])
            {

                /*" -3088- MOVE REG-ORIGEM-AIC OF REG-SIGAT TO W-ORIGEM-PROPOSTA */
                _.Move(REG_SIGAT.REG_ORIGEM_AIC, WREA88.W_ORIGEM_PROPOSTA);

                /*" -3089- ELSE */
            }
            else
            {


                /*" -3091- MOVE REG-ORIGEM OF REG-SIGAT TO W-ORIGEM-PROPOSTA */
                _.Move(REG_SIGAT.REG_ORIGEM_SIV.REG_ORIGEM, WREA88.W_ORIGEM_PROPOSTA);

                /*" -3099- END-IF */
            }


            /*" -3100- IF PROPOSTA-AUTOMOVEL */

            if (WREA88.FILLER_34.PRP_AUTO["PROPOSTA_AUTOMOVEL"])
            {

                /*" -3101- IF MOVTO-SIVPF-FILIAL */

                if (WREA88.W_TP_MOVIMENTO["MOVTO_SIVPF_FILIAL"])
                {

                    /*" -3102- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -3104- DISPLAY 'PROPOSTA DE AUTO VENDIDA NA FILIAL, ANALIZAR ' REG-NUM-PROPOSTA */
                    _.Display($"PROPOSTA DE AUTO VENDIDA NA FILIAL, ANALIZAR {REG_SIGAT.REG_NUM_PROPOSTA}");

                    /*" -3105- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3106- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -3107- END-IF */
                }


                /*" -3113- END-IF */
            }


            /*" -3115- MOVE 'NAO' TO W-EXISTE-PROPOSTA */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_PROPOSTA);

            /*" -3117- PERFORM R9978-00-VERIFICAR-PROPOSTA */

            R9978_00_VERIFICAR_PROPOSTA_SECTION();

            /*" -3120- MOVE ' ' TO PROPOFID-SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ */
            _.Move(" ", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -3121- IF PROPOFID-SIT-PROPOSTA EQUAL 'CAV' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "CAV")
            {

                /*" -3122- MOVE 2 TO W-CONVENIO */
                _.Move(2, WREA88.W_CONVENIO);

                /*" -3123- ELSE */
            }
            else
            {


                /*" -3124- IF PROPOFID-SIT-PROPOSTA EQUAL 'CCA' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "CCA")
                {

                    /*" -3125- MOVE 3 TO W-CONVENIO */
                    _.Move(3, WREA88.W_CONVENIO);

                    /*" -3126- ELSE */
                }
                else
                {


                    /*" -3127- MOVE 1 TO W-CONVENIO */
                    _.Move(1, WREA88.W_CONVENIO);

                    /*" -3128- END-IF */
                }


                /*" -3130- END-IF */
            }


            /*" -3131- IF W-EXISTE-PROPOSTA EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_PROPOSTA == "SIM")
            {

                /*" -3132- IF PRODUTO-AUTOMOVEL */

                if (LBWPF002.W_PRODUTO["PRODUTO_AUTOMOVEL"])
                {

                    /*" -3134- IF PROPOFID-SIT-PROPOSTA EQUAL 'CAV' */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "CAV")
                    {

                        /*" -3136- PERFORM R9970-00-TRATAR-PROPOSTA */

                        R9970_00_TRATAR_PROPOSTA_SECTION();

                        /*" -3137- GO TO R0302-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0302_SAIDA*/ //GOTO
                        return;

                        /*" -3138- END-IF */
                    }


                    /*" -3139- END-IF */
                }


                /*" -3141- END-IF */
            }


            /*" -3142- IF W-EXISTE-PROPOSTA EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_PROPOSTA == "SIM")
            {

                /*" -3143- IF CONVENIO-CCA */

                if (WREA88.W_CONVENIO["CONVENIO_CCA"])
                {

                    /*" -3145- IF PROPOFID-SIT-PROPOSTA EQUAL 'CCA' */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "CCA")
                    {

                        /*" -3147- PERFORM R9970-00-TRATAR-PROPOSTA */

                        R9970_00_TRATAR_PROPOSTA_SECTION();

                        /*" -3148- GO TO R0302-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0302_SAIDA*/ //GOTO
                        return;

                        /*" -3149- END-IF */
                    }


                    /*" -3150- END-IF */
                }


                /*" -3153- END-IF */
            }


            /*" -3154- IF W-EXISTE-PROPOSTA EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_PROPOSTA == "SIM")
            {

                /*" -3155- IF R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE EQUAL 'ENV' */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA == "ENV")
                {

                    /*" -3156- IF PRODUTO-AUTOMOVEL */

                    if (LBWPF002.W_PRODUTO["PRODUTO_AUTOMOVEL"])
                    {

                        /*" -3157- IF PROPOFID-SIT-PROPOSTA EQUAL 'POB' */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "POB")
                        {

                            /*" -3159- MOVE 2 TO W-CRITICA-PROPOSTA */
                            _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                            /*" -3161- PERFORM R9985-00-ATUALIZAR-DADOS-SISPF */

                            R9985_00_ATUALIZAR_DADOS_SISPF_SECTION();

                            /*" -3167- PERFORM R0050-00-LER-MOV-SIGAT UNTIL W-FIM-MOVTO-SIGAT EQUAL 'FIM' OR REG-TIPO-SIGAT OF REG-SIGAT EQUAL 'T' OR REG-NUM-PROPOSTA OF REG-SIGAT NOT EQUAL W-NUM-PROPOSTA-ANT */

                            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM" || REG_SIGAT.REG_TIPO_SIGAT == "T" || REG_SIGAT.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
                            {

                                R0050_00_LER_MOV_SIGAT_SECTION();
                            }

                            /*" -3168- GO TO R0302-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0302_SAIDA*/ //GOTO
                            return;

                            /*" -3169- END-IF */
                        }


                        /*" -3170- END-IF */
                    }


                    /*" -3171- END-IF */
                }


                /*" -3173- END-IF */
            }


            /*" -3175- IF W-EXISTE-PROPOSTA EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_PROPOSTA == "SIM")
            {

                /*" -3177- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -3178- IF R1-DATA-NASCIMENTO OF REG-CLIENTES EQUAL ZEROS */

                if (LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO == 00)
                {

                    /*" -3179- MOVE 01010001 TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                    _.Move(01010001, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                    /*" -3181- END-IF */
                }


                /*" -3183- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

                if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
                {

                    /*" -3185- PERFORM R0505-LER-PESSOA-FISICA */

                    R0505_LER_PESSOA_FISICA_SECTION();

                    /*" -3187- IF SQLCODE EQUAL ZEROS NEXT SENTENCE */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3189- ELSE */
                    }
                    else
                    {


                        /*" -3191- ADD 1 TO W-INDICE-1 */
                        WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                        /*" -3193- MOVE 4 TO W-TB-COD-DESCRI (W-INDICE-1) */
                        _.Move(4, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                        /*" -3195- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3197- ELSE */
                    }

                }
                else
                {


                    /*" -3199- PERFORM R0510-LER-PESSOA-JURIDICA */

                    R0510_LER_PESSOA_JURIDICA_SECTION();

                    /*" -3201- IF SQLCODE EQUAL ZEROS NEXT SENTENCE */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3203- ELSE */
                    }
                    else
                    {


                        /*" -3205- ADD 1 TO W-INDICE-1 */
                        WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                        /*" -3207- MOVE 4 TO W-TB-COD-DESCRI (W-INDICE-1) */
                        _.Move(4, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                        /*" -3208- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3209- END-IF */
                    }


                    /*" -3215- END-IF */
                }


                /*" -3217- ELSE */
            }
            else
            {


                /*" -3219- IF CANAL-VENDA-PAPEL */

                if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                {

                    /*" -3221- PERFORM R0305-00-LER-PROP-SICOB */

                    R0305_00_LER_PROP_SICOB_SECTION();

                    /*" -3223- IF SICOB-JA-CADASTRADO */

                    if (WREA88.W_LEITURA_SICOB["SICOB_JA_CADASTRADO"])
                    {

                        /*" -3225- MOVE 2 TO W-CRITICA-PROPOSTA */
                        _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                        /*" -3227- ADD 1 TO W-INDICE-1 */
                        WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                        /*" -3230- MOVE 2 TO W-TB-COD-DESCRI (W-INDICE-1) */
                        _.Move(2, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                        /*" -3232- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3234- END-IF */
                    }


                    /*" -3237- MOVE REG-NUM-PROPOSTA OF REG-SIGAT TO PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Move(REG_SIGAT.REG_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

                    /*" -3239- PERFORM R0763-LER-RCAP */

                    R0763_LER_RCAP_SECTION();

                    /*" -3240- IF ENCONTROU-RCAP */

                    if (WREA88.W_LEITURA_RCAP["ENCONTROU_RCAP"])
                    {

                        /*" -3241- IF RCAPS-SIT-REGISTRO OF DCLRCAPS EQUAL '1' */

                        if (RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO == "1")
                        {

                            /*" -3242- MOVE 2 TO W-CRITICA-PROPOSTA */
                            _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                            /*" -3244- ADD 1 TO W-INDICE-1 */
                            WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                            /*" -3246- MOVE 5 TO W-TB-COD-DESCRI(W-INDICE-1) */
                            _.Move(5, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                            /*" -3247- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -3248- ELSE */
                        }
                        else
                        {


                            /*" -3249- IF RCAPS-SIT-REGISTRO OF DCLRCAPS EQUAL '2' */

                            if (RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO == "2")
                            {

                                /*" -3250- MOVE 2 TO W-CRITICA-PROPOSTA */
                                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                                /*" -3252- ADD 1 TO W-INDICE-1 */
                                WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                                /*" -3254- MOVE 9 TO W-TB-COD-DESCRI (W-INDICE-1) */
                                _.Move(9, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                                /*" -3255- PERFORM R9979-00-MONTA-TAB-CRITICA */

                                R9979_00_MONTA_TAB_CRITICA_SECTION();

                                /*" -3256- END-IF */
                            }


                            /*" -3257- END-IF */
                        }


                        /*" -3258- END-IF */
                    }


                    /*" -3259- END-IF */
                }


                /*" -3265- END-IF */
            }


            /*" -3276- IF R3-NUM-PROPOSTA EQUAL 1 OR 2 OR 3 OR 4 OR 5 OR 6 OR 7 OR 8 OR 9 OR 19 OR 11111111111111 OR 22222222222222 OR 33333333333333 OR 44444444444444 OR 55555555555555 OR 66666666666666 OR 77777777777777 OR 88888888888888 OR 99999999999999 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA.In("1", "2", "3", "4", "5", "6", "7", "8", "9", "19", "11111111111111", "22222222222222", "33333333333333", "44444444444444", "55555555555555", "66666666666666", "77777777777777", "88888888888888", "99999999999999"))
            {

                /*" -3277- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -3279- ADD 1 TO W-INDICE-1 */
                WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                /*" -3281- MOVE 7 TO W-TB-COD-DESCRI (W-INDICE-1) */
                _.Move(7, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                /*" -3282- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3290- END-IF */
            }


            /*" -3291- IF W-EXISTE-PROPOSTA EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_EXISTE_PROPOSTA == "NAO")
            {

                /*" -3294- IF PRODUTOS-VIDA OR SEGURO-PRESTAMISTA OR VIDA-EXCLUSIVO-AIC */

                if (LBWPF002.W_PRODUTO["PRODUTOS_VIDA"] || LBWPF002.W_PRODUTO["SEGURO_PRESTAMISTA"] || LBWPF002.W_PRODUTO["VIDA_EXCLUSIVO_AIC"])
                {

                    /*" -3296- PERFORM R9983-00-LER-PROPOSTAVA */

                    R9983_00_LER_PROPOSTAVA_SECTION();

                    /*" -3298- IF W-EXISTE-PROPOSTA EQUAL 'SIM' */

                    if (WAREA_AUXILIAR.W_EXISTE_PROPOSTA == "SIM")
                    {

                        /*" -3300- MOVE 2 TO W-CRITICA-PROPOSTA */
                        _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                        /*" -3302- ADD 1 TO W-INDICE-1 */
                        WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                        /*" -3304- MOVE 10 TO W-TB-COD-DESCRI (W-INDICE-1) */
                        _.Move(10, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                        /*" -3305- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3306- ELSE */
                    }
                    else
                    {


                        /*" -3307- CONTINUE */

                        /*" -3308- END-IF */
                    }


                    /*" -3309- ELSE */
                }
                else
                {


                    /*" -3312- IF BILHETE-AP OR BILHETE-RD */

                    if (LBWPF002.W_PRODUTO["BILHETE_AP"] || LBWPF002.W_PRODUTO["BILHETE_RD"])
                    {

                        /*" -3314- PERFORM R9984-00-LER-BILHETE */

                        R9984_00_LER_BILHETE_SECTION();

                        /*" -3316- IF W-EXISTE-PROPOSTA EQUAL 'SIM' */

                        if (WAREA_AUXILIAR.W_EXISTE_PROPOSTA == "SIM")
                        {

                            /*" -3318- MOVE 2 TO W-CRITICA-PROPOSTA */
                            _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                            /*" -3320- ADD 1 TO W-INDICE-1 */
                            WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                            /*" -3322- MOVE 11 TO W-TB-COD-DESCRI (W-INDICE-1) */
                            _.Move(11, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                            /*" -3323- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -3324- END-IF */
                        }


                        /*" -3325- END-IF */
                    }


                    /*" -3326- END-IF */
                }


                /*" -3335- END-IF */
            }


            /*" -3339- IF PRODUTOS-VIDA OR SEGURO-PRESTAMISTA OR ORIGEM-AIC OR VIDA-EXCLUSIVO-AIC */

            if (LBWPF002.W_PRODUTO["PRODUTOS_VIDA"] || LBWPF002.W_PRODUTO["SEGURO_PRESTAMISTA"] || WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AIC"] || LBWPF002.W_PRODUTO["VIDA_EXCLUSIVO_AIC"])
            {

                /*" -3341- MOVE 2 TO W-VERSAO-SIGAT */
                _.Move(2, WREA88.W_VERSAO_SIGAT);

                /*" -3342- IF R3-PERIPGTO NOT NUMERIC */

                if (!LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO.IsNumeric())
                {

                    /*" -3343- MOVE ZEROS TO R3-PERIPGTO */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO);

                    /*" -3345- END-IF */
                }


                /*" -3347- MOVE R3-PERIPGTO TO W-PERI-PGTO */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO, WREA88.W_PERI_PGTO);

                /*" -3348- IF R3-OPCAO-CONJUGE EQUAL 'S' */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE == "S")
                {

                    /*" -3350- MOVE '1' TO WHOST-OPCAO-CONJUGE W-CONJUGE */
                    _.Move("1", WHOST_OPCAO_CONJUGE, WREA88.W_CONJUGE);

                    /*" -3351- ELSE */
                }
                else
                {


                    /*" -3353- MOVE '3' TO WHOST-OPCAO-CONJUGE W-CONJUGE */
                    _.Move("3", WHOST_OPCAO_CONJUGE, WREA88.W_CONJUGE);

                    /*" -3355- END-IF */
                }


                /*" -3357- IF PRODUTOS-VIDA-INDIVIDUAL AND R3-PERIPGTO EQUAL ZEROS */

                if (LBWPF002.W_PRODUTO["PRODUTOS_VIDA_INDIVIDUAL"] && LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO == 00)
                {

                    /*" -3359- MOVE 2 TO W-CRITICA-PROPOSTA */
                    _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                    /*" -3360- ADD 1 TO W-INDICE-1 */
                    WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                    /*" -3361- MOVE 15 TO W-TB-COD-DESCRI (W-INDICE-1) */
                    _.Move(15, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                    /*" -3363- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3364- DISPLAY ' PERIODICIDADE DE PAGAMENTO NAO PREVISTO: ' */
                    _.Display($" PERIODICIDADE DE PAGAMENTO NAO PREVISTO: ");

                    /*" -3366- DISPLAY ' PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($" PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3381- END-IF */
                }


                /*" -3382- IF VIDA-DA-GENTE */

                if (LBWPF002.W_PRODUTO["VIDA_DA_GENTE"])
                {

                    /*" -3383- IF R3-PERIPGTO GREATER ZEROS */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO > 00)
                    {

                        /*" -3384- MOVE 1 TO W-VERSAO-SIGAT */
                        _.Move(1, WREA88.W_VERSAO_SIGAT);

                        /*" -3386- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -3387- ELSE */
                    }

                }
                else
                {


                    /*" -3388- IF MULTIPREMIADO-SUPER */

                    if (LBWPF002.W_PRODUTO["MULTIPREMIADO_SUPER"])
                    {

                        /*" -3389- IF R3-PERIPGTO GREATER ZEROS */

                        if (LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO > 00)
                        {

                            /*" -3399- MOVE 1 TO W-VERSAO-SIGAT. */
                            _.Move(1, WREA88.W_VERSAO_SIGAT);
                        }

                    }

                }

            }


            /*" -3400- IF ORIGEM-AUTO-COMPRA-IBC OR ORIGEM-AUTO-COMPRA-LOJA */

            if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_IBC"] || WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_LOJA"])
            {

                /*" -3402- MOVE R3-VALOR-PREMIO-TOTAL OF REG-PROPOSTA-SASSE TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                /*" -3404- END-IF */
            }


            /*" -3406- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE NOT EQUAL 3 AND R3-VAL-PAGO OF REG-PROPOSTA-SASSE EQUAL ZEROS */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG != 3 && LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO == 00)
            {

                /*" -3407- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -3408- ADD 1 TO W-INDICE-1 */
                WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                /*" -3409- MOVE 17 TO W-TB-COD-DESCRI (W-INDICE-1) */
                _.Move(17, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                /*" -3410- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3424- END-IF */
            }


            /*" -3425- IF PROPOSTA-COM-CRITICA */

            if (WREA88.W_CRITICA_PROPOSTA["PROPOSTA_COM_CRITICA"])
            {

                /*" -3426- ADD 1 TO W-QTD-CRITICA */
                WAREA_AUXILIAR.W_QTD_CRITICA.Value = WAREA_AUXILIAR.W_QTD_CRITICA + 1;

                /*" -3431- PERFORM R0050-00-LER-MOV-SIGAT UNTIL W-FIM-MOVTO-SIGAT EQUAL 'FIM' OR REG-TIPO-SIGAT OF REG-SIGAT EQUAL 'T' OR REG-NUM-PROPOSTA OF REG-SIGAT NOT EQUAL W-NUM-PROPOSTA-ANT */

                while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM" || REG_SIGAT.REG_TIPO_SIGAT == "T" || REG_SIGAT.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
                {

                    R0050_00_LER_MOV_SIGAT_SECTION();
                }

                /*" -3432- GO TO R0302-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0302_SAIDA*/ //GOTO
                return;

                /*" -3438- END-IF */
            }


            /*" -3460- IF R3-NUM-PROPOSTA EQUAL 10289160000016 OR 10051160000016 OR 10866160000015 OR 10966160000011 OR 10357160000340 OR 11727160000013 OR 10717160000010 OR 10282160000167 OR 10162160000026 OR 10726160000044 OR 10811160000034 OR 12884160000022 OR 10020160000016 OR 10850160000078 OR 10205160000015 OR 10292160000032 OR 10099160000045 OR 10850160000060 OR 10374160000014 OR 10374160000022 OR 12156160000022 OR 11108160000027 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA.In("10289160000016", "10051160000016", "10866160000015", "10966160000011", "10357160000340", "11727160000013", "10717160000010", "10282160000167", "10162160000026", "10726160000044", "10811160000034", "12884160000022", "10020160000016", "10850160000078", "10205160000015", "10292160000032", "10099160000045", "10850160000060", "10374160000014", "10374160000022", "12156160000022", "11108160000027"))
            {

                /*" -3461- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -3462- ADD 1 TO W-QTD-CRITICA */
                WAREA_AUXILIAR.W_QTD_CRITICA.Value = WAREA_AUXILIAR.W_QTD_CRITICA + 1;

                /*" -3467- PERFORM R0050-00-LER-MOV-SIGAT UNTIL W-FIM-MOVTO-SIGAT EQUAL 'FIM' OR REG-TIPO-SIGAT OF REG-SIGAT EQUAL 'T' OR REG-NUM-PROPOSTA OF REG-SIGAT NOT EQUAL W-NUM-PROPOSTA-ANT */

                while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM" || REG_SIGAT.REG_TIPO_SIGAT == "T" || REG_SIGAT.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
                {

                    R0050_00_LER_MOV_SIGAT_SECTION();
                }

                /*" -3469- END-IF */
            }


            /*" -3469- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0302_SAIDA*/

        [StopWatch]
        /*" R0305-00-LER-PROP-SICOB-SECTION */
        private void R0305_00_LER_PROP_SICOB_SECTION()
        {
            /*" -3476- MOVE 'R0305-00-LER-PROP-SICOB' TO PARAGRAFO. */
            _.Move("R0305-00-LER-PROP-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3478- MOVE 'SELECT PROPOSTA_FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA_FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3481- MOVE REG-NUM-PROPOSTA OF REG-SIGAT TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(REG_SIGAT.REG_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -3486- PERFORM R0305_00_LER_PROP_SICOB_DB_SELECT_1 */

            R0305_00_LER_PROP_SICOB_DB_SELECT_1();

            /*" -3489- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -3490- MOVE 1 TO W-LEITURA-SICOB */
                _.Move(1, WREA88.W_LEITURA_SICOB);

                /*" -3491- ELSE */
            }
            else
            {


                /*" -3492- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3493- MOVE 2 TO W-LEITURA-SICOB */
                    _.Move(2, WREA88.W_LEITURA_SICOB);

                    /*" -3494- ELSE */
                }
                else
                {


                    /*" -3495- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -3497- DISPLAY '          NUMERO DO SICOB..... ' PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO DO SICOB..... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

                    /*" -3498- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3498- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0305-00-LER-PROP-SICOB-DB-SELECT-1 */
        public void R0305_00_LER_PROP_SICOB_DB_SELECT_1()
        {
            /*" -3486- EXEC SQL SELECT SIT_PROPOSTA INTO :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB END-EXEC. */

            var r0305_00_LER_PROP_SICOB_DB_SELECT_1_Query1 = new R0305_00_LER_PROP_SICOB_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            var executed_1 = R0305_00_LER_PROP_SICOB_DB_SELECT_1_Query1.Execute(r0305_00_LER_PROP_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0305_SAIDA*/

        [StopWatch]
        /*" R0310-00-MOVTO-AVULSO-SECTION */
        private void R0310_00_MOVTO_AVULSO_SECTION()
        {
            /*" -3505- MOVE 'R0310-00-MOVTO-AVULSO' TO PARAGRAFO. */
            _.Move("R0310-00-MOVTO-AVULSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3507- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3508- MOVE 1 TO W-CONTROLE-TP-0 */
            _.Move(1, WAREA_AUXILIAR.W_CONTROLE_TP_0);

            /*" -3510- MOVE REG-SIGAT TO REG-PAG-AVULSO */
            _.Move(MOV_SIGAT?.Value, LBFPF000.REG_PAG_AVULSO);

            /*" -3510- ADD 1 TO W-QTD-LD-SIVPF-0. */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_0.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_0 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_SAIDA*/

        [StopWatch]
        /*" R0315-00-MOVTO-ENDERECO-SECTION */
        private void R0315_00_MOVTO_ENDERECO_SECTION()
        {
            /*" -3517- MOVE 'R0315-00-MOVTO-ENDERECO' TO PARAGRAFO. */
            _.Move("R0315-00-MOVTO-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3519- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3520- MOVE 'SIM' TO W-EXISTE-TP-2 */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_2);

            /*" -3522- ADD 1 TO W-IND-ENDER-N. */
            WAREA_AUXILIAR.W_IND_ENDER_N.Value = WAREA_AUXILIAR.W_IND_ENDER_N + 1;

            /*" -3523- IF W-IND-ENDER-N GREATER 30 */

            if (WAREA_AUXILIAR.W_IND_ENDER_N > 30)
            {

                /*" -3524- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -3525- DISPLAY '          ESTOURO DA TABELA DE ENDERECOS' */
                _.Display($"          ESTOURO DA TABELA DE ENDERECOS");

                /*" -3527- DISPLAY '          NUMERO DA PROPOSTA..........  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA..........  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -3529- DISPLAY '          W-IND-ENDER.................  ' W-IND-ENDER */
                _.Display($"          W-IND-ENDER.................  {WAREA_AUXILIAR.W_IND_ENDER}");

                /*" -3530- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3532- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -3533- MOVE REG-SIGAT TO W-TB-REG-ENDERECOS-N(W-IND-ENDER-N). */
            _.Move(MOV_SIGAT?.Value, WAREA_AUXILIAR.W_TB_ENDERECOS_N.W_TAB_END_REG_N[WAREA_AUXILIAR.W_IND_ENDER_N].W_TB_REG_ENDERECOS_N);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0315_SAIDA*/

        [StopWatch]
        /*" R0320-00-MOVTO-PROPOSTA-SECTION */
        private void R0320_00_MOVTO_PROPOSTA_SECTION()
        {
            /*" -3540- MOVE 'R0320-00-MOVTO-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0320-00-MOVTO-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3542- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3544- MOVE REG-SIGAT TO REG-PROPOSTA-SASSE */
            _.Move(MOV_SIGAT?.Value, LXFCT004.REG_PROPOSTA_SASSE);

            /*" -3545- IF R3-COD-PRODUTO OF REG-PROPOSTA-SASSE = 1 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO == 1)
            {

                /*" -3546- IF R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE > ZEROS */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE > 00)
                {

                    /*" -3548- IF R1-RENDA-INDIVIDUAL OF REG-CLIENTES NOT EQUAL SPACES */

                    if (!LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL.IsEmpty())
                    {

                        /*" -3549- IF CANAL-VENDA-PAPEL */

                        if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                        {

                            /*" -3550- IF FAIXA-NUMERACAO-MULT-SUPER */

                            if (WREA88.FAIXAS.FAIXA_NUMERACAO["FAIXA_NUMERACAO_MULT_SUPER"])
                            {

                                /*" -3551- MOVE 13 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                                _.Move(13, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                                /*" -3552- ELSE */
                            }
                            else
                            {


                                /*" -3553- MOVE 01 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                                _.Move(01, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                                /*" -3554- ELSE */
                            }

                        }
                        else
                        {


                            /*" -3555- IF CANAL-VENDA-CEF */

                            if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_CEF"])
                            {

                                /*" -3556- MOVE 13 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                                _.Move(13, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                                /*" -3557- ELSE */
                            }
                            else
                            {


                                /*" -3558- MOVE 01 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                                _.Move(01, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                                /*" -3559- ELSE */
                            }

                        }

                    }
                    else
                    {


                        /*" -3560- MOVE 01 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                        _.Move(01, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                        /*" -3561- ELSE */
                    }

                }
                else
                {


                    /*" -3562- IF R1-RENDA-INDIVIDUAL NOT EQUAL SPACES */

                    if (!LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL.IsEmpty())
                    {

                        /*" -3563- IF CANAL-VENDA-PAPEL */

                        if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                        {

                            /*" -3564- IF FAIXA-NUMERACAO-MULT-SUPER */

                            if (WREA88.FAIXAS.FAIXA_NUMERACAO["FAIXA_NUMERACAO_MULT_SUPER"])
                            {

                                /*" -3565- MOVE 13 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                                _.Move(13, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                                /*" -3566- ELSE */
                            }
                            else
                            {


                                /*" -3567- MOVE 01 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                                _.Move(01, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                                /*" -3568- ELSE */
                            }

                        }
                        else
                        {


                            /*" -3569- IF CANAL-VENDA-CEF */

                            if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_CEF"])
                            {

                                /*" -3570- MOVE 13 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                                _.Move(13, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                                /*" -3571- ELSE */
                            }
                            else
                            {


                                /*" -3572- MOVE 01 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                                _.Move(01, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                                /*" -3573- ELSE */
                            }

                        }

                    }
                    else
                    {


                        /*" -3575- MOVE 01 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE. */
                        _.Move(01, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);
                    }

                }

            }


            /*" -3578- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO W-PRODUTO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, LBWPF002.W_PRODUTO);

            /*" -3578- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_SAIDA*/

        [StopWatch]
        /*" R0325-00-MOVTO-BENEFICIARIO-SECTION */
        private void R0325_00_MOVTO_BENEFICIARIO_SECTION()
        {
            /*" -3585- MOVE 'R0325-00-MOVTO-BENEFICIARIO ' TO PARAGRAFO. */
            _.Move("R0325-00-MOVTO-BENEFICIARIO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3587- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3588- ADD 1 TO W-QTD-LD-SIVPF-4 */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_4.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_4 + 1;

            /*" -3590- MOVE 'SIM' TO W-EXISTE-TP-4 */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_4);

            /*" -3592- ADD 1 TO W-IND-BENEF-N. */
            WAREA_AUXILIAR.W_IND_BENEF_N.Value = WAREA_AUXILIAR.W_IND_BENEF_N + 1;

            /*" -3593- IF W-IND-BENEF-N GREATER 30 */

            if (WAREA_AUXILIAR.W_IND_BENEF_N > 30)
            {

                /*" -3594- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -3595- DISPLAY '          ESTOURO DA TABELA DE BENEFICIARIOS' */
                _.Display($"          ESTOURO DA TABELA DE BENEFICIARIOS");

                /*" -3597- DISPLAY '          NUMERO DA PROPOSTA..............  ' R4-NUM-PROPOSTA OF REG-BENEFIC */
                _.Display($"          NUMERO DA PROPOSTA..............  {LBFPF014.REG_BENEFIC.R4_NUM_PROPOSTA}");

                /*" -3599- DISPLAY '          W-IND-BENEF-N...................  ' W-IND-BENEF-N */
                _.Display($"          W-IND-BENEF-N...................  {WAREA_AUXILIAR.W_IND_BENEF_N}");

                /*" -3600- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3602- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -3603- MOVE REG-SIGAT TO W-TB-REG-BENEFI(W-IND-BENEF-N). */
            _.Move(MOV_SIGAT?.Value, WAREA_AUXILIAR.W_TAB_BENEFICIARIOS.W_TAB_BENEF_REG[WAREA_AUXILIAR.W_IND_BENEF_N].W_TB_REG_BENEFI);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0325_SAIDA*/

        [StopWatch]
        /*" R0327-00-MOVTO-TIPO-B-SECTION */
        private void R0327_00_MOVTO_TIPO_B_SECTION()
        {
            /*" -3610- MOVE 'R0327-00-MOVTO-TIPO-B          ' TO PARAGRAFO. */
            _.Move("R0327-00-MOVTO-TIPO-B          ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3611- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3613- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3614- ADD 1 TO W-QTD-LD-SIVPF-B */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_B.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_B + 1;

            /*" -3616- MOVE 'SIM' TO W-EXISTE-TP-B */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_B);

            /*" -3618- MOVE REG-SIGAT TO REG-TIPO-B. */
            _.Move(MOV_SIGAT?.Value, LXFPF024.REG_TIPO_B);

            /*" -3620- IF (WS-COD-CBO EQUAL 999) OR (WS-COD-CBO EQUAL ZEROS) */

            if ((WAREA_AUXILIAR.WS_COD_CBO == 999) || (WAREA_AUXILIAR.WS_COD_CBO == 00))
            {

                /*" -3621- MOVE R24-COD-CBO-CLIENTE TO WS-COD-CBO */
                _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_COD_CBO_CLIENTE, WAREA_AUXILIAR.WS_COD_CBO);

                /*" -3623- END-IF */
            }


            /*" -3625- IF R24-ORIG-PARCEIROS EQUAL 1021 OR 1022 OR 1023 OR 1024 OR 1025 */

            if (LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_ORIG_PARCEIROS.In("1021", "1022", "1023", "1024", "1025"))
            {

                /*" -3626- MOVE R24-ORIG-PARCEIROS TO W-ORIGEM-PROPOSTA */
                _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_ORIG_PARCEIROS, WREA88.W_ORIGEM_PROPOSTA);

                /*" -3628- END-IF */
            }


            /*" -3629- MOVE 'N' TO N88-ERRO-MATRIZ */
            _.Move("N", WREA88.N88_ERRO_MATRIZ);

            /*" -3630- MOVE R24-IND-SUBS-DINAMICA TO N88-MATRIZ */
            _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_IND_SUBS_DINAMICA, WREA88.N88_MATRIZ);

            /*" -3632- MOVE R24-TP-SUBS-DINAMICA TO N88-TIPO-MATRIZ */
            _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_TP_SUBS_DINAMICA, WREA88.N88_TIPO_MATRIZ);

            /*" -3633- IF SEM-MATRIZ */

            if (WREA88.N88_MATRIZ["SEM_MATRIZ"])
            {

                /*" -3634- MOVE R3-VALOR-PREMIO-TOTAL TO WHOST-PRM-TOTAL-MA */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL, WHOST_PRM_TOTAL_MA);

                /*" -3635- ELSE */
            }
            else
            {


                /*" -3636- MOVE R24-VLR-PRM-BRUTO TO WHOST-PRM-TOTAL-MA */
                _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VLR_PRM_BRUTO, WHOST_PRM_TOTAL_MA);

                /*" -3638- END-IF */
            }


            /*" -3639- IF VIDAZUL-EMPRESARIAL-SUPER */

            if (LBWPF002.W_PRODUTO["VIDAZUL_EMPRESARIAL_SUPER"])
            {

                /*" -3640- CONTINUE */

                /*" -3641- ELSE */
            }
            else
            {


                /*" -3643- PERFORM R0350-00-CRITICAS-TIPO-B THRU R0350-99-SAIDA */

                R0350_00_CRITICAS_TIPO_B_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/


                /*" -3645- END-IF */
            }


            /*" -3645- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0327_SAIDA*/

        [StopWatch]
        /*" R0328-00-MOVTO-TIPO-C-SECTION */
        private void R0328_00_MOVTO_TIPO_C_SECTION()
        {
            /*" -3652- MOVE 'R0328-00-MOVTO-TIPO-C          ' TO PARAGRAFO. */
            _.Move("R0328-00-MOVTO-TIPO-C          ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3654- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3655- ADD 1 TO W-QTD-LD-SIVPF-C */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_C.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_C + 1;

            /*" -3657- MOVE 'SIM' TO W-EXISTE-TP-C */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_C);

            /*" -3657- MOVE REG-SIGAT TO REG-TIPO-C. */
            _.Move(MOV_SIGAT?.Value, LBFPF026.REG_TIPO_C);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0328_SAIDA*/

        [StopWatch]
        /*" R0329-00-MOVTO-TIPO-W-SECTION */
        private void R0329_00_MOVTO_TIPO_W_SECTION()
        {
            /*" -3664- MOVE 'R0329-00-MOVTO-TIPO-W          ' TO PARAGRAFO. */
            _.Move("R0329-00-MOVTO-TIPO-W          ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3666- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3667- ADD 1 TO W-QTD-LD-SIVPF-W */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_W.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_W + 1;

            /*" -3669- MOVE 'SIM' TO W-EXISTE-TP-W */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_W);

            /*" -3669- MOVE REG-SIGAT TO REG-TIPO-W. */
            _.Move(MOV_SIGAT?.Value, LXFPF027.REG_TIPO_W);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0329_SAIDA*/

        [StopWatch]
        /*" R0330-00-MOVTO-INF-COMPLEME-SECTION */
        private void R0330_00_MOVTO_INF_COMPLEME_SECTION()
        {
            /*" -3676- MOVE 'R0330-00-MOVTO-INF-COMPLEME ' TO PARAGRAFO. */
            _.Move("R0330-00-MOVTO-INF-COMPLEME ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3677- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3679- MOVE REG-SIGAT TO REG-INFORMACOES. */
            _.Move(MOV_SIGAT?.Value, LBFPF015.REG_INFORMACOES);

            /*" -3680- IF R5-INFO-COMPLEMEN OF REG-INFORMACOES NOT EQUAL SPACES */

            if (!LBFPF015.REG_INFORMACOES.R5_INFO_COMPLEMEN.IsEmpty())
            {

                /*" -3681- ADD 1 TO W-QTD-LD-SIVPF-5 */
                WAREA_AUXILIAR.W_QTD_LD_SIVPF_5.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_5 + 1;

                /*" -3682- MOVE 'SIM' TO W-EXISTE-TP-5 */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_5);

                /*" -3684- ADD 1 TO W-IND-INFO-N */
                WAREA_AUXILIAR.W_IND_INFO_N.Value = WAREA_AUXILIAR.W_IND_INFO_N + 1;

                /*" -3685- IF W-IND-INFO-N GREATER 90 */

                if (WAREA_AUXILIAR.W_IND_INFO_N > 90)
                {

                    /*" -3686- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -3687- DISPLAY '          ESTOURO DA TABELA INF.COMPLEMENTAR' */
                    _.Display($"          ESTOURO DA TABELA INF.COMPLEMENTAR");

                    /*" -3689- DISPLAY '          NUMERO DA PROPOSTA..............  ' R5-NUM-PROPOSTA OF REG-INFORMACOES */
                    _.Display($"          NUMERO DA PROPOSTA..............  {LBFPF015.REG_INFORMACOES.R5_NUM_PROPOSTA}");

                    /*" -3691- DISPLAY '          W-IND-INFO-N....................  ' W-IND-INFO-N */
                    _.Display($"          W-IND-INFO-N....................  {WAREA_AUXILIAR.W_IND_INFO_N}");

                    /*" -3692- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3693- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -3695- END-IF */
                }


                /*" -3695- MOVE REG-SIGAT TO W-TB-REG-INFORMACOES(W-IND-INFO-N). */
                _.Move(MOV_SIGAT?.Value, WAREA_AUXILIAR.W_TAB_INFORMACOES.W_TAB_INFO_REG[WAREA_AUXILIAR.W_IND_INFO_N].W_TB_REG_INFORMACOES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_SAIDA*/

        [StopWatch]
        /*" R0331-00-MOVTO-TIPO-D-SECTION */
        private void R0331_00_MOVTO_TIPO_D_SECTION()
        {
            /*" -3702- MOVE 'R0331-00-MOVTO-TIPO-D          ' TO PARAGRAFO. */
            _.Move("R0331-00-MOVTO-TIPO-D          ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3704- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3705- ADD 1 TO W-QTD-LD-SIVPF-D */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_D.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_D + 1;

            /*" -3707- MOVE 'SIM' TO W-EXISTE-TP-D */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_D);

            /*" -3707- MOVE REG-SIGAT TO REG-TIPO-D. */
            _.Move(MOV_SIGAT?.Value, LXFPF028.REG_TIPO_D);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0331_SAIDA*/

        [StopWatch]
        /*" R0335-00-MOVTO-REG-DIVERSOS-SECTION */
        private void R0335_00_MOVTO_REG_DIVERSOS_SECTION()
        {
            /*" -3714- MOVE 'R0335-00-MOVTO-REG-DIVERSOS' TO PARAGRAFO. */
            _.Move("R0335-00-MOVTO-REG-DIVERSOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3715- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3717- IF SEGURO-VIDA-MULHER OR W-PRODUTO EQUAL 9341 */

            if (LBWPF002.W_PRODUTO["SEGURO_VIDA_MULHER"] || LBWPF002.W_PRODUTO == 9341)
            {

                /*" -3718- MOVE 'SIM' TO W-EXISTE-TP-6 */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_6);

                /*" -3719- MOVE REG-SIGAT TO REGISTRO-VIDA-MULHER */
                _.Move(MOV_SIGAT?.Value, LBFPF161.REGISTRO_VIDA_MULHER);

                /*" -3720- ELSE */
            }
            else
            {


                /*" -3721- IF SEGURO-PRESTAMISTA */

                if (LBWPF002.W_PRODUTO["SEGURO_PRESTAMISTA"])
                {

                    /*" -3722- MOVE 'SIM' TO W-EXISTE-TP-6 */
                    _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_6);

                    /*" -3723- MOVE REG-SIGAT TO REGISTRO-PRESTAMISTA */
                    _.Move(MOV_SIGAT?.Value, LBFPF162.REGISTRO_PRESTAMISTA);

                    /*" -3724- IF R6-DES-OPER-CREDITO NOT EQUAL SPACES */

                    if (!LBFPF162.REGISTRO_PRESTAMISTA.R6_DES_OPER_CREDITO.IsEmpty())
                    {

                        /*" -3725- PERFORM R0960-INF-PRESTAMISTA */

                        R0960_INF_PRESTAMISTA_SECTION();

                        /*" -3726- END-IF */
                    }


                    /*" -3727- ELSE */
                }
                else
                {


                    /*" -3728- MOVE REG-SIGAT TO W-PROPOSTA-DPS */
                    _.Move(MOV_SIGAT?.Value, WAREA_AUXILIAR.W_PROPOSTA_DPS);

                    /*" -3762- IF W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNNNNNNNNNNN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNSNNSNNNNNNSS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNSNNNSNNNNNNNSS' OR W-DPS-VDMULHER EQUAL 'NSSNNNNNNNNNNNNNSSNNNNNNNS' OR W-DPS-VDMULHER EQUAL 'NSSNNNNNNNNNNNNNSSNNNNNNNS' OR W-DPS-VDMULHER EQUAL 'NSNNNSNNNNNNNNNNNNNNSNNNNN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNSNNNNNNNNS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNSNNNNNNNSNNNNS' OR W-DPS-VDMULHER EQUAL 'NSNNNSNNNNNNNNSNNSNNNSNNNS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNSNNSNNSNNNNS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNNNNNNNNNSN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNSNNNNNNNNNNS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNSNSSNNSNNNSN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNNNNNSNNNNN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNNNNNSNNNNS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNNNNNSNNNSN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNSNNSNNNNNNNN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNNSNNNNSNSS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNNNNNNNNNNS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNNSNNNNNNNN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNSNNSNSSNNNNNNSS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNSNNNNNNNNNNN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNNNNNNNNNNNSS' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNSNNSNSNNNNNNNNNNN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNNNNSNNSNNNNNNSN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNSNNNNNNNNNSNNNNNNNN' OR W-DPS-VDMULHER EQUAL 'NSNNNNNNNNNSNNSNSSNNSNNNSS' OR W-DPS-VDMULHER EQUAL 'NSSNNSNSNNNNNNNNSSNNSNNNNN' OR W-DPS-VDMULHER EQUAL 'NSSNNNNSNNNNNNNNNNNNNNNNNN' OR W-DPS-VDMULHER EQUAL 'NSNNNSSSNSNSNNNNNSNNNNNNNN' OR W-DPS-VDMULHER EQUAL 'SSNNNNNNNNNNNNNNSNNNNNNNNS' OR W-DPS-VDMULHER EQUAL 'NSSNNNNNNNNNNNNNNNNNNNNSNN' OR W-DPS-VDMULHER EQUAL 'NSSNNNNNNNNNNNSNSNNNNNNNNN' NEXT SENTENCE */

                    if (WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNNNNNNNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNSNNSNNNNNNSS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNSNNNSNNNNNNNSS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSSNNNNNNNNNNNNNSSNNNNNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSSNNNNNNNNNNNNNSSNNNNNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNSNNNNNNNNNNNNNNSNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNSNNNNNNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNSNNNNNNNSNNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNSNNNNNNNNSNNSNNNSNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNSNNSNNSNNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNNNNNNNNNSN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNSNNNNNNNNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNSNSSNNSNNNSN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNNNNNSNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNNNNNSNNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNNNNNSNNNSN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNSNNSNNNNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNNSNNNNSNSS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNNNNNNNNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNNSNNNNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNSNNSNSSNNNNNNSS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNSNNNNNNNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNNNNNNNNNNNSS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNSNNSNSNNNNNNNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNNNNSNNSNNNNNNSN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNSNNNNNNNNNSNNNNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNNNNNNNSNNSNSSNNSNNNSS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSSNNSNSNNNNNNNNSSNNSNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSSNNNNSNNNNNNNNNNNNNNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSNNNSSSNSNSNNNNNSNNNNNNNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "SSNNNNNNNNNNNNNNSNNNNNNNNS" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSSNNNNNNNNNNNNNNNNNNNNSNN" || WAREA_AUXILIAR.FILLER_14.W_DPS_VDMULHER == "NSSNNNNNNNNNNNSNSNNNNNNNNN")
                    {

                        /*" -3763- ELSE */
                    }
                    else
                    {


                        /*" -3764- IF PRODUTO-AUTOMOVEL */

                        if (LBWPF002.W_PRODUTO["PRODUTO_AUTOMOVEL"])
                        {

                            /*" -3765- PERFORM R0336-00-MOVTO-CLAUSULA-AUTO */

                            R0336_00_MOVTO_CLAUSULA_AUTO_SECTION();

                            /*" -3766- ELSE */
                        }
                        else
                        {


                            /*" -3767- IF PRODUTO-MULTIRISCO */

                            if (LBWPF002.W_PRODUTO["PRODUTO_MULTIRISCO"])
                            {

                                /*" -3768- PERFORM R0337-MOVTO-DIV-MULTIRISCO */

                                R0337_MOVTO_DIV_MULTIRISCO_SECTION();

                                /*" -3769- ELSE */
                            }
                            else
                            {


                                /*" -3770- IF VIDAZUL-EMPRESARIAL-SUPER */

                                if (LBWPF002.W_PRODUTO["VIDAZUL_EMPRESARIAL_SUPER"])
                                {

                                    /*" -3771- PERFORM R0338-MOVTO-DIV-VD-EMPRESARIAL */

                                    R0338_MOVTO_DIV_VD_EMPRESARIAL_SECTION();

                                    /*" -3772- ELSE */
                                }
                                else
                                {


                                    /*" -3773- IF PROTECAO-EXECUTIVA */

                                    if (LBWPF002.W_PRODUTO["PROTECAO_EXECUTIVA"])
                                    {

                                        /*" -3774- PERFORM R0340-MOVTO-DIV-VD-EMPRESA */

                                        R0340_MOVTO_DIV_VD_EMPRESA_SECTION();

                                        /*" -3775- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3776- DISPLAY 'VA0600B FIM ANORMAL' */
                                        _.Display($"VA0600B FIM ANORMAL");

                                        /*" -3777- DISPLAY '     PROCESSO NAO PREPARADO PARA TRATAR' */
                                        _.Display($"     PROCESSO NAO PREPARADO PARA TRATAR");

                                        /*" -3778- DISPLAY '     REGISTRO -6- PARA ESTE PRODUTO.' */
                                        _.Display($"     REGISTRO -6- PARA ESTE PRODUTO.");

                                        /*" -3780- DISPLAY '     NUMERO DA PROPOSTA..............  ' R3-NUM-PROPOSTA */
                                        _.Display($"     NUMERO DA PROPOSTA..............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                                        /*" -3782- DISPLAY '     PRODUTO DA PROPOSTA.............  ' R3-COD-PRODUTO */
                                        _.Display($"     PRODUTO DA PROPOSTA.............  {LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO}");

                                        /*" -3783- PERFORM R9988-00-FECHAR-ARQUIVOS */

                                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                                        /*" -3783- GO TO R9999-00-FINALIZAR. */

                                        R9999_00_FINALIZAR_SECTION(); //GOTO
                                        return;
                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0335_SAIDA*/

        [StopWatch]
        /*" R0336-00-MOVTO-CLAUSULA-AUTO-SECTION */
        private void R0336_00_MOVTO_CLAUSULA_AUTO_SECTION()
        {
            /*" -3790- MOVE 'R0336-00-MOVTO-CLAUSULA-AUTO' TO PARAGRAFO. */
            _.Move("R0336-00-MOVTO-CLAUSULA-AUTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3792- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3794- MOVE 1 TO W-MOVTO-AUTO */
            _.Move(1, WREA88.W_MOVTO_AUTO);

            /*" -3796- MOVE 'SIM' TO W-EXISTE-TP-6 */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_6);

            /*" -3798- ADD 1 TO W-IND-CLAU-N */
            WAREA_AUXILIAR.W_IND_CLAU_N.Value = WAREA_AUXILIAR.W_IND_CLAU_N + 1;

            /*" -3799- IF W-IND-CLAU-N GREATER 300 */

            if (WAREA_AUXILIAR.W_IND_CLAU_N > 300)
            {

                /*" -3800- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -3801- DISPLAY '          ESTOURO TABELA CLAUSULAS AUTOMOVEL' */
                _.Display($"          ESTOURO TABELA CLAUSULAS AUTOMOVEL");

                /*" -3803- DISPLAY '          NUMERO DA PROPOSTA............  ' R6-NUM-PROPOSTA OF REG-VAL-ACESSORIOS */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF016.REG_VAL_ACESSORIOS.R6_NUM_PROPOSTA}");

                /*" -3805- DISPLAY '          W-IND-CLAU-N..................  ' W-IND-CLAU-N */
                _.Display($"          W-IND-CLAU-N..................  {WAREA_AUXILIAR.W_IND_CLAU_N}");

                /*" -3806- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3808- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -3808- MOVE REG-SIGAT TO W-TB-REG-CLAUSULA(W-IND-CLAU-N). */
            _.Move(MOV_SIGAT?.Value, WAREA_AUXILIAR.W_TAB_CLAUSULAS.W_TAB_CLAU_REG[WAREA_AUXILIAR.W_IND_CLAU_N].W_TB_REG_CLAUSULA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0336_SAIDA*/

        [StopWatch]
        /*" R0337-MOVTO-DIV-MULTIRISCO-SECTION */
        private void R0337_MOVTO_DIV_MULTIRISCO_SECTION()
        {
            /*" -3815- MOVE 'R0337-00-MOVTO-DIV-MULTIRISCO' TO PARAGRAFO. */
            _.Move("R0337-00-MOVTO-DIV-MULTIRISCO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3817- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3819- MOVE 1 TO W-MOVTO-RISCO */
            _.Move(1, WREA88.W_MOVTO_RISCO);

            /*" -3821- MOVE 'SIM' TO W-EXISTE-TP-6 */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_6);

            /*" -3824- ADD 1 TO W-IND-RISCO-N */
            WAREA_AUXILIAR.W_IND_RISCO_N.Value = WAREA_AUXILIAR.W_IND_RISCO_N + 1;

            /*" -3825- IF W-IND-RISCO-N GREATER 998 */

            if (WAREA_AUXILIAR.W_IND_RISCO_N > 998)
            {

                /*" -3826- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -3827- DISPLAY '          ESTOURO TABELA DE DIVERSOS MULTIRISCO' */
                _.Display($"          ESTOURO TABELA DE DIVERSOS MULTIRISCO");

                /*" -3829- DISPLAY '          NUMERO DA PROPOSTA.................  ' R3-NUM-PROPOSTA */
                _.Display($"          NUMERO DA PROPOSTA.................  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -3831- DISPLAY '          W-IND-RISCO-N......................  ' W-IND-RISCO-N */
                _.Display($"          W-IND-RISCO-N......................  {WAREA_AUXILIAR.W_IND_RISCO_N}");

                /*" -3832- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3834- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -3835- IF W-IND-RISCO-N EQUAL 1 */

            if (WAREA_AUXILIAR.W_IND_RISCO_N == 1)
            {

                /*" -3836- MOVE REG-SIGAT TO REG-TIPO-6-AUX */
                _.Move(MOV_SIGAT?.Value, REG_TIPO_6_AUX);

                /*" -3837- MOVE RENOV-AUTOM-6-AUX TO R3-RENOVACAO-AUTOM */
                _.Move(REG_TIPO_6_AUX.RENOV_AUTOM_6_AUX, LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM);

                /*" -3838- IF R3-RENOVACAO-AUTOM NOT EQUAL 'S' */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM != "S")
                {

                    /*" -3839- MOVE 'N' TO R3-RENOVACAO-AUTOM */
                    _.Move("N", LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM);

                    /*" -3840- END-IF */
                }


                /*" -3843- END-IF. */
            }


            /*" -3844- MOVE REG-SIGAT TO W-TB-REG-DIV-M-RISCO(W-IND-RISCO-N). */
            _.Move(MOV_SIGAT?.Value, WAREA_AUXILIAR.W_TAB_DIV_M_RISCO.W_TAB_RISCO_REG[WAREA_AUXILIAR.W_IND_RISCO_N].W_TB_REG_DIV_M_RISCO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0337_SAIDA*/

        [StopWatch]
        /*" R0338-MOVTO-DIV-VD-EMPRESARIAL-SECTION */
        private void R0338_MOVTO_DIV_VD_EMPRESARIAL_SECTION()
        {
            /*" -3850- MOVE 'R0338-00-MOVTO-DIV-VD-EMPRESARIAL' TO PARAGRAFO. */
            _.Move("R0338-00-MOVTO-DIV-VD-EMPRESARIAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3851- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3853- MOVE 1 TO W-MOVTO-VDEMP */
            _.Move(1, WREA88.W_MOVTO_VDEMP);

            /*" -3855- MOVE 'SIM' TO W-EXISTE-TP-6 */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_6);

            /*" -3857- ADD 1 TO W-IND-VDEMP-N */
            WAREA_AUXILIAR.W_IND_VDEMP_N.Value = WAREA_AUXILIAR.W_IND_VDEMP_N + 1;

            /*" -3858- IF W-IND-VDEMP-N GREATER 990 */

            if (WAREA_AUXILIAR.W_IND_VDEMP_N > 990)
            {

                /*" -3859- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -3860- DISPLAY '          ESTOURO TABELA DE DIVERSOS EMPRESARIAL' */
                _.Display($"          ESTOURO TABELA DE DIVERSOS EMPRESARIAL");

                /*" -3862- DISPLAY '          NUMERO DA PROPOSTA.................  ' R3-NUM-PROPOSTA */
                _.Display($"          NUMERO DA PROPOSTA.................  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -3864- DISPLAY '          W-IND-VDEMP-N......................  ' W-IND-VDEMP-N */
                _.Display($"          W-IND-VDEMP-N......................  {WAREA_AUXILIAR.W_IND_VDEMP_N}");

                /*" -3865- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3867- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -3868- MOVE REG-SIGAT TO W-TB-REG-DIV-VDEMP(W-IND-VDEMP-N). */
            _.Move(MOV_SIGAT?.Value, WAREA_AUXILIAR.W_TAB_DIV_VDEMP.W_TAB_VDEMP_REG[WAREA_AUXILIAR.W_IND_VDEMP_N].W_TB_REG_DIV_VDEMP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0338_SAIDA*/

        [StopWatch]
        /*" R0340-MOVTO-DIV-VD-EMPRESA-SECTION */
        private void R0340_MOVTO_DIV_VD_EMPRESA_SECTION()
        {
            /*" -3874- MOVE 'R0340-00-MOVTO-DIV-VD-EMPRESA    ' TO PARAGRAFO. */
            _.Move("R0340-00-MOVTO-DIV-VD-EMPRESA    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3875- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3877- MOVE 1 TO W-MOVTO-PEXEC */
            _.Move(1, WREA88.W_MOVTO_PEXEC);

            /*" -3879- MOVE 'SIM' TO W-EXISTE-TP-6 */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_6);

            /*" -3880- MOVE REG-SIGAT TO REGISTRO-EMPRESA. */
            _.Move(MOV_SIGAT?.Value, LBFPF164.REGISTRO_EMPRESA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_SAIDA*/

        [StopWatch]
        /*" R0350-00-CRITICAS-TIPO-B-SECTION */
        private void R0350_00_CRITICAS_TIPO_B_SECTION()
        {
            /*" -3886- MOVE 'R0350-00-CRITICAS-TIPO-B' TO PARAGRAFO. */
            _.Move("R0350-00-CRITICAS-TIPO-B", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3887- MOVE 'CRITICAR PROPOSTAS      ' TO COMANDO. */
            _.Move("CRITICAR PROPOSTAS      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3889- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3891- IF R24-COD-TIPO-ASSISTENCIA EQUAL SPACES OR HIGH-VALUES OR LOW-VALUES */

            if (LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_COD_TIPO_ASSISTENCIA.IsEmpty() || LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_COD_TIPO_ASSISTENCIA.IsHighValues || LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_COD_TIPO_ASSISTENCIA.IsLowValues())
            {

                /*" -3892- MOVE ZEROS TO W-AIC-TIPO-ASSIST */
                _.Move(0, WREA88.W_AIC_TIPO_ASSIST);

                /*" -3893- ELSE */
            }
            else
            {


                /*" -3894- MOVE R24-COD-TIPO-ASSISTENCIA TO W-AIC-TIPO-ASSIST */
                _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_COD_TIPO_ASSISTENCIA, WREA88.W_AIC_TIPO_ASSIST);

                /*" -3897- IF (W-COD-TIPO-ASSIST NOT NUMERIC) OR (W-COD-TIPO-ASSIST GREATER 003) */

                if ((!WREA88.W_AIC_TIPO_ASSIST.W_COD_TIPO_ASSIST.IsNumeric()) || (WREA88.W_AIC_TIPO_ASSIST.W_COD_TIPO_ASSIST > 003))
                {

                    /*" -3898- MOVE 2 TO W-CRITICA-PROPOSTA */
                    _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                    /*" -3899- ADD 1 TO W-INDICE-1 */
                    WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                    /*" -3902- MOVE 19 TO W-TB-COD-DESCRI(W-INDICE-1) */
                    _.Move(19, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                    /*" -3904- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3906- DISPLAY 'PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3908- DISPLAY 'FALHA NO TIPO DE ASSISTENCIA: ' R24-COD-TIPO-ASSISTENCIA */
                    _.Display($"FALHA NO TIPO DE ASSISTENCIA: {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_COD_TIPO_ASSISTENCIA}");

                    /*" -3909- END-IF */
                }


                /*" -3911- END-IF */
            }


            /*" -3912- DISPLAY 'REG B RECEBIDO NA MATRIZ' */
            _.Display($"REG B RECEBIDO NA MATRIZ");

            /*" -3913- DISPLAY ' NUMERO DA PROPOSTA ..: ' R24-NUM-PROPOSTA */
            _.Display($" NUMERO DA PROPOSTA ..: {LXFPF024.REG_TIPO_B.R24_NUM_PROPOSTA}");

            /*" -3914- DISPLAY ' R24-IND-SUBS-DINAMICA: ' R24-IND-SUBS-DINAMICA */
            _.Display($" R24-IND-SUBS-DINAMICA: {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_IND_SUBS_DINAMICA}");

            /*" -3915- DISPLAY ' R24-TP-SUBS-DINAMICA : ' R24-TP-SUBS-DINAMICA */
            _.Display($" R24-TP-SUBS-DINAMICA : {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_TP_SUBS_DINAMICA}");

            /*" -3916- DISPLAY ' R3-VAL-PAGO .........: ' R3-VAL-PAGO */
            _.Display($" R3-VAL-PAGO .........: {LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO}");

            /*" -3917- DISPLAY ' R3-VALOR-PREMIO-TOTAL: ' R3-VALOR-PREMIO-TOTAL */
            _.Display($" R3-VALOR-PREMIO-TOTAL: {LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL}");

            /*" -3918- DISPLAY ' R24-VLR-PRM-BRUTO ...: ' R24-VLR-PRM-BRUTO */
            _.Display($" R24-VLR-PRM-BRUTO ...: {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VLR_PRM_BRUTO}");

            /*" -3919- DISPLAY ' R24-VERSAO-MATRIZ ...: ' R24-VERSAO-MATRIZ */
            _.Display($" R24-VERSAO-MATRIZ ...: {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VERSAO_MATRIZ}");

            /*" -3920- DISPLAY ' R24-PERCENTUAL-APLICA: ' R24-PERCENTUAL-APLICADO */
            _.Display($" R24-PERCENTUAL-APLICA: {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_PERCENTUAL_APLICADO}");

            /*" -3922- DISPLAY ' R24-COD-TIPO-ASSIST .: ' W-COD-TIPO-ASSIST */
            _.Display($" R24-COD-TIPO-ASSIST .: {WREA88.W_AIC_TIPO_ASSIST.W_COD_TIPO_ASSIST}");

            /*" -3923- IF SEM-MATRIZ */

            if (WREA88.N88_MATRIZ["SEM_MATRIZ"])
            {

                /*" -3924- CONTINUE */

                /*" -3926- ELSE */
            }
            else
            {


                /*" -3928- IF ORIGEM-AUTO-COMPRA-IBC OR ORIGEM-AUTO-COMPRA-LOJA */

                if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_IBC"] || WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_LOJA"])
                {

                    /*" -3929- MOVE R3-VALOR-PREMIO-TOTAL TO WHOST-PRM-PAGO-MA */
                    _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL, WHOST_PRM_PAGO_MA);

                    /*" -3930- ELSE */
                }
                else
                {


                    /*" -3931- MOVE R3-VAL-PAGO TO WHOST-PRM-PAGO-MA */
                    _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, WHOST_PRM_PAGO_MA);

                    /*" -3933- END-IF */
                }


                /*" -3935- IF R24-TP-SUBS-DINAMICA NOT EQUAL 'AGRAVO' AND 'DESCONTO' */

                if (!LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_TP_SUBS_DINAMICA.In("AGRAVO", "DESCONTO"))
                {

                    /*" -3936- MOVE 'S' TO N88-ERRO-MATRIZ */
                    _.Move("S", WREA88.N88_ERRO_MATRIZ);

                    /*" -3938- END-IF */
                }


                /*" -3940- IF (R24-VLR-PRM-BRUTO NOT NUMERIC) OR (R24-VLR-PRM-BRUTO EQUAL ZEROS) */

                if ((!LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VLR_PRM_BRUTO.IsNumeric()) || (LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VLR_PRM_BRUTO == 00))
                {

                    /*" -3941- MOVE 'S' TO N88-ERRO-MATRIZ */
                    _.Move("S", WREA88.N88_ERRO_MATRIZ);

                    /*" -3947- END-IF */
                }


                /*" -3948- IF R24-TP-SUBS-DINAMICA EQUAL 'AGRAVO' */

                if (LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_TP_SUBS_DINAMICA == "AGRAVO")
                {

                    /*" -3949- IF WHOST-PRM-PAGO-MA NOT GREATER R24-VLR-PRM-BRUTO */

                    if (WHOST_PRM_PAGO_MA <= LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VLR_PRM_BRUTO)
                    {

                        /*" -3950- MOVE 'S' TO N88-ERRO-MATRIZ */
                        _.Move("S", WREA88.N88_ERRO_MATRIZ);

                        /*" -3951- END-IF */
                    }


                    /*" -3952- ELSE */
                }
                else
                {


                    /*" -3953- IF WHOST-PRM-PAGO-MA NOT LESS R24-VLR-PRM-BRUTO */

                    if (WHOST_PRM_PAGO_MA >= LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VLR_PRM_BRUTO)
                    {

                        /*" -3954- MOVE 'S' TO N88-ERRO-MATRIZ */
                        _.Move("S", WREA88.N88_ERRO_MATRIZ);

                        /*" -3955- END-IF */
                    }


                    /*" -3957- END-IF */
                }


                /*" -3959- IF (R24-VERSAO-MATRIZ NOT NUMERIC) OR (R24-VERSAO-MATRIZ EQUAL ZEROS) */

                if ((!LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VERSAO_MATRIZ.IsNumeric()) || (LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VERSAO_MATRIZ == 00))
                {

                    /*" -3960- MOVE 'S' TO N88-ERRO-MATRIZ */
                    _.Move("S", WREA88.N88_ERRO_MATRIZ);

                    /*" -3962- END-IF */
                }


                /*" -3964- IF (R24-PERCENTUAL-APLICADO NOT NUMERIC) OR (R24-PERCENTUAL-APLICADO EQUAL ZEROS) */

                if ((!LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_PERCENTUAL_APLICADO.IsNumeric()) || (LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_PERCENTUAL_APLICADO == 00))
                {

                    /*" -3965- MOVE 'S' TO N88-ERRO-MATRIZ */
                    _.Move("S", WREA88.N88_ERRO_MATRIZ);

                    /*" -3967- END-IF */
                }


                /*" -3968- IF ERRO-MATRIZ */

                if (WREA88.N88_ERRO_MATRIZ["ERRO_MATRIZ"])
                {

                    /*" -3969- MOVE 2 TO W-CRITICA-PROPOSTA */
                    _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                    /*" -3970- ADD 1 TO W-INDICE-1 */
                    WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                    /*" -3973- MOVE 16 TO W-TB-COD-DESCRI(W-INDICE-1) */
                    _.Move(16, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                    /*" -3975- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3977- DISPLAY 'PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3978- DISPLAY 'FALHA NO AGRAVO/DESCONTO NA MATRIZ' */
                    _.Display($"FALHA NO AGRAVO/DESCONTO NA MATRIZ");

                    /*" -3979- DISPLAY 'NUMERO DA PROPOSTA ..: ' R24-NUM-PROPOSTA */
                    _.Display($"NUMERO DA PROPOSTA ..: {LXFPF024.REG_TIPO_B.R24_NUM_PROPOSTA}");

                    /*" -3980- DISPLAY 'R24-IND-SUBS-DINAMICA: ' R24-IND-SUBS-DINAMICA */
                    _.Display($"R24-IND-SUBS-DINAMICA: {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_IND_SUBS_DINAMICA}");

                    /*" -3981- DISPLAY 'R24-TP-SUBS-DINAMICA : ' R24-TP-SUBS-DINAMICA */
                    _.Display($"R24-TP-SUBS-DINAMICA : {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_TP_SUBS_DINAMICA}");

                    /*" -3982- DISPLAY 'R24-VLR-PRM-BRUTO ...: ' R24-VLR-PRM-BRUTO */
                    _.Display($"R24-VLR-PRM-BRUTO ...: {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VLR_PRM_BRUTO}");

                    /*" -3983- DISPLAY 'R3-VAL-PAGO .........: ' R3-VAL-PAGO */
                    _.Display($"R3-VAL-PAGO .........: {LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO}");

                    /*" -3984- DISPLAY 'R24-VERSAO-MATRIZ ...: ' R24-VERSAO-MATRIZ */
                    _.Display($"R24-VERSAO-MATRIZ ...: {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VERSAO_MATRIZ}");

                    /*" -3986- DISPLAY 'R24-PERCENTUAL-APLICA: ' R24-PERCENTUAL-APLICADO */
                    _.Display($"R24-PERCENTUAL-APLICA: {LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_PERCENTUAL_APLICADO}");

                    /*" -3987- END-IF */
                }


                /*" -3989- END-IF */
            }


            /*" -3992- PERFORM R0352-00-VALIDA-PLANO THRU R0352-99-SAIDA */

            R0352_00_VALIDA_PLANO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0352_99_SAIDA*/


            /*" -3993- IF POSSUI-PLANO */

            if (WREA88.W_POSSUI_PLANO["POSSUI_PLANO"])
            {

                /*" -3994- CONTINUE */

                /*" -3995- ELSE */
            }
            else
            {


                /*" -3996- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -3997- ADD 1 TO W-INDICE-1 */
                WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                /*" -4000- MOVE 20 TO W-TB-COD-DESCRI(W-INDICE-1) */
                _.Move(20, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                /*" -4002- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4004- DISPLAY 'PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4005- DISPLAY 'FALHA AO RECUPERAR O PLANO COMERCIALIZADO' */
                _.Display($"FALHA AO RECUPERAR O PLANO COMERCIALIZADO");

                /*" -4006- DISPLAY 'NUMERO DA APOLICE  ' VG130-NUM-APOLICE */
                _.Display($"NUMERO DA APOLICE  {VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}");

                /*" -4007- DISPLAY 'CODIGO DO SUBGRUPO ' VG130-COD-SUBGRUPO */
                _.Display($"CODIGO DO SUBGRUPO {VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}");

                /*" -4008- DISPLAY 'OPCAO DE COBERTURA ' WHOST-OPCAO-COBER */
                _.Display($"OPCAO DE COBERTURA {WHOST_OPCAO_COBER}");

                /*" -4009- DISPLAY 'DATA DE QUITACAO   ' WHOST-DATA-QUITACAO */
                _.Display($"DATA DE QUITACAO   {WHOST_DATA_QUITACAO}");

                /*" -4010- DISPLAY 'DATA DA PROPOSTA   ' WHOST-DATA-PROPOSTA */
                _.Display($"DATA DA PROPOSTA   {WHOST_DATA_PROPOSTA}");

                /*" -4011- DISPLAY 'IDADE              ' WHOST-IDADE */
                _.Display($"IDADE              {WHOST_IDADE}");

                /*" -4012- DISPLAY 'VALOR PREMIO PROP. ' WHOST-PRM-TOTAL-MA */
                _.Display($"VALOR PREMIO PROP. {WHOST_PRM_TOTAL_MA}");

                /*" -4013- DISPLAY 'CANAL DA PROPOSTA  ' W-CANAL-PROPOSTA */
                _.Display($"CANAL DA PROPOSTA  {WREA88.CANAL.W_CANAL_PROPOSTA}");

                /*" -4015- END-IF */
            }


            /*" -4016- IF PROPOSTA-COM-CRITICA */

            if (WREA88.W_CRITICA_PROPOSTA["PROPOSTA_COM_CRITICA"])
            {

                /*" -4017- ADD 1 TO W-QTD-CRITICA */
                WAREA_AUXILIAR.W_QTD_CRITICA.Value = WAREA_AUXILIAR.W_QTD_CRITICA + 1;

                /*" -4022- PERFORM R0050-00-LER-MOV-SIGAT UNTIL W-FIM-MOVTO-SIGAT EQUAL 'FIM' OR REG-TIPO-SIGAT OF REG-SIGAT EQUAL 'T' OR REG-NUM-PROPOSTA OF REG-SIGAT NOT EQUAL W-NUM-PROPOSTA-ANT */

                while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM" || REG_SIGAT.REG_TIPO_SIGAT == "T" || REG_SIGAT.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
                {

                    R0050_00_LER_MOV_SIGAT_SECTION();
                }

                /*" -4024- END-IF */
            }


            /*" -4024- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0352-00-VALIDA-PLANO-SECTION */
        private void R0352_00_VALIDA_PLANO_SECTION()
        {
            /*" -4031- MOVE 'R0352-00-VALIDA-PLANO' TO PARAGRAFO */
            _.Move("R0352-00-VALIDA-PLANO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4033- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4034- MOVE 'SELECT VG_PLANO_SUBGRUPO' TO COMANDO */
            _.Move("SELECT VG_PLANO_SUBGRUPO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4036- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4037- INITIALIZE DCLVG-PLANO-SUBGRUPO */
            _.Initialize(
                VG130.DCLVG_PLANO_SUBGRUPO
            );

            /*" -4038- MOVE R3-COD-PRODUTO TO VG130-COD-PRODUTO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO_SIVPF);

            /*" -4039- MOVE R3-OPCAO-COBER TO VG130-COD-OPCAO-COBER */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_OPCAO_COBER);

            /*" -4040- MOVE R3-PERIPGTO TO VG130-IND-PERIOD-PGTO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO, VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_PERIOD_PGTO);

            /*" -4041- IF R3-OPCAO-CONJUGE NOT EQUAL 'S' */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE != "S")
            {

                /*" -4042- MOVE 'N' TO R3-OPCAO-CONJUGE */
                _.Move("N", LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE);

                /*" -4043- END-IF */
            }


            /*" -4044- MOVE R3-OPCAO-CONJUGE TO VG130-IND-OPCAO-CONJUGE */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE, VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE);

            /*" -4045- MOVE W-COD-TIPO-ASSIST TO VG130-COD-TIPO-ASSISTENCIA */
            _.Move(WREA88.W_AIC_TIPO_ASSIST.W_COD_TIPO_ASSIST, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA);

            /*" -4046- MOVE R3-DATA-PROPOSTA(1:2) TO WHOST-DATA-PROPOSTA(9:2) */
            _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(1, 2), WHOST_DATA_PROPOSTA, 9, 2);

            /*" -4047- MOVE '-' TO WHOST-DATA-PROPOSTA(8:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 8, 1);

            /*" -4048- MOVE R3-DATA-PROPOSTA(3:2) TO WHOST-DATA-PROPOSTA(6:2) */
            _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(3, 2), WHOST_DATA_PROPOSTA, 6, 2);

            /*" -4049- MOVE '-' TO WHOST-DATA-PROPOSTA(5:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 5, 1);

            /*" -4051- MOVE R3-DATA-PROPOSTA(5:4) TO WHOST-DATA-PROPOSTA(1:4) */
            _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(5, 4), WHOST_DATA_PROPOSTA, 1, 4);

            /*" -4068- PERFORM R0352_00_VALIDA_PLANO_DB_SELECT_1 */

            R0352_00_VALIDA_PLANO_DB_SELECT_1();

            /*" -4071- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4072- MOVE VG130-NUM-APOLICE TO WHOST-APOLICE-PLANO */
                _.Move(VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE, WHOST_APOLICE_PLANO);

                /*" -4073- MOVE VG130-COD-SUBGRUPO TO WHOST-CODSUBES-PLANO */
                _.Move(VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO, WHOST_CODSUBES_PLANO);

                /*" -4082- DISPLAY '# /' VG130-COD-PRODUTO-SIVPF '/' VG130-COD-OPCAO-COBER '/' VG130-IND-PERIOD-PGTO '/' VG130-IND-OPCAO-CONJUGE '/' VG130-COD-TIPO-ASSISTENCIA '/' WHOST-DATA-PROPOSTA '/' VG130-NUM-APOLICE '/' VG130-COD-SUBGRUPO */

                $"# /{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO_SIVPF}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_OPCAO_COBER}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_PERIOD_PGTO}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA}/{WHOST_DATA_PROPOSTA}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}"
                .Display();

                /*" -4083- ELSE */
            }
            else
            {


                /*" -4084- DISPLAY 'VA0600B FIM ANORMAL' */
                _.Display($"VA0600B FIM ANORMAL");

                /*" -4085- DISPLAY 'R0352-ERRO SELECT VG_PLANO_SUBGRUPO' */
                _.Display($"R0352-ERRO SELECT VG_PLANO_SUBGRUPO");

                /*" -4093- DISPLAY 'PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '/' VG130-COD-PRODUTO-SIVPF '/' VG130-COD-OPCAO-COBER '/' VG130-IND-PERIOD-PGTO '/' VG130-IND-OPCAO-CONJUGE '/' VG130-COD-TIPO-ASSISTENCIA '/' WHOST-DATA-PROPOSTA */

                $"PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO_SIVPF}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_OPCAO_COBER}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_PERIOD_PGTO}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA}/{WHOST_DATA_PROPOSTA}"
                .Display();

                /*" -4094- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4095- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -4097- END-IF */
            }


            /*" -4098- MOVE 'PESQUISA PLANO VALIDO ' TO COMANDO */
            _.Move("PESQUISA PLANO VALIDO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4100- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4102- MOVE R3-OPCAO-COBER TO WHOST-OPCAO-COBER */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, WHOST_OPCAO_COBER);

            /*" -4103- IF CANAL-VENDA-INTERNET */

            if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_INTERNET"])
            {

                /*" -4104- MOVE R3-DATA-PROPOSTA(1:2) TO WHOST-DATA-QUITACAO(9:2) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(1, 2), WHOST_DATA_QUITACAO, 9, 2);

                /*" -4105- MOVE '-' TO WHOST-DATA-QUITACAO(8:1) */
                _.MoveAtPosition("-", WHOST_DATA_QUITACAO, 8, 1);

                /*" -4106- MOVE R3-DATA-PROPOSTA(3:2) TO WHOST-DATA-QUITACAO(6:2) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(3, 2), WHOST_DATA_QUITACAO, 6, 2);

                /*" -4107- MOVE '-' TO WHOST-DATA-QUITACAO(5:1) */
                _.MoveAtPosition("-", WHOST_DATA_QUITACAO, 5, 1);

                /*" -4108- MOVE R3-DATA-PROPOSTA(5:4) TO WHOST-DATA-QUITACAO(1:4) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(5, 4), WHOST_DATA_QUITACAO, 1, 4);

                /*" -4109- ELSE */
            }
            else
            {


                /*" -4110- MOVE R3-DTQITBCO(1:2) TO WHOST-DATA-QUITACAO(9:2) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.Substring(1, 2), WHOST_DATA_QUITACAO, 9, 2);

                /*" -4111- MOVE '-' TO WHOST-DATA-QUITACAO(8:1) */
                _.MoveAtPosition("-", WHOST_DATA_QUITACAO, 8, 1);

                /*" -4112- MOVE R3-DTQITBCO(3:2) TO WHOST-DATA-QUITACAO(6:2) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.Substring(3, 2), WHOST_DATA_QUITACAO, 6, 2);

                /*" -4113- MOVE '-' TO WHOST-DATA-QUITACAO(5:1) */
                _.MoveAtPosition("-", WHOST_DATA_QUITACAO, 5, 1);

                /*" -4114- MOVE R3-DTQITBCO(5:4) TO WHOST-DATA-QUITACAO(1:4) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.Substring(5, 4), WHOST_DATA_QUITACAO, 1, 4);

                /*" -4117- END-IF */
            }


            /*" -4134- PERFORM R0352_00_VALIDA_PLANO_DB_SELECT_2 */

            R0352_00_VALIDA_PLANO_DB_SELECT_2();

            /*" -4137-  EVALUATE SQLCODE  */

            /*" -4138-  WHEN ZEROS  */

            /*" -4138- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4139- MOVE 1 TO W-POSSUI-PLANO */
                _.Move(1, WREA88.W_POSSUI_PLANO);

                /*" -4140-  WHEN +100  */

                /*" -4140- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -4141- IF VIDA-CONFORTO */

                if (LBWPF002.W_PRODUTO["VIDA_CONFORTO"])
                {

                    /*" -4142- PERFORM R0354-00-VALIDA-PLANO */

                    R0354_00_VALIDA_PLANO_SECTION();

                    /*" -4143- ELSE */
                }
                else
                {


                    /*" -4144- MOVE 0 TO W-POSSUI-PLANO */
                    _.Move(0, WREA88.W_POSSUI_PLANO);

                    /*" -4145- END-IF */
                }


                /*" -4146-  WHEN OTHER  */

                /*" -4146- ELSE */
            }
            else
            {


                /*" -4147- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4148- DISPLAY 'ERRO NO ACESSO A PLANOS_VA_VGAP - R0352 ' */
                _.Display($"ERRO NO ACESSO A PLANOS_VA_VGAP - R0352 ");

                /*" -4150- DISPLAY 'NUMERO DA PROPOSTA ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO DA PROPOSTA {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4151- DISPLAY 'NUMERO DA APOLICE  ' VG130-NUM-APOLICE */
                _.Display($"NUMERO DA APOLICE  {VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}");

                /*" -4152- DISPLAY 'CODIGO DO SUBGRUPO ' VG130-COD-SUBGRUPO */
                _.Display($"CODIGO DO SUBGRUPO {VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}");

                /*" -4153- DISPLAY 'OPCAO DE COBERTURA ' WHOST-OPCAO-COBER */
                _.Display($"OPCAO DE COBERTURA {WHOST_OPCAO_COBER}");

                /*" -4154- DISPLAY 'DATA DA PROPOSTA   ' WHOST-DATA-PROPOSTA */
                _.Display($"DATA DA PROPOSTA   {WHOST_DATA_PROPOSTA}");

                /*" -4155- DISPLAY 'DATA DA QUITACAO   ' WHOST-DATA-QUITACAO */
                _.Display($"DATA DA QUITACAO   {WHOST_DATA_QUITACAO}");

                /*" -4156- DISPLAY 'VALOR PREMIO PROP. ' WHOST-PRM-TOTAL-MA */
                _.Display($"VALOR PREMIO PROP. {WHOST_PRM_TOTAL_MA}");

                /*" -4157- DISPLAY 'CANAL DA PROPOSTA  ' W-CANAL-PROPOSTA */
                _.Display($"CANAL DA PROPOSTA  {WREA88.CANAL.W_CANAL_PROPOSTA}");

                /*" -4158- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4159- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -4161-  END-EVALUATE  */

                /*" -4161- END-IF */
            }


            /*" -4161- . */

        }

        [StopWatch]
        /*" R0352-00-VALIDA-PLANO-DB-SELECT-1 */
        public void R0352_00_VALIDA_PLANO_DB_SELECT_1()
        {
            /*" -4068- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , COD_PRODUTO INTO :VG130-NUM-APOLICE , :VG130-COD-SUBGRUPO , :VG130-COD-PRODUTO FROM SEGUROS.VG_PLANO_SUBGRUPO WHERE COD_EMPRESA_SIVPF = 001 AND COD_PRODUTO_SIVPF = :VG130-COD-PRODUTO-SIVPF AND COD_OPCAO_COBER = :VG130-COD-OPCAO-COBER AND IND_PERIOD_PGTO = :VG130-IND-PERIOD-PGTO AND IND_OPCAO_CONJUGE = :VG130-IND-OPCAO-CONJUGE AND COD_TIPO_ASSISTENCIA = :VG130-COD-TIPO-ASSISTENCIA AND :WHOST-DATA-PROPOSTA BETWEEN DTA_INI_VIGENCIA AND DTA_FIM_VIGENCIA AND STA_REGISTRO = '0' END-EXEC */

            var r0352_00_VALIDA_PLANO_DB_SELECT_1_Query1 = new R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1()
            {
                VG130_COD_TIPO_ASSISTENCIA = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA.ToString(),
                VG130_COD_PRODUTO_SIVPF = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO_SIVPF.ToString(),
                VG130_IND_OPCAO_CONJUGE = VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE.ToString(),
                VG130_COD_OPCAO_COBER = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_OPCAO_COBER.ToString(),
                VG130_IND_PERIOD_PGTO = VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_PERIOD_PGTO.ToString(),
                WHOST_DATA_PROPOSTA = WHOST_DATA_PROPOSTA.ToString(),
            };

            var executed_1 = R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1.Execute(r0352_00_VALIDA_PLANO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG130_NUM_APOLICE, VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE);
                _.Move(executed_1.VG130_COD_SUBGRUPO, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO);
                _.Move(executed_1.VG130_COD_PRODUTO, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0352_99_SAIDA*/

        [StopWatch]
        /*" R0352-00-VALIDA-PLANO-DB-SELECT-2 */
        public void R0352_00_VALIDA_PLANO_DB_SELECT_2()
        {
            /*" -4134- EXEC SQL SELECT NUM_APOLICE , CODSUBES , VLPREMIOTOT INTO :WHOST-APOLICE-PLANO , :WHOST-CODSUBES-PLANO , :PLAVAVGA-VLPREMIOTOT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :VG130-NUM-APOLICE AND CODSUBES = :VG130-COD-SUBGRUPO AND OPCAO_COBER = :WHOST-OPCAO-COBER AND ((:WHOST-DATA-PROPOSTA BETWEEN DTINIVIG AND DTTERVIG) OR (:WHOST-DATA-QUITACAO BETWEEN DTINIVIG AND DTTERVIG)) AND VLPREMIOTOT = :WHOST-PRM-TOTAL-MA WITH UR END-EXEC */

            var r0352_00_VALIDA_PLANO_DB_SELECT_2_Query1 = new R0352_00_VALIDA_PLANO_DB_SELECT_2_Query1()
            {
                WHOST_DATA_PROPOSTA = WHOST_DATA_PROPOSTA.ToString(),
                WHOST_DATA_QUITACAO = WHOST_DATA_QUITACAO.ToString(),
                VG130_COD_SUBGRUPO = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO.ToString(),
                WHOST_PRM_TOTAL_MA = WHOST_PRM_TOTAL_MA.ToString(),
                VG130_NUM_APOLICE = VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE.ToString(),
                WHOST_OPCAO_COBER = WHOST_OPCAO_COBER.ToString(),
            };

            var executed_1 = R0352_00_VALIDA_PLANO_DB_SELECT_2_Query1.Execute(r0352_00_VALIDA_PLANO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_APOLICE_PLANO, WHOST_APOLICE_PLANO);
                _.Move(executed_1.WHOST_CODSUBES_PLANO, WHOST_CODSUBES_PLANO);
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
            }


        }

        [StopWatch]
        /*" R0354-00-VALIDA-PLANO-SECTION */
        private void R0354_00_VALIDA_PLANO_SECTION()
        {
            /*" -4169- MOVE 'R0354-00-VALIDA-PLANO' TO PARAGRAFO */
            _.Move("R0354-00-VALIDA-PLANO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4170- MOVE 'PESQUISA PLANO VIDA CONFORTO' TO COMANDO */
            _.Move("PESQUISA PLANO VIDA CONFORTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4171- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4174- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4190- PERFORM R0354_00_VALIDA_PLANO_DB_SELECT_1 */

            R0354_00_VALIDA_PLANO_DB_SELECT_1();

            /*" -4193-  EVALUATE SQLCODE  */

            /*" -4194-  WHEN ZEROS  */

            /*" -4194- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4195- MOVE 1 TO W-POSSUI-PLANO */
                _.Move(1, WREA88.W_POSSUI_PLANO);

                /*" -4196-  WHEN +100  */

                /*" -4196- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -4197- MOVE 0 TO W-POSSUI-PLANO */
                _.Move(0, WREA88.W_POSSUI_PLANO);

                /*" -4198-  WHEN OTHER  */

                /*" -4198- ELSE */
            }
            else
            {


                /*" -4199- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4200- DISPLAY 'ERRO NO ACESSO A PLANOS_VA_VGAP - R0354 ' */
                _.Display($"ERRO NO ACESSO A PLANOS_VA_VGAP - R0354 ");

                /*" -4202- DISPLAY 'NUMERO DA PROPOSTA ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO DA PROPOSTA {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4203- DISPLAY 'NUMERO DA APOLICE  ' VG130-NUM-APOLICE */
                _.Display($"NUMERO DA APOLICE  {VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}");

                /*" -4204- DISPLAY 'CODIGO DO SUBGRUPO ' VG130-COD-SUBGRUPO */
                _.Display($"CODIGO DO SUBGRUPO {VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}");

                /*" -4205- DISPLAY 'OPCAO DE COBERTURA ' WHOST-OPCAO-COBER */
                _.Display($"OPCAO DE COBERTURA {WHOST_OPCAO_COBER}");

                /*" -4206- DISPLAY 'DATA DA PROPOSTA   ' WHOST-DATA-PROPOSTA */
                _.Display($"DATA DA PROPOSTA   {WHOST_DATA_PROPOSTA}");

                /*" -4207- DISPLAY 'DATA DA QUITACAO   ' WHOST-DATA-QUITACAO */
                _.Display($"DATA DA QUITACAO   {WHOST_DATA_QUITACAO}");

                /*" -4208- DISPLAY 'VALOR PREMIO PROP. ' WHOST-PRM-TOTAL-MA */
                _.Display($"VALOR PREMIO PROP. {WHOST_PRM_TOTAL_MA}");

                /*" -4209- DISPLAY 'CANAL DA PROPOSTA  ' W-CANAL-PROPOSTA */
                _.Display($"CANAL DA PROPOSTA  {WREA88.CANAL.W_CANAL_PROPOSTA}");

                /*" -4210- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4211- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -4213-  END-EVALUATE  */

                /*" -4213- END-IF */
            }


            /*" -4213- . */

        }

        [StopWatch]
        /*" R0354-00-VALIDA-PLANO-DB-SELECT-1 */
        public void R0354_00_VALIDA_PLANO_DB_SELECT_1()
        {
            /*" -4190- EXEC SQL SELECT NUM_APOLICE , CODSUBES , VLPREMIOTOT INTO :WHOST-APOLICE-PLANO , :WHOST-CODSUBES-PLANO , :PLAVAVGA-VLPREMIOTOT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :VG130-NUM-APOLICE AND CODSUBES = :VG130-COD-SUBGRUPO AND OPCAO_COBER = :WHOST-OPCAO-COBER AND ((:WHOST-DATA-PROPOSTA BETWEEN DTINIVIG AND DTTERVIG) OR (:WHOST-DATA-QUITACAO BETWEEN DTINIVIG AND DTTERVIG)) WITH UR END-EXEC */

            var r0354_00_VALIDA_PLANO_DB_SELECT_1_Query1 = new R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1()
            {
                WHOST_DATA_PROPOSTA = WHOST_DATA_PROPOSTA.ToString(),
                WHOST_DATA_QUITACAO = WHOST_DATA_QUITACAO.ToString(),
                VG130_COD_SUBGRUPO = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO.ToString(),
                VG130_NUM_APOLICE = VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE.ToString(),
                WHOST_OPCAO_COBER = WHOST_OPCAO_COBER.ToString(),
            };

            var executed_1 = R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1.Execute(r0354_00_VALIDA_PLANO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_APOLICE_PLANO, WHOST_APOLICE_PLANO);
                _.Move(executed_1.WHOST_CODSUBES_PLANO, WHOST_CODSUBES_PLANO);
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0354_99_SAIDA*/

        [StopWatch]
        /*" R0476-00-GERAR-HEADER-VDEMP-SECTION */
        private void R0476_00_GERAR_HEADER_VDEMP_SECTION()
        {
            /*" -4220- MOVE 'R0476-00-GERAR-HEADER-VDEMP' TO PARAGRAFO. */
            _.Move("R0476-00-GERAR-HEADER-VDEMP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4221- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4223- MOVE 2 TO W-HEADER-VDEMP. */
            _.Move(2, WREA88.W_HEADER_VDEMP);

            /*" -4224- MOVE SPACES TO REG-MOV-VDEMP */
            _.Move("", REG_MOV_VDEMP);

            /*" -4225- MOVE REG-HEADER TO REG-MOV-VDEMP */
            _.Move(LBFPF990.REG_HEADER, REG_MOV_VDEMP);

            /*" -4226- WRITE REG-MOV-VDEMP. */
            MOV_VDEMP.Write(REG_MOV_VDEMP.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0476_SAIDA*/

        [StopWatch]
        /*" R0480-00-GERAR-TAB-PF-SECTION */
        private void R0480_00_GERAR_TAB_PF_SECTION()
        {
            /*" -4232- MOVE 'R0480-00-GERAR-TAB-PF' TO PARAGRAFO. */
            _.Move("R0480-00-GERAR-TAB-PF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4233- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4235- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4236- PERFORM R0500-TRATA-CLIENTE */

            R0500_TRATA_CLIENTE_SECTION();

            /*" -4237- PERFORM R0600-TRATA-END-TEL */

            R0600_TRATA_END_TEL_SECTION();

            /*" -4239- PERFORM R0700-TRATA-PROPOSTA */

            R0700_TRATA_PROPOSTA_SECTION();

            /*" -4240- IF W-EXISTE-TP-4 EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_4 == "SIM")
            {

                /*" -4243- IF PRODUTO-AUTOMOVEL OR PRODUTO-MULTIRISCO NEXT SENTENCE */

                if (LBWPF002.W_PRODUTO["PRODUTO_AUTOMOVEL"] || LBWPF002.W_PRODUTO["PRODUTO_MULTIRISCO"])
                {

                    /*" -4244- ELSE */
                }
                else
                {


                    /*" -4245- PERFORM R0800-TRATA-BENEFICIARIOS */

                    R0800_TRATA_BENEFICIARIOS_SECTION();

                    /*" -4246- END-IF */
                }


                /*" -4250- END-IF. */
            }


            /*" -4252- IF VIDAZUL-EMPRESARIAL-SUPER NEXT SENTENCE */

            if (LBWPF002.W_PRODUTO["VIDAZUL_EMPRESARIAL_SUPER"])
            {

                /*" -4253- ELSE */
            }
            else
            {


                /*" -4254- IF W-EXISTE-TP-B EQUAL 'SIM' */

                if (WAREA_AUXILIAR.W_EXISTE_TP_B == "SIM")
                {

                    /*" -4255- PERFORM R0850-TRATA-TIPO-B */

                    R0850_TRATA_TIPO_B_SECTION();

                    /*" -4256- END-IF */
                }


                /*" -4258- END-IF. */
            }


            /*" -4259- IF W-EXISTE-TP-5 EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_5 == "SIM")
            {

                /*" -4262- PERFORM R0900-TRATA-INF-COMPLEMENTARES VARYING W-IND-INFO1 FROM 1 BY 1 UNTIL W-IND-INFO1 GREATER W-IND-INFO-N */

                for (WAREA_AUXILIAR.W_IND_INFO1.Value = 1; !(WAREA_AUXILIAR.W_IND_INFO1 > WAREA_AUXILIAR.W_IND_INFO_N); WAREA_AUXILIAR.W_IND_INFO1.Value += 1)
                {

                    R0900_TRATA_INF_COMPLEMENTARES_SECTION();
                }

                /*" -4264- END-IF. */
            }


            /*" -4265- IF W-EXISTE-TP-C EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_C == "SIM")
            {

                /*" -4266- PERFORM R0910-TRATA-INF-SICAQWEB */

                R0910_TRATA_INF_SICAQWEB_SECTION();

                /*" -4268- END-IF. */
            }


            /*" -4272- IF W-EXISTE-TP-D EQUAL 'SIM' AND RSD-NOME-SOCIAL NOT EQUAL SPACES AND RSD-NOME-SOCIAL NOT EQUAL LOW-VALUES AND RSD-NOME-SOCIAL NOT EQUAL HIGH-VALUES */

            if (WAREA_AUXILIAR.W_EXISTE_TP_D == "SIM" && !LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL.IsEmpty() && LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL != "" && LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL.IsHighValues)
            {

                /*" -4273- PERFORM R1000-INCLUI-NOME-SOCIAL */

                R1000_INCLUI_NOME_SOCIAL_SECTION();

                /*" -4275- END-IF. */
            }


            /*" -4276- IF SEGURO-VIDA-MULHER */

            if (LBWPF002.W_PRODUTO["SEGURO_VIDA_MULHER"])
            {

                /*" -4277- IF W-EXISTE-TP-6 EQUAL 'SIM' */

                if (WAREA_AUXILIAR.W_EXISTE_TP_6 == "SIM")
                {

                    /*" -4278- IF R6-INFORMACOES-DO-MEDICO NOT EQUAL SPACES */

                    if (!LBFPF161.REGISTRO_VIDA_MULHER.R6_INFORMACOES_DO_MEDICO.IsEmpty())
                    {

                        /*" -4279- PERFORM R0950-INF-MEDICO-VIDA-MULHER */

                        R0950_INF_MEDICO_VIDA_MULHER_SECTION();

                        /*" -4280- END-IF */
                    }


                    /*" -4281- END-IF */
                }


                /*" -4283- END-IF. */
            }


            /*" -4284- IF PROTECAO-EXECUTIVA */

            if (LBWPF002.W_PRODUTO["PROTECAO_EXECUTIVA"])
            {

                /*" -4285- IF W-EXISTE-TP-6 EQUAL 'SIM' */

                if (WAREA_AUXILIAR.W_EXISTE_TP_6 == "SIM")
                {

                    /*" -4286- IF REGISTRO-EMPRESA NOT EQUAL SPACES */

                    if (!LBFPF164.REGISTRO_EMPRESA.IsEmpty())
                    {

                        /*" -4287- PERFORM R0952-INF-EMPRESA-PEXECUTIVA */

                        R0952_INF_EMPRESA_PEXECUTIVA_SECTION();

                        /*" -4288- END-IF */
                    }


                    /*" -4289- END-IF */
                }


                /*" -4291- END-IF. */
            }


            /*" -4295- IF BILHETE-AP OR PRODUTOS-VIDA-INDIVIDUAL OR PRODUTOS-VIDA-INDIVIDUAL-93 OR SEGURO-PRESTAMISTA OR VIDA-EXCLUSIVO-AIC */

            if (LBWPF002.W_PRODUTO["BILHETE_AP"] || LBWPF002.W_PRODUTO["PRODUTOS_VIDA_INDIVIDUAL"] || LBWPF002.W_PRODUTO["PRODUTOS_VIDA_INDIVIDUAL_93"] || LBWPF002.W_PRODUTO["SEGURO_PRESTAMISTA"] || LBWPF002.W_PRODUTO["VIDA_EXCLUSIVO_AIC"])
            {

                /*" -4297- MOVE SPACES TO CBO-DESCR-CBO WS-DESCR-CBO WS-DESCR-CBO-1 */
                _.Move("", CBO.DCLCBO.CBO_DESCR_CBO, WAREA_AUXILIAR.WS_DESCR_CBO, WAREA_AUXILIAR.WS_DESCR_CBO_1);

                /*" -4299- PERFORM R0490-00-OBTER-CBO */

                R0490_00_OBTER_CBO_SECTION();

                /*" -4300- IF CBO-NAO-ENCONTRADO */

                if (WREA88.W_LEITURA_CBO["CBO_NAO_ENCONTRADO"])
                {

                    /*" -4302- MOVE 'PROFISSAO NAO CADASTRADA' TO R1-DESCRICAO-PROFISSAO */
                    _.Move("PROFISSAO NAO CADASTRADA", LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                    /*" -4303- ELSE */
                }
                else
                {


                    /*" -4305- MOVE CBO-DESCR-CBO TO WS-DESCR-CBO */
                    _.Move(CBO.DCLCBO.CBO_DESCR_CBO, WAREA_AUXILIAR.WS_DESCR_CBO);

                    /*" -4308- IF CBO-DESCR-CBO EQUAL 'OUTROS' OR WS-DESCR-CBO EQUAL 'SERVIDOR PUBLICO' */

                    if (CBO.DCLCBO.CBO_DESCR_CBO == "OUTROS" || WAREA_AUXILIAR.WS_DESCR_CBO == "SERVIDOR PUBLICO")
                    {

                        /*" -4309- IF R1-DESCRICAO-PROFISSAO EQUAL SPACES */

                        if (LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO.IsEmpty())
                        {

                            /*" -4311- MOVE 'PROFISSAO NAO QUALIFICADA' TO R1-DESCRICAO-PROFISSAO */
                            _.Move("PROFISSAO NAO QUALIFICADA", LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                            /*" -4312- ELSE */
                        }
                        else
                        {


                            /*" -4314- MOVE R1-DESCRICAO-PROFISSAO TO WS-DESCR-CBO WS-DESCR-CBO-1 */
                            _.Move(LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO, WAREA_AUXILIAR.WS_DESCR_CBO, WAREA_AUXILIAR.WS_DESCR_CBO_1);

                            /*" -4315- IF WS-DESCR-INI EQUAL 'OUTROS ' */

                            if (WAREA_AUXILIAR.WS_DESCR_CBO_R.WS_DESCR_INI == "OUTROS ")
                            {

                                /*" -4316- IF WS-DESCR-FIM NOT EQUAL SPACES */

                                if (!WAREA_AUXILIAR.WS_DESCR_CBO_R.WS_DESCR_FIM.IsEmpty())
                                {

                                    /*" -4318- MOVE WS-DESCR-FIM TO R1-DESCRICAO-PROFISSAO */
                                    _.Move(WAREA_AUXILIAR.WS_DESCR_CBO_R.WS_DESCR_FIM, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                                    /*" -4319- END-IF */
                                }


                                /*" -4320- END-IF */
                            }


                            /*" -4321- END-IF */
                        }


                        /*" -4322- END-IF */
                    }


                    /*" -4323- END-IF */
                }


                /*" -4324- PERFORM R0495-00-INCLUIR-PF-CBO */

                R0495_00_INCLUIR_PF_CBO_SECTION();

                /*" -4324- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0480_SAIDA*/

        [StopWatch]
        /*" R0490-00-OBTER-CBO-SECTION */
        private void R0490_00_OBTER_CBO_SECTION()
        {
            /*" -4331- MOVE 'R0490-00-OBTER-CBO     ' TO PARAGRAFO. */
            _.Move("R0490-00-OBTER-CBO     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4333- MOVE 'SELECT SEGUROS.CBO' TO COMANDO. */
            _.Move("SELECT SEGUROS.CBO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4335- MOVE WS-COD-CBO TO CBO-COD-CBO */
            _.Move(WAREA_AUXILIAR.WS_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);

            /*" -4341- PERFORM R0490_00_OBTER_CBO_DB_SELECT_1 */

            R0490_00_OBTER_CBO_DB_SELECT_1();

            /*" -4344- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4345- MOVE 1 TO W-LEITURA-CBO */
                _.Move(1, WREA88.W_LEITURA_CBO);

                /*" -4346- ELSE */
            }
            else
            {


                /*" -4347- MOVE 2 TO W-LEITURA-CBO */
                _.Move(2, WREA88.W_LEITURA_CBO);

                /*" -4347- END-IF. */
            }


        }

        [StopWatch]
        /*" R0490-00-OBTER-CBO-DB-SELECT-1 */
        public void R0490_00_OBTER_CBO_DB_SELECT_1()
        {
            /*" -4341- EXEC SQL SELECT VALUE(DESCR_CBO, ' ' ) INTO :CBO-DESCR-CBO FROM SEGUROS.CBO WHERE COD_CBO = :CBO-COD-CBO WITH UR END-EXEC. */

            var r0490_00_OBTER_CBO_DB_SELECT_1_Query1 = new R0490_00_OBTER_CBO_DB_SELECT_1_Query1()
            {
                CBO_COD_CBO = CBO.DCLCBO.CBO_COD_CBO.ToString(),
            };

            var executed_1 = R0490_00_OBTER_CBO_DB_SELECT_1_Query1.Execute(r0490_00_OBTER_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0490_SAIDA*/

        [StopWatch]
        /*" R0495-00-INCLUIR-PF-CBO-SECTION */
        private void R0495_00_INCLUIR_PF_CBO_SECTION()
        {
            /*" -4354- MOVE 'R0495-00-INCLUIR-PF-CBO' TO PARAGRAFO. */
            _.Move("R0495-00-INCLUIR-PF-CBO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4356- MOVE 'INSERT SEGUROS.PF_CBO' TO COMANDO. */
            _.Move("INSERT SEGUROS.PF_CBO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4357- MOVE R1-NUM-PROPOSTA TO PF062-NUM-PROPOSTA-SIVPF */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA, PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF);

            /*" -4358- MOVE WS-COD-CBO TO PF062-COD-CBO */
            _.Move(WAREA_AUXILIAR.WS_COD_CBO, PF062.DCLPF_CBO.PF062_COD_CBO);

            /*" -4360- MOVE R1-DESCRICAO-PROFISSAO TO PF062-DES-CBO */
            _.Move(LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO, PF062.DCLPF_CBO.PF062_DES_CBO);

            /*" -4365- PERFORM R0495_00_INCLUIR_PF_CBO_DB_INSERT_1 */

            R0495_00_INCLUIR_PF_CBO_DB_INSERT_1();

            /*" -4368- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -4369- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4370- DISPLAY '          ERRO INSERT DA TABELA PF_CBO' */
                _.Display($"          ERRO INSERT DA TABELA PF_CBO");

                /*" -4372- DISPLAY '          NUMERO PROPOSTA...........  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...........  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4374- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -4375- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4376- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -4378- END-IF. */
            }


            /*" -4379- IF (COD-CBO OF DCLPESSOA-FISICA NOT EQUAL WS-COD-CBO) */

            if ((PESFIS.DCLPESSOA_FISICA.COD_CBO != WAREA_AUXILIAR.WS_COD_CBO))
            {

                /*" -4381- MOVE WS-COD-CBO TO COD-CBO OF DCLPESSOA-FISICA */
                _.Move(WAREA_AUXILIAR.WS_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

                /*" -4385- PERFORM R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1 */

                R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1();

                /*" -4388- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -4389- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -4390- DISPLAY '          PROBLEMA UPDATE PESSOA-FISICA' */
                    _.Display($"          PROBLEMA UPDATE PESSOA-FISICA");

                    /*" -4392- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -4394- DISPLAY '          COD-PESSOA....................  ' COD-CBO OF DCLPESSOA-FISICA */
                    _.Display($"          COD-PESSOA....................  {PESFIS.DCLPESSOA_FISICA.COD_CBO}");

                    /*" -4396- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4397- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4398- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -4399- END-IF */
                }


                /*" -4399- END-IF. */
            }


        }

        [StopWatch]
        /*" R0495-00-INCLUIR-PF-CBO-DB-INSERT-1 */
        public void R0495_00_INCLUIR_PF_CBO_DB_INSERT_1()
        {
            /*" -4365- EXEC SQL INSERT INTO SEGUROS.PF_CBO VALUES (:PF062-NUM-PROPOSTA-SIVPF, :PF062-COD-CBO , :PF062-DES-CBO) END-EXEC. */

            var r0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1 = new R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1()
            {
                PF062_NUM_PROPOSTA_SIVPF = PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF.ToString(),
                PF062_COD_CBO = PF062.DCLPF_CBO.PF062_COD_CBO.ToString(),
                PF062_DES_CBO = PF062.DCLPF_CBO.PF062_DES_CBO.ToString(),
            };

            R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1.Execute(r0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0495-00-INCLUIR-PF-CBO-DB-UPDATE-1 */
        public void R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1()
        {
            /*" -4385- EXEC SQL UPDATE SEGUROS.PESSOA_FISICA SET COD_CBO = :DCLPESSOA-FISICA.COD-CBO WHERE COD_PESSOA = :DCLPESSOA-FISICA.COD-PESSOA END-EXEC */

            var r0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1 = new R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1()
            {
                COD_CBO = PESFIS.DCLPESSOA_FISICA.COD_CBO.ToString(),
                COD_PESSOA = PESFIS.DCLPESSOA_FISICA.COD_PESSOA.ToString(),
            };

            R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1.Execute(r0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0495_SAIDA*/

        [StopWatch]
        /*" R0500-TRATA-CLIENTE-SECTION */
        private void R0500_TRATA_CLIENTE_SECTION()
        {
            /*" -4406- MOVE 'R0500-TRATA-CLIENTE' TO PARAGRAFO. */
            _.Move("R0500-TRATA-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4415- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4417- ADD 1 TO W-QTD-LD-SIVPF-1 */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_1.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_1 + 1;

            /*" -4418- IF R1-DATA-NASCIMENTO OF REG-CLIENTES EQUAL ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO == 00)
            {

                /*" -4419- MOVE 01010001 TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                _.Move(01010001, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                /*" -4421- END-IF */
            }


            /*" -4422- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -4423- PERFORM R0505-LER-PESSOA-FISICA */

                R0505_LER_PESSOA_FISICA_SECTION();

                /*" -4424- ELSE */
            }
            else
            {


                /*" -4425- PERFORM R0510-LER-PESSOA-JURIDICA */

                R0510_LER_PESSOA_JURIDICA_SECTION();

                /*" -4427- END-IF */
            }


            /*" -4428- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4429- PERFORM R0515-INCLUIR-TAB-CORPORATIVAS */

                R0515_INCLUIR_TAB_CORPORATIVAS_SECTION();

                /*" -4430- ELSE */
            }
            else
            {


                /*" -4431- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -4434- PERFORM R0550-LER-TAB-CORPORATIVAS */

                    R0550_LER_TAB_CORPORATIVAS_SECTION();

                    /*" -4435- PERFORM R0535-INCLUIR-END-EMAIL */

                    R0535_INCLUIR_END_EMAIL_SECTION();

                    /*" -4436- END-IF */
                }


                /*" -4438- END-IF */
            }


            /*" -4438- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0505-LER-PESSOA-FISICA-SECTION */
        private void R0505_LER_PESSOA_FISICA_SECTION()
        {
            /*" -4445- MOVE 'R0505-LER-PESSOA-FISICA' TO PARAGRAFO. */
            _.Move("R0505-LER-PESSOA-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4446- MOVE 'SELECT PESSOA_FISICA' TO COMANDO. */
            _.Move("SELECT PESSOA_FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4449- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -4452- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

            /*" -4455- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_19.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -4458- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_19.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -4461- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_19.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -4465- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -4468- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -4469- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -4471- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -4472- ELSE */
            }
            else
            {


                /*" -4475- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -4506- PERFORM R0505_LER_PESSOA_FISICA_DB_SELECT_1 */

            R0505_LER_PESSOA_FISICA_DB_SELECT_1();

            /*" -4509- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4510- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4511- DISPLAY '          ERRO NO ACESSO A PESSOA-FISICA  ' */
                _.Display($"          ERRO NO ACESSO A PESSOA-FISICA  ");

                /*" -4513- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4515- DISPLAY '          CPF...........................  ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF...........................  {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -4517- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                /*" -4519- DISPLAY '          SEXO..........................  ' SEXO OF DCLPESSOA-FISICA */
                _.Display($"          SEXO..........................  {PESFIS.DCLPESSOA_FISICA.SEXO}");

                /*" -4521- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4522- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4525- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -4528- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -4530- PERFORM R0507-CORRIGE-PESSOA-FISICA */

                R0507_CORRIGE_PESSOA_FISICA_SECTION();

                /*" -4530- END-IF. */
            }


        }

        [StopWatch]
        /*" R0505-LER-PESSOA-FISICA-DB-SELECT-1 */
        public void R0505_LER_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -4506- EXEC SQL SELECT COD_PESSOA, CPF, DATA_NASCIMENTO, SEXO, TIPO_IDENT_SIVPF, NUM_IDENTIDADE, ORGAO_EXPEDIDOR, UF_EXPEDIDORA, DATA_EXPEDICAO, COD_CBO, COD_USUARIO, ESTADO_CIVIL, TIMESTAMP INTO :DCLPESSOA-FISICA.COD-PESSOA:VIND-COD-PESSOA, :DCLPESSOA-FISICA.CPF:VIND-CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO:VIND-DTNASCI, :DCLPESSOA-FISICA.SEXO:VIND-SEXO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF:VIND-TP-IDENT, :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NUM-IDENT, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-ORGAO-EXP, :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UF-EXP, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO:VIND-COD-CBO, :DCLPESSOA-FISICA.COD-USUARIO:VIND-COD-USUR, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.TIMESTAMP:VIND-TIMESTAMP FROM SEGUROS.PESSOA_FISICA WHERE CPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND SEXO = :DCLPESSOA-FISICA.SEXO END-EXEC. */

            var r0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1 = new R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESFIS.DCLPESSOA_FISICA.COD_PESSOA);
                _.Move(executed_1.VIND_COD_PESSOA, VIND_COD_PESSOA);
                _.Move(executed_1.CPF, PESFIS.DCLPESSOA_FISICA.CPF);
                _.Move(executed_1.VIND_CPF, VIND_CPF);
                _.Move(executed_1.DATA_NASCIMENTO, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASCI, VIND_DTNASCI);
                _.Move(executed_1.SEXO, PESFIS.DCLPESSOA_FISICA.SEXO);
                _.Move(executed_1.VIND_SEXO, VIND_SEXO);
                _.Move(executed_1.TIPO_IDENT_SIVPF, PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);
                _.Move(executed_1.VIND_TP_IDENT, VIND_TP_IDENT);
                _.Move(executed_1.NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);
                _.Move(executed_1.VIND_NUM_IDENT, VIND_NUM_IDENT);
                _.Move(executed_1.ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);
                _.Move(executed_1.VIND_ORGAO_EXP, VIND_ORGAO_EXP);
                _.Move(executed_1.UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UF_EXP, VIND_UF_EXP);
                _.Move(executed_1.DATA_EXPEDICAO, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DTEXPEDI, VIND_DTEXPEDI);
                _.Move(executed_1.COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);
                _.Move(executed_1.VIND_COD_CBO, VIND_COD_CBO);
                _.Move(executed_1.COD_USUARIO, PESFIS.DCLPESSOA_FISICA.COD_USUARIO);
                _.Move(executed_1.VIND_COD_USUR, VIND_COD_USUR);
                _.Move(executed_1.ESTADO_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                _.Move(executed_1.TIMESTAMP, PESFIS.DCLPESSOA_FISICA.TIMESTAMP);
                _.Move(executed_1.VIND_TIMESTAMP, VIND_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0505_SAIDA*/

        [StopWatch]
        /*" R0507-CORRIGE-PESSOA-FISICA-SECTION */
        private void R0507_CORRIGE_PESSOA_FISICA_SECTION()
        {
            /*" -4539- MOVE 'R0507-CORRIGE-PESSOA-FISICA' TO PARAGRAFO */
            _.Move("R0507-CORRIGE-PESSOA-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4542- MOVE 'UPDATE PESSOA_FISICA' TO COMANDO */
            _.Move("UPDATE PESSOA_FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4543- MOVE SPACES TO WS-ESTADO-CIVIL */
            _.Move("", WAREA_AUXILIAR.WS_ESTADO_CIVIL);

            /*" -4545- MOVE '*' TO N88-CORRIGE-PF */
            _.Move("*", WREA88.N88_CORRIGE_PF);

            /*" -4546- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 1)
            {

                /*" -4547- MOVE 'S' TO WS-ESTADO-CIVIL */
                _.Move("S", WAREA_AUXILIAR.WS_ESTADO_CIVIL);

                /*" -4548- ELSE */
            }
            else
            {


                /*" -4549- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 2)
                {

                    /*" -4550- MOVE 'C' TO WS-ESTADO-CIVIL */
                    _.Move("C", WAREA_AUXILIAR.WS_ESTADO_CIVIL);

                    /*" -4551- ELSE */
                }
                else
                {


                    /*" -4552- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 3 */

                    if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 3)
                    {

                        /*" -4553- MOVE 'V' TO WS-ESTADO-CIVIL */
                        _.Move("V", WAREA_AUXILIAR.WS_ESTADO_CIVIL);

                        /*" -4554- ELSE */
                    }
                    else
                    {


                        /*" -4555- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 4 */

                        if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 4)
                        {

                            /*" -4556- MOVE 'O' TO WS-ESTADO-CIVIL */
                            _.Move("O", WAREA_AUXILIAR.WS_ESTADO_CIVIL);

                            /*" -4557- ELSE */
                        }
                        else
                        {


                            /*" -4558- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 5 */

                            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 5)
                            {

                                /*" -4559- MOVE 'D' TO WS-ESTADO-CIVIL */
                                _.Move("D", WAREA_AUXILIAR.WS_ESTADO_CIVIL);

                                /*" -4560- ELSE */
                            }
                            else
                            {


                                /*" -4561- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 6 */

                                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 6)
                                {

                                    /*" -4562- MOVE 'J' TO WS-ESTADO-CIVIL */
                                    _.Move("J", WAREA_AUXILIAR.WS_ESTADO_CIVIL);

                                    /*" -4564- END-IF. */
                                }

                            }

                        }

                    }

                }

            }


            /*" -4566- IF (ESTADO-CIVIL OF DCLPESSOA-FISICA NOT EQUAL WS-ESTADO-CIVIL) */

            if ((PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL != WAREA_AUXILIAR.WS_ESTADO_CIVIL))
            {

                /*" -4567- MOVE 'S' TO N88-CORRIGE-PF */
                _.Move("S", WREA88.N88_CORRIGE_PF);

                /*" -4570- END-IF */
            }


            /*" -4571- MOVE ZEROS TO W-QTD-DIG-RG */
            _.Move(0, W_QTD_DIG_RG);

            /*" -4573- MOVE NUM-IDENTIDADE OF DCLPESSOA-FISICA TO W-LIT-RG */
            _.Move(PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE, W_LIT_RG);

            /*" -4576- PERFORM VARYING IND-RG FROM 001 BY 001 UNTIL IND-RG GREATER 015 */

            for (IND_RG.Value = 001; !(IND_RG > 015); IND_RG.Value += 001)
            {

                /*" -4577- IF W-LIT-RG-NUM(IND-RG) IS NUMERIC */

                if (W_LIT_RG.W_LIT_RG_NUM[IND_RG].IsNumeric())
                {

                    /*" -4578- ADD W-LIT-RG-NUM(IND-RG) TO W-QTD-DIG-RG */
                    W_QTD_DIG_RG.Value = W_QTD_DIG_RG + W_LIT_RG.W_LIT_RG_NUM[IND_RG];

                    /*" -4579- END-IF */
                }


                /*" -4582- END-PERFORM */
            }

            /*" -4592- IF (W-QTD-DIG-RG EQUAL ZEROS) OR ((ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA EQUAL SPACES OR LOW-VALUES) OR (VIND-ORGAO-EXP LESS ZEROS)) OR ((UF-EXPEDIDORA OF DCLPESSOA-FISICA EQUAL SPACES OR LOW-VALUES) OR (VIND-UF-EXP LESS ZEROS)) */

            if ((W_QTD_DIG_RG == 00) || ((PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.IsLowValues()) || (VIND_ORGAO_EXP < 00)) || ((PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA.IsLowValues()) || (VIND_UF_EXP < 00)))
            {

                /*" -4593- MOVE 'S' TO N88-CORRIGE-PF */
                _.Move("S", WREA88.N88_CORRIGE_PF);

                /*" -4595- END-IF */
            }


            /*" -4596- IF NOT CORRIGE-PF */

            if (!WREA88.N88_CORRIGE_PF["CORRIGE_PF"])
            {

                /*" -4597- GO TO R0507-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0507_SAIDA*/ //GOTO
                return;

                /*" -4600- END-IF */
            }


            /*" -4602- MOVE WS-ESTADO-CIVIL TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
            _.Move(WAREA_AUXILIAR.WS_ESTADO_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

            /*" -4604- MOVE R1-NUM-IDENTIDADE TO NUM-IDENTIDADE OF DCLPESSOA-FISICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);

            /*" -4606- MOVE R1-ORGAO-EXPEDIDOR TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

            /*" -4608- MOVE R1-UF-EXPEDIDORA TO UF-EXPEDIDORA OF DCLPESSOA-FISICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

            /*" -4609- MOVE R1-DATA-EXPEDICAO-RG(1:2) TO WHOST-DATA-EXP-RG(9:2) */
            _.MoveAtPosition(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG.Substring(1, 2), WHOST_DATA_EXP_RG, 9, 2);

            /*" -4610- MOVE '-' TO WHOST-DATA-EXP-RG(8:1) */
            _.MoveAtPosition("-", WHOST_DATA_EXP_RG, 8, 1);

            /*" -4611- MOVE R1-DATA-EXPEDICAO-RG(3:2) TO WHOST-DATA-EXP-RG(6:2) */
            _.MoveAtPosition(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG.Substring(3, 2), WHOST_DATA_EXP_RG, 6, 2);

            /*" -4612- MOVE '-' TO WHOST-DATA-EXP-RG(5:1) */
            _.MoveAtPosition("-", WHOST_DATA_EXP_RG, 5, 1);

            /*" -4613- MOVE R1-DATA-EXPEDICAO-RG(5:4) TO WHOST-DATA-EXP-RG(1:4) */
            _.MoveAtPosition(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG.Substring(5, 4), WHOST_DATA_EXP_RG, 1, 4);

            /*" -4617- MOVE WHOST-DATA-EXP-RG TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
            _.Move(WHOST_DATA_EXP_RG, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

            /*" -4627- PERFORM R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1 */

            R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1();

            /*" -4630- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4631- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4632- DISPLAY '          PROBLEMA UPDATE PESSOA-FISICA' */
                _.Display($"          PROBLEMA UPDATE PESSOA-FISICA");

                /*" -4634- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4636- DISPLAY '          CPF...........................  ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF...........................  {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -4638- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                /*" -4640- DISPLAY '          SEXO..........................  ' SEXO OF DCLPESSOA-FISICA */
                _.Display($"          SEXO..........................  {PESFIS.DCLPESSOA_FISICA.SEXO}");

                /*" -4642- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4643- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4644- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -4646- END-IF */
            }


            /*" -4646- . */

        }

        [StopWatch]
        /*" R0507-CORRIGE-PESSOA-FISICA-DB-UPDATE-1 */
        public void R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1()
        {
            /*" -4627- EXEC SQL UPDATE SEGUROS.PESSOA_FISICA SET ESTADO_CIVIL = :DCLPESSOA-FISICA.ESTADO-CIVIL , NUM_IDENTIDADE = :DCLPESSOA-FISICA.NUM-IDENTIDADE, ORGAO_EXPEDIDOR = :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, UF_EXPEDIDORA = :DCLPESSOA-FISICA.UF-EXPEDIDORA, DATA_EXPEDICAO = :WHOST-DATA-EXP-RG , TIPO_IDENT_SIVPF = ' ' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_PESSOA = :DCLPESSOA-FISICA.COD-PESSOA END-EXEC */

            var r0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1 = new R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1()
            {
                ORGAO_EXPEDIDOR = PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.ToString(),
                NUM_IDENTIDADE = PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE.ToString(),
                UF_EXPEDIDORA = PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                WHOST_DATA_EXP_RG = WHOST_DATA_EXP_RG.ToString(),
                COD_PESSOA = PESFIS.DCLPESSOA_FISICA.COD_PESSOA.ToString(),
            };

            R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1.Execute(r0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0507_SAIDA*/

        [StopWatch]
        /*" R0510-LER-PESSOA-JURIDICA-SECTION */
        private void R0510_LER_PESSOA_JURIDICA_SECTION()
        {
            /*" -4653- MOVE 'R0510-LER-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R0510-LER-PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4654- MOVE 'SELECT' TO COMANDO. */
            _.Move("SELECT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4657- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -4670- PERFORM R0510_LER_PESSOA_JURIDICA_DB_SELECT_1 */

            R0510_LER_PESSOA_JURIDICA_DB_SELECT_1();

            /*" -4673- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4674- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4675- DISPLAY '          ERRO NO ACESSO A PESSOA-JURIDICA' */
                _.Display($"          ERRO NO ACESSO A PESSOA-JURIDICA");

                /*" -4677- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4679- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4680- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4680- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0510-LER-PESSOA-JURIDICA-DB-SELECT-1 */
        public void R0510_LER_PESSOA_JURIDICA_DB_SELECT_1()
        {
            /*" -4670- EXEC SQL SELECT COD_PESSOA, CGC, NOME_FANTASIA, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, :DCLPESSOA-JURIDICA.TIMESTAMP FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLPESSOA-JURIDICA.CGC END-EXEC. */

            var r0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 = new R0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1()
            {
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
            };

            var executed_1 = R0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1.Execute(r0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);
                _.Move(executed_1.CGC, PESJUR.DCLPESSOA_JURIDICA.CGC);
                _.Move(executed_1.NOME_FANTASIA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);
                _.Move(executed_1.COD_USUARIO, PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESJUR.DCLPESSOA_JURIDICA.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_SAIDA*/

        [StopWatch]
        /*" R0515-INCLUIR-TAB-CORPORATIVAS-SECTION */
        private void R0515_INCLUIR_TAB_CORPORATIVAS_SECTION()
        {
            /*" -4687- MOVE 'R0515-INCLUIR-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R0515-INCLUIR-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4688- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4690- PERFORM R0520-INCLUIR-TAB-PESSOA. */

            R0520_INCLUIR_TAB_PESSOA_SECTION();

            /*" -4691- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -4692- PERFORM R0525-INCLUIR-PESSOA-FISICA */

                R0525_INCLUIR_PESSOA_FISICA_SECTION();

                /*" -4693- ELSE */
            }
            else
            {


                /*" -4695- PERFORM R0530-INCLUIR-PESSOA-JURIDICA. */

                R0530_INCLUIR_PESSOA_JURIDICA_SECTION();
            }


            /*" -4695- PERFORM R0535-INCLUIR-END-EMAIL. */

            R0535_INCLUIR_END_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0515_SAIDA*/

        [StopWatch]
        /*" R0520-INCLUIR-TAB-PESSOA-SECTION */
        private void R0520_INCLUIR_TAB_PESSOA_SECTION()
        {
            /*" -4702- MOVE 'R0520-INCLUIR-TAB-PESSOA' TO PARAGRAFO. */
            _.Move("R0520-INCLUIR-TAB-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4703- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4704- IF W-OBTER-MAX-PESSOA EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_PESSOA == "NAO")
            {

                /*" -4705- MOVE 'SIM' TO W-OBTER-MAX-PESSOA */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_PESSOA);

                /*" -4707- PERFORM R0521-OBTER-MAX-COD-PESSOA. */

                R0521_OBTER_MAX_COD_PESSOA_SECTION();
            }


            /*" -4710- COMPUTE W-COD-PESSOA = W-COD-PESSOA + 1 */
            WAREA_AUXILIAR.W_COD_PESSOA.Value = WAREA_AUXILIAR.W_COD_PESSOA + 1;

            /*" -4713- MOVE W-COD-PESSOA TO WHOST-COD-PESSOA-PF */
            _.Move(WAREA_AUXILIAR.W_COD_PESSOA, WHOST_COD_PESSOA_PF);

            /*" -4716- MOVE W-COD-PESSOA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(WAREA_AUXILIAR.W_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -4719- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -4722- MOVE ' ' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
            _.Move(" ", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -4723- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -4725- MOVE 'F' TO PESSOA-TIPO-PESSOA OF DCLPESSOA */
                _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -4726- ELSE */
            }
            else
            {


                /*" -4727- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 2)
                {

                    /*" -4730- MOVE 'J' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
                    _.Move("J", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                }

            }


            /*" -4733- MOVE 'VA0600B' TO PESSOA-COD-USUARIO OF DCLPESSOA. */
            _.Move("VA0600B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -4741- PERFORM R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1 */

            R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1();

            /*" -4745- IF SQLCODE NOT EQUAL 00 OR PESSOA-NOME-PESSOA OF DCLPESSOA EQUAL SPACES */

            if (DB.SQLCODE != 00 || PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsEmpty())
            {

                /*" -4746- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4747- DISPLAY '          ERRO INSERT DA TABELA PESSOA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA");

                /*" -4749- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -4751- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -4753- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4755- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4756- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4756- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0520-INCLUIR-TAB-PESSOA-DB-INSERT-1 */
        public void R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1()
        {
            /*" -4741- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, CURRENT TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO, :DCLPESSOA.PESSOA-TIPO-PESSOA, NULL) END-EXEC. */

            var r0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1 = new R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                PESSOA_TIPO_PESSOA = PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA.ToString(),
            };

            R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1.Execute(r0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_SAIDA*/

        [StopWatch]
        /*" R0521-OBTER-MAX-COD-PESSOA-SECTION */
        private void R0521_OBTER_MAX_COD_PESSOA_SECTION()
        {
            /*" -4763- MOVE 'R0521-OBTER-MAX-COD-PESSOA' TO PARAGRAFO. */
            _.Move("R0521-OBTER-MAX-COD-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4764- MOVE 'MAX SEGUROS.PESSOA' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4768- PERFORM R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1 */

            R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1();

            /*" -4771- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4772- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4773- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA");

                /*" -4775- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4777- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4778- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4780- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -4781- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO W-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, WAREA_AUXILIAR.W_COD_PESSOA);

        }

        [StopWatch]
        /*" R0521-OBTER-MAX-COD-PESSOA-DB-SELECT-1 */
        public void R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1()
        {
            /*" -4768- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :DCLPESSOA.PESSOA-COD-PESSOA FROM SEGUROS.PESSOA END-EXEC. */

            var r0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1 = new R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1.Execute(r0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0521_SAIDA*/

        [StopWatch]
        /*" R0525-INCLUIR-PESSOA-FISICA-SECTION */
        private void R0525_INCLUIR_PESSOA_FISICA_SECTION()
        {
            /*" -4788- MOVE 'R0525-INCLUIR-PESSOA-FISICA ' TO PARAGRAFO. */
            _.Move("R0525-INCLUIR-PESSOA-FISICA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4790- MOVE 'INSERT PESSOA-FISICA' TO COMANDO. */
            _.Move("INSERT PESSOA-FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4793- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-FISICA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFIS.DCLPESSOA_FISICA.COD_PESSOA);

            /*" -4796- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -4799- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

            /*" -4802- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_19.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -4805- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_19.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -4808- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_19.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -4812- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -4815- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -4816- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -4818- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -4819- ELSE */
            }
            else
            {


                /*" -4822- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -4825- MOVE SPACES TO TIPO-IDENT-SIVPF OF DCLPESSOA-FISICA. */
            _.Move("", PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);

            /*" -4828- MOVE R1-NUM-IDENTIDADE OF REG-CLIENTES TO NUM-IDENTIDADE OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);

            /*" -4831- MOVE R1-ORGAO-EXPEDIDOR OF REG-CLIENTES TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

            /*" -4832- IF R1-UF-EXPEDIDORA OF REG-CLIENTES EQUAL '  ' */

            if (LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA == "  ")
            {

                /*" -4834- MOVE 'DF' TO R1-UF-EXPEDIDORA OF REG-CLIENTES */
                _.Move("DF", LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);

                /*" -4836- END-IF. */
            }


            /*" -4839- MOVE R1-UF-EXPEDIDORA OF REG-CLIENTES TO UF-EXPEDIDORA OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

            /*" -4840- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 1)
            {

                /*" -4842- MOVE 'S' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                _.Move("S", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                /*" -4843- ELSE */
            }
            else
            {


                /*" -4844- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 2)
                {

                    /*" -4846- MOVE 'C' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                    _.Move("C", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                    /*" -4847- ELSE */
                }
                else
                {


                    /*" -4848- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 3 */

                    if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 3)
                    {

                        /*" -4850- MOVE 'V' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                        _.Move("V", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                        /*" -4851- ELSE */
                    }
                    else
                    {


                        /*" -4852- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 4 */

                        if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 4)
                        {

                            /*" -4854- MOVE 'O' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                            _.Move("O", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                            /*" -4855- ELSE */
                        }
                        else
                        {


                            /*" -4856- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 5 */

                            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 5)
                            {

                                /*" -4858- MOVE 'D' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                                _.Move("D", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                                /*" -4859- ELSE */
                            }
                            else
                            {


                                /*" -4860- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 6 */

                                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 6)
                                {

                                    /*" -4863- MOVE 'J' TO ESTADO-CIVIL OF DCLPESSOA-FISICA. */
                                    _.Move("J", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                                }

                            }

                        }

                    }

                }

            }


            /*" -4866- MOVE R1-DATA-EXPEDICAO-RG OF REG-CLIENTES TO W-DATA-DDMMAAAA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -4867- IF W-DATA-DDMMAAAA NOT NUMERIC */

            if (!WAREA_AUXILIAR.W_DATA_DDMMAAAA.IsNumeric())
            {

                /*" -4869- MOVE -1 TO VIND-DTEXPEDI */
                _.Move(-1, VIND_DTEXPEDI);

                /*" -4870- ELSE */
            }
            else
            {


                /*" -4872- IF W-DATA-DDMMAAAA EQUAL 01010001 OR W-DATA-DDMMAAAA EQUAL ZEROS */

                if (WAREA_AUXILIAR.W_DATA_DDMMAAAA == 01010001 || WAREA_AUXILIAR.W_DATA_DDMMAAAA == 00)
                {

                    /*" -4874- MOVE -1 TO VIND-DTEXPEDI */
                    _.Move(-1, VIND_DTEXPEDI);

                    /*" -4875- ELSE */
                }
                else
                {


                    /*" -4877- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                    /*" -4879- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                    /*" -4882- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                    /*" -4886- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                    _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                    _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                    /*" -4888- MOVE W-DATA-SQL TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

                    /*" -4890- MOVE ZEROS TO VIND-DTEXPEDI. */
                    _.Move(0, VIND_DTEXPEDI);
                }

            }


            /*" -4893- MOVE WS-COD-CBO TO COD-CBO OF DCLPESSOA-FISICA. */
            _.Move(WAREA_AUXILIAR.WS_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

            /*" -4896- MOVE 'VA0600B' TO COD-USUARIO OF DCLPESSOA-FISICA. */
            _.Move("VA0600B", PESFIS.DCLPESSOA_FISICA.COD_USUARIO);

            /*" -4911- PERFORM R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1 */

            R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1();

            /*" -4914- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4915- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4916- DISPLAY '          ERRO INSERT DA TABELA PESSOA FISICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA FISICA");

                /*" -4918- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                _.Display($"          CODIGO PESSOA.................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                /*" -4920- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4922- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4923- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4923- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0525-INCLUIR-PESSOA-FISICA-DB-INSERT-1 */
        public void R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1()
        {
            /*" -4911- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA-FISICA.COD-PESSOA, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC. */

            var r0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1 = new R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESFIS.DCLPESSOA_FISICA.COD_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                COD_USUARIO = PESFIS.DCLPESSOA_FISICA.COD_USUARIO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                NUM_IDENTIDADE = PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE.ToString(),
                ORGAO_EXPEDIDOR = PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.ToString(),
                UF_EXPEDIDORA = PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA.ToString(),
                DATA_EXPEDICAO = PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.ToString(),
                VIND_DTEXPEDI = VIND_DTEXPEDI.ToString(),
                COD_CBO = PESFIS.DCLPESSOA_FISICA.COD_CBO.ToString(),
                TIPO_IDENT_SIVPF = PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF.ToString(),
            };

            R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1.Execute(r0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0525_SAIDA*/

        [StopWatch]
        /*" R0530-INCLUIR-PESSOA-JURIDICA-SECTION */
        private void R0530_INCLUIR_PESSOA_JURIDICA_SECTION()
        {
            /*" -4930- MOVE 'R0530-INCLUIR-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R0530-INCLUIR-PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4931- MOVE 'INSERT PESSOA-JURIDICA' TO COMANDO. */
            _.Move("INSERT PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4934- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-JURIDICA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);

            /*" -4937- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -4940- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO NOME-FANTASIA OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);

            /*" -4943- MOVE 'VA0600B' TO COD-USUARIO OF DCLPESSOA-JURIDICA */
            _.Move("VA0600B", PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);

            /*" -4950- PERFORM R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1 */

            R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1();

            /*" -4953- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4954- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4955- DISPLAY '          ERRO INSERT DA TABELA PESSOA JURIDICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA JURIDICA");

                /*" -4957- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                _.Display($"          CODIGO PESSOA.................  {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                /*" -4959- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4961- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4962- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4962- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0530-INCLUIR-PESSOA-JURIDICA-DB-INSERT-1 */
        public void R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1()
        {
            /*" -4950- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES (:DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1 = new R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA.ToString(),
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
                NOME_FANTASIA = PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA.ToString(),
                COD_USUARIO = PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO.ToString(),
            };

            R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1.Execute(r0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_SAIDA*/

        [StopWatch]
        /*" R0536-RELACIONA-EMAIL-SECTION */
        private void R0536_RELACIONA_EMAIL_SECTION()
        {
            /*" -4969- MOVE 'R0536-RELACIONA-EMAIL' TO PARAGRAFO. */
            _.Move("R0536-RELACIONA-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4970- MOVE 'DECLARE PESSOA-EMAIL' TO COMANDO. */
            _.Move("DECLARE PESSOA-EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4973- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4982- PERFORM R0536_RELACIONA_EMAIL_DB_DECLARE_1 */

            R0536_RELACIONA_EMAIL_DB_DECLARE_1();

            /*" -4986- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4987- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -4988- DISPLAY '          ERRO DECLARE DA TABELA PESSOA EMAIL' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA EMAIL");

                /*" -4990- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -4992- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4994- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4995- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4995- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0536-RELACIONA-EMAIL-DB-DECLARE-1 */
        public void R0536_RELACIONA_EMAIL_DB_DECLARE_1()
        {
            /*" -4982- EXEC SQL DECLARE EMAIL CURSOR FOR SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA ORDER BY SEQ_EMAIL END-EXEC. */
            EMAIL = new VA0600B_EMAIL(true);
            string GetQuery_EMAIL()
            {
                var query = @$"SELECT COD_PESSOA
							, 
							SEQ_EMAIL
							, 
							EMAIL
							, 
							SITUACAO_EMAIL 
							FROM SEGUROS.PESSOA_EMAIL 
							WHERE COD_PESSOA = '{PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}' 
							ORDER BY SEQ_EMAIL";

                return query;
            }
            EMAIL.GetQueryEvent += GetQuery_EMAIL;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0536_SAIDA*/

        [StopWatch]
        /*" R0535-INCLUIR-END-EMAIL-SECTION */
        private void R0535_INCLUIR_END_EMAIL_SECTION()
        {
            /*" -5002- MOVE 'R0535-INCLUIR-END-EMAIL' TO PARAGRAFO. */
            _.Move("R0535-INCLUIR-END-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5003- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5005- PERFORM R0536-RELACIONA-EMAIL. */

            R0536_RELACIONA_EMAIL_SECTION();

            /*" -5007- MOVE 'OPEN CURSOR EMAIL' TO COMANDO. */
            _.Move("OPEN CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5007- PERFORM R0535_INCLUIR_END_EMAIL_DB_OPEN_1 */

            R0535_INCLUIR_END_EMAIL_DB_OPEN_1();

            /*" -5011- MOVE 'NAO' TO W-ACHOU-EMAIL. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_EMAIL);

            /*" -5013- MOVE SPACES TO W-FIM-CURSOR-EMAIL. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

            /*" -5015- PERFORM R0537-FETCH-EMAIL */

            R0537_FETCH_EMAIL_SECTION();

            /*" -5016- IF W-FIM-CURSOR-EMAIL EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM")
            {

                /*" -5017- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

                if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
                {

                    /*" -5018- MOVE 'SIM' TO W-ACHOU-EMAIL */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);

                    /*" -5019- END-IF */
                }


                /*" -5021- END-IF */
            }


            /*" -5024- PERFORM R0538-VERIFICA-EXISTE-EMAIL UNTIL W-FIM-CURSOR-EMAIL EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM"))
            {

                R0538_VERIFICA_EXISTE_EMAIL_SECTION();
            }

            /*" -5025- IF W-ACHOU-EMAIL EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_EMAIL == "NAO")
            {

                /*" -5026- PERFORM R0539-INCLUIR-NOVO-EMAIL */

                R0539_INCLUIR_NOVO_EMAIL_SECTION();

                /*" -5028- END-IF */
            }


            /*" -5028- . */

        }

        [StopWatch]
        /*" R0535-INCLUIR-END-EMAIL-DB-OPEN-1 */
        public void R0535_INCLUIR_END_EMAIL_DB_OPEN_1()
        {
            /*" -5007- EXEC SQL OPEN EMAIL END-EXEC. */

            EMAIL.Open();

        }

        [StopWatch]
        /*" R0605A-RELACIONA-ENDERECO-DB-DECLARE-1 */
        public void R0605A_RELACIONA_ENDERECO_DB_DECLARE_1()
        {
            /*" -5443- EXEC SQL DECLARE ENDERECOS CURSOR FOR SELECT OCORR_ENDERECO, COD_PESSOA, ENDERECO, TIPO_ENDER, BAIRRO, CEP, CIDADE, SIGLA_UF, SITUACAO_ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA ORDER BY OCORR_ENDERECO END-EXEC. */
            ENDERECOS = new VA0600B_ENDERECOS(true);
            string GetQuery_ENDERECOS()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							COD_PESSOA
							, 
							ENDERECO
							, 
							TIPO_ENDER
							, 
							BAIRRO
							, 
							CEP
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							SITUACAO_ENDERECO 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = '{PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}' 
							ORDER BY OCORR_ENDERECO";

                return query;
            }
            ENDERECOS.GetQueryEvent += GetQuery_ENDERECOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0535_SAIDA*/

        [StopWatch]
        /*" R0537-FETCH-EMAIL-SECTION */
        private void R0537_FETCH_EMAIL_SECTION()
        {
            /*" -5035- MOVE 'R0537-FETCH-EMAIL' TO PARAGRAFO. */
            _.Move("R0537-FETCH-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5036- MOVE 'FETCH CURSOR EMAIL' TO COMANDO. */
            _.Move("FETCH CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5042- PERFORM R0537_FETCH_EMAIL_DB_FETCH_1 */

            R0537_FETCH_EMAIL_DB_FETCH_1();

            /*" -5045- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5046- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5047- MOVE 'SIM' TO W-FIM-CURSOR-EMAIL */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

                    /*" -5047- PERFORM R0537_FETCH_EMAIL_DB_CLOSE_1 */

                    R0537_FETCH_EMAIL_DB_CLOSE_1();

                    /*" -5049- ELSE */
                }
                else
                {


                    /*" -5050- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -5051- DISPLAY '          ERRO FETCH CURSOR EMAIL' */
                    _.Display($"          ERRO FETCH CURSOR EMAIL");

                    /*" -5053- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                    _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                    /*" -5055- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -5057- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -5058- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -5058- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0537-FETCH-EMAIL-DB-FETCH-1 */
        public void R0537_FETCH_EMAIL_DB_FETCH_1()
        {
            /*" -5042- EXEC SQL FETCH EMAIL INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL END-EXEC. */

            if (EMAIL.Fetch())
            {
                _.Move(EMAIL.DCLPESSOA_EMAIL_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
            }

        }

        [StopWatch]
        /*" R0537-FETCH-EMAIL-DB-CLOSE-1 */
        public void R0537_FETCH_EMAIL_DB_CLOSE_1()
        {
            /*" -5047- EXEC SQL CLOSE EMAIL END-EXEC */

            EMAIL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0537_SAIDA*/

        [StopWatch]
        /*" R0538-VERIFICA-EXISTE-EMAIL-SECTION */
        private void R0538_VERIFICA_EXISTE_EMAIL_SECTION()
        {
            /*" -5065- MOVE 'R0538-VERIFICA-EXISTE-EMAIL' TO PARAGRAFO. */
            _.Move("R0538-VERIFICA-EXISTE-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5066- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5069- IF R1-EMAIL OF REG-CLIENTES EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL == PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -5072- IF PRODUTOS-VIDA-INDIVIDUAL OR VIDA-EXCLUSIVO-AIC */

                if (LBWPF002.W_PRODUTO["PRODUTOS_VIDA_INDIVIDUAL"] || LBWPF002.W_PRODUTO["VIDA_EXCLUSIVO_AIC"])
                {

                    /*" -5073- MOVE 'UPDATE PESSOA-EMAIL   ' TO COMANDO */
                    _.Move("UPDATE PESSOA-EMAIL   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -5077- PERFORM R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1 */

                    R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1();

                    /*" -5079- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -5080- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -5081- GO TO R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION(); //GOTO
                        return;

                        /*" -5082- END-IF */
                    }


                    /*" -5083- END-IF */
                }


                /*" -5085- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -5088- IF ((R3-INDIC-TIPO-PROPOSTA OF REG-PROPOSTA-SASSE EQUAL 'V' OR 'D' OR 'E' OR 'S' ) AND R1-EMAIL OF REG-CLIENTES EQUAL SPACES) */

            if (((LXFCT004.REG_PROPOSTA_SASSE.R3_INDIC_TIPO_PROPOSTA.In("V", "D", "E", "S")) && LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty()))
            {

                /*" -5090- MOVE EMAIL OF DCLPESSOA-EMAIL TO R1-EMAIL OF REG-CLIENTES */
                _.Move(PESEMAIL.DCLPESSOA_EMAIL.EMAIL, LBFPF011.REG_CLIENTES.R1_EMAIL);

                /*" -5092- END-IF */
            }


            /*" -5093- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
            {

                /*" -5095- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -5095- PERFORM R0537-FETCH-EMAIL. */

            R0537_FETCH_EMAIL_SECTION();

        }

        [StopWatch]
        /*" R0538-VERIFICA-EXISTE-EMAIL-DB-UPDATE-1 */
        public void R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1()
        {
            /*" -5077- EXEC SQL UPDATE SEGUROS.PESSOA_EMAIL SET SITUACAO_EMAIL = 'P' WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND EMAIL = :DCLPESSOA-EMAIL.EMAIL END-EXEC */

            var r0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1_Update1 = new R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1_Update1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
            };

            R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1_Update1.Execute(r0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0538_SAIDA*/

        [StopWatch]
        /*" R0539-INCLUIR-NOVO-EMAIL-SECTION */
        private void R0539_INCLUIR_NOVO_EMAIL_SECTION()
        {
            /*" -5102- MOVE 'R0539-INCLUIR-NOVO-EMAIL' TO PARAGRAFO. */
            _.Move("R0539-INCLUIR-NOVO-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5110- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5113- MOVE SEQ-EMAIL OF DCLPESSOA-EMAIL TO W-SEQ-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL, WAREA_AUXILIAR.W_SEQ_EMAIL);

            /*" -5115- COMPUTE W-SEQ-EMAIL = W-SEQ-EMAIL + 1. */
            WAREA_AUXILIAR.W_SEQ_EMAIL.Value = WAREA_AUXILIAR.W_SEQ_EMAIL + 1;

            /*" -5115- PERFORM R0541-INCLUIR-EMAIL. */

            R0541_INCLUIR_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0539_SAIDA*/

        [StopWatch]
        /*" R0540-OBTER-MAX-EMAIL-SECTION */
        private void R0540_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -5122- MOVE 'R0540-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R0540-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5123- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5126- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -5131- PERFORM R0540_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R0540_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -5134- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5135- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5136- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -5138- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -5140- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5141- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5141- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0540-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R0540_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -5131- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA END-EXEC. */

            var r0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0540_SAIDA*/

        [StopWatch]
        /*" R0541-INCLUIR-EMAIL-SECTION */
        private void R0541_INCLUIR_EMAIL_SECTION()
        {
            /*" -5148- MOVE 'R0541-INCLUI-EMAIL' TO PARAGRAFO. */
            _.Move("R0541-INCLUI-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5149- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5152- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -5155- MOVE W-SEQ-EMAIL TO SEQ-EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(WAREA_AUXILIAR.W_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);

            /*" -5158- MOVE R1-EMAIL OF REG-CLIENTES TO EMAIL OF DCLPESSOA-EMAIL */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -5160- IF PRODUTOS-VIDA-INDIVIDUAL OR VIDA-EXCLUSIVO-AIC */

            if (LBWPF002.W_PRODUTO["PRODUTOS_VIDA_INDIVIDUAL"] || LBWPF002.W_PRODUTO["VIDA_EXCLUSIVO_AIC"])
            {

                /*" -5162- MOVE 'P' TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
                _.Move("P", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

                /*" -5163- ELSE */
            }
            else
            {


                /*" -5165- MOVE 'A' TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
                _.Move("A", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

                /*" -5167- END-IF. */
            }


            /*" -5170- MOVE 'VA0600B' TO COD-USUARIO OF DCLPESSOA-EMAIL. */
            _.Move("VA0600B", PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);

            /*" -5178- PERFORM R0541_INCLUIR_EMAIL_DB_INSERT_1 */

            R0541_INCLUIR_EMAIL_DB_INSERT_1();

            /*" -5181- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5182- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5183- DISPLAY '          ERRO INSERT DA TABELA PESSOA-EMAIL' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA-EMAIL");

                /*" -5185- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -5187- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -5189- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -5191- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5192- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5192- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0541-INCLUIR-EMAIL-DB-INSERT-1 */
        public void R0541_INCLUIR_EMAIL_DB_INSERT_1()
        {
            /*" -5178- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1 = new R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
                SITUACAO_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL.ToString(),
                COD_USUARIO = PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO.ToString(),
            };

            R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1.Execute(r0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0541_SAIDA*/

        [StopWatch]
        /*" R0550-LER-TAB-CORPORATIVAS-SECTION */
        private void R0550_LER_TAB_CORPORATIVAS_SECTION()
        {
            /*" -5199- MOVE 'R0550-LER-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R0550-LER-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5200- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5201- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -5203- MOVE COD-PESSOA OF DCLPESSOA-FISICA TO PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Move(PESFIS.DCLPESSOA_FISICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

                /*" -5204- ELSE */
            }
            else
            {


                /*" -5207- MOVE COD-PESSOA OF DCLPESSOA-JURIDICA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
                _.Move(PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


            /*" -5209- PERFORM R0555-LER-TAB-PESSOA. */

            R0555_LER_TAB_PESSOA_SECTION();

            /*" -5209- PERFORM R0560-LER-TAB-EMAIL. */

            R0560_LER_TAB_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_SAIDA*/

        [StopWatch]
        /*" R0555-LER-TAB-PESSOA-SECTION */
        private void R0555_LER_TAB_PESSOA_SECTION()
        {
            /*" -5216- MOVE 'R0550-LER-TAB-PESSOA ' TO PARAGRAFO. */
            _.Move("R0550-LER-TAB-PESSOA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5217- MOVE 'SELECT SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5230- PERFORM R0555_LER_TAB_PESSOA_DB_SELECT_1 */

            R0555_LER_TAB_PESSOA_DB_SELECT_1();

            /*" -5233- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5234- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5235- DISPLAY '          ERRO ACESSO TAB. SEGUROS.PESSOA' */
                _.Display($"          ERRO ACESSO TAB. SEGUROS.PESSOA");

                /*" -5237- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -5239- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5240- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5242- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -5244- IF PESSOA-NOME-PESSOA EQUAL SPACES OR PESSOA-NOME-PESSOA EQUAL LOW-VALUES */

            if (PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsEmpty() || PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsLowValues())
            {

                /*" -5245- PERFORM R05551-CORRIGE-PESSOA */

                R05551_CORRIGE_PESSOA_SECTION();

                /*" -5247- END-IF */
            }


            /*" -5247- . */

        }

        [StopWatch]
        /*" R0555-LER-TAB-PESSOA-DB-SELECT-1 */
        public void R0555_LER_TAB_PESSOA_DB_SELECT_1()
        {
            /*" -5230- EXEC SQL SELECT COD_PESSOA, NOME_PESSOA, TIPO_PESSOA, TIMESTAMP, COD_USUARIO INTO :DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, :DCLPESSOA.PESSOA-TIPO-PESSOA, :DCLPESSOA.PESSOA-TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA END-EXEC. */

            var r0555_LER_TAB_PESSOA_DB_SELECT_1_Query1 = new R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1.Execute(r0555_LER_TAB_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
                _.Move(executed_1.PESSOA_TIPO_PESSOA, PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                _.Move(executed_1.PESSOA_TIMESTAMP, PESSOA.DCLPESSOA.PESSOA_TIMESTAMP);
                _.Move(executed_1.PESSOA_COD_USUARIO, PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0555_SAIDA*/

        [StopWatch]
        /*" R05551-CORRIGE-PESSOA-SECTION */
        private void R05551_CORRIGE_PESSOA_SECTION()
        {
            /*" -5257- MOVE 'R05551-CORRIGE-PESSOA' TO PARAGRAFO. */
            _.Move("R05551-CORRIGE-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5258- MOVE 'UPDATE SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("UPDATE SEGUROS.PESSOAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5260- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5263- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -5267- PERFORM R05551_CORRIGE_PESSOA_DB_UPDATE_1 */

            R05551_CORRIGE_PESSOA_DB_UPDATE_1();

            /*" -5271- IF SQLCODE NOT EQUAL ZEROS OR PESSOA-NOME-PESSOA OF DCLPESSOA EQUAL SPACES */

            if (DB.SQLCODE != 00 || PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsEmpty())
            {

                /*" -5272- DISPLAY 'VA0600B FIM ANORMAL' */
                _.Display($"VA0600B FIM ANORMAL");

                /*" -5273- DISPLAY '        ERRO UPDATE TAB. PESSOA' */
                _.Display($"        ERRO UPDATE TAB. PESSOA");

                /*" -5275- DISPLAY '        CODIGO PESSOA....... ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"        CODIGO PESSOA....... {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -5277- DISPLAY '        NOME DA PESSOA...... ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"        NOME DA PESSOA...... {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -5279- DISPLAY '        NUMERO DA PROPOSTA.. ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"        NUMERO DA PROPOSTA.. {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -5280- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5282- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5282- . */

        }

        [StopWatch]
        /*" R05551-CORRIGE-PESSOA-DB-UPDATE-1 */
        public void R05551_CORRIGE_PESSOA_DB_UPDATE_1()
        {
            /*" -5267- EXEC SQL UPDATE SEGUROS.PESSOA SET NOME_PESSOA = :DCLPESSOA.PESSOA-NOME-PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA END-EXEC. */

            var r05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1 = new R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1()
            {
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1.Execute(r05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R05551_SAIDA*/

        [StopWatch]
        /*" R0560-LER-TAB-EMAIL-SECTION */
        private void R0560_LER_TAB_EMAIL_SECTION()
        {
            /*" -5288- MOVE 'R0560-LER-TAB-EMAIL' TO PARAGRAFO. */
            _.Move("R0560-LER-TAB-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5289- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5291- PERFORM R0565-OBTER-MAX-EMAIL. */

            R0565_OBTER_MAX_EMAIL_SECTION();

            /*" -5291- PERFORM R0570-LER-EMAIL-ATUAL. */

            R0570_LER_EMAIL_ATUAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_SAIDA*/

        [StopWatch]
        /*" R0565-OBTER-MAX-EMAIL-SECTION */
        private void R0565_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -5298- MOVE 'R0565-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R0565-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5299- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5302- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -5307- PERFORM R0565_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R0565_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -5310- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5311- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5312- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -5314- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -5316- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5317- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5317- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0565-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R0565_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -5307- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA END-EXEC. */

            var r0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0565_SAIDA*/

        [StopWatch]
        /*" R0570-LER-EMAIL-ATUAL-SECTION */
        private void R0570_LER_EMAIL_ATUAL_SECTION()
        {
            /*" -5324- MOVE 'R0570-LER-EMAIL-ATUAL' TO PARAGRAFO. */
            _.Move("R0570-LER-EMAIL-ATUAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5325- MOVE 'SELECT SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5328- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -5344- PERFORM R0570_LER_EMAIL_ATUAL_DB_SELECT_1 */

            R0570_LER_EMAIL_ATUAL_DB_SELECT_1();

            /*" -5348- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5349- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5350- DISPLAY '          ERRO SELECT TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT TAB. PESSOA-EMAIL");

                /*" -5352- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -5354- DISPLAY '          SEQUENCIAEMAIL................  ' SEQ-EMAIL OF DCLPESSOA-EMAIL */
                _.Display($"          SEQUENCIAEMAIL................  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -5356- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5357- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5357- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0570-LER-EMAIL-ATUAL-DB-SELECT-1 */
        public void R0570_LER_EMAIL_ATUAL_DB_SELECT_1()
        {
            /*" -5344- EXEC SQL SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, :DCLPESSOA-EMAIL.TIMESTAMP FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL END-EXEC. */

            var r0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 = new R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
            };

            var executed_1 = R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1.Execute(r0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(executed_1.EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(executed_1.SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
                _.Move(executed_1.COD_USUARIO, PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESEMAIL.DCLPESSOA_EMAIL.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0600-TRATA-END-TEL-SECTION */
        private void R0600_TRATA_END_TEL_SECTION()
        {
            /*" -5364- MOVE 'R0600-TRATA-END-TEL' TO PARAGRAFO. */
            _.Move("R0600-TRATA-END-TEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5365- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5369- PERFORM R0601-TRATA-ENDERECO VARYING W-IND-ENDER FROM 1 BY 1 UNTIL W-IND-ENDER GREATER W-IND-ENDER-N. */

            for (WAREA_AUXILIAR.W_IND_ENDER.Value = 1; !(WAREA_AUXILIAR.W_IND_ENDER > WAREA_AUXILIAR.W_IND_ENDER_N); WAREA_AUXILIAR.W_IND_ENDER.Value += 1)
            {

                R0601_TRATA_ENDERECO_SECTION();
            }

            /*" -5371- MOVE ZEROS TO W-INDEX. */
            _.Move(0, WAREA_AUXILIAR.W_INDEX);

            /*" -5371- PERFORM R0650-TRATA-TELEFONES 3 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R0650_TRATA_TELEFONES_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0601-TRATA-ENDERECO-SECTION */
        private void R0601_TRATA_ENDERECO_SECTION()
        {
            /*" -5378- MOVE 'R0601-TRATA-ENDERECO' TO PARAGRAFO. */
            _.Move("R0601-TRATA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5379- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5383- MOVE ZEROS TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO, W-OCORR-ENDERECO. */
            _.Move(0, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -5385- PERFORM R0605-TAB-ENDERECO-NOVOS. */

            R0605_TAB_ENDERECO_NOVOS_SECTION();

            /*" -5387- MOVE W-TB-REG-ENDERECOS-N(W-IND-ENDER) TO REG-ENDERECO */
            _.Move(WAREA_AUXILIAR.W_TB_ENDERECOS_N.W_TAB_END_REG_N[WAREA_AUXILIAR.W_IND_ENDER].W_TB_REG_ENDERECOS_N, LBFPF012.REG_ENDERECO);

            /*" -5389- MOVE 'NAO' TO W-ACHOU-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_ENDERECO);

            /*" -5393- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

            if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
            {

                /*" -5395- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -5400- PERFORM R0615-VERIFICA-EXISTE-ENDERECO VARYING W-IND-ENDER1 FROM 1 BY 1 UNTIL W-IND-ENDER1 GREATER W-IND-ENDER-A OR W-ACHOU-ENDERECO EQUAL 'SIM' . */

            for (WAREA_AUXILIAR.W_IND_ENDER1.Value = 1; !(WAREA_AUXILIAR.W_IND_ENDER1 > WAREA_AUXILIAR.W_IND_ENDER_A || WAREA_AUXILIAR.W_ACHOU_ENDERECO == "SIM"); WAREA_AUXILIAR.W_IND_ENDER1.Value += 1)
            {

                R0615_VERIFICA_EXISTE_ENDERECO_SECTION();
            }

            /*" -5401- IF W-ACHOU-ENDERECO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_ENDERECO == "NAO")
            {

                /*" -5401- PERFORM R0620-INCLUIR-NOVO-ENDERECO. */

                R0620_INCLUIR_NOVO_ENDERECO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0601_SAIDA*/

        [StopWatch]
        /*" R0605-TAB-ENDERECO-NOVOS-SECTION */
        private void R0605_TAB_ENDERECO_NOVOS_SECTION()
        {
            /*" -5408- MOVE 'R0605-TAB-ENDERECO-NOVOS' TO PARAGRAFO. */
            _.Move("R0605-TAB-ENDERECO-NOVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5409- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5411- MOVE ZEROS TO W-IND-ENDER-A. */
            _.Move(0, WAREA_AUXILIAR.W_IND_ENDER_A);

            /*" -5413- MOVE 'NAO' TO W-FIM-CURSOR-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

            /*" -5415- PERFORM R0605A-RELACIONA-ENDERECO */

            R0605A_RELACIONA_ENDERECO_SECTION();

            /*" -5417- PERFORM R0610-FETCH-ENDERECO. */

            R0610_FETCH_ENDERECO_SECTION();

            /*" -5418- PERFORM R0605B-CARREGA-TB-ENDERECO UNTIL W-FIM-CURSOR-ENDERECO EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM"))
            {

                R0605B_CARREGA_TB_ENDERECO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605_SAIDA*/

        [StopWatch]
        /*" R0605A-RELACIONA-ENDERECO-SECTION */
        private void R0605A_RELACIONA_ENDERECO_SECTION()
        {
            /*" -5425- MOVE 'R0605A-RELACIONA-ENDERECO' TO PARAGRAFO. */
            _.Move("R0605A-RELACIONA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5426- MOVE 'DECLARE PESSOA-ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5429- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -5443- PERFORM R0605A_RELACIONA_ENDERECO_DB_DECLARE_1 */

            R0605A_RELACIONA_ENDERECO_DB_DECLARE_1();

            /*" -5447- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5448- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5449- DISPLAY '          ERRO DECLARE DA TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA-ENDERECO");

                /*" -5451- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -5453- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -5455- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5456- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5458- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -5460- MOVE 'OPEN CURSOR ENDERECOS' TO COMANDO. */
            _.Move("OPEN CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5460- PERFORM R0605A_RELACIONA_ENDERECO_DB_OPEN_1 */

            R0605A_RELACIONA_ENDERECO_DB_OPEN_1();

            /*" -5463- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5464- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5465- DISPLAY '          ERRO OPEN TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO OPEN TABELA PESSOA-ENDERECO");

                /*" -5467- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -5469- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -5471- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5472- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5472- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0605A-RELACIONA-ENDERECO-DB-OPEN-1 */
        public void R0605A_RELACIONA_ENDERECO_DB_OPEN_1()
        {
            /*" -5460- EXEC SQL OPEN ENDERECOS END-EXEC. */

            ENDERECOS.Open();

        }

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-DB-DECLARE-1 */
        public void R0762_00_OBTER_COMISSAO_DB_DECLARE_1()
        {
            /*" -6825- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO END-EXEC. */
            FUNDOCOMISVA = new VA0600B_FUNDOCOMISVA(true);
            string GetQuery_FUNDOCOMISVA()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							VAL_COMISSAO_VG
							, 
							VAL_COMISSAO_AP 
							FROM SEGUROS.FUNDO_COMISSAO_VA 
							WHERE NUM_CERTIFICADO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}' 
							AND COD_OPERACAO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}'";

                return query;
            }
            FUNDOCOMISVA.GetQueryEvent += GetQuery_FUNDOCOMISVA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605A_SAIDA*/

        [StopWatch]
        /*" R0605B-CARREGA-TB-ENDERECO-SECTION */
        private void R0605B_CARREGA_TB_ENDERECO_SECTION()
        {
            /*" -5479- MOVE 'R0605B-CARREGA-TB-ENDERECO' TO PARAGRAFO. */
            _.Move("R0605B-CARREGA-TB-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5480- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5482- ADD 1 TO W-IND-ENDER-A. */
            WAREA_AUXILIAR.W_IND_ENDER_A.Value = WAREA_AUXILIAR.W_IND_ENDER_A + 1;

            /*" -5483- IF W-IND-ENDER-A GREATER 30 */

            if (WAREA_AUXILIAR.W_IND_ENDER_A > 30)
            {

                /*" -5484- MOVE 30 TO W-IND-ENDER-A */
                _.Move(30, WAREA_AUXILIAR.W_IND_ENDER_A);

                /*" -5486- END-IF. */
            }


            /*" -5489- MOVE DCLPESSOA-ENDERECO TO W-TB-REG-ENDERECOS-A(W-IND-ENDER-A) */
            _.Move(PESENDER.DCLPESSOA_ENDERECO, WAREA_AUXILIAR.W_TB_ENDERECOS_A.W_TAB_END_REG_A[WAREA_AUXILIAR.W_IND_ENDER_A].W_TB_REG_ENDERECOS_A);

            /*" -5489- PERFORM R0610-FETCH-ENDERECO. */

            R0610_FETCH_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605B_SAIDA*/

        [StopWatch]
        /*" R0610-FETCH-ENDERECO-SECTION */
        private void R0610_FETCH_ENDERECO_SECTION()
        {
            /*" -5496- MOVE 'R0610-FETCH-ENDERECO' TO PARAGRAFO. */
            _.Move("R0610-FETCH-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5497- MOVE 'FETCH CURSOR ENDERECOS' TO COMANDO. */
            _.Move("FETCH CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5508- PERFORM R0610_FETCH_ENDERECO_DB_FETCH_1 */

            R0610_FETCH_ENDERECO_DB_FETCH_1();

            /*" -5511- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5512- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5513- MOVE 'SIM' TO W-FIM-CURSOR-ENDERECO */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

                    /*" -5513- PERFORM R0610_FETCH_ENDERECO_DB_CLOSE_1 */

                    R0610_FETCH_ENDERECO_DB_CLOSE_1();

                    /*" -5515- ELSE */
                }
                else
                {


                    /*" -5516- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -5517- DISPLAY '          ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"          ERRO FETCH CURSOR ENDERECO");

                    /*" -5519- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -5521- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -5523- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -5524- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -5524- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0610-FETCH-ENDERECO-DB-FETCH-1 */
        public void R0610_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -5508- EXEC SQL FETCH ENDERECOS INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO END-EXEC. */

            if (ENDERECOS.Fetch())
            {
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SITUACAO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);
            }

        }

        [StopWatch]
        /*" R0610-FETCH-ENDERECO-DB-CLOSE-1 */
        public void R0610_FETCH_ENDERECO_DB_CLOSE_1()
        {
            /*" -5513- EXEC SQL CLOSE ENDERECOS END-EXEC */

            ENDERECOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_SAIDA*/

        [StopWatch]
        /*" R0615-VERIFICA-EXISTE-ENDERECO-SECTION */
        private void R0615_VERIFICA_EXISTE_ENDERECO_SECTION()
        {
            /*" -5531- MOVE 'R0615-VERIFICA-EXISTE-ENDERECO' TO PARAGRAFO. */
            _.Move("R0615-VERIFICA-EXISTE-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5532- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5535- MOVE W-TB-REG-ENDERECOS-A(W-IND-ENDER1) TO DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_TB_ENDERECOS_A.W_TAB_END_REG_A[WAREA_AUXILIAR.W_IND_ENDER1].W_TB_REG_ENDERECOS_A, PESENDER.DCLPESSOA_ENDERECO);

            /*" -5545- IF R2-TIPO-ENDER OF REG-ENDERECO EQUAL TIPO-ENDER OF DCLPESSOA-ENDERECO AND R2-ENDERECO OF REG-ENDERECO EQUAL ENDERECO OF DCLPESSOA-ENDERECO AND R2-CIDADE OF REG-ENDERECO EQUAL CIDADE OF DCLPESSOA-ENDERECO AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SIGLA-UF OF DCLPESSOA-ENDERECO AND R2-CEP OF REG-ENDERECO EQUAL CEP OF DCLPESSOA-ENDERECO */

            if (LBFPF012.REG_ENDERECO.R2_TIPO_ENDER == PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER && LBFPF012.REG_ENDERECO.R2_ENDERECO == PESENDER.DCLPESSOA_ENDERECO.ENDERECO && LBFPF012.REG_ENDERECO.R2_CIDADE == PESENDER.DCLPESSOA_ENDERECO.CIDADE && LBFPF012.REG_ENDERECO.R2_SIGLA_UF == PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF && LBFPF012.REG_ENDERECO.R2_CEP == PESENDER.DCLPESSOA_ENDERECO.CEP)
            {

                /*" -5545- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0615_SAIDA*/

        [StopWatch]
        /*" R0620-INCLUIR-NOVO-ENDERECO-SECTION */
        private void R0620_INCLUIR_NOVO_ENDERECO_SECTION()
        {
            /*" -5552- MOVE 'R0620-INCLUIR-NOVO-ENDERECO' TO PARAGRAFO. */
            _.Move("R0620-INCLUIR-NOVO-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5553- MOVE 'INSERT PESSOA-ENDERECO' TO COMANDO. */
            _.Move("INSERT PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5555- ADD 1 TO W-QTD-LD-SIVPF-2 */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_2.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_2 + 1;

            /*" -5558- MOVE OCORR-ENDERECO OF DCLPESSOA-ENDERECO TO W-OCORR-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -5560- COMPUTE W-OCORR-ENDERECO = W-OCORR-ENDERECO + 1. */
            WAREA_AUXILIAR.W_OCORR_ENDERECO.Value = WAREA_AUXILIAR.W_OCORR_ENDERECO + 1;

            /*" -5563- MOVE W-OCORR-ENDERECO TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -5566- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -5569- MOVE R2-ENDERECO OF REG-ENDERECO TO ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -5572- MOVE R2-TIPO-ENDER OF REG-ENDERECO TO TIPO-ENDER OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -5575- MOVE R2-BAIRRO OF REG-ENDERECO TO BAIRRO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -5578- MOVE R2-CEP OF REG-ENDERECO TO CEP OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -5581- MOVE R2-CIDADE OF REG-ENDERECO TO CIDADE OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -5584- MOVE R2-SIGLA-UF OF REG-ENDERECO TO SIGLA-UF OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -5587- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -5590- MOVE 'VA0600B' TO COD-USUARIO OF DCLPESSOA-ENDERECO. */
            _.Move("VA0600B", PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -5604- PERFORM R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1 */

            R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1();

            /*" -5608- IF SQLCODE NOT EQUAL 00 AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -5609- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5610- DISPLAY '          ERRO INSERT TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO INSERT TABELA PESSOA-ENDERECO");

                /*" -5612- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -5614- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -5616- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5617- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5619- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -5620- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -5621- DISPLAY 'VA0600B - CLIENTE COM ENDERECO JA CADASTRADO  ' */
                _.Display($"VA0600B - CLIENTE COM ENDERECO JA CADASTRADO  ");

                /*" -5622- DISPLAY ' COD PESSOA = ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($" COD PESSOA = {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -5630- DISPLAY ' ENDERECO= ' ENDERECO OF DCLPESSOA-ENDERECO ' ' TIPO-ENDER OF DCLPESSOA-ENDERECO ' ' BAIRRO OF DCLPESSOA-ENDERECO ' ' CEP OF DCLPESSOA-ENDERECO ' ' CIDADE OF DCLPESSOA-ENDERECO ' ' SIGLA-UF OF DCLPESSOA-ENDERECO ' ' SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO ' ' */

                $" ENDERECO= {PESENDER.DCLPESSOA_ENDERECO.ENDERECO} {PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER} {PESENDER.DCLPESSOA_ENDERECO.BAIRRO} {PESENDER.DCLPESSOA_ENDERECO.CEP} {PESENDER.DCLPESSOA_ENDERECO.CIDADE} {PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF} {PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO} "
                .Display();

                /*" -5630- END-IF. */
            }


        }

        [StopWatch]
        /*" R0620-INCLUIR-NOVO-ENDERECO-DB-INSERT-1 */
        public void R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1()
        {
            /*" -5604- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1 = new R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA.ToString(),
                OCORR_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                TIPO_ENDER = PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                SITUACAO_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO.ToString(),
                COD_USUARIO = PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO.ToString(),
            };

            R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1.Execute(r0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_SAIDA*/

        [StopWatch]
        /*" R0650-TRATA-TELEFONES-SECTION */
        private void R0650_TRATA_TELEFONES_SECTION()
        {
            /*" -5637- MOVE 'R0650-TRATA-TELEFONE' TO PARAGRAFO. */
            _.Move("R0650-TRATA-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5638- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5640- ADD 1 TO W-INDEX. */
            WAREA_AUXILIAR.W_INDEX.Value = WAREA_AUXILIAR.W_INDEX + 1;

            /*" -5642- MOVE 'NAO' TO W-ACHOU-TELEFONE. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

            /*" -5643- IF R1-NUM-FONE (W-INDEX) GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE > 00)
            {

                /*" -5644- PERFORM R0655-LER-TELEFONE */

                R0655_LER_TELEFONE_SECTION();

                /*" -5645- IF W-ACHOU-TELEFONE EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_ACHOU_TELEFONE == "NAO")
                {

                    /*" -5645- PERFORM R0660-INCLUIR-NOVO-TELEFONE. */

                    R0660_INCLUIR_NOVO_TELEFONE_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0655-LER-TELEFONE-SECTION */
        private void R0655_LER_TELEFONE_SECTION()
        {
            /*" -5652- MOVE 'R0655-LER-TELEFONE' TO PARAGRAFO. */
            _.Move("R0655-LER-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5653- MOVE 'SELECT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("SELECT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5659- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -5660- IF R1-DDD (W-INDEX) NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD.IsNumeric())
            {

                /*" -5662- MOVE ZEROS TO R1-DDD (W-INDEX). */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD);
            }


            /*" -5668- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -5669- IF R1-NUM-FONE (W-INDEX) NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE.IsNumeric())
            {

                /*" -5671- MOVE ZEROS TO R1-NUM-FONE (W-INDEX). */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE);
            }


            /*" -5679- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -5682- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -5690- PERFORM R0655_LER_TELEFONE_DB_SELECT_1 */

            R0655_LER_TELEFONE_DB_SELECT_1();

            /*" -5693- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -5694- MOVE 'SIM' TO W-ACHOU-TELEFONE */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                /*" -5697- IF SQLCODE EQUAL ZEROS AND (PRODUTOS-VIDA-INDIVIDUAL OR VIDA-EXCLUSIVO-AIC) */

                if (DB.SQLCODE == 00 && (LBWPF002.W_PRODUTO["PRODUTOS_VIDA_INDIVIDUAL"] || LBWPF002.W_PRODUTO["VIDA_EXCLUSIVO_AIC"]))
                {

                    /*" -5698- MOVE 'UPDATE PESSOA-TELEFONE' TO COMANDO */
                    _.Move("UPDATE PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -5704- PERFORM R0655_LER_TELEFONE_DB_UPDATE_1 */

                    R0655_LER_TELEFONE_DB_UPDATE_1();

                    /*" -5706- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -5707- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -5708- GO TO R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION(); //GOTO
                        return;

                        /*" -5709- END-IF */
                    }


                    /*" -5710- END-IF */
                }


                /*" -5711- ELSE */
            }
            else
            {


                /*" -5712- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5713- MOVE 'NAO' TO W-ACHOU-TELEFONE */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                    /*" -5714- ELSE */
                }
                else
                {


                    /*" -5715- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -5716- DISPLAY '          ERRO SELECT TABELA PESSOA-TELEFONE' */
                    _.Display($"          ERRO SELECT TABELA PESSOA-TELEFONE");

                    /*" -5718- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                    _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                    /*" -5720- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -5722- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -5723- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -5723- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0655-LER-TELEFONE-DB-SELECT-1 */
        public void R0655_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -5690- EXEC SQL SELECT SITUACAO_FONE INTO :DCLPESSOA-TELEFONE.SITUACAO-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE AND DDD = :DCLPESSOA-TELEFONE.DDD END-EXEC. */

            var r0655_LER_TELEFONE_DB_SELECT_1_Query1 = new R0655_LER_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
            };

            var executed_1 = R0655_LER_TELEFONE_DB_SELECT_1_Query1.Execute(r0655_LER_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SITUACAO_FONE, PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);
            }


        }

        [StopWatch]
        /*" R0655-LER-TELEFONE-DB-UPDATE-1 */
        public void R0655_LER_TELEFONE_DB_UPDATE_1()
        {
            /*" -5704- EXEC SQL UPDATE SEGUROS.PESSOA_TELEFONE SET SITUACAO_FONE = 'P' WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE AND DDD = :DCLPESSOA-TELEFONE.DDD END-EXEC */

            var r0655_LER_TELEFONE_DB_UPDATE_1_Update1 = new R0655_LER_TELEFONE_DB_UPDATE_1_Update1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
            };

            R0655_LER_TELEFONE_DB_UPDATE_1_Update1.Execute(r0655_LER_TELEFONE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0655_SAIDA*/

        [StopWatch]
        /*" R0660-INCLUIR-NOVO-TELEFONE-SECTION */
        private void R0660_INCLUIR_NOVO_TELEFONE_SECTION()
        {
            /*" -5730- MOVE 'R0660-INCLUIR-NOVO-TELEFONE' TO PARAGRAFO. */
            _.Move("R0660-INCLUIR-NOVO-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5731- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5733- PERFORM R0665-OBTER-MAX-TELEFONE. */

            R0665_OBTER_MAX_TELEFONE_SECTION();

            /*" -5736- MOVE SEQ-FONE OF DCLPESSOA-TELEFONE TO W-SEQ-FONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE, WAREA_AUXILIAR.W_SEQ_FONE);

            /*" -5738- COMPUTE W-SEQ-FONE = W-SEQ-FONE + 1. */
            WAREA_AUXILIAR.W_SEQ_FONE.Value = WAREA_AUXILIAR.W_SEQ_FONE + 1;

            /*" -5738- PERFORM R0670-INCLUIR-TELEFONE. */

            R0670_INCLUIR_TELEFONE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0660_SAIDA*/

        [StopWatch]
        /*" R0665-OBTER-MAX-TELEFONE-SECTION */
        private void R0665_OBTER_MAX_TELEFONE_SECTION()
        {
            /*" -5745- MOVE 'R0665-OBTER-MAX-TELEFONE' TO PARAGRAFO. */
            _.Move("R0665-OBTER-MAX-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5746- MOVE 'MAX SEGUROS.PESSOA_TELEFONE' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5751- PERFORM R0665_OBTER_MAX_TELEFONE_DB_SELECT_1 */

            R0665_OBTER_MAX_TELEFONE_DB_SELECT_1();

            /*" -5754- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5755- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5756- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-TELEFONE' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-TELEFONE");

                /*" -5758- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -5760- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -5762- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5763- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5763- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0665-OBTER-MAX-TELEFONE-DB-SELECT-1 */
        public void R0665_OBTER_MAX_TELEFONE_DB_SELECT_1()
        {
            /*" -5751- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :DCLPESSOA-TELEFONE.SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA END-EXEC. */

            var r0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1 = new R0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
            };

            var executed_1 = R0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1.Execute(r0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0665_SAIDA*/

        [StopWatch]
        /*" R0670-INCLUIR-TELEFONE-SECTION */
        private void R0670_INCLUIR_TELEFONE_SECTION()
        {
            /*" -5770- MOVE 'R0670-INCLUI-TELEFONE' TO PARAGRAFO. */
            _.Move("R0670-INCLUI-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5771- MOVE 'INSERT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("INSERT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5775- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -5778- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -5781- MOVE W-SEQ-FONE TO SEQ-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);

            /*" -5784- MOVE 55 TO DDI OF DCLPESSOA-TELEFONE. */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -5787- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -5790- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -5792- IF PRODUTOS-VIDA-INDIVIDUAL OR VIDA-EXCLUSIVO-AIC */

            if (LBWPF002.W_PRODUTO["PRODUTOS_VIDA_INDIVIDUAL"] || LBWPF002.W_PRODUTO["VIDA_EXCLUSIVO_AIC"])
            {

                /*" -5794- MOVE 'P' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE */
                _.Move("P", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

                /*" -5795- ELSE */
            }
            else
            {


                /*" -5797- MOVE 'A' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE */
                _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

                /*" -5799- END-IF. */
            }


            /*" -5802- MOVE 'VA0600B' TO COD-USUARIO OF DCLPESSOA-TELEFONE. */
            _.Move("VA0600B", PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -5813- PERFORM R0670_INCLUIR_TELEFONE_DB_INSERT_1 */

            R0670_INCLUIR_TELEFONE_DB_INSERT_1();

            /*" -5816- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5817- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5818- DISPLAY '          ERRO INSERT TABELA PESSOA-TELEFONE' */
                _.Display($"          ERRO INSERT TABELA PESSOA-TELEFONE");

                /*" -5820- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -5822- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -5824- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5825- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5825- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0670-INCLUIR-TELEFONE-DB-INSERT-1 */
        public void R0670_INCLUIR_TELEFONE_DB_INSERT_1()
        {
            /*" -5813- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA-TELEFONE.COD-PESSOA, :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.SEQ-FONE, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1 = new R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                SEQ_FONE = PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE.ToString(),
                DDI = PESFONE.DCLPESSOA_TELEFONE.DDI.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                SITUACAO_FONE = PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE.ToString(),
                COD_USUARIO = PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO.ToString(),
            };

            R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1.Execute(r0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0670_SAIDA*/

        [StopWatch]
        /*" R0700-TRATA-PROPOSTA-SECTION */
        private void R0700_TRATA_PROPOSTA_SECTION()
        {
            /*" -5832- MOVE 'R0700-TRATA-PROPOSTA' TO PARAGRAFO */
            _.Move("R0700-TRATA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5833- MOVE ' ' TO COMANDO */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5835- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5837- PERFORM R0710-TRATA-TAB-RELACIONAMENTO */

            R0710_TRATA_TAB_RELACIONAMENTO_SECTION();

            /*" -5839- PERFORM R0750-TRATA-TAB-IDE-RELACIONAM */

            R0750_TRATA_TAB_IDE_RELACIONAM_SECTION();

            /*" -5841- PERFORM R0760-TRATA-PROP-FIDELIZACAO */

            R0760_TRATA_PROP_FIDELIZACAO_SECTION();

            /*" -5843- MOVE PROPOFID-COD-PRODUTO-SIVPF TO W-PRODUTO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, LBWPF002.W_PRODUTO);

            /*" -5843- PERFORM R0765-TRATA-PROP-ESPECIFICA. */

            R0765_TRATA_PROP_ESPECIFICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0710-TRATA-TAB-RELACIONAMENTO-SECTION */
        private void R0710_TRATA_TAB_RELACIONAMENTO_SECTION()
        {
            /*" -5850- MOVE 'R0710-TRATA-TAB-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R0710-TRATA-TAB-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5851- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5853- PERFORM R0715-DETERMINA-RELACIONAMENTO */

            R0715_DETERMINA_RELACIONAMENTO_SECTION();

            /*" -5855- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

            /*" -5857- PERFORM R0720-VERIFICA-EXISTE-RELACION. */

            R0720_VERIFICA_EXISTE_RELACION_SECTION();

            /*" -5858- IF W-ACHOU-RELACIONAMENTO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO == "NAO")
            {

                /*" -5858- PERFORM R0730-GERA-RELACIONAMENTO. */

                R0730_GERA_RELACIONAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_SAIDA*/

        [StopWatch]
        /*" R0715-DETERMINA-RELACIONAMENTO-SECTION */
        private void R0715_DETERMINA_RELACIONAMENTO_SECTION()
        {
            /*" -5865- MOVE 'R0715-DETERMINA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R0715-DETERMINA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5866- MOVE 'SELECT PRODUTOS_SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5868- IF RH-NOME OF REG-HEADER EQUAL 'PRPVG' OR 'PRPCTCRE' OR 'PRPATCOM' */

            if (LBFPF990.REG_HEADER.RH_NOME.In("PRPVG", "PRPCTCRE", "PRPATCOM"))
            {

                /*" -5870- MOVE 1 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Move(1, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

                /*" -5872- END-IF */
            }


            /*" -5873- IF RH-NOME OF REG-HEADER EQUAL 'PRPFPREV' */

            if (LBFPF990.REG_HEADER.RH_NOME == "PRPFPREV")
            {

                /*" -5875- MOVE 2 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Move(2, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

                /*" -5877- END-IF */
            }


            /*" -5878- IF RH-NOME OF REG-HEADER EQUAL 'PRPFCAP' */

            if (LBFPF990.REG_HEADER.RH_NOME == "PRPFCAP")
            {

                /*" -5880- MOVE 3 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Move(3, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

                /*" -5882- END-IF */
            }


            /*" -5885- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -5888- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO W-COD-EMPRESA. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, WREA88.W_COD_EMPRESA);

            /*" -5903- PERFORM R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1 */

            R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1();

            /*" -5906- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5907- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5908- DISPLAY '          ERRO SELECT TAB. PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT TAB. PRODUTOS-SIVPF");

                /*" -5910- DISPLAY '          NOME EMPRESA.................. ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME EMPRESA.................. {LBFPF990.REG_HEADER.RH_NOME}");

                /*" -5912- DISPLAY '          CODIGO DA EMPRESA............. ' PRDSIVPF-COD-EMPRESA-SIVPF */
                _.Display($"          CODIGO DA EMPRESA............. {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF}");

                /*" -5914- DISPLAY '          CODIGO DO PRODUTO............. ' PRDSIVPF-COD-PRODUTO-SIVPF */
                _.Display($"          CODIGO DO PRODUTO............. {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -5916- DISPLAY '       NUMERO DA PROPOSTA............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"       NUMERO DA PROPOSTA............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -5918- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5919- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5921- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -5925- MOVE PRDSIVPF-COD-RELAC OF DCLPRODUTOS-SIVPF TO W-COD-RELACION, W-RELACIONAMENTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC, WAREA_AUXILIAR.W_COD_RELACION, WREA88.W_RELACIONAMENTO);

            /*" -5926- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO W-PRODUTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, LBWPF002.W_PRODUTO);

        }

        [StopWatch]
        /*" R0715-DETERMINA-RELACIONAMENTO-DB-SELECT-1 */
        public void R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1()
        {
            /*" -5903- EXEC SQL SELECT DISTINCT COD_PRODUTO_SIVPF, COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF, :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF AND DTH_INI_VIGENCIA < :SISTEMAS-DATA-MOV-ABERTO AND DTH_FIM_VIGENCIA > :SISTEMAS-DATA-MOV-ABERTO order by COD_PRODUTO_SIVPF, COD_RELAC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1 = new R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_EMPRESA_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1.Execute(r0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0715_SAIDA*/

        [StopWatch]
        /*" R0720-VERIFICA-EXISTE-RELACION-SECTION */
        private void R0720_VERIFICA_EXISTE_RELACION_SECTION()
        {
            /*" -5933- MOVE 'R0720-VERIFICA-EXISTE-RELACION' TO PARAGRAFO. */
            _.Move("R0720-VERIFICA-EXISTE-RELACION", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5934- MOVE 'SELECT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("SELECT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5937- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -5940- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -5948- PERFORM R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1 */

            R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1();

            /*" -5951- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5952- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5953- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

                    /*" -5954- ELSE */
                }
                else
                {


                    /*" -5955- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -5956- DISPLAY '          ERRO SELECT TAB. PESSOA-TIPORELAC' */
                    _.Display($"          ERRO SELECT TAB. PESSOA-TIPORELAC");

                    /*" -5958- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                    /*" -5960- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                    /*" -5962- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -5963- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -5964- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -5965- ELSE */
                }

            }
            else
            {


                /*" -5965- MOVE 'SIM' TO W-ACHOU-RELACIONAMENTO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);
            }


        }

        [StopWatch]
        /*" R0720-VERIFICA-EXISTE-RELACION-DB-SELECT-1 */
        public void R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1()
        {
            /*" -5948- EXEC SQL SELECT COD_PESSOA, COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC END-EXEC. */

            var r0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 = new R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            var executed_1 = R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1.Execute(r0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);
                _.Move(executed_1.COD_RELAC, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0720_SAIDA*/

        [StopWatch]
        /*" R0730-GERA-RELACIONAMENTO-SECTION */
        private void R0730_GERA_RELACIONAMENTO_SECTION()
        {
            /*" -5972- MOVE 'R0730-GERA-RELACIONAMENTO' TO PARAGRAFO */
            _.Move("R0730-GERA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5973- MOVE 'INSERT PESSOAS_TIPORELAC' TO COMANDO */
            _.Move("INSERT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5976- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -5979- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -5983- PERFORM R0730_GERA_RELACIONAMENTO_DB_INSERT_1 */

            R0730_GERA_RELACIONAMENTO_DB_INSERT_1();

            /*" -5986- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5987- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -5988- DISPLAY '          ERRO INSERT TAB. PESSOA-TIPORELAC' */
                _.Display($"          ERRO INSERT TAB. PESSOA-TIPORELAC");

                /*" -5990- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                /*" -5992- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                /*" -5994- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5995- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5995- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0730-GERA-RELACIONAMENTO-DB-INSERT-1 */
        public void R0730_GERA_RELACIONAMENTO_DB_INSERT_1()
        {
            /*" -5983- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC) END-EXEC. */

            var r0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1 = new R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1.Execute(r0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0730_SAIDA*/

        [StopWatch]
        /*" R0750-TRATA-TAB-IDE-RELACIONAM-SECTION */
        private void R0750_TRATA_TAB_IDE_RELACIONAM_SECTION()
        {
            /*" -6002- MOVE 'R0750-TRATA-TAB-IDE-RELACIONAM' TO PARAGRAFO. */
            _.Move("R0750-TRATA-TAB-IDE-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6003- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6005- PERFORM R0755-OBTER-MAX-ID-RELACIONAM. */

            R0755_OBTER_MAX_ID_RELACIONAM_SECTION();

            /*" -6008- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO W-NUM-IDENTIF. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, WAREA_AUXILIAR.W_NUM_IDENTIF);

            /*" -6011- COMPUTE W-NUM-IDENTIF = W-NUM-IDENTIF + 1. */
            WAREA_AUXILIAR.W_NUM_IDENTIF.Value = WAREA_AUXILIAR.W_NUM_IDENTIF + 1;

            /*" -6014- MOVE W-NUM-IDENTIF TO NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC. */
            _.Move(WAREA_AUXILIAR.W_NUM_IDENTIF, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);

            /*" -6017- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -6020- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -6023- MOVE 'VA0600B' TO COD-USUARIO OF DCLIDENTIFICA-RELAC. */
            _.Move("VA0600B", IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO);

            /*" -6030- PERFORM R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1 */

            R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1();

            /*" -6033- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6034- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -6035- DISPLAY '          ERRO INSERT TABELA IDENTIFICA-RELAC.' */
                _.Display($"          ERRO INSERT TABELA IDENTIFICA-RELAC.");

                /*" -6037- DISPLAY '          NUM IDENTIFICACAO.............  ' NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC */
                _.Display($"          NUM IDENTIFICACAO.............  {IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO}");

                /*" -6039- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -6041- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -6043- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -6045- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6046- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6046- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0750-TRATA-TAB-IDE-RELACIONAM-DB-INSERT-1 */
        public void R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1()
        {
            /*" -6030- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO, :DCLIDENTIFICA-RELAC.COD-PESSOA, :DCLIDENTIFICA-RELAC.COD-RELAC, :DCLIDENTIFICA-RELAC.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 = new R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1()
            {
                NUM_IDENTIFICACAO = IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO.ToString(),
                COD_PESSOA = IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA.ToString(),
                COD_RELAC = IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC.ToString(),
                COD_USUARIO = IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO.ToString(),
            };

            R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1.Execute(r0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_SAIDA*/

        [StopWatch]
        /*" R0755-OBTER-MAX-ID-RELACIONAM-SECTION */
        private void R0755_OBTER_MAX_ID_RELACIONAM_SECTION()
        {
            /*" -6053- MOVE 'R0755-OBTER-MAX-ID-RELACIONAM' TO PARAGRAFO. */
            _.Move("R0755-OBTER-MAX-ID-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6054- MOVE 'MAX IDENTIFICA_RELAC' TO COMANDO. */
            _.Move("MAX IDENTIFICA_RELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6057- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -6060- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -6064- PERFORM R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1 */

            R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1();

            /*" -6067- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6068- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -6069- DISPLAY '          ERRO SELECT MAX TAB. IDENTIFICA-RELAC' */
                _.Display($"          ERRO SELECT MAX TAB. IDENTIFICA-RELAC");

                /*" -6071- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -6073- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -6075- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6076- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6076- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0755-OBTER-MAX-ID-RELACIONAM-DB-SELECT-1 */
        public void R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1()
        {
            /*" -6064- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC END-EXEC. */

            var r0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 = new R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1.Execute(r0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_IDENTIFICACAO, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0755_SAIDA*/

        [StopWatch]
        /*" R0760-TRATA-PROP-FIDELIZACAO-SECTION */
        private void R0760_TRATA_PROP_FIDELIZACAO_SECTION()
        {
            /*" -6083- MOVE 'R0760-TRATA-PROP-FIDELIZACAO' TO PARAGRAFO */
            _.Move("R0760-TRATA-PROP-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6084- MOVE ' ' TO COMANDO */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6086- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6089- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -6092- MOVE ' ' TO PROPOFID-SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(" ", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -6093- IF CANAL-VENDA-PAPEL */

            if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -6094- IF MOVTO-CEF-SIGAT */

                if (WREA88.W_TP_MOVIMENTO["MOVTO_CEF_SIGAT"])
                {

                    /*" -6096- MOVE 1 TO PROPOFID-CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                    _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

                    /*" -6097- ELSE */
                }
                else
                {


                    /*" -6098- IF MOVTO-SIVPF-FILIAL */

                    if (WREA88.W_TP_MOVIMENTO["MOVTO_SIVPF_FILIAL"])
                    {

                        /*" -6100- MOVE 2 TO PROPOFID-CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                        _.Move(2, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

                        /*" -6101- ELSE */
                    }
                    else
                    {


                        /*" -6102- DISPLAY 'VA0600B - FIM ANORMAL' */
                        _.Display($"VA0600B - FIM ANORMAL");

                        /*" -6105- DISPLAY '          MOVIMENTO <> DE CEF E FILIAL  ' W-TP-MOVIMENTO '  ' W-NUM-PROPOSTA */

                        $"          MOVIMENTO <> DE CEF E FILIAL  {WREA88.W_TP_MOVIMENTO}  {WREA88.W_NUM_PROPOSTA}"
                        .Display();

                        /*" -6106- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -6107- GO TO R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION(); //GOTO
                        return;

                        /*" -6108- END-IF */
                    }


                    /*" -6109- END-IF */
                }


                /*" -6110- ELSE */
            }
            else
            {


                /*" -6112- MOVE W-CANAL-PROPOSTA TO PROPOFID-CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move(WREA88.CANAL.W_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

                /*" -6117- END-IF */
            }


            /*" -6118- IF MOVTO-CEF-SIGAT */

            if (WREA88.W_TP_MOVIMENTO["MOVTO_CEF_SIGAT"])
            {

                /*" -6119- IF ORIGEM-REMOTA */

                if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_REMOTA"])
                {

                    /*" -6120- IF W-CANAL-PROPOSTA EQUAL 6 */

                    if (WREA88.CANAL.W_CANAL_PROPOSTA == 6)
                    {

                        /*" -6122- MOVE 1 TO PROPOFID-CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                        _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

                        /*" -6123- END-IF */
                    }


                    /*" -6124- END-IF */
                }


                /*" -6126- END-IF */
            }


            /*" -6127- IF MOVTO-SIVPF-FILIAL */

            if (WREA88.W_TP_MOVIMENTO["MOVTO_SIVPF_FILIAL"])
            {

                /*" -6128- IF ORIGEM-SIGAT */

                if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_SIGAT"])
                {

                    /*" -6130- MOVE 4 TO PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                    _.Move(4, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                    /*" -6131- ELSE */
                }
                else
                {


                    /*" -6133- MOVE R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                    _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                    /*" -6134- END-IF */
                }


                /*" -6135- ELSE */
            }
            else
            {


                /*" -6137- IF W-ORIGEM-PROPOSTA EQUAL 1009 OR 1010 OR 1021 OR 1022 OR 1023 OR 1024 OR 1025 */

                if (WREA88.W_ORIGEM_PROPOSTA.In("1009", "1010", "1021", "1022", "1023", "1024", "1025"))
                {

                    /*" -6139- MOVE W-ORIGEM-PROPOSTA TO PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                    _.Move(WREA88.W_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                    /*" -6140- ELSE */
                }
                else
                {


                    /*" -6142- MOVE R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                    _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                    /*" -6143- END-IF */
                }


                /*" -6145- END-IF */
            }


            /*" -6147- IF R3-VAL-TARIFA OF REG-PROPOSTA-SASSE NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA.IsNumeric())
            {

                /*" -6149- MOVE ZEROS TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

                /*" -6151- END-IF */
            }


            /*" -6153- IF R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.IsNumeric())
            {

                /*" -6155- MOVE ZEROS TO R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO);

                /*" -6158- END-IF */
            }


            /*" -6161- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -6162- PERFORM R0763-LER-RCAP */

            R0763_LER_RCAP_SECTION();

            /*" -6163- IF ENCONTROU-RCAP */

            if (WREA88.W_LEITURA_RCAP["ENCONTROU_RCAP"])
            {

                /*" -6166- MOVE RCAPS-NUM-TITULO OF DCLRCAPS TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

                /*" -6168- PERFORM R0764-LER-RCAPCOMP */

                R0764_LER_RCAPCOMP_SECTION();

                /*" -6169- IF ENCONTROU-RCAPCOMP */

                if (WREA88.W_LEITURA_RCAPCOMP["ENCONTROU_RCAPCOMP"])
                {

                    /*" -6171- MOVE RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR TO W-DATA-SQL */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -6172- MOVE W-DIA-SQL TO W-DIA-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA);

                    /*" -6173- MOVE W-MES-SQL TO W-MES-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA);

                    /*" -6174- MOVE W-ANO-SQL TO W-ANO-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA);

                    /*" -6177- MOVE W-DATA-DDMMAAAA TO R3-DTQITBCO OF REG-PROPOSTA-SASSE */
                    _.Move(WAREA_AUXILIAR.W_DATA_DDMMAAAA, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                    /*" -6179- MOVE RCAPCOMP-DATA-MOVIMENTO OF DCLRCAP-COMPLEMENTAR TO W-DATA-SQL */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -6180- MOVE W-DIA-SQL TO W-DIA-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA);

                    /*" -6181- MOVE W-MES-SQL TO W-MES-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA);

                    /*" -6182- MOVE W-ANO-SQL TO W-ANO-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA);

                    /*" -6185- MOVE W-DATA-DDMMAAAA TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE */
                    _.Move(WAREA_AUXILIAR.W_DATA_DDMMAAAA, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                    /*" -6187- MOVE RCAPCOMP-VAL-RCAP OF DCLRCAP-COMPLEMENTAR TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                    /*" -6188- ELSE */
                }
                else
                {


                    /*" -6194- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ NUM-SICOB OF DCLCONVERSAO-SICOB R3-NUM-SICOB OF REG-PROPOSTA-SASSE */
                    _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB);

                    /*" -6197- MOVE '01010001' TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE */
                    _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                    /*" -6198- IF R3-DTQITBCO OF REG-PROPOSTA-SASSE EQUAL ZEROS */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO == 00)
                    {

                        /*" -6200- MOVE '01010001' TO R3-DTQITBCO OF REG-PROPOSTA-SASSE */
                        _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                        /*" -6201- END-IF */
                    }


                    /*" -6202- END-IF */
                }


                /*" -6204- ELSE */
            }
            else
            {


                /*" -6205- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE EQUAL '3' */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == "3")
                {

                    /*" -6206- CONTINUE */

                    /*" -6207- ELSE */
                }
                else
                {


                    /*" -6213- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ NUM-SICOB OF DCLCONVERSAO-SICOB R3-NUM-SICOB OF REG-PROPOSTA-SASSE */
                    _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB);

                    /*" -6216- MOVE '01010001' TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE */
                    _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                    /*" -6217- IF R3-DTQITBCO OF REG-PROPOSTA-SASSE EQUAL ZEROS */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO == 00)
                    {

                        /*" -6220- MOVE '01010001' TO R3-DTQITBCO OF REG-PROPOSTA-SASSE */
                        _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                        /*" -6221- END-IF */
                    }


                    /*" -6222- END-IF */
                }


                /*" -6224- END-IF */
            }


            /*" -6225- IF CANAL-VENDA-PAPEL */

            if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -6229- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ NUM-SICOB OF DCLCONVERSAO-SICOB */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);

                /*" -6230- ELSE */
            }
            else
            {


                /*" -6231- PERFORM R0791-OBTER-NUM-SICOB */

                R0791_OBTER_NUM_SICOB_SECTION();

                /*" -6233- END-IF */
            }


            /*" -6236- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO R3-NUM-SICOB OF REG-PROPOSTA-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB);

            /*" -6239- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);

            /*" -6242- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-DATA-DDMMAAAA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -6244- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -6246- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -6249- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -6253- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -6255- MOVE W-DATA-SQL TO PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);

            /*" -6258- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -6261- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -6264- MOVE R3-AGECOBR OF REG-PROPOSTA-SASSE TO PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);

            /*" -6265- IF R3-DIA-DEBITO OF REG-PROPOSTA-SASSE > 0 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO > 0)
            {

                /*" -6266- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 3 */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 3)
                {

                    /*" -6267- IF R3-DIA-DEBITO OF REG-PROPOSTA-SASSE < 29 */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO < 29)
                    {

                        /*" -6269- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ */
                        _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

                        /*" -6270- ELSE */
                    }
                    else
                    {


                        /*" -6272- MOVE 28 TO PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ */
                        _.Move(28, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

                        /*" -6273- END-IF */
                    }


                    /*" -6274- ELSE */
                }
                else
                {


                    /*" -6276- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ */
                    _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

                    /*" -6277- END-IF */
                }


                /*" -6278- ELSE */
            }
            else
            {


                /*" -6280- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

                /*" -6282- END-IF */
            }


            /*" -6285- MOVE R3-OPCAOPAG OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

            /*" -6288- MOVE R3-AGECTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-AGECTADEB OF DCLPROPOSTA-FIDELIZ */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);

            /*" -6291- MOVE R3-OPRCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-OPRCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);

            /*" -6294- MOVE R3-NUMCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-NUMCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);

            /*" -6297- MOVE R3-DIGCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-DIGCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);

            /*" -6300- MOVE R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE TO PROPOFID-PERC-DESCONTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);

            /*" -6303- MOVE R3-NRMATRVEN OF REG-PROPOSTA-SASSE TO PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

            /*" -6309- MOVE ZEROS TO PROPOFID-AGECTAVEN OF DCLPROPOSTA-FIDELIZ PROPOFID-OPRCTAVEN OF DCLPROPOSTA-FIDELIZ PROPOFID-NUMCTAVEN OF DCLPROPOSTA-FIDELIZ PROPOFID-DIGCTAVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);

            /*" -6312- MOVE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);

            /*" -6315- MOVE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-NOME-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);

            /*" -6316- IF ORIGEM-AUTO-COMPRA-IBC OR ORIGEM-AUTO-COMPRA-LOJA */

            if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_IBC"] || WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_LOJA"])
            {

                /*" -6318- MOVE 1 TO PROPOFID-NRMATRCON OF DCLPROPOSTA-FIDELIZ */
                _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);

                /*" -6319- ELSE */
            }
            else
            {


                /*" -6321- MOVE ZEROS TO PROPOFID-NRMATRCON OF DCLPROPOSTA-FIDELIZ */
                _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);

                /*" -6323- END-IF */
            }


            /*" -6324- IF R3-DTQITBCO NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.IsNumeric())
            {

                /*" -6325- MOVE 01010001 TO R3-DTQITBCO */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                /*" -6339- END-IF. */
            }


            /*" -6341- IF ((CANAL-VENDA-INTRANET AND VIDA-DA-GENTE) OR ORIGEM-AUTO-COMPRA-IBC OR ORIGEM-AUTO-COMPRA-LOJA) */

            if (((WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_INTRANET"] && LBWPF002.W_PRODUTO["VIDA_DA_GENTE"]) || WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_IBC"] || WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AUTO_COMPRA_LOJA"]))
            {

                /*" -6342- IF R3-NUM-PROPOSTA(1:3) EQUAL ZEROS */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA.Substring(1, 3) == 00)
                {

                    /*" -6343- CONTINUE */

                    /*" -6344- ELSE */
                }
                else
                {


                    /*" -6346- IF R3-VAL-PAGO EQUAL R3-VALOR-PREMIO-TOTAL AND R3-DTQITBCO EQUAL R3-DATA-PROPOSTA */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO == LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL && LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO == LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA)
                    {

                        /*" -6347- CONTINUE */

                        /*" -6348- ELSE */
                    }
                    else
                    {


                        /*" -6350- IF R3-VALOR-PREMIO-TOTAL NOT EQUAL ZEROS AND R3-VAL-PAGO NOT EQUAL R3-VALOR-PREMIO-TOTAL */

                        if (LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL != 00 && LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO != LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL)
                        {

                            /*" -6351- MOVE R3-VALOR-PREMIO-TOTAL TO R3-VAL-PAGO */
                            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                            /*" -6352- END-IF */
                        }


                        /*" -6353- IF R3-DTQITBCO NOT EQUAL R3-DATA-PROPOSTA */

                        if (LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO != LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA)
                        {

                            /*" -6354- MOVE R3-DATA-PROPOSTA TO R3-DTQITBCO */
                            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                            /*" -6355- END-IF */
                        }


                        /*" -6356- END-IF */
                    }


                    /*" -6357- END-IF */
                }


                /*" -6360- END-IF */
            }


            /*" -6362- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-DDMMAAAA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -6364- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -6366- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -6369- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -6373- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -6376- MOVE W-DATA-SQL TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

            /*" -6378- IF BILHETE-AP OR BILHETE-RD */

            if (LBWPF002.W_PRODUTO["BILHETE_AP"] || LBWPF002.W_PRODUTO["BILHETE_RD"])
            {

                /*" -6379- IF CANAL-VENDA-GITEL */

                if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
                {

                    /*" -6381- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ */
                    _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

                    /*" -6383- IF R3-DIA-DEBITO OF REG-PROPOSTA-SASSE = ZEROS */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO == 00)
                    {

                        /*" -6385- MOVE 10 TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE */
                        _.Move(10, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);

                        /*" -6387- DISPLAY 'GITEL - DIA DEBITO ZERADO ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                        _.Display($"GITEL - DIA DEBITO ZERADO ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                        /*" -6388- END-IF */
                    }


                    /*" -6390- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO PROPOFID-DTQITBCO(9:2) */
                    _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, 9, 2);

                    /*" -6392- IF PROPOFID-DTQITBCO(9:2) LESS PROPOFID-DATA-PROPOSTA(9:2) */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Substring(9, 2) < PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Substring(9, 2))
                    {

                        /*" -6394- MOVE PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ TO WS-DTQITBCO */
                        _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, WAREA_AUXILIAR.WS_DTQITBCO);

                        /*" -6395- ADD 1 TO WS-DTQITBCO-MES */
                        WAREA_AUXILIAR.WS_DTQITBCO_R.WS_DTQITBCO_MES.Value = WAREA_AUXILIAR.WS_DTQITBCO_R.WS_DTQITBCO_MES + 1;

                        /*" -6396- IF WS-DTQITBCO-MES > 12 */

                        if (WAREA_AUXILIAR.WS_DTQITBCO_R.WS_DTQITBCO_MES > 12)
                        {

                            /*" -6397- MOVE 01 TO WS-DTQITBCO-MES */
                            _.Move(01, WAREA_AUXILIAR.WS_DTQITBCO_R.WS_DTQITBCO_MES);

                            /*" -6398- ADD 1 TO WS-DTQITBCO-ANO */
                            WAREA_AUXILIAR.WS_DTQITBCO_R.WS_DTQITBCO_ANO.Value = WAREA_AUXILIAR.WS_DTQITBCO_R.WS_DTQITBCO_ANO + 1;

                            /*" -6399- END-IF */
                        }


                        /*" -6401- MOVE WS-DTQITBCO TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ */
                        _.Move(WAREA_AUXILIAR.WS_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

                        /*" -6402- END-IF */
                    }


                    /*" -6403- END-IF */
                }


                /*" -6405- END-IF. */
            }


            /*" -6408- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

            /*" -6411- IF BILHETE-AP OR BILHETE-RD OR SEGURO-PRESTAMISTA */

            if (LBWPF002.W_PRODUTO["BILHETE_AP"] || LBWPF002.W_PRODUTO["BILHETE_RD"] || LBWPF002.W_PRODUTO["SEGURO_PRESTAMISTA"])
            {

                /*" -6413- MOVE R3-VALOR-PREMIO-TOTAL OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

                /*" -6415- END-IF */
            }


            /*" -6418- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO PROPOFID-AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);

            /*" -6421- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-TARIFA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);

            /*" -6424- MOVE ZEROS TO PROPOFID-VAL-IOF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);

            /*" -6427- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-DDMMAAAA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -6429- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -6431- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -6434- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -6438- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -6441- MOVE W-DATA-SQL TO PROPOFID-DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

            /*" -6444- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-COMISSAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);

            /*" -6447- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -6450- MOVE 'VA0600B' TO PROPOFID-COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("VA0600B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -6451- IF W-PRODUTO EQUAL 77 */

            if (LBWPF002.W_PRODUTO == 77)
            {

                /*" -6453- MOVE W-PERI-PGTO TO PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Move(WREA88.W_PERI_PGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

                /*" -6454- ELSE */
            }
            else
            {


                /*" -6456- MOVE ZEROS TO PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

                /*" -6459- END-IF. */
            }


            /*" -6462- MOVE W-QTD-LD-SIVPF-3 TO PROPOFID-NSL OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_SIVPF_3, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -6465- MOVE RH-NSAS OF REG-HEADER TO PROPOFID-NSAC-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF990.REG_HEADER.RH_NSAS, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);

            /*" -6468- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO PROPOFID-COD-PESSOA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);

            /*" -6471- MOVE R3-OPCAO-COBER OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAO-COBER OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);

            /*" -6472- IF SEGURO-PRESTAMISTA */

            if (LBWPF002.W_PRODUTO["SEGURO_PRESTAMISTA"])
            {

                /*" -6473- IF CANAL-VENDA-GITEL */

                if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
                {

                    /*" -6474- IF R3-OPCAO-COBER EQUAL ' ' */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER == " ")
                    {

                        /*" -6476- MOVE 12 TO R3-COD-PLANO */
                        _.Move(12, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

                        /*" -6477- END-IF */
                    }


                    /*" -6478- END-IF */
                }


                /*" -6480- END-IF. */
            }


            /*" -6481- MOVE R3-DATA-PROPOSTA TO WHOST-DATA-TRABALHO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WHOST_DATA_TRABALHO);

            /*" -6482- MOVE WHOST-DATA-TRABALHO(1:2) TO WHOST-DATA-PROPOSTA(9:2) */
            _.MoveAtPosition(WHOST_DATA_TRABALHO.Substring(1, 2), WHOST_DATA_PROPOSTA, 9, 2);

            /*" -6483- MOVE '-' TO WHOST-DATA-PROPOSTA(8:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 8, 1);

            /*" -6484- MOVE WHOST-DATA-TRABALHO(3:2) TO WHOST-DATA-PROPOSTA(6:2) */
            _.MoveAtPosition(WHOST_DATA_TRABALHO.Substring(3, 2), WHOST_DATA_PROPOSTA, 6, 2);

            /*" -6485- MOVE '-' TO WHOST-DATA-PROPOSTA(5:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 5, 1);

            /*" -6487- MOVE WHOST-DATA-TRABALHO(5:4) TO WHOST-DATA-PROPOSTA(1:4) */
            _.MoveAtPosition(WHOST_DATA_TRABALHO.Substring(5, 4), WHOST_DATA_PROPOSTA, 1, 4);

            /*" -6491- MOVE R3-COD-PLANO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PLANO OF DCLPROPOSTA-FIDELIZ PROPSSVD-NUM-PRAZO-FIN */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN);

            /*" -6492- IF WHOST-DATA-PROPOSTA >= LK-GEJVW002-JV-DTA-INI */

            if (WHOST_DATA_PROPOSTA >= GEJVW002.LK_GEJVW002_JV_DTA_INI)
            {

                /*" -6493- IF R3-COD-PLANO > 0 */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO > 0)
                {

                    /*" -6494- IF JVPROD(R3-COD-PLANO) > 0 */

                    if (JVBKINCL.FILLER.JVPROD[LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO] > 0)
                    {

                        /*" -6496- MOVE JVPROD(R3-COD-PLANO) TO PROPOFID-COD-PLANO OF DCLPROPOSTA-FIDELIZ */
                        _.Move(JVBKINCL.FILLER.JVPROD[LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO], PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);

                        /*" -6497- END-IF */
                    }


                    /*" -6498- END-IF */
                }


                /*" -6500- END-IF */
            }


            /*" -6503- MOVE R1-NOME-CONJUGE OF REG-CLIENTES TO PROPOFID-NOME-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);

            /*" -6506- MOVE R1-DTNASC-CONJUGE OF REG-CLIENTES TO W-DATA-DDMMAAAA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -6508- IF W-DATA-DDMMAAAA EQUAL 01010001 OR W-DATA-DDMMAAAA EQUAL ZEROS */

            if (WAREA_AUXILIAR.W_DATA_DDMMAAAA == 01010001 || WAREA_AUXILIAR.W_DATA_DDMMAAAA == 00)
            {

                /*" -6510- MOVE -1 TO VIND-DTNASC-ESPOSA */
                _.Move(-1, VIND_DTNASC_ESPOSA);

                /*" -6511- ELSE */
            }
            else
            {


                /*" -6513- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -6515- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -6517- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -6520- MOVE +0 TO VIND-DTNASC-ESPOSA */
                _.Move(+0, VIND_DTNASC_ESPOSA);

                /*" -6524- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -6527- MOVE W-DATA-SQL TO PROPOFID-DATA-NASC-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);
            }


            /*" -6528- MOVE +0 TO VIND-CBO-CONJ */
            _.Move(+0, VIND_CBO_CONJ);

            /*" -6531- MOVE R1-CBO-CONJUGE OF REG-CLIENTES TO PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);

            /*" -6534- MOVE R1-RENDA-INDIVIDUAL OF REG-CLIENTES TO PROPOFID-FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);

            /*" -6565- MOVE R1-RENDA-FAMILIAR OF REG-CLIENTES TO PROPOFID-FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_RENDA_FAMILIAR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);

            /*" -6566- MOVE R3-DATA-PROPOSTA TO W-DATA-DDMMAAAA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -6567- MOVE W-DIA-DDMMAAAA TO W-DIA-PROPOSTA */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.FILLER_17.W_DIA_PROPOSTA);

            /*" -6568- MOVE W-MES-DDMMAAAA TO W-MES-PROPOSTA */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.FILLER_17.W_MES_PROPOSTA);

            /*" -6570- MOVE W-ANO-DDMMAAAA TO W-ANO-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.FILLER_17.W_ANO_PROPOSTA);

            /*" -6574- IF VIDA-DA-GENTE OR MULTIPREMIADO-SUPER OR SENIOR OR SEGURO-VIDA-MULHER */

            if (LBWPF002.W_PRODUTO["VIDA_DA_GENTE"] || LBWPF002.W_PRODUTO["MULTIPREMIADO_SUPER"] || LBWPF002.W_PRODUTO["SENIOR"] || LBWPF002.W_PRODUTO["SEGURO_VIDA_MULHER"])
            {

                /*" -6575- IF CANAL-VENDA-PAPEL */

                if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                {

                    /*" -6576- IF W-DATA-PROPOSTA >= 20060701 */

                    if (WAREA_AUXILIAR.W_DATA_PROPOSTA.GetMoveValues().ToInt() >= 20060701)
                    {

                        /*" -6578- IF (VIDA-DA-GENTE AND R3-NUM-PROPOSTA < 84619128350) */

                        if ((LBWPF002.W_PRODUTO["VIDA_DA_GENTE"] && LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA < 84619128350))
                        {

                            /*" -6580- MOVE 'DEC' TO PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                            _.Move("DEC", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

                            /*" -6581- ELSE */
                        }
                        else
                        {


                            /*" -6583- IF (MULTIPREMIADO-SUPER AND R3-NUM-PROPOSTA < 84618078350) */

                            if ((LBWPF002.W_PRODUTO["MULTIPREMIADO_SUPER"] && LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA < 84618078350))
                            {

                                /*" -6585- MOVE 'DEC' TO PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                                _.Move("DEC", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

                                /*" -6586- ELSE */
                            }
                            else
                            {


                                /*" -6588- IF (SENIOR AND R3-NUM-PROPOSTA < 84620553350) */

                                if ((LBWPF002.W_PRODUTO["SENIOR"] && LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA < 84620553350))
                                {

                                    /*" -6590- MOVE 'DEC' TO PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                                    _.Move("DEC", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

                                    /*" -6591- ELSE */
                                }
                                else
                                {


                                    /*" -6593- IF (SEGURO-VIDA-MULHER AND R3-NUM-PROPOSTA < 84620078350) */

                                    if ((LBWPF002.W_PRODUTO["SEGURO_VIDA_MULHER"] && LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA < 84620078350))
                                    {

                                        /*" -6601- MOVE 'DEC' TO PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
                                        _.Move("DEC", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -6603- IF (R3-INDIC-TIPO-PROPOSTA OF REG-PROPOSTA-SASSE NOT EQUAL 'V' AND 'D' AND 'E' AND 'S' ) */

            if ((!LXFCT004.REG_PROPOSTA_SASSE.R3_INDIC_TIPO_PROPOSTA.In("V", "D", "E", "S")))
            {

                /*" -6604- MOVE -1 TO VIND-TP-PROP */
                _.Move(-1, VIND_TP_PROP);

                /*" -6605- ELSE */
            }
            else
            {


                /*" -6606- MOVE +0 TO VIND-TP-PROP */
                _.Move(+0, VIND_TP_PROP);

                /*" -6608- MOVE R3-INDIC-TIPO-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-IND-TP-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_INDIC_TIPO_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA);

                /*" -6610- END-IF */
            }


            /*" -6611- IF R3-INDIC-TIPO-CONTA OF REG-PROPOSTA-SASSE = 'S' OR 'N' */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_INDIC_TIPO_CONTA.In("S", "N"))
            {

                /*" -6613- MOVE R3-INDIC-TIPO-CONTA OF REG-PROPOSTA-SASSE TO PROPOFID-IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_INDIC_TIPO_CONTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

                /*" -6614- ELSE */
            }
            else
            {


                /*" -6616- MOVE 'N' TO PROPOFID-IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ */
                _.Move("N", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

                /*" -6625- END-IF. */
            }


            /*" -6627- PERFORM R7950-PROCURA-AVALIACAO-RISCO */

            R7950_PROCURA_AVALIACAO_RISCO_SECTION();

            /*" -6628- IF WS-ENCONTROU-RISCO EQUAL 'NAO' */

            if (WS_ENCONTROU_RISCO == "NAO")
            {

                /*" -6629- MOVE 'PCR' TO PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move("PCR", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

                /*" -6630- ADD 1 TO WS-QT-SITUACAO-PCR */
                WS_QT_SITUACAO_PCR.Value = WS_QT_SITUACAO_PCR + 1;

                /*" -6634- END-IF */
            }


            /*" -6742- PERFORM R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1 */

            R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1();

            /*" -6745- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6746- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -6747- DISPLAY '          ERRO INSERT TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA PROPOSTA FIDELIZ");

                /*" -6749- DISPLAY '          CODIGO PESSOA.................  ' PROPOFID-COD-PESSOA OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          CODIGO PESSOA.................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                /*" -6751- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -6753- DISPLAY '          COD-EMPRESA...................  ' PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          COD-EMPRESA...................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF}");

                /*" -6755- DISPLAY '          COD-PRODUTO-SIVPF.............  ' PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          COD-PRODUTO-SIVPF.............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -6757- DISPLAY '          SIT-PROPOSTA .................  ' PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          SIT-PROPOSTA .................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA}");

                /*" -6759- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6760- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6762- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -6763- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

        }

        [StopWatch]
        /*" R0760-TRATA-PROP-FIDELIZACAO-DB-INSERT-1 */
        public void R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -6742- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF , NUM_IDENTIFICACAO , COD_EMPRESA_SIVPF , COD_PESSOA , NUM_SICOB , DATA_PROPOSTA , COD_PRODUTO_SIVPF , AGECOBR , DIA_DEBITO , OPCAOPAG , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , PERC_DESCONTO , NRMATRVEN , AGECTAVEN , OPRCTAVEN , NUMCTAVEN , DIGCTAVEN , CGC_CONVENENTE , NOME_CONVENENTE , NRMATRCON , DTQITBCO , VAL_PAGO , AGEPGTO , VAL_TARIFA , VAL_IOF , DATA_CREDITO , VAL_COMISSAO , SIT_PROPOSTA , COD_USUARIO , CANAL_PROPOSTA , NSAS_SIVPF , ORIGEM_PROPOSTA , TIMESTAMP , NSL , NSAC_SIVPF , SITUACAO_ENVIO , OPCAO_COBER , COD_PLANO , NOME_CONJUGE , DATA_NASC_CONJUGE , PROFISSAO_CONJUGE , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , IND_TP_PROPOSTA , IND_TIPO_CONTA ) VALUES ( :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAOPAG, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN, :DCLPESSOA-ENDERECO.OCORR-ENDERECO , :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRCON, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-IOF, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-USUARIO, :DCLPROPOSTA-FIDELIZ.PROPOFID-CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA, CURRENT TIMESTAMP, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSL, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-SITUACAO-ENVIO, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO, :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DTNASC-ESPOSA, :DCLPROPOSTA-FIDELIZ.PROPOFID-PROFISSAO-CONJUGE :VIND-CBO-CONJ, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM, :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TP-PROPOSTA :VIND-TP-PROP, :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TIPO-CONTA ) END-EXEC. */

            var r0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 = new R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
                PROPOFID_DATA_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_DIA_DEBITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.ToString(),
                PROPOFID_OPCAOPAG = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                PROPOFID_PERC_DESCONTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                OCORR_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                PROPOFID_NOME_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE.ToString(),
                PROPOFID_NRMATRCON = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PROPOFID_AGEPGTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO.ToString(),
                PROPOFID_VAL_TARIFA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA.ToString(),
                PROPOFID_VAL_IOF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF.ToString(),
                PROPOFID_DATA_CREDITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.ToString(),
                PROPOFID_VAL_COMISSAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOFID_CANAL_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_NSAC_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF.ToString(),
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DTNASC_ESPOSA = VIND_DTNASC_ESPOSA.ToString(),
                PROPOFID_PROFISSAO_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE.ToString(),
                VIND_CBO_CONJ = VIND_CBO_CONJ.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                PROPOFID_IND_TP_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA.ToString(),
                VIND_TP_PROP = VIND_TP_PROP.ToString(),
                PROPOFID_IND_TIPO_CONTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA.ToString(),
            };

            R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0760_SAIDA*/

        [StopWatch]
        /*" R0761-00-OBTER-VAL-TARIFA-SECTION */
        private void R0761_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -6773- MOVE 'R0761-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0761-00-OBTER-VAL-TARIFA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6774- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6777- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -6788- PERFORM R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -6791- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6792- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6793- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -6794- ELSE */
                }
                else
                {


                    /*" -6795- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -6796- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -6798- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -6800- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -6801- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -6801- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0761-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -6788- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO END-EXEC. */

            var r0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 = new R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1.Execute(r0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VAL_TARIFA, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0761_SAIDA*/

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-SECTION */
        private void R0762_00_OBTER_COMISSAO_SECTION()
        {
            /*" -6808- MOVE 'R0762-00-OBTER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0762-00-OBTER-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6809- MOVE 'SELECT FUNDOCOMISVA' TO COMANDO. */
            _.Move("SELECT FUNDOCOMISVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6812- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -6815- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -6825- PERFORM R0762_00_OBTER_COMISSAO_DB_DECLARE_1 */

            R0762_00_OBTER_COMISSAO_DB_DECLARE_1();

            /*" -6828- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6829- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6832- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -6833- GO TO R0762-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0762_SAIDA*/ //GOTO
                    return;

                    /*" -6834- ELSE */
                }
                else
                {


                    /*" -6835- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -6836- DISPLAY '          ERRO DECLARE CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO DECLARE CURSOR FUNDOCOMISVA");

                    /*" -6838- DISPLAY '          NUMERO CERTIFICADO.............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO.............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -6840- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -6841- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -6843- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6843- PERFORM R0762_00_OBTER_COMISSAO_DB_OPEN_1 */

            R0762_00_OBTER_COMISSAO_DB_OPEN_1();

            /*" -6846- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6847- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -6848- DISPLAY '          ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -6850- DISPLAY '          NUMERO CERTIFICADO........... ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO........... {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -6852- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -6853- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6855- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -6861- PERFORM R0762_00_OBTER_COMISSAO_DB_FETCH_1 */

            R0762_00_OBTER_COMISSAO_DB_FETCH_1();

            /*" -6864- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6865- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6868- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -6869- ELSE */
                }
                else
                {


                    /*" -6870- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -6871- DISPLAY '          ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -6873- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -6875- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -6876- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -6878- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6878- PERFORM R0762_00_OBTER_COMISSAO_DB_CLOSE_1 */

            R0762_00_OBTER_COMISSAO_DB_CLOSE_1();

            /*" -6881- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6882- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -6883- DISPLAY '          ERRO CLOSE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO CLOSE CURSOR FUNDOCOMISVA");

                /*" -6885- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO............ {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -6887- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -6888- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6889- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6891- END-IF */
            }


            /*" -6891- . */

        }

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-DB-OPEN-1 */
        public void R0762_00_OBTER_COMISSAO_DB_OPEN_1()
        {
            /*" -6843- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-DB-DECLARE-1 */
        public void R6200_00_DECLARE_FONTES_DB_DECLARE_1()
        {
            /*" -9347- EXEC SQL DECLARE CFONTES CURSOR FOR SELECT COD_FONTE, ULT_PROP_AUTOMAT FROM SEGUROS.FONTES ORDER BY COD_FONTE END-EXEC. */
            CFONTES = new VA0600B_CFONTES(false);
            string GetQuery_CFONTES()
            {
                var query = @$"SELECT COD_FONTE
							, 
							ULT_PROP_AUTOMAT 
							FROM SEGUROS.FONTES 
							ORDER BY COD_FONTE";

                return query;
            }
            CFONTES.GetQueryEvent += GetQuery_CFONTES;

        }

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-DB-FETCH-1 */
        public void R0762_00_OBTER_COMISSAO_DB_FETCH_1()
        {
            /*" -6861- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

            if (FUNDOCOMISVA.Fetch())
            {
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);
            }

        }

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-DB-CLOSE-1 */
        public void R0762_00_OBTER_COMISSAO_DB_CLOSE_1()
        {
            /*" -6878- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0762_SAIDA*/

        [StopWatch]
        /*" R0763-LER-RCAP-SECTION */
        private void R0763_LER_RCAP_SECTION()
        {
            /*" -6898- MOVE 'R0763-LER-RCAP' TO PARAGRAFO */
            _.Move("R0763-LER-RCAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6899- MOVE 'SELECT RCAP' TO COMANDO */
            _.Move("SELECT RCAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6902- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO RCAPS-NUM-TITULO OF DCLRCAPS */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -6916- PERFORM R0763_LER_RCAP_DB_SELECT_1 */

            R0763_LER_RCAP_DB_SELECT_1();

            /*" -6919- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -6921- MOVE 1 TO W-LEITURA-RCAP */
                _.Move(1, WREA88.W_LEITURA_RCAP);

                /*" -6922- IF VIND-RCAPS-AGE LESS ZERO */

                if (VIND_RCAPS_AGE < 00)
                {

                    /*" -6923- MOVE ZEROS TO RCAPS-AGE-COBRANCA OF DCLRCAPS */
                    _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);

                    /*" -6924- END-IF */
                }


                /*" -6925- ELSE */
            }
            else
            {


                /*" -6926- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6927- MOVE 2 TO W-LEITURA-RCAP */
                    _.Move(2, WREA88.W_LEITURA_RCAP);

                    /*" -6928- ELSE */
                }
                else
                {


                    /*" -6929- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -6930- MOVE 1 TO W-LEITURA-RCAP */
                        _.Move(1, WREA88.W_LEITURA_RCAP);

                        /*" -6931- ELSE */
                    }
                    else
                    {


                        /*" -6932- DISPLAY 'VA0600B - FIM ANORMAL' */
                        _.Display($"VA0600B - FIM ANORMAL");

                        /*" -6933- DISPLAY '          ERRO LEITURA RCAP ' SQLCODE */
                        _.Display($"          ERRO LEITURA RCAP {DB.SQLCODE}");

                        /*" -6935- DISPLAY '          NUMERO PROPOSTA   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                        _.Display($"          NUMERO PROPOSTA   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                        /*" -6936- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -6937- GO TO R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION(); //GOTO
                        return;

                        /*" -6938- END-IF */
                    }


                    /*" -6939- END-IF */
                }


                /*" -6941- END-IF */
            }


            /*" -6941- . */

        }

        [StopWatch]
        /*" R0763-LER-RCAP-DB-SELECT-1 */
        public void R0763_LER_RCAP_DB_SELECT_1()
        {
            /*" -6916- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP, AGE_COBRANCA INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLRCAPS.RCAPS-AGE-COBRANCA:VIND-RCAPS-AGE FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC */

            var r0763_LER_RCAP_DB_SELECT_1_Query1 = new R0763_LER_RCAP_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0763_LER_RCAP_DB_SELECT_1_Query1.Execute(r0763_LER_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(executed_1.VIND_RCAPS_AGE, VIND_RCAPS_AGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0763_SAIDA*/

        [StopWatch]
        /*" R0764-LER-RCAPCOMP-SECTION */
        private void R0764_LER_RCAPCOMP_SECTION()
        {
            /*" -6948- MOVE 'R0764-LER-RCAPCOMP' TO PARAGRAFO. */
            _.Move("R0764-LER-RCAPCOMP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6949- MOVE 'SELECT RCAPCOMP' TO COMANDO. */
            _.Move("SELECT RCAPCOMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6967- PERFORM R0764_LER_RCAPCOMP_DB_SELECT_1 */

            R0764_LER_RCAPCOMP_DB_SELECT_1();

            /*" -6970- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -6971- MOVE 1 TO W-LEITURA-RCAPCOMP */
                _.Move(1, WREA88.W_LEITURA_RCAPCOMP);

                /*" -6972- ELSE */
            }
            else
            {


                /*" -6973- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6974- MOVE 2 TO W-LEITURA-RCAPCOMP */
                    _.Move(2, WREA88.W_LEITURA_RCAPCOMP);

                    /*" -6975- ELSE */
                }
                else
                {


                    /*" -6976- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -6994- PERFORM R0764_LER_RCAPCOMP_DB_SELECT_2 */

                        R0764_LER_RCAPCOMP_DB_SELECT_2();

                        /*" -6997- IF SQLCODE EQUAL 00 */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -6998- MOVE 1 TO W-LEITURA-RCAPCOMP */
                            _.Move(1, WREA88.W_LEITURA_RCAPCOMP);

                            /*" -6999- ELSE */
                        }
                        else
                        {


                            /*" -7000- IF SQLCODE EQUAL 100 */

                            if (DB.SQLCODE == 100)
                            {

                                /*" -7001- MOVE 2 TO W-LEITURA-RCAPCOMP */
                                _.Move(2, WREA88.W_LEITURA_RCAPCOMP);

                                /*" -7002- ELSE */
                            }
                            else
                            {


                                /*" -7003- IF SQLCODE EQUAL -811 */

                                if (DB.SQLCODE == -811)
                                {

                                    /*" -7004- MOVE 1 TO W-LEITURA-RCAPCOMP */
                                    _.Move(1, WREA88.W_LEITURA_RCAPCOMP);

                                    /*" -7005- ELSE */
                                }
                                else
                                {


                                    /*" -7006- DISPLAY 'VA0600B - FIM ANORMAL' */
                                    _.Display($"VA0600B - FIM ANORMAL");

                                    /*" -7007- DISPLAY '  ERRO LEITURA RCAPCOMP ' SQLCODE */
                                    _.Display($"  ERRO LEITURA RCAPCOMP {DB.SQLCODE}");

                                    /*" -7010- DISPLAY '          NUMERO PROPOSTA...... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                                    _.Display($"          NUMERO PROPOSTA...... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                                    /*" -7011- PERFORM R9988-00-FECHAR-ARQUIVOS */

                                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                                    /*" -7012- GO TO R9999-00-FINALIZAR */

                                    R9999_00_FINALIZAR_SECTION(); //GOTO
                                    return;

                                    /*" -7013- ELSE */
                                }

                            }

                        }

                    }
                    else
                    {


                        /*" -7014- DISPLAY 'VA0600B - FIM ANORMAL' */
                        _.Display($"VA0600B - FIM ANORMAL");

                        /*" -7015- DISPLAY '          ERRO LEITURA RCAPCOMP ' SQLCODE */
                        _.Display($"          ERRO LEITURA RCAPCOMP {DB.SQLCODE}");

                        /*" -7017- DISPLAY '          NUMERO PROPOSTA...... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                        _.Display($"          NUMERO PROPOSTA...... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                        /*" -7018- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -7018- GO TO R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0764-LER-RCAPCOMP-DB-SELECT-1 */
        public void R0764_LER_RCAPCOMP_DB_SELECT_1()
        {
            /*" -6967- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, VAL_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-VAL-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE =:DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP =:DCLRCAPS.RCAPS-NUM-RCAP AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r0764_LER_RCAPCOMP_DB_SELECT_1_Query1 = new R0764_LER_RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R0764_LER_RCAPCOMP_DB_SELECT_1_Query1.Execute(r0764_LER_RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0764_SAIDA*/

        [StopWatch]
        /*" R0764-LER-RCAPCOMP-DB-SELECT-2 */
        public void R0764_LER_RCAPCOMP_DB_SELECT_2()
        {
            /*" -6994- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, VAL_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-VAL-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 END-EXEC */

            var r0764_LER_RCAPCOMP_DB_SELECT_2_Query1 = new R0764_LER_RCAPCOMP_DB_SELECT_2_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R0764_LER_RCAPCOMP_DB_SELECT_2_Query1.Execute(r0764_LER_RCAPCOMP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
            }


        }

        [StopWatch]
        /*" R0765-TRATA-PROP-ESPECIFICA-SECTION */
        private void R0765_TRATA_PROP_ESPECIFICA_SECTION()
        {
            /*" -7025- MOVE 'R0765-TRATA-PROP-ESPECIFICA' TO PARAGRAFO. */
            _.Move("R0765-TRATA-PROP-ESPECIFICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7026- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7028- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7031- MOVE W-COD-RELACION TO W-RELACIONAMENTO. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, WREA88.W_RELACIONAMENTO);

            /*" -7033- IF SEGURO-VIDA OR SEGURO-PRESTAMISTA */

            if (WREA88.W_RELACIONAMENTO["SEGURO_VIDA"] || LBWPF002.W_PRODUTO["SEGURO_PRESTAMISTA"])
            {

                /*" -7034- PERFORM R77100-GERA-PROP-VIDA */

                R77100_GERA_PROP_VIDA_SECTION();

                /*" -7035- ELSE */
            }
            else
            {


                /*" -7036- IF BILHETE-R */

                if (WREA88.W_RELACIONAMENTO["BILHETE_R"])
                {

                    /*" -7037- PERFORM R0773-GERA-PROP-BILHETE */

                    R0773_GERA_PROP_BILHETE_SECTION();

                    /*" -7038- ELSE */
                }
                else
                {


                    /*" -7039- IF PRODUTO-AUTOMOVEL */

                    if (LBWPF002.W_PRODUTO["PRODUTO_AUTOMOVEL"])
                    {

                        /*" -7040- CONTINUE */

                        /*" -7041- ELSE */
                    }
                    else
                    {


                        /*" -7042- IF MULTIRISCO */

                        if (WREA88.W_RELACIONAMENTO["MULTIRISCO"])
                        {

                            /*" -7043- PERFORM R0768-GERAR-TAB-ACOMP-PROP */

                            R0768_GERAR_TAB_ACOMP_PROP_SECTION();

                            /*" -7044- ELSE */
                        }
                        else
                        {


                            /*" -7045- DISPLAY 'VA0600B - FIM ANORMAL' */
                            _.Display($"VA0600B - FIM ANORMAL");

                            /*" -7046- DISPLAY '          RELACIONAMENTO INVALIDO' */
                            _.Display($"          RELACIONAMENTO INVALIDO");

                            /*" -7048- DISPLAY '          EMPRESA PROCESSADA - SASSE ' RH-NOME OF REG-HEADER */
                            _.Display($"          EMPRESA PROCESSADA - SASSE {LBFPF990.REG_HEADER.RH_NOME}");

                            /*" -7051- DISPLAY '          NUMERO PROPOSTA........... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                            _.Display($"          NUMERO PROPOSTA........... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                            /*" -7053- DISPLAY '          CODIGO RELACIONAMENTO..... ' W-RELACIONAMENTO */
                            _.Display($"          CODIGO RELACIONAMENTO..... {WREA88.W_RELACIONAMENTO}");

                            /*" -7054- PERFORM R9988-00-FECHAR-ARQUIVOS */

                            R9988_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -7055- GO TO R9999-00-FINALIZAR */

                            R9999_00_FINALIZAR_SECTION(); //GOTO
                            return;

                            /*" -7056- END-IF */
                        }


                        /*" -7057- END-IF */
                    }


                    /*" -7058- END-IF */
                }


                /*" -7060- END-IF */
            }


            /*" -7060- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0765_SAIDA*/

        [StopWatch]
        /*" R0768-GERAR-TAB-ACOMP-PROP-SECTION */
        private void R0768_GERAR_TAB_ACOMP_PROP_SECTION()
        {
            /*" -7067- MOVE 'R0768-GERAR-ACOMP-PROP' TO PARAGRAFO */
            _.Move("R0768-GERAR-ACOMP-PROP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7068- MOVE 'INSERT PF-ACOMP-PROPOSTAS' TO COMANDO */
            _.Move("INSERT PF-ACOMP-PROPOSTAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7071- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO PFACOPRO-DTH-INCLUSAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PFACOPRO.DCLPF_ACOMP_PROPOSTAS.PFACOPRO_DTH_INCLUSAO);

            /*" -7073- MOVE 'VA0600B' TO PFACOPRO-COD-USUARIO. */
            _.Move("VA0600B", PFACOPRO.DCLPF_ACOMP_PROPOSTAS.PFACOPRO_COD_USUARIO);

            /*" -7083- PERFORM R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1 */

            R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1();

            /*" -7086- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -7087- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -7088- DISPLAY '          ERRO INSERT TAB. PF_ACOMP_PSOPOSTAS' */
                _.Display($"          ERRO INSERT TAB. PF_ACOMP_PSOPOSTAS");

                /*" -7090- DISPLAY '          NUMERO PROPOSTA.................... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA.................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -7092- DISPLAY '          SQLCODE............................ ' SQLCODE */
                _.Display($"          SQLCODE............................ {DB.SQLCODE}");

                /*" -7093- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -7093- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0768-GERAR-TAB-ACOMP-PROP-DB-INSERT-1 */
        public void R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1()
        {
            /*" -7083- EXEC SQL INSERT INTO SEGUROS.PF_ACOMP_PROPOSTAS VALUES (:PROPOFID-NUM-PROPOSTA-SIVPF, NULL , NULL , NULL , NULL , :PFACOPRO-DTH-INCLUSAO , :PFACOPRO-COD-USUARIO , CURRENT TIMESTAMP) END-EXEC. */

            var r0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1 = new R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PFACOPRO_DTH_INCLUSAO = PFACOPRO.DCLPF_ACOMP_PROPOSTAS.PFACOPRO_DTH_INCLUSAO.ToString(),
                PFACOPRO_COD_USUARIO = PFACOPRO.DCLPF_ACOMP_PROPOSTAS.PFACOPRO_COD_USUARIO.ToString(),
            };

            R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1.Execute(r0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0768_SAIDA*/

        [StopWatch]
        /*" R77100-GERA-PROP-VIDA-SECTION */
        private void R77100_GERA_PROP_VIDA_SECTION()
        {
            /*" -7100- MOVE 'R77100-GERA-PROP-VIDA' TO PARAGRAFO */
            _.Move("R77100-GERA-PROP-VIDA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7101- MOVE 'INSERT PROPOSTA-SASSE' TO COMANDO */
            _.Move("INSERT PROPOSTA-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7103- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7107- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO);

            /*" -7109- IF SEGURO-VIDA-MULHER OR W-PRODUTO EQUAL 9341 */

            if (LBWPF002.W_PRODUTO["SEGURO_VIDA_MULHER"] || LBWPF002.W_PRODUTO == 9341)
            {

                /*" -7112- MOVE R6-DPS-TITULAR OF REGISTRO-VIDA-MULHER TO PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA */
                _.Move(LBFPF161.REGISTRO_VIDA_MULHER.R6_DPS_TITULAR, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR);

                /*" -7114- MOVE R6-DPS-CONJUGE OF REGISTRO-VIDA-MULHER TO PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA */
                _.Move(LBFPF161.REGISTRO_VIDA_MULHER.R6_DPS_CONJUGE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE);

                /*" -7115- ELSE */
            }
            else
            {


                /*" -7118- MOVE R3-DPS-TITULAR OF REG-PROPOSTA-SASSE TO PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR);

                /*" -7121- MOVE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE TO PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA. */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE);
            }


            /*" -7124- MOVE R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE TO PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ);

            /*" -7128- MOVE 'VA0600B' TO PROPSSVD-COD-USUARIO OF DCLPROP-SASSE-VIDA. */
            _.Move("VA0600B", PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO);

            /*" -7129- MOVE R3-DATA-PROPOSTA TO W-DATA-DDMMAAAA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -7130- MOVE W-DIA-DDMMAAAA TO W-DIA-PROPOSTA */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.FILLER_17.W_DIA_PROPOSTA);

            /*" -7131- MOVE W-MES-DDMMAAAA TO W-MES-PROPOSTA */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.FILLER_17.W_MES_PROPOSTA);

            /*" -7133- MOVE W-ANO-DDMMAAAA TO W-ANO-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.FILLER_17.W_ANO_PROPOSTA);

            /*" -7134- MOVE W-DATA-DDMMAAAA(1:2) TO WHOST-DATA-PROPOSTA(9:2) */
            _.MoveAtPosition(WAREA_AUXILIAR.W_DATA_DDMMAAAA.Substring(1, 2), WHOST_DATA_PROPOSTA, 9, 2);

            /*" -7135- MOVE '-' TO WHOST-DATA-PROPOSTA(8:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 8, 1);

            /*" -7136- MOVE W-DATA-DDMMAAAA(3:2) TO WHOST-DATA-PROPOSTA(6:2) */
            _.MoveAtPosition(WAREA_AUXILIAR.W_DATA_DDMMAAAA.Substring(3, 2), WHOST_DATA_PROPOSTA, 6, 2);

            /*" -7137- MOVE '-' TO WHOST-DATA-PROPOSTA(5:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 5, 1);

            /*" -7139- MOVE W-DATA-DDMMAAAA(5:4) TO WHOST-DATA-PROPOSTA(1:4) */
            _.MoveAtPosition(WAREA_AUXILIAR.W_DATA_DDMMAAAA.Substring(5, 4), WHOST_DATA_PROPOSTA, 1, 4);

            /*" -7151- IF VIDA-DA-GENTE OR MULTIPREMIADO-SUPER OR SENIOR OR SEGURO-VIDA-MULHER OR SEGURO-PRESTAMISTA OR ORIGEM-AIC OR VIDA-EXCLUSIVO-AIC OR PROTECAO-EXECUTIVA OR VIDA-CONFORTO */

            if (LBWPF002.W_PRODUTO["VIDA_DA_GENTE"] || LBWPF002.W_PRODUTO["MULTIPREMIADO_SUPER"] || LBWPF002.W_PRODUTO["SENIOR"] || LBWPF002.W_PRODUTO["SEGURO_VIDA_MULHER"] || LBWPF002.W_PRODUTO["SEGURO_PRESTAMISTA"] || WREA88.W_ORIGEM_PROPOSTA["ORIGEM_AIC"] || LBWPF002.W_PRODUTO["VIDA_EXCLUSIVO_AIC"] || LBWPF002.W_PRODUTO["PROTECAO_EXECUTIVA"] || LBWPF002.W_PRODUTO["VIDA_CONFORTO"])
            {

                /*" -7152- PERFORM R77200-OBTER-APOLICE-SUBES */

                R77200_OBTER_APOLICE_SUBES_SECTION();

                /*" -7161- DISPLAY '$ /' R3-NUM-PROPOSTA '/' R3-COD-PRODUTO '/' R3-PERIPGTO '/' R3-DATA-PROPOSTA '/' R3-OPCAO-COBER '/' R3-OPCAO-CONJUGE '/' VG130-NUM-APOLICE '/' VG130-COD-SUBGRUPO */

                $"$ /{LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}/{LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO}/{LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO}/{LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA}/{LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER}/{LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}"
                .Display();

                /*" -7162- GO TO R77100-10-NEXT */

                R77100_10_NEXT(); //GOTO
                return;

                /*" -7164- END-IF */
            }


            /*" -7171- IF VIDAZUL-EMPRESARIAL-SUPER */

            if (LBWPF002.W_PRODUTO["VIDAZUL_EMPRESARIAL_SUPER"])
            {

                /*" -7173- MOVE 3009300012678 TO VG130-NUM-APOLICE WHOST-APOLICE-PLANO */
                _.Move(3009300012678, VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE, WHOST_APOLICE_PLANO);

                /*" -7175- MOVE 1 TO VG130-COD-SUBGRUPO WHOST-CODSUBES-PLANO */
                _.Move(1, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO, WHOST_CODSUBES_PLANO);

                /*" -7177- END-IF */
            }


            /*" -7177- . */

            /*" -0- FLUXCONTROL_PERFORM R77100_10_NEXT */

            R77100_10_NEXT();

        }

        [StopWatch]
        /*" R77100-10-NEXT */
        private void R77100_10_NEXT(bool isPerform = false)
        {
            /*" -7188- IF VG130-NUM-APOLICE NOT EQUAL WHOST-APOLICE-PLANO OR VG130-COD-SUBGRUPO NOT EQUAL WHOST-CODSUBES-PLANO */

            if (VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE != WHOST_APOLICE_PLANO || VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO != WHOST_CODSUBES_PLANO)
            {

                /*" -7189- DISPLAY 'OBSERVAR MOTIVO DA SUBSTITUICAO DA APOLICE' */
                _.Display($"OBSERVAR MOTIVO DA SUBSTITUICAO DA APOLICE");

                /*" -7190- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -7192- DISPLAY '          NUMERO PROPOSTA.................... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA.................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -7194- DISPLAY ' WHOST-APOLICE-PLANO......................... ' WHOST-APOLICE-PLANO */
                _.Display($" WHOST-APOLICE-PLANO......................... {WHOST_APOLICE_PLANO}");

                /*" -7196- DISPLAY ' WHOST-CODSUBES-PLANO........................ ' WHOST-CODSUBES-PLANO */
                _.Display($" WHOST-CODSUBES-PLANO........................ {WHOST_CODSUBES_PLANO}");

                /*" -7198- DISPLAY ' VG130-NUM-APOLICE........................... ' VG130-NUM-APOLICE */
                _.Display($" VG130-NUM-APOLICE........................... {VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}");

                /*" -7200- DISPLAY ' VG130-COD-SUBGRUPO.......................... ' VG130-COD-SUBGRUPO */
                _.Display($" VG130-COD-SUBGRUPO.......................... {VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}");

                /*" -7201- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -7202- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7204- END-IF */
            }


            /*" -7207- MOVE VG130-NUM-APOLICE TO PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA. */
            _.Move(VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE);

            /*" -7210- MOVE VG130-COD-SUBGRUPO TO PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA. */
            _.Move(VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO);

            /*" -7211- IF PROPSSVD-NUM-PRAZO-FIN EQUAL ZEROS */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN == 00)
            {

                /*" -7213- MOVE -1 TO VIND-NUM-PRAZO */
                _.Move(-1, VIND_NUM_PRAZO);

                /*" -7214- ELSE */
            }
            else
            {


                /*" -7216- MOVE +0 TO VIND-NUM-PRAZO */
                _.Move(+0, VIND_NUM_PRAZO);

                /*" -7218- END-IF. */
            }


            /*" -7219- IF GE372-COD-OPER-CREDITO EQUAL ZEROS */

            if (GE372.DCLGE_OPER_CREDITO.GE372_COD_OPER_CREDITO == 00)
            {

                /*" -7221- MOVE -1 TO VIND-OPER-CREDITO */
                _.Move(-1, VIND_OPER_CREDITO);

                /*" -7222- ELSE */
            }
            else
            {


                /*" -7224- MOVE +0 TO VIND-OPER-CREDITO */
                _.Move(+0, VIND_OPER_CREDITO);

                /*" -7226- END-IF. */
            }


            /*" -7240- PERFORM R77100_10_NEXT_DB_INSERT_1 */

            R77100_10_NEXT_DB_INSERT_1();

            /*" -7243- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -7244- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -7245- DISPLAY '          ERRO INSERT TAB. PROPOSTA SASSE VIDA' */
                _.Display($"          ERRO INSERT TAB. PROPOSTA SASSE VIDA");

                /*" -7247- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -7249- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -7251- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -7253- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -7254- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -7255- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7257- END-IF */
            }


            /*" -7257- . */

        }

        [StopWatch]
        /*" R77100-10-NEXT-DB-INSERT-1 */
        public void R77100_10_NEXT_DB_INSERT_1()
        {
            /*" -7240- EXEC SQL INSERT INTO SEGUROS.PROP_SASSE_VIDA VALUES (:DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE, :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-USUARIO, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, CURRENT TIMESTAMP, :PROPSSVD-NUM-CONTR-VINCULO:VIND-OPER-CREDITO, :PROPSSVD-COD-CORRESP-BANC :VIND-OPER-CREDITO, :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , :PROPSSVD-COD-OPER-CREDITO:VIND-OPER-CREDITO) END-EXEC. */

            var r77100_10_NEXT_DB_INSERT_1_Insert1 = new R77100_10_NEXT_DB_INSERT_1_Insert1()
            {
                PROPSSVD_NUM_IDENTIFICACAO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.ToString(),
                PROPSSVD_DPS_TITULAR = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.ToString(),
                PROPSSVD_DPS_CONJUGE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.ToString(),
                PROPSSVD_APOS_INVALIDEZ = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ.ToString(),
                PROPSSVD_COD_USUARIO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_CONTR_VINCULO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.ToString(),
                VIND_OPER_CREDITO = VIND_OPER_CREDITO.ToString(),
                PROPSSVD_COD_CORRESP_BANC = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.ToString(),
                PROPSSVD_NUM_PRAZO_FIN = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.ToString(),
                VIND_NUM_PRAZO = VIND_NUM_PRAZO.ToString(),
                PROPSSVD_COD_OPER_CREDITO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.ToString(),
            };

            R77100_10_NEXT_DB_INSERT_1_Insert1.Execute(r77100_10_NEXT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R77100_SAIDA*/

        [StopWatch]
        /*" R77200-OBTER-APOLICE-SUBES-SECTION */
        private void R77200_OBTER_APOLICE_SUBES_SECTION()
        {
            /*" -7609- MOVE 'R77200-OBTER-APOLICE-SUBES' TO PARAGRAFO */
            _.Move("R77200-OBTER-APOLICE-SUBES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7610- MOVE 'DECLER CURSOR CC_PRODUTO' TO COMANDO */
            _.Move("DECLER CURSOR CC_PRODUTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7612- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7614- PERFORM R77210-00-OBTER-APO-SUB-VG130 */

            R77210_00_OBTER_APO_SUB_VG130_SECTION();

            /*" -7616- PERFORM R77230-00-PESQ-PLANOS */

            R77230_00_PESQ_PLANOS_SECTION();

            /*" -7616- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R77200_SAIDA*/

        [StopWatch]
        /*" R77210-00-OBTER-APO-SUB-VG130-SECTION */
        private void R77210_00_OBTER_APO_SUB_VG130_SECTION()
        {
            /*" -7625- MOVE 'R77210-00-OBTER-APO-SUB-VG130' TO PARAGRAFO */
            _.Move("R77210-00-OBTER-APO-SUB-VG130", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7626- MOVE 'SELECT VG_PLANO_SUBGRUPO' TO COMANDO */
            _.Move("SELECT VG_PLANO_SUBGRUPO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7628- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7629- MOVE R3-COD-PRODUTO TO VG130-COD-PRODUTO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO_SIVPF);

            /*" -7630- MOVE R3-OPCAO-COBER TO VG130-COD-OPCAO-COBER */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_OPCAO_COBER);

            /*" -7631- MOVE R3-PERIPGTO TO VG130-IND-PERIOD-PGTO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO, VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_PERIOD_PGTO);

            /*" -7632- IF R3-OPCAO-CONJUGE NOT EQUAL 'S' */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE != "S")
            {

                /*" -7633- MOVE 'N' TO R3-OPCAO-CONJUGE */
                _.Move("N", LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE);

                /*" -7634- END-IF */
            }


            /*" -7635- MOVE R3-OPCAO-CONJUGE TO VG130-IND-OPCAO-CONJUGE */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE, VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE);

            /*" -7636- MOVE W-COD-TIPO-ASSIST TO VG130-COD-TIPO-ASSISTENCIA */
            _.Move(WREA88.W_AIC_TIPO_ASSIST.W_COD_TIPO_ASSIST, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA);

            /*" -7637- MOVE R3-DATA-PROPOSTA(1:2) TO WHOST-DATA-PROPOSTA(9:2) */
            _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(1, 2), WHOST_DATA_PROPOSTA, 9, 2);

            /*" -7638- MOVE '-' TO WHOST-DATA-PROPOSTA(8:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 8, 1);

            /*" -7639- MOVE R3-DATA-PROPOSTA(3:2) TO WHOST-DATA-PROPOSTA(6:2) */
            _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(3, 2), WHOST_DATA_PROPOSTA, 6, 2);

            /*" -7640- MOVE '-' TO WHOST-DATA-PROPOSTA(5:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 5, 1);

            /*" -7643- MOVE R3-DATA-PROPOSTA(5:4) TO WHOST-DATA-PROPOSTA(1:4) */
            _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(5, 4), WHOST_DATA_PROPOSTA, 1, 4);

            /*" -7660- PERFORM R77210_00_OBTER_APO_SUB_VG130_DB_SELECT_1 */

            R77210_00_OBTER_APO_SUB_VG130_DB_SELECT_1();

            /*" -7663- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -7664- MOVE VG130-NUM-APOLICE TO WHOST-APOLICE-PLANO */
                _.Move(VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE, WHOST_APOLICE_PLANO);

                /*" -7665- MOVE VG130-COD-SUBGRUPO TO WHOST-CODSUBES-PLANO */
                _.Move(VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO, WHOST_CODSUBES_PLANO);

                /*" -7674- DISPLAY '### /' VG130-COD-PRODUTO-SIVPF '/' VG130-COD-OPCAO-COBER '/' VG130-IND-PERIOD-PGTO '/' VG130-IND-OPCAO-CONJUGE '/' VG130-COD-TIPO-ASSISTENCIA '/' WHOST-DATA-PROPOSTA '/' VG130-NUM-APOLICE '/' VG130-COD-SUBGRUPO */

                $"### /{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO_SIVPF}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_OPCAO_COBER}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_PERIOD_PGTO}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA}/{WHOST_DATA_PROPOSTA}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}"
                .Display();

                /*" -7675- ELSE */
            }
            else
            {


                /*" -7676- DISPLAY 'VA0600B FIM ANORMAL' */
                _.Display($"VA0600B FIM ANORMAL");

                /*" -7677- DISPLAY ' ERRO SELECT VG_PLANO_SUBGRUPO' */
                _.Display($" ERRO SELECT VG_PLANO_SUBGRUPO");

                /*" -7685- DISPLAY ' PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '/' VG130-COD-PRODUTO-SIVPF '/' VG130-COD-OPCAO-COBER '/' VG130-IND-PERIOD-PGTO '/' VG130-IND-OPCAO-CONJUGE '/' VG130-COD-TIPO-ASSISTENCIA '/' WHOST-DATA-PROPOSTA */

                $" PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO_SIVPF}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_OPCAO_COBER}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_PERIOD_PGTO}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA}/{WHOST_DATA_PROPOSTA}"
                .Display();

                /*" -7686- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -7687- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7689- END-IF */
            }


            /*" -7689- . */

        }

        [StopWatch]
        /*" R77210-00-OBTER-APO-SUB-VG130-DB-SELECT-1 */
        public void R77210_00_OBTER_APO_SUB_VG130_DB_SELECT_1()
        {
            /*" -7660- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , COD_PRODUTO INTO :VG130-NUM-APOLICE , :VG130-COD-SUBGRUPO , :VG130-COD-PRODUTO FROM SEGUROS.VG_PLANO_SUBGRUPO WHERE COD_EMPRESA_SIVPF = 001 AND COD_PRODUTO_SIVPF = :VG130-COD-PRODUTO-SIVPF AND COD_OPCAO_COBER = :VG130-COD-OPCAO-COBER AND IND_PERIOD_PGTO = :VG130-IND-PERIOD-PGTO AND IND_OPCAO_CONJUGE = :VG130-IND-OPCAO-CONJUGE AND COD_TIPO_ASSISTENCIA = :VG130-COD-TIPO-ASSISTENCIA AND :WHOST-DATA-PROPOSTA BETWEEN DTA_INI_VIGENCIA AND DTA_FIM_VIGENCIA AND STA_REGISTRO = '0' END-EXEC */

            var r77210_00_OBTER_APO_SUB_VG130_DB_SELECT_1_Query1 = new R77210_00_OBTER_APO_SUB_VG130_DB_SELECT_1_Query1()
            {
                VG130_COD_TIPO_ASSISTENCIA = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA.ToString(),
                VG130_COD_PRODUTO_SIVPF = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO_SIVPF.ToString(),
                VG130_IND_OPCAO_CONJUGE = VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE.ToString(),
                VG130_COD_OPCAO_COBER = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_OPCAO_COBER.ToString(),
                VG130_IND_PERIOD_PGTO = VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_PERIOD_PGTO.ToString(),
                WHOST_DATA_PROPOSTA = WHOST_DATA_PROPOSTA.ToString(),
            };

            var executed_1 = R77210_00_OBTER_APO_SUB_VG130_DB_SELECT_1_Query1.Execute(r77210_00_OBTER_APO_SUB_VG130_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG130_NUM_APOLICE, VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE);
                _.Move(executed_1.VG130_COD_SUBGRUPO, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO);
                _.Move(executed_1.VG130_COD_PRODUTO, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R77210_99_SAIDA*/

        [StopWatch]
        /*" R77230-00-PESQ-PLANOS-SECTION */
        private void R77230_00_PESQ_PLANOS_SECTION()
        {
            /*" -7695- MOVE 'R77230-00-PESQ-PLANOS' TO PARAGRAFO. */
            _.Move("R77230-00-PESQ-PLANOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7696- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7698- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7699- MOVE R3-OPCAO-COBER TO WHOST-OPCAO-COBER */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, WHOST_OPCAO_COBER);

            /*" -7700- MOVE PROPOFID-DATA-PROPOSTA(1:4) TO WS-ANO-BASE */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Substring(1, 4), WAREA_AUXILIAR.WS_ANO_BASE);

            /*" -7701- DISPLAY 'WS-dat-prop: ' PROPOFID-DATA-PROPOSTA */
            _.Display($"WS-dat-prop: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA}");

            /*" -7702- DISPLAY 'WS-ANO-BASE: ' WS-ANO-BASE */
            _.Display($"WS-ANO-BASE: {WAREA_AUXILIAR.WS_ANO_BASE}");

            /*" -7703- DISPLAY 'WS-dat-nasc: ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
            _.Display($"WS-dat-nasc: {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

            /*" -7705- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA (1:4) TO WS-ANO-NASC */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Substring(1, 4), WAREA_AUXILIAR.WS_ANO_NASC);

            /*" -7706- DISPLAY 'WS-ANO-NASC: ' WS-ANO-NASC */
            _.Display($"WS-ANO-NASC: {WAREA_AUXILIAR.WS_ANO_NASC}");

            /*" -7707- COMPUTE WHOST-IDADE = WS-ANO-BASE - WS-ANO-NASC */
            WHOST_IDADE.Value = WAREA_AUXILIAR.WS_ANO_BASE - WAREA_AUXILIAR.WS_ANO_NASC;

            /*" -7709- IF DATA-NASCIMENTO OF DCLPESSOA-FISICA (6:5) > PROPOFID-DATA-PROPOSTA(6:5) */

            if (PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Substring(6, 5) > PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Substring(6, 5))
            {

                /*" -7710- COMPUTE WHOST-IDADE = WHOST-IDADE - 1 */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -7711- END-IF */
            }


            /*" -7712- DISPLAY 'WHOST-IDADE: ' WHOST-IDADE */
            _.Display($"WHOST-IDADE: {WHOST_IDADE}");

            /*" -7713- IF SEM-MATRIZ */

            if (WREA88.N88_MATRIZ["SEM_MATRIZ"])
            {

                /*" -7714- MOVE R3-VALOR-PREMIO-TOTAL TO WHOST-PRM-TOTAL-MA */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL, WHOST_PRM_TOTAL_MA);

                /*" -7715- ELSE */
            }
            else
            {


                /*" -7716- MOVE R24-VLR-PRM-BRUTO TO WHOST-PRM-TOTAL-MA */
                _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_VLR_PRM_BRUTO, WHOST_PRM_TOTAL_MA);

                /*" -7718- END-IF */
            }


            /*" -7719- MOVE R3-DATA-PROPOSTA(1:2) TO WHOST-DATA-PROPOSTA(9:2) */
            _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(1, 2), WHOST_DATA_PROPOSTA, 9, 2);

            /*" -7720- MOVE '-' TO WHOST-DATA-PROPOSTA(8:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 8, 1);

            /*" -7721- MOVE R3-DATA-PROPOSTA(3:2) TO WHOST-DATA-PROPOSTA(6:2) */
            _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(3, 2), WHOST_DATA_PROPOSTA, 6, 2);

            /*" -7722- MOVE '-' TO WHOST-DATA-PROPOSTA(5:1) */
            _.MoveAtPosition("-", WHOST_DATA_PROPOSTA, 5, 1);

            /*" -7724- MOVE R3-DATA-PROPOSTA(5:4) TO WHOST-DATA-PROPOSTA(1:4) */
            _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(5, 4), WHOST_DATA_PROPOSTA, 1, 4);

            /*" -7725- IF CANAL-VENDA-INTERNET */

            if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_INTERNET"])
            {

                /*" -7726- MOVE R3-DATA-PROPOSTA(1:2) TO WHOST-DATA-QUITACAO(9:2) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(1, 2), WHOST_DATA_QUITACAO, 9, 2);

                /*" -7727- MOVE '-' TO WHOST-DATA-QUITACAO(8:1) */
                _.MoveAtPosition("-", WHOST_DATA_QUITACAO, 8, 1);

                /*" -7728- MOVE R3-DATA-PROPOSTA(3:2) TO WHOST-DATA-QUITACAO(6:2) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(3, 2), WHOST_DATA_QUITACAO, 6, 2);

                /*" -7729- MOVE '-' TO WHOST-DATA-QUITACAO(5:1) */
                _.MoveAtPosition("-", WHOST_DATA_QUITACAO, 5, 1);

                /*" -7730- MOVE R3-DATA-PROPOSTA(5:4) TO WHOST-DATA-QUITACAO(1:4) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.Substring(5, 4), WHOST_DATA_QUITACAO, 1, 4);

                /*" -7731- ELSE */
            }
            else
            {


                /*" -7732- MOVE R3-DTQITBCO(1:2) TO WHOST-DATA-QUITACAO(9:2) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.Substring(1, 2), WHOST_DATA_QUITACAO, 9, 2);

                /*" -7733- MOVE '-' TO WHOST-DATA-QUITACAO(8:1) */
                _.MoveAtPosition("-", WHOST_DATA_QUITACAO, 8, 1);

                /*" -7734- MOVE R3-DTQITBCO(3:2) TO WHOST-DATA-QUITACAO(6:2) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.Substring(3, 2), WHOST_DATA_QUITACAO, 6, 2);

                /*" -7735- MOVE '-' TO WHOST-DATA-QUITACAO(5:1) */
                _.MoveAtPosition("-", WHOST_DATA_QUITACAO, 5, 1);

                /*" -7736- MOVE R3-DTQITBCO(5:4) TO WHOST-DATA-QUITACAO(1:4) */
                _.MoveAtPosition(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.Substring(5, 4), WHOST_DATA_QUITACAO, 1, 4);

                /*" -7741- END-IF */
            }


            /*" -7759- PERFORM R77230_00_PESQ_PLANOS_DB_SELECT_1 */

            R77230_00_PESQ_PLANOS_DB_SELECT_1();

            /*" -7762- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7763- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -7764- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -7766- DISPLAY 'ERRO NO ACESSO A PLANOS_VA_VGAP - R77230' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"ERRO NO ACESSO A PLANOS_VA_VGAP - R77230{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -7767- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -7768- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -7769- ELSE */
                }
                else
                {


                    /*" -7770- IF VIDA-CONFORTO */

                    if (LBWPF002.W_PRODUTO["VIDA_CONFORTO"])
                    {

                        /*" -7771- PERFORM R8240-00-PLANO-SEM-PREMIO */

                        R8240_00_PLANO_SEM_PREMIO_SECTION();

                        /*" -7772- ELSE */
                    }
                    else
                    {


                        /*" -7773- PERFORM R8230-00-PLANO-SEM-DATA */

                        R8230_00_PLANO_SEM_DATA_SECTION();

                        /*" -7774- END-IF */
                    }


                    /*" -7775- IF COM-MATRIZ */

                    if (WREA88.N88_MATRIZ["COM_MATRIZ"])
                    {

                        /*" -7776- PERFORM R77233-00-INS-GE-RETENCAO-PROP */

                        R77233_00_INS_GE_RETENCAO_PROP_SECTION();

                        /*" -7777- END-IF */
                    }


                    /*" -7778- END-IF */
                }


                /*" -7779- ELSE */
            }
            else
            {


                /*" -7780- IF COM-MATRIZ */

                if (WREA88.N88_MATRIZ["COM_MATRIZ"])
                {

                    /*" -7781- PERFORM R77233-00-INS-GE-RETENCAO-PROP */

                    R77233_00_INS_GE_RETENCAO_PROP_SECTION();

                    /*" -7782- END-IF */
                }


                /*" -7784- END-IF */
            }


            /*" -7784- . */

        }

        [StopWatch]
        /*" R77230-00-PESQ-PLANOS-DB-SELECT-1 */
        public void R77230_00_PESQ_PLANOS_DB_SELECT_1()
        {
            /*" -7759- EXEC SQL SELECT NUM_APOLICE , CODSUBES , VLPREMIOTOT INTO :WHOST-APOLICE-PLANO , :WHOST-CODSUBES-PLANO , :PLAVAVGA-VLPREMIOTOT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :VG130-NUM-APOLICE AND CODSUBES = :VG130-COD-SUBGRUPO AND OPCAO_COBER = :WHOST-OPCAO-COBER AND ((:WHOST-DATA-PROPOSTA BETWEEN DTINIVIG AND DTTERVIG) OR (:WHOST-DATA-QUITACAO BETWEEN DTINIVIG AND DTTERVIG)) AND :WHOST-IDADE BETWEEN IDADE_INICIAL AND IDADE_FINAL AND VLPREMIOTOT = :WHOST-PRM-TOTAL-MA END-EXEC */

            var r77230_00_PESQ_PLANOS_DB_SELECT_1_Query1 = new R77230_00_PESQ_PLANOS_DB_SELECT_1_Query1()
            {
                WHOST_DATA_PROPOSTA = WHOST_DATA_PROPOSTA.ToString(),
                WHOST_DATA_QUITACAO = WHOST_DATA_QUITACAO.ToString(),
                VG130_COD_SUBGRUPO = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO.ToString(),
                WHOST_PRM_TOTAL_MA = WHOST_PRM_TOTAL_MA.ToString(),
                VG130_NUM_APOLICE = VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE.ToString(),
                WHOST_OPCAO_COBER = WHOST_OPCAO_COBER.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R77230_00_PESQ_PLANOS_DB_SELECT_1_Query1.Execute(r77230_00_PESQ_PLANOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_APOLICE_PLANO, WHOST_APOLICE_PLANO);
                _.Move(executed_1.WHOST_CODSUBES_PLANO, WHOST_CODSUBES_PLANO);
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R77230_99_SAIDA*/

        [StopWatch]
        /*" R77233-00-INS-GE-RETENCAO-PROP-SECTION */
        private void R77233_00_INS_GE_RETENCAO_PROP_SECTION()
        {
            /*" -7791- MOVE 'R77233-00-INS-GE-RETENCAO-PROP   ' TO PARAGRAFO */
            _.Move("R77233-00-INS-GE-RETENCAO-PROP   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7792- MOVE 'INSERE TABELA GE_RETENCAO_PROP  ' TO COMANDO */
            _.Move("INSERE TABELA GE_RETENCAO_PROP  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7794- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7796- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO GE406-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_NUM_CERTIFICADO);

            /*" -7800- MOVE R1-CGC-CPF OF REG-CLIENTES TO GE406-NUM-CPF */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_NUM_CPF);

            /*" -7802- PERFORM R77233_00_INS_GE_RETENCAO_PROP_DB_SEQUENCE_1 */

            R77233_00_INS_GE_RETENCAO_PROP_DB_SEQUENCE_1();

            /*" -7811- MOVE 3 TO GE406-IND-SERV-CONSULTA */
            _.Move(3, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_SERV_CONSULTA);

            /*" -7812- MOVE 'D' TO GE406-IND-PROCESSAMENTO */
            _.Move("D", GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_PROCESSAMENTO);

            /*" -7814- MOVE 'VA0600B' TO GE406-COD-USUARIO */
            _.Move("VA0600B", GE406.DCLGE_RETENCAO_PROPOSTA.GE406_COD_USUARIO);

            /*" -7815- MOVE R24-PERCENTUAL-APLICADO TO GE406-PCT-AGRAVO */
            _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R2.R24_MATRIZ.R24_PERCENTUAL_APLICADO, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO);

            /*" -7821- MOVE WHOST-PRM-TOTAL-MA TO GE406-VLR-PRM-SEM-AGR */
            _.Move(WHOST_PRM_TOTAL_MA, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_VLR_PRM_SEM_AGR);

            /*" -7822-  EVALUATE TRUE  */

            /*" -7823-  WHEN    DESCONTO  */

            /*" -7823- IF    DESCONTO */

            if (WREA88.N88_TIPO_MATRIZ["DESCONTO"])
            {

                /*" -7824- MOVE '1' TO GE406-IND-RET-SUBSCRICAO */
                _.Move("1", GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO);

                /*" -7825-  WHEN    AGRAVO  */

                /*" -7825- ELSE IF    AGRAVO */
            }
            else

            if (WREA88.N88_TIPO_MATRIZ["AGRAVO"])
            {

                /*" -7826- MOVE '2' TO GE406-IND-RET-SUBSCRICAO */
                _.Move("2", GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO);

                /*" -7828-  END-EVALUATE  */

                /*" -7828- END-IF */
            }


            /*" -7859- PERFORM R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1 */

            R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1();

            /*" -7862- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -7863- ADD 1 TO W-QTD-MATRIZ */
                WAREA_AUXILIAR.W_QTD_MATRIZ.Value = WAREA_AUXILIAR.W_QTD_MATRIZ + 1;

                /*" -7864- ELSE */
            }
            else
            {


                /*" -7865- DISPLAY 'PROBLEMAS AO INSERIR NA GE_RETENCAO_PROPOSTA' */
                _.Display($"PROBLEMAS AO INSERIR NA GE_RETENCAO_PROPOSTA");

                /*" -7867- DISPLAY ' NUM_CERTIFICADO.......   ' GE406-NUM-CERTIFICADO */
                _.Display($" NUM_CERTIFICADO.......   {GE406.DCLGE_RETENCAO_PROPOSTA.GE406_NUM_CERTIFICADO}");

                /*" -7869- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -7870- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -7871- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7873- END-IF */
            }


            /*" -7873- . */

        }

        [StopWatch]
        /*" R77233-00-INS-GE-RETENCAO-PROP-DB-SEQUENCE-1 */
        public void R77233_00_INS_GE_RETENCAO_PROP_DB_SEQUENCE_1()
        {
            /*" -7802- EXEC SQL SET :GE406-COD-IDE-CONSULTA = NEXT VALUE FOR SEGUROS.GE406SQ END-EXEC */

            var r77233_00_INS_GE_RETENCAO_PROP_DB_SEQUENCE_1_Query1 = new R77233_00_INS_GE_RETENCAO_PROP_DB_SEQUENCE_1_Query1()
            {
            };

            var executed_1 = R77233_00_INS_GE_RETENCAO_PROP_DB_SEQUENCE_1_Query1.Execute(r77233_00_INS_GE_RETENCAO_PROP_DB_SEQUENCE_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE406_COD_IDE_CONSULTA, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_COD_IDE_CONSULTA);
            }


        }

        [StopWatch]
        /*" R77233-00-INS-GE-RETENCAO-PROP-DB-INSERT-1 */
        public void R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1()
        {
            /*" -7859- EXEC SQL INSERT INTO SEGUROS.GE_RETENCAO_PROPOSTA ( NUM_CERTIFICADO , NUM_CPF , COD_IDE_CONSULTA , IND_SERV_CONSULTA , IND_PROCESSAMENTO , IND_ACEITACAO , COD_USUARIO , DTH_GERACAO , DTH_PROCESSAMENTO , DTH_CONSUMO , IND_RET_SUBSCRICAO , PCT_AGRAVO , VLR_PRM_SEM_AGR ) VALUES ( :GE406-NUM-CERTIFICADO , :GE406-NUM-CPF , :GE406-COD-IDE-CONSULTA , :GE406-IND-SERV-CONSULTA , :GE406-IND-PROCESSAMENTO , NULL , :GE406-COD-USUARIO , CURRENT TIMESTAMP , NULL , NULL , :GE406-IND-RET-SUBSCRICAO , :GE406-PCT-AGRAVO , :GE406-VLR-PRM-SEM-AGR ) END-EXEC */

            var r77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1 = new R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1()
            {
                GE406_NUM_CERTIFICADO = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_NUM_CERTIFICADO.ToString(),
                GE406_NUM_CPF = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_NUM_CPF.ToString(),
                GE406_COD_IDE_CONSULTA = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_COD_IDE_CONSULTA.ToString(),
                GE406_IND_SERV_CONSULTA = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_SERV_CONSULTA.ToString(),
                GE406_IND_PROCESSAMENTO = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_PROCESSAMENTO.ToString(),
                GE406_COD_USUARIO = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_COD_USUARIO.ToString(),
                GE406_IND_RET_SUBSCRICAO = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO.ToString(),
                GE406_PCT_AGRAVO = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO.ToString(),
                GE406_VLR_PRM_SEM_AGR = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_VLR_PRM_SEM_AGR.ToString(),
            };

            R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1.Execute(r77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R77233_99_SAIDA*/

        [StopWatch]
        /*" R0773-GERA-PROP-BILHETE-SECTION */
        private void R0773_GERA_PROP_BILHETE_SECTION()
        {
            /*" -7880- MOVE 'R0773-GERA-PROP-BILHETE' TO PARAGRAFO. */
            _.Move("R0773-GERA-PROP-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7881- MOVE 'INSERT PROPOSTA-BILHETE' TO COMANDO. */
            _.Move("INSERT PROPOSTA-BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7885- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPSSBI-NUM-IDENTIFICACAO OF DCLPROP-SASSE-BILHETE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO);

            /*" -7888- MOVE R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE TO PROPSSBI-RENOVACAO-AUTOM OF DCLPROP-SASSE-BILHETE */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM, PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_RENOVACAO_AUTOM);

            /*" -7891- MOVE 'VA0600B' TO PROPSSBI-COD-USUARIO OF DCLPROP-SASSE-BILHETE. */
            _.Move("VA0600B", PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_COD_USUARIO);

            /*" -7894- MOVE R3-TIPO-RESIDENCIA OF REG-PROPOSTA-SASSE TO GETPMOIM-NUM-TP-MORA-IMOVEL */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_RESIDENCIA, GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_NUM_TP_MORA_IMOVEL);

            /*" -7899- PERFORM R0773_GERA_PROP_BILHETE_DB_SELECT_1 */

            R0773_GERA_PROP_BILHETE_DB_SELECT_1();

            /*" -7902- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -7903- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7904- MOVE ZEROS TO GETPMOIM-NUM-TP-MORA-IMOVEL */
                    _.Move(0, GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_NUM_TP_MORA_IMOVEL);

                    /*" -7905- ELSE */
                }
                else
                {


                    /*" -7906- DISPLAY 'VA0600B FIM ANORMAL' */
                    _.Display($"VA0600B FIM ANORMAL");

                    /*" -7907- DISPLAY '        ERRO SELECT PROP_SASSE_BILHETE  ' */
                    _.Display($"        ERRO SELECT PROP_SASSE_BILHETE  ");

                    /*" -7909- DISPLAY '        NUM DA PROPOSTA .... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"        NUM DA PROPOSTA .... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -7910- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -7911- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -7912- END-IF */
                }


                /*" -7914- END-IF. */
            }


            /*" -7917- MOVE GETPMOIM-NUM-TP-MORA-IMOVEL TO PROPSSBI-NUM-TP-MORA-IMOVEL OF DCLPROP-SASSE-BILHETE. */
            _.Move(GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_NUM_TP_MORA_IMOVEL, PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_TP_MORA_IMOVEL);

            /*" -7925- PERFORM R0773_GERA_PROP_BILHETE_DB_INSERT_1 */

            R0773_GERA_PROP_BILHETE_DB_INSERT_1();

            /*" -7928- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -7929- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -7930- DISPLAY '          ERRO INSERT TABELA PROPOSTA BILHETE' */
                _.Display($"          ERRO INSERT TABELA PROPOSTA BILHETE");

                /*" -7932- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -7934- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -7936- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPSSBI-NUM-IDENTIFICACAO OF DCLPROP-SASSE-BILHETE */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO}");

                /*" -7938- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -7939- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -7939- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0773-GERA-PROP-BILHETE-DB-SELECT-1 */
        public void R0773_GERA_PROP_BILHETE_DB_SELECT_1()
        {
            /*" -7899- EXEC SQL SELECT DES_TP_MORA_IMOVEL INTO :GETPMOIM-DES-TP-MORA-IMOVEL FROM SEGUROS.GE_TP_MORAD_IMOVEL WHERE NUM_TP_MORA_IMOVEL = :GETPMOIM-NUM-TP-MORA-IMOVEL END-EXEC */

            var r0773_GERA_PROP_BILHETE_DB_SELECT_1_Query1 = new R0773_GERA_PROP_BILHETE_DB_SELECT_1_Query1()
            {
                GETPMOIM_NUM_TP_MORA_IMOVEL = GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_NUM_TP_MORA_IMOVEL.ToString(),
            };

            var executed_1 = R0773_GERA_PROP_BILHETE_DB_SELECT_1_Query1.Execute(r0773_GERA_PROP_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GETPMOIM_DES_TP_MORA_IMOVEL, GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_DES_TP_MORA_IMOVEL);
            }


        }

        [StopWatch]
        /*" R0773-GERA-PROP-BILHETE-DB-INSERT-1 */
        public void R0773_GERA_PROP_BILHETE_DB_INSERT_1()
        {
            /*" -7925- EXEC SQL INSERT INTO SEGUROS.PROP_SASSE_BILHETE VALUES (:DCLPROP-SASSE-BILHETE.PROPSSBI-NUM-IDENTIFICACAO , :DCLPROP-SASSE-BILHETE.PROPSSBI-RENOVACAO-AUTOM , :DCLPROP-SASSE-BILHETE.PROPSSBI-COD-USUARIO , CURRENT TIMESTAMP , NULL , :DCLPROP-SASSE-BILHETE.PROPSSBI-NUM-TP-MORA-IMOVEL ) END-EXEC. */

            var r0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1 = new R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1()
            {
                PROPSSBI_NUM_IDENTIFICACAO = PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO.ToString(),
                PROPSSBI_RENOVACAO_AUTOM = PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_RENOVACAO_AUTOM.ToString(),
                PROPSSBI_COD_USUARIO = PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_COD_USUARIO.ToString(),
                PROPSSBI_NUM_TP_MORA_IMOVEL = PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_TP_MORA_IMOVEL.ToString(),
            };

            R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1.Execute(r0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0773_SAIDA*/

        [StopWatch]
        /*" R0791-OBTER-NUM-SICOB-SECTION */
        private void R0791_OBTER_NUM_SICOB_SECTION()
        {
            /*" -7946- MOVE 'R0791-OBTER-NUM-SICOB' TO PARAGRAFO. */
            _.Move("R0791-OBTER-NUM-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7947- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7949- MOVE SPACES TO W-ACHOU-SICOB. */
            _.Move("", WAREA_AUXILIAR.W_ACHOU_SICOB);

            /*" -7953- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB, W-NUM-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, WREA88.W_NUM_PROPOSTA);

            /*" -7955- PERFORM R0792-ACESSAR-CONVERSAO-SICOB. */

            R0792_ACESSAR_CONVERSAO_SICOB_SECTION();

            /*" -7956- IF W-ACHOU-SICOB EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_ACHOU_SICOB == "SIM")
            {

                /*" -7958- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

                /*" -7959- ELSE */
            }
            else
            {


                /*" -7960- IF SASSE */

                if (WREA88.W_COD_EMPRESA["SASSE"])
                {

                    /*" -7961- IF CANAL-VENDA-PAPEL */

                    if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                    {

                        /*" -7964- MOVE NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ, NUM-SICOB OF DCLCONVERSAO-SICOB */
                        _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);

                        /*" -7965- ELSE */
                    }
                    else
                    {


                        /*" -7966- PERFORM R0793-NUMERAR-SICOB */

                        R0793_NUMERAR_SICOB_SECTION();

                        /*" -7967- PERFORM R0794-GERA-DE-PARA-NR-SICOB */

                        R0794_GERA_DE_PARA_NR_SICOB_SECTION();

                        /*" -7969- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                        _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

                        /*" -7970- END-IF */
                    }


                    /*" -7971- ELSE */
                }
                else
                {


                    /*" -7972- IF CANAL-VENDA-PAPEL */

                    if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                    {

                        /*" -7974- MOVE NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                        _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

                        /*" -7975- ELSE */
                    }
                    else
                    {


                        /*" -7976- PERFORM R0793-NUMERAR-SICOB */

                        R0793_NUMERAR_SICOB_SECTION();

                        /*" -7977- PERFORM R0794-GERA-DE-PARA-NR-SICOB */

                        R0794_GERA_DE_PARA_NR_SICOB_SECTION();

                        /*" -7979- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                        _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

                        /*" -7980- END-IF */
                    }


                    /*" -7981- END-IF */
                }


                /*" -7983- END-IF */
            }


            /*" -7983- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0791_SAIDA*/

        [StopWatch]
        /*" R0792-ACESSAR-CONVERSAO-SICOB-SECTION */
        private void R0792_ACESSAR_CONVERSAO_SICOB_SECTION()
        {
            /*" -7990- MOVE 'R0792-ACESSAR-CONVERSAO-SICOB' TO PARAGRAFO. */
            _.Move("R0792-ACESSAR-CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7991- MOVE 'SELECT CONVERSAO-SICOB' TO COMANDO. */
            _.Move("SELECT CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8003- PERFORM R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1 */

            R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1();

            /*" -8006- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8007- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -8008- DISPLAY 'VA0600B FIM ANORMAL' */
                    _.Display($"VA0600B FIM ANORMAL");

                    /*" -8009- DISPLAY '        ERRO SELECT TAB. CONVERSAO-SICOB' */
                    _.Display($"        ERRO SELECT TAB. CONVERSAO-SICOB");

                    /*" -8011- DISPLAY '        NUM DA PROPOSTA .... ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                    _.Display($"        NUM DA PROPOSTA .... {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                    /*" -8012- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -8014- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


            /*" -8015- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -8016- MOVE 'SIM' TO W-ACHOU-SICOB */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_SICOB);

                /*" -8017- ELSE */
            }
            else
            {


                /*" -8017- MOVE 'NAO' TO W-ACHOU-SICOB. */
                _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_SICOB);
            }


        }

        [StopWatch]
        /*" R0792-ACESSAR-CONVERSAO-SICOB-DB-SELECT-1 */
        public void R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1()
        {
            /*" -8003- EXEC SQL SELECT NUM_SICOB , DATA_OPERACAO, DATA_QUITACAO, VAL_RCAP INTO :DCLCONVERSAO-SICOB.NUM-SICOB , :DCLCONVERSAO-SICOB.DATA-OPERACAO, :DCLCONVERSAO-SICOB.DATA-QUITACAO, :DCLCONVERSAO-SICOB.VAL-RCAP FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 = new R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1.Execute(r0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);
                _.Move(executed_1.DATA_OPERACAO, COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO);
                _.Move(executed_1.DATA_QUITACAO, COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO);
                _.Move(executed_1.VAL_RCAP, COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0792_SAIDA*/

        [StopWatch]
        /*" R0793-NUMERAR-SICOB-SECTION */
        private void R0793_NUMERAR_SICOB_SECTION()
        {
            /*" -8024- MOVE 'R0793-NUMERAR-SICOB' TO PARAGRAFO. */
            _.Move("R0793-NUMERAR-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8025- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8026- IF CAIXA-PREVIDENCIA */

            if (WREA88.W_COD_EMPRESA["CAIXA_PREVIDENCIA"])
            {

                /*" -8027- MOVE 92 TO CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Move(92, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

                /*" -8028- ELSE */
            }
            else
            {


                /*" -8029- IF CAIXA-CAPITALIZACAO */

                if (WREA88.W_COD_EMPRESA["CAIXA_CAPITALIZACAO"])
                {

                    /*" -8030- MOVE 34 TO CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                    _.Move(34, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

                    /*" -8031- ELSE */
                }
                else
                {


                    /*" -8032- IF SASSE */

                    if (WREA88.W_COD_EMPRESA["SASSE"])
                    {

                        /*" -8033- MOVE 26 TO CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                        _.Move(26, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

                        /*" -8034- ELSE */
                    }
                    else
                    {


                        /*" -8035- DISPLAY 'VA0600B FIM ANORMAL' */
                        _.Display($"VA0600B FIM ANORMAL");

                        /*" -8037- DISPLAY '        EMPRESA NAO DEFINIDA' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                        _.Display($"        EMPRESA NAO DEFINIDA{COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                        /*" -8038- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -8040- GO TO R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -8047- PERFORM R0793_NUMERAR_SICOB_DB_SELECT_1 */

            R0793_NUMERAR_SICOB_DB_SELECT_1();

            /*" -8050- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8051- DISPLAY 'VA0600B FIM ANORMAL' */
                _.Display($"VA0600B FIM ANORMAL");

                /*" -8052- DISPLAY '        ERRO SELECT TAB. CEDENTE' */
                _.Display($"        ERRO SELECT TAB. CEDENTE");

                /*" -8054- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -8055- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8059- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -8061- MOVE CEDENTE-NUM-TITULO OF DCLCEDENTE TO W-NUMR-TITULO. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WAREA_AUXILIAR.W_NUMR_TITULO);

            /*" -8063- ADD 1 TO WTITL-SEQUENCIA. */
            WAREA_AUXILIAR.FILLER_13.WTITL_SEQUENCIA.Value = WAREA_AUXILIAR.FILLER_13.WTITL_SEQUENCIA + 1;

            /*" -8065- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(WAREA_AUXILIAR.FILLER_13.WTITL_SEQUENCIA, WAREA_AUXILIAR.DPARM01X.DPARM01);

            /*" -8067- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", WAREA_AUXILIAR.DPARM01X);

            /*" -8068- IF DPARM01-RC NOT EQUAL +0 */

            if (WAREA_AUXILIAR.DPARM01X.DPARM01_RC != +0)
            {

                /*" -8069- DISPLAY 'VA0600B FIM ANORMAL' */
                _.Display($"VA0600B FIM ANORMAL");

                /*" -8071- DISPLAY '        ERRO CHAMADA PROTIT01  ' DPARM01-RC */
                _.Display($"        ERRO CHAMADA PROTIT01  {WAREA_AUXILIAR.DPARM01X.DPARM01_RC}");

                /*" -8073- DISPLAY '        CODIGO CEDENTE........ ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE........ {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -8074- DISPLAY '        AREA DE PARM.......... ' DPARM01X */
                _.Display($"        AREA DE PARM.......... {WAREA_AUXILIAR.DPARM01X}");

                /*" -8075- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8077- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -8079- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(WAREA_AUXILIAR.DPARM01X.DPARM01_D1, WAREA_AUXILIAR.FILLER_13.WTITL_DIGITO);

            /*" -8081- MOVE W-NUMR-TITULO TO CEDENTE-NUM-TITULO OF DCLCEDENTE. */
            _.Move(WAREA_AUXILIAR.W_NUMR_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

            /*" -8083- IF CEDENTE-NUM-TITULO OF DCLCEDENTE NOT LESS CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */

            if (CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO >= CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX)
            {

                /*" -8084- DISPLAY 'VA0600B FIM ANORMAL' */
                _.Display($"VA0600B FIM ANORMAL");

                /*" -8085- DISPLAY '        NUM. SICOB CALCULADO EXCEDE SICOB MAXIMO' */
                _.Display($"        NUM. SICOB CALCULADO EXCEDE SICOB MAXIMO");

                /*" -8087- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -8089- DISPLAY '        SICOB CALCULADO..... ' CEDENTE-NUM-TITULO OF DCLCEDENTE */
                _.Display($"        SICOB CALCULADO..... {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO}");

                /*" -8091- DISPLAY '        SICOB MAXIMO........ ' CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */
                _.Display($"        SICOB MAXIMO........ {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX}");

                /*" -8092- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8096- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -8097- IF CEDENTE-NUM-TITULO LESS 95322401400 */

            if (CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO < 95322401400)
            {

                /*" -8098- DISPLAY 'VA0600B FIM ANORMAL' */
                _.Display($"VA0600B FIM ANORMAL");

                /*" -8100- DISPLAY '        NUM. SICOB CALCULADO INFERIOR NRTIT' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        NUM. SICOB CALCULADO INFERIOR NRTIT{CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -8102- DISPLAY '        SICOB CALCULADO..... ' CEDENTE-NUM-TITULO OF DCLCEDENTE */
                _.Display($"        SICOB CALCULADO..... {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO}");

                /*" -8104- DISPLAY '        SICOB MAXIMO........ ' CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */
                _.Display($"        SICOB MAXIMO........ {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX}");

                /*" -8105- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8107- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -8111- PERFORM R0793_NUMERAR_SICOB_DB_UPDATE_1 */

            R0793_NUMERAR_SICOB_DB_UPDATE_1();

            /*" -8114- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8115- DISPLAY 'VA0600B FIM ANORMAL' */
                _.Display($"VA0600B FIM ANORMAL");

                /*" -8116- DISPLAY '        ERRO UPDATE TAB. CEDENTE' */
                _.Display($"        ERRO UPDATE TAB. CEDENTE");

                /*" -8118- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -8119- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8119- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0793-NUMERAR-SICOB-DB-SELECT-1 */
        public void R0793_NUMERAR_SICOB_DB_SELECT_1()
        {
            /*" -8047- EXEC SQL SELECT NUM_TITULO, NUM_TITULO_MAX INTO :DCLCEDENTE.CEDENTE-NUM-TITULO, :DCLCEDENTE.CEDENTE-NUM-TITULO-MAX FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = :DCLCEDENTE.CEDENTE-COD-CEDENTE END-EXEC. */

            var r0793_NUMERAR_SICOB_DB_SELECT_1_Query1 = new R0793_NUMERAR_SICOB_DB_SELECT_1_Query1()
            {
                CEDENTE_COD_CEDENTE = CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE.ToString(),
            };

            var executed_1 = R0793_NUMERAR_SICOB_DB_SELECT_1_Query1.Execute(r0793_NUMERAR_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
                _.Move(executed_1.CEDENTE_NUM_TITULO_MAX, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX);
            }


        }

        [StopWatch]
        /*" R0793-NUMERAR-SICOB-DB-UPDATE-1 */
        public void R0793_NUMERAR_SICOB_DB_UPDATE_1()
        {
            /*" -8111- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :DCLCEDENTE.CEDENTE-NUM-TITULO WHERE COD_CEDENTE = :DCLCEDENTE.CEDENTE-COD-CEDENTE END-EXEC. */

            var r0793_NUMERAR_SICOB_DB_UPDATE_1_Update1 = new R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
                CEDENTE_COD_CEDENTE = CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE.ToString(),
            };

            R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1.Execute(r0793_NUMERAR_SICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0793_SAIDA*/

        [StopWatch]
        /*" R0794-GERA-DE-PARA-NR-SICOB-SECTION */
        private void R0794_GERA_DE_PARA_NR_SICOB_SECTION()
        {
            /*" -8126- MOVE 'R0794-GERA-DE-PARA-NR-SICOB' TO PARAGRAFO. */
            _.Move("R0794-GERA-DE-PARA-NR-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8127- MOVE 'INSERT CONVERSAO-SICOB' TO COMANDO. */
            _.Move("INSERT CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8130- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -8133- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRODUTO-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, COVSICOB.DCLCONVERSAO_SICOB.PRODUTO_SIVPF);

            /*" -8134- IF R3-DATA-PROPOSTA NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA.IsNumeric())
            {

                /*" -8135- MOVE 01010001 TO R3-DATA-PROPOSTA */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

                /*" -8137- END-IF. */
            }


            /*" -8138- IF R3-DTQITBCO NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.IsNumeric())
            {

                /*" -8139- MOVE 01010001 TO R3-DTQITBCO */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                /*" -8141- END-IF. */
            }


            /*" -8142- IF CANAL-VENDA-GITEL */

            if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
            {

                /*" -8144- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-DATA-DDMMAAAA */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

                /*" -8145- ELSE */
            }
            else
            {


                /*" -8147- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-DDMMAAAA */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

                /*" -8149- END-IF. */
            }


            /*" -8151- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -8153- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -8156- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -8160- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -8163- MOVE W-DATA-SQL TO DATA-QUITACAO OF DCLCONVERSAO-SICOB */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO);

            /*" -8166- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO);

            /*" -8169- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-RCAP OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP);

            /*" -8172- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO COD-EMPRESA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, COVSICOB.DCLCONVERSAO_SICOB.COD_EMPRESA_SIVPF);

            /*" -8175- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO DATA-OPERACAO OF DCLCONVERSAO-SICOB */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO);

            /*" -8178- MOVE 'VA0600B' TO COD-USUARIO OF DCLCONVERSAO-SICOB. */
            _.Move("VA0600B", COVSICOB.DCLCONVERSAO_SICOB.COD_USUARIO);

            /*" -8181- MOVE CEDENTE-NUM-TITULO OF DCLCEDENTE TO NUM-SICOB OF DCLCONVERSAO-SICOB. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);

            /*" -8193- PERFORM R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1 */

            R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1();

            /*" -8196- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8197- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -8198- PERFORM R0795-00-TRATA-DUPLICI-SICOB */

                    R0795_00_TRATA_DUPLICI_SICOB_SECTION();

                    /*" -8199- ELSE */
                }
                else
                {


                    /*" -8200- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -8201- DISPLAY '          ERRO INSERT DA TAB. CONVERSAO-SICOB' */
                    _.Display($"          ERRO INSERT DA TAB. CONVERSAO-SICOB");

                    /*" -8203- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                    _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                    /*" -8205- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                    _.Display($"          NUMERO PROPOSTA...............  {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                    /*" -8207- DISPLAY '          NUMERO SICOB..................  ' NUM-SICOB OF DCLCONVERSAO-SICOB */
                    _.Display($"          NUMERO SICOB..................  {COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB}");

                    /*" -8209- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -8210- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -8210- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0794-GERA-DE-PARA-NR-SICOB-DB-INSERT-1 */
        public void R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1()
        {
            /*" -8193- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES (:DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF, :DCLCONVERSAO-SICOB.NUM-SICOB, :DCLCONVERSAO-SICOB.COD-EMPRESA-SIVPF, :DCLCONVERSAO-SICOB.PRODUTO-SIVPF, :DCLCONVERSAO-SICOB.AGEPGTO, :DCLCONVERSAO-SICOB.DATA-OPERACAO, :DCLCONVERSAO-SICOB.DATA-QUITACAO, :DCLCONVERSAO-SICOB.VAL-RCAP, :DCLCONVERSAO-SICOB.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1 = new R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1()
            {
                NUM_PROPOSTA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF.ToString(),
                NUM_SICOB = COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB.ToString(),
                COD_EMPRESA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.COD_EMPRESA_SIVPF.ToString(),
                PRODUTO_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.PRODUTO_SIVPF.ToString(),
                AGEPGTO = COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO.ToString(),
                DATA_OPERACAO = COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO.ToString(),
                DATA_QUITACAO = COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO.ToString(),
                VAL_RCAP = COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP.ToString(),
                COD_USUARIO = COVSICOB.DCLCONVERSAO_SICOB.COD_USUARIO.ToString(),
            };

            R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1.Execute(r0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0794_SAIDA*/

        [StopWatch]
        /*" R0795-00-TRATA-DUPLICI-SICOB-SECTION */
        private void R0795_00_TRATA_DUPLICI_SICOB_SECTION()
        {
            /*" -8218- MOVE 'R0795-00-TRATA-DUPLICI-SICOB' TO PARAGRAFO. */
            _.Move("R0795-00-TRATA-DUPLICI-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8219- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8220- PERFORM R0793-NUMERAR-SICOB */

            R0793_NUMERAR_SICOB_SECTION();

            /*" -8221- PERFORM R0794-GERA-DE-PARA-NR-SICOB. */

            R0794_GERA_DE_PARA_NR_SICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0795_99_SAIDA*/

        [StopWatch]
        /*" R0800-TRATA-BENEFICIARIOS-SECTION */
        private void R0800_TRATA_BENEFICIARIOS_SECTION()
        {
            /*" -8229- MOVE 'R0800-TRATA-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0800-TRATA-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8230- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8232- PERFORM R0805-OBTER-MAX-BENEFICIARIO. */

            R0805_OBTER_MAX_BENEFICIARIO_SECTION();

            /*" -8238- MOVE ZEROS TO COD-AGENCIA-LOTE OF DCLBENEF-PROP-AZUL, DATA-LOTE OF DCLBENEF-PROP-AZUL, NUM-LOTE OF DCLBENEF-PROP-AZUL, NUM-SEQ-LOTE OF DCLBENEF-PROP-AZUL. */
            _.Move(0, BENPROPZ.DCLBENEF_PROP_AZUL.COD_AGENCIA_LOTE, BENPROPZ.DCLBENEF_PROP_AZUL.DATA_LOTE, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_LOTE, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_SEQ_LOTE);

            /*" -8241- MOVE NUM-BENEFICIARIO OF DCLBENEF-PROP-AZUL TO W-NUM-BENEF. */
            _.Move(BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO, WAREA_AUXILIAR.W_NUM_BENEF);

            /*" -8243- PERFORM R0810-TRATA-BENEFICIARIO VARYING W-IND-BENEF FROM 1 BY 1 UNTIL W-IND-BENEF GREATER W-IND-BENEF-N. */

            for (WAREA_AUXILIAR.W_IND_BENEF.Value = 1; !(WAREA_AUXILIAR.W_IND_BENEF > WAREA_AUXILIAR.W_IND_BENEF_N); WAREA_AUXILIAR.W_IND_BENEF.Value += 1)
            {

                R0810_TRATA_BENEFICIARIO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0805-OBTER-MAX-BENEFICIARIO-SECTION */
        private void R0805_OBTER_MAX_BENEFICIARIO_SECTION()
        {
            /*" -8251- MOVE 'R0805-OBTER-MAX-BENEFICIARIO' TO PARAGRAFO. */
            _.Move("R0805-OBTER-MAX-BENEFICIARIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8252- MOVE 'MAX BENEF-PROP-AZUL' TO COMANDO. */
            _.Move("MAX BENEF-PROP-AZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8255- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO NUM-PROPOSTA-AZUL OF DCLBENEF-PROP-AZUL. */
            _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL);

            /*" -8261- PERFORM R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1 */

            R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1();

            /*" -8264- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8265- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -8266- DISPLAY '          ERRO SELECT MAX TAB. BENEF-PROP-AZUL' */
                _.Display($"          ERRO SELECT MAX TAB. BENEF-PROP-AZUL");

                /*" -8268- DISPLAY '          NUMERO DA PROPOSTA............  ' NUM-PROPOSTA-AZUL OF DCLBENEF-PROP-AZUL */
                _.Display($"          NUMERO DA PROPOSTA............  {BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL}");

                /*" -8270- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -8271- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8271- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0805-OBTER-MAX-BENEFICIARIO-DB-SELECT-1 */
        public void R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1()
        {
            /*" -8261- EXEC SQL SELECT VALUE(MAX(NUM_BENEFICIARIO),0) INTO :DCLBENEF-PROP-AZUL.NUM-BENEFICIARIO FROM SEGUROS.BENEF_PROP_AZUL WHERE NUM_PROPOSTA_AZUL = :DCLBENEF-PROP-AZUL.NUM-PROPOSTA-AZUL END-EXEC. */

            var r0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1 = new R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_AZUL = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL.ToString(),
            };

            var executed_1 = R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1.Execute(r0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_BENEFICIARIO, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0805_SAIDA*/

        [StopWatch]
        /*" R0810-TRATA-BENEFICIARIO-SECTION */
        private void R0810_TRATA_BENEFICIARIO_SECTION()
        {
            /*" -8278- MOVE 'R0810-TRATA-BENEFICIARIO' TO PARAGRAFO. */
            _.Move("R0810-TRATA-BENEFICIARIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8279- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8282- COMPUTE W-NUM-BENEF = W-NUM-BENEF + 1. */
            WAREA_AUXILIAR.W_NUM_BENEF.Value = WAREA_AUXILIAR.W_NUM_BENEF + 1;

            /*" -8285- MOVE W-NUM-BENEF TO NUM-BENEFICIARIO OF DCLBENEF-PROP-AZUL. */
            _.Move(WAREA_AUXILIAR.W_NUM_BENEF, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO);

            /*" -8287- MOVE W-TB-REG-BENEFI(W-IND-BENEF) TO REG-BENEFIC. */
            _.Move(WAREA_AUXILIAR.W_TAB_BENEFICIARIOS.W_TAB_BENEF_REG[WAREA_AUXILIAR.W_IND_BENEF].W_TB_REG_BENEFI, LBFPF014.REG_BENEFIC);

            /*" -8290- MOVE R4-NOME OF REG-BENEFIC TO NOME-BENEFICIARIO OF DCLBENEF-PROP-AZUL. */
            _.Move(LBFPF014.REG_BENEFIC.R4_NOME, BENPROPZ.DCLBENEF_PROP_AZUL.NOME_BENEFICIARIO);

            /*" -8291- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 1 */

            if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 1)
            {

                /*" -8293- MOVE 'CONJUGE' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                _.Move("CONJUGE", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                /*" -8294- ELSE */
            }
            else
            {


                /*" -8295- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 2 */

                if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 2)
                {

                    /*" -8297- MOVE 'COMPANHEIRO(A)' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                    _.Move("COMPANHEIRO(A)", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                    /*" -8298- ELSE */
                }
                else
                {


                    /*" -8299- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 3 */

                    if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 3)
                    {

                        /*" -8301- MOVE 'FILHOS' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                        _.Move("FILHOS", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                        /*" -8302- ELSE */
                    }
                    else
                    {


                        /*" -8303- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 4 */

                        if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 4)
                        {

                            /*" -8305- MOVE 'PAIS' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                            _.Move("PAIS", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                            /*" -8306- ELSE */
                        }
                        else
                        {


                            /*" -8307- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 5 */

                            if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 5)
                            {

                                /*" -8309- MOVE 'IRMAOS' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                                _.Move("IRMAOS", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                                /*" -8310- ELSE */
                            }
                            else
                            {


                                /*" -8311- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 6 */

                                if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 6)
                                {

                                    /*" -8312- IF R4-DESCR-PARENTESCO OF REG-BENEFIC = ' ' */

                                    if (LBFPF014.REG_BENEFIC.R4_DESCR_PARENTESCO == " ")
                                    {

                                        /*" -8314- MOVE 'OUTROS' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                                        _.Move("OUTROS", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                                        /*" -8315- ELSE */
                                    }
                                    else
                                    {


                                        /*" -8317- MOVE R4-DESCR-PARENTESCO OF REG-BENEFIC TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                                        _.Move(LBFPF014.REG_BENEFIC.R4_DESCR_PARENTESCO, BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                                        /*" -8318- END-IF */
                                    }


                                    /*" -8319- ELSE */
                                }
                                else
                                {


                                    /*" -8320- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 7 */

                                    if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 7)
                                    {

                                        /*" -8322- MOVE 'HERDEIROS LEGAIS' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                                        _.Move("HERDEIROS LEGAIS", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                                        /*" -8323- ELSE */
                                    }
                                    else
                                    {


                                        /*" -8325- MOVE 'ERROPF' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                                        _.Move("ERROPF", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                                        /*" -8326- END-IF */
                                    }


                                    /*" -8327- END-IF */
                                }


                                /*" -8328- END-IF */
                            }


                            /*" -8329- END-IF */
                        }


                        /*" -8330- END-IF */
                    }


                    /*" -8331- END-IF */
                }


                /*" -8333- END-IF. */
            }


            /*" -8336- MOVE R4-PCT-PARTICIP OF REG-BENEFIC TO PCT-PART-BENEFICIA OF DCLBENEF-PROP-AZUL. */
            _.Move(LBFPF014.REG_BENEFIC.R4_PCT_PARTICIP, BENPROPZ.DCLBENEF_PROP_AZUL.PCT_PART_BENEFICIA);

            /*" -8337- IF R4-DATA-NASCIMENTO OF REG-BENEFIC EQUAL ZEROS */

            if (LBFPF014.REG_BENEFIC.R4_DATA_NASCIMENTO == 00)
            {

                /*" -8338- MOVE -1 TO VIND-DT-NASCI */
                _.Move(-1, VIND_DT_NASCI);

                /*" -8339- ELSE */
            }
            else
            {


                /*" -8342- MOVE R4-DATA-NASCIMENTO OF REG-BENEFIC TO W-DATA-DDMMAAAA */
                _.Move(LBFPF014.REG_BENEFIC.R4_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

                /*" -8344- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -8346- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -8349- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -8353- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -8355- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLBENEF-PROP-AZUL */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, BENPROPZ.DCLBENEF_PROP_AZUL.DATA_NASCIMENTO);

                /*" -8357- MOVE ZEROS TO VIND-DT-NASCI. */
                _.Move(0, VIND_DT_NASCI);
            }


            /*" -8369- PERFORM R0810_TRATA_BENEFICIARIO_DB_INSERT_1 */

            R0810_TRATA_BENEFICIARIO_DB_INSERT_1();

            /*" -8372- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8373- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -8374- DISPLAY '          ERRO INSERT TABELA BENEF-PROP-AZUL' */
                _.Display($"          ERRO INSERT TABELA BENEF-PROP-AZUL");

                /*" -8376- DISPLAY '          NUMERO PROPOSTA...............  ' R4-NUM-PROPOSTA OF REG-BENEFIC */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF014.REG_BENEFIC.R4_NUM_PROPOSTA}");

                /*" -8378- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -8379- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8379- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0810-TRATA-BENEFICIARIO-DB-INSERT-1 */
        public void R0810_TRATA_BENEFICIARIO_DB_INSERT_1()
        {
            /*" -8369- EXEC SQL INSERT INTO SEGUROS.BENEF_PROP_AZUL VALUES (:DCLBENEF-PROP-AZUL.NUM-PROPOSTA-AZUL, :DCLBENEF-PROP-AZUL.COD-AGENCIA-LOTE, :DCLBENEF-PROP-AZUL.DATA-LOTE, :DCLBENEF-PROP-AZUL.NUM-LOTE, :DCLBENEF-PROP-AZUL.NUM-SEQ-LOTE, :DCLBENEF-PROP-AZUL.NUM-BENEFICIARIO, :DCLBENEF-PROP-AZUL.NOME-BENEFICIARIO, :DCLBENEF-PROP-AZUL.GRAU-PARENTESCO, :DCLBENEF-PROP-AZUL.PCT-PART-BENEFICIA, :DCLBENEF-PROP-AZUL.DATA-NASCIMENTO:VIND-DT-NASCI) END-EXEC. */

            var r0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1 = new R0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1()
            {
                NUM_PROPOSTA_AZUL = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL.ToString(),
                COD_AGENCIA_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.COD_AGENCIA_LOTE.ToString(),
                DATA_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.DATA_LOTE.ToString(),
                NUM_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_LOTE.ToString(),
                NUM_SEQ_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_SEQ_LOTE.ToString(),
                NUM_BENEFICIARIO = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO.ToString(),
                NOME_BENEFICIARIO = BENPROPZ.DCLBENEF_PROP_AZUL.NOME_BENEFICIARIO.ToString(),
                GRAU_PARENTESCO = BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO.ToString(),
                PCT_PART_BENEFICIA = BENPROPZ.DCLBENEF_PROP_AZUL.PCT_PART_BENEFICIA.ToString(),
                DATA_NASCIMENTO = BENPROPZ.DCLBENEF_PROP_AZUL.DATA_NASCIMENTO.ToString(),
                VIND_DT_NASCI = VIND_DT_NASCI.ToString(),
            };

            R0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1.Execute(r0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0810_SAIDA*/

        [StopWatch]
        /*" R0850-TRATA-TIPO-B-SECTION */
        private void R0850_TRATA_TIPO_B_SECTION()
        {
            /*" -8398- MOVE 'R0850-TRATA-TIPO-B            ' TO PARAGRAFO. */
            _.Move("R0850-TRATA-TIPO-B            ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8399- IF R24-NUM-TEL-FAX NOT NUMERIC */

            if (!LXFPF024.REG_TIPO_B.R24_INFO_R.R24_NUM_TEL_FAX.IsNumeric())
            {

                /*" -8400- MOVE ZEROS TO R24-NUM-TEL-FAX */
                _.Move(0, LXFPF024.REG_TIPO_B.R24_INFO_R.R24_NUM_TEL_FAX);

                /*" -8402- END-IF */
            }


            /*" -8403- IF R24-NUM-TEL-FAX GREATER ZEROS */

            if (LXFPF024.REG_TIPO_B.R24_INFO_R.R24_NUM_TEL_FAX > 00)
            {

                /*" -8404- PERFORM R0865-INCLUIR-FAX */

                R0865_INCLUIR_FAX_SECTION();

                /*" -8406- END-IF */
            }


            /*" -8406- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0865-INCLUIR-FAX-SECTION */
        private void R0865_INCLUIR_FAX_SECTION()
        {
            /*" -8414- MOVE 'R0865-INCLUI-FAX     ' TO PARAGRAFO. */
            _.Move("R0865-INCLUI-FAX     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8415- MOVE 'MAX SEGUROS.PESSOA_TELEFONE' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8420- PERFORM R0865_INCLUIR_FAX_DB_SELECT_1 */

            R0865_INCLUIR_FAX_DB_SELECT_1();

            /*" -8423- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8424- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -8425- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-TELEFONE' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-TELEFONE");

                /*" -8427- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -8429- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -8431- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -8432- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8434- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -8437- MOVE SEQ-FONE OF DCLPESSOA-TELEFONE TO W-SEQ-FONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE, WAREA_AUXILIAR.W_SEQ_FONE);

            /*" -8439- COMPUTE W-SEQ-FONE = W-SEQ-FONE + 1. */
            WAREA_AUXILIAR.W_SEQ_FONE.Value = WAREA_AUXILIAR.W_SEQ_FONE + 1;

            /*" -8443- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -8446- MOVE 4 TO TIPO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(4, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -8449- MOVE W-SEQ-FONE TO SEQ-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);

            /*" -8452- MOVE 55 TO DDI OF DCLPESSOA-TELEFONE. */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -8453- IF R24-DDD-TEL-FAX NOT NUMERIC */

            if (!LXFPF024.REG_TIPO_B.R24_INFO_R.R24_DDD_TEL_FAX.IsNumeric())
            {

                /*" -8455- MOVE ZEROS TO R24-DDD-TEL-FAX. */
                _.Move(0, LXFPF024.REG_TIPO_B.R24_INFO_R.R24_DDD_TEL_FAX);
            }


            /*" -8458- MOVE R24-DDD-TEL-FAX TO DDD OF DCLPESSOA-TELEFONE */
            _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R.R24_DDD_TEL_FAX, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -8461- MOVE R24-NUM-TEL-FAX TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LXFPF024.REG_TIPO_B.R24_INFO_R.R24_NUM_TEL_FAX, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -8464- MOVE 'A' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -8467- MOVE 'VA0600B' TO COD-USUARIO OF DCLPESSOA-TELEFONE. */
            _.Move("VA0600B", PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -8469- MOVE 'INSERT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("INSERT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8480- PERFORM R0865_INCLUIR_FAX_DB_INSERT_1 */

            R0865_INCLUIR_FAX_DB_INSERT_1();

            /*" -8483- IF SQLCODE NOT EQUAL 00 AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -8484- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -8485- DISPLAY '          ERRO INSERT TABELA PESSOA-TELEFONE' */
                _.Display($"          ERRO INSERT TABELA PESSOA-TELEFONE");

                /*" -8487- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -8489- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -8491- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -8492- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8492- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0865-INCLUIR-FAX-DB-SELECT-1 */
        public void R0865_INCLUIR_FAX_DB_SELECT_1()
        {
            /*" -8420- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :DCLPESSOA-TELEFONE.SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA END-EXEC. */

            var r0865_INCLUIR_FAX_DB_SELECT_1_Query1 = new R0865_INCLUIR_FAX_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
            };

            var executed_1 = R0865_INCLUIR_FAX_DB_SELECT_1_Query1.Execute(r0865_INCLUIR_FAX_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);
            }


        }

        [StopWatch]
        /*" R0865-INCLUIR-FAX-DB-INSERT-1 */
        public void R0865_INCLUIR_FAX_DB_INSERT_1()
        {
            /*" -8480- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA-TELEFONE.COD-PESSOA, :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.SEQ-FONE, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0865_INCLUIR_FAX_DB_INSERT_1_Insert1 = new R0865_INCLUIR_FAX_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                SEQ_FONE = PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE.ToString(),
                DDI = PESFONE.DCLPESSOA_TELEFONE.DDI.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                SITUACAO_FONE = PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE.ToString(),
                COD_USUARIO = PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO.ToString(),
            };

            R0865_INCLUIR_FAX_DB_INSERT_1_Insert1.Execute(r0865_INCLUIR_FAX_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0865_SAIDA*/

        [StopWatch]
        /*" R0900-TRATA-INF-COMPLEMENTARES-SECTION */
        private void R0900_TRATA_INF_COMPLEMENTARES_SECTION()
        {
            /*" -8499- MOVE 'R0900-TRATA-INF-COMPLEMENTARES' TO PARAGRAFO. */
            _.Move("R0900-TRATA-INF-COMPLEMENTARES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8500- MOVE 'INSERT SEGUROS.PROP_FIDELIZ_COMP' TO COMANDO. */
            _.Move("INSERT SEGUROS.PROP_FIDELIZ_COMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8502- MOVE W-TB-REG-INFORMACOES(W-IND-INFO1) TO REG-INFORMACOES */
            _.Move(WAREA_AUXILIAR.W_TAB_INFORMACOES.W_TAB_INFO_REG[WAREA_AUXILIAR.W_IND_INFO1].W_TB_REG_INFORMACOES, LBFPF015.REG_INFORMACOES);

            /*" -8505- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROFIDCO-NUM-IDENTIFICACAO OF DCLPROP-FIDELIZ-COMP */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO);

            /*" -8508- MOVE R5-INFO-COMPLEMEN OF REG-INFORMACOES TO PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP */
            _.Move(LBFPF015.REG_INFORMACOES.R5_INFO_COMPLEMEN, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);

            /*" -8511- MOVE '1' TO PROFIDCO-IND-TP-INFORMACAO OF DCLPROP-FIDELIZ-COMP */
            _.Move("1", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

            /*" -8514- MOVE 'VA0600B' TO PROFIDCO-COD-USUARIO OF DCLPROP-FIDELIZ-COMP */
            _.Move("VA0600B", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO);

            /*" -8521- PERFORM R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1 */

            R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1();

            /*" -8524- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8525- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -8526- DISPLAY 'VA0600B - INFORMACAO COMPL. JA EXISTE' */
                    _.Display($"VA0600B - INFORMACAO COMPL. JA EXISTE");

                    /*" -8528- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -8530- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -8532- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8533- ELSE */
                }
                else
                {


                    /*" -8534- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -8535- DISPLAY '          ERRO INSERT TABELA PROPOSTA_COMPL' */
                    _.Display($"          ERRO INSERT TABELA PROPOSTA_COMPL");

                    /*" -8537- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -8539- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -8541- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8543- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -8544- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -8545- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -8546- END-IF */
                }


                /*" -8548- END-IF */
            }


            /*" -8548- . */

        }

        [StopWatch]
        /*" R0900-TRATA-INF-COMPLEMENTARES-DB-INSERT-1 */
        public void R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1()
        {
            /*" -8521- EXEC SQL INSERT INTO SEGUROS.PROP_FIDELIZ_COMP VALUES (:DCLPROP-FIDELIZ-COMP.PROFIDCO-NUM-IDENTIFICACAO, :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL, :DCLPROP-FIDELIZ-COMP.PROFIDCO-COD-USUARIO, CURRENT TIMESTAMP, :DCLPROP-FIDELIZ-COMP.PROFIDCO-IND-TP-INFORMACAO) END-EXEC */

            var r0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1 = new R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1()
            {
                PROFIDCO_NUM_IDENTIFICACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO.ToString(),
                PROFIDCO_INFORMACAO_COMPL = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL.ToString(),
                PROFIDCO_COD_USUARIO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO.ToString(),
                PROFIDCO_IND_TP_INFORMACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO.ToString(),
            };

            R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1.Execute(r0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R0910-TRATA-INF-SICAQWEB-SECTION */
        private void R0910_TRATA_INF_SICAQWEB_SECTION()
        {
            /*" -8558- MOVE 'R0910-TRATA-INF-SICAQWEB' TO PARAGRAFO. */
            _.Move("R0910-TRATA-INF-SICAQWEB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8559- MOVE 'INSERT SEGUROS.PROP_FIDELIZ_COMP' TO COMANDO. */
            _.Move("INSERT SEGUROS.PROP_FIDELIZ_COMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8560- MOVE SPACES TO WSRC-INF-SICAQWEB */
            _.Move("", WSRC_INF_SICAQWEB);

            /*" -8561- MOVE REGC-COD-OPERADOR TO WSRC-NUM-OPERADOR */
            _.Move(LBFPF026.REG_TIPO_C.REGC_COD_OPERADOR, WSRC_INF_SICAQWEB.WSRC_NUM_OPERADOR);

            /*" -8562- MOVE REGC-NUM-CORRESPONDENTE TO WSRC-NUM-CORRESPONDENTE */
            _.Move(LBFPF026.REG_TIPO_C.REGC_NUM_CORRESPONDENTE, WSRC_INF_SICAQWEB.WSRC_NUM_CORRESPONDENTE);

            /*" -8563- MOVE REGC-DATA-CONTRATACAO TO WSRC-DATA-CONTRATACAO */
            _.Move(LBFPF026.REG_TIPO_C.REGC_DATA_CONTRATACAO, WSRC_INF_SICAQWEB.WSRC_DATA_CONTRATACAO);

            /*" -8564- MOVE REGC-HORA-CONTRATACAO TO WSRC-HORA-CONTRATACAO */
            _.Move(LBFPF026.REG_TIPO_C.REGC_HORA_CONTRATACAO, WSRC_INF_SICAQWEB.WSRC_HORA_CONTRATACAO);

            /*" -8565- MOVE REGC-NRO-PROPOSTA-SICAQ TO WSRC-NRO-PROPOSTA-SICAQ */
            _.Move(LBFPF026.REG_TIPO_C.REGC_NRO_PROPOSTA_SICAQ, WSRC_INF_SICAQWEB.WSRC_NRO_PROPOSTA_SICAQ);

            /*" -8566- MOVE REGC-TIPO-CORRESPONDENTE TO WSRC-TIPO-CORRESPONDENTE */
            _.Move(LBFPF026.REG_TIPO_C.REGC_TIPO_CORRESPONDENTE, WSRC_INF_SICAQWEB.WSRC_TIPO_CORRESPONDENTE);

            /*" -8568- MOVE REGC-ORIGEM-PROPOSTA TO WSRC-ORIGEM-PROPOSTA */
            _.Move(LBFPF026.REG_TIPO_C.REGC_ORIGEM_PROPOSTA, WSRC_INF_SICAQWEB.WSRC_ORIGEM_PROPOSTA);

            /*" -8571- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROFIDCO-NUM-IDENTIFICACAO OF DCLPROP-FIDELIZ-COMP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO);

            /*" -8575- MOVE WSRC-INF-SICAQWEB TO PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP. */
            _.Move(WSRC_INF_SICAQWEB, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);

            /*" -8576- IF CANAL-VENDA-CORRETOR */

            if (WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_CORRETOR"])
            {

                /*" -8578- MOVE '3' TO PROFIDCO-IND-TP-INFORMACAO OF DCLPROP-FIDELIZ-COMP */
                _.Move("3", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

                /*" -8579- ELSE */
            }
            else
            {


                /*" -8581- MOVE '1' TO PROFIDCO-IND-TP-INFORMACAO OF DCLPROP-FIDELIZ-COMP */
                _.Move("1", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

                /*" -8584- END-IF */
            }


            /*" -8587- MOVE 'VA0600B' TO PROFIDCO-COD-USUARIO OF DCLPROP-FIDELIZ-COMP. */
            _.Move("VA0600B", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO);

            /*" -8594- PERFORM R0910_TRATA_INF_SICAQWEB_DB_INSERT_1 */

            R0910_TRATA_INF_SICAQWEB_DB_INSERT_1();

            /*" -8597- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8598- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -8599- DISPLAY 'VA0600B - INFORMACAO COMPL. JA EXISTE' */
                    _.Display($"VA0600B - INFORMACAO COMPL. JA EXISTE");

                    /*" -8601- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -8603- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -8605- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8607- DISPLAY '          IND TIPO INFORMACAO...........  ' PROFIDCO-IND-TP-INFORMACAO OF DCLPROP-FIDELIZ-COMP */
                    _.Display($"          IND TIPO INFORMACAO...........  {PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO}");

                    /*" -8608- ELSE */
                }
                else
                {


                    /*" -8609- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -8610- DISPLAY '          ERRO INSERT TABELA PROPOSTA_COMPL' */
                    _.Display($"          ERRO INSERT TABELA PROPOSTA_COMPL");

                    /*" -8612- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -8614- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -8616- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8618- DISPLAY '          IND TIPO INFORMACAO...........  ' PROFIDCO-IND-TP-INFORMACAO OF DCLPROP-FIDELIZ-COMP */
                    _.Display($"          IND TIPO INFORMACAO...........  {PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO}");

                    /*" -8620- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -8621- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -8622- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -8623- END-IF */
                }


                /*" -8624- END-IF */
            }


            /*" -8624- . */

        }

        [StopWatch]
        /*" R0910-TRATA-INF-SICAQWEB-DB-INSERT-1 */
        public void R0910_TRATA_INF_SICAQWEB_DB_INSERT_1()
        {
            /*" -8594- EXEC SQL INSERT INTO SEGUROS.PROP_FIDELIZ_COMP VALUES (:DCLPROP-FIDELIZ-COMP.PROFIDCO-NUM-IDENTIFICACAO, :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL, :DCLPROP-FIDELIZ-COMP.PROFIDCO-COD-USUARIO, CURRENT TIMESTAMP, :DCLPROP-FIDELIZ-COMP.PROFIDCO-IND-TP-INFORMACAO) END-EXEC. */

            var r0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1 = new R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1()
            {
                PROFIDCO_NUM_IDENTIFICACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO.ToString(),
                PROFIDCO_INFORMACAO_COMPL = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL.ToString(),
                PROFIDCO_COD_USUARIO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO.ToString(),
                PROFIDCO_IND_TP_INFORMACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO.ToString(),
            };

            R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1.Execute(r0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_SAIDA*/

        [StopWatch]
        /*" R0950-INF-MEDICO-VIDA-MULHER-SECTION */
        private void R0950_INF_MEDICO_VIDA_MULHER_SECTION()
        {
            /*" -8630- MOVE 'R0950-INF-MEDICO-VIDA-MULHER' TO PARAGRAFO. */
            _.Move("R0950-INF-MEDICO-VIDA-MULHER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8631- MOVE 'INSERT SEGUROS.PROP_FIDELIZ_COMP' TO COMANDO. */
            _.Move("INSERT SEGUROS.PROP_FIDELIZ_COMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8634- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROFIDCO-NUM-IDENTIFICACAO OF DCLPROP-FIDELIZ-COMP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO);

            /*" -8637- MOVE R6-INFORMACOES-DO-MEDICO OF REGISTRO-VIDA-MULHER TO PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP. */
            _.Move(LBFPF161.REGISTRO_VIDA_MULHER.R6_INFORMACOES_DO_MEDICO, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);

            /*" -8640- MOVE '2' TO PROFIDCO-IND-TP-INFORMACAO OF DCLPROP-FIDELIZ-COMP. */
            _.Move("2", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

            /*" -8643- MOVE 'VA0600B' TO PROFIDCO-COD-USUARIO OF DCLPROP-FIDELIZ-COMP. */
            _.Move("VA0600B", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO);

            /*" -8650- PERFORM R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1 */

            R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1();

            /*" -8653- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8654- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -8655- DISPLAY 'VA0600B - INFORMACAO MEDICO JA EXISTE' */
                    _.Display($"VA0600B - INFORMACAO MEDICO JA EXISTE");

                    /*" -8657- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -8659- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -8661- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8662- ELSE */
                }
                else
                {


                    /*" -8663- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -8664- DISPLAY '          ERRO INSERT INFORMACOES MEDICO' */
                    _.Display($"          ERRO INSERT INFORMACOES MEDICO");

                    /*" -8666- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -8668- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -8670- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8672- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -8673- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -8673- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0950-INF-MEDICO-VIDA-MULHER-DB-INSERT-1 */
        public void R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1()
        {
            /*" -8650- EXEC SQL INSERT INTO SEGUROS.PROP_FIDELIZ_COMP VALUES (:DCLPROP-FIDELIZ-COMP.PROFIDCO-NUM-IDENTIFICACAO, :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL, :DCLPROP-FIDELIZ-COMP.PROFIDCO-COD-USUARIO, CURRENT TIMESTAMP, :DCLPROP-FIDELIZ-COMP.PROFIDCO-IND-TP-INFORMACAO) END-EXEC. */

            var r0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1_Insert1 = new R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1_Insert1()
            {
                PROFIDCO_NUM_IDENTIFICACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO.ToString(),
                PROFIDCO_INFORMACAO_COMPL = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL.ToString(),
                PROFIDCO_COD_USUARIO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO.ToString(),
                PROFIDCO_IND_TP_INFORMACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO.ToString(),
            };

            R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1_Insert1.Execute(r0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_SAIDA*/

        [StopWatch]
        /*" R0952-INF-EMPRESA-PEXECUTIVA-SECTION */
        private void R0952_INF_EMPRESA_PEXECUTIVA_SECTION()
        {
            /*" -8680- MOVE 'R0952-INF-EMPRESA-PEXECUTIVA' TO PARAGRAFO */
            _.Move("R0952-INF-EMPRESA-PEXECUTIVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8682- MOVE 'INSERT PROP_FIDELIZ_COMP' TO COMANDO */
            _.Move("INSERT PROP_FIDELIZ_COMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8684- MOVE R6-RAZAO-SOCIAL-MEI TO R6C-RAZAO-SOCIAL-MEI */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_RAZAO_SOCIAL_MEI, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_RAZAO_SOCIAL_MEI);

            /*" -8686- MOVE R6-DATA-CONSTITUICAO-MEI TO R6C-DATA-CONSTITUICAO-MEI */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_DATA_CONSTITUICAO_MEI, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DATA_CONSTITUICAO_MEI);

            /*" -8687- MOVE R6-COD-PORTE-MEI TO R6C-COD-PORTE-MEI */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_COD_PORTE_MEI, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_COD_PORTE_MEI);

            /*" -8688- MOVE R6-CNAE-MEI TO R6C-CNAE-MEI */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_CNAE_MEI, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNAE_MEI);

            /*" -8689- MOVE R6-VAL-FAT-ANUAL-MEI TO R6C-VAL-FAT-ANUAL-MEI */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_VAL_FAT_ANUAL_MEI, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_VAL_FAT_ANUAL_MEI);

            /*" -8690- MOVE R6-DAT-FAT-ANUAL-MEI TO R6C-DAT-FAT-ANUAL-MEI */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_DAT_FAT_ANUAL_MEI, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DAT_FAT_ANUAL_MEI);

            /*" -8691- MOVE R6-CNPJ-MEI TO R6C-CNPJ-MEI */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_CNPJ_MEI, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CNPJ_MEI);

            /*" -8692- MOVE R6-DDD-COMERCIAL TO R6C-DDD-COMERCIAL */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_DDD_COMERCIAL, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_DDD_COMERCIAL);

            /*" -8693- MOVE R6-TELEFONE-COMERCIAL TO R6C-TELEFONE-COMERCIAL */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_TELEFONE_COMERCIAL, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_TELEFONE_COMERCIAL);

            /*" -8694- MOVE R6-EMAIL TO R6C-EMAIL */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_EMAIL, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_EMAIL);

            /*" -8695- MOVE R6-TIPO-ENDERECO TO R6C-TIPO-ENDERECO */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_TIPO_ENDERECO, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_TIPO_ENDERECO);

            /*" -8696- MOVE R6-ENDERECO TO R6C-ENDERECO */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_ENDERECO, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_ENDERECO);

            /*" -8697- MOVE R6-BAIRRO TO R6C-BAIRRO */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_BAIRRO, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_BAIRRO);

            /*" -8698- MOVE R6-CIDADE TO R6C-CIDADE */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_CIDADE, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CIDADE);

            /*" -8699- MOVE R6-UF TO R6C-UF */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_UF, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_UF);

            /*" -8701- MOVE R6-CEP TO R6C-CEP */
            _.Move(LBFPF164.REGISTRO_EMPRESA.R6_CEP, BIEMPCOM.R6C_EMPRESA_COMPACTADO.R6C_CEP);

            /*" -8703- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROFIDCO-NUM-IDENTIFICACAO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO);

            /*" -8705- MOVE R6C-EMPRESA-COMPACTADO TO PROFIDCO-INFORMACAO-COMPL */
            _.Move(BIEMPCOM.R6C_EMPRESA_COMPACTADO, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);

            /*" -8706- MOVE '4' TO PROFIDCO-IND-TP-INFORMACAO */
            _.Move("4", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

            /*" -8708- MOVE 'PF0600B' TO PROFIDCO-COD-USUARIO */
            _.Move("PF0600B", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO);

            /*" -8715- PERFORM R0952_INF_EMPRESA_PEXECUTIVA_DB_INSERT_1 */

            R0952_INF_EMPRESA_PEXECUTIVA_DB_INSERT_1();

            /*" -8718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8719- DISPLAY 'PF0600B - FIM ANORMAL' */
                _.Display($"PF0600B - FIM ANORMAL");

                /*" -8720- DISPLAY 'ERRO INSERT NA PROP_FIDELIZ_COMP' */
                _.Display($"ERRO INSERT NA PROP_FIDELIZ_COMP");

                /*" -8721- DISPLAY 'IDENTIFICACAO: ' PROFIDCO-NUM-IDENTIFICACAO */
                _.Display($"IDENTIFICACAO: {PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO}");

                /*" -8723- DISPLAY 'NUMERO PROPOSTA: ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"NUMERO PROPOSTA: {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -8724- DISPLAY 'SQLCODE: ' SQLCODE */
                _.Display($"SQLCODE: {DB.SQLCODE}");

                /*" -8725- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8726- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -8728- END-IF */
            }


            /*" -8729- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -8730- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -8731- DISPLAY 'VA0600B - INFORMACAO EMPRESA JA EXISTE' */
                    _.Display($"VA0600B - INFORMACAO EMPRESA JA EXISTE");

                    /*" -8733- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -8735- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -8737- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8738- ELSE */
                }
                else
                {


                    /*" -8739- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -8740- DISPLAY '          ERRO INSERT INFORMACOES EMPRESA' */
                    _.Display($"          ERRO INSERT INFORMACOES EMPRESA");

                    /*" -8742- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -8744- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -8746- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -8748- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -8749- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -8749- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0952-INF-EMPRESA-PEXECUTIVA-DB-INSERT-1 */
        public void R0952_INF_EMPRESA_PEXECUTIVA_DB_INSERT_1()
        {
            /*" -8715- EXEC SQL INSERT INTO SEGUROS.PROP_FIDELIZ_COMP VALUES (:PROFIDCO-NUM-IDENTIFICACAO , :PROFIDCO-INFORMACAO-COMPL , :PROFIDCO-COD-USUARIO , CURRENT TIMESTAMP , :PROFIDCO-IND-TP-INFORMACAO ) END-EXEC */

            var r0952_INF_EMPRESA_PEXECUTIVA_DB_INSERT_1_Insert1 = new R0952_INF_EMPRESA_PEXECUTIVA_DB_INSERT_1_Insert1()
            {
                PROFIDCO_NUM_IDENTIFICACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO.ToString(),
                PROFIDCO_INFORMACAO_COMPL = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL.ToString(),
                PROFIDCO_COD_USUARIO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO.ToString(),
                PROFIDCO_IND_TP_INFORMACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO.ToString(),
            };

            R0952_INF_EMPRESA_PEXECUTIVA_DB_INSERT_1_Insert1.Execute(r0952_INF_EMPRESA_PEXECUTIVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0952_SAIDA*/

        [StopWatch]
        /*" R0960-INF-PRESTAMISTA-SECTION */
        private void R0960_INF_PRESTAMISTA_SECTION()
        {
            /*" -8756- MOVE 'R0960-INF-PRESTAMISTA       ' TO PARAGRAFO. */
            _.Move("R0960-INF-PRESTAMISTA       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8757- MOVE 'SELECT GE-OPER-CREDITO      ' TO COMANDO. */
            _.Move("SELECT GE-OPER-CREDITO      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8760- MOVE R6-DES-OPER-CREDITO OF REGISTRO-PRESTAMISTA TO GE372-DES-OPER-CREDITO */
            _.Move(LBFPF162.REGISTRO_PRESTAMISTA.R6_DES_OPER_CREDITO, GE372.DCLGE_OPER_CREDITO.GE372_DES_OPER_CREDITO);

            /*" -8767- PERFORM R0960_INF_PRESTAMISTA_DB_SELECT_1 */

            R0960_INF_PRESTAMISTA_DB_SELECT_1();

            /*" -8770- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -8771- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -8772- DISPLAY '          ERRO SELECT GE_OPER_CREDITO   ' */
                _.Display($"          ERRO SELECT GE_OPER_CREDITO   ");

                /*" -8774- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -8776- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -8778- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -8780- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -8781- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8783- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -8786- MOVE GE372-COD-OPER-CREDITO TO PROPSSVD-COD-OPER-CREDITO */
            _.Move(GE372.DCLGE_OPER_CREDITO.GE372_COD_OPER_CREDITO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO);

            /*" -8789- MOVE R6-NUM-CONTR-VINCULO TO PROPSSVD-NUM-CONTR-VINCULO */
            _.Move(LBFPF162.REGISTRO_PRESTAMISTA.R6_NUM_CONTR_VINCULO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO);

            /*" -8790- MOVE R6-COD-CORRESP-BANC TO PROPSSVD-COD-CORRESP-BANC. */
            _.Move(LBFPF162.REGISTRO_PRESTAMISTA.R6_COD_CORRESP_BANC, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC);

        }

        [StopWatch]
        /*" R0960-INF-PRESTAMISTA-DB-SELECT-1 */
        public void R0960_INF_PRESTAMISTA_DB_SELECT_1()
        {
            /*" -8767- EXEC SQL SELECT COD_OPER_CREDITO INTO :GE372-COD-OPER-CREDITO FROM SEGUROS.GE_OPER_CREDITO WHERE DES_OPER_CREDITO = :GE372-DES-OPER-CREDITO END-EXEC. */

            var r0960_INF_PRESTAMISTA_DB_SELECT_1_Query1 = new R0960_INF_PRESTAMISTA_DB_SELECT_1_Query1()
            {
                GE372_DES_OPER_CREDITO = GE372.DCLGE_OPER_CREDITO.GE372_DES_OPER_CREDITO.ToString(),
            };

            var executed_1 = R0960_INF_PRESTAMISTA_DB_SELECT_1_Query1.Execute(r0960_INF_PRESTAMISTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE372_COD_OPER_CREDITO, GE372.DCLGE_OPER_CREDITO.GE372_COD_OPER_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0960_SAIDA*/

        [StopWatch]
        /*" R1000-INCLUI-NOME-SOCIAL-SECTION */
        private void R1000_INCLUI_NOME_SOCIAL_SECTION()
        {
            /*" -8801- MOVE '*' TO LK-GE053-E-TRACE */
            _.Move("*", SPGE053W.LK_GE053_E_TRACE);

            /*" -8802- MOVE 'VA' TO LK-GE053-E-IDE-SISTEMA */
            _.Move("VA", SPGE053W.LK_GE053_E_IDE_SISTEMA);

            /*" -8805- MOVE 1 TO LK-GE053-E-IND-OPERACAO */
            _.Move(1, SPGE053W.LK_GE053_E_IND_OPERACAO);

            /*" -8806- MOVE R1-CGC-CPF TO LK-GE053-I-NUM-CPF. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, SPGE053W.LK_GE053_I_NUM_CPF);

            /*" -8808- MOVE '0001-01-01-00.00.00.000000' TO LK-GE053-I-DTH-OPERACAO. */
            _.Move("0001-01-01-00.00.00.000000", SPGE053W.LK_GE053_I_DTH_OPERACAO);

            /*" -8809- MOVE RSD-NOME-SOCIAL TO LK-GE053-I-NOM-SOCIAL. */
            _.Move(LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL, SPGE053W.LK_GE053_I_NOM_SOCIAL);

            /*" -8810- MOVE 'I' TO LK-GE053-I-IND-TIPO-ACAO. */
            _.Move("I", SPGE053W.LK_GE053_I_IND_TIPO_ACAO);

            /*" -8812- MOVE 'S' TO LK-GE053-I-IND-USA-NOME-SOCIAL. */
            _.Move("S", SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL);

            /*" -8814- MOVE 1 TO LK-GE053-I-COD-TP-PES-NEGOCIO. */
            _.Move(1, SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO);

            /*" -8815- MOVE RSD-NUM-PROPOSTA TO LK-GE053-I-NUM-PROPOSTA. */
            _.Move(LXFPF028.REG_TIPO_D.RSD_NUM_PROPOSTA, SPGE053W.LK_GE053_I_NUM_PROPOSTA);

            /*" -8817- MOVE RSD-NUM-PROPOSTA(1:1) TO LK-GE053-I-COD-CANAL-ORIGEM. */
            _.Move(LXFPF028.REG_TIPO_D.RSD_NUM_PROPOSTA.Substring(1, 1), SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM);

            /*" -8818- MOVE 'VA0600B' TO LK-GE053-I-NUM-MATRICULA. */
            _.Move("VA0600B", SPGE053W.LK_GE053_I_NUM_MATRICULA);

            /*" -8819- MOVE SPACES TO LK-GE053-I-NOM-PROGRAMA. */
            _.Move("", SPGE053W.LK_GE053_I_NOM_PROGRAMA);

            /*" -8822- MOVE '0001-01-01-00.00.00.000000' TO LK-GE053-I-DTH-CADASTRAMENTO. */
            _.Move("0001-01-01-00.00.00.000000", SPGE053W.LK_GE053_I_DTH_CADASTRAMENTO);

            /*" -8844- CALL 'SPBGE053' USING LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE. */
            _.Call("SPBGE053", SPGE053W);

            /*" -8845- IF LK-GE053-IND-ERRO NOT EQUAL ZERO */

            if (SPGE053W.LK_GE053_IND_ERRO != 00)
            {

                /*" -8846- DISPLAY 'ERRO NO PROCESSAMENTO DO NOME SOCIAL' */
                _.Display($"ERRO NO PROCESSAMENTO DO NOME SOCIAL");

                /*" -8847- DISPLAY 'LK-GE053-IND-ERRO   ' LK-GE053-IND-ERRO */
                _.Display($"LK-GE053-IND-ERRO   {SPGE053W.LK_GE053_IND_ERRO}");

                /*" -8848- DISPLAY 'LK-GE053-ID-ERRO    ' LK-GE053-ID-ERRO */
                _.Display($"LK-GE053-ID-ERRO    {SPGE053W.LK_GE053_ID_ERRO}");

                /*" -8849- DISPLAY 'LK-GE053-MENSAGEM   ' LK-GE053-MENSAGEM */
                _.Display($"LK-GE053-MENSAGEM   {SPGE053W.LK_GE053_MENSAGEM}");

                /*" -8850- IF LK-GE053-SQLCODE NOT EQUAL ZERO */

                if (SPGE053W.LK_GE053_SQLCODE != 00)
                {

                    /*" -8851- DISPLAY 'LK-GE053-NOM-TABELA ' LK-GE053-NOM-TABELA */
                    _.Display($"LK-GE053-NOM-TABELA {SPGE053W.LK_GE053_NOM_TABELA}");

                    /*" -8852- DISPLAY 'LK-GE053-SQLCODE    ' LK-GE053-SQLCODE */
                    _.Display($"LK-GE053-SQLCODE    {SPGE053W.LK_GE053_SQLCODE}");

                    /*" -8853- DISPLAY 'LK-GE053-SQLERRMC   ' LK-GE053-SQLERRMC */
                    _.Display($"LK-GE053-SQLERRMC   {SPGE053W.LK_GE053_SQLERRMC}");

                    /*" -8854- DISPLAY 'LK-GE053-SQLSTATE   ' LK-GE053-SQLSTATE */
                    _.Display($"LK-GE053-SQLSTATE   {SPGE053W.LK_GE053_SQLSTATE}");

                    /*" -8855- END-IF */
                }


                /*" -8856- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -8857- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8857- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1800-00-GERAR-MOV-VDEMP-SECTION */
        private void R1800_00_GERAR_MOV_VDEMP_SECTION()
        {
            /*" -8864- MOVE 'R1800-00-GERAR-MOV-VDEMP' TO PARAGRAFO. */
            _.Move("R1800-00-GERAR-MOV-VDEMP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8865- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8867- PERFORM R1810-00-GRAVA-REG-CLIENTE */

            R1810_00_GRAVA_REG_CLIENTE_SECTION();

            /*" -8871- PERFORM R1815-00-GRAVA-REG-ENDERECO VARYING W-IND-ENDER1 FROM 1 BY 1 UNTIL W-IND-ENDER1 GREATER W-IND-ENDER-N. */

            for (WAREA_AUXILIAR.W_IND_ENDER1.Value = 1; !(WAREA_AUXILIAR.W_IND_ENDER1 > WAREA_AUXILIAR.W_IND_ENDER_N); WAREA_AUXILIAR.W_IND_ENDER1.Value += 1)
            {

                R1815_00_GRAVA_REG_ENDERECO_SECTION();
            }

            /*" -8873- PERFORM R1820-00-GRAVA-PROPOSTA */

            R1820_00_GRAVA_PROPOSTA_SECTION();

            /*" -8874- IF W-EXISTE-TP-5 EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_5 == "SIM")
            {

                /*" -8878- PERFORM R1830-00-GRAVA-INF-COMPLE VARYING W-IND-INFO FROM 1 BY 1 UNTIL W-IND-INFO GREATER W-IND-INFO-N. */

                for (WAREA_AUXILIAR.W_IND_INFO.Value = 1; !(WAREA_AUXILIAR.W_IND_INFO > WAREA_AUXILIAR.W_IND_INFO_N); WAREA_AUXILIAR.W_IND_INFO.Value += 1)
                {

                    R1830_00_GRAVA_INF_COMPLE_SECTION();
                }
            }


            /*" -8879- IF W-EXISTE-TP-6 EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_6 == "SIM")
            {

                /*" -8883- PERFORM R1835-00-REGISTROS-DIVERSOS VARYING W-IND-VDEMP FROM 1 BY 1 UNTIL W-IND-VDEMP GREATER W-IND-VDEMP-N. */

                for (WAREA_AUXILIAR.W_IND_VDEMP.Value = 1; !(WAREA_AUXILIAR.W_IND_VDEMP > WAREA_AUXILIAR.W_IND_VDEMP_N); WAREA_AUXILIAR.W_IND_VDEMP.Value += 1)
                {

                    R1835_00_REGISTROS_DIVERSOS_SECTION();
                }
            }


            /*" -8884- IF W-EXISTE-TP-B EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_B == "SIM")
            {

                /*" -8885- ADD 1 TO W-QTD-LD-VDEMP-B */
                WAREA_AUXILIAR.W_QTD_LD_VDEMP_B.Value = WAREA_AUXILIAR.W_QTD_LD_VDEMP_B + 1;

                /*" -8886- MOVE REG-TIPO-B TO REG-MOV-VDEMP */
                _.Move(LXFPF024.REG_TIPO_B, REG_MOV_VDEMP);

                /*" -8887- WRITE REG-MOV-VDEMP */
                MOV_VDEMP.Write(REG_MOV_VDEMP.GetMoveValues().ToString());

                /*" -8889- END-IF. */
            }


            /*" -8890- IF W-EXISTE-TP-W EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_W == "SIM")
            {

                /*" -8891- ADD 1 TO W-QTD-LD-VDEMP-W */
                WAREA_AUXILIAR.W_QTD_LD_VDEMP_W.Value = WAREA_AUXILIAR.W_QTD_LD_VDEMP_W + 1;

                /*" -8892- MOVE REG-TIPO-W TO REG-MOV-VDEMP */
                _.Move(LXFPF027.REG_TIPO_W, REG_MOV_VDEMP);

                /*" -8893- WRITE REG-MOV-VDEMP */
                MOV_VDEMP.Write(REG_MOV_VDEMP.GetMoveValues().ToString());

                /*" -8893- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_SAIDA*/

        [StopWatch]
        /*" R1810-00-GRAVA-REG-CLIENTE-SECTION */
        private void R1810_00_GRAVA_REG_CLIENTE_SECTION()
        {
            /*" -8900- MOVE 'R1810-00-GRAVA-REG-CLIENTE' TO PARAGRAFO. */
            _.Move("R1810-00-GRAVA-REG-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8901- MOVE 'WRITE REG-MOV-VDEMP' TO COMANDO. */
            _.Move("WRITE REG-MOV-VDEMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8903- ADD 1 TO W-QTD-LD-VDEMP-1 */
            WAREA_AUXILIAR.W_QTD_LD_VDEMP_1.Value = WAREA_AUXILIAR.W_QTD_LD_VDEMP_1 + 1;

            /*" -8905- MOVE SPACES TO REG-MOV-VDEMP */
            _.Move("", REG_MOV_VDEMP);

            /*" -8907- MOVE REG-CLIENTES TO REG-MOV-VDEMP */
            _.Move(LBFPF011.REG_CLIENTES, REG_MOV_VDEMP);

            /*" -8907- WRITE REG-MOV-VDEMP. */
            MOV_VDEMP.Write(REG_MOV_VDEMP.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1810_SAIDA*/

        [StopWatch]
        /*" R1815-00-GRAVA-REG-ENDERECO-SECTION */
        private void R1815_00_GRAVA_REG_ENDERECO_SECTION()
        {
            /*" -8914- MOVE 'R1815-00-GRAVA-REG-ENDERECO' TO PARAGRAFO. */
            _.Move("R1815-00-GRAVA-REG-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8915- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8917- MOVE W-TB-REG-ENDERECOS-N(W-IND-ENDER1) TO REG-ENDERECO */
            _.Move(WAREA_AUXILIAR.W_TB_ENDERECOS_N.W_TAB_END_REG_N[WAREA_AUXILIAR.W_IND_ENDER1].W_TB_REG_ENDERECOS_N, LBFPF012.REG_ENDERECO);

            /*" -8919- ADD 1 TO W-QTD-LD-VDEMP-2 */
            WAREA_AUXILIAR.W_QTD_LD_VDEMP_2.Value = WAREA_AUXILIAR.W_QTD_LD_VDEMP_2 + 1;

            /*" -8921- MOVE SPACES TO REG-MOV-VDEMP */
            _.Move("", REG_MOV_VDEMP);

            /*" -8923- MOVE REG-ENDERECO TO REG-MOV-VDEMP */
            _.Move(LBFPF012.REG_ENDERECO, REG_MOV_VDEMP);

            /*" -8923- WRITE REG-MOV-VDEMP. */
            MOV_VDEMP.Write(REG_MOV_VDEMP.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1815_SAIDA*/

        [StopWatch]
        /*" R1820-00-GRAVA-PROPOSTA-SECTION */
        private void R1820_00_GRAVA_PROPOSTA_SECTION()
        {
            /*" -8930- MOVE 'R1820-00-GRAVA-PROPOSTA    ' TO PARAGRAFO. */
            _.Move("R1820-00-GRAVA-PROPOSTA    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8931- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8933- ADD 1 TO W-QTD-LD-VDEMP-3 */
            WAREA_AUXILIAR.W_QTD_LD_VDEMP_3.Value = WAREA_AUXILIAR.W_QTD_LD_VDEMP_3 + 1;

            /*" -8935- MOVE SPACES TO REG-MOV-VDEMP. */
            _.Move("", REG_MOV_VDEMP);

            /*" -8938- MOVE RH-NSAS OF REG-HEADER TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(LBFPF990.REG_HEADER.RH_NSAS, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -8941- MOVE W-QTD-LD-VDEMP-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -8943- MOVE REG-PROPOSTA-SASSE TO REG-MOV-VDEMP. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE, REG_MOV_VDEMP);

            /*" -8943- WRITE REG-MOV-VDEMP. */
            MOV_VDEMP.Write(REG_MOV_VDEMP.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1820_SAIDA*/

        [StopWatch]
        /*" R1830-00-GRAVA-INF-COMPLE-SECTION */
        private void R1830_00_GRAVA_INF_COMPLE_SECTION()
        {
            /*" -8950- MOVE 'R1830-00-GRAVA-INF-COMPLE  ' TO PARAGRAFO. */
            _.Move("R1830-00-GRAVA-INF-COMPLE  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8951- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8953- MOVE W-TB-REG-INFORMACOES(W-IND-INFO) TO REG-INFORMACOES. */
            _.Move(WAREA_AUXILIAR.W_TAB_INFORMACOES.W_TAB_INFO_REG[WAREA_AUXILIAR.W_IND_INFO].W_TB_REG_INFORMACOES, LBFPF015.REG_INFORMACOES);

            /*" -8955- ADD 1 TO W-QTD-LD-VDEMP-5 */
            WAREA_AUXILIAR.W_QTD_LD_VDEMP_5.Value = WAREA_AUXILIAR.W_QTD_LD_VDEMP_5 + 1;

            /*" -8957- MOVE SPACES TO REG-MOV-VDEMP */
            _.Move("", REG_MOV_VDEMP);

            /*" -8959- MOVE REG-INFORMACOES TO REG-MOV-VDEMP */
            _.Move(LBFPF015.REG_INFORMACOES, REG_MOV_VDEMP);

            /*" -8959- WRITE REG-MOV-VDEMP. */
            MOV_VDEMP.Write(REG_MOV_VDEMP.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1830_SAIDA*/

        [StopWatch]
        /*" R1835-00-REGISTROS-DIVERSOS-SECTION */
        private void R1835_00_REGISTROS_DIVERSOS_SECTION()
        {
            /*" -8966- MOVE 'R1835-00-REGISTROS-DIVERSOS' TO PARAGRAFO. */
            _.Move("R1835-00-REGISTROS-DIVERSOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8967- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8969- MOVE SPACES TO REG-MOV-VDEMP */
            _.Move("", REG_MOV_VDEMP);

            /*" -8971- MOVE W-TB-REG-DIV-VDEMP(W-IND-VDEMP) TO REG-MOV-VDEMP */
            _.Move(WAREA_AUXILIAR.W_TAB_DIV_VDEMP.W_TAB_VDEMP_REG[WAREA_AUXILIAR.W_IND_VDEMP].W_TB_REG_DIV_VDEMP, REG_MOV_VDEMP);

            /*" -8973- ADD 1 TO W-QTD-LD-VDEMP-6 */
            WAREA_AUXILIAR.W_QTD_LD_VDEMP_6.Value = WAREA_AUXILIAR.W_QTD_LD_VDEMP_6 + 1;

            /*" -8973- WRITE REG-MOV-VDEMP. */
            MOV_VDEMP.Write(REG_MOV_VDEMP.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1835_SAIDA*/

        [StopWatch]
        /*" R2000-00-QUEBRA-EMPRESSA-SECTION */
        private void R2000_00_QUEBRA_EMPRESSA_SECTION()
        {
            /*" -8981- MOVE 'R2000-00-QUEBRA-EMPRESSA   ' TO PARAGRAFO. */
            _.Move("R2000-00-QUEBRA-EMPRESSA   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8982-  EVALUATE TRUE  */

            /*" -8983-  WHEN MOVTO-CEF-SIGAT  */

            /*" -8983- IF MOVTO-CEF-SIGAT */

            if (WREA88.W_TP_MOVIMENTO["MOVTO_CEF_SIGAT"])
            {

                /*" -8984- DISPLAY ' *---- PROCESSADO MOVIMENTO DA CEF -----*' */
                _.Display($" *---- PROCESSADO MOVIMENTO DA CEF -----*");

                /*" -8985-  WHEN MOVTO-AIC  */

                /*" -8985- ELSE IF MOVTO-AIC */
            }
            else

            if (WREA88.W_TP_MOVIMENTO["MOVTO_AIC"])
            {

                /*" -8986- DISPLAY ' *---- PROCESSADO MOVIMENTO DO AIC    ----*' */
                _.Display($" *---- PROCESSADO MOVIMENTO DO AIC    ----*");

                /*" -8989- DISPLAY '       CODIGO DA FILIAL.............. ' W-RH-AGE-GERADORA */
                _.Display($"       CODIGO DA FILIAL.............. {W_REG_HEADER.W_RH_AGE_GERADORA}");

                /*" -8990-  WHEN MOVTO-SIVPF-FILIAL  */

                /*" -8990- ELSE IF MOVTO-SIVPF-FILIAL */
            }
            else

            if (WREA88.W_TP_MOVIMENTO["MOVTO_SIVPF_FILIAL"])
            {

                /*" -8991- DISPLAY ' *---- PROCESSADO MOVIMENTO DA FILIAL ----*' */
                _.Display($" *---- PROCESSADO MOVIMENTO DA FILIAL ----*");

                /*" -8994- DISPLAY '       CODIGO DA FILIAL.............. ' W-RH-AGE-GERADORA */
                _.Display($"       CODIGO DA FILIAL.............. {W_REG_HEADER.W_RH_AGE_GERADORA}");

                /*" -8995-  WHEN MOVTO-AUTO-COMPRA  */

                /*" -8995- ELSE IF MOVTO-AUTO-COMPRA */
            }
            else

            if (WREA88.W_TP_MOVIMENTO["MOVTO_AUTO_COMPRA"])
            {

                /*" -8996- DISPLAY ' *-- PROCESSADO MOVIMENTO AUTO COMPRA --*' */
                _.Display($" *-- PROCESSADO MOVIMENTO AUTO COMPRA --*");

                /*" -8997-  WHEN OTHER  */

                /*" -8997- ELSE */
            }
            else
            {


                /*" -8998- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -8999- DISPLAY '          MOVIMENTO NAO ESPERADO' */
                _.Display($"          MOVIMENTO NAO ESPERADO");

                /*" -9001- DISPLAY '          EMPRESA  PROCESSADA...... ' RH-NOME OF REG-HEADER */
                _.Display($"          EMPRESA  PROCESSADA...... {LBFPF990.REG_HEADER.RH_NOME}");

                /*" -9003- DISPLAY '          ARQUIVO NUMERO........... ' RH-NSAS OF REG-HEADER */
                _.Display($"          ARQUIVO NUMERO........... {LBFPF990.REG_HEADER.RH_NSAS}");

                /*" -9005- DISPLAY '          ORIGEM DO ARQUIVO........ ' RH-SIST-ORIGEM OF REG-HEADER */
                _.Display($"          ORIGEM DO ARQUIVO........ {LBFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                /*" -9007- DISPLAY '          GERADO EM................ ' RH-DATA-GERACAO OF REG-HEADER */
                _.Display($"          GERADO EM................ {LBFPF990.REG_HEADER.RH_DATA_GERACAO}");

                /*" -9008- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -9009- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9011-  END-EVALUATE.  */

                /*" -9011- END-IF. */
            }


            /*" -9013- DISPLAY '       ARQUIVO PROCESSADO.................... ' RH-NSAS OF REG-HEADER */
            _.Display($"       ARQUIVO PROCESSADO.................... {LBFPF990.REG_HEADER.RH_NSAS}");

            /*" -9015- DISPLAY '       GERADO EM............................. ' RH-DATA-GERACAO OF REG-HEADER */
            _.Display($"       GERADO EM............................. {LBFPF990.REG_HEADER.RH_DATA_GERACAO}");

            /*" -9017- DISPLAY '       TOTAL DE PROPOSTAS PROCESSADAS........ ' W-QTD-LD-SIVPF-3 */
            _.Display($"       TOTAL DE PROPOSTAS PROCESSADAS........ {WAREA_AUXILIAR.W_QTD_LD_SIVPF_3}");

            /*" -9019- DISPLAY '       TOTAL DE PROPOSTAS COM INCOSISTENCIA.. ' W-QTD-CRITICA */
            _.Display($"       TOTAL DE PROPOSTAS COM INCOSISTENCIA.. {WAREA_AUXILIAR.W_QTD_CRITICA}");

            /*" -9020- DISPLAY ' ' */
            _.Display($" ");

            /*" -9022- DISPLAY '       PROPOSTAS COM MATRIZ AGRAVO/DESC ..... ' W-QTD-MATRIZ */
            _.Display($"       PROPOSTAS COM MATRIZ AGRAVO/DESC ..... {WAREA_AUXILIAR.W_QTD_MATRIZ}");

            /*" -9025- DISPLAY '       QUANTIDADE SITUACAO PCR GERADA........ ' WS-QT-SITUACAO-PCR */
            _.Display($"       QUANTIDADE SITUACAO PCR GERADA........ {WS_QT_SITUACAO_PCR}");

            /*" -9069- MOVE ZEROS TO W-QTD-LD-SIVPF-0, W-QTD-LD-SIVPF-1, W-QTD-LD-SIVPF-2, W-QTD-LD-SIVPF-3, W-QTD-LD-SIVPF-4, W-QTD-LD-SIVPF-5, W-QTD-LD-SIVPF-6, W-QTD-LD-SIVPF-7, W-QTD-LD-SIVPF-8, W-QTD-LD-SIVPF-9, W-QTD-LD-SIVPF-A, W-QTD-LD-SIVPF-B, W-QTD-LD-SIVPF-C, W-QTD-LD-SIVPF-D, W-QTD-LD-SIVPF-E, W-QTD-LD-SIVPF-F, W-QTD-LD-SIVPF-G, W-QTD-LD-SIVPF-H, W-QTD-LD-SIVPF-I, W-QTD-LD-SIVPF-J, W-QTD-LD-SIVPF-W, W-QTD-LD-RISCO-0, W-QTD-LD-RISCO-1, W-QTD-LD-RISCO-2, W-QTD-LD-RISCO-3, W-QTD-LD-RISCO-4, W-QTD-LD-RISCO-5, W-QTD-LD-RISCO-6, W-QTD-LD-RISCO-7, W-QTD-LD-RISCO-8, W-QTD-LD-RISCO-9, W-QTD-LD-RISCO-A, W-QTD-LD-RISCO-B, W-QTD-LD-RISCO-C, W-QTD-LD-RISCO-D, W-QTD-LD-RISCO-E, W-QTD-LD-RISCO-F, W-QTD-LD-RISCO-G, W-QTD-LD-RISCO-H, W-QTD-LD-RISCO-I, W-QTD-LD-RISCO-J, W-QTD-LD-VDEMP-0, W-QTD-LD-VDEMP-1, W-QTD-LD-VDEMP-2, W-QTD-LD-VDEMP-3, W-QTD-LD-VDEMP-4, W-QTD-LD-VDEMP-5, W-QTD-LD-VDEMP-6, W-QTD-LD-VDEMP-7, W-QTD-LD-VDEMP-8, W-QTD-LD-VDEMP-9, W-QTD-LD-VDEMP-A, W-QTD-LD-VDEMP-B, W-QTD-LD-VDEMP-C, W-QTD-LD-VDEMP-D, W-QTD-LD-VDEMP-E, W-QTD-LD-VDEMP-F, W-QTD-LD-VDEMP-G, W-QTD-LD-VDEMP-H, W-QTD-LD-VDEMP-I, W-QTD-LD-VDEMP-J, W-QTD-LD-VDEMP-W, W-QTD-LD-AUTO-0, W-QTD-LD-AUTO-1, W-QTD-LD-AUTO-2, W-QTD-LD-AUTO-3, W-QTD-LD-AUTO-4, W-QTD-LD-AUTO-5, W-QTD-LD-AUTO-6, W-QTD-LD-AUTO-7, W-QTD-LD-AUTO-8, W-QTD-LD-AUTO-9, W-QTD-LD-AUTO-A, W-QTD-LD-AUTO-B, W-QTD-LD-AUTO-C, W-QTD-LD-AUTO-D, W-QTD-LD-AUTO-E, W-QTD-LD-AUTO-F, W-QTD-LD-AUTO-G, W-QTD-LD-AUTO-H, W-QTD-LD-AUTO-I, W-QTD-LD-AUTO-J, W-QTD-CRITICA. */
            _.Move(0, WAREA_AUXILIAR.W_QTD_LD_SIVPF_0, WAREA_AUXILIAR.W_QTD_LD_SIVPF_1, WAREA_AUXILIAR.W_QTD_LD_SIVPF_2, WAREA_AUXILIAR.W_QTD_LD_SIVPF_3, WAREA_AUXILIAR.W_QTD_LD_SIVPF_4, WAREA_AUXILIAR.W_QTD_LD_SIVPF_5, WAREA_AUXILIAR.W_QTD_LD_SIVPF_6, WAREA_AUXILIAR.W_QTD_LD_SIVPF_7, WAREA_AUXILIAR.W_QTD_LD_SIVPF_8, WAREA_AUXILIAR.W_QTD_LD_SIVPF_9, WAREA_AUXILIAR.W_QTD_LD_SIVPF_A, WAREA_AUXILIAR.W_QTD_LD_SIVPF_B, WAREA_AUXILIAR.W_QTD_LD_SIVPF_C, WAREA_AUXILIAR.W_QTD_LD_SIVPF_D, WAREA_AUXILIAR.W_QTD_LD_SIVPF_E, WAREA_AUXILIAR.W_QTD_LD_SIVPF_F, WAREA_AUXILIAR.W_QTD_LD_SIVPF_G, WAREA_AUXILIAR.W_QTD_LD_SIVPF_H, WAREA_AUXILIAR.W_QTD_LD_SIVPF_I, WAREA_AUXILIAR.W_QTD_LD_SIVPF_J, WAREA_AUXILIAR.W_QTD_LD_SIVPF_W, WAREA_AUXILIAR.W_QTD_LD_RISCO_0, WAREA_AUXILIAR.W_QTD_LD_RISCO_1, WAREA_AUXILIAR.W_QTD_LD_RISCO_2, WAREA_AUXILIAR.W_QTD_LD_RISCO_3, WAREA_AUXILIAR.W_QTD_LD_RISCO_4, WAREA_AUXILIAR.W_QTD_LD_RISCO_5, WAREA_AUXILIAR.W_QTD_LD_RISCO_6, WAREA_AUXILIAR.W_QTD_LD_RISCO_7, WAREA_AUXILIAR.W_QTD_LD_RISCO_8, WAREA_AUXILIAR.W_QTD_LD_RISCO_9, WAREA_AUXILIAR.W_QTD_LD_RISCO_A, WAREA_AUXILIAR.W_QTD_LD_RISCO_B, WAREA_AUXILIAR.W_QTD_LD_RISCO_C, WAREA_AUXILIAR.W_QTD_LD_RISCO_D, WAREA_AUXILIAR.W_QTD_LD_RISCO_E, WAREA_AUXILIAR.W_QTD_LD_RISCO_F, WAREA_AUXILIAR.W_QTD_LD_RISCO_G, WAREA_AUXILIAR.W_QTD_LD_RISCO_H, WAREA_AUXILIAR.W_QTD_LD_RISCO_I, WAREA_AUXILIAR.W_QTD_LD_RISCO_J, WAREA_AUXILIAR.W_QTD_LD_VDEMP_0, WAREA_AUXILIAR.W_QTD_LD_VDEMP_1, WAREA_AUXILIAR.W_QTD_LD_VDEMP_2, WAREA_AUXILIAR.W_QTD_LD_VDEMP_3, WAREA_AUXILIAR.W_QTD_LD_VDEMP_4, WAREA_AUXILIAR.W_QTD_LD_VDEMP_5, WAREA_AUXILIAR.W_QTD_LD_VDEMP_6, WAREA_AUXILIAR.W_QTD_LD_VDEMP_7, WAREA_AUXILIAR.W_QTD_LD_VDEMP_8, WAREA_AUXILIAR.W_QTD_LD_VDEMP_9, WAREA_AUXILIAR.W_QTD_LD_VDEMP_A, WAREA_AUXILIAR.W_QTD_LD_VDEMP_B, WAREA_AUXILIAR.W_QTD_LD_VDEMP_C, WAREA_AUXILIAR.W_QTD_LD_VDEMP_D, WAREA_AUXILIAR.W_QTD_LD_VDEMP_E, WAREA_AUXILIAR.W_QTD_LD_VDEMP_F, WAREA_AUXILIAR.W_QTD_LD_VDEMP_G, WAREA_AUXILIAR.W_QTD_LD_VDEMP_H, WAREA_AUXILIAR.W_QTD_LD_VDEMP_I, WAREA_AUXILIAR.W_QTD_LD_VDEMP_J, WAREA_AUXILIAR.W_QTD_LD_VDEMP_W, WAREA_AUXILIAR.W_QTD_LD_AUTO_0, WAREA_AUXILIAR.W_QTD_LD_AUTO_1, WAREA_AUXILIAR.W_QTD_LD_AUTO_2, WAREA_AUXILIAR.W_QTD_LD_AUTO_3, WAREA_AUXILIAR.W_QTD_LD_AUTO_4, WAREA_AUXILIAR.W_QTD_LD_AUTO_5, WAREA_AUXILIAR.W_QTD_LD_AUTO_6, WAREA_AUXILIAR.W_QTD_LD_AUTO_7, WAREA_AUXILIAR.W_QTD_LD_AUTO_8, WAREA_AUXILIAR.W_QTD_LD_AUTO_9, WAREA_AUXILIAR.W_QTD_LD_AUTO_A, WAREA_AUXILIAR.W_QTD_LD_AUTO_B, WAREA_AUXILIAR.W_QTD_LD_AUTO_C, WAREA_AUXILIAR.W_QTD_LD_AUTO_D, WAREA_AUXILIAR.W_QTD_LD_AUTO_E, WAREA_AUXILIAR.W_QTD_LD_AUTO_F, WAREA_AUXILIAR.W_QTD_LD_AUTO_G, WAREA_AUXILIAR.W_QTD_LD_AUTO_H, WAREA_AUXILIAR.W_QTD_LD_AUTO_I, WAREA_AUXILIAR.W_QTD_LD_AUTO_J, WAREA_AUXILIAR.W_QTD_CRITICA);

            /*" -9070- IF W-FIM-MOVTO-SIGAT NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT != "FIM")
            {

                /*" -9070- PERFORM R0050-00-LER-MOV-SIGAT. */

                R0050_00_LER_MOV_SIGAT_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_SAIDA*/

        [StopWatch]
        /*" R2060-00-ATUALIZA-ARQSIVPF-SECTION */
        private void R2060_00_ATUALIZA_ARQSIVPF_SECTION()
        {
            /*" -9078- MOVE 'R2060-00-ATUALIZAR-ARQSIVPF' TO PARAGRAFO. */
            _.Move("R2060-00-ATUALIZAR-ARQSIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9079- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9082- MOVE RH-SIST-ORIGEM OF REG-HEADER TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
            _.Move(LBFPF990.REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -9085- MOVE RH-NSAS OF REG-HEADER TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
            _.Move(LBFPF990.REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -9088- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -9090- MOVE RH-DATA-GERACAO OF REG-HEADER TO W-DATA-DDMMAAAA */
            _.Move(LBFPF990.REG_HEADER.RH_DATA_GERACAO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -9092- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -9094- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -9096- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -9099- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -9102- MOVE W-DATA-SQL TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -9105- MOVE W-QTD-LD-SIVPF-3 TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_SIVPF_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -9113- PERFORM R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1 */

            R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1();

            /*" -9117- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -9118- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -9119- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF / 1' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF / 1");

                /*" -9121- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -9123- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -9125- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -9127- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -9129- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -9130- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -9130- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2060-00-ATUALIZA-ARQSIVPF-DB-INSERT-1 */
        public void R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1()
        {
            /*" -9113- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1 = new R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1.Execute(r2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_SAIDA*/

        [StopWatch]
        /*" R2075-00-GERAR-TRAILLER-VDEMP-SECTION */
        private void R2075_00_GERAR_TRAILLER_VDEMP_SECTION()
        {
            /*" -9137- MOVE 'R2075-00-GERAR-TRAILLER-VDEMP' TO PARAGRAFO. */
            _.Move("R2075-00-GERAR-TRAILLER-VDEMP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9138- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9140- MOVE SPACES TO REG-TRAILLER. */
            _.Move("", LBFPF991.REG_TRAILLER);

            /*" -9143- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -9146- MOVE 'PRPVG' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPVG", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -9149- MOVE W-QTD-LD-VDEMP-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -9152- MOVE W-QTD-LD-VDEMP-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -9155- MOVE W-QTD-LD-VDEMP-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -9158- MOVE W-QTD-LD-VDEMP-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -9161- MOVE W-QTD-LD-VDEMP-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -9164- MOVE W-QTD-LD-VDEMP-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -9167- MOVE W-QTD-LD-VDEMP-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -9170- MOVE W-QTD-LD-VDEMP-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -9173- MOVE W-QTD-LD-VDEMP-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -9176- MOVE W-QTD-LD-VDEMP-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -9179- MOVE W-QTD-LD-VDEMP-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -9182- MOVE W-QTD-LD-VDEMP-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -9185- MOVE W-QTD-LD-VDEMP-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -9188- MOVE W-QTD-LD-VDEMP-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -9191- MOVE W-QTD-LD-VDEMP-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -9194- MOVE W-QTD-LD-VDEMP-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -9197- MOVE W-QTD-LD-VDEMP-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -9200- MOVE W-QTD-LD-VDEMP-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -9203- MOVE W-QTD-LD-VDEMP-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -9206- MOVE W-QTD-LD-VDEMP-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -9209- MOVE W-QTD-LD-VDEMP-W TO RT-QTDE-TIPO-W OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_VDEMP_W, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_W);

            /*" -9221- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = W-QTD-LD-VDEMP-1 + W-QTD-LD-VDEMP-2 + W-QTD-LD-VDEMP-3 + W-QTD-LD-VDEMP-4 + W-QTD-LD-VDEMP-5 + W-QTD-LD-VDEMP-6 + W-QTD-LD-VDEMP-7 + W-QTD-LD-VDEMP-8 + W-QTD-LD-VDEMP-9 + W-QTD-LD-VDEMP-A + W-QTD-LD-VDEMP-B + W-QTD-LD-VDEMP-C + W-QTD-LD-VDEMP-D + W-QTD-LD-VDEMP-E + W-QTD-LD-VDEMP-F + W-QTD-LD-VDEMP-G + W-QTD-LD-VDEMP-H + W-QTD-LD-VDEMP-I + W-QTD-LD-VDEMP-J + W-QTD-LD-VDEMP-W. */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = WAREA_AUXILIAR.W_QTD_LD_VDEMP_1 + WAREA_AUXILIAR.W_QTD_LD_VDEMP_2 + WAREA_AUXILIAR.W_QTD_LD_VDEMP_3 + WAREA_AUXILIAR.W_QTD_LD_VDEMP_4 + WAREA_AUXILIAR.W_QTD_LD_VDEMP_5 + WAREA_AUXILIAR.W_QTD_LD_VDEMP_6 + WAREA_AUXILIAR.W_QTD_LD_VDEMP_7 + WAREA_AUXILIAR.W_QTD_LD_VDEMP_8 + WAREA_AUXILIAR.W_QTD_LD_VDEMP_9 + WAREA_AUXILIAR.W_QTD_LD_VDEMP_A + WAREA_AUXILIAR.W_QTD_LD_VDEMP_B + WAREA_AUXILIAR.W_QTD_LD_VDEMP_C + WAREA_AUXILIAR.W_QTD_LD_VDEMP_D + WAREA_AUXILIAR.W_QTD_LD_VDEMP_E + WAREA_AUXILIAR.W_QTD_LD_VDEMP_F + WAREA_AUXILIAR.W_QTD_LD_VDEMP_G + WAREA_AUXILIAR.W_QTD_LD_VDEMP_H + WAREA_AUXILIAR.W_QTD_LD_VDEMP_I + WAREA_AUXILIAR.W_QTD_LD_VDEMP_J + WAREA_AUXILIAR.W_QTD_LD_VDEMP_W;

            /*" -9223- MOVE REG-TRAILLER TO REG-MOV-VDEMP */
            _.Move(LBFPF991.REG_TRAILLER, REG_MOV_VDEMP);

            /*" -9224- WRITE REG-MOV-VDEMP. */
            MOV_VDEMP.Write(REG_MOV_VDEMP.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2075_SAIDA*/

        [StopWatch]
        /*" R2090-00-ATUALIZAR-ARQSIVPF-SECTION */
        private void R2090_00_ATUALIZAR_ARQSIVPF_SECTION()
        {
            /*" -9230- MOVE 'R2090-00-ATUALIZAR-ARQSIVPF' TO PARAGRAFO. */
            _.Move("R2090-00-ATUALIZAR-ARQSIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9232- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9235- MOVE 'PRPVG' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
            _.Move("PRPVG", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -9237- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -9240- MOVE W-NSAS-PRP-CEF TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
            _.Move(WAREA_AUXILIAR.W_NSAS_PRP_CEF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -9244- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -9247- MOVE W-NSL-SASSE TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSL_SASSE, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -9255- PERFORM R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1 */

            R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1();

            /*" -9259- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -9260- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -9261- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF / 2' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF / 2");

                /*" -9263- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -9265- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -9267- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -9269- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -9271- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -9272- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -9272- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2090-00-ATUALIZAR-ARQSIVPF-DB-INSERT-1 */
        public void R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1()
        {
            /*" -9255- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1 = new R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1.Execute(r2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2090_SAIDA*/

        [StopWatch]
        /*" R2100-00-TB-CONTROLE-SECTION */
        private void R2100_00_TB_CONTROLE_SECTION()
        {
            /*" -9281- MOVE RH-NOME OF REG-HEADER TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
            _.Move(LBFPF990.REG_HEADER.RH_NOME, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -9284- MOVE RH-SIST-ORIGEM OF REG-HEADER TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
            _.Move(LBFPF990.REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -9287- MOVE RH-NSAS OF REG-HEADER TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
            _.Move(LBFPF990.REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -9290- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -9292- MOVE RH-DATA-GERACAO OF REG-HEADER TO W-DATA-DDMMAAAA */
            _.Move(LBFPF990.REG_HEADER.RH_DATA_GERACAO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -9294- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -9296- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -9298- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -9301- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -9304- MOVE W-DATA-SQL TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -9307- MOVE W-QTD-LD-SIVPF-3 TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_SIVPF_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -9315- PERFORM R2100_00_TB_CONTROLE_DB_INSERT_1 */

            R2100_00_TB_CONTROLE_DB_INSERT_1();

            /*" -9319- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -9320- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -9321- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF / 3' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF / 3");

                /*" -9323- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -9325- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -9327- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -9329- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -9331- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -9332- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -9332- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-TB-CONTROLE-DB-INSERT-1 */
        public void R2100_00_TB_CONTROLE_DB_INSERT_1()
        {
            /*" -9315- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r2100_00_TB_CONTROLE_DB_INSERT_1_Insert1 = new R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1.Execute(r2100_00_TB_CONTROLE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_SAIDA*/

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-SECTION */
        private void R6200_00_DECLARE_FONTES_SECTION()
        {
            /*" -9340- MOVE 'R6200-00-DECLARE-FONTES ' TO PARAGRAFO. */
            _.Move("R6200-00-DECLARE-FONTES ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9342- MOVE 'DECLARE FONTES         ' TO COMANDO. */
            _.Move("DECLARE FONTES         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9347- PERFORM R6200_00_DECLARE_FONTES_DB_DECLARE_1 */

            R6200_00_DECLARE_FONTES_DB_DECLARE_1();

            /*" -9349- PERFORM R6200_00_DECLARE_FONTES_DB_OPEN_1 */

            R6200_00_DECLARE_FONTES_DB_OPEN_1();

            /*" -9352- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9353- DISPLAY 'R6200 - PROBLEMAS DECLARE (FONTES   ) ..  ' */
                _.Display($"R6200 - PROBLEMAS DECLARE (FONTES   ) ..  ");

                /*" -9354- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -9354- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-DB-OPEN-1 */
        public void R6200_00_DECLARE_FONTES_DB_OPEN_1()
        {
            /*" -9349- EXEC SQL OPEN CFONTES END-EXEC. */

            CFONTES.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-SECTION */
        private void R6210_00_FETCH_FONTES_SECTION()
        {
            /*" -9361- MOVE 'R6210-FETCH-FONTES     ' TO PARAGRAFO. */
            _.Move("R6210-FETCH-FONTES     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9363- MOVE 'FETCH   FONTES         ' TO COMANDO. */
            _.Move("FETCH   FONTES         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9366- PERFORM R6210_00_FETCH_FONTES_DB_FETCH_1 */

            R6210_00_FETCH_FONTES_DB_FETCH_1();

            /*" -9369- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9370- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9371- MOVE 'S' TO W-FIM-FONTES */
                    _.Move("S", WAREA_AUXILIAR.W_FIM_FONTES);

                    /*" -9371- PERFORM R6210_00_FETCH_FONTES_DB_CLOSE_1 */

                    R6210_00_FETCH_FONTES_DB_CLOSE_1();

                    /*" -9373- ELSE */
                }
                else
                {


                    /*" -9373- PERFORM R6210_00_FETCH_FONTES_DB_CLOSE_2 */

                    R6210_00_FETCH_FONTES_DB_CLOSE_2();

                    /*" -9375- DISPLAY '6200 - (PROBLEMAS NO FETCH CFONTES  ) ..' */
                    _.Display($"6200 - (PROBLEMAS NO FETCH CFONTES  ) ..");

                    /*" -9376- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -9376- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-FETCH-1 */
        public void R6210_00_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -9366- EXEC SQL FETCH CFONTES INTO :DCLFONTES.FONTES-COD-FONTE, :DCLFONTES.FONTES-ULT-PROP-AUTOMAT END-EXEC. */

            if (CFONTES.Fetch())
            {
                _.Move(CFONTES.DCLFONTES_FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
                _.Move(CFONTES.DCLFONTES_FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }

        }

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-CLOSE-1 */
        public void R6210_00_FETCH_FONTES_DB_CLOSE_1()
        {
            /*" -9371- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6210_99_SAIDA*/

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-CLOSE-2 */
        public void R6210_00_FETCH_FONTES_DB_CLOSE_2()
        {
            /*" -9373- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }

        [StopWatch]
        /*" R6220-00-CARREGA-FONTES-SECTION */
        private void R6220_00_CARREGA_FONTES_SECTION()
        {
            /*" -9383- MOVE 'R6220-CARREGA-FONTES    ' TO PARAGRAFO. */
            _.Move("R6220-CARREGA-FONTES    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9385- MOVE 'CARREGA FONTES          ' TO COMANDO. */
            _.Move("CARREGA FONTES          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9388- MOVE FONTES-COD-FONTE OF DCLFONTES TO TAB-COD-FILIAL (FONTES-COD-FONTE OF DCLFONTES). */
            _.Move(FONTES.DCLFONTES.FONTES_COD_FONTE, WAREA_AUXILIAR.TAB_FILIAL.TAB_FILIAIS[FONTES.DCLFONTES.FONTES_COD_FONTE].TAB_COD_FILIAL);

            /*" -9390- SET I08 UP BY 1. */
            I08.Value += 1;

            /*" -9390- PERFORM R6210-00-FETCH-FONTES. */

            R6210_00_FETCH_FONTES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6220_99_SAIDA*/

        [StopWatch]
        /*" R7950-PROCURA-AVALIACAO-RISCO-SECTION */
        private void R7950_PROCURA_AVALIACAO_RISCO_SECTION()
        {
            /*" -9401- MOVE 'R7950-PROCURA-AVALIACAO-RISCO' TO PARAGRAFO. */
            _.Move("R7950-PROCURA-AVALIACAO-RISCO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9402- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9404- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9405- MOVE 'NAO' TO WS-ENCONTROU-RISCO */
            _.Move("NAO", WS_ENCONTROU_RISCO);

            /*" -9406- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -9408- MOVE 'VA0600B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("VA0600B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -9409- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -9412- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -9413- MOVE 0 TO LK-VG009-IND-ERRO */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO);

            /*" -9415- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA);

            /*" -9416- MOVE 0 TO LK-VG009-SQLCODE */
            _.Move(0, SPVG009W.LK_VG009_SQLCODE);

            /*" -9418- MOVE SPACES TO LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_SQLERRMC);

            /*" -9420- MOVE 'SPBVG009' TO WS-PROGRAMA */
            _.Move("SPBVG009", WS_PROGRAMA);

            /*" -9441- CALL WS-PROGRAMA USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_PROGRAMA, SPVG009W);

            /*" -9442- IF LK-VG009-IND-ERRO EQUAL ZEROS */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -9443- MOVE 'SIM' TO WS-ENCONTROU-RISCO */
                _.Move("SIM", WS_ENCONTROU_RISCO);

                /*" -9444- ELSE */
            }
            else
            {


                /*" -9446- IF LK-VG009-IND-ERRO EQUAL 1 AND LK-VG009-SQLCODE EQUAL +100 */

                if (SPVG009W.LK_VG009_IND_ERRO == 1 && SPVG009W.LK_VG009_SQLCODE == +100)
                {

                    /*" -9447- MOVE 'NAO' TO WS-ENCONTROU-RISCO */
                    _.Move("NAO", WS_ENCONTROU_RISCO);

                    /*" -9448- ELSE */
                }
                else
                {


                    /*" -9449- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -9451- DISPLAY '          ERRO NA CHAMADA SPBVG009 ' LK-VG009-IND-ERRO */
                    _.Display($"          ERRO NA CHAMADA SPBVG009 {SPVG009W.LK_VG009_IND_ERRO}");

                    /*" -9453- DISPLAY '          NUMERO PROPOSTA ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -9454- DISPLAY '          NOME TABELA ' LK-VG009-NOM-TABELA */
                    _.Display($"          NOME TABELA {SPVG009W.LK_VG009_NOM_TABELA}");

                    /*" -9455- DISPLAY '          SQLCODE ' LK-VG009-SQLCODE */
                    _.Display($"          SQLCODE {SPVG009W.LK_VG009_SQLCODE}");

                    /*" -9456- DISPLAY '          SQLERRMC ' LK-VG009-SQLERRMC */
                    _.Display($"          SQLERRMC {SPVG009W.LK_VG009_SQLERRMC}");

                    /*" -9457- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -9458- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -9459- END-IF */
                }


                /*" -9460- END-IF */
            }


            /*" -9460- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7950_99_EXIT*/

        [StopWatch]
        /*" R8230-00-PLANO-SEM-DATA-SECTION */
        private void R8230_00_PLANO_SEM_DATA_SECTION()
        {
            /*" -9468- MOVE 'R8230-00-PLANO-SEM-DATA' TO PARAGRAFO */
            _.Move("R8230-00-PLANO-SEM-DATA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9469- MOVE 'ENCONTRAR PLANO SEM DATA ' TO COMANDO */
            _.Move("ENCONTRAR PLANO SEM DATA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9472- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9486- PERFORM R8230_00_PLANO_SEM_DATA_DB_SELECT_1 */

            R8230_00_PLANO_SEM_DATA_DB_SELECT_1();

            /*" -9489-  EVALUATE SQLCODE  */

            /*" -9490-  WHEN ZEROS  */

            /*" -9490- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -9498- DISPLAY '> ACESSO SEM DATA PROP/QUIT: ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '/' VG130-NUM-APOLICE '/' VG130-COD-SUBGRUPO '/' WHOST-OPCAO-COBER '/' WHOST-IDADE '/' WHOST-PRM-TOTAL-MA */

                $"> ACESSO SEM DATA PROP/QUIT: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}/{WHOST_OPCAO_COBER}/{WHOST_IDADE}/{WHOST_PRM_TOTAL_MA}"
                .Display();

                /*" -9499-  WHEN OTHER  */

                /*" -9499- ELSE */
            }
            else
            {


                /*" -9500- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -9501- DISPLAY ' ERRO NO ACESSO A PLANOS_VA_VGAP - R8230 ' */
                _.Display($" ERRO NO ACESSO A PLANOS_VA_VGAP - R8230 ");

                /*" -9503- DISPLAY 'NUMERO DA PROPOSTA ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO DA PROPOSTA {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -9504- DISPLAY 'NUMERO DA APOLICE  ' VG130-NUM-APOLICE */
                _.Display($"NUMERO DA APOLICE  {VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}");

                /*" -9505- DISPLAY 'CODIGO DO SUBGRUPO ' VG130-COD-SUBGRUPO */
                _.Display($"CODIGO DO SUBGRUPO {VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}");

                /*" -9506- DISPLAY 'OPCAO DE COBERTURA ' WHOST-OPCAO-COBER */
                _.Display($"OPCAO DE COBERTURA {WHOST_OPCAO_COBER}");

                /*" -9507- DISPLAY 'IDADE              ' WHOST-IDADE */
                _.Display($"IDADE              {WHOST_IDADE}");

                /*" -9508- DISPLAY 'VALOR PREMIO PROP. ' WHOST-PRM-TOTAL-MA */
                _.Display($"VALOR PREMIO PROP. {WHOST_PRM_TOTAL_MA}");

                /*" -9509- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -9510- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9512-  END-EVALUATE  */

                /*" -9512- END-IF */
            }


            /*" -9512- . */

        }

        [StopWatch]
        /*" R8230-00-PLANO-SEM-DATA-DB-SELECT-1 */
        public void R8230_00_PLANO_SEM_DATA_DB_SELECT_1()
        {
            /*" -9486- EXEC SQL SELECT NUM_APOLICE , CODSUBES , VLPREMIOTOT INTO :WHOST-APOLICE-PLANO , :WHOST-CODSUBES-PLANO , :PLAVAVGA-VLPREMIOTOT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :VG130-NUM-APOLICE AND CODSUBES = :VG130-COD-SUBGRUPO AND OPCAO_COBER = :WHOST-OPCAO-COBER AND :WHOST-IDADE BETWEEN IDADE_INICIAL AND IDADE_FINAL AND VLPREMIOTOT = :WHOST-PRM-TOTAL-MA END-EXEC */

            var r8230_00_PLANO_SEM_DATA_DB_SELECT_1_Query1 = new R8230_00_PLANO_SEM_DATA_DB_SELECT_1_Query1()
            {
                VG130_COD_SUBGRUPO = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO.ToString(),
                WHOST_PRM_TOTAL_MA = WHOST_PRM_TOTAL_MA.ToString(),
                VG130_NUM_APOLICE = VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE.ToString(),
                WHOST_OPCAO_COBER = WHOST_OPCAO_COBER.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R8230_00_PLANO_SEM_DATA_DB_SELECT_1_Query1.Execute(r8230_00_PLANO_SEM_DATA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_APOLICE_PLANO, WHOST_APOLICE_PLANO);
                _.Move(executed_1.WHOST_CODSUBES_PLANO, WHOST_CODSUBES_PLANO);
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8230_99_SAIDA*/

        [StopWatch]
        /*" R8240-00-PLANO-SEM-PREMIO-SECTION */
        private void R8240_00_PLANO_SEM_PREMIO_SECTION()
        {
            /*" -9518- MOVE 'R8240-00-PLANO-SEM-PREMIO' TO PARAGRAFO */
            _.Move("R8240-00-PLANO-SEM-PREMIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9519- MOVE 'ENCONTRAR PLANO SEM DATA ' TO COMANDO */
            _.Move("ENCONTRAR PLANO SEM DATA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9522- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9535- PERFORM R8240_00_PLANO_SEM_PREMIO_DB_SELECT_1 */

            R8240_00_PLANO_SEM_PREMIO_DB_SELECT_1();

            /*" -9538-  EVALUATE SQLCODE  */

            /*" -9539-  WHEN ZEROS  */

            /*" -9539- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -9547- DISPLAY '> ACESSO SEM PREMIO: ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '/' VG130-NUM-APOLICE '/' VG130-COD-SUBGRUPO '/' WHOST-OPCAO-COBER '/' WHOST-IDADE '/' WHOST-PRM-TOTAL-MA */

                $"> ACESSO SEM PREMIO: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}/{WHOST_OPCAO_COBER}/{WHOST_IDADE}/{WHOST_PRM_TOTAL_MA}"
                .Display();

                /*" -9548-  WHEN OTHER  */

                /*" -9548- ELSE */
            }
            else
            {


                /*" -9549- DISPLAY 'VA0600B - FIM ANORMAL' */
                _.Display($"VA0600B - FIM ANORMAL");

                /*" -9550- DISPLAY ' ERRO NO ACESSO A PLANOS_VA_VGAP - R8240 ' */
                _.Display($" ERRO NO ACESSO A PLANOS_VA_VGAP - R8240 ");

                /*" -9552- DISPLAY 'NUMERO DA PROPOSTA ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUMERO DA PROPOSTA {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -9553- DISPLAY 'NUMERO DA APOLICE  ' VG130-NUM-APOLICE */
                _.Display($"NUMERO DA APOLICE  {VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE}");

                /*" -9554- DISPLAY 'CODIGO DO SUBGRUPO ' VG130-COD-SUBGRUPO */
                _.Display($"CODIGO DO SUBGRUPO {VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO}");

                /*" -9555- DISPLAY 'OPCAO DE COBERTURA ' WHOST-OPCAO-COBER */
                _.Display($"OPCAO DE COBERTURA {WHOST_OPCAO_COBER}");

                /*" -9556- DISPLAY 'IDADE              ' WHOST-IDADE */
                _.Display($"IDADE              {WHOST_IDADE}");

                /*" -9557- DISPLAY 'VALOR PREMIO PROP. ' WHOST-PRM-TOTAL-MA */
                _.Display($"VALOR PREMIO PROP. {WHOST_PRM_TOTAL_MA}");

                /*" -9558- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -9559- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9561-  END-EVALUATE  */

                /*" -9561- END-IF */
            }


            /*" -9561- . */

        }

        [StopWatch]
        /*" R8240-00-PLANO-SEM-PREMIO-DB-SELECT-1 */
        public void R8240_00_PLANO_SEM_PREMIO_DB_SELECT_1()
        {
            /*" -9535- EXEC SQL SELECT NUM_APOLICE , CODSUBES , VLPREMIOTOT INTO :WHOST-APOLICE-PLANO , :WHOST-CODSUBES-PLANO , :PLAVAVGA-VLPREMIOTOT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :VG130-NUM-APOLICE AND CODSUBES = :VG130-COD-SUBGRUPO AND OPCAO_COBER = :WHOST-OPCAO-COBER AND :WHOST-IDADE BETWEEN IDADE_INICIAL AND IDADE_FINAL END-EXEC */

            var r8240_00_PLANO_SEM_PREMIO_DB_SELECT_1_Query1 = new R8240_00_PLANO_SEM_PREMIO_DB_SELECT_1_Query1()
            {
                VG130_COD_SUBGRUPO = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_SUBGRUPO.ToString(),
                VG130_NUM_APOLICE = VG130.DCLVG_PLANO_SUBGRUPO.VG130_NUM_APOLICE.ToString(),
                WHOST_OPCAO_COBER = WHOST_OPCAO_COBER.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R8240_00_PLANO_SEM_PREMIO_DB_SELECT_1_Query1.Execute(r8240_00_PLANO_SEM_PREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_APOLICE_PLANO, WHOST_APOLICE_PLANO);
                _.Move(executed_1.WHOST_CODSUBES_PLANO, WHOST_CODSUBES_PLANO);
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8240_99_SAIDA*/

        [StopWatch]
        /*" R9970-00-TRATAR-PROPOSTA-SECTION */
        private void R9970_00_TRATAR_PROPOSTA_SECTION()
        {
            /*" -9567- MOVE 'R9970-00-TRATAR-PROPOSTA' TO PARAGRAFO. */
            _.Move("R9970-00-TRATAR-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9568- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9571- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO R3-NUM-SICOB OF REG-PROPOSTA-SASSE */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB);

            /*" -9573- MOVE 1 TO W-CRITICA-PROPOSTA */
            _.Move(1, WREA88.W_CRITICA_PROPOSTA);

            /*" -9575- PERFORM R9971-LER-RCAP */

            R9971_LER_RCAP_SECTION();

            /*" -9576- IF ENCONTROU-RCAP */

            if (WREA88.W_LEITURA_RCAP["ENCONTROU_RCAP"])
            {

                /*" -9577- PERFORM R0764-LER-RCAPCOMP */

                R0764_LER_RCAPCOMP_SECTION();

                /*" -9578- IF ENCONTROU-RCAPCOMP */

                if (WREA88.W_LEITURA_RCAPCOMP["ENCONTROU_RCAPCOMP"])
                {

                    /*" -9581- MOVE 'ENV' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE */
                    _.Move("ENV", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

                    /*" -9584- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE */
                    _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

                    /*" -9587- MOVE 00 TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE */
                    _.Move(00, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

                    /*" -9589- MOVE RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR TO W-DATA-SQL */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -9590- MOVE W-DIA-SQL TO W-DIA-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA);

                    /*" -9591- MOVE W-MES-SQL TO W-MES-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA);

                    /*" -9592- MOVE W-ANO-SQL TO W-ANO-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA);

                    /*" -9595- MOVE W-DATA-DDMMAAAA TO R3-DTQITBCO OF REG-PROPOSTA-SASSE */
                    _.Move(WAREA_AUXILIAR.W_DATA_DDMMAAAA, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                    /*" -9598- MOVE RCAPCOMP-DATA-MOVIMENTO OF DCLRCAP-COMPLEMENTAR TO W-DATA-SQL */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -9599- MOVE W-DIA-SQL TO W-DIA-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA);

                    /*" -9600- MOVE W-MES-SQL TO W-MES-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA);

                    /*" -9601- MOVE W-ANO-SQL TO W-ANO-DDMMAAAA */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA);

                    /*" -9604- MOVE W-DATA-DDMMAAAA TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE */
                    _.Move(WAREA_AUXILIAR.W_DATA_DDMMAAAA, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                    /*" -9607- MOVE RCAPCOMP-VAL-RCAP OF DCLRCAP-COMPLEMENTAR TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                    /*" -9609- MOVE RCAPS-AGE-COBRANCA OF DCLRCAPS TO R3-AGEPGTO OF REG-PROPOSTA-SASSE */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

                    /*" -9610- ELSE */
                }
                else
                {


                    /*" -9613- MOVE 'POB' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE */
                    _.Move("POB", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

                    /*" -9616- MOVE 'SUS' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE */
                    _.Move("SUS", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

                    /*" -9619- MOVE ZEROS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                    /*" -9622- MOVE 001 TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE */
                    _.Move(001, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

                    /*" -9625- MOVE '01010001' TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE, R3-DTQITBCO OF REG-PROPOSTA-SASSE */
                    _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                    /*" -9626- ELSE */
                }

            }
            else
            {


                /*" -9629- MOVE 'POB' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Move("POB", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

                /*" -9632- MOVE 'SUS' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE */
                _.Move("SUS", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

                /*" -9635- MOVE ZEROS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                /*" -9638- MOVE 001 TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE */
                _.Move(001, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

                /*" -9642- MOVE '01010001' TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE, R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
                _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);
            }


            /*" -9643- IF R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE NOT EQUAL 'POB' */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA != "POB")
            {

                /*" -9643- PERFORM R9985-00-ATUALIZAR-DADOS-SISPF. */

                R9985_00_ATUALIZAR_DADOS_SISPF_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9970_SAIDA*/

        [StopWatch]
        /*" R9971-LER-RCAP-SECTION */
        private void R9971_LER_RCAP_SECTION()
        {
            /*" -9650- MOVE 'R9971-LER-RCAP' TO PARAGRAFO. */
            _.Move("R9971-LER-RCAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9651- MOVE 'SELECT RCAP' TO COMANDO. */
            _.Move("SELECT RCAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9654- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO RCAPS-NUM-CERTIFICADO OF DCLRCAPS. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -9667- PERFORM R9971_LER_RCAP_DB_SELECT_1 */

            R9971_LER_RCAP_DB_SELECT_1();

            /*" -9670- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -9672- MOVE 1 TO W-LEITURA-RCAP */
                _.Move(1, WREA88.W_LEITURA_RCAP);

                /*" -9673- IF VIND-RCAPS-AGE LESS ZERO */

                if (VIND_RCAPS_AGE < 00)
                {

                    /*" -9674- MOVE ZEROS TO RCAPS-AGE-COBRANCA OF DCLRCAPS */
                    _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);

                    /*" -9675- END-IF */
                }


                /*" -9676- ELSE */
            }
            else
            {


                /*" -9677- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9678- MOVE 2 TO W-LEITURA-RCAP */
                    _.Move(2, WREA88.W_LEITURA_RCAP);

                    /*" -9679- ELSE */
                }
                else
                {


                    /*" -9680- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -9681- MOVE 1 TO W-LEITURA-RCAP */
                        _.Move(1, WREA88.W_LEITURA_RCAP);

                        /*" -9682- ELSE */
                    }
                    else
                    {


                        /*" -9683- DISPLAY 'VA0600B - FIM ANORMAL' */
                        _.Display($"VA0600B - FIM ANORMAL");

                        /*" -9684- DISPLAY '          ERRO LEITURA RCAP ' SQLCODE */
                        _.Display($"          ERRO LEITURA RCAP {DB.SQLCODE}");

                        /*" -9686- DISPLAY '          NUMERO PROPOSTA   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                        _.Display($"          NUMERO PROPOSTA   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                        /*" -9687- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -9687- GO TO R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R9971-LER-RCAP-DB-SELECT-1 */
        public void R9971_LER_RCAP_DB_SELECT_1()
        {
            /*" -9667- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP, AGE_COBRANCA INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLRCAPS.RCAPS-AGE-COBRANCA:VIND-RCAPS-AGE FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO =:DCLRCAPS.RCAPS-NUM-CERTIFICADO AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r9971_LER_RCAP_DB_SELECT_1_Query1 = new R9971_LER_RCAP_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R9971_LER_RCAP_DB_SELECT_1_Query1.Execute(r9971_LER_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(executed_1.VIND_RCAPS_AGE, VIND_RCAPS_AGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9971_SAIDA*/

        [StopWatch]
        /*" R9978-00-VERIFICAR-PROPOSTA-SECTION */
        private void R9978_00_VERIFICAR_PROPOSTA_SECTION()
        {
            /*" -9694- MOVE 'R9978-00-VERIFICAR-PROPOSTA' TO PARAGRAFO. */
            _.Move("R9978-00-VERIFICAR-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9695- MOVE 'SELECT PROPOSTA_FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA_FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9698- MOVE REG-NUM-PROPOSTA OF REG-SIGAT TO PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(REG_SIGAT.REG_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -9716- PERFORM R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1 */

            R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1();

            /*" -9724- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -9725- MOVE 'SIM' TO W-EXISTE-PROPOSTA */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_PROPOSTA);

                /*" -9726- ELSE */
            }
            else
            {


                /*" -9727- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9728- MOVE 'NAO' TO W-EXISTE-PROPOSTA */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_PROPOSTA);

                    /*" -9729- ELSE */
                }
                else
                {


                    /*" -9730- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -9732- DISPLAY '          ERRO NO ACESSO A PROPOSTA-FIDELIZ  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          ERRO NO ACESSO A PROPOSTA-FIDELIZ  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -9733- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -9733- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R9978-00-VERIFICAR-PROPOSTA-DB-SELECT-1 */
        public void R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1()
        {
            /*" -9716- EXEC SQL SELECT NUM_IDENTIFICACAO , NUM_SICOB , DTQITBCO , VAL_PAGO , AGEPGTO , SIT_PROPOSTA , DATA_CREDITO INTO :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 = new R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1.Execute(r9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(executed_1.PROPOFID_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                _.Move(executed_1.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
                _.Move(executed_1.PROPOFID_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_DATA_CREDITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9978_SAIDA*/

        [StopWatch]
        /*" R9979-00-MONTA-TAB-CRITICA-SECTION */
        private void R9979_00_MONTA_TAB_CRITICA_SECTION()
        {
            /*" -9740- MOVE 'R9979-00-MONTA-TAB-CRITICA' TO PARAGRAFO. */
            _.Move("R9979-00-MONTA-TAB-CRITICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9741- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9742- IF W-INDICE-1 GREATER 1999 */

            if (WAREA_AUXILIAR.W_INDICE_1 > 1999)
            {

                /*" -9743- DISPLAY ' ' */
                _.Display($" ");

                /*" -9744- DISPLAY ' ' */
                _.Display($" ");

                /*" -9745- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -9746- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -9747- DISPLAY '//           PROGRAMA =>  VA0600B            //' */
                _.Display($"//           PROGRAMA =>  VA0600B            //");

                /*" -9748- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -9749- DISPLAY '//                 TERMINO                   //' */
                _.Display($"//                 TERMINO                   //");

                /*" -9750- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -9751- DISPLAY '//       ==>   A N O R M A L     <==         //' */
                _.Display($"//       ==>   A N O R M A L     <==         //");

                /*" -9752- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -9753- DISPLAY '//    ==> ESTOURO DA TABELA DE ERROS <==     //' */
                _.Display($"//    ==> ESTOURO DA TABELA DE ERROS <==     //");

                /*" -9754- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -9755- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -9756- DISPLAY ' ' */
                _.Display($" ");

                /*" -9757- DISPLAY ' ' */
                _.Display($" ");

                /*" -9758- DISPLAY 'VALOR DO INDICE     ' W-INDICE-1 */
                _.Display($"VALOR DO INDICE     {WAREA_AUXILIAR.W_INDICE_1}");

                /*" -9759- DISPLAY ' ' */
                _.Display($" ");

                /*" -9760- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -9761- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9763- END-IF */
            }


            /*" -9764- IF R3-NSAS OF REG-PROPOSTA-SASSE > ZEROS */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS > 00)
            {

                /*" -9766- MOVE R3-NSAS OF REG-PROPOSTA-SASSE TO W-TB-NSAS(W-INDICE-1) */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_NSAS);

                /*" -9767- ELSE */
            }
            else
            {


                /*" -9769- MOVE W-NSAS-FILIAL TO W-TB-NSAS(W-INDICE-1). */
                _.Move(WAREA_AUXILIAR.W_NSAS_FILIAL, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_NSAS);
            }


            /*" -9771- MOVE W-TP-MOVIMENTO TO W-TB-CANAL(W-INDICE-1) */
            _.Move(WREA88.W_TP_MOVIMENTO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_CANAL);

            /*" -9774- MOVE R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE TO W-TB-ORIGEM(W-INDICE-1) */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_ORIGEM);

            /*" -9775- IF MOVTO-SIVPF-FILIAL */

            if (WREA88.W_TP_MOVIMENTO["MOVTO_SIVPF_FILIAL"])
            {

                /*" -9776- IF ORIGEM-REMOTA */

                if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_REMOTA"])
                {

                    /*" -9778- MOVE 7 TO W-TB-ORIGEM(W-INDICE-1). */
                    _.Move(7, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_ORIGEM);
                }

            }


            /*" -9781- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO W-TB-NUM-PROPOSTA(W-INDICE-1) */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_NUM_PROPOSTA);

            /*" -9784- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO W-TB-SIT-PROPOSTA(W-INDICE-1) */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_SIT_PROPOSTA);

            /*" -9785- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-TB-DT-SITUACAO(W-INDICE-1). */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_1].W_TB_DT_SITUACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9979_SAIDA*/

        [StopWatch]
        /*" R9980-00-GERAR-RELATORIO-SECTION */
        private void R9980_00_GERAR_RELATORIO_SECTION()
        {
            /*" -9792- MOVE 'R9980-00-GERAR-RELATORIO' TO PARAGRAFO. */
            _.Move("R9980-00-GERAR-RELATORIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9793- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9795- OPEN OUTPUT RVA0600B */
            RVA0600B.Open(REG_RVA0600B);

            /*" -9798- MOVE '/' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -9800- MOVE W-DTMOVABE-I TO LC02-DATA. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE_I, LC00.LC02.LC02_DATA);

            /*" -9804- PERFORM R9981-00-INCONSISTENCIA VARYING W-INDICE-2 FROM 1 BY 1 UNTIL W-INDICE-2 GREATER W-INDICE-1. */

            for (WAREA_AUXILIAR.W_INDICE_2.Value = 1; !(WAREA_AUXILIAR.W_INDICE_2 > WAREA_AUXILIAR.W_INDICE_1); WAREA_AUXILIAR.W_INDICE_2.Value += 1)
            {

                R9981_00_INCONSISTENCIA_SECTION();
            }

            /*" -9804- CLOSE RVA0600B. */
            RVA0600B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9980_SAIDA*/

        [StopWatch]
        /*" R9981-00-INCONSISTENCIA-SECTION */
        private void R9981_00_INCONSISTENCIA_SECTION()
        {
            /*" -9811- MOVE 'R9981-00-INCONSISTENCIA' TO PARAGRAFO. */
            _.Move("R9981-00-INCONSISTENCIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9812- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9815- IF W-TB-NUM-PROPOSTA(W-INDICE-2) NOT NUMERIC OR W-TB-NUM-PROPOSTA(W-INDICE-2) EQUAL ZEROS */

            if (!AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_NUM_PROPOSTA.IsNumeric() || AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_NUM_PROPOSTA == 00)
            {

                /*" -9817- COMPUTE W-INDICE-2 = W-INDICE-1 + 1 */
                WAREA_AUXILIAR.W_INDICE_2.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                /*" -9819- GO TO R9981-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9981_SAIDA*/ //GOTO
                return;
            }


            /*" -9821- MOVE W-TB-NUM-PROPOSTA(W-INDICE-2) TO LC06-NUM-PROPOSTA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_NUM_PROPOSTA, LC00.LC06.LC06_NUM_PROPOSTA);

            /*" -9823- MOVE W-TB-SIT-PROPOSTA(W-INDICE-2) TO LC06-SITUACAO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_SIT_PROPOSTA, LC00.LC06.LC06_SITUACAO);

            /*" -9824- MOVE W-TB-DT-SITUACAO (W-INDICE-2) TO W-DATA-DDMMAAAA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_DT_SITUACAO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -9825- MOVE W-DIA-DDMMAAAA TO W-DIA-SITUACAO OF W-DATA-SIT-RD */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SIT_RD.W_DIA_SITUACAO);

            /*" -9826- MOVE W-MES-DDMMAAAA TO W-MES-SITUACAO OF W-DATA-SIT-RD */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SIT_RD.W_MES_SITUACAO);

            /*" -9827- MOVE W-ANO-DDMMAAAA TO W-ANO-SITUACAO OF W-DATA-SIT-RD */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SIT_RD.W_ANO_SITUACAO);

            /*" -9830- MOVE '/' TO W-BARRA1 OF W-DATA-SIT-RD W-BARRA2 OF W-DATA-SIT-RD. */
            _.Move("/", WAREA_AUXILIAR.W_DATA_SIT_RD.W_BARRA1_2);
            _.Move("/", WAREA_AUXILIAR.W_DATA_SIT_RD.W_BARRA2_2);


            /*" -9832- MOVE W-DATA-SITUACAO TO LC06-DATA-SITUACAO */
            _.Move(WAREA_AUXILIAR.W_DATA_SITUACAO, LC00.LC06.LC06_DATA_SITUACAO);

            /*" -9834- MOVE W-TB-ORIGEM(W-INDICE-2) TO W-INDICE-ERRO. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_ORIGEM, WAREA_AUXILIAR.W_INDICE_ERRO);

            /*" -9837- MOVE W-TB-DESCRI-ORIGEM(W-INDICE-ERRO) TO LC06-ORIGEM. */
            _.Move(AREA_DAS_TABELAS.W_TAB_ORIGEM_RD[WAREA_AUXILIAR.W_INDICE_ERRO].W_TB_DESCRI_ORIGEM, LC00.LC06.LC06_ORIGEM);

            /*" -9839- MOVE W-TB-COD-DESCRI (W-INDICE-2) TO W-INDICE-ERRO. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_COD_DESCRI, WAREA_AUXILIAR.W_INDICE_ERRO);

            /*" -9842- MOVE W-TB-DESCRI-ERRO(W-INDICE-ERRO) TO LC06-DESCRICAO. */
            _.Move(AREA_DAS_TABELAS.W_TAB_DESCRICAO_RD[WAREA_AUXILIAR.W_INDICE_ERRO].W_TB_DESCRI_ERRO, LC00.LC06.LC06_DESCRICAO);

            /*" -9845- IF W-CANAL-ANT EQUAL W-TB-CANAL(W-INDICE-2) AND W-NSAS-ANT EQUAL W-TB-NSAS (W-INDICE-2) NEXT SENTENCE */

            if (WAREA_AUXILIAR.W_CANAL_ANT == AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_CANAL && WAREA_AUXILIAR.W_NSAS_ANT == AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_NSAS)
            {

                /*" -9846- ELSE */
            }
            else
            {


                /*" -9847- PERFORM R9982-00-GRAVA-CABECALHO */

                R9982_00_GRAVA_CABECALHO_SECTION();

                /*" -9848- MOVE W-TB-CANAL (W-INDICE-2) TO W-CANAL-ANT */
                _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_CANAL, WAREA_AUXILIAR.W_CANAL_ANT);

                /*" -9850- MOVE W-TB-NSAS (W-INDICE-2) TO W-NSAS-ANT. */
                _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_NSAS, WAREA_AUXILIAR.W_NSAS_ANT);
            }


            /*" -9851- IF W-CONT-LINHAS GREATER 60 */

            if (WAREA_AUXILIAR.W_CONT_LINHAS > 60)
            {

                /*" -9853- PERFORM R9982-00-GRAVA-CABECALHO. */

                R9982_00_GRAVA_CABECALHO_SECTION();
            }


            /*" -9855- WRITE REG-RVA0600B FROM LC06 AFTER 1. */
            _.Move(LC00.LC06.GetMoveValues(), REG_RVA0600B);

            RVA0600B.Write(REG_RVA0600B.GetMoveValues().ToString());

            /*" -9855- ADD 1 TO W-CONT-LINHAS. */
            WAREA_AUXILIAR.W_CONT_LINHAS.Value = WAREA_AUXILIAR.W_CONT_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9981_SAIDA*/

        [StopWatch]
        /*" R9982-00-GRAVA-CABECALHO-SECTION */
        private void R9982_00_GRAVA_CABECALHO_SECTION()
        {
            /*" -9862- MOVE 'R9982-00-GRAVA-CABECALHO' TO PARAGRAFO. */
            _.Move("R9982-00-GRAVA-CABECALHO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9864- MOVE 'WRITE' TO COMANDO. */
            _.Move("WRITE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9866- ADD 1 TO LC01-PAGINA. */
            LC00.LC01.LC01_PAGINA.Value = LC00.LC01.LC01_PAGINA + 1;

            /*" -9868- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -9869- MOVE WS-TIME-N TO WS-TIME-EDIT */
            _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

            /*" -9871- MOVE WS-TIME-EDIT TO LC03-HORA. */
            _.Move(WS_TIME_EDIT, LC00.LC03.LC03_HORA);

            /*" -9873- MOVE W-TB-CANAL(W-INDICE-2) TO W-INDICE-ERRO. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_CANAL, WAREA_AUXILIAR.W_INDICE_ERRO);

            /*" -9876- MOVE W-TB-DESCRI-CANAL(W-INDICE-ERRO) TO LC03-CANAL. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CANAL_RD[WAREA_AUXILIAR.W_INDICE_ERRO].W_TB_DESCRI_CANAL, LC00.LC03.LC03_CANAL);

            /*" -9878- MOVE W-TB-NSAS(W-INDICE-2) TO LC04-NSAS-SIVPF. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_65[WAREA_AUXILIAR.W_INDICE_2].W_TB_NSAS, LC00.LC04.LC04_NSAS_SIVPF);

            /*" -9879- MOVE RH-DATA-GERACAO OF REG-HEADER TO W-DATA-DDMMAAAA */
            _.Move(LBFPF990.REG_HEADER.RH_DATA_GERACAO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

            /*" -9880- MOVE W-DIA-DDMMAAAA TO W-DIA-MOVABE OF W-DTMOVABE-I1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -9881- MOVE W-MES-DDMMAAAA TO W-MES-MOVABE OF W-DTMOVABE-I1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -9883- MOVE W-ANO-DDMMAAAA TO W-ANO-MOVABE OF W-DTMOVABE-I1 */
            _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -9885- MOVE W-DTMOVABE-I TO LC04-DATA-GERACAO. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE_I, LC00.LC04.LC04_DATA_GERACAO);

            /*" -9886- WRITE REG-RVA0600B FROM LC01 AFTER PAGE. */
            _.Move(LC00.LC01.GetMoveValues(), REG_RVA0600B);

            RVA0600B.Write(REG_RVA0600B.GetMoveValues().ToString());

            /*" -9887- WRITE REG-RVA0600B FROM LC02 AFTER 1 */
            _.Move(LC00.LC02.GetMoveValues(), REG_RVA0600B);

            RVA0600B.Write(REG_RVA0600B.GetMoveValues().ToString());

            /*" -9888- WRITE REG-RVA0600B FROM LC03 AFTER 1 */
            _.Move(LC00.LC03.GetMoveValues(), REG_RVA0600B);

            RVA0600B.Write(REG_RVA0600B.GetMoveValues().ToString());

            /*" -9889- WRITE REG-RVA0600B FROM LC04 AFTER 2 */
            _.Move(LC00.LC04.GetMoveValues(), REG_RVA0600B);

            RVA0600B.Write(REG_RVA0600B.GetMoveValues().ToString());

            /*" -9891- WRITE REG-RVA0600B FROM LC07 AFTER 1 */
            _.Move(LC00.LC07.GetMoveValues(), REG_RVA0600B);

            RVA0600B.Write(REG_RVA0600B.GetMoveValues().ToString());

            /*" -9893- WRITE REG-RVA0600B FROM LC05 AFTER 2. */
            _.Move(LC00.LC05.GetMoveValues(), REG_RVA0600B);

            RVA0600B.Write(REG_RVA0600B.GetMoveValues().ToString());

            /*" -9893- MOVE 8 TO W-CONT-LINHAS. */
            _.Move(8, WAREA_AUXILIAR.W_CONT_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9982_SAIDA*/

        [StopWatch]
        /*" R9983-00-LER-PROPOSTAVA-SECTION */
        private void R9983_00_LER_PROPOSTAVA_SECTION()
        {
            /*" -9900- MOVE 'R9983-00-LER-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R9983-00-LER-PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9901- MOVE 'SELECT PROPOSTAS_VA' TO COMANDO. */
            _.Move("SELECT PROPOSTAS_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9904- MOVE REG-NUM-PROPOSTA OF REG-SIGAT TO PROPOVA-NUM-CERTIFICADO OF DCLPROPOSTAS-VA. */
            _.Move(REG_SIGAT.REG_NUM_PROPOSTA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -9910- PERFORM R9983_00_LER_PROPOSTAVA_DB_SELECT_1 */

            R9983_00_LER_PROPOSTAVA_DB_SELECT_1();

            /*" -9913- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -9914- MOVE 'SIM' TO W-EXISTE-PROPOSTA */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_PROPOSTA);

                /*" -9915- ELSE */
            }
            else
            {


                /*" -9916- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9917- MOVE 'NAO' TO W-EXISTE-PROPOSTA */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_PROPOSTA);

                    /*" -9918- ELSE */
                }
                else
                {


                    /*" -9919- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -9920- DISPLAY '          PROBLEMAS NO ACESSO A PROPOSTA-VA' */
                    _.Display($"          PROBLEMAS NO ACESSO A PROPOSTA-VA");

                    /*" -9922- DISPLAY '          NUMERO DO CERTIFICADO........... ' PROPOVA-NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                    _.Display($"          NUMERO DO CERTIFICADO........... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -9923- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -9923- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R9983-00-LER-PROPOSTAVA-DB-SELECT-1 */
        public void R9983_00_LER_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -9910- EXEC SQL SELECT SIT_REGISTRO INTO :DCLPROPOSTAS-VA.PROPOVA-SIT-REGISTRO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 = new R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9983_SAIDA*/

        [StopWatch]
        /*" R9984-00-LER-BILHETE-SECTION */
        private void R9984_00_LER_BILHETE_SECTION()
        {
            /*" -9930- MOVE 'R9984-00-LER-BILHETE' TO PARAGRAFO. */
            _.Move("R9984-00-LER-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9931- MOVE 'SELECT BILHETE' TO COMANDO. */
            _.Move("SELECT BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9934- MOVE REG-NUM-PROPOSTA OF REG-SIGAT TO BILHETE-NUM-BILHETE OF DCLBILHETE. */
            _.Move(REG_SIGAT.REG_NUM_PROPOSTA, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);

            /*" -9940- PERFORM R9984_00_LER_BILHETE_DB_SELECT_1 */

            R9984_00_LER_BILHETE_DB_SELECT_1();

            /*" -9943- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -9944- MOVE 'SIM' TO W-EXISTE-PROPOSTA */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_PROPOSTA);

                /*" -9945- ELSE */
            }
            else
            {


                /*" -9946- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9947- MOVE 'NAO' TO W-EXISTE-PROPOSTA */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_PROPOSTA);

                    /*" -9948- ELSE */
                }
                else
                {


                    /*" -9949- DISPLAY 'VA0600B - PROBLEMAS NO ACESSO A BILHETE' */
                    _.Display($"VA0600B - PROBLEMAS NO ACESSO A BILHETE");

                    /*" -9951- DISPLAY '          NUMERO DO BILHETE........... ' BILHETE-NUM-BILHETE OF DCLBILHETE */
                    _.Display($"          NUMERO DO BILHETE........... {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -9952- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -9952- GO TO R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R9984-00-LER-BILHETE-DB-SELECT-1 */
        public void R9984_00_LER_BILHETE_DB_SELECT_1()
        {
            /*" -9940- EXEC SQL SELECT SITUACAO INTO :DCLBILHETE.BILHETE-SITUACAO FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :DCLBILHETE.BILHETE-NUM-BILHETE END-EXEC. */

            var r9984_00_LER_BILHETE_DB_SELECT_1_Query1 = new R9984_00_LER_BILHETE_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R9984_00_LER_BILHETE_DB_SELECT_1_Query1.Execute(r9984_00_LER_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9984_SAIDA*/

        [StopWatch]
        /*" R9985-00-ATUALIZAR-DADOS-SISPF-SECTION */
        private void R9985_00_ATUALIZAR_DADOS_SISPF_SECTION()
        {
            /*" -9965- MOVE 'R9985-00-ATUALIZAR-DADOS-SISPF' TO PARAGRAFO. */
            _.Move("R9985-00-ATUALIZAR-DADOS-SISPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9967- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9969- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9972- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -9975- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -9976- IF PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ = '0001-01-01' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO == "0001-01-01")
            {

                /*" -9979- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-DDMMAAAA */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

                /*" -9981- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -9983- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -9986- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -9990- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -9993- MOVE W-DATA-SQL TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
            }


            /*" -9994- IF PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ EQUAL ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO == 00)
            {

                /*" -9997- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
            }


            /*" -9998- IF PROPOFID-AGEPGTO OF DCLPROPOSTA-FIDELIZ EQUAL ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO == 00)
            {

                /*" -10001- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO PROPOFID-AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);
            }


            /*" -10003- IF PROPOFID-DATA-CREDITO OF DCLPROPOSTA-FIDELIZ = '0001-01-01' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO == "0001-01-01")
            {

                /*" -10006- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-DDMMAAAA */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_DDMMAAAA);

                /*" -10008- MOVE W-DIA-DDMMAAAA TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_DIA_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -10010- MOVE W-MES-DDMMAAAA TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_MES_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -10013- MOVE W-ANO-DDMMAAAA TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_18.W_ANO_DDMMAAAA, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -10017- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -10020- MOVE W-DATA-SQL TO PROPOFID-DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);
            }


            /*" -10023- MOVE 'VA0600B' TO PROPOFID-COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("VA0600B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -10041- PERFORM R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1 */

            R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1();

            /*" -10044- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -10045- DISPLAY 'VA0600B - PROBLEMAS NO UPDATE PROPOSTA-FIDELIZ ' */
                _.Display($"VA0600B - PROBLEMAS NO UPDATE PROPOSTA-FIDELIZ ");

                /*" -10047- DISPLAY '          NUMERO DA PROPOSTA.................. ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO DA PROPOSTA.................. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -10049- DISPLAY '          SQLCODE............................. ' SQLCODE */
                _.Display($"          SQLCODE............................. {DB.SQLCODE}");

                /*" -10050- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -10052- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -10054- MOVE REG-PROPOSTA-SASSE TO REG-SIGAT. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE, REG_SIGAT);

        }

        [StopWatch]
        /*" R9985-00-ATUALIZAR-DADOS-SISPF-DB-UPDATE-1 */
        public void R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1()
        {
            /*" -10041- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DTQITBCO = :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , DATA_CREDITO = :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO , AGEPGTO = :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO , SIT_PROPOSTA = :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA , VAL_PAGO = :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO , SITUACAO_ENVIO = :DCLPROPOSTA-FIDELIZ.PROPOFID-SITUACAO-ENVIO, COD_USUARIO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-USUARIO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1 = new R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1()
            {
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_DATA_CREDITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PROPOFID_AGEPGTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1.Execute(r9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9985_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -10060- CLOSE MOV-SIGAT. */
            MOV_SIGAT.Close();

            /*" -10060- CLOSE MOV-VDEMP. */
            MOV_VDEMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -10068- DISPLAY ' ' */
            _.Display($" ");

            /*" -10069- IF W-FIM-MOVTO-SIGAT = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM")
            {

                /*" -10070- DISPLAY 'VA0600B - FIM NORMAL' */
                _.Display($"VA0600B - FIM NORMAL");

                /*" -10072- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -10072- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -10075- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -10076- ELSE */
            }
            else
            {


                /*" -10077- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_21.WSQLCODE);

                /*" -10078- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_21.WSQLERRD1);

                /*" -10079- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_21.WSQLERRD2);

                /*" -10080- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, WABEND.WSQLERRO.WSQLERRMC);

                /*" -10082- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -10084- DISPLAY '*** VA0600B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** VA0600B *** ROLLBACK EM ANDAMENTO ...");

                /*" -10084- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -10087- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -10087- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}