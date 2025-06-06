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
    public class VGFOLLOW_DCLVG_FOLLOW_UP : VarBasis
    {
        /*"    10 VGFOLLOW-NOM-ARQUIVO  PIC X(8).*/
        public StringBasis VGFOLLOW_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGFOLLOW-SEQ-GERACAO  PIC S9(9) USAGE COMP.*/
        public IntBasis VGFOLLOW_SEQ_GERACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VGFOLLOW-NUM-FITA-CEF  PIC S9(9) USAGE COMP.*/
        public IntBasis VGFOLLOW_NUM_FITA_CEF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VGFOLLOW-NUM-NOSSA-FITA  PIC S9(9) USAGE COMP.*/
        public IntBasis VGFOLLOW_NUM_NOSSA_FITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VGFOLLOW-NUM-LANCAMENTO  PIC S9(9) USAGE COMP.*/
        public IntBasis VGFOLLOW_NUM_LANCAMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VGFOLLOW-COD-CONVENIO  PIC S9(9) USAGE COMP.*/
        public IntBasis VGFOLLOW_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VGFOLLOW-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGFOLLOW_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGFOLLOW-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis VGFOLLOW_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGFOLLOW-STA-PROCESSAMENTO  PIC X(1).*/
        public StringBasis VGFOLLOW_STA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGFOLLOW-NUM-VERSAO-LAYOUT  PIC S9(4) USAGE COMP.*/
        public IntBasis VGFOLLOW_NUM_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGFOLLOW-REG-LANCAMENTO  PIC X(150).*/
        public StringBasis VGFOLLOW_REG_LANCAMENTO { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"    10 VGFOLLOW-COD-USUARIO  PIC X(8).*/
        public StringBasis VGFOLLOW_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGFOLLOW-DTH-ATUALIZACAO  PIC X(26).*/
        public StringBasis VGFOLLOW_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VGFOLLOW-NUM-PARCELA-USADA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGFOLLOW_NUM_PARCELA_USADA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}