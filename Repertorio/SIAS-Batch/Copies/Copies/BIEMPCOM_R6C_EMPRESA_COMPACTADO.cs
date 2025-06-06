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
    public class BIEMPCOM_R6C_EMPRESA_COMPACTADO : VarBasis
    {
        /*" 03    R6C-RAZAO-SOCIAL-MEI          PIC  X(040)*/
        public StringBasis R6C_RAZAO_SOCIAL_MEI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*" 03    R6C-DATA-CONSTITUICAO-MEI     PIC  9(008)*/
        public IntBasis R6C_DATA_CONSTITUICAO_MEI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*" 03    R6C-COD-PORTE-MEI             PIC S9(004)    COMP-3*/
        public IntBasis R6C_COD_PORTE_MEI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 03    R6C-CNAE-MEI                  PIC S9(010)    COMP-3*/
        public IntBasis R6C_CNAE_MEI { get; set; } = new IntBasis(new PIC("S9", "10", "S9(010)"));
        /*" 03    R6C-VAL-FAT-ANUAL-MEI         PIC S9(013)V99 COMP-3*/
        public DoubleBasis R6C_VAL_FAT_ANUAL_MEI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*" 03    R6C-DAT-FAT-ANUAL-MEI         PIC  9(008)*/
        public IntBasis R6C_DAT_FAT_ANUAL_MEI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*" 03    R6C-CNPJ-MEI                  PIC S9(015)    COMP-3*/
        public IntBasis R6C_CNPJ_MEI { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*" 03    R6C-DDD-COMERCIAL             PIC S9(003)    COMP-3*/
        public IntBasis R6C_DDD_COMERCIAL { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*" 03    R6C-TELEFONE-COMERCIAL        PIC S9(009)    COMP-3*/
        public IntBasis R6C_TELEFONE_COMERCIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*" 03    R6C-EMAIL                     PIC  X(040)*/
        public StringBasis R6C_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*" 03    R6C-TIPO-ENDERECO             PIC  9(001)    COMP-3*/
        public IntBasis R6C_TIPO_ENDERECO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*" 03    R6C-ENDERECO                  PIC  X(050)*/
        public StringBasis R6C_ENDERECO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*" 03    R6C-BAIRRO                    PIC  X(030)*/
        public StringBasis R6C_BAIRRO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*" 03    R6C-CIDADE                    PIC  X(035)*/
        public StringBasis R6C_CIDADE { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
        /*" 03    R6C-UF                        PIC  X(002)*/
        public StringBasis R6C_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*" 03    R6C-CEP                       PIC S9(008)    COMP-3*/
        public IntBasis R6C_CEP { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
        /*"*/
    }
}