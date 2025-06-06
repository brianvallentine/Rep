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
    public class SISTEMAS_DCLSISTEMAS : VarBasis
    {
        /*"    10 SISTEMAS-IDE-SISTEMA  PIC X(2).*/
        public StringBasis SISTEMAS_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SISTEMAS-DATA-MOV-ABERTO  PIC X(10).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SISTEMAS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis SISTEMAS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SISTEMAS-DATULT-PROCESSAMEN  PIC X(10).*/
        public StringBasis SISTEMAS_DATULT_PROCESSAMEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SISTEMAS-DESCRICAO-SISTEMA  PIC X(80).*/
        public StringBasis SISTEMAS_DESCRICAO_SISTEMA { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        /*"    10 SISTEMAS-DTH-ATUALIZACAO  PIC X(10).*/
        public StringBasis SISTEMAS_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SISTEMAS-STA-SISTEMA  PIC X(1).*/
        public StringBasis SISTEMAS_STA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SISTEMAS-IND-SGBD    PIC X(1).*/
        public StringBasis SISTEMAS_IND_SGBD { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}