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
using Sias.VidaEmGrupo.DB2.VP0437B;

namespace Code
{
    public class VP0437B
    {
        public bool IsCall { get; set; }

        public VP0437B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *  EMITE CERTIFICADOS DAS APOLICES PESSOA FISICA NO PADRAO FAC.  *      */
        /*"      *                                                                *      */
        /*"      *  COLUNAS SETADAS NA TABELA V0RELATORIOS:                       *      */
        /*"      *                                                                *      */
        /*"      *  OPERACAO = 2 (INDICA A EMISSAO DE CERTIFICADO)                *      */
        /*"      *  NRPARCEL = 2 (INDICA O ENVIO PARA O SEGURADO)                 *      */
        /*"JV139 *-----------------------------------------------------------------      */
        /*"JV139 *VERSAO 39: JV1 DEMANDA 256312 - KINKAS 19/11/2020                      */
        /*"JV139 *           AJUSTA MONTAGEM STARTDBM                                    */
        /*"JV139 *           - PROCURAR POR JV139                                        */
        /*"JV138 *-----------------------------------------------------------------      */
        /*"JV138 *VERSAO 38: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV138 *           ALTERA FORMULARIOS PARA EMPRESA 11 - JV1                    */
        /*"JV138 *           - PROCURAR POR JV138                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 037                                                  *      */
        /*"      * MOTIVO  : ATUALIZAR CERTIFICADOS DS03, DS06 E DS24             *      */
        /*"      * CADMUS  : 148672                                               *      */
        /*"      * DATA    : 03/05/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.37                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 036                                                  *      */
        /*"      * MOTIVO  : VERIFICAR COMPRA DE TITULO DA CAP                    *      */
        /*"      * CADMUS  : 147286                                               *      */
        /*"      * DATA    : 01/03/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.36                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 035                                                  *      */
        /*"      * MOTIVO  : DISPLAY QTD DE REGISTRO GRAVADOS NA TABELA           *      */
        /*"      *           SEGUROS.GE_OBJETO_ECT                                *      */
        /*"      * CADMUS  : 117435                                               *      */
        /*"      * DATA    : 08/12/2016                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.35                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 034                                                  *      */
        /*"      * MOTIVO  : SUBSTITUIR OS CERTIFICADOS:                          *      */
        /*"      *           7707   TE LIGO CROTINHO - PE01 (SUBSTITUIR PELO DS06)*      */
        /*"      *           7705   DIVIDA ZERO      - PE02 (SUBSTITUIR PELO DS03)*      */
        /*"      *           7707   TE LIGO CROT     - PE03 (SUBSTITUIR PELO DS06)*      */
        /*"      *           7705   DIVIDA ZERO      - PE04 (SUBSTITUIR PELO DS03)*      */
        /*"      *           7708   QUITACRED        - PP01 (SUBSTITUIR PELO DS06)*      */
        /*"      *           7713   MICROSSEGURO     - PE02 (SUBSTITUIR PELO DS03)*      */
        /*"      *           7716   DIVIDA ZERO CCA  - PE02 (SUBSTITUIR PELO DS03)*      */
        /*"      * CADMUS  : 117435                                               *      */
        /*"      * DATA    : 14/09/2015                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.34                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RVP0437B { get; set; } = new FileBasis(new PIC("X", "2200", "X(2200)"));

        public FileBasis RVP0437B
        {
            get
            {
                _.Move(RVP0437B_RECORD, _RVP0437B); VarBasis.RedefinePassValue(RVP0437B_RECORD, _RVP0437B, RVP0437B_RECORD); return _RVP0437B;
            }
        }
        public FileBasis _FVP0437B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis FVP0437B
        {
            get
            {
                _.Move(FVP0437B_RECORD, _FVP0437B); VarBasis.RedefinePassValue(FVP0437B_RECORD, _FVP0437B, FVP0437B_RECORD); return _FVP0437B;
            }
        }
        public SortBasis<VP0437B_REG_SVP0437B> SVP0437B { get; set; } = new SortBasis<VP0437B_REG_SVP0437B>(new VP0437B_REG_SVP0437B());
        /*"01                RVP0437B-RECORD     PIC X(2200).*/
        public StringBasis RVP0437B_RECORD { get; set; } = new StringBasis(new PIC("X", "2200", "X(2200)."), @"");
        /*"01                FVP0437B-RECORD     PIC X(132).*/
        public StringBasis FVP0437B_RECORD { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01                REG-SVP0437B.*/
        public VP0437B_REG_SVP0437B REG_SVP0437B { get; set; } = new VP0437B_REG_SVP0437B();
        public class VP0437B_REG_SVP0437B : VarBasis
        {
            /*"    05            SVA-CEP-G           PIC 9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05            SVA-NUM-CEP.*/
            public VP0437B_SVA_NUM_CEP SVA_NUM_CEP { get; set; } = new VP0437B_SVA_NUM_CEP();
            public class VP0437B_SVA_NUM_CEP : VarBasis
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
            /*"    05            SVA-IMPSEGCDG       PIC 9(013)V99.*/
            public DoubleBasis SVA_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05            SVA-VLPREMIO        PIC 9(013)V99.*/
            public DoubleBasis SVA_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05            SVA-OPCAOPAG        PIC X(001).*/
            public StringBasis SVA_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            SVA-AGECOBRAN       PIC S9(4) USAGE COMP.*/
            public IntBasis SVA_AGECOBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05            SVA-NOMEAGCOB       PIC X(040).*/
            public StringBasis SVA_NOMEAGCOB { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
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
            /*"    05            SVA-COD-EMPRESA     PIC 9(004).*/
            public IntBasis SVA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"01        WS-QTD-GRAVADOS        PIC 9(006) VALUE ZEROS.*/
        public IntBasis WS_QTD_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01        WS-DET6-COBERTURAS.*/
        public VP0437B_WS_DET6_COBERTURAS WS_DET6_COBERTURAS { get; set; } = new VP0437B_WS_DET6_COBERTURAS();
        public class VP0437B_WS_DET6_COBERTURAS : VarBasis
        {
            /*"  03      WS-DET6-COBER-OCC OCCURS 02 TIMES.*/
            public ListBasis<VP0437B_WS_DET6_COBER_OCC> WS_DET6_COBER_OCC { get; set; } = new ListBasis<VP0437B_WS_DET6_COBER_OCC>(02);
            public class VP0437B_WS_DET6_COBER_OCC : VarBasis
            {
                /*"    05    WS-DET6-RAMO           PIC X(002).*/
                public StringBasis WS_DET6_RAMO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05    WS-DET6-STRING1        PIC X(043).*/
                public StringBasis WS_DET6_STRING1 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)."), @"");
                /*"    05    WS-DET6-VALOR-SEG      PIC X(013).*/
                public StringBasis WS_DET6_VALOR_SEG { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05    WS-DET6-VALOR-SEG-NUM  PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_DET6_VALOR_SEG_NUM { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"    05    WS-DET6-PREMIO-LIQ     PIC X(013).*/
                public StringBasis WS_DET6_PREMIO_LIQ { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05    WS-DET6-PREMIO-LIQ-NUM PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_DET6_PREMIO_LIQ_NUM { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"    05    WS-DET6-VALOR-IOF      PIC X(013).*/
                public StringBasis WS_DET6_VALOR_IOF { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05    WS-DET6-VALOR-IOF-NUM  PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_DET6_VALOR_IOF_NUM { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"    05    WS-DET6-PREMIO-TOT     PIC X(013).*/
                public StringBasis WS_DET6_PREMIO_TOT { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05    WS-DET6-PREMIO-TOT-NUM PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_DET6_PREMIO_TOT_NUM { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"01        WS-DET3-COBERTURAS.*/
            }
        }
        public VP0437B_WS_DET3_COBERTURAS WS_DET3_COBERTURAS { get; set; } = new VP0437B_WS_DET3_COBERTURAS();
        public class VP0437B_WS_DET3_COBERTURAS : VarBasis
        {
            /*"  03      WS-DET3-COBER-OCC OCCURS 02 TIMES.*/
            public ListBasis<VP0437B_WS_DET3_COBER_OCC> WS_DET3_COBER_OCC { get; set; } = new ListBasis<VP0437B_WS_DET3_COBER_OCC>(02);
            public class VP0437B_WS_DET3_COBER_OCC : VarBasis
            {
                /*"    05    WS-DET3-RAMO           PIC X(002).*/
                public StringBasis WS_DET3_RAMO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05    WS-DET3-STRING1        PIC X(043).*/
                public StringBasis WS_DET3_STRING1 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)."), @"");
                /*"    05    WS-DET3-VALOR-SEG      PIC X(013).*/
                public StringBasis WS_DET3_VALOR_SEG { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05    WS-DET3-VALOR-SEG-NUM  PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_DET3_VALOR_SEG_NUM { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"    05    WS-DET3-PREMIO-LIQ     PIC X(013).*/
                public StringBasis WS_DET3_PREMIO_LIQ { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05    WS-DET3-PREMIO-LIQ-NUM PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_DET3_PREMIO_LIQ_NUM { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"    05    WS-DET3-VALOR-IOF      PIC X(013).*/
                public StringBasis WS_DET3_VALOR_IOF { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05    WS-DET3-VALOR-IOF-NUM  PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_DET3_VALOR_IOF_NUM { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"    05    WS-DET3-PREMIO-TOT     PIC X(013).*/
                public StringBasis WS_DET3_PREMIO_TOT { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05    WS-DET3-PREMIO-TOT-NUM PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_DET3_PREMIO_TOT_NUM { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"77  WS-DET6-VLR-PREMIA-NUM         PIC ZZ.ZZZ.ZZZ,ZZ.*/
            }
        }
        public StringBasis WS_DET6_VLR_PREMIA_NUM { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
        /*"77  WS-TIPO-FORM-REF               PIC  X(008) VALUE SPACES.*/
        public StringBasis WS_TIPO_FORM_REF { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  WHOST-DATA-TERVIG-PREMIO       PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIG_PREMIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  W77-MES                        PIC  9(002).*/
        public IntBasis W77_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"77  ENDOSSOS-DATA-TERVIGENCIA-1    PIC  X(010).*/
        public StringBasis ENDOSSOS_DATA_TERVIGENCIA_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-1     PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WS-SQLCODE                     PIC  ---9.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01  WS-PREMIO-TOT                  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WS_PREMIO_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  WS-PREMIO-LIQ                  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis WS_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  WS-VAL-IOF                     PIC S9(4)V9(2) USAGE COMP-3.*/
        public DoubleBasis WS_VAL_IOF { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(2)"), 2);
        /*"01  WS-CERTIFICADO                 PIC  S9(15) USAGE COMP-3.*/
        public IntBasis WS_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  WS-NOME-SEG                    PIC  X(40) VALUE SPACES.*/
        public StringBasis WS_NOME_SEG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"01  WS-TIPO-FORM                   PIC  X(008) VALUE SPACES.*/
        public StringBasis WS_TIPO_FORM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-CGCCPF-SEG                  PIC  S9(15) USAGE COMP-3.*/
        public IntBasis WS_CGCCPF_SEG { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  WS-ENDERECO-SEG                PIC  X(72) VALUE SPACES.*/
        public StringBasis WS_ENDERECO_SEG { get; set; } = new StringBasis(new PIC("X", "72", "X(72)"), @"");
        /*"01  WS-BAIRRO-SEG                  PIC  X(72) VALUE SPACES.*/
        public StringBasis WS_BAIRRO_SEG { get; set; } = new StringBasis(new PIC("X", "72", "X(72)"), @"");
        /*"01  WS-CIDADE-SEG                  PIC  X(72) VALUE SPACES.*/
        public StringBasis WS_CIDADE_SEG { get; set; } = new StringBasis(new PIC("X", "72", "X(72)"), @"");
        /*"01  WS-UF-SEG                      PIC  X(02) VALUE SPACES.*/
        public StringBasis WS_UF_SEG { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"01  WS-CEP-SEG                     PIC  S9(9) USAGE COMP.*/
        public IntBasis WS_CEP_SEG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01 WS-DT-AVERB-INV.*/
        public VP0437B_WS_DT_AVERB_INV WS_DT_AVERB_INV { get; set; } = new VP0437B_WS_DT_AVERB_INV();
        public class VP0437B_WS_DT_AVERB_INV : VarBasis
        {
            /*"   03 WS-AAAA-INV                  PIC 9(04).*/
            public IntBasis WS_AAAA_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   03 WS-MM-INV                    PIC 9(02).*/
            public IntBasis WS_MM_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   03 WS-DD-INV                    PIC 9(02).*/
            public IntBasis WS_DD_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"77    VIND-CODPRODUTO             PIC S9(004)    COMP VALUE  0.*/
        }
        public IntBasis VIND_CODPRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                VIND-CODMOEDA-I     PIC S9(004) COMP VALUE -1.*/
        public IntBasis VIND_CODMOEDA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77                VIND-NRCOPIAS       PIC S9(004) COMP VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77                VIND-AGECTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                VIND-OPRCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                VIND-NUMCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                VIND-DIGCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                VIND-QTMDIT         PIC S9(004) COMP.*/
        public IntBasis VIND_QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                VIND-SEXO           PIC S9(004) COMP.*/
        public IntBasis VIND_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77                WS-DATA-FIM-CALC    PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DATA_FIM_CALC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77                WS-PCTCONJUGE       PIC 9(003)V99 VALUE ZEROS.*/
        public DoubleBasis WS_PCTCONJUGE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
        /*"77                WS-IMPCONJUGE       PIC S9(013)V99 COMP-3                                                  VALUE +0.*/
        public DoubleBasis WS_IMPCONJUGE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77                WS-SVA-AGECOBRAN    PIC S9(4) USAGE COMP.*/
        public IntBasis WS_SVA_AGECOBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
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
        /*"77                V1SIST-MESREFER     PIC S9(004) COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                V1SIST-ANOREFER     PIC S9(004) COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                V1SIST-CURRENT      PIC X(010).*/
        public StringBasis V1SIST_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"01  AREA-DE-WORK.*/
        public VP0437B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VP0437B_AREA_DE_WORK();
        public class VP0437B_AREA_DE_WORK : VarBasis
        {
            /*"    05  WS-VALORES-AX.*/
            public VP0437B_WS_VALORES_AX WS_VALORES_AX { get; set; } = new VP0437B_WS_VALORES_AX();
            public class VP0437B_WS_VALORES_AX : VarBasis
            {
                /*"     10           WS-VALOR-9          PIC S9(11)V99.*/
                public DoubleBasis WS_VALOR_9 { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99."), 2);
                /*"     10           WS-VALOR-INT        PIC Z9.*/
                public IntBasis WS_VALOR_INT { get; set; } = new IntBasis(new PIC("9", "2", "Z9."));
                /*"     10           WS-VALOR-INT-X      PIC X(10).*/
                public StringBasis WS_VALOR_INT_X { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10           WS-VALOR            PIC ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"     10           WS-VALOR-RAMO       PIC ZZ.*/
                public StringBasis WS_VALOR_RAMO { get; set; } = new StringBasis(new PIC("X", "0", "ZZ."), @"");
                /*"     10           WS-VALOR4           PIC ZZZZ.*/
                public StringBasis WS_VALOR4 { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZ."), @"");
                /*"    05  WS-COBER-DESC                 PIC X(40).*/
            }
            public StringBasis WS_COBER_DESC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 CEP-TOTAL            PIC 9(8).*/
            public IntBasis CEP_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(8)."));
            /*"    05 CEP-LEGAL  REDEFINES CEP-TOTAL.*/
            private _REDEF_VP0437B_CEP_LEGAL _cep_legal { get; set; }
            public _REDEF_VP0437B_CEP_LEGAL CEP_LEGAL
            {
                get { _cep_legal = new _REDEF_VP0437B_CEP_LEGAL(); _.Move(CEP_TOTAL, _cep_legal); VarBasis.RedefinePassValue(CEP_TOTAL, _cep_legal, CEP_TOTAL); _cep_legal.ValueChanged += () => { _.Move(_cep_legal, CEP_TOTAL); }; return _cep_legal; }
                set { VarBasis.RedefinePassValue(value, _cep_legal, CEP_TOTAL); }
            }  //Redefines
            public class _REDEF_VP0437B_CEP_LEGAL : VarBasis
            {
                /*"      10  CEP-PARTE1      PIC 9(5).*/
                public IntBasis CEP_PARTE1 { get; set; } = new IntBasis(new PIC("9", "5", "9(5)."));
                /*"      10  CEP-PARTE2      PIC 9(3).*/
                public IntBasis CEP_PARTE2 { get; set; } = new IntBasis(new PIC("9", "3", "9(3)."));
                /*"    05            LC01-LINHA01.*/

                public _REDEF_VP0437B_CEP_LEGAL()
                {
                    CEP_PARTE1.ValueChanged += OnValueChanged;
                    CEP_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public VP0437B_LC01_LINHA01 LC01_LINHA01 { get; set; } = new VP0437B_LC01_LINHA01();
            public class VP0437B_LC01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(002) VALUE '%!'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"%!");
                /*"    05            LC02-LINHA02.*/
            }
            public VP0437B_LC02_LINHA02 LC02_LINHA02 { get; set; } = new VP0437B_LC02_LINHA02();
            public class VP0437B_LC02_LINHA02 : VarBasis
            {
                /*"      10          LC02-FILLER          PIC X(070) VALUE    '%%DocumentMedia: papel1 595 842 75 white normal'.*/
                public StringBasis LC02_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%DocumentMedia: papel1 595 842 75 white normal");
                /*"    05            LC03-LINHA03.*/
            }
            public VP0437B_LC03_LINHA03 LC03_LINHA03 { get; set; } = new VP0437B_LC03_LINHA03();
            public class VP0437B_LC03_LINHA03 : VarBasis
            {
                /*"      10          LC03-FILLER          PIC X(070) VALUE    '%%+papel2 595 842 75 blue azul'.*/
                public StringBasis LC03_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%+papel2 595 842 75 blue azul");
                /*"    05            LC04-LINHA04.*/
            }
            public VP0437B_LC04_LINHA04 LC04_LINHA04 { get; set; } = new VP0437B_LC04_LINHA04();
            public class VP0437B_LC04_LINHA04 : VarBasis
            {
                /*"      10          LC04-FILLER          PIC X(070) VALUE    '%XRXrequeriments: duplex'.*/
                public StringBasis LC04_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%XRXrequeriments: duplex");
                /*"    05            LC04-LINHA04-01.*/
            }
            public VP0437B_LC04_LINHA04_01 LC04_LINHA04_01 { get; set; } = new VP0437B_LC04_LINHA04_01();
            public class VP0437B_LC04_LINHA04_01 : VarBasis
            {
                /*"      10          LC04-FILLER-01       PIC X(070) VALUE    '%XRXrequeriments: simplex'.*/
                public StringBasis LC04_FILLER_01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%XRXrequeriments: simplex");
                /*"    05            LC05-LINHA05.*/
            }
            public VP0437B_LC05_LINHA05 LC05_LINHA05 { get; set; } = new VP0437B_LC05_LINHA05();
            public class VP0437B_LC05_LINHA05 : VarBasis
            {
                /*"      10          LC05-FILLER          PIC X(070) VALUE    '%%BeginFeature: *Duplex True'.*/
                public StringBasis LC05_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%BeginFeature: *Duplex True");
                /*"    05            LC05-LINHA05-01.*/
            }
            public VP0437B_LC05_LINHA05_01 LC05_LINHA05_01 { get; set; } = new VP0437B_LC05_LINHA05_01();
            public class VP0437B_LC05_LINHA05_01 : VarBasis
            {
                /*"      10          LC05-FILLER-01       PIC X(070) VALUE    '%%BeginFeature: *Simplex True'.*/
                public StringBasis LC05_FILLER_01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%BeginFeature: *Simplex True");
                /*"    05            LC06-LINHA06.*/
            }
            public VP0437B_LC06_LINHA06 LC06_LINHA06 { get; set; } = new VP0437B_LC06_LINHA06();
            public class VP0437B_LC06_LINHA06 : VarBasis
            {
                /*"      10          LC06-FILLER          PIC X(070) VALUE    '<</Duplex true>> setpagedevice'.*/
                public StringBasis LC06_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"<</Duplex true>> setpagedevice");
                /*"    05            LC06-LINHA06-01.*/
            }
            public VP0437B_LC06_LINHA06_01 LC06_LINHA06_01 { get; set; } = new VP0437B_LC06_LINHA06_01();
            public class VP0437B_LC06_LINHA06_01 : VarBasis
            {
                /*"      10          LC06-FILLER-01       PIC X(070) VALUE    '<</Simplex true>> setpagedevice'.*/
                public StringBasis LC06_FILLER_01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"<</Simplex true>> setpagedevice");
                /*"    05            LC07-LINHA07.*/
            }
            public VP0437B_LC07_LINHA07 LC07_LINHA07 { get; set; } = new VP0437B_LC07_LINHA07();
            public class VP0437B_LC07_LINHA07 : VarBasis
            {
                /*"      10          LC07-FILLER          PIC X(070) VALUE    '%%EndFeature'.*/
                public StringBasis LC07_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EndFeature");
                /*"    05            LC08-LINHA08.*/
            }
            public VP0437B_LC08_LINHA08 LC08_LINHA08 { get; set; } = new VP0437B_LC08_LINHA08();
            public class VP0437B_LC08_LINHA08 : VarBasis
            {
                /*"      10          LC08-FILLER          PIC X(070) VALUE    '(|) SETDBSEP'.*/
                public StringBasis LC08_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"(|) SETDBSEP");
                /*"    05            LC09-JDE             PIC X(008) VALUE SPACES.*/
            }
            public StringBasis LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05            LC09-LINHA09         PIC X(023) VALUE SPACES.*/
            public StringBasis LC09_LINHA09 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
            /*"   05  CABEC-DS06.*/
            public VP0437B_CABEC_DS06 CABEC_DS06 { get; set; } = new VP0437B_CABEC_DS06();
            public class VP0437B_CABEC_DS06 : VarBasis
            {
                /*"      10         FILLER              PIC X(042) VALUE     'APOLICE|CERTIFICADO|PROPOSTA|DATA-EMISSAO|'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"APOLICE|CERTIFICADO|PROPOSTA|DATA_EMISSAO|");
                /*"      10         FILLER              PIC X(048) VALUE     'PERIODO-VIGENCIA|NUM-CONTRATO|RAZAO-SOCIAL|CNPJ|'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"PERIODO_VIGENCIA|NUM_CONTRATO|RAZAO_SOCIAL|CNPJ|");
                /*"      10         FILLER              PIC X(040) VALUE     'COD-SUSEP|ENDERECO|BAIRRO|CIDADE|CEP|UF|'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"COD_SUSEP|ENDERECO|BAIRRO|CIDADE|CEP|UF|");
                /*"      10         FILLER              PIC X(053) VALUE     'NOME-CORRETOR|CODIGO-SUSEP|NOME-ESTIPULANTE|CPF-CNPJ|'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"NOME_CORRETOR|CODIGO_SUSEP|NOME_ESTIPULANTE|CPF_CNPJ|");
                /*"      10         FILLER              PIC X(039) VALUE     'TELEFONE|ENDERECO|BAIRRO|CIDADE|CEP|UF|'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"TELEFONE|ENDERECO|BAIRRO|CIDADE|CEP|UF|");
                /*"      10         FILLER              PIC X(053) VALUE     'NOME-SEGURADO|CPF-CNPJ|ENDERECO|BAIRRO|CIDADE|CEP|UF|'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"NOME_SEGURADO|CPF_CNPJ|ENDERECO|BAIRRO|CIDADE|CEP|UF|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME1|CPF1|GRAU-PARENTESCO1|PART%1|'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME1|CPF1|GRAU_PARENTESCO1|PART%1|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME2|CPF2|GRAU-PARENTESCO2|PART%2|'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME2|CPF2|GRAU_PARENTESCO2|PART%2|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME3|CPF3|GRAU-PARENTESCO3|PART%3|'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME3|CPF3|GRAU_PARENTESCO3|PART%3|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME4|CPF4|GRAU-PARENTESCO4|PART%4|'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME4|CPF4|GRAU_PARENTESCO4|PART%4|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME5|CPF5|GRAU-PARENTESCO5|PART%5|'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME5|CPF5|GRAU_PARENTESCO5|PART%5|");
                /*"      10         FILLER              PIC X(035) VALUE     'RAMO1|COBERTURA1|CAPITAL-SEGURADO1|'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"RAMO1|COBERTURA1|CAPITAL_SEGURADO1|");
                /*"      10         FILLER              PIC X(035) VALUE     'RAMO2|COBERTURA2|CAPITAL-SEGURADO2|'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"RAMO2|COBERTURA2|CAPITAL_SEGURADO2|");
                /*"      10         FILLER              PIC X(035) VALUE     'PREMIO-LIQUIDO1|IOF1|PREMIO-TOTAL1|'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"PREMIO_LIQUIDO1|IOF1|PREMIO_TOTAL1|");
                /*"      10         FILLER              PIC X(035) VALUE     'PREMIO-LIQUIDO2|IOF2|PREMIO-TOTAL2|'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"PREMIO_LIQUIDO2|IOF2|PREMIO_TOTAL2|");
                /*"      10         FILLER              PIC X(047) VALUE     'FORMA-PAGAMENTO|PRAZOS|PERIODICIDADE|NUM-SORTE|'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"FORMA_PAGAMENTO|PRAZOS|PERIODICIDADE|NUM_SORTE|");
                /*"      10         FILLER              PIC X(016) VALUE     'VALOR-PREMIACAO|'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"VALOR_PREMIACAO|");
                /*"      10         FILLER              PIC X(039) VALUE     'DIA-CORRENTE|MES-CORRENTE|ANO-CORRENTE|'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"DIA_CORRENTE|MES_CORRENTE|ANO_CORRENTE|");
                /*"      10         FILLER              PIC X(015) VALUE     'CODIGO-PRODUTO|'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CODIGO_PRODUTO|");
                /*"      10         FILLER              PIC X(020) VALUE     'E-MAIL|DDD|TELEFONE|'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"E-MAIL|DDD|TELEFONE|");
                /*"   05  CABEC-DS03.*/
            }
            public VP0437B_CABEC_DS03 CABEC_DS03 { get; set; } = new VP0437B_CABEC_DS03();
            public class VP0437B_CABEC_DS03 : VarBasis
            {
                /*"      10         FILLER              PIC X(042) VALUE     'APOLICE|CERTIFICADO|PROPOSTA|DATA-EMISSAO|'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"APOLICE|CERTIFICADO|PROPOSTA|DATA_EMISSAO|");
                /*"      10         FILLER              PIC X(048) VALUE     'PERIODO-VIGENCIA|NUM-CONTRATO|RAZAO-SOCIAL|CNPJ|'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"PERIODO_VIGENCIA|NUM_CONTRATO|RAZAO_SOCIAL|CNPJ|");
                /*"      10         FILLER              PIC X(040) VALUE     'COD-SUSEP|ENDERECO|BAIRRO|CIDADE|CEP|UF|'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"COD_SUSEP|ENDERECO|BAIRRO|CIDADE|CEP|UF|");
                /*"      10         FILLER              PIC X(053) VALUE     'NOME-CORRETOR|CODIGO-SUSEP|NOME-ESTIPULANTE|CPF-CNPJ|'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"NOME_CORRETOR|CODIGO_SUSEP|NOME_ESTIPULANTE|CPF_CNPJ|");
                /*"      10         FILLER              PIC X(039) VALUE     'TELEFONE|ENDERECO|BAIRRO|CIDADE|CEP|UF|'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"TELEFONE|ENDERECO|BAIRRO|CIDADE|CEP|UF|");
                /*"      10         FILLER              PIC X(053) VALUE     'NOME-SEGURADO|CPF-CNPJ|ENDERECO|BAIRRO|CIDADE|CEP|UF|'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"NOME_SEGURADO|CPF_CNPJ|ENDERECO|BAIRRO|CIDADE|CEP|UF|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME1|CPF1|GRAU-PARENTESCO1|PART%1|'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME1|CPF1|GRAU_PARENTESCO1|PART%1|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME2|CPF2|GRAU-PARENTESCO2|PART%2|'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME2|CPF2|GRAU_PARENTESCO2|PART%2|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME3|CPF3|GRAU-PARENTESCO3|PART%3|'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME3|CPF3|GRAU_PARENTESCO3|PART%3|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME4|CPF4|GRAU-PARENTESCO4|PART%4|'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME4|CPF4|GRAU_PARENTESCO4|PART%4|");
                /*"      10         FILLER              PIC X(035) VALUE     'NOME5|CPF5|GRAU-PARENTESCO5|PART%5|'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"NOME5|CPF5|GRAU_PARENTESCO5|PART%5|");
                /*"      10         FILLER              PIC X(035) VALUE     'RAMO1|COBERTURA1|CAPITAL-SEGURADO1|'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"RAMO1|COBERTURA1|CAPITAL_SEGURADO1|");
                /*"      10         FILLER              PIC X(035) VALUE     'RAMO2|COBERTURA2|CAPITAL-SEGURADO2|'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"RAMO2|COBERTURA2|CAPITAL_SEGURADO2|");
                /*"      10         FILLER              PIC X(035) VALUE     'PREMIO-LIQUIDO1|IOF1|PREMIO-TOTAL1|'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"PREMIO_LIQUIDO1|IOF1|PREMIO_TOTAL1|");
                /*"      10         FILLER              PIC X(035) VALUE     'PREMIO-LIQUIDO2|IOF2|PREMIO-TOTAL2|'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"PREMIO_LIQUIDO2|IOF2|PREMIO_TOTAL2|");
                /*"      10         FILLER              PIC X(037) VALUE     'FORMA-PAGAMENTO|PRAZOS|PERIODICIDADE|'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"FORMA_PAGAMENTO|PRAZOS|PERIODICIDADE|");
                /*"      10         FILLER              PIC X(039) VALUE     'DIA-CORRENTE|MES-CORRENTE|ANO-CORRENTE|'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"DIA_CORRENTE|MES_CORRENTE|ANO_CORRENTE|");
                /*"      10         FILLER              PIC X(015) VALUE     'CODIGO-PRODUTO|'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CODIGO_PRODUTO|");
                /*"      10         FILLER              PIC X(020) VALUE     'E-MAIL|DDD|TELEFONE|'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"E-MAIL|DDD|TELEFONE|");
                /*"    05 DETALHE-DS06.*/
            }
        }
        public VP0437B_DETALHE_DS06 DETALHE_DS06 { get; set; } = new VP0437B_DETALHE_DS06();
        public class VP0437B_DETALHE_DS06 : VarBasis
        {
            /*"       10         DET6-APOLICE        PIC ZZZZZZZZZZZZZ.*/
            public StringBasis DET6_APOLICE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-NRCERTIF       PIC ZZZZZZZZZZZZZZZ.*/
            public StringBasis DET6_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"       10         DET6-DVCERTIF       PIC 9(001).*/
            public IntBasis DET6_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-NRPROPOST      PIC ZZZZZZZZZZZZZZZ.*/
            public StringBasis DET6_NRPROPOST { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"       10         DET6-DVPROPOST      PIC 9(001).*/
            public IntBasis DET6_DVPROPOST { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-DTINIVIG       PIC X(010).*/
            public StringBasis DET6_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-PERIODO-VIG    PIC X(023).*/
            public StringBasis DET6_PERIODO_VIG { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-NRCONTRATO     PIC ZZZZZZZZZZZZZZZ.*/
            public StringBasis DET6_NRCONTRATO { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"       10         DET6-DVCONTRATO     PIC 9(001).*/
            public IntBasis DET6_DVCONTRATO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-NOME-RAZAO-EMP PIC X(040).*/
            public StringBasis DET6_NOME_RAZAO_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-CNPJ-EMP       PIC X(017).*/
            public StringBasis DET6_CNPJ_EMP { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-COD-SUSEP-EMP  PIC X(005).*/
            public StringBasis DET6_COD_SUSEP_EMP { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-ENDERECO-EMP   PIC X(053).*/
            public StringBasis DET6_ENDERECO_EMP { get; set; } = new StringBasis(new PIC("X", "53", "X(053)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-BAIRRO-EMP     PIC X(009).*/
            public StringBasis DET6_BAIRRO_EMP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-CIDADE-EMP     PIC X(008).*/
            public StringBasis DET6_CIDADE_EMP { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-CEP-EMP        PIC X(009).*/
            public StringBasis DET6_CEP_EMP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-UF-EMP         PIC X(002).*/
            public StringBasis DET6_UF_EMP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-NOME-CORRETOR  PIC X(040).*/
            public StringBasis DET6_NOME_CORRETOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-COD-SUSEP-COR  PIC X(013).*/
            public StringBasis DET6_COD_SUSEP_COR { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-ESTIPULANTE    PIC X(040).*/
            public StringBasis DET6_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-NRCPF          PIC 999.999.999.*/
            public IntBasis DET6_NRCPF { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
            /*"       10         FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"       10         DET6-DVCPF          PIC 9(002).*/
            public IntBasis DET6_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-TEL-ESTIP      PIC X(009).*/
            public StringBasis DET6_TEL_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-END-ESTIP      PIC X(009).*/
            public StringBasis DET6_END_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-BAIRRO-ESTIP   PIC X(009).*/
            public StringBasis DET6_BAIRRO_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-CIDADE-ESTIP   PIC X(009).*/
            public StringBasis DET6_CIDADE_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-CEP-ESTIP      PIC X(009).*/
            public StringBasis DET6_CEP_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-UF-ESTIP       PIC X(002).*/
            public StringBasis DET6_UF_ESTIP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-NOME-SEG       PIC X(040).*/
            public StringBasis DET6_NOME_SEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-CGCCPF-SEG     PIC X(015).*/
            public StringBasis DET6_CGCCPF_SEG { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-ENDERE-SEG     PIC X(070).*/
            public StringBasis DET6_ENDERE_SEG { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-BAIRRO-SEG     PIC X(040).*/
            public StringBasis DET6_BAIRRO_SEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-CIDADE-SEG     PIC X(040).*/
            public StringBasis DET6_CIDADE_SEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-CEP-SEG        PIC X(008).*/
            public StringBasis DET6_CEP_SEG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-UF-SEG         PIC X(002).*/
            public StringBasis DET6_UF_SEG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-BENEFICIARIOS.*/
            public VP0437B_DET6_BENEFICIARIOS DET6_BENEFICIARIOS { get; set; } = new VP0437B_DET6_BENEFICIARIOS();
            public class VP0437B_DET6_BENEFICIARIOS : VarBasis
            {
                /*"         15       DET6-BENEF-OCC OCCURS 5 TIMES.*/
                public ListBasis<VP0437B_DET6_BENEF_OCC> DET6_BENEF_OCC { get; set; } = new ListBasis<VP0437B_DET6_BENEF_OCC>(5);
                public class VP0437B_DET6_BENEF_OCC : VarBasis
                {
                    /*"           20     DET6-NOME-BENEF     PIC X(040).*/
                    public StringBasis DET6_NOME_BENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"           20     DET6-DELIMIT-01     PIC X(001).*/
                    public StringBasis DET6_DELIMIT_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           20     DET6-NUM-CPF        PIC X(011).*/
                    public StringBasis DET6_NUM_CPF { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                    /*"           20     DET6-DELIMIT-02     PIC X(001).*/
                    public StringBasis DET6_DELIMIT_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           20     DET6-PARENTESCO     PIC X(020).*/
                    public StringBasis DET6_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                    /*"           20     DET6-DELIMIT-03     PIC X(001).*/
                    public StringBasis DET6_DELIMIT_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           20     DET6-PARTICIP-X     PIC X(006).*/
                    public StringBasis DET6_PARTICIP_X { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                    /*"           20     DET6-PARTICIP      REDEFINES                  DET6-PARTICIP-X     PIC ZZ9,99.*/
                    private _REDEF_DoubleBasis _det6_particip { get; set; }
                    public _REDEF_DoubleBasis DET6_PARTICIP
                    {
                        get { _det6_particip = new _REDEF_DoubleBasis(new PIC("9", "ZZ9,99", "ZZ9V99."), 2); ; _.Move(DET6_PARTICIP_X, _det6_particip); VarBasis.RedefinePassValue(DET6_PARTICIP_X, _det6_particip, DET6_PARTICIP_X); _det6_particip.ValueChanged += () => { _.Move(_det6_particip, DET6_PARTICIP_X); }; return _det6_particip; }
                        set { VarBasis.RedefinePassValue(value, _det6_particip, DET6_PARTICIP_X); }
                    }  //Redefines
                    /*"           20     DET6-DELIMIT-4      PIC X(001).*/
                    public StringBasis DET6_DELIMIT_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"       10         DET6-COBERTURAS.*/
                }
            }
            public VP0437B_DET6_COBERTURAS DET6_COBERTURAS { get; set; } = new VP0437B_DET6_COBERTURAS();
            public class VP0437B_DET6_COBERTURAS : VarBasis
            {
                /*"           20     DET6-RAMO1          PIC X(002).*/
                public StringBasis DET6_RAMO1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"           20     DET6-DELIMIT1-1     PIC X(001).*/
                public StringBasis DET6_DELIMIT1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-STRING1        PIC X(043) VALUE SPACES.*/
                public StringBasis DET6_STRING1 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"           20     DET6-DELIMIT1-2     PIC X(001).*/
                public StringBasis DET6_DELIMIT1_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-VALOR-SEG1     PIC X(013).*/
                public StringBasis DET6_VALOR_SEG1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET6-DELIMIT1-3     PIC X(001).*/
                public StringBasis DET6_DELIMIT1_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-RAMO2          PIC X(002).*/
                public StringBasis DET6_RAMO2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"           20     DET6-DELIMIT2-1     PIC X(001).*/
                public StringBasis DET6_DELIMIT2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-STRING2        PIC X(043) VALUE SPACES.*/
                public StringBasis DET6_STRING2 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"           20     DET6-DELIMIT2-2     PIC X(001).*/
                public StringBasis DET6_DELIMIT2_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-VALOR-SEG2     PIC X(013).*/
                public StringBasis DET6_VALOR_SEG2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET6-DELIMIT2-3     PIC X(001).*/
                public StringBasis DET6_DELIMIT2_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-PREMIO-LIQ1    PIC X(013).*/
                public StringBasis DET6_PREMIO_LIQ1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET6-DELIMIT1-4     PIC X(001).*/
                public StringBasis DET6_DELIMIT1_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-VALOR-IOF1     PIC X(013).*/
                public StringBasis DET6_VALOR_IOF1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET6-DELIMIT1-5     PIC X(001).*/
                public StringBasis DET6_DELIMIT1_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-PREMIO-TOT1    PIC X(013).*/
                public StringBasis DET6_PREMIO_TOT1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET6-DELIMIT1-6     PIC X(001).*/
                public StringBasis DET6_DELIMIT1_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-PREMIO-LIQ2    PIC X(013).*/
                public StringBasis DET6_PREMIO_LIQ2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET6-DELIMIT2-4     PIC X(001).*/
                public StringBasis DET6_DELIMIT2_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-VALOR-IOF2     PIC X(013).*/
                public StringBasis DET6_VALOR_IOF2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET6-DELIMIT2-5     PIC X(001).*/
                public StringBasis DET6_DELIMIT2_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET6-PREMIO-TOT2    PIC X(013).*/
                public StringBasis DET6_PREMIO_TOT2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET6-DELIMIT2-6     PIC X(001).*/
                public StringBasis DET6_DELIMIT2_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10         DET6-OPCAOPAG       PIC X(030) VALUE SPACES.*/
            }
            public StringBasis DET6_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"       10         DET6-OPCAOPAG-R REDEFINES                  DET6-OPCAOPAG.*/
            private _REDEF_VP0437B_DET6_OPCAOPAG_R _det6_opcaopag_r { get; set; }
            public _REDEF_VP0437B_DET6_OPCAOPAG_R DET6_OPCAOPAG_R
            {
                get { _det6_opcaopag_r = new _REDEF_VP0437B_DET6_OPCAOPAG_R(); _.Move(DET6_OPCAOPAG, _det6_opcaopag_r); VarBasis.RedefinePassValue(DET6_OPCAOPAG, _det6_opcaopag_r, DET6_OPCAOPAG); _det6_opcaopag_r.ValueChanged += () => { _.Move(_det6_opcaopag_r, DET6_OPCAOPAG); }; return _det6_opcaopag_r; }
                set { VarBasis.RedefinePassValue(value, _det6_opcaopag_r, DET6_OPCAOPAG); }
            }  //Redefines
            public class _REDEF_VP0437B_DET6_OPCAOPAG_R : VarBasis
            {
                /*"         15       DET6-AGECTADEB      PIC 9(004).*/
                public IntBasis DET6_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"         15       DET6-PONTO1         PIC X(001).*/
                public StringBasis DET6_PONTO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"         15       DET6-OPRCTADEB      PIC 9(004).*/
                public IntBasis DET6_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"         15       DET6-PONTO2         PIC X(001).*/
                public StringBasis DET6_PONTO2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"         15       DET6-NUMCTADEB      PIC 9(012).*/
                public IntBasis DET6_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"         15       DET6-TRACO          PIC X(001).*/
                public StringBasis DET6_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"         15       DET6-DIGCTADEB      PIC 9(001).*/
                public IntBasis DET6_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"         15       FILLER              PIC X(006).*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                public _REDEF_VP0437B_DET6_OPCAOPAG_R()
                {
                    DET6_AGECTADEB.ValueChanged += OnValueChanged;
                    DET6_PONTO1.ValueChanged += OnValueChanged;
                    DET6_OPRCTADEB.ValueChanged += OnValueChanged;
                    DET6_PONTO2.ValueChanged += OnValueChanged;
                    DET6_NUMCTADEB.ValueChanged += OnValueChanged;
                    DET6_TRACO.ValueChanged += OnValueChanged;
                    DET6_DIGCTADEB.ValueChanged += OnValueChanged;
                    FILLER_75.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-PRAZO          PIC X(004) VALUE SPACES.*/
            public StringBasis DET6_PRAZO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-PERIODICIDADE PIC X(004) VALUE SPACES.*/
            public StringBasis DET6_PERIODICIDADE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-NUM-SORTE      PIC X(020) VALUE SPACES.*/
            public StringBasis DET6_NUM_SORTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-VLR-PREMIACAO  PIC X(013) VALUE SPACES.*/
            public StringBasis DET6_VLR_PREMIACAO { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-DIA-CORRENTE   PIC X(002) VALUE SPACES.*/
            public StringBasis DET6_DIA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-MES-CORRENTE   PIC X(009) VALUE SPACES.*/
            public StringBasis DET6_MES_CORRENTE { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-ANO-CORRENTE   PIC X(009) VALUE SPACES.*/
            public StringBasis DET6_ANO_CORRENTE { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-COD-PRODUTO    PIC 9(004).*/
            public IntBasis DET6_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-E-MAIL         PIC X(040) VALUE SPACES.*/
            public StringBasis DET6_E_MAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-DDD            PIC X(005) VALUE SPACES.*/
            public StringBasis DET6_DDD { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET6-TELEFONE       PIC X(011) VALUE SPACES.*/
            public StringBasis DET6_TELEFONE { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"    05 DETALHE-DS03.*/
        }
        public VP0437B_DETALHE_DS03 DETALHE_DS03 { get; set; } = new VP0437B_DETALHE_DS03();
        public class VP0437B_DETALHE_DS03 : VarBasis
        {
            /*"       10         DET3-APOLICE        PIC ZZZZZZZZZZZZZ.*/
            public StringBasis DET3_APOLICE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-NRCERTIF       PIC ZZZZZZZZZZZZZZZ.*/
            public StringBasis DET3_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"       10         DET3-DVCERTIF       PIC 9(001).*/
            public IntBasis DET3_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-NRPROPOST      PIC ZZZZZZZZZZZZZZZ.*/
            public StringBasis DET3_NRPROPOST { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"       10         DET3-DVPROPOST      PIC 9(001).*/
            public IntBasis DET3_DVPROPOST { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-DTINIVIG       PIC X(010).*/
            public StringBasis DET3_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-PERIODO-VIG    PIC X(023).*/
            public StringBasis DET3_PERIODO_VIG { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-NRCONTRATO     PIC ZZZZZZZZZZZZZZZ.*/
            public StringBasis DET3_NRCONTRATO { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"       10         DET3-DVCONTRATO     PIC 9(001).*/
            public IntBasis DET3_DVCONTRATO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-NOME-RAZAO-EMP PIC X(040).*/
            public StringBasis DET3_NOME_RAZAO_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-CNPJ-EMP       PIC X(017).*/
            public StringBasis DET3_CNPJ_EMP { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-COD-SUSEP-EMP  PIC X(005).*/
            public StringBasis DET3_COD_SUSEP_EMP { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-ENDERECO-EMP   PIC X(053).*/
            public StringBasis DET3_ENDERECO_EMP { get; set; } = new StringBasis(new PIC("X", "53", "X(053)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-BAIRRO-EMP     PIC X(009).*/
            public StringBasis DET3_BAIRRO_EMP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-CIDADE-EMP     PIC X(008).*/
            public StringBasis DET3_CIDADE_EMP { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-CEP-EMP        PIC X(009).*/
            public StringBasis DET3_CEP_EMP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-UF-EMP         PIC X(002).*/
            public StringBasis DET3_UF_EMP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-NOME-CORRETOR  PIC X(040).*/
            public StringBasis DET3_NOME_CORRETOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-COD-SUSEP-COR  PIC X(013).*/
            public StringBasis DET3_COD_SUSEP_COR { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-ESTIPULANTE    PIC X(040).*/
            public StringBasis DET3_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-NRCPF          PIC 999.999.999.*/
            public IntBasis DET3_NRCPF { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
            /*"       10         FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"       10         DET3-DVCPF          PIC 9(002).*/
            public IntBasis DET3_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-TEL-ESTIP      PIC X(009).*/
            public StringBasis DET3_TEL_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-END-ESTIP      PIC X(009).*/
            public StringBasis DET3_END_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-BAIRRO-ESTIP   PIC X(009).*/
            public StringBasis DET3_BAIRRO_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-CIDADE-ESTIP   PIC X(009).*/
            public StringBasis DET3_CIDADE_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-CEP-ESTIP      PIC X(009).*/
            public StringBasis DET3_CEP_ESTIP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-UF-ESTIP       PIC X(002).*/
            public StringBasis DET3_UF_ESTIP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-NOME-SEG       PIC X(040).*/
            public StringBasis DET3_NOME_SEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-CGCCPF-SEG     PIC X(015).*/
            public StringBasis DET3_CGCCPF_SEG { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-ENDERE-SEG     PIC X(070).*/
            public StringBasis DET3_ENDERE_SEG { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-BAIRRO-SEG     PIC X(040).*/
            public StringBasis DET3_BAIRRO_SEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-CIDADE-SEG     PIC X(040).*/
            public StringBasis DET3_CIDADE_SEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-CEP-SEG        PIC X(008).*/
            public StringBasis DET3_CEP_SEG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-UF-SEG         PIC X(002).*/
            public StringBasis DET3_UF_SEG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-BENEFICIARIOS.*/
            public VP0437B_DET3_BENEFICIARIOS DET3_BENEFICIARIOS { get; set; } = new VP0437B_DET3_BENEFICIARIOS();
            public class VP0437B_DET3_BENEFICIARIOS : VarBasis
            {
                /*"         15       DET3-BENEF-OCC OCCURS 5 TIMES.*/
                public ListBasis<VP0437B_DET3_BENEF_OCC> DET3_BENEF_OCC { get; set; } = new ListBasis<VP0437B_DET3_BENEF_OCC>(5);
                public class VP0437B_DET3_BENEF_OCC : VarBasis
                {
                    /*"           20     DET3-NOME-BENEF PIC X(040).*/
                    public StringBasis DET3_NOME_BENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"           20     DET3-DELIMIT-01 PIC X(001).*/
                    public StringBasis DET3_DELIMIT_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           20     DET3-NUM-CPF    PIC X(011).*/
                    public StringBasis DET3_NUM_CPF { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                    /*"           20     DET3-DELIMIT-02 PIC X(001).*/
                    public StringBasis DET3_DELIMIT_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           20     DET3-PARENTESCO PIC X(020).*/
                    public StringBasis DET3_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                    /*"           20     DET3-DELIMIT-03 PIC X(001).*/
                    public StringBasis DET3_DELIMIT_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           20     DET3-PARTICIP-X PIC X(006).*/
                    public StringBasis DET3_PARTICIP_X { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                    /*"           20     DET3-PARTICIP      REDEFINES                  DET3-PARTICIP-X     PIC ZZ9,99.*/
                    private _REDEF_DoubleBasis _det3_particip { get; set; }
                    public _REDEF_DoubleBasis DET3_PARTICIP
                    {
                        get { _det3_particip = new _REDEF_DoubleBasis(new PIC("9", "ZZ9,99", "ZZ9V99."), 2); ; _.Move(DET3_PARTICIP_X, _det3_particip); VarBasis.RedefinePassValue(DET3_PARTICIP_X, _det3_particip, DET3_PARTICIP_X); _det3_particip.ValueChanged += () => { _.Move(_det3_particip, DET3_PARTICIP_X); }; return _det3_particip; }
                        set { VarBasis.RedefinePassValue(value, _det3_particip, DET3_PARTICIP_X); }
                    }  //Redefines
                    /*"           20     DET3-DELIMIT-4      PIC X(001).*/
                    public StringBasis DET3_DELIMIT_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"       10         DET3-COBERTURAS.*/
                }
            }
            public VP0437B_DET3_COBERTURAS DET3_COBERTURAS { get; set; } = new VP0437B_DET3_COBERTURAS();
            public class VP0437B_DET3_COBERTURAS : VarBasis
            {
                /*"           20     DET3-RAMO1          PIC X(002).*/
                public StringBasis DET3_RAMO1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"           20     DET3-DELIMIT1-1     PIC X(001).*/
                public StringBasis DET3_DELIMIT1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-STRING1        PIC X(043) VALUE SPACES.*/
                public StringBasis DET3_STRING1 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"           20     DET3-DELIMIT1-2     PIC X(001).*/
                public StringBasis DET3_DELIMIT1_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-VALOR-SEG1     PIC X(013).*/
                public StringBasis DET3_VALOR_SEG1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET3-DELIMIT1-3     PIC X(001).*/
                public StringBasis DET3_DELIMIT1_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-RAMO2          PIC X(002).*/
                public StringBasis DET3_RAMO2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"           20     DET3-DELIMIT2-1     PIC X(001).*/
                public StringBasis DET3_DELIMIT2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-STRING2        PIC X(043) VALUE SPACES.*/
                public StringBasis DET3_STRING2 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"           20     DET3-DELIMIT2-2     PIC X(001).*/
                public StringBasis DET3_DELIMIT2_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-VALOR-SEG2     PIC X(013).*/
                public StringBasis DET3_VALOR_SEG2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET3-DELIMIT2-3     PIC X(001).*/
                public StringBasis DET3_DELIMIT2_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-PREMIO-LIQ1    PIC X(013).*/
                public StringBasis DET3_PREMIO_LIQ1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET3-DELIMIT1-4     PIC X(001).*/
                public StringBasis DET3_DELIMIT1_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-VALOR-IOF1     PIC X(013).*/
                public StringBasis DET3_VALOR_IOF1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET3-DELIMIT1-5     PIC X(001).*/
                public StringBasis DET3_DELIMIT1_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-PREMIO-TOT1    PIC X(013).*/
                public StringBasis DET3_PREMIO_TOT1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET3-DELIMIT1-6     PIC X(001).*/
                public StringBasis DET3_DELIMIT1_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-PREMIO-LIQ2    PIC X(013).*/
                public StringBasis DET3_PREMIO_LIQ2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET3-DELIMIT2-4     PIC X(001).*/
                public StringBasis DET3_DELIMIT2_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-VALOR-IOF2     PIC X(013).*/
                public StringBasis DET3_VALOR_IOF2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET3-DELIMIT2-5     PIC X(001).*/
                public StringBasis DET3_DELIMIT2_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"           20     DET3-PREMIO-TOT2    PIC X(013).*/
                public StringBasis DET3_PREMIO_TOT2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"           20     DET3-DELIMIT2-6     PIC X(001).*/
                public StringBasis DET3_DELIMIT2_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10         DET3-OPCAOPAG       PIC X(030) VALUE SPACES.*/
            }
            public StringBasis DET3_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"       10         DET3-OPCAOPAG-R REDEFINES                  DET3-OPCAOPAG.*/
            private _REDEF_VP0437B_DET3_OPCAOPAG_R _det3_opcaopag_r { get; set; }
            public _REDEF_VP0437B_DET3_OPCAOPAG_R DET3_OPCAOPAG_R
            {
                get { _det3_opcaopag_r = new _REDEF_VP0437B_DET3_OPCAOPAG_R(); _.Move(DET3_OPCAOPAG, _det3_opcaopag_r); VarBasis.RedefinePassValue(DET3_OPCAOPAG, _det3_opcaopag_r, DET3_OPCAOPAG); _det3_opcaopag_r.ValueChanged += () => { _.Move(_det3_opcaopag_r, DET3_OPCAOPAG); }; return _det3_opcaopag_r; }
                set { VarBasis.RedefinePassValue(value, _det3_opcaopag_r, DET3_OPCAOPAG); }
            }  //Redefines
            public class _REDEF_VP0437B_DET3_OPCAOPAG_R : VarBasis
            {
                /*"         15       DET3-AGECTADEB      PIC 9(004).*/
                public IntBasis DET3_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"         15       DET3-PONTO1         PIC X(001).*/
                public StringBasis DET3_PONTO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"         15       DET3-OPRCTADEB      PIC 9(004).*/
                public IntBasis DET3_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"         15       DET3-PONTO2         PIC X(001).*/
                public StringBasis DET3_PONTO2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"         15       DET3-NUMCTADEB      PIC 9(012).*/
                public IntBasis DET3_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"         15       DET3-TRACO          PIC X(001).*/
                public StringBasis DET3_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"         15       DET3-DIGCTADEB      PIC 9(001).*/
                public IntBasis DET3_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"         15       FILLER              PIC X(006).*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                public _REDEF_VP0437B_DET3_OPCAOPAG_R()
                {
                    DET3_AGECTADEB.ValueChanged += OnValueChanged;
                    DET3_PONTO1.ValueChanged += OnValueChanged;
                    DET3_OPRCTADEB.ValueChanged += OnValueChanged;
                    DET3_PONTO2.ValueChanged += OnValueChanged;
                    DET3_NUMCTADEB.ValueChanged += OnValueChanged;
                    DET3_TRACO.ValueChanged += OnValueChanged;
                    DET3_DIGCTADEB.ValueChanged += OnValueChanged;
                    FILLER_123.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-PRAZO          PIC X(004) VALUE SPACES.*/
            public StringBasis DET3_PRAZO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-PERIODICIDADE  PIC X(004) VALUE SPACES.*/
            public StringBasis DET3_PERIODICIDADE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-DIA-CORRENTE   PIC X(002) VALUE SPACES.*/
            public StringBasis DET3_DIA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-MES-CORRENTE   PIC X(009) VALUE SPACES.*/
            public StringBasis DET3_MES_CORRENTE { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-ANO-CORRENTE   PIC X(009) VALUE SPACES.*/
            public StringBasis DET3_ANO_CORRENTE { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-COD-PRODUTO    PIC 9(004).*/
            public IntBasis DET3_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-E-MAIL         PIC X(040) VALUE SPACES.*/
            public StringBasis DET3_E_MAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-DDD            PIC X(005) VALUE SPACES.*/
            public StringBasis DET3_DDD { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"       10         DET3-TELEFONE       PIC X(011) VALUE SPACES.*/
            public StringBasis DET3_TELEFONE { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"       10         FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"    05            LC12-LINHA12.*/
        }
        public VP0437B_LC12_LINHA12 LC12_LINHA12 { get; set; } = new VP0437B_LC12_LINHA12();
        public class VP0437B_LC12_LINHA12 : VarBasis
        {
            /*"      10          LC12-FILLER          PIC X(070) VALUE    '%%EOF'.*/
            public StringBasis LC12_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EOF");
            /*"    05            LF01-LINHA01.*/
        }
        public VP0437B_LF01_LINHA01 LF01_LINHA01 { get; set; } = new VP0437B_LF01_LINHA01();
        public class VP0437B_LF01_LINHA01 : VarBasis
        {
            /*"      10          FILLER              PIC X(055) VALUE     '<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>'.*/
            public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>");
            /*"      10          FILLER              PIC X(080) VALUE     'setpagedevice'.*/
            public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"setpagedevice");
            /*"    05            LF02-LINHA02         PIC X(023) VALUE                                      '(XXXXXXXX.DBM) STARTDBM'.*/
        }
        public StringBasis LF02_LINHA02 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"(XXXXXXXX.DBM) STARTDBM");
        /*"    05            LF03-LINHA03.*/
        public VP0437B_LF03_LINHA03 LF03_LINHA03 { get; set; } = new VP0437B_LF03_LINHA03();
        public class VP0437B_LF03_LINHA03 : VarBasis
        {
            /*"      10          FILLER               PIC X(070) VALUE     'LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA'.*/
            public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA");
            /*"    05            LF04-LINHA04.*/
        }
        public VP0437B_LF04_LINHA04 LF04_LINHA04 { get; set; } = new VP0437B_LF04_LINHA04();
        public class VP0437B_LF04_LINHA04 : VarBasis
        {
            /*"      10          LF04-NOME-FAIXA     PIC X(072).*/
            public StringBasis LF04_NOME_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"      10          FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"      10          LF04-FAIXA1         PIC X(005).*/
            public StringBasis LF04_FAIXA1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"      10          FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"      10          LF04-FAIXA1C        PIC X(003).*/
            public StringBasis LF04_FAIXA1C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"      10          FILLER              PIC X(005) VALUE '  A '.*/
            public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  A ");
            /*"      10          LF04-FAIXA2         PIC X(005).*/
            public StringBasis LF04_FAIXA2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"      10          FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"      10          LF04-FAIXA2C        PIC X(003).*/
            public StringBasis LF04_FAIXA2C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"      10          FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"      10          LF04-QTD-OBJ        PIC 9(003).*/
            public IntBasis LF04_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"      10          FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"      10          LF04-AMARRADO       PIC ZZZ.999.*/
            public IntBasis LF04_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
            /*"      10          FILLER              PIC X(001) VALUE '|'.*/
            public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"      10          LF04-SEQ-INICIAL    PIC ZZZ.999.*/
            public IntBasis LF04_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
            /*"      10          FILLER              PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          LF04-SEQ-FINAL      PIC ZZZ.999.*/
            public IntBasis LF04_SEQ_FINAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
            /*"    05            LR01-LINHA01.*/
        }
        public VP0437B_LR01_LINHA01 LR01_LINHA01 { get; set; } = new VP0437B_LR01_LINHA01();
        public class VP0437B_LR01_LINHA01 : VarBasis
        {
            /*"      10          FILLER               PIC X(001) VALUE '1'.*/
            public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"    05            LR02-LINHA02         PIC X(023) VALUE                                      '(CO05.JDT) STARTLM '.*/
        }
        public StringBasis LR02_LINHA02 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"(CO05.JDT) STARTLM ");
        /*"    05            LR03-LINHA03.*/
        public VP0437B_LR03_LINHA03 LR03_LINHA03 { get; set; } = new VP0437B_LR03_LINHA03();
        public class VP0437B_LR03_LINHA03 : VarBasis
        {
            /*"      10          LR03-CONTRATO-ECT    PIC X(030) VALUE     '     100134700-5'.*/
            public StringBasis LR03_CONTRATO_ECT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     100134700-5");
            /*"    05            LR04-LINHA04.*/
        }
        public VP0437B_LR04_LINHA04 LR04_LINHA04 { get; set; } = new VP0437B_LR04_LINHA04();
        public class VP0437B_LR04_LINHA04 : VarBasis
        {
            /*"      10          LR04-USUARIO         PIC X(030) VALUE     '     CAIXA SEGUROS'.*/
            public StringBasis LR04_USUARIO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     CAIXA SEGUROS");
            /*"    05            LR05-LINHA05.*/
        }
        public VP0437B_LR05_LINHA05 LR05_LINHA05 { get; set; } = new VP0437B_LR05_LINHA05();
        public class VP0437B_LR05_LINHA05 : VarBasis
        {
            /*"      10          LR05-ENDERECO        PIC X(070) VALUE     '     SHN Q1 BLOCO E - ED. SEDE CAIXA SEGURADORA'.*/
            public StringBasis LR05_ENDERECO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"     SHN Q1 BLOCO E - ED. SEDE CAIXA SEGURADORA");
            /*"    05            LR06-LINHA06.*/
        }
        public VP0437B_LR06_LINHA06 LR06_LINHA06 { get; set; } = new VP0437B_LR06_LINHA06();
        public class VP0437B_LR06_LINHA06 : VarBasis
        {
            /*"      10          LR06-UNID-POSTAGEM   PIC X(030) VALUE     '     DR/BSB/BSA'.*/
            public StringBasis LR06_UNID_POSTAGEM { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     DR/BSB/BSA");
            /*"    05            LR07-LINHA07.*/
        }
        public VP0437B_LR07_LINHA07 LR07_LINHA07 { get; set; } = new VP0437B_LR07_LINHA07();
        public class VP0437B_LR07_LINHA07 : VarBasis
        {
            /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
            public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"      10          LR07-SEQ             PIC ZZ.ZZ9.*/
            public IntBasis LR07_SEQ { get; set; } = new IntBasis(new PIC("9", "5", "ZZ.ZZ9."));
            /*"      10          FILLER               PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          LR07-MES             PIC X(012).*/
            public StringBasis LR07_MES { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"    05            LR08-LINHA08.*/
        }
        public VP0437B_LR08_LINHA08 LR08_LINHA08 { get; set; } = new VP0437B_LR08_LINHA08();
        public class VP0437B_LR08_LINHA08 : VarBasis
        {
            /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
            public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"      10          LR08-TIPO.*/
            public VP0437B_LR08_TIPO LR08_TIPO { get; set; } = new VP0437B_LR08_TIPO();
            public class VP0437B_LR08_TIPO : VarBasis
            {
                /*"        15        LR08-COD-PRODUTO     PIC 9(004).*/
                public IntBasis LR08_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        15        FILLER               PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        15        LR08-NOM-PRODUTO     PIC X(030).*/
                public StringBasis LR08_NOM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05            LR09-LINHA09.*/
            }
        }
        public VP0437B_LR09_LINHA09 LR09_LINHA09 { get; set; } = new VP0437B_LR09_LINHA09();
        public class VP0437B_LR09_LINHA09 : VarBasis
        {
            /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
            public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"      10          LR09-DATA            PIC X(010).*/
            public StringBasis LR09_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            LR10-LINHA10-A.*/
        }
        public VP0437B_LR10_LINHA10_A LR10_LINHA10_A { get; set; } = new VP0437B_LR10_LINHA10_A();
        public class VP0437B_LR10_LINHA10_A : VarBasis
        {
            /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
            public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"      10          LR10-NUCLEO          PIC X(030) VALUE                 'BRASILIA(DF)'.*/
            public StringBasis LR10_NUCLEO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"BRASILIA(DF)");
            /*"    05            LR10-LINHA10.*/
        }
        public VP0437B_LR10_LINHA10 LR10_LINHA10 { get; set; } = new VP0437B_LR10_LINHA10();
        public class VP0437B_LR10_LINHA10 : VarBasis
        {
            /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
            public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"      10          LR10-PAGINA          PIC 9(003).*/
            public IntBasis LR10_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"      10          FILLER               PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          LR10-PAGINA-T        PIC 9(003).*/
            public IntBasis LR10_PAGINA_T { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05            LR11-LINHA11.*/
        }
        public VP0437B_LR11_LINHA11 LR11_LINHA11 { get; set; } = new VP0437B_LR11_LINHA11();
        public class VP0437B_LR11_LINHA11 : VarBasis
        {
            /*"      10          FILLER              PIC X(101) VALUE SPACES.*/
            public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "101", "X(101)"), @"");
            /*"      10          LR11-GEPES          PIC X(008) VALUE                                                'GEPES - '.*/
            public StringBasis LR11_GEPES { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES - ");
            /*"      10          LR11-TP-PGTO        PIC X(022) VALUE SPACES.*/
            public StringBasis LR11_TP_PGTO { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
            /*"    05            LR12-LINHA12.*/
        }
        public VP0437B_LR12_LINHA12 LR12_LINHA12 { get; set; } = new VP0437B_LR12_LINHA12();
        public class VP0437B_LR12_LINHA12 : VarBasis
        {
            /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
            public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"      10          LR12-CEPI           PIC 9(005).*/
            public IntBasis LR12_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"      10          FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"      10          LR12-COMPL-CEPI     PIC 9(003).*/
            public IntBasis LR12_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
            public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"      10          LR12-CEPF           PIC 9(005).*/
            public IntBasis LR12_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"      10          FILLER              PIC X(001) VALUE '-'.*/
            public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"      10          LR12-COMPL-CEPF     PIC 9(003).*/
            public IntBasis LR12_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
            public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"      10          LR12-OBJI           PIC ZZZ.999.*/
            public IntBasis LR12_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
            /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
            public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"      10          LR12-OBJF           PIC ZZZ.999.*/
            public IntBasis LR12_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
            /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
            public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"      10          LR12-AMARI          PIC ZZZ.999.*/
            public IntBasis LR12_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
            /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
            public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"      10          LR12-AMARF          PIC ZZZ.999.*/
            public IntBasis LR12_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
            /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
            public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"      10          LR12-QTD-OBJ        PIC ZZZ.999.*/
            public IntBasis LR12_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
            /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
            public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"      10          LR12-QTD-AMAR       PIC ZZZ.999.*/
            public IntBasis LR12_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
            /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
            public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"      10          LR12-OBS            PIC X(023).*/
            public StringBasis LR12_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
            /*"    05            LR13-LINHA13.*/
        }
        public VP0437B_LR13_LINHA13 LR13_LINHA13 { get; set; } = new VP0437B_LR13_LINHA13();
        public class VP0437B_LR13_LINHA13 : VarBasis
        {
            /*"      10          FILLER              PIC X(001) VALUE '1'.*/
            public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"    05            AC-LINHAS           PIC 9(002) VALUE 80.*/
        }
        public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
        /*"    05            WWORK-QTDE01.*/
        public VP0437B_WWORK_QTDE01 WWORK_QTDE01 { get; set; } = new VP0437B_WWORK_QTDE01();
        public class VP0437B_WWORK_QTDE01 : VarBasis
        {
            /*"           10     WWORK-QTDE11        PIC  9(004).*/
            public IntBasis WWORK_QTDE11 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"           10     WWORK-QTDE12        PIC  9(002).*/
            public IntBasis WWORK_QTDE12 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            WWORK-QTDE  REDEFINES  WWORK-QTDE01                                      PIC S9(004)V99.*/
        }
        private _REDEF_DoubleBasis _wwork_qtde { get; set; }
        public _REDEF_DoubleBasis WWORK_QTDE
        {
            get { _wwork_qtde = new _REDEF_DoubleBasis(new PIC("S9", "004", "S9(004)V99."), 2); ; _.Move(WWORK_QTDE01, _wwork_qtde); VarBasis.RedefinePassValue(WWORK_QTDE01, _wwork_qtde, WWORK_QTDE01); _wwork_qtde.ValueChanged += () => { _.Move(_wwork_qtde, WWORK_QTDE01); }; return _wwork_qtde; }
            set { VarBasis.RedefinePassValue(value, _wwork_qtde, WWORK_QTDE01); }
        }  //Redefines
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
        /*"    05            WS-AMARRADO         PIC 9(006) VALUE ZEROS.*/
        public IntBasis WS_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05            WS-SEQ              PIC 9(006) VALUE ZEROS.*/
        public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05            WS-SEQ-INICIAL      PIC 9(006) VALUE ZEROS.*/
        public IntBasis WS_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05            AC-QTD-OBJ          PIC 9(006) VALUE ZEROS.*/
        public IntBasis AC_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05            WS-CONTROLE         PIC 9(006) VALUE ZEROS.*/
        public IntBasis WS_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05            WS-CONTR-AMAR       PIC 9(006) VALUE ZEROS.*/
        public IntBasis WS_CONTR_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
        /*"    05            WS-JDE-ANT          PIC X(008) VALUE ALL '*'.*/
        public StringBasis WS_JDE_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"ALL");
        /*"    05            WS-OPER-ANT         PIC 9(004).*/
        public IntBasis WS_OPER_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        /*"    05            WS-CEP-G-ANT        PIC 9(010).*/
        public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
        /*"    05            WS-NOME-COR-ANT.*/
        public VP0437B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new VP0437B_WS_NOME_COR_ANT();
        public class VP0437B_WS_NOME_COR_ANT : VarBasis
        {
            /*"      10          WS-FAIXA1-ANT       PIC 9(008).*/
            public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      10          WS-FAIXA2-ANT       PIC 9(008).*/
            public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      10          WS-NOME-ANT         PIC X(072).*/
            public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05            WS-INF              PIC 9(009).*/
        }
        public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"    05            WS-SUP              PIC 9(009).*/
        public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"    05            WS-IND              PIC S9(004) COMP                                                  VALUE +0.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    05            WIND                PIC S9(004) COMP                                                  VALUE +0.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    05            WIND-N              PIC S9(004) COMP                                                  VALUE +0.*/
        public IntBasis WIND_N { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        public VP0437B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new VP0437B_DEST_NUM_CEP();
        public class VP0437B_DEST_NUM_CEP : VarBasis
        {
            /*"      15          DEST-CEP            PIC 9(005) VALUE ZEROS.*/
            public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"      15          DEST-CEP-COMPL      PIC 9(003) VALUE ZEROS.*/
            public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05            WS-CPF              PIC 9(015).*/
        }
        public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
        /*"    05            WS-CPF-R            REDEFINES                  WS-CPF.*/
        private _REDEF_VP0437B_WS_CPF_R _ws_cpf_r { get; set; }
        public _REDEF_VP0437B_WS_CPF_R WS_CPF_R
        {
            get { _ws_cpf_r = new _REDEF_VP0437B_WS_CPF_R(); _.Move(WS_CPF, _ws_cpf_r); VarBasis.RedefinePassValue(WS_CPF, _ws_cpf_r, WS_CPF); _ws_cpf_r.ValueChanged += () => { _.Move(_ws_cpf_r, WS_CPF); }; return _ws_cpf_r; }
            set { VarBasis.RedefinePassValue(value, _ws_cpf_r, WS_CPF); }
        }  //Redefines
        public class _REDEF_VP0437B_WS_CPF_R : VarBasis
        {
            /*"      10          WS-NRCPF            PIC 9(013).*/
            public IntBasis WS_NRCPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"      10          WS-DVCPF            PIC 9(002).*/
            public IntBasis WS_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            WS-CERTIF           PIC 9(015).*/

            public _REDEF_VP0437B_WS_CPF_R()
            {
                WS_NRCPF.ValueChanged += OnValueChanged;
                WS_DVCPF.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
        /*"    05            WS-CERTIF-R         REDEFINES                  WS-CERTIF.*/
        private _REDEF_VP0437B_WS_CERTIF_R _ws_certif_r { get; set; }
        public _REDEF_VP0437B_WS_CERTIF_R WS_CERTIF_R
        {
            get { _ws_certif_r = new _REDEF_VP0437B_WS_CERTIF_R(); _.Move(WS_CERTIF, _ws_certif_r); VarBasis.RedefinePassValue(WS_CERTIF, _ws_certif_r, WS_CERTIF); _ws_certif_r.ValueChanged += () => { _.Move(_ws_certif_r, WS_CERTIF); }; return _ws_certif_r; }
            set { VarBasis.RedefinePassValue(value, _ws_certif_r, WS_CERTIF); }
        }  //Redefines
        public class _REDEF_VP0437B_WS_CERTIF_R : VarBasis
        {
            /*"      10          WS-NRCERTIF         PIC 9(014).*/
            public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"      10          WS-DVCERTIF         PIC 9(001).*/
            public IntBasis WS_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05            WDATA1.*/

            public _REDEF_VP0437B_WS_CERTIF_R()
            {
                WS_NRCERTIF.ValueChanged += OnValueChanged;
                WS_DVCERTIF.ValueChanged += OnValueChanged;
            }

        }
        public VP0437B_WDATA1 WDATA1 { get; set; } = new VP0437B_WDATA1();
        public class VP0437B_WDATA1 : VarBasis
        {
            /*"      10          WDATA1-ANO          PIC 9(004) VALUE ZEROS.*/
            public IntBasis WDATA1_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"      10          FILLER              PIC X(001).*/
            public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WDATA1-MES          PIC 9(002) VALUE ZEROS.*/
            public IntBasis WDATA1_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          FILLER              PIC X(001).*/
            public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WDATA1-DIA          PIC 9(002) VALUE ZEROS.*/
            public IntBasis WDATA1_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05            WS-DATA-SQL.*/
        }
        public VP0437B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VP0437B_WS_DATA_SQL();
        public class VP0437B_WS_DATA_SQL : VarBasis
        {
            /*"      10          WS-SEC-ANO          PIC 9(004) VALUE ZEROS.*/
            public IntBasis WS_SEC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"      10          WS-SEC-ANO-R        REDEFINES                  WS-SEC-ANO.*/
            private _REDEF_VP0437B_WS_SEC_ANO_R _ws_sec_ano_r { get; set; }
            public _REDEF_VP0437B_WS_SEC_ANO_R WS_SEC_ANO_R
            {
                get { _ws_sec_ano_r = new _REDEF_VP0437B_WS_SEC_ANO_R(); _.Move(WS_SEC_ANO, _ws_sec_ano_r); VarBasis.RedefinePassValue(WS_SEC_ANO, _ws_sec_ano_r, WS_SEC_ANO); _ws_sec_ano_r.ValueChanged += () => { _.Move(_ws_sec_ano_r, WS_SEC_ANO); }; return _ws_sec_ano_r; }
                set { VarBasis.RedefinePassValue(value, _ws_sec_ano_r, WS_SEC_ANO); }
            }  //Redefines
            public class _REDEF_VP0437B_WS_SEC_ANO_R : VarBasis
            {
                /*"        15        WS-ANO-SQL          PIC 9(004).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          FILLER              PIC X(001).*/

                public _REDEF_VP0437B_WS_SEC_ANO_R()
                {
                    WS_ANO_SQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WS-MES-SQL          PIC 9(002) VALUE ZEROS.*/
            public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          FILLER              PIC X(001).*/
            public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WS-DIA-SQL          PIC 9(002) VALUE ZEROS.*/
            public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05            WS-DATA.*/
        }
        public VP0437B_WS_DATA WS_DATA { get; set; } = new VP0437B_WS_DATA();
        public class VP0437B_WS_DATA : VarBasis
        {
            /*"      10          WS-DIA              PIC 9(002).*/
            public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10          FILLER              PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          WS-MES              PIC 9(002).*/
            public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10          FILLER              PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          WS-ANO              PIC 9(004).*/
            public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-DATA-ATUAL.*/
        }
        public VP0437B_WS_DATA_ATUAL WS_DATA_ATUAL { get; set; } = new VP0437B_WS_DATA_ATUAL();
        public class VP0437B_WS_DATA_ATUAL : VarBasis
        {
            /*"      10          WS-DIA-ATUAL        PIC 9(002).*/
            public IntBasis WS_DIA_ATUAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10          FILLER              PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          WS-MES-ATUAL        PIC 9(002).*/
            public IntBasis WS_MES_ATUAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10          FILLER              PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          WS-ANO-ATUAL        PIC 9(004).*/
            public IntBasis WS_ANO_ATUAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-DATA-MOV.*/
        }
        public VP0437B_WS_DATA_MOV WS_DATA_MOV { get; set; } = new VP0437B_WS_DATA_MOV();
        public class VP0437B_WS_DATA_MOV : VarBasis
        {
            /*"      10          WS-DIA-MOV          PIC 9(002).*/
            public IntBasis WS_DIA_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10          FILLER              PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          WS-MES-MOV          PIC 9(002).*/
            public IntBasis WS_MES_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10          FILLER              PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          WS-ANO-MOV          PIC 9(004).*/
            public IntBasis WS_ANO_MOV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-DT-EMI.*/
        }
        public VP0437B_WS_DT_EMI WS_DT_EMI { get; set; } = new VP0437B_WS_DT_EMI();
        public class VP0437B_WS_DT_EMI : VarBasis
        {
            /*"      10          WS-DD-EMI           PIC 9(002) VALUE ZEROS.*/
            public IntBasis WS_DD_EMI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          FILLERT1            PIC X(001).*/
            public StringBasis FILLERT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WS-MM-EMI           PIC 9(002) VALUE ZEROS.*/
            public IntBasis WS_MM_EMI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          FILLERT2            PIC X(001).*/
            public StringBasis FILLERT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WS-AAAA-EMI         PIC 9(004).*/
            public IntBasis WS_AAAA_EMI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-DATA-I.*/
        }
        public VP0437B_WS_DATA_I WS_DATA_I { get; set; } = new VP0437B_WS_DATA_I();
        public class VP0437B_WS_DATA_I : VarBasis
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
            private _REDEF_VP0437B_WS_SEC_ANO_IR _ws_sec_ano_ir { get; set; }
            public _REDEF_VP0437B_WS_SEC_ANO_IR WS_SEC_ANO_IR
            {
                get { _ws_sec_ano_ir = new _REDEF_VP0437B_WS_SEC_ANO_IR(); _.Move(WS_SEC_ANO_I, _ws_sec_ano_ir); VarBasis.RedefinePassValue(WS_SEC_ANO_I, _ws_sec_ano_ir, WS_SEC_ANO_I); _ws_sec_ano_ir.ValueChanged += () => { _.Move(_ws_sec_ano_ir, WS_SEC_ANO_I); }; return _ws_sec_ano_ir; }
                set { VarBasis.RedefinePassValue(value, _ws_sec_ano_ir, WS_SEC_ANO_I); }
            }  //Redefines
            public class _REDEF_VP0437B_WS_SEC_ANO_IR : VarBasis
            {
                /*"        15        WS-ANO-I            PIC 9(004).*/
                public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05            WS-TIME.*/

                public _REDEF_VP0437B_WS_SEC_ANO_IR()
                {
                    WS_ANO_I.ValueChanged += OnValueChanged;
                }

            }
        }
        public VP0437B_WS_TIME WS_TIME { get; set; } = new VP0437B_WS_TIME();
        public class VP0437B_WS_TIME : VarBasis
        {
            /*"      10          WS-HH-TIME          PIC 9(002) VALUE ZEROS.*/
            public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          WS-MM-TIME          PIC 9(002) VALUE ZEROS.*/
            public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          WS-SS-TIME          PIC 9(002) VALUE ZEROS.*/
            public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          WS-CC-TIME          PIC 9(002) VALUE ZEROS.*/
            public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05            WDATA-CABEC.*/
        }
        public VP0437B_WDATA_CABEC WDATA_CABEC { get; set; } = new VP0437B_WDATA_CABEC();
        public class VP0437B_WDATA_CABEC : VarBasis
        {
            /*"      10          WDATA-DD-CABEC      PIC 9(002) VALUE ZEROS.*/
            public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          FILLER              PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          WDATA-MM-CABEC      PIC 9(002) VALUE ZEROS.*/
            public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          FILLER              PIC X(001) VALUE '/'.*/
            public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10          WDATA-AA-CABEC      PIC 9(004) VALUE ZEROS.*/
            public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05            WHORA-CABEC.*/
        }
        public VP0437B_WHORA_CABEC WHORA_CABEC { get; set; } = new VP0437B_WHORA_CABEC();
        public class VP0437B_WHORA_CABEC : VarBasis
        {
            /*"      10          WHORA-HH-CABEC      PIC 9(002) VALUE ZEROS.*/
            public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          FILLER              PIC X(001) VALUE '.'.*/
            public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
            /*"      10          WHORA-MM-CABEC      PIC 9(002) VALUE ZEROS.*/
            public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10          FILLER              PIC X(001) VALUE '.'.*/
            public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
            /*"      10          WHORA-SS-CABEC      PIC 9(002) VALUE ZEROS.*/
            public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05            WDATA-REL           PIC X(010) VALUE SPACES.*/
        }
        public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"    05            FILLER              REDEFINES  WDATA-REL.*/
        private _REDEF_VP0437B_FILLER_181 _filler_181 { get; set; }
        public _REDEF_VP0437B_FILLER_181 FILLER_181
        {
            get { _filler_181 = new _REDEF_VP0437B_FILLER_181(); _.Move(WDATA_REL, _filler_181); VarBasis.RedefinePassValue(WDATA_REL, _filler_181, WDATA_REL); _filler_181.ValueChanged += () => { _.Move(_filler_181, WDATA_REL); }; return _filler_181; }
            set { VarBasis.RedefinePassValue(value, _filler_181, WDATA_REL); }
        }  //Redefines
        public class _REDEF_VP0437B_FILLER_181 : VarBasis
        {
            /*"      10          WDAT-REL-ANO        PIC 9(004).*/
            public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      10          FILLER              PIC X(001).*/
            public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WDAT-REL-MES        PIC 9(002).*/
            public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10          FILLER              PIC X(001).*/
            public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WDAT-REL-DIA        PIC 9(002).*/
            public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  WS-DATA-VIGENCIA.*/

            public _REDEF_VP0437B_FILLER_181()
            {
                WDAT_REL_ANO.ValueChanged += OnValueChanged;
                FILLER_182.ValueChanged += OnValueChanged;
                WDAT_REL_MES.ValueChanged += OnValueChanged;
                FILLER_183.ValueChanged += OnValueChanged;
                WDAT_REL_DIA.ValueChanged += OnValueChanged;
            }

        }
        public VP0437B_WS_DATA_VIGENCIA WS_DATA_VIGENCIA { get; set; } = new VP0437B_WS_DATA_VIGENCIA();
        public class VP0437B_WS_DATA_VIGENCIA : VarBasis
        {
            /*"      10  WS-DT-INI-VIG       PIC X(010) VALUE SPACES.*/
            public StringBasis WS_DT_INI_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"      10  WS-FILLER-A         PIC X(003) VALUE ' A '.*/
            public StringBasis WS_FILLER_A { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
            /*"      10  WS-DT-FIM-VIG       PIC X(010) VALUE SPACES.*/
            public StringBasis WS_DT_FIM_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05            WS-DATA-SEG.*/
        }
        public VP0437B_WS_DATA_SEG WS_DATA_SEG { get; set; } = new VP0437B_WS_DATA_SEG();
        public class VP0437B_WS_DATA_SEG : VarBasis
        {
            /*"      10          WS-STRING1          PIC X(020) VALUE SPACES.*/
            public StringBasis WS_STRING1 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"      10          WS-DTINIVIG.*/
            public VP0437B_WS_DTINIVIG WS_DTINIVIG { get; set; } = new VP0437B_WS_DTINIVIG();
            public class VP0437B_WS_DTINIVIG : VarBasis
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
            public VP0437B_WS_DTTERVIG WS_DTTERVIG { get; set; } = new VP0437B_WS_DTTERVIG();
            public class VP0437B_WS_DTTERVIG : VarBasis
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
        public VP0437B_WS_DATA_INV WS_DATA_INV { get; set; } = new VP0437B_WS_DATA_INV();
        public class VP0437B_WS_DATA_INV : VarBasis
        {
            /*"      10          WS-ANO-INV          PIC 9(004).*/
            public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      10          FILLER              PIC X(001).*/
            public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WS-MES-INV          PIC 9(002).*/
            public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10          FILLER              PIC X(001).*/
            public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10          WS-DIA-INV          PIC 9(002).*/
            public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            WHORA-CURR          PIC X(008) VALUE SPACES.*/
        }
        public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"    05            WS-NUM-CEP-AUX      PIC 9(008).*/
        public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"    05            WS-NUM-CEP-AUX-R    REDEFINES                  WS-NUM-CEP-AUX.*/
        private _REDEF_VP0437B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
        public _REDEF_VP0437B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
        {
            get { _ws_num_cep_aux_r = new _REDEF_VP0437B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
            set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
        }  //Redefines
        public class _REDEF_VP0437B_WS_NUM_CEP_AUX_R : VarBasis
        {
            /*"      10          WS-CEP-AUX          PIC 9(005).*/
            public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"      10          WS-CEP-COMPL-AUX    PIC 9(003).*/
            public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05            WS-NUM-CEP-AUX-R1   REDEFINES                  WS-NUM-CEP-AUX.*/

            public _REDEF_VP0437B_WS_NUM_CEP_AUX_R()
            {
                WS_CEP_AUX.ValueChanged += OnValueChanged;
                WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
            }

        }
        private _REDEF_VP0437B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
        public _REDEF_VP0437B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
        {
            get { _ws_num_cep_aux_r1 = new _REDEF_VP0437B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
            set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
        }  //Redefines
        public class _REDEF_VP0437B_WS_NUM_CEP_AUX_R1 : VarBasis
        {
            /*"      10          WS-CEP-COMPL-AUX1   PIC 9(003).*/
            public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"      10          WS-CEP-AUX1         PIC 9(005).*/
            public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        WS-RAMO.*/

            public _REDEF_VP0437B_WS_NUM_CEP_AUX_R1()
            {
                WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                WS_CEP_AUX1.ValueChanged += OnValueChanged;
            }

        }
        public VP0437B_WS_RAMO WS_RAMO { get; set; } = new VP0437B_WS_RAMO();
        public class VP0437B_WS_RAMO : VarBasis
        {
            /*"      10      WS-RAMOFR                PIC 9(002).*/
            public IntBasis WS_RAMOFR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10      WS-RAMOFR-99             PIC 9(002).*/
            public IntBasis WS_RAMOFR_99 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05        WS-CHAVE            PIC  X(020).*/
        }
        public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"    05        WS-CHAVE-R          REDEFINES              WS-CHAVE.*/
        private _REDEF_VP0437B_WS_CHAVE_R _ws_chave_r { get; set; }
        public _REDEF_VP0437B_WS_CHAVE_R WS_CHAVE_R
        {
            get { _ws_chave_r = new _REDEF_VP0437B_WS_CHAVE_R(); _.Move(WS_CHAVE, _ws_chave_r); VarBasis.RedefinePassValue(WS_CHAVE, _ws_chave_r, WS_CHAVE); _ws_chave_r.ValueChanged += () => { _.Move(_ws_chave_r, WS_CHAVE); }; return _ws_chave_r; }
            set { VarBasis.RedefinePassValue(value, _ws_chave_r, WS_CHAVE); }
        }  //Redefines
        public class _REDEF_VP0437B_WS_CHAVE_R : VarBasis
        {
            /*"      10      WS-NUM-APOLICE      PIC  9(013).*/
            public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"      10      WS-CODSUBES         PIC  9(004).*/
            public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      10      WS-CODOPER          PIC  9(003).*/
            public IntBasis WS_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05            AC-LIDOS            PIC 9(006) VALUE ZEROES.*/

            public _REDEF_VP0437B_WS_CHAVE_R()
            {
                WS_NUM_APOLICE.ValueChanged += OnValueChanged;
                WS_CODSUBES.ValueChanged += OnValueChanged;
                WS_CODOPER.ValueChanged += OnValueChanged;
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
        public VP0437B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new VP0437B_LK_PROSOMU1();
        public class VP0437B_LK_PROSOMU1 : VarBasis
        {
            /*"      10          LK-DATA-SOM         PIC 9(008).*/
            public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      10          LK-DATA-SOM-R       REDEFINES                  LK-DATA-SOM.*/
            private _REDEF_VP0437B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
            public _REDEF_VP0437B_LK_DATA_SOM_R LK_DATA_SOM_R
            {
                get { _lk_data_som_r = new _REDEF_VP0437B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
            }  //Redefines
            public class _REDEF_VP0437B_LK_DATA_SOM_R : VarBasis
            {
                /*"        15        LK-DIA-SOM          PIC 9(002).*/
                public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        15        LK-MES-SOM          PIC 9(002).*/
                public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        15        LK-ANO-SOM          PIC 9(004).*/
                public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          LK-QTDIAS           PIC S9(005) COMP-3                                                  VALUE +1.*/

                public _REDEF_VP0437B_LK_DATA_SOM_R()
                {
                    LK_DIA_SOM.ValueChanged += OnValueChanged;
                    LK_MES_SOM.ValueChanged += OnValueChanged;
                    LK_ANO_SOM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
            /*"      10          LK-DATA-CALC        PIC 9(008).*/
            public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      10          LK-DATA-CALC-R      REDEFINES                  LK-DATA-CALC.*/
            private _REDEF_VP0437B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
            public _REDEF_VP0437B_LK_DATA_CALC_R LK_DATA_CALC_R
            {
                get { _lk_data_calc_r = new _REDEF_VP0437B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
            }  //Redefines
            public class _REDEF_VP0437B_LK_DATA_CALC_R : VarBasis
            {
                /*"        15        LK-DIA-CALC         PIC 9(002).*/
                public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        15        LK-MES-CALC         PIC 9(002).*/
                public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        15        LK-ANO-CALC         PIC 9(004).*/
                public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01                PARAMETROS.*/

                public _REDEF_VP0437B_LK_DATA_CALC_R()
                {
                    LK_DIA_CALC.ValueChanged += OnValueChanged;
                    LK_MES_CALC.ValueChanged += OnValueChanged;
                    LK_ANO_CALC.ValueChanged += OnValueChanged;
                }

            }
        }
        public VP0437B_PARAMETROS PARAMETROS { get; set; } = new VP0437B_PARAMETROS();
        public class VP0437B_PARAMETROS : VarBasis
        {
            /*"  05              LK-APOLICE          PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05              LK-SUBGRUPO         PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05              LK-IDADE            PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05              LK-NASCIMENTO.*/
            public VP0437B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VP0437B_LK_NASCIMENTO();
            public class VP0437B_LK_NASCIMENTO : VarBasis
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
            /*"01  VG0716S-COD-FONTE                PIC  S9(004) COMP.*/
        }
        public IntBasis VG0716S_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-COD-PRODUTO              PIC  S9(004) COMP.*/
        public IntBasis VG0716S_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-NUM-PROPOSTA             PIC  S9(015)    COMP-3.*/
        public IntBasis VG0716S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  VG0716S-VLR-MENSALIDADE          PIC  S9(008)V99 COMP-3.*/
        public DoubleBasis VG0716S_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
        /*"01  VG0716S-NUM-PLANO                PIC  S9(004) COMP.*/
        public IntBasis VG0716S_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-NUM-SERIE                PIC  S9(004) COMP.*/
        public IntBasis VG0716S_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-NUM-TITULO               PIC  S9(009) COMP.*/
        public IntBasis VG0716S_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  VG0716S-IND-DV                   PIC  S9(004) COMP.*/
        public IntBasis VG0716S_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-DTH-INI-VIGENCIA         PIC  X(010).*/
        public StringBasis VG0716S_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  VG0716S-DTH-FIM-VIGENCIA         PIC  X(010).*/
        public StringBasis VG0716S_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  VG0716S-DES-COMBINACAO           PIC  X(020).*/
        public StringBasis VG0716S_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  VG0716S-COD-STA-TITULO           PIC  X(003).*/
        public StringBasis VG0716S_COD_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  VG0716S-SQLCODE                  PIC  S9(004) COMP.*/
        public IntBasis VG0716S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-COD-RETORNO              PIC  S9(004) COMP.*/
        public IntBasis VG0716S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VG0716S-DES-MENSAGEM             PIC   X(070).*/
        public StringBasis VG0716S_DES_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01                TAB-MESES1.*/
        public VP0437B_TAB_MESES1 TAB_MESES1 { get; set; } = new VP0437B_TAB_MESES1();
        public class VP0437B_TAB_MESES1 : VarBasis
        {
            /*"    05            FILLER     PIC X(009) VALUE ' janeiro '.*/
            public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" janeiro ");
            /*"    05            FILLER     PIC X(009) VALUE 'fevereiro'.*/
            public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"fevereiro");
            /*"    05            FILLER     PIC X(009) VALUE '  marco  '.*/
            public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  marco  ");
            /*"    05            FILLER     PIC X(009) VALUE '  abril  '.*/
            public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  abril  ");
            /*"    05            FILLER     PIC X(009) VALUE '  maio   '.*/
            public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  maio   ");
            /*"    05            FILLER     PIC X(009) VALUE '  junho  '.*/
            public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  junho  ");
            /*"    05            FILLER     PIC X(009) VALUE '  julho  '.*/
            public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  julho  ");
            /*"    05            FILLER     PIC X(009) VALUE '  agosto '.*/
            public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  agosto ");
            /*"    05            FILLER     PIC X(009) VALUE 'setembro '.*/
            public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"setembro ");
            /*"    05            FILLER     PIC X(009) VALUE ' outubro '.*/
            public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" outubro ");
            /*"    05            FILLER     PIC X(009) VALUE 'novembro '.*/
            public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"novembro ");
            /*"    05            FILLER     PIC X(009) VALUE 'dezembro '.*/
            public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"dezembro ");
            /*"01                TAB-MESES1-R REDEFINES TAB-MESES1.*/
        }
        private _REDEF_VP0437B_TAB_MESES1_R _tab_meses1_r { get; set; }
        public _REDEF_VP0437B_TAB_MESES1_R TAB_MESES1_R
        {
            get { _tab_meses1_r = new _REDEF_VP0437B_TAB_MESES1_R(); _.Move(TAB_MESES1, _tab_meses1_r); VarBasis.RedefinePassValue(TAB_MESES1, _tab_meses1_r, TAB_MESES1); _tab_meses1_r.ValueChanged += () => { _.Move(_tab_meses1_r, TAB_MESES1); }; return _tab_meses1_r; }
            set { VarBasis.RedefinePassValue(value, _tab_meses1_r, TAB_MESES1); }
        }  //Redefines
        public class _REDEF_VP0437B_TAB_MESES1_R : VarBasis
        {
            /*"    05            TAB-MES1   OCCURS 12 TIMES                             PIC X(009).*/
            public ListBasis<StringBasis, string> TAB_MES1 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
            /*"01                WS-DESCRICAO-DIA.*/

            public _REDEF_VP0437B_TAB_MESES1_R()
            {
                TAB_MES1.ValueChanged += OnValueChanged;
            }

        }
        public VP0437B_WS_DESCRICAO_DIA WS_DESCRICAO_DIA { get; set; } = new VP0437B_WS_DESCRICAO_DIA();
        public class VP0437B_WS_DESCRICAO_DIA : VarBasis
        {
            /*"    05            FILLER              PIC X(002) VALUE SPACES.*/
            public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05            WS-DESC-DIA         PIC 9(002).*/
            public IntBasis WS_DESC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            FILLER              PIC X(002) VALUE SPACES.*/
            public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05            WS-DESC-MES         PIC X(009).*/
            public StringBasis WS_DESC_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"    05            FILLER              PIC X(006) VALUE '  de  '.*/
            public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"  de  ");
            /*"    05            WS-DESC-ANO         PIC 9(004).*/
            public IntBasis WS_DESC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01                TAB-FILIAL.*/
        }
        public VP0437B_TAB_FILIAL TAB_FILIAL { get; set; } = new VP0437B_TAB_FILIAL();
        public class VP0437B_TAB_FILIAL : VarBasis
        {
            /*"    05            FILLER              OCCURS  99  TIMES.*/
            public ListBasis<VP0437B_FILLER_201> FILLER_201 { get; set; } = new ListBasis<VP0437B_FILLER_201>(99);
            public class VP0437B_FILLER_201 : VarBasis
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
        public VP0437B_TABELA_CEP TABELA_CEP { get; set; } = new VP0437B_TABELA_CEP();
        public class VP0437B_TABELA_CEP : VarBasis
        {
            /*"    05            CEP                 OCCURS  2000 TIMES.*/
            public ListBasis<VP0437B_CEP> CEP { get; set; } = new ListBasis<VP0437B_CEP>(2000);
            public class VP0437B_CEP : VarBasis
            {
                /*"      10          TAB-FX-CEP-G        PIC 9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          TAB-FAIXAS.*/
                public VP0437B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new VP0437B_TAB_FAIXAS();
                public class VP0437B_TAB_FAIXAS : VarBasis
                {
                    /*"        15        TAB-FX-INI          PIC 9(008).*/
                    public IntBasis TAB_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15        TAB-FX-FIM          PIC 9(008).*/
                    public IntBasis TAB_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15        TAB-FX-NOME         PIC X(072).*/
                    public StringBasis TAB_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"        15        TAB-FX-CENTR        PIC X(072).*/
                    public StringBasis TAB_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"01                TABELA-TOTAIS.*/
                }
            }
        }
        public VP0437B_TABELA_TOTAIS TABELA_TOTAIS { get; set; } = new VP0437B_TABELA_TOTAIS();
        public class VP0437B_TABELA_TOTAIS : VarBasis
        {
            /*"    05            TAB-TOTAIS          OCCURS  2000 TIMES.*/
            public ListBasis<VP0437B_TAB_TOTAIS> TAB_TOTAIS { get; set; } = new ListBasis<VP0437B_TAB_TOTAIS>(2000);
            public class VP0437B_TAB_TOTAIS : VarBasis
            {
                /*"      10          TAB1-OBJI           PIC 9(006).*/
                public IntBasis TAB1_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10          TAB1-OBJF           PIC 9(006).*/
                public IntBasis TAB1_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10          TAB1-AMARI          PIC 9(006).*/
                public IntBasis TAB1_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10          TAB1-AMARF          PIC 9(006).*/
                public IntBasis TAB1_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10          TAB1-QTD-OBJ        PIC 9(006).*/
                public IntBasis TAB1_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10          TAB1-QTD-AMAR       PIC 9(006).*/
                public IntBasis TAB1_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"01            TABELA-MSG.*/
            }
        }
        public VP0437B_TABELA_MSG TABELA_MSG { get; set; } = new VP0437B_TABELA_MSG();
        public class VP0437B_TABELA_MSG : VarBasis
        {
            /*"    05        TAB-MSG             OCCURS 2000  TIMES.*/
            public ListBasis<VP0437B_TAB_MSG> TAB_MSG { get; set; } = new ListBasis<VP0437B_TAB_MSG>(2000);
            public class VP0437B_TAB_MSG : VarBasis
            {
                /*"      10      TABJ-CHAVE          PIC  X(020).*/
                public StringBasis TABJ_CHAVE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      TABJ-CHAVE-R        REDEFINES              TABJ-CHAVE.*/
                private _REDEF_VP0437B_TABJ_CHAVE_R _tabj_chave_r { get; set; }
                public _REDEF_VP0437B_TABJ_CHAVE_R TABJ_CHAVE_R
                {
                    get { _tabj_chave_r = new _REDEF_VP0437B_TABJ_CHAVE_R(); _.Move(TABJ_CHAVE, _tabj_chave_r); VarBasis.RedefinePassValue(TABJ_CHAVE, _tabj_chave_r, TABJ_CHAVE); _tabj_chave_r.ValueChanged += () => { _.Move(_tabj_chave_r, TABJ_CHAVE); }; return _tabj_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tabj_chave_r, TABJ_CHAVE); }
                }  //Redefines
                public class _REDEF_VP0437B_TABJ_CHAVE_R : VarBasis
                {
                    /*"        15    TABJ-APOLICE        PIC  9(013).*/
                    public IntBasis TABJ_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"        15    TABJ-CODSUBES       PIC  9(004).*/
                    public IntBasis TABJ_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15    TABJ-CODOPER        PIC  9(003).*/
                    public IntBasis TABJ_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"      10      TABJ-JDE            PIC  X(008).*/

                    public _REDEF_VP0437B_TABJ_CHAVE_R()
                    {
                        TABJ_APOLICE.ValueChanged += OnValueChanged;
                        TABJ_CODSUBES.ValueChanged += OnValueChanged;
                        TABJ_CODOPER.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis TABJ_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      10      TABJ-JDL            PIC  X(008).*/
                public StringBasis TABJ_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01                TB99.*/
            }
        }
        public VP0437B_TB99 TB99 { get; set; } = new VP0437B_TB99();
        public class VP0437B_TB99 : VarBasis
        {
            /*"    03            TB99-CONT           OCCURS  100  TIMES.*/
            public ListBasis<VP0437B_TB99_CONT> TB99_CONT { get; set; } = new ListBasis<VP0437B_TB99_CONT>(100);
            public class VP0437B_TB99_CONT : VarBasis
            {
                /*"       05         TB99-NOME-BENEF     PIC X(040).*/
                public StringBasis TB99_NOME_BENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       05         TB99-NUM-CPF        PIC 9(011).*/
                public IntBasis TB99_NUM_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
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
        public VP0437B_TABELA_NOMES TABELA_NOMES { get; set; } = new VP0437B_TABELA_NOMES();
        public class VP0437B_TABELA_NOMES : VarBasis
        {
            /*"    05            TAB-NOMES.*/
            public VP0437B_TAB_NOMES TAB_NOMES { get; set; } = new VP0437B_TAB_NOMES();
            public class VP0437B_TAB_NOMES : VarBasis
            {
                /*"      10          FILLER              PIC X(040).*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05            TAB-NOMES-R         REDEFINES  TAB-NOMES.*/
            }
            private _REDEF_VP0437B_TAB_NOMES_R _tab_nomes_r { get; set; }
            public _REDEF_VP0437B_TAB_NOMES_R TAB_NOMES_R
            {
                get { _tab_nomes_r = new _REDEF_VP0437B_TAB_NOMES_R(); _.Move(TAB_NOMES, _tab_nomes_r); VarBasis.RedefinePassValue(TAB_NOMES, _tab_nomes_r, TAB_NOMES); _tab_nomes_r.ValueChanged += () => { _.Move(_tab_nomes_r, TAB_NOMES); }; return _tab_nomes_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes_r, TAB_NOMES); }
            }  //Redefines
            public class _REDEF_VP0437B_TAB_NOMES_R : VarBasis
            {
                /*"      10          TAB-NOME            OCCURS  40  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 40);
                /*"01                TABELA-NOMES1.*/

                public _REDEF_VP0437B_TAB_NOMES_R()
                {
                    TAB_NOME.ValueChanged += OnValueChanged;
                }

            }
        }
        public VP0437B_TABELA_NOMES1 TABELA_NOMES1 { get; set; } = new VP0437B_TABELA_NOMES1();
        public class VP0437B_TABELA_NOMES1 : VarBasis
        {
            /*"    05            TAB-NOMES1.*/
            public VP0437B_TAB_NOMES1 TAB_NOMES1 { get; set; } = new VP0437B_TAB_NOMES1();
            public class VP0437B_TAB_NOMES1 : VarBasis
            {
                /*"      10          FILLER              PIC X(040).*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05            TAB-NOMES1-R        REDEFINES  TAB-NOMES1.*/
            }
            private _REDEF_VP0437B_TAB_NOMES1_R _tab_nomes1_r { get; set; }
            public _REDEF_VP0437B_TAB_NOMES1_R TAB_NOMES1_R
            {
                get { _tab_nomes1_r = new _REDEF_VP0437B_TAB_NOMES1_R(); _.Move(TAB_NOMES1, _tab_nomes1_r); VarBasis.RedefinePassValue(TAB_NOMES1, _tab_nomes1_r, TAB_NOMES1); _tab_nomes1_r.ValueChanged += () => { _.Move(_tab_nomes1_r, TAB_NOMES1); }; return _tab_nomes1_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes1_r, TAB_NOMES1); }
            }  //Redefines
            public class _REDEF_VP0437B_TAB_NOMES1_R : VarBasis
            {
                /*"      10          TAB-NOME1           OCCURS  40  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME1 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 40);
                /*"01                LK-LINK.*/

                public _REDEF_VP0437B_TAB_NOMES1_R()
                {
                    TAB_NOME1.ValueChanged += OnValueChanged;
                }

            }
        }
        public VP0437B_LK_LINK LK_LINK { get; set; } = new VP0437B_LK_LINK();
        public class VP0437B_LK_LINK : VarBasis
        {
            /*"    05            LK-RTCODE           PIC S9(004) VALUE +0 COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            LK-TAMANHO          PIC S9(004) VALUE +40 COMP*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"    05            LK-TITULO           PIC  X(132) VALUE SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01                TABELA-COBER.*/
        }
        public VP0437B_TABELA_COBER TABELA_COBER { get; set; } = new VP0437B_TABELA_COBER();
        public class VP0437B_TABELA_COBER : VarBasis
        {
            /*"    05            TAB-COBER.*/
            public VP0437B_TAB_COBER TAB_COBER { get; set; } = new VP0437B_TAB_COBER();
            public class VP0437B_TAB_COBER : VarBasis
            {
                /*"      10          FILLER              PIC X(040)  VALUE                 'COBERTURA DOENCA GRAVE.............: R$ '.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"COBERTURA DOENCA GRAVE.............: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'SERVICO ASSITENCIA FUNERAL.........: R$ '.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SERVICO ASSITENCIA FUNERAL.........: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ADIANTAMENTO AUXILIO FUNERAL(ATE)..: R$ '.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ADIANTAMENTO AUXILIO FUNERAL(ATE)..: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'CESTA BASICA.......................: R$ '.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"CESTA BASICA.......................: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'AUXILIO ALIMENTACAO................: R$ '.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"AUXILIO ALIMENTACAO................: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'DOENCAS CONGENITAS GRAVES..........: R$ '.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DOENCAS CONGENITAS GRAVES..........: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'INDENIZACAO RESCISAO TRABALHISTA...: R$ '.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"INDENIZACAO RESCISAO TRABALHISTA...: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'DESEMPREGO INVOLUNTARIO............: R$ '.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESEMPREGO INVOLUNTARIO............: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'PERDA DE RENDA (AUTONOMO)..........: R$ '.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"PERDA DE RENDA (AUTONOMO)..........: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'REMISSAO PREMIO DESEMPREGO INVOLUNTARIO '.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"REMISSAO PREMIO DESEMPREGO INVOLUNTARIO ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'DIAGNOSTICO DE CANCER..............: R$ '.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DIAGNOSTICO DE CANCER..............: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'SERVICO ASSISTENCIA VIAGEM.........: R$ '.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SERVICO ASSISTENCIA VIAGEM.........: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'EXTRAVIO DE BAGAGEM................: R$ '.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"EXTRAVIO DE BAGAGEM................: R$ ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'REMISSAO PREMIO DIAGNOSTICO CANCER      '.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"REMISSAO PREMIO DIAGNOSTICO CANCER      ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'REMISSAO PREMIO INDENIZACAO CDG         '.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"REMISSAO PREMIO INDENIZACAO CDG         ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ASSISTENCIA FARMACIA                    '.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ASSISTENCIA FARMACIA                    ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ASSISTENCIA RESIDENCIAL                 '.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ASSISTENCIA RESIDENCIAL                 ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ASSISTENCIA VIAGEM                      '.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ASSISTENCIA VIAGEM                      ");
                /*"      10          FILLER              PIC X(040)  VALUE                 'ORIENTACAO NUTRICIONAL                  '.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ORIENTACAO NUTRICIONAL                  ");
                /*"    05            TAB-COBER-R         REDEFINES                  TAB-COBER.*/
            }
            private _REDEF_VP0437B_TAB_COBER_R _tab_cober_r { get; set; }
            public _REDEF_VP0437B_TAB_COBER_R TAB_COBER_R
            {
                get { _tab_cober_r = new _REDEF_VP0437B_TAB_COBER_R(); _.Move(TAB_COBER, _tab_cober_r); VarBasis.RedefinePassValue(TAB_COBER, _tab_cober_r, TAB_COBER); _tab_cober_r.ValueChanged += () => { _.Move(_tab_cober_r, TAB_COBER); }; return _tab_cober_r; }
                set { VarBasis.RedefinePassValue(value, _tab_cober_r, TAB_COBER); }
            }  //Redefines
            public class _REDEF_VP0437B_TAB_COBER_R : VarBasis
            {
                /*"      10          TAB-COBER-DESCR     OCCURS  19  TIMES                                      PIC X(040).*/
                public ListBasis<StringBasis, string> TAB_COBER_DESCR { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "40", "X(040)."), 19);
                /*"01                TABELA-MESES.*/

                public _REDEF_VP0437B_TAB_COBER_R()
                {
                    TAB_COBER_DESCR.ValueChanged += OnValueChanged;
                }

            }
        }
        public VP0437B_TABELA_MESES TABELA_MESES { get; set; } = new VP0437B_TABELA_MESES();
        public class VP0437B_TABELA_MESES : VarBasis
        {
            /*"    05            TAB-MESES.*/
            public VP0437B_TAB_MESES TAB_MESES { get; set; } = new VP0437B_TAB_MESES();
            public class VP0437B_TAB_MESES : VarBasis
            {
                /*"      10          FILLER           PIC X(009) VALUE '  JANEIRO'.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"      10          FILLER           PIC X(009) VALUE 'FEVEREIRO'.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"      10          FILLER           PIC X(009) VALUE '    MARCO'.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"      10          FILLER           PIC X(009) VALUE '    ABRIL'.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"      10          FILLER           PIC X(009) VALUE '     MAIO'.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"      10          FILLER           PIC X(009) VALUE '    JUNHO'.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"      10          FILLER           PIC X(009) VALUE '    JULHO'.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"      10          FILLER           PIC X(009) VALUE '   AGOSTO'.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"      10          FILLER           PIC X(009) VALUE ' SETEMBRO'.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"      10          FILLER           PIC X(009) VALUE '  OUTUBRO'.*/
                public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"      10          FILLER           PIC X(009) VALUE ' NOVEMBRO'.*/
                public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"      10          FILLER           PIC X(009) VALUE ' DEZEMBRO'.*/
                public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"    05            TAB-MESES-R         REDEFINES                  TAB-MESES.*/
            }
            private _REDEF_VP0437B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_VP0437B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_VP0437B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_VP0437B_TAB_MESES_R : VarBasis
            {
                /*"      10          TAB-MES             OCCURS  12  TIMES                                      PIC X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01                WABEND.*/

                public _REDEF_VP0437B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public VP0437B_WABEND WABEND { get; set; } = new VP0437B_WABEND();
        public class VP0437B_WABEND : VarBasis
        {
            /*"      05          FILLER              PIC X(010) VALUE                 ' VP0437B'.*/
            public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VP0437B");
            /*"      05          FILLER              PIC X(026) VALUE                 ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05          WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05          FILLER              PIC X(013) VALUE                 ' *** SQLCODE '.*/
            public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05          WSQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"      05          WSQLERRMC           PIC X(070).*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }


        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.GEOBJECT GEOBJECT { get; set; } = new Dclgens.GEOBJECT();
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
        public Dclgens.AGENCIAS AGENCIAS { get; set; } = new Dclgens.AGENCIAS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PRODUTOR PRODUTOR { get; set; } = new Dclgens.PRODUTOR();
        public Dclgens.APOLICOR APOLICOR { get; set; } = new Dclgens.APOLICOR();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.FCTITULO FCTITULO { get; set; } = new Dclgens.FCTITULO();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public VP0437B_CFAIXACEP CFAIXACEP { get; set; } = new VP0437B_CFAIXACEP();
        public VP0437B_CMSG CMSG { get; set; } = new VP0437B_CMSG();
        public VP0437B_V1AGENCEF V1AGENCEF { get; set; } = new VP0437B_V1AGENCEF();
        public VP0437B_CRELAT CRELAT { get; set; } = new VP0437B_CRELAT();
        public VP0437B_COBER COBER { get; set; } = new VP0437B_COBER();
        public VP0437B_V0BENEF V0BENEF { get; set; } = new VP0437B_V0BENEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVP0437B_FILE_NAME_P, string SVP0437B_FILE_NAME_P, string FVP0437B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVP0437B.SetFile(RVP0437B_FILE_NAME_P);
                SVP0437B.SetFile(SVP0437B_FILE_NAME_P);
                FVP0437B.SetFile(FVP0437B_FILE_NAME_P);

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
            /*" -1435- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", WABEND.WNR_EXEC_SQL);

            /*" -1436- DISPLAY ' ' */
            _.Display($" ");

            /*" -1438- DISPLAY '--------------------------------------------------' '--------------------------------------------------' */
            _.Display($"----------------------------------------------------------------------------------------------------");

            /*" -1445- DISPLAY 'VERSAO V.39 - DEMANDA 256312 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"VERSAO V.39 - DEMANDA 256312 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1447- DISPLAY '--------------------------------------------------' '--------------------------------------------------' */
            _.Display($"----------------------------------------------------------------------------------------------------");

            /*" -1448- DISPLAY ' ' */
            _.Display($" ");

            /*" -1455- DISPLAY 'INICIOU PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1456- DISPLAY ' ' */
            _.Display($" ");

            /*" -1458- DISPLAY '* DATA MOVIMENTO: ' WS-DATA-MOV */
            _.Display($"* DATA MOVIMENTO: {WS_DATA_MOV}");

            /*" -1460- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -1462- MOVE ZEROS TO TABELA-TOTAIS. */
            _.Move(0, TABELA_TOTAIS);

            /*" -1464- INITIALIZE TAB-FILIAL. */
            _.Initialize(
                TAB_FILIAL
            );

            /*" -1466- PERFORM R0500-00-DECLARE-AGENCCEF. */

            R0500_00_DECLARE_AGENCCEF_SECTION();

            /*" -1468- PERFORM R0510-00-FETCH-AGENCCEF. */

            R0510_00_FETCH_AGENCCEF_SECTION();

            /*" -1469- IF WFIM-AGENCCEF NOT EQUAL SPACES */

            if (!WFIM_AGENCCEF.IsEmpty())
            {

                /*" -1470- DISPLAY 'R0000 - PROBLEMA NO FETCH DA AGENCCEF ' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA AGENCCEF ");

                /*" -1472- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1475- PERFORM R0520-00-CARREGA-FILIAL UNTIL WFIM-AGENCCEF EQUAL 'S' . */

            while (!(WFIM_AGENCCEF == "S"))
            {

                R0520_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1477- PERFORM R0900-00-DECLARE-RELATORI. */

            R0900_00_DECLARE_RELATORI_SECTION();

            /*" -1479- PERFORM R0910-00-FETCH-RELATORI. */

            R0910_00_FETCH_RELATORI_SECTION();

            /*" -1480- IF WFIM-RELATORI EQUAL 'S' */

            if (WFIM_RELATORI == "S")
            {

                /*" -1481- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1482- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1484- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1485- IF WFIM-SISTEMAS NOT EQUAL SPACES */

            if (!WFIM_SISTEMAS.IsEmpty())
            {

                /*" -1487- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1489- PERFORM R0200-00-CARREGA-FAIXACEP. */

            R0200_00_CARREGA_FAIXACEP_SECTION();

            /*" -1491- PERFORM R0300-00-CARREGA-COBMENVG. */

            R0300_00_CARREGA_COBMENVG_SECTION();

            /*" -1493- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1499- SORT SVP0437B ON ASCENDING KEY SVA-CODRELAT SVA-NRAPOLICE SVA-CODSUBES SVA-OPRCTADEB INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SVP0437B.Sort("SVA-CODRELAT,SVA-NRAPOLICE,SVA-CODSUBES,SVA-OPRCTADEB", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -1502- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1503- DISPLAY '*** VP0437B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VP0437B *** PROBLEMAS NO SORT ");

                /*" -1504- DISPLAY '*** VP0437B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VP0437B *** SORT-RETURN = {SORT_RETURN}");

                /*" -1505- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -1505- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1511- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1511- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1515- DISPLAY '******  VP0437B *********' */
            _.Display($"******  VP0437B *********");

            /*" -1516- DISPLAY 'LIDOS V0RELATORIOS       ' AC-L-RELATORI. */
            _.Display($"LIDOS V0RELATORIOS       {AC_L_RELATORI}");

            /*" -1517- DISPLAY 'CERTIFICADOS IMPRESSOS   ' AC-IMPRESSOS. */
            _.Display($"CERTIFICADOS IMPRESSOS   {AC_IMPRESSOS}");

            /*" -1518- DISPLAY 'DESPREZADOS CANCELAMEN   ' AC-DESPR-CANCEL. */
            _.Display($"DESPREZADOS CANCELAMEN   {AC_DESPR_CANCEL}");

            /*" -1519- DISPLAY 'DESPREZADOS V0SEGURAVG   ' AC-DESPR-SEGURAVG. */
            _.Display($"DESPREZADOS V0SEGURAVG   {AC_DESPR_SEGURAVG}");

            /*" -1520- DISPLAY 'DESPREZADOS V0OPCAOPAGVA ' AC-DESPR-OPCAOPAG. */
            _.Display($"DESPREZADOS V0OPCAOPAGVA {AC_DESPR_OPCAOPAG}");

            /*" -1521- DISPLAY 'DESPREZADOS V0CLIENTE    ' AC-DESPR-CLIENTE. */
            _.Display($"DESPREZADOS V0CLIENTE    {AC_DESPR_CLIENTE}");

            /*" -1522- DISPLAY 'DESPREZADOS V0ENDERECO   ' AC-DESPR-ENDERECO. */
            _.Display($"DESPREZADOS V0ENDERECO   {AC_DESPR_ENDERECO}");

            /*" -1523- DISPLAY 'DESPREZADOS V0COBERPRO   ' AC-DESPR-COBERPRO. */
            _.Display($"DESPREZADOS V0COBERPRO   {AC_DESPR_COBERPRO}");

            /*" -1524- DISPLAY 'DESPREZADOS CODRELAT     ' AC-DESPR-CODRELAT. */
            _.Display($"DESPREZADOS CODRELAT     {AC_DESPR_CODRELAT}");

            /*" -1525- DISPLAY '********  SORT  *********' */
            _.Display($"********  SORT  *********");

            /*" -1526- DISPLAY 'DESPREZADOS V0COBERAPOL  ' AC-DESPR-APOLICOB. */
            _.Display($"DESPREZADOS V0COBERAPOL  {AC_DESPR_APOLICOB}");

            /*" -1527- DISPLAY 'DESPREZADOS V0HISTSEGVG  ' AC-DESPR-SEGVGAPH. */
            _.Display($"DESPREZADOS V0HISTSEGVG  {AC_DESPR_SEGVGAPH}");

            /*" -1528- DISPLAY 'DESPREZADOS V0COTACAO    ' AC-DESPR-MOEDACOT. */
            _.Display($"DESPREZADOS V0COTACAO    {AC_DESPR_MOEDACOT}");

            /*" -1529- DISPLAY '                         ' . */
            _.Display($"                         ");

            /*" -1531- DISPLAY '*--------------------------------------------------' '----------------------' */
            _.Display($"*------------------------------------------------------------------------");

            /*" -1534- DISPLAY 'QTD DE REGISTROS GRAVADOS NA TABELA ' 'SEGUROS.GE_OBJETO_ECT DO PRODUTO 7707 = ' WS-QTD-GRAVADOS */

            $"QTD DE REGISTROS GRAVADOS NA TABELA SEGUROS.GE_OBJETO_ECT DO PRODUTO 7707 = {WS_QTD_GRAVADOS}"
            .Display();

            /*" -1536- DISPLAY '*--------------------------------------------------' '----------------------' */
            _.Display($"*------------------------------------------------------------------------");

            /*" -1538- DISPLAY '                         ' . */
            _.Display($"                         ");

            /*" -1539- DISPLAY '*** VP0437B - TERMINO NORMAL ***' */
            _.Display($"*** VP0437B - TERMINO NORMAL ***");

            /*" -1539- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1548- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-RELATORI EQUAL 'S' . */

            while (!(WFIM_RELATORI == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -1558- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1562- MOVE ZEROS TO WIND. */
            _.Move(0, WIND);

            /*" -1563- MOVE SPACES TO LF02-LINHA02 */
            _.Move("", LF02_LINHA02);

            /*" -1569- STRING '(' FUNCTION LOWER-CASE( 'CO03.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LF02-LINHA02 */
            #region STRING
            var spl1 = "(" + "CO03.DBM".ToString().ToLower() + ") STARTDBM";
            _.Move(spl1, LF02_LINHA02);
            #endregion

            /*" -1570- MOVE SPACES TO LR02-LINHA02 */
            _.Move("", LR02_LINHA02);

            /*" -1574- STRING '(' FUNCTION LOWER-CASE( 'CO05.JDT' ) ') STARTLM' DELIMITED BY SIZE INTO LR02-LINHA02 */
            #region STRING
            var spl2 = "(" + "CO05.JDT".ToString().ToLower() + ") STARTLM";
            _.Move(spl2, LR02_LINHA02);
            #endregion

            /*" -1576- PERFORM R2300-00-LE-SORT. */

            R2300_00_LE_SORT_SECTION();

            /*" -1577- WRITE RVP0437B-RECORD FROM LC01-LINHA01 */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVP0437B_RECORD);

            RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1578- WRITE FVP0437B-RECORD FROM LC01-LINHA01 */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1579- WRITE FVP0437B-RECORD FROM LC02-LINHA02 */
            _.Move(AREA_DE_WORK.LC02_LINHA02.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1580- WRITE FVP0437B-RECORD FROM LC03-LINHA03 */
            _.Move(AREA_DE_WORK.LC03_LINHA03.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1581- WRITE FVP0437B-RECORD FROM LC04-LINHA04-01 */
            _.Move(AREA_DE_WORK.LC04_LINHA04_01.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1582- WRITE FVP0437B-RECORD FROM LC05-LINHA05-01 */
            _.Move(AREA_DE_WORK.LC05_LINHA05_01.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1583- WRITE FVP0437B-RECORD FROM LC06-LINHA06-01 */
            _.Move(AREA_DE_WORK.LC06_LINHA06_01.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1584- WRITE FVP0437B-RECORD FROM LC07-LINHA07 */
            _.Move(AREA_DE_WORK.LC07_LINHA07.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1586- WRITE FVP0437B-RECORD FROM LC08-LINHA08. */
            _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1589- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -1591- WRITE FVP0437B-RECORD FROM LC12-LINHA12. */
            _.Move(LC12_LINHA12.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -1591- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -1602- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -1615- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -1618- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1619- DISPLAY 'VP0437B - SISTEMA FI NAO ESTA CADASTRADO' */
                _.Display($"VP0437B - SISTEMA FI NAO ESTA CADASTRADO");

                /*" -1620- MOVE 'S' TO WFIM-SISTEMAS */
                _.Move("S", WFIM_SISTEMAS);

                /*" -1622- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1625- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO WS-DESC-DIA DET3-DIA-CORRENTE DET6-DIA-CORRENTE */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), WS_DESCRICAO_DIA.WS_DESC_DIA, DETALHE_DS03.DET3_DIA_CORRENTE, DETALHE_DS06.DET6_DIA_CORRENTE);

            /*" -1628- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO W77-MES */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), W77_MES);

            /*" -1631- MOVE TAB-MES1 (W77-MES) TO WS-DESC-MES DET3-MES-CORRENTE DET6-MES-CORRENTE */
            _.Move(TAB_MESES1_R.TAB_MES1[W77_MES], WS_DESCRICAO_DIA.WS_DESC_MES, DETALHE_DS03.DET3_MES_CORRENTE, DETALHE_DS06.DET6_MES_CORRENTE);

            /*" -1634- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO WS-DESC-ANO DET3-ANO-CORRENTE DET6-ANO-CORRENTE */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), WS_DESCRICAO_DIA.WS_DESC_ANO, DETALHE_DS03.DET3_ANO_CORRENTE, DETALHE_DS06.DET6_ANO_CORRENTE);

            /*" -1637- MOVE V1SIST-CURRENT (9:2) TO WS-DIA-ATUAL. */
            _.Move(V1SIST_CURRENT.Substring(9, 2), WS_DATA_ATUAL.WS_DIA_ATUAL);

            /*" -1640- MOVE V1SIST-CURRENT (6:2) TO WS-MES-ATUAL. */
            _.Move(V1SIST_CURRENT.Substring(6, 2), WS_DATA_ATUAL.WS_MES_ATUAL);

            /*" -1643- MOVE V1SIST-CURRENT (1:4) TO WS-ANO-ATUAL. */
            _.Move(V1SIST_CURRENT.Substring(1, 4), WS_DATA_ATUAL.WS_ANO_ATUAL);

            /*" -1646- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO WS-DIA-MOV. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), WS_DATA_MOV.WS_DIA_MOV);

            /*" -1649- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO WS-MES-MOV. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), WS_DATA_MOV.WS_MES_MOV);

            /*" -1650- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO WS-ANO-MOV. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), WS_DATA_MOV.WS_ANO_MOV);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1615- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 1 YEAR, MONTH(DATA_MOV_ABERTO), YEAR(DATA_MOV_ABERTO), CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO-1, :V1SIST-MESREFER, :V1SIST-ANOREFER, :V1SIST-CURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_1, SISTEMAS_DATA_MOV_ABERTO_1);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
                _.Move(executed_1.V1SIST_CURRENT, V1SIST_CURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXACEP-SECTION */
        private void R0200_00_CARREGA_FAIXACEP_SECTION()
        {
            /*" -1661- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -1674- PERFORM R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1 */

            R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1();

            /*" -1676- PERFORM R0200_00_CARREGA_FAIXACEP_DB_OPEN_1 */

            R0200_00_CARREGA_FAIXACEP_DB_OPEN_1();

            /*" -1679- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1680- DISPLAY 'VP0437B - PROBLEMAS NA FAIXA_CEP' */
                _.Display($"VP0437B - PROBLEMAS NA FAIXA_CEP");

                /*" -1682- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1683- PERFORM R0210-00-FETCH-FAIXACEP UNTIL WFIM-FAIXACEP EQUAL 'S' . */

            while (!(WFIM_FAIXACEP == "S"))
            {

                R0210_00_FETCH_FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXACEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1()
        {
            /*" -1674- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO ORDER BY FAIXA END-EXEC. */
            CFAIXACEP = new VP0437B_CFAIXACEP(true);
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
            /*" -1676- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-DB-DECLARE-1 */
        public void R0300_00_CARREGA_COBMENVG_DB_DECLARE_1()
        {
            /*" -1742- EXEC SQL DECLARE CMSG CURSOR FOR SELECT NUM_APOLICE, CODSUBES, COD_OPERACAO, JDE, JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND COD_OPERACAO = 2 ORDER BY 1,2,3 END-EXEC. */
            CMSG = new VP0437B_CMSG(false);
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
							FROM SEGUROS.COBRANCA_MENS_VGAP 
							WHERE IDFORM = 'A4' 
							AND COD_OPERACAO = 2 
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
            /*" -1694- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WABEND.WNR_EXEC_SQL);

            /*" -1701- PERFORM R0210_00_FETCH_FAIXACEP_DB_FETCH_1 */

            R0210_00_FETCH_FAIXACEP_DB_FETCH_1();

            /*" -1704- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1705- MOVE 'S' TO WFIM-FAIXACEP */
                _.Move("S", WFIM_FAIXACEP);

                /*" -1705- PERFORM R0210_00_FETCH_FAIXACEP_DB_CLOSE_1 */

                R0210_00_FETCH_FAIXACEP_DB_CLOSE_1();

                /*" -1709- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1711- MOVE GEFAICEP-FAIXA TO TAB-FX-CEP-G (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FX_CEP_G);

            /*" -1713- MOVE GEFAICEP-CEP-INICIAL TO TAB-FX-INI (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -1715- MOVE GEFAICEP-CEP-FINAL TO TAB-FX-FIM (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -1717- MOVE GEFAICEP-DESCRICAO-FAIXA TO TAB-FX-NOME (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -1720- MOVE GEFAICEP-CENTRALIZADOR TO TAB-FX-CENTR (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -1720- GO TO R0210-00-FETCH-FAIXACEP. */
            new Task(() => R0210_00_FETCH_FAIXACEP_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-00-FETCH-FAIXACEP-DB-FETCH-1 */
        public void R0210_00_FETCH_FAIXACEP_DB_FETCH_1()
        {
            /*" -1701- EXEC SQL FETCH CFAIXACEP INTO :GEFAICEP-FAIXA, :GEFAICEP-CEP-INICIAL, :GEFAICEP-CEP-FINAL, :GEFAICEP-DESCRICAO-FAIXA, :GEFAICEP-CENTRALIZADOR END-EXEC. */

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
            /*" -1705- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-SECTION */
        private void R0300_00_CARREGA_COBMENVG_SECTION()
        {
            /*" -1731- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -1742- PERFORM R0300_00_CARREGA_COBMENVG_DB_DECLARE_1 */

            R0300_00_CARREGA_COBMENVG_DB_DECLARE_1();

            /*" -1744- PERFORM R0300_00_CARREGA_COBMENVG_DB_OPEN_1 */

            R0300_00_CARREGA_COBMENVG_DB_OPEN_1();

            /*" -1747- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1748- DISPLAY 'VP0437B - PROBLEMAS NA COBRANCA_MENS_VGAP ' */
                _.Display($"VP0437B - PROBLEMAS NA COBRANCA_MENS_VGAP ");

                /*" -1750- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1751- PERFORM R0310-00-FETCH-COBMENVG UNTIL WFIM-COBMENVG EQUAL 'S' . */

            while (!(WFIM_COBMENVG == "S"))
            {

                R0310_00_FETCH_COBMENVG_SECTION();
            }

        }

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-DB-OPEN-1 */
        public void R0300_00_CARREGA_COBMENVG_DB_OPEN_1()
        {
            /*" -1744- EXEC SQL OPEN CMSG END-EXEC. */

            CMSG.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-DB-DECLARE-1 */
        public void R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1()
        {
            /*" -1819- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT COD_FONTE, NOME_FONTE, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.FONTES WHERE COD_FONTE < 99 ORDER BY COD_FONTE END-EXEC. */
            V1AGENCEF = new VP0437B_V1AGENCEF(false);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-SECTION */
        private void R0310_00_FETCH_COBMENVG_SECTION()
        {
            /*" -1762- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", WABEND.WNR_EXEC_SQL);

            /*" -1769- PERFORM R0310_00_FETCH_COBMENVG_DB_FETCH_1 */

            R0310_00_FETCH_COBMENVG_DB_FETCH_1();

            /*" -1772- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1773- MOVE 'S' TO WFIM-COBMENVG */
                _.Move("S", WFIM_COBMENVG);

                /*" -1773- PERFORM R0310_00_FETCH_COBMENVG_DB_CLOSE_1 */

                R0310_00_FETCH_COBMENVG_DB_CLOSE_1();

                /*" -1776- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1778- ADD 1 TO WINDM. */
            WINDM.Value = WINDM + 1;

            /*" -1779- IF WINDM > 2000 */

            if (WINDM > 2000)
            {

                /*" -1780- MOVE 2000 TO WINDM */
                _.Move(2000, WINDM);

                /*" -1781- MOVE 'S' TO WFIM-COBMENVG */
                _.Move("S", WFIM_COBMENVG);

                /*" -1781- PERFORM R0310_00_FETCH_COBMENVG_DB_CLOSE_2 */

                R0310_00_FETCH_COBMENVG_DB_CLOSE_2();

                /*" -1784- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1786- MOVE COBMENVG-NUM-APOLICE TO TABJ-APOLICE (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE, TABELA_MSG.TAB_MSG[WINDM].TABJ_CHAVE_R.TABJ_APOLICE);

            /*" -1788- MOVE COBMENVG-CODSUBES TO TABJ-CODSUBES (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES, TABELA_MSG.TAB_MSG[WINDM].TABJ_CHAVE_R.TABJ_CODSUBES);

            /*" -1790- MOVE COBMENVG-COD-OPERACAO TO TABJ-CODOPER (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO, TABELA_MSG.TAB_MSG[WINDM].TABJ_CHAVE_R.TABJ_CODOPER);

            /*" -1792- MOVE COBMENVG-JDE TO TABJ-JDE (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, TABELA_MSG.TAB_MSG[WINDM].TABJ_JDE);

            /*" -1795- MOVE COBMENVG-JDL TO TABJ-JDL (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL, TABELA_MSG.TAB_MSG[WINDM].TABJ_JDL);

            /*" -1795- GO TO R0310-00-FETCH-COBMENVG. */
            new Task(() => R0310_00_FETCH_COBMENVG_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-FETCH-1 */
        public void R0310_00_FETCH_COBMENVG_DB_FETCH_1()
        {
            /*" -1769- EXEC SQL FETCH CMSG INTO :COBMENVG-NUM-APOLICE, :COBMENVG-CODSUBES, :COBMENVG-COD-OPERACAO, :COBMENVG-JDE, :COBMENVG-JDL END-EXEC. */

            if (CMSG.Fetch())
            {
                _.Move(CMSG.COBMENVG_NUM_APOLICE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE);
                _.Move(CMSG.COBMENVG_CODSUBES, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES);
                _.Move(CMSG.COBMENVG_COD_OPERACAO, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);
                _.Move(CMSG.COBMENVG_JDE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);
                _.Move(CMSG.COBMENVG_JDL, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-CLOSE-1 */
        public void R0310_00_FETCH_COBMENVG_DB_CLOSE_1()
        {
            /*" -1773- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-CLOSE-2 */
        public void R0310_00_FETCH_COBMENVG_DB_CLOSE_2()
        {
            /*" -1781- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-SECTION */
        private void R0500_00_DECLARE_AGENCCEF_SECTION()
        {
            /*" -1806- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -1819- PERFORM R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1 */

            R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1();

            /*" -1821- PERFORM R0500_00_DECLARE_AGENCCEF_DB_OPEN_1 */

            R0500_00_DECLARE_AGENCCEF_DB_OPEN_1();

            /*" -1824- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1825- DISPLAY 'R0500 - PROBLEMAS DECLARE (AGENCCEF) ..' */
                _.Display($"R0500 - PROBLEMAS DECLARE (AGENCCEF) ..");

                /*" -1826- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1826- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-DB-OPEN-1 */
        public void R0500_00_DECLARE_AGENCCEF_DB_OPEN_1()
        {
            /*" -1821- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-DECLARE-1 */
        public void R0900_00_DECLARE_RELATORI_DB_DECLARE_1()
        {
            /*" -1976- EXEC SQL DECLARE CRELAT CURSOR FOR SELECT DISTINCT A.COD_OPERACAO, A.COD_USUARIO, A.COD_RELATORIO, B.DATA_QUITACAO, B.NUM_APOLICE, B.COD_SUBGRUPO, B.NUM_CERTIFICADO, B.COD_PRODUTO, B.COD_CLIENTE, B.IDE_SEXO, B.SIT_REGISTRO, B.AGE_COBRANCA, B.COD_FONTE, B.IDADE, B.OCORR_HISTORICO, (B.DATA_QUITACAO + B.NUM_PRAZO_FIN MONTHS)-1 DAY, C.CODRELAT, C.PERI_PAGAMENTO, C.ORIG_PRODU , D.COD_EMPRESA FROM SEGUROS.RELATORIOS A, SEGUROS.PROPOSTAS_VA B, SEGUROS.PRODUTOS_VG C , SEGUROS.PRODUTO D WHERE A.SIT_REGISTRO = '0' AND B.COD_PRODUTO = 7707 AND A.COD_OPERACAO = 2 AND A.NUM_PARCELA = 2 AND B.SIT_REGISTRO <> '2' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.RAMO = 77 AND A.COD_RELATORIO = 'VP0437B' AND D.COD_PRODUTO = B.COD_PRODUTO UNION ALL SELECT DISTINCT A.COD_OPERACAO, A.COD_USUARIO, A.COD_RELATORIO, B.DATA_QUITACAO, B.NUM_APOLICE, B.COD_SUBGRUPO, B.NUM_CERTIFICADO, B.COD_PRODUTO, B.COD_CLIENTE, B.IDE_SEXO, B.SIT_REGISTRO, B.AGE_COBRANCA, B.COD_FONTE, B.IDADE, B.OCORR_HISTORICO, (B.DATA_QUITACAO + B.NUM_PRAZO_FIN MONTHS)-1 DAY, C.CODRELAT, C.PERI_PAGAMENTO, C.ORIG_PRODU , D.COD_EMPRESA FROM SEGUROS.RELATORIOS A, SEGUROS.PROPOSTAS_VA B, SEGUROS.PRODUTOS_VG C , SEGUROS.PRODUTO D WHERE A.SIT_REGISTRO = '0' AND DATE(A.TIMESTAMP) > '2017-05-13' AND B.COD_PRODUTO IN (7705,7713,7715,7725) AND A.COD_OPERACAO = 2 AND A.NUM_PARCELA = 2 AND B.SIT_REGISTRO <> '2' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.RAMO = 77 AND A.COD_RELATORIO = 'VP0437B' AND D.COD_PRODUTO = B.COD_PRODUTO WITH UR END-EXEC. */
            CRELAT = new VP0437B_CRELAT(false);
            string GetQuery_CRELAT()
            {
                var query = @$"SELECT DISTINCT 
							A.COD_OPERACAO
							, 
							A.COD_USUARIO
							, 
							A.COD_RELATORIO
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
							(B.DATA_QUITACAO 
							+ B.NUM_PRAZO_FIN MONTHS)-1 DAY
							, 
							C.CODRELAT
							, 
							C.PERI_PAGAMENTO
							, 
							C.ORIG_PRODU 
							, D.COD_EMPRESA 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.PROPOSTAS_VA B
							, 
							SEGUROS.PRODUTOS_VG C 
							, SEGUROS.PRODUTO D 
							WHERE A.SIT_REGISTRO = '0' 
							AND B.COD_PRODUTO = 7707 
							AND A.COD_OPERACAO = 2 
							AND A.NUM_PARCELA = 2 
							AND B.SIT_REGISTRO <> '2' 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND C.RAMO = 77 
							AND A.COD_RELATORIO = 'VP0437B' 
							AND D.COD_PRODUTO = B.COD_PRODUTO 
							UNION ALL 
							SELECT DISTINCT 
							A.COD_OPERACAO
							, 
							A.COD_USUARIO
							, 
							A.COD_RELATORIO
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
							(B.DATA_QUITACAO 
							+ B.NUM_PRAZO_FIN MONTHS)-1 DAY
							, 
							C.CODRELAT
							, 
							C.PERI_PAGAMENTO
							, 
							C.ORIG_PRODU 
							, D.COD_EMPRESA 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.PROPOSTAS_VA B
							, 
							SEGUROS.PRODUTOS_VG C 
							, SEGUROS.PRODUTO D 
							WHERE A.SIT_REGISTRO = '0' 
							AND DATE(A.TIMESTAMP) > '2017-05-13' 
							AND B.COD_PRODUTO IN (7705
							,7713
							,7715
							,7725) 
							AND A.COD_OPERACAO = 2 
							AND A.NUM_PARCELA = 2 
							AND B.SIT_REGISTRO <> '2' 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND C.RAMO = 77 
							AND A.COD_RELATORIO = 'VP0437B' 
							AND D.COD_PRODUTO = B.COD_PRODUTO";

                return query;
            }
            CRELAT.GetQueryEvent += GetQuery_CRELAT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-SECTION */
        private void R0510_00_FETCH_AGENCCEF_SECTION()
        {
            /*" -1837- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -1846- PERFORM R0510_00_FETCH_AGENCCEF_DB_FETCH_1 */

            R0510_00_FETCH_AGENCCEF_DB_FETCH_1();

            /*" -1849- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1850- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1851- MOVE 'S' TO WFIM-AGENCCEF */
                    _.Move("S", WFIM_AGENCCEF);

                    /*" -1851- PERFORM R0510_00_FETCH_AGENCCEF_DB_CLOSE_1 */

                    R0510_00_FETCH_AGENCCEF_DB_CLOSE_1();

                    /*" -1853- ELSE */
                }
                else
                {


                    /*" -1853- PERFORM R0510_00_FETCH_AGENCCEF_DB_CLOSE_2 */

                    R0510_00_FETCH_AGENCCEF_DB_CLOSE_2();

                    /*" -1855- DISPLAY 'R0510 - (PROBLEMAS NO FETCH AGENCCEF) ..' */
                    _.Display($"R0510 - (PROBLEMAS NO FETCH AGENCCEF) ..");

                    /*" -1856- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1856- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-FETCH-1 */
        public void R0510_00_FETCH_AGENCCEF_DB_FETCH_1()
        {
            /*" -1846- EXEC SQL FETCH V1AGENCEF INTO :MALHACEF-COD-FONTE, :FONTES-NOME-FONTE, :FONTES-ENDERECO, :FONTES-BAIRRO, :FONTES-CIDADE, :FONTES-CEP, :FONTES-SIGLA-UF END-EXEC. */

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
            /*" -1851- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-CLOSE-2 */
        public void R0510_00_FETCH_AGENCCEF_DB_CLOSE_2()
        {
            /*" -1853- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0520-00-CARREGA-FILIAL-SECTION */
        private void R0520_00_CARREGA_FILIAL_SECTION()
        {
            /*" -1867- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -1869- MOVE MALHACEF-COD-FONTE TO IDX-IND1. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, IDX_IND1);

            /*" -1871- MOVE MALHACEF-COD-FONTE TO TAB-FONTE (IDX-IND1) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAL.FILLER_201[IDX_IND1].TAB_FONTE);

            /*" -1873- MOVE FONTES-NOME-FONTE TO TAB-NOMEFTE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, TAB_FILIAL.FILLER_201[IDX_IND1].TAB_NOMEFTE);

            /*" -1875- MOVE FONTES-ENDERECO TO TAB-ENDERFTE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_ENDERECO, TAB_FILIAL.FILLER_201[IDX_IND1].TAB_ENDERFTE);

            /*" -1877- MOVE FONTES-BAIRRO TO TAB-BAIRRO (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_BAIRRO, TAB_FILIAL.FILLER_201[IDX_IND1].TAB_BAIRRO);

            /*" -1879- MOVE FONTES-CIDADE TO TAB-CIDADE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_CIDADE, TAB_FILIAL.FILLER_201[IDX_IND1].TAB_CIDADE);

            /*" -1881- MOVE FONTES-CEP TO TAB-CEP (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_CEP, TAB_FILIAL.FILLER_201[IDX_IND1].TAB_CEP);

            /*" -1884- MOVE FONTES-SIGLA-UF TO TAB-UF (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_SIGLA_UF, TAB_FILIAL.FILLER_201[IDX_IND1].TAB_UF);

            /*" -1884- PERFORM R0510-00-FETCH-AGENCCEF. */

            R0510_00_FETCH_AGENCCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-SECTION */
        private void R0900_00_DECLARE_RELATORI_SECTION()
        {
            /*" -1895- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -1976- PERFORM R0900_00_DECLARE_RELATORI_DB_DECLARE_1 */

            R0900_00_DECLARE_RELATORI_DB_DECLARE_1();

            /*" -1978- PERFORM R0900_00_DECLARE_RELATORI_DB_OPEN_1 */

            R0900_00_DECLARE_RELATORI_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-OPEN-1 */
        public void R0900_00_DECLARE_RELATORI_DB_OPEN_1()
        {
            /*" -1978- EXEC SQL OPEN CRELAT END-EXEC. */

            CRELAT.Open();

        }

        [StopWatch]
        /*" R2210-00-IMP-CAPITAIS-DB-DECLARE-1 */
        public void R2210_00_IMP_CAPITAIS_DB_DECLARE_1()
        {
            /*" -4211- EXEC SQL DECLARE COBER CURSOR FOR SELECT COD_COBERTURA, IMP_SEGURADA_IX FROM SEGUROS.VG_COBERTURAS_SUBG WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES AND COD_COBERTURA NOT IN (2, 12) END-EXEC. */
            COBER = new VP0437B_COBER(true);
            string GetQuery_COBER()
            {
                var query = @$"SELECT COD_COBERTURA
							, 
							IMP_SEGURADA_IX 
							FROM SEGUROS.VG_COBERTURAS_SUBG 
							WHERE NUM_APOLICE = '{WHOST_NRAPOLICE}' 
							AND COD_SUBGRUPO = '{WHOST_CODSUBES}' 
							AND COD_COBERTURA NOT IN (2
							, 12)";

                return query;
            }
            COBER.GetQueryEvent += GetQuery_COBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-SECTION */
        private void R0910_00_FETCH_RELATORI_SECTION()
        {
            /*" -1989- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -2011- PERFORM R0910_00_FETCH_RELATORI_DB_FETCH_1 */

            R0910_00_FETCH_RELATORI_DB_FETCH_1();

            /*" -2014- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2015- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", WFIM_RELATORI);

                /*" -2017- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AC_CONTA, AC_LIDOS);

                /*" -2017- PERFORM R0910_00_FETCH_RELATORI_DB_CLOSE_1 */

                R0910_00_FETCH_RELATORI_DB_CLOSE_1();

                /*" -2020- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2024- ADD 1 TO AC-L-RELATORI AC-CONTA AC-LIDOS. */
            AC_L_RELATORI.Value = AC_L_RELATORI + 1;
            AC_CONTA.Value = AC_CONTA + 1;
            AC_LIDOS.Value = AC_LIDOS + 1;

            /*" -2025- IF AC-CONTA GREATER 199 */

            if (AC_CONTA > 199)
            {

                /*" -2026- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -2027- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), WHORA_CURR);

                /*" -2029- DISPLAY '**** LIDOS V0RELAT    ' AC-LIDOS ' ' WHORA-CURR. */

                $"**** LIDOS V0RELAT    {AC_LIDOS} {WHORA_CURR}"
                .Display();
            }


            /*" -2030- MOVE PROPOVA-NUM-CERTIFICADO TO WS-CERTIFICADO-ATU. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WS_CERTIFICADO_ATU);

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-FETCH-1 */
        public void R0910_00_FETCH_RELATORI_DB_FETCH_1()
        {
            /*" -2011- EXEC SQL FETCH CRELAT INTO :RELATORI-COD-OPERACAO, :RELATORI-COD-USUARIO, :RELATORI-COD-RELATORIO, :PROPOVA-DATA-QUITACAO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-PRODUTO, :PROPOVA-COD-CLIENTE, :PROPOVA-IDE-SEXO, :PROPOVA-SIT-REGISTRO, :PROPOVA-AGE-COBRANCA, :PROPOVA-COD-FONTE, :PROPOVA-IDADE, :PROPOVA-OCORR-HISTORICO, :WS-DATA-FIM-CALC, :PRODUVG-CODRELAT, :PRODUVG-PERI-PAGAMENTO, :PRODUVG-ORIG-PRODU , :PRODUTO-COD-EMPRESA END-EXEC. */

            if (CRELAT.Fetch())
            {
                _.Move(CRELAT.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(CRELAT.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(CRELAT.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(CRELAT.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CRELAT.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CRELAT.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CRELAT.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CRELAT.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(CRELAT.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CRELAT.PROPOVA_IDE_SEXO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO);
                _.Move(CRELAT.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(CRELAT.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(CRELAT.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(CRELAT.PROPOVA_IDADE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE);
                _.Move(CRELAT.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(CRELAT.WS_DATA_FIM_CALC, WS_DATA_FIM_CALC);
                _.Move(CRELAT.PRODUVG_CODRELAT, PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT);
                _.Move(CRELAT.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CRELAT.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
                _.Move(CRELAT.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-CLOSE-1 */
        public void R0910_00_FETCH_RELATORI_DB_CLOSE_1()
        {
            /*" -2017- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -2041- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -2043- IF WS-CERTIFICADO-ATU NOT EQUAL WS-CERTIFICADO-ANT */

            if (WS_CERTIFICADO_ATU != WS_CERTIFICADO_ANT)
            {

                /*" -2045- MOVE WS-CERTIFICADO-ATU TO WS-CERTIFICADO-ANT */
                _.Move(WS_CERTIFICADO_ATU, WS_CERTIFICADO_ANT);

                /*" -2046- ELSE */
            }
            else
            {


                /*" -2048- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2050- PERFORM R1010-00-SELECT-SEGURVGA. */

            R1010_00_SELECT_SEGURVGA_SECTION();

            /*" -2051- IF WTEM-SEGURVGA EQUAL 'N' */

            if (WTEM_SEGURVGA == "N")
            {

                /*" -2052- ADD 1 TO AC-DESPR-SEGURAVG */
                AC_DESPR_SEGURAVG.Value = AC_DESPR_SEGURAVG + 1;

                /*" -2054- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2056- PERFORM R1100-00-SELECT-OPCPAGVI. */

            R1100_00_SELECT_OPCPAGVI_SECTION();

            /*" -2057- IF WTEM-OPCPAGVI EQUAL 'N' */

            if (WTEM_OPCPAGVI == "N")
            {

                /*" -2058- ADD 1 TO AC-DESPR-OPCAOPAG */
                AC_DESPR_OPCAOPAG.Value = AC_DESPR_OPCAOPAG + 1;

                /*" -2060- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2064- PERFORM R1200-00-SELECT-CLIENTES. */

            R1200_00_SELECT_CLIENTES_SECTION();

            /*" -2065- IF WTEM-CLIENTES EQUAL 'N' */

            if (WTEM_CLIENTES == "N")
            {

                /*" -2066- ADD 1 TO AC-DESPR-CLIENTE */
                AC_DESPR_CLIENTE.Value = AC_DESPR_CLIENTE + 1;

                /*" -2068- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2070- PERFORM R1300-00-SELECT-ENDERECO. */

            R1300_00_SELECT_ENDERECO_SECTION();

            /*" -2071- IF WTEM-ENDERECO EQUAL 'N' */

            if (WTEM_ENDERECO == "N")
            {

                /*" -2072- ADD 1 TO AC-DESPR-ENDERECO */
                AC_DESPR_ENDERECO.Value = AC_DESPR_ENDERECO + 1;

                /*" -2074- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2076- PERFORM R1400-00-SELECT-HISCOBPR. */

            R1400_00_SELECT_HISCOBPR_SECTION();

            /*" -2077- IF WTEM-HISCOBPR EQUAL 'N' */

            if (WTEM_HISCOBPR == "N")
            {

                /*" -2078- ADD 1 TO AC-DESPR-COBERPRO */
                AC_DESPR_COBERPRO.Value = AC_DESPR_COBERPRO + 1;

                /*" -2080- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2082- PERFORM R1500-00-SELECT-AGENCCEF. */

            R1500_00_SELECT_AGENCCEF_SECTION();

            /*" -2084- PERFORM R1600-00-SELECT-APOLICE. */

            R1600_00_SELECT_APOLICE_SECTION();

            /*" -2086- PERFORM R1640-00-SELECT-ENDOSSOS. */

            R1640_00_SELECT_ENDOSSOS_SECTION();

            /*" -2090- PERFORM R1650-00-SELECT-APOLCOBER. */

            R1650_00_SELECT_APOLCOBER_SECTION();

            /*" -2091- MOVE ZEROS TO SVA-PLANO. */
            _.Move(0, REG_SVP0437B.SVA_PLANO);

            /*" -2093- MOVE APOLICES-COD-CLIENTE TO SVA-CODCLIEN. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, REG_SVP0437B.SVA_CODCLIEN);

            /*" -2095- MOVE APOLICES-RAMO-EMISSOR TO SVA-RAMO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, REG_SVP0437B.SVA_RAMO);

            /*" -2096- MOVE MALHACEF-COD-FONTE TO SVA-FONTE. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, REG_SVP0437B.SVA_FONTE);

            /*" -2098- MOVE PROPOVA-NUM-CERTIFICADO TO SVA-NRCERTIF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_SVP0437B.SVA_NRCERTIF);

            /*" -2099- MOVE PROPOVA-IDE-SEXO TO SVA-IDSEXO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO, REG_SVP0437B.SVA_IDSEXO);

            /*" -2101- MOVE PROPOVA-DATA-QUITACAO TO SVA-DTINIVIG. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, REG_SVP0437B.SVA_DTINIVIG);

            /*" -2102- MOVE PROPOVA-NUM-APOLICE TO SVA-NRAPOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, REG_SVP0437B.SVA_NRAPOLICE);

            /*" -2104- MOVE PROPOVA-COD-SUBGRUPO TO SVA-CODSUBES. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, REG_SVP0437B.SVA_CODSUBES);

            /*" -2106- MOVE PRODUVG-CODRELAT TO SVA-CODRELAT. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT, REG_SVP0437B.SVA_CODRELAT);

            /*" -2108- MOVE RELATORI-COD-RELATORIO TO SVA-CODRELATVG. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO, REG_SVP0437B.SVA_CODRELATVG);

            /*" -2109- MOVE SEGURVGA-NUM-ITEM TO SVA-NUM-ITEM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, REG_SVP0437B.SVA_NUM_ITEM);

            /*" -2111- MOVE SEGURVGA-OCORR-HISTORICO TO SVA-OCORHIST. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO, REG_SVP0437B.SVA_OCORHIST);

            /*" -2113- MOVE HISCOBPR-DATA-INIVIGENCIA TO SVA-DTMOVTO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, REG_SVP0437B.SVA_DTMOVTO);

            /*" -2115- MOVE RELATORI-COD-OPERACAO TO SVA-CODOPER */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, REG_SVP0437B.SVA_CODOPER);

            /*" -2117- MOVE RELATORI-COD-USUARIO TO SVA-CODUSU. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SVP0437B.SVA_CODUSU);

            /*" -2119- MOVE PROPOVA-SIT-REGISTRO TO SVA-SITPROP. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO, REG_SVP0437B.SVA_SITPROP);

            /*" -2121- MOVE SEGURVGA-SIT-REGISTRO TO SVA-SITSEG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO, REG_SVP0437B.SVA_SITSEG);

            /*" -2122- MOVE HISCOBPR-VLPREMIO TO SVA-VLPREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, REG_SVP0437B.SVA_VLPREMIO);

            /*" -2123- MOVE HISCOBPR-IMPSEGCDG TO SVA-IMPSEGCDG. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, REG_SVP0437B.SVA_IMPSEGCDG);

            /*" -2124- MOVE OPCPAGVI-DIA-DEBITO TO SVA-DIA-DEBITO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, REG_SVP0437B.SVA_DIA_DEBITO);

            /*" -2125- MOVE CLIENTES-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SVP0437B.SVA_NOME_RAZAO);

            /*" -2126- MOVE CLIENTES-CGCCPF TO SVA-CPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SVP0437B.SVA_CPF);

            /*" -2129- MOVE PRODUVG-PERI-PAGAMENTO TO SVA-PERI-PAGAMENTO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO, REG_SVP0437B.SVA_PERI_PAGAMENTO);

            /*" -2131- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -2133- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO SVA-AGECTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, REG_SVP0437B.SVA_AGECTADEB);

                /*" -2135- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO SVA-OPRCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, REG_SVP0437B.SVA_OPRCTADEB);

                /*" -2137- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO SVA-NUMCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, REG_SVP0437B.SVA_NUMCTADEB);

                /*" -2139- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO SVA-DIGCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, REG_SVP0437B.SVA_DIGCTADEB);

                /*" -2140- ELSE */
            }
            else
            {


                /*" -2144- MOVE ZEROS TO SVA-AGECTADEB SVA-OPRCTADEB SVA-NUMCTADEB SVA-DIGCTADEB. */
                _.Move(0, REG_SVP0437B.SVA_AGECTADEB, REG_SVP0437B.SVA_OPRCTADEB, REG_SVP0437B.SVA_NUMCTADEB, REG_SVP0437B.SVA_DIGCTADEB);
            }


            /*" -2147- MOVE WS-DATA-FIM-CALC TO SVA-DTTERVIG. */
            _.Move(WS_DATA_FIM_CALC, REG_SVP0437B.SVA_DTTERVIG);

            /*" -2150- IF WHOST-DATA-TERVIG-PREMIO > ENDOSSOS-DATA-TERVIGENCIA-1 NEXT SENTENCE */

            if (WHOST_DATA_TERVIG_PREMIO > ENDOSSOS_DATA_TERVIGENCIA_1)
            {

                /*" -2151- ELSE */
            }
            else
            {


                /*" -2153- IF WHOST-DATA-TERVIG-PREMIO (6:2) < ENDOSSOS-DATA-TERVIGENCIA-1 (6:2) */

                if (WHOST_DATA_TERVIG_PREMIO.Substring(6, 2) < ENDOSSOS_DATA_TERVIGENCIA_1.Substring(6, 2))
                {

                    /*" -2155- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO WHOST-DATA-TERVIG-PREMIO (1:4) */
                    _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), WHOST_DATA_TERVIG_PREMIO, 1, 4);

                    /*" -2156- ELSE */
                }
                else
                {


                    /*" -2158- MOVE SISTEMAS-DATA-MOV-ABERTO-1 (1:4) TO WHOST-DATA-TERVIG-PREMIO (1:4) */
                    _.MoveAtPosition(SISTEMAS_DATA_MOV_ABERTO_1.Substring(1, 4), WHOST_DATA_TERVIG_PREMIO, 1, 4);

                    /*" -2159- END-IF */
                }


                /*" -2161- END-IF. */
            }


            /*" -2163- IF WHOST-DATA-TERVIG-PREMIO > ENDOSSOS-DATA-TERVIGENCIA */

            if (WHOST_DATA_TERVIG_PREMIO > ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA)
            {

                /*" -2164- MOVE '*' TO SVA-IND-VIGENCIA */
                _.Move("*", REG_SVP0437B.SVA_IND_VIGENCIA);

                /*" -2165- ELSE */
            }
            else
            {


                /*" -2166- MOVE ' ' TO SVA-IND-VIGENCIA */
                _.Move(" ", REG_SVP0437B.SVA_IND_VIGENCIA);

                /*" -2168- END-IF. */
            }


            /*" -2170- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO SVA-OPCAOPAG. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, REG_SVP0437B.SVA_OPCAOPAG);

            /*" -2171- MOVE ENDERECO-ENDERECO TO SVA-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, REG_SVP0437B.SVA_ENDERECO);

            /*" -2172- MOVE ENDERECO-BAIRRO TO SVA-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, REG_SVP0437B.SVA_BAIRRO);

            /*" -2173- MOVE ENDERECO-CIDADE TO SVA-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, REG_SVP0437B.SVA_CIDADE);

            /*" -2174- MOVE ENDERECO-SIGLA-UF TO SVA-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SVP0437B.SVA_UF);

            /*" -2176- MOVE ENDERECO-CEP TO WS-NUM-CEP-AUX. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, WS_NUM_CEP_AUX);

            /*" -2178- MOVE PROPOVA-COD-PRODUTO TO SVA-PRODUTO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, REG_SVP0437B.SVA_PRODUTO);

            /*" -2179- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -2180- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SVP0437B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -2181- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SVP0437B.SVA_NUM_CEP.SVA_CEP);

                /*" -2182- ELSE */
            }
            else
            {


                /*" -2183- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SVP0437B.SVA_NUM_CEP.SVA_CEP);

                /*" -2185- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL. */
                _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SVP0437B.SVA_NUM_CEP.SVA_CEP_COMPL);
            }


            /*" -2186- IF ENDERECO-CEP EQUAL ZEROS */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP == 00)
            {

                /*" -2187- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVP0437B.SVA_CEP_G);

                /*" -2188- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVP0437B.SVA_NOME_CORREIO);

                /*" -2189- ELSE */
            }
            else
            {


                /*" -2190- PERFORM R1900-00-LOCALIZA-CEP. */

                R1900_00_LOCALIZA_CEP_SECTION();
            }


            /*" -2192- MOVE PROPOVA-AGE-COBRANCA TO SVA-AGECOBRAN. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, REG_SVP0437B.SVA_AGECOBRAN);

            /*" -2195- MOVE PRODUTO-COD-EMPRESA TO SVA-COD-EMPRESA. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, REG_SVP0437B.SVA_COD_EMPRESA);

            /*" -2195- RELEASE REG-SVP0437B. */
            SVP0437B.Release(REG_SVP0437B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -2199- PERFORM R0910-00-FETCH-RELATORI. */

            R0910_00_FETCH_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-SECTION */
        private void R1010_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -2209- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", WABEND.WNR_EXEC_SQL);

            /*" -2211- MOVE 'S' TO WTEM-SEGURVGA */
            _.Move("S", WTEM_SEGURVGA);

            /*" -2234- PERFORM R1010_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1010_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -2237- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2238- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2239- MOVE 'N' TO WTEM-SEGURVGA */
                    _.Move("N", WTEM_SEGURVGA);

                    /*" -2240- ELSE */
                }
                else
                {


                    /*" -2242- DISPLAY '*** VP0437B PROBLEMAS NO ACESSO A V0SEGURAVG ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VP0437B PROBLEMAS NO ACESSO A V0SEGURAVG {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2242- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1010_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -2234- EXEC SQL SELECT SIT_REGISTRO, COD_CLIENTE, DATA_INIVIGENCIA, DATA_INIVIGENCIA + :PRODUVG-PERI-PAGAMENTO MONTHS, COD_SUBGRUPO, OCORR_ENDERECO, NUM_ITEM, OCORR_HISTORICO INTO :SEGURVGA-SIT-REGISTRO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-DATA-INIVIGENCIA, :WHOST-DATA-TERVIG-PREMIO, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

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
        /*" R1050-00-VERIFICA-CAP-SECTION */
        private void R1050_00_VERIFICA_CAP_SECTION()
        {
            /*" -2254- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", WABEND.WNR_EXEC_SQL);

            /*" -2270- INITIALIZE VG0716S-COD-FONTE , VG0716S-COD-PRODUTO , VG0716S-NUM-PROPOSTA , VG0716S-VLR-MENSALIDADE, VG0716S-NUM-PLANO , VG0716S-NUM-SERIE , VG0716S-NUM-TITULO , VG0716S-IND-DV , VG0716S-DTH-INI-VIGENCIA, VG0716S-DTH-FIM-VIGENCIA, VG0716S-DES-COMBINACAO , VG0716S-COD-STA-TITULO , VG0716S-SQLCODE , VG0716S-COD-RETORNO , VG0716S-DES-MENSAGEM . */
            _.Initialize(
                VG0716S_COD_FONTE
                , VG0716S_COD_PRODUTO
                , VG0716S_NUM_PROPOSTA
                , VG0716S_VLR_MENSALIDADE
                , VG0716S_NUM_PLANO
                , VG0716S_NUM_SERIE
                , VG0716S_NUM_TITULO
                , VG0716S_IND_DV
                , VG0716S_DTH_INI_VIGENCIA
                , VG0716S_DTH_FIM_VIGENCIA
                , VG0716S_DES_COMBINACAO
                , VG0716S_COD_STA_TITULO
                , VG0716S_SQLCODE
                , VG0716S_COD_RETORNO
                , VG0716S_DES_MENSAGEM
            );

            /*" -2272- PERFORM R1052-00-PEGAR-VLR-TITULO */

            R1052_00_PEGAR_VLR_TITULO_SECTION();

            /*" -2273- MOVE SVA-FONTE TO VG0716S-COD-FONTE. */
            _.Move(REG_SVP0437B.SVA_FONTE, VG0716S_COD_FONTE);

            /*" -2274- MOVE SVA-PRODUTO TO VG0716S-COD-PRODUTO. */
            _.Move(REG_SVP0437B.SVA_PRODUTO, VG0716S_COD_PRODUTO);

            /*" -2275- MOVE 810 TO VG0716S-NUM-PLANO. */
            _.Move(810, VG0716S_NUM_PLANO);

            /*" -2277- MOVE SVA-NRCERTIF TO VG0716S-NUM-PROPOSTA. */
            _.Move(REG_SVP0437B.SVA_NRCERTIF, VG0716S_NUM_PROPOSTA);

            /*" -2279- MOVE FCTITULO-VLR-MENSALIDADE TO VG0716S-VLR-MENSALIDADE. */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_VLR_MENSALIDADE, VG0716S_VLR_MENSALIDADE);

            /*" -2296- CALL 'VG0716S' USING VG0716S-COD-FONTE , VG0716S-COD-PRODUTO , VG0716S-NUM-PROPOSTA , VG0716S-VLR-MENSALIDADE, VG0716S-NUM-PLANO , VG0716S-NUM-SERIE , VG0716S-NUM-TITULO , VG0716S-IND-DV , VG0716S-DTH-INI-VIGENCIA, VG0716S-DTH-FIM-VIGENCIA, VG0716S-DES-COMBINACAO , VG0716S-COD-STA-TITULO , VG0716S-SQLCODE , VG0716S-COD-RETORNO , VG0716S-DES-MENSAGEM . */
            _.Call("VG0716S", VG0716S_COD_FONTE, VG0716S_COD_PRODUTO, VG0716S_NUM_PROPOSTA, VG0716S_VLR_MENSALIDADE, VG0716S_NUM_PLANO, VG0716S_NUM_SERIE, VG0716S_NUM_TITULO, VG0716S_IND_DV, VG0716S_DTH_INI_VIGENCIA, VG0716S_DTH_FIM_VIGENCIA, VG0716S_DES_COMBINACAO, VG0716S_COD_STA_TITULO, VG0716S_SQLCODE, VG0716S_COD_RETORNO, VG0716S_DES_MENSAGEM, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -2297- IF VG0716S-COD-RETORNO NOT EQUAL ZEROS */

            if (VG0716S_COD_RETORNO != 00)
            {

                /*" -2298- MOVE VG0716S-SQLCODE TO WSQLCODE */
                _.Move(VG0716S_SQLCODE, WABEND.WSQLCODE);

                /*" -2299- DISPLAY 'PROBLEMAS NO ACESSO A VG0716S ' */
                _.Display($"PROBLEMAS NO ACESSO A VG0716S ");

                /*" -2300- DISPLAY 'NUM-PROPOSTA     ' VG0716S-NUM-PROPOSTA */
                _.Display($"NUM-PROPOSTA     {VG0716S_NUM_PROPOSTA}");

                /*" -2301- DISPLAY 'NUM-TITULO       ' VG0716S-NUM-TITULO */
                _.Display($"NUM-TITULO       {VG0716S_NUM_TITULO}");

                /*" -2302- DISPLAY 'SQLCODE          ' VG0716S-SQLCODE */
                _.Display($"SQLCODE          {VG0716S_SQLCODE}");

                /*" -2303- DISPLAY 'COD-RETORNO      ' VG0716S-COD-RETORNO */
                _.Display($"COD-RETORNO      {VG0716S_COD_RETORNO}");

                /*" -2304- DISPLAY 'DES-MENSAGEM     ' VG0716S-DES-MENSAGEM */
                _.Display($"DES-MENSAGEM     {VG0716S_DES_MENSAGEM}");

                /*" -2304- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1051-00-PROPOSTA-FIDEL-SECTION */
        private void R1051_00_PROPOSTA_FIDEL_SECTION()
        {
            /*" -2312- MOVE '1051' TO WNR-EXEC-SQL. */
            _.Move("1051", WABEND.WNR_EXEC_SQL);

            /*" -2314- MOVE SVA-NRCERTIF TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(REG_SVP0437B.SVA_NRCERTIF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -2320- PERFORM R1051_00_PROPOSTA_FIDEL_DB_SELECT_1 */

            R1051_00_PROPOSTA_FIDEL_DB_SELECT_1();

            /*" -2323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2325- DISPLAY '*** VP0437B PROBLEMAS NO ACESSO A PROPOSTA_FIDELIZ' */
                _.Display($"*** VP0437B PROBLEMAS NO ACESSO A PROPOSTA_FIDELIZ");

                /*" -2326- DISPLAY 'NUM_PROPOSTA_SIVPF=' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"NUM_PROPOSTA_SIVPF={PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -2327- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2327- END-IF. */
            }


        }

        [StopWatch]
        /*" R1051-00-PROPOSTA-FIDEL-DB-SELECT-1 */
        public void R1051_00_PROPOSTA_FIDEL_DB_SELECT_1()
        {
            /*" -2320- EXEC SQL SELECT OPRCTADEB INTO :PROPOFID-OPRCTADEB FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1 = new R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1.Execute(r1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1051_99_SAIDA*/

        [StopWatch]
        /*" R1052-00-PEGAR-VLR-TITULO-SECTION */
        private void R1052_00_PEGAR_VLR_TITULO_SECTION()
        {
            /*" -2335- MOVE '1052' TO WNR-EXEC-SQL. */
            _.Move("1052", WABEND.WNR_EXEC_SQL);

            /*" -2337- MOVE SVA-NRCERTIF TO FCTITULO-NUM-PROPOSTA */
            _.Move(REG_SVP0437B.SVA_NRCERTIF, FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PROPOSTA);

            /*" -2347- PERFORM R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1 */

            R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1();

            /*" -2350- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2351- MOVE ZEROS TO FCTITULO-VLR-MENSALIDADE */
                _.Move(0, FCTITULO.DCLFC_TITULO.FCTITULO_VLR_MENSALIDADE);

                /*" -2353- END-IF. */
            }


            /*" -2354- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2356- DISPLAY '*** VP0437B PROBLEMAS NO ACESSO A FDRCAP.FC_TITULO' */
                _.Display($"*** VP0437B PROBLEMAS NO ACESSO A FDRCAP.FC_TITULO");

                /*" -2357- DISPLAY 'NUM_PROPOSTA = ' FCTITULO-NUM-PROPOSTA */
                _.Display($"NUM_PROPOSTA = {FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PROPOSTA}");

                /*" -2358- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2358- END-IF. */
            }


        }

        [StopWatch]
        /*" R1052-00-PEGAR-VLR-TITULO-DB-SELECT-1 */
        public void R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1()
        {
            /*" -2347- EXEC SQL SELECT VLR_MENSALIDADE INTO :FCTITULO-VLR-MENSALIDADE FROM FDRCAP.FC_TITULO WHERE NUM_PROPOSTA = :FCTITULO-NUM-PROPOSTA AND NUM_PLANO = 810 AND COD_STA_TITULO = 'ATV' ORDER BY DTH_ATIVACAO DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1 = new R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1()
            {
                FCTITULO_NUM_PROPOSTA = FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1.Execute(r1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCTITULO_VLR_MENSALIDADE, FCTITULO.DCLFC_TITULO.FCTITULO_VLR_MENSALIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1052_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-OPCPAGVI-SECTION */
        private void R1100_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -2367- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -2369- MOVE 'S' TO WTEM-OPCPAGVI. */
            _.Move("S", WTEM_OPCPAGVI);

            /*" -2386- PERFORM R1100_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R1100_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -2389- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2390- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2391- MOVE 'N' TO WTEM-OPCPAGVI */
                    _.Move("N", WTEM_OPCPAGVI);

                    /*" -2392- ELSE */
                }
                else
                {


                    /*" -2393- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -2394- MOVE 'N' TO WTEM-OPCPAGVI */
                        _.Move("N", WTEM_OPCPAGVI);

                        /*" -2395- ELSE */
                    }
                    else
                    {


                        /*" -2397- DISPLAY '*** VP0437B PROBLEMAS NO ACESSO A V0OPCAOPAG ' PROPOVA-NUM-CERTIFICADO */
                        _.Display($"*** VP0437B PROBLEMAS NO ACESSO A V0OPCAOPAG {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                        /*" -2397- GO TO R9999-00-ROT-ERRO. */

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
            /*" -2386- EXEC SQL SELECT OPCAO_PAGAMENTO, DIA_DEBITO, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO INTO :OPCPAGVI-OPCAO-PAGAMENTO, :OPCPAGVI-DIA-DEBITO, :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB, :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB, :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB, :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

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
        /*" R1200-00-SELECT-CLIENTES-SECTION */
        private void R1200_00_SELECT_CLIENTES_SECTION()
        {
            /*" -2407- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -2409- MOVE 'S' TO WTEM-CLIENTES. */
            _.Move("S", WTEM_CLIENTES);

            /*" -2419- PERFORM R1200_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1200_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -2422- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2423- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2424- MOVE 'N' TO WTEM-CLIENTES */
                    _.Move("N", WTEM_CLIENTES);

                    /*" -2425- ELSE */
                }
                else
                {


                    /*" -2427- DISPLAY '*** VP0437B PROBLEMAS NO ACESSO A CLIENTES   ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VP0437B PROBLEMAS NO ACESSO A CLIENTES   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2429- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2430- IF VIND-SEXO LESS 0 */

            if (VIND_SEXO < 0)
            {

                /*" -2431- MOVE ' ' TO CLIENTES-IDE-SEXO. */
                _.Move(" ", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1200_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -2419- EXEC SQL SELECT NOME_RAZAO, CGCCPF, IDE_SEXO INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-IDE-SEXO:VIND-SEXO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECO-SECTION */
        private void R1300_00_SELECT_ENDERECO_SECTION()
        {
            /*" -2441- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -2443- MOVE 'S' TO WTEM-ENDERECO. */
            _.Move("S", WTEM_ENDERECO);

            /*" -2459- PERFORM R1300_00_SELECT_ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -2462- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2463- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2464- MOVE 'N' TO WTEM-ENDERECO */
                    _.Move("N", WTEM_ENDERECO);

                    /*" -2465- ELSE */
                }
                else
                {


                    /*" -2467- DISPLAY '*** VP0437B PROBLEMAS NO ACESSO A V0ENDERECO ' PROPOVA-NUM-CERTIFICADO ' ' SEGURVGA-COD-CLIENTE */

                    $"*** VP0437B PROBLEMAS NO ACESSO A V0ENDERECO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE}"
                    .Display();

                    /*" -2467- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -2459- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE AND OCORR_ENDERECO = :SEGURVGA-OCORR-ENDERECO END-EXEC. */

            var r1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_ENDERECO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
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
            /*" -2477- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -2479- MOVE 'S' TO WTEM-HISCOBPR. */
            _.Move("S", WTEM_HISCOBPR);

            /*" -2496- PERFORM R1400_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1400_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -2499- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2500- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2501- IF PRODUVG-ORIG-PRODU EQUAL 'MULT' */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "MULT")
                    {

                        /*" -2502- MOVE 'N' TO WTEM-HISCOBPR */
                        _.Move("N", WTEM_HISCOBPR);

                        /*" -2503- END-IF */
                    }


                    /*" -2504- ELSE */
                }
                else
                {


                    /*" -2506- DISPLAY '*** VA0436B PROBLEMAS ACESSO HIS_COBER_PROPOST' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA0436B PROBLEMAS ACESSO HIS_COBER_PROPOST{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2506- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1400_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -2496- EXEC SQL SELECT DATA_INIVIGENCIA, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPSEGCDG, VLPREMIO INTO :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-AGENCCEF-SECTION */
        private void R1500_00_SELECT_AGENCCEF_SECTION()
        {
            /*" -2517- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -2526- PERFORM R1500_00_SELECT_AGENCCEF_DB_SELECT_1 */

            R1500_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -2529- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2530- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2531- MOVE PROPOVA-COD-FONTE TO MALHACEF-COD-FONTE */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);

                    /*" -2532- ELSE */
                }
                else
                {


                    /*" -2533- DISPLAY 'R1500 - PROBLEMAS SELECT AGENCIAS_CEF ..' */
                    _.Display($"R1500 - PROBLEMAS SELECT AGENCIAS_CEF ..");

                    /*" -2534- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -2535- DISPLAY 'AGE COBR- ' PROPOVA-AGE-COBRANCA */
                    _.Display($"AGE COBR- {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA}");

                    /*" -2535- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -2526- EXEC SQL SELECT B.COD_FONTE INTO :MALHACEF-COD-FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :PROPOVA-AGE-COBRANCA END-EXEC. */

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
            /*" -2546- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -2554- PERFORM R1600_00_SELECT_APOLICE_DB_SELECT_1 */

            R1600_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -2557- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2558- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2559- DISPLAY 'APOLICE NAO CADASTRADA ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE NAO CADASTRADA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -2560- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2561- ELSE */
                }
                else
                {


                    /*" -2563- DISPLAY 'R1600 - PROBLEMAS SELECT APOLICES  ..' SQLCODE ' ' PROPOVA-NUM-APOLICE */

                    $"R1600 - PROBLEMAS SELECT APOLICES  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                    .Display();

                    /*" -2563- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-APOLICE-DB-SELECT-1 */
        public void R1600_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -2554- EXEC SQL SELECT COD_CLIENTE, RAMO_EMISSOR INTO :APOLICES-COD-CLIENTE, :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE END-EXEC. */

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
            /*" -2574- MOVE '1640' TO WNR-EXEC-SQL. */
            _.Move("1640", WABEND.WNR_EXEC_SQL);

            /*" -2583- PERFORM R1640_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1640_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -2586- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2587- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2588- DISPLAY 'ENDOSSO NAO CADASTRAD0 ' PROPOVA-NUM-APOLICE */
                    _.Display($"ENDOSSO NAO CADASTRAD0 {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -2589- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2590- ELSE */
                }
                else
                {


                    /*" -2592- DISPLAY 'R1640 - PROBLEMAS SELECT ENDOSSOS  ..' SQLCODE ' ' PROPOVA-NUM-APOLICE */

                    $"R1640 - PROBLEMAS SELECT ENDOSSOS  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                    .Display();

                    /*" -2592- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1640-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1640_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -2583- EXEC SQL SELECT DATA_TERVIGENCIA, DATA_TERVIGENCIA - 1 YEAR INTO :ENDOSSOS-DATA-TERVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA-1 FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

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
        /*" R1650-00-SELECT-APOLCOBER-SECTION */
        private void R1650_00_SELECT_APOLCOBER_SECTION()
        {
            /*" -2603- MOVE '1650' TO WNR-EXEC-SQL. */
            _.Move("1650", WABEND.WNR_EXEC_SQL);

            /*" -2612- PERFORM R1650_00_SELECT_APOLCOBER_DB_SELECT_1 */

            R1650_00_SELECT_APOLCOBER_DB_SELECT_1();

            /*" -2615- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2616- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2617- DISPLAY 'APOLICE NAO ENCONTRADA ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE NAO ENCONTRADA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -2618- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2619- ELSE */
                }
                else
                {


                    /*" -2621- DISPLAY 'R1650 - PROBLEMAS SELECT APOLICOB  ..' SQLCODE ' ' PROPOVA-NUM-APOLICE */

                    $"R1650 - PROBLEMAS SELECT APOLICOB  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                    .Display();

                    /*" -2621- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1650-00-SELECT-APOLCOBER-DB-SELECT-1 */
        public void R1650_00_SELECT_APOLCOBER_DB_SELECT_1()
        {
            /*" -2612- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :APOLICOB-DATA-INIVIGENCIA, :APOLICOB-DATA-TERVIGENCIA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO END-EXEC. */

            var r1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1 = new R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1.Execute(r1650_00_SELECT_APOLCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);
                _.Move(executed_1.APOLICOB_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-PLANOVID-SECTION */
        private void R1700_00_SELECT_PLANOVID_SECTION()
        {
            /*" -2631- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -2633- MOVE 'S' TO WTEM-PLANOVID. */
            _.Move("S", WTEM_PLANOVID);

            /*" -2646- PERFORM R1700_00_SELECT_PLANOVID_DB_SELECT_1 */

            R1700_00_SELECT_PLANOVID_DB_SELECT_1();

            /*" -2649- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2650- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2651- MOVE 'N' TO WTEM-PLANOVID */
                    _.Move("N", WTEM_PLANOVID);

                    /*" -2652- ELSE */
                }
                else
                {


                    /*" -2654- DISPLAY 'R1700 - PROBLEMAS SELECT PLANOVID  ..' SQLCODE ' ' PROPOVA-NUM-CERTIFICADO */

                    $"R1700 - PROBLEMAS SELECT PLANOVID  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                    .Display();

                    /*" -2654- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-PLANOVID-DB-SELECT-1 */
        public void R1700_00_SELECT_PLANOVID_DB_SELECT_1()
        {
            /*" -2646- EXEC SQL SELECT COD_PLANO INTO :PLANOVID-COD-PLANO FROM SEGUROS.PLANOS_VIDAZUL WHERE COD_PRODUTO = :PROPOVA-COD-PRODUTO AND OPCAO_COBERTURA = :HISCOBPR-OPCAO-COBERTURA AND IDADE_INICIAL <= :PROPOVA-IDADE AND IDADE_FINAL >= :PROPOVA-IDADE AND DATA_INIVIGENCIA <= CURRENT DATE AND DATA_TERVIGENCIA >= CURRENT DATE AND PERI_PAGAMENTO = 1 END-EXEC. */

            var r1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1 = new R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1()
            {
                HISCOBPR_OPCAO_COBERTURA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA.ToString(),
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
                PROPOVA_IDADE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.ToString(),
            };

            var executed_1 = R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANOVID_COD_PLANO, PLANOVID.DCLPLANOS_VIDAZUL.PLANOVID_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-CONDITEC-SECTION */
        private void R1800_00_SELECT_CONDITEC_SECTION()
        {
            /*" -2664- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -2666- MOVE 'S' TO WTEM-CONDITEC. */
            _.Move("S", WTEM_CONDITEC);

            /*" -2682- PERFORM R1800_00_SELECT_CONDITEC_DB_SELECT_1 */

            R1800_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -2685- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2686- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2687- MOVE 'N' TO WTEM-CONDITEC */
                    _.Move("N", WTEM_CONDITEC);

                    /*" -2688- MOVE ZEROS TO WS-CAR-CONJUGE */
                    _.Move(0, WS_CAR_CONJUGE);

                    /*" -2689- GO TO R1800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/ //GOTO
                    return;

                    /*" -2690- ELSE */
                }
                else
                {


                    /*" -2691- DISPLAY 'VP0437B - NAO ENCONTRADO NA CONDITEC ' */
                    _.Display($"VP0437B - NAO ENCONTRADO NA CONDITEC ");

                    /*" -2692- DISPLAY 'APOLICE  ' WHOST-NRAPOLICE */
                    _.Display($"APOLICE  {WHOST_NRAPOLICE}");

                    /*" -2693- DISPLAY 'SUBGRUPO ' WHOST-CODSUBES */
                    _.Display($"SUBGRUPO {WHOST_CODSUBES}");

                    /*" -2695- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2698- MOVE CONDITEC-CARREGA-CONJUGE TO WS-CAR-CONJUGE. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE, WS_CAR_CONJUGE);

            /*" -2700- COMPUTE WS-CAR-CONJUGE = WS-CAR-CONJUGE / 100. */
            WS_CAR_CONJUGE.Value = WS_CAR_CONJUGE / 100f;

        }

        [StopWatch]
        /*" R1800-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R1800_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -2682- EXEC SQL SELECT CARREGA_CONJUGE, GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :CONDITEC-CARREGA-CONJUGE, :CONDITEC-GARAN-ADIC-IEA, :CONDITEC-GARAN-ADIC-IPA, :CONDITEC-GARAN-ADIC-IPD, :CONDITEC-GARAN-ADIC-HD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES END-EXEC. */

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
            _.Move(1, WIND);

            /*" -0- FLUXCONTROL_PERFORM R1900_10_LOOP */

            R1900_10_LOOP();

        }

        [StopWatch]
        /*" R1900-10-LOOP */
        private void R1900_10_LOOP(bool isPerform = false)
        {
            /*" -2715- IF WIND GREATER 2000 */

            if (WIND > 2000)
            {

                /*" -2718- DISPLAY '*** VP0437B CEP NAO ENCONTRADO ' ENDERECO-CEP ' ' PROPOVA-NUM-CERTIFICADO */

                $"*** VP0437B CEP NAO ENCONTRADO {ENDERECO.DCLENDERECOS.ENDERECO_CEP} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -2719- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVP0437B.SVA_CEP_G);

                /*" -2720- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVP0437B.SVA_NOME_CORREIO);

                /*" -2722- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2723- MOVE TAB-FX-FIM (WIND) TO WS-SUP. */
            _.Move(TABELA_CEP.CEP[WIND].TAB_FAIXAS.TAB_FX_FIM, WS_SUP);

            /*" -2725- MOVE TAB-FX-INI (WIND) TO WS-INF. */
            _.Move(TABELA_CEP.CEP[WIND].TAB_FAIXAS.TAB_FX_INI, WS_INF);

            /*" -2726- ADD 1 TO WS-SUP. */
            WS_SUP.Value = WS_SUP + 1;

            /*" -2728- SUBTRACT 1 FROM WS-INF. */
            WS_INF.Value = WS_INF - 1;

            /*" -2730- IF ENDERECO-CEP GREATER WS-INF AND ENDERECO-CEP LESS WS-SUP */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP > WS_INF && ENDERECO.DCLENDERECOS.ENDERECO_CEP < WS_SUP)
            {

                /*" -2731- MOVE TAB-FX-CEP-G (WIND) TO SVA-CEP-G */
                _.Move(TABELA_CEP.CEP[WIND].TAB_FX_CEP_G, REG_SVP0437B.SVA_CEP_G);

                /*" -2732- MOVE TAB-FAIXAS (WIND) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[WIND].TAB_FAIXAS, REG_SVP0437B.SVA_NOME_CORREIO);

                /*" -2733- ELSE */
            }
            else
            {


                /*" -2734- ADD 1 TO WIND */
                WIND.Value = WIND + 1;

                /*" -2734- GO TO R1900-10-LOOP. */
                new Task(() => R1900_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-NOME-CORRETOR-SECTION */
        private void R1910_00_NOME_CORRETOR_SECTION()
        {
            /*" -2742- MOVE '1910' TO WNR-EXEC-SQL. */
            _.Move("1910", WABEND.WNR_EXEC_SQL);

            /*" -2744- MOVE SVA-NRAPOLICE TO APOLICOR-NUM-APOLICE */
            _.Move(REG_SVP0437B.SVA_NRAPOLICE, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE);

            /*" -2753- PERFORM R1910_00_NOME_CORRETOR_DB_SELECT_1 */

            R1910_00_NOME_CORRETOR_DB_SELECT_1();

            /*" -2756- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2758- MOVE PRODUTOR-NOME-PRODUTOR TO DET6-NOME-CORRETOR DET3-NOME-CORRETOR */
                _.Move(PRODUTOR.DCLPRODUTORES.PRODUTOR_NOME_PRODUTOR, DETALHE_DS06.DET6_NOME_CORRETOR, DETALHE_DS03.DET3_NOME_CORRETOR);

                /*" -2760- MOVE PRODUTOR-REGISTRO-SUSEP TO DET6-COD-SUSEP-COR DET3-COD-SUSEP-COR */
                _.Move(PRODUTOR.DCLPRODUTORES.PRODUTOR_REGISTRO_SUSEP, DETALHE_DS06.DET6_COD_SUSEP_COR, DETALHE_DS03.DET3_COD_SUSEP_COR);

                /*" -2762- END-IF */
            }


            /*" -2763- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2764- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2766- MOVE '********************' TO DET6-NOME-CORRETOR DET3-NOME-CORRETOR */
                    _.Move("********************", DETALHE_DS06.DET6_NOME_CORRETOR, DETALHE_DS03.DET3_NOME_CORRETOR);

                    /*" -2768- MOVE '********' TO DET6-COD-SUSEP-COR DET3-COD-SUSEP-COR */
                    _.Move("********", DETALHE_DS06.DET6_COD_SUSEP_COR, DETALHE_DS03.DET3_COD_SUSEP_COR);

                    /*" -2769- ELSE */
                }
                else
                {


                    /*" -2770- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_SQLCODE);

                    /*" -2772- DISPLAY 'ERRO ACESSO APOLICE_CORRETOR => SQLCODE = ' WS-SQLCODE */
                    _.Display($"ERRO ACESSO APOLICE_CORRETOR => SQLCODE = {WS_SQLCODE}");

                    /*" -2773- DISPLAY 'NUM_APOLICE  = ' APOLICOR-NUM-APOLICE */
                    _.Display($"NUM_APOLICE  = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE}");

                    /*" -2774- ADD 1 TO AC-DESPR-SEGVGAPH */
                    AC_DESPR_SEGVGAPH.Value = AC_DESPR_SEGVGAPH + 1;

                    /*" -2775- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2776- END-IF */
                }


                /*" -2776- END-IF. */
            }


        }

        [StopWatch]
        /*" R1910-00-NOME-CORRETOR-DB-SELECT-1 */
        public void R1910_00_NOME_CORRETOR_DB_SELECT_1()
        {
            /*" -2753- EXEC SQL SELECT T2.REGISTRO_SUSEP, T2.NOME_PRODUTOR INTO :PRODUTOR-REGISTRO-SUSEP, :PRODUTOR-NOME-PRODUTOR FROM SEGUROS.APOLICE_CORRETOR T1, SEGUROS.PRODUTORES T2 WHERE T1.NUM_APOLICE = :APOLICOR-NUM-APOLICE AND T1.COD_CORRETOR = T2.COD_PRODUTOR FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1910_00_NOME_CORRETOR_DB_SELECT_1_Query1 = new R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1()
            {
                APOLICOR_NUM_APOLICE = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1910_00_NOME_CORRETOR_DB_SELECT_1_Query1.Execute(r1910_00_NOME_CORRETOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTOR_REGISTRO_SUSEP, PRODUTOR.DCLPRODUTORES.PRODUTOR_REGISTRO_SUSEP);
                _.Move(executed_1.PRODUTOR_NOME_PRODUTOR, PRODUTOR.DCLPRODUTORES.PRODUTOR_NOME_PRODUTOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R1920-00-DADOS-SEGURADO-SECTION */
        private void R1920_00_DADOS_SEGURADO_SECTION()
        {
            /*" -2783- MOVE '1920' TO WNR-EXEC-SQL. */
            _.Move("1920", WABEND.WNR_EXEC_SQL);

            /*" -2785- MOVE SVA-NRCERTIF TO WS-CERTIFICADO */
            _.Move(REG_SVP0437B.SVA_NRCERTIF, WS_CERTIFICADO);

            /*" -2809- PERFORM R1920_00_DADOS_SEGURADO_DB_SELECT_1 */

            R1920_00_DADOS_SEGURADO_DB_SELECT_1();

            /*" -2812- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2813- MOVE WS-NOME-SEG TO DET6-NOME-SEG DET3-NOME-SEG */
                _.Move(WS_NOME_SEG, DETALHE_DS06.DET6_NOME_SEG, DETALHE_DS03.DET3_NOME_SEG);

                /*" -2814- MOVE WS-CGCCPF-SEG TO DET6-CGCCPF-SEG DET3-CGCCPF-SEG */
                _.Move(WS_CGCCPF_SEG, DETALHE_DS06.DET6_CGCCPF_SEG, DETALHE_DS03.DET3_CGCCPF_SEG);

                /*" -2815- MOVE WS-ENDERECO-SEG TO DET6-ENDERE-SEG DET3-ENDERE-SEG */
                _.Move(WS_ENDERECO_SEG, DETALHE_DS06.DET6_ENDERE_SEG, DETALHE_DS03.DET3_ENDERE_SEG);

                /*" -2816- MOVE WS-BAIRRO-SEG TO DET6-BAIRRO-SEG DET3-BAIRRO-SEG */
                _.Move(WS_BAIRRO_SEG, DETALHE_DS06.DET6_BAIRRO_SEG, DETALHE_DS03.DET3_BAIRRO_SEG);

                /*" -2817- MOVE WS-CIDADE-SEG TO DET6-CIDADE-SEG DET3-CIDADE-SEG */
                _.Move(WS_CIDADE_SEG, DETALHE_DS06.DET6_CIDADE_SEG, DETALHE_DS03.DET3_CIDADE_SEG);

                /*" -2818- MOVE WS-UF-SEG TO DET6-UF-SEG DET3-UF-SEG */
                _.Move(WS_UF_SEG, DETALHE_DS06.DET6_UF_SEG, DETALHE_DS03.DET3_UF_SEG);

                /*" -2819- MOVE WS-CEP-SEG TO DET6-CEP-SEG DET3-CEP-SEG */
                _.Move(WS_CEP_SEG, DETALHE_DS06.DET6_CEP_SEG, DETALHE_DS03.DET3_CEP_SEG);

                /*" -2821- END-IF */
            }


            /*" -2822- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2823- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2825- MOVE '********************' TO DET6-NOME-SEG DET3-NOME-SEG */
                    _.Move("********************", DETALHE_DS06.DET6_NOME_SEG, DETALHE_DS03.DET3_NOME_SEG);

                    /*" -2826- MOVE '********' TO DET6-CGCCPF-SEG DET3-CGCCPF-SEG */
                    _.Move("********", DETALHE_DS06.DET6_CGCCPF_SEG, DETALHE_DS03.DET3_CGCCPF_SEG);

                    /*" -2827- MOVE '********' TO DET6-ENDERE-SEG DET3-ENDERE-SEG */
                    _.Move("********", DETALHE_DS06.DET6_ENDERE_SEG, DETALHE_DS03.DET3_ENDERE_SEG);

                    /*" -2828- MOVE '********' TO DET6-BAIRRO-SEG DET3-BAIRRO-SEG */
                    _.Move("********", DETALHE_DS06.DET6_BAIRRO_SEG, DETALHE_DS03.DET3_BAIRRO_SEG);

                    /*" -2829- MOVE '********' TO DET6-CIDADE-SEG DET3-CIDADE-SEG */
                    _.Move("********", DETALHE_DS06.DET6_CIDADE_SEG, DETALHE_DS03.DET3_CIDADE_SEG);

                    /*" -2830- MOVE '**' TO DET6-UF-SEG DET3-UF-SEG */
                    _.Move("**", DETALHE_DS06.DET6_UF_SEG, DETALHE_DS03.DET3_UF_SEG);

                    /*" -2831- MOVE '*******' TO DET6-CEP-SEG DET3-CEP-SEG */
                    _.Move("*******", DETALHE_DS06.DET6_CEP_SEG, DETALHE_DS03.DET3_CEP_SEG);

                    /*" -2832- ELSE */
                }
                else
                {


                    /*" -2833- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_SQLCODE);

                    /*" -2835- DISPLAY 'ERRO ACESSO DADOS DO SEGURADO => SQLCODE = ' WS-SQLCODE */
                    _.Display($"ERRO ACESSO DADOS DO SEGURADO => SQLCODE = {WS_SQLCODE}");

                    /*" -2836- DISPLAY 'NUM_CERTIFICADO = ' WS-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {WS_CERTIFICADO}");

                    /*" -2837- ADD 1 TO AC-DESPR-SEGVGAPH */
                    AC_DESPR_SEGVGAPH.Value = AC_DESPR_SEGVGAPH + 1;

                    /*" -2838- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2839- END-IF */
                }


                /*" -2839- END-IF. */
            }


        }

        [StopWatch]
        /*" R1920-00-DADOS-SEGURADO-DB-SELECT-1 */
        public void R1920_00_DADOS_SEGURADO_DB_SELECT_1()
        {
            /*" -2809- EXEC SQL SELECT T2.NOME_RAZAO, T2.CGCCPF, T3.ENDERECO, T3.BAIRRO, T3.CIDADE, T3.CEP, T3.SIGLA_UF INTO :WS-NOME-SEG, :WS-CGCCPF-SEG, :WS-ENDERECO-SEG, :WS-BAIRRO-SEG, :WS-CIDADE-SEG, :WS-CEP-SEG, :WS-UF-SEG FROM SEGUROS.PROPOSTAS_VA T1, SEGUROS.CLIENTES T2, SEGUROS.ENDERECOS T3 WHERE T1.NUM_CERTIFICADO = :WS-CERTIFICADO AND T1.COD_CLIENTE = T2.COD_CLIENTE AND T1.COD_CLIENTE = T3.COD_CLIENTE AND T1.OCOREND = T3.OCORR_ENDERECO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1 = new R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1()
            {
                WS_CERTIFICADO = WS_CERTIFICADO.ToString(),
            };

            var executed_1 = R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1.Execute(r1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NOME_SEG, WS_NOME_SEG);
                _.Move(executed_1.WS_CGCCPF_SEG, WS_CGCCPF_SEG);
                _.Move(executed_1.WS_ENDERECO_SEG, WS_ENDERECO_SEG);
                _.Move(executed_1.WS_BAIRRO_SEG, WS_BAIRRO_SEG);
                _.Move(executed_1.WS_CIDADE_SEG, WS_CIDADE_SEG);
                _.Move(executed_1.WS_CEP_SEG, WS_CEP_SEG);
                _.Move(executed_1.WS_UF_SEG, WS_UF_SEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1920_99_SAIDA*/

        [StopWatch]
        /*" R1950-00-PRIMEIRO-NOME-SECTION */
        private void R1950_00_PRIMEIRO_NOME_SECTION()
        {
            /*" -2848- MOVE '1950' TO WNR-EXEC-SQL. */
            _.Move("1950", WABEND.WNR_EXEC_SQL);

            /*" -2848- MOVE 1 TO WIND-N. */
            _.Move(1, WIND_N);

            /*" -0- FLUXCONTROL_PERFORM R1950_10_LOOP */

            R1950_10_LOOP();

        }

        [StopWatch]
        /*" R1950-10-LOOP */
        private void R1950_10_LOOP(bool isPerform = false)
        {
            /*" -2853- IF WIND-N GREATER 40 */

            if (WIND_N > 40)
            {

                /*" -2854- DISPLAY '*** VA1436B TAB NOMES ESTOURADA ' */
                _.Display($"*** VA1436B TAB NOMES ESTOURADA ");

                /*" -2856- GO TO R1950-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2858- IF TAB-NOME (WIND-N) EQUAL SPACES AND WIND-N EQUAL 1 */

            if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[WIND_N] == string.Empty && WIND_N == 1)
            {

                /*" -2859- ADD 1 TO WIND-N */
                WIND_N.Value = WIND_N + 1;

                /*" -2860- GO TO R1950-10-LOOP */
                new Task(() => R1950_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2861- ELSE */
            }
            else
            {


                /*" -2863- IF TAB-NOME (WIND-N) EQUAL SPACES AND WIND-N EQUAL 2 */

                if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[WIND_N] == string.Empty && WIND_N == 2)
                {

                    /*" -2864- DISPLAY 'PRIMEIRAS POSICOES DO NOME EM BRANCO ' */
                    _.Display($"PRIMEIRAS POSICOES DO NOME EM BRANCO ");

                    /*" -2865- ADD 1 TO WIND-N */
                    WIND_N.Value = WIND_N + 1;

                    /*" -2867- GO TO R1950-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2868- IF TAB-NOME (WIND-N) NOT EQUAL SPACES */

            if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[WIND_N] != string.Empty)
            {

                /*" -2869- MOVE TAB-NOME (WIND-N) TO TAB-NOME1 (WIND-N) */
                _.Move(TABELA_NOMES.TAB_NOMES_R.TAB_NOME[WIND_N], TABELA_NOMES1.TAB_NOMES1_R.TAB_NOME1[WIND_N]);

                /*" -2870- ADD 1 TO WIND-N */
                WIND_N.Value = WIND_N + 1;

                /*" -2872- GO TO R1950-10-LOOP. */
                new Task(() => R1950_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2872- MOVE ',' TO TAB-NOME1 (WIND-N). */
            _.Move(",", TABELA_NOMES1.TAB_NOMES1_R.TAB_NOME1[WIND_N]);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -2882- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -2887- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE-ANT COBMENVG-NUM-APOLICE WHOST-NRAPOLICE. */
            _.Move(REG_SVP0437B.SVA_NRAPOLICE, WS_NUM_APOLICE_ANT, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE, WHOST_NRAPOLICE);

            /*" -2891- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT COBMENVG-CODSUBES WHOST-CODSUBES. */
            _.Move(REG_SVP0437B.SVA_CODSUBES, WS_CODSUBES_ANT, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES, WHOST_CODSUBES);

            /*" -2893- PERFORM R2710-00-SELECT-ESTIP. */

            R2710_00_SELECT_ESTIP_SECTION();

            /*" -2895- MOVE CLIENTES-NOME-RAZAO TO DET6-ESTIPULANTE DET3-ESTIPULANTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETALHE_DS06.DET6_ESTIPULANTE, DETALHE_DS03.DET3_ESTIPULANTE);

            /*" -2897- PERFORM R2900-00-TRATA-RELATORI. */

            R2900_00_TRATA_RELATORI_SECTION();

            /*" -2899- PERFORM R2700-00-SELECT-PRODUVG. */

            R2700_00_SELECT_PRODUVG_SECTION();

            /*" -2900- MOVE PRODUVG-COD-PRODUTO TO LR08-COD-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, LR08_LINHA08.LR08_TIPO.LR08_COD_PRODUTO);

            /*" -2902- MOVE PRODUVG-NOME-PRODUTO TO LR08-NOM-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, LR08_LINHA08.LR08_TIPO.LR08_NOM_PRODUTO);

            /*" -2908- PERFORM R2010-00-PROCESSA-PRODUTO UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVP0437B.SVA_NRAPOLICE != WS_NUM_APOLICE_ANT || REG_SVP0437B.SVA_CODSUBES != WS_CODSUBES_ANT || WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_SECTION();
            }

            /*" -2909- IF AC-CONTA1 EQUAL ZEROS */

            if (AC_CONTA1 == 00)
            {

                /*" -2911- GO TO R2000-10-ZERA. */

                R2000_10_ZERA(); //GOTO
                return;
            }


            /*" -2915- MOVE 'C' TO WS-CONTR-PRODU. */
            _.Move("C", WS_CONTR_PRODU);

            /*" -2917- PERFORM R3100-00-SEPARA-PRODUTO. */

            R3100_00_SEPARA_PRODUTO_SECTION();

            /*" -2919- PERFORM R3000-00-IMPRIME-LST. */

            R3000_00_IMPRIME_LST_SECTION();

            /*" -2920- WRITE FVP0437B-RECORD FROM LC12-LINHA12 */
            _.Move(LC12_LINHA12.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -2922- WRITE FVP0437B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -2924- MOVE 'R' TO WS-CONTR-PRODU. */
            _.Move("R", WS_CONTR_PRODU);

            /*" -2924- PERFORM R3100-00-SEPARA-PRODUTO. */

            R3100_00_SEPARA_PRODUTO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2000_10_ZERA */

            R2000_10_ZERA();

        }

        [StopWatch]
        /*" R2000-10-ZERA */
        private void R2000_10_ZERA(bool isPerform = false)
        {
            /*" -2938- MOVE ZEROS TO TABELA-TOTAIS WS-AMARRADO WS-CONTR-AMAR WS-CONTR-OBJ WS-CONTR-200 WS-SEQ AC-QTD-OBJ AC-CONTA1 AC-PAGINA WS-OCORR WIND. */
            _.Move(0, TABELA_TOTAIS, WS_AMARRADO, WS_CONTR_AMAR, WS_CONTR_OBJ, WS_CONTR_200, WS_SEQ, AC_QTD_OBJ, AC_CONTA1, AC_PAGINA, WS_OCORR, WIND);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -2950- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", WABEND.WNR_EXEC_SQL);

            /*" -2951- MOVE SVA-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SVP0437B.SVA_CEP_G, WS_CEP_G_ANT);

            /*" -2952- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SVP0437B.SVA_NOME_CORREIO, WS_NOME_COR_ANT);

            /*" -2955- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, WS_CONTR_AMAR, WS_CONTR_OBJ);

            /*" -2957- MOVE TAB-FX-INI (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVP0437B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_INI, WS_NUM_CEP_AUX);

            /*" -2958- MOVE WS-CEP-AUX TO LF04-FAIXA1. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, LF04_LINHA04.LF04_FAIXA1);

            /*" -2959- MOVE WS-CEP-COMPL-AUX TO LF04-FAIXA1C. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, LF04_LINHA04.LF04_FAIXA1C);

            /*" -2961- MOVE TAB-FX-FIM (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVP0437B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_FIM, WS_NUM_CEP_AUX);

            /*" -2962- MOVE WS-CEP-AUX TO LF04-FAIXA2. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, LF04_LINHA04.LF04_FAIXA2);

            /*" -2964- MOVE WS-CEP-COMPL-AUX TO LF04-FAIXA2C. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, LF04_LINHA04.LF04_FAIXA2C);

            /*" -2971- PERFORM R2100-00-PROCESSA-CEP UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVP0437B.SVA_NRAPOLICE != WS_NUM_APOLICE_ANT || REG_SVP0437B.SVA_CODSUBES != WS_CODSUBES_ANT || REG_SVP0437B.SVA_CEP_G != WS_CEP_G_ANT || WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

            /*" -2973- MOVE WS-AMARRADO TO TAB1-AMARF(WS-CEP-G-ANT). */
            _.Move(WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[WS_CEP_G_ANT].TAB1_AMARF);

            /*" -2974- MOVE WS-SEQ TO TAB1-OBJF (WS-CEP-G-ANT). */
            _.Move(WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[WS_CEP_G_ANT].TAB1_OBJF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -2985- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -2991- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AC_CONTA1, AC_QTD_OBJ, WS_CONTR_200);

            /*" -2993- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE. */
            _.Move(REG_SVP0437B.SVA_NRAPOLICE, WS_CHAVE_R.WS_NUM_APOLICE);

            /*" -2995- MOVE SVA-CODSUBES TO WS-CODSUBES. */
            _.Move(REG_SVP0437B.SVA_CODSUBES, WS_CHAVE_R.WS_CODSUBES);

            /*" -2999- MOVE SVA-CODOPER TO WS-OPER-ANT WHOST-CODOPER WS-CODOPER. */
            _.Move(REG_SVP0437B.SVA_CODOPER, WS_OPER_ANT);
            _.Move(REG_SVP0437B.SVA_CODOPER, WHOST_CODOPER);
            _.Move(REG_SVP0437B.SVA_CODOPER, WS_CHAVE_R.WS_CODOPER);


            /*" -3000- MOVE 1 TO INF. */
            _.Move(1, INF);

            /*" -3002- MOVE WINDM TO SUP. */
            _.Move(WINDM, SUP);

            /*" -3004- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -3005- IF SVA-PRODUTO EQUAL 7707 */

            if (REG_SVP0437B.SVA_PRODUTO == 7707)
            {

                /*" -3006- PERFORM R1051-00-PROPOSTA-FIDEL */

                R1051_00_PROPOSTA_FIDEL_SECTION();

                /*" -3008- END-IF */
            }


            /*" -3009- MOVE SVA-DTINIVIG TO WS-DATA-SQL */
            _.Move(REG_SVP0437B.SVA_DTINIVIG, WS_DATA_SQL);

            /*" -3010- MOVE WS-ANO-SQL TO WS-ANO-I */
            _.Move(WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3011- MOVE WS-MES-SQL TO WS-MES-I */
            _.Move(WS_DATA_SQL.WS_MES_SQL, WS_DATA_I.WS_MES_I);

            /*" -3012- MOVE WS-DIA-SQL TO WS-DIA-I */
            _.Move(WS_DATA_SQL.WS_DIA_SQL, WS_DATA_I.WS_DIA_I);

            /*" -3014- MOVE WS-DATA-I TO WS-DT-EMI */
            _.Move(WS_DATA_I, WS_DT_EMI);

            /*" -3015- IF SVA-PRODUTO = 7705 OR 7715 OR 7725 */

            if (REG_SVP0437B.SVA_PRODUTO.In("7705", "7715", "7725"))
            {

                /*" -3016- MOVE 'ds03' TO WS-TIPO-FORM-REF */
                _.Move("ds03", WS_TIPO_FORM_REF);

                /*" -3018- END-IF */
            }


            /*" -3019- MOVE WS-DD-EMI TO WS-DD-INV */
            _.Move(WS_DT_EMI.WS_DD_EMI, WS_DT_AVERB_INV.WS_DD_INV);

            /*" -3020- MOVE WS-MM-EMI TO WS-MM-INV */
            _.Move(WS_DT_EMI.WS_MM_EMI, WS_DT_AVERB_INV.WS_MM_INV);

            /*" -3022- MOVE WS-AAAA-EMI TO WS-AAAA-INV */
            _.Move(WS_DT_EMI.WS_AAAA_EMI, WS_DT_AVERB_INV.WS_AAAA_INV);

            /*" -3023- IF SVA-PRODUTO = 7705 OR 7715 OR 7725 */

            if (REG_SVP0437B.SVA_PRODUTO.In("7705", "7715", "7725"))
            {

                /*" -3024- IF WS-DT-AVERB-INV > 20160630 */

                if (WS_DT_AVERB_INV.GetMoveValues().ToInt() > 20160630)
                {

                    /*" -3025- MOVE 'ds24' TO WS-TIPO-FORM-REF */
                    _.Move("ds24", WS_TIPO_FORM_REF);

                    /*" -3026- END-IF */
                }


                /*" -3027- END-IF */
            }


            /*" -3028- IF SVA-PRODUTO = 7705 OR 7715 OR 7725 */

            if (REG_SVP0437B.SVA_PRODUTO.In("7705", "7715", "7725"))
            {

                /*" -3029- MOVE WS-TIPO-FORM-REF TO LC09-JDE */
                _.Move(WS_TIPO_FORM_REF, AREA_DE_WORK.LC09_JDE);

                /*" -3031- END-IF */
            }


            /*" -3032- IF SVA-PRODUTO NOT EQUAL 7707 */

            if (REG_SVP0437B.SVA_PRODUTO != 7707)
            {

                /*" -3034- WRITE RVP0437B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVP0437B_RECORD);

                RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                /*" -3036- PERFORM R2202-00-GRAVA-LINHA09 */

                R2202_00_GRAVA_LINHA09_SECTION();

                /*" -3037- IF LC09-JDE = 'DS24' OR 'ds24' */

                if (AREA_DE_WORK.LC09_JDE.In("DS24", "ds24"))
                {

                    /*" -3038- MOVE 'pe03' TO WS-TIPO-FORM */
                    _.Move("pe03", WS_TIPO_FORM);

                    /*" -3041- END-IF */
                }


                /*" -3042- IF WS-TIPO-FORM = 'pe04' */

                if (WS_TIPO_FORM == "pe04")
                {

                    /*" -3043- WRITE RVP0437B-RECORD FROM CABEC-DS03 */
                    _.Move(AREA_DE_WORK.CABEC_DS03.GetMoveValues(), RVP0437B_RECORD);

                    RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                    /*" -3044- ELSE */
                }
                else
                {


                    /*" -3045- IF WS-TIPO-FORM = 'pe03' OR 'pe01' OR 'vp01' */

                    if (WS_TIPO_FORM.In("pe03", "pe01", "vp01"))
                    {

                        /*" -3046- WRITE RVP0437B-RECORD FROM CABEC-DS06 */
                        _.Move(AREA_DE_WORK.CABEC_DS06.GetMoveValues(), RVP0437B_RECORD);

                        RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                        /*" -3047- ELSE */
                    }
                    else
                    {


                        /*" -3048- DISPLAY 'CERTIFICADO NAO EMITIDO = ' SVA-NRCERTIF */
                        _.Display($"CERTIFICADO NAO EMITIDO = {REG_SVP0437B.SVA_NRCERTIF}");

                        /*" -3050- DISPLAY 'tipo de formulario nao tratado = ' WS-TIPO-FORM */
                        _.Display($"tipo de formulario nao tratado = {WS_TIPO_FORM}");

                        /*" -3051- ADD 1 TO AC-DESPR-SEGVGAPH */
                        AC_DESPR_SEGVGAPH.Value = AC_DESPR_SEGVGAPH + 1;

                        /*" -3052- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3053- END-IF */
                    }


                    /*" -3054- END-IF */
                }


                /*" -3056- END-IF */
            }


            /*" -3057- IF DET3-COD-PRODUTO = 7705 OR 7713 OR 7715 OR 7725 */

            if (DETALHE_DS03.DET3_COD_PRODUTO.In("7705", "7713", "7715", "7725"))
            {

                /*" -3058- MOVE WS-TIPO-FORM-REF TO LC09-JDE */
                _.Move(WS_TIPO_FORM_REF, AREA_DE_WORK.LC09_JDE);

                /*" -3060- END-IF */
            }


            /*" -3061- IF SVA-PRODUTO EQUAL 7707 */

            if (REG_SVP0437B.SVA_PRODUTO == 7707)
            {

                /*" -3064- IF PROPOFID-OPRCTADEB EQUAL 001 OR PROPOFID-OPRCTADEB EQUAL 023 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 001 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 023)
                {

                    /*" -3065- CONTINUE */

                    /*" -3066- ELSE */
                }
                else
                {


                    /*" -3070- WRITE RVP0437B-RECORD FROM LC08-LINHA08 */
                    _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVP0437B_RECORD);

                    RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                    /*" -3071- IF WS-TIPO-FORM = 'pe04' */

                    if (WS_TIPO_FORM == "pe04")
                    {

                        /*" -3072- WRITE RVP0437B-RECORD FROM CABEC-DS03 */
                        _.Move(AREA_DE_WORK.CABEC_DS03.GetMoveValues(), RVP0437B_RECORD);

                        RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                        /*" -3073- ELSE */
                    }
                    else
                    {


                        /*" -3074- IF WS-TIPO-FORM = 'pe03' OR 'pe01' OR 'vp01' */

                        if (WS_TIPO_FORM.In("pe03", "pe01", "vp01"))
                        {

                            /*" -3075- WRITE RVP0437B-RECORD FROM CABEC-DS06 */
                            _.Move(AREA_DE_WORK.CABEC_DS06.GetMoveValues(), RVP0437B_RECORD);

                            RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                            /*" -3076- ELSE */
                        }
                        else
                        {


                            /*" -3077- DISPLAY 'CERTIFICADO NAO EMITIDO = ' SVA-NRCERTIF */
                            _.Display($"CERTIFICADO NAO EMITIDO = {REG_SVP0437B.SVA_NRCERTIF}");

                            /*" -3079- DISPLAY '*tipo de formulario nao tratado = ' WS-TIPO-FORM */
                            _.Display($"*tipo de formulario nao tratado = {WS_TIPO_FORM}");

                            /*" -3080- ADD 1 TO AC-DESPR-SEGVGAPH */
                            AC_DESPR_SEGVGAPH.Value = AC_DESPR_SEGVGAPH + 1;

                            /*" -3081- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -3082- END-IF */
                        }


                        /*" -3083- END-IF */
                    }


                    /*" -3084- END-IF */
                }


                /*" -3087- END-IF */
            }


            /*" -3096- PERFORM R2200-00-PROCESSA-FAC UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 > 199 OR SVA-CODOPER NOT EQUAL WS-OPER-ANT. */

            while (!(REG_SVP0437B.SVA_NRAPOLICE != WS_NUM_APOLICE_ANT || REG_SVP0437B.SVA_CODSUBES != WS_CODSUBES_ANT || REG_SVP0437B.SVA_CEP_G != WS_CEP_G_ANT || WFIM_SORT == "S" || AC_CONTA1 > 199 || REG_SVP0437B.SVA_CODOPER != WS_OPER_ANT))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

            /*" -3097- IF AC-CONTA1 EQUAL ZEROS */

            if (AC_CONTA1 == 00)
            {

                /*" -3099- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3103- ADD 1 TO WS-AMARRADO TAB1-QTD-AMAR(WS-CEP-G-ANT). */
            WS_AMARRADO.Value = WS_AMARRADO + 1;
            TABELA_TOTAIS.TAB_TOTAIS[WS_CEP_G_ANT].TAB1_QTD_AMAR.Value = TABELA_TOTAIS.TAB_TOTAIS[WS_CEP_G_ANT].TAB1_QTD_AMAR + 1;

            /*" -3104- IF WS-CONTR-AMAR EQUAL ZEROS */

            if (WS_CONTR_AMAR == 00)
            {

                /*" -3105- MOVE 1 TO WS-CONTR-AMAR */
                _.Move(1, WS_CONTR_AMAR);

                /*" -3108- MOVE WS-AMARRADO TO TAB1-AMARI(WS-CEP-G-ANT). */
                _.Move(WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[WS_CEP_G_ANT].TAB1_AMARI);
            }


            /*" -3109- MOVE WS-AMARRADO TO LF04-AMARRADO. */
            _.Move(WS_AMARRADO, LF04_LINHA04.LF04_AMARRADO);

            /*" -3110- MOVE AC-QTD-OBJ TO LF04-QTD-OBJ. */
            _.Move(AC_QTD_OBJ, LF04_LINHA04.LF04_QTD_OBJ);

            /*" -3111- MOVE WS-SEQ-INICIAL TO LF04-SEQ-INICIAL. */
            _.Move(WS_SEQ_INICIAL, LF04_LINHA04.LF04_SEQ_INICIAL);

            /*" -3115- MOVE WS-SEQ TO LF04-SEQ-FINAL. */
            _.Move(WS_SEQ, LF04_LINHA04.LF04_SEQ_FINAL);

            /*" -3116- WRITE RVP0437B-RECORD FROM LC12-LINHA12 */
            _.Move(LC12_LINHA12.GetMoveValues(), RVP0437B_RECORD);

            RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

            /*" -3118- WRITE RVP0437B-RECORD FROM LC01-LINHA01 */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVP0437B_RECORD);

            RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

            /*" -3119- IF AC-CONTA1 GREATER 199 */

            if (AC_CONTA1 > 199)
            {

                /*" -3121- MOVE TAB-FX-NOME (WS-CEP-G-ANT) TO LF04-NOME-FAIXA */
                _.Move(TABELA_CEP.CEP[WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_NOME, LF04_LINHA04.LF04_NOME_FAIXA);

                /*" -3122- ELSE */
            }
            else
            {


                /*" -3125- MOVE TAB-FX-CENTR(WS-CEP-G-ANT) TO LF04-NOME-FAIXA. */
                _.Move(TABELA_CEP.CEP[WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_CENTR, LF04_LINHA04.LF04_NOME_FAIXA);
            }


            /*" -3126- MOVE ZEROS TO AC-QTD-OBJ. */
            _.Move(0, AC_QTD_OBJ);

            /*" -3126- MOVE 1 TO WS-CONTROLE. */
            _.Move(1, WS_CONTROLE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -3137- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -3138- MOVE SVA-NRAPOLICE TO DET6-APOLICE DET3-APOLICE */
            _.Move(REG_SVP0437B.SVA_NRAPOLICE, DETALHE_DS06.DET6_APOLICE, DETALHE_DS03.DET3_APOLICE);

            /*" -3140- MOVE SVA-NRCERTIF TO WS-CERTIF WHOST-NRCERTIF */
            _.Move(REG_SVP0437B.SVA_NRCERTIF, WS_CERTIF, WHOST_NRCERTIF);

            /*" -3141- PERFORM R1050-00-VERIFICA-CAP. */

            R1050_00_VERIFICA_CAP_SECTION();

            /*" -3142- MOVE SPACES TO DET6-NUM-SORTE */
            _.Move("", DETALHE_DS06.DET6_NUM_SORTE);

            /*" -3143- IF VG0716S-DES-COMBINACAO EQUAL SPACES */

            if (VG0716S_DES_COMBINACAO.IsEmpty())
            {

                /*" -3144- MOVE SPACES TO DET6-NUM-SORTE */
                _.Move("", DETALHE_DS06.DET6_NUM_SORTE);

                /*" -3145- ELSE */
            }
            else
            {


                /*" -3146- MOVE VG0716S-DES-COMBINACAO TO DET6-NUM-SORTE */
                _.Move(VG0716S_DES_COMBINACAO, DETALHE_DS06.DET6_NUM_SORTE);

                /*" -3147- END-IF. */
            }


            /*" -3150- MOVE SVA-PRODUTO TO DET6-COD-PRODUTO DET3-COD-PRODUTO. */
            _.Move(REG_SVP0437B.SVA_PRODUTO, DETALHE_DS06.DET6_COD_PRODUTO, DETALHE_DS03.DET3_COD_PRODUTO);

            /*" -3151- IF SVA-PRODUTO EQUAL 7707 */

            if (REG_SVP0437B.SVA_PRODUTO == 7707)
            {

                /*" -3153- IF PROPOFID-OPRCTADEB EQUAL 001 OR PROPOFID-OPRCTADEB EQUAL 023 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 001 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 023)
                {

                    /*" -3154- IF DET6-NUM-SORTE EQUAL SPACES */

                    if (DETALHE_DS06.DET6_NUM_SORTE.IsEmpty())
                    {

                        /*" -3155- GO TO R2200-40-NEXT */

                        R2200_40_NEXT(); //GOTO
                        return;

                        /*" -3156- END-IF */
                    }


                    /*" -3157- END-IF */
                }


                /*" -3159- END-IF */
            }


            /*" -3160- IF SVA-PRODUTO = 7707 */

            if (REG_SVP0437B.SVA_PRODUTO == 7707)
            {

                /*" -3161- MOVE 'ds06' TO LC09-JDE */
                _.Move("ds06", AREA_DE_WORK.LC09_JDE);

                /*" -3163- END-IF */
            }


            /*" -3164- IF SVA-PRODUTO EQUAL 7707 */

            if (REG_SVP0437B.SVA_PRODUTO == 7707)
            {

                /*" -3166- IF PROPOFID-OPRCTADEB EQUAL 001 OR PROPOFID-OPRCTADEB EQUAL 023 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 001 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 023)
                {

                    /*" -3168- WRITE RVP0437B-RECORD FROM LC08-LINHA08 */
                    _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVP0437B_RECORD);

                    RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                    /*" -3170- PERFORM R2202-00-GRAVA-LINHA09 */

                    R2202_00_GRAVA_LINHA09_SECTION();

                    /*" -3171- IF WS-TIPO-FORM = 'pe04' */

                    if (WS_TIPO_FORM == "pe04")
                    {

                        /*" -3172- WRITE RVP0437B-RECORD FROM CABEC-DS03 */
                        _.Move(AREA_DE_WORK.CABEC_DS03.GetMoveValues(), RVP0437B_RECORD);

                        RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                        /*" -3173- ELSE */
                    }
                    else
                    {


                        /*" -3174- IF WS-TIPO-FORM = 'pe03' OR 'pe01' OR 'vp01' */

                        if (WS_TIPO_FORM.In("pe03", "pe01", "vp01"))
                        {

                            /*" -3175- WRITE RVP0437B-RECORD FROM CABEC-DS06 */
                            _.Move(AREA_DE_WORK.CABEC_DS06.GetMoveValues(), RVP0437B_RECORD);

                            RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                            /*" -3176- ELSE */
                        }
                        else
                        {


                            /*" -3177- DISPLAY 'CERTIFICADO NAO EMITIDO = ' SVA-NRCERTIF */
                            _.Display($"CERTIFICADO NAO EMITIDO = {REG_SVP0437B.SVA_NRCERTIF}");

                            /*" -3179- DISPLAY '**tipo de formulario nao tratado = ' WS-TIPO-FORM */
                            _.Display($"**tipo de formulario nao tratado = {WS_TIPO_FORM}");

                            /*" -3180- ADD 1 TO AC-DESPR-SEGVGAPH */
                            AC_DESPR_SEGVGAPH.Value = AC_DESPR_SEGVGAPH + 1;

                            /*" -3181- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -3182- END-IF */
                        }


                        /*" -3183- END-IF */
                    }


                    /*" -3184- END-IF */
                }


                /*" -3188- END-IF */
            }


            /*" -3189- IF SVA-SITSEG NOT EQUAL '0' */

            if (REG_SVP0437B.SVA_SITSEG != "0")
            {

                /*" -3190- MOVE SVA-CODUSU TO WHOST-CODUSU */
                _.Move(REG_SVP0437B.SVA_CODUSU, WHOST_CODUSU);

                /*" -3191- PERFORM R2205-00-SELECT-USUARIOS */

                R2205_00_SELECT_USUARIOS_SECTION();

                /*" -3192- IF WTEM-USUARIOS EQUAL 'N' */

                if (WTEM_USUARIOS == "N")
                {

                    /*" -3193- ADD 1 TO AC-DESPR-CANCEL */
                    AC_DESPR_CANCEL.Value = AC_DESPR_CANCEL + 1;

                    /*" -3194- DISPLAY 'VAI ATUALIZAR RELATORI - R2200-35' */
                    _.Display($"VAI ATUALIZAR RELATORI - R2200-35");

                    /*" -3198- GO TO R2200-35-ATU-RELATORI. */

                    R2200_35_ATU_RELATORI(); //GOTO
                    return;
                }

            }


            /*" -3200- MOVE SVA-TIPOSEGU TO WHOST-TIPOSEGU */
            _.Move(REG_SVP0437B.SVA_TIPOSEGU, WHOST_TIPOSEGU);

            /*" -3203- MOVE WS-NRCERTIF TO DET6-NRCERTIF DET6-NRCONTRATO DET3-NRCERTIF DET3-NRCONTRATO DET6-NRPROPOST DET3-NRPROPOST */
            _.Move(WS_CERTIF_R.WS_NRCERTIF, DETALHE_DS06.DET6_NRCERTIF, DETALHE_DS06.DET6_NRCONTRATO, DETALHE_DS03.DET3_NRCERTIF, DETALHE_DS03.DET3_NRCONTRATO, DETALHE_DS06.DET6_NRPROPOST, DETALHE_DS03.DET3_NRPROPOST);

            /*" -3206- MOVE WS-DVCERTIF TO DET6-DVCERTIF DET6-DVCONTRATO DET3-DVCERTIF DET3-DVCONTRATO DET6-DVPROPOST DET3-DVPROPOST */
            _.Move(WS_CERTIF_R.WS_DVCERTIF, DETALHE_DS06.DET6_DVCERTIF, DETALHE_DS06.DET6_DVCONTRATO, DETALHE_DS03.DET3_DVCERTIF, DETALHE_DS03.DET3_DVCONTRATO, DETALHE_DS06.DET6_DVPROPOST, DETALHE_DS03.DET3_DVPROPOST);

            /*" -3207- MOVE SVA-DTINIVIG TO WS-DATA-SQL */
            _.Move(REG_SVP0437B.SVA_DTINIVIG, WS_DATA_SQL);

            /*" -3208- MOVE WS-ANO-SQL TO WS-ANO-I */
            _.Move(WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3209- MOVE WS-MES-SQL TO WS-MES-I */
            _.Move(WS_DATA_SQL.WS_MES_SQL, WS_DATA_I.WS_MES_I);

            /*" -3210- MOVE WS-DIA-SQL TO WS-DIA-I */
            _.Move(WS_DATA_SQL.WS_DIA_SQL, WS_DATA_I.WS_DIA_I);

            /*" -3233- MOVE WS-DATA-I TO DET6-DTINIVIG DET3-DTINIVIG */
            _.Move(WS_DATA_I, DETALHE_DS06.DET6_DTINIVIG, DETALHE_DS03.DET3_DTINIVIG);

            /*" -3236- MOVE SPACES TO TABELA-NOMES TABELA-NOMES1. */
            _.Move("", TABELA_NOMES, TABELA_NOMES1);

            /*" -3238- MOVE 'CAIXA SEGURADORA S/A' TO DET6-NOME-RAZAO-EMP DET3-NOME-RAZAO-EMP */
            _.Move("CAIXA SEGURADORA S/A", DETALHE_DS06.DET6_NOME_RAZAO_EMP, DETALHE_DS03.DET3_NOME_RAZAO_EMP);

            /*" -3240- MOVE '34.20.354/0001-10' TO DET6-CNPJ-EMP DET3-CNPJ-EMP */
            _.Move("34.20.354/0001-10", DETALHE_DS06.DET6_CNPJ_EMP, DETALHE_DS03.DET3_CNPJ_EMP);

            /*" -3242- MOVE '05631' TO DET6-COD-SUSEP-EMP DET3-COD-SUSEP-EMP */
            _.Move("05631", DETALHE_DS06.DET6_COD_SUSEP_EMP, DETALHE_DS03.DET3_COD_SUSEP_EMP);

            /*" -3244- MOVE 'SHN QUADRA 1 BLOCO E - EDIFICIO SEDE CAIXA SEGURADORA' TO DET6-ENDERECO-EMP DET3-ENDERECO-EMP */
            _.Move("SHN QUADRA 1 BLOCO E - EDIFICIO SEDE CAIXA SEGURADORA", DETALHE_DS06.DET6_ENDERECO_EMP, DETALHE_DS03.DET3_ENDERECO_EMP);

            /*" -3245- MOVE 'ASA NORTE' TO DET6-BAIRRO-EMP DET3-BAIRRO-EMP */
            _.Move("ASA NORTE", DETALHE_DS06.DET6_BAIRRO_EMP, DETALHE_DS03.DET3_BAIRRO_EMP);

            /*" -3246- MOVE 'BRASILIA' TO DET6-CIDADE-EMP DET3-CIDADE-EMP */
            _.Move("BRASILIA", DETALHE_DS06.DET6_CIDADE_EMP, DETALHE_DS03.DET3_CIDADE_EMP);

            /*" -3247- MOVE 'DF' TO DET6-UF-EMP DET3-UF-EMP */
            _.Move("DF", DETALHE_DS06.DET6_UF_EMP, DETALHE_DS03.DET3_UF_EMP);

            /*" -3248- MOVE '70701-050' TO DET6-CEP-EMP DET3-CEP-EMP */
            _.Move("70701-050", DETALHE_DS06.DET6_CEP_EMP, DETALHE_DS03.DET3_CEP_EMP);

            /*" -3249- PERFORM R1910-00-NOME-CORRETOR. */

            R1910_00_NOME_CORRETOR_SECTION();

            /*" -3255- MOVE SPACES TO DET6-TEL-ESTIP DET3-TEL-ESTIP DET6-END-ESTIP DET3-END-ESTIP DET6-BAIRRO-ESTIP DET3-BAIRRO-ESTIP DET6-CIDADE-ESTIP DET3-CIDADE-ESTIP DET6-CEP-ESTIP DET3-CEP-ESTIP DET6-UF-ESTIP DET3-UF-ESTIP. */
            _.Move("", DETALHE_DS06.DET6_TEL_ESTIP, DETALHE_DS03.DET3_TEL_ESTIP, DETALHE_DS06.DET6_END_ESTIP, DETALHE_DS03.DET3_END_ESTIP, DETALHE_DS06.DET6_BAIRRO_ESTIP, DETALHE_DS03.DET3_BAIRRO_ESTIP, DETALHE_DS06.DET6_CIDADE_ESTIP, DETALHE_DS03.DET3_CIDADE_ESTIP, DETALHE_DS06.DET6_CEP_ESTIP, DETALHE_DS03.DET3_CEP_ESTIP, DETALHE_DS06.DET6_UF_ESTIP, DETALHE_DS03.DET3_UF_ESTIP);

            /*" -3257- PERFORM R1920-00-DADOS-SEGURADO */

            R1920_00_DADOS_SEGURADO_SECTION();

            /*" -3259- PERFORM R2901-00-TRATA-EMAIL-TEL */

            R2901_00_TRATA_EMAIL_TEL_SECTION();

            /*" -3260- MOVE SVA-NOME-RAZAO TO TAB-NOMES. */
            _.Move(REG_SVP0437B.SVA_NOME_RAZAO, TABELA_NOMES.TAB_NOMES);

            /*" -3262- PERFORM R1950-00-PRIMEIRO-NOME. */

            R1950_00_PRIMEIRO_NOME_SECTION();

            /*" -3263- MOVE SVA-CPF TO WS-CPF */
            _.Move(REG_SVP0437B.SVA_CPF, WS_CPF);

            /*" -3264- MOVE WS-NRCPF TO DET6-NRCPF DET3-NRCPF */
            _.Move(WS_CPF_R.WS_NRCPF, DETALHE_DS06.DET6_NRCPF, DETALHE_DS03.DET3_NRCPF);

            /*" -3271- MOVE WS-DVCPF TO DET6-DVCPF DET3-DVCPF. */
            _.Move(WS_CPF_R.WS_DVCPF, DETALHE_DS06.DET6_DVCPF, DETALHE_DS03.DET3_DVCPF);

            /*" -3293- MOVE ZEROS TO LK-APOLICE LK-SUBGRUPO LK-IDADE LK-SALARIO LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-RETURN-CODE */
            _.Move(0, PARAMETROS.LK_APOLICE, PARAMETROS.LK_SUBGRUPO, PARAMETROS.LK_IDADE, PARAMETROS.LK_SALARIO, PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE, PARAMETROS.LK_COBT_ASS_MEDICA, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_INTERNACAO, PARAMETROS.LK_PREM_MORTE_NATURAL, PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS, PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_RETURN_CODE);

            /*" -3297- MOVE SPACES TO LK-NASCIMENTO LK-MENSAGEM. */
            _.Move("", PARAMETROS.LK_NASCIMENTO, PARAMETROS.LK_MENSAGEM);

            /*" -3298- MOVE SVA-NRAPOLICE TO LK-APOLICE. */
            _.Move(REG_SVP0437B.SVA_NRAPOLICE, PARAMETROS.LK_APOLICE);

            /*" -3300- MOVE SVA-CODSUBES TO LK-SUBGRUPO. */
            _.Move(REG_SVP0437B.SVA_CODSUBES, PARAMETROS.LK_SUBGRUPO);

            /*" -3303- MOVE '220A' TO WNR-EXEC-SQL. */
            _.Move("220A", WABEND.WNR_EXEC_SQL);

            /*" -3305- PERFORM R2800-00-SELECT-SEGURVGA. */

            R2800_00_SELECT_SEGURVGA_SECTION();

            /*" -3308- MOVE '220B' TO WNR-EXEC-SQL. */
            _.Move("220B", WABEND.WNR_EXEC_SQL);

            /*" -3320- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_1 */

            R2200_00_PROCESSA_FAC_DB_SELECT_1();

            /*" -3323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3324- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3325- ADD 1 TO AC-DESPR-SEGVGAPH */
                    AC_DESPR_SEGVGAPH.Value = AC_DESPR_SEGVGAPH + 1;

                    /*" -3326- GO TO R2200-40-NEXT */

                    R2200_40_NEXT(); //GOTO
                    return;

                    /*" -3327- ELSE */
                }
                else
                {


                    /*" -3329- DISPLAY 'ERRO ACESSO SEGURADOSVGAP_HIST ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO SEGURADOSVGAP_HIST {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3330- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVP0437B.SVA_NRCERTIF}");

                    /*" -3331- ADD 1 TO AC-DESPR-SEGVGAPH */
                    AC_DESPR_SEGVGAPH.Value = AC_DESPR_SEGVGAPH + 1;

                    /*" -3333- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3334- IF VIND-CODMOEDA-I < 0 */

            if (VIND_CODMOEDA_I < 0)
            {

                /*" -3337- MOVE 17 TO SEGVGAPH-COD-MOEDA-PRM. */
                _.Move(17, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM);
            }


            /*" -3340- MOVE '220C' TO WNR-EXEC-SQL. */
            _.Move("220C", WABEND.WNR_EXEC_SQL);

            /*" -3350- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_2 */

            R2200_00_PROCESSA_FAC_DB_SELECT_2();

            /*" -3353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3354- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3355- ADD 1 TO AC-DESPR-MOEDACOT */
                    AC_DESPR_MOEDACOT.Value = AC_DESPR_MOEDACOT + 1;

                    /*" -3356- GO TO R2200-40-NEXT */

                    R2200_40_NEXT(); //GOTO
                    return;

                    /*" -3357- ELSE */
                }
                else
                {


                    /*" -3361- DISPLAY 'ERRO ACESSO MOEDAS_COTACAO     ' SQLCODE ' ' SEGVGAPH-COD-MOEDA-PRM ' ' SEGVGAPH-DATA-MOVIMENTO ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO MOEDAS_COTACAO     {DB.SQLCODE} {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM} {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3362- ADD 1 TO AC-DESPR-MOEDACOT */
                    AC_DESPR_MOEDACOT.Value = AC_DESPR_MOEDACOT + 1;

                    /*" -3363- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3366- MOVE '220D' TO WNR-EXEC-SQL. */
            _.Move("220D", WABEND.WNR_EXEC_SQL);

            /*" -3384- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_3 */

            R2200_00_PROCESSA_FAC_DB_SELECT_3();

            /*" -3387- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3388- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3392- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-VG APOLICOB-PRM-TARIFARIO-VG APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_VG, APOLICOB_PRM_TARIFARIO_VG, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3393- ELSE */
                }
                else
                {


                    /*" -3395- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS 77/93' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS 77/93{DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3396- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVP0437B.SVA_NRCERTIF}");

                    /*" -3397- ADD 1 TO AC-DESPR-APOLICOB */
                    AC_DESPR_APOLICOB.Value = AC_DESPR_APOLICOB + 1;

                    /*" -3399- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3404- COMPUTE APOLICOB-IMP-SEGURADA-VG = APOLICOB-IMP-SEGURADA-VG * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_VG.Value = APOLICOB_IMP_SEGURADA_VG * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3409- COMPUTE APOLICOB-PRM-TARIFARIO-VG = APOLICOB-PRM-TARIFARIO-VG * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_PRM_TARIFARIO_VG.Value = APOLICOB_PRM_TARIFARIO_VG * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3412- MOVE '220E' TO WNR-EXEC-SQL. */
            _.Move("220E", WABEND.WNR_EXEC_SQL);

            /*" -3430- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_4 */

            R2200_00_PROCESSA_FAC_DB_SELECT_4();

            /*" -3433- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3434- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3438- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-AP APOLICOB-PRM-TARIFARIO-AP APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_AP, APOLICOB_PRM_TARIFARIO_AP, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3439- ELSE */
                }
                else
                {


                    /*" -3442- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-01 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-01 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3443- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVP0437B.SVA_NRCERTIF}");

                    /*" -3444- ADD 1 TO AC-DESPR-APOLICOB */
                    AC_DESPR_APOLICOB.Value = AC_DESPR_APOLICOB + 1;

                    /*" -3446- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3451- COMPUTE APOLICOB-IMP-SEGURADA-AP = APOLICOB-IMP-SEGURADA-AP * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_AP.Value = APOLICOB_IMP_SEGURADA_AP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3456- COMPUTE APOLICOB-PRM-TARIFARIO-AP = APOLICOB-PRM-TARIFARIO-AP * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_PRM_TARIFARIO_AP.Value = APOLICOB_PRM_TARIFARIO_AP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3457- IF SVA-VLPREMIO EQUAL ZEROS */

            if (REG_SVP0437B.SVA_VLPREMIO == 00)
            {

                /*" -3461- COMPUTE SVA-VLPREMIO = APOLICOB-PRM-TARIFARIO-VG + APOLICOB-PRM-TARIFARIO-AP. */
                REG_SVP0437B.SVA_VLPREMIO.Value = APOLICOB_PRM_TARIFARIO_VG + APOLICOB_PRM_TARIFARIO_AP;
            }


            /*" -3464- MOVE '220F' TO WNR-EXEC-SQL. */
            _.Move("220F", WABEND.WNR_EXEC_SQL);

            /*" -3480- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_5 */

            R2200_00_PROCESSA_FAC_DB_SELECT_5();

            /*" -3483- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3484- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3487- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-IP APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_IP, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3488- ELSE */
                }
                else
                {


                    /*" -3491- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-02 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-02 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3492- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVP0437B.SVA_NRCERTIF}");

                    /*" -3493- ADD 1 TO AC-DESPR-APOLICOB */
                    AC_DESPR_APOLICOB.Value = AC_DESPR_APOLICOB + 1;

                    /*" -3495- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3500- COMPUTE APOLICOB-IMP-SEGURADA-IP = APOLICOB-IMP-SEGURADA-IP * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_IP.Value = APOLICOB_IMP_SEGURADA_IP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3503- MOVE '220G' TO WNR-EXEC-SQL. */
            _.Move("220G", WABEND.WNR_EXEC_SQL);

            /*" -3519- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_6 */

            R2200_00_PROCESSA_FAC_DB_SELECT_6();

            /*" -3522- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3523- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3526- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-AMDS APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_AMDS, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3527- ELSE */
                }
                else
                {


                    /*" -3530- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-03 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-03 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3531- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVP0437B.SVA_NRCERTIF}");

                    /*" -3532- ADD 1 TO AC-DESPR-APOLICOB */
                    AC_DESPR_APOLICOB.Value = AC_DESPR_APOLICOB + 1;

                    /*" -3534- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3539- COMPUTE APOLICOB-IMP-SEGURADA-AMDS = APOLICOB-IMP-SEGURADA-AMDS * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_AMDS.Value = APOLICOB_IMP_SEGURADA_AMDS * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3542- MOVE '220H' TO WNR-EXEC-SQL. */
            _.Move("220H", WABEND.WNR_EXEC_SQL);

            /*" -3558- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_7 */

            R2200_00_PROCESSA_FAC_DB_SELECT_7();

            /*" -3561- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3562- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3565- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-DH APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_DH, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3566- ELSE */
                }
                else
                {


                    /*" -3569- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-04 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-04 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3570- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVP0437B.SVA_NRCERTIF}");

                    /*" -3571- ADD 1 TO AC-DESPR-APOLICOB */
                    AC_DESPR_APOLICOB.Value = AC_DESPR_APOLICOB + 1;

                    /*" -3573- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3578- COMPUTE APOLICOB-IMP-SEGURADA-DH = APOLICOB-IMP-SEGURADA-DH * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_DH.Value = APOLICOB_IMP_SEGURADA_DH * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3581- MOVE '220I' TO WNR-EXEC-SQL. */
            _.Move("220I", WABEND.WNR_EXEC_SQL);

            /*" -3597- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_8 */

            R2200_00_PROCESSA_FAC_DB_SELECT_8();

            /*" -3600- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3601- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3604- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-DIT APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_DIT, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3605- ELSE */
                }
                else
                {


                    /*" -3608- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-05 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-05 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3609- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVP0437B.SVA_NRCERTIF}");

                    /*" -3610- ADD 1 TO AC-DESPR-APOLICOB */
                    AC_DESPR_APOLICOB.Value = AC_DESPR_APOLICOB + 1;

                    /*" -3612- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3619- COMPUTE APOLICOB-IMP-SEGURADA-DIT = APOLICOB-IMP-SEGURADA-DIT * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_DIT.Value = APOLICOB_IMP_SEGURADA_DIT * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3621- MOVE APOLICOB-IMP-SEGURADA-VG TO LK-PURO-MORTE-NATURAL */
            _.Move(APOLICOB_IMP_SEGURADA_VG, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -3623- MOVE APOLICOB-IMP-SEGURADA-AP TO LK-PURO-MORTE-ACIDENTAL */
            _.Move(APOLICOB_IMP_SEGURADA_AP, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -3625- MOVE APOLICOB-IMP-SEGURADA-IP TO LK-PURO-INV-PERMANENTE */
            _.Move(APOLICOB_IMP_SEGURADA_IP, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -3627- MOVE APOLICOB-IMP-SEGURADA-AMDS TO LK-PURO-ASS-MEDICA */
            _.Move(APOLICOB_IMP_SEGURADA_AMDS, PARAMETROS.LK_PURO_ASS_MEDICA);

            /*" -3629- MOVE APOLICOB-IMP-SEGURADA-DH TO LK-PURO-DIARIA-HOSPITALAR */
            _.Move(APOLICOB_IMP_SEGURADA_DH, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR);

            /*" -3632- MOVE APOLICOB-IMP-SEGURADA-DIT TO LK-PURO-DIARIA-INTERNACAO */
            _.Move(APOLICOB_IMP_SEGURADA_DIT, PARAMETROS.LK_PURO_DIARIA_INTERNACAO);

            /*" -3634- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -3635- MOVE LK-RETURN-CODE TO WS-RETURN-CODE. */
            _.Move(PARAMETROS.LK_RETURN_CODE, WS_RETURN_CODE);

            /*" -3637- MOVE WS-RETURN-CODE TO WS-RETURN-CODE-M. */
            _.Move(WS_RETURN_CODE, WS_RETURN_CODE_M);

            /*" -3638- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK_RETURN_CODE != 00)
            {

                /*" -3639- DISPLAY 'ERRO SUBROTINA VG0710S ' */
                _.Display($"ERRO SUBROTINA VG0710S ");

                /*" -3640- DISPLAY 'MENSAGEM ' LK-MENSAGEM */
                _.Display($"MENSAGEM {PARAMETROS.LK_MENSAGEM}");

                /*" -3641- DISPLAY 'ERRO     ' LK-RETURN-CODE */
                _.Display($"ERRO     {PARAMETROS.LK_RETURN_CODE}");

                /*" -3642- DISPLAY 'ERRO     ' WS-RETURN-CODE-M */
                _.Display($"ERRO     {WS_RETURN_CODE_M}");

                /*" -3643- DISPLAY 'APOLICE  ' SVA-NRAPOLICE */
                _.Display($"APOLICE  {REG_SVP0437B.SVA_NRAPOLICE}");

                /*" -3644- DISPLAY 'CODSUBES ' SVA-CODSUBES */
                _.Display($"CODSUBES {REG_SVP0437B.SVA_CODSUBES}");

                /*" -3645- DISPLAY 'CERTIF   ' WHOST-NRCERTIF */
                _.Display($"CERTIF   {WHOST_NRCERTIF}");

                /*" -3651- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3653- MOVE LK-COBT-MORTE-NATURAL TO APOLICOB-IMP-SEGURADA-VG */
            _.Move(PARAMETROS.LK_COBT_MORTE_NATURAL, APOLICOB_IMP_SEGURADA_VG);

            /*" -3655- MOVE LK-COBT-MORTE-ACIDENTAL TO APOLICOB-IMP-SEGURADA-AP */
            _.Move(PARAMETROS.LK_COBT_MORTE_ACIDENTAL, APOLICOB_IMP_SEGURADA_AP);

            /*" -3657- MOVE LK-COBT-INV-PERMANENTE TO APOLICOB-IMP-SEGURADA-IP */
            _.Move(PARAMETROS.LK_COBT_INV_PERMANENTE, APOLICOB_IMP_SEGURADA_IP);

            /*" -3659- MOVE LK-COBT-INV-POR-ACIDENTE TO APOLICOB-IMP-SEGURADA-IPA */
            _.Move(PARAMETROS.LK_COBT_INV_POR_ACIDENTE, APOLICOB_IMP_SEGURADA_IPA);

            /*" -3661- MOVE LK-COBT-ASS-MEDICA TO APOLICOB-IMP-SEGURADA-AMDS */
            _.Move(PARAMETROS.LK_COBT_ASS_MEDICA, APOLICOB_IMP_SEGURADA_AMDS);

            /*" -3663- MOVE LK-COBT-DIARIA-HOSPITALAR TO APOLICOB-IMP-SEGURADA-DH */
            _.Move(PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, APOLICOB_IMP_SEGURADA_DH);

            /*" -3666- MOVE LK-COBT-DIARIA-INTERNACAO TO APOLICOB-IMP-SEGURADA-DIT. */
            _.Move(PARAMETROS.LK_COBT_DIARIA_INTERNACAO, APOLICOB_IMP_SEGURADA_DIT);

            /*" -3671- MOVE SEGVGAPH-DATA-MOVIMENTO TO SVA-DTMOVTO. */
            _.Move(SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO, REG_SVP0437B.SVA_DTMOVTO);

            /*" -3672- IF LC09-JDE NOT EQUAL WS-JDE-ANT */

            if (AREA_DE_WORK.LC09_JDE != WS_JDE_ANT)
            {

                /*" -3673- IF WS-CONTROLE EQUAL 1 */

                if (WS_CONTROLE == 1)
                {

                    /*" -3674- MOVE ZEROS TO WS-CONTROLE */
                    _.Move(0, WS_CONTROLE);

                    /*" -3675- MOVE LC09-JDE TO WS-JDE-ANT */
                    _.Move(AREA_DE_WORK.LC09_JDE, WS_JDE_ANT);

                    /*" -3676- ELSE */
                }
                else
                {


                    /*" -3677- MOVE LC09-JDE TO WS-JDE-ANT */
                    _.Move(AREA_DE_WORK.LC09_JDE, WS_JDE_ANT);

                    /*" -3678- END-IF */
                }


                /*" -3679- ELSE */
            }
            else
            {


                /*" -3680- IF WS-CONTROLE EQUAL 1 */

                if (WS_CONTROLE == 1)
                {

                    /*" -3681- MOVE ZEROS TO WS-CONTROLE */
                    _.Move(0, WS_CONTROLE);

                    /*" -3682- END-IF */
                }


                /*" -3684- END-IF. */
            }


            /*" -3685- PERFORM R2210-00-IMP-CAPITAIS. */

            R2210_00_IMP_CAPITAIS_SECTION();

            /*" -3687- PERFORM R2213-MOVER-COBERTURAS. */

            R2213_MOVER_COBERTURAS_SECTION();

            /*" -3688- MOVE SVA-DTMOVTO TO WS-DATA-SQL */
            _.Move(REG_SVP0437B.SVA_DTMOVTO, WS_DATA_SQL);

            /*" -3689- MOVE WS-ANO-SQL TO WS-ANO-I */
            _.Move(WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3690- MOVE WS-MES-SQL TO WS-MES-I */
            _.Move(WS_DATA_SQL.WS_MES_SQL, WS_DATA_I.WS_MES_I);

            /*" -3693- MOVE WS-DIA-SQL TO WS-DIA-I */
            _.Move(WS_DATA_SQL.WS_DIA_SQL, WS_DATA_I.WS_DIA_I);

            /*" -3695- MOVE SPACES TO DET6-OPCAOPAG DET3-OPCAOPAG. */
            _.Move("", DETALHE_DS06.DET6_OPCAOPAG, DETALHE_DS03.DET3_OPCAOPAG);

            /*" -3697- PERFORM R2212-00-PEGAR-PRAZO */

            R2212_00_PEGAR_PRAZO_SECTION();

            /*" -3698- IF SVA-OPCAOPAG EQUAL '1' OR '2' */

            if (REG_SVP0437B.SVA_OPCAOPAG.In("1", "2"))
            {

                /*" -3699- MOVE PROPOFID-COD-PLANO TO WS-VALOR4 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                /*" -3700- MOVE WS-VALOR4 TO DET6-PRAZO DET3-PRAZO */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PRAZO, DETALHE_DS03.DET3_PRAZO);

                /*" -3701- MOVE SEGURVGA-PERI-RENOVACAO TO WS-VALOR4 */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_RENOVACAO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                /*" -3702- MOVE WS-VALOR4 TO DET6-PERIODICIDADE DET3-PERIODICIDADE */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PERIODICIDADE, DETALHE_DS03.DET3_PERIODICIDADE);

                /*" -3703- MOVE SVA-AGECTADEB TO DET6-AGECTADEB DET3-AGECTADEB */
                _.Move(REG_SVP0437B.SVA_AGECTADEB, DETALHE_DS06.DET6_OPCAOPAG_R.DET6_AGECTADEB);
                _.Move(REG_SVP0437B.SVA_AGECTADEB, DETALHE_DS03.DET3_OPCAOPAG_R.DET3_AGECTADEB);


                /*" -3704- MOVE SVA-OPRCTADEB TO DET6-OPRCTADEB DET3-OPRCTADEB */
                _.Move(REG_SVP0437B.SVA_OPRCTADEB, DETALHE_DS06.DET6_OPCAOPAG_R.DET6_OPRCTADEB);
                _.Move(REG_SVP0437B.SVA_OPRCTADEB, DETALHE_DS03.DET3_OPCAOPAG_R.DET3_OPRCTADEB);


                /*" -3705- MOVE SVA-NUMCTADEB TO DET6-NUMCTADEB DET3-NUMCTADEB */
                _.Move(REG_SVP0437B.SVA_NUMCTADEB, DETALHE_DS06.DET6_OPCAOPAG_R.DET6_NUMCTADEB);
                _.Move(REG_SVP0437B.SVA_NUMCTADEB, DETALHE_DS03.DET3_OPCAOPAG_R.DET3_NUMCTADEB);


                /*" -3706- MOVE SVA-DIGCTADEB TO DET6-DIGCTADEB DET3-DIGCTADEB */
                _.Move(REG_SVP0437B.SVA_DIGCTADEB, DETALHE_DS06.DET6_OPCAOPAG_R.DET6_DIGCTADEB);
                _.Move(REG_SVP0437B.SVA_DIGCTADEB, DETALHE_DS03.DET3_OPCAOPAG_R.DET3_DIGCTADEB);


                /*" -3708- MOVE '.' TO DET6-PONTO1 DET3-PONTO1 DET6-PONTO2 DET3-PONTO2 */
                _.Move(".", DETALHE_DS06.DET6_OPCAOPAG_R.DET6_PONTO1);
                _.Move(".", DETALHE_DS03.DET3_OPCAOPAG_R.DET3_PONTO1);
                _.Move(".", DETALHE_DS06.DET6_OPCAOPAG_R.DET6_PONTO2);
                _.Move(".", DETALHE_DS03.DET3_OPCAOPAG_R.DET3_PONTO2);


                /*" -3709- MOVE '-' TO DET6-TRACO DET3-TRACO */
                _.Move("-", DETALHE_DS06.DET6_OPCAOPAG_R.DET6_TRACO);
                _.Move("-", DETALHE_DS03.DET3_OPCAOPAG_R.DET3_TRACO);


                /*" -3710- ELSE */
            }
            else
            {


                /*" -3711- IF SVA-OPCAOPAG EQUAL '3' */

                if (REG_SVP0437B.SVA_OPCAOPAG == "3")
                {

                    /*" -3712- MOVE PROPOFID-COD-PLANO TO WS-VALOR4 */
                    _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                    /*" -3713- MOVE WS-VALOR4 TO DET6-PRAZO DET3-PRAZO */
                    _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PRAZO, DETALHE_DS03.DET3_PRAZO);

                    /*" -3714- MOVE SEGURVGA-PERI-RENOVACAO TO WS-VALOR4 */
                    _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_RENOVACAO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                    /*" -3716- MOVE WS-VALOR4 TO DET6-PERIODICIDADE DET3-PERIODICIDADE */
                    _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PERIODICIDADE, DETALHE_DS03.DET3_PERIODICIDADE);

                    /*" -3718- MOVE 'BOLETO DE COBRANCA BANCARIA' TO DET6-OPCAOPAG DET3-OPCAOPAG */
                    _.Move("BOLETO DE COBRANCA BANCARIA", DETALHE_DS06.DET6_OPCAOPAG, DETALHE_DS03.DET3_OPCAOPAG);

                    /*" -3719- ELSE */
                }
                else
                {


                    /*" -3720- IF SVA-OPCAOPAG EQUAL '4' */

                    if (REG_SVP0437B.SVA_OPCAOPAG == "4")
                    {

                        /*" -3721- MOVE PROPOFID-COD-PLANO TO WS-VALOR4 */
                        _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                        /*" -3722- MOVE WS-VALOR4 TO DET6-PRAZO DET3-PRAZO */
                        _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PRAZO, DETALHE_DS03.DET3_PRAZO);

                        /*" -3723- MOVE SEGURVGA-PERI-RENOVACAO TO WS-VALOR4 */
                        _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_RENOVACAO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                        /*" -3725- MOVE WS-VALOR4 TO DET6-PERIODICIDADE DET3-PERIODICIDADE */
                        _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PERIODICIDADE, DETALHE_DS03.DET3_PERIODICIDADE);

                        /*" -3727- MOVE 'DESCONTO EM FOLHA DE PAGTO ' TO DET6-OPCAOPAG DET3-OPCAOPAG */
                        _.Move("DESCONTO EM FOLHA DE PAGTO ", DETALHE_DS06.DET6_OPCAOPAG, DETALHE_DS03.DET3_OPCAOPAG);

                        /*" -3728- ELSE */
                    }
                    else
                    {


                        /*" -3729- IF SVA-OPCAOPAG EQUAL '5' */

                        if (REG_SVP0437B.SVA_OPCAOPAG == "5")
                        {

                            /*" -3730- MOVE PROPOFID-COD-PLANO TO WS-VALOR4 */
                            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                            /*" -3731- MOVE WS-VALOR4 TO DET6-PRAZO DET3-PRAZO */
                            _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PRAZO, DETALHE_DS03.DET3_PRAZO);

                            /*" -3732- MOVE SEGURVGA-PERI-RENOVACAO TO WS-VALOR4 */
                            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_RENOVACAO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                            /*" -3734- MOVE WS-VALOR4 TO DET6-PERIODICIDADE DET3-PERIODICIDADE */
                            _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PERIODICIDADE, DETALHE_DS03.DET3_PERIODICIDADE);

                            /*" -3736- MOVE 'CARTAO DE CREDITO' TO DET6-OPCAOPAG DET3-OPCAOPAG */
                            _.Move("CARTAO DE CREDITO", DETALHE_DS06.DET6_OPCAOPAG, DETALHE_DS03.DET3_OPCAOPAG);

                            /*" -3737- ELSE */
                        }
                        else
                        {


                            /*" -3738- MOVE SPACES TO DET6-PRAZO DET3-PRAZO */
                            _.Move("", DETALHE_DS06.DET6_PRAZO, DETALHE_DS03.DET3_PRAZO);

                            /*" -3740- MOVE SPACES TO DET6-PERIODICIDADE DET3-PERIODICIDADE */
                            _.Move("", DETALHE_DS06.DET6_PERIODICIDADE, DETALHE_DS03.DET3_PERIODICIDADE);

                            /*" -3742- MOVE '  ************************ ' TO DET6-OPCAOPAG DET3-OPCAOPAG */
                            _.Move("  ************************ ", DETALHE_DS06.DET6_OPCAOPAG, DETALHE_DS03.DET3_OPCAOPAG);

                            /*" -3743- END-IF */
                        }


                        /*" -3744- END-IF */
                    }


                    /*" -3745- END-IF */
                }


                /*" -3747- END-IF. */
            }


            /*" -3749- IF WHOST-NRAPOLICE EQUAL 107700000013 */

            if (WHOST_NRAPOLICE == 107700000013)
            {

                /*" -3750- MOVE PROPOFID-COD-PLANO TO WS-VALOR4 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                /*" -3751- MOVE WS-VALOR4 TO DET6-PRAZO DET3-PRAZO */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PRAZO, DETALHE_DS03.DET3_PRAZO);

                /*" -3752- MOVE SEGURVGA-PERI-RENOVACAO TO WS-VALOR4 */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_RENOVACAO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4);

                /*" -3753- MOVE WS-VALOR4 TO DET6-PERIODICIDADE DET3-PERIODICIDADE */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR4, DETALHE_DS06.DET6_PERIODICIDADE, DETALHE_DS03.DET3_PERIODICIDADE);

                /*" -3755- MOVE 'PREMIO PAGO A VISTA' TO DET6-OPCAOPAG DET3-OPCAOPAG */
                _.Move("PREMIO PAGO A VISTA", DETALHE_DS06.DET6_OPCAOPAG, DETALHE_DS03.DET3_OPCAOPAG);

                /*" -3757- END-IF. */
            }


            /*" -3758- MOVE SVA-DTINIVIG TO WS-DATA-INV */
            _.Move(REG_SVP0437B.SVA_DTINIVIG, WS_DATA_INV);

            /*" -3759- MOVE WS-DIA-INV TO WS-DIA-INI */
            _.Move(WS_DATA_INV.WS_DIA_INV, WS_DATA_SEG.WS_DTINIVIG.WS_DIA_INI);

            /*" -3760- MOVE WS-MES-INV TO WS-MES-INI */
            _.Move(WS_DATA_INV.WS_MES_INV, WS_DATA_SEG.WS_DTINIVIG.WS_MES_INI);

            /*" -3761- MOVE WS-ANO-INV TO WS-ANO-INI */
            _.Move(WS_DATA_INV.WS_ANO_INV, WS_DATA_SEG.WS_DTINIVIG.WS_ANO_INI);

            /*" -3764- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
            _.Move("/", WS_DATA_SEG.WS_DTINIVIG.WS_BARRA1, WS_DATA_SEG.WS_DTINIVIG.WS_BARRA2);

            /*" -3765- MOVE ' a ' TO WS-FIL-A */
            _.Move(" a ", WS_DATA_SEG.WS_FIL_A);

            /*" -3766- MOVE SVA-DTTERVIG TO WS-DATA-INV */
            _.Move(REG_SVP0437B.SVA_DTTERVIG, WS_DATA_INV);

            /*" -3767- MOVE WS-DIA-INV TO WS-DIA-TER */
            _.Move(WS_DATA_INV.WS_DIA_INV, WS_DATA_SEG.WS_DTTERVIG.WS_DIA_TER);

            /*" -3768- MOVE WS-MES-INV TO WS-MES-TER */
            _.Move(WS_DATA_INV.WS_MES_INV, WS_DATA_SEG.WS_DTTERVIG.WS_MES_TER);

            /*" -3769- MOVE WS-ANO-INV TO WS-ANO-TER */
            _.Move(WS_DATA_INV.WS_ANO_INV, WS_DATA_SEG.WS_DTTERVIG.WS_ANO_TER);

            /*" -3771- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
            _.Move("/", WS_DATA_SEG.WS_DTTERVIG.WS_BARRA3, WS_DATA_SEG.WS_DTTERVIG.WS_BARRA4);

            /*" -3772- IF SVA-IND-VIGENCIA EQUAL '*' */

            if (REG_SVP0437B.SVA_IND_VIGENCIA == "*")
            {

                /*" -3773- MOVE '(*)' TO WS-STRING2 */
                _.Move("(*)", WS_DATA_SEG.WS_STRING2);

                /*" -3774- ELSE */
            }
            else
            {


                /*" -3775- MOVE SPACES TO WS-STRING2 */
                _.Move("", WS_DATA_SEG.WS_STRING2);

                /*" -3777- END-IF. */
            }


            /*" -3778- MOVE WS-DTINIVIG TO WS-DT-INI-VIG */
            _.Move(WS_DATA_SEG.WS_DTINIVIG, WS_DATA_VIGENCIA.WS_DT_INI_VIG);

            /*" -3779- MOVE WS-DTTERVIG TO WS-DT-FIM-VIG */
            _.Move(WS_DATA_SEG.WS_DTTERVIG, WS_DATA_VIGENCIA.WS_DT_FIM_VIG);

            /*" -3781- MOVE WS-DATA-VIGENCIA TO DET6-PERIODO-VIG DET3-PERIODO-VIG */
            _.Move(WS_DATA_VIGENCIA, DETALHE_DS06.DET6_PERIODO_VIG, DETALHE_DS03.DET3_PERIODO_VIG);

            /*" -3783- IF CONDITEC-CARREGA-CONJUGE NOT EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE != 00)
            {

                /*" -3785- MOVE 'SEG. DEPENDENTE:' TO WS-STRING1 */
                _.Move("SEG. DEPENDENTE:", WS_DATA_SEG.WS_STRING1);

                /*" -3786- MOVE SVA-DTINIVIG TO WS-DATA-INV */
                _.Move(REG_SVP0437B.SVA_DTINIVIG, WS_DATA_INV);

                /*" -3787- MOVE WS-DIA-INV TO WS-DIA-INI */
                _.Move(WS_DATA_INV.WS_DIA_INV, WS_DATA_SEG.WS_DTINIVIG.WS_DIA_INI);

                /*" -3788- MOVE WS-MES-INV TO WS-MES-INI */
                _.Move(WS_DATA_INV.WS_MES_INV, WS_DATA_SEG.WS_DTINIVIG.WS_MES_INI);

                /*" -3789- MOVE WS-ANO-INV TO WS-ANO-INI */
                _.Move(WS_DATA_INV.WS_ANO_INV, WS_DATA_SEG.WS_DTINIVIG.WS_ANO_INI);

                /*" -3792- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
                _.Move("/", WS_DATA_SEG.WS_DTINIVIG.WS_BARRA1, WS_DATA_SEG.WS_DTINIVIG.WS_BARRA2);

                /*" -3793- MOVE ' a ' TO WS-FIL-A */
                _.Move(" a ", WS_DATA_SEG.WS_FIL_A);

                /*" -3794- MOVE SVA-DTTERVIG TO WS-DATA-INV */
                _.Move(REG_SVP0437B.SVA_DTTERVIG, WS_DATA_INV);

                /*" -3795- MOVE WS-DIA-INV TO WS-DIA-TER */
                _.Move(WS_DATA_INV.WS_DIA_INV, WS_DATA_SEG.WS_DTTERVIG.WS_DIA_TER);

                /*" -3796- MOVE WS-MES-INV TO WS-MES-TER */
                _.Move(WS_DATA_INV.WS_MES_INV, WS_DATA_SEG.WS_DTTERVIG.WS_MES_TER);

                /*" -3797- MOVE WS-ANO-INV TO WS-ANO-TER */
                _.Move(WS_DATA_INV.WS_ANO_INV, WS_DATA_SEG.WS_DTTERVIG.WS_ANO_TER);

                /*" -3799- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
                _.Move("/", WS_DATA_SEG.WS_DTTERVIG.WS_BARRA3, WS_DATA_SEG.WS_DTTERVIG.WS_BARRA4);

                /*" -3801- MOVE SPACES TO WS-STRING2. */
                _.Move("", WS_DATA_SEG.WS_STRING2);
            }


            /*" -3806- PERFORM R2400-00-BENEFICIARIOS. */

            R2400_00_BENEFICIARIOS_SECTION();

            /*" -3808- INITIALIZE DET6-BENEFICIARIOS DET3-BENEFICIARIOS. */
            _.Initialize(
                DETALHE_DS06.DET6_BENEFICIARIOS
                , DETALHE_DS03.DET3_BENEFICIARIOS
            );

            /*" -3849- MOVE '|' TO DET6-DELIMIT-01 (1) DET3-DELIMIT-01 (1) DET6-DELIMIT-01 (2) DET3-DELIMIT-01 (2) DET6-DELIMIT-01 (3) DET3-DELIMIT-01 (3) DET6-DELIMIT-01 (4) DET3-DELIMIT-01 (4) DET6-DELIMIT-01 (5) DET3-DELIMIT-01 (5) DET6-DELIMIT-02 (1) DET3-DELIMIT-02 (1) DET6-DELIMIT-02 (2) DET3-DELIMIT-02 (2) DET6-DELIMIT-02 (3) DET3-DELIMIT-02 (3) DET6-DELIMIT-02 (4) DET3-DELIMIT-02 (4) DET6-DELIMIT-02 (5) DET3-DELIMIT-02 (5) DET6-DELIMIT-03 (1) DET3-DELIMIT-03 (1) DET6-DELIMIT-03 (2) DET3-DELIMIT-03 (2) DET6-DELIMIT-03 (3) DET3-DELIMIT-03 (3) DET6-DELIMIT-03 (4) DET3-DELIMIT-03 (4) DET6-DELIMIT-03 (5) DET3-DELIMIT-03 (5) DET3-DELIMIT-4 (1) DET3-DELIMIT-4 (2) DET3-DELIMIT-4 (3) DET3-DELIMIT-4 (4) DET3-DELIMIT-4 (5) DET6-DELIMIT-4 (1) DET6-DELIMIT-4 (2) DET6-DELIMIT-4 (3) DET6-DELIMIT-4 (4) DET6-DELIMIT-4 (5). */
            _.Move("|", DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[1].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[1].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[2].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[2].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[3].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[3].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[4].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[4].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[5].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[5].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[1].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[1].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[2].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[2].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[3].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[3].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[4].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[4].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[5].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[5].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[1].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[1].DET3_DELIMIT_03, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[2].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[2].DET3_DELIMIT_03, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[3].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[3].DET3_DELIMIT_03, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[4].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[4].DET3_DELIMIT_03, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[5].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[5].DET3_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[1].DET3_DELIMIT_4, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[2].DET3_DELIMIT_4, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[3].DET3_DELIMIT_4, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[4].DET3_DELIMIT_4, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[5].DET3_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[1].DET6_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[2].DET6_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[3].DET6_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[4].DET6_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[5].DET6_DELIMIT_4);

            /*" -3851- IF WIND-99 EQUAL ZEROS */

            if (WIND_99 == 00)
            {

                /*" -3853- PERFORM R2650-00-BUSCA-FONTE */

                R2650_00_BUSCA_FONTE_SECTION();

                /*" -3858- ADD 1 TO WS-SEQ TAB1-QTD-OBJ(SVA-CEP-G) AC-QTD-OBJ AC-CONTA1 */
                WS_SEQ.Value = WS_SEQ + 1;
                TABELA_TOTAIS.TAB_TOTAIS[REG_SVP0437B.SVA_CEP_G].TAB1_QTD_OBJ.Value = TABELA_TOTAIS.TAB_TOTAIS[REG_SVP0437B.SVA_CEP_G].TAB1_QTD_OBJ + 1;
                AC_QTD_OBJ.Value = AC_QTD_OBJ + 1;
                AC_CONTA1.Value = AC_CONTA1 + 1;

                /*" -3859- IF WS-CONTR-OBJ EQUAL ZEROS */

                if (WS_CONTR_OBJ == 00)
                {

                    /*" -3860- MOVE 1 TO WS-CONTR-OBJ */
                    _.Move(1, WS_CONTR_OBJ);

                    /*" -3862- MOVE WS-SEQ TO TAB1-OBJI (SVA-CEP-G) */
                    _.Move(WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[REG_SVP0437B.SVA_CEP_G].TAB1_OBJI);

                    /*" -3864- END-IF */
                }


                /*" -3865- IF WS-CONTR-200 EQUAL ZEROS */

                if (WS_CONTR_200 == 00)
                {

                    /*" -3866- MOVE 1 TO WS-CONTR-200 */
                    _.Move(1, WS_CONTR_200);

                    /*" -3867- MOVE WS-SEQ TO WS-SEQ-INICIAL */
                    _.Move(WS_SEQ, WS_SEQ_INICIAL);

                    /*" -3870- END-IF */
                }


                /*" -3871- IF WS-TIPO-FORM = 'pe04' */

                if (WS_TIPO_FORM == "pe04")
                {

                    /*" -3872- WRITE RVP0437B-RECORD FROM DETALHE-DS03 */
                    _.Move(DETALHE_DS03.GetMoveValues(), RVP0437B_RECORD);

                    RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                    /*" -3873- ELSE */
                }
                else
                {


                    /*" -3874- IF WS-TIPO-FORM = 'pe03' OR 'pe01' OR 'vp01' */

                    if (WS_TIPO_FORM.In("pe03", "pe01", "vp01"))
                    {

                        /*" -3875- WRITE RVP0437B-RECORD FROM DETALHE-DS06 */
                        _.Move(DETALHE_DS06.GetMoveValues(), RVP0437B_RECORD);

                        RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                        /*" -3876- ELSE */
                    }
                    else
                    {


                        /*" -3877- DISPLAY 'CERTIFICADO NAO EMITIDO = ' SVA-NRCERTIF */
                        _.Display($"CERTIFICADO NAO EMITIDO = {REG_SVP0437B.SVA_NRCERTIF}");

                        /*" -3879- DISPLAY '#tipo de formulario nao tratado = ' WS-TIPO-FORM */
                        _.Display($"#tipo de formulario nao tratado = {WS_TIPO_FORM}");

                        /*" -3880- ADD 1 TO AC-DESPR-SEGVGAPH */
                        AC_DESPR_SEGVGAPH.Value = AC_DESPR_SEGVGAPH + 1;

                        /*" -3881- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3882- END-IF */
                    }


                    /*" -3884- END-IF */
                }


                /*" -3885- PERFORM R9900-00-GRAVA-OBJETO */

                R9900_00_GRAVA_OBJETO_SECTION();

                /*" -3886- ADD 1 TO AC-IMPRESSOS */
                AC_IMPRESSOS.Value = AC_IMPRESSOS + 1;

                /*" -3888- GO TO R2200-35-ATU-RELATORI. */

                R2200_35_ATU_RELATORI(); //GOTO
                return;
            }


            /*" -3888- PERFORM R2220-00-IMP-BENEFICIARIOS. */

            R2220_00_IMP_BENEFICIARIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2200_35_ATU_RELATORI */

            R2200_35_ATU_RELATORI();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-1 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_1()
        {
            /*" -3320- EXEC SQL SELECT DATA_MOVIMENTO, COD_OPERACAO, COD_MOEDA_PRM INTO :SEGVGAPH-DATA-MOVIMENTO, :SEGVGAPH-COD-OPERACAO, :SEGVGAPH-COD-MOEDA-PRM:VIND-CODMOEDA-I FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO END-EXEC. */

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
            /*" -3893- MOVE SVA-CODRELATVG TO WHOST-CODRELAT. */
            _.Move(REG_SVP0437B.SVA_CODRELATVG, WHOST_CODRELAT);

            /*" -3893- PERFORM R2500-00-UPDATE-RELATORI. */

            R2500_00_UPDATE_RELATORI_SECTION();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-2 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_2()
        {
            /*" -3350- EXEC SQL SELECT VAL_COMPRA INTO :MOEDACOT-VAL-COMPRA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = :SEGVGAPH-COD-MOEDA-PRM AND DATA_INIVIGENCIA <= :SEGVGAPH-DATA-MOVIMENTO AND DATA_TERVIGENCIA >= :SEGVGAPH-DATA-MOVIMENTO END-EXEC. */

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
            /*" -3899- PERFORM R2300-00-LE-SORT. */

            R2300_00_LE_SORT_SECTION();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-3 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_3()
        {
            /*" -3384- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA, RAMO_COBERTURA INTO :APOLICOB-IMP-SEGURADA-VG, :APOLICOB-PRM-TARIFARIO-VG, :APOLICOB-FATOR-MULTIPLICA, :APOLICOB-RAMO-COBERTURA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (77,93) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 11 END-EXEC. */

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
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-4 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_4()
        {
            /*" -3430- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA, RAMO_COBERTURA INTO :APOLICOB-IMP-SEGURADA-AP, :APOLICOB-PRM-TARIFARIO-AP, :APOLICOB-FATOR-MULTIPLICA, :APOLICOB-RAMO-COBERTURA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 01 END-EXEC. */

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
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
            }


        }

        [StopWatch]
        /*" R2202-00-GRAVA-LINHA09-SECTION */
        private void R2202_00_GRAVA_LINHA09_SECTION()
        {
            /*" -3907- MOVE SPACES TO LC09-LINHA09 */
            _.Move("", AREA_DE_WORK.LC09_LINHA09);

            /*" -3911- STRING '(' FUNCTION LOWER-CASE(LC09-JDE) DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LC09-LINHA09 */
            #region STRING
            var spl3 = "(" + AREA_DE_WORK.LC09_JDE.ToString().ToLower().Split(" ").FirstOrDefault() + ".DBM".ToString().ToLower() + ") STARTDBM";
            spl3 += "(";
            spl3 += AREA_DE_WORK.LC09_JDE.ToString().ToLower();
            spl3 += ".DBM".ToString().ToLower();
            spl3 += ") STARTDBM";
            _.Move(spl3, AREA_DE_WORK.LC09_LINHA09);
            #endregion

            /*" -3912- WRITE RVP0437B-RECORD FROM LC09-LINHA09 */
            _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVP0437B_RECORD);

            RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

            /*" -3912- . */

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-5 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_5()
        {
            /*" -3480- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA, RAMO_COBERTURA INTO :APOLICOB-IMP-SEGURADA-IP, :APOLICOB-FATOR-MULTIPLICA, :APOLICOB-RAMO-COBERTURA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 02 END-EXEC. */

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
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2202_00_GRAVA_LINHA09_EXIT*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-6 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_6()
        {
            /*" -3519- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA, RAMO_COBERTURA INTO :APOLICOB-IMP-SEGURADA-AMDS, :APOLICOB-FATOR-MULTIPLICA, :APOLICOB-RAMO-COBERTURA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 03 END-EXEC. */

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
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-USUARIOS-SECTION */
        private void R2205_00_SELECT_USUARIOS_SECTION()
        {
            /*" -3921- MOVE '2205' TO WNR-EXEC-SQL. */
            _.Move("2205", WABEND.WNR_EXEC_SQL);

            /*" -3923- MOVE 'S' TO WTEM-USUARIOS. */
            _.Move("S", WTEM_USUARIOS);

            /*" -3928- PERFORM R2205_00_SELECT_USUARIOS_DB_SELECT_1 */

            R2205_00_SELECT_USUARIOS_DB_SELECT_1();

            /*" -3931- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3932- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3933- MOVE 'N' TO WTEM-USUARIOS */
                    _.Move("N", WTEM_USUARIOS);

                    /*" -3934- ELSE */
                }
                else
                {


                    /*" -3936- DISPLAY '*** VP0437B PROBLEMAS NO ACESSO A USUARIOS   ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VP0437B PROBLEMAS NO ACESSO A USUARIOS   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -3936- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-USUARIOS-DB-SELECT-1 */
        public void R2205_00_SELECT_USUARIOS_DB_SELECT_1()
        {
            /*" -3928- EXEC SQL SELECT COD_USUARIO INTO :USUARIOS-COD-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :WHOST-CODUSU END-EXEC. */

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
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-7 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_7()
        {
            /*" -3558- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA, RAMO_COBERTURA INTO :APOLICOB-IMP-SEGURADA-DH, :APOLICOB-FATOR-MULTIPLICA, :APOLICOB-RAMO-COBERTURA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 04 END-EXEC. */

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
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2205_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-8 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_8()
        {
            /*" -3597- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA, RAMO_COBERTURA INTO :APOLICOB-IMP-SEGURADA-DIT, :APOLICOB-FATOR-MULTIPLICA, :APOLICOB-RAMO-COBERTURA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 05 END-EXEC. */

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
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
            }


        }

        [StopWatch]
        /*" R2210-00-IMP-CAPITAIS-SECTION */
        private void R2210_00_IMP_CAPITAIS_SECTION()
        {
            /*" -3947- MOVE '2210' TO WNR-EXEC-SQL. */
            _.Move("2210", WABEND.WNR_EXEC_SQL);

            /*" -3949- INITIALIZE DET6-COBERTURAS DET3-COBERTURAS */
            _.Initialize(
                DETALHE_DS06.DET6_COBERTURAS
                , DETALHE_DS03.DET3_COBERTURAS
            );

            /*" -3952- MOVE ZEROS TO CONTROLA-IMP W77-IND. */
            _.Move(0, CONTROLA_IMP, W77_IND);

            /*" -3953- PERFORM R1800-00-SELECT-CONDITEC */

            R1800_00_SELECT_CONDITEC_SECTION();

            /*" -3955- MOVE WS-CAR-CONJUGE TO WS-PCTCONJUGE */
            _.Move(WS_CAR_CONJUGE, WS_PCTCONJUGE);

            /*" -3956- MOVE ZEROES TO WS-IMPCONJUGE. */
            _.Move(0, WS_IMPCONJUGE);

            /*" -3957- IF WS-PCTCONJUGE > ZEROES */

            if (WS_PCTCONJUGE > 00)
            {

                /*" -3963- COMPUTE WS-IMPCONJUGE = APOLICOB-IMP-SEGURADA-VG * WS-PCTCONJUGE. */
                WS_IMPCONJUGE.Value = APOLICOB_IMP_SEGURADA_VG * WS_PCTCONJUGE;
            }


            /*" -3965- IF APOLICOB-IMP-SEGURADA-VG > ZEROS */

            if (APOLICOB_IMP_SEGURADA_VG > 00)
            {

                /*" -3967- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -3969- IF W77-IND > 2 */

                if (W77_IND > 2)
                {

                    /*" -3970- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -3972- END-IF */
                }


                /*" -3973- IF SVA-RAMO EQUAL 77 */

                if (REG_SVP0437B.SVA_RAMO == 77)
                {

                    /*" -3975- MOVE 'MORTE POR CAUSAS NATURAIS E ACIDENTAIS : R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                    _.Move("MORTE POR CAUSAS NATURAIS E ACIDENTAIS : R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                    /*" -3976- ELSE */
                }
                else
                {


                    /*" -3978- MOVE 'MORTE POR CAUSAS NATURAIS E ACIDENTAIS : R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                    _.Move("MORTE POR CAUSAS NATURAIS E ACIDENTAIS : R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                    /*" -3980- END-IF */
                }


                /*" -3981- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -3983- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO(W77-IND) WS-DET3-RAMO(W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -3985- MOVE APOLICOB-IMP-SEGURADA-VG TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_VG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3986- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -3987- MOVE APOLICOB-IMP-SEGURADA-VG TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_VG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -3991- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);

                /*" -3993- END-IF. */
            }


            /*" -4000- COMPUTE WS-IMP-SEGURADA-AP = APOLICOB-IMP-SEGURADA-AP - APOLICOB-IMP-SEGURADA-VG. */
            WS_IMP_SEGURADA_AP.Value = APOLICOB_IMP_SEGURADA_AP - APOLICOB_IMP_SEGURADA_VG;

            /*" -4002- IF WS-IMP-SEGURADA-AP > ZEROS */

            if (WS_IMP_SEGURADA_AP > 00)
            {

                /*" -4004- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4006- IF W77-IND > 2 */

                if (W77_IND > 2)
                {

                    /*" -4007- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -4010- END-IF */
                }


                /*" -4011- IF SVA-RAMO EQUAL 81 OR 82 */

                if (REG_SVP0437B.SVA_RAMO.In("81", "82"))
                {

                    /*" -4013- MOVE 'MORTE ACIDENTAL.......................: R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                    _.Move("MORTE ACIDENTAL.......................: R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                    /*" -4014- ELSE */
                }
                else
                {


                    /*" -4016- MOVE 'INDENIZ. ESPEC. POR MORTE ACIDENTAL....: R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                    _.Move("INDENIZ. ESPEC. POR MORTE ACIDENTAL....: R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                    /*" -4017- END-IF */
                }


                /*" -4019- MOVE WS-IMP-SEGURADA-AP TO WS-VALOR */
                _.Move(WS_IMP_SEGURADA_AP, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4024- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);
            }


            /*" -4026- IF APOLICOB-IMP-SEGURADA-IP > ZEROS */

            if (APOLICOB_IMP_SEGURADA_IP > 00)
            {

                /*" -4028- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4030- IF W77-IND > 2 */

                if (W77_IND > 2)
                {

                    /*" -4031- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -4033- END-IF */
                }


                /*" -4035- MOVE 'INVALID. PERMANENTE TOTAL POR ACIDENTE: R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                _.Move("INVALID. PERMANENTE TOTAL POR ACIDENTE: R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                /*" -4036- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -4038- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO(W77-IND) WS-DET3-RAMO(W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -4039- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -4041- MOVE APOLICOB-IMP-SEGURADA-IP TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_IP, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4045- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);

                /*" -4047- END-IF. */
            }


            /*" -4049- IF APOLICOB-IMP-SEGURADA-IPA > ZEROS */

            if (APOLICOB_IMP_SEGURADA_IPA > 00)
            {

                /*" -4051- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4053- IF W77-IND > 2 */

                if (W77_IND > 2)
                {

                    /*" -4054- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -4056- END-IF */
                }


                /*" -4058- MOVE 'INVALIDEZ PERMANENTE POR DOENCA.......: R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                _.Move("INVALIDEZ PERMANENTE POR DOENCA.......: R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                /*" -4059- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -4061- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO(W77-IND) WS-DET3-RAMO(W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -4062- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -4064- MOVE APOLICOB-IMP-SEGURADA-IPA TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_IPA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4071- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);
            }


            /*" -4073- IF SVA-NRAPOLICE = 97010000889 AND SVA-CODSUBES = 3603 OR 4190 */

            if (REG_SVP0437B.SVA_NRAPOLICE == 97010000889 && REG_SVP0437B.SVA_CODSUBES.In("3603", "4190"))
            {

                /*" -4074- IF SVA-IDSEXO = 'F' */

                if (REG_SVP0437B.SVA_IDSEXO == "F")
                {

                    /*" -4078- MOVE ZEROS TO WS-IMPCONJUGE. */
                    _.Move(0, WS_IMPCONJUGE);
                }

            }


            /*" -4079- IF WS-IMPCONJUGE > ZEROS */

            if (WS_IMPCONJUGE > 00)
            {

                /*" -4081- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4083- IF W77-IND > 2 */

                if (W77_IND > 2)
                {

                    /*" -4084- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -4086- END-IF */
                }


                /*" -4088- MOVE 'MORTE DO CONJUGE......................: R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                _.Move("MORTE DO CONJUGE......................: R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                /*" -4089- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -4091- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO (W77-IND) WS-DET3-RAMO (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -4092- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -4094- MOVE WS-IMPCONJUGE TO WS-VALOR */
                _.Move(WS_IMPCONJUGE, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4099- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);
            }


            /*" -4101- IF APOLICOB-IMP-SEGURADA-AMDS > ZEROS */

            if (APOLICOB_IMP_SEGURADA_AMDS > 00)
            {

                /*" -4103- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4105- IF W77-IND > 2 */

                if (W77_IND > 2)
                {

                    /*" -4106- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -4108- END-IF */
                }


                /*" -4110- MOVE 'ASSISTENCIA MEDICA....................: R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                _.Move("ASSISTENCIA MEDICA....................: R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                /*" -4111- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -4113- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO (W77-IND) WS-DET3-RAMO (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -4114- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -4116- MOVE APOLICOB-IMP-SEGURADA-AMDS TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_AMDS, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4121- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);
            }


            /*" -4123- IF APOLICOB-IMP-SEGURADA-DH > ZEROS */

            if (APOLICOB_IMP_SEGURADA_DH > 00)
            {

                /*" -4125- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4127- IF W77-IND > 2 */

                if (W77_IND > 2)
                {

                    /*" -4128- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -4130- END-IF */
                }


                /*" -4132- MOVE 'DIARIA HOSPITALAR.....................: R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                _.Move("DIARIA HOSPITALAR.....................: R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                /*" -4133- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -4135- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO (W77-IND) WS-DET3-RAMO (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -4136- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -4138- MOVE APOLICOB-IMP-SEGURADA-DH TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_DH, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4143- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);
            }


            /*" -4145- IF APOLICOB-IMP-SEGURADA-DIT > ZEROES */

            if (APOLICOB_IMP_SEGURADA_DIT > 00)
            {

                /*" -4146- PERFORM R2750-00-SELECT-HISCOBPR */

                R2750_00_SELECT_HISCOBPR_SECTION();

                /*" -4147- IF HISCOBPR-QTMDIT EQUAL ZEROES */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT == 00)
                {

                    /*" -4148- MOVE 15 TO HISCOBPR-QTMDIT */
                    _.Move(15, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);

                    /*" -4149- END-IF */
                }


                /*" -4153- COMPUTE WS-IMP-SEGURADA-DIT = APOLICOB-IMP-SEGURADA-DIT / HISCOBPR-QTMDIT. */
                WS_IMP_SEGURADA_DIT.Value = APOLICOB_IMP_SEGURADA_DIT / HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT;
            }


            /*" -4155- IF APOLICOB-IMP-SEGURADA-DIT > ZEROS */

            if (APOLICOB_IMP_SEGURADA_DIT > 00)
            {

                /*" -4157- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4159- IF W77-IND > 2 */

                if (W77_IND > 2)
                {

                    /*" -4160- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -4162- END-IF */
                }


                /*" -4164- MOVE 'DIARIA INCAPACIDADE TEMPORARIA........: R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                _.Move("DIARIA INCAPACIDADE TEMPORARIA........: R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                /*" -4165- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -4167- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO (W77-IND) WS-DET3-RAMO (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -4168- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -4170- MOVE WS-IMP-SEGURADA-DIT TO WS-VALOR */
                _.Move(WS_IMP_SEGURADA_DIT, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4175- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);
            }


            /*" -4176- IF WHOST-NRAPOLICE EQUAL 109300000567 */

            if (WHOST_NRAPOLICE == 109300000567)
            {

                /*" -4178- COMPUTE WS-IMP-ADIANT-CDG = APOLICOB-IMP-SEGURADA-VG * 0,5 */
                WS_IMP_ADIANT_CDG.Value = APOLICOB_IMP_SEGURADA_VG * 0.5;

                /*" -4180- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4182- IF W77-IND > 2 */

                if (W77_IND > 2)
                {

                    /*" -4183- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -4185- END-IF */
                }


                /*" -4187- MOVE 'ADIANTAMENTO DOENCA GRAVE ............: R$ ' TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) */
                _.Move("ADIANTAMENTO DOENCA GRAVE ............: R$ ", WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1);

                /*" -4188- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -4190- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO (W77-IND) WS-DET3-RAMO (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -4191- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -4193- MOVE WS-IMP-ADIANT-CDG TO WS-VALOR */
                _.Move(WS_IMP_ADIANT_CDG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4198- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);
            }


            /*" -4201- MOVE '2111' TO WNR-EXEC-SQL. */
            _.Move("2111", WABEND.WNR_EXEC_SQL);

            /*" -4203- MOVE 'N' TO WFIM-COBER. */
            _.Move("N", WFIM_COBER);

            /*" -4211- PERFORM R2210_00_IMP_CAPITAIS_DB_DECLARE_1 */

            R2210_00_IMP_CAPITAIS_DB_DECLARE_1();

            /*" -4213- PERFORM R2210_00_IMP_CAPITAIS_DB_OPEN_1 */

            R2210_00_IMP_CAPITAIS_DB_OPEN_1();

            /*" -4217- PERFORM R2215-00-FETCH-COBER. */

            R2215_00_FETCH_COBER_SECTION();

            /*" -4218- IF WFIM-COBER EQUAL 'S' */

            if (WFIM_COBER == "S")
            {

                /*" -4218- GO TO R2210-99-SAIDA. */
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
            /*" -4213- EXEC SQL OPEN COBER END-EXEC. */

            COBER.Open();

        }

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-DB-DECLARE-1 */
        public void R2400_00_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -4824- EXEC SQL DECLARE V0BENEF CURSOR FOR SELECT NOME_BENEFICIARIO, GRAU_PARENTESCO, PCT_PART_BENEFICIA, VALUE(NUM_CPF, 0) FROM SEGUROS.BENEFICIARIOS WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */
            V0BENEF = new VP0437B_V0BENEF(true);
            string GetQuery_V0BENEF()
            {
                var query = @$"SELECT NOME_BENEFICIARIO
							, 
							GRAU_PARENTESCO
							, 
							PCT_PART_BENEFICIA
							, 
							VALUE(NUM_CPF
							, 0) 
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
        /*" R2210-10-ACESSORIAS */
        private void R2210_10_ACESSORIAS(bool isPerform = false)
        {
            /*" -4224- ADD 1 TO W77-IND */
            W77_IND.Value = W77_IND + 1;

            /*" -4226- IF W77-IND > 2 */

            if (W77_IND > 2)
            {

                /*" -4227- GO TO R2210-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;

                /*" -4230- END-IF */
            }


            /*" -4234- MOVE TAB-COBER-DESCR (VGCOBSUB-COD-COBERTURA) TO WS-DET6-STRING1(W77-IND) WS-DET3-STRING1(W77-IND) WS-COBER-DESC */
            _.Move(TABELA_COBER.TAB_COBER_R.TAB_COBER_DESCR[VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA], WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_STRING1, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_STRING1, AREA_DE_WORK.WS_COBER_DESC);

            /*" -4236- MOVE SPACES TO WS-VALOR-INT-X */
            _.Move("", AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X);

            /*" -4237- IF WS-COBER-DESC(1:8) = 'REMISSAO' */

            if (AREA_DE_WORK.WS_COBER_DESC.Substring(1, 8) == "REMISSAO")
            {

                /*" -4239- MOVE VGCOBSUB-IMP-SEGURADA-IX TO WS-VALOR-INT */
                _.Move(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT);

                /*" -4242- STRING '(' WS-VALOR-INT ' MESES) ' DELIMITED BY '  ' INTO WS-VALOR-INT-X */
                #region STRING
                var spl4 = "(" + AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT.GetMoveValues().Split("  ").FirstOrDefault();
                spl4 += " MESES) ";
                _.Move(spl4, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X);
                #endregion

                /*" -4243- ELSE */
            }
            else
            {


                /*" -4245- MOVE VGCOBSUB-IMP-SEGURADA-IX TO WS-VALOR */
                _.Move(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4247- END-IF */
            }


            /*" -4249- IF VGCOBSUB-COD-COBERTURA EQUAL 01 AND SVA-IMPSEGCDG GREATER ZEROS */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 01 && REG_SVP0437B.SVA_IMPSEGCDG > 00)
            {

                /*" -4250- MOVE SVA-IMPSEGCDG TO WS-VALOR */
                _.Move(REG_SVP0437B.SVA_IMPSEGCDG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4252- END-IF */
            }


            /*" -4254- IF VGCOBSUB-COD-COBERTURA EQUAL 02 OR 16 OR 17 OR 18 OR 19 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.In("02", "16", "17", "18", "19"))
            {

                /*" -4255- MOVE ZEROS TO WS-VALOR */
                _.Move(0, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4259- END-IF */
            }


            /*" -4260- IF VGCOBSUB-COD-COBERTURA EQUAL 11 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 11)
            {

                /*" -4262- COMPUTE WS-VALOR-9 = APOLICOB-IMP-SEGURADA-VG / 2 */
                AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9.Value = APOLICOB_IMP_SEGURADA_VG / 2f;

                /*" -4263- IF WS-VALOR-9 > 50000 */

                if (AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9 > 50000)
                {

                    /*" -4264- MOVE 50000 TO WS-VALOR */
                    _.Move(50000, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                    /*" -4265- ELSE */
                }
                else
                {


                    /*" -4266- MOVE WS-VALOR-9 TO WS-VALOR */
                    _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                    /*" -4267- END-IF */
                }


                /*" -4269- END-IF. */
            }


            /*" -4270- IF WS-VALOR-INT-X EQUAL SPACES */

            if (AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X.IsEmpty())
            {

                /*" -4271- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -4273- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO (W77-IND) WS-DET3-RAMO (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -4274- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -4278- MOVE WS-VALOR TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);

                /*" -4279- ELSE */
            }
            else
            {


                /*" -4280- PERFORM R2211-00-VALORES-COBERTURAS */

                R2211_00_VALORES_COBERTURAS_SECTION();

                /*" -4281- MOVE APOLICOB-RAMO-COBERTURA TO WS-VALOR-RAMO */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO);

                /*" -4283- MOVE WS-VALOR-RAMO TO WS-DET6-RAMO (W77-IND) WS-DET3-RAMO (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_RAMO, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_RAMO, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_RAMO);

                /*" -4287- MOVE WS-VALOR-INT-X TO WS-DET6-VALOR-SEG(W77-IND) WS-DET6-VALOR-SEG-NUM(W77-IND) WS-DET3-VALOR-SEG(W77-IND) WS-DET3-VALOR-SEG-NUM(W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_SEG_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_SEG_NUM);

                /*" -4289- END-IF */
            }


            /*" -4291- PERFORM R2215-00-FETCH-COBER. */

            R2215_00_FETCH_COBER_SECTION();

            /*" -4292- IF WFIM-COBER EQUAL 'S' */

            if (WFIM_COBER == "S")
            {

                /*" -4293- GO TO R2210-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;

                /*" -4294- ELSE */
            }
            else
            {


                /*" -4294- GO TO R2210-10-ACESSORIAS. */
                new Task(() => R2210_10_ACESSORIAS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2211-00-VALORES-COBERTURAS-SECTION */
        private void R2211_00_VALORES_COBERTURAS_SECTION()
        {
            /*" -4303- MOVE '2211' TO WNR-EXEC-SQL. */
            _.Move("2211", WABEND.WNR_EXEC_SQL);

            /*" -4304- MOVE ZEROS TO WS-VAL-IOF */
            _.Move(0, WS_VAL_IOF);

            /*" -4305- COMPUTE WS-VAL-IOF = (APOLICOB-PRM-TARIFARIO-VG * 0,0038) */
            WS_VAL_IOF.Value = (APOLICOB_PRM_TARIFARIO_VG * 0.0038);

            /*" -4307- COMPUTE WS-PREMIO-LIQ = (APOLICOB-PRM-TARIFARIO-VG - WS-VAL-IOF) */
            WS_PREMIO_LIQ.Value = (APOLICOB_PRM_TARIFARIO_VG - WS_VAL_IOF);

            /*" -4308- MOVE WS-VAL-IOF TO WS-VALOR */
            _.Move(WS_VAL_IOF, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

            /*" -4312- MOVE WS-VALOR TO WS-DET6-VALOR-IOF(W77-IND) WS-DET6-VALOR-IOF-NUM(W77-IND) WS-DET3-VALOR-IOF(W77-IND) WS-DET3-VALOR-IOF-NUM(W77-IND) */
            _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_IOF, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_VALOR_IOF_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_IOF, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_VALOR_IOF_NUM);

            /*" -4313- MOVE WS-PREMIO-LIQ TO WS-VALOR */
            _.Move(WS_PREMIO_LIQ, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

            /*" -4317- MOVE WS-VALOR TO WS-DET6-PREMIO-LIQ(W77-IND) WS-DET6-PREMIO-LIQ-NUM(W77-IND) WS-DET3-PREMIO-LIQ(W77-IND) WS-DET3-PREMIO-LIQ-NUM(W77-IND) */
            _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_PREMIO_LIQ, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_PREMIO_LIQ_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_PREMIO_LIQ, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_PREMIO_LIQ_NUM);

            /*" -4318- MOVE APOLICOB-PRM-TARIFARIO-VG TO WS-VALOR */
            _.Move(APOLICOB_PRM_TARIFARIO_VG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

            /*" -4322- MOVE WS-VALOR TO WS-DET6-PREMIO-TOT(W77-IND) WS-DET6-PREMIO-TOT-NUM(W77-IND) WS-DET3-PREMIO-TOT(W77-IND) WS-DET3-PREMIO-TOT-NUM(W77-IND) */
            _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_PREMIO_TOT, WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[W77_IND].WS_DET6_PREMIO_TOT_NUM, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_PREMIO_TOT, WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[W77_IND].WS_DET3_PREMIO_TOT_NUM);

            /*" -4322- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2211_99_SAIDA*/

        [StopWatch]
        /*" R2212-00-PEGAR-PRAZO-SECTION */
        private void R2212_00_PEGAR_PRAZO_SECTION()
        {
            /*" -4330- MOVE '2212' TO WNR-EXEC-SQL. */
            _.Move("2212", WABEND.WNR_EXEC_SQL);

            /*" -4332- MOVE SVA-NRCERTIF TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(REG_SVP0437B.SVA_NRCERTIF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -4341- PERFORM R2212_00_PEGAR_PRAZO_DB_SELECT_1 */

            R2212_00_PEGAR_PRAZO_DB_SELECT_1();

            /*" -4344- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4346- DISPLAY '*** VP0437B PROBLEMAS NO ACESSO A PROPOSTA_FIDELIZ2' */
                _.Display($"*** VP0437B PROBLEMAS NO ACESSO A PROPOSTA_FIDELIZ2");

                /*" -4347- DISPLAY 'NUM_PROPOSTA_SIVPF=' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"NUM_PROPOSTA_SIVPF={PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4348- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4348- END-IF. */
            }


        }

        [StopWatch]
        /*" R2212-00-PEGAR-PRAZO-DB-SELECT-1 */
        public void R2212_00_PEGAR_PRAZO_DB_SELECT_1()
        {
            /*" -4341- EXEC SQL SELECT T1.COD_PLANO, T2.PERI_RENOVACAO INTO :PROPOFID-COD-PLANO, :SEGURVGA-PERI-RENOVACAO FROM SEGUROS.PROPOSTA_FIDELIZ T1, SEGUROS.SEGURADOS_VGAP T2 WHERE T1.NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF AND T2.NUM_CERTIFICADO = T1.NUM_PROPOSTA_SIVPF AND T2.TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1 = new R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1.Execute(r2212_00_PEGAR_PRAZO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);
                _.Move(executed_1.SEGURVGA_PERI_RENOVACAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_RENOVACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2212_99_SAIDA*/

        [StopWatch]
        /*" R2213-MOVER-COBERTURAS-SECTION */
        private void R2213_MOVER_COBERTURAS_SECTION()
        {
            /*" -4356- MOVE '2213' TO WNR-EXEC-SQL */
            _.Move("2213", WABEND.WNR_EXEC_SQL);

            /*" -4357- MOVE WS-DET6-RAMO(1) TO DET6-RAMO1 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_RAMO, DETALHE_DS06.DET6_COBERTURAS.DET6_RAMO1);

            /*" -4358- MOVE WS-DET6-STRING1(1) TO DET6-STRING1 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_STRING1, DETALHE_DS06.DET6_COBERTURAS.DET6_STRING1);

            /*" -4360- MOVE WS-DET6-VALOR-SEG(1) TO DET6-VALOR-SEG1 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_VALOR_SEG, DETALHE_DS06.DET6_COBERTURAS.DET6_VALOR_SEG1);

            /*" -4361- IF WS-DET6-VALOR-SEG-NUM(1) = ZEROS */

            if (WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_VALOR_SEG_NUM == 00)
            {

                /*" -4362- MOVE WS-DET6-VALOR-SEG-NUM(1) TO DET6-VALOR-SEG1 */
                _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_VALOR_SEG_NUM, DETALHE_DS06.DET6_COBERTURAS.DET6_VALOR_SEG1);

                /*" -4364- END-IF */
            }


            /*" -4366- MOVE WS-DET6-VALOR-SEG(1) TO DET6-VLR-PREMIACAO */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_VALOR_SEG, DETALHE_DS06.DET6_VLR_PREMIACAO);

            /*" -4367- IF WS-DET6-VALOR-SEG-NUM(1) > 20000 */

            if (WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_VALOR_SEG_NUM > 20000)
            {

                /*" -4368- MOVE 20000 TO WS-DET6-VLR-PREMIA-NUM */
                _.Move(20000, WS_DET6_VLR_PREMIA_NUM);

                /*" -4369- MOVE WS-DET6-VLR-PREMIA-NUM TO DET6-VLR-PREMIACAO */
                _.Move(WS_DET6_VLR_PREMIA_NUM, DETALHE_DS06.DET6_VLR_PREMIACAO);

                /*" -4371- END-IF */
            }


            /*" -4373- MOVE WS-DET6-PREMIO-LIQ(1) TO DET6-PREMIO-LIQ1 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_PREMIO_LIQ, DETALHE_DS06.DET6_COBERTURAS.DET6_PREMIO_LIQ1);

            /*" -4374- IF WS-DET6-PREMIO-LIQ-NUM(1) = ZEROS */

            if (WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_PREMIO_LIQ_NUM == 00)
            {

                /*" -4375- MOVE WS-DET6-PREMIO-LIQ-NUM(1) TO DET6-PREMIO-LIQ1 */
                _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_PREMIO_LIQ_NUM, DETALHE_DS06.DET6_COBERTURAS.DET6_PREMIO_LIQ1);

                /*" -4377- END-IF */
            }


            /*" -4378- MOVE WS-DET6-VALOR-IOF(1) TO DET6-VALOR-IOF1 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_VALOR_IOF, DETALHE_DS06.DET6_COBERTURAS.DET6_VALOR_IOF1);

            /*" -4380- MOVE WS-DET6-PREMIO-TOT(1) TO DET6-PREMIO-TOT1 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[1].WS_DET6_PREMIO_TOT, DETALHE_DS06.DET6_COBERTURAS.DET6_PREMIO_TOT1);

            /*" -4381- MOVE WS-DET6-RAMO(2) TO DET6-RAMO2 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_RAMO, DETALHE_DS06.DET6_COBERTURAS.DET6_RAMO2);

            /*" -4382- MOVE WS-DET6-STRING1(2) TO DET6-STRING2 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_STRING1, DETALHE_DS06.DET6_COBERTURAS.DET6_STRING2);

            /*" -4384- MOVE WS-DET6-VALOR-SEG(2) TO DET6-VALOR-SEG2 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_VALOR_SEG, DETALHE_DS06.DET6_COBERTURAS.DET6_VALOR_SEG2);

            /*" -4385- IF WS-DET6-VALOR-SEG-NUM(2) = ZEROS */

            if (WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_VALOR_SEG_NUM == 00)
            {

                /*" -4386- MOVE WS-DET6-VALOR-SEG-NUM(2) TO DET6-VALOR-SEG2 */
                _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_VALOR_SEG_NUM, DETALHE_DS06.DET6_COBERTURAS.DET6_VALOR_SEG2);

                /*" -4388- END-IF */
            }


            /*" -4390- MOVE WS-DET6-PREMIO-LIQ(2) TO DET6-PREMIO-LIQ2 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_PREMIO_LIQ, DETALHE_DS06.DET6_COBERTURAS.DET6_PREMIO_LIQ2);

            /*" -4391- IF WS-DET6-PREMIO-LIQ-NUM(2) = ZEROS */

            if (WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_PREMIO_LIQ_NUM == 00)
            {

                /*" -4392- MOVE WS-DET6-PREMIO-LIQ-NUM(2) TO DET6-PREMIO-LIQ2 */
                _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_PREMIO_LIQ_NUM, DETALHE_DS06.DET6_COBERTURAS.DET6_PREMIO_LIQ2);

                /*" -4394- END-IF */
            }


            /*" -4396- MOVE WS-DET6-VALOR-IOF(2) TO DET6-VALOR-IOF2 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_VALOR_IOF, DETALHE_DS06.DET6_COBERTURAS.DET6_VALOR_IOF2);

            /*" -4397- IF WS-DET6-VALOR-IOF-NUM(2) = ZEROS */

            if (WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_VALOR_IOF_NUM == 00)
            {

                /*" -4398- MOVE WS-DET6-VALOR-IOF-NUM(2) TO DET6-VALOR-IOF2 */
                _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_VALOR_IOF_NUM, DETALHE_DS06.DET6_COBERTURAS.DET6_VALOR_IOF2);

                /*" -4400- END-IF */
            }


            /*" -4402- MOVE WS-DET6-PREMIO-TOT(2) TO DET6-PREMIO-TOT2 */
            _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_PREMIO_TOT, DETALHE_DS06.DET6_COBERTURAS.DET6_PREMIO_TOT2);

            /*" -4403- IF WS-DET6-PREMIO-TOT-NUM(2) = ZEROS */

            if (WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_PREMIO_TOT_NUM == 00)
            {

                /*" -4404- MOVE WS-DET6-PREMIO-TOT-NUM(2) TO DET6-PREMIO-TOT2 */
                _.Move(WS_DET6_COBERTURAS.WS_DET6_COBER_OCC[2].WS_DET6_PREMIO_TOT_NUM, DETALHE_DS06.DET6_COBERTURAS.DET6_PREMIO_TOT2);

                /*" -4406- END-IF */
            }


            /*" -4407- MOVE WS-DET3-RAMO(1) TO DET3-RAMO1 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_RAMO, DETALHE_DS03.DET3_COBERTURAS.DET3_RAMO1);

            /*" -4408- MOVE WS-DET3-STRING1(1) TO DET3-STRING1 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_STRING1, DETALHE_DS03.DET3_COBERTURAS.DET3_STRING1);

            /*" -4410- MOVE WS-DET3-VALOR-SEG(1) TO DET3-VALOR-SEG1 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_VALOR_SEG, DETALHE_DS03.DET3_COBERTURAS.DET3_VALOR_SEG1);

            /*" -4411- IF WS-DET3-VALOR-SEG-NUM(1) = ZEROS */

            if (WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_VALOR_SEG_NUM == 00)
            {

                /*" -4412- MOVE WS-DET3-VALOR-SEG-NUM(1) TO DET3-VALOR-SEG1 */
                _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_VALOR_SEG_NUM, DETALHE_DS03.DET3_COBERTURAS.DET3_VALOR_SEG1);

                /*" -4414- END-IF */
            }


            /*" -4416- MOVE WS-DET3-PREMIO-LIQ(1) TO DET3-PREMIO-LIQ1 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_PREMIO_LIQ, DETALHE_DS03.DET3_COBERTURAS.DET3_PREMIO_LIQ1);

            /*" -4417- IF WS-DET3-PREMIO-LIQ-NUM(1) = ZEROS */

            if (WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_PREMIO_LIQ_NUM == 00)
            {

                /*" -4418- MOVE WS-DET3-PREMIO-LIQ-NUM(1) TO DET3-PREMIO-LIQ1 */
                _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_PREMIO_LIQ_NUM, DETALHE_DS03.DET3_COBERTURAS.DET3_PREMIO_LIQ1);

                /*" -4420- END-IF */
            }


            /*" -4422- MOVE WS-DET3-VALOR-IOF(1) TO DET3-VALOR-IOF1 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_VALOR_IOF, DETALHE_DS03.DET3_COBERTURAS.DET3_VALOR_IOF1);

            /*" -4423- IF WS-DET3-VALOR-IOF-NUM(1) = ZEROS */

            if (WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_VALOR_IOF_NUM == 00)
            {

                /*" -4424- MOVE WS-DET3-VALOR-IOF-NUM(1) TO DET3-VALOR-IOF1 */
                _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_VALOR_IOF_NUM, DETALHE_DS03.DET3_COBERTURAS.DET3_VALOR_IOF1);

                /*" -4426- END-IF */
            }


            /*" -4428- MOVE WS-DET3-PREMIO-TOT(1) TO DET3-PREMIO-TOT1 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_PREMIO_TOT, DETALHE_DS03.DET3_COBERTURAS.DET3_PREMIO_TOT1);

            /*" -4429- IF WS-DET3-PREMIO-TOT-NUM(1) = ZEROS */

            if (WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_PREMIO_TOT_NUM == 00)
            {

                /*" -4430- MOVE WS-DET3-PREMIO-TOT-NUM(1) TO DET3-PREMIO-TOT1 */
                _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[1].WS_DET3_PREMIO_TOT_NUM, DETALHE_DS03.DET3_COBERTURAS.DET3_PREMIO_TOT1);

                /*" -4432- END-IF */
            }


            /*" -4433- MOVE WS-DET3-RAMO(2) TO DET3-RAMO2 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_RAMO, DETALHE_DS03.DET3_COBERTURAS.DET3_RAMO2);

            /*" -4434- MOVE WS-DET3-STRING1(2) TO DET3-STRING2 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_STRING1, DETALHE_DS03.DET3_COBERTURAS.DET3_STRING2);

            /*" -4436- MOVE WS-DET3-VALOR-SEG(2) TO DET3-VALOR-SEG2 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_VALOR_SEG, DETALHE_DS03.DET3_COBERTURAS.DET3_VALOR_SEG2);

            /*" -4437- IF WS-DET3-VALOR-SEG-NUM(2) = ZEROS */

            if (WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_VALOR_SEG_NUM == 00)
            {

                /*" -4438- MOVE WS-DET3-VALOR-SEG-NUM(2) TO DET3-VALOR-SEG1 */
                _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_VALOR_SEG_NUM, DETALHE_DS03.DET3_COBERTURAS.DET3_VALOR_SEG1);

                /*" -4440- END-IF */
            }


            /*" -4442- MOVE WS-DET3-PREMIO-LIQ(2) TO DET3-PREMIO-LIQ2 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_PREMIO_LIQ, DETALHE_DS03.DET3_COBERTURAS.DET3_PREMIO_LIQ2);

            /*" -4443- IF WS-DET3-PREMIO-LIQ-NUM(2) = ZEROS */

            if (WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_PREMIO_LIQ_NUM == 00)
            {

                /*" -4444- MOVE WS-DET3-PREMIO-LIQ-NUM(2) TO DET3-PREMIO-LIQ2 */
                _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_PREMIO_LIQ_NUM, DETALHE_DS03.DET3_COBERTURAS.DET3_PREMIO_LIQ2);

                /*" -4446- END-IF */
            }


            /*" -4448- MOVE WS-DET3-VALOR-IOF(2) TO DET3-VALOR-IOF2 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_VALOR_IOF, DETALHE_DS03.DET3_COBERTURAS.DET3_VALOR_IOF2);

            /*" -4449- IF WS-DET3-VALOR-IOF-NUM(2) = ZEROS */

            if (WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_VALOR_IOF_NUM == 00)
            {

                /*" -4450- MOVE WS-DET3-VALOR-IOF-NUM(2) TO DET3-VALOR-IOF2 */
                _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_VALOR_IOF_NUM, DETALHE_DS03.DET3_COBERTURAS.DET3_VALOR_IOF2);

                /*" -4452- END-IF */
            }


            /*" -4454- MOVE WS-DET3-PREMIO-TOT(2) TO DET3-PREMIO-TOT2 */
            _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_PREMIO_TOT, DETALHE_DS03.DET3_COBERTURAS.DET3_PREMIO_TOT2);

            /*" -4455- IF WS-DET3-PREMIO-TOT-NUM(2) = ZEROS */

            if (WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_PREMIO_TOT_NUM == 00)
            {

                /*" -4456- MOVE WS-DET3-PREMIO-TOT-NUM(2) TO DET3-PREMIO-TOT2 */
                _.Move(WS_DET3_COBERTURAS.WS_DET3_COBER_OCC[2].WS_DET3_PREMIO_TOT_NUM, DETALHE_DS03.DET3_COBERTURAS.DET3_PREMIO_TOT2);

                /*" -4458- END-IF */
            }


            /*" -4463- MOVE '|' TO DET6-DELIMIT1-1 DET6-DELIMIT1-2 DET6-DELIMIT1-3 DET6-DELIMIT2-1 DET6-DELIMIT2-2 DET6-DELIMIT2-3 DET6-DELIMIT1-4 DET6-DELIMIT1-5 DET6-DELIMIT1-6 DET6-DELIMIT2-4 DET6-DELIMIT2-5 DET6-DELIMIT2-6 */
            _.Move("|", DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT1_1, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT1_2, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT1_3, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT2_1, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT2_2, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT2_3, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT1_4, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT1_5, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT1_6, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT2_4, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT2_5, DETALHE_DS06.DET6_COBERTURAS.DET6_DELIMIT2_6);

            /*" -4467- MOVE '|' TO DET3-DELIMIT1-1 DET3-DELIMIT1-2 DET3-DELIMIT1-3 DET3-DELIMIT2-1 DET3-DELIMIT2-2 DET3-DELIMIT2-3 DET3-DELIMIT1-4 DET3-DELIMIT1-5 DET3-DELIMIT1-6 DET3-DELIMIT2-4 DET3-DELIMIT2-5 DET3-DELIMIT2-6 */
            _.Move("|", DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT1_1, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT1_2, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT1_3, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT2_1, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT2_2, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT2_3, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT1_4, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT1_5, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT1_6, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT2_4, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT2_5, DETALHE_DS03.DET3_COBERTURAS.DET3_DELIMIT2_6);

            /*" -4467- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2213_99_SAIDA*/

        [StopWatch]
        /*" R2215-00-FETCH-COBER-SECTION */
        private void R2215_00_FETCH_COBER_SECTION()
        {
            /*" -4477- MOVE '2215' TO WNR-EXEC-SQL. */
            _.Move("2215", WABEND.WNR_EXEC_SQL);

            /*" -4481- PERFORM R2215_00_FETCH_COBER_DB_FETCH_1 */

            R2215_00_FETCH_COBER_DB_FETCH_1();

            /*" -4484- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4485- MOVE 'S' TO WFIM-COBER */
                _.Move("S", WFIM_COBER);

                /*" -4485- PERFORM R2215_00_FETCH_COBER_DB_CLOSE_1 */

                R2215_00_FETCH_COBER_DB_CLOSE_1();

                /*" -4486- GO TO R2215-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2215-00-FETCH-COBER-DB-FETCH-1 */
        public void R2215_00_FETCH_COBER_DB_FETCH_1()
        {
            /*" -4481- EXEC SQL FETCH COBER INTO :VGCOBSUB-COD-COBERTURA, :VGCOBSUB-IMP-SEGURADA-IX END-EXEC. */

            if (COBER.Fetch())
            {
                _.Move(COBER.VGCOBSUB_COD_COBERTURA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);
                _.Move(COBER.VGCOBSUB_IMP_SEGURADA_IX, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);
            }

        }

        [StopWatch]
        /*" R2215-00-FETCH-COBER-DB-CLOSE-1 */
        public void R2215_00_FETCH_COBER_DB_CLOSE_1()
        {
            /*" -4485- EXEC SQL CLOSE COBER END-EXEC */

            COBER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-IMP-BENEFICIARIOS-SECTION */
        private void R2220_00_IMP_BENEFICIARIOS_SECTION()
        {
            /*" -4499- MOVE '2220' TO WNR-EXEC-SQL. */
            _.Move("2220", WABEND.WNR_EXEC_SQL);

            /*" -4500- MOVE ZEROS TO WIND-88 */
            _.Move(0, WIND_88);

            /*" -4501- MOVE 'N' TO WFIM-TABELA WPRIM-LINHA. */
            _.Move("N", WFIM_TABELA, WPRIM_LINHA);

            /*" -0- FLUXCONTROL_PERFORM R2220_10_INI_CERTIFICADO */

            R2220_10_INI_CERTIFICADO();

        }

        [StopWatch]
        /*" R2220-10-INI-CERTIFICADO */
        private void R2220_10_INI_CERTIFICADO(bool isPerform = false)
        {
            /*" -4507- INITIALIZE DET6-BENEFICIARIOS. */
            _.Initialize(
                DETALHE_DS06.DET6_BENEFICIARIOS
            );

            /*" -4509- MOVE ZEROS TO WIND-77. */
            _.Move(0, WIND_77);

            /*" -4550- MOVE '|' TO DET6-DELIMIT-01 (1) DET3-DELIMIT-01 (1) DET6-DELIMIT-01 (2) DET3-DELIMIT-01 (2) DET6-DELIMIT-01 (3) DET3-DELIMIT-01 (3) DET6-DELIMIT-01 (4) DET3-DELIMIT-01 (4) DET6-DELIMIT-01 (5) DET3-DELIMIT-01 (5) DET6-DELIMIT-02 (1) DET3-DELIMIT-02 (1) DET6-DELIMIT-02 (2) DET3-DELIMIT-02 (2) DET6-DELIMIT-02 (3) DET3-DELIMIT-02 (3) DET6-DELIMIT-02 (4) DET3-DELIMIT-02 (4) DET6-DELIMIT-02 (5) DET3-DELIMIT-02 (5) DET6-DELIMIT-03 (1) DET3-DELIMIT-03 (1) DET6-DELIMIT-03 (2) DET3-DELIMIT-03 (2) DET6-DELIMIT-03 (3) DET3-DELIMIT-03 (3) DET6-DELIMIT-03 (4) DET3-DELIMIT-03 (4) DET6-DELIMIT-03 (5) DET3-DELIMIT-03 (5) DET3-DELIMIT-4 (1) DET3-DELIMIT-4 (2) DET3-DELIMIT-4 (3) DET3-DELIMIT-4 (4) DET3-DELIMIT-4 (5) DET6-DELIMIT-4 (1) DET6-DELIMIT-4 (2) DET6-DELIMIT-4 (3) DET6-DELIMIT-4 (4) DET6-DELIMIT-4 (5). */
            _.Move("|", DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[1].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[1].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[2].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[2].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[3].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[3].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[4].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[4].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[5].DET6_DELIMIT_01, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[5].DET3_DELIMIT_01, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[1].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[1].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[2].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[2].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[3].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[3].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[4].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[4].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[5].DET6_DELIMIT_02, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[5].DET3_DELIMIT_02, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[1].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[1].DET3_DELIMIT_03, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[2].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[2].DET3_DELIMIT_03, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[3].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[3].DET3_DELIMIT_03, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[4].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[4].DET3_DELIMIT_03, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[5].DET6_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[5].DET3_DELIMIT_03, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[1].DET3_DELIMIT_4, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[2].DET3_DELIMIT_4, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[3].DET3_DELIMIT_4, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[4].DET3_DELIMIT_4, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[5].DET3_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[1].DET6_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[2].DET6_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[3].DET6_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[4].DET6_DELIMIT_4, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[5].DET6_DELIMIT_4);

            /*" -4557- ADD 1 TO WS-SEQ TAB1-QTD-OBJ(SVA-CEP-G) AC-QTD-OBJ AC-CONTA1. */
            WS_SEQ.Value = WS_SEQ + 1;
            TABELA_TOTAIS.TAB_TOTAIS[REG_SVP0437B.SVA_CEP_G].TAB1_QTD_OBJ.Value = TABELA_TOTAIS.TAB_TOTAIS[REG_SVP0437B.SVA_CEP_G].TAB1_QTD_OBJ + 1;
            AC_QTD_OBJ.Value = AC_QTD_OBJ + 1;
            AC_CONTA1.Value = AC_CONTA1 + 1;

            /*" -4558- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (WS_CONTR_OBJ == 00)
            {

                /*" -4559- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, WS_CONTR_OBJ);

                /*" -4562- MOVE WS-SEQ TO TAB1-OBJI (SVA-CEP-G). */
                _.Move(WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[REG_SVP0437B.SVA_CEP_G].TAB1_OBJI);
            }


            /*" -4563- IF WS-CONTR-200 EQUAL ZEROS */

            if (WS_CONTR_200 == 00)
            {

                /*" -4564- MOVE 1 TO WS-CONTR-200 */
                _.Move(1, WS_CONTR_200);

                /*" -4566- MOVE WS-SEQ TO WS-SEQ-INICIAL. */
                _.Move(WS_SEQ, WS_SEQ_INICIAL);
            }


            /*" -4567- IF WIND-88 > 4 */

            if (WIND_88 > 4)
            {

                /*" -4568- PERFORM R2210-00-IMP-CAPITAIS */

                R2210_00_IMP_CAPITAIS_SECTION();

                /*" -4568- PERFORM R2213-MOVER-COBERTURAS. */

                R2213_MOVER_COBERTURAS_SECTION();
            }


        }

        [StopWatch]
        /*" R2220-20-BENEFICIARIOS */
        private void R2220_20_BENEFICIARIOS(bool isPerform = false)
        {
            /*" -4580- ADD 1 TO WIND-77 WIND-88. */
            WIND_77.Value = WIND_77 + 1;
            WIND_88.Value = WIND_88 + 1;

            /*" -4581- IF WIND-88 > WIND-99 */

            if (WIND_88 > WIND_99)
            {

                /*" -4582- MOVE 'S' TO WFIM-TABELA */
                _.Move("S", WFIM_TABELA);

                /*" -4584- GO TO R2220-30-ENDERECO. */

                R2220_30_ENDERECO(); //GOTO
                return;
            }


            /*" -4586- IF WIND-88 = 1 OR WPRIM-LINHA = 'S' */

            if (WIND_88 == 1 || WPRIM_LINHA == "S")
            {

                /*" -4587- MOVE 'N' TO WPRIM-LINHA */
                _.Move("N", WPRIM_LINHA);

                /*" -4588- ELSE */
            }
            else
            {


                /*" -4590- DIVIDE WIND-88 BY 5 GIVING WS-QUOCIENTE REMAINDER WS-RESTO */
                _.Divide(WIND_88, 5, WS_QUOCIENTE, WS_RESTO);

                /*" -4592- IF WS-RESTO = 1 AND WPRIM-LINHA = 'N' */

                if (WS_RESTO == 1 && WPRIM_LINHA == "N")
                {

                    /*" -4593- MOVE 'N' TO WFIM-TABELA */
                    _.Move("N", WFIM_TABELA);

                    /*" -4594- MOVE 'S' TO WPRIM-LINHA */
                    _.Move("S", WPRIM_LINHA);

                    /*" -4596- GO TO R2220-30-ENDERECO. */

                    R2220_30_ENDERECO(); //GOTO
                    return;
                }

            }


            /*" -4599- MOVE TB99-NOME-BENEF (WIND-88) TO DET6-NOME-BENEF (WIND-77) DET3-NOME-BENEF (WIND-77). */
            _.Move(TB99.TB99_CONT[WIND_88].TB99_NOME_BENEF, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[WIND_77].DET6_NOME_BENEF, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[WIND_77].DET3_NOME_BENEF);

            /*" -4602- MOVE TB99-NUM-CPF (WIND-88) TO DET3-NUM-CPF (WIND-77) DET6-NUM-CPF (WIND-77) */
            _.Move(TB99.TB99_CONT[WIND_88].TB99_NUM_CPF, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[WIND_77].DET3_NUM_CPF, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[WIND_77].DET6_NUM_CPF);

            /*" -4605- MOVE TB99-PARENTESCO (WIND-88) TO DET6-PARENTESCO (WIND-77) DET3-PARENTESCO (WIND-77). */
            _.Move(TB99.TB99_CONT[WIND_88].TB99_PARENTESCO, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[WIND_77].DET6_PARENTESCO, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[WIND_77].DET3_PARENTESCO);

            /*" -4609- MOVE TB99-PARTICIP (WIND-88) TO DET6-PARTICIP (WIND-77) DET3-PARTICIP (WIND-77). */
            _.Move(TB99.TB99_CONT[WIND_88].TB99_PARTICIP, DETALHE_DS06.DET6_BENEFICIARIOS.DET6_BENEF_OCC[WIND_77].DET6_PARTICIP, DETALHE_DS03.DET3_BENEFICIARIOS.DET3_BENEF_OCC[WIND_77].DET3_PARTICIP);

            /*" -4609- GO TO R2220-20-BENEFICIARIOS. */
            new Task(() => R2220_20_BENEFICIARIOS()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2220-30-ENDERECO */
        private void R2220_30_ENDERECO(bool isPerform = false)
        {
            /*" -4615- PERFORM R2650-00-BUSCA-FONTE. */

            R2650_00_BUSCA_FONTE_SECTION();

            /*" -4616- IF LC09-JDE = 'DS24' OR 'ds24' */

            if (AREA_DE_WORK.LC09_JDE.In("DS24", "ds24"))
            {

                /*" -4617- MOVE 'pe03' TO WS-TIPO-FORM */
                _.Move("pe03", WS_TIPO_FORM);

                /*" -4620- END-IF */
            }


            /*" -4621- IF WS-TIPO-FORM = 'pe04' */

            if (WS_TIPO_FORM == "pe04")
            {

                /*" -4622- WRITE RVP0437B-RECORD FROM DETALHE-DS03 */
                _.Move(DETALHE_DS03.GetMoveValues(), RVP0437B_RECORD);

                RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                /*" -4623- ELSE */
            }
            else
            {


                /*" -4624- IF WS-TIPO-FORM = 'pe03' OR 'pe01' OR 'vp01' */

                if (WS_TIPO_FORM.In("pe03", "pe01", "vp01"))
                {

                    /*" -4625- WRITE RVP0437B-RECORD FROM DETALHE-DS06 */
                    _.Move(DETALHE_DS06.GetMoveValues(), RVP0437B_RECORD);

                    RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                    /*" -4626- ELSE */
                }
                else
                {


                    /*" -4627- DISPLAY 'CERTIFICADO NAO EMITIDO = ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO = {REG_SVP0437B.SVA_NRCERTIF}");

                    /*" -4629- DISPLAY '##tipo de formulario nao tratado = ' WS-TIPO-FORM */
                    _.Display($"##tipo de formulario nao tratado = {WS_TIPO_FORM}");

                    /*" -4630- ADD 1 TO AC-DESPR-SEGVGAPH */
                    AC_DESPR_SEGVGAPH.Value = AC_DESPR_SEGVGAPH + 1;

                    /*" -4631- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4632- END-IF */
                }


                /*" -4633- END-IF */
            }


            /*" -4635- PERFORM R9900-00-GRAVA-OBJETO */

            R9900_00_GRAVA_OBJETO_SECTION();

            /*" -4637- ADD 1 TO AC-IMPRESSOS. */
            AC_IMPRESSOS.Value = AC_IMPRESSOS + 1;

            /*" -4638- IF WFIM-TABELA NOT EQUAL 'S' */

            if (WFIM_TABELA != "S")
            {

                /*" -4639- SUBTRACT 1 FROM WIND-88 */
                WIND_88.Value = WIND_88 - 1;

                /*" -4639- GO TO R2220-10-INI-CERTIFICADO. */

                R2220_10_INI_CERTIFICADO(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-LE-SORT-SECTION */
        private void R2300_00_LE_SORT_SECTION()
        {
            /*" -4650- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -4652- RETURN SVP0437B AT END */
            try
            {
                SVP0437B.Return(REG_SVP0437B, () =>
                {

                    /*" -4653- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", WFIM_SORT);

                    /*" -4655- GO TO R2300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -4658- ADD 1 TO AC-LIDOS AC-CONTA. */
            AC_LIDOS.Value = AC_LIDOS + 1;
            AC_CONTA.Value = AC_CONTA + 1;

            /*" -4660- MOVE SVA-COD-EMPRESA TO PRODUTO-COD-EMPRESA. */
            _.Move(REG_SVP0437B.SVA_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);

            /*" -4661- IF AC-CONTA GREATER 99 */

            if (AC_CONTA > 99)
            {

                /*" -4662- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -4663- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), WHORA_CURR);

                /*" -4663- DISPLAY '*** LIDOS SORT       ' AC-LIDOS ' ' WHORA-CURR. */

                $"*** LIDOS SORT       {AC_LIDOS} {WHORA_CURR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-IDENTIFICA-MSG-SECTION */
        private void R2310_00_IDENTIFICA_MSG_SECTION()
        {
            /*" -4674- MOVE '2310' TO WNR-EXEC-SQL. */
            _.Move("2310", WABEND.WNR_EXEC_SQL);

            /*" -4675- IF INF > SUP */

            if (INF > SUP)
            {

                /*" -4676- MOVE 'N' TO WTEM-MULTIMSG */
                _.Move("N", WTEM_MULTIMSG);

                /*" -4677- ELSE */
            }
            else
            {


                /*" -4678- COMPUTE WS-IND = (SUP + INF) / 2 */
                WS_IND.Value = (SUP + INF) / 2;

                /*" -4679- IF WS-CHAVE < TABJ-CHAVE(WS-IND) */

                if (WS_CHAVE < TABELA_MSG.TAB_MSG[WS_IND].TABJ_CHAVE)
                {

                    /*" -4680- COMPUTE SUP = WS-IND - 1 */
                    SUP.Value = WS_IND - 1;

                    /*" -4681- GO TO R2310-00-IDENTIFICA-MSG */
                    new Task(() => R2310_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -4682- ELSE */
                }
                else
                {


                    /*" -4683- IF WS-CHAVE > TABJ-CHAVE(WS-IND) */

                    if (WS_CHAVE > TABELA_MSG.TAB_MSG[WS_IND].TABJ_CHAVE)
                    {

                        /*" -4684- COMPUTE INF = WS-IND + 1 */
                        INF.Value = WS_IND + 1;

                        /*" -4685- GO TO R2310-00-IDENTIFICA-MSG */
                        new Task(() => R2310_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -4686- ELSE */
                    }
                    else
                    {


                        /*" -4690- MOVE 'S' TO WTEM-MULTIMSG. */
                        _.Move("S", WTEM_MULTIMSG);
                    }

                }

            }


            /*" -4692- IF WTEM-MULTIMSG = 'S' */

            if (WTEM_MULTIMSG == "S")
            {

                /*" -4695- IF SVA-NRAPOLICE EQUAL 0107700000013 AND TABJ-JDE (WS-IND) = 'PE03' AND SVA-OPRCTADEB = 023 */

                if (REG_SVP0437B.SVA_NRAPOLICE == 0107700000013 && TABELA_MSG.TAB_MSG[WS_IND].TABJ_JDE == "PE03" && REG_SVP0437B.SVA_OPRCTADEB == 023)
                {

                    /*" -4696- MOVE 'PE01' TO TABJ-JDE (WS-IND) */
                    _.Move("PE01", TABELA_MSG.TAB_MSG[WS_IND].TABJ_JDE);

                    /*" -4704- END-IF */
                }


                /*" -4705- MOVE TABJ-JDE (WS-IND) TO LC09-JDE */
                _.Move(TABELA_MSG.TAB_MSG[WS_IND].TABJ_JDE, AREA_DE_WORK.LC09_JDE);

                /*" -4706- IF LC09-JDE = 'PE03' OR 'PE01' OR 'VP01' OR 'DS06' */

                if (AREA_DE_WORK.LC09_JDE.In("PE03", "PE01", "VP01", "DS06"))
                {

                    /*" -4707- MOVE 'DS06' TO LC09-JDE */
                    _.Move("DS06", AREA_DE_WORK.LC09_JDE);

                    /*" -4708- END-IF */
                }


                /*" -4709- ELSE */
            }
            else
            {


                /*" -4710- PERFORM R2315-00-SELECT-V0MULTIMENS */

                R2315_00_SELECT_V0MULTIMENS_SECTION();

                /*" -4713- IF SVA-NRAPOLICE EQUAL 0107700000013 AND COBMENVG-JDE = 'PE03' AND SVA-OPRCTADEB = 023 */

                if (REG_SVP0437B.SVA_NRAPOLICE == 0107700000013 && COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE == "PE03" && REG_SVP0437B.SVA_OPRCTADEB == 023)
                {

                    /*" -4714- MOVE 'PE01' TO COBMENVG-JDE */
                    _.Move("PE01", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);

                    /*" -4718- END-IF */
                }


                /*" -4719- MOVE COBMENVG-JDE TO LC09-JDE */
                _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.LC09_JDE);

                /*" -4720- IF LC09-JDE = 'PE03' OR 'PE01' OR 'VP01' OR 'DS06' */

                if (AREA_DE_WORK.LC09_JDE.In("PE03", "PE01", "VP01", "DS06"))
                {

                    /*" -4721- MOVE 'DS06' TO LC09-JDE */
                    _.Move("DS06", AREA_DE_WORK.LC09_JDE);

                    /*" -4722- END-IF. */
                }

            }


            /*" -4723- IF LC09-JDE = 'PE04' OR 'pe04' OR 'ds03' */

            if (AREA_DE_WORK.LC09_JDE.In("PE04", "pe04", "ds03"))
            {

                /*" -4724- MOVE LC09-JDE TO WS-TIPO-FORM */
                _.Move(AREA_DE_WORK.LC09_JDE, WS_TIPO_FORM);

                /*" -4725- MOVE 'ds03' TO LC09-JDE */
                _.Move("ds03", AREA_DE_WORK.LC09_JDE);

                /*" -4726- END-IF. */
            }


            /*" -4728- IF LC09-JDE = 'PE03' OR 'PE01' OR 'VP01' OR 'DS06' OR 'pe03' OR 'pe01' OR 'vp01' OR 'ds06' */

            if (AREA_DE_WORK.LC09_JDE.In("PE03", "PE01", "VP01", "DS06", "pe03", "pe01", "vp01", "ds06"))
            {

                /*" -4729- MOVE LC09-JDE TO WS-TIPO-FORM */
                _.Move(AREA_DE_WORK.LC09_JDE, WS_TIPO_FORM);

                /*" -4730- MOVE 'ds06' TO LC09-JDE */
                _.Move("ds06", AREA_DE_WORK.LC09_JDE);

                /*" -4730- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-SECTION */
        private void R2315_00_SELECT_V0MULTIMENS_SECTION()
        {
            /*" -4740- MOVE '2315' TO WNR-EXEC-SQL */
            _.Move("2315", WABEND.WNR_EXEC_SQL);

            /*" -4751- PERFORM R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1 */

            R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1();

            /*" -4754- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4755- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4756- MOVE 'VA44' TO COBMENVG-JDE */
                    _.Move("VA44", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);

                    /*" -4757- IF PRODUTO-COD-EMPRESA = 11 */

                    if (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA == 11)
                    {

                        /*" -4758- MOVE 'VIDA05' TO COBMENVG-JDE */
                        _.Move("VIDA05", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);

                        /*" -4759- END-IF */
                    }


                    /*" -4760- MOVE 'VA' TO COBMENVG-JDL */
                    _.Move("VA", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);

                    /*" -4761- ELSE */
                }
                else
                {


                    /*" -4762- DISPLAY 'R2315 - NAO ENCONTRADO NA COBRANCA_MENS_VGAP ' */
                    _.Display($"R2315 - NAO ENCONTRADO NA COBRANCA_MENS_VGAP ");

                    /*" -4763- DISPLAY 'APOLICE     => ' COBMENVG-NUM-APOLICE */
                    _.Display($"APOLICE     => {COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE}");

                    /*" -4764- DISPLAY 'SUBGRUPO    => ' COBMENVG-CODSUBES */
                    _.Display($"SUBGRUPO    => {COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES}");

                    /*" -4765- DISPLAY 'OPERACAO    => ' WHOST-CODOPER */
                    _.Display($"OPERACAO    => {WHOST_CODOPER}");

                    /*" -4765- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-DB-SELECT-1 */
        public void R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1()
        {
            /*" -4751- EXEC SQL SELECT JDE, JDL INTO :COBMENVG-JDE, :COBMENVG-JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :COBMENVG-NUM-APOLICE AND CODSUBES = :COBMENVG-CODSUBES AND COD_OPERACAO = 2 END-EXEC. */

            var r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 = new R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1()
            {
                COBMENVG_NUM_APOLICE = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE.ToString(),
                COBMENVG_CODSUBES = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES.ToString(),
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
        /*" R2320-00-SELECT-CLIENTES-SECTION */
        private void R2320_00_SELECT_CLIENTES_SECTION()
        {
            /*" -4776- MOVE '2320' TO WNR-EXEC-SQL. */
            _.Move("2320", WABEND.WNR_EXEC_SQL);

            /*" -4778- MOVE SVA-CODCLIEN TO WHOST-CODCLIEN. */
            _.Move(REG_SVP0437B.SVA_CODCLIEN, WHOST_CODCLIEN);

            /*" -4785- PERFORM R2320_00_SELECT_CLIENTES_DB_SELECT_1 */

            R2320_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -4788- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4789- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4791- MOVE '*** ESTIPULANTE NAO CADASTRADO ***' TO DET6-ESTIPULANTE DET3-ESTIPULANTE */
                    _.Move("*** ESTIPULANTE NAO CADASTRADO ***", DETALHE_DS06.DET6_ESTIPULANTE, DETALHE_DS03.DET3_ESTIPULANTE);

                    /*" -4792- GO TO R2320-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/ //GOTO
                    return;

                    /*" -4793- ELSE */
                }
                else
                {


                    /*" -4795- DISPLAY '*** R2320 - PROBLEMAS ACESSO CLIENTES  ' WHOST-CODCLIEN */
                    _.Display($"*** R2320 - PROBLEMAS ACESSO CLIENTES  {WHOST_CODCLIEN}");

                    /*" -4799- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4800- MOVE CLIENTES-NOME-RAZAO TO DET6-ESTIPULANTE DET3-ESTIPULANTE. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETALHE_DS06.DET6_ESTIPULANTE, DETALHE_DS03.DET3_ESTIPULANTE);

        }

        [StopWatch]
        /*" R2320-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R2320_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -4785- EXEC SQL SELECT NOME_RAZAO, IDE_SEXO INTO :CLIENTES-NOME-RAZAO, :CLIENTES-IDE-SEXO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :WHOST-CODCLIEN END-EXEC. */

            var r2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                WHOST_CODCLIEN = WHOST_CODCLIEN.ToString(),
            };

            var executed_1 = R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-SECTION */
        private void R2400_00_BENEFICIARIOS_SECTION()
        {
            /*" -4811- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -4812- MOVE 'N' TO WFIM-BENEFICIA. */
            _.Move("N", WFIM_BENEFICIA);

            /*" -4814- MOVE ZEROS TO WIND-99. */
            _.Move(0, WIND_99);

            /*" -4824- PERFORM R2400_00_BENEFICIARIOS_DB_DECLARE_1 */

            R2400_00_BENEFICIARIOS_DB_DECLARE_1();

            /*" -4826- PERFORM R2400_00_BENEFICIARIOS_DB_OPEN_1 */

            R2400_00_BENEFICIARIOS_DB_OPEN_1();

            /*" -4829- PERFORM R2410-00-FETCH-V0BENEF UNTIL WFIM-BENEFICIA EQUAL 'S' . */

            while (!(WFIM_BENEFICIA == "S"))
            {

                R2410_00_FETCH_V0BENEF_SECTION();
            }

        }

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-DB-OPEN-1 */
        public void R2400_00_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -4826- EXEC SQL OPEN V0BENEF END-EXEC. */

            V0BENEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-SECTION */
        private void R2410_00_FETCH_V0BENEF_SECTION()
        {
            /*" -4840- MOVE '2410' TO WNR-EXEC-SQL. */
            _.Move("2410", WABEND.WNR_EXEC_SQL);

            /*" -4846- PERFORM R2410_00_FETCH_V0BENEF_DB_FETCH_1 */

            R2410_00_FETCH_V0BENEF_DB_FETCH_1();

            /*" -4849- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4850- MOVE 'S' TO WFIM-BENEFICIA */
                _.Move("S", WFIM_BENEFICIA);

                /*" -4850- PERFORM R2410_00_FETCH_V0BENEF_DB_CLOSE_1 */

                R2410_00_FETCH_V0BENEF_DB_CLOSE_1();

                /*" -4853- GO TO R2410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4855- ADD 1 TO WIND-99. */
            WIND_99.Value = WIND_99 + 1;

            /*" -4857- MOVE BENEFICI-NOME-BENEFICIARIO TO TB99-NOME-BENEF (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO, TB99.TB99_CONT[WIND_99].TB99_NOME_BENEF);

            /*" -4859- MOVE BENEFICI-NUM-CPF TO TB99-NUM-CPF (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CPF, TB99.TB99_CONT[WIND_99].TB99_NUM_CPF);

            /*" -4861- MOVE BENEFICI-GRAU-PARENTESCO TO TB99-PARENTESCO (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO, TB99.TB99_CONT[WIND_99].TB99_PARENTESCO);

            /*" -4862- MOVE BENEFICI-PCT-PART-BENEFICIA TO TB99-PARTICIP (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA, TB99.TB99_CONT[WIND_99].TB99_PARTICIP);

        }

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-DB-FETCH-1 */
        public void R2410_00_FETCH_V0BENEF_DB_FETCH_1()
        {
            /*" -4846- EXEC SQL FETCH V0BENEF INTO :BENEFICI-NOME-BENEFICIARIO, :BENEFICI-GRAU-PARENTESCO, :BENEFICI-PCT-PART-BENEFICIA, :BENEFICI-NUM-CPF END-EXEC. */

            if (V0BENEF.Fetch())
            {
                _.Move(V0BENEF.BENEFICI_NOME_BENEFICIARIO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO);
                _.Move(V0BENEF.BENEFICI_GRAU_PARENTESCO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO);
                _.Move(V0BENEF.BENEFICI_PCT_PART_BENEFICIA, BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA);
                _.Move(V0BENEF.BENEFICI_NUM_CPF, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CPF);
            }

        }

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-DB-CLOSE-1 */
        public void R2410_00_FETCH_V0BENEF_DB_CLOSE_1()
        {
            /*" -4850- EXEC SQL CLOSE V0BENEF END-EXEC */

            V0BENEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-SECTION */
        private void R2500_00_UPDATE_RELATORI_SECTION()
        {
            /*" -4873- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -4882- PERFORM R2500_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R2500_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -4885- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4885- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R2500_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -4882- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_RELATORIO = :WHOST-CODRELAT AND SIT_REGISTRO = '0' AND COD_OPERACAO = 2 AND NUM_PARCELA = 2 AND NUM_CERTIFICADO = :WHOST-NRCERTIF END-EXEC. */

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
            /*" -4895- MOVE '2650' TO WNR-EXEC-SQL */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -4897- MOVE TAB-CEP (SVA-FONTE) TO DEST-NUM-CEP */
            _.Move(TAB_FILIAL.FILLER_201[REG_SVP0437B.SVA_FONTE].TAB_CEP, DEST_NUM_CEP);

            /*" -4897- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-SELECT-PRODUVG-SECTION */
        private void R2700_00_SELECT_PRODUVG_SECTION()
        {
            /*" -4908- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WABEND.WNR_EXEC_SQL);

            /*" -4916- PERFORM R2700_00_SELECT_PRODUVG_DB_SELECT_1 */

            R2700_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -4919- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4920- DISPLAY 'R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ' */
                _.Display($"R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ");

                /*" -4922- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                .Display();

                /*" -4922- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2700-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R2700_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -4916- EXEC SQL SELECT NOME_PRODUTO, COD_PRODUTO INTO :PRODUVG-NOME-PRODUTO, :PRODUVG-COD-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES END-EXEC. */

            var r2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2710-00-SELECT-ESTIP-SECTION */
        private void R2710_00_SELECT_ESTIP_SECTION()
        {
            /*" -4933- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", WABEND.WNR_EXEC_SQL);

            /*" -4940- PERFORM R2710_00_SELECT_ESTIP_DB_SELECT_1 */

            R2710_00_SELECT_ESTIP_DB_SELECT_1();

            /*" -4943- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4944- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4945- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                    _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -4946- ELSE */
                }
                else
                {


                    /*" -4947- DISPLAY 'R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ' */
                    _.Display($"R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ");

                    /*" -4949- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                    $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                    .Display();

                    /*" -4949- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2710-00-SELECT-ESTIP-DB-SELECT-1 */
        public void R2710_00_SELECT_ESTIP_DB_SELECT_1()
        {
            /*" -4940- EXEC SQL SELECT B.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.APOLICES A, SEGUROS.CLIENTES B WHERE A.NUM_APOLICE = :WHOST-NRAPOLICE AND B.COD_CLIENTE = A.COD_CLIENTE END-EXEC. */

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
        /*" R2710-00-SELECT-SUBESTIP-SECTION */
        private void R2710_00_SELECT_SUBESTIP_SECTION()
        {
            /*" -4960- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", WABEND.WNR_EXEC_SQL);

            /*" -4968- PERFORM R2710_00_SELECT_SUBESTIP_DB_SELECT_1 */

            R2710_00_SELECT_SUBESTIP_DB_SELECT_1();

            /*" -4971- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4972- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4973- MOVE SPACES TO PRODUVG-NOME-PRODUTO */
                    _.Move("", PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);

                    /*" -4974- ELSE */
                }
                else
                {


                    /*" -4975- DISPLAY 'R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ' */
                    _.Display($"R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ");

                    /*" -4977- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                    $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                    .Display();

                    /*" -4979- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4980- IF SVA-NRAPOLICE EQUAL 97010000889 */

            if (REG_SVP0437B.SVA_NRAPOLICE == 97010000889)
            {

                /*" -4981- MOVE 9706 TO LR08-COD-PRODUTO */
                _.Move(9706, LR08_LINHA08.LR08_TIPO.LR08_COD_PRODUTO);

                /*" -4982- MOVE 'EMPRESARIAL' TO LR08-NOM-PRODUTO */
                _.Move("EMPRESARIAL", LR08_LINHA08.LR08_TIPO.LR08_NOM_PRODUTO);

                /*" -4983- ELSE */
            }
            else
            {


                /*" -4984- MOVE SVA-RAMO TO WS-RAMOFR */
                _.Move(REG_SVP0437B.SVA_RAMO, WS_RAMO.WS_RAMOFR);

                /*" -4985- MOVE 99 TO WS-RAMOFR-99 */
                _.Move(99, WS_RAMO.WS_RAMOFR_99);

                /*" -4986- MOVE WS-RAMO TO LR08-COD-PRODUTO */
                _.Move(WS_RAMO, LR08_LINHA08.LR08_TIPO.LR08_COD_PRODUTO);

                /*" -4986- MOVE 'APOLICE ESPECIFICA' TO LR08-NOM-PRODUTO. */
                _.Move("APOLICE ESPECIFICA", LR08_LINHA08.LR08_TIPO.LR08_NOM_PRODUTO);
            }


        }

        [StopWatch]
        /*" R2710-00-SELECT-SUBESTIP-DB-SELECT-1 */
        public void R2710_00_SELECT_SUBESTIP_DB_SELECT_1()
        {
            /*" -4968- EXEC SQL SELECT B.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.SUBGRUPOS_VGAP A, SEGUROS.CLIENTES B WHERE A.NUM_APOLICE = :WHOST-NRAPOLICE AND A.COD_SUBGRUPO = :WHOST-CODSUBES AND B.COD_CLIENTE = A.COD_CLIENTE END-EXEC. */

            var r2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1 = new R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1.Execute(r2710_00_SELECT_SUBESTIP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2750-00-SELECT-HISCOBPR-SECTION */
        private void R2750_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -4996- MOVE '2750' TO WNR-EXEC-SQL. */
            _.Move("2750", WABEND.WNR_EXEC_SQL);

            /*" -4998- MOVE 'S' TO WTEM-HISCOBPR. */
            _.Move("S", WTEM_HISCOBPR);

            /*" -5007- PERFORM R2750_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R2750_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -5010- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5011- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5012- MOVE 'N' TO WTEM-HISCOBPR */
                    _.Move("N", WTEM_HISCOBPR);

                    /*" -5014- MOVE ZEROS TO HISCOBPR-QTMDIT VIND-QTMDIT */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT, VIND_QTMDIT);

                    /*" -5015- ELSE */
                }
                else
                {


                    /*" -5017- DISPLAY '*** VP0437B PROBLEMAS ACESSO HIS_COBER_PROPOST' WHOST-NRCERTIF */
                    _.Display($"*** VP0437B PROBLEMAS ACESSO HIS_COBER_PROPOST{WHOST_NRCERTIF}");

                    /*" -5019- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5020- IF VIND-QTMDIT LESS ZEROES */

            if (VIND_QTMDIT < 00)
            {

                /*" -5020- MOVE ZEROES TO HISCOBPR-QTMDIT. */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
            }


        }

        [StopWatch]
        /*" R2750-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R2750_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -5007- EXEC SQL SELECT QTMDIT INTO :HISCOBPR-QTMDIT:VIND-QTMDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND DATA_INIVIGENCIA <= CURRENT DATE AND DATA_TERVIGENCIA >= CURRENT DATE END-EXEC. */

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
            /*" -5031- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WABEND.WNR_EXEC_SQL);

            /*" -5043- PERFORM R2800_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R2800_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -5046- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5047- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5049- DISPLAY '*** VP0437B DESPREZADO SEGURADOS_VGAP ' WHOST-NRCERTIF */
                    _.Display($"*** VP0437B DESPREZADO SEGURADOS_VGAP {WHOST_NRCERTIF}");

                    /*" -5050- ELSE */
                }
                else
                {


                    /*" -5052- DISPLAY '*** VP0437B PROBLEMAS ACESSO SEGURADOS_VGAP ' WHOST-NRCERTIF */
                    _.Display($"*** VP0437B PROBLEMAS ACESSO SEGURADOS_VGAP {WHOST_NRCERTIF}");

                    /*" -5052- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R2800_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -5043- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_ITEM, OCORR_HISTORICO INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

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
        /*" R2900-00-TRATA-RELATORI-SECTION */
        private void R2900_00_TRATA_RELATORI_SECTION()
        {
            /*" -5063- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WABEND.WNR_EXEC_SQL);

            /*" -5065- PERFORM R2910-00-OBTEM-NUMERACAO. */

            R2910_00_OBTEM_NUMERACAO_SECTION();

            /*" -5067- MOVE RELATORI-NUM-COPIAS TO LR07-SEQ. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS, LR07_LINHA07.LR07_SEQ);

            /*" -5069- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_DATA_SQL);

            /*" -5070- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(WS_DATA_SQL.WS_DIA_SQL, WS_DATA.WS_DIA);

            /*" -5071- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(WS_DATA_SQL.WS_MES_SQL, WS_DATA.WS_MES);

            /*" -5073- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, WS_DATA.WS_ANO);

            /*" -5075- MOVE TAB-MES(WS-MES-SQL) TO LR07-MES. */
            _.Move(TABELA_MESES.TAB_MESES_R.TAB_MES[WS_DATA_SQL.WS_MES_SQL], LR07_LINHA07.LR07_MES);

            /*" -5078- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", WS_DATA_I.FILLERB1, WS_DATA_I.FILLERB2);

            /*" -5079- MOVE WS-ANO-SQL TO LK-ANO-CALC. */
            _.Move(WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC);

            /*" -5080- MOVE WS-MES-SQL TO LK-MES-CALC. */
            _.Move(WS_DATA_SQL.WS_MES_SQL, LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC);

            /*" -5080- MOVE WS-DIA-SQL TO LK-DIA-CALC. */
            _.Move(WS_DATA_SQL.WS_DIA_SQL, LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2901-00-TRATA-EMAIL-TEL-SECTION */
        private void R2901_00_TRATA_EMAIL_TEL_SECTION()
        {
            /*" -5088- MOVE '2901' TO WNR-EXEC-SQL. */
            _.Move("2901", WABEND.WNR_EXEC_SQL);

            /*" -5089- MOVE SVA-NRCERTIF TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(REG_SVP0437B.SVA_NRCERTIF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -5090- PERFORM R2902-00-LER-FIDELIZ */

            R2902_00_LER_FIDELIZ_SECTION();

            /*" -5091- PERFORM R2903-00-LER-EMAIL */

            R2903_00_LER_EMAIL_SECTION();

            /*" -5092- PERFORM R2904-00-LER-TELEFONE */

            R2904_00_LER_TELEFONE_SECTION();

            /*" -5092- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2901_99_SAIDA*/

        [StopWatch]
        /*" R2902-00-LER-FIDELIZ-SECTION */
        private void R2902_00_LER_FIDELIZ_SECTION()
        {
            /*" -5100- MOVE '2902' TO WNR-EXEC-SQL. */
            _.Move("2902", WABEND.WNR_EXEC_SQL);

            /*" -5106- PERFORM R2902_00_LER_FIDELIZ_DB_SELECT_1 */

            R2902_00_LER_FIDELIZ_DB_SELECT_1();

            /*" -5109- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5111- DISPLAY '*** VP0437B ERRO NO SELECT DA PROPOSTA_FIDELIZ' */
                _.Display($"*** VP0437B ERRO NO SELECT DA PROPOSTA_FIDELIZ");

                /*" -5113- DISPLAY 'NUM_PROPOSTA_SIVPF = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"NUM_PROPOSTA_SIVPF = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -5114- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5114- END-IF. */
            }


        }

        [StopWatch]
        /*" R2902-00-LER-FIDELIZ-DB-SELECT-1 */
        public void R2902_00_LER_FIDELIZ_DB_SELECT_1()
        {
            /*" -5106- EXEC SQL SELECT COD_PESSOA INTO :PROPOFID-COD-PESSOA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r2902_00_LER_FIDELIZ_DB_SELECT_1_Query1 = new R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R2902_00_LER_FIDELIZ_DB_SELECT_1_Query1.Execute(r2902_00_LER_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2902_99_SAIDA*/

        [StopWatch]
        /*" R2903-00-LER-EMAIL-SECTION */
        private void R2903_00_LER_EMAIL_SECTION()
        {
            /*" -5122- MOVE '2903' TO WNR-EXEC-SQL. */
            _.Move("2903", WABEND.WNR_EXEC_SQL);

            /*" -5130- PERFORM R2903_00_LER_EMAIL_DB_SELECT_1 */

            R2903_00_LER_EMAIL_DB_SELECT_1();

            /*" -5133- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5134- MOVE EMAIL TO DET3-E-MAIL DET6-E-MAIL */
                _.Move(PESEMAIL.DCLPESSOA_EMAIL.EMAIL, DETALHE_DS03.DET3_E_MAIL, DETALHE_DS06.DET6_E_MAIL);

                /*" -5136- END-IF */
            }


            /*" -5137- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5138- MOVE SPACES TO DET3-E-MAIL DET6-E-MAIL */
                _.Move("", DETALHE_DS03.DET3_E_MAIL, DETALHE_DS06.DET6_E_MAIL);

                /*" -5140- END-IF */
            }


            /*" -5141- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -5142- DISPLAY '*** VP0437B ERRO NO SELECT DA PESSOA_EMAIL  ' */
                _.Display($"*** VP0437B ERRO NO SELECT DA PESSOA_EMAIL  ");

                /*" -5143- DISPLAY 'COD_PESSOA = ' PROPOFID-COD-PESSOA */
                _.Display($"COD_PESSOA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                /*" -5144- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5144- END-IF. */
            }


        }

        [StopWatch]
        /*" R2903-00-LER-EMAIL-DB-SELECT-1 */
        public void R2903_00_LER_EMAIL_DB_SELECT_1()
        {
            /*" -5130- EXEC SQL SELECT EMAIL INTO :EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :PROPOFID-COD-PESSOA ORDER BY SEQ_EMAIL DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r2903_00_LER_EMAIL_DB_SELECT_1_Query1 = new R2903_00_LER_EMAIL_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2903_00_LER_EMAIL_DB_SELECT_1_Query1.Execute(r2903_00_LER_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2903_99_SAIDA*/

        [StopWatch]
        /*" R2904-00-LER-TELEFONE-SECTION */
        private void R2904_00_LER_TELEFONE_SECTION()
        {
            /*" -5152- MOVE '2904' TO WNR-EXEC-SQL. */
            _.Move("2904", WABEND.WNR_EXEC_SQL);

            /*" -5161- PERFORM R2904_00_LER_TELEFONE_DB_SELECT_1 */

            R2904_00_LER_TELEFONE_DB_SELECT_1();

            /*" -5164- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5165- MOVE DDD TO DET3-DDD DET6-DDD */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, DETALHE_DS03.DET3_DDD, DETALHE_DS06.DET6_DDD);

                /*" -5166- MOVE NUM-FONE TO DET3-TELEFONE DET6-TELEFONE */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, DETALHE_DS03.DET3_TELEFONE, DETALHE_DS06.DET6_TELEFONE);

                /*" -5168- END-IF */
            }


            /*" -5169- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5170- MOVE SPACES TO DET3-DDD DET6-DDD */
                _.Move("", DETALHE_DS03.DET3_DDD, DETALHE_DS06.DET6_DDD);

                /*" -5171- MOVE SPACES TO DET3-TELEFONE DET6-TELEFONE */
                _.Move("", DETALHE_DS03.DET3_TELEFONE, DETALHE_DS06.DET6_TELEFONE);

                /*" -5173- END-IF */
            }


            /*" -5174- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -5175- DISPLAY '*** VP0437B ERRO NO SELECT DA PESSOA_TELEFONE' */
                _.Display($"*** VP0437B ERRO NO SELECT DA PESSOA_TELEFONE");

                /*" -5176- DISPLAY 'COD_PESSOA = ' PROPOFID-COD-PESSOA */
                _.Display($"COD_PESSOA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                /*" -5177- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5177- END-IF. */
            }


        }

        [StopWatch]
        /*" R2904-00-LER-TELEFONE-DB-SELECT-1 */
        public void R2904_00_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -5161- EXEC SQL SELECT DDD, NUM_FONE INTO :DDD ,:NUM-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :PROPOFID-COD-PESSOA ORDER BY TIMESTAMP DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r2904_00_LER_TELEFONE_DB_SELECT_1_Query1 = new R2904_00_LER_TELEFONE_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2904_00_LER_TELEFONE_DB_SELECT_1_Query1.Execute(r2904_00_LER_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);
                _.Move(executed_1.NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2904_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-SECTION */
        private void R2910_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -5187- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", WABEND.WNR_EXEC_SQL);

            /*" -5194- PERFORM R2910_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R2910_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -5197- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5198- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5200- MOVE ZEROS TO RELATORI-NUM-COPIAS */
                    _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

                    /*" -5201- ELSE */
                }
                else
                {


                    /*" -5202- DISPLAY 'R2910 - PROBLEMAS SELECT RELATORIOS' */
                    _.Display($"R2910 - PROBLEMAS SELECT RELATORIOS");

                    /*" -5204- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5205- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -5206- MOVE ZEROS TO RELATORI-NUM-COPIAS. */
                _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R2910_10_INCLUI_RELATORIO */

            R2910_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R2910_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -5194- EXEC SQL SELECT MAX(NUM_COPIAS) INTO :RELATORI-NUM-COPIAS:VIND-NRCOPIAS FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER END-EXEC. */

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
            /*" -5213- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -5216- ADD 1 TO RELATORI-NUM-COPIAS. */
            RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.Value = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS + 1;

            /*" -5259- PERFORM R2910_10_INCLUI_RELATORIO_DB_INSERT_1 */

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -5262- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -5263- DISPLAY 'R2910 - (REGISTRO DUPLICADO) ... ' */
                _.Display($"R2910 - (REGISTRO DUPLICADO) ... ");

                /*" -5265- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5266- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5267- DISPLAY 'R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -5269- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5269- ADD 1 TO AC-I-RELATORI. */
            AC_I_RELATORI.Value = AC_I_RELATORI + 1;

        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO-DB-INSERT-1 */
        public void R2910_10_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -5259- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'EM0600B' , :SISTEMAS-DATA-MOV-ABERTO, 'EM' , 'CARTAECT' , :RELATORI-NUM-COPIAS, 0, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-MESREFER, :V1SIST-ANOREFER, 0, 0, 0, 0, 0, 0, :WHOST-NRAPOLICE, 0, 0, 0, 0, :WHOST-CODSUBES, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

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
        /*" R3000-00-IMPRIME-LST-SECTION */
        private void R3000_00_IMPRIME_LST_SECTION()
        {
            /*" -5280- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -5282- MOVE 1 TO WIND. */
            _.Move(1, WIND);

            /*" -5282- WRITE FVP0437B-RECORD FROM LR02-LINHA02. */
            _.Move(LR02_LINHA02.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LOOP_OCORR */

            R3000_10_LOOP_OCORR();

        }

        [StopWatch]
        /*" R3000-10-LOOP-OCORR */
        private void R3000_10_LOOP_OCORR(bool isPerform = false)
        {
            /*" -5287- IF WIND GREATER 2000 */

            if (WIND > 2000)
            {

                /*" -5288- MOVE 1 TO WIND */
                _.Move(1, WIND);

                /*" -5290- GO TO R3000-20-INT. */

                R3000_20_INT(); //GOTO
                return;
            }


            /*" -5291- IF TAB1-QTD-OBJ (WIND) NOT EQUAL ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_QTD_OBJ != 00)
            {

                /*" -5293- ADD 1 TO WS-OCORR. */
                WS_OCORR.Value = WS_OCORR + 1;
            }


            /*" -5295- ADD 1 TO WIND. */
            WIND.Value = WIND + 1;

            /*" -5295- GO TO R3000-10-LOOP-OCORR. */
            new Task(() => R3000_10_LOOP_OCORR()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3000-20-INT */
        private void R3000_20_INT(bool isPerform = false)
        {
            /*" -5300- COMPUTE WWORK-QTDE = (WS-OCORR / 18) */
            WWORK_QTDE.Value = (WS_OCORR / 18f);

            /*" -5301- IF WWORK-QTDE12 NOT EQUAL ZEROS */

            if (WWORK_QTDE01.WWORK_QTDE12 != 00)
            {

                /*" -5303- COMPUTE WWORK-QTDE11 = WWORK-QTDE11 + 1. */
                WWORK_QTDE01.WWORK_QTDE11.Value = WWORK_QTDE01.WWORK_QTDE11 + 1;
            }


            /*" -5303- MOVE WWORK-QTDE11 TO LR10-PAGINA-T. */
            _.Move(WWORK_QTDE01.WWORK_QTDE11, LR10_LINHA10.LR10_PAGINA_T);

        }

        [StopWatch]
        /*" R3000-30-LOOP-CABEC */
        private void R3000_30_LOOP_CABEC(bool isPerform = false)
        {
            /*" -5308- IF WIND > 2000 */

            if (WIND > 2000)
            {

                /*" -5309- MOVE 80 TO AC-LINHAS */
                _.Move(80, AC_LINHAS);

                /*" -5311- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5312- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -5313- ADD 1 TO WIND */
                WIND.Value = WIND + 1;

                /*" -5315- GO TO R3000-30-LOOP-CABEC. */
                new Task(() => R3000_30_LOOP_CABEC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5317- ADD 1 TO AC-PAGINA. */
            AC_PAGINA.Value = AC_PAGINA + 1;

            /*" -5319- MOVE AC-PAGINA TO LR10-PAGINA. */
            _.Move(AC_PAGINA, LR10_LINHA10.LR10_PAGINA);

            /*" -5320- IF AC-PAGINA GREATER 1 */

            if (AC_PAGINA > 1)
            {

                /*" -5322- WRITE FVP0437B-RECORD FROM LR13-LINHA13. */
                _.Move(LR13_LINHA13.GetMoveValues(), FVP0437B_RECORD);

                FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());
            }


            /*" -5324- PERFORM R3010-00-CABECALHOS. */

            R3010_00_CABECALHOS_SECTION();

            /*" -5325- WRITE FVP0437B-RECORD FROM LR10-LINHA10. */
            _.Move(LR10_LINHA10.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -5327- MOVE 1 TO AC-LINHAS. */
            _.Move(1, AC_LINHAS);

            /*" -5328- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[WIND].TAB_FAIXAS.TAB_FX_INI, WS_NUM_CEP_AUX);

            /*" -5329- MOVE WS-CEP-AUX TO LR12-CEPI. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, LR12_LINHA12.LR12_CEPI);

            /*" -5330- MOVE WS-CEP-COMPL-AUX TO LR12-COMPL-CEPI. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, LR12_LINHA12.LR12_COMPL_CEPI);

            /*" -5331- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[WIND].TAB_FAIXAS.TAB_FX_FIM, WS_NUM_CEP_AUX);

            /*" -5332- MOVE WS-CEP-AUX TO LR12-CEPF. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, LR12_LINHA12.LR12_CEPF);

            /*" -5333- MOVE WS-CEP-COMPL-AUX TO LR12-COMPL-CEPF. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, LR12_LINHA12.LR12_COMPL_CEPF);

            /*" -5334- MOVE TAB1-OBJI (WIND) TO LR12-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_OBJI, LR12_LINHA12.LR12_OBJI);

            /*" -5335- MOVE TAB1-OBJF (WIND) TO LR12-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_OBJF, LR12_LINHA12.LR12_OBJF);

            /*" -5336- MOVE TAB1-AMARI (WIND) TO LR12-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_AMARI, LR12_LINHA12.LR12_AMARI);

            /*" -5337- MOVE TAB1-AMARF (WIND) TO LR12-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_AMARF, LR12_LINHA12.LR12_AMARF);

            /*" -5338- MOVE TAB1-QTD-OBJ (WIND) TO LR12-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_QTD_OBJ, LR12_LINHA12.LR12_QTD_OBJ);

            /*" -5339- MOVE TAB1-QTD-AMAR(WIND) TO LR12-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_QTD_AMAR, LR12_LINHA12.LR12_QTD_AMAR);

            /*" -5340- MOVE SPACES TO LR12-OBS. */
            _.Move("", LR12_LINHA12.LR12_OBS);

            /*" -5340- WRITE FVP0437B-RECORD FROM LR12-LINHA12. */
            _.Move(LR12_LINHA12.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R3000-40-LOOP-DET */
        private void R3000_40_LOOP_DET(bool isPerform = false)
        {
            /*" -5346- ADD 1 TO WIND. */
            WIND.Value = WIND + 1;

            /*" -5347- IF WIND > 2000 */

            if (WIND > 2000)
            {

                /*" -5348- MOVE 80 TO AC-LINHAS */
                _.Move(80, AC_LINHAS);

                /*" -5350- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5351- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -5353- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5354- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[WIND].TAB_FAIXAS.TAB_FX_INI, WS_NUM_CEP_AUX);

            /*" -5355- MOVE WS-CEP-AUX TO LR12-CEPI. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, LR12_LINHA12.LR12_CEPI);

            /*" -5356- MOVE WS-CEP-COMPL-AUX TO LR12-COMPL-CEPI. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, LR12_LINHA12.LR12_COMPL_CEPI);

            /*" -5357- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[WIND].TAB_FAIXAS.TAB_FX_FIM, WS_NUM_CEP_AUX);

            /*" -5358- MOVE WS-CEP-AUX TO LR12-CEPF. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_AUX, LR12_LINHA12.LR12_CEPF);

            /*" -5359- MOVE WS-CEP-COMPL-AUX TO LR12-COMPL-CEPF. */
            _.Move(WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, LR12_LINHA12.LR12_COMPL_CEPF);

            /*" -5360- MOVE TAB1-OBJI (WIND) TO LR12-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_OBJI, LR12_LINHA12.LR12_OBJI);

            /*" -5361- MOVE TAB1-OBJF (WIND) TO LR12-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_OBJF, LR12_LINHA12.LR12_OBJF);

            /*" -5362- MOVE TAB1-AMARI (WIND) TO LR12-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_AMARI, LR12_LINHA12.LR12_AMARI);

            /*" -5363- MOVE TAB1-AMARF (WIND) TO LR12-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_AMARF, LR12_LINHA12.LR12_AMARF);

            /*" -5364- MOVE TAB1-QTD-OBJ (WIND) TO LR12-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_QTD_OBJ, LR12_LINHA12.LR12_QTD_OBJ);

            /*" -5365- MOVE TAB1-QTD-AMAR(WIND) TO LR12-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[WIND].TAB1_QTD_AMAR, LR12_LINHA12.LR12_QTD_AMAR);

            /*" -5366- MOVE SPACES TO LR12-OBS. */
            _.Move("", LR12_LINHA12.LR12_OBS);

            /*" -5367- WRITE FVP0437B-RECORD FROM LR12-LINHA12. */
            _.Move(LR12_LINHA12.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -5369- ADD 1 TO AC-LINHAS. */
            AC_LINHAS.Value = AC_LINHAS + 1;

            /*" -5370- IF AC-LINHAS > 17 */

            if (AC_LINHAS > 17)
            {

                /*" -5371- ADD 1 TO WIND */
                WIND.Value = WIND + 1;

                /*" -5372- GO TO R3000-30-LOOP-CABEC */

                R3000_30_LOOP_CABEC(); //GOTO
                return;

                /*" -5373- ELSE */
            }
            else
            {


                /*" -5373- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-CABECALHOS-SECTION */
        private void R3010_00_CABECALHOS_SECTION()
        {
            /*" -5382- WRITE FVP0437B-RECORD FROM LR03-LINHA03 */
            _.Move(LR03_LINHA03.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -5383- WRITE FVP0437B-RECORD FROM LR04-LINHA04 */
            _.Move(LR04_LINHA04.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -5384- WRITE FVP0437B-RECORD FROM LR05-LINHA05 */
            _.Move(LR05_LINHA05.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -5385- WRITE FVP0437B-RECORD FROM LR06-LINHA06 */
            _.Move(LR06_LINHA06.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -5386- WRITE FVP0437B-RECORD FROM LR07-LINHA07 */
            _.Move(LR07_LINHA07.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -5387- WRITE FVP0437B-RECORD FROM LR08-LINHA08 */
            _.Move(LR08_LINHA08.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -5388- WRITE FVP0437B-RECORD FROM LR09-LINHA09 */
            _.Move(LR09_LINHA09.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

            /*" -5388- WRITE FVP0437B-RECORD FROM LR10-LINHA10-A. */
            _.Move(LR10_LINHA10_A.GetMoveValues(), FVP0437B_RECORD);

            FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SEPARA-PRODUTO-SECTION */
        private void R3100_00_SEPARA_PRODUTO_SECTION()
        {
            /*" -5399- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -5407- MOVE 999999 TO LF04-FAIXA1 LF04-FAIXA2 LF04-FAIXA1C LF04-FAIXA2C LF04-AMARRADO LF04-QTD-OBJ LF04-SEQ-INICIAL LF04-SEQ-FINAL. */
            _.Move(999999, LF04_LINHA04.LF04_FAIXA1, LF04_LINHA04.LF04_FAIXA2, LF04_LINHA04.LF04_FAIXA1C, LF04_LINHA04.LF04_FAIXA2C, LF04_LINHA04.LF04_AMARRADO, LF04_LINHA04.LF04_QTD_OBJ, LF04_LINHA04.LF04_SEQ_INICIAL, LF04_LINHA04.LF04_SEQ_FINAL);

            /*" -5409- MOVE LR11-TP-PGTO TO LF04-NOME-FAIXA. */
            _.Move(LR11_LINHA11.LR11_TP_PGTO, LF04_LINHA04.LF04_NOME_FAIXA);

            /*" -5410- IF WS-CONTR-PRODU EQUAL 'C' */

            if (WS_CONTR_PRODU == "C")
            {

                /*" -5411- PERFORM R3200-00-FAC-PRODUTO 1 TIMES */

                for (int i = 0; i < 1; i++)
                {

                    R3200_00_FAC_PRODUTO_SECTION();

                }

                /*" -5412- ELSE */
            }
            else
            {


                /*" -5412- PERFORM R3200-00-FAC-PRODUTO. */

                R3200_00_FAC_PRODUTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-FAC-PRODUTO-SECTION */
        private void R3200_00_FAC_PRODUTO_SECTION()
        {
            /*" -5425- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WABEND.WNR_EXEC_SQL);

            /*" -5426- IF WS-CONTR-PRODU EQUAL 'C' */

            if (WS_CONTR_PRODU == "C")
            {

                /*" -5427- WRITE RVP0437B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVP0437B_RECORD);

                RVP0437B.Write(RVP0437B_RECORD.GetMoveValues().ToString());

                /*" -5428- ELSE */
            }
            else
            {


                /*" -5429- WRITE FVP0437B-RECORD FROM LF01-LINHA01 */
                _.Move(LF01_LINHA01.GetMoveValues(), FVP0437B_RECORD);

                FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

                /*" -5430- WRITE FVP0437B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), FVP0437B_RECORD);

                FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

                /*" -5431- WRITE FVP0437B-RECORD FROM LF02-LINHA02 */
                _.Move(LF02_LINHA02.GetMoveValues(), FVP0437B_RECORD);

                FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

                /*" -5432- WRITE FVP0437B-RECORD FROM LF03-LINHA03 */
                _.Move(LF03_LINHA03.GetMoveValues(), FVP0437B_RECORD);

                FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

                /*" -5433- WRITE FVP0437B-RECORD FROM LF04-LINHA04 */
                _.Move(LF04_LINHA04.GetMoveValues(), FVP0437B_RECORD);

                FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

                /*" -5434- WRITE FVP0437B-RECORD FROM LC12-LINHA12 */
                _.Move(LC12_LINHA12.GetMoveValues(), FVP0437B_RECORD);

                FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());

                /*" -5434- WRITE FVP0437B-RECORD FROM LC01-LINHA01. */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVP0437B_RECORD);

                FVP0437B.Write(FVP0437B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-SELECT-PRODUVG-SECTION */
        private void R3300_00_SELECT_PRODUVG_SECTION()
        {
            /*" -5444- MOVE 'S' TO WTEM-PRODUVGE. */
            _.Move("S", WTEM_PRODUVGE);

            /*" -5447- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", WABEND.WNR_EXEC_SQL);

            /*" -5455- PERFORM R3300_00_SELECT_PRODUVG_DB_SELECT_1 */

            R3300_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -5458- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5459- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5460- MOVE 'N' TO WTEM-PRODUVGE */
                    _.Move("N", WTEM_PRODUVGE);

                    /*" -5461- ELSE */
                }
                else
                {


                    /*" -5462- DISPLAY 'R3300 - PROBLEMAS NO ACESSO A PRODUTOS_VG ' */
                    _.Display($"R3300 - PROBLEMAS NO ACESSO A PRODUTOS_VG ");

                    /*" -5464- DISPLAY 'NUM_APOLICE - ' SEGURVGA-NUM-APOLICE ' ' 'COD_SUBGRUPO- ' SEGURVGA-COD-SUBGRUPO */

                    $"NUM_APOLICE - {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE} COD_SUBGRUPO- {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO}"
                    .Display();

                    /*" -5464- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3300-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R3300_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -5455- EXEC SQL SELECT ID_SISTEMA, VALUE(CODRELAT, '********' ) INTO :PRODUVG-ID-SISTEMA, :PRODUVG-CODRELAT FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_ID_SISTEMA, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ID_SISTEMA);
                _.Move(executed_1.PRODUVG_CODRELAT, PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -5475- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -5476- OPEN OUTPUT RVP0437B FVP0437B. */
            RVP0437B.Open(RVP0437B_RECORD);
            FVP0437B.Open(FVP0437B_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -5487- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -5488- CLOSE RVP0437B FVP0437B. */
            RVP0437B.Close();
            FVP0437B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -5501- MOVE '9800' TO WNR-EXEC-SQL. */
            _.Move("9800", WABEND.WNR_EXEC_SQL);

            /*" -5502- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -5503- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -5504- DISPLAY '*   VP0437B - EMITE CERTIFICADO            *' */
            _.Display($"*   VP0437B - EMITE CERTIFICADO            *");

            /*" -5505- DISPLAY '*   -------   -----------------            *' */
            _.Display($"*   -------   -----------------            *");

            /*" -5506- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -5507- DISPLAY '*             NAO EXISTEM CERTIFICADOS A   *' */
            _.Display($"*             NAO EXISTEM CERTIFICADOS A   *");

            /*" -5508- DISPLAY '*             SEREM EMITIDOS.              *' */
            _.Display($"*             SEREM EMITIDOS.              *");

            /*" -5509- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -5509- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5521- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -5522- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -5523- DISPLAY '*** VP0437B - LIDOS         ' AC-LIDOS. */
            _.Display($"*** VP0437B - LIDOS         {AC_LIDOS}");

            /*" -5525- DISPLAY '*** VP0437B - CERTIFICADO   ' PROPOVA-NUM-CERTIFICADO. */
            _.Display($"*** VP0437B - CERTIFICADO   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -5527- DISPLAY '*** VP0437B - CERTIFICADO-W ' WHOST-NRCERTIF. */
            _.Display($"*** VP0437B - CERTIFICADO-W {WHOST_NRCERTIF}");

            /*" -5527- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -5529- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5533- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5533- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9900-00-GRAVA-OBJETO-SECTION */
        private void R9900_00_GRAVA_OBJETO_SECTION()
        {
            /*" -5542- MOVE FUNCTION UPPER-CASE (LC09-JDE) TO GEOBJECT-COD-FORMULARIO */
            _.Move(AREA_DE_WORK.LC09_JDE.ToString().ToUpper(), GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

            /*" -5551- PERFORM R9900_00_GRAVA_OBJETO_DB_SELECT_1 */

            R9900_00_GRAVA_OBJETO_DB_SELECT_1();

            /*" -5555- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5556- PERFORM R9900-03-VALUES-DETALHE */

                R9900_03_VALUES_DETALHE_SECTION();

                /*" -5557- PERFORM R9900-02-INSERT-OBJETO */

                R9900_02_INSERT_OBJETO_SECTION();

                /*" -5559- GO TO R9900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5560- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -5561- DISPLAY 'ERRO DE ACESSO A TABELA GE_OBJETO_ECT.' */
                _.Display($"ERRO DE ACESSO A TABELA GE_OBJETO_ECT.");

                /*" -5562- DISPLAY 'SQLCODE............... ' SQLCODE */
                _.Display($"SQLCODE............... {DB.SQLCODE}");

                /*" -5563- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5564- ELSE */
            }
            else
            {


                /*" -5565- PERFORM R9900-01-VALUES-HEADER */

                R9900_01_VALUES_HEADER_SECTION();

                /*" -5566- PERFORM R9900-02-INSERT-OBJETO */

                R9900_02_INSERT_OBJETO_SECTION();

                /*" -5567- PERFORM R9900-03-VALUES-DETALHE */

                R9900_03_VALUES_DETALHE_SECTION();

                /*" -5567- PERFORM R9900-02-INSERT-OBJETO. */

                R9900_02_INSERT_OBJETO_SECTION();
            }


        }

        [StopWatch]
        /*" R9900-00-GRAVA-OBJETO-DB-SELECT-1 */
        public void R9900_00_GRAVA_OBJETO_DB_SELECT_1()
        {
            /*" -5551- EXEC SQL SELECT STA_REGISTRO INTO :GEOBJECT-STA-REGISTRO FROM SEGUROS.GE_OBJETO_ECT WHERE NUM_CEP = 0 AND NOM_PROGRAMA = 'VP0437B' AND COD_FORMULARIO = :GEOBJECT-COD-FORMULARIO AND STA_REGISTRO = 'H' AND DATE(DTH_TIMESTAMP) <> '9999-12-31' END-EXEC. */

            var r9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1 = new R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1()
            {
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
            };

            var executed_1 = R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1.Execute(r9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOBJECT_STA_REGISTRO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9900-02-INSERT-OBJETO-SECTION */
        private void R9900_02_INSERT_OBJETO_SECTION()
        {
            /*" -5587- PERFORM R9900_02_INSERT_OBJETO_DB_INSERT_1 */

            R9900_02_INSERT_OBJETO_DB_INSERT_1();

            /*" -5590- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5591- IF GEOBJECT-STA-REGISTRO = 'D' */

                if (GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO == "D")
                {

                    /*" -5592- ADD 1 TO WS-QTD-GRAVADOS */
                    WS_QTD_GRAVADOS.Value = WS_QTD_GRAVADOS + 1;

                    /*" -5593- END-IF */
                }


                /*" -5595- END-IF */
            }


            /*" -5596- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5597- IF SQLCODE EQUAL -530 */

                if (DB.SQLCODE == -530)
                {

                    /*" -5599- DISPLAY 'FORMULARIO............ ' GEOBJECT-COD-FORMULARIO */
                    _.Display($"FORMULARIO............ {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO}");

                    /*" -5600- DISPLAY 'SQLCODE............... ' SQLCODE */
                    _.Display($"SQLCODE............... {DB.SQLCODE}");

                    /*" -5601- DISPLAY 'CERTIFICADO..: ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO..: {REG_SVP0437B.SVA_NRCERTIF}");

                    /*" -5602- DISPLAY 'APOLICE......: ' SVA-NRAPOLICE */
                    _.Display($"APOLICE......: {REG_SVP0437B.SVA_NRAPOLICE}");

                    /*" -5603- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                    /*" -5604- MOVE SQLERRMC TO WSQLERRMC */
                    _.Move(DB.SQLERRMC, WABEND.WSQLERRMC);

                    /*" -5605- DISPLAY ' WABEND ' WABEND */
                    _.Display($" WABEND {WABEND}");

                    /*" -5606- GO TO R2200-40-NEXT */

                    R2200_40_NEXT(); //GOTO
                    return;

                    /*" -5607- ELSE */
                }
                else
                {


                    /*" -5608- DISPLAY 'ERRO NO INSERT DA GE-OBJETO-ECT ' */
                    _.Display($"ERRO NO INSERT DA GE-OBJETO-ECT ");

                    /*" -5610- DISPLAY 'H = HEADER D = DETALHE.' GEOBJECT-STA-REGISTRO */
                    _.Display($"H = HEADER D = DETALHE.{GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO}");

                    /*" -5611- DISPLAY 'PROGRAMA VP0437B.......' */
                    _.Display($"PROGRAMA VP0437B.......");

                    /*" -5613- DISPLAY 'FORMULARIO............ ' GEOBJECT-COD-FORMULARIO */
                    _.Display($"FORMULARIO............ {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO}");

                    /*" -5614- DISPLAY 'SQLCODE............... ' SQLCODE */
                    _.Display($"SQLCODE............... {DB.SQLCODE}");

                    /*" -5614- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R9900-02-INSERT-OBJETO-DB-INSERT-1 */
        public void R9900_02_INSERT_OBJETO_DB_INSERT_1()
        {
            /*" -5587- EXEC SQL INSERT INTO SEGUROS.GE_OBJETO_ECT VALUES (:GEOBJECT-NUM-CEP, 'VP0437B' , :GEOBJECT-COD-FORMULARIO, :GEOBJECT-STA-REGISTRO, CURRENT TIMESTAMP, :GEOBJECT-COD-PRODUTO:VIND-CODPRODUTO, :GEOBJECT-NUM-INI-POS-VERSO, :GEOBJECT-QTD-PESO-GRAMAS, :GEOBJECT-VLR-DECLARADO, :GEOBJECT-COD-IDENT-OBJETO, :GEOBJECT-DES-OBJETO) END-EXEC. */

            var r9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1 = new R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1()
            {
                GEOBJECT_NUM_CEP = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP.ToString(),
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
                GEOBJECT_STA_REGISTRO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO.ToString(),
                GEOBJECT_COD_PRODUTO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO.ToString(),
                VIND_CODPRODUTO = VIND_CODPRODUTO.ToString(),
                GEOBJECT_NUM_INI_POS_VERSO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO.ToString(),
                GEOBJECT_QTD_PESO_GRAMAS = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS.ToString(),
                GEOBJECT_VLR_DECLARADO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO.ToString(),
                GEOBJECT_COD_IDENT_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO.ToString(),
                GEOBJECT_DES_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.ToString(),
            };

            R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1.Execute(r9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_02_SAIDA*/

        [StopWatch]
        /*" R9900-01-VALUES-HEADER-SECTION */
        private void R9900_01_VALUES_HEADER_SECTION()
        {
            /*" -5622- MOVE 0 TO GEOBJECT-NUM-CEP */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -5623- MOVE 'H' TO GEOBJECT-STA-REGISTRO */
            _.Move("H", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -5624- MOVE -1 TO VIND-CODPRODUTO */
            _.Move(-1, VIND_CODPRODUTO);

            /*" -5625- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -5626- MOVE 0 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -5627- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -5629- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -5630- IF WS-TIPO-FORM = 'pe04' */

            if (WS_TIPO_FORM == "pe04")
            {

                /*" -5631- MOVE CABEC-DS03 TO GEOBJECT-DES-OBJETO-TEXT */
                _.Move(AREA_DE_WORK.CABEC_DS03, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

                /*" -5632- END-IF */
            }


            /*" -5633- IF WS-TIPO-FORM = 'pe03' OR 'pe01' OR 'vp01' */

            if (WS_TIPO_FORM.In("pe03", "pe01", "vp01"))
            {

                /*" -5634- MOVE CABEC-DS06 TO GEOBJECT-DES-OBJETO-TEXT */
                _.Move(AREA_DE_WORK.CABEC_DS06, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

                /*" -5636- END-IF. */
            }


            /*" -5637- MOVE LENGTH OF GEOBJECT-DES-OBJETO-TEXT TO GEOBJECT-DES-OBJETO-LEN. */
            _.Move(GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT.Value.Length, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_01_SAIDA*/

        [StopWatch]
        /*" R9900-03-VALUES-DETALHE-SECTION */
        private void R9900_03_VALUES_DETALHE_SECTION()
        {
            /*" -5645- MOVE 70701 TO CEP-PARTE1 */
            _.Move(70701, AREA_DE_WORK.CEP_LEGAL.CEP_PARTE1);

            /*" -5646- MOVE 050 TO CEP-PARTE2 */
            _.Move(050, AREA_DE_WORK.CEP_LEGAL.CEP_PARTE2);

            /*" -5647- MOVE CEP-TOTAL TO GEOBJECT-NUM-CEP */
            _.Move(AREA_DE_WORK.CEP_TOTAL, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -5648- MOVE 'D' TO GEOBJECT-STA-REGISTRO */
            _.Move("D", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -5649- MOVE 0 TO VIND-CODPRODUTO */
            _.Move(0, VIND_CODPRODUTO);

            /*" -5650- MOVE SVA-PRODUTO TO GEOBJECT-COD-PRODUTO */
            _.Move(REG_SVP0437B.SVA_PRODUTO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO);

            /*" -5651- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -5652- MOVE 4,6 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(4.6, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -5653- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -5654- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -5655- IF WS-TIPO-FORM = 'pe04' */

            if (WS_TIPO_FORM == "pe04")
            {

                /*" -5656- MOVE DETALHE-DS03 TO GEOBJECT-DES-OBJETO-TEXT */
                _.Move(DETALHE_DS03, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

                /*" -5657- END-IF */
            }


            /*" -5658- IF WS-TIPO-FORM = 'pe03' OR 'pe01' OR 'vp01' */

            if (WS_TIPO_FORM.In("pe03", "pe01", "vp01"))
            {

                /*" -5659- MOVE DETALHE-DS06 TO GEOBJECT-DES-OBJETO-TEXT */
                _.Move(DETALHE_DS06, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

                /*" -5660- END-IF. */
            }


            /*" -5661- MOVE LENGTH OF GEOBJECT-DES-OBJETO-TEXT TO GEOBJECT-DES-OBJETO-LEN. */
            _.Move(GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT.Value.Length, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_03_SAIDA*/
    }
}