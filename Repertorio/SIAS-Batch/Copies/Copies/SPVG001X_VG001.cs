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
    public class SPVG001X_VG001 : VarBasis
    {
        /*" 05  VG001-ARR-STA-I                 PIC S9(004) COMP VALUE 12*/
        public IntBasis VG001_ARR_STA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 12);
        /*" 05  VG001-ARR-STA-J                 PIC S9(004) COMP VALUE 4*/
        public IntBasis VG001_ARR_STA_J { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 4);
        /*" 05  VG001-ARR-STA*/
        public SPVG001X_VG001_ARR_STA VG001_ARR_STA { get; set; } = new SPVG001X_VG001_ARR_STA();

        private _REDEF_SPVG001X_FILLER _filler { get; set; }
        public _REDEF_SPVG001X_FILLER FILLER
        {
            get { _filler = new _REDEF_SPVG001X_FILLER(); _.Move(VG001_ARR_STA, _filler); VarBasis.RedefinePassValue(VG001_ARR_STA, _filler, VG001_ARR_STA); _filler.ValueChanged += () => { _.Move(_filler, VG001_ARR_STA); }; return _filler; }
            set { VarBasis.RedefinePassValue(value, _filler, VG001_ARR_STA); }
        }  //Redefines

    }
}