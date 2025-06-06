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
    public class CLIENTES_DCLCLIENTES : VarBasis
    {
        /*"    10 CLIENTES-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis CLIENTES_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CLIENTES-NOME-RAZAO  PIC X(40).*/
        public StringBasis CLIENTES_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 CLIENTES-TIPO-PESSOA  PIC X(1).*/
        public StringBasis CLIENTES_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CLIENTES-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis CLIENTES_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 CLIENTES-SIT-REGISTRO  PIC X(1).*/
        public StringBasis CLIENTES_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CLIENTES-DATA-NASCIMENTO  PIC X(10).*/
        public StringBasis CLIENTES_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CLIENTES-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis CLIENTES_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CLIENTES-COD-PORTE-EMP  PIC S9(4) USAGE COMP.*/
        public IntBasis CLIENTES_COD_PORTE_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CLIENTES-COD-NATUREZA-ATIV  PIC S9(9) USAGE COMP.*/
        public IntBasis CLIENTES_COD_NATUREZA_ATIV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CLIENTES-COD-RAMO-ATIVIDADE  PIC S9(9) USAGE COMP.*/
        public IntBasis CLIENTES_COD_RAMO_ATIVIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CLIENTES-COD-ATIVIDADE  PIC S9(9) USAGE COMP.*/
        public IntBasis CLIENTES_COD_ATIVIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CLIENTES-IDE-SEXO    PIC X(1).*/
        public StringBasis CLIENTES_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CLIENTES-ESTADO-CIVIL  PIC X(1).*/
        public StringBasis CLIENTES_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CLIENTES-COD-GRD-GRUPO-CBO  PIC X(1).*/
        public StringBasis CLIENTES_COD_GRD_GRUPO_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CLIENTES-COD-SUBGRUPO-CBO  PIC S9(9) USAGE COMP.*/
        public IntBasis CLIENTES_COD_SUBGRUPO_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CLIENTES-COD-GRUPO-BASE-CBO  PIC S9(9) USAGE COMP.*/
        public IntBasis CLIENTES_COD_GRUPO_BASE_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CLIENTES-COD-SUBGR-BASE-CBO  PIC S9(9) USAGE COMP.*/
        public IntBasis CLIENTES_COD_SUBGR_BASE_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}