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
    public class VG099_DCLVG_DM_STA_CRITICA : VarBasis
    {
        /*"    10 VG099-STA-CRITICA    PIC X(1).*/
        public StringBasis VG099_STA_CRITICA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG099-DES-STA-CRITICA.*/
        public VG099_VG099_DES_STA_CRITICA VG099_DES_STA_CRITICA { get; set; } = new VG099_VG099_DES_STA_CRITICA();

        public StringBasis VG099_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG099-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG099_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG099-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG099_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}