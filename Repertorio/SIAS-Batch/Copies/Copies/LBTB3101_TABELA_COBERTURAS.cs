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
    public class LBTB3101_TABELA_COBERTURAS : VarBasis
    {
        /*"  10   CB0001 PIC X(050) VALUE        'INC,RAIO EXP   -INCENDIO,QUEDA RAIO E EXPLOSAO '*/
        public StringBasis CB0001 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"INC,RAIO EXP   -INCENDIO,QUEDA RAIO E EXPLOSAO ");
        /*"  10   CB0002 PIC X(050) VALUE        'ROUBO VAL      -ROUBO DE VALORES               '*/
        public StringBasis CB0002 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"ROUBO VAL      -ROUBO DE VALORES               ");
        /*"  10   CB0003 PIC X(050) VALUE        'DAN.ELET       -DANOS ELETRICOS               '*/
        public StringBasis CB0003 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"DAN.ELET       -DANOS ELETRICOS               ");
        /*"  10   CB0004 PIC X(050) VALUE        'ACI.PES.EMPR   -ACID.PES. EMPREGADOR           '*/
        public StringBasis CB0004 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"ACI.PES.EMPR   -ACID.PES. EMPREGADOR           ");
        /*"  10   CB0005 PIC X(050) VALUE        'ACI.PES.EMP    -ACID.PES. EMPREGADO            '*/
        public StringBasis CB0005 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"ACI.PES.EMP    -ACID.PES. EMPREGADO            ");
        /*"  10   CB0006 PIC X(050) VALUE        'RC-OPERACOES   -RESPONSABILIDADE CIVIL OPERACOES'*/
        public StringBasis CB0006 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RC-OPERACOES   -RESPONSABILIDADE CIVIL OPERACOES");
        /*"  10   CB0007 PIC X(050) VALUE        'ROUBO INT.ESTB -ROUBO DE VALORES INT. ESTAB    '*/
        public StringBasis CB0007 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"ROUBO INT.ESTB -ROUBO DE VALORES INT. ESTAB    ");
        /*"  10   CB0008 PIC X(050) VALUE        'ROUBO MAO PORT -ROUBO DE VALORES MAOS PORTADOR '*/
        public StringBasis CB0008 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"ROUBO MAO PORT -ROUBO DE VALORES MAOS PORTADOR ");
        /*"  10   CB0009 PIC X(050) VALUE        'ROUBO MAQ MOV  -ROUBO DE MAQ. MOVEIS E UTENS.  '*/
        public StringBasis CB0009 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"ROUBO MAQ MOV  -ROUBO DE MAQ. MOVEIS E UTENS.  ");
        /*"  10   CB0010 PIC X(050) VALUE        'VENDAVAL       -VENDAVAL/FUMACA                '*/
        public StringBasis CB0010 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"VENDAVAL       -VENDAVAL/FUMACA                ");
        /*"  10   CB0011 PIC X(050) VALUE        'DIAS PARALIS   -DIAS PARALISACAO               '*/
        public StringBasis CB0011 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"DIAS PARALIS   -DIAS PARALISACAO               ");
        /*"  10   CB0012 PIC X(050) VALUE        'PERDA PAG ALUG -PERDA/PAGAMENTO ALUGUEL        '*/
        public StringBasis CB0012 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"PERDA PAG ALUG -PERDA/PAGAMENTO ALUGUEL        ");
        /*"  10   CB0013 PIC X(050) VALUE        'TUMULTOS       -TUMULTOS E GREVES              '*/
        public StringBasis CB0013 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"TUMULTOS       -TUMULTOS E GREVES              ");
        /*"  10   CB0014 PIC X(050) VALUE        'QUEBRA VIDROS  -QUEBRA DE VIDROS/ANUNCIOS LUM. '*/
        public StringBasis CB0014 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"QUEBRA VIDROS  -QUEBRA DE VIDROS/ANUNCIOS LUM. ");
        /*"  10   CB0015 PIC X(050) VALUE        'DERRAME SPRINK -DERRAME DE SPRINKLERS          '*/
        public StringBasis CB0015 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"DERRAME SPRINK -DERRAME DE SPRINKLERS          ");
        /*"  10   CB0016 PIC X(050) VALUE        'RC-GUARDA VEIC -RC - GUARDA DE VEICULOS        '*/
        public StringBasis CB0016 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RC-GUARDA VEIC -RC - GUARDA DE VEICULOS        ");
        /*"  10   CB0017 PIC X(050) VALUE        'EQ.MOV EST-TFL -EQUIP.MOVEIS E ESTAC - TFL     '*/
        public StringBasis CB0017 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"EQ.MOV EST-TFL -EQUIP.MOVEIS E ESTAC - TFL     ");
        /*"  10   CB0018 PIC X(050) VALUE        'EQ.MOV EST-COF -EQUIP.MOVEIS E ESTAC - COFRE   '*/
        public StringBasis CB0018 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"EQ.MOV EST-COF -EQUIP.MOVEIS E ESTAC - COFRE   ");
        /*"  10   CB0019 PIC X(050) VALUE        'EQ.MOV EST-DEM -EQUIP.MOVEIS E ESTAC - DEMAIS  '*/
        public StringBasis CB0019 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"EQ.MOV EST-DEM -EQUIP.MOVEIS E ESTAC - DEMAIS  ");
        /*"  10   CB0020 PIC X(050) VALUE      '                                               '*/
        public StringBasis CB0020 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"                                               ");
        /*" 07     TABELA-COBERTURAS-R REDEFINES TABELA-COBERTURAS*/
    }
}