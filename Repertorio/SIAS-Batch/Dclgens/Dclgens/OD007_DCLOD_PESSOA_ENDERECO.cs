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
    public class OD007_DCLOD_PESSOA_ENDERECO : VarBasis
    {
        /*"    10 OD007-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis OD007_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD007-SEQ-ENDERECO   PIC S9(4) USAGE COMP.*/
        public IntBasis OD007_SEQ_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD007-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis OD007_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 OD007-IND-ENDERECO   PIC X(1).*/
        public StringBasis OD007_IND_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD007-STA-ENDERECO   PIC X(1).*/
        public StringBasis OD007_STA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD007-NOM-LOGRADOURO  PIC X(72).*/
        public StringBasis OD007_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 OD007-DES-NUM-IMOVEL  PIC X(10).*/
        public StringBasis OD007_DES_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OD007-DES-COMPL-ENDERECO  PIC X(72).*/
        public StringBasis OD007_DES_COMPL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 OD007-NOM-BAIRRO     PIC X(72).*/
        public StringBasis OD007_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 OD007-NOM-CIDADE     PIC X(72).*/
        public StringBasis OD007_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 OD007-COD-CEP        PIC X(8).*/
        public StringBasis OD007_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 OD007-COD-UF         PIC X(2).*/
        public StringBasis OD007_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 OD007-STA-CORRESPONDER  PIC X(1).*/
        public StringBasis OD007_STA_CORRESPONDER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD007-STA-PROPAGANDA  PIC X(1).*/
        public StringBasis OD007_STA_PROPAGANDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}