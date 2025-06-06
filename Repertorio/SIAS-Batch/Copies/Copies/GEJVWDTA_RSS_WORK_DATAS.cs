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
    public class GEJVWDTA_RSS_WORK_DATAS : VarBasis
    {
        /*"   05       WS-WHEN-COMPILED    PIC  X(021)      VALUE SPACES.*/
        public StringBasis WS_WHEN_COMPILED { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
        /*"   05       FILLER              REDEFINES WS-WHEN-COMPILED.*/
        private _REDEF_GEJVWDTA_FILLER _filler { get; set; }
        public _REDEF_GEJVWDTA_FILLER FILLER
        {
            get { _filler = new _REDEF_GEJVWDTA_FILLER(); _.Move(WS_WHEN_COMPILED, _filler); VarBasis.RedefinePassValue(WS_WHEN_COMPILED, _filler, WS_WHEN_COMPILED); _filler.ValueChanged += () => { _.Move(_filler, WS_WHEN_COMPILED); }; return _filler; }
            set { VarBasis.RedefinePassValue(value, _filler, WS_WHEN_COMPILED); }
        }  //Redefines

        public StringBasis WS_COMPILED_EDIT { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
        /*"   05       WS-CURRENT-DATE     PIC  X(021)      VALUE SPACES.*/
        public StringBasis WS_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
        /*"   05       FILLER              REDEFINES WS-CURRENT-DATE.*/
        private _REDEF_GEJVWDTA_FILLER_0 _filler_0 { get; set; }
        public _REDEF_GEJVWDTA_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_GEJVWDTA_FILLER_0(); _.Move(WS_CURRENT_DATE, _filler_0); VarBasis.RedefinePassValue(WS_CURRENT_DATE, _filler_0, WS_CURRENT_DATE); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_CURRENT_DATE); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, WS_CURRENT_DATE); }
        }  //Redefines

        public StringBasis WS_CURRENT_EDIT { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
        /*"*/
    }
}