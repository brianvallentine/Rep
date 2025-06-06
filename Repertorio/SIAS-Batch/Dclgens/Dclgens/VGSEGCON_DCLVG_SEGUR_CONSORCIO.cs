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
    public class VGSEGCON_DCLVG_SEGUR_CONSORCIO : VarBasis
    {
        /*"    10 VGSEGCON-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGSEGCON_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGSEGCON-NUM-GRUPO-CONSOR  PIC S9(9) USAGE COMP.*/
        public IntBasis VGSEGCON_NUM_GRUPO_CONSOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VGSEGCON-NUM-COTA-CONSOR  PIC S9(9) USAGE COMP.*/
        public IntBasis VGSEGCON_NUM_COTA_CONSOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VGSEGCON-DTH-ADESAO  PIC X(10).*/
        public StringBasis VGSEGCON_DTH_ADESAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGSEGCON-COD-USUARIO  PIC X(8).*/
        public StringBasis VGSEGCON_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGSEGCON-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis VGSEGCON_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VGSEGCON-NUM-CONTR-CONSOR  PIC S9(9) USAGE COMP.*/
        public IntBasis VGSEGCON_NUM_CONTR_CONSOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}