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
using Sias.VidaAzul.DB2.VA1476B;

namespace Code
{
    public class VA1476B
    {
        public bool IsCall { get; set; }

        public VA1476B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   FUNCAO .................  GERA ARQUIVO PARA A CAIXA          *      */
        /*"      *                             ASSISTENCIA - MULTIPREMIADO,       *      */
        /*"      *                                           SENIOR E             *      */
        /*"      *                                           VIDA MULHER.         *      */
        /*"      *                                                                *      */
        /*"      *                   ***************************************      *      */
        /*"      *                   *******   C A R G A    D I A R I A ****      *      */
        /*"      *                   ***************************************      *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FAST COMPUTER.                     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA1476B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  NOV/2008                           *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS .................  17.910                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   APOLICE        SUBGR   FARM   RESID  VIAG   NUTR  R.PROF UNIV*      */
        /*"      *                                                                *      */
        /*"      *   0097010000889   3603          X      X                       *      */
        /*"      *   0097010000889   4150          X      X                       *      */
        /*"      *   0097010000889   4190          X      X                       *      */
        /*"      *   0109300000550  TODOS          X      X                       *      */
        /*"      *   0109300001394  TODOS          X      X                       *      */
        /*"      *   0097010000889   1950          X      X                       *      */
        /*"      *   0109300000909  TODOS   X      X             X                *      */
        /*"      *   0109300000709  TODOS   X      X             X                *      */
        /*"      *   0109300001311  TODOS   X      X             X                *      */
        /*"      *   0109300001393  TODOS   X      X             X                *      */
        /*"      *   0109300001392  TODOS   X      X             X                *      */
        /*"      *V010109300000598  TODOS          X      X                       *      */
        /*"      *=  0109300001294  TODOS          X      X                       *      */
        /*"      *=  0109300001391  TODOS          X      X                       *      */
        /*"      *=  0109300001679  TODOS          X      X                       *      */
        /*"      *=  0109300001680  TODOS          X      X                       *      */
        /*"      *=  0109300000559  TODOS          X      X                       *      */
        /*"      *=  0109300001553  TODOS          X      X                       *      */
        /*"      *=  0109300001575  TODOS          X      X                       *      */
        /*"      *                                                                *      */
        /*"      *   0109300002001  TODOS       X      X                          *      */
        /*"      *   0109300002002  TODOS       X      X                          *      */
        /*"      *   0109300002003  TODOS       X      X                          *      */
        /*"      *   0109300001966  TODOS       X      X                          *      */
        /*"      *   0109300001970  TODOS       X      X                          *      */
        /*"      *   0109300001971  TODOS       X      X                          *      */
        /*"      *   0109300002004  TODOS  X    X           X                     *      */
        /*"      *   0109300002005  TODOS  X    X           X                     *      */
        /*"      *   0109300002006  TODOS  X    X           X                     *      */
        /*"      *   0109300002007  TODOS  X    X           X                     *      */
        /*"      *   0109300002008  TODOS  X    X           X                     *      */
        /*"      *   0109300002010  TODOS  X    X           X                     *      */
        /*"      *   0109300001976  TODOS  X    X           X                     *      */
        /*"      *   0109300001977  TODOS  X    X           X                     *      */
        /*"      *   0109300001978  TODOS  X    X           X                     *      */
        /*"      *   0109300003691  TODOS  X    X           X                     *      */
        /*"      *   0109300003692  TODOS  X    X           X                     *      */
        /*"      *                                                                *      */
        /*"      *V03BILHETE        8103           X                              *      */
        /*"      *=  BILHETE        8201           X                    X         *      */
        /*"      *=  BILHETE        8202           X                    X         *      */
        /*"      *=  BILHETE        8102           X                    X         *      */
        /*"      *=  BILHETE        8104           X                    X         *      */
        /*"      *=  BILHETE        8108                         X      X         *      */
        /*"      *=  BILHETE        8112           X                    X         *      */
        /*"      *=  BILHETE        3709           X                    X         *      */
        /*"      *=  BILHETE        8114    X      X                    X         *      */
        /*"      *=  BILHETE        8115    X                           X         *      */
        /*"      *=  BILHETE        8116    X                           X         *      */
        /*"      *=  BILHETE        8117    X                           X         *      */
        /*"      *=  BILHETE        8118    X                           X         *      */
        /*"      *=  BILHETE        8119    X                           X         *      */
        /*"      *=  BILHETE        8120    X                           X         *      */
        /*"      *=  BILHETE        8121    X                           X         *      */
        /*"      *=  BILHETE        8122    X                           X         *      */
        /*"      *=  BILHETE        8123    X                           X         *      */
        /*"      *=  BILHETE        8124                                          *      */
        /*"      *=  BILHETE        8125                                          *      */
        /*"      *=  BILHETE        8132                                          *      */
        /*"      *=  BILHETE        8139                                          *      */
        /*"      *=  BILHETE        8126                  X                       *      */
        /*"      *=  BILHETE        8127                  X                       *      */
        /*"      *=  BILHETE        8128           X                              *      */
        /*"      *=  BILHETE        8138                                      X   *      */
        /*"V.41  *=  BILHETE        8521   X                                      *      */
        /*"V.41  *=  BILHETE        8528   X                                      *      */
        /*"V.41  *=  BILHETE        8529   X                                      *      */
        /*"V.42  *=  BILHETE        8529   X                                      *      */
        /*"V.54  *=  BILHETE        8533   X                                      *      */
        /*"V.54  *=  BILHETE        8534   X                                      *      */
        /*"V.49.1*=  BILHETE        8241                                          *      */
        /*"V.49.1*=  BILHETE        8242                                          *      */
        /*"V.49.1*=  CERTIFICADO    9381                                          *      */
        /*"V.52  *=  BILHETE        8241                                          *      */
        /*"V.52  *=  BILHETE        8242                                          *      */
        /*"V.52  *=  CERTIFICADO    9381                                          *      */
        /*"V.52  *=  CERTIFICADO    9382                                          *      */
        /*"V.52  *=  CERTIFICADO    9750                                          *      */
        /*"V.52  *=  CERTIFICADO    9751                                          *      */
        /*"V.52  *=  CERTIFICADO    9752                                          *      */
        /*"V.52  *=  BILHETE        8530                                          *      */
        /*"V.52  *=  BILHETE        8531                                          *      */
        /*"V.52  *=  BILHETE        8532                                          *      */
        /*"      ******************************************************************      */
        /*"V.54  *   VERSAO 54 - DEMANDA 538808                                   *      */
        /*"      *   OBJETIVO: ENVIAR ASSISTENCIA CEPR PARA OS PRODUTOS ABAIXO:   *      */
        /*"V.54  *    -> SEG ACIDENTES PESSOAIS BEM ESTAR (8533, 8534)            *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.53  *   VERSAO 53 - DEMANDA 525079                                   *      */
        /*"      *   OBJETIVO: ENVIAR ASSISTENCIA CEPR PARA OS PRODUTOS ABAIXO:   *      */
        /*"      *    -> CAIXA FACIL APOIO FAMILIA (8521)                         *      */
        /*"V.54  *    -> SEG ACIDENTES PESSOAIS BEM ESTAR (8528, 8529)            *      */
        /*"      *                                                                *      */
        /*"      *1)CAIXA FACIL APOIO FAMILIA -> 8521 -> CONVENIO X ARQUIVO MENSAL*      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *|CONVENIO   |CO|ASSISTENCIA       |ARQUIVO CAIXA ASSSIT        |T      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *|40000142243|02|SAF FAMILIAR      |Maamm.VA1492B.REPSAF.ENV.TXT|0      */
        /*"      *|40001262238|16|FARM              |Maamm.VA1475B.MFARMA.TXT    |0      */
        /*"      *|40000999981|81|CEPR              |Maamm.VA1475B.CEPR.TXT      |1      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *                                                                *      */
        /*"V.54  *2)SEG AP BEM-ESTAR -> 8528, 8529 -> CONVENIO X ARQUIVO MENSAL   *      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *|CONVENIO   |CO|ASSISTENCIA       |ARQUIVO CAIXA ASSSIT        |T      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *|40000142243|02|SAF FAMILIAR      |Maamm.VA1492B.REPSAF.ENV.TXT|0      */
        /*"      *|40001262238|16|FARM              |Maamm.VA1475B.MFARMA.TXT    |0      */
        /*"      *|40000999981|81|CEPR              |Maamm.VA1475B.CEPR.TXT      |1      */
        /*"      *|===========|==|==================|============================|=      */
        /*"      *                                                                *      */
        /*"      *3)PRODUTO X COBERTURAS/ASSITENCIAS:                             *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |Produto       |COD |Apolice      |Subg|Pgto. |Cober./Assist.| *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      * |CAIXA FACIL   |8521|3008199999998|8521|1     |02 SAF_F      | *      */
        /*"      * |APOIO FAMILIA |    |             |    |MES   |16 FARM       | *      */
        /*"      * |              |    |             |    |      |81 CEPR       | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"V.54  * |SEG ACIDENTES |8528|3008199999998|8528|12    |02 SAF_F      | *      */
        /*"      * |PESSOAIS BEM- |    |             |    |MESES |16 FARM       | *      */
        /*"      * |ESTAR PU 12M  |    |             |    |      |81 CEPR       | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"V.54  * |SEG ACIDENTES |8529|3008199999998|8529|36    |02 SAF_F      | *      */
        /*"      * |PESSOAIS BEM- |    |             |    |MESES |16 FARM       | *      */
        /*"      * |ESTAR PU 36M  |    |             |    |      |81 CEPR       | *      */
        /*"      * |==============|====|=============|====|======|==============| *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/02/2024 - ANSELMO SOUSA                                *      */
        /*"      *                                            PROCURE POR V.53    *      */
        /*"      ******************************************************************      */
        /*"V.52  *   VERSAO 52 - DEMANDA 484074 / TAREFA 553176                   *      */
        /*"      *   OBJETIVO: ENVIAR ASSISTENCIAS AOS NOVOS PRODUTOS ABAIXO:     *      */
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
        /*"V.52S *    - INCLUSAO DE OPCAO PARA SIMULACAO  (PROCURE POR V.52S)     *      */
        /*"V.52D *    - INCLUSAO DE MONITORACAO NO CODIGO (PROCURE POR V.52D)     *      */
        /*"V.52T *    - AJUSTES PARA REALIZACAO DE TESTES, POIS OS PRODUTOS EXECU-*      */
        /*"      *    VO NAO APARECERAM ARQUIVO (PROCURE POR V.52T)               *      */
        /*"V.52A *    - REVISAO DA ASSISTENCIA AMBIENTAL POR NAO ESTAR APARECENDO *      */
        /*"      *    NO ARQUIVO DE PRD. SOLICITANTE ELOISA EM 21/12/2023 NO TEAMS*      */
        /*"      *    DEMANDA 510565.                                             *      */
        /*"V.52R *    - REVISAO GERAL DO CODIGO FONTE                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/12/2023 - ANSELMO SOUSA                                *      */
        /*"      *                                            PROCURE POR V.52    *      */
        /*"      ******************************************************************      */
        /*"V.49.1* Vers�o 49.1 - Incidente 558979                                 *      */
        /*"      *                                                                *      */
        /*"      * - Rollback da V.52, V.51, V.50, devido erros na demanda 546164;*      */
        /*"      * - Inclusao de ajustes faltantes do arquivo AMBIENT.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/12/2023 - ANSELMO SOUSA/RAUL ROTTA                     *      */
        /*"      *                                            PROCURE POR V.49.1  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.49  * Vers�o 49 - Incidente 552701                                   *      */
        /*"      * Corre��o de Abend - incidente 552701                           *      */
        /*"      *                                                                *      */
        /*"      * 17/11/2023 - 00.58 - JPVAD07 - E0171476, VA1476B               *      */
        /*"      * SQLCODE: -811                                                  *      */
        /*"      *                                                                *      */
        /*"      * R0010-ERRO SELECT PARAMETROS                                   *      */
        /*"      * VA1476B    *** ERRO  EXEC SQL ***         SQLCODE =     811-   *      */
        /*"      * SQLERRD1 =     140-   SQLERRD2 =     000    SQLERRD2 = PA      *      */
        /*"      * RAGRAFO = R5200-00-SELECT-PARAM                                *      */
        /*"      * COMANDO   = SELECT PARAM                                       *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * Raul Basili Rotta - TER29882 - 17/11/2023                      *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"V.48  * VERSAO 48 - DEMANDA 510565                                     *      */
        /*"      * RAUL BASILI ROTTA                                              *      */
        /*"      * EM 22/09/2023                                                  *      */
        /*"      *                                                                *      */
        /*"      * Criar arquivo novo para nova Assist�ncia ESG                   *      */
        /*"      * Conv�nio (*provis�rio) - 40000536893                           *      */
        /*"      *---------------------------------------                         *      */
        /*"      * Conv�nio de PRODU��O   - 40000528999 ********                  *      */
        /*"      *---------------------------------------                         *      */
        /*"      * Conv�nio de Homologa��o- 40000537469                           *      */
        /*"      * C�digo da Cobertura -> 93 Assistencia Ambiental                *      */
        /*"      *                                                                *      */
        /*"      *-- Produto 8241  AP Mensal                                      *      */
        /*"      *-- Ap�lice Criada: 3008211398371                                *      */
        /*"      *                                                                *      */
        /*"      *-- Produto 8242  AP Antecipado                                  *      */
        /*"      *-- Ap�lice Criada: 3008211398372                                *      */
        /*"      *                                                                *      */
        /*"      *-- Produto 9381 VG Mensal                                       *      */
        /*"      *-- Ap�lice Criada: 3009300007527                                *      */
        /*"      *                                                                *      */
        /*"      *-- Produto 9382 AP Antecipado                                   *      */
        /*"      *-- Ap�lice Criada: 3009300007528                                *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"V.48  * Vers�o 48 - demanda 469807 e 469965                            *      */
        /*"      * Corre��o de arquivos di�rios - Ajuste para n�o ignorar cober 36*      */
        /*"      *                                Cesta Natalidade Plus           *      */
        /*"      * Raul Basili Rotta - TER29882 - 07/06/2023                      *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"V.47  * Vers�o 47 - demanda 469807 e 469965                            *      */
        /*"      * Corre��o de arquivos di�rios - Ajuste para n�o ignorar cober 36*      */
        /*"      *                                Cesta Natalidade Plus           *      */
        /*"      * Raul Basili Rotta - TER29882 - 07/06/2023                      *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"V.46  * Vers�o 46 - demanda 469965                                     *      */
        /*"      * Corre��o de arquivos di�rios - removido trecho que provocava   *      */
        /*"      *                                grava��o incorreta              *      */
        /*"      * Raul Basili Rotta - TER29882 - 31/05/2023                      *      */
        /*"      ******************************************************************      */
        /*"V.45  *                                                                *      */
        /*"      *   VERSAO 45 - DEMANDA 455038                                   *      */
        /*"      *                                                                *      */
        /*"      *    Inclusao das seguintes apolices no movimento diario:        *      */
        /*"      *                                                                *      */
        /*"      *           |=============|===|=========|========|====|          *      */
        /*"      *           |APOLICE      |SUB|SIT.SUBG |ASSIST. |PROD|          *      */
        /*"      *           |=============|===|=========|========|====|          *      */
        /*"      *           |3009300006739|001|CANCELADO|        |9386|          *      */
        /*"      *           |3009300006739|002|CANCELADO|        |    |          *      */
        /*"      *           |3009300006739|003|CANCELADO|        |    |          *      */
        /*"      *           |3009300006739|004|CANCELADO|        |    |          *      */
        /*"      *           |3009300006739|005|CANCELADO|        |    |          *      */
        /*"      *           |3009300006739|006|CANCELADO|        |    |          *      */
        /*"      *           |3009300006739|007|CANCELADO|        |    |          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |3009300006746|001|ATIVO    |49 SAF_E|9386|          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |3009300006773|001|CANCELADO|        |9386|          *      */
        /*"      *           |3009300006773|002|CANCELADO|        |    |          *      */
        /*"      *           |3009300006773|003|CANCELADO|        |    |          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |3009300006515|001|ATIVO    |37 RPC  |9386|          *      */
        /*"      *           |             |   |         |49 SAF_E|    |          *      */
        /*"      *           |             |   |         |51 OPS  |    |          *      */
        /*"      *           |             |   |         |75 NUTR |    |          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |0109300001980|004|CANCELADO|        |9311|          *      */
        /*"      *           |0109300001980|005|CANCELADO|        |    |          *      */
        /*"      *           |0109300001980|006|CANCELADO|        |    |          *      */
        /*"      *           |0109300001980|011|CANCELADO|        |    |          *      */
        /*"      *           |0109300001980|012|CANCELADO|        |    |          *      */
        /*"      *           |0109300001980|013|CANCELADO|        |    |          *      */
        /*"      *           |0109300001980|014|CANCELADO|        |    |          *      */
        /*"      *           |0109300001980|015|CANCELADO|        |    |          *      */
        /*"      *           |0109300001980|016|CANCELADO|        |    |          *      */
        /*"      *           |0109300001980|017|CANCELADO|        |    |          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |0109300001521|001|ATIVO    |01 CDG  |9311|          *      */
        /*"      *           |             |   |         |49 SAF_E|    |          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |0109300001521|002|ATIVO    |01 CDG  |9311|          *      */
        /*"      *           |             |   |         |49 SAF_E|    |          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |0109300001521|003|ATIVO    |01 CDG  |9311|          *      */
        /*"      *           |             |   |         |49 SAF_E|    |          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |0108211034287|001|CANCELADO|        |8203|          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |0109300003228|001|ATIVO    |49 SAF_E|9311|          *      */
        /*"      *           |-------------|---|---------|--------|----|          *      */
        /*"      *           |0109300003658|001|CANCELADO|        |9311|          *      */
        /*"      *           |=============|===|=========|========|====|          *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2023 - ANSELMO SOUSA                                *      */
        /*"      *                                            PROCURE POR V.45    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.44  *                                                                *      */
        /*"      *   VERSAO 44 - DEMANDA 415708                                   *      */
        /*"      *             - CORRECAO DO ENVIO A MENOR DE ASSISTENCIAS IDENTI-*      */
        /*"      *               FICADAS NOS ARQUIVOS DIARIOS (Daammdd):          *      */
        /*"      *               .ASSISTENCIA FARMACIA (FARM) / DESCONTO FARMACIA *      */
        /*"      *               .ASSISTENCIA RESIDENCIA (RESID) / ASSISTENCIA LAR*      */
        /*"      *                                                                *      */
        /*"      *   EM 12/12/2022 - ANSELMO SOUSA                                *      */
        /*"      *                                            PROCURE POR V.44    *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 43 - DEMANDA 415708                                   *      */
        /*"      *             - RETIRAR NEXT SENTENCE DA V.42.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/10/2021 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.43         *      */
        /*"      ******************************************************************      */
        /*"V.42  *   VERSAO 42 - DEMANDA 415708                                   *      */
        /*"      *             - ENVIAR NOVAS ASSISTENCIAS NO ARQUIVO DIARIO      *      */
        /*"      *                                                                *      */
        /*"      * CONVENIO X ASSISTENCIA (HM):                                   *      */
        /*"      * CONVENIO    COB ASSISTENCIA                                    *      */
        /*"      * 40000527293 16  Desconto em farmacia                           *      */
        /*"      * 40000999981 81  Servico reducao de preco em consultas e exames *      */
        /*"      * 40000527273 83  Assistencia Lar                                *      */
        /*"      * 40000527275 84  Assistencia Recolocacao profissional           *      */
        /*"      * 40000527277 85  Assistencia PET                                *      */
        /*"      * 40000527305 86  Assistencia Help Desk para Smartphones         *      */
        /*"      * 40000527279 87  Assistencia gestante                           *      */
        /*"      * 40000527281 88  Cartao natalidade                              *      */
        /*"      * 40000527283 89  Assistencia automoveis e motocicletas          *      */
        /*"      * 40000527285 90  Assistencia Bike                               *      */
        /*"      * 40000527287 91  Telemedicina                                   *      */
        /*"      * 40000527307 92  Assistencia Senior                             *      */
        /*"      * 40000527289 88  Cartao natalidade (funcionaria e funcionario)  *      */
        /*"      * 40000142243 02  Assistencia Funeral Familiar                   *      */
        /*"      *                                                                *      */
        /*"      * CONVENIO X ASSISTENCIA (PRD):                                  *      */
        /*"      * CONVENIO    COB ASSISTENCIA                                    *      */
        /*"      * 40000527293 16  Desconto em farmacia                           *      */
        /*"      * 40000999981 81  Servico reducao de preco em consultas e exames *      */
        /*"      * 40000527273 83  Assistencia Lar                                *      */
        /*"      * 40000527275 84  Assistencia Recolocacao profissional           *      */
        /*"      * 40000527277 85  Assistencia PET                                *      */
        /*"      * 40000527305 86  Assistencia Help Desk para Smartphones         *      */
        /*"      * 40000527279 87  Assistencia gestante                           *      */
        /*"      * 40000527281 88  Cartao natalidade                              *      */
        /*"      * 40000527283 89  Assistencia automoveis e motocicletas          *      */
        /*"      * 40000527285 90  Assistencia Bike                               *      */
        /*"      * 40000527287 91  Telemedicina                                   *      */
        /*"      * 40000527307 92  Assistencia Senior                             *      */
        /*"      * 40000527289 88  Cartao natalidade (funcionaria e funcionario)  *      */
        /*"      * 40000142243 02  Assistencia Funeral Familiar                   *      */
        /*"      * CONVENIO X ARQUIVO DIARIO:                                     *      */
        /*"      * CONVENIO    COB ARQUIVO_DIARIO                                 *      */
        /*"      * 40000527293 16  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000999981 81  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527273 83  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527275 84  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527277 85  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527305 86  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527279 87  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527281 88  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527283 89  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527285 90  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527287 91  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527307 92  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000527289 88  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000999905 05  PRD.VA.D$(ODATE).VA1476B.ARQMVA.SORT           *      */
        /*"      * 40000142243 02  PRD.VA.D$(ODATE).VA1471B.REPSAF                *      */
        /*"      *                                                                *      */
        /*"      * CONVENIO X ARQUIVO MENSAL:                                     *      */
        /*"      * CONVENIO    COB ARQUIVO_MENSAL                                 *      */
        /*"      * 40000527293 16  M2208.VA1475B.MEDICOS.TXT                      *      */
        /*"      * 40000999981 81  M2208.VA1475B.CEPR.TXT                         *      */
        /*"      * 40000527273 83  M2208.VA1475B.LAR.TXT                          *      */
        /*"      * 40000527275 84  M2208.VA1475B.RECPROF.TXT                      *      */
        /*"      * 40000527277 85  M2208.VA1475B.PET.TXT                          *      */
        /*"      * 40000527305 86  M2208.VA1475B.HELPCEL.TXT                      *      */
        /*"      * 40000527279 87  M2208.VA1475B.GESTANT.TXT                      *      */
        /*"      * 40000527281 88  M2208.VA1475B.CNATAL.TXT                       *      */
        /*"      * 40000527283 89  M2208.VA1475B.AUTOMOT.TXT                      *      */
        /*"      * 40000527285 90  M2208.VA1475B.BIKE.TXT                         *      */
        /*"      * 40000527287 91  M2208.VA1475B.TELEMED.TXT                      *      */
        /*"      * 40000527307 92  M2208.VA1475B.SENIOR.TXT                       *      */
        /*"      * 40000527289 88  M2208.VA1475B.CNATALF.TXT                      *      */
        /*"      * 40000999981 02  M2208.VA1471B.REPSAF.TXT                       *      */
        /*"      * 40000528999 93  M2208.VA1475B.AMBIENT.TXT                      *      */
        /*"      *                                                                *      */
        /*"      * SEGUROS.VG_ACESSORIO:                                          *      */
        /*"      * ACESSORIO SIGLA      DES_ACESSORIO                             *      */
        /*"      * 16        FARM       ASSIST�NCIA FARM�CIA                      *      */
        /*"      * 81        CEPR       CONSULTAS E EXAMES COM PRECOS REDUZIDOS   *      */
        /*"      * 83        ASSIS RESD ASSISTENCIA LAR                           *      */
        /*"      * 84        ASSIST REC ASSISTENCIA RECOLOCACAO PROFISSIONAL      *      */
        /*"      * 85        ASSIST PET ASSISTENCIA PET                           *      */
        /*"      * 86        ASSIST HDS ASSISTENCIA HELPDESK SMARTPHONE           *      */
        /*"      * 87        ASSIST GES ASSISTENCIA GESTANTE                      *      */
        /*"      * 88        ASSIST NAT ASSISTENCIA CART�O NATALIDADE             *      */
        /*"      * 89        ASSIST AUT ASSISTENCIA AUTOMOVEIS E MOTOCICLETAS     *      */
        /*"      * 90        ASSIST BIK ASSISTENCIA BIKE                          *      */
        /*"      * 91        ASSIST TEL ASSISTENCIA TELEMEDICINA                  *      */
        /*"      * 92        ASSIST SEN ASSISTENCIA SENIOR                        *      */
        /*"      * 93        Assistencia Ambiental (ESG)                          *      */
        /*"      * 88        ASSIST NAT ASSISTENCIA CART�O NATALIDADE             *      */
        /*"      * 02        SAF_F      SERVI�O ASSIST�NCIA FUNERAL FAMILIAR      *      */
        /*"      *                                                                *      */
        /*"      * PRODUTOS IMPACTADOS:                                           *      */
        /*"      * NUM_APOLICE   SUB PROD NOME_PRODUTO      PERIOD CONJ PLANO     *      */
        /*"      *................................................................*      */
        /*"      *................................................................*      */
        /*"      * 3008211398371 0   8241 VIDA EMPRESARIAL CAPITAL GLOBAL AP Mensal      */
        /*"      * 3008211398372 0   8242 VIDA EMPRESARIAL CAPITAL GLOBAL AP Anteci      */
        /*"      * 3009300007527 0   9381 VIDA EMPRESARIAL CAPITAL GLOBAL VG Mensal      */
        /*"      * 3009300007528 0   9382 VIDA EMPRESARIAL CAPITAL GLOBAL VG Anteci      */
        /*"      *................................................................*      */
        /*"      * 3009300001559 21  9749 VIDA EXCLUSIVO    MENSAL C/C  PL1�      *      */
        /*"      * 3009300001559 22  9749 VIDA EXCLUSIVO    MENSAL C/C  PL2�      *      */
        /*"      * 3009300001559 23  9749 VIDA EXCLUSIVO    MENSAL C/C  PL3�      *      */
        /*"      * 3009300001559 24  9749 VIDA EXCLUSIVO    MENSAL S/C  PL1�      *      */
        /*"      * 3009300001559 25  9749 VIDA EXCLUSIVO    MENSAL S/C  PL2�      *      */
        /*"      * 3009300001559 26  9749 VIDA EXCLUSIVO    MENSAL S/C  PL3�      *      */
        /*"      *................................................................*      */
        /*"      * 3009300001909 02  9729 VIDA SENIOR       MENSAL S/C  PL1       *      */
        /*"      * 3009300001909 03  9729 VIDA SENIOR       MENSAL S/C  PL2       *      */
        /*"      * 3009300001909 04  9729 VIDA SENIOR       MENSAL S/C  PL3       *      */
        /*"      *................................................................*      */
        /*"      * 3009300011970 05  9746 MULTIPR TOTAL     ANTEC  S/C  PL1���    *      */
        /*"      * 3009300011970 06  9746 MULTIPR TOTAL     ANTEC  S/C  PL2���    *      */
        /*"      * 3009300011970 07  9746 MULTIPR TOTAL     ANTEC  S/C  PL3���    *      */
        /*"      * 3009300011970 08  9746 MULTIPR TOTAL     ANTEC  S/C  PL1���    *      */
        /*"      * 3009300011970 09  9746 MULTIPR TOTAL     ANTEC  S/C  PL2���    *      */
        /*"      * 3009300011970 10  9746 MULTIPR TOTAL     ANTEC  S/C  PL3���    *      */
        /*"      *................................................................*      */
        /*"      * 3009300011970 11  9745 MULTIPR TOTAL     MENSAL S/C  PL1��     *      */
        /*"      * 3009300011970 12  9745 MULTIPR TOTAL     MENSAL S/C  PL2��     *      */
        /*"      * 3009300011970 13  9745 MULTIPR TOTAL     MENSAL S/C  PL3��     *      */
        /*"      * 3009300011970 14  9745 MULTIPR TOTAL     MENSAL C/C  PL1��     *      */
        /*"      * 3009300011970 15  9745 MULTIPR TOTAL     MENSAL C/C  PL2��     *      */
        /*"      * 3009300011970 16  9745 MULTIPR TOTAL     MENSAL C/C  PL3��     *      */
        /*"      *................................................................*      */
        /*"      * 3009300011971 03  9747 MULTIPR TOTAL     PU     S/C  PL1������ *      */
        /*"      * 3009300011971 04  9747 MULTIPR TOTAL     PU     S/C  PL2������ *      */
        /*"      * 3009300011971 05  9747 MULTIPR TOTAL     PU     S/C  PL3������ *      */
        /*"      * 3009300011971 06  9747 MULTIPR TOTAL     PU     C/C  PL1������ *      */
        /*"      * 3009300011971 07  9747 MULTIPR TOTAL     PU     C/C  PL2������ *      */
        /*"      * 3009300011971 08  9747 MULTIPR TOTAL     PU     C/C  PL3������ *      */
        /*"      *................................................................*      */
        /*"      * 3009300011977 09  9735 VD MULHER TOTAL   MENSAL C/C  PL1       *      */
        /*"      * 3009300011977 10  9735 VD MULHER TOTAL   MENSAL C/C  PL2       *      */
        /*"      * 3009300011977 11  9735 VD MULHER TOTAL   MENSAL C/C  PL3       *      */
        /*"      *................................................................*      */
        /*"      * 3009300011977 12  9736 VD MULHER TOTAL   ANTEC  C/C  PL1�      *      */
        /*"      * 3009300011977 13  9736 VD MULHER TOTAL   ANTEC  C/C  PL2�      *      */
        /*"      * 3009300011977 14  9736 VD MULHER TOTAL   ANTEC  C/C  PL3�      *      */
        /*"      *................................................................*      */
        /*"      * 3009300011977 15  9735 VIDA MULHER TOTAL PU     S/C  PL1��     *      */
        /*"      * 3009300011977 16  9735 VIDA MULHER TOTAL PU     S/C  PL2��     *      */
        /*"      * 3009300011977 17  9735 VIDA MULHER TOTAL PU     S/C  PL3��     *      */
        /*"      *................................................................*      */
        /*"      * 3009300011977 18  9736 VD MULHER TOTAL   ANTEC  S/C  PL1�      *      */
        /*"      * 3009300011977 19  9736 VD MULHER TOTAL   ANTEC  S/C  PL2�      *      */
        /*"      * 3009300011977 20  9736 VD MULHER TOTAL   ANTEC  S/C  PL3�      *      */
        /*"      *................................................................*      */
        /*"      * 3009300011978 03  9737 VIDA MULHER TOTAL PU     C/C  PL1��     *      */
        /*"      * 3009300011978 04  9737 VIDA MULHER TOTAL PU     C/C  PL2��     *      */
        /*"      * 3009300011978 05  9737 VIDA MULHER TOTAL PU     C/C  PL3��     *      */
        /*"      * 3009300011978 06  9737 VIDA MULHER TOTAL PU     S/C  PL1��     *      */
        /*"      * 3009300011978 07  9737 VIDA MULHER TOTAL PU     S/C  PL2��     *      */
        /*"      * 3009300011978 08  9737 VIDA MULHER TOTAL PU     S/C  PL3��     *      */
        /*"      *................................................................*      */
        /*"      * 3009300012002 06  9742 MULTIPR SUPER     ANTEC  C/C  PL1���    *      */
        /*"      * 3009300012002 07  9742 MULTIPR SUPER     ANTEC  C/C  PL2���    *      */
        /*"      * 3009300012002 08  9742 MULTIPR SUPER     ANTEC  C/C  PL3���    *      */
        /*"      * 3009300012002 09  9742 MULTIPR SUPER     ANTEC  S/C  PL1���    *      */
        /*"      * 3009300012002 10  9742 MULTIPR SUPER     ANTEC  S/C  PL2���    *      */
        /*"      * 3009300012002 11  9742 MULTIPR SUPER     ANTEC  S/C  PL3���    *      */
        /*"      *................................................................*      */
        /*"      * 3009300012002 12  9741 MULTIPR SUPER     MENSAL C/C  PL1��     *      */
        /*"      * 3009300012002 13  9741 MULTIPR SUPER     MENSAL C/C  PL2��     *      */
        /*"      * 3009300012002 14  9741 MULTIPR SUPER     MENSAL C/C  PL3��     *      */
        /*"      * 3009300012002 15  9741 MULTIPR SUPER     MENSAL S/C  PL1��     *      */
        /*"      * 3009300012002 16  9741 MULTIPR SUPER     MENSAL S/C  PL2��     *      */
        /*"      * 3009300012002 17  9741 MULTIPR SUPER     MENSAL S/C  PL3��     *      */
        /*"      *................................................................*      */
        /*"      * 3009300012003 03  9743 MULTIPR SUPER     PU     C/C  PL1������ *      */
        /*"      * 3009300012003 04  9743 MULTIPR SUPER     PU     C/C  PL2������ *      */
        /*"      * 3009300012003 05  9743 MULTIPR SUPER     PU     C/C  PL3������ *      */
        /*"      * 3009300012003 06  9743 MULTIPR SUPER     PU     S/C  PL1������ *      */
        /*"      * 3009300012003 07  9743 MULTIPR SUPER     PU     S/C  PL2������ *      */
        /*"      * 3009300012003 08  9743 MULTIPR SUPER     PU     S/C  PL3������ *      */
        /*"      *................................................................*      */
        /*"      * 3009300012005 05  9731 VIDA MULHER       MENSAL C/C  PL1����   *      */
        /*"      * 3009300012005 06  9731 VIDA MULHER       MENSAL C/C  PL2����   *      */
        /*"      * 3009300012005 07  9731 VIDA MULHER       MENSAL C/C  PL3����   *      */
        /*"      *................................................................*      */
        /*"      * 3009300012005 08  9732 VIDA MULHER       ANTEC  C/C  PL1�����  *      */
        /*"      * 3009300012005 09  9732 VIDA MULHER       ANTEC  C/C  PL2�����  *      */
        /*"      * 3009300012005 10  9732 VIDA MULHER       ANTEC  C/C  PL3�����  *      */
        /*"      *................................................................*      */
        /*"      * 3009300012005 11  9731 VIDA MULHER       MENSAL S/C  PL1����   *      */
        /*"      * 3009300012005 12  9731 VIDA MULHER       MENSAL S/C  PL2����   *      */
        /*"      * 3009300012005 13  9731 VIDA MULHER       MENSAL S/C  PL3����   *      */
        /*"      *................................................................*      */
        /*"      * 3009300012005 14  9732 VIDA MULHER       ANTEC  S/C  PL1�����  *      */
        /*"      * 3009300012005 15  9732 VIDA MULHER       ANTEC  S/C  PL2�����  *      */
        /*"      * 3009300012005 16  9732 VIDA MULHER       ANTEC  S/C  PL3�����  *      */
        /*"      *................................................................*      */
        /*"      * 3009300012006 03  9733 VIDA MULHER       PU     S/C  PL1�������*      */
        /*"      * 3009300012006 04  9733 VIDA MULHER       PU     S/C  PL2�������*      */
        /*"      * 3009300012006 05  9733 VIDA MULHER       PU     S/C  PL3�������*      */
        /*"      * 3009300012006 06  9733 VIDA MULHER       PU     S/C  PL1�������*      */
        /*"      * 3009300012006 07  9733 VIDA MULHER       PU     S/C  PL2�������*      */
        /*"      * 3009300012006 08  9733 VIDA MULHER       PU     S/C  PL3�������*      */
        /*"      *................................................................*      */
        /*"      * 3009300012008 05  9731 VIDA MULHER       MENSAL C/C  PL1����   *      */
        /*"      * 3009300012008 06  9731 VIDA MULHER       MENSAL C/C  PL2����   *      */
        /*"      * 3009300012008 07  9731 VIDA MULHER       MENSAL C/C  PL3����   *      */
        /*"      *................................................................*      */
        /*"      * 3009300012008 08  9732 VIDA MULHER       ANTEC  C/C  PL1�����  *      */
        /*"      * 3009300012008 09  9732 VIDA MULHER       ANTEC  C/C  PL2�����  *      */
        /*"      * 3009300012008 10  9732 VIDA MULHER       ANTEC  C/C  PL3�����  *      */
        /*"      *................................................................*      */
        /*"      * 3009300012008 11  9731 VIDA MULHER       MENSAL S/C  PL1����   *      */
        /*"      * 3009300012008 12  9731 VIDA MULHER       MENSAL S/C  PL2����   *      */
        /*"      * 3009300012008 13  9731 VIDA MULHER       MENSAL S/C  PL3����   *      */
        /*"      *................................................................*      */
        /*"      * 3009300012008 14  9732 VIDA MULHER       ANTEC  S/C  PL1�����  *      */
        /*"      * 3009300012008 15  9732 VIDA MULHER       ANTEC  S/C  PL2�����  *      */
        /*"      * 3009300012008 16  9732 VIDA MULHER       ANTEC  S/C  PL3�����  *      */
        /*"      *................................................................*      */
        /*"      * 3009300012010 03  9733 VIDA MULHER       PU     C/C  PL1�������*      */
        /*"      * 3009300012010 04  9733 VIDA MULHER       PU     C/C  PL2�������*      */
        /*"      * 3009300012010 05  9733 VIDA MULHER       PU     C/C  PL3�������*      */
        /*"      * 3009300012010 06  9733 VIDA MULHER       PU     S/C  PL1�������*      */
        /*"      * 3009300012010 07  9733 VIDA MULHER       PU     S/C  PL2�������*      */
        /*"      * 3009300012010 08  9733 VIDA MULHER       PU     S/C  PL3�������*      */
        /*"      *................................................................*      */
        /*"      * 3009300012344 03  9722 VIDA DA GENTE     ANUAL  S/C  PL1���    *      */
        /*"      * 3009300012344 04  9722 VIDA DA GENTE     ANUAL  S/C  PL2���    *      */
        /*"      * 3009300012344 05  9722 VIDA DA GENTE     ANUAL  S/C  PL3���    *      */
        /*"      *................................................................*      */
        /*"      * 3009300012344 06  9721 VIDA DA GENTE     MENSAL S/C  PL1��     *      */
        /*"      * 3009300012344 07  9721 VIDA DA GENTE     MENSAL S/C  PL2��     *      */
        /*"      * 3009300012344 08  9721 VIDA DA GENTE     MENSAL S/C  PL3��     *      */
        /*"      *................................................................*      */
        /*"      * 3009300012358 02  9723 VIDA DA GENTE     PU     S/C  PL1������ *      */
        /*"      * 3009300012358 03  9723 VIDA DA GENTE     PU     S/C  PL2������ *      */
        /*"      * 3009300012358 04  9723 VIDA DA GENTE     PU     S/C  PL3������ *      */
        /*"      *................................................................*      */
        /*"      *                                                                *      */
        /*"      * COBERTURA por CONVENIO e TAXA:                                 *      */
        /*"      * COB DES_ACESSORIO                            CONVENIO    TAXA  *      */
        /*"      * --- ---------------------------------------- ----------- ----  *      */
        /*"      *  16 ASSIST�NCIA FARM�CIA                     40000527293 0.15  *      */
        /*"      *  81 CONSULTAS E EXAMES COM PRECOS REDUZIDOS  40000999981 1.40  *      */
        /*"      *  83 ASSISTENCIA LAR                          40000527273 1.07  *      */
        /*"      *  84 ASSISTENCIA RECOLOCACAO PROFISSIONAL     40000527275 0.31  *      */
        /*"      *  85 ASSISTENCIA PET                          40000527277 0.42  *      */
        /*"      *  86 ASSISTENCIA HELPDESK SMARTPHONE          40000527305 0.44  *      */
        /*"      *  87 ASSISTENCIA GESTANTE                     40000527279 1.57  *      */
        /*"      *  88 ASSISTENCIA CART�O NATALIDADE            40000527281 1.05  *      */
        /*"      *  89 ASSISTENCIA AUTOMOVEIS E MOTOCICLETAS    40000527283 0.17  *      */
        /*"      *  90 ASSISTENCIA BIKE                         40000527285 0.04  *      */
        /*"      *  91 ASSISTENCIA TELEMEDICINA                 40000527287 0.36  *      */
        /*"      *  92 ASSISTENCIA SENIOR                       40000527307 0.07  *      */
        /*"      *  88 ASSISTENCIA CART�O NATALIDADE (FUNC)     40000527289 1.05  *      */
        /*"      *  02 SERVI�O ASSIST�NCIA FUNERAL FAMILIAR     40000142243 0.00  *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/08/2022 - ANSELMO SOUSA                                *      */
        /*"      *                                            PROCURE POR V.42    *      */
        /*"      ******************************************************************      */
        /*"V.41  *   VERSAO 41 - DEMANDA 404620                                   *      */
        /*"      *             - ENVIAR NOVAS ASSISTENCIAS PARA OS PRODUTOS       *      */
        /*"      *               ESTAR 8521, 8528 E 8529                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/07/2022 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.41    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.40  *VERSAO V.40-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV139#*VERSAO 39: JV1 DEMANDA 262179 - KINKAS 28/10/2020               *      */
        /*"JV139#*           TROCA REFERENCIAS PRODUTOS JV1 POR JVPRDXXXX         *      */
        /*"JV139#*           - PROCURAR POR JV139                                 *      */
        /*"JV139#*----------------------------------------------------------------*      */
        /*"JV138 *VERSAO 38: JV1 DEMANDA 262179 - KINKAS 23/10/2020               *      */
        /*"JV138 *           EXCLUI APOLICES/PRODUTOS JV1 - FASE 2                *      */
        /*"JV138 *           - PROCURAR POR JV138                                 *      */
        /*"JV138 *----------------------------------------------------------------*      */
        /*"JV137 *VERSAO 37: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV137 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV137 *           - PROCURAR POR JV137                                 *      */
        /*"JV137 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36 - HIST 181610                                      *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2019 - JOAO ARAUJO                                  *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"V.35  *----------------------------------------------------------------*      */
        /*"V.35  *   VERSAO 35 - DEMANDA 175.167                                  *      */
        /*"V.35  *             - OPERACAO CONTA SALARIO                           *      */
        /*"V.35  *                                                                *      */
        /*"V.35  *   EM 22/02/2018 - MARCUS VALERIO                               *      */
        /*"V.35  *                                       PROCURE POR V.35         *      */
        /*"V.34  ******************************************************************      */
        /*"V.34  *   VERSAO 34 - CAD 157.341                                      *      */
        /*"V.34  *             - INCLUIR A APOLICE 108211251755 PARA ASSISTENCIA  *      */
        /*"V.34  *               RESIDENCIAL (SUBGRUPO 1 E 2) E  ASSISTENCIA      *      */
        /*"V.34  *               SAF INDIVIDUAL + CESTA BASICA (SUBGRUPO 2)       *      */
        /*"V.34  *                                                                *      */
        /*"V.34  *   EM 04/01/2018 - ELIERMES OLIVEIRA                            *      */
        /*"V.34  *                                       PROCURE POR V.34         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 33 - CAD 149660                                       *      */
        /*"      *               RETIRADA DE ABEND - SQLCODE 100                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/04/2017 - MARCUS                                       *      */
        /*"      *                                       PROCURE POR V.33         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 32 - CAD 142.610                                      *      */
        /*"      *               CORRIGIR ENVIO DE ASSISTENCIAS A TEMPO ASSIST.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/03/2017 - MARCUS                                       *      */
        /*"      *                                       PROCURE POR V.32         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 31 - CAD 135.693                                      *      */
        /*"      *                INIBE A INCLUSAO NESSE ARQUIVO DE ASSISTENCIAS  *      */
        /*"      *                ASSISTENCIAS QUE ESTEJAM DESABILITADAS NO SIAS  *      */
        /*"      *                CONSIDERANDO A DATA EM QUE A DESABILITACAO      *      */
        /*"      *                OCORREU OU SEJA 08/03/2016.                     *      */
        /*"      *                                                                *      */
        /*"      *                OS PRODUTOS A SEREM CONSIDERADOS SAO OS ABAIXO: *      */
        /*"      *                                                                *      */
        /*"      *  COD   NOME DO PRODUTO                APOLICE        SUBGRUPO  *      */
        /*"      *                                                                *      */
        /*"      *  9310  EXCLUSIVO                      109300000559    01 A 19  *      */
        /*"      *  9314  SENIOR                         109300000909             *      */
        /*"      *  9353  VIDA DA GENTE - MENSAL         109300002357    01       *      */
        /*"      *  9352  VIDA DA GENTE-ANTECIPADO       109300002344    01 A 02  *      */
        /*"      *  9351  VIDA DA GENTE - PU             109300002358    01       *      */
        /*"      *  9320  MULTIPREMIADO SUPER - MENSAL   109300002001    01 A 02  *      */
        /*"      *  9321  MULTIPREMIADO SUPER-ANTECIPADO 109300002002    01 A 04  *      */
        /*"      *  9322  MULTIPREMIADO SUPER - PU       109300002003    01 A 02  *      */
        /*"      *  9359  MULTIPREMIADO SUPER - MENSAL   109300001966    01 A 04  *      */
        /*"      *  9360  MULTIPREMIADO SUPER-ANTECIPADO 109300001970    01 A 04  *      */
        /*"      *  9361  MULTIPREMIADO SUPER - PU       109300001971    01 A 02  *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2016 - MAURO                                        *      */
        /*"      *                                       PROCURE POR V.31         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.30  *   VERSAO 30 - CAD 120.218                                      *      */
        /*"=     *             - INCLUIR AS APOLICES 109300003691 E 109300003692  *      */
        /*"=     *               NO SAF-ESTENDIDO.                                *      */
        /*"=     *                                                                *      */
        /*"=     *   EM 11/08/2015 - ROGERIO LAMAS                                *      */
        /*"=     *                                       PROCURE POR V.30         *      */
        /*"      ******************************************************************      */
        /*"V.29  *   VERSAO 29 - CAD 86.052                                       *      */
        /*"=     *             - MIGRAR CONVENIO 40001052599 PARA 40001052587     *      */
        /*"=     *             - PARA O CONVENIO 40001052587, INCLUIR O  PRODUTO  *      */
        /*"=     *               8213, 9311 E 9354                                *      */
        /*"=     *             - VALOR MENSAL DE 0,40.                            *      */
        /*"=     *                                                                *      */
        /*"=     *                                                                *      */
        /*"=     *   EM 18/12/2014 - ELIERMES OLIVEIRA                            *      */
        /*"V.29  *                                       PROCURE POR V.29         *      */
        /*"      ******************************************************************      */
        /*"V.28  *   VERSAO 28 - CAD 104.952                                      *      */
        /*"      *                                                                *      */
        /*"      *              - MIGRACAO DOS PRODUTOS 8112 E 8113 PARA MICROSSE-*      */
        /*"      *                GURO 3709.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/11/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      ******************************************************************      */
        /*"V.27  *   VERSAO 27 - CAD 83.783                                       *      */
        /*"      *                                                                *      */
        /*"      *              - PARA O CONVENIO 40000042589, INCLUIR OS PRODUTOS*      */
        /*"      *                8209 E 9343.                                    *      */
        /*"      *              - VALOR MENSAL DE 0,40.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2013 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.27         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 26 - CAD 81.094                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUIR CESTA NATALIDADE E SEGURO VIAGEM        *      */
        /*"      *                PARA APOLICE ESPECIFICA                         *      */
        /*"      *                109300002554 - CYRELA BRAZIL REALTY S.A         *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/08/2013 - EDIVALDO GOMES    (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      ******************************************************************      */
        /*"V.24  *   VERSAO 24 - CAD 77.935                                       *      */
        /*"      *                                                                *      */
        /*"      *   - INCLUSAO DO ARQUIVO DE RESUMO DE ASSISTENCIAS.             *      */
        /*"      *   - CORRECAO NO LAYOUT DO ARQUIVO REPSAF.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/06/2013 - COREON - CASSIANO                            *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.24    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *   VERSAO 23 - CAD 77.247                                       *      */
        /*"      *                                                                *      */
        /*"      *              - PARA O CONVENIO 40000042589, INCLUIR OS PRODUTOS*      */
        /*"      *                8205 E 9329.                                   .*      */
        /*"      *              - ALTERAR O VALOR DE 1,00 PARA 0,40.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/06/2013 - CASSIANO (COREON)                            *      */
        /*"      *                                       PROCURE POR V.23         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.22  *   VERSAO 22 - CAD 77.320                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUIR PARA O CONVENIO 40001052599, SEXO       *      */
        /*"      *                MASCULINO E ALTERAR O VALOR DE 0,75 PARA 0,08   *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/04/2013 - CASSIANO (COREON)                            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CAD 80.248                                       *      */
        /*"      *                                                                *      */
        /*"      *              - PASSA A TRATAR O PRODUTO 3701 BILHETE           *      */
        /*"      *                MICRO SEGURO LOTERICO                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/04/2013 - EDIVALDO GOMES    (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - CAD 71.447                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUIR NO RELATORIO O SERVICO 400000142324     *      */
        /*"      *                SAF-ESTENDIDO PARA APOLICE 109300001980         *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/12/2012 - AUGUSTO ANASTACIO (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 - CAD 72.667                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUSAO DOS PRODUTOS COMERCIALIZADOS NA REDE   *      */
        /*"      *                SIM                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/10/2012 - LUIZ MARQUES(FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 - CAD 71.349                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AUMENTAR O TAMANHO DO TELEFONE PARA 09 DIGITOS  *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/08/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - CAD 57.801                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUIR  NO RELATORIO O SERVICO 40001052599     *      */
        /*"      *                CESTA NATALIDADE PARA OS PRODUTOS 8213 E 9354   *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.17         *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - CAD 67.646                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUSAO DO PRODUTO EXCELLENCE                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/04/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.16         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - CAD 56.396                                       *      */
        /*"      *                                                                *      */
        /*"      *         - INCLUIR  NO RELATORIO O SERVICO 40001172590          *      */
        /*"      *            ASSISTENCIA EMPRESARIAL  PARA OS PRODUTO 8138       *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/10/2011 - ALESSANDR G. RAMOS (FAST COMPUTER)           *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.15         *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - CAD 54.323                                       *      */
        /*"      *                                                                *      */
        /*"      *              - ALTERAR CODIGO DO SERVICO EDUCACIONAL PARA OS   *      */
        /*"      *                PRODUTOS DE VIDA.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/08/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 - CAD 60.539                                       *      */
        /*"      *                                                                *      */
        /*"      *              - TRATAR O ABEND DA ROTINA R5200-00-SELECT-PARAM. *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/08/2011 - ALESSANDR G. RAMOS (FAST COMPUTER)           *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 - CAD 57.177                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUIR  NO RELATORIO O SERVICO 40000042589     *      */
        /*"      *                 ASSISTENCIA EMPRESARIAL  PARA OS PRODUTO 8117  *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/07/2011 - ALESSANDR G. RAMOS (FAST COMPUTER)           *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 53.482                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUSAO DOS PRODUTOS DA REDE SIM:              *      */
        /*"      *               88126,8127,8128.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/05/2011 - FAST COMPUTER - MARCO PAIVA                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 55.966                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUSAO DE COD_PRODUTOS                        *      */
        /*"      *               8114, 8115, 8116, 8117, 8118, 8119, 8120, 8121,  *      */
        /*"      *               8122, 8123, 8124, 8125, 8132.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/05/2011 - FAST COMPUTER - MARCO PAIVA                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                TRATAR OS PRODUTOS DOS CLIENTES SYSTEMCRED      *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                             PROCURE POR V.09                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08  - CAD 46.050                                      *      */
        /*"      *                TRATAR O PRODUTO 8108 (FARMA VIDA)              *      */
        /*"      *                ACRECESTAR ORIENTACAO NUTRICIONAL               *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/08/2010 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                             PROCURE POR V.08                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07  - CAD 45.761                                      *      */
        /*"      *                TRATAR O PRODUTO 8108 (FARMA VIDA)              *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/08/2010 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                             PROCURE POR V.07                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 42.363                                       *      */
        /*"      *               JUNCAO DOS CADMUS 37.455 E 41.104                *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/05/2010 - FAST COMPUTER (MARCO PAIVA)PROCURE POR V.06  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 41.104                                       *      */
        /*"      *               TRATAR DE BILHETE OS PRODUTOS 8112 E 8113        *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/04/2010 - FAST COMPUTER (MARCO PAIVA)PROCURE POR V.05  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 37.455                                       *      */
        /*"      *             . VIDA DA GENTE - ACRESCENTAR A. VIAGEM PARA       *      */
        /*"      *               AS APOLICES EXISTENTES E PARA AS NOVAS           *      */
        /*"      *                                                                *      */
        /*"      *             . BILHETE AP    - ACRESCENTAR CHECK LAR PARA       *      */
        /*"      *               AS APOLICES EXISTENTES E PARA AS NOVAS           *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/02/2010 - EDIVALDO GOMES   (FAST COMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.04             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 28.444                                       *      */
        /*"      *               INCLUSAO DE BILHETES AP                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/08/2009 - FAST COMPUTER (EDIVALDO)   PROCURE POR V.03  *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 24.709/2009                                  *      */
        /*"      *               INCLUSAO DE NOVAS APOLICES                       *      */
        /*"      *   ABRIU UM NOVO CAD - (24.709) REFERENTE ESSE CADMUS:          *      */
        /*"      *   CAD 21.862/22.844 - 2009                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/05/2009 - ROGERIO    (FAST)    PROCURE POR V.02        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD 21.862/2009 E 22.844                         *      */
        /*"      *               INCLUSAO DE NOVAS APOLICES                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/03/2009 - ROGERIO/ELISEU (FAST)    PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MVA1476B { get; set; } = new FileBasis(new PIC("X", "899", "X(899)"));

        public FileBasis MVA1476B
        {
            get
            {
                _.Move(REG_MVA1476B, _MVA1476B); VarBasis.RedefinePassValue(REG_MVA1476B, _MVA1476B, REG_MVA1476B); return _MVA1476B;
            }
        }
        public FileBasis _PVA1476B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis PVA1476B
        {
            get
            {
                _.Move(REG_PVA1476B, _PVA1476B); VarBasis.RedefinePassValue(REG_PVA1476B, _PVA1476B, REG_PVA1476B); return _PVA1476B;
            }
        }
        public FileBasis _RVA1476B { get; set; } = new FileBasis(new PIC("X", "90", "X(90)"));

        public FileBasis RVA1476B
        {
            get
            {
                _.Move(REG_RVA1476B, _RVA1476B); VarBasis.RedefinePassValue(REG_RVA1476B, _RVA1476B, REG_RVA1476B); return _RVA1476B;
            }
        }
        public FileBasis _M1476BHM { get; set; } = new FileBasis(new PIC("X", "899", "X(899)"));

        public FileBasis M1476BHM
        {
            get
            {
                _.Move(REG_M1476BHM, _M1476BHM); VarBasis.RedefinePassValue(REG_M1476BHM, _M1476BHM, REG_M1476BHM); return _M1476BHM;
            }
        }
        public FileBasis _P1476BHM { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis P1476BHM
        {
            get
            {
                _.Move(REG_P1476BHM, _P1476BHM); VarBasis.RedefinePassValue(REG_P1476BHM, _P1476BHM, REG_P1476BHM); return _P1476BHM;
            }
        }
        public FileBasis _R1476BHM { get; set; } = new FileBasis(new PIC("X", "90", "X(90)"));

        public FileBasis R1476BHM
        {
            get
            {
                _.Move(REG_R1476BHM, _R1476BHM); VarBasis.RedefinePassValue(REG_R1476BHM, _R1476BHM, REG_R1476BHM); return _R1476BHM;
            }
        }
        /*"01   REG-MVA1476B PIC X(899).*/
        public StringBasis REG_MVA1476B { get; set; } = new StringBasis(new PIC("X", "899", "X(899)."), @"");
        /*"01   REG-PVA1476B PIC X(132).*/
        public StringBasis REG_PVA1476B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01   REG-RVA1476B PIC X(090).*/
        public StringBasis REG_RVA1476B { get; set; } = new StringBasis(new PIC("X", "90", "X(090)."), @"");
        /*"01   REG-M1476BHM PIC X(899).*/
        public StringBasis REG_M1476BHM { get; set; } = new StringBasis(new PIC("X", "899", "X(899)."), @"");
        /*"01   REG-P1476BHM PIC X(132).*/
        public StringBasis REG_P1476BHM { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01   REG-R1476BHM PIC X(090).*/
        public StringBasis REG_R1476BHM { get; set; } = new StringBasis(new PIC("X", "90", "X(090)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01     VIND-NOME-RAZAO            PIC S9(4) USAGE COMP.*/
        public IntBasis VIND_NOME_RAZAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     VIND-ENDERECO              PIC S9(4) USAGE COMP.*/
        public IntBasis VIND_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     VIND-BAIRRO                PIC S9(4) USAGE COMP.*/
        public IntBasis VIND_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     VIND-CIDADE                PIC S9(4) USAGE COMP.*/
        public IntBasis VIND_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     VIND-SIGLA-UF              PIC S9(4) USAGE COMP.*/
        public IntBasis VIND_SIGLA_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     VIND-CEP                   PIC S9(4) USAGE COMP.*/
        public IntBasis VIND_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     VIND-DDD                   PIC S9(4) USAGE COMP.*/
        public IntBasis VIND_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     VIND-TELEFONE              PIC S9(4) USAGE COMP.*/
        public IntBasis VIND_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     VIND-DATA-NASC             PIC S9(4) USAGE COMP.*/
        public IntBasis VIND_DATA_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  ENDLOCAL.*/
        public VA1476B_ENDLOCAL ENDLOCAL { get; set; } = new VA1476B_ENDLOCAL();
        public class VA1476B_ENDLOCAL : VarBasis
        {
            /*"  03 ENDLOCAL-COD-ENDERECO      PIC S9(4) USAGE COMP.*/
            public IntBasis ENDLOCAL_COD_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  03 ENDLOCAL-OCORR-ENDERECO    PIC S9(4) USAGE COMP.*/
            public IntBasis ENDLOCAL_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  03 ENDLOCAL-ENDERECO          PIC X(40).*/
            public StringBasis ENDLOCAL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"  03 ENDLOCAL-BAIRRO            PIC X(20).*/
            public StringBasis ENDLOCAL_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"  03 ENDLOCAL-CIDADE            PIC X(20).*/
            public StringBasis ENDLOCAL_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"  03 ENDLOCAL-SIGLA-UF          PIC X(2).*/
            public StringBasis ENDLOCAL_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
            /*"  03 ENDLOCAL-CEP               PIC S9(9) USAGE COMP.*/
            public IntBasis ENDLOCAL_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  03 ENDLOCAL-DDD               PIC S9(4) USAGE COMP.*/
            public IntBasis ENDLOCAL_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  03 ENDLOCAL-TELEFONE          PIC S9(9) USAGE COMP.*/
            public IntBasis ENDLOCAL_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  03 ENDLOCAL-FAX               PIC S9(9) USAGE COMP.*/
            public IntBasis ENDLOCAL_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  03 ENDLOCAL-TELEX             PIC S9(9) USAGE COMP.*/
            public IntBasis ENDLOCAL_TELEX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  03 ENDLOCAL-SIT-REGISTRO      PIC X(1).*/
            public StringBasis ENDLOCAL_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"01  WS-COD-PRODUTO                PIC S9(04) USAGE COMP.*/
        }
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WTEM-PROPOVA                  PIC  X(03) VALUE SPACES.*/
        public StringBasis WTEM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01  SISTEMAS-DATA-MOV-ABERTO-30   PIC  X(10).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-NUM-APOLICE-ANT            PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-DTQIT10A               PIC  X(10).*/
        public StringBasis PROPVA_DTQIT10A { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-NOME-ESTIP              PIC  X(72).*/
        public StringBasis WHOST_NOME_ESTIP { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"01  WHOST-TIPO-MOVIMENTO          PIC  X(01).*/
        public StringBasis WHOST_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  CLIENT-DTNASC-I               PIC S9(04) COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CLIENT-SEXO-I                 PIC S9(04) COMP.*/
        public IntBasis CLIENT_SEXO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPOF-I                      PIC S9(04) COMP.*/
        public IntBasis PROPOF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-ICODPRODEA             PIC S9(04) COMP.*/
        public IntBasis PRODVG_ICODPRODEA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SISTEMA-DTMVM06M              PIC  X(10).*/
        public StringBasis SISTEMA_DTMVM06M { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTCURREN             PIC  X(10).*/
        public StringBasis SISTEMAS_DTCURREN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTCURINI             PIC  X(10).*/
        public StringBasis SISTEMAS_DTCURINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  MVA1476B-DTINIVIG             PIC  X(10).*/
        public StringBasis MVA1476B_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  M1476BHM-DTINIVIG             PIC  X(10).*/
        public StringBasis M1476BHM_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-COD-CONVENIO            PIC  X(11).*/
        public StringBasis WHOST_COD_CONVENIO { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
        /*"01  WS-WORK-AREAS.*/
        public VA1476B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA1476B_WS_WORK_AREAS();
        public class VA1476B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WTEM-ENDOSSO           PIC X(03) VALUE SPACES.*/
            public StringBasis WTEM_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    03  WS-TEM-VGCOBSUB           PIC X(01) VALUE SPACES.*/
            public StringBasis WS_TEM_VGCOBSUB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    03  WFIM-PARAM                PIC X(01) VALUE SPACES.*/
            public StringBasis WFIM_PARAM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    03  WFIM-MOVDIARIO            PIC X(01) VALUE SPACES.*/
            public StringBasis WFIM_MOVDIARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    03  WS-EOF                    PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOF-PROPOFID           PIC 9(01) VALUE 0.*/
            public IntBasis WS_EOF_PROPOFID { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    03  WNR-EXEC-SQL              PIC 9(05) VALUE 0.*/
            public IntBasis WNR_EXEC_SQL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    03  LT-INCLUSAO               PIC X(10) VALUE 'INCLUSAO'.*/
            public StringBasis LT_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"INCLUSAO");
            /*"    03  LT-ALTERACAO              PIC X(10) VALUE 'ALTERACAO'.*/
            public StringBasis LT_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"ALTERACAO");
            /*"    03  LT-EXCLUSAO               PIC X(10) VALUE 'EXCLUSAO'.*/
            public StringBasis LT_EXCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"EXCLUSAO");
            /*"    03  WS-DISPLAY-8530           PIC X(01) VALUE 'N'.*/
            public StringBasis WS_DISPLAY_8530 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    03  WS-DISPLAY-8531           PIC X(01) VALUE 'N'.*/
            public StringBasis WS_DISPLAY_8531 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    03  WS-DISPLAY-8532           PIC X(01) VALUE 'N'.*/
            public StringBasis WS_DISPLAY_8532 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    03  WSQLCODE3                 PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03         WS-DATA-H-SQL.*/
            public VA1476B_WS_DATA_H_SQL WS_DATA_H_SQL { get; set; } = new VA1476B_WS_DATA_H_SQL();
            public class VA1476B_WS_DATA_H_SQL : VarBasis
            {
                /*"       05       WS-ANO-H-SQL       PIC  9(004).*/
                public IntBasis WS_ANO_H_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05       WS-MES-H-SQL       PIC  9(002).*/
                public IntBasis WS_MES_H_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05       WS-DIA-H-SQL       PIC  9(002).*/
                public IntBasis WS_DIA_H_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03         WS-DATA-H.*/
            }
            public VA1476B_WS_DATA_H WS_DATA_H { get; set; } = new VA1476B_WS_DATA_H();
            public class VA1476B_WS_DATA_H : VarBasis
            {
                /*"       05       WS-DIA-H           PIC  9(002).*/
                public IntBasis WS_DIA_H { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       WS-BARRA1          PIC  X(001) VALUE '/'.*/
                public StringBasis WS_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       05       WS-MES-H           PIC  9(002).*/
                public IntBasis WS_MES_H { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       WS-BARRA2          PIC  X(001) VALUE '/'.*/
                public StringBasis WS_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       05       WS-ANO-H           PIC  9(004).*/
                public IntBasis WS_ANO_H { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03         WS-DATE.*/
            }
            public VA1476B_WS_DATE WS_DATE { get; set; } = new VA1476B_WS_DATE();
            public class VA1476B_WS_DATE : VarBasis
            {
                /*"       05       WS-AA-DATE         PIC  9(02).*/
                public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05       WS-MM-DATE         PIC  9(02).*/
                public IntBasis WS_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05       WS-DD-DATE         PIC  9(02).*/
                public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03  W01DTSQL.*/
            }
            public VA1476B_W01DTSQL W01DTSQL { get; set; } = new VA1476B_W01DTSQL();
            public class VA1476B_W01DTSQL : VarBasis
            {
                /*"       05  W01AASQL               PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01AASQL-R REDEFINES  W01AASQL.*/
                private _REDEF_VA1476B_W01AASQL_R _w01aasql_r { get; set; }
                public _REDEF_VA1476B_W01AASQL_R W01AASQL_R
                {
                    get { _w01aasql_r = new _REDEF_VA1476B_W01AASQL_R(); _.Move(W01AASQL, _w01aasql_r); VarBasis.RedefinePassValue(W01AASQL, _w01aasql_r, W01AASQL); _w01aasql_r.ValueChanged += () => { _.Move(_w01aasql_r, W01AASQL); }; return _w01aasql_r; }
                    set { VarBasis.RedefinePassValue(value, _w01aasql_r, W01AASQL); }
                }  //Redefines
                public class _REDEF_VA1476B_W01AASQL_R : VarBasis
                {
                    /*"          10 W01SECSQL            PIC 9(002).*/
                    public IntBasis W01SECSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"          10 W01ANOSQL            PIC 9(002).*/
                    public IntBasis W01ANOSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       05  W01T1SQL               PIC X(001).*/

                    public _REDEF_VA1476B_W01AASQL_R()
                    {
                        W01SECSQL.ValueChanged += OnValueChanged;
                        W01ANOSQL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01MMSQL               PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01T2SQL               PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01DDSQL               PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  W01DTCOR.*/
            }
            public VA1476B_W01DTCOR W01DTCOR { get; set; } = new VA1476B_W01DTCOR();
            public class VA1476B_W01DTCOR : VarBasis
            {
                /*"       05  W01AACOR               PIC 9(004).*/
                public IntBasis W01AACOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01MMCOR               PIC 9(002).*/
                public IntBasis W01MMCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01DDCOR               PIC 9(002).*/
                public IntBasis W01DDCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  W01DTINV.*/
            }
            public VA1476B_W01DTINV W01DTINV { get; set; } = new VA1476B_W01DTINV();
            public class VA1476B_W01DTINV : VarBasis
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
            private _REDEF_VA1476B_WS_ANO_REF_R _ws_ano_ref_r { get; set; }
            public _REDEF_VA1476B_WS_ANO_REF_R WS_ANO_REF_R
            {
                get { _ws_ano_ref_r = new _REDEF_VA1476B_WS_ANO_REF_R(); _.Move(WS_ANO_REF, _ws_ano_ref_r); VarBasis.RedefinePassValue(WS_ANO_REF, _ws_ano_ref_r, WS_ANO_REF); _ws_ano_ref_r.ValueChanged += () => { _.Move(_ws_ano_ref_r, WS_ANO_REF); }; return _ws_ano_ref_r; }
                set { VarBasis.RedefinePassValue(value, _ws_ano_ref_r, WS_ANO_REF); }
            }  //Redefines
            public class _REDEF_VA1476B_WS_ANO_REF_R : VarBasis
            {
                /*"       05  FILLER                 PIC X(002).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       05  WS-ANO-REF-2           PIC 9(002).*/
                public IntBasis WS_ANO_REF_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  TABELA-ULT-DIAS.*/

                public _REDEF_VA1476B_WS_ANO_REF_R()
                {
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_ANO_REF_2.ValueChanged += OnValueChanged;
                }

            }
            public VA1476B_TABELA_ULT_DIAS TABELA_ULT_DIAS { get; set; } = new VA1476B_TABELA_ULT_DIAS();
            public class VA1476B_TABELA_ULT_DIAS : VarBasis
            {
                /*"      05 TAB-DIAS.*/
                public VA1476B_TAB_DIAS TAB_DIAS { get; set; } = new VA1476B_TAB_DIAS();
                public class VA1476B_TAB_DIAS : VarBasis
                {
                    /*"         09  FILLER               PIC  X(024)   VALUE            '312831303130313130313031'.*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                    /*"      05 TAB-DIAS-R               REDEFINES     TAB-DIAS.*/
                }
                private _REDEF_VA1476B_TAB_DIAS_R _tab_dias_r { get; set; }
                public _REDEF_VA1476B_TAB_DIAS_R TAB_DIAS_R
                {
                    get { _tab_dias_r = new _REDEF_VA1476B_TAB_DIAS_R(); _.Move(TAB_DIAS, _tab_dias_r); VarBasis.RedefinePassValue(TAB_DIAS, _tab_dias_r, TAB_DIAS); _tab_dias_r.ValueChanged += () => { _.Move(_tab_dias_r, TAB_DIAS); }; return _tab_dias_r; }
                    set { VarBasis.RedefinePassValue(value, _tab_dias_r, TAB_DIAS); }
                }  //Redefines
                public class _REDEF_VA1476B_TAB_DIAS_R : VarBasis
                {
                    /*"         09  ULT-DIA              OCCURS  12    TIMES                                  PIC  X(002).*/
                    public ListBasis<StringBasis, string> ULT_DIA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "2", "X(002)."), 12);
                    /*"    03  TAB-CONVENIO.*/

                    public _REDEF_VA1476B_TAB_DIAS_R()
                    {
                        ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public VA1476B_TAB_CONVENIO TAB_CONVENIO { get; set; } = new VA1476B_TAB_CONVENIO();
            public class VA1476B_TAB_CONVENIO : VarBasis
            {
                /*"      05 FILLER PIC X(36) VALUE         '40000042589ASSIST. EMPRESARIAL      '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000042589ASSIST. EMPRESARIAL      ");
                /*"      05 FILLER PIC X(36) VALUE         '40001262238ASSIST. FARMACIA         '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40001262238ASSIST. FARMACIA         ");
                /*"      05 FILLER PIC X(36) VALUE         '40000042239ASSIST. RESIDENCIAL      '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000042239ASSIST. RESIDENCIAL      ");
                /*"      05 FILLER PIC X(36) VALUE         '40001102241ORIENTACAO NUTRICIONAL   '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40001102241ORIENTACAO NUTRICIONAL   ");
                /*"      05 FILLER PIC X(36) VALUE         '40000032503ASSIST. HELP DESK        '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000032503ASSIST. HELP DESK        ");
                /*"      05 FILLER PIC X(36) VALUE         '40001112584ASSIST. ATOS VIOLENTOS   '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40001112584ASSIST. ATOS VIOLENTOS   ");
                /*"      05 FILLER PIC X(36) VALUE         '40001072240ASSIST. VIAGEM           '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40001072240ASSIST. VIAGEM           ");
                /*"      05 FILLER PIC X(36) VALUE         '40001172543ASSIST. EDUCACIONAL      '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40001172543ASSIST. EDUCACIONAL      ");
                /*"      05 FILLER PIC X(36) VALUE         '40001172590ASSIST. EDUCACIONAL      '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40001172590ASSIST. EDUCACIONAL      ");
                /*"      05 FILLER PIC X(36) VALUE         '40001152343ASSIST.RECOLOCACAO PROFI.'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40001152343ASSIST.RECOLOCACAO PROFI.");
                /*"      05 FILLER PIC X(36) VALUE         '40000142242CESTA BASICA             '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000142242CESTA BASICA             ");
                /*"      05 FILLER PIC X(36) VALUE         '40000142324SAF ESTENDIDO            '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000142324SAF ESTENDIDO            ");
                /*"      05 FILLER PIC X(36) VALUE         '40001052587CESTA NATALIDADE + BONUS '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40001052587CESTA NATALIDADE + BONUS ");
                /*"      05 FILLER PIC X(36) VALUE         '40000527293ASSIST. FARMACIA         '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527293ASSIST. FARMACIA         ");
                /*"      05 FILLER PIC X(36) VALUE         '40000999981CONS. EXAMES PRECOS REDUZ'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000999981CONS. EXAMES PRECOS REDUZ");
                /*"      05 FILLER PIC X(36) VALUE         '40000527273ASSIST. LAR              '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527273ASSIST. LAR              ");
                /*"      05 FILLER PIC X(36) VALUE         '40000527275ASSIST. REC. PROFISSIONAL'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527275ASSIST. REC. PROFISSIONAL");
                /*"      05 FILLER PIC X(36) VALUE         '40000527277ASSIST. PET              '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527277ASSIST. PET              ");
                /*"      05 FILLER PIC X(36) VALUE         '40000527305ASSIST. HELPDSK SMARTPHON'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527305ASSIST. HELPDSK SMARTPHON");
                /*"      05 FILLER PIC X(36) VALUE         '40000527279ASSIST. GESTANTE         '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527279ASSIST. GESTANTE         ");
                /*"      05 FILLER PIC X(36) VALUE         '40000527281ASSIST. CARTAO NATALIDADE'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527281ASSIST. CARTAO NATALIDADE");
                /*"      05 FILLER PIC X(36) VALUE         '40000527283ASSIST. AUTOMOVEIS E MOTO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527283ASSIST. AUTOMOVEIS E MOTO");
                /*"      05 FILLER PIC X(36) VALUE         '40000527285ASSIST. BIKE             '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527285ASSIST. BIKE             ");
                /*"      05 FILLER PIC X(36) VALUE         '40000527287ASSIST. TELEMEDICINA     '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527287ASSIST. TELEMEDICINA     ");
                /*"      05 FILLER PIC X(36) VALUE         '40000527307ASSIST. SENIOR           '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527307ASSIST. SENIOR           ");
                /*"      05 FILLER PIC X(36) VALUE         '40000527289ASSIST. CAR. NATAL. FUNC.'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000527289ASSIST. CAR. NATAL. FUNC.");
                /*"      05 FILLER PIC X(36) VALUE         '99999999999ORIENTACAO PSICO E SOCIAL'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"99999999999ORIENTACAO PSICO E SOCIAL");
                /*"      05 FILLER PIC X(36) VALUE         '40000528999ASSIST. AMBIENTAL        '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000528999ASSIST. AMBIENTAL        ");
                /*"      05 FILLER PIC X(36) VALUE         '40000529003ASSIST. ORIENT.FINANCEIRA'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000529003ASSIST. ORIENT.FINANCEIRA");
                /*"      05 FILLER PIC X(36) VALUE         '40000529001ASSIST. INVENTARIO       '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000529001ASSIST. INVENTARIO       ");
                /*"      05 FILLER PIC X(36) VALUE         '40000529005ASSIST.VIAGEM LAV+HOS.PET'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000529005ASSIST.VIAGEM LAV+HOS.PET");
                /*"      05 FILLER PIC X(36) VALUE         '40000529007ASSIST.REPARO EQUIPAMENTO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"40000529007ASSIST.REPARO EQUIPAMENTO");
                /*"    03  TAB-CONVENIO-R REDEFINES        TAB-CONVENIO.*/
            }
            private _REDEF_VA1476B_TAB_CONVENIO_R _tab_convenio_r { get; set; }
            public _REDEF_VA1476B_TAB_CONVENIO_R TAB_CONVENIO_R
            {
                get { _tab_convenio_r = new _REDEF_VA1476B_TAB_CONVENIO_R(); _.Move(TAB_CONVENIO, _tab_convenio_r); VarBasis.RedefinePassValue(TAB_CONVENIO, _tab_convenio_r, TAB_CONVENIO); _tab_convenio_r.ValueChanged += () => { _.Move(_tab_convenio_r, TAB_CONVENIO); }; return _tab_convenio_r; }
                set { VarBasis.RedefinePassValue(value, _tab_convenio_r, TAB_CONVENIO); }
            }  //Redefines
            public class _REDEF_VA1476B_TAB_CONVENIO_R : VarBasis
            {
                /*"       05 FILLER  OCCURS 32 TIMES.*/
                public ListBasis<VA1476B_FILLER_36> FILLER_36 { get; set; } = new ListBasis<VA1476B_FILLER_36>(32);
                public class VA1476B_FILLER_36 : VarBasis
                {
                    /*"            10  TB-COD-CONVENIO   PIC 9(11).*/
                    public IntBasis TB_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                    /*"            10  TB-DES-CONVENIO   PIC X(25).*/
                    public StringBasis TB_DES_CONVENIO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
                    /*"    03  WS-TOTAL-0917.*/

                    public VA1476B_FILLER_36()
                    {
                        TB_COD_CONVENIO.ValueChanged += OnValueChanged;
                        TB_DES_CONVENIO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA1476B_TAB_CONVENIO_R()
                {
                    FILLER_36.ValueChanged += OnValueChanged;
                }

            }
            public VA1476B_WS_TOTAL_0917 WS_TOTAL_0917 { get; set; } = new VA1476B_WS_TOTAL_0917();
            public class VA1476B_WS_TOTAL_0917 : VarBasis
            {
                /*"        05 FILLER                 PIC  X(005)  VALUE '0917;'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"0917;");
                /*"        05 WS-QTD-0917            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_0917 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9307.*/
            }
            public VA1476B_WS_TOTAL_9307 WS_TOTAL_9307 { get; set; } = new VA1476B_WS_TOTAL_9307();
            public class VA1476B_WS_TOTAL_9307 : VarBasis
            {
                /*"        05 WS-DESC-9307           PIC  X(005)  VALUE '9307;'.*/
                public StringBasis WS_DESC_9307 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9307;");
                /*"        05 WS-QTD-9307            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9307 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9311.*/
            }
            public VA1476B_WS_TOTAL_9311 WS_TOTAL_9311 { get; set; } = new VA1476B_WS_TOTAL_9311();
            public class VA1476B_WS_TOTAL_9311 : VarBasis
            {
                /*"        05 WS-DESC-9311           PIC  X(005)  VALUE '9311;'.*/
                public StringBasis WS_DESC_9311 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9311;");
                /*"        05 WS-QTD-9311            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9311 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9320.*/
            }
            public VA1476B_WS_TOTAL_9320 WS_TOTAL_9320 { get; set; } = new VA1476B_WS_TOTAL_9320();
            public class VA1476B_WS_TOTAL_9320 : VarBasis
            {
                /*"        05 WS-DESC-9320           PIC  X(005)  VALUE '9320;'.*/
                public StringBasis WS_DESC_9320 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9320;");
                /*"        05 WS-QTD-9320            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9320 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9321.*/
            }
            public VA1476B_WS_TOTAL_9321 WS_TOTAL_9321 { get; set; } = new VA1476B_WS_TOTAL_9321();
            public class VA1476B_WS_TOTAL_9321 : VarBasis
            {
                /*"        05 WS-DESC-9321           PIC  X(005)  VALUE '9321;'.*/
                public StringBasis WS_DESC_9321 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9321;");
                /*"        05 WS-QTD-9321            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9321 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9332.*/
            }
            public VA1476B_WS_TOTAL_9332 WS_TOTAL_9332 { get; set; } = new VA1476B_WS_TOTAL_9332();
            public class VA1476B_WS_TOTAL_9332 : VarBasis
            {
                /*"        05 WS-DESC-9332           PIC  X(005)  VALUE '9332;'.*/
                public StringBasis WS_DESC_9332 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9332;");
                /*"        05 WS-QTD-9332            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9332 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9703.*/
            }
            public VA1476B_WS_TOTAL_9703 WS_TOTAL_9703 { get; set; } = new VA1476B_WS_TOTAL_9703();
            public class VA1476B_WS_TOTAL_9703 : VarBasis
            {
                /*"        05 WS-DESC-9703           PIC  X(005)  VALUE '9703;'.*/
                public StringBasis WS_DESC_9703 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9703;");
                /*"        05 WS-QTD-9703            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9703 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9314.*/
            }
            public VA1476B_WS_TOTAL_9314 WS_TOTAL_9314 { get; set; } = new VA1476B_WS_TOTAL_9314();
            public class VA1476B_WS_TOTAL_9314 : VarBasis
            {
                /*"        05 WS-DESC-9314           PIC  X(005)  VALUE '9314;'.*/
                public StringBasis WS_DESC_9314 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9314;");
                /*"        05 WS-QTD-9314            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9314 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9327.*/
            }
            public VA1476B_WS_TOTAL_9327 WS_TOTAL_9327 { get; set; } = new VA1476B_WS_TOTAL_9327();
            public class VA1476B_WS_TOTAL_9327 : VarBasis
            {
                /*"        05 WS-DESC-9327           PIC  X(005)  VALUE '9327;'.*/
                public StringBasis WS_DESC_9327 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9327;");
                /*"        05 WS-QTD-9327            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9327 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9334.*/
            }
            public VA1476B_WS_TOTAL_9334 WS_TOTAL_9334 { get; set; } = new VA1476B_WS_TOTAL_9334();
            public class VA1476B_WS_TOTAL_9334 : VarBasis
            {
                /*"        05 WS-DESC-9334           PIC  X(005)  VALUE '9334;'.*/
                public StringBasis WS_DESC_9334 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9334;");
                /*"        05 WS-QTD-9334            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9334 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9329.*/
            }
            public VA1476B_WS_TOTAL_9329 WS_TOTAL_9329 { get; set; } = new VA1476B_WS_TOTAL_9329();
            public class VA1476B_WS_TOTAL_9329 : VarBasis
            {
                /*"        05 WS-DESC-9329           PIC  X(005)  VALUE '9329;'.*/
                public StringBasis WS_DESC_9329 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9329;");
                /*"        05 WS-QTD-9329            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9329 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8203.*/
            }
            public VA1476B_WS_TOTAL_8203 WS_TOTAL_8203 { get; set; } = new VA1476B_WS_TOTAL_8203();
            public class VA1476B_WS_TOTAL_8203 : VarBasis
            {
                /*"        05 WS-DESC-8203           PIC  X(005)  VALUE '8203;'.*/
                public StringBasis WS_DESC_8203 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8203;");
                /*"        05 WS-QTD-8203            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8203 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8521.*/
            }
            public VA1476B_WS_TOTAL_8521 WS_TOTAL_8521 { get; set; } = new VA1476B_WS_TOTAL_8521();
            public class VA1476B_WS_TOTAL_8521 : VarBasis
            {
                /*"        05 WS-DESC-8521           PIC  X(005)  VALUE '8521;'.*/
                public StringBasis WS_DESC_8521 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8521;");
                /*"        05 WS-QTD-8521            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8521 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8528.*/
            }
            public VA1476B_WS_TOTAL_8528 WS_TOTAL_8528 { get; set; } = new VA1476B_WS_TOTAL_8528();
            public class VA1476B_WS_TOTAL_8528 : VarBasis
            {
                /*"        05 WS-DESC-8528           PIC  X(005)  VALUE '8528;'.*/
                public StringBasis WS_DESC_8528 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8528;");
                /*"        05 WS-QTD-8528            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8528 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8529.*/
            }
            public VA1476B_WS_TOTAL_8529 WS_TOTAL_8529 { get; set; } = new VA1476B_WS_TOTAL_8529();
            public class VA1476B_WS_TOTAL_8529 : VarBasis
            {
                /*"        05 WS-DESC-8529           PIC  X(005)  VALUE '8529;'.*/
                public StringBasis WS_DESC_8529 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8529;");
                /*"        05 WS-QTD-8529            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8529 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8533.*/
            }
            public VA1476B_WS_TOTAL_8533 WS_TOTAL_8533 { get; set; } = new VA1476B_WS_TOTAL_8533();
            public class VA1476B_WS_TOTAL_8533 : VarBasis
            {
                /*"        05 WS-DESC-8533           PIC  X(005)  VALUE '8533;'.*/
                public StringBasis WS_DESC_8533 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8533;");
                /*"        05 WS-QTD-8533            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8533 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8534.*/
            }
            public VA1476B_WS_TOTAL_8534 WS_TOTAL_8534 { get; set; } = new VA1476B_WS_TOTAL_8534();
            public class VA1476B_WS_TOTAL_8534 : VarBasis
            {
                /*"        05 WS-DESC-8534           PIC  X(005)  VALUE '8534;'.*/
                public StringBasis WS_DESC_8534 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8534;");
                /*"        05 WS-QTD-8534            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8534 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9749.*/
            }
            public VA1476B_WS_TOTAL_9749 WS_TOTAL_9749 { get; set; } = new VA1476B_WS_TOTAL_9749();
            public class VA1476B_WS_TOTAL_9749 : VarBasis
            {
                /*"        05 WS-DESC-9749           PIC  X(005)  VALUE '9749;'.*/
                public StringBasis WS_DESC_9749 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9749;");
                /*"        05 WS-QTD-9749            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9749 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9729.*/
            }
            public VA1476B_WS_TOTAL_9729 WS_TOTAL_9729 { get; set; } = new VA1476B_WS_TOTAL_9729();
            public class VA1476B_WS_TOTAL_9729 : VarBasis
            {
                /*"        05 WS-DESC-9729           PIC  X(005)  VALUE '9729;'.*/
                public StringBasis WS_DESC_9729 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9729;");
                /*"        05 WS-QTD-9729            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9729 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9746.*/
            }
            public VA1476B_WS_TOTAL_9746 WS_TOTAL_9746 { get; set; } = new VA1476B_WS_TOTAL_9746();
            public class VA1476B_WS_TOTAL_9746 : VarBasis
            {
                /*"        05 WS-DESC-9746           PIC  X(005)  VALUE '9746;'.*/
                public StringBasis WS_DESC_9746 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9746;");
                /*"        05 WS-QTD-9746            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9746 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9745.*/
            }
            public VA1476B_WS_TOTAL_9745 WS_TOTAL_9745 { get; set; } = new VA1476B_WS_TOTAL_9745();
            public class VA1476B_WS_TOTAL_9745 : VarBasis
            {
                /*"        05 WS-DESC-9745           PIC  X(005)  VALUE '9745;'.*/
                public StringBasis WS_DESC_9745 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9745;");
                /*"        05 WS-QTD-9745            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9745 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9747.*/
            }
            public VA1476B_WS_TOTAL_9747 WS_TOTAL_9747 { get; set; } = new VA1476B_WS_TOTAL_9747();
            public class VA1476B_WS_TOTAL_9747 : VarBasis
            {
                /*"        05 WS-DESC-9747           PIC  X(005)  VALUE '9747;'.*/
                public StringBasis WS_DESC_9747 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9747;");
                /*"        05 WS-QTD-9747            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9747 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9735.*/
            }
            public VA1476B_WS_TOTAL_9735 WS_TOTAL_9735 { get; set; } = new VA1476B_WS_TOTAL_9735();
            public class VA1476B_WS_TOTAL_9735 : VarBasis
            {
                /*"        05 WS-DESC-9735           PIC  X(005)  VALUE '9735;'.*/
                public StringBasis WS_DESC_9735 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9735;");
                /*"        05 WS-QTD-9735            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9735 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9736.*/
            }
            public VA1476B_WS_TOTAL_9736 WS_TOTAL_9736 { get; set; } = new VA1476B_WS_TOTAL_9736();
            public class VA1476B_WS_TOTAL_9736 : VarBasis
            {
                /*"        05 WS-DESC-9736           PIC  X(005)  VALUE '9736;'.*/
                public StringBasis WS_DESC_9736 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9736;");
                /*"        05 WS-QTD-9736            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9736 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9737.*/
            }
            public VA1476B_WS_TOTAL_9737 WS_TOTAL_9737 { get; set; } = new VA1476B_WS_TOTAL_9737();
            public class VA1476B_WS_TOTAL_9737 : VarBasis
            {
                /*"        05 WS-DESC-9737           PIC  X(005)  VALUE '9737;'.*/
                public StringBasis WS_DESC_9737 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9737;");
                /*"        05 WS-QTD-9737            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9737 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9742.*/
            }
            public VA1476B_WS_TOTAL_9742 WS_TOTAL_9742 { get; set; } = new VA1476B_WS_TOTAL_9742();
            public class VA1476B_WS_TOTAL_9742 : VarBasis
            {
                /*"        05 WS-DESC-9742           PIC  X(005)  VALUE '9742;'.*/
                public StringBasis WS_DESC_9742 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9742;");
                /*"        05 WS-QTD-9742            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9742 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9741.*/
            }
            public VA1476B_WS_TOTAL_9741 WS_TOTAL_9741 { get; set; } = new VA1476B_WS_TOTAL_9741();
            public class VA1476B_WS_TOTAL_9741 : VarBasis
            {
                /*"        05 WS-DESC-9741           PIC  X(005)  VALUE '9741;'.*/
                public StringBasis WS_DESC_9741 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9741;");
                /*"        05 WS-QTD-9741            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9741 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9743.*/
            }
            public VA1476B_WS_TOTAL_9743 WS_TOTAL_9743 { get; set; } = new VA1476B_WS_TOTAL_9743();
            public class VA1476B_WS_TOTAL_9743 : VarBasis
            {
                /*"        05 WS-DESC-9743           PIC  X(005)  VALUE '9743;'.*/
                public StringBasis WS_DESC_9743 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9743;");
                /*"        05 WS-QTD-9743            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9743 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9731.*/
            }
            public VA1476B_WS_TOTAL_9731 WS_TOTAL_9731 { get; set; } = new VA1476B_WS_TOTAL_9731();
            public class VA1476B_WS_TOTAL_9731 : VarBasis
            {
                /*"        05 WS-DESC-9731           PIC  X(005)  VALUE '9731;'.*/
                public StringBasis WS_DESC_9731 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9731;");
                /*"        05 WS-QTD-9731            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9731 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9732.*/
            }
            public VA1476B_WS_TOTAL_9732 WS_TOTAL_9732 { get; set; } = new VA1476B_WS_TOTAL_9732();
            public class VA1476B_WS_TOTAL_9732 : VarBasis
            {
                /*"        05 WS-DESC-9732           PIC  X(005)  VALUE '9732;'.*/
                public StringBasis WS_DESC_9732 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9732;");
                /*"        05 WS-QTD-9732            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9732 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9733.*/
            }
            public VA1476B_WS_TOTAL_9733 WS_TOTAL_9733 { get; set; } = new VA1476B_WS_TOTAL_9733();
            public class VA1476B_WS_TOTAL_9733 : VarBasis
            {
                /*"        05 WS-DESC-9733           PIC  X(005)  VALUE '9733;'.*/
                public StringBasis WS_DESC_9733 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9733;");
                /*"        05 WS-QTD-9733            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9733 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9722.*/
            }
            public VA1476B_WS_TOTAL_9722 WS_TOTAL_9722 { get; set; } = new VA1476B_WS_TOTAL_9722();
            public class VA1476B_WS_TOTAL_9722 : VarBasis
            {
                /*"        05 WS-DESC-9722           PIC  X(005)  VALUE '9722;'.*/
                public StringBasis WS_DESC_9722 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9722;");
                /*"        05 WS-QTD-9722            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9722 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9721.*/
            }
            public VA1476B_WS_TOTAL_9721 WS_TOTAL_9721 { get; set; } = new VA1476B_WS_TOTAL_9721();
            public class VA1476B_WS_TOTAL_9721 : VarBasis
            {
                /*"        05 WS-DESC-9721           PIC  X(005)  VALUE '9721;'.*/
                public StringBasis WS_DESC_9721 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9721;");
                /*"        05 WS-QTD-9721            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9721 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9723.*/
            }
            public VA1476B_WS_TOTAL_9723 WS_TOTAL_9723 { get; set; } = new VA1476B_WS_TOTAL_9723();
            public class VA1476B_WS_TOTAL_9723 : VarBasis
            {
                /*"        05 WS-DESC-9723           PIC  X(005)  VALUE '9723;'.*/
                public StringBasis WS_DESC_9723 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9723;");
                /*"        05 WS-QTD-9723            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9723 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9386.*/
            }
            public VA1476B_WS_TOTAL_9386 WS_TOTAL_9386 { get; set; } = new VA1476B_WS_TOTAL_9386();
            public class VA1476B_WS_TOTAL_9386 : VarBasis
            {
                /*"        05 WS-DESC-9386           PIC  X(005)  VALUE '9386;'.*/
                public StringBasis WS_DESC_9386 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9386;");
                /*"        05 WS-QTD-9386            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9386 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8241.*/
            }
            public VA1476B_WS_TOTAL_8241 WS_TOTAL_8241 { get; set; } = new VA1476B_WS_TOTAL_8241();
            public class VA1476B_WS_TOTAL_8241 : VarBasis
            {
                /*"        05 WS-DESC-8241           PIC  X(005)  VALUE '8241;'.*/
                public StringBasis WS_DESC_8241 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8241;");
                /*"        05 WS-QTD-8241            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8241 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8242.*/
            }
            public VA1476B_WS_TOTAL_8242 WS_TOTAL_8242 { get; set; } = new VA1476B_WS_TOTAL_8242();
            public class VA1476B_WS_TOTAL_8242 : VarBasis
            {
                /*"        05 WS-DESC-8242           PIC  X(005)  VALUE '8242;'.*/
                public StringBasis WS_DESC_8242 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8242;");
                /*"        05 WS-QTD-8242            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8242 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9381.*/
            }
            public VA1476B_WS_TOTAL_9381 WS_TOTAL_9381 { get; set; } = new VA1476B_WS_TOTAL_9381();
            public class VA1476B_WS_TOTAL_9381 : VarBasis
            {
                /*"        05 WS-DESC-9381           PIC  X(005)  VALUE '9381;'.*/
                public StringBasis WS_DESC_9381 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9381;");
                /*"        05 WS-QTD-9381            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9381 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9382.*/
            }
            public VA1476B_WS_TOTAL_9382 WS_TOTAL_9382 { get; set; } = new VA1476B_WS_TOTAL_9382();
            public class VA1476B_WS_TOTAL_9382 : VarBasis
            {
                /*"        05 WS-DESC-9382           PIC  X(005)  VALUE '9382;'.*/
                public StringBasis WS_DESC_9382 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9382;");
                /*"        05 WS-QTD-9382            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9382 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9750.*/
            }
            public VA1476B_WS_TOTAL_9750 WS_TOTAL_9750 { get; set; } = new VA1476B_WS_TOTAL_9750();
            public class VA1476B_WS_TOTAL_9750 : VarBasis
            {
                /*"        05 WS-DESC-9750           PIC  X(005)  VALUE '9750;'.*/
                public StringBasis WS_DESC_9750 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9750;");
                /*"        05 WS-QTD-9750            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9750 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9751.*/
            }
            public VA1476B_WS_TOTAL_9751 WS_TOTAL_9751 { get; set; } = new VA1476B_WS_TOTAL_9751();
            public class VA1476B_WS_TOTAL_9751 : VarBasis
            {
                /*"        05 WS-DESC-9751           PIC  X(005)  VALUE '9751;'.*/
                public StringBasis WS_DESC_9751 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9751;");
                /*"        05 WS-QTD-9751            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9751 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9752.*/
            }
            public VA1476B_WS_TOTAL_9752 WS_TOTAL_9752 { get; set; } = new VA1476B_WS_TOTAL_9752();
            public class VA1476B_WS_TOTAL_9752 : VarBasis
            {
                /*"        05 WS-DESC-9752           PIC  X(005)  VALUE '9752;'.*/
                public StringBasis WS_DESC_9752 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9752;");
                /*"        05 WS-QTD-9752            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9752 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8530.*/
            }
            public VA1476B_WS_TOTAL_8530 WS_TOTAL_8530 { get; set; } = new VA1476B_WS_TOTAL_8530();
            public class VA1476B_WS_TOTAL_8530 : VarBasis
            {
                /*"        05 WS-DESC-8530           PIC  X(005)  VALUE '8530;'.*/
                public StringBasis WS_DESC_8530 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8530;");
                /*"        05 WS-QTD-8530            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8530 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8531.*/
            }
            public VA1476B_WS_TOTAL_8531 WS_TOTAL_8531 { get; set; } = new VA1476B_WS_TOTAL_8531();
            public class VA1476B_WS_TOTAL_8531 : VarBasis
            {
                /*"        05 WS-DESC-8531           PIC  X(005)  VALUE '8531;'.*/
                public StringBasis WS_DESC_8531 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8531;");
                /*"        05 WS-QTD-8531            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8531 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-8532.*/
            }
            public VA1476B_WS_TOTAL_8532 WS_TOTAL_8532 { get; set; } = new VA1476B_WS_TOTAL_8532();
            public class VA1476B_WS_TOTAL_8532 : VarBasis
            {
                /*"        05 WS-DESC-8532           PIC  X(005)  VALUE '8532;'.*/
                public StringBasis WS_DESC_8532 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"8532;");
                /*"        05 WS-QTD-8532            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_8532 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-TOTAL-9999.*/
            }
            public VA1476B_WS_TOTAL_9999 WS_TOTAL_9999 { get; set; } = new VA1476B_WS_TOTAL_9999();
            public class VA1476B_WS_TOTAL_9999 : VarBasis
            {
                /*"        05 FILLER                 PIC  X(005)  VALUE '9999;'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"9999;");
                /*"        05 WS-QTD-9999            PIC  9(008)  VALUE ZEROS.*/
                public IntBasis WS_QTD_9999 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    03  WS-NUM-FONE.*/
            }
            public VA1476B_WS_NUM_FONE WS_NUM_FONE { get; set; } = new VA1476B_WS_NUM_FONE();
            public class VA1476B_WS_NUM_FONE : VarBasis
            {
                /*"        05 WS-NUM-FONE-DDD        PIC  9(002).*/
                public IntBasis WS_NUM_FONE_DDD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05 WS-NUM-FONE            PIC  9(008).*/
                public IntBasis WS_NUM_FONE_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    03  WS-NUM-APOLICE            PIC  9(013).*/
            }
            public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    03  WS-NUM-APOLICE-R          REDEFINES        WS-NUM-APOLICE.*/
            private _REDEF_VA1476B_WS_NUM_APOLICE_R _ws_num_apolice_r { get; set; }
            public _REDEF_VA1476B_WS_NUM_APOLICE_R WS_NUM_APOLICE_R
            {
                get { _ws_num_apolice_r = new _REDEF_VA1476B_WS_NUM_APOLICE_R(); _.Move(WS_NUM_APOLICE, _ws_num_apolice_r); VarBasis.RedefinePassValue(WS_NUM_APOLICE, _ws_num_apolice_r, WS_NUM_APOLICE); _ws_num_apolice_r.ValueChanged += () => { _.Move(_ws_num_apolice_r, WS_NUM_APOLICE); }; return _ws_num_apolice_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_apolice_r, WS_NUM_APOLICE); }
            }  //Redefines
            public class _REDEF_VA1476B_WS_NUM_APOLICE_R : VarBasis
            {
                /*"        05  WS-NO-APOLICE         OCCURS 13 TIMES                                  PIC  9(001).*/
                public ListBasis<IntBasis, Int64> WS_NO_APOLICE { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 13);
                /*"    03  WS-NUM-CERTIFICADO        PIC  9(015).*/

                public _REDEF_VA1476B_WS_NUM_APOLICE_R()
                {
                    WS_NO_APOLICE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03  WS-NUM-CERTIFICADO-R      REDEFINES        WS-NUM-CERTIFICADO.*/
            private _REDEF_VA1476B_WS_NUM_CERTIFICADO_R _ws_num_certificado_r { get; set; }
            public _REDEF_VA1476B_WS_NUM_CERTIFICADO_R WS_NUM_CERTIFICADO_R
            {
                get { _ws_num_certificado_r = new _REDEF_VA1476B_WS_NUM_CERTIFICADO_R(); _.Move(WS_NUM_CERTIFICADO, _ws_num_certificado_r); VarBasis.RedefinePassValue(WS_NUM_CERTIFICADO, _ws_num_certificado_r, WS_NUM_CERTIFICADO); _ws_num_certificado_r.ValueChanged += () => { _.Move(_ws_num_certificado_r, WS_NUM_CERTIFICADO); }; return _ws_num_certificado_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_certificado_r, WS_NUM_CERTIFICADO); }
            }  //Redefines
            public class _REDEF_VA1476B_WS_NUM_CERTIFICADO_R : VarBasis
            {
                /*"        05  WS-NRCERTIF           OCCURS 15 TIMES                                  PIC  9(001).*/
                public ListBasis<IntBasis, Int64> WS_NRCERTIF { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 15);
                /*"    03  FLG                       PIC  9(001).*/

                public _REDEF_VA1476B_WS_NUM_CERTIFICADO_R()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis FLG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    03  IND                       PIC  9(002).*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03  INDF                      PIC  9(002).*/
            public IntBasis INDF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03  WS-TIME                   PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03  WS-TOTAL-LIDOS            PIC  9(009) VALUE  0.*/
            public IntBasis WS_TOTAL_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03  WS-TOTAL-CONTA            PIC  9(009) VALUE  0.*/
            public IntBasis WS_TOTAL_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03  WS-TOTAL-GRAVADOS         PIC  9(009) VALUE  0.*/
            public IntBasis WS_TOTAL_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03  WS-TOTAL-APOLICES         PIC  9(015) VALUE  0.*/
            public IntBasis WS_TOTAL_APOLICES { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    03  AC-ASSIST                 PIC  9(009) VALUE  0.*/
            public IntBasis AC_ASSIST { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EMPR-ANT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EMPR_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EMPR-INC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EMPR_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EMPR-EXC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EMPR_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EMPR-ALT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EMPR_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EMPR-ATU          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EMPR_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EMPR-X            PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EMPR_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FARM-ANT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FARM_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FARM-INC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FARM_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FARM-EXC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FARM_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FARM-ALT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FARM_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FARM-ATU          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FARM_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIOL-ANT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIOL_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIOL-INC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIOL_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIOL-EXC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIOL_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIOL-ALT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIOL_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIOL-ATU          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIOL_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RESI-ANT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RESI_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RESI-INC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RESI_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RESI-EXC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RESI_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RESI-ALT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RESI_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RESI-ATU          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RESI_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAG-ANT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAG_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAG-INC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAG_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAG-EXC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAG_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAG-ALT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAG_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAG-ATU          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAG_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-NUTR-ANT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_NUTR_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-NUTR-INC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_NUTR_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-NUTR-EXC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_NUTR_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-NUTR-ALT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_NUTR_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-NUTR-ATU          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_NUTR_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-NUTR-X            PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_NUTR_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RPROF-ANT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RPROF_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RPROF-INC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RPROF_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RPROF-EXC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RPROF_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RPROF-ALT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RPROF_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RPROF-ATU         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RPROF_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RPROF-X           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RPROF_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-ANT-U       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_ANT_U { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-INC-U       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_INC_U { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-EXC-U       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_EXC_U { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-ALT-U       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_ALT_U { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-ATU-U       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_ATU_U { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTA-ANT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTA_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTA-INC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTA_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTA-EXC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTA_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTA-ALT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTA_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTA-ATU         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTA_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTABONUS-ANT    PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTABONUS_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTABONUS-INC    PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTABONUS_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTABONUS-EXC    PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTABONUS_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTABONUS-ALT    PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTABONUS_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESTABONUS-ATU    PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESTABONUS_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SAFES-ANT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SAFES_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SAFES-INC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SAFES_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SAFES-EXC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SAFES_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SAFES-ALT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SAFES_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SAFES-ATU         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SAFES_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SAFES-X           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SAFES_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-ANT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-INC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-EXC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-ALT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-EDUCA-ATU         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_EDUCA_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HDESK-ANT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HDESK_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HDESK-INC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HDESK_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HDESK-EXC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HDESK_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HDESK-ALT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HDESK_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HDESK-ATU         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HDESK_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AXFUN-ANT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AXFUN_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AXFUN-INC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AXFUN_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AXFUN-EXC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AXFUN_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AXFUN-ALT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AXFUN_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AXFUN-ATU         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AXFUN_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESBA-ANT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESBA_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESBA-INC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESBA_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESBA-EXC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESBA_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESBA-ALT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESBA_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CESBA-ATU         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CESBA_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-MEDICOS-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_MEDICOS_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-MEDICOS-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_MEDICOS_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-MEDICOS-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_MEDICOS_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-MEDICOS-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_MEDICOS_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-MEDICOS-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_MEDICOS_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CEPR-ANT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CEPR_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CEPR-INC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CEPR_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CEPR-EXC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CEPR_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CEPR-ALT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CEPR_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CEPR-ATU          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CEPR_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-LAR-ANT           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_LAR_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-LAR-INC           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_LAR_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-LAR-EXC           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_LAR_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-LAR-ALT           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_LAR_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-LAR-ATU           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_LAR_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-LAR-X             PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_LAR_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RECPROF-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RECPROF_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RECPROF-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RECPROF_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RECPROF-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RECPROF_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RECPROF-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RECPROF_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-RECPROF-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_RECPROF_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-PET-ANT           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_PET_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-PET-INC           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_PET_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-PET-EXC           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_PET_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-PET-ALT           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_PET_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-PET-ATU           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_PET_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HELPCEL-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HELPCEL_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HELPCEL-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HELPCEL_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HELPCEL-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HELPCEL_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HELPCEL-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HELPCEL_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-HELPCEL-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_HELPCEL_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-GESTANT-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_GESTANT_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-GESTANT-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_GESTANT_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-GESTANT-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_GESTANT_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-GESTANT-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_GESTANT_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-GESTANT-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_GESTANT_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATAL-ANT        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATAL_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATAL-INC        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATAL_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATAL-EXC        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATAL_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATAL-ALT        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATAL_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATAL-ATU        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATAL_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AUTOMOT-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AUTOMOT_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AUTOMOT-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AUTOMOT_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AUTOMOT-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AUTOMOT_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AUTOMOT-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AUTOMOT_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AUTOMOT-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AUTOMOT_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-BIKE-ANT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_BIKE_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-BIKE-INC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_BIKE_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-BIKE-EXC          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_BIKE_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-BIKE-ALT          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_BIKE_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-BIKE-ATU          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_BIKE_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-TELEMED-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_TELEMED_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-TELEMED-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_TELEMED_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-TELEMED-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_TELEMED_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-TELEMED-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_TELEMED_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-TELEMED-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_TELEMED_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-TELEMED-X         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_TELEMED_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SENIOR-ANT        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SENIOR_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SENIOR-INC        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SENIOR_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SENIOR-EXC        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SENIOR_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SENIOR-ALT        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SENIOR_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-SENIOR-ATU        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_SENIOR_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATALF-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATALF_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATALF-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATALF_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATALF-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATALF_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATALF-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATALF_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-CNATALF-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_CNATALF_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AMBIENT-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AMBIENT_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AMBIENT-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AMBIENT_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AMBIENT-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AMBIENT_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AMBIENT-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AMBIENT_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AMBIENT-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AMBIENT_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-AMBIENT-X         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_AMBIENT_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FINANCE-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FINANCE_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FINANCE-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FINANCE_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FINANCE-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FINANCE_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FINANCE-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FINANCE_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FINANCE-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FINANCE_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-FINANCE-X         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_FINANCE_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-INVENTA-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_INVENTA_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-INVENTA-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_INVENTA_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-INVENTA-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_INVENTA_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-INVENTA-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_INVENTA_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-INVENTA-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_INVENTA_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-INVENTA-X         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_INVENTA_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAGELH-ANT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAGELH_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAGELH-INC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAGELH_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAGELH-EXC       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAGELH_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAGELH-ALT       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAGELH_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAGELH-ATU       PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAGELH_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-VIAGELH-X         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_VIAGELH_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-REPARO-ANT        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_REPARO_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-REPARO-INC        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_REPARO_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-REPARO-EXC        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_REPARO_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-REPARO-ALT        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_REPARO_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-REPARO-ATU        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_REPARO_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-REPARO-X          PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_REPARO_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-OPS-ANT           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_OPS_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-OPS-INC           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_OPS_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-OPS-EXC           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_OPS_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-OPS-ALT           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_OPS_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-OPS-ATU           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_OPS_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    AC-OPS-X             PIC 9(009)   VALUE ZEROS.*/
            public IntBasis AC_OPS_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    WS-TOTAL-ANT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    WS-TOTAL-INC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    WS-TOTAL-EXC         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_EXC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    WS-TOTAL-ALT         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_ALT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    WS-TOTAL-ATU         PIC 9(009)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    WS-TOTAL-X           PIC 9(009)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_X { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    WS-SEQUENCIAL        PIC 9(009)   VALUE ZEROS.*/
            public IntBasis WS_SEQUENCIAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03    WS-IND               PIC 9(006)   VALUE ZEROS.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01  HEADER-RECORD.*/
        }
        public VA1476B_HEADER_RECORD HEADER_RECORD { get; set; } = new VA1476B_HEADER_RECORD();
        public class VA1476B_HEADER_RECORD : VarBasis
        {
            /*"    05  HE-CONTANTE-1            PIC  X(001) VALUE  'H'.*/
            public StringBasis HE_CONTANTE_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"H");
            /*"    05  HE-SEQUENCIAL            PIC  9(010) VALUE 0.*/
            public IntBasis HE_SEQUENCIAL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    05  HE-COD-CLIENTE           PIC  9(015) VALUE 0.*/
            public IntBasis HE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  HE-CONTANTE-2            PIC  X(001) VALUE 'I'.*/
            public StringBasis HE_CONTANTE_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
            /*"    05  HE-INCLUSOES             PIC  9(010) VALUE 0.*/
            public IntBasis HE_INCLUSOES { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    05  HE-CONTANTE-3            PIC  X(001) VALUE 'E'.*/
            public StringBasis HE_CONTANTE_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"E");
            /*"    05  HE-EXCLUSOES             PIC  9(010) VALUE 0.*/
            public IntBasis HE_EXCLUSOES { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    05  HE-CONTANTE-4            PIC  X(001) VALUE 'A'.*/
            public StringBasis HE_CONTANTE_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"A");
            /*"    05  HE-ALTERACOES            PIC  9(010) VALUE 0.*/
            public IntBasis HE_ALTERACOES { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    05  HE-TOTAL-REG             PIC  9(010) VALUE 0.*/
            public IntBasis HE_TOTAL_REG { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    05  HE-CONTANTE-5            PIC  X(001) VALUE 'F'.*/
            public StringBasis HE_CONTANTE_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"F");
            /*"01  DETAIL-RECORD.*/
        }
        public VA1476B_DETAIL_RECORD DETAIL_RECORD { get; set; } = new VA1476B_DETAIL_RECORD();
        public class VA1476B_DETAIL_RECORD : VarBasis
        {
            /*"    05  DET-NUM-CONTRATO          PIC  X(018) VALUE SPACES.*/
            public StringBasis DET_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
            /*"    05  DET-NUM-VERSAO-CONTRATO   PIC  X(015) VALUE '0'.*/
            public StringBasis DET_NUM_VERSAO_CONTRATO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"0");
            /*"    05  DET-CHAVE-PRINCIPAL.*/
            public VA1476B_DET_CHAVE_PRINCIPAL DET_CHAVE_PRINCIPAL { get; set; } = new VA1476B_DET_CHAVE_PRINCIPAL();
            public class VA1476B_DET_CHAVE_PRINCIPAL : VarBasis
            {
                /*"        10  DET-NUM-CERTIFICADO   PIC  X(030) VALUE SPACES.*/
                public StringBasis DET_NUM_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05  DET-SUB-CHAVE-PRINCIPAL.*/
            }
            public VA1476B_DET_SUB_CHAVE_PRINCIPAL DET_SUB_CHAVE_PRINCIPAL { get; set; } = new VA1476B_DET_SUB_CHAVE_PRINCIPAL();
            public class VA1476B_DET_SUB_CHAVE_PRINCIPAL : VarBasis
            {
                /*"        10  DET-NUM-APOLICE       PIC  X(015).*/
                public StringBasis DET_NUM_APOLICE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    05  DET-TIPO-MOV              PIC  X(001).*/
            }
            public StringBasis DET_TIPO_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  DET-NOME-USUARIO-ASSIST   PIC  X(080).*/
            public StringBasis DET_NOME_USUARIO_ASSIST { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"    05  DET-DTINIVIG-ASSIST       PIC  X(008).*/
            public StringBasis DET_DTINIVIG_ASSIST { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  DET-DTTERVIG-ASSIST       PIC  X(008).*/
            public StringBasis DET_DTTERVIG_ASSIST { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  DET-CGC                   PIC  9(014).*/
            public IntBasis DET_CGC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  DET-CPF                   PIC  9(011).*/
            public IntBasis DET_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"    05  DET-ENDERECO              PIC  X(080).*/
            public StringBasis DET_ENDERECO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"    05  DET-SIGLA-UF              PIC  X(002).*/
            public StringBasis DET_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  DET-CIDADE                PIC  X(035).*/
            public StringBasis DET_CIDADE { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
            /*"    05  DET-BAIRRO                PIC  X(035).*/
            public StringBasis DET_BAIRRO { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
            /*"    05  DET-CEP                   PIC  X(010).*/
            public StringBasis DET_CEP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  DET-AREA-TELEFONE.*/
            public VA1476B_DET_AREA_TELEFONE DET_AREA_TELEFONE { get; set; } = new VA1476B_DET_AREA_TELEFONE();
            public class VA1476B_DET_AREA_TELEFONE : VarBasis
            {
                /*"      10  DET-DDD                 PIC  9(002).*/
                public IntBasis DET_DDD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10  DET-TELEFONE            PIC  9(009).*/
                public IntBasis DET_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10  FILLER                  PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05  DET-ENDERECO-RISCO        PIC  X(080).*/
            }
            public StringBasis DET_ENDERECO_RISCO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"    05  DET-SIGLA-UF-RISCO        PIC  X(002).*/
            public StringBasis DET_SIGLA_UF_RISCO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  DET-CIDADE-RISCO          PIC  X(035).*/
            public StringBasis DET_CIDADE_RISCO { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
            /*"    05  DET-BAIRRO-RISCO          PIC  X(035).*/
            public StringBasis DET_BAIRRO_RISCO { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
            /*"    05  DET-CEP-RISCO             PIC  X(010).*/
            public StringBasis DET_CEP_RISCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  DET-AREA-TELEFONE-RISCO.*/
            public VA1476B_DET_AREA_TELEFONE_RISCO DET_AREA_TELEFONE_RISCO { get; set; } = new VA1476B_DET_AREA_TELEFONE_RISCO();
            public class VA1476B_DET_AREA_TELEFONE_RISCO : VarBasis
            {
                /*"      10  DET-DDD-RISCO           PIC  9(002).*/
                public IntBasis DET_DDD_RISCO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10  DET-TELEFONE-RISCO      PIC  9(009).*/
                public IntBasis DET_TELEFONE_RISCO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10  FILLER                  PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05  DET-PLACA                 PIC  X(010).*/
            }
            public StringBasis DET_PLACA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  DET-CHASSIS               PIC  X(020).*/
            public StringBasis DET_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  DET-COR                   PIC  X(010).*/
            public StringBasis DET_COR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  DET-ANO-FABRICACAO        PIC  X(004).*/
            public StringBasis DET_ANO_FABRICACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05  DET-MODELO                PIC  X(040).*/
            public StringBasis DET_MODELO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  DET-MARCA                 PIC  X(040).*/
            public StringBasis DET_MARCA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  DET-DIAS-CARRES-PP        PIC  X(011).*/
            public StringBasis DET_DIAS_CARRES_PP { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
            /*"    05  DET-DIAS-CARRES-PT        PIC  X(011).*/
            public StringBasis DET_DIAS_CARRES_PT { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
            /*"    05  DET-DIAS-CARRES-PR        PIC  X(011).*/
            public StringBasis DET_DIAS_CARRES_PR { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
            /*"    05  DET-NOME-ESTIPULANTE      PIC  X(080).*/
            public StringBasis DET_NOME_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"    05  DET-BENEFICIARIO          PIC  X(080).*/
            public StringBasis DET_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"    05  DET-VALOR-LIMITE          PIC  9(013).*/
            public IntBasis DET_VALOR_LIMITE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05  DET-COD-PRODUTO           PIC  9(005).*/
            public IntBasis DET_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"01  AREA-CAB.*/
        }
        public VA1476B_AREA_CAB AREA_CAB { get; set; } = new VA1476B_AREA_CAB();
        public class VA1476B_AREA_CAB : VarBasis
        {
            /*"    05    LD01.*/
            public VA1476B_LD01 LD01 { get; set; } = new VA1476B_LD01();
            public class VA1476B_LD01 : VarBasis
            {
                /*"      10  FILLER            PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10  FILLER            PIC  X(017) VALUE 'DATA DA GERACAO:'*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"DATA DA GERACAO:");
                /*"      10  LD01-DATA-GERACAO PIC  X(010) VALUE SPACES.*/
                public StringBasis LD01_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10  FILLER            PIC  X(016) VALUE ' DATA DO ENVIO:'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @" DATA DO ENVIO:");
                /*"      10  LD01-DATA-ENVIO   PIC  X(010) VALUE SPACES.*/
                public StringBasis LD01_DATA_ENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10  FILLER            PIC  X(015) VALUE ' NR.SEQUENCIA:'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @" NR.SEQUENCIA:");
                /*"      10  LD01-SEQUENCIAL   PIC  9(006).*/
                public IntBasis LD01_SEQUENCIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05    LC02.*/
            }
            public VA1476B_LC02 LC02 { get; set; } = new VA1476B_LC02();
            public class VA1476B_LC02 : VarBasis
            {
                /*"      10   LC02-NUM-CONTRATO    PIC X(020) VALUE           'NUM.CONTRATO      '.*/
                public StringBasis LC02_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"NUM.CONTRATO      ");
                /*"      10   LC02-TOTAL-ANT       PIC X(009) VALUE 'POS INI'.*/
                public StringBasis LC02_TOTAL_ANT { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"POS INI");
                /*"      10   LC02-TOTAL-INC       PIC X(009) VALUE 'QTD INC'.*/
                public StringBasis LC02_TOTAL_INC { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"QTD INC");
                /*"      10   LC02-TOTAL-ALT       PIC X(009) VALUE 'QTD ALT'.*/
                public StringBasis LC02_TOTAL_ALT { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"QTD ALT");
                /*"      10   LC02-TOTAL-EXC       PIC X(009) VALUE 'QTD EXC'.*/
                public StringBasis LC02_TOTAL_EXC { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"QTD EXC");
                /*"      10   LC02-TOTAL-ATU       PIC X(009) VALUE 'POS ATU'.*/
                public StringBasis LC02_TOTAL_ATU { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"POS ATU");
                /*"    05    LD02.*/
            }
            public VA1476B_LD02 LD02 { get; set; } = new VA1476B_LD02();
            public class VA1476B_LD02 : VarBasis
            {
                /*"      10   LD02-NUM-CONTRATO    PIC X(018).*/
                public StringBasis LD02_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
                /*"      10   FILLER               PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10   LD02-TOTAL-ANT       PIC ZZZ.ZZ9.*/
                public IntBasis LD02_TOTAL_ANT { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"      10   FILLER               PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10   LD02-TOTAL-INC       PIC ZZZ.ZZ9.*/
                public IntBasis LD02_TOTAL_INC { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"      10   FILLER               PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10   LD02-TOTAL-ALT       PIC ZZZ.ZZ9.*/
                public IntBasis LD02_TOTAL_ALT { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"      10   FILLER               PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10   LD02-TOTAL-EXC       PIC ZZZ.ZZ9.*/
                public IntBasis LD02_TOTAL_EXC { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"      10   FILLER               PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10   LD02-TOTAL-ATU       PIC ZZZ.ZZ9.*/
                public IntBasis LD02_TOTAL_ATU { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"    05    LD03.*/
            }
            public VA1476B_LD03 LD03 { get; set; } = new VA1476B_LD03();
            public class VA1476B_LD03 : VarBasis
            {
                /*"      10   FILLER               PIC X(035) VALUE         'QUANTIDADE DE APOLICES VIGENTES EM '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"QUANTIDADE DE APOLICES VIGENTES EM ");
                /*"      10   LD03-DATA-DIA        PIC X(10) VALUE SPACES.*/
                public StringBasis LD03_DATA_DIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"      10   FILLER               PIC X(004) VALUE ' :- '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" :- ");
                /*"      10   LD03-TOTAL-APOL      PIC ZZ.ZZZ.ZZZ.ZZ9.*/
                public IntBasis LD03_TOTAL_APOL { get; set; } = new IntBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9."));
                /*"    05    LC05.*/
            }
            public VA1476B_LC05 LC05 { get; set; } = new VA1476B_LC05();
            public class VA1476B_LC05 : VarBasis
            {
                /*"      10   FILLER               PIC X(132) VALUE  SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"    05    LD06.*/
            }
            public VA1476B_LD06 LD06 { get; set; } = new VA1476B_LD06();
            public class VA1476B_LD06 : VarBasis
            {
                /*"      10   FILLER               PIC X(013) VALUE              '  BRASILIA,' .*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"  BRASILIA,");
                /*"      10   LD06-DATA-HOJE       PIC X(010) VALUE SPACES.*/
                public StringBasis LD06_DATA_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05        LR00.*/
            }
            public VA1476B_LR00 LR00 { get; set; } = new VA1476B_LR00();
            public class VA1476B_LR00 : VarBasis
            {
                /*"      10      FILLER              PIC X(44)   VALUE            'RELATORIO DE ASSISTENCIAS - CARGA DIARIA'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "44", "X(44)"), @"RELATORIO DE ASSISTENCIAS - CARGA DIARIA");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(11)   VALUE            'GERADO EM: '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"GERADO EM: ");
                /*"      10      LR00-DATA           PIC X(10).*/
                public StringBasis LR00_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"    05        LR01.*/
            }
            public VA1476B_LR01 LR01 { get; set; } = new VA1476B_LR01();
            public class VA1476B_LR01 : VarBasis
            {
                /*"      10      FILLER              PIC X(21)   VALUE             'CODIGO DA ASSISTENCIA'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"CODIGO DA ASSISTENCIA");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(19)   VALUE             'NOME DA ASSISTENCIA'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"NOME DA ASSISTENCIA");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(23)   VALUE             'QUANTIDADE DE REGISTROS'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"QUANTIDADE DE REGISTROS");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(16)   VALUE             'TIPO DO REGISTRO'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"TIPO DO REGISTRO");
                /*"    05        LR02.*/
            }
            public VA1476B_LR02 LR02 { get; set; } = new VA1476B_LR02();
            public class VA1476B_LR02 : VarBasis
            {
                /*"      10      LR02-COD-CONVENIO   PIC 9(11).*/
                public IntBasis LR02_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LR02-DESCRICAO      PIC X(25).*/
                public StringBasis LR02_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LR02-QUANTIDADE     PIC Z.ZZZ.ZZZ.ZZ9.*/
                public IntBasis LR02_QUANTIDADE { get; set; } = new IntBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9."));
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LR02-TIPO           PIC X(10).*/
                public StringBasis LR02_TIPO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"01  WABEND*/
            }
        }
        public VA1476B_WABEND WABEND { get; set; } = new VA1476B_WABEND();
        public class VA1476B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public VA1476B_FILLER_69 FILLER_69 { get; set; } = new VA1476B_FILLER_69();
            public class VA1476B_FILLER_69 : VarBasis
            {
                /*"      10  FILLER                  PIC  X(010) VALUE         'VA1476B  '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA1476B  ");
                /*"      10  FILLER                  PIC  X(028) VALUE         ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10  FILLER                  PIC  X(014) VALUE         '    SQLCODE = '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10  WSQLCODE                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD1 = '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10  WSQLERRD1               PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD2 = '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10  WSQLERRD2               PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD2 = '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05  LOCALIZA-ABEND-1.*/
            }
            public VA1476B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA1476B_LOCALIZA_ABEND_1();
            public class VA1476B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10  FILLER                  PIC  X(012)   VALUE         'PARAGRAFO = '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10  PARAGRAFO               PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05  LOCALIZA-ABEND-2.*/
            }
            public VA1476B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA1476B_LOCALIZA_ABEND_2();
            public class VA1476B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10  FILLER                  PIC  X(012)   VALUE         'COMANDO   = '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10  COMANDO                 PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01       WPAR-PARAMETROS.*/
            }
        }
        public VA1476B_WPAR_PARAMETROS WPAR_PARAMETROS { get; set; } = new VA1476B_WPAR_PARAMETROS();
        public class VA1476B_WPAR_PARAMETROS : VarBasis
        {
            /*"    03     WPAR-SIMULACAO      PIC  X(03).*/
            public StringBasis WPAR_SIMULACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    03     WPAR-FILLER1        PIC  X(01).*/
            public StringBasis WPAR_FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03     WPAR-DT-INI         PIC  X(10).*/
            public StringBasis WPAR_DT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03     WPAR-FILLER2        PIC  X(01).*/
            public StringBasis WPAR_FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03     WPAR-DT-FIM         PIC  X(10).*/
            public StringBasis WPAR_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.LTSOLPAR LTSOLPAR { get; set; } = new Dclgens.LTSOLPAR();
        public Dclgens.MRAPOITE MRAPOITE { get; set; } = new Dclgens.MRAPOITE();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.VGCOBSUB VGCOBSUB { get; set; } = new Dclgens.VGCOBSUB();
        public Dclgens.MOVIMEA MOVIMEA { get; set; } = new Dclgens.MOVIMEA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA1476B_MOVDIARIO MOVDIARIO { get; set; } = new VA1476B_MOVDIARIO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA1476B_WPAR_PARAMETROS VA1476B_WPAR_PARAMETROS_P, string MVA1476B_FILE_NAME_P, string PVA1476B_FILE_NAME_P, string RVA1476B_FILE_NAME_P, string M1476BHM_FILE_NAME_P, string P1476BHM_FILE_NAME_P, string R1476BHM_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.WPAR_PARAMETROS = VA1476B_WPAR_PARAMETROS_P;
                MVA1476B.SetFile(MVA1476B_FILE_NAME_P);
                PVA1476B.SetFile(PVA1476B_FILE_NAME_P);
                RVA1476B.SetFile(RVA1476B_FILE_NAME_P);
                M1476BHM.SetFile(M1476BHM_FILE_NAME_P);
                P1476BHM.SetFile(P1476BHM_FILE_NAME_P);
                R1476BHM.SetFile(R1476BHM_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { WPAR_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -2056- DISPLAY ' ' */
            _.Display($" ");

            /*" -2058- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -2078- DISPLAY 'PGM VA1476B V.54 DEMANDA 588808 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PGM VA1476B V.54 DEMANDA 588808 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -2080- DISPLAY 'GERAR ARQUIVOS DE ASSISTENCIAS DIARIOS PARA ' 'CAIXA ASSISTENCIA E HELLOMED. ' */
            _.Display($"GERAR ARQUIVOS DE ASSISTENCIAS DIARIOS PARA CAIXA ASSISTENCIA E HELLOMED. ");

            /*" -2082- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -2083- DISPLAY ' ' */
            _.Display($" ");

            /*" -2090- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -2092- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -2093- MOVE SPACES TO WPAR-SIMULACAO */
            _.Move("", WPAR_PARAMETROS.WPAR_SIMULACAO);

            /*" -2094- MOVE SPACES TO WPAR-FILLER1 */
            _.Move("", WPAR_PARAMETROS.WPAR_FILLER1);

            /*" -2095- MOVE SPACES TO WPAR-DT-INI */
            _.Move("", WPAR_PARAMETROS.WPAR_DT_INI);

            /*" -2096- MOVE SPACES TO WPAR-FILLER2 */
            _.Move("", WPAR_PARAMETROS.WPAR_FILLER2);

            /*" -2097- MOVE SPACES TO WPAR-DT-FIM */
            _.Move("", WPAR_PARAMETROS.WPAR_DT_FIM);

            /*" -2098- ACCEPT WPAR-PARAMETROS FROM SYSIN */
            /*-Accept convertido para parametro de entrada...*/

            /*" -2100- DISPLAY '===================================================' '=========' */
            _.Display($"============================================================");

            /*" -2101- DISPLAY 'PARAMETROS ACESSADOS:' */
            _.Display($"PARAMETROS ACESSADOS:");

            /*" -2102- DISPLAY 'WPAR-SIMULACAO = ' WPAR-SIMULACAO */
            _.Display($"WPAR-SIMULACAO = {WPAR_PARAMETROS.WPAR_SIMULACAO}");

            /*" -2103- DISPLAY 'WPAR-DT-INI    = ' WPAR-DT-INI */
            _.Display($"WPAR-DT-INI    = {WPAR_PARAMETROS.WPAR_DT_INI}");

            /*" -2104- DISPLAY 'WPAR-DT-FIM    = ' WPAR-DT-FIM */
            _.Display($"WPAR-DT-FIM    = {WPAR_PARAMETROS.WPAR_DT_FIM}");

            /*" -2106- DISPLAY '===================================================' '=========' */
            _.Display($"============================================================");

            /*" -2108- DISPLAY ' ' */
            _.Display($" ");

            /*" -2110- PERFORM R0100-00-SELECT-SISTEMAS */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -2112- PERFORM R0200-00-SELECT-RELATORI */

            R0200_00_SELECT_RELATORI_SECTION();

            /*" -2114- DISPLAY 'SISTEMAS-DATA-MOV-ABERTO   : ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"SISTEMAS-DATA-MOV-ABERTO   : {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -2116- DISPLAY 'SISTEMAS-DATA-MOV-ABERTO-30: ' SISTEMAS-DATA-MOV-ABERTO-30 */
            _.Display($"SISTEMAS-DATA-MOV-ABERTO-30: {SISTEMAS_DATA_MOV_ABERTO_30}");

            /*" -2117- DISPLAY 'SISTEMAS-DTCURREN          : ' SISTEMAS-DTCURREN */
            _.Display($"SISTEMAS-DTCURREN          : {SISTEMAS_DTCURREN}");

            /*" -2119- DISPLAY 'RELATORI-DATA-REFERENCIA   : ' RELATORI-DATA-REFERENCIA */
            _.Display($"RELATORI-DATA-REFERENCIA   : {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

            /*" -2120- MOVE 'N' TO WS-DISPLAY-8530 WS-DISPLAY-8531 WS-DISPLAY-8532 */
            _.Move("N", WS_WORK_AREAS.WS_DISPLAY_8530, WS_WORK_AREAS.WS_DISPLAY_8531, WS_WORK_AREAS.WS_DISPLAY_8532);

            /*" -2121- DISPLAY 'WS-DISPLAY-8530            : ' WS-DISPLAY-8530 */
            _.Display($"WS-DISPLAY-8530            : {WS_WORK_AREAS.WS_DISPLAY_8530}");

            /*" -2122- DISPLAY 'WS-DISPLAY-8531            : ' WS-DISPLAY-8531 */
            _.Display($"WS-DISPLAY-8531            : {WS_WORK_AREAS.WS_DISPLAY_8531}");

            /*" -2124- DISPLAY 'WS-DISPLAY-8532            : ' WS-DISPLAY-8532 */
            _.Display($"WS-DISPLAY-8532            : {WS_WORK_AREAS.WS_DISPLAY_8532}");

            /*" -2126- PERFORM R0900-00-DECLARE-MOVDIARIO */

            R0900_00_DECLARE_MOVDIARIO_SECTION();

            /*" -2128- PERFORM R0910-00-FETCH-MOVDIARIO */

            R0910_00_FETCH_MOVDIARIO_SECTION();

            /*" -2129- PERFORM R1000-00-PROCESSAMENTO UNTIL WFIM-MOVDIARIO NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_MOVDIARIO.IsEmpty()))
            {

                R1000_00_PROCESSAMENTO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_00_TERMINA */

            R0000_00_TERMINA();

        }

        [StopWatch]
        /*" R0000-00-TERMINA */
        private void R0000_00_TERMINA(bool isPerform = false)
        {
            /*" -2136- PERFORM R9000-00-FINALIZA */

            R9000_00_FINALIZA_SECTION();

            /*" -2138- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -2139- STOP RUN */

            throw new GoBack();   // => STOP RUN.

            /*" -2139- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -2147- MOVE 'R0100-00      ' TO PARAGRAFO */
            _.Move("R0100-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2148- MOVE 'R0100-INICIO' TO COMANDO */
            _.Move("R0100-INICIO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2150- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2159- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -2162- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2163- DISPLAY 'ERRO DE ACESSO EM SISTEMAS' */
                _.Display($"ERRO DE ACESSO EM SISTEMAS");

                /*" -2164- DISPLAY 'SQLCODE  =' SQLCODE */
                _.Display($"SQLCODE  ={DB.SQLCODE}");

                /*" -2165- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2167- END-IF */
            }


            /*" -2168- MOVE '1001-01-01' TO WS-DATA-H-SQL */
            _.Move("1001-01-01", WS_WORK_AREAS.WS_DATA_H_SQL);

            /*" -2170- MOVE '01/01/1001' TO WS-DATA-H */
            _.Move("01/01/1001", WS_WORK_AREAS.WS_DATA_H);

            /*" -2171- ACCEPT WS-DATE FROM DATE */
            _.Move(_.AcceptDate("DATE"), WS_WORK_AREAS.WS_DATE);

            /*" -2172- MOVE WS-DD-DATE TO WS-DIA-H-SQL */
            _.Move(WS_WORK_AREAS.WS_DATE.WS_DD_DATE, WS_WORK_AREAS.WS_DATA_H_SQL.WS_DIA_H_SQL);

            /*" -2173- MOVE WS-MM-DATE TO WS-MES-H-SQL */
            _.Move(WS_WORK_AREAS.WS_DATE.WS_MM_DATE, WS_WORK_AREAS.WS_DATA_H_SQL.WS_MES_H_SQL);

            /*" -2174- MOVE WS-AA-DATE TO WS-ANO-H-SQL */
            _.Move(WS_WORK_AREAS.WS_DATE.WS_AA_DATE, WS_WORK_AREAS.WS_DATA_H_SQL.WS_ANO_H_SQL);

            /*" -2176- ADD 2000 TO WS-ANO-H-SQL */
            WS_WORK_AREAS.WS_DATA_H_SQL.WS_ANO_H_SQL.Value = WS_WORK_AREAS.WS_DATA_H_SQL.WS_ANO_H_SQL + 2000;

            /*" -2177- MOVE WS-DIA-H-SQL TO WS-DIA-H */
            _.Move(WS_WORK_AREAS.WS_DATA_H_SQL.WS_DIA_H_SQL, WS_WORK_AREAS.WS_DATA_H.WS_DIA_H);

            /*" -2178- MOVE WS-MES-H-SQL TO WS-MES-H */
            _.Move(WS_WORK_AREAS.WS_DATA_H_SQL.WS_MES_H_SQL, WS_WORK_AREAS.WS_DATA_H.WS_MES_H);

            /*" -2180- MOVE WS-ANO-H-SQL TO WS-ANO-H */
            _.Move(WS_WORK_AREAS.WS_DATA_H_SQL.WS_ANO_H_SQL, WS_WORK_AREAS.WS_DATA_H.WS_ANO_H);

            /*" -2181- OPEN OUTPUT MVA1476B. */
            MVA1476B.Open(REG_MVA1476B);

            /*" -2182- OPEN OUTPUT PVA1476B. */
            PVA1476B.Open(REG_PVA1476B);

            /*" -2183- OPEN OUTPUT RVA1476B. */
            RVA1476B.Open(REG_RVA1476B);

            /*" -2184- OPEN OUTPUT M1476BHM. */
            M1476BHM.Open(REG_M1476BHM);

            /*" -2185- OPEN OUTPUT P1476BHM. */
            P1476BHM.Open(REG_P1476BHM);

            /*" -2187- OPEN OUTPUT R1476BHM. */
            R1476BHM.Open(REG_R1476BHM);

            /*" -2188- PERFORM R5200-00-SELECT-PARAM */

            R5200_00_SELECT_PARAM_SECTION();

            /*" -2188- . */

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -2159- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO - 30 DAYS, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO-30, :SISTEMAS-DTCURREN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_30, SISTEMAS_DATA_MOV_ABERTO_30);
                _.Move(executed_1.SISTEMAS_DTCURREN, SISTEMAS_DTCURREN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-RELATORI-SECTION */
        private void R0200_00_SELECT_RELATORI_SECTION()
        {
            /*" -2197- MOVE 'R0200-00      ' TO PARAGRAFO */
            _.Move("R0200-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2198- MOVE 'SELECT RELATORI' TO COMANDO */
            _.Move("SELECT RELATORI", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2200- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2205- PERFORM R0200_00_SELECT_RELATORI_DB_SELECT_1 */

            R0200_00_SELECT_RELATORI_DB_SELECT_1();

            /*" -2208- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2209- DISPLAY 'ERRO DE ACESSO EM RELATORI' */
                _.Display($"ERRO DE ACESSO EM RELATORI");

                /*" -2210- DISPLAY 'SQLCODE  =' SQLCODE */
                _.Display($"SQLCODE  ={DB.SQLCODE}");

                /*" -2211- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2212- END-IF */
            }


            /*" -2214- DISPLAY 'MOVIMENTO DE ' RELATORI-DATA-REFERENCIA ' ATE ' SISTEMAS-DATA-MOV-ABERTO */

            $"MOVIMENTO DE {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA} ATE {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

            /*" -2214- . */

        }

        [StopWatch]
        /*" R0200-00-SELECT-RELATORI-DB-SELECT-1 */
        public void R0200_00_SELECT_RELATORI_DB_SELECT_1()
        {
            /*" -2205- EXEC SQL SELECT DATA_REFERENCIA + 1 DAY INTO :RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'VA1476B' END-EXEC. */

            var r0200_00_SELECT_RELATORI_DB_SELECT_1_Query1 = new R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_RELATORI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-UPDATE-RELATORI-SECTION */
        private void R0300_00_UPDATE_RELATORI_SECTION()
        {
            /*" -2223- MOVE 'R0300-00      ' TO PARAGRAFO */
            _.Move("R0300-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2224- MOVE 'UPDATE RELATORI' TO COMANDO */
            _.Move("UPDATE RELATORI", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2226- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2230- PERFORM R0300_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R0300_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -2233- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2234- DISPLAY 'ERRO DE UPDATE RELATORI' */
                _.Display($"ERRO DE UPDATE RELATORI");

                /*" -2235- DISPLAY 'SQLCODE  =' SQLCODE */
                _.Display($"SQLCODE  ={DB.SQLCODE}");

                /*" -2236- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2237- END-IF */
            }


            /*" -2237- . */

        }

        [StopWatch]
        /*" R0300-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R0300_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -2230- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_REFERENCIA = :SISTEMAS-DATA-MOV-ABERTO WHERE COD_RELATORIO = 'VA1476B' END-EXEC. */

            var r0300_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R0300_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R0300_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r0300_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-MOVDIARIO-SECTION */
        private void R0900_00_DECLARE_MOVDIARIO_SECTION()
        {
            /*" -2246- MOVE 'R0900-00      ' TO PARAGRAFO */
            _.Move("R0900-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2247- MOVE 'R0900-INICIO   ' TO COMANDO */
            _.Move("R0900-INICIO   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2249- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2250- IF WPAR-SIMULACAO = 'SIM' */

            if (WPAR_PARAMETROS.WPAR_SIMULACAO == "SIM")
            {

                /*" -2251- MOVE WPAR-DT-INI TO RELATORI-DATA-REFERENCIA */
                _.Move(WPAR_PARAMETROS.WPAR_DT_INI, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

                /*" -2252- MOVE WPAR-DT-FIM TO SISTEMAS-DATA-MOV-ABERTO */
                _.Move(WPAR_PARAMETROS.WPAR_DT_FIM, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

                /*" -2254- DISPLAY 'RELATORI-DATA-REFERENCIA: ' RELATORI-DATA-REFERENCIA */
                _.Display($"RELATORI-DATA-REFERENCIA: {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

                /*" -2256- DISPLAY 'SISTEMAS-DATA-MOV-ABERTO: ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"SISTEMAS-DATA-MOV-ABERTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -2258- END-IF */
            }


            /*" -2658- PERFORM R0900_00_DECLARE_MOVDIARIO_DB_DECLARE_1 */

            R0900_00_DECLARE_MOVDIARIO_DB_DECLARE_1();

            /*" -2660- PERFORM R0900_00_DECLARE_MOVDIARIO_DB_OPEN_1 */

            R0900_00_DECLARE_MOVDIARIO_DB_OPEN_1();

            /*" -2663- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2664- DISPLAY 'ERRO NO DECLARE DO MOVDIARIO    ' */
                _.Display($"ERRO NO DECLARE DO MOVDIARIO    ");

                /*" -2665- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2666- END-IF */
            }


            /*" -2666- . */

        }

        [StopWatch]
        /*" R0900-00-DECLARE-MOVDIARIO-DB-DECLARE-1 */
        public void R0900_00_DECLARE_MOVDIARIO_DB_DECLARE_1()
        {
            /*" -2658- EXEC SQL DECLARE MOVDIARIO CURSOR FOR ( SELECT NUM_CERTIFICADO , COD_OPERACAO , 0 , 0 , 0 , '0' , 0 FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_APOLICE = 108210871143 AND COD_SUBGRUPO IN (0003, 0004) AND DATA_INCLUSAO >= :RELATORI-DATA-REFERENCIA AND DATA_INCLUSAO <= :SISTEMAS-DATA-MOV-ABERTO ) UNION ( SELECT NUM_CERTIFICADO , COD_OPERACAO , 0 , 0 , 0 , '0' , 0 FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_APOLICE = 97010000889 AND COD_SUBGRUPO IN (3603, 4150, 4190, 1950) AND DATA_INCLUSAO >= :RELATORI-DATA-REFERENCIA AND DATA_INCLUSAO <= :SISTEMAS-DATA-MOV-ABERTO ) UNION ( SELECT COD_CLIENTE, 9999, OCORR_HIST, 0, 0, '0' , 0 FROM SEGUROS.GE_CLIENTES_MOVTO WHERE DATA_ULT_MANUTEN >= :RELATORI-DATA-REFERENCIA AND DATA_ULT_MANUTEN <= :SISTEMAS-DATA-MOV-ABERTO ) UNION ( SELECT NUM_CERTIFICADO , COD_OPERACAO , 0 , 0 , 0 , '0' , 0 FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_APOLICE IN ( 0109300000550,0109300000598,0109300000559, 3009300000559, 3009300001559, 0109300000709,0109300000909,0109300001294, 3009300000909, 3009300001909, 0109300001311,0109300001391,0109300001392, 0109300001393,0109300001394,0109300001553, 0109300001575,0109300001679,0109300001680, 0109300002001,0109300002002, 3009300002002, 3009300012002, 0109300002003,0109300002004,0109300002005, 3009300002003, 3009300002005, 3009300012003, 3009300012005, 0109300002006,0109300002007,0109300002008, 3009300002006, 3009300002008, 3009300012006, 3009300012008, 0109300002010,0109300001966,0109300001970, 3009300002010, 3009300001970, 3009300012010, 3009300011970, 0109300001971,0109300001976,0109300001977, 3009300001971, 3009300001977, 3009300011971, 3009300011977, 0109300001978, 3009300001978, 3009300011978,3009300012344,3009300012358 ) AND DATA_INCLUSAO >= :RELATORI-DATA-REFERENCIA AND DATA_INCLUSAO <= :SISTEMAS-DATA-MOV-ABERTO ) UNION ( SELECT A.NUM_CERTIFICADO, A.COD_OPERACAO , 0 , A.NUM_APOLICE, A.COD_SUBGRUPO, CASE A.COD_OPERACAO WHEN 101 THEN 'I' WHEN 501 THEN 'I' WHEN 0 THEN 'A' WHEN 701 THEN 'A' WHEN 801 THEN 'A' WHEN 895 THEN 'A' WHEN 401 THEN 'E' WHEN 402 THEN 'E' WHEN 402 THEN 'E' WHEN 403 THEN 'E' WHEN 409 THEN 'E' WHEN 412 THEN 'E' WHEN 417 THEN 'E' WHEN 419 THEN 'E' ELSE '#' END ,B.COD_PRODUTO FROM SEGUROS.MOVIMENTO_VGAP A ,SEGUROS.APOLICES B WHERE A.NUM_APOLICE = 3009300007513 AND A.COD_SUBGRUPO IN (1, 2, 3, 4, 5, 6) AND A.DATA_INCLUSAO >= :RELATORI-DATA-REFERENCIA AND A.DATA_INCLUSAO <= :SISTEMAS-DATA-MOV-ABERTO AND A.NUM_APOLICE = B.NUM_APOLICE ) UNION ( SELECT A.NUM_CERTIFICADO, A.COD_OPERACAO , 0 , A.NUM_APOLICE, A.COD_SUBGRUPO, CASE A.COD_OPERACAO WHEN 101 THEN 'I' WHEN 501 THEN 'I' WHEN 0 THEN 'A' WHEN 701 THEN 'A' WHEN 801 THEN 'A' WHEN 895 THEN 'A' WHEN 401 THEN 'E' WHEN 402 THEN 'E' WHEN 402 THEN 'E' WHEN 403 THEN 'E' WHEN 409 THEN 'E' WHEN 412 THEN 'E' WHEN 417 THEN 'E' WHEN 419 THEN 'E' ELSE '#' END ,B.COD_PRODUTO FROM SEGUROS.MOVIMENTO_VGAP A ,SEGUROS.APOLICES B WHERE A.NUM_APOLICE = 3009300007514 AND A.COD_SUBGRUPO IN (1, 2, 3) AND A.DATA_INCLUSAO >= :RELATORI-DATA-REFERENCIA AND A.DATA_INCLUSAO <= :SISTEMAS-DATA-MOV-ABERTO AND A.NUM_APOLICE = B.NUM_APOLICE ) UNION ( SELECT A.NUM_BILHETE , 8888 , A.OCORR_ENDERECO , 0, 0, '0' , B.COD_PRODUTO FROM SEGUROS.BILHETE A, SEGUROS.ENDOSSOS B WHERE B.DATA_EMISSAO >= :RELATORI-DATA-REFERENCIA AND B.DATA_EMISSAO <= :SISTEMAS-DATA-MOV-ABERTO AND B.COD_PRODUTO IN (8201, 8202, 8102, 8103, 8104, 8108, 8112, 8113, 3709, 8114, 8116, 8117, 8118, 8119, 8121, 8122, 8123, 8115, 8120, 8124, 8125, 8132, 8139, 8126, 8127, 8128, 8138, 3701, 8521, 8528, 8529 ,8530, 8531, 8532 ,8533, 8534 ,:JVPRD3701 ,:JVPRD3709 ,:JVPRD8114 ,:JVPRD8115 ,:JVPRD8116 ,:JVPRD8117 ,:JVPRD8118 ,:JVPRD8119 ,:JVPRD8120 ,:JVPRD8121 ,:JVPRD8122 ,:JVPRD8123 ) AND B.NUM_APOLICE = A.NUM_APOLICE AND A.SITUACAO = '9' AND A.RAMO IN (37, 81, 82) AND B.RAMO_EMISSOR = A.RAMO AND B.COD_PRODUTO = A.COD_PRODUTO ) UNION ( SELECT A.NUM_CERTIFICADO , 9998 , 0 , A.NUM_APOLICE , A.COD_SUBGRUPO , CASE A.COD_OPERACAO WHEN 101 THEN 'I' WHEN 501 THEN 'I' WHEN 0 THEN 'A' WHEN 701 THEN 'A' WHEN 801 THEN 'A' WHEN 895 THEN 'A' WHEN 401 THEN 'E' WHEN 402 THEN 'E' WHEN 402 THEN 'E' WHEN 403 THEN 'E' WHEN 409 THEN 'E' WHEN 412 THEN 'E' WHEN 417 THEN 'E' WHEN 419 THEN 'E' ELSE '#' END , B.COD_PRODUTO FROM SEGUROS.MOVIMENTO_VGAP A, SEGUROS.APOLICES B WHERE A.NUM_APOLICE IN (108211251755 ,3009300006739 ,3009300006746 ,3009300006773 ,109300001980 ,109300001521 ,3009300006515 ,109300003228 ,108211034287 ,109300003658) AND A.NUM_APOLICE = B.NUM_APOLICE AND A.DATA_OPERACAO >= :RELATORI-DATA-REFERENCIA AND A.DATA_OPERACAO <= :SISTEMAS-DATA-MOV-ABERTO AND NOT EXISTS (SELECT D.NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA D WHERE D.NUM_CERTIFICADO = A.NUM_CERTIFICADO) ) UNION ( SELECT A.NUM_CERTIFICADO , 9998 , 0 , A.NUM_APOLICE , A.COD_SUBGRUPO , '0' , B.COD_PRODUTO FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PRODUTOS_VG B WHERE A.SIT_REGISTRO = '0' AND A.NUM_APOLICE NOT IN(108211251755 ,3009300006739 ,3009300006746 ,3009300006773 ,109300001980 ,109300001521 ,3009300006515 ,109300003228 ,108211034287 ,109300003658) AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND B.ORIG_PRODU = 'ESPEC' AND DATA_INIVIGENCIA >= :RELATORI-DATA-REFERENCIA AND DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND NOT EXISTS (SELECT C.NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA C WHERE C.NUM_CERTIFICADO = A.NUM_CERTIFICADO) ) UNION ( SELECT A.NUM_CERTIFICADO , A.COD_OPERACAO , 0 , A.NUM_APOLICE , 0 , '0' , 0 FROM SEGUROS.MOVIMENTO_VGAP A , SEGUROS.VG_COBERTURAS_SUBG B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.NUM_APOLICE IN (0109300001980, 0109300003691, 0109300003692) AND A.DATA_INCLUSAO >= :RELATORI-DATA-REFERENCIA AND A.DATA_INCLUSAO <= :SISTEMAS-DATA-MOV-ABERTO AND B.COD_COBERTURA = 2 AND B.COD_SUBGRUPO = 2 ) UNION ( SELECT A.NUM_CERTIFICADO , A.COD_OPERACAO , 0 , A.NUM_APOLICE , A.COD_SUBGRUPO , B.TIPO_MOVIMENTO , A.COD_PRODUTO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.MOVIMENTO_EA B, SEGUROS.CLIENTES C WHERE A.COD_PRODUTO IN (8205, 9329, 8209, 9343 ,:JVPRD8205 ,:JVPRD9329 ,:JVPRD9343 ,:JVPRD8209 ) AND A.NUM_APOLICE NOT IN ( 3008211398371 ,3008211398372 ,3009300007527 ,3009300007528) AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND DATE(B.TIMESTAMP) >= :RELATORI-DATA-REFERENCIA AND DATE(B.TIMESTAMP) <= :SISTEMAS-DATA-MOV-ABERTO AND A.COD_CLIENTE = C.COD_CLIENTE AND C.TIPO_PESSOA = 'J' AND B.NSAS = (SELECT MAX(D.NSAS) FROM SEGUROS.MOVIMENTO_EA D WHERE D.NUM_CERTIFICADO = B.NUM_CERTIFICADO) ) UNION ( SELECT A.NUM_CERTIFICADO ,A.COD_OPERACAO ,0 ,A.NUM_APOLICE ,A.COD_SUBGRUPO ,B.TIPO_MOVIMENTO ,A.COD_PRODUTO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.MOVIMENTO_EA B, SEGUROS.CLIENTES C WHERE A.COD_PRODUTO IN ( :JVPRD8205 ,:JVPRD9329 ,:JVPRD9343 ,:JVPRD8209 ) AND A.NUM_APOLICE IN ( 3008211398371 ,3008211398372 ,3009300007527 ,3009300007528) AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND DATE(B.TIMESTAMP) >= :RELATORI-DATA-REFERENCIA AND DATE(B.TIMESTAMP) <= :SISTEMAS-DATA-MOV-ABERTO AND A.COD_CLIENTE = C.COD_CLIENTE AND C.TIPO_PESSOA = 'J' AND B.NSAS = (SELECT MAX(D.NSAS) FROM SEGUROS.MOVIMENTO_EA D WHERE D.NUM_CERTIFICADO = B.NUM_CERTIFICADO) ) UNION ( SELECT A.NUM_CERTIFICADO , A.COD_OPERACAO , 0 , 0 , 0 , B.TIPO_MOVIMENTO , A.COD_PRODUTO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.MOVIMENTO_EA B WHERE A.COD_PRODUTO = 8217 AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND DATE(B.TIMESTAMP) >= :RELATORI-DATA-REFERENCIA AND DATE(B.TIMESTAMP) <= :SISTEMAS-DATA-MOV-ABERTO AND B.NSAS = (SELECT MAX(C.NSAS) FROM SEGUROS.MOVIMENTO_EA C WHERE C.NUM_CERTIFICADO = B.NUM_CERTIFICADO) ) END-EXEC. */
            MOVDIARIO = new VA1476B_MOVDIARIO(true);
            string GetQuery_MOVDIARIO()
            {
                var query = @$"( 
							SELECT NUM_CERTIFICADO
							, 
							COD_OPERACAO
							, 
							0
							, 
							0
							, 
							0
							, 
							'0' 
							, 0 
							FROM 
							SEGUROS.MOVIMENTO_VGAP 
							WHERE NUM_APOLICE = 108210871143 
							AND COD_SUBGRUPO IN (0003
							, 0004) 
							AND DATA_INCLUSAO >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND DATA_INCLUSAO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							) 
							UNION 
							( 
							SELECT NUM_CERTIFICADO
							, 
							COD_OPERACAO
							, 
							0
							, 
							0
							, 
							0
							, 
							'0' 
							, 0 
							FROM 
							SEGUROS.MOVIMENTO_VGAP 
							WHERE NUM_APOLICE = 97010000889 
							AND COD_SUBGRUPO IN (3603
							, 4150
							, 4190
							, 1950) 
							AND DATA_INCLUSAO >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND DATA_INCLUSAO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							) 
							UNION 
							( 
							SELECT COD_CLIENTE
							, 
							9999
							, 
							OCORR_HIST
							, 
							0
							, 
							0
							, 
							'0' 
							, 0 
							FROM 
							SEGUROS.GE_CLIENTES_MOVTO 
							WHERE 
							DATA_ULT_MANUTEN >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND DATA_ULT_MANUTEN <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							) 
							UNION 
							( 
							SELECT NUM_CERTIFICADO
							, 
							COD_OPERACAO
							, 
							0
							, 
							0
							, 
							0
							, 
							'0' 
							, 0 
							FROM 
							SEGUROS.MOVIMENTO_VGAP 
							WHERE NUM_APOLICE IN ( 
							0109300000550
							,0109300000598
							,0109300000559
							, 
							3009300000559
							, 
							3009300001559
							, 
							0109300000709
							,0109300000909
							,0109300001294
							, 
							3009300000909
							, 
							3009300001909
							, 
							0109300001311
							,0109300001391
							,0109300001392
							, 
							0109300001393
							,0109300001394
							,0109300001553
							, 
							0109300001575
							,0109300001679
							,0109300001680
							, 
							0109300002001
							,0109300002002
							, 
							3009300002002
							, 
							3009300012002
							, 
							0109300002003
							,0109300002004
							,0109300002005
							, 
							3009300002003
							, 3009300002005
							, 
							3009300012003
							, 3009300012005
							, 
							0109300002006
							,0109300002007
							,0109300002008
							, 
							3009300002006
							, 3009300002008
							, 
							3009300012006
							, 3009300012008
							, 
							0109300002010
							,0109300001966
							,0109300001970
							, 
							3009300002010
							, 3009300001970
							, 
							3009300012010
							, 3009300011970
							, 
							0109300001971
							,0109300001976
							,0109300001977
							, 
							3009300001971
							, 3009300001977
							, 
							3009300011971
							, 3009300011977
							, 
							0109300001978
							, 
							3009300001978
							, 
							3009300011978
							,3009300012344
							,3009300012358 
							) 
							AND DATA_INCLUSAO >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND DATA_INCLUSAO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							) 
							UNION 
							( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.COD_OPERACAO
							, 
							0
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							CASE A.COD_OPERACAO 
							WHEN 101 THEN 'I' 
							WHEN 501 THEN 'I' 
							WHEN 0 THEN 'A' 
							WHEN 701 THEN 'A' 
							WHEN 801 THEN 'A' 
							WHEN 895 THEN 'A' 
							WHEN 401 THEN 'E' 
							WHEN 402 THEN 'E' 
							WHEN 402 THEN 'E' 
							WHEN 403 THEN 'E' 
							WHEN 409 THEN 'E' 
							WHEN 412 THEN 'E' 
							WHEN 417 THEN 'E' 
							WHEN 419 THEN 'E' 
							ELSE '#' 
							END 
							,B.COD_PRODUTO 
							FROM 
							SEGUROS.MOVIMENTO_VGAP A 
							,SEGUROS.APOLICES B 
							WHERE 
							A.NUM_APOLICE = 3009300007513 
							AND A.COD_SUBGRUPO IN (1
							, 2
							, 3
							, 4
							, 5
							, 6) 
							AND A.DATA_INCLUSAO >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND A.DATA_INCLUSAO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							) 
							UNION 
							( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.COD_OPERACAO
							, 
							0
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							CASE A.COD_OPERACAO 
							WHEN 101 THEN 'I' 
							WHEN 501 THEN 'I' 
							WHEN 0 THEN 'A' 
							WHEN 701 THEN 'A' 
							WHEN 801 THEN 'A' 
							WHEN 895 THEN 'A' 
							WHEN 401 THEN 'E' 
							WHEN 402 THEN 'E' 
							WHEN 402 THEN 'E' 
							WHEN 403 THEN 'E' 
							WHEN 409 THEN 'E' 
							WHEN 412 THEN 'E' 
							WHEN 417 THEN 'E' 
							WHEN 419 THEN 'E' 
							ELSE '#' 
							END 
							,B.COD_PRODUTO 
							FROM 
							SEGUROS.MOVIMENTO_VGAP A 
							,SEGUROS.APOLICES B 
							WHERE 
							A.NUM_APOLICE = 3009300007514 
							AND A.COD_SUBGRUPO IN (1
							, 2
							, 3) 
							AND A.DATA_INCLUSAO >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND A.DATA_INCLUSAO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							) 
							UNION 
							( 
							SELECT A.NUM_BILHETE
							, 
							8888
							, 
							A.OCORR_ENDERECO
							, 
							0
							, 
							0
							, 
							'0' 
							, B.COD_PRODUTO 
							FROM SEGUROS.BILHETE A
							, 
							SEGUROS.ENDOSSOS B 
							WHERE B.DATA_EMISSAO >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND B.DATA_EMISSAO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.COD_PRODUTO IN 
							(8201
							, 8202
							, 8102
							, 8103
							, 8104
							, 8108
							, 8112
							, 8113
							, 3709
							, 
							8114
							, 8116
							, 8117
							, 8118
							, 8119
							, 8121
							, 8122
							, 8123
							, 
							8115
							, 8120
							, 8124
							, 8125
							, 8132
							, 8139
							, 
							8126
							, 8127
							, 8128
							, 8138
							, 3701
							, 
							8521
							, 8528
							, 8529 
							,8530
							, 8531
							, 8532 
							,8533
							, 8534 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD3701}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD3709}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8114}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8115}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8116}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8117}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8118}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8119}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8120}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8121}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8122}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8123}' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND A.SITUACAO = '9' 
							AND A.RAMO IN (37
							, 81
							, 82) 
							AND B.RAMO_EMISSOR = A.RAMO 
							AND B.COD_PRODUTO = A.COD_PRODUTO 
							) 
							UNION 
							( 
							SELECT A.NUM_CERTIFICADO
							, 
							9998
							, 
							0
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							CASE A.COD_OPERACAO 
							WHEN 101 THEN 'I' 
							WHEN 501 THEN 'I' 
							WHEN 0 THEN 'A' 
							WHEN 701 THEN 'A' 
							WHEN 801 THEN 'A' 
							WHEN 895 THEN 'A' 
							WHEN 401 THEN 'E' 
							WHEN 402 THEN 'E' 
							WHEN 402 THEN 'E' 
							WHEN 403 THEN 'E' 
							WHEN 409 THEN 'E' 
							WHEN 412 THEN 'E' 
							WHEN 417 THEN 'E' 
							WHEN 419 THEN 'E' 
							ELSE '#' 
							END
							, 
							B.COD_PRODUTO 
							FROM SEGUROS.MOVIMENTO_VGAP A
							, 
							SEGUROS.APOLICES B 
							WHERE A.NUM_APOLICE IN (108211251755 
							,3009300006739 
							,3009300006746 
							,3009300006773 
							,109300001980 
							,109300001521 
							,3009300006515 
							,109300003228 
							,108211034287 
							,109300003658) 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.DATA_OPERACAO >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND A.DATA_OPERACAO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND NOT EXISTS 
							(SELECT D.NUM_CERTIFICADO 
							FROM SEGUROS.PROPOSTAS_VA D 
							WHERE D.NUM_CERTIFICADO = A.NUM_CERTIFICADO) 
							) 
							UNION 
							( 
							SELECT A.NUM_CERTIFICADO
							, 
							9998
							, 
							0
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							'0' 
							, B.COD_PRODUTO 
							FROM 
							SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE A.SIT_REGISTRO = '0' 
							AND A.NUM_APOLICE NOT IN(108211251755 
							,3009300006739 
							,3009300006746 
							,3009300006773 
							,109300001980 
							,109300001521 
							,3009300006515 
							,109300003228 
							,108211034287 
							,109300003658) 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND B.ORIG_PRODU = 'ESPEC' 
							AND DATA_INIVIGENCIA >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND DATA_INIVIGENCIA <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND NOT EXISTS 
							(SELECT C.NUM_CERTIFICADO 
							FROM SEGUROS.PROPOSTAS_VA C 
							WHERE C.NUM_CERTIFICADO = A.NUM_CERTIFICADO) 
							) 
							UNION 
							( 
							SELECT A.NUM_CERTIFICADO 
							, A.COD_OPERACAO 
							, 0 
							, A.NUM_APOLICE 
							, 0 
							, '0' 
							, 0 
							FROM SEGUROS.MOVIMENTO_VGAP A 
							, SEGUROS.VG_COBERTURAS_SUBG B 
							WHERE A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND A.NUM_APOLICE IN (0109300001980
							, 
							0109300003691
							, 
							0109300003692) 
							AND A.DATA_INCLUSAO >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND A.DATA_INCLUSAO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.COD_COBERTURA = 2 
							AND B.COD_SUBGRUPO = 2 
							) 
							UNION 
							( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.COD_OPERACAO
							, 
							0
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							B.TIPO_MOVIMENTO 
							, A.COD_PRODUTO 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.MOVIMENTO_EA B
							, 
							SEGUROS.CLIENTES C 
							WHERE A.COD_PRODUTO IN (8205
							, 9329
							, 8209
							, 9343 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8205}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD9329}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD9343}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8209}' ) 
							AND A.NUM_APOLICE NOT IN ( 3008211398371 
							,3008211398372 
							,3009300007527 
							,3009300007528) 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND DATE(B.TIMESTAMP) >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND DATE(B.TIMESTAMP) <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.COD_CLIENTE = C.COD_CLIENTE 
							AND C.TIPO_PESSOA = 'J' 
							AND B.NSAS = 
							(SELECT MAX(D.NSAS) 
							FROM SEGUROS.MOVIMENTO_EA D 
							WHERE D.NUM_CERTIFICADO = B.NUM_CERTIFICADO) 
							) 
							UNION 
							( 
							SELECT A.NUM_CERTIFICADO 
							,A.COD_OPERACAO 
							,0 
							,A.NUM_APOLICE 
							,A.COD_SUBGRUPO 
							,B.TIPO_MOVIMENTO 
							,A.COD_PRODUTO 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.MOVIMENTO_EA B
							, 
							SEGUROS.CLIENTES C 
							WHERE A.COD_PRODUTO IN ( '{JVBKINCL.JV_PRODUTOS.JVPRD8205}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD9329}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD9343}' 
							,'{JVBKINCL.JV_PRODUTOS.JVPRD8209}' ) 
							AND A.NUM_APOLICE IN ( 3008211398371 
							,3008211398372 
							,3009300007527 
							,3009300007528) 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND DATE(B.TIMESTAMP) >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND DATE(B.TIMESTAMP) <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.COD_CLIENTE = C.COD_CLIENTE 
							AND C.TIPO_PESSOA = 'J' 
							AND B.NSAS = 
							(SELECT MAX(D.NSAS) 
							FROM SEGUROS.MOVIMENTO_EA D 
							WHERE D.NUM_CERTIFICADO = B.NUM_CERTIFICADO) 
							) 
							UNION 
							( 
							SELECT A.NUM_CERTIFICADO
							, 
							A.COD_OPERACAO
							, 
							0
							, 
							0
							, 
							0
							, 
							B.TIPO_MOVIMENTO 
							, A.COD_PRODUTO 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.MOVIMENTO_EA B 
							WHERE A.COD_PRODUTO = 8217 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND DATE(B.TIMESTAMP) >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND DATE(B.TIMESTAMP) <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.NSAS = 
							(SELECT MAX(C.NSAS) 
							FROM SEGUROS.MOVIMENTO_EA C 
							WHERE C.NUM_CERTIFICADO = B.NUM_CERTIFICADO) 
							)";

                return query;
            }
            MOVDIARIO.GetQueryEvent += GetQuery_MOVDIARIO;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-MOVDIARIO-DB-OPEN-1 */
        public void R0900_00_DECLARE_MOVDIARIO_DB_OPEN_1()
        {
            /*" -2660- EXEC SQL OPEN MOVDIARIO END-EXEC. */

            MOVDIARIO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-MOVDIARIO-SECTION */
        private void R0910_00_FETCH_MOVDIARIO_SECTION()
        {
            /*" -2675- MOVE 'R0910-00-LER-FETCH   ' TO PARAGRAFO */
            _.Move("R0910-00-LER-FETCH   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2677- MOVE 'FETCH            ' TO COMANDO */
            _.Move("FETCH            ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2686- PERFORM R0910_00_FETCH_MOVDIARIO_DB_FETCH_1 */

            R0910_00_FETCH_MOVDIARIO_DB_FETCH_1();

            /*" -2689- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2690- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2691- MOVE 'S' TO WFIM-MOVDIARIO */
                    _.Move("S", WS_WORK_AREAS.WFIM_MOVDIARIO);

                    /*" -2691- PERFORM R0910_00_FETCH_MOVDIARIO_DB_CLOSE_1 */

                    R0910_00_FETCH_MOVDIARIO_DB_CLOSE_1();

                    /*" -2693- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -2694- ELSE */
                }
                else
                {


                    /*" -2695- DISPLAY 'ERRO LER MOVDIARIO' */
                    _.Display($"ERRO LER MOVDIARIO");

                    /*" -2696- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2697- END-IF */
                }


                /*" -2699- END-IF */
            }


            /*" -2700- IF WS-DISPLAY-8530 = 'N' */

            if (WS_WORK_AREAS.WS_DISPLAY_8530 == "N")
            {

                /*" -2701- IF MOVIMVGA-COD-OPERACAO = 8888 AND WS-COD-PRODUTO = 8530 */

                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 8888 && WS_COD_PRODUTO == 8530)
                {

                    /*" -2702- DISPLAY 'PARAGRAFO: ' PARAGRAFO */
                    _.Display($"PARAGRAFO: {WABEND.LOCALIZA_ABEND_1.PARAGRAFO}");

                    /*" -2704- DISPLAY 'MOVIMVGA-NUM-CERTIFICADO: ' MOVIMVGA-NUM-CERTIFICADO */
                    _.Display($"MOVIMVGA-NUM-CERTIFICADO: {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                    /*" -2706- DISPLAY 'MOVIMVGA-COD-OPERACAO  : ' MOVIMVGA-COD-OPERACAO */
                    _.Display($"MOVIMVGA-COD-OPERACAO  : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO}");

                    /*" -2708- DISPLAY 'MOVIMVGA-OCORR-ENDERECO: ' MOVIMVGA-OCORR-ENDERECO */
                    _.Display($"MOVIMVGA-OCORR-ENDERECO: {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO}");

                    /*" -2710- DISPLAY 'MOVIMVGA-NUM-APOLICE   : ' MOVIMVGA-NUM-APOLICE */
                    _.Display($"MOVIMVGA-NUM-APOLICE   : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

                    /*" -2712- DISPLAY 'MOVIMVGA-COD-SUBGRUPO  : ' MOVIMVGA-COD-SUBGRUPO */
                    _.Display($"MOVIMVGA-COD-SUBGRUPO  : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO}");

                    /*" -2714- DISPLAY 'WHOST-TIPO-MOVIMENTO   : ' WHOST-TIPO-MOVIMENTO */
                    _.Display($"WHOST-TIPO-MOVIMENTO   : {WHOST_TIPO_MOVIMENTO}");

                    /*" -2715- DISPLAY 'WS-COD-PRODUTO         : ' WS-COD-PRODUTO */
                    _.Display($"WS-COD-PRODUTO         : {WS_COD_PRODUTO}");

                    /*" -2716- MOVE 'S' TO WS-DISPLAY-8530 */
                    _.Move("S", WS_WORK_AREAS.WS_DISPLAY_8530);

                    /*" -2717- END-IF */
                }


                /*" -2718- END-IF */
            }


            /*" -2719- IF WS-DISPLAY-8531 = 'N' */

            if (WS_WORK_AREAS.WS_DISPLAY_8531 == "N")
            {

                /*" -2720- IF MOVIMVGA-COD-OPERACAO = 8888 AND WS-COD-PRODUTO = 8531 */

                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 8888 && WS_COD_PRODUTO == 8531)
                {

                    /*" -2721- DISPLAY 'PARAGRAFO: ' PARAGRAFO */
                    _.Display($"PARAGRAFO: {WABEND.LOCALIZA_ABEND_1.PARAGRAFO}");

                    /*" -2723- DISPLAY 'MOVIMVGA-NUM-CERTIFICADO: ' MOVIMVGA-NUM-CERTIFICADO */
                    _.Display($"MOVIMVGA-NUM-CERTIFICADO: {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                    /*" -2725- DISPLAY 'MOVIMVGA-COD-OPERACAO  : ' MOVIMVGA-COD-OPERACAO */
                    _.Display($"MOVIMVGA-COD-OPERACAO  : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO}");

                    /*" -2727- DISPLAY 'MOVIMVGA-OCORR-ENDERECO: ' MOVIMVGA-OCORR-ENDERECO */
                    _.Display($"MOVIMVGA-OCORR-ENDERECO: {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO}");

                    /*" -2729- DISPLAY 'MOVIMVGA-NUM-APOLICE   : ' MOVIMVGA-NUM-APOLICE */
                    _.Display($"MOVIMVGA-NUM-APOLICE   : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

                    /*" -2731- DISPLAY 'MOVIMVGA-COD-SUBGRUPO  : ' MOVIMVGA-COD-SUBGRUPO */
                    _.Display($"MOVIMVGA-COD-SUBGRUPO  : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO}");

                    /*" -2733- DISPLAY 'WHOST-TIPO-MOVIMENTO   : ' WHOST-TIPO-MOVIMENTO */
                    _.Display($"WHOST-TIPO-MOVIMENTO   : {WHOST_TIPO_MOVIMENTO}");

                    /*" -2734- DISPLAY 'WS-COD-PRODUTO         : ' WS-COD-PRODUTO */
                    _.Display($"WS-COD-PRODUTO         : {WS_COD_PRODUTO}");

                    /*" -2735- MOVE 'S' TO WS-DISPLAY-8531 */
                    _.Move("S", WS_WORK_AREAS.WS_DISPLAY_8531);

                    /*" -2736- END-IF */
                }


                /*" -2737- END-IF */
            }


            /*" -2738- IF WS-DISPLAY-8532 = 'N' */

            if (WS_WORK_AREAS.WS_DISPLAY_8532 == "N")
            {

                /*" -2739- IF MOVIMVGA-COD-OPERACAO = 8888 AND WS-COD-PRODUTO = 8532 */

                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 8888 && WS_COD_PRODUTO == 8532)
                {

                    /*" -2740- DISPLAY 'PARAGRAFO: ' PARAGRAFO */
                    _.Display($"PARAGRAFO: {WABEND.LOCALIZA_ABEND_1.PARAGRAFO}");

                    /*" -2742- DISPLAY 'MOVIMVGA-NUM-CERTIFICADO: ' MOVIMVGA-NUM-CERTIFICADO */
                    _.Display($"MOVIMVGA-NUM-CERTIFICADO: {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                    /*" -2744- DISPLAY 'MOVIMVGA-COD-OPERACAO  : ' MOVIMVGA-COD-OPERACAO */
                    _.Display($"MOVIMVGA-COD-OPERACAO  : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO}");

                    /*" -2746- DISPLAY 'MOVIMVGA-OCORR-ENDERECO: ' MOVIMVGA-OCORR-ENDERECO */
                    _.Display($"MOVIMVGA-OCORR-ENDERECO: {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO}");

                    /*" -2748- DISPLAY 'MOVIMVGA-NUM-APOLICE   : ' MOVIMVGA-NUM-APOLICE */
                    _.Display($"MOVIMVGA-NUM-APOLICE   : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

                    /*" -2750- DISPLAY 'MOVIMVGA-COD-SUBGRUPO  : ' MOVIMVGA-COD-SUBGRUPO */
                    _.Display($"MOVIMVGA-COD-SUBGRUPO  : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO}");

                    /*" -2752- DISPLAY 'WHOST-TIPO-MOVIMENTO   : ' WHOST-TIPO-MOVIMENTO */
                    _.Display($"WHOST-TIPO-MOVIMENTO   : {WHOST_TIPO_MOVIMENTO}");

                    /*" -2753- DISPLAY 'WS-COD-PRODUTO         : ' WS-COD-PRODUTO */
                    _.Display($"WS-COD-PRODUTO         : {WS_COD_PRODUTO}");

                    /*" -2754- MOVE 'S' TO WS-DISPLAY-8532 */
                    _.Move("S", WS_WORK_AREAS.WS_DISPLAY_8532);

                    /*" -2755- END-IF */
                }


                /*" -2756- END-IF */
            }


            /*" -2756- . */

        }

        [StopWatch]
        /*" R0910-00-FETCH-MOVDIARIO-DB-FETCH-1 */
        public void R0910_00_FETCH_MOVDIARIO_DB_FETCH_1()
        {
            /*" -2686- EXEC SQL FETCH MOVDIARIO INTO :MOVIMVGA-NUM-CERTIFICADO , :MOVIMVGA-COD-OPERACAO , :MOVIMVGA-OCORR-ENDERECO , :MOVIMVGA-NUM-APOLICE , :MOVIMVGA-COD-SUBGRUPO , :WHOST-TIPO-MOVIMENTO , :WS-COD-PRODUTO END-EXEC. */

            if (MOVDIARIO.Fetch())
            {
                _.Move(MOVDIARIO.MOVIMVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);
                _.Move(MOVDIARIO.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
                _.Move(MOVDIARIO.MOVIMVGA_OCORR_ENDERECO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO);
                _.Move(MOVDIARIO.MOVIMVGA_NUM_APOLICE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE);
                _.Move(MOVDIARIO.MOVIMVGA_COD_SUBGRUPO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO);
                _.Move(MOVDIARIO.WHOST_TIPO_MOVIMENTO, WHOST_TIPO_MOVIMENTO);
                _.Move(MOVDIARIO.WS_COD_PRODUTO, WS_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-MOVDIARIO-DB-CLOSE-1 */
        public void R0910_00_FETCH_MOVDIARIO_DB_CLOSE_1()
        {
            /*" -2691- EXEC SQL CLOSE MOVDIARIO END-EXEC */

            MOVDIARIO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSAMENTO-SECTION */
        private void R1000_00_PROCESSAMENTO_SECTION()
        {
            /*" -2765- MOVE 'R1000-00-PROCESSA    ' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2774- MOVE 'PROCESSA         ' TO COMANDO. */
            _.Move("PROCESSA         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2782- IF (MOVIMVGA-COD-OPERACAO GREATER 99 AND MOVIMVGA-COD-OPERACAO LESS 200) OR (MOVIMVGA-COD-OPERACAO GREATER 399 AND MOVIMVGA-COD-OPERACAO LESS 900) OR (MOVIMVGA-COD-OPERACAO EQUAL 9999) OR (MOVIMVGA-COD-OPERACAO EQUAL 8888) OR (MOVIMVGA-COD-OPERACAO EQUAL 9998) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200) || (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 399 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 900) || (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999) || (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 8888) || (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998))
            {

                /*" -2783- CONTINUE */

                /*" -2784- ELSE */
            }
            else
            {


                /*" -2785- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2787- END-IF */
            }


            /*" -2788- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
            {

                /*" -2790- PERFORM R1020-00-SELECT-PROPOVA */

                R1020_00_SELECT_PROPOVA_SECTION();

                /*" -2791- IF (WTEM-PROPOVA EQUAL 'SIM' ) */

                if ((WTEM_PROPOVA == "SIM"))
                {

                    /*" -2792- CONTINUE */

                    /*" -2793- ELSE */
                }
                else
                {


                    /*" -2794- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -2795- END-IF */
                }


                /*" -2797- END-IF */
            }


            /*" -2799- IF (MOVIMVGA-COD-OPERACAO = 9998) AND (MOVIMVGA-NUM-APOLICE NOT EQUAL 108211251755) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.GetMoveValues().ToInt() != 108211251755))
            {

                /*" -2801- PERFORM R1050-00-SEL-VGCOBSUB */

                R1050_00_SEL_VGCOBSUB_SECTION();

                /*" -2802- IF (WS-TEM-VGCOBSUB EQUAL 'N' ) */

                if ((WS_WORK_AREAS.WS_TEM_VGCOBSUB == "N"))
                {

                    /*" -2803- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -2804- END-IF */
                }


                /*" -2806- END-IF */
            }


            /*" -2807- IF (MOVIMVGA-COD-OPERACAO EQUAL 8888) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 8888))
            {

                /*" -2808- PERFORM R1040-00-SELECT-BILHETE */

                R1040_00_SELECT_BILHETE_SECTION();

                /*" -2809- ELSE */
            }
            else
            {


                /*" -2812- IF (MOVIMVGA-COD-OPERACAO EQUAL 9998) OR (MOVIMVGA-NUM-APOLICE EQUAL 0109300001980 OR 0109300003691 OR 0109300003692) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) || (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.In("0109300001980", "0109300003691", "0109300003692")))
                {

                    /*" -2813- PERFORM R1060-00-SELECT-SEGURVGA */

                    R1060_00_SELECT_SEGURVGA_SECTION();

                    /*" -2814- ELSE */
                }
                else
                {


                    /*" -2815- PERFORM R1010-00-SELECT-PROPOVA */

                    R1010_00_SELECT_PROPOVA_SECTION();

                    /*" -2816- MOVE PROPOVA-COD-PRODUTO TO WS-COD-PRODUTO */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, WS_COD_PRODUTO);

                    /*" -2817- END-IF */
                }


                /*" -2819- END-IF */
            }


            /*" -2820- IF PROPOVA-NUM-APOLICE EQUAL 109300000959 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300000959)
            {

                /*" -2821- IF (PROPOVA-DATA-QUITACAO > '2008-08-31' ) */

                if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO > "2008-08-31"))
                {

                    /*" -2822- CONTINUE */

                    /*" -2823- ELSE */
                }
                else
                {


                    /*" -2824- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -2825- END-IF */
                }


                /*" -2827- END-IF */
            }


            /*" -2828- PERFORM R1100-00-SELECT-CLIENTE */

            R1100_00_SELECT_CLIENTE_SECTION();

            /*" -2830- PERFORM R1200-00-SELECT-ENDERECO */

            R1200_00_SELECT_ENDERECO_SECTION();

            /*" -2831- IF (MOVIMVGA-COD-OPERACAO = 9999) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
            {

                /*" -2832- PERFORM R1030-00-SELECT-GECLIMOV */

                R1030_00_SELECT_GECLIMOV_SECTION();

                /*" -2833- IF WTEM-PROPOVA = 'SIM' */

                if (WTEM_PROPOVA == "SIM")
                {

                    /*" -2834- CONTINUE */

                    /*" -2835- ELSE */
                }
                else
                {


                    /*" -2836- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -2837- END-IF */
                }


                /*" -2839- END-IF */
            }


            /*" -2850- IF (PROPOVA-NUM-APOLICE EQUAL 109300000959 ) OR (MOVIMVGA-COD-OPERACAO EQUAL 8888) OR (MOVIMVGA-COD-OPERACAO EQUAL 9998) OR (PROPOVA-COD-PRODUTO EQUAL 8205) OR (PROPOVA-COD-PRODUTO EQUAL JVPRD8205) OR (PROPOVA-COD-PRODUTO EQUAL 9329) OR (PROPOVA-COD-PRODUTO EQUAL JVPRD9329) OR (PROPOVA-COD-PRODUTO EQUAL 8209) OR (PROPOVA-COD-PRODUTO EQUAL JVPRD8209) OR (PROPOVA-COD-PRODUTO EQUAL 9343) OR (PROPOVA-COD-PRODUTO EQUAL JVPRD9343) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300000959) || (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 8888) || (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8205) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD8205) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9329) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9329) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8209) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD8209) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9343) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9343))
            {

                /*" -2851- CONTINUE */

                /*" -2852- ELSE */
            }
            else
            {


                /*" -2854- PERFORM R1300-00-SELECT-SEGURVGA */

                R1300_00_SELECT_SEGURVGA_SECTION();

                /*" -2855- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2856- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -2857- END-IF */
                }


                /*" -2859- END-IF */
            }


            /*" -2860- IF (PROPOVA-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE != WS_NUM_APOLICE_ANT))
            {

                /*" -2861- MOVE PROPOVA-NUM-APOLICE TO WS-NUM-APOLICE-ANT */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, WS_NUM_APOLICE_ANT);

                /*" -2863- PERFORM R1400-00-SELECT-ENDOSSO */

                R1400_00_SELECT_ENDOSSO_SECTION();

                /*" -2864- IF (WTEM-ENDOSSO EQUAL 'NAO' ) */

                if ((WS_WORK_AREAS.WTEM_ENDOSSO == "NAO"))
                {

                    /*" -2868- PERFORM R0910-00-FETCH-MOVDIARIO UNTIL WFIM-MOVDIARIO NOT EQUAL SPACES OR PROPOVA-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT */

                    while (!(!WS_WORK_AREAS.WFIM_MOVDIARIO.IsEmpty() || PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE != WS_NUM_APOLICE_ANT))
                    {

                        R0910_00_FETCH_MOVDIARIO_SECTION();
                    }

                    /*" -2869- GO TO R1000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;

                    /*" -2870- END-IF */
                }


                /*" -2872- END-IF */
            }


            /*" -2877- ADD 1 TO WS-TOTAL-LIDOS WS-TOTAL-CONTA */
            WS_WORK_AREAS.WS_TOTAL_LIDOS.Value = WS_WORK_AREAS.WS_TOTAL_LIDOS + 1;
            WS_WORK_AREAS.WS_TOTAL_CONTA.Value = WS_WORK_AREAS.WS_TOTAL_CONTA + 1;

            /*" -2878- IF (WS-TOTAL-CONTA > 999) */

            if ((WS_WORK_AREAS.WS_TOTAL_CONTA > 999))
            {

                /*" -2879- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -2880- MOVE ZEROS TO WS-TOTAL-CONTA */
                _.Move(0, WS_WORK_AREAS.WS_TOTAL_CONTA);

                /*" -2885- DISPLAY 'LIDOS PROPOVA ' WS-TOTAL-LIDOS ' ' WS-TIME ' ' PROPOVA-NUM-APOLICE ' ' PROPOVA-COD-SUBGRUPO ' ' PROPOVA-NUM-CERTIFICADO */

                $"LIDOS PROPOVA {WS_WORK_AREAS.WS_TOTAL_LIDOS} {WS_WORK_AREAS.WS_TIME} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -2887- END-IF */
            }


            /*" -2889- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WS_WORK_AREAS.WS_NUM_CERTIFICADO);

            /*" -2890- MOVE ZEROS TO FLG */
            _.Move(0, WS_WORK_AREAS.FLG);

            /*" -2892- MOVE ZEROS TO IND */
            _.Move(0, WS_WORK_AREAS.IND);

            /*" -2893- PERFORM UNTIL FLG = 1 */

            while (!(WS_WORK_AREAS.FLG == 1))
            {

                /*" -2894- ADD 1 TO IND */
                WS_WORK_AREAS.IND.Value = WS_WORK_AREAS.IND + 1;

                /*" -2895- IF IND > 15 */

                if (WS_WORK_AREAS.IND > 15)
                {

                    /*" -2896- MOVE 1 TO FLG */
                    _.Move(1, WS_WORK_AREAS.FLG);

                    /*" -2897- ELSE */
                }
                else
                {


                    /*" -2898- IF WS-NRCERTIF (IND) > ZEROS */

                    if (WS_WORK_AREAS.WS_NUM_CERTIFICADO_R.WS_NRCERTIF[WS_WORK_AREAS.IND] > 00)
                    {

                        /*" -2899- MOVE 1 TO FLG */
                        _.Move(1, WS_WORK_AREAS.FLG);

                        /*" -2900- END-IF */
                    }


                    /*" -2901- END-IF */
                }


                /*" -2903- END-PERFORM. */
            }

            /*" -2904- IF IND > 15 */

            if (WS_WORK_AREAS.IND > 15)
            {

                /*" -2905- MOVE 15 TO IND */
                _.Move(15, WS_WORK_AREAS.IND);

                /*" -2907- END-IF */
            }


            /*" -2908- SUBTRACT 15 FROM IND GIVING INDF */
            WS_WORK_AREAS.INDF.Value = WS_WORK_AREAS.IND - 15;

            /*" -2910- ADD 1 TO INDF */
            WS_WORK_AREAS.INDF.Value = WS_WORK_AREAS.INDF + 1;

            /*" -2912- MOVE WS-NUM-CERTIFICADO (IND:INDF) TO DET-NUM-CERTIFICADO */
            _.Move(WS_WORK_AREAS.WS_NUM_CERTIFICADO.Substring(WS_WORK_AREAS.IND, WS_WORK_AREAS.INDF), DETAIL_RECORD.DET_CHAVE_PRINCIPAL.DET_NUM_CERTIFICADO);

            /*" -2914- MOVE PROPOVA-NUM-APOLICE TO WS-NUM-APOLICE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, WS_WORK_AREAS.WS_NUM_APOLICE);

            /*" -2915- MOVE ZEROS TO FLG */
            _.Move(0, WS_WORK_AREAS.FLG);

            /*" -2917- MOVE ZEROS TO IND */
            _.Move(0, WS_WORK_AREAS.IND);

            /*" -2918- PERFORM UNTIL FLG = 1 */

            while (!(WS_WORK_AREAS.FLG == 1))
            {

                /*" -2919- ADD 1 TO IND */
                WS_WORK_AREAS.IND.Value = WS_WORK_AREAS.IND + 1;

                /*" -2920- IF IND > 13 */

                if (WS_WORK_AREAS.IND > 13)
                {

                    /*" -2921- MOVE 1 TO FLG */
                    _.Move(1, WS_WORK_AREAS.FLG);

                    /*" -2922- ELSE */
                }
                else
                {


                    /*" -2923- IF WS-NO-APOLICE(IND) > ZEROS */

                    if (WS_WORK_AREAS.WS_NUM_APOLICE_R.WS_NO_APOLICE[WS_WORK_AREAS.IND] > 00)
                    {

                        /*" -2924- MOVE 1 TO FLG */
                        _.Move(1, WS_WORK_AREAS.FLG);

                        /*" -2925- END-IF */
                    }


                    /*" -2926- END-IF */
                }


                /*" -2928- END-PERFORM. */
            }

            /*" -2929- IF IND > 13 */

            if (WS_WORK_AREAS.IND > 13)
            {

                /*" -2930- MOVE 13 TO IND */
                _.Move(13, WS_WORK_AREAS.IND);

                /*" -2932- END-IF */
            }


            /*" -2933- SUBTRACT 13 FROM IND GIVING INDF */
            WS_WORK_AREAS.INDF.Value = WS_WORK_AREAS.IND - 13;

            /*" -2935- ADD 1 TO INDF */
            WS_WORK_AREAS.INDF.Value = WS_WORK_AREAS.INDF + 1;

            /*" -2938- MOVE WS-NUM-APOLICE (IND:INDF) TO DET-NUM-APOLICE */
            _.Move(WS_WORK_AREAS.WS_NUM_APOLICE.Substring(WS_WORK_AREAS.IND, WS_WORK_AREAS.INDF), DETAIL_RECORD.DET_SUB_CHAVE_PRINCIPAL.DET_NUM_APOLICE);

            /*" -2940- MOVE CLIENTES-NOME-RAZAO TO DET-NOME-USUARIO-ASSIST */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETAIL_RECORD.DET_NOME_USUARIO_ASSIST);

            /*" -2942- MOVE PROPOVA-DATA-QUITACAO TO W01DTSQL */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WS_WORK_AREAS.W01DTSQL);

            /*" -2943- MOVE W01DDSQL TO W01DDCOR */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -2944- MOVE W01MMSQL TO W01MMCOR */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -2945- MOVE W01AASQL TO W01AACOR */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -2947- MOVE W01DTCOR TO DET-DTINIVIG-ASSIST */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTINIVIG_ASSIST);

            /*" -2949- MOVE ENDOSSOS-DATA-TERVIGENCIA TO W01DTSQL */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, WS_WORK_AREAS.W01DTSQL);

            /*" -2950- MOVE W01DDSQL TO W01DDCOR */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -2951- MOVE W01MMSQL TO W01MMCOR */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -2952- MOVE W01AASQL TO W01AACOR */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -2954- MOVE W01DTCOR TO DET-DTTERVIG-ASSIST */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTTERVIG_ASSIST);

            /*" -2955- IF (CLIENTES-TIPO-PESSOA EQUAL 'J' ) */

            if ((CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "J"))
            {

                /*" -2956- MOVE CLIENTES-CGCCPF TO DET-CGC */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DETAIL_RECORD.DET_CGC);

                /*" -2957- MOVE ZEROS TO DET-CPF */
                _.Move(0, DETAIL_RECORD.DET_CPF);

                /*" -2958- ELSE */
            }
            else
            {


                /*" -2959- MOVE CLIENTES-CGCCPF TO DET-CPF */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DETAIL_RECORD.DET_CPF);

                /*" -2960- MOVE ZEROS TO DET-CGC */
                _.Move(0, DETAIL_RECORD.DET_CGC);

                /*" -2962- END-IF */
            }


            /*" -2963- MOVE ENDERECO-ENDERECO TO DET-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, DETAIL_RECORD.DET_ENDERECO);

            /*" -2964- MOVE ENDERECO-SIGLA-UF TO DET-SIGLA-UF */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, DETAIL_RECORD.DET_SIGLA_UF);

            /*" -2965- MOVE ENDERECO-CIDADE TO DET-CIDADE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, DETAIL_RECORD.DET_CIDADE);

            /*" -2966- MOVE ENDERECO-BAIRRO TO DET-BAIRRO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, DETAIL_RECORD.DET_BAIRRO);

            /*" -2967- MOVE ENDERECO-CEP TO DET-CEP */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, DETAIL_RECORD.DET_CEP);

            /*" -2968- MOVE ENDERECO-DDD TO DET-DDD */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, DETAIL_RECORD.DET_AREA_TELEFONE.DET_DDD);

            /*" -2970- MOVE ENDERECO-TELEFONE TO DET-TELEFONE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, DETAIL_RECORD.DET_AREA_TELEFONE.DET_TELEFONE);

            /*" -2971- MOVE ENDERECO-ENDERECO TO DET-ENDERECO-RISCO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, DETAIL_RECORD.DET_ENDERECO_RISCO);

            /*" -2972- MOVE ENDERECO-SIGLA-UF TO DET-SIGLA-UF-RISCO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, DETAIL_RECORD.DET_SIGLA_UF_RISCO);

            /*" -2973- MOVE ENDERECO-CIDADE TO DET-CIDADE-RISCO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, DETAIL_RECORD.DET_CIDADE_RISCO);

            /*" -2974- MOVE ENDERECO-BAIRRO TO DET-BAIRRO-RISCO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, DETAIL_RECORD.DET_BAIRRO_RISCO);

            /*" -2975- MOVE ENDERECO-CEP TO DET-CEP-RISCO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, DETAIL_RECORD.DET_CEP_RISCO);

            /*" -2976- MOVE ENDERECO-DDD TO DET-DDD-RISCO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, DETAIL_RECORD.DET_AREA_TELEFONE_RISCO.DET_DDD_RISCO);

            /*" -2978- MOVE ENDERECO-TELEFONE TO DET-TELEFONE-RISCO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, DETAIL_RECORD.DET_AREA_TELEFONE_RISCO.DET_TELEFONE_RISCO);

            /*" -2979- MOVE SPACES TO DET-PLACA */
            _.Move("", DETAIL_RECORD.DET_PLACA);

            /*" -2980- MOVE SPACES TO DET-CHASSIS */
            _.Move("", DETAIL_RECORD.DET_CHASSIS);

            /*" -2981- MOVE SPACES TO DET-COR */
            _.Move("", DETAIL_RECORD.DET_COR);

            /*" -2982- MOVE SPACES TO DET-ANO-FABRICACAO */
            _.Move("", DETAIL_RECORD.DET_ANO_FABRICACAO);

            /*" -2983- MOVE SPACES TO DET-MODELO */
            _.Move("", DETAIL_RECORD.DET_MODELO);

            /*" -2984- MOVE SPACES TO DET-MARCA */
            _.Move("", DETAIL_RECORD.DET_MARCA);

            /*" -2985- MOVE SPACES TO DET-DIAS-CARRES-PP */
            _.Move("", DETAIL_RECORD.DET_DIAS_CARRES_PP);

            /*" -2986- MOVE SPACES TO DET-DIAS-CARRES-PT */
            _.Move("", DETAIL_RECORD.DET_DIAS_CARRES_PT);

            /*" -2987- MOVE SPACES TO DET-DIAS-CARRES-PR */
            _.Move("", DETAIL_RECORD.DET_DIAS_CARRES_PR);

            /*" -2988- MOVE WHOST-NOME-ESTIP TO DET-NOME-ESTIPULANTE */
            _.Move(WHOST_NOME_ESTIP, DETAIL_RECORD.DET_NOME_ESTIPULANTE);

            /*" -2989- MOVE CLIENTES-NOME-RAZAO TO DET-BENEFICIARIO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETAIL_RECORD.DET_BENEFICIARIO);

            /*" -2990- MOVE 00000000 TO DET-VALOR-LIMITE */
            _.Move(00000000, DETAIL_RECORD.DET_VALOR_LIMITE);

            /*" -2998- MOVE WS-COD-PRODUTO TO DET-COD-PRODUTO */
            _.Move(WS_COD_PRODUTO, DETAIL_RECORD.DET_COD_PRODUTO);

            /*" -3004- IF (ENDOSSOS-COD-PRODUTO EQUAL 8217 OR 8205 OR 9329 OR 8209 OR 9343 OR JVPRD8209 OR JVPRD9343 OR JVPRD8205 OR JVPRD9329 ) */

            if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8217", "8205", "9329", "8209", "9343", JVBKINCL.JV_PRODUTOS.JVPRD8209.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9343.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8205.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9329.ToString())))
            {

                /*" -3005- MOVE '40000042589' TO DET-NUM-CONTRATO */
                _.Move("40000042589", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -3007- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -3008- IF WHOST-TIPO-MOVIMENTO EQUAL 'I' */

                if (WHOST_TIPO_MOVIMENTO == "I")
                {

                    /*" -3009- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -3011- ADD 1 TO WS-TOTAL-INC AC-EMPR-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                    WS_WORK_AREAS.AC_EMPR_INC.Value = WS_WORK_AREAS.AC_EMPR_INC + 1;

                    /*" -3012- ELSE */
                }
                else
                {


                    /*" -3013- IF WHOST-TIPO-MOVIMENTO EQUAL 'A' */

                    if (WHOST_TIPO_MOVIMENTO == "A")
                    {

                        /*" -3014- MOVE 'A' TO DET-TIPO-MOV */
                        _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3016- ADD 1 TO WS-TOTAL-ALT AC-EMPR-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                        WS_WORK_AREAS.AC_EMPR_ALT.Value = WS_WORK_AREAS.AC_EMPR_ALT + 1;

                        /*" -3017- ELSE */
                    }
                    else
                    {


                        /*" -3018- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3020- ADD 1 TO WS-TOTAL-EXC AC-EMPR-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                        WS_WORK_AREAS.AC_EMPR_EXC.Value = WS_WORK_AREAS.AC_EMPR_EXC + 1;

                        /*" -3021- END-IF */
                    }


                    /*" -3022- END-IF */
                }


                /*" -3023- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -3031- END-IF. */
            }


            /*" -3036- PERFORM R1500-00-SELECT-PROPOFID */

            R1500_00_SELECT_PROPOFID_SECTION();

            /*" -3055- IF PROPOVA-NUM-APOLICE = 0109300000709 OR 0109300001311 OR 0109300001393 OR 0109300001392 OR 0109300002004 OR 0109300002005 OR 0109300002006 OR 3009300002005 OR 3009300002006 OR 3009300012005 OR 3009300012006 OR 0109300002007 OR 0109300002008 OR 0109300002010 OR 3009300002008 OR 3009300002010 OR 3009300012008 OR 3009300012010 OR 0109300001976 OR 0109300001977 OR 0109300001978 OR 3009300001977 OR 3009300001978 OR 3009300011977 OR 3009300011978 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("0109300000709", "0109300001311", "0109300001393", "0109300001392", "0109300002004", "0109300002005", "0109300002006", "3009300002005", "3009300002006", "3009300012005", "3009300012006", "0109300002007", "0109300002008", "0109300002010", "3009300002008", "3009300002010", "3009300012008", "3009300012010", "0109300001976", "0109300001977", "0109300001978", "3009300001977", "3009300001978", "3009300011977", "3009300011978"))
            {

                /*" -3061- IF PROPOVA-NUM-APOLICE = 3009300011977 OR 3009300011978 OR 3009300012005 OR 3009300012006 OR 3009300012008 OR 3009300012010 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300011977", "3009300011978", "3009300012005", "3009300012006", "3009300012008", "3009300012010"))
                {

                    /*" -3062- MOVE 16 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(16, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3063- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3064- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3066- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3067- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3069- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3070- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3072- ADD 1 TO WS-TOTAL-INC AC-MEDICOS-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_MEDICOS_INC.Value = WS_WORK_AREAS.AC_MEDICOS_INC + 1;

                            /*" -3073- ELSE */
                        }
                        else
                        {


                            /*" -3074- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3075- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3077- ADD 1 TO WS-TOTAL-ALT AC-MEDICOS-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_MEDICOS_ALT.Value = WS_WORK_AREAS.AC_MEDICOS_ALT + 1;

                                /*" -3078- ELSE */
                            }
                            else
                            {


                                /*" -3079- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3081- ADD 1 TO WS-TOTAL-EXC AC-MEDICOS-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_MEDICOS_EXC.Value = WS_WORK_AREAS.AC_MEDICOS_EXC + 1;

                                /*" -3082- END-IF */
                            }


                            /*" -3083- END-IF */
                        }


                        /*" -3084- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3086- ELSE */
                    }
                    else
                    {


                        /*" -3087- MOVE '40001262238' TO DET-NUM-CONTRATO */
                        _.Move("40001262238", DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3088- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3090- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3091- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3093- ADD 1 TO WS-TOTAL-INC AC-FARM-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_FARM_INC.Value = WS_WORK_AREAS.AC_FARM_INC + 1;

                            /*" -3094- ELSE */
                        }
                        else
                        {


                            /*" -3095- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3096- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3098- ADD 1 TO WS-TOTAL-ALT AC-FARM-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_FARM_ALT.Value = WS_WORK_AREAS.AC_FARM_ALT + 1;

                                /*" -3099- ELSE */
                            }
                            else
                            {


                                /*" -3100- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3102- ADD 1 TO WS-TOTAL-EXC AC-FARM-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_FARM_EXC.Value = WS_WORK_AREAS.AC_FARM_EXC + 1;

                                /*" -3103- END-IF */
                            }


                            /*" -3104- END-IF */
                        }


                        /*" -3105- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3106- END-IF */
                    }


                    /*" -3107- ELSE */
                }
                else
                {


                    /*" -3108- MOVE '40001262238' TO DET-NUM-CONTRATO */
                    _.Move("40001262238", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -3109- ADD 1 TO WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -3111- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                    {

                        /*" -3112- MOVE 'I' TO DET-TIPO-MOV */
                        _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3114- ADD 1 TO WS-TOTAL-INC AC-FARM-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                        WS_WORK_AREAS.AC_FARM_INC.Value = WS_WORK_AREAS.AC_FARM_INC + 1;

                        /*" -3115- ELSE */
                    }
                    else
                    {


                        /*" -3116- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                        {

                            /*" -3117- MOVE 'A' TO DET-TIPO-MOV */
                            _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3119- ADD 1 TO WS-TOTAL-ALT AC-FARM-ALT */
                            WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                            WS_WORK_AREAS.AC_FARM_ALT.Value = WS_WORK_AREAS.AC_FARM_ALT + 1;

                            /*" -3120- ELSE */
                        }
                        else
                        {


                            /*" -3121- MOVE 'E' TO DET-TIPO-MOV */
                            _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3123- ADD 1 TO WS-TOTAL-EXC AC-FARM-EXC */
                            WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                            WS_WORK_AREAS.AC_FARM_EXC.Value = WS_WORK_AREAS.AC_FARM_EXC + 1;

                            /*" -3124- END-IF */
                        }


                        /*" -3125- END-IF */
                    }


                    /*" -3126- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -3147- END-IF */
                }


                /*" -3153- IF PROPOVA-NUM-APOLICE = 3009300011977 OR 3009300011978 OR 3009300012005 OR 3009300012006 OR 3009300012008 OR 3009300012010 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300011977", "3009300011978", "3009300012005", "3009300012006", "3009300012008", "3009300012010"))
                {

                    /*" -3154- MOVE 83 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(83, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3155- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3156- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3158- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3159- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3161- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3162- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3164- ADD 1 TO WS-TOTAL-INC AC-LAR-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_LAR_INC.Value = WS_WORK_AREAS.AC_LAR_INC + 1;

                            /*" -3165- ELSE */
                        }
                        else
                        {


                            /*" -3166- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3167- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3169- ADD 1 TO WS-TOTAL-ALT AC-LAR-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_LAR_ALT.Value = WS_WORK_AREAS.AC_LAR_ALT + 1;

                                /*" -3170- ELSE */
                            }
                            else
                            {


                                /*" -3171- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3173- ADD 1 TO WS-TOTAL-EXC AC-LAR-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_LAR_EXC.Value = WS_WORK_AREAS.AC_LAR_EXC + 1;

                                /*" -3174- END-IF */
                            }


                            /*" -3175- END-IF */
                        }


                        /*" -3176- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3178- ELSE */
                    }
                    else
                    {


                        /*" -3179- IF PROPOFID-IND-TIPO-CONTA NOT = 'S' */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA != "S")
                        {

                            /*" -3180- MOVE '40000042239' TO DET-NUM-CONTRATO */
                            _.Move("40000042239", DETAIL_RECORD.DET_NUM_CONTRATO);

                            /*" -3181- ELSE */
                        }
                        else
                        {


                            /*" -3182- MOVE '40000481388' TO DET-NUM-CONTRATO */
                            _.Move("40000481388", DETAIL_RECORD.DET_NUM_CONTRATO);

                            /*" -3183- END-IF */
                        }


                        /*" -3184- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3186- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3187- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3189- ADD 1 TO WS-TOTAL-INC AC-RESI-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_RESI_INC.Value = WS_WORK_AREAS.AC_RESI_INC + 1;

                            /*" -3190- ELSE */
                        }
                        else
                        {


                            /*" -3191- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3192- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3194- ADD 1 TO WS-TOTAL-ALT AC-RESI-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_RESI_ALT.Value = WS_WORK_AREAS.AC_RESI_ALT + 1;

                                /*" -3195- ELSE */
                            }
                            else
                            {


                                /*" -3196- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3198- ADD 1 TO WS-TOTAL-EXC AC-RESI-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_RESI_EXC.Value = WS_WORK_AREAS.AC_RESI_EXC + 1;

                                /*" -3199- END-IF */
                            }


                            /*" -3200- END-IF */
                        }


                        /*" -3201- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3229- END-IF */
                    }


                    /*" -3237- END-IF */
                }


                /*" -3238- MOVE '40001102241' TO DET-NUM-CONTRATO */
                _.Move("40001102241", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -3239- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -3241- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                {

                    /*" -3242- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -3244- ADD 1 TO WS-TOTAL-INC AC-NUTR-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                    WS_WORK_AREAS.AC_NUTR_INC.Value = WS_WORK_AREAS.AC_NUTR_INC + 1;

                    /*" -3245- ELSE */
                }
                else
                {


                    /*" -3246- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                    {

                        /*" -3247- MOVE 'A' TO DET-TIPO-MOV */
                        _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3249- ADD 1 TO WS-TOTAL-ALT AC-NUTR-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                        WS_WORK_AREAS.AC_NUTR_ALT.Value = WS_WORK_AREAS.AC_NUTR_ALT + 1;

                        /*" -3250- ELSE */
                    }
                    else
                    {


                        /*" -3251- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3253- ADD 1 TO WS-TOTAL-EXC AC-NUTR-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                        WS_WORK_AREAS.AC_NUTR_EXC.Value = WS_WORK_AREAS.AC_NUTR_EXC + 1;

                        /*" -3254- END-IF */
                    }


                    /*" -3255- END-IF */
                }


                /*" -3271- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -3277- IF PROPOVA-NUM-APOLICE = 3009300011977 OR 3009300011978 OR 3009300012005 OR 3009300012006 OR 3009300012008 OR 3009300012010 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300011977", "3009300011978", "3009300012005", "3009300012006", "3009300012008", "3009300012010"))
                {

                    /*" -3278- MOVE 87 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(87, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3279- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3280- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3282- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3283- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3285- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3286- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3288- ADD 1 TO WS-TOTAL-INC AC-GESTANT-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_GESTANT_INC.Value = WS_WORK_AREAS.AC_GESTANT_INC + 1;

                            /*" -3289- ELSE */
                        }
                        else
                        {


                            /*" -3290- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3291- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3293- ADD 1 TO WS-TOTAL-ALT AC-GESTANT-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_GESTANT_ALT.Value = WS_WORK_AREAS.AC_GESTANT_ALT + 1;

                                /*" -3294- ELSE */
                            }
                            else
                            {


                                /*" -3295- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3297- ADD 1 TO WS-TOTAL-EXC AC-GESTANT-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_GESTANT_EXC.Value = WS_WORK_AREAS.AC_GESTANT_EXC + 1;

                                /*" -3298- END-IF */
                            }


                            /*" -3299- END-IF */
                        }


                        /*" -3300- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3301- ELSE */
                    }
                    else
                    {


                        /*" -3302- CONTINUE */

                        /*" -3303- END-IF */
                    }


                    /*" -3319- END-IF */
                }


                /*" -3325- IF PROPOVA-NUM-APOLICE = 3009300011977 OR 3009300011978 OR 3009300012005 OR 3009300012006 OR 3009300012008 OR 3009300012010 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300011977", "3009300011978", "3009300012005", "3009300012006", "3009300012008", "3009300012010"))
                {

                    /*" -3326- MOVE 88 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(88, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3327- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3328- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3330- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3331- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3333- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3334- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3336- ADD 1 TO WS-TOTAL-INC AC-CNATAL-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_CNATAL_INC.Value = WS_WORK_AREAS.AC_CNATAL_INC + 1;

                            /*" -3337- ELSE */
                        }
                        else
                        {


                            /*" -3338- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3339- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3341- ADD 1 TO WS-TOTAL-ALT AC-CNATAL-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_CNATAL_ALT.Value = WS_WORK_AREAS.AC_CNATAL_ALT + 1;

                                /*" -3342- ELSE */
                            }
                            else
                            {


                                /*" -3343- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3345- ADD 1 TO WS-TOTAL-EXC AC-CNATAL-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_CNATAL_EXC.Value = WS_WORK_AREAS.AC_CNATAL_EXC + 1;

                                /*" -3346- END-IF */
                            }


                            /*" -3347- END-IF */
                        }


                        /*" -3348- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3349- ELSE */
                    }
                    else
                    {


                        /*" -3350- CONTINUE */

                        /*" -3351- END-IF */
                    }


                    /*" -3367- END-IF */
                }


                /*" -3373- IF PROPOVA-NUM-APOLICE = 3009300011977 OR 3009300011978 OR 3009300012005 OR 3009300012006 OR 3009300012008 OR 3009300012010 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300011977", "3009300011978", "3009300012005", "3009300012006", "3009300012008", "3009300012010"))
                {

                    /*" -3374- MOVE 88 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(88, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3375- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3376- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3378- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3379- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3381- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3382- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3384- ADD 1 TO WS-TOTAL-INC AC-PET-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_PET_INC.Value = WS_WORK_AREAS.AC_PET_INC + 1;

                            /*" -3385- ELSE */
                        }
                        else
                        {


                            /*" -3386- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3387- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3389- ADD 1 TO WS-TOTAL-ALT AC-PET-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_PET_ALT.Value = WS_WORK_AREAS.AC_PET_ALT + 1;

                                /*" -3390- ELSE */
                            }
                            else
                            {


                                /*" -3391- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3393- ADD 1 TO WS-TOTAL-EXC AC-PET-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_PET_EXC.Value = WS_WORK_AREAS.AC_PET_EXC + 1;

                                /*" -3394- END-IF */
                            }


                            /*" -3395- END-IF */
                        }


                        /*" -3396- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3397- ELSE */
                    }
                    else
                    {


                        /*" -3398- CONTINUE */

                        /*" -3399- END-IF */
                    }


                    /*" -3418- END-IF */
                }


                /*" -3424- IF PROPOVA-NUM-APOLICE = 3009300011977 OR 3009300011978 OR 3009300012005 OR 3009300012006 OR 3009300012008 OR 3009300012010 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300011977", "3009300011978", "3009300012005", "3009300012006", "3009300012008", "3009300012010"))
                {

                    /*" -3425- MOVE 81 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(81, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3426- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3427- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3429- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3430- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3432- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3433- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3435- ADD 1 TO WS-TOTAL-INC AC-CEPR-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_CEPR_INC.Value = WS_WORK_AREAS.AC_CEPR_INC + 1;

                            /*" -3436- ELSE */
                        }
                        else
                        {


                            /*" -3437- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3438- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3440- ADD 1 TO WS-TOTAL-ALT AC-CEPR-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_CEPR_ALT.Value = WS_WORK_AREAS.AC_CEPR_ALT + 1;

                                /*" -3441- ELSE */
                            }
                            else
                            {


                                /*" -3442- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3444- ADD 1 TO WS-TOTAL-EXC AC-CEPR-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_CEPR_EXC.Value = WS_WORK_AREAS.AC_CEPR_EXC + 1;

                                /*" -3445- END-IF */
                            }


                            /*" -3446- END-IF */
                        }


                        /*" -3447- WRITE REG-M1476BHM FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_M1476BHM);

                        M1476BHM.Write(REG_M1476BHM.GetMoveValues().ToString());

                        /*" -3448- ELSE */
                    }
                    else
                    {


                        /*" -3449- CONTINUE */

                        /*" -3450- END-IF */
                    }


                    /*" -3454- END-IF */
                }


                /*" -3469- END-IF. */
            }


            /*" -3470- IF PROPOVA-NUM-APOLICE = 0109300000959 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 0109300000959)
            {

                /*" -3471- IF PROPOFID-IND-TIPO-CONTA NOT = 'S' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA != "S")
                {

                    /*" -3472- MOVE '40000042239' TO DET-NUM-CONTRATO */
                    _.Move("40000042239", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -3473- ELSE */
                }
                else
                {


                    /*" -3474- MOVE '40000481388' TO DET-NUM-CONTRATO */
                    _.Move("40000481388", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -3475- END-IF */
                }


                /*" -3476- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -3478- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                {

                    /*" -3479- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -3481- ADD 1 TO WS-TOTAL-INC AC-RESI-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                    WS_WORK_AREAS.AC_RESI_INC.Value = WS_WORK_AREAS.AC_RESI_INC + 1;

                    /*" -3482- ELSE */
                }
                else
                {


                    /*" -3483- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                    {

                        /*" -3484- MOVE 'A' TO DET-TIPO-MOV */
                        _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3486- ADD 1 TO WS-TOTAL-ALT AC-RESI-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                        WS_WORK_AREAS.AC_RESI_ALT.Value = WS_WORK_AREAS.AC_RESI_ALT + 1;

                        /*" -3487- ELSE */
                    }
                    else
                    {


                        /*" -3488- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3490- ADD 1 TO WS-TOTAL-EXC AC-RESI-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                        WS_WORK_AREAS.AC_RESI_EXC.Value = WS_WORK_AREAS.AC_RESI_EXC + 1;

                        /*" -3491- END-IF */
                    }


                    /*" -3492- END-IF */
                }


                /*" -3493- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -3507- END-IF. */
            }


            /*" -3512- IF PROPOVA-NUM-APOLICE = 0108210871143 AND PROPOVA-COD-SUBGRUPO = 4 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 0108210871143 && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO == 4)
            {

                /*" -3513- MOVE '40000032503' TO DET-NUM-CONTRATO */
                _.Move("40000032503", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -3514- ADD 1 TO AC-HDESK-INC */
                WS_WORK_AREAS.AC_HDESK_INC.Value = WS_WORK_AREAS.AC_HDESK_INC + 1;

                /*" -3516- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                {

                    /*" -3517- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -3519- ADD 1 TO WS-TOTAL-INC AC-HDESK-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                    WS_WORK_AREAS.AC_HDESK_INC.Value = WS_WORK_AREAS.AC_HDESK_INC + 1;

                    /*" -3520- ELSE */
                }
                else
                {


                    /*" -3521- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                    {

                        /*" -3522- MOVE 'A' TO DET-TIPO-MOV */
                        _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3524- ADD 1 TO WS-TOTAL-ALT AC-HDESK-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                        WS_WORK_AREAS.AC_HDESK_ALT.Value = WS_WORK_AREAS.AC_HDESK_ALT + 1;

                        /*" -3525- ELSE */
                    }
                    else
                    {


                        /*" -3526- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3528- ADD 1 TO WS-TOTAL-EXC AC-HDESK-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                        WS_WORK_AREAS.AC_HDESK_EXC.Value = WS_WORK_AREAS.AC_HDESK_EXC + 1;

                        /*" -3529- END-IF */
                    }


                    /*" -3530- END-IF */
                }


                /*" -3531- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -3546- END-IF. */
            }


            /*" -3551- IF PROPOVA-NUM-APOLICE = 0108210871143 AND PROPOVA-COD-SUBGRUPO = 3 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 0108210871143 && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO == 3)
            {

                /*" -3552- MOVE '40001112584' TO DET-NUM-CONTRATO */
                _.Move("40001112584", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -3553- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -3555- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                {

                    /*" -3556- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -3558- ADD 1 TO WS-TOTAL-INC AC-VIOL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                    WS_WORK_AREAS.AC_VIOL_INC.Value = WS_WORK_AREAS.AC_VIOL_INC + 1;

                    /*" -3559- ELSE */
                }
                else
                {


                    /*" -3560- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                    {

                        /*" -3561- MOVE 'A' TO DET-TIPO-MOV */
                        _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3563- ADD 1 TO WS-TOTAL-ALT AC-VIOL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                        WS_WORK_AREAS.AC_VIOL_ALT.Value = WS_WORK_AREAS.AC_VIOL_ALT + 1;

                        /*" -3564- ELSE */
                    }
                    else
                    {


                        /*" -3565- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3567- ADD 1 TO WS-TOTAL-EXC AC-VIOL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                        WS_WORK_AREAS.AC_VIOL_EXC.Value = WS_WORK_AREAS.AC_VIOL_EXC + 1;

                        /*" -3568- END-IF */
                    }


                    /*" -3569- END-IF */
                }


                /*" -3570- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -3584- END-IF. */
            }


            /*" -3661- IF PROPOVA-NUM-APOLICE = 0097010000889 OR 0109300000550 OR 0109300000909 OR 0109300001394 OR 3009300000909 OR 3009300001909 OR 0109300000559 OR 0109300001553 OR 0109300001575 OR 3009300000559 OR 3009300001559 OR 0109300002001 OR 0109300002002 OR 0109300002003 OR 3009300002002 OR 3009300002003 OR 3009300012002 OR 3009300012003 OR 0109300001966 OR 0109300001970 OR 0109300001971 OR 3009300001970 OR 3009300001971 OR 3009300011970 OR 3009300011971 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("0097010000889", "0109300000550", "0109300000909", "0109300001394", "3009300000909", "3009300001909", "0109300000559", "0109300001553", "0109300001575", "3009300000559", "3009300001559", "0109300002001", "0109300002002", "0109300002003", "3009300002002", "3009300002003", "3009300012002", "3009300012003", "0109300001966", "0109300001970", "0109300001971", "3009300001970", "3009300001971", "3009300011970", "3009300011971"))
            {

                /*" -3669- IF PROPOVA-NUM-APOLICE = 3009300001559 OR 3009300001909 OR 3009300011970 OR 3009300011971 OR 3009300012002 OR 3009300012003 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300001559", "3009300001909", "3009300011970", "3009300011971", "3009300012002", "3009300012003"))
                {

                    /*" -3670- MOVE 83 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(83, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3671- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3672- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3674- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3675- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3677- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3678- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3680- ADD 1 TO WS-TOTAL-INC AC-LAR-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_LAR_INC.Value = WS_WORK_AREAS.AC_LAR_INC + 1;

                            /*" -3681- ELSE */
                        }
                        else
                        {


                            /*" -3682- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3683- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3685- ADD 1 TO WS-TOTAL-ALT AC-LAR-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_LAR_ALT.Value = WS_WORK_AREAS.AC_LAR_ALT + 1;

                                /*" -3686- ELSE */
                            }
                            else
                            {


                                /*" -3687- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3689- ADD 1 TO WS-TOTAL-EXC AC-LAR-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_LAR_EXC.Value = WS_WORK_AREAS.AC_LAR_EXC + 1;

                                /*" -3690- END-IF */
                            }


                            /*" -3691- END-IF */
                        }


                        /*" -3692- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3694- ELSE */
                    }
                    else
                    {


                        /*" -3695- IF PROPOFID-IND-TIPO-CONTA NOT = 'S' */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA != "S")
                        {

                            /*" -3696- MOVE '40000042239' TO DET-NUM-CONTRATO */
                            _.Move("40000042239", DETAIL_RECORD.DET_NUM_CONTRATO);

                            /*" -3697- ELSE */
                        }
                        else
                        {


                            /*" -3698- MOVE '40000481388' TO DET-NUM-CONTRATO */
                            _.Move("40000481388", DETAIL_RECORD.DET_NUM_CONTRATO);

                            /*" -3699- END-IF */
                        }


                        /*" -3700- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3702- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3703- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3705- ADD 1 TO WS-TOTAL-INC AC-RESI-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_RESI_INC.Value = WS_WORK_AREAS.AC_RESI_INC + 1;

                            /*" -3706- ELSE */
                        }
                        else
                        {


                            /*" -3707- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3708- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3710- ADD 1 TO WS-TOTAL-ALT AC-RESI-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_RESI_ALT.Value = WS_WORK_AREAS.AC_RESI_ALT + 1;

                                /*" -3711- ELSE */
                            }
                            else
                            {


                                /*" -3712- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3714- ADD 1 TO WS-TOTAL-EXC AC-RESI-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_RESI_EXC.Value = WS_WORK_AREAS.AC_RESI_EXC + 1;

                                /*" -3715- END-IF */
                            }


                            /*" -3716- END-IF */
                        }


                        /*" -3717- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3718- END-IF */
                    }


                    /*" -3719- ELSE */
                }
                else
                {


                    /*" -3720- IF PROPOFID-IND-TIPO-CONTA NOT = 'S' */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA != "S")
                    {

                        /*" -3721- MOVE '40000042239' TO DET-NUM-CONTRATO */
                        _.Move("40000042239", DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3722- ELSE */
                    }
                    else
                    {


                        /*" -3723- MOVE '40000481388' TO DET-NUM-CONTRATO */
                        _.Move("40000481388", DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3724- END-IF */
                    }


                    /*" -3725- ADD 1 TO WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -3727- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                    {

                        /*" -3728- MOVE 'I' TO DET-TIPO-MOV */
                        _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -3730- ADD 1 TO WS-TOTAL-INC AC-RESI-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                        WS_WORK_AREAS.AC_RESI_INC.Value = WS_WORK_AREAS.AC_RESI_INC + 1;

                        /*" -3731- ELSE */
                    }
                    else
                    {


                        /*" -3732- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                        {

                            /*" -3733- MOVE 'A' TO DET-TIPO-MOV */
                            _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3735- ADD 1 TO WS-TOTAL-ALT AC-RESI-ALT */
                            WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                            WS_WORK_AREAS.AC_RESI_ALT.Value = WS_WORK_AREAS.AC_RESI_ALT + 1;

                            /*" -3736- ELSE */
                        }
                        else
                        {


                            /*" -3737- MOVE 'E' TO DET-TIPO-MOV */
                            _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3739- ADD 1 TO WS-TOTAL-EXC AC-RESI-EXC */
                            WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                            WS_WORK_AREAS.AC_RESI_EXC.Value = WS_WORK_AREAS.AC_RESI_EXC + 1;

                            /*" -3740- END-IF */
                        }


                        /*" -3741- END-IF */
                    }


                    /*" -3742- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -3768- END-IF */
                }


                /*" -3772- IF PROPOVA-NUM-APOLICE = 3009300001559 OR 3009300001909 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300001559", "3009300001909"))
                {

                    /*" -3773- MOVE 16 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(16, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3774- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3775- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3777- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3778- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3780- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3781- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3783- ADD 1 TO WS-TOTAL-INC AC-MEDICOS-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_MEDICOS_INC.Value = WS_WORK_AREAS.AC_MEDICOS_INC + 1;

                            /*" -3784- ELSE */
                        }
                        else
                        {


                            /*" -3785- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3786- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3788- ADD 1 TO WS-TOTAL-ALT AC-MEDICOS-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_MEDICOS_ALT.Value = WS_WORK_AREAS.AC_MEDICOS_ALT + 1;

                                /*" -3789- ELSE */
                            }
                            else
                            {


                                /*" -3790- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3792- ADD 1 TO WS-TOTAL-EXC AC-MEDICOS-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_MEDICOS_EXC.Value = WS_WORK_AREAS.AC_MEDICOS_EXC + 1;

                                /*" -3793- END-IF */
                            }


                            /*" -3794- END-IF */
                        }


                        /*" -3795- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3796- ELSE */
                    }
                    else
                    {


                        /*" -3797- CONTINUE */

                        /*" -3798- END-IF */
                    }


                    /*" -3821- END-IF */
                }


                /*" -3825- IF PROPOVA-NUM-APOLICE = 3009300001559 OR 3009300001909 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300001559", "3009300001909"))
                {

                    /*" -3826- MOVE 81 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(81, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3827- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3828- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3830- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3831- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3833- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3834- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3836- ADD 1 TO WS-TOTAL-INC AC-CEPR-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_CEPR_INC.Value = WS_WORK_AREAS.AC_CEPR_INC + 1;

                            /*" -3837- ELSE */
                        }
                        else
                        {


                            /*" -3838- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3839- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3841- ADD 1 TO WS-TOTAL-ALT AC-CEPR-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_CEPR_ALT.Value = WS_WORK_AREAS.AC_CEPR_ALT + 1;

                                /*" -3842- ELSE */
                            }
                            else
                            {


                                /*" -3843- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3845- ADD 1 TO WS-TOTAL-EXC AC-CEPR-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_CEPR_EXC.Value = WS_WORK_AREAS.AC_CEPR_EXC + 1;

                                /*" -3846- END-IF */
                            }


                            /*" -3847- END-IF */
                        }


                        /*" -3848- WRITE REG-M1476BHM FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_M1476BHM);

                        M1476BHM.Write(REG_M1476BHM.GetMoveValues().ToString());

                        /*" -3849- ELSE */
                    }
                    else
                    {


                        /*" -3850- CONTINUE */

                        /*" -3851- END-IF */
                    }


                    /*" -3870- END-IF */
                }


                /*" -3871- IF PROPOVA-NUM-APOLICE = 3009300001559 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300001559)
                {

                    /*" -3872- MOVE 84 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(84, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3873- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3874- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3876- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3877- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3879- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3880- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3882- ADD 1 TO WS-TOTAL-INC AC-RECPROF-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_RECPROF_INC.Value = WS_WORK_AREAS.AC_RECPROF_INC + 1;

                            /*" -3883- ELSE */
                        }
                        else
                        {


                            /*" -3884- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3885- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3887- ADD 1 TO WS-TOTAL-ALT AC-RECPROF-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_RECPROF_ALT.Value = WS_WORK_AREAS.AC_RECPROF_ALT + 1;

                                /*" -3888- ELSE */
                            }
                            else
                            {


                                /*" -3889- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3891- ADD 1 TO WS-TOTAL-EXC AC-RECPROF-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_RECPROF_EXC.Value = WS_WORK_AREAS.AC_RECPROF_EXC + 1;

                                /*" -3892- END-IF */
                            }


                            /*" -3893- END-IF */
                        }


                        /*" -3894- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3895- ELSE */
                    }
                    else
                    {


                        /*" -3896- CONTINUE */

                        /*" -3897- END-IF */
                    }


                    /*" -3933- END-IF */
                }


                /*" -3938- IF PROPOVA-NUM-APOLICE = 3009300001559 OR 3009300011970 OR 3009300011971 OR 3009300012002 OR 3009300012003 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300001559", "3009300011970", "3009300011971", "3009300012002", "3009300012003"))
                {

                    /*" -3939- MOVE 85 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(85, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3940- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3941- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3943- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3944- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3946- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3947- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -3949- ADD 1 TO WS-TOTAL-INC AC-PET-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_PET_INC.Value = WS_WORK_AREAS.AC_PET_INC + 1;

                            /*" -3950- ELSE */
                        }
                        else
                        {


                            /*" -3951- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -3952- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3954- ADD 1 TO WS-TOTAL-ALT AC-PET-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_PET_ALT.Value = WS_WORK_AREAS.AC_PET_ALT + 1;

                                /*" -3955- ELSE */
                            }
                            else
                            {


                                /*" -3956- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -3958- ADD 1 TO WS-TOTAL-EXC AC-PET-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_PET_EXC.Value = WS_WORK_AREAS.AC_PET_EXC + 1;

                                /*" -3959- END-IF */
                            }


                            /*" -3960- END-IF */
                        }


                        /*" -3961- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -3962- ELSE */
                    }
                    else
                    {


                        /*" -3963- CONTINUE */

                        /*" -3964- END-IF */
                    }


                    /*" -3989- END-IF */
                }


                /*" -3990- IF PROPOVA-NUM-APOLICE = 3009300001559 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300001559)
                {

                    /*" -3991- MOVE 88 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(88, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -3992- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -3993- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3995- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -3996- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -3998- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -3999- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4001- ADD 1 TO WS-TOTAL-INC AC-CNATALF-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_CNATALF_INC.Value = WS_WORK_AREAS.AC_CNATALF_INC + 1;

                            /*" -4002- ELSE */
                        }
                        else
                        {


                            /*" -4003- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4004- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4006- ADD 1 TO WS-TOTAL-ALT AC-CNATALF-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_CNATALF_ALT.Value = WS_WORK_AREAS.AC_CNATALF_ALT + 1;

                                /*" -4007- ELSE */
                            }
                            else
                            {


                                /*" -4008- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4010- ADD 1 TO WS-TOTAL-EXC AC-CNATALF-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_CNATALF_EXC.Value = WS_WORK_AREAS.AC_CNATALF_EXC + 1;

                                /*" -4011- END-IF */
                            }


                            /*" -4012- END-IF */
                        }


                        /*" -4013- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4014- ELSE */
                    }
                    else
                    {


                        /*" -4015- CONTINUE */

                        /*" -4016- END-IF */
                    }


                    /*" -4063- END-IF */
                }


                /*" -4068- IF PROPOVA-NUM-APOLICE = 3009300001559 OR 3009300011970 OR 3009300011971 OR 3009300012002 OR 3009300012003 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300001559", "3009300011970", "3009300011971", "3009300012002", "3009300012003"))
                {

                    /*" -4069- MOVE 89 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(89, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4070- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -4071- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4073- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4074- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4076- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4077- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4079- ADD 1 TO WS-TOTAL-INC AC-AUTOMOT-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_AUTOMOT_INC.Value = WS_WORK_AREAS.AC_AUTOMOT_INC + 1;

                            /*" -4080- ELSE */
                        }
                        else
                        {


                            /*" -4081- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4082- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4084- ADD 1 TO WS-TOTAL-ALT AC-AUTOMOT-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_AUTOMOT_ALT.Value = WS_WORK_AREAS.AC_AUTOMOT_ALT + 1;

                                /*" -4085- ELSE */
                            }
                            else
                            {


                                /*" -4086- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4088- ADD 1 TO WS-TOTAL-EXC AC-AUTOMOT-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_AUTOMOT_EXC.Value = WS_WORK_AREAS.AC_AUTOMOT_EXC + 1;

                                /*" -4089- END-IF */
                            }


                            /*" -4090- END-IF */
                        }


                        /*" -4091- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4092- ELSE */
                    }
                    else
                    {


                        /*" -4093- CONTINUE */

                        /*" -4094- END-IF */
                    }


                    /*" -4132- END-IF */
                }


                /*" -4137- IF PROPOVA-NUM-APOLICE = 3009300001559 OR 3009300011970 OR 3009300011971 OR 3009300012002 OR 3009300012003 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300001559", "3009300011970", "3009300011971", "3009300012002", "3009300012003"))
                {

                    /*" -4138- MOVE 90 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(90, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4139- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -4140- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4142- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4143- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4145- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4146- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4148- ADD 1 TO WS-TOTAL-INC AC-BIKE-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_BIKE_INC.Value = WS_WORK_AREAS.AC_BIKE_INC + 1;

                            /*" -4149- ELSE */
                        }
                        else
                        {


                            /*" -4150- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4151- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4153- ADD 1 TO WS-TOTAL-ALT AC-BIKE-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_BIKE_ALT.Value = WS_WORK_AREAS.AC_BIKE_ALT + 1;

                                /*" -4154- ELSE */
                            }
                            else
                            {


                                /*" -4155- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4157- ADD 1 TO WS-TOTAL-EXC AC-BIKE-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_BIKE_EXC.Value = WS_WORK_AREAS.AC_BIKE_EXC + 1;

                                /*" -4158- END-IF */
                            }


                            /*" -4159- END-IF */
                        }


                        /*" -4160- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4161- ELSE */
                    }
                    else
                    {


                        /*" -4162- CONTINUE */

                        /*" -4163- END-IF */
                    }


                    /*" -4220- END-IF */
                }


                /*" -4230- IF PROPOVA-NUM-APOLICE = 3009300001909 OR 3009300011970 OR 3009300011970 OR 3009300011970 OR 3009300011971 OR 3009300012002 OR 3009300012003 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300001909", "3009300011970", "3009300011970", "3009300011970", "3009300011971", "3009300012002", "3009300012003"))
                {

                    /*" -4231- MOVE 91 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(91, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4232- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -4233- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4235- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4236- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4238- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4239- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4241- ADD 1 TO WS-TOTAL-INC AC-TELEMED-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_TELEMED_INC.Value = WS_WORK_AREAS.AC_TELEMED_INC + 1;

                            /*" -4242- ELSE */
                        }
                        else
                        {


                            /*" -4243- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4244- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4246- ADD 1 TO WS-TOTAL-ALT AC-TELEMED-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_TELEMED_ALT.Value = WS_WORK_AREAS.AC_TELEMED_ALT + 1;

                                /*" -4247- ELSE */
                            }
                            else
                            {


                                /*" -4248- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4250- ADD 1 TO WS-TOTAL-EXC AC-TELEMED-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_TELEMED_EXC.Value = WS_WORK_AREAS.AC_TELEMED_EXC + 1;

                                /*" -4251- END-IF */
                            }


                            /*" -4252- END-IF */
                        }


                        /*" -4253- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4254- ELSE */
                    }
                    else
                    {


                        /*" -4255- CONTINUE */

                        /*" -4256- END-IF */
                    }


                    /*" -4279- END-IF */
                }


                /*" -4280- IF PROPOVA-NUM-APOLICE = 3009300001909 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300001909)
                {

                    /*" -4281- MOVE 92 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(92, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4282- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -4283- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4285- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4286- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4288- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4289- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4291- ADD 1 TO WS-TOTAL-INC AC-SENIOR-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_SENIOR_INC.Value = WS_WORK_AREAS.AC_SENIOR_INC + 1;

                            /*" -4292- ELSE */
                        }
                        else
                        {


                            /*" -4293- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4294- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4296- ADD 1 TO WS-TOTAL-ALT AC-SENIOR-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_SENIOR_ALT.Value = WS_WORK_AREAS.AC_SENIOR_ALT + 1;

                                /*" -4297- ELSE */
                            }
                            else
                            {


                                /*" -4298- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4300- ADD 1 TO WS-TOTAL-EXC AC-SENIOR-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_SENIOR_EXC.Value = WS_WORK_AREAS.AC_SENIOR_EXC + 1;

                                /*" -4301- END-IF */
                            }


                            /*" -4302- END-IF */
                        }


                        /*" -4303- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4304- ELSE */
                    }
                    else
                    {


                        /*" -4305- CONTINUE */

                        /*" -4306- END-IF */
                    }


                    /*" -4310- END-IF */
                }


                /*" -4327- END-IF. */
            }


            /*" -4339- IF (PROPOVA-NUM-APOLICE = 0097010000889 OR 0109300000550 OR 0109300000909 OR 0109300001394 OR 0109300000559 OR 3009300000909 OR 3009300000559 OR 3009300001909 OR 3009300001559 OR 0109300001553 OR 0109300001575 OR 0109300002001 OR 0109300002002 OR 0109300002003 OR 0109300001966 OR 3009300002002 OR 3009300002003 OR 3009300012002 OR 3009300012003 OR 0109300001970 OR 0109300001971 OR 3009300001970 OR 3009300001971 OR 3009300011970 OR 3009300011971) AND PROPOVA-DATA-QUITACAO < '2016-03-08' */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("0097010000889", "0109300000550", "0109300000909", "0109300001394", "0109300000559", "3009300000909", "3009300000559", "3009300001909", "3009300001559", "0109300001553", "0109300001575", "0109300002001", "0109300002002", "0109300002003", "0109300001966", "3009300002002", "3009300002003", "3009300012002", "3009300012003", "0109300001970", "0109300001971", "3009300001970", "3009300001971", "3009300011970", "3009300011971")) && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO < "2016-03-08")
            {

                /*" -4340- MOVE '40001072240' TO DET-NUM-CONTRATO */
                _.Move("40001072240", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -4341- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -4343- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                {

                    /*" -4344- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -4346- ADD 1 TO WS-TOTAL-INC AC-VIAG-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                    WS_WORK_AREAS.AC_VIAG_INC.Value = WS_WORK_AREAS.AC_VIAG_INC + 1;

                    /*" -4347- ELSE */
                }
                else
                {


                    /*" -4348- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                    {

                        /*" -4349- MOVE 'A' TO DET-TIPO-MOV */
                        _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -4351- ADD 1 TO WS-TOTAL-ALT AC-VIAG-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                        WS_WORK_AREAS.AC_VIAG_ALT.Value = WS_WORK_AREAS.AC_VIAG_ALT + 1;

                        /*" -4352- ELSE */
                    }
                    else
                    {


                        /*" -4353- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -4355- ADD 1 TO WS-TOTAL-EXC AC-VIAG-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                        WS_WORK_AREAS.AC_VIAG_EXC.Value = WS_WORK_AREAS.AC_VIAG_EXC + 1;

                        /*" -4356- END-IF */
                    }


                    /*" -4360- END-IF */
                }


                /*" -4361- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -4369- END-IF. */
            }


            /*" -4440- IF PROPOVA-NUM-APOLICE = 0109300000598 OR 0109300001294 OR 0109300001391 OR 0109300001679 OR 0109300001680 OR 3009300012344 OR 3009300012358 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("0109300000598", "0109300001294", "0109300001391", "0109300001679", "0109300001680", "3009300012344", "3009300012358"))
            {

                /*" -4443- IF PROPOVA-NUM-APOLICE = 3009300012344 OR 3009300012358 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300012344", "3009300012358"))
                {

                    /*" -4444- MOVE 83 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(83, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4445- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -4446- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4448- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4449- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4451- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4452- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4454- ADD 1 TO WS-TOTAL-INC AC-LAR-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_LAR_INC.Value = WS_WORK_AREAS.AC_LAR_INC + 1;

                            /*" -4455- ELSE */
                        }
                        else
                        {


                            /*" -4456- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4457- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4459- ADD 1 TO WS-TOTAL-ALT AC-LAR-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_LAR_ALT.Value = WS_WORK_AREAS.AC_LAR_ALT + 1;

                                /*" -4460- ELSE */
                            }
                            else
                            {


                                /*" -4461- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4463- ADD 1 TO WS-TOTAL-EXC AC-LAR-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_LAR_EXC.Value = WS_WORK_AREAS.AC_LAR_EXC + 1;

                                /*" -4464- END-IF */
                            }


                            /*" -4465- END-IF */
                        }


                        /*" -4466- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4468- ELSE */
                    }
                    else
                    {


                        /*" -4469- IF PROPOFID-IND-TIPO-CONTA NOT = 'S' */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA != "S")
                        {

                            /*" -4470- MOVE '40000042239' TO DET-NUM-CONTRATO */
                            _.Move("40000042239", DETAIL_RECORD.DET_NUM_CONTRATO);

                            /*" -4471- ELSE */
                        }
                        else
                        {


                            /*" -4472- MOVE '40000481388' TO DET-NUM-CONTRATO */
                            _.Move("40000481388", DETAIL_RECORD.DET_NUM_CONTRATO);

                            /*" -4473- END-IF */
                        }


                        /*" -4474- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4476- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4477- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4479- ADD 1 TO WS-TOTAL-INC AC-RESI-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_RESI_INC.Value = WS_WORK_AREAS.AC_RESI_INC + 1;

                            /*" -4480- ELSE */
                        }
                        else
                        {


                            /*" -4481- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4482- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4484- ADD 1 TO WS-TOTAL-ALT AC-RESI-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_RESI_ALT.Value = WS_WORK_AREAS.AC_RESI_ALT + 1;

                                /*" -4485- ELSE */
                            }
                            else
                            {


                                /*" -4486- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4488- ADD 1 TO WS-TOTAL-EXC AC-RESI-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_RESI_EXC.Value = WS_WORK_AREAS.AC_RESI_EXC + 1;

                                /*" -4489- END-IF */
                            }


                            /*" -4490- END-IF */
                        }


                        /*" -4491- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4492- END-IF */
                    }


                    /*" -4493- ELSE */
                }
                else
                {


                    /*" -4494- IF PROPOFID-IND-TIPO-CONTA NOT = 'S' */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA != "S")
                    {

                        /*" -4495- MOVE '40000042239' TO DET-NUM-CONTRATO */
                        _.Move("40000042239", DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4496- ELSE */
                    }
                    else
                    {


                        /*" -4497- MOVE '40000481388' TO DET-NUM-CONTRATO */
                        _.Move("40000481388", DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4498- END-IF */
                    }


                    /*" -4499- ADD 1 TO WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -4501- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                    {

                        /*" -4502- MOVE 'I' TO DET-TIPO-MOV */
                        _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -4504- ADD 1 TO WS-TOTAL-INC AC-RESI-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                        WS_WORK_AREAS.AC_RESI_INC.Value = WS_WORK_AREAS.AC_RESI_INC + 1;

                        /*" -4505- ELSE */
                    }
                    else
                    {


                        /*" -4506- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                        {

                            /*" -4507- MOVE 'A' TO DET-TIPO-MOV */
                            _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4509- ADD 1 TO WS-TOTAL-ALT AC-RESI-ALT */
                            WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                            WS_WORK_AREAS.AC_RESI_ALT.Value = WS_WORK_AREAS.AC_RESI_ALT + 1;

                            /*" -4510- ELSE */
                        }
                        else
                        {


                            /*" -4511- MOVE 'E' TO DET-TIPO-MOV */
                            _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4513- ADD 1 TO WS-TOTAL-EXC AC-RESI-EXC */
                            WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                            WS_WORK_AREAS.AC_RESI_EXC.Value = WS_WORK_AREAS.AC_RESI_EXC + 1;

                            /*" -4514- END-IF */
                        }


                        /*" -4515- END-IF */
                    }


                    /*" -4516- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -4549- END-IF */
                }


                /*" -4552- IF PROPOVA-NUM-APOLICE = 3009300012344 OR 3009300012358 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300012344", "3009300012358"))
                {

                    /*" -4553- MOVE 84 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(84, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4554- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -4555- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4557- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4558- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4560- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4561- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4563- ADD 1 TO WS-TOTAL-INC AC-RECPROF-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_RECPROF_INC.Value = WS_WORK_AREAS.AC_RECPROF_INC + 1;

                            /*" -4564- ELSE */
                        }
                        else
                        {


                            /*" -4565- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4566- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4568- ADD 1 TO WS-TOTAL-ALT AC-RECPROF-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_RECPROF_ALT.Value = WS_WORK_AREAS.AC_RECPROF_ALT + 1;

                                /*" -4569- ELSE */
                            }
                            else
                            {


                                /*" -4570- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4572- ADD 1 TO WS-TOTAL-EXC AC-RECPROF-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_RECPROF_EXC.Value = WS_WORK_AREAS.AC_RECPROF_EXC + 1;

                                /*" -4573- END-IF */
                            }


                            /*" -4574- END-IF */
                        }


                        /*" -4575- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4576- ELSE */
                    }
                    else
                    {


                        /*" -4577- CONTINUE */

                        /*" -4578- END-IF */
                    }


                    /*" -4634- END-IF */
                }


                /*" -4638- IF PROPOVA-NUM-APOLICE = 3009300012344 OR 3009300012358 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300012344", "3009300012358"))
                {

                    /*" -4639- MOVE 16 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(16, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4640- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -4641- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4643- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4644- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4646- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4647- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4649- ADD 1 TO WS-TOTAL-INC AC-MEDICOS-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_MEDICOS_INC.Value = WS_WORK_AREAS.AC_MEDICOS_INC + 1;

                            /*" -4650- ELSE */
                        }
                        else
                        {


                            /*" -4651- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4652- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4654- ADD 1 TO WS-TOTAL-ALT AC-MEDICOS-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_MEDICOS_ALT.Value = WS_WORK_AREAS.AC_MEDICOS_ALT + 1;

                                /*" -4655- ELSE */
                            }
                            else
                            {


                                /*" -4656- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4658- ADD 1 TO WS-TOTAL-EXC AC-MEDICOS-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_MEDICOS_EXC.Value = WS_WORK_AREAS.AC_MEDICOS_EXC + 1;

                                /*" -4659- END-IF */
                            }


                            /*" -4660- END-IF */
                        }


                        /*" -4661- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4662- ELSE */
                    }
                    else
                    {


                        /*" -4663- CONTINUE */

                        /*" -4664- END-IF */
                    }


                    /*" -4720- END-IF */
                }


                /*" -4724- IF PROPOVA-NUM-APOLICE = 3009300012344 OR 3009300012358 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300012344", "3009300012358"))
                {

                    /*" -4725- MOVE 81 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(81, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4726- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -4727- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4729- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4730- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4732- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4733- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4735- ADD 1 TO WS-TOTAL-INC AC-CEPR-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_CEPR_INC.Value = WS_WORK_AREAS.AC_CEPR_INC + 1;

                            /*" -4736- ELSE */
                        }
                        else
                        {


                            /*" -4737- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4738- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4740- ADD 1 TO WS-TOTAL-ALT AC-CEPR-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_CEPR_ALT.Value = WS_WORK_AREAS.AC_CEPR_ALT + 1;

                                /*" -4741- ELSE */
                            }
                            else
                            {


                                /*" -4742- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4744- ADD 1 TO WS-TOTAL-EXC AC-CEPR-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_CEPR_EXC.Value = WS_WORK_AREAS.AC_CEPR_EXC + 1;

                                /*" -4745- END-IF */
                            }


                            /*" -4746- END-IF */
                        }


                        /*" -4747- WRITE REG-M1476BHM FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_M1476BHM);

                        M1476BHM.Write(REG_M1476BHM.GetMoveValues().ToString());

                        /*" -4748- ELSE */
                    }
                    else
                    {


                        /*" -4749- CONTINUE */

                        /*" -4750- END-IF */
                    }


                    /*" -4786- END-IF */
                }


                /*" -4789- IF PROPOVA-NUM-APOLICE = 3009300012344 OR 3009300012358 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3009300012344", "3009300012358"))
                {

                    /*" -4790- MOVE 88 TO VGCOBSUB-COD-COBERTURA */
                    _.Move(88, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                    /*" -4791- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                    R1600_SELECT_NOVA_ASSIST_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                    /*" -4792- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4794- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                        _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4795- ADD 1 TO WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4797- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                        if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                        {

                            /*" -4798- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4800- ADD 1 TO WS-TOTAL-INC AC-AUTOMOT-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                            WS_WORK_AREAS.AC_AUTOMOT_INC.Value = WS_WORK_AREAS.AC_AUTOMOT_INC + 1;

                            /*" -4801- ELSE */
                        }
                        else
                        {


                            /*" -4802- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                            {

                                /*" -4803- MOVE 'A' TO DET-TIPO-MOV */
                                _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4805- ADD 1 TO WS-TOTAL-ALT AC-AUTOMOT-ALT */
                                WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                                WS_WORK_AREAS.AC_AUTOMOT_ALT.Value = WS_WORK_AREAS.AC_AUTOMOT_ALT + 1;

                                /*" -4806- ELSE */
                            }
                            else
                            {


                                /*" -4807- MOVE 'E' TO DET-TIPO-MOV */
                                _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4809- ADD 1 TO WS-TOTAL-EXC AC-AUTOMOT-EXC */
                                WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                                WS_WORK_AREAS.AC_AUTOMOT_EXC.Value = WS_WORK_AREAS.AC_AUTOMOT_EXC + 1;

                                /*" -4810- END-IF */
                            }


                            /*" -4811- END-IF */
                        }


                        /*" -4812- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4813- ELSE */
                    }
                    else
                    {


                        /*" -4814- CONTINUE */

                        /*" -4815- END-IF */
                    }


                    /*" -4819- END-IF */
                }


                /*" -4830- END-IF. */
            }


            /*" -4838- IF (PROPOVA-NUM-APOLICE = 0109300000598 OR 0109300001294 OR 0109300001391 OR 0109300001679 OR 0109300001680) AND (PROPOVA-DATA-QUITACAO < '2016-03-08' ) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("0109300000598", "0109300001294", "0109300001391", "0109300001679", "0109300001680")) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO < "2016-03-08"))
            {

                /*" -4840- MOVE '40001072240' TO DET-NUM-CONTRATO */
                _.Move("40001072240", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -4841- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -4843- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                {

                    /*" -4844- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -4846- ADD 1 TO WS-TOTAL-INC AC-VIAG-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;
                    WS_WORK_AREAS.AC_VIAG_INC.Value = WS_WORK_AREAS.AC_VIAG_INC + 1;

                    /*" -4847- ELSE */
                }
                else
                {


                    /*" -4848- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                    {

                        /*" -4849- MOVE 'A' TO DET-TIPO-MOV */
                        _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -4851- ADD 1 TO WS-TOTAL-ALT AC-VIAG-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;
                        WS_WORK_AREAS.AC_VIAG_ALT.Value = WS_WORK_AREAS.AC_VIAG_ALT + 1;

                        /*" -4852- ELSE */
                    }
                    else
                    {


                        /*" -4853- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -4855- ADD 1 TO WS-TOTAL-EXC AC-VIAG-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;
                        WS_WORK_AREAS.AC_VIAG_EXC.Value = WS_WORK_AREAS.AC_VIAG_EXC + 1;

                        /*" -4856- END-IF */
                    }


                    /*" -4860- END-IF */
                }


                /*" -4861- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -4872- END-IF. */
            }


            /*" -4873- IF (MOVIMVGA-COD-OPERACAO = 8888) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 8888))
            {

                /*" -4876- MOVE ENDOSSOS-COD-PRODUTO TO PROPOVA-COD-PRODUTO */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

                /*" -4877- IF ENDOSSOS-COD-PRODUTO EQUAL 8126 OR 8127 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8126", "8127"))
                {

                    /*" -4878- MOVE '40001072240' TO DET-NUM-CONTRATO */
                    _.Move("40001072240", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -4880- ADD 1 TO AC-VIAG-INC WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.AC_VIAG_INC.Value = WS_WORK_AREAS.AC_VIAG_INC + 1;
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -4881- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -4882- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -4883- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -4891- END-IF */
                }


                /*" -4905- IF ENDOSSOS-COD-PRODUTO EQUAL 8114 OR 8115 OR 8116 OR 8117 OR 8118 OR 8119 OR 8120 OR 8121 OR 8122 OR 8123 OR JVPRD8114 OR JVPRD8115 OR JVPRD8116 OR JVPRD8117 OR JVPRD8118 OR JVPRD8119 OR JVPRD8120 OR JVPRD8121 OR JVPRD8122 OR JVPRD8123 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8114", "8115", "8116", "8117", "8118", "8119", "8120", "8121", "8122", "8123", JVBKINCL.JV_PRODUTOS.JVPRD8114.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8115.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8116.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8117.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8118.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8119.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8120.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8121.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8122.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8123.ToString()))
                {

                    /*" -4906- MOVE '40001262238' TO DET-NUM-CONTRATO */
                    _.Move("40001262238", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -4908- ADD 1 TO AC-FARM-INC WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.AC_FARM_INC.Value = WS_WORK_AREAS.AC_FARM_INC + 1;
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -4909- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -4910- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -4911- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -4923- END-IF */
                }


                /*" -4926- IF ENDOSSOS-COD-PRODUTO = 8103 OR 8116 OR 8121 OR 8128 OR JVPRD8116 OR JVPRD8121 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8103", "8116", "8121", "8128", JVBKINCL.JV_PRODUTOS.JVPRD8116.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8121.ToString()))
                {

                    /*" -4927- IF PROPOFID-IND-TIPO-CONTA NOT = 'S' */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA != "S")
                    {

                        /*" -4928- MOVE '40000042239' TO DET-NUM-CONTRATO */
                        _.Move("40000042239", DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4929- ELSE */
                    }
                    else
                    {


                        /*" -4930- MOVE '40000481388' TO DET-NUM-CONTRATO */
                        _.Move("40000481388", DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4932- END-IF */
                    }


                    /*" -4934- ADD 1 TO AC-RESI-INC WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.AC_RESI_INC.Value = WS_WORK_AREAS.AC_RESI_INC + 1;
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -4935- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -4936- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -4941- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -4945- ELSE */
                }
                else
                {


                    /*" -4948- IF ENDOSSOS-COD-PRODUTO EQUAL 8114 OR 8122 OR JVPRD8114 OR JVPRD8122 */

                    if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8114", "8122", JVBKINCL.JV_PRODUTOS.JVPRD8114.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8122.ToString()))
                    {

                        /*" -4949- MOVE '40001172543' TO DET-NUM-CONTRATO */
                        _.Move("40001172543", DETAIL_RECORD.DET_NUM_CONTRATO);

                        /*" -4951- ADD 1 TO AC-EDUCA-INC WS-TOTAL-GRAVADOS */
                        WS_WORK_AREAS.AC_EDUCA_INC.Value = WS_WORK_AREAS.AC_EDUCA_INC + 1;
                        WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                        /*" -4952- MOVE 'I' TO DET-TIPO-MOV */
                        _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -4953- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -4958- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                        _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                        MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                        /*" -4962- ELSE */
                    }
                    else
                    {


                        /*" -4966- IF ENDOSSOS-COD-PRODUTO EQUAL 8138 */

                        if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 8138)
                        {

                            /*" -4967- MOVE '40001172590' TO DET-NUM-CONTRATO */
                            _.Move("40001172590", DETAIL_RECORD.DET_NUM_CONTRATO);

                            /*" -4969- ADD 1 TO AC-EDUCA-INC-U WS-TOTAL-GRAVADOS */
                            WS_WORK_AREAS.AC_EDUCA_INC_U.Value = WS_WORK_AREAS.AC_EDUCA_INC_U + 1;
                            WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                            /*" -4970- MOVE 'I' TO DET-TIPO-MOV */
                            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                            /*" -4971- ADD 1 TO WS-TOTAL-INC */
                            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                            /*" -4976- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                            _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                            MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                            /*" -4980- ELSE */
                        }
                        else
                        {


                            /*" -4986- IF ENDOSSOS-COD-PRODUTO EQUAL 8117 OR 8123 OR JVPRD8117 OR JVPRD8123 */

                            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8117", "8123", JVBKINCL.JV_PRODUTOS.JVPRD8117.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8123.ToString()))
                            {

                                /*" -4987- MOVE '40000032503' TO DET-NUM-CONTRATO */
                                _.Move("40000032503", DETAIL_RECORD.DET_NUM_CONTRATO);

                                /*" -4989- ADD 1 TO AC-HDESK-INC WS-TOTAL-GRAVADOS */
                                WS_WORK_AREAS.AC_HDESK_INC.Value = WS_WORK_AREAS.AC_HDESK_INC + 1;
                                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                                /*" -4990- MOVE 'I' TO DET-TIPO-MOV */
                                _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                                /*" -4991- ADD 1 TO WS-TOTAL-INC */
                                WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                                /*" -4996- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                                /*" -5024- ELSE */
                            }
                            else
                            {


                                /*" -5041- IF ENDOSSOS-COD-PRODUTO NOT EQUAL 8126 AND 8127 AND 8128 AND 3701 AND JVPRD3701 AND 8521 AND 8528 AND 8529 AND 8530 AND 8531 AND 8532 AND 8533 AND 8534 */

                                if (!ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8126", "8127", "8128", "3701", JVBKINCL.JV_PRODUTOS.JVPRD3701.ToString(), "8521", "8528", "8529", "8530", "8531", "8532", "8533", "8534"))
                                {

                                    /*" -5042- MOVE '40001152343' TO DET-NUM-CONTRATO */
                                    _.Move("40001152343", DETAIL_RECORD.DET_NUM_CONTRATO);

                                    /*" -5044- ADD 1 TO AC-RPROF-INC WS-TOTAL-GRAVADOS */
                                    WS_WORK_AREAS.AC_RPROF_INC.Value = WS_WORK_AREAS.AC_RPROF_INC + 1;
                                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                                    /*" -5045- MOVE 'I' TO DET-TIPO-MOV */
                                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                                    /*" -5046- ADD 1 TO WS-TOTAL-INC */
                                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                                    /*" -5061- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                                    /*" -5062- IF PROPOFID-IND-TIPO-CONTA NOT = 'S' */

                                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA != "S")
                                    {

                                        /*" -5063- MOVE '40000042239' TO DET-NUM-CONTRATO */
                                        _.Move("40000042239", DETAIL_RECORD.DET_NUM_CONTRATO);

                                        /*" -5064- ELSE */
                                    }
                                    else
                                    {


                                        /*" -5065- MOVE '40000481388' TO DET-NUM-CONTRATO */
                                        _.Move("40000481388", DETAIL_RECORD.DET_NUM_CONTRATO);

                                        /*" -5067- END-IF */
                                    }


                                    /*" -5069- ADD 1 TO AC-RESI-INC WS-TOTAL-GRAVADOS */
                                    WS_WORK_AREAS.AC_RESI_INC.Value = WS_WORK_AREAS.AC_RESI_INC + 1;
                                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                                    /*" -5070- MOVE 'I' TO DET-TIPO-MOV */
                                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                                    /*" -5071- ADD 1 TO WS-TOTAL-INC */
                                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                                    /*" -5075- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                                    /*" -5076- END-IF */
                                }


                                /*" -5077- END-IF */
                            }


                            /*" -5078- END-IF */
                        }


                        /*" -5079- END-IF */
                    }


                    /*" -5084- END-IF */
                }


                /*" -5090- IF ENDOSSOS-COD-PRODUTO EQUAL 8108 OR 8118 OR 8119 OR JVPRD8118 OR JVPRD8119 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8108", "8118", "8119", JVBKINCL.JV_PRODUTOS.JVPRD8118.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8119.ToString()))
                {

                    /*" -5091- MOVE '40001102241' TO DET-NUM-CONTRATO */
                    _.Move("40001102241", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5093- ADD 1 TO AC-NUTR-INC WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.AC_NUTR_INC.Value = WS_WORK_AREAS.AC_NUTR_INC + 1;
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -5094- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -5095- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -5096- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -5104- END-IF */
                }


                /*" -5108- IF ENDOSSOS-COD-PRODUTO EQUAL 3701 OR JVPRD3701 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("3701", JVBKINCL.JV_PRODUTOS.JVPRD3701.ToString()))
                {

                    /*" -5109- MOVE '40000142242' TO DET-NUM-CONTRATO */
                    _.Move("40000142242", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5111- ADD 1 TO AC-CESBA-INC WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.AC_CESBA_INC.Value = WS_WORK_AREAS.AC_CESBA_INC + 1;
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -5112- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -5113- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -5114- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -5125- END-IF */
                }


                /*" -5126- IF ENDOSSOS-COD-PRODUTO EQUAL 8530 OR 8531 OR 8532 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8530", "8531", "8532"))
                {

                    /*" -5127- MOVE '40000527287' TO DET-NUM-CONTRATO */
                    _.Move("40000527287", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5129- ADD 1 TO AC-TELEMED-INC WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.AC_TELEMED_INC.Value = WS_WORK_AREAS.AC_TELEMED_INC + 1;
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -5130- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -5131- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -5132- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -5143- END-IF */
                }


                /*" -5144- IF ENDOSSOS-COD-PRODUTO EQUAL 8530 OR 8531 OR 8532 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8530", "8531", "8532"))
                {

                    /*" -5145- MOVE '40000528999' TO DET-NUM-CONTRATO */
                    _.Move("40000528999", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5147- ADD 1 TO AC-AMBIENT-INC WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.AC_AMBIENT_INC.Value = WS_WORK_AREAS.AC_AMBIENT_INC + 1;
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -5148- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -5149- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -5150- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -5161- END-IF */
                }


                /*" -5162- IF ENDOSSOS-COD-PRODUTO EQUAL 8530 OR 8531 OR 8532 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8530", "8531", "8532"))
                {

                    /*" -5163- MOVE '40000529007' TO DET-NUM-CONTRATO */
                    _.Move("40000529007", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5165- ADD 1 TO AC-REPARO-INC WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.AC_REPARO_INC.Value = WS_WORK_AREAS.AC_REPARO_INC + 1;
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -5166- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -5167- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -5168- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -5173- END-IF */
                }


                /*" -5175- PERFORM R1702-00-FACIL-APOIO-FAMILIA THRU R1702-99-SAIDA */

                R1702_00_FACIL_APOIO_FAMILIA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1702_99_SAIDA*/


                /*" -5177- PERFORM R1703-00-SEGURO-AP-BEM-ESTAR THRU R1703-99-SAIDA */

                R1703_00_SEGURO_AP_BEM_ESTAR_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1703_99_SAIDA*/


                /*" -5206- END-IF. */
            }


            /*" -5213- IF (MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (ENDOSSOS-COD-PRODUTO EQUAL 8213 OR 9311 OR 9354 OR 8213 OR JVPRD9311 ) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8213", "9311", "9354", "8213", JVBKINCL.JV_PRODUTOS.JVPRD9311.ToString())))
            {

                /*" -5215- MOVE '40001052587' TO DET-NUM-CONTRATO */
                _.Move("40001052587", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5217- ADD 1 TO AC-CESTABONUS-INC WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.AC_CESTABONUS_INC.Value = WS_WORK_AREAS.AC_CESTABONUS_INC + 1;
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -5218- MOVE 'I' TO DET-TIPO-MOV */
                _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5219- ADD 1 TO WS-TOTAL-INC */
                WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                /*" -5220- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5234- END-IF. */
            }


            /*" -5239- IF (MOVIMVGA-COD-OPERACAO = 9998) AND (PROPOVA-NUM-APOLICE = 109300002554) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300002554))
            {

                /*" -5240- MOVE '40001072240' TO DET-NUM-CONTRATO */
                _.Move("40001072240", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5242- ADD 1 TO AC-VIAG-INC WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.AC_VIAG_INC.Value = WS_WORK_AREAS.AC_VIAG_INC + 1;
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -5244- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                {

                    /*" -5245- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -5246- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -5247- ELSE */
                }
                else
                {


                    /*" -5248- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                    {

                        /*" -5249- MOVE 'A' TO DET-TIPO-MOV */
                        _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -5250- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5251- ELSE */
                    }
                    else
                    {


                        /*" -5252- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -5253- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5254- END-IF */
                    }


                    /*" -5255- END-IF */
                }


                /*" -5256- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5271- END-IF. */
            }


            /*" -5278- IF (PROPOVA-NUM-APOLICE = 0109300001980 OR 0109300003691 OR 0109300003692) AND (PROPOVA-COD-PRODUTO = 9311) AND (PROPOVA-COD-PRODUTO = JVPRD9311) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("0109300001980", "0109300003691", "0109300003692")) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9311) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9311))
            {

                /*" -5279- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5281- IF (MOVIMVGA-COD-OPERACAO GREATER 99) AND (MOVIMVGA-COD-OPERACAO LESS 200) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 99) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200))
                {

                    /*" -5282- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -5283- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -5284- ADD 1 TO AC-SAFES-INC */
                    WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                    /*" -5285- ELSE */
                }
                else
                {


                    /*" -5286- IF (MOVIMVGA-COD-OPERACAO EQUAL 9999) */

                    if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9999))
                    {

                        /*" -5287- MOVE 'A' TO DET-TIPO-MOV */
                        _.Move("A", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -5288- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5289- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5290- ELSE */
                    }
                    else
                    {


                        /*" -5291- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -5292- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5293- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5294- END-IF */
                    }


                    /*" -5295- END-IF */
                }


                /*" -5296- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5307- END-IF. */
            }


            /*" -5312- IF (MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (MOVIMVGA-NUM-APOLICE EQUAL 108211251755) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.GetMoveValues().ToInt() == 108211251755))
            {

                /*" -5313- IF (MOVIMVGA-COD-SUBGRUPO EQUAL 02) */

                if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO == 02))
                {

                    /*" -5314- MOVE '40000142242' TO DET-NUM-CONTRATO */
                    _.Move("40000142242", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5316- ADD 1 TO WS-TOTAL-GRAVADOS */
                    WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                    /*" -5317- IF (WHOST-TIPO-MOVIMENTO = 'I' ) */

                    if ((WHOST_TIPO_MOVIMENTO == "I"))
                    {

                        /*" -5318- MOVE 'I' TO DET-TIPO-MOV */
                        _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -5319- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5320- ADD 1 TO AC-CESBA-INC */
                        WS_WORK_AREAS.AC_CESBA_INC.Value = WS_WORK_AREAS.AC_CESBA_INC + 1;

                        /*" -5321- ELSE */
                    }
                    else
                    {


                        /*" -5322- MOVE 'E' TO DET-TIPO-MOV */
                        _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                        /*" -5323- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5324- ADD 1 TO AC-CESBA-EXC */
                        WS_WORK_AREAS.AC_CESBA_EXC.Value = WS_WORK_AREAS.AC_CESBA_EXC + 1;

                        /*" -5326- END-IF */
                    }


                    /*" -5327- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                    _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                    MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                    /*" -5343- END-IF */
                }


                /*" -5344- IF PROPOFID-IND-TIPO-CONTA NOT = 'S' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA != "S")
                {

                    /*" -5345- MOVE '40000042239' TO DET-NUM-CONTRATO */
                    _.Move("40000042239", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5346- ELSE */
                }
                else
                {


                    /*" -5347- MOVE '40000481388' TO DET-NUM-CONTRATO */
                    _.Move("40000481388", DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5349- END-IF */
                }


                /*" -5351- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -5352- IF (WHOST-TIPO-MOVIMENTO = 'I' ) */

                if ((WHOST_TIPO_MOVIMENTO == "I"))
                {

                    /*" -5353- MOVE 'I' TO DET-TIPO-MOV */
                    _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -5354- ADD 1 TO WS-TOTAL-INC */
                    WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                    /*" -5355- ADD 1 TO AC-RESI-INC */
                    WS_WORK_AREAS.AC_RESI_INC.Value = WS_WORK_AREAS.AC_RESI_INC + 1;

                    /*" -5356- ELSE */
                }
                else
                {


                    /*" -5357- MOVE 'E' TO DET-TIPO-MOV */
                    _.Move("E", DETAIL_RECORD.DET_TIPO_MOV);

                    /*" -5358- ADD 1 TO WS-TOTAL-EXC */
                    WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                    /*" -5359- ADD 1 TO AC-RESI-EXC */
                    WS_WORK_AREAS.AC_RESI_EXC.Value = WS_WORK_AREAS.AC_RESI_EXC + 1;

                    /*" -5361- END-IF */
                }


                /*" -5365- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5386- END-IF. */
            }


            /*" -5391- IF ((MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (PROPOVA-NUM-APOLICE EQUAL 3009300006739) AND (MOVIMVGA-COD-SUBGRUPO EQUAL 01 OR 02 OR 03 OR 04 OR 05 OR 06 OR 07)) */

            if (((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300006739) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("01", "02", "03", "04", "05", "06", "07"))))
            {

                /*" -5393- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5395- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5396- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5397- WHEN 'I' */
                    case "I":

                        /*" -5398- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5399- ADD 1 TO AC-SAFES-INC */
                        WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                        /*" -5400- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5401- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5402- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5403- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5404- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5405- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5406- WHEN OTHER */
                        break;
                    default:

                        /*" -5407- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5408- ADD 1 TO AC-SAFES-X */
                        WS_WORK_AREAS.AC_SAFES_X.Value = WS_WORK_AREAS.AC_SAFES_X + 1;

                        /*" -5409- END-EVALUATE */
                        break;
                }


                /*" -5413- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5433- END-IF. */
            }


            /*" -5437- IF ((MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (PROPOVA-NUM-APOLICE EQUAL 3009300006746) AND (MOVIMVGA-COD-SUBGRUPO EQUAL 01)) */

            if (((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300006746) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO == 01)))
            {

                /*" -5439- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5441- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5442- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5443- WHEN 'I' */
                    case "I":

                        /*" -5444- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5445- ADD 1 TO AC-SAFES-INC */
                        WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                        /*" -5446- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5447- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5448- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5449- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5450- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5451- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5452- WHEN OTHER */
                        break;
                    default:

                        /*" -5453- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5454- ADD 1 TO AC-SAFES-X */
                        WS_WORK_AREAS.AC_SAFES_X.Value = WS_WORK_AREAS.AC_SAFES_X + 1;

                        /*" -5455- END-EVALUATE */
                        break;
                }


                /*" -5459- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5479- END-IF. */
            }


            /*" -5483- IF ((MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (PROPOVA-NUM-APOLICE EQUAL 3009300006773) AND (MOVIMVGA-COD-SUBGRUPO EQUAL 01 OR 02 OR 03)) */

            if (((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300006773) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("01", "02", "03"))))
            {

                /*" -5485- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5487- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5488- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5489- WHEN 'I' */
                    case "I":

                        /*" -5490- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5491- ADD 1 TO AC-SAFES-INC */
                        WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                        /*" -5492- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5493- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5494- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5495- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5496- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5497- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5498- WHEN OTHER */
                        break;
                    default:

                        /*" -5499- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5500- ADD 1 TO AC-SAFES-X */
                        WS_WORK_AREAS.AC_SAFES_X.Value = WS_WORK_AREAS.AC_SAFES_X + 1;

                        /*" -5502- END-EVALUATE */
                        break;
                }


                /*" -5506- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5529- END-IF. */
            }


            /*" -5535- IF ((MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (PROPOVA-NUM-APOLICE EQUAL 3009300006515) AND (MOVIMVGA-COD-SUBGRUPO EQUAL 01)) */

            if (((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300006515) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO == 01)))
            {

                /*" -5537- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5539- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5540- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5541- WHEN 'I' */
                    case "I":

                        /*" -5542- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5543- ADD 1 TO AC-SAFES-INC */
                        WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                        /*" -5544- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5545- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5546- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5547- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5548- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5549- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5550- WHEN OTHER */
                        break;
                    default:

                        /*" -5551- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5552- ADD 1 TO AC-SAFES-X */
                        WS_WORK_AREAS.AC_SAFES_X.Value = WS_WORK_AREAS.AC_SAFES_X + 1;

                        /*" -5554- END-EVALUATE */
                        break;
                }


                /*" -5562- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5566- MOVE '40001152343' TO DET-NUM-CONTRATO */
                _.Move("40001152343", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5567- MOVE '40001152343' TO DET-NUM-CONTRATO */
                _.Move("40001152343", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5569- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5570- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5571- WHEN 'I' */
                    case "I":

                        /*" -5572- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5573- ADD 1 TO AC-RPROF-INC */
                        WS_WORK_AREAS.AC_RPROF_INC.Value = WS_WORK_AREAS.AC_RPROF_INC + 1;

                        /*" -5574- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5575- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5576- ADD 1 TO AC-RPROF-ALT */
                        WS_WORK_AREAS.AC_RPROF_ALT.Value = WS_WORK_AREAS.AC_RPROF_ALT + 1;

                        /*" -5577- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5578- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5579- ADD 1 TO AC-RPROF-EXC */
                        WS_WORK_AREAS.AC_RPROF_EXC.Value = WS_WORK_AREAS.AC_RPROF_EXC + 1;

                        /*" -5580- WHEN OTHER */
                        break;
                    default:

                        /*" -5581- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5582- ADD 1 TO AC-RPROF-X */
                        WS_WORK_AREAS.AC_RPROF_X.Value = WS_WORK_AREAS.AC_RPROF_X + 1;

                        /*" -5584- END-EVALUATE */
                        break;
                }


                /*" -5611- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5621- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5622- MOVE '40001102241' TO DET-NUM-CONTRATO */
                _.Move("40001102241", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5624- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5625- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5626- WHEN 'I' */
                    case "I":

                        /*" -5627- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5628- ADD 1 TO AC-NUTR-INC */
                        WS_WORK_AREAS.AC_NUTR_INC.Value = WS_WORK_AREAS.AC_NUTR_INC + 1;

                        /*" -5629- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5630- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5631- ADD 1 TO AC-NUTR-ALT */
                        WS_WORK_AREAS.AC_NUTR_ALT.Value = WS_WORK_AREAS.AC_NUTR_ALT + 1;

                        /*" -5632- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5633- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5634- ADD 1 TO AC-NUTR-EXC */
                        WS_WORK_AREAS.AC_NUTR_EXC.Value = WS_WORK_AREAS.AC_NUTR_EXC + 1;

                        /*" -5635- WHEN OTHER */
                        break;
                    default:

                        /*" -5636- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5637- ADD 1 TO AC-NUTR-X */
                        WS_WORK_AREAS.AC_NUTR_X.Value = WS_WORK_AREAS.AC_NUTR_X + 1;

                        /*" -5638- END-EVALUATE */
                        break;
                }


                /*" -5642- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5663- END-IF. */
            }


            /*" -5668- IF ((MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (PROPOVA-NUM-APOLICE EQUAL 109300001980) AND (MOVIMVGA-COD-SUBGRUPO EQUAL 04 OR 05 OR 06 OR 11 OR 12 OR 13 OR 14 OR 15 OR 16 OR 17)) */

            if (((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300001980) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("04", "05", "06", "11", "12", "13", "14", "15", "16", "17"))))
            {

                /*" -5670- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5672- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5673- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5674- WHEN 'I' */
                    case "I":

                        /*" -5675- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5676- ADD 1 TO AC-SAFES-INC */
                        WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                        /*" -5677- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5678- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5679- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5680- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5681- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5682- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5683- WHEN OTHER */
                        break;
                    default:

                        /*" -5684- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5685- ADD 1 TO AC-SAFES-X */
                        WS_WORK_AREAS.AC_SAFES_X.Value = WS_WORK_AREAS.AC_SAFES_X + 1;

                        /*" -5687- END-EVALUATE */
                        break;
                }


                /*" -5691- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5711- END-IF. */
            }


            /*" -5715- IF ((MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (PROPOVA-NUM-APOLICE EQUAL 109300001521) AND (MOVIMVGA-COD-SUBGRUPO EQUAL 01 OR 02 OR 03)) */

            if (((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300001521) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("01", "02", "03"))))
            {

                /*" -5717- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5719- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5720- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5721- WHEN 'I' */
                    case "I":

                        /*" -5722- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5723- ADD 1 TO AC-SAFES-INC */
                        WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                        /*" -5724- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5725- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5726- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5727- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5728- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5729- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5730- WHEN OTHER */
                        break;
                    default:

                        /*" -5731- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5732- ADD 1 TO AC-SAFES-X */
                        WS_WORK_AREAS.AC_SAFES_X.Value = WS_WORK_AREAS.AC_SAFES_X + 1;

                        /*" -5734- END-EVALUATE */
                        break;
                }


                /*" -5738- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5758- END-IF. */
            }


            /*" -5762- IF ((MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (PROPOVA-NUM-APOLICE EQUAL 108211034287) AND (MOVIMVGA-COD-SUBGRUPO EQUAL 01)) */

            if (((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.GetMoveValues().ToInt() == 108211034287) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO == 01)))
            {

                /*" -5764- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5766- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5767- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5768- WHEN 'I' */
                    case "I":

                        /*" -5769- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5770- ADD 1 TO AC-SAFES-INC */
                        WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                        /*" -5771- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5772- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5773- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5774- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5775- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5776- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5777- WHEN OTHER */
                        break;
                    default:

                        /*" -5778- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5779- ADD 1 TO AC-SAFES-X */
                        WS_WORK_AREAS.AC_SAFES_X.Value = WS_WORK_AREAS.AC_SAFES_X + 1;

                        /*" -5780- END-EVALUATE */
                        break;
                }


                /*" -5784- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5804- END-IF. */
            }


            /*" -5808- IF ((MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (PROPOVA-NUM-APOLICE EQUAL 109300003228) AND (MOVIMVGA-COD-SUBGRUPO EQUAL 01)) */

            if (((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300003228) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO == 01)))
            {

                /*" -5810- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5812- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5813- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5814- WHEN 'I' */
                    case "I":

                        /*" -5815- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5816- ADD 1 TO AC-SAFES-INC */
                        WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                        /*" -5817- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5818- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5819- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5820- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5821- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5822- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5823- WHEN OTHER */
                        break;
                    default:

                        /*" -5824- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5825- ADD 1 TO AC-SAFES-X */
                        WS_WORK_AREAS.AC_SAFES_X.Value = WS_WORK_AREAS.AC_SAFES_X + 1;

                        /*" -5826- END-EVALUATE */
                        break;
                }


                /*" -5830- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5850- END-IF. */
            }


            /*" -5854- IF ((MOVIMVGA-COD-OPERACAO EQUAL 9998) AND (PROPOVA-NUM-APOLICE EQUAL 109300003658) AND (MOVIMVGA-COD-SUBGRUPO EQUAL 01)) */

            if (((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 9998) && (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300003658) && (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO == 01)))
            {

                /*" -5856- MOVE '40000142324' TO DET-NUM-CONTRATO */
                _.Move("40000142324", DETAIL_RECORD.DET_NUM_CONTRATO);

                /*" -5858- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5859- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5860- WHEN 'I' */
                    case "I":

                        /*" -5861- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5862- ADD 1 TO AC-SAFES-INC */
                        WS_WORK_AREAS.AC_SAFES_INC.Value = WS_WORK_AREAS.AC_SAFES_INC + 1;

                        /*" -5863- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5864- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5865- ADD 1 TO AC-SAFES-ALT */
                        WS_WORK_AREAS.AC_SAFES_ALT.Value = WS_WORK_AREAS.AC_SAFES_ALT + 1;

                        /*" -5866- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5867- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5868- ADD 1 TO AC-SAFES-EXC */
                        WS_WORK_AREAS.AC_SAFES_EXC.Value = WS_WORK_AREAS.AC_SAFES_EXC + 1;

                        /*" -5869- WHEN OTHER */
                        break;
                    default:

                        /*" -5870- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5871- ADD 1 TO AC-SAFES-X */
                        WS_WORK_AREAS.AC_SAFES_X.Value = WS_WORK_AREAS.AC_SAFES_X + 1;

                        /*" -5872- END-EVALUATE */
                        break;
                }


                /*" -5876- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5893- END-IF. */
            }


            /*" -5897- IF PROPOVA-NUM-APOLICE = 3008211398371 OR 3008211398372 OR 3009300007527 OR 3009300007528 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("3008211398371", "3008211398372", "3009300007527", "3009300007528"))
            {

                /*" -5898- MOVE 93 TO VGCOBSUB-COD-COBERTURA */
                _.Move(93, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -5899- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                R1600_SELECT_NOVA_ASSIST_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                /*" -5900- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -5901- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                    _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5902- ELSE */
                }
                else
                {


                    /*" -5903- MOVE 40000528999 TO DET-NUM-CONTRATO */
                    _.Move(40000528999, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -5904- END-IF */
                }


                /*" -5905- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -5906- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -5907- WHEN 'I' */
                    case "I":

                        /*" -5908- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -5909- ADD 1 TO AC-AMBIENT-INC */
                        WS_WORK_AREAS.AC_AMBIENT_INC.Value = WS_WORK_AREAS.AC_AMBIENT_INC + 1;

                        /*" -5910- WHEN 'A' */
                        break;
                    case "A":

                        /*" -5911- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -5912- ADD 1 TO AC-AMBIENT-ALT */
                        WS_WORK_AREAS.AC_AMBIENT_ALT.Value = WS_WORK_AREAS.AC_AMBIENT_ALT + 1;

                        /*" -5913- WHEN 'E' */
                        break;
                    case "E":

                        /*" -5914- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -5915- ADD 1 TO AC-AMBIENT-EXC */
                        WS_WORK_AREAS.AC_AMBIENT_EXC.Value = WS_WORK_AREAS.AC_AMBIENT_EXC + 1;

                        /*" -5916- WHEN OTHER */
                        break;
                    default:

                        /*" -5917- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -5918- ADD 1 TO AC-AMBIENT-X */
                        WS_WORK_AREAS.AC_AMBIENT_X.Value = WS_WORK_AREAS.AC_AMBIENT_X + 1;

                        /*" -5919- END-EVALUATE */
                        break;
                }


                /*" -5920- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -5921- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -6004- END-IF. */
            }


            /*" -6009- IF (PROPOVA-NUM-APOLICE = 3009300007513 AND MOVIMVGA-COD-SUBGRUPO EQUAL 02 OR 03 OR 05 OR 06) OR (PROPOVA-NUM-APOLICE = 3009300007514 AND MOVIMVGA-COD-SUBGRUPO EQUAL 02 OR 03) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007513 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("02", "03", "05", "06")) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007514 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("02", "03")))
            {

                /*" -6010- MOVE 94 TO VGCOBSUB-COD-COBERTURA */
                _.Move(94, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -6011- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                R1600_SELECT_NOVA_ASSIST_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                /*" -6012- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -6013- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                    _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6014- ELSE */
                }
                else
                {


                    /*" -6015- MOVE 40000529003 TO DET-NUM-CONTRATO */
                    _.Move(40000529003, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6016- END-IF */
                }


                /*" -6017- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -6018- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -6019- WHEN 'I' */
                    case "I":

                        /*" -6020- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -6021- ADD 1 TO AC-FINANCE-INC */
                        WS_WORK_AREAS.AC_FINANCE_INC.Value = WS_WORK_AREAS.AC_FINANCE_INC + 1;

                        /*" -6022- WHEN 'A' */
                        break;
                    case "A":

                        /*" -6023- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -6024- ADD 1 TO AC-FINANCE-ALT */
                        WS_WORK_AREAS.AC_FINANCE_ALT.Value = WS_WORK_AREAS.AC_FINANCE_ALT + 1;

                        /*" -6025- WHEN 'E' */
                        break;
                    case "E":

                        /*" -6026- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -6027- ADD 1 TO AC-FINANCE-EXC */
                        WS_WORK_AREAS.AC_FINANCE_EXC.Value = WS_WORK_AREAS.AC_FINANCE_EXC + 1;

                        /*" -6028- WHEN OTHER */
                        break;
                    default:

                        /*" -6029- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -6030- ADD 1 TO AC-FINANCE-X */
                        WS_WORK_AREAS.AC_FINANCE_X.Value = WS_WORK_AREAS.AC_FINANCE_X + 1;

                        /*" -6031- END-EVALUATE */
                        break;
                }


                /*" -6032- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -6033- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -6108- END-IF. */
            }


            /*" -6113- IF (PROPOVA-NUM-APOLICE = 3009300007513 AND MOVIMVGA-COD-SUBGRUPO EQUAL 02 OR 03 OR 05 OR 06) OR (PROPOVA-NUM-APOLICE = 3009300007514 AND MOVIMVGA-COD-SUBGRUPO EQUAL 02 OR 03) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007513 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("02", "03", "05", "06")) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007514 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("02", "03")))
            {

                /*" -6114- MOVE 95 TO VGCOBSUB-COD-COBERTURA */
                _.Move(95, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -6115- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                R1600_SELECT_NOVA_ASSIST_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                /*" -6116- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -6117- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                    _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6118- ELSE */
                }
                else
                {


                    /*" -6119- MOVE 40000529001 TO DET-NUM-CONTRATO */
                    _.Move(40000529001, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6120- END-IF */
                }


                /*" -6121- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -6122- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -6123- WHEN 'I' */
                    case "I":

                        /*" -6124- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -6125- ADD 1 TO AC-INVENTA-INC */
                        WS_WORK_AREAS.AC_INVENTA_INC.Value = WS_WORK_AREAS.AC_INVENTA_INC + 1;

                        /*" -6126- WHEN 'A' */
                        break;
                    case "A":

                        /*" -6127- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -6128- ADD 1 TO AC-INVENTA-ALT */
                        WS_WORK_AREAS.AC_INVENTA_ALT.Value = WS_WORK_AREAS.AC_INVENTA_ALT + 1;

                        /*" -6129- WHEN 'E' */
                        break;
                    case "E":

                        /*" -6130- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -6131- ADD 1 TO AC-INVENTA-EXC */
                        WS_WORK_AREAS.AC_INVENTA_EXC.Value = WS_WORK_AREAS.AC_INVENTA_EXC + 1;

                        /*" -6132- WHEN OTHER */
                        break;
                    default:

                        /*" -6133- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -6134- ADD 1 TO AC-INVENTA-X */
                        WS_WORK_AREAS.AC_INVENTA_X.Value = WS_WORK_AREAS.AC_INVENTA_X + 1;

                        /*" -6135- END-EVALUATE */
                        break;
                }


                /*" -6136- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -6137- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -6209- END-IF. */
            }


            /*" -6214- IF (PROPOVA-NUM-APOLICE = 3009300007513 AND MOVIMVGA-COD-SUBGRUPO EQUAL 03 OR 06) OR (PROPOVA-NUM-APOLICE = 3009300007514 AND MOVIMVGA-COD-SUBGRUPO EQUAL 03) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007513 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("03", "06")) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007514 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO == 03))
            {

                /*" -6215- MOVE 96 TO VGCOBSUB-COD-COBERTURA */
                _.Move(96, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -6216- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                R1600_SELECT_NOVA_ASSIST_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                /*" -6217- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -6218- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                    _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6219- ELSE */
                }
                else
                {


                    /*" -6220- MOVE 40000529005 TO DET-NUM-CONTRATO */
                    _.Move(40000529005, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6221- END-IF */
                }


                /*" -6222- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -6223- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -6224- WHEN 'I' */
                    case "I":

                        /*" -6225- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -6226- ADD 1 TO AC-VIAGELH-INC */
                        WS_WORK_AREAS.AC_VIAGELH_INC.Value = WS_WORK_AREAS.AC_VIAGELH_INC + 1;

                        /*" -6227- WHEN 'A' */
                        break;
                    case "A":

                        /*" -6228- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -6229- ADD 1 TO AC-VIAGELH-ALT */
                        WS_WORK_AREAS.AC_VIAGELH_ALT.Value = WS_WORK_AREAS.AC_VIAGELH_ALT + 1;

                        /*" -6230- WHEN 'E' */
                        break;
                    case "E":

                        /*" -6231- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -6232- ADD 1 TO AC-VIAGELH-EXC */
                        WS_WORK_AREAS.AC_VIAGELH_EXC.Value = WS_WORK_AREAS.AC_VIAGELH_EXC + 1;

                        /*" -6233- WHEN OTHER */
                        break;
                    default:

                        /*" -6234- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -6235- ADD 1 TO AC-VIAGELH-X */
                        WS_WORK_AREAS.AC_VIAGELH_X.Value = WS_WORK_AREAS.AC_VIAGELH_X + 1;

                        /*" -6236- END-EVALUATE */
                        break;
                }


                /*" -6237- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -6238- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -6316- END-IF. */
            }


            /*" -6322- IF (PROPOVA-NUM-APOLICE = 3009300007513 AND MOVIMVGA-COD-SUBGRUPO EQUAL 01 OR 02 OR 03 OR 04 OR 05 OR 06) OR (PROPOVA-NUM-APOLICE = 3009300007514 AND MOVIMVGA-COD-SUBGRUPO EQUAL 01 OR 02 OR 03) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007513 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("01", "02", "03", "04", "05", "06")) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007514 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("01", "02", "03")))
            {

                /*" -6323- MOVE 24 TO VGCOBSUB-COD-COBERTURA */
                _.Move(24, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -6324- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                R1600_SELECT_NOVA_ASSIST_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                /*" -6325- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -6326- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                    _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6327- ELSE */
                }
                else
                {


                    /*" -6328- MOVE 40000042589 TO DET-NUM-CONTRATO */
                    _.Move(40000042589, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6329- END-IF */
                }


                /*" -6330- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -6331- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -6332- WHEN 'I' */
                    case "I":

                        /*" -6333- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -6334- ADD 1 TO AC-EMPR-INC */
                        WS_WORK_AREAS.AC_EMPR_INC.Value = WS_WORK_AREAS.AC_EMPR_INC + 1;

                        /*" -6335- WHEN 'A' */
                        break;
                    case "A":

                        /*" -6336- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -6337- ADD 1 TO AC-EMPR-ALT */
                        WS_WORK_AREAS.AC_EMPR_ALT.Value = WS_WORK_AREAS.AC_EMPR_ALT + 1;

                        /*" -6338- WHEN 'E' */
                        break;
                    case "E":

                        /*" -6339- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -6340- ADD 1 TO AC-EMPR-EXC */
                        WS_WORK_AREAS.AC_EMPR_EXC.Value = WS_WORK_AREAS.AC_EMPR_EXC + 1;

                        /*" -6341- WHEN OTHER */
                        break;
                    default:

                        /*" -6342- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -6343- ADD 1 TO AC-EMPR-X */
                        WS_WORK_AREAS.AC_EMPR_X.Value = WS_WORK_AREAS.AC_EMPR_X + 1;

                        /*" -6344- END-EVALUATE */
                        break;
                }


                /*" -6345- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -6346- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -6429- END-IF. */
            }


            /*" -6435- IF (PROPOVA-NUM-APOLICE = 3009300007513 AND MOVIMVGA-COD-SUBGRUPO EQUAL 01 OR 02 OR 03 OR 04 OR 05 OR 06) OR (PROPOVA-NUM-APOLICE = 3009300007514 AND MOVIMVGA-COD-SUBGRUPO EQUAL 01 OR 02 OR 03) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007513 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("01", "02", "03", "04", "05", "06")) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007514 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("01", "02", "03")))
            {

                /*" -6436- MOVE 83 TO VGCOBSUB-COD-COBERTURA */
                _.Move(83, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -6437- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                R1600_SELECT_NOVA_ASSIST_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                /*" -6438- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -6439- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                    _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6440- ELSE */
                }
                else
                {


                    /*" -6441- MOVE 40000527273 TO DET-NUM-CONTRATO */
                    _.Move(40000527273, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6442- END-IF */
                }


                /*" -6443- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -6444- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -6445- WHEN 'I' */
                    case "I":

                        /*" -6446- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -6447- ADD 1 TO AC-LAR-INC */
                        WS_WORK_AREAS.AC_LAR_INC.Value = WS_WORK_AREAS.AC_LAR_INC + 1;

                        /*" -6448- WHEN 'A' */
                        break;
                    case "A":

                        /*" -6449- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -6450- ADD 1 TO AC-LAR-ALT */
                        WS_WORK_AREAS.AC_LAR_ALT.Value = WS_WORK_AREAS.AC_LAR_ALT + 1;

                        /*" -6451- WHEN 'E' */
                        break;
                    case "E":

                        /*" -6452- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -6453- ADD 1 TO AC-LAR-EXC */
                        WS_WORK_AREAS.AC_LAR_EXC.Value = WS_WORK_AREAS.AC_LAR_EXC + 1;

                        /*" -6454- WHEN OTHER */
                        break;
                    default:

                        /*" -6455- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -6456- ADD 1 TO AC-LAR-X */
                        WS_WORK_AREAS.AC_LAR_X.Value = WS_WORK_AREAS.AC_LAR_X + 1;

                        /*" -6457- END-EVALUATE */
                        break;
                }


                /*" -6458- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -6459- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -6534- END-IF. */
            }


            /*" -6539- IF (PROPOVA-NUM-APOLICE = 3009300007513 AND MOVIMVGA-COD-SUBGRUPO EQUAL 03 OR 06) OR (PROPOVA-NUM-APOLICE = 3009300007514 AND MOVIMVGA-COD-SUBGRUPO EQUAL 03) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007513 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("03", "06")) || (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 3009300007514 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO == 03))
            {

                /*" -6540- MOVE 91 TO VGCOBSUB-COD-COBERTURA */
                _.Move(91, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -6541- PERFORM R1600-SELECT-NOVA-ASSIST THRU R1600-99-SAIDA */

                R1600_SELECT_NOVA_ASSIST_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


                /*" -6542- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -6543- MOVE WHOST-COD-CONVENIO TO DET-NUM-CONTRATO */
                    _.Move(WHOST_COD_CONVENIO, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6544- ELSE */
                }
                else
                {


                    /*" -6545- MOVE 40000527287 TO DET-NUM-CONTRATO */
                    _.Move(40000527287, DETAIL_RECORD.DET_NUM_CONTRATO);

                    /*" -6546- END-IF */
                }


                /*" -6547- MOVE WHOST-TIPO-MOVIMENTO TO DET-TIPO-MOV */
                _.Move(WHOST_TIPO_MOVIMENTO, DETAIL_RECORD.DET_TIPO_MOV);

                /*" -6548- EVALUATE WHOST-TIPO-MOVIMENTO */
                switch (WHOST_TIPO_MOVIMENTO.Value.Trim())
                {

                    /*" -6549- WHEN 'I' */
                    case "I":

                        /*" -6550- ADD 1 TO WS-TOTAL-INC */
                        WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

                        /*" -6551- ADD 1 TO AC-TELEMED-INC */
                        WS_WORK_AREAS.AC_TELEMED_INC.Value = WS_WORK_AREAS.AC_TELEMED_INC + 1;

                        /*" -6552- WHEN 'A' */
                        break;
                    case "A":

                        /*" -6553- ADD 1 TO WS-TOTAL-ALT */
                        WS_WORK_AREAS.WS_TOTAL_ALT.Value = WS_WORK_AREAS.WS_TOTAL_ALT + 1;

                        /*" -6554- ADD 1 TO AC-TELEMED-ALT */
                        WS_WORK_AREAS.AC_TELEMED_ALT.Value = WS_WORK_AREAS.AC_TELEMED_ALT + 1;

                        /*" -6555- WHEN 'E' */
                        break;
                    case "E":

                        /*" -6556- ADD 1 TO WS-TOTAL-EXC */
                        WS_WORK_AREAS.WS_TOTAL_EXC.Value = WS_WORK_AREAS.WS_TOTAL_EXC + 1;

                        /*" -6557- ADD 1 TO AC-TELEMED-EXC */
                        WS_WORK_AREAS.AC_TELEMED_EXC.Value = WS_WORK_AREAS.AC_TELEMED_EXC + 1;

                        /*" -6558- WHEN OTHER */
                        break;
                    default:

                        /*" -6559- ADD 1 TO WS-TOTAL-X */
                        WS_WORK_AREAS.WS_TOTAL_X.Value = WS_WORK_AREAS.WS_TOTAL_X + 1;

                        /*" -6560- ADD 1 TO AC-TELEMED-X */
                        WS_WORK_AREAS.AC_TELEMED_X.Value = WS_WORK_AREAS.AC_TELEMED_X + 1;

                        /*" -6561- END-EVALUATE */
                        break;
                }


                /*" -6562- WRITE REG-MVA1476B FROM DETAIL-RECORD */
                _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

                MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

                /*" -6563- ADD 1 TO WS-TOTAL-GRAVADOS */
                WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

                /*" -6713- END-IF. */
            }


            /*" -6714-  EVALUATE PROPOVA-COD-PRODUTO  */

            /*" -6715-  WHEN 0917  */

            /*" -6715- IF   PROPOVA-COD-PRODUTO EQUALS  0917 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 0917)
            {

                /*" -6716- ADD 1 TO WS-QTD-0917 */
                WS_WORK_AREAS.WS_TOTAL_0917.WS_QTD_0917.Value = WS_WORK_AREAS.WS_TOTAL_0917.WS_QTD_0917 + 1;

                /*" -6717-  WHEN 9307  */

                /*" -6717- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9307 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9307)
            {

                /*" -6718- ADD 1 TO WS-QTD-9307 */
                WS_WORK_AREAS.WS_TOTAL_9307.WS_QTD_9307.Value = WS_WORK_AREAS.WS_TOTAL_9307.WS_QTD_9307 + 1;

                /*" -6719-  WHEN 9311  */

                /*" -6719- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9311 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9311)
            {

                /*" -6720- ADD 1 TO WS-QTD-9311 */
                WS_WORK_AREAS.WS_TOTAL_9311.WS_QTD_9311.Value = WS_WORK_AREAS.WS_TOTAL_9311.WS_QTD_9311 + 1;

                /*" -6721-  WHEN JVPRD9311  */

                /*" -6721- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  JVPRD9311 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9311)
            {

                /*" -6722- ADD 1 TO WS-QTD-9311 */
                WS_WORK_AREAS.WS_TOTAL_9311.WS_QTD_9311.Value = WS_WORK_AREAS.WS_TOTAL_9311.WS_QTD_9311 + 1;

                /*" -6723-  WHEN 9320  */

                /*" -6723- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9320 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9320)
            {

                /*" -6724- ADD 1 TO WS-QTD-9320 */
                WS_WORK_AREAS.WS_TOTAL_9320.WS_QTD_9320.Value = WS_WORK_AREAS.WS_TOTAL_9320.WS_QTD_9320 + 1;

                /*" -6725-  WHEN JVPRD9320  */

                /*" -6725- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  JVPRD9320 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9320)
            {

                /*" -6726- ADD 1 TO WS-QTD-9320 */
                WS_WORK_AREAS.WS_TOTAL_9320.WS_QTD_9320.Value = WS_WORK_AREAS.WS_TOTAL_9320.WS_QTD_9320 + 1;

                /*" -6727-  WHEN 9321  */

                /*" -6727- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9321 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9321)
            {

                /*" -6728- ADD 1 TO WS-QTD-9321 */
                WS_WORK_AREAS.WS_TOTAL_9321.WS_QTD_9321.Value = WS_WORK_AREAS.WS_TOTAL_9321.WS_QTD_9321 + 1;

                /*" -6729-  WHEN JVPRD9321  */

                /*" -6729- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  JVPRD9321 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9321)
            {

                /*" -6730- ADD 1 TO WS-QTD-9321 */
                WS_WORK_AREAS.WS_TOTAL_9321.WS_QTD_9321.Value = WS_WORK_AREAS.WS_TOTAL_9321.WS_QTD_9321 + 1;

                /*" -6731-  WHEN 9332  */

                /*" -6731- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9332 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9332)
            {

                /*" -6732- ADD 1 TO WS-QTD-9332 */
                WS_WORK_AREAS.WS_TOTAL_9332.WS_QTD_9332.Value = WS_WORK_AREAS.WS_TOTAL_9332.WS_QTD_9332 + 1;

                /*" -6733-  WHEN JVPRD9332  */

                /*" -6733- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  JVPRD9332 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9332)
            {

                /*" -6734- ADD 1 TO WS-QTD-9332 */
                WS_WORK_AREAS.WS_TOTAL_9332.WS_QTD_9332.Value = WS_WORK_AREAS.WS_TOTAL_9332.WS_QTD_9332 + 1;

                /*" -6735-  WHEN 9703  */

                /*" -6735- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9703 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9703)
            {

                /*" -6736- ADD 1 TO WS-QTD-9703 */
                WS_WORK_AREAS.WS_TOTAL_9703.WS_QTD_9703.Value = WS_WORK_AREAS.WS_TOTAL_9703.WS_QTD_9703 + 1;

                /*" -6737-  WHEN 9314  */

                /*" -6737- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9314 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9314)
            {

                /*" -6738- ADD 1 TO WS-QTD-9314 */
                WS_WORK_AREAS.WS_TOTAL_9314.WS_QTD_9314.Value = WS_WORK_AREAS.WS_TOTAL_9314.WS_QTD_9314 + 1;

                /*" -6739-  WHEN JVPRD9314  */

                /*" -6739- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  JVPRD9314 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9314)
            {

                /*" -6740- ADD 1 TO WS-QTD-9314 */
                WS_WORK_AREAS.WS_TOTAL_9314.WS_QTD_9314.Value = WS_WORK_AREAS.WS_TOTAL_9314.WS_QTD_9314 + 1;

                /*" -6741-  WHEN 9327  */

                /*" -6741- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9327 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9327)
            {

                /*" -6742- ADD 1 TO WS-QTD-9327 */
                WS_WORK_AREAS.WS_TOTAL_9327.WS_QTD_9327.Value = WS_WORK_AREAS.WS_TOTAL_9327.WS_QTD_9327 + 1;

                /*" -6743-  WHEN JVPRD9327  */

                /*" -6743- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  JVPRD9327 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9327)
            {

                /*" -6744- ADD 1 TO WS-QTD-9327 */
                WS_WORK_AREAS.WS_TOTAL_9327.WS_QTD_9327.Value = WS_WORK_AREAS.WS_TOTAL_9327.WS_QTD_9327 + 1;

                /*" -6745-  WHEN 9334  */

                /*" -6745- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9334 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9334)
            {

                /*" -6746- ADD 1 TO WS-QTD-9334 */
                WS_WORK_AREAS.WS_TOTAL_9334.WS_QTD_9334.Value = WS_WORK_AREAS.WS_TOTAL_9334.WS_QTD_9334 + 1;

                /*" -6747-  WHEN JVPRD9334  */

                /*" -6747- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  JVPRD9334 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9334)
            {

                /*" -6748- ADD 1 TO WS-QTD-9334 */
                WS_WORK_AREAS.WS_TOTAL_9334.WS_QTD_9334.Value = WS_WORK_AREAS.WS_TOTAL_9334.WS_QTD_9334 + 1;

                /*" -6749-  WHEN 9329  */

                /*" -6749- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9329 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9329)
            {

                /*" -6750- ADD 1 TO WS-QTD-9329 */
                WS_WORK_AREAS.WS_TOTAL_9329.WS_QTD_9329.Value = WS_WORK_AREAS.WS_TOTAL_9329.WS_QTD_9329 + 1;

                /*" -6751-  WHEN JVPRD9329  */

                /*" -6751- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  JVPRD9329 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9329)
            {

                /*" -6752- ADD 1 TO WS-QTD-9329 */
                WS_WORK_AREAS.WS_TOTAL_9329.WS_QTD_9329.Value = WS_WORK_AREAS.WS_TOTAL_9329.WS_QTD_9329 + 1;

                /*" -6753-  WHEN 8203  */

                /*" -6753- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8203 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8203)
            {

                /*" -6754- ADD 1 TO WS-QTD-8203 */
                WS_WORK_AREAS.WS_TOTAL_8203.WS_QTD_8203.Value = WS_WORK_AREAS.WS_TOTAL_8203.WS_QTD_8203 + 1;

                /*" -6755-  WHEN 8521  */

                /*" -6755- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8521 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8521)
            {

                /*" -6756- ADD 1 TO WS-QTD-8521 */
                WS_WORK_AREAS.WS_TOTAL_8521.WS_QTD_8521.Value = WS_WORK_AREAS.WS_TOTAL_8521.WS_QTD_8521 + 1;

                /*" -6757-  WHEN 8528  */

                /*" -6757- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8528 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8528)
            {

                /*" -6758- ADD 1 TO WS-QTD-8528 */
                WS_WORK_AREAS.WS_TOTAL_8528.WS_QTD_8528.Value = WS_WORK_AREAS.WS_TOTAL_8528.WS_QTD_8528 + 1;

                /*" -6759-  WHEN 8529  */

                /*" -6759- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8529 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8529)
            {

                /*" -6760- ADD 1 TO WS-QTD-8529 */
                WS_WORK_AREAS.WS_TOTAL_8529.WS_QTD_8529.Value = WS_WORK_AREAS.WS_TOTAL_8529.WS_QTD_8529 + 1;

                /*" -6761-  WHEN 8533  */

                /*" -6761- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8533 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8533)
            {

                /*" -6762- ADD 1 TO WS-QTD-8533 */
                WS_WORK_AREAS.WS_TOTAL_8533.WS_QTD_8533.Value = WS_WORK_AREAS.WS_TOTAL_8533.WS_QTD_8533 + 1;

                /*" -6763-  WHEN 8534  */

                /*" -6763- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8534 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8534)
            {

                /*" -6764- ADD 1 TO WS-QTD-8534 */
                WS_WORK_AREAS.WS_TOTAL_8534.WS_QTD_8534.Value = WS_WORK_AREAS.WS_TOTAL_8534.WS_QTD_8534 + 1;

                /*" -6765-  WHEN 9749  */

                /*" -6765- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9749 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9749)
            {

                /*" -6766- ADD 1 TO WS-QTD-9749 */
                WS_WORK_AREAS.WS_TOTAL_9749.WS_QTD_9749.Value = WS_WORK_AREAS.WS_TOTAL_9749.WS_QTD_9749 + 1;

                /*" -6767-  WHEN 9729  */

                /*" -6767- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9729 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9729)
            {

                /*" -6768- ADD 1 TO WS-QTD-9729 */
                WS_WORK_AREAS.WS_TOTAL_9729.WS_QTD_9729.Value = WS_WORK_AREAS.WS_TOTAL_9729.WS_QTD_9729 + 1;

                /*" -6769-  WHEN 9746  */

                /*" -6769- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9746 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9746)
            {

                /*" -6770- ADD 1 TO WS-QTD-9746 */
                WS_WORK_AREAS.WS_TOTAL_9746.WS_QTD_9746.Value = WS_WORK_AREAS.WS_TOTAL_9746.WS_QTD_9746 + 1;

                /*" -6771-  WHEN 9745  */

                /*" -6771- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9745 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9745)
            {

                /*" -6772- ADD 1 TO WS-QTD-9745 */
                WS_WORK_AREAS.WS_TOTAL_9745.WS_QTD_9745.Value = WS_WORK_AREAS.WS_TOTAL_9745.WS_QTD_9745 + 1;

                /*" -6773-  WHEN 9747  */

                /*" -6773- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9747 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9747)
            {

                /*" -6774- ADD 1 TO WS-QTD-9747 */
                WS_WORK_AREAS.WS_TOTAL_9747.WS_QTD_9747.Value = WS_WORK_AREAS.WS_TOTAL_9747.WS_QTD_9747 + 1;

                /*" -6775-  WHEN 9735  */

                /*" -6775- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9735 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9735)
            {

                /*" -6776- ADD 1 TO WS-QTD-9735 */
                WS_WORK_AREAS.WS_TOTAL_9735.WS_QTD_9735.Value = WS_WORK_AREAS.WS_TOTAL_9735.WS_QTD_9735 + 1;

                /*" -6777-  WHEN 9736  */

                /*" -6777- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9736 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9736)
            {

                /*" -6778- ADD 1 TO WS-QTD-9736 */
                WS_WORK_AREAS.WS_TOTAL_9736.WS_QTD_9736.Value = WS_WORK_AREAS.WS_TOTAL_9736.WS_QTD_9736 + 1;

                /*" -6779-  WHEN 9737  */

                /*" -6779- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9737 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9737)
            {

                /*" -6780- ADD 1 TO WS-QTD-9737 */
                WS_WORK_AREAS.WS_TOTAL_9737.WS_QTD_9737.Value = WS_WORK_AREAS.WS_TOTAL_9737.WS_QTD_9737 + 1;

                /*" -6781-  WHEN 9742  */

                /*" -6781- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9742 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9742)
            {

                /*" -6782- ADD 1 TO WS-QTD-9742 */
                WS_WORK_AREAS.WS_TOTAL_9742.WS_QTD_9742.Value = WS_WORK_AREAS.WS_TOTAL_9742.WS_QTD_9742 + 1;

                /*" -6783-  WHEN 9741  */

                /*" -6783- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9741 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9741)
            {

                /*" -6784- ADD 1 TO WS-QTD-9741 */
                WS_WORK_AREAS.WS_TOTAL_9741.WS_QTD_9741.Value = WS_WORK_AREAS.WS_TOTAL_9741.WS_QTD_9741 + 1;

                /*" -6785-  WHEN 9743  */

                /*" -6785- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9743 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9743)
            {

                /*" -6786- ADD 1 TO WS-QTD-9743 */
                WS_WORK_AREAS.WS_TOTAL_9743.WS_QTD_9743.Value = WS_WORK_AREAS.WS_TOTAL_9743.WS_QTD_9743 + 1;

                /*" -6787-  WHEN 9731  */

                /*" -6787- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9731 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9731)
            {

                /*" -6788- ADD 1 TO WS-QTD-9731 */
                WS_WORK_AREAS.WS_TOTAL_9731.WS_QTD_9731.Value = WS_WORK_AREAS.WS_TOTAL_9731.WS_QTD_9731 + 1;

                /*" -6789-  WHEN 9732  */

                /*" -6789- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9732 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9732)
            {

                /*" -6790- ADD 1 TO WS-QTD-9732 */
                WS_WORK_AREAS.WS_TOTAL_9732.WS_QTD_9732.Value = WS_WORK_AREAS.WS_TOTAL_9732.WS_QTD_9732 + 1;

                /*" -6791-  WHEN 9733  */

                /*" -6791- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9733 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9733)
            {

                /*" -6792- ADD 1 TO WS-QTD-9733 */
                WS_WORK_AREAS.WS_TOTAL_9733.WS_QTD_9733.Value = WS_WORK_AREAS.WS_TOTAL_9733.WS_QTD_9733 + 1;

                /*" -6793-  WHEN 9722  */

                /*" -6793- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9722 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9722)
            {

                /*" -6794- ADD 1 TO WS-QTD-9722 */
                WS_WORK_AREAS.WS_TOTAL_9722.WS_QTD_9722.Value = WS_WORK_AREAS.WS_TOTAL_9722.WS_QTD_9722 + 1;

                /*" -6795-  WHEN 9721  */

                /*" -6795- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9721 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9721)
            {

                /*" -6796- ADD 1 TO WS-QTD-9721 */
                WS_WORK_AREAS.WS_TOTAL_9721.WS_QTD_9721.Value = WS_WORK_AREAS.WS_TOTAL_9721.WS_QTD_9721 + 1;

                /*" -6797-  WHEN 9723  */

                /*" -6797- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9723 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9723)
            {

                /*" -6798- ADD 1 TO WS-QTD-9723 */
                WS_WORK_AREAS.WS_TOTAL_9723.WS_QTD_9723.Value = WS_WORK_AREAS.WS_TOTAL_9723.WS_QTD_9723 + 1;

                /*" -6799-  WHEN 9386  */

                /*" -6799- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9386 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9386)
            {

                /*" -6800- ADD 1 TO WS-QTD-9386 */
                WS_WORK_AREAS.WS_TOTAL_9386.WS_QTD_9386.Value = WS_WORK_AREAS.WS_TOTAL_9386.WS_QTD_9386 + 1;

                /*" -6801-  WHEN 8241  */

                /*" -6801- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8241 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8241)
            {

                /*" -6802- ADD 1 TO WS-QTD-8241 */
                WS_WORK_AREAS.WS_TOTAL_8241.WS_QTD_8241.Value = WS_WORK_AREAS.WS_TOTAL_8241.WS_QTD_8241 + 1;

                /*" -6803-  WHEN 8242  */

                /*" -6803- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8242 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8242)
            {

                /*" -6804- ADD 1 TO WS-QTD-8242 */
                WS_WORK_AREAS.WS_TOTAL_8242.WS_QTD_8242.Value = WS_WORK_AREAS.WS_TOTAL_8242.WS_QTD_8242 + 1;

                /*" -6805-  WHEN 9381  */

                /*" -6805- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9381 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9381)
            {

                /*" -6806- ADD 1 TO WS-QTD-9381 */
                WS_WORK_AREAS.WS_TOTAL_9381.WS_QTD_9381.Value = WS_WORK_AREAS.WS_TOTAL_9381.WS_QTD_9381 + 1;

                /*" -6807-  WHEN 9382  */

                /*" -6807- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9382 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9382)
            {

                /*" -6808- ADD 1 TO WS-QTD-9382 */
                WS_WORK_AREAS.WS_TOTAL_9382.WS_QTD_9382.Value = WS_WORK_AREAS.WS_TOTAL_9382.WS_QTD_9382 + 1;

                /*" -6809-  WHEN 9750  */

                /*" -6809- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9750 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9750)
            {

                /*" -6810- ADD 1 TO WS-QTD-9750 */
                WS_WORK_AREAS.WS_TOTAL_9750.WS_QTD_9750.Value = WS_WORK_AREAS.WS_TOTAL_9750.WS_QTD_9750 + 1;

                /*" -6811-  WHEN 9751  */

                /*" -6811- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9751 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9751)
            {

                /*" -6812- ADD 1 TO WS-QTD-9751 */
                WS_WORK_AREAS.WS_TOTAL_9751.WS_QTD_9751.Value = WS_WORK_AREAS.WS_TOTAL_9751.WS_QTD_9751 + 1;

                /*" -6813-  WHEN 9752  */

                /*" -6813- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  9752 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9752)
            {

                /*" -6814- ADD 1 TO WS-QTD-9752 */
                WS_WORK_AREAS.WS_TOTAL_9752.WS_QTD_9752.Value = WS_WORK_AREAS.WS_TOTAL_9752.WS_QTD_9752 + 1;

                /*" -6815-  WHEN 8530  */

                /*" -6815- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8530 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8530)
            {

                /*" -6816- ADD 1 TO WS-QTD-8530 */
                WS_WORK_AREAS.WS_TOTAL_8530.WS_QTD_8530.Value = WS_WORK_AREAS.WS_TOTAL_8530.WS_QTD_8530 + 1;

                /*" -6817-  WHEN 8531  */

                /*" -6817- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8531 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8531)
            {

                /*" -6818- ADD 1 TO WS-QTD-8531 */
                WS_WORK_AREAS.WS_TOTAL_8531.WS_QTD_8531.Value = WS_WORK_AREAS.WS_TOTAL_8531.WS_QTD_8531 + 1;

                /*" -6819-  WHEN 8532  */

                /*" -6819- ELSE IF   PROPOVA-COD-PRODUTO EQUALS  8532 */
            }
            else

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8532)
            {

                /*" -6820- ADD 1 TO WS-QTD-8532 */
                WS_WORK_AREAS.WS_TOTAL_8532.WS_QTD_8532.Value = WS_WORK_AREAS.WS_TOTAL_8532.WS_QTD_8532 + 1;

                /*" -6821-  WHEN OTHER  */

                /*" -6821- ELSE */
            }
            else
            {


                /*" -6822- ADD 1 TO WS-QTD-9999 */
                WS_WORK_AREAS.WS_TOTAL_9999.WS_QTD_9999.Value = WS_WORK_AREAS.WS_TOTAL_9999.WS_QTD_9999 + 1;

                /*" -6822-  END-EVALUATE.  */

                /*" -6822- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -6831- PERFORM R0910-00-FETCH-MOVDIARIO */

            R0910_00_FETCH_MOVDIARIO_SECTION();

            /*" -6831- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-PROPOVA-SECTION */
        private void R1010_00_SELECT_PROPOVA_SECTION()
        {
            /*" -6841- MOVE 'R1010-00      ' TO PARAGRAFO */
            _.Move("R1010-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6843- MOVE 'SELECT PROPOVA ' TO COMANDO */
            _.Move("SELECT PROPOVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6861- PERFORM R1010_00_SELECT_PROPOVA_DB_SELECT_1 */

            R1010_00_SELECT_PROPOVA_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1010-00-SELECT-PROPOVA-DB-SELECT-1 */
        public void R1010_00_SELECT_PROPOVA_DB_SELECT_1()
        {
            /*" -6861- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , DATA_QUITACAO , NUM_CERTIFICADO , COD_CLIENTE , COD_PRODUTO , OCOREND INTO :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PROPOVA-DATA-QUITACAO , :PROPOVA-NUM-CERTIFICADO , :PROPOVA-COD-CLIENTE , :PROPOVA-COD-PRODUTO , :PROPOVA-OCOREND FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :MOVIMVGA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1 = new R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1()
            {
                MOVIMVGA_NUM_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(executed_1.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-PROPOVA-SECTION */
        private void R1020_00_SELECT_PROPOVA_SECTION()
        {
            /*" -6871- MOVE 'R1020-00      ' TO PARAGRAFO */
            _.Move("R1020-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6873- MOVE 'SELECT PROPOVA 0001' TO COMANDO */
            _.Move("SELECT PROPOVA 0001", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6875- MOVE 'SIM' TO WTEM-PROPOVA */
            _.Move("SIM", WTEM_PROPOVA);

            /*" -6878- MOVE MOVIMVGA-NUM-CERTIFICADO TO PROPOVA-COD-CLIENTE */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);

            /*" -6920- PERFORM R1020_00_SELECT_PROPOVA_DB_SELECT_1 */

            R1020_00_SELECT_PROPOVA_DB_SELECT_1();

            /*" -6923- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6924- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6925- MOVE 'NAO' TO WTEM-PROPOVA */
                    _.Move("NAO", WTEM_PROPOVA);

                    /*" -6926- GO TO R1020-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/ //GOTO
                    return;

                    /*" -6927- ELSE */
                }
                else
                {


                    /*" -6929- DISPLAY 'PROBLEMAS NA LEITURA DE PROPOVA 0001...' CLIENTES-COD-CLIENTE */
                    _.Display($"PROBLEMAS NA LEITURA DE PROPOVA 0001...{CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                    /*" -6930- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6931- END-IF */
                }


                /*" -6933- END-IF. */
            }


            /*" -6934- MOVE PROPOVA-NUM-CERTIFICADO TO MOVIMVGA-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);

            /*" -6934- . */

        }

        [StopWatch]
        /*" R1020-00-SELECT-PROPOVA-DB-SELECT-1 */
        public void R1020_00_SELECT_PROPOVA_DB_SELECT_1()
        {
            /*" -6920- EXEC SQL SELECT NUM_CERTIFICADO, OCOREND , COD_PRODUTO INTO :PROPOVA-NUM-CERTIFICADO , :PROPOVA-OCOREND , :WS-COD-PRODUTO FROM SEGUROS.PROPOSTAS_VA WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND NUM_APOLICE IN ( 0109300000550.,0109300000598.,0109300000559., 0109300000709.,0109300000909.,0109300001294., 0109300001311.,0109300001391.,0109300001392., 0109300001393.,0109300001394.,0109300001553., 0109300001575.,0109300001679.,0109300001680., 0109300002001.,0109300002002.,0109300002003., 0109300002004.,0109300002005.,0109300002006., 0109300002007.,0109300002008.,0109300002010., 0109300001966.,0109300001970.,0109300001971., 0109300001976.,0109300001977.,0109300001978. ,3009300001559. ,3009300001909. ,3009300011970. ,3009300011971. ,3009300011977. ,3009300011978. ,3009300012002. ,3009300012003. ,3009300012005. ,3009300012006. ,3009300012008. ,3009300012010. ,3009300012344. ,3009300012358. ,3009300007513. ,3009300007514. ) AND DATA_QUITACAO < :SISTEMAS-DATA-MOV-ABERTO-30 FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1 = new R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO_30 = SISTEMAS_DATA_MOV_ABERTO_30.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(executed_1.WS_COD_PRODUTO, WS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-SELECT-GECLIMOV-SECTION */
        private void R1030_00_SELECT_GECLIMOV_SECTION()
        {
            /*" -6944- MOVE 'R1030-00      ' TO PARAGRAFO */
            _.Move("R1030-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6946- MOVE 'SELECT GECLIMOV    ' TO COMANDO */
            _.Move("SELECT GECLIMOV    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6970- PERFORM R1030_00_SELECT_GECLIMOV_DB_SELECT_1 */

            R1030_00_SELECT_GECLIMOV_DB_SELECT_1();

            /*" -6973- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6975- DISPLAY 'PROBLEMAS NA LEITURA DE GECLIMOV ......' PROPOVA-COD-CLIENTE */
                _.Display($"PROBLEMAS NA LEITURA DE GECLIMOV ......{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                /*" -6976- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6978- END-IF */
            }


            /*" -6987- IF VIND-NOME-RAZAO LESS +0 OR VIND-ENDERECO LESS +0 OR VIND-BAIRRO LESS +0 OR VIND-CIDADE LESS +0 OR VIND-SIGLA-UF LESS +0 OR VIND-CEP LESS +0 OR VIND-DDD LESS +0 OR VIND-TELEFONE LESS +0 OR VIND-DATA-NASC LESS +0 */

            if (VIND_NOME_RAZAO < +0 || VIND_ENDERECO < +0 || VIND_BAIRRO < +0 || VIND_CIDADE < +0 || VIND_SIGLA_UF < +0 || VIND_CEP < +0 || VIND_DDD < +0 || VIND_TELEFONE < +0 || VIND_DATA_NASC < +0)
            {

                /*" -6988- MOVE 'NAO' TO WTEM-PROPOVA */
                _.Move("NAO", WTEM_PROPOVA);

                /*" -6989- GO TO R1030-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/ //GOTO
                return;

                /*" -6991- END-IF */
            }


            /*" -6999- IF GECLIMOV-NOME-RAZAO EQUAL SPACES OR GECLIMOV-ENDERECO EQUAL SPACES OR GECLIMOV-BAIRRO EQUAL SPACES OR GECLIMOV-CIDADE EQUAL SPACES OR GECLIMOV-SIGLA-UF EQUAL SPACES OR GECLIMOV-CEP EQUAL ZEROS OR GECLIMOV-DDD EQUAL ZEROS OR GECLIMOV-TELEFONE EQUAL ZEROS */

            if (GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.IsEmpty() || GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.IsEmpty() || GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.IsEmpty() || GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.IsEmpty() || GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.IsEmpty() || GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP == 00 || GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD == 00 || GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE == 00)
            {

                /*" -7000- MOVE 'NAO' TO WTEM-PROPOVA */
                _.Move("NAO", WTEM_PROPOVA);

                /*" -7001- GO TO R1030-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/ //GOTO
                return;

                /*" -7003- END-IF */
            }


            /*" -7013- IF GECLIMOV-NOME-RAZAO EQUAL CLIENTES-NOME-RAZAO AND GECLIMOV-ENDERECO EQUAL ENDERECO-ENDERECO AND GECLIMOV-BAIRRO EQUAL ENDERECO-BAIRRO AND GECLIMOV-CIDADE EQUAL ENDERECO-CIDADE AND GECLIMOV-SIGLA-UF EQUAL ENDERECO-SIGLA-UF AND GECLIMOV-CEP EQUAL ENDERECO-CEP AND GECLIMOV-DDD EQUAL ENDERECO-DDD AND GECLIMOV-TELEFONE EQUAL ENDERECO-TELEFONE AND GECLIMOV-DATA-NASCIMENTO EQUAL CLIENTES-DATA-NASCIMENTO */

            if (GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO == CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO && GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO == ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO && GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO == ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO && GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE == ENDERECO.DCLENDERECOS.ENDERECO_CIDADE && GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF == ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF && GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP == ENDERECO.DCLENDERECOS.ENDERECO_CEP && GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD == ENDERECO.DCLENDERECOS.ENDERECO_DDD && GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE == ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE && GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO == CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO)
            {

                /*" -7014- MOVE 'NAO' TO WTEM-PROPOVA */
                _.Move("NAO", WTEM_PROPOVA);

                /*" -7015- GO TO R1030-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/ //GOTO
                return;

                /*" -7017- END-IF */
            }


            /*" -7018- MOVE GECLIMOV-NOME-RAZAO TO CLIENTES-NOME-RAZAO */
            _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

            /*" -7019- MOVE GECLIMOV-ENDERECO TO ENDERECO-ENDERECO */
            _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -7020- MOVE GECLIMOV-BAIRRO TO ENDERECO-BAIRRO */
            _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -7021- MOVE GECLIMOV-CIDADE TO ENDERECO-CIDADE */
            _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -7022- MOVE GECLIMOV-SIGLA-UF TO ENDERECO-SIGLA-UF */
            _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

            /*" -7023- MOVE GECLIMOV-CEP TO ENDERECO-CEP */
            _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -7024- MOVE GECLIMOV-DDD TO ENDERECO-DDD */
            _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);

            /*" -7025- MOVE GECLIMOV-TELEFONE TO ENDERECO-TELEFONE */
            _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);

            /*" -7027- MOVE GECLIMOV-DATA-NASCIMENTO TO CLIENTES-DATA-NASCIMENTO */
            _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -7027- . */

        }

        [StopWatch]
        /*" R1030-00-SELECT-GECLIMOV-DB-SELECT-1 */
        public void R1030_00_SELECT_GECLIMOV_DB_SELECT_1()
        {
            /*" -6970- EXEC SQL SELECT NOME_RAZAO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , DATA_NASCIMENTO INTO :GECLIMOV-NOME-RAZAO :VIND-NOME-RAZAO, :GECLIMOV-ENDERECO :VIND-ENDERECO , :GECLIMOV-BAIRRO :VIND-BAIRRO , :GECLIMOV-CIDADE :VIND-CIDADE , :GECLIMOV-SIGLA-UF :VIND-SIGLA-UF , :GECLIMOV-CEP :VIND-CEP , :GECLIMOV-DDD :VIND-DDD , :GECLIMOV-TELEFONE :VIND-TELEFONE , :GECLIMOV-DATA-NASCIMENTO :VIND-DATA-NASC FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_HIST = :MOVIMVGA-OCORR-ENDERECO END-EXEC. */

            var r1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1 = new R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1()
            {
                MOVIMVGA_OCORR_ENDERECO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1.Execute(r1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECLIMOV_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
                _.Move(executed_1.VIND_NOME_RAZAO, VIND_NOME_RAZAO);
                _.Move(executed_1.GECLIMOV_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
                _.Move(executed_1.VIND_ENDERECO, VIND_ENDERECO);
                _.Move(executed_1.GECLIMOV_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
                _.Move(executed_1.VIND_BAIRRO, VIND_BAIRRO);
                _.Move(executed_1.GECLIMOV_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
                _.Move(executed_1.VIND_CIDADE, VIND_CIDADE);
                _.Move(executed_1.GECLIMOV_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
                _.Move(executed_1.VIND_SIGLA_UF, VIND_SIGLA_UF);
                _.Move(executed_1.GECLIMOV_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
                _.Move(executed_1.VIND_CEP, VIND_CEP);
                _.Move(executed_1.GECLIMOV_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
                _.Move(executed_1.VIND_DDD, VIND_DDD);
                _.Move(executed_1.GECLIMOV_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
                _.Move(executed_1.VIND_TELEFONE, VIND_TELEFONE);
                _.Move(executed_1.GECLIMOV_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DATA_NASC, VIND_DATA_NASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1040-00-SELECT-BILHETE-SECTION */
        private void R1040_00_SELECT_BILHETE_SECTION()
        {
            /*" -7036- MOVE 'R1040-00      ' TO PARAGRAFO */
            _.Move("R1040-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7039- MOVE 'SELECT BILHETE ' TO COMANDO */
            _.Move("SELECT BILHETE ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7053- PERFORM R1040_00_SELECT_BILHETE_DB_SELECT_1 */

            R1040_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -7056- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7058- DISPLAY 'PROBLEMAS NA LEITURA DE BILHETE.......' MOVIMVGA-NUM-CERTIFICADO */
                _.Display($"PROBLEMAS NA LEITURA DE BILHETE.......{MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                /*" -7059- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7061- END-IF */
            }


            /*" -7062- MOVE BILHETE-NUM-BILHETE TO PROPOVA-NUM-CERTIFICADO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -7063- MOVE BILHETE-NUM-APOLICE TO PROPOVA-NUM-APOLICE */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);

            /*" -7064- MOVE BILHETE-DATA-QUITACAO TO PROPOVA-DATA-QUITACAO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);

            /*" -7065- MOVE BILHETE-COD-CLIENTE TO PROPOVA-COD-CLIENTE */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);

            /*" -7066- MOVE BILHETE-OCORR-ENDERECO TO PROPOVA-OCOREND */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);

            /*" -7066- . */

        }

        [StopWatch]
        /*" R1040-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R1040_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -7053- EXEC SQL SELECT NUM_BILHETE , NUM_APOLICE , DATA_QUITACAO , COD_CLIENTE , OCORR_ENDERECO INTO :BILHETE-NUM-BILHETE , :BILHETE-NUM-APOLICE , :BILHETE-DATA-QUITACAO , :BILHETE-COD-CLIENTE , :BILHETE-OCORR-ENDERECO FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :MOVIMVGA-NUM-CERTIFICADO END-EXEC. */

            var r1040_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                MOVIMVGA_NUM_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r1040_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(executed_1.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(executed_1.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(executed_1.BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
                _.Move(executed_1.BILHETE_OCORR_ENDERECO, BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SEL-VGCOBSUB-SECTION */
        private void R1050_00_SEL_VGCOBSUB_SECTION()
        {
            /*" -7075- MOVE 'R1050-00-SEL-VGCOBSUB' TO PARAGRAFO */
            _.Move("R1050-00-SEL-VGCOBSUB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7078- MOVE 'SELECT VGCOBSUB' TO COMANDO */
            _.Move("SELECT VGCOBSUB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7080- MOVE 'S' TO WS-TEM-VGCOBSUB */
            _.Move("S", WS_WORK_AREAS.WS_TEM_VGCOBSUB);

            /*" -7089- PERFORM R1050_00_SEL_VGCOBSUB_DB_SELECT_1 */

            R1050_00_SEL_VGCOBSUB_DB_SELECT_1();

            /*" -7092- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7093- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7094- MOVE 'N' TO WS-TEM-VGCOBSUB */
                    _.Move("N", WS_WORK_AREAS.WS_TEM_VGCOBSUB);

                    /*" -7095- GO TO R1050-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/ //GOTO
                    return;

                    /*" -7096- ELSE */
                }
                else
                {


                    /*" -7098- DISPLAY 'PROBLEMAS NA LEITURA DE VGCOBSUB......' MOVIMVGA-NUM-APOLICE */
                    _.Display($"PROBLEMAS NA LEITURA DE VGCOBSUB......{MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

                    /*" -7099- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7100- END-IF */
                }


                /*" -7102- END-IF */
            }


            /*" -7103- MOVE MOVIMVGA-NUM-APOLICE TO PROPOVA-NUM-APOLICE */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);

            /*" -7103- . */

        }

        [StopWatch]
        /*" R1050-00-SEL-VGCOBSUB-DB-SELECT-1 */
        public void R1050_00_SEL_VGCOBSUB_DB_SELECT_1()
        {
            /*" -7089- EXEC SQL SELECT COD_COBERTURA INTO :VGCOBSUB-COD-COBERTURA FROM SEGUROS.VG_COBERTURAS_SUBG WHERE NUM_APOLICE = :MOVIMVGA-NUM-APOLICE AND COD_SUBGRUPO = :MOVIMVGA-COD-SUBGRUPO AND ( COD_COBERTURA = 25 OR COD_COBERTURA = 36 ) AND SIT_COBERTURA = 0 END-EXEC. */

            var r1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1 = new R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1()
            {
                MOVIMVGA_COD_SUBGRUPO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.ToString(),
                MOVIMVGA_NUM_APOLICE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1.Execute(r1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGCOBSUB_COD_COBERTURA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-SELECT-SEGURVGA-SECTION */
        private void R1060_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -7112- MOVE 'R1060-00      ' TO PARAGRAFO */
            _.Move("R1060-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7115- MOVE 'SELECT SEGURVGA' TO COMANDO */
            _.Move("SELECT SEGURVGA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7117- MOVE SPACES TO SEGURVGA-IDE-SEXO */
            _.Move("", SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_IDE_SEXO);

            /*" -7136- PERFORM R1060_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1060_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -7139- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7141- DISPLAY 'PROBLEMAS NA LEITURA DE SEGURADOS_VGAP' MOVIMVGA-NUM-CERTIFICADO */
                _.Display($"PROBLEMAS NA LEITURA DE SEGURADOS_VGAP{MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                /*" -7142- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7144- END-IF */
            }


            /*" -7145- MOVE SEGURVGA-NUM-CERTIFICADO TO PROPOVA-NUM-CERTIFICADO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -7146- MOVE SEGURVGA-NUM-APOLICE TO PROPOVA-NUM-APOLICE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);

            /*" -7147- MOVE SEGURVGA-COD-SUBGRUPO TO PROPOVA-COD-SUBGRUPO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);

            /*" -7148- MOVE SEGURVGA-DATA-INIVIGENCIA TO PROPOVA-DATA-QUITACAO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);

            /*" -7149- MOVE SEGURVGA-COD-CLIENTE TO PROPOVA-COD-CLIENTE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);

            /*" -7151- MOVE SEGURVGA-OCORR-ENDERECO TO PROPOVA-OCOREND */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);

            /*" -7152- MOVE SEGURVGA-NUM-APOLICE TO PRODUVG-NUM-APOLICE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);

            /*" -7153- MOVE SEGURVGA-COD-SUBGRUPO TO PRODUVG-COD-SUBGRUPO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO);

            /*" -7154- PERFORM R1070-00-SELECT-PRODUVG */

            R1070_00_SELECT_PRODUVG_SECTION();

            /*" -7154- . */

        }

        [StopWatch]
        /*" R1060-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1060_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -7136- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , DATA_INIVIGENCIA , NUM_CERTIFICADO , COD_CLIENTE , OCORR_ENDERECO , IDE_SEXO INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-DATA-INIVIGENCIA, :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-IDE-SEXO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :MOVIMVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                MOVIMVGA_NUM_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
                _.Move(executed_1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(executed_1.SEGURVGA_OCORR_ENDERECO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);
                _.Move(executed_1.SEGURVGA_IDE_SEXO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_IDE_SEXO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1070-00-SELECT-PRODUVG-SECTION */
        private void R1070_00_SELECT_PRODUVG_SECTION()
        {
            /*" -7163- MOVE 'R1070-00      ' TO PARAGRAFO */
            _.Move("R1070-00      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7166- MOVE 'SELECT PRODUVG' TO COMANDO */
            _.Move("SELECT PRODUVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7168- MOVE ZEROS TO PROPOVA-COD-PRODUTO */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

            /*" -7175- PERFORM R1070_00_SELECT_PRODUVG_DB_SELECT_1 */

            R1070_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -7178- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -7179- DISPLAY 'PROBLEMAS NA LEITURA DE PRODUTOS_VG' */
                _.Display($"PROBLEMAS NA LEITURA DE PRODUTOS_VG");

                /*" -7180- DISPLAY 'NUM APOLICE  = ' PRODUVG-NUM-APOLICE */
                _.Display($"NUM APOLICE  = {PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE}");

                /*" -7181- DISPLAY 'COD SUBGRUPO = ' PRODUVG-COD-SUBGRUPO */
                _.Display($"COD SUBGRUPO = {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO}");

                /*" -7182- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7184- END-IF */
            }


            /*" -7185- MOVE PROPOVA-COD-PRODUTO TO WS-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, WS_COD_PRODUTO);

            /*" -7186- . */

        }

        [StopWatch]
        /*" R1070-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R1070_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -7175- EXEC SQL SELECT COD_PRODUTO INTO :PROPOVA-COD-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO WITH UR END-EXEC. */

            var r1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_SUBGRUPO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.ToString(),
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTE-SECTION */
        private void R1100_00_SELECT_CLIENTE_SECTION()
        {
            /*" -7195- MOVE 'R1100-00-SELECT-CLIENTE' TO PARAGRAFO */
            _.Move("R1100-00-SELECT-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7198- MOVE 'SELECT CLIENTES' TO COMANDO */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7211- PERFORM R1100_00_SELECT_CLIENTE_DB_SELECT_1 */

            R1100_00_SELECT_CLIENTE_DB_SELECT_1();

            /*" -7214- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7216- DISPLAY 'PROBLEMAS NA LEITURA DE CLIENTES.......' CLIENTES-COD-CLIENTE */
                _.Display($"PROBLEMAS NA LEITURA DE CLIENTES.......{CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -7217- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7219- END-IF */
            }


            /*" -7220- IF CLIENT-SEXO-I < ZEROS */

            if (CLIENT_SEXO_I < 00)
            {

                /*" -7221- MOVE SEGURVGA-IDE-SEXO TO CLIENTES-IDE-SEXO */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);

                /*" -7222- END-IF */
            }


            /*" -7222- . */

        }

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTE-DB-SELECT-1 */
        public void R1100_00_SELECT_CLIENTE_DB_SELECT_1()
        {
            /*" -7211- EXEC SQL SELECT NOME_RAZAO, CGCCPF, DATA_NASCIMENTO, TIPO_PESSOA, IDE_SEXO INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-DATA-NASCIMENTO:CLIENT-DTNASC-I, :CLIENTES-TIPO-PESSOA, :CLIENTES-IDE-SEXO:CLIENT-SEXO-I FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1 = new R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
                _.Move(executed_1.CLIENT_SEXO_I, CLIENT_SEXO_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-ENDERECO-SECTION */
        private void R1200_00_SELECT_ENDERECO_SECTION()
        {
            /*" -7231- MOVE 'R1200-00-SELECT-ENDERECO' TO PARAGRAFO */
            _.Move("R1200-00-SELECT-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7235- MOVE 'SELECT ENDERECOS    ' TO COMANDO */
            _.Move("SELECT ENDERECOS    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7259- PERFORM R1200_00_SELECT_ENDERECO_DB_SELECT_1 */

            R1200_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -7262- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7263- DISPLAY 'R0120-ERRO SELECT ENDERECOS ' */
                _.Display($"R0120-ERRO SELECT ENDERECOS ");

                /*" -7264- DISPLAY 'R0120-APOLICE = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"R0120-APOLICE = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -7265- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7266- END-IF */
            }


            /*" -7266- . */

        }

        [StopWatch]
        /*" R1200-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R1200_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -7259- EXEC SQL SELECT COD_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , SIT_REGISTRO INTO :ENDERECO-COD-ENDERECO, :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-FAX , :ENDERECO-SIT-REGISTRO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            var executed_1 = R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(executed_1.ENDERECO_SIT_REGISTRO, ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_00_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-SEGURVGA-SECTION */
        private void R1300_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -7275- MOVE 'R0130-00-LER-SEGURVG' TO PARAGRAFO */
            _.Move("R0130-00-LER-SEGURVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7278- MOVE 'SELECT SEGURVGA' TO COMANDO */
            _.Move("SELECT SEGURVGA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7287- PERFORM R1300_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1300_00_SELECT_SEGURVGA_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1300-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1300_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -7287- EXEC SQL SELECT DATA_INIVIGENCIA , NUM_ITEM INTO :SEGURVGA-DATA-INIVIGENCIA , :SEGURVGA-NUM-ITEM FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-ENDOSSO-SECTION */
        private void R1400_00_SELECT_ENDOSSO_SECTION()
        {
            /*" -7297- MOVE 'R1400-00-SELECT-ENDOSSO ' TO PARAGRAFO */
            _.Move("R1400-00-SELECT-ENDOSSO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7300- MOVE 'SELECT ENDOSSO        ' TO COMANDO */
            _.Move("SELECT ENDOSSO        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7302- MOVE 'SIM' TO WTEM-ENDOSSO */
            _.Move("SIM", WS_WORK_AREAS.WTEM_ENDOSSO);

            /*" -7317- PERFORM R1400_00_SELECT_ENDOSSO_DB_SELECT_1 */

            R1400_00_SELECT_ENDOSSO_DB_SELECT_1();

            /*" -7320- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7321- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7322- MOVE 'NAO' TO WTEM-ENDOSSO */
                    _.Move("NAO", WS_WORK_AREAS.WTEM_ENDOSSO);

                    /*" -7323- ELSE */
                }
                else
                {


                    /*" -7324- DISPLAY 'R1400-ERRO SELECT ENDOSSOS       ' */
                    _.Display($"R1400-ERRO SELECT ENDOSSOS       ");

                    /*" -7325- DISPLAY 'R1400-NRCERTIF= ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"R1400-NRCERTIF= {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -7326- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7327- END-IF */
                }


                /*" -7328- END-IF */
            }


            /*" -7328- . */

        }

        [StopWatch]
        /*" R1400-00-SELECT-ENDOSSO-DB-SELECT-1 */
        public void R1400_00_SELECT_ENDOSSO_DB_SELECT_1()
        {
            /*" -7317- EXEC SQL SELECT A.DATA_TERVIGENCIA , A.COD_PRODUTO , C.NOME_RAZAO INTO :ENDOSSOS-DATA-TERVIGENCIA, :ENDOSSOS-COD-PRODUTO, :WHOST-NOME-ESTIP FROM SEGUROS.ENDOSSOS A, SEGUROS.APOLICES B, SEGUROS.CLIENTES C WHERE A.NUM_APOLICE = :PROPOVA-NUM-APOLICE AND A.NUM_ENDOSSO = 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND C.COD_CLIENTE = B.COD_CLIENTE WITH UR END-EXEC. */

            var r1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1 = new R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.WHOST_NOME_ESTIP, WHOST_NOME_ESTIP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-PROPOFID-SECTION */
        private void R1500_00_SELECT_PROPOFID_SECTION()
        {
            /*" -7338- MOVE 'R1500-00-SELECT-PROPOFID' TO PARAGRAFO */
            _.Move("R1500-00-SELECT-PROPOFID", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7343- MOVE 'SELECT PROPOFID' TO COMANDO */
            _.Move("SELECT PROPOFID", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7344- MOVE SPACES TO PROPOFID-IND-TIPO-CONTA */
            _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

            /*" -7347- MOVE ZEROS TO PROPOF-I WS-EOF-PROPOFID */
            _.Move(0, PROPOF_I, WS_WORK_AREAS.WS_EOF_PROPOFID);

            /*" -7353- PERFORM R1500_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1500_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -7356- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7357- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7358- MOVE 1 TO WS-EOF-PROPOFID */
                    _.Move(1, WS_WORK_AREAS.WS_EOF_PROPOFID);

                    /*" -7359- ELSE */
                }
                else
                {


                    /*" -7360- DISPLAY 'R1500-ERRO SELECT PROPOFID' */
                    _.Display($"R1500-ERRO SELECT PROPOFID");

                    /*" -7361- DISPLAY 'R1500-NRCERTIF= ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"R1500-NRCERTIF= {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -7362- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7363- END-IF */
                }


                /*" -7365- END-IF */
            }


            /*" -7366- IF WS-EOF-PROPOFID = 1 */

            if (WS_WORK_AREAS.WS_EOF_PROPOFID == 1)
            {

                /*" -7367- MOVE SPACES TO PROPOFID-IND-TIPO-CONTA */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

                /*" -7368- ELSE */
            }
            else
            {


                /*" -7369- IF PROPOF-I LESS ZEROS */

                if (PROPOF_I < 00)
                {

                    /*" -7370- MOVE SPACES TO PROPOFID-IND-TIPO-CONTA */
                    _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

                    /*" -7371- END-IF */
                }


                /*" -7372- END-IF */
            }


            /*" -7372- . */

        }

        [StopWatch]
        /*" R1500-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1500_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -7353- EXEC SQL SELECT IND_TIPO_CONTA INTO :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TIPO-CONTA :PROPOF-I FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_IND_TIPO_CONTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);
                _.Move(executed_1.PROPOF_I, PROPOF_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-SELECT-NOVA-ASSIST-SECTION */
        private void R1600_SELECT_NOVA_ASSIST_SECTION()
        {
            /*" -7384- MOVE 'R1600-SELECT-NOVA-ASSIST' TO PARAGRAFO */
            _.Move("R1600-SELECT-NOVA-ASSIST", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7387- MOVE 'SELECT-NOVA-ASSIST' TO COMANDO */
            _.Move("SELECT-NOVA-ASSIST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7388- MOVE SPACES TO WHOST-COD-CONVENIO */
            _.Move("", WHOST_COD_CONVENIO);

            /*" -7493- PERFORM R1600_SELECT_NOVA_ASSIST_DB_SELECT_1 */

            R1600_SELECT_NOVA_ASSIST_DB_SELECT_1();

            /*" -7496- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -7497- DISPLAY 'PROBLEMAS NA LEITURA DE SELECT-NOVA-ASSIST' */
                _.Display($"PROBLEMAS NA LEITURA DE SELECT-NOVA-ASSIST");

                /*" -7499- DISPLAY 'MOVIMVGA-NUM-CERTIFICADO  = ' MOVIMVGA-NUM-CERTIFICADO */
                _.Display($"MOVIMVGA-NUM-CERTIFICADO  = {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                /*" -7500- DISPLAY 'VGCOBSUB-COD-COBERTURA = ' VGCOBSUB-COD-COBERTURA */
                _.Display($"VGCOBSUB-COD-COBERTURA = {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA}");

                /*" -7501- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7503- END-IF */
            }


            /*" -7504- MOVE PROPOVA-COD-PRODUTO TO WS-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, WS_COD_PRODUTO);

            /*" -7505- . */

        }

        [StopWatch]
        /*" R1600-SELECT-NOVA-ASSIST-DB-SELECT-1 */
        public void R1600_SELECT_NOVA_ASSIST_DB_SELECT_1()
        {
            /*" -7493- EXEC SQL SELECT CASE T2.COD_COBERTURA WHEN 16 THEN '40000527293' WHEN 81 THEN '40000999981' WHEN 83 THEN '40000527273' WHEN 84 THEN '40000527275' WHEN 85 THEN '40000527277' WHEN 86 THEN '40000527305' WHEN 87 THEN '40000527279' WHEN 88 THEN '40000527281' WHEN 89 THEN '40000527283' WHEN 90 THEN '40000527285' WHEN 91 THEN '40000527287' WHEN 92 THEN '40000527307' WHEN 88 THEN '40000527289' WHEN 2 THEN '40000142243' WHEN 93 THEN '40000528999' WHEN 94 THEN '40000529003' WHEN 95 THEN '40000529001' WHEN 96 THEN '40000529005' WHEN 97 THEN '40000529007' WHEN 24 THEN '40000042589' END AS CONVENIO ,T2.COD_COBERTURA INTO :WHOST-COD-CONVENIO ,:VGCOBSUB-COD-COBERTURA FROM SEGUROS.PRODUTOS_VG AS T1 ,SEGUROS.VG_COBERTURAS_SUBG AS T2 ,SEGUROS.VG_ACESSORIO AS T3 ,SEGUROS.VG_PLANO_SUBGRUPO AS T4 ,SEGUROS.PROPOSTAS_VA AS T5 WHERE T1.NUM_APOLICE = T2.NUM_APOLICE AND T2.COD_COBERTURA = T3.NUM_ACESSORIO AND T1.COD_SUBGRUPO = T2.COD_SUBGRUPO AND T1.NUM_APOLICE = T4.NUM_APOLICE AND T1.COD_SUBGRUPO = T4.COD_SUBGRUPO AND T1.NUM_APOLICE = T5.NUM_APOLICE AND T1.COD_SUBGRUPO = T5.COD_SUBGRUPO AND T4.COD_OPCAO_COBER = T5.OPCAO_COBERTURA AND T4.STA_REGISTRO = 0 AND T2.SIT_COBERTURA = '0' AND T4.COD_TIPO_ASSISTENCIA IN (1,2,3) AND T5.NUM_CERTIFICADO = :MOVIMVGA-NUM-CERTIFICADO AND T2.COD_COBERTURA = :VGCOBSUB-COD-COBERTURA WITH UR END-EXEC. */

            var r1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1 = new R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1()
            {
                MOVIMVGA_NUM_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.ToString(),
                VGCOBSUB_COD_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.ToString(),
            };

            var executed_1 = R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1.Execute(r1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COD_CONVENIO, WHOST_COD_CONVENIO);
                _.Move(executed_1.VGCOBSUB_COD_COBERTURA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1702-00-FACIL-APOIO-FAMILIA-SECTION */
        private void R1702_00_FACIL_APOIO_FAMILIA_SECTION()
        {
            /*" -7516- MOVE 'R1702-00-FACIL-APOIO-FAMILIA' TO PARAGRAFO */
            _.Move("R1702-00-FACIL-APOIO-FAMILIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7535- MOVE 'R1702-00-FACIL-APOIO-FAMILIA' TO COMANDO */
            _.Move("R1702-00-FACIL-APOIO-FAMILIA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7536- IF (PROPOVA-COD-PRODUTO = 8521) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 8521))
            {

                /*" -7537- PERFORM R2000-16-ASSIST-FARM THRU R2000-16-SAIDA */

                R2000_16_ASSIST_FARM_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_16_SAIDA*/


                /*" -7538- PERFORM R2000-81-ASSIST-CEPR THRU R2000-81-SAIDA */

                R2000_81_ASSIST_CEPR_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_81_SAIDA*/


                /*" -7539- END-IF */
            }


            /*" -7540- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1702_99_SAIDA*/

        [StopWatch]
        /*" R1703-00-SEGURO-AP-BEM-ESTAR-SECTION */
        private void R1703_00_SEGURO_AP_BEM_ESTAR_SECTION()
        {
            /*" -7551- MOVE 'R1703-00-SEGURO-AP-BEM-ESTAR' TO PARAGRAFO */
            _.Move("R1703-00-SEGURO-AP-BEM-ESTAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7573- MOVE 'R1703-00-SEGURO-AP-BEM-ESTAR' TO COMANDO */
            _.Move("R1703-00-SEGURO-AP-BEM-ESTAR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7574- IF (PROPOVA-COD-PRODUTO = 8528 OR 8529 OR 8533 OR 8534) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("8528", "8529", "8533", "8534")))
            {

                /*" -7575- PERFORM R2000-16-ASSIST-FARM THRU R2000-16-SAIDA */

                R2000_16_ASSIST_FARM_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_16_SAIDA*/


                /*" -7576- PERFORM R2000-81-ASSIST-CEPR THRU R2000-81-SAIDA */

                R2000_81_ASSIST_CEPR_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_81_SAIDA*/


                /*" -7577- END-IF */
            }


            /*" -7578- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1703_99_SAIDA*/

        [StopWatch]
        /*" R2000-16-ASSIST-FARM-SECTION */
        private void R2000_16_ASSIST_FARM_SECTION()
        {
            /*" -7601- MOVE 'R2000-16-ASSIST-FARM' TO PARAGRAFO */
            _.Move("R2000-16-ASSIST-FARM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7603- MOVE 'R2000-16-ASSIST-FARM' TO COMANDO */
            _.Move("R2000-16-ASSIST-FARM", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7604- MOVE '40001262238' TO DET-NUM-CONTRATO */
            _.Move("40001262238", DETAIL_RECORD.DET_NUM_CONTRATO);

            /*" -7606- ADD 1 TO AC-FARM-INC WS-TOTAL-GRAVADOS */
            WS_WORK_AREAS.AC_FARM_INC.Value = WS_WORK_AREAS.AC_FARM_INC + 1;
            WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

            /*" -7607- MOVE 'I' TO DET-TIPO-MOV */
            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

            /*" -7608- ADD 1 TO WS-TOTAL-INC */
            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

            /*" -7609- WRITE REG-MVA1476B FROM DETAIL-RECORD */
            _.Move(DETAIL_RECORD.GetMoveValues(), REG_MVA1476B);

            MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

            /*" -7610- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_16_SAIDA*/

        [StopWatch]
        /*" R2000-81-ASSIST-CEPR-SECTION */
        private void R2000_81_ASSIST_CEPR_SECTION()
        {
            /*" -7633- MOVE 'R2000-81-ASSIST-CEPR' TO PARAGRAFO */
            _.Move("R2000-81-ASSIST-CEPR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7635- MOVE 'R2000-81-ASSIST-CEPR' TO COMANDO */
            _.Move("R2000-81-ASSIST-CEPR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7636- MOVE '40000999981' TO DET-NUM-CONTRATO */
            _.Move("40000999981", DETAIL_RECORD.DET_NUM_CONTRATO);

            /*" -7638- ADD 1 TO AC-CEPR-INC WS-TOTAL-GRAVADOS */
            WS_WORK_AREAS.AC_CEPR_INC.Value = WS_WORK_AREAS.AC_CEPR_INC + 1;
            WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

            /*" -7639- MOVE 'I' TO DET-TIPO-MOV */
            _.Move("I", DETAIL_RECORD.DET_TIPO_MOV);

            /*" -7640- ADD 1 TO WS-TOTAL-INC */
            WS_WORK_AREAS.WS_TOTAL_INC.Value = WS_WORK_AREAS.WS_TOTAL_INC + 1;

            /*" -7641- WRITE REG-M1476BHM FROM DETAIL-RECORD */
            _.Move(DETAIL_RECORD.GetMoveValues(), REG_M1476BHM);

            M1476BHM.Write(REG_M1476BHM.GetMoveValues().ToString());

            /*" -7642- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_81_SAIDA*/

        [StopWatch]
        /*" R5200-00-SELECT-PARAM-SECTION */
        private void R5200_00_SELECT_PARAM_SECTION()
        {
            /*" -7654- MOVE 'R5200-00-SELECT-PARAM      ' TO PARAGRAFO */
            _.Move("R5200-00-SELECT-PARAM      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7668- MOVE 'SELECT PARAM          ' TO COMANDO */
            _.Move("SELECT PARAM          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7687- PERFORM R5200_00_SELECT_PARAM_DB_SELECT_1 */

            R5200_00_SELECT_PARAM_DB_SELECT_1();

            /*" -7691- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7692- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7694- MOVE 1 TO LTSOLPAR-PARAM-SMINT01 */
                    _.Move(1, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

                    /*" -7700- MOVE ZEROS TO LTSOLPAR-COD-CLIENTE LTSOLPAR-PARAM-INTG01 LTSOLPAR-PARAM-INTG02 LTSOLPAR-PARAM-INTG03 LTSOLPAR-PARAM-DEC01 */
                    _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

                    /*" -7702- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
                    _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

                    /*" -7703- ELSE */
                }
                else
                {


                    /*" -7704- DISPLAY 'R0010-ERRO SELECT PARAMETROS' */
                    _.Display($"R0010-ERRO SELECT PARAMETROS");

                    /*" -7705- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7706- END-IF */
                }


                /*" -7708- END-IF */
            }


            /*" -7710- MOVE LTSOLPAR-PARAM-SMINT01 TO WS-SEQUENCIAL */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01, WS_WORK_AREAS.WS_SEQUENCIAL);

            /*" -7711- MOVE LTSOLPAR-PARAM-INTG01 TO WS-TOTAL-INC */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01, WS_WORK_AREAS.WS_TOTAL_INC);

            /*" -7712- MOVE LTSOLPAR-PARAM-INTG02 TO WS-TOTAL-EXC */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02, WS_WORK_AREAS.WS_TOTAL_EXC);

            /*" -7713- MOVE LTSOLPAR-PARAM-INTG03 TO WS-TOTAL-ALT */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03, WS_WORK_AREAS.WS_TOTAL_ALT);

            /*" -7715- MOVE LTSOLPAR-PARAM-DEC01 TO WS-TOTAL-ANT */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01, WS_WORK_AREAS.WS_TOTAL_ANT);

            /*" -7716- DISPLAY 'DADOS DO ULTIMO PROCESSAMENTO' */
            _.Display($"DADOS DO ULTIMO PROCESSAMENTO");

            /*" -7717- DISPLAY 'DATA          =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($"DATA          ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -7718- DISPLAY 'SEQUENCIAL    =' WS-SEQUENCIAL */
            _.Display($"SEQUENCIAL    ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -7719- DISPLAY 'INCLUIDOS     =' WS-TOTAL-INC */
            _.Display($"INCLUIDOS     ={WS_WORK_AREAS.WS_TOTAL_INC}");

            /*" -7720- DISPLAY 'EXCLUIDOS     =' WS-TOTAL-EXC */
            _.Display($"EXCLUIDOS     ={WS_WORK_AREAS.WS_TOTAL_EXC}");

            /*" -7721- DISPLAY 'ALTERADOS     =' WS-TOTAL-ALT */
            _.Display($"ALTERADOS     ={WS_WORK_AREAS.WS_TOTAL_ALT}");

            /*" -7723- DISPLAY 'TOTAL         =' WS-TOTAL-ANT */
            _.Display($"TOTAL         ={WS_WORK_AREAS.WS_TOTAL_ANT}");

            /*" -7728- MOVE 0 TO WS-TOTAL-INC WS-TOTAL-EXC WS-TOTAL-ALT WS-TOTAL-ATU WS-TOTAL-X */
            _.Move(0, WS_WORK_AREAS.WS_TOTAL_INC, WS_WORK_AREAS.WS_TOTAL_EXC, WS_WORK_AREAS.WS_TOTAL_ALT, WS_WORK_AREAS.WS_TOTAL_ATU, WS_WORK_AREAS.WS_TOTAL_X);

            /*" -7728- . */

        }

        [StopWatch]
        /*" R5200-00-SELECT-PARAM-DB-SELECT-1 */
        public void R5200_00_SELECT_PARAM_DB_SELECT_1()
        {
            /*" -7687- EXEC SQL SELECT T1.COD_CLIENTE , T1.PARAM_SMINT01 , T1.PARAM_INTG01 , T1.PARAM_INTG02 , T1.PARAM_INTG03 , T1.PARAM_DEC01 , T1.DATA_SOLICITACAO INTO :LTSOLPAR-COD-CLIENTE , :LTSOLPAR-PARAM-SMINT01 , :LTSOLPAR-PARAM-INTG01 , :LTSOLPAR-PARAM-INTG02 , :LTSOLPAR-PARAM-INTG03 , :LTSOLPAR-PARAM-DEC01 , :LTSOLPAR-DATA-SOLICITACAO FROM SEGUROS.LT_SOLICITA_PARAM T1 WHERE T1.COD_PROGRAMA = 'VA1476B' AND T1.SIT_SOLICITACAO = '0' WITH UR END-EXEC. */

            var r5200_00_SELECT_PARAM_DB_SELECT_1_Query1 = new R5200_00_SELECT_PARAM_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R5200_00_SELECT_PARAM_DB_SELECT_1_Query1.Execute(r5200_00_SELECT_PARAM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTSOLPAR_COD_CLIENTE, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);
                _.Move(executed_1.LTSOLPAR_PARAM_SMINT01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);
                _.Move(executed_1.LTSOLPAR_PARAM_INTG01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);
                _.Move(executed_1.LTSOLPAR_PARAM_INTG02, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);
                _.Move(executed_1.LTSOLPAR_PARAM_INTG03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);
                _.Move(executed_1.LTSOLPAR_PARAM_DEC01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);
                _.Move(executed_1.LTSOLPAR_DATA_SOLICITACAO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R5300-00-UPDATE-PARAM-SECTION */
        private void R5300_00_UPDATE_PARAM_SECTION()
        {
            /*" -7738- MOVE 'R5300-00-UPDATE-PARAM      ' TO PARAGRAFO */
            _.Move("R5300-00-UPDATE-PARAM      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7742- MOVE 'UPDATE PARAM          ' TO COMANDO */
            _.Move("UPDATE PARAM          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7747- PERFORM R5300_00_UPDATE_PARAM_DB_UPDATE_1 */

            R5300_00_UPDATE_PARAM_DB_UPDATE_1();

            /*" -7750- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7751- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -7752- DISPLAY 'ERRO NO UPDATE DA LT-SOLICITA-PARAM' */
                    _.Display($"ERRO NO UPDATE DA LT-SOLICITA-PARAM");

                    /*" -7753- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7754- END-IF */
                }


                /*" -7755- END-IF */
            }


            /*" -7755- . */

        }

        [StopWatch]
        /*" R5300-00-UPDATE-PARAM-DB-UPDATE-1 */
        public void R5300_00_UPDATE_PARAM_DB_UPDATE_1()
        {
            /*" -7747- EXEC SQL UPDATE SEGUROS.LT_SOLICITA_PARAM SET SIT_SOLICITACAO = '3' WHERE COD_PROGRAMA = 'VA1476B' AND SIT_SOLICITACAO = '0' END-EXEC. */

            var r5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1 = new R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1()
            {
            };

            R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1.Execute(r5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/

        [StopWatch]
        /*" R5400-00-INSERT-PARAM-SECTION */
        private void R5400_00_INSERT_PARAM_SECTION()
        {
            /*" -7765- MOVE 'R5400-00-UPDATE-PARAM      ' TO PARAGRAFO */
            _.Move("R5400-00-UPDATE-PARAM      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7771- MOVE 'INSERT PARAM          ' TO COMANDO */
            _.Move("INSERT PARAM          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7772- MOVE 40000042589 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000042589, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -7773- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -7774- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -7775- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -7776- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -7777- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -7778- MOVE '0' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("0", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -7781- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -7784- COMPUTE AC-EMPR-ATU = AC-EMPR-ANT + AC-EMPR-INC - AC-EMPR-EXC . */
            WS_WORK_AREAS.AC_EMPR_ATU.Value = WS_WORK_AREAS.AC_EMPR_ANT + WS_WORK_AREAS.AC_EMPR_INC - WS_WORK_AREAS.AC_EMPR_EXC;

            /*" -7786- ADD 1 TO WS-SEQUENCIAL. */
            WS_WORK_AREAS.WS_SEQUENCIAL.Value = WS_WORK_AREAS.WS_SEQUENCIAL + 1;

            /*" -7787- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -7788- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -7789- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -7790- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -7791- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -7792- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -7793- MOVE AC-EMPR-INC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_EMPR_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -7794- MOVE AC-EMPR-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_EMPR_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -7795- MOVE AC-EMPR-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_EMPR_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -7796- MOVE AC-EMPR-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_EMPR_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -7797- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -7798- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -7799- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -7800- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -7801- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -7802- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -7803- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -7805- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -7807- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -7808- DISPLAY ' ' */
            _.Display($" ");

            /*" -7809- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -7810- DISPLAY ' GRAVOU PARAMETRO 40000042589 - EMPRESARIAL' */
            _.Display($" GRAVOU PARAMETRO 40000042589 - EMPRESARIAL");

            /*" -7811- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -7812- DISPLAY ' TOTAL ANTERIOR     =' AC-EMPR-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_EMPR_ANT}");

            /*" -7813- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -7814- DISPLAY ' TOTAL INCLUIDO     =' AC-EMPR-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_EMPR_INC}");

            /*" -7815- DISPLAY ' TOTAL EXCLUIDO     =' AC-EMPR-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_EMPR_EXC}");

            /*" -7816- DISPLAY ' TOTAL ALTERADO     =' AC-EMPR-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_EMPR_ALT}");

            /*" -7817- DISPLAY ' TOTAL ATUAL        =' AC-EMPR-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_EMPR_ATU}");

            /*" -7821- DISPLAY ' TOTAL AC-EMPR-X    =' AC-EMPR-X */
            _.Display($" TOTAL AC-EMPR-X    ={WS_WORK_AREAS.AC_EMPR_X}");

            /*" -7822- MOVE 40001262238 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40001262238, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -7823- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -7824- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -7825- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -7826- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -7827- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -7828- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -7831- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -7834- COMPUTE AC-FARM-ATU = AC-FARM-ANT + AC-FARM-INC - AC-FARM-EXC */
            WS_WORK_AREAS.AC_FARM_ATU.Value = WS_WORK_AREAS.AC_FARM_ANT + WS_WORK_AREAS.AC_FARM_INC - WS_WORK_AREAS.AC_FARM_EXC;

            /*" -7836- ADD 1 TO WS-SEQUENCIAL. */
            WS_WORK_AREAS.WS_SEQUENCIAL.Value = WS_WORK_AREAS.WS_SEQUENCIAL + 1;

            /*" -7837- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -7838- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -7839- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -7840- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -7841- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -7842- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -7843- MOVE AC-FARM-INC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_FARM_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -7844- MOVE AC-FARM-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_FARM_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -7845- MOVE AC-FARM-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_FARM_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -7846- MOVE AC-FARM-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_FARM_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -7847- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -7848- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -7849- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -7850- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -7851- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -7852- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -7853- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -7855- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -7858- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -7859- DISPLAY ' ' */
            _.Display($" ");

            /*" -7860- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -7861- DISPLAY ' GRAVOU PARAMETRO 40001262238 - FARMACIA' */
            _.Display($" GRAVOU PARAMETRO 40001262238 - FARMACIA");

            /*" -7862- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -7863- DISPLAY ' TOTAL ANTERIOR     =' AC-FARM-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_FARM_ANT}");

            /*" -7864- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -7865- DISPLAY ' TOTAL INCLUIDO     =' AC-FARM-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_FARM_INC}");

            /*" -7866- DISPLAY ' TOTAL EXCLUIDO     =' AC-FARM-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_FARM_EXC}");

            /*" -7867- DISPLAY ' TOTAL ALTERADO     =' AC-FARM-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_FARM_ALT}");

            /*" -7871- DISPLAY ' TOTAL ATUAL        =' AC-FARM-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_FARM_ATU}");

            /*" -7872- MOVE 40000042239 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000042239, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -7873- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -7874- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -7875- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -7876- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -7877- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -7878- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -7881- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -7884- COMPUTE AC-RESI-ATU = AC-RESI-ANT + AC-RESI-INC - AC-RESI-EXC */
            WS_WORK_AREAS.AC_RESI_ATU.Value = WS_WORK_AREAS.AC_RESI_ANT + WS_WORK_AREAS.AC_RESI_INC - WS_WORK_AREAS.AC_RESI_EXC;

            /*" -7885- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -7886- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -7887- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -7888- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -7889- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -7890- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -7891- MOVE AC-RESI-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_RESI_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -7892- MOVE AC-RESI-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_RESI_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -7893- MOVE AC-RESI-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_RESI_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -7894- MOVE AC-RESI-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_RESI_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -7895- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -7896- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -7897- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -7898- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -7899- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -7900- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -7901- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -7903- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -7906- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -7907- DISPLAY ' ' */
            _.Display($" ");

            /*" -7908- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -7909- DISPLAY ' GRAVOU PARAMETRO 40000042239 - RESIDENCIA' */
            _.Display($" GRAVOU PARAMETRO 40000042239 - RESIDENCIA");

            /*" -7910- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -7911- DISPLAY ' TOTAL ANTERIOR     =' AC-RESI-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_RESI_ANT}");

            /*" -7912- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -7913- DISPLAY ' TOTAL INCLUIDO     =' AC-RESI-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_RESI_INC}");

            /*" -7914- DISPLAY ' TOTAL EXCLUIDO     =' AC-RESI-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_RESI_EXC}");

            /*" -7915- DISPLAY ' TOTAL ALTERADO     =' AC-RESI-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_RESI_ALT}");

            /*" -7919- DISPLAY ' TOTAL ATUAL        =' AC-RESI-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_RESI_ATU}");

            /*" -7920- MOVE 40001072240 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40001072240, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -7921- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -7922- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -7923- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -7924- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -7925- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -7926- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -7929- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -7932- COMPUTE AC-VIAG-ATU = AC-VIAG-ANT + AC-VIAG-INC - AC-VIAG-EXC */
            WS_WORK_AREAS.AC_VIAG_ATU.Value = WS_WORK_AREAS.AC_VIAG_ANT + WS_WORK_AREAS.AC_VIAG_INC - WS_WORK_AREAS.AC_VIAG_EXC;

            /*" -7933- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -7934- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -7935- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -7936- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -7937- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -7938- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -7939- MOVE AC-VIAG-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_VIAG_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -7940- MOVE AC-VIAG-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_VIAG_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -7941- MOVE AC-VIAG-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_VIAG_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -7942- MOVE AC-VIAG-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_VIAG_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -7943- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -7944- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -7945- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -7946- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -7947- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -7948- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -7949- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -7951- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -7954- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -7955- DISPLAY ' ' */
            _.Display($" ");

            /*" -7956- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -7957- DISPLAY ' GRAVOU PARAMETRO 40001072240 - VIAGEM' */
            _.Display($" GRAVOU PARAMETRO 40001072240 - VIAGEM");

            /*" -7958- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -7959- DISPLAY ' TOTAL ANTERIOR     =' AC-VIAG-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_VIAG_ANT}");

            /*" -7960- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -7961- DISPLAY ' TOTAL INCLUIDO     =' AC-VIAG-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_VIAG_INC}");

            /*" -7962- DISPLAY ' TOTAL EXCLUIDO     =' AC-VIAG-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_VIAG_EXC}");

            /*" -7963- DISPLAY ' TOTAL ALTERADO     =' AC-VIAG-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_VIAG_ALT}");

            /*" -7967- DISPLAY ' TOTAL ATUAL        =' AC-VIAG-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_VIAG_ATU}");

            /*" -7968- MOVE 40001102241 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40001102241, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -7969- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -7970- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -7971- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -7972- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -7973- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -7974- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -7977- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -7980- COMPUTE AC-NUTR-ATU = AC-NUTR-ANT + AC-NUTR-INC - AC-NUTR-EXC */
            WS_WORK_AREAS.AC_NUTR_ATU.Value = WS_WORK_AREAS.AC_NUTR_ANT + WS_WORK_AREAS.AC_NUTR_INC - WS_WORK_AREAS.AC_NUTR_EXC;

            /*" -7981- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -7982- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -7983- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -7984- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -7985- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -7986- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -7987- MOVE AC-NUTR-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_NUTR_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -7988- MOVE AC-NUTR-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_NUTR_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -7989- MOVE AC-NUTR-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_NUTR_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -7990- MOVE AC-NUTR-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_NUTR_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -7991- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -7992- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -7993- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -7994- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -7995- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -7996- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -7997- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -7999- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8002- PERFORM R5600-00-INSERT-LT-SOLICITA. */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8003- DISPLAY ' ' */
            _.Display($" ");

            /*" -8004- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8005- DISPLAY ' GRAVOU PARAMETRO 40001102241 - NUTRICAO' */
            _.Display($" GRAVOU PARAMETRO 40001102241 - NUTRICAO");

            /*" -8006- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8007- DISPLAY ' TOTAL ANTERIOR     =' AC-NUTR-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_NUTR_ANT}");

            /*" -8008- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8009- DISPLAY ' TOTAL INCLUIDO     =' AC-NUTR-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_NUTR_INC}");

            /*" -8010- DISPLAY ' TOTAL EXCLUIDO     =' AC-NUTR-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_NUTR_EXC}");

            /*" -8011- DISPLAY ' TOTAL ALTERADO     =' AC-NUTR-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_NUTR_ALT}");

            /*" -8012- DISPLAY ' TOTAL ATUAL        =' AC-NUTR-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_NUTR_ATU}");

            /*" -8017- DISPLAY ' TOTAL AC-NUTR-X    =' AC-NUTR-X */
            _.Display($" TOTAL AC-NUTR-X    ={WS_WORK_AREAS.AC_NUTR_X}");

            /*" -8018- MOVE 40001152343 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40001152343, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8019- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8020- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8021- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8022- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8023- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8024- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8027- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8030- COMPUTE AC-RPROF-ATU = AC-RPROF-ANT + AC-RPROF-INC - AC-RPROF-EXC */
            WS_WORK_AREAS.AC_RPROF_ATU.Value = WS_WORK_AREAS.AC_RPROF_ANT + WS_WORK_AREAS.AC_RPROF_INC - WS_WORK_AREAS.AC_RPROF_EXC;

            /*" -8031- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8032- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8033- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8034- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8035- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8036- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8037- MOVE AC-RPROF-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_RPROF_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8038- MOVE AC-RPROF-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_RPROF_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8039- MOVE AC-RPROF-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_RPROF_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8040- MOVE AC-RPROF-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_RPROF_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8041- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8042- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8043- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8044- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8045- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8046- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8047- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8049- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8052- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8053- DISPLAY ' ' */
            _.Display($" ");

            /*" -8054- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8055- DISPLAY ' GRAVOU PARAMETRO 40001152343 - RECOL.PROFISSIONAL' */
            _.Display($" GRAVOU PARAMETRO 40001152343 - RECOL.PROFISSIONAL");

            /*" -8056- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8057- DISPLAY ' TOTAL ANTERIOR     =' AC-RPROF-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_RPROF_ANT}");

            /*" -8058- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8059- DISPLAY ' TOTAL INCLUIDO     =' AC-RPROF-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_RPROF_INC}");

            /*" -8060- DISPLAY ' TOTAL EXCLUIDO     =' AC-RPROF-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_RPROF_EXC}");

            /*" -8061- DISPLAY ' TOTAL ALTERADO     =' AC-RPROF-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_RPROF_ALT}");

            /*" -8062- DISPLAY ' TOTAL ATUAL        =' AC-RPROF-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_RPROF_ATU}");

            /*" -8067- DISPLAY ' TOTAL AC-RPROF-X   =' AC-RPROF-X */
            _.Display($" TOTAL AC-RPROF-X   ={WS_WORK_AREAS.AC_RPROF_X}");

            /*" -8068- MOVE 40001172543 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40001172543, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8069- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8070- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8071- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8072- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8073- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8074- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8077- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8080- COMPUTE AC-EDUCA-ATU = AC-EDUCA-ANT + AC-EDUCA-INC - AC-EDUCA-EXC */
            WS_WORK_AREAS.AC_EDUCA_ATU.Value = WS_WORK_AREAS.AC_EDUCA_ANT + WS_WORK_AREAS.AC_EDUCA_INC - WS_WORK_AREAS.AC_EDUCA_EXC;

            /*" -8081- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8082- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8083- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8084- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8085- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8086- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8087- MOVE AC-EDUCA-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_EDUCA_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8088- MOVE AC-EDUCA-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_EDUCA_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8089- MOVE AC-EDUCA-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8090- MOVE AC-EDUCA-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8091- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8092- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8093- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8094- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8095- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8096- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8097- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8099- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8102- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8103- DISPLAY ' ' */
            _.Display($" ");

            /*" -8104- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8105- DISPLAY ' GRAVOU PARAMETRO 40001172543 - ASSIST. EDUCACIONAL' */
            _.Display($" GRAVOU PARAMETRO 40001172543 - ASSIST. EDUCACIONAL");

            /*" -8106- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8107- DISPLAY ' TOTAL ANTERIOR     =' AC-EDUCA-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_EDUCA_ANT}");

            /*" -8108- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8109- DISPLAY ' TOTAL INCLUIDO     =' AC-EDUCA-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_EDUCA_INC}");

            /*" -8110- DISPLAY ' TOTAL EXCLUIDO     =' AC-EDUCA-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_EDUCA_EXC}");

            /*" -8111- DISPLAY ' TOTAL ALTERADO     =' AC-EDUCA-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_EDUCA_ALT}");

            /*" -8115- DISPLAY ' TOTAL ATUAL        =' AC-EDUCA-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_EDUCA_ATU}");

            /*" -8116- MOVE 40001172590 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40001172590, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8117- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8118- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8119- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8120- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8121- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8122- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8125- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8128- COMPUTE AC-EDUCA-ATU = AC-EDUCA-ANT-U + AC-EDUCA-INC-U - AC-EDUCA-EXC-U */
            WS_WORK_AREAS.AC_EDUCA_ATU.Value = WS_WORK_AREAS.AC_EDUCA_ANT_U + WS_WORK_AREAS.AC_EDUCA_INC_U - WS_WORK_AREAS.AC_EDUCA_EXC_U;

            /*" -8129- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8130- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8131- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8132- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8133- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8134- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8135- MOVE AC-EDUCA-INC-U TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_EDUCA_INC_U, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8136- MOVE AC-EDUCA-EXC-U TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_EDUCA_EXC_U, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8137- MOVE AC-EDUCA-ALT-U TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ALT_U, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8138- MOVE AC-EDUCA-ATU-U TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ATU_U, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8139- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8140- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8141- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8142- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8143- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8144- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8145- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8147- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8150- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8151- DISPLAY ' ' */
            _.Display($" ");

            /*" -8152- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8153- DISPLAY ' GRAVOU PARAMETRO 40001172590 - ASSIST. EMPRESARIAL' */
            _.Display($" GRAVOU PARAMETRO 40001172590 - ASSIST. EMPRESARIAL");

            /*" -8154- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8155- DISPLAY ' TOTAL ANTERIOR     =' AC-EDUCA-ANT-U */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_EDUCA_ANT_U}");

            /*" -8156- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8157- DISPLAY ' TOTAL INCLUIDO     =' AC-EDUCA-INC-U */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_EDUCA_INC_U}");

            /*" -8158- DISPLAY ' TOTAL EXCLUIDO     =' AC-EDUCA-EXC-U */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_EDUCA_EXC_U}");

            /*" -8159- DISPLAY ' TOTAL ALTERADO     =' AC-EDUCA-ALT-U */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_EDUCA_ALT_U}");

            /*" -8163- DISPLAY ' TOTAL ATUAL        =' AC-EDUCA-ATU-U */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_EDUCA_ATU_U}");

            /*" -8164- MOVE 40000032503 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000032503, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8165- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8166- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8167- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8168- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8169- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8170- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8173- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8176- COMPUTE AC-HDESK-ATU = AC-HDESK-ANT + AC-HDESK-INC - AC-HDESK-EXC */
            WS_WORK_AREAS.AC_HDESK_ATU.Value = WS_WORK_AREAS.AC_HDESK_ANT + WS_WORK_AREAS.AC_HDESK_INC - WS_WORK_AREAS.AC_HDESK_EXC;

            /*" -8177- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8178- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8179- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8180- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8181- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8182- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8183- MOVE AC-HDESK-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_HDESK_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8184- MOVE AC-HDESK-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_HDESK_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8185- MOVE AC-HDESK-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_HDESK_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8186- MOVE AC-HDESK-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_HDESK_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8187- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8188- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8189- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8190- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8191- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8192- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8193- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8195- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8198- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8199- DISPLAY ' ' */
            _.Display($" ");

            /*" -8200- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8201- DISPLAY ' GRAVOU PARAMETRO 40000032503 - HELP DESK' */
            _.Display($" GRAVOU PARAMETRO 40000032503 - HELP DESK");

            /*" -8202- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8203- DISPLAY ' TOTAL ANTERIOR     =' AC-HDESK-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_HDESK_ANT}");

            /*" -8204- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8205- DISPLAY ' TOTAL INCLUIDO     =' AC-HDESK-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_HDESK_INC}");

            /*" -8206- DISPLAY ' TOTAL EXCLUIDO     =' AC-HDESK-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_HDESK_EXC}");

            /*" -8207- DISPLAY ' TOTAL ALTERADO     =' AC-HDESK-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_HDESK_ALT}");

            /*" -8211- DISPLAY ' TOTAL ATUAL        =' AC-HDESK-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_HDESK_ATU}");

            /*" -8212- MOVE 40001112584 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40001112584, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8213- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8214- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8215- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8216- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8217- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8218- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8221- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8224- COMPUTE AC-VIOL-ATU = AC-VIOL-ANT + AC-VIOL-INC - AC-VIOL-EXC */
            WS_WORK_AREAS.AC_VIOL_ATU.Value = WS_WORK_AREAS.AC_VIOL_ANT + WS_WORK_AREAS.AC_VIOL_INC - WS_WORK_AREAS.AC_VIOL_EXC;

            /*" -8225- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8226- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8227- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8228- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8229- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8230- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8231- MOVE AC-VIOL-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_VIOL_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8232- MOVE AC-VIOL-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_VIOL_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8233- MOVE AC-VIOL-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_VIOL_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8234- MOVE AC-VIOL-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_VIOL_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8235- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8236- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8237- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8238- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8239- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8240- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8241- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8243- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8246- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8247- DISPLAY ' ' */
            _.Display($" ");

            /*" -8248- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8249- DISPLAY ' GRAVOU PARAMETRO 40001112584 - ATOS VIOLENTOS' */
            _.Display($" GRAVOU PARAMETRO 40001112584 - ATOS VIOLENTOS");

            /*" -8250- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8251- DISPLAY ' TOTAL ANTERIOR     =' AC-VIOL-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_VIOL_ANT}");

            /*" -8252- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8253- DISPLAY ' TOTAL INCLUIDO     =' AC-VIOL-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_VIOL_INC}");

            /*" -8254- DISPLAY ' TOTAL EXCLUIDO     =' AC-VIOL-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_VIOL_EXC}");

            /*" -8255- DISPLAY ' TOTAL ALTERADO     =' AC-VIOL-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_VIOL_ALT}");

            /*" -8422- DISPLAY ' TOTAL ATUAL        =' AC-VIOL-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_VIOL_ATU}");

            /*" -8423- MOVE 40000142324 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000142324, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8424- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8425- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8426- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8427- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8428- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8429- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8432- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8435- COMPUTE AC-SAFES-ATU = AC-SAFES-ANT + AC-SAFES-INC - AC-SAFES-EXC */
            WS_WORK_AREAS.AC_SAFES_ATU.Value = WS_WORK_AREAS.AC_SAFES_ANT + WS_WORK_AREAS.AC_SAFES_INC - WS_WORK_AREAS.AC_SAFES_EXC;

            /*" -8436- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8437- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8438- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8439- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8440- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8441- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8442- MOVE AC-SAFES-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_SAFES_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8443- MOVE AC-SAFES-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_SAFES_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8444- MOVE AC-SAFES-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_SAFES_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8445- MOVE AC-SAFES-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_SAFES_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8446- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8447- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8448- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8449- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8450- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8451- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8452- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8454- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8457- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8458- DISPLAY ' ' */
            _.Display($" ");

            /*" -8459- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8460- DISPLAY ' GRAVOU PARAMETRO 40000142324 - SAF ESTENDIDO   ' */
            _.Display($" GRAVOU PARAMETRO 40000142324 - SAF ESTENDIDO   ");

            /*" -8461- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8462- DISPLAY ' TOTAL ANTERIOR     =' AC-SAFES-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_SAFES_ANT}");

            /*" -8463- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8464- DISPLAY ' TOTAL INCLUIDO     =' AC-SAFES-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_SAFES_INC}");

            /*" -8465- DISPLAY ' TOTAL EXCLUIDO     =' AC-SAFES-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_SAFES_EXC}");

            /*" -8466- DISPLAY ' TOTAL ALTERADO     =' AC-SAFES-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_SAFES_ALT}");

            /*" -8467- DISPLAY ' TOTAL ATUAL        =' AC-SAFES-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_SAFES_ATU}");

            /*" -8472- DISPLAY ' TOTAL AC-SAFES-X   =' AC-SAFES-X */
            _.Display($" TOTAL AC-SAFES-X   ={WS_WORK_AREAS.AC_SAFES_X}");

            /*" -8473- MOVE 40000142242 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000142242, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8474- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8475- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8476- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8477- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8478- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8479- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8482- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8485- COMPUTE AC-CESBA-ATU = AC-CESBA-ANT + AC-CESBA-INC - AC-CESBA-EXC */
            WS_WORK_AREAS.AC_CESBA_ATU.Value = WS_WORK_AREAS.AC_CESBA_ANT + WS_WORK_AREAS.AC_CESBA_INC - WS_WORK_AREAS.AC_CESBA_EXC;

            /*" -8486- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8487- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8488- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8489- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8490- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8491- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8492- MOVE AC-CESBA-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_CESBA_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8493- MOVE AC-CESBA-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_CESBA_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8494- MOVE AC-CESBA-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_CESBA_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8495- MOVE AC-CESBA-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_CESBA_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8496- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8497- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8498- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8499- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8500- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8501- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8502- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8504- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8507- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8508- DISPLAY ' ' */
            _.Display($" ");

            /*" -8509- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8510- DISPLAY ' GRAVOU PARAMETRO 40000142242 - CESTA BASICA    ' */
            _.Display($" GRAVOU PARAMETRO 40000142242 - CESTA BASICA    ");

            /*" -8511- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8512- DISPLAY ' TOTAL ANTERIOR     =' AC-CESBA-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_CESBA_ANT}");

            /*" -8513- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8514- DISPLAY ' TOTAL INCLUIDO     =' AC-CESBA-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_CESBA_INC}");

            /*" -8515- DISPLAY ' TOTAL EXCLUIDO     =' AC-CESBA-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_CESBA_EXC}");

            /*" -8516- DISPLAY ' TOTAL ALTERADO     =' AC-CESBA-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_CESBA_ALT}");

            /*" -8520- DISPLAY ' TOTAL ATUAL        =' AC-CESBA-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_CESBA_ATU}");

            /*" -8521- MOVE 40001052587 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40001052587, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8522- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8523- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8524- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8525- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8526- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8527- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8530- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8533- COMPUTE AC-CESTABONUS-ATU = AC-CESTABONUS-ANT + AC-CESTABONUS-INC - AC-CESTABONUS-EXC */
            WS_WORK_AREAS.AC_CESTABONUS_ATU.Value = WS_WORK_AREAS.AC_CESTABONUS_ANT + WS_WORK_AREAS.AC_CESTABONUS_INC - WS_WORK_AREAS.AC_CESTABONUS_EXC;

            /*" -8534- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8535- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8536- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8537- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8538- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8539- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8540- MOVE AC-CESTABONUS-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8541- MOVE AC-CESTABONUS-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8542- MOVE AC-CESTABONUS-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8543- MOVE AC-CESTABONUS-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8544- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8545- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8546- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8547- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8548- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8549- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8550- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8552- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8554- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8555- DISPLAY ' ' */
            _.Display($" ");

            /*" -8556- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8557- DISPLAY ' GRAVOU PARAMETRO 40001052587 - CESTA NATAL.+ BONUS' */
            _.Display($" GRAVOU PARAMETRO 40001052587 - CESTA NATAL.+ BONUS");

            /*" -8558- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8559- DISPLAY ' TOTAL ANTERIOR     =' AC-CESTABONUS-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_CESTABONUS_ANT}");

            /*" -8560- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8561- DISPLAY ' TOTAL INCLUIDO     =' AC-CESTABONUS-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_CESTABONUS_INC}");

            /*" -8562- DISPLAY ' TOTAL EXCLUIDO     =' AC-CESTABONUS-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_CESTABONUS_EXC}");

            /*" -8563- DISPLAY ' TOTAL ALTERADO     =' AC-CESTABONUS-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_CESTABONUS_ALT}");

            /*" -8568- DISPLAY ' TOTAL ATUAL        =' AC-CESTABONUS-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_CESTABONUS_ATU}");

            /*" -8569- MOVE 40000527293 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527293, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8570- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8571- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8572- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8573- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8574- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8575- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8578- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8581- COMPUTE AC-MEDICOS-ATU = AC-MEDICOS-ANT + AC-MEDICOS-INC - AC-MEDICOS-EXC */
            WS_WORK_AREAS.AC_MEDICOS_ATU.Value = WS_WORK_AREAS.AC_MEDICOS_ANT + WS_WORK_AREAS.AC_MEDICOS_INC - WS_WORK_AREAS.AC_MEDICOS_EXC;

            /*" -8582- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8583- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8584- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8585- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8586- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8587- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8588- MOVE AC-MEDICOS-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8589- MOVE AC-MEDICOS-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8590- MOVE AC-MEDICOS-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8591- MOVE AC-MEDICOS-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8592- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8593- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8594- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8595- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8596- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8597- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8598- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8600- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8602- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8603- DISPLAY ' ' */
            _.Display($" ");

            /*" -8604- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8605- DISPLAY ' GRAVOU PARAMETRO 40000527293 - Desconto farmacia  ' */
            _.Display($" GRAVOU PARAMETRO 40000527293 - Desconto farmacia  ");

            /*" -8606- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8607- DISPLAY ' TOTAL ANTERIOR     =' AC-MEDICOS-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_MEDICOS_ANT}");

            /*" -8608- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8609- DISPLAY ' TOTAL INCLUIDO     =' AC-MEDICOS-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_MEDICOS_INC}");

            /*" -8610- DISPLAY ' TOTAL EXCLUIDO     =' AC-MEDICOS-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_MEDICOS_EXC}");

            /*" -8611- DISPLAY ' TOTAL ALTERADO     =' AC-MEDICOS-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_MEDICOS_ALT}");

            /*" -8616- DISPLAY ' TOTAL ATUAL        =' AC-MEDICOS-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_MEDICOS_ATU}");

            /*" -8617- MOVE 40000999981 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000999981, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8618- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8619- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8620- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8621- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8622- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8623- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8626- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8629- COMPUTE AC-CEPR-ATU = AC-CEPR-ANT + AC-CEPR-INC - AC-CEPR-EXC */
            WS_WORK_AREAS.AC_CEPR_ATU.Value = WS_WORK_AREAS.AC_CEPR_ANT + WS_WORK_AREAS.AC_CEPR_INC - WS_WORK_AREAS.AC_CEPR_EXC;

            /*" -8630- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8631- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8632- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8633- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8634- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8635- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8636- MOVE AC-CEPR-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_CEPR_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8637- MOVE AC-CEPR-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_CEPR_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8638- MOVE AC-CEPR-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_CEPR_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8639- MOVE AC-CEPR-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_CEPR_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8640- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8641- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8642- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8643- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8644- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8645- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8646- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8648- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8650- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8651- DISPLAY ' ' */
            _.Display($" ");

            /*" -8652- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8654- DISPLAY ' GRAVOU PARAMETRO 40000999981 - Servico reduc. prec' 'o em consultas e exames' */
            _.Display($" GRAVOU PARAMETRO 40000999981 - Servico reduc. preco em consultas e exames");

            /*" -8655- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8656- DISPLAY ' TOTAL ANTERIOR     =' AC-CEPR-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_CEPR_ANT}");

            /*" -8657- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8658- DISPLAY ' TOTAL INCLUIDO     =' AC-CEPR-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_CEPR_INC}");

            /*" -8659- DISPLAY ' TOTAL EXCLUIDO     =' AC-CEPR-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_CEPR_EXC}");

            /*" -8660- DISPLAY ' TOTAL ALTERADO     =' AC-CEPR-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_CEPR_ALT}");

            /*" -8665- DISPLAY ' TOTAL ATUAL        =' AC-CEPR-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_CEPR_ATU}");

            /*" -8666- MOVE 40000527273 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527273, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8667- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8668- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8669- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8670- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8671- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8672- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8675- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8678- COMPUTE AC-LAR-ATU = AC-LAR-ANT + AC-LAR-INC - AC-LAR-EXC */
            WS_WORK_AREAS.AC_LAR_ATU.Value = WS_WORK_AREAS.AC_LAR_ANT + WS_WORK_AREAS.AC_LAR_INC - WS_WORK_AREAS.AC_LAR_EXC;

            /*" -8679- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8680- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8681- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8682- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8683- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8684- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8685- MOVE AC-LAR-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_LAR_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8686- MOVE AC-LAR-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_LAR_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8687- MOVE AC-LAR-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_LAR_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8688- MOVE AC-LAR-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_LAR_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8689- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8690- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8691- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8692- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8693- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8694- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8695- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8697- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8699- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8700- DISPLAY ' ' */
            _.Display($" ");

            /*" -8701- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8702- DISPLAY ' GRAVOU PARAMETRO 40000527273 - Assist. Lar' */
            _.Display($" GRAVOU PARAMETRO 40000527273 - Assist. Lar");

            /*" -8703- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8704- DISPLAY ' TOTAL ANTERIOR     =' AC-LAR-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_LAR_ANT}");

            /*" -8705- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8706- DISPLAY ' TOTAL INCLUIDO     =' AC-LAR-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_LAR_INC}");

            /*" -8707- DISPLAY ' TOTAL EXCLUIDO     =' AC-LAR-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_LAR_EXC}");

            /*" -8708- DISPLAY ' TOTAL ALTERADO     =' AC-LAR-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_LAR_ALT}");

            /*" -8709- DISPLAY ' TOTAL ATUAL        =' AC-LAR-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_LAR_ATU}");

            /*" -8714- DISPLAY ' TOTAL AC-LAR-X     =' AC-LAR-X */
            _.Display($" TOTAL AC-LAR-X     ={WS_WORK_AREAS.AC_LAR_X}");

            /*" -8715- MOVE 40000527275 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527275, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8716- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8717- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8718- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8719- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8720- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8721- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8724- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8727- COMPUTE AC-RECPROF-ATU = AC-RECPROF-ANT + AC-RECPROF-INC - AC-RECPROF-EXC */
            WS_WORK_AREAS.AC_RECPROF_ATU.Value = WS_WORK_AREAS.AC_RECPROF_ANT + WS_WORK_AREAS.AC_RECPROF_INC - WS_WORK_AREAS.AC_RECPROF_EXC;

            /*" -8728- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8729- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8730- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8731- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8732- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8733- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8734- MOVE AC-RECPROF-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_RECPROF_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8735- MOVE AC-RECPROF-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_RECPROF_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8736- MOVE AC-RECPROF-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_RECPROF_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8737- MOVE AC-RECPROF-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_RECPROF_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8738- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8739- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8740- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8741- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8742- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8743- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8744- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8746- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8748- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8749- DISPLAY ' ' */
            _.Display($" ");

            /*" -8750- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8752- DISPLAY ' GRAVOU PARAMETRO 40000527275 - Assistencia Recoloc' 'acao profissional' */
            _.Display($" GRAVOU PARAMETRO 40000527275 - Assistencia Recolocacao profissional");

            /*" -8753- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8754- DISPLAY ' TOTAL ANTERIOR     =' AC-RECPROF-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_RECPROF_ANT}");

            /*" -8755- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8756- DISPLAY ' TOTAL INCLUIDO     =' AC-RECPROF-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_RECPROF_INC}");

            /*" -8757- DISPLAY ' TOTAL EXCLUIDO     =' AC-RECPROF-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_RECPROF_EXC}");

            /*" -8758- DISPLAY ' TOTAL ALTERADO     =' AC-RECPROF-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_RECPROF_ALT}");

            /*" -8763- DISPLAY ' TOTAL ATUAL        =' AC-RECPROF-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_RECPROF_ATU}");

            /*" -8764- MOVE 40000527277 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527277, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8765- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8766- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8767- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8768- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8769- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8770- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8773- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8776- COMPUTE AC-PET-ATU = AC-PET-ANT + AC-PET-INC - AC-PET-EXC */
            WS_WORK_AREAS.AC_PET_ATU.Value = WS_WORK_AREAS.AC_PET_ANT + WS_WORK_AREAS.AC_PET_INC - WS_WORK_AREAS.AC_PET_EXC;

            /*" -8777- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8778- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8779- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8780- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8781- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8782- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8783- MOVE AC-PET-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_PET_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8784- MOVE AC-PET-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_PET_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8785- MOVE AC-PET-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_PET_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8786- MOVE AC-PET-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_PET_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8787- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8788- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8789- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8790- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8791- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8792- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8793- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8795- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8797- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8798- DISPLAY ' ' */
            _.Display($" ");

            /*" -8799- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8800- DISPLAY ' GRAVOU PARAMETRO 40000527277 - Assistencia PET' */
            _.Display($" GRAVOU PARAMETRO 40000527277 - Assistencia PET");

            /*" -8801- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8802- DISPLAY ' TOTAL ANTERIOR     =' AC-PET-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_PET_ANT}");

            /*" -8803- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8804- DISPLAY ' TOTAL INCLUIDO     =' AC-PET-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_PET_INC}");

            /*" -8805- DISPLAY ' TOTAL EXCLUIDO     =' AC-PET-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_PET_EXC}");

            /*" -8806- DISPLAY ' TOTAL ALTERADO     =' AC-PET-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_PET_ALT}");

            /*" -8811- DISPLAY ' TOTAL ATUAL        =' AC-PET-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_PET_ATU}");

            /*" -8812- MOVE 40000527305 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527305, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8813- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8814- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8815- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8816- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8817- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8818- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8821- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8824- COMPUTE AC-HELPCEL-ATU = AC-HELPCEL-ANT + AC-HELPCEL-INC - AC-HELPCEL-EXC */
            WS_WORK_AREAS.AC_HELPCEL_ATU.Value = WS_WORK_AREAS.AC_HELPCEL_ANT + WS_WORK_AREAS.AC_HELPCEL_INC - WS_WORK_AREAS.AC_HELPCEL_EXC;

            /*" -8825- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8826- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8827- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8828- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8829- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8830- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8831- MOVE AC-HELPCEL-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8832- MOVE AC-HELPCEL-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8833- MOVE AC-HELPCEL-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8834- MOVE AC-HELPCEL-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8835- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8836- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8837- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8838- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8839- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8840- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8841- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8843- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8845- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8846- DISPLAY ' ' */
            _.Display($" ");

            /*" -8847- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8849- DISPLAY ' GRAVOU PARAMETRO 40000527305 - Assistencia Help De' 'sk para Smartphones' */
            _.Display($" GRAVOU PARAMETRO 40000527305 - Assistencia Help Desk para Smartphones");

            /*" -8850- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8851- DISPLAY ' TOTAL ANTERIOR     =' AC-HELPCEL-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_HELPCEL_ANT}");

            /*" -8852- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8853- DISPLAY ' TOTAL INCLUIDO     =' AC-HELPCEL-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_HELPCEL_INC}");

            /*" -8854- DISPLAY ' TOTAL EXCLUIDO     =' AC-HELPCEL-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_HELPCEL_EXC}");

            /*" -8855- DISPLAY ' TOTAL ALTERADO     =' AC-HELPCEL-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_HELPCEL_ALT}");

            /*" -8860- DISPLAY ' TOTAL ATUAL        =' AC-HELPCEL-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_HELPCEL_ATU}");

            /*" -8861- MOVE 40000527279 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527279, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8862- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8863- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8864- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8865- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8866- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8867- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8870- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8873- COMPUTE AC-GESTANT-ATU = AC-GESTANT-ANT + AC-GESTANT-INC - AC-GESTANT-EXC */
            WS_WORK_AREAS.AC_GESTANT_ATU.Value = WS_WORK_AREAS.AC_GESTANT_ANT + WS_WORK_AREAS.AC_GESTANT_INC - WS_WORK_AREAS.AC_GESTANT_EXC;

            /*" -8874- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8875- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8876- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8877- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8878- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8879- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8880- MOVE AC-GESTANT-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_GESTANT_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8881- MOVE AC-GESTANT-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_GESTANT_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8882- MOVE AC-GESTANT-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_GESTANT_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8883- MOVE AC-GESTANT-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_GESTANT_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8884- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8885- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8886- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8887- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8888- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8889- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8890- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8892- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8894- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8895- DISPLAY ' ' */
            _.Display($" ");

            /*" -8896- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8898- DISPLAY ' GRAVOU PARAMETRO 40000527279 - Assistencia gestant' 'e' */
            _.Display($" GRAVOU PARAMETRO 40000527279 - Assistencia gestante");

            /*" -8899- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8900- DISPLAY ' TOTAL ANTERIOR     =' AC-GESTANT-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_GESTANT_ANT}");

            /*" -8901- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8902- DISPLAY ' TOTAL INCLUIDO     =' AC-GESTANT-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_GESTANT_INC}");

            /*" -8903- DISPLAY ' TOTAL EXCLUIDO     =' AC-GESTANT-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_GESTANT_EXC}");

            /*" -8904- DISPLAY ' TOTAL ALTERADO     =' AC-GESTANT-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_GESTANT_ALT}");

            /*" -8909- DISPLAY ' TOTAL ATUAL        =' AC-GESTANT-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_GESTANT_ATU}");

            /*" -8910- MOVE 40000527281 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527281, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8911- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8912- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8913- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8914- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8915- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8916- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8919- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8922- COMPUTE AC-CNATAL-ATU = AC-CNATAL-ANT + AC-CNATAL-INC - AC-CNATAL-EXC */
            WS_WORK_AREAS.AC_CNATAL_ATU.Value = WS_WORK_AREAS.AC_CNATAL_ANT + WS_WORK_AREAS.AC_CNATAL_INC - WS_WORK_AREAS.AC_CNATAL_EXC;

            /*" -8923- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8924- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8925- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8926- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8927- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8928- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8929- MOVE AC-CNATAL-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_CNATAL_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8930- MOVE AC-CNATAL-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_CNATAL_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8931- MOVE AC-CNATAL-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_CNATAL_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8932- MOVE AC-CNATAL-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_CNATAL_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8933- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8934- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8935- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8936- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8937- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8938- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8939- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8941- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8943- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8944- DISPLAY ' ' */
            _.Display($" ");

            /*" -8945- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8946- DISPLAY ' GRAVOU PARAMETRO 40000527281 - Cartao natalidade  ' */
            _.Display($" GRAVOU PARAMETRO 40000527281 - Cartao natalidade  ");

            /*" -8947- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8948- DISPLAY ' TOTAL ANTERIOR     =' AC-CNATAL-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_CNATAL_ANT}");

            /*" -8949- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8950- DISPLAY ' TOTAL INCLUIDO     =' AC-CNATAL-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_CNATAL_INC}");

            /*" -8951- DISPLAY ' TOTAL EXCLUIDO     =' AC-CNATAL-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_CNATAL_EXC}");

            /*" -8952- DISPLAY ' TOTAL ALTERADO     =' AC-CNATAL-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_CNATAL_ALT}");

            /*" -8957- DISPLAY ' TOTAL ATUAL        =' AC-CNATAL-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_CNATAL_ATU}");

            /*" -8958- MOVE 40000527283 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527283, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8959- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -8960- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8961- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -8962- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -8963- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -8964- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8967- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -8970- COMPUTE AC-AUTOMOT-ATU = AC-AUTOMOT-ANT + AC-AUTOMOT-INC - AC-AUTOMOT-EXC */
            WS_WORK_AREAS.AC_AUTOMOT_ATU.Value = WS_WORK_AREAS.AC_AUTOMOT_ANT + WS_WORK_AREAS.AC_AUTOMOT_INC - WS_WORK_AREAS.AC_AUTOMOT_EXC;

            /*" -8971- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8972- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -8973- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8974- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8975- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -8976- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -8977- MOVE AC-AUTOMOT-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -8978- MOVE AC-AUTOMOT-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -8979- MOVE AC-AUTOMOT-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -8980- MOVE AC-AUTOMOT-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -8981- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -8982- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -8983- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -8984- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -8985- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -8986- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -8987- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -8989- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -8991- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -8992- DISPLAY ' ' */
            _.Display($" ");

            /*" -8993- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -8995- DISPLAY ' GRAVOU PARAMETRO 40000527283 - Assistencia automov' 'eis e motocicletas' */
            _.Display($" GRAVOU PARAMETRO 40000527283 - Assistencia automoveis e motocicletas");

            /*" -8996- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -8997- DISPLAY ' TOTAL ANTERIOR     =' AC-AUTOMOT-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_AUTOMOT_ANT}");

            /*" -8998- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -8999- DISPLAY ' TOTAL INCLUIDO     =' AC-AUTOMOT-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_AUTOMOT_INC}");

            /*" -9000- DISPLAY ' TOTAL EXCLUIDO     =' AC-AUTOMOT-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_AUTOMOT_EXC}");

            /*" -9001- DISPLAY ' TOTAL ALTERADO     =' AC-AUTOMOT-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_AUTOMOT_ALT}");

            /*" -9006- DISPLAY ' TOTAL ATUAL        =' AC-AUTOMOT-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_AUTOMOT_ATU}");

            /*" -9007- MOVE 40000527285 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527285, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -9008- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -9009- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -9010- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -9011- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -9012- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -9013- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -9016- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -9019- COMPUTE AC-BIKE-ATU = AC-BIKE-ANT + AC-BIKE-INC - AC-BIKE-EXC */
            WS_WORK_AREAS.AC_BIKE_ATU.Value = WS_WORK_AREAS.AC_BIKE_ANT + WS_WORK_AREAS.AC_BIKE_INC - WS_WORK_AREAS.AC_BIKE_EXC;

            /*" -9020- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -9021- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -9022- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -9023- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -9024- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -9025- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -9026- MOVE AC-BIKE-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_BIKE_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -9027- MOVE AC-BIKE-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_BIKE_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -9028- MOVE AC-BIKE-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_BIKE_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -9029- MOVE AC-BIKE-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_BIKE_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -9030- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -9031- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -9032- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -9033- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -9034- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -9035- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -9036- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -9038- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -9040- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -9041- DISPLAY ' ' */
            _.Display($" ");

            /*" -9042- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -9043- DISPLAY ' GRAVOU PARAMETRO 40000527285 - Assistencia Bike   ' */
            _.Display($" GRAVOU PARAMETRO 40000527285 - Assistencia Bike   ");

            /*" -9044- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -9045- DISPLAY ' TOTAL ANTERIOR     =' AC-BIKE-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_BIKE_ANT}");

            /*" -9046- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -9047- DISPLAY ' TOTAL INCLUIDO     =' AC-BIKE-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_BIKE_INC}");

            /*" -9048- DISPLAY ' TOTAL EXCLUIDO     =' AC-BIKE-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_BIKE_EXC}");

            /*" -9049- DISPLAY ' TOTAL ALTERADO     =' AC-BIKE-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_BIKE_ALT}");

            /*" -9054- DISPLAY ' TOTAL ATUAL        =' AC-BIKE-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_BIKE_ATU}");

            /*" -9055- MOVE 40000527287 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527287, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -9056- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -9057- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -9058- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -9059- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -9060- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -9061- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -9064- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -9067- COMPUTE AC-TELEMED-ATU = AC-TELEMED-ANT + AC-TELEMED-INC - AC-TELEMED-EXC */
            WS_WORK_AREAS.AC_TELEMED_ATU.Value = WS_WORK_AREAS.AC_TELEMED_ANT + WS_WORK_AREAS.AC_TELEMED_INC - WS_WORK_AREAS.AC_TELEMED_EXC;

            /*" -9068- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -9069- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -9070- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -9071- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -9072- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -9073- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -9074- MOVE AC-TELEMED-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_TELEMED_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -9075- MOVE AC-TELEMED-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_TELEMED_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -9076- MOVE AC-TELEMED-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_TELEMED_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -9077- MOVE AC-TELEMED-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_TELEMED_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -9078- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -9079- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -9080- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -9081- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -9082- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -9083- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -9084- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -9086- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -9088- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -9089- DISPLAY ' ' */
            _.Display($" ");

            /*" -9090- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -9092- DISPLAY ' GRAVOU PARAMETRO 40000527287 - Assistencia Telemed' 'icina' */
            _.Display($" GRAVOU PARAMETRO 40000527287 - Assistencia Telemedicina");

            /*" -9093- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -9094- DISPLAY ' TOTAL ANTERIOR     =' AC-TELEMED-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_TELEMED_ANT}");

            /*" -9095- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -9096- DISPLAY ' TOTAL INCLUIDO     =' AC-TELEMED-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_TELEMED_INC}");

            /*" -9097- DISPLAY ' TOTAL EXCLUIDO     =' AC-TELEMED-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_TELEMED_EXC}");

            /*" -9098- DISPLAY ' TOTAL ALTERADO     =' AC-TELEMED-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_TELEMED_ALT}");

            /*" -9099- DISPLAY ' TOTAL ATUAL        =' AC-TELEMED-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_TELEMED_ATU}");

            /*" -9104- DISPLAY ' TOTAL AC-TELEMED-X =' AC-TELEMED-X */
            _.Display($" TOTAL AC-TELEMED-X ={WS_WORK_AREAS.AC_TELEMED_X}");

            /*" -9105- MOVE 40000527307 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527307, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -9106- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -9107- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -9108- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -9109- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -9110- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -9111- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -9114- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -9117- COMPUTE AC-SENIOR-ATU = AC-SENIOR-ANT + AC-SENIOR-INC - AC-SENIOR-EXC */
            WS_WORK_AREAS.AC_SENIOR_ATU.Value = WS_WORK_AREAS.AC_SENIOR_ANT + WS_WORK_AREAS.AC_SENIOR_INC - WS_WORK_AREAS.AC_SENIOR_EXC;

            /*" -9118- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -9119- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -9120- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -9121- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -9122- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -9123- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -9124- MOVE AC-SENIOR-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_SENIOR_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -9125- MOVE AC-SENIOR-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_SENIOR_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -9126- MOVE AC-SENIOR-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_SENIOR_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -9127- MOVE AC-SENIOR-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_SENIOR_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -9128- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -9129- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -9130- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -9131- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -9132- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -9133- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -9134- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -9136- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -9138- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -9139- DISPLAY ' ' */
            _.Display($" ");

            /*" -9140- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -9141- DISPLAY ' GRAVOU PARAMETRO 40000527307 - Assistencia Senior ' */
            _.Display($" GRAVOU PARAMETRO 40000527307 - Assistencia Senior ");

            /*" -9142- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -9143- DISPLAY ' TOTAL ANTERIOR     =' AC-SENIOR-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_SENIOR_ANT}");

            /*" -9144- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -9145- DISPLAY ' TOTAL INCLUIDO     =' AC-SENIOR-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_SENIOR_INC}");

            /*" -9146- DISPLAY ' TOTAL EXCLUIDO     =' AC-SENIOR-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_SENIOR_EXC}");

            /*" -9147- DISPLAY ' TOTAL ALTERADO     =' AC-SENIOR-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_SENIOR_ALT}");

            /*" -9152- DISPLAY ' TOTAL ATUAL        =' AC-SENIOR-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_SENIOR_ATU}");

            /*" -9153- MOVE 40000527289 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000527289, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -9154- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -9155- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -9156- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -9157- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -9158- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -9159- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -9162- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -9165- COMPUTE AC-CNATALF-ATU = AC-CNATALF-ANT + AC-CNATALF-INC - AC-CNATALF-EXC */
            WS_WORK_AREAS.AC_CNATALF_ATU.Value = WS_WORK_AREAS.AC_CNATALF_ANT + WS_WORK_AREAS.AC_CNATALF_INC - WS_WORK_AREAS.AC_CNATALF_EXC;

            /*" -9166- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -9167- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -9168- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -9169- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -9170- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -9171- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -9172- MOVE AC-CNATALF-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_CNATALF_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -9173- MOVE AC-CNATALF-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_CNATALF_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -9174- MOVE AC-CNATALF-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_CNATALF_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -9175- MOVE AC-CNATALF-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_CNATALF_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -9176- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -9177- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -9178- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -9179- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -9180- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -9181- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -9182- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -9184- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -9186- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -9187- DISPLAY ' ' */
            _.Display($" ");

            /*" -9188- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -9190- DISPLAY ' GRAVOU PARAMETRO 40000527289 - Cartao natalidade (' 'funcionarios)' */
            _.Display($" GRAVOU PARAMETRO 40000527289 - Cartao natalidade (funcionarios)");

            /*" -9191- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -9192- DISPLAY ' TOTAL ANTERIOR     =' AC-CNATALF-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_CNATALF_ANT}");

            /*" -9193- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -9194- DISPLAY ' TOTAL INCLUIDO     =' AC-CNATALF-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_CNATALF_INC}");

            /*" -9195- DISPLAY ' TOTAL EXCLUIDO     =' AC-CNATALF-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_CNATALF_EXC}");

            /*" -9196- DISPLAY ' TOTAL ALTERADO     =' AC-CNATALF-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_CNATALF_ALT}");

            /*" -9202- DISPLAY ' TOTAL ATUAL        =' AC-CNATALF-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_CNATALF_ATU}");

            /*" -9203- MOVE 40000528999 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000528999, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -9204- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -9205- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -9206- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -9207- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -9208- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -9209- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -9212- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -9215- COMPUTE AC-AMBIENT-ATU = AC-AMBIENT-ANT + AC-AMBIENT-INC - AC-AMBIENT-EXC */
            WS_WORK_AREAS.AC_AMBIENT_ATU.Value = WS_WORK_AREAS.AC_AMBIENT_ANT + WS_WORK_AREAS.AC_AMBIENT_INC - WS_WORK_AREAS.AC_AMBIENT_EXC;

            /*" -9217- ADD 1 TO WS-SEQUENCIAL */
            WS_WORK_AREAS.WS_SEQUENCIAL.Value = WS_WORK_AREAS.WS_SEQUENCIAL + 1;

            /*" -9218- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -9219- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -9220- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -9221- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -9222- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -9223- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -9224- MOVE AC-AMBIENT-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -9225- MOVE AC-AMBIENT-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -9226- MOVE AC-AMBIENT-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -9227- MOVE AC-AMBIENT-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -9228- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -9229- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -9230- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -9231- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -9232- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -9233- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -9234- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -9236- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -9238- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -9239- DISPLAY ' ' */
            _.Display($" ");

            /*" -9240- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -9242- DISPLAY ' GRAVOU PARAMETRO 40000528999 - Assist. Ambiental (' 'ESG)' */
            _.Display($" GRAVOU PARAMETRO 40000528999 - Assist. Ambiental (ESG)");

            /*" -9243- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -9244- DISPLAY ' TOTAL ANTERIOR     =' AC-AMBIENT-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_AMBIENT_ANT}");

            /*" -9245- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -9246- DISPLAY ' TOTAL INCLUIDO     =' AC-AMBIENT-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_AMBIENT_INC}");

            /*" -9247- DISPLAY ' TOTAL EXCLUIDO     =' AC-AMBIENT-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_AMBIENT_EXC}");

            /*" -9248- DISPLAY ' TOTAL ALTERADO     =' AC-AMBIENT-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_AMBIENT_ALT}");

            /*" -9249- DISPLAY ' TOTAL ATUAL        =' AC-AMBIENT-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_AMBIENT_ATU}");

            /*" -9254- DISPLAY ' TOTAL AC-AMBIENT-X =' AC-AMBIENT-X */
            _.Display($" TOTAL AC-AMBIENT-X ={WS_WORK_AREAS.AC_AMBIENT_X}");

            /*" -9255- MOVE 40000529003 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000529003, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -9256- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -9257- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -9258- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -9259- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -9260- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -9261- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -9264- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -9267- COMPUTE AC-FINANCE-ATU = AC-FINANCE-ANT + AC-FINANCE-INC - AC-FINANCE-EXC */
            WS_WORK_AREAS.AC_FINANCE_ATU.Value = WS_WORK_AREAS.AC_FINANCE_ANT + WS_WORK_AREAS.AC_FINANCE_INC - WS_WORK_AREAS.AC_FINANCE_EXC;

            /*" -9269- ADD 1 TO WS-SEQUENCIAL */
            WS_WORK_AREAS.WS_SEQUENCIAL.Value = WS_WORK_AREAS.WS_SEQUENCIAL + 1;

            /*" -9270- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -9271- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -9272- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -9273- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -9274- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -9275- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -9276- MOVE AC-FINANCE-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_FINANCE_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -9277- MOVE AC-FINANCE-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_FINANCE_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -9278- MOVE AC-FINANCE-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_FINANCE_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -9279- MOVE AC-FINANCE-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_FINANCE_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -9280- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -9281- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -9282- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -9283- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -9284- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -9285- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -9286- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -9288- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -9290- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -9291- DISPLAY ' ' */
            _.Display($" ");

            /*" -9292- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -9294- DISPLAY ' GRAVOU PARAMETRO 40000529003 - ASSIST. ORIENT.FINA' 'NCEIRA - FINANCE' */
            _.Display($" GRAVOU PARAMETRO 40000529003 - ASSIST. ORIENT.FINANCEIRA - FINANCE");

            /*" -9295- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -9296- DISPLAY ' TOTAL ANTERIOR     =' AC-FINANCE-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_FINANCE_ANT}");

            /*" -9297- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -9298- DISPLAY ' TOTAL INCLUIDO     =' AC-FINANCE-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_FINANCE_INC}");

            /*" -9299- DISPLAY ' TOTAL EXCLUIDO     =' AC-FINANCE-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_FINANCE_EXC}");

            /*" -9300- DISPLAY ' TOTAL ALTERADO     =' AC-FINANCE-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_FINANCE_ALT}");

            /*" -9301- DISPLAY ' TOTAL ATUAL        =' AC-FINANCE-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_FINANCE_ATU}");

            /*" -9306- DISPLAY ' TOTAL AC-FINANCE-X =' AC-FINANCE-X */
            _.Display($" TOTAL AC-FINANCE-X ={WS_WORK_AREAS.AC_FINANCE_X}");

            /*" -9307- MOVE 40000529001 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000529001, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -9308- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -9309- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -9310- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -9311- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -9312- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -9313- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -9316- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -9319- COMPUTE AC-INVENTA-ATU = AC-INVENTA-ANT + AC-INVENTA-INC - AC-INVENTA-EXC */
            WS_WORK_AREAS.AC_INVENTA_ATU.Value = WS_WORK_AREAS.AC_INVENTA_ANT + WS_WORK_AREAS.AC_INVENTA_INC - WS_WORK_AREAS.AC_INVENTA_EXC;

            /*" -9321- ADD 1 TO WS-SEQUENCIAL */
            WS_WORK_AREAS.WS_SEQUENCIAL.Value = WS_WORK_AREAS.WS_SEQUENCIAL + 1;

            /*" -9322- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -9323- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -9324- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -9325- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -9326- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -9327- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -9328- MOVE AC-INVENTA-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_INVENTA_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -9329- MOVE AC-INVENTA-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_INVENTA_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -9330- MOVE AC-INVENTA-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_INVENTA_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -9331- MOVE AC-INVENTA-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_INVENTA_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -9332- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -9333- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -9334- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -9335- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -9336- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -9337- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -9338- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -9340- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -9342- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -9343- DISPLAY ' ' */
            _.Display($" ");

            /*" -9344- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -9346- DISPLAY ' GRAVOU PARAMETRO 40000529001 - ASSIST. INVENTARIO ' '- INVENTA' */
            _.Display($" GRAVOU PARAMETRO 40000529001 - ASSIST. INVENTARIO - INVENTA");

            /*" -9347- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -9348- DISPLAY ' TOTAL ANTERIOR     =' AC-INVENTA-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_INVENTA_ANT}");

            /*" -9349- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -9350- DISPLAY ' TOTAL INCLUIDO     =' AC-INVENTA-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_INVENTA_INC}");

            /*" -9351- DISPLAY ' TOTAL EXCLUIDO     =' AC-INVENTA-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_INVENTA_EXC}");

            /*" -9352- DISPLAY ' TOTAL ALTERADO     =' AC-INVENTA-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_INVENTA_ALT}");

            /*" -9353- DISPLAY ' TOTAL ATUAL        =' AC-INVENTA-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_INVENTA_ATU}");

            /*" -9358- DISPLAY ' TOTALAC-INVENTA-X  =' AC-INVENTA-X */
            _.Display($" TOTALAC-INVENTA-X  ={WS_WORK_AREAS.AC_INVENTA_X}");

            /*" -9359- MOVE 40000529005 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000529005, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -9360- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -9361- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -9362- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -9363- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -9364- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -9365- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -9368- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -9371- COMPUTE AC-VIAGELH-ATU = AC-VIAGELH-ANT + AC-VIAGELH-INC - AC-VIAGELH-EXC */
            WS_WORK_AREAS.AC_VIAGELH_ATU.Value = WS_WORK_AREAS.AC_VIAGELH_ANT + WS_WORK_AREAS.AC_VIAGELH_INC - WS_WORK_AREAS.AC_VIAGELH_EXC;

            /*" -9373- ADD 1 TO WS-SEQUENCIAL */
            WS_WORK_AREAS.WS_SEQUENCIAL.Value = WS_WORK_AREAS.WS_SEQUENCIAL + 1;

            /*" -9374- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -9375- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -9376- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -9377- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -9378- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -9379- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -9380- MOVE AC-VIAGELH-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -9381- MOVE AC-VIAGELH-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -9382- MOVE AC-VIAGELH-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -9383- MOVE AC-VIAGELH-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -9384- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -9385- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -9386- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -9387- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -9388- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -9389- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -9390- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -9392- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -9394- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -9395- DISPLAY ' ' */
            _.Display($" ");

            /*" -9396- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -9398- DISPLAY ' GRAVOU PARAMETRO 40000529005 - ASSIST.VIAGEM LAV+H' 'OS.PET - VIAGELH' */
            _.Display($" GRAVOU PARAMETRO 40000529005 - ASSIST.VIAGEM LAV+HOS.PET - VIAGELH");

            /*" -9399- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -9400- DISPLAY ' TOTAL ANTERIOR     =' AC-VIAGELH-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_VIAGELH_ANT}");

            /*" -9401- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -9402- DISPLAY ' TOTAL INCLUIDO     =' AC-VIAGELH-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_VIAGELH_INC}");

            /*" -9403- DISPLAY ' TOTAL EXCLUIDO     =' AC-VIAGELH-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_VIAGELH_EXC}");

            /*" -9404- DISPLAY ' TOTAL ALTERADO     =' AC-VIAGELH-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_VIAGELH_ALT}");

            /*" -9405- DISPLAY ' TOTAL ATUAL        =' AC-VIAGELH-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_VIAGELH_ATU}");

            /*" -9410- DISPLAY ' TOTAL AC-VIAGELH-X =' AC-VIAGELH-X */
            _.Display($" TOTAL AC-VIAGELH-X ={WS_WORK_AREAS.AC_VIAGELH_X}");

            /*" -9411- MOVE 40000529007 TO LTSOLPAR-COD-PRODUTO */
            _.Move(40000529007, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -9412- MOVE 0 TO LTSOLPAR-COD-CLIENTE */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE);

            /*" -9413- MOVE 'VA1476B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -9414- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -9415- MOVE 'VA1476B' TO LTSOLPAR-COD-USUARIO */
            _.Move("VA1476B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -9416- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -9417- MOVE '3' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("3", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -9420- MOVE SISTEMAS-DATA-MOV-ABERTO TO LTSOLPAR-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO);

            /*" -9423- COMPUTE AC-REPARO-ATU = AC-REPARO-ANT + AC-REPARO-INC - AC-REPARO-EXC */
            WS_WORK_AREAS.AC_REPARO_ATU.Value = WS_WORK_AREAS.AC_REPARO_ANT + WS_WORK_AREAS.AC_REPARO_INC - WS_WORK_AREAS.AC_REPARO_EXC;

            /*" -9425- ADD 1 TO WS-SEQUENCIAL */
            WS_WORK_AREAS.WS_SEQUENCIAL.Value = WS_WORK_AREAS.WS_SEQUENCIAL + 1;

            /*" -9426- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE01 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -9427- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -9428- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -9429- MOVE WS-SEQUENCIAL TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -9430- MOVE 0 TO LTSOLPAR-PARAM-SMINT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02);

            /*" -9431- MOVE 0 TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -9432- MOVE AC-REPARO-INC TO LTSOLPAR-PARAM-INTG01 */
            _.Move(WS_WORK_AREAS.AC_REPARO_INC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

            /*" -9433- MOVE AC-REPARO-EXC TO LTSOLPAR-PARAM-INTG02 */
            _.Move(WS_WORK_AREAS.AC_REPARO_EXC, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -9434- MOVE AC-REPARO-ALT TO LTSOLPAR-PARAM-INTG03 */
            _.Move(WS_WORK_AREAS.AC_REPARO_ALT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -9435- MOVE AC-REPARO-ATU TO LTSOLPAR-PARAM-DEC01 */
            _.Move(WS_WORK_AREAS.AC_REPARO_ATU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -9436- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -9437- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -9438- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -9439- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -9440- MOVE ' ' TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -9441- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -9442- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -9444- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

            /*" -9446- PERFORM R5600-00-INSERT-LT-SOLICITA */

            R5600_00_INSERT_LT_SOLICITA_SECTION();

            /*" -9447- DISPLAY ' ' */
            _.Display($" ");

            /*" -9448- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -9450- DISPLAY ' GRAVOU PARAMETRO 40000529007 - ASSIST.REPARO EQUIP' 'AMENTO - REPARO' */
            _.Display($" GRAVOU PARAMETRO 40000529007 - ASSIST.REPARO EQUIPAMENTO - REPARO");

            /*" -9451- DISPLAY ' DATA PROCESSAMENTO =' LTSOLPAR-DATA-SOLICITACAO */
            _.Display($" DATA PROCESSAMENTO ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO}");

            /*" -9452- DISPLAY ' TOTAL ANTERIOR     =' AC-REPARO-ANT */
            _.Display($" TOTAL ANTERIOR     ={WS_WORK_AREAS.AC_REPARO_ANT}");

            /*" -9453- DISPLAY ' SEQUENCIAL ATUAL   =' WS-SEQUENCIAL */
            _.Display($" SEQUENCIAL ATUAL   ={WS_WORK_AREAS.WS_SEQUENCIAL}");

            /*" -9454- DISPLAY ' TOTAL INCLUIDO     =' AC-REPARO-INC */
            _.Display($" TOTAL INCLUIDO     ={WS_WORK_AREAS.AC_REPARO_INC}");

            /*" -9455- DISPLAY ' TOTAL EXCLUIDO     =' AC-REPARO-EXC */
            _.Display($" TOTAL EXCLUIDO     ={WS_WORK_AREAS.AC_REPARO_EXC}");

            /*" -9456- DISPLAY ' TOTAL ALTERADO     =' AC-REPARO-ALT */
            _.Display($" TOTAL ALTERADO     ={WS_WORK_AREAS.AC_REPARO_ALT}");

            /*" -9457- DISPLAY ' TOTAL ATUAL        =' AC-REPARO-ATU */
            _.Display($" TOTAL ATUAL        ={WS_WORK_AREAS.AC_REPARO_ATU}");

            /*" -9557- DISPLAY ' TOTAL AC-REPARO-X  =' AC-REPARO-X */
            _.Display($" TOTAL AC-REPARO-X  ={WS_WORK_AREAS.AC_REPARO_X}");

            /*" -9558- PERFORM R7000-00-GRAVAR-HEADER */

            R7000_00_GRAVAR_HEADER_SECTION();

            /*" -9558- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5400_99_SAIDA*/

        [StopWatch]
        /*" R5500-00-GRAVAR-PROTOCOLO-SECTION */
        private void R5500_00_GRAVAR_PROTOCOLO_SECTION()
        {
            /*" -9568- MOVE 'R5500-00-GRAVAR-PROTOCOLO  ' TO PARAGRAFO */
            _.Move("R5500-00-GRAVAR-PROTOCOLO  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9574- MOVE 'GRAVAR PROTOCOLO      ' TO COMANDO */
            _.Move("GRAVAR PROTOCOLO      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9575- MOVE '  PROTOCOLO DE ENVIO DE CADASTRO ' TO REG-PVA1476B */
            _.Move("  PROTOCOLO DE ENVIO DE CADASTRO ", REG_PVA1476B);

            /*" -9576- MOVE '  PROTOCOLO DE ENVIO DE CADASTRO ' TO REG-P1476BHM */
            _.Move("  PROTOCOLO DE ENVIO DE CADASTRO ", REG_P1476BHM);

            /*" -9577- WRITE REG-PVA1476B . */
            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9578- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9579- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9581- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9582- WRITE REG-P1476BHM . */
            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9583- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9584- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9586- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9587- MOVE WS-DATA-H TO LD06-DATA-HOJE */
            _.Move(WS_WORK_AREAS.WS_DATA_H, AREA_CAB.LD06.LD06_DATA_HOJE);

            /*" -9588- WRITE REG-PVA1476B FROM LD06. */
            _.Move(AREA_CAB.LD06.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9589- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9591- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9592- WRITE REG-P1476BHM FROM LD06. */
            _.Move(AREA_CAB.LD06.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9593- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9596- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9597- MOVE '  � CAIXA ASSISTENCIA S.A.       ' TO REG-PVA1476B */
            _.Move("  � CAIXA ASSISTENCIA S.A.       ", REG_PVA1476B);

            /*" -9598- MOVE '  � HELLO MED.                   ' TO REG-P1476BHM */
            _.Move("  � HELLO MED.                   ", REG_P1476BHM);

            /*" -9599- WRITE REG-PVA1476B . */
            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9600- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9602- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9603- WRITE REG-P1476BHM . */
            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9604- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9606- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9608- MOVE '  AT.:DEPARTAMENTO DE INFORMATICA / CADADASTRO ' TO REG-PVA1476B */
            _.Move("  AT.:DEPARTAMENTO DE INFORMATICA / CADADASTRO ", REG_PVA1476B);

            /*" -9611- MOVE '  AT.:DEPARTAMENTO DE INFORMATICA / CADADASTRO ' TO REG-P1476BHM */
            _.Move("  AT.:DEPARTAMENTO DE INFORMATICA / CADADASTRO ", REG_P1476BHM);

            /*" -9612- WRITE REG-P1476BHM . */
            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9613- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9615- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9617- MOVE ' REFERENTE: ENVIO DE CADASTRO DE ASSOCIADOS DO PERIODO' TO REG-PVA1476B */
            _.Move(" REFERENTE: ENVIO DE CADASTRO DE ASSOCIADOS DO PERIODO", REG_PVA1476B);

            /*" -9619- MOVE ' REFERENTE: ENVIO DE CADASTRO DE ASSOCIADOS DO PERIODO' TO REG-P1476BHM */
            _.Move(" REFERENTE: ENVIO DE CADASTRO DE ASSOCIADOS DO PERIODO", REG_P1476BHM);

            /*" -9620- WRITE REG-PVA1476B . */
            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9621- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9623- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9624- WRITE REG-P1476BHM . */
            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9625- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9628- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9630- MOVE '  NOME DO CLIENTE: CAIXA VIDA E PREVIDENCIA' TO REG-PVA1476B */
            _.Move("  NOME DO CLIENTE: CAIXA VIDA E PREVIDENCIA", REG_PVA1476B);

            /*" -9632- MOVE '  NOME DO CLIENTE: CAIXA VIDA E PREVIDENCIA' TO REG-P1476BHM */
            _.Move("  NOME DO CLIENTE: CAIXA VIDA E PREVIDENCIA", REG_P1476BHM);

            /*" -9633- WRITE REG-PVA1476B . */
            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9634- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9636- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9637- WRITE REG-P1476BHM . */
            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9638- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9640- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9641- MOVE WS-DATA-H TO LD01-DATA-GERACAO */
            _.Move(WS_WORK_AREAS.WS_DATA_H, AREA_CAB.LD01.LD01_DATA_GERACAO);

            /*" -9642- MOVE WS-DATA-H TO LD01-DATA-ENVIO */
            _.Move(WS_WORK_AREAS.WS_DATA_H, AREA_CAB.LD01.LD01_DATA_ENVIO);

            /*" -9645- MOVE WS-SEQUENCIAL TO LD01-SEQUENCIAL */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, AREA_CAB.LD01.LD01_SEQUENCIAL);

            /*" -9647- MOVE WS-DATA-H TO LR00-DATA */
            _.Move(WS_WORK_AREAS.WS_DATA_H, AREA_CAB.LR00.LR00_DATA);

            /*" -9648- WRITE REG-RVA1476B FROM LR00. */
            _.Move(AREA_CAB.LR00.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9649- WRITE REG-R1476BHM FROM LR00. */
            _.Move(AREA_CAB.LR00.GetMoveValues(), REG_R1476BHM);

            R1476BHM.Write(REG_R1476BHM.GetMoveValues().ToString());

            /*" -9651- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9652- WRITE REG-RVA1476B FROM LR01. */
            _.Move(AREA_CAB.LR01.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9653- WRITE REG-R1476BHM FROM LR01. */
            _.Move(AREA_CAB.LR01.GetMoveValues(), REG_R1476BHM);

            R1476BHM.Write(REG_R1476BHM.GetMoveValues().ToString());

            /*" -9655- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9656- WRITE REG-PVA1476B FROM LD01. */
            _.Move(AREA_CAB.LD01.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9657- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9658- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9659- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9660- WRITE REG-PVA1476B FROM LC02. */
            _.Move(AREA_CAB.LC02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9662- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9663- WRITE REG-P1476BHM FROM LD01. */
            _.Move(AREA_CAB.LD01.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9664- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9665- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9666- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9667- WRITE REG-P1476BHM FROM LC02. */
            _.Move(AREA_CAB.LC02.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9672- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -9673- MOVE '40001262238' TO LD02-NUM-CONTRATO */
            _.Move("40001262238", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9674- MOVE AC-FARM-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_FARM_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9675- MOVE AC-FARM-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_FARM_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9676- MOVE AC-FARM-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_FARM_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9677- MOVE AC-FARM-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_FARM_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9678- MOVE AC-FARM-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_FARM_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9679- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9680- MOVE TB-COD-CONVENIO(2) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[2].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9681- MOVE TB-DES-CONVENIO(2) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[2].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9682- MOVE AC-FARM-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_FARM_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9683- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9684- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9685- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9686- MOVE TB-COD-CONVENIO(2) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[2].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9687- MOVE TB-DES-CONVENIO(2) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[2].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9688- MOVE AC-FARM-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_FARM_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9689- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9690- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9691- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9692- MOVE TB-COD-CONVENIO(2) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[2].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9693- MOVE TB-DES-CONVENIO(2) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[2].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9694- MOVE AC-FARM-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_FARM_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9695- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9696- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9700- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9701- MOVE '40000042589' TO LD02-NUM-CONTRATO */
            _.Move("40000042589", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9702- MOVE AC-EMPR-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_EMPR_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9703- MOVE AC-EMPR-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_EMPR_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9704- MOVE AC-EMPR-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_EMPR_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9705- MOVE AC-EMPR-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_EMPR_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9706- MOVE AC-EMPR-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_EMPR_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9707- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9708- MOVE TB-COD-CONVENIO(1) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[1].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9709- MOVE TB-DES-CONVENIO(1) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[1].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9710- MOVE AC-EMPR-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EMPR_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9711- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9712- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9713- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9714- MOVE TB-COD-CONVENIO(1) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[1].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9715- MOVE TB-DES-CONVENIO(1) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[1].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9716- MOVE AC-EMPR-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EMPR_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9717- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9718- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9719- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9720- MOVE TB-COD-CONVENIO(1) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[1].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9721- MOVE TB-DES-CONVENIO(1) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[1].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9722- MOVE AC-EMPR-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EMPR_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9723- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9724- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9728- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9729- MOVE '40001172590' TO LD02-NUM-CONTRATO */
            _.Move("40001172590", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9730- MOVE AC-EDUCA-ANT-U TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ANT_U, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9731- MOVE AC-EDUCA-INC-U TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_EDUCA_INC_U, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9732- MOVE AC-EDUCA-ALT-U TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ALT_U, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9733- MOVE AC-EDUCA-EXC-U TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_EDUCA_EXC_U, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9734- MOVE AC-EDUCA-ATU-U TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ATU_U, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9735- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9736- MOVE TB-COD-CONVENIO(9) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[9].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9737- MOVE TB-DES-CONVENIO(9) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[9].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9738- MOVE AC-EDUCA-INC-U TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EDUCA_INC_U, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9739- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9740- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9741- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9742- MOVE TB-COD-CONVENIO(9) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[9].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9743- MOVE TB-DES-CONVENIO(9) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[9].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9744- MOVE AC-EDUCA-ALT-U TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ALT_U, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9745- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9746- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9747- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9748- MOVE TB-COD-CONVENIO(9) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[9].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9749- MOVE TB-DES-CONVENIO(9) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[9].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9750- MOVE AC-EDUCA-EXC-U TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EDUCA_EXC_U, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9751- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9752- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9756- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9757- MOVE '40000042239' TO LD02-NUM-CONTRATO */
            _.Move("40000042239", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9758- MOVE AC-RESI-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_RESI_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9759- MOVE AC-RESI-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_RESI_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9760- MOVE AC-RESI-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_RESI_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9761- MOVE AC-RESI-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_RESI_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9762- MOVE AC-RESI-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_RESI_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9763- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9764- MOVE TB-COD-CONVENIO(3) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[3].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9765- MOVE TB-DES-CONVENIO(3) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[3].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9766- MOVE AC-RESI-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_RESI_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9767- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9768- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9769- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9770- MOVE TB-COD-CONVENIO(3) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[3].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9771- MOVE TB-DES-CONVENIO(3) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[3].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9772- MOVE AC-RESI-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_RESI_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9773- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9774- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9775- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9776- MOVE TB-COD-CONVENIO(3) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[3].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9777- MOVE TB-DES-CONVENIO(3) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[3].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9778- MOVE AC-RESI-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_RESI_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9779- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9780- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9784- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9785- MOVE '40001072240' TO LD02-NUM-CONTRATO */
            _.Move("40001072240", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9786- MOVE AC-VIAG-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_VIAG_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9787- MOVE AC-VIAG-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_VIAG_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9788- MOVE AC-VIAG-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_VIAG_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9789- MOVE AC-VIAG-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_VIAG_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9790- MOVE AC-VIAG-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_VIAG_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9791- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9792- MOVE TB-COD-CONVENIO(7) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[7].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9793- MOVE TB-DES-CONVENIO(7) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[7].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9794- MOVE AC-VIAG-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_VIAG_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9795- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9796- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9797- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9798- MOVE TB-COD-CONVENIO(7) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[7].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9799- MOVE TB-DES-CONVENIO(7) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[7].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9800- MOVE AC-VIAG-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_VIAG_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9801- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9802- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9803- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9804- MOVE TB-COD-CONVENIO(7) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[7].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9805- MOVE TB-DES-CONVENIO(7) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[7].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9806- MOVE AC-VIAG-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_VIAG_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9807- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9808- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9812- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9813- MOVE '40001102241' TO LD02-NUM-CONTRATO */
            _.Move("40001102241", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9814- MOVE AC-NUTR-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_NUTR_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9815- MOVE AC-NUTR-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_NUTR_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9816- MOVE AC-NUTR-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_NUTR_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9817- MOVE AC-NUTR-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_NUTR_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9818- MOVE AC-NUTR-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_NUTR_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9819- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9820- MOVE TB-COD-CONVENIO(4) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[4].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9821- MOVE TB-DES-CONVENIO(4) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[4].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9822- MOVE AC-NUTR-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_NUTR_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9823- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9824- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9825- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9826- MOVE TB-COD-CONVENIO(4) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[4].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9827- MOVE TB-DES-CONVENIO(4) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[4].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9828- MOVE AC-NUTR-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_NUTR_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9829- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9830- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9831- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9832- MOVE TB-COD-CONVENIO(4) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[4].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9833- MOVE TB-DES-CONVENIO(4) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[4].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9834- MOVE AC-NUTR-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_NUTR_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9835- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9836- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9840- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9841- MOVE '40001152343' TO LD02-NUM-CONTRATO */
            _.Move("40001152343", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9842- MOVE AC-RPROF-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_RPROF_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9843- MOVE AC-RPROF-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_RPROF_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9844- MOVE AC-RPROF-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_RPROF_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9845- MOVE AC-RPROF-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_RPROF_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9846- MOVE AC-RPROF-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_RPROF_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9847- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9848- MOVE TB-COD-CONVENIO(10) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[10].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9849- MOVE TB-DES-CONVENIO(10) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[10].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9850- MOVE AC-RPROF-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_RPROF_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9851- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9852- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9853- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9854- MOVE TB-COD-CONVENIO(10) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[10].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9855- MOVE TB-DES-CONVENIO(10) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[10].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9856- MOVE AC-RPROF-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_RPROF_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9857- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9858- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9859- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9860- MOVE TB-COD-CONVENIO(10) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[10].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9861- MOVE TB-DES-CONVENIO(10) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[10].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9862- MOVE AC-RPROF-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_RPROF_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9863- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9864- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9868- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9869- MOVE '40001172543' TO LD02-NUM-CONTRATO */
            _.Move("40001172543", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9870- MOVE AC-EDUCA-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9871- MOVE AC-EDUCA-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_EDUCA_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9872- MOVE AC-EDUCA-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9873- MOVE AC-EDUCA-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_EDUCA_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9874- MOVE AC-EDUCA-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9875- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9876- MOVE TB-COD-CONVENIO(8) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[8].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9877- MOVE TB-DES-CONVENIO(8) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[8].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9878- MOVE AC-EDUCA-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EDUCA_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9879- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9880- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9881- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9882- MOVE TB-COD-CONVENIO(8) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[8].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9883- MOVE TB-DES-CONVENIO(8) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[8].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9884- MOVE AC-EDUCA-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EDUCA_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9885- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9886- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9887- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9888- MOVE TB-COD-CONVENIO(8) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[8].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9889- MOVE TB-DES-CONVENIO(8) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[8].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9890- MOVE AC-EDUCA-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_EDUCA_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9891- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9892- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9896- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9897- MOVE '40000032503' TO LD02-NUM-CONTRATO */
            _.Move("40000032503", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9898- MOVE AC-HDESK-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_HDESK_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9899- MOVE AC-HDESK-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_HDESK_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9900- MOVE AC-HDESK-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_HDESK_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9901- MOVE AC-HDESK-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_HDESK_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9902- MOVE AC-HDESK-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_HDESK_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9903- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9904- MOVE TB-COD-CONVENIO(5) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[5].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9905- MOVE TB-DES-CONVENIO(5) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[5].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9906- MOVE AC-HDESK-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_HDESK_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9907- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9908- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9909- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9910- MOVE TB-COD-CONVENIO(5) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[5].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9911- MOVE TB-DES-CONVENIO(5) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[5].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9912- MOVE AC-HDESK-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_HDESK_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9913- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9914- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9915- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9916- MOVE TB-COD-CONVENIO(5) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[5].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9917- MOVE TB-DES-CONVENIO(5) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[5].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9918- MOVE AC-HDESK-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_HDESK_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9919- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9920- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9924- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9925- MOVE '40001112584' TO LD02-NUM-CONTRATO */
            _.Move("40001112584", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9926- MOVE AC-VIOL-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_VIOL_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -9927- MOVE AC-VIOL-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_VIOL_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -9928- MOVE AC-VIOL-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_VIOL_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -9929- MOVE AC-VIOL-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_VIOL_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -9930- MOVE AC-VIOL-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_VIOL_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -9932- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -9933- MOVE TB-COD-CONVENIO(6) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[6].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9934- MOVE TB-DES-CONVENIO(6) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[6].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9935- MOVE AC-VIOL-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_VIOL_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9936- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9937- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9938- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9939- MOVE TB-COD-CONVENIO(6) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[6].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9940- MOVE TB-DES-CONVENIO(6) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[6].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9941- MOVE AC-VIOL-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_VIOL_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9942- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9943- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9944- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9945- MOVE TB-COD-CONVENIO(6) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[6].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -9946- MOVE TB-DES-CONVENIO(6) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[6].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -9947- MOVE AC-VIOL-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_VIOL_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -9948- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -9949- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -9997- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -9998- MOVE '40000142324' TO LD02-NUM-CONTRATO */
            _.Move("40000142324", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -9999- MOVE AC-SAFES-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_SAFES_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10000- MOVE AC-SAFES-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_SAFES_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10001- MOVE AC-SAFES-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_SAFES_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10002- MOVE AC-SAFES-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_SAFES_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10003- MOVE AC-SAFES-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_SAFES_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10004- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10005- MOVE TB-COD-CONVENIO(12) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[12].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10006- MOVE TB-DES-CONVENIO(12) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[12].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10007- MOVE AC-SAFES-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_SAFES_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10008- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10009- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10010- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10011- MOVE TB-COD-CONVENIO(12) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[12].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10012- MOVE TB-DES-CONVENIO(12) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[12].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10013- MOVE AC-SAFES-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_SAFES_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10014- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10015- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10016- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10017- MOVE TB-COD-CONVENIO(12) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[12].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10018- MOVE TB-DES-CONVENIO(12) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[12].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10019- MOVE AC-SAFES-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_SAFES_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10020- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10021- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10025- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10026- MOVE '40000142242' TO LD02-NUM-CONTRATO */
            _.Move("40000142242", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10027- MOVE AC-CESBA-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_CESBA_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10028- MOVE AC-CESBA-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_CESBA_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10029- MOVE AC-CESBA-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_CESBA_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10030- MOVE AC-CESBA-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_CESBA_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10031- MOVE AC-CESBA-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_CESBA_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10032- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10033- MOVE TB-COD-CONVENIO(11) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[11].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10034- MOVE TB-DES-CONVENIO(11) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[11].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10035- MOVE AC-CESBA-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CESBA_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10036- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10037- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10038- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10039- MOVE TB-COD-CONVENIO(11) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[11].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10040- MOVE TB-DES-CONVENIO(11) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[11].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10041- MOVE AC-CESBA-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CESBA_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10042- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10043- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10044- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10045- MOVE TB-COD-CONVENIO(11) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[11].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10046- MOVE TB-DES-CONVENIO(11) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[11].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10047- MOVE AC-CESBA-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CESBA_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10048- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10049- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10053- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10054- MOVE '40001052587' TO LD02-NUM-CONTRATO */
            _.Move("40001052587", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10055- MOVE AC-CESTABONUS-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10056- MOVE AC-CESTABONUS-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10057- MOVE AC-CESTABONUS-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10058- MOVE AC-CESTABONUS-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10059- MOVE AC-CESTABONUS-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10061- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10062- MOVE TB-COD-CONVENIO(13) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[13].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10063- MOVE TB-DES-CONVENIO(13) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[13].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10064- MOVE AC-CESTABONUS-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10065- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10067- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10068- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10069- MOVE TB-COD-CONVENIO(13) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[13].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10070- MOVE TB-DES-CONVENIO(13) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[13].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10071- MOVE AC-CESTABONUS-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10072- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10074- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10075- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10076- MOVE TB-COD-CONVENIO(13) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[13].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10077- MOVE TB-DES-CONVENIO(13) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[13].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10078- MOVE AC-CESTABONUS-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CESTABONUS_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10079- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10080- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10084- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10085- MOVE '40000527293' TO LD02-NUM-CONTRATO */
            _.Move("40000527293", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10086- MOVE AC-MEDICOS-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10087- MOVE AC-MEDICOS-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10088- MOVE AC-MEDICOS-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10089- MOVE AC-MEDICOS-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10090- MOVE AC-MEDICOS-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10092- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10093- MOVE TB-COD-CONVENIO(14) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[14].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10094- MOVE TB-DES-CONVENIO(14) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[14].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10095- MOVE AC-MEDICOS-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10096- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10098- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10099- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10100- MOVE TB-COD-CONVENIO(14) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[14].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10101- MOVE TB-DES-CONVENIO(14) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[14].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10102- MOVE AC-MEDICOS-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10103- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10105- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10106- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10107- MOVE TB-COD-CONVENIO(14) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[14].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10108- MOVE TB-DES-CONVENIO(14) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[14].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10109- MOVE AC-MEDICOS-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_MEDICOS_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10110- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10111- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10115- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10116- MOVE '40000999981' TO LD02-NUM-CONTRATO */
            _.Move("40000999981", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10117- MOVE AC-CEPR-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_CEPR_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10118- MOVE AC-CEPR-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_CEPR_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10119- MOVE AC-CEPR-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_CEPR_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10120- MOVE AC-CEPR-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_CEPR_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10121- MOVE AC-CEPR-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_CEPR_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10123- WRITE REG-P1476BHM FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -10124- MOVE TB-COD-CONVENIO(15) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[15].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10125- MOVE TB-DES-CONVENIO(15) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[15].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10126- MOVE AC-CEPR-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CEPR_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10127- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10129- WRITE REG-R1476BHM FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_R1476BHM);

            R1476BHM.Write(REG_R1476BHM.GetMoveValues().ToString());

            /*" -10130- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10131- MOVE TB-COD-CONVENIO(15) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[15].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10132- MOVE TB-DES-CONVENIO(15) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[15].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10133- MOVE AC-CEPR-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CEPR_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10134- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10136- WRITE REG-R1476BHM FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_R1476BHM);

            R1476BHM.Write(REG_R1476BHM.GetMoveValues().ToString());

            /*" -10137- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10138- MOVE TB-COD-CONVENIO(15) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[15].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10139- MOVE TB-DES-CONVENIO(15) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[15].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10140- MOVE AC-CEPR-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CEPR_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10141- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10142- WRITE REG-R1476BHM FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_R1476BHM);

            R1476BHM.Write(REG_R1476BHM.GetMoveValues().ToString());

            /*" -10146- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10147- MOVE '40000527273' TO LD02-NUM-CONTRATO */
            _.Move("40000527273", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10148- MOVE AC-LAR-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_LAR_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10149- MOVE AC-LAR-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_LAR_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10150- MOVE AC-LAR-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_LAR_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10151- MOVE AC-LAR-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_LAR_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10152- MOVE AC-LAR-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_LAR_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10154- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10155- MOVE TB-COD-CONVENIO(16) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[16].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10156- MOVE TB-DES-CONVENIO(16) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[16].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10157- MOVE AC-LAR-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_LAR_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10158- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10160- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10161- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10162- MOVE TB-COD-CONVENIO(16) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[16].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10163- MOVE TB-DES-CONVENIO(16) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[16].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10164- MOVE AC-LAR-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_LAR_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10165- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10167- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10168- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10169- MOVE TB-COD-CONVENIO(16) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[16].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10170- MOVE TB-DES-CONVENIO(16) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[16].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10171- MOVE AC-LAR-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_LAR_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10172- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10173- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10177- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10178- MOVE '40000527275' TO LD02-NUM-CONTRATO */
            _.Move("40000527275", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10179- MOVE AC-RECPROF-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_RECPROF_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10180- MOVE AC-RECPROF-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_RECPROF_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10181- MOVE AC-RECPROF-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_RECPROF_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10182- MOVE AC-RECPROF-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_RECPROF_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10183- MOVE AC-RECPROF-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_RECPROF_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10185- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10186- MOVE TB-COD-CONVENIO(17) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[17].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10187- MOVE TB-DES-CONVENIO(17) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[17].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10188- MOVE AC-RECPROF-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_RECPROF_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10189- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10191- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10192- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10193- MOVE TB-COD-CONVENIO(17) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[17].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10194- MOVE TB-DES-CONVENIO(17) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[17].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10195- MOVE AC-RECPROF-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_RECPROF_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10196- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10198- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10199- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10200- MOVE TB-COD-CONVENIO(17) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[17].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10201- MOVE TB-DES-CONVENIO(17) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[17].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10202- MOVE AC-RECPROF-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_RECPROF_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10203- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10204- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10208- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10209- MOVE '40000527277' TO LD02-NUM-CONTRATO */
            _.Move("40000527277", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10210- MOVE AC-PET-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_PET_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10211- MOVE AC-PET-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_PET_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10212- MOVE AC-PET-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_PET_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10213- MOVE AC-PET-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_PET_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10214- MOVE AC-PET-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_PET_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10216- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10217- MOVE TB-COD-CONVENIO(18) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[18].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10218- MOVE TB-DES-CONVENIO(18) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[18].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10219- MOVE AC-PET-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_PET_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10220- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10222- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10223- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10224- MOVE TB-COD-CONVENIO(18) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[18].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10225- MOVE TB-DES-CONVENIO(18) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[18].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10226- MOVE AC-PET-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_PET_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10227- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10229- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10230- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10231- MOVE TB-COD-CONVENIO(18) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[18].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10232- MOVE TB-DES-CONVENIO(18) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[18].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10233- MOVE AC-PET-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_PET_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10234- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10235- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10239- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10240- MOVE '40000527305' TO LD02-NUM-CONTRATO */
            _.Move("40000527305", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10241- MOVE AC-HELPCEL-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10242- MOVE AC-HELPCEL-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10243- MOVE AC-HELPCEL-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10244- MOVE AC-HELPCEL-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10245- MOVE AC-HELPCEL-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10247- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10248- MOVE TB-COD-CONVENIO(19) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[19].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10249- MOVE TB-DES-CONVENIO(19) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[19].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10250- MOVE AC-HELPCEL-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10251- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10253- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10254- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10255- MOVE TB-COD-CONVENIO(19) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[19].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10256- MOVE TB-DES-CONVENIO(19) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[19].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10257- MOVE AC-HELPCEL-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10258- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10260- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10261- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10262- MOVE TB-COD-CONVENIO(19) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[19].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10263- MOVE TB-DES-CONVENIO(19) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[19].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10264- MOVE AC-HELPCEL-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_HELPCEL_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10265- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10266- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10270- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10271- MOVE '40000527279' TO LD02-NUM-CONTRATO */
            _.Move("40000527279", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10272- MOVE AC-GESTANT-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_GESTANT_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10273- MOVE AC-GESTANT-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_GESTANT_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10274- MOVE AC-GESTANT-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_GESTANT_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10275- MOVE AC-GESTANT-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_GESTANT_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10276- MOVE AC-GESTANT-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_GESTANT_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10278- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10279- MOVE TB-COD-CONVENIO(20) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[20].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10280- MOVE TB-DES-CONVENIO(20) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[20].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10281- MOVE AC-GESTANT-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_GESTANT_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10282- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10284- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10285- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10286- MOVE TB-COD-CONVENIO(20) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[20].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10287- MOVE TB-DES-CONVENIO(20) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[20].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10288- MOVE AC-GESTANT-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_GESTANT_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10289- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10291- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10292- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10293- MOVE TB-COD-CONVENIO(20) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[20].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10294- MOVE TB-DES-CONVENIO(20) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[20].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10295- MOVE AC-GESTANT-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_GESTANT_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10296- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10297- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10301- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10302- MOVE '40000527281' TO LD02-NUM-CONTRATO */
            _.Move("40000527281", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10303- MOVE AC-CNATAL-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_CNATAL_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10304- MOVE AC-CNATAL-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_CNATAL_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10305- MOVE AC-CNATAL-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_CNATAL_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10306- MOVE AC-CNATAL-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_CNATAL_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10307- MOVE AC-CNATAL-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_CNATAL_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10309- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10310- MOVE TB-COD-CONVENIO(21) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[21].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10311- MOVE TB-DES-CONVENIO(21) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[21].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10312- MOVE AC-CNATAL-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CNATAL_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10313- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10315- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10316- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10317- MOVE TB-COD-CONVENIO(21) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[21].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10318- MOVE TB-DES-CONVENIO(21) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[21].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10319- MOVE AC-CNATAL-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CNATAL_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10320- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10322- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10323- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10324- MOVE TB-COD-CONVENIO(21) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[21].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10325- MOVE TB-DES-CONVENIO(21) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[21].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10326- MOVE AC-CNATAL-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CNATAL_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10327- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10328- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10332- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10333- MOVE '40000527283' TO LD02-NUM-CONTRATO */
            _.Move("40000527283", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10334- MOVE AC-AUTOMOT-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10335- MOVE AC-AUTOMOT-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10336- MOVE AC-AUTOMOT-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10337- MOVE AC-AUTOMOT-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10338- MOVE AC-AUTOMOT-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10340- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10341- MOVE TB-COD-CONVENIO(22) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[22].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10342- MOVE TB-DES-CONVENIO(22) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[22].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10343- MOVE AC-AUTOMOT-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10344- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10346- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10347- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10348- MOVE TB-COD-CONVENIO(22) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[22].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10349- MOVE TB-DES-CONVENIO(22) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[22].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10350- MOVE AC-AUTOMOT-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10351- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10353- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10354- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10355- MOVE TB-COD-CONVENIO(22) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[22].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10356- MOVE TB-DES-CONVENIO(22) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[22].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10357- MOVE AC-AUTOMOT-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_AUTOMOT_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10358- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10359- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10363- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10364- MOVE '40000527285' TO LD02-NUM-CONTRATO */
            _.Move("40000527285", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10365- MOVE AC-BIKE-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_BIKE_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10366- MOVE AC-BIKE-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_BIKE_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10367- MOVE AC-BIKE-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_BIKE_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10368- MOVE AC-BIKE-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_BIKE_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10369- MOVE AC-BIKE-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_BIKE_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10371- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10372- MOVE TB-COD-CONVENIO(23) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[23].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10373- MOVE TB-DES-CONVENIO(23) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[23].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10374- MOVE AC-BIKE-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_BIKE_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10375- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10377- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10378- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10379- MOVE TB-COD-CONVENIO(23) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[23].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10380- MOVE TB-DES-CONVENIO(23) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[23].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10381- MOVE AC-BIKE-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_BIKE_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10382- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10384- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10385- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10386- MOVE TB-COD-CONVENIO(23) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[23].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10387- MOVE TB-DES-CONVENIO(23) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[23].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10388- MOVE AC-BIKE-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_BIKE_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10389- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10390- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10394- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10395- MOVE '40000527287' TO LD02-NUM-CONTRATO */
            _.Move("40000527287", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10396- MOVE AC-TELEMED-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_TELEMED_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10397- MOVE AC-TELEMED-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_TELEMED_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10398- MOVE AC-TELEMED-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_TELEMED_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10399- MOVE AC-TELEMED-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_TELEMED_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10400- MOVE AC-TELEMED-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_TELEMED_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10402- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10403- MOVE TB-COD-CONVENIO(24) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[24].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10404- MOVE TB-DES-CONVENIO(24) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[24].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10405- MOVE AC-TELEMED-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_TELEMED_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10406- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10408- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10409- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10410- MOVE TB-COD-CONVENIO(24) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[24].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10411- MOVE TB-DES-CONVENIO(24) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[24].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10412- MOVE AC-TELEMED-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_TELEMED_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10413- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10415- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10416- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10417- MOVE TB-COD-CONVENIO(24) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[24].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10418- MOVE TB-DES-CONVENIO(24) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[24].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10419- MOVE AC-TELEMED-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_TELEMED_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10420- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10421- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10425- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10426- MOVE '40000527307' TO LD02-NUM-CONTRATO */
            _.Move("40000527307", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10427- MOVE AC-SENIOR-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_SENIOR_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10428- MOVE AC-SENIOR-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_SENIOR_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10429- MOVE AC-SENIOR-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_SENIOR_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10430- MOVE AC-SENIOR-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_SENIOR_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10431- MOVE AC-SENIOR-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_SENIOR_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10433- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10434- MOVE TB-COD-CONVENIO(25) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[25].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10435- MOVE TB-DES-CONVENIO(25) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[25].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10436- MOVE AC-SENIOR-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_SENIOR_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10437- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10439- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10440- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10441- MOVE TB-COD-CONVENIO(25) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[25].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10442- MOVE TB-DES-CONVENIO(25) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[25].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10443- MOVE AC-SENIOR-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_SENIOR_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10444- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10446- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10447- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10448- MOVE TB-COD-CONVENIO(25) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[25].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10449- MOVE TB-DES-CONVENIO(25) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[25].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10450- MOVE AC-SENIOR-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_SENIOR_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10451- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10452- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10456- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10457- MOVE '40000527289' TO LD02-NUM-CONTRATO */
            _.Move("40000527289", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10458- MOVE AC-CNATALF-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_CNATALF_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10459- MOVE AC-CNATALF-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_CNATALF_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10460- MOVE AC-CNATALF-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_CNATALF_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10461- MOVE AC-CNATALF-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_CNATALF_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10462- MOVE AC-CNATALF-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_CNATALF_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10464- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10465- MOVE TB-COD-CONVENIO(26) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[26].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10466- MOVE TB-DES-CONVENIO(26) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[26].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10467- MOVE AC-CNATALF-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CNATALF_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10468- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10470- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10471- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10472- MOVE TB-COD-CONVENIO(26) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[26].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10473- MOVE TB-DES-CONVENIO(26) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[26].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10474- MOVE AC-CNATALF-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CNATALF_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10475- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10477- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10478- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10479- MOVE TB-COD-CONVENIO(26) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[26].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10480- MOVE TB-DES-CONVENIO(26) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[26].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10481- MOVE AC-CNATALF-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_CNATALF_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10482- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10483- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10488- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10489- MOVE '40000528999' TO LD02-NUM-CONTRATO */
            _.Move("40000528999", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10490- MOVE AC-AMBIENT-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10491- MOVE AC-AMBIENT-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10492- MOVE AC-AMBIENT-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10493- MOVE AC-AMBIENT-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10494- MOVE AC-AMBIENT-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10496- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10497- MOVE TB-COD-CONVENIO(28) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[28].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10498- MOVE TB-DES-CONVENIO(28) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[28].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10499- MOVE AC-AMBIENT-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10500- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10502- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10503- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10504- MOVE TB-COD-CONVENIO(28) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[28].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10505- MOVE TB-DES-CONVENIO(28) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[28].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10506- MOVE AC-AMBIENT-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10507- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10509- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10510- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10511- MOVE TB-COD-CONVENIO(28) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[28].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10512- MOVE TB-DES-CONVENIO(28) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[28].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10513- MOVE AC-AMBIENT-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_AMBIENT_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10514- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10515- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10519- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10520- MOVE '40000529003' TO LD02-NUM-CONTRATO */
            _.Move("40000529003", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10521- MOVE AC-FINANCE-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_FINANCE_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10522- MOVE AC-FINANCE-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_FINANCE_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10523- MOVE AC-FINANCE-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_FINANCE_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10524- MOVE AC-FINANCE-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_FINANCE_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10525- MOVE AC-FINANCE-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_FINANCE_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10527- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10528- MOVE TB-COD-CONVENIO(29) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[29].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10529- MOVE TB-DES-CONVENIO(29) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[29].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10530- MOVE AC-FINANCE-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_FINANCE_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10531- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10533- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10534- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10535- MOVE TB-COD-CONVENIO(29) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[29].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10536- MOVE TB-DES-CONVENIO(29) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[29].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10537- MOVE AC-FINANCE-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_FINANCE_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10538- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10540- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10541- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10542- MOVE TB-COD-CONVENIO(29) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[29].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10543- MOVE TB-DES-CONVENIO(29) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[29].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10544- MOVE AC-FINANCE-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_FINANCE_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10545- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10546- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10550- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10551- MOVE '40000529001' TO LD02-NUM-CONTRATO */
            _.Move("40000529001", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10552- MOVE AC-INVENTA-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_INVENTA_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10553- MOVE AC-INVENTA-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_INVENTA_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10554- MOVE AC-INVENTA-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_INVENTA_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10555- MOVE AC-INVENTA-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_INVENTA_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10556- MOVE AC-INVENTA-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_INVENTA_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10558- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10559- MOVE TB-COD-CONVENIO(30) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[30].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10560- MOVE TB-DES-CONVENIO(30) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[30].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10561- MOVE AC-INVENTA-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_INVENTA_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10562- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10564- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10565- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10566- MOVE TB-COD-CONVENIO(30) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[30].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10567- MOVE TB-DES-CONVENIO(30) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[30].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10568- MOVE AC-INVENTA-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_INVENTA_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10569- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10571- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10572- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10573- MOVE TB-COD-CONVENIO(30) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[30].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10574- MOVE TB-DES-CONVENIO(30) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[30].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10575- MOVE AC-INVENTA-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_INVENTA_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10576- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10577- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10581- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10582- MOVE '40000529005' TO LD02-NUM-CONTRATO */
            _.Move("40000529005", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10583- MOVE AC-VIAGELH-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10584- MOVE AC-VIAGELH-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10585- MOVE AC-VIAGELH-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10586- MOVE AC-VIAGELH-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10587- MOVE AC-VIAGELH-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10589- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10590- MOVE TB-COD-CONVENIO(31) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[31].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10591- MOVE TB-DES-CONVENIO(31) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[31].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10592- MOVE AC-VIAGELH-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10593- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10595- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10596- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10597- MOVE TB-COD-CONVENIO(31) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[31].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10598- MOVE TB-DES-CONVENIO(31) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[31].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10599- MOVE AC-VIAGELH-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10600- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10602- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10603- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10604- MOVE TB-COD-CONVENIO(31) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[31].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10605- MOVE TB-DES-CONVENIO(31) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[31].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10606- MOVE AC-VIAGELH-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_VIAGELH_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10607- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10608- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10612- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10613- MOVE '40000529007' TO LD02-NUM-CONTRATO */
            _.Move("40000529007", AREA_CAB.LD02.LD02_NUM_CONTRATO);

            /*" -10614- MOVE AC-REPARO-ANT TO LD02-TOTAL-ANT */
            _.Move(WS_WORK_AREAS.AC_REPARO_ANT, AREA_CAB.LD02.LD02_TOTAL_ANT);

            /*" -10615- MOVE AC-REPARO-INC TO LD02-TOTAL-INC */
            _.Move(WS_WORK_AREAS.AC_REPARO_INC, AREA_CAB.LD02.LD02_TOTAL_INC);

            /*" -10616- MOVE AC-REPARO-ALT TO LD02-TOTAL-ALT */
            _.Move(WS_WORK_AREAS.AC_REPARO_ALT, AREA_CAB.LD02.LD02_TOTAL_ALT);

            /*" -10617- MOVE AC-REPARO-EXC TO LD02-TOTAL-EXC */
            _.Move(WS_WORK_AREAS.AC_REPARO_EXC, AREA_CAB.LD02.LD02_TOTAL_EXC);

            /*" -10618- MOVE AC-REPARO-ATU TO LD02-TOTAL-ATU */
            _.Move(WS_WORK_AREAS.AC_REPARO_ATU, AREA_CAB.LD02.LD02_TOTAL_ATU);

            /*" -10620- WRITE REG-PVA1476B FROM LD02. */
            _.Move(AREA_CAB.LD02.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10621- MOVE TB-COD-CONVENIO(32) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[32].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10622- MOVE TB-DES-CONVENIO(32) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[32].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10623- MOVE AC-REPARO-INC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_REPARO_INC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10624- MOVE LT-INCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_INCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10626- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10627- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10628- MOVE TB-COD-CONVENIO(32) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[32].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10629- MOVE TB-DES-CONVENIO(32) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[32].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10630- MOVE AC-REPARO-ALT TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_REPARO_ALT, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10631- MOVE LT-ALTERACAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_ALTERACAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10633- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10634- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10635- MOVE TB-COD-CONVENIO(32) TO LR02-COD-CONVENIO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[32].TB_COD_CONVENIO, AREA_CAB.LR02.LR02_COD_CONVENIO);

            /*" -10636- MOVE TB-DES-CONVENIO(32) TO LR02-DESCRICAO */
            _.Move(WS_WORK_AREAS.TAB_CONVENIO_R.FILLER_36[32].TB_DES_CONVENIO, AREA_CAB.LR02.LR02_DESCRICAO);

            /*" -10637- MOVE AC-REPARO-EXC TO LR02-QUANTIDADE */
            _.Move(WS_WORK_AREAS.AC_REPARO_EXC, AREA_CAB.LR02.LR02_QUANTIDADE);

            /*" -10638- MOVE LT-EXCLUSAO TO LR02-TIPO */
            _.Move(WS_WORK_AREAS.LT_EXCLUSAO, AREA_CAB.LR02.LR02_TIPO);

            /*" -10639- WRITE REG-RVA1476B FROM LR02. */
            _.Move(AREA_CAB.LR02.GetMoveValues(), REG_RVA1476B);

            RVA1476B.Write(REG_RVA1476B.GetMoveValues().ToString());

            /*" -10706- ADD 1 TO AC-ASSIST */
            WS_WORK_AREAS.AC_ASSIST.Value = WS_WORK_AREAS.AC_ASSIST + 1;

            /*" -10707- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10708- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10709- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10710- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10712- WRITE REG-PVA1476B FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_PVA1476B);

            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10713- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -10714- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -10715- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -10716- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -10718- WRITE REG-P1476BHM FROM LC05 AFTER 1. */
            _.Move(AREA_CAB.LC05.GetMoveValues(), REG_P1476BHM);

            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

            /*" -10720- MOVE '  ASSINATURA:_______________________' TO REG-PVA1476B REG-P1476BHM */
            _.Move("  ASSINATURA:_______________________", REG_PVA1476B, REG_P1476BHM);

            /*" -10721- WRITE REG-PVA1476B . */
            PVA1476B.Write(REG_PVA1476B.GetMoveValues().ToString());

            /*" -10721- WRITE REG-P1476BHM . */
            P1476BHM.Write(REG_P1476BHM.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/

        [StopWatch]
        /*" R5600-00-INSERT-LT-SOLICITA-SECTION */
        private void R5600_00_INSERT_LT_SOLICITA_SECTION()
        {
            /*" -10731- MOVE 'R5600-00-INSERT PARAM      ' TO PARAGRAFO */
            _.Move("R5600-00-INSERT PARAM      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10734- MOVE 'INSERT LT-SOLICITA-PARAM' TO COMANDO */
            _.Move("INSERT LT-SOLICITA-PARAM", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10789- PERFORM R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1 */

            R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1();

            /*" -10792- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -10793- DISPLAY ' R0030-ERRO INSERT LT-SOLICITA_PARAM ' */
                _.Display($" R0030-ERRO INSERT LT-SOLICITA_PARAM ");

                /*" -10795- DISPLAY ' COD. PROGRAMA = ' LTSOLPAR-COD-PROGRAMA ' COD. PRODUTO = ' LTSOLPAR-COD-PRODUTO */

                $" COD. PROGRAMA = {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA} COD. PRODUTO = {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO}"
                .Display();

                /*" -10796- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -10797- END-IF */
            }


            /*" -10798- . */

        }

        [StopWatch]
        /*" R5600-00-INSERT-LT-SOLICITA-DB-INSERT-1 */
        public void R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1()
        {
            /*" -10789- EXEC SQL INSERT INTO SEGUROS.LT_SOLICITA_PARAM (COD_PRODUTO , COD_CLIENTE , COD_PROGRAMA , TIPO_SOLICITACAO, DATA_SOLICITACAO, COD_USUARIO , DATA_PREV_PROC , SIT_SOLICITACAO , TSTMP_SITUACAO , PARAM_DATE01 , PARAM_DATE02 , PARAM_DATE03 , PARAM_SMINT01 , PARAM_SMINT02 , PARAM_SMINT03 , PARAM_INTG01 , PARAM_INTG02 , PARAM_INTG03 , PARAM_DEC01 , PARAM_DEC02 , PARAM_DEC03 , PARAM_FLOAT01 , PARAM_FLOAT02 , PARAM_CHAR01 , PARAM_CHAR02 , PARAM_CHAR03 , PARAM_CHAR04) VALUES (:LTSOLPAR-COD-PRODUTO , :LTSOLPAR-COD-CLIENTE , :LTSOLPAR-COD-PROGRAMA , :LTSOLPAR-TIPO-SOLICITACAO , :LTSOLPAR-DATA-SOLICITACAO , :LTSOLPAR-COD-USUARIO , :LTSOLPAR-DATA-PREV-PROC , :LTSOLPAR-SIT-SOLICITACAO , CURRENT TIMESTAMP , :LTSOLPAR-PARAM-DATE01 , :LTSOLPAR-PARAM-DATE02 , :LTSOLPAR-PARAM-DATE03 , :LTSOLPAR-PARAM-SMINT01 , :LTSOLPAR-PARAM-SMINT02 , :LTSOLPAR-PARAM-SMINT03 , :LTSOLPAR-PARAM-INTG01 , :LTSOLPAR-PARAM-INTG02 , :LTSOLPAR-PARAM-INTG03 , :LTSOLPAR-PARAM-DEC01 , :LTSOLPAR-PARAM-DEC02 , :LTSOLPAR-PARAM-DEC03 , :LTSOLPAR-PARAM-FLOAT01 , :LTSOLPAR-PARAM-FLOAT02 , :LTSOLPAR-PARAM-CHAR01 , :LTSOLPAR-PARAM-CHAR02 , :LTSOLPAR-PARAM-CHAR03 , :LTSOLPAR-PARAM-CHAR03) END-EXEC. */

            var r5600_00_INSERT_LT_SOLICITA_DB_INSERT_1_Insert1 = new R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1_Insert1()
            {
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
                LTSOLPAR_COD_CLIENTE = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_TIPO_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO.ToString(),
                LTSOLPAR_DATA_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO.ToString(),
                LTSOLPAR_COD_USUARIO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO.ToString(),
                LTSOLPAR_DATA_PREV_PROC = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC.ToString(),
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_DATE01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.ToString(),
                LTSOLPAR_PARAM_DATE02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02.ToString(),
                LTSOLPAR_PARAM_DATE03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_PARAM_SMINT02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02.ToString(),
                LTSOLPAR_PARAM_SMINT03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03.ToString(),
                LTSOLPAR_PARAM_INTG01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01.ToString(),
                LTSOLPAR_PARAM_INTG02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02.ToString(),
                LTSOLPAR_PARAM_INTG03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03.ToString(),
                LTSOLPAR_PARAM_DEC01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01.ToString(),
                LTSOLPAR_PARAM_DEC02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02.ToString(),
                LTSOLPAR_PARAM_DEC03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03.ToString(),
                LTSOLPAR_PARAM_FLOAT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01.ToString(),
                LTSOLPAR_PARAM_FLOAT02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02.ToString(),
                LTSOLPAR_PARAM_CHAR01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01.ToString(),
                LTSOLPAR_PARAM_CHAR02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02.ToString(),
                LTSOLPAR_PARAM_CHAR03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03.ToString(),
            };

            R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1_Insert1.Execute(r5600_00_INSERT_LT_SOLICITA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5600_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-GRAVAR-HEADER-SECTION */
        private void R7000_00_GRAVAR_HEADER_SECTION()
        {
            /*" -10807- MOVE 'R7000-00-GRAVAR-HEADER     ' TO PARAGRAFO */
            _.Move("R7000-00-GRAVAR-HEADER     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10809- MOVE 'GRAVAR HEADER         ' TO COMANDO */
            _.Move("GRAVAR HEADER         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10813- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10815- MOVE WS-SEQUENCIAL TO HE-SEQUENCIAL */
            _.Move(WS_WORK_AREAS.WS_SEQUENCIAL, HEADER_RECORD.HE_SEQUENCIAL);

            /*" -10817- MOVE 100037 TO HE-COD-CLIENTE */
            _.Move(100037, HEADER_RECORD.HE_COD_CLIENTE);

            /*" -10819- MOVE WS-TOTAL-INC TO HE-INCLUSOES */
            _.Move(WS_WORK_AREAS.WS_TOTAL_INC, HEADER_RECORD.HE_INCLUSOES);

            /*" -10821- MOVE WS-TOTAL-ALT TO HE-ALTERACOES */
            _.Move(WS_WORK_AREAS.WS_TOTAL_ALT, HEADER_RECORD.HE_ALTERACOES);

            /*" -10823- MOVE WS-TOTAL-EXC TO HE-EXCLUSOES */
            _.Move(WS_WORK_AREAS.WS_TOTAL_EXC, HEADER_RECORD.HE_EXCLUSOES);

            /*" -10825- MOVE WS-TOTAL-GRAVADOS TO HE-TOTAL-REG */
            _.Move(WS_WORK_AREAS.WS_TOTAL_GRAVADOS, HEADER_RECORD.HE_TOTAL_REG);

            /*" -10827- WRITE REG-MVA1476B FROM HEADER-RECORD. */
            _.Move(HEADER_RECORD.GetMoveValues(), REG_MVA1476B);

            MVA1476B.Write(REG_MVA1476B.GetMoveValues().ToString());

            /*" -10828- ADD 1 TO WS-TOTAL-GRAVADOS */
            WS_WORK_AREAS.WS_TOTAL_GRAVADOS.Value = WS_WORK_AREAS.WS_TOTAL_GRAVADOS + 1;

            /*" -10828- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -10838- MOVE 'R9000-00-FINALIZA          ' TO PARAGRAFO */
            _.Move("R9000-00-FINALIZA          ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10840- MOVE 'FINALIZA              ' TO COMANDO */
            _.Move("FINALIZA              ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10844- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10845- PERFORM R5300-00-UPDATE-PARAM */

            R5300_00_UPDATE_PARAM_SECTION();

            /*" -10846- PERFORM R5400-00-INSERT-PARAM */

            R5400_00_INSERT_PARAM_SECTION();

            /*" -10847- PERFORM R5500-00-GRAVAR-PROTOCOLO */

            R5500_00_GRAVAR_PROTOCOLO_SECTION();

            /*" -10849- PERFORM R0300-00-UPDATE-RELATORI */

            R0300_00_UPDATE_RELATORI_SECTION();

            /*" -10850- CLOSE MVA1476B. */
            MVA1476B.Close();

            /*" -10851- CLOSE PVA1476B. */
            PVA1476B.Close();

            /*" -10853- CLOSE RVA1476B. */
            RVA1476B.Close();

            /*" -10854- CLOSE M1476BHM. */
            M1476BHM.Close();

            /*" -10855- CLOSE P1476BHM. */
            P1476BHM.Close();

            /*" -10857- CLOSE R1476BHM. */
            R1476BHM.Close();

            /*" -10858- DISPLAY ' ' . */
            _.Display($" ");

            /*" -10859- DISPLAY 'LIDOS ................. ' WS-TOTAL-LIDOS */
            _.Display($"LIDOS ................. {WS_WORK_AREAS.WS_TOTAL_LIDOS}");

            /*" -10860- DISPLAY ' ' */
            _.Display($" ");

            /*" -10861- DISPLAY 'INCLUIDOS ............. ' WS-TOTAL-INC */
            _.Display($"INCLUIDOS ............. {WS_WORK_AREAS.WS_TOTAL_INC}");

            /*" -10862- DISPLAY 'ALTERADOS ............. ' WS-TOTAL-ALT */
            _.Display($"ALTERADOS ............. {WS_WORK_AREAS.WS_TOTAL_ALT}");

            /*" -10863- DISPLAY 'EXCLUIDOS ............. ' WS-TOTAL-EXC */
            _.Display($"EXCLUIDOS ............. {WS_WORK_AREAS.WS_TOTAL_EXC}");

            /*" -10864- DISPLAY 'OUTROS (?)............. ' WS-TOTAL-X */
            _.Display($"OUTROS (?)............. {WS_WORK_AREAS.WS_TOTAL_X}");

            /*" -10865- DISPLAY 'GRAVADOS NO ARQ RESUMO. ' AC-ASSIST */
            _.Display($"GRAVADOS NO ARQ RESUMO. {WS_WORK_AREAS.AC_ASSIST}");

            /*" -10866- DISPLAY ' ' */
            _.Display($" ");

            /*" -10867- DISPLAY 'PROD     QTDE' */
            _.Display($"PROD     QTDE");

            /*" -10868- DISPLAY '---- --------' */
            _.Display($"---- --------");

            /*" -10869- DISPLAY WS-TOTAL-0917 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_0917);

            /*" -10870- IF JVPRD8203 NOT = 0 */

            if (JVBKINCL.JV_PRODUTOS.JVPRD8203 != 0)
            {

                /*" -10871- MOVE JVPRD8203 TO WS-DESC-8203 */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD8203, WS_WORK_AREAS.WS_TOTAL_8203.WS_DESC_8203);

                /*" -10872- END-IF. */
            }


            /*" -10873- DISPLAY WS-TOTAL-8203 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_8203);

            /*" -10874- DISPLAY WS-TOTAL-9307 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9307);

            /*" -10875- IF JVPRD9311 NOT = 0 */

            if (JVBKINCL.JV_PRODUTOS.JVPRD9311 != 0)
            {

                /*" -10876- MOVE JVPRD9311 TO WS-DESC-9311 */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD9311, WS_WORK_AREAS.WS_TOTAL_9311.WS_DESC_9311);

                /*" -10877- END-IF. */
            }


            /*" -10878- DISPLAY WS-TOTAL-9311 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9311);

            /*" -10879- IF JVPRD9320 NOT = 0 */

            if (JVBKINCL.JV_PRODUTOS.JVPRD9320 != 0)
            {

                /*" -10880- MOVE JVPRD9320 TO WS-DESC-9320 */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD9320, WS_WORK_AREAS.WS_TOTAL_9320.WS_DESC_9320);

                /*" -10881- END-IF. */
            }


            /*" -10882- DISPLAY WS-TOTAL-9320 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9320);

            /*" -10883- IF JVPRD9321 NOT = 0 */

            if (JVBKINCL.JV_PRODUTOS.JVPRD9321 != 0)
            {

                /*" -10884- MOVE JVPRD9321 TO WS-DESC-9321 */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD9321, WS_WORK_AREAS.WS_TOTAL_9321.WS_DESC_9321);

                /*" -10885- END-IF. */
            }


            /*" -10886- DISPLAY WS-TOTAL-9321 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9321);

            /*" -10887- IF JVPRD9332 NOT = 0 */

            if (JVBKINCL.JV_PRODUTOS.JVPRD9332 != 0)
            {

                /*" -10888- MOVE JVPRD9332 TO WS-DESC-9332 */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD9332, WS_WORK_AREAS.WS_TOTAL_9332.WS_DESC_9332);

                /*" -10889- END-IF. */
            }


            /*" -10890- DISPLAY WS-TOTAL-9332 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9332);

            /*" -10891- DISPLAY WS-TOTAL-9703 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9703);

            /*" -10892- IF JVPRD9314 NOT = 0 */

            if (JVBKINCL.JV_PRODUTOS.JVPRD9314 != 0)
            {

                /*" -10893- MOVE JVPRD9314 TO WS-DESC-9314 */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD9314, WS_WORK_AREAS.WS_TOTAL_9314.WS_DESC_9314);

                /*" -10894- END-IF. */
            }


            /*" -10895- DISPLAY WS-TOTAL-9314 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9314);

            /*" -10896- IF JVPRD9327 NOT = 0 */

            if (JVBKINCL.JV_PRODUTOS.JVPRD9327 != 0)
            {

                /*" -10897- MOVE JVPRD9327 TO WS-DESC-9327 */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD9327, WS_WORK_AREAS.WS_TOTAL_9327.WS_DESC_9327);

                /*" -10898- END-IF. */
            }


            /*" -10899- DISPLAY WS-TOTAL-9327 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9327);

            /*" -10900- IF JVPRD9334 NOT = 0 */

            if (JVBKINCL.JV_PRODUTOS.JVPRD9334 != 0)
            {

                /*" -10901- MOVE JVPRD9334 TO WS-DESC-9334 */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD9334, WS_WORK_AREAS.WS_TOTAL_9334.WS_DESC_9334);

                /*" -10902- END-IF. */
            }


            /*" -10903- DISPLAY WS-TOTAL-9334 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9334);

            /*" -10904- IF JVPRD9329 NOT = 0 */

            if (JVBKINCL.JV_PRODUTOS.JVPRD9329 != 0)
            {

                /*" -10905- MOVE JVPRD9329 TO WS-DESC-9329 */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD9329, WS_WORK_AREAS.WS_TOTAL_9329.WS_DESC_9329);

                /*" -10906- END-IF. */
            }


            /*" -10907- DISPLAY WS-TOTAL-9329 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9329);

            /*" -10908- DISPLAY WS-TOTAL-8241 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_8241);

            /*" -10909- DISPLAY WS-TOTAL-8242 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_8242);

            /*" -10910- DISPLAY WS-TOTAL-9381 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9381);

            /*" -10911- DISPLAY WS-TOTAL-9382 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9382);

            /*" -10912- DISPLAY WS-TOTAL-9750 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9750);

            /*" -10913- DISPLAY WS-TOTAL-9751 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9751);

            /*" -10914- DISPLAY WS-TOTAL-9752 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9752);

            /*" -10915- DISPLAY WS-TOTAL-8530 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_8530);

            /*" -10916- DISPLAY WS-TOTAL-8531 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_8531);

            /*" -10917- DISPLAY WS-TOTAL-8532 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_8532);

            /*" -10918- DISPLAY WS-TOTAL-9999 */
            _.Display(WS_WORK_AREAS.WS_TOTAL_9999);

            /*" -10919- DISPLAY '-------------' */
            _.Display($"-------------");

            /*" -10921- DISPLAY ' ' . */
            _.Display($" ");

            /*" -10923- DISPLAY '*** VA1476B *** TERMINO NORMAL' */
            _.Display($"*** VA1476B *** TERMINO NORMAL");

            /*" -10925- MOVE '9000-FINALIZA' TO PARAGRAFO */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10926- IF WPAR-SIMULACAO = 'SIM' */

            if (WPAR_PARAMETROS.WPAR_SIMULACAO == "SIM")
            {

                /*" -10928- MOVE 'ROLLBACK' TO COMANDO */
                _.Move("ROLLBACK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -10928- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -10930- DISPLAY ' ' */
                _.Display($" ");

                /*" -10932- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -10933- DISPLAY 'PARAMETRO DE SIMULACAO LIGADO' */
                _.Display($"PARAMETRO DE SIMULACAO LIGADO");

                /*" -10934- DISPLAY 'ROLLBACK EXECUTADO' */
                _.Display($"ROLLBACK EXECUTADO");

                /*" -10936- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -10937- DISPLAY ' ' */
                _.Display($" ");

                /*" -10938- ELSE */
            }
            else
            {


                /*" -10939- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -10939- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -10941- DISPLAY ' ' */
                _.Display($" ");

                /*" -10943- DISPLAY '------------------------------------------------' '------------' */
                _.Display($"------------------------------------------------------------");

                /*" -10944- DISPLAY 'COMMIT EXECUTADO' */
                _.Display($"COMMIT EXECUTADO");

                /*" -10946- DISPLAY '------------------------------------------------' '------------' */
                _.Display($"------------------------------------------------------------");

                /*" -10947- DISPLAY ' ' */
                _.Display($" ");

                /*" -10948- END-IF */
            }


            /*" -10948- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_00_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -10957- CLOSE MVA1476B. */
            MVA1476B.Close();

            /*" -10958- CLOSE PVA1476B. */
            PVA1476B.Close();

            /*" -10959- CLOSE RVA1476B. */
            RVA1476B.Close();

            /*" -10960- CLOSE M1476BHM. */
            M1476BHM.Close();

            /*" -10961- CLOSE P1476BHM. */
            P1476BHM.Close();

            /*" -10963- CLOSE R1476BHM. */
            R1476BHM.Close();

            /*" -10964- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.FILLER_69.WSQLCODE);

            /*" -10965- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WABEND.FILLER_69.WSQLERRD1);

            /*" -10966- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WABEND.FILLER_69.WSQLERRD2);

            /*" -10967- MOVE SQLCODE TO WSQLCODE3 */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -10969- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -10971- DISPLAY '*** VA1476B *** ROLLBACK EM ANDAMENTO ...' */
            _.Display($"*** VA1476B *** ROLLBACK EM ANDAMENTO ...");

            /*" -10971- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -10974- MOVE 'R9999-00-ROT-ERRO' TO PARAGRAFO */
            _.Move("R9999-00-ROT-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -10975- MOVE 'ROLLBACK WORK' TO COMANDO */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -10975- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -10978- DISPLAY ' ' */
            _.Display($" ");

            /*" -10979- DISPLAY ' ' */
            _.Display($" ");

            /*" -10981- DISPLAY '*** VA1476B *** ERRO DE EXECUCAO' */
            _.Display($"*** VA1476B *** ERRO DE EXECUCAO");

            /*" -10982- MOVE 9 TO RETURN-CODE */
            _.Move(9, RETURN_CODE);

            /*" -10983- STOP RUN */

            throw new GoBack();   // => STOP RUN.

            /*" -10983- . */

        }
    }
}