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
    public class LBTB3201 : VarBasis
    {
        /*"*/
        public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_MEN { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_IUF4 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01       TABELA-VIG-PLURI*/
        public LBTB3201_TABELA_VIG_PLURI TABELA_VIG_PLURI { get; set; } = new LBTB3201_TABELA_VIG_PLURI();

        public LBTB3201_TABELA_MESES TABELA_MESES { get; set; } = new LBTB3201_TABELA_MESES();

        public LBTB3201_TABELA_UF TABELA_UF { get; set; } = new LBTB3201_TABELA_UF();

        private _REDEF_LBTB3201_TABELA_UF_R _tabela_uf_r { get; set; }
        public _REDEF_LBTB3201_TABELA_UF_R TABELA_UF_R
        {
            get { _tabela_uf_r = new _REDEF_LBTB3201_TABELA_UF_R(); _.Move(TABELA_UF, _tabela_uf_r); VarBasis.RedefinePassValue(TABELA_UF, _tabela_uf_r, TABELA_UF); _tabela_uf_r.ValueChanged += () => { _.Move(_tabela_uf_r, TABELA_UF); }; return _tabela_uf_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_uf_r, TABELA_UF); }
        }  //Redefines

        public LBTB3201_TABELA_UF_4 TABELA_UF_4 { get; set; } = new LBTB3201_TABELA_UF_4();

        private _REDEF_LBTB3201_TABELA_UF_4_R _tabela_uf_4_r { get; set; }
        public _REDEF_LBTB3201_TABELA_UF_4_R TABELA_UF_4_R
        {
            get { _tabela_uf_4_r = new _REDEF_LBTB3201_TABELA_UF_4_R(); _.Move(TABELA_UF_4, _tabela_uf_4_r); VarBasis.RedefinePassValue(TABELA_UF_4, _tabela_uf_4_r, TABELA_UF_4); _tabela_uf_4_r.ValueChanged += () => { _.Move(_tabela_uf_4_r, TABELA_UF_4); }; return _tabela_uf_4_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_uf_4_r, TABELA_UF_4); }
        }  //Redefines

        public LBTB3201_TABELA_REGIAO TABELA_REGIAO { get; set; } = new LBTB3201_TABELA_REGIAO();

        public LBTB3201_TABELA_CLASSES TABELA_CLASSES { get; set; } = new LBTB3201_TABELA_CLASSES();

        public LBTB3201_TABELA_DE_COBERTURAS TABELA_DE_COBERTURAS { get; set; } = new LBTB3201_TABELA_DE_COBERTURAS();

        public LBTB3201_TABELA_DE_FRANQUIAS TABELA_DE_FRANQUIAS { get; set; } = new LBTB3201_TABELA_DE_FRANQUIAS();

        public LBTB3201_TABELA_DE_LIM_MINMAX TABELA_DE_LIM_MINMAX { get; set; } = new LBTB3201_TABELA_DE_LIM_MINMAX();

        public LBTB3201_TABELA_DE_LIMITE_MINMAX TABELA_DE_LIMITE_MINMAX { get; set; } = new LBTB3201_TABELA_DE_LIMITE_MINMAX();

        public LBTB3201_TAB_EQUIP TAB_EQUIP { get; set; } = new LBTB3201_TAB_EQUIP();

        public LBTB3201_TAB_EQUIP_DESC TAB_EQUIP_DESC { get; set; } = new LBTB3201_TAB_EQUIP_DESC();

        public LBTB3201_TAB_IMPSEG TAB_IMPSEG { get; set; } = new LBTB3201_TAB_IMPSEG();

        public LBTB3201_TAB_TAXAS TAB_TAXAS { get; set; } = new LBTB3201_TAB_TAXAS();

        public LBTB3201_TAB_PREMIOS TAB_PREMIOS { get; set; } = new LBTB3201_TAB_PREMIOS();

        public LBTB3201_TAB_COEF TAB_COEF { get; set; } = new LBTB3201_TAB_COEF();

        public LBTB3201_TABELA_DE_LIM_MINMAX_CCA TABELA_DE_LIM_MINMAX_CCA { get; set; } = new LBTB3201_TABELA_DE_LIM_MINMAX_CCA();

        public LBTB3201_TABELA_DE_LIMITE_MINMAX_CCA TABELA_DE_LIMITE_MINMAX_CCA { get; set; } = new LBTB3201_TABELA_DE_LIMITE_MINMAX_CCA();

        public LBTB3201_TABELA_DE_LIM_MINMAX_CCAT TABELA_DE_LIM_MINMAX_CCAT { get; set; } = new LBTB3201_TABELA_DE_LIM_MINMAX_CCAT();

        public LBTB3201_TABELA_DE_LIMITE_MINMAX_CCAT TABELA_DE_LIMITE_MINMAX_CCAT { get; set; } = new LBTB3201_TABELA_DE_LIMITE_MINMAX_CCAT();

    }
}