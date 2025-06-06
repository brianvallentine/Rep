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
    public class GE284_DCLGE_SISTEMA_ORIGEM : VarBasis
    {
        /*"    10 GE284-COD-SISTEMA-ORIGEM  PIC S9(4) USAGE COMP.*/
        public IntBasis GE284_COD_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE284-NOM-SISTEMA    PIC X(40).*/
        public StringBasis GE284_NOM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE284-IDE-SISTEMA    PIC X(2).*/
        public StringBasis GE284_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE284-DES-FUNCAO-SISTEMA.*/
        public GE284_GE284_DES_FUNCAO_SISTEMA GE284_DES_FUNCAO_SISTEMA { get; set; } = new GE284_GE284_DES_FUNCAO_SISTEMA();

        public StringBasis GE284_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE284-DTH-CRIACAO    PIC X(10).*/
        public StringBasis GE284_DTH_CRIACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}