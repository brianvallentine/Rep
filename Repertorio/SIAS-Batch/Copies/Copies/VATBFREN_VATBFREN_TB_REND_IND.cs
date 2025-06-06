using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class VATBFREN_VATBFREN_TB_REND_IND : VarBasis
    {
        /*"      05 FILLER                    PIC S9(09)V99 VALUE 108000,00*/
        public DoubleBasis FILLER { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V99"), 2, 108000.00);
        /*"      05 FILLER                    PIC S9(09)V99 VALUE 180000,00*/
        public DoubleBasis FILLER_0 { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V99"), 2, 180000.00);
        /*"      05 FILLER                    PIC S9(09)V99 VALUE 324000,00*/
        public DoubleBasis FILLER_1 { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V99"), 2, 324000.00);
        /*"      05 FILLER                    PIC S9(09)V99 VALUE 504000,00*/
        public DoubleBasis FILLER_2 { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V99"), 2, 504000.00);
        /*"      05 FILLER                    PIC S9(09)V99 VALUE 600000,00*/
        public DoubleBasis FILLER_3 { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V99"), 2, 600000.00);
        /*"    03   FILLER REDEFINES VATBFREN-TB-REND-IND*/
    }
}