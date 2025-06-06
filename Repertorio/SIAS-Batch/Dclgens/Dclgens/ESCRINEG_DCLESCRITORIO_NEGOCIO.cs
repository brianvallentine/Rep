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
    public class ESCRINEG_DCLESCRITORIO_NEGOCIO : VarBasis
    {
        /*"    10 ESCRINEG-COD-ESCNEG  PIC S9(4) USAGE COMP.*/
        public IntBasis ESCRINEG_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESCRINEG-REGIAO-ESCNEG  PIC X(40).*/
        public StringBasis ESCRINEG_REGIAO_ESCNEG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 ESCRINEG-LOCAL-SEDE  PIC X(30).*/
        public StringBasis ESCRINEG_LOCAL_SEDE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 ESCRINEG-COD-COREG   PIC S9(4) USAGE COMP.*/
        public IntBasis ESCRINEG_COD_COREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESCRINEG-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis ESCRINEG_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESCRINEG-NOME-ABREV-ESCNEG  PIC X(15).*/
        public StringBasis ESCRINEG_NOME_ABREV_ESCNEG { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"*/
    }
}