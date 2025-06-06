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
    public class BI004_DCLBI_TIPO_PARCELM : VarBasis
    {
        /*"    10 BI004-COD-TIPO-PARCELAM  PIC S9(4) USAGE COMP.*/
        public IntBasis BI004_COD_TIPO_PARCELAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BI004-DTH-INI-VIGENCIA  PIC X(26).*/
        public StringBasis BI004_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 BI004-DTH-FIM-VIGENCIA  PIC X(26).*/
        public StringBasis BI004_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 BI004-DES-TIPO-PARCELAM  PIC X(60).*/
        public StringBasis BI004_DES_TIPO_PARCELAM { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 BI004-QTD-PARCELAS   PIC S9(4) USAGE COMP.*/
        public IntBasis BI004_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BI004-VLR-CFC-ADFRAC  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis BI004_VLR_CFC_ADFRAC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 BI004-PCT-JUROS      PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BI004_PCT_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BI004-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis BI004_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 BI004-COD-USUARIO    PIC X(20).*/
        public StringBasis BI004_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 BI004-COD-FORPG-PRIMEIRA  PIC S9(4) USAGE COMP.*/
        public IntBasis BI004_COD_FORPG_PRIMEIRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BI004-COD-FORPG-DEMAIS  PIC S9(4) USAGE COMP.*/
        public IntBasis BI004_COD_FORPG_DEMAIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}