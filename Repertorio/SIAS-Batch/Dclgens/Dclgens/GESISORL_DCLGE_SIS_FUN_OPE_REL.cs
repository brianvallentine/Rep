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
    public class GESISORL_DCLGE_SIS_FUN_OPE_REL : VarBasis
    {
        /*"    10 GESISORL-IDE-SISTEMA-FUNCAO  PIC X(2).*/
        public StringBasis GESISORL_IDE_SISTEMA_FUNCAO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GESISORL-COD-FUNCAO  PIC S9(9) USAGE COMP.*/
        public IntBasis GESISORL_COD_FUNCAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GESISORL-IDE-SISTEMA-OPER  PIC X(2).*/
        public StringBasis GESISORL_IDE_SISTEMA_OPER { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GESISORL-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis GESISORL_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GESISORL-TIPO-ENDOSSO  PIC X(1).*/
        public StringBasis GESISORL_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GESISORL-IDE-SISTEMA-FC-ASS  PIC X(2).*/
        public StringBasis GESISORL_IDE_SISTEMA_FC_ASS { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GESISORL-COD-FUNCAO-ASS  PIC S9(9) USAGE COMP.*/
        public IntBasis GESISORL_COD_FUNCAO_ASS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GESISORL-IDE-SISTEMA-OP-ASS  PIC X(2).*/
        public StringBasis GESISORL_IDE_SISTEMA_OP_ASS { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GESISORL-COD-OPERACAO-ASS  PIC S9(4) USAGE COMP.*/
        public IntBasis GESISORL_COD_OPERACAO_ASS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GESISORL-TIPO-ENDOSSO-ASS  PIC X(1).*/
        public StringBasis GESISORL_TIPO_ENDOSSO_ASS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GESISORL-COD-USUARIO  PIC X(8).*/
        public StringBasis GESISORL_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GESISORL-DTH-CADASTRAMENTO  PIC X(10).*/
        public StringBasis GESISORL_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}