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
    public class LBTB3100 : VarBasis
    {
        /*"*/
        public IntBasis WS_MEN { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01       TABELA-MESES*/
        public LBTB3100_TABELA_MESES TABELA_MESES { get; set; } = new LBTB3100_TABELA_MESES();

        public LBTB3100_TABELA_UF TABELA_UF { get; set; } = new LBTB3100_TABELA_UF();

        private _REDEF_LBTB3100_TABELA_UF_R _tabela_uf_r { get; set; }
        public _REDEF_LBTB3100_TABELA_UF_R TABELA_UF_R
        {
            get { _tabela_uf_r = new _REDEF_LBTB3100_TABELA_UF_R(); _.Move(TABELA_UF, _tabela_uf_r); VarBasis.RedefinePassValue(TABELA_UF, _tabela_uf_r, TABELA_UF); _tabela_uf_r.ValueChanged += () => { _.Move(_tabela_uf_r, TABELA_UF); }; return _tabela_uf_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_uf_r, TABELA_UF); }
        }  //Redefines

        public LBTB3100_TAB_EQUIP TAB_EQUIP { get; set; } = new LBTB3100_TAB_EQUIP();

        public LBTB3100_TAB_EQUIP_DESC TAB_EQUIP_DESC { get; set; } = new LBTB3100_TAB_EQUIP_DESC();

        public LBTB3100_TAB_IMPSEG TAB_IMPSEG { get; set; } = new LBTB3100_TAB_IMPSEG();

        public LBTB3100_TAB_TAXAS TAB_TAXAS { get; set; } = new LBTB3100_TAB_TAXAS();

        public LBTB3100_TAB_PREMIOS TAB_PREMIOS { get; set; } = new LBTB3100_TAB_PREMIOS();

        public LBTB3100_TAB_TAXAS_20042005 TAB_TAXAS_20042005 { get; set; } = new LBTB3100_TAB_TAXAS_20042005();

        private _REDEF_LBTB3100_TAB_TAXAS_20042005_R _tab_taxas_20042005_r { get; set; }
        public _REDEF_LBTB3100_TAB_TAXAS_20042005_R TAB_TAXAS_20042005_R
        {
            get { _tab_taxas_20042005_r = new _REDEF_LBTB3100_TAB_TAXAS_20042005_R(); _.Move(TAB_TAXAS_20042005, _tab_taxas_20042005_r); VarBasis.RedefinePassValue(TAB_TAXAS_20042005, _tab_taxas_20042005_r, TAB_TAXAS_20042005); _tab_taxas_20042005_r.ValueChanged += () => { _.Move(_tab_taxas_20042005_r, TAB_TAXAS_20042005); }; return _tab_taxas_20042005_r; }
            set { VarBasis.RedefinePassValue(value, _tab_taxas_20042005_r, TAB_TAXAS_20042005); }
        }  //Redefines

        public LBTB3100_TAB_TAXAS_2006 TAB_TAXAS_2006 { get; set; } = new LBTB3100_TAB_TAXAS_2006();

        private _REDEF_LBTB3100_TAB_TAXAS_2006_R _tab_taxas_2006_r { get; set; }
        public _REDEF_LBTB3100_TAB_TAXAS_2006_R TAB_TAXAS_2006_R
        {
            get { _tab_taxas_2006_r = new _REDEF_LBTB3100_TAB_TAXAS_2006_R(); _.Move(TAB_TAXAS_2006, _tab_taxas_2006_r); VarBasis.RedefinePassValue(TAB_TAXAS_2006, _tab_taxas_2006_r, TAB_TAXAS_2006); _tab_taxas_2006_r.ValueChanged += () => { _.Move(_tab_taxas_2006_r, TAB_TAXAS_2006); }; return _tab_taxas_2006_r; }
            set { VarBasis.RedefinePassValue(value, _tab_taxas_2006_r, TAB_TAXAS_2006); }
        }  //Redefines

    }
}