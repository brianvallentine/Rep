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
    public class LXFPF003_RES_COMUM : VarBasis
    {
        /*"      07        RES-TIPO-REG          PIC  9(001)*/
        public IntBasis RES_TIPO_REG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"      07        RES-FILIAL-DOC        PIC  9(003)*/
        public IntBasis RES_FILIAL_DOC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"      07        RES-LOTE              PIC  9(003)*/
        public IntBasis RES_LOTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"      07        RES-TIPO-DOC          PIC  9(005)*/
        public IntBasis RES_TIPO_DOC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"    05          RES-NUMBIL            PIC  9(011)*/
    }
}