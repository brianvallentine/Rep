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
    public class _REDEF_LBFPF160_R6_INFO_COBERTURAS_FUNC : VarBasis
    {
        /*"    15 R6-QUANT-COBERTURAS             PIC  9(002)*/
        public IntBasis R6_QUANT_COBERTURAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    15 R6-COBERTURAS-FUNC OCCURS 06 TIMES*/
        public ListBasis<LBFPF160_R6_COBERTURAS_FUNC> R6_COBERTURAS_FUNC { get; set; } = new ListBasis<LBFPF160_R6_COBERTURAS_FUNC>(06);

        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
        /*"  10   R6-INFO-CNPJ-FILIAL             REDEFINES                                       R6-INFO*/

        public _REDEF_LBFPF160_R6_INFO_COBERTURAS_FUNC()
        {
            R6_QUANT_COBERTURAS.ValueChanged += OnValueChanged;
            R6_COBERTURAS_FUNC.ValueChanged += OnValueChanged;
            FILLER_1.ValueChanged += OnValueChanged;
        }

    }
}