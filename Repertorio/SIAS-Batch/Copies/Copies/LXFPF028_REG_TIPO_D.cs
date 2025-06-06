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
    public class LXFPF028_REG_TIPO_D : VarBasis
    {
        /*"     05  RSD-TIPO-REG                 PIC  X(001)*/
        public StringBasis RSD_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     05  RSD-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis RSD_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     05  RSD-NOME-SOCIAL              PIC  X(070)*/
        public StringBasis RSD_NOME_SOCIAL { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"     05  RSD-FILLER                   PIC  X(215)*/
        public StringBasis RSD_FILLER { get; set; } = new StringBasis(new PIC("X", "215", "X(215)"), @"");
        /*"*/
    }
}