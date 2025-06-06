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
    public class GECPB100_C02 : QueryBasis<GECPB100_C02>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GECPB100_C02() { IsCursor = true; }

        public GECPB100_C02(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GE540_COD_EMPRESA { get; set; }
        public string GE538_DES_EMPRESA { get; set; }
        public string GE537_NUM_IDLG { get; set; }
        public string VIND_NUM_IDLG { get; set; }
        public string GE540_COD_ID_PAGAM_COBR { get; set; }
        public string GE540_NUM_NSA_SAP { get; set; }
        public string GE540_SEQ_REGISTRO { get; set; }
        public string GE541_DTA_GERACAO_ARQ { get; set; }
        public string C02_STA_CONSUMO { get; set; }
        public string GE577_COD_RETORNO_ARQ_H { get; set; }
        public string GE576_DES_RETORNO_ARQ_H { get; set; }
        public string C02_QTD { get; set; }

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


        public override GECPB100_C02 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GECPB100_C02();
            var i = 0;

            dta.GE540_COD_EMPRESA = result[i++].Value?.ToString();
            dta.GE538_DES_EMPRESA = result[i++].Value?.ToString();
            dta.GE537_NUM_IDLG = result[i++].Value?.ToString();
            dta.VIND_NUM_IDLG = string.IsNullOrWhiteSpace(dta.GE537_NUM_IDLG) ? "-1" : "0";
            dta.GE540_COD_ID_PAGAM_COBR = result[i++].Value?.ToString();
            dta.GE540_NUM_NSA_SAP = result[i++].Value?.ToString();
            dta.GE540_SEQ_REGISTRO = result[i++].Value?.ToString();
            dta.GE541_DTA_GERACAO_ARQ = result[i++].Value?.ToString();
            dta.C02_STA_CONSUMO = result[i++].Value?.ToString();
            dta.GE577_COD_RETORNO_ARQ_H = result[i++].Value?.ToString();
            dta.GE576_DES_RETORNO_ARQ_H = result[i++].Value?.ToString();
            dta.C02_QTD = result[i++].Value?.ToString();

            return dta;
        }

    }
}