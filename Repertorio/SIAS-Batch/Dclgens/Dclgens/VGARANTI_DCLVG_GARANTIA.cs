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
    public class VGARANTI_DCLVG_GARANTIA : VarBasis
    {
        /*"    10 VGARANTI-NUM-GARANTIA       PIC S9(4) USAGE COMP.*/
        public IntBasis VGARANTI_NUM_GARANTIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGARANTI-DES-GARANTIA       PIC X(120).*/
        public StringBasis VGARANTI_DES_GARANTIA { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
        /*"    10 VGARANTI-STA-GARANTIA       PIC X(1).*/
        public StringBasis VGARANTI_STA_GARANTIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGARANTI-DTH-TIMESTAMP       PIC X(26).*/
        public StringBasis VGARANTI_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VGARANTI-COD-TIPO-GARANTIA       PIC X(1).*/
        public StringBasis VGARANTI_COD_TIPO_GARANTIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGARANTI-NUM-RAMO    PIC S9(4) USAGE COMP.*/
        public IntBasis VGARANTI_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGARANTI-NUM-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis VGARANTI_NUM_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGARANTI-NUM-ACESSORIO       PIC S9(4) USAGE COMP.*/
        public IntBasis VGARANTI_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}