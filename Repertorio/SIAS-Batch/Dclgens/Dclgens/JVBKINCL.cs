using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class JVBKINCL : VarBasis
    {
        /*"*/
        public IntBasis WS_IND_PROD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01    JV-CONTROLE*/
        public JVBKINCL_JV_CONTROLE JV_CONTROLE { get; set; } = new JVBKINCL_JV_CONTROLE();

        public JVBKINCL_JV_CONVENIOS JV_CONVENIOS { get; set; } = new JVBKINCL_JV_CONVENIOS();

        public JVBKINCL_JV_AGE_AVISO JV_AGE_AVISO { get; set; } = new JVBKINCL_JV_AGE_AVISO();

        public JVBKINCL_JV_PRODUTOS JV_PRODUTOS { get; set; } = new JVBKINCL_JV_PRODUTOS();

        private _REDEF_JVBKINCL_FILLER _filler { get; set; }
        public _REDEF_JVBKINCL_FILLER FILLER
        {
            get { _filler = new _REDEF_JVBKINCL_FILLER(); _.Move(JV_PRODUTOS, _filler); VarBasis.RedefinePassValue(JV_PRODUTOS, _filler, JV_PRODUTOS); _filler.ValueChanged += () => { _.Move(_filler, JV_PRODUTOS); }; return _filler; }
            set { VarBasis.RedefinePassValue(value, _filler, JV_PRODUTOS); }
        }  //Redefines

        public JVBKINCL_CVP_PRODUTOS_RUNOFF CVP_PRODUTOS_RUNOFF { get; set; } = new JVBKINCL_CVP_PRODUTOS_RUNOFF();

        private _REDEF_JVBKINCL_CVP_PRODUTO _cvp_produto { get; set; }
        public _REDEF_JVBKINCL_CVP_PRODUTO CVP_PRODUTO
        {
            get { _cvp_produto = new _REDEF_JVBKINCL_CVP_PRODUTO(); _.Move(CVP_PRODUTOS_RUNOFF, _cvp_produto); VarBasis.RedefinePassValue(CVP_PRODUTOS_RUNOFF, _cvp_produto, CVP_PRODUTOS_RUNOFF); _cvp_produto.ValueChanged += () => { _.Move(_cvp_produto, CVP_PRODUTOS_RUNOFF); }; return _cvp_produto; }
            set { VarBasis.RedefinePassValue(value, _cvp_produto, CVP_PRODUTOS_RUNOFF); }
        }  //Redefines

    }
}