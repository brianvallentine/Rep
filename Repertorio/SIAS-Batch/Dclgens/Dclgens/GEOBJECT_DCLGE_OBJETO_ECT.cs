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
    public class GEOBJECT_DCLGE_OBJETO_ECT : VarBasis
    {
        /*"    10 GEOBJECT-NUM-CEP     PIC S9(9) USAGE COMP.*/
        public IntBasis GEOBJECT_NUM_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEOBJECT-NOM-PROGRAMA       PIC X(8).*/
        public StringBasis GEOBJECT_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GEOBJECT-COD-FORMULARIO       PIC X(8).*/
        public StringBasis GEOBJECT_COD_FORMULARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GEOBJECT-STA-REGISTRO       PIC X(1).*/
        public StringBasis GEOBJECT_STA_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEOBJECT-DTH-TIMESTAMP       PIC X(26).*/
        public StringBasis GEOBJECT_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GEOBJECT-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis GEOBJECT_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEOBJECT-NUM-INI-POS-VERSO       PIC S9(4) USAGE COMP.*/
        public IntBasis GEOBJECT_NUM_INI_POS_VERSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEOBJECT-QTD-PESO-GRAMAS       PIC S9(2)V9(3) USAGE COMP-3.*/
        public DoubleBasis GEOBJECT_QTD_PESO_GRAMAS { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(2)V9(3)"), 3);
        /*"    10 GEOBJECT-VLR-DECLARADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GEOBJECT_VLR_DECLARADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GEOBJECT-COD-IDENT-OBJETO       PIC X(13).*/
        public StringBasis GEOBJECT_COD_IDENT_OBJETO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
        /*"    10 GEOBJECT-DES-OBJETO.*/
        public GEOBJECT_GEOBJECT_DES_OBJETO GEOBJECT_DES_OBJETO { get; set; } = new GEOBJECT_GEOBJECT_DES_OBJETO();

    }
}