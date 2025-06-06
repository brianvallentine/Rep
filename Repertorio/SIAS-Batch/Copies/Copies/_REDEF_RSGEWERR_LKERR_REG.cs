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
    public class _REDEF_RSGEWERR_LKERR_REG : VarBasis
    {
        /*"  05 LKERR-PROGRAMA                PIC  X(015)*/
        public StringBasis LKERR_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"  05 LKERR-DTHCATAL                PIC  X(022)*/
        public StringBasis LKERR_DTHCATAL { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
        /*"  05 LKERR-ORIGEM                  PIC  X(030)*/
        public StringBasis LKERR_ORIGEM { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"  05 LKERR-USUARIO                 PIC  X(008)*/
        public StringBasis LKERR_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"  05 LKERR-ROTINA                  PIC  X(100)*/
        public StringBasis LKERR_ROTINA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"  05 LKERR-FUNCAO                  PIC  X(100)*/
        public StringBasis LKERR_FUNCAO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"  05 LKERR-OBJETOS                 PIC  X(100)*/
        public StringBasis LKERR_OBJETOS { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"  05 LKERR-ELEMENTOS               PIC  X(300)*/
        public StringBasis LKERR_ELEMENTOS { get; set; } = new StringBasis(new PIC("X", "300", "X(300)"), @"");
        /*"  05 LKERR-LINKAGE                 PIC  X(10000)*/
        public StringBasis LKERR_LINKAGE { get; set; } = new StringBasis(new PIC("X", "10000", "X(10000)"), @"");
        /*"  05 LKERR-IND-ERRO                PIC  9(004)*/
        public IntBasis LKERR_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  05 LKERR-MENSAGEM                PIC  X(300)*/
        public StringBasis LKERR_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "300", "X(300)"), @"");
        /*"  05 LKERR-PROTOCOLO               PIC  X(026)*/
        public StringBasis LKERR_PROTOCOLO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"  05 LKERR-MENSAGEM-RETORNO        PIC  X(133)*/
        public StringBasis LKERR_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "133", "X(133)"), @"");
        /*"*/

        public _REDEF_RSGEWERR_LKERR_REG()
        {
            LKERR_PROGRAMA.ValueChanged += OnValueChanged;
            LKERR_DTHCATAL.ValueChanged += OnValueChanged;
            LKERR_ORIGEM.ValueChanged += OnValueChanged;
            LKERR_USUARIO.ValueChanged += OnValueChanged;
            LKERR_ROTINA.ValueChanged += OnValueChanged;
            LKERR_FUNCAO.ValueChanged += OnValueChanged;
            LKERR_OBJETOS.ValueChanged += OnValueChanged;
            LKERR_ELEMENTOS.ValueChanged += OnValueChanged;
            LKERR_LINKAGE.ValueChanged += OnValueChanged;
            LKERR_IND_ERRO.ValueChanged += OnValueChanged;
            LKERR_MENSAGEM.ValueChanged += OnValueChanged;
            LKERR_PROTOCOLO.ValueChanged += OnValueChanged;
            LKERR_MENSAGEM_RETORNO.ValueChanged += OnValueChanged;
        }

    }
}