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
    public class _REDEF_LXFPF024_R24_INFO_R : VarBasis
    {
        /*"       15 R24-INFO-CORRESPONDENCIA     PIC  9(001)*/
        public IntBasis R24_INFO_CORRESPONDENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"       15 R24-IC-GRAURISCO             PIC  9(002)*/
        public IntBasis R24_IC_GRAURISCO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"       15 R24-COD-CNAE                 PIC  9(010)*/
        public IntBasis R24_COD_CNAE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"       15 R24-DDD-TEL-FAX              PIC  9(003)*/
        public IntBasis R24_DDD_TEL_FAX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"       15 R24-NUM-TEL-FAX              PIC  9(009)*/
        public IntBasis R24_NUM_TEL_FAX { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"       15 R24-NUM-CARTAO*/
        public LXFPF024_R24_NUM_CARTAO R24_NUM_CARTAO { get; set; } = new LXFPF024_R24_NUM_CARTAO();

        private _REDEF_IntBasis _r24_num_cartao_r { get; set; }
        public _REDEF_IntBasis R24_NUM_CARTAO_R
        {
            get { _r24_num_cartao_r = new _REDEF_IntBasis(new PIC("9", "016", "9(016)")); ; _.Move(R24_NUM_CARTAO, _r24_num_cartao_r); VarBasis.RedefinePassValue(R24_NUM_CARTAO, _r24_num_cartao_r, R24_NUM_CARTAO); _r24_num_cartao_r.ValueChanged += () => { _.Move(_r24_num_cartao_r, R24_NUM_CARTAO); }; return _r24_num_cartao_r; }
            set { VarBasis.RedefinePassValue(value, _r24_num_cartao_r, R24_NUM_CARTAO); }
        }  //Redefines
        /*"       15 R24-AREA-ADMINIST            PIC  X(001)*/
        public StringBasis R24_AREA_ADMINIST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"       15 R24-BCOCTADEB                PIC  9(003)*/
        public IntBasis R24_BCOCTADEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"       15 R24-AGECTADEB                PIC  9(004)*/
        public IntBasis R24_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"       15 R24-OPRCTADEB                PIC  9(004)*/
        public IntBasis R24_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"       15 R24-NUMCTADEB                PIC  9(012)*/
        public IntBasis R24_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
        /*"       15 R24-DIGCTADEB                PIC  X(001)*/
        public StringBasis R24_DIGCTADEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"       15 R24-NOM-MAE                  PIC  X(040)*/
        public StringBasis R24_NOM_MAE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"       15 R24-NUM-CART                 PIC  9(015)*/
        public IntBasis R24_NUM_CART { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"       15 FILLER                       PIC  X(006)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
        /*"       15 R24-PAIS-DESTINO             PIC  9(004)*/
        public IntBasis R24_PAIS_DESTINO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"       15 R24-DT-IDA-VIAGEM            PIC  9(008)*/
        public IntBasis R24_DT_IDA_VIAGEM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"       15 R24-DT-VLT-VIAGEM            PIC  9(008)*/
        public IntBasis R24_DT_VLT_VIAGEM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"       15 R24-PRAZO-VIGENCIA           PIC  X(002)*/
        public StringBasis R24_PRAZO_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"       15 FILLER                       PIC  X(134)*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "134", "X(134)"), @"");
        /*"    10    R24-INFO-R2 REDEFINES R24-INFO*/

        public _REDEF_LXFPF024_R24_INFO_R()
        {
            R24_INFO_CORRESPONDENCIA.ValueChanged += OnValueChanged;
            R24_IC_GRAURISCO.ValueChanged += OnValueChanged;
            R24_COD_CNAE.ValueChanged += OnValueChanged;
            R24_DDD_TEL_FAX.ValueChanged += OnValueChanged;
            R24_NUM_TEL_FAX.ValueChanged += OnValueChanged;
            R24_NUM_CARTAO.ValueChanged += OnValueChanged;
            R24_NUM_CARTAO_R.ValueChanged += OnValueChanged;
        }

    }
}