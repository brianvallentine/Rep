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
    public class GESISFUN_DCLGE_SISTEMA_FUNCAO : VarBasis
    {
        /*"    10 GESISFUN-IDE-SISTEMA  PIC X(2).*/
        public StringBasis GESISFUN_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GESISFUN-COD-FUNCAO  PIC S9(9) USAGE COMP.*/
        public IntBasis GESISFUN_COD_FUNCAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GESISFUN-NOM-FUNCAO  PIC X(60).*/
        public StringBasis GESISFUN_NOM_FUNCAO { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 GESISFUN-SIT-REGISTRO  PIC X(1).*/
        public StringBasis GESISFUN_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GESISFUN-COD-USUARIO  PIC X(8).*/
        public StringBasis GESISFUN_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GESISFUN-DTH-CADASTRAMENTO  PIC X(10).*/
        public StringBasis GESISFUN_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GESISFUN-DES-FUNCAO.*/
        public GESISFUN_GESISFUN_DES_FUNCAO GESISFUN_DES_FUNCAO { get; set; } = new GESISFUN_GESISFUN_DES_FUNCAO();

        public IntBasis GESISFUN_COD_GRUPO_FUNCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}