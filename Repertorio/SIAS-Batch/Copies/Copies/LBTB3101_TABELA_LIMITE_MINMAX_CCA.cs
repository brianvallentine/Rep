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
    public class LBTB3101_TABELA_LIMITE_MINMAX_CCA : VarBasis
    {
        /*"  10 FCCAE1 PIC X(30) VALUE '00030000 000    00300000 000 '*/
        public StringBasis FCCAE1 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00030000 000    00300000 000 ");
        /*"  10 FCCAE2 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FCCAE2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*"  10 FCCAE3 PIC X(30) VALUE '00005000 000    00000000 020 '*/
        public StringBasis FCCAE3 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00000000 020 ");
        /*"  10 FCCAE4 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FCCAE4 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*"  10 FCCAE5 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FCCAE5 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*"  10 FCCAE6 PIC X(30) VALUE '00005000 000    00150000 100 '*/
        public StringBasis FCCAE6 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00150000 100 ");
        /*"  10 FCCAE7 PIC X(30) VALUE '00005000 000    00120000 100 '*/
        public StringBasis FCCAE7 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00120000 100 ");
        /*"  10 FCCAE8 PIC X(30) VALUE '00005000 000    00120000 100 '*/
        public StringBasis FCCAE8 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00120000 100 ");
        /*"  10 FCCAE9 PIC X(30) VALUE '00002000 000    00050000 050 '*/
        public StringBasis FCCAE9 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00002000 000    00050000 050 ");
        /*"  10 FCCA10 PIC X(30) VALUE '00000000 010    00000000 050 '*/
        public StringBasis FCCA10_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 010    00000000 050 ");
        /*"  10 FCCA11 PIC X(30) VALUE '00005000 000    00050000 020 '*/
        public StringBasis FCCA11_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00050000 020 ");
        /*"  10 FCCA12 PIC X(30) VALUE '00005000 000    00000000 020 '*/
        public StringBasis FCCA12_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00000000 020 ");
        /*"  10 FCCA13 PIC X(30) VALUE '00000000 010    00100000 100 '*/
        public StringBasis FCCA13_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 010    00100000 100 ");
        /*"  10 FCCA14 PIC X(30) VALUE '00002000 000    00000000 010 '*/
        public StringBasis FCCA14_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00002000 000    00000000 010 ");
        /*"  10 FCCA15 PIC X(30) VALUE '00000000 010    00000000 030 '*/
        public StringBasis FCCA15_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 010    00000000 030 ");
        /*"  10 FCCA16 PIC X(30) VALUE '00020000 000    00150000 100 '*/
        public StringBasis FCCA16_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00020000 000    00150000 100 ");
        /*"  10 FCCA17 PIC X(30) VALUE '00005000 000    01500000 000 '*/
        public StringBasis FCCA17_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    01500000 000 ");
        /*"  10 FCCA18 PIC X(30) VALUE '00005000 000    01500000 000 '*/
        public StringBasis FCCA18_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    01500000 000 ");
        /*"  10 FCCA19 PIC X(30) VALUE '00005000 000    01500000 000 '*/
        public StringBasis FCCA19_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    01500000 000 ");
        /*"  10 FCCA20 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FCCA20_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*" 07   FILLER                 REDEFINES TABELA-LIMITE-MINMAX-CCA*/
    }
}