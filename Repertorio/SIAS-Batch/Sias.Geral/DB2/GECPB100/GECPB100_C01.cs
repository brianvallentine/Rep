using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GECPB100
{
    public class GECPB100_C01 : QueryBasis<GECPB100_C01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GECPB100_C01() { IsCursor = true; }

        public GECPB100_C01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GE536_COD_EMPRESA { get; set; }
        public string GE538_DES_EMPRESA { get; set; }
        public string GE537_COD_ORIGEM { get; set; }
        public string VIND_COD_ORIGEM { get; set; }
        public string GE538_DES_ORIGEM { get; set; }
        public string GE537_DTA_MOVIMENTO { get; set; }
        public string C01_COD_TIPO_OCOR { get; set; }
        public string C01_QTD { get; set; }

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


        public override GECPB100_C01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GECPB100_C01();
            var i = 0;

            dta.GE536_COD_EMPRESA = result[i++].Value?.ToString();
            dta.GE538_DES_EMPRESA = result[i++].Value?.ToString();
            dta.GE537_COD_ORIGEM = result[i++].Value?.ToString();
            dta.VIND_COD_ORIGEM = string.IsNullOrWhiteSpace(dta.GE537_COD_ORIGEM) ? "-1" : "0";
            dta.GE538_DES_ORIGEM = result[i++].Value?.ToString();
            dta.GE537_DTA_MOVIMENTO = result[i++].Value?.ToString();
            dta.C01_COD_TIPO_OCOR = result[i++].Value?.ToString();
            dta.C01_QTD = result[i++].Value?.ToString();

            return dta;
        }

    }
}