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
    public class VGMOVFUN_DCLVG_MOV_FUNCIONARIO : VarBasis
    {
        /*"    10 VGMOVFUN-NUM-PROPOSTA-SIVPF  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGMOVFUN_NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGMOVFUN-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis VGMOVFUN_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGMOVFUN-NUM-CPF     PIC S9(14)V USAGE COMP-3.*/
        public DoubleBasis VGMOVFUN_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
        /*"    10 VGMOVFUN-DTH-FIM-VIGENCIA  PIC X(10).*/
        public StringBasis VGMOVFUN_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGMOVFUN-NUM-NIVEL-CARGO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGMOVFUN_NUM_NIVEL_CARGO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGMOVFUN-NUM-MATRICULA  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGMOVFUN_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGMOVFUN-NOM-FUNCIONARIO  PIC X(40).*/
        public StringBasis VGMOVFUN_NOM_FUNCIONARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 VGMOVFUN-DTH-NASCIMENTO  PIC X(10).*/
        public StringBasis VGMOVFUN_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGMOVFUN-NUM-IDADE   PIC S9(4) USAGE COMP.*/
        public IntBasis VGMOVFUN_NUM_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGMOVFUN-STA-SEXO    PIC X(1).*/
        public StringBasis VGMOVFUN_STA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGMOVFUN-STA-ESTADO-CIVIL  PIC X(1).*/
        public StringBasis VGMOVFUN_STA_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGMOVFUN-COD-PROFISSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGMOVFUN_COD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGMOVFUN-IND-REPR-EMPRE  PIC X(1).*/
        public StringBasis VGMOVFUN_IND_REPR_EMPRE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGMOVFUN-IND-IMP-DPS  PIC X(1).*/
        public StringBasis VGMOVFUN_IND_IMP_DPS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGMOVFUN-DES-MOTIVO.*/
        public VGMOVFUN_VGMOVFUN_DES_MOTIVO VGMOVFUN_DES_MOTIVO { get; set; } = new VGMOVFUN_VGMOVFUN_DES_MOTIVO();

        public IntBasis VGMOVFUN_NUM_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGMOVFUN-NUM-TELEFONE  PIC S9(9) USAGE COMP.*/
        public IntBasis VGMOVFUN_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VGMOVFUN-NUM-RG      PIC X(15).*/
        public StringBasis VGMOVFUN_NUM_RG { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 VGMOVFUN-COD-ORGAO-RG  PIC X(10).*/
        public StringBasis VGMOVFUN_COD_ORGAO_RG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGMOVFUN-COD-UF-ORGAO-RG  PIC X(2).*/
        public StringBasis VGMOVFUN_COD_UF_ORGAO_RG { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VGMOVFUN-DTH-EMISSAO-RG  PIC X(10).*/
        public StringBasis VGMOVFUN_DTH_EMISSAO_RG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGMOVFUN-STA-FUNCIONARIO  PIC X(1).*/
        public StringBasis VGMOVFUN_STA_FUNCIONARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGMOVFUN-COD-USUARIO  PIC X(8).*/
        public StringBasis VGMOVFUN_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGMOVFUN-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis VGMOVFUN_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}