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
    public class LXFPF003_REG_BIL_RESID : VarBasis
    {
        /*"    05          RES-COMUM*/
        public LXFPF003_RES_COMUM RES_COMUM { get; set; } = new LXFPF003_RES_COMUM();

        public IntBasis RES_NUMBIL { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
        /*"    05          RES-AGECOBR           PIC  9(004)*/
        public IntBasis RES_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05          RES-INDICADOR*/
        public LXFPF003_RES_INDICADOR RES_INDICADOR { get; set; } = new LXFPF003_RES_INDICADOR();

        public IntBasis RES_FILIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    05          RES-SEGURADO          PIC  X(040)*/
        public StringBasis RES_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"    05          RES-CPF               PIC  9(011)*/
        public IntBasis RES_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
        /*"    05          RES-CPF-R REDEFINES   RES-CPF*/
        private _REDEF_LXFPF003_RES_CPF_R _res_cpf_r { get; set; }
        public _REDEF_LXFPF003_RES_CPF_R RES_CPF_R
        {
            get { _res_cpf_r = new _REDEF_LXFPF003_RES_CPF_R(); _.Move(RES_CPF, _res_cpf_r); VarBasis.RedefinePassValue(RES_CPF, _res_cpf_r, RES_CPF); _res_cpf_r.ValueChanged += () => { _.Move(_res_cpf_r, RES_CPF); }; return _res_cpf_r; }
            set { VarBasis.RedefinePassValue(value, _res_cpf_r, RES_CPF); }
        }  //Redefines

        public IntBasis RES_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05          RES-TELEFONE          PIC  9(007)*/
        public IntBasis RES_TELEFONE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05          RES-ENDERECO          PIC  X(040)*/
        public StringBasis RES_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"    05          RES-BAIRRO            PIC  X(020)*/
        public StringBasis RES_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"    05          RES-CIDADE            PIC  X(020)*/
        public StringBasis RES_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"    05          RES-UF                PIC  X(002)*/
        public StringBasis RES_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"    05          RES-CEP               PIC  9(008)*/
        public IntBasis RES_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    05          RES-OPCAO             PIC  9(001)*/
        public IntBasis RES_OPCAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    05          RES-DTQITBCO          PIC  9(008)*/
        public IntBasis RES_DTQITBCO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    05          RES-VAL-RECIBO        PIC  9(011)V99*/
        public DoubleBasis RES_VAL_RECIBO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
        /*"    05          RES-CONTA-DEBITO*/
        public LXFPF003_RES_CONTA_DEBITO RES_CONTA_DEBITO { get; set; } = new LXFPF003_RES_CONTA_DEBITO();

        public StringBasis RES_FILLER { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"*/
    }
}