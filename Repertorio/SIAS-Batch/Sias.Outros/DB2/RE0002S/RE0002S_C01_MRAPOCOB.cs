using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0002S
{
    public class RE0002S_C01_MRAPOCOB : QueryBasis<RE0002S_C01_MRAPOCOB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public RE0002S_C01_MRAPOCOB() { IsCursor = true; }

        public RE0002S_C01_MRAPOCOB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MRAPOCOB_COD_COBERTURA { get; set; }
        public string MRAPOCOB_RAMO_COBERTURA { get; set; }
        public string MRAPOCOB_MODALI_COBERTURA { get; set; }
        public string MRAPOCOB_IMP_SEGURADA_IX { get; set; }
        public string MRAPOCOB_PRM_TARIFARIO_VAR { get; set; }
        public string MRAPOCOB_COD_EMPRESA { get; set; }

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


        public override RE0002S_C01_MRAPOCOB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new RE0002S_C01_MRAPOCOB();
            var i = 0;

            dta.MRAPOCOB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.MRAPOCOB_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.MRAPOCOB_MODALI_COBERTURA = result[i++].Value?.ToString();
            dta.MRAPOCOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.MRAPOCOB_PRM_TARIFARIO_VAR = result[i++].Value?.ToString();
            dta.MRAPOCOB_COD_EMPRESA = result[i++].Value?.ToString();

            return dta;
        }

    }
}