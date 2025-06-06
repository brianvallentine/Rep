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
    public class LBSI505B_SI0505B_SAIDA : VarBasis
    {
        /*"       05  SI0505B-RC                 PIC 99*/
        public IntBasis SI0505B_RC { get; set; } = new IntBasis(new PIC("9", "2", "99"));
        /*"       05  SI0505B-NUM-SQL            PIC X(003)*/
        public StringBasis SI0505B_NUM_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"       05  SI0505B-SQLCODE            PIC -999*/
        public IntBasis SI0505B_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-999"));
        /*"       05  SI0505B-MENSAGEM           PIC X(080)*/
        public StringBasis SI0505B_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
        /*"       05  SI0505B-AG-CONTRATO        PIC 9(04)*/
        public IntBasis SI0505B_AG_CONTRATO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"       05  SI0505B-UNO                PIC 9(04)*/
        public IntBasis SI0505B_UNO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"*/
    }
}