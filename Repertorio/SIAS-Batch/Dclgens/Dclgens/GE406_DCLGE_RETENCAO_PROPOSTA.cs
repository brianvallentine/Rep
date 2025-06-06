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
    public class GE406_DCLGE_RETENCAO_PROPOSTA : VarBasis
    {
        /*"    10 GE406-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis GE406_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GE406-NUM-CPF        PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis GE406_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 GE406-COD-IDE-CONSULTA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis GE406_COD_IDE_CONSULTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GE406-IND-SERV-CONSULTA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE406_IND_SERV_CONSULTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE406-IND-PROCESSAMENTO       PIC X(1).*/
        public StringBasis GE406_IND_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE406-IND-ACEITACAO  PIC X(1).*/
        public StringBasis GE406_IND_ACEITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE406-COD-USUARIO    PIC X(8).*/
        public StringBasis GE406_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE406-DTH-GERACAO    PIC X(26).*/
        public StringBasis GE406_DTH_GERACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE406-DTH-PROCESSAMENTO       PIC X(26).*/
        public StringBasis GE406_DTH_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE406-DTH-CONSUMO    PIC X(26).*/
        public StringBasis GE406_DTH_CONSUMO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE406-IND-RET-SUBSCRICAO       PIC X(1).*/
        public StringBasis GE406_IND_RET_SUBSCRICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE406-PCT-AGRAVO     PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE406_PCT_AGRAVO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 GE406-VLR-PRM-SEM-AGR       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE406_VLR_PRM_SEM_AGR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}