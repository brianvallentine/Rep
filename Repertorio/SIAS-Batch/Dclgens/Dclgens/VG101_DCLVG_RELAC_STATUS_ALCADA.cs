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
    public class VG101_DCLVG_RELAC_STATUS_ALCADA : VarBasis
    {
        /*"    10 VG101-STA-CRITICA    PIC X(1).*/
        public StringBasis VG101_STA_CRITICA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG101-COD-TIPO-FUNCAO       PIC X(30).*/
        public StringBasis VG101_COD_TIPO_FUNCAO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 VG101-COD-NIVEL-AUTORIZACAO       PIC X(1).*/
        public StringBasis VG101_COD_NIVEL_AUTORIZACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG101-COD-USUARIO    PIC X(8).*/
        public StringBasis VG101_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG101-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG101_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG101-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG101_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}