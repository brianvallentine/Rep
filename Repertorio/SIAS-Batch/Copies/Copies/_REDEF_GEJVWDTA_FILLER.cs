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
    public class _REDEF_GEJVWDTA_FILLER : VarBasis
    {
        /*"    10      WS-WHEN-ANO         PIC  9(004).*/
        public IntBasis WS_WHEN_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        /*"    10      WS-WHEN-MES         PIC  9(002).*/
        public IntBasis WS_WHEN_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"    10      WS-WHEN-DIA         PIC  9(002).*/
        public IntBasis WS_WHEN_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"    10      WS-WHEN-HORA        PIC  9(002).*/
        public IntBasis WS_WHEN_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"    10      WS-WHEN-MIN         PIC  9(002).*/
        public IntBasis WS_WHEN_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"    10      WS-WHEN-SEG         PIC  9(002).*/
        public IntBasis WS_WHEN_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"    10      WS-WHEN-DECSEG      PIC  9(002).*/
        public IntBasis WS_WHEN_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"    10      WS-WHEN-GREEN       PIC  X(001).*/
        public StringBasis WS_WHEN_GREEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"    10      WS-WHEN-GHORA       PIC  9(002).*/
        public IntBasis WS_WHEN_GHORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"    10      WS-WHEN-GMIN        PIC  9(002).*/
        public IntBasis WS_WHEN_GMIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"   05       WS-COMPILED-EDIT    PIC  X(022)      VALUE SPACES.*/

        public _REDEF_GEJVWDTA_FILLER()
        {
            WS_WHEN_ANO.ValueChanged += OnValueChanged;
            WS_WHEN_MES.ValueChanged += OnValueChanged;
            WS_WHEN_DIA.ValueChanged += OnValueChanged;
            WS_WHEN_HORA.ValueChanged += OnValueChanged;
            WS_WHEN_MIN.ValueChanged += OnValueChanged;
            WS_WHEN_SEG.ValueChanged += OnValueChanged;
            WS_WHEN_DECSEG.ValueChanged += OnValueChanged;
            WS_WHEN_GREEN.ValueChanged += OnValueChanged;
            WS_WHEN_GHORA.ValueChanged += OnValueChanged;
            WS_WHEN_GMIN.ValueChanged += OnValueChanged;
        }

    }
}