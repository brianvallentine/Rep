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
    public class LBFCT011_REG_TRAILLER_STA : VarBasis
    {
        /*"     10  RT-TIPO-REG                  PIC  X(001)*/
        public StringBasis RT_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  RT-NOME-EMPRESA              PIC  X(008)*/
        public StringBasis RT_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"     10  RT-QTDE-TIPO-1               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-2               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-3               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-4               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-5               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-6               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-7               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-8               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-9               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TIPO-0               PIC  9(008)*/
        public IntBasis RT_QTDE_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RT-QTDE-TOTAL                PIC  9(008)*/
        public IntBasis RT_QTDE_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  FILLER                       PIC  X(003)*/
        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"*/
    }
}