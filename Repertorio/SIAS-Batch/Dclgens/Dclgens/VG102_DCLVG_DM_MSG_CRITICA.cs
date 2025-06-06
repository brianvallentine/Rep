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
    public class VG102_DCLVG_DM_MSG_CRITICA : VarBasis
    {
        /*"    10 VG102-COD-MSG-CRITICA       PIC S9(4) USAGE COMP.*/
        public IntBasis VG102_COD_MSG_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG102-DES-MSG-CRITICA.*/
        public VG102_VG102_DES_MSG_CRITICA VG102_DES_MSG_CRITICA { get; set; } = new VG102_VG102_DES_MSG_CRITICA();

        public StringBasis VG102_DES_ABREV_MSG_CRITICA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 VG102-COD-USUARIO    PIC X(8).*/
        public StringBasis VG102_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG102-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG102_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG102-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG102_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG102-COD-TP-MSG-CRITICA       PIC S9(4) USAGE COMP.*/
        public IntBasis VG102_COD_TP_MSG_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG102-IND-EXCLUSAO   PIC X(1).*/
        public StringBasis VG102_IND_EXCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG102-COD-ERRO-SIVPF       PIC S9(9) USAGE COMP.*/
        public IntBasis VG102_COD_ERRO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG102-COD-AGRUPA-ERRO       PIC X(3).*/
        public StringBasis VG102_COD_AGRUPA_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 VG102-IND-ALTERACAO  PIC X(1).*/
        public StringBasis VG102_IND_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG102-IND-LIBERACAO-CAMPO       PIC X(2).*/
        public StringBasis VG102_IND_LIBERACAO_CAMPO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG102-IND-ALCADA     PIC X(1).*/
        public StringBasis VG102_IND_ALCADA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG102-IND-ACATAMENTO       PIC X(1).*/
        public StringBasis VG102_IND_ACATAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}