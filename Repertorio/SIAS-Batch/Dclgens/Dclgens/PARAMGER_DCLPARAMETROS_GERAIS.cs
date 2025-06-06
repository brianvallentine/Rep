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
    public class PARAMGER_DCLPARAMETROS_GERAIS : VarBasis
    {
        /*"    10 PARAMGER-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis PARAMGER_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARAMGER-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis PARAMGER_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARAMGER-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis PARAMGER_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARAMGER-COD-MOEDA   PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMGER_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMGER-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMGER_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMGER-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMGER_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMGER-OPCAO-BANCO       PIC X(1).*/
        public StringBasis PARAMGER_OPCAO_BANCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARAMGER-DIF-PREMIOS       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis PARAMGER_DIF_PREMIOS { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PARAMGER-FAIXA-APOL-MANUAL       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PARAMGER_FAIXA_APOL_MANUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PARAMGER-FAIXA-ENDOSCOB-MAN       PIC S9(9) USAGE COMP.*/
        public IntBasis PARAMGER_FAIXA_ENDOSCOB_MAN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARAMGER-DATA-FATURAVG-AUT       PIC X(10).*/
        public StringBasis PARAMGER_DATA_FATURAVG_AUT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARAMGER-CAPITAL-SOCIAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARAMGER_CAPITAL_SOCIAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARAMGER-CAPITAL-REALIZADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARAMGER_CAPITAL_REALIZADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARAMGER-CAPITAL-VINCULADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARAMGER_CAPITAL_VINCULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARAMGER-ULT-AVISO-CREDITO       PIC S9(9) USAGE COMP.*/
        public IntBasis PARAMGER_ULT_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARAMGER-CODIGO-LIDER       PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMGER_CODIGO_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMGER-NUM-RELACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMGER_NUM_RELACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMGER-COD-CGCCPF  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PARAMGER_COD_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PARAMGER-COD-EMPRESA-CAP       PIC S9(9) USAGE COMP.*/
        public IntBasis PARAMGER_COD_EMPRESA_CAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}