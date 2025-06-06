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
    public class CODIGOPE_DCLCODIGO_OPERACAO : VarBasis
    {
        /*"    10 CODIGOPE-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis CODIGOPE_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CODIGOPE-DESCR-OPERACAO       PIC X(40).*/
        public StringBasis CODIGOPE_DESCR_OPERACAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 CODIGOPE-TIPO-PROCESSO       PIC X(1).*/
        public StringBasis CODIGOPE_TIPO_PROCESSO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CODIGOPE-AREA-ENVOLVIDA       PIC X(1).*/
        public StringBasis CODIGOPE_AREA_ENVOLVIDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CODIGOPE-IND-BLOQ-LIBERA       PIC X(1).*/
        public StringBasis CODIGOPE_IND_BLOQ_LIBERA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CODIGOPE-QTD-DIAS-LIMITE       PIC S9(4) USAGE COMP.*/
        public IntBasis CODIGOPE_QTD_DIAS_LIMITE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CODIGOPE-COD-OPER-ASSOCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis CODIGOPE_COD_OPER_ASSOCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CODIGOPE-SIT-REGISTRO       PIC X(1).*/
        public StringBasis CODIGOPE_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CODIGOPE-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis CODIGOPE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CODIGOPE-DES-OPER-COMERC.*/
        public CODIGOPE_CODIGOPE_DES_OPER_COMERC CODIGOPE_DES_OPER_COMERC { get; set; } = new CODIGOPE_CODIGOPE_DES_OPER_COMERC();

        public CODIGOPE_CODIGOPE_DES_OPE_PORTALPJ CODIGOPE_DES_OPE_PORTALPJ { get; set; } = new CODIGOPE_CODIGOPE_DES_OPE_PORTALPJ();

    }
}