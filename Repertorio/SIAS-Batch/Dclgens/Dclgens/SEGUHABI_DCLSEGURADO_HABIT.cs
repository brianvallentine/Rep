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
    public class SEGUHABI_DCLSEGURADO_HABIT : VarBasis
    {
        /*"    10 SEGUHABI-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGUHABI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGUHABI-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGUHABI_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGUHABI-OPERACAO    PIC S9(4) USAGE COMP.*/
        public IntBasis SEGUHABI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGUHABI-PONTO-VENDA  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGUHABI_PONTO_VENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGUHABI-NUM-CONTRATO  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGUHABI_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGUHABI-OCORR-SEGUR  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGUHABI_OCORR_SEGUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGUHABI-NOME-SEGURADO  PIC X(40).*/
        public StringBasis SEGUHABI_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SEGUHABI-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SEGUHABI_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SEGUHABI-SITUACAO    PIC X(1).*/
        public StringBasis SEGUHABI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGUHABI-DATA-SIT-INI  PIC X(10).*/
        public StringBasis SEGUHABI_DATA_SIT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGUHABI-USUARIO     PIC X(8).*/
        public StringBasis SEGUHABI_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SEGUHABI-TIMESTAMP   PIC X(26).*/
        public StringBasis SEGUHABI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SEGUHABI-DATA-NASC   PIC X(10).*/
        public StringBasis SEGUHABI_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGUHABI-RENDA-PACTUADA  PIC S9(5)V9(2) USAGE COMP-3.*/
        public DoubleBasis SEGUHABI_RENDA_PACTUADA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(5)V9(2)"), 2);
        /*"    10 SEGUHABI-COMPROMET-RENDA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SEGUHABI_COMPROMET_RENDA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SEGUHABI-DATA-SIT-FIM  PIC X(10).*/
        public StringBasis SEGUHABI_DATA_SIT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGUHABI-SEXO        PIC X(1).*/
        public StringBasis SEGUHABI_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}