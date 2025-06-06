using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class SINLOTDO_DCLSINI_LOT_DOC01 : VarBasis
    {
        /*"    10 SINLOTDO-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINLOTDO_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINLOTDO-COD-DOCUMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINLOTDO_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINLOTDO-DATA-RECEBE  PIC X(10).*/
        public StringBasis SINLOTDO_DATA_RECEBE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINLOTDO-TMSP-MOV-RECEBE  PIC X(26).*/
        public StringBasis SINLOTDO_TMSP_MOV_RECEBE { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINLOTDO-CODUSU-RECEBE  PIC X(8).*/
        public StringBasis SINLOTDO_CODUSU_RECEBE { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINLOTDO-DATA-SOLICITA  PIC X(10).*/
        public StringBasis SINLOTDO_DATA_SOLICITA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINLOTDO-TMSP-MOV-SOLICITA  PIC X(26).*/
        public StringBasis SINLOTDO_TMSP_MOV_SOLICITA { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINLOTDO-CODUSU-SOLICITA  PIC X(8).*/
        public StringBasis SINLOTDO_CODUSU_SOLICITA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINLOTDO-SITUACAO    PIC X(1).*/
        public StringBasis SINLOTDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINLOTDO-TMSP-MOV-SITUACAO  PIC X(26).*/
        public StringBasis SINLOTDO_TMSP_MOV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINLOTDO-CODUSU-SITUACAO  PIC X(8).*/
        public StringBasis SINLOTDO_CODUSU_SITUACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINLOTDO-TIMESTAMP   PIC X(26).*/
        public StringBasis SINLOTDO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}