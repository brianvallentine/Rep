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
    public class LXFPF990_REG_HEADER : VarBasis
    {
        /*"     10  RH-TIPO-REG                 PIC  X(001)*/
        public StringBasis RH_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  RH-NOME                     PIC  X(008)*/
        public StringBasis RH_NOME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"     10  RH-DATA-GERACAO             PIC  9(008)*/
        public IntBasis RH_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RH-SIST-ORIGEM              PIC  9(001)*/
        public IntBasis RH_SIST_ORIGEM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  RH-SIST-DESTINO             PIC  9(001)*/
        public IntBasis RH_SIST_DESTINO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  RH-NSAS                     PIC  9(006)*/
        public IntBasis RH_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"     10  RH-TIPO-ARQUIVO             PIC  9(001)*/
        public IntBasis RH_TIPO_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  RH-FILLER1                  PIC  X(003)*/
        public StringBasis RH_FILLER1 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"     10  RH-COD-EMPRESA              PIC  9(002)*/
        public IntBasis RH_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10  RH-NOME-EMPRESA             PIC  X(040)*/
        public StringBasis RH_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"     10  RH-FILLER2                  PIC  X(229)*/
        public StringBasis RH_FILLER2 { get; set; } = new StringBasis(new PIC("X", "229", "X(229)"), @"");
        /*"*/
    }
}