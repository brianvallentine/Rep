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
    public class LBTB3101_TABELA_CLASSES : VarBasis
    {
        /*" 07     TAB-CLASSES*/
        public LBTB3101_TAB_CLASSES TAB_CLASSES { get; set; } = new LBTB3101_TAB_CLASSES();

        private _REDEF_LBTB3101_TAB_CLASSES_R _tab_classes_r { get; set; }
        public _REDEF_LBTB3101_TAB_CLASSES_R TAB_CLASSES_R
        {
            get { _tab_classes_r = new _REDEF_LBTB3101_TAB_CLASSES_R(); _.Move(TAB_CLASSES, _tab_classes_r); VarBasis.RedefinePassValue(TAB_CLASSES, _tab_classes_r, TAB_CLASSES); _tab_classes_r.ValueChanged += () => { _.Move(_tab_classes_r, TAB_CLASSES); }; return _tab_classes_r; }
            set { VarBasis.RedefinePassValue(value, _tab_classes_r, TAB_CLASSES); }
        }  //Redefines

    }
}