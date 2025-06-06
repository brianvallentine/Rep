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
    public class CONMOVVG_DCLCONTROLE_MOVTO_VG : VarBasis
    {
        /*"    10 CONMOVVG-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis CONMOVVG_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONMOVVG-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CONMOVVG_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CONMOVVG-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONMOVVG_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONMOVVG-NUM-ARQUIVO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONMOVVG_NUM_ARQUIVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONMOVVG-DATA-GERACAO  PIC X(10).*/
        public StringBasis CONMOVVG_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONMOVVG-DATA-PROCESSAMENTO  PIC X(10).*/
        public StringBasis CONMOVVG_DATA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONMOVVG-QTDE-REG-LIDOS  PIC S9(9) USAGE COMP.*/
        public IntBasis CONMOVVG_QTDE_REG_LIDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONMOVVG-QTDE-REG-ACEITOS  PIC S9(9) USAGE COMP.*/
        public IntBasis CONMOVVG_QTDE_REG_ACEITOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONMOVVG-QTDE-REG-REJEITA  PIC S9(9) USAGE COMP.*/
        public IntBasis CONMOVVG_QTDE_REG_REJEITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONMOVVG-SIT-REGISTRO  PIC X(1).*/
        public StringBasis CONMOVVG_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONMOVVG-TIMESTAMP   PIC X(26).*/
        public StringBasis CONMOVVG_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}