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
    public class PROPFIDH_DCLHIST_PROP_FIDELIZ : VarBasis
    {
        /*"    10 PROPFIDH-NUM-IDENTIFICACAO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPFIDH_NUM_IDENTIFICACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPFIDH-DATA-SITUACAO       PIC X(10).*/
        public StringBasis PROPFIDH_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPFIDH-NSAS-SIVPF  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPFIDH_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPFIDH-NSL         PIC S9(9) USAGE COMP.*/
        public IntBasis PROPFIDH_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPFIDH-SIT-PROPOSTA       PIC X(3).*/
        public StringBasis PROPFIDH_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 PROPFIDH-SIT-COBRANCA-SIVPF       PIC X(3).*/
        public StringBasis PROPFIDH_SIT_COBRANCA_SIVPF { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 PROPFIDH-SIT-MOTIVO-SIVPF       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPFIDH_SIT_MOTIVO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPFIDH-COD-EMPRESA-SIVPF       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPFIDH_COD_EMPRESA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPFIDH-COD-PRODUTO-SIVPF       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPFIDH_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}