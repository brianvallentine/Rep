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
    public class USUARIOS_DCLUSUARIOS : VarBasis
    {
        /*"    10 USUARIOS-COD-USUARIO       PIC X(8).*/
        public StringBasis USUARIOS_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 USUARIOS-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis USUARIOS_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 USUARIOS-NUM-CENTRO-CUSTO       PIC S9(9) USAGE COMP.*/
        public IntBasis USUARIOS_NUM_CENTRO_CUSTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 USUARIOS-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis USUARIOS_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 USUARIOS-NOME-USUARIO       PIC X(40).*/
        public StringBasis USUARIOS_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 USUARIOS-COD-AREA    PIC S9(9) USAGE COMP.*/
        public IntBasis USUARIOS_COD_AREA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 USUARIOS-DEPARTAMENTO       PIC X(10).*/
        public StringBasis USUARIOS_DEPARTAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 USUARIOS-NUM-RAMAL   PIC S9(4) USAGE COMP.*/
        public IntBasis USUARIOS_NUM_RAMAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 USUARIOS-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis USUARIOS_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 USUARIOS-DATA-CADASTRAMENTO       PIC X(10).*/
        public StringBasis USUARIOS_DATA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 USUARIOS-SENHA       PIC X(32).*/
        public StringBasis USUARIOS_SENHA { get; set; } = new StringBasis(new PIC("X", "32", "X(32)."), @"");
        /*"    10 USUARIOS-SIT-REGISTRO       PIC X(1).*/
        public StringBasis USUARIOS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 USUARIOS-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis USUARIOS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 USUARIOS-TIMESTAMP   PIC X(26).*/
        public StringBasis USUARIOS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 USUARIOS-DES-EMAIL   PIC X(50).*/
        public StringBasis USUARIOS_DES_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 USUARIOS-NUM-CPF     PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis USUARIOS_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 USUARIOS-COD-RG      PIC X(20).*/
        public StringBasis USUARIOS_COD_RG { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 USUARIOS-DTH-NASCIMENTO       PIC X(10).*/
        public StringBasis USUARIOS_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 USUARIOS-NUM-DDD     PIC S9(4) USAGE COMP.*/
        public IntBasis USUARIOS_NUM_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 USUARIOS-NUM-TELEFONE       PIC S9(9) USAGE COMP.*/
        public IntBasis USUARIOS_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 USUARIOS-IND-MUDA-SENHA       PIC X(1).*/
        public StringBasis USUARIOS_IND_MUDA_SENHA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 USUARIOS-QTD-DIAS-EXP-SENHA       PIC S9(4) USAGE COMP.*/
        public IntBasis USUARIOS_QTD_DIAS_EXP_SENHA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 USUARIOS-QTD-TENTATIVA       PIC S9(4) USAGE COMP.*/
        public IntBasis USUARIOS_QTD_TENTATIVA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 USUARIOS-DTH-FIM-ACESSO       PIC X(10).*/
        public StringBasis USUARIOS_DTH_FIM_ACESSO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 USUARIOS-COD-CARGO   PIC S9(4) USAGE COMP.*/
        public IntBasis USUARIOS_COD_CARGO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}