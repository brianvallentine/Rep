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
    public class LBTB3201_TABELA_FRANQUIAS : VarBasis
    {
        /*"  10 FQ01 PIC X(35) VALUE 'INC  : NAO HA                      '*/
        public StringBasis FQ01 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"INC  : NAO HA                      ");
        /*"  10 FQ02 PIC X(35) VALUE 'VAL  : NAO HA                      '*/
        public StringBasis FQ02 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"VAL  : NAO HA                      ");
        /*"  10 FQ03 PIC X(35) VALUE 'DAN  : 10 % COM MINIMO DE R$1000,00'*/
        public StringBasis FQ03 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"DAN  : 10 % COM MINIMO DE R$1000,00");
        /*"  10 FQ04 PIC X(35) VALUE 'APEDR: NAO HA                      '*/
        public StringBasis FQ04 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"APEDR: NAO HA                      ");
        /*"  10 FQ05 PIC X(35) VALUE 'APED : NAO HA                      '*/
        public StringBasis FQ05 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"APED : NAO HA                      ");
        /*"  10 FQ06 PIC X(35) VALUE 'RCLOT: 10 % COM MINIMO DE R$300,00 '*/
        public StringBasis FQ06 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"RCLOT: 10 % COM MINIMO DE R$300,00 ");
        /*"  10 FQ07 PIC X(35) VALUE 'RINT : 7,5% COM MINIMO DE R$600,00'*/
        public StringBasis FQ07 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"RINT : 7,5% COM MINIMO DE R$600,00");
        /*"  10 FQ08 PIC X(35) VALUE 'RMAOS: 7,5% COM MINIMO DE R$600,00'*/
        public StringBasis FQ08 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"RMAOS: 7,5% COM MINIMO DE R$600,00");
        /*"  10 FQ09 PIC X(35) VALUE 'RMMUT: 10 % COM MINIMO DE R$1000,00'*/
        public StringBasis FQ09 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"RMMUT: 10 % COM MINIMO DE R$1000,00");
        /*"  10 FQ10 PIC X(35) VALUE 'VENDV: 10 % COM MINIMO DE R$1000,00'*/
        public StringBasis FQ10 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"VENDV: 10 % COM MINIMO DE R$1000,00");
        /*"  10 FQ11 PIC X(35) VALUE 'DPALZ:  5 DIAS                     '*/
        public StringBasis FQ11 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"DPALZ:  5 DIAS                     ");
        /*"  10 FQ12 PIC X(35) VALUE 'PALUG: NAO HA                      '*/
        public StringBasis FQ12 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"PALUG: NAO HA                      ");
        /*"  10 FQ13 PIC X(35) VALUE 'TUMUL: 10 % COM MINIMO DE R$1000,00'*/
        public StringBasis FQ13 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"TUMUL: 10 % COM MINIMO DE R$1000,00");
        /*"  10 FQ14 PIC X(35) VALUE 'QVIDR: R$200,00                    '*/
        public StringBasis FQ14 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"QVIDR: R$200,00                    ");
        /*"  10 FQ15 PIC X(35) VALUE 'DSPKL: 10 % COM MINIMO DE R$1000,00'*/
        public StringBasis FQ15 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"DSPKL: 10 % COM MINIMO DE R$1000,00");
        /*"  10 FQ16 PIC X(35) VALUE 'RCVEI: 10 % COM MINIMO DE R$1000,00'*/
        public StringBasis FQ16 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"RCVEI: 10 % COM MINIMO DE R$1000,00");
        /*"  10 FQ17 PIC X(35) VALUE 'EQ.ME: 10 % COM MINIMO DE R$1000,00'*/
        public StringBasis FQ17 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"EQ.ME: 10 % COM MINIMO DE R$1000,00");
        /*"  10 FQ18 PIC X(35) VALUE 'EQ.ME: 10 % COM MINIMO DE R$1000,00'*/
        public StringBasis FQ18 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"EQ.ME: 10 % COM MINIMO DE R$1000,00");
        /*"  10 FQ19 PIC X(35) VALUE 'EQ.ME: 10 % COM MINIMO DE R$1000,00'*/
        public StringBasis FQ19 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"EQ.ME: 10 % COM MINIMO DE R$1000,00");
        /*"  10 FQ20 PIC X(35) VALUE '                                   '*/
        public StringBasis FQ20 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"                                   ");
        /*" 07   TABELA-FRANQUIAS-R REDEFINES TABELA-FRANQUIAS*/
    }
}