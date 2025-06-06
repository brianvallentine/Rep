using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LXFPF024_R24_MATRIZ : VarBasis
    {
        /*"          20 R24-IND-SUBS-DINAMICA     PIC  X(001)*/
        public StringBasis R24_IND_SUBS_DINAMICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"          20 R24-TP-SUBS-DINAMICA      PIC  X(015)*/
        public StringBasis R24_TP_SUBS_DINAMICA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"          20 R24-VLR-PRM-BRUTO         PIC  9(014)V99*/
        public DoubleBasis R24_VLR_PRM_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "14", "9(014)V99"), 2);
        /*"          20 R24-VERSAO-MATRIZ         PIC  9(002)*/
        public IntBasis R24_VERSAO_MATRIZ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"          20 R24-PERCENTUAL-APLICADO   PIC  9(003)*/
        public IntBasis R24_PERCENTUAL_APLICADO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"          20 R24-FILLER                PIC  X(006)*/
        public StringBasis R24_FILLER { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
        /*"       15 FILLER                       PIC  X(027)*/

        public LXFPF024_R24_MATRIZ()
        {
            R24_IND_SUBS_DINAMICA.ValueChanged += OnValueChanged;
            R24_TP_SUBS_DINAMICA.ValueChanged += OnValueChanged;
            R24_VLR_PRM_BRUTO.ValueChanged += OnValueChanged;
            R24_VERSAO_MATRIZ.ValueChanged += OnValueChanged;
            R24_PERCENTUAL_APLICADO.ValueChanged += OnValueChanged;
            R24_FILLER.ValueChanged += OnValueChanged;
        }

    }
}