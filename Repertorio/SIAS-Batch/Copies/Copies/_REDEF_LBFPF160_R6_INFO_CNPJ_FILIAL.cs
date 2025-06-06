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
    public class _REDEF_LBFPF160_R6_INFO_CNPJ_FILIAL : VarBasis
    {
        /*"    15 R6-QUANT-CNPJ-FILIAL            PIC  9(002)*/
        public IntBasis R6_QUANT_CNPJ_FILIAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    15 R6-CNPJ-FILIAL     OCCURS 10 TIMES*/
        public ListBasis<LBFPF160_R6_CNPJ_FILIAL> R6_CNPJ_FILIAL { get; set; } = new ListBasis<LBFPF160_R6_CNPJ_FILIAL>(10);

        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "141", "X(141)"), @"");
        /*"  10         R6-INFO-EMPRESA-MEI     REDEFINES      R6-INFO*/

        public _REDEF_LBFPF160_R6_INFO_CNPJ_FILIAL()
        {
            R6_QUANT_CNPJ_FILIAL.ValueChanged += OnValueChanged;
            R6_CNPJ_FILIAL.ValueChanged += OnValueChanged;
            FILLER_2.ValueChanged += OnValueChanged;
        }

    }
}