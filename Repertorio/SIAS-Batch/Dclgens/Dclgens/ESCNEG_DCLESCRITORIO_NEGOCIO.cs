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
    public class ESCNEG_DCLESCRITORIO_NEGOCIO : VarBasis
    {
        /*"    10 COD-ESCNEG           PIC S9(4) USAGE COMP.*/
        public IntBasis COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 REGIAO-ESCNEG        PIC X(40).*/
        public StringBasis REGIAO_ESCNEG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 LOCAL-SEDE           PIC X(30).*/
        public StringBasis LOCAL_SEDE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 COD-COREG            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_COREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-FONTE            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}