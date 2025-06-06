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
    public class OD004_DCLOD_PESSOA_TELEFONE : VarBasis
    {
        /*"    10 OD004-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis OD004_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD004-SEQ-TELEFONE   PIC S9(4) USAGE COMP.*/
        public IntBasis OD004_SEQ_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD004-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis OD004_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 OD004-IND-TELEFONE   PIC X(1).*/
        public StringBasis OD004_IND_TELEFONE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD004-STA-TELEFONE   PIC X(1).*/
        public StringBasis OD004_STA_TELEFONE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD004-COD-TELEFONE   PIC S9(9) USAGE COMP.*/
        public IntBasis OD004_COD_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD004-NUM-DDD        PIC S9(4) USAGE COMP.*/
        public IntBasis OD004_NUM_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD004-NUM-DDI        PIC S9(4) USAGE COMP.*/
        public IntBasis OD004_NUM_DDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD004-STA-CONTATO    PIC X(1).*/
        public StringBasis OD004_STA_CONTATO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}