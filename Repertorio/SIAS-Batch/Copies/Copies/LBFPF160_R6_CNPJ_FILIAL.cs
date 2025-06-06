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
    public class LBFPF160_R6_CNPJ_FILIAL : VarBasis
    {
        /*"       20 R6-NUM-CNPJ-FILIAL           PIC  9(014)*/
        public IntBasis R6_NUM_CNPJ_FILIAL { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"    15 FILLER                          PIC  X(141)*/

        public LBFPF160_R6_CNPJ_FILIAL()
        {
            R6_NUM_CNPJ_FILIAL.ValueChanged += OnValueChanged;
        }

    }
}