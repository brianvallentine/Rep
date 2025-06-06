using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0031B
{
    public class SI0031B_C01_SISINFAS : QueryBasis<SI0031B_C01_SISINFAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0031B_C01_SISINFAS() { IsCursor = true; }

        public SI0031B_C01_SISINFAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SISINFAS_COD_FASE { get; set; }
        public string SISINFAS_NUM_OCORR_SINIACO { get; set; }

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


        public override SI0031B_C01_SISINFAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0031B_C01_SISINFAS();
            var i = 0;

            dta.SISINFAS_COD_FASE = result[i++].Value?.ToString();
            dta.SISINFAS_NUM_OCORR_SINIACO = result[i++].Value?.ToString();

            return dta;
        }

    }
}