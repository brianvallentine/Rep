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
    public class PFACOPRO_DCLPF_ACOMP_PROPOSTAS : VarBasis
    {
        /*"    10 PFACOPRO-NUM-PROPOSTA-SIVPF  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PFACOPRO_NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PFACOPRO-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PFACOPRO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PFACOPRO-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis PFACOPRO_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PFACOPRO-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PFACOPRO_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PFACOPRO-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis PFACOPRO_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PFACOPRO-DTH-INCLUSAO  PIC X(10).*/
        public StringBasis PFACOPRO_DTH_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PFACOPRO-COD-USUARIO  PIC X(8).*/
        public StringBasis PFACOPRO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PFACOPRO-TIMESTAMP   PIC X(26).*/
        public StringBasis PFACOPRO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}