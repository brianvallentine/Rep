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
    public class LBFPF991_REG_TRAILLER : VarBasis
    {
        /*"     10  RT-TIPO-REG                 PIC  X(001)*/
        public StringBasis RT_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  RT-NOME-EMPRESA             PIC  X(008)*/
        public StringBasis RT_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"     10  RT-QTDE-TIPO-0              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-1              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-2              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-3              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-4              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-5              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-6              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-7              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-8              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-9              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-A              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-B              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-C              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-D              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-E              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-F              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-G              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-H              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-I              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-J              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-W              PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_W { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  FILLER                      PIC  X(073)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "73", "X(073)"), @"");
        /*"     10  RT-QTDE-TOTAL               PIC  9(008)*/
        public IntBasis RT_QTDE_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  FILLER                      PIC  X(042)*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"");
    }
}