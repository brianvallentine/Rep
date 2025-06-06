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
    public class VG078_DCLVG_ANDAMENTO_PROP : VarBasis
    {
        /*"    10 VG078-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG078_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG078-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG078_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG078-DES-ANDAMENTO.*/
        public VG078_VG078_DES_ANDAMENTO VG078_DES_ANDAMENTO { get; set; } = new VG078_VG078_DES_ANDAMENTO();

        public StringBasis VG078_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}