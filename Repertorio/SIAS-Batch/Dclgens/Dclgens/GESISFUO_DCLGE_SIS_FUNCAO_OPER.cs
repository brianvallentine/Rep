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
    public class GESISFUO_DCLGE_SIS_FUNCAO_OPER : VarBasis
    {
        /*"    10 GESISFUO-IDE-SISTEMA  PIC X(2).*/
        public StringBasis GESISFUO_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GESISFUO-COD-FUNCAO  PIC S9(9) USAGE COMP.*/
        public IntBasis GESISFUO_COD_FUNCAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GESISFUO-IDE-SISTEMA-OPER  PIC X(2).*/
        public StringBasis GESISFUO_IDE_SISTEMA_OPER { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GESISFUO-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis GESISFUO_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GESISFUO-TIPO-ENDOSSO  PIC X(1).*/
        public StringBasis GESISFUO_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GESISFUO-NUM-FATOR   PIC S9(4) USAGE COMP.*/
        public IntBasis GESISFUO_NUM_FATOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GESISFUO-COD-USUARIO  PIC X(8).*/
        public StringBasis GESISFUO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GESISFUO-DTH-CADASTRAMENTO  PIC X(10).*/
        public StringBasis GESISFUO_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}