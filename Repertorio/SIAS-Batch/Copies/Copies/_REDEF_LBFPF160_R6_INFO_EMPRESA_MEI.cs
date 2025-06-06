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
    public class _REDEF_LBFPF160_R6_INFO_EMPRESA_MEI : VarBasis
    {
        /*"    15       R6-RAZAO-SOCIAL-MEI          PIC  X(040)*/
        public StringBasis R6_RAZAO_SOCIAL_MEI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"    15       R6-DATA-CONSTITUICAO-MEI     PIC  9(008)*/
        public IntBasis R6_DATA_CONSTITUICAO_MEI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    15       R6-COD-PORTE-MEI             PIC  9(004)*/
        public IntBasis R6_COD_PORTE_MEI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    15       R6-CNAE-MEI                  PIC  9(010)*/
        public IntBasis R6_CNAE_MEI { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"    15       R6-DAT-FAT-ANUAL-MEI         PIC  9(008)*/
        public IntBasis R6_DAT_FAT_ANUAL_MEI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    15       R6-VAL-FAT-ANUAL-MEI         PIC  9(013)V99*/
        public DoubleBasis R6_VAL_FAT_ANUAL_MEI { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"    15       R6-CNPJ-MEI                  PIC  9(015)*/
        public IntBasis R6_CNPJ_MEI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"    15       R6-DDD-COMERCIAL             PIC  9(003)*/
        public IntBasis R6_DDD_COMERCIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    15       R6-TELEFONE-COMERCIAL        PIC  9(009)*/
        public IntBasis R6_TELEFONE_COMERCIAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    15       R6-EMAIL                     PIC  X(040)*/
        public StringBasis R6_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"    15       R6-TIPO-ENDERECO             PIC  9(001)*/
        public IntBasis R6_TIPO_ENDERECO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    15       R6-ENDERECO                  PIC  X(050)*/
        public StringBasis R6_ENDERECO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*"    15       R6-BAIRRO                    PIC  X(030)*/
        public StringBasis R6_BAIRRO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"    15       R6-CIDADE                    PIC  X(035)*/
        public StringBasis R6_CIDADE { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
        /*"    15       R6-UF                        PIC  X(002)*/
        public StringBasis R6_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"    15       R6-CEP                       PIC  9(008)*/
        public IntBasis R6_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    15       FILLER                       PIC  X(005)*/
        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"*/

        public _REDEF_LBFPF160_R6_INFO_EMPRESA_MEI()
        {
            R6_RAZAO_SOCIAL_MEI.ValueChanged += OnValueChanged;
            R6_DATA_CONSTITUICAO_MEI.ValueChanged += OnValueChanged;
            R6_COD_PORTE_MEI.ValueChanged += OnValueChanged;
            R6_CNAE_MEI.ValueChanged += OnValueChanged;
            R6_DAT_FAT_ANUAL_MEI.ValueChanged += OnValueChanged;
            R6_VAL_FAT_ANUAL_MEI.ValueChanged += OnValueChanged;
            R6_CNPJ_MEI.ValueChanged += OnValueChanged;
            R6_DDD_COMERCIAL.ValueChanged += OnValueChanged;
            R6_TELEFONE_COMERCIAL.ValueChanged += OnValueChanged;
            R6_EMAIL.ValueChanged += OnValueChanged;
            R6_TIPO_ENDERECO.ValueChanged += OnValueChanged;
            R6_ENDERECO.ValueChanged += OnValueChanged;
            R6_BAIRRO.ValueChanged += OnValueChanged;
            R6_CIDADE.ValueChanged += OnValueChanged;
            R6_UF.ValueChanged += OnValueChanged;
            R6_CEP.ValueChanged += OnValueChanged;
            FILLER_3.ValueChanged += OnValueChanged;
        }

    }
}