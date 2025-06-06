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
    public class MR023_DCLMR_PROP_ITEM_COND : VarBasis
    {
        /*"    10 MR023-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis MR023_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR023-NUM-PROPOSTA   PIC S9(9) USAGE COMP.*/
        public IntBasis MR023_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR023-NUM-ITEM       PIC S9(9) USAGE COMP.*/
        public IntBasis MR023_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR023-NUM-TP-CONDOMINIO  PIC S9(4) USAGE COMP.*/
        public IntBasis MR023_NUM_TP_CONDOMINIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR023-NUM-PAVIMENTOS  PIC S9(4) USAGE COMP.*/
        public IntBasis MR023_NUM_PAVIMENTOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR023-NUM-ELEVADORES  PIC S9(4) USAGE COMP.*/
        public IntBasis MR023_NUM_ELEVADORES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR023-NUM-PORTAO-ELETRON  PIC S9(4) USAGE COMP.*/
        public IntBasis MR023_NUM_PORTAO_ELETRON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR023-NUM-VAGAS      PIC S9(4) USAGE COMP.*/
        public IntBasis MR023_NUM_VAGAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR023-NUM-UNID-AUTONOMA  PIC S9(4) USAGE COMP.*/
        public IntBasis MR023_NUM_UNID_AUTONOMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR023-PCT-DESC-COBERTURA  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR023_PCT_DESC_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR023-PCT-BONUS-RENOVCAO  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR023_PCT_BONUS_RENOVCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR023-PCT-DESC-PROMOCAO  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR023_PCT_DESC_PROMOCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR023-PCT-DESC-CORRETOR  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR023_PCT_DESC_CORRETOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR023-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis MR023_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MR023-COD-BENEFICIARIO  PIC S9(9) USAGE COMP.*/
        public IntBasis MR023_COD_BENEFICIARIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR023-DES-CLAUSULA-BENEF.*/
        public MR023_MR023_DES_CLAUSULA_BENEF MR023_DES_CLAUSULA_BENEF { get; set; } = new MR023_MR023_DES_CLAUSULA_BENEF();

    }
}