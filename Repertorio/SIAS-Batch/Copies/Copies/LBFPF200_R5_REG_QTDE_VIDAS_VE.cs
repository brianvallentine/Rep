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
    public class LBFPF200_R5_REG_QTDE_VIDAS_VE : VarBasis
    {
        /*"     05       R5-TIPO-REG                 PIC  X(001)*/
        public StringBasis R5_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     05       R5-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R5_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     05       R5-DADOS-VE-ANTIGO*/
        public LBFPF200_R5_DADOS_VE_ANTIGO R5_DADOS_VE_ANTIGO { get; set; } = new LBFPF200_R5_DADOS_VE_ANTIGO();

        private _REDEF_LBFPF200_R5_DADOS_VE_NOVO _r5_dados_ve_novo { get; set; }
        public _REDEF_LBFPF200_R5_DADOS_VE_NOVO R5_DADOS_VE_NOVO
        {
            get { _r5_dados_ve_novo = new _REDEF_LBFPF200_R5_DADOS_VE_NOVO(); _.Move(R5_DADOS_VE_ANTIGO, _r5_dados_ve_novo); VarBasis.RedefinePassValue(R5_DADOS_VE_ANTIGO, _r5_dados_ve_novo, R5_DADOS_VE_ANTIGO); _r5_dados_ve_novo.ValueChanged += () => { _.Move(_r5_dados_ve_novo, R5_DADOS_VE_ANTIGO); }; return _r5_dados_ve_novo; }
            set { VarBasis.RedefinePassValue(value, _r5_dados_ve_novo, R5_DADOS_VE_ANTIGO); }
        }  //Redefines

    }
}