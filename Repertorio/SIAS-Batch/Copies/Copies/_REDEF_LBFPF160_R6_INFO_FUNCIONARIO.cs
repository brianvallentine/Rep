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
    public class _REDEF_LBFPF160_R6_INFO_FUNCIONARIO : VarBasis
    {
        /*"    15 R6-NUM-FUNC                     PIC  9(003)*/
        public IntBasis R6_NUM_FUNC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    15 R6-CPF-FUNC                     PIC  9(014)*/
        public IntBasis R6_CPF_FUNC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"    15 R6-NOME-FUNC                    PIC  X(040)*/
        public StringBasis R6_NOME_FUNC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"    15 R6-DATA-NASC-FUNC               PIC  9(008)*/
        public IntBasis R6_DATA_NASC_FUNC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    15 R6-IDADE-FUNC                   PIC  9(003)*/
        public IntBasis R6_IDADE_FUNC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    15 R6-SEXO-FUNC                    PIC  9(002)*/
        public IntBasis R6_SEXO_FUNC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    15 R6-ESTADO-CIVIL-FUNC            PIC  9(002)*/
        public IntBasis R6_ESTADO_CIVIL_FUNC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    15 R6-DDD-FUNC                     PIC  9(003)*/
        public IntBasis R6_DDD_FUNC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    15 R6-TEL-FUNC                     PIC  9(009)*/
        public IntBasis R6_TEL_FUNC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    15 R6-RG-FUNC                      PIC  X(015)*/
        public StringBasis R6_RG_FUNC { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"    15 R6-ORGAO-RG-FUNC                PIC  X(010)*/
        public StringBasis R6_ORGAO_RG_FUNC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"    15 R6-UF-RG-FUNC                   PIC  X(002)*/
        public StringBasis R6_UF_RG_FUNC { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"    15 R6-DATA-EMIS-RG-FUNC            PIC  9(008)*/
        public IntBasis R6_DATA_EMIS_RG_FUNC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    15 R6-CBO-FUNC                     PIC  9(003)*/
        public IntBasis R6_CBO_FUNC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    15 R6-NIVEL-CARGO-FUNC             PIC  9(002)*/
        public IntBasis R6_NIVEL_CARGO_FUNC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    15 R6-IND-REPRESE-FUNC             PIC  X(001)*/
        public StringBasis R6_IND_REPRESE_FUNC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    15 R6-IND-IMP-DPS-FUNC             PIC  X(001)*/
        public StringBasis R6_IND_IMP_DPS_FUNC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    15 R6-IND-FAIXA-RENDA              PIC  9(001)*/
        public IntBasis R6_IND_FAIXA_RENDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    15 FILLER                          PIC  X(155)*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "155", "X(155)"), @"");
        /*"  10   R6-INFO-COBERTURAS-FUNC         REDEFINES                                       R6-INFO*/

        public _REDEF_LBFPF160_R6_INFO_FUNCIONARIO()
        {
            R6_NUM_FUNC.ValueChanged += OnValueChanged;
            R6_CPF_FUNC.ValueChanged += OnValueChanged;
            R6_NOME_FUNC.ValueChanged += OnValueChanged;
            R6_DATA_NASC_FUNC.ValueChanged += OnValueChanged;
            R6_IDADE_FUNC.ValueChanged += OnValueChanged;
            R6_SEXO_FUNC.ValueChanged += OnValueChanged;
            R6_ESTADO_CIVIL_FUNC.ValueChanged += OnValueChanged;
            R6_DDD_FUNC.ValueChanged += OnValueChanged;
            R6_TEL_FUNC.ValueChanged += OnValueChanged;
            R6_RG_FUNC.ValueChanged += OnValueChanged;
            R6_ORGAO_RG_FUNC.ValueChanged += OnValueChanged;
            R6_UF_RG_FUNC.ValueChanged += OnValueChanged;
            R6_DATA_EMIS_RG_FUNC.ValueChanged += OnValueChanged;
            R6_CBO_FUNC.ValueChanged += OnValueChanged;
            R6_NIVEL_CARGO_FUNC.ValueChanged += OnValueChanged;
            R6_IND_REPRESE_FUNC.ValueChanged += OnValueChanged;
            R6_IND_IMP_DPS_FUNC.ValueChanged += OnValueChanged;
            R6_IND_FAIXA_RENDA.ValueChanged += OnValueChanged;
            FILLER_0.ValueChanged += OnValueChanged;
        }

    }
}