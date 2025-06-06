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
    public class GEOPERAC_DCLGE_OPERACAO : VarBasis
    {
        /*"    10 GEOPERAC-IDE-SISTEMA       PIC X(2).*/
        public StringBasis GEOPERAC_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GEOPERAC-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis GEOPERAC_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEOPERAC-DES-OPERACAO       PIC X(80).*/
        public StringBasis GEOPERAC_DES_OPERACAO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        /*"    10 GEOPERAC-FUNCAO-OPERACAO       PIC X(5).*/
        public StringBasis GEOPERAC_FUNCAO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 GEOPERAC-DES-ABREVIADA       PIC X(40).*/
        public StringBasis GEOPERAC_DES_ABREVIADA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GEOPERAC-IND-TIPO-FUNCAO       PIC X(40).*/
        public StringBasis GEOPERAC_IND_TIPO_FUNCAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GEOPERAC-SIT-REGISTRO       PIC X(1).*/
        public StringBasis GEOPERAC_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEOPERAC-COD-USUARIO       PIC X(8).*/
        public StringBasis GEOPERAC_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GEOPERAC-DTH-CADASTRAMENTO       PIC X(10).*/
        public StringBasis GEOPERAC_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEOPERAC-COD-OPER-LIDER       PIC S9(4) USAGE COMP.*/
        public IntBasis GEOPERAC_COD_OPER_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEOPERAC-COD-OPER-COSEG       PIC S9(4) USAGE COMP.*/
        public IntBasis GEOPERAC_COD_OPER_COSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEOPERAC-COD-DESEMBOLSO-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis GEOPERAC_COD_DESEMBOLSO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}