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
    public class LBTB3201_TABELA_LIMITE_MINMAX : VarBasis
    {
        /*"  10 FILLE1 PIC X(30) VALUE '00030000 000    01000000 000 '*/
        public StringBasis FILLE1_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00030000 000    01000000 000 ");
        /*"  10 FILLE2 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FILLE2_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*"  10 FILLE3 PIC X(30) VALUE '00005000 000    00000000 020 '*/
        public StringBasis FILLE3_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00000000 020 ");
        /*"  10 FILLE4 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FILLE4_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*"  10 FILLE5 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FILLE5_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*"  10 FILLE6 PIC X(30) VALUE '00005000 000    00300000 100 '*/
        public StringBasis FILLE6_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00300000 100 ");
        /*"  10 FILLE7 PIC X(30) VALUE '00005000 000    00500000 100 '*/
        public StringBasis FILLE7_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00500000 100 ");
        /*"  10 FILLE8 PIC X(30) VALUE '00005000 000    00500000 100 '*/
        public StringBasis FILLE8_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00500000 100 ");
        /*"  10 FILLE9 PIC X(30) VALUE '00002000 000    00050000 020 '*/
        public StringBasis FILLE9_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00002000 000    00050000 020 ");
        /*"  10 FILL10 PIC X(30) VALUE '00000000 010    00000000 050 '*/
        public StringBasis FILL10_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 010    00000000 050 ");
        /*"  10 FILL11 PIC X(30) VALUE '00005000 000    00060000 020 '*/
        public StringBasis FILL11_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00060000 020 ");
        /*"  10 FILL12 PIC X(30) VALUE '00005000 000    00000000 020 '*/
        public StringBasis FILL12_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00005000 000    00000000 020 ");
        /*"  10 FILL13 PIC X(30) VALUE '00000000 010    00500000 100 '*/
        public StringBasis FILL13_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 010    00500000 100 ");
        /*"  10 FILL14 PIC X(30) VALUE '00002000 000    00175000 010 '*/
        public StringBasis FILL14_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00002000 000    00175000 010 ");
        /*"  10 FILL15 PIC X(30) VALUE '00000000 010    00500000 030 '*/
        public StringBasis FILL15_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 010    00500000 030 ");
        /*"  10 FILL16 PIC X(30) VALUE '00020000 000    00150000 100 '*/
        public StringBasis FILL16_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00020000 000    00150000 100 ");
        /*"  10 FILL17 PIC X(30) VALUE '00002000 000    00000000 100 '*/
        public StringBasis FILL17_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00002000 000    00000000 100 ");
        /*"  10 FILL18 PIC X(30) VALUE '00002000 000    00500000 100 '*/
        public StringBasis FILL18_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00002000 000    00500000 100 ");
        /*"  10 FILL19 PIC X(30) VALUE '00002000 000    00000000 100 '*/
        public StringBasis FILL19_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00002000 000    00000000 100 ");
        /*"  10 FILL20 PIC X(30) VALUE '00000000 000    00000000 000 '*/
        public StringBasis FILL20_2 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"00000000 000    00000000 000 ");
        /*" 07   TABELA-LIMITE-MINMAX-R REDEFINES TABELA-LIMITE-MINMAX*/
    }
}