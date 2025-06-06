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
using Sias.Outros.DB2.FI0100S;

namespace Code
{
    public class FI0100S
    {
        public bool IsCall { get; set; }

        public FI0100S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  FINANCEIRO                         *      */
        /*"      *   SUBROTINA ..............  FI0100S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADORA...  LIGIA                              *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL/1998                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CALCULO DOS IMPOSTOS ISS/IRF/INSS/ *      */
        /*"      *                             COFINS                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * VERSAO  : 004                                                  *      */
        /*"      * TAREFA  : 602884                                               *      */
        /*"      * DATA    : 17/10/2024                                           *      */
        /*"      * NOME    : HERVAL SOUZA                                         *      */
        /*"      * MARCADOR: V.04                                                 *      */
        /*"      * MOTIVO  : CORRIGIR DISPLAY EXCESSIVO DA VERS�O                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * VERSAO  : 003                                                  *      */
        /*"      * TAREFA  : 247980                                               *      */
        /*"      * DATA    : 16/06/2020                                           *      */
        /*"      * NOME    : HERVAL SOUZA                                         *      */
        /*"      * MARCADOR: V.03                                                 *      */
        /*"      * MOTIVO  : CVP - INCLUIR NA PESQUISA DA CEPFAIXAFILIAL O CODIGO *      */
        /*"      *           DA EMPRES BASEADO NA INFORMACAO DO PRODUTO           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 2                                                    *      */
        /*"      * MOTIVO  : EXCLUIR O BLOQUEIO DE RETENCAO DE COFINS NOS PAGTO DO*      */
        /*"      *           PRESTADOR 2766041- BING MULLER ADVOGADOS ASSOCIADOS  *      */
        /*"      * CADMUS  : 141354                                               *      */
        /*"      * DATA    : 29/08/2016                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.2                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIGIA 08/02/95 : ACESSA RENDIMENTO E IMPOSTOS       *      */
        /*"      *                             COM SITUACAO "0" OU "1"            *      */
        /*"      *  ALTERACAO LIGIA 06/06/95 : SOH CALCULA NUMERO DO RECIBO       *      */
        /*"      *                             PARA FORNECEDOR E PRODUTOR         *      */
        /*"      *                             PROCURAR LG0695 NO COMENTARIO      *      */
        /*"      *  ALTERACAO EDER  06/10/95 : NO CALCULO DO ISS DO PRODUTOR/FOR- *      */
        /*"      *                             NECEDOR SERA OBTIDO O PERC. DE DES-*      */
        /*"      *                             CONTO A PARTIR DA TAB. FONTE E NAO *      */
        /*"      *                             MAIS DAS TAB. PRODUTOR/FORNECEDOR. *      */
        /*"      *  ALTERACAO LIGIA 18/01/96 : O CALCULO DO ISS SOH SERAH FEITO   *      */
        /*"      *                             PARA PRESTADORES DE SERVICO        *      */
        /*"      *                             SEM INSCRICAO NA PREFEITURA        *      */
        /*"      *                             OU QUE NAO ESTEJAM ALUGANDO        *      */
        /*"      *                             IMOVEIS PARA A SASSE               *      */
        /*"      *                             PROCURAR LG0196 NO COMENTARIO      *      */
        /*"      *  ALTERACAO BARAN 14/05/96 : NAO DESCONTAR ISS PARA PESSOA 'J'  *      */
        /*"      *  ALTERACAO LIGIA 02/09/96 : NAO DESCONTAR ISS PARA PRODUTOR    *      */
        /*"      *                             PESSOA 'J'                         *      */
        /*"      *                             PROCURAR LG0996 NO COMENTARIO      *      */
        /*"      *  ALTERACAO BARAN 17/07/97 : SE A FONTE FOR 25(UBERLANDIA)      *      */
        /*"      *                             SEMPRE SERA' RETIDO ISS            *      */
        /*"      *                             PROCURAR BR0797 NO COMENTARIO      *      */
        /*"      *  ALTERACAO LIGIA 17/09/97 : IMPLEMENTACAO DE:                  *      */
        /*"      *  PROCURAR LG0997            TRIBUTACAO DIFERENCIADA            *      */
        /*"      *                             - PARA CALCULO DO VALOR DO ISS     *      */
        /*"      *                               UTILIZAR SEMPRE O PERCENTUAL     *      */
        /*"      *                               INFORMADO NO CADASTRAMENTO DA OP *      */
        /*"      *                             - PARA CALCULO DO VALOR DO IRF     *      */
        /*"      *                               UTILIZAR O PERCENTUAL INFORMADO  *      */
        /*"      *                               NO CADASTRAMENTO DA OP   OU      *      */
        /*"      *                               UTILIZAR O PERCENTUAL DA TABELA  *      */
        /*"      *                               PROGRESSIVA QUANDO NAO INFORMADO *      */
        /*"      *                               NO CADASTRAMENTO DA OP           *      */
        /*"      *                               SE A FONTE FOR 23(MS)            *      */
        /*"      *                               SEMPRE SERA' RETIDO ISS          *      */
        /*"      *  ALTERACAO LIGIA 03/11/97 : BUSCA O PERCENTUAL DE ISS DA FONTE *      */
        /*"      *  PROCURAR LG1197            PARA ORDENS CADASTRADAS ANTES   DE *      */
        /*"      *                             04/11/97                           *      */
        /*"      *  ALTERACAO LIGIA 28/01/98 :   SE A FONTE FOR 11(MATO GROSSO)   *      */
        /*"      *  PROCURAR LG0198              SEMPRE SERA' RETIDO ISS          *      */
        /*"      *  ALTERACAO LIGIA 27/03/98 :   SE A FONTE FOR 06(CEARA)         *      */
        /*"      *  PROCURAR LG0398              SEMPRE SERA' RETIDO ISS          *      */
        /*"      *                               SE A FONTE FOR 11(MATO GROSSO)   *      */
        /*"      *  ALTERACAO LIGIA 08/05/98 : NAO RETEM ISS DOS INSCRITOS        *      */
        /*"      *  PROCURAR LG0598            NA PREFEITURA                      *      */
        /*"      *  ALTERACAO LIGIA 28/05/98 : CALCULA IMPOSTOS SOBRE             *      */
        /*"      *  PROCURAR SI0598            HONORARIOS DE SINISTROS SOMENTE    *      */
        /*"      *                             PARA PRESTADORES DE SERVICOS       *      */
        /*"      *                             (TIPREG=3)                         *      */
        /*"      * CONVERTE  ANO 2000              CONSEDA4           10/06/1998  *      */
        /*"      *  ALTERACAO LIGIA 16/11/98 :   SE A FONTE FOR 01(RIO DE JANEIRO)*      */
        /*"      *  PROCURAR LG1198              SEMPRE SERA' RETIDO ISS          *      */
        /*"      *  ALTERACAO LIGIA 02/12/98 :   SE A FONTE=05 (DISTRITO FEDERAL) *      */
        /*"      *                                      OU  10 (MATRIZ)           *      */
        /*"      *  PROCURAR LG1298              SEMPRE SERA' RETIDO ISS          *      */
        /*"      *  ALTERACAO LIGIA 01/02/99 : 1)INCLUI RENDIMENTO PARA PES. FIS. *      */
        /*"      *            PROCURAR LG0199    QUE NAO ATINGIU A FAIXA DA TAB.  *      */
        /*"      *                               PROGRESSIVA                      *      */
        /*"      *                             2)INCLUI RENDIMENTO COM CODSVI=2222*      */
        /*"      *                               QUANDO HOUVER TRIBUTACAO DE ISS  *      */
        /*"      *                               SEM TRIBUTACAO DE IRF NA         *      */
        /*"      *                               ORDEM DE PAGAMENTO               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIGIA 05/04/99 : - DEDUCAO POR DEPENDENTE NO CALCULO*      */
        /*"      *            PROCURAR LG0499    DO IMPOSTO DE RENDA PESSOA FISICA*      */
        /*"      *                             - INCLUSAO DO DESCONTO DO INSS     *      */
        /*"      *                             - SE A FONTE FOR 21(SAO PAULO)     *      */
        /*"      *                               SEMPRE SERA' RETIDO ISS          *      */
        /*"      *                             - INCLUI RENDIMENTO COM CODSVI=5555*      */
        /*"      *                               QUANDO HOUVER SOMENTE TRIBUTACAO *      */
        /*"      *                               DO INSS SEM TRIBUTACAO DE IRF NA *      */
        /*"      *                               ORDEM DE PAGAMENTO               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO OLIVEIRA 31/08/99- DESCONTO DO ISS PARA FONTE 16(PE)*      */
        /*"      *            PROCURAR OL0899    CONFORME ME-170/99 (16/08/99)  E *      */
        /*"      *                             - LEI 16.474/99                    *      */
        /*"      *                             - SE A FONTE FOR 16(RECIFE - PE)   *      */
        /*"      *                               RETER O ISS A ALIQUOTA DE 5%     *      */
        /*"      *                             - INCLUI PRESTADORES DE SVC COM OU *      */
        /*"      *                               SEM INSCRICAO NA PREFEITURA      *      */
        /*"      *                             - SOMENTE PESSOA JURIDICA          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIGIA 14/03/2000: -SE A FONTE FOR 04(BAHIA)         *      */
        /*"      *  PROCURAR LG0300              SEMPRE SERA' RETIDO ISS          *      */
        /*"      *                              -RESGATE DE PREVIDENCIA(3223)     *      */
        /*"      *                               EH ISENTO DE ISS                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIANE 31/03/2000: -INCLUIDO COD-EMPRESA NO PARAMETRO*      */
        /*"      *  PROCURAR LP0300              DE CHAMADA DA SUBROTINA FI0100S. *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIGIA 13/04/2000: - DISPLAY NOS TESTES DE SQLCOLDE  *      */
        /*"      *  PROCURAR LG0400                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIGIA 08/05/2000: - SE A FONTE FOR 16(RECIFE - PE)  *      */
        /*"      *  PROCURAR LG0500               RETER O ISS A ALIQUOTA DE 5%    *      */
        /*"      *                                SOMENTE SOBRE COMISSOES E       *      */
        /*"      *                                PRESTACAO SERVICO DE SINISTRO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIGIA 02/06/2000: - IMPLEMENTACAO DO CALCULO DO     *      */
        /*"      *  PROCURAR LG0600               IRF SOBRE RESGATE DE TITULOS    *      */
        /*"      *                                DE CAPITALIZACAO                *      */
        /*"      *                              - ACUMULA RENDIMENTOS E IMPOSTOS  *      */
        /*"      *                                DO FAVORECIDO POR EMPRESA       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIANE 11/07/2000: - IMPLEMENTACAO DO CALCULO DO     *      */
        /*"      *  PROCURAR LP0700               NUMERO DO RECIBO PARA PRODUTOR. *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIGIA 08/09/2000: - DISPENSA FAVORECIDOS DA TRIBUTA-*      */
        /*"      *                  21/09/2000:   CAO DO ISS A PEDIDO DO USUARIO  *      */
        /*"      *  ALTERACAO LIGIA 28/09/2000: - DISPENSA DE TRIBUTACAO DE ISS   *      */
        /*"      *  PROCURAR LG0900             - DATA DA ULTIMA ATUALIZACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIGIA 07/11/2000: - SE A FONTE FOR 19-RIO G. DO SUL *      */
        /*"      *  PROCURAR LG1100               RETER O ISS A ALIQUOTA DE 3%    *      */
        /*"      *                                PARA CORRETAGENS                *      */
        /*"      *  ALTERACAO LIGIA 07/11/2000: - SE A FONTE FOR 12-BELO HORIZONTE*      */
        /*"      *  PROCURAR LG1100               RETER O ISS A ALIQUOTA DE 3%    *      */
        /*"      *                                PARA CORRETAGENS                *      */
        /*"      *  ALTERACAO LIGIA 20/11/2000: - DISPENSA FAVORECIDOS DA TRIBUTA-*      */
        /*"      *  PROCURAR LG1100               CAO DO ISS A PEDIDO DO USUARIO  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG1200*  ALTERACAO LIGIA 27/12/2000: - VALIDACAO DE DADOS              *      */
        /*"      *                                NA TABELA AGRUPA_TABELAS_CH1    *      */
        /*"      *                              - TRIBUTA BASE DE CALCULO         *      */
        /*"      *                                INFORMADA PARA CADA IMPOSTO     *      */
        /*"      *                              - NOVA RETENCAO DE INSS           *      */
        /*"      *                                INCLUI RENDIMENTO E IMPOSTOS    *      */
        /*"      *  PROCURAR LG1200               COM CODSVI = 5555               *      */
        /*"HC1200*  ALTERACAO HEIDER 29/12/2000:  TRATAMENTO ESPECIFICO PARA O    *      */
        /*"      *  PROCURAR HC1200               PROGRAMA FI0009B                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LP0101*  ALTERACAO LIANE 29/01/2001: - DISPENSA FAVORECIDOS DA TRIBUTA-*      */
        /*"      *  PROCURAR LP0101               CAO DO ISS A PEDIDO DO USUARIO  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO LIGIA 30/03/2001: - SUBSTITUICAO TRIBUTARIA         *      */
        /*"      *  PROCURAR LG0301               SOMENTE PARA A SEGURADORA       *      */
        /*"      *                              - TRATAMENTO ESPECIAL PARA O      *      */
        /*"      *                                SINISTRO HABITACIONAL(FI0009B)  *      */
        /*"      *                                RAMO 66                         *      */
        /*"      *                                ISENTANDO ISS EM FILIAIS        *      */
        /*"      *                              - CRIACAO DO WS-TIPO-SERV         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"HC0301*  ALTERACAO HEIDER 30/03/2001:- TRATAMENTO ESPECIAL PARA O      *      */
        /*"      *  PROCURAR HC0301               SINISTRO HABITACIONAL(FI0009B)  *      */
        /*"      *                                RAMO 66                         *      */
        /*"HC0401*  ALTERACAO HEIDER 02/04/2001:- ACERTOS PARA O RAMO 66          *      */
        /*"      *  PROCURAR HC0401                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0401*  ALTERACAO LIGIA  18/04/2001:- ACERTA TRIBUTACAO IR E INSS     *      */
        /*"      *                                RAMO 66                         *      */
        /*"      *  PROCURAR LG0401                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0501*  LIGIA, 02/05/2001 - DISPENSA FAVORECIDO DA TRIBUTACAO DO ISS  *      */
        /*"      *  PROCURAR LG0501                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0501*  LIGIA, 16/05/2001 - RAMO 66 DISPENSADO DO ISS EM FT=01,06,16  *      */
        /*"      *  PROCURAR LG0501                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0601*  LIGIA, 11/06/2001 - DISPENSA FAVORECIDO DA TRIBUTACAO DO ISS  *      */
        /*"      *  PROCURAR LG0601                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0701*  LIGIA, 04/07/2001 - DISPENSA FAVORECIDO DE TRIBUTACAO ISS/IRF *      */
        /*"      *  PROCURAR LG0701                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0901*  LIGIA, 13/09/2001 - DISPENSA FAVORECIDO DE TRIBUTACAO(ISS)    *      */
        /*"      *                    - ATUALIZACAO DA DOCUMENTACAO               *      */
        /*"      *  PROCURAR LG0901                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LP0901*  ALTERACAO LIANE 18/09/2001: - INCLUSAO DA TRIBUTACAO DE IMPOS-*      */
        /*"      *                                TO PARA PAGAMENTO DE PREMIACAO  *      */
        /*"      *                                PRODUTOS PM E PU.               *      */
        /*"      *                                EMPRESA: CAIXA CAPITALIZACAO.   *      */
        /*"      *                              - ALTERADO O COD.RETENCAO DO IR   *      */
        /*"      *                                DA COMISSAO.                    *      */
        /*"      *  PROCURAR LP0901                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG1001*  LIGIA, 01/10/2001 - DISPENSA FAVORECIDO DO ISS (LISTA 11)     *      */
        /*"      *  PROCURAR LG1001                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG1001*  LIGIA, 11/10/2001 - DISPENSA FAVORECIDO DO ISS (LISTAS 12 E 13*      */
        /*"      *  PROCURAR LG1001                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LN1001*  LIGIA, 23/10/2001 - DISPENSA FAVORECIDO DO ISS (LISTA 14)     *      */
        /*"      *  PROCURAR LN1001                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD1001*  LIGIA, 29/10/2001 - DISPENSA FAVORECIDO DO ISS QUANDO O       *      */
        /*"      *  PROCURAR LD1001     INDICADOR DO DESCONTO DO ISS              *      */
        /*"      *                      NA TABELA FORNECEDORES DCOISS = "D"       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LS1001*  LIGIA, 29/10/2001 - APLICA ALIQUOTA DE 1% QUANDO O FAVORECIDO *      */
        /*"      *                      FOR OPTANTE DO SIMPLES MUNICIPAL.         *      */
        /*"      *                      ESTA NA TABELA FORNECEDORES COM           *      */
        /*"      *                      OPT_SIMPLES_MUN="S" E PCDESISS= 1%.       *      */
        /*"      *  PROCURAR LS1001                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG1201*  LIGIA, 13/12/2001 - DISPENSA FAVORECIDO DE TRIBUTACAO IRF     *      */
        /*"      *                    - MOVE MSG PARA   TIPREG DIFERENTE          *      */
        /*"      *  PROCURAR LG1201                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0102*  LIGIA, 18/01/2002 - DISPENSA FAVORECIDO DE TRIBUTACAO ISS/IRF *      */
        /*"      *  PROCURAR LG0102     EDISON EUSTORGIO E SILVA - ME             *      */
        /*"      *                      COD. 813068 E 901774                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0302*  LIGIA, 19/03/2002 - DISPENSA FAVORECIDO DO IRF                *      */
        /*"      *  PROCURAR LG0302     MARC COMPILACAO DE DADOS LTDA ME          *      */
        /*"      *                      COD. 965478 - CAIXAPREV                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0402*  LIGIA, 05/04/2002 - DISPENSA FAVORECIDO DO IRF                *      */
        /*"      *                      HL REGULADORA DE SINISTROS LTDA           *      */
        /*"      *                      COD. 612228 E 926737                      *      */
        /*"      *  PROCURAR LG0402                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LN0402*  ALTERADO PARA CONSIDERAR A DEDUCAO NO CALCULO DO IRF          *      */
        /*"      *  PARA BENEFICIARIOS DA PREV. MAIORES DE 65 ANOS                *      */
        /*"      *  ALTERADO POR LIGIA EM 18/04/2002, PROCURAR LN0402             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0402*  LIGIA, 18/04/2002 - DISPENSA FAVORECIDO DO IRF                *      */
        /*"      *  PROCURAR LC0402     ACRG SERVI OS S/C - C D. 88668 E 896113   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0402*  LIGIA, 23/04/2002 - DISPENSA FAVORECIDO DO IRF QUANDO O       *      */
        /*"      *                      INDICADOR DO DESCONTO DO IRF              *      */
        /*"      *                      NA TABELA FORNECEDORES DCOIRF = "D"       *      */
        /*"      *  PROCURAR LD0402                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0702*  LIGIA, 26/07/2002 - DISPENSA FAVORECIDO DE TRIBUTACAO ISS/IRF *      */
        /*"      *          PRESTADOR COD. 102650 - CONSELHO REGIONAL DE MEDICINA *      */
        /*"      *  PROCURAR LG0702                                               *      */
        /*"LN0702*  LIGIA, 29/07/2002 - RETIREI O DISPLAY R8888 PARA RESGATE CAP  *      */
        /*"      *  PROCURAR LG0702                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JU1002*  NEYDE, 28/10/2002 - CRIADO O NOVO TIPO DE IMPOSTO :           *      */
        /*" "    *  I = VALOR NOMINAL ISENTO DE IR                                *      */
        /*" "    *  PROCURAR JU1002                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG1102*  ALTERADO PARA CONSIDERAR A ISENCAO DO IRF                     *      */
        /*"      *  PARA BENEFICIARIOS DA PREV. COM INVALIDEZ PERMANENTE          *      */
        /*"      *  ALTERADO POR LIGIA EM 11/11/2002                              *      */
        /*"      *  PROCURAR LG1102                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0903*  PROMOVIDO SEM ALTERACAO PARA ATUALIZAR A PRD.V01.LOAD         *      */
        /*"      *  QUE ESTAVA COM DATA DE 28/10/2002                             *      */
        /*"      *  PRD.V01.LOAD(FI0100S)                                         *      */
        /*"      *       ...0....+....1....+....2....+                            *      */
        /*"      *  0009 FI0100S 20021028161758020101                             *      */
        /*"      *  PROMOVIDO EM 26/09/2003 - PROCURAR LG0903                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0104* ALTERADO PARA CALCULAR:  CSLL, COFINS, PIS/PASEP               *      */
        /*"      * SOBRE O VALOR BRUTO PAGO A PJ COM DESCONTO DO IR               *      */
        /*"      * OS VALORES SERAO REGISTRADOS NA TABELA IMPOSTOS COM OS TIPOS   *      */
        /*"      *--*      '7' = VALOR DA CSLL                                    *      */
        /*"      *--*      '8' = VALOR DA COFINS                                  *      */
        /*"      *--*      '9' = VALOR DA CONTRIBUICAO PARA O PIS/PASEP           *      */
        /*"      *   LIGIA EM 19/01/2004 PROCURAR LG0104 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0204* NAO RETER A COFINS DE 1385122 (EUDS FURTADO ADV. ASSOCIADOS)   *      */
        /*"      * A PEDIDO DO ALEXANDRE DA GECONT                                *      */
        /*"      *--* VALOR DA CSLL                          RETENCAO 5987        *      */
        /*"      *--* VALOR DA CONTRIBUICAO PARA O PIS/PASEP RETENCAO 5979        *      */
        /*"      *   LIGIA EM 05/02/2004 PROCURAR LG0204 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0204* NAO RETER A COFINS DE 444892 LAGUN,ARRUDA,ALVES,ROTH & ADV.    *      */
        /*"      * NAO RETER A COFINS DE 118541 TUFI SALIM,CASTRO DIAS ASSOC.ADV  *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 19/02/2004                     *      */
        /*"      *   LIGIA EM 20/02/2004 PROCURAR LC0204 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LN0204* NAO RETER A COFINS DE 1176087 MACHADO,MEYER,SENDACZ E OPICE    *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 25/02/2004                     *      */
        /*"      *   LIGIA EM 25/02/2004 PROCURAR LN0204 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0304* UTILIZA O COD. DE RETENCAO 0588 NA PREMIACAO DE PF             *      */
        /*"      * A PEDIDO DO EDILSON DA GECONT EM 01/03/2004                    *      */
        /*"      *   LIGIA EM 02/03/2004 PROCURAR LG0304 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LR0304* NAO RETER PIS E COFINS DO FAVORECIDO:                          *      */
        /*"      *  1654304 CASTRO , CAMPOS E ASSOC. ADVOGADO                     *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 18/03/2004                     *      */
        /*"      *   LIGIA EM 19/03/2004 PROCURAR LR0304 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LN0304* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  17477 - FENAE - CORRETORA DE SEGUROS                          *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 24/03/2004                     *      */
        /*"      *   LIGIA EM 24/03/2004 PROCURAR LN0304 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0304* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  1739761 - LG INFORMATICA LTDA                                 *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 24/03/2004                     *      */
        /*"      *   LIGIA EM 26/03/2004 PROCURAR LC0304 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0404* DESCONTO PARA MICRO-EMPRESA ALTERADO PARA 2%                   *      */
        /*"      *   LIGIA EM 26/04/2004 PROCURAR LC0404 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LR0404* SUBSTITUICAO TRIBUTARIA EM RECIFE                              *      */
        /*"      *    FONTE = 16 (RECIFE) - SOLICITADO POR SIDNEY EM 16/04/2004          */
        /*"      *   LIGIA EM 26/04/2004 PROCURAR LR0404 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0404* LIBERAR O DESCONTO DO ISS PARA DELPHOS NA FONTE 9 E 16         *      */
        /*"      * DELPHOS SERVICOS TECNICOS EM RECIFE(FT=16) E GOIANIA(FT=09)    *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 24/03/2004                     *      */
        /*"      *   LIGIA EM 26/04/2004 PROCURAR LG0404 NO COMENTARIO            *      */
        /*"      *  REVISADO PARA PROMOCAO EM 27/04/2004                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0604* NAO RETER PIS E COFINS DO FAVORECIDO:                          *      */
        /*"      *  2113969 PWC SOCIEDADE CIVIL LTDA    918258000171              *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 01/06/2004                     *      */
        /*"      *   LIGIA EM 03/06/2004 PROCURAR LG0604 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LR0604* NAO RETER A COFINS DE 71081 DUARTE,GONCALVES & OLSEN VEIGA ADVG*      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 16/06/2004                     *      */
        /*"      *   LIGIA EM 16/06/2004 PROCURAR LR0604 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LN0604* NAO RETER A COFINS DE 1786154    ERNESTO BORGES ADVOGADOS S/C  *      */
        /*"      *                       1818364    ERNESTO BORGES ADVOGADOS S/C  *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 21/06/2004                     *      */
        /*"      *   LIGIA EM 23/06/2004 PROCURAR LN0604 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0804* LIBERAR O DESCONTO DO ISS NA FILIAL 16(RECIFE) PARA            *      */
        /*"      * 1481  GERENCIAL BRASITEC SERVICOS TECNICOS                    *       */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 03/08/2004                     *      */
        /*"      *   LIGIA EM 03/08/2004 PROCURAR LG0804 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LN0804* A PEDIDO DO ALEXANDRE  DA GECONT EM 19/08/2004                 *      */
        /*"      * EMBASADO PELA IN-440, DE 11 DE AGOSTO DE 2004 DA SRF           *      */
        /*"      *  ALTERADO PARA CONSIDERAR A ISENCAO DE R$ 100,00 NO IR         *      */
        /*"      *  DOS  BENEFICIARIOS DA PREVIDENCIA DE AGOSTO A DEZEMBRO/2004   *      */
        /*"      *  ALTERADO POR LIGIA EM 23/08/2004 PROCURAR LN0804 NO COMENTARIO*      */
        /*"      *  PROMOVIDO EM 25/08/2004                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0804* NAO RETER A COFINS DE 433079 ZAMPIERI & CASTANHA               *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 17/08/2004                     *      */
        /*"      *   LIGIA EM 23/08/2004 PROCURAR LC0804 NO COMENTARIO            *      */
        /*"      *  PROMOVIDO EM 25/08/2004                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LS0804* NAO RETER A COFINS DE 152455 CASTRO,MENDONCA,URBANO E DE PAULA *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 24/08/2004                     *      */
        /*"      *   LIGIA EM 25/08/2004 PROCURAR LS0804 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"FUTURO* SOLICITACAO DE ALEXANDRE  DA GECONT EM 29/04/2004              *      */
        /*"      * ALTERADO PARA TRIBUTAR:  CSLL, COFINS, PIS/PASEP               *      */
        /*"      * SOBRE O VALOR BRUTO PAGO A PESSOA JURIDICA                     *      */
        /*"      * INDEPENDENTE DA EXISTENCIA DA TRIBUTACAO DO IR                 *      */
        /*"      *   LIGIA EM 27/08/2004 PROCURAR FUTURO NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0804* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *     CNPJ=61562112001526 - PRICE WATER HOUSE COOPERS            *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 26/08/2004                     *      */
        /*"      *   LIGIA EM 27/08/2004 PROCURAR LA0804 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0904* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  COD=984084 ALMEIDA ROTEMBERG E BOSCOLI ADVOCACIA              *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 01/09/2004                     *      */
        /*"      *   LIGIA EM 01/09/2004 PROCURAR LA0904 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0904* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  COD=2091958 SIRIUS MULTIMIDIA LTDA                                   */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 01/09/2004                     *      */
        /*"      *   LIGIA EM 02/09/2004 PROCURAR LB0904 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0904* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  COD=1385122 EUDS FURTADO & ADV. ASSOCIADOS                    *      */
        /*"      *  COD=1084748 STAG CENTRAL DE ESTAGIOS LTDA                     *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 03/09/2004                     *      */
        /*"      *   LIGIA EM 03/09/2004 PROCURAR LC0904 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0904* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  COD=99791 MERCER HUMAN RESOURCE CONSULTING                    *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 08/09/2004                     *      */
        /*"      *   LIGIA EM 08/09/2004 PROCURAR LD0904 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0904* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  COD=58050 INST.FOR INTERNAT.RESEARCH DO BR                    *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 10/09/2004                     *      */
        /*"      *   LIGIA EM 10/09/2004 PROCURAR LE0904 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0904* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"LF0904*  COD=1229971 ROCCA PRANDINI & RABBAT FIN SERV                  *      */
        /*"LF0904*  COD=856563 SOFTAPLIC SOCIEDADE CIVIL LTDA                     *      */
        /*"LF0904*  COD=2218390 ALLIAGE CONSULTORIA EM RH S/C LT                  *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 13/09/2004                     *      */
        /*"      *   LIGIA EM 13/09/2004 PROCURAR LF0904 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0904* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  COD=2121331 PIRES SERVICOS GERAIS A BANCOS                    *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 15/09/2004                     *      */
        /*"      *   LIGIA EM 15/09/2004 PROCURAR LG0904 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LH0904* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  COD=2220249 GUSMAO E LABRUNIE ADVOGADOS                              */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 21/09/2004                     *      */
        /*"      *   LIGIA EM 21/09/2004 PROCURAR LH0904 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA1004* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *  COD=1969335 PRICE WATER HOUSE COOPERSOS                              */
        /*"      *  COD=1268268 PRICE WATER HOUSE COOPERS                                */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 07/10/2004                     *      */
        /*"      *   LIGIA EM 07/10/2004 PROCURAR LA1004 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB1004* FAVOR ATIVAR NO SISTEMA AS RETENCOES DO PIS, COFINS E  CSLL    *      */
        /*"      *     CNPJ=61562112001526 - PRICE WATER HOUSE COOPERS            *      */
        /*"      *      COD=1064282 PRICEWATERHOUSECOOPERS                               */
        /*"      *      COD=1064283 PRICE WATER HOUSE COOPERS AUDITORES                  */
        /*"      *      COD=1064284 PRICEWATERHOUSECOOPERS AUDITORES INDEPEN             */
        /*"      *      COD=1268268 PRICEWATERHOUSECOOPERS AUD. INDEPENDENTE             */
        /*"      *      COD=1278907 PRICEWATERHOUSECOOPERS AUDITORES INDEP.              */
        /*"      *      COD=1969335 PRICE WATER HOUSE COOPERS                            */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 08/10/2004                     *      */
        /*"      *   LIGIA EM 08/10/2004 PROCURAR LB1004 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG1104* NAO ISENTAR                                                    *      */
        /*"      *  COD=984084 ALMEIDA ROTEMBERG E BOSCOLI ADVOCACIA              *      */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 10/11/2004                     *      */
        /*"      *   LIGIA EM 10/11/2004 PROCURAR LG1104 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NAO ISENTAR                                                    *      */
        /*"LA1104*  COD=2121331 PIRES SERVICOS GERAIS A BANCOS                           */
        /*"      * A PEDIDO DO SYDNEI DA GECONT EM 16/11/2004                     *      */
        /*"      *   LIGIA EM 17/11/2004 PROCURAR LA1104 NO COMENTARIO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"CA1204* ALTERADO PARA FORCAR A TRIBUTACAO DE IRF EM 15% (PESSOA FISICA)*      */
        /*"      * PROCURAR CA1204 - ALTERADO POR CARLOS ALBERTO EM 29/12/2004.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0305* NAO RETER PIS,COFINS E CSLL DO FAVORECIDO:                     *      */
        /*"      *     CNPJ=2593417000130 - RAPP DATA S/C LDTA                    *      */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM 11/03/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 14/03/2005               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0405* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI               *      */
        /*"LG0405* - 2339831 - EASYWAY DO BRASIL( SSI 1554/2005)                  *      */
        /*"LG0405* - VARIOS FAVORECIDOS DA CAIXA CONSORCIO ( SSI 1555/2005)       *      */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM 19 E 26/04/2005          *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 28/04/2005               *      */
        /*"      * PROCURAR LG0405 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0505* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO                     *      */
        /*"LG0505* - 1627298 - FINANCIAL CONSULT ECONOMICA(POR E-MAIL EM 04/05)   *      */
        /*"LG0505* - 2512142 - FINANCIAL CONSULT ECONOMICA( SSI 1606/2005)        *      */
        /*"LG0505* - 2521984 - UNIVERSAL CORRETORA DE SEGUROS LTDA (SEM SSI)      *      */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM 04/05/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 06/05/2005               *      */
        /*"      * PROCURAR LG0505 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0805* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4166/2005     *      */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM 01/08/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 02/08/2005               *      */
        /*"      * PROCURAR LC0805 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0805* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4296/2005     *      */
        /*"LG0805* - 984084 ALMEIDA ROTEMBERG E BOSCOLI ADVOCACIA               *        */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM 08/08/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 09/08/2005               *      */
        /*"      * PROCURAR LG0805 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LN0805* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4362/2005     *      */
        /*"LN0805* - 1358882 PERICIAL ASSEC. SAUDE                                *      */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM 10/08/2005               *      */
        /*"LN0805* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4400/2005     *      */
        /*"LN0805* - 997872  - LBH SERVICOS LTDA                                  *      */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM 12/08/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 12/08/2005               *      */
        /*"      * PROCURAR LN0805 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LR0805* VOLTA RETENCAO PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4453/2005*      */
        /*"LR0805* - 1358882 PERICIAL ASSEC. SAUDE  - VOLTA A TRIBUTACAO          *      */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM 15/08/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 16/08/2005               *      */
        /*"      * PROCURAR LR0805 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0805* VOLTA RETENCAO PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4585/2005*      */
        /*"LA0805* - 984084 ALMEIDA ROTEMBERG E BOSCOLI ADVOCACIA               *        */
        /*"LB0805* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4550/2005     *      */
        /*"LB0805* - 2692813  -EASY-WAY DO BRASIL CONSULTORIA E INFORMATICA LTDA  *      */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM    08/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 22/08/2005               *      */
        /*"      * PROCURAR LA0805 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0805* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4667/2005     *      */
        /*"LD0805* - 2645300  UNICRED COOPERATIVA  DE CREDITO                     *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 26/08/2005               *      */
        /*"      * PROCURAR LD0805 NO COMENTARIO                                  *      */
        /*"LE0805* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4689/2005     *      */
        /*"LE0805* - 1321664-  LIDERANCA LIMP. E CONSERVACAO LTDA.                *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 29/08/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 29/08/2005               *      */
        /*"      * PROCURAR LE0805 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4587/2005     *      */
        /*"LA0905* - 984084 ALMEIDA ROTEMBERG E BOSCOLI ADVOCACIA               *        */
        /*"      * SOLICITADO POR ALEXANDRE DA GECONT EM 22/08/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 01/09/2005               *      */
        /*"      * PROCURAR LA0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4758/2005     *      */
        /*"LB0905* - 1801053 - MICROSTRATEGY BRASIL LTDA                          *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 29/08/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 01/09/2005               *      */
        /*"      * PROCURAR LB0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4804/2005     *      */
        /*"LC0905* - 1030141 -PRICEWATERHOUSECOOPERS                              *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 01/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 05/09/2005               *      */
        /*"      * PROCURAR LC0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LP0905* **       PAGAMENTO DE PREMIACAO ATRAVES DE OP               ** *      */
        /*"LP0905* ALTERADO PARA ACATAR O PERCENTUAL INFORMADO NA OP              *      */
        /*"      * DE PAGAMENTO DE PREMIO DE TITULO DE CAPITALIZACAO              *      */
        /*"      * SOLICITADO POR RONI      DA GETEC  EM 05/08/2005 -SSI 4434/2005*      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 06/09/2005               *      */
        /*"      * PROCURAR LP0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4975/2005     *      */
        /*"LD0905* - 2107978 - ITG INFORMACOES, TECNOLOGIA GERENCIA LTDA          *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 09/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 14/09/2005               *      */
        /*"      * PROCURAR LD0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4984/2005     *      */
        /*"AV1220* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 6461/2005         *      */
        /*"LE0905* - 2353403- CNP-M TECNOLOGIA SERV. INFORMATICA S.A              *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 09/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 14/09/2005               *      */
        /*"      * PROCURAR LE0905 NO COMENTARIO                                  *      */
        /*"      * ALTERADO   POR ALEXIS    DA GESIS  EM 20/12/2005               *      */
        /*"      * PROCURAR AV1220 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4985/2005     *      */
        /*"LF0905* - 2364949 -ITG INFORMACOES, TECNOLOGIA GERENCIA LTDA           *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 09/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 14/09/2005               *      */
        /*"      * PROCURAR LF0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 4986/2005     *      */
        /*"LG0905* - 2106123 -ITG INFORMACOES, TECNOLOGIA GERENCIA LTDA           *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 09/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 14/09/2005               *      */
        /*"      * PROCURAR LG0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LH0905* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5021/2005         *      */
        /*"LH0905* - 1064282 - PRICEWALTERHOUSECOOPERS AUDIL. INDEPEND.           *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 12/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 14/09/2005               *      */
        /*"      * PROCURAR LB1004 NO COMENTARIO PORQUE JA ESTAVA ALTERADO        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LI0905* NAO RETER COFINS  EM ATENDIMENTO A SSI 5224/2005               *      */
        /*"LI0905* - 4545-  PIMENTEL E ASSOCIADOS ADVOCACIA                       *      */
        /*"HC1105* - 1545722 -  PIMENTEL E ASSOCIADOS ADVOCACIA                          */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 21/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 26/09/2005               *      */
        /*"      * PROCURAR LI0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LJ0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5335/2005     *      */
        /*"LJ0905* - 2719790 OPTION BRASIL CONSULT. E TREINAMENTO LTDA            *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 22/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 28/09/2005               *      */
        /*"      * PROCURAR LJ0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LK0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5336/2005     *      */
        /*"LK0905* - 507122 COOPERTAX COOP. CON. AUT. VEIC.  RODOV. DE  PAULO     *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 27/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 28/09/2005               *      */
        /*"      * PROCURAR LK0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LL0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5370/2005     *      */
        /*"LL0905* - 2723979 -  LAESER E PORTELA ADVOGADOS                        *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 28/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 29/09/2005               *      */
        /*"      * PROCURAR LL0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LM0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5395/2005     *      */
        /*"LM0905* - 2082506 -  SPIRIT MARKETING PROMOCIONAL LTDA                 *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 28/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 30/09/2005               *      */
        /*"      * PROCURAR LM0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LN0905* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5398/2005     *      */
        /*"LN0905* - 1164983 FESA - CONS. EM RH S/C LTDA                          *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 30/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 30/09/2005               *      */
        /*"      * PROCURAR LN0905 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5404/2005     *      */
        /*"LA1005* - 1674356 - SPIRIT MARKENTING PROMOCIONAL LTDA                 *      */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 30/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 03/10/2005               *      */
        /*"      * PROCURAR LA1005 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5418/2005     *      */
        /*"LB1005* - 862577 - ATENE ASSSESSORIA TECNICA LTDA                             */
        /*"      * SOLICITADO POR EMIDIO    DA GECONT EM 30/09/2005               *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 03/10/2005               *      */
        /*"      * PROCURAR LB1005 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC1005* APLICA A ALIQUOTA INFORMADA NO ARQUIVO DA PREV - SSI 5457/2005 *      */
        /*"      * ALTERADO   POR LIGIA     DA GESIS  EM 10/10/2005               *      */
        /*"      * PROCURAR LC1005 NO COMENTARIO                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5491/2005     *      */
        /*"LD1005* - 2689691 E-CLIP SISTEMA DE INFOIRMACOES S/A                   *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 11/10/2005 PROCURAR LD1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5519/2005     *      */
        /*"LE1005* - 170607 COOPERATIVA CON. COND.AUT. DE BR                      *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 11/10/2005 PROCURAR LE1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5530/2005     *      */
        /*"LF1005* - 1750178 - JOSE NORBERTO MARCHIORI DE FRANCESCHI              *      */
        /*"LF1005* - 1272507 - SBE SOC BRASILEIRA DE ENG. CONSULT & AVAL          *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 11/10/2005 PROCURAR LF1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5479/2005     *      */
        /*"LG1005* - 2193358 - FLUXOS ATIVOS E PASSIVOS  LTDA  (CONSORCIO)        *      */
        /*"LG1005* - 2193371 -  FLUXOS ATIVOS E PASSIVOS LTDA  (PREVIDENCIA)      *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 11/10/2005 PROCURAR LG1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LH1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5402/2005     *      */
        /*"LH1005* - 997872 LBH SERVICOS LTDA                                     *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 11/10/2005 PROCURAR LH1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LI1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5577/2005     *      */
        /*"LI1005* - 1086527 - SOMA DESENVOLVIMENTO HUMANO S/C                    *      */
        /*"LI1005* - 141248  - CELSO E NIEDA ADVOGADOS ASSOCIADOS  S/S            *      */
        /*"LI1005* - 2167132 - JL CURSOS LIVRES LTDA                              *      */
        /*"LI1005* - 1176088 - INFANTI ENGENHARIA E ARQUITETURA LTDA - ME         *      */
        /*"LI1005* - 1739761 - LG   INFORMATICA LTDA                              *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 14/10/2005 PROCURAR LI1005        *      */
        /*"AV1220* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 6468/2005         *      */
        /*"AV1220* - 2115744 - PROCONTAS SERV.CONT.S/S LTDA                       *      */
        /*"      * ALTERADO POR ALEXIS       EM 20/12/2005 PROCURAR AV1220        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LJ1005* NAO RETER A COFINS EM ATENDIMENTO A SSI 5577/2005              *      */
        /*"LJ1005* - 118541  - TUFI SALIM , CASTRO DIAS                           *      */
        /*"LJ1005* - 1786154 - ERNESTO BORGES ADVOGADOS S/C                       *      */
        /*"LJ1005* - 141348  - CELSO E  NIEDA ADVOGADOS ASSOCIADOS S/S            *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 14/10/2005 PROCURAR LJ1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LK1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5597/2005     *      */
        /*"LK1005* - 862577  - ATENE ASSESSORIA TEC. LTDA                         *      */
        /*"LK1005* - 2734650 - TENILSSON PEREIRA DA SILVA                         *      */
        /*"LK1005* - 2734651 - ZEPPELLIN PUBLICIDADE LTDA                         *      */
        /*"LK1005* - 118541  -  TUFIN SALIN, CASTRO                               *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 14/10/2005 PROCURAR LK1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LL1005* NAO RETER A COFINS EM ATENDIMENTO A SSI 5597/2005              *      */
        /*"LL1005* - 2286845 - MENDONCA URBANO E  DE PAILA ADV. ASSOCIADOS        *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 14/10/2005 PROCURAR LL1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LM1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5644/2005     *      */
        /*"LM1005* - 2271790 TREE ENSINO DE LINGUAS LTDA.                         *      */
        /*"LM1005* - 2271791 LYCEE FRANCAIS FRANCOIS MITTERRAND                   *      */
        /*"LM1005* - 2689691 E-CLIP SISTEMA DE INFOIRMACOES S/A                   *      */
        /*"LM1005* - 1640645 SERGIO ISRAEL DOS SANTOS S/C LTDA                    *      */
        /*"LM1005* - 1176088 INFANTI ENGENHARIA E ARQUITETURA LTDA                *      */
        /*"LM1005* - 1031289 CONSTRUTORA TAVARES TEIXEIRA LTDA                    *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 19/10/2005 PROCURAR LM1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LN1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5691/2005     *      */
        /*"LN1005* - 854156 PRANDINI RABBAT & ASSOCIATES S/C LTDA                 *      */
        /*"LN1005* - 2220249 GUSMAO E LABRUNIE ADVOGADOS                          *      */
        /*"LN1005* NAO RETER A COFINS EM ATENDIMENTO A SSI 5691/2005              *      */
        /*"LN1005* - 2739281 TOZZINI FREIRE TEIXEIRA E SILVA ADVOGADO             *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 20/10/2005 PROCURAR LN1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LO1005* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5719/2005         *      */
        /*"LO1005* -2107978  ITG INFORMACOES, TECNOLOGIA GERENCIA LTDA            *      */
        /*"LO1005* -2364949  ITG INFORMACOES, TECNOLOGIA GERENCIA LTDA            *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 24/10/2005 PROCURAR LO1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LP1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5730/2005     *      */
        /*"LP1005* - 2398960 - COOPERATIVA COND. AUTONOMOS BRAS. LTDA             *      */
        /*"LP1005* NAO RETER A COFINS EM ATENDIMENTO A SSI 5730/2005              *      */
        /*"LP1005* - 2286848 - RAIMUNDO MARQUES & VALE ADVOCACIA  S/C             *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 24/10/2005 PROCURAR LP1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LQ1005* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5748/2005         *      */
        /*"LQ1005* -1370541 - ESCRITORIO DE ADVOCACIA ALMEIDA ROTEMBERG E BOSCOLI *      */
        /*"LQ1005* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5748/2005     *      */
        /*"LQ1005* -1709258 - IMBUZI MAO-DE-OBRA TEMPORARIA LTDA                  *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 25/10/2005 PROCURAR LQ1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LR1005* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5796/2005         *      */
        /*"LR1005* - 984084    - ALMEIDA ROTEMBERG E BOSCOLI ADVOCACIA            *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 27/10/2005 PROCURAR LR1005        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA1105* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5823/2005                */
        /*"LA1105* - 1268274 ETEC ESCRIT.TECN.DE ENGENHARIA                              */
        /*"LA1105* NAO RETER A COFINS EM ATENDIMENTO A SSI 5823/2005                     */
        /*"LA1105* - 80471 PELLON & ASSOC.ADVOCACIA EMPRESARIAL S/C                      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 01/11/2005 PROCURAR LA1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB1105* NAO RETER A COFINS EM ATENDIMENTO A SSI 5832/2005                     */
        /*"LB1105* - 2746553 BING & MULLER ADVOCACIA A                                   */
        /*"LB1105* NAO RETER A COFINS EM ATENDIMENTO A SSI 5897/2005                     */
        /*"LB1105* - 1332341 CELSO E NIEDA ADVOGADOS ASSOCIADOS S/S                      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 01/11/2005 PROCURAR LB1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC1105* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5897/2005                */
        /*"LC1105* - 1072868 - SPIRIT MARKETING PROMOCIONAL LTDA.                        */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 03/11/2005 PROCURAR LC1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD1105* NAO RETER A COFINS EM ATENDIMENTO A SSI 5917/2005                     */
        /*"LD1105* - 82023 - IBC DO BRASIL LTDA                                          */
        /*"LD1105* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5919/2005                */
        /*"LD1105* - 1768521 - CAPITOLIO CONSULTORES ASSOCIADOS LTDA                     */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 04/11/2005 PROCURAR LD1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE1105* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5936/2005                */
        /*"LE1105* - 1768519 - CAPITOLIO CONSULTORES ASSOCIADOS LTDA                     */
        /*"LE1105* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5971/2005            */
        /*"LE1105* - 2168869 - GUSMAO E LABRUNIE ADVOGADOS                               */
        /*"LE1105* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5989/2005            */
        /*"LE1105* - 1896070 - PINTO E SOARES ADVOGADOS ASSOCIADOS S/C                   */
        /*"LE1105* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 5989/2005                */
        /*"LE1105* - 2082506 - SPIRIT INCENTIVO E FIDELIZACAO LTDA                       */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 10/11/2005 PROCURAR LE1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF1105* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 6050/2005            */
        /*"LF1105* - 1527904 - SOMA DESENVOLVIMENTO HUMANO S/A                           */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 16/11/2005 PROCURAR LF1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG1105* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 6023/2005            */
        /*"LG1105* - 61549 AEUDF-ASS.DE ENSINO UNIFICADO                                 */
        /*"LG1105* - 2753576 EXECUTIVA RECURSOS HUMANOS LTDA                             */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 17/11/2005 PROCURAR LG1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LH1105* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 6099/2005            */
        /*"LH1105* - 82023 - IBC DO BRASIL LTDA                                          */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 18/11/2005 PROCURAR LH1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LI1105* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 6187/2005     *      */
        /*"LI1105* -  99791 MERCER HUMAN RESOURCE CONSULTING                      *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 28/11/2005 PROCURAR LI1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LJ1105* NAO RETER COFINS EM ATENDIMENTO A SSI 6209/2005                *      */
        /*"LJ1105* -  4545    PIMENTEL E ASSOCIADOS ADVOCACIA                            */
        /*"LJ1105* -  1545722 PIMENTEL E ASSOCIADOS ADVOCACIA                            */
        /*"LJ1105* -  1786154 ERNESTO BORGES ADVOGADOS S/C                               */
        /*"LJ1105* -  1818364 ERNESTO BORGES ADVOGADOS S/C                               */
        /*"LJ1105* -  141348  CELSO E NIEDA ADVOGADOS ASSOC.S/S                          */
        /*"LJ1105* -  1332341 CELSO E NIEDA ADVOGADOS ASSOCIADOS S/S                     */
        /*"LJ1105* -  1080810 TUFI SALIM CASTRO DIAS ASSOCIADOS ADVOGA                   */
        /*"LJ1105* -  118541  TUFI SALIM,CASTRO DIAS ASSOC.ADV                           */
        /*"LJ1105* -  997901  TUFI SALIM, MEIRELLES PEREIRA ASSOCIADO                    */
        /*"LJ1105* -  1332340 TUFI SALIM, MEIRELLES PEREIRA E ASSOCIAD                   */
        /*"LJ1105* -  2746553 BING & MULLER ADVOCACIA                                    */
        /*"V.2   * VAI RETER CONFIS - 2766041 BING MULLER ADVOGADOS ASSOCIADOS           */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 01/12/2005 PROCURAR LJ1105        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA1205* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6242/2005    *      */
        /*"LA1205* - 1385077 - APOIO LIDERANCA CONTABIL  LTDA                     *      */
        /*"LA1205* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6244/2005    *      */
        /*"LA1205* - 0525062 - APOIO LIDERANCA CONTABIL  LTDA                            */
        /*"LA1205* - 1264533 - APOIO LIDERANCA CONTABIL LTDA                             */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 05/12/2005 PROCURAR LA1205        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"AV1219* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6413/2005    *      */
        /*"AV1219*  COD=2018911 ADELSON JOSE C. SANTOS                                   */
        /*"AV1219*  COD=2047790 ADELSON JOSE C. SANTOS                                   */
        /*"AV1219*  COD= 240224 AMU-ATENDIMENTO MEDICO DE URGENC                         */
        /*"AV1219*  COD=1550740 AMU-ATENDIMENTO MEDICO DE URGENC                         */
        /*"AV1219*  COD=1994662 ANA BEATRIZ TEIXEIRA FRANCISCO                           */
        /*"AV1219*  COD=2047791 ANA BEATRIZ TEIXEIRA FRANCISCO                           */
        /*"AV1219*  COD=1580191 ANA CRISTINA M.S.J.PERIRA CAMPOS                         */
        /*"AV1219*  COD=1662247 ANA CRISTINA M.S.J.PERIRA CAMPOS                         */
        /*"AV1219*  COD=  98329 AORT-ASSIST.ORTOPED.E TRAUMATOLO                         */
        /*"AV1219*  COD=1491898 AORT-ASSIST.ORTOPED.E TRAUMATOLO                         */
        /*"AV1219*  COD= 475328 ARMANDO FORTUNATO FILHO                                  */
        /*"AV1219*  COD=1414198 ARMANDO FORTUNATO FILHO                                  */
        /*"AV1219*  COD= 268363 ASTRAMED INTERNACIONAL                                   */
        /*"AV1219*  COD=1832833 ASTRAMED INTERNACIONAL                                   */
        /*"AV1219*  COD=2600104 BIOCLINICA                                               */
        /*"AV1219*  COD=2621252 BIOCLINICA                                               */
        /*"AV1219*  COD= 807158 BRENO ALVARES DE FARIA PEREIRA                           */
        /*"AV1219*  COD=1897643 BRENO ALVARES DE FARIA PEREIRA                           */
        /*"AV1219*  COD= 271201 CARDIO DIAGNOSE S/C LTDA                                 */
        /*"AV1219*  COD=1540402 DIAS & CORTES LTDA - CARDIOCENTE                         */
        /*"AV1219*  COD=1605304 DIAS & CORTES LTDA - CARDIOCENTE                         */
        /*"AV1219*  COD=1334828 CARDIOCLIN CARDIOLOGIA CLINICA                           */
        /*"AV1219*  COD=1491895 CARDIOCLIN CARDIOLOGIA CLINICA                           */
        /*"AV1219*  COD= 100005 CARDIOLOGICA CLIN.DIAG.CARDIO.S                          */
        /*"AV1219*  COD= 255307 CARDOSO E CARDOSO S/C LTDA                               */
        /*"AV1219*  COD=1467074 CARDIOLOGICA CLIN.DIAG.CARDIO.S                          */
        /*"AV1219*  COD= 427184 CARDOSO E CARDOSO S/C LTDA                               */
        /*"AV1219*  COD=1467071 CARDOSO E CARDOSO S/C LTDA                               */
        /*"AV1219*  COD=   3077 CEMAD CENTRO MEDIC DO APAREL DIG                         */
        /*"AV1219*  COD=  27502 CENTRO MEDICO DO APARELHO DIGEST                         */
        /*"AV1219*  COD=1445542 CENTRO MEDICO DO APARELHO DIGEST                         */
        /*"AV1219*  COD=1681859 CENTRO DE CARIOLOGIA DO NORTE                            */
        /*"AV1219*  COD= 1306234 CENTRO M�DICO HOSPITALAR ONCOL�G                        */
        /*"AV1219*  COD= 211503 CENTRO MEC.MARINGA S/C LTDA                              */
        /*"AV1219*  COD=1445543 CENTRO MEC.MARINGA S/C LTDA                              */
        /*"AV1219*  COD=  85375 CENTRO PERNAMBUCANO DE ANALISES                          */
        /*"AV1219*  COD=1467073 CENTRO PERNAMBUCANO DE ANALISES                          */
        /*"AV1219*  COD=1423514 CESAR AUGUSTO NUNES MACIEL                               */
        /*"AV1219*  COD=1467072 CESAR AUGUSTO NUNES MACIEL                               */
        /*"AV1219*  COD=1662232 CESMOR CENTRO DE SEG. E MEDICINA                         */
        /*"AV1219*  COD=1687117 CESMOR CENTRO DE SEG. E MEDICINA                         */
        /*"AV1219*  COD=  98337 C.G.P.ASSESSORIA MEDICA LTDA                             */
        /*"AV1219*  COD= 255933 CLIMEGE LTDA                                             */
        /*"AV1219*  COD=2470914 CL�NICA DA FAMILIA                                       */
        /*"AV1219*  COD=2696763 CL�NICA DA FAMILIA                                       */
        /*"AV1219*  COD= 641912 CAI-CLIN.DE ACIDENT.DE IMPERATRI                         */
        /*"AV1219*  COD=   8257 CLINICA DE FRATURAS PLACIDO ARRA                         */
        /*"AV1219*  COD=2255915 CLINICA DE FRATURAS PLACIDO ARRA                         */
        /*"AV1219*  COD= 151076 CLINICA DE MEDICINA INTEGRADA LT                         */
        /*"AV1219*  COD= 221036 CLINICA DE ONCOLOGIA ONCOCLINICA                         */
        /*"AV1219*  COD=1063194 EDUARDO CALIXTO SALIBA                                   */
        /*"AV1219*  COD=1414192 EDUARDO CALIXTO SALIBA                                   */
        /*"AV1219*  COD=  84824 CLINICA GINECOLOGICA FERRARI LTD                         */
        /*"AV1219*  COD=1119602 CLIMED - CLINICA M�DICA FLORIAN�                         */
        /*"AV1219*  COD=1550739 CLIMED - CLINICA M�DICA FLORIAN�                         */
        /*"AV1219*  COD=1236899 CL�NICA M�DICO PSICOLOGIA SILO�                          */
        /*"AV1219*  COD=1236898 CLINICA M�DICA DR. GERALDO CHINI                         */
        /*"AV1219*  COD=1687116 CLINICA M�DICA DR. GERALDO CHINI                         */
        /*"AV1219*  COD=  82147 CLINICA ORTOPEDICA CAMBURI LTDA                          */
        /*"AV1219*  COD=1632903 CLINICA ORTOPEDICA CAMBURI LTDA                          */
        /*"AV1219*  COD=  94781 CLIN.REUMATOLOG.EGRI E NISHINARI                         */
        /*"AV1219* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6414/2005    *      */
        /*"AV1219* COD =  395037 CLINICOR - CLIN. DE DIAG. CAR.                          */
        /*"AV1219* COD =   87840 CLINICA SUGISAWA S/C LTDA                               */
        /*"AV1219* COD =   80870 CLINICA SEG.DE MED.DO TRAB.DE GO                        */
        /*"AV1219* COD = 1414202 CLINICA SEG.DE MED.DO TRAB.DE GO                        */
        /*"AV1219* COD =  117391 CLODOMIR COSME DA SILVA                                 */
        /*"AV1219* COD = 2088143 CLODOMIR COSME DA SILVA                                 */
        /*"AV1219* COD = 1502586 WALTENCIR DE SOUZA PARIZZI                              */
        /*"AV1219* COD = 1632902 WALTENCIR DE SOUZA PARIZZI                              */
        /*"AV1219* COD = 1531032 COMIDEFREITAS SERVICOS MEDICOS                          */
        /*"AV1219* COD = 1605306 COMIDEFREITAS SERVICOS MEDICOS                          */
        /*"AV1219* COD =  100927 CONSULMED AUD.E CONSULT.MEDICA                          */
        /*"AV1219* COD = 2106152 CONSULMED AUD.E CONSULT.MEDICA                          */
        /*"AV1219* COD = 1860491 CONTERI J.CHAVES TUPINAMBA E ASS                        */
        /*"AV1219* COD = 1873180 CONTERI J.CHAVES TUPINAMBA E ASS                        */
        /*"AV1219* COD = 1406384 DANIEL BARROS PEREIRA                                   */
        /*"AV1219* COD = 1445541 DANIEL BARROS PEREIRA                                   */
        /*"AV1219* COD =  817584 DANIELA SILVA FREITAS                                   */
        /*"AV1219* COD = 1323881 DEBORA RIBEIRO DUARTE MORAES                            */
        /*"AV1219* COD =   96687 EXMED RIO-CONSULTORIA TECNICA                           */
        /*"AV1219* COD = 1414201 EXMED RIO-CONSULTORIA TECNICA                           */
        /*"AV1219* COD =   83411 FUNCIPE-FUND.DE CIEC.E PESQ.MARI                        */
        /*"AV1219* COD = 1414200 FUNCIPE-FUND.DE CIEC.E PESQ.MARI                        */
        /*"AV1219* COD = 1053365 HINDEMBURGO BULHOES DE CARVALHO                         */
        /*"AV1219* COD = 1414189 HINDEMBURGO BULHOES DE CARVALHO                         */
        /*"AV1219* COD =  169048 HOSPITAL DE CARIDADE SAO ROQUE                          */
        /*"AV1219* COD =  104248 HOSPITAL SANTA CRUZ LTDA                                */
        /*"AV1219* COD = 1605307 HOSPITAL SANTA CRUZ LTDA                                */
        /*"AV1219* COD =  100935 HOSPITAL E MAT.STA.TEREZINHA LTD                        */
        /*"AV1219* COD =  240226 HOSPITAL SAO DIMAS LTDA                                 */
        /*"AV1219* COD =  240226 HOSPITAL SAO DIMAS LTDA                                 */
        /*"AV1219* COD =  283140 INST.DO CORACAO CENTRO.DE DIAGNO                        */
        /*"AV1219* COD =  112933 IOR-INSTITUTO DE ORTOPEDIA LTDA                         */
        /*"AV1219* COD = 1414196 IOR-INSTITUTO DE ORTOPEDIA LTDA                         */
        /*"AV1219* COD =   82155 IORF/INST.DE ORTOP.E REABL.FISIO                        */
        /*"AV1219* COD = 1414195 IORF/INST.DE ORTOP.E REABL.FISIO                        */
        /*"AV1219* COD =  126331 IOT-INST.DE ORTOPEDIA E TRAUMT                          */
        /*"AV1219* COD = 2119354 CLINICA GERAL LTDA                                      */
        /*"AV1219* COD = 2200515 JOAO PERIM                                              */
        /*"AV1219* COD = 1515811 JORGE ANTONIO NASSAR FILHO                              */
        /*"AV1219* COD = 1687115 JORGE ANTONIO NASSAR FILHO                              */
        /*"AV1219* COD = 2426129 JORGE LUIZ NUNES ALMAS                                  */
        /*"AV1219* COD = 2441615 JORGE LUIZ NUNES ALMAS                                  */
        /*"AV1219* COD = 2308856 JOSE MARCONI RAMOS CARVALHO                             */
        /*"AV1219* COD = 2351445 JOSE MARCONI RAMOS CARVALHO                             */
        /*"AV1219* COD =   90531 CLINICA DR.ULCIJARA AQUINO                              */
        /*"AV1219* COD = 2027397 CLINICA DR.ULCIJARA AQUINO                              */
        /*"AV1219* COD =   80853 JR MEDICINA DO TRABALHO S/C LTDA                        */
        /*"AV1219* COD = 1445545 JR MEDICINA DO TRABALHO S/C LTDA                        */
        /*"AV1219* COD = 2351402 JULIANA CUNHA ROCHA                                     */
        /*"AV1219* COD =  153851 L.M.COELHO LTDA                                         */
        /*"AV1219* COD =   88498 LABOR CLINICA LTDA                                      */
        /*"AV1219* COD =  193763 LUIS FERNANDO KUMMER                                    */
        /*"AV1219* COD = 1662234 LUIZ CARLOS THOME DA CRUZ                               */
        /*"AV1219* COD = 1721989 LUIZ CARLOS THOME DA CRUZ                               */
        /*"AV1219* COD = 2429974 LUIZ INGLETTO                                           */
        /*"AV1219* COD = 2709223 LUIZ INGLETTO                                           */
        /*"AV1219* COD =  369978 LUIZ MARIO DE OLIVEIRA PEIXOTO                          */
        /*"AV1219* COD = 1721990 LUIZ MARIO DE OLIVEIRA PEIXOTO                          */
        /*"AV1219* COD = 1323880 MARIA INES FERREIRA DE OLIVEIRA                         */
        /*"AV1219* COD = 1414190 MARIA INES FERREIRA DE OLIVEIRA                         */
        /*"AV1219* COD =   84093 M.S.T.CLINICA LTDA                                      */
        /*"AV1219* COD =  148318 METRA B MEDICINA OCUPACIONAL LTD                        */
        /*"AV1219* COD =  135151 METRO-CLIN.ESP.MEC.TRAB.OCUPACIO                        */
        /*"AV1219* COD = 1491896 METRO-CLIN.ESP.MEC.TRAB.OCUPACIO                        */
        /*"AV1219* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6415/2005    *      */
        /*"AV1219* COD =   148318 METRA B MEDICINA OCUPACIONAL LTD                       */
        /*"AV1219* COD =   135151 METRO-CLIN.ESP.MEC.TRAB.OCUPACIO                       */
        /*"AV1219* COD =  1491896 METRO-CLIN.ESP.MEC.TRAB.OCUPACIO                       */
        /*"AV1219* COD =  1102533 NADJA SOTERO NATIVIDADE MENDES                         */
        /*"AV1219* COD =  2709222 NADJA SOTERO NATIVIDADE MENDES                         */
        /*"AV1219* COD =  1460597 NATIVIDADE MENDES S CIA LTDA                           */
        /*"AV1219* COD =  1521792 NATIVIDADE MENDES S CIA LTDA                           */
        /*"AV1219* COD =    94773 NIKEI MEDICOS ASSOCIADOS S/C LTD                       */
        /*"AV1219* COD =  1414188 NIKEI MEDICOS ASSOCIADOS S/C LTD                       */
        /*"AV1219* COD =  1473492 NUCLEO MEDICO SAINT ETHINE LTDA                        */
        /*"AV1219* COD =  1491897 NUCLEO MEDICO SAINT ETHINE LTDA                        */
        /*"AV1219* COD =  1406385 ORTHOCENTER CEN.DE ORTOP.TRAUMAT                       */
        /*"AV1219* COD =  1897644 ORTHOCENTER CEN.DE ORTOP.TRAUMAT                       */
        /*"AV1219* COD =    80896 ORTOCLINICA S/C LTDA                                   */
        /*"AV1219* COD =  1414193 ORTOCLINICA S/C LTDA                                   */
        /*"AV1219* COD =  1365968 PAULO SERGIO DE VARGAS DIAS LOPE                       */
        /*"AV1219* COD =  1414199 PAULO SERGIO DE VARGAS DIAS LOPE                       */
        /*"AV1219* COD =  2351444 PEDRO ABR�O MARQUES                                    */
        /*"AV1219* COD =  2403951 PEDRO ABR�O MARQUES                                    */
        /*"AV1219* COD =   271200 PRO - SAUDE ASSIST. MEDICA S/C                         */
        /*"AV1219* COD =   919528 PLAMED S/C LTDA                                        */
        /*"AV1219* COD =  1445544 PLAMED S/C LTDA                                        */
        /*"AV1219* COD =    82953 POLICLINICA PLANALTO LTDA                              */
        /*"AV1219* COD =  1662245 POLICLINICA PLANALTO LTDA                              */
        /*"AV1219* COD =   807159 PRESTADORA DE SERV. M�DICOS B VI                       */
        /*"AV1219* COD =   672574 PRONT/SOC.CRUZ DE PRATA LTDA                           */
        /*"AV1219* COD =  1832834 PRONT/SOC.CRUZ DE PRATA LTDA                           */
        /*"AV1219* COD =    15156 RAIMUNDO NONATO LEAL MARTINS                           */
        /*"AV1219* COD =  1577185 RAIMUNDO NONATO LEAL MARTINS                           */
        /*"AV1219* COD =  1932611 RUBENS FERRARI                                         */
        /*"AV1219* COD =  1955285 DR.RUBENS FERRARI                                      */
        /*"AV1219* COD =    26328 SALIM HADDAD NETO                                      */
        /*"AV1219* COD =  2243042 SAUDE OCUPACIONAL SEGURAN�A E ME                       */
        /*"AV1219* COD =  2255913 SAUDE OCUPACIONAL SEGURAN�A E ME                       */
        /*"AV1219* COD =   101095 SERGIMED-SERGIO P.SERV.MEDICOS                         */
        /*"AV1219* COD =  2226592 SERGIO ARTUR BESS                                      */
        /*"AV1219* COD =  2239350 SERGIO ARTUR BESS                                      */
        /*"AV1219* COD =    82171 SERVICOS MEDICO SANTA FE LTDA                          */
        /*"AV1219* COD =  1414203 SERVICOS MEDICO SANTA FE LTDA                          */
        /*"AV1219* COD =   395036 SILAS ANTONIO ROSA                                     */
        /*"AV1219* COD =  1524345 SOCEIDADE BENEFICIENTE SAO CAMIL                       */
        /*"AV1219* COD =  1598268 SOCIEDADE HOSPITAL QUELUZ                              */
        /*"AV1219* COD =   137375 TARCIANO ROBERTO DE CARVALHO                           */
        /*"AV1219* COD =    15199 THELMO CARLOS QUICK                                    */
        /*"AV1219* COD =  1550738 THELMO CARLOS QUICK                                    */
        /*"AV1219* COD =  1610910 UROCLINICA DE JOINVILLE S/C LTDA                       */
        /*"AV1219* COD =  1662246 UROCLINICA DE JOINVILLE S/C LTDA                       */
        /*"AV1219* COD =  1585124 VIAVIDA CLINICA S/C LTDA                               */
        /*"AV1219* COD =  1605309 VIAVIDA CLINICA S/C LTDA                               */
        /*"AV1219* COD =   925634 VIVALDO SOARES NETO                                    */
        /*"AV1219* COD =  1306237 VIVENDACENTRO DE INTEGRAC�O SOCI                       */
        /*"AV1219* COD =  2336583 WAGNER DE OLIVEIRA SILVA                               */
        /*"AV1219* COD =  1332384 WAGNER JORGE HAGUIARA                                  */
        /*"AV1219* COD =  1414191 WAGNER JORGE HAGUIARA                                  */
        /*"AV1219* COD =  1561597 WTA MEDICINA DO TRABALHO S/C LTD                       */
        /*"AV1219* COD =  1605305 WTA MEDICINA DO TRABALHO S/C LTD                       */
        /*"AV1219* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6445/2005    *      */
        /*"AV1219* COD =    80471 PELLON & ASSOC.ADVOCACIA EMPRESARIAL S/C               */
        /*"      * ALTERADO POR ALEXIS(GESIS) EM 19/12/2005 PROCURAR AV1219       *      */
        /*"AV1229* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6600/2005    *      */
        /*"AV1229* COD =    2691751 - ADOF TRADUCOES E SERVICOS                          */
        /*"AV1229* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6612/2005    *      */
        /*"AV1229* COD =     105783 META-LIMPEZA CONSERVACAO LTDA                        */
        /*"      * ALTERADO POR ALEXIS(GESIS) EM 29/12/2005 PROCURAR AV1229       *      */
        /*"AV0102* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6622/2005    *      */
        /*"AV0102* COD =     2202592 QUALITY SOFTWARE LTDA                               */
        /*"AV0102* COD =     2336604 QUALITY SOFTWARE LTDA                               */
        /*"AV0102* COD =     2783011 VIVA NEG. IMOBILIARIOS& CONS EM                     */
        /*"      * ALTERADO POR ALEXIS(GESIS) EM 02/01/2006 PROCURAR AV0102       *      */
        /*"AV0103* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6673/2006    *      */
        /*"AV0103* COD =     1486194 CURSO DE LINGUA TRANSALPINA LTDA                    */
        /*"      * ALTERADO POR ALEXIS(GESIS) EM 03/01/2006 PROCURAR AV0103       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0106* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6818/2006           */
        /*"LA0106* - 2458113 IMPI - INST. DE MED. E PSIC. INT                            */
        /*"LA0106* - 2740666 OCUPACIONAL E ASSIST. SERVOCOS MEDICOS                      */
        /*"LA0106* - 2711476 CENTRO MEDICO SAMARITANO LTDA                               */
        /*"LA0106* - 2740664 SAMAR - CENTRO MEDICO SAMARITANO                            */
        /*"LA0106* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6850/2006           */
        /*"LA0106* - 2556871 CONSIST CONSULTORIA E SERVICOS T                            */
        /*"LA0106* - 2583195 CONSIST CONS.E SERVICOS TECNICOS                            */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 12/01/2006 PROCURAR LA0106        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0106* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 6903/2006           */
        /*"LB0106* - 2396118 MBA ORIENTACAO EM CARREIRAS LTDA                            */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 18/01/2006 PROCURAR LB0106        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0106* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7025/2006           */
        /*"LC0106* - 997908  ADPO - ACAD DESENV. PROF. ORGANIZ. LTDA                     */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 24/01/2006 PROCURAR LC0106        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0106* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7095/2006           */
        /*"LD0106* - 1830248  -  DAVID BAZAN & FILHOS LTDA                               */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 30/01/2006 PROCURAR LD0106        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0106* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7105/2006           */
        /*"LE0106* - 2749497 ADECCO TOP SERVICES S/A                                     */
        /*"LE0106* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 7105/2006                */
        /*"LE0106* - 1072868 SPIRIT INCENTIVO & FIDELIZACAO L                            */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 30/01/2006 PROCURAR LE0106        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0106* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7134/2006           */
        /*"LF0106* - 212074 APOIO LIDERANCA ASSES.CONTABIL L                             */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 30/01/2006 PROCURAR LF0106        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0206* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7162/2006           */
        /*"LA0206* - 2080761 A.D.O.F. TRADUCOES E SERV. TAQUIGRAFICOS                    */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 02/02/2006 PROCURAR LA0206        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0206* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7199/2006           */
        /*"LB0206* - 2202592 QUALITY SOFTWARE LTDA                                       */
        /*"LB0206* - 2794747 ADECCO TOP SERVICES RH LTDA                                 */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 02/02/2006 PROCURAR LB0206        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0206* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7250/2006           */
        /*"LC0206* - 105783 META-LIMPEZA CONSERVACAO LTDA                                */
        /*"LC0206* - 1275062 NASCIMENTO ROCHA LTDA                                       */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 03/02/2006 PROCURAR LC0206        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0206* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7274/2006           */
        /*"LD0206* - 1435697 JOAO PAULO VITORELLI - ME                                   */
        /*"LD0206* - 2770357 PACTUAL PERICIAS, CONS E REPRE L                            */
        /*"LD0206* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 7274/2006                */
        /*"LD0206*  COD=1084748 STAG CENTRAL DE ESTAGIOS LTDA                     *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 06/02/2006 PROCURAR LD0206        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0206* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7345/2006           */
        /*"LE0206* - 2703870 FABIANO IMOVEIS LTDA                                        */
        /*"LE0206* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7409/2006           */
        /*"LE0206* - 2480023 MBA ORIENTACAO EM CARREIRAS LTDA                            */
        /*"LE0206* - 2507186 C.S.M.ASSESS.CONSULT.TEC DE SEGU                            */
        /*"LE0206* - 94978 EXITOS VISTORIAS LTDA                                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 13/02/2006 PROCURAR LE0206        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0206* NAO RETER PIS, COFINS E CSLL EM ATENDIMENTO A SSI 7474/2006    *      */
        /*"LF0206* - 854156 - PRANDINIR RABBAT & ASSOCIATES FIN  LTDA             *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 17/02/2006 PROCURAR LF0206        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0206* INIBIR A RETENCAO DE ISS PARA SERVICOS TOMADOS DE AGENCIAMENTO *      */
        /*"LG0206* CORRETAGEM OU INTERMEDIACAO DE SEGUROS/PREVIDENCIA PRIVADA     *      */
        /*"LG0206* CONFORME DECRETO N.� 46.598, DE 4 DE NOVEMBRO DE 2005,         *      */
        /*"LG0206* FONTE = 21 (SAO PAULO) SSI 7347/2006                           *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 17/02/2006 PROCURAR LG0206        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LP0206* INIBIR A RETENCAO DE ISS DA EMPRESA PRIMOS PARTICIPACOES LTDA         */
        /*"LP0206* COD.PRODUTOR:102651  ESTIPULANTE  21  CNPJ:4055313000106 NA           */
        /*"LP0206* FONTE = 21 (SAO PAULO) SSI 7347/2006                           *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 17/02/2006 PROCURAR LP0206        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0306* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 7690/2006         *      */
        /*"LA0306*  COD=854156 - PRANDINIR RABBAT & ASSOCIATES FIN  LTDA          *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 03/03/2006 PROCURAR LA0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 7736/2006     *      */
        /*"LB0306*  COD=2490719 TREE ENSINO DE LINGUAS LTDA                       *      */
        /*"LB0306*  COD=3022481 GAMA CONSULTORES ASSOCIADOS LTDA                  *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 07/03/2006 PROCURAR LB0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 7814/2006     *      */
        /*"LC0306*  COD=105783 META-LIMPEZA CONSERVACAO LTDA                      *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 08/03/2006 PROCURAR LC0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 7826/2006            */
        /*"LD0306*  COD=3023544 COOPERATIVA PAULISTA DE TEATRO                           */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 08/03/2006 PROCURAR LD0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8146/2006            */
        /*"LE0306*  COD=1242185 DANDARO CONSTRUTORA LTDA                                 */
        /*"LE0306*  COD=1550701 GARTNER DO BRASIL                                        */
        /*"LE0306*  COD=2325459 DIGITAL CONSULTORIA E PUBLICIDAD                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 17/03/2006 PROCURAR LE0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0306* RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8202/2006                */
        /*"LF0306* - 2353403     CNP - M TECNOL. SERV. INFORMATICA  S.A                  */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 23/03/2006 PROCURAR LF0306        *      */
        /*"LG0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8206/2006            */
        /*"LG0306* - 99791 MERCER HUMAN RESOURCE CONSULTING                              */
        /*"LG0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8260/2006            */
        /*"LG0306* - 2158397 GJ INFORMACOES DE SEGUROS LTDA                              */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 23/03/2006 PROCURAR LG0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LH0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8339/2006            */
        /*"LH0306*  COD=438300 PAIVA & LAGUNA LTDA                                       */
        /*"LH0306*  COD=2725131 NEW QUALITY SERVICE EMPR. E SERV                         */
        /*"LH0306*  COD=1385077 APOIO LIDERANCA CONTABIL LTDA                            */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 28/03/2006 PROCURAR LH0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LI0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8388/2006            */
        /*"LI0306*  COD=2759168 XERFRAN ADVOCACIA S/S                                    */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 28/03/2006 PROCURAR LI0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LJ0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8421/2006            */
        /*"LJ0306*  COD=118303 IDEMP-INSTITUTO DE DESENV.EMPRES                          */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 29/03/2006 PROCURAR LJ0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LK0306*     RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8464/2006            */
        /*"LK0306*  COD=1674356 SPIRIT MARKETING PROMOCIONAL LTDA                        */
        /*"LK0306*  COD=2458113 IMPI - INST. DE MED. E PSIC. INTEGRADAS                  */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 30/03/2006 PROCURAR LK0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LL0306* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8464/2006            */
        /*"LL0306*  COD=1037836 AVANCO ENGENHARIA E CONSTRUCOES LTDA                     */
        /*"LL0306*  COD=228929 INTEGRACAO CONSULTORIA E TREINAMENTO                      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 30/03/2006 PROCURAR LL0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LM0306* ALTERAR ALIQUOTA DE ISS DE 5% PARA 2% ATENDIMENTO SSI 8455/2006*      */
        /*"LM0306* NOS SERVICOS DE AGENCIAMENTO, CORRETAGEM OU INTERMEDIACAO DE   *      */
        /*"LM0306* CAMBIO, DE SEGUROS, DE CARTOES DE CREDITO, DE PLANOS DE SAUDE E*      */
        /*"LM0306* DE PLANOS DE PREVIDENCIA PARA A FILIAL BRASILIA(5) E MATRIZ(10)*      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 30/03/2006 PROCURAR LM0306        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0406* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8567/2006            */
        /*"LA0406*  COD=3033165 JOHN SNOW DO BRASIL CONSULT.LTDA                         */
        /*"LA0406*  COD=2728085 SCOPUS TECNOLOGIA LTDA                                   */
        /*"LA0406*  COD=210886 TELCION TELECOMINICACOES E ELET                           */
        /*"LA0406*  COD=1593029 ATTIVA SERVI�OS GERAIS S/C LTDA                          */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 04/04/2006 PROCURAR LA0406        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0406* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8583/2006            */
        /*"LB0406*  COD=87181 HSM DO BRASIL LTDA                                         */
        /*"LB0406*  COD=3033555 HSM DO BRASIL LTDA                                       */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 05/04/2006 PROCURAR LB0406        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0406*     RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8665/2006            */
        /*"LC0406*  COD=2396118 MBA ORIENTACAO EM CARREIRAS LTDA                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 06/04/2006 PROCURAR LC0406        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0406* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8741/2006            */
        /*"LD0406*  COD=3033560 JOHN SNOW DO BRASIL CONSULTORIA                          */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 10/04/2006 PROCURAR LD0406        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0406* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8778/2006            */
        /*"LE0406*  COD=2188559 MANCUSO E ASSOC. PERICIAS CONTAB                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 12/04/2006 PROCURAR LE0406        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0406*     RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 8883/2006            */
        /*"LF0406*  COD=1030141   - PRICEWATERHOUSECOOPERS                               */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 18/04/2006 PROCURAR LF0406        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0406* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9005/2006            */
        /*"LG0406*  COD=845753  ILAL - CURSOS COMERCIO E SERVICO                         */
        /*"LG0406*  COD=3038350 LV ENGENHARIA SIMPLES LTDA                               */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 24/04/2006 PROCURAR LG0406        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LH0406* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9025/2006            */
        /*"LH0406*  COD=3038765 TEXT INFO LTDA                                           */
        /*"LH0406*  COD=1862630 ASTROL ADM DE SERVICOS TERCEIRIZADOS                     */
        /*"LH0406*  COD=1799646 ASTROL ADM. DE SERVICOS TERCEIRIZADOS                    */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 26/04/2006 PROCURAR LH0406        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0506* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9199/2006            */
        /*"LA0506*  COD=3041208 INTEGRACAO TREINAMENTO & MARKETI                         */
        /*"LA0506*  COD=1538140 INTEGRACAO TREINAMENTO & MARKETI                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 04/05/2006 PROCURAR LA0506        *      */
        /*"LA0506* CORRECAO DO CODIGO DO FORNECEDOR                                      */
        /*"LA0506*  COD=1538146 INTEGRACAO TREINAMENTO & MARKETI                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 05/05/2006 PROCURAR LA0506        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0506* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9321/2006            */
        /*"LB0506*  COD=3042575 DASEIN ASSESSORIA LTDA                                   */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 09/05/2006 PROCURAR LB0506        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0506* NAO RETER COFINS EM ATENDIMENTO A SSI 9410/2006                       */
        /*"LC0506*  COD=3043656 CAUDURO/MARTINO ARQUITETOS ASSOCIADOS LT                 */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 16/05/2006 PROCURAR LC0506        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0506* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9425/2006            */
        /*"LD0506*  COD=2188553 BERLITZ CENTRO DE IDIOMAS S/A                            */
        /*"LD0506*  COD=3044335 TASKFORCE TRABALHO TEMPORARIO LT                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 16/05/2006 PROCURAR LD0506        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0506* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9534/2006            */
        /*"LE0506*  COD=2612186 PM & A MARKENTING E COMUNICACAO                          */
        /*"LE0506*  COD=78221   MENSIS CONSTRUTORA LTDA                                  */
        /*"LE0506*  COD=3038800 MENSIS CONSTRUTORA LTDA                                  */
        /*"LE0506*  COD=967022  MENSIS CONSTRUTORA LTDA                                  */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 22/05/2006 PROCURAR LE0506        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0506* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9567/2006            */
        /*"LF0506*  COD=1385122 EUDS FURTADO                                             */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 22/05/2006 PROCURAR LF0506        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0506* NAO RETER COFINS EM ATENDIMENTO A SSI 9580/2006                       */
        /*"LG0506*  COD=3047278 CAUDURO/MARTINO ARQUITETOS E ASS                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 22/05/2006 PROCURAR LG0506        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LH0506* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9645/2006            */
        /*"LH0506*  COD=666907 TECNOCOOP INFORMATICA LTDA                                */
        /*"LH0506* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9662/2006            */
        /*"LH0506*  COD=3048107 IGNIS SERV IND COMERCIO LTDA                             */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 29/05/2006 PROCURAR LH0506        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LI0506* NAO RETER A COFINS EM ATENDIMENTO A SSI 9674/2006                     */
        /*"LI0506*     VOLTAR A RETER PIS E CSLL                                         */
        /*"LI0506*  COD=1385122 EUDS FURTADO                                             */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 30/05/2006 PROCURAR LI0506        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0606* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9767/2006            */
        /*"LA0606*  COD=123927 SANTOS & TOSTES -ADVOGADOS S/C                            */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 02/06/2006 PROCURAR LA0606        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0606*     RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9784/2006            */
        /*"LB0606*  COD=2325459 DIGITAL CONSULTORIA E PUBLICIDAD                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 02/06/2006 PROCURAR LB0606        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0606* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 9906/2006            */
        /*"LC0606*  COD=2119388 MICRO POWER COM DESENV DE SOFTWA                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 09/06/2006 PROCURAR LC0606        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0606* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 10002/2006           */
        /*"LD0606*  COD=2262793 ATIVA RECURSOS HUMANOS SERVICOS LTDA                     */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 19/06/2006 PROCURAR LD0606        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0606* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 10117/2006           */
        /*"LE0606*  COD=2297584 EXECUTIVA RECURSOS HUMANOS LTDA                          */
        /*"LE0606*  COD=2753576 EXECUTIVA RECURSOS HUMANOS LTDA                          */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 26/06/2006 PROCURAR LE0606        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0606* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 10187/2006           */
        /*"LF0606*  COD=3058286 3H TERCEIRIZACAO E SERVICOS LTDA                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 29/06/2006 PROCURAR LF0606        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0706* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 10312/2006    *      */
        /*"LA0706*  COD=1029828 OVERSEAS CONSULTORIA S/C LTDA                     *      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 04/07/2006 PROCURAR LA0706        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0706* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 10420/2006           */
        /*"LB0706*  COD=3061264 SPSP SISTEMA DE PREST DE SERVI�OS PADRON                 */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 10/07/2006 PROCURAR LB0706        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0706* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 10506/2006           */
        /*"LC0706*  COD=1242183 MARQUEZI ENGENHARIA S/C LTDA                             */
        /*"LC0706*  COD=3047283 JAIR ERNESTO DOS SANTOS                                  */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 13/07/2006 PROCURAR LC0706        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0706* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 10546/2006           */
        /*"LD0706*  COD=1206403 SENA & SENA LTDA                                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 17/07/2006 PROCURAR LD0706        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0706* NAO RETER COFINS EM ATENDIMENTO A SSI 10669/2006                      */
        /*"LE0706*  COD=3065223 CAUDURO MARTINO ARQUITETOS ASSOCIADOS                    */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 25/07/2006 PROCURAR LE0706        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0706* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 10696/2006           */
        /*"LF0706*  COD=1208507 TOP PROJETOS E COSTRUCOES LTDA                           */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 28/07/2006 PROCURAR LF0706        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0706* ALTERA A ALIQUOTA ISS DA FONTE 12(BELO HORIZONTE) SSI 10713/2006      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 28/07/2006 PROCURAR LG0706        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0806* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 10892/2006           */
        /*"LA0806*  COD=3033553 SIRIUS VISTORIAS LTDA                                    */
        /*"LA0806*  COD=3034406 CLAUDOMIRO VIDAL VISTORIA ME                             */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 08/08/2006 PROCURAR LA0806        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0806* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11031/2006           */
        /*"LB0806*  COD=1177276 PASCAL COMERCIO E CONSTRUCAO LTD                         */
        /*"LB0806*  COD=1142438 LC ENGENHARIA E CONSTRUCOES LTDA                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 15/08/2006 PROCURAR LB0806        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0806* SSI 11035/2006 - ELIMINA ISS EM FILIAIS INATIVAS (023, 025, 011)      */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 16/08/2006 PROCURAR LC0806        *      */
        /*"LD0806* SSI 11035/2006 - ELIMINA ISS SOBRE O SERVICO DE AGENCIAMENTO/         */
        /*"      *                  CORRETAGEM NAS FONTES 02, 020, 027, 026 E 015        */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 16/08/2006 PROCURAR LD0806        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0806* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11045/2006           */
        /*"LE0806*  COD=899746 CORPO RECRUTAMENTO  SELECAO TREI                          */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 17/08/2006 PROCURAR LE0806        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LF0806* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11079/2006           */
        /*"LF0806*  COD=3072085 FEEDBACK CONSULTORIA E TREINAMEN                         */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 23/08/2006 PROCURAR LF0806        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0806* NAO RETER COFINS EM ATENDIMENTO A SSI 11079/2006                      */
        /*"LG0806*  COD=3072118 DINAMARCO & ROSSI ADVOCACIA                              */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 23/08/2006 PROCURAR LG0806        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LH0806* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11162/2006           */
        /*"LH0806*  COD=1176088 INFANTI ENGENHARIA E ARQUITETURA LTDA                    */
        /*"LH0806*  COD=1208512 SILVA FILHO ENGENHARIA CONSULTORIA LTDA                  */
        /*"LH0806*  COD=1206387 PAULO JUAREZ BEHR                                        */
        /*"LH0806*  COD=3072744 BSI BRASIL SISTEMAS DE GESTAO LTDA                       */
        /*"LH0806*  COD=1103847 MODELO ENGENHARIA LTDA                                   */
        /*"LH0806*  COD=2007368 ENGENHO CONSTRUCOES LTDA                                 */
        /*"LH0806*  COD=1878896 JOSE NORBERTO MARCHIORI DE FRANCESCHI                    */
        /*"LH0806*  COD=1242180 AVAL ENGENHARIA E CONSULTORIA LTDA                       */
        /*"LH0806*  COD=1211491 ATRIO ENGENHARIA E REPRESENTACOES LTDA,                  */
        /*"LH0806*  COD=2753574 EXACTA ASSESSORIA E CONSULTORIA S/S LTDA                 */
        /*"LH0806*  COD=1206388 ENGEAPE ENG. DE AVALIACOES E PERICIAS SC                 */
        /*"LH0806*  COD=1139689 NCR ENGENHARIA DE AVAL. E CONSULTORIA                    */
        /*"LH0806*  COD=1208539 SCS ENG. AVAL. E PERICIAS LTDA                           */
        /*"LH0806*  COD=1242182 BORDIN ENGENHARIA E CONSTRUCOES LTDA                     */
        /*"LH0806*  COD=1142422 DMC ENGENHARIA, AVAL E CONSTRUCAO LTDA                   */
        /*"LH0806*  COD=1142438 LC ENGENHARIA E CONSTRUCOES LTDA                         */
        /*"LH0806*  COD=1211490 JOSE LUCIANO AGUIAR LIRA & CIA LTDA                      */
        /*"LH0806*  COD=1264459 HEXAGONO ENGENHARIA LTDA                                 */
        /*"LH0806*  COD=1206385 INCORP-INCORP. GERENC. DE EMPREEND.IMOB                  */
        /*"      * ALTERADO POR LIGIA(GESIS) EM 28/08/2006 PROCURAR LH0806        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0906* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11384/2006           */
        /*"LA0906*  COD=3067186 MARIAH SERVICOS TERCEIRIZADOS LTDA                       */
        /*"LA0906*  COD=580650  FABIO RIMET BORGES MACHADO                               */
        /*"LA0906*  COD=1429787 FABIO RIMET BORGES MACHADO                               */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 12/09/2006 PROCURAR LA0906       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0906* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11591/2006           */
        /*"LB0906*  COD=3078454 CR BASSO CONSULTORIA E TREINAMEN                         */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 27/09/2006 PROCURAR LB0906       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0906* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11616/2006           */
        /*"LC0906*  COD=3043670 - E-CLIP SISTEMA DE INFORMACAO                           */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 28/09/2006 PROCURAR LC0906       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA1006* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11759/2006           */
        /*"LA1006*  COD=3078932 FIALHO & DUARTE ASS. CONS. EM CO                         */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 05/10/2006 PROCURAR LA1006       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB1006* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11826/2006           */
        /*"LB1006*  COD=3078996 INFORMA LA PLANEJAMENTO E ORG DE                         */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 11/10/2006 PROCURAR LB1006       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC1006* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 11997/2006           */
        /*"LC1006*  COD=1220151 MODULO SECURITY SOLUTIONS S/A                            */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 27/10/2006 PROCURAR LC1006       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA1106* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 12091/2006           */
        /*"LA1106*  COD=1275062 NASCIMENTO ROCHA LTDA                                    */
        /*"LA1106*  COD=1215263 AVALIZAN ENGENHARIA E AVALIACOES                         */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 06/11/2006 PROCURAR LA1106       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB1106* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 12148/2006           */
        /*"LB1106*  COD=3079992 LABORH SERVICOS EMPRESARIAIS                             */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 07/11/2006 PROCURAR LB1106       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC1106* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 12291/2006           */
        /*"LC1106*  COD=3050410 TI & COM CONSULT. PROJ. TECNOL.                          */
        /*"LC1106*  COD=1915342 QUANTUM ENGENHARIA DE AVALIACOES                         */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 20/11/2006 PROCURAR LC1106       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD1106* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 12348/2006           */
        /*"LD1106*  COD=3048097 INSO-INFORMATICA E SERVICO S/C                           */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 23/11/2006 PROCURAR LD1106       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG1206* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 12566/2006           */
        /*"LG1206*  COD=3081542 PEOPLE DOMUS ASSESSORIA RH LTDA                          */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 08/12/2006 PROCURAR LG1206       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"AV1206* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 12629/2006           */
        /*"AV1206*  COD= 3081746 BRASILMED AUDI MEDICA & SERVICOS                        */
        /*"      * ALTERADO POR ALEXIS(GECORP) EM 14/12/2006 PROCURAR AV1206      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"AV0107* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 12840/2007           */
        /*"AV0107*  COD= 3079509 AFIXCODE CONSULTORIA EM INFORMAT                        */
        /*"      * ALTERADO POR ALEXIS(GECORP) EM 03/01/2007 PROCURAR AV0107      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0207* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 13184/2007           */
        /*"LA0207*  COD=1208542 FINDER ENGENHARIA LTDA                                   */
        /*"LA0207*  COD=1450411 CABERO ENGENHARIA AVALIACOES E P                         */
        /*"LA0207*  COD=1034479 KAMIL SALSANI ENGENHARIA LTDA                            */
        /*"LA0207*  COD=1290990 REAL VALOR ENGENHARIA S/C LTDA                           */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 02/02/2007 PROCURAR LA0207       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0207* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 13476/2007           */
        /*"LB0207*  COD=3114798 AR LIMPO TECNOL DE CLIMATIZACAO                          */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 09/02/2007 PROCURAR LB0207       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0207* VOLTAR A RETER PIS, COFINS E CSLL - ATENDIMENTO SSI 13476/2007        */
        /*"LC0207*  COD=3081542 PEOPLE DOMUS ASSESSORIA RH LTDA                          */
        /*"LG1206*  COD=3081542 PEOPLE DOMUS ASSESSORIA RH LTDA                          */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 09/02/2007 PROCURAR LC0207       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0307* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 14564/2007           */
        /*"LA0307*  COD=3079509 AFIXCODE CONSULTORIA EM INFORMATICA LTDA                 */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 28/03/2007 PROCURAR LA0307       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0307* NAO RETER COFINS EM ATENDIMENTO A SSI 14564/2007                      */
        /*"LB0307*  COD=3116720 ARISTIDES JUNQUEIRA ADVOGADOS AS                         */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 28/03/2007 PROCURAR LB0307       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0407* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 14920/2007           */
        /*"LA0407*  COD=3117429 INSTITUTO TREVISAN DO CONHECIMENTO                       */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 13/04/2007 PROCURAR LA0407       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0407* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 15235/2007           */
        /*"LB0407*  COD=3118024  EMPREZA CONSULTORE ASSOCIADOS                           */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 30/04/2007 PROCURAR LB0407       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0507* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 15472/2007           */
        /*"LA0507*  COD=3118684  NORBER ENGENHARIA LTDA                                  */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 14/05/2007 PROCURAR LA0507       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0507* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 15848/2007           */
        /*"LB0507*  COD=2438961 EQUIFAX DO BRASIL LTDA                                   */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 29/05/2007 PROCURAR LB0507       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0607* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 16056/2007           */
        /*"LA0607*  COD=3120062 - BETTER RECURSOS HUMANOS LTDA                           */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 11/06/2007 PROCURAR LA0607       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0607* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 16111/2007           */
        /*"LB0607*  COD=3120160 - CENTRO DE TREINAMENTO E LAZER - LAJE INN               */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 11/06/2007 PROCURAR LB0607       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0607* NAO RETER COFINS EM ATENDIMENTO A SSI 16456/2007                      */
        /*"LC0607*  COD=3120818 - VELLOZA GIROTTO E LINDENBOJM ADVOGADOS                 */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 25/06/2007 PROCURAR LC0607       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0607* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 16479/2007           */
        /*"LD0607*  COD=3117755 - EASYWAY DO BRASIL                                      */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 25/06/2007 PROCURAR LD0607       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LA0707* NAO RETER COFINS EM ATENDIMENTO A SSI 16674/2007                      */
        /*"LA0707*  COD= 79651 LINCES VISTORIAS E SERV                                   */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 03/07/2007 PROCURAR LA0707       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LB0707* VOLTAR A RETER COFINS EM ATENDIMENTO A SSI 16684/2007                 */
        /*"LB0707*  COD=3116720 - ARISTIDES JUNQUEIRA ADVOGADOS ASSOCIADO                */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 06/07/2007 PROCURAR LB0707       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0707* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 16700/2007           */
        /*"LC0707*  COD=3078579 PARTNER CEO CONSULT. PUBLIC                              */
        /*"LC0707*  COD=  79651 LINCES VISTORIAS E SERVICOS S/C                          */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 06/07/2007 PROCURAR LC0707       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LD0707* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 16827/2007           */
        /*"LD0707*  COD=3121711 - THSYSTEM CONSULTORIA EM INFORMATICA LTDA               */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 13/07/2007 PROCURAR LD0707       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LE0707* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 16899/2007           */
        /*"LE0707*  COD=3121921 - DELTA FORCE LTDA                                       */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 13/07/2007 PROCURAR LE0707       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0408* NAO RETER PIS,COFINS E CSLL EM ATENDIMENTO A SSI 21599/2008           */
        /*"LG0408*  COD=80845 MA GAZEL ASSES.MEDICA SECURITARIA                          */
        /*"LG0408*  COD=961616 MA GAZEL ASSESSORIA M�DICO SECURIT�RIA                    */
        /*"LG0408*  COD=3129354 MA GAZEL ASSESSORIA SECURITARIA S/C LTDA                 */
        /*"LG0408*  COD=3074213 FERNANDO CARVALHO SERVI�OS M�DICOS LTDA                  */
        /*"LG0408*  COD=3049533 FERNANDO CARVALHO SERVICOS MEDICOS LTDA                  */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 25/04/2008 PROCURAR LG0408       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0409* LIBERA A RETENCAO DO ISS PARA A FILIAL SAO PAULO                      */
        /*"LG0409* FONTE = 21 (SAO PAULO) SSI 24221/2009                                 */
        /*"      * ALTERADO POR LIGIA(GECORP) EM 24/04/2009 PROCURAR LG0409       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERARCAO - 23/05/2014 WELLINGTON F R C VERAS - TE39902       *      */
        /*"      *              ALTERAR A ALIQUOTA DE RETENCAO DO ISS EM          *      */
        /*"      * CADMUS:      BELO HORIZONTE  DE 2% PARA 2,5 %.                *       */
        /*"      * C98258       ALTERACAO PUBLICADA NA LEI N� 10.692.             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"150292* ALTERADO POR WANGER - 02/05/2017                                      */
        /*"150292* PROCURAR POR - 150292***                                              */
        /*"150292* LIBERAR PIS,COFINS E CSLL EM ATENDIMENTO A CADMUS 150292/2017         */
        /*"150292* DOS SEGUINTES CODIGOS DE FAVORECIDOS:                                 */
        /*"      *CADASTRO NOME                                 CNPJ                     */
        /*"      *1206388  ENGEAPE ENG.AVALIACOES E PERIC SC    01204592000126           */
        /*"      *1242185  DANDARO CONSTRUTORA LTDA.            01250756000151           */
        /*"      *1290990  REAL VALOR ENGENHARIA S/C LTDA.      01262707000139           */
        /*"      *1208539  SCS ENG. AVAL. E PERICIAS LTDA.      02303810000142           */
        /*"      *1242180  AVAL ENGENHARIA E CONSULTORIA LTDA.  02314096000198           */
        /*"      *2753574  EXACTA ASSESS E CONSULT S/S LTDA     07169775000134           */
        /*"      *2740607  EXACTA ASSESS E CONSULTORIA S/S LTDA 07169775000134           */
        /*"      *1264459  HEXAGONO ENG LTDA                    02404171000101           */
        /*"      *4375466  LC ENGENHARIA E CONSTRUCOES LTDA.    11059417000146           */
        /*"      *1142438  LC ENGENHARIA E CONSTRUCOES LTDA.    11059417000146           */
        /*"      *1208542  FINDER ENGENHARIA LTDA.              02470598000108           */
        /*"150292*                                                                       */
        /*"150292*                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"VERSAO* ULTIMA VERSAO                      (VERSAO V28-05-2017)        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-QTDE                 PIC S9(004)    COMP.*/
        public IntBasis VIND_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-QTDE                PIC S9(009)    COMP.*/
        public IntBasis WHOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FONT-FONTE        PIC S9(004)      COMP.*/
        public IntBasis V1FONT_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FONT-PCDESISS     PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1FONT_PCDESISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1FONT-NOMEFTE      PIC  X(040).*/
        public StringBasis V1FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1IRF-ALQIPT     PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1IRF_ALQIPT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1IRF-VALDDU     PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V1IRF_VALDDU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2IRF-VALBRU     PIC S9(013)V99   COMP-3 VALUE +0.*/
        public DoubleBasis V2IRF_VALBRU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V3IRF-VALDEP     PIC S9(013)V99   COMP-3 VALUE +0.*/
        public DoubleBasis V3IRF_VALDEP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V4IRF-LIMSUP     PIC S9(013)V99   COMP-3 VALUE +0.*/
        public DoubleBasis V4IRF_LIMSUP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WS-DTINIREF      PIC  X(010).*/
        public StringBasis WS_DTINIREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WS-DTFIMREF      PIC  X(010).*/
        public StringBasis WS_DTFIMREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1FAVO-CODFAV       PIC S9(009) COMP.*/
        public IntBasis V1FAVO_CODFAV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FAVO-NOMFAV       PIC  X(040).*/
        public StringBasis V1FAVO_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1FAVO-NUMREC       PIC S9(009) COMP    VALUE  ZEROS.*/
        public IntBasis V1FAVO_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FAVO-TPPESSOA     PIC  X(001)         VALUE  SPACES*/
        public StringBasis V1FAVO_TPPESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1FAVO-PCTIRF       PIC S9(003)V99 COMP-3 VALUE ZEROS*/
        public DoubleBasis V1FAVO_PCTIRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1FAVO-CODSVI       PIC S9(004) COMP    VALUE  ZEROS.*/
        public IntBasis V1FAVO_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FAVO-TIPREG       PIC  X(001)         VALUE  SPACES*/
        public StringBasis V1FAVO_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1FAVO-INSPREFE     PIC S9(015) COMP-3  VALUE  ZEROS.*/
        public IntBasis V1FAVO_INSPREFE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1FAVO-INSESTAD     PIC S9(015) COMP-3  VALUE  ZEROS.*/
        public IntBasis V1FAVO_INSESTAD { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1FAVO-DCOIRF       PIC  X(001)         VALUE  SPACES*/
        public StringBasis V1FAVO_DCOIRF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1FAVO-INSINPS      PIC S9(015) COMP-3  VALUE  ZEROS.*/
        public IntBasis V1FAVO_INSINPS { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1FAVO-CGCCPF       PIC S9(015) COMP-3  VALUE  ZEROS.*/
        public IntBasis V1FAVO_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1FAVO-DCOISS       PIC  X(001)         VALUE  SPACES*/
        public StringBasis V1FAVO_DCOISS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1FAVO-NUMDEPIRF    PIC S9(004) COMP    VALUE  ZEROS.*/
        public IntBasis V1FAVO_NUMDEPIRF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FAVO-CODSVISS     PIC S9(004) COMP    VALUE  ZEROS.*/
        public IntBasis V1FAVO_CODSVISS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FAVO-DCOINSS      PIC  X(001)         VALUE  SPACES*/
        public StringBasis V1FAVO_DCOINSS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1FAVO-PCTINSS      PIC S9(003)V99 COMP-3 VALUE ZEROS*/
        public DoubleBasis V1FAVO_PCTINSS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1FAVO-FONTE        PIC S9(004) COMP    VALUE  ZEROS.*/
        public IntBasis V1FAVO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FAVO-CEP          PIC S9(009) COMP    VALUE  ZEROS.*/
        public IntBasis V1FAVO_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FAVO-DATA-ALT-CC  PIC  X(010).*/
        public StringBasis V1FAVO_DATA_ALT_CC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         VIND-DTALTCC        PIC S9(004)    COMP.*/
        public IntBasis VIND_DTALTCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FAVO-PCDESISS     PIC S9(003)V99 COMP-3 VALUE ZEROS*/
        public DoubleBasis V1FAVO_PCDESISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         VIND-PCDESISS       PIC S9(004)    COMP.*/
        public IntBasis VIND_PCDESISS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FAVO-OPT-SIMPLES-M PIC  X(001)        VALUE  SPACES*/
        public StringBasis V1FAVO_OPT_SIMPLES_M { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V2FAVO-DCOISS       PIC  X(001)         VALUE  SPACES*/
        public StringBasis V2FAVO_DCOISS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V2FAVO-IDECBT       PIC S9(004) COMP    VALUE  ZEROS.*/
        public IntBasis V2FAVO_IDECBT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V2FAVO-CODVIN       PIC S9(004) COMP    VALUE  ZEROS.*/
        public IntBasis V2FAVO_CODVIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V4FAVO-DATA-NASC    PIC  X(010).*/
        public StringBasis V4FAVO_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         VIND-DTNASC         PIC S9(004)    COMP.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V4FAVO-INV-PERMANENTE PIC  X(001).*/
        public StringBasis V4FAVO_INV_PERMANENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-CODEMP        PIC S9(009) COMP.*/
        public IntBasis WHOST_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0REND-DATRDT       PIC  X(010).*/
        public StringBasis V0REND_DATRDT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0REND-VALRDT       PIC S9(013)V99             COMP-3*/
        public DoubleBasis V0REND_VALRDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0REND-CODEMP       PIC S9(009)                COMP.*/
        public IntBasis V0REND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0REND-SITUACAO     PIC  X(001).*/
        public StringBasis V0REND_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0REND-CODSVI       PIC S9(004) COMP    VALUE  ZEROS.*/
        public IntBasis V0REND_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1REND-VALRDT       PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V1REND_VALRDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0IMPO-DATIPT       PIC  X(010).*/
        public StringBasis V0IMPO_DATIPT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0IMPO-TIPIPT       PIC  X(001).*/
        public StringBasis V0IMPO_TIPIPT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0IMPO-VALIPT       PIC S9(013)V99             COMP-3*/
        public DoubleBasis V0IMPO_VALIPT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0IMPO-CODEMP       PIC S9(009)                COMP.*/
        public IntBasis V0IMPO_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0IMPO-SITUACAO     PIC  X(001).*/
        public StringBasis V0IMPO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0IMPO-CODSVI       PIC S9(004) COMP    VALUE  ZEROS.*/
        public IntBasis V0IMPO_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1IMPO-VLIMPOST     PIC S9(013)V99             COMP-3*/
        public DoubleBasis V1IMPO_VLIMPOST { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         AREA-DE-WORK.*/
        public FI0100S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new FI0100S_AREA_DE_WORK();
        public class FI0100S_AREA_DE_WORK : VarBasis
        {
            /*"  05       WS-VLBASINSS       PIC S9(013)V99.*/
            public DoubleBasis WS_VLBASINSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       DISPLAY-VALOR      PIC ZZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_VALOR { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZZZ9V99-."), 3);
            /*"  05       DISPLAY-VALIRF     PIC ZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_VALIRF { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99-."), 3);
            /*"  05       DISPLAY-VALISS     PIC ZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_VALISS { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99-."), 3);
            /*"  05       DISPLAY-PCTIRF     PIC Z9,99.*/
            public DoubleBasis DISPLAY_PCTIRF { get; set; } = new DoubleBasis(new PIC("9", "2", "Z9V99."), 2);
            /*"  05       DISPLAY-PCDESISS   PIC Z9,99.*/
            public DoubleBasis DISPLAY_PCDESISS { get; set; } = new DoubleBasis(new PIC("9", "2", "Z9V99."), 2);
            /*"  05       DISPLAY-VLRDED     PIC ZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_VLRDED { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99-."), 3);
            /*"  05       DISPLAY-VALDEP     PIC ZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_VALDEP { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99-."), 3);
            /*"  05       DISPLAY-VALDDUDEP  PIC ZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_VALDDUDEP { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99-."), 3);
            /*"  05       DISPLAY-VALINSS    PIC ZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_VALINSS { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99-."), 3);
            /*"  05       DISPLAY-PCTINSS    PIC Z9,99.*/
            public DoubleBasis DISPLAY_PCTINSS { get; set; } = new DoubleBasis(new PIC("9", "2", "Z9V99."), 2);
            /*"  05       DISPLAY-CODFAV     PIC ZZZZZZ999.*/
            public IntBasis DISPLAY_CODFAV { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZ999."));
            /*"  05       DISPLAY-FONTE      PIC 9(02).*/
            public IntBasis DISPLAY_FONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"  05       DISPLAY-EMPRESA    PIC 9(02).*/
            public IntBasis DISPLAY_EMPRESA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"  05       DISPLAY-LIMSUP     PIC ZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_LIMSUP { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99-."), 3);
            /*"  05       DISPLAY-VLBASE     PIC ZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_VLBASE { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99-."), 3);
            /*"  05       WS-CALC-VALLIQ     PIC S9(013)V99.*/
            public DoubleBasis WS_CALC_VALLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       DISPLAY-VALLIQ     PIC ZZZZZ9,99-.*/
            public DoubleBasis DISPLAY_VALLIQ { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99-."), 3);
            /*"  05       WS-VLR-ISENTO-IR   PIC S9(013)V99  VALUE ZEROS.*/
            public DoubleBasis WS_VLR_ISENTO_IR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WS-EH-ISENTO-IR    PIC  X(001)     VALUE 'N'.*/
            public StringBasis WS_EH_ISENTO_IR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05       WS-EH-ISENTO-ISS   PIC  X(001)     VALUE 'N'.*/
            public StringBasis WS_EH_ISENTO_ISS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05       WS-EH-MAIOR-65ANOS PIC  X(001)     VALUE 'N'.*/
            public StringBasis WS_EH_MAIOR_65ANOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05       WS-TEM-DESC-100    PIC  X(001)     VALUE 'N'.*/
            public StringBasis WS_TEM_DESC_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05       WS-DTANO           PIC  9(004)    VALUE  ZEROS.*/
            public IntBasis WS_DTANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       WS-RESTO           PIC  9(004)    VALUE  ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       WS-MENSAGEM.*/
            public FI0100S_WS_MENSAGEM WS_MENSAGEM { get; set; } = new FI0100S_WS_MENSAGEM();
            public class FI0100S_WS_MENSAGEM : VarBasis
            {
                /*"    07     FILLER             PIC  X(076).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "76", "X(076)."), @"");
                /*"    07     WS-TIPO-SERV       PIC  X(001).*/
                public StringBasis WS_TIPO_SERV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05       WS-NUMREC          PIC  9(008)    VALUE  ZEROS.*/
            }
            public IntBasis WS_NUMREC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05       FILLER             REDEFINES      WS-NUMREC.*/
            private _REDEF_FI0100S_FILLER_1 _filler_1 { get; set; }
            public _REDEF_FI0100S_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_FI0100S_FILLER_1(); _.Move(WS_NUMREC, _filler_1); VarBasis.RedefinePassValue(WS_NUMREC, _filler_1, WS_NUMREC); _filler_1.ValueChanged += () => { _.Move(_filler_1, WS_NUMREC); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WS_NUMREC); }
            }  //Redefines
            public class _REDEF_FI0100S_FILLER_1 : VarBasis
            {
                /*"    07     WS-ANOREC          PIC  9(004).*/
                public IntBasis WS_ANOREC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    07     WS-SEQREC          PIC  9(004).*/
                public IntBasis WS_SEQREC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  WS-MESANO.*/

                public _REDEF_FI0100S_FILLER_1()
                {
                    WS_ANOREC.ValueChanged += OnValueChanged;
                    WS_SEQREC.ValueChanged += OnValueChanged;
                }

            }
            public FI0100S_WS_MESANO WS_MESANO { get; set; } = new FI0100S_WS_MESANO();
            public class FI0100S_WS_MESANO : VarBasis
            {
                /*"    07  WS-ANO                  PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    07  FILLER                  PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    07  WS-MES                  PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    07  FILLER                  PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    07  WS-DIA                  PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05  WS-MESANO-R  REDEFINES  WS-MESANO                                PIC  X(010).*/
            }
            private _REDEF_StringBasis _ws_mesano_r { get; set; }
            public _REDEF_StringBasis WS_MESANO_R
            {
                get { _ws_mesano_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WS_MESANO, _ws_mesano_r); VarBasis.RedefinePassValue(WS_MESANO, _ws_mesano_r, WS_MESANO); _ws_mesano_r.ValueChanged += () => { _.Move(_ws_mesano_r, WS_MESANO); }; return _ws_mesano_r; }
                set { VarBasis.RedefinePassValue(value, _ws_mesano_r, WS_MESANO); }
            }  //Redefines
            /*"01       FILLER.*/
        }
        public FI0100S_FILLER_4 FILLER_4 { get; set; } = new FI0100S_FILLER_4();
        public class FI0100S_FILLER_4 : VarBasis
        {
            /*"  05        WDAT-INVERT       PIC  9(008)    VALUE ZEROS.*/
            public IntBasis WDAT_INVERT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05        FILLER            REDEFINES      WDAT-INVERT.*/
            private _REDEF_FI0100S_FILLER_5 _filler_5 { get; set; }
            public _REDEF_FI0100S_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_FI0100S_FILLER_5(); _.Move(WDAT_INVERT, _filler_5); VarBasis.RedefinePassValue(WDAT_INVERT, _filler_5, WDAT_INVERT); _filler_5.ValueChanged += () => { _.Move(_filler_5, WDAT_INVERT); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WDAT_INVERT); }
            }  //Redefines
            public class _REDEF_FI0100S_FILLER_5 : VarBasis
            {
                /*"    10      WDAT-INV-ANO      PIC  9(004).*/
                public IntBasis WDAT_INV_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WDAT-INV-MES      PIC  9(002).*/
                public IntBasis WDAT_INV_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WDAT-INV-DIA      PIC  9(002).*/
                public IntBasis WDAT_INV_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDAT-CC.*/

                public _REDEF_FI0100S_FILLER_5()
                {
                    WDAT_INV_ANO.ValueChanged += OnValueChanged;
                    WDAT_INV_MES.ValueChanged += OnValueChanged;
                    WDAT_INV_DIA.ValueChanged += OnValueChanged;
                }

            }
            public FI0100S_WDAT_CC WDAT_CC { get; set; } = new FI0100S_WDAT_CC();
            public class FI0100S_WDAT_CC : VarBasis
            {
                /*"    10      WDAT-CC-ANO         PIC  9(004).*/
                public IntBasis WDAT_CC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-CC-MES         PIC  9(002).*/
                public IntBasis WDAT_CC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-CC-DIA         PIC  9(002).*/
                public IntBasis WDAT_CC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDAT-NASC.*/
            }
            public FI0100S_WDAT_NASC WDAT_NASC { get; set; } = new FI0100S_WDAT_NASC();
            public class FI0100S_WDAT_NASC : VarBasis
            {
                /*"    10      WDAT-NASC-ANO       PIC  9(004).*/
                public IntBasis WDAT_NASC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-NASC-MES       PIC  9(002).*/
                public IntBasis WDAT_NASC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-NASC-DIA       PIC  9(002).*/
                public IntBasis WDAT_NASC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WS-CALC-ANOS        PIC  9(003)    VALUE  ZEROS.*/
            }
            public IntBasis WS_CALC_ANOS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05        DISPLAY-ANOS        PIC  9(003)    VALUE  ZEROS.*/
            public IntBasis DISPLAY_ANOS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05        WS-PRIMEIRA-VEZ     PIC  X(003)    VALUE  'SIM'.*/
            public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
            /*"01          WS-DS0104.*/
        }
        public FI0100S_WS_DS0104 WS_DS0104 { get; set; } = new FI0100S_WS_DS0104();
        public class FI0100S_WS_DS0104 : VarBasis
        {
            /*"  05        WS-VLR-CSLL         PIC S9(013)V9(2) COMP-3 VALUE +0*/
            public DoubleBasis WS_VLR_CSLL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05        WS-VLR-COFINS       PIC S9(013)V9(2) COMP-3 VALUE +0*/
            public DoubleBasis WS_VLR_COFINS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05        WS-VLR-PISPASEP     PIC S9(013)V9(2) COMP-3 VALUE +0*/
            public DoubleBasis WS_VLR_PISPASEP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05        DISPLAY-VLRCSL      PIC ZZZZ.ZZ9,99-.*/
            public DoubleBasis DISPLAY_VLRCSL { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99-."), 3);
            /*"  05        DISPLAY-VLRCOF      PIC ZZZZ.ZZ9,99-.*/
            public DoubleBasis DISPLAY_VLRCOF { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99-."), 3);
            /*"  05        DISPLAY-VLRPIS      PIC ZZZZ.ZZ9,99-.*/
            public DoubleBasis DISPLAY_VLRPIS { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99-."), 3);
            /*"  05        WS-CODSVI-CSLL      PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WS_CODSVI_CSLL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        WS-CODSVI-COFINS    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WS_CODSVI_COFINS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        WS-CODSVI-PISPASEP  PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WS_CODSVI_PISPASEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01       FILLER.*/
        }
        public FI0100S_FILLER_10 FILLER_10 { get; set; } = new FI0100S_FILLER_10();
        public class FI0100S_FILLER_10 : VarBasis
        {
            /*"  05        WABEND.*/
            public FI0100S_WABEND WABEND { get; set; } = new FI0100S_WABEND();
            public class FI0100S_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(009) VALUE           'FI0100S '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FI0100S ");
                /*"    10      FILLER              PIC  X(035) VALUE           ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-IMPOSTOS.*/
            }
        }
        public FI0100S_LK_IMPOSTOS LK_IMPOSTOS { get; set; } = new FI0100S_LK_IMPOSTOS();
        public class FI0100S_LK_IMPOSTOS : VarBasis
        {
            /*"    03      LK-ATUALIZA    PIC  X(001).*/
            public StringBasis LK_ATUALIZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-IDTRIBUTA   PIC  X(001).*/
            public StringBasis LK_IDTRIBUTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-PROGRAMA    PIC  X(007).*/
            public StringBasis LK_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"    03      LK-FONTE       PIC S9(004)    COMP.*/
            public IntBasis LK_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03      LK-TIPFAV      PIC  X(001).*/
            public StringBasis LK_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-TIPREG      PIC  X(001).*/
            public StringBasis LK_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-CODFAV      PIC S9(009)    COMP.*/
            public IntBasis LK_CODFAV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03      LK-VALBRU      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALBRU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-DTMOVABE    PIC  X(010).*/
            public StringBasis LK_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03      LK-DCOIRF      PIC  X(001).*/
            public StringBasis LK_DCOIRF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-PCTIRF      PIC S9(003)V99 COMP-3.*/
            public DoubleBasis LK_PCTIRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    03      LK-DCOISS      PIC  X(001).*/
            public StringBasis LK_DCOISS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-PCDESISS    PIC S9(003)V99 COMP-3.*/
            public DoubleBasis LK_PCDESISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    03      LK-NOMFAV      PIC  X(040).*/
            public StringBasis LK_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03      LK-NUMREC      PIC S9(009)    COMP.*/
            public IntBasis LK_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03      LK-VALISS      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-VALIRF      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALIRF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-VALIAP      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALIAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-NOMEFTE     PIC  X(040).*/
            public StringBasis LK_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03      LK-TPPESSOA    PIC  X(001).*/
            public StringBasis LK_TPPESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-CODSVI      PIC S9(004)    COMP.*/
            public IntBasis LK_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03      LK-INSPREFE    PIC S9(015)    COMP-3.*/
            public IntBasis LK_INSPREFE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    03      LK-INSINPS     PIC S9(015)    COMP-3.*/
            public IntBasis LK_INSINPS { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    03      LK-CGCCPF      PIC S9(015)    COMP-3.*/
            public IntBasis LK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    03      LK-EXEC-SQL    PIC  X(004).*/
            public StringBasis LK_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    03      LK-RETCODE     PIC S9(004)    COMP.*/
            public IntBasis LK_RETCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03      LK-MENSAGEM    PIC  X(077).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(077)."), @"");
            /*"    03      LK-VALDDUDEP   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALDDUDEP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-DCOINSS     PIC  X(001).*/
            public StringBasis LK_DCOINSS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-PCTINSS     PIC S9(003)V99 COMP-3.*/
            public DoubleBasis LK_PCTINSS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    03      LK-VALINSS     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALINSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-EMPRESA     PIC S9(009)    COMP.*/
            public IntBasis LK_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        }


        public Dclgens.RELCHSIV RELCHSIV { get; set; } = new Dclgens.RELCHSIV();
        public Dclgens.AGTABCH1 AGTABCH1 { get; set; } = new Dclgens.AGTABCH1();
        public Dclgens.CEPFXFIL CEPFXFIL { get; set; } = new Dclgens.CEPFXFIL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(FI0100S_LK_IMPOSTOS FI0100S_LK_IMPOSTOS_P) //PROCEDURE DIVISION USING 
        /*LK_IMPOSTOS*/
        {
            try
            {
                this.LK_IMPOSTOS = FI0100S_LK_IMPOSTOS_P;

                /*" -1874- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -1877- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -1880- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -1880- FLUXCONTROL_PERFORM R0001-00-PRINCIPAL-SECTION */

                R0001_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_IMPOSTOS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0001-00-PRINCIPAL-SECTION */
        private void R0001_00_PRINCIPAL_SECTION()
        {
            /*" -1890- IF WS-PRIMEIRA-VEZ = 'SIM' */

            if (FILLER_4.WS_PRIMEIRA_VEZ == "SIM")
            {

                /*" -1891- MOVE 'NAO' TO WS-PRIMEIRA-VEZ */
                _.Move("NAO", FILLER_4.WS_PRIMEIRA_VEZ);

                /*" -1899- DISPLAY 'FI0100S - VERSAO 4 - INICIO  PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

                $"FI0100S - VERSAO 4 - INICIO  PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();
            }


            /*" -1903- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1906- PERFORM R0100-00-CRITICA-PARM */

            R0100_00_CRITICA_PARM_SECTION();

            /*" -1910- PERFORM R0200-00-ACESSA-FAVORECIDO */

            R0200_00_ACESSA_FAVORECIDO_SECTION();

            /*" -1911- IF LK-PROGRAMA = 'FI0009B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0009B")
            {

                /*" -1915- PERFORM R0210-00-ACESSA-CEPFXFIL. */

                R0210_00_ACESSA_CEPFXFIL_SECTION();
            }


            /*" -1916- MOVE ZEROS TO V1FONT-PCDESISS */
            _.Move(0, V1FONT_PCDESISS);

            /*" -1917- IF LK-PROGRAMA EQUAL 'FI0009B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0009B")
            {

                /*" -1918- IF WS-EH-ISENTO-ISS EQUAL 'N' */

                if (AREA_DE_WORK.WS_EH_ISENTO_ISS == "N")
                {

                    /*" -1919- PERFORM R0220-00-ACESSA-V1FONTE */

                    R0220_00_ACESSA_V1FONTE_SECTION();

                    /*" -1920- END-IF */
                }


                /*" -1921- ELSE */
            }
            else
            {


                /*" -1925- PERFORM R0220-00-ACESSA-V1FONTE. */

                R0220_00_ACESSA_V1FONTE_SECTION();
            }


            /*" -1926- IF LK-IDTRIBUTA EQUAL 'S' */

            if (LK_IMPOSTOS.LK_IDTRIBUTA == "S")
            {

                /*" -1927- PERFORM R0230-00-PREPARA-CALCULO-IRF */

                R0230_00_PREPARA_CALCULO_IRF_SECTION();

                /*" -1928- IF WS-EH-ISENTO-ISS = 'N' */

                if (AREA_DE_WORK.WS_EH_ISENTO_ISS == "N")
                {

                    /*" -1929- PERFORM R0240-00-PREPARA-CALCULO-ISS */

                    R0240_00_PREPARA_CALCULO_ISS_SECTION();

                    /*" -1930- ELSE */
                }
                else
                {


                    /*" -1931- PERFORM R0270-00-NAO-TRIBUTA-ISS */

                    R0270_00_NAO_TRIBUTA_ISS_SECTION();

                    /*" -1932- END-IF */
                }


                /*" -1933- PERFORM R0250-00-PREPARA-CALCULO-INSS */

                R0250_00_PREPARA_CALCULO_INSS_SECTION();

                /*" -1934- ELSE */
            }
            else
            {


                /*" -1935- PERFORM R0260-00-NAO-TRIBUTA-IR */

                R0260_00_NAO_TRIBUTA_IR_SECTION();

                /*" -1936- PERFORM R0270-00-NAO-TRIBUTA-ISS */

                R0270_00_NAO_TRIBUTA_ISS_SECTION();

                /*" -1940- PERFORM R0280-00-NAO-TRIBUTA-INSS. */

                R0280_00_NAO_TRIBUTA_INSS_SECTION();
            }


            /*" -1942- IF LK-IDTRIBUTA EQUAL 'S' AND LK-VALBRU > ZEROS */

            if (LK_IMPOSTOS.LK_IDTRIBUTA == "S" && LK_IMPOSTOS.LK_VALBRU > 00)
            {

                /*" -1943- PERFORM R0300-00-CALCULA-IMPOSTOS */

                R0300_00_CALCULA_IMPOSTOS_SECTION();

                /*" -1944- IF LK-ATUALIZA EQUAL 'S' */

                if (LK_IMPOSTOS.LK_ATUALIZA == "S")
                {

                    /*" -1945- PERFORM R0880-00-PREPARA-INC-RENDIM */

                    R0880_00_PREPARA_INC_RENDIM_SECTION();

                    /*" -1949- PERFORM R0900-00-PREPARA-INC-IMPOSTO. */

                    R0900_00_PREPARA_INC_IMPOSTO_SECTION();
                }

            }


            /*" -1950- IF LK-ATUALIZA EQUAL 'S' */

            if (LK_IMPOSTOS.LK_ATUALIZA == "S")
            {

                /*" -1951- IF LK-TIPFAV EQUAL '2' */

                if (LK_IMPOSTOS.LK_TIPFAV == "2")
                {

                    /*" -1952- PERFORM R0860-00-UPDATE-V1FORNECEDOR */

                    R0860_00_UPDATE_V1FORNECEDOR_SECTION();

                    /*" -1953- ELSE */
                }
                else
                {


                    /*" -1954- IF LK-TIPFAV EQUAL '3' */

                    if (LK_IMPOSTOS.LK_TIPFAV == "3")
                    {

                        /*" -1958- PERFORM R0870-00-UPDATE-V1PRODUTOR. */

                        R0870_00_UPDATE_V1PRODUTOR_SECTION();
                    }

                }

            }


            /*" -1963- IF LK-IDTRIBUTA = 'S' AND LK-ATUALIZA = 'S' AND (LK-VALIRF NOT = ZEROS OR LK-VALISS NOT = ZEROS OR LK-VALINSS NOT = ZEROS) */

            if (LK_IMPOSTOS.LK_IDTRIBUTA == "S" && LK_IMPOSTOS.LK_ATUALIZA == "S" && (LK_IMPOSTOS.LK_VALIRF != 00 || LK_IMPOSTOS.LK_VALISS != 00 || LK_IMPOSTOS.LK_VALINSS != 00))
            {

                /*" -1963- PERFORM R8888-00-DISPLAY-PARM-CALC. */

                R8888_00_DISPLAY_PARM_CALC_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0001_90_FINALIZA */

            R0001_90_FINALIZA();

        }

        [StopWatch]
        /*" R0001-90-FINALIZA */
        private void R0001_90_FINALIZA(bool isPerform = false)
        {
            /*" -1971- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1971- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-CRITICA-PARM-SECTION */
        private void R0100_00_CRITICA_PARM_SECTION()
        {
            /*" -1987- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1989- MOVE ZEROS TO LK-RETCODE */
            _.Move(0, LK_IMPOSTOS.LK_RETCODE);

            /*" -1991- MOVE LK-MENSAGEM TO WS-MENSAGEM. */
            _.Move(LK_IMPOSTOS.LK_MENSAGEM, AREA_DE_WORK.WS_MENSAGEM);

            /*" -1996- MOVE SPACES TO LK-EXEC-SQL LK-MENSAGEM */
            _.Move("", LK_IMPOSTOS.LK_EXEC_SQL, LK_IMPOSTOS.LK_MENSAGEM);

            /*" -1997- IF LK-PROGRAMA EQUAL 'FI0041B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0041B")
            {

                /*" -1998- IF LK-VALIRF > ZEROS */

                if (LK_IMPOSTOS.LK_VALIRF > 00)
                {

                    /*" -1999- MOVE LK-VALIRF TO WS-VLR-ISENTO-IR */
                    _.Move(LK_IMPOSTOS.LK_VALIRF, AREA_DE_WORK.WS_VLR_ISENTO_IR);

                    /*" -2003- MOVE ZEROS TO LK-VALIRF. */
                    _.Move(0, LK_IMPOSTOS.LK_VALIRF);
                }

            }


            /*" -2005- IF LK-ATUALIZA NOT EQUAL 'S' AND LK-ATUALIZA NOT EQUAL 'N' */

            if (LK_IMPOSTOS.LK_ATUALIZA != "S" && LK_IMPOSTOS.LK_ATUALIZA != "N")
            {

                /*" -2007- MOVE 'PROBLEMA SUBROTINA FI0100S, ATUALIZA INVALIDO' TO LK-MENSAGEM */
                _.Move("PROBLEMA SUBROTINA FI0100S, ATUALIZA INVALIDO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -2009- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2011- IF LK-IDTRIBUTA NOT EQUAL 'S' AND LK-IDTRIBUTA NOT EQUAL 'N' */

            if (LK_IMPOSTOS.LK_IDTRIBUTA != "S" && LK_IMPOSTOS.LK_IDTRIBUTA != "N")
            {

                /*" -2013- MOVE 'PROBLEMA SUBROTINA FI0100S, IDTRIBUTA INVALIDO' TO LK-MENSAGEM */
                _.Move("PROBLEMA SUBROTINA FI0100S, IDTRIBUTA INVALIDO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -2015- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2016- IF LK-PROGRAMA EQUAL SPACES */

            if (LK_IMPOSTOS.LK_PROGRAMA.IsEmpty())
            {

                /*" -2018- MOVE 'PROBLEMA SUBROTINA FI0100S, PROGRAMA NAO INFORMADO' TO LK-MENSAGEM */
                _.Move("PROBLEMA SUBROTINA FI0100S, PROGRAMA NAO INFORMADO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -2022- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2023- IF LK-TIPFAV NOT = ' ' */

            if (LK_IMPOSTOS.LK_TIPFAV != " ")
            {

                /*" -2024- MOVE 03 TO AGTABCH1-IDTAB */
                _.Move(03, AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_IDTAB);

                /*" -2025- MOVE LK-TIPFAV TO AGTABCH1-CODIGO-CH1 */
                _.Move(LK_IMPOSTOS.LK_TIPFAV, AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_CODIGO_CH1);

                /*" -2027- PERFORM R0978-00-LE-AGRUPA-CH1. */

                R0978_00_LE_AGRUPA_CH1_SECTION();
            }


            /*" -2029- IF LK-TIPFAV EQUAL '2' OR '3' NEXT SENTENCE */

            if (LK_IMPOSTOS.LK_TIPFAV.In("2", "3"))
            {

                /*" -2030- ELSE */
            }
            else
            {


                /*" -2032- MOVE 'PROBLEMA SUBROTINA FI0100S, TIPFAV INVALIDO' TO LK-MENSAGEM */
                _.Move("PROBLEMA SUBROTINA FI0100S, TIPFAV INVALIDO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -2036- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2037- IF LK-TIPREG NOT = ' ' */

            if (LK_IMPOSTOS.LK_TIPREG != " ")
            {

                /*" -2038- MOVE 07 TO AGTABCH1-IDTAB */
                _.Move(07, AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_IDTAB);

                /*" -2039- MOVE LK-TIPREG TO AGTABCH1-CODIGO-CH1 */
                _.Move(LK_IMPOSTOS.LK_TIPREG, AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_CODIGO_CH1);

                /*" -2041- PERFORM R0978-00-LE-AGRUPA-CH1. */

                R0978_00_LE_AGRUPA_CH1_SECTION();
            }


            /*" -2042- IF LK-CODFAV EQUAL ZEROS */

            if (LK_IMPOSTOS.LK_CODFAV == 00)
            {

                /*" -2044- MOVE 'PROBLEMA SUBROTINA FI0100S, CODFAV NAO INFORMADO' TO LK-MENSAGEM */
                _.Move("PROBLEMA SUBROTINA FI0100S, CODFAV NAO INFORMADO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -2046- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2048- IF LK-IDTRIBUTA EQUAL 'S' AND LK-VALBRU EQUAL ZEROS */

            if (LK_IMPOSTOS.LK_IDTRIBUTA == "S" && LK_IMPOSTOS.LK_VALBRU == 00)
            {

                /*" -2050- MOVE 'PROBLEMA SUBROTINA FI0100S, VALBRU NAO INFORMADO' TO LK-MENSAGEM */
                _.Move("PROBLEMA SUBROTINA FI0100S, VALBRU NAO INFORMADO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -2052- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2053- IF LK-DTMOVABE EQUAL SPACES */

            if (LK_IMPOSTOS.LK_DTMOVABE.IsEmpty())
            {

                /*" -2055- MOVE 'PROBLEMA SUBROTINA FI0100S,DTMOVABE NAO INFORMADO' TO LK-MENSAGEM */
                _.Move("PROBLEMA SUBROTINA FI0100S,DTMOVABE NAO INFORMADO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -2060- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2063- MOVE LK-DTMOVABE TO V1SIST-DTMOVABE WS-MESANO-R. */
            _.Move(LK_IMPOSTOS.LK_DTMOVABE, V1SIST_DTMOVABE);
            _.Move(LK_IMPOSTOS.LK_DTMOVABE, AREA_DE_WORK.WS_MESANO_R);


            /*" -2064- MOVE 01 TO WS-DIA */
            _.Move(01, AREA_DE_WORK.WS_MESANO.WS_DIA);

            /*" -2069- MOVE WS-MESANO-R TO WS-DTINIREF. */
            _.Move(AREA_DE_WORK.WS_MESANO_R, WS_DTINIREF);

            /*" -2070- IF WS-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_MESANO.WS_MES.In("04", "06", "09", "11"))
            {

                /*" -2071- MOVE 30 TO WS-DIA */
                _.Move(30, AREA_DE_WORK.WS_MESANO.WS_DIA);

                /*" -2072- ELSE */
            }
            else
            {


                /*" -2073- IF WS-MES EQUAL 02 */

                if (AREA_DE_WORK.WS_MESANO.WS_MES == 02)
                {

                    /*" -2075- DIVIDE WS-ANO BY 4 GIVING WS-DTANO REMAINDER WS-RESTO */
                    _.Divide(AREA_DE_WORK.WS_MESANO.WS_ANO, 4, AREA_DE_WORK.WS_DTANO, AREA_DE_WORK.WS_RESTO);

                    /*" -2076- IF WS-RESTO EQUAL 0 */

                    if (AREA_DE_WORK.WS_RESTO == 0)
                    {

                        /*" -2077- MOVE 29 TO WS-DIA */
                        _.Move(29, AREA_DE_WORK.WS_MESANO.WS_DIA);

                        /*" -2078- ELSE */
                    }
                    else
                    {


                        /*" -2079- MOVE 28 TO WS-DIA */
                        _.Move(28, AREA_DE_WORK.WS_MESANO.WS_DIA);

                        /*" -2080- ELSE */
                    }

                }
                else
                {


                    /*" -2082- MOVE 31 TO WS-DIA. */
                    _.Move(31, AREA_DE_WORK.WS_MESANO.WS_DIA);
                }

            }


            /*" -2082- MOVE WS-MESANO-R TO WS-DTFIMREF. */
            _.Move(AREA_DE_WORK.WS_MESANO_R, WS_DTFIMREF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-ACESSA-FAVORECIDO-SECTION */
        private void R0200_00_ACESSA_FAVORECIDO_SECTION()
        {
            /*" -2098- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -2099- MOVE ZEROS TO LK-NUMREC */
            _.Move(0, LK_IMPOSTOS.LK_NUMREC);

            /*" -2104- MOVE SPACES TO LK-NOMFAV */
            _.Move("", LK_IMPOSTOS.LK_NOMFAV);

            /*" -2106- MOVE 'N' TO WS-EH-ISENTO-IR. */
            _.Move("N", AREA_DE_WORK.WS_EH_ISENTO_IR);

            /*" -2118- MOVE ZEROS TO V1FAVO-NUMREC V1FAVO-PCTIRF V1FAVO-CODSVI V1FAVO-INSPREFE V1FAVO-INSESTAD V1FAVO-INSINPS V1FAVO-CGCCPF V2FAVO-IDECBT V2FAVO-CODVIN V1FAVO-NUMDEPIRF V1FAVO-CEP */
            _.Move(0, V1FAVO_NUMREC, V1FAVO_PCTIRF, V1FAVO_CODSVI, V1FAVO_INSPREFE, V1FAVO_INSESTAD, V1FAVO_INSINPS, V1FAVO_CGCCPF, V2FAVO_IDECBT, V2FAVO_CODVIN, V1FAVO_NUMDEPIRF, V1FAVO_CEP);

            /*" -2122- MOVE SPACES TO V1FAVO-NOMFAV V1FAVO-TPPESSOA V1FAVO-TIPREG */
            _.Move("", V1FAVO_NOMFAV, V1FAVO_TPPESSOA, V1FAVO_TIPREG);

            /*" -2123- MOVE 'N' TO WS-EH-MAIOR-65ANOS */
            _.Move("N", AREA_DE_WORK.WS_EH_MAIOR_65ANOS);

            /*" -2125- MOVE 'N' TO WS-TEM-DESC-100 */
            _.Move("N", AREA_DE_WORK.WS_TEM_DESC_100);

            /*" -2128- MOVE LK-CODFAV TO V1FAVO-CODFAV DISPLAY-CODFAV */
            _.Move(LK_IMPOSTOS.LK_CODFAV, V1FAVO_CODFAV, AREA_DE_WORK.DISPLAY_CODFAV);

            /*" -2134- MOVE ZEROS TO V2IRF-VALBRU. */
            _.Move(0, V2IRF_VALBRU);

            /*" -2135- IF LK-TIPFAV EQUAL '2' */

            if (LK_IMPOSTOS.LK_TIPFAV == "2")
            {

                /*" -2136- MOVE 2 TO V2FAVO-IDECBT */
                _.Move(2, V2FAVO_IDECBT);

                /*" -2137- PERFORM R0420-00-ACESSA-V1FORNECEDOR */

                R0420_00_ACESSA_V1FORNECEDOR_SECTION();

                /*" -2138- ELSE */
            }
            else
            {


                /*" -2139- IF LK-TIPFAV EQUAL '3' */

                if (LK_IMPOSTOS.LK_TIPFAV == "3")
                {

                    /*" -2140- MOVE 1 TO V2FAVO-IDECBT */
                    _.Move(1, V2FAVO_IDECBT);

                    /*" -2146- PERFORM R0430-00-ACESSA-V1PRODUTOR. */

                    R0430_00_ACESSA_V1PRODUTOR_SECTION();
                }

            }


            /*" -2148- MOVE V1FAVO-NOMFAV TO LK-NOMFAV */
            _.Move(V1FAVO_NOMFAV, LK_IMPOSTOS.LK_NOMFAV);

            /*" -2149- IF LK-ATUALIZA EQUAL 'S' */

            if (LK_IMPOSTOS.LK_ATUALIZA == "S")
            {

                /*" -2151- ADD 1 TO V1FAVO-NUMREC. */
                V1FAVO_NUMREC.Value = V1FAVO_NUMREC + 1;
            }


            /*" -2153- MOVE V1FAVO-NUMREC TO LK-NUMREC. */
            _.Move(V1FAVO_NUMREC, LK_IMPOSTOS.LK_NUMREC);

            /*" -2154- MOVE V1FAVO-TIPREG TO LK-TIPREG */
            _.Move(V1FAVO_TIPREG, LK_IMPOSTOS.LK_TIPREG);

            /*" -2155- MOVE V1FAVO-TPPESSOA TO LK-TPPESSOA */
            _.Move(V1FAVO_TPPESSOA, LK_IMPOSTOS.LK_TPPESSOA);

            /*" -2156- MOVE V1FAVO-CODSVI TO LK-CODSVI */
            _.Move(V1FAVO_CODSVI, LK_IMPOSTOS.LK_CODSVI);

            /*" -2157- MOVE V1FAVO-INSPREFE TO LK-INSPREFE */
            _.Move(V1FAVO_INSPREFE, LK_IMPOSTOS.LK_INSPREFE);

            /*" -2158- MOVE V1FAVO-INSINPS TO LK-INSINPS */
            _.Move(V1FAVO_INSINPS, LK_IMPOSTOS.LK_INSINPS);

            /*" -2158- MOVE V1FAVO-CGCCPF TO LK-CGCCPF. */
            _.Move(V1FAVO_CGCCPF, LK_IMPOSTOS.LK_CGCCPF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-ACESSA-CEPFXFIL-SECTION */
        private void R0210_00_ACESSA_CEPFXFIL_SECTION()
        {
            /*" -2172- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -2183- MOVE ZEROS TO CEPFXFIL-FONTE */
            _.Move(0, CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE);

            /*" -2185- MOVE 0 TO CEPFXFIL-COD-EMPRESA. */
            _.Move(0, CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_COD_EMPRESA);

            /*" -2192- PERFORM R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1 */

            R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1();

            /*" -2195- IF WHOST-QTDE EQUAL 0 */

            if (WHOST_QTDE == 0)
            {

                /*" -2196- MOVE 'S' TO WS-EH-ISENTO-ISS */
                _.Move("S", AREA_DE_WORK.WS_EH_ISENTO_ISS);

                /*" -2201- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2202- IF WHOST-QTDE > 1 */

            if (WHOST_QTDE > 1)
            {

                /*" -2210- PERFORM R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2 */

                R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2();

                /*" -2212- ELSE */
            }
            else
            {


                /*" -2220- PERFORM R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3 */

                R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3();

                /*" -2224- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -2225- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2226- MOVE 'S' TO WS-EH-ISENTO-ISS */
                        _.Move("S", AREA_DE_WORK.WS_EH_ISENTO_ISS);

                        /*" -2227- ELSE */
                    }
                    else
                    {


                        /*" -2229- MOVE 'FI0100S,R0210 - ERRO NO SELECT CEPFAIXAFILIAL' TO LK-MENSAGEM */
                        _.Move("FI0100S,R0210 - ERRO NO SELECT CEPFAIXAFILIAL", LK_IMPOSTOS.LK_MENSAGEM);

                        /*" -2230- DISPLAY LK-MENSAGEM */
                        _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                        /*" -2231- DISPLAY 'FI0100S - CEP = ' V1FAVO-CEP */
                        _.Display($"FI0100S - CEP = {V1FAVO_CEP}");

                        /*" -2233- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2234- IF CEPFXFIL-FONTE NOT EQUAL ZEROS */

            if (CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE != 00)
            {

                /*" -2235- DISPLAY 'FI0100S - R0210 - FONTE=' CEPFXFIL-FONTE */
                _.Display($"FI0100S - R0210 - FONTE={CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE}");

                /*" -2236- MOVE CEPFXFIL-FONTE TO V1FAVO-FONTE LK-FONTE. */
                _.Move(CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE, V1FAVO_FONTE, LK_IMPOSTOS.LK_FONTE);
            }


        }

        [StopWatch]
        /*" R0210-00-ACESSA-CEPFXFIL-DB-SELECT-1 */
        public void R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1()
        {
            /*" -2192- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WHOST-QTDE:VIND-QTDE FROM SEGUROS.CEPFAIXAFILIAL WHERE :V1FAVO-CEP BETWEEN CEP_INICIAL AND CEP_FINAL AND DATA_TER_VIGENCIA > :V1SIST-DTMOVABE AND COD_EMPRESA = :CEPFXFIL-COD-EMPRESA END-EXEC */

            var r0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1 = new R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1()
            {
                CEPFXFIL_COD_EMPRESA = CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_COD_EMPRESA.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1FAVO_CEP = V1FAVO_CEP.ToString(),
            };

            var executed_1 = R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1.Execute(r0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDE, WHOST_QTDE);
                _.Move(executed_1.VIND_QTDE, VIND_QTDE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-ACESSA-CEPFXFIL-DB-SELECT-2 */
        public void R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2()
        {
            /*" -2210- EXEC SQL SELECT VALUE(MAX(FONTE),0) INTO :CEPFXFIL-FONTE FROM SEGUROS.CEPFAIXAFILIAL WHERE :V1FAVO-CEP BETWEEN CEP_INICIAL AND CEP_FINAL AND DATA_TER_VIGENCIA > :V1SIST-DTMOVABE AND COD_EMPRESA = :CEPFXFIL-COD-EMPRESA END-EXEC */

            var r0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1 = new R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1()
            {
                CEPFXFIL_COD_EMPRESA = CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_COD_EMPRESA.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1FAVO_CEP = V1FAVO_CEP.ToString(),
            };

            var executed_1 = R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1.Execute(r0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEPFXFIL_FONTE, CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE);
            }


        }

        [StopWatch]
        /*" R0220-00-ACESSA-V1FONTE-SECTION */
        private void R0220_00_ACESSA_V1FONTE_SECTION()
        {
            /*" -2258- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -2259- IF LK-FONTE = ZEROS */

            if (LK_IMPOSTOS.LK_FONTE == 00)
            {

                /*" -2261- MOVE V1FAVO-FONTE TO LK-FONTE. */
                _.Move(V1FAVO_FONTE, LK_IMPOSTOS.LK_FONTE);
            }


            /*" -2263- MOVE LK-FONTE TO V1FONT-FONTE */
            _.Move(LK_IMPOSTOS.LK_FONTE, V1FONT_FONTE);

            /*" -2265- MOVE SPACES TO V1FONT-NOMEFTE LK-NOMEFTE */
            _.Move("", V1FONT_NOMEFTE, LK_IMPOSTOS.LK_NOMEFTE);

            /*" -2267- MOVE ZEROS TO V1FONT-PCDESISS */
            _.Move(0, V1FONT_PCDESISS);

            /*" -2275- PERFORM R0220_00_ACESSA_V1FONTE_DB_SELECT_1 */

            R0220_00_ACESSA_V1FONTE_DB_SELECT_1();

            /*" -2278- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2280- MOVE 'FI0100S,R0220 - ERRO NO SELECT V1FONTE' TO LK-MENSAGEM */
                _.Move("FI0100S,R0220 - ERRO NO SELECT V1FONTE", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -2281- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -2282- DISPLAY 'FI0100S - FONTE = ' V1FONT-FONTE */
                _.Display($"FI0100S - FONTE = {V1FONT_FONTE}");

                /*" -2286- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2290- MOVE V1FONT-NOMEFTE TO LK-NOMEFTE. */
            _.Move(V1FONT_NOMEFTE, LK_IMPOSTOS.LK_NOMEFTE);

            /*" -2291- IF V1FONT-FONTE EQUAL ZEROS */

            if (V1FONT_FONTE == 00)
            {

                /*" -2292- MOVE 'S' TO WS-EH-ISENTO-ISS */
                _.Move("S", AREA_DE_WORK.WS_EH_ISENTO_ISS);

                /*" -2293- ELSE */
            }
            else
            {


                /*" -2293- MOVE 'N' TO WS-EH-ISENTO-ISS. */
                _.Move("N", AREA_DE_WORK.WS_EH_ISENTO_ISS);
            }


        }

        [StopWatch]
        /*" R0220-00-ACESSA-V1FONTE-DB-SELECT-1 */
        public void R0220_00_ACESSA_V1FONTE_DB_SELECT_1()
        {
            /*" -2275- EXEC SQL SELECT NOMEFTE, PCDESISS INTO :V1FONT-NOMEFTE, :V1FONT-PCDESISS FROM SEGUROS.V1FONTE WHERE FONTE = :V1FONT-FONTE WITH UR END-EXEC. */

            var r0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1 = new R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1()
            {
                V1FONT_FONTE = V1FONT_FONTE.ToString(),
            };

            var executed_1 = R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1.Execute(r0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_NOMEFTE, V1FONT_NOMEFTE);
                _.Move(executed_1.V1FONT_PCDESISS, V1FONT_PCDESISS);
            }


        }

        [StopWatch]
        /*" R0210-00-ACESSA-CEPFXFIL-DB-SELECT-3 */
        public void R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3()
        {
            /*" -2220- EXEC SQL SELECT VALUE(FONTE,0) INTO :CEPFXFIL-FONTE FROM SEGUROS.CEPFAIXAFILIAL WHERE :V1FAVO-CEP BETWEEN CEP_INICIAL AND CEP_FINAL AND DATA_TER_VIGENCIA > :V1SIST-DTMOVABE AND COD_EMPRESA = :CEPFXFIL-COD-EMPRESA END-EXEC. */

            var r0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1 = new R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1()
            {
                CEPFXFIL_COD_EMPRESA = CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_COD_EMPRESA.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1FAVO_CEP = V1FAVO_CEP.ToString(),
            };

            var executed_1 = R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1.Execute(r0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEPFXFIL_FONTE, CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-PREPARA-CALCULO-IRF-SECTION */
        private void R0230_00_PREPARA_CALCULO_IRF_SECTION()
        {
            /*" -2312- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -2313- IF LK-TIPFAV EQUAL '2' */

            if (LK_IMPOSTOS.LK_TIPFAV == "2")
            {

                /*" -2315- IF WDAT-INVERT >= 20020423 AND V1FAVO-DCOIRF = 'D' */

                if (FILLER_4.WDAT_INVERT.GetMoveValues().ToInt() >= 20020423 && V1FAVO_DCOIRF == "D")
                {

                    /*" -2317- DISPLAY 'FI0100S - R0230 FAVORECIDO ' LK-CODFAV ' DISPENSADO DO IRF EM ' WDAT-INVERT */

                    $"FI0100S - R0230 FAVORECIDO {LK_IMPOSTOS.LK_CODFAV} DISPENSADO DO IRF EM {FILLER_4.WDAT_INVERT}"
                    .Display();

                    /*" -2318- MOVE 'N' TO LK-DCOIRF */
                    _.Move("N", LK_IMPOSTOS.LK_DCOIRF);

                    /*" -2320- GO TO R0230-20-ISENTO-IRF. */

                    R0230_20_ISENTO_IRF(); //GOTO
                    return;
                }

            }


            /*" -2322- IF LK-PROGRAMA NOT = 'FI0001B' AND 'FI0041B' */

            if (!LK_IMPOSTOS.LK_PROGRAMA.In("FI0001B", "FI0041B"))
            {

                /*" -2324- MOVE ZEROS TO LK-PCTIRF. */
                _.Move(0, LK_IMPOSTOS.LK_PCTIRF);
            }


            /*" -2326- IF LK-PROGRAMA = 'FI0003B' AND LK-DCOIRF EQUAL ' ' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0003B" && LK_IMPOSTOS.LK_DCOIRF == " ")
            {

                /*" -2328- MOVE V1FAVO-DCOIRF TO LK-DCOIRF. */
                _.Move(V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);
            }


            /*" -2329- IF V1FAVO-TPPESSOA EQUAL 'F' */

            if (V1FAVO_TPPESSOA == "F")
            {

                /*" -2330- MOVE 2 TO V2FAVO-CODVIN */
                _.Move(2, V2FAVO_CODVIN);

                /*" -2331- ELSE */
            }
            else
            {


                /*" -2332- IF V1FAVO-TPPESSOA EQUAL 'J' */

                if (V1FAVO_TPPESSOA == "J")
                {

                    /*" -2335- MOVE 3 TO V2FAVO-CODVIN. */
                    _.Move(3, V2FAVO_CODVIN);
                }

            }


            /*" -2336- IF V1FAVO-TIPREG EQUAL 'I' */

            if (V1FAVO_TIPREG == "I")
            {

                /*" -2338- MOVE 'S' TO V1FAVO-DCOIRF LK-DCOIRF */
                _.Move("S", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);

                /*" -2340- MOVE 1,50 TO V1FAVO-PCTIRF LK-PCTIRF */
                _.Move(1.50, V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);

                /*" -2342- ELSE */
            }
            else
            {


                /*" -2343- IF V1FAVO-TIPREG EQUAL 'J' */

                if (V1FAVO_TIPREG == "J")
                {

                    /*" -2345- MOVE 'S' TO V1FAVO-DCOIRF LK-DCOIRF */
                    _.Move("S", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);

                    /*" -2347- MOVE 25,00 TO V1FAVO-PCTIRF LK-PCTIRF */
                    _.Move(25.00, V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);

                    /*" -2349- ELSE */
                }
                else
                {


                    /*" -2350- IF V1FAVO-TIPREG EQUAL 'K' */

                    if (V1FAVO_TIPREG == "K")
                    {

                        /*" -2352- MOVE 'S' TO V1FAVO-DCOIRF LK-DCOIRF */
                        _.Move("S", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);

                        /*" -2354- MOVE 30,00 TO V1FAVO-PCTIRF LK-PCTIRF */
                        _.Move(30.00, V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);

                        /*" -2356- ELSE */
                    }
                    else
                    {


                        /*" -2357- IF V1FAVO-TIPREG EQUAL '5' */

                        if (V1FAVO_TIPREG == "5")
                        {

                            /*" -2359- MOVE 'S' TO V1FAVO-DCOIRF LK-DCOIRF */
                            _.Move("S", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);

                            /*" -2361- MOVE 20,00 TO V1FAVO-PCTIRF LK-PCTIRF */
                            _.Move(20.00, V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);

                            /*" -2363- ELSE */
                        }
                        else
                        {


                            /*" -2364- IF V1FAVO-TIPREG EQUAL '6' */

                            if (V1FAVO_TIPREG == "6")
                            {

                                /*" -2366- MOVE 'S' TO V1FAVO-DCOIRF LK-DCOIRF */
                                _.Move("S", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);

                                /*" -2372- MOVE LK-PCTIRF TO V1FAVO-PCTIRF */
                                _.Move(LK_IMPOSTOS.LK_PCTIRF, V1FAVO_PCTIRF);

                                /*" -2374- ELSE */
                            }
                            else
                            {


                                /*" -2375- IF V1FAVO-TIPREG EQUAL '7' */

                                if (V1FAVO_TIPREG == "7")
                                {

                                    /*" -2377- MOVE 'S' TO V1FAVO-DCOIRF LK-DCOIRF */
                                    _.Move("S", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);

                                    /*" -2378- IF V1FAVO-TPPESSOA EQUAL 'J' */

                                    if (V1FAVO_TPPESSOA == "J")
                                    {

                                        /*" -2380- MOVE 1,5 TO V1FAVO-PCTIRF LK-PCTIRF */
                                        _.Move(1.5, V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);

                                        /*" -2381- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2386- MOVE ZEROS TO V1FAVO-PCTIRF LK-PCTIRF. */
                                        _.Move(0, V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);
                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -2387- IF LK-PROGRAMA = 'FI0009B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0009B")
            {

                /*" -2388- IF WS-TIPO-SERV EQUAL '1' OR ' ' */

                if (AREA_DE_WORK.WS_MENSAGEM.WS_TIPO_SERV.In("1", " "))
                {

                    /*" -2390- MOVE 'N' TO V1FAVO-DCOIRF LK-DCOIRF */
                    _.Move("N", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);

                    /*" -2392- MOVE ZEROS TO V1FAVO-PCTIRF LK-PCTIRF */
                    _.Move(0, V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);

                    /*" -2393- ELSE */
                }
                else
                {


                    /*" -2394- IF WS-TIPO-SERV EQUAL '7' */

                    if (AREA_DE_WORK.WS_MENSAGEM.WS_TIPO_SERV == "7")
                    {

                        /*" -2395- IF V1FAVO-TPPESSOA EQUAL 'J' */

                        if (V1FAVO_TPPESSOA == "J")
                        {

                            /*" -2397- MOVE 'S' TO V1FAVO-DCOIRF LK-DCOIRF */
                            _.Move("S", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);

                            /*" -2402- MOVE V1FAVO-PCTIRF TO LK-PCTIRF. */
                            _.Move(V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);
                        }

                    }

                }

            }


            /*" -2403- IF LK-PROGRAMA EQUAL 'FI0001B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0001B")
            {

                /*" -2404- MOVE LK-DCOIRF TO V1FAVO-DCOIRF */
                _.Move(LK_IMPOSTOS.LK_DCOIRF, V1FAVO_DCOIRF);

                /*" -2409- MOVE LK-PCTIRF TO V1FAVO-PCTIRF. */
                _.Move(LK_IMPOSTOS.LK_PCTIRF, V1FAVO_PCTIRF);
            }


            /*" -2410- IF LK-PROGRAMA EQUAL 'FI0041B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0041B")
            {

                /*" -2411- MOVE LK-DCOIRF TO V1FAVO-DCOIRF */
                _.Move(LK_IMPOSTOS.LK_DCOIRF, V1FAVO_DCOIRF);

                /*" -2415- MOVE LK-PCTIRF TO V1FAVO-PCTIRF. */
                _.Move(LK_IMPOSTOS.LK_PCTIRF, V1FAVO_PCTIRF);
            }


            /*" -2418- IF LK-DCOIRF EQUAL 'S' AND LK-PCTIRF EQUAL 0 AND V1FAVO-TPPESSOA EQUAL 'J' */

            if (LK_IMPOSTOS.LK_DCOIRF == "S" && LK_IMPOSTOS.LK_PCTIRF == 0 && V1FAVO_TPPESSOA == "J")
            {

                /*" -2419- PERFORM R0960-00-ACESSA-IRJ */

                R0960_00_ACESSA_IRJ_SECTION();

                /*" -2431- MOVE V1IRF-ALQIPT TO V1FAVO-PCTIRF LK-PCTIRF. */
                _.Move(V1IRF_ALQIPT, V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);
            }


            /*" -2432- IF LK-TIPFAV EQUAL '2' */

            if (LK_IMPOSTOS.LK_TIPFAV == "2")
            {

                /*" -2443- IF LK-CODFAV EQUAL 561023 OR 79685 OR 813068 OR 901774 OR 965478 OR 612228 OR 926737 OR 88668 OR 896113 */

                if (LK_IMPOSTOS.LK_CODFAV.In("561023", "79685", "813068", "901774", "965478", "612228", "926737", "88668", "896113"))
                {

                    /*" -2450- MOVE 'N' TO V1FAVO-DCOIRF LK-DCOIRF. */
                    _.Move("N", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);
                }

            }


            /*" -2451- IF LK-TIPFAV EQUAL '3' */

            if (LK_IMPOSTOS.LK_TIPFAV == "3")
            {

                /*" -2454- IF LK-CODFAV EQUAL 102650 */

                if (LK_IMPOSTOS.LK_CODFAV == 102650)
                {

                    /*" -2455- MOVE 'N' TO V1FAVO-DCOIRF LK-DCOIRF. */
                    _.Move("N", V1FAVO_DCOIRF, LK_IMPOSTOS.LK_DCOIRF);
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0230_20_ISENTO_IRF */

            R0230_20_ISENTO_IRF();

        }

        [StopWatch]
        /*" R0230-20-ISENTO-IRF */
        private void R0230_20_ISENTO_IRF(bool isPerform = false)
        {
            /*" -2466- IF LK-DCOIRF EQUAL 'N' */

            if (LK_IMPOSTOS.LK_DCOIRF == "N")
            {

                /*" -2470- PERFORM R0260-00-NAO-TRIBUTA-IR. */

                R0260_00_NAO_TRIBUTA_IR_SECTION();
            }


            /*" -2471- MOVE ZEROS TO LK-VALIRF LK-VALDDUDEP. */
            _.Move(0, LK_IMPOSTOS.LK_VALIRF, LK_IMPOSTOS.LK_VALDDUDEP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-PREPARA-CALCULO-ISS-SECTION */
        private void R0240_00_PREPARA_CALCULO_ISS_SECTION()
        {
            /*" -2490- MOVE '0240' TO WNR-EXEC-SQL. */
            _.Move("0240", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -2491- IF LK-TIPFAV EQUAL '2' */

            if (LK_IMPOSTOS.LK_TIPFAV == "2")
            {

                /*" -2493- IF WDAT-INVERT >= 20011029 AND V1FAVO-DCOISS = 'D' */

                if (FILLER_4.WDAT_INVERT.GetMoveValues().ToInt() >= 20011029 && V1FAVO_DCOISS == "D")
                {

                    /*" -2495- DISPLAY 'FI0100S - R0240 FAVORECIDO ' LK-CODFAV ' DISPENSADO DO ISS EM ' WDAT-INVERT */

                    $"FI0100S - R0240 FAVORECIDO {LK_IMPOSTOS.LK_CODFAV} DISPENSADO DO ISS EM {FILLER_4.WDAT_INVERT}"
                    .Display();

                    /*" -2496- MOVE 'N' TO V2FAVO-DCOISS */
                    _.Move("N", V2FAVO_DCOISS);

                    /*" -2516- GO TO R0240-20-ISENTO-ISS. */

                    R0240_20_ISENTO_ISS(); //GOTO
                    return;
                }

            }


            /*" -2517- IF LK-FONTE EQUAL 21 */

            if (LK_IMPOSTOS.LK_FONTE == 21)
            {

                /*" -2518- IF V1FAVO-CGCCPF EQUAL 4055313000106 */

                if (V1FAVO_CGCCPF == 4055313000106)
                {

                    /*" -2520- DISPLAY 'FI0100S - R0240 FAVORECIDO DISPENSADO DO ISS = ' LK-CODFAV ' CGCCPF ' V1FAVO-CGCCPF ' NA FONTE ' LK-FONTE */

                    $"FI0100S - R0240 FAVORECIDO DISPENSADO DO ISS = {LK_IMPOSTOS.LK_CODFAV} CGCCPF {V1FAVO_CGCCPF} NA FONTE {LK_IMPOSTOS.LK_FONTE}"
                    .Display();

                    /*" -2521- MOVE 'N' TO V2FAVO-DCOISS */
                    _.Move("N", V2FAVO_DCOISS);

                    /*" -2528- GO TO R0240-20-ISENTO-ISS. */

                    R0240_20_ISENTO_ISS(); //GOTO
                    return;
                }

            }


            /*" -2529- IF LK-FONTE EQUAL 05 OR 10 */

            if (LK_IMPOSTOS.LK_FONTE.In("05", "10"))
            {

                /*" -2533- IF LK-TIPFAV EQUAL '3' */

                if (LK_IMPOSTOS.LK_TIPFAV == "3")
                {

                    /*" -2534- MOVE 2,00 TO V1FONT-PCDESISS */
                    _.Move(2.00, V1FONT_PCDESISS);

                    /*" -2536- MOVE 2,00 TO LK-PCDESISS. */
                    _.Move(2.00, LK_IMPOSTOS.LK_PCDESISS);
                }

            }


            /*" -2537- IF LK-PROGRAMA NOT = 'FI0001B' */

            if (LK_IMPOSTOS.LK_PROGRAMA != "FI0001B")
            {

                /*" -2549- MOVE ZEROS TO LK-PCDESISS. */
                _.Move(0, LK_IMPOSTOS.LK_PCDESISS);
            }


            /*" -2552- IF V1FAVO-CODSVI EQUAL 3208 OR 3223 OR 0916 */

            if (V1FAVO_CODSVI.In("3208", "3223", "0916"))
            {

                /*" -2553- MOVE 'N' TO V2FAVO-DCOISS */
                _.Move("N", V2FAVO_DCOISS);

                /*" -2556- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                return;
            }


            /*" -2557- IF LK-FONTE = 11 OR 23 OR 25 */

            if (LK_IMPOSTOS.LK_FONTE.In("11", "23", "25"))
            {

                /*" -2558- MOVE 'N' TO V2FAVO-DCOISS */
                _.Move("N", V2FAVO_DCOISS);

                /*" -2562- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                return;
            }


            /*" -2563- IF LK-FONTE = 02 OR 15 OR 20 OR 26 OR 27 */

            if (LK_IMPOSTOS.LK_FONTE.In("02", "15", "20", "26", "27"))
            {

                /*" -2564- IF LK-TIPFAV EQUAL '3' */

                if (LK_IMPOSTOS.LK_TIPFAV == "3")
                {

                    /*" -2565- MOVE 'N' TO V2FAVO-DCOISS */
                    _.Move("N", V2FAVO_DCOISS);

                    /*" -2569- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                    R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                    return;
                }

            }


            /*" -2574- MOVE 'S' TO V2FAVO-DCOISS */
            _.Move("S", V2FAVO_DCOISS);

            /*" -2575- IF V1FAVO-TPPESSOA EQUAL 'J' */

            if (V1FAVO_TPPESSOA == "J")
            {

                /*" -2576- MOVE 'N' TO V2FAVO-DCOISS */
                _.Move("N", V2FAVO_DCOISS);

                /*" -2577- ELSE */
            }
            else
            {


                /*" -2578- IF V1FAVO-INSPREFE EQUAL ZEROS */

                if (V1FAVO_INSPREFE == 00)
                {

                    /*" -2579- MOVE 'S' TO V2FAVO-DCOISS */
                    _.Move("S", V2FAVO_DCOISS);

                    /*" -2580- ELSE */
                }
                else
                {


                    /*" -2585- MOVE 'N' TO V2FAVO-DCOISS. */
                    _.Move("N", V2FAVO_DCOISS);
                }

            }


            /*" -2586- IF LK-EMPRESA NOT = 00 */

            if (LK_IMPOSTOS.LK_EMPRESA != 00)
            {

                /*" -2592- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                return;
            }


            /*" -2594- IF LK-TIPFAV EQUAL '2' AND V1FAVO-OPT-SIMPLES-M = 'S' */

            if (LK_IMPOSTOS.LK_TIPFAV == "2" && V1FAVO_OPT_SIMPLES_M == "S")
            {

                /*" -2595- MOVE V1FAVO-PCDESISS TO V1FONT-PCDESISS */
                _.Move(V1FAVO_PCDESISS, V1FONT_PCDESISS);

                /*" -2596- MOVE V1FAVO-PCDESISS TO LK-PCDESISS */
                _.Move(V1FAVO_PCDESISS, LK_IMPOSTOS.LK_PCDESISS);

                /*" -2607- DISPLAY 'FI0100S - R0240 FAVORECIDO ' LK-CODFAV ' - ME, RETEM 2% DE ISS - ALTERADO EM ' WDAT-INVERT. */

                $"FI0100S - R0240 FAVORECIDO {LK_IMPOSTOS.LK_CODFAV} - ME, RETEM 2% DE ISS - ALTERADO EM {FILLER_4.WDAT_INVERT}"
                .Display();
            }


            /*" -2612- IF LK-TIPFAV EQUAL '2' AND (LK-CODFAV EQUAL 813068 OR 901774) */

            if (LK_IMPOSTOS.LK_TIPFAV == "2" && (LK_IMPOSTOS.LK_CODFAV.In("813068", "901774")))
            {

                /*" -2613- MOVE 2,00 TO V1FONT-PCDESISS */
                _.Move(2.00, V1FONT_PCDESISS);

                /*" -2614- MOVE 2,00 TO LK-PCDESISS */
                _.Move(2.00, LK_IMPOSTOS.LK_PCDESISS);

                /*" -2622- DISPLAY 'FI0100S - R0240 FAVORECIDO ' LK-CODFAV ' - ME, RETEM 2% DE ISS' . */

                $"FI0100S - R0240 FAVORECIDO {LK_IMPOSTOS.LK_CODFAV} - ME, RETEM 2% DE ISS"
                .Display();
            }


            /*" -2623- IF LK-PROGRAMA = 'FI0009B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0009B")
            {

                /*" -2624- DISPLAY '@@@@@@@@ DISPLAY DE CONTROLE DE CALCULO ISS' */
                _.Display($"@@@@@@@@ DE CONTROLE DE CALCULO ISS");

                /*" -2625- DISPLAY 'FI0100S - CHAMADA PELO PROGRAMA FI0009B' */
                _.Display($"FI0100S - CHAMADA PELO PROGRAMA FI0009B");

                /*" -2629- DISPLAY ' COD FAVORECIDO....' LK-CODFAV ' FONTE FAVORECIDO..' LK-FONTE ' WS-TIPO-SERVICO...' WS-TIPO-SERV ' QTD. CEFFAIXAFIL..' WHOST-QTDE */

                $" COD FAVORECIDO....{LK_IMPOSTOS.LK_CODFAV} FONTE FAVORECIDO..{LK_IMPOSTOS.LK_FONTE} WS-TIPO-SERVICO...{AREA_DE_WORK.WS_MENSAGEM.WS_TIPO_SERV} QTD. CEFFAIXAFIL..{WHOST_QTDE}"
                .Display();

                /*" -2631- IF (LK-FONTE EQUAL 01 OR 06 OR 16) AND (WS-TIPO-SERV EQUAL '1' ) */

                if ((LK_IMPOSTOS.LK_FONTE.In("01", "06", "16")) && (AREA_DE_WORK.WS_MENSAGEM.WS_TIPO_SERV == "1"))
                {

                    /*" -2632- GO TO R0240-20-ISENTO-ISS */

                    R0240_20_ISENTO_ISS(); //GOTO
                    return;

                    /*" -2633- ELSE */
                }
                else
                {


                    /*" -2640- IF (LK-FONTE NOT EQUAL 04) AND (LK-FONTE NOT EQUAL 05) AND (LK-FONTE NOT EQUAL 06) AND (LK-FONTE NOT EQUAL 10) AND (LK-FONTE NOT EQUAL 11) AND (LK-FONTE NOT EQUAL 16) AND (LK-FONTE NOT EQUAL 25) */

                    if ((LK_IMPOSTOS.LK_FONTE != 04) && (LK_IMPOSTOS.LK_FONTE != 05) && (LK_IMPOSTOS.LK_FONTE != 06) && (LK_IMPOSTOS.LK_FONTE != 10) && (LK_IMPOSTOS.LK_FONTE != 11) && (LK_IMPOSTOS.LK_FONTE != 16) && (LK_IMPOSTOS.LK_FONTE != 25))
                    {

                        /*" -2641- GO TO R0240-20-ISENTO-ISS */

                        R0240_20_ISENTO_ISS(); //GOTO
                        return;

                        /*" -2642- ELSE */
                    }
                    else
                    {


                        /*" -2643- IF WS-TIPO-SERV = ' ' */

                        if (AREA_DE_WORK.WS_MENSAGEM.WS_TIPO_SERV == " ")
                        {

                            /*" -2644- GO TO R0240-20-ISENTO-ISS */

                            R0240_20_ISENTO_ISS(); //GOTO
                            return;

                            /*" -2645- ELSE */
                        }
                        else
                        {


                            /*" -2650- IF ( (LK-FONTE EQUAL 06 OR 16) AND (WS-TIPO-SERV NOT EQUAL '1' ) ) OR ( (LK-FONTE EQUAL 04) AND (WS-TIPO-SERV NOT EQUAL '7' ) ) */

                            if (((LK_IMPOSTOS.LK_FONTE.In("06", "16")) && (AREA_DE_WORK.WS_MENSAGEM.WS_TIPO_SERV != "1")) || ((LK_IMPOSTOS.LK_FONTE == 04) && (AREA_DE_WORK.WS_MENSAGEM.WS_TIPO_SERV != "7")))
                            {

                                /*" -2674- GO TO R0240-20-ISENTO-ISS. */

                                R0240_20_ISENTO_ISS(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -2677- IF LK-FONTE EQUAL 01 OR 05 OR 06 OR 10 OR 11 OR 21 OR 23 OR 25 OR 04 OR 16 */

            if (LK_IMPOSTOS.LK_FONTE.In("01", "05", "06", "10", "11", "21", "23", "25", "04", "16"))
            {

                /*" -2678- MOVE 'S' TO V2FAVO-DCOISS */
                _.Move("S", V2FAVO_DCOISS);

                /*" -2679- ELSE */
            }
            else
            {


                /*" -2681- IF V1FAVO-TPPESSOA EQUAL 'F' AND V1FAVO-INSPREFE NOT EQUAL 0 */

                if (V1FAVO_TPPESSOA == "F" && V1FAVO_INSPREFE != 0)
                {

                    /*" -2689- MOVE 'N' TO V2FAVO-DCOISS. */
                    _.Move("N", V2FAVO_DCOISS);
                }

            }


            /*" -2690- IF LK-FONTE EQUAL 12 */

            if (LK_IMPOSTOS.LK_FONTE == 12)
            {

                /*" -2691- IF LK-TIPFAV EQUAL '3' */

                if (LK_IMPOSTOS.LK_TIPFAV == "3")
                {

                    /*" -2694- MOVE 'S' TO V2FAVO-DCOISS */
                    _.Move("S", V2FAVO_DCOISS);

                    /*" -2695- MOVE 2,50 TO V1FONT-PCDESISS */
                    _.Move(2.50, V1FONT_PCDESISS);

                    /*" -2697- IF V1FAVO-TPPESSOA EQUAL 'F' AND V1FAVO-INSPREFE NOT EQUAL 0 */

                    if (V1FAVO_TPPESSOA == "F" && V1FAVO_INSPREFE != 0)
                    {

                        /*" -2704- MOVE 'N' TO V2FAVO-DCOISS. */
                        _.Move("N", V2FAVO_DCOISS);
                    }

                }

            }


            /*" -2705- IF LK-FONTE EQUAL 19 */

            if (LK_IMPOSTOS.LK_FONTE == 19)
            {

                /*" -2706- IF LK-TIPFAV EQUAL '3' */

                if (LK_IMPOSTOS.LK_TIPFAV == "3")
                {

                    /*" -2707- MOVE 'S' TO V2FAVO-DCOISS */
                    _.Move("S", V2FAVO_DCOISS);

                    /*" -2708- MOVE 3,00 TO V1FONT-PCDESISS */
                    _.Move(3.00, V1FONT_PCDESISS);

                    /*" -2709- IF V1FAVO-TPPESSOA EQUAL 'F' */

                    if (V1FAVO_TPPESSOA == "F")
                    {

                        /*" -2710- IF V1FAVO-INSPREFE NOT EQUAL 0 */

                        if (V1FAVO_INSPREFE != 0)
                        {

                            /*" -2711- MOVE 'N' TO V2FAVO-DCOISS */
                            _.Move("N", V2FAVO_DCOISS);

                            /*" -2712- ELSE */
                        }
                        else
                        {


                            /*" -2716- MOVE 10,00 TO V1FONT-PCDESISS. */
                            _.Move(10.00, V1FONT_PCDESISS);
                        }

                    }

                }

            }


            /*" -2719- IF LK-TIPFAV EQUAL '2' AND V1FAVO-TPPESSOA EQUAL 'F' AND V1FAVO-CODSVI EQUAL 3208 */

            if (LK_IMPOSTOS.LK_TIPFAV == "2" && V1FAVO_TPPESSOA == "F" && V1FAVO_CODSVI == 3208)
            {

                /*" -2723- MOVE 'N' TO V2FAVO-DCOISS. */
                _.Move("N", V2FAVO_DCOISS);
            }


            /*" -2724- IF LK-FONTE EQUAL 04 */

            if (LK_IMPOSTOS.LK_FONTE == 04)
            {

                /*" -2725- IF LK-VALBRU > 53,20 */

                if (LK_IMPOSTOS.LK_VALBRU > 53.20)
                {

                    /*" -2726- MOVE 'S' TO V2FAVO-DCOISS */
                    _.Move("S", V2FAVO_DCOISS);

                    /*" -2727- ELSE */
                }
                else
                {


                    /*" -2757- MOVE 'N' TO V2FAVO-DCOISS. */
                    _.Move("N", V2FAVO_DCOISS);
                }

            }


            /*" -2758- IF LK-PROGRAMA EQUAL 'FI0001B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0001B")
            {

                /*" -2759- MOVE LK-DCOISS TO V2FAVO-DCOISS */
                _.Move(LK_IMPOSTOS.LK_DCOISS, V2FAVO_DCOISS);

                /*" -2760- ELSE */
            }
            else
            {


                /*" -2761- IF LK-DCOISS EQUAL 'N' */

                if (LK_IMPOSTOS.LK_DCOISS == "N")
                {

                    /*" -2765- MOVE 'N' TO V2FAVO-DCOISS. */
                    _.Move("N", V2FAVO_DCOISS);
                }

            }


            /*" -2766- IF (LK-FONTE EQUAL 09 OR 16) */

            if ((LK_IMPOSTOS.LK_FONTE.In("09", "16")))
            {

                /*" -2770- IF LK-CODFAV EQUAL 116 OR 1562 OR 113689 OR 114227 OR 117005 OR 123331 OR 125342 OR 139246 OR 148032 OR 151866 OR 153745 OR 157376 OR 159352 OR 162264 OR 235751 OR 852176 OR 891743 OR 2066002 */

                if (LK_IMPOSTOS.LK_CODFAV.In("116", "1562", "113689", "114227", "117005", "123331", "125342", "139246", "148032", "151866", "153745", "157376", "159352", "162264", "235751", "852176", "891743", "2066002"))
                {

                    /*" -2773- DISPLAY 'FI0100S,R0240 - VAI DESCONTAR O ISS DA DELPHOS' ' FAV=' LK-CODFAV ' FT=' LK-FONTE ' ' V1FONT-PCDESISS '%' */

                    $"FI0100S,R0240 - VAI DESCONTAR O ISS DA DELPHOS FAV={LK_IMPOSTOS.LK_CODFAV} FT={LK_IMPOSTOS.LK_FONTE} {V1FONT_PCDESISS}%"
                    .Display();

                    /*" -2774- MOVE 'S' TO V2FAVO-DCOISS */
                    _.Move("S", V2FAVO_DCOISS);

                    /*" -2775- MOVE 'S' TO LK-DCOISS */
                    _.Move("S", LK_IMPOSTOS.LK_DCOISS);

                    /*" -2776- MOVE V1FONT-PCDESISS TO LK-PCDESISS */
                    _.Move(V1FONT_PCDESISS, LK_IMPOSTOS.LK_PCDESISS);

                    /*" -2784- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                    R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                    return;
                }

            }


            /*" -2789- IF LK-TIPFAV EQUAL '2' AND LK-CODFAV EQUAL 386194 OR 68632 */

            if (LK_IMPOSTOS.LK_TIPFAV == "2" && LK_IMPOSTOS.LK_CODFAV.In("386194", "68632"))
            {

                /*" -2790- MOVE 'N' TO V2FAVO-DCOISS */
                _.Move("N", V2FAVO_DCOISS);

                /*" -2797- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                return;
            }


            /*" -2802- IF LK-TIPFAV EQUAL '2' AND LK-CODFAV EQUAL 90841 AND LK-FONTE EQUAL 01 */

            if (LK_IMPOSTOS.LK_TIPFAV == "2" && LK_IMPOSTOS.LK_CODFAV == 90841 && LK_IMPOSTOS.LK_FONTE == 01)
            {

                /*" -2803- MOVE 'N' TO V2FAVO-DCOISS */
                _.Move("N", V2FAVO_DCOISS);

                /*" -2810- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                return;
            }


            /*" -2816- IF LK-TIPFAV EQUAL '2' AND LK-CODFAV EQUAL 1481 AND (LK-FONTE EQUAL 01 OR 21 OR 06 OR 23) */

            if (LK_IMPOSTOS.LK_TIPFAV == "2" && LK_IMPOSTOS.LK_CODFAV == 1481 && (LK_IMPOSTOS.LK_FONTE.In("01", "21", "06", "23")))
            {

                /*" -2817- MOVE 'N' TO V2FAVO-DCOISS */
                _.Move("N", V2FAVO_DCOISS);

                /*" -2836- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                return;
            }


            /*" -2864- IF LK-TIPFAV EQUAL '2' AND LK-CODFAV EQUAL 11100 OR 212781 OR 75884 OR 98353 OR 79685 OR 79758 OR 88668 OR 139246 OR 153745 OR 157376 OR 159352 OR 162264 OR 235751 OR 116 OR 1562 OR 114227 OR 113689 OR 117005 OR 123331 OR 96687 OR 11177 OR 67792 OR 94978 OR 99732 OR 81493 */

            if (LK_IMPOSTOS.LK_TIPFAV == "2" && LK_IMPOSTOS.LK_CODFAV.In("11100", "212781", "75884", "98353", "79685", "79758", "88668", "139246", "153745", "157376", "159352", "162264", "235751", "116", "1562", "114227", "113689", "117005", "123331", "96687", "11177", "67792", "94978", "99732", "81493"))
            {

                /*" -2865- MOVE 'N' TO V2FAVO-DCOISS */
                _.Move("N", V2FAVO_DCOISS);

                /*" -2876- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                return;
            }


            /*" -2884- IF LK-TIPFAV EQUAL '2' AND LK-CODFAV EQUAL 316904 OR 212325 OR 561023 OR 211315 OR 14354 */

            if (LK_IMPOSTOS.LK_TIPFAV == "2" && LK_IMPOSTOS.LK_CODFAV.In("316904", "212325", "561023", "211315", "14354"))
            {

                /*" -2885- MOVE 'N' TO V2FAVO-DCOISS */
                _.Move("N", V2FAVO_DCOISS);

                /*" -2898- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                return;
            }


            /*" -2908- IF LK-TIPFAV EQUAL '2' AND LK-CODFAV EQUAL 666903 OR 174807 OR 316905 OR 68578 OR 294228 OR 308670 OR 396299 */

            if (LK_IMPOSTOS.LK_TIPFAV == "2" && LK_IMPOSTOS.LK_CODFAV.In("666903", "174807", "316905", "68578", "294228", "308670", "396299"))
            {

                /*" -2909- MOVE 'N' TO V2FAVO-DCOISS */
                _.Move("N", V2FAVO_DCOISS);

                /*" -2919- GO TO R0240-10-MONTA-PARAMETRO-ISS. */

                R0240_10_MONTA_PARAMETRO_ISS(); //GOTO
                return;
            }


            /*" -2929- IF LK-TIPFAV EQUAL '3' AND LK-CODFAV EQUAL 17639 OR 19101 OR 19666 OR 19682 OR 23523 OR 23531 OR 102650 */

            if (LK_IMPOSTOS.LK_TIPFAV == "3" && LK_IMPOSTOS.LK_CODFAV.In("17639", "19101", "19666", "19682", "23523", "23531", "102650"))
            {

                /*" -2929- MOVE 'N' TO V2FAVO-DCOISS. */
                _.Move("N", V2FAVO_DCOISS);
            }


            /*" -0- FLUXCONTROL_PERFORM R0240_10_MONTA_PARAMETRO_ISS */

            R0240_10_MONTA_PARAMETRO_ISS();

        }

        [StopWatch]
        /*" R0240-10-MONTA-PARAMETRO-ISS */
        private void R0240_10_MONTA_PARAMETRO_ISS(bool isPerform = false)
        {
            /*" -2936- IF V2FAVO-DCOISS EQUAL 'S' */

            if (V2FAVO_DCOISS == "S")
            {

                /*" -2937- IF LK-PROGRAMA NOT = 'FI0001B' */

                if (LK_IMPOSTOS.LK_PROGRAMA != "FI0001B")
                {

                    /*" -2938- MOVE V2FAVO-DCOISS TO LK-DCOISS */
                    _.Move(V2FAVO_DCOISS, LK_IMPOSTOS.LK_DCOISS);

                    /*" -2940- MOVE V1FONT-PCDESISS TO LK-PCDESISS. */
                    _.Move(V1FONT_PCDESISS, LK_IMPOSTOS.LK_PCDESISS);
                }

            }


            /*" -2941- IF LK-PCDESISS EQUAL ZEROS */

            if (LK_IMPOSTOS.LK_PCDESISS == 00)
            {

                /*" -2941- MOVE V1FONT-PCDESISS TO LK-PCDESISS. */
                _.Move(V1FONT_PCDESISS, LK_IMPOSTOS.LK_PCDESISS);
            }


        }

        [StopWatch]
        /*" R0240-20-ISENTO-ISS */
        private void R0240_20_ISENTO_ISS(bool isPerform = false)
        {
            /*" -2950- IF V2FAVO-DCOISS EQUAL 'N' */

            if (V2FAVO_DCOISS == "N")
            {

                /*" -2954- PERFORM R0270-00-NAO-TRIBUTA-ISS. */

                R0270_00_NAO_TRIBUTA_ISS_SECTION();
            }


            /*" -2954- MOVE ZEROS TO LK-VALISS. */
            _.Move(0, LK_IMPOSTOS.LK_VALISS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-PREPARA-CALCULO-INSS-SECTION */
        private void R0250_00_PREPARA_CALCULO_INSS_SECTION()
        {
            /*" -2969- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -2971- IF V1FAVO-TPPESSOA EQUAL 'F' OR LK-DCOINSS EQUAL 'N' */

            if (V1FAVO_TPPESSOA == "F" || LK_IMPOSTOS.LK_DCOINSS == "N")
            {

                /*" -2972- PERFORM R0280-00-NAO-TRIBUTA-INSS */

                R0280_00_NAO_TRIBUTA_INSS_SECTION();

                /*" -2980- GO TO R0250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2981- MOVE ZEROS TO WS-VLBASINSS. */
            _.Move(0, AREA_DE_WORK.WS_VLBASINSS);

            /*" -2988- MOVE 11,00 TO LK-PCTINSS. */
            _.Move(11.00, LK_IMPOSTOS.LK_PCTINSS);

            /*" -2989- IF LK-PROGRAMA = 'FI0001B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0001B")
            {

                /*" -2990- MOVE LK-DCOINSS TO V1FAVO-DCOINSS */
                _.Move(LK_IMPOSTOS.LK_DCOINSS, V1FAVO_DCOINSS);

                /*" -2991- MOVE LK-VALBRU TO WS-VLBASINSS */
                _.Move(LK_IMPOSTOS.LK_VALBRU, AREA_DE_WORK.WS_VLBASINSS);

                /*" -2992- ELSE */
            }
            else
            {


                /*" -2993- IF LK-PROGRAMA = 'FI0009B' */

                if (LK_IMPOSTOS.LK_PROGRAMA == "FI0009B")
                {

                    /*" -2994- MOVE LK-DCOINSS TO V1FAVO-DCOINSS */
                    _.Move(LK_IMPOSTOS.LK_DCOINSS, V1FAVO_DCOINSS);

                    /*" -2995- MOVE LK-VALINSS TO WS-VLBASINSS */
                    _.Move(LK_IMPOSTOS.LK_VALINSS, AREA_DE_WORK.WS_VLBASINSS);

                    /*" -2996- ELSE */
                }
                else
                {


                    /*" -3000- MOVE 'N' TO LK-DCOINSS. */
                    _.Move("N", LK_IMPOSTOS.LK_DCOINSS);
                }

            }


            /*" -3001- IF LK-DCOINSS EQUAL 'N' */

            if (LK_IMPOSTOS.LK_DCOINSS == "N")
            {

                /*" -3005- PERFORM R0280-00-NAO-TRIBUTA-INSS. */

                R0280_00_NAO_TRIBUTA_INSS_SECTION();
            }


            /*" -3006- MOVE ZEROS TO LK-VALINSS LK-VALIAP. */
            _.Move(0, LK_IMPOSTOS.LK_VALINSS, LK_IMPOSTOS.LK_VALIAP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-NAO-TRIBUTA-IR-SECTION */
        private void R0260_00_NAO_TRIBUTA_IR_SECTION()
        {
            /*" -3024- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -3025- MOVE 'S' TO WS-EH-ISENTO-IR */
            _.Move("S", AREA_DE_WORK.WS_EH_ISENTO_IR);

            /*" -3026- MOVE 'N' TO V1FAVO-DCOIRF */
            _.Move("N", V1FAVO_DCOIRF);

            /*" -3027- MOVE ZEROS TO V1FAVO-PCTIRF */
            _.Move(0, V1FAVO_PCTIRF);

            /*" -3028- MOVE 'N' TO LK-DCOIRF */
            _.Move("N", LK_IMPOSTOS.LK_DCOIRF);

            /*" -3030- MOVE ZEROS TO LK-PCTIRF LK-VALIRF LK-VALDDUDEP. */
            _.Move(0, LK_IMPOSTOS.LK_PCTIRF, LK_IMPOSTOS.LK_VALIRF, LK_IMPOSTOS.LK_VALDDUDEP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-NAO-TRIBUTA-ISS-SECTION */
        private void R0270_00_NAO_TRIBUTA_ISS_SECTION()
        {
            /*" -3048- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -3049- MOVE 'S' TO WS-EH-ISENTO-ISS */
            _.Move("S", AREA_DE_WORK.WS_EH_ISENTO_ISS);

            /*" -3051- MOVE 'N' TO V1FAVO-DCOISS V2FAVO-DCOISS */
            _.Move("N", V1FAVO_DCOISS, V2FAVO_DCOISS);

            /*" -3053- MOVE ZEROS TO V1FONT-PCDESISS */
            _.Move(0, V1FONT_PCDESISS);

            /*" -3054- MOVE 'N' TO LK-DCOISS */
            _.Move("N", LK_IMPOSTOS.LK_DCOISS);

            /*" -3055- MOVE ZEROS TO LK-PCDESISS LK-VALISS. */
            _.Move(0, LK_IMPOSTOS.LK_PCDESISS, LK_IMPOSTOS.LK_VALISS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0280-00-NAO-TRIBUTA-INSS-SECTION */
        private void R0280_00_NAO_TRIBUTA_INSS_SECTION()
        {
            /*" -3073- MOVE '0280' TO WNR-EXEC-SQL. */
            _.Move("0280", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -3074- MOVE 'N' TO V1FAVO-DCOINSS */
            _.Move("N", V1FAVO_DCOINSS);

            /*" -3075- MOVE ZEROS TO V1FAVO-PCTINSS */
            _.Move(0, V1FAVO_PCTINSS);

            /*" -3076- MOVE 'N' TO LK-DCOINSS */
            _.Move("N", LK_IMPOSTOS.LK_DCOINSS);

            /*" -3078- MOVE ZEROS TO LK-PCTINSS LK-VALINSS LK-VALIAP. */
            _.Move(0, LK_IMPOSTOS.LK_PCTINSS, LK_IMPOSTOS.LK_VALINSS, LK_IMPOSTOS.LK_VALIAP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-CALCULA-IMPOSTOS-SECTION */
        private void R0300_00_CALCULA_IMPOSTOS_SECTION()
        {
            /*" -3095- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -3098- IF (LK-EMPRESA = 00 OR 10) AND (V1FAVO-TIPREG = 'B' ) AND (V4FAVO-INV-PERMANENTE = 'S' ) */

            if ((LK_IMPOSTOS.LK_EMPRESA.In("00", "10")) && (V1FAVO_TIPREG == "B") && (V4FAVO_INV_PERMANENTE == "S"))
            {

                /*" -3100- DISPLAY 'FI0100S,R0300 - INVALIDEZ PERMANENTE PARA ' ' LK-CODFAV ' LK-CODFAV */

                $"FI0100S,R0300 - INVALIDEZ PERMANENTE PARA  LK-CODFAV {LK_IMPOSTOS.LK_CODFAV}"
                .Display();

                /*" -3101- MOVE 'S' TO WS-EH-ISENTO-IR */
                _.Move("S", AREA_DE_WORK.WS_EH_ISENTO_IR);

                /*" -3102- MOVE ZEROS TO LK-VALIRF */
                _.Move(0, LK_IMPOSTOS.LK_VALIRF);

                /*" -3106- GO TO R0300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3107- IF LK-DCOIRF EQUAL 'S' */

            if (LK_IMPOSTOS.LK_DCOIRF == "S")
            {

                /*" -3111- PERFORM R0330-00-CALCULO-IRF. */

                R0330_00_CALCULO_IRF_SECTION();
            }


            /*" -3112- IF LK-PROGRAMA = 'FI0009B' */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0009B")
            {

                /*" -3113- DISPLAY 'FI0100S - CHAMADA PELO PROGRAMA FI0009B' */
                _.Display($"FI0100S - CHAMADA PELO PROGRAMA FI0009B");

                /*" -3114- DISPLAY 'LK-DCOISS......' LK-DCOISS */
                _.Display($"LK-DCOISS......{LK_IMPOSTOS.LK_DCOISS}");

                /*" -3116- DISPLAY 'LK-PCDESISS....' LK-PCDESISS. */
                _.Display($"LK-PCDESISS....{LK_IMPOSTOS.LK_PCDESISS}");
            }


            /*" -3118- IF LK-DCOISS EQUAL 'S' AND LK-PCDESISS NOT = ZEROS */

            if (LK_IMPOSTOS.LK_DCOISS == "S" && LK_IMPOSTOS.LK_PCDESISS != 00)
            {

                /*" -3122- PERFORM R0340-00-CALCULO-ISS. */

                R0340_00_CALCULO_ISS_SECTION();
            }


            /*" -3124- IF LK-DCOINSS EQUAL 'S' AND LK-PCTINSS NOT = ZEROS */

            if (LK_IMPOSTOS.LK_DCOINSS == "S" && LK_IMPOSTOS.LK_PCTINSS != 00)
            {

                /*" -3134- PERFORM R0350-00-CALCULO-INSS. */

                R0350_00_CALCULO_INSS_SECTION();
            }


            /*" -3135- INITIALIZE WS-DS0104. */
            _.Initialize(
                WS_DS0104
            );

            /*" -3138- IF (LK-PROGRAMA EQUAL 'FI0001B' ) AND (V1FAVO-TPPESSOA EQUAL 'J' ) AND (LK-VALIRF NOT EQUAL ZEROS) */

            if ((LK_IMPOSTOS.LK_PROGRAMA == "FI0001B") && (V1FAVO_TPPESSOA == "J") && (LK_IMPOSTOS.LK_VALIRF != 00))
            {

                /*" -3148- IF (V1FAVO-TIPREG EQUAL '3' OR '4' ) AND (V1FAVO-CODSVI NOT EQUAL 3208 AND V1FAVO-CODSVI NOT EQUAL 3223 AND V1FAVO-CODSVI NOT EQUAL 6891 AND V1FAVO-CODSVI NOT EQUAL 0916) */

                if ((V1FAVO_TIPREG.In("3", "4")) && (V1FAVO_CODSVI != 3208 && V1FAVO_CODSVI != 3223 && V1FAVO_CODSVI != 6891 && V1FAVO_CODSVI != 0916))
                {

                    /*" -3148- PERFORM R0360-00-NOVOS-IMPOSTOS. */

                    R0360_00_NOVOS_IMPOSTOS_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-CALCULO-IRF-SECTION */
        private void R0330_00_CALCULO_IRF_SECTION()
        {
            /*" -3169- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -3171- IF LK-PCTIRF NOT = ZEROS AND LK-TIPREG NOT = '5' */

            if (LK_IMPOSTOS.LK_PCTIRF != 00 && LK_IMPOSTOS.LK_TIPREG != "5")
            {

                /*" -3174- COMPUTE LK-VALIRF = LK-VALBRU * LK-PCTIRF / 100 */
                LK_IMPOSTOS.LK_VALIRF.Value = LK_IMPOSTOS.LK_VALBRU * LK_IMPOSTOS.LK_PCTIRF / 100f;

                /*" -3176- GO TO R0330-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3177- IF V1FAVO-TPPESSOA EQUAL 'F' */

            if (V1FAVO_TPPESSOA == "F")
            {

                /*" -3178- PERFORM R0920-00-CALCULA-IRF */

                R0920_00_CALCULA_IRF_SECTION();

                /*" -3179- ELSE */
            }
            else
            {


                /*" -3180- IF V1FAVO-TPPESSOA EQUAL 'J' */

                if (V1FAVO_TPPESSOA == "J")
                {

                    /*" -3182- COMPUTE LK-VALIRF = LK-VALBRU * LK-PCTIRF / 100. */
                    LK_IMPOSTOS.LK_VALIRF.Value = LK_IMPOSTOS.LK_VALBRU * LK_IMPOSTOS.LK_PCTIRF / 100f;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0330_00_VERIFICA_DESCONTO */

            R0330_00_VERIFICA_DESCONTO();

        }

        [StopWatch]
        /*" R0330-00-VERIFICA-DESCONTO */
        private void R0330_00_VERIFICA_DESCONTO(bool isPerform = false)
        {
            /*" -3197- IF LK-TIPREG EQUAL '5' */

            if (LK_IMPOSTOS.LK_TIPREG == "5")
            {

                /*" -3198- IF LK-VALIRF > 10,00 */

                if (LK_IMPOSTOS.LK_VALIRF > 10.00)
                {

                    /*" -3199- MOVE 'N' TO WS-EH-ISENTO-IR */
                    _.Move("N", AREA_DE_WORK.WS_EH_ISENTO_IR);

                    /*" -3200- ELSE */
                }
                else
                {


                    /*" -3201- MOVE 'S' TO WS-EH-ISENTO-IR */
                    _.Move("S", AREA_DE_WORK.WS_EH_ISENTO_IR);

                    /*" -3201- MOVE ZEROS TO LK-VALIRF. */
                    _.Move(0, LK_IMPOSTOS.LK_VALIRF);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-CALCULO-ISS-SECTION */
        private void R0340_00_CALCULO_ISS_SECTION()
        {
            /*" -3221- MOVE '0340' TO WNR-EXEC-SQL. */
            _.Move("0340", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -3223- COMPUTE LK-VALISS = LK-VALBRU * LK-PCDESISS / 100. */
            LK_IMPOSTOS.LK_VALISS.Value = LK_IMPOSTOS.LK_VALBRU * LK_IMPOSTOS.LK_PCDESISS / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-CALCULO-INSS-SECTION */
        private void R0350_00_CALCULO_INSS_SECTION()
        {
            /*" -3243- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -3245- COMPUTE LK-VALINSS = WS-VLBASINSS * LK-PCTINSS / 100. */
            LK_IMPOSTOS.LK_VALINSS.Value = AREA_DE_WORK.WS_VLBASINSS * LK_IMPOSTOS.LK_PCTINSS / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-NOVOS-IMPOSTOS-SECTION */
        private void R0360_00_NOVOS_IMPOSTOS_SECTION()
        {
            /*" -3268- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -3269- COMPUTE WS-VLR-CSLL = LK-VALBRU * 0,01. */
            WS_DS0104.WS_VLR_CSLL.Value = LK_IMPOSTOS.LK_VALBRU * 0.01;

            /*" -3270- MOVE WS-VLR-CSLL TO DISPLAY-VLRCSL */
            _.Move(WS_DS0104.WS_VLR_CSLL, WS_DS0104.DISPLAY_VLRCSL);

            /*" -3273- MOVE 5952 TO WS-CODSVI-CSLL */
            _.Move(5952, WS_DS0104.WS_CODSVI_CSLL);

            /*" -3274- COMPUTE WS-VLR-COFINS = LK-VALBRU * 0,03. */
            WS_DS0104.WS_VLR_COFINS.Value = LK_IMPOSTOS.LK_VALBRU * 0.03;

            /*" -3275- MOVE WS-VLR-COFINS TO DISPLAY-VLRCOF */
            _.Move(WS_DS0104.WS_VLR_COFINS, WS_DS0104.DISPLAY_VLRCOF);

            /*" -3278- MOVE 5952 TO WS-CODSVI-COFINS */
            _.Move(5952, WS_DS0104.WS_CODSVI_COFINS);

            /*" -3279- COMPUTE WS-VLR-PISPASEP = LK-VALBRU * 0,0065. */
            WS_DS0104.WS_VLR_PISPASEP.Value = LK_IMPOSTOS.LK_VALBRU * 0.0065;

            /*" -3280- MOVE WS-VLR-PISPASEP TO DISPLAY-VLRPIS */
            _.Move(WS_DS0104.WS_VLR_PISPASEP, WS_DS0104.DISPLAY_VLRPIS);

            /*" -3285- MOVE 5952 TO WS-CODSVI-PISPASEP */
            _.Move(5952, WS_DS0104.WS_CODSVI_PISPASEP);

            /*" -3286- IF V1FAVO-CODFAV = 1385122 */

            if (V1FAVO_CODFAV == 1385122)
            {

                /*" -3287- PERFORM R0362-00-ISENTA-COFINS */

                R0362_00_ISENTA_COFINS_SECTION();

                /*" -3291- GO TO R0360-10-DISPLAY. */

                R0360_10_DISPLAY(); //GOTO
                return;
            }


            /*" -3292- IF V1FAVO-CODFAV = 3065223 */

            if (V1FAVO_CODFAV == 3065223)
            {

                /*" -3293- PERFORM R0362-00-ISENTA-COFINS */

                R0362_00_ISENTA_COFINS_SECTION();

                /*" -3297- GO TO R0360-10-DISPLAY. */

                R0360_10_DISPLAY(); //GOTO
                return;
            }


            /*" -3298- IF V1FAVO-CODFAV = 3072118 */

            if (V1FAVO_CODFAV == 3072118)
            {

                /*" -3299- PERFORM R0362-00-ISENTA-COFINS */

                R0362_00_ISENTA_COFINS_SECTION();

                /*" -3311- GO TO R0360-10-DISPLAY. */

                R0360_10_DISPLAY(); //GOTO
                return;
            }


            /*" -3312- IF V1FAVO-CODFAV = 3120818 */

            if (V1FAVO_CODFAV == 3120818)
            {

                /*" -3313- PERFORM R0362-00-ISENTA-COFINS */

                R0362_00_ISENTA_COFINS_SECTION();

                /*" -3332- GO TO R0360-10-DISPLAY. */

                R0360_10_DISPLAY(); //GOTO
                return;
            }


            /*" -3341- IF V1FAVO-CODFAV = 1385122 OR V1FAVO-CODFAV = 444892 OR V1FAVO-CODFAV = 118541 OR V1FAVO-CODFAV = 1176087 OR V1FAVO-CODFAV = 71081 OR V1FAVO-CODFAV = 1786154 OR V1FAVO-CODFAV = 1818364 OR V1FAVO-CODFAV = 433079 OR V1FAVO-CODFAV = 152455 */

            if (V1FAVO_CODFAV == 1385122 || V1FAVO_CODFAV == 444892 || V1FAVO_CODFAV == 118541 || V1FAVO_CODFAV == 1176087 || V1FAVO_CODFAV == 71081 || V1FAVO_CODFAV == 1786154 || V1FAVO_CODFAV == 1818364 || V1FAVO_CODFAV == 433079 || V1FAVO_CODFAV == 152455)
            {

                /*" -3342- MOVE ZEROS TO WS-VLR-COFINS */
                _.Move(0, WS_DS0104.WS_VLR_COFINS);

                /*" -3343- MOVE ZEROS TO DISPLAY-VLRCOF */
                _.Move(0, WS_DS0104.DISPLAY_VLRCOF);

                /*" -3344- MOVE 5987 TO WS-CODSVI-CSLL */
                _.Move(5987, WS_DS0104.WS_CODSVI_CSLL);

                /*" -3345- MOVE ZEROS TO WS-CODSVI-COFINS */
                _.Move(0, WS_DS0104.WS_CODSVI_COFINS);

                /*" -3351- MOVE 5979 TO WS-CODSVI-PISPASEP. */
                _.Move(5979, WS_DS0104.WS_CODSVI_PISPASEP);
            }


            /*" -3353- IF V1FAVO-CODFAV = 1654304 OR V1FAVO-CODFAV = 2113969 */

            if (V1FAVO_CODFAV == 1654304 || V1FAVO_CODFAV == 2113969)
            {

                /*" -3354- MOVE 5987 TO WS-CODSVI-CSLL */
                _.Move(5987, WS_DS0104.WS_CODSVI_CSLL);

                /*" -3355- MOVE ZEROS TO WS-VLR-COFINS */
                _.Move(0, WS_DS0104.WS_VLR_COFINS);

                /*" -3356- MOVE ZEROS TO WS-VLR-PISPASEP */
                _.Move(0, WS_DS0104.WS_VLR_PISPASEP);

                /*" -3357- MOVE ZEROS TO DISPLAY-VLRCSL */
                _.Move(0, WS_DS0104.DISPLAY_VLRCSL);

                /*" -3358- MOVE ZEROS TO DISPLAY-VLRCOF */
                _.Move(0, WS_DS0104.DISPLAY_VLRCOF);

                /*" -3359- MOVE ZEROS TO WS-CODSVI-COFINS */
                _.Move(0, WS_DS0104.WS_CODSVI_COFINS);

                /*" -3386- MOVE ZEROS TO WS-CODSVI-PISPASEP. */
                _.Move(0, WS_DS0104.WS_CODSVI_PISPASEP);
            }


            /*" -3429- IF V1FAVO-CODFAV = 17477 OR V1FAVO-CODFAV = 1739761 OR V1FAVO-CODFAV = 2091958 OR V1FAVO-CODFAV = 1385122 OR V1FAVO-CODFAV = 99791 OR V1FAVO-CODFAV = 58050 OR V1FAVO-CODFAV = 1229971 OR V1FAVO-CODFAV = 856563 OR V1FAVO-CODFAV = 2218390 OR V1FAVO-CODFAV = 2220249 OR V1FAVO-CGCCPF = 2593417000130 OR V1FAVO-CODFAV = 2504422 OR V1FAVO-CODFAV = 2504423 OR V1FAVO-CODFAV = 2504424 OR V1FAVO-CODFAV = 2504425 OR V1FAVO-CODFAV = 2504429 OR V1FAVO-CODFAV = 2504434 OR V1FAVO-CODFAV = 2504438 OR V1FAVO-CODFAV = 2504441 OR V1FAVO-CODFAV = 2504444 OR V1FAVO-CODFAV = 2504447 OR V1FAVO-CODFAV = 2504452 OR V1FAVO-CODFAV = 2504456 OR V1FAVO-CODFAV = 2504469 OR V1FAVO-CODFAV = 2504472 OR V1FAVO-CODFAV = 2504475 OR V1FAVO-CODFAV = 2504477 OR V1FAVO-CODFAV = 2504479 OR V1FAVO-CODFAV = 2504481 OR V1FAVO-CODFAV = 2504482 OR V1FAVO-CODFAV = 2504483 OR V1FAVO-CODFAV = 2504484 OR V1FAVO-CODFAV = 2504485 OR V1FAVO-CODFAV = 2339831 OR V1FAVO-CODFAV = 1627298 OR V1FAVO-CODFAV = 2512142 OR V1FAVO-CODFAV = 2521984 */

            if (V1FAVO_CODFAV == 17477 || V1FAVO_CODFAV == 1739761 || V1FAVO_CODFAV == 2091958 || V1FAVO_CODFAV == 1385122 || V1FAVO_CODFAV == 99791 || V1FAVO_CODFAV == 58050 || V1FAVO_CODFAV == 1229971 || V1FAVO_CODFAV == 856563 || V1FAVO_CODFAV == 2218390 || V1FAVO_CODFAV == 2220249 || V1FAVO_CGCCPF == 2593417000130 || V1FAVO_CODFAV == 2504422 || V1FAVO_CODFAV == 2504423 || V1FAVO_CODFAV == 2504424 || V1FAVO_CODFAV == 2504425 || V1FAVO_CODFAV == 2504429 || V1FAVO_CODFAV == 2504434 || V1FAVO_CODFAV == 2504438 || V1FAVO_CODFAV == 2504441 || V1FAVO_CODFAV == 2504444 || V1FAVO_CODFAV == 2504447 || V1FAVO_CODFAV == 2504452 || V1FAVO_CODFAV == 2504456 || V1FAVO_CODFAV == 2504469 || V1FAVO_CODFAV == 2504472 || V1FAVO_CODFAV == 2504475 || V1FAVO_CODFAV == 2504477 || V1FAVO_CODFAV == 2504479 || V1FAVO_CODFAV == 2504481 || V1FAVO_CODFAV == 2504482 || V1FAVO_CODFAV == 2504483 || V1FAVO_CODFAV == 2504484 || V1FAVO_CODFAV == 2504485 || V1FAVO_CODFAV == 2339831 || V1FAVO_CODFAV == 1627298 || V1FAVO_CODFAV == 2512142 || V1FAVO_CODFAV == 2521984)
            {

                /*" -3430- MOVE ZEROS TO WS-VLR-CSLL */
                _.Move(0, WS_DS0104.WS_VLR_CSLL);

                /*" -3431- MOVE ZEROS TO WS-VLR-COFINS */
                _.Move(0, WS_DS0104.WS_VLR_COFINS);

                /*" -3432- MOVE ZEROS TO WS-VLR-PISPASEP */
                _.Move(0, WS_DS0104.WS_VLR_PISPASEP);

                /*" -3433- MOVE ZEROS TO DISPLAY-VLRCSL */
                _.Move(0, WS_DS0104.DISPLAY_VLRCSL);

                /*" -3434- MOVE ZEROS TO DISPLAY-VLRCOF */
                _.Move(0, WS_DS0104.DISPLAY_VLRCOF);

                /*" -3435- MOVE ZEROS TO DISPLAY-VLRPIS */
                _.Move(0, WS_DS0104.DISPLAY_VLRPIS);

                /*" -3436- MOVE ZEROS TO WS-CODSVI-CSLL */
                _.Move(0, WS_DS0104.WS_CODSVI_CSLL);

                /*" -3437- MOVE ZEROS TO WS-CODSVI-COFINS */
                _.Move(0, WS_DS0104.WS_CODSVI_COFINS);

                /*" -3440- MOVE ZEROS TO WS-CODSVI-PISPASEP. */
                _.Move(0, WS_DS0104.WS_CODSVI_PISPASEP);
            }


            /*" -3548- IF V1FAVO-CODFAV = 8257 OR V1FAVO-CODFAV = 15156 OR V1FAVO-CODFAV = 15199 OR V1FAVO-CODFAV = 27502 OR V1FAVO-CODFAV = 80853 OR V1FAVO-CODFAV = 80870 OR V1FAVO-CODFAV = 80896 OR V1FAVO-CODFAV = 82147 OR V1FAVO-CODFAV = 82155 OR V1FAVO-CODFAV = 82171 OR V1FAVO-CODFAV = 82953 OR V1FAVO-CODFAV = 83411 OR V1FAVO-CODFAV = 84093 OR V1FAVO-CODFAV = 84824 OR V1FAVO-CODFAV = 85375 OR V1FAVO-CODFAV = 87840 OR V1FAVO-CODFAV = 88498 OR V1FAVO-CODFAV = 90531 OR V1FAVO-CODFAV = 94773 OR V1FAVO-CODFAV = 94781 OR V1FAVO-CODFAV = 96687 OR V1FAVO-CODFAV = 98329 OR V1FAVO-CODFAV = 98337 OR V1FAVO-CODFAV = 100005 OR V1FAVO-CODFAV = 100927 OR V1FAVO-CODFAV = 100935 OR V1FAVO-CODFAV = 101095 OR V1FAVO-CODFAV = 104248 OR V1FAVO-CODFAV = 112933 OR V1FAVO-CODFAV = 117391 OR V1FAVO-CODFAV = 126331 OR V1FAVO-CODFAV = 135151 OR V1FAVO-CODFAV = 137375 OR V1FAVO-CODFAV = 138142 OR V1FAVO-CODFAV = 148318 OR V1FAVO-CODFAV = 151076 OR V1FAVO-CODFAV = 153851 OR V1FAVO-CODFAV = 169048 OR V1FAVO-CODFAV = 193763 OR V1FAVO-CODFAV = 211503 OR V1FAVO-CODFAV = 221036 OR V1FAVO-CODFAV = 225933 OR V1FAVO-CODFAV = 240224 OR V1FAVO-CODFAV = 240226 OR V1FAVO-CODFAV = 240907 OR V1FAVO-CODFAV = 240909 OR V1FAVO-CODFAV = 268363 OR V1FAVO-CODFAV = 271201 OR V1FAVO-CODFAV = 283140 OR V1FAVO-CODFAV = 324432 OR V1FAVO-CODFAV = 346350 OR V1FAVO-CODFAV = 369978 OR V1FAVO-CODFAV = 395036 OR V1FAVO-CODFAV = 395037 OR V1FAVO-CODFAV = 475328 OR V1FAVO-CODFAV = 608220 OR V1FAVO-CODFAV = 641912 OR V1FAVO-CODFAV = 807158 OR V1FAVO-CODFAV = 807159 OR V1FAVO-CODFAV = 919528 OR V1FAVO-CODFAV = 925634 OR V1FAVO-CODFAV = 1053365 OR V1FAVO-CODFAV = 1063194 OR V1FAVO-CODFAV = 1102533 OR V1FAVO-CODFAV = 1119602 OR V1FAVO-CODFAV = 1236898 OR V1FAVO-CODFAV = 1236899 OR V1FAVO-CODFAV = 1306234 OR V1FAVO-CODFAV = 1306237 OR V1FAVO-CODFAV = 1323880 OR V1FAVO-CODFAV = 1323881 OR V1FAVO-CODFAV = 1332384 OR V1FAVO-CODFAV = 1334828 OR V1FAVO-CODFAV = 1365968 OR V1FAVO-CODFAV = 1406384 OR V1FAVO-CODFAV = 1406385 OR V1FAVO-CODFAV = 1423514 OR V1FAVO-CODFAV = 1460597 OR V1FAVO-CODFAV = 1473492 OR V1FAVO-CODFAV = 1502586 OR V1FAVO-CODFAV = 1515811 OR V1FAVO-CODFAV = 1524345 OR V1FAVO-CODFAV = 1531032 OR V1FAVO-CODFAV = 1540402 OR V1FAVO-CODFAV = 1561597 OR V1FAVO-CODFAV = 1580191 OR V1FAVO-CODFAV = 1585124 OR V1FAVO-CODFAV = 1598268 OR V1FAVO-CODFAV = 1610910 OR V1FAVO-CODFAV = 1662232 OR V1FAVO-CODFAV = 1662234 OR V1FAVO-CODFAV = 1681859 OR V1FAVO-CODFAV = 1860491 OR V1FAVO-CODFAV = 1932611 OR V1FAVO-CODFAV = 1994662 OR V1FAVO-CODFAV = 2018911 OR V1FAVO-CODFAV = 2119354 OR V1FAVO-CODFAV = 2226592 OR V1FAVO-CODFAV = 2243042 OR V1FAVO-CODFAV = 2308856 OR V1FAVO-CODFAV = 2336583 OR V1FAVO-CODFAV = 2351402 OR V1FAVO-CODFAV = 2351444 OR V1FAVO-CODFAV = 2391615 OR V1FAVO-CODFAV = 2426129 OR V1FAVO-CODFAV = 2429974 OR V1FAVO-CODFAV = 2470914 OR V1FAVO-CODFAV = 2600104 */

            if (V1FAVO_CODFAV == 8257 || V1FAVO_CODFAV == 15156 || V1FAVO_CODFAV == 15199 || V1FAVO_CODFAV == 27502 || V1FAVO_CODFAV == 80853 || V1FAVO_CODFAV == 80870 || V1FAVO_CODFAV == 80896 || V1FAVO_CODFAV == 82147 || V1FAVO_CODFAV == 82155 || V1FAVO_CODFAV == 82171 || V1FAVO_CODFAV == 82953 || V1FAVO_CODFAV == 83411 || V1FAVO_CODFAV == 84093 || V1FAVO_CODFAV == 84824 || V1FAVO_CODFAV == 85375 || V1FAVO_CODFAV == 87840 || V1FAVO_CODFAV == 88498 || V1FAVO_CODFAV == 90531 || V1FAVO_CODFAV == 94773 || V1FAVO_CODFAV == 94781 || V1FAVO_CODFAV == 96687 || V1FAVO_CODFAV == 98329 || V1FAVO_CODFAV == 98337 || V1FAVO_CODFAV == 100005 || V1FAVO_CODFAV == 100927 || V1FAVO_CODFAV == 100935 || V1FAVO_CODFAV == 101095 || V1FAVO_CODFAV == 104248 || V1FAVO_CODFAV == 112933 || V1FAVO_CODFAV == 117391 || V1FAVO_CODFAV == 126331 || V1FAVO_CODFAV == 135151 || V1FAVO_CODFAV == 137375 || V1FAVO_CODFAV == 138142 || V1FAVO_CODFAV == 148318 || V1FAVO_CODFAV == 151076 || V1FAVO_CODFAV == 153851 || V1FAVO_CODFAV == 169048 || V1FAVO_CODFAV == 193763 || V1FAVO_CODFAV == 211503 || V1FAVO_CODFAV == 221036 || V1FAVO_CODFAV == 225933 || V1FAVO_CODFAV == 240224 || V1FAVO_CODFAV == 240226 || V1FAVO_CODFAV == 240907 || V1FAVO_CODFAV == 240909 || V1FAVO_CODFAV == 268363 || V1FAVO_CODFAV == 271201 || V1FAVO_CODFAV == 283140 || V1FAVO_CODFAV == 324432 || V1FAVO_CODFAV == 346350 || V1FAVO_CODFAV == 369978 || V1FAVO_CODFAV == 395036 || V1FAVO_CODFAV == 395037 || V1FAVO_CODFAV == 475328 || V1FAVO_CODFAV == 608220 || V1FAVO_CODFAV == 641912 || V1FAVO_CODFAV == 807158 || V1FAVO_CODFAV == 807159 || V1FAVO_CODFAV == 919528 || V1FAVO_CODFAV == 925634 || V1FAVO_CODFAV == 1053365 || V1FAVO_CODFAV == 1063194 || V1FAVO_CODFAV == 1102533 || V1FAVO_CODFAV == 1119602 || V1FAVO_CODFAV == 1236898 || V1FAVO_CODFAV == 1236899 || V1FAVO_CODFAV == 1306234 || V1FAVO_CODFAV == 1306237 || V1FAVO_CODFAV == 1323880 || V1FAVO_CODFAV == 1323881 || V1FAVO_CODFAV == 1332384 || V1FAVO_CODFAV == 1334828 || V1FAVO_CODFAV == 1365968 || V1FAVO_CODFAV == 1406384 || V1FAVO_CODFAV == 1406385 || V1FAVO_CODFAV == 1423514 || V1FAVO_CODFAV == 1460597 || V1FAVO_CODFAV == 1473492 || V1FAVO_CODFAV == 1502586 || V1FAVO_CODFAV == 1515811 || V1FAVO_CODFAV == 1524345 || V1FAVO_CODFAV == 1531032 || V1FAVO_CODFAV == 1540402 || V1FAVO_CODFAV == 1561597 || V1FAVO_CODFAV == 1580191 || V1FAVO_CODFAV == 1585124 || V1FAVO_CODFAV == 1598268 || V1FAVO_CODFAV == 1610910 || V1FAVO_CODFAV == 1662232 || V1FAVO_CODFAV == 1662234 || V1FAVO_CODFAV == 1681859 || V1FAVO_CODFAV == 1860491 || V1FAVO_CODFAV == 1932611 || V1FAVO_CODFAV == 1994662 || V1FAVO_CODFAV == 2018911 || V1FAVO_CODFAV == 2119354 || V1FAVO_CODFAV == 2226592 || V1FAVO_CODFAV == 2243042 || V1FAVO_CODFAV == 2308856 || V1FAVO_CODFAV == 2336583 || V1FAVO_CODFAV == 2351402 || V1FAVO_CODFAV == 2351444 || V1FAVO_CODFAV == 2391615 || V1FAVO_CODFAV == 2426129 || V1FAVO_CODFAV == 2429974 || V1FAVO_CODFAV == 2470914 || V1FAVO_CODFAV == 2600104)
            {

                /*" -3549- MOVE ZEROS TO WS-VLR-CSLL */
                _.Move(0, WS_DS0104.WS_VLR_CSLL);

                /*" -3550- MOVE ZEROS TO WS-VLR-COFINS */
                _.Move(0, WS_DS0104.WS_VLR_COFINS);

                /*" -3551- MOVE ZEROS TO WS-VLR-PISPASEP */
                _.Move(0, WS_DS0104.WS_VLR_PISPASEP);

                /*" -3552- MOVE ZEROS TO DISPLAY-VLRCSL */
                _.Move(0, WS_DS0104.DISPLAY_VLRCSL);

                /*" -3553- MOVE ZEROS TO DISPLAY-VLRCOF */
                _.Move(0, WS_DS0104.DISPLAY_VLRCOF);

                /*" -3554- MOVE ZEROS TO DISPLAY-VLRPIS */
                _.Move(0, WS_DS0104.DISPLAY_VLRPIS);

                /*" -3555- MOVE ZEROS TO WS-CODSVI-CSLL */
                _.Move(0, WS_DS0104.WS_CODSVI_CSLL);

                /*" -3556- MOVE ZEROS TO WS-CODSVI-COFINS */
                _.Move(0, WS_DS0104.WS_CODSVI_COFINS);

                /*" -3573- MOVE ZEROS TO WS-CODSVI-PISPASEP. */
                _.Move(0, WS_DS0104.WS_CODSVI_PISPASEP);
            }


            /*" -3574- IF V1FAVO-CODFAV = 997872 */

            if (V1FAVO_CODFAV == 997872)
            {

                /*" -3578- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3579- IF V1FAVO-CODFAV = 2692813 */

            if (V1FAVO_CODFAV == 2692813)
            {

                /*" -3583- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3584- IF V1FAVO-CODFAV = 2645300 */

            if (V1FAVO_CODFAV == 2645300)
            {

                /*" -3588- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3589- IF V1FAVO-CODFAV = 1321664 */

            if (V1FAVO_CODFAV == 1321664)
            {

                /*" -3599- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3600- IF V1FAVO-CODFAV = 1801053 */

            if (V1FAVO_CODFAV == 1801053)
            {

                /*" -3629- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3630- IF V1FAVO-CODFAV = 2106123 */

            if (V1FAVO_CODFAV == 2106123)
            {

                /*" -3635- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3636- IF V1FAVO-CODFAV = 4545 OR 1545722 */

            if (V1FAVO_CODFAV.In("4545", "1545722"))
            {

                /*" -3640- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3641- IF V1FAVO-CODFAV = 2719790 */

            if (V1FAVO_CODFAV == 2719790)
            {

                /*" -3645- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3646- IF V1FAVO-CODFAV = 507122 */

            if (V1FAVO_CODFAV == 507122)
            {

                /*" -3650- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3651- IF V1FAVO-CODFAV = 2723979 */

            if (V1FAVO_CODFAV == 2723979)
            {

                /*" -3662- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3663- IF V1FAVO-CODFAV = 1164983 */

            if (V1FAVO_CODFAV == 1164983)
            {

                /*" -3674- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3675- IF V1FAVO-CODFAV = 862577 */

            if (V1FAVO_CODFAV == 862577)
            {

                /*" -3679- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3680- IF V1FAVO-CODFAV = 2689691 */

            if (V1FAVO_CODFAV == 2689691)
            {

                /*" -3684- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3685- IF V1FAVO-CODFAV = 170607 */

            if (V1FAVO_CODFAV == 170607)
            {

                /*" -3690- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3692- IF V1FAVO-CODFAV = 1750178 OR V1FAVO-CODFAV = 1272507 */

            if (V1FAVO_CODFAV == 1750178 || V1FAVO_CODFAV == 1272507)
            {

                /*" -3697- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3699- IF V1FAVO-CODFAV = 2193358 OR V1FAVO-CODFAV = 2193371 */

            if (V1FAVO_CODFAV == 2193358 || V1FAVO_CODFAV == 2193371)
            {

                /*" -3703- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3704- IF V1FAVO-CODFAV = 997872 */

            if (V1FAVO_CODFAV == 997872)
            {

                /*" -3715- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3721- IF V1FAVO-CODFAV = 1086527 OR V1FAVO-CODFAV = 141248 OR V1FAVO-CODFAV = 2167132 OR V1FAVO-CODFAV = 1176088 OR V1FAVO-CODFAV = 1739761 */

            if (V1FAVO_CODFAV == 1086527 || V1FAVO_CODFAV == 141248 || V1FAVO_CODFAV == 2167132 || V1FAVO_CODFAV == 1176088 || V1FAVO_CODFAV == 1739761)
            {

                /*" -3727- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3730- IF V1FAVO-CODFAV = 118541 OR V1FAVO-CODFAV = 1786154 OR V1FAVO-CODFAV = 141348 */

            if (V1FAVO_CODFAV == 118541 || V1FAVO_CODFAV == 1786154 || V1FAVO_CODFAV == 141348)
            {

                /*" -3737- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3741- IF V1FAVO-CODFAV = 862577 OR V1FAVO-CODFAV = 2734650 OR V1FAVO-CODFAV = 2734651 OR V1FAVO-CODFAV = 118541 */

            if (V1FAVO_CODFAV == 862577 || V1FAVO_CODFAV == 2734650 || V1FAVO_CODFAV == 2734651 || V1FAVO_CODFAV == 118541)
            {

                /*" -3745- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3746- IF V1FAVO-CODFAV = 2286845 */

            if (V1FAVO_CODFAV == 2286845)
            {

                /*" -3755- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3761- IF V1FAVO-CODFAV = 2271790 OR V1FAVO-CODFAV = 2271791 OR V1FAVO-CODFAV = 2689691 OR V1FAVO-CODFAV = 1640645 OR V1FAVO-CODFAV = 1176088 OR V1FAVO-CODFAV = 1031289 */

            if (V1FAVO_CODFAV == 2271790 || V1FAVO_CODFAV == 2271791 || V1FAVO_CODFAV == 2689691 || V1FAVO_CODFAV == 1640645 || V1FAVO_CODFAV == 1176088 || V1FAVO_CODFAV == 1031289)
            {

                /*" -3765- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3766- IF V1FAVO-CODFAV = 2220249 */

            if (V1FAVO_CODFAV == 2220249)
            {

                /*" -3776- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3777- IF V1FAVO-CODFAV = 2739281 */

            if (V1FAVO_CODFAV == 2739281)
            {

                /*" -3781- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3782- IF V1FAVO-CODFAV = 2398960 */

            if (V1FAVO_CODFAV == 2398960)
            {

                /*" -3786- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3787- IF V1FAVO-CODFAV = 2286848 */

            if (V1FAVO_CODFAV == 2286848)
            {

                /*" -3791- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3792- IF V1FAVO-CODFAV = 1709258 */

            if (V1FAVO_CODFAV == 1709258)
            {

                /*" -3796- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3797- IF V1FAVO-CODFAV = 1268274 */

            if (V1FAVO_CODFAV == 1268274)
            {

                /*" -3801- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3802- IF V1FAVO-CODFAV = 80471 */

            if (V1FAVO_CODFAV == 80471)
            {

                /*" -3806- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3807- IF V1FAVO-CODFAV = 2746553 */

            if (V1FAVO_CODFAV == 2746553)
            {

                /*" -3811- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3812- IF V1FAVO-CODFAV = 1332341 */

            if (V1FAVO_CODFAV == 1332341)
            {

                /*" -3822- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3823- IF V1FAVO-CODFAV = 82023 */

            if (V1FAVO_CODFAV == 82023)
            {

                /*" -3837- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3839- IF V1FAVO-CODFAV = 2168869 OR V1FAVO-CODFAV = 1896070 */

            if (V1FAVO_CODFAV == 2168869 || V1FAVO_CODFAV == 1896070)
            {

                /*" -3843- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3844- IF V1FAVO-CODFAV = 1527904 */

            if (V1FAVO_CODFAV == 1527904)
            {

                /*" -3849- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3851- IF V1FAVO-CODFAV = 61549 OR V1FAVO-CODFAV = 2753576 */

            if (V1FAVO_CODFAV == 61549 || V1FAVO_CODFAV == 2753576)
            {

                /*" -3855- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3856- IF V1FAVO-CODFAV = 82023 */

            if (V1FAVO_CODFAV == 82023)
            {

                /*" -3860- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3861- IF V1FAVO-CODFAV = 99791 */

            if (V1FAVO_CODFAV == 99791)
            {

                /*" -3865- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3866- IF V1FAVO-CODFAV = 105783 */

            if (V1FAVO_CODFAV == 105783)
            {

                /*" -3870- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3871- IF V1FAVO-CODFAV = 2691751 */

            if (V1FAVO_CODFAV == 2691751)
            {

                /*" -3877- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3880- IF V1FAVO-CODFAV = 2202592 OR V1FAVO-CODFAV = 2336604 OR V1FAVO-CODFAV = 2783011 */

            if (V1FAVO_CODFAV == 2202592 || V1FAVO_CODFAV == 2336604 || V1FAVO_CODFAV == 2783011)
            {

                /*" -3884- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3885- IF V1FAVO-CODFAV = 1486194 */

            if (V1FAVO_CODFAV == 1486194)
            {

                /*" -3900- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -3912- IF V1FAVO-CODFAV = 4545 OR V1FAVO-CODFAV = 1545722 OR V1FAVO-CODFAV = 1786154 OR V1FAVO-CODFAV = 1818364 OR V1FAVO-CODFAV = 141348 OR V1FAVO-CODFAV = 1332341 OR V1FAVO-CODFAV = 1080810 OR V1FAVO-CODFAV = 118541 OR V1FAVO-CODFAV = 997901 OR V1FAVO-CODFAV = 1332340 OR V1FAVO-CODFAV = 2746553 */

            if (V1FAVO_CODFAV == 4545 || V1FAVO_CODFAV == 1545722 || V1FAVO_CODFAV == 1786154 || V1FAVO_CODFAV == 1818364 || V1FAVO_CODFAV == 141348 || V1FAVO_CODFAV == 1332341 || V1FAVO_CODFAV == 1080810 || V1FAVO_CODFAV == 118541 || V1FAVO_CODFAV == 997901 || V1FAVO_CODFAV == 1332340 || V1FAVO_CODFAV == 2746553)
            {

                /*" -3916- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3917- IF V1FAVO-CODFAV = 3043656 */

            if (V1FAVO_CODFAV == 3043656)
            {

                /*" -3921- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3922- IF V1FAVO-CODFAV = 3047278 */

            if (V1FAVO_CODFAV == 3047278)
            {

                /*" -3926- PERFORM R0362-00-ISENTA-COFINS. */

                R0362_00_ISENTA_COFINS_SECTION();
            }


            /*" -3929- IF V1FAVO-CODFAV = 1385077 OR V1FAVO-CODFAV = 0525062 OR V1FAVO-CODFAV = 1264533 */

            if (V1FAVO_CODFAV == 1385077 || V1FAVO_CODFAV == 0525062 || V1FAVO_CODFAV == 1264533)
            {

                /*" -3936- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4118- IF V1FAVO-CODFAV EQUAL 2018911 OR EQUAL 2047790 OR EQUAL 240224 OR EQUAL 1550740 OR EQUAL 1994662 OR EQUAL 2047791 OR EQUAL 1580191 OR EQUAL 1662247 OR EQUAL 98329 OR EQUAL 1491898 OR EQUAL 475328 OR EQUAL 1414198 OR EQUAL 268363 OR EQUAL 1832833 OR EQUAL 2600104 OR EQUAL 2621252 OR EQUAL 807158 OR EQUAL 1897643 OR EQUAL 271201 OR EQUAL 1540402 OR EQUAL 1605304 OR EQUAL 1334828 OR EQUAL 1491895 OR EQUAL 100005 OR EQUAL 255307 OR EQUAL 1467074 OR EQUAL 427184 OR EQUAL 1467071 OR EQUAL 3077 OR EQUAL 27502 OR EQUAL 1445542 OR EQUAL 1681859 OR EQUAL 1306234 OR EQUAL 211503 OR EQUAL 1445543 OR EQUAL 85375 OR EQUAL 1467073 OR EQUAL 1423514 OR EQUAL 1467072 OR EQUAL 1662232 OR EQUAL 1687117 OR EQUAL 98337 OR EQUAL 255933 OR EQUAL 2470914 OR EQUAL 2696763 OR EQUAL 641912 OR EQUAL 8257 OR EQUAL 2255915 OR EQUAL 151076 OR EQUAL 221036 OR EQUAL 1063194 OR EQUAL 1414192 OR EQUAL 84824 OR EQUAL 1119602 OR EQUAL 1550739 OR EQUAL 1236899 OR EQUAL 1236898 OR EQUAL 1687116 OR EQUAL 82147 OR EQUAL 1632903 OR EQUAL 94781 OR EQUAL 395037 OR EQUAL 87840 OR EQUAL 80870 OR EQUAL 1414202 OR EQUAL 117391 OR EQUAL 2088143 OR EQUAL 1502586 OR EQUAL 1632902 OR EQUAL 1531032 OR EQUAL 1605306 OR EQUAL 100927 OR EQUAL 2106152 OR EQUAL 1860491 OR EQUAL 1873180 OR EQUAL 1406384 OR EQUAL 1445541 OR EQUAL 817584 OR EQUAL 1323881 OR EQUAL 96687 OR EQUAL 1414201 OR EQUAL 83411 OR EQUAL 1414200 OR EQUAL 1053365 OR EQUAL 1414189 OR EQUAL 169048 OR EQUAL 104248 OR EQUAL 1605307 OR EQUAL 100935 OR EQUAL 240226 OR EQUAL 240226 OR EQUAL 283140 OR EQUAL 112933 OR EQUAL 1414196 OR EQUAL 82155 OR EQUAL 1414195 OR EQUAL 126331 OR EQUAL 2119354 OR EQUAL 2200515 OR EQUAL 1515811 OR EQUAL 1687115 OR EQUAL 2426129 OR EQUAL 2441615 OR EQUAL 2308856 OR EQUAL 2351445 OR EQUAL 90531 OR EQUAL 2027397 OR EQUAL 80853 OR EQUAL 1445545 OR EQUAL 2351402 OR EQUAL 153851 OR EQUAL 88498 OR EQUAL 193763 OR EQUAL 1662234 OR EQUAL 1721989 OR EQUAL 2429974 OR EQUAL 2709223 OR EQUAL 369978 OR EQUAL 1721990 OR EQUAL 1323880 OR EQUAL 1414190 OR EQUAL 84093 OR EQUAL 148318 OR EQUAL 135151 OR EQUAL 1491896 OR EQUAL 148318 OR EQUAL 135151 OR EQUAL 1491896 OR EQUAL 1102533 OR EQUAL 2709222 OR EQUAL 1460597 OR EQUAL 1521792 OR EQUAL 94773 OR EQUAL 1414188 OR EQUAL 1473492 OR EQUAL 1491897 OR EQUAL 1406385 OR EQUAL 1897644 OR EQUAL 80896 OR EQUAL 1414193 OR EQUAL 1365968 OR EQUAL 1414199 OR EQUAL 2351444 OR EQUAL 2403951 OR EQUAL 271200 OR EQUAL 919528 OR EQUAL 1445544 OR EQUAL 82953 OR EQUAL 1662245 OR EQUAL 807159 OR EQUAL 672574 OR EQUAL 1832834 OR EQUAL 15156 OR EQUAL 1577185 OR EQUAL 1932611 OR EQUAL 1955285 OR EQUAL 26328 OR EQUAL 2243042 OR EQUAL 2255913 OR EQUAL 101095 OR EQUAL 2226592 OR EQUAL 2239350 OR EQUAL 82171 OR EQUAL 1414203 OR EQUAL 395036 OR EQUAL 1524345 OR EQUAL 1598268 OR EQUAL 137375 OR EQUAL 15199 OR EQUAL 1550738 OR EQUAL 1610910 OR EQUAL 1662246 OR EQUAL 1585124 OR EQUAL 1605309 OR EQUAL 925634 OR EQUAL 1306237 OR EQUAL 2336583 OR EQUAL 1332384 OR EQUAL 1414191 OR EQUAL 1561597 OR EQUAL 1605305 OR EQUAL 80471 */

            if (V1FAVO_CODFAV.In("2018911", "2047790", "240224", "1550740", "1994662", "2047791", "1580191", "1662247", "98329", "1491898", "475328", "1414198", "268363", "1832833", "2600104", "2621252", "807158", "1897643", "271201", "1540402", "1605304", "1334828", "1491895", "100005", "255307", "1467074", "427184", "1467071", "3077", "27502", "1445542", "1681859", "1306234", "211503", "1445543", "85375", "1467073", "1423514", "1467072", "1662232", "1687117", "98337", "255933", "2470914", "2696763", "641912", "8257", "2255915", "151076", "221036", "1063194", "1414192", "84824", "1119602", "1550739", "1236899", "1236898", "1687116", "82147", "1632903", "94781", "395037", "87840", "80870", "1414202", "117391", "2088143", "1502586", "1632902", "1531032", "1605306", "100927", "2106152", "1860491", "1873180", "1406384", "1445541", "817584", "1323881", "96687", "1414201", "83411", "1414200", "1053365", "1414189", "169048", "104248", "1605307", "100935", "240226", "240226", "283140", "112933", "1414196", "82155", "1414195", "126331", "2119354", "2200515", "1515811", "1687115", "2426129", "2441615", "2308856", "2351445", "90531", "2027397", "80853", "1445545", "2351402", "153851", "88498", "193763", "1662234", "1721989", "2429974", "2709223", "369978", "1721990", "1323880", "1414190", "84093", "148318", "135151", "1491896", "148318", "135151", "1491896", "1102533", "2709222", "1460597", "1521792", "94773", "1414188", "1473492", "1491897", "1406385", "1897644", "80896", "1414193", "1365968", "1414199", "2351444", "2403951", "271200", "919528", "1445544", "82953", "1662245", "807159", "672574", "1832834", "15156", "1577185", "1932611", "1955285", "26328", "2243042", "2255913", "101095", "2226592", "2239350", "82171", "1414203", "395036", "1524345", "1598268", "137375", "15199", "1550738", "1610910", "1662246", "1585124", "1605309", "925634", "1306237", "2336583", "1332384", "1414191", "1561597", "1605305", "80471"))
            {

                /*" -4119- PERFORM R0361-00-LIMPA-INDICADORES */

                R0361_00_LIMPA_INDICADORES_SECTION();

                /*" -4123- END-IF. */
            }


            /*" -4128- IF V1FAVO-CODFAV = 2740666 OR V1FAVO-CODFAV = 2711476 OR V1FAVO-CODFAV = 2740664 OR V1FAVO-CODFAV = 2556871 OR V1FAVO-CODFAV = 2583195 */

            if (V1FAVO_CODFAV == 2740666 || V1FAVO_CODFAV == 2711476 || V1FAVO_CODFAV == 2740664 || V1FAVO_CODFAV == 2556871 || V1FAVO_CODFAV == 2583195)
            {

                /*" -4145- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4146- IF V1FAVO-CODFAV = 997908 */

            if (V1FAVO_CODFAV == 997908)
            {

                /*" -4150- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4151- IF V1FAVO-CODFAV = 1830248 */

            if (V1FAVO_CODFAV == 1830248)
            {

                /*" -4155- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4156- IF V1FAVO-CODFAV = 2749497 */

            if (V1FAVO_CODFAV == 2749497)
            {

                /*" -4160- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4161- IF V1FAVO-CODFAV = 212074 */

            if (V1FAVO_CODFAV == 212074)
            {

                /*" -4165- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4166- IF V1FAVO-CODFAV = 2080761 */

            if (V1FAVO_CODFAV == 2080761)
            {

                /*" -4171- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4173- IF V1FAVO-CODFAV = 2202592 OR V1FAVO-CODFAV = 2794747 */

            if (V1FAVO_CODFAV == 2202592 || V1FAVO_CODFAV == 2794747)
            {

                /*" -4178- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4180- IF V1FAVO-CODFAV = 105783 OR V1FAVO-CODFAV = 1275062 */

            if (V1FAVO_CODFAV == 105783 || V1FAVO_CODFAV == 1275062)
            {

                /*" -4185- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4187- IF V1FAVO-CODFAV = 1435697 OR V1FAVO-CODFAV = 2770357 */

            if (V1FAVO_CODFAV == 1435697 || V1FAVO_CODFAV == 2770357)
            {

                /*" -4191- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4195- IF V1FAVO-CODFAV = 2703870 OR V1FAVO-CODFAV = 2480023 OR V1FAVO-CODFAV = 2507186 OR V1FAVO-CODFAV = 94978 */

            if (V1FAVO_CODFAV == 2703870 || V1FAVO_CODFAV == 2480023 || V1FAVO_CODFAV == 2507186 || V1FAVO_CODFAV == 94978)
            {

                /*" -4206- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4208- IF V1FAVO-CODFAV = 2490719 OR V1FAVO-CODFAV = 3022481 */

            if (V1FAVO_CODFAV == 2490719 || V1FAVO_CODFAV == 3022481)
            {

                /*" -4212- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4213- IF V1FAVO-CODFAV = 105783 */

            if (V1FAVO_CODFAV == 105783)
            {

                /*" -4217- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4218- IF V1FAVO-CODFAV = 3023544 */

            if (V1FAVO_CODFAV == 3023544)
            {

                /*" -4226- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4229- IF V1FAVO-CODFAV = 1550701 */

            if (V1FAVO_CODFAV == 1550701)
            {

                /*" -4240- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4242- IF V1FAVO-CODFAV = 99791 OR V1FAVO-CODFAV = 2158397 */

            if (V1FAVO_CODFAV == 99791 || V1FAVO_CODFAV == 2158397)
            {

                /*" -4248- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4251- IF V1FAVO-CODFAV = 438300 OR V1FAVO-CODFAV = 2725131 OR V1FAVO-CODFAV = 1385077 */

            if (V1FAVO_CODFAV == 438300 || V1FAVO_CODFAV == 2725131 || V1FAVO_CODFAV == 1385077)
            {

                /*" -4255- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4256- IF V1FAVO-CODFAV = 2759168 */

            if (V1FAVO_CODFAV == 2759168)
            {

                /*" -4260- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4261- IF V1FAVO-CODFAV = 118303 */

            if (V1FAVO_CODFAV == 118303)
            {

                /*" -4266- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4268- IF V1FAVO-CODFAV = 1037836 OR V1FAVO-CODFAV = 228929 */

            if (V1FAVO_CODFAV == 1037836 || V1FAVO_CODFAV == 228929)
            {

                /*" -4275- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4279- IF V1FAVO-CODFAV = 3033165 OR V1FAVO-CODFAV = 2728085 OR V1FAVO-CODFAV = 210886 OR V1FAVO-CODFAV = 1593029 */

            if (V1FAVO_CODFAV == 3033165 || V1FAVO_CODFAV == 2728085 || V1FAVO_CODFAV == 210886 || V1FAVO_CODFAV == 1593029)
            {

                /*" -4284- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4286- IF V1FAVO-CODFAV = 87181 OR V1FAVO-CODFAV = 3033555 */

            if (V1FAVO_CODFAV == 87181 || V1FAVO_CODFAV == 3033555)
            {

                /*" -4290- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4291- IF V1FAVO-CODFAV = 3033560 */

            if (V1FAVO_CODFAV == 3033560)
            {

                /*" -4295- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4296- IF V1FAVO-CODFAV = 2188559 */

            if (V1FAVO_CODFAV == 2188559)
            {

                /*" -4301- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4303- IF V1FAVO-CODFAV = 845753 OR V1FAVO-CODFAV = 3038350 */

            if (V1FAVO_CODFAV == 845753 || V1FAVO_CODFAV == 3038350)
            {

                /*" -4309- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4312- IF V1FAVO-CODFAV = 3038765 OR V1FAVO-CODFAV = 1862630 OR V1FAVO-CODFAV = 1799646 */

            if (V1FAVO_CODFAV == 3038765 || V1FAVO_CODFAV == 1862630 || V1FAVO_CODFAV == 1799646)
            {

                /*" -4320- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4322- IF V1FAVO-CODFAV = 3041208 OR V1FAVO-CODFAV = 1538146 */

            if (V1FAVO_CODFAV == 3041208 || V1FAVO_CODFAV == 1538146)
            {

                /*" -4326- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4327- IF V1FAVO-CODFAV = 3042575 */

            if (V1FAVO_CODFAV == 3042575)
            {

                /*" -4332- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4334- IF V1FAVO-CODFAV = 2188553 OR V1FAVO-CODFAV = 3044335 */

            if (V1FAVO_CODFAV == 2188553 || V1FAVO_CODFAV == 3044335)
            {

                /*" -4341- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4345- IF V1FAVO-CODFAV = 2612186 OR V1FAVO-CODFAV = 78221 OR V1FAVO-CODFAV = 3038800 OR V1FAVO-CODFAV = 967022 */

            if (V1FAVO_CODFAV == 2612186 || V1FAVO_CODFAV == 78221 || V1FAVO_CODFAV == 3038800 || V1FAVO_CODFAV == 967022)
            {

                /*" -4349- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4350- IF V1FAVO-CODFAV = 1385122 */

            if (V1FAVO_CODFAV == 1385122)
            {

                /*" -4356- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4358- IF V1FAVO-CODFAV = 666907 OR V1FAVO-CODFAV = 3048107 */

            if (V1FAVO_CODFAV == 666907 || V1FAVO_CODFAV == 3048107)
            {

                /*" -4362- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4363- IF V1FAVO-CODFAV = 123927 */

            if (V1FAVO_CODFAV == 123927)
            {

                /*" -4367- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4368- IF V1FAVO-CODFAV = 2119388 */

            if (V1FAVO_CODFAV == 2119388)
            {

                /*" -4372- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4373- IF V1FAVO-CODFAV = 2262793 */

            if (V1FAVO_CODFAV == 2262793)
            {

                /*" -4378- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4380- IF V1FAVO-CODFAV = 2297584 OR V1FAVO-CODFAV = 2753576 */

            if (V1FAVO_CODFAV == 2297584 || V1FAVO_CODFAV == 2753576)
            {

                /*" -4384- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4385- IF V1FAVO-CODFAV = 3058286 */

            if (V1FAVO_CODFAV == 3058286)
            {

                /*" -4389- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4390- IF V1FAVO-CODFAV = 1029828 */

            if (V1FAVO_CODFAV == 1029828)
            {

                /*" -4394- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4395- IF V1FAVO-CODFAV = 3061264 */

            if (V1FAVO_CODFAV == 3061264)
            {

                /*" -4400- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4402- IF V1FAVO-CODFAV = 1242183 OR V1FAVO-CODFAV = 3047283 */

            if (V1FAVO_CODFAV == 1242183 || V1FAVO_CODFAV == 3047283)
            {

                /*" -4406- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4407- IF V1FAVO-CODFAV = 1206403 */

            if (V1FAVO_CODFAV == 1206403)
            {

                /*" -4411- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4412- IF V1FAVO-CODFAV = 1208507 */

            if (V1FAVO_CODFAV == 1208507)
            {

                /*" -4417- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4419- IF V1FAVO-CODFAV = 3033553 OR V1FAVO-CODFAV = 3034406 */

            if (V1FAVO_CODFAV == 3033553 || V1FAVO_CODFAV == 3034406)
            {

                /*" -4424- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4426- IF V1FAVO-CODFAV = 1177276 */

            if (V1FAVO_CODFAV == 1177276)
            {

                /*" -4430- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4431- IF V1FAVO-CODFAV = 899746 */

            if (V1FAVO_CODFAV == 899746)
            {

                /*" -4435- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4436- IF V1FAVO-CODFAV = 3072085 */

            if (V1FAVO_CODFAV == 3072085)
            {

                /*" -4458- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4477- IF V1FAVO-CODFAV = 1176088 OR V1FAVO-CODFAV = 1208512 OR V1FAVO-CODFAV = 1206387 OR V1FAVO-CODFAV = 3072744 OR V1FAVO-CODFAV = 1103847 OR V1FAVO-CODFAV = 2007368 OR V1FAVO-CODFAV = 1878896 OR V1FAVO-CODFAV = 1211491 OR V1FAVO-CODFAV = 1139689 OR V1FAVO-CODFAV = 1242182 OR V1FAVO-CODFAV = 1142422 OR V1FAVO-CODFAV = 1211490 OR V1FAVO-CODFAV = 1206385 */

            if (V1FAVO_CODFAV == 1176088 || V1FAVO_CODFAV == 1208512 || V1FAVO_CODFAV == 1206387 || V1FAVO_CODFAV == 3072744 || V1FAVO_CODFAV == 1103847 || V1FAVO_CODFAV == 2007368 || V1FAVO_CODFAV == 1878896 || V1FAVO_CODFAV == 1211491 || V1FAVO_CODFAV == 1139689 || V1FAVO_CODFAV == 1242182 || V1FAVO_CODFAV == 1142422 || V1FAVO_CODFAV == 1211490 || V1FAVO_CODFAV == 1206385)
            {

                /*" -4483- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4486- IF V1FAVO-CODFAV = 3067186 OR V1FAVO-CODFAV = 580650 OR V1FAVO-CODFAV = 1429787 */

            if (V1FAVO_CODFAV == 3067186 || V1FAVO_CODFAV == 580650 || V1FAVO_CODFAV == 1429787)
            {

                /*" -4490- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4491- IF V1FAVO-CODFAV = 3078454 */

            if (V1FAVO_CODFAV == 3078454)
            {

                /*" -4495- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4496- IF V1FAVO-CODFAV = 3043670 */

            if (V1FAVO_CODFAV == 3043670)
            {

                /*" -4500- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4501- IF V1FAVO-CODFAV = 3078932 */

            if (V1FAVO_CODFAV == 3078932)
            {

                /*" -4505- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4506- IF V1FAVO-CODFAV = 3078996 */

            if (V1FAVO_CODFAV == 3078996)
            {

                /*" -4510- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4511- IF V1FAVO-CODFAV = 1220151 */

            if (V1FAVO_CODFAV == 1220151)
            {

                /*" -4516- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4518- IF V1FAVO-CODFAV = 1275062 OR V1FAVO-CODFAV = 1215263 */

            if (V1FAVO_CODFAV == 1275062 || V1FAVO_CODFAV == 1215263)
            {

                /*" -4522- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4523- IF V1FAVO-CODFAV = 3079992 */

            if (V1FAVO_CODFAV == 3079992)
            {

                /*" -4528- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4530- IF V1FAVO-CODFAV = 3050410 OR V1FAVO-CODFAV = 1915342 */

            if (V1FAVO_CODFAV == 3050410 || V1FAVO_CODFAV == 1915342)
            {

                /*" -4534- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4535- IF V1FAVO-CODFAV = 3048097 */

            if (V1FAVO_CODFAV == 3048097)
            {

                /*" -4546- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4547- IF V1FAVO-CODFAV = 3081746 */

            if (V1FAVO_CODFAV == 3081746)
            {

                /*" -4551- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4552- IF V1FAVO-CODFAV = 3079509 */

            if (V1FAVO_CODFAV == 3079509)
            {

                /*" -4559- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4563- IF V1FAVO-CODFAV = 1450411 OR V1FAVO-CODFAV = 1034479 */

            if (V1FAVO_CODFAV == 1450411 || V1FAVO_CODFAV == 1034479)
            {

                /*" -4567- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4568- IF V1FAVO-CODFAV = 3114798 */

            if (V1FAVO_CODFAV == 3114798)
            {

                /*" -4572- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4573- IF V1FAVO-CODFAV = 3079509 */

            if (V1FAVO_CODFAV == 3079509)
            {

                /*" -4577- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4578- IF V1FAVO-CODFAV = 3117429 */

            if (V1FAVO_CODFAV == 3117429)
            {

                /*" -4582- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4583- IF V1FAVO-CODFAV = 3118024 */

            if (V1FAVO_CODFAV == 3118024)
            {

                /*" -4587- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4588- IF V1FAVO-CODFAV = 3118684 */

            if (V1FAVO_CODFAV == 3118684)
            {

                /*" -4592- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4593- IF V1FAVO-CODFAV = 2438961 */

            if (V1FAVO_CODFAV == 2438961)
            {

                /*" -4597- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4598- IF V1FAVO-CODFAV = 3120062 */

            if (V1FAVO_CODFAV == 3120062)
            {

                /*" -4602- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4603- IF V1FAVO-CODFAV = 3120160 */

            if (V1FAVO_CODFAV == 3120160)
            {

                /*" -4607- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4608- IF V1FAVO-CODFAV = 3117755 */

            if (V1FAVO_CODFAV == 3117755)
            {

                /*" -4613- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4615- IF V1FAVO-CODFAV = 3078579 OR V1FAVO-CODFAV = 79651 */

            if (V1FAVO_CODFAV == 3078579 || V1FAVO_CODFAV == 79651)
            {

                /*" -4619- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4620- IF V1FAVO-CODFAV = 3121711 */

            if (V1FAVO_CODFAV == 3121711)
            {

                /*" -4624- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4625- IF V1FAVO-CODFAV = 3121921 */

            if (V1FAVO_CODFAV == 3121921)
            {

                /*" -4633- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -4638- IF V1FAVO-CODFAV = 80845 OR V1FAVO-CODFAV = 961616 OR V1FAVO-CODFAV = 3129354 OR V1FAVO-CODFAV = 3074213 OR V1FAVO-CODFAV = 3049533 */

            if (V1FAVO_CODFAV == 80845 || V1FAVO_CODFAV == 961616 || V1FAVO_CODFAV == 3129354 || V1FAVO_CODFAV == 3074213 || V1FAVO_CODFAV == 3049533)
            {

                /*" -4638- PERFORM R0361-00-LIMPA-INDICADORES. */

                R0361_00_LIMPA_INDICADORES_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0360_10_DISPLAY */

            R0360_10_DISPLAY();

        }

        [StopWatch]
        /*" R0360-10-DISPLAY */
        private void R0360_10_DISPLAY(bool isPerform = false)
        {
            /*" -4648- DISPLAY 'FI0100S,R0360,F=' V1FAVO-CODFAV '-' V1FAVO-TPPESSOA '-' V1FAVO-TIPREG ' CODSVI->CSLL=' WS-CODSVI-CSLL ' COFINS=' WS-CODSVI-COFINS ' PIS=' WS-CODSVI-PISPASEP. */

            $"FI0100S,R0360,F={V1FAVO_CODFAV}-{V1FAVO_TPPESSOA}-{V1FAVO_TIPREG} CODSVI->CSLL={WS_DS0104.WS_CODSVI_CSLL} COFINS={WS_DS0104.WS_CODSVI_COFINS} PIS={WS_DS0104.WS_CODSVI_PISPASEP}"
            .Display();

            /*" -4651- DISPLAY 'FI0100S,R0360,' ' CSLL' DISPLAY-VLRCSL ' COFINS' DISPLAY-VLRCOF ' PIS' DISPLAY-VLRPIS. */

            $"FI0100S,R0360, CSLL{WS_DS0104.DISPLAY_VLRCSL} COFINS{WS_DS0104.DISPLAY_VLRCOF} PIS{WS_DS0104.DISPLAY_VLRPIS}"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0361-00-LIMPA-INDICADORES-SECTION */
        private void R0361_00_LIMPA_INDICADORES_SECTION()
        {
            /*" -4661- MOVE ZEROS TO WS-VLR-CSLL */
            _.Move(0, WS_DS0104.WS_VLR_CSLL);

            /*" -4662- MOVE ZEROS TO WS-VLR-COFINS */
            _.Move(0, WS_DS0104.WS_VLR_COFINS);

            /*" -4663- MOVE ZEROS TO WS-VLR-PISPASEP */
            _.Move(0, WS_DS0104.WS_VLR_PISPASEP);

            /*" -4664- MOVE ZEROS TO DISPLAY-VLRCSL */
            _.Move(0, WS_DS0104.DISPLAY_VLRCSL);

            /*" -4665- MOVE ZEROS TO DISPLAY-VLRCOF */
            _.Move(0, WS_DS0104.DISPLAY_VLRCOF);

            /*" -4666- MOVE ZEROS TO DISPLAY-VLRPIS */
            _.Move(0, WS_DS0104.DISPLAY_VLRPIS);

            /*" -4667- MOVE ZEROS TO WS-CODSVI-CSLL */
            _.Move(0, WS_DS0104.WS_CODSVI_CSLL);

            /*" -4668- MOVE ZEROS TO WS-CODSVI-COFINS */
            _.Move(0, WS_DS0104.WS_CODSVI_COFINS);

            /*" -4668- MOVE ZEROS TO WS-CODSVI-PISPASEP. */
            _.Move(0, WS_DS0104.WS_CODSVI_PISPASEP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0361_99_SAIDA*/

        [StopWatch]
        /*" R0362-00-ISENTA-COFINS-SECTION */
        private void R0362_00_ISENTA_COFINS_SECTION()
        {
            /*" -4679- MOVE ZEROS TO WS-VLR-COFINS */
            _.Move(0, WS_DS0104.WS_VLR_COFINS);

            /*" -4680- MOVE ZEROS TO DISPLAY-VLRCOF */
            _.Move(0, WS_DS0104.DISPLAY_VLRCOF);

            /*" -4682- MOVE ZEROS TO WS-CODSVI-COFINS */
            _.Move(0, WS_DS0104.WS_CODSVI_COFINS);

            /*" -4683- MOVE 5987 TO WS-CODSVI-CSLL */
            _.Move(5987, WS_DS0104.WS_CODSVI_CSLL);

            /*" -4683- MOVE 5979 TO WS-CODSVI-PISPASEP. */
            _.Move(5979, WS_DS0104.WS_CODSVI_PISPASEP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0362_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-ACESSA-V1FORNECEDOR-SECTION */
        private void R0420_00_ACESSA_V1FORNECEDOR_SECTION()
        {
            /*" -4696- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -4747- PERFORM R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1 */

            R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1();

            /*" -4750- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -4752- MOVE 'FI0100S,R0420 - ERRO NO SELECT V1FORNECEDOR' TO LK-MENSAGEM */
                _.Move("FI0100S,R0420 - ERRO NO SELECT V1FORNECEDOR", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4753- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4754- DISPLAY 'FI0100S - FAV = ' DISPLAY-CODFAV */
                _.Display($"FI0100S - FAV = {AREA_DE_WORK.DISPLAY_CODFAV}");

                /*" -4756- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4757- IF VIND-DTALTCC IS NEGATIVE */

            if (VIND_DTALTCC < 0)
            {

                /*" -4759- MOVE ZEROS TO V1FAVO-DATA-ALT-CC. */
                _.Move(0, V1FAVO_DATA_ALT_CC);
            }


            /*" -4760- IF VIND-PCDESISS IS NEGATIVE */

            if (VIND_PCDESISS < 0)
            {

                /*" -4762- MOVE ZEROS TO V1FAVO-PCDESISS. */
                _.Move(0, V1FAVO_PCDESISS);
            }


            /*" -4763- IF VIND-DTNASC IS NEGATIVE */

            if (VIND_DTNASC < 0)
            {

                /*" -4765- MOVE SPACES TO V4FAVO-DATA-NASC. */
                _.Move("", V4FAVO_DATA_NASC);
            }


            /*" -4767- IF V1FAVO-INSPREFE EQUAL ZEROS AND V1FAVO-INSESTAD NOT = ZEROS */

            if (V1FAVO_INSPREFE == 00 && V1FAVO_INSESTAD != 00)
            {

                /*" -4774- MOVE V1FAVO-INSESTAD TO V1FAVO-INSPREFE. */
                _.Move(V1FAVO_INSESTAD, V1FAVO_INSPREFE);
            }


            /*" -4777- IF LK-TIPREG EQUAL '3' AND LK-TIPREG NOT EQUAL V1FAVO-TIPREG AND LK-PROGRAMA NOT EQUAL 'FI0009B' */

            if (LK_IMPOSTOS.LK_TIPREG == "3" && LK_IMPOSTOS.LK_TIPREG != V1FAVO_TIPREG && LK_IMPOSTOS.LK_PROGRAMA != "FI0009B")
            {

                /*" -4779- MOVE 'FI0100S,R0420, LK-TIPREG  NOT =   V1FAVO-TIPREG' TO LK-MENSAGEM */
                _.Move("FI0100S,R0420, LK-TIPREG  NOT =   V1FAVO-TIPREG", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4780- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4781- DISPLAY 'FI0100S,R0420, FAV = ' DISPLAY-CODFAV */
                _.Display($"FI0100S,R0420, FAV = {AREA_DE_WORK.DISPLAY_CODFAV}");

                /*" -4782- DISPLAY 'FI0100S,R0420, LK-TIPREG = ' LK-TIPREG */
                _.Display($"FI0100S,R0420, LK-TIPREG = {LK_IMPOSTOS.LK_TIPREG}");

                /*" -4783- DISPLAY 'FI0100S,R0420, V1FAVO-TIPREG = ' V1FAVO-TIPREG */
                _.Display($"FI0100S,R0420, V1FAVO-TIPREG = {V1FAVO_TIPREG}");

                /*" -4789- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4791- IF V1FAVO-TIPREG EQUAL '1' OR '2' AND LK-PROGRAMA NOT = 'FI0009B' */

            if (V1FAVO_TIPREG.In("1", "2") && LK_IMPOSTOS.LK_PROGRAMA != "FI0009B")
            {

                /*" -4799- MOVE 'N' TO LK-IDTRIBUTA. */
                _.Move("N", LK_IMPOSTOS.LK_IDTRIBUTA);
            }


            /*" -4801- IF LK-PROGRAMA = 'FI0009B' AND V1FAVO-CEP = ZEROS */

            if (LK_IMPOSTOS.LK_PROGRAMA == "FI0009B" && V1FAVO_CEP == 00)
            {

                /*" -4803- MOVE 'PROBLEMA SUBROTINA FI0100S, CEP ZERADO' TO LK-MENSAGEM */
                _.Move("PROBLEMA SUBROTINA FI0100S, CEP ZERADO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4806- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4807- MOVE V1FAVO-DATA-ALT-CC TO WDAT-CC */
            _.Move(V1FAVO_DATA_ALT_CC, FILLER_4.WDAT_CC);

            /*" -4808- MOVE WDAT-CC-DIA TO WDAT-INV-DIA */
            _.Move(FILLER_4.WDAT_CC.WDAT_CC_DIA, FILLER_4.FILLER_5.WDAT_INV_DIA);

            /*" -4809- MOVE WDAT-CC-MES TO WDAT-INV-MES */
            _.Move(FILLER_4.WDAT_CC.WDAT_CC_MES, FILLER_4.FILLER_5.WDAT_INV_MES);

            /*" -4814- MOVE WDAT-CC-ANO TO WDAT-INV-ANO. */
            _.Move(FILLER_4.WDAT_CC.WDAT_CC_ANO, FILLER_4.FILLER_5.WDAT_INV_ANO);

            /*" -4815- MOVE 'N' TO WS-EH-MAIOR-65ANOS */
            _.Move("N", AREA_DE_WORK.WS_EH_MAIOR_65ANOS);

            /*" -4818- IF (LK-EMPRESA = 00 OR 10) AND (V1FAVO-TIPREG = 'B' ) AND (V4FAVO-DATA-NASC NOT = SPACES) */

            if ((LK_IMPOSTOS.LK_EMPRESA.In("00", "10")) && (V1FAVO_TIPREG == "B") && (!V4FAVO_DATA_NASC.IsEmpty()))
            {

                /*" -4819- MOVE V4FAVO-DATA-NASC TO WDAT-NASC */
                _.Move(V4FAVO_DATA_NASC, FILLER_4.WDAT_NASC);

                /*" -4820- COMPUTE WS-CALC-ANOS = WS-ANO - WDAT-NASC-ANO */
                FILLER_4.WS_CALC_ANOS.Value = AREA_DE_WORK.WS_MESANO.WS_ANO - FILLER_4.WDAT_NASC.WDAT_NASC_ANO;

                /*" -4823- IF WS-CALC-ANOS > 65 OR (WS-CALC-ANOS = 65 AND WDAT-NASC-MES < WS-MES) */

                if (FILLER_4.WS_CALC_ANOS > 65 || (FILLER_4.WS_CALC_ANOS == 65 && FILLER_4.WDAT_NASC.WDAT_NASC_MES < AREA_DE_WORK.WS_MESANO.WS_MES))
                {

                    /*" -4824- MOVE 'S' TO WS-EH-MAIOR-65ANOS */
                    _.Move("S", AREA_DE_WORK.WS_EH_MAIOR_65ANOS);

                    /*" -4835- DISPLAY 'FI0100S,R0420,F=' V1FAVO-CODFAV '-' V1FAVO-TIPREG '-' V1FAVO-TPPESSOA '-' V1FAVO-CODSVI ' DT-NASC=' V4FAVO-DATA-NASC ' ANOS=' WS-CALC-ANOS ' >65ANOS=' WS-EH-MAIOR-65ANOS. */

                    $"FI0100S,R0420,F={V1FAVO_CODFAV}-{V1FAVO_TIPREG}-{V1FAVO_TPPESSOA}-{V1FAVO_CODSVI} DT-NASC={V4FAVO_DATA_NASC} ANOS={FILLER_4.WS_CALC_ANOS} >65ANOS={AREA_DE_WORK.WS_EH_MAIOR_65ANOS}"
                    .Display();
                }

            }


            /*" -4838- IF (LK-EMPRESA = 00 OR 10) AND (V1FAVO-TIPREG = 'B' ) AND (V4FAVO-INV-PERMANENTE = 'S' ) */

            if ((LK_IMPOSTOS.LK_EMPRESA.In("00", "10")) && (V1FAVO_TIPREG == "B") && (V4FAVO_INV_PERMANENTE == "S"))
            {

                /*" -4844- MOVE LK-VALBRU TO WS-VLR-ISENTO-IR. */
                _.Move(LK_IMPOSTOS.LK_VALBRU, AREA_DE_WORK.WS_VLR_ISENTO_IR);
            }


            /*" -4845- MOVE 'N' TO WS-TEM-DESC-100 */
            _.Move("N", AREA_DE_WORK.WS_TEM_DESC_100);

            /*" -4849- IF (LK-EMPRESA = 00 OR 10) AND (WS-ANO = 2004) AND (V1FAVO-TIPREG = 'B' ) AND (V1FAVO-CODSVI = 0561) */

            if ((LK_IMPOSTOS.LK_EMPRESA.In("00", "10")) && (AREA_DE_WORK.WS_MESANO.WS_ANO == 2004) && (V1FAVO_TIPREG == "B") && (V1FAVO_CODSVI == 0561))
            {

                /*" -4849- MOVE 'S' TO WS-TEM-DESC-100. */
                _.Move("S", AREA_DE_WORK.WS_TEM_DESC_100);
            }


        }

        [StopWatch]
        /*" R0420-00-ACESSA-V1FORNECEDOR-DB-SELECT-1 */
        public void R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1()
        {
            /*" -4747- EXEC SQL SELECT NOME, NUMREC, TPPESSOA, DCOIRF, PCTIRF, OPERACAO, TIPREG, INSPREFE, INSESTAD, INSINPS, CGCCPF, DCOISS, NUM_DEP_IRF, CODSVI_ISS, DCOINSS, PCTINSS, FONTE, CEP, DATA_ALT_CC, PCDESISS, OPT_SIMPLES_MUN, DATA_NASCIMENTO, INV_PERMANENTE INTO :V1FAVO-NOMFAV, :V1FAVO-NUMREC, :V1FAVO-TPPESSOA, :V1FAVO-DCOIRF, :V1FAVO-PCTIRF, :V1FAVO-CODSVI, :V1FAVO-TIPREG, :V1FAVO-INSPREFE, :V1FAVO-INSESTAD, :V1FAVO-INSINPS, :V1FAVO-CGCCPF, :V1FAVO-DCOISS, :V1FAVO-NUMDEPIRF, :V1FAVO-CODSVISS, :V1FAVO-DCOINSS, :V1FAVO-PCTINSS, :V1FAVO-FONTE, :V1FAVO-CEP, :V1FAVO-DATA-ALT-CC:VIND-DTALTCC, :V1FAVO-PCDESISS:VIND-PCDESISS, :V1FAVO-OPT-SIMPLES-M, :V4FAVO-DATA-NASC:VIND-DTNASC, :V4FAVO-INV-PERMANENTE FROM SEGUROS.V1FORNECEDOR WHERE CLIFOR = :V1FAVO-CODFAV END-EXEC. */

            var r0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1 = new R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1()
            {
                V1FAVO_CODFAV = V1FAVO_CODFAV.ToString(),
            };

            var executed_1 = R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1.Execute(r0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FAVO_NOMFAV, V1FAVO_NOMFAV);
                _.Move(executed_1.V1FAVO_NUMREC, V1FAVO_NUMREC);
                _.Move(executed_1.V1FAVO_TPPESSOA, V1FAVO_TPPESSOA);
                _.Move(executed_1.V1FAVO_DCOIRF, V1FAVO_DCOIRF);
                _.Move(executed_1.V1FAVO_PCTIRF, V1FAVO_PCTIRF);
                _.Move(executed_1.V1FAVO_CODSVI, V1FAVO_CODSVI);
                _.Move(executed_1.V1FAVO_TIPREG, V1FAVO_TIPREG);
                _.Move(executed_1.V1FAVO_INSPREFE, V1FAVO_INSPREFE);
                _.Move(executed_1.V1FAVO_INSESTAD, V1FAVO_INSESTAD);
                _.Move(executed_1.V1FAVO_INSINPS, V1FAVO_INSINPS);
                _.Move(executed_1.V1FAVO_CGCCPF, V1FAVO_CGCCPF);
                _.Move(executed_1.V1FAVO_DCOISS, V1FAVO_DCOISS);
                _.Move(executed_1.V1FAVO_NUMDEPIRF, V1FAVO_NUMDEPIRF);
                _.Move(executed_1.V1FAVO_CODSVISS, V1FAVO_CODSVISS);
                _.Move(executed_1.V1FAVO_DCOINSS, V1FAVO_DCOINSS);
                _.Move(executed_1.V1FAVO_PCTINSS, V1FAVO_PCTINSS);
                _.Move(executed_1.V1FAVO_FONTE, V1FAVO_FONTE);
                _.Move(executed_1.V1FAVO_CEP, V1FAVO_CEP);
                _.Move(executed_1.V1FAVO_DATA_ALT_CC, V1FAVO_DATA_ALT_CC);
                _.Move(executed_1.VIND_DTALTCC, VIND_DTALTCC);
                _.Move(executed_1.V1FAVO_PCDESISS, V1FAVO_PCDESISS);
                _.Move(executed_1.VIND_PCDESISS, VIND_PCDESISS);
                _.Move(executed_1.V1FAVO_OPT_SIMPLES_M, V1FAVO_OPT_SIMPLES_M);
                _.Move(executed_1.V4FAVO_DATA_NASC, V4FAVO_DATA_NASC);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
                _.Move(executed_1.V4FAVO_INV_PERMANENTE, V4FAVO_INV_PERMANENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0430-00-ACESSA-V1PRODUTOR-SECTION */
        private void R0430_00_ACESSA_V1PRODUTOR_SECTION()
        {
            /*" -4861- MOVE '0430' TO WNR-EXEC-SQL. */
            _.Move("0430", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -4863- MOVE ZEROS TO V1FAVO-PCTIRF. */
            _.Move(0, V1FAVO_PCTIRF);

            /*" -4884- PERFORM R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1 */

            R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1();

            /*" -4887- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -4889- MOVE 'FI0100S,R0430 - ERRO NO SELECT V1PRODUTOR' TO LK-MENSAGEM */
                _.Move("FI0100S,R0430 - ERRO NO SELECT V1PRODUTOR", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4890- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4891- DISPLAY 'FI0100S,R0430 FAV = ' DISPLAY-CODFAV */
                _.Display($"FI0100S,R0430 FAV = {AREA_DE_WORK.DISPLAY_CODFAV}");

                /*" -4893- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4894- IF LK-ATUALIZA NOT EQUAL 'S' */

            if (LK_IMPOSTOS.LK_ATUALIZA != "S")
            {

                /*" -4896- GO TO R0430-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4898- MOVE V1FAVO-NUMREC TO WS-NUMREC. */
            _.Move(V1FAVO_NUMREC, AREA_DE_WORK.WS_NUMREC);

            /*" -4899- IF WS-ANOREC NOT EQUAL WS-ANO */

            if (AREA_DE_WORK.FILLER_1.WS_ANOREC != AREA_DE_WORK.WS_MESANO.WS_ANO)
            {

                /*" -4900- MOVE WS-ANO TO WS-ANOREC */
                _.Move(AREA_DE_WORK.WS_MESANO.WS_ANO, AREA_DE_WORK.FILLER_1.WS_ANOREC);

                /*" -4901- MOVE ZEROS TO WS-SEQREC */
                _.Move(0, AREA_DE_WORK.FILLER_1.WS_SEQREC);

                /*" -4907- MOVE WS-NUMREC TO V1FAVO-NUMREC. */
                _.Move(AREA_DE_WORK.WS_NUMREC, V1FAVO_NUMREC);
            }


            /*" -4908- IF LK-TIPFAV EQUAL '3' */

            if (LK_IMPOSTOS.LK_TIPFAV == "3")
            {

                /*" -4921- MOVE '3' TO V1FAVO-TIPREG */
                _.Move("3", V1FAVO_TIPREG);

                /*" -4922- IF V1FAVO-TPPESSOA EQUAL 'F' */

                if (V1FAVO_TPPESSOA == "F")
                {

                    /*" -4923- MOVE 0588 TO V1FAVO-CODSVI */
                    _.Move(0588, V1FAVO_CODSVI);

                    /*" -4924- ELSE */
                }
                else
                {


                    /*" -4924- MOVE 8045 TO V1FAVO-CODSVI. */
                    _.Move(8045, V1FAVO_CODSVI);
                }

            }


        }

        [StopWatch]
        /*" R0430-00-ACESSA-V1PRODUTOR-DB-SELECT-1 */
        public void R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1()
        {
            /*" -4884- EXEC SQL SELECT NOMPDT, NUMREC, TPPESSOA, INSPREFE, INSINPS, CGCCPF, DCOIRF, CEP INTO :V1FAVO-NOMFAV, :V1FAVO-NUMREC, :V1FAVO-TPPESSOA, :V1FAVO-INSPREFE, :V1FAVO-INSINPS, :V1FAVO-CGCCPF, :V1FAVO-DCOIRF, :V1FAVO-CEP FROM SEGUROS.V1PRODUTOR WHERE CODPDT = :V1FAVO-CODFAV END-EXEC. */

            var r0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1 = new R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1()
            {
                V1FAVO_CODFAV = V1FAVO_CODFAV.ToString(),
            };

            var executed_1 = R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1.Execute(r0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FAVO_NOMFAV, V1FAVO_NOMFAV);
                _.Move(executed_1.V1FAVO_NUMREC, V1FAVO_NUMREC);
                _.Move(executed_1.V1FAVO_TPPESSOA, V1FAVO_TPPESSOA);
                _.Move(executed_1.V1FAVO_INSPREFE, V1FAVO_INSPREFE);
                _.Move(executed_1.V1FAVO_INSINPS, V1FAVO_INSINPS);
                _.Move(executed_1.V1FAVO_CGCCPF, V1FAVO_CGCCPF);
                _.Move(executed_1.V1FAVO_DCOIRF, V1FAVO_DCOIRF);
                _.Move(executed_1.V1FAVO_CEP, V1FAVO_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/

        [StopWatch]
        /*" R0860-00-UPDATE-V1FORNECEDOR-SECTION */
        private void R0860_00_UPDATE_V1FORNECEDOR_SECTION()
        {
            /*" -4939- MOVE '0860' TO WNR-EXEC-SQL. */
            _.Move("0860", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -4944- PERFORM R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1 */

            R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1();

            /*" -4947- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -4949- MOVE 'FI0100S,R0860 - ERRO NO UPDATE V0FORNECEDOR' TO LK-MENSAGEM */
                _.Move("FI0100S,R0860 - ERRO NO UPDATE V0FORNECEDOR", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4950- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4951- DISPLAY 'FI0100S,R0860 FAV = ' DISPLAY-CODFAV */
                _.Display($"FI0100S,R0860 FAV = {AREA_DE_WORK.DISPLAY_CODFAV}");

                /*" -4951- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0860-00-UPDATE-V1FORNECEDOR-DB-UPDATE-1 */
        public void R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1()
        {
            /*" -4944- EXEC SQL UPDATE SEGUROS.V0FORNECEDOR SET NUMREC = :V1FAVO-NUMREC, TIMESTAMP = CURRENT TIMESTAMP WHERE CLIFOR = :V1FAVO-CODFAV END-EXEC. */

            var r0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1 = new R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1()
            {
                V1FAVO_NUMREC = V1FAVO_NUMREC.ToString(),
                V1FAVO_CODFAV = V1FAVO_CODFAV.ToString(),
            };

            R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1.Execute(r0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0860_99_SAIDA*/

        [StopWatch]
        /*" R0870-00-UPDATE-V1PRODUTOR-SECTION */
        private void R0870_00_UPDATE_V1PRODUTOR_SECTION()
        {
            /*" -4966- MOVE '0870' TO WNR-EXEC-SQL. */
            _.Move("0870", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -4970- PERFORM R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1 */

            R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1();

            /*" -4973- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -4975- MOVE 'FI0100S,R0870 - ERRO NO UPDATE V0PRODUTOR' TO LK-MENSAGEM */
                _.Move("FI0100S,R0870 - ERRO NO UPDATE V0PRODUTOR", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4976- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -4977- DISPLAY 'FI0100S,R0870 FAV = ' DISPLAY-CODFAV */
                _.Display($"FI0100S,R0870 FAV = {AREA_DE_WORK.DISPLAY_CODFAV}");

                /*" -4977- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0870-00-UPDATE-V1PRODUTOR-DB-UPDATE-1 */
        public void R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1()
        {
            /*" -4970- EXEC SQL UPDATE SEGUROS.V0PRODUTOR SET NUMREC = :V1FAVO-NUMREC, TIMESTAMP = CURRENT TIMESTAMP WHERE CODPDT = :V1FAVO-CODFAV END-EXEC. */

            var r0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1 = new R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1()
            {
                V1FAVO_NUMREC = V1FAVO_NUMREC.ToString(),
                V1FAVO_CODFAV = V1FAVO_CODFAV.ToString(),
            };

            R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1.Execute(r0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0870_99_SAIDA*/

        [StopWatch]
        /*" R0880-00-PREPARA-INC-RENDIM-SECTION */
        private void R0880_00_PREPARA_INC_RENDIM_SECTION()
        {
            /*" -4991- MOVE '0880' TO WNR-EXEC-SQL. */
            _.Move("0880", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -4992- MOVE V1SIST-DTMOVABE TO V0REND-DATRDT */
            _.Move(V1SIST_DTMOVABE, V0REND_DATRDT);

            /*" -4993- MOVE LK-EMPRESA TO V0REND-CODEMP */
            _.Move(LK_IMPOSTOS.LK_EMPRESA, V0REND_CODEMP);

            /*" -4997- MOVE '0' TO V0REND-SITUACAO */
            _.Move("0", V0REND_SITUACAO);

            /*" -4998- IF LK-DCOIRF EQUAL 'S' */

            if (LK_IMPOSTOS.LK_DCOIRF == "S")
            {

                /*" -4999- MOVE LK-CODSVI TO V0REND-CODSVI */
                _.Move(LK_IMPOSTOS.LK_CODSVI, V0REND_CODSVI);

                /*" -5000- MOVE LK-VALBRU TO V0REND-VALRDT */
                _.Move(LK_IMPOSTOS.LK_VALBRU, V0REND_VALRDT);

                /*" -5001- PERFORM R0890-00-INSERE-V0RENDIMENTO */

                R0890_00_INSERE_V0RENDIMENTO_SECTION();

                /*" -5002- ELSE */
            }
            else
            {


                /*" -5003- IF LK-DCOISS EQUAL 'S' */

                if (LK_IMPOSTOS.LK_DCOISS == "S")
                {

                    /*" -5004- MOVE 2222 TO V0REND-CODSVI */
                    _.Move(2222, V0REND_CODSVI);

                    /*" -5005- MOVE LK-VALBRU TO V0REND-VALRDT */
                    _.Move(LK_IMPOSTOS.LK_VALBRU, V0REND_VALRDT);

                    /*" -5009- PERFORM R0890-00-INSERE-V0RENDIMENTO. */

                    R0890_00_INSERE_V0RENDIMENTO_SECTION();
                }

            }


            /*" -5010- IF LK-VALINSS NOT EQUAL ZEROS */

            if (LK_IMPOSTOS.LK_VALINSS != 00)
            {

                /*" -5011- MOVE 5555 TO V0REND-CODSVI */
                _.Move(5555, V0REND_CODSVI);

                /*" -5012- MOVE WS-VLBASINSS TO V0REND-VALRDT */
                _.Move(AREA_DE_WORK.WS_VLBASINSS, V0REND_VALRDT);

                /*" -5012- PERFORM R0890-00-INSERE-V0RENDIMENTO. */

                R0890_00_INSERE_V0RENDIMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0880_99_SAIDA*/

        [StopWatch]
        /*" R0890-00-INSERE-V0RENDIMENTO-SECTION */
        private void R0890_00_INSERE_V0RENDIMENTO_SECTION()
        {
            /*" -5025- MOVE '0890' TO WNR-EXEC-SQL. */
            _.Move("0890", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5037- PERFORM R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1 */

            R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1();

            /*" -5040- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5042- MOVE 'FI0100S,R0890 - ERRO NO INSERT V0RENDIMENTO' TO LK-MENSAGEM */
                _.Move("FI0100S,R0890 - ERRO NO INSERT V0RENDIMENTO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5043- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5046- DISPLAY 'FI0100S - FONTE=' V1FONT-FONTE ' FAV=' V1FAVO-CODFAV ' REC=' V1FAVO-NUMREC */

                $"FI0100S - FONTE={V1FONT_FONTE} FAV={V1FAVO_CODFAV} REC={V1FAVO_NUMREC}"
                .Display();

                /*" -5050- DISPLAY 'FI0100S -    DT=' V0REND-DATRDT ' IDE=' V2FAVO-IDECBT ' SVI=' V0REND-CODSVI ' EMP=' V0REND-CODEMP */

                $"FI0100S -    DT={V0REND_DATRDT} IDE={V2FAVO_IDECBT} SVI={V0REND_CODSVI} EMP={V0REND_CODEMP}"
                .Display();

                /*" -5050- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0890-00-INSERE-V0RENDIMENTO-DB-INSERT-1 */
        public void R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1()
        {
            /*" -5037- EXEC SQL INSERT INTO SEGUROS.V0RENDIMENTO VALUES (:V1FAVO-CODFAV, :V1FAVO-NUMREC, :V0REND-DATRDT, :V0REND-VALRDT, :V2FAVO-IDECBT, :V0REND-CODSVI, :V0REND-CODEMP, CURRENT TIMESTAMP, :V0REND-SITUACAO, :V1FONT-FONTE) END-EXEC. */

            var r0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1 = new R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1()
            {
                V1FAVO_CODFAV = V1FAVO_CODFAV.ToString(),
                V1FAVO_NUMREC = V1FAVO_NUMREC.ToString(),
                V0REND_DATRDT = V0REND_DATRDT.ToString(),
                V0REND_VALRDT = V0REND_VALRDT.ToString(),
                V2FAVO_IDECBT = V2FAVO_IDECBT.ToString(),
                V0REND_CODSVI = V0REND_CODSVI.ToString(),
                V0REND_CODEMP = V0REND_CODEMP.ToString(),
                V0REND_SITUACAO = V0REND_SITUACAO.ToString(),
                V1FONT_FONTE = V1FONT_FONTE.ToString(),
            };

            R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1.Execute(r0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0890_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-PREPARA-INC-IMPOSTO-SECTION */
        private void R0900_00_PREPARA_INC_IMPOSTO_SECTION()
        {
            /*" -5064- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5065- MOVE V1SIST-DTMOVABE TO V0IMPO-DATIPT */
            _.Move(V1SIST_DTMOVABE, V0IMPO_DATIPT);

            /*" -5066- MOVE LK-EMPRESA TO V0IMPO-CODEMP */
            _.Move(LK_IMPOSTOS.LK_EMPRESA, V0IMPO_CODEMP);

            /*" -5070- MOVE '0' TO V0IMPO-SITUACAO */
            _.Move("0", V0IMPO_SITUACAO);

            /*" -5071- IF LK-VALIRF NOT EQUAL ZEROS */

            if (LK_IMPOSTOS.LK_VALIRF != 00)
            {

                /*" -5072- MOVE '1' TO V0IMPO-TIPIPT */
                _.Move("1", V0IMPO_TIPIPT);

                /*" -5073- MOVE LK-VALIRF TO V0IMPO-VALIPT */
                _.Move(LK_IMPOSTOS.LK_VALIRF, V0IMPO_VALIPT);

                /*" -5074- MOVE LK-CODSVI TO V0IMPO-CODSVI */
                _.Move(LK_IMPOSTOS.LK_CODSVI, V0IMPO_CODSVI);

                /*" -5078- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


            /*" -5079- IF LK-VALISS NOT EQUAL ZEROS */

            if (LK_IMPOSTOS.LK_VALISS != 00)
            {

                /*" -5080- MOVE '2' TO V0IMPO-TIPIPT */
                _.Move("2", V0IMPO_TIPIPT);

                /*" -5081- MOVE LK-VALISS TO V0IMPO-VALIPT */
                _.Move(LK_IMPOSTOS.LK_VALISS, V0IMPO_VALIPT);

                /*" -5082- MOVE 2222 TO V0IMPO-CODSVI */
                _.Move(2222, V0IMPO_CODSVI);

                /*" -5086- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


            /*" -5087- IF LK-VALIAP NOT EQUAL ZEROS */

            if (LK_IMPOSTOS.LK_VALIAP != 00)
            {

                /*" -5088- MOVE '3' TO V0IMPO-TIPIPT */
                _.Move("3", V0IMPO_TIPIPT);

                /*" -5089- MOVE LK-VALIAP TO V0IMPO-VALIPT */
                _.Move(LK_IMPOSTOS.LK_VALIAP, V0IMPO_VALIPT);

                /*" -5090- MOVE V0REND-CODSVI TO V0IMPO-CODSVI */
                _.Move(V0REND_CODSVI, V0IMPO_CODSVI);

                /*" -5094- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


            /*" -5095- IF LK-VALINSS NOT EQUAL ZEROS */

            if (LK_IMPOSTOS.LK_VALINSS != 00)
            {

                /*" -5096- MOVE '5' TO V0IMPO-TIPIPT */
                _.Move("5", V0IMPO_TIPIPT);

                /*" -5097- MOVE LK-VALINSS TO V0IMPO-VALIPT */
                _.Move(LK_IMPOSTOS.LK_VALINSS, V0IMPO_VALIPT);

                /*" -5098- MOVE 5555 TO V0IMPO-CODSVI */
                _.Move(5555, V0IMPO_CODSVI);

                /*" -5102- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


            /*" -5103- IF LK-VALDDUDEP > ZEROS */

            if (LK_IMPOSTOS.LK_VALDDUDEP > 00)
            {

                /*" -5104- MOVE 'D' TO V0IMPO-TIPIPT */
                _.Move("D", V0IMPO_TIPIPT);

                /*" -5105- MOVE LK-VALDDUDEP TO V0IMPO-VALIPT */
                _.Move(LK_IMPOSTOS.LK_VALDDUDEP, V0IMPO_VALIPT);

                /*" -5106- MOVE LK-CODSVI TO V0IMPO-CODSVI */
                _.Move(LK_IMPOSTOS.LK_CODSVI, V0IMPO_CODSVI);

                /*" -5110- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


            /*" -5111- IF V4IRF-LIMSUP > ZEROS */

            if (V4IRF_LIMSUP > 00)
            {

                /*" -5112- MOVE 'A' TO V0IMPO-TIPIPT */
                _.Move("A", V0IMPO_TIPIPT);

                /*" -5113- MOVE V4IRF-LIMSUP TO V0IMPO-VALIPT */
                _.Move(V4IRF_LIMSUP, V0IMPO_VALIPT);

                /*" -5114- MOVE LK-CODSVI TO V0IMPO-CODSVI */
                _.Move(LK_IMPOSTOS.LK_CODSVI, V0IMPO_CODSVI);

                /*" -5118- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


            /*" -5119- IF WS-VLR-ISENTO-IR > ZEROS */

            if (AREA_DE_WORK.WS_VLR_ISENTO_IR > 00)
            {

                /*" -5120- MOVE 'I' TO V0IMPO-TIPIPT */
                _.Move("I", V0IMPO_TIPIPT);

                /*" -5121- MOVE WS-VLR-ISENTO-IR TO V0IMPO-VALIPT */
                _.Move(AREA_DE_WORK.WS_VLR_ISENTO_IR, V0IMPO_VALIPT);

                /*" -5122- MOVE LK-CODSVI TO V0IMPO-CODSVI */
                _.Move(LK_IMPOSTOS.LK_CODSVI, V0IMPO_CODSVI);

                /*" -5123- MOVE ZEROS TO WS-VLR-ISENTO-IR */
                _.Move(0, AREA_DE_WORK.WS_VLR_ISENTO_IR);

                /*" -5127- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


            /*" -5128- IF WS-VLR-CSLL NOT EQUAL ZEROS */

            if (WS_DS0104.WS_VLR_CSLL != 00)
            {

                /*" -5129- MOVE '7' TO V0IMPO-TIPIPT */
                _.Move("7", V0IMPO_TIPIPT);

                /*" -5131- MOVE WS-VLR-CSLL TO V0IMPO-VALIPT */
                _.Move(WS_DS0104.WS_VLR_CSLL, V0IMPO_VALIPT);

                /*" -5132- MOVE WS-CODSVI-CSLL TO V0IMPO-CODSVI */
                _.Move(WS_DS0104.WS_CODSVI_CSLL, V0IMPO_CODSVI);

                /*" -5136- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


            /*" -5137- IF WS-VLR-COFINS NOT EQUAL ZEROS */

            if (WS_DS0104.WS_VLR_COFINS != 00)
            {

                /*" -5138- MOVE '8' TO V0IMPO-TIPIPT */
                _.Move("8", V0IMPO_TIPIPT);

                /*" -5140- MOVE WS-VLR-COFINS TO V0IMPO-VALIPT */
                _.Move(WS_DS0104.WS_VLR_COFINS, V0IMPO_VALIPT);

                /*" -5141- MOVE WS-CODSVI-COFINS TO V0IMPO-CODSVI */
                _.Move(WS_DS0104.WS_CODSVI_COFINS, V0IMPO_CODSVI);

                /*" -5145- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


            /*" -5146- IF WS-VLR-PISPASEP NOT EQUAL ZEROS */

            if (WS_DS0104.WS_VLR_PISPASEP != 00)
            {

                /*" -5147- MOVE '9' TO V0IMPO-TIPIPT */
                _.Move("9", V0IMPO_TIPIPT);

                /*" -5149- MOVE WS-VLR-PISPASEP TO V0IMPO-VALIPT */
                _.Move(WS_DS0104.WS_VLR_PISPASEP, V0IMPO_VALIPT);

                /*" -5150- MOVE WS-CODSVI-PISPASEP TO V0IMPO-CODSVI */
                _.Move(WS_DS0104.WS_CODSVI_PISPASEP, V0IMPO_CODSVI);

                /*" -5150- PERFORM R0910-00-INSERT-V0IMPOSTOS. */

                R0910_00_INSERT_V0IMPOSTOS_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-INSERT-V0IMPOSTOS-SECTION */
        private void R0910_00_INSERT_V0IMPOSTOS_SECTION()
        {
            /*" -5164- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5177- PERFORM R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1 */

            R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1();

            /*" -5180- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5182- MOVE 'FI0100S,R0910 - ERRO NO INSERT V0IMPOSTOS' TO LK-MENSAGEM */
                _.Move("FI0100S,R0910 - ERRO NO INSERT V0IMPOSTOS", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5183- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5186- DISPLAY 'FI0100S - FONTE=' V1FONT-FONTE ' FAV=' V1FAVO-CODFAV ' REC=' V1FAVO-NUMREC */

                $"FI0100S - FONTE={V1FONT_FONTE} FAV={V1FAVO_CODFAV} REC={V1FAVO_NUMREC}"
                .Display();

                /*" -5191- DISPLAY 'FI0100S -    DT=' V0IMPO-DATIPT ' IPT=' V0IMPO-TIPIPT ' IDE=' V2FAVO-IDECBT ' SVI=' V0IMPO-CODSVI ' EMP=' V0IMPO-CODEMP */

                $"FI0100S -    DT={V0IMPO_DATIPT} IPT={V0IMPO_TIPIPT} IDE={V2FAVO_IDECBT} SVI={V0IMPO_CODSVI} EMP={V0IMPO_CODEMP}"
                .Display();

                /*" -5191- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0910-00-INSERT-V0IMPOSTOS-DB-INSERT-1 */
        public void R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1()
        {
            /*" -5177- EXEC SQL INSERT INTO SEGUROS.V0IMPOSTOS VALUES (:V1FAVO-CODFAV, :V1FAVO-NUMREC, :V0IMPO-DATIPT, :V0IMPO-TIPIPT, :V0IMPO-VALIPT, :V2FAVO-IDECBT, :V0IMPO-CODSVI, :V0IMPO-CODEMP, CURRENT TIMESTAMP, :V0IMPO-SITUACAO, :V1FONT-FONTE) END-EXEC. */

            var r0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1 = new R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1()
            {
                V1FAVO_CODFAV = V1FAVO_CODFAV.ToString(),
                V1FAVO_NUMREC = V1FAVO_NUMREC.ToString(),
                V0IMPO_DATIPT = V0IMPO_DATIPT.ToString(),
                V0IMPO_TIPIPT = V0IMPO_TIPIPT.ToString(),
                V0IMPO_VALIPT = V0IMPO_VALIPT.ToString(),
                V2FAVO_IDECBT = V2FAVO_IDECBT.ToString(),
                V0IMPO_CODSVI = V0IMPO_CODSVI.ToString(),
                V0IMPO_CODEMP = V0IMPO_CODEMP.ToString(),
                V0IMPO_SITUACAO = V0IMPO_SITUACAO.ToString(),
                V1FONT_FONTE = V1FONT_FONTE.ToString(),
            };

            R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1.Execute(r0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0920-00-CALCULA-IRF-SECTION */
        private void R0920_00_CALCULA_IRF_SECTION()
        {
            /*" -5213- MOVE '0920' TO WNR-EXEC-SQL. */
            _.Move("0920", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5217- MOVE LK-EMPRESA TO WHOST-CODEMP */
            _.Move(LK_IMPOSTOS.LK_EMPRESA, WHOST_CODEMP);

            /*" -5221- PERFORM R0930-00-SOMA-RENDIMENTO */

            R0930_00_SOMA_RENDIMENTO_SECTION();

            /*" -5226- COMPUTE V2IRF-VALBRU = LK-VALBRU + V1REND-VALRDT. */
            V2IRF_VALBRU.Value = LK_IMPOSTOS.LK_VALBRU + V1REND_VALRDT;

            /*" -5246- PERFORM R0940-00-SOMA-IMPOSTO. */

            R0940_00_SOMA_IMPOSTO_SECTION();

            /*" -5247- MOVE V2IRF-VALBRU TO DISPLAY-VALOR */
            _.Move(V2IRF_VALBRU, AREA_DE_WORK.DISPLAY_VALOR);

            /*" -5252- MOVE ZEROS TO V3IRF-VALDEP LK-VALDDUDEP DISPLAY-VLBASE DISPLAY-VALDEP DISPLAY-VALDDUDEP */
            _.Move(0, V3IRF_VALDEP, LK_IMPOSTOS.LK_VALDDUDEP, AREA_DE_WORK.DISPLAY_VLBASE, AREA_DE_WORK.DISPLAY_VALDEP, AREA_DE_WORK.DISPLAY_VALDDUDEP);

            /*" -5254- MOVE ZEROS TO V4IRF-LIMSUP DISPLAY-LIMSUP */
            _.Move(0, V4IRF_LIMSUP, AREA_DE_WORK.DISPLAY_LIMSUP);

            /*" -5255- IF (LK-EMPRESA = 00 OR 10) */

            if ((LK_IMPOSTOS.LK_EMPRESA.In("00", "10")))
            {

                /*" -5256- IF (LK-TIPFAV = '2' ) */

                if ((LK_IMPOSTOS.LK_TIPFAV == "2"))
                {

                    /*" -5259- IF (V1FAVO-NUMDEPIRF > ZEROS) OR (WS-EH-MAIOR-65ANOS = 'S' ) OR (WS-TEM-DESC-100 = 'S' ) */

                    if ((V1FAVO_NUMDEPIRF > 00) || (AREA_DE_WORK.WS_EH_MAIOR_65ANOS == "S") || (AREA_DE_WORK.WS_TEM_DESC_100 == "S"))
                    {

                        /*" -5262- PERFORM R0946-00-APLICA-DEDUCOES. */

                        R0946_00_APLICA_DEDUCOES_SECTION();
                    }

                }

            }


            /*" -5263- IF V2IRF-VALBRU <= ZEROS */

            if (V2IRF_VALBRU <= 00)
            {

                /*" -5264- DISPLAY 'FI0100S,R0920 - SAIU COM V2IRF-VALBRU <= ZEROS' */
                _.Display($"FI0100S,R0920 - SAIU COM V2IRF-VALBRU <= ZEROS");

                /*" -5266- GO TO R0920-99-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_EXIT*/ //GOTO
                return;
            }


            /*" -5267- IF LK-TIPREG NOT EQUAL '5' */

            if (LK_IMPOSTOS.LK_TIPREG != "5")
            {

                /*" -5268- PERFORM R0950-00-ACESSA-V1IRFONTE */

                R0950_00_ACESSA_V1IRFONTE_SECTION();

                /*" -5272- COMPUTE LK-VALIRF = (V2IRF-VALBRU * V1IRF-ALQIPT) / 100 - V1IRF-VALDDU */
                LK_IMPOSTOS.LK_VALIRF.Value = (V2IRF_VALBRU * V1IRF_ALQIPT) / 100f - V1IRF_VALDDU;

                /*" -5273- ELSE */
            }
            else
            {


                /*" -5277- COMPUTE LK-VALIRF = V2IRF-VALBRU * LK-PCTIRF / 100. */
                LK_IMPOSTOS.LK_VALIRF.Value = V2IRF_VALBRU * LK_IMPOSTOS.LK_PCTIRF / 100f;
            }


            /*" -5280- COMPUTE LK-VALIRF = LK-VALIRF - V1IMPO-VLIMPOST. */
            LK_IMPOSTOS.LK_VALIRF.Value = LK_IMPOSTOS.LK_VALIRF - V1IMPO_VLIMPOST;

            /*" -5281- IF LK-PCTIRF EQUAL ZEROS */

            if (LK_IMPOSTOS.LK_PCTIRF == 00)
            {

                /*" -5281- MOVE V1FAVO-PCTIRF TO LK-PCTIRF. */
                _.Move(V1FAVO_PCTIRF, LK_IMPOSTOS.LK_PCTIRF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_EXIT*/

        [StopWatch]
        /*" R0930-00-SOMA-RENDIMENTO-SECTION */
        private void R0930_00_SOMA_RENDIMENTO_SECTION()
        {
            /*" -5296- MOVE '0930' TO WNR-EXEC-SQL. */
            _.Move("0930", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5308- PERFORM R0930_00_SOMA_RENDIMENTO_DB_SELECT_1 */

            R0930_00_SOMA_RENDIMENTO_DB_SELECT_1();

            /*" -5311- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5313- MOVE 'FI0100S,R0930 - ERRO NO SELECT V1RENDIMENTO' TO LK-MENSAGEM */
                _.Move("FI0100S,R0930 - ERRO NO SELECT V1RENDIMENTO", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5314- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5315- MOVE LK-VALBRU TO DISPLAY-VALOR */
                _.Move(LK_IMPOSTOS.LK_VALBRU, AREA_DE_WORK.DISPLAY_VALOR);

                /*" -5316- MOVE V1REND-VALRDT TO DISPLAY-VALIRF */
                _.Move(V1REND_VALRDT, AREA_DE_WORK.DISPLAY_VALIRF);

                /*" -5322- DISPLAY 'FI0100S - FAV=' V1FAVO-CODFAV ' IDE=' V2FAVO-IDECBT ' WS-DTINIREF=' WS-DTINIREF ' WS-DTFIMREF=' WS-DTFIMREF ' B=' DISPLAY-VALOR ' IR=' DISPLAY-VALIRF */

                $"FI0100S - FAV={V1FAVO_CODFAV} IDE={V2FAVO_IDECBT} WS-DTINIREF={WS_DTINIREF} WS-DTFIMREF={WS_DTFIMREF} B={AREA_DE_WORK.DISPLAY_VALOR} IR={AREA_DE_WORK.DISPLAY_VALIRF}"
                .Display();

                /*" -5322- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0930-00-SOMA-RENDIMENTO-DB-SELECT-1 */
        public void R0930_00_SOMA_RENDIMENTO_DB_SELECT_1()
        {
            /*" -5308- EXEC SQL SELECT VALUE(SUM(VALRDT), 0) INTO :V1REND-VALRDT FROM SEGUROS.V1RENDIMENTO WHERE IDECBT = :V2FAVO-IDECBT AND CODPDT = :V1FAVO-CODFAV AND SITUACAO IN ( '0' , '1' ) AND CODSVI IN (0,0561,0588,3208, 8045,3223,0916) AND (DATRDT BETWEEN :WS-DTINIREF AND :WS-DTFIMREF) AND COD_EMPRESA = :WHOST-CODEMP END-EXEC. */

            var r0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1 = new R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1()
            {
                V2FAVO_IDECBT = V2FAVO_IDECBT.ToString(),
                V1FAVO_CODFAV = V1FAVO_CODFAV.ToString(),
                WHOST_CODEMP = WHOST_CODEMP.ToString(),
                WS_DTINIREF = WS_DTINIREF.ToString(),
                WS_DTFIMREF = WS_DTFIMREF.ToString(),
            };

            var executed_1 = R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1.Execute(r0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1REND_VALRDT, V1REND_VALRDT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_EXIT*/

        [StopWatch]
        /*" R0940-00-SOMA-IMPOSTO-SECTION */
        private void R0940_00_SOMA_IMPOSTO_SECTION()
        {
            /*" -5337- MOVE '0940' TO WNR-EXEC-SQL. */
            _.Move("0940", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5348- PERFORM R0940_00_SOMA_IMPOSTO_DB_SELECT_1 */

            R0940_00_SOMA_IMPOSTO_DB_SELECT_1();

            /*" -5351- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5353- MOVE 'FI0100S,R0940 - ERRO NO SELECT V1IMPOSTOS' TO LK-MENSAGEM */
                _.Move("FI0100S,R0940 - ERRO NO SELECT V1IMPOSTOS", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5354- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5355- MOVE LK-VALBRU TO DISPLAY-VALOR */
                _.Move(LK_IMPOSTOS.LK_VALBRU, AREA_DE_WORK.DISPLAY_VALOR);

                /*" -5356- MOVE V1IMPO-VLIMPOST TO DISPLAY-VALIRF */
                _.Move(V1IMPO_VLIMPOST, AREA_DE_WORK.DISPLAY_VALIRF);

                /*" -5362- DISPLAY 'FI0100S - FAV=' DISPLAY-CODFAV ' IDE=' V2FAVO-IDECBT ' WS-DTINIREF=' WS-DTINIREF ' WS-DTFIMREF=' WS-DTFIMREF ' B=' DISPLAY-VALOR ' IR=' DISPLAY-VALIRF */

                $"FI0100S - FAV={AREA_DE_WORK.DISPLAY_CODFAV} IDE={V2FAVO_IDECBT} WS-DTINIREF={WS_DTINIREF} WS-DTFIMREF={WS_DTFIMREF} B={AREA_DE_WORK.DISPLAY_VALOR} IR={AREA_DE_WORK.DISPLAY_VALIRF}"
                .Display();

                /*" -5362- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0940-00-SOMA-IMPOSTO-DB-SELECT-1 */
        public void R0940_00_SOMA_IMPOSTO_DB_SELECT_1()
        {
            /*" -5348- EXEC SQL SELECT VALUE(SUM(VLIMPOST), 0) INTO :V1IMPO-VLIMPOST FROM SEGUROS.V1IMPOSTOS WHERE IDECBT = :V2FAVO-IDECBT AND CODPDT = :V1FAVO-CODFAV AND (DATIPT BETWEEN :WS-DTINIREF AND :WS-DTFIMREF) AND TIPIPT = '1' AND SITUACAO IN ( '0' , '1' ) AND COD_EMPRESA = :WHOST-CODEMP END-EXEC. */

            var r0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1 = new R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1()
            {
                V2FAVO_IDECBT = V2FAVO_IDECBT.ToString(),
                V1FAVO_CODFAV = V1FAVO_CODFAV.ToString(),
                WHOST_CODEMP = WHOST_CODEMP.ToString(),
                WS_DTINIREF = WS_DTINIREF.ToString(),
                WS_DTFIMREF = WS_DTFIMREF.ToString(),
            };

            var executed_1 = R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1.Execute(r0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1IMPO_VLIMPOST, V1IMPO_VLIMPOST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0940_99_EXIT*/

        [StopWatch]
        /*" R0945-00-CALC-DEDUCAO-DEP-SECTION */
        private void R0945_00_CALC_DEDUCAO_DEP_SECTION()
        {
            /*" -5376- MOVE '0945' TO WNR-EXEC-SQL. */
            _.Move("0945", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5378- MOVE ZEROS TO V3IRF-VALDEP */
            _.Move(0, V3IRF_VALDEP);

            /*" -5388- PERFORM R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1 */

            R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1();

            /*" -5391- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5393- MOVE 'FI0100S,R0945 - ERRO NO SELECT V1IRFONTE' TO LK-MENSAGEM */
                _.Move("FI0100S,R0945 - ERRO NO SELECT V1IRFONTE", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5394- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5395- MOVE V2IRF-VALBRU TO DISPLAY-VALOR */
                _.Move(V2IRF_VALBRU, AREA_DE_WORK.DISPLAY_VALOR);

                /*" -5400- DISPLAY 'FI0100S - DATA SIS=' V1SIST-DTMOVABE ' BRU=' DISPLAY-VALOR ' FAVORECIDO=' V1FAVO-CODFAV ' TP. PES.=' V1FAVO-TPPESSOA ' CODVIN=' V2FAVO-CODVIN */

                $"FI0100S - DATA SIS={V1SIST_DTMOVABE} BRU={AREA_DE_WORK.DISPLAY_VALOR} FAVORECIDO={V1FAVO_CODFAV} TP. PES.={V1FAVO_TPPESSOA} CODVIN={V2FAVO_CODVIN}"
                .Display();

                /*" -5402- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5403- COMPUTE LK-VALDDUDEP = V1FAVO-NUMDEPIRF * V3IRF-VALDEP. */
            LK_IMPOSTOS.LK_VALDDUDEP.Value = V1FAVO_NUMDEPIRF * V3IRF_VALDEP;

        }

        [StopWatch]
        /*" R0945-00-CALC-DEDUCAO-DEP-DB-SELECT-1 */
        public void R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1()
        {
            /*" -5388- EXEC SQL SELECT VALDEP INTO :V3IRF-VALDEP FROM SEGUROS.V1IRFONTE WHERE (:V1SIST-DTMOVABE BETWEEN DTINIVIG AND DTTERVIG) AND (:V2IRF-VALBRU BETWEEN LIMINF AND LIMSUP) AND TPPESSOA = :V1FAVO-TPPESSOA AND CODVIN = :V2FAVO-CODVIN END-EXEC */

            var r0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1 = new R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1FAVO_TPPESSOA = V1FAVO_TPPESSOA.ToString(),
                V2FAVO_CODVIN = V2FAVO_CODVIN.ToString(),
                V2IRF_VALBRU = V2IRF_VALBRU.ToString(),
            };

            var executed_1 = R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1.Execute(r0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3IRF_VALDEP, V3IRF_VALDEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0945_99_EXIT*/

        [StopWatch]
        /*" R0946-00-APLICA-DEDUCOES-SECTION */
        private void R0946_00_APLICA_DEDUCOES_SECTION()
        {
            /*" -5435- MOVE '0946' TO WNR-EXEC-SQL. */
            _.Move("0946", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5446- PERFORM R0946_00_APLICA_DEDUCOES_DB_SELECT_1 */

            R0946_00_APLICA_DEDUCOES_DB_SELECT_1();

            /*" -5449- MOVE V3IRF-VALDEP TO DISPLAY-VALDEP */
            _.Move(V3IRF_VALDEP, AREA_DE_WORK.DISPLAY_VALDEP);

            /*" -5451- MOVE V4IRF-LIMSUP TO DISPLAY-LIMSUP */
            _.Move(V4IRF_LIMSUP, AREA_DE_WORK.DISPLAY_LIMSUP);

            /*" -5452- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5454- MOVE 'FI0100S,R0946 - ERRO NO SELECT V1IRFONTE' TO LK-MENSAGEM */
                _.Move("FI0100S,R0946 - ERRO NO SELECT V1IRFONTE", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5455- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5465- DISPLAY 'FI0100S,R0946' ' FAV=' LK-TIPFAV '-' V1FAVO-TIPREG '-' DISPLAY-CODFAV '-' V1FAVO-TPPESSOA ' B=' DISPLAY-VALOR ' VALDEP=' DISPLAY-VALDEP ' LIMSUP=' DISPLAY-LIMSUP ' DT SIS=' V1SIST-DTMOVABE ' CODVIN=' V2FAVO-CODVIN */

                $"FI0100S,R0946 FAV={LK_IMPOSTOS.LK_TIPFAV}-{V1FAVO_TIPREG}-{AREA_DE_WORK.DISPLAY_CODFAV}-{V1FAVO_TPPESSOA} B={AREA_DE_WORK.DISPLAY_VALOR} VALDEP={AREA_DE_WORK.DISPLAY_VALDEP} LIMSUP={AREA_DE_WORK.DISPLAY_LIMSUP} DT SIS={V1SIST_DTMOVABE} CODVIN={V2FAVO_CODVIN}"
                .Display();

                /*" -5471- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5472- IF (WS-TEM-DESC-100 EQUAL 'S' ) */

            if ((AREA_DE_WORK.WS_TEM_DESC_100 == "S"))
            {

                /*" -5473- MOVE 100,00 TO WS-VLR-ISENTO-IR */
                _.Move(100.00, AREA_DE_WORK.WS_VLR_ISENTO_IR);

                /*" -5474- IF (V2IRF-VALBRU > V4IRF-LIMSUP) */

                if ((V2IRF_VALBRU > V4IRF_LIMSUP))
                {

                    /*" -5476- COMPUTE V2IRF-VALBRU = V2IRF-VALBRU - 100,00 */
                    V2IRF_VALBRU.Value = V2IRF_VALBRU - 100.00;

                    /*" -5477- MOVE V2IRF-VALBRU TO DISPLAY-VLBASE */
                    _.Move(V2IRF_VALBRU, AREA_DE_WORK.DISPLAY_VLBASE);

                    /*" -5490- DISPLAY 'FI0100S,R0946,F=' V1FAVO-CODFAV '-' V1FAVO-TIPREG '-' V1FAVO-TPPESSOA '-' V1FAVO-CODSVI 'ANO=' WS-ANO ' B=' DISPLAY-VALOR ' - 100 =' DISPLAY-VLBASE. */

                    $"FI0100S,R0946,F={V1FAVO_CODFAV}-{V1FAVO_TIPREG}-{V1FAVO_TPPESSOA}-{V1FAVO_CODSVI}ANO={AREA_DE_WORK.WS_MESANO.WS_ANO} B={AREA_DE_WORK.DISPLAY_VALOR} - 100 ={AREA_DE_WORK.DISPLAY_VLBASE}"
                    .Display();
                }

            }


            /*" -5491- IF V2IRF-VALBRU <= V4IRF-LIMSUP */

            if (V2IRF_VALBRU <= V4IRF_LIMSUP)
            {

                /*" -5492- MOVE ZEROS TO LK-VALDDUDEP */
                _.Move(0, LK_IMPOSTOS.LK_VALDDUDEP);

                /*" -5493- MOVE ZEROS TO V4IRF-LIMSUP */
                _.Move(0, V4IRF_LIMSUP);

                /*" -5498- GO TO R0946-99-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0946_99_EXIT*/ //GOTO
                return;
            }


            /*" -5499- IF V1FAVO-NUMDEPIRF > ZEROS */

            if (V1FAVO_NUMDEPIRF > 00)
            {

                /*" -5501- COMPUTE LK-VALDDUDEP = V1FAVO-NUMDEPIRF * V3IRF-VALDEP */
                LK_IMPOSTOS.LK_VALDDUDEP.Value = V1FAVO_NUMDEPIRF * V3IRF_VALDEP;

                /*" -5502- MOVE LK-VALDDUDEP TO DISPLAY-VALDDUDEP */
                _.Move(LK_IMPOSTOS.LK_VALDDUDEP, AREA_DE_WORK.DISPLAY_VALDDUDEP);

                /*" -5503- IF V2IRF-VALBRU < LK-VALDDUDEP */

                if (V2IRF_VALBRU < LK_IMPOSTOS.LK_VALDDUDEP)
                {

                    /*" -5504- MOVE ZEROS TO LK-VALDDUDEP */
                    _.Move(0, LK_IMPOSTOS.LK_VALDDUDEP);

                    /*" -5505- ELSE */
                }
                else
                {


                    /*" -5507- COMPUTE V2IRF-VALBRU = V2IRF-VALBRU - LK-VALDDUDEP */
                    V2IRF_VALBRU.Value = V2IRF_VALBRU - LK_IMPOSTOS.LK_VALDDUDEP;

                    /*" -5508- MOVE V2IRF-VALBRU TO DISPLAY-VLBASE */
                    _.Move(V2IRF_VALBRU, AREA_DE_WORK.DISPLAY_VLBASE);

                    /*" -5521- DISPLAY 'FI0100S,R0946' ' FAV=' LK-TIPFAV '-' V1FAVO-TIPREG '-' DISPLAY-CODFAV '-' V1FAVO-TPPESSOA ' B=' DISPLAY-VALOR '(-)DEP' DISPLAY-VALDDUDEP '=' DISPLAY-VLBASE. */

                    $"FI0100S,R0946 FAV={LK_IMPOSTOS.LK_TIPFAV}-{V1FAVO_TIPREG}-{AREA_DE_WORK.DISPLAY_CODFAV}-{V1FAVO_TPPESSOA} B={AREA_DE_WORK.DISPLAY_VALOR}(-)DEP{AREA_DE_WORK.DISPLAY_VALDDUDEP}={AREA_DE_WORK.DISPLAY_VLBASE}"
                    .Display();
                }

            }


            /*" -5523- IF (WS-EH-MAIOR-65ANOS EQUAL 'N' ) OR (V1FAVO-TIPREG NOT = 'B' ) */

            if ((AREA_DE_WORK.WS_EH_MAIOR_65ANOS == "N") || (V1FAVO_TIPREG != "B"))
            {

                /*" -5524- MOVE ZEROS TO V4IRF-LIMSUP */
                _.Move(0, V4IRF_LIMSUP);

                /*" -5525- MOVE ZEROS TO DISPLAY-LIMSUP */
                _.Move(0, AREA_DE_WORK.DISPLAY_LIMSUP);

                /*" -5530- GO TO R0946-99-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0946_99_EXIT*/ //GOTO
                return;
            }


            /*" -5531- IF WS-EH-MAIOR-65ANOS EQUAL 'S' */

            if (AREA_DE_WORK.WS_EH_MAIOR_65ANOS == "S")
            {

                /*" -5532- IF V2IRF-VALBRU < V4IRF-LIMSUP */

                if (V2IRF_VALBRU < V4IRF_LIMSUP)
                {

                    /*" -5533- MOVE ZEROS TO V4IRF-LIMSUP */
                    _.Move(0, V4IRF_LIMSUP);

                    /*" -5534- ELSE */
                }
                else
                {


                    /*" -5536- COMPUTE V2IRF-VALBRU = V2IRF-VALBRU - V4IRF-LIMSUP */
                    V2IRF_VALBRU.Value = V2IRF_VALBRU - V4IRF_LIMSUP;

                    /*" -5537- MOVE V2IRF-VALBRU TO DISPLAY-VLBASE */
                    _.Move(V2IRF_VALBRU, AREA_DE_WORK.DISPLAY_VLBASE);

                    /*" -5544- DISPLAY 'FI0100S,R0946' ' FAV=' LK-TIPFAV '-' V1FAVO-TIPREG '-' DISPLAY-CODFAV '-' V1FAVO-TPPESSOA ' B=' DISPLAY-VALOR '(-)65A' DISPLAY-LIMSUP '=' DISPLAY-VLBASE. */

                    $"FI0100S,R0946 FAV={LK_IMPOSTOS.LK_TIPFAV}-{V1FAVO_TIPREG}-{AREA_DE_WORK.DISPLAY_CODFAV}-{V1FAVO_TPPESSOA} B={AREA_DE_WORK.DISPLAY_VALOR}(-)65A{AREA_DE_WORK.DISPLAY_LIMSUP}={AREA_DE_WORK.DISPLAY_VLBASE}"
                    .Display();
                }

            }


        }

        [StopWatch]
        /*" R0946-00-APLICA-DEDUCOES-DB-SELECT-1 */
        public void R0946_00_APLICA_DEDUCOES_DB_SELECT_1()
        {
            /*" -5446- EXEC SQL SELECT VALDEP, LIMSUP INTO :V3IRF-VALDEP, :V4IRF-LIMSUP FROM SEGUROS.V1IRFONTE WHERE (:V1SIST-DTMOVABE BETWEEN DTINIVIG AND DTTERVIG) AND LIMINF = 0.00 AND TPPESSOA = :V1FAVO-TPPESSOA AND CODVIN = :V2FAVO-CODVIN END-EXEC */

            var r0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1 = new R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1FAVO_TPPESSOA = V1FAVO_TPPESSOA.ToString(),
                V2FAVO_CODVIN = V2FAVO_CODVIN.ToString(),
            };

            var executed_1 = R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1.Execute(r0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3IRF_VALDEP, V3IRF_VALDEP);
                _.Move(executed_1.V4IRF_LIMSUP, V4IRF_LIMSUP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0946_99_EXIT*/

        [StopWatch]
        /*" R0950-00-ACESSA-V1IRFONTE-SECTION */
        private void R0950_00_ACESSA_V1IRFONTE_SECTION()
        {
            /*" -5557- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5563- MOVE ZEROS TO V1IRF-ALQIPT V1IRF-VALDDU */
            _.Move(0, V1IRF_ALQIPT, V1IRF_VALDDU);

            /*" -5575- PERFORM R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1 */

            R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1();

            /*" -5578- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5580- MOVE 'FI0100S,R0950 - ERRO NO SELECT V1IRFONTE' TO LK-MENSAGEM */
                _.Move("FI0100S,R0950 - ERRO NO SELECT V1IRFONTE", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5581- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5582- MOVE V2IRF-VALBRU TO DISPLAY-VALOR */
                _.Move(V2IRF_VALBRU, AREA_DE_WORK.DISPLAY_VALOR);

                /*" -5587- DISPLAY 'FI0100S - DATA SIS=' V1SIST-DTMOVABE ' BRU=' DISPLAY-VALOR ' FAVORECIDO=' V1FAVO-CODFAV ' TP. PES.=' V1FAVO-TPPESSOA ' CODVIN=' V2FAVO-CODVIN */

                $"FI0100S - DATA SIS={V1SIST_DTMOVABE} BRU={AREA_DE_WORK.DISPLAY_VALOR} FAVORECIDO={V1FAVO_CODFAV} TP. PES.={V1FAVO_TPPESSOA} CODVIN={V2FAVO_CODVIN}"
                .Display();

                /*" -5589- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5591- IF V1IRF-ALQIPT EQUAL ZEROS AND V1IRF-VALDDU EQUAL ZEROS */

            if (V1IRF_ALQIPT == 00 && V1IRF_VALDDU == 00)
            {

                /*" -5592- MOVE 'S' TO WS-EH-ISENTO-IR */
                _.Move("S", AREA_DE_WORK.WS_EH_ISENTO_IR);

                /*" -5593- ELSE */
            }
            else
            {


                /*" -5595- MOVE 'N' TO WS-EH-ISENTO-IR. */
                _.Move("N", AREA_DE_WORK.WS_EH_ISENTO_IR);
            }


            /*" -5597- MOVE V1IRF-ALQIPT TO V1FAVO-PCTIRF. */
            _.Move(V1IRF_ALQIPT, V1FAVO_PCTIRF);

            /*" -5598- IF WS-EH-ISENTO-IR = 'N' */

            if (AREA_DE_WORK.WS_EH_ISENTO_IR == "N")
            {

                /*" -5602- DISPLAY 'FI0100S,R0950 - DATA SIS=' V1SIST-DTMOVABE ' FAVORECIDO=' V1FAVO-CODFAV ' TP. PES.=' V1FAVO-TPPESSOA ' CODVIN=' V2FAVO-CODVIN */

                $"FI0100S,R0950 - DATA SIS={V1SIST_DTMOVABE} FAVORECIDO={V1FAVO_CODFAV} TP. PES.={V1FAVO_TPPESSOA} CODVIN={V2FAVO_CODVIN}"
                .Display();

                /*" -5603- MOVE V2IRF-VALBRU TO DISPLAY-VALOR */
                _.Move(V2IRF_VALBRU, AREA_DE_WORK.DISPLAY_VALOR);

                /*" -5604- MOVE V1IRF-ALQIPT TO DISPLAY-PCTIRF */
                _.Move(V1IRF_ALQIPT, AREA_DE_WORK.DISPLAY_PCTIRF);

                /*" -5605- MOVE V1IRF-VALDDU TO DISPLAY-VLRDED */
                _.Move(V1IRF_VALDDU, AREA_DE_WORK.DISPLAY_VLRDED);

                /*" -5608- DISPLAY '                REND. MES=' DISPLAY-VALOR ' ALIQ=' DISPLAY-PCTIRF ' DEDUC.=' DISPLAY-VLRDED */

                $"                REND. MES={AREA_DE_WORK.DISPLAY_VALOR} ALIQ={AREA_DE_WORK.DISPLAY_PCTIRF} DEDUC.={AREA_DE_WORK.DISPLAY_VLRDED}"
                .Display();

                /*" -5610- MOVE ZEROS TO DISPLAY-VALOR DISPLAY-PCTIRF DISPLAY-VLRDED. */
                _.Move(0, AREA_DE_WORK.DISPLAY_VALOR, AREA_DE_WORK.DISPLAY_PCTIRF, AREA_DE_WORK.DISPLAY_VLRDED);
            }


        }

        [StopWatch]
        /*" R0950-00-ACESSA-V1IRFONTE-DB-SELECT-1 */
        public void R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1()
        {
            /*" -5575- EXEC SQL SELECT ALQIPT, VALDDU INTO :V1IRF-ALQIPT, :V1IRF-VALDDU FROM SEGUROS.V1IRFONTE WHERE (:V1SIST-DTMOVABE BETWEEN DTINIVIG AND DTTERVIG) AND (:V2IRF-VALBRU BETWEEN LIMINF AND LIMSUP) AND TPPESSOA = :V1FAVO-TPPESSOA AND CODVIN = :V2FAVO-CODVIN END-EXEC */

            var r0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1 = new R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1FAVO_TPPESSOA = V1FAVO_TPPESSOA.ToString(),
                V2FAVO_CODVIN = V2FAVO_CODVIN.ToString(),
                V2IRF_VALBRU = V2IRF_VALBRU.ToString(),
            };

            var executed_1 = R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1.Execute(r0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1IRF_ALQIPT, V1IRF_ALQIPT);
                _.Move(executed_1.V1IRF_VALDDU, V1IRF_VALDDU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_EXIT*/

        [StopWatch]
        /*" R0960-00-ACESSA-IRJ-SECTION */
        private void R0960_00_ACESSA_IRJ_SECTION()
        {
            /*" -5627- MOVE '0960' TO WNR-EXEC-SQL. */
            _.Move("0960", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5629- MOVE ZEROS TO V1IRF-ALQIPT */
            _.Move(0, V1IRF_ALQIPT);

            /*" -5637- PERFORM R0960_00_ACESSA_IRJ_DB_SELECT_1 */

            R0960_00_ACESSA_IRJ_DB_SELECT_1();

            /*" -5640- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5642- MOVE 'FI0100S,R0960 - ERRO NO SELECT V1IRFONTE' TO LK-MENSAGEM */
                _.Move("FI0100S,R0960 - ERRO NO SELECT V1IRFONTE", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5643- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5647- DISPLAY 'FI0100S - DATA SIS=' V1SIST-DTMOVABE ' FAVORECIDO=' V1FAVO-CODFAV ' TP. PES.=' V1FAVO-TPPESSOA ' CODVIN=' V2FAVO-CODVIN */

                $"FI0100S - DATA SIS={V1SIST_DTMOVABE} FAVORECIDO={V1FAVO_CODFAV} TP. PES.={V1FAVO_TPPESSOA} CODVIN={V2FAVO_CODVIN}"
                .Display();

                /*" -5647- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0960-00-ACESSA-IRJ-DB-SELECT-1 */
        public void R0960_00_ACESSA_IRJ_DB_SELECT_1()
        {
            /*" -5637- EXEC SQL SELECT ALQIPT INTO :V1IRF-ALQIPT FROM SEGUROS.V1IRFONTE WHERE (:V1SIST-DTMOVABE BETWEEN DTINIVIG AND DTTERVIG) AND TPPESSOA = :V1FAVO-TPPESSOA AND CODVIN = :V2FAVO-CODVIN END-EXEC */

            var r0960_00_ACESSA_IRJ_DB_SELECT_1_Query1 = new R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1FAVO_TPPESSOA = V1FAVO_TPPESSOA.ToString(),
                V2FAVO_CODVIN = V2FAVO_CODVIN.ToString(),
            };

            var executed_1 = R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1.Execute(r0960_00_ACESSA_IRJ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1IRF_ALQIPT, V1IRF_ALQIPT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0960_99_SAIDA*/

        [StopWatch]
        /*" R0978-00-LE-AGRUPA-CH1-SECTION */
        private void R0978_00_LE_AGRUPA_CH1_SECTION()
        {
            /*" -5660- MOVE '0978' TO WNR-EXEC-SQL. */
            _.Move("0978", FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -5667- PERFORM R0978_00_LE_AGRUPA_CH1_DB_SELECT_1 */

            R0978_00_LE_AGRUPA_CH1_DB_SELECT_1();

            /*" -5670- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5672- MOVE 'FI0100S,R0978 - ERRO NO SELECT AGRUPA_TABELAS_CH1' TO LK-MENSAGEM */
                _.Move("FI0100S,R0978 - ERRO NO SELECT AGRUPA_TABELAS_CH1", LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5673- DISPLAY LK-MENSAGEM */
                _.Display(LK_IMPOSTOS.LK_MENSAGEM);

                /*" -5675- DISPLAY 'FI0100S - ID  CH1: ' AGTABCH1-IDTAB ' COD CH1: ' AGTABCH1-CODIGO-CH1 */

                $"FI0100S - ID  CH1: {AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_IDTAB} COD CH1: {AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_CODIGO_CH1}"
                .Display();

                /*" -5675- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0978-00-LE-AGRUPA-CH1-DB-SELECT-1 */
        public void R0978_00_LE_AGRUPA_CH1_DB_SELECT_1()
        {
            /*" -5667- EXEC SQL SELECT DESCRICAO INTO :AGTABCH1-DESCRICAO FROM SEGUROS.AGRUPA_TABELAS_CH1 WHERE IDTAB = :AGTABCH1-IDTAB AND CODIGO_CH1 = :AGTABCH1-CODIGO-CH1 AND SITUACAO = '0' END-EXEC. */

            var r0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1 = new R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1()
            {
                AGTABCH1_CODIGO_CH1 = AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_CODIGO_CH1.ToString(),
                AGTABCH1_IDTAB = AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_IDTAB.ToString(),
            };

            var executed_1 = R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1.Execute(r0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGTABCH1_DESCRICAO, AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_DESCRICAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0978_999_EXIT*/

        [StopWatch]
        /*" R8888-00-DISPLAY-PARM-CALC-SECTION */
        private void R8888_00_DISPLAY_PARM_CALC_SECTION()
        {
            /*" -5687- IF LK-TIPREG = '5' */

            if (LK_IMPOSTOS.LK_TIPREG == "5")
            {

                /*" -5689- GO TO R8888-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8888_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5691- IF LK-TIPREG = '7' AND LK-VALIRF < 10,00 */

            if (LK_IMPOSTOS.LK_TIPREG == "7" && LK_IMPOSTOS.LK_VALIRF < 10.00)
            {

                /*" -5693- GO TO R8888-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8888_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5694- MOVE LK-CODFAV TO DISPLAY-CODFAV */
            _.Move(LK_IMPOSTOS.LK_CODFAV, AREA_DE_WORK.DISPLAY_CODFAV);

            /*" -5695- MOVE LK-FONTE TO DISPLAY-FONTE */
            _.Move(LK_IMPOSTOS.LK_FONTE, AREA_DE_WORK.DISPLAY_FONTE);

            /*" -5697- MOVE LK-EMPRESA TO DISPLAY-EMPRESA */
            _.Move(LK_IMPOSTOS.LK_EMPRESA, AREA_DE_WORK.DISPLAY_EMPRESA);

            /*" -5712- DISPLAY 'FI0100S,R8888 ' 'FAV=' LK-TIPFAV '-' LK-TIPREG '-' DISPLAY-CODFAV '-' LK-TPPESSOA ' FT=' DISPLAY-FONTE ' RE=' LK-NUMREC ' EMP=' DISPLAY-EMPRESA ' ' 'V28-05-2017' . */

            $"FI0100S,R8888 FAV={LK_IMPOSTOS.LK_TIPFAV}-{LK_IMPOSTOS.LK_TIPREG}-{AREA_DE_WORK.DISPLAY_CODFAV}-{LK_IMPOSTOS.LK_TPPESSOA} FT={AREA_DE_WORK.DISPLAY_FONTE} RE={LK_IMPOSTOS.LK_NUMREC} EMP={AREA_DE_WORK.DISPLAY_EMPRESA} V28-05-2017"
            .Display();

            /*" -5714- IF LK-VALIRF NOT = ZEROS AND WS-EH-ISENTO-IR = 'N' */

            if (LK_IMPOSTOS.LK_VALIRF != 00 && AREA_DE_WORK.WS_EH_ISENTO_IR == "N")
            {

                /*" -5715- MOVE LK-VALBRU TO DISPLAY-VALOR */
                _.Move(LK_IMPOSTOS.LK_VALBRU, AREA_DE_WORK.DISPLAY_VALOR);

                /*" -5716- MOVE LK-PCTIRF TO DISPLAY-PCTIRF */
                _.Move(LK_IMPOSTOS.LK_PCTIRF, AREA_DE_WORK.DISPLAY_PCTIRF);

                /*" -5717- MOVE LK-VALIRF TO DISPLAY-VALIRF */
                _.Move(LK_IMPOSTOS.LK_VALIRF, AREA_DE_WORK.DISPLAY_VALIRF);

                /*" -5718- MOVE V2IRF-VALBRU TO DISPLAY-VLBASE */
                _.Move(V2IRF_VALBRU, AREA_DE_WORK.DISPLAY_VLBASE);

                /*" -5720- COMPUTE WS-CALC-VALLIQ = LK-VALBRU - LK-VALIRF */
                AREA_DE_WORK.WS_CALC_VALLIQ.Value = LK_IMPOSTOS.LK_VALBRU - LK_IMPOSTOS.LK_VALIRF;

                /*" -5721- MOVE WS-CALC-VALLIQ TO DISPLAY-VALLIQ */
                _.Move(AREA_DE_WORK.WS_CALC_VALLIQ, AREA_DE_WORK.DISPLAY_VALLIQ);

                /*" -5740- DISPLAY '        ' 'B=' DISPLAY-VALOR 'BASE=' DISPLAY-VLBASE ' IRF=' LK-DCOIRF ' ' DISPLAY-PCTIRF '% ' DISPLAY-VALIRF ' L=' DISPLAY-VALLIQ. */

                $"        B={AREA_DE_WORK.DISPLAY_VALOR}BASE={AREA_DE_WORK.DISPLAY_VLBASE} IRF={LK_IMPOSTOS.LK_DCOIRF} {AREA_DE_WORK.DISPLAY_PCTIRF}% {AREA_DE_WORK.DISPLAY_VALIRF} L={AREA_DE_WORK.DISPLAY_VALLIQ}"
                .Display();
            }


            /*" -5741- IF LK-VALISS NOT = ZEROS */

            if (LK_IMPOSTOS.LK_VALISS != 00)
            {

                /*" -5742- MOVE LK-VALBRU TO DISPLAY-VALOR */
                _.Move(LK_IMPOSTOS.LK_VALBRU, AREA_DE_WORK.DISPLAY_VALOR);

                /*" -5743- MOVE LK-VALBRU TO DISPLAY-VLBASE */
                _.Move(LK_IMPOSTOS.LK_VALBRU, AREA_DE_WORK.DISPLAY_VLBASE);

                /*" -5744- MOVE LK-PCDESISS TO DISPLAY-PCDESISS */
                _.Move(LK_IMPOSTOS.LK_PCDESISS, AREA_DE_WORK.DISPLAY_PCDESISS);

                /*" -5745- MOVE LK-VALISS TO DISPLAY-VALISS */
                _.Move(LK_IMPOSTOS.LK_VALISS, AREA_DE_WORK.DISPLAY_VALISS);

                /*" -5747- COMPUTE WS-CALC-VALLIQ = LK-VALBRU - LK-VALISS */
                AREA_DE_WORK.WS_CALC_VALLIQ.Value = LK_IMPOSTOS.LK_VALBRU - LK_IMPOSTOS.LK_VALISS;

                /*" -5748- MOVE WS-CALC-VALLIQ TO DISPLAY-VALLIQ */
                _.Move(AREA_DE_WORK.WS_CALC_VALLIQ, AREA_DE_WORK.DISPLAY_VALLIQ);

                /*" -5761- DISPLAY '        ' 'B=' DISPLAY-VALOR 'BASE=' DISPLAY-VLBASE ' ISS=' LK-DCOISS ' ' DISPLAY-PCDESISS '% ' DISPLAY-VALISS ' L=' DISPLAY-VALLIQ 'ISENTO ISS=' WS-EH-ISENTO-ISS. */

                $"        B={AREA_DE_WORK.DISPLAY_VALOR}BASE={AREA_DE_WORK.DISPLAY_VLBASE} ISS={LK_IMPOSTOS.LK_DCOISS} {AREA_DE_WORK.DISPLAY_PCDESISS}% {AREA_DE_WORK.DISPLAY_VALISS} L={AREA_DE_WORK.DISPLAY_VALLIQ}ISENTO ISS={AREA_DE_WORK.WS_EH_ISENTO_ISS}"
                .Display();
            }


            /*" -5762- IF LK-VALINSS NOT = ZEROS */

            if (LK_IMPOSTOS.LK_VALINSS != 00)
            {

                /*" -5763- MOVE LK-VALBRU TO DISPLAY-VALOR */
                _.Move(LK_IMPOSTOS.LK_VALBRU, AREA_DE_WORK.DISPLAY_VALOR);

                /*" -5764- MOVE WS-VLBASINSS TO DISPLAY-VLBASE */
                _.Move(AREA_DE_WORK.WS_VLBASINSS, AREA_DE_WORK.DISPLAY_VLBASE);

                /*" -5765- MOVE LK-PCTINSS TO DISPLAY-PCTINSS */
                _.Move(LK_IMPOSTOS.LK_PCTINSS, AREA_DE_WORK.DISPLAY_PCTINSS);

                /*" -5766- MOVE LK-VALINSS TO DISPLAY-VALINSS */
                _.Move(LK_IMPOSTOS.LK_VALINSS, AREA_DE_WORK.DISPLAY_VALINSS);

                /*" -5768- COMPUTE WS-CALC-VALLIQ = WS-VLBASINSS - LK-VALINSS */
                AREA_DE_WORK.WS_CALC_VALLIQ.Value = AREA_DE_WORK.WS_VLBASINSS - LK_IMPOSTOS.LK_VALINSS;

                /*" -5769- MOVE WS-CALC-VALLIQ TO DISPLAY-VALLIQ */
                _.Move(AREA_DE_WORK.WS_CALC_VALLIQ, AREA_DE_WORK.DISPLAY_VALLIQ);

                /*" -5775- DISPLAY '        ' 'B=' DISPLAY-VALOR 'BASE=' DISPLAY-VLBASE 'INSS=' LK-DCOINSS ' ' DISPLAY-PCTINSS '% ' DISPLAY-VALINSS ' L=' DISPLAY-VALLIQ. */

                $"        B={AREA_DE_WORK.DISPLAY_VALOR}BASE={AREA_DE_WORK.DISPLAY_VLBASE}INSS={LK_IMPOSTOS.LK_DCOINSS} {AREA_DE_WORK.DISPLAY_PCTINSS}% {AREA_DE_WORK.DISPLAY_VALINSS} L={AREA_DE_WORK.DISPLAY_VALLIQ}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8888_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5789- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, FILLER_10.WABEND.WSQLCODE);

            /*" -5790- DISPLAY WABEND */
            _.Display(FILLER_10.WABEND);

            /*" -5791- MOVE WNR-EXEC-SQL TO LK-EXEC-SQL */
            _.Move(FILLER_10.WABEND.WNR_EXEC_SQL, LK_IMPOSTOS.LK_EXEC_SQL);

            /*" -5792- MOVE SQLCODE TO LK-RETCODE */
            _.Move(DB.SQLCODE, LK_IMPOSTOS.LK_RETCODE);

            /*" -5794- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -5795- IF LK-MENSAGEM NOT EQUAL SPACES */

            if (!LK_IMPOSTOS.LK_MENSAGEM.IsEmpty())
            {

                /*" -5799- DISPLAY 'FI0100S - RETORNO COM ERRO ' ' LK-EXEC-SQL ' LK-EXEC-SQL ' LK-RETCODE ' LK-RETCODE ' LK-MENSAGEM ' LK-MENSAGEM */

                $"FI0100S - RETORNO COM ERRO  LK-EXEC-SQL {LK_IMPOSTOS.LK_EXEC_SQL} LK-RETCODE {LK_IMPOSTOS.LK_RETCODE} LK-MENSAGEM {LK_IMPOSTOS.LK_MENSAGEM}"
                .Display();

                /*" -5816- PERFORM R8888-00-DISPLAY-PARM-CALC. */

                R8888_00_DISPLAY_PARM_CALC_SECTION();
            }


            /*" -5816- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}