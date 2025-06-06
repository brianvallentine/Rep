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
using Sias.VidaAzul.DB2.VA1471B;

namespace Code
{
    public class VA1471B
    {
        public bool IsCall { get; set; }

        public VA1471B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   FUNCAO .................  GERA REPASSE SAF PARA A ICATU.     *      */
        /*"      *                             CONVENIO EUROPE ASSISTANCE, EXCETO *      */
        /*"      *                             PARA O CAAES E FEDERAL CLUBE.      *      */
        /*"      *                                                                *      */
        /*"      *   PERIODICIDADE ..........  ENVIA OS ARQUIVOS DIARIAMENTE.     *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  M MESSIAS DE S                     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA1471B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  17/10/2001                         *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO DO PROGRAMA......  VF0471B                            *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                      A L T E R A C O E S                       *      */
        /*"      ******************************************************************      */
        /*"V.59  *   VERSAO 59 - DEMANDA 484074 / TAREFA 553176                   *      */
        /*"      *   OBJETIVO: ENVIAR SAF_F ASSISTENCIAS AOS NOVOS PRODUTOS ABAIXO*      */
        /*"      *    -> PROTECAO EXECUTIVA                                       *      */
        /*"      *    -> PROTECAO EMPREENDEDOR (MEI)                              *      */
        /*"      *                                                                *      */
        /*"      *1)SEGURO PROTECAO EXECUTIVA -> CONVENIO X ARQUIVO MENSAL:       *      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *|CONVENIO   |CO|ASSISTENCIA       |ARQUIVO CAIXA ASSSIT        |T      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *|40000142243|02|SAF FAMILIAR      |Maamm.VA1492B.REPSAF.ENV.TXT|0      */
        /*"      *|40000042589|24|EMPRESARIAL       |Maamm.VA1475B.MEMPRE.TXT    |0      */
        /*"      *|40000527273|83|LAR               |Maamm.VA1475B.LAR.TXT       |1      */
        /*"      *|40000527287|91|TELEMEDICINA      |Maamm.VA1475B.TELEMED.TXT   |0      */
        /*"      *|40000529003|94|ORIENT.FINANCEIRA |Maamm.VA1475B.FINANCE.TXT   |1      */
        /*"      *|40000529001|95|INVENTARIO        |Maamm.VA1475B.INVENTA.TXT   |1      */
        /*"      *|40000529005|96|VIAGEM LAV+HOS.PET|Maamm.VA1475B.VIAGELH.TXT   |1      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *                                                                *      */
        /*"      *2)SEGURO PROTECAO EMPREENDEDOR (MEI)-> CONVENIO X ARQUIVO MENSAL*      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *|CONVENIO   |CO|ASSISTENCIA       |ARQUIVO CAIXA ASSSIT        |T      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *|40000142243|02|SAF FAMILIAR      |Maamm.VA1492B.REPSAF.ENV.TXT|0      */
        /*"      *|40000527287|91|TELEMEDICINA      |Maamm.VA1475B.TELEMED.TXT   |0      */
        /*"      *|40000528999|93|AMBIENTAL         |Maamm.VA1475B.AMBIENT.TXT   |0      */
        /*"      *|40000529007|97|REPARO DE EQUIPAM.|Maamm.VA1475B.REPARO.TXT    |0      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *                                                                *      */
        /*"      *3)PRODUTO X COBERTURAS/ASSITENCIAS:                             *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Produto       |COD |Apolice      |Subg|Pgto. |Cober./Assist.| *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Vida Executivo|9750|3009300007513|1   |Mensal|02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |22 CDGCA      | *      */
        /*"      * |              |    |             |    |      |24 ASSIST EMP | *      */
        /*"      * |              |    |             |    |      |35 DIT        | *      */
        /*"      * |              |    |             |    |      |83 ASSIS LAR  | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Vida Executivo|9750|3009300007513|2   |Mensal|02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |22 CDGCA      | *      */
        /*"      * |              |    |             |    |      |24 ASSIST EMP | *      */
        /*"      * |              |    |             |    |      |35 DIT        | *      */
        /*"      * |              |    |             |    |      |83 ASSIS LAR  | *      */
        /*"      * |              |    |             |    |      |94 ASSIS ORFI | *      */
        /*"      * |              |    |             |    |      |95 ASSIS INVE | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Vida Executivo|9750|3009300007513|3   |Mensal|02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |22 CDGCA      | *      */
        /*"      * |              |    |             |    |      |24 ASSIST EMP | *      */
        /*"      * |              |    |             |    |      |35 DIT        | *      */
        /*"      * |              |    |             |    |      |83 ASSIS LAR  | *      */
        /*"      * |              |    |             |    |      |91 ASSIST TEL | *      */
        /*"      * |              |    |             |    |      |94 ASSIS ORFI | *      */
        /*"      * |              |    |             |    |      |95 ASSIS INVE | *      */
        /*"      * |              |    |             |    |      |96 ASSIS VIAG | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Vida Executivo|9751|3009300007513|4   |Anual |02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |22 CDGCA      | *      */
        /*"      * |              |    |             |    |      |24 ASSIST EMP | *      */
        /*"      * |              |    |             |    |      |35 DIT        | *      */
        /*"      * |              |    |             |    |      |83 ASSIS LAR  | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Vida Executivo|9751|3009300007513|5   |Anual |02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |22 CDGCA      | *      */
        /*"      * |              |    |             |    |      |24 ASSIST EMP | *      */
        /*"      * |              |    |             |    |      |35 DIT        | *      */
        /*"      * |              |    |             |    |      |83 ASSIS LAR  | *      */
        /*"      * |              |    |             |    |      |94 ASSIS ORFI | *      */
        /*"      * |              |    |             |    |      |95 ASSIS INVE | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Vida Executivo|9751|3009300007513|6   |Anual |02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |22 CDGCA      | *      */
        /*"      * |              |    |             |    |      |24 ASSIST EMP | *      */
        /*"      * |              |    |             |    |      |35 DIT        | *      */
        /*"      * |              |    |             |    |      |83 ASSIS LAR  | *      */
        /*"      * |              |    |             |    |      |91 ASSIST TEL | *      */
        /*"      * |              |    |             |    |      |94 ASSIS ORFI | *      */
        /*"      * |              |    |             |    |      |95 ASSIS INVE | *      */
        /*"      * |              |    |             |    |      |96 ASSIS VIAG | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Vida Executivo|9752|3009300007514|1   |Unico |02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |22 CDGCA      | *      */
        /*"      * |              |    |             |    |      |24 ASSIST EMP | *      */
        /*"      * |              |    |             |    |      |35 DIT        | *      */
        /*"      * |              |    |             |    |      |83 ASSIS LAR  | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Vida Executivo|9752|3009300007514|2   |Unico |02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |22 CDGCA      | *      */
        /*"      * |              |    |             |    |      |24 ASSIST EMP | *      */
        /*"      * |              |    |             |    |      |35 DIT        | *      */
        /*"      * |              |    |             |    |      |83 ASSIS LAR  | *      */
        /*"      * |              |    |             |    |      |94 ASSIS ORFI | *      */
        /*"      * |              |    |             |    |      |95 ASSIS INVE | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Vida Executivo|9752|3009300007514|3   |Unico |02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |22 CDGCA      | *      */
        /*"      * |              |    |             |    |      |24 ASSIST EMP | *      */
        /*"      * |              |    |             |    |      |35 DIT        | *      */
        /*"      * |              |    |             |    |      |83 ASSIS LAR  | *      */
        /*"      * |              |    |             |    |      |91 ASSIST TEL | *      */
        /*"      * |              |    |             |    |      |94 ASSIS ORFI | *      */
        /*"      * |              |    |             |    |      |95 ASSIS INVE | *      */
        /*"      * |              |    |             |    |      |96 ASSIS VIAG | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Prot. Empreend|8530|3008199999998|8530|Mensal|02 SAF_F      | *      */
        /*"      * |              |    |             |    |      |91 ASSIST TEL | *      */
        /*"      * |              |    |             |    |      |93 ASSIS AMBT | *      */
        /*"      * |              |    |             |    |      |97 ASSIST REP | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Prot. Empreend|8531|3008199999998|8531|Unico |02 SAF_F      | *      */
        /*"      * |              |    |             |    |12    |91 ASSIST TEL | *      */
        /*"      * |              |    |             |    |meses |93 ASSIS AMBT | *      */
        /*"      * |              |    |             |    |      |97 ASSIST REP | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Prot. Empreend|8532|3008199999998|8532|Unico |02 SAF_F      | *      */
        /*"      * |              |    |             |    |36    |91 ASSIST TEL | *      */
        /*"      * |              |    |             |    |meses |93 ASSIS AMBT | *      */
        /*"      * |              |    |             |    |      |97 ASSIST REP | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/12/2023 - ANSELMO SOUSA                                *      */
        /*"      *                                            PROCURE POR V.59    *      */
        /*"      ******************************************************************      */
        /*"V.58  *VERSAO V.58-DEMANDA 510565 - RAUL 20/11/2023-Inclus�o de novas  *      */
        /*"V.58  * ap�lices substituindo as antigas                               *      */
        /*"      *8205            8241              8241                                 */
        /*"      *3008208874329 , 3008218874329 --> 3008211398371                        */
        /*"      *                                                                       */
        /*"      *8209            8242              8242                                 */
        /*"      *3008210933403 , 3008220933403 --> 3008211398372                        */
        /*"      *                                                                       */
        /*"      *9329            9381              9381                                 */
        /*"      *3009300002679 , 3009300007397 --> 3009300007527                        */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *9343            9382              9382                                 */
        /*"      *3009300006210 , 3009300007147 --> 3009300007528                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"V.57  *   VERSAO 57 - DEMANDA 546164                                   *      */
        /*"      *                                                                *      */
        /*"      *   - SUBSTITUI��O DE DATAS DE EMISSAO, INICIO E FIM DE VIGENCIA *      */
        /*"      *     NO CURSOR CPROPVA PARA CORRE��O DOS ARQUIVOS DI�RIOS E     *      */
        /*"      *     MENSAIS DE ASSISTENCIA SAF (REPSAF).                       *      */
        /*"      *   - PARA BILHETES TROCADA A BUSCA DAS DATAS DO ENDOSSO 0 PARA  *      */
        /*"      *     AS DATAS DO ENDOSSO MAIS RECENTE                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/11/2023 - ANSELMO SOUSA                                *      */
        /*"      *                                      PROCURE POR V.57          *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 56 - DEMANDA 489860                                   *      */
        /*"      *                                                                *      */
        /*"      *   - RETIRAR DO ENVIO DO ARQUIVO APOLICES DO PRODUTO 9729 e 9386*      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2023 - RAUL BASILI ROTTA                            *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.56    *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 55 - DEMANDA 489860                                   *      */
        /*"      *                                                                *      */
        /*"      *   - RETIRAR DO ENVIO DO ARQUIVO APOLICES DO PRODUTO 9729       *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/07/2023 - RAUL BASILI ROTTA                            *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.55    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 54 - DEMANDA 507522                                   *      */
        /*"      *                                                                *      */
        /*"      *   - INCLUSAO DA APOLICE 3009300007397 QUE PASSOU A SUBSTITUIR  *      */
        /*"      *     A APOLICE 3009300007007 QUE ESTOUROU SUB-GRUPOS.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/06/2023 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.54    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 53 - DEMANDA 452235                                   *      */
        /*"      *                                                                *      */
        /*"      *   - INCLUSAO DA APOLICE 3009300007147 QUE PASSOU A SUBSTITUIR  *      */
        /*"      *     A APOLICE 3009300006210 QUE ESTOUROU SUB-GRUPOS.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/03/2023 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.53    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 52 - DEMANDA 419828                                   *      */
        /*"      *                                                                *      */
        /*"      *   - INCLUSAO DA APOLICE 3009300007007 QUE PASSOU A SUBSTITUIR  *      */
        /*"      *     A APOLICE 3009300006730 QUE ESTOUROU SUB-GRUPOS.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/08/2022 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.52    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.51  *   VERSAO 51 - DEMANDA 404620                                   *      */
        /*"      *             - ENVIAR ASSISTENCIA FUNERAL FAMILIA - SAF PARA    *      */
        /*"      *               BILHETES AP-BEM ESTAR 8521, 8528 E 8529          *      */
        /*"      *             - ALTERAR DATA DE CONSULTA DO CURSOR DE BILHETES   *      */
        /*"      *               PARA 5 ANOS, JAH QUE EXISTEM BILHETES COM ESSE   *      */
        /*"      *               PRAZO DE VIGENCIA                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/07/2022 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.51    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 50 - DEMANDA 352800                                   *      */
        /*"      *                                                                *      */
        /*"      *   - INCLUSAO DA APOLICE 3009300006730 QUE PASSOU A SUBSTITUIR  *      */
        /*"      *     A APOLICE 3009300012679 QUE ESTOUROU SUB-GRUPOS.           *      */
        /*"      *                                                                *      */
        /*"      *   OBS> COMENTARIOS ANTERIORES A V.42 FORAM REMOVIDOS.          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/01/2022 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.50    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 49 - DEMANDA 262053/245802                            *      */
        /*"      *                                                                *      */
        /*"      *   - ENVIAR SAF DO PRODUTO 3716 PARA A TEMPO.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/10/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.49    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.49  *VERSAO V.49-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"JV148 *----------------------------------------------------------------*      */
        /*"JV148 *VERSAO 48: JV1 DEMANDA 262179 - KINKAS 23/10/2020               *      */
        /*"JV148 *           EXCLUI APOLICES/PRODUTOS JV1 - FASE 2                *      */
        /*"JV148 *           - PROCURAR POR JV148                                 *      */
        /*"JV148 *----------------------------------------------------------------*      */
        /*"JV147 *VERSAO 47: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV147 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV147 *           - PROCURAR POR JV147                                 *      */
        /*"JV147 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 46 - ABEND 258431                                     *      */
        /*"      *                                                                *      */
        /*"      *   - INCLUSAO DA APOLICE 109300006210 EM SUBSTITUICAO DA        *      */
        /*"      *     109300005270 POIS HOUVE O ESTOURO DE SUBGRUPO.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/09/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.46    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 45 - 216.426 - CORRECAO DE ABEND                      *      */
        /*"      *                         (System Completion Code=0C7)           *      */
        /*"      *   EM 05/09/2019 - JOAO ARAUJO         PROCURE POR V.45         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 44 - 208.154 - EXCLUIR DO REPSAF OS CPFS PARA OS      *      */
        /*"      *               PRODUTOS 8205 9329 8209 9343 7405 8529 7409 8543 *      */
        /*"      *             - INCLUI MONITORACAO (PROCURE POR "F ALL MONIT 1"  *      */
        /*"      *   EM 27/08/2019 - KINKAS              PROCURE POR V.44         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 43 - JAZZ 199.509 - VINCULO ERRADO                    *      */
        /*"      *             - INCLUSAO DAS APOLICES 108211323063 E 108211323064*      */
        /*"      *                                                                *      */
        /*"      *   EM 01/08/2019 - CANETTA                                      *      */
        /*"      *                                       PROCURE POR V.43         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   DEMAIS HISTORICOS DE ALTERACOES - VIDE FINAL DO PROGRAMA     *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _REPSAF { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis REPSAF
        {
            get
            {
                _.Move(REPSAF_RECORD, _REPSAF); VarBasis.RedefinePassValue(REPSAF_RECORD, _REPSAF, REPSAF_RECORD); return _REPSAF;
            }
        }
        public FileBasis _RVA1471B { get; set; } = new FileBasis(new PIC("X", "90", "X(90)"));

        public FileBasis RVA1471B
        {
            get
            {
                _.Move(ASSIST_RECORD, _RVA1471B); VarBasis.RedefinePassValue(ASSIST_RECORD, _RVA1471B, ASSIST_RECORD); return _RVA1471B;
            }
        }
        /*"01   REPSAF-RECORD PIC X(350).*/
        public StringBasis REPSAF_RECORD { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");
        /*"01   ASSIST-RECORD PIC X(090).*/
        public StringBasis ASSIST_RECORD { get; set; } = new StringBasis(new PIC("X", "90", "X(090)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  PROPVA-DTQIT10A               PIC  X(10).*/
        public StringBasis PROPVA_DTQIT10A { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC-I               PIC S9(04) COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-ICODPRODEA             PIC S9(04) COMP.*/
        public IntBasis PRODVG_ICODPRODEA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SISTEMA-DTMVM06M              PIC  X(10).*/
        public StringBasis SISTEMA_DTMVM06M { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTCURREN             PIC  X(10).*/
        public StringBasis SISTEMAS_DTCURREN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTCURINI             PIC  X(10).*/
        public StringBasis SISTEMAS_DTCURINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTMOVABE-10D         PIC  X(10).*/
        public StringBasis SISTEMAS_DTMOVABE_10D { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTMOVABE-1M          PIC  X(10).*/
        public StringBasis SISTEMAS_DTMOVABE_1M { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTMOVABE-60M         PIC  X(10).*/
        public StringBasis SISTEMAS_DTMOVABE_60M { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CONARQEA-ANO-REF-ANT          PIC S9(04) COMP.*/
        public IntBasis CONARQEA_ANO_REF_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CONARQEA-ANO-REF-ATU          PIC S9(04) COMP.*/
        public IntBasis CONARQEA_ANO_REF_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  REPSAF-DTINIVIG               PIC  X(10).*/
        public StringBasis REPSAF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-DTH-INI                 PIC  X(010).*/
        public StringBasis WHOST_DTH_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-DTH-INI-BIL             PIC  X(010).*/
        public StringBasis WHOST_DTH_INI_BIL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-DTH-FIM                 PIC  X(010).*/
        public StringBasis WHOST_DTH_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-WORK-AREAS.*/
        public VA1471B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA1471B_WS_WORK_AREAS();
        public class VA1471B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-SAF-LOTERICO           PIC X(003) VALUE SPACES.*/
            public StringBasis WS_SAF_LOTERICO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    03  WS-ERRO-DATA              PIC X(003) VALUE SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    03  AUX-RESULTADO             PIC 9(009) COMP-3 VALUE ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03  AUX-RESTO                 PIC 9(009) COMP-3 VALUE ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03  WS-SMALLINT               PIC 9(004) VALUE ZEROS.*/
            public IntBasis WS_SMALLINT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03  WS-DECIMAL                PIC 9(013) VALUE ZEROS.*/
            public IntBasis WS_DECIMAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03  AC-CODPRODEA-NOK          PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_CODPRODEA_NOK { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-REJEITADOS             PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_REJEITADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  WS-EOF                    PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  LT-INCLUSAO               PIC X(10) VALUE 'INCLUSAO'.*/
            public StringBasis LT_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"INCLUSAO");
            /*"    03  LT-ALTERACAO              PIC X(10) VALUE 'ALTERACAO'.*/
            public StringBasis LT_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"ALTERACAO");
            /*"    03  LT-EXCLUSAO               PIC X(10) VALUE 'EXCLUSAO'.*/
            public StringBasis LT_EXCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"EXCLUSAO");
            /*"    03  WSQLCODE3                 PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03  W01DTSQL.*/
            public VA1471B_W01DTSQL W01DTSQL { get; set; } = new VA1471B_W01DTSQL();
            public class VA1471B_W01DTSQL : VarBasis
            {
                /*"       05  W01AASQL               PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01T1SQL               PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01MMSQL               PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01T2SQL               PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01DDSQL               PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WS-DATA-H.*/
            }
            public VA1471B_WS_DATA_H WS_DATA_H { get; set; } = new VA1471B_WS_DATA_H();
            public class VA1471B_WS_DATA_H : VarBasis
            {
                /*"       05  WS-DIA-H               PIC  9(002).*/
                public IntBasis WS_DIA_H { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                 PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       05  WS-MES-H               PIC  9(002).*/
                public IntBasis WS_MES_H { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                 PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       05  WS-ANO-H               PIC  9(004).*/
                public IntBasis WS_ANO_H { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03  W01DTCOR.*/
            }
            public VA1471B_W01DTCOR W01DTCOR { get; set; } = new VA1471B_W01DTCOR();
            public class VA1471B_W01DTCOR : VarBasis
            {
                /*"       05  W01DDCOR               PIC 9(002).*/
                public IntBasis W01DDCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01MMCOR               PIC 9(002).*/
                public IntBasis W01MMCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01AACOR               PIC 9(004).*/
                public IntBasis W01AACOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03  W01DTINV.*/
            }
            public VA1471B_W01DTINV W01DTINV { get; set; } = new VA1471B_W01DTINV();
            public class VA1471B_W01DTINV : VarBasis
            {
                /*"       05  W01AAINV               PIC 9(004).*/
                public IntBasis W01AAINV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01MMINV               PIC 9(002).*/
                public IntBasis W01MMINV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01DDINV               PIC 9(002).*/
                public IntBasis W01DDINV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WS-ANO-REF                PIC 9(004).*/
            }
            public IntBasis WS_ANO_REF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03  WS-ANO-REF-R              REDEFINES        WS-ANO-REF.*/
            private _REDEF_VA1471B_WS_ANO_REF_R _ws_ano_ref_r { get; set; }
            public _REDEF_VA1471B_WS_ANO_REF_R WS_ANO_REF_R
            {
                get { _ws_ano_ref_r = new _REDEF_VA1471B_WS_ANO_REF_R(); _.Move(WS_ANO_REF, _ws_ano_ref_r); VarBasis.RedefinePassValue(WS_ANO_REF, _ws_ano_ref_r, WS_ANO_REF); _ws_ano_ref_r.ValueChanged += () => { _.Move(_ws_ano_ref_r, WS_ANO_REF); }; return _ws_ano_ref_r; }
                set { VarBasis.RedefinePassValue(value, _ws_ano_ref_r, WS_ANO_REF); }
            }  //Redefines
            public class _REDEF_VA1471B_WS_ANO_REF_R : VarBasis
            {
                /*"       05  FILLER                 PIC X(002).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       05  WS-ANO-REF-2           PIC 9(002).*/
                public IntBasis WS_ANO_REF_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-DTH-CRITICA             PIC  9(008).*/

                public _REDEF_VA1471B_WS_ANO_REF_R()
                {
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_ANO_REF_2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03 WS-DTH-CRITICA-R           REDEFINES    WS-DTH-CRITICA.*/
            private _REDEF_VA1471B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VA1471B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VA1471B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VA1471B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"      05     WS-CRITICA-ANO       PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-CRITICA-MES       PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05     WS-CRITICA-DIA       PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  TABELA-ULT-DIAS.*/

                public _REDEF_VA1471B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VA1471B_TABELA_ULT_DIAS TABELA_ULT_DIAS { get; set; } = new VA1471B_TABELA_ULT_DIAS();
            public class VA1471B_TABELA_ULT_DIAS : VarBasis
            {
                /*"      05 TAB-DIAS.*/
                public VA1471B_TAB_DIAS TAB_DIAS { get; set; } = new VA1471B_TAB_DIAS();
                public class VA1471B_TAB_DIAS : VarBasis
                {
                    /*"         09  FILLER               PIC  X(024)   VALUE            '312831303130313130313031'.*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                    /*"      05 TAB-DIAS-R               REDEFINES     TAB-DIAS.*/
                }
                private _REDEF_VA1471B_TAB_DIAS_R _tab_dias_r { get; set; }
                public _REDEF_VA1471B_TAB_DIAS_R TAB_DIAS_R
                {
                    get { _tab_dias_r = new _REDEF_VA1471B_TAB_DIAS_R(); _.Move(TAB_DIAS, _tab_dias_r); VarBasis.RedefinePassValue(TAB_DIAS, _tab_dias_r, TAB_DIAS); _tab_dias_r.ValueChanged += () => { _.Move(_tab_dias_r, TAB_DIAS); }; return _tab_dias_r; }
                    set { VarBasis.RedefinePassValue(value, _tab_dias_r, TAB_DIAS); }
                }  //Redefines
                public class _REDEF_VA1471B_TAB_DIAS_R : VarBasis
                {
                    /*"         09  ULT-DIA              OCCURS  12    TIMES                                  PIC  X(002).*/
                    public ListBasis<StringBasis, string> ULT_DIA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "2", "X(002)."), 12);
                    /*"    03  TAB-CONVENIO.*/

                    public _REDEF_VA1471B_TAB_DIAS_R()
                    {
                        ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public VA1471B_TAB_CONVENIO TAB_CONVENIO { get; set; } = new VA1471B_TAB_CONVENIO();
            public class VA1471B_TAB_CONVENIO : VarBasis
            {
                /*"      05 FILLER PIC X(30) VALUE      '40000142242SAF INDIVIDUAL (S1)'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"40000142242SAF INDIVIDUAL (S1)");
                /*"      05 FILLER PIC X(30) VALUE      '40000142243SAF FAMILIA    (SS)'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"40000142243SAF FAMILIA    (SS)");
                /*"      05 FILLER PIC X(30) VALUE      '40000142324SAF EXTENDIDO  (S2)'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"40000142324SAF EXTENDIDO  (S2)");
                /*"    03  TAB-CONVENIO-R   REDEFINES   TAB-CONVENIO.*/
            }
            private _REDEF_VA1471B_TAB_CONVENIO_R _tab_convenio_r { get; set; }
            public _REDEF_VA1471B_TAB_CONVENIO_R TAB_CONVENIO_R
            {
                get { _tab_convenio_r = new _REDEF_VA1471B_TAB_CONVENIO_R(); _.Move(TAB_CONVENIO, _tab_convenio_r); VarBasis.RedefinePassValue(TAB_CONVENIO, _tab_convenio_r, TAB_CONVENIO); _tab_convenio_r.ValueChanged += () => { _.Move(_tab_convenio_r, TAB_CONVENIO); }; return _tab_convenio_r; }
                set { VarBasis.RedefinePassValue(value, _tab_convenio_r, TAB_CONVENIO); }
            }  //Redefines
            public class _REDEF_VA1471B_TAB_CONVENIO_R : VarBasis
            {
                /*"      05 FILLER  OCCURS 3 TIMES.*/
                public ListBasis<VA1471B_FILLER_7> FILLER_7 { get; set; } = new ListBasis<VA1471B_FILLER_7>(3);
                public class VA1471B_FILLER_7 : VarBasis
                {
                    /*"       10  TB-COD-CONVENIO   PIC 9(11).*/
                    public IntBasis TB_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                    /*"       10  TB-DES-CONVENIO   PIC X(19).*/
                    public StringBasis TB_DES_CONVENIO { get; set; } = new StringBasis(new PIC("X", "19", "X(19)."), @"");
                    /*"    03  WS-TIME                   PIC  X(008) VALUE  SPACES.*/

                    public VA1471B_FILLER_7()
                    {
                        TB_COD_CONVENIO.ValueChanged += OnValueChanged;
                        TB_DES_CONVENIO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA1471B_TAB_CONVENIO_R()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    03  WS-TIMESTAMP-INI          PIC  X(026) VALUE  SPACES.*/
            public StringBasis WS_TIMESTAMP_INI { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"    03  WS-TIMESTAMP-FIM          PIC  X(026) VALUE  SPACES.*/
            public StringBasis WS_TIMESTAMP_FIM { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"    03  WS-TIMESTAMP-TOT          PIC  X(026) VALUE  SPACES.*/
            public StringBasis WS_TIMESTAMP_TOT { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"    03  AC-LIDOS                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-CONTA                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-ACEITOS                PIC  9(006) VALUE  0.*/
            public IntBasis AC_ACEITOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-ACEITOS-BIL-AP         PIC  9(006) VALUE  0.*/
            public IntBasis AC_ACEITOS_BIL_AP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-ACEITOS-BIL-MEI-8530   PIC  9(006) VALUE  0.*/
            public IntBasis AC_ACEITOS_BIL_MEI_8530 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-ACEITOS-BIL-MEI-8531   PIC  9(006) VALUE  0.*/
            public IntBasis AC_ACEITOS_BIL_MEI_8531 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-ACEITOS-BIL-MEI-8532   PIC  9(006) VALUE  0.*/
            public IntBasis AC_ACEITOS_BIL_MEI_8532 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-PRODUTO-NOK            PIC  9(006) VALUE  0.*/
            public IntBasis AC_PRODUTO_NOK { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-REGISTROS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-INCLUIDOS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_INCLUIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-ALTERADOS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_ALTERADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-EXCLUIDOS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_EXCLUIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-ASSIST                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_ASSIST { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-INS-SS                 PIC  9(010) VALUE  0.*/
            public IntBasis AC_INS_SS { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    03  AC-ALT-SS                 PIC  9(010) VALUE  0.*/
            public IntBasis AC_ALT_SS { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    03  AC-EXC-SS                 PIC  9(010) VALUE  0.*/
            public IntBasis AC_EXC_SS { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    03  AC-INS-S1                 PIC  9(010) VALUE  0.*/
            public IntBasis AC_INS_S1 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    03  AC-ALT-S1                 PIC  9(010) VALUE  0.*/
            public IntBasis AC_ALT_S1 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    03  AC-EXC-S1                 PIC  9(010) VALUE  0.*/
            public IntBasis AC_EXC_S1 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    03  AC-INS-S2                 PIC  9(010) VALUE  0.*/
            public IntBasis AC_INS_S2 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    03  AC-ALT-S2                 PIC  9(010) VALUE  0.*/
            public IntBasis AC_ALT_S2 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    03  AC-EXC-S2                 PIC  9(010) VALUE  0.*/
            public IntBasis AC_EXC_S2 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"01  HEADER-RECORD.*/
        }
        public VA1471B_HEADER_RECORD HEADER_RECORD { get; set; } = new VA1471B_HEADER_RECORD();
        public class VA1471B_HEADER_RECORD : VarBasis
        {
            /*"    05  FILLER                    PIC  X(021) VALUE      'HICATU HARTFORD'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"HICATU HARTFORD");
            /*"    05  HEA-DATA-CRIACAO          PIC  X(008).*/
            public StringBasis HEA_DATA_CRIACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  HEA-ARQUIVO-ATU.*/
            public VA1471B_HEA_ARQUIVO_ATU HEA_ARQUIVO_ATU { get; set; } = new VA1471B_HEA_ARQUIVO_ATU();
            public class VA1471B_HEA_ARQUIVO_ATU : VarBasis
            {
                /*"      10  FILLER                  PIC  X(002) VALUE        'IH'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"IH");
                /*"      10  HEA-ANO-REF-ATU         PIC  9(002).*/
                public IntBasis HEA_ANO_REF_ATU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10  HEA-NUM-ARQ-ATU         PIC  9(004).*/
                public IntBasis HEA_NUM_ARQ_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  HEA-ARQUIVO-ANT.*/
            }
            public VA1471B_HEA_ARQUIVO_ANT HEA_ARQUIVO_ANT { get; set; } = new VA1471B_HEA_ARQUIVO_ANT();
            public class VA1471B_HEA_ARQUIVO_ANT : VarBasis
            {
                /*"      10  FILLER                  PIC  X(002) VALUE        'IH'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"IH");
                /*"      10  HEA-ANO-REF-ANT         PIC  9(002).*/
                public IntBasis HEA_ANO_REF_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10  HEA-NUM-ARQ-ANT         PIC  9(004).*/
                public IntBasis HEA_NUM_ARQ_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  DETAIL-RECORD.*/
            }
        }
        public VA1471B_DETAIL_RECORD DETAIL_RECORD { get; set; } = new VA1471B_DETAIL_RECORD();
        public class VA1471B_DETAIL_RECORD : VarBasis
        {
            /*"    05  DET-TIPO-MOV              PIC  X(002).*/
            public StringBasis DET_TIPO_MOV { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  DET-COD-PRODUTO           PIC  9(005).*/
            public IntBasis DET_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05  DET-NRCERTIF              PIC  9(015).*/
            public IntBasis DET_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  DET-CODPRODEA             PIC  X(002).*/
            public StringBasis DET_CODPRODEA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  DET-NOME-RAZAO            PIC  X(040).*/
            public StringBasis DET_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  DET-ENDERECO              PIC  X(040).*/
            public StringBasis DET_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  FILLER                    PIC  X(010) VALUE SPACES.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  DET-CIDADE                PIC  X(030).*/
            public StringBasis DET_CIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  DET-CEP                   PIC  9(008).*/
            public IntBasis DET_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  DET-SIGLA-UF              PIC  X(002).*/
            public StringBasis DET_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  DET-BAIRRO                PIC  X(020).*/
            public StringBasis DET_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  DET-CGCCPF                PIC  9(014).*/
            public IntBasis DET_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FILLER                    PIC  X(001) VALUE 'F'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"F");
            /*"    05  FILLER                    PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"    05  DET-DDD                   PIC  9(004).*/
            public IntBasis DET_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  DET-TELEFONE              PIC  9(009).*/
            public IntBasis DET_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  DET-DTNASC                PIC  X(008).*/
            public StringBasis DET_DTNASC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  DET-DTEMIS                PIC  X(008).*/
            public StringBasis DET_DTEMIS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  DET-DTINIVIG              PIC  X(008).*/
            public StringBasis DET_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  DET-DTTERVIG              PIC  X(008).*/
            public StringBasis DET_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  FILLER                    PIC  X(068) VALUE SPACES.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "68", "X(068)"), @"");
            /*"    05  DET-APOLICE               PIC  9(015).*/
            public IntBasis DET_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  DET-SUBGRUPO              PIC  9(004).*/
            public IntBasis DET_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  FILLER                    PIC  X(003) VALUE '001'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"001");
            /*"    05  DET-NUM-ITEM              PIC  9(009).*/
            public IntBasis DET_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  DET-DTCANCEL              PIC  X(008).*/
            public StringBasis DET_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  FILLER                    PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"01  TRAILLER-RECORD.*/
        }
        public VA1471B_TRAILLER_RECORD TRAILLER_RECORD { get; set; } = new VA1471B_TRAILLER_RECORD();
        public class VA1471B_TRAILLER_RECORD : VarBasis
        {
            /*"    05  FILLER                    PIC  X(001) VALUE 'T'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"T");
            /*"    05  TRA-TOT-REGISTROS         PIC  9(008).*/
            public IntBasis TRA_TOT_REGISTROS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  TRA-TOT-INCLUSOES         PIC  9(008).*/
            public IntBasis TRA_TOT_INCLUSOES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  TRA-TOT-ALTERACOES        PIC  9(008).*/
            public IntBasis TRA_TOT_ALTERACOES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  TRA-TOT-EXCLUSOES         PIC  9(008).*/
            public IntBasis TRA_TOT_EXCLUSOES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        LR00.*/
            public VA1471B_LR00 LR00 { get; set; } = new VA1471B_LR00();
            public class VA1471B_LR00 : VarBasis
            {
                /*"      10      FILLER              PIC X(44)   VALUE            'RELATORIO DE ASSISTENCIAS - CARGA FULL TEMPO'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "44", "X(44)"), @"RELATORIO DE ASSISTENCIAS - CARGA FULL TEMPO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(11)   VALUE            'GERADO EM: '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"GERADO EM: ");
                /*"      10      LR00-DATA           PIC X(10).*/
                public StringBasis LR00_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"    05        LR01.*/
            }
            public VA1471B_LR01 LR01 { get; set; } = new VA1471B_LR01();
            public class VA1471B_LR01 : VarBasis
            {
                /*"      10      FILLER              PIC X(21)   VALUE             'CODIGO DA ASSISTENCIA'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"CODIGO DA ASSISTENCIA");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(19)   VALUE             'NOME DA ASSISTENCIA'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"NOME DA ASSISTENCIA");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(23)   VALUE             'QUANTIDADE DE REGISTROS'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"QUANTIDADE DE REGISTROS");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(16)   VALUE             'TIPO DO REGISTRO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"TIPO DO REGISTRO");
                /*"    05        LR02.*/
            }
            public VA1471B_LR02 LR02 { get; set; } = new VA1471B_LR02();
            public class VA1471B_LR02 : VarBasis
            {
                /*"      10      LR02-COD-CONVENIO   PIC 9(11).*/
                public IntBasis LR02_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LR02-DESCRICAO      PIC X(25).*/
                public StringBasis LR02_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LR02-QUANTIDADE     PIC Z.ZZZ.ZZZ.ZZ9.*/
                public IntBasis LR02_QUANTIDADE { get; set; } = new IntBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9."));
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LR02-TIPO           PIC X(10).*/
                public StringBasis LR02_TIPO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"01  WABEND.*/
            }
        }
        public VA1471B_WABEND WABEND { get; set; } = new VA1471B_WABEND();
        public class VA1471B_WABEND : VarBasis
        {
            /*"      10  FILLER                  PIC  X(010) VALUE         'VA1471B  '.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA1471B  ");
            /*"      10  FILLER                  PIC  X(028) VALUE         ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10  FILLER                  PIC  X(014) VALUE         '    SQLCODE = '.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10  WSQLCODE                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD1 = '.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10  WSQLERRD1               PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD2 = '.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10  WSQLERRD2               PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD2 = '.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRMC = '.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
            /*"      10  WSQLERRMC               PIC  X(070)   VALUE SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"      05  LOCALIZA-ABEND-1.*/
            public VA1471B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA1471B_LOCALIZA_ABEND_1();
            public class VA1471B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10  FILLER                  PIC  X(012)   VALUE           'PARAGRAFO = '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10  PARAGRAFO               PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      05  LOCALIZA-ABEND-2.*/
            }
            public VA1471B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA1471B_LOCALIZA_ABEND_2();
            public class VA1471B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        10  FILLER                  PIC  X(012)   VALUE           'COMANDO   = '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10  COMANDO                 PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  FILLER.*/
            }
        }
        public VA1471B_FILLER_42 FILLER_42 { get; set; } = new VA1471B_FILLER_42();
        public class VA1471B_FILLER_42 : VarBasis
        {
            /*"    03 W01-I                   PIC 9(009).*/
            public IntBasis W01_I { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 W01-R-AUX REDEFINES W01-I                                PIC 9(009).*/
            private _REDEF_IntBasis _w01_r_aux { get; set; }
            public _REDEF_IntBasis W01_R_AUX
            {
                get { _w01_r_aux = new _REDEF_IntBasis(new PIC("9", "009", "9(009).")); ; _.Move(W01_I, _w01_r_aux); VarBasis.RedefinePassValue(W01_I, _w01_r_aux, W01_I); _w01_r_aux.ValueChanged += () => { _.Move(_w01_r_aux, W01_I); }; return _w01_r_aux; }
                set { VarBasis.RedefinePassValue(value, _w01_r_aux, W01_I); }
            }  //Redefines
            /*"    03 W01-FETCH-I             PIC 9(003).*/
            public IntBasis W01_FETCH_I { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    03 W01-SEG-FETCH-ANT       PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_FETCH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-SEG-INI             PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_INI { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-SEG-FIN             PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_FIN { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-QTD-ACC-OK          PIC 9(008).*/
            public IntBasis W01_QTD_ACC_OK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03 W01-QTD-ACC-NOK         PIC 9(008).*/
            public IntBasis W01_QTD_ACC_NOK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03 W01-TOT-ACC-OK-ED       PIC ZZ.ZZZ.ZZ9.*/
            public IntBasis W01_TOT_ACC_OK_ED { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
            /*"    03 W01-TOT-ACC-NOK-ED      PIC ZZ.ZZZ.ZZ9.*/
            public IntBasis W01_TOT_ACC_NOK_ED { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
            /*"    03 W01-TOT-TIME-ED         PIC ZZZ.ZZ9,9999-.*/
            public DoubleBasis W01_TOT_TIME_ED { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V9999-."), 5);
            /*"    03      W01-CURRENT-DATE.*/
            public VA1471B_W01_CURRENT_DATE W01_CURRENT_DATE { get; set; } = new VA1471B_W01_CURRENT_DATE();
            public class VA1471B_W01_CURRENT_DATE : VarBasis
            {
                /*"      10    W01-CDTE-ANO       PIC  9(004).*/
                public IntBasis W01_CDTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    W01-CDTE-MES       PIC  9(002).*/
                public IntBasis W01_CDTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-DIA       PIC  9(002).*/
                public IntBasis W01_CDTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-HORA      PIC  9(002).*/
                public IntBasis W01_CDTE_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-MIN       PIC  9(002).*/
                public IntBasis W01_CDTE_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-SEG       PIC  9(002).*/
                public IntBasis W01_CDTE_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-DECSEG    PIC  9(002).*/
                public IntBasis W01_CDTE_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-GREEN     PIC  X(001).*/
                public StringBasis W01_CDTE_GREEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    W01-CDTE-GHORA     PIC  9(002).*/
                public IntBasis W01_CDTE_GHORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-GMIN      PIC  9(002).*/
                public IntBasis W01_CDTE_GMIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W01-LIM-OCOR            PIC 9(009)      VALUE  28.*/
            }
            public IntBasis W01_LIM_OCOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 28);
            /*"    03 W01-TABELA-TOTAIS.*/
            public VA1471B_W01_TABELA_TOTAIS W01_TABELA_TOTAIS { get; set; } = new VA1471B_W01_TABELA_TOTAIS();
            public class VA1471B_W01_TABELA_TOTAIS : VarBasis
            {
                /*"       05 W01-TOT-ACC-OK       PIC 9(008)      OCCURS 28.*/
                public ListBasis<IntBasis, Int64> W01_TOT_ACC_OK { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)"), 28);
                /*"       05 W01-TOT-ACC-NOK      PIC 9(008)      OCCURS 28.*/
                public ListBasis<IntBasis, Int64> W01_TOT_ACC_NOK { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)"), 28);
                /*"       05 W01-TOT-TIME         PIC S9(08)V9(4) OCCURS 28.*/
                public ListBasis<DoubleBasis, double> W01_TOT_TIME { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V9(4)"), 28);
                /*"    03 W01-TABELA-TEXTO.*/
            }
            public VA1471B_W01_TABELA_TEXTO W01_TABELA_TEXTO { get; set; } = new VA1471B_W01_TABELA_TEXTO();
            public class VA1471B_W01_TABELA_TEXTO : VarBasis
            {
                /*"       05 W01-TAB-TEXTO                        OCCURS 28.*/
                public ListBasis<VA1471B_W01_TAB_TEXTO> W01_TAB_TEXTO { get; set; } = new ListBasis<VA1471B_W01_TAB_TEXTO>(28);
                public class VA1471B_W01_TAB_TEXTO : VarBasis
                {
                    /*"          10 W01-ORDEM         PIC X(002).*/
                    public StringBasis W01_ORDEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"          10 W01-TEXTO         PIC X(034).*/
                    public StringBasis W01_TEXTO { get; set; } = new StringBasis(new PIC("X", "34", "X(034)."), @"");
                    /*"01       WPAR-PARAMETROS     PIC  X(05).*/
                }
            }
        }
        public StringBasis WPAR_PARAMETROS { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
        /*"01       REDEFINES           WPAR-PARAMETROS.*/
        private _REDEF_VA1471B_REDEFINES _redefines { get; set; }
        public _REDEF_VA1471B_REDEFINES REDEFINES
        {
            get { _redefines = new _REDEF_VA1471B_REDEFINES(); _.Move(WPAR_PARAMETROS, _redefines); VarBasis.RedefinePassValue(WPAR_PARAMETROS, _redefines, WPAR_PARAMETROS); _redefines.ValueChanged += () => { _.Move(_redefines, WPAR_PARAMETROS); }; return _redefines; }
            set { VarBasis.RedefinePassValue(value, _redefines, WPAR_PARAMETROS); }
        }  //Redefines
        public class _REDEF_VA1471B_REDEFINES : VarBasis
        {
            /*"  05     WPAR-ROTINA         PIC  X(01).*/
            public StringBasis WPAR_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05     FILLER              PIC  X(01).*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05     WPAR-SIMULACAO      PIC  X(03).*/
            public StringBasis WPAR_SIMULACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");

            public _REDEF_VA1471B_REDEFINES()
            {
                WPAR_ROTINA.ValueChanged += OnValueChanged;
                FILLER_43.ValueChanged += OnValueChanged;
                WPAR_SIMULACAO.ValueChanged += OnValueChanged;
            }

        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CONARQEA CONARQEA { get; set; } = new Dclgens.CONARQEA();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.MOVIMEA MOVIMEA { get; set; } = new Dclgens.MOVIMEA();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.FUNCIONA FUNCIONA { get; set; } = new Dclgens.FUNCIONA();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA1471B_CPROPVA CPROPVA { get; set; } = new VA1471B_CPROPVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(StringBasis WPAR_PARAMETROS_P, string REPSAF_FILE_NAME_P, string RVA1471B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.WPAR_PARAMETROS.Value = WPAR_PARAMETROS_P.Value;
                REPSAF.SetFile(REPSAF_FILE_NAME_P);
                RVA1471B.SetFile(RVA1471B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { WPAR_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -672- DISPLAY ' ' */
            _.Display($" ");

            /*" -674- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -681- DISPLAY 'PROGRAMA VA1471B - VERSAO V.58 - DEMANDA 510565  - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VA1471B - VERSAO V.58 - DEMANDA 510565  - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -682- DISPLAY 'ENVIA REPASSE SAF DE ASSISTENCIAS PARA TEMPO ASSIST' */
            _.Display($"ENVIA REPASSE SAF DE ASSISTENCIAS PARA TEMPO ASSIST");

            /*" -684- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -689- DISPLAY ' ' */
            _.Display($" ");

            /*" -693- INITIALIZE W01-TABELA-TOTAIS W01-FETCH-I */
            _.Initialize(
                FILLER_42.W01_TABELA_TOTAIS
                , FILLER_42.W01_FETCH_I
            );

            /*" -694- MOVE 01 TO W01-I */
            _.Move(01, FILLER_42.W01_I);

            /*" -696- MOVE 'SET CURRENT TIMESTAMP INI' TO W01-TEXTO(W01-I) */
            _.Move("SET CURRENT TIMESTAMP INI", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -700- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -702- PERFORM M_0000_PRINCIPAL_DB_SET_1 */

            M_0000_PRINCIPAL_DB_SET_1();

            /*" -706- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -710- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -711- DISPLAY ' ' */
            _.Display($" ");

            /*" -713- MOVE SPACES TO WPAR-ROTINA WPAR-SIMULACAO */
            _.Move("", REDEFINES.WPAR_ROTINA);
            _.Move("", REDEFINES.WPAR_SIMULACAO);


            /*" -715- ACCEPT WPAR-PARAMETROS FROM SYSIN */
            /*-Accept convertido para parametro de entrada...*/

            /*" -717- DISPLAY '===================================================' '=========' */
            _.Display($"============================================================");

            /*" -718- DISPLAY 'PARAMETROS ACESSADOS:' */
            _.Display($"PARAMETROS ACESSADOS:");

            /*" -719- DISPLAY 'ROTINA    = ' WPAR-ROTINA */
            _.Display($"ROTINA    = {REDEFINES.WPAR_ROTINA}");

            /*" -720- DISPLAY 'SIMULACAO = ' WPAR-SIMULACAO */
            _.Display($"SIMULACAO = {REDEFINES.WPAR_SIMULACAO}");

            /*" -722- DISPLAY '===================================================' '=========' */
            _.Display($"============================================================");

            /*" -724- DISPLAY ' ' */
            _.Display($" ");

            /*" -727- OPEN OUTPUT REPSAF RVA1471B. */
            REPSAF.Open(REPSAF_RECORD);
            RVA1471B.Open(ASSIST_RECORD);

            /*" -728- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -734- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -735- MOVE 02 TO W01-I */
            _.Move(02, FILLER_42.W01_I);

            /*" -736- MOVE W01-I TO W01-FETCH-I */
            _.Move(FILLER_42.W01_I, FILLER_42.W01_FETCH_I);

            /*" -744- MOVE 'PRIMEIRO FETCH ?????????' TO W01-TEXTO(W01-FETCH-I) */
            _.Move("PRIMEIRO FETCH ?????????", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_FETCH_I].W01_TEXTO);

            /*" -745- MOVE 03 TO W01-I */
            _.Move(03, FILLER_42.W01_I);

            /*" -747- MOVE 'SELECT SISTEMAS' TO W01-TEXTO(W01-I) */
            _.Move("SELECT SISTEMAS", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -751- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -766- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -770- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -775- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -776- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -777- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -779- END-IF. */
            }


            /*" -780- IF WPAR-ROTINA EQUAL 'M' */

            if (REDEFINES.WPAR_ROTINA == "M")
            {

                /*" -781- MOVE '0001-01-01' TO WHOST-DTH-INI */
                _.Move("0001-01-01", WHOST_DTH_INI);

                /*" -783- MOVE '9999-12-31' TO WHOST-DTH-FIM */
                _.Move("9999-12-31", WHOST_DTH_FIM);

                /*" -784- MOVE SISTEMAS-DTMOVABE-60M TO WHOST-DTH-INI-BIL */
                _.Move(SISTEMAS_DTMOVABE_60M, WHOST_DTH_INI_BIL);

                /*" -785- ELSE */
            }
            else
            {


                /*" -787- MOVE SISTEMAS-DTMOVABE-10D TO WHOST-DTH-INI WHOST-DTH-INI-BIL */
                _.Move(SISTEMAS_DTMOVABE_10D, WHOST_DTH_INI, WHOST_DTH_INI_BIL);

                /*" -788- MOVE SISTEMAS-DTCURREN TO WHOST-DTH-FIM */
                _.Move(SISTEMAS_DTCURREN, WHOST_DTH_FIM);

                /*" -790- END-IF. */
            }


            /*" -791- DISPLAY 'ROTINA M/D PARAM. <' WPAR-ROTINA '>' */

            $"ROTINA M/D PARAM. <{REDEFINES.WPAR_ROTINA}>"
            .Display();

            /*" -792- DISPLAY ' ' */
            _.Display($" ");

            /*" -793- DISPLAY 'DATA-MOV-ABERTO   <' SISTEMAS-DATA-MOV-ABERTO '>' */

            $"DATA-MOV-ABERTO   <{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}>"
            .Display();

            /*" -794- DISPLAY 'DATA DE INICIO    <' WHOST-DTH-INI '>' */

            $"DATA DE INICIO    <{WHOST_DTH_INI}>"
            .Display();

            /*" -795- DISPLAY 'DATA INIC.BILHETE <' WHOST-DTH-INI-BIL '>' */

            $"DATA INIC.BILHETE <{WHOST_DTH_INI_BIL}>"
            .Display();

            /*" -797- DISPLAY 'DATA FIM (HOJE)   <' WHOST-DTH-FIM '>' */

            $"DATA FIM (HOJE)   <{WHOST_DTH_FIM}>"
            .Display();

            /*" -798- DISPLAY ' ' */
            _.Display($" ");

            /*" -799- DISPLAY 'DATA CORRENTE INICIO: DATA DE HOJE, DIA 01' */
            _.Display($"DATA CORRENTE INICIO: DATA DE HOJE, DIA 01");

            /*" -800- DISPLAY 'DATA CORRENTE FIM   : DATA DE HOJE, ULTIMO DIA' */
            _.Display($"DATA CORRENTE FIM   : DATA DE HOJE, ULTIMO DIA");

            /*" -801- MOVE SISTEMAS-DTCURREN TO W01DTSQL. */
            _.Move(SISTEMAS_DTCURREN, WS_WORK_AREAS.W01DTSQL);

            /*" -802- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -803- MOVE W01DTSQL TO SISTEMAS-DTCURINI. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMAS_DTCURINI);

            /*" -804- MOVE ULT-DIA(W01MMSQL) TO W01DDSQL. */
            _.Move(WS_WORK_AREAS.TABELA_ULT_DIAS.TAB_DIAS_R.ULT_DIA[WS_WORK_AREAS.W01DTSQL.W01MMSQL], WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -806- MOVE W01DTSQL TO SISTEMAS-DTCURREN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMAS_DTCURREN);

            /*" -807- DISPLAY 'DT.CURR.INICIO  <' SISTEMAS-DTCURINI '>' */

            $"DT.CURR.INICIO  <{SISTEMAS_DTCURINI}>"
            .Display();

            /*" -809- DISPLAY 'DT.CURR.FIM     <' SISTEMAS-DTCURREN '>' */

            $"DT.CURR.FIM     <{SISTEMAS_DTCURREN}>"
            .Display();

            /*" -810- MOVE SISTEMAS-DATA-MOV-ABERTO TO W01DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_WORK_AREAS.W01DTSQL);

            /*" -811- MOVE W01DDSQL TO W01DDINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTINV.W01DDINV);

            /*" -812- MOVE W01MMSQL TO W01MMINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTINV.W01MMINV);

            /*" -813- MOVE W01AASQL TO W01AAINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTINV.W01AAINV);

            /*" -815- MOVE W01DTINV TO HEA-DATA-CRIACAO. */
            _.Move(WS_WORK_AREAS.W01DTINV, HEADER_RECORD.HEA_DATA_CRIACAO);

            /*" -816- MOVE SISTEMAS-DTMOVABE-1M TO W01DTSQL. */
            _.Move(SISTEMAS_DTMOVABE_1M, WS_WORK_AREAS.W01DTSQL);

            /*" -817- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -823- MOVE W01DTSQL TO SISTEMAS-DTMOVABE-1M. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMAS_DTMOVABE_1M);

            /*" -827- MOVE 'SELECT MAX NSAS' TO COMANDO. */
            _.Move("SELECT MAX NSAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -828- MOVE 04 TO W01-I */
            _.Move(04, FILLER_42.W01_I);

            /*" -830- MOVE 'SELECT CONT_ARQUIVOS_EA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT CONT_ARQUIVOS_EA", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -834- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -839- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -843- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -848- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -849- IF CONARQEA-NSAS EQUAL 0 */

            if (CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS == 0)
            {

                /*" -850- MOVE W01AASQL TO CONARQEA-ANO-REFERENCIA */
                _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA);

                /*" -851- MOVE SPACES TO HEA-ARQUIVO-ANT */
                _.Move("", HEADER_RECORD.HEA_ARQUIVO_ANT);

                /*" -852- MOVE 0 TO CONARQEA-NUM-ARQUIVO */
                _.Move(0, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO);

                /*" -853- ELSE */
            }
            else
            {


                /*" -856- MOVE 'SELECT NSAS' TO COMANDO */
                _.Move("SELECT NSAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -857- MOVE 05 TO W01-I */
                _.Move(05, FILLER_42.W01_I);

                /*" -859- MOVE 'SELECT CONT_ARQUIVOS_EA' TO W01-TEXTO(W01-I) */
                _.Move("SELECT CONT_ARQUIVOS_EA", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

                /*" -863- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

                R8000_TOTALIZA_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


                /*" -870- PERFORM M_0000_PRINCIPAL_DB_SELECT_3 */

                M_0000_PRINCIPAL_DB_SELECT_3();

                /*" -874- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_42.W01_QTD_ACC_OK);

                /*" -879- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

                R8100_TOTALIZA_FINAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


                /*" -880- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -881- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -883- END-IF */
                }


                /*" -884- MOVE CONARQEA-NUM-ARQUIVO TO HEA-NUM-ARQ-ANT */
                _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO, HEADER_RECORD.HEA_ARQUIVO_ANT.HEA_NUM_ARQ_ANT);

                /*" -886- MOVE CONARQEA-ANO-REFERENCIA TO WS-ANO-REF HEA-ANO-REF-ANT */
                _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA, WS_WORK_AREAS.WS_ANO_REF, HEADER_RECORD.HEA_ARQUIVO_ANT.HEA_ANO_REF_ANT);

                /*" -889- MOVE WS-ANO-REF-2 TO CONARQEA-ANO-REF-ANT. */
                _.Move(WS_WORK_AREAS.WS_ANO_REF_R.WS_ANO_REF_2, CONARQEA_ANO_REF_ANT);
            }


            /*" -891- ADD 1 TO CONARQEA-NSAS. */
            CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.Value = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS + 1;

            /*" -892- IF W01AASQL NOT EQUAL CONARQEA-ANO-REFERENCIA */

            if (WS_WORK_AREAS.W01DTSQL.W01AASQL != CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA)
            {

                /*" -893- MOVE 1 TO CONARQEA-NUM-ARQUIVO */
                _.Move(1, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO);

                /*" -894- MOVE W01AASQL TO CONARQEA-ANO-REFERENCIA */
                _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA);

                /*" -895- ELSE */
            }
            else
            {


                /*" -896- ADD 1 TO CONARQEA-NUM-ARQUIVO */
                CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO.Value = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO + 1;

                /*" -898- END-IF. */
            }


            /*" -899- MOVE CONARQEA-NUM-ARQUIVO TO HEA-NUM-ARQ-ATU. */
            _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO, HEADER_RECORD.HEA_ARQUIVO_ATU.HEA_NUM_ARQ_ATU);

            /*" -900- MOVE CONARQEA-ANO-REFERENCIA TO WS-ANO-REF. */
            _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA, WS_WORK_AREAS.WS_ANO_REF);

            /*" -903- MOVE WS-ANO-REF-2 TO CONARQEA-ANO-REF-ATU HEA-ANO-REF-ATU. */
            _.Move(WS_WORK_AREAS.WS_ANO_REF_R.WS_ANO_REF_2, CONARQEA_ANO_REF_ATU, HEADER_RECORD.HEA_ARQUIVO_ATU.HEA_ANO_REF_ATU);

            /*" -905- WRITE REPSAF-RECORD FROM HEADER-RECORD. */
            _.Move(HEADER_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

            /*" -907- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1256- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -1261- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1262- MOVE 06 TO W01-I */
            _.Move(06, FILLER_42.W01_I);

            /*" -1264- MOVE 'OPEN CPROPVA' TO W01-TEXTO(W01-I) */
            _.Move("OPEN CPROPVA", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -1268- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -1268- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -1272- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -1277- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -1278- MOVE W01-FETCH-I TO W01-I */
            _.Move(FILLER_42.W01_FETCH_I, FILLER_42.W01_I);

            /*" -1280- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -1283- MOVE W01-SEG-INI TO W01-SEG-FETCH-ANT */
            _.Move(FILLER_42.W01_SEG_INI, FILLER_42.W01_SEG_FETCH_ANT);

            /*" -1286- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -1287- MOVE W01-FETCH-I TO W01-I */
            _.Move(FILLER_42.W01_FETCH_I, FILLER_42.W01_I);

            /*" -1288- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -1289- MOVE W01-SEG-FETCH-ANT TO W01-SEG-INI */
            _.Move(FILLER_42.W01_SEG_FETCH_ANT, FILLER_42.W01_SEG_INI);

            /*" -1293- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -1296- PERFORM 0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_CONTINUA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -1298- MOVE 'INSERT CONT_ARQUIVOS_EA' TO COMANDO. */
            _.Move("INSERT CONT_ARQUIVOS_EA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1300- MOVE AC-INCLUIDOS TO CONARQEA-NUM-INCLUSOES TRA-TOT-INCLUSOES. */
            _.Move(WS_WORK_AREAS.AC_INCLUIDOS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_INCLUSOES, TRAILLER_RECORD.TRA_TOT_INCLUSOES);

            /*" -1302- MOVE AC-ALTERADOS TO CONARQEA-NUM-ALTERACOES TRA-TOT-ALTERACOES. */
            _.Move(WS_WORK_AREAS.AC_ALTERADOS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ALTERACOES, TRAILLER_RECORD.TRA_TOT_ALTERACOES);

            /*" -1304- MOVE AC-EXCLUIDOS TO CONARQEA-NUM-EXCLUSOES TRA-TOT-EXCLUSOES. */
            _.Move(WS_WORK_AREAS.AC_EXCLUIDOS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_EXCLUSOES, TRAILLER_RECORD.TRA_TOT_EXCLUSOES);

            /*" -1307- MOVE AC-REGISTROS TO CONARQEA-NUM-REGISTROS TRA-TOT-REGISTROS. */
            _.Move(WS_WORK_AREAS.AC_REGISTROS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_REGISTROS, TRAILLER_RECORD.TRA_TOT_REGISTROS);

            /*" -1308- MOVE 07 TO W01-I */
            _.Move(07, FILLER_42.W01_I);

            /*" -1310- MOVE 'INSERT CONT_ARQUIVOS_EA' TO W01-TEXTO(W01-I) */
            _.Move("INSERT CONT_ARQUIVOS_EA", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -1314- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -1326- PERFORM M_0000_PRINCIPAL_DB_INSERT_1 */

            M_0000_PRINCIPAL_DB_INSERT_1();

            /*" -1330- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -1334- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -1335- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1337- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1337- WRITE REPSAF-RECORD FROM TRAILLER-RECORD. */
            _.Move(TRAILLER_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SET-1 */
        public void M_0000_PRINCIPAL_DB_SET_1()
        {
            /*" -702- EXEC SQL SET :WS-TIMESTAMP-INI = CURRENT TIMESTAMP END-EXEC */
            _.Move(_.CurrentDate(), WS_WORK_AREAS.WS_TIMESTAMP_INI);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -766- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 10 DAYS, DATA_MOV_ABERTO - 1 MONTH, DATA_MOV_ABERTO - 60 MONTHS, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DTMOVABE-10D, :SISTEMAS-DTMOVABE-1M, :SISTEMAS-DTMOVABE-60M, :SISTEMAS-DTCURREN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DTMOVABE_10D, SISTEMAS_DTMOVABE_10D);
                _.Move(executed_1.SISTEMAS_DTMOVABE_1M, SISTEMAS_DTMOVABE_1M);
                _.Move(executed_1.SISTEMAS_DTMOVABE_60M, SISTEMAS_DTMOVABE_60M);
                _.Move(executed_1.SISTEMAS_DTCURREN, SISTEMAS_DTCURREN);
            }


        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -1344- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -1348- PERFORM R8200-MOSTRA-TOTALIZADORES THRU R8200-MOSTRA-TOTALIZ-EXIT */

            R8200_MOSTRA_TOTALIZADORES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8200_MOSTRA_TOTALIZ_EXIT*/


            /*" -1350- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1350- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -839- EXEC SQL SELECT VALUE(MAX(NSAS),0) INTO :CONARQEA-NSAS FROM SEGUROS.CONT_ARQUIVOS_EA WHERE NSAS > 0 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONARQEA_NSAS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -1256- EXEC SQL DECLARE CPROPVA CURSOR FOR ( SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCOREND , A.DATA_QUITACAO, A.DATA_QUITACAO, A.DATA_QUITACAO + 10 YEARS, A.SIT_REGISTRO, A.DTPROXVEN, A.COD_PRODUTO, B.COD_PRODUTO_EA, B.OPCAO_PAGAMENTO, B.PERI_PAGAMENTO, B.ORIG_PRODU FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.PRODUTOS_VG B WHERE A.NUM_CERTIFICADO > 0 AND A.SIT_REGISTRO IN ( '3' , '6' ) AND A.DATA_QUITACAO BETWEEN :WHOST-DTH-INI AND :WHOST-DTH-FIM AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.ROT_SAF = 'MULTI' AND B.RAMO <> 77 AND A.COD_PRODUTO <> 9729 AND A.NUM_APOLICE NOT IN (3009300006440,3009300006470,3009300006528 ,3009300006529,3009300006552,3009300006562 ,3009300006584,3009300006638,3009300006642 ,3009300006670,3009300006673,3009300006713 ,3009300006889,3009300006936,3009300006956 ,3009300006958,3009300007002,3009300007023 ,3009300007090,3009300007159,3009300007167 ,3009300007171,3009300007172,3009300007182 ) ) UNION ( SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCOREND , A.DATA_QUITACAO, A.DATA_QUITACAO, A.DATA_QUITACAO + 10 YEARS, A.SIT_REGISTRO, A.DTPROXVEN, A.COD_PRODUTO, B.COD_PRODUTO_EA, B.OPCAO_PAGAMENTO, B.PERI_PAGAMENTO, B.ORIG_PRODU FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.PRODUTOS_VG B WHERE A.NUM_CERTIFICADO > 0 AND A.SIT_REGISTRO = '4' AND A.DATA_MOVIMENTO > :SISTEMAS-DTMOVABE-10D AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.ROT_SAF = 'MULTI' AND B.RAMO <> 77 AND A.COD_PRODUTO <> 9729 AND A.NUM_APOLICE NOT IN (3009300006440,3009300006470,3009300006528 ,3009300006529,3009300006552,3009300006562 ,3009300006584,3009300006638,3009300006642 ,3009300006670,3009300006673,3009300006713 ,3009300006889,3009300006936,3009300006956 ,3009300006958,3009300007002,3009300007023 ,3009300007090,3009300007159,3009300007167 ,3009300007171,3009300007172,3009300007182 ) ) UNION ( SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCORR_ENDERECO, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA + 10 YEARS, '3' , A.DATA_INIVIGENCIA, B.COD_PRODUTO, B.COD_PRODUTO_EA, '1' , 1, B.ROT_SAF FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PRODUTOS_VG B WHERE A.DATA_INIVIGENCIA BETWEEN :WHOST-DTH-INI AND :WHOST-DTH-FIM AND A.SIT_REGISTRO IN ( '0' , '1' ) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.ROT_SAF = 'GCS' AND A.NUM_APOLICE NOT IN (3009300006440,3009300006470,3009300006528 ,3009300006529,3009300006552,3009300006562 ,3009300006584,3009300006638,3009300006642 ,3009300006670,3009300006673,3009300006713 ,3009300006889,3009300006936,3009300006956 ,3009300006958,3009300007002,3009300007023 ,3009300007090,3009300007159,3009300007167 ,3009300007171,3009300007172,3009300007182 ) ) UNION ( SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCORR_ENDERECO, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA + 10 YEARS, '4' , A.DATA_INIVIGENCIA, B.COD_PRODUTO, B.COD_PRODUTO_EA, '1' , 1, B.ROT_SAF FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PRODUTOS_VG B, SEGUROS.MOVIMENTO_VGAP C WHERE A.SIT_REGISTRO NOT IN ( '0' , '1' ) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.ROT_SAF = 'GCS' AND C.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND C.COD_OPERACAO BETWEEN 400 AND 499 AND A.NUM_APOLICE NOT IN (3009300006440,3009300006470,3009300006528 ,3009300006529,3009300006552,3009300006562 ,3009300006584,3009300006638,3009300006642 ,3009300006670,3009300006673,3009300006713 ,3009300006889,3009300006936,3009300006956 ,3009300006958,3009300007002,3009300007023 ,3009300007090,3009300007159,3009300007167 ,3009300007171,3009300007172,3009300007182 ) ) UNION ( SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCORR_ENDERECO, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA + 10 YEARS, '3' , A.DATA_INIVIGENCIA, B.COD_PRODUTO, B.COD_PRODUTO_EA, '1' , 1, 'GCS' FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PRODUTOS_VG B WHERE A.NUM_APOLICE = +109300002554 AND A.DATA_INIVIGENCIA BETWEEN :SISTEMAS-DTMOVABE-1M AND :WHOST-DTH-FIM AND A.SIT_REGISTRO IN ( '0' , '1' ) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO ) UNION ( SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCORR_ENDERECO, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA + 10 YEARS, '4' , A.DATA_INIVIGENCIA, B.COD_PRODUTO, B.COD_PRODUTO_EA, '1' , 1, 'GCS' FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PRODUTOS_VG B, SEGUROS.MOVIMENTO_VGAP C WHERE A.NUM_APOLICE = +109300002554 AND A.SIT_REGISTRO NOT IN ( '0' , '1' ) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND C.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND C.COD_OPERACAO BETWEEN 400 AND 499 ) UNION ( SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCORR_ENDERECO, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA + 10 YEARS, '3' , A.DATA_INIVIGENCIA, B.COD_PRODUTO, B.COD_PRODUTO_EA, '1' , 1, 'GCS' FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PRODUTOS_VG B WHERE A.NUM_APOLICE IN (109300003382, 109300003383 ,3009300006440,3009300006470,3009300006528 ,3009300006529,3009300006552,3009300006562 ,3009300006584,3009300006638,3009300006642 ,3009300006670,3009300006673,3009300006713 ,3009300006889,3009300006936,3009300006956 ,3009300006958,3009300007002,3009300007023 ,3009300007090,3009300007159,3009300007167 ,3009300007171,3009300007172,3009300007182 ) AND A.DATA_INIVIGENCIA BETWEEN :WHOST-DTH-INI AND :WHOST-DTH-FIM AND A.SIT_REGISTRO IN ( '0' , '1' ) AND B.NUM_APOLICE = A.NUM_APOLICE ) UNION ( SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCORR_ENDERECO, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA + 10 YEARS, '4' , A.DATA_INIVIGENCIA, B.COD_PRODUTO, B.COD_PRODUTO_EA, '1' , 1, 'GCS' FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PRODUTOS_VG B, SEGUROS.MOVIMENTO_VGAP C WHERE A.NUM_APOLICE IN (109300003382, 109300003383 ,3009300006440,3009300006470,3009300006528 ,3009300006529,3009300006552,3009300006562 ,3009300006584,3009300006638,3009300006642 ,3009300006670,3009300006673,3009300006713 ,3009300006889,3009300006936,3009300006956 ,3009300006958,3009300007002,3009300007023 ,3009300007090,3009300007159,3009300007167 ,3009300007171,3009300007172,3009300007182 ) AND A.SIT_REGISTRO NOT IN ( '0' , '1' ) AND B.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND C.COD_OPERACAO BETWEEN 400 AND 499 ) UNION ( SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCORR_ENDERECO, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA, A.DATA_INIVIGENCIA + 10 YEARS, '3' , A.DATA_INIVIGENCIA, B.COD_PRODUTO, B.COD_PRODUTO_EA, '1' , 1, B.ROT_SAF FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PRODUTOS_VG B WHERE A.NUM_APOLICE NOT IN (109700000001,109300000667, 109300000668,109300000669, 109300001791 ,3009300006440,3009300006470,3009300006528 ,3009300006529,3009300006552,3009300006562 ,3009300006584,3009300006638,3009300006642 ,3009300006670,3009300006673,3009300006713 ,3009300006889,3009300006936,3009300006956 ,3009300006958,3009300007002,3009300007023 ,3009300007090,3009300007159,3009300007167 ,3009300007171,3009300007172,3009300007182 ) AND A.DATA_INIVIGENCIA BETWEEN :WHOST-DTH-INI AND :WHOST-DTH-FIM AND A.SIT_REGISTRO IN ( '0' , '1' ) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.ROT_SAF = 'GCS' ) UNION ( SELECT A.NUM_BILHETE , A.NUM_APOLICE, 0 , A.COD_CLIENTE, A.OCORR_ENDERECO, B.DATA_EMISSAO, B.DATA_INIVIGENCIA, B.DATA_TERVIGENCIA, '3' , A.DATA_QUITACAO + 1 YEAR, B.COD_PRODUTO, 'SS' , '1' , 12, 'BILHE ' FROM SEGUROS.BILHETE A, SEGUROS.ENDOSSOS B WHERE A.SITUACAO = '9' AND A.DATA_QUITACAO BETWEEN :WHOST-DTH-INI-BIL AND :WHOST-DTH-FIM AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO IN (SELECT MAX (E.NUM_ENDOSSO) FROM SEGUROS.ENDOSSOS E WHERE E.NUM_APOLICE = A.NUM_APOLICE) AND A.NUM_APOLICE NOT IN (3009300006440,3009300006470,3009300006528 ,3009300006529,3009300006552,3009300006562 ,3009300006584,3009300006638,3009300006642 ,3009300006670,3009300006673,3009300006713 ,3009300006889,3009300006936,3009300006956 ,3009300006958,3009300007002,3009300007023 ,3009300007090,3009300007159,3009300007167 ,3009300007171,3009300007172,3009300007182 ) ) ORDER BY 6,1 FOR FETCH ONLY WITH UR END-EXEC. */
            CPROPVA = new VA1471B_CPROPVA(true);
            string GetQuery_CPROPVA()
            {
                var query = @$"( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCOREND
							, 
							A.DATA_QUITACAO
							, 
							A.DATA_QUITACAO
							, 
							A.DATA_QUITACAO + 10 YEARS
							, 
							A.SIT_REGISTRO
							, 
							A.DTPROXVEN
							, 
							A.COD_PRODUTO
							, 
							B.COD_PRODUTO_EA
							, 
							B.OPCAO_PAGAMENTO
							, 
							B.PERI_PAGAMENTO
							, 
							B.ORIG_PRODU 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE A.NUM_CERTIFICADO > 0 
							AND A.SIT_REGISTRO IN ( '3'
							, '6' ) 
							AND A.DATA_QUITACAO BETWEEN '{WHOST_DTH_INI}' 
							AND '{WHOST_DTH_FIM}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.ROT_SAF = 'MULTI' 
							AND B.RAMO <> 77 
							AND A.COD_PRODUTO <> 9729 
							AND A.NUM_APOLICE NOT IN 
							(3009300006440
							,3009300006470
							,3009300006528 
							,3009300006529
							,3009300006552
							,3009300006562 
							,3009300006584
							,3009300006638
							,3009300006642 
							,3009300006670
							,3009300006673
							,3009300006713 
							,3009300006889
							,3009300006936
							,3009300006956 
							,3009300006958
							,3009300007002
							,3009300007023 
							,3009300007090
							,3009300007159
							,3009300007167 
							,3009300007171
							,3009300007172
							,3009300007182 
							) 
							) UNION ( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCOREND
							, 
							A.DATA_QUITACAO
							, 
							A.DATA_QUITACAO
							, 
							A.DATA_QUITACAO + 10 YEARS
							, 
							A.SIT_REGISTRO
							, 
							A.DTPROXVEN
							, 
							A.COD_PRODUTO
							, 
							B.COD_PRODUTO_EA
							, 
							B.OPCAO_PAGAMENTO
							, 
							B.PERI_PAGAMENTO
							, 
							B.ORIG_PRODU 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE A.NUM_CERTIFICADO > 0 
							AND A.SIT_REGISTRO = '4' 
							AND A.DATA_MOVIMENTO > '{SISTEMAS_DTMOVABE_10D}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.ROT_SAF = 'MULTI' 
							AND B.RAMO <> 77 
							AND A.COD_PRODUTO <> 9729 
							AND A.NUM_APOLICE NOT IN 
							(3009300006440
							,3009300006470
							,3009300006528 
							,3009300006529
							,3009300006552
							,3009300006562 
							,3009300006584
							,3009300006638
							,3009300006642 
							,3009300006670
							,3009300006673
							,3009300006713 
							,3009300006889
							,3009300006936
							,3009300006956 
							,3009300006958
							,3009300007002
							,3009300007023 
							,3009300007090
							,3009300007159
							,3009300007167 
							,3009300007171
							,3009300007172
							,3009300007182 
							) 
							) UNION ( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA + 10 YEARS
							, 
							'3'
							, 
							A.DATA_INIVIGENCIA
							, 
							B.COD_PRODUTO
							, 
							B.COD_PRODUTO_EA
							, 
							'1'
							, 
							1
							, 
							B.ROT_SAF 
							FROM SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE A.DATA_INIVIGENCIA BETWEEN '{WHOST_DTH_INI}' 
							AND '{WHOST_DTH_FIM}' 
							AND A.SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.ROT_SAF = 'GCS' 
							AND A.NUM_APOLICE NOT IN 
							(3009300006440
							,3009300006470
							,3009300006528 
							,3009300006529
							,3009300006552
							,3009300006562 
							,3009300006584
							,3009300006638
							,3009300006642 
							,3009300006670
							,3009300006673
							,3009300006713 
							,3009300006889
							,3009300006936
							,3009300006956 
							,3009300006958
							,3009300007002
							,3009300007023 
							,3009300007090
							,3009300007159
							,3009300007167 
							,3009300007171
							,3009300007172
							,3009300007182 
							) 
							) UNION ( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA + 10 YEARS
							, 
							'4'
							, 
							A.DATA_INIVIGENCIA
							, 
							B.COD_PRODUTO
							, 
							B.COD_PRODUTO_EA
							, 
							'1'
							, 
							1
							, 
							B.ROT_SAF 
							FROM SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B
							, 
							SEGUROS.MOVIMENTO_VGAP C 
							WHERE A.SIT_REGISTRO NOT IN ( '0'
							, '1' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.ROT_SAF = 'GCS' 
							AND C.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND C.COD_OPERACAO BETWEEN 400 AND 499 
							AND A.NUM_APOLICE NOT IN 
							(3009300006440
							,3009300006470
							,3009300006528 
							,3009300006529
							,3009300006552
							,3009300006562 
							,3009300006584
							,3009300006638
							,3009300006642 
							,3009300006670
							,3009300006673
							,3009300006713 
							,3009300006889
							,3009300006936
							,3009300006956 
							,3009300006958
							,3009300007002
							,3009300007023 
							,3009300007090
							,3009300007159
							,3009300007167 
							,3009300007171
							,3009300007172
							,3009300007182 
							) 
							) UNION ( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA + 10 YEARS
							, 
							'3'
							, 
							A.DATA_INIVIGENCIA
							, 
							B.COD_PRODUTO
							, 
							B.COD_PRODUTO_EA
							, 
							'1'
							, 
							1
							, 
							'GCS' 
							FROM SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE A.NUM_APOLICE = +109300002554 
							AND A.DATA_INIVIGENCIA BETWEEN '{SISTEMAS_DTMOVABE_1M}' 
							AND '{WHOST_DTH_FIM}' 
							AND A.SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							) UNION ( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA + 10 YEARS
							, 
							'4'
							, 
							A.DATA_INIVIGENCIA
							, 
							B.COD_PRODUTO
							, 
							B.COD_PRODUTO_EA
							, 
							'1'
							, 
							1
							, 
							'GCS' 
							FROM SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B
							, 
							SEGUROS.MOVIMENTO_VGAP C 
							WHERE A.NUM_APOLICE = +109300002554 
							AND A.SIT_REGISTRO NOT IN ( '0'
							, '1' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND C.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND C.COD_OPERACAO BETWEEN 400 AND 499 
							) UNION ( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA + 10 YEARS
							, 
							'3'
							, 
							A.DATA_INIVIGENCIA
							, 
							B.COD_PRODUTO
							, 
							B.COD_PRODUTO_EA
							, 
							'1'
							, 
							1
							, 
							'GCS' 
							FROM SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE A.NUM_APOLICE IN (109300003382
							, 
							109300003383 
							,3009300006440
							,3009300006470
							,3009300006528 
							,3009300006529
							,3009300006552
							,3009300006562 
							,3009300006584
							,3009300006638
							,3009300006642 
							,3009300006670
							,3009300006673
							,3009300006713 
							,3009300006889
							,3009300006936
							,3009300006956 
							,3009300006958
							,3009300007002
							,3009300007023 
							,3009300007090
							,3009300007159
							,3009300007167 
							,3009300007171
							,3009300007172
							,3009300007182 
							) 
							AND A.DATA_INIVIGENCIA BETWEEN '{WHOST_DTH_INI}' 
							AND '{WHOST_DTH_FIM}' 
							AND A.SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							) UNION ( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA + 10 YEARS
							, 
							'4'
							, 
							A.DATA_INIVIGENCIA
							, 
							B.COD_PRODUTO
							, 
							B.COD_PRODUTO_EA
							, 
							'1'
							, 
							1
							, 
							'GCS' 
							FROM SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B
							, 
							SEGUROS.MOVIMENTO_VGAP C 
							WHERE A.NUM_APOLICE IN (109300003382
							, 
							109300003383 
							,3009300006440
							,3009300006470
							,3009300006528 
							,3009300006529
							,3009300006552
							,3009300006562 
							,3009300006584
							,3009300006638
							,3009300006642 
							,3009300006670
							,3009300006673
							,3009300006713 
							,3009300006889
							,3009300006936
							,3009300006956 
							,3009300006958
							,3009300007002
							,3009300007023 
							,3009300007090
							,3009300007159
							,3009300007167 
							,3009300007171
							,3009300007172
							,3009300007182 
							) 
							AND A.SIT_REGISTRO NOT IN ( '0'
							, '1' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND C.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND C.COD_OPERACAO BETWEEN 400 AND 499 
							) UNION ( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA
							, 
							A.DATA_INIVIGENCIA + 10 YEARS
							, 
							'3'
							, 
							A.DATA_INIVIGENCIA
							, 
							B.COD_PRODUTO
							, 
							B.COD_PRODUTO_EA
							, 
							'1'
							, 
							1
							, 
							B.ROT_SAF 
							FROM SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE A.NUM_APOLICE NOT IN (109700000001
							,109300000667
							, 
							109300000668
							,109300000669
							, 
							109300001791 
							,3009300006440
							,3009300006470
							,3009300006528 
							,3009300006529
							,3009300006552
							,3009300006562 
							,3009300006584
							,3009300006638
							,3009300006642 
							,3009300006670
							,3009300006673
							,3009300006713 
							,3009300006889
							,3009300006936
							,3009300006956 
							,3009300006958
							,3009300007002
							,3009300007023 
							,3009300007090
							,3009300007159
							,3009300007167 
							,3009300007171
							,3009300007172
							,3009300007182 
							) 
							AND A.DATA_INIVIGENCIA BETWEEN '{WHOST_DTH_INI}' 
							AND '{WHOST_DTH_FIM}' 
							AND A.SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.ROT_SAF = 'GCS' 
							) UNION ( 
							SELECT A.NUM_BILHETE
							, 
							A.NUM_APOLICE
							, 
							0
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							B.DATA_EMISSAO
							, 
							B.DATA_INIVIGENCIA
							, 
							B.DATA_TERVIGENCIA
							, 
							'3'
							, 
							A.DATA_QUITACAO + 1 YEAR
							, 
							B.COD_PRODUTO
							, 
							'SS'
							, 
							'1'
							, 
							12
							, 
							'BILHE ' 
							FROM SEGUROS.BILHETE A
							, 
							SEGUROS.ENDOSSOS B 
							WHERE A.SITUACAO = '9' 
							AND A.DATA_QUITACAO BETWEEN '{WHOST_DTH_INI_BIL}' 
							AND '{WHOST_DTH_FIM}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO IN
							(SELECT  MAX (E.NUM_ENDOSSO) 
							FROM SEGUROS.ENDOSSOS E 
							WHERE E.NUM_APOLICE = 
							A.NUM_APOLICE) 
							AND A.NUM_APOLICE NOT IN 
							(3009300006440
							,3009300006470
							,3009300006528 
							,3009300006529
							,3009300006552
							,3009300006562 
							,3009300006584
							,3009300006638
							,3009300006642 
							,3009300006670
							,3009300006673
							,3009300006713 
							,3009300006889
							,3009300006936
							,3009300006956 
							,3009300006958
							,3009300007002
							,3009300007023 
							,3009300007090
							,3009300007159
							,3009300007167 
							,3009300007171
							,3009300007172
							,3009300007182 
							) 
							) 
							ORDER BY 6
							,1 
							FOR FETCH ONLY";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -1268- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-INSERT-1 */
        public void M_0000_PRINCIPAL_DB_INSERT_1()
        {
            /*" -1326- EXEC SQL INSERT INTO SEGUROS.CONT_ARQUIVOS_EA VALUES (:CONARQEA-NSAS, :CONARQEA-ANO-REFERENCIA, :CONARQEA-NUM-ARQUIVO, CURRENT DATE, :CONARQEA-NUM-REGISTROS, :CONARQEA-NUM-INCLUSOES, :CONARQEA-NUM-ALTERACOES, :CONARQEA-NUM-EXCLUSOES, 'VA1471B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_0000_PRINCIPAL_DB_INSERT_1_Insert1 = new M_0000_PRINCIPAL_DB_INSERT_1_Insert1()
            {
                CONARQEA_NSAS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.ToString(),
                CONARQEA_ANO_REFERENCIA = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA.ToString(),
                CONARQEA_NUM_ARQUIVO = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO.ToString(),
                CONARQEA_NUM_REGISTROS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_REGISTROS.ToString(),
                CONARQEA_NUM_INCLUSOES = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_INCLUSOES.ToString(),
                CONARQEA_NUM_ALTERACOES = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ALTERACOES.ToString(),
                CONARQEA_NUM_EXCLUSOES = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_EXCLUSOES.ToString(),
            };

            M_0000_PRINCIPAL_DB_INSERT_1_Insert1.Execute(m_0000_PRINCIPAL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -1361- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1363- INITIALIZE ASSIST-RECORD. */
            _.Initialize(
                ASSIST_RECORD
            );

            /*" -1364- IF PRODUVG-ORIG-PRODU (1:5) EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "BILHE")
            {

                /*" -1367- MOVE 'SELECT BILHETE      ' TO COMANDO */
                _.Move("SELECT BILHETE      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1368- MOVE 08 TO W01-I */
                _.Move(08, FILLER_42.W01_I);

                /*" -1370- MOVE 'SELECT BILHETE' TO W01-TEXTO(W01-I) */
                _.Move("SELECT BILHETE", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

                /*" -1374- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

                R8000_TOTALIZA_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


                /*" -1383- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

                /*" -1387- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_42.W01_QTD_ACC_OK);

                /*" -1391- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

                R8100_TOTALIZA_FINAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


                /*" -1392- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1394- DISPLAY 'BILHETE NAO ENCONTRADO: ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"BILHETE NAO ENCONTRADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1395- ADD 1 TO AC-REJEITADOS */
                    WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                    /*" -1396- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1397- ELSE */
                }
                else
                {


                    /*" -1398- IF CONVERSI-COD-PRODUTO-SIVPF EQUAL 8129 */

                    if (CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF == 8129)
                    {

                        /*" -1399- GO TO 0100-CONTINUA */

                        M_0100_CONTINUA(); //GOTO
                        return;

                        /*" -1400- END-IF */
                    }


                    /*" -1402- END-IF */
                }


                /*" -1403- IF PROPOVA-COD-PRODUTO EQUAL 8521 OR 8528 OR 8529 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("8521", "8528", "8529"))
                {

                    /*" -1404- ADD 1 TO AC-ACEITOS-BIL-AP */
                    WS_WORK_AREAS.AC_ACEITOS_BIL_AP.Value = WS_WORK_AREAS.AC_ACEITOS_BIL_AP + 1;

                    /*" -1405- GO TO 0100-CONTINUA */

                    M_0100_CONTINUA(); //GOTO
                    return;

                    /*" -1407- END-IF */
                }


                /*" -1408- IF PROPOVA-COD-PRODUTO EQUAL 8530 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8530)
                {

                    /*" -1409- ADD 1 TO AC-ACEITOS-BIL-MEI-8530 */
                    WS_WORK_AREAS.AC_ACEITOS_BIL_MEI_8530.Value = WS_WORK_AREAS.AC_ACEITOS_BIL_MEI_8530 + 1;

                    /*" -1410- GO TO 0100-CONTINUA */

                    M_0100_CONTINUA(); //GOTO
                    return;

                    /*" -1412- END-IF */
                }


                /*" -1413- IF PROPOVA-COD-PRODUTO EQUAL 8531 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8531)
                {

                    /*" -1414- ADD 1 TO AC-ACEITOS-BIL-MEI-8531 */
                    WS_WORK_AREAS.AC_ACEITOS_BIL_MEI_8531.Value = WS_WORK_AREAS.AC_ACEITOS_BIL_MEI_8531 + 1;

                    /*" -1415- GO TO 0100-CONTINUA */

                    M_0100_CONTINUA(); //GOTO
                    return;

                    /*" -1417- END-IF */
                }


                /*" -1418- IF PROPOVA-COD-PRODUTO EQUAL 8532 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8532)
                {

                    /*" -1419- ADD 1 TO AC-ACEITOS-BIL-MEI-8532 */
                    WS_WORK_AREAS.AC_ACEITOS_BIL_MEI_8532.Value = WS_WORK_AREAS.AC_ACEITOS_BIL_MEI_8532 + 1;

                    /*" -1420- GO TO 0100-CONTINUA */

                    M_0100_CONTINUA(); //GOTO
                    return;

                    /*" -1421- END-IF */
                }


                /*" -1423- END-IF. */
            }


            /*" -1424- IF PRODUVG-ORIG-PRODU (1:5) EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "BILHE")
            {

                /*" -1425- PERFORM M-0101-VERIFICA-SAF-LOTERICO THRU 0101-FIM */

                M_0101_VERIFICA_SAF_LOTERICO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0101_FIM*/


                /*" -1426- IF WS-SAF-LOTERICO EQUAL 'SIM' */

                if (WS_WORK_AREAS.WS_SAF_LOTERICO == "SIM")
                {

                    /*" -1427- GO TO 0100-CONTINUA */

                    M_0100_CONTINUA(); //GOTO
                    return;

                    /*" -1428- END-IF */
                }


                /*" -1430- END-IF. */
            }


            /*" -1431- IF PRODUVG-ORIG-PRODU (1:5) EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "BILHE")
            {

                /*" -1432- IF PROPVA-DTQIT10A < SISTEMAS-DATA-MOV-ABERTO */

                if (PROPVA_DTQIT10A < SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
                {

                    /*" -1433- ADD 1 TO AC-REJEITADOS */
                    WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                    /*" -1434- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1435- END-IF */
                }


                /*" -1437- END-IF. */
            }


            /*" -1438- IF PRODUVG-ORIG-PRODU (1:5) EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "BILHE")
            {

                /*" -1441- IF PROPOVA-NUM-CERTIFICADO > 80000000000 AND PROPOVA-NUM-CERTIFICADO < 89999999999 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO > 80000000000 && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO < 89999999999)
                {

                    /*" -1442- ADD 1 TO AC-REJEITADOS */
                    WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                    /*" -1443- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1444- END-IF */
                }


                /*" -1446- END-IF. */
            }


            /*" -1447- IF PRODUVG-ORIG-PRODU (1:5) EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "BILHE")
            {

                /*" -1448- MOVE PROPOVA-NUM-CERTIFICADO TO CONVERSI-NUM-SICOB */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

                /*" -1452- MOVE 'SELECT CONVERSI     ' TO COMANDO */
                _.Move("SELECT CONVERSI     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1453- MOVE 09 TO W01-I */
                _.Move(09, FILLER_42.W01_I);

                /*" -1455- MOVE 'SELECT CONVERSAO_SICOB' TO W01-TEXTO(W01-I) */
                _.Move("SELECT CONVERSAO_SICOB", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

                /*" -1459- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

                R8000_TOTALIZA_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


                /*" -1467- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

                /*" -1471- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_42.W01_QTD_ACC_OK);

                /*" -1475- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

                R8100_TOTALIZA_FINAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


                /*" -1476- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1477- ADD 1 TO AC-REJEITADOS */
                    WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                    /*" -1478- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1480- END-IF */
                }


                /*" -1481- IF CONVERSI-COD-PRODUTO-SIVPF NOT EQUAL 09 */

                if (CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF != 09)
                {

                    /*" -1482- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1484- END-IF */
                }


                /*" -1487- IF CONVERSI-NUM-PROPOSTA-SIVPF > 50000000000000 AND CONVERSI-NUM-PROPOSTA-SIVPF < 59999999999999 NEXT SENTENCE */

                if (CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF > 50000000000000 && CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF < 59999999999999)
                {

                    /*" -1488- ELSE */
                }
                else
                {


                    /*" -1489- ADD 1 TO AC-REJEITADOS */
                    WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                    /*" -1490- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1491- END-IF */
                }


                /*" -1491- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -1383- EXEC SQL SELECT B.NUM_PROPOSTA_SIVPF , B.COD_PRODUTO_SIVPF INTO :CONVERSI-NUM-PROPOSTA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF FROM SEGUROS.BILHETE A, SEGUROS.CONVERSAO_SICOB B WHERE A.NUM_BILHETE = :PROPOVA-NUM-CERTIFICADO AND A.NUM_BILHETE = B.NUM_SICOB END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.CONVERSI_COD_PRODUTO_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-3 */
        public void M_0000_PRINCIPAL_DB_SELECT_3()
        {
            /*" -870- EXEC SQL SELECT ANO_REFERENCIA, NUM_ARQUIVO INTO :CONARQEA-ANO-REFERENCIA, :CONARQEA-NUM-ARQUIVO FROM SEGUROS.CONT_ARQUIVOS_EA WHERE NSAS = :CONARQEA-NSAS END-EXEC */

            var m_0000_PRINCIPAL_DB_SELECT_3_Query1 = new M_0000_PRINCIPAL_DB_SELECT_3_Query1()
            {
                CONARQEA_NSAS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.ToString(),
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_3_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONARQEA_ANO_REFERENCIA, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA);
                _.Move(executed_1.CONARQEA_NUM_ARQUIVO, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -1467- EXEC SQL SELECT NUM_PROPOSTA_SIVPF , COD_PRODUTO_SIVPF INTO :CONVERSI-NUM-PROPOSTA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :CONVERSI-NUM-SICOB END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                CONVERSI_NUM_SICOB = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.CONVERSI_COD_PRODUTO_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);
            }


        }

        [StopWatch]
        /*" M-0100-CONTINUA */
        private void M_0100_CONTINUA(bool isPerform = false)
        {
            /*" -1500- MOVE 'SELECT MOVIMENTO_EA MAX' TO COMANDO. */
            _.Move("SELECT MOVIMENTO_EA MAX", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1501- MOVE 10 TO W01-I */
            _.Move(10, FILLER_42.W01_I);

            /*" -1503- MOVE 'SELECT MOVIMENTO_EA MAX' TO W01-TEXTO(W01-I) */
            _.Move("SELECT MOVIMENTO_EA MAX", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -1507- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -1513- PERFORM M_0100_CONTINUA_DB_SELECT_1 */

            M_0100_CONTINUA_DB_SELECT_1();

            /*" -1517- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -1521- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -1522- IF MOVIMEA-NSAS GREATER 0 */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS > 0)
            {

                /*" -1525- MOVE 'SELECT MOVIMENTO_EA ' TO COMANDO */
                _.Move("SELECT MOVIMENTO_EA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1526- MOVE 11 TO W01-I */
                _.Move(11, FILLER_42.W01_I);

                /*" -1528- MOVE 'SELECT MOVIMENTO_EA' TO W01-TEXTO(W01-I) */
                _.Move("SELECT MOVIMENTO_EA", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

                /*" -1532- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

                R8000_TOTALIZA_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


                /*" -1539- PERFORM M_0100_CONTINUA_DB_SELECT_2 */

                M_0100_CONTINUA_DB_SELECT_2();

                /*" -1543- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_42.W01_QTD_ACC_OK);

                /*" -1547- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

                R8100_TOTALIZA_FINAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


                /*" -1548- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1549- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1550- END-IF */
                }


                /*" -1552- END-IF */
            }


            /*" -1553- IF WPAR-ROTINA EQUAL 'M' */

            if (REDEFINES.WPAR_ROTINA == "M")
            {

                /*" -1554- MOVE ZEROS TO MOVIMEA-NSAS */
                _.Move(0, MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS);

                /*" -1555- MOVE SPACES TO MOVIMEA-TIPO-MOVIMENTO */
                _.Move("", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                /*" -1559- END-IF */
            }


            /*" -1563- IF PRODUVG-OPCAO-PAGAMENTO EQUAL '4' OR PRODUVG-ORIG-PRODU(1:5) EQUAL 'BILHE' OR PRODUVG-ORIG-PRODU EQUAL 'GCS' NEXT SENTENCE */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO == "4" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "BILHE" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "GCS")
            {

                /*" -1564- ELSE */
            }
            else
            {


                /*" -1565- IF PRODUVG-OPCAO-PAGAMENTO EQUAL '5' OR '3' */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO.In("5", "3"))
                {

                    /*" -1566- MOVE 'SELECT PARCELAS_VIDAZUL' TO COMANDO */
                    _.Move("SELECT PARCELAS_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1567- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

                    /*" -1571- MOVE 12 TO W01-I */
                    _.Move(12, FILLER_42.W01_I);

                    /*" -1573- MOVE 'SELECT PARCELAS_VIDAZUL' TO W01-TEXTO(W01-I) */
                    _.Move("SELECT PARCELAS_VIDAZUL", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

                    /*" -1577- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

                    R8000_TOTALIZA_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


                    /*" -1585- PERFORM M_0100_CONTINUA_DB_SELECT_3 */

                    M_0100_CONTINUA_DB_SELECT_3();

                    /*" -1589- MOVE 1 TO W01-QTD-ACC-OK */
                    _.Move(1, FILLER_42.W01_QTD_ACC_OK);

                    /*" -1593- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

                    R8100_TOTALIZA_FINAL(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


                    /*" -1594- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1595- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1597- IF PRODUVG-PERI-PAGAMENTO GREATER 01 NEXT SENTENCE */

                            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO > 01)
                            {

                                /*" -1598- ELSE */
                            }
                            else
                            {


                                /*" -1600- IF PROPOVA-SIT-REGISTRO EQUAL '4' NEXT SENTENCE */

                                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "4")
                                {

                                    /*" -1601- ELSE */
                                }
                                else
                                {


                                    /*" -1602- ADD 1 TO AC-REJEITADOS */
                                    WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                                    /*" -1603- GO TO 0100-NEXT */

                                    M_0100_NEXT(); //GOTO
                                    return;

                                    /*" -1604- ELSE */
                                }

                            }

                        }
                        else
                        {


                            /*" -1606- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                            if (DB.SQLCODE == -811)
                            {

                                /*" -1607- ELSE */
                            }
                            else
                            {


                                /*" -1609- DISPLAY 'ERRO NA LEITURA DA PARCELAS_VIDAZUL ' PROPOVA-NUM-CERTIFICADO */
                                _.Display($"ERRO NA LEITURA DA PARCELAS_VIDAZUL {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                                /*" -1613- GO TO 9999-ERRO. */

                                M_9999_ERRO(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -1614- IF MOVIMEA-NSAS EQUAL 0 */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS == 0)
            {

                /*" -1615- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO != "3")
                {

                    /*" -1616- ADD 1 TO AC-REJEITADOS */
                    WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                    /*" -1617- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1618- ELSE */
                }
                else
                {


                    /*" -1619- MOVE 'I' TO MOVIMEA-TIPO-MOVIMENTO */
                    _.Move("I", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                    /*" -1620- END-IF */
                }


                /*" -1621- ELSE */
            }
            else
            {


                /*" -1622- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'I' */

                if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "I")
                {

                    /*" -1623- IF PROPOVA-SIT-REGISTRO EQUAL '3' */

                    if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3")
                    {

                        /*" -1624- ADD 1 TO AC-REJEITADOS */
                        WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                        /*" -1625- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1626- ELSE */
                    }
                    else
                    {


                        /*" -1627- MOVE 'E' TO MOVIMEA-TIPO-MOVIMENTO */
                        _.Move("E", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                        /*" -1628- END-IF */
                    }


                    /*" -1629- ELSE */
                }
                else
                {


                    /*" -1630- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'E' */

                    if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "E")
                    {

                        /*" -1631- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO != "3")
                        {

                            /*" -1632- ADD 1 TO AC-REJEITADOS */
                            WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                            /*" -1633- GO TO 0100-NEXT */

                            M_0100_NEXT(); //GOTO
                            return;

                            /*" -1634- ELSE */
                        }
                        else
                        {


                            /*" -1635- MOVE 'A' TO MOVIMEA-TIPO-MOVIMENTO */
                            _.Move("A", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                            /*" -1636- END-IF */
                        }


                        /*" -1637- ELSE */
                    }
                    else
                    {


                        /*" -1638- IF PROPOVA-SIT-REGISTRO EQUAL '3' */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3")
                        {

                            /*" -1639- ADD 1 TO AC-REJEITADOS */
                            WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                            /*" -1640- GO TO 0100-NEXT */

                            M_0100_NEXT(); //GOTO
                            return;

                            /*" -1641- ELSE */
                        }
                        else
                        {


                            /*" -1642- MOVE 'E' TO MOVIMEA-TIPO-MOVIMENTO */
                            _.Move("E", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                            /*" -1643- END-IF */
                        }


                        /*" -1644- END-IF */
                    }


                    /*" -1645- END-IF */
                }


                /*" -1647- END-IF. */
            }


            /*" -1648- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'I' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "I")
            {

                /*" -1649- MOVE 'IN' TO DET-TIPO-MOV */
                _.Move("IN", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -1650- ADD 1 TO AC-INCLUIDOS */
                WS_WORK_AREAS.AC_INCLUIDOS.Value = WS_WORK_AREAS.AC_INCLUIDOS + 1;

                /*" -1651- ELSE */
            }
            else
            {


                /*" -1652- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'A' */

                if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "A")
                {

                    /*" -1653- MOVE 'AL' TO DET-TIPO-MOV */
                    _.Move("AL", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -1654- ADD 1 TO AC-ALTERADOS */
                    WS_WORK_AREAS.AC_ALTERADOS.Value = WS_WORK_AREAS.AC_ALTERADOS + 1;

                    /*" -1655- ELSE */
                }
                else
                {


                    /*" -1656- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'E' */

                    if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "E")
                    {

                        /*" -1657- MOVE 'EX' TO DET-TIPO-MOV */
                        _.Move("EX", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -1658- ADD 1 TO AC-EXCLUIDOS */
                        WS_WORK_AREAS.AC_EXCLUIDOS.Value = WS_WORK_AREAS.AC_EXCLUIDOS + 1;

                        /*" -1659- END-IF */
                    }


                    /*" -1660- END-IF */
                }


                /*" -1664- END-IF. */
            }


            /*" -1666- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1669- MOVE ZEROS TO CLIENT-DTNASC-I. */
            _.Move(0, CLIENT_DTNASC_I);

            /*" -1670- MOVE 13 TO W01-I */
            _.Move(13, FILLER_42.W01_I);

            /*" -1672- MOVE 'SELECT CLIENTES' TO W01-TEXTO(W01-I) */
            _.Move("SELECT CLIENTES", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -1676- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -1687- PERFORM M_0100_CONTINUA_DB_SELECT_4 */

            M_0100_CONTINUA_DB_SELECT_4();

            /*" -1691- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -1695- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -1696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1697- DISPLAY '*** NAO ENCONTROU CLIENTE ***' */
                _.Display($"*** NAO ENCONTROU CLIENTE ***");

                /*" -1701- DISPLAY 'CERTIFICADO: ' PROPOVA-NUM-CERTIFICADO ' APOLICE: ' PROPOVA-NUM-APOLICE ' SUBGRUPO: ' PROPOVA-COD-SUBGRUPO ' CLIENTE: ' PROPOVA-COD-CLIENTE */

                $"CERTIFICADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} APOLICE: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} SUBGRUPO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO} CLIENTE: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}"
                .Display();

                /*" -1702- DISPLAY ' ' */
                _.Display($" ");

                /*" -1703- ADD 1 TO AC-REJEITADOS */
                WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                /*" -1704- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1707- END-IF */
            }


            /*" -1708-  EVALUATE PROPOVA-COD-PRODUTO  */

            /*" -1708-  WHEN 8205 */

            /*" -1708-  WHEN JVPROD(8205) */

            /*" -1709-  WHEN 8209 */

            /*" -1709-  WHEN JVPROD(8209) */

            /*" -1710-  WHEN 9329 */

            /*" -1710-  WHEN JVPROD(9329) */

            /*" -1711-  WHEN 9343 */

            /*" -1711-  WHEN JVPROD(9343) */

            /*" -1713- IF   PROPOVA-COD-PRODUTO EQUALS 8205 OR  JVPROD(8205)  OR  8209  OR  JVPROD(8209)  OR  9329  OR  JVPROD(9329)  OR  9343  OR  JVPROD(9343) */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("8205", JVBKINCL.FILLER.JVPROD[8205].ToString(), "8209", JVBKINCL.FILLER.JVPROD[8209].ToString(), "9329", JVBKINCL.FILLER.JVPROD[9329].ToString(), "9343", JVBKINCL.FILLER.JVPROD[9343].ToString()))
            {

                /*" -1713- IF CLIENTES-TIPO-PESSOA NOT = 'J' */

                if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA != "J")
                {

                    /*" -1714- ADD 1 TO AC-REJEITADOS */
                    WS_WORK_AREAS.AC_REJEITADOS.Value = WS_WORK_AREAS.AC_REJEITADOS + 1;

                    /*" -1715- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1716- END-IF */
                }


                /*" -1718-  END-EVALUATE  */

                /*" -1718- END-IF */
            }


            /*" -1719- IF CLIENT-DTNASC-I LESS ZEROES */

            if (CLIENT_DTNASC_I < 00)
            {

                /*" -1722- MOVE 'SELECT SEGURADOS_VGAP' TO COMANDO */
                _.Move("SELECT SEGURADOS_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1723- MOVE 14 TO W01-I */
                _.Move(14, FILLER_42.W01_I);

                /*" -1725- MOVE 'SELECT SEGURADOS_VGAP' TO W01-TEXTO(W01-I) */
                _.Move("SELECT SEGURADOS_VGAP", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

                /*" -1729- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

                R8000_TOTALIZA_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


                /*" -1735- PERFORM M_0100_CONTINUA_DB_SELECT_5 */

                M_0100_CONTINUA_DB_SELECT_5();

                /*" -1739- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_42.W01_QTD_ACC_OK);

                /*" -1743- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

                R8100_TOTALIZA_FINAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


                /*" -1744- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1745- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1748- IF PRODUVG-ORIG-PRODU EQUAL 'GLOBAL' OR PRODUVG-ORIG-PRODU(1:5) EQUAL 'BILHE' OR PRODUVG-ORIG-PRODU(1:5) EQUAL 'EMPRE' */

                        if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "GLOBAL" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "BILHE" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "EMPRE")
                        {

                            /*" -1749- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
                            _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                            /*" -1750- END-IF */
                        }


                        /*" -1751- ELSE */
                    }
                    else
                    {


                        /*" -1752- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -1753- END-IF */
                    }


                    /*" -1755- END-IF */
                }


                /*" -1756- IF CLIENT-DTNASC-I LESS ZEROES */

                if (CLIENT_DTNASC_I < 00)
                {

                    /*" -1761- IF PRODUVG-ORIG-PRODU EQUAL 'GCS' OR PRODUVG-ORIG-PRODU (1:5) EQUAL 'BILHE' OR PRODUVG-ORIG-PRODU (1:6) EQUAL 'GLOBAL' OR PRODUVG-ORIG-PRODU (1:5) EQUAL 'EMPRE' OR PRODUVG-ORIG-PRODU EQUAL 'MULT ' */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "GCS" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "BILHE" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 6) == "GLOBAL" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.Substring(1, 5) == "EMPRE" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "MULT ")
                    {

                        /*" -1762- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
                        _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                        /*" -1763- ELSE */
                    }
                    else
                    {


                        /*" -1766- DISPLAY 'DATA DE NASCIMENTO INVALIDA NAS TABELAS ' PROPOVA-COD-CLIENTE ' ' PROPOVA-NUM-CERTIFICADO ' ' PRODUVG-ORIG-PRODU */

                        $"DATA DE NASCIMENTO INVALIDA NAS TABELAS {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU}"
                        .Display();

                        /*" -1767- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -1768- END-IF */
                    }


                    /*" -1769- END-IF */
                }


                /*" -1771- END-IF */
            }


            /*" -1774- MOVE 'SELECT ENDERECOS' TO COMANDO. */
            _.Move("SELECT ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1775- MOVE 16 TO W01-I */
            _.Move(16, FILLER_42.W01_I);

            /*" -1777- MOVE 'SELECT ENDERECOS' TO W01-TEXTO(W01-I) */
            _.Move("SELECT ENDERECOS", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -1781- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -1799- PERFORM M_0100_CONTINUA_DB_SELECT_6 */

            M_0100_CONTINUA_DB_SELECT_6();

            /*" -1803- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -1807- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -1808- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1809- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1811- END-IF. */
            }


            /*" -1812- MOVE PRODUVG-COD-PRODUTO-EA TO DET-CODPRODEA. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA, DETAIL_RECORD.DET_CODPRODEA);

            /*" -1813- MOVE CLIENTES-NOME-RAZAO TO DET-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETAIL_RECORD.DET_NOME_RAZAO);

            /*" -1814- MOVE ENDERECO-ENDERECO TO DET-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, DETAIL_RECORD.DET_ENDERECO);

            /*" -1815- MOVE ENDERECO-BAIRRO TO DET-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, DETAIL_RECORD.DET_BAIRRO);

            /*" -1816- MOVE ENDERECO-CIDADE TO DET-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, DETAIL_RECORD.DET_CIDADE);

            /*" -1817- MOVE ENDERECO-SIGLA-UF TO DET-SIGLA-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, DETAIL_RECORD.DET_SIGLA_UF);

            /*" -1818- MOVE ENDERECO-CEP TO DET-CEP. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, DETAIL_RECORD.DET_CEP);

            /*" -1819- MOVE ENDERECO-TELEFONE TO DET-TELEFONE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, DETAIL_RECORD.DET_TELEFONE);

            /*" -1820- MOVE ENDERECO-DDD TO DET-DDD. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, DETAIL_RECORD.DET_DDD);

            /*" -1821- MOVE CLIENTES-CGCCPF TO DET-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DETAIL_RECORD.DET_CGCCPF);

            /*" -1822- MOVE CLIENTES-DATA-NASCIMENTO TO W01DTSQL. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, WS_WORK_AREAS.W01DTSQL);

            /*" -1823- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -1824- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -1825- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -1826- MOVE W01DTCOR TO DET-DTNASC. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTNASC);

            /*" -1827- MOVE ENDOSSOS-DATA-EMISSAO TO W01DTSQL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, WS_WORK_AREAS.W01DTSQL);

            /*" -1828- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -1829- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -1830- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -1831- MOVE W01DTCOR TO DET-DTEMIS. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTEMIS);

            /*" -1832- MOVE PROPOVA-DATA-QUITACAO TO W01DTSQL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WS_WORK_AREAS.W01DTSQL);

            /*" -1833- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -1834- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -1836- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -1837- MOVE W01DTCOR TO DET-DTINIVIG. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTINIVIG);

            /*" -1838- MOVE PROPVA-DTQIT10A TO W01DTSQL. */
            _.Move(PROPVA_DTQIT10A, WS_WORK_AREAS.W01DTSQL);

            /*" -1839- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -1840- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -1841- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -1842- MOVE W01DTCOR TO DET-DTTERVIG. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTTERVIG);

            /*" -1843- MOVE PROPOVA-NUM-CERTIFICADO TO DET-NRCERTIF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, DETAIL_RECORD.DET_NRCERTIF);

            /*" -1844- MOVE PROPOVA-NUM-APOLICE TO DET-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, DETAIL_RECORD.DET_APOLICE);

            /*" -1845- MOVE PROPOVA-COD-SUBGRUPO TO DET-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, DETAIL_RECORD.DET_SUBGRUPO);

            /*" -1847- MOVE PROPOVA-COD-PRODUTO TO DET-COD-PRODUTO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, DETAIL_RECORD.DET_COD_PRODUTO);

            /*" -1847- PERFORM 0200-INSERT-REPSAF THRU 0200-FIM. */

            M_0200_INSERT_REPSAF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


        }

        [StopWatch]
        /*" M-0100-CONTINUA-DB-SELECT-1 */
        public void M_0100_CONTINUA_DB_SELECT_1()
        {
            /*" -1513- EXEC SQL SELECT VALUE(MAX(NSAS),0) INTO :MOVIMEA-NSAS FROM SEGUROS.MOVIMENTO_EA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_USUARIO = 'VA1471B' END-EXEC. */

            var m_0100_CONTINUA_DB_SELECT_1_Query1 = new M_0100_CONTINUA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0100_CONTINUA_DB_SELECT_1_Query1.Execute(m_0100_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMEA_NSAS, MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -1851- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-CONTINUA-DB-SELECT-2 */
        public void M_0100_CONTINUA_DB_SELECT_2()
        {
            /*" -1539- EXEC SQL SELECT TIPO_MOVIMENTO INTO :MOVIMEA-TIPO-MOVIMENTO FROM SEGUROS.MOVIMENTO_EA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NSAS = :MOVIMEA-NSAS AND COD_USUARIO = 'VA1471B' END-EXEC */

            var m_0100_CONTINUA_DB_SELECT_2_Query1 = new M_0100_CONTINUA_DB_SELECT_2_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                MOVIMEA_NSAS = MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS.ToString(),
            };

            var executed_1 = M_0100_CONTINUA_DB_SELECT_2_Query1.Execute(m_0100_CONTINUA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMEA_TIPO_MOVIMENTO, MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-CONTINUA-DB-SELECT-3 */
        public void M_0100_CONTINUA_DB_SELECT_3()
        {
            /*" -1585- EXEC SQL SELECT NUM_PARCELA INTO :PARCEVID-NUM-PARCELA FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_VENCIMENTO >= :SISTEMAS-DTCURINI AND DATA_VENCIMENTO <= :SISTEMAS-DTCURREN AND SIT_REGISTRO = '1' END-EXEC */

            var m_0100_CONTINUA_DB_SELECT_3_Query1 = new M_0100_CONTINUA_DB_SELECT_3_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                SISTEMAS_DTCURINI = SISTEMAS_DTCURINI.ToString(),
                SISTEMAS_DTCURREN = SISTEMAS_DTCURREN.ToString(),
            };

            var executed_1 = M_0100_CONTINUA_DB_SELECT_3_Query1.Execute(m_0100_CONTINUA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);
            }


        }

        [StopWatch]
        /*" M-0101-VERIFICA-SAF-LOTERICO */
        private void M_0101_VERIFICA_SAF_LOTERICO(bool isPerform = false)
        {
            /*" -1858- MOVE '0101-VERIF' TO PARAGRAFO. */
            _.Move("0101-VERIF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1859- MOVE 'NAO' TO WS-SAF-LOTERICO */
            _.Move("NAO", WS_WORK_AREAS.WS_SAF_LOTERICO);

            /*" -1862- MOVE 'SELECT APOL ' TO COMANDO. */
            _.Move("SELECT APOL ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1863- MOVE 17 TO W01-I */
            _.Move(17, FILLER_42.W01_I);

            /*" -1865- MOVE 'SELECT APOLICES' TO W01-TEXTO(W01-I) */
            _.Move("SELECT APOLICES", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -1869- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -1876- PERFORM M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1 */

            M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1();

            /*" -1880- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -1884- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -1885- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1886- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1888- END-IF. */
            }


            /*" -1890-  EVALUATE APOLICES-COD-PRODUTO  */

            /*" -1890-  WHEN 8114 */

            /*" -1890-  WHEN JVPROD(8114) */

            /*" -1891-  WHEN 8115 */

            /*" -1891-  WHEN JVPROD(8115) */

            /*" -1892-  WHEN 8116 */

            /*" -1892-  WHEN JVPROD(8116) */

            /*" -1893-  WHEN 8117 */

            /*" -1893-  WHEN JVPROD(8117) */

            /*" -1894-  WHEN 8118 */

            /*" -1894-  WHEN JVPROD(8118) */

            /*" -1897-  WHEN 8125  */

            /*" -1897-  WHEN 8119 */

            /*" -1897-  WHEN JVPROD(8119) */

            /*" -1898-  WHEN 8120 */

            /*" -1898-  WHEN JVPROD(8120) */

            /*" -1899-  WHEN 8121 */

            /*" -1899-  WHEN JVPROD(8121) */

            /*" -1900-  WHEN 8122 */

            /*" -1900-  WHEN JVPROD(8122) */

            /*" -1901-  WHEN 8123 */

            /*" -1901-  WHEN JVPROD(8123) */

            /*" -1905-  WHEN 8124  */

            /*" -1908-  WHEN 8132  */

            /*" -1911-  WHEN 8138  */

            /*" -1911-  WHEN 6901 */

            /*" -1911-  WHEN JVPROD(6901) */

            /*" -1912-  WHEN 6902 */

            /*" -1912-  WHEN JVPROD(6902) */

            /*" -1913-  WHEN 6903 */

            /*" -1913-  WHEN JVPROD(6903) */

            /*" -1914-  WHEN 6904 */

            /*" -1914-  WHEN JVPROD(6904) */

            /*" -1915-  WHEN 6905 */

            /*" -1915-  WHEN JVPROD(6905) */

            /*" -1916-  WHEN 6906 */

            /*" -1916-  WHEN JVPROD(6906) */

            /*" -1917-  WHEN 6907 */

            /*" -1917-  WHEN JVPROD(6907) */

            /*" -1918-  WHEN 6908 */

            /*" -1918-  WHEN JVPROD(6908) */

            /*" -1919-  WHEN 6909 */

            /*" -1919-  WHEN JVPROD(6909) */

            /*" -1920-  WHEN 6910 */

            /*" -1920-  WHEN JVPROD(6910) */

            /*" -1921-  WHEN 6911 */

            /*" -1921-  WHEN JVPROD(6911) */

            /*" -1922-  WHEN 6912 */

            /*" -1922-  WHEN JVPROD(6912) */

            /*" -1923-  WHEN 6913 */

            /*" -1923-  WHEN JVPROD(6913) */

            /*" -1924-  WHEN 6914 */

            /*" -1924-  WHEN JVPROD(6914) */

            /*" -1925-  WHEN 6915 */

            /*" -1925-  WHEN JVPROD(6915) */

            /*" -1926-  WHEN 6916 */

            /*" -1926-  WHEN JVPROD(6916) */

            /*" -1930-  WHEN 6917  */

            /*" -1931-  WHEN 6918  */

            /*" -1932-  WHEN 6919  */

            /*" -1933-  WHEN 6920  */

            /*" -1936-  WHEN 6921  */

            /*" -1936-  WHEN 8144 */

            /*" -1936-  WHEN JVPROD(8144) */

            /*" -1937-  WHEN 8145 */

            /*" -1937-  WHEN JVPROD(8145) */

            /*" -1938-  WHEN 8146 */

            /*" -1938-  WHEN JVPROD(8146) */

            /*" -1939-  WHEN 8147 */

            /*" -1939-  WHEN JVPROD(8147) */

            /*" -1940-  WHEN 8148 */

            /*" -1940-  WHEN JVPROD(8148) */

            /*" -1941-  WHEN 8149 */

            /*" -1941-  WHEN JVPROD(8149) */

            /*" -1942-  WHEN 8150 */

            /*" -1942-  WHEN JVPROD(8150) */

            /*" -1946-  WHEN 8530  */

            /*" -1947-  WHEN 8531  */

            /*" -1949-  WHEN 8532  */

            /*" -1949- IF   APOLICES-COD-PRODUTO EQUALS 8114 OR  JVPROD(8114)  OR  8115  OR  JVPROD(8115)  OR  8116  OR  JVPROD(8116)  OR  8117  OR  JVPROD(8117)  OR  8118  OR  JVPROD(8118)  OR  8125   OR  8119  OR  JVPROD(8119)  OR  8120  OR  JVPROD(8120)  OR  8121  OR  JVPROD(8121)  OR  8122  OR  JVPROD(8122)  OR  8123  OR  JVPROD(8123)  OR  8124   OR  8132   OR  8138   OR  6901  OR  JVPROD(6901)  OR  6902  OR  JVPROD(6902)  OR  6903  OR  JVPROD(6903)  OR  6904  OR  JVPROD(6904)  OR  6905  OR  JVPROD(6905)  OR  6906  OR  JVPROD(6906)  OR  6907  OR  JVPROD(6907)  OR  6908  OR  JVPROD(6908)  OR  6909  OR  JVPROD(6909)  OR  6910  OR  JVPROD(6910)  OR  6911  OR  JVPROD(6911)  OR  6912  OR  JVPROD(6912)  OR  6913  OR  JVPROD(6913)  OR  6914  OR  JVPROD(6914)  OR  6915  OR  JVPROD(6915)  OR  6916  OR  JVPROD(6916)  OR  6917   OR  6918   OR  6919   OR  6920   OR  6921   OR  8144  OR  JVPROD(8144)  OR  8145  OR  JVPROD(8145)  OR  8146  OR  JVPROD(8146)  OR  8147  OR  JVPROD(8147)  OR  8148  OR  JVPROD(8148)  OR  8149  OR  JVPROD(8149)  OR  8150  OR  JVPROD(8150)  OR  8530   OR  8531 OR  8532 */

            if (APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.In("8114", JVBKINCL.FILLER.JVPROD[8114].ToString(), "8115", JVBKINCL.FILLER.JVPROD[8115].ToString(), "8116", JVBKINCL.FILLER.JVPROD[8116].ToString(), "8117", JVBKINCL.FILLER.JVPROD[8117].ToString(), "8118", JVBKINCL.FILLER.JVPROD[8118].ToString(), "8125", "8119", JVBKINCL.FILLER.JVPROD[8119].ToString(), "8120", JVBKINCL.FILLER.JVPROD[8120].ToString(), "8121", JVBKINCL.FILLER.JVPROD[8121].ToString(), "8122", JVBKINCL.FILLER.JVPROD[8122].ToString(), "8123", JVBKINCL.FILLER.JVPROD[8123].ToString(), "8124", "8132", "8138", "6901", JVBKINCL.FILLER.JVPROD[6901].ToString(), "6902", JVBKINCL.FILLER.JVPROD[6902].ToString(), "6903", JVBKINCL.FILLER.JVPROD[6903].ToString(), "6904", JVBKINCL.FILLER.JVPROD[6904].ToString(), "6905", JVBKINCL.FILLER.JVPROD[6905].ToString(), "6906", JVBKINCL.FILLER.JVPROD[6906].ToString(), "6907", JVBKINCL.FILLER.JVPROD[6907].ToString(), "6908", JVBKINCL.FILLER.JVPROD[6908].ToString(), "6909", JVBKINCL.FILLER.JVPROD[6909].ToString(), "6910", JVBKINCL.FILLER.JVPROD[6910].ToString(), "6911", JVBKINCL.FILLER.JVPROD[6911].ToString(), "6912", JVBKINCL.FILLER.JVPROD[6912].ToString(), "6913", JVBKINCL.FILLER.JVPROD[6913].ToString(), "6914", JVBKINCL.FILLER.JVPROD[6914].ToString(), "6915", JVBKINCL.FILLER.JVPROD[6915].ToString(), "6916", JVBKINCL.FILLER.JVPROD[6916].ToString(), "6917", "6918", "6919", "6920", "6921", "8144", JVBKINCL.FILLER.JVPROD[8144].ToString(), "8145", JVBKINCL.FILLER.JVPROD[8145].ToString(), "8146", JVBKINCL.FILLER.JVPROD[8146].ToString(), "8147", JVBKINCL.FILLER.JVPROD[8147].ToString(), "8148", JVBKINCL.FILLER.JVPROD[8148].ToString(), "8149", JVBKINCL.FILLER.JVPROD[8149].ToString(), "8150", JVBKINCL.FILLER.JVPROD[8150].ToString(), "8530", "8531", "8532"))
            {

                /*" -1952- MOVE 'SS' TO PRODUVG-COD-PRODUTO-EA */
                _.Move("SS", PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA);

                /*" -1952-  WHEN 3701 */

                /*" -1952-  WHEN JVPROD(3701) */

                /*" -1953-  WHEN 3716 */

                /*" -1953-  WHEN JVPROD(3716) */

                /*" -1956-  WHEN 8105  */

                /*" -1956- ELSE IF   APOLICES-COD-PRODUTO EQUALS 3701 OR  JVPROD(3701)  OR  3716  OR  JVPROD(3716) OR  8105 */
            }
            else

            if (APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.In("3701", JVBKINCL.FILLER.JVPROD[3701].ToString(), "3716", JVBKINCL.FILLER.JVPROD[3716].ToString(), "8105"))
            {

                /*" -1958- MOVE 'S1' TO PRODUVG-COD-PRODUTO-EA */
                _.Move("S1", PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA);

                /*" -1960-  WHEN OTHER  */

                /*" -1960- ELSE */
            }
            else
            {


                /*" -1961- GO TO 0101-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0101_FIM*/ //GOTO
                return;

                /*" -1963-  END-EVALUATE  */

                /*" -1963- END-IF */
            }


            /*" -1965- MOVE 'SIM' TO WS-SAF-LOTERICO. */
            _.Move("SIM", WS_WORK_AREAS.WS_SAF_LOTERICO);

            /*" -1968- MOVE 'SELECT CLIEN' TO COMANDO. */
            _.Move("SELECT CLIEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1969- MOVE 18 TO W01-I */
            _.Move(18, FILLER_42.W01_I);

            /*" -1971- MOVE 'SELECT CLIENTES' TO W01-TEXTO(W01-I) */
            _.Move("SELECT CLIENTES", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -1975- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -1980- PERFORM M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_2 */

            M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_2();

            /*" -1984- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -1988- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -1989- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1990- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1992- END-IF */
            }


            /*" -1993- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1999- MOVE CLIENTES-CGCCPF TO FUNCIONA-NUM-CPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, FUNCIONA.DCLFUNCIONARIOS.FUNCIONA_NUM_CPF);

            /*" -2002- MOVE 'SELECT FUNC ' TO COMANDO. */
            _.Move("SELECT FUNC ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2003- MOVE 19 TO W01-I */
            _.Move(19, FILLER_42.W01_I);

            /*" -2005- MOVE 'SELECT FUNCIONARIOS' TO W01-TEXTO(W01-I) */
            _.Move("SELECT FUNCIONARIOS", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -2009- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -2014- PERFORM M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3 */

            M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3();

            /*" -2018- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -2025- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -2026- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -2027- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2028- GO TO 0101-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0101_FIM*/ //GOTO
                    return;

                    /*" -2029- ELSE */
                }
                else
                {


                    /*" -2030- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2031- END-IF */
                }


                /*" -2033- END-IF. */
            }


            /*" -2034- MOVE 'S2' TO PRODUVG-COD-PRODUTO-EA. */
            _.Move("S2", PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA);

            /*" -2035- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

        }

        [StopWatch]
        /*" M-0101-VERIFICA-SAF-LOTERICO-DB-SELECT-1 */
        public void M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1()
        {
            /*" -1876- EXEC SQL SELECT COD_PRODUTO, COD_CLIENTE INTO :APOLICES-COD-PRODUTO, :APOLICES-COD-CLIENTE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE END-EXEC. */

            var m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1 = new M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1.Execute(m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" M-0100-CONTINUA-DB-SELECT-4 */
        public void M_0100_CONTINUA_DB_SELECT_4()
        {
            /*" -1687- EXEC SQL SELECT CGCCPF, NOME_RAZAO, DATA_NASCIMENTO , TIPO_PESSOA INTO :CLIENTES-CGCCPF, :CLIENTES-NOME-RAZAO, :CLIENTES-DATA-NASCIMENTO:CLIENT-DTNASC-I , :CLIENTES-TIPO-PESSOA FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var m_0100_CONTINUA_DB_SELECT_4_Query1 = new M_0100_CONTINUA_DB_SELECT_4_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_0100_CONTINUA_DB_SELECT_4_Query1.Execute(m_0100_CONTINUA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
            }


        }

        [StopWatch]
        /*" M-0101-VERIFICA-SAF-LOTERICO-DB-SELECT-2 */
        public void M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_2()
        {
            /*" -1980- EXEC SQL SELECT CGCCPF INTO :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :APOLICES-COD-CLIENTE END-EXEC. */

            var m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_2_Query1 = new M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_2_Query1()
            {
                APOLICES_COD_CLIENTE = APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_2_Query1.Execute(m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0101_FIM*/

        [StopWatch]
        /*" M-0101-VERIFICA-SAF-LOTERICO-DB-SELECT-3 */
        public void M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3()
        {
            /*" -2014- EXEC SQL SELECT NOME_FUNCIONARIO INTO :FUNCIONA-NOME-FUNCIONARIO FROM SEGUROS.FUNCIONARIOS WHERE NUM_CPF = :FUNCIONA-NUM-CPF END-EXEC. */

            var m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1 = new M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1()
            {
                FUNCIONA_NUM_CPF = FUNCIONA.DCLFUNCIONARIOS.FUNCIONA_NUM_CPF.ToString(),
            };

            var executed_1 = M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1.Execute(m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCIONA_NOME_FUNCIONARIO, FUNCIONA.DCLFUNCIONARIOS.FUNCIONA_NOME_FUNCIONARIO);
            }


        }

        [StopWatch]
        /*" M-0100-CONTINUA-DB-SELECT-5 */
        public void M_0100_CONTINUA_DB_SELECT_5()
        {
            /*" -1735- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENTES-DATA-NASCIMENTO:CLIENT-DTNASC-I FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC */

            var m_0100_CONTINUA_DB_SELECT_5_Query1 = new M_0100_CONTINUA_DB_SELECT_5_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0100_CONTINUA_DB_SELECT_5_Query1.Execute(m_0100_CONTINUA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -2046- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2049- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2050- MOVE 20 TO W01-I */
            _.Move(20, FILLER_42.W01_I);

            /*" -2052- MOVE 'FETCH CPROPVA' TO W01-TEXTO(W01-I) */
            _.Move("FETCH CPROPVA", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -2056- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -2074- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -2078- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -2082- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -2083- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2084- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2085- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -2088- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -2089- MOVE 21 TO W01-I */
                    _.Move(21, FILLER_42.W01_I);

                    /*" -2091- MOVE 'CLOSE CPROPVA' TO W01-TEXTO(W01-I) */
                    _.Move("CLOSE CPROPVA", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

                    /*" -2095- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

                    R8000_TOTALIZA_INICIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


                    /*" -2095- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -2099- MOVE 1 TO W01-QTD-ACC-OK */
                    _.Move(1, FILLER_42.W01_QTD_ACC_OK);

                    /*" -2103- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

                    R8100_TOTALIZA_FINAL(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


                    /*" -2104- GO TO 0110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;

                    /*" -2105- ELSE */
                }
                else
                {


                    /*" -2106- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2107- END-IF */
                }


                /*" -2109- END-IF. */
            }


            /*" -2111- ADD 1 TO AC-LIDOS */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

            /*" -2112- IF PROPOVA-NUM-APOLICE EQUAL 109300000567 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300000567)
            {

                /*" -2113- MOVE '4' TO PROPOVA-SIT-REGISTRO */
                _.Move("4", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                /*" -2115- END-IF. */
            }


            /*" -2159- IF (PRODUVG-ORIG-PRODU EQUAL 'EMPRE' OR 'ESPEC' OR 'ESPE1' OR 'ESPE2' OR 'ESPE3' OR 'GLOBAL' ) AND PROPOVA-NUM-APOLICE NOT EQUAL 0108208874329 AND 0108210105792 AND 0108210933403 AND 0108211323063 AND 0108211323064 AND 0109300000672 AND 0109300000959 AND 0109300001350 AND 0109300001670 AND 0109300001819 AND 0109300002142 AND 0109300002585 AND 0109300002606 AND 0109300002675 AND 0109300002676 AND 0109300002677 AND 0109300002678 AND 0109300002679 AND 0109300002680 AND 0109300003432 AND 0109300004544 AND 0109300005270 AND 0109300006210 AND 3008208874329 AND 3008210933403 AND 3009300002678 AND 3009300012678 AND 3009300002679 AND 3009300012679 AND 3009300006730 AND 3009300007007 AND 3009300007147 AND 3009300007397 AND 3009300002680 AND 3009300012680 AND 3009300005270 AND 3009300006210 AND 3009320006210 AND 3008211398371 AND 3008211398372 AND 3009300007527 AND 3009300007528 */

            if ((PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.In("EMPRE", "ESPEC", "ESPE1", "ESPE2", "ESPE3", "GLOBAL")) && !PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("0108208874329", "0108210105792", "0108210933403", "0108211323063", "0108211323064", "0109300000672", "0109300000959", "0109300001350", "0109300001670", "0109300001819", "0109300002142", "0109300002585", "0109300002606", "0109300002675", "0109300002676", "0109300002677", "0109300002678", "0109300002679", "0109300002680", "0109300003432", "0109300004544", "0109300005270", "0109300006210", "3008208874329", "3008210933403", "3009300002678", "3009300012678", "3009300002679", "3009300012679", "3009300006730", "3009300007007", "3009300007147", "3009300007397", "3009300002680", "3009300012680", "3009300005270", "3009300006210", "3009320006210", "3008211398371", "3008211398372", "3009300007527", "3009300007528"))
            {

                /*" -2160- IF PROPOVA-DTPROXVEN NOT EQUAL '9999-12-31' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN != "9999-12-31")
                {

                    /*" -2161- GO TO 0110-FETCH */
                    new Task(() => M_0110_FETCH()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2162- END-IF */
                }


                /*" -2164- END-IF. */
            }


            /*" -2206- IF PROPOVA-NUM-APOLICE = 0108208874329 OR 3008208874329 OR 3008211398371 OR 0108210933403 OR 3008210933403 OR 3008211398372 OR 0108211323063 OR 0108211323064 OR 0109300000672 OR 0109300001670 OR 0109300001819 OR 0109300002142 OR 0109300002585 OR 0109300002606 OR 0109300002675 OR 0109300002676 OR 0109300002677 OR 0109300002678 OR 3009300002678 OR 3009300012678 OR 0109300002679 OR 3009300002679 OR 3009300012679 OR 3009300006730 OR 3009300007007 OR 3009300007147 OR 3009300007528 OR 3009300007397 OR 3009300007527 OR 0109300002680 OR 3009300002680 OR 3009300012680 OR 0109300003432 OR 0109300004544 OR 0109300005270 OR 3009300005270 OR 0109300006210 OR 3009300006210 OR 3009320006210 OR 0109300001670 OR 0109300001819 OR 0109300002142 OR 0109300002585 OR 0109300002606 OR 0109300002675 OR 0109300002676 OR 0109300002677 OR 0109300003432 OR 0109300004544 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("0108208874329", "3008208874329", "3008211398371", "0108210933403", "3008210933403", "3008211398372", "0108211323063", "0108211323064", "0109300000672", "0109300001670", "0109300001819", "0109300002142", "0109300002585", "0109300002606", "0109300002675", "0109300002676", "0109300002677", "0109300002678", "3009300002678", "3009300012678", "0109300002679", "3009300002679", "3009300012679", "3009300006730", "3009300007007", "3009300007147", "3009300007528", "3009300007397", "3009300007527", "0109300002680", "3009300002680", "3009300012680", "0109300003432", "0109300004544", "0109300005270", "3009300005270", "0109300006210", "3009300006210", "3009320006210", "0109300001670", "0109300001819", "0109300002142", "0109300002585", "0109300002606", "0109300002675", "0109300002676", "0109300002677", "0109300003432", "0109300004544"))
            {

                /*" -2207- IF PROPOVA-DTPROXVEN EQUAL '9999-12-31' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN == "9999-12-31")
                {

                    /*" -2208- GO TO 0110-FETCH */
                    new Task(() => M_0110_FETCH()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2209- END-IF */
                }


                /*" -2211- END-IF. */
            }


            /*" -2213- ADD 1 TO AC-ACEITOS AC-CONTA */
            WS_WORK_AREAS.AC_ACEITOS.Value = WS_WORK_AREAS.AC_ACEITOS + 1;
            WS_WORK_AREAS.AC_CONTA.Value = WS_WORK_AREAS.AC_CONTA + 1;

            /*" -2214- IF AC-CONTA > 9999 */

            if (WS_WORK_AREAS.AC_CONTA > 9999)
            {

                /*" -2215- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WS_WORK_AREAS.AC_CONTA);

                /*" -2216- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -2221- DISPLAY 'LIDOS/GRAVADOS/HORA/CERTIFICADO: ' AC-ACEITOS '/' AC-REGISTROS '/' WS-TIME '/' PROPOVA-NUM-CERTIFICADO */

                $"LIDOS/GRAVADOS/HORA/CERTIFICADO: {WS_WORK_AREAS.AC_ACEITOS}/{WS_WORK_AREAS.AC_REGISTROS}/{WS_WORK_AREAS.WS_TIME}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -2221- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -2074- EXEC SQL FETCH CPROPVA INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-COD-CLIENTE, :PROPOVA-OCOREND, :ENDOSSOS-DATA-EMISSAO, :PROPOVA-DATA-QUITACAO, :PROPVA-DTQIT10A, :PROPOVA-SIT-REGISTRO, :PROPOVA-DTPROXVEN, :PROPOVA-COD-PRODUTO, :PRODUVG-COD-PRODUTO-EA:PRODVG-ICODPRODEA, :PRODUVG-OPCAO-PAGAMENTO, :PRODUVG-PERI-PAGAMENTO, :PRODUVG-ORIG-PRODU END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CPROPVA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CPROPVA.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(CPROPVA.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(CPROPVA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CPROPVA.PROPVA_DTQIT10A, PROPVA_DTQIT10A);
                _.Move(CPROPVA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(CPROPVA.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(CPROPVA.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(CPROPVA.PRODUVG_COD_PRODUTO_EA, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA);
                _.Move(CPROPVA.PRODVG_ICODPRODEA, PRODVG_ICODPRODEA);
                _.Move(CPROPVA.PRODUVG_OPCAO_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO);
                _.Move(CPROPVA.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CPROPVA.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -2095- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0100-CONTINUA-DB-SELECT-6 */
        public void M_0100_CONTINUA_DB_SELECT_6()
        {
            /*" -1799- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, TELEFONE, DDD INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, :ENDERECO-TELEFONE, :ENDERECO-DDD FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var m_0100_CONTINUA_DB_SELECT_6_Query1 = new M_0100_CONTINUA_DB_SELECT_6_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            var executed_1 = M_0100_CONTINUA_DB_SELECT_6_Query1.Execute(m_0100_CONTINUA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0200-INSERT-REPSAF */
        private void M_0200_INSERT_REPSAF(bool isPerform = false)
        {
            /*" -2234- MOVE '0200-SELECT-REPSAF' TO PARAGRAFO. */
            _.Move("0200-SELECT-REPSAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2237- MOVE 'SELECT MOVIMENTO_EA' TO COMANDO. */
            _.Move("SELECT MOVIMENTO_EA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2238- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2242- MOVE 22 TO W01-I */
            _.Move(22, FILLER_42.W01_I);

            /*" -2244- MOVE 'SELECT MOVIMENTO_EA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT MOVIMENTO_EA", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -2248- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -2254- PERFORM M_0200_INSERT_REPSAF_DB_SELECT_1 */

            M_0200_INSERT_REPSAF_DB_SELECT_1();

            /*" -2258- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -2262- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -2264- IF SQLCODE EQUAL ZEROS OR SQLCODE EQUAL -811 */

            if (DB.SQLCODE == 00 || DB.SQLCODE == -811)
            {

                /*" -2266- DISPLAY 'VA1471B - CERTIFICADO EXISTE MOVIMENTO_EA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"VA1471B - CERTIFICADO EXISTE MOVIMENTO_EA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2268- DISPLAY 'NSAS........................... ' CONARQEA-NSAS */
                _.Display($"NSAS........................... {CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS}");

                /*" -2270- DISPLAY 'MOVIMEA-TIPO-MOVIMENTO......... ' MOVIMEA-TIPO-MOVIMENTO */
                _.Display($"MOVIMEA-TIPO-MOVIMENTO......... {MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO}");

                /*" -2272- GO TO 0200-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/ //GOTO
                return;
            }


            /*" -2273- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -2276- MOVE '0200-INSERT-REPSAF' TO PARAGRAFO. */
            _.Move("0200-INSERT-REPSAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2279- MOVE 'INSERT MOVIMENTO_EA' TO COMANDO. */
            _.Move("INSERT MOVIMENTO_EA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2280- MOVE 23 TO W01-I */
            _.Move(23, FILLER_42.W01_I);

            /*" -2282- MOVE 'INSERT MOVIMENTO_EA' TO W01-TEXTO(W01-I) */
            _.Move("INSERT MOVIMENTO_EA", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -2286- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -2293- PERFORM M_0200_INSERT_REPSAF_DB_INSERT_1 */

            M_0200_INSERT_REPSAF_DB_INSERT_1();

            /*" -2297- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -2301- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -2302- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2303- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2305- END-IF */
            }


            /*" -2306- WRITE REPSAF-RECORD FROM DETAIL-RECORD. */
            _.Move(DETAIL_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

            /*" -2307- ADD 1 TO AC-REGISTROS. */
            WS_WORK_AREAS.AC_REGISTROS.Value = WS_WORK_AREAS.AC_REGISTROS + 1;

            /*" -2307- PERFORM 0201-ATUALIZA-ASSIST THRU 0201-FIM. */

            M_0201_ATUALIZA_ASSIST(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0201_FIM*/


        }

        [StopWatch]
        /*" M-0200-INSERT-REPSAF-DB-SELECT-1 */
        public void M_0200_INSERT_REPSAF_DB_SELECT_1()
        {
            /*" -2254- EXEC SQL SELECT TIPO_MOVIMENTO INTO :MOVIMEA-TIPO-MOVIMENTO FROM SEGUROS.MOVIMENTO_EA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NSAS = :CONARQEA-NSAS END-EXEC. */

            var m_0200_INSERT_REPSAF_DB_SELECT_1_Query1 = new M_0200_INSERT_REPSAF_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                CONARQEA_NSAS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.ToString(),
            };

            var executed_1 = M_0200_INSERT_REPSAF_DB_SELECT_1_Query1.Execute(m_0200_INSERT_REPSAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMEA_TIPO_MOVIMENTO, MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" M-0200-INSERT-REPSAF-DB-INSERT-1 */
        public void M_0200_INSERT_REPSAF_DB_INSERT_1()
        {
            /*" -2293- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_EA VALUES (:PROPOVA-NUM-CERTIFICADO, :CONARQEA-NSAS, :MOVIMEA-TIPO-MOVIMENTO, 'VA1471B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1 = new M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                CONARQEA_NSAS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.ToString(),
                MOVIMEA_TIPO_MOVIMENTO = MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO.ToString(),
            };

            M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1.Execute(m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-0201-ATUALIZA-ASSIST */
        private void M_0201_ATUALIZA_ASSIST(bool isPerform = false)
        {
            /*" -2318- EVALUATE DET-CODPRODEA */
            switch (DETAIL_RECORD.DET_CODPRODEA.Value.Trim())
            {

                /*" -2320- WHEN 'S1' */
                case "S1":

                    /*" -2321- IF DET-TIPO-MOV EQUAL 'IN' */

                    if (DETAIL_RECORD.DET_TIPO_MOV == "IN")
                    {

                        /*" -2322- ADD 1 TO AC-INS-S1 */
                        WS_WORK_AREAS.AC_INS_S1.Value = WS_WORK_AREAS.AC_INS_S1 + 1;

                        /*" -2323- ELSE */
                    }
                    else
                    {


                        /*" -2324- IF DET-TIPO-MOV EQUAL 'AL' */

                        if (DETAIL_RECORD.DET_TIPO_MOV == "AL")
                        {

                            /*" -2325- ADD 1 TO AC-ALT-S1 */
                            WS_WORK_AREAS.AC_ALT_S1.Value = WS_WORK_AREAS.AC_ALT_S1 + 1;

                            /*" -2326- ELSE */
                        }
                        else
                        {


                            /*" -2327- IF DET-TIPO-MOV EQUAL 'EX' */

                            if (DETAIL_RECORD.DET_TIPO_MOV == "EX")
                            {

                                /*" -2328- ADD 1 TO AC-EXC-S1 */
                                WS_WORK_AREAS.AC_EXC_S1.Value = WS_WORK_AREAS.AC_EXC_S1 + 1;

                                /*" -2329- END-IF */
                            }


                            /*" -2330- END-IF */
                        }


                        /*" -2332- END-IF */
                    }


                    /*" -2335- WHEN 'SS' */
                    break;
                case "SS":

                    /*" -2336- IF DET-TIPO-MOV EQUAL 'IN' */

                    if (DETAIL_RECORD.DET_TIPO_MOV == "IN")
                    {

                        /*" -2337- ADD 1 TO AC-INS-SS */
                        WS_WORK_AREAS.AC_INS_SS.Value = WS_WORK_AREAS.AC_INS_SS + 1;

                        /*" -2338- ELSE */
                    }
                    else
                    {


                        /*" -2339- IF DET-TIPO-MOV EQUAL 'AL' */

                        if (DETAIL_RECORD.DET_TIPO_MOV == "AL")
                        {

                            /*" -2340- ADD 1 TO AC-ALT-SS */
                            WS_WORK_AREAS.AC_ALT_SS.Value = WS_WORK_AREAS.AC_ALT_SS + 1;

                            /*" -2341- ELSE */
                        }
                        else
                        {


                            /*" -2342- IF DET-TIPO-MOV EQUAL 'EX' */

                            if (DETAIL_RECORD.DET_TIPO_MOV == "EX")
                            {

                                /*" -2343- ADD 1 TO AC-EXC-SS */
                                WS_WORK_AREAS.AC_EXC_SS.Value = WS_WORK_AREAS.AC_EXC_SS + 1;

                                /*" -2344- END-IF */
                            }


                            /*" -2345- END-IF */
                        }


                        /*" -2347- END-IF */
                    }


                    /*" -2350- WHEN 'S2' */
                    break;
                case "S2":

                    /*" -2351- IF DET-TIPO-MOV EQUAL 'IN' */

                    if (DETAIL_RECORD.DET_TIPO_MOV == "IN")
                    {

                        /*" -2352- ADD 1 TO AC-INS-S2 */
                        WS_WORK_AREAS.AC_INS_S2.Value = WS_WORK_AREAS.AC_INS_S2 + 1;

                        /*" -2353- ELSE */
                    }
                    else
                    {


                        /*" -2354- IF DET-TIPO-MOV EQUAL 'AL' */

                        if (DETAIL_RECORD.DET_TIPO_MOV == "AL")
                        {

                            /*" -2355- ADD 1 TO AC-ALT-S2 */
                            WS_WORK_AREAS.AC_ALT_S2.Value = WS_WORK_AREAS.AC_ALT_S2 + 1;

                            /*" -2356- ELSE */
                        }
                        else
                        {


                            /*" -2357- IF DET-TIPO-MOV EQUAL 'EX' */

                            if (DETAIL_RECORD.DET_TIPO_MOV == "EX")
                            {

                                /*" -2358- ADD 1 TO AC-EXC-S2 */
                                WS_WORK_AREAS.AC_EXC_S2.Value = WS_WORK_AREAS.AC_EXC_S2 + 1;

                                /*" -2359- END-IF */
                            }


                            /*" -2360- END-IF */
                        }


                        /*" -2362- END-IF */
                    }


                    /*" -2363- WHEN OTHER */
                    break;
                default:

                    /*" -2364- ADD 1 TO AC-CODPRODEA-NOK */
                    WS_WORK_AREAS.AC_CODPRODEA_NOK.Value = WS_WORK_AREAS.AC_CODPRODEA_NOK + 1;

                    /*" -2367- DISPLAY '-> COD_PRODUTO_EA <' DET-CODPRODEA 'INVALIDO. CODIGOS VALIDOS <S1,S2,SS>' */

                    $"-> COD_PRODUTO_EA <{DETAIL_RECORD.DET_CODPRODEA}INVALIDO. CODIGOS VALIDOS <S1,S2,SS>"
                    .Display();

                    /*" -2367- END-EVALUATE. */
                    break;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0201_FIM*/

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -2379- PERFORM 9001-GERA-ARQ-ASSIST THRU 9001-FIM. */

            M_9001_GERA_ARQ_ASSIST(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9001_FIM*/


            /*" -2382- CLOSE REPSAF RVA1471B. */
            REPSAF.Close();
            RVA1471B.Close();

            /*" -2383- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2385- DISPLAY ' ' */
            _.Display($" ");

            /*" -2386- IF WPAR-SIMULACAO = 'SIM' */

            if (REDEFINES.WPAR_SIMULACAO == "SIM")
            {

                /*" -2389- MOVE 'ROLLBACK' TO COMANDO */
                _.Move("ROLLBACK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2390- MOVE 24 TO W01-I */
                _.Move(24, FILLER_42.W01_I);

                /*" -2392- MOVE 'ROLLBACK FIM' TO W01-TEXTO(W01-I) */
                _.Move("ROLLBACK FIM", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

                /*" -2396- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

                R8000_TOTALIZA_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


                /*" -2396- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2400- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_42.W01_QTD_ACC_OK);

                /*" -2404- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

                R8100_TOTALIZA_FINAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


                /*" -2406- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -2407- DISPLAY 'PARAMETRO DE SIMULACAO LIGADO' */
                _.Display($"PARAMETRO DE SIMULACAO LIGADO");

                /*" -2408- DISPLAY 'ROLLBACK EXECUTADO' */
                _.Display($"ROLLBACK EXECUTADO");

                /*" -2410- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -2411- DISPLAY ' ' */
                _.Display($" ");

                /*" -2413- DISPLAY '------------------------------------------------' '------------' */
                _.Display($"------------------------------------------------------------");

                /*" -2414- ELSE */
            }
            else
            {


                /*" -2417- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2418- MOVE 25 TO W01-I */
                _.Move(25, FILLER_42.W01_I);

                /*" -2420- MOVE 'COMMIT WORK' TO W01-TEXTO(W01-I) */
                _.Move("COMMIT WORK", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

                /*" -2424- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

                R8000_TOTALIZA_INICIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


                /*" -2424- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2428- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_42.W01_QTD_ACC_OK);

                /*" -2432- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

                R8100_TOTALIZA_FINAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


                /*" -2434- DISPLAY '------------------------------------------------' '------------' */
                _.Display($"------------------------------------------------------------");

                /*" -2435- DISPLAY 'COMMIT EXECUTADO' */
                _.Display($"COMMIT EXECUTADO");

                /*" -2437- END-IF */
            }


            /*" -2438- DISPLAY 'REGISTROS LIDOS NO CURSOR ... ' AC-LIDOS */
            _.Display($"REGISTROS LIDOS NO CURSOR ... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -2439- DISPLAY 'REGISTROS ACEITOS ........... ' AC-ACEITOS */
            _.Display($"REGISTROS ACEITOS ........... {WS_WORK_AREAS.AC_ACEITOS}");

            /*" -2440- DISPLAY 'REGISTROS ACEITOS BILHETE AP. ' AC-ACEITOS-BIL-AP */
            _.Display($"REGISTROS ACEITOS BILHETE AP. {WS_WORK_AREAS.AC_ACEITOS_BIL_AP}");

            /*" -2442- DISPLAY 'REGISTROS ACEITOS BIL MEI 8530: ' AC-ACEITOS-BIL-MEI-8530 */
            _.Display($"REGISTROS ACEITOS BIL MEI 8530: {WS_WORK_AREAS.AC_ACEITOS_BIL_MEI_8530}");

            /*" -2444- DISPLAY 'REGISTROS ACEITOS BIL MEI 8531: ' AC-ACEITOS-BIL-MEI-8531 */
            _.Display($"REGISTROS ACEITOS BIL MEI 8531: {WS_WORK_AREAS.AC_ACEITOS_BIL_MEI_8531}");

            /*" -2446- DISPLAY 'REGISTROS ACEITOS BIL MEI 8532: ' AC-ACEITOS-BIL-MEI-8532 */
            _.Display($"REGISTROS ACEITOS BIL MEI 8532: {WS_WORK_AREAS.AC_ACEITOS_BIL_MEI_8532}");

            /*" -2447- DISPLAY ' ' */
            _.Display($" ");

            /*" -2448- DISPLAY 'REG.DESPREZADOS PROD.INVALIDO ' AC-PRODUTO-NOK */
            _.Display($"REG.DESPREZADOS PROD.INVALIDO {WS_WORK_AREAS.AC_PRODUTO_NOK}");

            /*" -2449- DISPLAY 'COD_PRODUTO_EA INVALIDOS .... ' AC-CODPRODEA-NOK */
            _.Display($"COD_PRODUTO_EA INVALIDOS .... {WS_WORK_AREAS.AC_CODPRODEA_NOK}");

            /*" -2450- DISPLAY ' ' */
            _.Display($" ");

            /*" -2451- DISPLAY 'INCLUIDOS ................... ' AC-INCLUIDOS */
            _.Display($"INCLUIDOS ................... {WS_WORK_AREAS.AC_INCLUIDOS}");

            /*" -2452- DISPLAY 'ALTERADOS ................... ' AC-ALTERADOS */
            _.Display($"ALTERADOS ................... {WS_WORK_AREAS.AC_ALTERADOS}");

            /*" -2453- DISPLAY 'EXCLUIDOS ................... ' AC-EXCLUIDOS */
            _.Display($"EXCLUIDOS ................... {WS_WORK_AREAS.AC_EXCLUIDOS}");

            /*" -2454- DISPLAY ' ' */
            _.Display($" ");

            /*" -2455- DISPLAY 'GRAVADOS NO ARQ REPSAF......  ' AC-REGISTROS */
            _.Display($"GRAVADOS NO ARQ REPSAF......  {WS_WORK_AREAS.AC_REGISTROS}");

            /*" -2456- DISPLAY 'GRAVADOS NO ARQ RESUMO......  ' AC-ASSIST */
            _.Display($"GRAVADOS NO ARQ RESUMO......  {WS_WORK_AREAS.AC_ASSIST}");

            /*" -2458- DISPLAY '---------------------------------------------------' '---------' */
            _.Display($"------------------------------------------------------------");

            /*" -2461- DISPLAY ' ' */
            _.Display($" ");

            /*" -2462- MOVE 26 TO W01-I */
            _.Move(26, FILLER_42.W01_I);

            /*" -2464- MOVE 'SET CURRENT TIMESTAMP FIN' TO W01-TEXTO(W01-I) */
            _.Move("SET CURRENT TIMESTAMP FIN", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -2468- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -2470- PERFORM M_9000_FINALIZA_DB_SET_1 */

            M_9000_FINALIZA_DB_SET_1();

            /*" -2474- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -2479- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -2480- MOVE 27 TO W01-I */
            _.Move(27, FILLER_42.W01_I);

            /*" -2482- MOVE 'SET CURRENT TIMESTAMP TOT' TO W01-TEXTO(W01-I) */
            _.Move("SET CURRENT TIMESTAMP TOT", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -2486- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -2489- PERFORM M_9000_FINALIZA_DB_SET_2 */

            M_9000_FINALIZA_DB_SET_2();

            /*" -2493- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -2497- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -2498- DISPLAY ' ' */
            _.Display($" ");

            /*" -2500- DISPLAY '---------------------------------------------------' '---------' */
            _.Display($"------------------------------------------------------------");

            /*" -2501- DISPLAY '- HORA INICIAL...: ' WS-TIMESTAMP-INI */
            _.Display($"- HORA INICIAL...: {WS_WORK_AREAS.WS_TIMESTAMP_INI}");

            /*" -2502- DISPLAY '- HORA TERMINO...: ' WS-TIMESTAMP-FIM */
            _.Display($"- HORA TERMINO...: {WS_WORK_AREAS.WS_TIMESTAMP_FIM}");

            /*" -2503- DISPLAY '- TEMPO DECORRIDO: ' WS-TIMESTAMP-TOT */
            _.Display($"- TEMPO DECORRIDO: {WS_WORK_AREAS.WS_TIMESTAMP_TOT}");

            /*" -2505- DISPLAY '---------------------------------------------------' '---------' */
            _.Display($"------------------------------------------------------------");

            /*" -2506- DISPLAY ' ' */
            _.Display($" ");

            /*" -2507- DISPLAY '*** VA1471B *** TERMINO NORMAL' */
            _.Display($"*** VA1471B *** TERMINO NORMAL");

            /*" -2507- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" M-9000-FINALIZA-DB-SET-1 */
        public void M_9000_FINALIZA_DB_SET_1()
        {
            /*" -2470- EXEC SQL SET :WS-TIMESTAMP-FIM = CURRENT TIMESTAMP END-EXEC */
            _.Move(_.CurrentDate(), WS_WORK_AREAS.WS_TIMESTAMP_FIM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9000-FINALIZA-DB-SET-2 */
        public void M_9000_FINALIZA_DB_SET_2()
        {
            /*" -2489- EXEC SQL SET :WS-TIMESTAMP-TOT = TIMESTAMP(:WS-TIMESTAMP-FIM) - TIMESTAMP(:WS-TIMESTAMP-INI) END-EXEC */
            _.Move(_.ToDateTime(WS_WORK_AREAS.WS_TIMESTAMP_FIM) - _.ToDateTime(WS_WORK_AREAS.WS_TIMESTAMP_INI), WS_WORK_AREAS.WS_TIMESTAMP_TOT);

        }

        [StopWatch]
        /*" M-9001-GERA-ARQ-ASSIST */
        private void M_9001_GERA_ARQ_ASSIST(bool isPerform = false)
        {
            /*" -2517- MOVE SISTEMAS-DATA-MOV-ABERTO TO W01DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_WORK_AREAS.W01DTSQL);

            /*" -2518- MOVE W01DDSQL TO WS-DIA-H. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.WS_DATA_H.WS_DIA_H);

            /*" -2519- MOVE W01MMSQL TO WS-MES-H. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.WS_DATA_H.WS_MES_H);

            /*" -2520- MOVE W01AASQL TO WS-ANO-H. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.WS_DATA_H.WS_ANO_H);

            /*" -2521- MOVE WS-DATA-H TO LR00-DATA. */
            _.Move(WS_WORK_AREAS.WS_DATA_H, TRAILLER_RECORD.LR00.LR00_DATA);

            /*" -2522- WRITE ASSIST-RECORD FROM LR00 */
            _.Move(TRAILLER_RECORD.LR00.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2524- ADD 1 TO AC-ASSIST. */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2525- WRITE ASSIST-RECORD FROM LR01 */
            _.Move(TRAILLER_RECORD.LR01.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2529- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2530- MOVE TB-COD-CONVENIO(1) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[1].TB_COD_CONVENIO, TRAILLER_RECORD.LR02.LR02_COD_CONVENIO);

            /*" -2531- MOVE TB-DES-CONVENIO(1) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[1].TB_DES_CONVENIO, TRAILLER_RECORD.LR02.LR02_DESCRICAO);

            /*" -2532- MOVE AC-INS-S1 TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_INS_S1, TRAILLER_RECORD.LR02.LR02_QUANTIDADE);

            /*" -2533- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, TRAILLER_RECORD.LR02.LR02_TIPO);

            /*" -2534- WRITE ASSIST-RECORD FROM LR02 */
            _.Move(TRAILLER_RECORD.LR02.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2536- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2537- MOVE TB-COD-CONVENIO(1) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[1].TB_COD_CONVENIO, TRAILLER_RECORD.LR02.LR02_COD_CONVENIO);

            /*" -2538- MOVE TB-DES-CONVENIO(1) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[1].TB_DES_CONVENIO, TRAILLER_RECORD.LR02.LR02_DESCRICAO);

            /*" -2539- MOVE AC-ALT-S1 TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_ALT_S1, TRAILLER_RECORD.LR02.LR02_QUANTIDADE);

            /*" -2540- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, TRAILLER_RECORD.LR02.LR02_TIPO);

            /*" -2541- WRITE ASSIST-RECORD FROM LR02 */
            _.Move(TRAILLER_RECORD.LR02.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2543- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2544- MOVE TB-COD-CONVENIO(1) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[1].TB_COD_CONVENIO, TRAILLER_RECORD.LR02.LR02_COD_CONVENIO);

            /*" -2545- MOVE TB-DES-CONVENIO(1) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[1].TB_DES_CONVENIO, TRAILLER_RECORD.LR02.LR02_DESCRICAO);

            /*" -2546- MOVE AC-EXC-S1 TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EXC_S1, TRAILLER_RECORD.LR02.LR02_QUANTIDADE);

            /*" -2547- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, TRAILLER_RECORD.LR02.LR02_TIPO);

            /*" -2548- WRITE ASSIST-RECORD FROM LR02 */
            _.Move(TRAILLER_RECORD.LR02.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2552- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2553- MOVE TB-COD-CONVENIO(2) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[2].TB_COD_CONVENIO, TRAILLER_RECORD.LR02.LR02_COD_CONVENIO);

            /*" -2554- MOVE TB-DES-CONVENIO(2) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[2].TB_DES_CONVENIO, TRAILLER_RECORD.LR02.LR02_DESCRICAO);

            /*" -2555- MOVE AC-INS-SS TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_INS_SS, TRAILLER_RECORD.LR02.LR02_QUANTIDADE);

            /*" -2556- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, TRAILLER_RECORD.LR02.LR02_TIPO);

            /*" -2557- WRITE ASSIST-RECORD FROM LR02 */
            _.Move(TRAILLER_RECORD.LR02.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2559- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2560- MOVE TB-COD-CONVENIO(2) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[2].TB_COD_CONVENIO, TRAILLER_RECORD.LR02.LR02_COD_CONVENIO);

            /*" -2561- MOVE TB-DES-CONVENIO(2) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[2].TB_DES_CONVENIO, TRAILLER_RECORD.LR02.LR02_DESCRICAO);

            /*" -2562- MOVE AC-ALT-SS TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_ALT_SS, TRAILLER_RECORD.LR02.LR02_QUANTIDADE);

            /*" -2563- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, TRAILLER_RECORD.LR02.LR02_TIPO);

            /*" -2564- WRITE ASSIST-RECORD FROM LR02 */
            _.Move(TRAILLER_RECORD.LR02.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2566- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2567- MOVE TB-COD-CONVENIO(2) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[2].TB_COD_CONVENIO, TRAILLER_RECORD.LR02.LR02_COD_CONVENIO);

            /*" -2568- MOVE TB-DES-CONVENIO(2) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[2].TB_DES_CONVENIO, TRAILLER_RECORD.LR02.LR02_DESCRICAO);

            /*" -2569- MOVE AC-EXC-SS TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EXC_SS, TRAILLER_RECORD.LR02.LR02_QUANTIDADE);

            /*" -2570- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, TRAILLER_RECORD.LR02.LR02_TIPO);

            /*" -2571- WRITE ASSIST-RECORD FROM LR02 */
            _.Move(TRAILLER_RECORD.LR02.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2575- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2576- MOVE TB-COD-CONVENIO(3) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[3].TB_COD_CONVENIO, TRAILLER_RECORD.LR02.LR02_COD_CONVENIO);

            /*" -2577- MOVE TB-DES-CONVENIO(3) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[3].TB_DES_CONVENIO, TRAILLER_RECORD.LR02.LR02_DESCRICAO);

            /*" -2578- MOVE AC-INS-S2 TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_INS_S2, TRAILLER_RECORD.LR02.LR02_QUANTIDADE);

            /*" -2579- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, TRAILLER_RECORD.LR02.LR02_TIPO);

            /*" -2580- WRITE ASSIST-RECORD FROM LR02 */
            _.Move(TRAILLER_RECORD.LR02.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2582- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2583- MOVE TB-COD-CONVENIO(3) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[3].TB_COD_CONVENIO, TRAILLER_RECORD.LR02.LR02_COD_CONVENIO);

            /*" -2584- MOVE TB-DES-CONVENIO(3) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[3].TB_DES_CONVENIO, TRAILLER_RECORD.LR02.LR02_DESCRICAO);

            /*" -2585- MOVE AC-ALT-S2 TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_ALT_S2, TRAILLER_RECORD.LR02.LR02_QUANTIDADE);

            /*" -2586- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, TRAILLER_RECORD.LR02.LR02_TIPO);

            /*" -2587- WRITE ASSIST-RECORD FROM LR02 */
            _.Move(TRAILLER_RECORD.LR02.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2589- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -2590- MOVE TB-COD-CONVENIO(3) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[3].TB_COD_CONVENIO, TRAILLER_RECORD.LR02.LR02_COD_CONVENIO);

            /*" -2591- MOVE TB-DES-CONVENIO(3) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_7[3].TB_DES_CONVENIO, TRAILLER_RECORD.LR02.LR02_DESCRICAO);

            /*" -2592- MOVE AC-EXC-S2 TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EXC_S2, TRAILLER_RECORD.LR02.LR02_QUANTIDADE);

            /*" -2593- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, TRAILLER_RECORD.LR02.LR02_TIPO);

            /*" -2594- WRITE ASSIST-RECORD FROM LR02 */
            _.Move(TRAILLER_RECORD.LR02.GetMoveValues(), ASSIST_RECORD);

            RVA1471B.Write(ASSIST_RECORD.GetMoveValues().ToString());

            /*" -2594- ADD 1 TO AC-ASSIST. */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9001_FIM*/

        [StopWatch]
        /*" R8000-TOTALIZA-INICIO */
        private void R8000_TOTALIZA_INICIO(bool isPerform = false)
        {
            /*" -2609- INITIALIZE W01-QTD-ACC-OK W01-QTD-ACC-NOK */
            _.Initialize(
                FILLER_42.W01_QTD_ACC_OK
                , FILLER_42.W01_QTD_ACC_NOK
            );

            /*" -2610- MOVE FUNCTION CURRENT-DATE TO W01-CURRENT-DATE */
            _.Move(_.CurrentDate(), FILLER_42.W01_CURRENT_DATE);

            /*" -2613- COMPUTE W01-SEG-INI = (W01-CDTE-HORA * 60 * 60) + (W01-CDTE-MIN * 60) + W01-CDTE-SEG + (W01-CDTE-DECSEG / 100) */
            FILLER_42.W01_SEG_INI.Value = (FILLER_42.W01_CURRENT_DATE.W01_CDTE_HORA * 60 * 60) + (FILLER_42.W01_CURRENT_DATE.W01_CDTE_MIN * 60) + FILLER_42.W01_CURRENT_DATE.W01_CDTE_SEG + (FILLER_42.W01_CURRENT_DATE.W01_CDTE_DECSEG / 100f);

            /*" -2613- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/

        [StopWatch]
        /*" R8100-TOTALIZA-FINAL */
        private void R8100_TOTALIZA_FINAL(bool isPerform = false)
        {
            /*" -2621- ADD W01-QTD-ACC-OK TO W01-TOT-ACC-OK(W01-I) */
            FILLER_42.W01_TABELA_TOTAIS.W01_TOT_ACC_OK[FILLER_42.W01_I].Value = FILLER_42.W01_TABELA_TOTAIS.W01_TOT_ACC_OK[FILLER_42.W01_I] + FILLER_42.W01_QTD_ACC_OK;

            /*" -2624- ADD W01-QTD-ACC-NOK TO W01-TOT-ACC-NOK(W01-I) */
            FILLER_42.W01_TABELA_TOTAIS.W01_TOT_ACC_NOK[FILLER_42.W01_I].Value = FILLER_42.W01_TABELA_TOTAIS.W01_TOT_ACC_NOK[FILLER_42.W01_I] + FILLER_42.W01_QTD_ACC_NOK;

            /*" -2625- MOVE FUNCTION CURRENT-DATE TO W01-CURRENT-DATE */
            _.Move(_.CurrentDate(), FILLER_42.W01_CURRENT_DATE);

            /*" -2628- COMPUTE W01-SEG-FIN = (W01-CDTE-HORA * 60 * 60) + (W01-CDTE-MIN * 60) + W01-CDTE-SEG + (W01-CDTE-DECSEG / 100) */
            FILLER_42.W01_SEG_FIN.Value = (FILLER_42.W01_CURRENT_DATE.W01_CDTE_HORA * 60 * 60) + (FILLER_42.W01_CURRENT_DATE.W01_CDTE_MIN * 60) + FILLER_42.W01_CURRENT_DATE.W01_CDTE_SEG + (FILLER_42.W01_CURRENT_DATE.W01_CDTE_DECSEG / 100f);

            /*" -2630- SUBTRACT W01-SEG-INI FROM W01-SEG-FIN */
            FILLER_42.W01_SEG_FIN.Value = FILLER_42.W01_SEG_FIN - FILLER_42.W01_SEG_INI;

            /*" -2631- ADD W01-SEG-FIN TO W01-TOT-TIME(W01-I) */
            FILLER_42.W01_TABELA_TOTAIS.W01_TOT_TIME[FILLER_42.W01_I].Value = FILLER_42.W01_TABELA_TOTAIS.W01_TOT_TIME[FILLER_42.W01_I] + FILLER_42.W01_SEG_FIN;

            /*" -2631- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/

        [StopWatch]
        /*" R8200-MOSTRA-TOTALIZADORES */
        private void R8200_MOSTRA_TOTALIZADORES(bool isPerform = false)
        {
            /*" -2642- DISPLAY ' ' */
            _.Display($" ");

            /*" -2643- DISPLAY '--> R8200-MOSTRA-TOTALIZADORES:' */
            _.Display($"--> R8200-MOSTRA-TOTALIZADORES:");

            /*" -2645- DISPLAY '==================================================' '===============================' */
            _.Display($"=================================================================================");

            /*" -2647- DISPLAY '      TOTALIZACAO                                 ' 'EXECUTADOS' */
            _.Display($"      TOTALIZACAO                                 EXECUTADOS");

            /*" -2649- DISPLAY '   TOTAIS                               QTD OK   T' 'EMPO(SEG)           OC' */
            _.Display($"   TOTAIS                               QTD OK   TEMPO(SEG)           OC");

            /*" -2651- DISPLAY '----------------------------------- ---------- ---' '----------   -----------' */
            _.Display($"----------------------------------- ---------- -------------   -----------");

            /*" -2653- DISPLAY 'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX   00.000.000   0' '0.000.000   (000000000)' */
            _.Display($"XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX   00.000.000   00.000.000   (000000000)");

            /*" -2656- DISPLAY '==================================================' '===============================' */
            _.Display($"=================================================================================");

            /*" -2658- PERFORM VARYING W01-I FROM 1 BY 1 UNTIL W01-I > W01-LIM-OCOR */

            for (FILLER_42.W01_I.Value = 1; !(FILLER_42.W01_I > FILLER_42.W01_LIM_OCOR); FILLER_42.W01_I.Value += 1)
            {

                /*" -2659-  EVALUATE TRUE  */

                /*" -2660-  WHEN W01-TEXTO(W01-I) NOT = LOW-VALUES AND SPACES  */

                /*" -2660- IF W01-TEXTO(W01-I) NOT = LOW-VALUES AND SPACES */

                if (FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO != "")
                {

                    /*" -2661- MOVE W01-TOT-ACC-OK(W01-I) TO W01-TOT-ACC-OK-ED */
                    _.Move(FILLER_42.W01_TABELA_TOTAIS.W01_TOT_ACC_OK[FILLER_42.W01_I], FILLER_42.W01_TOT_ACC_OK_ED);

                    /*" -2662- MOVE W01-TOT-TIME(W01-I) TO W01-TOT-TIME-ED */
                    _.Move(FILLER_42.W01_TABELA_TOTAIS.W01_TOT_TIME[FILLER_42.W01_I], FILLER_42.W01_TOT_TIME_ED);

                    /*" -2666- DISPLAY W01-TEXTO(W01-I) '  ' W01-TOT-ACC-OK-ED ' ' W01-TOT-TIME-ED '  (' W01-I ')' */

                    $"{FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I]}  {FILLER_42.W01_TOT_ACC_OK_ED} {FILLER_42.W01_TOT_TIME_ED}  ({FILLER_42.W01_I})"
                    .Display();

                    /*" -2667-  END-EVALUATE  */

                    /*" -2667- END-IF */
                }


                /*" -2669- END-PERFORM */
            }

            /*" -2671- DISPLAY '==================================================' '===============================' */
            _.Display($"=================================================================================");

            /*" -2672- DISPLAY ' ' */
            _.Display($" ");

            /*" -2672- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8200_MOSTRA_TOTALIZ_EXIT*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -2684- CLOSE REPSAF. */
            REPSAF.Close();

            /*" -2685- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2686- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -2687- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -2688- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -2689- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRMC);

            /*" -2691- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -2693- DISPLAY '*** VA1471B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA1471B *** ROLLBACK EM ANDAMENTO ...");

            /*" -2693- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2696- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2699- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2700- MOVE 28 TO W01-I */
            _.Move(28, FILLER_42.W01_I);

            /*" -2702- MOVE 'ROLLBACK WORK' TO W01-TEXTO(W01-I) */
            _.Move("ROLLBACK WORK", FILLER_42.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_42.W01_I].W01_TEXTO);

            /*" -2706- PERFORM R8000-TOTALIZA-INICIO THRU R8000-TOTALIZA-INICIO-EXIT */

            R8000_TOTALIZA_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_TOTALIZA_INICIO_EXIT*/


            /*" -2706- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2710- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_42.W01_QTD_ACC_OK);

            /*" -2715- PERFORM R8100-TOTALIZA-FINAL THRU R8100-TOTALIZA-FINAL-EXIT */

            R8100_TOTALIZA_FINAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_TOTALIZA_FINAL_EXIT*/


            /*" -2716- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2717- DISPLAY 'LIDOS ......................... ' AC-ACEITOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_ACEITOS}");

            /*" -2718- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2719- DISPLAY 'CERTIFICADO.. ' PROPOVA-NUM-CERTIFICADO */
            _.Display($"CERTIFICADO.. {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -2720- DISPLAY 'APOLICE ..... ' PROPOVA-NUM-APOLICE */
            _.Display($"APOLICE ..... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

            /*" -2721- DISPLAY 'SUBGRUPO .... ' PROPOVA-COD-SUBGRUPO */
            _.Display($"SUBGRUPO .... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

            /*" -2722- DISPLAY 'CLIENTE ..... ' PROPOVA-COD-CLIENTE */
            _.Display($"CLIENTE ..... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

            /*" -2723- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2725- DISPLAY '*** VA1471B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA1471B *** ERRO DE EXECUCAO");

            /*" -2728- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2732- PERFORM R8200-MOSTRA-TOTALIZADORES THRU R8200-MOSTRA-TOTALIZ-EXIT */

            R8200_MOSTRA_TOTALIZADORES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8200_MOSTRA_TOTALIZ_EXIT*/


            /*" -2732- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}