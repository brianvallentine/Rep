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
    public class MRBENSEG_DCLMR_BENS_SEGURADO : VarBasis
    {
        /*"    10 MRBENSEG-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis MRBENSEG_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRBENSEG-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRBENSEG_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRBENSEG-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis MRBENSEG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRBENSEG-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis MRBENSEG_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRBENSEG-NUM-BEM-SEGURADO  PIC S9(4) USAGE COMP.*/
        public IntBasis MRBENSEG_NUM_BEM_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRBENSEG-QTD-BEM-SEGURADO  PIC S9(4) USAGE COMP.*/
        public IntBasis MRBENSEG_QTD_BEM_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRBENSEG-DES-OBJ-SEGURADO  PIC X(20).*/
        public StringBasis MRBENSEG_DES_OBJ_SEGURADO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 MRBENSEG-DES-MARCA-BEM-SEG  PIC X(20).*/
        public StringBasis MRBENSEG_DES_MARCA_BEM_SEG { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 MRBENSEG-DES-BEM-SEGURADO.*/
        public MRBENSEG_MRBENSEG_DES_BEM_SEGURADO MRBENSEG_DES_BEM_SEGURADO { get; set; } = new MRBENSEG_MRBENSEG_DES_BEM_SEGURADO();

        public DoubleBasis MRBENSEG_VLR_BEM_SEGURADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MRBENSEG-STA-BEM-SEGURADO  PIC X(1).*/
        public StringBasis MRBENSEG_STA_BEM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRBENSEG-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MRBENSEG_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MRBENSEG-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis MRBENSEG_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRBENSEG-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis MRBENSEG_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}