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
    public class LBSI0202_SI0202S_SAIDA : VarBasis
    {
        /*"      05 SI0202S-LOGRADOURO         PIC X(40)*/
        public StringBasis SI0202S_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"      05 SI0202S-BAIRRO             PIC X(40)*/
        public StringBasis SI0202S_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"      05 SI0202S-CIDADE             PIC X(40)*/
        public StringBasis SI0202S_CIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"      05 SI0202S-UF                 PIC X(02)*/
        public StringBasis SI0202S_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"      05 SI0202S-CEP                PIC 9(08)*/
        public IntBasis SI0202S_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"      05 SI0202S-ORIGEM             PIC X(02)*/
        public StringBasis SI0202S_ORIGEM { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"      05 SI0202S-RC                 PIC 99*/
        public IntBasis SI0202S_RC { get; set; } = new IntBasis(new PIC("9", "2", "99"));
        /*"      05 SI0202S-NUM-SQL            PIC X(003)*/
        public StringBasis SI0202S_NUM_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"      05 SI0202S-SQLCODE            PIC -999*/
        public IntBasis SI0202S_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-999"));
        /*"      05 SI0202S-MENSAGEM           PIC X(080)*/
        public StringBasis SI0202S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
    }
}