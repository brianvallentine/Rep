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
    public class CLIENTE_DCLCLIENTES : VarBasis
    {
        /*"    10 COD-CLIENTE          PIC S9(9) USAGE COMP.*/
        public IntBasis COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NOME-RAZAO           PIC X(40).*/
        public StringBasis NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 TIPO-PESSOA          PIC X(1).*/
        public StringBasis TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CGCCPF               PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SIT-REGISTRO         PIC X(1).*/
        public StringBasis SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 DATA-NASCIMENTO      PIC X(10).*/
        public StringBasis DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-EMPRESA          PIC S9(9) USAGE COMP.*/
        public IntBasis COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-PORTE-EMP        PIC S9(4) USAGE COMP.*/
        public IntBasis COD_PORTE_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-NATUREZA-ATIV    PIC S9(9) USAGE COMP.*/
        public IntBasis COD_NATUREZA_ATIV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-RAMO-ATIVIDADE   PIC S9(9) USAGE COMP.*/
        public IntBasis COD_RAMO_ATIVIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-ATIVIDADE        PIC S9(9) USAGE COMP.*/
        public IntBasis COD_ATIVIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 IDE-SEXO             PIC X(1).*/
        public StringBasis IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ESTADO-CIVIL         PIC X(1).*/
        public StringBasis ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-GRD-GRUPO-CBO    PIC X(1).*/
        public StringBasis COD_GRD_GRUPO_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-SUBGRUPO-CBO     PIC S9(9) USAGE COMP.*/
        public IntBasis COD_SUBGRUPO_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-GRUPO-BASE-CBO   PIC S9(9) USAGE COMP.*/
        public IntBasis COD_GRUPO_BASE_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-SUBGR-BASE-CBO   PIC S9(9) USAGE COMP.*/
        public IntBasis COD_SUBGR_BASE_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}