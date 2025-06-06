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
    public class LXFPF004_REG_BILHETE_AP : VarBasis
    {
        /*"    05          R-AP-COMUM*/
        public LXFPF004_R_AP_COMUM R_AP_COMUM { get; set; } = new LXFPF004_R_AP_COMUM();

        public IntBasis R_AP_NUMBIL { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
        /*"    05          R-AP-AGECOBR               PIC  9(004)*/
        public IntBasis R_AP_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05          R-AP-INDICADOR*/
        public LXFPF004_R_AP_INDICADOR R_AP_INDICADOR { get; set; } = new LXFPF004_R_AP_INDICADOR();

        public IntBasis R_AP_FILIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    05          R-AP-SEGURADO              PIC  X(040)*/
        public StringBasis R_AP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"    05          R-AP-CPF                   PIC  9(011)*/
        public IntBasis R_AP_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
        /*"    05          R-AP-CPF-R      REDEFINES  R-AP-CPF*/
        private _REDEF_LXFPF004_R_AP_CPF_R _r_ap_cpf_r { get; set; }
        public _REDEF_LXFPF004_R_AP_CPF_R R_AP_CPF_R
        {
            get { _r_ap_cpf_r = new _REDEF_LXFPF004_R_AP_CPF_R(); _.Move(R_AP_CPF, _r_ap_cpf_r); VarBasis.RedefinePassValue(R_AP_CPF, _r_ap_cpf_r, R_AP_CPF); _r_ap_cpf_r.ValueChanged += () => { _.Move(_r_ap_cpf_r, R_AP_CPF); }; return _r_ap_cpf_r; }
            set { VarBasis.RedefinePassValue(value, _r_ap_cpf_r, R_AP_CPF); }
        }  //Redefines

        public IntBasis R_AP_DTNASC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    05          R-AP-PROFISSAO             PIC  X(020)*/
        public StringBasis R_AP_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"    05          R-AP-SEXO                  PIC  X(001)*/
        public StringBasis R_AP_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    05          R-AP-ESTCIVIL              PIC  X(001)*/
        public StringBasis R_AP_ESTCIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    05          R-AP-DDD                   PIC  9(004)*/
        public IntBasis R_AP_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05          R-AP-TELEFONE              PIC  9(007)*/
        public IntBasis R_AP_TELEFONE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05          R-AP-ENDERECO              PIC  X(040)*/
        public StringBasis R_AP_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"    05          R-AP-BAIRRO                PIC  X(020)*/
        public StringBasis R_AP_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"    05          R-AP-CIDADE                PIC  X(020)*/
        public StringBasis R_AP_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"    05          R-AP-UF                    PIC  X(002)*/
        public StringBasis R_AP_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"    05          R-AP-CEP                   PIC  9(008)*/
        public IntBasis R_AP_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    05          R-AP-OPCAO                 PIC  9(001)*/
        public IntBasis R_AP_OPCAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    05          R-AP-DTQITBCO              PIC  9(008)*/
        public IntBasis R_AP_DTQITBCO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    05          R-AP-VAL-RECIBO            PIC  9(011)V99*/
        public DoubleBasis R_AP_VAL_RECIBO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
        /*"    05          R-AP-CONTA-DEBITO*/
        public LXFPF004_R_AP_CONTA_DEBITO R_AP_CONTA_DEBITO { get; set; } = new LXFPF004_R_AP_CONTA_DEBITO();

    }
}