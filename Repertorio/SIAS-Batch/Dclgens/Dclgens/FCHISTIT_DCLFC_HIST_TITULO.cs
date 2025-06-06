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
    public class FCHISTIT_DCLFC_HIST_TITULO : VarBasis
    {
        /*"    10 FCHISTIT-IDE-HIST-TITULO  PIC S9(9) USAGE COMP.*/
        public IntBasis FCHISTIT_IDE_HIST_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCHISTIT-COD-OPERACAO  PIC X(4).*/
        public StringBasis FCHISTIT_COD_OPERACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 FCHISTIT-DTH-REGISTRO  PIC X(26).*/
        public StringBasis FCHISTIT_DTH_REGISTRO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 FCHISTIT-IDE-USUARIO  PIC S9(4) USAGE COMP.*/
        public IntBasis FCHISTIT_IDE_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCHISTIT-NUM-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis FCHISTIT_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCHISTIT-NUM-SERIE   PIC S9(4) USAGE COMP.*/
        public IntBasis FCHISTIT_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCHISTIT-NUM-TITULO  PIC S9(9) USAGE COMP.*/
        public IntBasis FCHISTIT_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCHISTIT-COD-DETALHE  PIC X(3).*/
        public StringBasis FCHISTIT_COD_DETALHE { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCHISTIT-DES-MSG-ORIGEM.*/
        public FCHISTIT_FCHISTIT_DES_MSG_ORIGEM FCHISTIT_DES_MSG_ORIGEM { get; set; } = new FCHISTIT_FCHISTIT_DES_MSG_ORIGEM();

        public FCHISTIT_FCHISTIT_DES_MSG_DESTINO FCHISTIT_DES_MSG_DESTINO { get; set; } = new FCHISTIT_FCHISTIT_DES_MSG_DESTINO();

        public IntBasis FCHISTIT_IDE_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCHISTIT-IDE-ENDERECO  PIC S9(9) USAGE COMP.*/
        public IntBasis FCHISTIT_IDE_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}