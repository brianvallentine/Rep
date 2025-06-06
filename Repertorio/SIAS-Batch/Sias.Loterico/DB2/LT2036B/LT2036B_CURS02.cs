using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2036B
{
    public class LT2036B_CURS02 : QueryBasis<LT2036B_CURS02>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public LT2036B_CURS02() { IsCursor = true; }

        public LT2036B_CURS02(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string OUTROCOB_COD_COBERTURA { get; set; }
        public string OUTROCOB_IMP_SEGURADA_IX { get; set; }
        public string OUTROCOB_PRM_TARIFARIO_IX { get; set; }
        public string OUTROCOB_VAL_FRANQ_OBR_IX { get; set; }

        public new void Open()
        {
            if (!IsProcedure)
                SetQuery(GetQueryEvent());
            base.Open();
        }


        public new bool Fetch()
        {
            if (!JustACursor)
            {
                var idx = CurrentIndex;
                Open();
                CurrentIndex = idx > -1 ? idx : 0;
            }

            return base.Fetch();
        }


        public override LT2036B_CURS02 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new LT2036B_CURS02();
            var i = 0;

            dta.OUTROCOB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.OUTROCOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.OUTROCOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.OUTROCOB_VAL_FRANQ_OBR_IX = result[i++].Value?.ToString();

            return dta;
        }

    }
}