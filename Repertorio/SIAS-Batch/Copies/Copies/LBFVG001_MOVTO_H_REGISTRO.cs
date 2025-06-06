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
    public class LBFVG001_MOVTO_H_REGISTRO : VarBasis
    {
        /*"    10      MOVTO-H-TIPO-REG     PIC  X(001)*/
        public StringBasis MOVTO_H_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10      MOVTO-H-DATA-GERACAO*/
        public LBFVG001_MOVTO_H_DATA_GERACAO MOVTO_H_DATA_GERACAO { get; set; } = new LBFVG001_MOVTO_H_DATA_GERACAO();

        public IntBasis MOVTO_H_DATA_REFER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10      MOVTO-H-NUM-SEQ      PIC  9(006)*/
        public IntBasis MOVTO_H_NUM_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10      MOVTO-H-NUM-ARQUIVO  PIC  9(006)*/
        public IntBasis MOVTO_H_NUM_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10      MOVTO-H-TIPO-MOVTO   PIC  X(001)*/
        public StringBasis MOVTO_H_TIPO_MOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10      MOVTO-H-NOME-EMP     PIC  X(030)*/
        public StringBasis MOVTO_H_NOME_EMP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"    10      FILLER               PIC  X(440)*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "440", "X(440)"), @"");
        /*"*/
    }
}