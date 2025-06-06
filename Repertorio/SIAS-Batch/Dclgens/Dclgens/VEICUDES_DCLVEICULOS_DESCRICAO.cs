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
    public class VEICUDES_DCLVEICULOS_DESCRICAO : VarBasis
    {
        /*"    10 VEICUDES-COD-TABELA  PIC S9(4) USAGE COMP.*/
        public IntBasis VEICUDES_COD_TABELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VEICUDES-TIPO-VEICULO  PIC S9(4) USAGE COMP.*/
        public IntBasis VEICUDES_TIPO_VEICULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VEICUDES-COD-FABRICANTE  PIC S9(4) USAGE COMP.*/
        public IntBasis VEICUDES_COD_FABRICANTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VEICUDES-COD-VEICULO  PIC S9(9) USAGE COMP.*/
        public IntBasis VEICUDES_COD_VEICULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VEICUDES-DESCR-VEICULO  PIC X(40).*/
        public StringBasis VEICUDES_DESCR_VEICULO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 VEICUDES-QTD-COD-RELACIONA  PIC S9(4) USAGE COMP.*/
        public IntBasis VEICUDES_QTD_COD_RELACIONA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VEICUDES-IDE-VEIC-FORA-FABR  PIC X(1).*/
        public StringBasis VEICUDES_IDE_VEIC_FORA_FABR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VEICUDES-COD-CARRO   PIC S9(9) USAGE COMP.*/
        public IntBasis VEICUDES_COD_CARRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VEICUDES-DATA-ULT-MANUTEN  PIC X(10).*/
        public StringBasis VEICUDES_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VEICUDES-HORA-ULT-MANUTEN  PIC X(8).*/
        public StringBasis VEICUDES_HORA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VEICUDES-TIPO-ULT-MANUTEN  PIC X(1).*/
        public StringBasis VEICUDES_TIPO_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VEICUDES-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis VEICUDES_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VEICUDES-TIMESTAMP   PIC X(26).*/
        public StringBasis VEICUDES_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VEICUDES-QTD-PASSAGEIROS  PIC S9(4) USAGE COMP.*/
        public IntBasis VEICUDES_QTD_PASSAGEIROS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VEICUDES-VERSAO      PIC S9(9) USAGE COMP.*/
        public IntBasis VEICUDES_VERSAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}