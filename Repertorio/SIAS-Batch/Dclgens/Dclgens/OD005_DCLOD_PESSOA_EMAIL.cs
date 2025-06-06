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
    public class OD005_DCLOD_PESSOA_EMAIL : VarBasis
    {
        /*"    10 OD005-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis OD005_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD005-SEQ-EMAIL      PIC S9(4) USAGE COMP.*/
        public IntBasis OD005_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD005-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis OD005_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 OD005-DES-EMAIL      PIC X(100).*/
        public StringBasis OD005_DES_EMAIL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 OD005-STA-EMAIL      PIC X(1).*/
        public StringBasis OD005_STA_EMAIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD005-STA-CORRESPONDER  PIC X(1).*/
        public StringBasis OD005_STA_CORRESPONDER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD005-STA-CONTATO    PIC X(1).*/
        public StringBasis OD005_STA_CONTATO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD005-IND-ELETRONICO  PIC X(1).*/
        public StringBasis OD005_IND_ELETRONICO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}