using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBTB3201_TABELA_LIMITE_MINMAX_CCAT : VarBasis
    {
        /*"  10 FCCATE1 PIC X(30) VALUE '00030000 000    00500000 000 '*/
        public StringBasis FCCATE1 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00030000 000    00500000 000 ");
        /*"  10 FCCATE2 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FCCATE2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*"  10 FCCATE3 PIC X(30) VALUE '00005000 000    00000000 020 '*/
        public StringBasis FCCATE3 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00000000 020 ");
        /*"  10 FCCATE4 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FCCATE4 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*"  10 FCCATE5 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FCCATE5 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*"  10 FCCATE6 PIC X(30) VALUE '00005000 000    00150000 100 '*/
        public StringBasis FCCATE6 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00150000 100 ");
        /*"  10 FCCATE7 PIC X(30) VALUE '00005000 000    00500000 100 '*/
        public StringBasis FCCATE7 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00500000 100 ");
        /*"  10 FCCATE8 PIC X(30) VALUE '00005000 000    00500000 100 '*/
        public StringBasis FCCATE8 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00500000 100 ");
        /*"  10 FCCATE9 PIC X(30) VALUE '00002000 000    00050000 020 '*/
        public StringBasis FCCATE9 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00002000 000    00050000 020 ");
        /*"  10 FCCAT10 PIC X(30) VALUE '00000000 010    00000000 050 '*/
        public StringBasis FCCAT10_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 010    00000000 050 ");
        /*"  10 FCCAT11 PIC X(30) VALUE '00005000 000    00050000 020 '*/
        public StringBasis FCCAT11_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00050000 020 ");
        /*"  10 FCCAT12 PIC X(30) VALUE '00005000 000    00000000 020 '*/
        public StringBasis FCCAT12_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00000000 020 ");
        /*"  10 FCCAT13 PIC X(30) VALUE '00000000 010    00100000 100 '*/
        public StringBasis FCCAT13_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 010    00100000 100 ");
        /*"  10 FCCAT14 PIC X(30) VALUE '00002000 000    00000000 010 '*/
        public StringBasis FCCAT14_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00002000 000    00000000 010 ");
        /*"  10 FCCAT15 PIC X(30) VALUE '00000000 010    00000000 030 '*/
        public StringBasis FCCAT15_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 010    00000000 030 ");
        /*"  10 FCCAT16 PIC X(30) VALUE '00020000 000    00150000 100 '*/
        public StringBasis FCCAT16_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00020000 000    00150000 100 ");
        /*"  10 FCCAT17 PIC X(30) VALUE '00005000 000    01500000 000 '*/
        public StringBasis FCCAT17_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    01500000 000 ");
        /*"  10 FCCAT18 PIC X(30) VALUE '00005000 000    01500000 000 '*/
        public StringBasis FCCAT18_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    01500000 000 ");
        /*"  10 FCCAT19 PIC X(30) VALUE '00005000 000    01500000 000 '*/
        public StringBasis FCCAT19_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    01500000 000 ");
        /*"  10 FCCAT20 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FCCAT20_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*" 07   FILLER              REDEFINES TABELA-LIMITE-MINMAX-CCAT*/
    }
}