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
    public class _REDEF_RSGEWDTA_FILLER_0 : VarBasis
    {
        /*"    10      WS-CDTE-ANO         PIC  9(004)*/
        public IntBasis WS_CDTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    10      WS-CDTE-MES         PIC  9(002)*/
        public IntBasis WS_CDTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10      WS-CDTE-DIA         PIC  9(002)*/
        public IntBasis WS_CDTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10      WS-CDTE-HORA        PIC  9(002)*/
        public IntBasis WS_CDTE_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10      WS-CDTE-MIN         PIC  9(002)*/
        public IntBasis WS_CDTE_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10      WS-CDTE-SEG         PIC  9(002)*/
        public IntBasis WS_CDTE_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10      WS-CDTE-DECSEG      PIC  9(002)*/
        public IntBasis WS_CDTE_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10      WS-CDTE-GREEN       PIC  X(001)*/
        public StringBasis WS_CDTE_GREEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10      WS-CDTE-GHORA       PIC  9(002)*/
        public IntBasis WS_CDTE_GHORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10      WS-CDTE-GMIN        PIC  9(002)*/
        public IntBasis WS_CDTE_GMIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"   05       WS-CURRENT-EDIT     PIC  X(022)      VALUE SPACES*/

        public _REDEF_RSGEWDTA_FILLER_0()
        {
            WS_CDTE_ANO.ValueChanged += OnValueChanged;
            WS_CDTE_MES.ValueChanged += OnValueChanged;
            WS_CDTE_DIA.ValueChanged += OnValueChanged;
            WS_CDTE_HORA.ValueChanged += OnValueChanged;
            WS_CDTE_MIN.ValueChanged += OnValueChanged;
            WS_CDTE_SEG.ValueChanged += OnValueChanged;
            WS_CDTE_DECSEG.ValueChanged += OnValueChanged;
            WS_CDTE_GREEN.ValueChanged += OnValueChanged;
            WS_CDTE_GHORA.ValueChanged += OnValueChanged;
            WS_CDTE_GMIN.ValueChanged += OnValueChanged;
        }

    }
}