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
    public class LBFPF160_REGISTRO_VIDA_EMPRESARIAL : VarBasis
    {
        /*"  10   R6-TIPO-REG                     PIC  X(001)*/
        public StringBasis R6_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"  10   R6-NUM-PROPOSTA                 PIC  9(014)*/
        public IntBasis R6_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"  10   R6-TIPO-INFORMACAO              PIC  9(002)*/
        public IntBasis R6_TIPO_INFORMACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"  10   R6-INFO                         PIC  X(283)*/
        public StringBasis R6_INFO { get; set; } = new StringBasis(new PIC("X", "283", "X(283)"), @"");
        /*"  10   R6-INFO-EMPRESA                 REDEFINES                                       R6-INFO*/
        private _REDEF_LBFPF160_R6_INFO_EMPRESA _r6_info_empresa { get; set; }
        public _REDEF_LBFPF160_R6_INFO_EMPRESA R6_INFO_EMPRESA
        {
            get { _r6_info_empresa = new _REDEF_LBFPF160_R6_INFO_EMPRESA(); _.Move(R6_INFO, _r6_info_empresa); VarBasis.RedefinePassValue(R6_INFO, _r6_info_empresa, R6_INFO); _r6_info_empresa.ValueChanged += () => { _.Move(_r6_info_empresa, R6_INFO); }; return _r6_info_empresa; }
            set { VarBasis.RedefinePassValue(value, _r6_info_empresa, R6_INFO); }
        }  //Redefines

        private _REDEF_LBFPF160_R6_INFO_FUNCIONARIO _r6_info_funcionario { get; set; }
        public _REDEF_LBFPF160_R6_INFO_FUNCIONARIO R6_INFO_FUNCIONARIO
        {
            get { _r6_info_funcionario = new _REDEF_LBFPF160_R6_INFO_FUNCIONARIO(); _.Move(R6_INFO, _r6_info_funcionario); VarBasis.RedefinePassValue(R6_INFO, _r6_info_funcionario, R6_INFO); _r6_info_funcionario.ValueChanged += () => { _.Move(_r6_info_funcionario, R6_INFO); }; return _r6_info_funcionario; }
            set { VarBasis.RedefinePassValue(value, _r6_info_funcionario, R6_INFO); }
        }  //Redefines

        private _REDEF_LBFPF160_R6_INFO_COBERTURAS_FUNC _r6_info_coberturas_func { get; set; }
        public _REDEF_LBFPF160_R6_INFO_COBERTURAS_FUNC R6_INFO_COBERTURAS_FUNC
        {
            get { _r6_info_coberturas_func = new _REDEF_LBFPF160_R6_INFO_COBERTURAS_FUNC(); _.Move(R6_INFO, _r6_info_coberturas_func); VarBasis.RedefinePassValue(R6_INFO, _r6_info_coberturas_func, R6_INFO); _r6_info_coberturas_func.ValueChanged += () => { _.Move(_r6_info_coberturas_func, R6_INFO); }; return _r6_info_coberturas_func; }
            set { VarBasis.RedefinePassValue(value, _r6_info_coberturas_func, R6_INFO); }
        }  //Redefines

        private _REDEF_LBFPF160_R6_INFO_CNPJ_FILIAL _r6_info_cnpj_filial { get; set; }
        public _REDEF_LBFPF160_R6_INFO_CNPJ_FILIAL R6_INFO_CNPJ_FILIAL
        {
            get { _r6_info_cnpj_filial = new _REDEF_LBFPF160_R6_INFO_CNPJ_FILIAL(); _.Move(R6_INFO, _r6_info_cnpj_filial); VarBasis.RedefinePassValue(R6_INFO, _r6_info_cnpj_filial, R6_INFO); _r6_info_cnpj_filial.ValueChanged += () => { _.Move(_r6_info_cnpj_filial, R6_INFO); }; return _r6_info_cnpj_filial; }
            set { VarBasis.RedefinePassValue(value, _r6_info_cnpj_filial, R6_INFO); }
        }  //Redefines

        private _REDEF_LBFPF160_R6_INFO_EMPRESA_MEI _r6_info_empresa_mei { get; set; }
        public _REDEF_LBFPF160_R6_INFO_EMPRESA_MEI R6_INFO_EMPRESA_MEI
        {
            get { _r6_info_empresa_mei = new _REDEF_LBFPF160_R6_INFO_EMPRESA_MEI(); _.Move(R6_INFO, _r6_info_empresa_mei); VarBasis.RedefinePassValue(R6_INFO, _r6_info_empresa_mei, R6_INFO); _r6_info_empresa_mei.ValueChanged += () => { _.Move(_r6_info_empresa_mei, R6_INFO); }; return _r6_info_empresa_mei; }
            set { VarBasis.RedefinePassValue(value, _r6_info_empresa_mei, R6_INFO); }
        }  //Redefines

    }
}