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
    public class BENEFPRO_DCLBENEFICIARIOS_PROP : VarBasis
    {
        /*"    10 BENEFPRO-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis BENEFPRO_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 BENEFPRO-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis BENEFPRO_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BENEFPRO-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis BENEFPRO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BENEFPRO-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis BENEFPRO_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 BENEFPRO-NUM-BENEFICIARIO  PIC S9(4) USAGE COMP.*/
        public IntBasis BENEFPRO_NUM_BENEFICIARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BENEFPRO-NOME-BENEFICIARIO  PIC X(40).*/
        public StringBasis BENEFPRO_NOME_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 BENEFPRO-GRAU-PARENTESCO  PIC X(10).*/
        public StringBasis BENEFPRO_GRAU_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BENEFPRO-PCT-PART-BENEFICIA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BENEFPRO_PCT_PART_BENEFICIA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BENEFPRO-COD-USUARIO  PIC X(8).*/
        public StringBasis BENEFPRO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 BENEFPRO-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis BENEFPRO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}