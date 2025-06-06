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
    public class _REDEF_LXFPF024_R24_INFO_R2 : VarBasis
    {
        /*"       15 FILLER                       PIC  X(042)*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"");
        /*"       15 R24-COD-CBO-CLIENTE          PIC  9(010)*/
        public IntBasis R24_COD_CBO_CLIENTE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"       15 R24-COD-CBO-COMERCIAL        PIC  9(010)*/
        public IntBasis R24_COD_CBO_COMERCIAL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"       15 R24-INFO-TEM-DEPEND          PIC  X(001)*/
        public StringBasis R24_INFO_TEM_DEPEND { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"       15 R24-RESP-PERG-PRO            PIC  X(001)*/
        public StringBasis R24_RESP_PERG_PRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"       15 R24-NUM-CGCCPF-TITULAR       PIC  9(014)*/
        public IntBasis R24_NUM_CGCCPF_TITULAR { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"       15 R24-NOM-TITULAR              PIC  X(040)*/
        public StringBasis R24_NOM_TITULAR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"       15 R24-DTA-NASC-RESPONSAVEL     PIC  X(008)*/
        public StringBasis R24_DTA_NASC_RESPONSAVEL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"       15 R24-IND-SEXO-RESPONSAVEL     PIC  X(001)*/
        public StringBasis R24_IND_SEXO_RESPONSAVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"       15 FILLER                       PIC  X(051)*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"");
        /*"       15 R24-ORIG-PARCEIROS           PIC  9(004)*/
        public IntBasis R24_ORIG_PARCEIROS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"       15 R24-MATRIZ*/
        public LXFPF024_R24_MATRIZ R24_MATRIZ { get; set; } = new LXFPF024_R24_MATRIZ();

        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
        /*"       15 R24-COD-TIPO-ASSISTENCIA     PIC  X(004)*/
        public StringBasis R24_COD_TIPO_ASSISTENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"       15 FILLER                       PIC  X(027)*/
        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
        /*"*/

        public _REDEF_LXFPF024_R24_INFO_R2()
        {
            FILLER_1.ValueChanged += OnValueChanged;
            R24_COD_CBO_CLIENTE.ValueChanged += OnValueChanged;
            R24_COD_CBO_COMERCIAL.ValueChanged += OnValueChanged;
            R24_INFO_TEM_DEPEND.ValueChanged += OnValueChanged;
            R24_RESP_PERG_PRO.ValueChanged += OnValueChanged;
            R24_NUM_CGCCPF_TITULAR.ValueChanged += OnValueChanged;
            R24_NOM_TITULAR.ValueChanged += OnValueChanged;
            R24_DTA_NASC_RESPONSAVEL.ValueChanged += OnValueChanged;
            R24_IND_SEXO_RESPONSAVEL.ValueChanged += OnValueChanged;
            FILLER_2.ValueChanged += OnValueChanged;
            R24_ORIG_PARCEIROS.ValueChanged += OnValueChanged;
            R24_MATRIZ.ValueChanged += OnValueChanged;
            FILLER_3.ValueChanged += OnValueChanged;
            R24_COD_TIPO_ASSISTENCIA.ValueChanged += OnValueChanged;
            FILLER_4.ValueChanged += OnValueChanged;
        }

    }
}