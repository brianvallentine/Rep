using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class ESTRUTUR_DCLESTRUTURA : VarBasis
    {
        /*"    10 ESTRUTUR-SISTEMA     PIC S9(4) USAGE COMP.*/
        public IntBasis ESTRUTUR_SISTEMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESTRUTUR-SUB-SISTEMA       PIC S9(4) USAGE COMP.*/
        public IntBasis ESTRUTUR_SUB_SISTEMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESTRUTUR-GRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis ESTRUTUR_GRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESTRUTUR-SUB-GRUPO   PIC S9(4) USAGE COMP.*/
        public IntBasis ESTRUTUR_SUB_GRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESTRUTUR-ITEM        PIC S9(4) USAGE COMP.*/
        public IntBasis ESTRUTUR_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESTRUTUR-SUB-ITEM    PIC S9(4) USAGE COMP.*/
        public IntBasis ESTRUTUR_SUB_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESTRUTUR-COD-APLICACAO       PIC X(8).*/
        public StringBasis ESTRUTUR_COD_APLICACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ESTRUTUR-NOME-GRUPO  PIC X(40).*/
        public StringBasis ESTRUTUR_NOME_GRUPO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 ESTRUTUR-IDE-SISTEMA       PIC X(2).*/
        public StringBasis ESTRUTUR_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 ESTRUTUR-SIT-REGISTRO       PIC X(1).*/
        public StringBasis ESTRUTUR_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ESTRUTUR-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis ESTRUTUR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}